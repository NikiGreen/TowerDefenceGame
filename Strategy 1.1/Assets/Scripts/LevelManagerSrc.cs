using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class LevelManagerSrc : MonoBehaviour {

    public int fieldWidth, fieldHeight;
    public GameObject cellPref;




    public Transform cellParent;

    public Sprite[] tileSpr = new Sprite[2];

   public List<GameObject> wayPoints = new List<GameObject>();
    GameObject[,] allCells = new GameObject[10,17 ];

    int currWayX, currWayY;
    GameObject firstCell;

    void Start()
    {
        //CreateLevel();
        
    }

   public void CreateLevel(int NumberOfLevel)
    {
        wayPoints.Clear();
        firstCell = null;

        Vector3 worldVec = Camera.main.ScreenToWorldPoint(new Vector3(0, Screen.height, 0));

        for (int i = 0; i < fieldHeight; i++)
            for (int k = 0; k < fieldWidth; k++)
            {
                int sprIndex = int.Parse(LoadLevelText(NumberOfLevel)[i].ToCharArray()[k].ToString());
                Sprite Spr = tileSpr[sprIndex] ;

                bool isGround = Spr == tileSpr[1] ? true : false;

                CreateCell(isGround,Spr,k, i,worldVec);
            }

        LoadWaypoints();
    }

    void CreateCell(bool isGround,Sprite Spr,int x, int y,Vector3 wV)
    {
        GameObject tmpCell = Instantiate(cellPref);
        tmpCell.transform.SetParent(cellParent, false);

        tmpCell.GetComponent<SpriteRenderer>().sprite = Spr;

        float sprSizeX = tmpCell.GetComponent<SpriteRenderer>().bounds.size.x;//Размер спрайта ячейки
        float sprSizeY = tmpCell.GetComponent<SpriteRenderer>().bounds.size.y;

        tmpCell.transform.position = new Vector3(wV.x+(sprSizeX*x), wV.y + (sprSizeY * -y));

        if (isGround)
        {
            tmpCell.GetComponent<CellSrc>().isGround = true;

            if (firstCell == null)
            {
                firstCell = tmpCell;
                currWayX = x;
                currWayY = y;
            }
        }

        allCells[y, x] = tmpCell;
    } 

    string[] LoadLevelText(int i)
    {
        TextAsset tmpTxt = Resources.Load<TextAsset>("Level" + i + "Ground");

        string tmpStr = tmpTxt.text.Replace(Environment.NewLine, string.Empty);

        return tmpStr.Split('!');
    }

    void LoadWaypoints()
    {
        GameObject currWayGO;
        wayPoints.Add(firstCell);
        
        while(true)
        {
            currWayGO = null;
            //Начало поиска пути
            if (currWayX > 0 && allCells[currWayY, currWayX - 1].GetComponent<CellSrc>().isGround &&//Проверка правого соседа на наличие пути
                !wayPoints.Exists(x => x == allCells[currWayY, currWayX - 1]))
            {
                currWayGO = allCells[currWayY, currWayX - 1];
                currWayX--;
                Debug.Log("Next Cell is Left");
            }

            else if (currWayX < (fieldWidth - 1) && allCells[currWayY, currWayX + 1].GetComponent<CellSrc>().isGround &&//Проверка левого соседа на наличие пути
                !wayPoints.Exists(x => x == allCells[currWayY, currWayX + 1]))
            {
                currWayGO = allCells[currWayY, currWayX + 1];
                currWayX++;
                Debug.Log("Next Cell is Right");
            }

            else if (currWayY > 0 && allCells[currWayY - 1, currWayX].GetComponent<CellSrc>().isGround &&//Проверка верхней ячейки
               !wayPoints.Exists(x => x == allCells[currWayY - 1, currWayX]))
            {
                currWayGO = allCells[currWayY - 1, currWayX];
                currWayY--;
                Debug.Log("Next Cell is Up");
            }

            else if (currWayY < (fieldHeight - 1) && allCells[currWayY + 1, currWayX].GetComponent<CellSrc>().isGround &&//Проверка нижней ячейки
             !wayPoints.Exists(x => x == allCells[currWayY + 1, currWayX]))
            {
                currWayGO = allCells[currWayY + 1, currWayX];
                currWayY++;
                Debug.Log("Next Cell is Down");
            }
            else
                break;

            wayPoints.Add(currWayGO);
        }
    
    }

   
}
