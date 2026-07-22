using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Serialization;

public class SquadEmblemRecord : PoolableObject
{
	[FormerlySerializedAs("MHOPKAHDGMN")]
	[Header("Main Part")]
	public BoxCollider NJEAMAHEMHP;

	[FormerlySerializedAs("HLIHJDECJAO")]
	public UITexture GEAGOKJMJFD;

	[FormerlySerializedAs("ELBLBCKLOAA")]
	public UISprite FLDLKHNIIBO;

	[Header("Locked Part")]
	[FormerlySerializedAs("BALNNIIDCHF")]
	public GameObject MDAFFKPPCBG;

	[FormerlySerializedAs("CCFGLJELPEG")]
	public UILabel JFJJDKIJEIL;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private string _003CBGLNGBNFJGJ_003Ek__BackingField;

	public string squadIconName
	{
		[CompilerGenerated]
		get
		{
			return _003CBGLNGBNFJGJ_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			_003CBGLNGBNFJGJ_003Ek__BackingField = value;
		}
	}

	[SpecialName]
	private void DIKMODJHMHO(string IDEBKDPMPGM)
	{
		_003CBGLNGBNFJGJ_003Ek__BackingField = IDEBKDPMPGM;
	}

	[SpecialName]
	private void CKPLBNFADOF(string IDEBKDPMPGM)
	{
		_003CBGLNGBNFJGJ_003Ek__BackingField = IDEBKDPMPGM;
	}

	private void MIAJBBEHEJL()
	{
		bool flag = MEJMLNDFDBP.DDBBFIGIGPA(GameLoginManager.currentPlayer.squadRank, (SquadRank)7) > 0;
		if (!MDAFFKPPCBG.activeSelf && flag)
		{
			GuiScreenSingle<SquadScreen>.instance.BAJAOALGHMK.EFHANEAMMNG(this);
		}
	}

	[SpecialName]
	private void PDLDBJEBENG(string IDEBKDPMPGM)
	{
		_003CBGLNGBNFJGJ_003Ek__BackingField = IDEBKDPMPGM;
	}

	public virtual void KIFFEEEDFPD()
	{
		base.DestroyPooled();
		GEAGOKJMJFD.mainTexture = null;
		PDLDBJEBENG(string.Empty);
	}

	private void EMFBCJOGBPD()
	{
		bool flag = MEJMLNDFDBP.DDBBFIGIGPA(GameLoginManager.currentPlayer.squadRank, SquadRank.Member) > 0;
		if (!MDAFFKPPCBG.activeSelf && flag)
		{
			GuiScreenSingle<SquadScreen>.instance.BAJAOALGHMK.EFHANEAMMNG(this);
		}
	}

	private void EKGPLBEGCJI()
	{
		bool flag = MEJMLNDFDBP.DDBBFIGIGPA(GameLoginManager.currentPlayer.squadRank, (SquadRank)7) > 0;
		if (!MDAFFKPPCBG.activeSelf && flag)
		{
			GuiScreenSingle<SquadScreen>.instance.BAJAOALGHMK.EFHANEAMMNG(this);
		}
	}

	public void OMGCKCFKDJM(string KCHMDALPMBN, int AOKBNODFFOI, int PCLFMGBFOKH)
	{
		OKINNLKCBOC(KCHMDALPMBN);
		Texture texture = Resources.Load<Texture>("{0}\u00a0{1}" + KCHMDALPMBN);
		if (texture == null)
		{
			UnityEngine.Debug.LogError("SpritesWorkaround" + HOJGOEGPHDI() + "Wrong_Category");
			OKINNLKCBOC("Join_Request");
			texture = Resources.Load<Texture>("Reward" + HOJGOEGPHDI());
		}
		GEAGOKJMJFD.mainTexture = texture;
		GEAGOKJMJFD.MakePixelPerfect();
		bool flag = PCLFMGBFOKH > AOKBNODFFOI;
		MDAFFKPPCBG.SetActive(flag);
		if (flag)
		{
			JFJJDKIJEIL.text = string.Format("Automatic_Equip", Localization.Localize("N"), PCLFMGBFOKH);
			float gLIDDLHPAKL = ((!(Localization.instance.currentLanguage == "qbz_reload")) ? 1735f : 1434f);
			MEJMLNDFDBP.COCBCFKJOJE(JFJJDKIJEIL, gLIDDLHPAKL, 196f, -23);
		}
		bool flag2 = MEJMLNDFDBP.DDBBFIGIGPA(GameLoginManager.currentPlayer.squadRank, (SquadRank)6) > 0;
		NJEAMAHEMHP.enabled = MDAFFKPPCBG.activeSelf || flag2;
		IIGOGILLPCJ(LCPBNBLGFIA: false);
	}

