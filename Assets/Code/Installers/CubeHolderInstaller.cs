using UnityEngine;
using Zenject;
namespace TZ_24PLAY
{
    public class CubeHolderInstaller : MonoInstaller
    {
        [SerializeField] private CubeHolder _cubeHolder;
        [SerializeField] private PlayerCubeHolder _playerCubeHolder;
        public override void InstallBindings()
        {
            Container.Bind<CubeHolder>().FromInstance(_cubeHolder).AsSingle().NonLazy();
            Container.Bind<PlayerCubeHolder>().FromInstance(_playerCubeHolder).AsSingle().NonLazy();
        }
    }
}