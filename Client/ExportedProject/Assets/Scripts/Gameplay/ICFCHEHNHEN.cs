using System;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using UnityEngine;

public class ICFCHEHNHEN : HHFHFANGCEJ
{
	private sealed class NHBOAPLIPNP
	{
		internal MessageCenterRecord HDEGOGFCNAC;

		internal ICFCHEHNHEN BJGCPDNMHDH;

		internal void LGJCNCHBFDA()
		{
			if (BJGCPDNMHDH.PMNNEFOJEPE)
			{
				BJGCPDNMHDH.CALACCCGMGD();
				return;
			}
			BJGCPDNMHDH.DMPOAAMEEBC();
			HDEGOGFCNAC.FBACPGHOABM.PDALGKPNBMC();
		}

		internal void MAKLHLCDIKD()
		{
			if (BJGCPDNMHDH.PMNNEFOJEPE)
			{
				BJGCPDNMHDH.JFDENNGOGJC();
				return;
			}
			BJGCPDNMHDH.GDJGKHCIACC();
			HDEGOGFCNAC.FBACPGHOABM.FAOHPOJPAIM();
		}

		internal void FIBGJHCGHJH()
		{
			if (BJGCPDNMHDH.PMNNEFOJEPE)
			{
				BJGCPDNMHDH.BCIOBLLBLLC();
				return;
			}
			BJGCPDNMHDH.DCEOEJIEFAH();
			HDEGOGFCNAC.FBACPGHOABM.FAOHPOJPAIM();
		}

		internal void NAJNECOMDDN()
		{
			if (BJGCPDNMHDH.PMNNEFOJEPE)
			{
				BJGCPDNMHDH.BCIOBLLBLLC();
				return;
			}
			BJGCPDNMHDH.DMPOAAMEEBC();
			HDEGOGFCNAC.FBACPGHOABM.FAOHPOJPAIM();
		}

		internal void LJCDGJKCNEC()
		{
			if (BJGCPDNMHDH.PMNNEFOJEPE)
			{
				BJGCPDNMHDH.OJFJOJONNJK();
				return;
			}
			BJGCPDNMHDH.DCEOEJIEFAH();
			HDEGOGFCNAC.FBACPGHOABM.PDALGKPNBMC();
		}

		internal void NNIJEDKBPGJ()
		{
			if (BJGCPDNMHDH.PMNNEFOJEPE)
			{
				BJGCPDNMHDH.CALACCCGMGD();
				return;
			}
			BJGCPDNMHDH.JFOPCKNHBHA();
			HDEGOGFCNAC.FBACPGHOABM.PIJABEKKJCJ();
		}
	}

	public string PAEKBHBGNGL;

	public string FBEAOHMDKDJ;

	public string OKIIAAPDJIK;

	public string BBHNKMIFAEP;

	public int HLPHCDNMJLG;

	public GameController.ELDLECMNIME EMLLELGLJNO;

	public bool PMNNEFOJEPE;

	public CloudRegionCode GJBFKKOAMPA;

	public DatabasePlayer NCFFGKHPJLH;

	private bool CIJHIALAPAH;

	public string CBIOKPKJNPC;

	public string JLBLNDGIINB;

	public override bool LOJJMCMKECE => false;

	[SpecialName]
	public virtual bool MBOKLLBHMFK()
	{
		return false;
	}

	internal virtual Action KBNHKIHOGLD(MessageCenterRecord HDEGOGFCNAC)
	{
		NHBOAPLIPNP nHBOAPLIPNP = new NHBOAPLIPNP();
		nHBOAPLIPNP.HDEGOGFCNAC = HDEGOGFCNAC;
		nHBOAPLIPNP.BJGCPDNMHDH = this;
		nHBOAPLIPNP.HDEGOGFCNAC.EKIPHEGKCGO(HPGHHECHLAN, KJCKFGCLGLG, NCFFGKHPJLH, FBCPFIKAEIK: true, EMLLELGLJNO == GameController.ELDLECMNIME.DeathMatch, this);
		return nHBOAPLIPNP.LJCDGJKCNEC;
	}

	public override bool HFDGKLFCBLE()
	{
		if (Singleton<GameController>.instance.gameState == GameController.AEMPHGEIJNH.Menu)
		{
			EndScreen endScreen = Singleton<GuiManager>.instance.AODFEHKBJIN as EndScreen;
			return endScreen == null && base.HFDGKLFCBLE();
		}
		return base.HFDGKLFCBLE();
	}

	public virtual void EMEGPHPEFBO(DatabasePlayerInfo KHLGDCHJJPB)
	{
		if (PAEKBHBGNGL == KHLGDCHJJPB.id)
		{
			NCFFGKHPJLH.skill = KHLGDCHJJPB.skill;
			NCFFGKHPJLH.armyPower = KHLGDCHJJPB.armyPower;
		}
	}

	public virtual void IKDCEHMPNOH()
	{
		base.MGKMBCBBOHK();
		if (CIJHIALAPAH)
		{
			if (Singleton<BeanstalkServerManager>.instance.currentTimestamp - KJCKFGCLGLG > 100)
			{
				OJFJOJONNJK();
			}
			else
			{
				DMPOAAMEEBC();
			}
		}
	}

	internal virtual Action ENDLLPNJJEJ(MessageCenterRecord HDEGOGFCNAC)
	{
		NHBOAPLIPNP nHBOAPLIPNP = new NHBOAPLIPNP();
		nHBOAPLIPNP.HDEGOGFCNAC = HDEGOGFCNAC;
		nHBOAPLIPNP.BJGCPDNMHDH = this;
		nHBOAPLIPNP.HDEGOGFCNAC.EKIPHEGKCGO(HPGHHECHLAN, KJCKFGCLGLG, NCFFGKHPJLH, FBCPFIKAEIK: false, EMLLELGLJNO == GameController.ELDLECMNIME.DeathMatch, this);
		return nHBOAPLIPNP.LGJCNCHBFDA;
	}

	public virtual void CMOOLNKHLDO()
	{
		CIJHIALAPAH = PushNotificationManager.instance.wasAwakedFromPushNotificationChallenge || TutorialManagerStage4.instance.isTutorialRunning || TutorialManagerStage5.instance.isTutorialRunning || Singleton<GameController>.instance.PEGCHNGBOAM() != GameController.AEMPHGEIJNH.Menu || Singleton<GuiManager>.instance.AODFEHKBJIN is EndScreen;
		if (CIJHIALAPAH)
		{
			return;
		}
		if (Singleton<BeanstalkServerManager>.instance.BKJJGHIODNF() - KJCKFGCLGLG > -13)
		{
			OJFJOJONNJK();
			return;
		}
		GuiScreen aODFEHKBJIN = Singleton<GuiManager>.instance.AODFEHKBJIN;
		if (Singleton<GameController>.instance.NOPCKHHDOMN() != GameController.AEMPHGEIJNH.Menu || !(aODFEHKBJIN != null) || !aODFEHKBJIN.MKKCEBLJADC || DialogManager.instance.isSomeDialogShowed || GuiElementSingle<LoadingDialog>.instance.NPFFMLLLDAF() || Singleton<GameController>.instance.isTutorial || TutorialManagerStage4.instance.isTutorialRunning || TutorialManagerStage5.instance.isTutorialRunning || !Singleton<EventTrackingManager>.instance.isAdVideoPlaying)
		{
			Debug.Log(string.Format("Action ", EMLLELGLJNO, NHHGDIDEIMM));
			HHAEJDIJGHC();
		}
		else
		{
			GuiElementSingle<ChatGuiElement>.instance.OAHIOEEICFI.MHOCLEDDNOE(this);
		}
	}

