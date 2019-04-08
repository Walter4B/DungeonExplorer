using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public GameObject ProjectilePrefab;
    public GameObject SwingPrefab;
    public Transform FiringPoint;

    public float Power = 10.0f;

    private GameObject _projectileParent;

    void Awake()
    {
        GameObject.Find("PauseCanvas").GetComponent<PauseMenu>();
        _projectileParent = new GameObject("ProjectileParent");

    }

    void Update()
    {


        if (!PauseMenu.GameIsPaused)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                Swing();
            }
            if (Input.GetButtonDown("Fire2"))
            {
                Shooting();
            }
        }
    }
    
    void Shooting ()
    {
        GameObject projectileClone = Instantiate(ProjectilePrefab, FiringPoint.position, Quaternion.identity, _projectileParent.transform);
        Rigidbody2D projectileRigidbody = projectileClone.GetComponent<Rigidbody2D>();
        projectileRigidbody.AddForce(FiringPoint.forward * Power, ForceMode2D.Force);
    }

    void Swing()
    {
        GameObject swingClone = Instantiate(SwingPrefab, FiringPoint.position, Quaternion.identity);
        Rigidbody2D projectileRigidbody = swingClone.GetComponent<Rigidbody2D>();
    }
}