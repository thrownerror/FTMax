using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour {

    private Quaternion battleAngle;
    private Quaternion overworldAngle;
    private bool shake;
    private int shakeCounter;
   // public Rigidbody camRB;
	// Use this for initialization
	void Start () {
        overworldAngle = Quaternion.Euler(90, 0, 90);
        battleAngle = Quaternion.Euler(180, 0, 180);
        shakeCounter = 0;
    }
	
	// Update is called once per frame
	void Update () {
		if(shake)
        {
            // this.transform.rotation = new Vector3(this.transform.rotation.x, this.transform.rotation.y, this.transform.rotation.z + .01f);
            this.transform.rotation = Quaternion.AngleAxis(Random.Range(-2, 2), Vector3.forward);//10, Vector3.forward);
            shakeCounter++;
            if (shakeCounter > 30){
                shake = false;
            }
        }
        else
        {
            this.transform.rotation = Quaternion.AngleAxis(0, Vector3.forward);
        }
    }

    public void startShake()
    {
        shakeCounter = 0;
        shake = true;
    }
    void setAngleBattle()
    {
        this.transform.rotation = battleAngle;
    }
    void setAngleOver()
    {
        this.transform.rotation = overworldAngle;
    }
}
