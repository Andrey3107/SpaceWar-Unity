using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Asteroid : CommonGravity {
	[SerializeField] private int minSpeed = -10;
	[SerializeField] private int maxSpeed = 10;
	[SerializeField] private int rotateSpeed = 20;

	private Vector3 astDt;


	// Use this for initialization
	protected override void Start () {
		base.Start ();
		RandomDt ();
	}
	void RandomDt() {
		deltaX = Random.Range(minSpeed,maxSpeed);
		deltaY = Random.Range(minSpeed,maxSpeed);
		deltaZ = Random.Range(minSpeed,maxSpeed); 

	}	
	// Update is called once per frame
	protected override void Update () {
		base.Update ();

		transform.Rotate (rotateSpeed*deltaX*Time.deltaTime,
			rotateSpeed*deltaY*Time.deltaTime, 
			rotateSpeed*deltaZ*Time.deltaTime);
	}
}
