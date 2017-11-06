using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalController : MonoBehaviour {
	private int side;

	private void Start()
	{
		if(transform.position.x < 0)
		{
			side = -1;
		}
		else
		{
			side = 1;
		}
	}

	//private void OnCollisionEnter(Collision collision){
	//	Debug.Log("um");
	//	if (collision.collider.tag == "Player" || collision.collider.tag == "Shot"){
	//		Debug.Log("collider");
	//	}
	//}

	private void OnTriggerEnter(Collider other)
	{
		//Debug.Log("what?");
		if (other.tag == "Player" || other.tag == "Shot")
		{
			other.gameObject.transform.position = new Vector3(-1*other.gameObject.transform.position.x + side*2f,
				other.gameObject.transform.position.y, -1*other.gameObject.transform.position.z);
			Debug.Log("trigger");
		}
	}
}
