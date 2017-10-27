﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RegisterPlayers : MonoBehaviour
{
	public GameObject connectMessage;
	public Text p1Message, p2Message, p3Message, p4Message;
	private bool connected = false;
	private bool p1Ready = false, p2Ready = false, p3Ready = false, p4Ready = false;

	void MapControllers()
	{
		connected = true;
		connectMessage.SetActive(false);

		// controller mapping defaults to XBox, so only change if PS4 controller connected
		if (Input.GetJoystickNames()[0] == "Wireless Controller") // PS4 connection message
		{
			InputManager.controlMap[InputManager.Axes.P1_Horizontal] = "P1 Horizontal PS4";
			InputManager.controlMap[InputManager.Axes.P1_Vertical] = "P1 Vertical PS4";
			InputManager.controlMap[InputManager.Axes.P1_WindSpell] = "P1 Wind Spell PS4";
			InputManager.controlMap[InputManager.Axes.P1_IceSpell] = "P1 Ice Spell PS4";
			InputManager.controlMap[InputManager.Axes.P1_Interact] = "P1 Interact PS4";
			InputManager.controlMap[InputManager.Axes.P1_Menu] = "P1 Menu PS4";
			InputManager.controlMap[InputManager.Axes.P1_Submit] = "P1 Submit PS4";
			InputManager.controlMap[InputManager.Axes.P1_Cancel] = "P1 Cancel PS4";
			Debug.Log("P1 remapped");
		}

		//if (Input.GetJoystickNames()[1] == "Wireless Controller")
		//{
		//	InputManager.controlMap[InputManager.Axes.P2_Horizontal] = "P2 Horizontal PS4";
		//	InputManager.controlMap[InputManager.Axes.P2_Vertical] = "P2 Vertical PS4";
		//	InputManager.controlMap[InputManager.Axes.P2_WindSpell] = "P2 Wind Spell PS4";
		//	InputManager.controlMap[InputManager.Axes.P2_IceSpell] = "P2 Ice Spell PS4";
		//	InputManager.controlMap[InputManager.Axes.P2_Interact] = "P2 Interact PS4";
		//	InputManager.controlMap[InputManager.Axes.P2_Menu] = "P2 Menu PS4";
		//	InputManager.controlMap[InputManager.Axes.P2_Submit] = "P2 Submit PS4";
		//	InputManager.controlMap[InputManager.Axes.P2_Cancel] = "P2 Cancel PS4";
		//	Debug.Log("P2 remapped");
		//}

		//if (Input.GetJoystickNames()[2] == "Wireless Controller")
		//{
		//	InputManager.controlMap[InputManager.Axes.P3_Horizontal] = "P3 Horizontal PS4";
		//	InputManager.controlMap[InputManager.Axes.P3_Vertical] = "P3 Vertical PS4";
		//	InputManager.controlMap[InputManager.Axes.P3_WindSpell] = "P3 Wind Spell PS4";
		//	InputManager.controlMap[InputManager.Axes.P3_IceSpell] = "P3 Ice Spell PS4";
		//	InputManager.controlMap[InputManager.Axes.P3_Interact] = "P3 Interact PS4";
		//	InputManager.controlMap[InputManager.Axes.P3_Menu] = "P3 Menu PS4";
		//	InputManager.controlMap[InputManager.Axes.P3_Submit] = "P3 Submit PS4";
		//	InputManager.controlMap[InputManager.Axes.P3_Cancel] = "P3 Cancel PS4";
		//	Debug.Log("P3 remapped");
		//}

		//if (Input.GetJoystickNames()[3] == "Wireless Controller")
		//{
		//	InputManager.controlMap[InputManager.Axes.P4_Horizontal] = "P4 Horizontal PS4";
		//	InputManager.controlMap[InputManager.Axes.P4_Vertical] = "P4 Vertical PS4";
		//	InputManager.controlMap[InputManager.Axes.P4_WindSpell] = "P4 Wind Spell PS4";
		//	InputManager.controlMap[InputManager.Axes.P4_IceSpell] = "P4 Ice Spell PS4";
		//	InputManager.controlMap[InputManager.Axes.P4_Interact] = "P4 Interact PS4";
		//	InputManager.controlMap[InputManager.Axes.P4_Menu] = "P4 Menu PS4";
		//	InputManager.controlMap[InputManager.Axes.P4_Submit] = "P4 Submit PS4";
		//	InputManager.controlMap[InputManager.Axes.P4_Cancel] = "P4 Cancel PS4";
		//	Debug.Log("P4 remapped");
		//}
	}

	void Update()
	{
		if (Input.GetJoystickNames().Length == 1)
		{
			if (!connected)
			{
				MapControllers();
			}
			else
			{
				if (InputManager.GetButtonDown(InputManager.Axes.P1_Submit))
				{
					p1Ready = true;
					p1Message.text = "READY";
				}
				//if (InputManager.GetButtonDown(InputManager.Axes.P2_Submit))
				//{
				//	p2Ready = true;
				//	p2Message.text = "READY";
				//}
				//if (InputManager.GetButtonDown(InputManager.Axes.P3_Submit))
				//{
				//	p3Ready = true;
				//	p3Message.text = "READY";
				//}
				//if (InputManager.GetButtonDown(InputManager.Axes.P4_Submit))
				//{
				//	p4Ready = true;
				//	p4Message.text = "READY";
				//}
				if (p1Ready) //&& p2Ready && p3Ready && p4Ready)
				{
					//p4Message.text = "boo";
					SceneManager.LoadScene("controller_test");
				}

			}
		}
	}
}
