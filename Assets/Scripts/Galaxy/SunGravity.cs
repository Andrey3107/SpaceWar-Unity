using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SunGravity : MonoBehaviour {
	private const string PLAYER_TAG = "Player";
	private const string ENEMY_TAG = "Enemy";
	private const string PLANET_TAG = "Planet";
	private const string ASTEROID_TAG = "Asteroid";

	private string[] allTags;
	private List<GameObject> gravityObjects { get; set;}
	private GameObject[] tempObjects;

	public float gravityRadius = 1024f;
	public float gravity = 0.0005f;

	private CommonGravity _gravity;

	void findGravityObjects (){
		allTags = new string[]{ PLAYER_TAG, PLANET_TAG, ASTEROID_TAG };
		gravityObjects = new List<GameObject> ();
		foreach (string tag in allTags) {
			tempObjects = GameObject.FindGameObjectsWithTag (tag);
			foreach (GameObject obj in tempObjects) {
				gravityObjects.Add (obj);
			}
		}
//		Debug.Log (gravityObjects.Count);
	}

	void sunGravity(){
		foreach (GameObject obj in gravityObjects) {

			float dist = Vector3.Distance(obj.transform.position,transform.position);

			if (dist!=0 && dist < gravityRadius) {
				float actual_gravity = (gravityRadius - dist) * gravity;
				Vector3 deltaGrav = (transform.position - obj.transform.position) / dist * actual_gravity;

				_gravity = obj.GetComponent<CommonGravity> ();
				_gravity.Gravity (deltaGrav);

			}
		}
	}


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		findGravityObjects ();
		sunGravity ();
	}
}
