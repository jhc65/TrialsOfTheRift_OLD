using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RiftController : MonoBehaviour {

    public int power;
    int timer;
    const int maxTimer = 5;
    const int maxPower = 100;
    GameObject teleportedPlayer;
    public float offset;


	// Use this for initialization
	void Start () {
		power = 0;
        timer = maxTimer;
	}

    private void OnTriggerStay(Collider other) {
        if(other.tag == "Player" && !teleportedPlayer) {
            power++;
        }

        if (other.tag == "fire" || other.tag == "wind" || (power >= maxPower && other.tag == "Player")) {
            Teleport(other.gameObject);
        } 
    }

    void Teleport(GameObject teleport) {
        float currentOffset = offset;
        //find out rift side that's being touched.

        if (Mathf.Abs(teleport.transform.position.x) < 6) {
            currentOffset *= -1;
        }

        if (teleport.transform.position.x > 0) {
            currentOffset *= -1;
        }
        //For checking if players are trying to hop back while under the Rift timer.
        bool validTeleport = true;

        //This is for when the players are being pulled back by the rift timer.
        int nullOffset = 1;
        

        if (teleport.tag == "Player") {
             if (!teleportedPlayer) {
                //start rift pullback timer.
                TimerTick();

                //Set teleported player to drag them back.
                teleportedPlayer = teleport;
             } else {
                if (timer > 0) { 
                    //case where other player is teleported before rift timer runs out.
                    Debug.Log("Timer is not over");
                    if (!teleportedPlayer.Equals(teleport)) {
                        //SideSwitch goes here.
                        DarkMagician.GetInstance().SideSwitch();
                        teleportedPlayer = null;
                        timer = maxTimer;
                        Debug.Log("Object is the other player");
                        CancelInvoke("TimerTick");
                        power = 0;

                    } else { //case where player tries to hop back during timer. Block 'em.
                        validTeleport = false;
                        Debug.Log("Object is the same player, thus blocked.");
                    }
                } else {
                    Debug.Log("Timer is over");
                    teleportedPlayer = null;
                    nullOffset = 0;
                    power = 0;
                }

             }
        }
            
        Debug.Log("valid:" + validTeleport);
        //flip the x-axis of the player object.
        if (validTeleport) {
            teleport.transform.position = new Vector3((-1 * teleport.transform.position.x) + (currentOffset * nullOffset),
                                                    teleport.transform.position.y,
                                                    teleport.transform.position.z);
            Debug.Log("Fired off.");
            
        }
 
    }

    void TimerTick() {
        Debug.Log("Tick tick");
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
