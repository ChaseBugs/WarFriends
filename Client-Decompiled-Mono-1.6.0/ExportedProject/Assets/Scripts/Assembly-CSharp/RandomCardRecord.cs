using System;
using Google2u;
using UnityEngine;

public class RandomCardRecord : PoolableObject
{
	private sealed class HAPNJHJCOEA
	{
		internal Action<GameObject> IFGAGNBDKBE;

		internal void MMEEJDGGAID(GameObject KHAHPAKDIKE)
		{
			IFGAGNBDKBE(KHAHPAKDIKE);
		}

		internal void NNIJEDKBPGJ(GameObject KHAHPAKDIKE)
		{
			IFGAGNBDKBE(KHAHPAKDIKE);
		}

		internal void NAJNECOMDDN(GameObject KHAHPAKDIKE)
		{
			IFGAGNBDKBE(KHAHPAKDIKE);
		}

		internal void NDJOJHNIBFC(GameObject KHAHPAKDIKE)
		{
			IFGAGNBDKBE(KHAHPAKDIKE);
		}

		internal void MAKLHLCDIKD(GameObject KHAHPAKDIKE)
		{
			IFGAGNBDKBE(KHAHPAKDIKE);
		}

		internal void LJCDGJKCNEC(GameObject KHAHPAKDIKE)
		{
			IFGAGNBDKBE(KHAHPAKDIKE);
		}

		internal void OKNCFDMEFGJ(GameObject KHAHPAKDIKE)
		{
			IFGAGNBDKBE(KHAHPAKDIKE);
		}
	}

	[Header("GUI")]
	public UIButton AMKGEJIKJOL;

	public UILabel DMDFANNPMGO;

	public UILabel INFKHFJFFHP;

	public UILabel GMBJHOCENGD;

	public void FKJFMCJPJBC(string FCFPODPEHBO, int OPEICELHNLI, string GAJEGKHMLIJ, Action<GameObject> IFGAGNBDKBE)
	{
		HAPNJHJCOEA hAPNJHJCOEA = new HAPNJHJCOEA();
		hAPNJHJCOEA.IFGAGNBDKBE = IFGAGNBDKBE;
		INFKHFJFFHP.text = FCFPODPEHBO;
		DMDFANNPMGO.text = MEJMLNDFDBP.GMIPFLIEOHD(OPEICELHNLI);
		GMBJHOCENGD.text = GAJEGKHMLIJ;
		UIEventListener uIEventListener = UIEventListener.Get(AMKGEJIKJOL.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(hAPNJHJCOEA.MMEEJDGGAID));
	}

	private void OnClick(GameObject KHAHPAKDIKE)
	{
		CardPacksRow row = Singleton<GameVariables>.instance.cardPacks.GetRow(CardPacks.rowIds.THREE_CARDS);
		if (!Singleton<Wallet>.instance.CanBuyW(row.WARBUCKS))
		{
			GuiElementSingle<NotEnoughDialog>.instance.ShowWarbucks(row.WARBUCKS, Localization.Localize(row.NAME));
			GuiElementSingle<InappScreen>.instance.GIJGFEOICHF = "WarCards";
		}
		else
		{
			Singleton<Wallet>.instance.CDIDDJGINID(row.WARBUCKS);
			CardManager.instance.BuyThreeCards(row.WARBUCKS);
		}
	}

	public void EGIDHHONMCN(string FCFPODPEHBO, string GAJEGKHMLIJ)
	{
		INFKHFJFFHP.text = FCFPODPEHBO;
		DMDFANNPMGO.text = string.Empty + Singleton<GameVariables>.instance.OOMDGKBEMOJ().GetRow(CardPacks.rowIds.THREE_CARDS).WARBUCKS;
		GMBJHOCENGD.text = GAJEGKHMLIJ;
		UIEventListener uIEventListener = UIEventListener.Get(AMKGEJIKJOL.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(GPPCCOBLIHB));
	}

