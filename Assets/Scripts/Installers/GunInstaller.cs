﻿using PachowStudios.BossWave.Guns;
using PachowStudios.Framework.Messaging;
using UnityEngine;
using Zenject;

namespace PachowStudios.BossWave.Installers
{
  [AddComponentMenu("Boss Wave/Installers/Gun Installer")]
  public partial class GunInstaller : MonoInstaller
  {
    [SerializeField] private Settings config = null;

    private IEventAggregator EventAggregator { get; set; }

    [Inject]
    public void Construct(IEventAggregator eventAggregator)
      => EventAggregator = eventAggregator;

    public override void InstallBindings()
    {
      Container.Bind<GunModel>().AsSingle();
      Container.BindInstance(this.config.Components).WhenInjectedInto<GunModel>();

      Container.BindAllInterfaces<GunRotationHandler>().To<GunRotationHandler>().AsSingle();
      Container.BindAllInterfaces<GunActivatedHandler>().To<GunActivatedHandler>().AsSingle();

      Container.BindInstance(this.config.Facade).WhenInjectedInto<GunFacade>();

      Container.BindAllInterfaces<EventAggregator>().FromMethod(c => EventAggregator.CreateChildContext()).AsSingle();
    }
  }
}
