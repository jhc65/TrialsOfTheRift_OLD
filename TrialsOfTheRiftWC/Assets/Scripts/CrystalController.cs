using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrystalController : MonoBehaviour {

    public Constants.Color e_color;		// identifies owning team
	public int i_maxHealth = 500;	// crystal starting health
    public int i_health;				// indicates how much health the crystal has
    //public float f_spellDamagePercent;     // set the percentage of health the spell takes away
    //public float f_basicDamagePercent;     // set percentage for basic attack damage
    //private float f_spellDamage;    // the damage number calculated from the health and percentage given
    //private float f_basicDamage;    // the damage number calculated from the health and percentage given


	public void ChangeHealth(float percentage) {
		i_health += (int) (percentage * i_maxHealth);
		GameController.GetInstance().CrystalHealth(e_color, i_health);
	}

	//   // Use this for initialization
	//   void Start () {
	//       f_spellDamage = f_health * f_spellDamagePercent;
	//       f_basicDamage = f_health * f_basicDamagePercent;
	//}

	//   //Damages the crystal based on the spell specific percentage of max crystal health
	//   public void SpellDamage()
	//   {
	//       f_health = f_health - f_spellDamage;
	//       Debug.Log(f_health);
	//   }

	//   //Damages the crystal based on the basic attack specific percentage of max crystal health
	//   public void BasicDamage()
	//   {
	//       f_health = f_health - f_basicDamage;
	//   }

	//   //Heals the crystal based on the spell specific percentage of max crystal health
	//   public void SpellHeal()
	//   {
	//       f_health = f_health + (f_spellDamage * 0.5f);
	//   }

	//   //Heals the crystal based on the basic attack specific percentage of max crystal health
	//   public void BasicHeal()
	//   {
	//       f_health = f_health + (f_basicDamage * 0.5f);
	//   }

}
