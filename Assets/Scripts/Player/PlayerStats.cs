using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerStats : MonoBehaviour
{
    public int Health = 100;

    private void Update()
    {
        if(Health <= 0)
        {
            SceneManager.LoadScene(1);
        }
    }
}
