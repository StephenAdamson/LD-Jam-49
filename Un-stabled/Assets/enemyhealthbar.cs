using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class enemyhealthbar : MonoBehaviour
{

    public Slider slider;
    float health;
    float maxHealth;

    public void setHealth(float health){
        this.health = health;
        slider.value = health;
    }
    public void setMaxHealth(float health){
        slider = GetComponent<Slider>();
        maxHealth = health;
        slider.maxValue = health;
    }
}
