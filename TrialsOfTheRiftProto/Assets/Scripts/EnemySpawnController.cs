using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnController : MonoBehaviour {

    [SerializeField]GameObject enemy;
    [SerializeField]GameObject debugplayer;

    public GameObject[] leftEnemies = new GameObject[10];
    public GameObject[] rightEnemies = new GameObject[10];

    public int numLeftEnemies;
    public int numRightEnemies;

	// Use this for initialization
	void Start () {
		//Spawn(debugplayer);
	}
	
	// Update is called once per frame
	public void Spawn(GameObject targetPlayer) {
        PlayerController_STest pc = targetPlayer.GetComponent<PlayerController_STest>();

        if (pc.GetSide() == "left") {
            for(int i = 0; i < 10; i++) {
                //Spawn one enemy with default rotation.
                float Xbound = Random.Range(-20.8f, -4.35f);
                float Zbound = Random.Range(-13.54f, 13.55f);
                GameObject newmeat = Instantiate(enemy, new Vector3(Xbound, 1, Zbound), Quaternion.identity);
                leftEnemies[i] = newmeat;
                newmeat.GetComponent<EnemyController_Stest>().SetPlayer(pc.gameObject);
            }
            numLeftEnemies = 10;
        } else {
            for(int i = 0; i < 10; i++) {
                //Spawn one enemy with default rotation.
                float Xbound = Random.Range(4.19f, 20.66f);
                float Zbound = Random.Range(-13.54f, 13.55f);
                GameObject newmeat = Instantiate(enemy, new Vector3(Xbound, 1, Zbound), Quaternion.identity);
                rightEnemies[i] = newmeat;
                newmeat.GetComponent<EnemyController_Stest>().SetPlayer(pc.gameObject);
            }
            numRightEnemies = 10;
        }
    }
}
