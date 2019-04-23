using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    public int Health = 50;

    public float SearchDistance;

    private bool isColliding = false;

    private GameObject player;
    private Transform target;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    //public ParticleSystem ExplosionPrefab;
    private void FixedUpdate()
    {
        if (Health <= 0)
        {
            Destroy(gameObject);
        }

        if (isColliding)
        {
            Invoke("SetBoolBack", 1);
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
            if (isColliding)
            {
                return;
            }
            else
            {
                isColliding = true;
                player.GetComponent<PlayerStats>().TakeDamage(10);
                player.GetComponent<PlayerStats>().CanTakeDamage = false;
            }
            //if (ExplosionPrefab)
                //Instantiate(ExplosionPrefab, transform.position, transform.rotation);
        }
    }
    private void SetBoolBack()
    {
        isColliding = false;
    }
}