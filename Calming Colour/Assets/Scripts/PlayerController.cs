using Liminal.SDK.VR;
using Liminal.SDK.VR.Input;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerController : MonoBehaviour
{
    public Material colourSelection;

    //tooltip Values
    public GameObject toolTip_SelectColour;
    public GameObject toolTip_PlaceColour;
    public GameObject toolTip_Reset;
    public GameObject toolTip_Complete;
    public GameObject toolTip_Swap;
    public GameObject toolTip_Storage;

    public GameObject mosaicFader;
    public GameObject completeMosaicFader;

    Animator mosaicFadeAnimator;
    bool transitioningMosaic = false;

    public List<GameObject> futureMosaics;

    public int whichMosaic = 0;

    public GameObject mosaicCanvas;
    public GameObject glassFinish;

    public List<GameObject> completeCanvases;

    public Slider completeMosaicSlider;
    public bool completeMosaic = false;

    public bool fastPlacePiece = false;

    public float completeSpeed = 1.5f;

    private void Start()
    {
        mosaicFadeAnimator = mosaicFader.GetComponent<Animator>();
    }

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
        //increase slider when held
        if (completeMosaic == true)
        {
            completeMosaicSlider.value += completeSpeed;

            if (completeMosaicSlider.value >= completeMosaicSlider.maxValue & futureMosaics.Count != 1)
            {
                CompleteMosaic();
            }
        }
    }

    //complete mosaic
    void CompleteMosaic()
    {
        GameObject i = completeCanvases[0];

        if (i != null)
        {
            completeMosaicSlider.value = completeMosaicSlider.minValue;
            completeMosaic = false;
            GameObject glassFinishClone = Instantiate(glassFinish, mosaicCanvas.transform.position, mosaicCanvas.transform.rotation);
            glassFinishClone.transform.parent = mosaicCanvas.transform;

            int x = whichMosaic;

            futureMosaics.Remove(futureMosaics[x]);

            if (futureMosaics.Count == x)
            {
                ChangeMosaicCount(0);
            }

            StartCoroutine(MosaicCompleteTransition(i));

            //GameObject mosaicClone = Instantiate(futureMosaics[whichMosaic], mosaicCanvas.transform.position, mosaicCanvas.transform.rotation);

            TooltipUpdater(toolTip_Complete);      
        }
    }

    IEnumerator MosaicCompleteTransition(GameObject i)
    {
        mosaicFadeAnimator.SetTrigger("FadeOut");
        Instantiate(completeMosaicFader, i.transform);
        yield return new WaitForSeconds(mosaicFadeAnimator.runtimeAnimatorController.animationClips.Length / 2);
        GameObject mosaicClone = Instantiate(futureMosaics[whichMosaic], mosaicCanvas.transform.position, mosaicCanvas.transform.rotation);
        mosaicCanvas.transform.parent = i.transform;
        mosaicCanvas.transform.position = i.transform.position;
        mosaicCanvas.transform.rotation = i.transform.rotation;
        completeCanvases.Remove(i);

        mosaicCanvas = mosaicClone;
    }

    //swap mosaic
    public void SwapMosaic(int i)
    {
        if (transitioningMosaic == false)
        {
            StartCoroutine(MosaicSwapTransition());
            ChangeMosaicCount(i);
        }
        //futureMosaics[whichMosaic] = mosaicCanvas;
    }

    IEnumerator MosaicSwapTransition()
    {
        transitioningMosaic = true;
        
        mosaicFadeAnimator.SetTrigger("FadeOut");
        yield return new WaitForSeconds(mosaicFadeAnimator.runtimeAnimatorController.animationClips.Length / 2);
        GameObject mosaicClone = Instantiate(futureMosaics[whichMosaic], mosaicCanvas.transform.position, mosaicCanvas.transform.rotation);
        Destroy(mosaicCanvas);
        mosaicCanvas = mosaicClone;

        print("Ani Time " + mosaicFadeAnimator.runtimeAnimatorController.animationClips.Length / 2);

        transitioningMosaic = false;
    }

    //Reload canvas
    public void resetCanvas()
    {
        if (transitioningMosaic == false)
        {
            StartCoroutine(MosaicResetTransition());
        }
        
    }

    IEnumerator MosaicResetTransition()
    {
        transitioningMosaic = true;

        mosaicFadeAnimator.SetTrigger("FadeOut");
        yield return new WaitForSeconds(mosaicFadeAnimator.runtimeAnimatorController.animationClips.Length / 2);
        GameObject mosaicClone = Instantiate(futureMosaics[whichMosaic], mosaicCanvas.transform.position, mosaicCanvas.transform.rotation);
        Destroy(mosaicCanvas);
        mosaicCanvas = mosaicClone;

        transitioningMosaic = false;
    }

    //update count to match list of available mosaics
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

    //Remove called tooltip
    public void TooltipUpdater(GameObject g)
    {
        if (g.activeInHierarchy == true)
        {
            g.GetComponent<ClosePanel>().DisableTooltip();
        }
    }

}
