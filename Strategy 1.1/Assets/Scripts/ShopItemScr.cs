using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ShopItemScr : MonoBehaviour,IPointerEnterHandler,IPointerExitHandler,IPointerClickHandler {

    Tower selfTower;
    CellSrc selfCell;
    public Image TowerLogo;
    public Text TowerName, TowerPrice;

    public Color currColor, BaseColor;

	public void SetStartData(Tower tower,CellSrc cell)
    {
        selfTower = tower;
        TowerLogo.sprite = tower.Spr;
        TowerName.text = tower.Name;
        TowerPrice.text = tower.Price.ToString();
        selfCell = cell;
    }

    public void OnPointerEnter(PointerEventData eventData)//Навёл
    {
        GetComponent<Image>().color = currColor;
    }

    public void OnPointerExit(PointerEventData eventData)//Отвёл
    {
        GetComponent<Image>().color = BaseColor;
    }

    public void OnPointerClick(PointerEventData eventData)//Нажал
    {
        if (GameManagerSrc.Instance.GameMoney >= selfTower.Price)
        {
            selfCell.BuildTower(selfTower);
            GameManagerSrc.Instance.GameMoney -= selfTower.Price;
        }
    }
}
