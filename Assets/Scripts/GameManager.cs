using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager
{
    public static GameManager instance = null;

    public GameState gameState = GameState.Lobby;

    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new GameManager();
            }

            return instance;
        }
    }

    public void GameStart()
    {
        gameState = GameState.Playing;
        GameEventer.StartGame?.Invoke();
    }

    public void GameEnd()
    {
        gameState = GameState.GameEnd;
    }
}


public enum GameState
{
    Lobby,
    Playing,
    GameEnd
}