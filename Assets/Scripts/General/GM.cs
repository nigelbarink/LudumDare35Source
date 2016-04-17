using UnityEngine;
using UnityEngine.UI;

using System.Collections;
using System.Collections.Generic;

public class GM : MonoBehaviour {
/*
 * the Game Manager is responsible for Victory conditions , Loses and spawning enemies. 
 * further it  handles simple operations like telling an enemy it toke damage (Or the player in some instance) 
 *
 */
	public Stats player = new Stats ();
	public   Material[] mat = new Material[3]; 
	public GameObject[] spawn ;
	public  GameObject pp;
	// move death screen to some kind of UI manager !

	public float cooldown = 0;
	float down = 60;
	int floor = 0;

	void Start () {
		player.update_Grades ("Damage");
		player.update_Grades ("Punch");
		player.update_Grades ("Movement", 0);
	}
	

	void Update () {

		cooldown = cooldown - 0.1f;
		if (cooldown > 0) {
			// we're currently counting down, this  means that there can be no shap shifting right now ! 
			GetComponent<Interface>().cooldown = true;

		}
		if (cooldown < 0) { 
			//we're currently waiting for a shapshift to happen or the down time is finnally over !
			GetComponent<Interface>().cooldown = false;

		}
	}
	public  void change_mat (int num){
		pp.GetComponentInChildren<Renderer> ().material = mat [num];
		cooldown = down;
		player.shape.set_type (num);
		onUpgrade ();
	}
	public void DoDamage(float damage){
		player.Lives -= damage;
	}

	public void onUpgrade (){
		player.dmgI = (player.dmg + player.shape.return_type() )* player.UPGRADES["Damage"];
		player.crckI = (player.crck + player.shape.return_type() ) * player.UPGRADES["Punch"];
	}

	public void Pause ( bool state ){
		if (state) {
			Time.timeScale = 0;
			Debug.Log ("Pause");
		}
		if (!state) {
			Time.timeScale = 1;
			Debug.Log ("Resume");
		}
	}
		
	public void NewFloor (Collider Other, GameObject us){
		if (Other.tag == "Spawn" && player.shape.return_type() == 0) {

			// TODO: play animation Here?!
			Vector3 pos = transform.position;
			Debug.Log (floor);
			pos = spawn [floor].transform.position;
			us.transform.position = pos;
			floor++;
		}
	}

	public	void TakeDamage(float Damage, GameObject Target){
		AI a =Target.GetComponent <AI> ();
		if (a) {
			a.Lives -= Damage * (Time.deltaTime / 2);
		} else {
			player.Lives -= Damage * (Time.deltaTime /2);
		}

		}

		void Attack(GameObject T){

			if (T.GetComponent<GM> () != null) {
			T.GetComponent<GM> ().DoDamage (player.dmg);
			}
			else if (T.GetComponent<Wall> () != null) {
			T.GetComponent<Wall> ().DestroyWall ((int) player.crck);
			}
			// And something else, maybe?
			/*if (T.GetComponent<> () != null) {
		}*/
		}

	public void Fire (){
		RaycastHit hit;
		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);

		if (Physics.Raycast (ray,out hit, Mathf.Infinity) && Time.timeScale >= 0.1){
			//Debug.Log (hit.collider.name);
			GameObject T = hit.collider.gameObject;
			if (T == null || T != hit.collider.gameObject) {
				if (hit.collider.tag == "Node") {
					T = hit.collider.gameObject;
					T.GetComponent<Wall> ().select (true);
				}
			}


			else if (T == hit.collider.gameObject) {
				Attack (T);
			} 
		}

		else {
			//Debug.Log ("No Object there!");
			return;
		}
	}

}
