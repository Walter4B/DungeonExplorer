using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossScript : MonoBehaviour
{
    [SerializeField]
    private int Health;
    [SerializeField]
    private GameObject Gate;
   

    private void Update()
    {
        if (Health <= 0)
        {
            Destroy(Gate);
            Destroy(gameObject);
        }
    }
}