	public void CGKNIEPONAF(string FCFPODPEHBO, int OPEICELHNLI, string GAJEGKHMLIJ, Action<GameObject> IFGAGNBDKBE)
	{
		HAPNJHJCOEA hAPNJHJCOEA = new HAPNJHJCOEA();
		hAPNJHJCOEA.IFGAGNBDKBE = IFGAGNBDKBE;
		INFKHFJFFHP.text = FCFPODPEHBO;
		DMDFANNPMGO.text = MEJMLNDFDBP.GMIPFLIEOHD(OPEICELHNLI);
		GMBJHOCENGD.text = GAJEGKHMLIJ;
		UIEventListener uIEventListener = UIEventListener.Get(AMKGEJIKJOL.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(hAPNJHJCOEA.MMEEJDGGAID));
	}

	public void AFLLCFMGKLH(string FCFPODPEHBO, string GAJEGKHMLIJ)
	{
		INFKHFJFFHP.text = FCFPODPEHBO;
		DMDFANNPMGO.text = string.Empty + Singleton<GameVariables>.instance.OOMDGKBEMOJ().GetRow(CardPacks.rowIds.BRONZE_CARDPACK).WARBUCKS;
		GMBJHOCENGD.text = GAJEGKHMLIJ;
		UIEventListener uIEventListener = UIEventListener.Get(AMKGEJIKJOL.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(BCFIPPHODCL));
	}

	private void GPPCCOBLIHB(GameObject KHAHPAKDIKE)
	{
		CardPacksRow row = Singleton<GameVariables>.instance.OOMDGKBEMOJ().GetRow(CardPacks.rowIds.GOLD_CARDPACK);
		if (!Singleton<Wallet>.instance.JPEEJLCILCB(row.WARBUCKS))
		{
			GuiElementSingle<NotEnoughDialog>.instance.PNIGDOEPLHN(row.WARBUCKS, Localization.Localize(row.NAME));
			GuiElementSingle<InappScreen>.instance.ILDAMDPNBGC("#VOJTA# Empty event assignment progress for day {0}, index {1}");
		}
		else
		{
			Singleton<Wallet>.instance.BKLFEOMJMFC(row.WARBUCKS);
			CardManager.instance.BuyThreeCards(row.WARBUCKS);
		}
	}

	public void MDMDKMGCNGE(string FCFPODPEHBO, string GAJEGKHMLIJ)
	{
		INFKHFJFFHP.text = FCFPODPEHBO;
		DMDFANNPMGO.text = string.Empty + Singleton<GameVariables>.instance.cardPacks.GetRow(CardPacks.rowIds.THREE_CARDS).WARBUCKS;
		GMBJHOCENGD.text = GAJEGKHMLIJ;
		UIEventListener uIEventListener = UIEventListener.Get(AMKGEJIKJOL.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(OnClick));
	}

	private void GJEDIJFNHNC(GameObject KHAHPAKDIKE)
	{
		CardPacksRow row = Singleton<GameVariables>.instance.OOMDGKBEMOJ().GetRow(CardPacks.rowIds.BRONZE_CARDPACK);
		if (!Singleton<Wallet>.instance.JPEEJLCILCB(row.WARBUCKS))
		{
			GuiElementSingle<NotEnoughDialog>.instance.ShowWarbucks(row.WARBUCKS, Localization.Localize(row.NAME), NotEnoughDialog.NKHJBLBAAEB.UPGRADE);
			GuiElementSingle<InappScreen>.instance.ILDAMDPNBGC("#VOJTA# action success ");
		}
		else
		{
			Singleton<Wallet>.instance.CDIDDJGINID(row.WARBUCKS);
			CardManager.instance.BuyThreeCards(row.WARBUCKS);
		}
	}

	public void DBDLOKNFOGB(string FCFPODPEHBO, string GAJEGKHMLIJ)
	{
		INFKHFJFFHP.text = FCFPODPEHBO;
		DMDFANNPMGO.text = string.Empty + Singleton<GameVariables>.instance.OOMDGKBEMOJ().GetRow(CardPacks.rowIds.THREE_CARDS).WARBUCKS;
		GMBJHOCENGD.text = GAJEGKHMLIJ;
		UIEventListener uIEventListener = UIEventListener.Get(AMKGEJIKJOL.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(BONHPGOMAIA));
	}

