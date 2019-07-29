using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeScr : MonoBehaviour {

    public AudioClip MainMenuTheme, MainGameTheme;


    public void Start()
    {
        //if (FindObjectOfType<GameManagerSrc>().setactive2)
        //    GetComponent<AudioSource>().mute = true;
        //else
       // {
            GetComponent<AudioSource>().mute = false;
            if (FindObjectOfType<GameManagerSrc>().setactive)
                GetComponent<AudioSource>().clip = MainMenuTheme;
            else
                GetComponent<AudioSource>().clip = MainGameTheme;
            //if (FindObjectOfType<GameManagerSrc>().Volume)
            GetComponent<AudioSource>().Play();
       // }
    }

    void Update()
    {      
            GetComponent<AudioSource>().mute=!(FindObjectOfType<GameManagerSrc>().Volume);
        if (FindObjectOfType<GameManagerSrc>().setactive2)
            GetComponent<AudioSource>().mute = FindObjectOfType<GameManagerSrc>().setactive2;
    }


}
