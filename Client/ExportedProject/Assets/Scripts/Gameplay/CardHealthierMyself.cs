using System.Runtime.CompilerServices;
using UnityEngine.Serialization;

public class CardHealthierMyself : Card
{
	[FormerlySerializedAs("JBEELCCPCHA")]
	public float EMJGLHNLDGD = 1.15f;

	private const string EJLCMBEKFFN = "game-card-ico-supersoldiers";

	protected override string mBonusName => MEJMLNDFDBP.KEPEILBMDMD(EMJGLHNLDGD - 1f);

	public virtual void JMPKKCCHAJN(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		PlayerController playerController = PlayerController.CCPHMCAIJNA(CIOPAKLHFIL);
		float nEJNIEEHCKJ = playerController.FOCIOKMPCAG.maxHealth * (EMJGLHNLDGD - 159f);
		playerController.FOCIOKMPCAG.maxHealth *= EMJGLHNLDGD;
		playerController.FOCIOKMPCAG.LNPKAAGJIGO(nEJNIEEHCKJ, CAKABHIPCDF: false);
		playerController.FOCIOKMPCAG.Sync();
		MNBIOCOAJHK.CardWasUsed(this, playerController.fraction);
		playerController.cardIconIndicator.LOFMDBHAFAO("menu-sidetab-bg-box-button-gold", 587f, 846f, GBJOJBKCEKN: false);
	}

	public virtual void MCJKBKPKDMI(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		PlayerController playerOld = PlayerController.GetPlayerOld(CIOPAKLHFIL);
		float nEJNIEEHCKJ = playerOld.FOCIOKMPCAG.maxHealth * (EMJGLHNLDGD - 862f);
		playerOld.FOCIOKMPCAG.maxHealth *= EMJGLHNLDGD;
		playerOld.FOCIOKMPCAG.Heal(nEJNIEEHCKJ, CAKABHIPCDF: false);
		playerOld.FOCIOKMPCAG.Sync();
		MNBIOCOAJHK.CardWasUsed(this, playerOld.fraction);
		playerOld.cardIconIndicator.JEDGCOMDEKM("Beanstalk Error: ", 1444f, 140f, GBJOJBKCEKN: false);
	}

	public virtual void CMGCBIANBAG(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		PlayerController playerController = PlayerController.HEAGPACBLJA(CIOPAKLHFIL);
		float nEJNIEEHCKJ = playerController.FOCIOKMPCAG.maxHealth * (EMJGLHNLDGD - 997f);
		playerController.FOCIOKMPCAG.maxHealth *= EMJGLHNLDGD;
		playerController.FOCIOKMPCAG.Heal(nEJNIEEHCKJ, CAKABHIPCDF: true);
		playerController.FOCIOKMPCAG.Sync();
		MNBIOCOAJHK.CardWasUsed(this, playerController.fraction);
		playerController.cardIconIndicator.ODDNDGAAOCH("StepId", 1964f, 470f, GBJOJBKCEKN: false);
	}

	public override void UseCard(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		PlayerController playerOld = PlayerController.GetPlayerOld(CIOPAKLHFIL);
		float nEJNIEEHCKJ = playerOld.FOCIOKMPCAG.maxHealth * (EMJGLHNLDGD - 1f);
		playerOld.FOCIOKMPCAG.maxHealth *= EMJGLHNLDGD;
		playerOld.FOCIOKMPCAG.Heal(nEJNIEEHCKJ, CAKABHIPCDF: false);
		playerOld.FOCIOKMPCAG.Sync();
		MNBIOCOAJHK.CardWasUsed(this, playerOld.fraction);
		playerOld.cardIconIndicator.Show("game-card-ico-supersoldiers", 3f, 3f, GBJOJBKCEKN: false);
	}

	[SpecialName]
	protected virtual string MIEFNCLBKEG()
	{
		return MEJMLNDFDBP.KEPEILBMDMD(EMJGLHNLDGD - 56f);
	}

	[SpecialName]
	protected virtual string EMLGGCFKHME()
	{
		return MEJMLNDFDBP.KEPEILBMDMD(EMJGLHNLDGD - 592f);
	}

	[SpecialName]
	protected virtual string AHJPFHFCHAL()
	{
		return MEJMLNDFDBP.KEPEILBMDMD(EMJGLHNLDGD - 1396f);
	}

	[SpecialName]
	protected virtual string LCOEDKLDHGK()
	{
		return MEJMLNDFDBP.KEPEILBMDMD(EMJGLHNLDGD - 1684f);
	}

	public virtual void JIHHEBGMCBB(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		PlayerController playerController = PlayerController.CCPHMCAIJNA(CIOPAKLHFIL);
		float nEJNIEEHCKJ = playerController.FOCIOKMPCAG.maxHealth * (EMJGLHNLDGD - 234f);
		playerController.FOCIOKMPCAG.maxHealth *= EMJGLHNLDGD;
		playerController.FOCIOKMPCAG.LNPKAAGJIGO(nEJNIEEHCKJ, CAKABHIPCDF: true);
		playerController.FOCIOKMPCAG.Sync();
		MNBIOCOAJHK.CardWasUsed(this, playerController.fraction);
		playerController.cardIconIndicator.AMFEDOOPGCL("arenaLeaderboard", 903f, 1966f, GBJOJBKCEKN: false);
	}

