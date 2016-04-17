using UnityEngine;
using System.Collections;

public class FollowPlayer : MonoBehaviour {
	public GameObject orie;
	Vector3 cam ;
	Vector3 obj;

	void Update () {
	// track our object in the world around!
		obj = orie.transform.position;
		cam = transform.position;
			// move camera !
			//camera follows object with slightly incorrect coordinates 
			cam = obj - new Vector3 (2.5f,-3,50); 
			Camera.main.transform.position = new Vector3(cam.x ,cam.y ,0);// * Time.deltaTime;
			
	}}
