using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActorOverworld : MonoBehaviour {

    float collisionRadius;
    GameObject currentTarget;
    string team; //enemy, obstacle, player, friendly
    float speed;
    Vector3 lineToTarget;
    float distance;

    public ActorOverworld(string side)
    {
        team = side;
    }
    public ActorOverworld()
    {
        team = "obstacle";
    }

    void move()
    {

    }

    void getLineToTarget()
    {
        lineToTarget = currentTarget.transform.position - this.transform.position;
    }
    void distanceCalculator(Vector3 target)
    {

    }
    
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