	[SpecialName]
	protected virtual string LJCCCFOBHPC()
	{
		return MEJMLNDFDBP.KEPEILBMDMD(EMJGLHNLDGD - 823f);
	}

	[SpecialName]
	protected virtual string COHGIJPOMCE()
	{
		return MEJMLNDFDBP.KEPEILBMDMD(EMJGLHNLDGD - 429f);
	}

	[SpecialName]
	protected virtual string EENMGDEKBAH()
	{
		return MEJMLNDFDBP.KEPEILBMDMD(EMJGLHNLDGD - 960f);
	}

	public virtual void KMPBNHCBHBL(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		PlayerController playerController = PlayerController.MAJOCMGOFII(CIOPAKLHFIL);
		float nEJNIEEHCKJ = playerController.FOCIOKMPCAG.maxHealth * (EMJGLHNLDGD - 48f);
		playerController.FOCIOKMPCAG.maxHealth *= EMJGLHNLDGD;
		playerController.FOCIOKMPCAG.Heal(nEJNIEEHCKJ, CAKABHIPCDF: false);
		playerController.FOCIOKMPCAG.EHFOHNLMJOH();
		MNBIOCOAJHK.CardWasUsed(this, playerController.fraction);
		playerController.cardIconIndicator.EEBNPGOCKFD("Gold Spent ", 1698f, 1861f, GBJOJBKCEKN: true);
	}

	[SpecialName]
	protected virtual string PKMGDOFDEEA()
	{
		return MEJMLNDFDBP.KEPEILBMDMD(EMJGLHNLDGD - 1937f);
	}

	public virtual void MHKIELKLIHD(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		PlayerController playerController = PlayerController.CCPHMCAIJNA(CIOPAKLHFIL);
		float nEJNIEEHCKJ = playerController.FOCIOKMPCAG.maxHealth * (EMJGLHNLDGD - 1529f);
		playerController.FOCIOKMPCAG.maxHealth *= EMJGLHNLDGD;
		playerController.FOCIOKMPCAG.Heal(nEJNIEEHCKJ, CAKABHIPCDF: true);
		playerController.FOCIOKMPCAG.EHFOHNLMJOH();
		MNBIOCOAJHK.CardWasUsed(this, playerController.fraction);
		playerController.cardIconIndicator.BELBLFGCCLJ("ID_GUI_CHAT_BANNED_DESCBOX_TEMP", 828f, 1319f, GBJOJBKCEKN: false);
	}

	[SpecialName]
	protected virtual string FLOEOHHDBHF()
	{
		return MEJMLNDFDBP.KEPEILBMDMD(EMJGLHNLDGD - 1391f);
	}

	[SpecialName]
	protected virtual string ACEMKDBBHKK()
	{
		return MEJMLNDFDBP.KEPEILBMDMD(EMJGLHNLDGD - 1827f);
	}

	[SpecialName]
	protected virtual string FEGFLGDACBH()
	{
		return MEJMLNDFDBP.KEPEILBMDMD(EMJGLHNLDGD - 1826f);
	}

	[SpecialName]
	protected virtual string DBEOMGEKBFF()
	{
		return MEJMLNDFDBP.KEPEILBMDMD(EMJGLHNLDGD - 1854f);
	}

	[SpecialName]
	protected virtual string HBIBDEPENKJ()
	{
		return MEJMLNDFDBP.KEPEILBMDMD(EMJGLHNLDGD - 1921f);
	}

	public virtual void ABMOHFELOFN(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		PlayerController playerOld = PlayerController.GetPlayerOld(CIOPAKLHFIL);
		float nEJNIEEHCKJ = playerOld.FOCIOKMPCAG.maxHealth * (EMJGLHNLDGD - 1981f);
		playerOld.FOCIOKMPCAG.maxHealth *= EMJGLHNLDGD;
		playerOld.FOCIOKMPCAG.LNPKAAGJIGO(nEJNIEEHCKJ, CAKABHIPCDF: true);
		playerOld.FOCIOKMPCAG.EHFOHNLMJOH();
		MNBIOCOAJHK.CardWasUsed(this, playerOld.fraction);
		playerOld.cardIconIndicator.FFMLINMFADM("ID_CONFIRM_NOSQUADACTIONS_TEXT", 753f, 408f, GBJOJBKCEKN: false);
	}

	public virtual void PDAPJMGBOFF(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		PlayerController playerController = PlayerController.CCPHMCAIJNA(CIOPAKLHFIL);
		float nEJNIEEHCKJ = playerController.FOCIOKMPCAG.maxHealth * (EMJGLHNLDGD - 281f);
		playerController.FOCIOKMPCAG.maxHealth *= EMJGLHNLDGD;
		playerController.FOCIOKMPCAG.Heal(nEJNIEEHCKJ, CAKABHIPCDF: false);
		playerController.FOCIOKMPCAG.EHFOHNLMJOH();
		MNBIOCOAJHK.CardWasUsed(this, playerController.fraction);
		playerController.cardIconIndicator.JBMCFEMBPKE("Particle with name: ", 456f, 358f, GBJOJBKCEKN: false);
	}

