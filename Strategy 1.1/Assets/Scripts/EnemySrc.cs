using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemySrc : MonoBehaviour
{

    List<GameObject> wayPoints = new List<GameObject>();

    public Enemy selfEnemy;

    int wayIndex = 0;

    public Color NoHPCol, FullHPCol;
    public Image HealthBar;

    

    void Start()
    {
        GetWaypoints();

        GetComponent<SpriteRenderer>().sprite = selfEnemy.spr;
    }


    void Update()
    {
        Move();
    }

    void GetWaypoints()
    {
        wayPoints = GameObject.Find("LevelGroup").GetComponent<LevelManagerSrc>().wayPoints;
    }

    private void Move()
    {
        Transform currWayPoint = wayPoints[wayIndex].transform;
        Vector3 currWayPos = new Vector3(currWayPoint.position.x + currWayPoint.GetComponent<SpriteRenderer>().bounds.size.x / 2,
                                         currWayPoint.position.y - currWayPoint.GetComponent<SpriteRenderer>().bounds.size.y / 2);//Равняем проход юнитов ровно посередине пути


        Vector3 dir = currWayPos - transform.position;

        transform.Translate(dir.normalized * Time.deltaTime * selfEnemy.Speed);

        if (Vector3.Distance(transform.position, currWayPos) < 0.3f)
        {
            if (wayIndex < wayPoints.Count - 1)
                wayIndex++;
            else
            {
                GameManagerSrc.Instance.MinusLives();
                Destroy(gameObject);
            }
        }
    }

    public void TakeDamage(float damage)
    {
        selfEnemy.Health -= damage;

        StartCoroutine(HealthBarUpdate(selfEnemy.Health + damage));

        
        checkisAlive();
    }

    IEnumerator HealthBarUpdate(float oldHP)
    {
        while (true)
        {
            oldHP--;

            HealthBar.fillAmount = oldHP / selfEnemy.MaxHealth;
            HealthBar.color = Color.Lerp(NoHPCol, FullHPCol, HealthBar.fillAmount);

            if (oldHP <= selfEnemy.Health)
                break;
            yield return new WaitForSeconds(.01f);
        }
    }

    void checkisAlive()
    {
        if (selfEnemy.Health <= 0)
        {
            GameManagerSrc.Instance.ShowBounty(selfEnemy.Bounty);
            GameManagerSrc.Instance.PlayHitSnd();
            FindObjectOfType<GameManagerSrc>().Enemies++;
            FindObjectOfType<GameManagerSrc>().EnemiesForEnd++;
            Destroy(gameObject);

        }
    }

    public void StartSlow(float duration, float slowValue)
    {

        StopCoroutine("GetSlow");
        selfEnemy.Speed = selfEnemy.StartSpeed;
        StartCoroutine(GetSlow(duration, slowValue));
    }

    IEnumerator GetSlow(float duration, float slowValue)
    {
        selfEnemy.Speed -= slowValue;
        yield return new WaitForSeconds(duration);
        selfEnemy.Speed = selfEnemy.StartSpeed; ;
    }

    public void AOEDemage(float range, float damage)
    {
        List<EnemySrc> enemies = new List<EnemySrc>();

        foreach (GameObject go in GameObject.FindGameObjectsWithTag("Enemy"))
        {
            if (Vector2.Distance(transform.position, go.transform.position) <= range)
                enemies.Add(go.GetComponent<EnemySrc>());
        }
        foreach (EnemySrc es in enemies)
            es.TakeDamage(damage);
    }
}
