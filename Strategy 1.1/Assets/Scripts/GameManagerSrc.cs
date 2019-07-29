using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManagerSrc : MonoBehaviour {

    public static GameManagerSrc Instance;
    public GameObject Menu,LevelsMenu,LoseMenu,InfoMenu,SettingsMenu,BountyPref,VolumeButton;
    public Text MoneyTxt,LivesTxt;
    public int GameMoney,LivesCount;
    public bool canSpawn = false, Volume = true, setactive = true, setactive2 = false, setactive3 = false, setactive4 = false, setactive5 = false, Result = false;
    public int Enemies = 0;
    public int EnemiesForEnd = 0;
    public int Level = 1;
    public int lock2 = 1;

    public AudioClip LoseSnd, HitSnd, ShootSnd;
    


    void Start () {
        Instance = this;
        DateTime time = DateTime.Now;
        if(time.Hour>18 && time.Hour<23)//вечер
        Menu.GetComponent<Image>().sprite= Resources.Load<Sprite>("FontSprites/Lesson2");
        else
            if (time.Hour > 12 && time.Hour < 18)//день
            Menu.GetComponent<Image>().sprite = Resources.Load<Sprite>("FontSprites/SuperFont");
        else
            if (time.Hour > 6 && time.Hour < 12)//утро
            Menu.GetComponent<Image>().sprite = Resources.Load<Sprite>("FontSprites/SuperFont");
        else
            if (time.Hour > 0 && time.Hour < 6)//ночь
            Menu.GetComponent<Image>().sprite = Resources.Load<Sprite>("FontSprites/SuperFont");
        else
            Menu.GetComponent<Image>().sprite = Resources.Load<Sprite>("FontSprites/SuperFont");
    }
	
	 
	void Update () {
        MoneyTxt.text = "GOLD: " + GameMoney.ToString();
        LivesTxt.text = "Lives: " + LivesCount.ToString();


        if (Input.GetKeyDown(KeyCode.Escape) && (setactive3 == true || setactive4==true || setactive5 == true || setactive2 == true))
        {
            LoseBtn();
        }
        else
        if (Input.GetKeyDown(KeyCode.Escape) && setactive3 == false)
        {
            Result = false;
            ToMenu();
        }
        else 
            if (EnemiesForEnd == 36)
        {
            Result = true;
            if (Level == lock2)
                FindObjectOfType<LockLevels>().lock1++;
            ToMenu();
        }
	}

    public void PlayBtn(int NumberOfLevel)
    {
        
        FindObjectOfType<LevelManagerSrc>().CreateLevel(NumberOfLevel);
        FindObjectOfType<EnemySpawnerSrc>().spawnCount=0;
        FindObjectOfType<EnemySpawnerSrc>().timeToSpawn = 4;
        setactive3 = false;
        LevelsMenu.SetActive(setactive3);
        canSpawn = true;
        FindObjectOfType<VolumeScr>().Start();
    }

    public void ExitBtn()
    {
        Application.Quit();
    }

    public void VolumeBtn()
    {
        if (Volume)
        {
            VolumeButton.GetComponent<Image>().sprite = Resources.Load<Sprite>("ButtonsSprites/volume_Off");
            GetComponent<AudioSource>().mute = true;
            Volume = false;           
        }
        else
        {
            VolumeButton.GetComponent<Image>().sprite = Resources.Load<Sprite>("ButtonsSprites/volume_On");
            GetComponent<AudioSource>().mute=false;
            Volume = true;           
        }
    }

    public void ToMenu()
    {
        PlayLoseSnd();
     

        FindObjectOfType<EnemySpawnerSrc>().StopAllCoroutines();
        foreach (EnemySrc es in FindObjectsOfType<EnemySrc>())
        {
            es.StopAllCoroutines();
            Destroy(es.gameObject);
        }
        foreach (TowerScr ts in FindObjectsOfType<TowerScr>())
            Destroy(ts.gameObject);
        foreach (CellSrc cs in FindObjectsOfType<CellSrc>())
            Destroy(cs.gameObject);


        
        //setactive = true;
        // Menu.SetActive(setactive);


        setactive2 = true;
        LoseMenu.SetActive(setactive2);
        FindObjectOfType<VolumeScr>().Start();
        canSpawn = false;

        if (FindObjectsOfType<ShopScr>().Length > 0)
            Destroy(FindObjectOfType<ShopScr>().gameObject);
    }

    public void ShowBounty(int bounty)
    {
        GameMoney += bounty;

        GameObject bountyObj = Instantiate(BountyPref);
        bountyObj.transform.SetParent(GameObject.Find("Canvas").transform, false);
        bountyObj.GetComponent<BountyEffSrc>().SetParams(bounty);
    }

    public void MinusLives()
    {
        if (LivesCount > 1)
        {
            EnemiesForEnd++;
            LivesCount--;
        }
        else
        {
            Result = false;
            ToMenu();
        }
    }

    public void PlayLoseSnd()
    {
        GetComponent<AudioSource>().clip = LoseSnd;
        // if (Volume)
        GetComponent<AudioSource>().Play();
    }

    public void PlayHitSnd()
    {
        GetComponent<AudioSource>().clip = HitSnd;
        //if (Volume)
        GetComponent<AudioSource>().Play();
    }

    public void PlayShootSnd()
    {
        GetComponent<AudioSource>().clip = ShootSnd;
        //if (Volume)
        GetComponent<AudioSource>().Play();
    }

    public void LoseBtn()
    {
        GameMoney = 30;
        LivesCount = 5;
        EnemiesForEnd = 0;
        Enemies = 0;
        setactive2 = false;
        setactive = true;
        setactive3 = false;
        setactive4 = false;
        setactive5 = false;
        SettingsMenu.SetActive(setactive5);
        InfoMenu.SetActive(setactive4);
        LevelsMenu.SetActive(setactive3);
        LoseMenu.SetActive(setactive2);
        Menu.SetActive(setactive);
        
        FindObjectOfType<VolumeScr>().Start();
    }

    public void PlayButton()
    {
        setactive = false;
        Menu.SetActive(setactive);
        setactive3 = true;
        LevelsMenu.SetActive(setactive3);
    }

    public void InfoButton()
    {
        setactive = false;
        Menu.SetActive(setactive);
        setactive4 = true;
        InfoMenu.SetActive(setactive4);
    }

    public void SettingsButton()
    {
        setactive = false;
        Menu.SetActive(setactive);
        setactive5 = true;
        SettingsMenu.SetActive(setactive5);
    }

    public void CleanButton()
    {
        FindObjectOfType<LockLevels>().lock1 = 1;
        //PlayerPrefs.SetInt("UnLockLevel", 1);
    }
}