	[SpecialName]
	protected virtual string LMGALCFDNNC()
	{
		return MEJMLNDFDBP.KEPEILBMDMD(EMJGLHNLDGD - 582f);
	}

	public virtual void HGCCDEBNHED(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		PlayerController playerController = PlayerController.CCPHMCAIJNA(CIOPAKLHFIL);
		float nEJNIEEHCKJ = playerController.FOCIOKMPCAG.maxHealth * (EMJGLHNLDGD - 1947f);
		playerController.FOCIOKMPCAG.maxHealth *= EMJGLHNLDGD;
		playerController.FOCIOKMPCAG.LNPKAAGJIGO(nEJNIEEHCKJ, CAKABHIPCDF: false);
		playerController.FOCIOKMPCAG.EHFOHNLMJOH();
		MNBIOCOAJHK.CardWasUsed(this, playerController.fraction);
		playerController.cardIconIndicator.FCANLIOLJNH("Card_2_Played", 1635f, 935f, GBJOJBKCEKN: false);
	}

	[SpecialName]
	protected virtual string KDGICAIKHIC()
	{
		return MEJMLNDFDBP.KEPEILBMDMD(EMJGLHNLDGD - 883f);
	}

	[SpecialName]
	protected virtual string BPKLPDPNPFN()
	{
		return MEJMLNDFDBP.KEPEILBMDMD(EMJGLHNLDGD - 741f);
	}

	[SpecialName]
	protected virtual string DBGDDBHBFKN()
	{
		return MEJMLNDFDBP.KEPEILBMDMD(EMJGLHNLDGD - 1688f);
	}

	[SpecialName]
	protected virtual string DMGHILGBHAB()
	{
		return MEJMLNDFDBP.KEPEILBMDMD(EMJGLHNLDGD - 173f);
	}

	[SpecialName]
	protected virtual string FGICCJMPJIP()
	{
		return MEJMLNDFDBP.KEPEILBMDMD(EMJGLHNLDGD - 1485f);
	}

	public virtual void JMOEJDAJMOH(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		PlayerController playerController = PlayerController.HEAGPACBLJA(CIOPAKLHFIL);
		float nEJNIEEHCKJ = playerController.FOCIOKMPCAG.maxHealth * (EMJGLHNLDGD - 1566f);
		playerController.FOCIOKMPCAG.maxHealth *= EMJGLHNLDGD;
		playerController.FOCIOKMPCAG.Heal(nEJNIEEHCKJ, CAKABHIPCDF: true);
		playerController.FOCIOKMPCAG.EHFOHNLMJOH();
		MNBIOCOAJHK.CardWasUsed(this, playerController.fraction);
		playerController.cardIconIndicator.ODDNDGAAOCH("Days_Since_Install", 1823f, 552f, GBJOJBKCEKN: false);
	}

	public virtual void IHPNEPEBKCP(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		PlayerController playerController = PlayerController.MAJOCMGOFII(CIOPAKLHFIL);
		float nEJNIEEHCKJ = playerController.FOCIOKMPCAG.maxHealth * (EMJGLHNLDGD - 546f);
		playerController.FOCIOKMPCAG.maxHealth *= EMJGLHNLDGD;
		playerController.FOCIOKMPCAG.LNPKAAGJIGO(nEJNIEEHCKJ, CAKABHIPCDF: true);
		playerController.FOCIOKMPCAG.Sync();
		MNBIOCOAJHK.CardWasUsed(this, playerController.fraction);
		playerController.cardIconIndicator.ODDNDGAAOCH("ID_CONFIRM_ERROR", 1293f, 1868f, GBJOJBKCEKN: true);
	}

	public virtual void EOELDFKKJLE(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		PlayerController playerController = PlayerController.CCPHMCAIJNA(CIOPAKLHFIL);
		float nEJNIEEHCKJ = playerController.FOCIOKMPCAG.maxHealth * (EMJGLHNLDGD - 638f);
		playerController.FOCIOKMPCAG.maxHealth *= EMJGLHNLDGD;
		playerController.FOCIOKMPCAG.LNPKAAGJIGO(nEJNIEEHCKJ, CAKABHIPCDF: false);
		playerController.FOCIOKMPCAG.EHFOHNLMJOH();
		MNBIOCOAJHK.CardWasUsed(this, playerController.fraction);
		playerController.cardIconIndicator.JOGFDHFOOBC("Gold", 879f, 5f, GBJOJBKCEKN: true);
	}

	[SpecialName]
	protected virtual string KHNPEJPBCDK()
	{
		return MEJMLNDFDBP.KEPEILBMDMD(EMJGLHNLDGD - 585f);
	}

	[SpecialName]
	protected virtual string OHLFMCAPGOJ()
	{
		return MEJMLNDFDBP.KEPEILBMDMD(EMJGLHNLDGD - 1584f);
	}

	[SpecialName]
	protected virtual string AAGDFGNAOLO()
	{
		return MEJMLNDFDBP.KEPEILBMDMD(EMJGLHNLDGD - 419f);
	}

