using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class GameSignalInstaller : Installer<GameSignalInstaller>
{
    public override void InstallBindings()
    {
        SignalBusInstaller.Install(Container);

        Container.DeclareSignal<GameOverSignal>();
        //Container.DeclareSignal<StartGameSignal>();
        //Container.DeclareSignal<ContinueGameSignal>();
        //Container.DeclareSignal<GameSaveSignal>();
        //Container.DeclareSignal<GameLoadSignal>();
        //Container.DeclareSignal<ChangeLanguage>();

    }
}
