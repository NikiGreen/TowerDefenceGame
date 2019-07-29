using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct Tower
{
    public string Name;
    public int type,Price;
    public float range, Cooldown, CurrCooldown;
    public Sprite Spr;

    public Tower(string Name,int type,float range,float cd,int Price,string path)
    {
        this.Name = Name;
        this.type = type;
        this.range = range;
        Cooldown = cd;
        this.Price = Price;
        Spr = Resources.Load<Sprite>(path);
        CurrCooldown = 0;
    }

}

public struct TowerProjectile
{
    public float speed;
    public int damage;
    public Sprite Spr;

    public TowerProjectile(float speed,int dmge,string path)
    {
        this.speed = speed;
        damage = dmge;
        Spr = Resources.Load<Sprite>(path);
    }
}

public struct Enemy
{
    public float Health,MaxHealth, Speed, StartSpeed;
    public int Bounty;
    public Sprite spr;

    public Enemy(float health, float speed,int bounty,string sprPath)
    {
        MaxHealth=Health = health;
        StartSpeed=Speed = speed;
        Bounty = bounty;

        spr = Resources.Load<Sprite>(sprPath);
    }

  
}

public enum TowerType
{
    FIRST_TOWER,
    SECOND_TOWER
}

public class GameControllerSrc : MonoBehaviour {

    public List<Tower> AllTowers = new List<Tower>();
    public List<TowerProjectile> AllProjectiles = new List<TowerProjectile>();
    public List<Enemy> AllEnemies = new List<Enemy>();

    private void Awake()
    {
        AllTowers.Add(new Tower("FastShooting Tower",0,2,1f,10,"TowerSprites/FTower"));
        AllTowers.Add(new Tower("LargeRange Tower",1,5, 2f,20, "TowerSprites/STower"));

        AllProjectiles.Add(new TowerProjectile(10,10, "ProjectilesSprites/FProjectile"));
        AllProjectiles.Add(new TowerProjectile(9,15, "ProjectilesSprites/SProjectile"));

        AllEnemies.Add(new Enemy(30,3,3, "EnemySprites/enemy1"));
        AllEnemies.Add(new Enemy(20,4,5, "EnemySprites/enemy2"));
    }
}
