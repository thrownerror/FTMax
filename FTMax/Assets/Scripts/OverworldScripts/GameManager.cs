using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    private string gameMode;
    public GameObject camera;
    public GameObject overPlayer;
    public GameObject battlePlayer;
    public GameObject enemyUnit;
    public bool playerWonBattle;
    private int playerHealth;
    //public GameObject gameEndText;
	// Use this for initialization
	void Start () {
        gameMode = "overworld";
        playerWonBattle = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void winBattle()
    {
        playerWonBattle = true;
        enemyUnit.transform.position = new Vector3(1000, enemyUnit.transform.position.y, enemyUnit.transform.position.z);
    }
    public void resetBattle()
    {
        playerWonBattle = false;
        float posX = Random.Range(0.0f, 40f);
        float posZ = Random.Range(0.0f, 40f);
        enemyUnit.transform.position = new Vector3(posX, enemyUnit.transform.position.y, posZ);
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
