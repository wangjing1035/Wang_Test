using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GameMap : MonoBehaviour
{
    [SerializeField] private MapCell mapcellPre;
    [SerializeField] private MapItem mapItemPre;

    private int col = 4, row = 4;


    private MapCell[,] listMapCell = new MapCell[Reg.mapCol, Reg.MapRow];
    private MapItem[,] listMapItem = new MapItem[Reg.mapCol, Reg.MapRow];

    private int allGridNum = 0;

    private void OnEnable()
    {
        GameEventer.StartGame.AddListener(InitMap);
    }

    private void OnDisable()
    {
        GameEventer.StartGame.RemoveListener(InitMap);
    }

    public void InitMap()
    {
        col = Reg.mapCol;
        row = Reg.MapRow;
        allGridNum = col * row;

        for (int i = 0; i < col; i++)
        {
            for (int j = 0; j < row; j++)
            {
                if (listMapCell[i, j] != null)
                {
                    listMapCell[i, j].Init(i, j);
                }
                else
                {
                    MapCell mapcel = Instantiate(mapcellPre, transform);
                    mapcel.Init(i, j);
                    listMapCell[i, j] = mapcel;
                }
            }
        }

        for (int i = 0; i < col; i++)
        {
            for (int j = 0; j < row; j++)
            {
                if (listMapItem[i, j] != null)
                {
                    listMapItem[i, j].Init(i, j,0);
                }
                else
                {
                    MapItem mapitem = Instantiate(mapItemPre, transform);
                    mapitem.Init(i, j,0);
                    listMapItem[i, j] = mapitem;
                }
                listMapItem[i, j].gameObject.SetActive(false);
            }
        }

        
        //初始化地图上面两个item
        for (int i = 0; i < Reg.InitItemNum; i++)
        {
            int pos1 = Random.Range(0, Reg.mapCol);
            int pos2 = Random.Range(0, Reg.MapRow);

        
            int score = 2;
            if ( Random.Range(0, 100)> 60)
            {
                score = 4;
            }
                
            while (listMapItem[pos1, pos2] != null && listMapItem[pos1, pos2].gameObject.activeSelf)
            {
                pos1 = Random.Range(0, Reg.mapCol);
                pos2 = Random.Range(0, Reg.MapRow);
            }

            listMapItem[pos1,pos2].Init(pos1,pos2,score);
            listMapItem[pos1,pos2].gameObject.SetActive(true);
        }
    }

    public void Move(MoveDir dir)
    {
        switch (dir)
        {
            case MoveDir.left:
                MoveLeft();
                break;
            case MoveDir.right:
                MoveRight();
                break;
            case MoveDir.up:
                MoveUp();
                break;
            case MoveDir.down:
                MoveDown();
                break;
            case MoveDir.none:
                break;
        }
    }

    public void MoveLeft()
    {
        Debug.LogError("MoveLeft");
    }

    public void MoveRight()
    {
        Debug.LogError("MoveRight");
    }

    public void MoveUp()
    {
        Debug.LogError("MoveUp");
    }

    private List<MapItem> comBineItemList = new List<MapItem>();
    private List<MapItem> completeCombine = new List<MapItem>();
    public void MoveDown()
    {
        Debug.LogError("MoveDown");
        for (int i = 0; i < Reg.MapRow; i++)
        {
            comBineItemList.Clear();
            for (int j = Reg.mapCol -1 ; j >= 0; j--)
            {
                if (GetCurPosState(i,j))
                {
                     comBineItemList.Add(listMapItem[i,j]);           
                }
            }

            completeCombine.Clear();
        
            if (comBineItemList.Count > 2)
            {
                completeCombine = CalCombileList(comBineItemList);
            }
            else
            {
                completeCombine = comBineItemList;
            }
            int m = 0;
            for (int j = Reg.mapCol -1 ; j >= 0; j--)
            {
                
                if ( m < completeCombine.Count )
                {
                    listMapItem[j, i] = completeCombine[m];
                    listMapItem[j, i].gameObject.SetActive(true);
                    listMapCell[j,i].ChangeState();
                    m++;
                }
                else
                {
                    listMapItem[j, i].gameObject.SetActive(false);
                    listMapCell[j,i].clear();
                }

                listMapItem[j, i].MoveToPos(i, j);

            }
        }
    }

    private List<MapItem> comBineCompleteList = new List<MapItem>();
    private List<MapItem> CalCombileList(List<MapItem> mapitemList)
    {
        comBineCompleteList.Clear();
        MapItem item = mapitemList[0];
        if (mapitemList.Count > 2)
        {
            for (int i = 1; i < mapitemList.Count; i++)
            {
                if (mapitemList[i].Score == item.Score)
                {
                    mapitemList[i].Score *= 2; 
                    comBineCompleteList.Add(mapitemList[i]);
                    item = mapitemList[i];
                }
                else
                {
                    comBineCompleteList.Add(item);
                    item =  mapitemList[i];
                }
            }
        }

        return comBineCompleteList;
    }

    private bool GetCurPosState(int posX, int posY)
    {
        if (listMapItem[posX,posY] != null && listMapItem[posX,posY].gameObject.activeSelf)
        {
            return true;
        }

        return false;
    }
        
}