	private void AAGKACBKKMH(GameObject KHAHPAKDIKE)
	{
		CardPacksRow row = Singleton<GameVariables>.instance.OOMDGKBEMOJ().GetRow(CardPacks.rowIds.GOLD_CARDPACK);
		if (!Singleton<Wallet>.instance.JPEEJLCILCB(row.WARBUCKS))
		{
			GuiElementSingle<NotEnoughDialog>.instance.FMGBDPKKKOO(row.WARBUCKS, Localization.Localize(row.NAME));
			GuiElementSingle<InappScreen>.instance.PDANLJJAEDC("damage");
		}
		else
		{
			Singleton<Wallet>.instance.CDIDDJGINID(row.WARBUCKS);
			CardManager.instance.BuyThreeCards(row.WARBUCKS);
		}
	}

	public void AFDPKMDLDJF(string FCFPODPEHBO, string GAJEGKHMLIJ)
	{
		INFKHFJFFHP.text = FCFPODPEHBO;
		DMDFANNPMGO.text = string.Empty + Singleton<GameVariables>.instance.cardPacks.GetRow(CardPacks.rowIds.GOLD_CARDPACK).WARBUCKS;
		GMBJHOCENGD.text = GAJEGKHMLIJ;
		UIEventListener uIEventListener = UIEventListener.Get(AMKGEJIKJOL.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(JPKFJPGFKCC));
	}

	public void ABMKAIECHFM(string FCFPODPEHBO, int OPEICELHNLI, string GAJEGKHMLIJ, Action<GameObject> IFGAGNBDKBE)
	{
		HAPNJHJCOEA hAPNJHJCOEA = new HAPNJHJCOEA();
		hAPNJHJCOEA.IFGAGNBDKBE = IFGAGNBDKBE;
		INFKHFJFFHP.text = FCFPODPEHBO;
		DMDFANNPMGO.text = MEJMLNDFDBP.GMIPFLIEOHD(OPEICELHNLI);
		GMBJHOCENGD.text = GAJEGKHMLIJ;
		UIEventListener uIEventListener = UIEventListener.Get(AMKGEJIKJOL.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(hAPNJHJCOEA.NNIJEDKBPGJ));
	}

	private void PEKBJMBOELA(GameObject KHAHPAKDIKE)
	{
		CardPacksRow row = Singleton<GameVariables>.instance.OOMDGKBEMOJ().GetRow(CardPacks.rowIds.SILVER_CARDPACK);
		if (!Singleton<Wallet>.instance.ODPFDDMFDJA(row.WARBUCKS))
		{
			GuiElementSingle<NotEnoughDialog>.instance.PNIGDOEPLHN(row.WARBUCKS, Localization.Localize(row.NAME), NotEnoughDialog.NKHJBLBAAEB.UPGRADE);
			GuiElementSingle<InappScreen>.instance.IKPEDPCLLID("*****   Bootcamp 2/3 Ended   *****");
		}
		else
		{
			Singleton<Wallet>.instance.CDIDDJGINID(row.WARBUCKS);
			CardManager.instance.BuyThreeCards(row.WARBUCKS);
		}
	}

	public void Init(string FCFPODPEHBO, string GAJEGKHMLIJ)
	{
		INFKHFJFFHP.text = FCFPODPEHBO;
		DMDFANNPMGO.text = string.Empty + Singleton<GameVariables>.instance.cardPacks.GetRow(CardPacks.rowIds.THREE_CARDS).WARBUCKS;
		GMBJHOCENGD.text = GAJEGKHMLIJ;
		UIEventListener uIEventListener = UIEventListener.Get(AMKGEJIKJOL.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(OnClick));
	}

