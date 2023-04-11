using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TZ_24PLAY
{
    [RequireComponent(typeof(Movable))]
    public class StackableMovable : Stackable
    {
        public Movable Movable { get; private set; }

        private void Start()
        {
            Movable = GetComponent<Movable>();
        }
    }
}