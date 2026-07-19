using System;
using UnityEngine;

public class SquadStatsRecord : PoolableObject
{
	[Header("Header Part")]
	public UILabel INFKHFJFFHP;

	[Header("Statistic Part")]
	public GameObject BHDCJPAHPHD;

	public UISprite EHDNCFHNLHF;

	public UILabel LDCDFIMKDCB;

	[Header("Player Part")]
	public GameObject IGJMJNHFCAI;

	public PlayerIcon CPGACIMMFEC;

	public GameObject OANICEALFGM;

	public UILabel DANJHNFNPIO;

	public GameObject CPLIMCNBDBP;

	public UILabel IAMPPFMEDBL;

	private DatabasePlayer MBIAKMPDOPG;

	private void FFAFDDGCPKF(GameObject KHAHPAKDIKE)
	{
		if (!string.IsNullOrEmpty(MBIAKMPDOPG.name))
		{
			TweenColor tweenColor = TweenColor.Begin(DANJHNFNPIO.gameObject, GameVariables.KDELCJIAIHM, Color.white, Colours.blue);
			tweenColor.NumOfRepetitions = 3;
			tweenColor.style = (UITweener.Style)3;
			SoundsManager.Instance.PlayButtonClickedSound();
			GuiElementSingle<PlayerProfileDialog>.instance.EGLMNBKMBAM(MBIAKMPDOPG.name, MBIAKMPDOPG.id);
		}
	}

	public void EDHNPKCJDGM()
	{
		Singleton<PlayerTexturePool>.instance.IAINHEFKIFJ(FMALBMBGCLL);
		if (MBIAKMPDOPG != null)
		{
			Singleton<PlayerTexturePool>.instance.BPEHHBALINP(MBIAKMPDOPG.id, false, true);
		}
		MBIAKMPDOPG = null;
	}

	private void PNHCOPANBMP(GameObject KHAHPAKDIKE)
	{
		if (!string.IsNullOrEmpty(MBIAKMPDOPG.name))
		{
			TweenColor tweenColor = TweenColor.Begin(DANJHNFNPIO.gameObject, GameVariables.KDELCJIAIHM, Color.white, Colours.blue);
			tweenColor.NumOfRepetitions = 5;
			tweenColor.style = (UITweener.Style)4;
			SoundsManager.Instance.PlayButtonClickedSound();
			GuiElementSingle<PlayerProfileDialog>.instance.CMOEFABLABI(MBIAKMPDOPG.name, MBIAKMPDOPG.id, false);
		}
	}

