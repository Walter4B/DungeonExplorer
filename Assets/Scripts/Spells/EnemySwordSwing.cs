using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySwordSwing : MonoBehaviour
{

    private bool damaged = false;
    [SerializeField]
    private int damage = 10;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player" && damaged == false)
        {
            damaged = true;
            other.GetComponent<PlayerStats>().TakeDamage(damage);
        }
    }
}
