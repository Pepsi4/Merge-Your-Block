using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
namespace TZ_24PLAY
{
    public class Stackable : MonoBehaviour
    {
        [field: SerializeField]
        public float Height { get; private set; }
    }

}