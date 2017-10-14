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

	public GameObject enemy;
    public GameObject doorLeft;        // left door
    public GameObject doorRight;        // right door

	public int numberOfEnemies = 10;
	private int currentEnemiesRed;
	private int currentEnemiesBlue;

    private void enemySpawn()
    {
        for (int i = 0; i < numberOfEnemies; i++)
        {
            float zPos = Random.Range(-12, 12);
            float xPos = Random.Range(3, 22);
            //Instantiate(redEnemy, new Vector3(xPos, 0.5f, zPos), new Quaternion(0, 0, 0, 0));
            //Instantiate(blueEnemy, new Vector3(-1.0f * xPos, 0.5f, zPos), new Quaternion(0, 0, 0, 0));
			Instantiate(enemy, new Vector3(xPos, 0.5f, zPos), new Quaternion(0, 0, 0, 0));
            Instantiate(enemy, new Vector3(-1.0f * xPos, 0.5f, zPos), new Quaternion(0, 0, 0, 0));
        }
    }

	// Update is called once per frame
	void Update () {

		//Check to see if there's no enemies left
		//GameObject[] BlueEnemies = GameObject.FindGameObjectsWithTag("Blue Enemy");
		//GameObject[] RedEnemies = GameObject.FindGameObjectsWithTag("Red Enemy");
		GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
		//currentEnemiesRed = RedEnemies.Length;
		//currentEnemiesBlue = BlueEnemies.Length;

		currentEnemiesRed = 0;
		currentEnemiesBlue = 0;

		for (int i = 0; i < enemies.Length; i++) {
			if (enemies[i].transform.position.x < 0) {
				currentEnemiesRed++;
			}
			else if (enemies[i].transform.position.x > 0) {
				currentEnemiesBlue++;
			}
		}
		
		if (currentEnemiesRed == 0) {
			doorLeft.SetActive(false);
		}
		
		if (currentEnemiesBlue == 0) {
			doorRight.SetActive(false);
		}
	}

    // Use this for initialization
    void Start () {
		enemySpawn();
		//pc = PlayerController.GetInstance();
	}
}
