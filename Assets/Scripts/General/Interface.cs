﻿using UnityEngine;
using UnityEngine.UI;

using System.Collections;
using System.Collections.Generic;

public class Interface : MonoBehaviour {
	/*
	 * This Class is responsible for all the User interface data!
	 * All ui button and texts are defined here.
	 * 
	 */
	public GM gm;
	public GameObject Cooldown_Warning;
	public GameObject Death_screen;
	public bool cooldown = false ;

	public Text Lives;
	public Text Shape;
	public Text Punch;
	public Text dmg;
	public Text money;
	public Text [] E_Lives;


	void Update () {
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

		if (E_Lives ==  null)
			return;
		foreach (Text t in E_Lives) {
			t.text = "Lives: " + (int) t.gameObject.GetComponentInParent<AI>().Lives;
		}
		}
}
