using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstAidKit : MonoBehaviour
{
    public int health;

    private void OnTriggerEnter2D(Collider2D other) {
        Debug.Log("he detectat a " + other.name);
        //Debug.Log("vida abans " + other.GetComponent<SaraHealth>().getCurrentHealth());
        other.GetComponent<SaraHealth>().gainHealth(health);
        Debug.Log("vida després " + other.GetComponent<SaraHealth>().getCurrentHealth());
        GameObject.Destroy(gameObject);
    }
}
