using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOverworld : AgentOverworld
{
    public Rigidbody rb;
    float angle;
    public GameObject gM;
    private float health;
    public GameObject cam;
    public PlayerOverworld():base("player", .01f, .03f, .5f)
    {
        //debug.log("player constructor called");
        
    }
	// Use this for initialization
	void Start () {
        health = 100;
        // base("player", .01f, .03f, .5f);
        base.setProperties("player", .03f, .03f, .2f);
        rb = GetComponent<Rigidbody>();
        angle = 0;
	}
	
	// Update is called once per frame
    void Update()
    {
        //Debug("pls");
       // Vector3 oldPos = this.transform.position;
        Vector3 moveDir = new Vector3(0, 0, 0);
        Quaternion rotateDir; //= new Vector3(0, 0, 0);
        float speed = base.speed;
        if (Input.GetKey("w"))
        {
            // this.transform.position = new Vector3(oldPos.x, oldPos.y, oldPos.z + (10 * Time.deltaTime));
            moveDir = moveDir + (transform.forward * Time.deltaTime);
          
        }
        if (Input.GetKey("s"))
        {
            moveDir = moveDir + (transform.forward * Time.deltaTime * -1);
        }
        move(moveDir);
        if(rb.velocity != new Vector3(0, 0, 0)) {
            if (Input.GetKey("a"))
            {
                angle -= 40 * Time.deltaTime;
                rotate();
                //rotateDir = //rotateDir + Quaternion.Euler(0,.8f *(Vector3.left.x) * Time.deltaTime,0);
                //  rb.rotation = Quaternion.AngleAxis(angle, Vector3.up);
            }
            if (Input.GetKey("d"))
            {
                angle += 40 * Time.deltaTime;
                rotate();
                //rotateDir = //rotateDir + Quaternion.Euler(0,.8f *(Vector3.left.x) * Time.deltaTime,0);
                // rb.rotation = Quaternion.AngleAxis(angle, Vector3.up);
                //rotateDir = rotateDir + (.8f* Vector3.right * Time.deltaTime);
            }
        }
       // newDir.Normalize();
       // newDir = newDir * (acceleration * Time.deltaTime);
       // velocity += newDir;
       
        //this.transform.position = this.transform.position + Vector3.ClampMagnitude(velocity, maxSpeed);
        if(health < 0)
        {
            Debug.Log("dead");
        }
    }
    protected void rotate()
    {
        //Quaternion toRotate += rb.rotation;
        //toRotate += 
        rb.rotation = Quaternion.AngleAxis(angle, Vector3.up);
    }
    protected void move(Vector3 mv)
    {
        mv.Normalize();
        mv = mv * (acceleration * Time.deltaTime);
        rb.velocity += mv;
        rb.velocity = Vector3.ClampMagnitude(rb.velocity, base.maxSpeed);
        rb.position += rb.velocity;
      //  rb.rotation = Quaternion.Euler(0.0f, rb.velocity.x * 900, 0.0f);
        //velocity += mv;
       // this.transform.position = this.transform.position + Vector3.ClampMagnitude(velocity, maxSpeed);
    }
    private void OnCollisionEnter(Collision collision)
    {
        rb.velocity = Vector3.ClampMagnitude(rb.velocity/5, base.maxSpeed);
        cam.GetComponent<CameraScript>().startShake();
        Debug.Log(collision.gameObject);
        if (collision.gameObject.tag == "enemy")
        {
            gM.GetComponent<GameManager>().enterBattle();
        }
        if (collision.gameObject.tag == "obstacle")
        {
            health -= 10;
        }        
    }
}
