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
    public float heat;

    public Node desiredNode;
    public bool moving;
    public float lerpSpeed;

    public List<Vector3> moveList;

	void Start () {
		
	}
	
	void Update () {
        LerpToNextNode();

    }
    public void RequesMoveAction(Action.ACTIONS _action) {
        switch(_action) {
            case Action.ACTIONS.MOVE_FORWARD:
                //TerrainManager.Instance.MoveAgent(this, , true);
                break;
            case Action.ACTIONS.RIGHT_TURN:
                break;
            case Action.ACTIONS.LEFT_TURN:
                break;
        }
    }
    public void LerpToNextNode() {
        if(moving) {
            //...
        }
    }


    public void StartMove(List<Vector3> _nodeLocs) {
        moving = true;
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
