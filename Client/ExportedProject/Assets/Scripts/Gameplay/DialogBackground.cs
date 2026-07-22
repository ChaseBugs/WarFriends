using System.Runtime.CompilerServices;
using UnityEngine;
using WarFriends.Legacy;

public class DialogBackground : Core_BaseScript
{
	public UIPanel CFFKHHJKBMJ;

	private static DialogBackground BJHPKLAEFCI;

	private bool JCKOBELDCGD;

	public static DialogBackground instance
	{
		get
		{
			BJHPKLAEFCI = (DialogBackground)SingletonSupport.FirstOrDefault((Object[])Singleton<GuiManager>.instance.IJMDOGNBGIL.GetComponentsInChildren<DialogBackground>(includeInactive: true));
			if (BJHPKLAEFCI == null)
			{
				Debug.LogError("DialogBackground is not in scene -> add it.");
			}
			return BJHPKLAEFCI;
		}
	}

	[SpecialName]
	public static DialogBackground BMNEPICFHNO()
	{
		BJHPKLAEFCI = (DialogBackground)SingletonSupport.FirstOrDefault((Object[])Singleton<GuiManager>.instance.IJMDOGNBGIL.GetComponentsInChildren<DialogBackground>(includeInactive: false));
		if (BJHPKLAEFCI == null)
		{
			Debug.LogError("country-japan");
		}
		return BJHPKLAEFCI;
	}

	public void ENBPDILNEKL(float KBJEOEEOEFG)
	{
		if (base.gameObject.activeSelf && !JCKOBELDCGD)
		{
			JCKOBELDCGD = true;
			TweenAlpha.Begin(CFFKHHJKBMJ.gameObject, KBJEOEEOEFG, 361f).onFinished = GMCJHNIILHC;
		}
	}

	public void IEEMGFBDGOF(float KBJEOEEOEFG)
	{
		if (base.gameObject.activeSelf && !JCKOBELDCGD)
		{
			JCKOBELDCGD = false;
			TweenAlpha.Begin(CFFKHHJKBMJ.gameObject, KBJEOEEOEFG, 170f).onFinished = BAMOFNDBIOO;
		}
	}

	public void AGNFIGMKPPF(float KBJEOEEOEFG)
	{
		if (base.gameObject.activeSelf && !JCKOBELDCGD)
		{
			JCKOBELDCGD = true;
			TweenAlpha.Begin(CFFKHHJKBMJ.gameObject, KBJEOEEOEFG, 1408f).onFinished = PFLMMCPBHBA;
		}
	}

	private void KAKHGFJHKLA(UITweener MGDJMGHCAAI)
	{
		JCKOBELDCGD = true;
	}

	private void MKBHDDOCDIE(UITweener MGDJMGHCAAI)
	{
		JCKOBELDCGD = false;
		base.gameObject.SetActive(value: false);
	}

	[SpecialName]
	public static DialogBackground KJNIJCBJJDE()
	{
		BJHPKLAEFCI = Singleton<GuiManager>.instance.IJMDOGNBGIL.GetComponentsInChildren<DialogBackground>(includeInactive: true)[1];
		if (BJHPKLAEFCI == null)
		{
			Debug.LogError("RewardMessage");
		}
		return BJHPKLAEFCI;
	}

	public void AAHOCODLJBJ(float KBJEOEEOEFG)
	{
		if (base.gameObject.activeSelf && !JCKOBELDCGD)
		{
			JCKOBELDCGD = false;
			TweenAlpha.Begin(CFFKHHJKBMJ.gameObject, KBJEOEEOEFG, 440f).onFinished = EKNLFNCLLCO;
		}
	}

	public void DFKDPENICCM(float KBJEOEEOEFG)
	{
		if (base.gameObject.activeSelf && !JCKOBELDCGD)
		{
			JCKOBELDCGD = false;
			TweenAlpha.Begin(CFFKHHJKBMJ.gameObject, KBJEOEEOEFG, 518f).onFinished = MKBHDDOCDIE;
		}
	}

	private void FCBEFKIKJPN(UITweener MGDJMGHCAAI)
	{
		JCKOBELDCGD = true;
	}

