using System;
using System.Runtime.CompilerServices;
using UnityEngine;

public class MessageCenterRecord : PoolableObject
{
	private enum ANJPPDKMFCH
	{
		None,
		Blue,
		Yellow
	}

	private enum MPLBPIBFDDE
	{
		None,
		Simple,
		Reward,
		Emblem,
		AcceptPlayer
	}

	private sealed class JNKLHKFMIJH
	{
		public MessageCenterRecord HNNCIECPFEJ;

		public ECFKBOAEIAC GFCPOPNBHKN;

		internal void ODPMKEFKCCD()
		{
		}
	}

	private sealed class HOIBACIPGEM
	{
		public MessageCenterRecord HNNCIECPFEJ;

		public DatabasePlayer GDMBMAPOKCL;

		internal void DGLACCOPKMH(GameObject LJFDGDIAGIN)
		{
		}

		internal void EBLDDFFEPOG(GameObject LJFDGDIAGIN)
		{
		}
	}

	[CompilerGenerated]
	private Action IOEHBDIIHGP;

	public UISprite GIMMLMFBMEI;

	public BoxCollider MHOPKAHDGMN;

	public UILabel KHEBILCPHPE;

	public WinStreakCounter HCBLGGPDDAO;

	public GameObject KLEAPKKCBGH;

	public UILabel EECMFMKNMGK;

	public UISprite HMEPJIDIIFA;

	public UISprite ECPHAFLCJPL;

	public UISprite NBDHFPEODEG;

	public UITexture KNIHAEEIFLJ;

	public UISprite ANGKPGHJEOK;

	public GameObject CILBODEIMFN;

	public GameObject PJPFDPFHPBO;

	public UILabel EBHAJEACAFL;

	public GameObject AOABFPGNNOG;

	public UITexture[] HNNLCBBFJPK;

	public GameObject FGCOBBEIIIP;

	public GameObject DBNBNJIBBEE;

	[SerializeField]
	private GameObject mCommanderIcon;

	[SerializeField]
	private GameObject mDoubleUpgradesPart;

	public GameObject ADJDCMPIMIH;

	public UISprite LPBGFEAJOIJ;

	public UILabel CDGBJOJFEEP;

	public UILabel AIOPDIPGLBM;

	public BoxCollider JKMFPJNPLGN;

	public UILabel HHHDFOOEHOC;

	public UITable HMNBPIONEPD;

	public UILabel DGBEPDCADLF;

	public UISprite KMMBHNBCCMK;

	public UILabel PJKNLIPPHML;

	public GameObject MDDDMMMIJFM;

	public UILabel FDHMDJDDACO;

	public GameObject OCCDPIKELBB;

	public UITexture NMAEJHKDIJE;

	public UILabel HIBBGBKCDKE;

	public GameObject DLFCGBMCNDJ;

	public UITable JPHMKMAADDK;

	public UILabel APJCOGLJKPD;

	public UISprite GFMOJNOMHOD;

	public UILabel KKKIKOFFHBD;

	public GameObject DFLBOHPICKJ;

	public GameObject CGCPJHCAHAO;

	public GameObject NMEDJBFDFJF;

	public GameObject LKIPEAKDIIH;

	public UITable CNJPJKDEMKC;

	public UILabel MLAEAOBNLAO;

	public UILabel JJLDHFDFLHB;

	public UISprite GOMJGLLKCPG;

	public GameObject MPHACBOAJAL;

	public UITable MAKLOLFNCEA;

	public UILabel NAFEHLAPHBC;

	public UISprite FKMDAFOLNDF;

	public UISprite FEADMNICEDG;

	public UITexture CIPDLPJELCG;

	public UISprite KPBHFPOHEKE;

	public UILabel PICIPDJDIMM;

	private GIFNNKNKCMA LDAPODNKEGA;

	private DatabasePlayer HOCKBODCNMI;

	private DatabasePlayer KIHLHCFNNLI;

	private Card ELNPNPNLCAJ;

	private WeaponLevelsSetup[] CHNPKACIDHM;

	private int HAELMFLAHPC;

	public float height => 0f;

	private bool CFEECKGHGCO => false;

	public event Action OnClickEvent
	{
		[CompilerGenerated]
		add
		{
		}
		[CompilerGenerated]
		remove
		{
		}
	}

	public void SetAppearance_Challenge(GIFNNKNKCMA.GKGEBFJCFPJ NMELNIBILEG, int OOHJFGGOCFI, DatabasePlayer MBIHLECMNNJ, bool GLFGCJCLIFO, ECFKBOAEIAC GFCPOPNBHKN)
	{
	}

