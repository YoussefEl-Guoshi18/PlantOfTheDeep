using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DamageBeing : MonoBehaviour
{
    public int currentHealth;
    public Text beingHealth;
    HealthManager healthManager;

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            if(this.CompareTag("Kill"))
            {
                healthManager.AddHealth();
               TakeDamage();
            }
            
        }
    }

    void TakeDamage()
    {
        if (currentHealth <= 1)
        {
            SceneManager.LoadScene("YOU WIN");
        }
        currentHealth--;
        UpdateHealth();
    }

    void UpdateHealth()
    {
        beingHealth.text = "Being Health: " + currentHealth;
    }
    // Start is called before the first frame update
    void Start()
    {
        healthManager = FindObjectOfType<HealthManager>();
        UpdateHealth();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
