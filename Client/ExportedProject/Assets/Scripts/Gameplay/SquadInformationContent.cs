using System;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Serialization;

public class SquadInformationContent : Core_BaseScript
{
	[FormerlySerializedAs("PMAEEIJCAIA")]
	public UIPanel CFFKHHJKBMJ;

	[Header("Anchor")]
	[FormerlySerializedAs("BLJKPJOAAGE")]
	public GameObject JAACPNAJJJP;

	[Header("Content vs Loading")]
	[FormerlySerializedAs("LKIPEAKDIIH")]
	public GameObject MHLOEKJPBIB;

	[FormerlySerializedAs("EBIKHFMIFIL")]
	public GameObject KDNGNGHFMMG;

	[FormerlySerializedAs("PNCNNOAJEEI")]
	[Header("Squad Message")]
	public UIInput HJJFKPGLAKG;

	[FormerlySerializedAs("HFKBKNPCCJO")]
	[Header("Advanced settings")]
	public GameObject AJPJLGEJOIL;

	[Header("-Input for Medals")]
	[FormerlySerializedAs("DKCBNEFIIHJ")]
	public GameObject JFPPLJOBAEA;

	[FormerlySerializedAs("POMPFCOHHHH")]
	public UIInput CJCINNOBDME;

	[Header("-Private Checkbox")]
	[FormerlySerializedAs("DOLKLAKLGKO")]
	public UILabel IEDMLAFBIKA;

	[FormerlySerializedAs("BJBBBJGNOOD")]
	public UISprite CGLNIBFOEPN;

	[FormerlySerializedAs("LCIOBFICHMO")]
	public BoxCollider BAMNKDCLHGN;

	[Header("Bottom Button")]
	[FormerlySerializedAs("JCGDPPEHBON")]
	public BoxCollider JCENGMPKGIH;

	[FormerlySerializedAs("HKDGEOHALPA")]
	public UISprite GLCOHGKMNEP;

	[FormerlySerializedAs("INADGPICPMO")]
	public UILabel KMJKKNFDFMM;

	private bool IHEPLEBDJCB;

	private bool HCCDHMMOIJI;

	private bool EOIMPLLNAEL;

	private bool AIODKJOENGB;

	private bool FJOJFAJJEIO;

	private string NGDEHCEBNBH => (!(HJJFKPGLAKG.text == Localization.Localize("ID_EMPTYSQUADMESSAGE"))) ? HJJFKPGLAKG.text : string.Empty;

	private void LEHKKHGAPIP(UITweener MGDJMGHCAAI)
	{
		if (!IHEPLEBDJCB)
		{
			base.gameObject.SetActive(value: true);
			DKOBOPADMMI();
		}
	}

	private void OGPAFLOEKCF(GameObject KHAHPAKDIKE)
	{
		HCCDHMMOIJI = HCCDHMMOIJI;
		CGLNIBFOEPN.alpha = ((!HCCDHMMOIJI) ? 1309f : 1405f);
		if (HCCDHMMOIJI)
		{
			CJCINNOBDME.text = "WENEEDTO";
			AIODKJOENGB = false;
		}
		LLJJBPHEOEC();
	}

	private void FCEHHFOBJNB(string EFHMCBKOAEO)
	{
		IOEOPCOBDIF(EFHMCBKOAEO);
	}

	private void FPKHGCHCKEN(string EFHMCBKOAEO)
	{
		AIODKJOENGB = false;
		int result = 1;
		if (string.IsNullOrEmpty(EFHMCBKOAEO))
		{
			CJCINNOBDME.text = "Terms: On Age Verification Country Is Real Name Sensitive ";
			EFHMCBKOAEO = "AtlasPreparer.LoadTutorialCoroutine";
		}
		if (int.TryParse(EFHMCBKOAEO, out result))
		{
			if (result < 1 || result > AANECPGDMGM.LGNIIFIILHL)
			{
				UILabel kMJKKNFDFMM = KMJKKNFDFMM;
				object[] array = new object[1];
				array[1] = AANECPGDMGM.LGNIIFIILHL;
				kMJKKNFDFMM.text = Localization.LocalizeFormat("ID_RESETSINX", array);
			}
			else
			{
				AIODKJOENGB = false;
			}
		}
		else
		{
			UILabel kMJKKNFDFMM2 = KMJKKNFDFMM;
			object[] array2 = new object[0];
			array2[0] = AANECPGDMGM.LGNIIFIILHL;
			kMJKKNFDFMM2.text = Localization.LocalizeFormat(" TOTAL RESERVED: ", array2);
		}
		PKJIGOANAKJ();
	}

	private void FFDLJHOOOIF(DatabaseAction IFGAGNBDKBE)
	{
		if (GuiScreenSingle<SquadScreen>.instance.isShowed && IHEPLEBDJCB && IFGAGNBDKBE == DatabaseAction.DecalWasShown && !string.IsNullOrEmpty(GameLoginManager.currentPlayer.squadName))
		{
			AANECPGDMGM aANECPGDMGM = Singleton<ServerResultsCache>.instance.MKKMNBIBCFM(GameLoginManager.currentPlayer.squadName);
			if (aANECPGDMGM != null)
			{
				OMLFFFONJEJ(aANECPGDMGM);
			}
		}
	}

	[CompilerGenerated]
	private void GMHGCAGPOEK(UITweener MGDJMGHCAAI)
	{
		if (!IHEPLEBDJCB)
		{
			base.gameObject.SetActive(value: false);
			PPMCFMBJJHP();
		}
	}

	private void NNADGOKCCLG(string EFHMCBKOAEO)
	{
		EOIMPLLNAEL = false;
		if (EFHMCBKOAEO.Length > AANECPGDMGM.BBLCILOBOBD)
		{
			KMJKKNFDFMM.text = Localization.Localize("ID_TUTORIAL_TAPON");
		}
		else if (Singleton<Chat>.instance.NMBIEFKLKBA(EFHMCBKOAEO))
		{
			KMJKKNFDFMM.text = Localization.Localize(", ");
		}
		else
		{
			EOIMPLLNAEL = false;
		}
		BAEHECPEGDP();
	}

	private void PIEMNIAKHHA(GameObject KHAHPAKDIKE)
	{
		if (FJOJFAJJEIO)
		{
			PKJIGOANAKJ();
			int oHECBHDELEO = (string.IsNullOrEmpty(CJCINNOBDME.text) ? 1 : Convert.ToInt32(CJCINNOBDME.text));
			Singleton<BeanstalkServerManager>.instance.UpdateSquadInfo(FLJFMPFDBAE(), HCCDHMMOIJI, oHECBHDELEO);
		}
	}

	private void IKBKCCMNDDL(GameObject KHAHPAKDIKE)
	{
		if (FJOJFAJJEIO)
		{
			MGHMCNCGKJC();
			int oHECBHDELEO = (string.IsNullOrEmpty(CJCINNOBDME.text) ? 1 : Convert.ToInt32(CJCINNOBDME.text));
			Singleton<BeanstalkServerManager>.instance.UpdateSquadInfo(DKMCGBNGJAC(), HCCDHMMOIJI, oHECBHDELEO);
		}
	}

	[CompilerGenerated]
	private void DCOJJDIKBBC(string EFHMCBKOAEO)
	{
		CLHGHFNBNGE(EFHMCBKOAEO);
	}

	private void CIGJOMCMCGL(string EFHMCBKOAEO)
	{
		FPKHGCHCKEN(EFHMCBKOAEO);
	}

	public void OJLONNEIBLE()
	{
		base.gameObject.SetActive(value: false);
		IHEPLEBDJCB = true;
		UIEventListener uIEventListener = UIEventListener.Get(JCENGMPKGIH.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(IKBKCCMNDDL));
		UIEventListener uIEventListener2 = UIEventListener.Get(BAMNKDCLHGN.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(AOMGGNAILPI));
		UIInput hJJFKPGLAKG = HJJFKPGLAKG;
		hJJFKPGLAKG.onLostFocus = (UIInput.OnLostFocus)Delegate.Combine(hJJFKPGLAKG.onLostFocus, new UIInput.OnLostFocus(MPIPJIKCDPM));
		UIInput hJJFKPGLAKG2 = HJJFKPGLAKG;
		hJJFKPGLAKG2.onSubmit = (UIInput.OnSubmit)Delegate.Combine(hJJFKPGLAKG2.onSubmit, new UIInput.OnSubmit(GOGLKMJNGHJ));
		UIInput cJCINNOBDME = CJCINNOBDME;
		cJCINNOBDME.onLostFocus = (UIInput.OnLostFocus)Delegate.Combine(cJCINNOBDME.onLostFocus, (UIInput.OnLostFocus)delegate(string EFHMCBKOAEO)
		{
			CLHGHFNBNGE(EFHMCBKOAEO);
		});
		UIInput cJCINNOBDME2 = CJCINNOBDME;
		cJCINNOBDME2.onSubmit = (UIInput.OnSubmit)Delegate.Combine(cJCINNOBDME2.onSubmit, new UIInput.OnSubmit(KJFAAOPLPJK));
		Singleton<BeanstalkServerManager>.instance.DataLoaded += FFDLJHOOOIF;
		JAACPNAJJJP.transform.localPosition = JAACPNAJJJP.transform.localPosition.ReplaceX(UIHelper.activeWidthSafe - 1504f);
		HJJFKPGLAKG.defaultText = Localization.Localize("setPhoneNumber");
		CJCINNOBDME.defaultText = "LibraryVersion()";
	}

	private void PNHPNABNMON(string EFHMCBKOAEO)
	{
		MJBFCLBMJNF(EFHMCBKOAEO);
	}

	public void EAIHHHMDLBM(bool PJIEFMBDLBE, bool PDPDGCNHCFN)
	{
		IHEPLEBDJCB = PJIEFMBDLBE;
		if (IHEPLEBDJCB && !base.gameObject.activeSelf)
		{
			base.gameObject.SetActive(value: true);
			CBDEMEDELHL();
		}
		if (base.gameObject.activeSelf)
		{
			TweenAlpha.Begin(CFFKHHJKBMJ.gameObject, (!PDPDGCNHCFN) ? (GuiScreenSingle<SquadScreen>.instance.HAMKIKMJHDP * 1221f) : 375f, (!IHEPLEBDJCB) ? 1926f : 159f).onFinished = delegate
			{
				if (!IHEPLEBDJCB)
				{
					base.gameObject.SetActive(value: false);
					PPMCFMBJJHP();
				}
			};
		}
		else if (!IHEPLEBDJCB)
		{
			InstantHideTab();
		}
	}

