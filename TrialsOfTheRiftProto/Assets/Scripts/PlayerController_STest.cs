using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController_STest : MonoBehaviour {

    public int walkSpeed;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        float inputX = Input.GetAxisRaw("Horizontal");
        float inputZ = Input.GetAxisRaw("Vertical");
        Vector3 moveDir = new Vector3(inputX, 0, inputZ).normalized;
        Rigidbody rb = gameObject.GetComponent<Rigidbody>();

        // This vector addition here is so gravity works.
        rb.velocity = (moveDir * walkSpeed) + new Vector3(0,-9.81f,0);
        
		
	}
}
