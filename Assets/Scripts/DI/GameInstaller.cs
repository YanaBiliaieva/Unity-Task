using UnityEngine;
using Zenject;

namespace DI
{
    public class GameInstaller : MonoInstaller
    {
        [SerializeField] private WindowsManager windowManager;
        [SerializeField] private StageWindowView stageView;
        [SerializeField] private MainMenuWindowView mainMenuView;

        public override void InstallBindings()
        {
            Container.Bind<StageWindowView>().FromInstance(stageView).AsSingle();
            Container.Bind<MainMenuWindowView>().FromInstance(mainMenuView).AsSingle();
            Container.Bind<WindowsManager>().FromInstance(windowManager).AsSingle();
            Container.Bind<StageWindowController>().AsSingle().NonLazy();
            Container.Bind<MainMenuWindowController>().AsSingle().NonLazy();
            Container.Bind<GameController>().AsSingle().NonLazy();
            Container.Bind<CameraHelper>().AsSingle();
        }
    }
}