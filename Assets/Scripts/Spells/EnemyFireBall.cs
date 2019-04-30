using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFireBall : MonoBehaviour
{
    private bool damaged = false;

    [SerializeField]
    private GameObject _explosion;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Wall")
        {
            Instantiate(_explosion, transform.position, transform.rotation);
            Destroy(gameObject);
        }
        if (other.tag == "Player" && damaged == false)
        {
            damaged = true;
            Instantiate(_explosion, transform.position, transform.rotation);
            other.GetComponent<PlayerStats>().TakeDamage(7);
            Destroy(gameObject);
        }
    }
}