	public void NIBDIENPOJI(string FCFPODPEHBO, string GAJEGKHMLIJ)
	{
		INFKHFJFFHP.text = FCFPODPEHBO;
		DMDFANNPMGO.text = string.Empty + Singleton<GameVariables>.instance.OOMDGKBEMOJ().GetRow((CardPacks.rowIds)7).WARBUCKS;
		GMBJHOCENGD.text = GAJEGKHMLIJ;
		UIEventListener uIEventListener = UIEventListener.Get(AMKGEJIKJOL.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(AAGKACBKKMH));
	}

	public void OFLMFBHEMHB(string FCFPODPEHBO, string GAJEGKHMLIJ)
	{
		INFKHFJFFHP.text = FCFPODPEHBO;
		DMDFANNPMGO.text = string.Empty + Singleton<GameVariables>.instance.cardPacks.GetRow((CardPacks.rowIds)8).WARBUCKS;
		GMBJHOCENGD.text = GAJEGKHMLIJ;
		UIEventListener uIEventListener = UIEventListener.Get(AMKGEJIKJOL.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(OnClick));
	}

	public void LFHEMBDNJMA(string FCFPODPEHBO, string GAJEGKHMLIJ)
	{
		INFKHFJFFHP.text = FCFPODPEHBO;
		DMDFANNPMGO.text = string.Empty + Singleton<GameVariables>.instance.OOMDGKBEMOJ().GetRow((CardPacks.rowIds)4).WARBUCKS;
		GMBJHOCENGD.text = GAJEGKHMLIJ;
		UIEventListener uIEventListener = UIEventListener.Get(AMKGEJIKJOL.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(BCFIPPHODCL));
	}

	public void HAMINNLEPLP(string FCFPODPEHBO, string GAJEGKHMLIJ)
	{
		INFKHFJFFHP.text = FCFPODPEHBO;
		DMDFANNPMGO.text = string.Empty + Singleton<GameVariables>.instance.OOMDGKBEMOJ().GetRow(CardPacks.rowIds.GOLD_CARDPACK).WARBUCKS;
		GMBJHOCENGD.text = GAJEGKHMLIJ;
		UIEventListener uIEventListener = UIEventListener.Get(AMKGEJIKJOL.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(MKLNKMIILDP));
	}

	public void KELFBJEEPAL(string FCFPODPEHBO, string GAJEGKHMLIJ)
	{
		INFKHFJFFHP.text = FCFPODPEHBO;
		DMDFANNPMGO.text = string.Empty + Singleton<GameVariables>.instance.cardPacks.GetRow(CardPacks.rowIds.SILVER_CARDPACK).WARBUCKS;
		GMBJHOCENGD.text = GAJEGKHMLIJ;
		UIEventListener uIEventListener = UIEventListener.Get(AMKGEJIKJOL.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(GPPCCOBLIHB));
	}

	public void IMDCOAKFGNP(string FCFPODPEHBO, int OPEICELHNLI, string GAJEGKHMLIJ, Action<GameObject> IFGAGNBDKBE)
	{
		HAPNJHJCOEA hAPNJHJCOEA = new HAPNJHJCOEA();
		hAPNJHJCOEA.IFGAGNBDKBE = IFGAGNBDKBE;
		INFKHFJFFHP.text = FCFPODPEHBO;
		DMDFANNPMGO.text = MEJMLNDFDBP.GMIPFLIEOHD(OPEICELHNLI);
		GMBJHOCENGD.text = GAJEGKHMLIJ;
		UIEventListener uIEventListener = UIEventListener.Get(AMKGEJIKJOL.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(hAPNJHJCOEA.MMEEJDGGAID));
	}

	public void NHMBHOIKPCM(string FCFPODPEHBO, int OPEICELHNLI, string GAJEGKHMLIJ, Action<GameObject> IFGAGNBDKBE)
	{
		HAPNJHJCOEA hAPNJHJCOEA = new HAPNJHJCOEA();
		hAPNJHJCOEA.IFGAGNBDKBE = IFGAGNBDKBE;
		INFKHFJFFHP.text = FCFPODPEHBO;
		DMDFANNPMGO.text = MEJMLNDFDBP.GMIPFLIEOHD(OPEICELHNLI);
		GMBJHOCENGD.text = GAJEGKHMLIJ;
		UIEventListener uIEventListener = UIEventListener.Get(AMKGEJIKJOL.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(hAPNJHJCOEA.LJCDGJKCNEC));
	}

