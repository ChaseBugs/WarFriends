using System.Collections.Generic;
using UnityEngine;

public class ChatSquadButtonOnline : Core_BaseScript
{
	[Header("Core")]
	public GameObject centerPart;

	public UILabel centerLabel;

	public ChatButtonUnderline underline;

	[Header("Aditional")]
	public GameObject onlinePart;

	public UILabel numberOfOnline;

	public void InitControls()
	{
		Singleton<BeanstalkServerManager>.instance.DataLoaded += OnDataLoaded;
	}

	private void OnDataLoaded(DatabaseAction action)
	{
		if (action == DatabaseAction.GetAllSquadMembers)
		{
			InitGui();
		}
	}

	public void InitGui()
	{
		int num = 0;
		if (!string.IsNullOrEmpty(GameLoginManager.currentPlayer.squadName))
		{
			List<DatabasePlayer> squadMembers = Singleton<ServerResultsCache>.instance.GetSquadMembers(GameLoginManager.currentPlayer.squadName, ommitTime: true);
			if (squadMembers != null)
			{
				num = 1;
				foreach (DatabasePlayer item in squadMembers)
				{
					if (item.id != GameLoginManager.currentPlayer.id && item.GetRealStatus() != PlayerStatus.Offline)
					{
						num++;
					}
				}
			}
		}
		SetNumberOfOnline(num);
	}

	private void SetNumberOfOnline(int onlinePlayers)
	{
		bool flag = onlinePlayers > 0;
		onlinePart.SetActive(flag);
		centerPart.transform.localPosition = centerPart.transform.localPosition.ReplaceX((!flag) ? 0f : (-60f));
		if (flag)
		{
			numberOfOnline.text = MiscTools.FormatBigNumber(onlinePlayers);
			float y = centerLabel.transform.localScale.y;
			MiscTools.SetUILabelRescale(centerLabel, 40f, 20f, 210);
			if (y != centerLabel.transform.localScale.y)
			{
				underline.Rescale();
				MatchSizes();
			}
		}
		else if (centerLabel.transform.localScale.y < 40f)
		{
			MiscTools.SetUILabelRescale(centerLabel, 40f, 20f, 397);
			MatchSizes();
		}
	}

	private void MatchSizes()
	{
		numberOfOnline.transform.localPosition = numberOfOnline.transform.localPosition.ReplaceY(centerLabel.transform.localPosition.y);
		numberOfOnline.transform.localScale = centerLabel.transform.localScale;
	}
}
