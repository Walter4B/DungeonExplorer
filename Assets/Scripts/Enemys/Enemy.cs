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

    [SerializeField]
    private float _rangeReloadDuration = 2;
    [SerializeField]
    private float _meleReloadDuration = 2;

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

    [SerializeField]
    private GameObject _meleAttackIcon;
    [SerializeField]
    private GameObject _rangedAttackIcon;

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

        if (isRanged && Vector2.Distance(transform.position, target.position) < SearchDistance && !isCasting)
        {
            StartCoroutine(ShootingTimer());
            isCasting = true;
            Invoke("SetBoolBackCast", _rangeReloadDuration);
        }

        if (isMele && Vector2.Distance(transform.position, target.position) < SearchDistance && !isAttacking)
        {
            StartCoroutine(SwingingTimer());
            isAttacking = true;
            Invoke("SetBoolBackAttack", _meleReloadDuration);
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
                player.GetComponent<PlayerStats>().TakeDamage(5);
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

    IEnumerator ShootingTimer()
    {
        GameObject RangedIconClone = Instantiate(_rangedAttackIcon, transform.position, Quaternion.identity, transform.parent);
        RangedIconClone.transform.Translate(new Vector3(0, 1, 0));
        yield return new WaitForSeconds(0.5f);
        Shoot();
    }
    IEnumerator SwingingTimer()
    {
        GameObject MeleIconClone = Instantiate(_meleAttackIcon, transform.position, Quaternion.identity, transform.parent);
        MeleIconClone.transform.Translate(new Vector3(0, 1, 0));
        yield return new WaitForSeconds(0.5f);
        Swing();
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
        isCasting = false;
    }

    public void TakeDamage(int damage)
    {
        Health -= damage;
    }
}