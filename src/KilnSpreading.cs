using HarmonyLib;
using Vintagestory.API.Common;

[assembly: ModInfo("KilnSpreading",
    Authors = new[] { "Noelle Lavenza" })]

namespace KilnSpreading
{
	class KilnSpreading : ModSystem
	{
		internal static Harmony harmony;
		public override void Start(ICoreAPI api)
		{
			api.World.Logger.Event("started 'KilnSpreading' mod");
			// TODO: REPLACE WITH SETTING A DELEGATE USING A BLOCKENTITYBEHAVIOR
			// WHENEVER AN ONFIRESTART DELEGATE IS ADDED TO BEBehaviorBurning
			harmony = new Harmony("KilnSpreading");
			harmony.PatchAll();
		}

		public override void Dispose()
		{
			harmony.UnpatchAll();
			base.Dispose();
		}
	}
}