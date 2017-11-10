using System.Collections;
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


	//TODO: something with player color, then have the Main Scene's GameController read the set colors (and character models?)
		// from here to instantiate player prefabs correctly.


	void MapControllers()
	{
		connected = true;
		connectMessage.SetActive(false);

		// controller mapping defaults to XBOX, so only change if PS4 controller connected
		if (Input.GetJoystickNames()[0] == "Wireless Controller") { // PS4 connection message
			InputManager.P1_Map = InputManager.P1_PS4;
			Debug.Log("P1 PS4");
		}
		else {
			InputManager.P1_Map = InputManager.P1_XBOX;
			Debug.Log("P1 XBOX");
		}

		if (Input.GetJoystickNames()[1] == "Wireless Controller"){
			InputManager.P2_Map = InputManager.P2_PS4;
			Debug.Log("P2 PS4");
		}
		else {
			InputManager.P2_Map = InputManager.P2_XBOX;
			Debug.Log("P2 XBOX");
		}

		if (Input.GetJoystickNames()[2] == "Wireless Controller"){
			InputManager.P3_Map = InputManager.P3_PS4;
			Debug.Log("P3 PS4");
		}
		else {
			InputManager.P3_Map = InputManager.P3_XBOX;
			Debug.Log("P3 XBOX");
		}

		if (Input.GetJoystickNames()[3] == "Wireless Controller"){
			InputManager.P4_Map = InputManager.P4_PS4;
			Debug.Log("P4 PS4");
		}
		else {
			InputManager.P4_Map = InputManager.P4_XBOX;
			Debug.Log("P4 XBOX");
		}
	}

	void Update()
	{
		if (Input.GetJoystickNames().Length == 1)		// when 4 controllers are detected, commence mapping
		{
			if (!connected)
			{
				MapControllers();
			}
			else
			{
				if (InputManager.GetButtonDown(InputManager.Axes.Submit, 1))
				{
					p1Ready = true;
					p1Message.text = "READY";
				}
				//if (InputManager.GetButtonDown(InputManager.Axes.Submit, 2))
				//{
				//	p2Ready = true;
				//	p2Message.text = "READY";
				//}
				//if (InputManager.GetButtonDown(InputManager.Axes.Submit, 3))
				//{
				//	p3Ready = true;
				//	p3Message.text = "READY";
				//}
				//if (InputManager.GetButtonDown(InputManager.Axes.Submit, 4))
				//{
				//	p4Ready = true;
				//	p4Message.text = "READY";
				//}
				if (p1Ready) //&& p2Ready && p3Ready && p4Ready)
				{
					//p4Message.text = "boo";
					//SceneManager.LoadScene("controller_test");
				}

			}
		}
	}
}
