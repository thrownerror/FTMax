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
            Move(new TerrainManager.TerrainNode(new Vector2(0,1)), gridRot, 1);
        }else if(Input.GetKey(KeyCode.A)) {
            Move(new TerrainManager.TerrainNode(new Vector2(-1, 0)), gridRot, 1);
        } else if(Input.GetKey(KeyCode.S)) {
            Move(new TerrainManager.TerrainNode(new Vector2(0, -1)), gridRot, 1);
        } else if(Input.GetKey(KeyCode.D)) {
            Move(new TerrainManager.TerrainNode(new Vector2(1, 0)), gridRot, 1);
        }
	}

    void Move(TerrainManager.TerrainNode _newPos, Vector2 _rotation, int spaces) {
        if(CanMoveTo(gridPos)) {
            base.SetPosition(new TerrainManager.TerrainNode(new Vector3(_newPos.position.x, 0, _newPos.position.y)));
        }
    }

}
