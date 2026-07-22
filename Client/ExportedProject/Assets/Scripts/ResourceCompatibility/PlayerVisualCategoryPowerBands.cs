using System;
using System.Collections.Generic;
using UnityEngine;

public class PlayerVisualCategoryPowerBands : PlayerVisualCategoryGeneric<PlayerVisualCategoryPowerBands.PlayerVisualPowerBand>
{
	[Serializable]
	public class PlayerVisualPowerBand : PlayerVisualHead
	{
		public Texture2D texture;

		public Vector2 position;

		public Vector2 size;

		private static Dictionary<int, string> mDecalDescription;

		private static Dictionary<int, string> mDecalMiniIcon;

		private static Dictionary<int, Color> mDecalMiniIconColor;

		private static Dictionary<int, Tuple<string, string>> mNameLocalizations;

		public override string description => null;

		public override string decalMiniIcon => null;

		public override Color decalMiniIconColor => default(Color);

		public override string decalShortName => null;

		public override string decalTypeName => null;

		public override bool isEmptyPowerBand => false;

		public override bool isBought => false;

		public override void DMNOEANLNHM(AFIKFLMIBBA HHCDBKJFPBD, bool LGJJGEBKKKF = false)
		{
		}

		public override void FLNGJDAAMND()
		{
		}
	}
}
