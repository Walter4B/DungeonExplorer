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
            damage = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>().MeleeDamage;
            other.GetComponent<Enemy>().TakeDamage(damage);
            //ovak mozda mozeš popraviti da ti se damagea samo jedan neprijatelj (makneš onda ovu varijablu damaged)
            // ---> GetComponent<Collider2D>().enabled = false;
        }
    }
}
