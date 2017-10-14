using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public float speed;

	private float x;
	private float y;

    private Rigidbody rb;

    void Start ()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate ()
    {
        float moveHorizontal = Input.GetAxis ("Horizontal")*speed;
        float moveVertical = Input.GetAxis ("Vertical")*speed;
		transform.Translate(moveHorizontal*Time.deltaTime,0f,moveVertical*Time.deltaTime);
    }
}