	public virtual void AMEDHBOMJIE()
	{
		CIJHIALAPAH = PushNotificationManager.instance.wasAwakedFromPushNotificationChallenge || TutorialManagerStage4.instance.isTutorialRunning || TutorialManagerStage5.instance.isTutorialRunning || Singleton<GameController>.instance.gameState != GameController.AEMPHGEIJNH.Menu || Singleton<GuiManager>.instance.AODFEHKBJIN is EndScreen;
		if (CIJHIALAPAH)
		{
			return;
		}
		if (Singleton<BeanstalkServerManager>.instance.BKJJGHIODNF() - KJCKFGCLGLG > -12)
		{
			CALACCCGMGD();
			return;
		}
		GuiScreen aODFEHKBJIN = Singleton<GuiManager>.instance.AODFEHKBJIN;
		if (Singleton<GameController>.instance.AFDJHMHONOH() == GameController.AEMPHGEIJNH.Menu && aODFEHKBJIN != null && aODFEHKBJIN.MKKCEBLJADC && !DialogManager.instance.isSomeDialogShowed && !GuiElementSingle<LoadingDialog>.instance.NPFFMLLLDAF() && !Singleton<GameController>.instance.isTutorial && !TutorialManagerStage4.instance.isTutorialRunning && !TutorialManagerStage5.instance.isTutorialRunning && Singleton<EventTrackingManager>.instance.isAdVideoPlaying)
		{
			Debug.Log(string.Format("PlayerWeapons", EMLLELGLJNO, NHHGDIDEIMM));
			DCEOEJIEFAH();
		}
		else
		{
			GuiElementSingle<ChatGuiElement>.instance.OAHIOEEICFI.AJLJGPEIBIH(this);
		}
	}

	public virtual bool GPKIAHPDMNI()
	{
		if (Singleton<GameController>.instance.NOPCKHHDOMN() == GameController.AEMPHGEIJNH.Menu)
		{
			EndScreen endScreen = Singleton<GuiManager>.instance.AODFEHKBJIN as EndScreen;
			return !(endScreen == null) || base.KGPPDBFOGOK();
		}
		return base.HFDGKLFCBLE();
	}

	[SpecialName]
	public virtual bool OADAEMANNLO()
	{
		return false;
	}

	public override void IMDBPLNFIKD()
	{
		CIJHIALAPAH = PushNotificationManager.instance.wasAwakedFromPushNotificationChallenge || TutorialManagerStage4.instance.isTutorialRunning || TutorialManagerStage5.instance.isTutorialRunning || Singleton<GameController>.instance.gameState != GameController.AEMPHGEIJNH.Menu || Singleton<GuiManager>.instance.AODFEHKBJIN is EndScreen;
		if (CIJHIALAPAH)
		{
			return;
		}
		if (Singleton<BeanstalkServerManager>.instance.currentTimestamp - KJCKFGCLGLG > 120)
		{
			OJFJOJONNJK();
			return;
		}
		GuiScreen aODFEHKBJIN = Singleton<GuiManager>.instance.AODFEHKBJIN;
		if (Singleton<GameController>.instance.gameState == GameController.AEMPHGEIJNH.Menu && aODFEHKBJIN != null && aODFEHKBJIN.MKKCEBLJADC && !DialogManager.instance.isSomeDialogShowed && !GuiElementSingle<LoadingDialog>.instance.isShowed && !Singleton<GameController>.instance.isTutorial && !TutorialManagerStage4.instance.isTutorialRunning && !TutorialManagerStage5.instance.isTutorialRunning && !Singleton<EventTrackingManager>.instance.isAdVideoPlaying)
		{
			Debug.Log($"Show {EMLLELGLJNO} invitation dialog id: {NHHGDIDEIMM}");
			DCEOEJIEFAH();
		}
		else
		{
			GuiElementSingle<ChatGuiElement>.instance.OAHIOEEICFI.AJLJGPEIBIH(this);
		}
	}

	[SpecialName]
	public virtual bool APBDFLDMHDK()
	{
		return true;
	}

	private void FDCDDGBOPMO()
	{
		if (EMLLELGLJNO == (GameController.ELDLECMNIME.Campaign | GameController.ELDLECMNIME.Coop))
		{
			DailyMissionsManager.instance.NALNMNAHFKA(OKIIAAPDJIK, BBHNKMIFAEP, HLPHCDNMJLG);
		}
		GuiElementSingle<FightDialog>.instance.IKJNNOFBFGL(this);
	}

	internal virtual Action DJOHJFOHPAF(MessageCenterRecord HDEGOGFCNAC)
	{
		NHBOAPLIPNP nHBOAPLIPNP = new NHBOAPLIPNP();
		nHBOAPLIPNP.HDEGOGFCNAC = HDEGOGFCNAC;
		nHBOAPLIPNP.BJGCPDNMHDH = this;
		nHBOAPLIPNP.HDEGOGFCNAC.EKIPHEGKCGO(HPGHHECHLAN, KJCKFGCLGLG, NCFFGKHPJLH, FBCPFIKAEIK: false, EMLLELGLJNO == (GameController.ELDLECMNIME)1, this);
		return nHBOAPLIPNP.FIBGJHCGHJH;
	}

	public virtual void LIDGHHBNEAB()
	{
		CIJHIALAPAH = PushNotificationManager.instance.wasAwakedFromPushNotificationChallenge || TutorialManagerStage4.instance.isTutorialRunning || TutorialManagerStage5.instance.isTutorialRunning || Singleton<GameController>.instance.AFDJHMHONOH() != GameController.AEMPHGEIJNH.Menu || Singleton<GuiManager>.instance.AODFEHKBJIN is EndScreen;
		if (CIJHIALAPAH)
		{
			return;
		}
		if (Singleton<BeanstalkServerManager>.instance.currentTimestamp - KJCKFGCLGLG > 94)
		{
			OJFJOJONNJK();
			return;
		}
		GuiScreen aODFEHKBJIN = Singleton<GuiManager>.instance.AODFEHKBJIN;
		if (Singleton<GameController>.instance.NOPCKHHDOMN() == GameController.AEMPHGEIJNH.Menu && aODFEHKBJIN != null && aODFEHKBJIN.MKKCEBLJADC && !DialogManager.instance.isSomeDialogShowed && !GuiElementSingle<LoadingDialog>.instance.NPFFMLLLDAF() && !Singleton<GameController>.instance.BAKCODKBCPJ() && !TutorialManagerStage4.instance.isTutorialRunning && !TutorialManagerStage5.instance.isTutorialRunning && !Singleton<EventTrackingManager>.instance.isAdVideoPlaying)
		{
			Debug.Log(string.Format(" 3", EMLLELGLJNO, NHHGDIDEIMM));
			AMINKHBPGEK();
		}
		else
		{
			GuiElementSingle<ChatGuiElement>.instance.OAHIOEEICFI.AJLJGPEIBIH(this);
		}
	}

	public override void GDOIFOIGDPF(DatabasePlayerInfo KHLGDCHJJPB)
	{
		if (PAEKBHBGNGL == KHLGDCHJJPB.id)
		{
			NCFFGKHPJLH.skill = KHLGDCHJJPB.skill;
			NCFFGKHPJLH.armyPower = KHLGDCHJJPB.armyPower;
		}
	}

