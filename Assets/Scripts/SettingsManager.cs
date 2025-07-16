using System;
using UnityEngine;
using UnityEngine.UI;

public class SettingsManager : MonoBehaviour
{
    [Header("Sound")]
    [SerializeField] Transform soundScale;
    [SerializeField] Slider soundSlider;
    //[SerializeField] private int maxSize;
    //[SerializeField] private int minSize;

    private void Start()
    {
        
        //fetch the settings from static
        
        SliderOnChange();
    }

    public void SliderOnChange()
    {
        //Change scale of the circle
        soundScale.localScale = Vector3.one * soundSlider.value;
    }
}
