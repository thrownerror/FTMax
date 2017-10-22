using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBattle : BattleAgent {

	// Use this for initialization
	void Start () {
        base.Start();
        base.health = 50;
        base.speed = 1;
        base.heat = 0;
	}
	
	// Update is called once per frame
	void Update () {
        base.Update();
	}

    void Move(Node _newPos, Vector2 _rotation, int spaces) {

    }

}