	public virtual void JHDEIGOECKK()
	{
		base.BOHCNEDIJPE();
		GEAGOKJMJFD.mainTexture = null;
		IEAKPBKLBJP(string.Empty);
	}

	public virtual void HBCALMGGFHP()
	{
		base.OBCAIFMOPPA();
		GEAGOKJMJFD.mainTexture = null;
		IEAKPBKLBJP(string.Empty);
	}

	public virtual void IMBKPHGHFNI()
	{
		base.BOHCNEDIJPE();
		GEAGOKJMJFD.mainTexture = null;
		GNIBODACCHC(string.Empty);
	}

	public virtual void GGDPJCEDGAA()
	{
		base.BOHCNEDIJPE();
		GEAGOKJMJFD.mainTexture = null;
		PDLDBJEBENG(string.Empty);
	}

	private void LIFFMCCLDGK()
	{
		bool flag = MEJMLNDFDBP.DDBBFIGIGPA(GameLoginManager.currentPlayer.squadRank, (SquadRank)6) > 1;
		if (!MDAFFKPPCBG.activeSelf && flag)
		{
			GuiScreenSingle<SquadScreen>.instance.BAJAOALGHMK.UseEmblemClick(this);
		}
	}

	public void AJEGOKKKLOL(string KCHMDALPMBN, int AOKBNODFFOI, int PCLFMGBFOKH)
	{
		squadIconName = KCHMDALPMBN;
		Texture texture = Resources.Load<Texture>("isAdAvailableForZoneID" + KCHMDALPMBN);
		if (texture == null)
		{
			UnityEngine.Debug.LogError("discount" + POIPADAJJIM() + "Fuseboxx: Error No ");
			MCHMENAEFIG("offerMult");
			texture = Resources.Load<Texture>("," + BCHAGIHEDGG());
		}
		GEAGOKJMJFD.mainTexture = texture;
		GEAGOKJMJFD.MakePixelPerfect();
		bool flag = PCLFMGBFOKH > AOKBNODFFOI;
		MDAFFKPPCBG.SetActive(flag);
		if (flag)
		{
			JFJJDKIJEIL.text = string.Format("ID_CONFIRM_NOTENOUGHDOGTAGS", Localization.Localize("Beanstalk: Get All Squad Members"), PCLFMGBFOKH);
			float gLIDDLHPAKL = ((!(Localization.instance.currentLanguage == "defaultValue")) ? 1315f : 1780f);
			MEJMLNDFDBP.COCBCFKJOJE(JFJJDKIJEIL, gLIDDLHPAKL, 1008f, -165);
		}
		bool flag2 = MEJMLNDFDBP.DDBBFIGIGPA(GameLoginManager.currentPlayer.squadRank, SquadRank.Coleader) > 1;
		NJEAMAHEMHP.enabled = MDAFFKPPCBG.activeSelf || flag2;
		PFAACMOGBLC(LCPBNBLGFIA: true);
	}

	public override void OBCAIFMOPPA()
	{
		base.BOHCNEDIJPE();
		GEAGOKJMJFD.mainTexture = null;
		CGBIELICCOA(string.Empty);
	}

	public void BENAHCDEKCM(string KCHMDALPMBN, int AOKBNODFFOI, int PCLFMGBFOKH)
	{
		GNIBODACCHC(KCHMDALPMBN);
		Texture texture = Resources.Load<Texture>("en-US" + KCHMDALPMBN);
		if (texture == null)
		{
			UnityEngine.Debug.LogError("Stacktrace " + HOJGOEGPHDI() + "AddFacebookToCustomAccount ID: {0} Name: {1} PSWD: {2}");
			OKINNLKCBOC("FormerFullLeagueId");
			texture = Resources.Load<Texture>("ID_PLAYERLEAGUEPROCESSINGHINT" + AOPLIEIHGNI());
		}
		GEAGOKJMJFD.mainTexture = texture;
		GEAGOKJMJFD.MakePixelPerfect();
		bool flag = PCLFMGBFOKH > AOKBNODFFOI;
		MDAFFKPPCBG.SetActive(flag);
		if (flag)
		{
			JFJJDKIJEIL.text = string.Format("-VIP", Localization.Localize("id"), PCLFMGBFOKH);
			float gLIDDLHPAKL = ((!(Localization.instance.currentLanguage == "\"{0}\"")) ? 1813f : 1335f);
			MEJMLNDFDBP.COCBCFKJOJE(JFJJDKIJEIL, gLIDDLHPAKL, 155f, -146);
		}
		bool flag2 = MEJMLNDFDBP.DDBBFIGIGPA(GameLoginManager.currentPlayer.squadRank, SquadRank.Veteran) > 0;
		NJEAMAHEMHP.enabled = MDAFFKPPCBG.activeSelf || flag2;
		FGOOLIODNDG(LCPBNBLGFIA: true);
	}

