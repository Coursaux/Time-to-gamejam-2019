using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class HealthManager : MonoBehaviour
{
    public int totalHealth;
    public int currentHealth;

    public virtual void TakeDamage(int damage)
    {
        currentHealth -= damage;

        die();
    }

    public virtual void AddHealth(int health)
    {
        currentHealth += health;
        if (currentHealth > totalHealth)
        {
            currentHealth = totalHealth;
        }
    }

    protected virtual void die()
    {
        if (currentHealth <= 0)
        {
            gameObject.SetActive(false);
        }
    }
}
