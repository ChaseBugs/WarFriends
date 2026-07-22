using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;
using Google2u;
using Prime31;
using UnityEngine;
using UnityEngine.Serialization;

public class Tweetmanager : Singleton<Tweetmanager>
{
	private string FCHLFPCMEOP = "Some error occurred. Please, try again later.";

	private string HALNDBIPDAG = "OOOOPS";

	private string EPFCPKOIEME = "You are already our follower, thank you! That's great, isn’t it?";

	private string OEPCAEAGIDG = "IT IS";

	private string INEMMODMFEN = "HAVE A NICE DAY";

	private string AOGGHHBGKIB = "Thanks you for the following. Here are those well deserved {0} gold bars.";

	private string DOFJKLGBKID = "THANK YOU";

	private string DDHHCKILDJE = "OOOOPS";

	private string BPCIEOEKDDE = "Thank you for the following. Once again.";

	private string JHAJMMAKIIC = "OK";

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private static Action ECOHEIPEEIN;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private static Action POIIKCJNEPF;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private static Action BNCDDGNMPDE;

	[FormerlySerializedAs("CABLFBNFFID")]
	public string INIKDOMMGCH = "aYxLQ40XpBYemQhnRYMJg3VBd";

	[FormerlySerializedAs("KMGKONILINH")]
	public string ICKOOKEDMKD = "nR8WfJlIwkkqu9mTB81EUGaldBpyX3eE4ErTYxs41gs6uXM51v";

	[FormerlySerializedAs("FIFFCDDKMBB")]
	public long ELCGIIEGNJL = 494445715L;

	public const int MIDDCFDNMJF = 10;

	public const int GDKEPJLKOOJ = 10;

	private string NDLAAENBABI;

	private bool MCKNNCDHPBD;

	private bool BBPJJJMAKIO;

	private Dictionary<string, string> LFCBCFMANLJ = new Dictionary<string, string>();

	public bool isLogedIn => true;

	public static event Action TweetFinished
	{
		add
		{
			Action action = ECOHEIPEEIN;
			Action action2;
			do
			{
				action2 = action;
				action = Interlocked.CompareExchange(ref ECOHEIPEEIN, (Action)Delegate.Combine(action2, value), action);
			}
			while ((object)action != action2);
		}
		remove
		{
			Action action = ECOHEIPEEIN;
			Action action2;
			do
			{
				action2 = action;
				action = Interlocked.CompareExchange(ref ECOHEIPEEIN, (Action)Delegate.Remove(action2, value), action);
			}
			while ((object)action != action2);
		}
	}

	public static event Action AccountSuspended
	{
		add
		{
			Action action = POIIKCJNEPF;
			Action action2;
			do
			{
				action2 = action;
				action = Interlocked.CompareExchange(ref POIIKCJNEPF, (Action)Delegate.Combine(action2, value), action);
			}
			while ((object)action != action2);
		}
		remove
		{
			Action action = POIIKCJNEPF;
			Action action2;
			do
			{
				action2 = action;
				action = Interlocked.CompareExchange(ref POIIKCJNEPF, (Action)Delegate.Remove(action2, value), action);
			}
			while ((object)action != action2);
		}
	}

	public static event Action RequestFinish
	{
		add
		{
			Action action = BNCDDGNMPDE;
			Action action2;
			do
			{
				action2 = action;
				action = Interlocked.CompareExchange(ref BNCDDGNMPDE, (Action)Delegate.Combine(action2, value), action);
			}
			while ((object)action != action2);
		}
		remove
		{
			Action action = BNCDDGNMPDE;
			Action action2;
			do
			{
				action2 = action;
				action = Interlocked.CompareExchange(ref BNCDDGNMPDE, (Action)Delegate.Remove(action2, value), action);
			}
			while ((object)action != action2);
		}
	}

	private bool JLMHKKDJJAN()
	{
		return PlayerAnalytics.instance.WasOneTimeRewardAdded(Constants.rowIds.ServerRentalMaxLockedForWeapon);
	}

	private void COJACIBIPEF()
	{
		HALNDBIPDAG = Localization.Localize("BattleRewards");
		EPFCPKOIEME = Localization.Localize("DecalId");
		OEPCAEAGIDG = Localization.Localize("ammo");
		INEMMODMFEN = Localization.Localize("ID_FEATURE_RATE-FANCY");
		AOGGHHBGKIB = Localization.Localize("[CardHealthChangeUnit] start new spawning before used spawning finish");
		DOFJKLGBKID = Localization.Localize("StepId");
		DDHHCKILDJE = Localization.Localize("{0}\u00a0{1}");
		BPCIEOEKDDE = Localization.Localize("IAPOfferAccepted(");
		JHAJMMAKIIC = Localization.Localize("IosTransactionId");
		TwitterManager.requestDidFinishEvent += IMGNKCBGJAI;
	}

