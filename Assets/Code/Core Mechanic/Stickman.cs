using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace TZ_24PLAY
{
    [RequireComponent(typeof(Animator))]
    public class Stickman : MonoBehaviour
    {
        private Animator _animator;
        private int _jumpAnimation = Animator.StringToHash("Jumping");
        private StackingManager _stackingManager;
        [Inject]
        private void Construct(StackingManager stackingManager)
        {
            _stackingManager = stackingManager;
        }

        private void Start()
        {
            _stackingManager.OnNewStackable += OnNewStackableAddedHandler;
            _stackingManager.SetStickman(this);
            _animator = this.GetComponent<Animator>();
        }

        private void OnDestroy()
        {
            _stackingManager.OnNewStackable -= OnNewStackableAddedHandler;
        }

        public void Jump()
        {
            _animator.CrossFade(_jumpAnimation, 0f);
        }

        public void ApplyPosition(float y)
        {
            this.transform.localPosition = new Vector3(this.transform.localPosition.x, y, this.transform.localPosition.z);
        }

        private void OnNewStackableAddedHandler(float y)
        {
            ApplyPosition(y);
            Jump();
        }
    }
}