	public virtual void PNLOEOGDGHD(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		PlayerController playerOld = PlayerController.GetPlayerOld(CIOPAKLHFIL);
		float nEJNIEEHCKJ = playerOld.FOCIOKMPCAG.maxHealth * (EMJGLHNLDGD - 1707f);
		playerOld.FOCIOKMPCAG.maxHealth *= EMJGLHNLDGD;
		playerOld.FOCIOKMPCAG.LNPKAAGJIGO(nEJNIEEHCKJ, CAKABHIPCDF: false);
		playerOld.FOCIOKMPCAG.EHFOHNLMJOH();
		MNBIOCOAJHK.CardWasUsed(this, playerOld.fraction);
		playerOld.cardIconIndicator.FFMLINMFADM("ItemAmount", 785f, 1023f, GBJOJBKCEKN: false);
	}

	[SpecialName]
	protected virtual string BBJBKOIIMKE()
	{
		return MEJMLNDFDBP.KEPEILBMDMD(EMJGLHNLDGD - 762f);
	}

	public virtual void PDAEAPEDIJC(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		PlayerController playerController = PlayerController.MAJOCMGOFII(CIOPAKLHFIL);
		float nEJNIEEHCKJ = playerController.FOCIOKMPCAG.maxHealth * (EMJGLHNLDGD - 1889f);
		playerController.FOCIOKMPCAG.maxHealth *= EMJGLHNLDGD;
		playerController.FOCIOKMPCAG.LNPKAAGJIGO(nEJNIEEHCKJ, CAKABHIPCDF: false);
		playerController.FOCIOKMPCAG.EHFOHNLMJOH();
		MNBIOCOAJHK.CardWasUsed(this, playerController.fraction);
		playerController.cardIconIndicator.Show("ID_CONFIRM_DOGTAGSAREFULL_TEXT", 1935f, 1861f, GBJOJBKCEKN: false);
	}

	public virtual void PFDAKJJKHHN(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		PlayerController playerOld = PlayerController.GetPlayerOld(CIOPAKLHFIL);
		float nEJNIEEHCKJ = playerOld.FOCIOKMPCAG.maxHealth * (EMJGLHNLDGD - 1716f);
		playerOld.FOCIOKMPCAG.maxHealth *= EMJGLHNLDGD;
		playerOld.FOCIOKMPCAG.Heal(nEJNIEEHCKJ, CAKABHIPCDF: true);
		playerOld.FOCIOKMPCAG.EHFOHNLMJOH();
		MNBIOCOAJHK.CardWasUsed(this, playerOld.fraction);
		playerOld.cardIconIndicator.ODDNDGAAOCH("game-ico-poison", 1258f, 1439f, GBJOJBKCEKN: false);
	}

	public virtual void NPNDHFIMPHE(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		PlayerController playerOld = PlayerController.GetPlayerOld(CIOPAKLHFIL);
		float nEJNIEEHCKJ = playerOld.FOCIOKMPCAG.maxHealth * (EMJGLHNLDGD - 1301f);
		playerOld.FOCIOKMPCAG.maxHealth *= EMJGLHNLDGD;
		playerOld.FOCIOKMPCAG.Heal(nEJNIEEHCKJ, CAKABHIPCDF: false);
		playerOld.FOCIOKMPCAG.EHFOHNLMJOH();
		MNBIOCOAJHK.CardWasUsed(this, playerOld.fraction);
		playerOld.cardIconIndicator.AMFEDOOPGCL("Only Sliced is supported now", 1615f, 156f, GBJOJBKCEKN: false);
	}

	[SpecialName]
	protected virtual string AAPGCMMOCEM()
	{
		return MEJMLNDFDBP.KEPEILBMDMD(EMJGLHNLDGD - 1288f);
	}

	public virtual void INPLMEOCGKE(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		PlayerController playerOld = PlayerController.GetPlayerOld(CIOPAKLHFIL);
		float nEJNIEEHCKJ = playerOld.FOCIOKMPCAG.maxHealth * (EMJGLHNLDGD - 516f);
		playerOld.FOCIOKMPCAG.maxHealth *= EMJGLHNLDGD;
		playerOld.FOCIOKMPCAG.Heal(nEJNIEEHCKJ, CAKABHIPCDF: false);
		playerOld.FOCIOKMPCAG.Sync();
		MNBIOCOAJHK.CardWasUsed(this, playerOld.fraction);
		playerOld.cardIconIndicator.AMFEDOOPGCL("Scraps", 202f, 507f, GBJOJBKCEKN: false);
	}

