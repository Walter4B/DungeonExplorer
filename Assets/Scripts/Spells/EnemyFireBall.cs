using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFireBall : MonoBehaviour
{
    private bool damaged = false;

    [SerializeField]
    private GameObject _explosion;
    [SerializeField]
    private int damage = 10;
    [SerializeField]
    private GameObject _BossMinion;
    [SerializeField]
    private bool _isBossOrb = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Wall")
        {
            Instantiate(_explosion, transform.position, transform.rotation);
            if (_isBossOrb)
            {
                Instantiate(_BossMinion, transform.position, Quaternion.identity);
            }
            Destroy(gameObject);
        }
        if (other.tag == "Player" && damaged == false)
        {
            damaged = true;
            Instantiate(_explosion, transform.position, transform.rotation);
            other.GetComponent<PlayerStats>().TakeDamage(damage);
            if (_isBossOrb)
            {
                Instantiate(_BossMinion, transform.position, Quaternion.identity);
            }
            Destroy(gameObject);
        }
    }
}
