using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnController : MonoBehaviour {

    [SerializeField]GameObject enemy;
    [SerializeField]GameObject debugplayer;

    GameObject[] leftEnemies = new GameObject[10];
    GameObject[] rightEnemies = new GameObject[10];

    public int numLeftEnemies;
    int numRightEnemies;

	// Use this for initialization
	void Start () {
		Spawn(debugplayer);
	}
	
	// Update is called once per frame
	void Spawn(GameObject targetPlayer) {
        PlayerController_STest pc = targetPlayer.GetComponent<PlayerController_STest>();

        if (pc.GetSide() == "left") {
            for(int i = 0; i < 10; i++) {
                //Spawn one enemy with default rotation.
                float Xbound = Random.Range(-20.8f, -4.35f);
                float Zbound = Random.Range(-13.54f, 13.55f);
                GameObject newmeat = Instantiate(enemy, new Vector3(Xbound, 1, Zbound), Quaternion.identity);
                leftEnemies[i] = newmeat;
            }
            numLeftEnemies = 10;
        } else {
            for(int i = 0; i < 10; i++) {
                //Spawn one enemy with default rotation.
                float Xbound = Random.Range(4.19f, 20.66f);
                float Zbound = Random.Range(-13.54f, 13.55f);
                GameObject newmeat = Instantiate(enemy, new Vector3(Xbound, 1, Zbound), Quaternion.identity);
                rightEnemies[i] = newmeat;
            }
            numRightEnemies = 10;
        }
    }
}
