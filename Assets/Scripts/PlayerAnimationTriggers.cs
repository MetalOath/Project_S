using System.Collections;
using System.Collections.Generic;
using StarterAssets;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

namespace StarterAssets
{
    public class PlayerAnimationTriggers : MonoBehaviour
    {
        public Animator anim;
        public StarterAssetsInputs input;

        public GameObject backBow, armedBow, shootingPoint;

        public GameObject arrowPrefab;

        private GameObject _mainCamera;
        
        // Start is called before the first frame update
        void Start()
        {
            anim = GetComponent<Animator>();
            _mainCamera = GameObject.FindWithTag("MainCamera");
        }

        // Update is called once per frame
        void Update()
        {
            anim.SetFloat("Horizontal", input.move.y);
            anim.SetFloat("Vertical", input.move.x);

            if (Mouse.current.rightButton.isPressed)
            {
                anim.SetBool("Armed", true);
                anim.SetBool("Aiming", true);

                if (Mouse.current.leftButton.wasPressedThisFrame)
                {
                    anim.SetTrigger("Shoot");
                }
            }
            else
            {
                anim.SetBool("Aiming", false);
            }

            if (anim.GetBool("Armed"))
            {
                backBow.SetActive(false);
                armedBow.SetActive(true);
            }
            else
            {
                backBow.SetActive(true);
                armedBow.SetActive(false);
            }

            if (Keyboard.current.zKey.wasPressedThisFrame)
            {
                anim.SetBool("Armed", !anim.GetBool("Armed"));
            }

            if (Keyboard.current.spaceKey.wasPressedThisFrame)
            {
                anim.SetTrigger("Jump");
            }

            if (Mouse.current.rightButton.wasPressedThisFrame)
            {
                if (!anim.GetBool("IsGrounded"))
                {
                    anim.SetTrigger("FallToAim");
                }
            }
        }

        public void ShootArrow()
        {
            Instantiate(arrowPrefab, shootingPoint.transform.position, shootingPoint.transform.rotation);

            //Instantiate(arrowPrefab, shootingPoint.transform.position, Quaternion.Euler(_mainCamera.transform.eulerAngles));
        }
    }
}