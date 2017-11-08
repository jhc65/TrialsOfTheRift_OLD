using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaptureTheFlagObjective : Objective {

	public int i_maxScore;						// score needed to complete objective
	public GameObject go_redFlag, go_blueFlag;	// referenced flag objects
	public GameObject go_redGoal, go_blueGoal;	// referenced goal objects

	private GameObject go_currentFlag, go_currentGoal;  // active objects specific to this objective instance
	private int i_score;

	override public void Instantiate(){
		// instantiate prefabs based on color
		if(e_color == Constants.Color.RED){
			go_currentFlag = Instantiate(go_blueFlag, Constants.C_RedObjectiveSpawn, new Quaternion(0,0,0,0));
			go_currentGoal = Instantiate(go_redGoal, Constants.C_RedObjectiveGoal, new Quaternion(0, 0, 0, 0));
		}
		else{
			go_currentFlag = Instantiate(go_redFlag, Constants.C_BlueObjectiveSpawn, new Quaternion(0, 0, 0, 0));
			go_currentGoal = Instantiate(go_blueGoal, Constants.C_BlueObjectiveGoal, new Quaternion(0, 0, 0, 0));
		}
	}

	override public void Complete(){
		// destroy prefabs based on color
		base.Complete();
		Destroy(go_currentFlag);
		Destroy(go_currentGoal);
	}

	private void Start(){
		i_score = 0;
		i_maxScore = 2;
	}

	private void Update(){
		if (go_currentFlag.GetComponent<FlagController>().b_scored){
			go_currentFlag.GetComponent<FlagController>().b_scored = false;
			i_score += 1;
			GameController.GetInstance().Score(e_color);
		}
		if(i_score == i_maxScore){
			Complete();
		}
	}
}