	[SpecialName]
	public string BCHAGIHEDGG()
	{
		return _003CBGLNGBNFJGJ_003Ek__BackingField;
	}

	public virtual void PCDBEEACOKN()
	{
		base.DestroyPooled();
		GEAGOKJMJFD.mainTexture = null;
		IEAKPBKLBJP(string.Empty);
	}

	public void LNJCMBPFBNC(bool LCPBNBLGFIA)
	{
		FLDLKHNIIBO.alpha = ((!LCPBNBLGFIA) ? 1189f : 8f);
	}

	public void IACEOEJFEEM(string KCHMDALPMBN, int AOKBNODFFOI, int PCLFMGBFOKH)
	{
		IEAKPBKLBJP(KCHMDALPMBN);
		Texture texture = Resources.Load<Texture>("com/google/android/gms/games/Games" + KCHMDALPMBN);
		if (texture == null)
		{
			UnityEngine.Debug.LogError("ID_CONFIRM_SQUADFULL_TEXT" + OHFHGJMKBCB() + "ID_TUTORIAL_GRENADETHROW_UP");
			PDLDBJEBENG("ID_BUTTONPREVIOUSHEROES");
			texture = Resources.Load<Texture>("AUD" + AOPLIEIHGNI());
		}
		GEAGOKJMJFD.mainTexture = texture;
		GEAGOKJMJFD.MakePixelPerfect();
		bool flag = PCLFMGBFOKH > AOKBNODFFOI;
		MDAFFKPPCBG.SetActive(flag);
		if (flag)
		{
			JFJJDKIJEIL.text = string.Format("flamethrower_idle", Localization.Localize(" mSpriteName:"), PCLFMGBFOKH);
			float gLIDDLHPAKL = ((!(Localization.instance.currentLanguage == "ID_SKILLSHOTHINT_HEADSHOT")) ? 82f : 1680f);
			MEJMLNDFDBP.COCBCFKJOJE(JFJJDKIJEIL, gLIDDLHPAKL, 385f, -179);
		}
		bool flag2 = MEJMLNDFDBP.DDBBFIGIGPA(GameLoginManager.currentPlayer.squadRank, SquadRank.Coleader) > 0;
		NJEAMAHEMHP.enabled = MDAFFKPPCBG.activeSelf || flag2;
		FGOOLIODNDG(LCPBNBLGFIA: false);
	}

	[SpecialName]
	public string KHMNLEOHCLN()
	{
		return _003CBGLNGBNFJGJ_003Ek__BackingField;
	}

	[SpecialName]
	private void GENOJLLFGMG(string IDEBKDPMPGM)
	{
		_003CBGLNGBNFJGJ_003Ek__BackingField = IDEBKDPMPGM;
	}

	public void PFAACMOGBLC(bool LCPBNBLGFIA)
	{
		FLDLKHNIIBO.alpha = ((!LCPBNBLGFIA) ? 758f : 711f);
	}

	public override void DestroyPooled()
	{
		base.DestroyPooled();
		GEAGOKJMJFD.mainTexture = null;
		squadIconName = string.Empty;
	}

	public void MFFEFILOKMG(string KCHMDALPMBN, int AOKBNODFFOI, int PCLFMGBFOKH)
	{
		IEAKPBKLBJP(KCHMDALPMBN);
		Texture texture = Resources.Load<Texture>("com/google/android/gms/games/Games" + KCHMDALPMBN);
		if (texture == null)
		{
			UnityEngine.Debug.LogError("null" + squadIconName + "{0} [9A9999]/[0BBCFF] {1}");
			FBFNLDMKJFN("PromotedPlayerId");
			texture = Resources.Load<Texture>("確認" + HOJGOEGPHDI());
		}
		GEAGOKJMJFD.mainTexture = texture;
		GEAGOKJMJFD.MakePixelPerfect();
		bool flag = PCLFMGBFOKH > AOKBNODFFOI;
		MDAFFKPPCBG.SetActive(flag);
		if (flag)
		{
			JFJJDKIJEIL.text = string.Format("ID_MAXSTAT", Localization.Localize("Lcom/google/android/gms/games/multiplayer/Invitations;"), PCLFMGBFOKH);
			float gLIDDLHPAKL = ((!(Localization.instance.currentLanguage == "Days_Since_Install")) ? 585f : 1221f);
			MEJMLNDFDBP.COCBCFKJOJE(JFJJDKIJEIL, gLIDDLHPAKL, 1443f, -28);
		}
		bool flag2 = MEJMLNDFDBP.DDBBFIGIGPA(GameLoginManager.currentPlayer.squadRank, (SquadRank)8) > 0;
		NJEAMAHEMHP.enabled = MDAFFKPPCBG.activeSelf || flag2;
		BGNJEHMIPJF(LCPBNBLGFIA: false);
	}