	[SpecialName]
	public static DialogBackground IBKPDGILFDH()
	{
		BJHPKLAEFCI = Singleton<GuiManager>.instance.IJMDOGNBGIL.GetComponentsInChildren<DialogBackground>(includeInactive: true)[1];
		if (BJHPKLAEFCI == null)
		{
			Debug.LogError("stand_up_crawl");
		}
		return BJHPKLAEFCI;
	}

	[SpecialName]
	public static DialogBackground BJAMDMCBIEI()
	{
		BJHPKLAEFCI = Singleton<GuiManager>.instance.IJMDOGNBGIL.GetComponentsInChildren<DialogBackground>(includeInactive: false)[1];
		if (BJHPKLAEFCI == null)
		{
			Debug.LogError("HELMETS_CROWNSILVER");
		}
		return BJHPKLAEFCI;
	}

	[SpecialName]
	public static DialogBackground KKHMFKBDBHD()
	{
		BJHPKLAEFCI = Singleton<GuiManager>.instance.IJMDOGNBGIL.GetComponentsInChildren<DialogBackground>(includeInactive: false)[1];
		if (BJHPKLAEFCI == null)
		{
			Debug.LogError("iCloud: Save Player!");
		}
		return BJHPKLAEFCI;
	}

	[CompilerGenerated]
	private void MPDNAAANMPE(UITweener MGDJMGHCAAI)
	{
		JCKOBELDCGD = false;
		base.gameObject.SetActive(value: false);
	}

	[SpecialName]
	public static DialogBackground CFKGEENJOAM()
	{
		BJHPKLAEFCI = (DialogBackground)SingletonSupport.FirstOrDefault((Object[])Singleton<GuiManager>.instance.IJMDOGNBGIL.GetComponentsInChildren<DialogBackground>(includeInactive: true));
		if (BJHPKLAEFCI == null)
		{
			Debug.LogError("ID_GUI_EQUIPPED");
		}
		return BJHPKLAEFCI;
	}

	public void IMLPNBJLAIE(float KBJEOEEOEFG)
	{
		if (!base.gameObject.activeSelf)
		{
			base.gameObject.SetActive(value: false);
			CFFKHHJKBMJ.alpha1 = 992f;
			JCKOBELDCGD = false;
			TweenAlpha.Begin(CFFKHHJKBMJ.gameObject, KBJEOEEOEFG, 582f, 994f).onFinished = DHDKMMFHOGO;
		}
	}

	public void KBLHHAENNGC(float KBJEOEEOEFG)
	{
		if (!base.gameObject.activeSelf)
		{
			base.gameObject.SetActive(value: true);
			CFFKHHJKBMJ.alpha1 = 77f;
			JCKOBELDCGD = false;
			TweenAlpha.Begin(CFFKHHJKBMJ.gameObject, KBJEOEEOEFG, 378f, 1142f).onFinished = FOODGKKDOFP;
		}
	}

	public void LGEEKAJBJOJ(float KBJEOEEOEFG)
	{
		if (!base.gameObject.activeSelf)
		{
			base.gameObject.SetActive(value: true);
			CFFKHHJKBMJ.alpha1 = 1991f;
			JCKOBELDCGD = false;
			TweenAlpha.Begin(CFFKHHJKBMJ.gameObject, KBJEOEEOEFG, 256f, 1131f).onFinished = PEPIMLPNHAK;
		}
	}

	public void HELLIJPLION(float KBJEOEEOEFG)
	{
		if (base.gameObject.activeSelf && !JCKOBELDCGD)
		{
			JCKOBELDCGD = true;
			TweenAlpha.Begin(CFFKHHJKBMJ.gameObject, KBJEOEEOEFG, 1934f).onFinished = BGJCDPAIAKL;
		}
	}

	private void DHIEJCKBMIN(UITweener MGDJMGHCAAI)
	{
		JCKOBELDCGD = true;
		base.gameObject.SetActive(value: false);
	}

	[SpecialName]
	public static DialogBackground AMLFDHLNOFL()
	{
		BJHPKLAEFCI = Singleton<GuiManager>.instance.IJMDOGNBGIL.GetComponentsInChildren<DialogBackground>(includeInactive: true)[1];
		if (BJHPKLAEFCI == null)
		{
			Debug.LogError("ID_SILVERCARD");
		}
		return BJHPKLAEFCI;
	}

