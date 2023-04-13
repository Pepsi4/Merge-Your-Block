using UnityEngine;
using Zenject;
using Redcode.Pools;
using DG.Tweening;

namespace TZ_24PLAY
{
    public class PopUpTextPool : MonoBehaviour
    {
        [SerializeField] private Transform _popUpTextPrefab;
        [SerializeField] private Vector3 _endPoint;
        [SerializeField] private float _speed;
        private StackingManager _stackingManager;
        private GameStateManager _gameStateManager;
        private Pool<Transform> _pool;

        [Inject]
        private void Construct(StackingManager stackingManager, GameStateManager gameStateManager)
        {
            _stackingManager = stackingManager;
            _gameStateManager = gameStateManager;
        }

        private void Start()
        {
            _stackingManager.OnNewStackable += OnNewStackableHandler;
            _pool = Pool.Create(_popUpTextPrefab, 0, this.transform);
        }

        private void OnDestroy()
        {
            _stackingManager.OnNewStackable -= OnNewStackableHandler;
        }

        private void OnNewStackableHandler(Vector3 pos)
        {
            if (_gameStateManager.CurrentState != GameState.Play) return;

            Transform text = _pool.Get();
            text.position = pos;
            text.DOMove(_endPoint, _speed).SetSpeedBased(true).OnComplete(() => _pool.Take(text));
        }
    }
}