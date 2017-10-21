﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    private string gameMode;
    public GameObject camera;
    public GameObject overPlayer;
    public GameObject battlePlayer;


    private int playerHealth;

	// Use this for initialization
	void Start () {
        gameMode = "overworld";
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void toggleMode(){
        if(gameMode == "overworld"){
            gameMode = "battle";
        }
        else{
            gameMode = "overworld";
        }
    }

    void setPlayerHealth()
    {
        //overPlayer.health = battlePlayer.health;
    }

    public void enterBattle()
    {
        SceneManager.LoadScene("testBattleScene", LoadSceneMode.Additive);
        
    }

}