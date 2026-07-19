using System;
using System.Runtime.CompilerServices;
using UnityEngine;

public class SettingsGuiContent : Core_BaseScript
{
	[Header("Core")]
	public SettingsButton DBFLEAABFGI;

	public SettingsButton EKJGFIPEKJB;

	public SettingsButton IAOAJDBIAKH;

	public SettingsButton FNHHPIDIKGE;

	public SettingsButton OCMKFJJKKFP;

	public SettingsButton CKCIOAGNPED;

	private bool BLOFHEBNAID
	{
		get
		{
			return DebugSettings.healthbarsOnOpponentUnits;
		}
		set
		{
			if (value != BLOFHEBNAID)
			{
				DebugSettings.healthbarsOnOpponentUnits = value;
			}
		}
	}

	private bool FFAMNEJDFHI
	{
		get
		{
			return DebugSettings.healthbarsOnMyUnits;
		}
		set
		{
			if (value != FFAMNEJDFHI)
			{
				DebugSettings.healthbarsOnMyUnits = value;
			}
		}
	}

	private bool MIDDFNLNKHN
	{
		get
		{
			return DebugSettings.showPrimaryScopes;
		}
		set
		{
			if (value != MIDDFNLNKHN)
			{
				DebugSettings.showPrimaryScopes = value;
			}
		}
	}

	private bool LJKBCICLEME
	{
		get
		{
			return DebugSettings.playerHealthbars;
		}
		set
		{
			if (value != LJKBCICLEME)
			{
				DebugSettings.playerHealthbars = value;
			}
		}
	}

	private bool ECBKIBKBJHM
	{
		get
		{
			return DebugSettings.autoDeploy;
		}
		set
		{
			if (value != ECBKIBKBJHM)
			{
				DebugSettings.autoDeploy = value;
				if (value)
				{
					Singleton<EventTrackingManager>.instance.RegisterAutodeployOn();
				}
				else
				{
					Singleton<EventTrackingManager>.instance.RegisterAutodeployOff();
				}
			}
		}
	}

	private bool KHAKFABBLAG
	{
		get
		{
			return DebugSettings.vibrations;
		}
		set
		{
			if (value != KHAKFABBLAG)
			{
				DebugSettings.vibrations = value;
			}
		}
	}

