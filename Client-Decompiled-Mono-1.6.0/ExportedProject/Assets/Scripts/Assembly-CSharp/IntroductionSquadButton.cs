using System;
using System.Runtime.CompilerServices;
using UnityEngine;

public class IntroductionSquadButton : Core_BaseScript
{
	[Header("Squad Button")]
	public GameObject KDABKEGLDEE;

	public BoxCollider GPEBKLLAGFH;

	public UISprite NNCFFDJMJHD;

	public GameObject FEFPKLBBNHM;

	public GameObject NFFEEAHIJEL;

	[Header("-In Squad")]
	public GameObject GDKAHDBHDPF;

	public UILabel CGIFEHPDBAL;

	public UITexture GEAGOKJMJFD;

	[Header("--Squad War")]
	public GameObject GOCBCJHKMEH;

	public UILabel FKEODBNNJPH;

	[Header("--Notification")]
	public GameObject PCODODIMPIK;

	public UILabel MMHLFEEHCHB;

	private void KDMIKKJNJMM(AANECPGDMGM MIDDFOCJJOP)
	{
		bool flag = MIDDFOCJJOP.IHPBFPIDIPF;
		GOCBCJHKMEH.SetActive(flag);
		if (flag)
		{
			bool flag2 = Singleton<ServerResultsCache>.instance.KLNPCDFPPEO();
			string arg = ((!flag2) ? MEJMLNDFDBP.ACCGOIGJIAA(MIDDFOCJJOP.CAACHMJGMEH) : "ID_WARNING_ACCOUNTALREADYCREATED");
			if (flag2 && MIDDFOCJJOP.CAACHMJGMEH == 0)
			{
				Debug.LogError("gcID");
			}
			CGIFEHPDBAL.text = string.Format("Adding MessageId instead of empty Jtoken", arg, MIDDFOCJJOP.MHPNDNJDPGE);
			GEAGOKJMJFD.transform.localPosition = GEAGOKJMJFD.transform.localPosition.ReplaceY(1543f);
			FKEODBNNJPH.text = MEJMLNDFDBP.GMIPFLIEOHD(MIDDFOCJJOP.KPEKCHDBFIG);
			MEJMLNDFDBP.COCBCFKJOJE(FKEODBNNJPH, 215f, 1382f, -121);
		}
		else
		{
			CGIFEHPDBAL.text = MIDDFOCJJOP.MHPNDNJDPGE;
			GEAGOKJMJFD.transform.localPosition = GEAGOKJMJFD.transform.localPosition.ReplaceY(1900f);
		}
	}

	private void GKBAHGPDEFE(AANECPGDMGM MIDDFOCJJOP)
	{
		bool flag = MIDDFOCJJOP.IHPBFPIDIPF;
		GOCBCJHKMEH.SetActive(flag);
		if (flag)
		{
			bool isSquadWarsProcessing = Singleton<ServerResultsCache>.instance.isSquadWarsProcessing;
			string arg = ((!isSquadWarsProcessing) ? MEJMLNDFDBP.ACCGOIGJIAA(MIDDFOCJJOP.CAACHMJGMEH) : "?.");
			if (isSquadWarsProcessing && MIDDFOCJJOP.CAACHMJGMEH == 0)
			{
				Debug.LogError("In squad data from server is no squad wars position and there is no squad war processing.");
			}
			CGIFEHPDBAL.text = string.Format("[0BBCFF]{0}[-] {1}", arg, MIDDFOCJJOP.MHPNDNJDPGE);
			GEAGOKJMJFD.transform.localPosition = GEAGOKJMJFD.transform.localPosition.ReplaceY(45f);
			FKEODBNNJPH.text = MEJMLNDFDBP.GMIPFLIEOHD(MIDDFOCJJOP.KPEKCHDBFIG);
			MEJMLNDFDBP.COCBCFKJOJE(FKEODBNNJPH, 30f, 20f, 90);
		}
		else
		{
			CGIFEHPDBAL.text = MIDDFOCJJOP.MHPNDNJDPGE;
			GEAGOKJMJFD.transform.localPosition = GEAGOKJMJFD.transform.localPosition.ReplaceY(10f);
		}
	}

