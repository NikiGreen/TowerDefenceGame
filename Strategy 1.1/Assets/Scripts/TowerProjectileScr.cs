using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerProjectileScr : MonoBehaviour {

    Transform target;
    TowerProjectile selfProjectile;
    public Tower selfTower;
    GameControllerSrc gsc;
    
    private void Start()
    {
        gsc = FindObjectOfType<GameControllerSrc>();

        selfProjectile = gsc.AllProjectiles[selfTower.type];
        GetComponent<SpriteRenderer>().sprite = selfProjectile.Spr;
    }

    void Update () {
        Move();
	}

    public void setTarget(Transform enemy)
    {
        target = enemy;
    }

    private void Move()
    {

        if (target != null)
        {
            if (Vector2.Distance(transform.position, target.position) < 0.1f)
            {
                Hit();
            }
            else
            {
                Vector2 dir = target.position - transform.position;
                transform.Translate(dir.normalized * Time.deltaTime * selfProjectile.speed);
            }
        }
        else
            Destroy(gameObject);
    }

    void Hit()
    {
        switch (selfTower.type)
        {
            case (int)TowerType.FIRST_TOWER:
                target.GetComponent<EnemySrc>().StartSlow(3,1);//Замедляем на три секунды отнимая от скорости единицу
                target.GetComponent<EnemySrc>().TakeDamage(selfProjectile.damage);
                break;
            case (int)TowerType.SECOND_TOWER:
                target.GetComponent<EnemySrc>().AOEDemage(2,selfProjectile.damage);
                break;
        }
        Destroy(gameObject);
    }
}
