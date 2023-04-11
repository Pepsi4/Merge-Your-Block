using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
public class PlayerMove : MonoBehaviour
{
    [SerializeField] private Joystick _joystick;
    [SerializeField] private float _movingSpeed = 2f;
    private GameStateManager _gameStateManager;

    [Inject]
    private void Construct(GameStateManager gameStateManager)
    {
        _gameStateManager = gameStateManager;
    }

    private void Update()
    {
        if (_gameStateManager.CurrentState == GameState.Play)
            Move();
    }

    private void Move()
    {
        if (_joystick.Horizontal != 0)
        {
            this.transform.position = new Vector3(_joystick.Horizontal * _movingSpeed, this.transform.position.y, this.transform.position.z);
        }
    }
}
