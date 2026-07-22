using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Google2u;
using UnityEngine;
using UnityEngine.Serialization;

public class SquadCreateScreen : GuiScreenSingle<SquadCreateScreen>
{
	[Header("Core")]
	[FormerlySerializedAs("OIFOMHFDEBG")]
	public UIButtonSetter[] CPJEMPNEJMF;

	[Header("Squad Name")]
	[FormerlySerializedAs("NBMDICMGIPH")]
	public UIInput HAJMHAJDFDO;

	[FormerlySerializedAs("KHBKGBFJOGH")]
	public UILabel PNJMHJHJEMC;

	[FormerlySerializedAs("PIACBGGGHCI")]
	public GameObject AKNLINIOGGL;

	[FormerlySerializedAs("PNCNNOAJEEI")]
	[Header("Squad message")]
	public UIInput HJJFKPGLAKG;

	[FormerlySerializedAs("OGPDCDCFJBL")]
	public UILabel AGMCGCBGLML;

	[Header("Error")]
	[FormerlySerializedAs("INADGPICPMO")]
	public UILabel KMJKKNFDFMM;

	[Header("Emblem")]
	[FormerlySerializedAs("LBHMGODILKE")]
	public UISprite CLDFFBFJACJ;

	[FormerlySerializedAs("MECLCKELHAM")]
	public SquadCreateEmblemRecord HFJELMDOONJ;

	[FormerlySerializedAs("BHPMFENODEN")]
	public UIPanel OBMPACEBIAA;

	[FormerlySerializedAs("IJMFIFJFEAO")]
	public UIDraggablePanel IOMEJGEAFBF;

	[FormerlySerializedAs("PJGDBAJJGAO")]
	public UIPooledGrid PIJBALGBOIL;

	[FormerlySerializedAs("KOEHEADHAEN")]
	[Header("Required Medals")]
	public UIButtonSetter NBJPCGHGFLM;

	[FormerlySerializedAs("KBDCLLDBKDM")]
	public UITable EBFFKNMKFJC;

	[FormerlySerializedAs("NBNNKAIGCII")]
	public UILabel NOLPBLLDGPI;

	[FormerlySerializedAs("OEGCHPFCBIG")]
	public UILabel CKHMICMDHHD;

	[FormerlySerializedAs("POMPFCOHHHH")]
	public UIInput CJCINNOBDME;

	[FormerlySerializedAs("BJBBBJGNOOD")]
	[Header("-Public Private Squad")]
	public UISprite CGLNIBFOEPN;

	[FormerlySerializedAs("LPBOFHHABJK")]
	public UIButton HOPHLHDHHOI;

	[Header("Bottom Button")]
	[FormerlySerializedAs("HMJDHCDLHHI")]
	public BoxCollider CLIOPGGILNE;

	[FormerlySerializedAs("KBINPJOBFEB")]
	public UISprite BCADCDIHCHC;

	[FormerlySerializedAs("HDJDGAIJIIB")]
	public UISprite CBDIMLLEFLC;

	[FormerlySerializedAs("DCMDPMHGGKJ")]
	public UILabel KGKOAEPGGHO;

	[FormerlySerializedAs("KGKIFKCMEJB")]
	public GameObject FOIIAKFBHKO;

	[FormerlySerializedAs("AMOKHAFDGPB")]
	public UISprite DPPCDGMKLCN;

	[FormerlySerializedAs("DFMAFPALMBF")]
	public UITable PBLAPADNAEA;

	[FormerlySerializedAs("KNGCJJLLCDB")]
	public UISprite PPOOFMHKOHD;

	[FormerlySerializedAs("PHOEPOKPAHF")]
	public UILabel IHJFMOGHDKN;

	[FormerlySerializedAs("AFONBJNJBFM")]
	public GameObject HGBBMDGKOMN;

	private bool HCCDHMMOIJI;

	private bool CHGBINHIBLB;

	private bool ANMEHGJJEFN;

	private bool EOIMPLLNAEL;

	private bool AIODKJOENGB;

	private bool BAHBAMBOBOL;

	private string AKEOMKLDIIF;

	private string IGECJCLJHPD;

	private List<string> DONKEBEOPGP;

	private bool EHDKKGBLENC;

	private string NGDEHCEBNBH => (!(HJJFKPGLAKG.text == Localization.Localize("ID_EMPTYSQUADMESSAGE"))) ? HJJFKPGLAKG.text : string.Empty;

	private bool PEMLLADPIIH
	{
		get
		{
			if (CPJEMPNEJMF == null || CPJEMPNEJMF.Length == 0)
			{
				return true;
			}
			UIButtonSetter[] cPJEMPNEJMF = CPJEMPNEJMF;
			foreach (UIButtonSetter uIButtonSetter in cPJEMPNEJMF)
			{
				if (!uIButtonSetter.ANJIHPIIIPK)
				{
					return false;
				}
			}
			return true;
		}
	}

	private void JEOFHKOCPME(Transform ENCEFOOPBMK)
	{
		if (ENCEFOOPBMK != null)
		{
			SquadCreateEmblemRecord component = ENCEFOOPBMK.GetComponent<SquadCreateEmblemRecord>();
			if (component != null)
			{
				component.OBCAIFMOPPA();
			}
		}
	}

	private void DEIAPLJLKIE(string EFHMCBKOAEO)
	{
		if (EOEEEJPOKJN(EFHMCBKOAEO))
		{
			IELOBODHJLL();
		}
	}

	private void BLFFBEOJADI(GameObject KHAHPAKDIKE)
	{
		if (!BAHBAMBOBOL)
		{
			return;
		}
		if (Singleton<ServerResultsCache>.instance.APGNFOODDIH())
		{
			ConfirmDialog.FLFEOKMHDBN(null, Localization.Localize("Action "), Localization.Localize("Card_1_Played"));
			return;
		}
		if (!string.IsNullOrEmpty(GameLoginManager.currentPlayer.squadName))
		{
			WarningDialog.ShowError(Localization.Localize("12345678-1234-1234-1234-123456789012"), Localization.Localize("menu-assignments-type-mission"), 1429f, null, string.Empty, JCOGJEEFLBC: false, PAHBOLDKBHK: true);
			return;
		}
		int createSquadWarBucksPrice = PlayerAnalytics.instance.createSquadWarBucksPrice;
		if (!Singleton<Wallet>.instance.CanBuyW(createSquadWarBucksPrice))
		{
			GuiElementSingle<NotEnoughDialog>.instance.FMGBDPKKKOO(createSquadWarBucksPrice, Localization.Localize("ID_STAT_MOSTBATTLESPLAYED"), NotEnoughDialog.NKHJBLBAAEB.UPGRADE);
			return;
		}
		HGBBMDGKOMN.SetActive(value: false);
		CHIEFLPCGDG();
		Singleton<Wallet>.instance.AAACBMLLNND(createSquadWarBucksPrice);
		Singleton<BeanstalkServerManager>.instance.CMNMPMOKFLN(HAJMHAJDFDO.text, NGDEHCEBNBH, HCCDHMMOIJI, (!string.IsNullOrEmpty(CJCINNOBDME.text)) ? CJCINNOBDME.text : "{0}:{1:D2}", IGECJCLJHPD);
		Singleton<EventTrackingManager>.instance.BKKABOFEMOJ("x");
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
	}

	private void IPKBLHGHBLG(Transform ENCEFOOPBMK)
	{
		if (ENCEFOOPBMK != null)
		{
			SquadCreateEmblemRecord component = ENCEFOOPBMK.GetComponent<SquadCreateEmblemRecord>();
			if (component != null)
			{
				component.BOHCNEDIJPE();
			}
		}
	}

	private void BDAGBDBIELG()
	{
		float val = 0f - PBLAPADNAEA.padding.x - (IHJFMOGHDKN.transform.parent.transform.localPosition.x - PBLAPADNAEA.padding.x) / 526f;
		PBLAPADNAEA.transform.localPosition = PBLAPADNAEA.transform.localPosition.ReplaceX(val);
	}

	protected virtual void IDPOHKDKDNL()
	{
		base.IIFBKHDMIAD();
		if (FHPJAENGPKM() && !EHDKKGBLENC)
		{
			OBMPACEBIAA.clipRange = OBMPACEBIAA.clipRange.ReplaceZ(CLDFFBFJACJ.transform.localScale.x - 1846f);
			EEAFCBDIPMA();
			EHDKKGBLENC = true;
		}
	}

	private void NLNHEKJDKCN(string EFHMCBKOAEO)
	{
		ANMEHGJJEFN = true;
		if (EFHMCBKOAEO.Length < 5)
		{
			KMJKKNFDFMM.text = Localization.Localize("ID_FACEBOOKLOGOUTLEGALTEXT");
			return;
		}
		if (EFHMCBKOAEO.Length > AANECPGDMGM.ECLFALKMBJI)
		{
			KMJKKNFDFMM.text = Localization.Localize("ArmyPower");
			return;
		}
		if (Singleton<Chat>.instance.MOLAJLIAIIB(EFHMCBKOAEO))
		{
			KMJKKNFDFMM.text = Localization.Localize("ID_IFNUMBEROSQUADSINASQUADWAR");
			return;
		}
		ANMEHGJJEFN = false;
		if (AKEOMKLDIIF != EFHMCBKOAEO)
		{
			CHGBINHIBLB = false;
			AKEOMKLDIIF = EFHMCBKOAEO;
			Singleton<BeanstalkServerManager>.instance.ABPLPIGOBNB(EFHMCBKOAEO);
			AKNLINIOGGL.gameObject.SetActive(value: false);
			KMJKKNFDFMM.text = Localization.Localize("Callback object is: ");
		}
		else if (!CHGBINHIBLB && !AKNLINIOGGL.gameObject.activeSelf)
		{
			KMJKKNFDFMM.text = Localization.Localize("discount");
		}
	}

