using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour {

	public float attackRange = 1.0f;
	public float distanceFromTarget;
	private Transform player;
	private GameObject[] players;
	private Transform player1;
	private Transform player2;

	private float dist;
	public Transform thisObject;
	public int side;
	public enum Side {LEFT, RIGHT};
	protected float rotAngle;
	public float speed = 1.5f;

	void Start () {
		players = GameObject.FindGameObjectsWithTag("Player");
		player1 = players[0].transform;
		player2 = players[1].transform;
	}
	
	// Update is called once per frame
	void Update () {

		float dist1 = Vector3.Distance(player1.position, transform.position);
		float dist2 = Vector3.Distance(player2.position, transform.position);

		if (player1.position.x > 0 && transform.position.x > 0) {
			player = player1;
			dist = dist1;
		}
		else if (player1.position.x < 0 && transform.position.x < 0) {
			player = player1;
			dist = dist1;
		}
		else if (player2.position.x < 0 && transform.position.x < 0) {
			player = player2;
			dist = dist2;
		}
		else if (player2.position.x > 0 && transform.position.x > 0){
			player = player2;
			dist = dist2;
		}
	
		transform.LookAt(player);
		if (player) {
			if (dist > attackRange) {
				transform.position += transform.forward * speed * Time.deltaTime;
			}
			else {
				transform.position -= transform.forward * speed * Time.deltaTime;
			}
		}
	}

	void SetSide(int NewSide) {
		if (NewSide == 1 || NewSide == 2) {
			side = NewSide;
		}
	}

	void SwitchSide() {
		if (side == 1) {
			side = 2;
		}
		else {
			side = 2;
		}
	}

	Side GetSide() {
		float x = transform.position.x;
		if (x < 0) {
			side = 1;
			return Side.LEFT;
		}
		else {
			side = 2;
			return Side.RIGHT;
		}
	}
}