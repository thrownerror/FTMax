using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAgent : BattleAgent {

	// Use this for initialization
	void Start () {
        base.Start();
		
	}
	
	// Update is called once per frame
	void Update () {
        base.Update();
    }

    public void GenerateMove()
    {
        int act = Random.Range(0, 9);
        RequestMoveAction(act);
    }
}
