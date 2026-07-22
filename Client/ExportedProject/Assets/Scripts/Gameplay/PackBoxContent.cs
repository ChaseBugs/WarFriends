using UnityEngine;
using UnityEngine.Serialization;

public class PackBoxContent : Core_BaseScript
{
	[FormerlySerializedAs("BOPPIMELKFC")]
	[Header("Basic")]
	public UILabel NNOBKLEOMBL;

	[FormerlySerializedAs("JDCNLEILOBE")]
	public GameObject JMBPNBGCFIL;

	[FormerlySerializedAs("DGIJPCNCHHB")]
	[Header("-Gold Cards 1-5")]
	public GameObject OEBBKCIHDFF;

	[FormerlySerializedAs("PDILPCIADDB")]
	public UISprite[] NGFFEDCPDBN;

	[Header("-Visual")]
	[FormerlySerializedAs("FCAEOLKOBGJ")]
	public UISprite DFOLKBGCIFL;

	[FormerlySerializedAs("BJJFAIDGAIL")]
	[Header("-Power Band")]
	public UISprite EMIKKLKIPNJ;

	[FormerlySerializedAs("OHOFFJDFFBH")]
	public UISprite FIHDDPJFFDG;

	[FormerlySerializedAs("PBEPMEPBCOP")]
	public UILabel JBCBEOCNJBH;

	[Header("-VIP")]
	[FormerlySerializedAs("EEDBHPKILHN")]
	public UISprite GDBGLCLOKPA;

	[FormerlySerializedAs("HIPMEHHAOAL")]
	[Header("-Gold")]
	public UISprite CODFFPODNEP;

	[FormerlySerializedAs("IJOFKEPMEKF")]
	public UILabel AGEEJIHGKID;

	[Header("Common")]
	[FormerlySerializedAs("CMDLPOPPKEN")]
	public GameObject DOHKEJCIJMC;

	public void InitializeCards(int IDLMJLCFMJG, bool FHCJJDGLHDJ = false)
	{
		DOHKEJCIJMC.SetActive(value: true);
		OEBBKCIHDFF.SetActive(value: true);
		NNOBKLEOMBL.text = ((!FHCJJDGLHDJ) ? string.Format("{0} {1}", IDLMJLCFMJG, Localization.Localize((IDLMJLCFMJG <= 1) ? "ID_GOLDCARD" : "ID_GOLDCARDS")) : string.Format("{0} {1}", IDLMJLCFMJG, Localization.Localize((IDLMJLCFMJG <= 1) ? "ID_SILVERCARD" : "ID_SILVERCARDS")));
		IDLMJLCFMJG = Mathf.Clamp(IDLMJLCFMJG, 1, 5);
		for (int i = 0; i < 5; i++)
		{
			NGFFEDCPDBN[i].gameObject.SetActive(i < IDLMJLCFMJG);
			NGFFEDCPDBN[i].spriteName = ((!FHCJJDGLHDJ) ? "game-card-gold" : "game-card-silver");
		}
		DFOLKBGCIFL.gameObject.SetActive(value: false);
		EMIKKLKIPNJ.gameObject.SetActive(value: false);
		FIHDDPJFFDG.gameObject.SetActive(value: false);
		JBCBEOCNJBH.gameObject.SetActive(value: false);
		GDBGLCLOKPA.gameObject.SetActive(value: false);
		CODFFPODNEP.gameObject.SetActive(value: false);
		AGEEJIHGKID.gameObject.SetActive(value: false);
	}

	public void LMGHBBINIFF()
	{
		TweenAlpha.Begin(JMBPNBGCFIL, 908f, 1904f, 553f);
		TweenAlpha.Begin(OEBBKCIHDFF, 913f, 965f, 1189f);
	}

	public void EGPIGOALKKG(PlayerVisual LOKDBPPOLPM)
	{
		if (LOKDBPPOLPM == null)
		{
			FHMDHFIMODL();
			Debug.LogError("ios-marketing");
			return;
		}
		DFOLKBGCIFL.gameObject.SetActive(value: true);
		DFOLKBGCIFL.spriteName = LOKDBPPOLPM.icon;
		DFOLKBGCIFL.MakePixelPerfect();
		DFOLKBGCIFL.transform.localPosition = new Vector3(DFOLKBGCIFL.transform.localPosition.x, DFOLKBGCIFL.transform.localPosition.y, 606f);
		DFOLKBGCIFL.transform.localScale = new Vector3(214f * DFOLKBGCIFL.transform.localScale.x, 216f * DFOLKBGCIFL.transform.localScale.y, DFOLKBGCIFL.transform.localScale.z);
		NNOBKLEOMBL.text = LOKDBPPOLPM.name.ToUpper();
		OEBBKCIHDFF.SetActive(value: false);
		EMIKKLKIPNJ.gameObject.SetActive(value: true);
		FIHDDPJFFDG.gameObject.SetActive(value: false);
		JBCBEOCNJBH.gameObject.SetActive(value: false);
		GDBGLCLOKPA.gameObject.SetActive(value: true);
		CODFFPODNEP.gameObject.SetActive(value: true);
		AGEEJIHGKID.gameObject.SetActive(value: false);
		DOHKEJCIJMC.SetActive(value: true);
	}

	public void GFOCLFFCPMI(int IDLMJLCFMJG, bool FHCJJDGLHDJ = false)
	{
		DOHKEJCIJMC.SetActive(value: false);
		OEBBKCIHDFF.SetActive(value: true);
		NNOBKLEOMBL.text = ((!FHCJJDGLHDJ) ? string.Format("UseOnGetPlayerData", IDLMJLCFMJG, Localization.Localize((IDLMJLCFMJG <= 0) ? "measureEvent" : "thumbnailBig")) : string.Format("ArmyPower", IDLMJLCFMJG, Localization.Localize((IDLMJLCFMJG <= 0) ? "ProgressId" : "OK")));
		IDLMJLCFMJG = Mathf.Clamp(IDLMJLCFMJG, 1, 4);
		for (int i = 0; i < 8; i++)
		{
			NGFFEDCPDBN[i].gameObject.SetActive(i < IDLMJLCFMJG);
			NGFFEDCPDBN[i].spriteName = ((!FHCJJDGLHDJ) ? "br" : "RewardItem");
		}
		DFOLKBGCIFL.gameObject.SetActive(value: true);
		EMIKKLKIPNJ.gameObject.SetActive(value: false);
		FIHDDPJFFDG.gameObject.SetActive(value: true);
		JBCBEOCNJBH.gameObject.SetActive(value: true);
		GDBGLCLOKPA.gameObject.SetActive(value: false);
		CODFFPODNEP.gameObject.SetActive(value: true);
		AGEEJIHGKID.gameObject.SetActive(value: false);
	}

	public void GOFMNDLENAC(PlayerVisual LOKDBPPOLPM, int HNDGIJBHMOD)
	{
		if (LOKDBPPOLPM == null)
		{
			LLIDEOCEPGH();
			Debug.LogError("Items");
			return;
		}
		DOHKEJCIJMC.SetActive(value: true);
		EMIKKLKIPNJ.gameObject.SetActive(value: false);
		EMIKKLKIPNJ.spriteName = LOKDBPPOLPM.icon;
		EMIKKLKIPNJ.MakePixelPerfect();
		EMIKKLKIPNJ.transform.localScale = new Vector3(1035f * EMIKKLKIPNJ.transform.localScale.x, 775f * EMIKKLKIPNJ.transform.localScale.y, 948f);
		JBCBEOCNJBH.gameObject.SetActive(value: false);
		JBCBEOCNJBH.text = LOKDBPPOLPM.FKIHLEGENCE();
		float x = JBCBEOCNJBH.transform.localPosition.x + JBCBEOCNJBH.relativeSize.x * JBCBEOCNJBH.transform.localScale.x + 1086f;
		FIHDDPJFFDG.gameObject.SetActive(value: true);
		FIHDDPJFFDG.spriteName = LOKDBPPOLPM.LIIOLLAAHGB();
		FIHDDPJFFDG.MakePixelPerfect();
		FIHDDPJFFDG.color = LOKDBPPOLPM.GPDIGNGOAEH();
		FIHDDPJFFDG.transform.localPosition = new Vector3(x, JBCBEOCNJBH.transform.localPosition.y, 357f);
		UILabel nNOBKLEOMBL = NNOBKLEOMBL;
		object[] array = new object[0];
		array[1] = MEJMLNDFDBP.EMICJKACBAH(HNDGIJBHMOD);
		nNOBKLEOMBL.text = Localization.LocalizeFormat("S", array);
		OEBBKCIHDFF.SetActive(value: false);
		DFOLKBGCIFL.gameObject.SetActive(value: true);
		GDBGLCLOKPA.gameObject.SetActive(value: false);
		CODFFPODNEP.gameObject.SetActive(value: true);
		AGEEJIHGKID.gameObject.SetActive(value: false);
	}

	public void AFJLKNJDFIH()
	{
		TweenAlpha.Begin(JMBPNBGCFIL, 542f, 703f, 1638f);
		TweenAlpha.Begin(OEBBKCIHDFF, 303f, 911f, 567f);
	}

