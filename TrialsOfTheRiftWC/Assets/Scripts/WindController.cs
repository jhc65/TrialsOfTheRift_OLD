using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindController : SpellController {

	public float f_windForce;
	private float f_windDamage = Constants.SpellStats.C_WindDamage;

    // [Param Fix] - Remove if unecessary.
    private void Start() {
        f_windForce = Constants.SpellStats.C_WindForce;
    }

    protected override void ApplyEffect(GameObject go_target) {
        if (go_target.tag == "Player") {
			Vector3 v3_direction = transform.forward.normalized;
			go_target.GetComponent<Rigidbody>().AddForce(v3_direction * f_windForce);
			go_target.GetComponent<PlayerController>().Drop();
		}
		else if (go_target.tag == "Enemy") {
			Vector3 v3_direction = transform.forward.normalized;
			go_target.GetComponent<Rigidbody>().AddForce(v3_direction * f_windForce);
			go_target.GetComponent<EnemyController>().TakeDamage(f_windDamage);
		}
		else if (go_target.tag == "Crystal"){
			Constants.Color crystalColor = go_target.GetComponent<CrystalController>().e_color;
			if (crystalColor != e_color){
				go_target.GetComponent<CrystalController>().ChangeHealth(-0.1f);
			}
			else if (crystalColor == e_color) {
				go_target.GetComponent<CrystalController>().ChangeHealth(0.05f);
			}
		}
    }

    protected override void BuffSpell(){
        f_windDamage = f_windDamage * Constants.SpellStats.C_WindDamageMultiplier;
        transform.localScale += new Vector3(0.5f, 0.5f, 0.5f);
    }
}
