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
    }

    private void FixedUpdate()
    {
        fastPlaceTiles = controller.GetComponent<PlayerController>().fastPlacePiece;

        var main = ringParticleEffect.main;
        var emision = ringParticleEffect.emission;

        if (fastPlaceTiles == false)
        {
            main.startColor = new Color(0f, 0.85f, 1f, 1f);
            emision.rateOverTime = 1;
            main.simulationSpeed = 1;

            if (currentSpeed > regularSpeed)
            {
                currentSpeed -= acceleration;
            }
        } 
        else if(fastPlaceTiles == true)
        {
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
