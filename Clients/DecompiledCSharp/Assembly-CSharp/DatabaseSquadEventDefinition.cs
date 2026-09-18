using System;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;

public class DatabaseSquadEventDefinition
{
	public class EventTier
	{
		public int reward;

		public int nAssignments;

		public List<int> assignmentIds;
	}

	public int eventStart;

	public int eventEnd;

	public int nTiers;

	public List<EventTier> tiers;

	internal static DatabaseSquadEventDefinition CreateFromDatabase(Dictionary<string, object> item)
	{
		DatabaseSquadEventDefinition databaseSquadEventDefinition = new DatabaseSquadEventDefinition();
		int num = 0;
		if (item.ContainsKey("eventStart"))
		{
			databaseSquadEventDefinition.eventStart = Convert.ToInt32(item["eventStart"]);
		}
		if (item.ContainsKey("eventEnd"))
		{
			databaseSquadEventDefinition.eventEnd = Convert.ToInt32(item["eventEnd"]);
		}
		if (item.ContainsKey("tierCount"))
		{
			databaseSquadEventDefinition.nTiers = Convert.ToInt32(item["tierCount"]);
		}
		if (item.ContainsKey("assignmentCount"))
		{
			num = Convert.ToInt32(item["assignmentCount"]);
		}
		databaseSquadEventDefinition.tiers = new List<EventTier>(databaseSquadEventDefinition.nTiers);
		for (int i = 0; i < databaseSquadEventDefinition.nTiers; i++)
		{
			EventTier eventTier = new EventTier();
			eventTier.nAssignments = num;
			eventTier.reward = Convert.ToInt32(item["T" + i + "Reward"]);
			eventTier.assignmentIds = new List<int>(num);
			EventTier eventTier2 = eventTier;
			for (int j = 0; j < num; j++)
			{
				eventTier2.assignmentIds.Add(Convert.ToInt32(item["T" + i + "A" + j + "Id"]));
			}
			databaseSquadEventDefinition.tiers.Add(eventTier2);
		}
		return databaseSquadEventDefinition;
	}

	internal static DatabaseSquadEventDefinition CreateFromDatabase(JToken item)
	{
		DatabaseSquadEventDefinition databaseSquadEventDefinition = new DatabaseSquadEventDefinition();
		int num = 0;
		if (item["eventStart"] != null)
		{
			databaseSquadEventDefinition.eventStart = item["eventStart"].ToObject<int>();
		}
		if (item["eventEnd"] != null)
		{
			databaseSquadEventDefinition.eventEnd = item["eventEnd"].ToObject<int>();
		}
		if (item["tierCount"] != null)
		{
			databaseSquadEventDefinition.nTiers = item["tierCount"].ToObject<int>();
		}
		if (item["assignmentCount"] != null)
		{
			num = item["assignmentCount"].ToObject<int>();
		}
		databaseSquadEventDefinition.tiers = new List<EventTier>(databaseSquadEventDefinition.nTiers);
		for (int i = 0; i < databaseSquadEventDefinition.nTiers; i++)
		{
			EventTier eventTier = new EventTier();
			eventTier.nAssignments = num;
			eventTier.reward = item["T" + i + "Reward"].ToObject<int>();
			eventTier.assignmentIds = new List<int>(num);
			EventTier eventTier2 = eventTier;
			for (int j = 0; j < num; j++)
			{
				eventTier2.assignmentIds.Add(item["T" + i + "A" + j + "Id"].ToObject<int>());
			}
			databaseSquadEventDefinition.tiers.Add(eventTier2);
		}
		return databaseSquadEventDefinition;
	}
}
