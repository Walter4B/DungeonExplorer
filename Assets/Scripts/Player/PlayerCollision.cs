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

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.tag == "Enemy" && !isColliding)
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
