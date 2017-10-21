using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour {

    private Quaternion battleAngle;
    private Quaternion overworldAngle;
	// Use this for initialization
	void Start () {
        overworldAngle = Quaternion.Euler(90, 0, 90);
        battleAngle = Quaternion.Euler(180, 0, 180);
    }
	
	// Update is called once per frame
	void Update () {
		
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
