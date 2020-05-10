using UnityEngine;

[System.Serializable]
public class Weapon {    

    private int id;
    private string name;
    private KeyCode keyCode;
    private int damage;
    private float range;
    private double shots;
    private AudioClip clip;

    public Weapon(int id, string name, KeyCode keyCode, int damage, float range, double shots, AudioClip clip) {
        this.id = id;
        this.name = name;
        this.keyCode = keyCode;
        this.damage = damage;
        this.range = range;
        this.shots = shots;
        this.clip = clip;
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

    public AudioClip GetClip() {
        return clip;
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