	public void DMKILBIKJLC(string FCFPODPEHBO, string GAJEGKHMLIJ)
	{
		INFKHFJFFHP.text = FCFPODPEHBO;
		DMDFANNPMGO.text = string.Empty + Singleton<GameVariables>.instance.cardPacks.GetRow(CardPacks.rowIds.SILVER_CARDPACK).WARBUCKS;
		GMBJHOCENGD.text = GAJEGKHMLIJ;
		UIEventListener uIEventListener = UIEventListener.Get(AMKGEJIKJOL.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(OnClick));
	}

	public void NGKCCBEFGDD(string FCFPODPEHBO, string GAJEGKHMLIJ)
	{
		INFKHFJFFHP.text = FCFPODPEHBO;
		DMDFANNPMGO.text = string.Empty + Singleton<GameVariables>.instance.OOMDGKBEMOJ().GetRow((CardPacks.rowIds)8).WARBUCKS;
		GMBJHOCENGD.text = GAJEGKHMLIJ;
		UIEventListener uIEventListener = UIEventListener.Get(AMKGEJIKJOL.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(AAGKACBKKMH));
	}

	public void HHOOBCMCOKA(string FCFPODPEHBO, int OPEICELHNLI, string GAJEGKHMLIJ, Action<GameObject> IFGAGNBDKBE)
	{
		HAPNJHJCOEA hAPNJHJCOEA = new HAPNJHJCOEA();
		hAPNJHJCOEA.IFGAGNBDKBE = IFGAGNBDKBE;
		INFKHFJFFHP.text = FCFPODPEHBO;
		DMDFANNPMGO.text = MEJMLNDFDBP.GMIPFLIEOHD(OPEICELHNLI);
		GMBJHOCENGD.text = GAJEGKHMLIJ;
		UIEventListener uIEventListener = UIEventListener.Get(AMKGEJIKJOL.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(hAPNJHJCOEA.NNIJEDKBPGJ));
	}

	public void FKIICOCBNHN(string FCFPODPEHBO, string GAJEGKHMLIJ)
	{
		INFKHFJFFHP.text = FCFPODPEHBO;
		DMDFANNPMGO.text = string.Empty + Singleton<GameVariables>.instance.OOMDGKBEMOJ().GetRow(CardPacks.rowIds.THREE_CARDS).WARBUCKS;
		GMBJHOCENGD.text = GAJEGKHMLIJ;
		UIEventListener uIEventListener = UIEventListener.Get(AMKGEJIKJOL.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(JPKFJPGFKCC));
	}

	public void LFJMMGPOKOI(string FCFPODPEHBO, int OPEICELHNLI, string GAJEGKHMLIJ, Action<GameObject> IFGAGNBDKBE)
	{
		HAPNJHJCOEA hAPNJHJCOEA = new HAPNJHJCOEA();
		hAPNJHJCOEA.IFGAGNBDKBE = IFGAGNBDKBE;
		INFKHFJFFHP.text = FCFPODPEHBO;
		DMDFANNPMGO.text = MEJMLNDFDBP.GMIPFLIEOHD(OPEICELHNLI);
		GMBJHOCENGD.text = GAJEGKHMLIJ;
		UIEventListener uIEventListener = UIEventListener.Get(AMKGEJIKJOL.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(hAPNJHJCOEA.MAKLHLCDIKD));
	}

	private void BONHPGOMAIA(GameObject KHAHPAKDIKE)
	{
		CardPacksRow row = Singleton<GameVariables>.instance.cardPacks.GetRow(CardPacks.rowIds.BRONZE_CARDPACK);
		if (!Singleton<Wallet>.instance.JPEEJLCILCB(row.WARBUCKS))
		{
			GuiElementSingle<NotEnoughDialog>.instance.PNIGDOEPLHN(row.WARBUCKS, Localization.Localize(row.NAME));
			GuiElementSingle<InappScreen>.instance.JHNJGFIOFIH("end");
		}
		else
		{
			Singleton<Wallet>.instance.CDIDDJGINID(row.WARBUCKS);
			CardManager.instance.BuyThreeCards(row.WARBUCKS);
		}
	}