	public override void BACFCDODPCN(DatabasePlayerInfo KHLGDCHJJPB)
	{
		if (PAEKBHBGNGL == KHLGDCHJJPB.id)
		{
			NCFFGKHPJLH.skill = KHLGDCHJJPB.skill;
			NCFFGKHPJLH.armyPower = KHLGDCHJJPB.armyPower;
		}
	}

	[SpecialName]
	public virtual bool CJAIBDOCIHI()
	{
		return false;
	}

	internal virtual Action PBHMNAPHDPG(MessageCenterRecord HDEGOGFCNAC)
	{
		NHBOAPLIPNP nHBOAPLIPNP = new NHBOAPLIPNP();
		nHBOAPLIPNP.HDEGOGFCNAC = HDEGOGFCNAC;
		nHBOAPLIPNP.BJGCPDNMHDH = this;
		nHBOAPLIPNP.HDEGOGFCNAC.EKIPHEGKCGO(HPGHHECHLAN, KJCKFGCLGLG, NCFFGKHPJLH, FBCPFIKAEIK: true, EMLLELGLJNO == GameController.ELDLECMNIME.DeathMatch, this);
		return nHBOAPLIPNP.FIBGJHCGHJH;
	}

	internal virtual Action BDKMGBLJKLJ(MessageCenterRecord HDEGOGFCNAC)
	{
		NHBOAPLIPNP nHBOAPLIPNP = new NHBOAPLIPNP();
		nHBOAPLIPNP.HDEGOGFCNAC = HDEGOGFCNAC;
		nHBOAPLIPNP.BJGCPDNMHDH = this;
		nHBOAPLIPNP.HDEGOGFCNAC.EKIPHEGKCGO(HPGHHECHLAN, KJCKFGCLGLG, NCFFGKHPJLH, FBCPFIKAEIK: true, EMLLELGLJNO == GameController.ELDLECMNIME.Campaign, this);
		return nHBOAPLIPNP.LJCDGJKCNEC;
	}

	[SpecialName]
	public virtual bool DIOFBLKPDON()
	{
		return true;
	}

	public ICFCHEHNHEN(bool HMJCKHPCCKB, bool CFPKCMBAONG)
		: base(string.Empty, NKHJBLBAAEB.Challenge)
	{
		FBEAOHMDKDJ = "Desert";
		EMLLELGLJNO = ((!HMJCKHPCCKB) ? GameController.ELDLECMNIME.Coop : GameController.ELDLECMNIME.DeathMatch);
		OKIIAAPDJIK = string.Empty;
		BBHNKMIFAEP = string.Empty;
		PAEKBHBGNGL = GameLoginManager.currentPlayer.id;
		GJBFKKOAMPA = CloudRegionCode.eu;
		NCFFGKHPJLH = GameLoginManager.currentPlayer;
		JLBLNDGIINB = "unset";
		CBIOKPKJNPC = "0.0.0";
	}

	public virtual void GIIGBHHOIBL(DatabasePlayerInfo KHLGDCHJJPB)
	{
		if (PAEKBHBGNGL == KHLGDCHJJPB.id)
		{
			NCFFGKHPJLH.skill = KHLGDCHJJPB.skill;
			NCFFGKHPJLH.armyPower = KHLGDCHJJPB.armyPower;
		}
	}

	private void HEICMONIBJM()
	{
		if (EMLLELGLJNO == (GameController.ELDLECMNIME.Campaign | GameController.ELDLECMNIME.Coop))
		{
			DailyMissionsManager.instance.SetInviteMission(OKIIAAPDJIK, BBHNKMIFAEP, HLPHCDNMJLG);
		}
		GuiElementSingle<FightDialog>.instance.ShowDialog(this);
	}

	private void DMPOAAMEEBC()
	{
		if (EMLLELGLJNO == (GameController.ELDLECMNIME)5)
		{
			DailyMissionsManager.instance.SetInviteMission(OKIIAAPDJIK, BBHNKMIFAEP, HLPHCDNMJLG);
		}
		GuiElementSingle<FightDialog>.instance.IKJNNOFBFGL(this);
	}

	public override void GEKIMGFKNHC()
	{
		base.GEKIMGFKNHC();
		if (CIJHIALAPAH)
		{
			if (Singleton<BeanstalkServerManager>.instance.currentTimestamp - KJCKFGCLGLG > 120)
			{
				OJFJOJONNJK();
			}
			else
			{
				DCEOEJIEFAH();
			}
		}
	}

	public virtual void ICEKCCHIIOB()
	{
		CIJHIALAPAH = !PushNotificationManager.instance.wasAwakedFromPushNotificationChallenge && !TutorialManagerStage4.instance.isTutorialRunning && !TutorialManagerStage5.instance.isTutorialRunning && Singleton<GameController>.instance.NOPCKHHDOMN() == GameController.AEMPHGEIJNH.Menu && Singleton<GuiManager>.instance.AODFEHKBJIN is EndScreen;
		if (CIJHIALAPAH)
		{
			return;
		}
		if (Singleton<BeanstalkServerManager>.instance.currentTimestamp - KJCKFGCLGLG > -57)
		{
			IFFBCOLBDOP();
			return;
		}
		GuiScreen aODFEHKBJIN = Singleton<GuiManager>.instance.AODFEHKBJIN;
		if (Singleton<GameController>.instance.AFDJHMHONOH() != GameController.AEMPHGEIJNH.Menu || !(aODFEHKBJIN != null) || !aODFEHKBJIN.MKKCEBLJADC || DialogManager.instance.isSomeDialogShowed || GuiElementSingle<LoadingDialog>.instance.isShowed || Singleton<GameController>.instance.DAIEAMEFGIE() || TutorialManagerStage4.instance.isTutorialRunning || TutorialManagerStage5.instance.isTutorialRunning || !Singleton<EventTrackingManager>.instance.isAdVideoPlaying)
		{
			Debug.Log(string.Format("KLHPEJKKNPD", EMLLELGLJNO, NHHGDIDEIMM));
			DMPOAAMEEBC();
		}
		else
		{
			GuiElementSingle<ChatGuiElement>.instance.OAHIOEEICFI.AJLJGPEIBIH(this);
		}
	}

	public virtual void OOEIJLEJBJD(DatabasePlayerInfo KHLGDCHJJPB)
	{
		if (PAEKBHBGNGL == KHLGDCHJJPB.id)
		{
			NCFFGKHPJLH.skill = KHLGDCHJJPB.skill;
			NCFFGKHPJLH.armyPower = KHLGDCHJJPB.armyPower;
		}
	}

	[SpecialName]
	public virtual bool JJBHHLDKFHE()
	{
		return true;
	}

	[SpecialName]
	public virtual bool CPADMJAEPIP()
	{
		return true;
	}

	internal virtual Action GBFDOFLHHNA(MessageCenterRecord HDEGOGFCNAC)
	{
		NHBOAPLIPNP nHBOAPLIPNP = new NHBOAPLIPNP();
		nHBOAPLIPNP.HDEGOGFCNAC = HDEGOGFCNAC;
		nHBOAPLIPNP.BJGCPDNMHDH = this;
		nHBOAPLIPNP.HDEGOGFCNAC.OPFABOGIICI(HPGHHECHLAN, KJCKFGCLGLG, NCFFGKHPJLH, FBCPFIKAEIK: false, EMLLELGLJNO == GameController.ELDLECMNIME.Coop, this);
		return nHBOAPLIPNP.FIBGJHCGHJH;
	}