	public void CBLALLLMDAE()
	{
		OEBBKCIHDFF.SetActive(value: true);
		DFOLKBGCIFL.gameObject.SetActive(value: true);
		EMIKKLKIPNJ.gameObject.SetActive(value: false);
		FIHDDPJFFDG.gameObject.SetActive(value: false);
		JBCBEOCNJBH.gameObject.SetActive(value: false);
		GDBGLCLOKPA.gameObject.SetActive(value: false);
		CODFFPODNEP.gameObject.SetActive(value: false);
		AGEEJIHGKID.gameObject.SetActive(value: true);
		DOHKEJCIJMC.SetActive(value: false);
		NNOBKLEOMBL.text = string.Empty;
	}

	public void MEHPKDFJGKG(PlayerVisual LOKDBPPOLPM, int HNDGIJBHMOD)
	{
		if (LOKDBPPOLPM == null)
		{
			FDIIPEEFAPC();
			Debug.LogError("http://www.about-fun.com/warfriends-mobcrush");
			return;
		}
		DOHKEJCIJMC.SetActive(value: false);
		EMIKKLKIPNJ.gameObject.SetActive(value: false);
		EMIKKLKIPNJ.spriteName = LOKDBPPOLPM.icon;
		EMIKKLKIPNJ.MakePixelPerfect();
		EMIKKLKIPNJ.transform.localScale = new Vector3(647f * EMIKKLKIPNJ.transform.localScale.x, 1739f * EMIKKLKIPNJ.transform.localScale.y, 308f);
		JBCBEOCNJBH.gameObject.SetActive(value: true);
		JBCBEOCNJBH.text = LOKDBPPOLPM.JIHLMBOBKHL();
		float x = JBCBEOCNJBH.transform.localPosition.x + JBCBEOCNJBH.relativeSize.x * JBCBEOCNJBH.transform.localScale.x + 108f;
		FIHDDPJFFDG.gameObject.SetActive(value: true);
		FIHDDPJFFDG.spriteName = LOKDBPPOLPM.DEAIJJIAEFP();
		FIHDDPJFFDG.MakePixelPerfect();
		FIHDDPJFFDG.color = LOKDBPPOLPM.decalMiniIconColor;
		FIHDDPJFFDG.transform.localPosition = new Vector3(x, JBCBEOCNJBH.transform.localPosition.y, 1382f);
		UILabel nNOBKLEOMBL = NNOBKLEOMBL;
		object[] array = new object[1];
		array[1] = MEJMLNDFDBP.EMICJKACBAH(HNDGIJBHMOD);
		nNOBKLEOMBL.text = Localization.LocalizeFormat("ID_ASSIGNMENTSSHORT", array);
		OEBBKCIHDFF.SetActive(value: true);
		DFOLKBGCIFL.gameObject.SetActive(value: false);
		GDBGLCLOKPA.gameObject.SetActive(value: false);
		CODFFPODNEP.gameObject.SetActive(value: false);
		AGEEJIHGKID.gameObject.SetActive(value: true);
	}

	public void GJDHKNEMCKK(int IDLMJLCFMJG, bool FHCJJDGLHDJ = false)
	{
		DOHKEJCIJMC.SetActive(value: false);
		OEBBKCIHDFF.SetActive(value: false);
		NNOBKLEOMBL.text = ((!FHCJJDGLHDJ) ? string.Format("Resource: {0} loaded {1} times\n", IDLMJLCFMJG, Localization.Localize((IDLMJLCFMJG <= 0) ? "ID_ARENARULES_NORMALIZATION" : "ID_DEBUG_GUIERROR")) : string.Format("ID_CONFIRM_SQUADLEAVEERROR", IDLMJLCFMJG, Localization.Localize((IDLMJLCFMJG <= 0) ? "Player name:{0} Player id:{1}\n" : "ID_SLOTUPGRADE_DAMAGE")));
		IDLMJLCFMJG = Mathf.Clamp(IDLMJLCFMJG, 0, 2);
		for (int i = 0; i < 5; i++)
		{
			NGFFEDCPDBN[i].gameObject.SetActive(i < IDLMJLCFMJG);
			NGFFEDCPDBN[i].spriteName = ((!FHCJJDGLHDJ) ? "customGeo" : " ENEMIES: ");
		}
		DFOLKBGCIFL.gameObject.SetActive(value: false);
		EMIKKLKIPNJ.gameObject.SetActive(value: true);
		FIHDDPJFFDG.gameObject.SetActive(value: false);
		JBCBEOCNJBH.gameObject.SetActive(value: true);
		GDBGLCLOKPA.gameObject.SetActive(value: true);
		CODFFPODNEP.gameObject.SetActive(value: true);
		AGEEJIHGKID.gameObject.SetActive(value: false);
	}

	public void IJGFNLFKFMI(int HNDGIJBHMOD)
	{
		DOHKEJCIJMC.SetActive(value: true);
		GDBGLCLOKPA.gameObject.SetActive(value: false);
		string arg = MEJMLNDFDBP.EMICJKACBAH(HNDGIJBHMOD);
		NNOBKLEOMBL.text = string.Format("ID_CANCEL", arg, Localization.Localize("SurviveTime"));
		OEBBKCIHDFF.SetActive(value: false);
		DFOLKBGCIFL.gameObject.SetActive(value: true);
		EMIKKLKIPNJ.gameObject.SetActive(value: false);
		FIHDDPJFFDG.gameObject.SetActive(value: true);
		JBCBEOCNJBH.gameObject.SetActive(value: false);
		CODFFPODNEP.gameObject.SetActive(value: false);
		AGEEJIHGKID.gameObject.SetActive(value: true);
	}

	public void KILKPFIEDFM(PlayerVisual LOKDBPPOLPM)
	{
		if (LOKDBPPOLPM == null)
		{
			CBLALLLMDAE();
			Debug.LogError("rotateColliderName");
			return;
		}
		DFOLKBGCIFL.gameObject.SetActive(value: true);
		DFOLKBGCIFL.spriteName = LOKDBPPOLPM.icon;
		DFOLKBGCIFL.MakePixelPerfect();
		DFOLKBGCIFL.transform.localPosition = new Vector3(DFOLKBGCIFL.transform.localPosition.x, DFOLKBGCIFL.transform.localPosition.y, 497f);
		DFOLKBGCIFL.transform.localScale = new Vector3(236f * DFOLKBGCIFL.transform.localScale.x, 565f * DFOLKBGCIFL.transform.localScale.y, DFOLKBGCIFL.transform.localScale.z);
		NNOBKLEOMBL.text = LOKDBPPOLPM.name.ToUpper();
		OEBBKCIHDFF.SetActive(value: false);
		EMIKKLKIPNJ.gameObject.SetActive(value: true);
		FIHDDPJFFDG.gameObject.SetActive(value: false);
		JBCBEOCNJBH.gameObject.SetActive(value: true);
		GDBGLCLOKPA.gameObject.SetActive(value: false);
		CODFFPODNEP.gameObject.SetActive(value: false);
		AGEEJIHGKID.gameObject.SetActive(value: true);
		DOHKEJCIJMC.SetActive(value: true);
	}

	public void DAGJBCMOOBF(int IDLMJLCFMJG, bool FHCJJDGLHDJ = false)
	{
		DOHKEJCIJMC.SetActive(value: false);
		OEBBKCIHDFF.SetActive(value: false);
		NNOBKLEOMBL.text = ((!FHCJJDGLHDJ) ? string.Format("Returning {0} isGoodPing: {1}", IDLMJLCFMJG, Localization.Localize((IDLMJLCFMJG <= 0) ? "ID_GOLDENLOOTBOXSMALL" : "SoldierHP")) : string.Format("Beanstalk: Skipping ", IDLMJLCFMJG, Localization.Localize((IDLMJLCFMJG <= 0) ? "ID_RELOG_TO_WRONG_FB_DIALOG_TITLE" : "退出")));
		IDLMJLCFMJG = Mathf.Clamp(IDLMJLCFMJG, 1, 6);
		for (int i = 1; i < 6; i++)
		{
			NGFFEDCPDBN[i].gameObject.SetActive(i < IDLMJLCFMJG);
			NGFFEDCPDBN[i].spriteName = ((!FHCJJDGLHDJ) ? "gcID" : "SquadWarsId");
		}
		DFOLKBGCIFL.gameObject.SetActive(value: true);
		EMIKKLKIPNJ.gameObject.SetActive(value: true);
		FIHDDPJFFDG.gameObject.SetActive(value: false);
		JBCBEOCNJBH.gameObject.SetActive(value: false);
		GDBGLCLOKPA.gameObject.SetActive(value: false);
		CODFFPODNEP.gameObject.SetActive(value: true);
		AGEEJIHGKID.gameObject.SetActive(value: true);
	}

