using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindController : SpellController {
	
	public float f_windForce;

	protected override void ApplyEffect(GameObject go_target){
		Debug.Log(transform.forward.normalized);
		Vector3 v3_direction = transform.forward.normalized;
		go_target.GetComponent<Rigidbody>().AddForce(v3_direction * f_windForce);
		go_target.GetComponent<PlayerController>().Drop();
        Destroy(gameObject);
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
