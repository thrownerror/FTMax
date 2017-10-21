using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BattleStates
{
    PlayerTurn,
    EnemyTurn, 
    Pause,
    EndBattle
}

public enum Actions
{
    TURN_LEFT,
    TURN_RIGHT,
    GO_FORWARD,
    SLOW_DOWN,
    HAIRPIN,
    DRIFT,
    SPEED_UP,
    LANE_SHIFT_LEFT,
    LANE_SHIFT_RIGHT
}

public class BattleManager : MonoBehaviour
{
    //Attributes
    public BattleStates battleState;
    public PlayerBattle player;

	// Use this for initialization
	void Start () {
        TerrainManager.Instance.MoveAgent(player, new Vector2(10, 0), true);
	}
	
	// Update is called once per frame
	void Update () {
	    while(battleState != BattleStates.EndBattle)
        {
            Actions playerAct =GetPlayerAction();
            Actions enemyAction =GetAIAction();
            CheckIfBattleOver();
        }	
	}

    //Will Take in a Player, And a Enemy Car, + data about collision (not sure what this ) returns array of vector to for resolution
    public Vector2[] ResolveCarCollision()
    {
        Vector2[] resoltuion = new Vector2[] { new Vector2(), new Vector2() };
        return resoltuion;
    }

    public void CheckIfBattleOver()
    {

        battleState = BattleStates.EndBattle;
    }
    
    //Will get players action for that Turn
    public Actions GetPlayerAction()
    {
        return Actions.GO_FORWARD;
    }

    public Actions GetAIAction()
    {
        return Actions.SLOW_DOWN;
    }
}