	public void SetAppearance_CheatWarning(GIFNNKNKCMA.GKGEBFJCFPJ NMELNIBILEG, int OOHJFGGOCFI, AntiCheatDetector.DNLMFJBJMIJ ONFAGAGBKEK)
	{
	}

	public void SetAppearance_LeagueEntered(GIFNNKNKCMA.GKGEBFJCFPJ NMELNIBILEG, int OOHJFGGOCFI, League NLCKLCDJLAO)
	{
	}

	public void SetAppearance_InformSquadLeader(GIFNNKNKCMA.GKGEBFJCFPJ NMELNIBILEG, int OOHJFGGOCFI)
	{
	}

	public void SetAppearance_SquadDemotion(GIFNNKNKCMA.GKGEBFJCFPJ NMELNIBILEG, int OOHJFGGOCFI, int GLKEDIKBBFC, DatabasePlayer GDMBMAPOKCL, DatabasePlayer LKKNGMGGIPO)
	{
	}

	public void SetAppearance_SquadEventEntered(GIFNNKNKCMA.GKGEBFJCFPJ NMELNIBILEG, int OOHJFGGOCFI)
	{
	}

	public void SetAppearance_SquadEventTierReward(GIFNNKNKCMA.GKGEBFJCFPJ NMELNIBILEG, int OOHJFGGOCFI, int LNOKLLPABOP, int GAMKCDKDPKL)
	{
	}

	public void SetAppearance_SquadEventEnded(GIFNNKNKCMA.GKGEBFJCFPJ NMELNIBILEG, int OOHJFGGOCFI, int EHFHMNGPODD, int FLPABEPBLEC)
	{
	}

	public void SetAppearance_SquadInvitation(GIFNNKNKCMA.GKGEBFJCFPJ NMELNIBILEG, int OOHJFGGOCFI, DatabasePlayer CHFBMHCGGKK)
	{
	}

	public void SetAppearance_SquadJoined(GIFNNKNKCMA.GKGEBFJCFPJ NMELNIBILEG, int OOHJFGGOCFI, DatabasePlayer GDMBMAPOKCL)
	{
	}

	public void SetAppearance_AcceptPlayer(GIFNNKNKCMA.GKGEBFJCFPJ NMELNIBILEG, int OOHJFGGOCFI, DatabasePlayer GDMBMAPOKCL)
	{
	}

	public void UpdateAcceptPlayer(string ECIJDHLNIJO)
	{
	}

	public void SetAppearance_SquadPromotion(GIFNNKNKCMA.GKGEBFJCFPJ NMELNIBILEG, int OOHJFGGOCFI, int GLKEDIKBBFC, DatabasePlayer GDMBMAPOKCL)
	{
	}

	public void SetAppearance_SquadLevelUp(GIFNNKNKCMA.GKGEBFJCFPJ NMELNIBILEG, int OOHJFGGOCFI, int FCNDEBDBOFH)
	{
	}

	public void SetAppearance_SquadWarsEnded(GIFNNKNKCMA.GKGEBFJCFPJ NMELNIBILEG, int OOHJFGGOCFI, int MPHCJEIMBEB, int HJJKJKGBOMF, string OFOMNJAPIBJ)
	{
	}

	public void SetAppearance_WarcardWithdrew(GIFNNKNKCMA.GKGEBFJCFPJ NMELNIBILEG, int OOHJFGGOCFI, DatabasePlayer GDMBMAPOKCL, Card CIDDAMDLNJD, int FFCMNBFMMFD)
	{
	}

	public void SetAppearance_DepositWarcards(GIFNNKNKCMA.GKGEBFJCFPJ NMELNIBILEG, int OOHJFGGOCFI, DatabasePlayer GDMBMAPOKCL)
	{
	}

	public void SetAppearance_NewRecruit(GIFNNKNKCMA.GKGEBFJCFPJ NMELNIBILEG, int OOHJFGGOCFI, string KBJPGNFNAAA)
	{
	}

	public void SetAppearance_BeAdvisedFacebook(GIFNNKNKCMA.GKGEBFJCFPJ NMELNIBILEG, int OOHJFGGOCFI)
	{
	}

	public void SetAppearance_GenericGetFreeGoldWithSocial(GIFNNKNKCMA.GKGEBFJCFPJ NMELNIBILEG, int OOHJFGGOCFI, int KHEPJPGLLOA)
	{
	}