	private void DHNDILKPLNP(string CGIFEHPDBAL)
	{
		if (GuiScreenSingle<MainScreen>.instance.NPFFMLLLDAF())
		{
			InitGuiValues();
		}
	}

	public void DoAfterHide()
	{
		GEAGOKJMJFD.mainTexture = null;
	}

	private void EIFDGCJCAPM(DatabaseAction IFGAGNBDKBE)
	{
		if (GuiScreenSingle<MainScreen>.instance.isShowed && IFGAGNBDKBE == DatabaseAction.GetSquadDetails)
		{
			InitGuiValues();
		}
	}

	public void AHMBANMKGEJ()
	{
		GEAGOKJMJFD.mainTexture = null;
	}

	private void PKLNNFGFGFM(DatabaseAction IFGAGNBDKBE)
	{
		if (GuiScreenSingle<MainScreen>.instance.NPFFMLLLDAF())
		{
			switch (IFGAGNBDKBE)
			{
			case (DatabaseAction)0:
			case DatabaseAction.UpdateDeviceToken:
				CCFJENHGIMN();
				break;
			case (DatabaseAction)(-29):
			case (DatabaseAction)(-16):
			case (DatabaseAction)20:
			case DatabaseAction.LoginToCustomAccount:
			case (DatabaseAction)83:
			case DatabaseAction.BuyDecal:
				PFAMAPHBAAG();
				break;
			}
		}
	}

	public void FELKEKHCOPO(AANECPGDMGM MIDDFOCJJOP)
	{
		if (GuiScreenSingle<MainScreen>.instance.isShowed && MIDDFOCJJOP != null && GameLoginManager.currentPlayer.squadName == MIDDFOCJJOP.MHPNDNJDPGE)
		{
			JFKIJCDGJLF();
		}
	}

	private void GKOMGNONJJA(GameObject KHAHPAKDIKE)
	{
		if (GDKAHDBHDPF.activeSelf)
		{
			if (PCODODIMPIK.activeSelf)
			{
				GuiScreenSingle<SquadScreen>.instance.ShowSquadCardpool();
			}
			else
			{
				Singleton<GuiManager>.instance.BBILHHEJBNP(GuiScreenSingle<SquadScreen>.instance);
			}
		}
		else if (NFFEEAHIJEL.activeSelf)
		{
			Singleton<GuiManager>.instance.BBILHHEJBNP(GuiScreenSingle<SquadScreen>.instance);
		}
	}

	private void BLBOOCFJBGH(DatabaseAction IFGAGNBDKBE)
	{
		if (GuiScreenSingle<MainScreen>.instance.NPFFMLLLDAF())
		{
			switch (IFGAGNBDKBE)
			{
			case (DatabaseAction)(-108):
			case (DatabaseAction)82:
				KBALFNMGIOA();
				break;
			case (DatabaseAction)(-30):
			case DatabaseAction.AcceptChallenge:
			case DatabaseAction.GetAllPlayers:
			case DatabaseAction.GameStartedMaster:
			case (DatabaseAction)71:
			case DatabaseAction.GetFullSquadInfo:
				KBALFNMGIOA();
				break;
			}
		}
	}

