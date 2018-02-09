using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretShipController : MonoBehaviour {

	private const string PLAYER_TAG = "Player";

	[SerializeField] private float sensHor = 5.0f;
	[SerializeField] private float sensVer = 5.0f;

	[SerializeField] private float minVer = - 70.0f;
	[SerializeField] private float maxVer = 30.0f;

	private float rotationX = 0;
	private float rotationY = 0;

	private float cameraInitY = 3;

	private float deltaX;
	private float deltaZ;
	private float deltaY;

	private float dist;
	private Camera _camera;
	private GameObject _player;

	void Start () {

		_camera = GetComponent<Camera>();
		_player = GameObject.FindGameObjectWithTag (PLAYER_TAG);
		Vector3 real_cameraPos = _camera.transform.localPosition + _player.transform.position;
		dist = Vector3.Distance (real_cameraPos, _player.transform.position);
		

		Rigidbody body = GetComponent<Rigidbody>();

		// turn off world physics for mouse
		if (body != null) {
			body.freezeRotation = true;
		}

		// hide cursor ESC to exit if playmode
		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;

	}

	void CameraMoveAroudShip() {
		
		Debug.Log (dist);
		float angle_radLR = _camera.transform.localEulerAngles.y * Mathf.PI/180;
		float angle_radUD = transform.localEulerAngles.x * Mathf.PI/180;
		deltaX = -Mathf.Sin (angle_radLR) * dist;
		deltaY = Mathf.Sin (angle_radUD)*dist;
		deltaZ = -Mathf.Cos (angle_radLR) * dist;
		_camera.transform.localPosition = new Vector3 (deltaX, cameraInitY+deltaY, deltaZ);

	}

	void Update () {

		rotationX -= Input.GetAxis ("Mouse Y") * sensVer;
		rotationX = Mathf.Clamp (rotationX, minVer, maxVer);
		float delta = Input.GetAxis("Mouse X") * sensHor;

		// angle now + delta
		rotationY = transform.localEulerAngles.y + delta;
		transform.localEulerAngles = new Vector3 (rotationX, rotationY, 0);

		CameraMoveAroudShip ();

	}
}
