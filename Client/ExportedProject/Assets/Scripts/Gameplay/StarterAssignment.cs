using System.Collections.Generic;
using Google2u;
using Newtonsoft.Json;
using UnityEngine;

public abstract class StarterAssignment
{
	protected StarterAssignmentsRow mAssigmentsRow;

	protected abstract int numberId { get; }

	public string id => "ID_" + numberId;

	public string textWithProgress => (!string.IsNullOrEmpty(textProgress)) ? $"{text} {textProgress}" : text;

	public virtual string text => Localization.LocalizeFormat("ID_STARTERASSIGNMENT" + numberId, mAssigmentsRow.VALUE);

	public virtual string textProgress => string.Empty;

	public int rewardGold => mAssigmentsRow.REWARDGOLD;

	public int rewardWB => mAssigmentsRow.REWARDWB;

	public int order => mAssigmentsRow.ORDER;

	public bool completed
	{
		get
		{
			return StarterAssignmentsManager.instance.GetAssignmentData(id).completed;
		}
		set
		{
			StarterAssignmentsManager.instance.GetAssignmentData(id).completed = value;
		}
	}

	public bool claimed => StarterAssignmentsManager.instance.GetAssignmentData(id).claimed;

	public abstract bool Evaluate();

	public virtual void Init(StarterAssignmentsRow starterAssignmentsRow)
	{
		mAssigmentsRow = starterAssignmentsRow;
	}

	public void Claim()
	{
		StarterAssignmentsManager.instance.GetAssignmentData(id).claimed = true;
		if (rewardGold > 0)
		{
			Singleton<Wallet>.instance.COLJGNLBEII(rewardGold);
		}
		if (rewardWB > 0)
		{
			Singleton<Wallet>.instance.NFLMMKJBKEJ(rewardWB);
		}
		SoundsManager.Instance.PlaySound(SoundsManager.KJGDNLHKPOG.AssigmentCompleted);
		StarterAssignmentsManager.instance.StarterAssignmentClaimed();
		RequestBuffer requestBuffer = RequestBufferManager.instance.GetRequestBuffer();
		requestBuffer.AddRequest(DatabaseAction.ClaimStarterAssignment, JsonConvert.SerializeObject(new Dictionary<string, object>
		{
			{ "AssignmentId", id },
			{ "Gold", rewardGold },
			{ "WarBucks", rewardWB }
		}), 0, 0, string.Empty);
		if (numberId == 10)
		{
			Debug.LogError("SENDING BUFFER IMMEDIATELY");
			requestBuffer.Send();
		}
	}
}
