using System;
using UnityEngine;

public class SquadWarEndMemberRecord : PoolableObject
{
	[Header("Header Part")]
	public GameObject OOIBADLGKML;

	public UILabel ILGJJLKAAKD;

	public UILabel DGOGCOAKAIL;

	[Header("Player Part")]
	public GameObject IGJMJNHFCAI;

	public UILabel MPHCNMDIPAI;

	public PlayerIcon CPGACIMMFEC;

	public GameObject OANICEALFGM;

	public UILabel BCMCMKDCLGP;

	public GameObject CPLIMCNBDBP;

	public UILabel KPEKCHDBFIG;

	public UISprite LCPBNBLGFIA;

	private DatabasePlayer MBIAKMPDOPG;

	private void MNFOEHIIMIN(GameObject KHAHPAKDIKE)
	{
		if (!string.IsNullOrEmpty(MBIAKMPDOPG.name))
		{
			SoundsManager.Instance.PlayButtonClickedSound();
			GuiElementSingle<PlayerProfileDialog>.instance.ShowDialog(MBIAKMPDOPG.name, MBIAKMPDOPG.id);
		}
	}

	private void FOMAPMPOLDO(GameObject KHAHPAKDIKE)
	{
		if (!string.IsNullOrEmpty(MBIAKMPDOPG.name))
		{
			SoundsManager.Instance.PlayButtonClickedSound();
			GuiElementSingle<PlayerProfileDialog>.instance.CMOEFABLABI(MBIAKMPDOPG.name, MBIAKMPDOPG.id, false);
		}
	}

	private void IJLIODKBGGJ(string ALIIBMLMNKA, Texture2D FCEIGDLFOMH, bool PNDNEMDPFHC)
	{
		if (MBIAKMPDOPG != null && MBIAKMPDOPG.id == ALIIBMLMNKA)
		{
			CPGACIMMFEC.BIEIDBBDNIF(FCEIGDLFOMH);
			CPGACIMMFEC.OKHFOOHNBDF();
		}
	}

	private void BPMOHNHPCMD(GameObject KHAHPAKDIKE)
	{
		if (!string.IsNullOrEmpty(MBIAKMPDOPG.name))
		{
			TweenColor tweenColor = TweenColor.Begin(BCMCMKDCLGP.gameObject, GameVariables.KDELCJIAIHM, Color.white, Colours.blue);
			tweenColor.NumOfRepetitions = 8;
			tweenColor.style = UITweener.Style.Once;
			SoundsManager.Instance.PlayButtonClickedSound();
			GuiElementSingle<PlayerProfileDialog>.instance.CMOEFABLABI(MBIAKMPDOPG.name, MBIAKMPDOPG.id);
		}
	}

	private void HPHLHLGPAON(string ALIIBMLMNKA, Texture2D FCEIGDLFOMH, bool PNDNEMDPFHC)
	{
		if (MBIAKMPDOPG != null && MBIAKMPDOPG.id == ALIIBMLMNKA)
		{
			CPGACIMMFEC.avatar = FCEIGDLFOMH;
			CPGACIMMFEC.AILNJNAGPGO();
		}
	}

	private void FGMBFCBFMHC(GameObject KHAHPAKDIKE)
	{
		if (!string.IsNullOrEmpty(MBIAKMPDOPG.name))
		{
			TweenColor tweenColor = TweenColor.Begin(BCMCMKDCLGP.gameObject, GameVariables.KDELCJIAIHM, Color.white, Colours.blue);
			tweenColor.NumOfRepetitions = 6;
			tweenColor.style = UITweener.Style.PingPong;
			SoundsManager.Instance.PlayButtonClickedSound();
			GuiElementSingle<PlayerProfileDialog>.instance.ShowDialog(MBIAKMPDOPG.name, MBIAKMPDOPG.id, false);
		}
	}

