using UnityEngine;
using System.Collections;

public class Rotate : MonoBehaviour {
	public float speed = 1f;	
	public Vector3 axis;

	// Update is called once per frame
	void Update () {
		float addToAngle = 0.0f;
		transform.Rotate(axis, addToAngle + speed);
	}

}
