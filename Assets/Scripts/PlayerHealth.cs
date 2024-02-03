
using UnityEngine;
using UnityEngine.UI;



public class PlayerHealth : MonoBehaviour
{
    public int maxHealth;
    [HideInInspector]
    public int health;
    [Space(10)]
    public Slider sliderHealth;
    

    public void Start()
    {
        health = maxHealth;
        sliderHealth.maxValue = health;
        sliderHealth.value = health;
    }

    public void TakeDamage(int amount)
    {
        health -= amount;
        sliderHealth.value = health;
        if (health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}
