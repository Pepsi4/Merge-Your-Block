using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Zenject;
namespace TZ_24PLAY
{
    public class StackingManager : MonoBehaviour
    {
        private List<Stackable> _stack;
        public event Action<float> OnNewStackable;
        private CubeHolder _cubeHolder;

        [Inject]
        private void Construct(CubeHolder cubeHolder)
        {
            _cubeHolder = cubeHolder;
        }


        private void Awake()
        {
            _stack = new List<Stackable>();
        }

        public void Add(Stackable stackable)
        {
            stackable.transform.parent = _cubeHolder.transform;
            ApplyPosition(stackable);
            _stack.Add(stackable);
            OnNewStackable?.Invoke(CurrentHeight());
        }

        public void Remove()
        {

        }

        public void StopMove(StackableMovable stackable)
        {
            stackable.Movable.Stop();
        }

        private void ApplyPosition(Stackable stackable)
        {
            stackable.transform.localPosition = new Vector3(0, CurrentHeight(), 0);

            //for (int i = 1; i < _stack.Count; i++)
            //{
            //    _stack[i].transform.position = new Vector3(_stack[i].transform.position.x, i * _stack[i].Height, _stack[i].transform.position.z);
            //}
        }

        private float CurrentHeight(float height = 0)
        {
            _stack.ForEach(stackable => height += stackable.Height);
            return height;
        }
    }
}