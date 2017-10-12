using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController_STest : MonoBehaviour {

    public int walkSpeed;
    Rigidbody rb;
    float inputX;
    float inputZ;
    Vector3 moveDir;
    Vector3 lastAngle;
    Quaternion rotation;

    [SerializeField]GameObject shot = null;
    [SerializeField]int timeToFire = 30;

	// Use this for initialization
	void Start () {
		rb = gameObject.GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {

        inputX = Input.GetAxisRaw("Horizontal");
        inputZ = Input.GetAxisRaw("Vertical");
        moveDir = new Vector3(inputX, 0, inputZ).normalized;
        if (!moveDir.Equals(Vector3.zero)) {
            lastAngle = moveDir;
        }
        // This vector addition here is so gravity works.
        rb.velocity = (moveDir * walkSpeed) + new Vector3(0,-9.81f,0);

        timeToFire--;
        if(Input.GetKeyDown(KeyCode.Space) && timeToFire <= 0) {
            GameObject bullet = Instantiate(shot);
            bullet.transform.position = transform.position + (lastAngle * 0.5f);
            bullet.GetComponent<Rigidbody>().velocity = lastAngle * 30;
            timeToFire = 30;
        }
        
		
	}

    public string GetSide() {
        if (transform.position.x < 0) {
            return "left";
        } else {
            return "right";
        }
    }
}