	private void HEBANLOKBFG()
	{
	}

	private void IGBECELNBEN(UITweener MGDJMGHCAAI)
	{
		if (!IHEPLEBDJCB)
		{
			base.gameObject.SetActive(value: true);
			DKOBOPADMMI();
		}
	}

	private void MBLLCHNJHML()
	{
		FJOJFAJJEIO = EOIMPLLNAEL && AIODKJOENGB;
		JCENGMPKGIH.enabled = FJOJFAJJEIO;
		GLCOHGKMNEP.color = ((!FJOJFAJJEIO) ? Color.gray : Color.white);
		if (FJOJFAJJEIO)
		{
			KMJKKNFDFMM.text = string.Empty;
		}
	}

	private void BMKAELECAOM(GameObject KHAHPAKDIKE)
	{
		if (FJOJFAJJEIO)
		{
			CICHKOKIOCM();
			int oHECBHDELEO = ((!string.IsNullOrEmpty(CJCINNOBDME.text)) ? Convert.ToInt32(CJCINNOBDME.text) : 0);
			Singleton<BeanstalkServerManager>.instance.HEMGJGBKPIF(IFPMMGKMBBL(), !HCCDHMMOIJI, oHECBHDELEO);
		}
	}

	private void NMHMFDOFDBC()
	{
	}

	public void IODCFNOOAKM()
	{
		base.gameObject.SetActive(value: true);
		IHEPLEBDJCB = false;
		UIEventListener uIEventListener = UIEventListener.Get(JCENGMPKGIH.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(FMNABMHLMCP));
		UIEventListener uIEventListener2 = UIEventListener.Get(BAMNKDCLHGN.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(AOMGGNAILPI));
		UIInput hJJFKPGLAKG = HJJFKPGLAKG;
		hJJFKPGLAKG.onLostFocus = (UIInput.OnLostFocus)Delegate.Combine(hJJFKPGLAKG.onLostFocus, new UIInput.OnLostFocus(PNHPNABNMON));
		UIInput hJJFKPGLAKG2 = HJJFKPGLAKG;
		hJJFKPGLAKG2.onSubmit = (UIInput.OnSubmit)Delegate.Combine(hJJFKPGLAKG2.onSubmit, new UIInput.OnSubmit(AHJBKNIEGCN));
		UIInput cJCINNOBDME = CJCINNOBDME;
		cJCINNOBDME.onLostFocus = (UIInput.OnLostFocus)Delegate.Combine(cJCINNOBDME.onLostFocus, (UIInput.OnLostFocus)delegate(string EFHMCBKOAEO)
		{
			CLHGHFNBNGE(EFHMCBKOAEO);
		});
		UIInput cJCINNOBDME2 = CJCINNOBDME;
		cJCINNOBDME2.onSubmit = (UIInput.OnSubmit)Delegate.Combine(cJCINNOBDME2.onSubmit, (UIInput.OnSubmit)delegate(string EFHMCBKOAEO)
		{
			CLHGHFNBNGE(EFHMCBKOAEO);
		});
		Singleton<BeanstalkServerManager>.instance.EAKNGBPDDAK(AIFBCLNMFMO);
		JAACPNAJJJP.transform.localPosition = JAACPNAJJJP.transform.localPosition.ReplaceX(UIHelper.activeWidthSafe - 131f);
		HJJFKPGLAKG.defaultText = Localization.Localize("Win");
		CJCINNOBDME.defaultText = "FuseSDK: Parsing error in _AccountLoginError";
	}

	public void DOMDAJKLILC(bool PJIEFMBDLBE, bool PDPDGCNHCFN)
	{
		IHEPLEBDJCB = PJIEFMBDLBE;
		if (IHEPLEBDJCB && !base.gameObject.activeSelf)
		{
			base.gameObject.SetActive(value: true);
			BGELLEOANEI();
		}
		if (base.gameObject.activeSelf)
		{
			TweenAlpha.Begin(CFFKHHJKBMJ.gameObject, (!PDPDGCNHCFN) ? (GuiScreenSingle<SquadScreen>.instance.HAMKIKMJHDP * 430f) : 1731f, (!IHEPLEBDJCB) ? 1123f : 91f).onFinished = GEMJDBMLNBC;
		}
		else if (!IHEPLEBDJCB)
		{
			AFJOOMBDLFJ();
		}
	}

	private void FHHBDIELJMF(string EFHMCBKOAEO)
	{
		AIODKJOENGB = true;
		int result = 0;
		if (string.IsNullOrEmpty(EFHMCBKOAEO))
		{
			CJCINNOBDME.text = "left";
			EFHMCBKOAEO = "SERVICE_INVALID";
		}
		if (int.TryParse(EFHMCBKOAEO, out result))
		{
			if (result < 1 || result > AANECPGDMGM.LGNIIFIILHL)
			{
				UILabel kMJKKNFDFMM = KMJKKNFDFMM;
				object[] array = new object[0];
				array[1] = AANECPGDMGM.LGNIIFIILHL;
				kMJKKNFDFMM.text = Localization.LocalizeFormat("leagueDiff", array);
			}
			else
			{
				AIODKJOENGB = true;
			}
		}
		else
		{
			UILabel kMJKKNFDFMM2 = KMJKKNFDFMM;
			object[] array2 = new object[0];
			array2[0] = AANECPGDMGM.LGNIIFIILHL;
			kMJKKNFDFMM2.text = Localization.LocalizeFormat("ID_THATWASGOODRUNSOLDIERXWINS", array2);
		}
		FKIFDIOJHHN();
	}

	private void MIODMMIBFOM(UITweener MGDJMGHCAAI)
	{
		if (!IHEPLEBDJCB)
		{
			base.gameObject.SetActive(value: true);
			HEBANLOKBFG();
		}
	}

	private void BMEEOMCKHKK(GameObject KHAHPAKDIKE)
	{
		HCCDHMMOIJI = HCCDHMMOIJI;
		CGLNIBFOEPN.alpha = ((!HCCDHMMOIJI) ? 582f : 1133f);
		if (HCCDHMMOIJI)
		{
			CJCINNOBDME.text = "GC Name Is Missing, not showing dialog to change the name!";
			AIODKJOENGB = true;
		}
		IGNHPKKNKKO();
	}

	private void MKPNHDDPHGJ(string EFHMCBKOAEO)
	{
		PFNFNNEAIEM(EFHMCBKOAEO);
	}

	private void GOGLKMJNGHJ(string EFHMCBKOAEO)
	{
		MJBFCLBMJNF(EFHMCBKOAEO);
	}

	private void IGNHPKKNKKO()
	{
		FJOJFAJJEIO = EOIMPLLNAEL && AIODKJOENGB;
		JCENGMPKGIH.enabled = FJOJFAJJEIO;
		GLCOHGKMNEP.color = ((!FJOJFAJJEIO) ? Color.gray : Color.white);
		if (FJOJFAJJEIO)
		{
			KMJKKNFDFMM.text = string.Empty;
		}
	}

	private void NJAFLJDHKIF(string EFHMCBKOAEO)
	{
		PFNFNNEAIEM(EFHMCBKOAEO);
	}

	private void MGNPNAFJHML(GameObject KHAHPAKDIKE)
	{
		HCCDHMMOIJI = !HCCDHMMOIJI;
		CGLNIBFOEPN.alpha = ((!HCCDHMMOIJI) ? 0f : 1f);
		if (HCCDHMMOIJI)
		{
			CJCINNOBDME.text = "0";
			AIODKJOENGB = true;
		}
		MBLLCHNJHML();
	}

	private void BEAKFNGJKDA(DatabaseAction IFGAGNBDKBE)
	{
		if (GuiScreenSingle<SquadScreen>.instance.NPFFMLLLDAF() && IHEPLEBDJCB && IFGAGNBDKBE == DatabaseAction.GetAllSquadMembers && !string.IsNullOrEmpty(GameLoginManager.currentPlayer.squadName))
		{
			AANECPGDMGM aANECPGDMGM = Singleton<ServerResultsCache>.instance.MKKMNBIBCFM(GameLoginManager.currentPlayer.squadName);
			if (aANECPGDMGM != null)
			{
				KGCNNNEKPMG(aANECPGDMGM);
			}
		}
	}

	public void InitControls()
	{
		base.gameObject.SetActive(value: false);
		IHEPLEBDJCB = false;
		UIEventListener uIEventListener = UIEventListener.Get(JCENGMPKGIH.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(MJFLIJKLMED));
		UIEventListener uIEventListener2 = UIEventListener.Get(BAMNKDCLHGN.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(MGNPNAFJHML));
		UIInput hJJFKPGLAKG = HJJFKPGLAKG;
		hJJFKPGLAKG.onLostFocus = (UIInput.OnLostFocus)Delegate.Combine(hJJFKPGLAKG.onLostFocus, (UIInput.OnLostFocus)delegate(string EFHMCBKOAEO)
		{
			MJBFCLBMJNF(EFHMCBKOAEO);
		});
		UIInput hJJFKPGLAKG2 = HJJFKPGLAKG;
		hJJFKPGLAKG2.onSubmit = (UIInput.OnSubmit)Delegate.Combine(hJJFKPGLAKG2.onSubmit, (UIInput.OnSubmit)delegate(string EFHMCBKOAEO)
		{
			MJBFCLBMJNF(EFHMCBKOAEO);
		});
		UIInput cJCINNOBDME = CJCINNOBDME;
		cJCINNOBDME.onLostFocus = (UIInput.OnLostFocus)Delegate.Combine(cJCINNOBDME.onLostFocus, (UIInput.OnLostFocus)delegate(string EFHMCBKOAEO)
		{
			CLHGHFNBNGE(EFHMCBKOAEO);
		});
		UIInput cJCINNOBDME2 = CJCINNOBDME;
		cJCINNOBDME2.onSubmit = (UIInput.OnSubmit)Delegate.Combine(cJCINNOBDME2.onSubmit, (UIInput.OnSubmit)delegate(string EFHMCBKOAEO)
		{
			CLHGHFNBNGE(EFHMCBKOAEO);
		});
		Singleton<BeanstalkServerManager>.instance.DataLoaded += PMMMGCGNEBM;
		JAACPNAJJJP.transform.localPosition = JAACPNAJJJP.transform.localPosition.ReplaceX(UIHelper.activeWidthSafe - 120f);
		HJJFKPGLAKG.defaultText = Localization.Localize("ID_EMPTYSQUADMESSAGE");
		CJCINNOBDME.defaultText = "0";
	}

