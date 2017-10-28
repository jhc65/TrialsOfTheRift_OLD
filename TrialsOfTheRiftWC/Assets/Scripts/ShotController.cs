using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(SphereCollider))]
abstract public class ShotController : MonoBehaviour {
	
	public Constants.Color e_Color;	//Currently does nothing. I'd like to use this to differentiate friendly fire.
	public float f_damage;		// Damage of the bullet. Currently 0 for the demo.
	public float f_liveTime = 2f;
	public float f_tickRate = 0.1f;
	
	protected Rigidbody r_rigidbody;
	
	protected void Awake() {
        Invoke("TimerTick", f_tickRate);
    }
	
	protected void TimerTick() {
        f_liveTime--;
        if (f_liveTime <= 0) {
            Destroy(gameObject);
        } else {
            Invoke("TimerTick",1.0f);
        }
    }
	
	protected void Start(){
		// I'd like to set e_Color from PlayerController here.
		r_rigidbody = GetComponent<Rigidbody>();
	}

	// If a player walks into a shot, apply that shot's effect and then destroy the shot.
	protected void OnTriggerEnter(Collider coll){
		if(coll.gameObject.tag == "Player"){ //Add enemy tag too once it's needed.
			ApplyEffect(coll.gameObject);
			Destroy(gameObject);
		}
		else if(coll.gameObject.tag != "Rift") // If we hit something not a player (walls), just destroy the shot without an effect.
			Destroy(gameObject);
	}
	
	protected abstract void ApplyEffect(GameObject go_target);
}
