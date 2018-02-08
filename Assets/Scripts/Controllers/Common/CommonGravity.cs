using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class CommonGravity : MonoBehaviour {

	public float deltaX;
	public float deltaZ;
	public float deltaY;

	public Rigidbody rigidBody;

	public void Gravity(Vector3 delta_grav) {
		deltaX += delta_grav.x;
		deltaY += delta_grav.y;
		deltaZ += delta_grav.z;
	}

	protected virtual void Start () {
		rigidBody = GetComponent<Rigidbody> ();

	}

	protected virtual void Update () {

		// move player
		var vel = rigidBody.velocity;
		vel.x = deltaX;
		vel.y = deltaY;
		vel.z = deltaZ;
		rigidBody.velocity = vel;

	}
}