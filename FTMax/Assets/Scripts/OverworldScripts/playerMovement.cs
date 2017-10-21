using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour {

    public float speed;
    public float maxSpeed;

    private Vector3 velocity;
    public float acceleration;

	// Use this for initialization
	void Start () {
        maxSpeed = 20;
        speed = 3;
        acceleration = 1.75f;
        velocity = new Vector3(0, 0, 0);
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 oldPos = this.transform.position;
        Vector3 newDir = new Vector3(0, 0, 0);
        if (Input.GetKey("w"))
        {
            // this.transform.position = new Vector3(oldPos.x, oldPos.y, oldPos.z + (10 * Time.deltaTime));
            newDir = newDir + (Vector3.forward * Time.deltaTime);
        }
        if (Input.GetKey("a"))
        {
            newDir = newDir + (Vector3.left * Time.deltaTime);
        }
        if (Input.GetKey("s"))
        {
            newDir = newDir + (Vector3.back * Time.deltaTime);
        }
        if (Input.GetKey("d"))
        {
            newDir = newDir + (Vector3.right * Time.deltaTime);
        }
        newDir.Normalize();
        newDir = newDir * (acceleration * Time.deltaTime);
        velocity += newDir;
        
        this.transform.position = this.transform.position + Vector3.ClampMagnitude(velocity, maxSpeed);
    }
}
