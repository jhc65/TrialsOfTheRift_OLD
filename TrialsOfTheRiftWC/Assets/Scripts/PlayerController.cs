using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour{

	public int i_playerNumber;				// designates player's number for controller mappings
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

	public Constants.Color GetColor(){
		return e_Color;
	}

	private void Start(){
		b_canMove = true;
		f_nextWind = 0;
		f_nextIce = 0;
	}

	private void FixedUpdate(){
		if (b_canMove){
			Move();

			// spells
			if (!go_flagObj){
				if (InputManager.GetButton(InputManager.Axes.WINDSPELL, i_playerNumber) && Time.time > f_nextWind){   // checks for fire button and if time delay has passed
					f_nextWind = Time.time + f_windRecharge;
					GameObject go_spell = Instantiate(go_windShot, t_spellSpawn.position, t_spellSpawn.rotation);
					go_spell.GetComponent<SpellController>().e_color = e_Color;
					Debug.Log(transform.forward.normalized);
					go_spell.GetComponent<Rigidbody>().velocity = transform.forward * f_spellSpeed;
				}
				if (InputManager.GetButton(InputManager.Axes.ICESPELL, i_playerNumber) && Time.time > f_nextIce){   // checks for fire button and if time delay has passed
					f_nextIce = Time.time + f_iceRecharge;
					GameObject go_spell = Instantiate(go_iceShot, t_spellSpawn.position, t_spellSpawn.rotation);
					go_spell.GetComponent<SpellController>().e_color = e_Color;
					go_spell.GetComponent<Rigidbody>().velocity = transform.forward * f_spellSpeed;
				}
			}
		}
	}

	private void Update(){
		if (InputManager.GetButtonDown(InputManager.Axes.INTERACT, i_playerNumber)){
			if (go_flagObj){
				Drop();
			}
			else{
				go_interactCollider.SetActive(true);
				Invoke("TurnOffInteractCollider", .5f);
			}
		}
	}
}
