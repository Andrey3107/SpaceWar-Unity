using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet : CommonGravity {
	public float rotateSpeed = 0.2f;

	// Use this for initialization
	protected void Start () {
		base.Start ();
	}
	
	// Update is called once per frame
	protected void Update () {
		base.Update ();
		transform.Rotate (0, 0.2f, 0);
	}
}
