using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BluePortal : MonoBehaviour {
    public Vector3 v_playerSpawnPosition = new Vector3(-13.25f, 0.0f, 13.44f);
    public Vector3 v_shotSpawnPosition = new Vector3(-12.25f, 0.0f, 13.44f);

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Player") {
            PlayerDidCollide(collision.collider.gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Shot") {
            ShotDidCollide(other.gameObject);
        }
    }

    public void PlayerDidCollide(GameObject player)
    {
        player.transform.position = v_playerSpawnPosition;
    }

    private void ShotDidCollide(GameObject shot)
    {
        Debug.Log("Look, a thing in blue.");
        shot.transform.position = v_shotSpawnPosition;
    }
}