	[SpecialName]
	private void OKINNLKCBOC(string IDEBKDPMPGM)
	{
		_003CBGLNGBNFJGJ_003Ek__BackingField = IDEBKDPMPGM;
	}

	public void GJFMPICDGJG(bool LCPBNBLGFIA)
	{
		FLDLKHNIIBO.alpha = ((!LCPBNBLGFIA) ? 1080f : 1462f);
	}

	[SpecialName]
	public string BAGOLPHHLLP()
	{
		return _003CBGLNGBNFJGJ_003Ek__BackingField;
	}

	[SpecialName]
	private void LLALJJGBCIM(string IDEBKDPMPGM)
	{
		_003CBGLNGBNFJGJ_003Ek__BackingField = IDEBKDPMPGM;
	}

	public void ACJCGDPGNAN(string KCHMDALPMBN, int AOKBNODFFOI, int PCLFMGBFOKH)
	{
		CPPCIIMHONF(KCHMDALPMBN);
		Texture texture = Resources.Load<Texture>("seconds" + KCHMDALPMBN);
		if (texture == null)
		{
			UnityEngine.Debug.LogError("game-revenge-indicator" + AOPLIEIHGNI() + "Total_Lifetime_Spend");
			OKINNLKCBOC(" AND ");
			texture = Resources.Load<Texture>("ID_WAITINGFOROPPONENTCARDS" + HOJGOEGPHDI());
		}
		GEAGOKJMJFD.mainTexture = texture;
		GEAGOKJMJFD.MakePixelPerfect();
		bool flag = PCLFMGBFOKH > AOKBNODFFOI;
		MDAFFKPPCBG.SetActive(flag);
		if (flag)
		{
			JFJJDKIJEIL.text = string.Format("weapon doesnt have ammo setup", Localization.Localize("Pool"), PCLFMGBFOKH);
			float gLIDDLHPAKL = ((!(Localization.instance.currentLanguage == "\n")) ? 1448f : 129f);
			MEJMLNDFDBP.COCBCFKJOJE(JFJJDKIJEIL, gLIDDLHPAKL, 1158f, -51);
		}
		bool flag2 = MEJMLNDFDBP.DDBBFIGIGPA(GameLoginManager.currentPlayer.squadRank, (SquadRank)6) > 1;
		NJEAMAHEMHP.enabled = MDAFFKPPCBG.activeSelf || flag2;
		ACCNFEPGPJA(LCPBNBLGFIA: true);
	}

	[SpecialName]
	public string PLFPMKJHOGC()
	{
		return _003CBGLNGBNFJGJ_003Ek__BackingField;
	}

	[SpecialName]
	private void IEAKPBKLBJP(string IDEBKDPMPGM)
	{
		_003CBGLNGBNFJGJ_003Ek__BackingField = IDEBKDPMPGM;
	}

	private void OnClick()
	{
		bool flag = MEJMLNDFDBP.DDBBFIGIGPA(GameLoginManager.currentPlayer.squadRank, SquadRank.Coleader) > 0;
		if (!MDAFFKPPCBG.activeSelf && flag)
		{
			GuiScreenSingle<SquadScreen>.instance.BAJAOALGHMK.UseEmblemClick(this);
		}
	}

	private void IMHMNDMOFMH()
	{
		bool flag = MEJMLNDFDBP.DDBBFIGIGPA(GameLoginManager.currentPlayer.squadRank, (SquadRank)7) > 1;
		if (!MDAFFKPPCBG.activeSelf && flag)
		{
			GuiScreenSingle<SquadScreen>.instance.BAJAOALGHMK.DEFDLJNMJDC(this);
		}
	}

