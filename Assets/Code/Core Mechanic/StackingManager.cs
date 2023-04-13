using System.Collections.Generic;
using UnityEngine;
using System;
using Zenject;
using DG.Tweening;
using System.Collections;

namespace TZ_24PLAY
{
    public class StackingManager : MonoBehaviour
    {
        public event Action<float> OnNewStackable;
        public Action<Transform> OnWallCollision;

        private List<CubePickup> _stack;
        private CubeHolder _cubeHolder;
        private PlayerCubeHolder _playerCubeHolder;
        private GameStateManager _gameStateManager;
        private Stickman _stickman;

        private const float DELAY_AFTER_COLLISION = 0.6f;
        private const float STACKING_SPEED = 3f;

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
            try { _stack[0].IsMainCube = true; }
            catch (ArgumentOutOfRangeException) { }
        }

        private void ApplyPosition(CubePickup cubePickup)
        {
            cubePickup.transform.localPosition = new Vector3(0, CurrentHeight(), 0);
        }

        public void SetStickman(Stickman stickman)
        {
            _stickman = stickman;
        }

        public void ApplyStackPosition()
        {
            StartCoroutine(ApplyStackPositionAFterDelay());
        }

        private IEnumerator ApplyStackPositionAFterDelay()
        {
            yield return new WaitForSeconds(DELAY_AFTER_COLLISION);
            if (_gameStateManager.CurrentState != GameState.Play) yield break;

            float height = 0;
            for (int i = 0; i < _stack.Count; i++)
            {
                _stack[i].transform.DOLocalMoveY(height, STACKING_SPEED).SetSpeedBased(true);

                height += _stack[i].Height;
            }

            _stickman.transform.DOLocalMoveY(height, STACKING_SPEED).SetSpeedBased(true);
        }

        private float CurrentHeight(float height = 0)
        {
            _stack.ForEach(cubePickup => height += cubePickup.Height);
            return height;
        }
    }
}