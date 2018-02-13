using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Addvelocity : MonoBehaviour {

	private Rigidbody Body;
	public float Velocity;
	public float VelocityRate;

	void Start(){
		Body = this.gameObject.GetComponent<Rigidbody> ();

	}

	

	void Update () {

		if (Input.GetKey (KeyCode.Z)) {
			Velocity += VelocityRate;
		} else if (Input.GetKey (KeyCode.X)) {
			Velocity -= VelocityRate;
		}

		Body.AddForce (transform.TransformDirection(Vector3.right) * Velocity);
	}
}
