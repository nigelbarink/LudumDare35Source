using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class Interface : MonoBehaviour {
	
	/*
	 * This Class is responsible for all the User interface data!
	 * All ui button and texts are defined here.
	 * 
	 */
	public GM gm;
	public GameObject ui;
	public GameObject Cooldown_Warning;
	public GameObject Death_screen;
	public bool cooldown = false ;

	public Text Lives;
	public Text Shape;
	public Text Punch;
	public Text dmg;
	public Text money;



	void Update () {
		if (SceneManager.GetActiveScene().buildIndex == 0)
			return;
		if (SceneManager.GetActiveScene().buildIndex > 0 && ui.activeSelf == false)
			ui.SetActive (true);


		Lives.text = "Lives: " + (int) gm.player.Lives ;
		// TODO: make shapes in to readable text 
		Shape.text = "Shape: " + gm.player.shape.return_type ();
		Punch.text = "Punch PWR: " + gm.player.crckI;
		dmg.text = "Damage: " + gm.player.dmgI;
		money.text = "Money($): " + gm.player.money;

		if (gm.player.Lives <= 0) {
			// You Losed
			Death_screen.SetActive(true);
			//	Debug.Log ("Losed GAME!");
			Time.timeScale = 0;
			return;
		}
		Cooldown_Warning.SetActive (cooldown);


		}

	public void NextScene (int num){
		SceneManager.LoadScene (num);
	}
	public void exit (){
		Application.Quit ();
	}
}
