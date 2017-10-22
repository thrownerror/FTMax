using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyOverworld : AgentOverworld
{
    float angle;
    public Rigidbody rb;
    public int health = 25;
    public enemyOverworld() //:// base("player", .01f, .03f, .5f)
    {
        //debug.log("player constructor called");

    }
    // Use this for initialization
    void Start()
    {
        angle = 0;
        // base("player", .01f, .03f, .5f);
        base.setProperties("enemy", 0.1f, .015f, .3f);
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
        move();
    }

    private void OnCollisionEnter(Collision collision)
    {
       // cam.GetComponent<CameraScript>().startShake();
        Debug.Log(collision.gameObject);
        if (collision.gameObject.tag == "enemy")
        {
           // gM.GetComponent<GameManager>().enterBattle();
        }
        if (collision.gameObject.tag == "obstacle")
        {
            health -= 5;
           // Debug.Log(health);
        }
        rb.velocity = Vector3.ClampMagnitude(rb.velocity / 5, base.maxSpeed);

    }
    void move()
    {
        Vector3 moveDir = new Vector3(0, 0, 0);
        
        int random = (int)Random.Range(0f, 5.999f);
      //  Debug.Log(random);
        switch (random)
        {
            case 0:
                moveDir = moveDir + (transform.forward * Time.deltaTime);
                break;
            case 1:
                moveDir = moveDir + (transform.forward * Time.deltaTime * -1);
                break;
            case 2:
                moveDir = moveDir + (transform.forward * Time.deltaTime * -1);
                angle -= 40 * Time.deltaTime;
                break;
            case 3:
                moveDir = moveDir + (transform.forward * Time.deltaTime * -1);
                angle += 40 * Time.deltaTime;
                break;
            case 4:
                moveDir = moveDir + (transform.forward * Time.deltaTime);
                angle += 40 * Time.deltaTime;
                break;
            case 5:
                moveDir = moveDir + (transform.forward * Time.deltaTime);
                angle -= 40 * Time.deltaTime;
                break;
            default:
                break;
        }
        rb.rotation = Quaternion.AngleAxis(angle, Vector3.up);
        moveDir.Normalize();
        moveDir = moveDir * (acceleration * Time.deltaTime);
        rb.velocity += moveDir;
        rb.velocity = Vector3.ClampMagnitude(rb.velocity, base.maxSpeed);
        rb.position += rb.velocity;
    }
}
