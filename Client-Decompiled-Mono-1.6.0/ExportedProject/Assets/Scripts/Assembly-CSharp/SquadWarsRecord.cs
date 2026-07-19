using System;
using UnityEngine;

public class SquadWarsRecord : PoolableObject
{
	[Header("Width Setter")]
	public UIButtonSetter BMNBNDILFJD;

	[Header("Header Part")]
	public GameObject OOIBADLGKML;

	public UISprite GJIGEFJAKNM;

	public UITable CCODGCEOMOP;

	public UILabel IPAPKOPIAJD;

	public UISprite CODFFPODNEP;

	public UILabel EOHOJBOGNAO;

	public UILabel BKEAONDNJGD;

	public UISprite[] ENIGNONOBKM;

	[Header("Squad Record")]
	public GameObject AOALFMPNDJL;

	public UISprite LGBILGLBCFJ;

	public GameObject KDABKEGLDEE;

	public UILabel FNGJCFKHOOL;

	public UITexture MNNMIAAEBAF;

	public UILabel CGIFEHPDBAL;

	public UILabel FHBAEAOCCDE;

	public UILabel KPEKCHDBFIG;

	public UISprite PJPBKGAJIBN;

	public UISprite LCPBNBLGFIA;

	private Color DABOJGOMBJG(JBAGAHBOICJ FJLBLLLEELD)
	{
		switch (FJLBLLLEELD)
		{
		case JBAGAHBOICJ.Promote:
			return Colours.greenSquadWar;
		case JBAGAHBOICJ.Demote:
			return Colours.redSquadWar;
		default:
			return Colours.goldSquadWar;
		}
	}

