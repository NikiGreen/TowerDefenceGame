using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LockLevels : MonoBehaviour {

   
    public Button[] buttons;
    
    public int lock1 , lock2;


    
    void Start () {
        if (PlayerPrefs.GetInt("UnLockLevel") == 0)
        {
            lock1 = 1;
        }
        else
            lock1 = PlayerPrefs.GetInt("UnLockLevel");


    }
	
	// Update is called once per frame
	void Update () {
        PlayerPrefs.SetInt("UnLockLevel", lock1);
        lock2 = PlayerPrefs.GetInt("UnLockLevel");
        if (lock2 > lock1)
        {
           lock1 = lock2;
        }

        FindObjectOfType<GameManagerSrc>().lock2 = lock1;

        for (int i = 0; i < buttons.Length; i++)
        {
            if (Convert.ToInt32(buttons[i].GetComponentInChildren<Text>().text) <= lock1)
            {
                buttons[i].interactable = true;
            }
            else
            {
                buttons[i].interactable = false;
            }
        }
    }
}
