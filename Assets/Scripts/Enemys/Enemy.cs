using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    public GameObject EnemyProjectilePrefab;
    public GameObject EnemySwingPrefab;

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
    private bool isFinalBoss = false;

    [SerializeField]
    private GameObject _meleAttackIcon;
    [SerializeField]
    private GameObject _rangedAttackIcon;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        target = player.transform;
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
            if(isFinalBoss)
            {
                DestroyAll();
                Cursor.visible = true;
                SceneManager.LoadScene(7);
            }
            Destroy(gameObject);
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
        float rotation_z = Mathf.Atan2(EnemyFiringPoint.forward.y, EnemyFiringPoint.forward.x) * Mathf.Rad2Deg;


        GameObject swingClone = Instantiate(EnemySwingPrefab, EnemyFiringPoint.position + EnemyFiringPoint.forward, Quaternion.Euler(0, 0, rotation_z - 90));
        swingClone.transform.SetParent(gameObject.transform);
        Rigidbody2D projectileRigidbody = swingClone.GetComponent<Rigidbody2D>();
    }

    IEnumerator ShootingTimer()
    {
        GameObject RangedIconClone = Instantiate(_rangedAttackIcon, transform.position, Quaternion.identity, transform.parent);
        RangedIconClone.transform.Translate(new Vector3(0, 1, 0));
        RangedIconClone.transform.SetParent(gameObject.transform);
        yield return new WaitForSeconds(0.5f);
        Shoot();
    }
    IEnumerator SwingingTimer()
    {
        GameObject MeleIconClone = Instantiate(_meleAttackIcon, transform.position, Quaternion.identity, transform.parent);
        MeleIconClone.transform.Translate(new Vector3(0, 1, 0));
        MeleIconClone.transform.SetParent(gameObject.transform);
        yield return new WaitForSeconds(0.5f);
        Swing();
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
    
    private void DestroyAll()
    {
        foreach (GameObject o in Object.FindObjectsOfType<GameObject>())
        {
            Destroy(o);
        }
    }
}