using UnityEngine;
using Zenject;
using DG.Tweening;
namespace TZ_24PLAY
{
    public class Movable : MonoBehaviour, IMovable
    {
        [SerializeField] private Vector3 _randomSpawnRange;
        [SerializeField] private bool _moveOnStart = true;
        [SerializeField] private float _replaceOnZ;

        private MovableConfig _movableConfig;
        private Tween _moveTween;
        private float _endPointZ;
        private float _speed;
       [SerializeField] private Transform _spawnPos;

        [Inject]
        private void Construct(MovableConfig gameConfig)
        {
            _movableConfig = gameConfig;
        }

        private void Start()
        {
            Init();
        }

        public void Replace()
        {
            this.transform.position = new Vector3(
                _spawnPos.position.x + UnityEngine.Random.Range(-_randomSpawnRange.x, _randomSpawnRange.x),
                _spawnPos.position.y + UnityEngine.Random.Range(-_randomSpawnRange.y, _randomSpawnRange.y),
                _spawnPos.position.z + UnityEngine.Random.Range(-_randomSpawnRange.z, _randomSpawnRange.z));
        }

        public void Restart()
        {
            //_moveTween.Restart();
            Stop();
            Replace();
            Move();
        }

        public void Move()
        {
            _moveTween = this.transform.DOMoveZ(_endPointZ, _speed).SetSpeedBased(true);
            _moveTween.Play();
        }

        public void Stop()
        {
            _moveTween?.Kill();
        }

        private void FixedUpdate()
        {
            if (this.transform.position.z < _replaceOnZ)
                Restart();
        }

        private void Init()
        {
            _endPointZ = _movableConfig.EndPointZ;
            _speed = _movableConfig.Speed;
        }

        private void OnEnable()
        {
            GameStateManager.OnGameStateChanged += OnGameStateChanged;
        }

        private void OnDisable()
        {
            GameStateManager.OnGameStateChanged -= OnGameStateChanged;
        }

        private void OnGameStateChanged(GameState gameState)
        {
            switch (gameState)
            {
                case GameState.Play:
                    if (_moveOnStart)
                        Move();
                    break;

                default:
                    Stop();
                    break;
            }
        }
    }
}