using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerOverworld : AgentOverworld
{
    public Rigidbody rb;
    float angle;
    public GameObject gM;
    public float health;
    public GameObject cam;
    public int invulnFrames;
    public int enemiesKilled;
    public GameObject enemyText;
    public GameObject healthText;
    public GameObject gameEndText;
    public PlayerOverworld():base("player", .01f, .03f, .5f)
    {
        //debug.log("player constructor called");
        
    }
	// Use this for initialization
	void Start () {
        health = 50;
        // base("player", .01f, .03f, .5f);
        base.setProperties("player", .03f, .03f, .2f);
        rb = GetComponent<Rigidbody>();
        enemiesKilled = 0;
        
        angle = 0;
	}
	public void enemiesSlain(int kia)
    {
        enemiesKilled = kia;
    }
	// Update is called once per frame
    void Update()
    {
        
        if(health <= 0)
        {
            gameEndText.GetComponent<Text>().text = "GAME OVER";
        }
        healthText.GetComponent<Text>().text = "Health: " + health;
        enemyText.GetComponent<Text>().text = "Bandits Killed: " + enemiesKilled;

        //healthText = healthText.GetComponent<Text>();
        //healthText.text = "Health: " + health;
        //healthText.GetComponent<TextAlignmen
        //enemyText = enemyText.GetComponent<Text>();
        //enemyText.text = "Bandits slain: " + enemiesKilled;
        if (invulnFrames > 0)
        {
            invulnFrames--;
        }
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
        cam.GetComponent<CameraScript>().startShake();
        Debug.Log(collision.gameObject);
        if (collision.gameObject.tag == "enemy")
        {
            gM.GetComponent<GameManager>().enterBattle();
        }
        if (collision.gameObject.tag == "obstacle")
        {
            if (invulnFrames == 0)
            {
                health -= 5;
                Debug.Log(health);
                invulnFrames = 30;
            }
        }
        if(collision.gameObject.tag == "settlement")
        {
            health = 50;
            Debug.Log(health);
            gM.GetComponent<GameManager>().resetBattle();
        }
        rb.velocity = Vector3.ClampMagnitude(rb.velocity / 5, base.maxSpeed);

    }
}
