using Liminal.SDK.VR;
using Liminal.SDK.VR.Input;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerController : MonoBehaviour
{
    public Material colourSelection;

    public GameObject mosaicCanvas;
    public GameObject nextMosaicCanvas;
    public GameObject glassFinish;

    public List<GameObject> completeCanvases;

    public Slider completeMosaicSlider;
    bool completeMosaic = false;

    public bool fastPlacePiece = false;

    void Update()
    { 
        var primaryInput = VRDevice.Device.PrimaryInputDevice;

        if (primaryInput.GetButtonDown(VRButton.One))
        {
            fastPlacePiece = true;
            print("You are now fast placing tiles");
        }
        if (primaryInput.GetButtonUp(VRButton.One))
        {
            fastPlacePiece = false;
        }

        if (primaryInput.GetButtonDown(VRButton.Two))
        {
            Debug.Log("StartCompletingMosaic");
            completeMosaic = true;
        }
        if (primaryInput.GetButtonUp(VRButton.Two))
        {
            completeMosaicSlider.value = completeMosaicSlider.minValue;
            completeMosaic = false;
        }

        if (completeMosaic == true)
        {
            completeMosaicSlider.value += 0.5f;

            if (completeMosaicSlider.value >= completeMosaicSlider.maxValue)
            {
                CompleteMosaic();
            }
        }

        //Testing Only
        if (Input.GetKeyDown(KeyCode.Space))
        {
            CompleteMosaic();
        }
    }

    void CompleteMosaic()
    {
        completeMosaicSlider.value = completeMosaicSlider.minValue;
        completeMosaic = false;
        GameObject glassFinishClone = Instantiate(glassFinish, mosaicCanvas.transform.position, mosaicCanvas.transform.rotation);
        glassFinishClone.transform.parent = mosaicCanvas.transform;
        GameObject mosaicClone = Instantiate(nextMosaicCanvas, mosaicCanvas.transform.position, mosaicCanvas.transform.rotation);
        //Destroy(mosaicCanvas);

        GameObject i = completeCanvases[Random.Range(0, (completeCanvases.Count))];
        mosaicCanvas.transform.parent = i.transform;
        mosaicCanvas.transform.position = i.transform.position;
        mosaicCanvas.transform.rotation = i.transform.rotation;
        completeCanvases.Remove(i);

        mosaicCanvas = mosaicClone;
    }
}
