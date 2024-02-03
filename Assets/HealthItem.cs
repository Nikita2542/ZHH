using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthItem : MonoBehaviour
{
    public int health;
    public int maxHealth;

    void Start()
    {
        health = maxHealth;
    }

   public void TakeDamage(int amount)
    {
        health -= amount;
        if(health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        transform.SetParent(null);
       
        gameObject.AddComponent<Rigidbody>();
    }
}
