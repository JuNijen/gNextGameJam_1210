using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloneManager : MonoBehaviour {
	Clone[] pool;
	public static CloneManager cm;

	void Awake(){
		if(cm!=null)
			cm = this;
	}

	void Update(){

	}
}
