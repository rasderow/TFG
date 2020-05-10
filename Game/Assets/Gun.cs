using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public AudioClip audioClip;    

    private void OnTriggerEnter2D(Collider2D other) {        
        if (other.name == "Sara") {
            other.GetComponent<SaraWeapons>().addWeapon(new Weapon(2, "gun", KeyCode.Alpha2, 30, 10.0f, 15, audioClip));
            GameObject.Destroy(gameObject);
        }
    }
}
