using UnityEngine;
using Zenject;
namespace TZ_24PLAY
{
    public class CubeHolderInstaller : MonoInstaller
    {
        [SerializeField] private CubeHolder _cubeHolder;
        public override void InstallBindings()
        {
            Container.Bind<CubeHolder>().FromInstance(_cubeHolder).AsSingle().NonLazy();
        }
    }
}