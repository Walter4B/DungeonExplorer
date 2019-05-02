using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lvl3BossExtraScript : MonoBehaviour
{
    [SerializeField]
    private GameObject _projectileS4;
    [SerializeField]
    private Transform FiringPoint;
    [SerializeField]
    private int Power = 10;
    [SerializeField]
    private int SearchDistance = 20;

    [SerializeField]
    private GameObject _rangedAttackIconS16;

    private Transform target;


    private bool reloading4S = false;

    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    private void FixedUpdate()
    {
        if (Vector2.Distance(transform.position, target.position) < SearchDistance && !reloading4S)
        {
            reloading4S = true;
            StartCoroutine(NextBurstTimer());
            Invoke("SetBoolBackS4", 15);
        }

    }
  

    private void S16Burst()
    {
        GameObject projectileClone = Instantiate(_projectileS4, FiringPoint.position, Quaternion.identity);
        Rigidbody2D projectileRigidbody = projectileClone.GetComponent<Rigidbody2D>();
        projectileRigidbody.AddForce(FiringPoint.forward * Power, ForceMode2D.Force);
    }

    private void SetBoolBackS4()
    {
        reloading4S = false;
    }

    IEnumerator NextBurstTimer()
    {
        GameObject S4Clone = Instantiate(_rangedAttackIconS16, transform.position, Quaternion.identity, transform.parent);
        S4Clone.transform.Translate(new Vector3(0, 1, 0));
        yield return new WaitForSeconds(0.5f);
        S16Burst();
        Destroy(S4Clone);
    }
}

