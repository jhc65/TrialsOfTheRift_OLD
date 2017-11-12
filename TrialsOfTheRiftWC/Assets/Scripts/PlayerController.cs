﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour{

	public int i_playerNumber;				// designates player's number for controller mappings
	public Constants.Color e_Color;			// identifies player's team
	public Constants.Side e_Side;			// identifies which side of the rift player is on
	public int i_moveSpeed;					// basic movement speed
	public Transform t_flagPos;				// location on character model of flag
	public GameObject go_flagObj;			// flag game object; if not null, player is carrying flag
	public GameObject go_interactCollider;  // activated with button-press to pickup flag
	public Transform t_spellSpawn;			// location spells are instantiated
	public bool b_canMove;					// identifies if the player is frozen
	public GameObject go_windShot;			// wind spell object
	public GameObject go_iceShot;			// ice spell object

    //In Constants
	public float f_spellSpeed;				// spell movement speed
    public float f_windSpeed;               // wind spell movement speed
    public float f_iceSpeed;                // ice spell movement speed
	public float f_windRecharge;			// delay between wind spells
	public float f_iceRecharge;             // delay between ice spells
    public GameObject c_playerCapsule;     // Player main body
    public GameObject c_playerWisp;        // Player wisp body

    private float f_nextWind;				// time next wind spell can be cast
	private float f_nextIce;				// time next ice spell can be cast
    private float f_playerHealth;           // Players current health value


	private void Move(){
		float f_inputX = InputManager.GetAxis(InputManager.Axes.HORIZONTAL, i_playerNumber);
		float f_inputZ = InputManager.GetAxis(InputManager.Axes.VERTICAL, i_playerNumber);

		Vector3 v3_moveDir = new Vector3(f_inputX, 0, f_inputZ).normalized;
		if (v3_moveDir.magnitude > 0){
			transform.rotation = Quaternion.LookRotation(v3_moveDir);
		}

        if (b_canMove) { // Lock player in place proper.
            GetComponent<Rigidbody>().velocity = (v3_moveDir * i_moveSpeed);
        } else {
            GetComponent<Rigidbody>().velocity = Vector3.zero;
        }

		// this vector addition here is so gravity works.
		//rb.velocity = (moveDir * walkSpeed) + new Vector3(0, -9.81f, 0);
	}

	public void Freeze(){
		b_canMove = false;
		Drop();
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
			go_flagObj.transform.localPosition = new Vector3(0, -1.5f, 0);	// this is relative to t_flagPos
			go_flagObj.transform.SetParent(null);
			go_flagObj = null;
		}
	}

    public void DoDamage(float damageIn){
        f_playerHealth -= damageIn;
    }

	public Constants.Color GetColor(){
		return e_Color;
	}

    private void PlayerDeath() {
        f_nextWind = Time.time + (Constants.PlayerStats.C_RespawnTimer + 3.0f);
        f_nextIce = Time.time + (Constants.PlayerStats.C_RespawnTimer + 3.0f);
        c_playerCapsule.SetActive(false);
        Drop();
        c_playerWisp.SetActive(true);
        i_moveSpeed = Constants.PlayerStats.C_WispMovementSpeed;
        Invoke("PlayerRespawn", Constants.PlayerStats.C_RespawnTimer);
    }

    private void PlayerRespawn() {
        c_playerCapsule.SetActive(true);
        c_playerWisp.SetActive(false);
        f_playerHealth = Constants.PlayerStats.C_MaxHealth;
        i_moveSpeed = Constants.PlayerStats.C_MovementSpeed;
        f_nextWind = Time.time;
        f_nextIce = Time.time;
    }

	private void Start(){
        f_playerHealth = Constants.PlayerStats.C_MaxHealth;
		b_canMove = true;
        i_moveSpeed = Constants.PlayerStats.C_MovementSpeed;
		f_nextWind = 0;
		f_nextIce = 0;
		if (transform.position.x > 0)
			e_Side = Constants.Side.RIGHT;
		else
			e_Side = Constants.Side.LEFT;
	}

	private void FixedUpdate(){
		if (b_canMove){
			Move();
            f_nextWind += Time.deltaTime;
            f_nextIce += Time.deltaTime;

			// spells
			if (!go_flagObj){
				if (InputManager.GetButton(InputManager.Axes.WINDSPELL, i_playerNumber) && f_nextWind > f_windRecharge){   // checks for fire button and if time delay has passed
					f_nextWind = 0;
					GameObject go_spell = Instantiate(go_windShot, t_spellSpawn.position, t_spellSpawn.rotation);
					go_spell.GetComponent<SpellController>().e_color = e_Color;
					Debug.Log(transform.forward.normalized);
					go_spell.GetComponent<Rigidbody>().velocity = transform.forward * f_spellSpeed;
				}
				if (InputManager.GetButton(InputManager.Axes.ICESPELL, i_playerNumber) && f_nextIce > f_iceRecharge){   // checks for fire button and if time delay has passed
					f_nextIce = 0;
					GameObject go_spell = Instantiate(go_iceShot, t_spellSpawn.position, t_spellSpawn.rotation);
					go_spell.GetComponent<SpellController>().e_color = e_Color;
					go_spell.GetComponent<Rigidbody>().velocity = transform.forward * f_spellSpeed;
				}
			}
		}
	}

	private void Update(){
        if (f_playerHealth <= 0.0f) {
            PlayerDeath();
        }
		if (InputManager.GetButtonDown(InputManager.Axes.INTERACT, i_playerNumber)){
			if (go_flagObj){
				Drop();
			}
			else{
				go_interactCollider.SetActive(true);
				Invoke("TurnOffInteractCollider", .5f);
			}
		}
		
		if (transform.position.x > 0)
			e_Side = Constants.Side.RIGHT;
		else
			e_Side = Constants.Side.LEFT;
	}
	
	public void TakeDamage(float damage){
		print("ow");
	}

    public float GetNextWind() {
        return f_nextWind;
    }

    public float GetNextIce() {
        return f_nextIce;
    }
}
