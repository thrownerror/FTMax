using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAgent : BattleAgent {

	// Use this for initialization
	void Start () {
        base.Start();
		
	}
	
	// Update is called once per frame
	void Update () {
        base.Update();
    }

    public void GenerateMove()
    {
        PlayerBattle player = BattleManager.Instance.player;
        Vector2 playerPos = BattleManager.Instance.player.gridPos.position;

        if(playerPos.x > gridPos.position.x)
        {
            if(transform.forward.normalized == Vector3.right)
                RequestMoveAction(0);
            else if (transform.forward.normalized == Vector3.forward)
            {
                RequestMoveAction(1);
            }
            else if(transform.forward.normalized == Vector3.back)
            {
                RequestMoveAction(2);
            }
            else 
            {
                if (gridPos.position.y == 0)
                    RequestMoveAction(6);
                else
                    RequestMoveAction(5);
            }
        }
        else if (playerPos.x < gridPos.position.x)
        {
            if (transform.forward.normalized == Vector3.left)
                RequestMoveAction(0);
            else if (transform.forward.normalized == Vector3.forward)
            {
                RequestMoveAction(2);
            }
            else if (transform.forward.normalized == Vector3.back)
            {
                RequestMoveAction(1);
            }
            else
            {
                if (gridPos.position.y == 0)
                    RequestMoveAction(5);
                else
                    RequestMoveAction(6);
            }
        }
        else if(playerPos.y < gridPos.position.y)
        {
            if (transform.forward.normalized == Vector3.back)
                RequestMoveAction(0);
            else
            {
                if (gridPos.position.x == 0)
                    RequestMoveAction(6);
                else
                    RequestMoveAction(5);
            }
        }
        else if (playerPos.y > gridPos.position.y)
        {
            if (transform.forward.normalized == Vector3.forward)
                RequestMoveAction(0);
            else
            {
                if (gridPos.position.x == 0)
                    RequestMoveAction(5);
                else
                    RequestMoveAction(6);
            }
        }
        else
        {
            RequestMoveAction(0);
        }

    }
}