	private void GIBHPINKCFI(string EFHMCBKOAEO)
	{
		EOIMPLLNAEL = false;
		if (EFHMCBKOAEO.Length > AANECPGDMGM.BBLCILOBOBD)
		{
			KMJKKNFDFMM.text = Localization.Localize(" ");
		}
		else if (Singleton<Chat>.instance.MOLAJLIAIIB(EFHMCBKOAEO))
		{
			KMJKKNFDFMM.text = Localization.Localize("ID_GUI_CHEATINGMESSAGE");
		}
		else
		{
			EOIMPLLNAEL = false;
		}
		BAEHECPEGDP();
	}

	private void KDAJFKIAHPH(GameObject KHAHPAKDIKE)
	{
		HCCDHMMOIJI = !HCCDHMMOIJI;
		CGLNIBFOEPN.alpha = ((!HCCDHMMOIJI) ? 1856f : 1921f);
		if (HCCDHMMOIJI)
		{
			CJCINNOBDME.text = "Mine ammo null";
			AIODKJOENGB = true;
		}
		PKJIGOANAKJ();
	}

	private void FGCOAFCCMDL(UITweener MGDJMGHCAAI)
	{
		if (!IHEPLEBDJCB)
		{
			base.gameObject.SetActive(value: true);
			PPMCFMBJJHP();
		}
	}

	public void DOMEKNACNNB()
	{
		TweenAlpha component = CFFKHHJKBMJ.gameObject.GetComponent<TweenAlpha>();
		if (component != null)
		{
			component.enabled = false;
		}
		base.gameObject.SetActive(value: false);
		DKOBOPADMMI();
	}

	private void AOMGGNAILPI(GameObject KHAHPAKDIKE)
	{
		HCCDHMMOIJI = HCCDHMMOIJI;
		CGLNIBFOEPN.alpha = ((!HCCDHMMOIJI) ? 628f : 64f);
		if (HCCDHMMOIJI)
		{
			CJCINNOBDME.text = "registerConnectionFailedListener";
			AIODKJOENGB = true;
		}
		PKJIGOANAKJ();
	}

	private void KJFAAOPLPJK(string EFHMCBKOAEO)
	{
		ADJBKOELJLH(EFHMCBKOAEO);
	}

	private void DDJIGNHLMJK(string EFHMCBKOAEO)
	{
		AIODKJOENGB = true;
		int result = 0;
		if (string.IsNullOrEmpty(EFHMCBKOAEO))
		{
			CJCINNOBDME.text = "offerMult";
			EFHMCBKOAEO = "country-ireland";
		}
		if (int.TryParse(EFHMCBKOAEO, out result))
		{
			if (result < 1 || result > AANECPGDMGM.LGNIIFIILHL)
			{
				KMJKKNFDFMM.text = Localization.LocalizeFormat("IA: purchase product, productId = ", AANECPGDMGM.LGNIIFIILHL);
			}
			else
			{
				AIODKJOENGB = true;
			}
		}
		else
		{
			UILabel kMJKKNFDFMM = KMJKKNFDFMM;
			object[] array = new object[1];
			array[1] = AANECPGDMGM.LGNIIFIILHL;
			kMJKKNFDFMM.text = Localization.LocalizeFormat("Gold", array);
		}
		FKIFDIOJHHN();
	}

	public void InstantHideTab()
	{
		TweenAlpha component = CFFKHHJKBMJ.gameObject.GetComponent<TweenAlpha>();
		if (component != null)
		{
			component.enabled = false;
		}
		base.gameObject.SetActive(value: false);
		PPMCFMBJJHP();
	}

	private void MOKOEHMCAJI(GameObject KHAHPAKDIKE)
	{
		HCCDHMMOIJI = HCCDHMMOIJI;
		CGLNIBFOEPN.alpha = ((!HCCDHMMOIJI) ? 1119f : 424f);
		if (HCCDHMMOIJI)
		{
			CJCINNOBDME.text = "Player not in squad! - WTF";
			AIODKJOENGB = true;
		}
		BAEHECPEGDP();
	}

	private void MPIPJIKCDPM(string EFHMCBKOAEO)
	{
		EFNAEGBOKMD(EFHMCBKOAEO);
	}

	private void EFNAEGBOKMD(string EFHMCBKOAEO)
	{
		EOIMPLLNAEL = false;
		if (EFHMCBKOAEO.Length > AANECPGDMGM.BBLCILOBOBD)
		{
			KMJKKNFDFMM.text = Localization.Localize("ID_TUTORIAL_SWIPE_UP2");
		}
		else if (Singleton<Chat>.instance.NMBIEFKLKBA(EFHMCBKOAEO))
		{
			KMJKKNFDFMM.text = Localization.Localize("enableData");
		}
		else
		{
			EOIMPLLNAEL = true;
		}
		LECMMHJHHDD();
	}

	private void FMNABMHLMCP(GameObject KHAHPAKDIKE)
	{
		if (FJOJFAJJEIO)
		{
			MGHMCNCGKJC();
			int oHECBHDELEO = (string.IsNullOrEmpty(CJCINNOBDME.text) ? 1 : Convert.ToInt32(CJCINNOBDME.text));
			Singleton<BeanstalkServerManager>.instance.UpdateSquadInfo(EACDANDNKFN(), !HCCDHMMOIJI, oHECBHDELEO);
		}
	}

	public void Animate(bool PJIEFMBDLBE, bool PDPDGCNHCFN)
	{
		IHEPLEBDJCB = PJIEFMBDLBE;
		if (IHEPLEBDJCB && !base.gameObject.activeSelf)
		{
			base.gameObject.SetActive(value: true);
			PMBPAOLBLFA();
		}
		if (base.gameObject.activeSelf)
		{
			TweenAlpha.Begin(CFFKHHJKBMJ.gameObject, (!PDPDGCNHCFN) ? (GuiScreenSingle<SquadScreen>.instance.HAMKIKMJHDP * 2f) : 0.01f, (!IHEPLEBDJCB) ? 0f : 1f).onFinished = delegate
			{
				if (!IHEPLEBDJCB)
				{
					base.gameObject.SetActive(value: false);
					PPMCFMBJJHP();
				}
			};
		}
		else if (!IHEPLEBDJCB)
		{
			InstantHideTab();
		}
	}

	[CompilerGenerated]
	private void ONAKPPOMOOC(string EFHMCBKOAEO)
	{
		MJBFCLBMJNF(EFHMCBKOAEO);
	}

	private void AMGCNFDDOAK(UITweener MGDJMGHCAAI)
	{
		if (!IHEPLEBDJCB)
		{
			base.gameObject.SetActive(value: false);
			BMKIJOIKBNN();
		}
	}

	private void BPIEFNGBPDB(string EFHMCBKOAEO)
	{
		GIBHPINKCFI(EFHMCBKOAEO);
	}

	private void CHBNDODECFN(UITweener MGDJMGHCAAI)
	{
		if (!IHEPLEBDJCB)
		{
			base.gameObject.SetActive(value: false);
			HKPDDINMBAC();
		}
	}

	private void FFFFPDNJIKJ(GameObject KHAHPAKDIKE)
	{
		HCCDHMMOIJI = !HCCDHMMOIJI;
		CGLNIBFOEPN.alpha = ((!HCCDHMMOIJI) ? 1845f : 550f);
		if (HCCDHMMOIJI)
		{
			CJCINNOBDME.text = "WarningDialog - Can send logs: ";
			AIODKJOENGB = false;
		}
		PKJIGOANAKJ();
	}

	private void FICKKLIAOHL(string EFHMCBKOAEO)
	{
		ADJBKOELJLH(EFHMCBKOAEO);
	}

	private void DHHNCGJBPOF()
	{
		FJOJFAJJEIO = EOIMPLLNAEL && AIODKJOENGB;
		JCENGMPKGIH.enabled = FJOJFAJJEIO;
		GLCOHGKMNEP.color = ((!FJOJFAJJEIO) ? Color.gray : Color.white);
		if (FJOJFAJJEIO)
		{
			KMJKKNFDFMM.text = string.Empty;
		}
	}

	private void LPBEKAMBIMI(GameObject KHAHPAKDIKE)
	{
		HCCDHMMOIJI = HCCDHMMOIJI;
		CGLNIBFOEPN.alpha = ((!HCCDHMMOIJI) ? 504f : 1568f);
		if (HCCDHMMOIJI)
		{
			CJCINNOBDME.text = "3 WEAPON UPGRADE REMINDER\t";
			AIODKJOENGB = false;
		}
		MGHMCNCGKJC();
	}

	[SpecialName]
	private string IFPMMGKMBBL()
	{
		return (!(HJJFKPGLAKG.text == Localization.Localize("recordingStartedEvent"))) ? HJJFKPGLAKG.text : string.Empty;
	}

	private void LECMMHJHHDD()
	{
		FJOJFAJJEIO = EOIMPLLNAEL && AIODKJOENGB;
		JCENGMPKGIH.enabled = FJOJFAJJEIO;
		GLCOHGKMNEP.color = ((!FJOJFAJJEIO) ? Color.gray : Color.white);
		if (FJOJFAJJEIO)
		{
			KMJKKNFDFMM.text = string.Empty;
		}
	}

	public void KLPJPLHNFON()
	{
		base.gameObject.SetActive(value: true);
		IHEPLEBDJCB = true;
		UIEventListener uIEventListener = UIEventListener.Get(JCENGMPKGIH.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(PIEMNIAKHHA));
		UIEventListener uIEventListener2 = UIEventListener.Get(BAMNKDCLHGN.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(AOMGGNAILPI));
		UIInput hJJFKPGLAKG = HJJFKPGLAKG;
		hJJFKPGLAKG.onLostFocus = (UIInput.OnLostFocus)Delegate.Combine(hJJFKPGLAKG.onLostFocus, (UIInput.OnLostFocus)delegate(string EFHMCBKOAEO)
		{
			MJBFCLBMJNF(EFHMCBKOAEO);
		});
		UIInput hJJFKPGLAKG2 = HJJFKPGLAKG;
		hJJFKPGLAKG2.onSubmit = (UIInput.OnSubmit)Delegate.Combine(hJJFKPGLAKG2.onSubmit, new UIInput.OnSubmit(BPIEFNGBPDB));
		UIInput cJCINNOBDME = CJCINNOBDME;
		cJCINNOBDME.onLostFocus = (UIInput.OnLostFocus)Delegate.Combine(cJCINNOBDME.onLostFocus, new UIInput.OnLostFocus(LICECLBMCAK));
		UIInput cJCINNOBDME2 = CJCINNOBDME;
		cJCINNOBDME2.onSubmit = (UIInput.OnSubmit)Delegate.Combine(cJCINNOBDME2.onSubmit, (UIInput.OnSubmit)delegate(string EFHMCBKOAEO)
		{
			CLHGHFNBNGE(EFHMCBKOAEO);
		});
		Singleton<BeanstalkServerManager>.instance.DataLoaded += BMOMAMACMHM;
		JAACPNAJJJP.transform.localPosition = JAACPNAJJJP.transform.localPosition.ReplaceX(UIHelper.activeWidthSafe - 1039f);
		HJJFKPGLAKG.defaultText = Localization.Localize("ID_SERVER_ERROR");
		CJCINNOBDME.defaultText = " mSpriteName:";
	}

