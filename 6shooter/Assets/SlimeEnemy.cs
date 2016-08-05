using UnityEngine;
using System.Collections;

public class SlimeEnemy : MonoBehaviour {
    public float speed;
    public float health;
    public ParticleSystem deathEffect;

    // Use this for initialization
    void Start() {
    }

    // Update is called once per frame
    void Update() {
        transform.Translate(Vector3.back * speed *  Time.deltaTime);
    }

    public void Damage(float damage) {
        health -= damage;
        if(health <= 0) {
            OnDeath();
        }
    }

    void OnDeath() {
        deathEffect = Instantiate(deathEffect, transform.position, Quaternion.Euler(0, 0, 0)) as ParticleSystem;
        deathEffect.Play();
        Destroy(this.gameObject);
    }
}
