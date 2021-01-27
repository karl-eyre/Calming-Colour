using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerColour : MonoBehaviour
{
    Rigidbody tileRig;

    ParticleSystem ringParticleEffect;
    public GameObject ringParticleObject;

    public GameObject controller;

    public bool fastPlaceTiles = false;

    //public float rotationSpeedCap = 5;
    //public float accelerationSpeed = 5;
    //public float fastPlaceRotationSpeedCap = 30;
    //public float fastPlaceAccelerationSpeed = 30;

    public float currentMagnitude;

    public float currentSpeed = 100;
    public float regularSpeed = 100;
    public float quickPlaceSpeed = 500;
    public float acceleration = 10;

    void Start()
    {
        tileRig = this.GetComponent<Rigidbody>();
        ringParticleEffect = ringParticleObject.GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {   
        //this.gameObject.transform.Rotate(0, 50 * Time.deltaTime, 0);
    }

    private void FixedUpdate()
    {
        fastPlaceTiles = controller.GetComponent<PlayerController>().fastPlacePiece;

        var main = ringParticleEffect.main;
        var emision = ringParticleEffect.emission;

        if (/*tileRig.angularVelocity.magnitude <= rotationSpeedCap &*/ fastPlaceTiles == false)
        {
            //tileRig.AddTorque(transform.rotation(new Vector3(0,0,0)) * accelerationSpeed);
            main.startColor = new Color(0f, 0.85f, 1f, 1f);
            emision.rateOverTime = 1;
            main.simulationSpeed = 1;

            if (currentSpeed > regularSpeed)
            {
                currentSpeed -= acceleration;
            }
        } 
        else if(/*tileRig.angularVelocity.magnitude <= fastPlaceRotationSpeedCap &*/ fastPlaceTiles == true)
        {
            //tileRig.AddTorque(transform.forward * fastPlaceAccelerationSpeed);
            main.startColor = new Color(1f, 0.1259845f, 0f, 1f);
            emision.rateOverTime = 1;
            main.simulationSpeed = 4;

            if (currentSpeed < quickPlaceSpeed)
            {
                currentSpeed += acceleration;
            }
        }

        this.gameObject.transform.Rotate(0, currentSpeed * Time.deltaTime, 0);

        currentMagnitude = tileRig.angularVelocity.magnitude;

    }
}