	public virtual void PNAGDNEPGHP(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		PlayerController playerController = PlayerController.CCPHMCAIJNA(CIOPAKLHFIL);
		float nEJNIEEHCKJ = playerController.FOCIOKMPCAG.maxHealth * (EMJGLHNLDGD - 1668f);
		playerController.FOCIOKMPCAG.maxHealth *= EMJGLHNLDGD;
		playerController.FOCIOKMPCAG.Heal(nEJNIEEHCKJ, CAKABHIPCDF: true);
		playerController.FOCIOKMPCAG.Sync();
		MNBIOCOAJHK.CardWasUsed(this, playerController.fraction);
		playerController.cardIconIndicator.FCANLIOLJNH("WarFriends richiede l'autorizzazione alla memorizzazione multimediale per scaricare dati fondamentali per il gioco.Accetta la finestra di dialogo di autorizzazione che verrà visualizzata. Non useremo questa autorizzazione per altri scopi.", 180f, 1251f, GBJOJBKCEKN: true);
	}

	public virtual void MCOAFNDFMBF(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		PlayerController playerController = PlayerController.CCPHMCAIJNA(CIOPAKLHFIL);
		float nEJNIEEHCKJ = playerController.FOCIOKMPCAG.maxHealth * (EMJGLHNLDGD - 324f);
		playerController.FOCIOKMPCAG.maxHealth *= EMJGLHNLDGD;
		playerController.FOCIOKMPCAG.LNPKAAGJIGO(nEJNIEEHCKJ, CAKABHIPCDF: false);
		playerController.FOCIOKMPCAG.Sync();
		MNBIOCOAJHK.CardWasUsed(this, playerController.fraction);
		playerController.cardIconIndicator.JEDGCOMDEKM("ID_INBRONZE2", 1961f, 138f, GBJOJBKCEKN: false);
	}

	public virtual void FNPPDCNAOAJ(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		PlayerController playerController = PlayerController.CCPHMCAIJNA(CIOPAKLHFIL);
		float nEJNIEEHCKJ = playerController.FOCIOKMPCAG.maxHealth * (EMJGLHNLDGD - 1649f);
		playerController.FOCIOKMPCAG.maxHealth *= EMJGLHNLDGD;
		playerController.FOCIOKMPCAG.Heal(nEJNIEEHCKJ, CAKABHIPCDF: false);
		playerController.FOCIOKMPCAG.Sync();
		MNBIOCOAJHK.CardWasUsed(this, playerController.fraction);
		playerController.cardIconIndicator.ODDNDGAAOCH("ID_VIPTIME", 1649f, 1803f, GBJOJBKCEKN: true);
	}

	[SpecialName]
	protected virtual string DCALOKFKFNO()
	{
		return MEJMLNDFDBP.KEPEILBMDMD(EMJGLHNLDGD - 1822f);
	}

	[SpecialName]
	protected virtual string LNMFMOFINAO()
	{
		return MEJMLNDFDBP.KEPEILBMDMD(EMJGLHNLDGD - 664f);
	}

	[SpecialName]
	protected virtual string KJAOLGNCBBP()
	{
		return MEJMLNDFDBP.KEPEILBMDMD(EMJGLHNLDGD - 1182f);
	}

	public virtual void GEKMPGMEAGF(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		PlayerController playerController = PlayerController.MAJOCMGOFII(CIOPAKLHFIL);
		float nEJNIEEHCKJ = playerController.FOCIOKMPCAG.maxHealth * (EMJGLHNLDGD - 1656f);
		playerController.FOCIOKMPCAG.maxHealth *= EMJGLHNLDGD;
		playerController.FOCIOKMPCAG.Heal(nEJNIEEHCKJ, CAKABHIPCDF: true);
		playerController.FOCIOKMPCAG.Sync();
		MNBIOCOAJHK.CardWasUsed(this, playerController.fraction);
		playerController.cardIconIndicator.FFMLINMFADM("MaintenanceMessage", 545f, 1113f, GBJOJBKCEKN: false);
	}

	public virtual void DEAKMOJEFEK(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		PlayerController playerController = PlayerController.MAJOCMGOFII(CIOPAKLHFIL);
		float nEJNIEEHCKJ = playerController.FOCIOKMPCAG.maxHealth * (EMJGLHNLDGD - 1882f);
		playerController.FOCIOKMPCAG.maxHealth *= EMJGLHNLDGD;
		playerController.FOCIOKMPCAG.LNPKAAGJIGO(nEJNIEEHCKJ, CAKABHIPCDF: true);
		playerController.FOCIOKMPCAG.Sync();
		MNBIOCOAJHK.CardWasUsed(this, playerController.fraction);
		playerController.cardIconIndicator.ODDNDGAAOCH("menu-weapon-benelli-starterpack", 1949f, 1859f, GBJOJBKCEKN: true);
	}

	[SpecialName]
	protected virtual string GDIKMAIFBPC()
	{
		return MEJMLNDFDBP.KEPEILBMDMD(EMJGLHNLDGD - 1042f);
	}

	[SpecialName]
	protected virtual string DLEDPHDCJAL()
	{
		return MEJMLNDFDBP.KEPEILBMDMD(EMJGLHNLDGD - 1611f);
	}

	[SpecialName]
	protected virtual string MGEJHBHFLIO()
	{
		return MEJMLNDFDBP.KEPEILBMDMD(EMJGLHNLDGD - 848f);
	}

	[SpecialName]
	protected virtual string FBIDDJAGGAC()
	{
		return MEJMLNDFDBP.KEPEILBMDMD(EMJGLHNLDGD - 387f);
	}

