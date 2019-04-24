using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFireBall : MonoBehaviour
{
    private GameObject player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Wall")
        {
            Destroy(gameObject);
        }
        if (other.tag == "Player")
        {
            player.GetComponent<PlayerStats>().TakeDamage(7);
            Destroy(gameObject);
        }
    }
}
