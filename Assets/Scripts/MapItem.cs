using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapItem : MapCell
{
    private int score = 0;
    private int pos = 0;
    public void Init( int pos ,int score = 0)
    {
        this.score = score;
        this.pos = pos;
        
        SetPosition(pos);
    }
}