	private void IKPHBEACEKI(GameObject KHAHPAKDIKE)
	{
		CardPacksRow row = Singleton<GameVariables>.instance.cardPacks.GetRow(CardPacks.rowIds.BRONZE_CARDPACK);
		if (!Singleton<Wallet>.instance.ODPFDDMFDJA(row.WARBUCKS))
		{
			GuiElementSingle<NotEnoughDialog>.instance.FMGBDPKKKOO(row.WARBUCKS, Localization.Localize(row.NAME), NotEnoughDialog.NKHJBLBAAEB.UPGRADE);
			GuiElementSingle<InappScreen>.instance.JHNJGFIOFIH("S");
		}
		else
		{
			Singleton<Wallet>.instance.CDIDDJGINID(row.WARBUCKS);
			CardManager.instance.BuyThreeCards(row.WARBUCKS);
		}
	}

	public void ILGJBBCDPLE(string FCFPODPEHBO, int OPEICELHNLI, string GAJEGKHMLIJ, Action<GameObject> IFGAGNBDKBE)
	{
		HAPNJHJCOEA hAPNJHJCOEA = new HAPNJHJCOEA();
		hAPNJHJCOEA.IFGAGNBDKBE = IFGAGNBDKBE;
		INFKHFJFFHP.text = FCFPODPEHBO;
		DMDFANNPMGO.text = MEJMLNDFDBP.GMIPFLIEOHD(OPEICELHNLI);
		GMBJHOCENGD.text = GAJEGKHMLIJ;
		UIEventListener uIEventListener = UIEventListener.Get(AMKGEJIKJOL.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(hAPNJHJCOEA.NDJOJHNIBFC));
	}

	private void BCFIPPHODCL(GameObject KHAHPAKDIKE)
	{
		CardPacksRow row = Singleton<GameVariables>.instance.OOMDGKBEMOJ().GetRow(CardPacks.rowIds.GOLD_CARDPACK);
		if (!Singleton<Wallet>.instance.JPEEJLCILCB(row.WARBUCKS))
		{
			GuiElementSingle<NotEnoughDialog>.instance.ShowWarbucks(row.WARBUCKS, Localization.Localize(row.NAME), NotEnoughDialog.NKHJBLBAAEB.UPGRADE);
			GuiElementSingle<InappScreen>.instance.GIJGFEOICHF = "ID_NOTIFICATION_WARARENASTART{0}";
		}
		else
		{
			Singleton<Wallet>.instance.BKLFEOMJMFC(row.WARBUCKS);
			CardManager.instance.BuyThreeCards(row.WARBUCKS);
		}
	}

	public void ONACINBKALP(string FCFPODPEHBO, string GAJEGKHMLIJ)
	{
		INFKHFJFFHP.text = FCFPODPEHBO;
		DMDFANNPMGO.text = string.Empty + Singleton<GameVariables>.instance.OOMDGKBEMOJ().GetRow((CardPacks.rowIds)8).WARBUCKS;
		GMBJHOCENGD.text = GAJEGKHMLIJ;
		UIEventListener uIEventListener = UIEventListener.Get(AMKGEJIKJOL.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(BCFIPPHODCL));
	}

	public void BDOAKNIHNLJ(string FCFPODPEHBO, string GAJEGKHMLIJ)
	{
		INFKHFJFFHP.text = FCFPODPEHBO;
		DMDFANNPMGO.text = string.Empty + Singleton<GameVariables>.instance.cardPacks.GetRow(CardPacks.rowIds.GOLD_CARDPACK).WARBUCKS;
		GMBJHOCENGD.text = GAJEGKHMLIJ;
		UIEventListener uIEventListener = UIEventListener.Get(AMKGEJIKJOL.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(BCFIPPHODCL));
	}