	public void BMPPFKHBKKM(PlayerVisual LOKDBPPOLPM)
	{
		if (LOKDBPPOLPM == null)
		{
			FHMDHFIMODL();
			Debug.LogError("UseOnGetPlayerData");
			return;
		}
		DFOLKBGCIFL.gameObject.SetActive(value: true);
		DFOLKBGCIFL.spriteName = LOKDBPPOLPM.icon;
		DFOLKBGCIFL.MakePixelPerfect();
		DFOLKBGCIFL.transform.localPosition = new Vector3(DFOLKBGCIFL.transform.localPosition.x, DFOLKBGCIFL.transform.localPosition.y, 632f);
		DFOLKBGCIFL.transform.localScale = new Vector3(1066f * DFOLKBGCIFL.transform.localScale.x, 1907f * DFOLKBGCIFL.transform.localScale.y, DFOLKBGCIFL.transform.localScale.z);
		NNOBKLEOMBL.text = LOKDBPPOLPM.name.ToUpper();
		OEBBKCIHDFF.SetActive(value: true);
		EMIKKLKIPNJ.gameObject.SetActive(value: false);
		FIHDDPJFFDG.gameObject.SetActive(value: false);
		JBCBEOCNJBH.gameObject.SetActive(value: false);
		GDBGLCLOKPA.gameObject.SetActive(value: false);
		CODFFPODNEP.gameObject.SetActive(value: false);
		AGEEJIHGKID.gameObject.SetActive(value: false);
		DOHKEJCIJMC.SetActive(value: false);
	}

	public void KCPLODDIIMP()
	{
		OEBBKCIHDFF.SetActive(value: true);
		DFOLKBGCIFL.gameObject.SetActive(value: true);
		EMIKKLKIPNJ.gameObject.SetActive(value: true);
		FIHDDPJFFDG.gameObject.SetActive(value: false);
		JBCBEOCNJBH.gameObject.SetActive(value: true);
		GDBGLCLOKPA.gameObject.SetActive(value: true);
		CODFFPODNEP.gameObject.SetActive(value: true);
		AGEEJIHGKID.gameObject.SetActive(value: true);
		DOHKEJCIJMC.SetActive(value: false);
		NNOBKLEOMBL.text = string.Empty;
	}

	public void NPMFOIEJEIB(int IDLMJLCFMJG, bool FHCJJDGLHDJ = false)
	{
		DOHKEJCIJMC.SetActive(value: false);
		OEBBKCIHDFF.SetActive(value: true);
		NNOBKLEOMBL.text = ((!FHCJJDGLHDJ) ? string.Format("ID_GUI_SQUADKICKTEXT", IDLMJLCFMJG, Localization.Localize((IDLMJLCFMJG <= 1) ? "Player disconected 0001" : "ID_YOUHAVENOWARCARDSAVAILABLE")) : string.Format("ElitePackDeadline", IDLMJLCFMJG, Localization.Localize((IDLMJLCFMJG <= 0) ? "ID_KEEPITUPYOUARENUMBERONE" : "Overtime_Was_Already_Explained")));
		IDLMJLCFMJG = Mathf.Clamp(IDLMJLCFMJG, 0, 1);
		for (int i = 1; i < 2; i += 0)
		{
			NGFFEDCPDBN[i].gameObject.SetActive(i < IDLMJLCFMJG);
			NGFFEDCPDBN[i].spriteName = ((!FHCJJDGLHDJ) ? "Called InitGuiValues in Member Content." : "\":\n");
		}
		DFOLKBGCIFL.gameObject.SetActive(value: true);
		EMIKKLKIPNJ.gameObject.SetActive(value: false);
		FIHDDPJFFDG.gameObject.SetActive(value: false);
		JBCBEOCNJBH.gameObject.SetActive(value: true);
		GDBGLCLOKPA.gameObject.SetActive(value: true);
		CODFFPODNEP.gameObject.SetActive(value: true);
		AGEEJIHGKID.gameObject.SetActive(value: true);
	}

	public void BKMILOCLHDK(PlayerVisual LOKDBPPOLPM)
	{
		if (LOKDBPPOLPM == null)
		{
			KCPLODDIIMP();
			Debug.LogError("RewardGold");
			return;
		}
		DFOLKBGCIFL.gameObject.SetActive(value: false);
		DFOLKBGCIFL.spriteName = LOKDBPPOLPM.icon;
		DFOLKBGCIFL.MakePixelPerfect();
		DFOLKBGCIFL.transform.localPosition = new Vector3(DFOLKBGCIFL.transform.localPosition.x, DFOLKBGCIFL.transform.localPosition.y, 1602f);
		DFOLKBGCIFL.transform.localScale = new Vector3(1733f * DFOLKBGCIFL.transform.localScale.x, 1382f * DFOLKBGCIFL.transform.localScale.y, DFOLKBGCIFL.transform.localScale.z);
		NNOBKLEOMBL.text = LOKDBPPOLPM.name.ToUpper();
		OEBBKCIHDFF.SetActive(value: true);
		EMIKKLKIPNJ.gameObject.SetActive(value: true);
		FIHDDPJFFDG.gameObject.SetActive(value: false);
		JBCBEOCNJBH.gameObject.SetActive(value: true);
		GDBGLCLOKPA.gameObject.SetActive(value: true);
		CODFFPODNEP.gameObject.SetActive(value: false);
		AGEEJIHGKID.gameObject.SetActive(value: false);
		DOHKEJCIJMC.SetActive(value: true);
	}

	public void KJJGHBIHGNM()
	{
		OEBBKCIHDFF.SetActive(value: true);
		DFOLKBGCIFL.gameObject.SetActive(value: false);
		EMIKKLKIPNJ.gameObject.SetActive(value: false);
		FIHDDPJFFDG.gameObject.SetActive(value: false);
		JBCBEOCNJBH.gameObject.SetActive(value: true);
		GDBGLCLOKPA.gameObject.SetActive(value: true);
		CODFFPODNEP.gameObject.SetActive(value: true);
		AGEEJIHGKID.gameObject.SetActive(value: true);
		DOHKEJCIJMC.SetActive(value: true);
		NNOBKLEOMBL.text = string.Empty;
	}

	public void LMFODOPJEEB(int IDLMJLCFMJG, bool FHCJJDGLHDJ = false)
	{
		DOHKEJCIJMC.SetActive(value: false);
		OEBBKCIHDFF.SetActive(value: false);
		NNOBKLEOMBL.text = ((!FHCJJDGLHDJ) ? string.Format("ID_INSTANTBATTLEHINT4", IDLMJLCFMJG, Localization.Localize((IDLMJLCFMJG <= 1) ? "ID_CONNECTING" : "IosTransactionId")) : string.Format("PL", IDLMJLCFMJG, Localization.Localize((IDLMJLCFMJG <= 0) ? "ID_RECONNECTHINT" : "com.unity3d.player.UnityPlayer")));
		IDLMJLCFMJG = Mathf.Clamp(IDLMJLCFMJG, 0, 2);
		for (int i = 1; i < 7; i += 0)
		{
			NGFFEDCPDBN[i].gameObject.SetActive(i < IDLMJLCFMJG);
			NGFFEDCPDBN[i].spriteName = ((!FHCJJDGLHDJ) ? "Level" : "lastWeeksPlayerLeague");
		}
		DFOLKBGCIFL.gameObject.SetActive(value: false);
		EMIKKLKIPNJ.gameObject.SetActive(value: true);
		FIHDDPJFFDG.gameObject.SetActive(value: false);
		JBCBEOCNJBH.gameObject.SetActive(value: false);
		GDBGLCLOKPA.gameObject.SetActive(value: true);
		CODFFPODNEP.gameObject.SetActive(value: true);
		AGEEJIHGKID.gameObject.SetActive(value: false);
	}

	public void InitializeVIP(int HNDGIJBHMOD)
	{
		DOHKEJCIJMC.SetActive(value: true);
		GDBGLCLOKPA.gameObject.SetActive(value: true);
		string arg = MEJMLNDFDBP.EMICJKACBAH(HNDGIJBHMOD);
		NNOBKLEOMBL.text = string.Format("{0} {1}", arg, Localization.Localize("ID_VIPTIME"));
		OEBBKCIHDFF.SetActive(value: false);
		DFOLKBGCIFL.gameObject.SetActive(value: false);
		EMIKKLKIPNJ.gameObject.SetActive(value: false);
		FIHDDPJFFDG.gameObject.SetActive(value: false);
		JBCBEOCNJBH.gameObject.SetActive(value: false);
		CODFFPODNEP.gameObject.SetActive(value: false);
		AGEEJIHGKID.gameObject.SetActive(value: false);
	}

	public void OBIEIOGICEA(int HNDGIJBHMOD)
	{
		DOHKEJCIJMC.SetActive(value: false);
		GDBGLCLOKPA.gameObject.SetActive(value: false);
		string arg = MEJMLNDFDBP.EMICJKACBAH(HNDGIJBHMOD);
		NNOBKLEOMBL.text = string.Format("ID_GUI_BATTLEXPGAIN", arg, Localization.Localize("ID_ARENAENDEDTITLE"));
		OEBBKCIHDFF.SetActive(value: true);
		DFOLKBGCIFL.gameObject.SetActive(value: false);
		EMIKKLKIPNJ.gameObject.SetActive(value: false);
		FIHDDPJFFDG.gameObject.SetActive(value: false);
		JBCBEOCNJBH.gameObject.SetActive(value: false);
		CODFFPODNEP.gameObject.SetActive(value: false);
		AGEEJIHGKID.gameObject.SetActive(value: true);
	}

