using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public int health = 100;
    Slider slider; 
    // Start is called before the first frame update
    void Start()
    {
        slider = GameObject.Find("HealthBar").GetComponent<Slider>();
        slider.maxValue = health;
    }

    // Update is called once per frame
    void Update()
    {
        slider.value = health;
    }
}
