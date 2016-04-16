using UnityEngine;
using System.Collections;

public class FollowPlayer : MonoBehaviour {
	public GameObject orie;
	Vector3 cam ;
	Vector3 obj;
	float  change = 0;
	Vector3 Last =  new Vector3();
	void Update () {
	// track our object in the world around!
		obj = orie.transform.position;
		cam = transform.position;



			// move camera !
		if(change != 0 && change != null){
			float relcam = cam.x - obj.x; 
			//relcam = Mathf.Clamp (relcam, 34, 40);

			/*if (relcam >= 34 && relcam <= 40) {
			cam += new Vector3 (change * 1.5f ,0,0) ;

			}*/
			//camera follows object with slightly incorrect coordinates 
			cam = obj - new Vector3 (2.5f,-3,50); 
			Camera.main.transform.position = new Vector3(cam.x ,cam.y ,0);// * Time.deltaTime;
		}


		//Debug.Log (change);
		change = obj.x - Last.x;
		Last = obj;
	

	
	}}
