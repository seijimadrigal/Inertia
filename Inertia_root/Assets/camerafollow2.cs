using UnityEngine;
using System.Collections;

public class camerafollow2 : MonoBehaviour {

    public Vector3 offset;
    public GameObject Player;
	// Use this for initialization
	void Start () {
        offset = new Vector3(4, 20, -1);
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        transform.position = Player.transform.position + offset;
	}
}
