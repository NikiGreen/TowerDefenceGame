using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinalScores : MonoBehaviour {

    public Text Lives,Gold,Enemies,Result;
    public Button LoseButton;


	// Use this for initialization
	void Start () {
        

    }

    
    void Update()
    {
        

        if (FindObjectOfType<GameManagerSrc>().Result)
        {
            Result.text = "You Won";
            Result.color =Color.green;
            
        }
        else
        {
            Result.text = "You Lose";
            FindObjectOfType<GameManagerSrc>().LivesCount=0;
            Result.color = Color.red;
        }

        Lives.text = Convert.ToString("Lives: " + FindObjectOfType<GameManagerSrc>().LivesCount);
        Gold.text = Convert.ToString("Gold: " + FindObjectOfType<GameManagerSrc>().GameMoney);
        Enemies.text = Convert.ToString("Killed: " + FindObjectOfType<GameManagerSrc>().Enemies);
    }
}