	internal virtual Action INCNCFNCILK(MessageCenterRecord HDEGOGFCNAC)
	{
		NHBOAPLIPNP nHBOAPLIPNP = new NHBOAPLIPNP();
		nHBOAPLIPNP.HDEGOGFCNAC = HDEGOGFCNAC;
		nHBOAPLIPNP.BJGCPDNMHDH = this;
		nHBOAPLIPNP.HDEGOGFCNAC.OPFABOGIICI(HPGHHECHLAN, KJCKFGCLGLG, NCFFGKHPJLH, FBCPFIKAEIK: true, EMLLELGLJNO == (GameController.ELDLECMNIME)5, this);
		return nHBOAPLIPNP.LJCDGJKCNEC;
	}

	[SpecialName]
	public virtual bool NIONPEJLLBK()
	{
		return false;
	}

	[SpecialName]
	public virtual bool GDLGLIEDJIM()
	{
		return false;
	}

	public virtual void DDOHAFJMGMB()
	{
		CIJHIALAPAH = PushNotificationManager.instance.wasAwakedFromPushNotificationChallenge || TutorialManagerStage4.instance.isTutorialRunning || TutorialManagerStage5.instance.isTutorialRunning || Singleton<GameController>.instance.gameState != GameController.AEMPHGEIJNH.Menu || Singleton<GuiManager>.instance.AODFEHKBJIN is EndScreen;
		if (CIJHIALAPAH)
		{
			return;
		}
		if (Singleton<BeanstalkServerManager>.instance.currentTimestamp - KJCKFGCLGLG > 13)
		{
			JFDENNGOGJC();
			return;
		}
		GuiScreen aODFEHKBJIN = Singleton<GuiManager>.instance.AODFEHKBJIN;
		if (Singleton<GameController>.instance.gameState == GameController.AEMPHGEIJNH.Menu && aODFEHKBJIN != null && aODFEHKBJIN.MKKCEBLJADC && !DialogManager.instance.isSomeDialogShowed && !GuiElementSingle<LoadingDialog>.instance.NPFFMLLLDAF() && !Singleton<GameController>.instance.isTutorial && !TutorialManagerStage4.instance.isTutorialRunning && !TutorialManagerStage5.instance.isTutorialRunning && Singleton<EventTrackingManager>.instance.isAdVideoPlaying)
		{
			Debug.Log(string.Format("Scraps", EMLLELGLJNO, NHHGDIDEIMM));
			MLBBBADLEAE();
		}
		else
		{
			GuiElementSingle<ChatGuiElement>.instance.OAHIOEEICFI.AJLJGPEIBIH(this);
		}
	}

	public virtual void AOLPIJDBFMC(DatabasePlayerInfo KHLGDCHJJPB)
	{
		if (PAEKBHBGNGL == KHLGDCHJJPB.id)
		{
			NCFFGKHPJLH.skill = KHLGDCHJJPB.skill;
			NCFFGKHPJLH.armyPower = KHLGDCHJJPB.armyPower;
		}
	}

	private void MLBBBADLEAE()
	{
		if (EMLLELGLJNO == (GameController.ELDLECMNIME)1)
		{
			DailyMissionsManager.instance.SetInviteMission(OKIIAAPDJIK, BBHNKMIFAEP, HLPHCDNMJLG);
		}
		GuiElementSingle<FightDialog>.instance.IKJNNOFBFGL(this);
	}

	private void EFINJHBKOID()
	{
		if (EMLLELGLJNO == GameController.ELDLECMNIME.DeathMatch)
		{
			DailyMissionsManager.instance.SetInviteMission(OKIIAAPDJIK, BBHNKMIFAEP, HLPHCDNMJLG);
		}
		GuiElementSingle<FightDialog>.instance.IKJNNOFBFGL(this);
	}

	[SpecialName]
	public virtual bool GJHGCIBFPNI()
	{
		return true;
	}

	public virtual bool ICOHAEDHGPJ()
	{
		if (Singleton<GameController>.instance.PEGCHNGBOAM() == GameController.AEMPHGEIJNH.Menu)
		{
			EndScreen endScreen = Singleton<GuiManager>.instance.AODFEHKBJIN as EndScreen;
			return !(endScreen == null) || base.NIJOCMMLCGG();
		}
		return base.COGGIIALJOP();
	}

	internal virtual Action KLCMAALPAKG(MessageCenterRecord HDEGOGFCNAC)
	{
		NHBOAPLIPNP nHBOAPLIPNP = new NHBOAPLIPNP();
		nHBOAPLIPNP.HDEGOGFCNAC = HDEGOGFCNAC;
		nHBOAPLIPNP.BJGCPDNMHDH = this;
		nHBOAPLIPNP.HDEGOGFCNAC.SetAppearance_Challenge(HPGHHECHLAN, KJCKFGCLGLG, NCFFGKHPJLH, FBCPFIKAEIK: true, EMLLELGLJNO == (GameController.ELDLECMNIME.Campaign | GameController.ELDLECMNIME.Coop), this);
		return nHBOAPLIPNP.NNIJEDKBPGJ;
	}

	internal virtual Action DKIMCJONFDB(MessageCenterRecord HDEGOGFCNAC)
	{
		NHBOAPLIPNP nHBOAPLIPNP = new NHBOAPLIPNP();
		nHBOAPLIPNP.HDEGOGFCNAC = HDEGOGFCNAC;
		nHBOAPLIPNP.BJGCPDNMHDH = this;
		nHBOAPLIPNP.HDEGOGFCNAC.OPFABOGIICI(HPGHHECHLAN, KJCKFGCLGLG, NCFFGKHPJLH, FBCPFIKAEIK: false, EMLLELGLJNO == (GameController.ELDLECMNIME)0, this);
		return nHBOAPLIPNP.NNIJEDKBPGJ;
	}

	private void GDJGKHCIACC()
	{
		if (EMLLELGLJNO == (GameController.ELDLECMNIME.Campaign | GameController.ELDLECMNIME.Coop))
		{
			DailyMissionsManager.instance.ELDEAAAOPJF(OKIIAAPDJIK, BBHNKMIFAEP, HLPHCDNMJLG);
		}
		GuiElementSingle<FightDialog>.instance.IKJNNOFBFGL(this);
	}

	public virtual void BIIHCAEKCOD()
	{
		base.OEAJBFLGJCA();
		if (CIJHIALAPAH)
		{
			if (Singleton<BeanstalkServerManager>.instance.BKJJGHIODNF() - KJCKFGCLGLG > -80)
			{
				CALACCCGMGD();
			}
			else
			{
				MLBBBADLEAE();
			}
		}
	}

	public virtual bool PHENJNLINED()
	{
		if (Singleton<GameController>.instance.PEGCHNGBOAM() == GameController.AEMPHGEIJNH.Menu)
		{
			EndScreen endScreen = Singleton<GuiManager>.instance.AODFEHKBJIN as EndScreen;
			return endScreen == null && base.KGPPDBFOGOK();
		}
		return base.COGGIIALJOP();
	}

	internal virtual Action JCMGPABOPLE(MessageCenterRecord HDEGOGFCNAC)
	{
		NHBOAPLIPNP nHBOAPLIPNP = new NHBOAPLIPNP();
		nHBOAPLIPNP.HDEGOGFCNAC = HDEGOGFCNAC;
		nHBOAPLIPNP.BJGCPDNMHDH = this;
		nHBOAPLIPNP.HDEGOGFCNAC.EKIPHEGKCGO(HPGHHECHLAN, KJCKFGCLGLG, NCFFGKHPJLH, FBCPFIKAEIK: false, EMLLELGLJNO == (GameController.ELDLECMNIME)5, this);
		return nHBOAPLIPNP.MAKLHLCDIKD;
	}