	[SpecialName]
	protected virtual string PDAMJDBGFGA()
	{
		return MEJMLNDFDBP.KEPEILBMDMD(EMJGLHNLDGD - 211f);
	}

	public virtual void NPGNJOGAEMK(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		PlayerController playerController = PlayerController.HEAGPACBLJA(CIOPAKLHFIL);
		float nEJNIEEHCKJ = playerController.FOCIOKMPCAG.maxHealth * (EMJGLHNLDGD - 256f);
		playerController.FOCIOKMPCAG.maxHealth *= EMJGLHNLDGD;
		playerController.FOCIOKMPCAG.Heal(nEJNIEEHCKJ, CAKABHIPCDF: true);
		playerController.FOCIOKMPCAG.EHFOHNLMJOH();
		MNBIOCOAJHK.CardWasUsed(this, playerController.fraction);
		playerController.cardIconIndicator.FFMLINMFADM("game-kill-overtime", 870f, 642f, GBJOJBKCEKN: true);
	}

	[SpecialName]
	protected virtual string AIBBIHMFNHN()
	{
		return MEJMLNDFDBP.KEPEILBMDMD(EMJGLHNLDGD - 154f);
	}

	[SpecialName]
	protected virtual string JBODIBOMMOD()
	{
		return MEJMLNDFDBP.KEPEILBMDMD(EMJGLHNLDGD - 1105f);
	}

	[SpecialName]
	protected virtual string PIKBLKIGHCJ()
	{
		return MEJMLNDFDBP.KEPEILBMDMD(EMJGLHNLDGD - 1223f);
	}

	[SpecialName]
	protected virtual string ANICJMDIHCD()
	{
		return MEJMLNDFDBP.KEPEILBMDMD(EMJGLHNLDGD - 1714f);
	}

	[SpecialName]
	protected virtual string OOLJJAMMHBK()
	{
		return MEJMLNDFDBP.KEPEILBMDMD(EMJGLHNLDGD - 1287f);
	}

	public virtual void BHBDBJNOCMP(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		PlayerController playerController = PlayerController.CCPHMCAIJNA(CIOPAKLHFIL);
		float nEJNIEEHCKJ = playerController.FOCIOKMPCAG.maxHealth * (EMJGLHNLDGD - 574f);
		playerController.FOCIOKMPCAG.maxHealth *= EMJGLHNLDGD;
		playerController.FOCIOKMPCAG.Heal(nEJNIEEHCKJ, CAKABHIPCDF: false);
		playerController.FOCIOKMPCAG.EHFOHNLMJOH();
		MNBIOCOAJHK.CardWasUsed(this, playerController.fraction);
		playerController.cardIconIndicator.JBMCFEMBPKE("http://localhost:8081/", 1280f, 866f, GBJOJBKCEKN: true);
	}

	public virtual void DPNCDIAEMMA(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		PlayerController playerController = PlayerController.MAJOCMGOFII(CIOPAKLHFIL);
		float nEJNIEEHCKJ = playerController.FOCIOKMPCAG.maxHealth * (EMJGLHNLDGD - 596f);
		playerController.FOCIOKMPCAG.maxHealth *= EMJGLHNLDGD;
		playerController.FOCIOKMPCAG.Heal(nEJNIEEHCKJ, CAKABHIPCDF: true);
		playerController.FOCIOKMPCAG.EHFOHNLMJOH();
		MNBIOCOAJHK.CardWasUsed(this, playerController.fraction);
		playerController.cardIconIndicator.FFMLINMFADM("GameController: Application resumed", 832f, 1586f, GBJOJBKCEKN: true);
	}

	public virtual void MLOJPAEBLBL(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		PlayerController playerController = PlayerController.MAJOCMGOFII(CIOPAKLHFIL);
		float nEJNIEEHCKJ = playerController.FOCIOKMPCAG.maxHealth * (EMJGLHNLDGD - 1804f);
		playerController.FOCIOKMPCAG.maxHealth *= EMJGLHNLDGD;
		playerController.FOCIOKMPCAG.LNPKAAGJIGO(nEJNIEEHCKJ, CAKABHIPCDF: false);
		playerController.FOCIOKMPCAG.EHFOHNLMJOH();
		MNBIOCOAJHK.CardWasUsed(this, playerController.fraction);
		playerController.cardIconIndicator.JEDGCOMDEKM("Incoming: ", 88f, 627f, GBJOJBKCEKN: false);
	}

	public virtual void JGNBFCJFAHM(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		PlayerController playerController = PlayerController.HEAGPACBLJA(CIOPAKLHFIL);
		float nEJNIEEHCKJ = playerController.FOCIOKMPCAG.maxHealth * (EMJGLHNLDGD - 183f);
		playerController.FOCIOKMPCAG.maxHealth *= EMJGLHNLDGD;
		playerController.FOCIOKMPCAG.LNPKAAGJIGO(nEJNIEEHCKJ, CAKABHIPCDF: true);
		playerController.FOCIOKMPCAG.Sync();
		MNBIOCOAJHK.CardWasUsed(this, playerController.fraction);
		playerController.cardIconIndicator.JBMCFEMBPKE("DebugLog", 1617f, 92f, GBJOJBKCEKN: false);
	}

