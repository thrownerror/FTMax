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

    private Node[] moveList;
    private int count;
    public List<Vector2> requestedMoveList;

    void Start () {
        requestedMoveList = new List<Vector2>();
        count = 0;
    }
	
	void Update () {
        //  Debug.Log(moveList.Count);
       LerpToNextNode();

    }
    public void RequestMoveAction(int _action) {
        print("Request move");
         
        switch(_action) {
            case (int)Action.ACTIONS.MOVE_FORWARD:
                for(int i = 0; i < Action.moveForward.Length; i++) {
                    requestedMoveList.Add(Action.moveForward[i]);
                }
                List<Node> poop = GameObject.FindGameObjectWithTag("GameManager").GetComponent<TerrainManager>().MoveAgent(this, requestedMoveList, true);
                moveList = new Node[poop.Count];
                for(int j = 0; j< poop.Count; j++) {
                    moveList[j] = poop[j];
                }
                SetupMove(poop);
                break;
            case (int)Action.ACTIONS.RIGHT_TURN:
                for (int i = 0; i < Action.turnRight.Length; i++) {
                    requestedMoveList.Add(Action.turnRight[i]);
                }

                List<Node> poop2 = GameObject.FindGameObjectWithTag("GameManager").GetComponent<TerrainManager>().MoveAgent(this, requestedMoveList, true);
                SetupMove(poop2);
                moveList = new Node[poop2.Count];
                for (int j = 0; j < poop2.Count; j++) {
                    moveList[j] = poop2[j];
                }
                break;
            case (int)Action.ACTIONS.LEFT_TURN:
                break;
        }
    }
    public void LerpToNextNode() {
        //print("lerpiin");
        
        if (moveList!= null) {
            print("lerpiin");
            transform.position = new Vector3(moveList[count].transform.position.x, 0, moveList[count].transform.position.z);
            gridPos = moveList[count];
           // moveList.Remove(moveList[count]);
            if(count+1 < moveList.Length) {
                count++;
            }
            else {
                count = 0;
                moveList = null;
            }
        }
    }

    private void SetupMove(List<Node> fuck) {
      //  moveList = fuck;
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
