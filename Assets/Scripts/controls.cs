using UnityEngine;
using System.Collections;

public class controls : MonoBehaviour {
	public float Speed = 2f;
	public float yTime ;
	Vector3 last , cur ;
	Rigidbody rig ;
	void Start () {
		rig = GetComponent<Rigidbody> ();
		yTime = Speed * 0.75f ;
	}
	

	void Update () {
	// movement Handeling ~
		cur = transform.position; 
		last = cur;
		cur += new Vector3 (Input.GetAxis("Horizontal") *  Speed , Input.GetAxis("Jump")* yTime,Input.GetAxis("Vertical") * Speed);
		float z = cur.z;
		z = Mathf.Clamp (z, 30.88f, 49.9f);
		cur.z = z;

		transform.position = cur;
	/*	if (Input.GetKeyDown(KeyCode.Space)) {
			Debug.Log ("Air Time");
			rig.AddForce (new Vector3 (0, Input.GetAxis("Jump")* yTime,0));
	
		} */
	}
}
