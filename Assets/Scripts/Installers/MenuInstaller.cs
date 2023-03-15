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

    //public SaveController SaveController;
    //public Game Game;
    //public AudioMixer AudioMixer;
    //public Localization Localization;
    //public Skin PrefabSkin;

    public override void InstallBindings()
    {
        Container.Bind<SavedController>().AsSingle();
        Container.Bind<ManagerResources>().FromComponentInNewPrefab(ManagerResources).AsSingle();
        Container.Bind<ManagerFactorys>().FromComponentInNewPrefab(ManagerFactorys).AsSingle();
        Container.BindInstance(MagazinController).AsSingle();
        //Container.BindInstance(settings.Borders).AsSingle();
        //Container.BindInstance(AudioMixer).AsSingle();

        //Container.Bind<AdsView>().FromComponentInNewPrefab(AdsView).AsSingle();
        //Container.Bind<SaveController>().FromComponentInNewPrefab(SaveController).AsSingle();

        //Container.BindInstance(Localization).AsSingle();

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
