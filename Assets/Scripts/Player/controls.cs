using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class controls : MonoBehaviour {

	public float sensitivity = 2f;

	public  GM gm ;
	public void Start(){
		GameObject gg = GameObject.FindGameObjectWithTag ("GameController");
		if (gg != null) {
			gm = gg.GetComponent<GM> ();
		gm.pp = this.gameObject;
		}
	}
	void OnTriggerEnter(Collider Other){
		gm.NewFloor (Other , this.gameObject);
	}
	void Update () {
		Vector3   cur ;
	// movement Handeling ~
		cur = transform.position; 

//		Debug.Log (sensitivity);
		cur += new Vector3 (Input.GetAxis("Horizontal") *  (sensitivity + gm.player.UPGRADES["Movement"]) , 0,Input.GetAxis("Vertical") * (sensitivity + gm.player.UPGRADES["Movement"]));
		float z = cur.z;
		z = Mathf.Clamp (z, 30.88f, 49.9f);
		cur.z = z;

		transform.position = cur;
		if (Input.GetMouseButtonDown (0)) {
			gm.Fire ();
		}

		if ( GameObject.FindGameObjectWithTag("GameController").GetComponent<Interface>().cooldown == false){
		if (Input.GetKeyDown (KeyCode.Z) ) {
			//	Shift (0); Shape.Types.Normal
			gm.change_mat((int)Shape.Types.Normal);
			}
		if (Input.GetKeyDown (KeyCode.X) ) {
			//Shift (1); Shape.Types.Giant
			gm.change_mat((int)Shape.Types.Giant);
			}
		if (Input.GetKeyDown (KeyCode.C) ) {
			//	Shift (2); Shape.Types.Unknown
			gm.change_mat((int)Shape.Types.Unknown);
			}
		}
		}
	}
	
