using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaraWeapons : MonoBehaviour
{
    public Weapon actualWeapon;
    public AudioClip knifeClip;

    private List<Weapon> weaponInventari = new List<Weapon>();    
    private Animator animator;
    private ShotsCounter shotsCounter;
    

    // Start is called before the first frame update
    void Start() {        
        // Add the default weapons to inventari
        addWeapon(new Weapon(1, "knife", KeyCode.Alpha1, 15, 0.7f, double.PositiveInfinity, knifeClip));        
        actualWeapon = weaponInventari.Find(x => x.GetId() == 1);        
        shotsCounter = GameObject.FindGameObjectWithTag("ShotsCounter").GetComponent<ShotsCounter>();
        shotsCounter.SetShots(actualWeapon.GetShots());
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
                shotsCounter.SetShots(actualWeapon.GetShots());
            }
        }        
    }

    public void addWeapon(Weapon weapon) { 
        if (!weaponInventari.Exists(x => x.GetId() == weapon.GetId())) {
            weaponInventari.Add(weapon);            
        }
        else {
            Weapon w = weaponInventari.Find(x => x.GetId() == weapon.GetId());            
            w.Load(weapon.GetShots());            
        }
    }
}
