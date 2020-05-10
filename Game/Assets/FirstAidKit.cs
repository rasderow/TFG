using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstAidKit : MonoBehaviour
{
    public int health;

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.name == "Sara") {
            other.GetComponent<SaraHealth>().gainHealth(health);
            GameObject.Destroy(gameObject);
        }
    }
}
