using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarkMagician : MonoBehaviour {

    [SerializeField]GameObject player1;
    [SerializeField]GameObject player2;
    [SerializeField]public EnemySpawnController enemySpawner;
    [SerializeField]public RoomController leftRoom;
    [SerializeField]public RoomController rightRoom;

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
            if (enemySpawner.numLeftEnemies <= 0) {
                leftRoom.OpenDoor();
            }
        } else {
            enemySpawner.numRightEnemies--;
            if (enemySpawner.numRightEnemies <= 0) {
                rightRoom.OpenDoor();
            }
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
        //Reset player's position and advance numbers.
        PlayerController_STest pc = player.GetComponent<PlayerController_STest>();
        if (pc.GetSide() == "left") {
            player.transform.position = new Vector3(-12.62f,1f,-11.32f);
            leftRoom.index++;
            leftRoom.CloseDoor();
        } else {
            player.transform.position = new Vector3(12.62f,1f,-11.32f);
            rightRoom.index++;
            rightRoom.CloseDoor();
        }
        
        //Then spawn enemies.
        enemySpawner.Spawn(player);
    }
}
