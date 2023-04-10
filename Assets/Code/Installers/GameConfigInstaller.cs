using UnityEngine;
using Zenject;

[CreateAssetMenu(fileName = "GameConfigInstaller", menuName = "Installers/GameConfigInstaller")]
public class GameConfigInstaller : ScriptableObjectInstaller<GameConfigInstaller>
{
    [SerializeField] private MovableConfig _movableConfig;

    public override void InstallBindings()
    {
        Container.Bind<MovableConfig>().FromInstance(_movableConfig).NonLazy();
    }
}