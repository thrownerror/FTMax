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

    private List<Node> moveList;

    public void Start () {
        moveList = new List<Node>();
    }
	
	public void Update() {
        //  Debug.Log(moveList.Count);
        if (Input.GetKeyDown(KeyCode.W))
        {
            RequestMoveAction(0);
        }
       LerpToNextNode();

    }
    public void RequestMoveAction(int _action)
    {
        print("Request move");
        List<Vector2> requestedMoveList = new List<Vector2>();
        switch (_action)
        {
            case (int)Action.ACTIONS.MOVE_FORWARD:
                for (int i = 0; i < Action.moveForward.Length; i++)
                {
                    requestedMoveList.Add(Action.moveForward[i]);
                }
                moveList = GameObject.FindGameObjectWithTag("GameManager").GetComponent<TerrainManager>().MoveAgent(this, requestedMoveList, true);
                break;
            case (int)Action.ACTIONS.RIGHT_TURN:
                for (int i = 0; i < Action.turnRight.Length; i++)
                {
                    requestedMoveList.Add(Action.turnRight[i]);
                }

                moveList = GameObject.FindGameObjectWithTag("GameManager").GetComponent<TerrainManager>().MoveAgent(this, requestedMoveList, true);

                break;
            case (int)Action.ACTIONS.LEFT_TURN:
                break;
        }

    }

   
    public void LerpToNextNode() {
        //print("lerpiin");
        
        if (moveList.Count != 0) {
            print("lerpiin");
            transform.position = new Vector3(moveList[0].transform.position.x, 0, moveList[0].transform.position.z);
            gridPos = moveList[0];
            moveList.Remove(moveList[0]);
            
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
