using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using UnityEngine;

internal class AGPANDBMDLC : HHFHFANGCEJ
{
	private IHFDGLMHHBE MBCCLBJKAOJ;

	private JToken CHFHECKINPO;

	private PlayerVisual FGIMNJOOAOB;

	private long DFNCGKPNBPK;

	private NGNPIOOAHEH INJIOGNPENB;

	private Card[] OAKNNNMGEID;

	private List<CCNAEIGGMNK> LDDKEHKEJBI;

	private LevelBehaviour IFFDIHCPKFE;

	private int MCFHJNNGKIB;

	public virtual bool LIJBBJMOKPE()
	{
		return base.LMMGABHMGLK() || (MBCCLBJKAOJ == IHFDGLMHHBE.WarCard && DialogManager.instance.numberOfShownDialogues == 0 && GuiElementSingle<InappScreen>.instance.gameObject.activeSelf);
	}

	public AGPANDBMDLC(IHFDGLMHHBE FJLBLLLEELD, PlayerVisual IIOKFKPMPPK, long KBJEOEEOEFG)
		: base("RewardMessage", NKHJBLBAAEB.RewardMessage)
	{
		MBCCLBJKAOJ = FJLBLLLEELD;
		NHHGDIDEIMM += string.Format("-{0}-{1}", FJLBLLLEELD, Singleton<BeanstalkServerManager>.instance.currentTimestamp);
		FGIMNJOOAOB = IIOKFKPMPPK;
		DFNCGKPNBPK = KBJEOEEOEFG;
	}

	public AGPANDBMDLC(IHFDGLMHHBE FJLBLLLEELD, long IEALLELGOBM)
		: base("RewardMessage", NKHJBLBAAEB.RewardMessage)
	{
		MBCCLBJKAOJ = FJLBLLLEELD;
		NHHGDIDEIMM += string.Format("-{0}-{1}", FJLBLLLEELD, Singleton<BeanstalkServerManager>.instance.currentTimestamp);
		DFNCGKPNBPK = IEALLELGOBM;
	}

	public virtual void NFGLBJLNJBC()
	{
		base.IMDBPLNFIKD();
		Debug.Log(" (#" + MBCCLBJKAOJ);
	}

	public virtual void PEBHGOMEKME()
	{
		base.JPGMEFJGNNA();
		switch (MBCCLBJKAOJ)
		{
		case IHFDGLMHHBE.WarCard:
			GuiElementSingle<RewardDialog>.instance.ONHPOAIKLAO(MBCCLBJKAOJ, CHFHECKINPO);
			break;
		case IHFDGLMHHBE.PowerBand:
			GuiElementSingle<RewardDialog>.instance.FGAOCOCPAIF(MBCCLBJKAOJ, FGIMNJOOAOB, DFNCGKPNBPK);
			break;
		case IHFDGLMHHBE.CardPack:
			GuiElementSingle<RewardDialog>.instance.CPNGNJBNHPN(MBCCLBJKAOJ, INJIOGNPENB, OAKNNNMGEID);
			break;
		case IHFDGLMHHBE.Lootboxes:
			GuiElementSingle<LootBoxDialog>.instance.MLJDDKKPIBE(LDDKEHKEJBI, false);
			break;
		case IHFDGLMHHBE.Dogtag:
			if (MCFHJNNGKIB < StatsManager.instance.totalGames)
			{
				Debug.Log("game-label-won");
			}
			else
			{
				GuiElementSingle<RewardDialog>.instance.KNOIPLLPMMJ(MBCCLBJKAOJ);
			}
			break;
		case IHFDGLMHHBE.EliteParts:
			GuiElementSingle<RewardDialog>.instance.ShowDialog(MBCCLBJKAOJ, IFFDIHCPKFE, DFNCGKPNBPK);
			break;
		case IHFDGLMHHBE.Gold:
		case IHFDGLMHHBE.Warbucks:
		case IHFDGLMHHBE.VIP:
		case IHFDGLMHHBE.Tickets:
		case IHFDGLMHHBE.Scraps:
			GuiElementSingle<RewardDialog>.instance.KLMGKBDODBJ(MBCCLBJKAOJ, DFNCGKPNBPK);
			break;
		case IHFDGLMHHBE.DailyGold:
			break;
		}
	}

	public override void IMDBPLNFIKD()
	{
		base.IMDBPLNFIKD();
		Debug.Log("Added reward message " + MBCCLBJKAOJ);
	}

	public AGPANDBMDLC(IHFDGLMHHBE FJLBLLLEELD, NGNPIOOAHEH IGOHEBEDMFH, Card[] HGPGKHLOHEF)
		: base("RewardMessage", NKHJBLBAAEB.RewardMessage)
	{
		MBCCLBJKAOJ = FJLBLLLEELD;
		NHHGDIDEIMM += string.Format("-{0}-{1}", FJLBLLLEELD, Singleton<BeanstalkServerManager>.instance.currentTimestamp);
		INJIOGNPENB = IGOHEBEDMFH;
		OAKNNNMGEID = HGPGKHLOHEF;
	}