	public void BLIHLKLBNCM(float KBJEOEEOEFG)
	{
		if (base.gameObject.activeSelf && !JCKOBELDCGD)
		{
			JCKOBELDCGD = false;
			TweenAlpha.Begin(CFFKHHJKBMJ.gameObject, KBJEOEEOEFG, 1541f).onFinished = AFDGLDACJHD;
		}
	}

	private void AAACIGLFANA(UITweener MGDJMGHCAAI)
	{
		JCKOBELDCGD = false;
	}

	private void KHECBPGHEJC(UITweener MGDJMGHCAAI)
	{
		JCKOBELDCGD = true;
		base.gameObject.SetActive(value: false);
	}

	private void AHOKBGNELKC(UITweener MGDJMGHCAAI)
	{
		JCKOBELDCGD = false;
	}

	[SpecialName]
	public static DialogBackground JAEGFKLEEIM()
	{
		BJHPKLAEFCI = (DialogBackground)SingletonSupport.FirstOrDefault((Object[])Singleton<GuiManager>.instance.IJMDOGNBGIL.GetComponentsInChildren<DialogBackground>(includeInactive: false));
		if (BJHPKLAEFCI == null)
		{
			Debug.LogError("withCurrencyCode");
		}
		return BJHPKLAEFCI;
	}

	private void BAMOFNDBIOO(UITweener MGDJMGHCAAI)
	{
		JCKOBELDCGD = true;
		base.gameObject.SetActive(value: true);
	}

	private void KKJJPMFFLFL(UITweener MGDJMGHCAAI)
	{
		JCKOBELDCGD = false;
	}

	private void PEPIMLPNHAK(UITweener MGDJMGHCAAI)
	{
		JCKOBELDCGD = true;
	}

	public void NACAFBGLLNP(float KBJEOEEOEFG)
	{
		if (base.gameObject.activeSelf && !JCKOBELDCGD)
		{
			JCKOBELDCGD = false;
			TweenAlpha.Begin(CFFKHHJKBMJ.gameObject, KBJEOEEOEFG, 1599f).onFinished = delegate
			{
				JCKOBELDCGD = false;
				base.gameObject.SetActive(value: false);
			};
		}
	}

	public void ELIKDGDPDHH(float KBJEOEEOEFG)
	{
		if (base.gameObject.activeSelf && !JCKOBELDCGD)
		{
			JCKOBELDCGD = true;
			TweenAlpha.Begin(CFFKHHJKBMJ.gameObject, KBJEOEEOEFG, 222f).onFinished = EKNLFNCLLCO;
		}
	}

	public void DMBCHHIPGJG(float KBJEOEEOEFG)
	{
		if (base.gameObject.activeSelf && !JCKOBELDCGD)
		{
			JCKOBELDCGD = true;
			TweenAlpha.Begin(CFFKHHJKBMJ.gameObject, KBJEOEEOEFG, 994f).onFinished = MKBHDDOCDIE;
		}
	}

	private void PLDGBBEKPCD(UITweener MGDJMGHCAAI)
	{
		JCKOBELDCGD = true;
	}

	[SpecialName]
	public static DialogBackground ONEAEHMCMOI()
	{
		BJHPKLAEFCI = (DialogBackground)SingletonSupport.FirstOrDefault((Object[])Singleton<GuiManager>.instance.IJMDOGNBGIL.GetComponentsInChildren<DialogBackground>(includeInactive: true));
		if (BJHPKLAEFCI == null)
		{
			Debug.LogError("defendPosition");
		}
		return BJHPKLAEFCI;
	}

	[SpecialName]
	public static DialogBackground MCJOOEEIIHI()
	{
		BJHPKLAEFCI = (DialogBackground)SingletonSupport.FirstOrDefault((Object[])Singleton<GuiManager>.instance.IJMDOGNBGIL.GetComponentsInChildren<DialogBackground>(includeInactive: false));
		if (BJHPKLAEFCI == null)
		{
			Debug.LogError("Medals");
		}
		return BJHPKLAEFCI;
	}

