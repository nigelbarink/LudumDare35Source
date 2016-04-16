using UnityEngine;
using System.Collections;

public class health : MonoBehaviour {
	public  float Lives = 100;
	float  dmg = 3;
	float crck = 2;
	void Update (){
	if (Lives <= 0) {
		// You Losed
			Debug.Log ("Losed GAME!");
			return;
	}
	
	}

public	void TakeDamage(float Damage){
		Lives  -= Damage * Time.deltaTime;
	}
	public void Attack(GameObject T){

		if (T.GetComponent<AI> () != null) {
			T.GetComponent<AI> ().DoDamage (dmg);
		}
		else if (T.GetComponent<Wall> () != null) {
			T.GetComponent<Wall>().DestroyWall((int)crck);
		}
		// And something else, maybe?
		/*if (T.GetComponent<> () != null) {
		}*/
	}


}