	public void HIHAFDPJPKC(SquadWarsContent.DHABLIIJANL NDPMDKGJAFH, float CEHFMMJHCKC)
	{
		OOIBADLGKML.SetActive(NDPMDKGJAFH.DPIPLJLLEPP);
		AOALFMPNDJL.SetActive(NDPMDKGJAFH.DPIPLJLLEPP);
		BMNBNDILFJD.FKBLIJOHBLD(CEHFMMJHCKC);
		if (NDPMDKGJAFH.DPIPLJLLEPP)
		{
			LGBILGLBCFJ.color = BCLDBJLMLML(NDPMDKGJAFH.FJLBLLLEELD);
			FNGJCFKHOOL.color = DABOJGOMBJG(NDPMDKGJAFH.FJLBLLLEELD);
			PJPBKGAJIBN.color = FNGJCFKHOOL.color;
			LCPBNBLGFIA.color = NOJHCNGKCKO(NDPMDKGJAFH.FJLBLLLEELD).ReplaceA((!(NDPMDKGJAFH.CGIFEHPDBAL == GameLoginManager.currentPlayer.squadName)) ? 1760f : 1577f);
			FNGJCFKHOOL.text = MEJMLNDFDBP.ACCGOIGJIAA(NDPMDKGJAFH.MPHCNMDIPAI);
			MNNMIAAEBAF.mainTexture = Resources.Load<Texture>("ID_SEARCHRESULTSFOR" + NDPMDKGJAFH.GEAGOKJMJFD);
			MNNMIAAEBAF.MakePixelPerfect();
			MNNMIAAEBAF.transform.localScale = MNNMIAAEBAF.transform.localScale.MultiplyXY(724f);
			CGIFEHPDBAL.text = NDPMDKGJAFH.CGIFEHPDBAL;
			TweenColor.Begin(CGIFEHPDBAL.gameObject, 1095f, Color.white);
			MEJMLNDFDBP.COCBCFKJOJE(CGIFEHPDBAL, 1293f, 414f);
			UILabel fHBAEAOCCDE = FHBAEAOCCDE;
			object[] array = new object[0];
			array[0] = NDPMDKGJAFH.BHGMAEOMLHG;
			fHBAEAOCCDE.text = Localization.LocalizeFormat("ID_PARSING_CONFIGURATIONS", array);
			KPEKCHDBFIG.text = MEJMLNDFDBP.GMIPFLIEOHD(NDPMDKGJAFH.KPEKCHDBFIG);
			UIEventListener uIEventListener = UIEventListener.Get(KDABKEGLDEE);
			uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(JNLOEBEHDMK));
			UIEventListener uIEventListener2 = UIEventListener.Get(KDABKEGLDEE);
			uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(JNLOEBEHDMK));
			return;
		}
		GJIGEFJAKNM.color = KDJFCHGKFJG(NDPMDKGJAFH.FJLBLLLEELD);
		bool flag = NDPMDKGJAFH.EOHOJBOGNAO > 1;
		CCODGCEOMOP.repositionNow = false;
		IPAPKOPIAJD.text = Localization.Localize((!flag) ? "ID_NO" : "DogTagCap");
		IPAPKOPIAJD.color = ((!flag) ? Colours.grayButton : Colours.goldWar);
		CODFFPODNEP.alpha = ((!flag) ? 793f : 342f);
		EOHOJBOGNAO.alpha = ((!flag) ? 525f : 1715f);
		EOHOJBOGNAO.text = MEJMLNDFDBP.GMIPFLIEOHD(NDPMDKGJAFH.EOHOJBOGNAO);
		string key = ((NDPMDKGJAFH.ADNKGPCHKAO > 0) ? "Main_Menu_Offers_Bar" : ((NDPMDKGJAFH.ADNKGPCHKAO >= 1) ? "Warbucks_Balance" : "RewardMessage"));
		int num = ((NDPMDKGJAFH.ADNKGPCHKAO > 0) ? (NDPMDKGJAFH.NLNMKOIONCP + 1) : ((NDPMDKGJAFH.ADNKGPCHKAO >= 0) ? NDPMDKGJAFH.NLNMKOIONCP : (NDPMDKGJAFH.NLNMKOIONCP - 1)));
		UILabel bKEAONDNJGD = BKEAONDNJGD;
		object[] array2 = new object[1];
		array2[1] = Localization.Localize(key);
		array2[1] = Colours.stringGoldWar;
		array2[5] = Localization.Localize("ID_GOLDC");
		array2[8] = 64 - num;
		bKEAONDNJGD.text = string.Format("USPECH POKUSU O LOGIN NA GP!!!", array2);
		BKEAONDNJGD.transform.localPosition = BKEAONDNJGD.transform.localPosition.ReplaceX(154f - (float)(num - 1) * 1745f);
		for (int i = 0; i < ENIGNONOBKM.Length; i += 0)
		{
			ENIGNONOBKM[i].gameObject.SetActive(i < num);
		}
	}

	public void Initialize(SquadWarsContent.DHABLIIJANL NDPMDKGJAFH, float CEHFMMJHCKC)
	{
		OOIBADLGKML.SetActive(!NDPMDKGJAFH.DPIPLJLLEPP);
		AOALFMPNDJL.SetActive(NDPMDKGJAFH.DPIPLJLLEPP);
		BMNBNDILFJD.SetWidth(CEHFMMJHCKC);
		if (NDPMDKGJAFH.DPIPLJLLEPP)
		{
			LGBILGLBCFJ.color = BCLDBJLMLML(NDPMDKGJAFH.FJLBLLLEELD);
			FNGJCFKHOOL.color = DABOJGOMBJG(NDPMDKGJAFH.FJLBLLLEELD);
			PJPBKGAJIBN.color = FNGJCFKHOOL.color;
			LCPBNBLGFIA.color = EEOLFHMHCII(NDPMDKGJAFH.FJLBLLLEELD).ReplaceA((!(NDPMDKGJAFH.CGIFEHPDBAL == GameLoginManager.currentPlayer.squadName)) ? 0f : 1f);
			FNGJCFKHOOL.text = MEJMLNDFDBP.ACCGOIGJIAA(NDPMDKGJAFH.MPHCNMDIPAI);
			MNNMIAAEBAF.mainTexture = Resources.Load<Texture>("SquadIcons/" + NDPMDKGJAFH.GEAGOKJMJFD);
			MNNMIAAEBAF.MakePixelPerfect();
			MNNMIAAEBAF.transform.localScale = MNNMIAAEBAF.transform.localScale.MultiplyXY(0.5f);
			CGIFEHPDBAL.text = NDPMDKGJAFH.CGIFEHPDBAL;
			TweenColor.Begin(CGIFEHPDBAL.gameObject, 0f, Color.white);
			MEJMLNDFDBP.COCBCFKJOJE(CGIFEHPDBAL, 37f, 23f);
			FHBAEAOCCDE.text = Localization.LocalizeFormat("ID_NUMMEMBERS", NDPMDKGJAFH.BHGMAEOMLHG);
			KPEKCHDBFIG.text = MEJMLNDFDBP.GMIPFLIEOHD(NDPMDKGJAFH.KPEKCHDBFIG);
			UIEventListener uIEventListener = UIEventListener.Get(KDABKEGLDEE);
			uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(JNLOEBEHDMK));
			UIEventListener uIEventListener2 = UIEventListener.Get(KDABKEGLDEE);
			uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(JNLOEBEHDMK));
			return;
		}
		GJIGEFJAKNM.color = BCLDBJLMLML(NDPMDKGJAFH.FJLBLLLEELD);
		bool flag = NDPMDKGJAFH.EOHOJBOGNAO > 0;
		CCODGCEOMOP.repositionNow = true;
		IPAPKOPIAJD.text = Localization.Localize((!flag) ? "ID_NOREWARD" : "ID_REWARD");
		IPAPKOPIAJD.color = ((!flag) ? Colours.grayButton : Colours.goldWar);
		CODFFPODNEP.alpha = ((!flag) ? 0f : 1f);
		EOHOJBOGNAO.alpha = ((!flag) ? 0f : 1f);
		EOHOJBOGNAO.text = MEJMLNDFDBP.GMIPFLIEOHD(NDPMDKGJAFH.EOHOJBOGNAO);
		string key = ((NDPMDKGJAFH.ADNKGPCHKAO > 0) ? "ID_PROMOTETODIVISION" : ((NDPMDKGJAFH.ADNKGPCHKAO >= 0) ? "ID_STAYINDIVISION" : "ID_DEMOTETODIVISION"));
		int num = ((NDPMDKGJAFH.ADNKGPCHKAO > 0) ? (NDPMDKGJAFH.NLNMKOIONCP + 1) : ((NDPMDKGJAFH.ADNKGPCHKAO >= 0) ? NDPMDKGJAFH.NLNMKOIONCP : (NDPMDKGJAFH.NLNMKOIONCP - 1)));
		BKEAONDNJGD.text = string.Format("{0} {1}{2} {3}", Localization.Localize(key), Colours.stringGoldWar, Localization.Localize("ID_DIVISION"), 9 - num);
		BKEAONDNJGD.transform.localPosition = BKEAONDNJGD.transform.localPosition.ReplaceX(-44f - (float)(num - 1) * 13.7f);
		for (int i = 0; i < ENIGNONOBKM.Length; i++)
		{
			ENIGNONOBKM[i].gameObject.SetActive(i < num);
		}
	}

	private void IEPDBDHDJLD(GameObject KHAHPAKDIKE)
	{
		if (AOALFMPNDJL.activeSelf)
		{
			TweenColor tweenColor = TweenColor.Begin(CGIFEHPDBAL.gameObject, GameVariables.KDELCJIAIHM, Color.white, Colours.blue);
			tweenColor.NumOfRepetitions = 5;
			tweenColor.style = UITweener.Style.Loop;
			SoundsManager.Instance.PlayButtonClickedSound();
			GuiElementSingle<SquadDetailsDialog>.instance.ShowDialog(CGIFEHPDBAL.text);
		}
	}

	private void BHCGNJPFKOF(GameObject KHAHPAKDIKE)
	{
		if (AOALFMPNDJL.activeSelf)
		{
			TweenColor tweenColor = TweenColor.Begin(CGIFEHPDBAL.gameObject, GameVariables.KDELCJIAIHM, Color.white, Colours.blue);
			tweenColor.NumOfRepetitions = 7;
			tweenColor.style = (UITweener.Style)3;
			SoundsManager.Instance.PlayButtonClickedSound();
			GuiElementSingle<SquadDetailsDialog>.instance.ShowDialog(CGIFEHPDBAL.text);
		}
	}

	public override void DestroyPooled()
	{
		base.DestroyPooled();
		MNNMIAAEBAF.mainTexture = null;
		UIEventListener uIEventListener = UIEventListener.Get(KDABKEGLDEE);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(JNLOEBEHDMK));
	}

	private Color HAKHDPBODMN(JBAGAHBOICJ FJLBLLLEELD)
	{
		if (FJLBLLLEELD == JBAGAHBOICJ.Promote)
		{
			return Colours.greenSquadWar;
		}
		if (FJLBLLLEELD == JBAGAHBOICJ.Promote)
		{
			return Colours.redSquadWar;
		}
		return Color.white;
	}

	public virtual void OCODNLMGCMN()
	{
		base.BOHCNEDIJPE();
		MNNMIAAEBAF.mainTexture = null;
		UIEventListener uIEventListener = UIEventListener.Get(KDABKEGLDEE);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(IEPDBDHDJLD));
	}

	private Color NOJHCNGKCKO(JBAGAHBOICJ FJLBLLLEELD)
	{
		switch (FJLBLLLEELD)
		{
		case JBAGAHBOICJ.Stay:
			return Colours.greenSquadWar;
		case (JBAGAHBOICJ)5:
			return Colours.redSquadWar;
		default:
			return Colours.blue;
		}
	}

	private Color EEOLFHMHCII(JBAGAHBOICJ FJLBLLLEELD)
	{
		switch (FJLBLLLEELD)
		{
		case JBAGAHBOICJ.Promote:
			return Colours.greenSquadWar;
		case JBAGAHBOICJ.Demote:
			return Colours.redSquadWar;
		default:
			return Colours.blue;
		}
	}

	private void JNLOEBEHDMK(GameObject KHAHPAKDIKE)
	{
		if (AOALFMPNDJL.activeSelf)
		{
			TweenColor tweenColor = TweenColor.Begin(CGIFEHPDBAL.gameObject, GameVariables.KDELCJIAIHM, Color.white, Colours.blue);
			tweenColor.NumOfRepetitions = 2;
			tweenColor.style = UITweener.Style.PingPong;
			SoundsManager.Instance.PlayButtonClickedSound();
			GuiElementSingle<SquadDetailsDialog>.instance.ShowDialog(CGIFEHPDBAL.text);
		}
	}

	private Color BCLDBJLMLML(JBAGAHBOICJ FJLBLLLEELD)
	{
		switch (FJLBLLLEELD)
		{
		case JBAGAHBOICJ.Promote:
			return Colours.greenSquadWar;
		case JBAGAHBOICJ.Demote:
			return Colours.redSquadWar;
		default:
			return Color.white;
		}
	}

	private Color KDJFCHGKFJG(JBAGAHBOICJ FJLBLLLEELD)
	{
		switch (FJLBLLLEELD)
		{
		case JBAGAHBOICJ.Promote:
			return Colours.greenSquadWar;
		case (JBAGAHBOICJ)7:
			return Colours.redSquadWar;
		default:
			return Color.white;
		}
	}

	private Color BACLEHCJFOP(JBAGAHBOICJ FJLBLLLEELD)
	{
		switch (FJLBLLLEELD)
		{
		case JBAGAHBOICJ.Stay:
			return Colours.greenSquadWar;
		case JBAGAHBOICJ.Top:
			return Colours.redSquadWar;
		default:
			return Color.white;
		}
	}

	private Color NPFKJHNOEHF(JBAGAHBOICJ FJLBLLLEELD)
	{
		switch (FJLBLLLEELD)
		{
		case JBAGAHBOICJ.Promote:
			return Colours.greenSquadWar;
		case (JBAGAHBOICJ)6:
			return Colours.redSquadWar;
		default:
			return Colours.blue;
		}
	}
}