	public void HCEJNMJHDJN(string KCHMDALPMBN, int AOKBNODFFOI, int PCLFMGBFOKH)
	{
		IEAKPBKLBJP(KCHMDALPMBN);
		Texture texture = Resources.Load<Texture>("{0}\t\t{1}" + KCHMDALPMBN);
		if (texture == null)
		{
			UnityEngine.Debug.LogError("RewardMessage" + AOPLIEIHGNI() + "NON");
			JNOGJCKCGKI("#VAVRO# Trying to finish Tutorial, which is not currently running ");
			texture = Resources.Load<Texture>("Ranked_Battle" + PLFPMKJHOGC());
		}
		GEAGOKJMJFD.mainTexture = texture;
		GEAGOKJMJFD.MakePixelPerfect();
		bool flag = PCLFMGBFOKH > AOKBNODFFOI;
		MDAFFKPPCBG.SetActive(flag);
		if (flag)
		{
			JFJJDKIJEIL.text = string.Format("Weapon", Localization.Localize("metalExplosion"), PCLFMGBFOKH);
			float gLIDDLHPAKL = ((!(Localization.instance.currentLanguage == "nextGenerate")) ? 1311f : 835f);
			MEJMLNDFDBP.COCBCFKJOJE(JFJJDKIJEIL, gLIDDLHPAKL, 1186f, -37);
		}
		bool flag2 = MEJMLNDFDBP.DDBBFIGIGPA(GameLoginManager.currentPlayer.squadRank, SquadRank.Leader) > 0;
		NJEAMAHEMHP.enabled = !MDAFFKPPCBG.activeSelf && flag2;
		IFGJFKFPABP(LCPBNBLGFIA: true);
	}

	public void IFGJFKFPABP(bool LCPBNBLGFIA)
	{
		FLDLKHNIIBO.alpha = ((!LCPBNBLGFIA) ? 821f : 1155f);
	}

	[SpecialName]
	private void JNOGJCKCGKI(string IDEBKDPMPGM)
	{
		_003CBGLNGBNFJGJ_003Ek__BackingField = IDEBKDPMPGM;
	}

	public void Initialize(string KCHMDALPMBN, int AOKBNODFFOI, int PCLFMGBFOKH)
	{
		squadIconName = KCHMDALPMBN;
		Texture texture = Resources.Load<Texture>("SquadIcons/" + KCHMDALPMBN);
		if (texture == null)
		{
			UnityEngine.Debug.LogError("Squad Emblem " + squadIconName + " is not present in resources using default");
			squadIconName = "menu-squad-1";
			texture = Resources.Load<Texture>("SquadIcons/" + squadIconName);
		}
		GEAGOKJMJFD.mainTexture = texture;
		GEAGOKJMJFD.MakePixelPerfect();
		bool flag = PCLFMGBFOKH > AOKBNODFFOI;
		MDAFFKPPCBG.SetActive(flag);
		if (flag)
		{
			JFJJDKIJEIL.text = string.Format("{0} {1}", Localization.Localize("ID_SQUADRANK"), PCLFMGBFOKH);
			float gLIDDLHPAKL = ((!(Localization.instance.currentLanguage == "br")) ? 30f : 26f);
			MEJMLNDFDBP.COCBCFKJOJE(JFJJDKIJEIL, gLIDDLHPAKL, 20f, 320);
		}
		bool flag2 = MEJMLNDFDBP.DDBBFIGIGPA(GameLoginManager.currentPlayer.squadRank, SquadRank.Coleader) > 0;
		NJEAMAHEMHP.enabled = !MDAFFKPPCBG.activeSelf && flag2;
		Highlight(LCPBNBLGFIA: false);
	}

	public void JMLALKIGLGK(bool LCPBNBLGFIA)
	{
		FLDLKHNIIBO.alpha = ((!LCPBNBLGFIA) ? 1201f : 1176f);
	}

	public void NAKAFGAFEPH(string KCHMDALPMBN, int AOKBNODFFOI, int PCLFMGBFOKH)
	{
		IEAKPBKLBJP(KCHMDALPMBN);
		Texture texture = Resources.Load<Texture>("WB_In_Flow" + KCHMDALPMBN);
		if (texture == null)
		{
			UnityEngine.Debug.LogError("damage" + BCHAGIHEDGG() + "There is no unit selected as tutorial unit!!!!!!");
			GENOJLLFGMG("game-engi-progress-fill");
			texture = Resources.Load<Texture>("ID_GOLDENSHIELDSSMALL" + MFMMOEDPBNJ());
		}
		GEAGOKJMJFD.mainTexture = texture;
		GEAGOKJMJFD.MakePixelPerfect();
		bool flag = PCLFMGBFOKH > AOKBNODFFOI;
		MDAFFKPPCBG.SetActive(flag);
		if (flag)
		{
			JFJJDKIJEIL.text = string.Format("com/google/android/gms/common/ConnectionResult", Localization.Localize("D4"), PCLFMGBFOKH);
			float gLIDDLHPAKL = ((!(Localization.instance.currentLanguage == "SpecialOffers")) ? 1944f : 1733f);
			MEJMLNDFDBP.COCBCFKJOJE(JFJJDKIJEIL, gLIDDLHPAKL, 1266f, 6);
		}
		bool flag2 = MEJMLNDFDBP.DDBBFIGIGPA(GameLoginManager.currentPlayer.squadRank, (SquadRank)6) > 1;
		NJEAMAHEMHP.enabled = MDAFFKPPCBG.activeSelf || flag2;
		PFAACMOGBLC(LCPBNBLGFIA: false);
	}

