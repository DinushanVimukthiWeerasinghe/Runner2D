using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    public float health = 100f;
    public float damage = 20f;
    public Text healthText;
    // Start is called before the first frame update
    void Start()
    {
        health = 100f;
        healthText.text = health.ToString();
    }

    // IsDead is called when the player is dead
    public bool IsDead()
    {
        return health <= 0;
    }
    
    public void TakeDamage()
    {
        health -= damage;
        healthText.text = health.ToString();
    }
    
    public void IncreaseHealth()
    {
        if (health >= 100f)
        {
            return;
        }
        health += 20f;
        healthText.text = health.ToString();
    }
    
    public void resetHealth()
    {
        health = 100f;
        healthText.text = health.ToString();
    }
    
    
}
