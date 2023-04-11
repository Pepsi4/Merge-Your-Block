using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace TZ_24PLAY
{
    [RequireComponent(typeof(Stackable))]
    public class PlayerCube : MonoBehaviour
    {
        private StackingManager _stackingManager;

        [Inject]
        private void Construct(StackingManager stackingManager)
        {
            _stackingManager = stackingManager;
        }

        private void Start()
        {
            _stackingManager.Add(this.GetComponent<Stackable>());
        }


        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.TryGetComponent(out StackableMovable stackable))
            {
                _stackingManager.Add(stackable);
                _stackingManager.StopMove(stackable);
            }
        }
    }
}