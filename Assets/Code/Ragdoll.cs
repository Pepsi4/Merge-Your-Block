using System.Collections.Generic;
using UnityEngine;
using System.Linq;
namespace TZ_24PLAY
{
    public class Ragdoll : MonoBehaviour
    {
        [SerializeField] private bool _isKinematicOnStart = true;
        [SerializeField] Animator _animator;
        private List<Rigidbody> _childrenRigidbodies;

        private void Awake()
        {
            _childrenRigidbodies = this.gameObject.GetComponentsInChildren<Rigidbody>().ToList();
        }

        private void Start()
        {
            SetChildrenRigibodiesKinematic(_isKinematicOnStart);
            GameStateManager.OnGameStateChanged += OnGameStateChanged;
        }

        private void OnDestroy()
        {
            GameStateManager.OnGameStateChanged -= OnGameStateChanged;
        }

        private void DisableAnimator()
        {
            _animator.enabled = false;
        }

        private void SetChildrenRigibodiesKinematic(bool isKinematic)
        {
            _childrenRigidbodies.ForEach(rb => rb.isKinematic = isKinematic);
        }

        private void OnGameStateChanged(GameState state)
        {
            switch (state)
            {
                case GameState.Fail:
                    SetChildrenRigibodiesKinematic(false);
                    DisableAnimator();
                    break;

                default:
                    SetChildrenRigibodiesKinematic(true);
                    break;
            }
        }
    }
}