using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSwordSwing : MonoBehaviour
{

    private bool damaged = false;
    [SerializeField]
    private int damage = 10;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy" && damaged == false)
        {
            damaged = true;
            other.GetComponent<Enemy>().TakeDamage(damage);
        }
    }
}
