using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeObjectDestractor : MonoBehaviour
{
    public float Time = 5.0f;

    void Awake()
    {
        Invoke("DestroyNow", Time);
    }
    private void DestroyNow()
    {
        Destroy(gameObject);
    }
}
