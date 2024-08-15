using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HUDManager : MonoBehaviour
{
    TMP_Text text;
    Slider slider;

    public void Start()
    {
        text = GetComponentInChildren<TMP_Text>();
        slider = GetComponentInChildren<Slider>();
    }
    public void DistanceCalculator(float dist)
    {
        if (dist <= 500f)
        {
            text.text = dist.ToString("F2") + "m";
        }
        else
        {
            dist = dist / 1000f;
            text.text = dist.ToString("F2") + "km";
        }
    }

    public void AddFuel(float value)
    {
        slider.value += value;
    }
    public void SetMaxFuel(float max)
    {
        slider.maxValue += max;
        slider.value = max;
    }
    public void SetFuel(float value)
    {
        slider.value = value;
    }

}
