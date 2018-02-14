using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityBody : MonoBehaviour {
	private double G = 0.5f  ;
	[SerializeField]private double Gforce;
	private double BodyMass,OtherBodyMass;
	private Rigidbody OtherRigid;
	[SerializeField]GameObject []OtherBodies;
	int count = 0;
	private Vector3 Pointto;

	void Start () {
		
		BodyMass = this.gameObject.GetComponent<Rigidbody> ().mass;
		OtherBodies = GameObject.FindGameObjectsWithTag ("Planet");


	}
	

	void FixedUpdate () {
		Pointto = this.gameObject.transform.position - OtherBodies [count].transform.position;
		if (count < OtherBodies.Length && OtherBodies[count]!=this.gameObject) {
			OtherRigid = OtherBodies [count].GetComponent<Rigidbody> ();
			OtherBodyMass =OtherRigid.mass;

			Gforce = G * OtherBodyMass * BodyMass / Mathf.Pow (Vector3.Distance (OtherBodies [count].transform.position, this.gameObject.transform.position), 2);
			OtherBodies [count].transform.localRotation = Quaternion.LookRotation (Pointto);
			OtherRigid.AddForce (Pointto * (float)Gforce, ForceMode.Acceleration);
			}
		   count++;
		if (count >= OtherBodies.Length)
			count = 0;




		Debug.Log (OtherBodies);
	}
}
