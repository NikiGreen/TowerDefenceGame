using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemySpawnerSrc : MonoBehaviour
{
    public LevelManagerSrc LMS;
    GameControllerSrc gcs;

    public float timeToSpawn = 6;
    public int spawnCount = 0;

    public GameObject enemyPref;
	
    public void Start()
    {
        gcs = FindObjectOfType<GameControllerSrc>();
    }

	void Update () {
        if (GameManagerSrc.Instance.canSpawn)
        {
            if (timeToSpawn <= 0 && spawnCount <= 7)//изначально было 8
            {
                StartCoroutine(SpawnEnemy(spawnCount + 1));
                timeToSpawn = 4;
            }
            


            timeToSpawn -= Time.deltaTime;
            
        }
	}

    IEnumerator SpawnEnemy(int enemyCount)
    {
        spawnCount++;

        for (int i = 0; i < enemyCount; i++)
        {
            GameObject tmpEnemy = Instantiate(enemyPref);
            tmpEnemy.transform.SetParent(gameObject.transform, false);

            tmpEnemy.GetComponent<EnemySrc>().selfEnemy = gcs.AllEnemies[Random.Range(0,gcs.AllEnemies.Count)];

            Transform startCellPos = LMS.wayPoints[0].transform;
            Vector3 startPos = new Vector3(startCellPos.position.x + startCellPos.GetComponent<SpriteRenderer>().bounds.size.x / 2, 
                                           startCellPos.position.y + startCellPos.GetComponent<SpriteRenderer>().bounds.size.y);//Вектор для создания юнитов над первой ячейкой

            tmpEnemy.transform.position = startPos;

           yield return new WaitForSeconds(0.3f);
        }
    }
}
