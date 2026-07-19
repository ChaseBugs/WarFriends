using System;
using System.Runtime.CompilerServices;
using Google2u;
using UnityEngine;

public class LoginToFacebookDialog : GuiElementSingle<LoginToFacebookDialog>, PAIIOKBBHBC
{
	[Header("Dialog Content")]
	public GameObject JKIBNCMHNDP;

	public GameObject GABAPHBHPOH;

	public UILabel EOHOJBOGNAO;

	public UIButton PHNIFMONKGA;

	public UIButton JHOMCBKIPKK;

	private void KOACKJOKJNP(GameObject KHAHPAKDIKE)
	{
		if (base.isFullyShowed)
		{
			HideDialog();
		}
	}

	private void BHEDBMGGPHM(bool FBFJNHLKJEC)
	{
		if (FBFJNHLKJEC)
		{
			GameLoginManager.instance.AfterTutorialLoginToFacebook();
			HideDialog();
		}
	}

	[CompilerGenerated]
	private void ONAKPPOMOOC(GameObject KHAHPAKDIKE)
	{
		if (!base.isFullyShowed)
		{
			return;
		}
		GuiElementSingle<FacebookDialog>.instance.ShowLoginDialog(delegate(bool FBFJNHLKJEC)
		{
			if (FBFJNHLKJEC)
			{
				GameLoginManager.instance.AfterTutorialLoginToFacebook();
				HideDialog();
			}
		});
	}

	private void POECDPJIIEO(GameObject KHAHPAKDIKE)
	{
		if (BJNBLINDAED())
		{
			GuiElementSingle<FacebookDialog>.instance.MKJANDGAPFF(LFGEAKGLMED);
		}
	}

	private void BNOKBEHPIKJ(GameObject KHAHPAKDIKE)
	{
		if (!AFOFDNJOJHG())
		{
			return;
		}
		GuiElementSingle<FacebookDialog>.instance.MKJANDGAPFF(delegate(bool FBFJNHLKJEC)
		{
			if (FBFJNHLKJEC)
			{
				GameLoginManager.instance.AfterTutorialLoginToFacebook();
				HideDialog();
			}
		});
	}

	public virtual void DLNJFMIDPFE()
	{
		UIEventListener uIEventListener = UIEventListener.Get(PHNIFMONKGA.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(GAJOEPACHHB));
		UIEventListener uIEventListener2 = UIEventListener.Get(JHOMCBKIPKK.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(BNNLLELILEL));
	}

	public virtual void PAIKCHDABEJ()
	{
		DNIJPDFMGML(PHNIFMONKGA.gameObject);
	}

	public override void InitControls()
	{
		UIEventListener uIEventListener = UIEventListener.Get(PHNIFMONKGA.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(GKOHJGFKPAH));
		UIEventListener uIEventListener2 = UIEventListener.Get(JHOMCBKIPKK.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, (UIEventListener.VoidDelegate)delegate
		{
			if (base.isFullyShowed)
			{
				GuiElementSingle<FacebookDialog>.instance.ShowLoginDialog(delegate(bool FBFJNHLKJEC)
				{
					if (FBFJNHLKJEC)
					{
						GameLoginManager.instance.AfterTutorialLoginToFacebook();
						HideDialog();
					}
				});
			}
		});
	}

	public GuiElement JPBIPBMAHBO()
	{
		return this;
	}

	public GuiElement HLEIFPAMOON()
	{
		return this;
	}

	private void DLDCNDNMLFF(bool FBFJNHLKJEC)
	{
		if (FBFJNHLKJEC)
		{
			GameLoginManager.instance.AfterTutorialLoginToFacebook();
			HideDialog();
		}
	}

	public virtual void DOPDLKMCFMA()
	{
		UIEventListener uIEventListener = UIEventListener.Get(PHNIFMONKGA.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(HFKLDKIEBGK));
		UIEventListener uIEventListener2 = UIEventListener.Get(JHOMCBKIPKK.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(GDBNPFGMINL));
	}

	private void MPIPJIKCDPM(GameObject KHAHPAKDIKE)
	{
		if (!AFOFDNJOJHG())
		{
			return;
		}
		GuiElementSingle<FacebookDialog>.instance.MBDJOHOHMMA(delegate(bool FBFJNHLKJEC)
		{
			if (FBFJNHLKJEC)
			{
				GameLoginManager.instance.AfterTutorialLoginToFacebook();
				HideDialog();
			}
		});
	}

