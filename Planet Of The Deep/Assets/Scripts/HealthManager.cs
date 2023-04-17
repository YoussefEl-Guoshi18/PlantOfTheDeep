using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    public Text healthText;
    public static int currentHealth = 5;
    public float invincibilityDuration = 2f; 
    private bool isInvincible = false; 
    private float invincibilityTimer = 0f;


    void Start()
    {
        UpdateHealth();

    }

    void Update()
    {
        
        UpdateHealth();

        
        if (isInvincible)
        {
            invincibilityTimer -= Time.deltaTime;
            if (invincibilityTimer <= 0f)
            {
                isInvincible = false;
            }
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            TakeDamage();
        }
    }

    public void TakeDamage()
    {
        // If not currently invincible, take damage and trigger invincibility frames
        if (!isInvincible)
        {
            currentHealth--;
            UpdateHealth();

            isInvincible = true;
            invincibilityTimer = invincibilityDuration;
        }
    }

    void UpdateHealth()
    {
        healthText.text = "Health: " + currentHealth;
    }
}
