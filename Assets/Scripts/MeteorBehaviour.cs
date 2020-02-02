using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorBehaviour : MonoBehaviour {

	public float speed;
	public float rotationSpeed;

	// Use this for initialization
	void Start () {
		GetComponent<Rigidbody> ().AddForce (transform.parent.forward * speed * 100,ForceMode.Force);
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate(rotationSpeed,rotationSpeed,rotationSpeed);
	}


	void OnCollisionEnter(Collision collision)
	{
		GameObject.Destroy(this.gameObject);
	}
}
