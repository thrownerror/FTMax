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
    public float playerHealth;
    public static GameManager Instance;
    GameObject donkey;
    //public GameObject gameEndText;
    // Use this for initialization
    private void Awake()
    {
    //    if (Instance) { DontDestroyOnLoad(gameObject); }
    //    else { DontDestroyOnLoad(gameObject); Instance = this; }
        //DontDestroyOnLoad(this.gameObject);
    }
    void Start () {
        donkey = GameObject.FindGameObjectWithTag("donkey");

        gameMode = "overworld";
        playerWonBattle = false;
        overPlayer.GetComponent<PlayerOverworld>().health = donkey.GetComponent<informationDonkey>().getPlayerHealth();
	}
	
	// Update is called once per frame
	void Update () {
        if (donkey.GetComponent<informationDonkey>().playerWon)
        {
            overPlayer.GetComponent<PlayerOverworld>().enemiesSlain(donkey.GetComponent<informationDonkey>().enemiesKilled);
          //  donkey.GetComponent<informationDonkey>().playerWon = false;
        }
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

    public void goToOverworld()
    {
        SceneManager.LoadScene("overworldScene");
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
        SceneManager.LoadScene("testBattleScene");
        //gm.GetComponent<GameManager>().playerHealth = player.GetComponent<PlayerBattle>().health;
        //gm.GetComponent<GameManager>().goToOverworld();
        //donkey.GetComponent<GameManager>().goToOverworld();
        //donkey.GetComponent<informationDonkey>().enterBattle();
        //donkey.GetComponent<information>
        //donkey.GetComponent<>
        donkey.gameObject.GetComponent<informationDonkey>().setPlayerHealth(overPlayer.GetComponent<PlayerOverworld>().health);
        donkey.gameObject.GetComponent<informationDonkey>().enterBattle();
    }




}
