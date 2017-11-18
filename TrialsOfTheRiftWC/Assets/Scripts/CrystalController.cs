using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrystalController : MonoBehaviour
{
    public Constants.Color e_color;     // identifies owning team
    public int i_maxHealth = Constants.EnviroStats.C_CrystalMaxHealth;	// crystal starting health
    public float i_health;                // indicates how much health the crystal has

    public void ChangeHealth(float percentage)
    {
        i_health += percentage * i_maxHealth;
        if(i_health > i_maxHealth) {
            i_health = i_maxHealth;
        }
        GameController.GetInstance().CrystalHealth(e_color, (int) i_health);
    }
}
