using UnityEngine;
using Zenject;
using System.Collections;

namespace TZ_24PLAY
{
    public class DeviceVibration : MonoBehaviour
    {
        private StackingManager _stackingManager;

        private const float COOLDOWN_AVAILABLE = 1f;
        private static bool _isAvailable = true;

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
                Handheld.Vibrate();
                _isAvailable = false;
                StartCoroutine(OnAvailableCooldown());
            }
        }

        IEnumerator OnAvailableCooldown()
        {
            yield return new WaitForSeconds(COOLDOWN_AVAILABLE);
            _isAvailable = true;
        }
    }
}