	private void OLBCIHPCPOF(GameObject KHAHPAKDIKE)
	{
		if (BJNBLINDAED())
		{
			HideDialog();
		}
	}

	private void LIFLEEGJFFN(GameObject KHAHPAKDIKE)
	{
		if (BJNBLINDAED())
		{
			GuiElementSingle<FacebookDialog>.instance.AGNKAJJBNAJ(FIOHHANEGNP);
		}
	}

	public virtual void OJGFJICEFJE()
	{
		UIEventListener uIEventListener = UIEventListener.Get(PHNIFMONKGA.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(DAJODKGBOML));
		UIEventListener uIEventListener2 = UIEventListener.Get(JHOMCBKIPKK.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(LIFLEEGJFFN));
	}

	public GuiElement IDDIJEBGLDL()
	{
		return this;
	}

	private void HBBLFODLHEN(bool FBFJNHLKJEC)
	{
		if (FBFJNHLKJEC)
		{
			GameLoginManager.instance.AfterTutorialLoginToFacebook();
			HideDialog();
		}
	}

	public virtual void COBDHBOCGAP()
	{
		UIEventListener uIEventListener = UIEventListener.Get(PHNIFMONKGA.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(GAJOEPACHHB));
		UIEventListener uIEventListener2 = UIEventListener.Get(JHOMCBKIPKK.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(MPIPJIKCDPM));
	}

	public GuiElement CBANDKHPNBD()
	{
		return this;
	}

	public virtual void NHOEHNJICBO()
	{
		DAJODKGBOML(PHNIFMONKGA.gameObject);
	}

	private void PMNALHFBIAA(GameObject KHAHPAKDIKE)
	{
		if (MHAIBHBGBOO())
		{
			HideDialog();
		}
	}

	public GuiElement NIONCAAFPGO()
	{
		return this;
	}

	public virtual void FHJDLCDAMGI()
	{
		UIEventListener uIEventListener = UIEventListener.Get(PHNIFMONKGA.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(JBBAFMFBDBE));
		UIEventListener uIEventListener2 = UIEventListener.Get(JHOMCBKIPKK.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(POECDPJIIEO));
	}

	public virtual void KLABPENJAHJ()
	{
		bool flag = PlayerAnalytics.instance.WasOneTimeRewardAdded(Constants.rowIds.ServerRentalVisualProbability);
		JKIBNCMHNDP.SetActive(!flag);
		GABAPHBHPOH.SetActive(flag);
		if (!flag)
		{
			int fFHHEHHFOKJ = (int)(float)Singleton<GameVariables>.instance.CAEDOJHMAAD().GetRow((Constants.rowIds)(-109)).FLOATVALUE;
			EOHOJBOGNAO.text = MEJMLNDFDBP.GMIPFLIEOHD(fFHHEHHFOKJ);
		}
	}

	private void GDBNPFGMINL(GameObject KHAHPAKDIKE)
	{
		if (BKIGLABDGCP())
		{
			GuiElementSingle<FacebookDialog>.instance.MKJANDGAPFF(FIOHHANEGNP);
		}
	}

	public override void OIEPFDKMCNC()
	{
		FDKNMLGJBHO(PHNIFMONKGA.gameObject);
	}

	private void JLJBCDIBBLK(GameObject KHAHPAKDIKE)
	{
		if (LHDGJFHPJNM())
		{
			GuiElementSingle<FacebookDialog>.instance.ShowLoginDialog(DLDCNDNMLFF);
		}
	}

	private void PFLJKJCHCIF(GameObject KHAHPAKDIKE)
	{
		if (BJNBLINDAED())
		{
			GuiElementSingle<FacebookDialog>.instance.JJHMNGMPDCH(BJNIGJDEMGD);
		}
	}

	private void GMEPNIMOMOB(GameObject KHAHPAKDIKE)
	{
		if (LHDGJFHPJNM())
		{
			HideDialog();
		}
	}

	public GuiElement EEAHKOCLJHB()
	{
		return this;
	}