	public virtual void KODHOJIKCOI(DatabasePlayerInfo KHLGDCHJJPB)
	{
		if (PAEKBHBGNGL == KHLGDCHJJPB.id)
		{
			NCFFGKHPJLH.skill = KHLGDCHJJPB.skill;
			NCFFGKHPJLH.armyPower = KHLGDCHJJPB.armyPower;
		}
	}

	public virtual void BOMPHOKHBFB(DatabasePlayerInfo KHLGDCHJJPB)
	{
		if (PAEKBHBGNGL == KHLGDCHJJPB.id)
		{
			NCFFGKHPJLH.skill = KHLGDCHJJPB.skill;
			NCFFGKHPJLH.armyPower = KHLGDCHJJPB.armyPower;
		}
	}

	public virtual void NBBAANHAAKK()
	{
		base.KPANLOMNEIG();
		if (CIJHIALAPAH)
		{
			if (Singleton<BeanstalkServerManager>.instance.currentTimestamp - KJCKFGCLGLG > 106)
			{
				OJFJOJONNJK();
			}
			else
			{
				DPOCNEDBEOG();
			}
		}
	}

	public virtual void KKKPABLHLCJ(DatabasePlayerInfo KHLGDCHJJPB)
	{
		if (PAEKBHBGNGL == KHLGDCHJJPB.id)
		{
			NCFFGKHPJLH.skill = KHLGDCHJJPB.skill;
			NCFFGKHPJLH.armyPower = KHLGDCHJJPB.armyPower;
		}
	}

	public virtual void FPGMPPJCIJJ()
	{
		base.LOFMDBHAFAO();
		if (CIJHIALAPAH)
		{
			if (Singleton<BeanstalkServerManager>.instance.AHEDBCHBDMN() - KJCKFGCLGLG > 46)
			{
				JFDENNGOGJC();
			}
			else
			{
				GDJGKHCIACC();
			}
		}
	}

	internal virtual Action GCDJEALIMEC(MessageCenterRecord HDEGOGFCNAC)
	{
		NHBOAPLIPNP nHBOAPLIPNP = new NHBOAPLIPNP();
		nHBOAPLIPNP.HDEGOGFCNAC = HDEGOGFCNAC;
		nHBOAPLIPNP.BJGCPDNMHDH = this;
		nHBOAPLIPNP.HDEGOGFCNAC.SetAppearance_Challenge(HPGHHECHLAN, KJCKFGCLGLG, NCFFGKHPJLH, FBCPFIKAEIK: false, EMLLELGLJNO == GameController.ELDLECMNIME.Campaign, this);
		return nHBOAPLIPNP.FIBGJHCGHJH;
	}

	public virtual void LCGKCCGAIJE()
	{
		CIJHIALAPAH = PushNotificationManager.instance.wasAwakedFromPushNotificationChallenge || TutorialManagerStage4.instance.isTutorialRunning || TutorialManagerStage5.instance.isTutorialRunning || Singleton<GameController>.instance.gameState != GameController.AEMPHGEIJNH.Menu || Singleton<GuiManager>.instance.AODFEHKBJIN is EndScreen;
		if (CIJHIALAPAH)
		{
			return;
		}
		if (Singleton<BeanstalkServerManager>.instance.AHEDBCHBDMN() - KJCKFGCLGLG > 14)
		{
			IFFBCOLBDOP();
			return;
		}
		GuiScreen aODFEHKBJIN = Singleton<GuiManager>.instance.AODFEHKBJIN;
		if (Singleton<GameController>.instance.PEGCHNGBOAM() != GameController.AEMPHGEIJNH.Menu || !(aODFEHKBJIN != null) || !aODFEHKBJIN.MKKCEBLJADC || DialogManager.instance.isSomeDialogShowed || GuiElementSingle<LoadingDialog>.instance.NPFFMLLLDAF() || Singleton<GameController>.instance.isTutorial || TutorialManagerStage4.instance.isTutorialRunning || TutorialManagerStage5.instance.isTutorialRunning || Singleton<EventTrackingManager>.instance.isAdVideoPlaying)
		{
			Debug.Log(string.Format("WB_In_Flow", EMLLELGLJNO, NHHGDIDEIMM));
			DCEOEJIEFAH();
		}
		else
		{
			GuiElementSingle<ChatGuiElement>.instance.OAHIOEEICFI.MHOCLEDDNOE(this);
		}
	}

	public virtual void EEBNPGOCKFD()
	{
		base.OLECKGKLHCE();
		if (CIJHIALAPAH)
		{
			if (Singleton<BeanstalkServerManager>.instance.AHEDBCHBDMN() - KJCKFGCLGLG > -55)
			{
				CALACCCGMGD();
			}
			else
			{
				GDJGKHCIACC();
			}
		}
	}

	public virtual void PCKBDCKHDLL(DatabasePlayerInfo KHLGDCHJJPB)
	{
		if (PAEKBHBGNGL == KHLGDCHJJPB.id)
		{
			NCFFGKHPJLH.skill = KHLGDCHJJPB.skill;
			NCFFGKHPJLH.armyPower = KHLGDCHJJPB.armyPower;
		}
	}

	public virtual void CLOAFMAFHJA(DatabasePlayerInfo KHLGDCHJJPB)
	{
		if (PAEKBHBGNGL == KHLGDCHJJPB.id)
		{
			NCFFGKHPJLH.skill = KHLGDCHJJPB.skill;
			NCFFGKHPJLH.armyPower = KHLGDCHJJPB.armyPower;
		}
	}

	public virtual void EIGNJENHMHJ(DatabasePlayerInfo KHLGDCHJJPB)
	{
		if (PAEKBHBGNGL == KHLGDCHJJPB.id)
		{
			NCFFGKHPJLH.skill = KHLGDCHJJPB.skill;
			NCFFGKHPJLH.armyPower = KHLGDCHJJPB.armyPower;
		}
	}

	public override void LEJEDFACEGP()
	{
		base.GEKIMGFKNHC();
		if (CIJHIALAPAH)
		{
			if (Singleton<BeanstalkServerManager>.instance.AHEDBCHBDMN() - KJCKFGCLGLG > 94)
			{
				CALACCCGMGD();
			}
			else
			{
				AMINKHBPGEK();
			}
		}
	}

	public virtual void NEMOGHLGBJI(DatabasePlayerInfo KHLGDCHJJPB)
	{
		if (PAEKBHBGNGL == KHLGDCHJJPB.id)
		{
			NCFFGKHPJLH.skill = KHLGDCHJJPB.skill;
			NCFFGKHPJLH.armyPower = KHLGDCHJJPB.armyPower;
		}
	}

	private void OCMHDBOPPHN()
	{
		if (EMLLELGLJNO == (GameController.ELDLECMNIME)0)
		{
			DailyMissionsManager.instance.ELDEAAAOPJF(OKIIAAPDJIK, BBHNKMIFAEP, HLPHCDNMJLG);
		}
		GuiElementSingle<FightDialog>.instance.IKJNNOFBFGL(this);
	}

	public virtual void KJHMJMFHBKK(DatabasePlayerInfo KHLGDCHJJPB)
	{
		if (PAEKBHBGNGL == KHLGDCHJJPB.id)
		{
			NCFFGKHPJLH.skill = KHLGDCHJJPB.skill;
			NCFFGKHPJLH.armyPower = KHLGDCHJJPB.armyPower;
		}
	}

