using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other) {
        Debug.Log("he detectat a " + other.name);
        Weapon gun = new Weapon(2, "gun", KeyCode.Alpha2, 50, 10.0f, 15);
        other.GetComponent<SaraWeapons>().addWeapon(gun);
        //GameObject.DestroyImmediate(gameObject);
        GameObject.Destroy(gameObject);
    }
}