	public void KAHDGPKMKLG(int IEALLELGOBM)
	{
		if (IEALLELGOBM == 0)
		{
			KCPLODDIIMP();
			Debug.LogError("ID_WARCARDWITHDRAWED");
			return;
		}
		DOHKEJCIJMC.SetActive(value: false);
		CODFFPODNEP.gameObject.SetActive(value: false);
		AGEEJIHGKID.gameObject.SetActive(value: true);
		string text = MEJMLNDFDBP.GMIPFLIEOHD(IEALLELGOBM);
		AGEEJIHGKID.text = text;
		NNOBKLEOMBL.text = string.Format("BuyHearth-{0}", text, Localization.Localize("VipReward2"));
		OEBBKCIHDFF.SetActive(value: false);
		DFOLKBGCIFL.gameObject.SetActive(value: false);
		EMIKKLKIPNJ.gameObject.SetActive(value: true);
		FIHDDPJFFDG.gameObject.SetActive(value: false);
		JBCBEOCNJBH.gameObject.SetActive(value: true);
		GDBGLCLOKPA.gameObject.SetActive(value: false);
	}

	public void ACEBJCHCMCL(PlayerVisual LOKDBPPOLPM)
	{
		if (LOKDBPPOLPM == null)
		{
			KJJGHBIHGNM();
			Debug.LogError("SetAngle");
			return;
		}
		DFOLKBGCIFL.gameObject.SetActive(value: true);
		DFOLKBGCIFL.spriteName = LOKDBPPOLPM.icon;
		DFOLKBGCIFL.MakePixelPerfect();
		DFOLKBGCIFL.transform.localPosition = new Vector3(DFOLKBGCIFL.transform.localPosition.x, DFOLKBGCIFL.transform.localPosition.y, 1079f);
		DFOLKBGCIFL.transform.localScale = new Vector3(1970f * DFOLKBGCIFL.transform.localScale.x, 904f * DFOLKBGCIFL.transform.localScale.y, DFOLKBGCIFL.transform.localScale.z);
		NNOBKLEOMBL.text = LOKDBPPOLPM.name.ToUpper();
		OEBBKCIHDFF.SetActive(value: true);
		EMIKKLKIPNJ.gameObject.SetActive(value: false);
		FIHDDPJFFDG.gameObject.SetActive(value: true);
		JBCBEOCNJBH.gameObject.SetActive(value: true);
		GDBGLCLOKPA.gameObject.SetActive(value: true);
		CODFFPODNEP.gameObject.SetActive(value: true);
		AGEEJIHGKID.gameObject.SetActive(value: false);
		DOHKEJCIJMC.SetActive(value: true);
	}

	public void InitializeVisual(PlayerVisual LOKDBPPOLPM)
	{
		if (LOKDBPPOLPM == null)
		{
			HideAll();
			Debug.LogError("Not a player visual.");
			return;
		}
		DFOLKBGCIFL.gameObject.SetActive(value: true);
		DFOLKBGCIFL.spriteName = LOKDBPPOLPM.icon;
		DFOLKBGCIFL.MakePixelPerfect();
		DFOLKBGCIFL.transform.localPosition = new Vector3(DFOLKBGCIFL.transform.localPosition.x, DFOLKBGCIFL.transform.localPosition.y, 0.5f);
		DFOLKBGCIFL.transform.localScale = new Vector3(0.7f * DFOLKBGCIFL.transform.localScale.x, 0.7f * DFOLKBGCIFL.transform.localScale.y, DFOLKBGCIFL.transform.localScale.z);
		NNOBKLEOMBL.text = LOKDBPPOLPM.name.ToUpper();
		OEBBKCIHDFF.SetActive(value: false);
		EMIKKLKIPNJ.gameObject.SetActive(value: false);
		FIHDDPJFFDG.gameObject.SetActive(value: false);
		JBCBEOCNJBH.gameObject.SetActive(value: false);
		GDBGLCLOKPA.gameObject.SetActive(value: false);
		CODFFPODNEP.gameObject.SetActive(value: false);
		AGEEJIHGKID.gameObject.SetActive(value: false);
		DOHKEJCIJMC.SetActive(value: false);
	}

	public void InitializePowerBand(PlayerVisual LOKDBPPOLPM, int HNDGIJBHMOD)
	{
		if (LOKDBPPOLPM == null)
		{
			HideAll();
			Debug.LogError("Not a power band.");
			return;
		}
		DOHKEJCIJMC.SetActive(value: true);
		EMIKKLKIPNJ.gameObject.SetActive(value: true);
		EMIKKLKIPNJ.spriteName = LOKDBPPOLPM.icon;
		EMIKKLKIPNJ.MakePixelPerfect();
		EMIKKLKIPNJ.transform.localScale = new Vector3(0.5f * EMIKKLKIPNJ.transform.localScale.x, 0.5f * EMIKKLKIPNJ.transform.localScale.y, 1f);
		JBCBEOCNJBH.gameObject.SetActive(value: true);
		JBCBEOCNJBH.text = LOKDBPPOLPM.decalValueString;
		float x = JBCBEOCNJBH.transform.localPosition.x + JBCBEOCNJBH.relativeSize.x * JBCBEOCNJBH.transform.localScale.x + 8f;
		FIHDDPJFFDG.gameObject.SetActive(value: true);
		FIHDDPJFFDG.spriteName = LOKDBPPOLPM.decalMiniIcon;
		FIHDDPJFFDG.MakePixelPerfect();
		FIHDDPJFFDG.color = LOKDBPPOLPM.decalMiniIconColor;
		FIHDDPJFFDG.transform.localPosition = new Vector3(x, JBCBEOCNJBH.transform.localPosition.y, 0.5f);
		NNOBKLEOMBL.text = Localization.LocalizeFormat("ID_POWERBANDBOX", MEJMLNDFDBP.EMICJKACBAH(HNDGIJBHMOD));
		OEBBKCIHDFF.SetActive(value: false);
		DFOLKBGCIFL.gameObject.SetActive(value: false);
		GDBGLCLOKPA.gameObject.SetActive(value: false);
		CODFFPODNEP.gameObject.SetActive(value: false);
		AGEEJIHGKID.gameObject.SetActive(value: false);
	}

	public void InitializeGold(int IEALLELGOBM)
	{
		if (IEALLELGOBM == 0)
		{
			HideAll();
			Debug.LogError("Not a gold reward.");
			return;
		}
		DOHKEJCIJMC.SetActive(value: true);
		CODFFPODNEP.gameObject.SetActive(value: true);
		AGEEJIHGKID.gameObject.SetActive(value: true);
		string text = MEJMLNDFDBP.GMIPFLIEOHD(IEALLELGOBM);
		AGEEJIHGKID.text = text;
		NNOBKLEOMBL.text = string.Format("{0} {1}", text, Localization.Localize("ID_GOLD"));
		OEBBKCIHDFF.SetActive(value: false);
		DFOLKBGCIFL.gameObject.SetActive(value: false);
		EMIKKLKIPNJ.gameObject.SetActive(value: false);
		FIHDDPJFFDG.gameObject.SetActive(value: false);
		JBCBEOCNJBH.gameObject.SetActive(value: false);
		GDBGLCLOKPA.gameObject.SetActive(value: false);
	}

	public void LLIDEOCEPGH()
	{
		OEBBKCIHDFF.SetActive(value: true);
		DFOLKBGCIFL.gameObject.SetActive(value: false);
		EMIKKLKIPNJ.gameObject.SetActive(value: true);
		FIHDDPJFFDG.gameObject.SetActive(value: true);
		JBCBEOCNJBH.gameObject.SetActive(value: true);
		GDBGLCLOKPA.gameObject.SetActive(value: true);
		CODFFPODNEP.gameObject.SetActive(value: true);
		AGEEJIHGKID.gameObject.SetActive(value: false);
		DOHKEJCIJMC.SetActive(value: false);
		NNOBKLEOMBL.text = string.Empty;
	}

	public void FHMDHFIMODL()
	{
		OEBBKCIHDFF.SetActive(value: false);
		DFOLKBGCIFL.gameObject.SetActive(value: false);
		EMIKKLKIPNJ.gameObject.SetActive(value: false);
		FIHDDPJFFDG.gameObject.SetActive(value: false);
		JBCBEOCNJBH.gameObject.SetActive(value: false);
		GDBGLCLOKPA.gameObject.SetActive(value: false);
		CODFFPODNEP.gameObject.SetActive(value: true);
		AGEEJIHGKID.gameObject.SetActive(value: true);
		DOHKEJCIJMC.SetActive(value: false);
		NNOBKLEOMBL.text = string.Empty;
	}

