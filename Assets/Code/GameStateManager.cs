using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateManager : MonoBehaviour
{
    public GameState CurrentState { get; private set; }

    public static Action<GameState> OnGameStateChanged;

    public void UpdateGameState(GameState gameState)
    {
        CurrentState = gameState;

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

        Debug.Log("<color=orange> Current game state: " + CurrentState + " </color>");
        OnGameStateChanged?.Invoke(gameState);
    }

    private void Start()
    {
        UpdateGameState(GameState.WaitToStart);
    }
}
