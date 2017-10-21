using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBattle : BattleAgent {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKey(KeyCode.W)) {
            Move(new Node(), 1);
        }else if(Input.GetKey(KeyCode.A)) {

        }else if(Input.GetKey(KeyCode.S)) {

        }else if(Input.GetKey(KeyCode.D)) {

        }
	}
    void Move(Node _dir, int spaces) {
        if(CanMoveTo(gridPos)) {
            base.SetPosition(_dir);
        }
    }
    void Rotate() {

    }
    public void LeftTurn() {

    }
    public void RightTurn() {

    }

}