	[CompilerGenerated]
	private void HMGMPCIHJIC(bool FBFJNHLKJEC)
	{
		if (FBFJNHLKJEC)
		{
			GameLoginManager.instance.AfterTutorialLoginToFacebook();
			HideDialog();
		}
	}

	private void DHEPCFMAAPJ(GameObject KHAHPAKDIKE)
	{
		if (LHDGJFHPJNM())
		{
			HideDialog();
		}
	}

	private void CCGAOKKBBIC(GameObject KHAHPAKDIKE)
	{
		if (base.isFullyShowed)
		{
			GuiElementSingle<FacebookDialog>.instance.MKJANDGAPFF(MNDOJANLJAC);
		}
	}

	private void JJHPIPLIIDO(GameObject KHAHPAKDIKE)
	{
		if (BJNBLINDAED())
		{
			HideDialog();
		}
	}

	public virtual void DILDDAGFIEO()
	{
		GPJDIGEHLLO(PHNIFMONKGA.gameObject);
	}

	public override void OnBack()
	{
		GKOHJGFKPAH(PHNIFMONKGA.gameObject);
	}

	private void JBBAFMFBDBE(GameObject KHAHPAKDIKE)
	{
		if (BJNBLINDAED())
		{
			HideDialog();
		}
	}

	public virtual void ODLKCAGIKBE()
	{
		UIEventListener uIEventListener = UIEventListener.Get(PHNIFMONKGA.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(FDKNMLGJBHO));
		UIEventListener uIEventListener2 = UIEventListener.Get(JHOMCBKIPKK.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(CCGAOKKBBIC));
	}

	public virtual void HCAOABHNLID()
	{
		UIEventListener uIEventListener = UIEventListener.Get(PHNIFMONKGA.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(FDKNMLGJBHO));
		UIEventListener uIEventListener2 = UIEventListener.Get(JHOMCBKIPKK.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(JLJBCDIBBLK));
	}

	private void OCEGGNPENEA(bool FBFJNHLKJEC)
	{
		if (FBFJNHLKJEC)
		{
			GameLoginManager.instance.AfterTutorialLoginToFacebook();
			HideDialog();
		}
	}

	private void PHGPDMMLNJP(GameObject KHAHPAKDIKE)
	{
		if (base.isFullyShowed)
		{
			HideDialog();
		}
	}

	private void GNCLOJBFMOI(GameObject KHAHPAKDIKE)
	{
		if (AFOFDNJOJHG())
		{
			HideDialog();
		}
	}

	public virtual void NEOLLOMIKPK()
	{
		bool flag = PlayerAnalytics.instance.WasOneTimeRewardAdded((Constants.rowIds)(-11));
		JKIBNCMHNDP.SetActive(!flag);
		GABAPHBHPOH.SetActive(flag);
		if (!flag)
		{
			int fFHHEHHFOKJ = (int)(float)Singleton<GameVariables>.instance.constants.GetRow((Constants.rowIds)(-86)).FLOATVALUE;
			EOHOJBOGNAO.text = MEJMLNDFDBP.GMIPFLIEOHD(fFHHEHHFOKJ);
		}
	}

	public virtual void JDFDJPAAIAA()
	{
		bool flag = PlayerAnalytics.instance.WasOneTimeRewardAdded(Constants.rowIds.WinstreakReward5);
		JKIBNCMHNDP.SetActive(!flag);
		GABAPHBHPOH.SetActive(flag);
		if (!flag)
		{
			int fFHHEHHFOKJ = (int)(float)Singleton<GameVariables>.instance.OPDHANHDJDC().GetRow(Constants.rowIds.DeathMatchTime).FLOATVALUE;
			EOHOJBOGNAO.text = MEJMLNDFDBP.GMIPFLIEOHD(fFHHEHHFOKJ);
		}
	}

	private void DNIJPDFMGML(GameObject KHAHPAKDIKE)
	{
		if (BJNBLINDAED())
		{
			HideDialog();
		}
	}

	private void FIOHHANEGNP(bool FBFJNHLKJEC)
	{
		if (FBFJNHLKJEC)
		{
			GameLoginManager.instance.AfterTutorialLoginToFacebook();
			HideDialog();
		}
	}