	public override bool HFDGKLFCBLE()
	{
		return base.HFDGKLFCBLE() || (MBCCLBJKAOJ == IHFDGLMHHBE.Lootboxes && DialogManager.instance.numberOfShownDialogues == 1 && GuiElementSingle<InappScreen>.instance.gameObject.activeSelf);
	}

	public AGPANDBMDLC(IHFDGLMHHBE FJLBLLLEELD, LevelBehaviour IOIKKIIFOCB, long IEALLELGOBM)
		: base("RewardMessage", NKHJBLBAAEB.RewardMessage)
	{
		MBCCLBJKAOJ = FJLBLLLEELD;
		NHHGDIDEIMM += string.Format("-{0}-{1}", FJLBLLLEELD, Singleton<BeanstalkServerManager>.instance.currentTimestamp);
		IFFDIHCPKFE = IOIKKIIFOCB;
		DFNCGKPNBPK = IEALLELGOBM;
	}

	public override void GEKIMGFKNHC()
	{
		base.GEKIMGFKNHC();
		switch (MBCCLBJKAOJ)
		{
		case IHFDGLMHHBE.WarCard:
			GuiElementSingle<RewardDialog>.instance.ShowDialog(MBCCLBJKAOJ, CHFHECKINPO);
			break;
		case IHFDGLMHHBE.PowerBand:
			GuiElementSingle<RewardDialog>.instance.ShowDialog(MBCCLBJKAOJ, FGIMNJOOAOB, DFNCGKPNBPK);
			break;
		case IHFDGLMHHBE.CardPack:
			GuiElementSingle<RewardDialog>.instance.ShowDialog(MBCCLBJKAOJ, INJIOGNPENB, OAKNNNMGEID);
			break;
		case IHFDGLMHHBE.Lootboxes:
			GuiElementSingle<LootBoxDialog>.instance.ShowDialogMoreBoxes(LDDKEHKEJBI, false);
			break;
		case IHFDGLMHHBE.Dogtag:
			if (MCFHJNNGKIB < StatsManager.instance.totalGames)
			{
				Debug.Log("DOGTAG REWARD DIALOG - not showing because player already played one match and spent gained dogtag");
			}
			else
			{
				GuiElementSingle<RewardDialog>.instance.ShowDialog(MBCCLBJKAOJ);
			}
			break;
		case IHFDGLMHHBE.EliteParts:
			GuiElementSingle<RewardDialog>.instance.ShowDialog(MBCCLBJKAOJ, IFFDIHCPKFE, DFNCGKPNBPK);
			break;
		case IHFDGLMHHBE.Gold:
		case IHFDGLMHHBE.Warbucks:
		case IHFDGLMHHBE.VIP:
		case IHFDGLMHHBE.Tickets:
		case IHFDGLMHHBE.Scraps:
			GuiElementSingle<RewardDialog>.instance.ShowDialog(MBCCLBJKAOJ, DFNCGKPNBPK);
			break;
		case IHFDGLMHHBE.DailyGold:
			break;
		}
	}

	public AGPANDBMDLC(IHFDGLMHHBE FJLBLLLEELD, JToken CEKHIJECPNP)
		: base("RewardMessage", NKHJBLBAAEB.RewardMessage)
	{
		MBCCLBJKAOJ = FJLBLLLEELD;
		NHHGDIDEIMM += string.Format("-{0}-{1}", FJLBLLLEELD, Singleton<BeanstalkServerManager>.instance.currentTimestamp);
		CHFHECKINPO = CEKHIJECPNP;
	}

	public AGPANDBMDLC(IHFDGLMHHBE FJLBLLLEELD, List<CCNAEIGGMNK> NMJKMJBFFFJ)
		: base("RewardMessage", NKHJBLBAAEB.RewardMessage)
	{
		MBCCLBJKAOJ = FJLBLLLEELD;
		NHHGDIDEIMM += string.Format("-{0}-{1}", FJLBLLLEELD, Singleton<BeanstalkServerManager>.instance.currentTimestamp);
		LDDKEHKEJBI = NMJKMJBFFFJ;
	}

	public AGPANDBMDLC(IHFDGLMHHBE FJLBLLLEELD)
		: base("RewardMessage", NKHJBLBAAEB.RewardMessage)
	{
		MBCCLBJKAOJ = FJLBLLLEELD;
		NHHGDIDEIMM += string.Format("-{0}-{1}", FJLBLLLEELD, Singleton<BeanstalkServerManager>.instance.currentTimestamp);
		MCFHJNNGKIB = StatsManager.instance.totalGames;
	}

	public virtual bool DGHGHCEAACD()
	{
		return !base.HFDGKLFCBLE() && (MBCCLBJKAOJ != IHFDGLMHHBE.CardPack || DialogManager.instance.numberOfShownDialogues != 1 || GuiElementSingle<InappScreen>.instance.gameObject.activeSelf);
	}
}
