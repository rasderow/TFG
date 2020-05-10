using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rifle : MonoBehaviour
{
    public AudioClip audioClip;

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.name == "Sara") {
            other.GetComponent<SaraWeapons>().addWeapon(new Weapon(3, "rifle", KeyCode.Alpha3, 45, 30.0f, 20, audioClip));
            GameObject.Destroy(gameObject);
        }
    }
}
