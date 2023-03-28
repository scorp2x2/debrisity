using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class MenuInstaller : MonoInstaller
{
    public Settings settings;
    public SavedController SavedController;
    public ManagerResources ManagerResources;
    public HumanSkinMagazin PrefabSkin;
    public MagazinController MagazinController;
    public ManagerFactorys ManagerFactorys;
    public Localization Localization;

    public override void InstallBindings()
    {
        Container.Bind<SavedController>().AsSingle();
        Container.Bind<ManagerResources>().FromComponentInNewPrefab(ManagerResources).AsSingle();
        Container.Bind<ManagerFactorys>().FromComponentInNewPrefab(ManagerFactorys).AsSingle();
        Container.BindInstance(MagazinController).AsSingle();
        Container.BindInstance(Localization).AsSingle();

        Container.BindFactory<HumanSkin, SavedController, HumanSkinMagazin, HumanSkinMagazin.Factory>()
                .FromPoolableMemoryPool<HumanSkin, SavedController, HumanSkinMagazin, HumanSkinMagazinPool>(poolBinder => poolBinder
                .FromComponentInNewPrefab(PrefabSkin));

        GameSignalInstaller.Install(Container);
    }

    [Serializable]
    public class Settings
    {
        //public Borders Borders;
    }

    class HumanSkinMagazinPool : MonoPoolableMemoryPool<HumanSkin, SavedController, IMemoryPool, HumanSkinMagazin>
    {
    }
}
