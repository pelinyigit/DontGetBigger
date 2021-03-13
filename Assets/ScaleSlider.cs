using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScaleSlider : MonoBehaviour
{
    public Gradient gradient;

    [SerializeField] Image fillImage;

    Slider scaleSlider;    
    
    private void Start()
    {
        scaleSlider = GetComponent<Slider>();
        fillImage.color = gradient.Evaluate(0f);       
    }

    //private void OnEnable()
    //{
    //    EventManager.OnFireCollision.AddListener(ColorAdjuster);
    //    EventManager.OnSnowmanCollision.AddListener(ColorAdjuster);
    //}

    //private void OnDisable()
    //{
    //    EventManager.OnFireCollision.RemoveListener(ColorAdjuster);
    //    EventManager.OnSnowmanCollision.RemoveListener(ColorAdjuster);
    //}

    private void Update()
    {
        ColorAdjuster();
    }

    private void ColorAdjuster()
    {
        fillImage.color = gradient.Evaluate(scaleSlider.normalizedValue);
    }
}
