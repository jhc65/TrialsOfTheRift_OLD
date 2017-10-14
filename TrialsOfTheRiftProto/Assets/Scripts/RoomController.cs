using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomController : MonoBehaviour {

    [SerializeField]string color;
    public int index;
    [SerializeField]Material[] redMats = new Material[2];
    [SerializeField]Material[] blueMats = new Material[2];
    [SerializeField]GameObject door;

	// Use this for initialization
	void Start () {
		index = 0;
        //CloseDoor();
	}

    private void Update() {
        if (color == "red") {
            gameObject.GetComponent<MeshRenderer>().material = redMats[index % 2];
        } else {
            gameObject.GetComponent<MeshRenderer>().material = blueMats[index % 2];
        }
    }

    public void SwapColor() {
        if (color == "red") {
            gameObject.GetComponent<MeshRenderer>().material = blueMats[index % 2];
            color = "blue";
        } else {
            gameObject.GetComponent<MeshRenderer>().material = redMats[index % 2];
            color = "red";
        }
    }

    public void CloseDoor() {
        door.tag = "not door";
    }

    public void OpenDoor() {
        door.tag = "door";
    }
}
