using UnityEngine;
using System.Collections.Generic;

public class Node : MonoBehaviour {
	public List <Node> neighbours;
	public int num;
	public Node (  ){
		neighbours = new List<Node>();

	}
}