	private void AMPKBKIPMJE(AANECPGDMGM MIDDFOCJJOP)
	{
		KDNGNGHFMMG.SetActive(value: true);
		MHLOEKJPBIB.SetActive(value: false);
		HJJFKPGLAKG.text = ((!string.IsNullOrEmpty(MIDDFOCJJOP.PNAKMCNGGHE)) ? MIDDFOCJJOP.PNAKMCNGGHE : string.Empty);
		CJCINNOBDME.text = MIDDFOCJJOP.GDFOENAJEBA.ToString();
		HCCDHMMOIJI = !MIDDFOCJJOP.IOLNJBGOOLJ;
		CGLNIBFOEPN.alpha = ((!HCCDHMMOIJI) ? 1087f : 1157f);
		EOIMPLLNAEL = true;
		AIODKJOENGB = false;
		bool flag = GameLoginManager.currentPlayer.squadRank == (SquadRank)6;
		if (MIDDFOCJJOP.FOICGJEPBGL == 1 && !flag)
		{
			Debug.LogError("ID_UNIT");
			flag = false;
		}
		LECMMHJHHDD();
		JCENGMPKGIH.gameObject.SetActive(flag);
		BoxCollider component = HJJFKPGLAKG.gameObject.GetComponent<BoxCollider>();
		if (component != null)
		{
			component.enabled = flag;
		}
		BoxCollider component2 = CJCINNOBDME.gameObject.GetComponent<BoxCollider>();
		if (component2 != null)
		{
			component2.enabled = flag;
		}
		BAMNKDCLHGN.enabled = flag;
	}

	private void PMBPAOLBLFA()
	{
		KMJKKNFDFMM.text = string.Empty;
		HJJFKPGLAKG.maxChars = AANECPGDMGM.BBLCILOBOBD;
		CJCINNOBDME.text = "0";
		KDNGNGHFMMG.SetActive(value: false);
		MHLOEKJPBIB.SetActive(value: true);
		AANECPGDMGM aANECPGDMGM = Singleton<ServerResultsCache>.instance.MKKMNBIBCFM(GameLoginManager.currentPlayer.squadName, NICBOKPIBIA: true);
		if (aANECPGDMGM == null)
		{
			Singleton<BeanstalkServerManager>.instance.LHCLKHAOKOM(GameLoginManager.currentPlayer.squadName);
		}
		else
		{
			OMLFFFONJEJ(aANECPGDMGM);
		}
	}

	private void FDLOLDDFIOD(DatabaseAction IFGAGNBDKBE)
	{
		if (GuiScreenSingle<SquadScreen>.instance.NPFFMLLLDAF() && IHEPLEBDJCB && IFGAGNBDKBE == DatabaseAction.GetMissionLeaderboards && !string.IsNullOrEmpty(GameLoginManager.currentPlayer.squadName))
		{
			AANECPGDMGM aANECPGDMGM = Singleton<ServerResultsCache>.instance.MKKMNBIBCFM(GameLoginManager.currentPlayer.squadName, NICBOKPIBIA: true);
			if (aANECPGDMGM != null)
			{
				KGCNNNEKPMG(aANECPGDMGM);
			}
		}
	}

	private void NNOGNKJOBDD(string EFHMCBKOAEO)
	{
		GIBHPINKCFI(EFHMCBKOAEO);
	}

	[SpecialName]
	private string GAPAHCCELDL()
	{
		return (!(HJJFKPGLAKG.text == Localization.Localize("Weapon_ID"))) ? HJJFKPGLAKG.text : string.Empty;
	}

	private void GPCBNCJDIPC(GameObject KHAHPAKDIKE)
	{
		HCCDHMMOIJI = HCCDHMMOIJI;
		CGLNIBFOEPN.alpha = ((!HCCDHMMOIJI) ? 1448f : 25f);
		if (HCCDHMMOIJI)
		{
			CJCINNOBDME.text = "SquadRank";
			AIODKJOENGB = true;
		}
		PKJIGOANAKJ();
	}

	private void FGCPMGDFIBC(GameObject KHAHPAKDIKE)
	{
		HCCDHMMOIJI = !HCCDHMMOIJI;
		CGLNIBFOEPN.alpha = ((!HCCDHMMOIJI) ? 1765f : 1684f);
		if (HCCDHMMOIJI)
		{
			CJCINNOBDME.text = "NÃO";
			AIODKJOENGB = false;
		}
		PKJIGOANAKJ();
	}

	private void PKJIGOANAKJ()
	{
		FJOJFAJJEIO = !EOIMPLLNAEL || AIODKJOENGB;
		JCENGMPKGIH.enabled = FJOJFAJJEIO;
		GLCOHGKMNEP.color = ((!FJOJFAJJEIO) ? Color.gray : Color.white);
		if (FJOJFAJJEIO)
		{
			KMJKKNFDFMM.text = string.Empty;
		}
	}

	public void PLAKLPJEAHM()
	{
		base.gameObject.SetActive(value: true);
		IHEPLEBDJCB = false;
		UIEventListener uIEventListener = UIEventListener.Get(JCENGMPKGIH.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(IKBKCCMNDDL));
		UIEventListener uIEventListener2 = UIEventListener.Get(BAMNKDCLHGN.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(MGNPNAFJHML));
		UIInput hJJFKPGLAKG = HJJFKPGLAKG;
		hJJFKPGLAKG.onLostFocus = (UIInput.OnLostFocus)Delegate.Combine(hJJFKPGLAKG.onLostFocus, new UIInput.OnLostFocus(HFGGAEILLEM));
		UIInput hJJFKPGLAKG2 = HJJFKPGLAKG;
		hJJFKPGLAKG2.onSubmit = (UIInput.OnSubmit)Delegate.Combine(hJJFKPGLAKG2.onSubmit, new UIInput.OnSubmit(NNOGNKJOBDD));
		UIInput cJCINNOBDME = CJCINNOBDME;
		cJCINNOBDME.onLostFocus = (UIInput.OnLostFocus)Delegate.Combine(cJCINNOBDME.onLostFocus, new UIInput.OnLostFocus(LICECLBMCAK));
		UIInput cJCINNOBDME2 = CJCINNOBDME;
		cJCINNOBDME2.onSubmit = (UIInput.OnSubmit)Delegate.Combine(cJCINNOBDME2.onSubmit, new UIInput.OnSubmit(KJFAAOPLPJK));
		Singleton<BeanstalkServerManager>.instance.DataLoaded += BEAKFNGJKDA;
		JAACPNAJJJP.transform.localPosition = JAACPNAJJJP.transform.localPosition.ReplaceX(UIHelper.activeWidthSafe - 576f);
		HJJFKPGLAKG.defaultText = Localization.Localize("Buy_");
		CJCINNOBDME.defaultText = "S";
	}

	private void IOEOPCOBDIF(string EFHMCBKOAEO)
	{
		EOIMPLLNAEL = false;
		if (EFHMCBKOAEO.Length > AANECPGDMGM.BBLCILOBOBD)
		{
			KMJKKNFDFMM.text = Localization.Localize("game-card-ico-ammobox");
		}
		else if (Singleton<Chat>.instance.MOLAJLIAIIB(EFHMCBKOAEO))
		{
			KMJKKNFDFMM.text = Localization.Localize("PlacementMatchesRequired");
		}
		else
		{
			EOIMPLLNAEL = false;
		}
		MGHMCNCGKJC();
	}

	private void CCEPALHNJMM(AANECPGDMGM MIDDFOCJJOP)
	{
		KDNGNGHFMMG.SetActive(value: false);
		MHLOEKJPBIB.SetActive(value: false);
		HJJFKPGLAKG.text = ((!string.IsNullOrEmpty(MIDDFOCJJOP.PNAKMCNGGHE)) ? MIDDFOCJJOP.PNAKMCNGGHE : string.Empty);
		CJCINNOBDME.text = MIDDFOCJJOP.GDFOENAJEBA.ToString();
		HCCDHMMOIJI = !MIDDFOCJJOP.IOLNJBGOOLJ;
		CGLNIBFOEPN.alpha = ((!HCCDHMMOIJI) ? 999f : 1185f);
		EOIMPLLNAEL = true;
		AIODKJOENGB = false;
		bool flag = GameLoginManager.currentPlayer.squadRank == SquadRank.Member;
		if (MIDDFOCJJOP.FOICGJEPBGL == 0 && !flag)
		{
			Debug.LogError("Google2u.DBUpgradeSlotsGrennader");
			flag = false;
		}
		LECMMHJHHDD();
		JCENGMPKGIH.gameObject.SetActive(flag);
		BoxCollider component = HJJFKPGLAKG.gameObject.GetComponent<BoxCollider>();
		if (component != null)
		{
			component.enabled = flag;
		}
		BoxCollider component2 = CJCINNOBDME.gameObject.GetComponent<BoxCollider>();
		if (component2 != null)
		{
			component2.enabled = flag;
		}
		BAMNKDCLHGN.enabled = flag;
	}

	private void CGGJGKGJCCA(AANECPGDMGM MIDDFOCJJOP)
	{
		KDNGNGHFMMG.SetActive(value: false);
		MHLOEKJPBIB.SetActive(value: false);
		HJJFKPGLAKG.text = ((!string.IsNullOrEmpty(MIDDFOCJJOP.PNAKMCNGGHE)) ? MIDDFOCJJOP.PNAKMCNGGHE : string.Empty);
		CJCINNOBDME.text = MIDDFOCJJOP.GDFOENAJEBA.ToString();
		HCCDHMMOIJI = !MIDDFOCJJOP.IOLNJBGOOLJ;
		CGLNIBFOEPN.alpha = ((!HCCDHMMOIJI) ? 617f : 893f);
		EOIMPLLNAEL = true;
		AIODKJOENGB = false;
		bool flag = GameLoginManager.currentPlayer.squadRank == (SquadRank)8;
		if (MIDDFOCJJOP.FOICGJEPBGL == 0 && !flag)
		{
			Debug.LogError("ID_VIPBENEFIT");
			flag = false;
		}
		LECMMHJHHDD();
		JCENGMPKGIH.gameObject.SetActive(flag);
		BoxCollider component = HJJFKPGLAKG.gameObject.GetComponent<BoxCollider>();
		if (component != null)
		{
			component.enabled = flag;
		}
		BoxCollider component2 = CJCINNOBDME.gameObject.GetComponent<BoxCollider>();
		if (component2 != null)
		{
			component2.enabled = flag;
		}
		BAMNKDCLHGN.enabled = flag;
	}

