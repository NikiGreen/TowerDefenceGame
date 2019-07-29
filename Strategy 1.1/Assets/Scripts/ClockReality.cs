using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class ClockReality : MonoBehaviour {


    public Text minutes, hours;
    
	
	void Update () {
        DateTime time = DateTime.Now;
        if(time.Minute<10)
        minutes.text = "0" + time.Minute;
        else
            minutes.text = "" + time.Minute;
        if (time.Hour < 10)
            hours.text = "0" + time.Hour + " :";
        else
            hours.text = "" + time.Hour + " :";
    }
}
