using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.InteropServices;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    public Text healthText;
    public static int currentHealth = 5;
    public float defaultInvincibilityDuration = 2f;
    public float poisonInvincibilityDuration = 0.5f;
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
            TakeDamage(defaultInvincibilityDuration);
        }
        if (other.gameObject.tag == "Poison")
        {
            TakeDamage(poisonInvincibilityDuration);
        }
    }

    public void TakeDamage(float invincibilityDuration)
    {
        if (!isInvincible)
        {
            currentHealth--;
            UpdateHealth();

            if (currentHealth <= 0)
            {
                SceneManager.LoadScene("YOU LOSE");
            }

            isInvincible = true;
            this.invincibilityTimer = invincibilityDuration;
        }
    }



    void UpdateHealth()
    {
        healthText.text = "Health: " + currentHealth;
    }

    public void AddHealth()
    {
        currentHealth++;
        UpdateHealth();
    }


}
