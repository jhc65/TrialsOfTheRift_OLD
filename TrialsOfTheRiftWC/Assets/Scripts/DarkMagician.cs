using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarkMagician : MonoBehaviour {

	public GameObject[] go_objectivesList;

	//private GameObject go_redObjective, blueObjective;
	private Objective O_redObjective, O_blueObjective;

	private void Start(){
		O_redObjective = Instantiate(go_objectivesList[0]).GetComponent<Objective>();
		O_blueObjective = Instantiate(go_objectivesList[0]).GetComponent<Objective>();
		O_redObjective.Set(Constants.Color.RED, 1);
		O_blueObjective.Set(Constants.Color.BLUE, 1);
	}

	private void Update(){

		// check for completion of objectives
		if (O_redObjective.b_complete){
			O_redObjective = GetNextObjective(O_redObjective);
		}
		else if(O_blueObjective.b_complete){
			O_blueObjective = GetNextObjective(O_blueObjective);
		}
	}

	private Objective GetNextObjective(Objective o)
	{
		int newObjectiveNumber = o.i_numberInList;
		//if(newObjectiveNumber == 5)
		//{ game over}

		// temporary, alternates between two objectives indefinitely instead of counting up to 5 and ending
		if (newObjectiveNumber == 2){
			newObjectiveNumber = 1;
		}
		else{
			newObjectiveNumber += 1;
		}

		GameObject go_newObjective = Instantiate(go_objectivesList[newObjectiveNumber - 1]);	// objectiveNumber starts with 1 but array is 0-based
		go_newObjective.GetComponent<Objective>().Set(o.e_color, newObjectiveNumber);
		Destroy(o.gameObject);
		return go_newObjective.GetComponent<Objective>();
	}
}
