using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControlsTest : MonoBehaviour {

	public Text t;
	public int playerNum;
	public InputManager.Axes horizontal, vertical, wind, ice, interact, menu, submit, cancel;

	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	//void Update()
	//{
	//	float speed = 10.0F;
	//	float h = speed * InputManager.GetAxis(horizontal);
	//	float v = speed * InputManager.GetAxis(vertical);
	//	t.transform.Translate(h, v, 0);

	//	if (InputManager.GetButtonDown(wind))
	//	{
	//		t.text = "P" + playerNum + " wind";
	//	}
	//	if (InputManager.GetButtonDown(ice))
	//	{
	//		t.text = "P" + playerNum + " ice";
	//	}
	//	if (InputManager.GetButtonDown(interact))
	//	{
	//		t.text = "P" + playerNum + " interact";
	//	}
	//	if (InputManager.GetButtonDown(menu))
	//	{
	//		t.text = "P" + playerNum + " menu";
	//	}
	//	if (InputManager.GetButtonDown(submit))
	//	{
	//		t.text = "P" + playerNum + " submit";
	//	}
	//	if (InputManager.GetButtonDown(cancel))
	//	{
	//		t.text = "P" + playerNum + " cancel";
	//	}
	//}

}
