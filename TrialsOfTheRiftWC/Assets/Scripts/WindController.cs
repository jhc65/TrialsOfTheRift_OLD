using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindController : ShotController {
	
	public float f_windForce;

	protected override void ApplyEffect(GameObject go_target){
		Vector3 v3_direction = r_rigidbody.velocity.normalized;
		go_target.GetComponent<Rigidbody>().AddForce(v3_direction * f_windForce);
		go_target.GetComponent<PlayerController>().Drop();
        Destroy(gameObject);
	}
}
