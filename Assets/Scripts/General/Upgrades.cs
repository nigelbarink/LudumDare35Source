using UnityEngine;
using System.Collections;

public class Upgrades : MonoBehaviour {

	public GM gm;

	public void Add_Upgrades (string name){
		switch (name) {
		case "VTooth":
			if (gm.player.money < 10)
				break;
			gm.player.update_Grades ("Damage", 1.05f);
			gm.player.update_Grades ("Movement", 0.2f);
			gm.player.money -= 10;
			gm.onUpgrade ();
			break;


		case "H_Hair":
			if (gm.player.money < 10)
				break;
			gm.player.update_Grades ("Punch", 1.02f);
			gm.player.update_Grades ("Movement", -0.01f);
			gm.player.money -= 10;
			gm.onUpgrade ();
			break;


		case "Axe":
			if (gm.player.money < 15) 
				break;
			gm.player.update_Grades ("Damage" , 1.08f);
			gm.player.update_Grades ("Punch", 1.04f);
			gm.player.update_Grades ("Movement" , -0.05f);
			gm.player.money -= 15;
			gm.onUpgrade ();
			break;


		case "Sword":
			if (gm.player.money < 15) 
				break;
			gm.player.update_Grades ("Damage", 1.08f);
			gm.player.update_Grades ("Punch" ,2 );
			gm.player.update_Grades ("Movement",- 0.02f);
			gm.player.money -= 15;
			gm.onUpgrade ();
			break;


		case "A_feet":
			if (gm.player.money < 20) 
				break;
			gm.player.update_Grades ("Movement" , 0.05f);
			gm.player.money -= 20;
			gm.onUpgrade ();
			break;


		case "ThirdEye":
			if (gm.player.money < 1) 
				break;
			gm.player.update_Grades ("Damage" , 1.005f);
			gm.player.update_Grades ("Movement", 0.01f);
			gm.player.money -= 1;
			gm.onUpgrade ();
			break;


		case "Hunger":
			if (gm.player.money < 30) 
				break;
			gm.player.update_Grades ("Damage" , 1.25f );
			gm.player.update_Grades ("Movement" , 0.2f);
			gm.player.money -= 30;
			gm.onUpgrade ();
			break;


		case "DwarfenPowder":
			if (gm.player.money < 30) 
				break;
			gm.player.update_Grades ("Punch" , 1.25f);
			gm.player.update_Grades ("Movement" , 0.2f);
			gm.player.money -= 30;
			gm.onUpgrade ();
			break;


		case "SecBrain":
			if (gm.player.money < 15) 
				break;
			gm.player.update_Grades ("Damage" , 1.1f);
			gm.player.update_Grades ("Punch" , 1.1f);
			gm.player.money -= 15;
			gm.onUpgrade ();
			break;


		case "Keys":
			if (gm.player.money < 100) 
				break;
			gm.player.update_Grades ("End" , 500);
			gm.player.money -= 100;
			break;
		}

	}
}
