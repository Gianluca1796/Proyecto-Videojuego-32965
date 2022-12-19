using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class SetFocus : MonoBehaviour
{

    public PostProcessVolume volume;
    Vignette _vignette;
    private void Start() 
    {
        volume.profile.TryGetSettings(out _vignette);
    }
    private void OnTriggerStay(Collider other) 
    {
        if (other.gameObject.CompareTag("Player"))
        {
            SetFocusTrigger();
        }
    }
    void SetFocusTrigger()

    {
        _vignette.intensity.value+=0.008f ; 
    }
}
