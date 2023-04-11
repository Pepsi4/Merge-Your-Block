using UnityEngine;
using Zenject;
using DG.Tweening;

public class Movable : MonoBehaviour, IMovable
{
    private MovableConfig _movableConfig;
    private Tween _moveTween;
    private float _endPointZ;
    private float _speed;

    [Inject]
    public void Consturct(MovableConfig gameConfig)
    {
        _movableConfig = gameConfig;
    }

    public void Move()
    {
        _moveTween = this.transform.DOMoveZ(_endPointZ, _speed).SetSpeedBased(true);
    }

    public void Stop()
    {
        _moveTween?.Kill();
    }

    private void Start()
    {
        Init();
    }

    private void Init()
    {
        _endPointZ = _movableConfig.MovableEndPointZ;
        _speed = _movableConfig.MovableSpeed;
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
                Move();
                break;

            default:
                Stop();
                break;
        }
    }
}
