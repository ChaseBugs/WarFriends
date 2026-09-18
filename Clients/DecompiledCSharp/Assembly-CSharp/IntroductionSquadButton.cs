using System;
using UnityEngine;

public class IntroductionSquadButton : Core_BaseScript
{
	[Header("Squad Button")]
	public GameObject squadButton;

	public BoxCollider squadCollider;

	public UISprite squadBorder;

	public GameObject squadLockedPart;

	public GameObject notInSquadPart;

	[Header("-In Squad")]
	public GameObject squadPart;

	public UILabel squadName;

	public UITexture squadIcon;

	[Header("--Squad War")]
	public GameObject squadWarPart;

	public UILabel squadWarPoints;

	[Header("--Notification")]
	public GameObject squadNotificationObject;

	public UILabel squadNotificationValue;

	public void InitEvents()
	{
		Singleton<BeanstalkServerManager>.instance.DataLoaded += OnDataLoaded;
		Singleton<BeanstalkServerManager>.instance.ErrorReceived += OnErrorReceived;
		Singleton<BeanstalkServerManager>.instance.SquadUpdateReceived += OnSquadUpdateReceived;
		GameLoginManager.instance.PlayerJoinedSquad += OnPlayerJoinedSquad;
		GameLoginManager.instance.PlayerLeftSquad += OnPlayerLeftSquad;
	}

	private void OnDataLoaded(DatabaseAction action)
	{
		if (GuiScreenSingle<MainScreen>.instance.isShowed)
		{
			switch (action)
			{
			case DatabaseAction.GetPlayerData:
			case DatabaseAction.GetSquadDetails:
				InitGuiValues();
				break;
			case DatabaseAction.LoginToCustomAccount:
			case DatabaseAction.AddFacebook:
			case DatabaseAction.CreateGcAccount:
			case DatabaseAction.RemoveFacebook:
			case DatabaseAction.AddGooglePlay:
			case DatabaseAction.RemoveGooglePlay:
				InitGuiValues();
				break;
			}
		}
	}

	private void OnErrorReceived(DatabaseAction action)
	{
		if (GuiScreenSingle<MainScreen>.instance.isShowed && action == DatabaseAction.GetSquadDetails)
		{
			InitGuiValues();
		}
	}

	public void OnSquadUpdateReceived(DatabaseSquad squad)
	{
		if (GuiScreenSingle<MainScreen>.instance.isShowed && squad != null && GameLoginManager.currentPlayer.squadName == squad.name)
		{
			InitGuiValues();
		}
	}

	private void OnPlayerJoinedSquad(string squadName)
	{
		if (GuiScreenSingle<MainScreen>.instance.isShowed)
		{
			InitGuiValues();
		}
	}

	private void OnPlayerLeftSquad()
	{
		if (GuiScreenSingle<MainScreen>.instance.isShowed)
		{
			InitGuiValues();
		}
	}

	public void InitControls()
	{
		UIEventListener uIEventListener = UIEventListener.Get(squadButton);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(SquadButtonClick));
		Singleton<NotificationManager>.instance.CardpoolNotificationChanged += delegate
		{
			if (GuiScreenSingle<MainScreen>.instance.isShowed)
			{
				SquadNotifications();
			}
		};
	}

	private void SquadButtonClick(GameObject go)
	{
		if (squadPart.activeSelf)
		{
			if (squadNotificationObject.activeSelf)
			{
				GuiScreenSingle<SquadScreen>.instance.ShowSquadCardpool();
			}
			else
			{
				Singleton<GuiManager>.instance.ShowGui(GuiScreenSingle<SquadScreen>.instance);
			}
		}
		else if (notInSquadPart.activeSelf)
		{
			Singleton<GuiManager>.instance.ShowGui(GuiScreenSingle<SquadScreen>.instance);
		}
	}

	public void InitGuiValues()
	{
		if (Singleton<BeanstalkServerManager>.instance.isPlayerDataLoaded && !string.IsNullOrEmpty(GameLoginManager.currentPlayer.squadName))
		{
			DatabaseSquad squad = Singleton<ServerResultsCache>.instance.GetSquad(GameLoginManager.currentPlayer.squadName, ommitTime: true);
			if (squad != null)
			{
				UpdateButton(squad);
				if (squad.name != GameLoginManager.currentPlayer.squadName)
				{
					Singleton<BeanstalkServerManager>.instance.GetSquadDetails(GameLoginManager.currentPlayer.squadName);
				}
			}
			else
			{
				UpdateButton(null);
				Singleton<BeanstalkServerManager>.instance.GetSquadDetails(GameLoginManager.currentPlayer.squadName);
			}
		}
		else
		{
			UpdateButton(null);
		}
	}

	public void DoAfterHide()
	{
		squadIcon.mainTexture = null;
	}

	private void UpdateButton(DatabaseSquad squad)
	{
		bool isSquadLocked = LevelManager.instance.isSquadLocked;
		bool flag = squad != null;
		squadCollider.enabled = !isSquadLocked;
		squadBorder.alpha = ((!isSquadLocked) ? 1f : 0.2f);
		squadLockedPart.SetActive(isSquadLocked);
		if (isSquadLocked)
		{
			notInSquadPart.SetActive(value: false);
			squadPart.SetActive(value: false);
			return;
		}
		if (!flag != notInSquadPart.activeSelf)
		{
			notInSquadPart.SetActive(!flag);
		}
		if (flag != squadPart.activeSelf)
		{
			squadPart.SetActive(flag);
		}
		if (flag)
		{
			squadIcon.alpha = 1f;
			squadIcon.mainTexture = Resources.Load<Texture>("SquadIcons/" + squad.icon);
			squadIcon.MakePixelPerfect();
			float multiplier = 0.39f;
			squadIcon.transform.localScale = squadIcon.transform.localScale.MultiplyXY(multiplier);
			SquadWar(squad);
			SquadNotifications();
		}
	}

	private void SquadWar(DatabaseSquad squad)
	{
		bool isInDivision = squad.isInDivision;
		squadWarPart.SetActive(isInDivision);
		if (isInDivision)
		{
			bool isSquadWarsProcessing = Singleton<ServerResultsCache>.instance.isSquadWarsProcessing;
			string arg = ((!isSquadWarsProcessing) ? MiscTools.FormatNumberToOrdinalPoint(squad.warsPosition) : "?.");
			if (isSquadWarsProcessing && squad.warsPosition == 0)
			{
				Debug.LogError("In squad data from server is no squad wars position and there is no squad war processing.");
			}
			squadName.text = $"[0BBCFF]{arg}[-] {squad.name}";
			squadIcon.transform.localPosition = squadIcon.transform.localPosition.ReplaceY(45f);
			squadWarPoints.text = MiscTools.FormatBigNumber(squad.squadPoints);
			MiscTools.SetUILabelRescale(squadWarPoints, 30f, 20f, 90);
		}
		else
		{
			squadName.text = squad.name;
			squadIcon.transform.localPosition = squadIcon.transform.localPosition.ReplaceY(10f);
		}
	}

	private void SquadNotifications()
	{
		if (squadPart.activeSelf)
		{
			int squadCardpoolNotifications = Singleton<NotificationManager>.instance.GetSquadCardpoolNotifications();
			squadNotificationValue.text = MiscTools.FormatBigNumber(squadCardpoolNotifications);
			squadNotificationObject.SetActive(squadCardpoolNotifications > 0);
		}
	}
}
