using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaraHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public HealthBar healthBar;

    // Start is called before the first frame update
    void Start() {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetKeyDown(KeyCode.M)) {
            TakeDamage(20);
        }
    }

    // Damage function
    void TakeDamage (int damage) {
        currentHealth = currentHealth - damage;
        healthBar.SetHealth(currentHealth);
    }
}
