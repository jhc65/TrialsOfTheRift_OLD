using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindController : SpellController {
    private float f_windDamage = Constants.SpellStats.C_WindDamage;
	public float f_windForce;

	protected override void ApplyEffect(GameObject go_target){
		Debug.Log(transform.forward.normalized);
		Vector3 v3_direction = transform.forward.normalized;
		go_target.GetComponent<Rigidbody>().AddForce(v3_direction * f_windForce);
        go_target.GetComponent<PlayerController>().DoDamage(f_windDamage);
			go_target.GetComponent<PlayerController>().Drop();
        Destroy(gameObject);
	}

    protected override void BuffSpell()
    {
        f_windDamage = f_windDamage * Constants.SpellStats.C_WindDamageMultiplier;
        transform.localScale += new Vector3(0.5f, 0.5f, 0.5f);
    }

	protected override void AffectCrystal(GameObject go_crystal)
    {
        Constants.Color crystalColor = go_crystal.GetComponent<CrystalController>().e_color;
        if (crystalColor != this.e_color) {
            go_crystal.GetComponent<CrystalController>().SpellDamage();
        }
        else if (crystalColor == this.e_color)
        {
            go_crystal.GetComponent<CrystalController>().SpellHeal();
        }
    }
}