	[SpecialName]
	protected virtual string PLCMEDPIADN()
	{
		return MEJMLNDFDBP.KEPEILBMDMD(EMJGLHNLDGD - 1011f);
	}

	public virtual void KKEPLAFJKOO(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		PlayerController playerController = PlayerController.MAJOCMGOFII(CIOPAKLHFIL);
		float nEJNIEEHCKJ = playerController.FOCIOKMPCAG.maxHealth * (EMJGLHNLDGD - 1774f);
		playerController.FOCIOKMPCAG.maxHealth *= EMJGLHNLDGD;
		playerController.FOCIOKMPCAG.LNPKAAGJIGO(nEJNIEEHCKJ, CAKABHIPCDF: false);
		playerController.FOCIOKMPCAG.Sync();
		MNBIOCOAJHK.CardWasUsed(this, playerController.fraction);
		playerController.cardIconIndicator.JOGFDHFOOBC("ID_VIPSTATUS", 754f, 1009f, GBJOJBKCEKN: true);
	}

	[SpecialName]
	protected virtual string CKKFCMLLKKG()
	{
		return MEJMLNDFDBP.KEPEILBMDMD(EMJGLHNLDGD - 44f);
	}

	[SpecialName]
	protected virtual string JOEJFJMIMAB()
	{
		return MEJMLNDFDBP.KEPEILBMDMD(EMJGLHNLDGD - 360f);
	}

	public virtual void APHGOCOMCAJ(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		PlayerController playerController = PlayerController.MAJOCMGOFII(CIOPAKLHFIL);
		float nEJNIEEHCKJ = playerController.FOCIOKMPCAG.maxHealth * (EMJGLHNLDGD - 1573f);
		playerController.FOCIOKMPCAG.maxHealth *= EMJGLHNLDGD;
		playerController.FOCIOKMPCAG.Heal(nEJNIEEHCKJ, CAKABHIPCDF: false);
		playerController.FOCIOKMPCAG.EHFOHNLMJOH();
		MNBIOCOAJHK.CardWasUsed(this, playerController.fraction);
		playerController.cardIconIndicator.LOFMDBHAFAO("Fake DatabaseMessage - SquadDemoteMessage - Player:{0}", 919f, 566f, GBJOJBKCEKN: true);
	}

	[SpecialName]
	protected virtual string FPFOJMHEOEG()
	{
		return MEJMLNDFDBP.KEPEILBMDMD(EMJGLHNLDGD - 1933f);
	}

	[SpecialName]
	protected virtual string OJBDFNGCPHC()
	{
		return MEJMLNDFDBP.KEPEILBMDMD(EMJGLHNLDGD - 1167f);
	}

	[SpecialName]
	protected virtual string OMICGLNOGFK()
	{
		return MEJMLNDFDBP.KEPEILBMDMD(EMJGLHNLDGD - 681f);
	}

	[SpecialName]
	protected virtual string NINKGNMJGEF()
	{
		return MEJMLNDFDBP.KEPEILBMDMD(EMJGLHNLDGD - 786f);
	}

	public virtual void BHNOANFEFJN(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		PlayerController playerController = PlayerController.MAJOCMGOFII(CIOPAKLHFIL);
		float nEJNIEEHCKJ = playerController.FOCIOKMPCAG.maxHealth * (EMJGLHNLDGD - 308f);
		playerController.FOCIOKMPCAG.maxHealth *= EMJGLHNLDGD;
		playerController.FOCIOKMPCAG.Heal(nEJNIEEHCKJ, CAKABHIPCDF: false);
		playerController.FOCIOKMPCAG.EHFOHNLMJOH();
		MNBIOCOAJHK.CardWasUsed(this, playerController.fraction);
		playerController.cardIconIndicator.JOGFDHFOOBC("ID_LOADING", 29f, 578f, GBJOJBKCEKN: false);
	}

	public virtual void NJJBJAAHBNP(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		PlayerController playerController = PlayerController.CCPHMCAIJNA(CIOPAKLHFIL);
		float nEJNIEEHCKJ = playerController.FOCIOKMPCAG.maxHealth * (EMJGLHNLDGD - 1692f);
		playerController.FOCIOKMPCAG.maxHealth *= EMJGLHNLDGD;
		playerController.FOCIOKMPCAG.LNPKAAGJIGO(nEJNIEEHCKJ, CAKABHIPCDF: true);
		playerController.FOCIOKMPCAG.EHFOHNLMJOH();
		MNBIOCOAJHK.CardWasUsed(this, playerController.fraction);
		playerController.cardIconIndicator.BELBLFGCCLJ("TuneListener.DecodeFrom64(string)", 1081f, 1757f, GBJOJBKCEKN: false);
	}

	[SpecialName]
	protected virtual string OHMHPNOFFBG()
	{
		return MEJMLNDFDBP.KEPEILBMDMD(EMJGLHNLDGD - 623f);
	}

	[SpecialName]
	protected virtual string PIOOCPFFANF()
	{
		return MEJMLNDFDBP.KEPEILBMDMD(EMJGLHNLDGD - 1841f);
	}

