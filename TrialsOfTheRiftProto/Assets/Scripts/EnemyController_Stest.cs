using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController_Stest : MonoBehaviour {

    GameObject targetedPlayer;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if (targetedPlayer != null) {
            transform.position = Vector3.MoveTowards(transform.position, targetedPlayer.transform.position, 0.05f);
        }
		
	}

    public void SetPlayer(GameObject player) {
        targetedPlayer = player;
    }

    public string GetSide() {
        if (transform.position.x < 0) {
            return "left";
        } else {
            return "right";
        }
    }
}
