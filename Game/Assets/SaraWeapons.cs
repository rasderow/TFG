using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon {
    private int id;
    private string name;    
    private KeyCode keyCode;
    private int damage;
    private float range;
    private double shots;

    public Weapon(int id, string name, KeyCode keyCode, int damage, float range, double shots) {
        this.id = id;
        this.name = name;        
        this.keyCode = keyCode;
        this.damage = damage;
        this.range = range;
        this.shots = shots;
    }

    public int GetId() {
        return id;
    }

    public string GetName() {
        return name;
    }

    public KeyCode GetKeyCode() {
        return keyCode;
    }

    public int GetDamage() {
        return damage;
    }

    public float GetRange() {
        return range;
    }

    public double GetShots() {
        return shots;
    }

    public void Shoot() {
        if (shots > 0) {
            shots = shots - 1;
        }
    }

    public void Load(double bullets) {
        shots = shots + bullets;
    }
}

public class SaraWeapons : MonoBehaviour
{
    public Weapon actualWeapon;

    private List<Weapon> weaponInventari = new List<Weapon>();
    private Animator animator;

    // Start is called before the first frame update
    void Start() {        
        // Add the default weapons to inventari
        addWeapon(new Weapon(1, "knife", KeyCode.Alpha1, 20, 0.7f, double.PositiveInfinity));
        //addWeapon(new Weapon(2, "gun", KeyCode.Alpha2, 50, 10.0f, 15));
        actualWeapon = weaponInventari.Find(x => x.GetId() == 1);        
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update() {
        // Check if player change the weapon
        foreach (Weapon w in weaponInventari) {
            if (Input.GetKeyDown(w.GetKeyCode())) {
                actualWeapon = w;
                animator.SetInteger("Weapon", w.GetId());
                animator.SetTrigger("ChangeWeapon");                
            }
        }

        // Detect if Sara take a new weapon
        //Collider2D[] items = Physics2D.OverlapCircleAll(attackPoint.position, weapon.GetRange(), enemyLayer);
    }

    public void addWeapon(Weapon weapon) { 
        if (!weaponInventari.Exists(x => x.GetId() == weapon.GetId())) {
            weaponInventari.Add(weapon);
            Debug.Log("s'afegeix al inventari: " + weapon.GetName() + " : " + weapon.GetShots());
        }
        else {
            Weapon w = weaponInventari.Find(x => x.GetId() == weapon.GetId());
            Debug.Log("bales inici: " + w.GetShots());
            w.Load(weapon.GetShots());
            Debug.Log("bales final: " + w.GetShots());
        }
    }
}