	public GuiElement HDGJKEDKNDL()
	{
		return this;
	}

	public virtual void ILMDHKEMCAM()
	{
		APHFFNCNBHK(PHNIFMONKGA.gameObject);
	}

	private void APHFFNCNBHK(GameObject KHAHPAKDIKE)
	{
		if (BKIGLABDGCP())
		{
			HideDialog();
		}
	}

	public virtual void LIEGBJHHFIG()
	{
		bool flag = PlayerAnalytics.instance.WasOneTimeRewardAdded(Constants.rowIds.WinstreakReward10);
		JKIBNCMHNDP.SetActive(flag);
		GABAPHBHPOH.SetActive(flag);
		if (!flag)
		{
			int fFHHEHHFOKJ = (int)(float)Singleton<GameVariables>.instance.OPDHANHDJDC().GetRow(Constants.rowIds.WinstreakReward2).FLOATVALUE;
			EOHOJBOGNAO.text = MEJMLNDFDBP.GMIPFLIEOHD(fFHHEHHFOKJ);
		}
	}

	public GuiElement LHIPJNFMBHL()
	{
		return this;
	}

	public virtual void IODCFNOOAKM()
	{
		UIEventListener uIEventListener = UIEventListener.Get(PHNIFMONKGA.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(JBBAFMFBDBE));
		UIEventListener uIEventListener2 = UIEventListener.Get(JHOMCBKIPKK.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(GDBNPFGMINL));
	}

	private void GAJOEPACHHB(GameObject KHAHPAKDIKE)
	{
		if (base.isFullyShowed)
		{
			HideDialog();
		}
	}

