using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Riffle : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other) {
        Debug.Log("he detectat a " + other.name);
        Weapon riffle = new Weapon(3, "riffle", KeyCode.Alpha3, 45, 30.0f, 20);
        other.GetComponent<SaraWeapons>().addWeapon(riffle);
        GameObject.Destroy(gameObject);
    }
}
