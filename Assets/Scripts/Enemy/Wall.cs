using UnityEngine;
using System.Collections;

public class Wall : MonoBehaviour {
	public GM gm ;
	public float lives = 50;
	public Material[] mat = new Material[5];
	public Renderer rend;
	Color default_color;
	void Start (){
		default_color = this.GetComponent<Renderer>().material.color;
		GameObject gg = GameObject.FindGameObjectWithTag ("GameController");
		if (gg != null) {
			gm = gg.GetComponent<GM> ();
			gm.pp = this.gameObject;
		}
	}

	public void select (bool fase){
		if (fase == true ) {
			this.GetComponent<Renderer> ().material.color = Color.yellow;
		}
		else {
			this.GetComponent<Renderer>().material.color = default_color ;
		}
	}

	public void DestroyWall (int cracked){
		lives -= cracked;
		if (lives >= 50) {
			rend.material =	mat [0];
		}
		if (lives <= 49 && lives > 35 ) {
			rend.material = mat [1];
		}
		if (lives <= 35 && lives > 21 ) {
			rend.material =	mat [2];
		}
		if (lives <= 21 && lives > 11 ) {
			rend.material =	mat [3];
		}
		if (lives <= 11 && lives > 0 ) {
			rend.material =	mat [4];
		}
		if (lives <= 0 ) {
			gm.player.money += 10 - gm.player.shape.return_type ();
			Destroy (this.gameObject);
			//TODO: maybe some cool destroying wall animation 
		}
	}
}