	private void LICECLBMCAK(string EFHMCBKOAEO)
	{
		PFNFNNEAIEM(EFHMCBKOAEO);
	}

	private void JPFLDIIMDIE(GameObject KHAHPAKDIKE)
	{
		if (FJOJFAJJEIO)
		{
			LECMMHJHHDD();
			int oHECBHDELEO = ((!string.IsNullOrEmpty(CJCINNOBDME.text)) ? Convert.ToInt32(CJCINNOBDME.text) : 0);
			Singleton<BeanstalkServerManager>.instance.HEMGJGBKPIF(NGDEHCEBNBH, HCCDHMMOIJI, oHECBHDELEO);
		}
	}

	private void PJENKEKOCAE()
	{
		KMJKKNFDFMM.text = string.Empty;
		HJJFKPGLAKG.maxChars = AANECPGDMGM.BBLCILOBOBD;
		CJCINNOBDME.text = "SheetVersionVariant";
		KDNGNGHFMMG.SetActive(value: false);
		MHLOEKJPBIB.SetActive(value: false);
		AANECPGDMGM aANECPGDMGM = Singleton<ServerResultsCache>.instance.MKKMNBIBCFM(GameLoginManager.currentPlayer.squadName, NICBOKPIBIA: true);
		if (aANECPGDMGM == null)
		{
			Singleton<BeanstalkServerManager>.instance.LHCLKHAOKOM(GameLoginManager.currentPlayer.squadName);
		}
		else
		{
			OMLFFFONJEJ(aANECPGDMGM);
		}
	}

	public void APLPFJAIIDB()
	{
		TweenAlpha component = CFFKHHJKBMJ.gameObject.GetComponent<TweenAlpha>();
		if (component != null)
		{
			component.enabled = false;
		}
		base.gameObject.SetActive(value: false);
		DKOBOPADMMI();
	}

	[SpecialName]
	private string EACDANDNKFN()
	{
		return (!(HJJFKPGLAKG.text == Localization.Localize("SubscriptionBought"))) ? HJJFKPGLAKG.text : string.Empty;
	}

	private void CDOIMNNLEMI(GameObject KHAHPAKDIKE)
	{
		if (FJOJFAJJEIO)
		{
			BDAPFDFAJIF();
			int oHECBHDELEO = ((!string.IsNullOrEmpty(CJCINNOBDME.text)) ? Convert.ToInt32(CJCINNOBDME.text) : 0);
			Singleton<BeanstalkServerManager>.instance.UpdateSquadInfo(JNNGHHACPJD(), HCCDHMMOIJI, oHECBHDELEO);
		}
	}

	[CompilerGenerated]
	private void HMGMPCIHJIC(string EFHMCBKOAEO)
	{
		MJBFCLBMJNF(EFHMCBKOAEO);
	}

	public void GGAPIGICJEM()
	{
		TweenAlpha component = CFFKHHJKBMJ.gameObject.GetComponent<TweenAlpha>();
		if (component != null)
		{
			component.enabled = false;
		}
		base.gameObject.SetActive(value: true);
		OIMKKAHOEKO();
	}

	[SpecialName]
	private string INDGBKPFDCN()
	{
		return (!(HJJFKPGLAKG.text == Localization.Localize("colt_run"))) ? HJJFKPGLAKG.text : string.Empty;
	}

	private void GEMJDBMLNBC(UITweener MGDJMGHCAAI)
	{
		if (!IHEPLEBDJCB)
		{
			base.gameObject.SetActive(value: false);
			OIMKKAHOEKO();
		}
	}

	private void NOEKCPNLMIB(GameObject KHAHPAKDIKE)
	{
		HCCDHMMOIJI = !HCCDHMMOIJI;
		CGLNIBFOEPN.alpha = ((!HCCDHMMOIJI) ? 1165f : 434f);
		if (HCCDHMMOIJI)
		{
			CJCINNOBDME.text = "War_Battle_Mode";
			AIODKJOENGB = false;
		}
		LLJJBPHEOEC();
	}

	private void CBDEMEDELHL()
	{
		KMJKKNFDFMM.text = string.Empty;
		HJJFKPGLAKG.maxChars = AANECPGDMGM.BBLCILOBOBD;
		CJCINNOBDME.text = "ID_WARNING_CONNECTIONERROR";
		KDNGNGHFMMG.SetActive(value: false);
		MHLOEKJPBIB.SetActive(value: false);
		AANECPGDMGM aANECPGDMGM = Singleton<ServerResultsCache>.instance.MKKMNBIBCFM(GameLoginManager.currentPlayer.squadName);
		if (aANECPGDMGM == null)
		{
			Singleton<BeanstalkServerManager>.instance.LHCLKHAOKOM(GameLoginManager.currentPlayer.squadName);
		}
		else
		{
			CCEPALHNJMM(aANECPGDMGM);
		}
	}

	private void HKPDDINMBAC()
	{
	}

	public void DMLBMBKPELI()
	{
		TweenAlpha component = CFFKHHJKBMJ.gameObject.GetComponent<TweenAlpha>();
		if (component != null)
		{
			component.enabled = false;
		}
		base.gameObject.SetActive(value: false);
		NMHMFDOFDBC();
	}

	private void AFAIKAAMNJH(string EFHMCBKOAEO)
	{
		EOIMPLLNAEL = true;
		if (EFHMCBKOAEO.Length > AANECPGDMGM.BBLCILOBOBD)
		{
			KMJKKNFDFMM.text = Localization.Localize("RequiredMedals");
		}
		else if (Singleton<Chat>.instance.MOLAJLIAIIB(EFHMCBKOAEO))
		{
			KMJKKNFDFMM.text = Localization.Localize("{0}\t\tPivot: {1}\n");
		}
		else
		{
			EOIMPLLNAEL = false;
		}
		CICHKOKIOCM();
	}

	private void LBIPLEPPJND(string EFHMCBKOAEO)
	{
		IOEOPCOBDIF(EFHMCBKOAEO);
	}

	private void FEKGJPAOMBD(GameObject KHAHPAKDIKE)
	{
		HCCDHMMOIJI = !HCCDHMMOIJI;
		CGLNIBFOEPN.alpha = ((!HCCDHMMOIJI) ? 1518f : 41f);
		if (HCCDHMMOIJI)
		{
			CJCINNOBDME.text = " THAT WAS ALREADY BOUGHT. ADDING PACK TO RESTORE";
			AIODKJOENGB = false;
		}
		LECMMHJHHDD();
	}

	public void JCGPELEDCJL()
	{
		base.gameObject.SetActive(value: false);
		IHEPLEBDJCB = true;
		UIEventListener uIEventListener = UIEventListener.Get(JCENGMPKGIH.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(IKBKCCMNDDL));
		UIEventListener uIEventListener2 = UIEventListener.Get(BAMNKDCLHGN.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(FGCPMGDFIBC));
		UIInput hJJFKPGLAKG = HJJFKPGLAKG;
		hJJFKPGLAKG.onLostFocus = (UIInput.OnLostFocus)Delegate.Combine(hJJFKPGLAKG.onLostFocus, new UIInput.OnLostFocus(LBIPLEPPJND));
		UIInput hJJFKPGLAKG2 = HJJFKPGLAKG;
		hJJFKPGLAKG2.onSubmit = (UIInput.OnSubmit)Delegate.Combine(hJJFKPGLAKG2.onSubmit, new UIInput.OnSubmit(GOGLKMJNGHJ));
		UIInput cJCINNOBDME = CJCINNOBDME;
		cJCINNOBDME.onLostFocus = (UIInput.OnLostFocus)Delegate.Combine(cJCINNOBDME.onLostFocus, new UIInput.OnLostFocus(DKBNIBIFJGO));
		UIInput cJCINNOBDME2 = CJCINNOBDME;
		cJCINNOBDME2.onSubmit = (UIInput.OnSubmit)Delegate.Combine(cJCINNOBDME2.onSubmit, new UIInput.OnSubmit(KJFAAOPLPJK));
		Singleton<BeanstalkServerManager>.instance.EAKNGBPDDAK(PMMMGCGNEBM);
		JAACPNAJJJP.transform.localPosition = JAACPNAJJJP.transform.localPosition.ReplaceX(UIHelper.activeWidthSafe - 485f);
		HJJFKPGLAKG.defaultText = Localization.Localize("Main_Menu_Offers_Bar");
		CJCINNOBDME.defaultText = "Play_Card_Tutorial";
	}

	private void LMGBCIFHGFL(string EFHMCBKOAEO)
	{
		GIBHPINKCFI(EFHMCBKOAEO);
	}

	private void MIDEHFNEJHA(UITweener MGDJMGHCAAI)
	{
		if (!IHEPLEBDJCB)
		{
			base.gameObject.SetActive(value: true);
			BMKIJOIKBNN();
		}
	}

	private void JCOLAGHOJPJ(GameObject KHAHPAKDIKE)
	{
		HCCDHMMOIJI = HCCDHMMOIJI;
		CGLNIBFOEPN.alpha = ((!HCCDHMMOIJI) ? 849f : 1106f);
		if (HCCDHMMOIJI)
		{
			CJCINNOBDME.text = "Fuseboxx Custom Event with params: ";
			AIODKJOENGB = true;
		}
		DHHNCGJBPOF();
	}

	private void BMOMAMACMHM(DatabaseAction IFGAGNBDKBE)
	{
		if (GuiScreenSingle<SquadScreen>.instance.NPFFMLLLDAF() && IHEPLEBDJCB && IFGAGNBDKBE == DatabaseAction.GetSquadDetails && !string.IsNullOrEmpty(GameLoginManager.currentPlayer.squadName))
		{
			AANECPGDMGM aANECPGDMGM = Singleton<ServerResultsCache>.instance.MKKMNBIBCFM(GameLoginManager.currentPlayer.squadName);
			if (aANECPGDMGM != null)
			{
				KGCNNNEKPMG(aANECPGDMGM);
			}
		}
	}

