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

public class BattleManager : Singleton<BattleManager>
{
    protected BattleManager() { }

    //Attributes
    public BattleStates battleState;
    public PlayerBattle player;
    public int numEnemies = 1;
    public List<EnemyAgent> enemies;
    public bool hasPlayerGone = false;

    // Use this for initialization
    void Start()
    {
        TerrainManager.Instance.MoveAgentToNode(player, new Vector2(10, 2), true);
        enemies = TerrainManager.Instance.GenerateEnemy(numEnemies);
    }

    // Update is called once per frame
    void Update()
    {

        while (battleState != BattleStates.EndBattle)
        {
            GetPlayerAction();
            GetAIAction();

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
    public void GetPlayerAction()
    {
    }

    public void GetAIAction()
    {
        foreach(EnemyAgent enemy in enemies)
        {
            enemy.GenerateMove();
        }
    }
}

