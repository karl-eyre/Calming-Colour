using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class AudioManager : MonoBehaviour
{
    [SerializeField]
    private AudioSource uiPress;
    [SerializeField]
    public AudioClip menuClose;
    public AudioClip paint;
    public AudioClip paintSelect;
    
    private void Start()
    {
        ColourSelect.onColorSelect += ColourSelectOnonColorSelect;
        ColourAdd.onColorAdd += onColourAddOncolorAdd;
        ClosePanel.ONPanelClose += ClosePanelOnONPanelClose;
    }

    private void ClosePanelOnONPanelClose(object sender, EventArgs e)
    {
        uiPress.pitch = Random.Range(0.95f, 1);
        uiPress.PlayOneShot(menuClose);
    }

    private void onColourAddOncolorAdd(object sender, EventArgs e)
    {
        uiPress.pitch = Random.Range(0.95f, 1);
        uiPress.PlayOneShot(paint);
    }

    private void ColourSelectOnonColorSelect(object sender, EventArgs e)
    {
        uiPress.pitch = Random.Range(0.95f, 1);
        uiPress.PlayOneShot(paintSelect);
    }

    private void OnDestroy()
    {
        ColourSelect.onColorSelect -= ColourSelectOnonColorSelect;
        ColourAdd.onColorAdd -= onColourAddOncolorAdd;
        ClosePanel.ONPanelClose -= ClosePanelOnONPanelClose;
    }
}
