using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float health = 100;
    [SerializeField] GameObject enemyLaser;
    [SerializeField] GameObject deathVFX;
    [SerializeField] float durationOfExplosion;
    [SerializeField] AudioClip deathClip;
    [SerializeField] AudioClip laserClip;

    [SerializeField] float shotcounter;
    [SerializeField] int DeathScore;
    [SerializeField] float minTimeBetweenShots = 0.2f;
    [SerializeField] float maxTimeBetweenShots = 3f;
    [SerializeField] float projectileSpeed = 10f;
    [SerializeField] [Range(0, 1)] float deathSound = 0.2f;
    [SerializeField] [Range(0, 1)] float laserSound = 0.055f;

    // Start is called before the first frame update
    void Start()
    {
        shotCounter();
    }

    // Update is called once per frame
    void Update()
    {
        CountDownAndShoot();
    }

    private void CountDownAndShoot()
    {
        shotcounter -= Time.deltaTime;
        if (shotcounter <= 0f)
        {
            Fire();
        }
    }
    public void shotCounter()
    {
        shotcounter = UnityEngine.Random.Range(minTimeBetweenShots, maxTimeBetweenShots);
    }

    private void Fire()
    {
        shotCounter();
        GameObject laser = Instantiate(enemyLaser, transform.position, Quaternion.identity) as GameObject;
        AudioSource.PlayClipAtPoint(laserClip, Camera.main.transform.position, laserSound);
        laser.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -projectileSpeed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        DamageDealer damageDealer = collision.gameObject.GetComponent<DamageDealer>();
        if (!damageDealer) { return; }
        ProcessHit(damageDealer);

    }

    private void ProcessHit(DamageDealer damageDealer)
    {
        health -= damageDealer.GetDamage();
        if (health <= 0)
        {
            damageDealer.Hit();
            Die();
        }
    }

    private void Die()
    {
        Destroy(gameObject);
        GameObject explosion = Instantiate(deathVFX, transform.position, transform.rotation);
        Destroy(explosion, durationOfExplosion);
        AudioSource.PlayClipAtPoint(deathClip, Camera.main.transform.position, deathSound);
        FindObjectOfType<GameStatus>().addScore(DeathScore);
    }
}