	public void EFKFHFNAOHA()
	{
		UIEventListener uIEventListener = UIEventListener.Get(DBFLEAABFGI.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, (UIEventListener.VoidDelegate)delegate
		{
			BLOFHEBNAID = !BLOFHEBNAID;
			DBFLEAABFGI.HDFHLAKFNDE(BLOFHEBNAID);
		});
		UIEventListener uIEventListener2 = UIEventListener.Get(EKJGFIPEKJB.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, (UIEventListener.VoidDelegate)delegate
		{
			FFAMNEJDFHI = !FFAMNEJDFHI;
			EKJGFIPEKJB.HDFHLAKFNDE(FFAMNEJDFHI);
		});
		UIEventListener uIEventListener3 = UIEventListener.Get(IAOAJDBIAKH.gameObject);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener3.onClick, new UIEventListener.VoidDelegate(BFEOEKANJBP));
		UIEventListener uIEventListener4 = UIEventListener.Get(FNHHPIDIKGE.gameObject);
		uIEventListener4.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener4.onClick, new UIEventListener.VoidDelegate(LJEKEOPPCDJ));
		UIEventListener uIEventListener5 = UIEventListener.Get(OCMKFJJKKFP.gameObject);
		uIEventListener5.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener5.onClick, (UIEventListener.VoidDelegate)delegate
		{
			ECBKIBKBJHM = !ECBKIBKBJHM;
			OCMKFJJKKFP.HDFHLAKFNDE(ECBKIBKBJHM);
		});
		UIEventListener uIEventListener6 = UIEventListener.Get(CKCIOAGNPED.gameObject);
		uIEventListener6.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener6.onClick, (UIEventListener.VoidDelegate)delegate
		{
			KHAKFABBLAG = !KHAKFABBLAG;
			CKCIOAGNPED.HDFHLAKFNDE(KHAKFABBLAG);
		});
	}

	[CompilerGenerated]
	private void HMGMPCIHJIC(GameObject KHAHPAKDIKE)
	{
		FFAMNEJDFHI = !FFAMNEJDFHI;
		EKJGFIPEKJB.HDFHLAKFNDE(FFAMNEJDFHI);
	}

	private void DBEJBHEPJAN(GameObject KHAHPAKDIKE)
	{
		LJKBCICLEME = !NLJBOJDAGEE();
		FNHHPIDIKGE.IJGNOLEGCOI(LJKBCICLEME);
	}

	private void CFKBBDCJGDM(GameObject KHAHPAKDIKE)
	{
		MCBLPCLMCFB(FFAMNEJDFHI);
		EKJGFIPEKJB.BMEHDKPGOEM(DHFPCPLBJEA(), false);
	}

	[CompilerGenerated]
	private void FLOPNFKLAEG(GameObject KHAHPAKDIKE)
	{
		KHAKFABBLAG = !KHAKFABBLAG;
		CKCIOAGNPED.HDFHLAKFNDE(KHAKFABBLAG);
	}

	public void NGHAPNEFBED()
	{
		DBFLEAABFGI.HICJHPKIMCC(IJEIBNNAKDB(), false);
		EKJGFIPEKJB.EIKGDPJEJAL(DHFPCPLBJEA());
		IAOAJDBIAKH.HPMFEBKKDFO(MIDDFNLNKHN, false);
		FNHHPIDIKGE.GBCDOBCFNOK(NLJBOJDAGEE());
		OCMKFJJKKFP.MLHECBGDMNE(ECBKIBKBJHM, false);
		CKCIOAGNPED.PLMKLGGKMNH(KHAKFABBLAG, false);
	}

	private void EIGHAKHHGEI(GameObject KHAHPAKDIKE)
	{
		MCBLPCLMCFB(!FFAMNEJDFHI);
		EKJGFIPEKJB.HBFBBLFKOMD(DHFPCPLBJEA(), false);
	}

	[SpecialName]
	private void LNODGPNCMNL(bool IDEBKDPMPGM)
	{
		if (IDEBKDPMPGM != ECBKIBKBJHM)
		{
			DebugSettings.autoDeploy = IDEBKDPMPGM;
			if (IDEBKDPMPGM)
			{
				Singleton<EventTrackingManager>.instance.RegisterAutodeployOn();
			}
			else
			{
				Singleton<EventTrackingManager>.instance.RegisterAutodeployOff();
			}
		}
	}

	[SpecialName]
	private void FHOLDJHCONK(bool IDEBKDPMPGM)
	{
		if (IDEBKDPMPGM != BLOFHEBNAID)
		{
			DebugSettings.healthbarsOnOpponentUnits = IDEBKDPMPGM;
		}
	}

	[SpecialName]
	private void MCBLPCLMCFB(bool IDEBKDPMPGM)
	{
		if (IDEBKDPMPGM != DHFPCPLBJEA())
		{
			DebugSettings.healthbarsOnMyUnits = IDEBKDPMPGM;
		}
	}

	[SpecialName]
	private bool HMEKHMHCKEC()
	{
		return DebugSettings.playerHealthbars;
	}

	private void BFEOEKANJBP(GameObject KHAHPAKDIKE)
	{
		JPIONCCLHEN(!MIDDFNLNKHN);
		IAOAJDBIAKH.NFAIPALMOON(BIKKNBENENH(), false);
	}

	private void MKPNHDDPHGJ(GameObject KHAHPAKDIKE)
	{
		JPIONCCLHEN(BIKKNBENENH());
		IAOAJDBIAKH.KFOOJPEOIHP(BIKKNBENENH(), false);
	}

	[SpecialName]
	private bool AKAIIMACGNO()
	{
		return DebugSettings.playerHealthbars;
	}

	[SpecialName]
	private bool DHFPCPLBJEA()
	{
		return DebugSettings.healthbarsOnMyUnits;
	}

	public void InitControls()
	{
		UIEventListener uIEventListener = UIEventListener.Get(DBFLEAABFGI.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, (UIEventListener.VoidDelegate)delegate
		{
			BLOFHEBNAID = !BLOFHEBNAID;
			DBFLEAABFGI.HDFHLAKFNDE(BLOFHEBNAID);
		});
		UIEventListener uIEventListener2 = UIEventListener.Get(EKJGFIPEKJB.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, (UIEventListener.VoidDelegate)delegate
		{
			FFAMNEJDFHI = !FFAMNEJDFHI;
			EKJGFIPEKJB.HDFHLAKFNDE(FFAMNEJDFHI);
		});
		UIEventListener uIEventListener3 = UIEventListener.Get(IAOAJDBIAKH.gameObject);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener3.onClick, (UIEventListener.VoidDelegate)delegate
		{
			MIDDFNLNKHN = !MIDDFNLNKHN;
			IAOAJDBIAKH.HDFHLAKFNDE(MIDDFNLNKHN);
		});
		UIEventListener uIEventListener4 = UIEventListener.Get(FNHHPIDIKGE.gameObject);
		uIEventListener4.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener4.onClick, (UIEventListener.VoidDelegate)delegate
		{
			LJKBCICLEME = !LJKBCICLEME;
			FNHHPIDIKGE.HDFHLAKFNDE(LJKBCICLEME);
		});
		UIEventListener uIEventListener5 = UIEventListener.Get(OCMKFJJKKFP.gameObject);
		uIEventListener5.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener5.onClick, (UIEventListener.VoidDelegate)delegate
		{
			ECBKIBKBJHM = !ECBKIBKBJHM;
			OCMKFJJKKFP.HDFHLAKFNDE(ECBKIBKBJHM);
		});
		UIEventListener uIEventListener6 = UIEventListener.Get(CKCIOAGNPED.gameObject);
		uIEventListener6.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener6.onClick, (UIEventListener.VoidDelegate)delegate
		{
			KHAKFABBLAG = !KHAKFABBLAG;
			CKCIOAGNPED.HDFHLAKFNDE(KHAKFABBLAG);
		});
	}

	[CompilerGenerated]
	private void ONAKPPOMOOC(GameObject KHAHPAKDIKE)
	{
		BLOFHEBNAID = !BLOFHEBNAID;
		DBFLEAABFGI.HDFHLAKFNDE(BLOFHEBNAID);
	}

	[SpecialName]
	private void JOFGLBIJPJD(bool IDEBKDPMPGM)
	{
		if (IDEBKDPMPGM != KHAKFABBLAG)
		{
			DebugSettings.vibrations = IDEBKDPMPGM;
		}
	}

	[SpecialName]
	private void JPIONCCLHEN(bool IDEBKDPMPGM)
	{
		if (IDEBKDPMPGM != BIKKNBENENH())
		{
			DebugSettings.showPrimaryScopes = IDEBKDPMPGM;
		}
	}

	public void ODLKCAGIKBE()
	{
		UIEventListener uIEventListener = UIEventListener.Get(DBFLEAABFGI.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, (UIEventListener.VoidDelegate)delegate
		{
			BLOFHEBNAID = !BLOFHEBNAID;
			DBFLEAABFGI.HDFHLAKFNDE(BLOFHEBNAID);
		});
		UIEventListener uIEventListener2 = UIEventListener.Get(EKJGFIPEKJB.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(CFKBBDCJGDM));
		UIEventListener uIEventListener3 = UIEventListener.Get(IAOAJDBIAKH.gameObject);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener3.onClick, new UIEventListener.VoidDelegate(MKPNHDDPHGJ));
		UIEventListener uIEventListener4 = UIEventListener.Get(FNHHPIDIKGE.gameObject);
		uIEventListener4.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener4.onClick, new UIEventListener.VoidDelegate(LJEKEOPPCDJ));
		UIEventListener uIEventListener5 = UIEventListener.Get(OCMKFJJKKFP.gameObject);
		uIEventListener5.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener5.onClick, (UIEventListener.VoidDelegate)delegate
		{
			ECBKIBKBJHM = !ECBKIBKBJHM;
			OCMKFJJKKFP.HDFHLAKFNDE(ECBKIBKBJHM);
		});
		UIEventListener uIEventListener6 = UIEventListener.Get(CKCIOAGNPED.gameObject);
		uIEventListener6.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener6.onClick, (UIEventListener.VoidDelegate)delegate
		{
			KHAKFABBLAG = !KHAKFABBLAG;
			CKCIOAGNPED.HDFHLAKFNDE(KHAKFABBLAG);
		});
	}

	private void LJEKEOPPCDJ(GameObject KHAHPAKDIKE)
	{
		JFIAPALCDGA(!NLJBOJDAGEE());
		FNHHPIDIKGE.EIKGDPJEJAL(AKAIIMACGNO());
	}

	[CompilerGenerated]
	private void DCOJJDIKBBC(GameObject KHAHPAKDIKE)
	{
		MIDDFNLNKHN = !MIDDFNLNKHN;
		IAOAJDBIAKH.HDFHLAKFNDE(MIDDFNLNKHN);
	}

	[SpecialName]
	private void HLHBAMEGKCA(bool IDEBKDPMPGM)
	{
		if (IDEBKDPMPGM != MIDDFNLNKHN)
		{
			DebugSettings.showPrimaryScopes = IDEBKDPMPGM;
		}
	}

	[SpecialName]
	private bool NLJBOJDAGEE()
	{
		return DebugSettings.playerHealthbars;
	}

	[SpecialName]
	private void DIENGIEAGOI(bool IDEBKDPMPGM)
	{
		if (IDEBKDPMPGM != DHFPCPLBJEA())
		{
			DebugSettings.healthbarsOnMyUnits = IDEBKDPMPGM;
		}
	}

	[SpecialName]
	private void JFIAPALCDGA(bool IDEBKDPMPGM)
	{
		if (IDEBKDPMPGM != HMEKHMHCKEC())
		{
			DebugSettings.playerHealthbars = IDEBKDPMPGM;
		}
	}

	[SpecialName]
	private bool IJEIBNNAKDB()
	{
		return DebugSettings.healthbarsOnOpponentUnits;
	}

	public void InitGUIValues()
	{
		DBFLEAABFGI.HDFHLAKFNDE(BLOFHEBNAID, false);
		EKJGFIPEKJB.HDFHLAKFNDE(FFAMNEJDFHI, false);
		IAOAJDBIAKH.HDFHLAKFNDE(MIDDFNLNKHN, false);
		FNHHPIDIKGE.HDFHLAKFNDE(LJKBCICLEME, false);
		OCMKFJJKKFP.HDFHLAKFNDE(ECBKIBKBJHM, false);
		CKCIOAGNPED.HDFHLAKFNDE(KHAKFABBLAG, false);
	}

	[CompilerGenerated]
	private void IIKKMAEBFJO(GameObject KHAHPAKDIKE)
	{
		ECBKIBKBJHM = !ECBKIBKBJHM;
		OCMKFJJKKFP.HDFHLAKFNDE(ECBKIBKBJHM);
	}

	[SpecialName]
	private void IMHDPMLGKAK(bool IDEBKDPMPGM)
	{
		if (IDEBKDPMPGM != IJEIBNNAKDB())
		{
			DebugSettings.healthbarsOnOpponentUnits = IDEBKDPMPGM;
		}
	}

	[CompilerGenerated]
	private void EACNIDLHDGD(GameObject KHAHPAKDIKE)
	{
		LJKBCICLEME = !LJKBCICLEME;
		FNHHPIDIKGE.HDFHLAKFNDE(LJKBCICLEME);
	}

	[SpecialName]
	private bool BIKKNBENENH()
	{
		return DebugSettings.showPrimaryScopes;
	}
}
