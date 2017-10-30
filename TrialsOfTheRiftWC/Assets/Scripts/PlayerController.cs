using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour{

	public InputManager.Axes ax_horizontal, ax_vertical, 
		ax_wind, ax_ice, ax_interact, ax_menu, ax_submit, ax_cancel;    // controls mapped in the InputManager for this player
	public Constants.Color e_Color;			// identifies player's team
	public int i_moveSpeed;					// basic movement speed
	public Transform t_flagPos;				// location on character model of flag
	public GameObject go_flagObj;			// flag game object; if not null, player is carrying flag
	public GameObject go_interactCollider;  // activated with button-press to pickup flag
	public Transform t_spellSpawn;			// location spells are instantiated
	public bool b_canMove;					// identifies if the player is frozen
	public GameObject go_windShot;			// wind spell object
	public GameObject go_iceShot;			// ice spell object
	public float f_spellSpeed;				// spell movement speed
    public float f_windSpeed;               // wind spell movement speed
    public float f_iceSpeed;                // ice spell movement speed
	public float f_windRecharge;			// delay between wind spells
	public float f_iceRecharge;             // delay between ice spells

	private float f_nextWind;				// time next wind spell can be cast
	private float f_nextIce;				// time next ice spell can be cast


	private void Move(){
		float f_inputX = InputManager.GetAxis(ax_horizontal);
		float f_inputZ = InputManager.GetAxis(ax_vertical);

		Vector3 v3_moveDir = new Vector3(f_inputX, 0, f_inputZ).normalized;
		if (v3_moveDir.magnitude > 0){
			transform.rotation = Quaternion.LookRotation(v3_moveDir);
		}

		GetComponent<Rigidbody>().velocity = (v3_moveDir * i_moveSpeed);

		// this vector addition here is so gravity works.
		//rb.velocity = (moveDir * walkSpeed) + new Vector3(0, -9.81f, 0);
	}

	public void Freeze(){
		b_canMove = false;
		Invoke("Unfreeze", 2f);
	}

	private void Unfreeze(){
		b_canMove = true;
	}

	private void TurnOffInteractCollider(){
		go_interactCollider.SetActive(false);
	}

	public void Pickup(GameObject flag){
		flag.transform.SetParent(t_flagPos);
		flag.transform.localPosition = new Vector3(0, 0, 0);
		go_flagObj = flag;
	}

	public void Drop(){
		if(go_flagObj){
			go_flagObj.transform.SetParent(null);
			go_flagObj = null;
		}
	}

	public Constants.Color GetColor(){
		return e_Color;
	}

	private void Start(){
		b_canMove = true;
		f_nextWind = 0;
		f_nextIce = 0;

		// TODO: Delete this once it's in GameController or wherever
		// controller mapping defaults to XBox, so only change if PS4 controller connected
		if (Input.GetJoystickNames()[0] == "Wireless Controller"){ // PS4 connection message
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
	}

	private void FixedUpdate(){
		Move();

		if (InputManager.GetButton(ax_interact)){
			go_interactCollider.SetActive(true);
			Invoke("TurnOffInteractCollider", .5f);
		}

		// spells
		if (InputManager.GetButton(ax_wind) && Time.time > f_nextWind){   // checks for fire button and if time delay has passed
			f_nextWind = Time.time + f_windRecharge;
			GameObject go_spell = Instantiate(go_windShot, t_spellSpawn.position, t_spellSpawn.rotation);
			go_spell.GetComponent<Rigidbody>().velocity = transform.forward * f_spellSpeed;
		}
		if (InputManager.GetButton(ax_ice) && Time.time > f_nextIce){   // checks for fire button and if time delay has passed
			f_nextIce = Time.time + f_iceRecharge;
			GameObject go_spell = Instantiate(go_iceShot, t_spellSpawn.position, t_spellSpawn.rotation);
			go_spell.GetComponent<Rigidbody>().velocity = transform.forward * f_spellSpeed;
		}
	}
}
