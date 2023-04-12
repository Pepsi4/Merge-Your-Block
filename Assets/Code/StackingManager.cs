using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Zenject;
namespace TZ_24PLAY
{
    public class StackingManager : MonoBehaviour
    {
        private List<CubePickup> _stack;
        public event Action<float> OnNewStackable;
        private CubeHolder _cubeHolder;
        private PlayerCubeHolder _playerCubeHolder;
        private GameStateManager _gameStateManager;

        [Inject]
        private void Construct(PlayerCubeHolder playerCubeHolder, CubeHolder cubeHolder, GameStateManager gameStateManager)
        {
            _playerCubeHolder = playerCubeHolder;
            _cubeHolder = cubeHolder;
            _gameStateManager = gameStateManager;
        }

        private void Awake()
        {
            _stack = new List<CubePickup>();
        }

        public void Add(CubePickup cubePickup)
        {
            cubePickup.transform.parent = _playerCubeHolder.transform;
            ApplyPosition(cubePickup);
            _stack.Add(cubePickup);
            OnNewStackable?.Invoke(CurrentHeight());
        }

        public void Remove(CubePickup cubePickup)
        {
            cubePickup.transform.parent = _cubeHolder.transform;
            _stack.Remove(cubePickup);
            SetMainCube();
        }

        private void SetMainCube()
        {
            try
            {
                _stack[0].IsMainCube = true;
            }
            catch (ArgumentOutOfRangeException) { _gameStateManager.UpdateGameState(GameState.Fail); }
        }


        private void ApplyPosition(CubePickup cubePickup)
        {
            cubePickup.transform.localPosition = new Vector3(0, CurrentHeight(), 0);
        }

        private float CurrentHeight(float height = 0)
        {
            _stack.ForEach(cubePickup => height += cubePickup.Height);
            return height;
        }
    }
}