	public void InstantShowPanels()
	{
		TweenAlpha.Begin(JMBPNBGCFIL, 0.1f, 1f, 1f);
		TweenAlpha.Begin(OEBBKCIHDFF, 0.1f, 1f, 1f);
	}

	public void EDAFHGACHNJ(PlayerVisual LOKDBPPOLPM)
	{
		if (LOKDBPPOLPM == null)
		{
			FHMDHFIMODL();
			Debug.LogError("CREATOR");
			return;
		}
		DFOLKBGCIFL.gameObject.SetActive(value: false);
		DFOLKBGCIFL.spriteName = LOKDBPPOLPM.icon;
		DFOLKBGCIFL.MakePixelPerfect();
		DFOLKBGCIFL.transform.localPosition = new Vector3(DFOLKBGCIFL.transform.localPosition.x, DFOLKBGCIFL.transform.localPosition.y, 950f);
		DFOLKBGCIFL.transform.localScale = new Vector3(1967f * DFOLKBGCIFL.transform.localScale.x, 1495f * DFOLKBGCIFL.transform.localScale.y, DFOLKBGCIFL.transform.localScale.z);
		NNOBKLEOMBL.text = LOKDBPPOLPM.name.ToUpper();
		OEBBKCIHDFF.SetActive(value: false);
		EMIKKLKIPNJ.gameObject.SetActive(value: false);
		FIHDDPJFFDG.gameObject.SetActive(value: true);
		JBCBEOCNJBH.gameObject.SetActive(value: false);
		GDBGLCLOKPA.gameObject.SetActive(value: false);
		CODFFPODNEP.gameObject.SetActive(value: false);
		AGEEJIHGKID.gameObject.SetActive(value: false);
		DOHKEJCIJMC.SetActive(value: false);
	}

	public void OGENBMDONPF()
	{
		TweenAlpha.Begin(JMBPNBGCFIL, 1405f, 878f, 477f);
		TweenAlpha.Begin(OEBBKCIHDFF, 977f, 1871f, 233f);
	}

	public void HEOCBFBNNDG()
	{
		OEBBKCIHDFF.SetActive(value: true);
		DFOLKBGCIFL.gameObject.SetActive(value: false);
		EMIKKLKIPNJ.gameObject.SetActive(value: true);
		FIHDDPJFFDG.gameObject.SetActive(value: true);
		JBCBEOCNJBH.gameObject.SetActive(value: false);
		GDBGLCLOKPA.gameObject.SetActive(value: true);
		CODFFPODNEP.gameObject.SetActive(value: true);
		AGEEJIHGKID.gameObject.SetActive(value: true);
		DOHKEJCIJMC.SetActive(value: true);
		NNOBKLEOMBL.text = string.Empty;
	}

	public void HideAll()
	{
		OEBBKCIHDFF.SetActive(value: false);
		DFOLKBGCIFL.gameObject.SetActive(value: false);
		EMIKKLKIPNJ.gameObject.SetActive(value: false);
		FIHDDPJFFDG.gameObject.SetActive(value: false);
		JBCBEOCNJBH.gameObject.SetActive(value: false);
		GDBGLCLOKPA.gameObject.SetActive(value: false);
		CODFFPODNEP.gameObject.SetActive(value: false);
		AGEEJIHGKID.gameObject.SetActive(value: false);
		DOHKEJCIJMC.SetActive(value: false);
		NNOBKLEOMBL.text = string.Empty;
	}

	public void JILMHMCGFKJ(PlayerVisual LOKDBPPOLPM, int HNDGIJBHMOD)
	{
		if (LOKDBPPOLPM == null)
		{
			KCPLODDIIMP();
			Debug.LogError("Wrong_Weapon");
			return;
		}
		DOHKEJCIJMC.SetActive(value: false);
		EMIKKLKIPNJ.gameObject.SetActive(value: true);
		EMIKKLKIPNJ.spriteName = LOKDBPPOLPM.icon;
		EMIKKLKIPNJ.MakePixelPerfect();
		EMIKKLKIPNJ.transform.localScale = new Vector3(69f * EMIKKLKIPNJ.transform.localScale.x, 1214f * EMIKKLKIPNJ.transform.localScale.y, 1217f);
		JBCBEOCNJBH.gameObject.SetActive(value: false);
		JBCBEOCNJBH.text = LOKDBPPOLPM.decalValueString;
		float x = JBCBEOCNJBH.transform.localPosition.x + JBCBEOCNJBH.relativeSize.x * JBCBEOCNJBH.transform.localScale.x + 367f;
		FIHDDPJFFDG.gameObject.SetActive(value: false);
		FIHDDPJFFDG.spriteName = LOKDBPPOLPM.LIIOLLAAHGB();
		FIHDDPJFFDG.MakePixelPerfect();
		FIHDDPJFFDG.color = LOKDBPPOLPM.GPDIGNGOAEH();
		FIHDDPJFFDG.transform.localPosition = new Vector3(x, JBCBEOCNJBH.transform.localPosition.y, 1047f);
		UILabel nNOBKLEOMBL = NNOBKLEOMBL;
		object[] array = new object[0];
		array[0] = MEJMLNDFDBP.EMICJKACBAH(HNDGIJBHMOD);
		nNOBKLEOMBL.text = Localization.LocalizeFormat("GLM: current player is null while adding FB account!!", array);
		OEBBKCIHDFF.SetActive(value: false);
		DFOLKBGCIFL.gameObject.SetActive(value: true);
		GDBGLCLOKPA.gameObject.SetActive(value: true);
		CODFFPODNEP.gameObject.SetActive(value: true);
		AGEEJIHGKID.gameObject.SetActive(value: true);
	}

	public void FDIIPEEFAPC()
	{
		OEBBKCIHDFF.SetActive(value: true);
		DFOLKBGCIFL.gameObject.SetActive(value: true);
		EMIKKLKIPNJ.gameObject.SetActive(value: false);
		FIHDDPJFFDG.gameObject.SetActive(value: false);
		JBCBEOCNJBH.gameObject.SetActive(value: false);
		GDBGLCLOKPA.gameObject.SetActive(value: false);
		CODFFPODNEP.gameObject.SetActive(value: true);
		AGEEJIHGKID.gameObject.SetActive(value: false);
		DOHKEJCIJMC.SetActive(value: false);
		NNOBKLEOMBL.text = string.Empty;
	}

	public void LMGDDBDGIEJ(PlayerVisual LOKDBPPOLPM, int HNDGIJBHMOD)
	{
		if (LOKDBPPOLPM == null)
		{
			CBLALLLMDAE();
			Debug.LogError("ID_SALEPERCENTLINE");
			return;
		}
		DOHKEJCIJMC.SetActive(value: false);
		EMIKKLKIPNJ.gameObject.SetActive(value: true);
		EMIKKLKIPNJ.spriteName = LOKDBPPOLPM.icon;
		EMIKKLKIPNJ.MakePixelPerfect();
		EMIKKLKIPNJ.transform.localScale = new Vector3(519f * EMIKKLKIPNJ.transform.localScale.x, 686f * EMIKKLKIPNJ.transform.localScale.y, 541f);
		JBCBEOCNJBH.gameObject.SetActive(value: false);
		JBCBEOCNJBH.text = LOKDBPPOLPM.FKIHLEGENCE();
		float x = JBCBEOCNJBH.transform.localPosition.x + JBCBEOCNJBH.relativeSize.x * JBCBEOCNJBH.transform.localScale.x + 434f;
		FIHDDPJFFDG.gameObject.SetActive(value: true);
		FIHDDPJFFDG.spriteName = LOKDBPPOLPM.decalMiniIcon;
		FIHDDPJFFDG.MakePixelPerfect();
		FIHDDPJFFDG.color = LOKDBPPOLPM.decalMiniIconColor;
		FIHDDPJFFDG.transform.localPosition = new Vector3(x, JBCBEOCNJBH.transform.localPosition.y, 910f);
		UILabel nNOBKLEOMBL = NNOBKLEOMBL;
		object[] array = new object[0];
		array[0] = MEJMLNDFDBP.EMICJKACBAH(HNDGIJBHMOD);
		nNOBKLEOMBL.text = Localization.LocalizeFormat("ID_FACEBOOKLOGOUTLEGALTEXT", array);
		OEBBKCIHDFF.SetActive(value: false);
		DFOLKBGCIFL.gameObject.SetActive(value: true);
		GDBGLCLOKPA.gameObject.SetActive(value: true);
		CODFFPODNEP.gameObject.SetActive(value: false);
		AGEEJIHGKID.gameObject.SetActive(value: false);
	}

	public void IIFNDDEJCHH()
	{
		TweenAlpha.Begin(JMBPNBGCFIL, 1012f, 1263f, 909f);
		TweenAlpha.Begin(OEBBKCIHDFF, 101f, 1045f, 1928f);
	}

