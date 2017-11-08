using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objective : MonoBehaviour {

	public Constants.Color e_color;
	public int i_numberInList;
	public bool b_complete;

	public void Set(Constants.Color c, int n){
		e_color = c;
		i_numberInList = n;
		Instantiate();
	}

	public virtual void Instantiate(){

	}

	public virtual void Complete(){
		b_complete = true;
	}
}
