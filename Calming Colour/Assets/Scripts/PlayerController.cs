using Liminal.SDK.VR;
using Liminal.SDK.VR.Input;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerController : MonoBehaviour
{
    public Material colourSelection;

    public List<GameObject> futureMosaics;

    int whichMosaic = 0;

    public GameObject mosaicCanvas;
    public GameObject nextMosaicCanvas;
    public GameObject glassFinish;

    public List<GameObject> completeCanvases;

    public Slider completeMosaicSlider;
    public bool completeMosaic = false;

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

            completeMosaicSlider.value = completeMosaicSlider.minValue;
            completeMosaic = false;
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

        //Testing Only
        if (Input.GetKeyDown(KeyCode.Space))
        {
            CompleteMosaic();
            //resetCanvas();
        }
    }

    private void FixedUpdate()
    {
        if (completeMosaic == true)
        {
            completeMosaicSlider.value += 0.7f;

            if (completeMosaicSlider.value >= completeMosaicSlider.maxValue)
            {
                CompleteMosaic();
            }
        }
    }

    void CompleteMosaic()
    {
        GameObject i = completeCanvases[0];

        if (i != null)
        {
            completeMosaicSlider.value = completeMosaicSlider.minValue;
            completeMosaic = false;
            GameObject glassFinishClone = Instantiate(glassFinish, mosaicCanvas.transform.position, mosaicCanvas.transform.rotation);
            glassFinishClone.transform.parent = mosaicCanvas.transform;
            GameObject mosaicClone = Instantiate(futureMosaics[whichMosaic + 1], mosaicCanvas.transform.position, mosaicCanvas.transform.rotation);

            mosaicCanvas.transform.parent = i.transform;
            mosaicCanvas.transform.position = i.transform.position;
            mosaicCanvas.transform.rotation = i.transform.rotation;
            completeCanvases.Remove(i);

            ChangeMosaicCount(1);
            mosaicCanvas = mosaicClone;
        }
    }

    public void resetCanvas()
    {
        GameObject mosaicClone = Instantiate(nextMosaicCanvas, mosaicCanvas.transform.position, mosaicCanvas.transform.rotation);
        Destroy(mosaicCanvas);
        mosaicCanvas = mosaicClone;
    }

    public void SwapMosaic(int i)
    {
        ChangeMosaicCount(i);
        GameObject mosaicClone = Instantiate(futureMosaics[whichMosaic], mosaicCanvas.transform.position, mosaicCanvas.transform.rotation);
        Destroy(mosaicCanvas);
        mosaicCanvas = mosaicClone;
    }

    void ChangeMosaicCount(int i)
    {
        if (whichMosaic + i >= futureMosaics.Count)
        {
            whichMosaic += i - futureMosaics.Count;
        }
        else if(whichMosaic + i < 0)
        {
            whichMosaic += futureMosaics.Count + i;
        }
        else
        {
            whichMosaic += i;
        }
        print(whichMosaic);
    }

}
