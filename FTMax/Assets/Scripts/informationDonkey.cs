using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class informationDonkey : MonoBehaviour {
    private float playerHealth = 50;
    public bool playerWon;
    public static bool created = false;

    private void Awake()
    {
        if (!created) { DontDestroyOnLoad(this.gameObject); created = true; }
        else { Destroy(this.gameObject); }//DontDestroyOnLoad(gameObject); Instance = this; }
        //DontDestroyOnLoad(this.gameObject);
    }
    // Use this for initialization
    void Start () {
        playerHealth = 50;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void setPlayerHealth(float health)
    {
        playerHealth = health;
    }
    public float getPlayerHealth()
    {
        return playerHealth;
    }
    public void goToOverworld()
    {
        SceneManager.LoadScene("overworldScene");
    }

    public void enterBattle()
    {
        SceneManager.LoadScene("testBattleScene");

    }
}
