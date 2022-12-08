using HarmonyLib;
using Vintagestory.API.Common;
using Vintagestory.API.MathTools;
using Vintagestory.GameContent;

namespace KilnSpreading {
	[HarmonyPatch]
	public static class PitKilnSpreadPatch
	{
		static readonly string[] DIAGONALS = new string[] {"nw", "ne", "se", "sw"};
		[HarmonyPostfix]
		[HarmonyPatch(typeof(BlockEntityPitKiln), nameof(BlockEntityPitKiln.TryIgnite))]
		public static void TryIgnite(BlockEntityPitKiln __instance, IPlayer byPlayer)
		{
			if(byPlayer == null) return; // only do this for player-lit kilns
			foreach (var dir in DIAGONALS) {
				BlockEntityPitKiln kiln = __instance.Api.World.BlockAccessor.GetBlockEntity(__instance.Pos.AddCopy(Cardinal.FromInitial(dir).Normali)) as BlockEntityPitKiln;
				if (kiln == null || !kiln.IsComplete || kiln.Lit)
				{
					continue;
				}
				kiln.TryIgnite(byPlayer); // will daisy-chain
			}
		}
	}
}