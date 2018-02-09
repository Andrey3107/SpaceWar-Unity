using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet : CommonGravity {
	[SerializeField] private float rotateSpeed = 0.2f;

	// Use this for initialization
	protected override void Start () {
		base.Start ();
	}
	
	// Update is called once per frame
	protected override void Update () {
		base.Update ();
		transform.Rotate (0, rotateSpeed, 0);
	}
}