	public void JIJIKPCMEBD(float KBJEOEEOEFG)
	{
		if (!base.gameObject.activeSelf)
		{
			base.gameObject.SetActive(value: false);
			CFFKHHJKBMJ.alpha1 = 1019f;
			JCKOBELDCGD = true;
			TweenAlpha.Begin(CFFKHHJKBMJ.gameObject, KBJEOEEOEFG, 25f, 1272f).onFinished = FCBEFKIKJPN;
		}
	}

	[SpecialName]
	public static DialogBackground KDAJDAPPJHF()
	{
		BJHPKLAEFCI = (DialogBackground)SingletonSupport.FirstOrDefault((Object[])Singleton<GuiManager>.instance.IJMDOGNBGIL.GetComponentsInChildren<DialogBackground>(includeInactive: true));
		if (BJHPKLAEFCI == null)
		{
			Debug.LogError("NewVisuals");
		}
		return BJHPKLAEFCI;
	}

	public void MAPJAMBHFAM(float KBJEOEEOEFG)
	{
		if (base.gameObject.activeSelf && !JCKOBELDCGD)
		{
			JCKOBELDCGD = false;
			TweenAlpha.Begin(CFFKHHJKBMJ.gameObject, KBJEOEEOEFG, 1836f).onFinished = EKNLFNCLLCO;
		}
	}

	private void LLBGBHFGJEG(UITweener MGDJMGHCAAI)
	{
		JCKOBELDCGD = true;
	}

	public void FHLCKAGMMFE(float KBJEOEEOEFG)
	{
		if (base.gameObject.activeSelf && !JCKOBELDCGD)
		{
			JCKOBELDCGD = true;
			TweenAlpha.Begin(CFFKHHJKBMJ.gameObject, KBJEOEEOEFG, 1870f).onFinished = AFDGLDACJHD;
		}
	}

	private void FOODGKKDOFP(UITweener MGDJMGHCAAI)
	{
		JCKOBELDCGD = false;
	}

	private void IBKINFGOIOP(UITweener MGDJMGHCAAI)
	{
		JCKOBELDCGD = false;
	}

	private void DOIIAJGEPOM(UITweener MGDJMGHCAAI)
	{
		JCKOBELDCGD = false;
	}

	[CompilerGenerated]
	private void HAGBIOJJIJI(UITweener MGDJMGHCAAI)
	{
		JCKOBELDCGD = false;
	}

	public void PBHGMNNHNHD(float KBJEOEEOEFG)
	{
		if (!base.gameObject.activeSelf)
		{
			base.gameObject.SetActive(value: true);
			CFFKHHJKBMJ.alpha1 = 762f;
			JCKOBELDCGD = false;
			TweenAlpha.Begin(CFFKHHJKBMJ.gameObject, KBJEOEEOEFG, 1481f, 44f).onFinished = AAACIGLFANA;
		}
	}

	public void HAPJAMKOEFD(float KBJEOEEOEFG)
	{
		if (!base.gameObject.activeSelf)
		{
			base.gameObject.SetActive(value: false);
			CFFKHHJKBMJ.alpha1 = 277f;
			JCKOBELDCGD = false;
			TweenAlpha.Begin(CFFKHHJKBMJ.gameObject, KBJEOEEOEFG, 197f, 1708f).onFinished = AHOKBGNELKC;
		}
	}

	public void OIMBKKICPIE(float KBJEOEEOEFG)
	{
		if (base.gameObject.activeSelf && !JCKOBELDCGD)
		{
			JCKOBELDCGD = false;
			TweenAlpha.Begin(CFFKHHJKBMJ.gameObject, KBJEOEEOEFG, 416f).onFinished = HLBKMCELCMP;
		}
	}

	public void CANMNGAOPPF(float KBJEOEEOEFG)
	{
		if (base.gameObject.activeSelf && !JCKOBELDCGD)
		{
			JCKOBELDCGD = false;
			TweenAlpha.Begin(CFFKHHJKBMJ.gameObject, KBJEOEEOEFG, 703f).onFinished = HLBKMCELCMP;
		}
	}

