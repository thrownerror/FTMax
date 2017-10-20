using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

}
