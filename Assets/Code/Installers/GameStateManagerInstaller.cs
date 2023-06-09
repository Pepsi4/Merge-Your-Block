using Zenject;
namespace TZ_24PLAY
{
    public class GameStateManagerInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            var gameStateManagerInstance = Container.InstantiateComponentOnNewGameObject<GameStateManager>();

            Container.Bind<GameStateManager>().
                FromInstance(gameStateManagerInstance).AsSingle().NonLazy();
        }
    }
}