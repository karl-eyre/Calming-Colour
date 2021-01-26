using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerColour : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        this.gameObject.transform.Rotate(0, 50 * Time.deltaTime, 0);
    }
}
