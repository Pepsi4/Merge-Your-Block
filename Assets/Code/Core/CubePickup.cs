using UnityEngine;
using Zenject;

namespace TZ_24PLAY
{
    [RequireComponent(typeof(Movable))]
    public class CubePickup : MonoBehaviour
    {
        [field: SerializeField] public bool IsMainCube { get; set; }
        [field: SerializeField] public float Height { get; private set; }

        private Movable _movable;
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
            if (IsMainCube)
                _stackingManager.Add(this.GetComponent<CubePickup>());

            _movable = GetComponent<Movable>();
        }

        public void StopMove()
        {
            _movable.Stop();
        }

        public void StartMove()
        {
            if (_gameStateManager.CurrentState == GameState.Play)
                _movable.Move();
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.TryGetComponent(out CubePickup cubePickup) && IsMainCube)
            {
                _stackingManager.Add(cubePickup);
                cubePickup.StopMove();
            }

            if (collision.gameObject.TryGetComponent(out CubeWall cubeWall))
            {
                OnWallCollision();
            }
        }

        private void OnWallCollision()
        {
            _stackingManager.OnWallCollision?.Invoke();
            StartMove();

            if (IsMainCube)
                _stackingManager.ApplyStackPosition();

            IsMainCube = false;
            _stackingManager.Remove(this);
        }
    }
}