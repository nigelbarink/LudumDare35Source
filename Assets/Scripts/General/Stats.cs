using UnityEngine;

using System.Collections;
using System.Collections.Generic;

public class Stats  {
	/*
	 * Stats class keeps count of all player information. 
	 * Things like health , money and damage are stored here!
	 * 
	 */
	 
	public  float Lives = 100;
	public float  dmg = 3;
	public float dmgI;
	public float crck = 2;
	public float crckI;
	public float money = 0; 

	public Dictionary < string , float > UPGRADES; 

	public Shape shape = new Shape ();


	public Stats (){
		UPGRADES = new Dictionary<string, float> ();
		dmgI = dmg;
		crckI = crck;
	}


	// This is almost certainly not the way to correctly do this BUT it works for now !
	public void update_Grades (string name , float value = 1){
		if ( UPGRADES.Count == 0  ){
			UPGRADES.Add (name , value );
		}
		else if ( ! UPGRADES.ContainsKey(name)  ){
		UPGRADES.Add (name , value );
		}
		else {
		UPGRADES.Remove (name);
		UPGRADES.Add (name , value);
		}
	}

}
