using System;
using UnityEngine;
namespace TZ_24PLAY
{
    public class GameStateManager : MonoBehaviour
    {
        public GameState CurrentState { get; private set; }

        public static Action<GameState> OnGameStateChanged;

        public void UpdateGameState(GameState gameState)
        {
            CurrentState = gameState;

            Debug.Log("<color=orange> Current game state: " + CurrentState + " </color>");
            OnGameStateChanged?.Invoke(gameState);
        }

        private void Start()
        {
            UpdateGameState(GameState.WaitToStart);
        }
    }
}