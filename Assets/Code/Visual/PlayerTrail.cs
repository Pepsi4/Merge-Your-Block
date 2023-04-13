using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace TZ_24PLAY
{
    public class PlayerTrail : MonoBehaviour
    {
        [SerializeField] ParticleSystem _particleSystem;
        private MovableConfig _config;
        // private ParticleSystem.MainModule _main;

        private const float SIMULATION_SPEED_DEFAULT = 1f;

        [Inject]
        private void Construct(MovableConfig config)
        {
            _config = config;
        }

        private void Awake()
        {
            GameStateManager.OnGameStateChanged += OnGameStateChanged;
        }

        private void OnDestroy()
        {
            GameStateManager.OnGameStateChanged -= OnGameStateChanged;
        }

        private void OnGameStateChanged(GameState state)
        {
            if (state == GameState.Play)
            {
                var main = _particleSystem.main;
                main.simulationSpeed = SIMULATION_SPEED_DEFAULT;
                main.startSpeed = -_config.Speed;
            }
            else
            {
                var main = _particleSystem.main;
                main.simulationSpeed = 0;
            }
        }
    }
}