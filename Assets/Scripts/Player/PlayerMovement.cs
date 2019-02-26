using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float Speed = 2;
    public GameObject crossHair;

    void Update()
    {
        Movement();
        MoveCrossHair();
    }

    public void Movement()
    {
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0.0f);

        transform.position = transform.position + (movement * Speed) * Time.deltaTime;
        MoveCrossHair();
    }

    private void MoveCrossHair()
    {
        Cursor.visible = false;
        Vector3 mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

        Vector2 direction = new Vector2(mousePosition.x, mousePosition.y);

        crossHair.transform.position = direction;

    }
}

    