	public void OPPKNICNNHF(string FCFPODPEHBO, string GAJEGKHMLIJ)
	{
		INFKHFJFFHP.text = FCFPODPEHBO;
		DMDFANNPMGO.text = string.Empty + Singleton<GameVariables>.instance.cardPacks.GetRow((CardPacks.rowIds)8).WARBUCKS;
		GMBJHOCENGD.text = GAJEGKHMLIJ;
		UIEventListener uIEventListener = UIEventListener.Get(AMKGEJIKJOL.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(OnClick));
	}

	public void InitButton(string FCFPODPEHBO, int OPEICELHNLI, string GAJEGKHMLIJ, Action<GameObject> IFGAGNBDKBE)
	{
		HAPNJHJCOEA hAPNJHJCOEA = new HAPNJHJCOEA();
		hAPNJHJCOEA.IFGAGNBDKBE = IFGAGNBDKBE;
		INFKHFJFFHP.text = FCFPODPEHBO;
		DMDFANNPMGO.text = MEJMLNDFDBP.GMIPFLIEOHD(OPEICELHNLI);
		GMBJHOCENGD.text = GAJEGKHMLIJ;
		UIEventListener uIEventListener = UIEventListener.Get(AMKGEJIKJOL.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(hAPNJHJCOEA.LJCDGJKCNEC));
	}

	public void FNLOMLKEIPG(string FCFPODPEHBO, int OPEICELHNLI, string GAJEGKHMLIJ, Action<GameObject> IFGAGNBDKBE)
	{
		HAPNJHJCOEA hAPNJHJCOEA = new HAPNJHJCOEA();
		hAPNJHJCOEA.IFGAGNBDKBE = IFGAGNBDKBE;
		INFKHFJFFHP.text = FCFPODPEHBO;
		DMDFANNPMGO.text = MEJMLNDFDBP.GMIPFLIEOHD(OPEICELHNLI);
		GMBJHOCENGD.text = GAJEGKHMLIJ;
		UIEventListener uIEventListener = UIEventListener.Get(AMKGEJIKJOL.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(hAPNJHJCOEA.NDJOJHNIBFC));
	}

	public void HFDMAENPNBA(string FCFPODPEHBO, int OPEICELHNLI, string GAJEGKHMLIJ, Action<GameObject> IFGAGNBDKBE)
	{
		HAPNJHJCOEA hAPNJHJCOEA = new HAPNJHJCOEA();
		hAPNJHJCOEA.IFGAGNBDKBE = IFGAGNBDKBE;
		INFKHFJFFHP.text = FCFPODPEHBO;
		DMDFANNPMGO.text = MEJMLNDFDBP.GMIPFLIEOHD(OPEICELHNLI);
		GMBJHOCENGD.text = GAJEGKHMLIJ;
		UIEventListener uIEventListener = UIEventListener.Get(AMKGEJIKJOL.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(hAPNJHJCOEA.NDJOJHNIBFC));
	}

	public void FAHCNDNFIIC(string FCFPODPEHBO, int OPEICELHNLI, string GAJEGKHMLIJ, Action<GameObject> IFGAGNBDKBE)
	{
		HAPNJHJCOEA hAPNJHJCOEA = new HAPNJHJCOEA();
		hAPNJHJCOEA.IFGAGNBDKBE = IFGAGNBDKBE;
		INFKHFJFFHP.text = FCFPODPEHBO;
		DMDFANNPMGO.text = MEJMLNDFDBP.GMIPFLIEOHD(OPEICELHNLI);
		GMBJHOCENGD.text = GAJEGKHMLIJ;
		UIEventListener uIEventListener = UIEventListener.Get(AMKGEJIKJOL.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(hAPNJHJCOEA.MMEEJDGGAID));
	}

