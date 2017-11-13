using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceController : SpellController {
    private float f_iceDamage = Constants.SpellStats.C_IceDamage;

    // SendMessage() calls all functions named the parameter that exist in MonoBehavior 
    // scripts on the GameObject. This way, we don't have worry about differentiating 
    // between freezing a player or freezing an enemy. It'll just find the function
    // named Freeze() on the GameObject's controller script.
    protected override void ApplyEffect(GameObject go_target){
        go_target.GetComponent<PlayerController>().DoDamage(f_iceDamage);
		go_target.SendMessage("Freeze"); 
	}

    protected override void BuffSpell()
    {
        f_iceDamage = f_iceDamage * Constants.SpellStats.C_IceDamageMultiplier;
        transform.localScale += new Vector3(0.5f, 0.5f, 0.5f);
    }
	protected override void AffectCrystal(GameObject go_crystal)
    {
        Constants.Color crystalColor = go_crystal.GetComponent<CrystalController>().e_color;
        if (crystalColor != this.e_color)
        {
            go_crystal.GetComponent<CrystalController>().SpellDamage();
        }
        else if (crystalColor == this.e_color)
        {
            go_crystal.GetComponent<CrystalController>().SpellHeal();
        }
    }
}

