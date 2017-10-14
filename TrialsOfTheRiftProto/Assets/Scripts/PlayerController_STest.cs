using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController_STest : MonoBehaviour {

    public string color;
    public int walkSpeed;
    Rigidbody rb;
    float inputX;
    float inputZ;
    Vector3 moveDir;
    Vector3 lastAngle;
    Quaternion rotation;

    [SerializeField]GameObject wind = null;
    [SerializeField]GameObject fire = null;
    [SerializeField]int timeToFire = 30;
    [SerializeField]int timeToFireWind = 200;

	// Use this for initialization
	void Start () {
		rb = gameObject.GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        Move(color);
        FireCheck(color);
	}

    public string GetSide() {
        if (transform.position.x < 0) {
            return "left";
        } else {
            return "right";
        }
    }

    void Move(string color) {
        if (color == "red") {
            inputX = Input.GetAxisRaw("Horizontal");
            inputZ = Input.GetAxisRaw("Vertical");
        } else {
            if (Input.GetKey(KeyCode.U)) {
                inputZ = 1;
            } else if (Input.GetKey(KeyCode.J)) {
                inputZ = -1;
            } else {
                inputZ = 0;
            }

            if (Input.GetKey(KeyCode.H)) {
                inputX = -1;
            } else if (Input.GetKey(KeyCode.K)) {
                inputX = 1;
            } else {
                inputX = 0;
            }
        }
        
        moveDir = new Vector3(inputX, 0, inputZ).normalized;
        if (!moveDir.Equals(Vector3.zero)) {
            lastAngle = moveDir;
        }
        // This vector addition here is so gravity works.
        rb.velocity = (moveDir * walkSpeed) + new Vector3(0,-9.81f,0);
    }

    void FireCheck(string color) {
        timeToFire--;
        timeToFireWind--;
        if (color == "red") {
            GameObject bullet;
            if(Input.GetKey(KeyCode.C) && timeToFire <= 0) {
                bullet = Instantiate(fire);
                bullet.transform.position = transform.position + (lastAngle * 1.35f);
                bullet.GetComponent<Rigidbody>().velocity = lastAngle * 20;
                timeToFire = 30;
            } else if (Input.GetKey(KeyCode.V) && timeToFireWind <= 0) {
                bullet = Instantiate(wind);
                bullet.transform.position = transform.position + (lastAngle * 1.35f);
                bullet.GetComponent<Rigidbody>().velocity = lastAngle * 40;
                timeToFireWind = 200;
            }
            
        } else {
            GameObject bullet;
            if(Input.GetKeyDown(KeyCode.Comma) && timeToFire <= 0) {
                bullet = Instantiate(fire);
                bullet.transform.position = transform.position + (lastAngle * 1.35f);
                bullet.GetComponent<Rigidbody>().velocity = lastAngle * 20;
                timeToFire = 30;
            } else if (Input.GetKeyDown(KeyCode.Period) && timeToFireWind <= 0) {
                bullet = Instantiate(wind);
                bullet.transform.position = transform.position + (lastAngle * 1.35f);
                bullet.GetComponent<Rigidbody>().velocity = lastAngle * 40;
                timeToFireWind = 200;
            }
        }
        
    }

    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.tag == "door") {
            DarkMagician.GetInstance().RoomAdvance(this.gameObject);
        }
    }
}
