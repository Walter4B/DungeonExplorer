using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerStats : MonoBehaviour
{
    public int Health = 100;
    private int ActiveScene;

    private void Start()
    {
        ActiveScene = SceneManager.GetActiveScene().buildIndex; 
    }

    private void Update()
    {
        if(Health <= 0)
        {
            SceneManager.LoadScene(ActiveScene + 1);
            ActiveScene = SceneManager.GetActiveScene().buildIndex;
        }
    }
}
