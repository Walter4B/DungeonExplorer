using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour {

    private bool damaged = false;
    [SerializeField]
    private int damage = 10;
    [SerializeField]
    private GameObject _explosion;
    [SerializeField]
    private GameObject _BossMinion;
    [SerializeField]
    private bool _isBossOrb = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Wall")
        {
            Instantiate(_explosion, transform.position, transform.rotation);
            Destroy(gameObject);
        }
        if(other.tag == "Enemy" && damaged == false)
        {
            damaged = true;
            Instantiate(_explosion,transform.position,transform.rotation);
            damage = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>().SpellDamage;
            other.GetComponent<Enemy>().TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}