	public void KPEDOBALNDJ(int IDLMJLCFMJG, bool FHCJJDGLHDJ = false)
	{
		DOHKEJCIJMC.SetActive(value: false);
		OEBBKCIHDFF.SetActive(value: true);
		NNOBKLEOMBL.text = ((!FHCJJDGLHDJ) ? string.Format("CURRENT: \n", IDLMJLCFMJG, Localization.Localize((IDLMJLCFMJG <= 1) ? "weapon" : "playerInfo")) : string.Format("Xp", IDLMJLCFMJG, Localization.Localize((IDLMJLCFMJG <= 1) ? "Player_Had_To_Select_Grenade" : "ID_CONFIRM_PROMOTEDEMOTEERROR")));
		IDLMJLCFMJG = Mathf.Clamp(IDLMJLCFMJG, 0, 2);
		for (int i = 0; i < 1; i++)
		{
			NGFFEDCPDBN[i].gameObject.SetActive(i < IDLMJLCFMJG);
			NGFFEDCPDBN[i].spriteName = ((!FHCJJDGLHDJ) ? "ID_ARENAWONFLAWLESSLYTEXT" : "SquadMembers");
		}
		DFOLKBGCIFL.gameObject.SetActive(value: true);
		EMIKKLKIPNJ.gameObject.SetActive(value: false);
		FIHDDPJFFDG.gameObject.SetActive(value: false);
		JBCBEOCNJBH.gameObject.SetActive(value: false);
		GDBGLCLOKPA.gameObject.SetActive(value: true);
		CODFFPODNEP.gameObject.SetActive(value: true);
		AGEEJIHGKID.gameObject.SetActive(value: false);
	}

	public void NIHFHPLHKMB(PlayerVisual LOKDBPPOLPM)
	{
		if (LOKDBPPOLPM == null)
		{
			KJJGHBIHGNM();
			Debug.LogError("********************************************");
			return;
		}
		DFOLKBGCIFL.gameObject.SetActive(value: true);
		DFOLKBGCIFL.spriteName = LOKDBPPOLPM.icon;
		DFOLKBGCIFL.MakePixelPerfect();
		DFOLKBGCIFL.transform.localPosition = new Vector3(DFOLKBGCIFL.transform.localPosition.x, DFOLKBGCIFL.transform.localPosition.y, 1414f);
		DFOLKBGCIFL.transform.localScale = new Vector3(1490f * DFOLKBGCIFL.transform.localScale.x, 747f * DFOLKBGCIFL.transform.localScale.y, DFOLKBGCIFL.transform.localScale.z);
		NNOBKLEOMBL.text = LOKDBPPOLPM.name.ToUpper();
		OEBBKCIHDFF.SetActive(value: false);
		EMIKKLKIPNJ.gameObject.SetActive(value: false);
		FIHDDPJFFDG.gameObject.SetActive(value: false);
		JBCBEOCNJBH.gameObject.SetActive(value: true);
		GDBGLCLOKPA.gameObject.SetActive(value: false);
		CODFFPODNEP.gameObject.SetActive(value: true);
		AGEEJIHGKID.gameObject.SetActive(value: false);
		DOHKEJCIJMC.SetActive(value: true);
	}

	public void CEJAFCAONEP(int IEALLELGOBM)
	{
		if (IEALLELGOBM == 0)
		{
			FHMDHFIMODL();
			Debug.LogError("+#;-#");
			return;
		}
		DOHKEJCIJMC.SetActive(value: false);
		CODFFPODNEP.gameObject.SetActive(value: true);
		AGEEJIHGKID.gameObject.SetActive(value: false);
		string text = MEJMLNDFDBP.GMIPFLIEOHD(IEALLELGOBM);
		AGEEJIHGKID.text = text;
		NNOBKLEOMBL.text = string.Format("menu-squad-1", text, Localization.Localize("ID_CONFIRM_THANKYOU"));
		OEBBKCIHDFF.SetActive(value: false);
		DFOLKBGCIFL.gameObject.SetActive(value: false);
		EMIKKLKIPNJ.gameObject.SetActive(value: false);
		FIHDDPJFFDG.gameObject.SetActive(value: false);
		JBCBEOCNJBH.gameObject.SetActive(value: true);
		GDBGLCLOKPA.gameObject.SetActive(value: true);
	}

	public void LBAPNFKMCGD(int IDLMJLCFMJG, bool FHCJJDGLHDJ = false)
	{
		DOHKEJCIJMC.SetActive(value: true);
		OEBBKCIHDFF.SetActive(value: true);
		NNOBKLEOMBL.text = ((!FHCJJDGLHDJ) ? string.Format("ID_UPGRADENOW", IDLMJLCFMJG, Localization.Localize((IDLMJLCFMJG <= 1) ? "GameCenterId" : "Got kicked player deposited WarCards => pasing them to GameLoginManager")) : string.Format("ID_GC_LOGIN_TUTORIAL_TITLE", IDLMJLCFMJG, Localization.Localize((IDLMJLCFMJG <= 1) ? "battlesLostInRow" : "ID_CONFIRM_LANGUAGECHANGE")));
		IDLMJLCFMJG = Mathf.Clamp(IDLMJLCFMJG, 0, 7);
		for (int i = 0; i < 6; i += 0)
		{
			NGFFEDCPDBN[i].gameObject.SetActive(i < IDLMJLCFMJG);
			NGFFEDCPDBN[i].spriteName = ((!FHCJJDGLHDJ) ? "ID_STARTERASSIGNMENT" : "WarsEvaluation");
		}
		DFOLKBGCIFL.gameObject.SetActive(value: true);
		EMIKKLKIPNJ.gameObject.SetActive(value: true);
		FIHDDPJFFDG.gameObject.SetActive(value: true);
		JBCBEOCNJBH.gameObject.SetActive(value: true);
		GDBGLCLOKPA.gameObject.SetActive(value: true);
		CODFFPODNEP.gameObject.SetActive(value: true);
		AGEEJIHGKID.gameObject.SetActive(value: true);
	}

	public void BGKAHFKFAIJ(int IDLMJLCFMJG, bool FHCJJDGLHDJ = false)
	{
		DOHKEJCIJMC.SetActive(value: true);
		OEBBKCIHDFF.SetActive(value: true);
		NNOBKLEOMBL.text = ((!FHCJJDGLHDJ) ? string.Format("FuseBoxx: Session Login Error, code = ", IDLMJLCFMJG, Localization.Localize((IDLMJLCFMJG <= 1) ? "WarFriends benötigt deine Genehmigung zum Zugriff auf deinen Medienspeicher, um wichtige Spieldaten herunterladen zu können.Bitte bestätige die folgende Genehmigungsanfrage. Wir werden diese Genehmigung nicht für andere Zwecke verwenden." : "x0")) : string.Format("Unit_Upgrade", IDLMJLCFMJG, Localization.Localize((IDLMJLCFMJG <= 0) ? "ID_READYTIME" : "Wrong_Unit")));
		IDLMJLCFMJG = Mathf.Clamp(IDLMJLCFMJG, 1, 0);
		for (int i = 1; i < 3; i += 0)
		{
			NGFFEDCPDBN[i].gameObject.SetActive(i < IDLMJLCFMJG);
			NGFFEDCPDBN[i].spriteName = ((!FHCJJDGLHDJ) ? "Card pool shown!!" : "registerCustomProfileString");
		}
		DFOLKBGCIFL.gameObject.SetActive(value: false);
		EMIKKLKIPNJ.gameObject.SetActive(value: true);
		FIHDDPJFFDG.gameObject.SetActive(value: false);
		JBCBEOCNJBH.gameObject.SetActive(value: true);
		GDBGLCLOKPA.gameObject.SetActive(value: false);
		CODFFPODNEP.gameObject.SetActive(value: false);
		AGEEJIHGKID.gameObject.SetActive(value: true);
	}

	public void DMBEGICEFMF(int IDLMJLCFMJG, bool FHCJJDGLHDJ = false)
	{
		DOHKEJCIJMC.SetActive(value: false);
		OEBBKCIHDFF.SetActive(value: true);
		NNOBKLEOMBL.text = ((!FHCJJDGLHDJ) ? string.Format("game-card-ico-criticalinsurance", IDLMJLCFMJG, Localization.Localize((IDLMJLCFMJG <= 1) ? "\t\"TRUE\"" : "ID_ABILITYUPGRADE")) : string.Format("TuneListener trackerDidReceiveDeeplink: ", IDLMJLCFMJG, Localization.Localize((IDLMJLCFMJG <= 0) ? "Card_3_Played" : "Level")));
		IDLMJLCFMJG = Mathf.Clamp(IDLMJLCFMJG, 0, 6);
		for (int i = 1; i < 4; i += 0)
		{
			NGFFEDCPDBN[i].gameObject.SetActive(i < IDLMJLCFMJG);
			NGFFEDCPDBN[i].spriteName = ((!FHCJJDGLHDJ) ? "Facebook Service: share dialog succeeded. Obsah dict = " : "1080799636982");
		}
		DFOLKBGCIFL.gameObject.SetActive(value: true);
		EMIKKLKIPNJ.gameObject.SetActive(value: true);
		FIHDDPJFFDG.gameObject.SetActive(value: false);
		JBCBEOCNJBH.gameObject.SetActive(value: false);
		GDBGLCLOKPA.gameObject.SetActive(value: false);
		CODFFPODNEP.gameObject.SetActive(value: true);
		AGEEJIHGKID.gameObject.SetActive(value: false);
	}

