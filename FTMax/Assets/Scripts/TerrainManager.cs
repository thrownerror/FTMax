using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainManager : MonoBehaviour {
    //Attributes
    public Node[][] terrain;
    Node playerNode;
    GameObject[] prefabs;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void MoveAgent(BattleAgent car, Vector2 move)
    {
        
    }

    public bool isValidMove(Node location)
    {
        return true;
    }

    public bool CheckForCollision(Node desiredLocation)
    {
        if (desiredLocation.isTraversable)
            return false;
        else
            return true;
    }
}
