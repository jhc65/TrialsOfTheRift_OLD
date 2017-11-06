using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindController : ShotController {
	
	public float f_windForce;

	protected override void ApplyEffect(GameObject go_target){
		Debug.Log(transform.forward.normalized);
		Vector3 v3_direction = transform.forward.normalized;
		go_target.GetComponent<Rigidbody>().AddForce(v3_direction * f_windForce);
		go_target.GetComponent<PlayerController>().Drop();
        Destroy(gameObject);
	}
}
