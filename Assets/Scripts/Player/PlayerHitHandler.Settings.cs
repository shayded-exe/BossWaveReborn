﻿using System;
using PachowStudios.Framework;

namespace PachowStudios.BossWave.Player
{
  public partial class PlayerHitHandler
  {
    [Serializable, InstallerSettings]
    public class Settings
    {
      public float KnockbackDelay = 1f;
    }
  }
}