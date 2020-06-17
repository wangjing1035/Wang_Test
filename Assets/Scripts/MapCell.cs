using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapCell : MonoBehaviour
{
    private CellState curState = CellState.Empty;
    protected int posX = 0;
    protected int posY = 0;

    public void clear()
    {
        curState = CellState.Empty;
    }

    public void ChangeState()
    {
        curState = CellState.Full;
    }

    public virtual void Init(int posX, int PosY)
    {
        clear();
        this.posX = posX;
        this.posY = PosY;
        SetPosition();
    }

    protected void SetPosition()
    {
        transform.localPosition = GetPos();
    }

    protected Vector2 GetPos()
    {
        float posX = (this.posX - Reg.mapCol / 2) * Reg.MapItemWidh;
        float posY = (this.posY - Reg.MapRow / 2) * Reg.MapItemWidh;
        return new Vector2(posX, posY);
    }
}

public enum CellState
{
    Empty,
    Full
}