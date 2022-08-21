using System.Collections;
using System.Collections.Generic;
using StarterAssets;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

namespace StarterAssets
{
    public class CharMotionAnim : MonoBehaviour
    {
        public Animator anim;
        public StarterAssetsInputs input;
    
        // Start is called before the first frame update
        void Start()
        {
            anim = GetComponent<Animator>();
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

            if (Keyboard.current.zKey.wasPressedThisFrame)
            {
                anim.SetBool("Armed", !anim.GetBool("Armed"));
            }
        }
    }
}