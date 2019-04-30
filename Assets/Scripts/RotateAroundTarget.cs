using UnityEngine;
using System.Collections;

public class RotateAroundTarget : MonoBehaviour
{
	public Transform Target;
	public Vector3 Axis;
	public float Speed = 20.0f;

	// Use this for initialization
	void Start ()
	{

	}
	
	// Update is called once per frame
	void Update ()
	{
		transform.RotateAround (Target.position, Axis, Speed);
	}

	void FixedUpdate()
	{
		
	}
}
