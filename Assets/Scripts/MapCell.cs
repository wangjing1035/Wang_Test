using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapCell : MonoBehaviour
{
    private CellState curState = CellState.Empty;
    private int pos = 0;

    public void clear()
    {
        curState = CellState.Empty;
    }

    public void ChangeState()
    {
        curState = CellState.Full;
    }

    public virtual void Init(int pos)
    {
        clear();
        this.pos = pos;

        SetPosition(pos);
    }

    protected void SetPosition(int pos)
    {
        int row = pos / 4;
        int col = pos % 4;

        float posY = row - (Reg.MapRow / 2) * Reg.MapItemWidh;
        float posX = col - (Reg.mapCol / 2) * Reg.MapItemWidh;

        transform.localPosition = new Vector2(posX, posY);
    }
}

public enum CellState
{
    Empty,
    Full
}