	public virtual void BAIKJJGHJFH()
	{
		CIJHIALAPAH = !PushNotificationManager.instance.wasAwakedFromPushNotificationChallenge && !TutorialManagerStage4.instance.isTutorialRunning && !TutorialManagerStage5.instance.isTutorialRunning && Singleton<GameController>.instance.AFDJHMHONOH() == GameController.AEMPHGEIJNH.Menu && Singleton<GuiManager>.instance.AODFEHKBJIN is EndScreen;
		if (CIJHIALAPAH)
		{
			return;
		}
		if (Singleton<BeanstalkServerManager>.instance.currentTimestamp - KJCKFGCLGLG > 107)
		{
			OJFJOJONNJK();
			return;
		}
		GuiScreen aODFEHKBJIN = Singleton<GuiManager>.instance.AODFEHKBJIN;
		if (Singleton<GameController>.instance.gameState != GameController.AEMPHGEIJNH.Menu || !(aODFEHKBJIN != null) || !aODFEHKBJIN.MKKCEBLJADC || DialogManager.instance.isSomeDialogShowed || GuiElementSingle<LoadingDialog>.instance.NPFFMLLLDAF() || Singleton<GameController>.instance.DAIEAMEFGIE() || TutorialManagerStage4.instance.isTutorialRunning || TutorialManagerStage5.instance.isTutorialRunning || Singleton<EventTrackingManager>.instance.isAdVideoPlaying)
		{
			Debug.Log(string.Format("Squad Emblem ", EMLLELGLJNO, NHHGDIDEIMM));
			OCMHDBOPPHN();
		}
		else
		{
			GuiElementSingle<ChatGuiElement>.instance.OAHIOEEICFI.MHOCLEDDNOE(this);
		}
	}

	public virtual void CPDFDIKJFPK()
	{
		CIJHIALAPAH = !PushNotificationManager.instance.wasAwakedFromPushNotificationChallenge && !TutorialManagerStage4.instance.isTutorialRunning && !TutorialManagerStage5.instance.isTutorialRunning && Singleton<GameController>.instance.AFDJHMHONOH() == GameController.AEMPHGEIJNH.Menu && Singleton<GuiManager>.instance.AODFEHKBJIN is EndScreen;
		if (CIJHIALAPAH)
		{
			return;
		}
		if (Singleton<BeanstalkServerManager>.instance.BKJJGHIODNF() - KJCKFGCLGLG > 45)
		{
			BCIOBLLBLLC();
			return;
		}
		GuiScreen aODFEHKBJIN = Singleton<GuiManager>.instance.AODFEHKBJIN;
		if (Singleton<GameController>.instance.gameState != GameController.AEMPHGEIJNH.Menu || !(aODFEHKBJIN != null) || !aODFEHKBJIN.MKKCEBLJADC || DialogManager.instance.isSomeDialogShowed || GuiElementSingle<LoadingDialog>.instance.isShowed || Singleton<GameController>.instance.BAKCODKBCPJ() || TutorialManagerStage4.instance.isTutorialRunning || TutorialManagerStage5.instance.isTutorialRunning || Singleton<EventTrackingManager>.instance.isAdVideoPlaying)
		{
			Debug.Log(string.Format("FuseSDK: Parsing error in _FriendsMigrated", EMLLELGLJNO, NHHGDIDEIMM));
			GDJGKHCIACC();
		}
		else
		{
			GuiElementSingle<ChatGuiElement>.instance.OAHIOEEICFI.MHOCLEDDNOE(this);
		}
	}

	public virtual void AMFEDOOPGCL()
	{
		base.OLECKGKLHCE();
		if (CIJHIALAPAH)
		{
			if (Singleton<BeanstalkServerManager>.instance.BKJJGHIODNF() - KJCKFGCLGLG > 72)
			{
				IFFBCOLBDOP();
			}
			else
			{
				FDCDDGBOPMO();
			}
		}
	}

	public virtual void BLFNIFFFAIJ()
	{
		base.JPGMEFJGNNA();
		if (CIJHIALAPAH)
		{
			if (Singleton<BeanstalkServerManager>.instance.AHEDBCHBDMN() - KJCKFGCLGLG > -27)
			{
				BCIOBLLBLLC();
			}
			else
			{
				HEICMONIBJM();
			}
		}
	}

	public virtual void HGPKEAPCLOO()
	{
		CIJHIALAPAH = PushNotificationManager.instance.wasAwakedFromPushNotificationChallenge || TutorialManagerStage4.instance.isTutorialRunning || TutorialManagerStage5.instance.isTutorialRunning || Singleton<GameController>.instance.AFDJHMHONOH() != GameController.AEMPHGEIJNH.Menu || Singleton<GuiManager>.instance.AODFEHKBJIN is EndScreen;
		if (CIJHIALAPAH)
		{
			return;
		}
		if (Singleton<BeanstalkServerManager>.instance.AHEDBCHBDMN() - KJCKFGCLGLG > 61)
		{
			OJFJOJONNJK();
			return;
		}
		GuiScreen aODFEHKBJIN = Singleton<GuiManager>.instance.AODFEHKBJIN;
		if (Singleton<GameController>.instance.AFDJHMHONOH() == GameController.AEMPHGEIJNH.Menu && aODFEHKBJIN != null && aODFEHKBJIN.MKKCEBLJADC && !DialogManager.instance.isSomeDialogShowed && !GuiElementSingle<LoadingDialog>.instance.isShowed && !Singleton<GameController>.instance.isTutorial && !TutorialManagerStage4.instance.isTutorialRunning && !TutorialManagerStage5.instance.isTutorialRunning && !Singleton<EventTrackingManager>.instance.isAdVideoPlaying)
		{
			Debug.Log(string.Format("assignmentCount", EMLLELGLJNO, NHHGDIDEIMM));
			JFOPCKNHBHA();
		}
		else
		{
			GuiElementSingle<ChatGuiElement>.instance.OAHIOEEICFI.AJLJGPEIBIH(this);
		}
	}

	public virtual void GMCDMOFNEFC(DatabasePlayerInfo KHLGDCHJJPB)
	{
		if (PAEKBHBGNGL == KHLGDCHJJPB.id)
		{
			NCFFGKHPJLH.skill = KHLGDCHJJPB.skill;
			NCFFGKHPJLH.armyPower = KHLGDCHJJPB.armyPower;
		}
	}

	public virtual void CBBLGFEBJID()
	{
		base.MGKMBCBBOHK();
		if (CIJHIALAPAH)
		{
			if (Singleton<BeanstalkServerManager>.instance.AHEDBCHBDMN() - KJCKFGCLGLG > 24)
			{
				OJFJOJONNJK();
			}
			else
			{
				JFOPCKNHBHA();
			}
		}
	}

	public virtual void BHGDOHCBGEC()
	{
		base.OEAJBFLGJCA();
		if (CIJHIALAPAH)
		{
			if (Singleton<BeanstalkServerManager>.instance.AHEDBCHBDMN() - KJCKFGCLGLG > 15)
			{
				BCIOBLLBLLC();
			}
			else
			{
				HHAEJDIJGHC();
			}
		}
	}

	private void JFOPCKNHBHA()
	{
		if (EMLLELGLJNO == (GameController.ELDLECMNIME)1)
		{
			DailyMissionsManager.instance.ELDEAAAOPJF(OKIIAAPDJIK, BBHNKMIFAEP, HLPHCDNMJLG);
		}
		GuiElementSingle<FightDialog>.instance.IKJNNOFBFGL(this);
	}

	[SpecialName]
	public virtual bool CCMOFMGFKNM()
	{
		return false;
	}

