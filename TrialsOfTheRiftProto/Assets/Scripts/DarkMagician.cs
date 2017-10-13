using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarkMagician : MonoBehaviour {

    [SerializeField]GameObject player1;
    [SerializeField]GameObject player2;
    [SerializeField]EnemySpawnController enemySpawner;
    [SerializeField]RoomController leftRoom;
    [SerializeField]RoomController rightRoom;

    // Create a single instance of this class to be referenced throught the project
    static DarkMagician instance;

    protected void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

        if (instance != null && instance != this)
        {
            Debug.Log("Destroying non-primary DM.");
            Destroy(this);
        }
    }

	// Use this for initialization
	void Start () {
		//InitialEnemySpawn();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public static DarkMagician GetInstance() {
        return instance;
    }

    public void EnemyKilled(string side) {
        if (side == "left") {
            enemySpawner.numLeftEnemies--;
        } else {
            enemySpawner.numRightEnemies--;
        }
    }

    public void InitialEnemySpawn() {
        enemySpawner.Spawn(player1);
        enemySpawner.Spawn(player2);
    }

    public void SideSwitch() {
        //swap color (ownership)
        leftRoom.SwapColor();
        rightRoom.SwapColor();

        //Then swap enemy targets based on where the player is now.
        if (player1.GetComponent<PlayerController_STest>().GetSide() == "left") {
            foreach(GameObject go in enemySpawner.leftEnemies) {
                if (go != null) {
                    go.GetComponent<EnemyController_Stest>().SetPlayer(player1);
                }
            }

            foreach(GameObject go in enemySpawner.rightEnemies) {
                if (go != null) {
                    go.GetComponent<EnemyController_Stest>().SetPlayer(player2);
                }
            }
        } else {
            foreach(GameObject go in enemySpawner.leftEnemies) {
                if (go != null) {
                    go.GetComponent<EnemyController_Stest>().SetPlayer(player2);
                }
            }

            foreach(GameObject go in enemySpawner.rightEnemies) {
                if (go != null) {
                    go.GetComponent<EnemyController_Stest>().SetPlayer(player1);
                }
            }
        }
    }

    public void RoomAdvance(GameObject player) {
        enemySpawner.Spawn(player);
        if (player.GetComponent<PlayerController_STest>().GetSide() == "left") {
            leftRoom.index++;
        } else {
            rightRoom.index++;
        }
    }
}
