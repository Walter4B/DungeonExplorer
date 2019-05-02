using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Linq;

public class Exit : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            GameObject.FindObjectsOfType<CommanChest>().ToList().ForEach(chest => chest.DestroyClone());
            int ActiveScene = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(ActiveScene + 1);
        }
    }
}
