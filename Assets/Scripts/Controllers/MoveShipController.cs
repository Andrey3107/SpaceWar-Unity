using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// problem with place lasers in right place for diferent models and diferent scale?
// no display camera rendering after dead
// when hit sun sun disappear 

// problem with crosshair use different models
// change diagonal speed
// better system for move

// aster collision
// respawan asters
// destroy asters

// made torpedos
// graviry torpedos


// new 3d models


public class MoveShipController : CommonGravity {
	[SerializeField] private float engineSpeed = 80f;
	[SerializeField] private float maxSpeed = 100;
	[SerializeField] private float rotateSpeed = 100f;

	private bool up;
	private bool down;
	private float deltaUp;
	private float deltaDown;

	void runEngine() {
		
		float speed = Input.GetAxis ("Vertical") * engineSpeed;
		speed *= Time.deltaTime;
		// angle for left right
		float angle_radLR = transform.localEulerAngles.y * Mathf.PI/180;
		// angle for up down
		float angle_radUD = transform.localEulerAngles.x * Mathf.PI/180;

		deltaX += Mathf.Sin (angle_radLR)*speed;
		deltaY += -Mathf.Sin (angle_radUD)*speed;
		deltaZ += Mathf.Cos (angle_radLR)*speed;

		deltaX = Mathf.Min (Mathf.Max (deltaX, -maxSpeed), maxSpeed);
		deltaY = Mathf.Min (Mathf.Max (deltaY, -maxSpeed), maxSpeed);
		deltaZ = Mathf.Min (Mathf.Max (deltaZ, -maxSpeed), maxSpeed);

//		Debug.Log (deltaX);
//		Debug.Log (deltaY);
//		Debug.Log (deltaZ);
	}

	// Use this for initialization
	protected override void Start () {
		base.Start ();
		deltaZ = 0;
		deltaX = 0;
		deltaY = 0;
	}

	// Update is called once per frame
	protected override void Update () {
		base.Update ();

		// move forward
		if (Input.GetAxis ("Vertical") > 0) {
			runEngine ();
		}
		// soft move up down
		if (Input.GetKeyDown(KeyCode.Q)) {
			up = true;
		}
		if (Input.GetKeyUp (KeyCode.Q)) {
			up = false;
			deltaUp = 0;
		}
		if (Input.GetKeyDown(KeyCode.E)) {
			down = true;
		}
		if (Input.GetKeyUp(KeyCode.E)) {
			down = false;
			deltaDown = 0;
		}

		if (up){
			if (deltaUp < 1) {
				deltaUp += 0.1f;
			}

			transform.Rotate (-deltaUp*rotateSpeed*Time.deltaTime,0, 0);
		}

		if (down){
			if (deltaDown < 1) {
				deltaDown+=0.1f;
			}
			transform.Rotate (deltaDown*rotateSpeed*Time.deltaTime,0, 0);
		}
			
		// rotate
		float rotateY = Input.GetAxis ("Horizontal") * rotateSpeed;
		transform.Rotate (0, rotateY*Time.deltaTime, 0);

	
	}
}
