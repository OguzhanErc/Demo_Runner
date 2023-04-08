using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public GameState state;

    public static event Action<GameState> OnGameStateChanged;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        UpdateGameState(GameState.BeforeStarting);
    }
    public void UpdateGameState(GameState newState)
    {
        state = newState;

        switch (newState)
        {
            case GameState.BeforeStarting:
                PlayerDance();
                break;
            case GameState.Playtime:
                RunningStart();
                break;
            case GameState.Endgame:
                PaintingStage();
                break;
            default:
                break;
        }

        OnGameStateChanged?.Invoke(newState);
    }

    private void PaintingStage()
    {
    
    }

    private void RunningStart()
    {
       
    }

    private void PlayerDance()
    {
        
    }

    public enum GameState
    {
        BeforeStarting,
        Playtime,
        Endgame
    }
}
