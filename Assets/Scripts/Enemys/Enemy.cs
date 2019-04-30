using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    public GameObject EnemyProjectilePrefab;

    public int Health = 50;

    public float Power = 2;
    public float SearchDistance = 20;

    public Transform EnemyFiringPoint;

    private bool isAttacking = false;
    private bool isCasting = false;
    private bool isColliding = false;

    private GameObject player;
    private Transform target;

    [SerializeField]
    private GameObject Gate;

    [SerializeField]
    private bool isMele = true;
    [SerializeField]
    private bool isRanged = true;
    [SerializeField]
    private bool isBoss = false;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    //public ParticleSystem ExplosionPrefab;
    private void FixedUpdate()
    {
        if (Health <= 0 && isBoss)
        {
            Destroy(Gate);
            Destroy(gameObject);
        }

        if (isRanged && Vector2.Distance(transform.position, target.position) < SearchDistance && !isAttacking)
        {
            Shoot();
            isAttacking = true;
            Invoke("SetBoolBackAttack", 2);
        }

        if (isMele && Vector2.Distance(transform.position, target.position) < SearchDistance && !isCasting)
        {
            Swing();
            isCasting = true;
            Invoke("SetBoolBackCast", 2);
        }

        if (Health <= 0)
        {
            if(isBoss)
            {
                Destroy(Gate);
            }
            Destroy(gameObject);
        }

        if (isColliding)
        {
            Invoke("SetBoolBackCollide", 1);
        }
    }
   
    void OnTriggerEnter2D(Collider2D other)
    {

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

    private void Shoot()
    {
        GameObject projectileColne = Instantiate(EnemyProjectilePrefab, EnemyFiringPoint.position, Quaternion.identity);
        Rigidbody2D projectileRigidBody = projectileColne.GetComponent<Rigidbody2D>();
        projectileRigidBody.AddForce(EnemyFiringPoint.forward * Power, ForceMode2D.Force);
    }

    private void Swing()
    {

    }

    private void SetBoolBackCollide()
    {
        isColliding = false;
    }

    private void SetBoolBackAttack()
    {
        isAttacking = false;
    }
    private void SetBoolBackCast()
    {
        isAttacking = false;
    }

    public void TakeDamage(int damage)
    {
        Health -= damage;
    }
}