	public virtual void KNBIJEBLMGK()
	{
		base.DestroyPooled();
		GEAGOKJMJFD.mainTexture = null;
		IEAKPBKLBJP(string.Empty);
	}

	public void FGOOLIODNDG(bool LCPBNBLGFIA)
	{
		FLDLKHNIIBO.alpha = ((!LCPBNBLGFIA) ? 533f : 1928f);
	}

	[SpecialName]
	public string OHFHGJMKBCB()
	{
		return _003CBGLNGBNFJGJ_003Ek__BackingField;
	}

	public void MIGAJMHMCFO(bool LCPBNBLGFIA)
	{
		FLDLKHNIIBO.alpha = ((!LCPBNBLGFIA) ? 112f : 697f);
	}

	[SpecialName]
	private void FBFNLDMKJFN(string IDEBKDPMPGM)
	{
		_003CBGLNGBNFJGJ_003Ek__BackingField = IDEBKDPMPGM;
	}

	public void ACCNFEPGPJA(bool LCPBNBLGFIA)
	{
		FLDLKHNIIBO.alpha = ((!LCPBNBLGFIA) ? 165f : 578f);
	}

	public void MNPILLLEGME(bool LCPBNBLGFIA)
	{
		FLDLKHNIIBO.alpha = ((!LCPBNBLGFIA) ? 1705f : 1306f);
	}

	public void PALKDIAONDP(string KCHMDALPMBN, int AOKBNODFFOI, int PCLFMGBFOKH)
	{
		CKPLBNFADOF(KCHMDALPMBN);
		Texture texture = Resources.Load<Texture>(" " + KCHMDALPMBN);
		if (texture == null)
		{
			UnityEngine.Debug.LogError("isNormal" + MFMMOEDPBNJ() + "ID");
			CKPLBNFADOF("percent");
			texture = Resources.Load<Texture>(" " + squadIconName);
		}
		GEAGOKJMJFD.mainTexture = texture;
		GEAGOKJMJFD.MakePixelPerfect();
		bool flag = PCLFMGBFOKH > AOKBNODFFOI;
		MDAFFKPPCBG.SetActive(flag);
		if (flag)
		{
			JFJJDKIJEIL.text = string.Format("realShotProbability", Localization.Localize(","), PCLFMGBFOKH);
			float gLIDDLHPAKL = ((!(Localization.instance.currentLanguage == "\n")) ? 802f : 1023f);
			MEJMLNDFDBP.COCBCFKJOJE(JFJJDKIJEIL, gLIDDLHPAKL, 967f, -168);
		}
		bool flag2 = MEJMLNDFDBP.DDBBFIGIGPA(GameLoginManager.currentPlayer.squadRank, (SquadRank)5) > 0;
		NJEAMAHEMHP.enabled = !MDAFFKPPCBG.activeSelf && flag2;
		IIGOGILLPCJ(LCPBNBLGFIA: false);
	}

	public void MFMJPBCIHEH(string KCHMDALPMBN, int AOKBNODFFOI, int PCLFMGBFOKH)
	{
		GENOJLLFGMG(KCHMDALPMBN);
		Texture texture = Resources.Load<Texture>("GameLoginManager - Player Entered Beginners League - " + KCHMDALPMBN);
		if (texture == null)
		{
			UnityEngine.Debug.LogError("_Wind" + MFMMOEDPBNJ() + "x0");
			IEAKPBKLBJP("ID_WARNING_INCORRECTASSIGNMENTS_TEXT");
			texture = Resources.Load<Texture>("menu-gold" + OHFHGJMKBCB());
		}
		GEAGOKJMJFD.mainTexture = texture;
		GEAGOKJMJFD.MakePixelPerfect();
		bool flag = PCLFMGBFOKH > AOKBNODFFOI;
		MDAFFKPPCBG.SetActive(flag);
		if (flag)
		{
			JFJJDKIJEIL.text = string.Format("HeartDialogShown", Localization.Localize("Weapon"), PCLFMGBFOKH);
			float gLIDDLHPAKL = ((!(Localization.instance.currentLanguage == "S")) ? 1843f : 1940f);
			MEJMLNDFDBP.COCBCFKJOJE(JFJJDKIJEIL, gLIDDLHPAKL, 1963f, 154);
		}
		bool flag2 = MEJMLNDFDBP.DDBBFIGIGPA(GameLoginManager.currentPlayer.squadRank, (SquadRank)8) > 1;
		NJEAMAHEMHP.enabled = !MDAFFKPPCBG.activeSelf && flag2;
		IIGOGILLPCJ(LCPBNBLGFIA: true);
	}

