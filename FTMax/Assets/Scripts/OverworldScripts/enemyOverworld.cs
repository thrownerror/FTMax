using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyOverworld : AgentOverworld
{

    public enemyOverworld() //:// base("player", .01f, .03f, .5f)
    {
        //debug.log("player constructor called");

    }
    // Use this for initialization
    void Start()
    {
        // base("player", .01f, .03f, .5f);
        base.setProperties("enemy", 0.1f, .02f, .5f);
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