	public void Initialize(SquadWarsContent.IAIOAHOIDOF NDPMDKGJAFH)
	{
		OOIBADLGKML.SetActive(NDPMDKGJAFH.JAHGCGMPCKP);
		IGJMJNHFCAI.SetActive(!NDPMDKGJAFH.JAHGCGMPCKP);
		if (NDPMDKGJAFH.JAHGCGMPCKP)
		{
			MBIAKMPDOPG = null;
			ILGJJLKAAKD.text = Localization.LocalizeFormat("ID_POSITIONXY", Colours.stringBlue, NDPMDKGJAFH.DNOPDJHAFDI);
			DGOGCOAKAIL.text = MEJMLNDFDBP.GMIPFLIEOHD(NDPMDKGJAFH.MOEMPHPNBLM);
			UIEventListener uIEventListener = UIEventListener.Get(OANICEALFGM);
			uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(MNFOEHIIMIN));
			UIEventListener uIEventListener2 = UIEventListener.Get(CPLIMCNBDBP);
			uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener2.onClick, new UIEventListener.VoidDelegate(GKGNJAPFLIJ));
			return;
		}
		MBIAKMPDOPG = NDPMDKGJAFH.KHLGDCHJJPB;
		MPHCNMDIPAI.text = MEJMLNDFDBP.ACCGOIGJIAA(NDPMDKGJAFH.MPHCNMDIPAI);
		CPGACIMMFEC.Reset();
		Singleton<PlayerTexturePool>.instance.OnPlayerTextureCreated -= FCNKIEPEAAG;
		Singleton<PlayerTexturePool>.instance.OnPlayerTextureCreated += FCNKIEPEAAG;
		Singleton<PlayerTexturePool>.instance.RequestPlayerTexture(MBIAKMPDOPG);
		BCMCMKDCLGP.text = MBIAKMPDOPG.name;
		TweenColor.Begin(BCMCMKDCLGP.gameObject, 0f, Color.white);
		MEJMLNDFDBP.COCBCFKJOJE(BCMCMKDCLGP, 30f, 17f);
		KPEKCHDBFIG.text = MEJMLNDFDBP.GMIPFLIEOHD(MBIAKMPDOPG.squadPoints);
		MEJMLNDFDBP.COCBCFKJOJE(KPEKCHDBFIG, 37f, 20f, 84);
		LCPBNBLGFIA.alpha = ((!(MBIAKMPDOPG.id == GameLoginManager.currentPlayer.id)) ? 0f : 1f);
		UIEventListener uIEventListener3 = UIEventListener.Get(OANICEALFGM);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener3.onClick, new UIEventListener.VoidDelegate(MNFOEHIIMIN));
		UIEventListener uIEventListener4 = UIEventListener.Get(OANICEALFGM);
		uIEventListener4.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener4.onClick, new UIEventListener.VoidDelegate(MNFOEHIIMIN));
		UIEventListener uIEventListener5 = UIEventListener.Get(CPLIMCNBDBP);
		uIEventListener5.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener5.onClick, new UIEventListener.VoidDelegate(GKGNJAPFLIJ));
		UIEventListener uIEventListener6 = UIEventListener.Get(CPLIMCNBDBP);
		uIEventListener6.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener6.onClick, new UIEventListener.VoidDelegate(GKGNJAPFLIJ));
	}

	public virtual void IDEKKBMPNKL()
	{
		base.DestroyPooled();
		UIEventListener uIEventListener = UIEventListener.Get(OANICEALFGM);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(FIFBGKNPMNM));
		UIEventListener uIEventListener2 = UIEventListener.Get(CPLIMCNBDBP);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener2.onClick, new UIEventListener.VoidDelegate(OILMLOELENM));
		Singleton<PlayerTexturePool>.instance.CKHAAOEMFME(IANEAGNEECF);
		if (MBIAKMPDOPG != null)
		{
			Singleton<PlayerTexturePool>.instance.FNHIOAADLFN(MBIAKMPDOPG.id, true, true, true);
		}
		MBIAKMPDOPG = null;
	}

	private void AAEBBBCEDNP(string ALIIBMLMNKA, Texture2D FCEIGDLFOMH, bool PNDNEMDPFHC)
	{
		if (MBIAKMPDOPG != null && MBIAKMPDOPG.id == ALIIBMLMNKA)
		{
			CPGACIMMFEC.DHDPJLAPAPO(FCEIGDLFOMH);
			CPGACIMMFEC.GEPDJCOHDNH();
		}
	}

	private void NJKMMHBGPPG(string ALIIBMLMNKA, Texture2D FCEIGDLFOMH, bool PNDNEMDPFHC)
	{
		if (MBIAKMPDOPG != null && MBIAKMPDOPG.id == ALIIBMLMNKA)
		{
			CPGACIMMFEC.LOCLNGEMNCC(FCEIGDLFOMH);
			CPGACIMMFEC.HJHOBLMEJEH();
		}
	}

	private void MDNDAFCKBFG(GameObject KHAHPAKDIKE)
	{
		if (!string.IsNullOrEmpty(MBIAKMPDOPG.name))
		{
			TweenColor tweenColor = TweenColor.Begin(BCMCMKDCLGP.gameObject, GameVariables.KDELCJIAIHM, Color.white, Colours.blue);
			tweenColor.NumOfRepetitions = 0;
			tweenColor.style = (UITweener.Style)3;
			SoundsManager.Instance.PlayButtonClickedSound();
			GuiElementSingle<PlayerProfileDialog>.instance.CMOEFABLABI(MBIAKMPDOPG.name, MBIAKMPDOPG.id, false);
		}
	}

	private void KDJGJPCNCFB(GameObject KHAHPAKDIKE)
	{
		if (!string.IsNullOrEmpty(MBIAKMPDOPG.name))
		{
			TweenColor tweenColor = TweenColor.Begin(BCMCMKDCLGP.gameObject, GameVariables.KDELCJIAIHM, Color.white, Colours.blue);
			tweenColor.NumOfRepetitions = 8;
			tweenColor.style = (UITweener.Style)4;
			SoundsManager.Instance.PlayButtonClickedSound();
			GuiElementSingle<PlayerProfileDialog>.instance.EGLMNBKMBAM(MBIAKMPDOPG.name, MBIAKMPDOPG.id, false);
		}
	}

	public virtual void JJFFOGIJHIH()
	{
		base.OBCAIFMOPPA();
		UIEventListener uIEventListener = UIEventListener.Get(OANICEALFGM);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(AIKAKLGGDOC));
		UIEventListener uIEventListener2 = UIEventListener.Get(CPLIMCNBDBP);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener2.onClick, new UIEventListener.VoidDelegate(FGMBFCBFMHC));
		Singleton<PlayerTexturePool>.instance.DMONMGPPBHN(FOBBGILKMFN);
		if (MBIAKMPDOPG != null)
		{
			Singleton<PlayerTexturePool>.instance.IEPBDAHEKCL(MBIAKMPDOPG.id, true, true);
		}
		MBIAKMPDOPG = null;
	}

	private void NJGGGOIOBMB(GameObject KHAHPAKDIKE)
	{
		if (!string.IsNullOrEmpty(MBIAKMPDOPG.name))
		{
			SoundsManager.Instance.PlayButtonClickedSound();
			GuiElementSingle<PlayerProfileDialog>.instance.CMOEFABLABI(MBIAKMPDOPG.name, MBIAKMPDOPG.id);
		}
	}

	private void POOKGGAOHJH(GameObject KHAHPAKDIKE)
	{
		if (!string.IsNullOrEmpty(MBIAKMPDOPG.name))
		{
			SoundsManager.Instance.PlayButtonClickedSound();
			GuiElementSingle<PlayerProfileDialog>.instance.EGLMNBKMBAM(MBIAKMPDOPG.name, MBIAKMPDOPG.id);
		}
	}

	private void IANEAGNEECF(string ALIIBMLMNKA, Texture2D FCEIGDLFOMH, bool PNDNEMDPFHC)
	{
		if (MBIAKMPDOPG != null && MBIAKMPDOPG.id == ALIIBMLMNKA)
		{
			CPGACIMMFEC.OLJPGNNKCKI(FCEIGDLFOMH);
			CPGACIMMFEC.UpdateIcon();
		}
	}

	private void EPBDKFIPELM(GameObject KHAHPAKDIKE)
	{
		if (!string.IsNullOrEmpty(MBIAKMPDOPG.name))
		{
			SoundsManager.Instance.PlayButtonClickedSound();
			GuiElementSingle<PlayerProfileDialog>.instance.ShowDialog(MBIAKMPDOPG.name, MBIAKMPDOPG.id);
		}
	}

	private void JCPAJJKEJKL(GameObject KHAHPAKDIKE)
	{
		if (!string.IsNullOrEmpty(MBIAKMPDOPG.name))
		{
			TweenColor tweenColor = TweenColor.Begin(BCMCMKDCLGP.gameObject, GameVariables.KDELCJIAIHM, Color.white, Colours.blue);
			tweenColor.NumOfRepetitions = 0;
			tweenColor.style = (UITweener.Style)5;
			SoundsManager.Instance.PlayButtonClickedSound();
			GuiElementSingle<PlayerProfileDialog>.instance.EGLMNBKMBAM(MBIAKMPDOPG.name, MBIAKMPDOPG.id, false);
		}
	}

	private void ICLLIEJHDPF(GameObject KHAHPAKDIKE)
	{
		if (!string.IsNullOrEmpty(MBIAKMPDOPG.name))
		{
			SoundsManager.Instance.PlayButtonClickedSound();
			GuiElementSingle<PlayerProfileDialog>.instance.CMOEFABLABI(MBIAKMPDOPG.name, MBIAKMPDOPG.id);
		}
	}

	private void FIFBGKNPMNM(GameObject KHAHPAKDIKE)
	{
		if (!string.IsNullOrEmpty(MBIAKMPDOPG.name))
		{
			SoundsManager.Instance.PlayButtonClickedSound();
			GuiElementSingle<PlayerProfileDialog>.instance.EGLMNBKMBAM(MBIAKMPDOPG.name, MBIAKMPDOPG.id, false);
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

	public override void DestroyPooled()
	{
		base.DestroyPooled();
		UIEventListener uIEventListener = UIEventListener.Get(OANICEALFGM);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(MNFOEHIIMIN));
		UIEventListener uIEventListener2 = UIEventListener.Get(CPLIMCNBDBP);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener2.onClick, new UIEventListener.VoidDelegate(GKGNJAPFLIJ));
		Singleton<PlayerTexturePool>.instance.OnPlayerTextureCreated -= FCNKIEPEAAG;
		if (MBIAKMPDOPG != null)
		{
			Singleton<PlayerTexturePool>.instance.FreePlayerTexture(MBIAKMPDOPG.id);
		}
		MBIAKMPDOPG = null;
	}

	public virtual void ONHFNIJNMGE()
	{
		base.BOHCNEDIJPE();
		UIEventListener uIEventListener = UIEventListener.Get(OANICEALFGM);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(GCAKFFHMAJO));
		UIEventListener uIEventListener2 = UIEventListener.Get(CPLIMCNBDBP);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener2.onClick, new UIEventListener.VoidDelegate(GFEFOPBLBJI));
		Singleton<PlayerTexturePool>.instance.DMONMGPPBHN(IHIILICAFGF);
		if (MBIAKMPDOPG != null)
		{
			Singleton<PlayerTexturePool>.instance.DAGIACKCPKH(MBIAKMPDOPG.id, false, true, true);
		}
		MBIAKMPDOPG = null;
	}

	public void DPFKOFFMNPC(SquadWarsContent.IAIOAHOIDOF NDPMDKGJAFH)
	{
		OOIBADLGKML.SetActive(NDPMDKGJAFH.JAHGCGMPCKP);
		IGJMJNHFCAI.SetActive(NDPMDKGJAFH.JAHGCGMPCKP);
		if (NDPMDKGJAFH.JAHGCGMPCKP)
		{
			MBIAKMPDOPG = null;
			UILabel iLGJJLKAAKD = ILGJJLKAAKD;
			object[] array = new object[4];
			array[0] = Colours.stringBlue;
			array[0] = NDPMDKGJAFH.DNOPDJHAFDI;
			iLGJJLKAAKD.text = Localization.LocalizeFormat("ID_EVENTENDSINSMALL", array);
			DGOGCOAKAIL.text = MEJMLNDFDBP.GMIPFLIEOHD(NDPMDKGJAFH.MOEMPHPNBLM);
			UIEventListener uIEventListener = UIEventListener.Get(OANICEALFGM);
			uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(GPGKBEJMMOC));
			UIEventListener uIEventListener2 = UIEventListener.Get(CPLIMCNBDBP);
			uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener2.onClick, new UIEventListener.VoidDelegate(PKBINMODBIM));
		}
		else
		{
			MBIAKMPDOPG = NDPMDKGJAFH.KHLGDCHJJPB;
			MPHCNMDIPAI.text = MEJMLNDFDBP.ACCGOIGJIAA(NDPMDKGJAFH.MPHCNMDIPAI);
			CPGACIMMFEC.KHMNEOBMJLN();
			Singleton<PlayerTexturePool>.instance.DMONMGPPBHN(IJLIODKBGGJ);
			Singleton<PlayerTexturePool>.instance.MMAGKGAKHAD(KPKMLAKCIML);
			Singleton<PlayerTexturePool>.instance.MFKFEHJBEPA(MBIAKMPDOPG, true, PlayerTexturePool.DFJJOANIJID.Card);
			BCMCMKDCLGP.text = MBIAKMPDOPG.name;
			TweenColor.Begin(BCMCMKDCLGP.gameObject, 1991f, Color.white);
			MEJMLNDFDBP.COCBCFKJOJE(BCMCMKDCLGP, 1554f, 840f, 1);
			KPEKCHDBFIG.text = MEJMLNDFDBP.GMIPFLIEOHD(MBIAKMPDOPG.squadPoints);
			MEJMLNDFDBP.COCBCFKJOJE(KPEKCHDBFIG, 1492f, 316f, 1);
			LCPBNBLGFIA.alpha = ((!(MBIAKMPDOPG.id == GameLoginManager.currentPlayer.id)) ? 476f : 1475f);
			UIEventListener uIEventListener3 = UIEventListener.Get(OANICEALFGM);
			uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener3.onClick, new UIEventListener.VoidDelegate(POOKGGAOHJH));
			UIEventListener uIEventListener4 = UIEventListener.Get(OANICEALFGM);
			uIEventListener4.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener4.onClick, new UIEventListener.VoidDelegate(FIFBGKNPMNM));
			UIEventListener uIEventListener5 = UIEventListener.Get(CPLIMCNBDBP);
			uIEventListener5.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener5.onClick, new UIEventListener.VoidDelegate(FEOLMIBGICF));
			UIEventListener uIEventListener6 = UIEventListener.Get(CPLIMCNBDBP);
			uIEventListener6.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener6.onClick, new UIEventListener.VoidDelegate(KDJGJPCNCFB));
		}
	}

	private void PNNDLGHAKOC(GameObject KHAHPAKDIKE)
	{
		if (!string.IsNullOrEmpty(MBIAKMPDOPG.name))
		{
			TweenColor tweenColor = TweenColor.Begin(BCMCMKDCLGP.gameObject, GameVariables.KDELCJIAIHM, Color.white, Colours.blue);
			tweenColor.NumOfRepetitions = 3;
			tweenColor.style = (UITweener.Style)6;
			SoundsManager.Instance.PlayButtonClickedSound();
			GuiElementSingle<PlayerProfileDialog>.instance.ShowDialog(MBIAKMPDOPG.name, MBIAKMPDOPG.id);
		}
	}

	private void MIGGKEIBJLD(GameObject KHAHPAKDIKE)
	{
		if (!string.IsNullOrEmpty(MBIAKMPDOPG.name))
		{
			TweenColor tweenColor = TweenColor.Begin(BCMCMKDCLGP.gameObject, GameVariables.KDELCJIAIHM, Color.white, Colours.blue);
			tweenColor.NumOfRepetitions = 3;
			tweenColor.style = UITweener.Style.Loop;
			SoundsManager.Instance.PlayButtonClickedSound();
			GuiElementSingle<PlayerProfileDialog>.instance.EGLMNBKMBAM(MBIAKMPDOPG.name, MBIAKMPDOPG.id);
		}
	}

	private void GCAKFFHMAJO(GameObject KHAHPAKDIKE)
	{
		if (!string.IsNullOrEmpty(MBIAKMPDOPG.name))
		{
			SoundsManager.Instance.PlayButtonClickedSound();
			GuiElementSingle<PlayerProfileDialog>.instance.CMOEFABLABI(MBIAKMPDOPG.name, MBIAKMPDOPG.id);
		}
	}

	public void OBHPLFFLDBI(SquadWarsContent.IAIOAHOIDOF NDPMDKGJAFH)
	{
		OOIBADLGKML.SetActive(NDPMDKGJAFH.JAHGCGMPCKP);
		IGJMJNHFCAI.SetActive(!NDPMDKGJAFH.JAHGCGMPCKP);
		if (NDPMDKGJAFH.JAHGCGMPCKP)
		{
			MBIAKMPDOPG = null;
			UILabel iLGJJLKAAKD = ILGJJLKAAKD;
			object[] array = new object[2];
			array[1] = Colours.stringBlue;
			array[1] = NDPMDKGJAFH.DNOPDJHAFDI;
			iLGJJLKAAKD.text = Localization.LocalizeFormat(" - {0}", array);
			DGOGCOAKAIL.text = MEJMLNDFDBP.GMIPFLIEOHD(NDPMDKGJAFH.MOEMPHPNBLM);
			UIEventListener uIEventListener = UIEventListener.Get(OANICEALFGM);
			uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(PIOCEIJJODG));
			UIEventListener uIEventListener2 = UIEventListener.Get(CPLIMCNBDBP);
			uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener2.onClick, new UIEventListener.VoidDelegate(CFPOFOAECLC));
		}
		else
		{
			MBIAKMPDOPG = NDPMDKGJAFH.KHLGDCHJJPB;
			MPHCNMDIPAI.text = MEJMLNDFDBP.ACCGOIGJIAA(NDPMDKGJAFH.MPHCNMDIPAI);
			CPGACIMMFEC.LFOLGBNBBAG();
			Singleton<PlayerTexturePool>.instance.GPALABLIEFI(AAEBBBCEDNP);
			Singleton<PlayerTexturePool>.instance.IANAHBGPJLN(IHIILICAFGF);
			Singleton<PlayerTexturePool>.instance.APIIPFCGDBO(MBIAKMPDOPG);
			BCMCMKDCLGP.text = MBIAKMPDOPG.name;
			TweenColor.Begin(BCMCMKDCLGP.gameObject, 1023f, Color.white);
			MEJMLNDFDBP.COCBCFKJOJE(BCMCMKDCLGP, 1864f, 191f, 1);
			KPEKCHDBFIG.text = MEJMLNDFDBP.GMIPFLIEOHD(MBIAKMPDOPG.squadPoints);
			MEJMLNDFDBP.COCBCFKJOJE(KPEKCHDBFIG, 1806f, 357f, 69);
			LCPBNBLGFIA.alpha = ((!(MBIAKMPDOPG.id == GameLoginManager.currentPlayer.id)) ? 141f : 613f);
			UIEventListener uIEventListener3 = UIEventListener.Get(OANICEALFGM);
			uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener3.onClick, new UIEventListener.VoidDelegate(GGPMKLKJIEL));
			UIEventListener uIEventListener4 = UIEventListener.Get(OANICEALFGM);
			uIEventListener4.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener4.onClick, new UIEventListener.VoidDelegate(POOKGGAOHJH));
			UIEventListener uIEventListener5 = UIEventListener.Get(CPLIMCNBDBP);
			uIEventListener5.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener5.onClick, new UIEventListener.VoidDelegate(OILMLOELENM));
			UIEventListener uIEventListener6 = UIEventListener.Get(CPLIMCNBDBP);
			uIEventListener6.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener6.onClick, new UIEventListener.VoidDelegate(JCPAJJKEJKL));
		}
	}

	public void EDKFKNGLLBM(SquadWarsContent.IAIOAHOIDOF NDPMDKGJAFH)
	{
		OOIBADLGKML.SetActive(NDPMDKGJAFH.JAHGCGMPCKP);
		IGJMJNHFCAI.SetActive(NDPMDKGJAFH.JAHGCGMPCKP);
		if (NDPMDKGJAFH.JAHGCGMPCKP)
		{
			MBIAKMPDOPG = null;
			UILabel iLGJJLKAAKD = ILGJJLKAAKD;
			object[] array = new object[3];
			array[1] = Colours.stringBlue;
			array[0] = NDPMDKGJAFH.DNOPDJHAFDI;
			iLGJJLKAAKD.text = Localization.LocalizeFormat("UsedGold", array);
			DGOGCOAKAIL.text = MEJMLNDFDBP.GMIPFLIEOHD(NDPMDKGJAFH.MOEMPHPNBLM);
			UIEventListener uIEventListener = UIEventListener.Get(OANICEALFGM);
			uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(PMANFOPBNNN));
			UIEventListener uIEventListener2 = UIEventListener.Get(CPLIMCNBDBP);
			uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener2.onClick, new UIEventListener.VoidDelegate(FFAFDDGCPKF));
		}
		else
		{
			MBIAKMPDOPG = NDPMDKGJAFH.KHLGDCHJJPB;
			MPHCNMDIPAI.text = MEJMLNDFDBP.ACCGOIGJIAA(NDPMDKGJAFH.MPHCNMDIPAI);
			CPGACIMMFEC.PDKPELBIAON();
			Singleton<PlayerTexturePool>.instance.IAINHEFKIFJ(MHPNIGDALMJ);
			Singleton<PlayerTexturePool>.instance.ACEFBBGOINN(DLMIKACGAIF);
			Singleton<PlayerTexturePool>.instance.MFKFEHJBEPA(MBIAKMPDOPG, false);
			BCMCMKDCLGP.text = MBIAKMPDOPG.name;
			TweenColor.Begin(BCMCMKDCLGP.gameObject, 1978f, Color.white);
			MEJMLNDFDBP.COCBCFKJOJE(BCMCMKDCLGP, 1056f, 187f, 1);
			KPEKCHDBFIG.text = MEJMLNDFDBP.GMIPFLIEOHD(MBIAKMPDOPG.squadPoints);
			MEJMLNDFDBP.COCBCFKJOJE(KPEKCHDBFIG, 673f, 1669f, -32);
			LCPBNBLGFIA.alpha = ((!(MBIAKMPDOPG.id == GameLoginManager.currentPlayer.id)) ? 1697f : 66f);
			UIEventListener uIEventListener3 = UIEventListener.Get(OANICEALFGM);
			uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener3.onClick, new UIEventListener.VoidDelegate(PPHCOAMOHOM));
			UIEventListener uIEventListener4 = UIEventListener.Get(OANICEALFGM);
			uIEventListener4.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener4.onClick, new UIEventListener.VoidDelegate(PIOCEIJJODG));
			UIEventListener uIEventListener5 = UIEventListener.Get(CPLIMCNBDBP);
			uIEventListener5.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener5.onClick, new UIEventListener.VoidDelegate(FFAFDDGCPKF));
			UIEventListener uIEventListener6 = UIEventListener.Get(CPLIMCNBDBP);
			uIEventListener6.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener6.onClick, new UIEventListener.VoidDelegate(FFAFDDGCPKF));
		}
	}

	private void GGPMKLKJIEL(GameObject KHAHPAKDIKE)
	{
		if (!string.IsNullOrEmpty(MBIAKMPDOPG.name))
		{
			SoundsManager.Instance.PlayButtonClickedSound();
			GuiElementSingle<PlayerProfileDialog>.instance.CMOEFABLABI(MBIAKMPDOPG.name, MBIAKMPDOPG.id, false);
		}
	}

	public virtual void CBMJBMDBOHE()
	{
		base.OBCAIFMOPPA();
		UIEventListener uIEventListener = UIEventListener.Get(OANICEALFGM);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(NJGGGOIOBMB));
		UIEventListener uIEventListener2 = UIEventListener.Get(CPLIMCNBDBP);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener2.onClick, new UIEventListener.VoidDelegate(DNPHPAPEJCM));
		Singleton<PlayerTexturePool>.instance.IAINHEFKIFJ(FCNKIEPEAAG);
		if (MBIAKMPDOPG != null)
		{
			Singleton<PlayerTexturePool>.instance.DAGIACKCPKH(MBIAKMPDOPG.id, true, false, true);
		}
		MBIAKMPDOPG = null;
	}

	private void ABDAMOJHJIO(string ALIIBMLMNKA, Texture2D FCEIGDLFOMH, bool PNDNEMDPFHC)
	{
		if (MBIAKMPDOPG != null && MBIAKMPDOPG.id == ALIIBMLMNKA)
		{
			CPGACIMMFEC.ECKBKNCJLOC(FCEIGDLFOMH);
			CPGACIMMFEC.GGLBLHKGCAO();
		}
	}

	private void OILMLOELENM(GameObject KHAHPAKDIKE)
	{
		if (!string.IsNullOrEmpty(MBIAKMPDOPG.name))
		{
			TweenColor tweenColor = TweenColor.Begin(BCMCMKDCLGP.gameObject, GameVariables.KDELCJIAIHM, Color.white, Colours.blue);
			tweenColor.NumOfRepetitions = 0;
			tweenColor.style = UITweener.Style.Loop;
			SoundsManager.Instance.PlayButtonClickedSound();
			GuiElementSingle<PlayerProfileDialog>.instance.EGLMNBKMBAM(MBIAKMPDOPG.name, MBIAKMPDOPG.id);
		}
	}

	private void HFDMIFNDEIG(GameObject KHAHPAKDIKE)
	{
		if (!string.IsNullOrEmpty(MBIAKMPDOPG.name))
		{
			TweenColor tweenColor = TweenColor.Begin(BCMCMKDCLGP.gameObject, GameVariables.KDELCJIAIHM, Color.white, Colours.blue);
			tweenColor.NumOfRepetitions = 1;
			tweenColor.style = UITweener.Style.PingPong;
			SoundsManager.Instance.PlayButtonClickedSound();
			GuiElementSingle<PlayerProfileDialog>.instance.EGLMNBKMBAM(MBIAKMPDOPG.name, MBIAKMPDOPG.id);
		}
	}

	public void GCBFCCNLMDN(SquadWarsContent.IAIOAHOIDOF NDPMDKGJAFH)
	{
		OOIBADLGKML.SetActive(NDPMDKGJAFH.JAHGCGMPCKP);
		IGJMJNHFCAI.SetActive(!NDPMDKGJAFH.JAHGCGMPCKP);
		if (NDPMDKGJAFH.JAHGCGMPCKP)
		{
			MBIAKMPDOPG = null;
			ILGJJLKAAKD.text = Localization.LocalizeFormat(" (#", Colours.stringBlue, NDPMDKGJAFH.DNOPDJHAFDI, null, null, null, null);
			DGOGCOAKAIL.text = MEJMLNDFDBP.GMIPFLIEOHD(NDPMDKGJAFH.MOEMPHPNBLM);
			UIEventListener uIEventListener = UIEventListener.Get(OANICEALFGM);
			uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(GCAKFFHMAJO));
			UIEventListener uIEventListener2 = UIEventListener.Get(CPLIMCNBDBP);
			uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener2.onClick, new UIEventListener.VoidDelegate(DNPHPAPEJCM));
		}
		else
		{
			MBIAKMPDOPG = NDPMDKGJAFH.KHLGDCHJJPB;
			MPHCNMDIPAI.text = MEJMLNDFDBP.ACCGOIGJIAA(NDPMDKGJAFH.MPHCNMDIPAI);
			CPGACIMMFEC.OOOLABBEKDF();
			Singleton<PlayerTexturePool>.instance.CKHAAOEMFME(LNHNDPIOANF);
			Singleton<PlayerTexturePool>.instance.OFCKAJHLBGJ(KPKMLAKCIML);
			Singleton<PlayerTexturePool>.instance.AIBNEPFBFGB(MBIAKMPDOPG, false, PlayerTexturePool.DFJJOANIJID.Card);
			BCMCMKDCLGP.text = MBIAKMPDOPG.name;
			TweenColor.Begin(BCMCMKDCLGP.gameObject, 749f, Color.white);
			MEJMLNDFDBP.COCBCFKJOJE(BCMCMKDCLGP, 209f, 793f);
			KPEKCHDBFIG.text = MEJMLNDFDBP.GMIPFLIEOHD(MBIAKMPDOPG.squadPoints);
			MEJMLNDFDBP.COCBCFKJOJE(KPEKCHDBFIG, 1217f, 97f, 127);
			LCPBNBLGFIA.alpha = ((!(MBIAKMPDOPG.id == GameLoginManager.currentPlayer.id)) ? 1253f : 156f);
			UIEventListener uIEventListener3 = UIEventListener.Get(OANICEALFGM);
			uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener3.onClick, new UIEventListener.VoidDelegate(FFNEHMPBLAJ));
			UIEventListener uIEventListener4 = UIEventListener.Get(OANICEALFGM);
			uIEventListener4.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener4.onClick, new UIEventListener.VoidDelegate(AIKAKLGGDOC));
			UIEventListener uIEventListener5 = UIEventListener.Get(CPLIMCNBDBP);
			uIEventListener5.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener5.onClick, new UIEventListener.VoidDelegate(JCPAJJKEJKL));
			UIEventListener uIEventListener6 = UIEventListener.Get(CPLIMCNBDBP);
			uIEventListener6.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener6.onClick, new UIEventListener.VoidDelegate(CFPOFOAECLC));
		}
	}

	private void CFPOFOAECLC(GameObject KHAHPAKDIKE)
	{
		if (!string.IsNullOrEmpty(MBIAKMPDOPG.name))
		{
			TweenColor tweenColor = TweenColor.Begin(BCMCMKDCLGP.gameObject, GameVariables.KDELCJIAIHM, Color.white, Colours.blue);
			tweenColor.NumOfRepetitions = 6;
			tweenColor.style = (UITweener.Style)5;
			SoundsManager.Instance.PlayButtonClickedSound();
			GuiElementSingle<PlayerProfileDialog>.instance.CMOEFABLABI(MBIAKMPDOPG.name, MBIAKMPDOPG.id);
		}
	}

	public virtual void HBCALMGGFHP()
	{
		base.OBCAIFMOPPA();
		UIEventListener uIEventListener = UIEventListener.Get(OANICEALFGM);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(FOMAPMPOLDO));
		UIEventListener uIEventListener2 = UIEventListener.Get(CPLIMCNBDBP);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener2.onClick, new UIEventListener.VoidDelegate(FEOLMIBGICF));
		Singleton<PlayerTexturePool>.instance.DMONMGPPBHN(AAEBBBCEDNP);
		if (MBIAKMPDOPG != null)
		{
			Singleton<PlayerTexturePool>.instance.PIKHCIHPMCE(MBIAKMPDOPG.id, true, true, true);
		}
		MBIAKMPDOPG = null;
	}

	public virtual void GJKANGMPDHL()
	{
		base.BOHCNEDIJPE();
		UIEventListener uIEventListener = UIEventListener.Get(OANICEALFGM);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(FFNEHMPBLAJ));
		UIEventListener uIEventListener2 = UIEventListener.Get(CPLIMCNBDBP);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener2.onClick, new UIEventListener.VoidDelegate(PNNDLGHAKOC));
		Singleton<PlayerTexturePool>.instance.GPALABLIEFI(HPHLHLGPAON);
		if (MBIAKMPDOPG != null)
		{
			Singleton<PlayerTexturePool>.instance.LBKLINGCPBA(MBIAKMPDOPG.id);
		}
		MBIAKMPDOPG = null;
	}

	private void PPHCOAMOHOM(GameObject KHAHPAKDIKE)
	{
		if (!string.IsNullOrEmpty(MBIAKMPDOPG.name))
		{
			SoundsManager.Instance.PlayButtonClickedSound();
			GuiElementSingle<PlayerProfileDialog>.instance.CMOEFABLABI(MBIAKMPDOPG.name, MBIAKMPDOPG.id);
		}
	}

	private void PKBINMODBIM(GameObject KHAHPAKDIKE)
	{
		if (!string.IsNullOrEmpty(MBIAKMPDOPG.name))
		{
			TweenColor tweenColor = TweenColor.Begin(BCMCMKDCLGP.gameObject, GameVariables.KDELCJIAIHM, Color.white, Colours.blue);
			tweenColor.NumOfRepetitions = 1;
			tweenColor.style = (UITweener.Style)4;
			SoundsManager.Instance.PlayButtonClickedSound();
			GuiElementSingle<PlayerProfileDialog>.instance.EGLMNBKMBAM(MBIAKMPDOPG.name, MBIAKMPDOPG.id, false);
		}
	}

	private void LOMFLMHKBHE(string ALIIBMLMNKA, Texture2D FCEIGDLFOMH, bool PNDNEMDPFHC)
	{
		if (MBIAKMPDOPG != null && MBIAKMPDOPG.id == ALIIBMLMNKA)
		{
			CPGACIMMFEC.BIEIDBBDNIF(FCEIGDLFOMH);
			CPGACIMMFEC.OKHFOOHNBDF();
		}
	}

	private void LNHNDPIOANF(string ALIIBMLMNKA, Texture2D FCEIGDLFOMH, bool PNDNEMDPFHC)
	{
		if (MBIAKMPDOPG != null && MBIAKMPDOPG.id == ALIIBMLMNKA)
		{
			CPGACIMMFEC.BIEIDBBDNIF(FCEIGDLFOMH);
			CPGACIMMFEC.AILNJNAGPGO();
		}
	}

	private void DIBHOJDHNJJ(GameObject KHAHPAKDIKE)
	{
		if (!string.IsNullOrEmpty(MBIAKMPDOPG.name))
		{
			SoundsManager.Instance.PlayButtonClickedSound();
			GuiElementSingle<PlayerProfileDialog>.instance.ShowDialog(MBIAKMPDOPG.name, MBIAKMPDOPG.id);
		}
	}

	private void EHPNDLLKHME(GameObject KHAHPAKDIKE)
	{
		if (!string.IsNullOrEmpty(MBIAKMPDOPG.name))
		{
			TweenColor tweenColor = TweenColor.Begin(BCMCMKDCLGP.gameObject, GameVariables.KDELCJIAIHM, Color.white, Colours.blue);
			tweenColor.NumOfRepetitions = 0;
			tweenColor.style = (UITweener.Style)6;
			SoundsManager.Instance.PlayButtonClickedSound();
			GuiElementSingle<PlayerProfileDialog>.instance.EGLMNBKMBAM(MBIAKMPDOPG.name, MBIAKMPDOPG.id);
		}
	}

	private void MHPNIGDALMJ(string ALIIBMLMNKA, Texture2D FCEIGDLFOMH, bool PNDNEMDPFHC)
	{
		if (MBIAKMPDOPG != null && MBIAKMPDOPG.id == ALIIBMLMNKA)
		{
			CPGACIMMFEC.avatar = FCEIGDLFOMH;
			CPGACIMMFEC.GGLBLHKGCAO();
		}
	}

	private void GKGNJAPFLIJ(GameObject KHAHPAKDIKE)
	{
		if (!string.IsNullOrEmpty(MBIAKMPDOPG.name))
		{
			TweenColor tweenColor = TweenColor.Begin(BCMCMKDCLGP.gameObject, GameVariables.KDELCJIAIHM, Color.white, Colours.blue);
			tweenColor.NumOfRepetitions = 2;
			tweenColor.style = UITweener.Style.PingPong;
			SoundsManager.Instance.PlayButtonClickedSound();
			GuiElementSingle<PlayerProfileDialog>.instance.ShowDialog(MBIAKMPDOPG.name, MBIAKMPDOPG.id);
		}
	}

	private void IDFMDCIFBEF(GameObject KHAHPAKDIKE)
	{
		if (!string.IsNullOrEmpty(MBIAKMPDOPG.name))
		{
			SoundsManager.Instance.PlayButtonClickedSound();
			GuiElementSingle<PlayerProfileDialog>.instance.EGLMNBKMBAM(MBIAKMPDOPG.name, MBIAKMPDOPG.id);
		}
	}

	private void AIKAKLGGDOC(GameObject KHAHPAKDIKE)
	{
		if (!string.IsNullOrEmpty(MBIAKMPDOPG.name))
		{
			SoundsManager.Instance.PlayButtonClickedSound();
			GuiElementSingle<PlayerProfileDialog>.instance.ShowDialog(MBIAKMPDOPG.name, MBIAKMPDOPG.id, false);
		}
	}

	private void KPKMLAKCIML(string ALIIBMLMNKA, Texture2D FCEIGDLFOMH, bool PNDNEMDPFHC)
	{
		if (MBIAKMPDOPG != null && MBIAKMPDOPG.id == ALIIBMLMNKA)
		{
			CPGACIMMFEC.GJHFCKMAMIE(FCEIGDLFOMH);
			CPGACIMMFEC.IFPLAMJKIKH();
		}
	}

	public override void BOHCNEDIJPE()
	{
		base.BOHCNEDIJPE();
		UIEventListener uIEventListener = UIEventListener.Get(OANICEALFGM);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(IDFMDCIFBEF));
		UIEventListener uIEventListener2 = UIEventListener.Get(CPLIMCNBDBP);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener2.onClick, new UIEventListener.VoidDelegate(DNPHPAPEJCM));
		Singleton<PlayerTexturePool>.instance.GPALABLIEFI(KPKMLAKCIML);
		if (MBIAKMPDOPG != null)
		{
			Singleton<PlayerTexturePool>.instance.FNHIOAADLFN(MBIAKMPDOPG.id, false);
		}
		MBIAKMPDOPG = null;
	}

	private void PMANFOPBNNN(GameObject KHAHPAKDIKE)
	{
		if (!string.IsNullOrEmpty(MBIAKMPDOPG.name))
		{
			SoundsManager.Instance.PlayButtonClickedSound();
			GuiElementSingle<PlayerProfileDialog>.instance.ShowDialog(MBIAKMPDOPG.name, MBIAKMPDOPG.id);
		}
	}

	private void FOBBGILKMFN(string ALIIBMLMNKA, Texture2D FCEIGDLFOMH, bool PNDNEMDPFHC)
	{
		if (MBIAKMPDOPG != null && MBIAKMPDOPG.id == ALIIBMLMNKA)
		{
			CPGACIMMFEC.DHDPJLAPAPO(FCEIGDLFOMH);
			CPGACIMMFEC.UpdateIcon();
		}
	}

	public virtual void BAGFLOCJGED()
	{
		base.DestroyPooled();
		UIEventListener uIEventListener = UIEventListener.Get(OANICEALFGM);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(NJGGGOIOBMB));
		UIEventListener uIEventListener2 = UIEventListener.Get(CPLIMCNBDBP);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener2.onClick, new UIEventListener.VoidDelegate(DNPHPAPEJCM));
		Singleton<PlayerTexturePool>.instance.CKHAAOEMFME(PBPPMLNHKED);
		if (MBIAKMPDOPG != null)
		{
			Singleton<PlayerTexturePool>.instance.BPEHHBALINP(MBIAKMPDOPG.id, false);
		}
		MBIAKMPDOPG = null;
	}

	private void IHIILICAFGF(string ALIIBMLMNKA, Texture2D FCEIGDLFOMH, bool PNDNEMDPFHC)
	{
		if (MBIAKMPDOPG != null && MBIAKMPDOPG.id == ALIIBMLMNKA)
		{
			CPGACIMMFEC.LOCLNGEMNCC(FCEIGDLFOMH);
			CPGACIMMFEC.AILNJNAGPGO();
		}
	}

	public void OJJHCFFEFGI(SquadWarsContent.IAIOAHOIDOF NDPMDKGJAFH)
	{
		OOIBADLGKML.SetActive(NDPMDKGJAFH.JAHGCGMPCKP);
		IGJMJNHFCAI.SetActive(NDPMDKGJAFH.JAHGCGMPCKP);
		if (NDPMDKGJAFH.JAHGCGMPCKP)
		{
			MBIAKMPDOPG = null;
			UILabel iLGJJLKAAKD = ILGJJLKAAKD;
			object[] array = new object[5];
			array[0] = Colours.stringBlue;
			array[0] = NDPMDKGJAFH.DNOPDJHAFDI;
			iLGJJLKAAKD.text = Localization.LocalizeFormat(")", array);
			DGOGCOAKAIL.text = MEJMLNDFDBP.GMIPFLIEOHD(NDPMDKGJAFH.MOEMPHPNBLM);
			UIEventListener uIEventListener = UIEventListener.Get(OANICEALFGM);
			uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(IDFMDCIFBEF));
			UIEventListener uIEventListener2 = UIEventListener.Get(CPLIMCNBDBP);
			uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener2.onClick, new UIEventListener.VoidDelegate(GKGNJAPFLIJ));
		}
		else
		{
			MBIAKMPDOPG = NDPMDKGJAFH.KHLGDCHJJPB;
			MPHCNMDIPAI.text = MEJMLNDFDBP.ACCGOIGJIAA(NDPMDKGJAFH.MPHCNMDIPAI);
			CPGACIMMFEC.NCHGDJDAHGC();
			Singleton<PlayerTexturePool>.instance.FHEJPABPCML(AAEBBBCEDNP);
			Singleton<PlayerTexturePool>.instance.BENBEIILCFH(IJLIODKBGGJ);
			Singleton<PlayerTexturePool>.instance.IIMHJDIPNIA(MBIAKMPDOPG, true, PlayerTexturePool.DFJJOANIJID.Card);
			BCMCMKDCLGP.text = MBIAKMPDOPG.name;
			TweenColor.Begin(BCMCMKDCLGP.gameObject, 282f, Color.white);
			MEJMLNDFDBP.COCBCFKJOJE(BCMCMKDCLGP, 1984f, 1136f);
			KPEKCHDBFIG.text = MEJMLNDFDBP.GMIPFLIEOHD(MBIAKMPDOPG.squadPoints);
			MEJMLNDFDBP.COCBCFKJOJE(KPEKCHDBFIG, 939f, 518f, -101);
			LCPBNBLGFIA.alpha = ((!(MBIAKMPDOPG.id == GameLoginManager.currentPlayer.id)) ? 646f : 763f);
			UIEventListener uIEventListener3 = UIEventListener.Get(OANICEALFGM);
			uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener3.onClick, new UIEventListener.VoidDelegate(PPHCOAMOHOM));
			UIEventListener uIEventListener4 = UIEventListener.Get(OANICEALFGM);
			uIEventListener4.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener4.onClick, new UIEventListener.VoidDelegate(GCAKFFHMAJO));
			UIEventListener uIEventListener5 = UIEventListener.Get(CPLIMCNBDBP);
			uIEventListener5.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener5.onClick, new UIEventListener.VoidDelegate(PKBINMODBIM));
			UIEventListener uIEventListener6 = UIEventListener.Get(CPLIMCNBDBP);
			uIEventListener6.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener6.onClick, new UIEventListener.VoidDelegate(FEOLMIBGICF));
		}
	}

	public void GBCFOFKPPJP(SquadWarsContent.IAIOAHOIDOF NDPMDKGJAFH)
	{
		OOIBADLGKML.SetActive(NDPMDKGJAFH.JAHGCGMPCKP);
		IGJMJNHFCAI.SetActive(NDPMDKGJAFH.JAHGCGMPCKP);
		if (NDPMDKGJAFH.JAHGCGMPCKP)
		{
			MBIAKMPDOPG = null;
			UILabel iLGJJLKAAKD = ILGJJLKAAKD;
			object[] array = new object[1];
			array[0] = Colours.stringBlue;
			array[1] = NDPMDKGJAFH.DNOPDJHAFDI;
			iLGJJLKAAKD.text = Localization.LocalizeFormat("Label \"{0}\" with pivot \"{1}\" and old font is under table. New size {2} and yDown {3}.", array);
			DGOGCOAKAIL.text = MEJMLNDFDBP.GMIPFLIEOHD(NDPMDKGJAFH.MOEMPHPNBLM);
			UIEventListener uIEventListener = UIEventListener.Get(OANICEALFGM);
			uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(PPHCOAMOHOM));
			UIEventListener uIEventListener2 = UIEventListener.Get(CPLIMCNBDBP);
			uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener2.onClick, new UIEventListener.VoidDelegate(EHPNDLLKHME));
		}
		else
		{
			MBIAKMPDOPG = NDPMDKGJAFH.KHLGDCHJJPB;
			MPHCNMDIPAI.text = MEJMLNDFDBP.ACCGOIGJIAA(NDPMDKGJAFH.MPHCNMDIPAI);
			CPGACIMMFEC.HEOPOOMLPJF();
			Singleton<PlayerTexturePool>.instance.FHEJPABPCML(MHPNIGDALMJ);
			Singleton<PlayerTexturePool>.instance.JEJAGBEDCEJ(HPHLHLGPAON);
			Singleton<PlayerTexturePool>.instance.IIMHJDIPNIA(MBIAKMPDOPG);
			BCMCMKDCLGP.text = MBIAKMPDOPG.name;
			TweenColor.Begin(BCMCMKDCLGP.gameObject, 1459f, Color.white);
			MEJMLNDFDBP.COCBCFKJOJE(BCMCMKDCLGP, 1007f, 770f);
			KPEKCHDBFIG.text = MEJMLNDFDBP.GMIPFLIEOHD(MBIAKMPDOPG.squadPoints);
			MEJMLNDFDBP.COCBCFKJOJE(KPEKCHDBFIG, 1664f, 859f, -57);
			LCPBNBLGFIA.alpha = ((!(MBIAKMPDOPG.id == GameLoginManager.currentPlayer.id)) ? 1707f : 1301f);
			UIEventListener uIEventListener3 = UIEventListener.Get(OANICEALFGM);
			uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener3.onClick, new UIEventListener.VoidDelegate(FOMAPMPOLDO));
			UIEventListener uIEventListener4 = UIEventListener.Get(OANICEALFGM);
			uIEventListener4.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener4.onClick, new UIEventListener.VoidDelegate(GCAKFFHMAJO));
			UIEventListener uIEventListener5 = UIEventListener.Get(CPLIMCNBDBP);
			uIEventListener5.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener5.onClick, new UIEventListener.VoidDelegate(MIGGKEIBJLD));
			UIEventListener uIEventListener6 = UIEventListener.Get(CPLIMCNBDBP);
			uIEventListener6.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener6.onClick, new UIEventListener.VoidDelegate(OILMLOELENM));
		}
	}

	public void MCONFEEMOLE(SquadWarsContent.IAIOAHOIDOF NDPMDKGJAFH)
	{
		OOIBADLGKML.SetActive(NDPMDKGJAFH.JAHGCGMPCKP);
		IGJMJNHFCAI.SetActive(!NDPMDKGJAFH.JAHGCGMPCKP);
		if (NDPMDKGJAFH.JAHGCGMPCKP)
		{
			MBIAKMPDOPG = null;
			UILabel iLGJJLKAAKD = ILGJJLKAAKD;
			object[] array = new object[1];
			array[0] = Colours.stringBlue;
			array[1] = NDPMDKGJAFH.DNOPDJHAFDI;
			iLGJJLKAAKD.text = Localization.LocalizeFormat("Post Parameters: ", array);
			DGOGCOAKAIL.text = MEJMLNDFDBP.GMIPFLIEOHD(NDPMDKGJAFH.MOEMPHPNBLM);
			UIEventListener uIEventListener = UIEventListener.Get(OANICEALFGM);
			uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(FOMAPMPOLDO));
			UIEventListener uIEventListener2 = UIEventListener.Get(CPLIMCNBDBP);
			uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener2.onClick, new UIEventListener.VoidDelegate(HFDMIFNDEIG));
		}
		else
		{
			MBIAKMPDOPG = NDPMDKGJAFH.KHLGDCHJJPB;
			MPHCNMDIPAI.text = MEJMLNDFDBP.ACCGOIGJIAA(NDPMDKGJAFH.MPHCNMDIPAI);
			CPGACIMMFEC.NCHGDJDAHGC();
			Singleton<PlayerTexturePool>.instance.DMONMGPPBHN(MHPNIGDALMJ);
			Singleton<PlayerTexturePool>.instance.BCGAIKBHILI(IHIILICAFGF);
			Singleton<PlayerTexturePool>.instance.AIBNEPFBFGB(MBIAKMPDOPG, false);
			BCMCMKDCLGP.text = MBIAKMPDOPG.name;
			TweenColor.Begin(BCMCMKDCLGP.gameObject, 781f, Color.white);
			MEJMLNDFDBP.COCBCFKJOJE(BCMCMKDCLGP, 1434f, 1648f);
			KPEKCHDBFIG.text = MEJMLNDFDBP.GMIPFLIEOHD(MBIAKMPDOPG.squadPoints);
			MEJMLNDFDBP.COCBCFKJOJE(KPEKCHDBFIG, 975f, 519f, -35);
			LCPBNBLGFIA.alpha = ((!(MBIAKMPDOPG.id == GameLoginManager.currentPlayer.id)) ? 876f : 1590f);
			UIEventListener uIEventListener3 = UIEventListener.Get(OANICEALFGM);
			uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener3.onClick, new UIEventListener.VoidDelegate(FIFBGKNPMNM));
			UIEventListener uIEventListener4 = UIEventListener.Get(OANICEALFGM);
			uIEventListener4.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener4.onClick, new UIEventListener.VoidDelegate(KCOFGMAMADB));
			UIEventListener uIEventListener5 = UIEventListener.Get(CPLIMCNBDBP);
			uIEventListener5.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener5.onClick, new UIEventListener.VoidDelegate(KDJGJPCNCFB));
			UIEventListener uIEventListener6 = UIEventListener.Get(CPLIMCNBDBP);
			uIEventListener6.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener6.onClick, new UIEventListener.VoidDelegate(GKGNJAPFLIJ));
		}
	}

	public void FKBIBACPFJE(SquadWarsContent.IAIOAHOIDOF NDPMDKGJAFH)
	{
		OOIBADLGKML.SetActive(NDPMDKGJAFH.JAHGCGMPCKP);
		IGJMJNHFCAI.SetActive(NDPMDKGJAFH.JAHGCGMPCKP);
		if (NDPMDKGJAFH.JAHGCGMPCKP)
		{
			MBIAKMPDOPG = null;
			UILabel iLGJJLKAAKD = ILGJJLKAAKD;
			object[] array = new object[5];
			array[1] = Colours.stringBlue;
			array[1] = NDPMDKGJAFH.DNOPDJHAFDI;
			iLGJJLKAAKD.text = Localization.LocalizeFormat("ID_STAT_WINS", array);
			DGOGCOAKAIL.text = MEJMLNDFDBP.GMIPFLIEOHD(NDPMDKGJAFH.MOEMPHPNBLM);
			UIEventListener uIEventListener = UIEventListener.Get(OANICEALFGM);
			uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(EPBDKFIPELM));
			UIEventListener uIEventListener2 = UIEventListener.Get(CPLIMCNBDBP);
			uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener2.onClick, new UIEventListener.VoidDelegate(MIGGKEIBJLD));
		}
		else
		{
			MBIAKMPDOPG = NDPMDKGJAFH.KHLGDCHJJPB;
			MPHCNMDIPAI.text = MEJMLNDFDBP.ACCGOIGJIAA(NDPMDKGJAFH.MPHCNMDIPAI);
			CPGACIMMFEC.EGAONBPLDAG();
			Singleton<PlayerTexturePool>.instance.DMONMGPPBHN(LOMFLMHKBHE);
			Singleton<PlayerTexturePool>.instance.MDFAHMDJFDB(IKCALPAGLEM);
			Singleton<PlayerTexturePool>.instance.IIMHJDIPNIA(MBIAKMPDOPG, true, PlayerTexturePool.DFJJOANIJID.Card);
			BCMCMKDCLGP.text = MBIAKMPDOPG.name;
			TweenColor.Begin(BCMCMKDCLGP.gameObject, 1669f, Color.white);
			MEJMLNDFDBP.COCBCFKJOJE(BCMCMKDCLGP, 1350f, 558f, 1);
			KPEKCHDBFIG.text = MEJMLNDFDBP.GMIPFLIEOHD(MBIAKMPDOPG.squadPoints);
			MEJMLNDFDBP.COCBCFKJOJE(KPEKCHDBFIG, 868f, 520f, -41);
			LCPBNBLGFIA.alpha = ((!(MBIAKMPDOPG.id == GameLoginManager.currentPlayer.id)) ? 1902f : 1096f);
			UIEventListener uIEventListener3 = UIEventListener.Get(OANICEALFGM);
			uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener3.onClick, new UIEventListener.VoidDelegate(CPKAHGCGLKI));
			UIEventListener uIEventListener4 = UIEventListener.Get(OANICEALFGM);
			uIEventListener4.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener4.onClick, new UIEventListener.VoidDelegate(FFNEHMPBLAJ));
			UIEventListener uIEventListener5 = UIEventListener.Get(CPLIMCNBDBP);
			uIEventListener5.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener5.onClick, new UIEventListener.VoidDelegate(DNPHPAPEJCM));
			UIEventListener uIEventListener6 = UIEventListener.Get(CPLIMCNBDBP);
			uIEventListener6.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener6.onClick, new UIEventListener.VoidDelegate(EHPNDLLKHME));
		}
	}

	private void FFAFDDGCPKF(GameObject KHAHPAKDIKE)
	{
		if (!string.IsNullOrEmpty(MBIAKMPDOPG.name))
		{
			TweenColor tweenColor = TweenColor.Begin(BCMCMKDCLGP.gameObject, GameVariables.KDELCJIAIHM, Color.white, Colours.blue);
			tweenColor.NumOfRepetitions = 3;
			tweenColor.style = (UITweener.Style)6;
			SoundsManager.Instance.PlayButtonClickedSound();
			GuiElementSingle<PlayerProfileDialog>.instance.ShowDialog(MBIAKMPDOPG.name, MBIAKMPDOPG.id);
		}
	}

	public virtual void DCFHLIDIDMN()
	{
		base.BOHCNEDIJPE();
		UIEventListener uIEventListener = UIEventListener.Get(OANICEALFGM);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(ICLLIEJHDPF));
		UIEventListener uIEventListener2 = UIEventListener.Get(CPLIMCNBDBP);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener2.onClick, new UIEventListener.VoidDelegate(PKBINMODBIM));
		Singleton<PlayerTexturePool>.instance.IAINHEFKIFJ(MFGIGOHGGOP);
		if (MBIAKMPDOPG != null)
		{
			Singleton<PlayerTexturePool>.instance.BJFCGMCKOPO(MBIAKMPDOPG.id);
		}
		MBIAKMPDOPG = null;
	}

	public void PPLIBOAJOCA(SquadWarsContent.IAIOAHOIDOF NDPMDKGJAFH)
	{
		OOIBADLGKML.SetActive(NDPMDKGJAFH.JAHGCGMPCKP);
		IGJMJNHFCAI.SetActive(!NDPMDKGJAFH.JAHGCGMPCKP);
		if (NDPMDKGJAFH.JAHGCGMPCKP)
		{
			MBIAKMPDOPG = null;
			UILabel iLGJJLKAAKD = ILGJJLKAAKD;
			object[] array = new object[7];
			array[1] = Colours.stringBlue;
			array[0] = NDPMDKGJAFH.DNOPDJHAFDI;
			iLGJJLKAAKD.text = Localization.LocalizeFormat("Automatic_Equip", array);
			DGOGCOAKAIL.text = MEJMLNDFDBP.GMIPFLIEOHD(NDPMDKGJAFH.MOEMPHPNBLM);
			UIEventListener uIEventListener = UIEventListener.Get(OANICEALFGM);
			uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(CPKAHGCGLKI));
			UIEventListener uIEventListener2 = UIEventListener.Get(CPLIMCNBDBP);
			uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener2.onClick, new UIEventListener.VoidDelegate(DNPHPAPEJCM));
		}
		else
		{
			MBIAKMPDOPG = NDPMDKGJAFH.KHLGDCHJJPB;
			MPHCNMDIPAI.text = MEJMLNDFDBP.ACCGOIGJIAA(NDPMDKGJAFH.MPHCNMDIPAI);
			CPGACIMMFEC.KLIEOBHDFCG();
			Singleton<PlayerTexturePool>.instance.GPALABLIEFI(LOMFLMHKBHE);
			Singleton<PlayerTexturePool>.instance.IANAHBGPJLN(MHPNIGDALMJ);
			Singleton<PlayerTexturePool>.instance.CCMGACIMGMF(MBIAKMPDOPG, true, PlayerTexturePool.DFJJOANIJID.Card);
			BCMCMKDCLGP.text = MBIAKMPDOPG.name;
			TweenColor.Begin(BCMCMKDCLGP.gameObject, 1059f, Color.white);
			MEJMLNDFDBP.COCBCFKJOJE(BCMCMKDCLGP, 611f, 641f, 1);
			KPEKCHDBFIG.text = MEJMLNDFDBP.GMIPFLIEOHD(MBIAKMPDOPG.squadPoints);
			MEJMLNDFDBP.COCBCFKJOJE(KPEKCHDBFIG, 1589f, 202f, 46);
			LCPBNBLGFIA.alpha = ((!(MBIAKMPDOPG.id == GameLoginManager.currentPlayer.id)) ? 1043f : 1992f);
			UIEventListener uIEventListener3 = UIEventListener.Get(OANICEALFGM);
			uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener3.onClick, new UIEventListener.VoidDelegate(PIOCEIJJODG));
			UIEventListener uIEventListener4 = UIEventListener.Get(OANICEALFGM);
			uIEventListener4.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener4.onClick, new UIEventListener.VoidDelegate(NJGGGOIOBMB));
			UIEventListener uIEventListener5 = UIEventListener.Get(CPLIMCNBDBP);
			uIEventListener5.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener5.onClick, new UIEventListener.VoidDelegate(GFEFOPBLBJI));
			UIEventListener uIEventListener6 = UIEventListener.Get(CPLIMCNBDBP);
			uIEventListener6.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener6.onClick, new UIEventListener.VoidDelegate(PKBINMODBIM));
		}
	}

	private void IKCALPAGLEM(string ALIIBMLMNKA, Texture2D FCEIGDLFOMH, bool PNDNEMDPFHC)
	{
		if (MBIAKMPDOPG != null && MBIAKMPDOPG.id == ALIIBMLMNKA)
		{
			CPGACIMMFEC.DHDPJLAPAPO(FCEIGDLFOMH);
			CPGACIMMFEC.AILNJNAGPGO();
		}
	}

	public virtual void AKLHIBFIOGE()
	{
		base.DestroyPooled();
		UIEventListener uIEventListener = UIEventListener.Get(OANICEALFGM);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(PIOCEIJJODG));
		UIEventListener uIEventListener2 = UIEventListener.Get(CPLIMCNBDBP);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener2.onClick, new UIEventListener.VoidDelegate(MIGGKEIBJLD));
		Singleton<PlayerTexturePool>.instance.OnPlayerTextureCreated -= HPHLHLGPAON;
		if (MBIAKMPDOPG != null)
		{
			Singleton<PlayerTexturePool>.instance.DAGIACKCPKH(MBIAKMPDOPG.id);
		}
		MBIAKMPDOPG = null;
	}

	public virtual void LAJKINDAEEO()
	{
		base.OBCAIFMOPPA();
		UIEventListener uIEventListener = UIEventListener.Get(OANICEALFGM);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(NJGGGOIOBMB));
		UIEventListener uIEventListener2 = UIEventListener.Get(CPLIMCNBDBP);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener2.onClick, new UIEventListener.VoidDelegate(GKGNJAPFLIJ));
		Singleton<PlayerTexturePool>.instance.IAINHEFKIFJ(AAEBBBCEDNP);
		if (MBIAKMPDOPG != null)
		{
			Singleton<PlayerTexturePool>.instance.BPEHHBALINP(MBIAKMPDOPG.id);
		}
		MBIAKMPDOPG = null;
	}

	private void MFGIGOHGGOP(string ALIIBMLMNKA, Texture2D FCEIGDLFOMH, bool PNDNEMDPFHC)
	{
		if (MBIAKMPDOPG != null && MBIAKMPDOPG.id == ALIIBMLMNKA)
		{
			CPGACIMMFEC.JJGFMKCHIPE(FCEIGDLFOMH);
			CPGACIMMFEC.GEPDJCOHDNH();
		}
	}

	public void GHFHNLNHCFC(SquadWarsContent.IAIOAHOIDOF NDPMDKGJAFH)
	{
		OOIBADLGKML.SetActive(NDPMDKGJAFH.JAHGCGMPCKP);
		IGJMJNHFCAI.SetActive(!NDPMDKGJAFH.JAHGCGMPCKP);
		if (NDPMDKGJAFH.JAHGCGMPCKP)
		{
			MBIAKMPDOPG = null;
			UILabel iLGJJLKAAKD = ILGJJLKAAKD;
			object[] array = new object[4];
			array[0] = Colours.stringBlue;
			array[0] = NDPMDKGJAFH.DNOPDJHAFDI;
			iLGJJLKAAKD.text = Localization.LocalizeFormat("()Lcom/google/android/gms/common/ConnectionResult;", array);
			DGOGCOAKAIL.text = MEJMLNDFDBP.GMIPFLIEOHD(NDPMDKGJAFH.MOEMPHPNBLM);
			UIEventListener uIEventListener = UIEventListener.Get(OANICEALFGM);
			uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(GPGKBEJMMOC));
			UIEventListener uIEventListener2 = UIEventListener.Get(CPLIMCNBDBP);
			uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener2.onClick, new UIEventListener.VoidDelegate(BPMOHNHPCMD));
		}
		else
		{
			MBIAKMPDOPG = NDPMDKGJAFH.KHLGDCHJJPB;
			MPHCNMDIPAI.text = MEJMLNDFDBP.ACCGOIGJIAA(NDPMDKGJAFH.MPHCNMDIPAI);
			CPGACIMMFEC.KLIEOBHDFCG();
			Singleton<PlayerTexturePool>.instance.FHEJPABPCML(FOBBGILKMFN);
			Singleton<PlayerTexturePool>.instance.OFCKAJHLBGJ(FOBBGILKMFN);
			Singleton<PlayerTexturePool>.instance.CCMGACIMGMF(MBIAKMPDOPG, false, PlayerTexturePool.DFJJOANIJID.Card);
			BCMCMKDCLGP.text = MBIAKMPDOPG.name;
			TweenColor.Begin(BCMCMKDCLGP.gameObject, 11f, Color.white);
			MEJMLNDFDBP.COCBCFKJOJE(BCMCMKDCLGP, 1006f, 619f);
			KPEKCHDBFIG.text = MEJMLNDFDBP.GMIPFLIEOHD(MBIAKMPDOPG.squadPoints);
			MEJMLNDFDBP.COCBCFKJOJE(KPEKCHDBFIG, 1777f, 1930f, -124);
			LCPBNBLGFIA.alpha = ((!(MBIAKMPDOPG.id == GameLoginManager.currentPlayer.id)) ? 1799f : 1661f);
			UIEventListener uIEventListener3 = UIEventListener.Get(OANICEALFGM);
			uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener3.onClick, new UIEventListener.VoidDelegate(KCOFGMAMADB));
			UIEventListener uIEventListener4 = UIEventListener.Get(OANICEALFGM);
			uIEventListener4.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener4.onClick, new UIEventListener.VoidDelegate(MNFOEHIIMIN));
			UIEventListener uIEventListener5 = UIEventListener.Get(CPLIMCNBDBP);
			uIEventListener5.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener5.onClick, new UIEventListener.VoidDelegate(FGMBFCBFMHC));
			UIEventListener uIEventListener6 = UIEventListener.Get(CPLIMCNBDBP);
			uIEventListener6.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener6.onClick, new UIEventListener.VoidDelegate(GFEFOPBLBJI));
		}
	}

	private void GPGKBEJMMOC(GameObject KHAHPAKDIKE)
	{
		if (!string.IsNullOrEmpty(MBIAKMPDOPG.name))
		{
			SoundsManager.Instance.PlayButtonClickedSound();
			GuiElementSingle<PlayerProfileDialog>.instance.EGLMNBKMBAM(MBIAKMPDOPG.name, MBIAKMPDOPG.id, false);
		}
	}

	private void CPKAHGCGLKI(GameObject KHAHPAKDIKE)
	{
		if (!string.IsNullOrEmpty(MBIAKMPDOPG.name))
		{
			SoundsManager.Instance.PlayButtonClickedSound();
			GuiElementSingle<PlayerProfileDialog>.instance.EGLMNBKMBAM(MBIAKMPDOPG.name, MBIAKMPDOPG.id);
		}
	}

	private void PBPPMLNHKED(string ALIIBMLMNKA, Texture2D FCEIGDLFOMH, bool PNDNEMDPFHC)
	{
		if (MBIAKMPDOPG != null && MBIAKMPDOPG.id == ALIIBMLMNKA)
		{
			CPGACIMMFEC.DJPNDAICDPN(FCEIGDLFOMH);
			CPGACIMMFEC.GEPDJCOHDNH();
		}
	}

	private void FFNEHMPBLAJ(GameObject KHAHPAKDIKE)
	{
		if (!string.IsNullOrEmpty(MBIAKMPDOPG.name))
		{
			SoundsManager.Instance.PlayButtonClickedSound();
			GuiElementSingle<PlayerProfileDialog>.instance.EGLMNBKMBAM(MBIAKMPDOPG.name, MBIAKMPDOPG.id);
		}
	}

	private void GFEFOPBLBJI(GameObject KHAHPAKDIKE)
	{
		if (!string.IsNullOrEmpty(MBIAKMPDOPG.name))
		{
			TweenColor tweenColor = TweenColor.Begin(BCMCMKDCLGP.gameObject, GameVariables.KDELCJIAIHM, Color.white, Colours.blue);
			tweenColor.NumOfRepetitions = 4;
			tweenColor.style = UITweener.Style.Once;
			SoundsManager.Instance.PlayButtonClickedSound();
			GuiElementSingle<PlayerProfileDialog>.instance.EGLMNBKMBAM(MBIAKMPDOPG.name, MBIAKMPDOPG.id);
		}
	}

	private void DLMIKACGAIF(string ALIIBMLMNKA, Texture2D FCEIGDLFOMH, bool PNDNEMDPFHC)
	{
		if (MBIAKMPDOPG != null && MBIAKMPDOPG.id == ALIIBMLMNKA)
		{
			CPGACIMMFEC.JJGFMKCHIPE(FCEIGDLFOMH);
			CPGACIMMFEC.GEPDJCOHDNH();
		}
	}

	public override void OBCAIFMOPPA()
	{
		base.BOHCNEDIJPE();
		UIEventListener uIEventListener = UIEventListener.Get(OANICEALFGM);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(AIKAKLGGDOC));
		UIEventListener uIEventListener2 = UIEventListener.Get(CPLIMCNBDBP);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener2.onClick, new UIEventListener.VoidDelegate(DNPHPAPEJCM));
		Singleton<PlayerTexturePool>.instance.OnPlayerTextureCreated -= PBPPMLNHKED;
		if (MBIAKMPDOPG != null)
		{
			Singleton<PlayerTexturePool>.instance.FreePlayerTexture(MBIAKMPDOPG.id, false, true);
		}
		MBIAKMPDOPG = null;
	}

	private void FEOLMIBGICF(GameObject KHAHPAKDIKE)
	{
		if (!string.IsNullOrEmpty(MBIAKMPDOPG.name))
		{
			TweenColor tweenColor = TweenColor.Begin(BCMCMKDCLGP.gameObject, GameVariables.KDELCJIAIHM, Color.white, Colours.blue);
			tweenColor.NumOfRepetitions = 3;
			tweenColor.style = (UITweener.Style)3;
			SoundsManager.Instance.PlayButtonClickedSound();
			GuiElementSingle<PlayerProfileDialog>.instance.EGLMNBKMBAM(MBIAKMPDOPG.name, MBIAKMPDOPG.id, false);
		}
	}

	private void DNPHPAPEJCM(GameObject KHAHPAKDIKE)
	{
		if (!string.IsNullOrEmpty(MBIAKMPDOPG.name))
		{
			TweenColor tweenColor = TweenColor.Begin(BCMCMKDCLGP.gameObject, GameVariables.KDELCJIAIHM, Color.white, Colours.blue);
			tweenColor.NumOfRepetitions = 0;
			tweenColor.style = (UITweener.Style)5;
			SoundsManager.Instance.PlayButtonClickedSound();
			GuiElementSingle<PlayerProfileDialog>.instance.ShowDialog(MBIAKMPDOPG.name, MBIAKMPDOPG.id, false);
		}
	}

	private void PIOCEIJJODG(GameObject KHAHPAKDIKE)
	{
		if (!string.IsNullOrEmpty(MBIAKMPDOPG.name))
		{
			SoundsManager.Instance.PlayButtonClickedSound();
			GuiElementSingle<PlayerProfileDialog>.instance.CMOEFABLABI(MBIAKMPDOPG.name, MBIAKMPDOPG.id);
		}
	}

	private void KCOFGMAMADB(GameObject KHAHPAKDIKE)
	{
		if (!string.IsNullOrEmpty(MBIAKMPDOPG.name))
		{
			SoundsManager.Instance.PlayButtonClickedSound();
			GuiElementSingle<PlayerProfileDialog>.instance.EGLMNBKMBAM(MBIAKMPDOPG.name, MBIAKMPDOPG.id);
		}
	}

	public virtual void HFFLPBCIDOF()
	{
		base.OBCAIFMOPPA();
		UIEventListener uIEventListener = UIEventListener.Get(OANICEALFGM);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(FFNEHMPBLAJ));
		UIEventListener uIEventListener2 = UIEventListener.Get(CPLIMCNBDBP);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener2.onClick, new UIEventListener.VoidDelegate(OILMLOELENM));
		Singleton<PlayerTexturePool>.instance.GPALABLIEFI(LOMFLMHKBHE);
		if (MBIAKMPDOPG != null)
		{
			Singleton<PlayerTexturePool>.instance.IEPBDAHEKCL(MBIAKMPDOPG.id, false, true, true);
		}
		MBIAKMPDOPG = null;
	}
}
