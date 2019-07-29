using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickManager : MonoBehaviour {


    public int NumberOfLevel;

    public void OnMouseDown()
    {
        /*int */NumberOfLevel = Convert.ToInt32(GetComponentInChildren<Text>().text);
        FindObjectOfType<GameManagerSrc>().Level = NumberOfLevel;
        FindObjectOfType<GameManagerSrc>().PlayBtn(NumberOfLevel);
       
    }
   

}
