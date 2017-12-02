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
	public int i_canMove;               // identifies if the player is frozen
	public GameObject go_magicMissileShot;  // wind spell object
	public GameObject go_windShot;			// wind spell object
	public GameObject go_iceShot;           // ice spell object

	public bool isWisp = false;

    // read from Constants.cs
    //public int i_moveSpeed;                 // basic movement speed
	//public int i_wispSpeed;
	//public float f_magicMissileSpeed;		// basic attack movement speed
    //public float f_windSpeed;               // wind spell movement speed
    //public float f_iceSpeed;                // ice spell movement speed
	//public float f_magicMissileRecharge;	// delay between basic attacks
	//public float f_windRecharge;			// delay between wind spells
	//public float f_iceRecharge;             // delay between ice spells
    //public float f_iceFreeze;               // Time that ice spell freezes for.
	//public float f_projectileSize = 1f;

    private float f_nextWind;				// time next wind spell can be cast
	private float f_nextIce;                // time next ice spell can be cast
	private float f_nextMagicMissile;       // time next basic attack can be cast
    private float f_nextCast;               // time next spell in general can be cast. (not including MagicMissile)
	private float f_playerHealth;           // player's current health value
    public float f_projectileSize;          // size of player projectiles.


	private void Move() {
		float f_inputX = InputManager.GetAxis(InputManager.Axes.HORIZONTAL, i_playerNumber);
		float f_inputZ = InputManager.GetAxis(InputManager.Axes.VERTICAL, i_playerNumber);
		float f_aimInputX = InputManager.GetAxis(InputManager.Axes.AIMHORIZONTAL, i_playerNumber);
		float f_aimInputZ = InputManager.GetAxis(InputManager.Axes.AIMVERTICAL, i_playerNumber);

		Vector3 v3_moveDir = new Vector3(f_inputX, 0, f_inputZ).normalized;
		Vector3 v3_aimDir = new Vector3(f_aimInputX, 0, f_aimInputZ).normalized;

		if (v3_aimDir.magnitude > 0) {
			transform.rotation = Quaternion.LookRotation(v3_aimDir);
		}

        if (isWisp) {
			GetComponent<Rigidbody>().velocity = (v3_moveDir * Constants.PlayerStats.C_WispMovementSpeed) * i_canMove;
		}
		else {
			GetComponent<Rigidbody>().velocity = (v3_moveDir * Constants.PlayerStats.C_MovementSpeed) * i_canMove;
		}

    /*}
		else {
            GetComponent<Rigidbody>().velocity = Vector3.zero;
            GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        }
        */
	}

	public void Freeze() {
		i_canMove = 0;
		Drop();
		Invoke("Unfreeze", Constants.SpellStats.C_IceFreezeTime);
	}

	private void Unfreeze() {
		i_canMove = 1;
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
            //this value right here is where the flag is being dropped from the bug
            //tried to change it to the transform of the player, didn't really work, maybe
            //try getting player transform, but setting y to 0
			//go_flagObj.transform.localPosition = new Vector3(0.0f, -1.5f, 0.0f);	// this is relative to t_flagPos
			go_flagObj.transform.SetParent(null);
			go_flagObj.transform.localPosition = new Vector3(go_flagObj.transform.localPosition.x, 0.5f, go_flagObj.transform.localPosition.z);
			go_flagObj = null;
		}
	}

	public Constants.Color GetColor() {
		return e_Color;
	}

    private void PlayerDeath() {
		isWisp = true;
		c_playerCapsule.SetActive(false);
		c_playerWisp.SetActive(true);
		Drop();
		f_nextWind = Time.time + (Constants.PlayerStats.C_RespawnTimer + 3.0f);
        f_nextIce = Time.time + (Constants.PlayerStats.C_RespawnTimer + 3.0f);
        Invoke("PlayerRespawn", Constants.PlayerStats.C_RespawnTimer);
    }

    private void PlayerRespawn() {
		isWisp = false;
        c_playerCapsule.SetActive(true);
        c_playerWisp.SetActive(false);
        f_playerHealth = Constants.PlayerStats.C_MaxHealth;
        f_nextWind = Time.time;
        f_nextIce = Time.time;
    }

	public void TakeDamage(float damage) {
		if (!isWisp) {
			print("ow");
			f_playerHealth -= damage;
			if (f_playerHealth <= 0.0f) {
				PlayerDeath();
			}
		}
	}

	// used by UI
    public float GetNextWind() {
        return f_nextWind;
    }

    public float GetNextIce() {
        return f_nextIce;
    }

    public float GetCurrentHealth() {
        return f_playerHealth;
    }

    //public void SetCurrentHealth(float f_healthIn) {
    //    f_playerHealth = f_healthIn;
    //}

	void Start() {
        f_playerHealth = Constants.PlayerStats.C_MaxHealth;
		i_canMove = 1;

		//i_moveSpeed = Constants.PlayerStats.C_MovementSpeed;
		//f_magicMissileSpeed = Constants.SpellStats.C_MagicMissileSpeed;
		//f_windSpeed = Constants.SpellStats.C_WindSpeed;
		//f_iceSpeed = Constants.SpellStats.C_IceSpeed;

		//f_magicMissileRecharge = Constants.SpellStats.C_MagicMissileCooldown;
		//f_windRecharge = Constants.SpellStats.C_WindCooldown;
		//f_iceRecharge = Constants.SpellStats.C_IceCooldown;
        //f_iceFreeze = Constants.SpellStats.C_IceFreezeTime; 

		f_nextMagicMissile = 0;
		f_nextWind = 0;
		f_nextIce = 0;
        f_nextCast = 0;

		if (transform.position.x > 0)
			e_Side = Constants.Side.RIGHT;
		else
			e_Side = Constants.Side.LEFT;
	}

	void FixedUpdate() {
			Move();
			f_nextMagicMissile += Time.deltaTime;
			f_nextWind += Time.deltaTime;
            f_nextIce += Time.deltaTime;
            f_nextCast += Time.deltaTime;
            f_projectileSize = Constants.SpellStats.C_PlayerProjectileSize;

			// spells
			if (!go_flagObj && !isWisp) {
				// Magic Missile
				if (InputManager.GetButton(InputManager.Axes.MAGICMISSILE, i_playerNumber) && f_nextMagicMissile > Constants.SpellStats.C_MagicMissileCooldown) {   // checks for fire button and if time delay has passed
					f_nextMagicMissile = 0;
					GameObject go_spell = Instantiate(go_magicMissileShot, t_spellSpawn.position, t_spellSpawn.rotation);
					go_spell.GetComponent<SpellController>().e_color = e_Color;
					go_spell.transform.localScale = new Vector3(f_projectileSize, f_projectileSize, f_projectileSize);
					Debug.Log(transform.forward.normalized);
					go_spell.GetComponent<Rigidbody>().velocity = transform.forward * Constants.SpellStats.C_MagicMissileSpeed;
				}
				// Wind Spell
				if (InputManager.GetButton(InputManager.Axes.WINDSPELL, i_playerNumber) && f_nextWind > Constants.SpellStats.C_WindCooldown && f_nextCast > Constants.SpellStats.C_NextSpellDelay) {   // checks for fire button and if time delay has passed
					f_nextWind = 0;
                    f_nextCast = 0;
					GameObject go_spell = Instantiate(go_windShot, t_spellSpawn.position, t_spellSpawn.rotation);
					go_spell.GetComponent<SpellController>().e_color = e_Color;
					go_spell.transform.localScale = new Vector3(f_projectileSize, f_projectileSize, f_projectileSize);
					Debug.Log(transform.forward.normalized);
					go_spell.GetComponent<Rigidbody>().velocity = transform.forward * Constants.SpellStats.C_WindSpeed;
				}
				// Ice Spell
				if (InputManager.GetButton(InputManager.Axes.ICESPELL, i_playerNumber) && f_nextIce > Constants.SpellStats.C_IceCooldown && f_nextCast > Constants.SpellStats.C_NextSpellDelay) {   // checks for fire button and if time delay has passed
					f_nextIce = 0;
                    f_nextCast = 0;
					GameObject go_spell = Instantiate(go_iceShot, t_spellSpawn.position, t_spellSpawn.rotation);
					go_spell.transform.localScale = new Vector3(f_projectileSize, f_projectileSize, f_projectileSize);
					go_spell.GetComponent<SpellController>().e_color = e_Color;
					go_spell.GetComponent<Rigidbody>().velocity = transform.forward * Constants.SpellStats.C_IceSpeed;
				}
			}
	}

	void Update() {
		if (InputManager.GetButtonDown(InputManager.Axes.INTERACT, i_playerNumber) && !isWisp) {
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

	void OnTriggerEnter(Collider other) {
		if (other.tag == "Rift") {
			TakeDamage(f_playerHealth);
			transform.position = transform.position + (int)e_Side * new Vector3(-2, 0, 0);
		}
	}

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player") {
            //ignores any collision detection between any Player
            Physics.IgnoreCollision(GetComponent<Collider>(), collision.gameObject.GetComponent<Collider>());
        }
    }
}
