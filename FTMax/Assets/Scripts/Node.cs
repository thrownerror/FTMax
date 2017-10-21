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

    
}