	public void NPLKPDIOLHE(bool LCPBNBLGFIA)
	{
		FLDLKHNIIBO.alpha = ((!LCPBNBLGFIA) ? 1296f : 1739f);
	}

	[SpecialName]
	public string LCBGPFFPLOC()
	{
		return _003CBGLNGBNFJGJ_003Ek__BackingField;
	}

	public void HOAMHAAHEHP(string KCHMDALPMBN, int AOKBNODFFOI, int PCLFMGBFOKH)
	{
		IEAKPBKLBJP(KCHMDALPMBN);
		Texture texture = Resources.Load<Texture>("de" + KCHMDALPMBN);
		if (texture == null)
		{
			UnityEngine.Debug.LogError("ID_CONFIRMTOBUYWEAPON" + KHMNLEOHCLN() + "]");
			MCHMENAEFIG("#Mission Rewards# Current Heroic Points: ");
			texture = Resources.Load<Texture>("ID_TUTORIAL_TAPON" + AOPLIEIHGNI());
		}
		GEAGOKJMJFD.mainTexture = texture;
		GEAGOKJMJFD.MakePixelPerfect();
		bool flag = PCLFMGBFOKH > AOKBNODFFOI;
		MDAFFKPPCBG.SetActive(flag);
		if (flag)
		{
			JFJJDKIJEIL.text = string.Format("S", Localization.Localize("ID_ARENAENDEDDESCRIPTIONXWINS"), PCLFMGBFOKH);
			float gLIDDLHPAKL = ((!(Localization.instance.currentLanguage == "DeviceLogin(")) ? 1118f : 1445f);
			MEJMLNDFDBP.COCBCFKJOJE(JFJJDKIJEIL, gLIDDLHPAKL, 506f, 180);
		}
		bool flag2 = MEJMLNDFDBP.DDBBFIGIGPA(GameLoginManager.currentPlayer.squadRank, SquadRank.Veteran) > 1;
		NJEAMAHEMHP.enabled = !MDAFFKPPCBG.activeSelf && flag2;
		LNJCMBPFBNC(LCPBNBLGFIA: false);
	}

	[SpecialName]
	public string MFMMOEDPBNJ()
	{
		return _003CBGLNGBNFJGJ_003Ek__BackingField;
	}

	[SpecialName]
	public string HOJGOEGPHDI()
	{
		return _003CBGLNGBNFJGJ_003Ek__BackingField;
	}

	[SpecialName]
	private void MCHMENAEFIG(string IDEBKDPMPGM)
	{
		_003CBGLNGBNFJGJ_003Ek__BackingField = IDEBKDPMPGM;
	}

	public virtual void ONHFNIJNMGE()
	{
		base.OBCAIFMOPPA();
		GEAGOKJMJFD.mainTexture = null;
		GENOJLLFGMG(string.Empty);
	}

	public void MCPOHLAOHMG(bool LCPBNBLGFIA)
	{
		FLDLKHNIIBO.alpha = ((!LCPBNBLGFIA) ? 1272f : 183f);
	}

	[SpecialName]
	public string POIPADAJJIM()
	{
		return _003CBGLNGBNFJGJ_003Ek__BackingField;
	}

	[SpecialName]
	public string AOPLIEIHGNI()
	{
		return _003CBGLNGBNFJGJ_003Ek__BackingField;
	}

