using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class health : MonoBehaviour {
	public  float Lives = 100;
	public float  dmg = 3;
	public float crck = 2;
	public float money = 0; 

	public Text lives;
	public Text shape;
	public Text damage;
	public Text crack;
	public Text Dollars;

	public GameObject Death_screen;

	public Transform[] spawn;
	int floor = 0;
	 void OnTriggerEnter(Collider Other){
		if (Other.tag == "Spawn" && GetComponent<controls>().shape == 0) {
			
			// TODO: play animation Here?!
			Vector3 pos = transform.position;
			pos = spawn[floor].position;
			transform.position = pos;
			floor++;
		}

	}


	void Update (){
	if (Lives <= 0) {
		// You Losed
			Death_screen.SetActive(true);
			Debug.Log ("Losed GAME!");
			Time.timeScale = 0;
			return;
	}
		lives.text = "Lives: " + Lives;
		shape.text = "shape: " + GetComponent<controls>().shape;
		damage.text = "Punch PWR: " + dmg;
		crack.text = "Crackign PWR: " + crck;
		Dollars.text = "Money($): " + money;
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
