using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ID;
using Terraria;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace ThanosChallenge.Common.Systems
{
    public class SnappedItemsSystem : ModSystem
    {
        public static bool[] IsItemAllowed = null;

        public override void PostWorldGen()
        {
            CreateList();
        }

        public override void ClearWorld()
        {
            IsItemAllowed = null;
        }

        public override void SaveWorldData(TagCompound tag)
        {
            if(IsItemAllowed != null)
            {
                tag.Add("bannedItems", IsItemAllowed);
            }
        }

        public override void LoadWorldData(TagCompound tag)
        {
            IsItemAllowed = null;
            if(!tag.ContainsKey("bannedItems") || ModContent.GetInstance<ChallengeConfig>().RerollBannedItemsOnWorldLoad)
            {
                CreateList();
            } else
            {
               IsItemAllowed = tag.Get<bool[]>("bannedItems");
            }
        }

        private void CreateList()
        {
            List<int> legalList = new();

            //Get a list of every item in the game
            for (int i = 1; i < ItemLoader.ItemCount; i++)
            {
                //Item item = ContentSamples.ItemsByType[i];
                legalList.Add(i);
            }

            //Randomize the list
            for (int i = legalList.Count - 1; i >= 0; i--)
            {
                var k = Main.rand.Next(i + 1);
                (legalList[i], legalList[k]) = (legalList[k], legalList[i]);
            }
            IsItemAllowed = new bool[legalList.Count+1];
            IsItemAllowed[0] = true;
            //Divide the randomized list in half
            for (int i = (int)((legalList.Count) * (ModContent.GetInstance<ChallengeConfig>().PercentageRemoved/100f)); i < legalList.Count; i++)
            {
                IsItemAllowed[legalList[i]] = true;
            }

            //Allow the Lizhard power cell
            IsItemAllowed[1293] = true;
        }
    }
}
