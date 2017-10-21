using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleAgent : MonoBehaviour {

    public Node gridPos;
    public Node[] neighbors;
    public Node[] moveableNodes;
    public float health;
    public float maxHealth;

    public Node desiredNode;

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void SetDesiredNode(Node _desiredNode) {
        desiredNode = _desiredNode;
    }
    public void SetPosition(Node _pos) {
        gridPos = _pos;
    }
    public void SetHealth(int _health) {
        health = _health;
    }
    public void TakeTurn() {
        SetPosition(desiredNode);
    }

}
