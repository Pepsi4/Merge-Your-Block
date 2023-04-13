using UnityEngine;
using Zenject;
namespace TZ_24PLAY
{
    public class StickmanInstaller : MonoInstaller
    {
        [SerializeField] private Stickman stickman;
        public override void InstallBindings()
        {
            Container.Bind<Stickman>().FromInstance(stickman).AsSingle().NonLazy();
        }
    }
}