using System.Collections;
using UnityEngine;
using DG.Tweening;
using Zenject;

namespace TZ_24PLAY
{
    public class CameraShaker : MonoBehaviour
    {
        [SerializeField] private float _duration;
        [SerializeField] private float _strength;

        private StackingManager _stackingManager;

        private static bool _isAvailable = true;
        private const float COOLDOWN_AVAILABLE = 1f;

        [Inject]
        private void Construct(StackingManager stackingManager)
        {
            _stackingManager = stackingManager;
        }

        private void Start()
        {
            _stackingManager.OnWallCollision += OnWallCollisionHandler;
        }

        private void OnDestroy()
        {
            _stackingManager.OnWallCollision -= OnWallCollisionHandler;
        }

        private void OnWallCollisionHandler()
        {
            if (_isAvailable)
            {
                _isAvailable = false;
                StartCoroutine(OnAvailableCooldown());
                Shake();
            }
        }

        private void Shake()
        {
            this.transform.DOShakePosition(_duration, _strength, 10, 70, false, true, ShakeRandomnessMode.Harmonic);
        }

        IEnumerator OnAvailableCooldown()
        {
            yield return new WaitForSeconds(COOLDOWN_AVAILABLE);
            _isAvailable = true;
        }
    }
}