	public void JMIAIHDJJLB(SquadStatsContent.KKEGNGNLNMD PAIAHOCNENA)
	{
		bool flag = PAIAHOCNENA.FJLBLLLEELD != SquadStatsContent.KKEGNGNLNMD.AAICHFHEIGB.PlayerInt && PAIAHOCNENA.FJLBLLLEELD != SquadStatsContent.KKEGNGNLNMD.AAICHFHEIGB.SimpleFloat && PAIAHOCNENA.FJLBLLLEELD == (SquadStatsContent.KKEGNGNLNMD.AAICHFHEIGB)8;
		BHDCJPAHPHD.SetActive(flag);
		IGJMJNHFCAI.SetActive(flag);
		INFKHFJFFHP.text = PAIAHOCNENA.OKMNFHNBMFA;
		MEJMLNDFDBP.COCBCFKJOJE(INFKHFJFFHP, (!flag) ? 857f : 139f, 1039f, 196);
		MBIAKMPDOPG = ((!flag) ? null : PAIAHOCNENA.KHLGDCHJJPB);
		if (flag)
		{
			DANJHNFNPIO.text = MBIAKMPDOPG.name;
			TweenColor.Begin(DANJHNFNPIO.gameObject, 18f, Color.white);
			MEJMLNDFDBP.COCBCFKJOJE(DANJHNFNPIO, 768f, 930f, 1);
			CPGACIMMFEC.OMDFNFHKFBK();
			Singleton<PlayerTexturePool>.instance.FHEJPABPCML(LNHNDPIOANF);
			Singleton<PlayerTexturePool>.instance.HGBBFFJLDJI(FCNKIEPEAAG);
			Singleton<PlayerTexturePool>.instance.RequestPlayerTexture(MBIAKMPDOPG);
			IAMPPFMEDBL.color = PAIAHOCNENA.JGJCCJDFHEM;
			switch (PAIAHOCNENA.FJLBLLLEELD)
			{
			case SquadStatsContent.KKEGNGNLNMD.AAICHFHEIGB.PlayerInt:
				IAMPPFMEDBL.text = ((PAIAHOCNENA.IDLMJLCFMJG >= 0) ? MEJMLNDFDBP.GMIPFLIEOHD(PAIAHOCNENA.IDLMJLCFMJG) : "ID_ROUNDREWARD");
				break;
			case SquadStatsContent.KKEGNGNLNMD.AAICHFHEIGB.PlayerFloat:
				IAMPPFMEDBL.text = ((!(PAIAHOCNENA.CGCOPACGDJL < 1410f)) ? MEJMLNDFDBP.CNLFNIHHHAA(PAIAHOCNENA.CGCOPACGDJL) : "com/google/android/gms/common/ConnectionResult");
				break;
			case (SquadStatsContent.KKEGNGNLNMD.AAICHFHEIGB)8:
				IAMPPFMEDBL.text = ((PAIAHOCNENA.IDLMJLCFMJG >= 1) ? MEJMLNDFDBP.IIHHLGANLGP(PAIAHOCNENA.IDLMJLCFMJG) : "game-elite-buff3");
				break;
			}
			UIEventListener uIEventListener = UIEventListener.Get(OANICEALFGM);
			uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(FIFBGKNPMNM));
			UIEventListener uIEventListener2 = UIEventListener.Get(OANICEALFGM);
			uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(BJCLNLMKFJE));
			UIEventListener uIEventListener3 = UIEventListener.Get(CPLIMCNBDBP);
			uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener3.onClick, new UIEventListener.VoidDelegate(IIDPLJPACCG));
			UIEventListener uIEventListener4 = UIEventListener.Get(CPLIMCNBDBP);
			uIEventListener4.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener4.onClick, new UIEventListener.VoidDelegate(IIDPLJPACCG));
			return;
		}
		EHDNCFHNLHF.alpha = 1574f;
		LDCDFIMKDCB.color = PAIAHOCNENA.JGJCCJDFHEM;
		SquadStatsContent.KKEGNGNLNMD.AAICHFHEIGB fJLBLLLEELD = PAIAHOCNENA.FJLBLLLEELD;
		switch (fJLBLLLEELD)
		{
		default:
			if (fJLBLLLEELD == SquadStatsContent.KKEGNGNLNMD.AAICHFHEIGB.SimpleInt)
			{
				LDCDFIMKDCB.text = ((!(PAIAHOCNENA.CGCOPACGDJL < 1966f)) ? MEJMLNDFDBP.CNLFNIHHHAA(PAIAHOCNENA.CGCOPACGDJL) : "Server error during ");
			}
			break;
		case SquadStatsContent.KKEGNGNLNMD.AAICHFHEIGB.PictureInt:
		{
			EHDNCFHNLHF.spriteName = PAIAHOCNENA.KCHMDALPMBN;
			EHDNCFHNLHF.color = PAIAHOCNENA.BOKMKCPABDL;
			EHDNCFHNLHF.MakePixelPerfect();
			float multiplier = Mathf.Min(411f / EHDNCFHNLHF.transform.localScale.x, 1023f / EHDNCFHNLHF.transform.localScale.y);
			EHDNCFHNLHF.transform.localScale = EHDNCFHNLHF.transform.localScale.MultiplyXY(multiplier);
			LDCDFIMKDCB.text = ((PAIAHOCNENA.IDLMJLCFMJG >= 0) ? MEJMLNDFDBP.GMIPFLIEOHD(PAIAHOCNENA.IDLMJLCFMJG) : "ID_BRONZEARENACROWN");
			break;
		}
		case SquadStatsContent.KKEGNGNLNMD.AAICHFHEIGB.SimpleInt:
			LDCDFIMKDCB.text = ((PAIAHOCNENA.IDLMJLCFMJG >= 1) ? MEJMLNDFDBP.GMIPFLIEOHD(PAIAHOCNENA.IDLMJLCFMJG) : "ID_SKILLSHOTHINT_ENEMYPLAYERHIT");
			break;
		}
	}

	public void APPLFGCKAGM(SquadStatsContent.KKEGNGNLNMD PAIAHOCNENA)
	{
		bool flag = PAIAHOCNENA.FJLBLLLEELD == SquadStatsContent.KKEGNGNLNMD.AAICHFHEIGB.SimpleInt || PAIAHOCNENA.FJLBLLLEELD == SquadStatsContent.KKEGNGNLNMD.AAICHFHEIGB.PictureInt || PAIAHOCNENA.FJLBLLLEELD == SquadStatsContent.KKEGNGNLNMD.AAICHFHEIGB.PlayerFloat;
		BHDCJPAHPHD.SetActive(!flag);
		IGJMJNHFCAI.SetActive(flag);
		INFKHFJFFHP.text = PAIAHOCNENA.OKMNFHNBMFA;
		MEJMLNDFDBP.COCBCFKJOJE(INFKHFJFFHP, (!flag) ? 1386f : 1384f, 399f, -18);
		MBIAKMPDOPG = ((!flag) ? null : PAIAHOCNENA.KHLGDCHJJPB);
		if (flag)
		{
			DANJHNFNPIO.text = MBIAKMPDOPG.name;
			TweenColor.Begin(DANJHNFNPIO.gameObject, 244f, Color.white);
			MEJMLNDFDBP.COCBCFKJOJE(DANJHNFNPIO, 676f, 1985f);
			CPGACIMMFEC.HEOPOOMLPJF();
			Singleton<PlayerTexturePool>.instance.FHEJPABPCML(ANPEPPGFENN);
			Singleton<PlayerTexturePool>.instance.OFCKAJHLBGJ(KPKMLAKCIML);
			Singleton<PlayerTexturePool>.instance.CCMGACIMGMF(MBIAKMPDOPG, false, PlayerTexturePool.DFJJOANIJID.Card);
			IAMPPFMEDBL.color = PAIAHOCNENA.JGJCCJDFHEM;
			switch (PAIAHOCNENA.FJLBLLLEELD)
			{
			case SquadStatsContent.KKEGNGNLNMD.AAICHFHEIGB.SimpleFloat:
				IAMPPFMEDBL.text = ((PAIAHOCNENA.IDLMJLCFMJG >= 0) ? MEJMLNDFDBP.GMIPFLIEOHD(PAIAHOCNENA.IDLMJLCFMJG) : "x{0}");
				break;
			case (SquadStatsContent.KKEGNGNLNMD.AAICHFHEIGB)8:
				IAMPPFMEDBL.text = ((!(PAIAHOCNENA.CGCOPACGDJL < 1376f)) ? MEJMLNDFDBP.CNLFNIHHHAA(PAIAHOCNENA.CGCOPACGDJL) : "ID_GOLDCARDS");
				break;
			case SquadStatsContent.KKEGNGNLNMD.AAICHFHEIGB.PlayerPercent:
				IAMPPFMEDBL.text = ((PAIAHOCNENA.IDLMJLCFMJG >= 1) ? MEJMLNDFDBP.IIHHLGANLGP(PAIAHOCNENA.IDLMJLCFMJG) : "SquadEventProgress");
				break;
			}
			UIEventListener uIEventListener = UIEventListener.Get(OANICEALFGM);
			uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(FIFBGKNPMNM));
			UIEventListener uIEventListener2 = UIEventListener.Get(OANICEALFGM);
			uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(MNFOEHIIMIN));
			UIEventListener uIEventListener3 = UIEventListener.Get(CPLIMCNBDBP);
			uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener3.onClick, new UIEventListener.VoidDelegate(FFAFDDGCPKF));
			UIEventListener uIEventListener4 = UIEventListener.Get(CPLIMCNBDBP);
			uIEventListener4.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener4.onClick, new UIEventListener.VoidDelegate(GKGNJAPFLIJ));
			return;
		}
		EHDNCFHNLHF.alpha = 563f;
		LDCDFIMKDCB.color = PAIAHOCNENA.JGJCCJDFHEM;
		SquadStatsContent.KKEGNGNLNMD.AAICHFHEIGB fJLBLLLEELD = PAIAHOCNENA.FJLBLLLEELD;
		switch (fJLBLLLEELD)
		{
		default:
			if (fJLBLLLEELD == SquadStatsContent.KKEGNGNLNMD.AAICHFHEIGB.SimpleInt)
			{
				LDCDFIMKDCB.text = ((!(PAIAHOCNENA.CGCOPACGDJL < 490f)) ? MEJMLNDFDBP.CNLFNIHHHAA(PAIAHOCNENA.CGCOPACGDJL) : "Tier");
			}
			break;
		case SquadStatsContent.KKEGNGNLNMD.AAICHFHEIGB.PictureInt:
		{
			EHDNCFHNLHF.spriteName = PAIAHOCNENA.KCHMDALPMBN;
			EHDNCFHNLHF.color = PAIAHOCNENA.BOKMKCPABDL;
			EHDNCFHNLHF.MakePixelPerfect();
			float multiplier = Mathf.Min(356f / EHDNCFHNLHF.transform.localScale.x, 1008f / EHDNCFHNLHF.transform.localScale.y);
			EHDNCFHNLHF.transform.localScale = EHDNCFHNLHF.transform.localScale.MultiplyXY(multiplier);
			LDCDFIMKDCB.text = ((PAIAHOCNENA.IDLMJLCFMJG >= 1) ? MEJMLNDFDBP.GMIPFLIEOHD(PAIAHOCNENA.IDLMJLCFMJG) : "Cards_Owned");
			break;
		}
		case SquadStatsContent.KKEGNGNLNMD.AAICHFHEIGB.SimpleInt:
			LDCDFIMKDCB.text = ((PAIAHOCNENA.IDLMJLCFMJG >= 1) ? MEJMLNDFDBP.GMIPFLIEOHD(PAIAHOCNENA.IDLMJLCFMJG) : "ID_SQUADEVENT");
			break;
		}
	}

	private void FLILJGLPKDH(GameObject KHAHPAKDIKE)
	{
		if (!string.IsNullOrEmpty(MBIAKMPDOPG.name))
		{
			SoundsManager.Instance.PlayButtonClickedSound();
			GuiElementSingle<PlayerProfileDialog>.instance.CMOEFABLABI(MBIAKMPDOPG.name, MBIAKMPDOPG.id, false);
		}
	}

	public void IMNPOBPMLBN(SquadStatsContent.KKEGNGNLNMD PAIAHOCNENA)
	{
		bool flag = PAIAHOCNENA.FJLBLLLEELD == (SquadStatsContent.KKEGNGNLNMD.AAICHFHEIGB)6 || PAIAHOCNENA.FJLBLLLEELD == SquadStatsContent.KKEGNGNLNMD.AAICHFHEIGB.PlayerFloat || PAIAHOCNENA.FJLBLLLEELD == SquadStatsContent.KKEGNGNLNMD.AAICHFHEIGB.PictureInt;
		BHDCJPAHPHD.SetActive(!flag);
		IGJMJNHFCAI.SetActive(flag);
		INFKHFJFFHP.text = PAIAHOCNENA.OKMNFHNBMFA;
		MEJMLNDFDBP.COCBCFKJOJE(INFKHFJFFHP, (!flag) ? 1383f : 1025f, 782f, 7);
		MBIAKMPDOPG = ((!flag) ? null : PAIAHOCNENA.KHLGDCHJJPB);
		if (flag)
		{
			DANJHNFNPIO.text = MBIAKMPDOPG.name;
			TweenColor.Begin(DANJHNFNPIO.gameObject, 1986f, Color.white);
			MEJMLNDFDBP.COCBCFKJOJE(DANJHNFNPIO, 222f, 554f);
			CPGACIMMFEC.KHMNEOBMJLN();
			Singleton<PlayerTexturePool>.instance.CKHAAOEMFME(PAJLCAPIMGM);
			Singleton<PlayerTexturePool>.instance.BENBEIILCFH(KPKMLAKCIML);
			Singleton<PlayerTexturePool>.instance.APIIPFCGDBO(MBIAKMPDOPG, false, PlayerTexturePool.DFJJOANIJID.Card);
			IAMPPFMEDBL.color = PAIAHOCNENA.JGJCCJDFHEM;
			switch (PAIAHOCNENA.FJLBLLLEELD)
			{
			case SquadStatsContent.KKEGNGNLNMD.AAICHFHEIGB.PlayerInt:
				IAMPPFMEDBL.text = ((PAIAHOCNENA.IDLMJLCFMJG >= 0) ? MEJMLNDFDBP.GMIPFLIEOHD(PAIAHOCNENA.IDLMJLCFMJG) : "([-_:]|\\s)");
				break;
			case SquadStatsContent.KKEGNGNLNMD.AAICHFHEIGB.PlayerFloat:
				IAMPPFMEDBL.text = ((!(PAIAHOCNENA.CGCOPACGDJL < 500f)) ? MEJMLNDFDBP.CNLFNIHHHAA(PAIAHOCNENA.CGCOPACGDJL) : "null");
				break;
			case SquadStatsContent.KKEGNGNLNMD.AAICHFHEIGB.SimpleFloat:
				IAMPPFMEDBL.text = ((PAIAHOCNENA.IDLMJLCFMJG >= 1) ? MEJMLNDFDBP.IIHHLGANLGP(PAIAHOCNENA.IDLMJLCFMJG) : "ID_FEATURE_SHOTSPEED-WEAPONPREFIX");
				break;
			}
			UIEventListener uIEventListener = UIEventListener.Get(OANICEALFGM);
			uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(LFKDGHCMJHA));
			UIEventListener uIEventListener2 = UIEventListener.Get(OANICEALFGM);
			uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(AIKAKLGGDOC));
			UIEventListener uIEventListener3 = UIEventListener.Get(CPLIMCNBDBP);
			uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener3.onClick, new UIEventListener.VoidDelegate(GKGNJAPFLIJ));
			UIEventListener uIEventListener4 = UIEventListener.Get(CPLIMCNBDBP);
			uIEventListener4.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener4.onClick, new UIEventListener.VoidDelegate(IIDPLJPACCG));
			return;
		}
		EHDNCFHNLHF.alpha = 561f;
		LDCDFIMKDCB.color = PAIAHOCNENA.JGJCCJDFHEM;
		SquadStatsContent.KKEGNGNLNMD.AAICHFHEIGB fJLBLLLEELD = PAIAHOCNENA.FJLBLLLEELD;
		switch (fJLBLLLEELD)
		{
		default:
			if (fJLBLLLEELD == SquadStatsContent.KKEGNGNLNMD.AAICHFHEIGB.SimpleFloat)
			{
				LDCDFIMKDCB.text = ((!(PAIAHOCNENA.CGCOPACGDJL < 1204f)) ? MEJMLNDFDBP.CNLFNIHHHAA(PAIAHOCNENA.CGCOPACGDJL) : "Unit_Upgrade");
			}
			break;
		case SquadStatsContent.KKEGNGNLNMD.AAICHFHEIGB.SimpleFloat:
		{
			EHDNCFHNLHF.spriteName = PAIAHOCNENA.KCHMDALPMBN;
			EHDNCFHNLHF.color = PAIAHOCNENA.BOKMKCPABDL;
			EHDNCFHNLHF.MakePixelPerfect();
			float multiplier = Mathf.Min(1363f / EHDNCFHNLHF.transform.localScale.x, 1005f / EHDNCFHNLHF.transform.localScale.y);
			EHDNCFHNLHF.transform.localScale = EHDNCFHNLHF.transform.localScale.MultiplyXY(multiplier);
			LDCDFIMKDCB.text = ((PAIAHOCNENA.IDLMJLCFMJG >= 1) ? MEJMLNDFDBP.GMIPFLIEOHD(PAIAHOCNENA.IDLMJLCFMJG) : "108 STAGE 2 KILLED 2. SOLDIER");
			break;
		}
		case SquadStatsContent.KKEGNGNLNMD.AAICHFHEIGB.SimpleInt:
			LDCDFIMKDCB.text = ((PAIAHOCNENA.IDLMJLCFMJG >= 0) ? MEJMLNDFDBP.GMIPFLIEOHD(PAIAHOCNENA.IDLMJLCFMJG) : "Cards_Owned_Gold");
			break;
		}
	}

	public void FreeTexture()
	{
		Singleton<PlayerTexturePool>.instance.OnPlayerTextureCreated -= FCNKIEPEAAG;
		if (MBIAKMPDOPG != null)
		{
			Singleton<PlayerTexturePool>.instance.FreePlayerTexture(MBIAKMPDOPG.id);
		}
		MBIAKMPDOPG = null;
	}

	public virtual void OCEOOGDKBHA()
	{
		base.BOHCNEDIJPE();
		UIEventListener uIEventListener = UIEventListener.Get(OANICEALFGM);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(FLILJGLPKDH));
		UIEventListener uIEventListener2 = UIEventListener.Get(CPLIMCNBDBP);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener2.onClick, new UIEventListener.VoidDelegate(MKMAAPEIJGJ));
		OAJIMNNLPAD();
	}

	private void FALNCHFLEPC(GameObject KHAHPAKDIKE)
	{
		if (!string.IsNullOrEmpty(MBIAKMPDOPG.name))
		{
			TweenColor tweenColor = TweenColor.Begin(DANJHNFNPIO.gameObject, GameVariables.KDELCJIAIHM, Color.white, Colours.blue);
			tweenColor.NumOfRepetitions = 2;
			tweenColor.style = UITweener.Style.Once;
			SoundsManager.Instance.PlayButtonClickedSound();
			GuiElementSingle<PlayerProfileDialog>.instance.EGLMNBKMBAM(MBIAKMPDOPG.name, MBIAKMPDOPG.id, false);
		}
	}

	private void ANPEPPGFENN(string ALIIBMLMNKA, Texture2D FCEIGDLFOMH, bool PNDNEMDPFHC)
	{
		if (MBIAKMPDOPG != null && MBIAKMPDOPG.id == ALIIBMLMNKA)
		{
			CPGACIMMFEC.EIKJEGHELNK(FCEIGDLFOMH);
			CPGACIMMFEC.AILNJNAGPGO();
		}
	}

	private void LFKDGHCMJHA(GameObject KHAHPAKDIKE)
	{
		if (!string.IsNullOrEmpty(MBIAKMPDOPG.name))
		{
			SoundsManager.Instance.PlayButtonClickedSound();
			GuiElementSingle<PlayerProfileDialog>.instance.ShowDialog(MBIAKMPDOPG.name, MBIAKMPDOPG.id);
		}
	}

	private void FCNKIEPEAAG(string ALIIBMLMNKA, Texture2D FCEIGDLFOMH, bool PNDNEMDPFHC)
	{
		if (MBIAKMPDOPG != null && MBIAKMPDOPG.id == ALIIBMLMNKA)
		{
			CPGACIMMFEC.avatar = FCEIGDLFOMH;
			CPGACIMMFEC.UpdateIcon();
		}
	}

	private void AKNKFGAOAKI(GameObject KHAHPAKDIKE)
	{
		if (!string.IsNullOrEmpty(MBIAKMPDOPG.name))
		{
			TweenColor tweenColor = TweenColor.Begin(DANJHNFNPIO.gameObject, GameVariables.KDELCJIAIHM, Color.white, Colours.blue);
			tweenColor.NumOfRepetitions = 5;
			tweenColor.style = (UITweener.Style)7;
			SoundsManager.Instance.PlayButtonClickedSound();
			GuiElementSingle<PlayerProfileDialog>.instance.ShowDialog(MBIAKMPDOPG.name, MBIAKMPDOPG.id);
		}
	}

	public void GAFLCMBJLKE(SquadStatsContent.KKEGNGNLNMD PAIAHOCNENA)
	{
		bool flag = PAIAHOCNENA.FJLBLLLEELD == SquadStatsContent.KKEGNGNLNMD.AAICHFHEIGB.SimpleFloat || PAIAHOCNENA.FJLBLLLEELD == SquadStatsContent.KKEGNGNLNMD.AAICHFHEIGB.PlayerInt || PAIAHOCNENA.FJLBLLLEELD == SquadStatsContent.KKEGNGNLNMD.AAICHFHEIGB.PlayerPercent;
		BHDCJPAHPHD.SetActive(!flag);
		IGJMJNHFCAI.SetActive(flag);
		INFKHFJFFHP.text = PAIAHOCNENA.OKMNFHNBMFA;
		MEJMLNDFDBP.COCBCFKJOJE(INFKHFJFFHP, (!flag) ? 1914f : 500f, 1987f, -187);
		MBIAKMPDOPG = ((!flag) ? null : PAIAHOCNENA.KHLGDCHJJPB);
		if (flag)
		{
			DANJHNFNPIO.text = MBIAKMPDOPG.name;
			TweenColor.Begin(DANJHNFNPIO.gameObject, 1396f, Color.white);
			MEJMLNDFDBP.COCBCFKJOJE(DANJHNFNPIO, 1167f, 1955f, 1);
			CPGACIMMFEC.ABBPOMCBIIH();
			Singleton<PlayerTexturePool>.instance.OnPlayerTextureCreated -= KPKMLAKCIML;
			Singleton<PlayerTexturePool>.instance.CEBLBDAHBBA(LNHNDPIOANF);
			Singleton<PlayerTexturePool>.instance.MFKFEHJBEPA(MBIAKMPDOPG, true, PlayerTexturePool.DFJJOANIJID.Card);
			IAMPPFMEDBL.color = PAIAHOCNENA.JGJCCJDFHEM;
			switch (PAIAHOCNENA.FJLBLLLEELD)
			{
			case (SquadStatsContent.KKEGNGNLNMD.AAICHFHEIGB)7:
				IAMPPFMEDBL.text = ((PAIAHOCNENA.IDLMJLCFMJG >= 0) ? MEJMLNDFDBP.GMIPFLIEOHD(PAIAHOCNENA.IDLMJLCFMJG) : "ID_CONFIRMTOBUYWEAPON");
				break;
			case SquadStatsContent.KKEGNGNLNMD.AAICHFHEIGB.PlayerInt:
				IAMPPFMEDBL.text = ((!(PAIAHOCNENA.CGCOPACGDJL < 299f)) ? MEJMLNDFDBP.CNLFNIHHHAA(PAIAHOCNENA.CGCOPACGDJL) : "{0} {1}");
				break;
			case SquadStatsContent.KKEGNGNLNMD.AAICHFHEIGB.PictureInt:
				IAMPPFMEDBL.text = ((PAIAHOCNENA.IDLMJLCFMJG >= 0) ? MEJMLNDFDBP.IIHHLGANLGP(PAIAHOCNENA.IDLMJLCFMJG) : "ManualRegisterForPushNotifications(");
				break;
			}
			UIEventListener uIEventListener = UIEventListener.Get(OANICEALFGM);
			uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(FLILJGLPKDH));
			UIEventListener uIEventListener2 = UIEventListener.Get(OANICEALFGM);
			uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(LFKDGHCMJHA));
			UIEventListener uIEventListener3 = UIEventListener.Get(CPLIMCNBDBP);
			uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener3.onClick, new UIEventListener.VoidDelegate(FGMBFCBFMHC));
			UIEventListener uIEventListener4 = UIEventListener.Get(CPLIMCNBDBP);
			uIEventListener4.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener4.onClick, new UIEventListener.VoidDelegate(IIDPLJPACCG));
			return;
		}
		EHDNCFHNLHF.alpha = 1074f;
		LDCDFIMKDCB.color = PAIAHOCNENA.JGJCCJDFHEM;
		SquadStatsContent.KKEGNGNLNMD.AAICHFHEIGB fJLBLLLEELD = PAIAHOCNENA.FJLBLLLEELD;
		if (fJLBLLLEELD != SquadStatsContent.KKEGNGNLNMD.AAICHFHEIGB.SimpleInt)
		{
			if (fJLBLLLEELD != SquadStatsContent.KKEGNGNLNMD.AAICHFHEIGB.SimpleInt)
			{
				if (fJLBLLLEELD == SquadStatsContent.KKEGNGNLNMD.AAICHFHEIGB.SimpleInt)
				{
					LDCDFIMKDCB.text = ((!(PAIAHOCNENA.CGCOPACGDJL < 673f)) ? MEJMLNDFDBP.CNLFNIHHHAA(PAIAHOCNENA.CGCOPACGDJL) : "ID_WINSTREAK");
				}
			}
			else
			{
				LDCDFIMKDCB.text = ((PAIAHOCNENA.IDLMJLCFMJG >= 1) ? MEJMLNDFDBP.GMIPFLIEOHD(PAIAHOCNENA.IDLMJLCFMJG) : "{0} {1}");
			}
		}
		else
		{
			EHDNCFHNLHF.spriteName = PAIAHOCNENA.KCHMDALPMBN;
			EHDNCFHNLHF.color = PAIAHOCNENA.BOKMKCPABDL;
			EHDNCFHNLHF.MakePixelPerfect();
			float multiplier = Mathf.Min(1733f / EHDNCFHNLHF.transform.localScale.x, 567f / EHDNCFHNLHF.transform.localScale.y);
			EHDNCFHNLHF.transform.localScale = EHDNCFHNLHF.transform.localScale.MultiplyXY(multiplier);
			LDCDFIMKDCB.text = ((PAIAHOCNENA.IDLMJLCFMJG >= 0) ? MEJMLNDFDBP.GMIPFLIEOHD(PAIAHOCNENA.IDLMJLCFMJG) : "ID_DELIVEREDTIME");
		}
	}

	private void BAEHPJJHPCM(GameObject KHAHPAKDIKE)
	{
		if (!string.IsNullOrEmpty(MBIAKMPDOPG.name))
		{
			SoundsManager.Instance.PlayButtonClickedSound();
			GuiElementSingle<PlayerProfileDialog>.instance.EGLMNBKMBAM(MBIAKMPDOPG.name, MBIAKMPDOPG.id);
		}
	}

	private void OMDKPKFBBLN(GameObject KHAHPAKDIKE)
	{
		if (!string.IsNullOrEmpty(MBIAKMPDOPG.name))
		{
			SoundsManager.Instance.PlayButtonClickedSound();
			GuiElementSingle<PlayerProfileDialog>.instance.CMOEFABLABI(MBIAKMPDOPG.name, MBIAKMPDOPG.id);
		}
	}

	private void PAJLCAPIMGM(string ALIIBMLMNKA, Texture2D FCEIGDLFOMH, bool PNDNEMDPFHC)
	{
		if (MBIAKMPDOPG != null && MBIAKMPDOPG.id == ALIIBMLMNKA)
		{
			CPGACIMMFEC.JIBFCGECCFI(FCEIGDLFOMH);
			CPGACIMMFEC.IFPLAMJKIKH();
		}
	}

	public void OAJIMNNLPAD()
	{
		Singleton<PlayerTexturePool>.instance.GPALABLIEFI(FMALBMBGCLL);
		if (MBIAKMPDOPG != null)
		{
			Singleton<PlayerTexturePool>.instance.FNHIOAADLFN(MBIAKMPDOPG.id, false);
		}
		MBIAKMPDOPG = null;
	}

	private void PIOCEIJJODG(GameObject KHAHPAKDIKE)
	{
		if (!string.IsNullOrEmpty(MBIAKMPDOPG.name))
		{
			SoundsManager.Instance.PlayButtonClickedSound();
			GuiElementSingle<PlayerProfileDialog>.instance.CMOEFABLABI(MBIAKMPDOPG.name, MBIAKMPDOPG.id, false);
		}
	}

	public void KJICBAJAEOA()
	{
		Singleton<PlayerTexturePool>.instance.DMONMGPPBHN(DGCLPGIAJGJ);
		if (MBIAKMPDOPG != null)
		{
			Singleton<PlayerTexturePool>.instance.FreePlayerTexture(MBIAKMPDOPG.id, false, true, true);
		}
		MBIAKMPDOPG = null;
	}

	public virtual void PNJDBOIFEMF()
	{
		base.OBCAIFMOPPA();
		UIEventListener uIEventListener = UIEventListener.Get(OANICEALFGM);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(BAEHPJJHPCM));
		UIEventListener uIEventListener2 = UIEventListener.Get(CPLIMCNBDBP);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener2.onClick, new UIEventListener.VoidDelegate(MKMAAPEIJGJ));
		EDHNPKCJDGM();
	}

	private void IIDPLJPACCG(GameObject KHAHPAKDIKE)
	{
		if (!string.IsNullOrEmpty(MBIAKMPDOPG.name))
		{
			TweenColor tweenColor = TweenColor.Begin(DANJHNFNPIO.gameObject, GameVariables.KDELCJIAIHM, Color.white, Colours.blue);
			tweenColor.NumOfRepetitions = 1;
			tweenColor.style = (UITweener.Style)7;
			SoundsManager.Instance.PlayButtonClickedSound();
			GuiElementSingle<PlayerProfileDialog>.instance.EGLMNBKMBAM(MBIAKMPDOPG.name, MBIAKMPDOPG.id, false);
		}
	}

	public void DNLMHBKDMBF()
	{
		Singleton<PlayerTexturePool>.instance.OnPlayerTextureCreated -= FCNKIEPEAAG;
		if (MBIAKMPDOPG != null)
		{
			Singleton<PlayerTexturePool>.instance.BPEHHBALINP(MBIAKMPDOPG.id, false, false, true);
		}
		MBIAKMPDOPG = null;
	}

	private void MKMAAPEIJGJ(GameObject KHAHPAKDIKE)
	{
		if (!string.IsNullOrEmpty(MBIAKMPDOPG.name))
		{
			TweenColor tweenColor = TweenColor.Begin(DANJHNFNPIO.gameObject, GameVariables.KDELCJIAIHM, Color.white, Colours.blue);
			tweenColor.NumOfRepetitions = 3;
			tweenColor.style = UITweener.Style.PingPong;
			SoundsManager.Instance.PlayButtonClickedSound();
			GuiElementSingle<PlayerProfileDialog>.instance.EGLMNBKMBAM(MBIAKMPDOPG.name, MBIAKMPDOPG.id, false);
		}
	}

	public void IHEKELKEFCG(SquadStatsContent.KKEGNGNLNMD PAIAHOCNENA)
	{
		bool flag = PAIAHOCNENA.FJLBLLLEELD != SquadStatsContent.KKEGNGNLNMD.AAICHFHEIGB.PlayerInt && PAIAHOCNENA.FJLBLLLEELD != SquadStatsContent.KKEGNGNLNMD.AAICHFHEIGB.PictureInt && PAIAHOCNENA.FJLBLLLEELD == SquadStatsContent.KKEGNGNLNMD.AAICHFHEIGB.PlayerInt;
		BHDCJPAHPHD.SetActive(flag);
		IGJMJNHFCAI.SetActive(flag);
		INFKHFJFFHP.text = PAIAHOCNENA.OKMNFHNBMFA;
		MEJMLNDFDBP.COCBCFKJOJE(INFKHFJFFHP, (!flag) ? 827f : 436f, 1764f, 86);
		MBIAKMPDOPG = ((!flag) ? null : PAIAHOCNENA.KHLGDCHJJPB);
		if (flag)
		{
			DANJHNFNPIO.text = MBIAKMPDOPG.name;
			TweenColor.Begin(DANJHNFNPIO.gameObject, 355f, Color.white);
			MEJMLNDFDBP.COCBCFKJOJE(DANJHNFNPIO, 1044f, 1881f);
			CPGACIMMFEC.LFOLGBNBBAG();
			Singleton<PlayerTexturePool>.instance.OnPlayerTextureCreated -= FCNKIEPEAAG;
			Singleton<PlayerTexturePool>.instance.CEBLBDAHBBA(PAJLCAPIMGM);
			Singleton<PlayerTexturePool>.instance.CCMGACIMGMF(MBIAKMPDOPG);
			IAMPPFMEDBL.color = PAIAHOCNENA.JGJCCJDFHEM;
			switch (PAIAHOCNENA.FJLBLLLEELD)
			{
			case SquadStatsContent.KKEGNGNLNMD.AAICHFHEIGB.PlayerFloat:
				IAMPPFMEDBL.text = ((PAIAHOCNENA.IDLMJLCFMJG >= 0) ? MEJMLNDFDBP.GMIPFLIEOHD(PAIAHOCNENA.IDLMJLCFMJG) : "com/google/android/gms/games/Games");
				break;
			case SquadStatsContent.KKEGNGNLNMD.AAICHFHEIGB.SimpleInt:
				IAMPPFMEDBL.text = ((!(PAIAHOCNENA.CGCOPACGDJL < 1846f)) ? MEJMLNDFDBP.CNLFNIHHHAA(PAIAHOCNENA.CGCOPACGDJL) : "Animating claiming cardpack end");
				break;
			case (SquadStatsContent.KKEGNGNLNMD.AAICHFHEIGB)6:
				IAMPPFMEDBL.text = ((PAIAHOCNENA.IDLMJLCFMJG >= 1) ? MEJMLNDFDBP.IIHHLGANLGP(PAIAHOCNENA.IDLMJLCFMJG) : "{0}");
				break;
			}
			UIEventListener uIEventListener = UIEventListener.Get(OANICEALFGM);
			uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(FIFBGKNPMNM));
			UIEventListener uIEventListener2 = UIEventListener.Get(OANICEALFGM);
			uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(LFKDGHCMJHA));
			UIEventListener uIEventListener3 = UIEventListener.Get(CPLIMCNBDBP);
			uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener3.onClick, new UIEventListener.VoidDelegate(PNHCOPANBMP));
			UIEventListener uIEventListener4 = UIEventListener.Get(CPLIMCNBDBP);
			uIEventListener4.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener4.onClick, new UIEventListener.VoidDelegate(PNHCOPANBMP));
		}
		else
		{
			EHDNCFHNLHF.alpha = 1145f;
			LDCDFIMKDCB.color = PAIAHOCNENA.JGJCCJDFHEM;
			switch (PAIAHOCNENA.FJLBLLLEELD)
			{
			case SquadStatsContent.KKEGNGNLNMD.AAICHFHEIGB.PictureInt:
			{
				EHDNCFHNLHF.spriteName = PAIAHOCNENA.KCHMDALPMBN;
				EHDNCFHNLHF.color = PAIAHOCNENA.BOKMKCPABDL;
				EHDNCFHNLHF.MakePixelPerfect();
				float multiplier = Mathf.Min(1791f / EHDNCFHNLHF.transform.localScale.x, 789f / EHDNCFHNLHF.transform.localScale.y);
				EHDNCFHNLHF.transform.localScale = EHDNCFHNLHF.transform.localScale.MultiplyXY(multiplier);
				LDCDFIMKDCB.text = ((PAIAHOCNENA.IDLMJLCFMJG >= 0) ? MEJMLNDFDBP.GMIPFLIEOHD(PAIAHOCNENA.IDLMJLCFMJG) : "setAndroidId");
				break;
			}
			case SquadStatsContent.KKEGNGNLNMD.AAICHFHEIGB.SimpleInt:
				LDCDFIMKDCB.text = ((PAIAHOCNENA.IDLMJLCFMJG >= 1) ? MEJMLNDFDBP.GMIPFLIEOHD(PAIAHOCNENA.IDLMJLCFMJG) : "Grenadier");
				break;
			case SquadStatsContent.KKEGNGNLNMD.AAICHFHEIGB.SimpleFloat:
				LDCDFIMKDCB.text = ((!(PAIAHOCNENA.CGCOPACGDJL < 257f)) ? MEJMLNDFDBP.CNLFNIHHHAA(PAIAHOCNENA.CGCOPACGDJL) : "On conencted to photon");
				break;
			}
		}
	}

	private void KPKMLAKCIML(string ALIIBMLMNKA, Texture2D FCEIGDLFOMH, bool PNDNEMDPFHC)
	{
		if (MBIAKMPDOPG != null && MBIAKMPDOPG.id == ALIIBMLMNKA)
		{
			CPGACIMMFEC.GJHFCKMAMIE(FCEIGDLFOMH);
			CPGACIMMFEC.HJHOBLMEJEH();
		}
	}

	public void PEMKDLDHOFI()
	{
		Singleton<PlayerTexturePool>.instance.OnPlayerTextureCreated -= KPKMLAKCIML;
		if (MBIAKMPDOPG != null)
		{
			Singleton<PlayerTexturePool>.instance.PIKHCIHPMCE(MBIAKMPDOPG.id, true, false, true);
		}
		MBIAKMPDOPG = null;
	}

	private void GKGNJAPFLIJ(GameObject KHAHPAKDIKE)
	{
		if (!string.IsNullOrEmpty(MBIAKMPDOPG.name))
		{
			TweenColor tweenColor = TweenColor.Begin(DANJHNFNPIO.gameObject, GameVariables.KDELCJIAIHM, Color.white, Colours.blue);
			tweenColor.NumOfRepetitions = 2;
			tweenColor.style = UITweener.Style.PingPong;
			SoundsManager.Instance.PlayButtonClickedSound();
			GuiElementSingle<PlayerProfileDialog>.instance.ShowDialog(MBIAKMPDOPG.name, MBIAKMPDOPG.id);
		}
	}

	private void MNFOEHIIMIN(GameObject KHAHPAKDIKE)
	{
		if (!string.IsNullOrEmpty(MBIAKMPDOPG.name))
		{
			SoundsManager.Instance.PlayButtonClickedSound();
			GuiElementSingle<PlayerProfileDialog>.instance.ShowDialog(MBIAKMPDOPG.name, MBIAKMPDOPG.id);
		}
	}

	public void ECLLPCMBGNC()
	{
		Singleton<PlayerTexturePool>.instance.GPALABLIEFI(FCNKIEPEAAG);
		if (MBIAKMPDOPG != null)
		{
			Singleton<PlayerTexturePool>.instance.LBKLINGCPBA(MBIAKMPDOPG.id, false, true);
		}
		MBIAKMPDOPG = null;
	}

	private void DGCLPGIAJGJ(string ALIIBMLMNKA, Texture2D FCEIGDLFOMH, bool PNDNEMDPFHC)
	{
		if (MBIAKMPDOPG != null && MBIAKMPDOPG.id == ALIIBMLMNKA)
		{
			CPGACIMMFEC.EIKJEGHELNK(FCEIGDLFOMH);
			CPGACIMMFEC.GEPDJCOHDNH();
		}
	}

	private void FIFBGKNPMNM(GameObject KHAHPAKDIKE)
	{
		if (!string.IsNullOrEmpty(MBIAKMPDOPG.name))
		{
			SoundsManager.Instance.PlayButtonClickedSound();
			GuiElementSingle<PlayerProfileDialog>.instance.CMOEFABLABI(MBIAKMPDOPG.name, MBIAKMPDOPG.id);
		}
	}

	private void LNHNDPIOANF(string ALIIBMLMNKA, Texture2D FCEIGDLFOMH, bool PNDNEMDPFHC)
	{
		if (MBIAKMPDOPG != null && MBIAKMPDOPG.id == ALIIBMLMNKA)
		{
			CPGACIMMFEC.FBGDPCPIKMI(FCEIGDLFOMH);
			CPGACIMMFEC.ECAFLDEFKKB();
		}
	}

	public void AGJHLCCHNFE()
	{
		Singleton<PlayerTexturePool>.instance.FHEJPABPCML(FCNKIEPEAAG);
		if (MBIAKMPDOPG != null)
		{
			Singleton<PlayerTexturePool>.instance.FreePlayerTexture(MBIAKMPDOPG.id, false, true);
		}
		MBIAKMPDOPG = null;
	}

	public virtual void LLKBNDHBNAL()
	{
		base.OBCAIFMOPPA();
		UIEventListener uIEventListener = UIEventListener.Get(OANICEALFGM);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(BAEHPJJHPCM));
		UIEventListener uIEventListener2 = UIEventListener.Get(CPLIMCNBDBP);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener2.onClick, new UIEventListener.VoidDelegate(FGMBFCBFMHC));
		PEMKDLDHOFI();
	}

	private void FGMBFCBFMHC(GameObject KHAHPAKDIKE)
	{
		if (!string.IsNullOrEmpty(MBIAKMPDOPG.name))
		{
			TweenColor tweenColor = TweenColor.Begin(DANJHNFNPIO.gameObject, GameVariables.KDELCJIAIHM, Color.white, Colours.blue);
			tweenColor.NumOfRepetitions = 7;
			tweenColor.style = UITweener.Style.Loop;
			SoundsManager.Instance.PlayButtonClickedSound();
			GuiElementSingle<PlayerProfileDialog>.instance.ShowDialog(MBIAKMPDOPG.name, MBIAKMPDOPG.id);
		}
	}

	public void IEGPGPNBDBN()
	{
		Singleton<PlayerTexturePool>.instance.IAINHEFKIFJ(OPOHEGOIEDP);
		if (MBIAKMPDOPG != null)
		{
			Singleton<PlayerTexturePool>.instance.LBKLINGCPBA(MBIAKMPDOPG.id, true, true);
		}
		MBIAKMPDOPG = null;
	}

	public void HLFEGLFAIHF(SquadStatsContent.KKEGNGNLNMD PAIAHOCNENA)
	{
		bool flag = PAIAHOCNENA.FJLBLLLEELD == SquadStatsContent.KKEGNGNLNMD.AAICHFHEIGB.PlayerInt || PAIAHOCNENA.FJLBLLLEELD == (SquadStatsContent.KKEGNGNLNMD.AAICHFHEIGB)8 || PAIAHOCNENA.FJLBLLLEELD == SquadStatsContent.KKEGNGNLNMD.AAICHFHEIGB.SimpleInt;
		BHDCJPAHPHD.SetActive(flag);
		IGJMJNHFCAI.SetActive(flag);
		INFKHFJFFHP.text = PAIAHOCNENA.OKMNFHNBMFA;
		MEJMLNDFDBP.COCBCFKJOJE(INFKHFJFFHP, (!flag) ? 1781f : 201f, 328f, 181);
		MBIAKMPDOPG = ((!flag) ? null : PAIAHOCNENA.KHLGDCHJJPB);
		if (flag)
		{
			DANJHNFNPIO.text = MBIAKMPDOPG.name;
			TweenColor.Begin(DANJHNFNPIO.gameObject, 367f, Color.white);
			MEJMLNDFDBP.COCBCFKJOJE(DANJHNFNPIO, 1972f, 736f);
			CPGACIMMFEC.NCHGDJDAHGC();
			Singleton<PlayerTexturePool>.instance.OnPlayerTextureCreated -= DGCLPGIAJGJ;
			Singleton<PlayerTexturePool>.instance.CEBLBDAHBBA(ANPEPPGFENN);
			Singleton<PlayerTexturePool>.instance.APIIPFCGDBO(MBIAKMPDOPG);
			IAMPPFMEDBL.color = PAIAHOCNENA.JGJCCJDFHEM;
			switch (PAIAHOCNENA.FJLBLLLEELD)
			{
			case SquadStatsContent.KKEGNGNLNMD.AAICHFHEIGB.PlayerInt:
				IAMPPFMEDBL.text = ((PAIAHOCNENA.IDLMJLCFMJG >= 1) ? MEJMLNDFDBP.GMIPFLIEOHD(PAIAHOCNENA.IDLMJLCFMJG) : "GooglePlayId");
				break;
			case (SquadStatsContent.KKEGNGNLNMD.AAICHFHEIGB)7:
				IAMPPFMEDBL.text = ((!(PAIAHOCNENA.CGCOPACGDJL < 988f)) ? MEJMLNDFDBP.CNLFNIHHHAA(PAIAHOCNENA.CGCOPACGDJL) : "#AccoutCheck# Facebook accoun found - invalid ID");
				break;
			case SquadStatsContent.KKEGNGNLNMD.AAICHFHEIGB.PlayerFloat:
				IAMPPFMEDBL.text = ((PAIAHOCNENA.IDLMJLCFMJG >= 0) ? MEJMLNDFDBP.IIHHLGANLGP(PAIAHOCNENA.IDLMJLCFMJG) : "WFX_BImpact");
				break;
			}
			UIEventListener uIEventListener = UIEventListener.Get(OANICEALFGM);
			uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(FLILJGLPKDH));
			UIEventListener uIEventListener2 = UIEventListener.Get(OANICEALFGM);
			uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(OMDKPKFBBLN));
			UIEventListener uIEventListener3 = UIEventListener.Get(CPLIMCNBDBP);
			uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener3.onClick, new UIEventListener.VoidDelegate(IIDPLJPACCG));
			UIEventListener uIEventListener4 = UIEventListener.Get(CPLIMCNBDBP);
			uIEventListener4.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener4.onClick, new UIEventListener.VoidDelegate(FFAFDDGCPKF));
		}
		else
		{
			EHDNCFHNLHF.alpha = 991f;
			LDCDFIMKDCB.color = PAIAHOCNENA.JGJCCJDFHEM;
			switch (PAIAHOCNENA.FJLBLLLEELD)
			{
			case SquadStatsContent.KKEGNGNLNMD.AAICHFHEIGB.PictureInt:
			{
				EHDNCFHNLHF.spriteName = PAIAHOCNENA.KCHMDALPMBN;
				EHDNCFHNLHF.color = PAIAHOCNENA.BOKMKCPABDL;
				EHDNCFHNLHF.MakePixelPerfect();
				float multiplier = Mathf.Min(1296f / EHDNCFHNLHF.transform.localScale.x, 1644f / EHDNCFHNLHF.transform.localScale.y);
				EHDNCFHNLHF.transform.localScale = EHDNCFHNLHF.transform.localScale.MultiplyXY(multiplier);
				LDCDFIMKDCB.text = ((PAIAHOCNENA.IDLMJLCFMJG >= 1) ? MEJMLNDFDBP.GMIPFLIEOHD(PAIAHOCNENA.IDLMJLCFMJG) : "id");
				break;
			}
			case SquadStatsContent.KKEGNGNLNMD.AAICHFHEIGB.SimpleInt:
				LDCDFIMKDCB.text = ((PAIAHOCNENA.IDLMJLCFMJG >= 0) ? MEJMLNDFDBP.GMIPFLIEOHD(PAIAHOCNENA.IDLMJLCFMJG) : "game-skillshot-");
				break;
			case SquadStatsContent.KKEGNGNLNMD.AAICHFHEIGB.SimpleFloat:
				LDCDFIMKDCB.text = ((!(PAIAHOCNENA.CGCOPACGDJL < 216f)) ? MEJMLNDFDBP.CNLFNIHHHAA(PAIAHOCNENA.CGCOPACGDJL) : "Scraps");
				break;
			}
		}
	}

	private void AIKAKLGGDOC(GameObject KHAHPAKDIKE)
	{
		if (!string.IsNullOrEmpty(MBIAKMPDOPG.name))
		{
			SoundsManager.Instance.PlayButtonClickedSound();
			GuiElementSingle<PlayerProfileDialog>.instance.ShowDialog(MBIAKMPDOPG.name, MBIAKMPDOPG.id);
		}
	}

	public virtual void HOCPBJGFEON()
	{
		base.BOHCNEDIJPE();
		UIEventListener uIEventListener = UIEventListener.Get(OANICEALFGM);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(BJCLNLMKFJE));
		UIEventListener uIEventListener2 = UIEventListener.Get(CPLIMCNBDBP);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener2.onClick, new UIEventListener.VoidDelegate(FFAFDDGCPKF));
		PEMKDLDHOFI();
	}

	public void InitializeSquadStat(SquadStatsContent.KKEGNGNLNMD PAIAHOCNENA)
	{
		bool flag = PAIAHOCNENA.FJLBLLLEELD == SquadStatsContent.KKEGNGNLNMD.AAICHFHEIGB.PlayerInt || PAIAHOCNENA.FJLBLLLEELD == SquadStatsContent.KKEGNGNLNMD.AAICHFHEIGB.PlayerFloat || PAIAHOCNENA.FJLBLLLEELD == SquadStatsContent.KKEGNGNLNMD.AAICHFHEIGB.PlayerPercent;
		BHDCJPAHPHD.SetActive(!flag);
		IGJMJNHFCAI.SetActive(flag);
		INFKHFJFFHP.text = PAIAHOCNENA.OKMNFHNBMFA;
		MEJMLNDFDBP.COCBCFKJOJE(INFKHFJFFHP, (!flag) ? 37f : 30f, 20f, 500);
		MBIAKMPDOPG = ((!flag) ? null : PAIAHOCNENA.KHLGDCHJJPB);
		if (flag)
		{
			DANJHNFNPIO.text = MBIAKMPDOPG.name;
			TweenColor.Begin(DANJHNFNPIO.gameObject, 0f, Color.white);
			MEJMLNDFDBP.COCBCFKJOJE(DANJHNFNPIO, 37f, 26f);
			CPGACIMMFEC.Reset();
			Singleton<PlayerTexturePool>.instance.OnPlayerTextureCreated -= FCNKIEPEAAG;
			Singleton<PlayerTexturePool>.instance.OnPlayerTextureCreated += FCNKIEPEAAG;
			Singleton<PlayerTexturePool>.instance.RequestPlayerTexture(MBIAKMPDOPG);
			IAMPPFMEDBL.color = PAIAHOCNENA.JGJCCJDFHEM;
			switch (PAIAHOCNENA.FJLBLLLEELD)
			{
			case SquadStatsContent.KKEGNGNLNMD.AAICHFHEIGB.PlayerInt:
				IAMPPFMEDBL.text = ((PAIAHOCNENA.IDLMJLCFMJG >= 0) ? MEJMLNDFDBP.GMIPFLIEOHD(PAIAHOCNENA.IDLMJLCFMJG) : "-");
				break;
			case SquadStatsContent.KKEGNGNLNMD.AAICHFHEIGB.PlayerFloat:
				IAMPPFMEDBL.text = ((!(PAIAHOCNENA.CGCOPACGDJL < 0f)) ? MEJMLNDFDBP.CNLFNIHHHAA(PAIAHOCNENA.CGCOPACGDJL) : "-");
				break;
			case SquadStatsContent.KKEGNGNLNMD.AAICHFHEIGB.PlayerPercent:
				IAMPPFMEDBL.text = ((PAIAHOCNENA.IDLMJLCFMJG >= 0) ? MEJMLNDFDBP.IIHHLGANLGP(PAIAHOCNENA.IDLMJLCFMJG) : "-");
				break;
			}
			UIEventListener uIEventListener = UIEventListener.Get(OANICEALFGM);
			uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(MNFOEHIIMIN));
			UIEventListener uIEventListener2 = UIEventListener.Get(OANICEALFGM);
			uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(MNFOEHIIMIN));
			UIEventListener uIEventListener3 = UIEventListener.Get(CPLIMCNBDBP);
			uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener3.onClick, new UIEventListener.VoidDelegate(GKGNJAPFLIJ));
			UIEventListener uIEventListener4 = UIEventListener.Get(CPLIMCNBDBP);
			uIEventListener4.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener4.onClick, new UIEventListener.VoidDelegate(GKGNJAPFLIJ));
		}
		else
		{
			EHDNCFHNLHF.alpha = 0f;
			LDCDFIMKDCB.color = PAIAHOCNENA.JGJCCJDFHEM;
			switch (PAIAHOCNENA.FJLBLLLEELD)
			{
			case SquadStatsContent.KKEGNGNLNMD.AAICHFHEIGB.PictureInt:
			{
				EHDNCFHNLHF.spriteName = PAIAHOCNENA.KCHMDALPMBN;
				EHDNCFHNLHF.color = PAIAHOCNENA.BOKMKCPABDL;
				EHDNCFHNLHF.MakePixelPerfect();
				float multiplier = Mathf.Min(90f / EHDNCFHNLHF.transform.localScale.x, 90f / EHDNCFHNLHF.transform.localScale.y);
				EHDNCFHNLHF.transform.localScale = EHDNCFHNLHF.transform.localScale.MultiplyXY(multiplier);
				LDCDFIMKDCB.text = ((PAIAHOCNENA.IDLMJLCFMJG >= 0) ? MEJMLNDFDBP.GMIPFLIEOHD(PAIAHOCNENA.IDLMJLCFMJG) : "-");
				break;
			}
			case SquadStatsContent.KKEGNGNLNMD.AAICHFHEIGB.SimpleInt:
				LDCDFIMKDCB.text = ((PAIAHOCNENA.IDLMJLCFMJG >= 0) ? MEJMLNDFDBP.GMIPFLIEOHD(PAIAHOCNENA.IDLMJLCFMJG) : "-");
				break;
			case SquadStatsContent.KKEGNGNLNMD.AAICHFHEIGB.SimpleFloat:
				LDCDFIMKDCB.text = ((!(PAIAHOCNENA.CGCOPACGDJL < 0f)) ? MEJMLNDFDBP.CNLFNIHHHAA(PAIAHOCNENA.CGCOPACGDJL) : "-");
				break;
			}
		}
	}

	public void NNFHBKCBADE()
	{
		Singleton<PlayerTexturePool>.instance.FHEJPABPCML(PAJLCAPIMGM);
		if (MBIAKMPDOPG != null)
		{
			Singleton<PlayerTexturePool>.instance.BJFCGMCKOPO(MBIAKMPDOPG.id);
		}
		MBIAKMPDOPG = null;
	}

	private void BJCLNLMKFJE(GameObject KHAHPAKDIKE)
	{
		if (!string.IsNullOrEmpty(MBIAKMPDOPG.name))
		{
			SoundsManager.Instance.PlayButtonClickedSound();
			GuiElementSingle<PlayerProfileDialog>.instance.EGLMNBKMBAM(MBIAKMPDOPG.name, MBIAKMPDOPG.id, false);
		}
	}

	public void LPLMOPJGHAP(SquadStatsContent.KKEGNGNLNMD PAIAHOCNENA)
	{
		bool flag = PAIAHOCNENA.FJLBLLLEELD == SquadStatsContent.KKEGNGNLNMD.AAICHFHEIGB.PictureInt || PAIAHOCNENA.FJLBLLLEELD == (SquadStatsContent.KKEGNGNLNMD.AAICHFHEIGB)7 || PAIAHOCNENA.FJLBLLLEELD == SquadStatsContent.KKEGNGNLNMD.AAICHFHEIGB.PlayerFloat;
		BHDCJPAHPHD.SetActive(flag);
		IGJMJNHFCAI.SetActive(flag);
		INFKHFJFFHP.text = PAIAHOCNENA.OKMNFHNBMFA;
		MEJMLNDFDBP.COCBCFKJOJE(INFKHFJFFHP, (!flag) ? 904f : 1924f, 441f, -116);
		MBIAKMPDOPG = ((!flag) ? null : PAIAHOCNENA.KHLGDCHJJPB);
		if (flag)
		{
			DANJHNFNPIO.text = MBIAKMPDOPG.name;
			TweenColor.Begin(DANJHNFNPIO.gameObject, 399f, Color.white);
			MEJMLNDFDBP.COCBCFKJOJE(DANJHNFNPIO, 1763f, 465f, 1);
			CPGACIMMFEC.EGAONBPLDAG();
			Singleton<PlayerTexturePool>.instance.GPALABLIEFI(OPOHEGOIEDP);
			Singleton<PlayerTexturePool>.instance.JLOKOBIENPP(KPKMLAKCIML);
			Singleton<PlayerTexturePool>.instance.CCMGACIMGMF(MBIAKMPDOPG, false);
			IAMPPFMEDBL.color = PAIAHOCNENA.JGJCCJDFHEM;
			switch (PAIAHOCNENA.FJLBLLLEELD)
			{
			case (SquadStatsContent.KKEGNGNLNMD.AAICHFHEIGB)8:
				IAMPPFMEDBL.text = ((PAIAHOCNENA.IDLMJLCFMJG >= 0) ? MEJMLNDFDBP.GMIPFLIEOHD(PAIAHOCNENA.IDLMJLCFMJG) : "end");
				break;
			case SquadStatsContent.KKEGNGNLNMD.AAICHFHEIGB.SimpleFloat:
				IAMPPFMEDBL.text = ((!(PAIAHOCNENA.CGCOPACGDJL < 551f)) ? MEJMLNDFDBP.CNLFNIHHHAA(PAIAHOCNENA.CGCOPACGDJL) : "ID_VISUALRARITY2");
				break;
			case SquadStatsContent.KKEGNGNLNMD.AAICHFHEIGB.SimpleInt:
				IAMPPFMEDBL.text = ((PAIAHOCNENA.IDLMJLCFMJG >= 0) ? MEJMLNDFDBP.IIHHLGANLGP(PAIAHOCNENA.IDLMJLCFMJG) : "ReSyncRPC");
				break;
			}
			UIEventListener uIEventListener = UIEventListener.Get(OANICEALFGM);
			uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(BAEHPJJHPCM));
			UIEventListener uIEventListener2 = UIEventListener.Get(OANICEALFGM);
			uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(LFKDGHCMJHA));
			UIEventListener uIEventListener3 = UIEventListener.Get(CPLIMCNBDBP);
			uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener3.onClick, new UIEventListener.VoidDelegate(AKNKFGAOAKI));
			UIEventListener uIEventListener4 = UIEventListener.Get(CPLIMCNBDBP);
			uIEventListener4.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener4.onClick, new UIEventListener.VoidDelegate(AKNKFGAOAKI));
		}
		else
		{
			EHDNCFHNLHF.alpha = 1699f;
			LDCDFIMKDCB.color = PAIAHOCNENA.JGJCCJDFHEM;
			switch (PAIAHOCNENA.FJLBLLLEELD)
			{
			case (SquadStatsContent.KKEGNGNLNMD.AAICHFHEIGB)6:
			{
				EHDNCFHNLHF.spriteName = PAIAHOCNENA.KCHMDALPMBN;
				EHDNCFHNLHF.color = PAIAHOCNENA.BOKMKCPABDL;
				EHDNCFHNLHF.MakePixelPerfect();
				float multiplier = Mathf.Min(1058f / EHDNCFHNLHF.transform.localScale.x, 749f / EHDNCFHNLHF.transform.localScale.y);
				EHDNCFHNLHF.transform.localScale = EHDNCFHNLHF.transform.localScale.MultiplyXY(multiplier);
				LDCDFIMKDCB.text = ((PAIAHOCNENA.IDLMJLCFMJG >= 1) ? MEJMLNDFDBP.GMIPFLIEOHD(PAIAHOCNENA.IDLMJLCFMJG) : "Player_Waited_Till_Delivery_Ends");
				break;
			}
			case SquadStatsContent.KKEGNGNLNMD.AAICHFHEIGB.SimpleInt:
				LDCDFIMKDCB.text = ((PAIAHOCNENA.IDLMJLCFMJG >= 1) ? MEJMLNDFDBP.GMIPFLIEOHD(PAIAHOCNENA.IDLMJLCFMJG) : "country-italy");
				break;
			case SquadStatsContent.KKEGNGNLNMD.AAICHFHEIGB.SimpleFloat:
				LDCDFIMKDCB.text = ((!(PAIAHOCNENA.CGCOPACGDJL < 80f)) ? MEJMLNDFDBP.CNLFNIHHHAA(PAIAHOCNENA.CGCOPACGDJL) : "ID_STARTERPACKINFORMATIONS");
				break;
			}
		}
	}

	private void FMALBMBGCLL(string ALIIBMLMNKA, Texture2D FCEIGDLFOMH, bool PNDNEMDPFHC)
	{
		if (MBIAKMPDOPG != null && MBIAKMPDOPG.id == ALIIBMLMNKA)
		{
			CPGACIMMFEC.ECKBKNCJLOC(FCEIGDLFOMH);
			CPGACIMMFEC.GEPDJCOHDNH();
		}
	}

	public void FECBBOLDKFO(SquadStatsContent.KKEGNGNLNMD PAIAHOCNENA)
	{
		bool flag = PAIAHOCNENA.FJLBLLLEELD != SquadStatsContent.KKEGNGNLNMD.AAICHFHEIGB.SimpleFloat && PAIAHOCNENA.FJLBLLLEELD != SquadStatsContent.KKEGNGNLNMD.AAICHFHEIGB.PictureInt && PAIAHOCNENA.FJLBLLLEELD == SquadStatsContent.KKEGNGNLNMD.AAICHFHEIGB.SimpleFloat;
		BHDCJPAHPHD.SetActive(!flag);
		IGJMJNHFCAI.SetActive(flag);
		INFKHFJFFHP.text = PAIAHOCNENA.OKMNFHNBMFA;
		MEJMLNDFDBP.COCBCFKJOJE(INFKHFJFFHP, (!flag) ? 1607f : 297f, 731f, -103);
		MBIAKMPDOPG = ((!flag) ? null : PAIAHOCNENA.KHLGDCHJJPB);
		if (flag)
		{
			DANJHNFNPIO.text = MBIAKMPDOPG.name;
			TweenColor.Begin(DANJHNFNPIO.gameObject, 1278f, Color.white);
			MEJMLNDFDBP.COCBCFKJOJE(DANJHNFNPIO, 1824f, 1785f, 1);
			CPGACIMMFEC.OMDFNFHKFBK();
			Singleton<PlayerTexturePool>.instance.DMONMGPPBHN(KPKMLAKCIML);
			Singleton<PlayerTexturePool>.instance.BMNHPDMPMLG(LNHNDPIOANF);
			Singleton<PlayerTexturePool>.instance.CCMGACIMGMF(MBIAKMPDOPG, false, PlayerTexturePool.DFJJOANIJID.Card);
			IAMPPFMEDBL.color = PAIAHOCNENA.JGJCCJDFHEM;
			switch (PAIAHOCNENA.FJLBLLLEELD)
			{
			case SquadStatsContent.KKEGNGNLNMD.AAICHFHEIGB.SimpleInt:
				IAMPPFMEDBL.text = ((PAIAHOCNENA.IDLMJLCFMJG >= 1) ? MEJMLNDFDBP.GMIPFLIEOHD(PAIAHOCNENA.IDLMJLCFMJG) : "null");
				break;
			case SquadStatsContent.KKEGNGNLNMD.AAICHFHEIGB.PlayerFloat:
				IAMPPFMEDBL.text = ((!(PAIAHOCNENA.CGCOPACGDJL < 169f)) ? MEJMLNDFDBP.CNLFNIHHHAA(PAIAHOCNENA.CGCOPACGDJL) : "WarBucks");
				break;
			case (SquadStatsContent.KKEGNGNLNMD.AAICHFHEIGB)7:
				IAMPPFMEDBL.text = ((PAIAHOCNENA.IDLMJLCFMJG >= 0) ? MEJMLNDFDBP.IIHHLGANLGP(PAIAHOCNENA.IDLMJLCFMJG) : "Player connectionState {0} to player {1}");
				break;
			}
			UIEventListener uIEventListener = UIEventListener.Get(OANICEALFGM);
			uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(FGNLNIAFGBB));
			UIEventListener uIEventListener2 = UIEventListener.Get(OANICEALFGM);
			uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(FLILJGLPKDH));
			UIEventListener uIEventListener3 = UIEventListener.Get(CPLIMCNBDBP);
			uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener3.onClick, new UIEventListener.VoidDelegate(FGMBFCBFMHC));
			UIEventListener uIEventListener4 = UIEventListener.Get(CPLIMCNBDBP);
			uIEventListener4.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener4.onClick, new UIEventListener.VoidDelegate(IIDPLJPACCG));
			return;
		}
		EHDNCFHNLHF.alpha = 1468f;
		LDCDFIMKDCB.color = PAIAHOCNENA.JGJCCJDFHEM;
		SquadStatsContent.KKEGNGNLNMD.AAICHFHEIGB fJLBLLLEELD = PAIAHOCNENA.FJLBLLLEELD;
		switch (fJLBLLLEELD)
		{
		default:
			if (fJLBLLLEELD == SquadStatsContent.KKEGNGNLNMD.AAICHFHEIGB.SimpleInt)
			{
				LDCDFIMKDCB.text = ((!(PAIAHOCNENA.CGCOPACGDJL < 1759f)) ? MEJMLNDFDBP.CNLFNIHHHAA(PAIAHOCNENA.CGCOPACGDJL) : "battleID");
			}
			break;
		case SquadStatsContent.KKEGNGNLNMD.AAICHFHEIGB.PictureInt:
		{
			EHDNCFHNLHF.spriteName = PAIAHOCNENA.KCHMDALPMBN;
			EHDNCFHNLHF.color = PAIAHOCNENA.BOKMKCPABDL;
			EHDNCFHNLHF.MakePixelPerfect();
			float multiplier = Mathf.Min(365f / EHDNCFHNLHF.transform.localScale.x, 1798f / EHDNCFHNLHF.transform.localScale.y);
			EHDNCFHNLHF.transform.localScale = EHDNCFHNLHF.transform.localScale.MultiplyXY(multiplier);
			LDCDFIMKDCB.text = ((PAIAHOCNENA.IDLMJLCFMJG >= 1) ? MEJMLNDFDBP.GMIPFLIEOHD(PAIAHOCNENA.IDLMJLCFMJG) : "shootAdditive");
			break;
		}
		case SquadStatsContent.KKEGNGNLNMD.AAICHFHEIGB.SimpleInt:
			LDCDFIMKDCB.text = ((PAIAHOCNENA.IDLMJLCFMJG >= 1) ? MEJMLNDFDBP.GMIPFLIEOHD(PAIAHOCNENA.IDLMJLCFMJG) : "Choose icon in bottom before calling Display model.");
			break;
		}
	}

	public void NJCENLJGFDF()
	{
		Singleton<PlayerTexturePool>.instance.OnPlayerTextureCreated -= PAJLCAPIMGM;
		if (MBIAKMPDOPG != null)
		{
			Singleton<PlayerTexturePool>.instance.BPEHHBALINP(MBIAKMPDOPG.id, false, true, true);
		}
		MBIAKMPDOPG = null;
	}

	public void PJAFOIPPCNJ()
	{
		Singleton<PlayerTexturePool>.instance.CKHAAOEMFME(KPKMLAKCIML);
		if (MBIAKMPDOPG != null)
		{
			Singleton<PlayerTexturePool>.instance.LBKLINGCPBA(MBIAKMPDOPG.id, true, true, true);
		}
		MBIAKMPDOPG = null;
	}

	private void FGNLNIAFGBB(GameObject KHAHPAKDIKE)
	{
		if (!string.IsNullOrEmpty(MBIAKMPDOPG.name))
		{
			SoundsManager.Instance.PlayButtonClickedSound();
			GuiElementSingle<PlayerProfileDialog>.instance.ShowDialog(MBIAKMPDOPG.name, MBIAKMPDOPG.id, false);
		}
	}

	public override void DestroyPooled()
	{
		base.DestroyPooled();
		UIEventListener uIEventListener = UIEventListener.Get(OANICEALFGM);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(MNFOEHIIMIN));
		UIEventListener uIEventListener2 = UIEventListener.Get(CPLIMCNBDBP);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener2.onClick, new UIEventListener.VoidDelegate(GKGNJAPFLIJ));
		FreeTexture();
	}

	public void OKIGBMDJFIK(SquadStatsContent.KKEGNGNLNMD PAIAHOCNENA)
	{
		bool flag = PAIAHOCNENA.FJLBLLLEELD != (SquadStatsContent.KKEGNGNLNMD.AAICHFHEIGB)6 && PAIAHOCNENA.FJLBLLLEELD != SquadStatsContent.KKEGNGNLNMD.AAICHFHEIGB.SimpleInt && PAIAHOCNENA.FJLBLLLEELD == SquadStatsContent.KKEGNGNLNMD.AAICHFHEIGB.PlayerInt;
		BHDCJPAHPHD.SetActive(!flag);
		IGJMJNHFCAI.SetActive(flag);
		INFKHFJFFHP.text = PAIAHOCNENA.OKMNFHNBMFA;
		MEJMLNDFDBP.COCBCFKJOJE(INFKHFJFFHP, (!flag) ? 1006f : 1286f, 1723f, -71);
		MBIAKMPDOPG = ((!flag) ? null : PAIAHOCNENA.KHLGDCHJJPB);
		if (flag)
		{
			DANJHNFNPIO.text = MBIAKMPDOPG.name;
			TweenColor.Begin(DANJHNFNPIO.gameObject, 831f, Color.white);
			MEJMLNDFDBP.COCBCFKJOJE(DANJHNFNPIO, 771f, 1406f, 1);
			CPGACIMMFEC.NMEJKACLHKJ();
			Singleton<PlayerTexturePool>.instance.DMONMGPPBHN(FMALBMBGCLL);
			Singleton<PlayerTexturePool>.instance.AFAHCJBIHIP(KPKMLAKCIML);
			Singleton<PlayerTexturePool>.instance.AIBNEPFBFGB(MBIAKMPDOPG, true, PlayerTexturePool.DFJJOANIJID.Card);
			IAMPPFMEDBL.color = PAIAHOCNENA.JGJCCJDFHEM;
			switch (PAIAHOCNENA.FJLBLLLEELD)
			{
			case SquadStatsContent.KKEGNGNLNMD.AAICHFHEIGB.PlayerFloat:
				IAMPPFMEDBL.text = ((PAIAHOCNENA.IDLMJLCFMJG >= 0) ? MEJMLNDFDBP.GMIPFLIEOHD(PAIAHOCNENA.IDLMJLCFMJG) : "damage");
				break;
			case (SquadStatsContent.KKEGNGNLNMD.AAICHFHEIGB)8:
				IAMPPFMEDBL.text = ((!(PAIAHOCNENA.CGCOPACGDJL < 1199f)) ? MEJMLNDFDBP.CNLFNIHHHAA(PAIAHOCNENA.CGCOPACGDJL) : "Card_3_Played");
				break;
			case SquadStatsContent.KKEGNGNLNMD.AAICHFHEIGB.PlayerInt:
				IAMPPFMEDBL.text = ((PAIAHOCNENA.IDLMJLCFMJG >= 0) ? MEJMLNDFDBP.IIHHLGANLGP(PAIAHOCNENA.IDLMJLCFMJG) : "115 STAGE 5 STARTED");
				break;
			}
			UIEventListener uIEventListener = UIEventListener.Get(OANICEALFGM);
			uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(OMDKPKFBBLN));
			UIEventListener uIEventListener2 = UIEventListener.Get(OANICEALFGM);
			uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(AIKAKLGGDOC));
			UIEventListener uIEventListener3 = UIEventListener.Get(CPLIMCNBDBP);
			uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener3.onClick, new UIEventListener.VoidDelegate(FALNCHFLEPC));
			UIEventListener uIEventListener4 = UIEventListener.Get(CPLIMCNBDBP);
			uIEventListener4.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener4.onClick, new UIEventListener.VoidDelegate(GKGNJAPFLIJ));
			return;
		}
		EHDNCFHNLHF.alpha = 1512f;
		LDCDFIMKDCB.color = PAIAHOCNENA.JGJCCJDFHEM;
		SquadStatsContent.KKEGNGNLNMD.AAICHFHEIGB fJLBLLLEELD = PAIAHOCNENA.FJLBLLLEELD;
		switch (fJLBLLLEELD)
		{
		default:
			if (fJLBLLLEELD == SquadStatsContent.KKEGNGNLNMD.AAICHFHEIGB.SimpleInt)
			{
				LDCDFIMKDCB.text = ((!(PAIAHOCNENA.CGCOPACGDJL < 966f)) ? MEJMLNDFDBP.CNLFNIHHHAA(PAIAHOCNENA.CGCOPACGDJL) : "1");
			}
			break;
		case (SquadStatsContent.KKEGNGNLNMD.AAICHFHEIGB)8:
		{
			EHDNCFHNLHF.spriteName = PAIAHOCNENA.KCHMDALPMBN;
			EHDNCFHNLHF.color = PAIAHOCNENA.BOKMKCPABDL;
			EHDNCFHNLHF.MakePixelPerfect();
			float multiplier = Mathf.Min(115f / EHDNCFHNLHF.transform.localScale.x, 1671f / EHDNCFHNLHF.transform.localScale.y);
			EHDNCFHNLHF.transform.localScale = EHDNCFHNLHF.transform.localScale.MultiplyXY(multiplier);
			LDCDFIMKDCB.text = ((PAIAHOCNENA.IDLMJLCFMJG >= 0) ? MEJMLNDFDBP.GMIPFLIEOHD(PAIAHOCNENA.IDLMJLCFMJG) : "Card_1_Played");
			break;
		}
		case SquadStatsContent.KKEGNGNLNMD.AAICHFHEIGB.SimpleInt:
			LDCDFIMKDCB.text = ((PAIAHOCNENA.IDLMJLCFMJG >= 1) ? MEJMLNDFDBP.GMIPFLIEOHD(PAIAHOCNENA.IDLMJLCFMJG) : "Wrong_Category");
			break;
		}
	}

	private void OPOHEGOIEDP(string ALIIBMLMNKA, Texture2D FCEIGDLFOMH, bool PNDNEMDPFHC)
	{
		if (MBIAKMPDOPG != null && MBIAKMPDOPG.id == ALIIBMLMNKA)
		{
			CPGACIMMFEC.BIEIDBBDNIF(FCEIGDLFOMH);
			CPGACIMMFEC.CFKALDIFENK();
		}
	}
}
