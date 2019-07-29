using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopScr : MonoBehaviour {

    public GameObject ItemPref;
    public Transform ItemGrid;

    GameControllerSrc gcs;

    public CellSrc selfCell;

	void Start () {

        gcs = FindObjectOfType<GameControllerSrc>();

        foreach(Tower tower in gcs.AllTowers)
        {
            GameObject tmpItem = Instantiate(ItemPref);
            tmpItem.transform.SetParent(ItemGrid, false);
            tmpItem.GetComponent<ShopItemScr>().SetStartData(tower,selfCell);
        }
		
	}
	
	public void CloseShop()
    {
        Destroy(gameObject);
    }
}