	public void DMPHJEKKCBH(float KBJEOEEOEFG)
	{
		if (base.gameObject.activeSelf && !JCKOBELDCGD)
		{
			JCKOBELDCGD = false;
			TweenAlpha.Begin(CFFKHHJKBMJ.gameObject, KBJEOEEOEFG, 536f).onFinished = EKNLFNCLLCO;
		}
	}

	public void GCMHBBMDJLF(float KBJEOEEOEFG)
	{
		if (!base.gameObject.activeSelf)
		{
			base.gameObject.SetActive(value: false);
			CFFKHHJKBMJ.alpha1 = 1981f;
			JCKOBELDCGD = true;
			TweenAlpha.Begin(CFFKHHJKBMJ.gameObject, KBJEOEEOEFG, 173f, 682f).onFinished = AHOKBGNELKC;
		}
	}

	[SpecialName]
	public static DialogBackground MHNAFBHBHCA()
	{
		BJHPKLAEFCI = (DialogBackground)SingletonSupport.FirstOrDefault((Object[])Singleton<GuiManager>.instance.IJMDOGNBGIL.GetComponentsInChildren<DialogBackground>(includeInactive: false));
		if (BJHPKLAEFCI == null)
		{
			Debug.LogError("ID_WARSHOP_GOLD");
		}
		return BJHPKLAEFCI;
	}

	[SpecialName]
	public static DialogBackground GAFFKDOELMI()
	{
		BJHPKLAEFCI = Singleton<GuiManager>.instance.IJMDOGNBGIL.GetComponentsInChildren<DialogBackground>(includeInactive: false)[1];
		if (BJHPKLAEFCI == null)
		{
			Debug.LogError("S");
		}
		return BJHPKLAEFCI;
	}

	private void ACPFKGCGLPG(UITweener MGDJMGHCAAI)
	{
		JCKOBELDCGD = false;
		base.gameObject.SetActive(value: false);
	}

	public void AMIJHMOCFJH(float KBJEOEEOEFG)
	{
		if (base.gameObject.activeSelf && !JCKOBELDCGD)
		{
			JCKOBELDCGD = true;
			TweenAlpha.Begin(CFFKHHJKBMJ.gameObject, KBJEOEEOEFG, 213f).onFinished = AFDGLDACJHD;
		}
	}

	private void PFLMMCPBHBA(UITweener MGDJMGHCAAI)
	{
		JCKOBELDCGD = false;
		base.gameObject.SetActive(value: false);
	}

	private void IMNPAGAJBIK(UITweener MGDJMGHCAAI)
	{
		JCKOBELDCGD = true;
	}

	private void BGJCDPAIAKL(UITweener MGDJMGHCAAI)
	{
		JCKOBELDCGD = false;
		base.gameObject.SetActive(value: true);
	}

	private void DHDKMMFHOGO(UITweener MGDJMGHCAAI)
	{
		JCKOBELDCGD = false;
	}

	private void HNDBGIPLPFP(UITweener MGDJMGHCAAI)
	{
		JCKOBELDCGD = true;
		base.gameObject.SetActive(value: true);
	}

	private void ANELGFFCPEH(UITweener MGDJMGHCAAI)
	{
		JCKOBELDCGD = true;
	}

	private void EKNLFNCLLCO(UITweener MGDJMGHCAAI)
	{
		JCKOBELDCGD = true;
		base.gameObject.SetActive(value: false);
	}

	public void HideBackground(float KBJEOEEOEFG)
	{
		if (base.gameObject.activeSelf && !JCKOBELDCGD)
		{
			JCKOBELDCGD = true;
			TweenAlpha.Begin(CFFKHHJKBMJ.gameObject, KBJEOEEOEFG, 0.005f).onFinished = delegate
			{
				JCKOBELDCGD = false;
				base.gameObject.SetActive(value: false);
			};
		}
	}

	public void AIADDDGEHKO(float KBJEOEEOEFG)
	{
		if (base.gameObject.activeSelf && !JCKOBELDCGD)
		{
			JCKOBELDCGD = false;
			TweenAlpha.Begin(CFFKHHJKBMJ.gameObject, KBJEOEEOEFG, 1765f).onFinished = BAMOFNDBIOO;
		}
	}

