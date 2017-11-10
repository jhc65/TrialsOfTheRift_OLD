using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class InputManager{

	public enum Axes{
		Horizontal, Vertical,
		//BasicAttack,
		WindSpell, IceSpell,
		//ElectricSpell,
		//Ultimate,
		Interact,
		Menu, Submit, Cancel
	}

	public static Dictionary<Axes, string> P1_XBOX = new Dictionary<Axes, string> {
		{Axes.Horizontal,"P1 Horizontal XBOX"},
		{Axes.Vertical,"P1 Vertical XBOX"},
		//{Axes.BasicAttack,"P1 Basic Attack XBOX"},
		{Axes.WindSpell,"P1 Wind Spell XBOX"},
		{Axes.IceSpell,"P1 Ice Spell XBOX"},
		//{Axes.ElectricSpell,"P1 Electric Spell XBOX"},
		//{Axes.Ultimate,"P1 Ultimate XBOX"},
		{Axes.Interact,"P1 Interact XBOX"},
		{Axes.Menu,"P1 Menu XBOX"},
		{Axes.Submit,"P1 Submit XBOX"},
		{Axes.Cancel,"P1 Cancel XBOX"}
	};

	public static Dictionary<Axes, string> P2_XBOX = new Dictionary<Axes, string> {
		{Axes.Horizontal,"P2 Horizontal XBOX"},
		{Axes.Vertical,"P2 Vertical XBOX"},
		//{Axes.BasicAttack,"P2 Basic Attack XBOX"},
		{Axes.WindSpell,"P2 Wind Spell XBOX"},
		{Axes.IceSpell,"P2 Ice Spell XBOX"},
		//{Axes.ElectricSpell,"P2 Electric Spell XBOX"},
		//{Axes.Ultimate,"P2 Ultimate XBOX"},
		{Axes.Interact,"P2 Interact XBOX"},
		{Axes.Menu,"P2 Menu XBOX"},
		{Axes.Submit,"P2 Submit XBOX"},
		{Axes.Cancel,"P2 Cancel XBOX"}
	};

	public static Dictionary<Axes, string> P3_XBOX = new Dictionary<Axes, string> {
		{Axes.Horizontal,"P3 Horizontal XBOX"},
		{Axes.Vertical,"P3 Vertical XBOX"},
		//{Axes.BasicAttack,"P3 Basic Attack XBOX"},
		{Axes.WindSpell,"P3 Wind Spell XBOX"},
		{Axes.IceSpell,"P3 Ice Spell XBOX"},
		//{Axes.ElectricSpell,"P3 Electric Spell XBOX"},
		//{Axes.Ultimate,"P3 Ultimate XBOX"},
		{Axes.Interact,"P3 Interact XBOX"},
		{Axes.Menu,"P3 Menu XBOX"},
		{Axes.Submit,"P3 Submit XBOX"},
		{Axes.Cancel,"P3 Cancel XBOX"}
	};

	public static Dictionary<Axes, string> P4_XBOX = new Dictionary<Axes, string> {
		{Axes.Horizontal,"P4 Horizontal XBOX"},
		{Axes.Vertical,"P4 Vertical XBOX"},
		//{Axes.BasicAttack,"P4 Basic Attack XBOX"},
		{Axes.WindSpell,"P4 Wind Spell XBOX"},
		{Axes.IceSpell,"P4 Ice Spell XBOX"},
		//{Axes.ElectricSpell,"P4 Electric Spell XBOX"},
		//{Axes.Ultimate,"P4 Ultimate XBOX"},
		{Axes.Interact,"P4 Interact XBOX"},
		{Axes.Menu,"P4 Menu XBOX"},
		{Axes.Submit,"P4 Submit XBOX"},
		{Axes.Cancel,"P4 Cancel XBOX"}
	};

	public static Dictionary<Axes, string> P1_PS4 = new Dictionary<Axes, string> {
		{Axes.Horizontal,"P1 Horizontal PS4"},
		{Axes.Vertical,"P1 Vertical PS4"},
		//{Axes.BasicAttack,"P1 Basic Attack PS4"},
		{Axes.WindSpell,"P1 Wind Spell PS4"},
		{Axes.IceSpell,"P1 Ice Spell PS4"},
		//{Axes.ElectricSpell,"P1 Electric Spell PS4"},
		//{Axes.Ultimate,"P1 Ultimate PS4"},
		{Axes.Interact,"P1 Interact PS4"},
		{Axes.Menu,"P1 Menu PS4"},
		{Axes.Submit,"P1 Submit PS4"},
		{Axes.Cancel,"P1 Cancel PS4"}
	};

	public static Dictionary<Axes, string> P2_PS4 = new Dictionary<Axes, string> {
		{Axes.Horizontal,"P2 Horizontal PS4"},
		{Axes.Vertical,"P2 Vertical PS4"},
		//{Axes.BasicAttack,"P2 Basic Attack PS4"},
		{Axes.WindSpell,"P2 Wind Spell PS4"},
		{Axes.IceSpell,"P2 Ice Spell PS4"},
		//{Axes.ElectricSpell,"P2 Electric Spell PS4"},
		//{Axes.Ultimate,"P2 Ultimate PS4"},
		{Axes.Interact,"P2 Interact PS4"},
		{Axes.Menu,"P2 Menu PS4"},
		{Axes.Submit,"P2 Submit PS4"},
		{Axes.Cancel,"P2 Cancel PS4"}
	};

	public static Dictionary<Axes, string> P3_PS4 = new Dictionary<Axes, string> {
		{Axes.Horizontal,"P3 Horizontal PS4"},
		{Axes.Vertical,"P3 Vertical PS4"},
		//{Axes.BasicAttack,"P3 Basic Attack PS4"},
		{Axes.WindSpell,"P3 Wind Spell PS4"},
		{Axes.IceSpell,"P3 Ice Spell PS4"},
		//{Axes.ElectricSpell,"P3 Electric Spell PS4"},
		//{Axes.Ultimate,"P3 Ultimate PS4"},
		{Axes.Interact,"P3 Interact PS4"},
		{Axes.Menu,"P3 Menu PS4"},
		{Axes.Submit,"P3 Submit PS4"},
		{Axes.Cancel,"P3 Cancel PS4"}
	};

	public static Dictionary<Axes, string> P4_PS4 = new Dictionary<Axes, string> {
		{Axes.Horizontal,"P4 Horizontal PS4"},
		{Axes.Vertical,"P4 Vertical PS4"},
		//{Axes.BasicAttack,"P4 Basic Attack PS4"},
		{Axes.WindSpell,"P4 Wind Spell PS4"},
		{Axes.IceSpell,"P4 Ice Spell PS4"},
		//{Axes.ElectricSpell,"P4 Electric Spell PS4"},
		//{Axes.Ultimate,"P4 Ultimate PS4"},
		{Axes.Interact,"P4 Interact PS4"},
		{Axes.Menu,"P4 Menu PS4"},
		{Axes.Submit,"P4 Submit PS4"},
		{Axes.Cancel,"P4 Cancel PS4"}
	};


	public static Dictionary<Axes, string> P1_Map = P1_PS4;		// P1, P2 default to PS4 for easier testing
	public static Dictionary<Axes, string> P2_Map = P2_PS4;
	public static Dictionary<Axes, string> P3_Map = P3_XBOX;	// P3, P4 default to XBOX to share the keyboard map
	public static Dictionary<Axes, string> P4_Map = P4_XBOX;


	public static float GetAxis(Axes a, int player){
		switch(player){
			case 1:
				return Input.GetAxis(P1_Map[a]);
			case 2:
				return Input.GetAxis(P2_Map[a]);
			case 3:
				return Input.GetAxis(P3_Map[a]);
			case 4:
				return Input.GetAxis(P4_Map[a]);
			default:
				return 0;	// unreachable
		}
	}

	public static bool GetButtonDown(Axes a, int player){
		switch (player){
			case 1:
				return Input.GetButtonDown(P1_Map[a]);
			case 2:
				return Input.GetButtonDown(P2_Map[a]);
			case 3:
				return Input.GetButtonDown(P3_Map[a]);
			case 4:
				return Input.GetButtonDown(P4_Map[a]);
			default:
				return false;	// unreachable
		}
	}

	public static bool GetButton(Axes a, int player){
		switch (player){
			case 1:
				return Input.GetButton(P1_Map[a]);
			case 2:
				return Input.GetButton(P2_Map[a]);
			case 3:
				return Input.GetButton(P3_Map[a]);
			case 4:
				return Input.GetButton(P4_Map[a]);
			default:
				return false;	// unreachable
		}
	}
}
