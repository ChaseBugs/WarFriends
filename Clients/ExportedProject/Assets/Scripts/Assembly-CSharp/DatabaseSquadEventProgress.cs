using System;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using UnityEngine;

public class DatabaseSquadEventProgress
{
	public class EventTierProgress
	{
		public int reward;

		public int tierNumber;

		public List<float> assignmentsProgress;

		public List<int> targets;

		public Dictionary<int, string> assignmentsSecondParams;

		internal float GetProgress()
		{
			float num = 0f;
			foreach (float item in assignmentsProgress)
			{
				float num2 = item;
				num += ((!(num2 > 1f)) ? num2 : 1f);
			}
			return num / (float)assignmentsProgress.Count;
		}
	}

	public string squadId;

	public string eventId;

	public int activeTier;

	public float levelProgress;

	public List<EventTierProgress> tiers;

	internal static DatabaseSquadEventProgress CreateFromDatabase(JToken item)
	{
		DatabaseSquadEventProgress databaseSquadEventProgress = new DatabaseSquadEventProgress();
		databaseSquadEventProgress.squadId = item["SquadId"]["S"].ToObject<string>();
		databaseSquadEventProgress.eventId = item["EventId"]["S"].ToObject<string>();
		databaseSquadEventProgress.activeTier = item["ActiveTier"]["N"].ToObject<int>();
		databaseSquadEventProgress.tiers = new List<EventTierProgress>();
		databaseSquadEventProgress.levelProgress = item["LevelProgress"]["N"].ToObject<float>();
		DatabaseSquadEventProgress databaseSquadEventProgress2 = databaseSquadEventProgress;
		for (int i = 0; item["T" + i + "Reward"] != null; i++)
		{
			EventTierProgress eventTierProgress = new EventTierProgress();
			eventTierProgress.reward = item["T" + i + "Reward"]["N"].ToObject<int>();
			eventTierProgress.assignmentsProgress = new List<float>();
			eventTierProgress.targets = new List<int>();
			eventTierProgress.tierNumber = i + 1;
			eventTierProgress.assignmentsSecondParams = new Dictionary<int, string>();
			EventTierProgress eventTierProgress2 = eventTierProgress;
			int num = 0;
			while (item["T" + i + "A" + num] != null)
			{
				eventTierProgress2.assignmentsProgress.Add(item["T" + i + "A" + num]["N"].ToObject<float>());
				eventTierProgress2.targets.Add(item["T" + i + "A" + num + "Target"]["N"].ToObject<int>());
				if (item["T" + i + "A" + num + "Param"] != null)
				{
					eventTierProgress2.assignmentsSecondParams[num] = item["T" + i + "A" + num + "Param"]["N"].ToObject<string>();
				}
				num++;
			}
			databaseSquadEventProgress2.tiers.Add(eventTierProgress2);
		}
		return databaseSquadEventProgress2;
	}

	internal float[] GetOnGameEndedUpdates(DatabaseSquadEventDefinition squadEventDefinition)
	{
		if (activeTier >= tiers.Count)
		{
			return null;
		}
		EventTierProgress eventTierProgress = tiers[activeTier];
		float[] array = new float[eventTierProgress.assignmentsProgress.Count];
		DatabaseSquadEventDefinition.EventTier eventTier = squadEventDefinition.tiers[activeTier];
		for (int i = 0; i < eventTierProgress.assignmentsProgress.Count; i++)
		{
			string secondParameter = string.Empty;
			if (eventTierProgress.assignmentsSecondParams.ContainsKey(i))
			{
				secondParameter = eventTierProgress.assignmentsSecondParams[i];
			}
			Assignment assignment = Assignment.CreateAssignment(new AssignmentsManager.DatabaseAssignment(eventTier.assignmentIds[i], eventTierProgress.targets[i]), isSquadEvent: true, secondParameter, levelProgress);
			float num = 0f;
			try
			{
				num = assignment.Update();
			}
			catch (Exception ex)
			{
				Debug.LogError($"Assignment ID: {eventTier.assignmentIds[i]}\nERROR: {ex.Message}\nSTACKTRACE: {ex.StackTrace}");
				if (DebugSettings.debugEnabled)
				{
					WarningDialog.ShowError(Localization.Localize("ID_DEBUG_STACKTRACEINCONSOLE"), Localization.Localize("ID_DEBUG_EVENTASSIGNMENTUPDATE"), 0f, null, string.Empty);
				}
				Crittercism.LogHandledException(ex);
			}
			array[i] = num;
		}
		return array;
	}
}
