using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider HealthBar_;

    public void SetMaxHealth(int health)
    {
        HealthBar_.maxValue = health;
        HealthBar_.value = health;

    }
    public void SetHealth(int health)
    {
        HealthBar_.value = health;
    }
}
