using UnityEngine;
using Zenject;

namespace TZ_24PLAY
{
    public class StickmanParticleSystem : MonoBehaviour
    {
        [SerializeField] private ParticleSystem _particles;
        private StackingManager _stackingManager;
        private GameStateManager _gameStateManager;

        [Inject]
        private void Construct(StackingManager stackingManager, GameStateManager gameStateManager)
        {
            _stackingManager = stackingManager;
            _gameStateManager = gameStateManager;
        }

        private void Start()
        {
            _stackingManager.OnNewStackable += OnNewStackableAddedHandler;
        }

        private void OnDestroy()
        {
            _stackingManager.OnNewStackable -= OnNewStackableAddedHandler;
        }

        private void OnNewStackableAddedHandler(Vector3 pos)
        {
            if (_gameStateManager.CurrentState == GameState.Play)
                _particles.Play();
        }
    }
}