	public virtual void MAEFFJLPNDK()
	{
		bool flag = PlayerAnalytics.instance.WasOneTimeRewardAdded(Constants.rowIds.WinstreakReward6);
		JKIBNCMHNDP.SetActive(!flag);
		GABAPHBHPOH.SetActive(flag);
		if (!flag)
		{
			int fFHHEHHFOKJ = (int)(float)Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.DogtagAdCount).FLOATVALUE;
			EOHOJBOGNAO.text = MEJMLNDFDBP.GMIPFLIEOHD(fFHHEHHFOKJ);
		}
	}

	private void AHGDFLEMOKB(GameObject KHAHPAKDIKE)
	{
		if (BKIGLABDGCP())
		{
			GuiElementSingle<FacebookDialog>.instance.NNMBENNACOA(MNDOJANLJAC);
		}
	}

	public virtual void FCPGJBMGBLJ()
	{
		PHGPDMMLNJP(PHNIFMONKGA.gameObject);
	}

	private void GPJDIGEHLLO(GameObject KHAHPAKDIKE)
	{
		if (AFOFDNJOJHG())
		{
			HideDialog();
		}
	}

	public virtual void FNLELBKLNBG()
	{
		UIEventListener uIEventListener = UIEventListener.Get(PHNIFMONKGA.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(APHFFNCNBHK));
		UIEventListener uIEventListener2 = UIEventListener.Get(JHOMCBKIPKK.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(BNOKBEHPIKJ));
	}

	public GuiElement HJFNBHHEGIF()
	{
		return this;
	}

	public virtual void NHKGKDBAKLH()
	{
		bool flag = PlayerAnalytics.instance.WasOneTimeRewardAdded(Constants.rowIds.TimeBetweenSquadReminderShown);
		JKIBNCMHNDP.SetActive(flag);
		GABAPHBHPOH.SetActive(flag);
		if (!flag)
		{
			int fFHHEHHFOKJ = (int)(float)Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.ServerRentalWoUDelayMax).FLOATVALUE;
			EOHOJBOGNAO.text = MEJMLNDFDBP.GMIPFLIEOHD(fFHHEHHFOKJ);
		}
	}

	public GuiElement GetGuiElement()
	{
		return this;
	}

	public GuiElement NKAJOPFDFEI()
	{
		return this;
	}

	public virtual void KMCKIIFEKCA()
	{
		bool flag = PlayerAnalytics.instance.WasOneTimeRewardAdded(Constants.rowIds.SilverPackMaxRarityCardsType);
		JKIBNCMHNDP.SetActive(flag);
		GABAPHBHPOH.SetActive(flag);
		if (!flag)
		{
			int fFHHEHHFOKJ = (int)(float)Singleton<GameVariables>.instance.OPDHANHDJDC().GetRow(Constants.rowIds.GoldCardRarity).FLOATVALUE;
			EOHOJBOGNAO.text = MEJMLNDFDBP.GMIPFLIEOHD(fFHHEHHFOKJ);
		}
	}

	public virtual void LFBAOBONBKH()
	{
		GMEPNIMOMOB(PHNIFMONKGA.gameObject);
	}

	private void DAJODKGBOML(GameObject KHAHPAKDIKE)
	{
		if (BKIGLABDGCP())
		{
			HideDialog();
		}
	}

	private void HFKLDKIEBGK(GameObject KHAHPAKDIKE)
	{
		if (AFOFDNJOJHG())
		{
			HideDialog();
		}
	}

	public virtual void ICNGBKKANLB()
	{
		UIEventListener uIEventListener = UIEventListener.Get(PHNIFMONKGA.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(JBBAFMFBDBE));
		UIEventListener uIEventListener2 = UIEventListener.Get(JHOMCBKIPKK.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(BNNLLELILEL));
	}

	public virtual void IMPMPKNJICB()
	{
		UIEventListener uIEventListener = UIEventListener.Get(PHNIFMONKGA.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(APHFFNCNBHK));
		UIEventListener uIEventListener2 = UIEventListener.Get(JHOMCBKIPKK.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(KGJLMADNBDI));
	}

	private void PGCMPBJFBCG(GameObject KHAHPAKDIKE)
	{
		if (base.isFullyShowed)
		{
			GuiElementSingle<FacebookDialog>.instance.JJHMNGMPDCH(HBBLFODLHEN);
		}
	}

	public virtual void AIIJHNNODDM()
	{
		DHEPCFMAAPJ(PHNIFMONKGA.gameObject);
	}

	public virtual void KPMLFMMINEP()
	{
		bool flag = PlayerAnalytics.instance.WasOneTimeRewardAdded((Constants.rowIds)(-93));
		JKIBNCMHNDP.SetActive(!flag);
		GABAPHBHPOH.SetActive(flag);
		if (!flag)
		{
			int fFHHEHHFOKJ = (int)(float)Singleton<GameVariables>.instance.CAEDOJHMAAD().GetRow(Constants.rowIds.WarpathUnlockLevel).FLOATVALUE;
			EOHOJBOGNAO.text = MEJMLNDFDBP.GMIPFLIEOHD(fFHHEHHFOKJ);
		}
	}

	private void MNDOJANLJAC(bool FBFJNHLKJEC)
	{
		if (FBFJNHLKJEC)
		{
			GameLoginManager.instance.AfterTutorialLoginToFacebook();
			HideDialog();
		}
	}

	public virtual void HHDEMBPMOMG()
	{
		PMNALHFBIAA(PHNIFMONKGA.gameObject);
	}

	private void FDKNMLGJBHO(GameObject KHAHPAKDIKE)
	{
		if (base.isFullyShowed)
		{
			HideDialog();
		}
	}

	public virtual void HCMELDFOBCP()
	{
		bool flag = PlayerAnalytics.instance.WasOneTimeRewardAdded((Constants.rowIds)(-15));
		JKIBNCMHNDP.SetActive(!flag);
		GABAPHBHPOH.SetActive(flag);
		if (!flag)
		{
			int fFHHEHHFOKJ = (int)(float)Singleton<GameVariables>.instance.OPDHANHDJDC().GetRow((Constants.rowIds)(-28)).FLOATVALUE;
			EOHOJBOGNAO.text = MEJMLNDFDBP.GMIPFLIEOHD(fFHHEHHFOKJ);
		}
	}

	private void JNOELIDIGNA(GameObject KHAHPAKDIKE)
	{
		if (base.isFullyShowed)
		{
			GuiElementSingle<FacebookDialog>.instance.AGNKAJJBNAJ(BHEDBMGGPHM);
		}
	}

	private void GKOHJGFKPAH(GameObject KHAHPAKDIKE)
	{
		if (base.isFullyShowed)
		{
			HideDialog();
		}
	}

	public virtual void EOFNCJHPHDM()
	{
		PHGPDMMLNJP(PHNIFMONKGA.gameObject);
	}

	public GuiElement AAMCALKKHEL()
	{
		return this;
	}

	public virtual void OBNCKIBJOGJ()
	{
		bool flag = PlayerAnalytics.instance.WasOneTimeRewardAdded((Constants.rowIds)(-57));
		JKIBNCMHNDP.SetActive(!flag);
		GABAPHBHPOH.SetActive(flag);
		if (!flag)
		{
			int fFHHEHHFOKJ = (int)(float)Singleton<GameVariables>.instance.OPDHANHDJDC().GetRow(Constants.rowIds.GoldCardRarityEarly).FLOATVALUE;
			EOHOJBOGNAO.text = MEJMLNDFDBP.GMIPFLIEOHD(fFHHEHHFOKJ);
		}
	}

	private void BJNIGJDEMGD(bool FBFJNHLKJEC)
	{
		if (FBFJNHLKJEC)
		{
			GameLoginManager.instance.AfterTutorialLoginToFacebook();
			HideDialog();
		}
	}

	private void NKPDHCKFJPK(GameObject KHAHPAKDIKE)
	{
		if (BJNBLINDAED())
		{
			HideDialog();
		}
	}

	public override void InitGUIValues()
	{
		bool flag = PlayerAnalytics.instance.WasOneTimeRewardAdded(Constants.rowIds.FacebookLoginReward);
		JKIBNCMHNDP.SetActive(!flag);
		GABAPHBHPOH.SetActive(flag);
		if (!flag)
		{
			int fFHHEHHFOKJ = (int)(float)Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.FacebookLoginReward).FLOATVALUE;
			EOHOJBOGNAO.text = MEJMLNDFDBP.GMIPFLIEOHD(fFHHEHHFOKJ);
		}
	}

	public virtual void PANHEDPIJHD()
	{
		NKPDHCKFJPK(PHNIFMONKGA.gameObject);
	}

	private void IIEPKDABDFP(bool FBFJNHLKJEC)
	{
		if (FBFJNHLKJEC)
		{
			GameLoginManager.instance.AfterTutorialLoginToFacebook();
			HideDialog();
		}
	}

	public virtual void AAJLGPIGDED()
	{
		UIEventListener uIEventListener = UIEventListener.Get(PHNIFMONKGA.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(FDKNMLGJBHO));
		UIEventListener uIEventListener2 = UIEventListener.Get(JHOMCBKIPKK.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(LIFLEEGJFFN));
	}

	private void KGJLMADNBDI(GameObject KHAHPAKDIKE)
	{
		if (MHAIBHBGBOO())
		{
			GuiElementSingle<FacebookDialog>.instance.ShowLoginDialog(BJNIGJDEMGD);
		}
	}

	public GuiElement KBCHMKHIADB()
	{
		return this;
	}

	public GuiElement CPONDDGFBIH()
	{
		return this;
	}

	private void JFNMPPEGJPM(GameObject KHAHPAKDIKE)
	{
		if (AFOFDNJOJHG())
		{
			GuiElementSingle<FacebookDialog>.instance.NONEOAOFPCC(MNDOJANLJAC);
		}
	}

	public virtual void BFLHENDLPLK()
	{
		bool flag = PlayerAnalytics.instance.WasOneTimeRewardAdded(Constants.rowIds.WinstreakReward6);
		JKIBNCMHNDP.SetActive(flag);
		GABAPHBHPOH.SetActive(flag);
		if (!flag)
		{
			int fFHHEHHFOKJ = (int)(float)Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.GoldCoefficient).FLOATVALUE;
			EOHOJBOGNAO.text = MEJMLNDFDBP.GMIPFLIEOHD(fFHHEHHFOKJ);
		}
	}

	private void LFGEAKGLMED(bool FBFJNHLKJEC)
	{
		if (FBFJNHLKJEC)
		{
			GameLoginManager.instance.AfterTutorialLoginToFacebook();
			HideDialog();
		}
	}

	private void BNNLLELILEL(GameObject KHAHPAKDIKE)
	{
		if (AFOFDNJOJHG())
		{
			GuiElementSingle<FacebookDialog>.instance.JJHMNGMPDCH(BJNIGJDEMGD);
		}
	}
}
