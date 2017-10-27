using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalController : MonoBehaviour {

	public Constants.Color e_Color; // identifies owning team

	public Constants.Color GetColor(){
		return e_Color;
	}
}
