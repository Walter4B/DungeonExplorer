using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossScript : MonoBehaviour
{
    public PlayerStats damage;
    public int Health = 50;
    public GameObject Gate;

    //public ParticleSystem ExplosionPrefab;
    private void Update()
    {
        if (Health <= 0)
        {
            Destroy(Gate);
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Projectile")
        {

            //if (ExplosionPrefab)
            //Instantiate(ExplosionPrefab, transform.position, transform.rotation);
            Health = Health - 10;
            Destroy(other.gameObject);
        }

        if (other.tag == "Weapon")
        {
            Health -= 10;
        }

        if (other.tag == "Player")
        {
            other.gameObject.GetComponent<PlayerStats>().TakeDamage(10);
            //if (ExplosionPrefab)
            //Instantiate(ExplosionPrefab, transform.position, transform.rotation);
        }
    }
}