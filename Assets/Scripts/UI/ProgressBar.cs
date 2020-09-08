using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ProgressBar : MonoBehaviour
{

    public Slider slider;

    public void SetLevelLenght(float levelLenght)
    {
        slider.maxValue = levelLenght;
        slider.minValue = 0;
        slider.value = 0;
    }

    public void SetLevelProgress(float progress)
    {
        slider.value = progress;
    }
}
