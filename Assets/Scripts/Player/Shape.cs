using UnityEngine;
using System.Collections;

public class Shape  {
	public enum Types {
		Normal,
		Giant ,
		Unknown
	};
		
	int Type;

	public Shape (int Type =  0) {
		this.Type = Type;

	}
	public int return_type (){
		return Type;
	}
	public void set_type (int num){
		Type = num;
	}
}