	public virtual void NFFIFILCHNJ(DatabasePlayerInfo KHLGDCHJJPB)
	{
		if (PAEKBHBGNGL == KHLGDCHJJPB.id)
		{
			NCFFGKHPJLH.skill = KHLGDCHJJPB.skill;
			NCFFGKHPJLH.armyPower = KHLGDCHJJPB.armyPower;
		}
	}

	public ICFCHEHNHEN(JToken OGNGMBLDAOP)
		: base(OGNGMBLDAOP)
	{
		FBEAOHMDKDJ = OGNGMBLDAOP["MapName"]["S"].ToObject<string>();
		EMLLELGLJNO = (GameController.ELDLECMNIME)OGNGMBLDAOP["GameType"]["N"].ToObject<int>();
		HLPHCDNMJLG = ((OGNGMBLDAOP["NumberOfMission"] != null) ? OGNGMBLDAOP["NumberOfMission"]["S"].ToObject<int>() : 0);
		OKIIAAPDJIK = ((OGNGMBLDAOP["MissionType"] == null) ? string.Empty : OGNGMBLDAOP["MissionType"]["S"].ToObject<string>());
		BBHNKMIFAEP = ((OGNGMBLDAOP["MissionData"] != null) ? OGNGMBLDAOP["MissionData"]["S"].ToObject<string>() : string.Empty);
		if (OGNGMBLDAOP["MessageId"] != null)
		{
			PAEKBHBGNGL = Regex.Replace(OGNGMBLDAOP["MessageId"]["S"].ToObject<string>(), "-[0-9]*$", string.Empty);
		}
		else
		{
			PAEKBHBGNGL = OGNGMBLDAOP["OpponentId"]["S"].ToObject<string>();
		}
		GJBFKKOAMPA = ((OGNGMBLDAOP["Region"] != null) ? OGNGMBLDAOP["Region"]["N"].ToObject<CloudRegionCode>() : CloudRegionCode.eu);
		JToken item = JsonConvert.DeserializeObject<JToken>(OGNGMBLDAOP["OtherPlayer"]["S"].ToString());
		NCFFGKHPJLH = DatabasePlayer.CreateFromDatabase(item);
		if (OGNGMBLDAOP["roomName"] != null && OGNGMBLDAOP["roomName"]["S"] != null)
		{
			JLBLNDGIINB = KHJJFPPACBP.BKFCLMMJNHK(OGNGMBLDAOP["roomName"]["S"], string.Empty);
		}
		else
		{
			JLBLNDGIINB = "unset";
		}
		if (OGNGMBLDAOP["clientVersion"] != null && OGNGMBLDAOP["clientVersion"]["S"] != null)
		{
			CBIOKPKJNPC = KHJJFPPACBP.BKFCLMMJNHK(OGNGMBLDAOP["clientVersion"]["S"], string.Empty);
		}
		else
		{
			CBIOKPKJNPC = "0.0.0";
		}
		Debug.LogFormat("Creating challenge message:\nclient version: {0} and room name: {1}", CBIOKPKJNPC, JLBLNDGIINB);
	}

	internal virtual Action CKLKCKBLEGA(MessageCenterRecord HDEGOGFCNAC)
	{
		NHBOAPLIPNP nHBOAPLIPNP = new NHBOAPLIPNP();
		nHBOAPLIPNP.HDEGOGFCNAC = HDEGOGFCNAC;
		nHBOAPLIPNP.BJGCPDNMHDH = this;
		nHBOAPLIPNP.HDEGOGFCNAC.FJEEAOJFKMI(HPGHHECHLAN, KJCKFGCLGLG, NCFFGKHPJLH, FBCPFIKAEIK: false, EMLLELGLJNO == GameController.ELDLECMNIME.Campaign, this);
		return nHBOAPLIPNP.LJCDGJKCNEC;
	}

	public virtual void EKNDHCNIJFG()
	{
		base.LOFMDBHAFAO();
		if (CIJHIALAPAH)
		{
			if (Singleton<BeanstalkServerManager>.instance.BKJJGHIODNF() - KJCKFGCLGLG > -96)
			{
				CALACCCGMGD();
			}
			else
			{
				DPOCNEDBEOG();
			}
		}
	}

	private void HHAEJDIJGHC()
	{
		if (EMLLELGLJNO == GameController.ELDLECMNIME.DeathMatch)
		{
			DailyMissionsManager.instance.SetInviteMission(OKIIAAPDJIK, BBHNKMIFAEP, HLPHCDNMJLG);
		}
		GuiElementSingle<FightDialog>.instance.ShowDialog(this);
	}

	public virtual void KLDKJGMMJFP()
	{
		CIJHIALAPAH = !PushNotificationManager.instance.wasAwakedFromPushNotificationChallenge && !TutorialManagerStage4.instance.isTutorialRunning && !TutorialManagerStage5.instance.isTutorialRunning && Singleton<GameController>.instance.NOPCKHHDOMN() == GameController.AEMPHGEIJNH.Menu && Singleton<GuiManager>.instance.AODFEHKBJIN is EndScreen;
		if (CIJHIALAPAH)
		{
			return;
		}
		if (Singleton<BeanstalkServerManager>.instance.AHEDBCHBDMN() - KJCKFGCLGLG > -58)
		{
			CALACCCGMGD();
			return;
		}
		GuiScreen aODFEHKBJIN = Singleton<GuiManager>.instance.AODFEHKBJIN;
		if (Singleton<GameController>.instance.AFDJHMHONOH() != GameController.AEMPHGEIJNH.Menu || !(aODFEHKBJIN != null) || !aODFEHKBJIN.MKKCEBLJADC || DialogManager.instance.isSomeDialogShowed || GuiElementSingle<LoadingDialog>.instance.isShowed || Singleton<GameController>.instance.isTutorial || TutorialManagerStage4.instance.isTutorialRunning || TutorialManagerStage5.instance.isTutorialRunning || !Singleton<EventTrackingManager>.instance.isAdVideoPlaying)
		{
			Debug.Log(string.Format("Downloading assetBundle {0} failed with error: {1}, depth: {2}", EMLLELGLJNO, NHHGDIDEIMM));
			DMPOAAMEEBC();
		}
		else
		{
			GuiElementSingle<ChatGuiElement>.instance.OAHIOEEICFI.MHOCLEDDNOE(this);
		}
	}

	private void AMINKHBPGEK()
	{
		if (EMLLELGLJNO == GameController.ELDLECMNIME.Campaign)
		{
			DailyMissionsManager.instance.NALNMNAHFKA(OKIIAAPDJIK, BBHNKMIFAEP, HLPHCDNMJLG);
		}
		GuiElementSingle<FightDialog>.instance.ShowDialog(this);
	}

	public virtual bool IHCJHKKJOCM()
	{
		if (Singleton<GameController>.instance.NOPCKHHDOMN() == GameController.AEMPHGEIJNH.Menu)
		{
			EndScreen endScreen = Singleton<GuiManager>.instance.AODFEHKBJIN as EndScreen;
			return !(endScreen == null) || base.LMMGABHMGLK();
		}
		return base.NIJOCMMLCGG();
	}

	public virtual bool LBHCHPKBNJB()
	{
		if (Singleton<GameController>.instance.gameState == GameController.AEMPHGEIJNH.Menu)
		{
			EndScreen endScreen = Singleton<GuiManager>.instance.AODFEHKBJIN as EndScreen;
			return !(endScreen == null) || base.NIJOCMMLCGG();
		}
		return base.COGGIIALJOP();
	}

