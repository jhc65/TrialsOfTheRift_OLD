using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RiftController : MonoBehaviour {

    int power;
    int timer;
    const int maxTimer = 3;
    const int maxPower = 100;
    GameObject teleportedPlayer;
    public string side;
    public float offset;


	// Use this for initialization
	void Start () {
		power = 0;
        timer = maxTimer;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void FixedUpdate() {
        
    }

    private void OnTriggerStay(Collider other) {
        if(other.tag == "Player") {
            power++;
        }
        
        if (other.tag == "shot" || (power >= maxPower && other.tag == "Player")) {
            Teleport(other.gameObject);
        } 
    }

    void Teleport(GameObject teleport) {
        int nullOffset = 1;
        //Switch offset direction for right-side rifts
        if (side == "right") {
            offset *= -1;
        }

        if (teleport.tag == "Player") {
             if (!teleportedPlayer) {
                //start rift pullback timer.
                TimerTick();

                //Set teleported player to drag them back.
                teleportedPlayer = teleport;
             } else {
                teleportedPlayer = null;
                timer = 0;

                //Need to nullify the offset in this case, otherwise weird stuff happens.
                nullOffset = 0;
                //SideSwitch goes here.
             }
            
        }
            

        //flip the x-axis of the player object.
        teleport.transform.position = new Vector3((-1 * teleport.transform.position.x) + (offset * nullOffset),
                                                    teleport.transform.position.y,
                                                    teleport.transform.position.z);

        

    }

    void TimerTick() {
        timer--;
        if (timer <= 0) {
            if (teleportedPlayer) {
                Teleport(teleportedPlayer);
            }
            //Reset power and timer
            power = 0;
            timer = maxTimer;
        } else {
            Invoke("TimerTick",1.0f);
        }
    }
}