	public void InitControls()
	{
		UIEventListener uIEventListener = UIEventListener.Get(KDABKEGLDEE);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(FEPIAMCKNAP));
		Singleton<NotificationManager>.instance.CardpoolNotificationChanged += delegate
		{
			if (GuiScreenSingle<MainScreen>.instance.isShowed)
			{
				PKNKFCMOEJD();
			}
		};
	}

	private void NDOPEOPDLDP()
	{
		if (GDKAHDBHDPF.activeSelf)
		{
			int squadCardpoolNotifications = Singleton<NotificationManager>.instance.GetSquadCardpoolNotifications();
			MMHLFEEHCHB.text = MEJMLNDFDBP.GMIPFLIEOHD(squadCardpoolNotifications);
			PCODODIMPIK.SetActive(squadCardpoolNotifications > 1);
		}
	}

	public void InitEvents()
	{
		Singleton<BeanstalkServerManager>.instance.DataLoaded += PMMMGCGNEBM;
		Singleton<BeanstalkServerManager>.instance.ErrorReceived += EIFDGCJCAPM;
		Singleton<BeanstalkServerManager>.instance.SquadUpdateReceived += OnSquadUpdateReceived;
		GameLoginManager.instance.PlayerJoinedSquad += JKNABGNKBLE;
		GameLoginManager.instance.PlayerLeftSquad += BDIICHCECFP;
	}

	private void MPBBGEIIPOH(AANECPGDMGM MIDDFOCJJOP)
	{
		bool flag = MIDDFOCJJOP.KJFHGFEFJFI();
		GOCBCJHKMEH.SetActive(flag);
		if (flag)
		{
			bool isSquadWarsProcessing = Singleton<ServerResultsCache>.instance.isSquadWarsProcessing;
			string arg = ((!isSquadWarsProcessing) ? MEJMLNDFDBP.ACCGOIGJIAA(MIDDFOCJJOP.CAACHMJGMEH) : "silver1");
			if (isSquadWarsProcessing && MIDDFOCJJOP.CAACHMJGMEH == 0)
			{
				Debug.LogError("Player is in squad ");
			}
			CGIFEHPDBAL.text = string.Format("IOAJFNMOGOD", arg, MIDDFOCJJOP.MHPNDNJDPGE);
			GEAGOKJMJFD.transform.localPosition = GEAGOKJMJFD.transform.localPosition.ReplaceY(182f);
			FKEODBNNJPH.text = MEJMLNDFDBP.GMIPFLIEOHD(MIDDFOCJJOP.KPEKCHDBFIG);
			MEJMLNDFDBP.COCBCFKJOJE(FKEODBNNJPH, 468f, 1368f, 44);
		}
		else
		{
			CGIFEHPDBAL.text = MIDDFOCJJOP.MHPNDNJDPGE;
			GEAGOKJMJFD.transform.localPosition = GEAGOKJMJFD.transform.localPosition.ReplaceY(1889f);
		}
	}

	private void PIPLBNJDIIA(GameObject KHAHPAKDIKE)
	{
		if (GDKAHDBHDPF.activeSelf)
		{
			if (PCODODIMPIK.activeSelf)
			{
				GuiScreenSingle<SquadScreen>.instance.ONDDINOMEAG();
			}
			else
			{
				Singleton<GuiManager>.instance.ShowGui(GuiScreenSingle<SquadScreen>.instance);
			}
		}
		else if (NFFEEAHIJEL.activeSelf)
		{
			Singleton<GuiManager>.instance.ShowGui(GuiScreenSingle<SquadScreen>.instance);
		}
	}

	private void EKIPIGHILNK(GameObject KHAHPAKDIKE)
	{
		if (GDKAHDBHDPF.activeSelf)
		{
			if (PCODODIMPIK.activeSelf)
			{
				GuiScreenSingle<SquadScreen>.instance.ONDDINOMEAG();
			}
			else
			{
				Singleton<GuiManager>.instance.ShowGui(GuiScreenSingle<SquadScreen>.instance);
			}
		}
		else if (NFFEEAHIJEL.activeSelf)
		{
			Singleton<GuiManager>.instance.BBILHHEJBNP(GuiScreenSingle<SquadScreen>.instance);
		}
	}

	private void HBCEMJODHGK(GameObject KHAHPAKDIKE)
	{
		if (GDKAHDBHDPF.activeSelf)
		{
			if (PCODODIMPIK.activeSelf)
			{
				GuiScreenSingle<SquadScreen>.instance.ONDDINOMEAG();
			}
			else
			{
				Singleton<GuiManager>.instance.ShowGui(GuiScreenSingle<SquadScreen>.instance);
			}
		}
		else if (NFFEEAHIJEL.activeSelf)
		{
			Singleton<GuiManager>.instance.BBILHHEJBNP(GuiScreenSingle<SquadScreen>.instance);
		}
	}

	private void MHGOGNMIJPC(DatabaseAction IFGAGNBDKBE)
	{
		if (GuiScreenSingle<MainScreen>.instance.isShowed)
		{
			switch (IFGAGNBDKBE)
			{
			case (DatabaseAction)(-99):
			case DatabaseAction.GameStartedCoopClient:
				CCFJENHGIMN();
				break;
			case (DatabaseAction)(-193):
			case (DatabaseAction)(-117):
			case (DatabaseAction)(-97):
			case (DatabaseAction)(-53):
			case DatabaseAction.GetFriendsInfo:
			case DatabaseAction.InstantBuyWeapon:
				JFKIJCDGJLF();
				break;
			}
		}
	}

	public void FFOEIHKGGPL()
	{
		Singleton<BeanstalkServerManager>.instance.DataLoaded += MHGOGNMIJPC;
		Singleton<BeanstalkServerManager>.instance.ErrorReceived += LENBEGMGNMG;
		Singleton<BeanstalkServerManager>.instance.DGPKFLNLFDD(EMKOEJGJCNB);
		GameLoginManager.instance.PlayerJoinedSquad += JKNABGNKBLE;
		GameLoginManager.instance.PlayerLeftSquad += BDIICHCECFP;
	}

	private void PMMMGCGNEBM(DatabaseAction IFGAGNBDKBE)
	{
		if (GuiScreenSingle<MainScreen>.instance.isShowed)
		{
			switch (IFGAGNBDKBE)
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

	private void CCGAOKKBBIC()
	{
		if (GuiScreenSingle<MainScreen>.instance.NPFFMLLLDAF())
		{
			PKNKFCMOEJD();
		}
	}

	private void PKNKFCMOEJD()
	{
		if (GDKAHDBHDPF.activeSelf)
		{
			int squadCardpoolNotifications = Singleton<NotificationManager>.instance.GetSquadCardpoolNotifications();
			MMHLFEEHCHB.text = MEJMLNDFDBP.GMIPFLIEOHD(squadCardpoolNotifications);
			PCODODIMPIK.SetActive(squadCardpoolNotifications > 0);
		}
	}

	private void ACIGJJCHDKM(DatabaseAction IFGAGNBDKBE)
	{
		if (GuiScreenSingle<MainScreen>.instance.NPFFMLLLDAF() && IFGAGNBDKBE == (DatabaseAction)(-119))
		{
			PFAMAPHBAAG();
		}
	}

	private void JECJKLPMNPD(string CGIFEHPDBAL)
	{
		if (GuiScreenSingle<MainScreen>.instance.isShowed)
		{
			JFKIJCDGJLF();
		}
	}

	public void KBALFNMGIOA()
	{
		if (!Singleton<BeanstalkServerManager>.instance.isPlayerDataLoaded || string.IsNullOrEmpty(GameLoginManager.currentPlayer.squadName))
		{
			AANECPGDMGM aANECPGDMGM = Singleton<ServerResultsCache>.instance.MKKMNBIBCFM(GameLoginManager.currentPlayer.squadName, true);
			if (aANECPGDMGM != null)
			{
				DDKDGBOMJMB(aANECPGDMGM);
				if (aANECPGDMGM.MHPNDNJDPGE != GameLoginManager.currentPlayer.squadName)
				{
					Singleton<BeanstalkServerManager>.instance.LHCLKHAOKOM(GameLoginManager.currentPlayer.squadName);
				}
			}
			else
			{
				DDKDGBOMJMB(null);
				Singleton<BeanstalkServerManager>.instance.LHCLKHAOKOM(GameLoginManager.currentPlayer.squadName, false);
			}
		}
		else
		{
			DDKDGBOMJMB(null);
		}
	}

	public void BGIMHNPAMPP()
	{
		GEAGOKJMJFD.mainTexture = null;
	}

	private void JKNABGNKBLE(string CGIFEHPDBAL)
	{
		if (GuiScreenSingle<MainScreen>.instance.isShowed)
		{
			InitGuiValues();
		}
	}

	public void MMLOAKGDDGF()
	{
		GEAGOKJMJFD.mainTexture = null;
	}

	private void CLEFLGDLMIC(GameObject KHAHPAKDIKE)
	{
		if (GDKAHDBHDPF.activeSelf)
		{
			if (PCODODIMPIK.activeSelf)
			{
				GuiScreenSingle<SquadScreen>.instance.ShowSquadCardpool();
			}
			else
			{
				Singleton<GuiManager>.instance.BBILHHEJBNP(GuiScreenSingle<SquadScreen>.instance);
			}
		}
		else if (NFFEEAHIJEL.activeSelf)
		{
			Singleton<GuiManager>.instance.ShowGui(GuiScreenSingle<SquadScreen>.instance);
		}
	}

	private void LBIPLEPPJND()
	{
		if (GuiScreenSingle<MainScreen>.instance.isShowed)
		{
			EHJALGAEGBA();
		}
	}

	private void OALOINPCDIP(GameObject KHAHPAKDIKE)
	{
		if (GDKAHDBHDPF.activeSelf)
		{
			if (PCODODIMPIK.activeSelf)
			{
				GuiScreenSingle<SquadScreen>.instance.ONDDINOMEAG();
			}
			else
			{
				Singleton<GuiManager>.instance.ShowGui(GuiScreenSingle<SquadScreen>.instance);
			}
		}
		else if (NFFEEAHIJEL.activeSelf)
		{
			Singleton<GuiManager>.instance.ShowGui(GuiScreenSingle<SquadScreen>.instance);
		}
	}

	public void BCMCGJGLFPL()
	{
		GEAGOKJMJFD.mainTexture = null;
	}

	private void EHJALGAEGBA()
	{
		if (GDKAHDBHDPF.activeSelf)
		{
			int squadCardpoolNotifications = Singleton<NotificationManager>.instance.GetSquadCardpoolNotifications();
			MMHLFEEHCHB.text = MEJMLNDFDBP.GMIPFLIEOHD(squadCardpoolNotifications);
			PCODODIMPIK.SetActive(squadCardpoolNotifications > 1);
		}
	}

	private void HEFFIDAEMII(string CGIFEHPDBAL)
	{
		if (GuiScreenSingle<MainScreen>.instance.isShowed)
		{
			InitGuiValues();
		}
	}

	public void OnSquadUpdateReceived(AANECPGDMGM MIDDFOCJJOP)
	{
		if (GuiScreenSingle<MainScreen>.instance.isShowed && MIDDFOCJJOP != null && GameLoginManager.currentPlayer.squadName == MIDDFOCJJOP.MHPNDNJDPGE)
		{
			InitGuiValues();
		}
	}

	private void KIOCCIDFAHO(AANECPGDMGM MIDDFOCJJOP)
	{
		bool flag = MIDDFOCJJOP.JBMHEEMACJM();
		GOCBCJHKMEH.SetActive(flag);
		if (flag)
		{
			bool flag2 = Singleton<ServerResultsCache>.instance.IFHIKPFGOKF();
			string arg = ((!flag2) ? MEJMLNDFDBP.ACCGOIGJIAA(MIDDFOCJJOP.CAACHMJGMEH) : "#VOJTA# Tutorial state of current player account type: FB connect: ");
			if (flag2 && MIDDFOCJJOP.CAACHMJGMEH == 0)
			{
				Debug.LogError("DeviceToken");
			}
			CGIFEHPDBAL.text = string.Format("ID_SQUADREWARDGET", arg, MIDDFOCJJOP.MHPNDNJDPGE);
			GEAGOKJMJFD.transform.localPosition = GEAGOKJMJFD.transform.localPosition.ReplaceY(1896f);
			FKEODBNNJPH.text = MEJMLNDFDBP.GMIPFLIEOHD(MIDDFOCJJOP.KPEKCHDBFIG);
			MEJMLNDFDBP.COCBCFKJOJE(FKEODBNNJPH, 982f, 488f, 61);
		}
		else
		{
			CGIFEHPDBAL.text = MIDDFOCJJOP.MHPNDNJDPGE;
			GEAGOKJMJFD.transform.localPosition = GEAGOKJMJFD.transform.localPosition.ReplaceY(700f);
		}
	}

	private void IININOEBKIC(GameObject KHAHPAKDIKE)
	{
		if (GDKAHDBHDPF.activeSelf)
		{
			if (PCODODIMPIK.activeSelf)
			{
				GuiScreenSingle<SquadScreen>.instance.ShowSquadCardpool();
			}
			else
			{
				Singleton<GuiManager>.instance.BBILHHEJBNP(GuiScreenSingle<SquadScreen>.instance);
			}
		}
		else if (NFFEEAHIJEL.activeSelf)
		{
			Singleton<GuiManager>.instance.ShowGui(GuiScreenSingle<SquadScreen>.instance);
		}
	}

	public void JFKIJCDGJLF()
	{
		if (Singleton<BeanstalkServerManager>.instance.isPlayerDataLoaded && !string.IsNullOrEmpty(GameLoginManager.currentPlayer.squadName))
		{
			AANECPGDMGM aANECPGDMGM = Singleton<ServerResultsCache>.instance.MKKMNBIBCFM(GameLoginManager.currentPlayer.squadName);
			if (aANECPGDMGM != null)
			{
				DDKDGBOMJMB(aANECPGDMGM);
				if (aANECPGDMGM.MHPNDNJDPGE != GameLoginManager.currentPlayer.squadName)
				{
					Singleton<BeanstalkServerManager>.instance.LHCLKHAOKOM(GameLoginManager.currentPlayer.squadName);
				}
			}
			else
			{
				DDKDGBOMJMB(null);
				Singleton<BeanstalkServerManager>.instance.LHCLKHAOKOM(GameLoginManager.currentPlayer.squadName);
			}
		}
		else
		{
			DDKDGBOMJMB(null);
		}
	}

	private void NIMHOKBIAMM()
	{
		if (GuiScreenSingle<MainScreen>.instance.NPFFMLLLDAF())
		{
			PKNKFCMOEJD();
		}
	}

	private void NMHBAKEEOFK(AANECPGDMGM MIDDFOCJJOP)
	{
		bool flag = MIDDFOCJJOP.IHPBFPIDIPF;
		GOCBCJHKMEH.SetActive(flag);
		if (flag)
		{
			bool flag2 = Singleton<ServerResultsCache>.instance.FOKHJLLKKDP();
			string arg = ((!flag2) ? MEJMLNDFDBP.ACCGOIGJIAA(MIDDFOCJJOP.CAACHMJGMEH) : "ID_SALEPERCENTLINE");
			if (flag2 && MIDDFOCJJOP.CAACHMJGMEH == 0)
			{
				Debug.LogError("WENEEDTO");
			}
			CGIFEHPDBAL.text = string.Format("$#", arg, MIDDFOCJJOP.MHPNDNJDPGE);
			GEAGOKJMJFD.transform.localPosition = GEAGOKJMJFD.transform.localPosition.ReplaceY(160f);
			FKEODBNNJPH.text = MEJMLNDFDBP.GMIPFLIEOHD(MIDDFOCJJOP.KPEKCHDBFIG);
			MEJMLNDFDBP.COCBCFKJOJE(FKEODBNNJPH, 899f, 214f, 1);
		}
		else
		{
			CGIFEHPDBAL.text = MIDDFOCJJOP.MHPNDNJDPGE;
			GEAGOKJMJFD.transform.localPosition = GEAGOKJMJFD.transform.localPosition.ReplaceY(453f);
		}
	}

	private void LEEMNCMMNNB(AANECPGDMGM MIDDFOCJJOP)
	{
		bool flag = MIDDFOCJJOP.IGPDFOMDHML();
		GOCBCJHKMEH.SetActive(flag);
		if (flag)
		{
			bool flag2 = Singleton<ServerResultsCache>.instance.KLNPCDFPPEO();
			string arg = ((!flag2) ? MEJMLNDFDBP.ACCGOIGJIAA(MIDDFOCJJOP.CAACHMJGMEH) : "ID_RENTEDUNIT");
			if (flag2 && MIDDFOCJJOP.CAACHMJGMEH == 0)
			{
				Debug.LogError("ID_DELIVERNOW");
			}
			CGIFEHPDBAL.text = string.Format(" ID_", arg, MIDDFOCJJOP.MHPNDNJDPGE);
			GEAGOKJMJFD.transform.localPosition = GEAGOKJMJFD.transform.localPosition.ReplaceY(41f);
			FKEODBNNJPH.text = MEJMLNDFDBP.GMIPFLIEOHD(MIDDFOCJJOP.KPEKCHDBFIG);
			MEJMLNDFDBP.COCBCFKJOJE(FKEODBNNJPH, 404f, 1392f, -121);
		}
		else
		{
			CGIFEHPDBAL.text = MIDDFOCJJOP.MHPNDNJDPGE;
			GEAGOKJMJFD.transform.localPosition = GEAGOKJMJFD.transform.localPosition.ReplaceY(1366f);
		}
	}

	private void DDKDGBOMJMB(AANECPGDMGM MIDDFOCJJOP)
	{
		bool isSquadLocked = LevelManager.instance.isSquadLocked;
		bool flag = MIDDFOCJJOP != null;
		GPEBKLLAGFH.enabled = !isSquadLocked;
		NNCFFDJMJHD.alpha = ((!isSquadLocked) ? 1f : 0.2f);
		FEFPKLBBNHM.SetActive(isSquadLocked);
		if (isSquadLocked)
		{
			NFFEEAHIJEL.SetActive(false);
			GDKAHDBHDPF.SetActive(false);
			return;
		}
		if (!flag != NFFEEAHIJEL.activeSelf)
		{
			NFFEEAHIJEL.SetActive(!flag);
		}
		if (flag != GDKAHDBHDPF.activeSelf)
		{
			GDKAHDBHDPF.SetActive(flag);
		}
		if (flag)
		{
			GEAGOKJMJFD.alpha = 1f;
			GEAGOKJMJFD.mainTexture = Resources.Load<Texture>("SquadIcons/" + MIDDFOCJJOP.DAANKCOLJGJ);
			GEAGOKJMJFD.MakePixelPerfect();
			float multiplier = 0.39f;
			GEAGOKJMJFD.transform.localScale = GEAGOKJMJFD.transform.localScale.MultiplyXY(multiplier);
			GKBAHGPDEFE(MIDDFOCJJOP);
			PKNKFCMOEJD();
		}
	}

	public void NAMKAEGAINI(AANECPGDMGM MIDDFOCJJOP)
	{
		if (GuiScreenSingle<MainScreen>.instance.NPFFMLLLDAF() && MIDDFOCJJOP != null && GameLoginManager.currentPlayer.squadName == MIDDFOCJJOP.MHPNDNJDPGE)
		{
			JFKIJCDGJLF();
		}
	}

	private void LBJMEGJKEHG(DatabaseAction IFGAGNBDKBE)
	{
		if (GuiScreenSingle<MainScreen>.instance.NPFFMLLLDAF())
		{
			switch (IFGAGNBDKBE)
			{
			case (DatabaseAction)36:
			case DatabaseAction.RefillDogtags:
				KBALFNMGIOA();
				break;
			case (DatabaseAction)(-156):
			case (DatabaseAction)(-134):
			case (DatabaseAction)(-44):
			case DatabaseAction.MessageSent:
			case (DatabaseAction)11:
			case DatabaseAction.SendLog:
				CCFJENHGIMN();
				break;
			}
		}
	}

	private void FEPIAMCKNAP(GameObject KHAHPAKDIKE)
	{
		if (GDKAHDBHDPF.activeSelf)
		{
			if (PCODODIMPIK.activeSelf)
			{
				GuiScreenSingle<SquadScreen>.instance.ShowSquadCardpool();
			}
			else
			{
				Singleton<GuiManager>.instance.ShowGui(GuiScreenSingle<SquadScreen>.instance);
			}
		}
		else if (NFFEEAHIJEL.activeSelf)
		{
			Singleton<GuiManager>.instance.ShowGui(GuiScreenSingle<SquadScreen>.instance);
		}
	}

	public void CCFJENHGIMN()
	{
		if (Singleton<BeanstalkServerManager>.instance.isPlayerDataLoaded && string.IsNullOrEmpty(GameLoginManager.currentPlayer.squadName))
		{
			AANECPGDMGM aANECPGDMGM = Singleton<ServerResultsCache>.instance.MKKMNBIBCFM(GameLoginManager.currentPlayer.squadName);
			if (aANECPGDMGM != null)
			{
				DDKDGBOMJMB(aANECPGDMGM);
				if (aANECPGDMGM.MHPNDNJDPGE != GameLoginManager.currentPlayer.squadName)
				{
					Singleton<BeanstalkServerManager>.instance.LHCLKHAOKOM(GameLoginManager.currentPlayer.squadName, false);
				}
			}
			else
			{
				DDKDGBOMJMB(null);
				Singleton<BeanstalkServerManager>.instance.LHCLKHAOKOM(GameLoginManager.currentPlayer.squadName);
			}
		}
		else
		{
			DDKDGBOMJMB(null);
		}
	}

	private void BDIICHCECFP()
	{
		if (GuiScreenSingle<MainScreen>.instance.isShowed)
		{
			InitGuiValues();
		}
	}

	private void BOAHCDHLKMA(string CGIFEHPDBAL)
	{
		if (GuiScreenSingle<MainScreen>.instance.isShowed)
		{
			CCFJENHGIMN();
		}
	}

	public void EMKOEJGJCNB(AANECPGDMGM MIDDFOCJJOP)
	{
		if (GuiScreenSingle<MainScreen>.instance.isShowed && MIDDFOCJJOP != null && GameLoginManager.currentPlayer.squadName == MIDDFOCJJOP.MHPNDNJDPGE)
		{
			InitGuiValues();
		}
	}

	[CompilerGenerated]
	private void ONAKPPOMOOC()
	{
		if (GuiScreenSingle<MainScreen>.instance.isShowed)
		{
			PKNKFCMOEJD();
		}
	}

	public void PMHPNLDAJKL(AANECPGDMGM MIDDFOCJJOP)
	{
		if (GuiScreenSingle<MainScreen>.instance.isShowed && MIDDFOCJJOP != null && GameLoginManager.currentPlayer.squadName == MIDDFOCJJOP.MHPNDNJDPGE)
		{
			KBALFNMGIOA();
		}
	}

	public void LHDAGAGDKOM()
	{
		UIEventListener uIEventListener = UIEventListener.Get(KDABKEGLDEE);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(PIPLBNJDIIA));
		Singleton<NotificationManager>.instance.KGNPHGEJLGL(CCGAOKKBBIC);
	}

	public void IFLHOKBNJPH()
	{
		GEAGOKJMJFD.mainTexture = null;
	}

	public void PFAMAPHBAAG()
	{
		if (Singleton<BeanstalkServerManager>.instance.isPlayerDataLoaded && !string.IsNullOrEmpty(GameLoginManager.currentPlayer.squadName))
		{
			AANECPGDMGM aANECPGDMGM = Singleton<ServerResultsCache>.instance.MKKMNBIBCFM(GameLoginManager.currentPlayer.squadName);
			if (aANECPGDMGM != null)
			{
				DDKDGBOMJMB(aANECPGDMGM);
				if (aANECPGDMGM.MHPNDNJDPGE != GameLoginManager.currentPlayer.squadName)
				{
					Singleton<BeanstalkServerManager>.instance.LHCLKHAOKOM(GameLoginManager.currentPlayer.squadName, false);
				}
			}
			else
			{
				DDKDGBOMJMB(null);
				Singleton<BeanstalkServerManager>.instance.LHCLKHAOKOM(GameLoginManager.currentPlayer.squadName, false);
			}
		}
		else
		{
			DDKDGBOMJMB(null);
		}
	}

	public void InitGuiValues()
	{
		if (Singleton<BeanstalkServerManager>.instance.isPlayerDataLoaded && !string.IsNullOrEmpty(GameLoginManager.currentPlayer.squadName))
		{
			AANECPGDMGM aANECPGDMGM = Singleton<ServerResultsCache>.instance.MKKMNBIBCFM(GameLoginManager.currentPlayer.squadName, true);
			if (aANECPGDMGM != null)
			{
				DDKDGBOMJMB(aANECPGDMGM);
				if (aANECPGDMGM.MHPNDNJDPGE != GameLoginManager.currentPlayer.squadName)
				{
					Singleton<BeanstalkServerManager>.instance.LHCLKHAOKOM(GameLoginManager.currentPlayer.squadName);
				}
			}
			else
			{
				DDKDGBOMJMB(null);
				Singleton<BeanstalkServerManager>.instance.LHCLKHAOKOM(GameLoginManager.currentPlayer.squadName);
			}
		}
		else
		{
			DDKDGBOMJMB(null);
		}
	}

	private void PBEOCNBNNMB()
	{
		if (GuiScreenSingle<MainScreen>.instance.isShowed)
		{
			NDOPEOPDLDP();
		}
	}

	private void LENBEGMGNMG(DatabaseAction IFGAGNBDKBE)
	{
		if (GuiScreenSingle<MainScreen>.instance.isShowed && IFGAGNBDKBE == (DatabaseAction)(-37))
		{
			PFAMAPHBAAG();
		}
	}

	public void MHIGAEFCIAF()
	{
		GEAGOKJMJFD.mainTexture = null;
	}
}