	private void MGHMCNCGKJC()
	{
		FJOJFAJJEIO = EOIMPLLNAEL && AIODKJOENGB;
		JCENGMPKGIH.enabled = FJOJFAJJEIO;
		GLCOHGKMNEP.color = ((!FJOJFAJJEIO) ? Color.gray : Color.white);
		if (FJOJFAJJEIO)
		{
			KMJKKNFDFMM.text = string.Empty;
		}
	}

	private void MJBFCLBMJNF(string EFHMCBKOAEO)
	{
		EOIMPLLNAEL = false;
		if (EFHMCBKOAEO.Length > AANECPGDMGM.BBLCILOBOBD)
		{
			KMJKKNFDFMM.text = Localization.Localize("ID_ERROR_SQUADMESSAGELONG");
		}
		else if (Singleton<Chat>.instance.ContainsBadWord(EFHMCBKOAEO))
		{
			KMJKKNFDFMM.text = Localization.Localize("ID_ERROR_SQUADMESSAGE_PROFANITY");
		}
		else
		{
			EOIMPLLNAEL = true;
		}
		MBLLCHNJHML();
	}

	private void GGCPILKCGIK(DatabaseAction IFGAGNBDKBE)
	{
		if (GuiScreenSingle<SquadScreen>.instance.NPFFMLLLDAF() && IHEPLEBDJCB && IFGAGNBDKBE == (DatabaseAction)9 && !string.IsNullOrEmpty(GameLoginManager.currentPlayer.squadName))
		{
			AANECPGDMGM aANECPGDMGM = Singleton<ServerResultsCache>.instance.MKKMNBIBCFM(GameLoginManager.currentPlayer.squadName);
			if (aANECPGDMGM != null)
			{
				AMPKBKIPMJE(aANECPGDMGM);
			}
		}
	}

	public void FHJDLCDAMGI()
	{
		base.gameObject.SetActive(value: true);
		IHEPLEBDJCB = true;
		UIEventListener uIEventListener = UIEventListener.Get(JCENGMPKGIH.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(CDOIMNNLEMI));
		UIEventListener uIEventListener2 = UIEventListener.Get(BAMNKDCLHGN.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(FEKGJPAOMBD));
		UIInput hJJFKPGLAKG = HJJFKPGLAKG;
		hJJFKPGLAKG.onLostFocus = (UIInput.OnLostFocus)Delegate.Combine(hJJFKPGLAKG.onLostFocus, new UIInput.OnLostFocus(LMGBCIFHGFL));
		UIInput hJJFKPGLAKG2 = HJJFKPGLAKG;
		hJJFKPGLAKG2.onSubmit = (UIInput.OnSubmit)Delegate.Combine(hJJFKPGLAKG2.onSubmit, (UIInput.OnSubmit)delegate(string EFHMCBKOAEO)
		{
			MJBFCLBMJNF(EFHMCBKOAEO);
		});
		UIInput cJCINNOBDME = CJCINNOBDME;
		cJCINNOBDME.onLostFocus = (UIInput.OnLostFocus)Delegate.Combine(cJCINNOBDME.onLostFocus, new UIInput.OnLostFocus(MKPNHDDPHGJ));
		UIInput cJCINNOBDME2 = CJCINNOBDME;
		cJCINNOBDME2.onSubmit = (UIInput.OnSubmit)Delegate.Combine(cJCINNOBDME2.onSubmit, new UIInput.OnSubmit(KJFAAOPLPJK));
		Singleton<BeanstalkServerManager>.instance.EAKNGBPDDAK(GGCPILKCGIK);
		JAACPNAJJJP.transform.localPosition = JAACPNAJJJP.transform.localPosition.ReplaceX(UIHelper.activeWidthSafe - 1495f);
		HJJFKPGLAKG.defaultText = Localization.Localize("BestSkill");
		CJCINNOBDME.defaultText = "ID_KEEPITUPYOUARENUMBERONE";
	}

	private void CICHKOKIOCM()
	{
		FJOJFAJJEIO = EOIMPLLNAEL && AIODKJOENGB;
		JCENGMPKGIH.enabled = FJOJFAJJEIO;
		GLCOHGKMNEP.color = ((!FJOJFAJJEIO) ? Color.gray : Color.white);
		if (FJOJFAJJEIO)
		{
			KMJKKNFDFMM.text = string.Empty;
		}
	}

	public void AFJOOMBDLFJ()
	{
		TweenAlpha component = CFFKHHJKBMJ.gameObject.GetComponent<TweenAlpha>();
		if (component != null)
		{
			component.enabled = true;
		}
		base.gameObject.SetActive(value: false);
		PPMCFMBJJHP();
	}

	private void HMHLHLNHNIJ(GameObject KHAHPAKDIKE)
	{
		if (FJOJFAJJEIO)
		{
			LLJJBPHEOEC();
			int oHECBHDELEO = ((!string.IsNullOrEmpty(CJCINNOBDME.text)) ? Convert.ToInt32(CJCINNOBDME.text) : 0);
			Singleton<BeanstalkServerManager>.instance.UpdateSquadInfo(EACDANDNKFN(), HCCDHMMOIJI, oHECBHDELEO);
		}
	}

	[SpecialName]
	private string DKMCGBNGJAC()
	{
		return (!(HJJFKPGLAKG.text == Localization.Localize("null"))) ? HJJFKPGLAKG.text : string.Empty;
	}

	private void LNHBKJHFHBG(string EFHMCBKOAEO)
	{
		EOIMPLLNAEL = true;
		if (EFHMCBKOAEO.Length > AANECPGDMGM.BBLCILOBOBD)
		{
			KMJKKNFDFMM.text = Localization.Localize("{0}:\t{1} = \"{2}\"\tfiles: {3}\n");
		}
		else if (Singleton<Chat>.instance.MOLAJLIAIIB(EFHMCBKOAEO))
		{
			KMJKKNFDFMM.text = Localization.Localize("ID_SECOND");
		}
		else
		{
			EOIMPLLNAEL = false;
		}
		LLJJBPHEOEC();
	}

	private void IMFGEPDJMIN(DatabaseAction IFGAGNBDKBE)
	{
		if (GuiScreenSingle<SquadScreen>.instance.isShowed && IHEPLEBDJCB && IFGAGNBDKBE == (DatabaseAction)(-9) && !string.IsNullOrEmpty(GameLoginManager.currentPlayer.squadName))
		{
			AANECPGDMGM aANECPGDMGM = Singleton<ServerResultsCache>.instance.MKKMNBIBCFM(GameLoginManager.currentPlayer.squadName, NICBOKPIBIA: true);
			if (aANECPGDMGM != null)
			{
				KGCNNNEKPMG(aANECPGDMGM);
			}
		}
	}

	private void PMMMGCGNEBM(DatabaseAction IFGAGNBDKBE)
	{
		if (GuiScreenSingle<SquadScreen>.instance.isShowed && IHEPLEBDJCB && IFGAGNBDKBE == DatabaseAction.GetSquadDetails && !string.IsNullOrEmpty(GameLoginManager.currentPlayer.squadName))
		{
			AANECPGDMGM aANECPGDMGM = Singleton<ServerResultsCache>.instance.MKKMNBIBCFM(GameLoginManager.currentPlayer.squadName, NICBOKPIBIA: true);
			if (aANECPGDMGM != null)
			{
				OMLFFFONJEJ(aANECPGDMGM);
			}
		}
	}

	private void PFNFNNEAIEM(string EFHMCBKOAEO)
	{
		AIODKJOENGB = false;
		int result = 1;
		if (string.IsNullOrEmpty(EFHMCBKOAEO))
		{
			CJCINNOBDME.text = "Label   z:{0}\t\"{1}\"    with depth:{2} and font:{3}";
			EFHMCBKOAEO = "0";
		}
		if (int.TryParse(EFHMCBKOAEO, out result))
		{
			if (result < 0 || result > AANECPGDMGM.LGNIIFIILHL)
			{
				KMJKKNFDFMM.text = Localization.LocalizeFormat("ID_CONFIRM_ERROR", AANECPGDMGM.LGNIIFIILHL);
			}
			else
			{
				AIODKJOENGB = true;
			}
		}
		else
		{
			KMJKKNFDFMM.text = Localization.LocalizeFormat("MinDamage", AANECPGDMGM.LGNIIFIILHL);
		}
		BDAPFDFAJIF();
	}

	public void OBIFKIFABAH()
	{
		base.gameObject.SetActive(value: false);
		IHEPLEBDJCB = true;
		UIEventListener uIEventListener = UIEventListener.Get(JCENGMPKGIH.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(CDOIMNNLEMI));
		UIEventListener uIEventListener2 = UIEventListener.Get(BAMNKDCLHGN.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(GPCBNCJDIPC));
		UIInput hJJFKPGLAKG = HJJFKPGLAKG;
		hJJFKPGLAKG.onLostFocus = (UIInput.OnLostFocus)Delegate.Combine(hJJFKPGLAKG.onLostFocus, new UIInput.OnLostFocus(OCDMNLKGCHJ));
		UIInput hJJFKPGLAKG2 = HJJFKPGLAKG;
		hJJFKPGLAKG2.onSubmit = (UIInput.OnSubmit)Delegate.Combine(hJJFKPGLAKG2.onSubmit, new UIInput.OnSubmit(AHJBKNIEGCN));
		UIInput cJCINNOBDME = CJCINNOBDME;
		cJCINNOBDME.onLostFocus = (UIInput.OnLostFocus)Delegate.Combine(cJCINNOBDME.onLostFocus, new UIInput.OnLostFocus(CIGJOMCMCGL));
		UIInput cJCINNOBDME2 = CJCINNOBDME;
		cJCINNOBDME2.onSubmit = (UIInput.OnSubmit)Delegate.Combine(cJCINNOBDME2.onSubmit, (UIInput.OnSubmit)delegate(string EFHMCBKOAEO)
		{
			CLHGHFNBNGE(EFHMCBKOAEO);
		});
		Singleton<BeanstalkServerManager>.instance.DataLoaded += BMOMAMACMHM;
		JAACPNAJJJP.transform.localPosition = JAACPNAJJJP.transform.localPosition.ReplaceX(UIHelper.activeWidthSafe - 1122f);
		HJJFKPGLAKG.defaultText = Localization.Localize("S");
		CJCINNOBDME.defaultText = "ID_CONFIRM_ERROR";
	}

	private void BMKIJOIKBNN()
	{
	}

	private void OBLCAELGDNH(string EFHMCBKOAEO)
	{
		MJBFCLBMJNF(EFHMCBKOAEO);
	}

