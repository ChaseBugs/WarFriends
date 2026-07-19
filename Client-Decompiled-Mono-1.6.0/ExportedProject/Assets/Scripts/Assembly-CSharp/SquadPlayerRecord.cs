using System;
using UnityEngine;

public class SquadPlayerRecord : PoolableObject
{
	[Header("Header Part")]
	public GameObject OOIBADLGKML;

	public UILabel ILGJJLKAAKD;

	public UISprite CODFFPODNEP;

	public UILabel DGOGCOAKAIL;

	[Header("Player Part")]
	public GameObject IGJMJNHFCAI;

	public UISprite LCPBNBLGFIA;

	public UILabel FNGJCFKHOOL;

	public PlayerIcon CPGACIMMFEC;

	public GameObject OANICEALFGM;

	public UILabel BCMCMKDCLGP;

	public GameObject CPLIMCNBDBP;

	public UILabel KPEKCHDBFIG;

	private DatabasePlayer MBIAKMPDOPG;

	private void MMJLEFLHLLK(string ALIIBMLMNKA, Texture2D FCEIGDLFOMH, bool PNDNEMDPFHC)
	{
		if (MBIAKMPDOPG != null && MBIAKMPDOPG.id == ALIIBMLMNKA)
		{
			CPGACIMMFEC.LOCLNGEMNCC(FCEIGDLFOMH);
			CPGACIMMFEC.GEPDJCOHDNH();
		}
	}

	private void JMILOMPEJGI(GameObject KHAHPAKDIKE)
	{
		if (!string.IsNullOrEmpty(MBIAKMPDOPG.name))
		{
			TweenColor tweenColor = TweenColor.Begin(BCMCMKDCLGP.gameObject, GameVariables.KDELCJIAIHM, Color.white, Colours.blue);
			tweenColor.NumOfRepetitions = 1;
			tweenColor.style = UITweener.Style.PingPong;
			SoundsManager.Instance.PlayButtonClickedSound();
			GuiElementSingle<PlayerProfileDialog>.instance.CMOEFABLABI(MBIAKMPDOPG.name, MBIAKMPDOPG.id);
		}
	}

	private void PAJLCAPIMGM(string ALIIBMLMNKA, Texture2D FCEIGDLFOMH, bool PNDNEMDPFHC)
	{
		if (MBIAKMPDOPG != null && MBIAKMPDOPG.id == ALIIBMLMNKA)
		{
			CPGACIMMFEC.BIEIDBBDNIF(FCEIGDLFOMH);
			CPGACIMMFEC.CFKALDIFENK();
		}
	}

