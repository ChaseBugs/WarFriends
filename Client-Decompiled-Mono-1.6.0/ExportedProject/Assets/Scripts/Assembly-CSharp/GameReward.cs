using System;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using UnityEngine;

[Serializable]
public abstract class GameReward
{
	public int amount;

	private static Dictionary<int, Type> mRewardTypes = new Dictionary<int, Type>
	{
		{
			0,
			typeof(GameRewardWarbucks)
		},
		{
			1,
			typeof(GameRewardGold)
		},
		{
			5,
			typeof(GameRewardScraps)
		},
		{
			8,
			typeof(GameRewardPlayerVisual)
		},
		{
			15,
			typeof(GameRewardTickets)
		},
		{
			17,
			typeof(GameRewardEliteParts)
		}
	};

	public abstract int id { get; }

	public static GameReward OMDNNCPJLGE(int GGIOEPBPMHF, JToken EGPDHGEOFIA)
	{
		Type value;
		if (!mRewardTypes.TryGetValue(GGIOEPBPMHF, out value))
		{
			Debug.LogError("Error: No reward " + GGIOEPBPMHF);
			value = typeof(GameRewardWarbucks);
		}
		GameReward gameReward = (GameReward)EGPDHGEOFIA.ToObject(value);
		gameReward.EHKKAOLJMCF();
		return gameReward;
	}

	public static GameReward OMDNNCPJLGE(GameRewardData EGPDHGEOFIA)
	{
		return OMDNNCPJLGE(EGPDHGEOFIA.type, EGPDHGEOFIA.data);
	}

	protected virtual void EHKKAOLJMCF()
	{
	}

	public abstract void HIECGLCKNCA();
}
