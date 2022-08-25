using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public Rigidbody rb;

    public float shootingForce, destroyAfterSeconds;

    public GameObject weight;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddRelativeForce(0, shootingForce, 0);
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        rb.isKinematic = true;
        Destroy(weight);
        StartCoroutine(ArrowDistroyTimer(destroyAfterSeconds));
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