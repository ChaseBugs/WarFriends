using System.Collections.Generic;

namespace Google2u
{
	public class CardDefinitions : Google2uComponentBase, IGoogle2uDB
	{
		public enum rowIds
		{
			SLOWMOVE,
			FREEZE,
			HEAVYDRONE,
			APOCALYPSE,
			SHIELDRAFFLE,
			MINEENEMY,
			BIGROCKET,
			ELITEMINIGUN,
			IMMORTAL,
			ROCKETTURRET,
			DISARMED,
			ELITESWAT,
			CHEMICALUNIT,
			ELITETANK,
			TOPBUILDERS,
			BIGMEDKIT,
			AIRSTRIKE,
			MADGANG,
			SABOTAGE,
			HEAVYTURRET,
			ELITESNIPER,
			CLUSTERGRENADE,
			HEADAHEAD,
			HELISTRIKE,
			KEVLARUP,
			MIRRORMYSELF,
			REFLECTION,
			AMMOTHIEF,
			EMPTYMAG,
			GREATGRENADIER,
			MEATHEADS,
			INVISIBILITY,
			BOOBYTRAP,
			ELECTRICTRAPS,
			SMALLMEDKIT,
			ELITEPARA,
			VEHICLEHEALTH,
			TURRETCRATE,
			HEALTHCRATE,
			KEVLARCRATE,
			BULLETHARMLESS,
			AMMOBOX,
			BACKSTAB,
			EXPLOSIVEPISTOL,
			MEDKIT,
			DECOY,
			MAXHEALTHINC,
			MINE,
			TURRET,
			RANDOMKEVLAR,
			EXPLOSIVETIMING,
			STREAKBOOST,
			DESTROYSHIELD,
			SHIELDSPAWNER,
			SHIELDSHEALTH,
			SLOWDOWN,
			HEALINGSTORM,
			TRIGGERHAPPY,
			AMMOCRATE,
			SICKNESS,
			CRITICALS,
			SUPERSOLDIERS,
			PARALYZE,
			CRATEBLOCKER,
			SHIELDGENERATOR,
			PLAGUE,
			PLAYERINVIS,
			HELIASSAULT,
			HEALTEAM,
			SCORESTREAK,
			HEALTHYUNIT,
			HEALINGSALVE,
			GRENADETIMING,
			DESTRUCTIVESHOT,
			SHIELDINGSHOT,
			SHRINK,
			ARMYSPAWNFAST,
			MAXHEALTHINCSOL,
			SEEENEMY,
			INCREASERANKS,
			ENGINEER,
			DEPLOYALL,
			CANTDIENOW
		}

		public string[] rowNames;

		public Dictionary<string, int> namesToIndex;

		public List<CardDefinitionsRow> Rows;

		public override bool haveDictionary => false;

		public override int getColumnCount => 0;

		public override int GetRowIndex(string rowID)
		{
			return 0;
		}

		public override void AddRowGeneric(List<string> input)
		{
		}

		public override int AddBlanckRowGeneric(string rowId)
		{
			return 0;
		}

		public override int AddRowGenericRealyAdd(List<string> input)
		{
			return 0;
		}

		public override void CheckRows(List<string> rowIds)
		{
		}

		public override void Clear()
		{
		}

		public IGoogle2uRow GetGenRow(string in_RowString)
		{
			return null;
		}

		public IGoogle2uRow GetGenRow(rowIds in_RowID)
		{
			return null;
		}

		public CardDefinitionsRow GetRow(rowIds in_RowID)
		{
			return null;
		}

		public CardDefinitionsRow GetRow(string in_RowString)
		{
			return null;
		}
	}
}
