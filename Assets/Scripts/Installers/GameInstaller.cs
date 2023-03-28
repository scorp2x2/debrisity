using System;
using UnityEngine;
using Zenject;

public class GameInstaller : MonoInstaller
{
    public Settings settings;
    public SavedController SavedController;
    public ManagerResources ManagerResources;
    public ManagerFactorys ManagerFactorys;

    public GameController GameController;
    public PanelFactorysController PanelFactoriesController;
    public PanelFarmController PanelFarmController;
    public SityController SityController;
    public PanelCardsController PanelCardsController;
    public PanelStatsController PanelStatsController;
    public DayController DayController;

    public Localization Localization;

    public override void InstallBindings()
    {
        Container.Bind<SavedController>().AsSingle();
        Container.Bind<ManagerResources>().FromComponentInNewPrefab(ManagerResources).AsSingle();
        Container.Bind<ManagerFactorys>().FromComponentInNewPrefab(ManagerFactorys).AsSingle();

        Container.BindInstance(GameController).AsSingle();
        Container.BindInstance(PanelFactoriesController).AsSingle();
        Container.BindInstance(PanelFarmController).AsSingle();
        Container.BindInstance(SityController).AsSingle();
        Container.BindInstance(PanelCardsController).AsSingle();
        Container.BindInstance(PanelStatsController).AsSingle();
        Container.BindInstance(DayController).AsSingle();

        Container.BindInstance(Localization).AsSingle();

        Container.BindFactory<SityController, ManagerResources, HumanController, HumanController.Factory>()
                .FromPoolableMemoryPool<SityController, ManagerResources, HumanController, HumanControllerPool>();

        GameSignalInstaller.Install(Container);
    }

    [Serializable]
    public class Settings
    {
        //public Borders Borders;
    }

    class HumanControllerPool : MonoPoolableMemoryPool<SityController, ManagerResources, IMemoryPool, HumanController>
    {
    }
}