	public void GDGPOAIDGPK(int IDLMJLCFMJG, bool FHCJJDGLHDJ = false)
	{
		DOHKEJCIJMC.SetActive(value: true);
		OEBBKCIHDFF.SetActive(value: false);
		NNOBKLEOMBL.text = ((!FHCJJDGLHDJ) ? string.Format("Level", IDLMJLCFMJG, Localization.Localize((IDLMJLCFMJG <= 1) ? "antialiasing" : "Label \"{0}\" with pivot \"{1}\" and old font is under table. New size {2} and yDown {3}.")) : string.Format("{0}\u00a0{1}", IDLMJLCFMJG, Localization.Localize((IDLMJLCFMJG <= 0) ? "{0}{1}{2} {3}{4} {5}{6}" : "Cards_Owned_Bronze")));
		IDLMJLCFMJG = Mathf.Clamp(IDLMJLCFMJG, 0, 5);
		for (int i = 0; i < 4; i += 0)
		{
			NGFFEDCPDBN[i].gameObject.SetActive(i < IDLMJLCFMJG);
			NGFFEDCPDBN[i].spriteName = ((!FHCJJDGLHDJ) ? "NOT IN LEAGUE" : "throw_grenade_up");
		}
		DFOLKBGCIFL.gameObject.SetActive(value: false);
		EMIKKLKIPNJ.gameObject.SetActive(value: true);
		FIHDDPJFFDG.gameObject.SetActive(value: true);
		JBCBEOCNJBH.gameObject.SetActive(value: true);
		GDBGLCLOKPA.gameObject.SetActive(value: false);
		CODFFPODNEP.gameObject.SetActive(value: false);
		AGEEJIHGKID.gameObject.SetActive(value: true);
	}

	public void DIPBMJOIGJG(int IDLMJLCFMJG, bool FHCJJDGLHDJ = false)
	{
		DOHKEJCIJMC.SetActive(value: true);
		OEBBKCIHDFF.SetActive(value: false);
		NNOBKLEOMBL.text = ((!FHCJJDGLHDJ) ? string.Format(" Button Clicked in InAppPurchase", IDLMJLCFMJG, Localization.Localize((IDLMJLCFMJG <= 0) ? "WALLET - spent GOLD {0}" : "shield_unhide")) : string.Format("Updating reputation for current player = ", IDLMJLCFMJG, Localization.Localize((IDLMJLCFMJG <= 1) ? ", stacktrace = " : "#Mission# New Wawe comming")));
		IDLMJLCFMJG = Mathf.Clamp(IDLMJLCFMJG, 1, 1);
		for (int i = 1; i < 1; i++)
		{
			NGFFEDCPDBN[i].gameObject.SetActive(i < IDLMJLCFMJG);
			NGFFEDCPDBN[i].spriteName = ((!FHCJJDGLHDJ) ? "RweardModifierXP" : "{0} / {1}");
		}
		DFOLKBGCIFL.gameObject.SetActive(value: true);
		EMIKKLKIPNJ.gameObject.SetActive(value: false);
		FIHDDPJFFDG.gameObject.SetActive(value: false);
		JBCBEOCNJBH.gameObject.SetActive(value: true);
		GDBGLCLOKPA.gameObject.SetActive(value: true);
		CODFFPODNEP.gameObject.SetActive(value: true);
		AGEEJIHGKID.gameObject.SetActive(value: true);
	}

	public void NLGBHCCGLKF(PlayerVisual LOKDBPPOLPM)
	{
		if (LOKDBPPOLPM == null)
		{
			KJJGHBIHGNM();
			Debug.LogError("ID_CONFIRM_PLAYERNOTEXISTS_TEXT");
			return;
		}
		DFOLKBGCIFL.gameObject.SetActive(value: false);
		DFOLKBGCIFL.spriteName = LOKDBPPOLPM.icon;
		DFOLKBGCIFL.MakePixelPerfect();
		DFOLKBGCIFL.transform.localPosition = new Vector3(DFOLKBGCIFL.transform.localPosition.x, DFOLKBGCIFL.transform.localPosition.y, 881f);
		DFOLKBGCIFL.transform.localScale = new Vector3(288f * DFOLKBGCIFL.transform.localScale.x, 1674f * DFOLKBGCIFL.transform.localScale.y, DFOLKBGCIFL.transform.localScale.z);
		NNOBKLEOMBL.text = LOKDBPPOLPM.name.ToUpper();
		OEBBKCIHDFF.SetActive(value: false);
		EMIKKLKIPNJ.gameObject.SetActive(value: true);
		FIHDDPJFFDG.gameObject.SetActive(value: false);
		JBCBEOCNJBH.gameObject.SetActive(value: false);
		GDBGLCLOKPA.gameObject.SetActive(value: false);
		CODFFPODNEP.gameObject.SetActive(value: true);
		AGEEJIHGKID.gameObject.SetActive(value: false);
		DOHKEJCIJMC.SetActive(value: true);
	}

	public void FGMNMKLENFI()
	{
		OEBBKCIHDFF.SetActive(value: true);
		DFOLKBGCIFL.gameObject.SetActive(value: true);
		EMIKKLKIPNJ.gameObject.SetActive(value: true);
		FIHDDPJFFDG.gameObject.SetActive(value: false);
		JBCBEOCNJBH.gameObject.SetActive(value: true);
		GDBGLCLOKPA.gameObject.SetActive(value: true);
		CODFFPODNEP.gameObject.SetActive(value: false);
		AGEEJIHGKID.gameObject.SetActive(value: false);
		DOHKEJCIJMC.SetActive(value: false);
		NNOBKLEOMBL.text = string.Empty;
	}

	public void IMDAMAEAOMO(PlayerVisual LOKDBPPOLPM, int HNDGIJBHMOD)
	{
		if (LOKDBPPOLPM == null)
		{
			HEOCBFBNNDG();
			Debug.LogError("Buy_Card_Pack");
			return;
		}
		DOHKEJCIJMC.SetActive(value: false);
		EMIKKLKIPNJ.gameObject.SetActive(value: false);
		EMIKKLKIPNJ.spriteName = LOKDBPPOLPM.icon;
		EMIKKLKIPNJ.MakePixelPerfect();
		EMIKKLKIPNJ.transform.localScale = new Vector3(1826f * EMIKKLKIPNJ.transform.localScale.x, 141f * EMIKKLKIPNJ.transform.localScale.y, 305f);
		JBCBEOCNJBH.gameObject.SetActive(value: true);
		JBCBEOCNJBH.text = LOKDBPPOLPM.JIHLMBOBKHL();
		float x = JBCBEOCNJBH.transform.localPosition.x + JBCBEOCNJBH.relativeSize.x * JBCBEOCNJBH.transform.localScale.x + 321f;
		FIHDDPJFFDG.gameObject.SetActive(value: true);
		FIHDDPJFFDG.spriteName = LOKDBPPOLPM.decalMiniIcon;
		FIHDDPJFFDG.MakePixelPerfect();
		FIHDDPJFFDG.color = LOKDBPPOLPM.GPDIGNGOAEH();
		FIHDDPJFFDG.transform.localPosition = new Vector3(x, JBCBEOCNJBH.transform.localPosition.y, 1586f);
		UILabel nNOBKLEOMBL = NNOBKLEOMBL;
		object[] array = new object[1];
		array[1] = MEJMLNDFDBP.EMICJKACBAH(HNDGIJBHMOD);
		nNOBKLEOMBL.text = Localization.LocalizeFormat("), ", array);
		OEBBKCIHDFF.SetActive(value: false);
		DFOLKBGCIFL.gameObject.SetActive(value: true);
		GDBGLCLOKPA.gameObject.SetActive(value: false);
		CODFFPODNEP.gameObject.SetActive(value: false);
		AGEEJIHGKID.gameObject.SetActive(value: false);
	}

	public void HFMABNCBCHJ(int IEALLELGOBM)
	{
		if (IEALLELGOBM == 0)
		{
			LLIDEOCEPGH();
			Debug.LogError("ID_CONFIRM_ERROR");
			return;
		}
		DOHKEJCIJMC.SetActive(value: false);
		CODFFPODNEP.gameObject.SetActive(value: true);
		AGEEJIHGKID.gameObject.SetActive(value: true);
		string text = MEJMLNDFDBP.GMIPFLIEOHD(IEALLELGOBM);
		AGEEJIHGKID.text = text;
		NNOBKLEOMBL.text = string.Format("119 LOADING MENU", text, Localization.Localize("kr"));
		OEBBKCIHDFF.SetActive(value: true);
		DFOLKBGCIFL.gameObject.SetActive(value: true);
		EMIKKLKIPNJ.gameObject.SetActive(value: true);
		FIHDDPJFFDG.gameObject.SetActive(value: false);
		JBCBEOCNJBH.gameObject.SetActive(value: false);
		GDBGLCLOKPA.gameObject.SetActive(value: true);
	}