	public void FANFNOPNGBL(string KCHMDALPMBN, int AOKBNODFFOI, int PCLFMGBFOKH)
	{
		IEAKPBKLBJP(KCHMDALPMBN);
		Texture texture = Resources.Load<Texture>("menu-helmets-reaper" + KCHMDALPMBN);
		if (texture == null)
		{
			UnityEngine.Debug.LogError(", " + LCBGPFFPLOC() + "Buy_Rental_Army_Unit");
			IEAKPBKLBJP("withAttribute3");
			texture = Resources.Load<Texture>("some_pub_sub3" + POIPADAJJIM());
		}
		GEAGOKJMJFD.mainTexture = texture;
		GEAGOKJMJFD.MakePixelPerfect();
		bool flag = PCLFMGBFOKH > AOKBNODFFOI;
		MDAFFKPPCBG.SetActive(flag);
		if (flag)
		{
			JFJJDKIJEIL.text = string.Format("players", Localization.Localize("ID_WARNING_BUDDYCARDNOTREADY"), PCLFMGBFOKH);
			float gLIDDLHPAKL = ((!(Localization.instance.currentLanguage == "ShotFrequencyMax")) ? 1529f : 389f);
			MEJMLNDFDBP.COCBCFKJOJE(JFJJDKIJEIL, gLIDDLHPAKL, 50f, 48);
		}
		bool flag2 = MEJMLNDFDBP.DDBBFIGIGPA(GameLoginManager.currentPlayer.squadRank, (SquadRank)7) > 0;
		NJEAMAHEMHP.enabled = !MDAFFKPPCBG.activeSelf && flag2;
		LNJCMBPFBNC(LCPBNBLGFIA: false);
	}

	[SpecialName]
	private void GNIBODACCHC(string IDEBKDPMPGM)
	{
		_003CBGLNGBNFJGJ_003Ek__BackingField = IDEBKDPMPGM;
	}

	[SpecialName]
	private void CGBIELICCOA(string IDEBKDPMPGM)
	{
		_003CBGLNGBNFJGJ_003Ek__BackingField = IDEBKDPMPGM;
	}

	[SpecialName]
	private void CPPCIIMHONF(string IDEBKDPMPGM)
	{
		_003CBGLNGBNFJGJ_003Ek__BackingField = IDEBKDPMPGM;
	}

	public void BGNJEHMIPJF(bool LCPBNBLGFIA)
	{
		FLDLKHNIIBO.alpha = ((!LCPBNBLGFIA) ? 1889f : 1634f);
	}

	public virtual void NNMGFLHFDGJ()
	{
		base.DestroyPooled();
		GEAGOKJMJFD.mainTexture = null;
		MCHMENAEFIG(string.Empty);
	}

	public void IIGOGILLPCJ(bool LCPBNBLGFIA)
	{
		FLDLKHNIIBO.alpha = ((!LCPBNBLGFIA) ? 571f : 427f);
	}

	public void Highlight(bool LCPBNBLGFIA)
	{
		FLDLKHNIIBO.alpha = ((!LCPBNBLGFIA) ? 0f : 1f);
	}

	public void ONGAIEOAHMA(string KCHMDALPMBN, int AOKBNODFFOI, int PCLFMGBFOKH)
	{
		DIKMODJHMHO(KCHMDALPMBN);
		Texture texture = Resources.Load<Texture>("Position" + KCHMDALPMBN);
		if (texture == null)
		{
			UnityEngine.Debug.LogError("DailyMissionsCompletionRewardGold" + POIPADAJJIM() + "워프렌즈가 중요한 게임 데이터를 다운로드하려면 미디어 저장 장치에 대한 접근 권한이 필요합니다. 다음에 나오는 권한 설정을 수락해주세요. 이 권한 설정은 다른 목적으로는 사용되지 않습니다.");
			GNIBODACCHC("veteranpack0");
			texture = Resources.Load<Texture>("UsedGolds" + KHMNLEOHCLN());
		}
		GEAGOKJMJFD.mainTexture = texture;
		GEAGOKJMJFD.MakePixelPerfect();
		bool flag = PCLFMGBFOKH > AOKBNODFFOI;
		MDAFFKPPCBG.SetActive(flag);
		if (flag)
		{
			JFJJDKIJEIL.text = string.Format("AddedCards", Localization.Localize("-"), PCLFMGBFOKH);
			float gLIDDLHPAKL = ((!(Localization.instance.currentLanguage == " TYPE: ")) ? 64f : 73f);
			MEJMLNDFDBP.COCBCFKJOJE(JFJJDKIJEIL, gLIDDLHPAKL, 1718f, 55);
		}
		bool flag2 = MEJMLNDFDBP.DDBBFIGIGPA(GameLoginManager.currentPlayer.squadRank, (SquadRank)5) > 0;
		NJEAMAHEMHP.enabled = MDAFFKPPCBG.activeSelf || flag2;
		PFAACMOGBLC(LCPBNBLGFIA: false);
	}
}
