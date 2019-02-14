using UnityEngine;
using System.Collections;

public class platformmove : MonoBehaviour {
    public float rightLimit;
    public float leftLimit;
    public float speed = 2.0f;
    public int direction = 1;
    public Vector3 movement;
    // Use this for initialization
    void Start () {
	}
	
	// Update is called once per frame
	void FixedUpdate () {
	       
        if(transform.localPosition.x >= rightLimit) 
        {
            direction = -1;
        }

        else if (transform.localPosition.x <= leftLimit)
        {
            direction = 1;
        }

        movement = Vector3.right * direction * speed * Time.deltaTime;
        transform.Translate(movement);

	}
}
