using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlagController : MonoBehaviour {

	public Constants.Color e_Color;	// identifies owning team
	public Vector3 v3_home;			// location of flag in players' base

	private void OnTriggerEnter(Collider other){
		if (other.tag == "InteractCollider"){	// opposing player trying to pick up flag
			if(other.GetComponentInParent<PlayerController>().GetColor() != e_Color){
				other.GetComponentInParent<PlayerController>().Pickup(gameObject);
			}
		}
		if(other.tag == "Player"){	// owning player "collects" flag, return it to base
			if(other.GetComponentInParent<PlayerController>().GetColor() == e_Color){
				transform.position = v3_home;
			}
		}
		if (other.tag == "Goal"){   // opposing player scoring with flag
			if (other.GetComponent<GoalController>().GetColor() != e_Color){
				if(transform.root.tag == "Player")	// this should not be necessary...OnTriggerEnter called twice on opponent's goal the second time a player scores (and only the second time). but Drop() works correctly so root is no longer player and throws error (would also increase score twice)
				{
					//GameController.GetInstance().Score(other.GetComponentInParent<GoalController>().GetColor());
					transform.root.GetComponent<PlayerController>().Drop();
					transform.position = v3_home;
				}

			}
		}
	}
}
