using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JunoRotate_junsal : MonoBehaviour
{
    float junoRotate = 0f;
    float junoSliderValue = 0f;
    public Slider junoSlider;

    public void Start()
    {
        junoSlider.value = junoSliderValue;
    }

    void Update()
    {
        junoRotate += 0.04f;
        junoSliderValue = junoSlider.value * 100f;
        transform.localEulerAngles = new Vector3(-23.6f, junoRotate * junoSliderValue, 9.409f);
    }
}