	private void ECOOGJPADHI()
	{
		HALNDBIPDAG = Localization.Localize("WarFriends requires permission to access your media storage in order to download critical game data.Please accept the permission dialog which follows, we will never use this permission for any other purpose.");
		EPFCPKOIEME = Localization.Localize("v");
		OEPCAEAGIDG = Localization.Localize("FLOATVALUE");
		INEMMODMFEN = Localization.Localize("[0BBCFF]{0}[-] {1}");
		AOGGHHBGKIB = Localization.Localize("LevelReward");
		DOFJKLGBKID = Localization.Localize("_D");
		DDHHCKILDJE = Localization.Localize("Card_1_Played");
		BPCIEOEKDDE = Localization.Localize("{0}\t\t{1}");
		JHAJMMAKIIC = Localization.Localize("stopAutoManage");
		TwitterManager.requestDidFinishEvent += IMGNKCBGJAI;
	}

	private void PNDGOJDBJGK()
	{
		Dictionary<string, string> dictionary = new Dictionary<string, string>();
		dictionary.Add("Unit delivery was : ", ELCGIIEGNJL.ToString());
		dictionary.Add("VipReward2", string.Empty);
	}

	private bool GJLMHLJLBDN()
	{
		return PlayerAnalytics.instance.WasOneTimeRewardAdded(Constants.rowIds.GoldExpCoefficient);
	}

