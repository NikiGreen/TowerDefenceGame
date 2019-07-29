using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyTowerScr : MonoBehaviour {

    public CellSrc SelfCell;


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            Destroy(gameObject);
    }

    public void Confirm()
    {
        SelfCell.DestroyTower();
        Cancel();
    }

    public void Cancel()
    {
        Destroy(gameObject);
    }
        
}
 