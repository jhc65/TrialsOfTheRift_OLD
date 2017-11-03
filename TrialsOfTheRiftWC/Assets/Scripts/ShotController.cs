using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(SphereCollider))]
public abstract class ShotController : MonoBehaviour {
	
	public Constants.Color e_Color;	//Currently does nothing. I'd like to use this to differentiate friendly fire.
	public float f_damage;		// Damage of the bullet. Currently 0 for the demo. It also isn't used by anything for now since players don't have health.
	public float f_liveTime = 2f;
	
	protected Rigidbody r_rigidbody;
	
	protected void Start() {
		// I'd like to set e_Color from PlayerController here.
		r_rigidbody = GetComponent<Rigidbody>();
		StartCoroutine(DestroyInSeconds(f_liveTime));
        Debug.Log(e_Color);
	}

	// If a player walks into a shot, apply that shot's effect and then destroy the shot.
	protected void OnTriggerEnter(Collider coll) {
        Debug.Log("Impact:" + coll.gameObject.tag);
        if(coll.gameObject.tag == "Player") {
			ApplyEffect(coll.gameObject);
			Destroy(gameObject);
		} else if(coll.gameObject.tag != "Rift" && coll.gameObject.tag != "Portal") { // If we hit something not a player, rift, or portal (walls), just destroy the shot without an effect.
			Destroy(gameObject);
		}

	}
	
	protected abstract void ApplyEffect(GameObject go_target);
	
	IEnumerator DestroyInSeconds(float seconds){
		yield return new WaitForSeconds(seconds);
		Destroy(gameObject);
	}
}
