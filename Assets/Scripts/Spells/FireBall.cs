using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour {

    private bool damaged = false;

    [SerializeField]
    private GameObject _explosion;

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
            other.GetComponent<Enemy>().TakeDamage(10);
            Destroy(gameObject);
        }
    }
}
