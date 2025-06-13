using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{

    [SerializeField] private Slider slider;
    [SerializeField] private Image fillImage;
    [SerializeField] private Gradient gradient;

    public void SetMaxHealth(int max)
    {
        slider.maxValue = max;
        slider.value = max;

        if (fillImage != null)
            fillImage.color = gradient.Evaluate(1f);
    }

    public void SetHealth(int hp)
    {
        slider.value = hp;

        if (fillImage != null)
            fillImage.color = gradient.Evaluate(slider.normalizedValue);
    }
}
