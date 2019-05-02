using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    private bool isColliding;

    private void FixedUpdate()
    {
        if (isColliding)
        {
            Invoke("SetBoolBackCollide", 2);
        }
    }
   
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy" && !isColliding)
        {
            isColliding = true;
            GetComponent<PlayerStats>().TakeDamage(5);
            GetComponent<PlayerStats>().CanTakeDamage = false;
        }
    }

    private void SetBoolBackCollide()
    {
        isColliding = false;
    }
}
