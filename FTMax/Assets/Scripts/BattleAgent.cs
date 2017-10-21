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
            case (int)Action.Actions.GO_FORWARD:
                for (int i = 0; i < Action.moveForward.Length; i++)
                {
                    requestedMoveList.Add(Action.moveForward[i]);
                }
                break;
            case (int)Action.Actions.TURN_RIGHT:
                for (int i = 0; i < Action.turnRight.Length; i++)
                {
                    requestedMoveList.Add(Action.turnRight[i]);
                }

                break;
            case (int)Action.Actions.TURN_LEFT:
                for (int i = 0; i < Action.turnLeft.Length; i++)
                {
                    requestedMoveList.Add(Action.turnLeft[i]);
                }
                break;

            case (int)Action.Actions.SPEED_UP:
                speed++;
                for (int i = 0; i < Action.moveForward.Length; i++)
                {
                    requestedMoveList.Add(Action.moveForward[i]);
                }
                break;

            case (int)Action.Actions.SLOW_DOWN:
                speed--;
                for (int i = 0; i < Action.moveForward.Length; i++)
                {
                    requestedMoveList.Add(Action.moveForward[i]);
                }
                break;

            case (int)Action.Actions.HAIRPIN_LEFT:
                for(int i = 0; i < Action.hairpinLeft.Length; i++)
                {
                    requestedMoveList.Add(Action.hairpinLeft[i]);
                }
                break;

            case (int)Action.Actions.HAIRPIN_RIGHT:
                for(int i = 0; i < Action.hairpinRight.Length; i++)
                {
                    requestedMoveList.Add(Action.hairpinRight[i]);
                }
                break;

            case (int)Action.Actions.LANE_SHIFT_LEFT:
                for (int i = 0; i < Action.laneShiftLeft.Length; i++)
                {
                    requestedMoveList.Add(Action.laneShiftLeft[i]);
                }
                break;

            case (int)Action.Actions.LANE_SHIFT_RIGHT:
                for (int i = 0; i < Action.laneShiftRight.Length; i++)
                {
                    requestedMoveList.Add(Action.laneShiftRight[i]);
                }
                break;
        }
        moveList = TerrainManager.Instance.MoveAgent(this, requestedMoveList, true);

    }
   
    public void LerpToNextNode() {
        //print("lerpiin");
        
        if (moveList.Count != 0) {
            print("lerpiin");
            transform.position = new Vector3(moveList[0].transform.position.x, 0, moveList[0].transform.position.z);
            if ((gridPos.position.x < moveList[0].position.x && transform.forward.normalized.x < 0) || (gridPos.position.x > moveList[0].position.x && transform.forward.normalized.x > 0))
            {
                transform.Rotate(Vector3.up, 180);
            }
            //if (gridPos.position.y < moveList[0].position.y && transform.right.z < 0 )
            //{
            //    transform.Rotate(Vector3.up, 90);
            //}
            //else if(gridPos.position.x > moveList[0].position.x && transform.right.z > 0)
            //{
            //    transform.Rotate(Vector3.up, 90);
            //}
            //else if(gridPos.position.x == moveList[0].position.x && gridPos.position.y < moveList[0].position.y)
            //{
            //    transform.Rotate(Vector3.up, -90);
            //}
            //else if (gridPos.position.x == moveList[0].position.x && gridPos.position.y > moveList[0].position.y)
            //{
            //    transform.Rotate(Vector3.up, 90);
            //}

            gridPos = moveList[0];
            moveList.Remove(moveList[0]);
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
