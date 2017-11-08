using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceController : SpellController {

	// SendMessage() calls all functions named the parameter that exist in MonoBehavior 
	// scripts on the GameObject. This way, we don't have worry about differentiating 
	// between freezing a player or freezing an enemy. It'll just find the function
	// named Freeze() on the GameObject's controller script.
	protected override void ApplyEffect(GameObject go_target){
		go_target.SendMessage("Freeze"); 
	}
}
