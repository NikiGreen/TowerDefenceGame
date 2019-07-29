using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuSrc : MonoBehaviour {
    /*
   public static MenuSrc Instance;
   public GameObject Menu;
   

    public AudioClip LoseSnd;


    void Start () {
       Instance = this;
   }


   void Update () {
       
   }

   public void PlayBtn()
   {
       FindObjectOfType<LevelManagerSrc>().CreateLevel();
       FindObjectOfType<EnemySpawnerSrc>().spawnCount = 0;
       FindObjectOfType<EnemySpawnerSrc>().timeToSpawn = 4;
       Menu.SetActive(false);
        FindObjectOfType<GameManagerSrc>().canSpawn = true;//
   }

   public void ExitBtn()
   {
       Application.Quit();
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

       FindObjectOfType<GameManagerSrc>().GameMoney = 30;
        FindObjectOfType<GameManagerSrc>().LivesCount = 5;

       Menu.SetActive(true);
        FindObjectOfType<GameManagerSrc>().canSpawn = false;//

       if (FindObjectsOfType<ShopScr>().Length > 0)
           Destroy(FindObjectOfType<ShopScr>().gameObject);
   }

   public void PlayLoseSnd()
   {
       GetComponent<AudioSource>().clip = LoseSnd;
       GetComponent<AudioSource>().Play();
   }

    /*public void PlayHitSnd()
    {
        GetComponent<AudioSource>().clip = HitSnd;
        GetComponent<AudioSource>().Play();
    }*/
}