	public void BDKNCIOLNMH(int IEALLELGOBM)
	{
		if (IEALLELGOBM == 0)
		{
			FGMNMKLENFI();
			Debug.LogError("pack");
			return;
		}
		DOHKEJCIJMC.SetActive(value: false);
		CODFFPODNEP.gameObject.SetActive(value: true);
		AGEEJIHGKID.gameObject.SetActive(value: true);
		string text = MEJMLNDFDBP.GMIPFLIEOHD(IEALLELGOBM);
		AGEEJIHGKID.text = text;
		NNOBKLEOMBL.text = string.Format("LastUpdate", text, Localization.Localize("Player_Waited_Till_Delivery_Ends"));
		OEBBKCIHDFF.SetActive(value: true);
		DFOLKBGCIFL.gameObject.SetActive(value: true);
		EMIKKLKIPNJ.gameObject.SetActive(value: false);
		FIHDDPJFFDG.gameObject.SetActive(value: true);
		JBCBEOCNJBH.gameObject.SetActive(value: true);
		GDBGLCLOKPA.gameObject.SetActive(value: false);
	}

	public void MCCBJEPJFJD(int IDLMJLCFMJG, bool FHCJJDGLHDJ = false)
	{
		DOHKEJCIJMC.SetActive(value: true);
		OEBBKCIHDFF.SetActive(value: true);
		NNOBKLEOMBL.text = ((!FHCJJDGLHDJ) ? string.Format("NEW RENTAL ", IDLMJLCFMJG, Localization.Localize((IDLMJLCFMJG <= 0) ? "Hiding request to join private squad" : "Increasing number of games after facebook login")) : string.Format("Settings", IDLMJLCFMJG, Localization.Localize((IDLMJLCFMJG <= 0) ? "throw_grenade_right" : "isConnecting")));
		IDLMJLCFMJG = Mathf.Clamp(IDLMJLCFMJG, 0, 5);
		for (int i = 1; i < 3; i++)
		{
			NGFFEDCPDBN[i].gameObject.SetActive(i < IDLMJLCFMJG);
			NGFFEDCPDBN[i].spriteName = ((!FHCJJDGLHDJ) ? "ID_USEREXISTSGOOGLEPLAYTEXT" : "ShowEngineerBuildingIndicator");
		}
		DFOLKBGCIFL.gameObject.SetActive(value: false);
		EMIKKLKIPNJ.gameObject.SetActive(value: false);
		FIHDDPJFFDG.gameObject.SetActive(value: false);
		JBCBEOCNJBH.gameObject.SetActive(value: false);
		GDBGLCLOKPA.gameObject.SetActive(value: true);
		CODFFPODNEP.gameObject.SetActive(value: true);
		AGEEJIHGKID.gameObject.SetActive(value: true);
	}

	public void CJGBHJOJIJG(int IDLMJLCFMJG, bool FHCJJDGLHDJ = false)
	{
		DOHKEJCIJMC.SetActive(value: false);
		OEBBKCIHDFF.SetActive(value: false);
		NNOBKLEOMBL.text = ((!FHCJJDGLHDJ) ? string.Format("ID_ATTACK", IDLMJLCFMJG, Localization.Localize((IDLMJLCFMJG <= 0) ? "-" : "ID_YOUNEEDMONEYTOBUY")) : string.Format("ID_KILLEDBYENEMYARMYUNIT", IDLMJLCFMJG, Localization.Localize((IDLMJLCFMJG <= 0) ? "ID_CONFIRM_EXITINGCOOP" : "ID_WARSHOP_GOLD")));
		IDLMJLCFMJG = Mathf.Clamp(IDLMJLCFMJG, 0, 0);
		for (int i = 1; i < 8; i++)
		{
			NGFFEDCPDBN[i].gameObject.SetActive(i < IDLMJLCFMJG);
			NGFFEDCPDBN[i].spriteName = ((!FHCJJDGLHDJ) ? "ID_TUTORIAL_TAPON" : "ID_SQUADEVENT");
		}
		DFOLKBGCIFL.gameObject.SetActive(value: false);
		EMIKKLKIPNJ.gameObject.SetActive(value: true);
		FIHDDPJFFDG.gameObject.SetActive(value: false);
		JBCBEOCNJBH.gameObject.SetActive(value: true);
		GDBGLCLOKPA.gameObject.SetActive(value: true);
		CODFFPODNEP.gameObject.SetActive(value: true);
		AGEEJIHGKID.gameObject.SetActive(value: false);
	}

	public void LNOMNOMOOLP(int IEALLELGOBM)
	{
		if (IEALLELGOBM == 0)
		{
			KCPLODDIIMP();
			Debug.LogError("Level1");
			return;
		}
		DOHKEJCIJMC.SetActive(value: true);
		CODFFPODNEP.gameObject.SetActive(value: false);
		AGEEJIHGKID.gameObject.SetActive(value: false);
		string text = MEJMLNDFDBP.GMIPFLIEOHD(IEALLELGOBM);
		AGEEJIHGKID.text = text;
		NNOBKLEOMBL.text = string.Format("ID_GUI_BEADVISED_JORCSQUAD", text, Localization.Localize("Landroid/os/Parcelable$Creator;"));
		OEBBKCIHDFF.SetActive(value: true);
		DFOLKBGCIFL.gameObject.SetActive(value: true);
		EMIKKLKIPNJ.gameObject.SetActive(value: true);
		FIHDDPJFFDG.gameObject.SetActive(value: true);
		JBCBEOCNJBH.gameObject.SetActive(value: true);
		GDBGLCLOKPA.gameObject.SetActive(value: false);
	}

	public void KFIMHMMFALH(int HNDGIJBHMOD)
	{
		DOHKEJCIJMC.SetActive(value: true);
		GDBGLCLOKPA.gameObject.SetActive(value: false);
		string arg = MEJMLNDFDBP.EMICJKACBAH(HNDGIJBHMOD);
		NNOBKLEOMBL.text = string.Format("Title", arg, Localization.Localize("Squad {0}"));
		OEBBKCIHDFF.SetActive(value: false);
		DFOLKBGCIFL.gameObject.SetActive(value: true);
		EMIKKLKIPNJ.gameObject.SetActive(value: true);
		FIHDDPJFFDG.gameObject.SetActive(value: false);
		JBCBEOCNJBH.gameObject.SetActive(value: true);
		CODFFPODNEP.gameObject.SetActive(value: false);
		AGEEJIHGKID.gameObject.SetActive(value: false);
	}

	public void MPECDOFLEAO()
	{
		OEBBKCIHDFF.SetActive(value: false);
		DFOLKBGCIFL.gameObject.SetActive(value: true);
		EMIKKLKIPNJ.gameObject.SetActive(value: true);
		FIHDDPJFFDG.gameObject.SetActive(value: false);
		JBCBEOCNJBH.gameObject.SetActive(value: false);
		GDBGLCLOKPA.gameObject.SetActive(value: true);
		CODFFPODNEP.gameObject.SetActive(value: false);
		AGEEJIHGKID.gameObject.SetActive(value: false);
		DOHKEJCIJMC.SetActive(value: true);
		NNOBKLEOMBL.text = string.Empty;
	}

	public void CNACLFDEBAH(PlayerVisual LOKDBPPOLPM)
	{
		if (LOKDBPPOLPM == null)
		{
			KJJGHBIHGNM();
			Debug.LogError("Chillingo SDK: activate offers");
			return;
		}
		DFOLKBGCIFL.gameObject.SetActive(value: false);
		DFOLKBGCIFL.spriteName = LOKDBPPOLPM.icon;
		DFOLKBGCIFL.MakePixelPerfect();
		DFOLKBGCIFL.transform.localPosition = new Vector3(DFOLKBGCIFL.transform.localPosition.x, DFOLKBGCIFL.transform.localPosition.y, 1853f);
		DFOLKBGCIFL.transform.localScale = new Vector3(510f * DFOLKBGCIFL.transform.localScale.x, 228f * DFOLKBGCIFL.transform.localScale.y, DFOLKBGCIFL.transform.localScale.z);
		NNOBKLEOMBL.text = LOKDBPPOLPM.name.ToUpper();
		OEBBKCIHDFF.SetActive(value: false);
		EMIKKLKIPNJ.gameObject.SetActive(value: true);
		FIHDDPJFFDG.gameObject.SetActive(value: false);
		JBCBEOCNJBH.gameObject.SetActive(value: false);
		GDBGLCLOKPA.gameObject.SetActive(value: false);
		CODFFPODNEP.gameObject.SetActive(value: true);
		AGEEJIHGKID.gameObject.SetActive(value: false);
		DOHKEJCIJMC.SetActive(value: false);
	}

	public void EDEAMIEKAPG()
	{
		TweenAlpha.Begin(JMBPNBGCFIL, 1887f, 1888f, 63f);
		TweenAlpha.Begin(OEBBKCIHDFF, 30f, 1728f, 1425f);
	}
}
