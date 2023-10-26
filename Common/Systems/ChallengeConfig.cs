using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ModLoader.Config;

namespace ThanosChallenge.Common.Systems
{
    public class ChallengeConfig : ModConfig
    {
        public override ConfigScope Mode => ConfigScope.ServerSide;

        [DefaultValue(0.5f)]
        [DrawTicks]
        public float PercentageRemoved = 0.5f;
    }
}
