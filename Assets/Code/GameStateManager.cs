using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateManager : MonoBehaviour
{
    // private GameState _currentState;

    public static Action<GameState> OnGameStateChanged;

    public void UpdateGameState(GameState gameState)
    {
        // _currentState = gameState;

        switch (gameState)
        {
            case GameState.WaitToStart:
                break;

            case GameState.Play:
                break;

            case GameState.Fail:
                break;

            default: throw new ArgumentOutOfRangeException(nameof(gameState), gameState, null);
        }

        OnGameStateChanged?.Invoke(gameState);
    }

    private void Start()
    {
        UpdateGameState(GameState.WaitToStart);
    }
}
