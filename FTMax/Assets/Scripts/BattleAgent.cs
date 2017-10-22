using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct MoveInstruct
{
    public Node node;
    public float rotate;

    public MoveInstruct(Node node, float z) : this()
    {
        this.node = node;
        rotate = z;
    }
}
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

    public List<MoveInstruct> moveList;

    public void Start () {
        moveList = new List<MoveInstruct>();
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
        List<Vector3> requestedMoveList = new List<Vector3>();
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
                if(speed == 0)
                {
                    for (int i = 0; i < Action.reverse.Length; i++)
                    {
                        requestedMoveList.Add(Action.reverse[i]);
                    }
                    break;
                }
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

            case (int)Action.Actions.KNOCKBACK_BACKWARD:
                for (int i = 0; i < Action.knockbackBackward.Length; i++) {
                    requestedMoveList.Add(Action.knockbackBackward[i]);
                }
                break;
            case (int)Action.Actions.KNOCKBACK_LEFT:
                for (int i = 0; i < Action.knockbackLeft.Length; i++) {
                    requestedMoveList.Add(Action.knockbackLeft[i]);
                }
                break;
            case (int)Action.Actions.KNOCKBACK_RIGHT:
                for (int i = 0; i < Action.knockbackRight.Length; i++) {
                    requestedMoveList.Add(Action.knockbackRight[i]);
                }
                break;
            case (int)Action.Actions.KNOCKBACK_FORWARD:
                for (int i = 0; i < Action.knockbackForward.Length; i++) {
                    requestedMoveList.Add(Action.knockbackForward[i]);
                }
                break;
        }
        moveList = TerrainManager.Instance.MoveAgent(this, requestedMoveList, true);

    }
   
    public void LerpToNextNode() {
        //print("lerpiin");
        if (moveList.Count != 0) {
            transform.position = new Vector3(moveList[0].node.transform.position.x, 0, moveList[0].node.transform.position.z);
            //if ((gridPos.position.x < moveList[0].node.position.x && transform.forward.normalized.x < 0) || (gridPos.position.x > moveList[0].node.position.x && transform.forward.normalized.x > 0))
            //{
            //    transform.Rotate(Vector3.up, 180);
            //}

            ////Rotate Right
            //if(gridPos.position.y > moveList[0].node.position.y)
            //{
            //    transform.Rotate(Vector3.up, 90);
            //}
            //else if(gridPos.position.y > moveList[0].node.position.y)
            //{
            //    transform.Rotate(Vector3.up, -90);
            //}

            transform.Rotate(Vector3.up, moveList[0].rotate);
            gridPos = moveList[0].node;
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

    #region Health and Saftey
    public MoveInstruct RegisterCollision(BattleAgent _other) {
        //For now, count all collisions as the same
        if(_other is Obstacle) {
            TakeDamage(10 + _other.speed);
            speed--;
        } else {
            TakeDamage(5 + _other.speed);
            speed--;
        }

        return new MoveInstruct(TerrainManager.Instance.terrain[
        (int)gridPos.position.x - (int)(transform.forward.normalized.x), (int)gridPos.position.y - (int)(transform.forward.normalized.z)], 0);
    }

    public void TakeDamage(float _damage) {
        health -= _damage;

        if (health <= 0) {
            Die();
        }
    }
    private void Die() {
       //GameObject.Destroy(gameObject);
    }
    #endregion
}
