using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public Rigidbody rb;

    public float shootingForce, destroyAfterSeconds;

    public GameObject weight, boomPrefab, hitPrefab;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddRelativeForce(0, shootingForce, 0);
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        rb.isKinematic = true;
        gameObject.transform.SetParent(collision.transform);
        Destroy(weight);
        Instantiate(hitPrefab, collision.GetContact(0).point, transform.rotation * Quaternion.Euler(90,0,0));
        StartCoroutine(ArrowDistroyTimer(destroyAfterSeconds));

        if (collision.gameObject.CompareTag("Enemy"))
        {
            Instantiate(boomPrefab, transform.position, transform.rotation);
            Destroy(collision.gameObject);
        }
    }
    
    IEnumerator ArrowDistroyTimer(float waitTime)
    {
        //Do something before waiting.

        //yield on a new YieldInstruction that waits for X seconds.
        yield return new WaitForSeconds(waitTime);

        //Do something after waiting.
        Destroy(gameObject);
    }
}
