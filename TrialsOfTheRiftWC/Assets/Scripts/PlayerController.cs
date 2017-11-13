using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour{

	public GameObject c_playerCapsule;      // player main body
	public GameObject c_playerWisp;         // player wisp body
	public int i_playerNumber;				// designates player's number for controller mappings
	public Constants.Color e_Color;			// identifies player's team
	public Constants.Side e_Side;			// identifies which side of the rift player is on
	public Transform t_flagPos;				// location on character model of flag
	public GameObject go_flagObj;			// flag game object; if not null, player is carrying flag
	public GameObject go_interactCollider;  // activated with button-press to pickup flag
	public Transform t_spellSpawn;			// location spells are instantiated
	public bool b_canMove;                  // identifies if the player is frozen
	public GameObject go_magicMissileShot;  // wind spell object
	public GameObject go_windShot;			// wind spell object
	public GameObject go_iceShot;           // ice spell object

	// read from Constants.cs
	public int i_moveSpeed;                 // basic movement speed
	public float f_magicMissileSpeed;		// basic attack movement speed
    public float f_windSpeed;               // wind spell movement speed
    public float f_iceSpeed;                // ice spell movement speed
	public float f_magicMissileRecharge;	// delay between basic attacks
	public float f_windRecharge;			// delay between wind spells
	public float f_iceRecharge;             // delay between ice spells

    private float f_nextWind;				// time next wind spell can be cast
	private float f_nextIce;                // time next ice spell can be cast
	private float f_nextMagicMissile;       // time next basic attack can be cast
	private float f_playerHealth;           // player's current health value


	private void Move() {
		float f_inputX = InputManager.GetAxis(InputManager.Axes.HORIZONTAL, i_playerNumber);
		float f_inputZ = InputManager.GetAxis(InputManager.Axes.VERTICAL, i_playerNumber);

		Vector3 v3_moveDir = new Vector3(f_inputX, 0, f_inputZ).normalized;
		if (v3_moveDir.magnitude > 0) {
			transform.rotation = Quaternion.LookRotation(v3_moveDir);
		}

        if (b_canMove) { // lock player in place proper
            GetComponent<Rigidbody>().velocity = (v3_moveDir * i_moveSpeed);
        }
		else {
            GetComponent<Rigidbody>().velocity = Vector3.zero;
        }
	}

	public void Freeze() {
		b_canMove = false;
		Drop();
		Invoke("Unfreeze", 2f);
	}

	private void Unfreeze() {
		b_canMove = true;
	}

	private void TurnOffInteractCollider() {
		go_interactCollider.SetActive(false);
	}

	public void Pickup(GameObject flag) {
		flag.transform.SetParent(t_flagPos);
		flag.transform.localPosition = new Vector3(0, 0, 0);
		go_flagObj = flag;
	}

	public void Drop() {
		if(go_flagObj) {
			go_flagObj.transform.localPosition = new Vector3(0, -1.5f, 0);	// this is relative to t_flagPos
			go_flagObj.transform.SetParent(null);
			go_flagObj = null;
		}
	}

	public Constants.Color GetColor() {
		return e_Color;
	}

    private void PlayerDeath() {
		c_playerCapsule.SetActive(false);
		c_playerWisp.SetActive(true);
		Drop();
		i_moveSpeed = Constants.PlayerStats.C_WispMovementSpeed;
		f_nextWind = Time.time + (Constants.PlayerStats.C_RespawnTimer + 3.0f);
        f_nextIce = Time.time + (Constants.PlayerStats.C_RespawnTimer + 3.0f);
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

	public void TakeDamage(float damage) {
		if (!(f_playerHealth <= 0.0f)){
			print("ow");
			f_playerHealth -= damage;
			if (f_playerHealth <= 0.0f){
				PlayerDeath();
			}
		}
	}

    public float GetNextWind() {
        return f_nextWind;
    }

    public float GetNextIce() {
        return f_nextIce;
    }

    public float GetCurrentHealth() {
        return f_playerHealth;
    }

	void Start() {
        f_playerHealth = Constants.PlayerStats.C_MaxHealth;
		b_canMove = true;

		i_moveSpeed = Constants.PlayerStats.C_MovementSpeed;
		f_magicMissileSpeed = Constants.SpellStats.C_MagicMissileSpeed;
		f_windSpeed = Constants.SpellStats.C_WindSpeed;
		f_iceSpeed = Constants.SpellStats.C_IceSpeed;

		f_magicMissileRecharge = Constants.SpellStats.C_MagicMissileCooldown;
		f_windRecharge = Constants.SpellStats.C_WindCooldown;
		f_iceRecharge = Constants.SpellStats.C_IceCooldown;

		f_nextMagicMissile = 0;
		f_nextWind = 0;
		f_nextIce = 0;

		if (transform.position.x > 0)
			e_Side = Constants.Side.RIGHT;
		else
			e_Side = Constants.Side.LEFT;
	}

	void FixedUpdate() {
		if (b_canMove) {
			Move();
			f_nextMagicMissile += Time.deltaTime;
			f_nextWind += Time.deltaTime;
            f_nextIce += Time.deltaTime;

			// spells
			if (!go_flagObj && !c_playerWisp.activeSelf) {
				if (InputManager.GetButton(InputManager.Axes.MAGICMISSILE, i_playerNumber) && f_nextMagicMissile > f_magicMissileRecharge) {   // checks for fire button and if time delay has passed
					f_nextMagicMissile = 0;
					GameObject go_spell = Instantiate(go_magicMissileShot, t_spellSpawn.position, t_spellSpawn.rotation);
					go_spell.GetComponent<SpellController>().e_color = e_Color;
					Debug.Log(transform.forward.normalized);
					go_spell.GetComponent<Rigidbody>().velocity = transform.forward * f_magicMissileSpeed;
				}
				if (InputManager.GetButton(InputManager.Axes.WINDSPELL, i_playerNumber) && f_nextWind > f_windRecharge) {   // checks for fire button and if time delay has passed
					f_nextWind = 0;
					GameObject go_spell = Instantiate(go_windShot, t_spellSpawn.position, t_spellSpawn.rotation);
					go_spell.GetComponent<SpellController>().e_color = e_Color;
					Debug.Log(transform.forward.normalized);
					go_spell.GetComponent<Rigidbody>().velocity = transform.forward * f_windSpeed;
				}
				if (InputManager.GetButton(InputManager.Axes.ICESPELL, i_playerNumber) && f_nextIce > f_iceRecharge) {   // checks for fire button and if time delay has passed
					f_nextIce = 0;
					GameObject go_spell = Instantiate(go_iceShot, t_spellSpawn.position, t_spellSpawn.rotation);
					go_spell.GetComponent<SpellController>().e_color = e_Color;
					go_spell.GetComponent<Rigidbody>().velocity = transform.forward * f_iceSpeed;
				}
			}
		}
	}

	void Update() {
		if (InputManager.GetButtonDown(InputManager.Axes.INTERACT, i_playerNumber)) {
			if (go_flagObj) {
				Drop();
			}
			else {
				go_interactCollider.SetActive(true);
				Invoke("TurnOffInteractCollider", .5f);
			}
		}
		
		if (transform.position.x > 0)
			e_Side = Constants.Side.RIGHT;
		else
			e_Side = Constants.Side.LEFT;
	}

	void OnTriggerEnter(Collider other){
		if (other.tag == "Rift") {
			f_playerHealth = 0.0f;
			PlayerDeath();
		}
	}
}
