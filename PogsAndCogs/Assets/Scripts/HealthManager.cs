using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    public int totalHealth;
    public int currentHealth;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
    }

    public void AddHealth(int health)
    {
        currentHealth += health;
        if (currentHealth > totalHealth)
        {
            currentHealth = totalHealth;
        }
    }
}
