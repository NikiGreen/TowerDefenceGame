using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CellSrc : MonoBehaviour {

    public bool isGround;

    public Color BaseColor, CurrColor,DestroyColor;

    public GameObject ShopPref,TowerPref;

    public GameObject DestroyPanel;

    public GameObject SelfTower;

    private void OnMouseEnter()
    {
        if (!isGround && FindObjectsOfType<ShopScr>().Length==0
            && FindObjectsOfType<DestroyTowerScr>().Length==0)
            if(!SelfTower)
            GetComponent<SpriteRenderer>().color = CurrColor;
        else
            GetComponent<SpriteRenderer>().color = CurrColor;
    }

    private void OnMouseExit()
    {
        GetComponent<SpriteRenderer>().color = BaseColor;
    }

    private void OnMouseDown()
    {
        if(!isGround && FindObjectsOfType<ShopScr>().Length == 0
            && GameManagerSrc.Instance.canSpawn && FindObjectsOfType<DestroyTowerScr>().Length == 0)
            if (!SelfTower)
            {
                GameObject shopObj = Instantiate(ShopPref);
                shopObj.transform.SetParent(GameObject.Find("Canvas").transform, false);
                shopObj.GetComponent<ShopScr>().selfCell = this;
            }
            else
            {
                GameObject towrDestr = Instantiate(DestroyPanel);
                towrDestr.transform.SetParent(GameObject.Find("Canvas").transform, false);
                towrDestr.GetComponent<DestroyTowerScr>().SelfCell = this;
            }
    }

    public void BuildTower(Tower tower)
    {
        GameObject tmpTower = Instantiate(TowerPref);
        tmpTower.transform.SetParent(transform, false);
        Vector2 towerPos = new Vector2(transform.position.x + /*tmpTower.GetComponent<SpriteRenderer>().bounds.size.x / 2*/(float)0.5,
                                       transform.position.y - /*tmpTower.GetComponent<SpriteRenderer>().bounds.size.y / 2*/(float)0.3);
        tmpTower.transform.position = towerPos;
            
        tmpTower.GetComponent<TowerScr>().selfType = (TowerType)tower.type;

        SelfTower = tmpTower;
        FindObjectOfType<ShopScr>().CloseShop();
    }

    public void DestroyTower()
    {
        GameManagerSrc.Instance.GameMoney += (SelfTower.GetComponent<TowerScr>().selfTower.Price / 2);
        Destroy(SelfTower);
    }
}
