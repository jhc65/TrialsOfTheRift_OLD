using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;
public class GameController : MonoBehaviour {

	public static GameController instance;
	public static GameController getInstance() { return instance; }

	void Awake() { instance = this; }
	public enum Side { LEFT, RIGHT };
	public enum Color { RED, BLUE };

	// The player object that is being modified
	//private PlayerController pc;

    //public GameObject redEnemy;
	//public GameObject blueEnemy;

	// Update is called once per frame
	void Update () {
        if (DarkMagician.GetInstance().enemySpawner.numLeftEnemies <= 0) {
            DarkMagician.GetInstance().leftRoom.OpenDoor();
        }

        if (DarkMagician.GetInstance().enemySpawner.numRightEnemies <= 0) {
            DarkMagician.GetInstance().rightRoom.OpenDoor();
        }
	}

    // Use this for initialization
    void Start () {
		DarkMagician.GetInstance().InitialEnemySpawn();
	}
}
