using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{
    LifeController life;
    public Slider slider;
    public void SetMaxHealth(int hp)
    {
        slider.maxValue = hp;
        slider.value = hp;

    }

    public void SetHealth(int hp)
    {
        slider.value = hp;
    }
    // Start is called before the first frame update
    void Start()
    {
        life = GetComponent<LifeController>();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
