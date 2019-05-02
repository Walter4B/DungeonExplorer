using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSwordSwing : MonoBehaviour
{

    private bool damaged = false;
    [SerializeField]
    private int damage;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy" && damaged == false)
        {
            damaged = true;
            damage = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>().Meleedamage;
            other.GetComponent<Enemy>().TakeDamage(damage);
        }
    }
}