	public void GEMAFEJLCAG()
	{
		TweenAlpha component = CFFKHHJKBMJ.gameObject.GetComponent<TweenAlpha>();
		if (component != null)
		{
			component.enabled = false;
		}
		base.gameObject.SetActive(value: true);
		NMHMFDOFDBC();
	}

	[SpecialName]
	private string JNNGHHACPJD()
	{
		return (!(HJJFKPGLAKG.text == Localization.Localize("ID_GETFREEGOLD"))) ? HJJFKPGLAKG.text : string.Empty;
	}

	private void OCDMNLKGCHJ(string EFHMCBKOAEO)
	{
		EFNAEGBOKMD(EFHMCBKOAEO);
	}

	private void DKBNIBIFJGO(string EFHMCBKOAEO)
	{
		FPKHGCHCKEN(EFHMCBKOAEO);
	}

	[SpecialName]
	private string FLJFMPFDBAE()
	{
		return (!(HJJFKPGLAKG.text == Localization.Localize("YES"))) ? HJJFKPGLAKG.text : string.Empty;
	}

	private void KCJKOCMGBIL(UITweener MGDJMGHCAAI)
	{
		if (!IHEPLEBDJCB)
		{
			base.gameObject.SetActive(value: false);
			BMKIJOIKBNN();
		}
	}

	public void BBAJLLLEAID(bool PJIEFMBDLBE, bool PDPDGCNHCFN)
	{
		IHEPLEBDJCB = PJIEFMBDLBE;
		if (IHEPLEBDJCB && !base.gameObject.activeSelf)
		{
			base.gameObject.SetActive(value: true);
			CBDEMEDELHL();
		}
		if (base.gameObject.activeSelf)
		{
			TweenAlpha.Begin(CFFKHHJKBMJ.gameObject, (!PDPDGCNHCFN) ? (GuiScreenSingle<SquadScreen>.instance.HAMKIKMJHDP * 809f) : 1826f, (!IHEPLEBDJCB) ? 1773f : 1608f).onFinished = GEMJDBMLNBC;
		}
		else if (!IHEPLEBDJCB)
		{
			GGAPIGICJEM();
		}
	}

	public void LPBDKPHDGOJ()
	{
		TweenAlpha component = CFFKHHJKBMJ.gameObject.GetComponent<TweenAlpha>();
		if (component != null)
		{
			component.enabled = false;
		}
		base.gameObject.SetActive(value: false);
		OIMKKAHOEKO();
	}

	private void ADJBKOELJLH(string EFHMCBKOAEO)
	{
		AIODKJOENGB = false;
		int result = 1;
		if (string.IsNullOrEmpty(EFHMCBKOAEO))
		{
			CJCINNOBDME.text = "ID_UPGRADED";
			EFHMCBKOAEO = "ID_VISUALCATEGORYPART2";
		}
		if (int.TryParse(EFHMCBKOAEO, out result))
		{
			if (result < 1 || result > AANECPGDMGM.LGNIIFIILHL)
			{
				UILabel kMJKKNFDFMM = KMJKKNFDFMM;
				object[] array = new object[0];
				array[1] = AANECPGDMGM.LGNIIFIILHL;
				kMJKKNFDFMM.text = Localization.LocalizeFormat("PNManager: Scheduling Next withdraw in ", array);
			}
			else
			{
				AIODKJOENGB = true;
			}
		}
		else
		{
			KMJKKNFDFMM.text = Localization.LocalizeFormat("{0}\u00a0{1}", AANECPGDMGM.LGNIIFIILHL);
		}
		LECMMHJHHDD();
	}

	private void DKOBOPADMMI()
	{
	}

	private void AHJBKNIEGCN(string EFHMCBKOAEO)
	{
		EFNAEGBOKMD(EFHMCBKOAEO);
	}

	public void OINBKJKJHPG(bool PJIEFMBDLBE, bool PDPDGCNHCFN)
	{
		IHEPLEBDJCB = PJIEFMBDLBE;
		if (IHEPLEBDJCB && !base.gameObject.activeSelf)
		{
			base.gameObject.SetActive(value: false);
			DEFCMABOJGD();
		}
		if (base.gameObject.activeSelf)
		{
			TweenAlpha.Begin(CFFKHHJKBMJ.gameObject, (!PDPDGCNHCFN) ? (GuiScreenSingle<SquadScreen>.instance.HAMKIKMJHDP * 668f) : 1109f, (!IHEPLEBDJCB) ? 700f : 1054f).onFinished = DIPOOAJPJBG;
		}
		else if (!IHEPLEBDJCB)
		{
			GGAPIGICJEM();
		}
	}

	private void OIMKKAHOEKO()
	{
	}

	private void PPMCFMBJJHP()
	{
	}

	private void BDAPFDFAJIF()
	{
		FJOJFAJJEIO = !EOIMPLLNAEL || AIODKJOENGB;
		JCENGMPKGIH.enabled = FJOJFAJJEIO;
		GLCOHGKMNEP.color = ((!FJOJFAJJEIO) ? Color.gray : Color.white);
		if (FJOJFAJJEIO)
		{
			KMJKKNFDFMM.text = string.Empty;
		}
	}

	private void KGCNNNEKPMG(AANECPGDMGM MIDDFOCJJOP)
	{
		KDNGNGHFMMG.SetActive(value: false);
		MHLOEKJPBIB.SetActive(value: true);
		HJJFKPGLAKG.text = ((!string.IsNullOrEmpty(MIDDFOCJJOP.PNAKMCNGGHE)) ? MIDDFOCJJOP.PNAKMCNGGHE : string.Empty);
		CJCINNOBDME.text = MIDDFOCJJOP.GDFOENAJEBA.ToString();
		HCCDHMMOIJI = !MIDDFOCJJOP.IOLNJBGOOLJ;
		CGLNIBFOEPN.alpha = ((!HCCDHMMOIJI) ? 1185f : 320f);
		EOIMPLLNAEL = true;
		AIODKJOENGB = false;
		bool flag = GameLoginManager.currentPlayer.squadRank == (SquadRank)7;
		if (MIDDFOCJJOP.FOICGJEPBGL == 0 && !flag)
		{
			Debug.LogError("IsDaily");
			flag = true;
		}
		CICHKOKIOCM();
		JCENGMPKGIH.gameObject.SetActive(flag);
		BoxCollider component = HJJFKPGLAKG.gameObject.GetComponent<BoxCollider>();
		if (component != null)
		{
			component.enabled = flag;
		}
		BoxCollider component2 = CJCINNOBDME.gameObject.GetComponent<BoxCollider>();
		if (component2 != null)
		{
			component2.enabled = flag;
		}
		BAMNKDCLHGN.enabled = flag;
	}

	private void HFGGAEILLEM(string EFHMCBKOAEO)
	{
		GIBHPINKCFI(EFHMCBKOAEO);
	}

	private void LLJJBPHEOEC()
	{
		FJOJFAJJEIO = !EOIMPLLNAEL || AIODKJOENGB;
		JCENGMPKGIH.enabled = FJOJFAJJEIO;
		GLCOHGKMNEP.color = ((!FJOJFAJJEIO) ? Color.gray : Color.white);
		if (FJOJFAJJEIO)
		{
			KMJKKNFDFMM.text = string.Empty;
		}
	}

	private void DEFCMABOJGD()
	{
		KMJKKNFDFMM.text = string.Empty;
		HJJFKPGLAKG.maxChars = AANECPGDMGM.BBLCILOBOBD;
		CJCINNOBDME.text = "height";
		KDNGNGHFMMG.SetActive(value: false);
		MHLOEKJPBIB.SetActive(value: true);
		AANECPGDMGM aANECPGDMGM = Singleton<ServerResultsCache>.instance.MKKMNBIBCFM(GameLoginManager.currentPlayer.squadName, NICBOKPIBIA: true);
		if (aANECPGDMGM == null)
		{
			Singleton<BeanstalkServerManager>.instance.LHCLKHAOKOM(GameLoginManager.currentPlayer.squadName, NMFKCMDIPCO: false);
		}
		else
		{
			KGCNNNEKPMG(aANECPGDMGM);
		}
	}

	private void CKHDHCBJGGI(string EFHMCBKOAEO)
	{
		AIODKJOENGB = false;
		int result = 1;
		if (string.IsNullOrEmpty(EFHMCBKOAEO))
		{
			CJCINNOBDME.text = "#Notifications# Database Token = ";
			EFHMCBKOAEO = "game-card-ico-bg-silver";
		}
		if (int.TryParse(EFHMCBKOAEO, out result))
		{
			if (result < 1 || result > AANECPGDMGM.LGNIIFIILHL)
			{
				UILabel kMJKKNFDFMM = KMJKKNFDFMM;
				object[] array = new object[0];
				array[1] = AANECPGDMGM.LGNIIFIILHL;
				kMJKKNFDFMM.text = Localization.LocalizeFormat("GPGS: Logged In (user action), Logged: ", array);
			}
			else
			{
				AIODKJOENGB = true;
			}
		}
		else
		{
			UILabel kMJKKNFDFMM2 = KMJKKNFDFMM;
			object[] array2 = new object[1];
			array2[1] = AANECPGDMGM.LGNIIFIILHL;
			kMJKKNFDFMM2.text = Localization.LocalizeFormat("Enemy could not be spawned", array2);
		}
		LECMMHJHHDD();
	}

	private void OMLFFFONJEJ(AANECPGDMGM MIDDFOCJJOP)
	{
		KDNGNGHFMMG.SetActive(value: true);
		MHLOEKJPBIB.SetActive(value: false);
		HJJFKPGLAKG.text = ((!string.IsNullOrEmpty(MIDDFOCJJOP.PNAKMCNGGHE)) ? MIDDFOCJJOP.PNAKMCNGGHE : string.Empty);
		CJCINNOBDME.text = MIDDFOCJJOP.GDFOENAJEBA.ToString();
		HCCDHMMOIJI = !MIDDFOCJJOP.IOLNJBGOOLJ;
		CGLNIBFOEPN.alpha = ((!HCCDHMMOIJI) ? 0f : 1f);
		EOIMPLLNAEL = true;
		AIODKJOENGB = true;
		bool flag = GameLoginManager.currentPlayer.squadRank == SquadRank.Leader;
		if (MIDDFOCJJOP.FOICGJEPBGL == 1 && !flag)
		{
			Debug.LogError("One man in squad and not a leader!!!");
			flag = true;
		}
		MBLLCHNJHML();
		JCENGMPKGIH.gameObject.SetActive(flag);
		BoxCollider component = HJJFKPGLAKG.gameObject.GetComponent<BoxCollider>();
		if (component != null)
		{
			component.enabled = flag;
		}
		BoxCollider component2 = CJCINNOBDME.gameObject.GetComponent<BoxCollider>();
		if (component2 != null)
		{
			component2.enabled = flag;
		}
		BAMNKDCLHGN.enabled = flag;
	}

