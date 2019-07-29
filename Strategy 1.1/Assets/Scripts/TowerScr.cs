using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerScr : MonoBehaviour {

    public GameObject Projectile;
    public Tower selfTower;
    public TowerType selfType;
    GameControllerSrc gcs;

    private void Start()
    {
        gcs = FindObjectOfType<GameControllerSrc>();

        selfTower = gcs.AllTowers[(int)selfType];
        GetComponent<SpriteRenderer>().sprite = selfTower.Spr;

        InvokeRepeating("SearchTarget",0,0.1f);
    }

    private void Update()
    {
        
        if (selfTower.CurrCooldown > 0)
            selfTower.CurrCooldown -= Time.deltaTime;
    }

    bool CanShoot()
    {
        if (selfTower.CurrCooldown <= 0)
            return true;
        return false;
    }

    void SearchTarget()
    {
        if (CanShoot())
        {
            Transform nearestEnemy = null;
            float nearestEnemyDistance = Mathf.Infinity;

            foreach (GameObject enemy in GameObject.FindGameObjectsWithTag("Enemy"))
            {
                float currDistance = Vector2.Distance(transform.position, enemy.transform.position);

                if (currDistance < nearestEnemyDistance &&
                   currDistance <= selfTower.range)
                {
                    nearestEnemy = enemy.transform;
                    nearestEnemyDistance = currDistance;
                }
            }

            if (nearestEnemy != null)
                Shoot(nearestEnemy);
        }
    }

    void Shoot(Transform enemy)
    {
        //if(FindObjectOfType<GameManagerSrc>().Volume)
        GetComponent<AudioSource>().Play();//Звук под префаб башни
        GameManagerSrc.Instance.PlayShootSnd();
       
        selfTower.CurrCooldown = selfTower.Cooldown;
        
        GameObject proj = Instantiate(Projectile);
        proj.GetComponent<TowerProjectileScr>().selfTower = selfTower;
        proj.transform.position = transform.position;
        proj.GetComponent<TowerProjectileScr>().setTarget(enemy);
    }
	
}
