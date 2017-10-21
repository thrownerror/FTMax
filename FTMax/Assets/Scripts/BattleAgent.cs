using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleAgent : MonoBehaviour {

    public Node gridPos;
    public Vector2 gridRot;

    public Node[] neighbors;
    public Node[] moveableNodes;
    
    public float health;
    public float maxHealth;

    public Vector2 velocity;
    public float speed;
    public float maxSpeed;

    public Node desiredNode;

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public bool CanMoveTo(Node _moveToLoc) {
        return true;
    }
    public void SetDesiredNode(Node _desiredNode) {
        desiredNode = _desiredNode;
    }
    public void SetPosition(Node _pos) {
        gridPos = _pos;
        transform.position = _pos.position;
    }
    public void Accelerate(Vector2 _accelVector) {
        velocity += _accelVector;
        velocity = Vector2.ClampMagnitude(velocity, maxSpeed);
        speed = velocity.magnitude;
    }
    public void SetRotation(Vector2 _rot) {
        gridRot = _rot;
    }
    public void SetHealth(int _health) {
        health = _health;
    }
    public void TakeTurn() {
        SetPosition(desiredNode);
    }
    void Rotate(Vector2 _dir) {
        gridRot += _dir;
    }
    public void LeftTurn() {
        Rotate(new Vector2(0, -90));
    }
    public void RightTurn() {
        Rotate(new Vector2(0, 90));
    }
}
