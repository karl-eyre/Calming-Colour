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

    public Slider completeMosaicSlider;
    bool completeMosaic = false;

    void Update()
    { 
        var primaryInput = VRDevice.Device.PrimaryInputDevice;

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
                completeMosaicSlider.value = completeMosaicSlider.minValue;
                completeMosaic = false;
                GameObject mosaicClone = Instantiate(nextMosaicCanvas, mosaicCanvas.transform.position , mosaicCanvas.transform.rotation);
                Destroy(mosaicCanvas);
                mosaicCanvas = mosaicClone;
            }
        }
    }
}
