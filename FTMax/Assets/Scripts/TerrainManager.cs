using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainManager : MonoBehaviour {
    //Attributes
    public TerrainManager.TerrainNode[][] terrain;
    TerrainManager.TerrainNode playerNode;
    GameObject[] prefabs;

    public class TerrainNode {
        public Vector2 position;
        public TerrainManager.TerrainNode[] neighbors;
        public BattleAgent[] Occupants;
        public bool isTraversable;
        public bool isBorder;

        public TerrainNode(Vector2 _pos) {
            position = _pos;
        }
    }

	void Start () {
		
	}
	
	void Update () {
		
	}

    public void MoveAgent(BattleAgent car, TerrainManager.TerrainNode _movePos){
        if(car.CanMoveTo(_movePos)) {
            car.SetPosition(_movePos);
        }
    }

    public bool isValidMove(TerrainNode location)
    {
        return true;
    }

    public bool CheckForCollision(TerrainNode desiredLocation)
    {
        if (desiredLocation.isTraversable)
            return false;
        else
            return true;
    }
}
