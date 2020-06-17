using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class MapItem : MapCell
{
    [SerializeField] private Text scoreText;
    private int age;
    public int Score
    {
        get { return age;}
        set
        {
            age = value;
            scoreText.text = age.ToString();
        }
    }

    public void Init(int posX, int posY, int score = 0)
    {
        base.Init(posX, posY);
        Score = score;
        SetPosition();
    }

    public void MoveToPos(int posX,int posY)
    {
        this.posX = posX;
        this.posY = posY;
        transform.DOLocalMove(GetPos(),0.2f);
    }
}