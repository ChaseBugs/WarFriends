using System;
using System.Collections.Generic;
using Google2u;
using Newtonsoft.Json.Linq;

[Serializable]
public class WarArenaLootboxConfig
{
	[Serializable]
	public class WarArenaLootbox
	{
		private int mWarbucks;

		public int elitePartsMin { get; private set; }

		public int elitePartsMax { get; private set; }

		public int ticketsMin { get; private set; }

		public int ticketsMax { get; private set; }

		public int scrapsMin { get; private set; }

		public int scrapsMax { get; private set; }

		public int goldMin { get; private set; }

		public int goldMax { get; private set; }

		public int warbucksMin => 0;

		public int warbucksMax => 0;

		public WarArenaLootbox(ArenaLootboxes.rowIds KABNCCKDBJP)
		{
		}

		private void BHKILEDFAOC(ArenaLootboxes.rowIds KABNCCKDBJP)
		{
		}

		public void LGJLIFDCFAA(Dictionary<string, string> BMIADLFBMEN)
		{
		}
	}

	public WarArenaLootbox gold { get; private set; }

	public WarArenaLootbox silver { get; private set; }

	public WarArenaLootbox bronze { get; private set; }

	public WarArenaLootboxConfig(JToken JFNEGCPHIFI)
	{
	}
}
