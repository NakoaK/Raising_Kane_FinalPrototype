using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    private float health;
    private float maxHealth;
    private float healthPercentage;

    // class constructor
    public HealthBar(float maxHealth)
    {
        this.maxHealth = maxHealth;
        health = maxHealth;
    }

    // getter method to return health
    public float GetHealth()
    {
        return health;
    }

    // return current health percentage
    public float GetHealthPercent()
    {
        healthPercentage = health / maxHealth;

        // check that healthPercentage is valid float
        if (float.IsNaN(healthPercentage))
        {
            healthPercentage = 0;
        }

        if (healthPercentage > 1f)
        {
            healthPercentage = 1f;
        }

        return healthPercentage;
    }

    // DamageHealth
    public void DamageHealth(float damage)
    {
        health -= damage;

        if (health <= 0)
        {
            health = 0;
        }

    }

    // BoostHealth
    public void BoostHealth(float boost)
    {
        health += boost;

        if (health > maxHealth)
        {
            health = maxHealth;
        }

    }
}
