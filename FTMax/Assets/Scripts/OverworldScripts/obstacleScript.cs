using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstacleScript : AgentOverworld
{

    public obstacleScript() //:// base("player", .01f, .03f, .5f)
    {
        //debug.log("player constructor called");

    }
    // Use this for initialization
    void Start()
    {
        // base("player", .01f, .03f, .5f);
        base.setProperties("obstacle", 0.0f, .00f, .0f);
    }
    protected void move(Vector3 mv)
    {
        mv.Normalize();
        mv = mv * (acceleration * Time.deltaTime);
        velocity += mv;
        this.transform.position = this.transform.position + Vector3.ClampMagnitude(velocity, maxSpeed);
    }
    // Update is called once per frame
    void Update()
    {

    }
}
