using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AI : MonoBehaviour {
	public Transform target;
	public float percentage = 0.1f;
	float lives = 50;
	public void Start(){
		target = GameObject.FindGameObjectWithTag ("Player").transform;
	}
	public void Update(){
		if (target) {

			float x =(float) percentage * target.position.x;
			float z =(float)percentage * target.position.z;

			Vector3 p = new Vector3 (x, 0,z );
			Vector3 h = target.position - p ;

			Vector3 my = this.transform.position ;


			if (Vector3.Distance (my, h) < 20) {
				this.transform.position =Vector3.Lerp(my , h,  Time.deltaTime);
			}

			if (Vector3.Distance (my, h) <= 10) {
				target.GetComponent<health> ().TakeDamage (2);
			}





		}
	}
	public void DoDamage(float damage){
		lives -= damage;
	}
}

