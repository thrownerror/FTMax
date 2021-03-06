﻿using System.Collections;
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
    private GameObject donkey;
    public bool enemyDestroyed = false;
    public bool ranAway;
    // Use this for initialization
    void Start()
    {
        TerrainManager.Instance.MoveAgentToNode(player, new Vector2(10, 2), true);
        enemies = TerrainManager.Instance.GenerateEnemy(numEnemies);
        donkey = GameObject.FindGameObjectWithTag("donkey");
        player.gameObject.GetComponent<PlayerBattle>().health = donkey.GetComponent<informationDonkey>().getPlayerHealth();
    }

    // Update is called once per frame
    void Update()
    {
        if (hasPlayerGone)
        {
            GetAIAction();
            hasPlayerGone = false;
        }
        CheckIfBattleOver();
    }

    //Will Take in a Player, And a Enemy Car, + data about collision (not sure what this ) returns array of vector to for resolution
    public Vector2[] ResolveCarCollision()
    {
        Vector2[] resoltuion = new Vector2[] { new Vector2(), new Vector2() };
        return resoltuion;
    }

    public void CheckIfBattleOver()
    {
        if (player.health <= 0)
        {
            battleState = BattleStates.EndBattle;
            donkey.gameObject.GetComponent<informationDonkey>().setPlayerHealth(0);
            donkey.gameObject.GetComponent<informationDonkey>().playerWon = false;
            donkey.gameObject.GetComponent<informationDonkey>().goToOverworld();
            //GameObject gm = GameObject.FindGameObjectWithTag("GameManager");
            //gm.GetComponent<GameManager>().playerHealth = player.GetComponent<PlayerBattle>().health;
            //gm.GetComponent<GameManager>().goToOverworld();
            // GameObject donkey = Game
        }
        if (enemyDestroyed)
        {
            battleState = BattleStates.EndBattle;
            donkey.gameObject.GetComponent<informationDonkey>().setPlayerHealth(player.GetComponent<PlayerBattle>().health);
            donkey.gameObject.GetComponent<informationDonkey>().playerWon = true;
            donkey.gameObject.GetComponent<informationDonkey>().enemiesKilled++;
            donkey.gameObject.GetComponent<informationDonkey>().goToOverworld();
        }
        if (player.gridPos.position.x == 0 || player.gridPos.position.x == TerrainManager.Instance.length - 1)
        {
            donkey.gameObject.GetComponent<informationDonkey>().setPlayerHealth(player.GetComponent<PlayerBattle>().health);
            battleState = BattleStates.EndBattle;
            donkey.gameObject.GetComponent<informationDonkey>().goToOverworld();

        }
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

