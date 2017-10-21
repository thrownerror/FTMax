using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBattle : BattleAgent {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void Move(Node _newPos, Vector2 _rotation, int spaces) {
        if(CanMoveTo(gridPos)) {
            
        }
    }

}
