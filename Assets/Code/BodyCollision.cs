using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace TZ_24PLAY
{
    public class BodyCollision : MonoBehaviour
    {
        private GameStateManager _gameStateManager;

        [Inject]
        private void Construct(GameStateManager gameStateManager)
        {
            _gameStateManager = gameStateManager;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.TryGetComponent(out CubeWall cubeWall))
            {
                _gameStateManager.UpdateGameState(GameState.Fail);
            }
        }
    }
}