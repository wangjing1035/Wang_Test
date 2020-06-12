using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GameMap : MonoBehaviour
{
    [SerializeField] private MapCell mapcellPre;
    [SerializeField] private MapItem mapItemPre;

    private int col = 4, row = 4;

    private int[,] map = new int[4, 4];

    private List<MapCell> listMapCell = new List<MapCell>();
    private List<MapItem> listMapItem = new List<MapItem>();

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
                int index = i * col + j;
                if (index < listMapCell.Count )
                {
                    listMapCell[index].Init(index);
                }
                else
                {
                    MapCell mapcel = Instantiate(mapcellPre, transform);
                    mapcel.Init(index);
                    listMapCell.Add(mapcel);
                }
            }
        }

        InitMapItem();
    }

    public void InitMapItem()
    {
        int pos1 = Random.Range(0, allGridNum);
        int pos2 = Random.Range(0, allGridNum);
        while (pos1 == pos2)
        {
            pos2 = Random.Range(0, allGridNum);
        }

        AddNewMapItem(pos1);
        AddNewMapItem(pos2);
    }

    public void AddNewMapItem(int pos)
    {
        MapItem item = null;
        if (pos < allGridNum)
        {
            foreach (var value in listMapItem)
            {
                if (! value.gameObject.activeSelf)
                {
                    item = value;
                    break;
                }
            }

            if (item == null)
            {
                item = Instantiate(mapItemPre, transform);
                listMapItem.Add(item);
            }
           
            item.Init(pos);
            listMapCell[pos].ChangeState();
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
    }

    public void MoveRight()
    {
    }

    public void MoveUp()
    {
    }

    public void MoveDown()
    {
    }
}