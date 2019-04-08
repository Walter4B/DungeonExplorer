using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetMover : MonoBehaviour
{
    public enum MovementDirection
    {
        Horizontal,
        Vertical,
        Custom
    }

    public MovementDirection MovementType = MovementDirection.Horizontal;
    public float Magnitude = 10.0f;
    public Vector3 CustomMovementVector;

    private Transform _transform;

    private void Awake()
    {
        _transform = transform;
    }

    void Update()
    {
        switch (MovementType)
        {
            case MovementDirection.Horizontal:
                _transform.Translate(Vector3.left * Magnitude * Time.deltaTime * Mathf.Sin(Time.timeSinceLevelLoad));
                break;
            case MovementDirection.Vertical:
                _transform.Translate(Vector3.down * Magnitude * Time.deltaTime * Mathf.Sin(Time.timeSinceLevelLoad));
                break;
            case MovementDirection.Custom:
                _transform.Translate(CustomMovementVector * Magnitude * Time.deltaTime * Mathf.Sin(Time.timeSinceLevelLoad));
                break;
            default:
                break;
        }
    }
}
