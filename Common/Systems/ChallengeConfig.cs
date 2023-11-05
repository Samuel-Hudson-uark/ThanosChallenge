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

        [Range(0f,100f)]
        [DefaultValue(50f)]
        [DrawTicks]
        [Increment(1f)]
        public float PercentageRemoved = 50f;

        [DefaultValue(false)]
        public bool RerollBannedItemsOnWorldLoad = false;
    }
}
