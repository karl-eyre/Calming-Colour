using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlingHeldColour : MonoBehaviour
{
    Rigidbody tileRig;
    public GameObject tileHolder;

    // Start is called before the first frame update
    void Start()
    {
        tileRig = this.gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        tileRig.AddForce((tileHolder.transform.position - transform.position) * 40);
    }
}
