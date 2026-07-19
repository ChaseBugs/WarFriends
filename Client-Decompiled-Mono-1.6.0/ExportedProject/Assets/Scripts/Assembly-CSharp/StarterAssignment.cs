using System.Collections.Generic;
using Google2u;
using Newtonsoft.Json;
using UnityEngine;

public abstract class StarterAssignment
{
	protected StarterAssignmentsRow mAssigmentsRow;

	protected abstract int numberId { get; }

	public string id
	{
		get
		{
			return "ID_" + numberId;
		}
	}

	public string textWithProgress
	{
		get
		{
			return (!string.IsNullOrEmpty(textProgress)) ? string.Format("{0} {1}", text, textProgress) : text;
		}
	}

	public virtual string text
	{
		get
		{
			return Localization.LocalizeFormat("ID_STARTERASSIGNMENT" + numberId, mAssigmentsRow.VALUE);
		}
	}

	public virtual string textProgress
	{
		get
		{
			return string.Empty;
		}
	}

	public int rewardGold
	{
		get
		{
			return mAssigmentsRow.REWARDGOLD;
		}
	}

	public int rewardWB
	{
		get
		{
			return mAssigmentsRow.REWARDWB;
		}
	}

	public int order
	{
		get
		{
			return mAssigmentsRow.ORDER;
		}
	}

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

	public bool claimed
	{
		get
		{
			return StarterAssignmentsManager.instance.GetAssignmentData(id).claimed;
		}
	}

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
