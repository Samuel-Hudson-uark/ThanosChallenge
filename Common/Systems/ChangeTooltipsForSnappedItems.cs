using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.Enums;
using Terraria.GameContent.UI;
using Terraria.ID;
using Terraria.ModLoader;

namespace ThanosChallenge.Common.Systems
{
    public class ChangeTooltipsForSnappedItems: GlobalItem
    {
        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {
            if(!SnappedItemsSystem.IsItemAllowed[item.type])
            {
                tooltips.Insert(1, new TooltipLine(Mod, "Unusable", "[c/E11919:This item can't be used.]"));
            }
        }

        public override bool CanUseItem(Item item, Player player)
        {
            return SnappedItemsSystem.IsItemAllowed[item.type];
        }

        public override bool? CanBeChosenAsAmmo(Item ammo, Item weapon, Player player)
        {
            return SnappedItemsSystem.IsItemAllowed[ammo.type] ? null : false;
        }

        public override bool? CanConsumeBait(Player player, Item bait)
        {
            return SnappedItemsSystem.IsItemAllowed[bait.type] ? null : false;
        }

        public override bool CanResearch(Item item)
        {
            return SnappedItemsSystem.IsItemAllowed[item.type];
        }

        public override bool CanRightClick(Item item)
        {
            return SnappedItemsSystem.IsItemAllowed[item.type];
        }

        public override bool CanEquipAccessory(Item item, Player player, int slot, bool modded)
        {
            return SnappedItemsSystem.IsItemAllowed[item.type];
        }

        public override bool ConsumeItem(Item item, Player player)
        {
            return SnappedItemsSystem.IsItemAllowed[item.type];
        }
    }
}
