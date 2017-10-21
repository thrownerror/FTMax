using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentOverworld : MonoBehaviour
{

    protected float collisionRadius;
    protected GameObject currentTarget;
    protected string team; //enemy, obstacle, player, friendly
    protected float speed;
    protected float acceleration;
    protected float maxSpeed;
    protected Vector3 lineToTarget;
    protected Vector3 velocity;
    protected float distance;

    public AgentOverworld(string side)
    {
        team = side;
    }
    public AgentOverworld(string side, float spd, float acc, float mS)
    {

    }
    public AgentOverworld()
    {
        team = "obstacle";
        
    }

    protected virtual void move(Vector3 mv){}

    protected void setProperties(string side, float spd, float acc, float mS)
    {
        team = "side";
        speed = spd;
        acceleration = acc;
        maxSpeed = mS;

    }

    void getLineToTarget()
    {
        lineToTarget = currentTarget.transform.position - this.transform.position;
    }
    void distanceCalculator(Vector3 target)
    {

    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