	public virtual void DJDFKKJLHIC()
	{
		base.OBCAIFMOPPA();
		UIEventListener uIEventListener = UIEventListener.Get(OANICEALFGM);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(MPHHAKFNOFI));
		UIEventListener uIEventListener2 = UIEventListener.Get(CPLIMCNBDBP);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener2.onClick, new UIEventListener.VoidDelegate(GKGNJAPFLIJ));
		Singleton<PlayerTexturePool>.instance.CKHAAOEMFME(ENGOCPGEONA);
		if (MBIAKMPDOPG != null)
		{
			Singleton<PlayerTexturePool>.instance.LBKLINGCPBA(MBIAKMPDOPG.id, true, false, true);
		}
		MBIAKMPDOPG = null;
	}

	private void POLOPBEOOCB(string ALIIBMLMNKA, Texture2D FCEIGDLFOMH, bool PNDNEMDPFHC)
	{
		if (MBIAKMPDOPG != null && MBIAKMPDOPG.id == ALIIBMLMNKA)
		{
			CPGACIMMFEC.FBGDPCPIKMI(FCEIGDLFOMH);
			CPGACIMMFEC.AILNJNAGPGO();
		}
	}

	private void EOANAEAIIDI(GameObject KHAHPAKDIKE)
	{
		if (!string.IsNullOrEmpty(MBIAKMPDOPG.name))
		{
			SoundsManager.Instance.PlayButtonClickedSound();
			GuiElementSingle<PlayerProfileDialog>.instance.EGLMNBKMBAM(MBIAKMPDOPG.name, MBIAKMPDOPG.id, false);
		}
	}

	public virtual void IMEEHKAHJAL()
	{
		base.OBCAIFMOPPA();
		UIEventListener uIEventListener = UIEventListener.Get(OANICEALFGM);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(HMOKEFPIJFD));
		UIEventListener uIEventListener2 = UIEventListener.Get(CPLIMCNBDBP);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener2.onClick, new UIEventListener.VoidDelegate(MALBODMPGAD));
		Singleton<PlayerTexturePool>.instance.DMONMGPPBHN(POLOPBEOOCB);
		if (MBIAKMPDOPG != null)
		{
			Singleton<PlayerTexturePool>.instance.FreePlayerTexture(MBIAKMPDOPG.id, true, true, true);
		}
		MBIAKMPDOPG = null;
	}

	public virtual void NHJKBCGFIAN()
	{
		base.DestroyPooled();
		UIEventListener uIEventListener = UIEventListener.Get(OANICEALFGM);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(NLEKOONKHMN));
		UIEventListener uIEventListener2 = UIEventListener.Get(CPLIMCNBDBP);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener2.onClick, new UIEventListener.VoidDelegate(GKGNJAPFLIJ));
		Singleton<PlayerTexturePool>.instance.IAINHEFKIFJ(LIBJOLAGNPC);
		if (MBIAKMPDOPG != null)
		{
			Singleton<PlayerTexturePool>.instance.FNHIOAADLFN(MBIAKMPDOPG.id, false, true);
		}
		MBIAKMPDOPG = null;
	}

	private void HMOKEFPIJFD(GameObject KHAHPAKDIKE)
	{
		if (!string.IsNullOrEmpty(MBIAKMPDOPG.name))
		{
			SoundsManager.Instance.PlayButtonClickedSound();
			GuiElementSingle<PlayerProfileDialog>.instance.CMOEFABLABI(MBIAKMPDOPG.name, MBIAKMPDOPG.id);
		}
	}

	private void FFNEHMPBLAJ(GameObject KHAHPAKDIKE)
	{
		if (!string.IsNullOrEmpty(MBIAKMPDOPG.name))
		{
			SoundsManager.Instance.PlayButtonClickedSound();
			GuiElementSingle<PlayerProfileDialog>.instance.ShowDialog(MBIAKMPDOPG.name, MBIAKMPDOPG.id);
		}
	}

	private void EBOONOIENCE(string ALIIBMLMNKA, Texture2D FCEIGDLFOMH, bool PNDNEMDPFHC)
	{
		if (MBIAKMPDOPG != null && MBIAKMPDOPG.id == ALIIBMLMNKA)
		{
			CPGACIMMFEC.avatar = FCEIGDLFOMH;
			CPGACIMMFEC.AILNJNAGPGO();
		}
	}

	private void HLJPLBOBDLN(GameObject KHAHPAKDIKE)
	{
		if (!string.IsNullOrEmpty(MBIAKMPDOPG.name))
		{
			SoundsManager.Instance.PlayButtonClickedSound();
			GuiElementSingle<PlayerProfileDialog>.instance.EGLMNBKMBAM(MBIAKMPDOPG.name, MBIAKMPDOPG.id, false);
		}
	}

	public void HHFELCAFANH(SquadWarsContent.IAIOAHOIDOF NDPMDKGJAFH)
	{
		OOIBADLGKML.SetActive(NDPMDKGJAFH.JAHGCGMPCKP);
		IGJMJNHFCAI.SetActive(NDPMDKGJAFH.JAHGCGMPCKP);
		if (NDPMDKGJAFH.JAHGCGMPCKP)
		{
			MBIAKMPDOPG = null;
			UILabel iLGJJLKAAKD = ILGJJLKAAKD;
			object[] array = new object[0];
			array[1] = Colours.stringBlue;
			array[1] = NDPMDKGJAFH.DNOPDJHAFDI;
			iLGJJLKAAKD.text = Localization.LocalizeFormat("Error: {0}", array);
			DGOGCOAKAIL.text = MEJMLNDFDBP.GMIPFLIEOHD(NDPMDKGJAFH.MOEMPHPNBLM);
			float num = DGOGCOAKAIL.relativeSize.x * DGOGCOAKAIL.transform.localScale.x;
			float val = Mathf.Min(1657f, 979f - num / 768f - 1332f);
			CODFFPODNEP.transform.localPosition = CODFFPODNEP.transform.localPosition.ReplaceX(val);
			UIEventListener uIEventListener = UIEventListener.Get(OANICEALFGM);
			uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(DOCEACMMDNO));
			UIEventListener uIEventListener2 = UIEventListener.Get(CPLIMCNBDBP);
			uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener2.onClick, new UIEventListener.VoidDelegate(OHCFKIHNLHP));
		}
		else
		{
			MBIAKMPDOPG = NDPMDKGJAFH.KHLGDCHJJPB;
			FNGJCFKHOOL.text = MEJMLNDFDBP.ACCGOIGJIAA(NDPMDKGJAFH.MPHCNMDIPAI);
			CPGACIMMFEC.LFOLGBNBBAG();
			Singleton<PlayerTexturePool>.instance.GPALABLIEFI(IANEAGNEECF);
			Singleton<PlayerTexturePool>.instance.JLOKOBIENPP(MHPNIGDALMJ);
			Singleton<PlayerTexturePool>.instance.APIIPFCGDBO(MBIAKMPDOPG);
			BCMCMKDCLGP.text = MBIAKMPDOPG.name;
			TweenColor.Begin(BCMCMKDCLGP.gameObject, 935f, Color.white);
			MEJMLNDFDBP.COCBCFKJOJE(BCMCMKDCLGP, 858f, 654f, 1);
			KPEKCHDBFIG.text = MEJMLNDFDBP.GMIPFLIEOHD(MBIAKMPDOPG.squadPoints);
			MEJMLNDFDBP.COCBCFKJOJE(KPEKCHDBFIG, 380f, 1501f, 106);
			LCPBNBLGFIA.alpha = ((!(MBIAKMPDOPG.id == GameLoginManager.currentPlayer.id)) ? 1902f : 761f);
			UIEventListener uIEventListener3 = UIEventListener.Get(OANICEALFGM);
			uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener3.onClick, new UIEventListener.VoidDelegate(GENEDHLCGNH));
			UIEventListener uIEventListener4 = UIEventListener.Get(OANICEALFGM);
			uIEventListener4.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener4.onClick, new UIEventListener.VoidDelegate(GENEDHLCGNH));
			UIEventListener uIEventListener5 = UIEventListener.Get(CPLIMCNBDBP);
			uIEventListener5.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener5.onClick, new UIEventListener.VoidDelegate(EHPNDLLKHME));
			UIEventListener uIEventListener6 = UIEventListener.Get(CPLIMCNBDBP);
			uIEventListener6.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener6.onClick, new UIEventListener.VoidDelegate(EABKFIECKNO));
		}
	}

	private void NLKMJJGPMPH(GameObject KHAHPAKDIKE)
	{
		if (!string.IsNullOrEmpty(MBIAKMPDOPG.name))
		{
			SoundsManager.Instance.PlayButtonClickedSound();
			GuiElementSingle<PlayerProfileDialog>.instance.ShowDialog(MBIAKMPDOPG.name, MBIAKMPDOPG.id);
		}
	}

	public virtual void PLIGMEBCIFB()
	{
		base.OBCAIFMOPPA();
		UIEventListener uIEventListener = UIEventListener.Get(OANICEALFGM);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(EOANAEAIIDI));
		UIEventListener uIEventListener2 = UIEventListener.Get(CPLIMCNBDBP);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener2.onClick, new UIEventListener.VoidDelegate(JMILOMPEJGI));
		Singleton<PlayerTexturePool>.instance.DMONMGPPBHN(FOBBGILKMFN);
		if (MBIAKMPDOPG != null)
		{
			Singleton<PlayerTexturePool>.instance.PIKHCIHPMCE(MBIAKMPDOPG.id);
		}
		MBIAKMPDOPG = null;
	}

	public virtual void IMHOHLIDMIG()
	{
		base.DestroyPooled();
		UIEventListener uIEventListener = UIEventListener.Get(OANICEALFGM);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(GGDEPGKAHOK));
		UIEventListener uIEventListener2 = UIEventListener.Get(CPLIMCNBDBP);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener2.onClick, new UIEventListener.VoidDelegate(AILFAMAFHFJ));
		Singleton<PlayerTexturePool>.instance.OnPlayerTextureCreated -= PMIMPLDCHKA;
		if (MBIAKMPDOPG != null)
		{
			Singleton<PlayerTexturePool>.instance.FreePlayerTexture(MBIAKMPDOPG.id, false, false, true);
		}
		MBIAKMPDOPG = null;
	}

	public virtual void GCNDLBLILAL()
	{
		base.BOHCNEDIJPE();
		UIEventListener uIEventListener = UIEventListener.Get(OANICEALFGM);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(MNFOEHIIMIN));
		UIEventListener uIEventListener2 = UIEventListener.Get(CPLIMCNBDBP);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener2.onClick, new UIEventListener.VoidDelegate(OHCFKIHNLHP));
		Singleton<PlayerTexturePool>.instance.FHEJPABPCML(HIHCBOMMEON);
		if (MBIAKMPDOPG != null)
		{
			Singleton<PlayerTexturePool>.instance.DAGIACKCPKH(MBIAKMPDOPG.id, true, true);
		}
		MBIAKMPDOPG = null;
	}

	private void JBCOINLOLJD(GameObject KHAHPAKDIKE)
	{
		if (!string.IsNullOrEmpty(MBIAKMPDOPG.name))
		{
			SoundsManager.Instance.PlayButtonClickedSound();
			GuiElementSingle<PlayerProfileDialog>.instance.CMOEFABLABI(MBIAKMPDOPG.name, MBIAKMPDOPG.id, false);
		}
	}

	private void GPKADIJLAGH(string ALIIBMLMNKA, Texture2D FCEIGDLFOMH, bool PNDNEMDPFHC)
	{
		if (MBIAKMPDOPG != null && MBIAKMPDOPG.id == ALIIBMLMNKA)
		{
			CPGACIMMFEC.DHDPJLAPAPO(FCEIGDLFOMH);
			CPGACIMMFEC.GEPDJCOHDNH();
		}
	}

	public void IEMFGBCBAAJ(SquadWarsContent.IAIOAHOIDOF NDPMDKGJAFH)
	{
		OOIBADLGKML.SetActive(NDPMDKGJAFH.JAHGCGMPCKP);
		IGJMJNHFCAI.SetActive(!NDPMDKGJAFH.JAHGCGMPCKP);
		if (NDPMDKGJAFH.JAHGCGMPCKP)
		{
			MBIAKMPDOPG = null;
			UILabel iLGJJLKAAKD = ILGJJLKAAKD;
			object[] array = new object[0];
			array[0] = Colours.stringBlue;
			array[0] = NDPMDKGJAFH.DNOPDJHAFDI;
			iLGJJLKAAKD.text = Localization.LocalizeFormat("ID_LOGOUT", array);
			DGOGCOAKAIL.text = MEJMLNDFDBP.GMIPFLIEOHD(NDPMDKGJAFH.MOEMPHPNBLM);
			float num = DGOGCOAKAIL.relativeSize.x * DGOGCOAKAIL.transform.localScale.x;
			float val = Mathf.Min(781f, 592f - num / 839f - 1237f);
			CODFFPODNEP.transform.localPosition = CODFFPODNEP.transform.localPosition.ReplaceX(val);
			UIEventListener uIEventListener = UIEventListener.Get(OANICEALFGM);
			uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(MNFOEHIIMIN));
			UIEventListener uIEventListener2 = UIEventListener.Get(CPLIMCNBDBP);
			uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener2.onClick, new UIEventListener.VoidDelegate(HKOIFINLBLL));
		}
		else
		{
			MBIAKMPDOPG = NDPMDKGJAFH.KHLGDCHJJPB;
			FNGJCFKHOOL.text = MEJMLNDFDBP.ACCGOIGJIAA(NDPMDKGJAFH.MPHCNMDIPAI);
			CPGACIMMFEC.ABBPOMCBIIH();
			Singleton<PlayerTexturePool>.instance.GPALABLIEFI(PMIMPLDCHKA);
			Singleton<PlayerTexturePool>.instance.HGBBFFJLDJI(LLHAKLFKIML);
			Singleton<PlayerTexturePool>.instance.APIIPFCGDBO(MBIAKMPDOPG);
			BCMCMKDCLGP.text = MBIAKMPDOPG.name;
			TweenColor.Begin(BCMCMKDCLGP.gameObject, 1069f, Color.white);
			MEJMLNDFDBP.COCBCFKJOJE(BCMCMKDCLGP, 1660f, 269f, 1);
			KPEKCHDBFIG.text = MEJMLNDFDBP.GMIPFLIEOHD(MBIAKMPDOPG.squadPoints);
			MEJMLNDFDBP.COCBCFKJOJE(KPEKCHDBFIG, 573f, 718f, 8);
			LCPBNBLGFIA.alpha = ((!(MBIAKMPDOPG.id == GameLoginManager.currentPlayer.id)) ? 403f : 872f);
			UIEventListener uIEventListener3 = UIEventListener.Get(OANICEALFGM);
			uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener3.onClick, new UIEventListener.VoidDelegate(NLEKOONKHMN));
			UIEventListener uIEventListener4 = UIEventListener.Get(OANICEALFGM);
			uIEventListener4.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener4.onClick, new UIEventListener.VoidDelegate(GNBALDLNGJJ));
			UIEventListener uIEventListener5 = UIEventListener.Get(CPLIMCNBDBP);
			uIEventListener5.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener5.onClick, new UIEventListener.VoidDelegate(AILFAMAFHFJ));
			UIEventListener uIEventListener6 = UIEventListener.Get(CPLIMCNBDBP);
			uIEventListener6.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener6.onClick, new UIEventListener.VoidDelegate(MCAMADAPPHJ));
		}
	}

	public void JIMBEDOMAFD(SquadWarsContent.IAIOAHOIDOF NDPMDKGJAFH)
	{
		OOIBADLGKML.SetActive(NDPMDKGJAFH.JAHGCGMPCKP);
		IGJMJNHFCAI.SetActive(!NDPMDKGJAFH.JAHGCGMPCKP);
		if (NDPMDKGJAFH.JAHGCGMPCKP)
		{
			MBIAKMPDOPG = null;
			UILabel iLGJJLKAAKD = ILGJJLKAAKD;
			object[] array = new object[2];
			array[1] = Colours.stringBlue;
			array[0] = NDPMDKGJAFH.DNOPDJHAFDI;
			iLGJJLKAAKD.text = Localization.LocalizeFormat("PLayerLeagueEvaluation = ", array);
			DGOGCOAKAIL.text = MEJMLNDFDBP.GMIPFLIEOHD(NDPMDKGJAFH.MOEMPHPNBLM);
			float num = DGOGCOAKAIL.relativeSize.x * DGOGCOAKAIL.transform.localScale.x;
			float val = Mathf.Min(1989f, 650f - num / 483f - 1285f);
			CODFFPODNEP.transform.localPosition = CODFFPODNEP.transform.localPosition.ReplaceX(val);
			UIEventListener uIEventListener = UIEventListener.Get(OANICEALFGM);
			uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(DOCEACMMDNO));
			UIEventListener uIEventListener2 = UIEventListener.Get(CPLIMCNBDBP);
			uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener2.onClick, new UIEventListener.VoidDelegate(MCAMADAPPHJ));
		}
		else
		{
			MBIAKMPDOPG = NDPMDKGJAFH.KHLGDCHJJPB;
			FNGJCFKHOOL.text = MEJMLNDFDBP.ACCGOIGJIAA(NDPMDKGJAFH.MPHCNMDIPAI);
			CPGACIMMFEC.NCHGDJDAHGC();
			Singleton<PlayerTexturePool>.instance.CKHAAOEMFME(FCNKIEPEAAG);
			Singleton<PlayerTexturePool>.instance.GENOIIGKOIK(DCACICJPABC);
			Singleton<PlayerTexturePool>.instance.IIMHJDIPNIA(MBIAKMPDOPG, true, PlayerTexturePool.DFJJOANIJID.Card);
			BCMCMKDCLGP.text = MBIAKMPDOPG.name;
			TweenColor.Begin(BCMCMKDCLGP.gameObject, 1600f, Color.white);
			MEJMLNDFDBP.COCBCFKJOJE(BCMCMKDCLGP, 188f, 1379f);
			KPEKCHDBFIG.text = MEJMLNDFDBP.GMIPFLIEOHD(MBIAKMPDOPG.squadPoints);
			MEJMLNDFDBP.COCBCFKJOJE(KPEKCHDBFIG, 1864f, 1012f, -19);
			LCPBNBLGFIA.alpha = ((!(MBIAKMPDOPG.id == GameLoginManager.currentPlayer.id)) ? 628f : 40f);
			UIEventListener uIEventListener3 = UIEventListener.Get(OANICEALFGM);
			uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener3.onClick, new UIEventListener.VoidDelegate(HMOKEFPIJFD));
			UIEventListener uIEventListener4 = UIEventListener.Get(OANICEALFGM);
			uIEventListener4.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener4.onClick, new UIEventListener.VoidDelegate(EOANAEAIIDI));
			UIEventListener uIEventListener5 = UIEventListener.Get(CPLIMCNBDBP);
			uIEventListener5.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener5.onClick, new UIEventListener.VoidDelegate(HKOIFINLBLL));
			UIEventListener uIEventListener6 = UIEventListener.Get(CPLIMCNBDBP);
			uIEventListener6.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener6.onClick, new UIEventListener.VoidDelegate(MALBODMPGAD));
		}
	}

	public virtual void KJDECEJDGHF()
	{
		base.BOHCNEDIJPE();
		UIEventListener uIEventListener = UIEventListener.Get(OANICEALFGM);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(MPHHAKFNOFI));
		UIEventListener uIEventListener2 = UIEventListener.Get(CPLIMCNBDBP);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener2.onClick, new UIEventListener.VoidDelegate(HKOIFINLBLL));
		Singleton<PlayerTexturePool>.instance.CKHAAOEMFME(FMALBMBGCLL);
		if (MBIAKMPDOPG != null)
		{
			Singleton<PlayerTexturePool>.instance.FreePlayerTexture(MBIAKMPDOPG.id, false);
		}
		MBIAKMPDOPG = null;
	}

	private void NLEKOONKHMN(GameObject KHAHPAKDIKE)
	{
		if (!string.IsNullOrEmpty(MBIAKMPDOPG.name))
		{
			SoundsManager.Instance.PlayButtonClickedSound();
			GuiElementSingle<PlayerProfileDialog>.instance.CMOEFABLABI(MBIAKMPDOPG.name, MBIAKMPDOPG.id, false);
		}
	}

	private void MPHHAKFNOFI(GameObject KHAHPAKDIKE)
	{
		if (!string.IsNullOrEmpty(MBIAKMPDOPG.name))
		{
			SoundsManager.Instance.PlayButtonClickedSound();
			GuiElementSingle<PlayerProfileDialog>.instance.EGLMNBKMBAM(MBIAKMPDOPG.name, MBIAKMPDOPG.id, false);
		}
	}

	private void IANEAGNEECF(string ALIIBMLMNKA, Texture2D FCEIGDLFOMH, bool PNDNEMDPFHC)
	{
		if (MBIAKMPDOPG != null && MBIAKMPDOPG.id == ALIIBMLMNKA)
		{
			CPGACIMMFEC.EIKJEGHELNK(FCEIGDLFOMH);
			CPGACIMMFEC.UpdateIcon();
		}
	}

	private void ICLLIEJHDPF(GameObject KHAHPAKDIKE)
	{
		if (!string.IsNullOrEmpty(MBIAKMPDOPG.name))
		{
			SoundsManager.Instance.PlayButtonClickedSound();
			GuiElementSingle<PlayerProfileDialog>.instance.CMOEFABLABI(MBIAKMPDOPG.name, MBIAKMPDOPG.id, false);
		}
	}

	public void HOAMHAAHEHP(SquadWarsContent.IAIOAHOIDOF NDPMDKGJAFH)
	{
		OOIBADLGKML.SetActive(NDPMDKGJAFH.JAHGCGMPCKP);
		IGJMJNHFCAI.SetActive(NDPMDKGJAFH.JAHGCGMPCKP);
		if (NDPMDKGJAFH.JAHGCGMPCKP)
		{
			MBIAKMPDOPG = null;
			ILGJJLKAAKD.text = Localization.LocalizeFormat("unit", Colours.stringBlue, NDPMDKGJAFH.DNOPDJHAFDI);
			DGOGCOAKAIL.text = MEJMLNDFDBP.GMIPFLIEOHD(NDPMDKGJAFH.MOEMPHPNBLM);
			float num = DGOGCOAKAIL.relativeSize.x * DGOGCOAKAIL.transform.localScale.x;
			float val = Mathf.Min(1639f, 1684f - num / 1650f - 1351f);
			CODFFPODNEP.transform.localPosition = CODFFPODNEP.transform.localPosition.ReplaceX(val);
			UIEventListener uIEventListener = UIEventListener.Get(OANICEALFGM);
			uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(NLEKOONKHMN));
			UIEventListener uIEventListener2 = UIEventListener.Get(CPLIMCNBDBP);
			uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener2.onClick, new UIEventListener.VoidDelegate(OPIAOAGOMNM));
		}
		else
		{
			MBIAKMPDOPG = NDPMDKGJAFH.KHLGDCHJJPB;
			FNGJCFKHOOL.text = MEJMLNDFDBP.ACCGOIGJIAA(NDPMDKGJAFH.MPHCNMDIPAI);
			CPGACIMMFEC.KOKJMKHECGK();
			Singleton<PlayerTexturePool>.instance.GPALABLIEFI(NJKMMHBGPPG);
			Singleton<PlayerTexturePool>.instance.GENOIIGKOIK(FOBBGILKMFN);
			Singleton<PlayerTexturePool>.instance.MFKFEHJBEPA(MBIAKMPDOPG, false, PlayerTexturePool.DFJJOANIJID.Card);
			BCMCMKDCLGP.text = MBIAKMPDOPG.name;
			TweenColor.Begin(BCMCMKDCLGP.gameObject, 1021f, Color.white);
			MEJMLNDFDBP.COCBCFKJOJE(BCMCMKDCLGP, 267f, 1654f, 1);
			KPEKCHDBFIG.text = MEJMLNDFDBP.GMIPFLIEOHD(MBIAKMPDOPG.squadPoints);
			MEJMLNDFDBP.COCBCFKJOJE(KPEKCHDBFIG, 1568f, 874f, 73);
			LCPBNBLGFIA.alpha = ((!(MBIAKMPDOPG.id == GameLoginManager.currentPlayer.id)) ? 1468f : 1813f);
			UIEventListener uIEventListener3 = UIEventListener.Get(OANICEALFGM);
			uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener3.onClick, new UIEventListener.VoidDelegate(FOPHJGOKKPP));
			UIEventListener uIEventListener4 = UIEventListener.Get(OANICEALFGM);
			uIEventListener4.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener4.onClick, new UIEventListener.VoidDelegate(AIKAKLGGDOC));
			UIEventListener uIEventListener5 = UIEventListener.Get(CPLIMCNBDBP);
			uIEventListener5.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener5.onClick, new UIEventListener.VoidDelegate(EHPNDLLKHME));
			UIEventListener uIEventListener6 = UIEventListener.Get(CPLIMCNBDBP);
			uIEventListener6.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener6.onClick, new UIEventListener.VoidDelegate(AILFAMAFHFJ));
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

	private void IHIILICAFGF(string ALIIBMLMNKA, Texture2D FCEIGDLFOMH, bool PNDNEMDPFHC)
	{
		if (MBIAKMPDOPG != null && MBIAKMPDOPG.id == ALIIBMLMNKA)
		{
			CPGACIMMFEC.JJGFMKCHIPE(FCEIGDLFOMH);
			CPGACIMMFEC.AILNJNAGPGO();
		}
	}

	private void KOMIBCNMEFO(GameObject KHAHPAKDIKE)
	{
		if (!string.IsNullOrEmpty(MBIAKMPDOPG.name))
		{
			SoundsManager.Instance.PlayButtonClickedSound();
			GuiElementSingle<PlayerProfileDialog>.instance.EGLMNBKMBAM(MBIAKMPDOPG.name, MBIAKMPDOPG.id, false);
		}
	}

	public virtual void CBMJBMDBOHE()
	{
		base.DestroyPooled();
		UIEventListener uIEventListener = UIEventListener.Get(OANICEALFGM);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(NLEKOONKHMN));
		UIEventListener uIEventListener2 = UIEventListener.Get(CPLIMCNBDBP);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener2.onClick, new UIEventListener.VoidDelegate(MALBODMPGAD));
		Singleton<PlayerTexturePool>.instance.CKHAAOEMFME(PAJLCAPIMGM);
		if (MBIAKMPDOPG != null)
		{
			Singleton<PlayerTexturePool>.instance.DAGIACKCPKH(MBIAKMPDOPG.id, false, true, true);
		}
		MBIAKMPDOPG = null;
	}

	private void MHPNIGDALMJ(string ALIIBMLMNKA, Texture2D FCEIGDLFOMH, bool PNDNEMDPFHC)
	{
		if (MBIAKMPDOPG != null && MBIAKMPDOPG.id == ALIIBMLMNKA)
		{
			CPGACIMMFEC.avatar = FCEIGDLFOMH;
			CPGACIMMFEC.GGLBLHKGCAO();
		}
	}

	private void MALBODMPGAD(GameObject KHAHPAKDIKE)
	{
		if (!string.IsNullOrEmpty(MBIAKMPDOPG.name))
		{
			TweenColor tweenColor = TweenColor.Begin(BCMCMKDCLGP.gameObject, GameVariables.KDELCJIAIHM, Color.white, Colours.blue);
			tweenColor.NumOfRepetitions = 0;
			tweenColor.style = (UITweener.Style)3;
			SoundsManager.Instance.PlayButtonClickedSound();
			GuiElementSingle<PlayerProfileDialog>.instance.EGLMNBKMBAM(MBIAKMPDOPG.name, MBIAKMPDOPG.id);
		}
	}

	private void GPGKBEJMMOC(GameObject KHAHPAKDIKE)
	{
		if (!string.IsNullOrEmpty(MBIAKMPDOPG.name))
		{
			SoundsManager.Instance.PlayButtonClickedSound();
			GuiElementSingle<PlayerProfileDialog>.instance.EGLMNBKMBAM(MBIAKMPDOPG.name, MBIAKMPDOPG.id);
		}
	}

	public virtual void DKMEHOEOADL()
	{
		base.OBCAIFMOPPA();
		UIEventListener uIEventListener = UIEventListener.Get(OANICEALFGM);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(ICLLIEJHDPF));
		UIEventListener uIEventListener2 = UIEventListener.Get(CPLIMCNBDBP);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener2.onClick, new UIEventListener.VoidDelegate(HKOIFINLBLL));
		Singleton<PlayerTexturePool>.instance.FHEJPABPCML(FOBBGILKMFN);
		if (MBIAKMPDOPG != null)
		{
			Singleton<PlayerTexturePool>.instance.BPEHHBALINP(MBIAKMPDOPG.id, false);
		}
		MBIAKMPDOPG = null;
	}

	public void PNCJCHPOMOJ(SquadWarsContent.IAIOAHOIDOF NDPMDKGJAFH)
	{
		OOIBADLGKML.SetActive(NDPMDKGJAFH.JAHGCGMPCKP);
		IGJMJNHFCAI.SetActive(NDPMDKGJAFH.JAHGCGMPCKP);
		if (NDPMDKGJAFH.JAHGCGMPCKP)
		{
			MBIAKMPDOPG = null;
			UILabel iLGJJLKAAKD = ILGJJLKAAKD;
			object[] array = new object[6];
			array[1] = Colours.stringBlue;
			array[0] = NDPMDKGJAFH.DNOPDJHAFDI;
			iLGJJLKAAKD.text = Localization.LocalizeFormat("ID_CONFIRM_OFFERTOOSHORTDURATION", array);
			DGOGCOAKAIL.text = MEJMLNDFDBP.GMIPFLIEOHD(NDPMDKGJAFH.MOEMPHPNBLM);
			float num = DGOGCOAKAIL.relativeSize.x * DGOGCOAKAIL.transform.localScale.x;
			float val = Mathf.Min(1422f, 1251f - num / 1799f - 1376f);
			CODFFPODNEP.transform.localPosition = CODFFPODNEP.transform.localPosition.ReplaceX(val);
			UIEventListener uIEventListener = UIEventListener.Get(OANICEALFGM);
			uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(MNFOEHIIMIN));
			UIEventListener uIEventListener2 = UIEventListener.Get(CPLIMCNBDBP);
			uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener2.onClick, new UIEventListener.VoidDelegate(HKOIFINLBLL));
		}
		else
		{
			MBIAKMPDOPG = NDPMDKGJAFH.KHLGDCHJJPB;
			FNGJCFKHOOL.text = MEJMLNDFDBP.ACCGOIGJIAA(NDPMDKGJAFH.MPHCNMDIPAI);
			CPGACIMMFEC.HEOPOOMLPJF();
			Singleton<PlayerTexturePool>.instance.DMONMGPPBHN(LLHAKLFKIML);
			Singleton<PlayerTexturePool>.instance.ACEFBBGOINN(EBOONOIENCE);
			Singleton<PlayerTexturePool>.instance.AIBNEPFBFGB(MBIAKMPDOPG, false);
			BCMCMKDCLGP.text = MBIAKMPDOPG.name;
			TweenColor.Begin(BCMCMKDCLGP.gameObject, 1960f, Color.white);
			MEJMLNDFDBP.COCBCFKJOJE(BCMCMKDCLGP, 1841f, 381f, 1);
			KPEKCHDBFIG.text = MEJMLNDFDBP.GMIPFLIEOHD(MBIAKMPDOPG.squadPoints);
			MEJMLNDFDBP.COCBCFKJOJE(KPEKCHDBFIG, 151f, 849f, -128);
			LCPBNBLGFIA.alpha = ((!(MBIAKMPDOPG.id == GameLoginManager.currentPlayer.id)) ? 2f : 1672f);
			UIEventListener uIEventListener3 = UIEventListener.Get(OANICEALFGM);
			uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener3.onClick, new UIEventListener.VoidDelegate(AEDJNJEGHEC));
			UIEventListener uIEventListener4 = UIEventListener.Get(OANICEALFGM);
			uIEventListener4.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener4.onClick, new UIEventListener.VoidDelegate(ICLLIEJHDPF));
			UIEventListener uIEventListener5 = UIEventListener.Get(CPLIMCNBDBP);
			uIEventListener5.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener5.onClick, new UIEventListener.VoidDelegate(AILFAMAFHFJ));
			UIEventListener uIEventListener6 = UIEventListener.Get(CPLIMCNBDBP);
			uIEventListener6.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener6.onClick, new UIEventListener.VoidDelegate(MALBODMPGAD));
		}
	}

	private void AILFAMAFHFJ(GameObject KHAHPAKDIKE)
	{
		if (!string.IsNullOrEmpty(MBIAKMPDOPG.name))
		{
			TweenColor tweenColor = TweenColor.Begin(BCMCMKDCLGP.gameObject, GameVariables.KDELCJIAIHM, Color.white, Colours.blue);
			tweenColor.NumOfRepetitions = 8;
			tweenColor.style = (UITweener.Style)8;
			SoundsManager.Instance.PlayButtonClickedSound();
			GuiElementSingle<PlayerProfileDialog>.instance.EGLMNBKMBAM(MBIAKMPDOPG.name, MBIAKMPDOPG.id, false);
		}
	}

	public virtual void HGOBLCPDFCD()
	{
		base.BOHCNEDIJPE();
		UIEventListener uIEventListener = UIEventListener.Get(OANICEALFGM);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(JBCOINLOLJD));
		UIEventListener uIEventListener2 = UIEventListener.Get(CPLIMCNBDBP);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener2.onClick, new UIEventListener.VoidDelegate(EABKFIECKNO));
		Singleton<PlayerTexturePool>.instance.CKHAAOEMFME(EKIJEHCLBCC);
		if (MBIAKMPDOPG != null)
		{
			Singleton<PlayerTexturePool>.instance.MDANAEPCCHK(MBIAKMPDOPG.id, true, false, true);
		}
		MBIAKMPDOPG = null;
	}

	private void OPIAOAGOMNM(GameObject KHAHPAKDIKE)
	{
		if (!string.IsNullOrEmpty(MBIAKMPDOPG.name))
		{
			TweenColor tweenColor = TweenColor.Begin(BCMCMKDCLGP.gameObject, GameVariables.KDELCJIAIHM, Color.white, Colours.blue);
			tweenColor.NumOfRepetitions = 0;
			tweenColor.style = (UITweener.Style)7;
			SoundsManager.Instance.PlayButtonClickedSound();
			GuiElementSingle<PlayerProfileDialog>.instance.ShowDialog(MBIAKMPDOPG.name, MBIAKMPDOPG.id);
		}
	}

	public void LIMIFKFNNLA(SquadWarsContent.IAIOAHOIDOF NDPMDKGJAFH)
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
			iLGJJLKAAKD.text = Localization.LocalizeFormat("UIReflectionEffect reference missing for index ", array);
			DGOGCOAKAIL.text = MEJMLNDFDBP.GMIPFLIEOHD(NDPMDKGJAFH.MOEMPHPNBLM);
			float num = DGOGCOAKAIL.relativeSize.x * DGOGCOAKAIL.transform.localScale.x;
			float val = Mathf.Min(1479f, 1569f - num / 162f - 285f);
			CODFFPODNEP.transform.localPosition = CODFFPODNEP.transform.localPosition.ReplaceX(val);
			UIEventListener uIEventListener = UIEventListener.Get(OANICEALFGM);
			uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(GGDEPGKAHOK));
			UIEventListener uIEventListener2 = UIEventListener.Get(CPLIMCNBDBP);
			uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener2.onClick, new UIEventListener.VoidDelegate(KLPCEGOHJGA));
		}
		else
		{
			MBIAKMPDOPG = NDPMDKGJAFH.KHLGDCHJJPB;
			FNGJCFKHOOL.text = MEJMLNDFDBP.ACCGOIGJIAA(NDPMDKGJAFH.MPHCNMDIPAI);
			CPGACIMMFEC.NCHGDJDAHGC();
			Singleton<PlayerTexturePool>.instance.CKHAAOEMFME(MMJLEFLHLLK);
			Singleton<PlayerTexturePool>.instance.LHOOOIOGOFM(NJKMMHBGPPG);
			Singleton<PlayerTexturePool>.instance.APIIPFCGDBO(MBIAKMPDOPG, true, PlayerTexturePool.DFJJOANIJID.Card);
			BCMCMKDCLGP.text = MBIAKMPDOPG.name;
			TweenColor.Begin(BCMCMKDCLGP.gameObject, 1560f, Color.white);
			MEJMLNDFDBP.COCBCFKJOJE(BCMCMKDCLGP, 439f, 1571f);
			KPEKCHDBFIG.text = MEJMLNDFDBP.GMIPFLIEOHD(MBIAKMPDOPG.squadPoints);
			MEJMLNDFDBP.COCBCFKJOJE(KPEKCHDBFIG, 1014f, 1549f, -81);
			LCPBNBLGFIA.alpha = ((!(MBIAKMPDOPG.id == GameLoginManager.currentPlayer.id)) ? 396f : 1238f);
			UIEventListener uIEventListener3 = UIEventListener.Get(OANICEALFGM);
			uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener3.onClick, new UIEventListener.VoidDelegate(GPGKBEJMMOC));
			UIEventListener uIEventListener4 = UIEventListener.Get(OANICEALFGM);
			uIEventListener4.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener4.onClick, new UIEventListener.VoidDelegate(FPNPPGMMIOD));
			UIEventListener uIEventListener5 = UIEventListener.Get(CPLIMCNBDBP);
			uIEventListener5.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener5.onClick, new UIEventListener.VoidDelegate(MCAMADAPPHJ));
			UIEventListener uIEventListener6 = UIEventListener.Get(CPLIMCNBDBP);
			uIEventListener6.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener6.onClick, new UIEventListener.VoidDelegate(KLPCEGOHJGA));
		}
	}

	private void GNBALDLNGJJ(GameObject KHAHPAKDIKE)
	{
		if (!string.IsNullOrEmpty(MBIAKMPDOPG.name))
		{
			SoundsManager.Instance.PlayButtonClickedSound();
			GuiElementSingle<PlayerProfileDialog>.instance.EGLMNBKMBAM(MBIAKMPDOPG.name, MBIAKMPDOPG.id);
		}
	}

	public virtual void AMPACMLGJEB()
	{
		base.OBCAIFMOPPA();
		UIEventListener uIEventListener = UIEventListener.Get(OANICEALFGM);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(AEDJNJEGHEC));
		UIEventListener uIEventListener2 = UIEventListener.Get(CPLIMCNBDBP);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener2.onClick, new UIEventListener.VoidDelegate(EABKFIECKNO));
		Singleton<PlayerTexturePool>.instance.IAINHEFKIFJ(LIBJOLAGNPC);
		if (MBIAKMPDOPG != null)
		{
			Singleton<PlayerTexturePool>.instance.BPEHHBALINP(MBIAKMPDOPG.id, false);
		}
		MBIAKMPDOPG = null;
	}

	private void HEFKHHKHJBO(GameObject KHAHPAKDIKE)
	{
		if (!string.IsNullOrEmpty(MBIAKMPDOPG.name))
		{
			SoundsManager.Instance.PlayButtonClickedSound();
			GuiElementSingle<PlayerProfileDialog>.instance.CMOEFABLABI(MBIAKMPDOPG.name, MBIAKMPDOPG.id);
		}
	}

	public virtual void KALNJKOBCAN()
	{
		base.BOHCNEDIJPE();
		UIEventListener uIEventListener = UIEventListener.Get(OANICEALFGM);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(NLEKOONKHMN));
		UIEventListener uIEventListener2 = UIEventListener.Get(CPLIMCNBDBP);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener2.onClick, new UIEventListener.VoidDelegate(MALBODMPGAD));
		Singleton<PlayerTexturePool>.instance.DMONMGPPBHN(ANPEPPGFENN);
		if (MBIAKMPDOPG != null)
		{
			Singleton<PlayerTexturePool>.instance.BPEHHBALINP(MBIAKMPDOPG.id, false, true);
		}
		MBIAKMPDOPG = null;
	}

	private void OHCFKIHNLHP(GameObject KHAHPAKDIKE)
	{
		if (!string.IsNullOrEmpty(MBIAKMPDOPG.name))
		{
			TweenColor tweenColor = TweenColor.Begin(BCMCMKDCLGP.gameObject, GameVariables.KDELCJIAIHM, Color.white, Colours.blue);
			tweenColor.NumOfRepetitions = 5;
			tweenColor.style = (UITweener.Style)5;
			SoundsManager.Instance.PlayButtonClickedSound();
			GuiElementSingle<PlayerProfileDialog>.instance.CMOEFABLABI(MBIAKMPDOPG.name, MBIAKMPDOPG.id);
		}
	}

	private void GENEDHLCGNH(GameObject KHAHPAKDIKE)
	{
		if (!string.IsNullOrEmpty(MBIAKMPDOPG.name))
		{
			SoundsManager.Instance.PlayButtonClickedSound();
			GuiElementSingle<PlayerProfileDialog>.instance.EGLMNBKMBAM(MBIAKMPDOPG.name, MBIAKMPDOPG.id, false);
		}
	}

	private void AIKAKLGGDOC(GameObject KHAHPAKDIKE)
	{
		if (!string.IsNullOrEmpty(MBIAKMPDOPG.name))
		{
			SoundsManager.Instance.PlayButtonClickedSound();
			GuiElementSingle<PlayerProfileDialog>.instance.EGLMNBKMBAM(MBIAKMPDOPG.name, MBIAKMPDOPG.id);
		}
	}

	private void MGMEPOOBHNO(string ALIIBMLMNKA, Texture2D FCEIGDLFOMH, bool PNDNEMDPFHC)
	{
		if (MBIAKMPDOPG != null && MBIAKMPDOPG.id == ALIIBMLMNKA)
		{
			CPGACIMMFEC.KHIPFLOFKMC(FCEIGDLFOMH);
			CPGACIMMFEC.DGPJIJBHBJC();
		}
	}

	public void CMOHGKPENIJ(SquadWarsContent.IAIOAHOIDOF NDPMDKGJAFH)
	{
		OOIBADLGKML.SetActive(NDPMDKGJAFH.JAHGCGMPCKP);
		IGJMJNHFCAI.SetActive(NDPMDKGJAFH.JAHGCGMPCKP);
		if (NDPMDKGJAFH.JAHGCGMPCKP)
		{
			MBIAKMPDOPG = null;
			UILabel iLGJJLKAAKD = ILGJJLKAAKD;
			object[] array = new object[2];
			array[1] = Colours.stringBlue;
			array[1] = NDPMDKGJAFH.DNOPDJHAFDI;
			iLGJJLKAAKD.text = Localization.LocalizeFormat("AtlasPreparer - WHITENING ATLAS ", array);
			DGOGCOAKAIL.text = MEJMLNDFDBP.GMIPFLIEOHD(NDPMDKGJAFH.MOEMPHPNBLM);
			float num = DGOGCOAKAIL.relativeSize.x * DGOGCOAKAIL.transform.localScale.x;
			float val = Mathf.Min(80f, 1266f - num / 353f - 1005f);
			CODFFPODNEP.transform.localPosition = CODFFPODNEP.transform.localPosition.ReplaceX(val);
			UIEventListener uIEventListener = UIEventListener.Get(OANICEALFGM);
			uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(EOANAEAIIDI));
			UIEventListener uIEventListener2 = UIEventListener.Get(CPLIMCNBDBP);
			uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener2.onClick, new UIEventListener.VoidDelegate(JMILOMPEJGI));
		}
		else
		{
			MBIAKMPDOPG = NDPMDKGJAFH.KHLGDCHJJPB;
			FNGJCFKHOOL.text = MEJMLNDFDBP.ACCGOIGJIAA(NDPMDKGJAFH.MPHCNMDIPAI);
			CPGACIMMFEC.KLIEOBHDFCG();
			Singleton<PlayerTexturePool>.instance.DMONMGPPBHN(FCNKIEPEAAG);
			Singleton<PlayerTexturePool>.instance.AFAHCJBIHIP(DCACICJPABC);
			Singleton<PlayerTexturePool>.instance.APIIPFCGDBO(MBIAKMPDOPG, true, PlayerTexturePool.DFJJOANIJID.Card);
			BCMCMKDCLGP.text = MBIAKMPDOPG.name;
			TweenColor.Begin(BCMCMKDCLGP.gameObject, 1681f, Color.white);
			MEJMLNDFDBP.COCBCFKJOJE(BCMCMKDCLGP, 207f, 1714f, 1);
			KPEKCHDBFIG.text = MEJMLNDFDBP.GMIPFLIEOHD(MBIAKMPDOPG.squadPoints);
			MEJMLNDFDBP.COCBCFKJOJE(KPEKCHDBFIG, 316f, 1089f, 1);
			LCPBNBLGFIA.alpha = ((!(MBIAKMPDOPG.id == GameLoginManager.currentPlayer.id)) ? 971f : 621f);
			UIEventListener uIEventListener3 = UIEventListener.Get(OANICEALFGM);
			uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener3.onClick, new UIEventListener.VoidDelegate(AEDJNJEGHEC));
			UIEventListener uIEventListener4 = UIEventListener.Get(OANICEALFGM);
			uIEventListener4.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener4.onClick, new UIEventListener.VoidDelegate(GNBALDLNGJJ));
			UIEventListener uIEventListener5 = UIEventListener.Get(CPLIMCNBDBP);
			uIEventListener5.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener5.onClick, new UIEventListener.VoidDelegate(EHPNDLLKHME));
			UIEventListener uIEventListener6 = UIEventListener.Get(CPLIMCNBDBP);
			uIEventListener6.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener6.onClick, new UIEventListener.VoidDelegate(HKOIFINLBLL));
		}
	}

	private void BAJFMDBAKKM(string ALIIBMLMNKA, Texture2D FCEIGDLFOMH, bool PNDNEMDPFHC)
	{
		if (MBIAKMPDOPG != null && MBIAKMPDOPG.id == ALIIBMLMNKA)
		{
			CPGACIMMFEC.LOCLNGEMNCC(FCEIGDLFOMH);
			CPGACIMMFEC.GPHGDAKLAJK();
		}
	}

	public virtual void EMCFMPHKILC()
	{
		base.OBCAIFMOPPA();
		UIEventListener uIEventListener = UIEventListener.Get(OANICEALFGM);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(KOMIBCNMEFO));
		UIEventListener uIEventListener2 = UIEventListener.Get(CPLIMCNBDBP);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener2.onClick, new UIEventListener.VoidDelegate(OPIAOAGOMNM));
		Singleton<PlayerTexturePool>.instance.CKHAAOEMFME(ANPEPPGFENN);
		if (MBIAKMPDOPG != null)
		{
			Singleton<PlayerTexturePool>.instance.BJFCGMCKOPO(MBIAKMPDOPG.id, false);
		}
		MBIAKMPDOPG = null;
	}

	private void FPNPPGMMIOD(GameObject KHAHPAKDIKE)
	{
		if (!string.IsNullOrEmpty(MBIAKMPDOPG.name))
		{
			SoundsManager.Instance.PlayButtonClickedSound();
			GuiElementSingle<PlayerProfileDialog>.instance.EGLMNBKMBAM(MBIAKMPDOPG.name, MBIAKMPDOPG.id, false);
		}
	}

	private void LIBJOLAGNPC(string ALIIBMLMNKA, Texture2D FCEIGDLFOMH, bool PNDNEMDPFHC)
	{
		if (MBIAKMPDOPG != null && MBIAKMPDOPG.id == ALIIBMLMNKA)
		{
			CPGACIMMFEC.KHIPFLOFKMC(FCEIGDLFOMH);
			CPGACIMMFEC.HCACKHAKDNC();
		}
	}

	private void GGDEPGKAHOK(GameObject KHAHPAKDIKE)
	{
		if (!string.IsNullOrEmpty(MBIAKMPDOPG.name))
		{
			SoundsManager.Instance.PlayButtonClickedSound();
			GuiElementSingle<PlayerProfileDialog>.instance.EGLMNBKMBAM(MBIAKMPDOPG.name, MBIAKMPDOPG.id);
		}
	}

	private void ENGOCPGEONA(string ALIIBMLMNKA, Texture2D FCEIGDLFOMH, bool PNDNEMDPFHC)
	{
		if (MBIAKMPDOPG != null && MBIAKMPDOPG.id == ALIIBMLMNKA)
		{
			CPGACIMMFEC.JJGFMKCHIPE(FCEIGDLFOMH);
			CPGACIMMFEC.BFKPPMIKNAA();
		}
	}

	public void IGBPNEODHIP(SquadWarsContent.IAIOAHOIDOF NDPMDKGJAFH)
	{
		OOIBADLGKML.SetActive(NDPMDKGJAFH.JAHGCGMPCKP);
		IGJMJNHFCAI.SetActive(!NDPMDKGJAFH.JAHGCGMPCKP);
		if (NDPMDKGJAFH.JAHGCGMPCKP)
		{
			MBIAKMPDOPG = null;
			ILGJJLKAAKD.text = Localization.LocalizeFormat("registerCurrency", Colours.stringBlue, NDPMDKGJAFH.DNOPDJHAFDI, null);
			DGOGCOAKAIL.text = MEJMLNDFDBP.GMIPFLIEOHD(NDPMDKGJAFH.MOEMPHPNBLM);
			float num = DGOGCOAKAIL.relativeSize.x * DGOGCOAKAIL.transform.localScale.x;
			float val = Mathf.Min(357f, 432f - num / 1997f - 710f);
			CODFFPODNEP.transform.localPosition = CODFFPODNEP.transform.localPosition.ReplaceX(val);
			UIEventListener uIEventListener = UIEventListener.Get(OANICEALFGM);
			uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(GGDEPGKAHOK));
			UIEventListener uIEventListener2 = UIEventListener.Get(CPLIMCNBDBP);
			uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener2.onClick, new UIEventListener.VoidDelegate(OHCFKIHNLHP));
		}
		else
		{
			MBIAKMPDOPG = NDPMDKGJAFH.KHLGDCHJJPB;
			FNGJCFKHOOL.text = MEJMLNDFDBP.ACCGOIGJIAA(NDPMDKGJAFH.MPHCNMDIPAI);
			CPGACIMMFEC.OMDFNFHKFBK();
			Singleton<PlayerTexturePool>.instance.CKHAAOEMFME(BFBMONEFKPG);
			Singleton<PlayerTexturePool>.instance.EPPEDDFMHIB(IHIILICAFGF);
			Singleton<PlayerTexturePool>.instance.IIMHJDIPNIA(MBIAKMPDOPG);
			BCMCMKDCLGP.text = MBIAKMPDOPG.name;
			TweenColor.Begin(BCMCMKDCLGP.gameObject, 620f, Color.white);
			MEJMLNDFDBP.COCBCFKJOJE(BCMCMKDCLGP, 1854f, 63f);
			KPEKCHDBFIG.text = MEJMLNDFDBP.GMIPFLIEOHD(MBIAKMPDOPG.squadPoints);
			MEJMLNDFDBP.COCBCFKJOJE(KPEKCHDBFIG, 1851f, 1740f, -13);
			LCPBNBLGFIA.alpha = ((!(MBIAKMPDOPG.id == GameLoginManager.currentPlayer.id)) ? 477f : 134f);
			UIEventListener uIEventListener3 = UIEventListener.Get(OANICEALFGM);
			uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener3.onClick, new UIEventListener.VoidDelegate(MNFOEHIIMIN));
			UIEventListener uIEventListener4 = UIEventListener.Get(OANICEALFGM);
			uIEventListener4.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener4.onClick, new UIEventListener.VoidDelegate(NLKMJJGPMPH));
			UIEventListener uIEventListener5 = UIEventListener.Get(CPLIMCNBDBP);
			uIEventListener5.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener5.onClick, new UIEventListener.VoidDelegate(MCAMADAPPHJ));
			UIEventListener uIEventListener6 = UIEventListener.Get(CPLIMCNBDBP);
			uIEventListener6.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener6.onClick, new UIEventListener.VoidDelegate(HKOIFINLBLL));
		}
	}

	public virtual void OCODNLMGCMN()
	{
		base.DestroyPooled();
		UIEventListener uIEventListener = UIEventListener.Get(OANICEALFGM);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(HEFKHHKHJBO));
		UIEventListener uIEventListener2 = UIEventListener.Get(CPLIMCNBDBP);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener2.onClick, new UIEventListener.VoidDelegate(AILFAMAFHFJ));
		Singleton<PlayerTexturePool>.instance.OnPlayerTextureCreated -= LIBJOLAGNPC;
		if (MBIAKMPDOPG != null)
		{
			Singleton<PlayerTexturePool>.instance.LBKLINGCPBA(MBIAKMPDOPG.id);
		}
		MBIAKMPDOPG = null;
	}

	public void JMLMMFOCKCN(SquadWarsContent.IAIOAHOIDOF NDPMDKGJAFH)
	{
		OOIBADLGKML.SetActive(NDPMDKGJAFH.JAHGCGMPCKP);
		IGJMJNHFCAI.SetActive(!NDPMDKGJAFH.JAHGCGMPCKP);
		if (NDPMDKGJAFH.JAHGCGMPCKP)
		{
			MBIAKMPDOPG = null;
			UILabel iLGJJLKAAKD = ILGJJLKAAKD;
			object[] array = new object[1];
			array[1] = Colours.stringBlue;
			array[1] = NDPMDKGJAFH.DNOPDJHAFDI;
			iLGJJLKAAKD.text = Localization.LocalizeFormat("\ni: {0} center: {1}", array);
			DGOGCOAKAIL.text = MEJMLNDFDBP.GMIPFLIEOHD(NDPMDKGJAFH.MOEMPHPNBLM);
			float num = DGOGCOAKAIL.relativeSize.x * DGOGCOAKAIL.transform.localScale.x;
			float val = Mathf.Min(1716f, 776f - num / 47f - 888f);
			CODFFPODNEP.transform.localPosition = CODFFPODNEP.transform.localPosition.ReplaceX(val);
			UIEventListener uIEventListener = UIEventListener.Get(OANICEALFGM);
			uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(FFNEHMPBLAJ));
			UIEventListener uIEventListener2 = UIEventListener.Get(CPLIMCNBDBP);
			uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener2.onClick, new UIEventListener.VoidDelegate(EABKFIECKNO));
		}
		else
		{
			MBIAKMPDOPG = NDPMDKGJAFH.KHLGDCHJJPB;
			FNGJCFKHOOL.text = MEJMLNDFDBP.ACCGOIGJIAA(NDPMDKGJAFH.MPHCNMDIPAI);
			CPGACIMMFEC.ABBPOMCBIIH();
			Singleton<PlayerTexturePool>.instance.CKHAAOEMFME(DCACICJPABC);
			Singleton<PlayerTexturePool>.instance.BENBEIILCFH(IANEAGNEECF);
			Singleton<PlayerTexturePool>.instance.CCMGACIMGMF(MBIAKMPDOPG);
			BCMCMKDCLGP.text = MBIAKMPDOPG.name;
			TweenColor.Begin(BCMCMKDCLGP.gameObject, 30f, Color.white);
			MEJMLNDFDBP.COCBCFKJOJE(BCMCMKDCLGP, 1481f, 1873f);
			KPEKCHDBFIG.text = MEJMLNDFDBP.GMIPFLIEOHD(MBIAKMPDOPG.squadPoints);
			MEJMLNDFDBP.COCBCFKJOJE(KPEKCHDBFIG, 552f, 1938f, 115);
			LCPBNBLGFIA.alpha = ((!(MBIAKMPDOPG.id == GameLoginManager.currentPlayer.id)) ? 1132f : 62f);
			UIEventListener uIEventListener3 = UIEventListener.Get(OANICEALFGM);
			uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener3.onClick, new UIEventListener.VoidDelegate(FFNEHMPBLAJ));
			UIEventListener uIEventListener4 = UIEventListener.Get(OANICEALFGM);
			uIEventListener4.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener4.onClick, new UIEventListener.VoidDelegate(FFNEHMPBLAJ));
			UIEventListener uIEventListener5 = UIEventListener.Get(CPLIMCNBDBP);
			uIEventListener5.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener5.onClick, new UIEventListener.VoidDelegate(OHCFKIHNLHP));
			UIEventListener uIEventListener6 = UIEventListener.Get(CPLIMCNBDBP);
			uIEventListener6.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener6.onClick, new UIEventListener.VoidDelegate(JMILOMPEJGI));
		}
	}

	private void FOPHJGOKKPP(GameObject KHAHPAKDIKE)
	{
		if (!string.IsNullOrEmpty(MBIAKMPDOPG.name))
		{
			SoundsManager.Instance.PlayButtonClickedSound();
			GuiElementSingle<PlayerProfileDialog>.instance.ShowDialog(MBIAKMPDOPG.name, MBIAKMPDOPG.id);
		}
	}

	public void KGOODMOOCLC(SquadWarsContent.IAIOAHOIDOF NDPMDKGJAFH)
	{
		OOIBADLGKML.SetActive(NDPMDKGJAFH.JAHGCGMPCKP);
		IGJMJNHFCAI.SetActive(!NDPMDKGJAFH.JAHGCGMPCKP);
		if (NDPMDKGJAFH.JAHGCGMPCKP)
		{
			MBIAKMPDOPG = null;
			UILabel iLGJJLKAAKD = ILGJJLKAAKD;
			object[] array = new object[8];
			array[1] = Colours.stringBlue;
			array[1] = NDPMDKGJAFH.DNOPDJHAFDI;
			iLGJJLKAAKD.text = Localization.LocalizeFormat("WarBucksBoxes", array);
			DGOGCOAKAIL.text = MEJMLNDFDBP.GMIPFLIEOHD(NDPMDKGJAFH.MOEMPHPNBLM);
			float num = DGOGCOAKAIL.relativeSize.x * DGOGCOAKAIL.transform.localScale.x;
			float val = Mathf.Min(1999f, 1576f - num / 1505f - 624f);
			CODFFPODNEP.transform.localPosition = CODFFPODNEP.transform.localPosition.ReplaceX(val);
			UIEventListener uIEventListener = UIEventListener.Get(OANICEALFGM);
			uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(MPHHAKFNOFI));
			UIEventListener uIEventListener2 = UIEventListener.Get(CPLIMCNBDBP);
			uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener2.onClick, new UIEventListener.VoidDelegate(OPIAOAGOMNM));
		}
		else
		{
			MBIAKMPDOPG = NDPMDKGJAFH.KHLGDCHJJPB;
			FNGJCFKHOOL.text = MEJMLNDFDBP.ACCGOIGJIAA(NDPMDKGJAFH.MPHCNMDIPAI);
			CPGACIMMFEC.KOKJMKHECGK();
			Singleton<PlayerTexturePool>.instance.GPALABLIEFI(MHPNIGDALMJ);
			Singleton<PlayerTexturePool>.instance.CNCEGIEPCIB(FCNKIEPEAAG);
			Singleton<PlayerTexturePool>.instance.IIMHJDIPNIA(MBIAKMPDOPG);
			BCMCMKDCLGP.text = MBIAKMPDOPG.name;
			TweenColor.Begin(BCMCMKDCLGP.gameObject, 1717f, Color.white);
			MEJMLNDFDBP.COCBCFKJOJE(BCMCMKDCLGP, 1563f, 311f);
			KPEKCHDBFIG.text = MEJMLNDFDBP.GMIPFLIEOHD(MBIAKMPDOPG.squadPoints);
			MEJMLNDFDBP.COCBCFKJOJE(KPEKCHDBFIG, 1766f, 1896f, 11);
			LCPBNBLGFIA.alpha = ((!(MBIAKMPDOPG.id == GameLoginManager.currentPlayer.id)) ? 301f : 1018f);
			UIEventListener uIEventListener3 = UIEventListener.Get(OANICEALFGM);
			uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener3.onClick, new UIEventListener.VoidDelegate(FOPHJGOKKPP));
			UIEventListener uIEventListener4 = UIEventListener.Get(OANICEALFGM);
			uIEventListener4.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener4.onClick, new UIEventListener.VoidDelegate(MPHHAKFNOFI));
			UIEventListener uIEventListener5 = UIEventListener.Get(CPLIMCNBDBP);
			uIEventListener5.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener5.onClick, new UIEventListener.VoidDelegate(MCAMADAPPHJ));
			UIEventListener uIEventListener6 = UIEventListener.Get(CPLIMCNBDBP);
			uIEventListener6.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener6.onClick, new UIEventListener.VoidDelegate(GKGNJAPFLIJ));
		}
	}

	public void Initialize(SquadWarsContent.IAIOAHOIDOF NDPMDKGJAFH)
	{
		OOIBADLGKML.SetActive(NDPMDKGJAFH.JAHGCGMPCKP);
		IGJMJNHFCAI.SetActive(!NDPMDKGJAFH.JAHGCGMPCKP);
		if (NDPMDKGJAFH.JAHGCGMPCKP)
		{
			MBIAKMPDOPG = null;
			ILGJJLKAAKD.text = Localization.LocalizeFormat("ID_POSITIONXYREWARD", Colours.stringBlue, NDPMDKGJAFH.DNOPDJHAFDI);
			DGOGCOAKAIL.text = MEJMLNDFDBP.GMIPFLIEOHD(NDPMDKGJAFH.MOEMPHPNBLM);
			float num = DGOGCOAKAIL.relativeSize.x * DGOGCOAKAIL.transform.localScale.x;
			float val = Mathf.Min(166f, 239f - num / 2f - 8f);
			CODFFPODNEP.transform.localPosition = CODFFPODNEP.transform.localPosition.ReplaceX(val);
			UIEventListener uIEventListener = UIEventListener.Get(OANICEALFGM);
			uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(MNFOEHIIMIN));
			UIEventListener uIEventListener2 = UIEventListener.Get(CPLIMCNBDBP);
			uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener2.onClick, new UIEventListener.VoidDelegate(GKGNJAPFLIJ));
		}
		else
		{
			MBIAKMPDOPG = NDPMDKGJAFH.KHLGDCHJJPB;
			FNGJCFKHOOL.text = MEJMLNDFDBP.ACCGOIGJIAA(NDPMDKGJAFH.MPHCNMDIPAI);
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
	}

	private void ANPEPPGFENN(string ALIIBMLMNKA, Texture2D FCEIGDLFOMH, bool PNDNEMDPFHC)
	{
		if (MBIAKMPDOPG != null && MBIAKMPDOPG.id == ALIIBMLMNKA)
		{
			CPGACIMMFEC.JJGFMKCHIPE(FCEIGDLFOMH);
			CPGACIMMFEC.HCACKHAKDNC();
		}
	}

	private void FMALBMBGCLL(string ALIIBMLMNKA, Texture2D FCEIGDLFOMH, bool PNDNEMDPFHC)
	{
		if (MBIAKMPDOPG != null && MBIAKMPDOPG.id == ALIIBMLMNKA)
		{
			CPGACIMMFEC.KGJCNNANACM(FCEIGDLFOMH);
			CPGACIMMFEC.DGPJIJBHBJC();
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

	private void FGNLNIAFGBB(GameObject KHAHPAKDIKE)
	{
		if (!string.IsNullOrEmpty(MBIAKMPDOPG.name))
		{
			SoundsManager.Instance.PlayButtonClickedSound();
			GuiElementSingle<PlayerProfileDialog>.instance.ShowDialog(MBIAKMPDOPG.name, MBIAKMPDOPG.id);
		}
	}

	public void OAMBDKHLJKI(SquadWarsContent.IAIOAHOIDOF NDPMDKGJAFH)
	{
		OOIBADLGKML.SetActive(NDPMDKGJAFH.JAHGCGMPCKP);
		IGJMJNHFCAI.SetActive(NDPMDKGJAFH.JAHGCGMPCKP);
		if (NDPMDKGJAFH.JAHGCGMPCKP)
		{
			MBIAKMPDOPG = null;
			UILabel iLGJJLKAAKD = ILGJJLKAAKD;
			object[] array = new object[6];
			array[1] = Colours.stringBlue;
			array[1] = NDPMDKGJAFH.DNOPDJHAFDI;
			iLGJJLKAAKD.text = Localization.LocalizeFormat("ID_LVLNUMBER", array);
			DGOGCOAKAIL.text = MEJMLNDFDBP.GMIPFLIEOHD(NDPMDKGJAFH.MOEMPHPNBLM);
			float num = DGOGCOAKAIL.relativeSize.x * DGOGCOAKAIL.transform.localScale.x;
			float val = Mathf.Min(1872f, 79f - num / 1235f - 116f);
			CODFFPODNEP.transform.localPosition = CODFFPODNEP.transform.localPosition.ReplaceX(val);
			UIEventListener uIEventListener = UIEventListener.Get(OANICEALFGM);
			uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(PMANFOPBNNN));
			UIEventListener uIEventListener2 = UIEventListener.Get(CPLIMCNBDBP);
			uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener2.onClick, new UIEventListener.VoidDelegate(EABKFIECKNO));
		}
		else
		{
			MBIAKMPDOPG = NDPMDKGJAFH.KHLGDCHJJPB;
			FNGJCFKHOOL.text = MEJMLNDFDBP.ACCGOIGJIAA(NDPMDKGJAFH.MPHCNMDIPAI);
			CPGACIMMFEC.NMEJKACLHKJ();
			Singleton<PlayerTexturePool>.instance.DMONMGPPBHN(EKIJEHCLBCC);
			Singleton<PlayerTexturePool>.instance.BENBEIILCFH(FCNKIEPEAAG);
			Singleton<PlayerTexturePool>.instance.APIIPFCGDBO(MBIAKMPDOPG, true, PlayerTexturePool.DFJJOANIJID.Card);
			BCMCMKDCLGP.text = MBIAKMPDOPG.name;
			TweenColor.Begin(BCMCMKDCLGP.gameObject, 803f, Color.white);
			MEJMLNDFDBP.COCBCFKJOJE(BCMCMKDCLGP, 242f, 194f, 1);
			KPEKCHDBFIG.text = MEJMLNDFDBP.GMIPFLIEOHD(MBIAKMPDOPG.squadPoints);
			MEJMLNDFDBP.COCBCFKJOJE(KPEKCHDBFIG, 272f, 1558f, 63);
			LCPBNBLGFIA.alpha = ((!(MBIAKMPDOPG.id == GameLoginManager.currentPlayer.id)) ? 880f : 428f);
			UIEventListener uIEventListener3 = UIEventListener.Get(OANICEALFGM);
			uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener3.onClick, new UIEventListener.VoidDelegate(FPNPPGMMIOD));
			UIEventListener uIEventListener4 = UIEventListener.Get(OANICEALFGM);
			uIEventListener4.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener4.onClick, new UIEventListener.VoidDelegate(HMOKEFPIJFD));
			UIEventListener uIEventListener5 = UIEventListener.Get(CPLIMCNBDBP);
			uIEventListener5.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener5.onClick, new UIEventListener.VoidDelegate(GKGNJAPFLIJ));
			UIEventListener uIEventListener6 = UIEventListener.Get(CPLIMCNBDBP);
			uIEventListener6.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener6.onClick, new UIEventListener.VoidDelegate(GKGNJAPFLIJ));
		}
	}

	private void KLPCEGOHJGA(GameObject KHAHPAKDIKE)
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

	private void DCACICJPABC(string ALIIBMLMNKA, Texture2D FCEIGDLFOMH, bool PNDNEMDPFHC)
	{
		if (MBIAKMPDOPG != null && MBIAKMPDOPG.id == ALIIBMLMNKA)
		{
			CPGACIMMFEC.ECKBKNCJLOC(FCEIGDLFOMH);
			CPGACIMMFEC.BFKPPMIKNAA();
		}
	}

	public virtual void JFBDNLDLLBP()
	{
		base.DestroyPooled();
		UIEventListener uIEventListener = UIEventListener.Get(OANICEALFGM);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(EMHIEKOBAGF));
		UIEventListener uIEventListener2 = UIEventListener.Get(CPLIMCNBDBP);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener2.onClick, new UIEventListener.VoidDelegate(HKOIFINLBLL));
		Singleton<PlayerTexturePool>.instance.FHEJPABPCML(PAJLCAPIMGM);
		if (MBIAKMPDOPG != null)
		{
			Singleton<PlayerTexturePool>.instance.FreePlayerTexture(MBIAKMPDOPG.id, false);
		}
		MBIAKMPDOPG = null;
	}

	private void EMHIEKOBAGF(GameObject KHAHPAKDIKE)
	{
		if (!string.IsNullOrEmpty(MBIAKMPDOPG.name))
		{
			SoundsManager.Instance.PlayButtonClickedSound();
			GuiElementSingle<PlayerProfileDialog>.instance.ShowDialog(MBIAKMPDOPG.name, MBIAKMPDOPG.id, false);
		}
	}

	public void GEGBFJHAPOE(SquadWarsContent.IAIOAHOIDOF NDPMDKGJAFH)
	{
		OOIBADLGKML.SetActive(NDPMDKGJAFH.JAHGCGMPCKP);
		IGJMJNHFCAI.SetActive(!NDPMDKGJAFH.JAHGCGMPCKP);
		if (NDPMDKGJAFH.JAHGCGMPCKP)
		{
			MBIAKMPDOPG = null;
			UILabel iLGJJLKAAKD = ILGJJLKAAKD;
			object[] array = new object[0];
			array[0] = Colours.stringBlue;
			array[1] = NDPMDKGJAFH.DNOPDJHAFDI;
			iLGJJLKAAKD.text = Localization.LocalizeFormat("FriendsListUpdated()", array);
			DGOGCOAKAIL.text = MEJMLNDFDBP.GMIPFLIEOHD(NDPMDKGJAFH.MOEMPHPNBLM);
			float num = DGOGCOAKAIL.relativeSize.x * DGOGCOAKAIL.transform.localScale.x;
			float val = Mathf.Min(1607f, 570f - num / 344f - 1815f);
			CODFFPODNEP.transform.localPosition = CODFFPODNEP.transform.localPosition.ReplaceX(val);
			UIEventListener uIEventListener = UIEventListener.Get(OANICEALFGM);
			uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(GGDEPGKAHOK));
			UIEventListener uIEventListener2 = UIEventListener.Get(CPLIMCNBDBP);
			uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener2.onClick, new UIEventListener.VoidDelegate(EABKFIECKNO));
		}
		else
		{
			MBIAKMPDOPG = NDPMDKGJAFH.KHLGDCHJJPB;
			FNGJCFKHOOL.text = MEJMLNDFDBP.ACCGOIGJIAA(NDPMDKGJAFH.MPHCNMDIPAI);
			CPGACIMMFEC.LFOLGBNBBAG();
			Singleton<PlayerTexturePool>.instance.OnPlayerTextureCreated -= PMIMPLDCHKA;
			Singleton<PlayerTexturePool>.instance.MMAGKGAKHAD(EBOONOIENCE);
			Singleton<PlayerTexturePool>.instance.IIMHJDIPNIA(MBIAKMPDOPG, false);
			BCMCMKDCLGP.text = MBIAKMPDOPG.name;
			TweenColor.Begin(BCMCMKDCLGP.gameObject, 924f, Color.white);
			MEJMLNDFDBP.COCBCFKJOJE(BCMCMKDCLGP, 585f, 954f);
			KPEKCHDBFIG.text = MEJMLNDFDBP.GMIPFLIEOHD(MBIAKMPDOPG.squadPoints);
			MEJMLNDFDBP.COCBCFKJOJE(KPEKCHDBFIG, 897f, 1633f, -89);
			LCPBNBLGFIA.alpha = ((!(MBIAKMPDOPG.id == GameLoginManager.currentPlayer.id)) ? 932f : 1953f);
			UIEventListener uIEventListener3 = UIEventListener.Get(OANICEALFGM);
			uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener3.onClick, new UIEventListener.VoidDelegate(EFAHKIAKGKC));
			UIEventListener uIEventListener4 = UIEventListener.Get(OANICEALFGM);
			uIEventListener4.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener4.onClick, new UIEventListener.VoidDelegate(FPNPPGMMIOD));
			UIEventListener uIEventListener5 = UIEventListener.Get(CPLIMCNBDBP);
			uIEventListener5.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener5.onClick, new UIEventListener.VoidDelegate(JMILOMPEJGI));
			UIEventListener uIEventListener6 = UIEventListener.Get(CPLIMCNBDBP);
			uIEventListener6.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener6.onClick, new UIEventListener.VoidDelegate(GKGNJAPFLIJ));
		}
	}

	private void PMIMPLDCHKA(string ALIIBMLMNKA, Texture2D FCEIGDLFOMH, bool PNDNEMDPFHC)
	{
		if (MBIAKMPDOPG != null && MBIAKMPDOPG.id == ALIIBMLMNKA)
		{
			CPGACIMMFEC.KGJCNNANACM(FCEIGDLFOMH);
			CPGACIMMFEC.DGPJIJBHBJC();
		}
	}

	private void EHPNDLLKHME(GameObject KHAHPAKDIKE)
	{
		if (!string.IsNullOrEmpty(MBIAKMPDOPG.name))
		{
			TweenColor tweenColor = TweenColor.Begin(BCMCMKDCLGP.gameObject, GameVariables.KDELCJIAIHM, Color.white, Colours.blue);
			tweenColor.NumOfRepetitions = 8;
			tweenColor.style = (UITweener.Style)6;
			SoundsManager.Instance.PlayButtonClickedSound();
			GuiElementSingle<PlayerProfileDialog>.instance.EGLMNBKMBAM(MBIAKMPDOPG.name, MBIAKMPDOPG.id);
		}
	}

	public void MCONFEEMOLE(SquadWarsContent.IAIOAHOIDOF NDPMDKGJAFH)
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
			iLGJJLKAAKD.text = Localization.LocalizeFormat(". Loading default...", array);
			DGOGCOAKAIL.text = MEJMLNDFDBP.GMIPFLIEOHD(NDPMDKGJAFH.MOEMPHPNBLM);
			float num = DGOGCOAKAIL.relativeSize.x * DGOGCOAKAIL.transform.localScale.x;
			float val = Mathf.Min(1024f, 466f - num / 977f - 1066f);
			CODFFPODNEP.transform.localPosition = CODFFPODNEP.transform.localPosition.ReplaceX(val);
			UIEventListener uIEventListener = UIEventListener.Get(OANICEALFGM);
			uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(ICLLIEJHDPF));
			UIEventListener uIEventListener2 = UIEventListener.Get(CPLIMCNBDBP);
			uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener2.onClick, new UIEventListener.VoidDelegate(KLPCEGOHJGA));
		}
		else
		{
			MBIAKMPDOPG = NDPMDKGJAFH.KHLGDCHJJPB;
			FNGJCFKHOOL.text = MEJMLNDFDBP.ACCGOIGJIAA(NDPMDKGJAFH.MPHCNMDIPAI);
			CPGACIMMFEC.LFOLGBNBBAG();
			Singleton<PlayerTexturePool>.instance.GPALABLIEFI(LBHMDCCHFLD);
			Singleton<PlayerTexturePool>.instance.MDFAHMDJFDB(POLOPBEOOCB);
			Singleton<PlayerTexturePool>.instance.AIBNEPFBFGB(MBIAKMPDOPG, true, PlayerTexturePool.DFJJOANIJID.Card);
			BCMCMKDCLGP.text = MBIAKMPDOPG.name;
			TweenColor.Begin(BCMCMKDCLGP.gameObject, 889f, Color.white);
			MEJMLNDFDBP.COCBCFKJOJE(BCMCMKDCLGP, 524f, 296f);
			KPEKCHDBFIG.text = MEJMLNDFDBP.GMIPFLIEOHD(MBIAKMPDOPG.squadPoints);
			MEJMLNDFDBP.COCBCFKJOJE(KPEKCHDBFIG, 1639f, 1862f, -88);
			LCPBNBLGFIA.alpha = ((!(MBIAKMPDOPG.id == GameLoginManager.currentPlayer.id)) ? 1561f : 684f);
			UIEventListener uIEventListener3 = UIEventListener.Get(OANICEALFGM);
			uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener3.onClick, new UIEventListener.VoidDelegate(GGPMKLKJIEL));
			UIEventListener uIEventListener4 = UIEventListener.Get(OANICEALFGM);
			uIEventListener4.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener4.onClick, new UIEventListener.VoidDelegate(AIKAKLGGDOC));
			UIEventListener uIEventListener5 = UIEventListener.Get(CPLIMCNBDBP);
			uIEventListener5.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener5.onClick, new UIEventListener.VoidDelegate(EHPNDLLKHME));
			UIEventListener uIEventListener6 = UIEventListener.Get(CPLIMCNBDBP);
			uIEventListener6.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener6.onClick, new UIEventListener.VoidDelegate(OHCFKIHNLHP));
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

	private void EFAHKIAKGKC(GameObject KHAHPAKDIKE)
	{
		if (!string.IsNullOrEmpty(MBIAKMPDOPG.name))
		{
			SoundsManager.Instance.PlayButtonClickedSound();
			GuiElementSingle<PlayerProfileDialog>.instance.EGLMNBKMBAM(MBIAKMPDOPG.name, MBIAKMPDOPG.id);
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

	private void EKIJEHCLBCC(string ALIIBMLMNKA, Texture2D FCEIGDLFOMH, bool PNDNEMDPFHC)
	{
		if (MBIAKMPDOPG != null && MBIAKMPDOPG.id == ALIIBMLMNKA)
		{
			CPGACIMMFEC.DHDPJLAPAPO(FCEIGDLFOMH);
			CPGACIMMFEC.IFPLAMJKIKH();
		}
	}

	private void AEDJNJEGHEC(GameObject KHAHPAKDIKE)
	{
		if (!string.IsNullOrEmpty(MBIAKMPDOPG.name))
		{
			SoundsManager.Instance.PlayButtonClickedSound();
			GuiElementSingle<PlayerProfileDialog>.instance.CMOEFABLABI(MBIAKMPDOPG.name, MBIAKMPDOPG.id);
		}
	}

	private void LDLKBIBPEOI(string ALIIBMLMNKA, Texture2D FCEIGDLFOMH, bool PNDNEMDPFHC)
	{
		if (MBIAKMPDOPG != null && MBIAKMPDOPG.id == ALIIBMLMNKA)
		{
			CPGACIMMFEC.GJHFCKMAMIE(FCEIGDLFOMH);
			CPGACIMMFEC.UpdateIcon();
		}
	}

	public void KOABMGAPCKP(SquadWarsContent.IAIOAHOIDOF NDPMDKGJAFH)
	{
		OOIBADLGKML.SetActive(NDPMDKGJAFH.JAHGCGMPCKP);
		IGJMJNHFCAI.SetActive(NDPMDKGJAFH.JAHGCGMPCKP);
		if (NDPMDKGJAFH.JAHGCGMPCKP)
		{
			MBIAKMPDOPG = null;
			ILGJJLKAAKD.text = Localization.LocalizeFormat("veteranpack", Colours.stringBlue, NDPMDKGJAFH.DNOPDJHAFDI, null);
			DGOGCOAKAIL.text = MEJMLNDFDBP.GMIPFLIEOHD(NDPMDKGJAFH.MOEMPHPNBLM);
			float num = DGOGCOAKAIL.relativeSize.x * DGOGCOAKAIL.transform.localScale.x;
			float val = Mathf.Min(1439f, 269f - num / 406f - 1563f);
			CODFFPODNEP.transform.localPosition = CODFFPODNEP.transform.localPosition.ReplaceX(val);
			UIEventListener uIEventListener = UIEventListener.Get(OANICEALFGM);
			uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(GPGKBEJMMOC));
			UIEventListener uIEventListener2 = UIEventListener.Get(CPLIMCNBDBP);
			uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener2.onClick, new UIEventListener.VoidDelegate(EABKFIECKNO));
		}
		else
		{
			MBIAKMPDOPG = NDPMDKGJAFH.KHLGDCHJJPB;
			FNGJCFKHOOL.text = MEJMLNDFDBP.ACCGOIGJIAA(NDPMDKGJAFH.MPHCNMDIPAI);
			CPGACIMMFEC.NCHGDJDAHGC();
			Singleton<PlayerTexturePool>.instance.DMONMGPPBHN(GPKADIJLAGH);
			Singleton<PlayerTexturePool>.instance.BCGAIKBHILI(ENGOCPGEONA);
			Singleton<PlayerTexturePool>.instance.APIIPFCGDBO(MBIAKMPDOPG, false);
			BCMCMKDCLGP.text = MBIAKMPDOPG.name;
			TweenColor.Begin(BCMCMKDCLGP.gameObject, 511f, Color.white);
			MEJMLNDFDBP.COCBCFKJOJE(BCMCMKDCLGP, 360f, 546f, 1);
			KPEKCHDBFIG.text = MEJMLNDFDBP.GMIPFLIEOHD(MBIAKMPDOPG.squadPoints);
			MEJMLNDFDBP.COCBCFKJOJE(KPEKCHDBFIG, 254f, 1956f, -110);
			LCPBNBLGFIA.alpha = ((!(MBIAKMPDOPG.id == GameLoginManager.currentPlayer.id)) ? 1996f : 1453f);
			UIEventListener uIEventListener3 = UIEventListener.Get(OANICEALFGM);
			uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener3.onClick, new UIEventListener.VoidDelegate(PMANFOPBNNN));
			UIEventListener uIEventListener4 = UIEventListener.Get(OANICEALFGM);
			uIEventListener4.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener4.onClick, new UIEventListener.VoidDelegate(HLJPLBOBDLN));
			UIEventListener uIEventListener5 = UIEventListener.Get(CPLIMCNBDBP);
			uIEventListener5.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener5.onClick, new UIEventListener.VoidDelegate(OPIAOAGOMNM));
			UIEventListener uIEventListener6 = UIEventListener.Get(CPLIMCNBDBP);
			uIEventListener6.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener6.onClick, new UIEventListener.VoidDelegate(KLPCEGOHJGA));
		}
	}

	private void DOCEACMMDNO(GameObject KHAHPAKDIKE)
	{
		if (!string.IsNullOrEmpty(MBIAKMPDOPG.name))
		{
			SoundsManager.Instance.PlayButtonClickedSound();
			GuiElementSingle<PlayerProfileDialog>.instance.CMOEFABLABI(MBIAKMPDOPG.name, MBIAKMPDOPG.id);
		}
	}

	public void DPFKOFFMNPC(SquadWarsContent.IAIOAHOIDOF NDPMDKGJAFH)
	{
		OOIBADLGKML.SetActive(NDPMDKGJAFH.JAHGCGMPCKP);
		IGJMJNHFCAI.SetActive(NDPMDKGJAFH.JAHGCGMPCKP);
		if (NDPMDKGJAFH.JAHGCGMPCKP)
		{
			MBIAKMPDOPG = null;
			UILabel iLGJJLKAAKD = ILGJJLKAAKD;
			object[] array = new object[7];
			array[1] = Colours.stringBlue;
			array[0] = NDPMDKGJAFH.DNOPDJHAFDI;
			iLGJJLKAAKD.text = Localization.LocalizeFormat("Daily Mission Screen : daily completition reward is not DEFINED: {0}", array);
			DGOGCOAKAIL.text = MEJMLNDFDBP.GMIPFLIEOHD(NDPMDKGJAFH.MOEMPHPNBLM);
			float num = DGOGCOAKAIL.relativeSize.x * DGOGCOAKAIL.transform.localScale.x;
			float val = Mathf.Min(1842f, 1372f - num / 966f - 1275f);
			CODFFPODNEP.transform.localPosition = CODFFPODNEP.transform.localPosition.ReplaceX(val);
			UIEventListener uIEventListener = UIEventListener.Get(OANICEALFGM);
			uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(EMHIEKOBAGF));
			UIEventListener uIEventListener2 = UIEventListener.Get(CPLIMCNBDBP);
			uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener2.onClick, new UIEventListener.VoidDelegate(OHCFKIHNLHP));
		}
		else
		{
			MBIAKMPDOPG = NDPMDKGJAFH.KHLGDCHJJPB;
			FNGJCFKHOOL.text = MEJMLNDFDBP.ACCGOIGJIAA(NDPMDKGJAFH.MPHCNMDIPAI);
			CPGACIMMFEC.OOOLABBEKDF();
			Singleton<PlayerTexturePool>.instance.OnPlayerTextureCreated -= LBHMDCCHFLD;
			Singleton<PlayerTexturePool>.instance.HGBBFFJLDJI(LDLKBIBPEOI);
			Singleton<PlayerTexturePool>.instance.AIBNEPFBFGB(MBIAKMPDOPG, false);
			BCMCMKDCLGP.text = MBIAKMPDOPG.name;
			TweenColor.Begin(BCMCMKDCLGP.gameObject, 233f, Color.white);
			MEJMLNDFDBP.COCBCFKJOJE(BCMCMKDCLGP, 1869f, 332f, 1);
			KPEKCHDBFIG.text = MEJMLNDFDBP.GMIPFLIEOHD(MBIAKMPDOPG.squadPoints);
			MEJMLNDFDBP.COCBCFKJOJE(KPEKCHDBFIG, 1072f, 188f, 10);
			LCPBNBLGFIA.alpha = ((!(MBIAKMPDOPG.id == GameLoginManager.currentPlayer.id)) ? 377f : 525f);
			UIEventListener uIEventListener3 = UIEventListener.Get(OANICEALFGM);
			uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener3.onClick, new UIEventListener.VoidDelegate(HLJPLBOBDLN));
			UIEventListener uIEventListener4 = UIEventListener.Get(OANICEALFGM);
			uIEventListener4.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener4.onClick, new UIEventListener.VoidDelegate(JBCOINLOLJD));
			UIEventListener uIEventListener5 = UIEventListener.Get(CPLIMCNBDBP);
			uIEventListener5.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener5.onClick, new UIEventListener.VoidDelegate(OHCFKIHNLHP));
			UIEventListener uIEventListener6 = UIEventListener.Get(CPLIMCNBDBP);
			uIEventListener6.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener6.onClick, new UIEventListener.VoidDelegate(MALBODMPGAD));
		}
	}

	private void HIHCBOMMEON(string ALIIBMLMNKA, Texture2D FCEIGDLFOMH, bool PNDNEMDPFHC)
	{
		if (MBIAKMPDOPG != null && MBIAKMPDOPG.id == ALIIBMLMNKA)
		{
			CPGACIMMFEC.KGJCNNANACM(FCEIGDLFOMH);
			CPGACIMMFEC.GGLBLHKGCAO();
		}
	}

	public void CIPKPHAGJMP(SquadWarsContent.IAIOAHOIDOF NDPMDKGJAFH)
	{
		OOIBADLGKML.SetActive(NDPMDKGJAFH.JAHGCGMPCKP);
		IGJMJNHFCAI.SetActive(!NDPMDKGJAFH.JAHGCGMPCKP);
		if (NDPMDKGJAFH.JAHGCGMPCKP)
		{
			MBIAKMPDOPG = null;
			UILabel iLGJJLKAAKD = ILGJJLKAAKD;
			object[] array = new object[8];
			array[1] = Colours.stringBlue;
			array[1] = NDPMDKGJAFH.DNOPDJHAFDI;
			iLGJJLKAAKD.text = Localization.LocalizeFormat("Attribution Data ", array);
			DGOGCOAKAIL.text = MEJMLNDFDBP.GMIPFLIEOHD(NDPMDKGJAFH.MOEMPHPNBLM);
			float num = DGOGCOAKAIL.relativeSize.x * DGOGCOAKAIL.transform.localScale.x;
			float val = Mathf.Min(453f, 1994f - num / 142f - 1148f);
			CODFFPODNEP.transform.localPosition = CODFFPODNEP.transform.localPosition.ReplaceX(val);
			UIEventListener uIEventListener = UIEventListener.Get(OANICEALFGM);
			uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(JBCOINLOLJD));
			UIEventListener uIEventListener2 = UIEventListener.Get(CPLIMCNBDBP);
			uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener2.onClick, new UIEventListener.VoidDelegate(MALBODMPGAD));
		}
		else
		{
			MBIAKMPDOPG = NDPMDKGJAFH.KHLGDCHJJPB;
			FNGJCFKHOOL.text = MEJMLNDFDBP.ACCGOIGJIAA(NDPMDKGJAFH.MPHCNMDIPAI);
			CPGACIMMFEC.KHMNEOBMJLN();
			Singleton<PlayerTexturePool>.instance.IAINHEFKIFJ(FMALBMBGCLL);
			Singleton<PlayerTexturePool>.instance.BENBEIILCFH(FCNKIEPEAAG);
			Singleton<PlayerTexturePool>.instance.RequestPlayerTexture(MBIAKMPDOPG);
			BCMCMKDCLGP.text = MBIAKMPDOPG.name;
			TweenColor.Begin(BCMCMKDCLGP.gameObject, 1318f, Color.white);
			MEJMLNDFDBP.COCBCFKJOJE(BCMCMKDCLGP, 1426f, 792f);
			KPEKCHDBFIG.text = MEJMLNDFDBP.GMIPFLIEOHD(MBIAKMPDOPG.squadPoints);
			MEJMLNDFDBP.COCBCFKJOJE(KPEKCHDBFIG, 1519f, 1091f, -124);
			LCPBNBLGFIA.alpha = ((!(MBIAKMPDOPG.id == GameLoginManager.currentPlayer.id)) ? 855f : 1263f);
			UIEventListener uIEventListener3 = UIEventListener.Get(OANICEALFGM);
			uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener3.onClick, new UIEventListener.VoidDelegate(FOPHJGOKKPP));
			UIEventListener uIEventListener4 = UIEventListener.Get(OANICEALFGM);
			uIEventListener4.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener4.onClick, new UIEventListener.VoidDelegate(GGPMKLKJIEL));
			UIEventListener uIEventListener5 = UIEventListener.Get(CPLIMCNBDBP);
			uIEventListener5.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener5.onClick, new UIEventListener.VoidDelegate(OPIAOAGOMNM));
			UIEventListener uIEventListener6 = UIEventListener.Get(CPLIMCNBDBP);
			uIEventListener6.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener6.onClick, new UIEventListener.VoidDelegate(EABKFIECKNO));
		}
	}

	public virtual void HOCPBJGFEON()
	{
		base.DestroyPooled();
		UIEventListener uIEventListener = UIEventListener.Get(OANICEALFGM);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(HMOKEFPIJFD));
		UIEventListener uIEventListener2 = UIEventListener.Get(CPLIMCNBDBP);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener2.onClick, new UIEventListener.VoidDelegate(HKOIFINLBLL));
		Singleton<PlayerTexturePool>.instance.DMONMGPPBHN(FCNKIEPEAAG);
		if (MBIAKMPDOPG != null)
		{
			Singleton<PlayerTexturePool>.instance.FNHIOAADLFN(MBIAKMPDOPG.id, false, true, true);
		}
		MBIAKMPDOPG = null;
	}

	private void MIHKPFFOACK(GameObject KHAHPAKDIKE)
	{
		if (!string.IsNullOrEmpty(MBIAKMPDOPG.name))
		{
			SoundsManager.Instance.PlayButtonClickedSound();
			GuiElementSingle<PlayerProfileDialog>.instance.CMOEFABLABI(MBIAKMPDOPG.name, MBIAKMPDOPG.id, false);
		}
	}

	private void GGPMKLKJIEL(GameObject KHAHPAKDIKE)
	{
		if (!string.IsNullOrEmpty(MBIAKMPDOPG.name))
		{
			SoundsManager.Instance.PlayButtonClickedSound();
			GuiElementSingle<PlayerProfileDialog>.instance.EGLMNBKMBAM(MBIAKMPDOPG.name, MBIAKMPDOPG.id, false);
		}
	}

	public virtual void GFNFMCDOKIJ()
	{
		base.OBCAIFMOPPA();
		UIEventListener uIEventListener = UIEventListener.Get(OANICEALFGM);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(JBCOINLOLJD));
		UIEventListener uIEventListener2 = UIEventListener.Get(CPLIMCNBDBP);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener2.onClick, new UIEventListener.VoidDelegate(MALBODMPGAD));
		Singleton<PlayerTexturePool>.instance.FHEJPABPCML(NJKMMHBGPPG);
		if (MBIAKMPDOPG != null)
		{
			Singleton<PlayerTexturePool>.instance.IEPBDAHEKCL(MBIAKMPDOPG.id, true, false, true);
		}
		MBIAKMPDOPG = null;
	}

	public virtual void BCOOIBKBLFD()
	{
		base.BOHCNEDIJPE();
		UIEventListener uIEventListener = UIEventListener.Get(OANICEALFGM);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(MPHHAKFNOFI));
		UIEventListener uIEventListener2 = UIEventListener.Get(CPLIMCNBDBP);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener2.onClick, new UIEventListener.VoidDelegate(OHCFKIHNLHP));
		Singleton<PlayerTexturePool>.instance.OnPlayerTextureCreated -= NJKMMHBGPPG;
		if (MBIAKMPDOPG != null)
		{
			Singleton<PlayerTexturePool>.instance.DAGIACKCPKH(MBIAKMPDOPG.id, true, true);
		}
		MBIAKMPDOPG = null;
	}

	public virtual void PBCHJELFINO()
	{
		base.BOHCNEDIJPE();
		UIEventListener uIEventListener = UIEventListener.Get(OANICEALFGM);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(AEDJNJEGHEC));
		UIEventListener uIEventListener2 = UIEventListener.Get(CPLIMCNBDBP);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener2.onClick, new UIEventListener.VoidDelegate(JMILOMPEJGI));
		Singleton<PlayerTexturePool>.instance.DMONMGPPBHN(POLOPBEOOCB);
		if (MBIAKMPDOPG != null)
		{
			Singleton<PlayerTexturePool>.instance.BPEHHBALINP(MBIAKMPDOPG.id, false);
		}
		MBIAKMPDOPG = null;
	}

	private void HKOIFINLBLL(GameObject KHAHPAKDIKE)
	{
		if (!string.IsNullOrEmpty(MBIAKMPDOPG.name))
		{
			TweenColor tweenColor = TweenColor.Begin(BCMCMKDCLGP.gameObject, GameVariables.KDELCJIAIHM, Color.white, Colours.blue);
			tweenColor.NumOfRepetitions = 0;
			tweenColor.style = (UITweener.Style)4;
			SoundsManager.Instance.PlayButtonClickedSound();
			GuiElementSingle<PlayerProfileDialog>.instance.ShowDialog(MBIAKMPDOPG.name, MBIAKMPDOPG.id, false);
		}
	}

	public void INMHFICPFAJ(SquadWarsContent.IAIOAHOIDOF NDPMDKGJAFH)
	{
		OOIBADLGKML.SetActive(NDPMDKGJAFH.JAHGCGMPCKP);
		IGJMJNHFCAI.SetActive(NDPMDKGJAFH.JAHGCGMPCKP);
		if (NDPMDKGJAFH.JAHGCGMPCKP)
		{
			MBIAKMPDOPG = null;
			UILabel iLGJJLKAAKD = ILGJJLKAAKD;
			object[] array = new object[1];
			array[1] = Colours.stringBlue;
			array[1] = NDPMDKGJAFH.DNOPDJHAFDI;
			iLGJJLKAAKD.text = Localization.LocalizeFormat("ID_NOW", array);
			DGOGCOAKAIL.text = MEJMLNDFDBP.GMIPFLIEOHD(NDPMDKGJAFH.MOEMPHPNBLM);
			float num = DGOGCOAKAIL.relativeSize.x * DGOGCOAKAIL.transform.localScale.x;
			float val = Mathf.Min(1366f, 509f - num / 1078f - 1669f);
			CODFFPODNEP.transform.localPosition = CODFFPODNEP.transform.localPosition.ReplaceX(val);
			UIEventListener uIEventListener = UIEventListener.Get(OANICEALFGM);
			uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(KOMIBCNMEFO));
			UIEventListener uIEventListener2 = UIEventListener.Get(CPLIMCNBDBP);
			uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener2.onClick, new UIEventListener.VoidDelegate(AILFAMAFHFJ));
		}
		else
		{
			MBIAKMPDOPG = NDPMDKGJAFH.KHLGDCHJJPB;
			FNGJCFKHOOL.text = MEJMLNDFDBP.ACCGOIGJIAA(NDPMDKGJAFH.MPHCNMDIPAI);
			CPGACIMMFEC.NCHGDJDAHGC();
			Singleton<PlayerTexturePool>.instance.CKHAAOEMFME(ENGOCPGEONA);
			Singleton<PlayerTexturePool>.instance.MDFAHMDJFDB(FMALBMBGCLL);
			Singleton<PlayerTexturePool>.instance.IIMHJDIPNIA(MBIAKMPDOPG, false, PlayerTexturePool.DFJJOANIJID.Card);
			BCMCMKDCLGP.text = MBIAKMPDOPG.name;
			TweenColor.Begin(BCMCMKDCLGP.gameObject, 1478f, Color.white);
			MEJMLNDFDBP.COCBCFKJOJE(BCMCMKDCLGP, 1658f, 1885f, 1);
			KPEKCHDBFIG.text = MEJMLNDFDBP.GMIPFLIEOHD(MBIAKMPDOPG.squadPoints);
			MEJMLNDFDBP.COCBCFKJOJE(KPEKCHDBFIG, 403f, 950f, 79);
			LCPBNBLGFIA.alpha = ((!(MBIAKMPDOPG.id == GameLoginManager.currentPlayer.id)) ? 1704f : 1680f);
			UIEventListener uIEventListener3 = UIEventListener.Get(OANICEALFGM);
			uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener3.onClick, new UIEventListener.VoidDelegate(GPGKBEJMMOC));
			UIEventListener uIEventListener4 = UIEventListener.Get(OANICEALFGM);
			uIEventListener4.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener4.onClick, new UIEventListener.VoidDelegate(GENEDHLCGNH));
			UIEventListener uIEventListener5 = UIEventListener.Get(CPLIMCNBDBP);
			uIEventListener5.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener5.onClick, new UIEventListener.VoidDelegate(AILFAMAFHFJ));
			UIEventListener uIEventListener6 = UIEventListener.Get(CPLIMCNBDBP);
			uIEventListener6.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener6.onClick, new UIEventListener.VoidDelegate(MCAMADAPPHJ));
		}
	}

	private void FOBBGILKMFN(string ALIIBMLMNKA, Texture2D FCEIGDLFOMH, bool PNDNEMDPFHC)
	{
		if (MBIAKMPDOPG != null && MBIAKMPDOPG.id == ALIIBMLMNKA)
		{
			CPGACIMMFEC.LOCLNGEMNCC(FCEIGDLFOMH);
			CPGACIMMFEC.BFKPPMIKNAA();
		}
	}

	private void NJKMMHBGPPG(string ALIIBMLMNKA, Texture2D FCEIGDLFOMH, bool PNDNEMDPFHC)
	{
		if (MBIAKMPDOPG != null && MBIAKMPDOPG.id == ALIIBMLMNKA)
		{
			CPGACIMMFEC.BIEIDBBDNIF(FCEIGDLFOMH);
			CPGACIMMFEC.GEPDJCOHDNH();
		}
	}

	private void LBHMDCCHFLD(string ALIIBMLMNKA, Texture2D FCEIGDLFOMH, bool PNDNEMDPFHC)
	{
		if (MBIAKMPDOPG != null && MBIAKMPDOPG.id == ALIIBMLMNKA)
		{
			CPGACIMMFEC.JJGFMKCHIPE(FCEIGDLFOMH);
			CPGACIMMFEC.GGLBLHKGCAO();
		}
	}

	private void BFBMONEFKPG(string ALIIBMLMNKA, Texture2D FCEIGDLFOMH, bool PNDNEMDPFHC)
	{
		if (MBIAKMPDOPG != null && MBIAKMPDOPG.id == ALIIBMLMNKA)
		{
			CPGACIMMFEC.OLJPGNNKCKI(FCEIGDLFOMH);
			CPGACIMMFEC.GPHGDAKLAJK();
		}
	}

	private void LLHAKLFKIML(string ALIIBMLMNKA, Texture2D FCEIGDLFOMH, bool PNDNEMDPFHC)
	{
		if (MBIAKMPDOPG != null && MBIAKMPDOPG.id == ALIIBMLMNKA)
		{
			CPGACIMMFEC.KGJCNNANACM(FCEIGDLFOMH);
			CPGACIMMFEC.HCACKHAKDNC();
		}
	}

	private void EABKFIECKNO(GameObject KHAHPAKDIKE)
	{
		if (!string.IsNullOrEmpty(MBIAKMPDOPG.name))
		{
			TweenColor tweenColor = TweenColor.Begin(BCMCMKDCLGP.gameObject, GameVariables.KDELCJIAIHM, Color.white, Colours.blue);
			tweenColor.NumOfRepetitions = 1;
			tweenColor.style = UITweener.Style.Once;
			SoundsManager.Instance.PlayButtonClickedSound();
			GuiElementSingle<PlayerProfileDialog>.instance.EGLMNBKMBAM(MBIAKMPDOPG.name, MBIAKMPDOPG.id, false);
		}
	}

	private void PMANFOPBNNN(GameObject KHAHPAKDIKE)
	{
		if (!string.IsNullOrEmpty(MBIAKMPDOPG.name))
		{
			SoundsManager.Instance.PlayButtonClickedSound();
			GuiElementSingle<PlayerProfileDialog>.instance.CMOEFABLABI(MBIAKMPDOPG.name, MBIAKMPDOPG.id, false);
		}
	}

	public virtual void KIFFEEEDFPD()
	{
		base.OBCAIFMOPPA();
		UIEventListener uIEventListener = UIEventListener.Get(OANICEALFGM);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(HMOKEFPIJFD));
		UIEventListener uIEventListener2 = UIEventListener.Get(CPLIMCNBDBP);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener2.onClick, new UIEventListener.VoidDelegate(MALBODMPGAD));
		Singleton<PlayerTexturePool>.instance.CKHAAOEMFME(ENGOCPGEONA);
		if (MBIAKMPDOPG != null)
		{
			Singleton<PlayerTexturePool>.instance.MDANAEPCCHK(MBIAKMPDOPG.id, false, false, true);
		}
		MBIAKMPDOPG = null;
	}

	public void OLOPLBDKBLA(SquadWarsContent.IAIOAHOIDOF NDPMDKGJAFH)
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
			iLGJJLKAAKD.text = Localization.LocalizeFormat("WarBucks", array);
			DGOGCOAKAIL.text = MEJMLNDFDBP.GMIPFLIEOHD(NDPMDKGJAFH.MOEMPHPNBLM);
			float num = DGOGCOAKAIL.relativeSize.x * DGOGCOAKAIL.transform.localScale.x;
			float val = Mathf.Min(783f, 1882f - num / 1565f - 478f);
			CODFFPODNEP.transform.localPosition = CODFFPODNEP.transform.localPosition.ReplaceX(val);
			UIEventListener uIEventListener = UIEventListener.Get(OANICEALFGM);
			uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(FFNEHMPBLAJ));
			UIEventListener uIEventListener2 = UIEventListener.Get(CPLIMCNBDBP);
			uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener2.onClick, new UIEventListener.VoidDelegate(OHCFKIHNLHP));
		}
		else
		{
			MBIAKMPDOPG = NDPMDKGJAFH.KHLGDCHJJPB;
			FNGJCFKHOOL.text = MEJMLNDFDBP.ACCGOIGJIAA(NDPMDKGJAFH.MPHCNMDIPAI);
			CPGACIMMFEC.Reset();
			Singleton<PlayerTexturePool>.instance.FHEJPABPCML(ENGOCPGEONA);
			Singleton<PlayerTexturePool>.instance.GENOIIGKOIK(FMALBMBGCLL);
			Singleton<PlayerTexturePool>.instance.IIMHJDIPNIA(MBIAKMPDOPG, false, PlayerTexturePool.DFJJOANIJID.Card);
			BCMCMKDCLGP.text = MBIAKMPDOPG.name;
			TweenColor.Begin(BCMCMKDCLGP.gameObject, 1005f, Color.white);
			MEJMLNDFDBP.COCBCFKJOJE(BCMCMKDCLGP, 1205f, 418f, 1);
			KPEKCHDBFIG.text = MEJMLNDFDBP.GMIPFLIEOHD(MBIAKMPDOPG.squadPoints);
			MEJMLNDFDBP.COCBCFKJOJE(KPEKCHDBFIG, 1667f, 583f, -53);
			LCPBNBLGFIA.alpha = ((!(MBIAKMPDOPG.id == GameLoginManager.currentPlayer.id)) ? 675f : 1208f);
			UIEventListener uIEventListener3 = UIEventListener.Get(OANICEALFGM);
			uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener3.onClick, new UIEventListener.VoidDelegate(GENEDHLCGNH));
			UIEventListener uIEventListener4 = UIEventListener.Get(OANICEALFGM);
			uIEventListener4.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener4.onClick, new UIEventListener.VoidDelegate(EFAHKIAKGKC));
			UIEventListener uIEventListener5 = UIEventListener.Get(CPLIMCNBDBP);
			uIEventListener5.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener5.onClick, new UIEventListener.VoidDelegate(EABKFIECKNO));
			UIEventListener uIEventListener6 = UIEventListener.Get(CPLIMCNBDBP);
			uIEventListener6.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener6.onClick, new UIEventListener.VoidDelegate(OPIAOAGOMNM));
		}
	}

	private void MCAMADAPPHJ(GameObject KHAHPAKDIKE)
	{
		if (!string.IsNullOrEmpty(MBIAKMPDOPG.name))
		{
			TweenColor tweenColor = TweenColor.Begin(BCMCMKDCLGP.gameObject, GameVariables.KDELCJIAIHM, Color.white, Colours.blue);
			tweenColor.NumOfRepetitions = 6;
			tweenColor.style = (UITweener.Style)6;
			SoundsManager.Instance.PlayButtonClickedSound();
			GuiElementSingle<PlayerProfileDialog>.instance.ShowDialog(MBIAKMPDOPG.name, MBIAKMPDOPG.id);
		}
	}
}
