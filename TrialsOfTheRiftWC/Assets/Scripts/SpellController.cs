using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(SphereCollider))]
public abstract class SpellController : MonoBehaviour {
	
	public Constants.Color e_color;
	public float f_damage;			// damage done to enemies
	//public float f_liveTime;
	public string[] s_spellTargetTags; // these are the tags of the objects spells should do damage/effect against

	protected abstract void BuffSpell();
	protected abstract void ApplyEffect(GameObject go_target);

    private Collision coll;  //used to turn the potato objective kinematic back on

	void Start() {
		//f_liveTime = Constants.SpellStats.C_SpellLiveTime;
		Destroy(gameObject, Constants.SpellStats.C_SpellLiveTime);
	}

	void OnCollisionEnter(Collision collision) {
		//Debug.Log("Impact:" + coll.gameObject.tag);
		foreach (string tag in s_spellTargetTags) {
			if (collision.gameObject.tag == tag) {
				ApplyEffect(collision.gameObject);

                //makes the potato stop moving after the spell has applied its affect
                //it moves the spell like this to hide it from view so it doesn't affect anyone on the field
                //I really hate this, but its the only good way for now
                if (collision.gameObject.tag == "Potato")
                {
                    coll = collision;
                    this.transform.localPosition = new Vector3(this.transform.localPosition.x, -1000.0f, this.transform.localPosition.z);
                    Invoke("TurnKinematicOn", 0.05f);
                }
                else
                {
                    Destroy(gameObject);
                }

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

    //makes the potato objective kinematic again
    private void TurnKinematicOn() {
        coll.gameObject.GetComponent<Rigidbody>().isKinematic = true;
        Destroy(gameObject);
    }

	void OnTriggerEnter(Collider other) {	// rift reacts to spells by trigger rather than collision
		if (other.tag == "Rift"){
			BuffSpell();
		}
	}
}
