using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(SphereCollider))]
public abstract class SpellController : MonoBehaviour {
	
	public Constants.Color e_color;
	public float f_damage;			// damage done to enemies
	public float f_liveTime;
	public string[] s_spellTargetTags; // these are the tags of the objects spells should do damage/effect against

	protected abstract void BuffSpell();
	protected abstract void ApplyEffect(GameObject go_target);


	void Start() {
		f_liveTime = Constants.SpellStats.C_SpellLiveTime;
		Destroy(gameObject, f_liveTime);
	}

	void OnCollisionEnter(Collision collision) {
		//Debug.Log("Impact:" + coll.gameObject.tag);
		foreach (string tag in s_spellTargetTags) {
			if (collision.gameObject.tag == tag) {
				ApplyEffect(collision.gameObject);
				Destroy(gameObject);
				return;
			}
		}

		if (collision.gameObject.tag != "Portal") { // If we hit something not a player, rift, or portal (walls), just destroy the shot without an effect.
			Destroy(gameObject);
        }
	}

	void OnTriggerEnter(Collider other) {	// rift reacts to spells by trigger rather than collision
		if (other.tag == "Rift"){
			BuffSpell();
		}
	}
}