	public void SetAppearance_BeAdvisedJoinOrCreateSquad(GIFNNKNKCMA.GKGEBFJCFPJ NMELNIBILEG, int OOHJFGGOCFI)
	{
	}

	public void SetAppearance_BeAdvisedVIP(GIFNNKNKCMA.GKGEBFJCFPJ NMELNIBILEG, int OOHJFGGOCFI)
	{
	}

	public void SetAppearance_SystemMessage(GIFNNKNKCMA.GKGEBFJCFPJ NMELNIBILEG, int OOHJFGGOCFI, string KPDJPHGDMDN)
	{
	}

	public void SetAppearance_VIPAlmostEnded(GIFNNKNKCMA.GKGEBFJCFPJ NMELNIBILEG, int OOHJFGGOCFI, int ACJLLLJEJCO)
	{
	}

	public void SetAppearance_VIPExpired(GIFNNKNKCMA.GKGEBFJCFPJ NMELNIBILEG, int OOHJFGGOCFI)
	{
	}

	public void SetAppearance_TimeLimitedOffer(GIFNNKNKCMA.GKGEBFJCFPJ NMELNIBILEG, int OOHJFGGOCFI)
	{
	}

	public void SetAppearance_StarterPackTimeLimitedOffer(GIFNNKNKCMA.GKGEBFJCFPJ NMELNIBILEG, int OOHJFGGOCFI)
	{
	}

	public void SetAppearance_InGameMessage(GIFNNKNKCMA.GKGEBFJCFPJ NMELNIBILEG, int OOHJFGGOCFI, bool KGDIAKBGDNI, string KFEGNKJLMEL, DateTime GFDJHHIPPHC)
	{
	}

	public void SetAppearance_DoubleUpgradesExpired(GIFNNKNKCMA.GKGEBFJCFPJ NMELNIBILEG, int OOHJFGGOCFI)
	{
	}

	private void OnClick()
	{
	}

	private void FIONECCJEEF()
	{
	}

	internal void FPFDNHHGFPP(GIFNNKNKCMA NNCFCHPCADD, bool JDPCAHAMECB = false)
	{
	}

	public void FakeDestroyPooled()
	{
	}

	public override void DestroyPooled()
	{
	}

	private void OPDPDALNCOM(GIFNNKNKCMA.GKGEBFJCFPJ NMELNIBILEG)
	{
	}

	private void LEEGBBPHPBL(string KBBHFLOCIIO)
	{
	}

	private void AICPNIFGJAA(bool KNBNNIEKABK = false)
	{
	}

	private void OCEDFCCIFBG(int OOHJFGGOCFI)
	{
	}

	private void KJLEJMEGFOG(DatabasePlayer GDMBMAPOKCL, bool IKMCKLEMPHE = true)
	{
	}

	private void FCCGNOLOLNA()
	{
	}

	private void IFHKBIIOJIF(string GMDKHHFABLH, bool FJFNJCFJBAE = false)
	{
	}

	private void AJAHAJLLPCL(GIFNNKNKCMA.GKGEBFJCFPJ NMELNIBILEG, League NLCKLCDJLAO = League.NoLeague)
	{
	}

	private void MEKGJECHKJD(Card CIDDAMDLNJD, int OGKFMNGNHBE)
	{
	}

	private void FMBOPAFMLDM(int KHEPJPGLLOA)
	{
	}

	private void DJKDGMCAFDG()
	{
	}

	private void BCBCAMMDCPB(ANJPPDKMFCH CBADPHMMCIM)
	{
	}

	private void BEOBGCGFMDO(MPLBPIBFDDE CBADPHMMCIM)
	{
	}

	private void EDNNKMKNFHC(ANJPPDKMFCH HILFBEJKGAC, MPLBPIBFDDE FACIIDHDENH)
	{
	}

	private void BOJBDKCIHOF(int EPNGMAHENPA, WeaponLevelsSetup AEBEOCBIBFI)
	{
	}

	private void HNLHLJMHCGD(int EPNGMAHENPA)
	{
	}

	protected void Update()
	{
	}

	[CompilerGenerated]
	private void NBHECLAMLLM(ConfirmDialog EJOPIJNPCGG, bool PNEJLHLMEPK)
	{
	}

	[CompilerGenerated]
	private void FPMMPACLMKM(ConfirmDialog EJOPIJNPCGG, bool PNEJLHLMEPK)
	{
	}

	[CompilerGenerated]
	private void CBGFBJCIMPM()
	{
	}

	[CompilerGenerated]
	private void EOGNAKEGHGD(GameObject LJFDGDIAGIN)
	{
	}
}
