using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class InputManager{

	public enum Axes{
		P1_Horizontal, P1_Vertical,
		//P1_BasicAttack,
		P1_WindSpell,
		P1_IceSpell,
		//P1_ElectricSpell,
		//P1_Ultimate,
		P1_Interact,
		P1_Menu, P1_Submit, P1_Cancel,

		P2_Horizontal, P2_Vertical,
		//P2_BasicAttack,
		P2_WindSpell,
		P2_IceSpell,
		//P2_ElectricSpell,
		//P2_Ultimate,
		P2_Interact,
		P2_Menu, P2_Submit, P2_Cancel,

		P3_Horizontal, P3_Vertical,
		//P3_BasicAttack, 
		P3_WindSpell,
		P3_IceSpell,
		//P3_ElectricSpell,
		//P3_Ultimate,
		P3_Interact,
		P3_Menu, P3_Submit, P3_Cancel,

		P4_Horizontal, P4_Vertical,
		//P4_BasicAttack,
		P4_WindSpell,
		P4_IceSpell,
		//P4_ElectricSpell,
		//P4_Ultimate,
		P4_Interact,
		P4_Menu, P4_Submit, P4_Cancel
	}

	// left stick and L1/R1 are same between controllers
	public static Dictionary<Axes, string> controlMap = new Dictionary<Axes, string>{
		{Axes.P1_Horizontal,"P1 Horizontal XBOX"},
		{Axes.P1_Vertical,"P1 Vertical XBOX"},
		//{Axes.P1_BasicAttack,"P1 Basic Attack XBOX"},
		{Axes.P1_WindSpell,"P1 Wind Spell XBOX"},
		{Axes.P1_IceSpell,"P1 Ice Spell XBOX"},
		//{Axes.P1_ElectricSpell,"P1 Electric Spell XBOX"},
		//{Axes.P1_Ultimate,"P1 Ultimate XBOX"},
		{Axes.P1_Interact,"P1 Interact XBOX"},
		{Axes.P1_Menu,"P1 Menu XBOX"},
		{Axes.P1_Submit,"P1 Submit XBOX"},
		{Axes.P1_Cancel,"P1 Cancel XBOX"},

		{Axes.P2_Horizontal,"P2 Horizontal XBOX"},
		{Axes.P2_Vertical,"P2 Vertical XBOX"},
		//{Axes.P2_BasicAttack,"P2 Basic Attack XBOX"},
		{Axes.P2_WindSpell,"P2 Wind Spell XBOX"},
		{Axes.P2_IceSpell,"P2 Ice Spell XBOX"},
		//{Axes.P2_ElectricSpell,"P2 Electric Spell XBOX"},
		//{Axes.P2_Ultimate,"P2 Ultimate XBOX"},
		{Axes.P2_Interact,"P2 Interact XBOX"},
		{Axes.P2_Menu,"P2 Menu XBOX"},
		{Axes.P2_Submit,"P2 Submit XBOX"},
		{Axes.P2_Cancel,"P2 Cancel XBOX"},

		{Axes.P3_Horizontal,"P3 Horizontal XBOX"},
		{Axes.P3_Vertical,"P3 Vertical XBOX"},
		//{Axes.P3_BasicAttack,"P3 Basic Attack XBOX"},
		{Axes.P3_WindSpell,"P3 Wind Spell XBOX"},
		{Axes.P3_IceSpell,"P3 Ice Spell XBOX"},
		//{Axes.P3_ElectricSpell,"P3 Electric Spell XBOX"},
		//{Axes.P3_Ultimate,"P3 Ultimate XBOX"},
		{Axes.P3_Interact,"P3 Interact XBOX"},
		{Axes.P3_Menu,"P3 Menu XBOX"},
		{Axes.P3_Submit,"P3 Submit XBOX"},
		{Axes.P3_Cancel,"P3 Cancel XBOX"},

		{Axes.P4_Horizontal,"P4 Horizontal XBOX"},
		{Axes.P4_Vertical,"P4 Vertical XBOX"},
		//{Axes.P4_BasicAttack,"P4 Basic Attack XBOX"},
		{Axes.P4_WindSpell,"P4 Wind Spell XBOX"},
		{Axes.P4_IceSpell,"P4 Ice Spell XBOX"},
		//{Axes.P4_ElectricSpell,"P4 Electric Spell XBOX"},
		//{Axes.P4_Ultimate,"P4 Ultimate XBOX"},
		{Axes.P4_Interact,"P4 Interact XBOX"},
		{Axes.P4_Menu,"P4 Menu XBOX"},
		{Axes.P4_Submit,"P4 Submit XBOX"},
		{Axes.P4_Cancel,"P4 Cancel XBOX"}
	};

	public static float GetAxis(Axes a){
		return Input.GetAxis(controlMap[a]);
	}

	public static bool GetButtonDown(Axes a){
		return Input.GetButtonDown(controlMap[a]);
	}

	public static bool GetButton(Axes a){
		return Input.GetButton(controlMap[a]);
	}
}
