using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectricAOEController : MonoBehaviour {

	public string[] s_spellTargetTags; // these are the tags of the objects spells should do damage/effect against
	public Constants.Color e_color;
	public float f_electricDamage;	// TODO: set this immediately after instantiation

	void Start () {
		Destroy(gameObject, Constants.SpellStats.C_ElectricAOELiveTime);
	}
	
	void OnTriggerEnter(Collider other) {
		foreach (string tag in s_spellTargetTags){
			if (other.gameObject.tag == tag){
				ApplyEffect(other.gameObject);
				return;
			}
		}
	}

	void OnTriggerExit(Collider other) {
		foreach (string tag in s_spellTargetTags) {
			if (other.gameObject.tag == tag) {
				NegateEffect(other.gameObject);
				return;
			}
		}
	}

	private void ApplyEffect(GameObject go_target) {
		if (go_target.tag == "Player") {
			go_target.GetComponent<PlayerController>().Drop();
			go_target.GetComponent<PlayerController>().f_canMove = .5f;
		}
		else if (go_target.tag == "Enemy") {
			StartCoroutine("ApplyEnemyDamage", go_target);
			// TODO: change enemy speed *.5
		}
		else if (go_target.tag == "Crystal") {
			StartCoroutine("ApplyCrystalDamage", go_target);

		}
	}

	private void NegateEffect(GameObject go_target) {
		if (go_target.tag == "Player") {
			go_target.GetComponent<PlayerController>().f_canMove = 1;
		}
		else if (go_target.tag == "Enemy") {
			StopCoroutine("ApplyCrystalDamage");
		}
		else if (go_target.tag == "Crystal") { 
			StopCoroutine("ApplyCrystalDamage");	// shouldn't be practically necessary
		}
	}

	// applies AOE damage/heal to crystal every .5s until dissipation
	IEnumerator ApplyCrystalDamage(GameObject go_target) {
		Constants.Color crystalColor = go_target.GetComponent<CrystalController>().e_color;
		if (crystalColor != e_color) {
			go_target.GetComponent<CrystalController>().ChangeHealth(Constants.SpellStats.C_SpellCrystalDamagePercent / 5);
		}
		else if (crystalColor == e_color) {
			go_target.GetComponent<CrystalController>().ChangeHealth(Constants.SpellStats.C_SpellCrystalHealPercent / 5);
		}
		yield return new WaitForSeconds(0.5f);
		StartCoroutine("ApplyCrystalDamage", go_target);
	}

	// applies AOE damage to enemy every .5s until dissipation or triggerexit
	IEnumerator ApplyEnemyDamage(GameObject go_target) {
		go_target.GetComponent<EnemyController>().TakeDamage(f_electricDamage);
		yield return new WaitForSeconds(0.5f);
		StartCoroutine("ApplyEnemyDamage", go_target);
	}

}