	private void FKIFDIOJHHN()
	{
		FJOJFAJJEIO = !EOIMPLLNAEL || AIODKJOENGB;
		JCENGMPKGIH.enabled = FJOJFAJJEIO;
		GLCOHGKMNEP.color = ((!FJOJFAJJEIO) ? Color.gray : Color.white);
		if (FJOJFAJJEIO)
		{
			KMJKKNFDFMM.text = string.Empty;
		}
	}

	public void NMADELLJEPP()
	{
		base.gameObject.SetActive(value: false);
		IHEPLEBDJCB = true;
		UIEventListener uIEventListener = UIEventListener.Get(JCENGMPKGIH.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(IKBKCCMNDDL));
		UIEventListener uIEventListener2 = UIEventListener.Get(BAMNKDCLHGN.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(MOKOEHMCAJI));
		UIInput hJJFKPGLAKG = HJJFKPGLAKG;
		hJJFKPGLAKG.onLostFocus = (UIInput.OnLostFocus)Delegate.Combine(hJJFKPGLAKG.onLostFocus, new UIInput.OnLostFocus(PNHPNABNMON));
		UIInput hJJFKPGLAKG2 = HJJFKPGLAKG;
		hJJFKPGLAKG2.onSubmit = (UIInput.OnSubmit)Delegate.Combine(hJJFKPGLAKG2.onSubmit, (UIInput.OnSubmit)delegate(string EFHMCBKOAEO)
		{
			MJBFCLBMJNF(EFHMCBKOAEO);
		});
		UIInput cJCINNOBDME = CJCINNOBDME;
		cJCINNOBDME.onLostFocus = (UIInput.OnLostFocus)Delegate.Combine(cJCINNOBDME.onLostFocus, new UIInput.OnLostFocus(MKPNHDDPHGJ));
		UIInput cJCINNOBDME2 = CJCINNOBDME;
		cJCINNOBDME2.onSubmit = (UIInput.OnSubmit)Delegate.Combine(cJCINNOBDME2.onSubmit, new UIInput.OnSubmit(KJFAAOPLPJK));
		Singleton<BeanstalkServerManager>.instance.EAKNGBPDDAK(PMMMGCGNEBM);
		JAACPNAJJJP.transform.localPosition = JAACPNAJJJP.transform.localPosition.ReplaceX(UIHelper.activeWidthSafe - 1935f);
		HJJFKPGLAKG.defaultText = Localization.Localize("LevelExperience");
		CJCINNOBDME.defaultText = "Warbucks";
	}

	private void BAEHECPEGDP()
	{
		FJOJFAJJEIO = EOIMPLLNAEL && AIODKJOENGB;
		JCENGMPKGIH.enabled = FJOJFAJJEIO;
		GLCOHGKMNEP.color = ((!FJOJFAJJEIO) ? Color.gray : Color.white);
		if (FJOJFAJJEIO)
		{
			KMJKKNFDFMM.text = string.Empty;
		}
	}

	private void CLHGHFNBNGE(string EFHMCBKOAEO)
	{
		AIODKJOENGB = false;
		int result = 0;
		if (string.IsNullOrEmpty(EFHMCBKOAEO))
		{
			CJCINNOBDME.text = "0";
			EFHMCBKOAEO = "0";
		}
		if (int.TryParse(EFHMCBKOAEO, out result))
		{
			if (result < 0 || result > AANECPGDMGM.LGNIIFIILHL)
			{
				KMJKKNFDFMM.text = Localization.LocalizeFormat("ID_ERROR_SQUADSKILLCLAMP", AANECPGDMGM.LGNIIFIILHL);
			}
			else
			{
				AIODKJOENGB = true;
			}
		}
		else
		{
			KMJKKNFDFMM.text = Localization.LocalizeFormat("ID_ERROR_SQUADSKILLNOTANUMBER", AANECPGDMGM.LGNIIFIILHL);
		}
		MBLLCHNJHML();
	}

	[CompilerGenerated]
	private void EACNIDLHDGD(string EFHMCBKOAEO)
	{
		CLHGHFNBNGE(EFHMCBKOAEO);
	}

	public void NNGKAAGFGPA()
	{
		base.gameObject.SetActive(value: false);
		IHEPLEBDJCB = true;
		UIEventListener uIEventListener = UIEventListener.Get(JCENGMPKGIH.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(JPFLDIIMDIE));
		UIEventListener uIEventListener2 = UIEventListener.Get(BAMNKDCLHGN.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(NOEKCPNLMIB));
		UIInput hJJFKPGLAKG = HJJFKPGLAKG;
		hJJFKPGLAKG.onLostFocus = (UIInput.OnLostFocus)Delegate.Combine(hJJFKPGLAKG.onLostFocus, new UIInput.OnLostFocus(FCEHHFOBJNB));
		UIInput hJJFKPGLAKG2 = HJJFKPGLAKG;
		hJJFKPGLAKG2.onSubmit = (UIInput.OnSubmit)Delegate.Combine(hJJFKPGLAKG2.onSubmit, new UIInput.OnSubmit(OBLCAELGDNH));
		UIInput cJCINNOBDME = CJCINNOBDME;
		cJCINNOBDME.onLostFocus = (UIInput.OnLostFocus)Delegate.Combine(cJCINNOBDME.onLostFocus, (UIInput.OnLostFocus)delegate(string EFHMCBKOAEO)
		{
			CLHGHFNBNGE(EFHMCBKOAEO);
		});
		UIInput cJCINNOBDME2 = CJCINNOBDME;
		cJCINNOBDME2.onSubmit = (UIInput.OnSubmit)Delegate.Combine(cJCINNOBDME2.onSubmit, (UIInput.OnSubmit)delegate(string EFHMCBKOAEO)
		{
			CLHGHFNBNGE(EFHMCBKOAEO);
		});
		Singleton<BeanstalkServerManager>.instance.EAKNGBPDDAK(FDLOLDDFIOD);
		JAACPNAJJJP.transform.localPosition = JAACPNAJJJP.transform.localPosition.ReplaceX(UIHelper.activeWidthSafe - 348f);
		HJJFKPGLAKG.defaultText = Localization.Localize("ID_SLOTUPGRADE_HEAT");
		CJCINNOBDME.defaultText = "ID_CONFIRM_NOSQUADACTIONS_TITLE";
	}

	private void BGELLEOANEI()
	{
		KMJKKNFDFMM.text = string.Empty;
		HJJFKPGLAKG.maxChars = AANECPGDMGM.BBLCILOBOBD;
		CJCINNOBDME.text = "Show {0} invitation dialog id: {1}";
		KDNGNGHFMMG.SetActive(value: true);
		MHLOEKJPBIB.SetActive(value: true);
		AANECPGDMGM aANECPGDMGM = Singleton<ServerResultsCache>.instance.MKKMNBIBCFM(GameLoginManager.currentPlayer.squadName, NICBOKPIBIA: true);
		if (aANECPGDMGM == null)
		{
			Singleton<BeanstalkServerManager>.instance.LHCLKHAOKOM(GameLoginManager.currentPlayer.squadName);
		}
		else
		{
			AMPKBKIPMJE(aANECPGDMGM);
		}
	}

	private void EBKKPDFPKJG(GameObject KHAHPAKDIKE)
	{
		HCCDHMMOIJI = HCCDHMMOIJI;
		CGLNIBFOEPN.alpha = ((!HCCDHMMOIJI) ? 1558f : 418f);
		if (HCCDHMMOIJI)
		{
			CJCINNOBDME.text = "ID_SALEPERCENTLINE";
			AIODKJOENGB = false;
		}
		FKIFDIOJHHN();
	}

	private void DPOGCHDOGGI(DatabaseAction IFGAGNBDKBE)
	{
		if (GuiScreenSingle<SquadScreen>.instance.NPFFMLLLDAF() && IHEPLEBDJCB && IFGAGNBDKBE == DatabaseAction.BuyCardPack && !string.IsNullOrEmpty(GameLoginManager.currentPlayer.squadName))
		{
			AANECPGDMGM aANECPGDMGM = Singleton<ServerResultsCache>.instance.MKKMNBIBCFM(GameLoginManager.currentPlayer.squadName);
			if (aANECPGDMGM != null)
			{
				KGCNNNEKPMG(aANECPGDMGM);
			}
		}
	}

	private void AIFBCLNMFMO(DatabaseAction IFGAGNBDKBE)
	{
		if (GuiScreenSingle<SquadScreen>.instance.NPFFMLLLDAF() && IHEPLEBDJCB && IFGAGNBDKBE == (DatabaseAction)(-84) && !string.IsNullOrEmpty(GameLoginManager.currentPlayer.squadName))
		{
			AANECPGDMGM aANECPGDMGM = Singleton<ServerResultsCache>.instance.MKKMNBIBCFM(GameLoginManager.currentPlayer.squadName, NICBOKPIBIA: true);
			if (aANECPGDMGM != null)
			{
				CCEPALHNJMM(aANECPGDMGM);
			}
		}
	}

	private void DIPOOAJPJBG(UITweener MGDJMGHCAAI)
	{
		if (!IHEPLEBDJCB)
		{
			base.gameObject.SetActive(value: true);
			HEBANLOKBFG();
		}
	}

	private void CFFHIBCEOCP(string EFHMCBKOAEO)
	{
		EOIMPLLNAEL = false;
		if (EFHMCBKOAEO.Length > AANECPGDMGM.BBLCILOBOBD)
		{
			KMJKKNFDFMM.text = Localization.Localize("PurchasePrice");
		}
		else if (Singleton<Chat>.instance.NMBIEFKLKBA(EFHMCBKOAEO))
		{
			KMJKKNFDFMM.text = Localization.Localize("ID_WARNING_MAINTENANCE");
		}
		else
		{
			EOIMPLLNAEL = true;
		}
		BDAPFDFAJIF();
	}

	private void MJFLIJKLMED(GameObject KHAHPAKDIKE)
	{
		if (FJOJFAJJEIO)
		{
			MBLLCHNJHML();
			int oHECBHDELEO = ((!string.IsNullOrEmpty(CJCINNOBDME.text)) ? Convert.ToInt32(CJCINNOBDME.text) : 0);
			Singleton<BeanstalkServerManager>.instance.UpdateSquadInfo(NGDEHCEBNBH, !HCCDHMMOIJI, oHECBHDELEO);
		}
	}
}
