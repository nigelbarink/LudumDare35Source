using UnityEngine;
using System.Collections;

public class controls : MonoBehaviour {
	public float Speed = 2f;
	public Material[] mat = new Material[3]; 

	enum shapes  {none, h, Punch};
	int type = (int) shapes.none;
	GameObject target;
	Vector3 last , cur ;

	void Update () {
	// movement Handeling ~
		cur = transform.position; 
		last = cur;
		cur += new Vector3 (Input.GetAxis("Horizontal") *  Speed , 0,Input.GetAxis("Vertical") * Speed);
		float z = cur.z;
		z = Mathf.Clamp (z, 30.88f, 49.9f);
		cur.z = z;

		transform.position = cur;
		if (Input.GetMouseButton (0)) {
			RaycastHit hit;
			Ray ray = new Ray (Input.mousePosition, Vector3.forward);
				Physics.Raycast (ray,out hit, Mathf.Infinity);
			if (target == null || target != hit.collider.gameObject) {
				target = hit.collider.gameObject;
			}
			if (target == hit.collider.gameObject) {
				gameObject.GetComponent<health> ().Attack (target);
			} 
		}
		if (Input.GetKeyDown (KeyCode.Z)) {
			Shift (0);
		}
		if (Input.GetKeyDown (KeyCode.X)) {
			Shift (1);
		}
		if (Input.GetKeyDown (KeyCode.C)) {
			Shift (2);
		}
	}

	void Shift(int num ){
		type = num;
		if (type == (int)shapes.none) {
			this.gameObject.GetComponentInChildren<Renderer> ().material = mat [0]; 
		}
		else if (type == (int) shapes.Punch) {
			this.gameObject.GetComponentInChildren<Renderer> ().material = mat [1]; 
		}
		else if (type == (int) shapes.h) {
			this.gameObject.GetComponentInChildren<Renderer> ().material = mat [2]; 
		}
	}
}
