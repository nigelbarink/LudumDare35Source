using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AI : MonoBehaviour {
	public Transform target;
	public float percentage = 0.1f;
	public float Lives = 50;
	public float damage = 5;
	public int type = 1;

/*
 Type :
	0	Undefined,
	1	Vampires,
	2	bloodsouls,
	3	Humans ???
*/	

	public void Start(){
		target = GameObject.FindGameObjectWithTag ("Player").transform;
	}
	public void Update(){
		if (Lives <= 0) {
			Destroy (this.gameObject);
		}
		if (target) {

			float x =(float) percentage * target.position.x;
			float z =(float)percentage * target.position.z;

			Vector3 p = new Vector3 (x, 0,z );
			Vector3 h = target.position - p ;
			Vector3 my = this.transform.position ;

			if (Vector3.Distance (my, h) < 20) {
				my =Vector3.Lerp(my , h,  Time.deltaTime);

				float zz = my.z ;
				zz = Mathf.Clamp (zz, 30.88f, 49.9f);
				my = new Vector3 (my.x, my.y, zz);
				this.transform.position = my;
			}

			if (GameObject.FindGameObjectWithTag("GameController").GetComponent<GM> ().player.shape.return_type () >= type) {
				GameObject.FindGameObjectWithTag("GameController").GetComponent<GM> ().TakeDamage (damage, this.gameObject );
				return;
			}


			if (Vector3.Distance (my, h) <= 10) {
				GameObject.FindGameObjectWithTag("GameController").GetComponent<GM>().TakeDamage (damage, target.gameObject );
			}





		}
	}

}