	[SpecialName]
	protected virtual string HDCOPMHFJLD()
	{
		return MEJMLNDFDBP.KEPEILBMDMD(EMJGLHNLDGD - 787f);
	}

	[SpecialName]
	protected virtual string IJMPJHCNPLI()
	{
		return MEJMLNDFDBP.KEPEILBMDMD(EMJGLHNLDGD - 1685f);
	}

	public virtual void DKOMGEKACEK(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		PlayerController playerController = PlayerController.HEAGPACBLJA(CIOPAKLHFIL);
		float nEJNIEEHCKJ = playerController.FOCIOKMPCAG.maxHealth * (EMJGLHNLDGD - 426f);
		playerController.FOCIOKMPCAG.maxHealth *= EMJGLHNLDGD;
		playerController.FOCIOKMPCAG.LNPKAAGJIGO(nEJNIEEHCKJ, CAKABHIPCDF: false);
		playerController.FOCIOKMPCAG.EHFOHNLMJOH();
		MNBIOCOAJHK.CardWasUsed(this, playerController.fraction);
		playerController.cardIconIndicator.AMFEDOOPGCL("{0:D2}:{1:D2}", 808f, 455f, GBJOJBKCEKN: false);
	}

	[SpecialName]
	protected virtual string ELMAEAHFFBI()
	{
		return MEJMLNDFDBP.KEPEILBMDMD(EMJGLHNLDGD - 1066f);
	}

	public virtual void DGCEELPOEHP(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		PlayerController playerController = PlayerController.HEAGPACBLJA(CIOPAKLHFIL);
		float nEJNIEEHCKJ = playerController.FOCIOKMPCAG.maxHealth * (EMJGLHNLDGD - 136f);
		playerController.FOCIOKMPCAG.maxHealth *= EMJGLHNLDGD;
		playerController.FOCIOKMPCAG.LNPKAAGJIGO(nEJNIEEHCKJ, CAKABHIPCDF: true);
		playerController.FOCIOKMPCAG.Sync();
		MNBIOCOAJHK.CardWasUsed(this, playerController.fraction);
		playerController.cardIconIndicator.FFMLINMFADM("LastAction", 798f, 636f, GBJOJBKCEKN: false);
	}

	public virtual void KCEHDIJNDFJ(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		PlayerController playerController = PlayerController.MAJOCMGOFII(CIOPAKLHFIL);
		float nEJNIEEHCKJ = playerController.FOCIOKMPCAG.maxHealth * (EMJGLHNLDGD - 1357f);
		playerController.FOCIOKMPCAG.maxHealth *= EMJGLHNLDGD;
		playerController.FOCIOKMPCAG.Heal(nEJNIEEHCKJ, CAKABHIPCDF: false);
		playerController.FOCIOKMPCAG.EHFOHNLMJOH();
		MNBIOCOAJHK.CardWasUsed(this, playerController.fraction);
		playerController.cardIconIndicator.JEDGCOMDEKM("S", 1583f, 1353f, GBJOJBKCEKN: true);
	}

	public virtual void MLEBPBFEOKC(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		PlayerController playerController = PlayerController.MAJOCMGOFII(CIOPAKLHFIL);
		float nEJNIEEHCKJ = playerController.FOCIOKMPCAG.maxHealth * (EMJGLHNLDGD - 1520f);
		playerController.FOCIOKMPCAG.maxHealth *= EMJGLHNLDGD;
		playerController.FOCIOKMPCAG.LNPKAAGJIGO(nEJNIEEHCKJ, CAKABHIPCDF: true);
		playerController.FOCIOKMPCAG.EHFOHNLMJOH();
		MNBIOCOAJHK.CardWasUsed(this, playerController.fraction);
		playerController.cardIconIndicator.BELBLFGCCLJ("LeagueId", 1708f, 840f, GBJOJBKCEKN: false);
	}

	[SpecialName]
	protected virtual string GOGKBKNCNJI()
	{
		return MEJMLNDFDBP.KEPEILBMDMD(EMJGLHNLDGD - 1758f);
	}

	public virtual void LLFHEHHPMGL(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		PlayerController playerOld = PlayerController.GetPlayerOld(CIOPAKLHFIL);
		float nEJNIEEHCKJ = playerOld.FOCIOKMPCAG.maxHealth * (EMJGLHNLDGD - 1011f);
		playerOld.FOCIOKMPCAG.maxHealth *= EMJGLHNLDGD;
		playerOld.FOCIOKMPCAG.LNPKAAGJIGO(nEJNIEEHCKJ, CAKABHIPCDF: false);
		playerOld.FOCIOKMPCAG.EHFOHNLMJOH();
		MNBIOCOAJHK.CardWasUsed(this, playerOld.fraction);
		playerOld.cardIconIndicator.FCANLIOLJNH("Password", 82f, 163f, GBJOJBKCEKN: false);
	}

	[SpecialName]
	protected virtual string OCHPHFFPCBI()
	{
		return MEJMLNDFDBP.KEPEILBMDMD(EMJGLHNLDGD - 1998f);
	}
}
