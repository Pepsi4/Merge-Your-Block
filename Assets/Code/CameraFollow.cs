using UnityEngine;
using DG.Tweening;
public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private float _speed;
    [SerializeField] private float _followMultiplierX = .2f;

    [SerializeField] private Vector3 _offset;


    private void FixedUpdate()
    {
        FollowOnX();
    }

    private void FollowOnX()
    {
        this.gameObject.transform.DOMoveX((_target.position.x * _followMultiplierX) + _offset.x, _speed);
    }
}