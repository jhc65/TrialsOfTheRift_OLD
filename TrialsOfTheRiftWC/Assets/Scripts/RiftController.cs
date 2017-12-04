using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RiftController : MonoBehaviour {
	void OnTriggerEnter(Collider other) {
		if (other.tag == "Player") {
			other.GetComponent<PlayerController>().TakeDamage(Constants.PlayerStats.C_MaxHealth);
			other.transform.position = other.transform.position + (int)other.GetComponent<PlayerController>().e_Side * new Vector3(-4, 0, 0);
		}
	}
}
