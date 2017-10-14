using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotController : MonoBehaviour {

    public float pushTime = 0.75f;
    public float liveTime = 2;
    public float tickRate = 0.1f;

    private void Awake() {
        Invoke("TimerTick", tickRate);
    }

    public void OnCollisionEnter(Collision collision)
    {
        string tag = this.gameObject.tag;

        //collisions where things should be let free: rifts
        //collisions that should instant kill shot: players (do nothing)[done], fire -> enemies (kill said enemy) [done], walls
        //collisions that don't IK: wind -> anything (shove for some time and then kill the shot) [done]
        if (collision.gameObject.tag == "enemy")
        {
            if (tag == "fire")
            {

                if (transform.position.x < 0) {
                    DarkMagician.GetInstance().EnemyKilled("left");
                } else {
                    DarkMagician.GetInstance().EnemyKilled("right");
                }
                //Kill enemy here.
                Destroy(collision.gameObject);
                CancelInvoke("TimerTick");
                Destroy(this.gameObject);

            }
        } else if (collision.gameObject.tag == "Player") {
            if (tag == "wind") {
                //Start timer for wind death.
                StartCoroutine(ExecuteAfterTime());
            } else {
                //Fireballs don't do anything to players... yet.
                Destroy(this.gameObject);
            }    
        }
    }

    //resets enemy velocity after some time, so it isn't pushed forever
    public IEnumerator ExecuteAfterTime()
    {
        yield return new WaitForSeconds(pushTime);
        CancelInvoke("TimerTick");
        Destroy(this.gameObject);
    }

    void TimerTick() {
        liveTime--;
        if (liveTime <= 0) {
            Destroy(this.gameObject);
        } else {
            Invoke("TimerTick",1.0f);
        }
    }
}
