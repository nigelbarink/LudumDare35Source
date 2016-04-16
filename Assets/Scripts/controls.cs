using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class controls : MonoBehaviour {
	public float Speed = 2f;
	public Material[] mat = new Material[3]; 
	float cooldown = 0;
	float down = 60;
	int dmg_Upgrade = 1;
	int crck_Upgrade = 1;
	enum shapes  {none, h, Punch};
	public int shape = (int) shapes.none;
	 GameObject target;
	Vector3 last , cur ;


	public GameObject Cooldown_Warning;
	void Update () {
	// movement Handeling ~
		cur = transform.position; 
		last = cur;
		cur += new Vector3 (Input.GetAxis("Horizontal") *  Speed , 0,Input.GetAxis("Vertical") * Speed);
		float z = cur.z;
		z = Mathf.Clamp (z, 30.88f, 49.9f);
		cur.z = z;

		transform.position = cur;
		if (Input.GetMouseButtonDown (0)) {
			RaycastHit hit;
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);

			if (Physics.Raycast (ray,out hit, Mathf.Infinity) && Time.timeScale >= 0.1){
				Debug.Log (hit.collider.name);
				if (target == null || target != hit.collider.gameObject) {
					if (hit.collider.tag == "Node") {
						target = hit.collider.gameObject;
						target.GetComponent<Wall> ().select (true);
					}
				}


			else if (target == hit.collider.gameObject) {
				gameObject.GetComponent<health> ().Attack (target);
			} 
			}

			else {
				Debug.Log ("No Object there!");
				return;
			}
		}
		cooldown--;
		if (cooldown > 0) {
			Cooldown_Warning.SetActive (true);
		}
		if (cooldown <= 0) { 
			Cooldown_Warning.SetActive (false);
			if (Input.GetKeyDown (KeyCode.Z)) {
				Shift (0);
				cooldown = down;
			}
			if (Input.GetKeyDown (KeyCode.X)) {
				Shift (1);
				cooldown = down;
			}
			if (Input.GetKeyDown (KeyCode.C)) {
				Shift (2);
				cooldown = down;
			}
		}
	}

	void Shift(int num ){
		shape = num;
		health he = this.GetComponent<health> ();
		if (shape == (int)shapes.none) {
			this.gameObject.GetComponentInChildren<Renderer> ().material = mat [0]; 
			he.dmg = he.dmg * dmg_Upgrade;
			he.crck = he.crck * crck_Upgrade;
		}
		else if (shape == (int) shapes.Punch) {
			this.gameObject.GetComponentInChildren<Renderer> ().material = mat [1];
			he.dmg = (he.dmg + 3) * dmg_Upgrade; 
		}
		else if (shape == (int) shapes.h) {
			this.gameObject.GetComponentInChildren<Renderer> ().material = mat [2]; 
			he.crck = (he.crck + 2 )* crck_Upgrade;
		}
	}
	public void Pause ( bool state ){
		if (state) {
			Time.timeScale = 0;
		}
		if (!state) {
			Time.timeScale = 1;
		}
	}
}
