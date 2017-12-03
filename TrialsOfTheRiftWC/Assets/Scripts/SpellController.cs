using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(SphereCollider))]
public abstract class SpellController : MonoBehaviour {
	
	public Constants.Color e_color;
	public float f_damage;			// currently unused, as each individual spell reads its damage value from Constants.cs in Start()
	public string[] s_spellTargetTags; // these are the tags of the objects spells should do damage/effect against

	protected abstract void BuffSpell();
	protected abstract void ApplyEffect(GameObject go_target);


	protected virtual void Start() {
		Destroy(gameObject, Constants.SpellStats.C_SpellLiveTime);
	}

	protected virtual void OnCollisionEnter(Collision collision) {
		//Debug.Log("Impact:" + coll.gameObject.tag);
		foreach (string tag in s_spellTargetTags) {
			if (collision.gameObject.tag == tag) {
				ApplyEffect(collision.gameObject);
				Destroy(gameObject);
				return;
			}
		}

        if (collision.gameObject.tag == "Spell") {
            Constants.Color spellColor = collision.gameObject.GetComponent<SpellController>().e_color;
            if (spellColor != e_color)
            {
                Destroy(gameObject);
            }
            else {
                //ignores any collision detection between the two spells
                Physics.IgnoreCollision(GetComponent<Collider>(), collision.gameObject.GetComponent<Collider>());
            }
        }
		else if (collision.gameObject.tag != "Portal") { // If we hit something not a player, rift, or portal (walls), just destroy the shot without an effect.
			Destroy(gameObject);
        }
	}

	void OnTriggerEnter(Collider other) {	// rift reacts to spells by trigger rather than collision
		if (other.tag == "Rift"){
			BuffSpell();
		}
	}
}