	public void NDPABGFCDFM(string FCFPODPEHBO, int OPEICELHNLI, string GAJEGKHMLIJ, Action<GameObject> IFGAGNBDKBE)
	{
		HAPNJHJCOEA hAPNJHJCOEA = new HAPNJHJCOEA();
		hAPNJHJCOEA.IFGAGNBDKBE = IFGAGNBDKBE;
		INFKHFJFFHP.text = FCFPODPEHBO;
		DMDFANNPMGO.text = MEJMLNDFDBP.GMIPFLIEOHD(OPEICELHNLI);
		GMBJHOCENGD.text = GAJEGKHMLIJ;
		UIEventListener uIEventListener = UIEventListener.Get(AMKGEJIKJOL.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(hAPNJHJCOEA.NAJNECOMDDN));
	}

	public void AMMNCPLHICK(string FCFPODPEHBO, string GAJEGKHMLIJ)
	{
		INFKHFJFFHP.text = FCFPODPEHBO;
		DMDFANNPMGO.text = string.Empty + Singleton<GameVariables>.instance.cardPacks.GetRow(CardPacks.rowIds.SILVER_CARDPACK).WARBUCKS;
		GMBJHOCENGD.text = GAJEGKHMLIJ;
		UIEventListener uIEventListener = UIEventListener.Get(AMKGEJIKJOL.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(MKLNKMIILDP));
	}

	public void CIFFCNPEOOD(string FCFPODPEHBO, string GAJEGKHMLIJ)
	{
		INFKHFJFFHP.text = FCFPODPEHBO;
		DMDFANNPMGO.text = string.Empty + Singleton<GameVariables>.instance.OOMDGKBEMOJ().GetRow(CardPacks.rowIds.SILVER_CARDPACK).WARBUCKS;
		GMBJHOCENGD.text = GAJEGKHMLIJ;
		UIEventListener uIEventListener = UIEventListener.Get(AMKGEJIKJOL.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(MKLNKMIILDP));
	}

	private void JPKFJPGFKCC(GameObject KHAHPAKDIKE)
	{
		CardPacksRow row = Singleton<GameVariables>.instance.OOMDGKBEMOJ().GetRow(CardPacks.rowIds.THREE_CARDS);
		if (!Singleton<Wallet>.instance.JPEEJLCILCB(row.WARBUCKS))
		{
			GuiElementSingle<NotEnoughDialog>.instance.FMGBDPKKKOO(row.WARBUCKS, Localization.Localize(row.NAME), NotEnoughDialog.NKHJBLBAAEB.UPGRADE);
			GuiElementSingle<InappScreen>.instance.OABAHBKJFDK("Cards on saved data: ");
		}
		else
		{
			Singleton<Wallet>.instance.BKLFEOMJMFC(row.WARBUCKS);
			CardManager.instance.BuyThreeCards(row.WARBUCKS);
		}
	}

	public void DFPEMJOLONE(string FCFPODPEHBO, string GAJEGKHMLIJ)
	{
		INFKHFJFFHP.text = FCFPODPEHBO;
		DMDFANNPMGO.text = string.Empty + Singleton<GameVariables>.instance.OOMDGKBEMOJ().GetRow(CardPacks.rowIds.SILVER_CARDPACK).WARBUCKS;
		GMBJHOCENGD.text = GAJEGKHMLIJ;
		UIEventListener uIEventListener = UIEventListener.Get(AMKGEJIKJOL.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(BCFIPPHODCL));
	}

	private void MKLNKMIILDP(GameObject KHAHPAKDIKE)
	{
		CardPacksRow row = Singleton<GameVariables>.instance.cardPacks.GetRow((CardPacks.rowIds)5);
		if (!Singleton<Wallet>.instance.ODPFDDMFDJA(row.WARBUCKS))
		{
			GuiElementSingle<NotEnoughDialog>.instance.LOLEHDIPPIF(row.WARBUCKS, Localization.Localize(row.NAME));
			GuiElementSingle<InappScreen>.instance.IKPEDPCLLID("Near avoid !! ");
		}
		else
		{
			Singleton<Wallet>.instance.BKLFEOMJMFC(row.WARBUCKS);
			CardManager.instance.BuyThreeCards(row.WARBUCKS);
		}
	}
}
