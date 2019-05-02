using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Shoot : MonoBehaviour
{
    public GameObject ProjectilePrefab;
    public GameObject SwingPrefab;
    public Transform FiringPoint;
    public Transform TargetCrossHair;

    public int ActiveScene;
    public int ThisScene;

    public float Power = 10.0f;
    public float SwingPower = 1.0f;

    private bool Attacking = false;

    private GameObject _projectileParent;
    private GameObject _swingParent;

    private PlayerStats ManaCost;

    void Awake()
    {
        ManaCost = this.gameObject.GetComponent<PlayerStats>();
        ParentInstantiate();
    }

    void FixedUpdate()
    {
        ThisScene = SceneManager.GetActiveScene().buildIndex;
        if (!PauseMenu.GameIsPaused)
        {
            if (UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject())
            {
                return;
            }

            if (Input.GetButtonDown("Fire1") && !Attacking)
            {
                Swing();
                Attacking = true;
                Invoke("SetBoolBack", 1);
            }

            if (Input.GetButtonDown("Fire2") && !Attacking && this.gameObject.GetComponent<PlayerStats>().currentMana >= 10)
            {
                Shooting();
                Attacking = true;
                Invoke("SetBoolBack", 1);
            }

        }
        if(ActiveScene != ThisScene)
        {
            ParentInstantiate();
        }
    }
    
    void Shooting ()
    {
        ManaCost.CastSpell();
        GameObject projectileClone = Instantiate(ProjectilePrefab, FiringPoint.position, Quaternion.identity, _projectileParent.transform);
        Rigidbody2D projectileRigidbody = projectileClone.GetComponent<Rigidbody2D>();
        projectileRigidbody.AddForce(FiringPoint.forward * Power, ForceMode2D.Force);
    }

    void Swing()
    {
        float rotation_z = Mathf.Atan2(FiringPoint.forward.y, FiringPoint.forward.x) * Mathf.Rad2Deg;


        GameObject swingClone = Instantiate(SwingPrefab, FiringPoint.position + FiringPoint.forward, Quaternion.Euler(0,0,rotation_z - 90) ,_swingParent.transform);
        swingClone.transform.SetParent(gameObject.transform);
        Rigidbody2D projectileRigidbody = swingClone.GetComponent<Rigidbody2D>();
    }

    void ParentInstantiate()
    {
        ActiveScene = SceneManager.GetActiveScene().buildIndex;
        GameObject.Find("PauseCanvas").GetComponent<PauseMenu>();
        _projectileParent = new GameObject("ProjectileParent");
        _swingParent = new GameObject("SwingParent");
    }


    private void SetBoolBack()
    {
        Attacking = false;
    }
}