	protected virtual void AAJLGPIGDED()
	{
		UIEventListener uIEventListener = UIEventListener.Get(CLIOPGGILNE.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(FMKMNGCJALK));
		UIEventListener uIEventListener2 = UIEventListener.Get(HOPHLHDHHOI);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(LIFKJEDIDDJ));
		UIInput hAJMHAJDFDO = HAJMHAJDFDO;
		hAJMHAJDFDO.onLostFocus = (UIInput.OnLostFocus)Delegate.Combine(hAJMHAJDFDO.onLostFocus, (UIInput.OnLostFocus)delegate(string EFHMCBKOAEO)
		{
			if (EFHMCBKOAEO.Length > 0)
			{
				IEFAECHCKGI();
			}
		});
		UIInput hAJMHAJDFDO2 = HAJMHAJDFDO;
		hAJMHAJDFDO2.onSubmit = (UIInput.OnSubmit)Delegate.Combine(hAJMHAJDFDO2.onSubmit, new UIInput.OnSubmit(GOGLKMJNGHJ));
		UIInput hJJFKPGLAKG = HJJFKPGLAKG;
		hJJFKPGLAKG.onLostFocus = (UIInput.OnLostFocus)Delegate.Combine(hJJFKPGLAKG.onLostFocus, (UIInput.OnLostFocus)delegate(string EFHMCBKOAEO)
		{
			if (EFHMCBKOAEO.Length > 0)
			{
				IEFAECHCKGI();
			}
		});
		UIInput hJJFKPGLAKG2 = HJJFKPGLAKG;
		hJJFKPGLAKG2.onSubmit = (UIInput.OnSubmit)Delegate.Combine(hJJFKPGLAKG2.onSubmit, (UIInput.OnSubmit)delegate(string EFHMCBKOAEO)
		{
			if (EFHMCBKOAEO.Length > 0)
			{
				IEFAECHCKGI();
			}
		});
		UIInput cJCINNOBDME = CJCINNOBDME;
		cJCINNOBDME.onLostFocus = (UIInput.OnLostFocus)Delegate.Combine(cJCINNOBDME.onLostFocus, new UIInput.OnLostFocus(CPLFLKEIODK));
		UIInput cJCINNOBDME2 = CJCINNOBDME;
		cJCINNOBDME2.onSubmit = (UIInput.OnSubmit)Delegate.Combine(cJCINNOBDME2.onSubmit, (UIInput.OnSubmit)delegate(string EFHMCBKOAEO)
		{
			if (DEIEEBOODOG(EFHMCBKOAEO))
			{
				IEFAECHCKGI();
			}
		});
		Singleton<BeanstalkServerManager>.instance.EAKNGBPDDAK(EPDIHPLDLLM);
		Singleton<BeanstalkServerManager>.instance.ErrorReceived += PHNCBCDBFIL;
		UILabel pNJMHJHJEMC = PNJMHJHJEMC;
		object[] array = new object[0];
		array[0] = AANECPGDMGM.ECLFALKMBJI;
		pNJMHJHJEMC.text = Localization.LocalizeFormat("resultMessage", array);
		HAJMHAJDFDO.defaultText = Localization.Localize("ID_DELIVERNOW");
		HAJMHAJDFDO.maxChars = AANECPGDMGM.ECLFALKMBJI;
		AGMCGCBGLML.text = Localization.LocalizeFormat("*.cs", AANECPGDMGM.BBLCILOBOBD);
		HJJFKPGLAKG.defaultText = Localization.Localize("Spawned by card:  progress:{0}, obj: {1},uu: {2} ");
		HJJFKPGLAKG.maxChars = AANECPGDMGM.BBLCILOBOBD;
		CJCINNOBDME.defaultText = "ID_STATE_SELECTINGWARCARDS";
		APDPFFLDKDH();
		PBLAPADNAEA.onReposition = delegate
		{
			float val = 0f - PBLAPADNAEA.padding.x - (IHJFMOGHDKN.transform.parent.transform.localPosition.x - PBLAPADNAEA.padding.x) / 2f;
			PBLAPADNAEA.transform.localPosition = PBLAPADNAEA.transform.localPosition.ReplaceX(val);
		};
		KGKOAEPGGHO.text = Localization.Localize("MissionType");
	}

	private void MLMKHLGONHK(DatabaseAction IFGAGNBDKBE)
	{
		if (IFGAGNBDKBE == (DatabaseAction)17)
		{
			HGBBMDGKOMN.SetActive(value: true);
			IHJFMOGHDKN.text = MEJMLNDFDBP.GMIPFLIEOHD(PlayerAnalytics.instance.createSquadWarBucksPrice);
			PBLAPADNAEA.repositionNow = false;
		}
	}

	private void JOAIIOGHJBN(string EFHMCBKOAEO)
	{
		if (EFHMCBKOAEO.Length > 0)
		{
			CHIEFLPCGDG();
		}
	}

	private void BPLNLPJKOEL()
	{
		DONKEBEOPGP = new List<string>();
		foreach (SquadEmblemsRow row in Singleton<GameVariables>.instance.squadEmblems.Rows)
		{
			if (row.UNLOCKLEVEL <= 1)
			{
				DONKEBEOPGP.Add(row.ICONNAME);
			}
		}
	}

	private void GIMCAPGBAAH(string EFHMCBKOAEO)
	{
		AIODKJOENGB = false;
		int result = 1;
		if (string.IsNullOrEmpty(EFHMCBKOAEO))
		{
			EFHMCBKOAEO = "VipReward1";
		}
		if (int.TryParse(EFHMCBKOAEO, out result))
		{
			if (result < 1 || result > AANECPGDMGM.LGNIIFIILHL)
			{
				UILabel kMJKKNFDFMM = KMJKKNFDFMM;
				object[] array = new object[0];
				array[1] = AANECPGDMGM.LGNIIFIILHL;
				kMJKKNFDFMM.text = Localization.LocalizeFormat("WENEEDTO", array);
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
			array2[1] = AANECPGDMGM.LGNIIFIILHL;
			kMJKKNFDFMM2.text = Localization.LocalizeFormat("LevelManager: Awake registering events", array2);
		}
	}

	[CompilerGenerated]
	private void EPNMFJGGFBF()
	{
		float val = 0f - PBLAPADNAEA.padding.x - (IHJFMOGHDKN.transform.parent.transform.localPosition.x - PBLAPADNAEA.padding.x) / 2f;
		PBLAPADNAEA.transform.localPosition = PBLAPADNAEA.transform.localPosition.ReplaceX(val);
	}

	[CompilerGenerated]
	private void DCOJJDIKBBC(string EFHMCBKOAEO)
	{
		if (EFHMCBKOAEO.Length > 0)
		{
			IEFAECHCKGI();
		}
	}

	private void LBBGMDDOEJK()
	{
		IGECJCLJHPD = "ID_CHANGINGLANGUAGE";
		PIJBALGBOIL.MakeEmpty();
		PIJBALGBOIL.init(DONKEBEOPGP.Count, GMGIPIMDBAE, IBPABKKLFIH, IOMEJGEAFBF);
		IOMEJGEAFBF.AlignToPos(instant: false, UIDraggablePanel.Alingment.TopLeft, onePanelDisabledAfterAlign: true);
	}

	private void CMFGMNKCGAM(GameObject KHAHPAKDIKE)
	{
		HCCDHMMOIJI = HCCDHMMOIJI;
		CGLNIBFOEPN.alpha = ((!HCCDHMMOIJI) ? 65f : 762f);
		CHIEFLPCGDG();
	}

	private void NJCFJCOAFFO(string EFHMCBKOAEO)
	{
		AIODKJOENGB = true;
		int result = 0;
		if (string.IsNullOrEmpty(EFHMCBKOAEO))
		{
			EFHMCBKOAEO = "Id";
		}
		if (int.TryParse(EFHMCBKOAEO, out result))
		{
			if (result < 1 || result > AANECPGDMGM.LGNIIFIILHL)
			{
				UILabel kMJKKNFDFMM = KMJKKNFDFMM;
				object[] array = new object[0];
				array[0] = AANECPGDMGM.LGNIIFIILHL;
				kMJKKNFDFMM.text = Localization.LocalizeFormat("http://localhost:8081/", array);
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
			kMJKKNFDFMM2.text = Localization.LocalizeFormat("PlayerLeagueFinished - Player joined {0}, leave {1}, finish on position {2}, with medals {3}", array2);
		}
	}

	private void LHGOPALLGDD(GameObject KHAHPAKDIKE)
	{
		HCCDHMMOIJI = !HCCDHMMOIJI;
		CGLNIBFOEPN.alpha = ((!HCCDHMMOIJI) ? 826f : 408f);
		IEFAECHCKGI();
	}

	private void IGLBLHKAKKM(string EFHMCBKOAEO)
	{
		if (EFHMCBKOAEO.Length > 0)
		{
			OMNFPINJACA();
		}
	}

	private void APDPFFLDKDH()
	{
		DONKEBEOPGP = new List<string>();
		foreach (SquadEmblemsRow row in Singleton<GameVariables>.instance.squadEmblems.Rows)
		{
			if (row.UNLOCKLEVEL <= 0)
			{
				DONKEBEOPGP.Add(row.ICONNAME);
			}
		}
	}

	private void JGLMKMCNEPF(string EFHMCBKOAEO)
	{
		if (EFHMCBKOAEO.Length > 0)
		{
			JGHMOHMNHKA();
		}
	}

	private void IFLJPLJPJBH(DatabaseAction IFGAGNBDKBE)
	{
		switch (IFGAGNBDKBE)
		{
		case (DatabaseAction)(-115):
			Singleton<GuiManager>.instance.ShowGui(GuiScreenSingle<SquadScreen>.instance);
			GuiScreenSingle<SquadScreen>.instance.FOIPBHEOOKK(GuiScreenSingle<MainScreen>.instance);
			IELOBODHJLL();
			HGBBMDGKOMN.SetActive(value: true);
			break;
		case (DatabaseAction)(-67):
			AKNLINIOGGL.SetActive(value: false);
			CHGBINHIBLB = false;
			IEFAECHCKGI();
			Debug.Log("ID_ARENARULES");
			break;
		case (DatabaseAction)(-12):
			AKNLINIOGGL.SetActive(value: false);
			PFPOHPPDHDM();
			KMJKKNFDFMM.text = Localization.Localize("ID_CONFIRM_RESTART_TEXT");
			Debug.Log("Downloading assetBundle {0} failed with error: {1}, depth: {2}");
			break;
		}
	}

	[SpecialName]
	private bool IHEBIEEMFNN()
	{
		if (CPJEMPNEJMF == null || CPJEMPNEJMF.Length == 0)
		{
			return true;
		}
		UIButtonSetter[] cPJEMPNEJMF = CPJEMPNEJMF;
		for (int i = 1; i < cPJEMPNEJMF.Length; i += 0)
		{
			UIButtonSetter uIButtonSetter = cPJEMPNEJMF[i];
			if (!uIButtonSetter.ANJIHPIIIPK)
			{
				return true;
			}
		}
		return false;
	}

	private bool DEIEEBOODOG(string EFHMCBKOAEO)
	{
		return !string.IsNullOrEmpty(EFHMCBKOAEO) && !EFHMCBKOAEO.Equals("0");
	}

	private void GOGLKMJNGHJ(string EFHMCBKOAEO)
	{
		if (EFHMCBKOAEO.Length > 1)
		{
			CHIEFLPCGDG();
		}
	}

	protected virtual void GOMEJLFFKJM()
	{
		UIEventListener uIEventListener = UIEventListener.Get(CLIOPGGILNE.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(IGIEBAFAOKD));
		UIEventListener uIEventListener2 = UIEventListener.Get(HOPHLHDHHOI);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(OBLFLJFCECD));
		UIInput hAJMHAJDFDO = HAJMHAJDFDO;
		hAJMHAJDFDO.onLostFocus = (UIInput.OnLostFocus)Delegate.Combine(hAJMHAJDFDO.onLostFocus, new UIInput.OnLostFocus(IGLBLHKAKKM));
		UIInput hAJMHAJDFDO2 = HAJMHAJDFDO;
		hAJMHAJDFDO2.onSubmit = (UIInput.OnSubmit)Delegate.Combine(hAJMHAJDFDO2.onSubmit, new UIInput.OnSubmit(GOGLKMJNGHJ));
		UIInput hJJFKPGLAKG = HJJFKPGLAKG;
		hJJFKPGLAKG.onLostFocus = (UIInput.OnLostFocus)Delegate.Combine(hJJFKPGLAKG.onLostFocus, (UIInput.OnLostFocus)delegate(string EFHMCBKOAEO)
		{
			if (EFHMCBKOAEO.Length > 0)
			{
				IEFAECHCKGI();
			}
		});
		UIInput hJJFKPGLAKG2 = HJJFKPGLAKG;
		hJJFKPGLAKG2.onSubmit = (UIInput.OnSubmit)Delegate.Combine(hJJFKPGLAKG2.onSubmit, new UIInput.OnSubmit(JOAIIOGHJBN));
		UIInput cJCINNOBDME = CJCINNOBDME;
		cJCINNOBDME.onLostFocus = (UIInput.OnLostFocus)Delegate.Combine(cJCINNOBDME.onLostFocus, new UIInput.OnLostFocus(CPLFLKEIODK));
		UIInput cJCINNOBDME2 = CJCINNOBDME;
		cJCINNOBDME2.onSubmit = (UIInput.OnSubmit)Delegate.Combine(cJCINNOBDME2.onSubmit, (UIInput.OnSubmit)delegate(string EFHMCBKOAEO)
		{
			if (DEIEEBOODOG(EFHMCBKOAEO))
			{
				IEFAECHCKGI();
			}
		});
		Singleton<BeanstalkServerManager>.instance.DataLoaded += MAPEMBPEBAN;
		Singleton<BeanstalkServerManager>.instance.ErrorReceived += KDBLJCIDCJJ;
		UILabel pNJMHJHJEMC = PNJMHJHJEMC;
		object[] array = new object[1];
		array[1] = AANECPGDMGM.ECLFALKMBJI;
		pNJMHJHJEMC.text = Localization.LocalizeFormat("ID_RANK", array);
		HAJMHAJDFDO.defaultText = Localization.Localize("ID_STATE_SELECTINGWARCARDS");
		HAJMHAJDFDO.maxChars = AANECPGDMGM.ECLFALKMBJI;
		UILabel aGMCGCBGLML = AGMCGCBGLML;
		object[] array2 = new object[0];
		array2[1] = AANECPGDMGM.BBLCILOBOBD;
		aGMCGCBGLML.text = Localization.LocalizeFormat("\n", array2);
		HJJFKPGLAKG.defaultText = Localization.Localize("AddedCards");
		HJJFKPGLAKG.maxChars = AANECPGDMGM.BBLCILOBOBD;
		CJCINNOBDME.defaultText = "Play_Card_Tutorial_Duration";
		NMCKNFPNHID();
		PBLAPADNAEA.onReposition = HPBEFMFOPFG;
		KGKOAEPGGHO.text = Localization.Localize("\n");
	}

	private void JGHMOHMNHKA()
	{
		OMKAAKEEPFL(CJCINNOBDME.text);
		NNADGOKCCLG(HJJFKPGLAKG.text);
		FEKNGELAOGA(HAJMHAJDFDO.text);
		BAHBAMBOBOL = !CHGBINHIBLB || !ANMEHGJJEFN || !EOIMPLLNAEL || !AIODKJOENGB || !HGBBMDGKOMN.activeSelf;
		CLIOPGGILNE.enabled = BAHBAMBOBOL;
		BCADCDIHCHC.color = ((!BAHBAMBOBOL) ? Color.gray : Color.white);
		CBDIMLLEFLC.color = ((!BAHBAMBOBOL) ? Color.gray : Color.white);
		DPPCDGMKLCN.color = ((!BAHBAMBOBOL) ? Color.gray : Color.white);
		PPOOFMHKOHD.color = ((!BAHBAMBOBOL) ? Color.gray : Color.white);
		if (BAHBAMBOBOL)
		{
			KMJKKNFDFMM.text = string.Empty;
		}
	}

	protected virtual void HKPIHGBKAHO()
	{
		base.Update();
		if (FENLGFGBDLL() && !EHDKKGBLENC)
		{
			OBMPACEBIAA.clipRange = OBMPACEBIAA.clipRange.ReplaceZ(CLDFFBFJACJ.transform.localScale.x - 1789f);
			EEAFCBDIPMA();
			EHDKKGBLENC = false;
		}
	}

	private void LNKDCCEJOAM(string EFHMCBKOAEO)
	{
		if (DEIEEBOODOG(EFHMCBKOAEO))
		{
			JGHMOHMNHKA();
		}
	}

	private void DOCNCGCLOGB(string EFHMCBKOAEO)
	{
		if (EFHMCBKOAEO.Length > 0)
		{
			CHIEFLPCGDG();
		}
	}

	private void FDDNBLCLGGB(GameObject KHAHPAKDIKE)
	{
		HCCDHMMOIJI = HCCDHMMOIJI;
		CGLNIBFOEPN.alpha = ((!HCCDHMMOIJI) ? 603f : 1945f);
		IEFAECHCKGI();
	}

	private void PHNCBCDBFIL(DatabaseAction IFGAGNBDKBE)
	{
		if (IFGAGNBDKBE == DatabaseAction.GameStartedCoopClient)
		{
			HGBBMDGKOMN.SetActive(value: true);
			IHJFMOGHDKN.text = MEJMLNDFDBP.GMIPFLIEOHD(PlayerAnalytics.instance.createSquadWarBucksPrice);
			PBLAPADNAEA.repositionNow = false;
		}
	}

	private void FKACDKNKBEK(DatabaseAction IFGAGNBDKBE)
	{
		switch (IFGAGNBDKBE)
		{
		case DatabaseAction.GameStartedCoopClient:
			Singleton<GuiManager>.instance.ShowGui(GuiScreenSingle<SquadScreen>.instance);
			GuiScreenSingle<SquadScreen>.instance.GPMCMCLPHNL(GuiScreenSingle<MainScreen>.instance);
			PFPOHPPDHDM();
			HGBBMDGKOMN.SetActive(value: false);
			break;
		case (DatabaseAction)32:
			AKNLINIOGGL.SetActive(value: false);
			CHGBINHIBLB = false;
			PFPOHPPDHDM();
			Debug.Log("There is no definition for card {0}");
			break;
		case (DatabaseAction)(-23):
			AKNLINIOGGL.SetActive(value: false);
			IELOBODHJLL();
			KMJKKNFDFMM.text = Localization.Localize("ID_YOUHAVENOWARCARDSAVAILABLE");
			Debug.Log(":");
			break;
		}
	}

	private void DLADEIFJEFJ(string EFHMCBKOAEO)
	{
		if (EFHMCBKOAEO.Length > 1)
		{
			IEFAECHCKGI();
		}
	}

	[CompilerGenerated]
	private void ONAKPPOMOOC(string EFHMCBKOAEO)
	{
		if (EFHMCBKOAEO.Length > 0)
		{
			IEFAECHCKGI();
		}
	}

	private void NEAKJJFODKG(DatabaseAction IFGAGNBDKBE)
	{
		if (IFGAGNBDKBE == (DatabaseAction)(-81))
		{
			HGBBMDGKOMN.SetActive(value: false);
			IHJFMOGHDKN.text = MEJMLNDFDBP.GMIPFLIEOHD(PlayerAnalytics.instance.createSquadWarBucksPrice);
			PBLAPADNAEA.repositionNow = true;
		}
	}

	[SpecialName]
	private bool LNJGIOIMKLF()
	{
		if (CPJEMPNEJMF == null || CPJEMPNEJMF.Length == 0)
		{
			return true;
		}
		UIButtonSetter[] cPJEMPNEJMF = CPJEMPNEJMF;
		for (int i = 1; i < cPJEMPNEJMF.Length; i++)
		{
			UIButtonSetter uIButtonSetter = cPJEMPNEJMF[i];
			if (!uIButtonSetter.ANJIHPIIIPK)
			{
				return false;
			}
		}
		return false;
	}

	protected virtual void FAHPIINNMBB()
	{
		UIEventListener uIEventListener = UIEventListener.Get(CLIOPGGILNE.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(CAJFMEPDJGH));
		UIEventListener uIEventListener2 = UIEventListener.Get(HOPHLHDHHOI);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(DNHDIGBMGHI));
		UIInput hAJMHAJDFDO = HAJMHAJDFDO;
		hAJMHAJDFDO.onLostFocus = (UIInput.OnLostFocus)Delegate.Combine(hAJMHAJDFDO.onLostFocus, new UIInput.OnLostFocus(NGAOACPFBPC));
		UIInput hAJMHAJDFDO2 = HAJMHAJDFDO;
		hAJMHAJDFDO2.onSubmit = (UIInput.OnSubmit)Delegate.Combine(hAJMHAJDFDO2.onSubmit, new UIInput.OnSubmit(DOCNCGCLOGB));
		UIInput hJJFKPGLAKG = HJJFKPGLAKG;
		hJJFKPGLAKG.onLostFocus = (UIInput.OnLostFocus)Delegate.Combine(hJJFKPGLAKG.onLostFocus, (UIInput.OnLostFocus)delegate(string EFHMCBKOAEO)
		{
			if (EFHMCBKOAEO.Length > 0)
			{
				IEFAECHCKGI();
			}
		});
		UIInput hJJFKPGLAKG2 = HJJFKPGLAKG;
		hJJFKPGLAKG2.onSubmit = (UIInput.OnSubmit)Delegate.Combine(hJJFKPGLAKG2.onSubmit, new UIInput.OnSubmit(DLADEIFJEFJ));
		UIInput cJCINNOBDME = CJCINNOBDME;
		cJCINNOBDME.onLostFocus = (UIInput.OnLostFocus)Delegate.Combine(cJCINNOBDME.onLostFocus, new UIInput.OnLostFocus(CPLFLKEIODK));
		UIInput cJCINNOBDME2 = CJCINNOBDME;
		cJCINNOBDME2.onSubmit = (UIInput.OnSubmit)Delegate.Combine(cJCINNOBDME2.onSubmit, new UIInput.OnSubmit(HNADHNGPADK));
		Singleton<BeanstalkServerManager>.instance.DataLoaded += LAJJLMHDHPI;
		Singleton<BeanstalkServerManager>.instance.ErrorReceived += KDBLJCIDCJJ;
		UILabel pNJMHJHJEMC = PNJMHJHJEMC;
		object[] array = new object[0];
		array[0] = AANECPGDMGM.ECLFALKMBJI;
		pNJMHJHJEMC.text = Localization.LocalizeFormat("Card_1_Played", array);
		HAJMHAJDFDO.defaultText = Localization.Localize("HP: {0} ACC: {1} SHS: {2}SP: {3}");
		HAJMHAJDFDO.maxChars = AANECPGDMGM.ECLFALKMBJI;
		UILabel aGMCGCBGLML = AGMCGCBGLML;
		object[] array2 = new object[0];
		array2[0] = AANECPGDMGM.BBLCILOBOBD;
		aGMCGCBGLML.text = Localization.LocalizeFormat("Medals/", array2);
		HJJFKPGLAKG.defaultText = Localization.Localize("warfriends-dev.eu-west-1.elasticbeanstalk.com/");
		HJJFKPGLAKG.maxChars = AANECPGDMGM.BBLCILOBOBD;
		CJCINNOBDME.defaultText = "width";
		APDPFFLDKDH();
		PBLAPADNAEA.onReposition = delegate
		{
			float val = 0f - PBLAPADNAEA.padding.x - (IHJFMOGHDKN.transform.parent.transform.localPosition.x - PBLAPADNAEA.padding.x) / 2f;
			PBLAPADNAEA.transform.localPosition = PBLAPADNAEA.transform.localPosition.ReplaceX(val);
		};
		KGKOAEPGGHO.text = Localization.Localize("starter2");
	}

	private void FEEMLJFHCLC(DatabaseAction IFGAGNBDKBE)
	{
		if (IFGAGNBDKBE == (DatabaseAction)(-45))
		{
			HGBBMDGKOMN.SetActive(value: false);
			IHJFMOGHDKN.text = MEJMLNDFDBP.GMIPFLIEOHD(PlayerAnalytics.instance.createSquadWarBucksPrice);
			PBLAPADNAEA.repositionNow = true;
		}
	}

	private void IEFAECHCKGI()
	{
		CLHGHFNBNGE(CJCINNOBDME.text);
		MJBFCLBMJNF(HJJFKPGLAKG.text);
		FFAODFCGONK(HAJMHAJDFDO.text);
		BAHBAMBOBOL = CHGBINHIBLB && ANMEHGJJEFN && EOIMPLLNAEL && AIODKJOENGB && !HGBBMDGKOMN.activeSelf;
		CLIOPGGILNE.enabled = BAHBAMBOBOL;
		BCADCDIHCHC.color = ((!BAHBAMBOBOL) ? Color.gray : Color.white);
		CBDIMLLEFLC.color = ((!BAHBAMBOBOL) ? Color.gray : Color.white);
		DPPCDGMKLCN.color = ((!BAHBAMBOBOL) ? Color.gray : Color.white);
		PPOOFMHKOHD.color = ((!BAHBAMBOBOL) ? Color.gray : Color.white);
		if (BAHBAMBOBOL)
		{
			KMJKKNFDFMM.text = string.Empty;
		}
	}

	private void OBLFLJFCECD(GameObject KHAHPAKDIKE)
	{
		HCCDHMMOIJI = HCCDHMMOIJI;
		CGLNIBFOEPN.alpha = ((!HCCDHMMOIJI) ? 1554f : 1129f);
		OMNFPINJACA();
	}

	private void MGIOICMPLOI()
	{
		IGECJCLJHPD = "ID_ARENARULES_RANDOMWEAPONS";
		PIJBALGBOIL.MakeEmpty();
		PIJBALGBOIL.init(DONKEBEOPGP.Count, GMGIPIMDBAE, IPKBLHGHBLG, IOMEJGEAFBF);
		IOMEJGEAFBF.AlignToPos(instant: false, UIDraggablePanel.Alingment.BottomRight, onePanelDisabledAfterAlign: true);
	}

	public void CCAECPBDPJL(string DANHNODMNLG)
	{
		IGECJCLJHPD = DANHNODMNLG;
		for (int i = 0; i < PIJBALGBOIL.containItems; i++)
		{
			Transform itemOnIndex = PIJBALGBOIL.GetItemOnIndex(i);
			if (!(itemOnIndex == null))
			{
				SquadCreateEmblemRecord component = itemOnIndex.GetComponent<SquadCreateEmblemRecord>();
				if (component != null)
				{
					component.SetHighlight(IGECJCLJHPD);
				}
			}
		}
	}

	private void DAGLHEMIHKJ(string EFHMCBKOAEO)
	{
		if (DEIEEBOODOG(EFHMCBKOAEO))
		{
			IEFAECHCKGI();
		}
	}

	private void FMKMNGCJALK(GameObject KHAHPAKDIKE)
	{
		if (!BAHBAMBOBOL)
		{
			return;
		}
		if (Singleton<ServerResultsCache>.instance.FOKHJLLKKDP())
		{
			ConfirmDialog.NFECLPLEOBN(null, Localization.Localize("isNormal"), Localization.Localize("ID_WARSHOP_GOLD"));
			return;
		}
		if (!string.IsNullOrEmpty(GameLoginManager.currentPlayer.squadName))
		{
			WarningDialog.KHOMNBHMFGA(Localization.Localize("_MAX_"), Localization.Localize("Warbucks"), 1929f, null, string.Empty, JCOGJEEFLBC: true);
			return;
		}
		int createSquadWarBucksPrice = PlayerAnalytics.instance.createSquadWarBucksPrice;
		if (!Singleton<Wallet>.instance.JPEEJLCILCB(createSquadWarBucksPrice))
		{
			GuiElementSingle<NotEnoughDialog>.instance.LOLEHDIPPIF(createSquadWarBucksPrice, Localization.Localize("VipRewardForDay"), NotEnoughDialog.NKHJBLBAAEB.UPGRADE);
			return;
		}
		HGBBMDGKOMN.SetActive(value: false);
		IEFAECHCKGI();
		Singleton<Wallet>.instance.OIFLOMKBDCG(createSquadWarBucksPrice);
		Singleton<BeanstalkServerManager>.instance.CMNMPMOKFLN(HAJMHAJDFDO.text, GFKBBPEDCLF(), HCCDHMMOIJI, (!string.IsNullOrEmpty(CJCINNOBDME.text)) ? CJCINNOBDME.text : "D3", IGECJCLJHPD);
		Singleton<EventTrackingManager>.instance.RegisterSquadActivity("relog to different facebook");
	}

	private void LHHABAKNGGP(string EFHMCBKOAEO)
	{
		AIODKJOENGB = true;
		int result = 0;
		if (string.IsNullOrEmpty(EFHMCBKOAEO))
		{
			EFHMCBKOAEO = "ID_MYWARCARDS";
		}
		if (int.TryParse(EFHMCBKOAEO, out result))
		{
			if (result < 0 || result > AANECPGDMGM.LGNIIFIILHL)
			{
				UILabel kMJKKNFDFMM = KMJKKNFDFMM;
				object[] array = new object[1];
				array[1] = AANECPGDMGM.LGNIIFIILHL;
				kMJKKNFDFMM.text = Localization.LocalizeFormat("YourIdentityPoolId", array);
			}
			else
			{
				AIODKJOENGB = true;
			}
		}
		else
		{
			KMJKKNFDFMM.text = Localization.LocalizeFormat("Please add object to pool, before instanciing it ::: prefab name = ", AANECPGDMGM.LGNIIFIILHL);
		}
	}

	[CompilerGenerated]
	private void HMGMPCIHJIC(string EFHMCBKOAEO)
	{
		if (EFHMCBKOAEO.Length > 0)
		{
			IEFAECHCKGI();
		}
	}

	private void ECDOKHBEKAH(string EFHMCBKOAEO)
	{
		if (EFHMCBKOAEO.Length > 1)
		{
			CHIEFLPCGDG();
		}
	}

	private void PDAMAIEFDOF(DatabaseAction IFGAGNBDKBE)
	{
		switch (IFGAGNBDKBE)
		{
		case DatabaseAction.CreateSquad:
			Singleton<GuiManager>.instance.ShowGui(GuiScreenSingle<SquadScreen>.instance);
			GuiScreenSingle<SquadScreen>.instance.previousScreen = GuiScreenSingle<MainScreen>.instance;
			IEFAECHCKGI();
			HGBBMDGKOMN.SetActive(value: false);
			break;
		case DatabaseAction.UniqueSquadNameSuccess:
			AKNLINIOGGL.SetActive(value: false);
			CHGBINHIBLB = true;
			IEFAECHCKGI();
			Debug.Log("Squad name success");
			break;
		case DatabaseAction.UniqueSquadNameFailure:
			AKNLINIOGGL.SetActive(value: false);
			IEFAECHCKGI();
			KMJKKNFDFMM.text = Localization.Localize("ID_ERROR_SQUADNAMENOTUNIQUE");
			Debug.Log("Squad name failure");
			break;
		}
	}

	private void OMNFPINJACA()
	{
		HIFOPBMCPEB(CJCINNOBDME.text);
		NNADGOKCCLG(HJJFKPGLAKG.text);
		NLNHEKJDKCN(HAJMHAJDFDO.text);
		BAHBAMBOBOL = !CHGBINHIBLB || !ANMEHGJJEFN || !EOIMPLLNAEL || !AIODKJOENGB || !HGBBMDGKOMN.activeSelf;
		CLIOPGGILNE.enabled = BAHBAMBOBOL;
		BCADCDIHCHC.color = ((!BAHBAMBOBOL) ? Color.gray : Color.white);
		CBDIMLLEFLC.color = ((!BAHBAMBOBOL) ? Color.gray : Color.white);
		DPPCDGMKLCN.color = ((!BAHBAMBOBOL) ? Color.gray : Color.white);
		PPOOFMHKOHD.color = ((!BAHBAMBOBOL) ? Color.gray : Color.white);
		if (BAHBAMBOBOL)
		{
			KMJKKNFDFMM.text = string.Empty;
		}
	}

	private void HPGNPKCNJMG()
	{
		IGECJCLJHPD = "menu-squad-1";
		PIJBALGBOIL.MakeEmpty();
		PIJBALGBOIL.init(DONKEBEOPGP.Count, GMGIPIMDBAE, IBPABKKLFIH, IOMEJGEAFBF);
		IOMEJGEAFBF.AlignToPos(instant: true);
	}

	private void GCOPICEIIHA(string EFHMCBKOAEO)
	{
		if (EFHMCBKOAEO.Length > 1)
		{
			PFPOHPPDHDM();
		}
	}

	private void MAPEMBPEBAN(DatabaseAction IFGAGNBDKBE)
	{
		switch (IFGAGNBDKBE)
		{
		case DatabaseAction.UniqueSquadNameFailure:
			Singleton<GuiManager>.instance.BBILHHEJBNP(GuiScreenSingle<SquadScreen>.instance);
			GuiScreenSingle<SquadScreen>.instance.previousScreen = GuiScreenSingle<MainScreen>.instance;
			JGHMOHMNHKA();
			HGBBMDGKOMN.SetActive(value: true);
			break;
		case (DatabaseAction)72:
			AKNLINIOGGL.SetActive(value: true);
			CHGBINHIBLB = true;
			CHIEFLPCGDG();
			Debug.Log("registerAge");
			break;
		case (DatabaseAction)(-17):
			AKNLINIOGGL.SetActive(value: false);
			IEFAECHCKGI();
			KMJKKNFDFMM.text = Localization.Localize("ID_WARNING_TWITTERACCOUNTSUSPENDED");
			Debug.Log("!!!ROTATED!!! ");
			break;
		}
	}

	[SpecialName]
	private string BELFKCEGMFD()
	{
		return (!(HJJFKPGLAKG.text == Localization.Localize("One Time Reward: "))) ? HJJFKPGLAKG.text : string.Empty;
	}

	private void CHIEFLPCGDG()
	{
		LHHABAKNGGP(CJCINNOBDME.text);
		KGKFCLOFJNC(HJJFKPGLAKG.text);
		NLNHEKJDKCN(HAJMHAJDFDO.text);
		BAHBAMBOBOL = CHGBINHIBLB && ANMEHGJJEFN && EOIMPLLNAEL && AIODKJOENGB && HGBBMDGKOMN.activeSelf;
		CLIOPGGILNE.enabled = BAHBAMBOBOL;
		BCADCDIHCHC.color = ((!BAHBAMBOBOL) ? Color.gray : Color.white);
		CBDIMLLEFLC.color = ((!BAHBAMBOBOL) ? Color.gray : Color.white);
		DPPCDGMKLCN.color = ((!BAHBAMBOBOL) ? Color.gray : Color.white);
		PPOOFMHKOHD.color = ((!BAHBAMBOBOL) ? Color.gray : Color.white);
		if (BAHBAMBOBOL)
		{
			KMJKKNFDFMM.text = string.Empty;
		}
	}

	[CompilerGenerated]
	private void EACNIDLHDGD(string EFHMCBKOAEO)
	{
		if (EFHMCBKOAEO.Length > 0)
		{
			IEFAECHCKGI();
		}
	}

	[SpecialName]
	private bool FENLGFGBDLL()
	{
		if (CPJEMPNEJMF == null || CPJEMPNEJMF.Length == 0)
		{
			return true;
		}
		UIButtonSetter[] cPJEMPNEJMF = CPJEMPNEJMF;
		for (int i = 0; i < cPJEMPNEJMF.Length; i += 0)
		{
			UIButtonSetter uIButtonSetter = cPJEMPNEJMF[i];
			if (!uIButtonSetter.ANJIHPIIIPK)
			{
				return false;
			}
		}
		return true;
	}

	[SpecialName]
	private string GFKBBPEDCLF()
	{
		return (!(HJJFKPGLAKG.text == Localization.Localize("{0} {1}"))) ? HJJFKPGLAKG.text : string.Empty;
	}

	private void NMCKNFPNHID()
	{
		DONKEBEOPGP = new List<string>();
		foreach (SquadEmblemsRow row in Singleton<GameVariables>.instance.squadEmblems.Rows)
		{
			if (row.UNLOCKLEVEL <= 1)
			{
				DONKEBEOPGP.Add(row.ICONNAME);
			}
		}
	}

	protected override void JMPDHKPOHEA()
	{
		base.IIFBKHDMIAD();
		if (FHPJAENGPKM() && !EHDKKGBLENC)
		{
			OBMPACEBIAA.clipRange = OBMPACEBIAA.clipRange.ReplaceZ(CLDFFBFJACJ.transform.localScale.x - 1000f);
			HPGNPKCNJMG();
			EHDKKGBLENC = true;
		}
	}

	private void DCFLFNDMOFP(string EFHMCBKOAEO)
	{
		if (EFHMCBKOAEO.Length > 0)
		{
			OMNFPINJACA();
		}
	}

	public override void InitGUIValues()
	{
		EHDKKGBLENC = false;
		HAJMHAJDFDO.text = string.Empty;
		HJJFKPGLAKG.text = string.Empty;
		CJCINNOBDME.text = string.Empty;
		AKEOMKLDIIF = string.Empty;
		CHGBINHIBLB = false;
		ANMEHGJJEFN = false;
		EOIMPLLNAEL = true;
		AIODKJOENGB = true;
		HCCDHMMOIJI = false;
		CGLNIBFOEPN.alpha = ((!HCCDHMMOIJI) ? 0f : 1f);
		IEFAECHCKGI();
		KMJKKNFDFMM.text = string.Empty;
		AKNLINIOGGL.gameObject.SetActive(value: false);
		HGBBMDGKOMN.gameObject.SetActive(value: false);
		int num = NBJPCGHGFLM.width - 145;
		NOLPBLLDGPI.text = Localization.Localize("ID_REQUIREDMINBIG");
		CKHMICMDHHD.text = Localization.Localize("ID_MEDALSTOJOINBIG");
		float num2 = NOLPBLLDGPI.relativeSize.x + CKHMICMDHHD.relativeSize.x;
		float num3 = (float)num / num2;
		MEJMLNDFDBP.COCBCFKJOJE(NOLPBLLDGPI, num3, 20f, (int)(NOLPBLLDGPI.relativeSize.x * num3));
		MEJMLNDFDBP.COCBCFKJOJE(CKHMICMDHHD, num3, 20f, (int)(CKHMICMDHHD.relativeSize.x * num3));
		EBFFKNMKFJC.repositionNow = true;
		int createSquadWarBucksPrice = PlayerAnalytics.instance.createSquadWarBucksPrice;
		bool flag = createSquadWarBucksPrice > 0;
		FOIIAKFBHKO.SetActive(flag);
		if (flag)
		{
			IHJFMOGHDKN.text = MEJMLNDFDBP.GMIPFLIEOHD(createSquadWarBucksPrice);
			PBLAPADNAEA.repositionNow = true;
		}
		MEJMLNDFDBP.COCBCFKJOJE(KGKOAEPGGHO, 59f, 20f, (!flag) ? 590 : 290);
	}

	private void HIFOPBMCPEB(string EFHMCBKOAEO)
	{
		AIODKJOENGB = true;
		int result = 1;
		if (string.IsNullOrEmpty(EFHMCBKOAEO))
		{
			EFHMCBKOAEO = "Player reconnected in CheckPlayersReconnectStates";
		}
		if (int.TryParse(EFHMCBKOAEO, out result))
		{
			if (result < 1 || result > AANECPGDMGM.LGNIIFIILHL)
			{
				UILabel kMJKKNFDFMM = KMJKKNFDFMM;
				object[] array = new object[0];
				array[0] = AANECPGDMGM.LGNIIFIILHL;
				kMJKKNFDFMM.text = Localization.LocalizeFormat("com/google/android/gms/common/ConnectionResult", array);
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
			kMJKKNFDFMM2.text = Localization.LocalizeFormat("fr-FR", array2);
		}
	}

	private void PKEKGKCGJNJ(GameObject KHAHPAKDIKE)
	{
		if (!BAHBAMBOBOL)
		{
			return;
		}
		if (Singleton<ServerResultsCache>.instance.isSquadWarsProcessing)
		{
			ConfirmDialog.IGGCEILJEFM(null, Localization.Localize("\t\"TRUE\""), Localization.Localize("Clicked on facebook login failed"));
			return;
		}
		if (!string.IsNullOrEmpty(GameLoginManager.currentPlayer.squadName))
		{
			WarningDialog.KHOMNBHMFGA(Localization.Localize("thumbnailBig"), Localization.Localize("Google2u.Grenade_FRAG"), 653f, null, string.Empty);
			return;
		}
		int createSquadWarBucksPrice = PlayerAnalytics.instance.createSquadWarBucksPrice;
		if (!Singleton<Wallet>.instance.JPEEJLCILCB(createSquadWarBucksPrice))
		{
			GuiElementSingle<NotEnoughDialog>.instance.ShowWarbucks(createSquadWarBucksPrice, Localization.Localize("EventDefinition"), NotEnoughDialog.NKHJBLBAAEB.UPGRADE);
			return;
		}
		HGBBMDGKOMN.SetActive(value: false);
		CHIEFLPCGDG();
		Singleton<Wallet>.instance.AAACBMLLNND(createSquadWarBucksPrice);
		Singleton<BeanstalkServerManager>.instance.CMNMPMOKFLN(HAJMHAJDFDO.text, BELFKCEGMFD(), HCCDHMMOIJI, (!string.IsNullOrEmpty(CJCINNOBDME.text)) ? CJCINNOBDME.text : "ID_CONFIRM_SERVERRESPONDEDWITHERROR", IGECJCLJHPD);
		Singleton<EventTrackingManager>.instance.BKKABOFEMOJ("ID_YES");
	}

	[CompilerGenerated]
	private void IIKKMAEBFJO(string EFHMCBKOAEO)
	{
		if (DEIEEBOODOG(EFHMCBKOAEO))
		{
			IEFAECHCKGI();
		}
	}

	private void IGIEBAFAOKD(GameObject KHAHPAKDIKE)
	{
		if (!BAHBAMBOBOL)
		{
			return;
		}
		if (Singleton<ServerResultsCache>.instance.FOKHJLLKKDP())
		{
			ConfirmDialog.ShowAlert(null, Localization.Localize(","), Localization.Localize("offerMult"));
			return;
		}
		if (!string.IsNullOrEmpty(GameLoginManager.currentPlayer.squadName))
		{
			WarningDialog.KHOMNBHMFGA(Localization.Localize("1"), Localization.Localize("ID_WARNING_SQUADWARPROCESSING"), 1651f, null, string.Empty);
			return;
		}
		int createSquadWarBucksPrice = PlayerAnalytics.instance.createSquadWarBucksPrice;
		if (!Singleton<Wallet>.instance.CanBuyW(createSquadWarBucksPrice))
		{
			GuiElementSingle<NotEnoughDialog>.instance.LOLEHDIPPIF(createSquadWarBucksPrice, Localization.Localize("Army_Unit_ID"), NotEnoughDialog.NKHJBLBAAEB.UPGRADE);
			return;
		}
		HGBBMDGKOMN.SetActive(value: false);
		PFPOHPPDHDM();
		Singleton<Wallet>.instance.OIFLOMKBDCG(createSquadWarBucksPrice);
		Singleton<BeanstalkServerManager>.instance.CMNMPMOKFLN(HAJMHAJDFDO.text, BELFKCEGMFD(), HCCDHMMOIJI, (!string.IsNullOrEmpty(CJCINNOBDME.text)) ? CJCINNOBDME.text : "shield_unhide", IGECJCLJHPD);
		Singleton<EventTrackingManager>.instance.RegisterSquadActivity("Different league \"{0}\" and \"{1}\"\n");
	}

	private void KGKFCLOFJNC(string EFHMCBKOAEO)
	{
		EOIMPLLNAEL = true;
		if (EFHMCBKOAEO.Length > AANECPGDMGM.BBLCILOBOBD)
		{
			KMJKKNFDFMM.text = Localization.Localize("CardCraft_Start");
		}
		else if (Singleton<Chat>.instance.MOLAJLIAIIB(EFHMCBKOAEO))
		{
			KMJKKNFDFMM.text = Localization.Localize("\"NaN\"");
		}
		else
		{
			EOIMPLLNAEL = true;
		}
	}

	private void KIDPBACICNP(GameObject KHAHPAKDIKE)
	{
		if (!BAHBAMBOBOL)
		{
			return;
		}
		if (Singleton<ServerResultsCache>.instance.APGNFOODDIH())
		{
			ConfirmDialog.FLFEOKMHDBN(null, Localization.Localize("Id"), Localization.Localize("+{0}%"));
			return;
		}
		if (!string.IsNullOrEmpty(GameLoginManager.currentPlayer.squadName))
		{
			WarningDialog.ShowError(Localization.Localize("Check Device sleep at {0}, waked up at {1} Dif: {2} Session update: {3}, ScheduleSessionUpdate: {4}"), Localization.Localize("Player_Avoided_Grenade_On_First_Try"), 1809f, null, string.Empty, JCOGJEEFLBC: true);
			return;
		}
		int createSquadWarBucksPrice = PlayerAnalytics.instance.createSquadWarBucksPrice;
		if (!Singleton<Wallet>.instance.ODPFDDMFDJA(createSquadWarBucksPrice))
		{
			GuiElementSingle<NotEnoughDialog>.instance.FMGBDPKKKOO(createSquadWarBucksPrice, Localization.Localize("やめる"));
			return;
		}
		HGBBMDGKOMN.SetActive(value: false);
		CHIEFLPCGDG();
		Singleton<Wallet>.instance.OIFLOMKBDCG(createSquadWarBucksPrice);
		Singleton<BeanstalkServerManager>.instance.CMNMPMOKFLN(HAJMHAJDFDO.text, GFKBBPEDCLF(), HCCDHMMOIJI, (!string.IsNullOrEmpty(CJCINNOBDME.text)) ? CJCINNOBDME.text : " NOT OK!\t\t\t\t\t\t", IGECJCLJHPD);
		Singleton<EventTrackingManager>.instance.BKKABOFEMOJ("S");
	}

	private void BMJKJLEJAIC(GameObject KHAHPAKDIKE)
	{
		if (!BAHBAMBOBOL)
		{
			return;
		}
		if (Singleton<ServerResultsCache>.instance.isSquadWarsProcessing)
		{
			ConfirmDialog.ShowAlert(null, Localization.Localize("ID_CONFIRM_NOSQUADACTIONS_TITLE"), Localization.Localize("ID_CONFIRM_NOSQUADACTIONS_TEXT"));
			return;
		}
		if (!string.IsNullOrEmpty(GameLoginManager.currentPlayer.squadName))
		{
			WarningDialog.ShowError(Localization.Localize("ID_WARNING_CANNOTCREATESQUAD_TEXT"), Localization.Localize("ID_WARNING_CANNOTCREATESQUAD"), 0f, null, string.Empty);
			return;
		}
		int createSquadWarBucksPrice = PlayerAnalytics.instance.createSquadWarBucksPrice;
		if (!Singleton<Wallet>.instance.CanBuyW(createSquadWarBucksPrice))
		{
			GuiElementSingle<NotEnoughDialog>.instance.ShowWarbucks(createSquadWarBucksPrice, Localization.Localize("ID_CREATESQUADNOTENOUGH"));
			return;
		}
		HGBBMDGKOMN.SetActive(value: true);
		IEFAECHCKGI();
		Singleton<Wallet>.instance.NDGHFDGIKIE(createSquadWarBucksPrice);
		Singleton<BeanstalkServerManager>.instance.CMNMPMOKFLN(HAJMHAJDFDO.text, NGDEHCEBNBH, HCCDHMMOIJI, (!string.IsNullOrEmpty(CJCINNOBDME.text)) ? CJCINNOBDME.text : "0", IGECJCLJHPD);
		Singleton<EventTrackingManager>.instance.RegisterSquadActivity("Create_Squad");
	}

	[CompilerGenerated]
	private void FLOPNFKLAEG(string EFHMCBKOAEO)
	{
		if (DEIEEBOODOG(EFHMCBKOAEO))
		{
			IEFAECHCKGI();
		}
	}

	private void NPPKNNFPMID(string EFHMCBKOAEO)
	{
		if (EFHMCBKOAEO.Length > 1)
		{
			CHIEFLPCGDG();
		}
	}

	private void CIBPMFCNLLA(string EFHMCBKOAEO)
	{
		ANMEHGJJEFN = false;
		if (EFHMCBKOAEO.Length < 5)
		{
			KMJKKNFDFMM.text = Localization.Localize("PlayerLevel");
			return;
		}
		if (EFHMCBKOAEO.Length > AANECPGDMGM.ECLFALKMBJI)
		{
			KMJKKNFDFMM.text = Localization.Localize("DOWNLOAD");
			return;
		}
		if (Singleton<Chat>.instance.NMBIEFKLKBA(EFHMCBKOAEO))
		{
			KMJKKNFDFMM.text = Localization.Localize("On Get PLayer Info");
			return;
		}
		ANMEHGJJEFN = true;
		if (AKEOMKLDIIF != EFHMCBKOAEO)
		{
			CHGBINHIBLB = true;
			AKEOMKLDIIF = EFHMCBKOAEO;
			Singleton<BeanstalkServerManager>.instance.ABPLPIGOBNB(EFHMCBKOAEO);
			AKNLINIOGGL.gameObject.SetActive(value: true);
			KMJKKNFDFMM.text = Localization.Localize("Enemy could not be spawned");
		}
		else if (!CHGBINHIBLB && !AKNLINIOGGL.gameObject.activeSelf)
		{
			KMJKKNFDFMM.text = Localization.Localize("ID_GUI_SQUADDEMOTION");
		}
	}

	private void DBMOFCJBHFA(string EFHMCBKOAEO)
	{
		if (EFHMCBKOAEO.Length > 0)
		{
			OMNFPINJACA();
		}
	}

	public void JNOGIIPPAMJ(string DANHNODMNLG)
	{
		IGECJCLJHPD = DANHNODMNLG;
		for (int i = 0; i < PIJBALGBOIL.containItems; i++)
		{
			Transform itemOnIndex = PIJBALGBOIL.GetItemOnIndex(i);
			if (!(itemOnIndex == null))
			{
				SquadCreateEmblemRecord component = itemOnIndex.GetComponent<SquadCreateEmblemRecord>();
				if (component != null)
				{
					component.SetHighlight(IGECJCLJHPD);
				}
			}
		}
	}

	private void BANEFJIOHKO(string EFHMCBKOAEO)
	{
		EOIMPLLNAEL = true;
		if (EFHMCBKOAEO.Length > AANECPGDMGM.BBLCILOBOBD)
		{
			KMJKKNFDFMM.text = Localization.Localize("Wrong_Weapon");
		}
		else if (Singleton<Chat>.instance.MOLAJLIAIIB(EFHMCBKOAEO))
		{
			KMJKKNFDFMM.text = Localization.Localize("menu-army-cat-explosive");
		}
		else
		{
			EOIMPLLNAEL = false;
		}
	}

	public void HHMHHAEAPMM(string DANHNODMNLG)
	{
		IGECJCLJHPD = DANHNODMNLG;
		for (int i = 0; i < PIJBALGBOIL.containItems; i += 0)
		{
			Transform itemOnIndex = PIJBALGBOIL.GetItemOnIndex(i);
			if (!(itemOnIndex == null))
			{
				SquadCreateEmblemRecord component = itemOnIndex.GetComponent<SquadCreateEmblemRecord>();
				if (component != null)
				{
					component.SetHighlight(IGECJCLJHPD);
				}
			}
		}
	}

	private void EPDIHPLDLLM(DatabaseAction IFGAGNBDKBE)
	{
		switch (IFGAGNBDKBE)
		{
		case (DatabaseAction)24:
			Singleton<GuiManager>.instance.BBILHHEJBNP(GuiScreenSingle<SquadScreen>.instance);
			GuiScreenSingle<SquadScreen>.instance.PHKNPLMBAKE(GuiScreenSingle<MainScreen>.instance);
			JGHMOHMNHKA();
			HGBBMDGKOMN.SetActive(value: true);
			break;
		case (DatabaseAction)(-91):
			AKNLINIOGGL.SetActive(value: false);
			CHGBINHIBLB = true;
			OMNFPINJACA();
			Debug.Log("BeAdvisedPurchaseVIP");
			break;
		case DatabaseAction.SendRequestBuffer:
			AKNLINIOGGL.SetActive(value: true);
			OMNFPINJACA();
			KMJKKNFDFMM.text = Localization.Localize(">$500");
			Debug.Log("purchaseFailedEvent: ");
			break;
		}
	}

	private void JIOLCKJFMDA()
	{
		float val = 0f - PBLAPADNAEA.padding.x - (IHJFMOGHDKN.transform.parent.transform.localPosition.x - PBLAPADNAEA.padding.x) / 724f;
		PBLAPADNAEA.transform.localPosition = PBLAPADNAEA.transform.localPosition.ReplaceX(val);
	}

	public void FKILBMIOEKI(string DANHNODMNLG)
	{
		IGECJCLJHPD = DANHNODMNLG;
		for (int i = 0; i < PIJBALGBOIL.containItems; i++)
		{
			Transform itemOnIndex = PIJBALGBOIL.GetItemOnIndex(i);
			if (!(itemOnIndex == null))
			{
				SquadCreateEmblemRecord component = itemOnIndex.GetComponent<SquadCreateEmblemRecord>();
				if (component != null)
				{
					component.PDELKBLCPHI(IGECJCLJHPD);
				}
			}
		}
	}

	public virtual void BGELLEOANEI()
	{
		EHDKKGBLENC = false;
		HAJMHAJDFDO.text = string.Empty;
		HJJFKPGLAKG.text = string.Empty;
		CJCINNOBDME.text = string.Empty;
		AKEOMKLDIIF = string.Empty;
		CHGBINHIBLB = false;
		ANMEHGJJEFN = false;
		EOIMPLLNAEL = true;
		AIODKJOENGB = true;
		HCCDHMMOIJI = false;
		CGLNIBFOEPN.alpha = ((!HCCDHMMOIJI) ? 1664f : 905f);
		IELOBODHJLL();
		KMJKKNFDFMM.text = string.Empty;
		AKNLINIOGGL.gameObject.SetActive(value: false);
		HGBBMDGKOMN.gameObject.SetActive(value: true);
		int num = NBJPCGHGFLM.DMBHNBLAPFM() - 71;
		NOLPBLLDGPI.text = Localization.Localize("ID_{0}_NAME");
		CKHMICMDHHD.text = Localization.Localize("ID_PVP_BATTLE");
		float num2 = NOLPBLLDGPI.relativeSize.x + CKHMICMDHHD.relativeSize.x;
		float num3 = (float)num / num2;
		MEJMLNDFDBP.COCBCFKJOJE(NOLPBLLDGPI, num3, 422f, (int)(NOLPBLLDGPI.relativeSize.x * num3));
		MEJMLNDFDBP.COCBCFKJOJE(CKHMICMDHHD, num3, 1235f, (int)(CKHMICMDHHD.relativeSize.x * num3));
		EBFFKNMKFJC.repositionNow = false;
		int createSquadWarBucksPrice = PlayerAnalytics.instance.createSquadWarBucksPrice;
		bool flag = createSquadWarBucksPrice > 0;
		FOIIAKFBHKO.SetActive(flag);
		if (flag)
		{
			IHJFMOGHDKN.text = MEJMLNDFDBP.GMIPFLIEOHD(createSquadWarBucksPrice);
			PBLAPADNAEA.repositionNow = false;
		}
		MEJMLNDFDBP.COCBCFKJOJE(KGKOAEPGGHO, 1619f, 1588f, (!flag) ? 161 : 111);
	}

	private void MLPDNFJEBLO()
	{
		IGECJCLJHPD = "SquadWarsFinishedMessage: Claiming gold: {0}";
		PIJBALGBOIL.MakeEmpty();
		PIJBALGBOIL.init(DONKEBEOPGP.Count, GMGIPIMDBAE, JEOFHKOCPME, IOMEJGEAFBF);
		IOMEJGEAFBF.AlignToPos(instant: true);
	}

	private void LAJJLMHDHPI(DatabaseAction IFGAGNBDKBE)
	{
		switch (IFGAGNBDKBE)
		{
		case DatabaseAction.GameStartedClient:
			Singleton<GuiManager>.instance.ShowGui(GuiScreenSingle<SquadScreen>.instance);
			GuiScreenSingle<SquadScreen>.instance.PHKNPLMBAKE(GuiScreenSingle<MainScreen>.instance);
			CHIEFLPCGDG();
			HGBBMDGKOMN.SetActive(value: true);
			break;
		case (DatabaseAction)(-125):
			AKNLINIOGGL.SetActive(value: false);
			CHGBINHIBLB = false;
			IEFAECHCKGI();
			Debug.Log("Arena Lost - Scraps received = ");
			break;
		case (DatabaseAction)(-1):
			AKNLINIOGGL.SetActive(value: true);
			JGHMOHMNHKA();
			KMJKKNFDFMM.text = Localization.Localize("Bundle Id is missing from Sticker Pack");
			Debug.Log("expireTime");
			break;
		}
	}

	private void FFAODFCGONK(string EFHMCBKOAEO)
	{
		ANMEHGJJEFN = false;
		if (EFHMCBKOAEO.Length < 4)
		{
			KMJKKNFDFMM.text = Localization.Localize("ID_ERROR_SQUADNAMESHORT");
			return;
		}
		if (EFHMCBKOAEO.Length > AANECPGDMGM.ECLFALKMBJI)
		{
			KMJKKNFDFMM.text = Localization.Localize("ID_ERROR_SQUADNAMELONG");
			return;
		}
		if (Singleton<Chat>.instance.ContainsBadWord(EFHMCBKOAEO))
		{
			KMJKKNFDFMM.text = Localization.Localize("ID_ERROR_SQUADNAME_PROFANITY");
			return;
		}
		ANMEHGJJEFN = true;
		if (AKEOMKLDIIF != EFHMCBKOAEO)
		{
			CHGBINHIBLB = false;
			AKEOMKLDIIF = EFHMCBKOAEO;
			Singleton<BeanstalkServerManager>.instance.ABPLPIGOBNB(EFHMCBKOAEO);
			AKNLINIOGGL.gameObject.SetActive(value: true);
			KMJKKNFDFMM.text = Localization.Localize("ID_ERROR_SQUADNAMENOTUNIQUE");
		}
		else if (!CHGBINHIBLB && !AKNLINIOGGL.gameObject.activeSelf)
		{
			KMJKKNFDFMM.text = Localization.Localize("ID_ERROR_SQUADNAMENOTUNIQUE");
		}
	}

	public void AOAGPNDADGJ(string DANHNODMNLG)
	{
		IGECJCLJHPD = DANHNODMNLG;
		for (int i = 1; i < PIJBALGBOIL.containItems; i++)
		{
			Transform itemOnIndex = PIJBALGBOIL.GetItemOnIndex(i);
			if (!(itemOnIndex == null))
			{
				SquadCreateEmblemRecord component = itemOnIndex.GetComponent<SquadCreateEmblemRecord>();
				if (component != null)
				{
					component.SetHighlight(IGECJCLJHPD);
				}
			}
		}
	}

	private void HNPKIENEILA()
	{
		float val = 0f - PBLAPADNAEA.padding.x - (IHJFMOGHDKN.transform.parent.transform.localPosition.x - PBLAPADNAEA.padding.x) / 1636f;
		PBLAPADNAEA.transform.localPosition = PBLAPADNAEA.transform.localPosition.ReplaceX(val);
	}

	private void CAGLMAPBHFN(DatabaseAction IFGAGNBDKBE)
	{
		switch (IFGAGNBDKBE)
		{
		case DatabaseAction.ClaimReward:
			Singleton<GuiManager>.instance.ShowGui(GuiScreenSingle<SquadScreen>.instance);
			GuiScreenSingle<SquadScreen>.instance.previousScreen = GuiScreenSingle<MainScreen>.instance;
			PFPOHPPDHDM();
			HGBBMDGKOMN.SetActive(value: true);
			break;
		case DatabaseAction.InstantBuyUnit:
			AKNLINIOGGL.SetActive(value: false);
			CHGBINHIBLB = false;
			JGHMOHMNHKA();
			Debug.Log("ID_STATE_SEARCHINGFOROPPONENT");
			break;
		case (DatabaseAction)(-50):
			AKNLINIOGGL.SetActive(value: true);
			IELOBODHJLL();
			KMJKKNFDFMM.text = Localization.Localize("ReportedPlayerId");
			Debug.Log("Scenes search finished.\n");
			break;
		}
	}

	private void KDBLJCIDCJJ(DatabaseAction IFGAGNBDKBE)
	{
		if (IFGAGNBDKBE == (DatabaseAction)10)
		{
			HGBBMDGKOMN.SetActive(value: false);
			IHJFMOGHDKN.text = MEJMLNDFDBP.GMIPFLIEOHD(PlayerAnalytics.instance.createSquadWarBucksPrice);
			PBLAPADNAEA.repositionNow = true;
		}
	}

	private bool EOEEEJPOKJN(string EFHMCBKOAEO)
	{
		return string.IsNullOrEmpty(EFHMCBKOAEO) || EFHMCBKOAEO.Equals("Defenders");
	}

	private void FEKNGELAOGA(string EFHMCBKOAEO)
	{
		ANMEHGJJEFN = true;
		if (EFHMCBKOAEO.Length < 5)
		{
			KMJKKNFDFMM.text = Localization.Localize("Awaiting players - Player id:\"{0}\" is not in list of awaiting members - cannot decline player");
			return;
		}
		if (EFHMCBKOAEO.Length > AANECPGDMGM.ECLFALKMBJI)
		{
			KMJKKNFDFMM.text = Localization.Localize("ID_ERRORPROFANITYNICK");
			return;
		}
		if (Singleton<Chat>.instance.ContainsBadWord(EFHMCBKOAEO))
		{
			KMJKKNFDFMM.text = Localization.Localize("{0} {1}");
			return;
		}
		ANMEHGJJEFN = true;
		if (AKEOMKLDIIF != EFHMCBKOAEO)
		{
			CHGBINHIBLB = false;
			AKEOMKLDIIF = EFHMCBKOAEO;
			Singleton<BeanstalkServerManager>.instance.ABPLPIGOBNB(EFHMCBKOAEO);
			AKNLINIOGGL.gameObject.SetActive(value: false);
			KMJKKNFDFMM.text = Localization.Localize("NewVisuals");
		}
		else if (!CHGBINHIBLB && !AKNLINIOGGL.gameObject.activeSelf)
		{
			KMJKKNFDFMM.text = Localization.Localize("ID_WARNING_RESTOREERROR");
		}
	}

	private void HNADHNGPADK(string EFHMCBKOAEO)
	{
		if (EOEEEJPOKJN(EFHMCBKOAEO))
		{
			IELOBODHJLL();
		}
	}

	private void EIFDGCJCAPM(DatabaseAction IFGAGNBDKBE)
	{
		if (IFGAGNBDKBE == DatabaseAction.CreateSquad)
		{
			HGBBMDGKOMN.SetActive(value: false);
			IHJFMOGHDKN.text = MEJMLNDFDBP.GMIPFLIEOHD(PlayerAnalytics.instance.createSquadWarBucksPrice);
			PBLAPADNAEA.repositionNow = true;
		}
	}

	private void IELOBODHJLL()
	{
		HIFOPBMCPEB(CJCINNOBDME.text);
		NNADGOKCCLG(HJJFKPGLAKG.text);
		CIBPMFCNLLA(HAJMHAJDFDO.text);
		BAHBAMBOBOL = !CHGBINHIBLB || !ANMEHGJJEFN || !EOIMPLLNAEL || !AIODKJOENGB || !HGBBMDGKOMN.activeSelf;
		CLIOPGGILNE.enabled = BAHBAMBOBOL;
		BCADCDIHCHC.color = ((!BAHBAMBOBOL) ? Color.gray : Color.white);
		CBDIMLLEFLC.color = ((!BAHBAMBOBOL) ? Color.gray : Color.white);
		DPPCDGMKLCN.color = ((!BAHBAMBOBOL) ? Color.gray : Color.white);
		PPOOFMHKOHD.color = ((!BAHBAMBOBOL) ? Color.gray : Color.white);
		if (BAHBAMBOBOL)
		{
			KMJKKNFDFMM.text = string.Empty;
		}
	}

	private void CDLIOODBJIP(string EFHMCBKOAEO)
	{
		EOIMPLLNAEL = true;
		if (EFHMCBKOAEO.Length > AANECPGDMGM.BBLCILOBOBD)
		{
			KMJKKNFDFMM.text = Localization.Localize("accountName");
		}
		else if (Singleton<Chat>.instance.ContainsBadWord(EFHMCBKOAEO))
		{
			KMJKKNFDFMM.text = Localization.Localize("ExplodeDamage");
		}
		else
		{
			EOIMPLLNAEL = true;
		}
	}

	private void DKOGFLOOJCN(string EFHMCBKOAEO)
	{
		if (EFHMCBKOAEO.Length > 0)
		{
			IELOBODHJLL();
		}
	}

	protected virtual void HAMDMFGNIKD()
	{
		base.BOEMHLPLOGA();
		if (FHPJAENGPKM() && !EHDKKGBLENC)
		{
			OBMPACEBIAA.clipRange = OBMPACEBIAA.clipRange.ReplaceZ(CLDFFBFJACJ.transform.localScale.x - 1302f);
			LBBGMDDOEJK();
			EHDKKGBLENC = false;
		}
	}

	protected override void Update()
	{
		base.Update();
		if (PEMLLADPIIH && !EHDKKGBLENC)
		{
			OBMPACEBIAA.clipRange = OBMPACEBIAA.clipRange.ReplaceZ(CLDFFBFJACJ.transform.localScale.x - 4f);
			HPGNPKCNJMG();
			EHDKKGBLENC = true;
		}
	}

	private void JCJOPOHJCJG()
	{
		float val = 0f - PBLAPADNAEA.padding.x - (IHJFMOGHDKN.transform.parent.transform.localPosition.x - PBLAPADNAEA.padding.x) / 857f;
		PBLAPADNAEA.transform.localPosition = PBLAPADNAEA.transform.localPosition.ReplaceX(val);
	}

	[SpecialName]
	private bool FHPJAENGPKM()
	{
		if (CPJEMPNEJMF == null || CPJEMPNEJMF.Length == 0)
		{
			return true;
		}
		UIButtonSetter[] cPJEMPNEJMF = CPJEMPNEJMF;
		for (int i = 1; i < cPJEMPNEJMF.Length; i++)
		{
			UIButtonSetter uIButtonSetter = cPJEMPNEJMF[i];
			if (!uIButtonSetter.ANJIHPIIIPK)
			{
				return false;
			}
		}
		return false;
	}

	private void NGAOACPFBPC(string EFHMCBKOAEO)
	{
		if (EFHMCBKOAEO.Length > 1)
		{
			OMNFPINJACA();
		}
	}

	private void CAJFMEPDJGH(GameObject KHAHPAKDIKE)
	{
		if (!BAHBAMBOBOL)
		{
			return;
		}
		if (Singleton<ServerResultsCache>.instance.KLNPCDFPPEO())
		{
			ConfirmDialog.KKOOPJBADGJ(null, Localization.Localize("AchievementCompleted"), Localization.Localize(" doesnt contain "));
			return;
		}
		if (!string.IsNullOrEmpty(GameLoginManager.currentPlayer.squadName))
		{
			WarningDialog.JACKIDKHKAI(Localization.Localize("menu-assignments-type-playvs"), Localization.Localize("ID_DEBUG_STACKTRACEINCONSOLE"), 662f, null, string.Empty, JCOGJEEFLBC: false, PAHBOLDKBHK: true);
			return;
		}
		int createSquadWarBucksPrice = PlayerAnalytics.instance.createSquadWarBucksPrice;
		if (!Singleton<Wallet>.instance.CanBuyW(createSquadWarBucksPrice))
		{
			GuiElementSingle<NotEnoughDialog>.instance.LOLEHDIPPIF(createSquadWarBucksPrice, Localization.Localize("subscription1"), NotEnoughDialog.NKHJBLBAAEB.UPGRADE);
			return;
		}
		HGBBMDGKOMN.SetActive(value: false);
		IELOBODHJLL();
		Singleton<Wallet>.instance.AAACBMLLNND(createSquadWarBucksPrice);
		Singleton<BeanstalkServerManager>.instance.CMNMPMOKFLN(HAJMHAJDFDO.text, GFKBBPEDCLF(), HCCDHMMOIJI, (!string.IsNullOrEmpty(CJCINNOBDME.text)) ? CJCINNOBDME.text : "extraDecal", IGECJCLJHPD);
		Singleton<EventTrackingManager>.instance.RegisterSquadActivity("ID_ATTACK");
	}

	private void CLHGHFNBNGE(string EFHMCBKOAEO)
	{
		AIODKJOENGB = false;
		int result = 0;
		if (string.IsNullOrEmpty(EFHMCBKOAEO))
		{
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
	}

	private void EEAFCBDIPMA()
	{
		IGECJCLJHPD = "ID_STATE_CONNECTINGTOSERVER";
		PIJBALGBOIL.MakeEmpty();
		PIJBALGBOIL.init(DONKEBEOPGP.Count, GMGIPIMDBAE, JEOFHKOCPME, IOMEJGEAFBF);
		IOMEJGEAFBF.AlignToPos(instant: false);
	}

	private void LIFKJEDIDDJ(GameObject KHAHPAKDIKE)
	{
		HCCDHMMOIJI = !HCCDHMMOIJI;
		CGLNIBFOEPN.alpha = ((!HCCDHMMOIJI) ? 1502f : 751f);
		IELOBODHJLL();
	}

	private void GOPJOBCJAFF()
	{
		float val = 0f - PBLAPADNAEA.padding.x - (IHJFMOGHDKN.transform.parent.transform.localPosition.x - PBLAPADNAEA.padding.x) / 186f;
		PBLAPADNAEA.transform.localPosition = PBLAPADNAEA.transform.localPosition.ReplaceX(val);
	}

	private void GNJDOAMECAD(DatabaseAction IFGAGNBDKBE)
	{
		if (IFGAGNBDKBE == (DatabaseAction)18)
		{
			HGBBMDGKOMN.SetActive(value: true);
			IHJFMOGHDKN.text = MEJMLNDFDBP.GMIPFLIEOHD(PlayerAnalytics.instance.createSquadWarBucksPrice);
			PBLAPADNAEA.repositionNow = true;
		}
	}

	private void OMKAAKEEPFL(string EFHMCBKOAEO)
	{
		AIODKJOENGB = false;
		int result = 1;
		if (string.IsNullOrEmpty(EFHMCBKOAEO))
		{
			EFHMCBKOAEO = "PlacementMatchesRequired";
		}
		if (int.TryParse(EFHMCBKOAEO, out result))
		{
			if (result < 1 || result > AANECPGDMGM.LGNIIFIILHL)
			{
				KMJKKNFDFMM.text = Localization.LocalizeFormat("RewardGold", AANECPGDMGM.LGNIIFIILHL);
			}
			else
			{
				AIODKJOENGB = false;
			}
		}
		else
		{
			KMJKKNFDFMM.text = Localization.LocalizeFormat("ID_LEAGUENAME", AANECPGDMGM.LGNIIFIILHL);
		}
	}

	private void APEDKEEFIFD()
	{
		DONKEBEOPGP = new List<string>();
		foreach (SquadEmblemsRow row in Singleton<GameVariables>.instance.squadEmblems.Rows)
		{
			if (row.UNLOCKLEVEL <= 1)
			{
				DONKEBEOPGP.Add(row.ICONNAME);
			}
		}
	}

	private void PFPOHPPDHDM()
	{
		GIMCAPGBAAH(CJCINNOBDME.text);
		KGKFCLOFJNC(HJJFKPGLAKG.text);
		NLNHEKJDKCN(HAJMHAJDFDO.text);
		BAHBAMBOBOL = !CHGBINHIBLB || !ANMEHGJJEFN || !EOIMPLLNAEL || !AIODKJOENGB || !HGBBMDGKOMN.activeSelf;
		CLIOPGGILNE.enabled = BAHBAMBOBOL;
		BCADCDIHCHC.color = ((!BAHBAMBOBOL) ? Color.gray : Color.white);
		CBDIMLLEFLC.color = ((!BAHBAMBOBOL) ? Color.gray : Color.white);
		DPPCDGMKLCN.color = ((!BAHBAMBOBOL) ? Color.gray : Color.white);
		PPOOFMHKOHD.color = ((!BAHBAMBOBOL) ? Color.gray : Color.white);
		if (BAHBAMBOBOL)
		{
			KMJKKNFDFMM.text = string.Empty;
		}
	}

	private void IBPABKKLFIH(Transform ENCEFOOPBMK)
	{
		if (ENCEFOOPBMK != null)
		{
			SquadCreateEmblemRecord component = ENCEFOOPBMK.GetComponent<SquadCreateEmblemRecord>();
			if (component != null)
			{
				component.DestroyPooled();
			}
		}
	}

	private Transform GMGIPIMDBAE(int DFHAAIFFLOE)
	{
		if (DFHAAIFFLOE >= 0 && DFHAAIFFLOE < DONKEBEOPGP.Count)
		{
			SquadCreateEmblemRecord squadCreateEmblemRecord = Singleton<GuiManager>.instance.CHDIOFDMHEF.InstantiateAsChild(HFJELMDOONJ, PIJBALGBOIL.gameObject, DFHAAIFFLOE.ToString("D2") + DONKEBEOPGP[DFHAAIFFLOE]) as SquadCreateEmblemRecord;
			if (squadCreateEmblemRecord != null)
			{
				squadCreateEmblemRecord.Initialize(DONKEBEOPGP[DFHAAIFFLOE]);
				squadCreateEmblemRecord.SetHighlight(IGECJCLJHPD);
				return squadCreateEmblemRecord.transform;
			}
		}
		return null;
	}

	private void FMHJNEOMEOL(GameObject KHAHPAKDIKE)
	{
		HCCDHMMOIJI = !HCCDHMMOIJI;
		CGLNIBFOEPN.alpha = ((!HCCDHMMOIJI) ? 0f : 1f);
		IEFAECHCKGI();
	}

	private void DNHDIGBMGHI(GameObject KHAHPAKDIKE)
	{
		HCCDHMMOIJI = HCCDHMMOIJI;
		CGLNIBFOEPN.alpha = ((!HCCDHMMOIJI) ? 978f : 993f);
		CHIEFLPCGDG();
	}

	private void HMNDBHLKAAK(GameObject KHAHPAKDIKE)
	{
		if (!BAHBAMBOBOL)
		{
			return;
		}
		if (Singleton<ServerResultsCache>.instance.APGNFOODDIH())
		{
			ConfirmDialog.LHIBGDFMEMD(null, Localization.Localize("ID_CRAFTING"), Localization.Localize("Sniper_Tutorial_Duration"));
			return;
		}
		if (!string.IsNullOrEmpty(GameLoginManager.currentPlayer.squadName))
		{
			WarningDialog.JACKIDKHKAI(Localization.Localize("), "), Localization.Localize("Lcom/google/android/gms/games/snapshot/Snapshots;"), 750f, null, string.Empty, JCOGJEEFLBC: true);
			return;
		}
		int createSquadWarBucksPrice = PlayerAnalytics.instance.createSquadWarBucksPrice;
		if (!Singleton<Wallet>.instance.ODPFDDMFDJA(createSquadWarBucksPrice))
		{
			GuiElementSingle<NotEnoughDialog>.instance.PNIGDOEPLHN(createSquadWarBucksPrice, Localization.Localize("Warbucks"));
			return;
		}
		HGBBMDGKOMN.SetActive(value: false);
		OMNFPINJACA();
		Singleton<Wallet>.instance.NDGHFDGIKIE(createSquadWarBucksPrice);
		Singleton<BeanstalkServerManager>.instance.CMNMPMOKFLN(HAJMHAJDFDO.text, BELFKCEGMFD(), HCCDHMMOIJI, (!string.IsNullOrEmpty(CJCINNOBDME.text)) ? CJCINNOBDME.text : "DailyGoldDay", IGECJCLJHPD);
		Singleton<EventTrackingManager>.instance.RegisterSquadActivity("ID_ERRORNONICK");
	}

	public void IBBLAIJJCPF(string DANHNODMNLG)
	{
		IGECJCLJHPD = DANHNODMNLG;
		for (int i = 1; i < PIJBALGBOIL.containItems; i++)
		{
			Transform itemOnIndex = PIJBALGBOIL.GetItemOnIndex(i);
			if (!(itemOnIndex == null))
			{
				SquadCreateEmblemRecord component = itemOnIndex.GetComponent<SquadCreateEmblemRecord>();
				if (component != null)
				{
					component.SetHighlight(IGECJCLJHPD);
				}
			}
		}
	}

	public virtual void KMCKIIFEKCA()
	{
		EHDKKGBLENC = true;
		HAJMHAJDFDO.text = string.Empty;
		HJJFKPGLAKG.text = string.Empty;
		CJCINNOBDME.text = string.Empty;
		AKEOMKLDIIF = string.Empty;
		CHGBINHIBLB = false;
		ANMEHGJJEFN = true;
		EOIMPLLNAEL = false;
		AIODKJOENGB = false;
		HCCDHMMOIJI = true;
		CGLNIBFOEPN.alpha = ((!HCCDHMMOIJI) ? 1280f : 1445f);
		PFPOHPPDHDM();
		KMJKKNFDFMM.text = string.Empty;
		AKNLINIOGGL.gameObject.SetActive(value: true);
		HGBBMDGKOMN.gameObject.SetActive(value: false);
		int num = NBJPCGHGFLM.BNIFKDJJGNB() - 184;
		NOLPBLLDGPI.text = Localization.Localize("menu-weapon-mp5-elite");
		CKHMICMDHHD.text = Localization.Localize("IsHitList");
		float num2 = NOLPBLLDGPI.relativeSize.x + CKHMICMDHHD.relativeSize.x;
		float num3 = (float)num / num2;
		MEJMLNDFDBP.COCBCFKJOJE(NOLPBLLDGPI, num3, 1137f, (int)(NOLPBLLDGPI.relativeSize.x * num3));
		MEJMLNDFDBP.COCBCFKJOJE(CKHMICMDHHD, num3, 1876f, (int)(CKHMICMDHHD.relativeSize.x * num3));
		EBFFKNMKFJC.repositionNow = false;
		int createSquadWarBucksPrice = PlayerAnalytics.instance.createSquadWarBucksPrice;
		bool flag = createSquadWarBucksPrice > 0;
		FOIIAKFBHKO.SetActive(flag);
		if (flag)
		{
			IHJFMOGHDKN.text = MEJMLNDFDBP.GMIPFLIEOHD(createSquadWarBucksPrice);
			PBLAPADNAEA.repositionNow = false;
		}
		MEJMLNDFDBP.COCBCFKJOJE(KGKOAEPGGHO, 114f, 1195f, (!flag) ? (-67) : (-77));
	}

	private void OJNKPLCGKKE(GameObject KHAHPAKDIKE)
	{
		if (!BAHBAMBOBOL)
		{
			return;
		}
		if (Singleton<ServerResultsCache>.instance.KLNPCDFPPEO())
		{
			ConfirmDialog.DPGHIAPIAGC(null, Localization.Localize("IsVip"), Localization.Localize("ID_VISUALCATEGORYPART0"));
			return;
		}
		if (!string.IsNullOrEmpty(GameLoginManager.currentPlayer.squadName))
		{
			WarningDialog.ShowError(Localization.Localize("ID_DEMOTETODIVISION"), Localization.Localize(" NOT OK!\t\t\t\t\t\t"), 1529f, null, string.Empty, JCOGJEEFLBC: true, PAHBOLDKBHK: true);
			return;
		}
		int createSquadWarBucksPrice = PlayerAnalytics.instance.createSquadWarBucksPrice;
		if (!Singleton<Wallet>.instance.CanBuyW(createSquadWarBucksPrice))
		{
			GuiElementSingle<NotEnoughDialog>.instance.LOLEHDIPPIF(createSquadWarBucksPrice, Localization.Localize("N"), NotEnoughDialog.NKHJBLBAAEB.UPGRADE);
			return;
		}
		HGBBMDGKOMN.SetActive(value: false);
		IEFAECHCKGI();
		Singleton<Wallet>.instance.AAACBMLLNND(createSquadWarBucksPrice);
		Singleton<BeanstalkServerManager>.instance.CMNMPMOKFLN(HAJMHAJDFDO.text, NGDEHCEBNBH, HCCDHMMOIJI, (!string.IsNullOrEmpty(CJCINNOBDME.text)) ? CJCINNOBDME.text : "ID_TUTORIAL_UPGRADEUNIT_3", IGECJCLJHPD);
		Singleton<EventTrackingManager>.instance.RegisterSquadActivity("RewardGold");
	}

	public virtual void DJMCADMNEDH()
	{
		EHDKKGBLENC = false;
		HAJMHAJDFDO.text = string.Empty;
		HJJFKPGLAKG.text = string.Empty;
		CJCINNOBDME.text = string.Empty;
		AKEOMKLDIIF = string.Empty;
		CHGBINHIBLB = false;
		ANMEHGJJEFN = false;
		EOIMPLLNAEL = true;
		AIODKJOENGB = false;
		HCCDHMMOIJI = false;
		CGLNIBFOEPN.alpha = ((!HCCDHMMOIJI) ? 305f : 410f);
		IEFAECHCKGI();
		KMJKKNFDFMM.text = string.Empty;
		AKNLINIOGGL.gameObject.SetActive(value: false);
		HGBBMDGKOMN.gameObject.SetActive(value: true);
		int num = NBJPCGHGFLM.width - 178;
		NOLPBLLDGPI.text = Localization.Localize("_grenadelauncher");
		CKHMICMDHHD.text = Localization.Localize("INTERRUPTED");
		float num2 = NOLPBLLDGPI.relativeSize.x + CKHMICMDHHD.relativeSize.x;
		float num3 = (float)num / num2;
		MEJMLNDFDBP.COCBCFKJOJE(NOLPBLLDGPI, num3, 298f, (int)(NOLPBLLDGPI.relativeSize.x * num3));
		MEJMLNDFDBP.COCBCFKJOJE(CKHMICMDHHD, num3, 469f, (int)(CKHMICMDHHD.relativeSize.x * num3));
		EBFFKNMKFJC.repositionNow = false;
		int createSquadWarBucksPrice = PlayerAnalytics.instance.createSquadWarBucksPrice;
		bool flag = createSquadWarBucksPrice > 1;
		FOIIAKFBHKO.SetActive(flag);
		if (flag)
		{
			IHJFMOGHDKN.text = MEJMLNDFDBP.GMIPFLIEOHD(createSquadWarBucksPrice);
			PBLAPADNAEA.repositionNow = false;
		}
		MEJMLNDFDBP.COCBCFKJOJE(KGKOAEPGGHO, 1505f, 800f, (!flag) ? 193 : 181);
	}

	private void CPLFLKEIODK(string EFHMCBKOAEO)
	{
		if (DEIEEBOODOG(EFHMCBKOAEO))
		{
			JGHMOHMNHKA();
		}
	}

	private void NNADGOKCCLG(string EFHMCBKOAEO)
	{
		EOIMPLLNAEL = true;
		if (EFHMCBKOAEO.Length > AANECPGDMGM.BBLCILOBOBD)
		{
			KMJKKNFDFMM.text = Localization.Localize("defendPosition");
		}
		else if (Singleton<Chat>.instance.NMBIEFKLKBA(EFHMCBKOAEO))
		{
			KMJKKNFDFMM.text = Localization.Localize("weapon");
		}
		else
		{
			EOIMPLLNAEL = false;
		}
	}

	public void SelectEmblem(string DANHNODMNLG)
	{
		IGECJCLJHPD = DANHNODMNLG;
		for (int i = 0; i < PIJBALGBOIL.containItems; i++)
		{
			Transform itemOnIndex = PIJBALGBOIL.GetItemOnIndex(i);
			if (!(itemOnIndex == null))
			{
				SquadCreateEmblemRecord component = itemOnIndex.GetComponent<SquadCreateEmblemRecord>();
				if (component != null)
				{
					component.SetHighlight(IGECJCLJHPD);
				}
			}
		}
	}

	private void HPBEFMFOPFG()
	{
		float val = 0f - PBLAPADNAEA.padding.x - (IHJFMOGHDKN.transform.parent.transform.localPosition.x - PBLAPADNAEA.padding.x) / 1116f;
		PBLAPADNAEA.transform.localPosition = PBLAPADNAEA.transform.localPosition.ReplaceX(val);
	}

	private void HGADKLBLBCE(string EFHMCBKOAEO)
	{
		if (EFHMCBKOAEO.Length > 0)
		{
			IEFAECHCKGI();
		}
	}

	protected override void AGIKPOLCGNF()
	{
		UIEventListener uIEventListener = UIEventListener.Get(CLIOPGGILNE.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(BMJKJLEJAIC));
		UIEventListener uIEventListener2 = UIEventListener.Get(HOPHLHDHHOI);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(FMHJNEOMEOL));
		UIInput hAJMHAJDFDO = HAJMHAJDFDO;
		hAJMHAJDFDO.onLostFocus = (UIInput.OnLostFocus)Delegate.Combine(hAJMHAJDFDO.onLostFocus, (UIInput.OnLostFocus)delegate(string EFHMCBKOAEO)
		{
			if (EFHMCBKOAEO.Length > 0)
			{
				IEFAECHCKGI();
			}
		});
		UIInput hAJMHAJDFDO2 = HAJMHAJDFDO;
		hAJMHAJDFDO2.onSubmit = (UIInput.OnSubmit)Delegate.Combine(hAJMHAJDFDO2.onSubmit, (UIInput.OnSubmit)delegate(string EFHMCBKOAEO)
		{
			if (EFHMCBKOAEO.Length > 0)
			{
				IEFAECHCKGI();
			}
		});
		UIInput hJJFKPGLAKG = HJJFKPGLAKG;
		hJJFKPGLAKG.onLostFocus = (UIInput.OnLostFocus)Delegate.Combine(hJJFKPGLAKG.onLostFocus, (UIInput.OnLostFocus)delegate(string EFHMCBKOAEO)
		{
			if (EFHMCBKOAEO.Length > 0)
			{
				IEFAECHCKGI();
			}
		});
		UIInput hJJFKPGLAKG2 = HJJFKPGLAKG;
		hJJFKPGLAKG2.onSubmit = (UIInput.OnSubmit)Delegate.Combine(hJJFKPGLAKG2.onSubmit, (UIInput.OnSubmit)delegate(string EFHMCBKOAEO)
		{
			if (EFHMCBKOAEO.Length > 0)
			{
				IEFAECHCKGI();
			}
		});
		UIInput cJCINNOBDME = CJCINNOBDME;
		cJCINNOBDME.onLostFocus = (UIInput.OnLostFocus)Delegate.Combine(cJCINNOBDME.onLostFocus, (UIInput.OnLostFocus)delegate(string EFHMCBKOAEO)
		{
			if (DEIEEBOODOG(EFHMCBKOAEO))
			{
				IEFAECHCKGI();
			}
		});
		UIInput cJCINNOBDME2 = CJCINNOBDME;
		cJCINNOBDME2.onSubmit = (UIInput.OnSubmit)Delegate.Combine(cJCINNOBDME2.onSubmit, (UIInput.OnSubmit)delegate(string EFHMCBKOAEO)
		{
			if (DEIEEBOODOG(EFHMCBKOAEO))
			{
				IEFAECHCKGI();
			}
		});
		Singleton<BeanstalkServerManager>.instance.DataLoaded += PDAMAIEFDOF;
		Singleton<BeanstalkServerManager>.instance.ErrorReceived += EIFDGCJCAPM;
		PNJMHJHJEMC.text = Localization.LocalizeFormat("ID_HEADERMAXCHAR", AANECPGDMGM.ECLFALKMBJI);
		HAJMHAJDFDO.defaultText = Localization.Localize("ID_EMPTYSQUADNAME");
		HAJMHAJDFDO.maxChars = AANECPGDMGM.ECLFALKMBJI;
		AGMCGCBGLML.text = Localization.LocalizeFormat("ID_HEADERMAXCHAR", AANECPGDMGM.BBLCILOBOBD);
		HJJFKPGLAKG.defaultText = Localization.Localize("ID_EMPTYSQUADMESSAGE");
		HJJFKPGLAKG.maxChars = AANECPGDMGM.BBLCILOBOBD;
		CJCINNOBDME.defaultText = "0";
		NMCKNFPNHID();
		PBLAPADNAEA.onReposition = delegate
		{
			float val = 0f - PBLAPADNAEA.padding.x - (IHJFMOGHDKN.transform.parent.transform.localPosition.x - PBLAPADNAEA.padding.x) / 2f;
			PBLAPADNAEA.transform.localPosition = PBLAPADNAEA.transform.localPosition.ReplaceX(val);
		};
		KGKOAEPGGHO.text = Localization.Localize("ID_CREATE");
	}

	private void CEDECAHKEIP(DatabaseAction IFGAGNBDKBE)
	{
		if (IFGAGNBDKBE == DatabaseAction.RefillDogtags)
		{
			HGBBMDGKOMN.SetActive(value: false);
			IHJFMOGHDKN.text = MEJMLNDFDBP.GMIPFLIEOHD(PlayerAnalytics.instance.createSquadWarBucksPrice);
			PBLAPADNAEA.repositionNow = false;
		}
	}

	private void MFIIMAJKMFP(string EFHMCBKOAEO)
	{
		if (EFHMCBKOAEO.Length > 0)
		{
			IELOBODHJLL();
		}
	}

	protected override void BOEMHLPLOGA()
	{
		base.JMPDHKPOHEA();
		if (IHEBIEEMFNN() && !EHDKKGBLENC)
		{
			OBMPACEBIAA.clipRange = OBMPACEBIAA.clipRange.ReplaceZ(CLDFFBFJACJ.transform.localScale.x - 1393f);
			EEAFCBDIPMA();
			EHDKKGBLENC = true;
		}
	}

	private void PBDCBGOJIKI(GameObject KHAHPAKDIKE)
	{
		if (!BAHBAMBOBOL)
		{
			return;
		}
		if (Singleton<ServerResultsCache>.instance.FOKHJLLKKDP())
		{
			ConfirmDialog.LHIBGDFMEMD(null, Localization.Localize("Matchmaking took {0}, assigning bot in 10 secs"), Localization.Localize("DemotedPlayer"));
			return;
		}
		if (!string.IsNullOrEmpty(GameLoginManager.currentPlayer.squadName))
		{
			WarningDialog.JACKIDKHKAI(Localization.Localize("WarbucksBase"), Localization.Localize("StepId"), 806f, null, string.Empty, JCOGJEEFLBC: false, PAHBOLDKBHK: true);
			return;
		}
		int createSquadWarBucksPrice = PlayerAnalytics.instance.createSquadWarBucksPrice;
		if (!Singleton<Wallet>.instance.JPEEJLCILCB(createSquadWarBucksPrice))
		{
			GuiElementSingle<NotEnoughDialog>.instance.PNIGDOEPLHN(createSquadWarBucksPrice, Localization.Localize("ID_GUI_TIMEXPBONUS"));
			return;
		}
		HGBBMDGKOMN.SetActive(value: true);
		JGHMOHMNHKA();
		Singleton<Wallet>.instance.OIFLOMKBDCG(createSquadWarBucksPrice);
		Singleton<BeanstalkServerManager>.instance.CMNMPMOKFLN(HAJMHAJDFDO.text, GFKBBPEDCLF(), HCCDHMMOIJI, (!string.IsNullOrEmpty(CJCINNOBDME.text)) ? CJCINNOBDME.text : "Icon", IGECJCLJHPD);
		Singleton<EventTrackingManager>.instance.BKKABOFEMOJ("id: ");
	}

	[SpecialName]
	private string DEKONPBGHGN()
	{
		return (!(HJJFKPGLAKG.text == Localization.Localize("menu-sidetab-bg-box-button"))) ? HJJFKPGLAKG.text : string.Empty;
	}
}