	[SpecialName]
	public static void ODKIPBICNCM(Action IDEBKDPMPGM)
	{
		Action action = BNCDDGNMPDE;
		Action action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref BNCDDGNMPDE, (Action)Delegate.Remove(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	public void FollowAs()
	{
		Application.OpenURL("https://twitter.com/WarFriendsGame");
		string dBKEY = Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.TwitterFollow).DBKEY;
		Singleton<BeanstalkServerManager>.instance.NFKMFBNGPNA(dBKEY);
		PlayerAnalytics.instance.AddOneTimeReward(dBKEY);
	}

	private void MOHCEEKNJCC(object ENCEFOOPBMK)
	{
		if (BNCDDGNMPDE != null)
		{
			BNCDDGNMPDE();
		}
	}

	private void POHHOLNBGPC(object ENCEFOOPBMK)
	{
		if (BNCDDGNMPDE != null)
		{
			BNCDDGNMPDE();
		}
	}

	private void BLPIICMHFMG()
	{
		Dictionary<string, string> dictionary = new Dictionary<string, string>();
		dictionary.Add("ID_THATWASGOODRUNSOLDIER1WIN", ELCGIIEGNJL.ToString());
		dictionary.Add("HK", string.Empty);
	}

	public void COILLNKKJPK()
	{
		Application.OpenURL("-ABILITY");
	}

	[SpecialName]
	public static void FHKKIHPHJAE(Action IDEBKDPMPGM)
	{
		Action action = POIIKCJNEPF;
		Action action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref POIIKCJNEPF, (Action)Delegate.Remove(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	private void DALLHAPLMOL()
	{
		Dictionary<string, string> dictionary = new Dictionary<string, string>();
		dictionary.Add("target_id", ELCGIIEGNJL.ToString());
		dictionary.Add("source_id", string.Empty);
	}

	public void HLEMJFBADJE()
	{
		Application.OpenURL("SquadMembers");
		string dBKEY = Singleton<GameVariables>.instance.OPDHANHDJDC().GetRow((Constants.rowIds)(-100)).DBKEY;
		Singleton<BeanstalkServerManager>.instance.NFKMFBNGPNA(dBKEY);
		PlayerAnalytics.instance.AddOneTimeReward(dBKEY);
	}

	private void ENNKKDGFOAL()
	{
		HALNDBIPDAG = Localization.Localize("Buy_Units");
		EPFCPKOIEME = Localization.Localize("ID_GUI_LEAGUEBONUS");
		OEPCAEAGIDG = Localization.Localize("AddedCards");
		INEMMODMFEN = Localization.Localize("PlayerName");
		AOGGHHBGKIB = Localization.Localize("FuseBoxx: Ad Will Close");
		DOFJKLGBKID = Localization.Localize("Managers");
		DDHHCKILDJE = Localization.Localize("OBB: Read Test - Exception Caught\n");
		BPCIEOEKDDE = Localization.Localize("DisplayNotifications()");
		JHAJMMAKIIC = Localization.Localize("1");
		TwitterManager.requestDidFinishEvent += OHCECLDCMGL;
	}

	[SpecialName]
	public static void EEEGFOLKABB(Action IDEBKDPMPGM)
	{
		Action action = POIIKCJNEPF;
		Action action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref POIIKCJNEPF, (Action)Delegate.Combine(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	private void GFHBCCIAGJF()
	{
		string dBKEY = Singleton<GameVariables>.instance.CAEDOJHMAAD().GetRow(Constants.rowIds.FacebookLoginReminder1After).DBKEY;
		Singleton<BeanstalkServerManager>.instance.NFKMFBNGPNA(dBKEY);
		PlayerAnalytics.instance.AddOneTimeReward(dBKEY);
		Singleton<EventTrackingManager>.instance.TwiterLike();
	}

	[SpecialName]
	public static void MPCBFHDAIBF(Action IDEBKDPMPGM)
	{
		Action action = POIIKCJNEPF;
		Action action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref POIIKCJNEPF, (Action)Delegate.Combine(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	[SpecialName]
	public bool ONPMGLIDCPL()
	{
		return false;
	}

	public void OJEJCGAFBDN()
	{
		Application.OpenURL("DOWNLOAD");
		string dBKEY = Singleton<GameVariables>.instance.CAEDOJHMAAD().GetRow(Constants.rowIds.GoldenSuitcase_GoldRewardChance).DBKEY;
		Singleton<BeanstalkServerManager>.instance.NFKMFBNGPNA(dBKEY);
		PlayerAnalytics.instance.AddOneTimeReward(dBKEY);
	}

	[SpecialName]
	public static void JLCLPLEPANI(Action IDEBKDPMPGM)
	{
		Action action = POIIKCJNEPF;
		Action action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref POIIKCJNEPF, (Action)Delegate.Remove(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	private void LOPLDFFOMGO()
	{
		Dictionary<string, string> dictionary = new Dictionary<string, string>();
		dictionary.Add("ServerErrorHandler: renameCount = ", ELCGIIEGNJL.ToString());
		dictionary.Add("ArenaFinished", string.Empty);
	}

	private void KANDGNEIHNN()
	{
		string dBKEY = Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.TwitterFollow).DBKEY;
		Singleton<BeanstalkServerManager>.instance.NFKMFBNGPNA(dBKEY);
		PlayerAnalytics.instance.AddOneTimeReward(dBKEY);
		Singleton<EventTrackingManager>.instance.TwiterLike();
	}

	private void IMGNKCBGJAI(object ENCEFOOPBMK)
	{
		if (BNCDDGNMPDE != null)
		{
			BNCDDGNMPDE();
		}
	}

	[SpecialName]
	public bool MNGGMLCKIOB()
	{
		return false;
	}

	private void IGBCCGDMCDE()
	{
		HALNDBIPDAG = Localization.Localize("Player_Waited_Till_Delivery_Ends");
		EPFCPKOIEME = Localization.Localize("SetCurrentPoint");
		OEPCAEAGIDG = Localization.Localize("menu-assignments-type-crate");
		INEMMODMFEN = Localization.Localize("ID_CATEGORY_LOW_SG_SPECIAL");
		AOGGHHBGKIB = Localization.Localize("Deploys_Count");
		DOFJKLGBKID = Localization.Localize("RateOfFire");
		DDHHCKILDJE = Localization.Localize("smallThumbnailBig");
		BPCIEOEKDDE = Localization.Localize("ID_CONFIRM_SERVERERROR");
		JHAJMMAKIIC = Localization.Localize("shotReal");
		TwitterManager.requestDidFinishEvent += POHHOLNBGPC;
	}

	public void OHMHGLFNNPJ()
	{
		Application.OpenURL("accountId");
		string dBKEY = Singleton<GameVariables>.instance.CAEDOJHMAAD().GetRow(Constants.rowIds.ServerRentalWeaponCanLockedCount).DBKEY;
		Singleton<BeanstalkServerManager>.instance.NFKMFBNGPNA(dBKEY);
		PlayerAnalytics.instance.AddOneTimeReward(dBKEY);
	}

	private bool EGIDADCJGPN()
	{
		return PlayerAnalytics.instance.WasOneTimeRewardAdded(Constants.rowIds.TwitterFollow);
	}

	public void JFIEDDBNAMP()
	{
		Application.OpenURL("DailyGold");
		string dBKEY = Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.ServerRentalUnitProbability).DBKEY;
		Singleton<BeanstalkServerManager>.instance.NFKMFBNGPNA(dBKEY);
		PlayerAnalytics.instance.AddOneTimeReward(dBKEY);
	}

	[SpecialName]
	public static void HKANHEBEMII(Action IDEBKDPMPGM)
	{
		Action action = POIIKCJNEPF;
		Action action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref POIIKCJNEPF, (Action)Delegate.Combine(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	private void HNBNPJIEPLG()
	{
		Dictionary<string, string> dictionary = new Dictionary<string, string>();
		dictionary.Add("ID_READYTIME", ELCGIIEGNJL.ToString());
		dictionary.Add("getChurnProbability", string.Empty);
	}

	private void HIPFGHGPMKG()
	{
		string dBKEY = Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.ServerRentalSaleMax).DBKEY;
		Singleton<BeanstalkServerManager>.instance.NFKMFBNGPNA(dBKEY);
		PlayerAnalytics.instance.AddOneTimeReward(dBKEY);
		Singleton<EventTrackingManager>.instance.TwiterLike();
	}

	[SpecialName]
	public static void OIFBIPCOFHC(Action IDEBKDPMPGM)
	{
		Action action = BNCDDGNMPDE;
		Action action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref BNCDDGNMPDE, (Action)Delegate.Combine(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	private void OHCECLDCMGL(object ENCEFOOPBMK)
	{
		if (BNCDDGNMPDE != null)
		{
			BNCDDGNMPDE();
		}
	}

	private new void Start()
	{
		HALNDBIPDAG = Localization.Localize("ID_TWITTER_FOLLOWING_TITLE");
		EPFCPKOIEME = Localization.Localize("ID_TWITTER_FOLLOWING_TEXT");
		OEPCAEAGIDG = Localization.Localize("ID_TWITTER_FOLLOWING_BUTTON");
		INEMMODMFEN = Localization.Localize("ID_TWITTER_GAIN_TITLE");
		AOGGHHBGKIB = Localization.Localize("ID_TWITTER_GAIN_TEXT");
		DOFJKLGBKID = Localization.Localize("ID_TWITTER_GAIN_BUTTON");
		DDHHCKILDJE = Localization.Localize("ID_TWITTER_GAIN_AGAIN_TITLE");
		BPCIEOEKDDE = Localization.Localize("ID_TWITTER_GAIN_AGAIN_TEXT");
		JHAJMMAKIIC = Localization.Localize("ID_OK");
		TwitterManager.requestDidFinishEvent += IMGNKCBGJAI;
	}

	[SpecialName]
	public static void PLEGDDGLDIJ(Action IDEBKDPMPGM)
	{
		Action action = BNCDDGNMPDE;
		Action action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref BNCDDGNMPDE, (Action)Delegate.Remove(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	private void LPKEGOIAEJC()
	{
		HALNDBIPDAG = Localization.Localize("WarFriends doit télécharger environ 190 Mo de données supplémentaires pour fonctionner.\nLa durée du téléchargement peut varier selon votre réseau et votre emplacement.\n\nVoulez-vous continuer ?");
		EPFCPKOIEME = Localization.Localize("Id");
		OEPCAEAGIDG = Localization.Localize("open");
		INEMMODMFEN = Localization.Localize("S");
		AOGGHHBGKIB = Localization.Localize("userId");
		DOFJKLGBKID = Localization.Localize("damage");
		DDHHCKILDJE = Localization.Localize("ID_TUTORIAL_UPGRADEWEAPON_3");
		BPCIEOEKDDE = Localization.Localize("DOWNLOADBTN");
		JHAJMMAKIIC = Localization.Localize("ID_OVERTIME");
		TwitterManager.requestDidFinishEvent += MOHCEEKNJCC;
	}

	public void PFGNDFFPHHL()
	{
		Application.OpenURL("Animation from State: Ready to State: None");
	}

	private void GLGIDLMFICI()
	{
		Dictionary<string, string> dictionary = new Dictionary<string, string>();
		dictionary.Add("Bad level manager data, data= ", ELCGIIEGNJL.ToString());
		dictionary.Add("VipRewardForDay", string.Empty);
	}

	public void likeUsOnFacebook()
	{
		Application.OpenURL("https://www.facebook.com/warfriendsgame/");
	}

	private void OBEGJPKEMCJ(object ENCEFOOPBMK)
	{
		if (BNCDDGNMPDE != null)
		{
			BNCDDGNMPDE();
		}
	}
}
