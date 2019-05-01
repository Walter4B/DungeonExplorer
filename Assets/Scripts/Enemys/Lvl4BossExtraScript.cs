using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lvl4BossExtraScript : MonoBehaviour
{
    [SerializeField]
    private GameObject _projectile;
    [SerializeField]
    private GameObject _projectileS16;
    [SerializeField]
    private Transform FiringPoint;
    [SerializeField]
    private int Power = 10;
    [SerializeField]
    private int SearchDistance = 20;

    [SerializeField]
    private GameObject _rangedAttackIconRay;
    [SerializeField]
    private GameObject _rangedAttackIconS16;

    private int _numOfFires = 0;

    private Transform target;



    private bool reloadingRay = false;
    private bool reloading16S = false;
    private bool ready = true;

    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    private void FixedUpdate()
    {
        if (Vector2.Distance(transform.position, target.position) < SearchDistance && !reloadingRay)
        {
            reloadingRay = true;
            StartCoroutine(NextBulletTimer());
            Invoke("SetBoolBackRay", 10);
        }
        
        if(Vector2.Distance(transform.position, target.position) < SearchDistance && !reloading16S)
        {
            reloading16S = true;
            StartCoroutine(NextBurstTimer());
            Invoke("SetBoolBackS16", 15);
        }
        
    }
    private void RapidFire()
    {
        GameObject projectileClone = Instantiate(_projectile, FiringPoint.position, Quaternion.identity);
        Rigidbody2D projectileRigidbody = projectileClone.GetComponent<Rigidbody2D>();
        projectileRigidbody.AddForce(FiringPoint.forward * Power, ForceMode2D.Force);
    }
   

    private void S16Burst()
    {
        GameObject projectileClone = Instantiate(_projectileS16, FiringPoint.position, Quaternion.identity);
        Rigidbody2D projectileRigidbody = projectileClone.GetComponent<Rigidbody2D>();
        projectileRigidbody.AddForce(FiringPoint.forward * Power, ForceMode2D.Force);
    }

    private void SetBoolBackRay()
    {
        reloadingRay = false;
    }
    private void SetBoolBackS16()
    {
        reloading16S = false;
    }

    IEnumerator NextBulletTimer()
    {
        GameObject RayClone = Instantiate(_rangedAttackIconRay, transform.position, Quaternion.identity, transform.parent);
        _rangedAttackIconRay.transform.Translate(new Vector3(0, 1, 0));
        yield return new WaitForSeconds(0.4f);
        while (_numOfFires < 10)
        {
            RapidFire();
            yield return new WaitForSeconds(0.1f);
            _numOfFires++;
            Destroy(RayClone);
        }
        
        _numOfFires = 0;
    }

    IEnumerator NextBurstTimer()
    {
        GameObject S16Clone = Instantiate(_rangedAttackIconS16, transform.position, Quaternion.identity, transform.parent);
        S16Clone.transform.Translate(new Vector3(0, 1, 0));
        yield return new WaitForSeconds(0.5f);
        S16Burst();
        Destroy(S16Clone);
    }
}