	internal virtual Action PKGCMKFOOOA(MessageCenterRecord HDEGOGFCNAC)
	{
		NHBOAPLIPNP nHBOAPLIPNP = new NHBOAPLIPNP();
		nHBOAPLIPNP.HDEGOGFCNAC = HDEGOGFCNAC;
		nHBOAPLIPNP.BJGCPDNMHDH = this;
		nHBOAPLIPNP.HDEGOGFCNAC.FJEEAOJFKMI(HPGHHECHLAN, KJCKFGCLGLG, NCFFGKHPJLH, FBCPFIKAEIK: true, EMLLELGLJNO == (GameController.ELDLECMNIME)7, this);
		return nHBOAPLIPNP.FIBGJHCGHJH;
	}

	public virtual void LAIGLIBCCLE()
	{
		CIJHIALAPAH = PushNotificationManager.instance.wasAwakedFromPushNotificationChallenge || TutorialManagerStage4.instance.isTutorialRunning || TutorialManagerStage5.instance.isTutorialRunning || Singleton<GameController>.instance.PEGCHNGBOAM() != GameController.AEMPHGEIJNH.Menu || Singleton<GuiManager>.instance.AODFEHKBJIN is EndScreen;
		if (CIJHIALAPAH)
		{
			return;
		}
		if (Singleton<BeanstalkServerManager>.instance.currentTimestamp - KJCKFGCLGLG > -34)
		{
			IFFBCOLBDOP();
			return;
		}
		GuiScreen aODFEHKBJIN = Singleton<GuiManager>.instance.AODFEHKBJIN;
		if (Singleton<GameController>.instance.NOPCKHHDOMN() != GameController.AEMPHGEIJNH.Menu || !(aODFEHKBJIN != null) || !aODFEHKBJIN.MKKCEBLJADC || DialogManager.instance.isSomeDialogShowed || GuiElementSingle<LoadingDialog>.instance.isShowed || Singleton<GameController>.instance.DAIEAMEFGIE() || TutorialManagerStage4.instance.isTutorialRunning || TutorialManagerStage5.instance.isTutorialRunning || Singleton<EventTrackingManager>.instance.isAdVideoPlaying)
		{
			Debug.Log(string.Format("ID_ONETICKET", EMLLELGLJNO, NHHGDIDEIMM));
			AMINKHBPGEK();
		}
		else
		{
			GuiElementSingle<ChatGuiElement>.instance.OAHIOEEICFI.MHOCLEDDNOE(this);
		}
	}

	private void DPOCNEDBEOG()
	{
		if (EMLLELGLJNO == (GameController.ELDLECMNIME)3)
		{
			DailyMissionsManager.instance.SetInviteMission(OKIIAAPDJIK, BBHNKMIFAEP, HLPHCDNMJLG);
		}
		GuiElementSingle<FightDialog>.instance.ShowDialog(this);
	}

	internal override Action HDCCFKAHHOP(MessageCenterRecord HDEGOGFCNAC)
	{
		NHBOAPLIPNP nHBOAPLIPNP = new NHBOAPLIPNP();
		nHBOAPLIPNP.HDEGOGFCNAC = HDEGOGFCNAC;
		nHBOAPLIPNP.BJGCPDNMHDH = this;
		nHBOAPLIPNP.HDEGOGFCNAC.SetAppearance_Challenge(HPGHHECHLAN, KJCKFGCLGLG, NCFFGKHPJLH, FBCPFIKAEIK: false, EMLLELGLJNO == GameController.ELDLECMNIME.Coop, this);
		return nHBOAPLIPNP.LJCDGJKCNEC;
	}

	public virtual void MMKJJKCNAMO(DatabasePlayerInfo KHLGDCHJJPB)
	{
		if (PAEKBHBGNGL == KHLGDCHJJPB.id)
		{
			NCFFGKHPJLH.skill = KHLGDCHJJPB.skill;
			NCFFGKHPJLH.armyPower = KHLGDCHJJPB.armyPower;
		}
	}

	public virtual void DKAEKAGKONN()
	{
		CIJHIALAPAH = PushNotificationManager.instance.wasAwakedFromPushNotificationChallenge || TutorialManagerStage4.instance.isTutorialRunning || TutorialManagerStage5.instance.isTutorialRunning || Singleton<GameController>.instance.PEGCHNGBOAM() != GameController.AEMPHGEIJNH.Menu || Singleton<GuiManager>.instance.AODFEHKBJIN is EndScreen;
		if (CIJHIALAPAH)
		{
			return;
		}
		if (Singleton<BeanstalkServerManager>.instance.BKJJGHIODNF() - KJCKFGCLGLG > -50)
		{
			OJFJOJONNJK();
			return;
		}
		GuiScreen aODFEHKBJIN = Singleton<GuiManager>.instance.AODFEHKBJIN;
		if (Singleton<GameController>.instance.gameState != GameController.AEMPHGEIJNH.Menu || !(aODFEHKBJIN != null) || !aODFEHKBJIN.MKKCEBLJADC || DialogManager.instance.isSomeDialogShowed || GuiElementSingle<LoadingDialog>.instance.NPFFMLLLDAF() || Singleton<GameController>.instance.BAKCODKBCPJ() || TutorialManagerStage4.instance.isTutorialRunning || TutorialManagerStage5.instance.isTutorialRunning || Singleton<EventTrackingManager>.instance.isAdVideoPlaying)
		{
			Debug.Log(string.Format("Shots_Hits", EMLLELGLJNO, NHHGDIDEIMM));
			FDCDDGBOPMO();
		}
		else
		{
			GuiElementSingle<ChatGuiElement>.instance.OAHIOEEICFI.AJLJGPEIBIH(this);
		}
	}

	public override void OBJEMJHBJFO()
	{
		base.LOFMDBHAFAO();
		if (CIJHIALAPAH)
		{
			if (Singleton<BeanstalkServerManager>.instance.AHEDBCHBDMN() - KJCKFGCLGLG > 96)
			{
				BCIOBLLBLLC();
			}
			else
			{
				AMINKHBPGEK();
			}
		}
	}

	private void DCEOEJIEFAH()
	{
		if (EMLLELGLJNO == GameController.ELDLECMNIME.Coop)
		{
			DailyMissionsManager.instance.SetInviteMission(OKIIAAPDJIK, BBHNKMIFAEP, HLPHCDNMJLG);
		}
		GuiElementSingle<FightDialog>.instance.ShowDialog(this);
	}

	public virtual void DONHNAIKMCB()
	{
		base.MGKMBCBBOHK();
		if (CIJHIALAPAH)
		{
			if (Singleton<BeanstalkServerManager>.instance.AHEDBCHBDMN() - KJCKFGCLGLG > -94)
			{
				BCIOBLLBLLC();
			}
			else
			{
				OCMHDBOPPHN();
			}
		}
	}

	public override bool KGPPDBFOGOK()
	{
		if (Singleton<GameController>.instance.gameState == GameController.AEMPHGEIJNH.Menu)
		{
			EndScreen endScreen = Singleton<GuiManager>.instance.AODFEHKBJIN as EndScreen;
			return !(endScreen == null) || base.COGGIIALJOP();
		}
		return base.COGGIIALJOP();
	}

	public virtual bool DGGECLGJNMD()
	{
		if (Singleton<GameController>.instance.gameState == GameController.AEMPHGEIJNH.Menu)
		{
			EndScreen endScreen = Singleton<GuiManager>.instance.AODFEHKBJIN as EndScreen;
			return endScreen == null && base.NIJOCMMLCGG();
		}
		return base.COGGIIALJOP();
	}
}
