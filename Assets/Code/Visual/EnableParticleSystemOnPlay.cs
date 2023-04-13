using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace TZ_24PLAY
{
    public class EnableParticleSystemOnPlay : MonoBehaviour
    {
        [SerializeField] ParticleSystem _particleSystem;
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
                _particleSystem.Play();
            else
                _particleSystem.Stop();
        }
    }
}