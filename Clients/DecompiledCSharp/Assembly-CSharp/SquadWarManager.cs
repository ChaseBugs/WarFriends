using System;
using System.Collections.Generic;
using UnityEngine;

public class SquadWarManager : Core_BaseScript
{
	private List<DatabaseSquad> mSquadsInSquadWar;

	private List<DatabasePlayer> mMembersInSquad;

	private static SquadWarManager mInstance;

	public static SquadWarManager instance
	{
		get
		{
			mInstance = mInstance ?? ((SquadWarManager)UnityEngine.Object.FindObjectsOfType(typeof(SquadWarManager))[0]);
			return mInstance;
		}
	}

	public event Action SquadWarSquadsUpdated;

	public event Action SquadWarMembersUpdated;

	public void OnDestroy()
	{
		mInstance = null;
	}

	public List<DatabaseSquad> GetSquadWarSquads()
	{
		if (mSquadsInSquadWar == null)
		{
			mSquadsInSquadWar = new List<DatabaseSquad>();
		}
		return mSquadsInSquadWar;
	}

	public List<DatabasePlayer> GetSquadWarMembers()
	{
		if (mMembersInSquad == null)
		{
			mMembersInSquad = new List<DatabasePlayer>();
		}
		return mMembersInSquad;
	}

	protected override void Awake()
	{
		base.Awake();
		Singleton<BeanstalkServerManager>.instance.DataLoaded += OnDataLoaded;
	}

	private void OnDataLoaded(DatabaseAction action)
	{
		if (!Singleton<BeanstalkServerManager>.instance.isPlayerDataLoaded)
		{
			return;
		}
		switch (action)
		{
		case DatabaseAction.GetSquadWarsDivision:
		{
			string squadName = GameLoginManager.currentPlayer.squadName;
			if (string.IsNullOrEmpty(squadName))
			{
				mSquadsInSquadWar = null;
				if (this.SquadWarSquadsUpdated != null)
				{
					this.SquadWarSquadsUpdated();
				}
				break;
			}
			DatabaseSquad squad = Singleton<ServerResultsCache>.instance.GetSquad(squadName, ommitTime: true);
			List<DatabaseSquad> list2 = Singleton<ServerResultsCache>.instance.GetSquadsFromLeague(squad.roundId);
			if (list2 == null)
			{
				list2 = new List<DatabaseSquad>();
			}
			int num3 = list2.FindIndex((DatabaseSquad s1) => s1.name == squadName);
			if (num3 >= 0)
			{
				list2[num3] = squad;
			}
			else
			{
				list2.Add(squad);
			}
			for (int num4 = list2.Count - 1; num4 >= 0; num4--)
			{
				if (string.IsNullOrEmpty(list2[num4].name))
				{
					list2.RemoveAt(num4);
				}
			}
			list2.Sort(SortFunctionSquads);
			mSquadsInSquadWar = list2;
			if (this.SquadWarSquadsUpdated != null)
			{
				this.SquadWarSquadsUpdated();
			}
			break;
		}
		case DatabaseAction.GetAllSquadMembers:
		{
			List<DatabasePlayer> list = Singleton<ServerResultsCache>.instance.GetSquadMembers(GameLoginManager.currentPlayer.squadName);
			if (list == null)
			{
				list = new List<DatabasePlayer>();
			}
			int num = list.FindIndex((DatabasePlayer p) => p.id == GameLoginManager.currentPlayer.id);
			if (num >= 0)
			{
				list[num].playerVisuals = GameLoginManager.generatedCurrentPlayer.playerVisuals;
			}
			else
			{
				list.Add(GameLoginManager.generatedCurrentPlayer);
			}
			for (int num2 = list.Count - 1; num2 >= 0; num2--)
			{
				if (string.IsNullOrEmpty(list[num2].name))
				{
					list.RemoveAt(num2);
				}
			}
			list.Sort(SortFunctionPlayers);
			mMembersInSquad = list;
			if (this.SquadWarMembersUpdated != null)
			{
				this.SquadWarMembersUpdated();
			}
			break;
		}
		}
	}

	public int SortFunctionPlayers(DatabasePlayer a, DatabasePlayer b)
	{
		if (a.squadPoints != b.squadPoints)
		{
			return b.squadPoints.CompareTo(a.squadPoints);
		}
		if (a.level != b.level)
		{
			return b.level.CompareTo(a.level);
		}
		if (string.IsNullOrEmpty(a.name))
		{
			return (!string.IsNullOrEmpty(b.name)) ? (-1) : 0;
		}
		return a.name.CompareTo(b.name);
	}

	private int SortFunctionSquads(DatabaseSquad a, DatabaseSquad b)
	{
		if (a.squadPoints != b.squadPoints)
		{
			return b.squadPoints.CompareTo(a.squadPoints);
		}
		if (a.rank != b.rank)
		{
			return b.rank.CompareTo(a.rank);
		}
		if (string.IsNullOrEmpty(a.name))
		{
			return (!string.IsNullOrEmpty(b.name)) ? (-1) : 0;
		}
		return a.name.CompareTo(b.name);
	}

	public List<DatabaseSquad> GenerateFakeSquads(int squadsInWar, int squadPosition, int minSquadPoints, int maxSquadPoints)
	{
		List<DatabaseSquad> list = new List<DatabaseSquad>();
		DatabaseSquad squad = Singleton<ServerResultsCache>.instance.GetSquad(GameLoginManager.currentPlayer.squadName, ommitTime: true);
		List<string> list2 = FakeSquadNames(squadsInWar - 1);
		string division = squad.division;
		int squadPoints = squad.squadPoints;
		if (squadPosition == 1)
		{
			maxSquadPoints = squadPoints;
		}
		if (squadPosition == squadsInWar)
		{
			minSquadPoints = squadPoints;
		}
		int num = 0;
		int num2 = squadPosition - 1;
		for (int i = 0; i < squadsInWar; i++)
		{
			if (i + 1 == squadPosition)
			{
				list.Add(squad);
			}
			else if (i + 1 < squadPosition)
			{
				int num3 = Mathf.Max(0, maxSquadPoints - squadPoints - 1);
				float num4 = (float)(num2 - i) / (float)num2;
				int squadPoints2 = Mathf.RoundToInt((float)num3 * num4) + squadPoints + 1;
				list.Add(GenerateFakeSquad(list2[num], squad, squadPoints2));
				num++;
			}
			else
			{
				int num5 = Mathf.Max(0, squadPoints - minSquadPoints - 1);
				float num6 = (float)(squadsInWar - i) / (float)(squadsInWar - num2);
				int squadPoints3 = Mathf.RoundToInt((float)num5 * num6);
				list.Add(GenerateFakeSquad(list2[num], squad, squadPoints3));
				num++;
			}
			list[i].division = division;
		}
		return list;
	}

	private List<string> FakeSquadNames(int count)
	{
		List<string> list = new List<string>();
		for (int i = 1; i <= count; i++)
		{
			string item = $"FakeDoNotClick{i:2}";
			list.Add(item);
		}
		return list;
	}

	private DatabaseSquad GenerateFakeSquad(string name, DatabaseSquad mySquad, int squadPoints)
	{
		DatabaseSquad databaseSquad = new DatabaseSquad();
		databaseSquad.name = name;
		databaseSquad.icon = $"menu-squad-{UnityEngine.Random.Range(1, 37)}";
		databaseSquad.squadPoints = squadPoints;
		databaseSquad.rank = mySquad.rank;
		databaseSquad.division = mySquad.division;
		databaseSquad.size = UnityEngine.Random.Range(4, 12);
		return databaseSquad;
	}
}
