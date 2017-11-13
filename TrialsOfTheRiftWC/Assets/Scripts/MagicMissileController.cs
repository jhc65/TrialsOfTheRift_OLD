using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicMissileController : SpellController {
    private float f_MagicMissileDamage = Constants.SpellStats.C_MagicMissileDamage;

    protected override void ApplyEffect(GameObject go_target) {
        if (go_target.tag.ToLower() == "player") {
            go_target.GetComponent<PlayerController>().DoDamage(f_MagicMissileDamage);
            go_target.GetComponent<PlayerController>().Drop();
        }
        // TODO: Uncomment that once enemies exist in the game.
        // NOTE: may been changed depending on what tags or controllers will be called, etc
        else if (go_target.tag.ToLower() == "enemy") {
            //go_target.GetComponent<EnemyController>().DoDamage(Constants.SpellStats.C_MagicMissileDamage);
        }

        Destroy(gameObject);
    }

    protected override void BuffSpell()
    {
        // Magic Missile doesn't cross the rift. Destroy it
        Destroy(gameObject);
    }

    protected override void AffectCrystal(GameObject go_crystal)
    {
        Constants.Color crystalColor = go_crystal.GetComponent<CrystalController>().e_color;
        if (crystalColor != this.e_color)
        {
            go_crystal.GetComponent<CrystalController>().BasicDamage();
        }
        else if (crystalColor == this.e_color)
        {
            go_crystal.GetComponent<CrystalController>().BasicHeal();
        }
    }
}