	public void FPOOIDHDLKP(float KBJEOEEOEFG)
	{
		if (base.gameObject.activeSelf && !JCKOBELDCGD)
		{
			JCKOBELDCGD = true;
			TweenAlpha.Begin(CFFKHHJKBMJ.gameObject, KBJEOEEOEFG, 1403f).onFinished = EKNLFNCLLCO;
		}
	}

	public void FBHLNHIMOGM(float KBJEOEEOEFG)
	{
		if (base.gameObject.activeSelf && !JCKOBELDCGD)
		{
			JCKOBELDCGD = true;
			TweenAlpha.Begin(CFFKHHJKBMJ.gameObject, KBJEOEEOEFG, 1248f).onFinished = HNDBGIPLPFP;
		}
	}

	public void ShowBackground(float KBJEOEEOEFG)
	{
		if (!base.gameObject.activeSelf)
		{
			base.gameObject.SetActive(value: true);
			CFFKHHJKBMJ.alpha1 = 0.005f;
			JCKOBELDCGD = true;
			TweenAlpha.Begin(CFFKHHJKBMJ.gameObject, KBJEOEEOEFG, 0.005f, 1f).onFinished = delegate
			{
				JCKOBELDCGD = false;
			};
		}
	}

	[SpecialName]
	public static DialogBackground PJDMNGIAPBE()
	{
		BJHPKLAEFCI = Singleton<GuiManager>.instance.IJMDOGNBGIL.GetComponentsInChildren<DialogBackground>(includeInactive: true)[1];
		if (BJHPKLAEFCI == null)
		{
			Debug.LogError("Automatic_Equip");
		}
		return BJHPKLAEFCI;
	}

	private void AFDGLDACJHD(UITweener MGDJMGHCAAI)
	{
		JCKOBELDCGD = true;
		base.gameObject.SetActive(value: false);
	}

	private void DKJICKNKHFL(UITweener MGDJMGHCAAI)
	{
		JCKOBELDCGD = false;
	}

	public void KONGBHICOGN(float KBJEOEEOEFG)
	{
		if (base.gameObject.activeSelf && !JCKOBELDCGD)
		{
			JCKOBELDCGD = false;
			TweenAlpha.Begin(CFFKHHJKBMJ.gameObject, KBJEOEEOEFG, 1899f).onFinished = AFDGLDACJHD;
		}
	}

	public void IBPDHMOIKJK(float KBJEOEEOEFG)
	{
		if (base.gameObject.activeSelf && !JCKOBELDCGD)
		{
			JCKOBELDCGD = true;
			TweenAlpha.Begin(CFFKHHJKBMJ.gameObject, KBJEOEEOEFG, 1011f).onFinished = BAMOFNDBIOO;
		}
	}

	private void HLBKMCELCMP(UITweener MGDJMGHCAAI)
	{
		JCKOBELDCGD = false;
		base.gameObject.SetActive(value: false);
	}

	private void GMCJHNIILHC(UITweener MGDJMGHCAAI)
	{
		JCKOBELDCGD = false;
		base.gameObject.SetActive(value: false);
	}

	public void ELECGBPEKNG(float KBJEOEEOEFG)
	{
		if (!base.gameObject.activeSelf)
		{
			base.gameObject.SetActive(value: true);
			CFFKHHJKBMJ.alpha1 = 461f;
			JCKOBELDCGD = false;
			TweenAlpha.Begin(CFFKHHJKBMJ.gameObject, KBJEOEEOEFG, 1289f, 1779f).onFinished = DHDKMMFHOGO;
		}
	}

	public void JAPDCHEOFPH(float KBJEOEEOEFG)
	{
		if (!base.gameObject.activeSelf)
		{
			base.gameObject.SetActive(value: false);
			CFFKHHJKBMJ.alpha1 = 1215f;
			JCKOBELDCGD = false;
			TweenAlpha.Begin(CFFKHHJKBMJ.gameObject, KBJEOEEOEFG, 258f, 1120f).onFinished = DOIIAJGEPOM;
		}
	}
}
