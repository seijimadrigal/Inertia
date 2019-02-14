using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

    public Vector3 offset;
    public GameObject Player;
	// Use this for initialization
	void Start () {

        // offset = transform.position - Player.transform.position;

        offset = new Vector3(0 ,14,-4);
	}
	
	// Update is called once per frame
	void FixedUpdate () {

        transform.position = Player.transform.position + offset;

	}
}
