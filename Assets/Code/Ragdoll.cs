using System.Collections.Generic;
using UnityEngine;
using System.Linq;
namespace TZ_24PLAY
{
    public class Ragdoll : MonoBehaviour
    {
        [SerializeField] private bool _isKinematicOnStart = true;
        private List<Rigidbody> _childrenRigidbodies;
        private void Awake()
        {
            _childrenRigidbodies = this.gameObject.GetComponentsInChildren<Rigidbody>().ToList();
        }

        private void Start()
        {
            SetChildrenRigibodiesKinematic(_isKinematicOnStart);
        }

        private void SetChildrenRigibodiesKinematic(bool isKinematic)
        {
            _childrenRigidbodies.ForEach(rb => rb.isKinematic = isKinematic);
        }
    }
}