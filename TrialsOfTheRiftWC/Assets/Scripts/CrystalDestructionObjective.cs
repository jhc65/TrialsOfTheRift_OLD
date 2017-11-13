using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrystalDestructionObjective : Objective {

	public GameObject go_redCrystal, go_blueCrystal;
	private GameObject go_activeCrystal;

	override public void Instantiate(){
		if(e_color == Constants.Color.RED){
			go_activeCrystal = Instantiate(go_blueCrystal, Constants.C_BlueCrystalSpawn, new Quaternion(0, 0, 0, 0));
		}
		else{
			go_activeCrystal = Instantiate(go_redCrystal, Constants.C_RedCrystalSpawn, new Quaternion(0, 0, 0, 0));
		}
	}

	override public void Complete(){
		base.Complete();
		Destroy(go_activeCrystal);
	}

	private void Update()
	{
        if (go_activeCrystal.GetComponent<CrystalController>().f_health <= 0.0f) {
            Complete();
        }
	}
}
