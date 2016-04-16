using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AI : MonoBehaviour {
	//Dictionary<Transform, int>  Nodes = new Dictionary<Transform, int>();
	Dictionary<Transform, int> nodes; 
	public Dictionary<Transform, int > destiny;
	public Transform[] reached;

	RaycastHit hit ;
	void Start () {
	}
	void Update () {}
	/*
	start = the closest node from the AI controlled object 
	goal = the closest node towards the player 

destiny is the path of which we go through after completely determining the best route!
	*/
	public int GoTo (Transform start , Transform goal ){
		destiny.Add (start, 0);
		Transform current = start;
		if ( current.position != goal.position){
		
		float lowest = 0;
		GameObject neighbour ;
		GameObject[] t = giveNodes (start, goal);
		
			for (int x = 0; x <=   t.Length; x++) {
			
				float value = Vector3.Distance (t [x].transform.position, goal.position);
			
				if (value < lowest) {
				lowest = value;
				neighbour = t.Clone [x];
			}
		}
			destiny.Add (neighbour.transform, lowest); 
			current = neighbour;
	}

		if (destiny == null)
			return;
		else {
			

		}

	}

	public GameObject[] giveNodes(int distance, Transform start) {
		GameObject[] go;

		Physics.BoxCast (start.position, 2f * distance, Vector3.forward, out hit);
		go[0]= hit.collider.gameObject;

		Physics.BoxCast (start.position, 2f * distance, Vector3.left, out hit);
		go [1] = hit.collider.gameObject;

		Physics.BoxCast (start.position, 2f * distance, Vector3.right, out hit);
		go[2]= hit.collider.gameObject;

		Physics.BoxCast (start.position, 2f * distance, Vector3.back, out hit);
		go [3] = hit.collider.gameObject;
		// left back
		Physics.BoxCast (start.position, 2f * distance, new Vector3 (-1,0,-1), out hit);
		go[4]= hit.collider.gameObject;
		// left forward 
		Physics.BoxCast (start.position, 2f * distance, new Vector3 (-1,0,1), out hit);
		go [5] = hit.collider.gameObject;
		// right back
		Physics.BoxCast (start.position, 2f * distance, new Vector3 (1,0,-1), out hit);
		go[6]= hit.collider.gameObject;
		// right forward
		Physics.BoxCast (start.position, 2f * distance, new Vector3 (1,0,1), out hit);
		go [7] = hit.collider.gameObject;

		return go;
	}
}
