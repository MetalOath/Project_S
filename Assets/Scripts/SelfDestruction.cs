using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestruction : MonoBehaviour
{
    public float timer;
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SelfDestruct(timer));
    }
    
    IEnumerator SelfDestruct(float waitTime)
    {
        //Do something before waiting.

        //yield on a new YieldInstruction that waits for X seconds.
        yield return new WaitForSeconds(waitTime);

        //Do something after waiting.
        Destroy(gameObject);
    }
}
