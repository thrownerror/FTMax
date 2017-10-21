using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour {
    public Vector2 position;
    public List<Node> neighbors;
    public List<BattleAgent> Occupants;
    public bool isTraversable;
    public bool isBorder;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public Node() {
        position = Vector2.zero;
        neighbors = new List<Node>();
        Occupants = new List<BattleAgent>();
        isTraversable = true;
        isBorder = false;
    }

    public Node(Vector2 pos, List<Node> neighborList, List<BattleAgent> occupant, bool traversable, bool border)
    {
        position = pos;
        neighbors = neighborList;
        Occupants = occupant;
        isTraversable = traversable;
        isBorder = border;
    }
}
