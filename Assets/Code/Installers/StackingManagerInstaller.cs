using Zenject;
namespace TZ_24PLAY
{
    public class StackingManagerInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            var instance = Container.InstantiateComponentOnNewGameObject<StackingManager>();

            Container.Bind<StackingManager>().FromInstance(instance).AsSingle().NonLazy();
        }
    }
}