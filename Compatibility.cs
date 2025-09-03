using Microsoft.Xna.Framework;
using System.IO;
using System.Threading;
using Terraria;
using Terraria.Audio;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using static Terraria.ModLoader.ModContent;

using FargowiltasSouls.Content.Bosses;
using FargowiltasSouls.Content.Bosses.TrojanSquirrel;
using FargowiltasSouls.Content.Bosses.CursedCoffin;
using FargowiltasSouls.Content.Bosses.DeviBoss;
using FargowiltasSouls.Content.Bosses.BanishedBaron;
using FargowiltasSouls.Content.Items.BossBags;
using FargowiltasSouls.Content.Bosses.Lifelight;
using FargowiltasSouls.Content.Bosses.Champions.Cosmos;
using FargowiltasSouls.Content.Bosses.AbomBoss;
using FargowiltasSouls.Content.Bosses.MutantBoss;

namespace RebootVan.Content
{
    public class CompatibilitySystem : ModSystem
    {
        public static bool squirrel = false;
        public static bool coffin = false;
        public static bool devi = false;

        public static bool baron = false;
        public static bool lifelight = false;

        public static bool eridanus = false;
        public static bool abom = false;
        public static bool mutant = false;


        public override void ClearWorld()
        {
            squirrel = false;
            coffin = false;
            devi = false;

            baron = false;
            lifelight = false;

            eridanus = false;
            abom = false;
            mutant = false;
        }

        public override void SaveWorldData(TagCompound tag)
        {
            if (squirrel) tag["squirrel"] = true;
            if (coffin) tag["coffin"] = true;
            if (devi) tag["devi"] = true;

            if (baron) tag["baron"] = true;
            if (lifelight) tag["lifelight"] = true;

            if (eridanus) tag["eridanus"] = true;
            if (abom) tag["abom"] = true;
            if (mutant) tag["mutant"] = true;


        }

        public override void LoadWorldData(TagCompound tag)
        {
            squirrel = tag.ContainsKey("squirrel");
            coffin = tag.ContainsKey("coffin");
            devi = tag.ContainsKey("devi");

            baron = tag.ContainsKey("baron");
            lifelight = tag.ContainsKey("lifelight");

            eridanus = tag.ContainsKey("eridanus");
            abom = tag.ContainsKey("abom");
            mutant = tag.ContainsKey("mutant");
        }

        public override void NetSend(BinaryWriter writer)
        {
            var flags1 = new BitsByte();
            flags1[0] = squirrel;
            flags1[1] = coffin;
            flags1[2] = devi;
            flags1[3] = baron;
            flags1[4] = lifelight;
            flags1[5] = eridanus;
            flags1[6] = abom;
            flags1[7] = mutant;
            writer.Write(flags1);
        }

        public override void NetReceive(BinaryReader reader)
        {
            BitsByte flags1 = reader.ReadByte();
            squirrel = flags1[0];
            coffin = flags1[1];
            devi = flags1[2];
            baron = flags1[3];
            lifelight = flags1[4];
            eridanus = flags1[5];
            abom = flags1[6];
            mutant = flags1[7];
        }
    }
    public class CompatibilityGlobalNPC : GlobalNPC
    {
        public override bool InstancePerEntity => true;
        public static void Refill()
        {
            if (ModLoader.TryGetMod("RebootVan", out Mod reboot))
            {
                reboot.Call("RefillVan");
            }
        }
        public override void OnKill(NPC npc)
        {
            
            if (npc.type == NPCType<TrojanSquirrel>()
                && !CompatibilitySystem.squirrel)
            {
                CompatibilitySystem.squirrel = true;
                Refill();
            }
            else if (npc.type == NPCType<CursedCoffin>()
                && !CompatibilitySystem.coffin)
            {
                CompatibilitySystem.coffin = true;
                Refill();
            }
            else if (npc.type == NPCType<DeviBoss>()
                && !CompatibilitySystem.devi)
            {
                CompatibilitySystem.devi = true;
                Refill();
            }
            else if (npc.type == NPCType<BanishedBaron>()
                && !CompatibilitySystem.baron)
            {
                CompatibilitySystem.baron = true;
                Refill();
            }
            else if (npc.type == NPCType<LifeChallenger>()
                && !CompatibilitySystem.lifelight)
            {
                CompatibilitySystem.lifelight = true;
                Refill();
            }
            else if (npc.type == NPCType<CosmosChampion>()
                && !CompatibilitySystem.eridanus)
            {
                CompatibilitySystem.eridanus = true;
                Refill();
            }
            else if (npc.type == NPCType<AbomBoss>()
                && !CompatibilitySystem.abom)
            {
                CompatibilitySystem.abom = true;
                Refill();
            }
            else if (npc.type == NPCType<MutantBoss>()
                && !CompatibilitySystem.mutant)
            {
                CompatibilitySystem.mutant = true;
                Refill();
            }
        }
    }
}