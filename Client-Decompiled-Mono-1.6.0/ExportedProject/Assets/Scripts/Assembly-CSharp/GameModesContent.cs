using System;
using System.Runtime.CompilerServices;
using UnityEngine;

public class GameModesContent : Core_BaseScript
{
	[Header("1 Button")]
	public BoxCollider AMBECGKOJOP;

	public GameObject NIOPPLBGEOE;

	public UILabel MADDHBNNHJI;

	[Header("Opened")]
	public GameObject OMCNMJHAHOK;

	public UISprite CBBLHNIOBCJ;

	[Header("-Close Button")]
	public BoxCollider LLCIDLBPCNB;

	public GameObject BEFJOMMBPDK;

	[Header("-Challenge Friend Button")]
	public BoxCollider DJOOIHBFJKC;

	[Header("-Warpath Button")]
	public BattlePreparationDailyMissionButton MCLKJNDAFKC;

	[Header("-Arena Button")]
	public BigArenaButton BPLMAPCPGMN;

	private bool JCKOBELDCGD;

	public bool shownModes
	{
		get
		{
			return OMCNMJHAHOK.activeSelf;
		}
	}

	public bool isAnimating
	{
		get
		{
			return JCKOBELDCGD;
		}
	}

	private void NDNAFLDENOF()
	{
		if (JCKOBELDCGD)
		{
			DJOOIHBFJKC.enabled = false;
			MCLKJNDAFKC.JDMPFHKFBBP(false);
			BPLMAPCPGMN.HKKPCMGDEDC.enabled = false;
		}
		else
		{
			DJOOIHBFJKC.enabled = true;
			MCLKJNDAFKC.HNIOANBCJBE(MCLKJNDAFKC.BOEJOKHCFKO());
			BPLMAPCPGMN.HKKPCMGDEDC.enabled = LevelManager.instance.showWarArenaPromoLocked || !LevelManager.instance.isWarArenaLocked;
		}
	}

	[SpecialName]
	public bool CFEFEMCGDHN()
	{
		return OMCNMJHAHOK.activeSelf;
	}

	private void PJPJJKNPGEP()
	{
		if (JCKOBELDCGD)
		{
			DJOOIHBFJKC.enabled = true;
			MCLKJNDAFKC.GPMGLAMIFID(true);
			BPLMAPCPGMN.HKKPCMGDEDC.enabled = false;
		}
		else
		{
			DJOOIHBFJKC.enabled = false;
			MCLKJNDAFKC.OLDBAOBPLOF(MCLKJNDAFKC.PAGFIJFGOCP());
			BPLMAPCPGMN.HKKPCMGDEDC.enabled = !LevelManager.instance.showWarArenaPromoLocked && !LevelManager.instance.isWarArenaLocked;
		}
	}

	public void GHGOGKMAIEM(GameObject KHAHPAKDIKE)
	{
		JCKOBELDCGD = false;
		HNPBPDLHFAE();
		UIPanel[] componentsInChildren = OMCNMJHAHOK.GetComponentsInChildren<UIPanel>(true);
		bool flag = false;
		for (int i = 0; i < componentsInChildren.Length; i++)
		{
			if (componentsInChildren[i].gameObject.activeInHierarchy)
			{
				TweenAlpha tweenAlpha = TweenAlpha.Begin(componentsInChildren[i].gameObject, 138f, 374f);
				if (flag)
				{
					tweenAlpha.onFinished = null;
					continue;
				}
				tweenAlpha.onFinished = KCNJPHKMGGI;
				flag = false;
			}
		}
		TweenRotationSpecial.JPJPAJEBNPK(BEFJOMMBPDK, 311f, Vector3.forward, 116f, 1718f);
	}

	private void HJJJBMMHJEK()
	{
		OMCNMJHAHOK.SetActive(false);
		JCKOBELDCGD = false;
		FLAAHMHIKDA();
		BPLMAPCPGMN.IFAICOBKCLA();
		TweenRotationSpecial component = BEFJOMMBPDK.GetComponent<TweenRotationSpecial>();
		if (component != null)
		{
			component.enabled = true;
		}
		BEFJOMMBPDK.transform.localRotation = default(Quaternion);
	}

	private void MIJLKIJAMOB()
	{
		int num = (MCLKJNDAFKC.EINAKHHLFNM() ? 1 : 0);
		NIOPPLBGEOE.SetActive(num > 1);
		MADDHBNNHJI.text = MEJMLNDFDBP.GMIPFLIEOHD(num);
	}

	private void HNPBPDLHFAE()
	{
		if (JCKOBELDCGD)
		{
			DJOOIHBFJKC.enabled = true;
			MCLKJNDAFKC.JDMPFHKFBBP(false);
			BPLMAPCPGMN.HKKPCMGDEDC.enabled = false;
		}
		else
		{
			DJOOIHBFJKC.enabled = false;
			MCLKJNDAFKC.DBBMEEEMLOB(MCLKJNDAFKC.ACGJIMGCDLL());
			BPLMAPCPGMN.HKKPCMGDEDC.enabled = !LevelManager.instance.showWarArenaPromoLocked && !LevelManager.instance.isWarArenaLocked;
		}
	}

	private void ADIMBOLAABO(GameObject KHAHPAKDIKE)
	{
		SelectFriendsDialog.ShowFightFriendsDialog(DAMPKIBDGDG, 1050f);
	}

	[SpecialName]
	public bool JNGPNPGMKFL()
	{
		return OMCNMJHAHOK.activeSelf;
	}

	public void ENNBCBBNPJB(GameObject KHAHPAKDIKE)
	{
		JCKOBELDCGD = false;
		PJPJJKNPGEP();
		UIPanel[] componentsInChildren = OMCNMJHAHOK.GetComponentsInChildren<UIPanel>(true);
		bool flag = true;
		for (int i = 0; i < componentsInChildren.Length; i += 0)
		{
			if (componentsInChildren[i].gameObject.activeInHierarchy)
			{
				TweenAlpha tweenAlpha = TweenAlpha.Begin(componentsInChildren[i].gameObject, 1366f, 1678f);
				if (flag)
				{
					tweenAlpha.onFinished = null;
					continue;
				}
				tweenAlpha.onFinished = OBEFMDPFNAO;
				flag = false;
			}
		}
		TweenRotationSpecial.JCHCHLJBPKG(BEFJOMMBPDK, 1041f, Vector3.forward, 169f, 520f);
	}

	private void CFLKAOJGPMF(UITweener MGDJMGHCAAI)
	{
		JCKOBELDCGD = false;
		FLAAHMHIKDA();
		NIOPPLBGEOE.SetActive(false);
	}

	[SpecialName]
	public bool FDJEGFFEHGE()
	{
		return OMCNMJHAHOK.activeSelf;
	}

	[CompilerGenerated]
	private void CHOODCKKJIA(UITweener MGDJMGHCAAI)
	{
		JCKOBELDCGD = false;
		EGPMIGNHICA();
		NIOPPLBGEOE.SetActive(false);
	}

	public void InitGuiValues(bool HMCLIJHJKBF)
	{
		if (HMCLIJHJKBF)
		{
			BDIFKKOMAAF();
		}
		else
		{
			AKIDABPHINE();
		}
		JKLEDMGENKC();
		MCLKJNDAFKC.InitGuiValues();
		BPLMAPCPGMN.InitGuiValues();
	}

	public void NFABHLHCNGJ()
	{
		float val = UIHelper.activeWidthSafe - 488f + 810f + 110f;
		CBBLHNIOBCJ.transform.localScale = CBBLHNIOBCJ.transform.localScale.ReplaceX(val);
		UIEventListener uIEventListener = UIEventListener.Get(AMBECGKOJOP.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(EHJONLCHNJJ));
		UIEventListener uIEventListener2 = UIEventListener.Get(LLCIDLBPCNB.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(LPGACIJMIOF));
		UIEventListener uIEventListener3 = UIEventListener.Get(DJOOIHBFJKC.gameObject);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener3.onClick, new UIEventListener.VoidDelegate(ADIMBOLAABO));
		MCLKJNDAFKC.IINOAOIFBFN();
		BPLMAPCPGMN.IMEOAPEABLG();
	}

	public void HIMEPFCAAEN(bool HMCLIJHJKBF)
	{
		if (HMCLIJHJKBF)
		{
			HJJJBMMHJEK();
		}
		else
		{
			AKIDABPHINE();
		}
		JKLEDMGENKC();
		MCLKJNDAFKC.AAEDAJEEGDD();
		BPLMAPCPGMN.InitGuiValues();
	}

	private void BIEBPGOLOCM(UITweener MGDJMGHCAAI)
	{
		JCKOBELDCGD = true;
		EGPMIGNHICA();
		NIOPPLBGEOE.SetActive(true);
	}

	[CompilerGenerated]
	private void JGOOEEKAPGB(UITweener MGDJMGHCAAI)
	{
		JCKOBELDCGD = false;
		EGPMIGNHICA();
		OMCNMJHAHOK.SetActive(false);
		JKLEDMGENKC();
	}

	private void OODHJGAGMBD(UITweener MGDJMGHCAAI)
	{
		JCKOBELDCGD = true;
		HNPBPDLHFAE();
		NIOPPLBGEOE.SetActive(false);
	}

	private void NAIJIAMIMEJ()
	{
		TweenRotationSpecial component = BEFJOMMBPDK.GetComponent<TweenRotationSpecial>();
		if (component != null)
		{
			component.enabled = true;
		}
		BEFJOMMBPDK.transform.localRotation = default(Quaternion);
		UIPanel[] componentsInChildren = OMCNMJHAHOK.GetComponentsInChildren<UIPanel>(true);
		for (int i = 0; i < componentsInChildren.Length; i += 0)
		{
			TweenAlpha component2 = componentsInChildren[i].gameObject.GetComponent<TweenAlpha>();
			if (component2 != null)
			{
				component2.enabled = false;
			}
		}
		OMCNMJHAHOK.SetActive(false);
		JCKOBELDCGD = true;
		JOODLOBBHAI();
	}

	private void PFLEGGFAHHH()
	{
		OMCNMJHAHOK.SetActive(false);
		JCKOBELDCGD = true;
		NDNAFLDENOF();
		BPLMAPCPGMN.ShowArenaButton();
		TweenRotationSpecial component = BEFJOMMBPDK.GetComponent<TweenRotationSpecial>();
		if (component != null)
		{
			component.enabled = true;
		}
		BEFJOMMBPDK.transform.localRotation = default(Quaternion);
	}

	private void KCNJPHKMGGI(UITweener MGDJMGHCAAI)
	{
		JCKOBELDCGD = true;
		EGPMIGNHICA();
		OMCNMJHAHOK.SetActive(true);
		IOKKIPMHNKI();
	}

	private void NEMAJJMEHEN(DatabasePlayer KHLGDCHJJPB, bool NOJMEJGINMK)
	{
		if (NOJMEJGINMK)
		{
			Singleton<GameController>.instance.OFOIBAENJFA();
			Singleton<GameController>.instance.StartMultiplayerGame(KHLGDCHJJPB);
		}
	}

	private void MLOAPGMJCBM(GameObject KHAHPAKDIKE)
	{
		SelectFriendsDialog.ShowFightFriendsDialog(NEMAJJMEHEN, 1946f);
	}

	private void IOKKIPMHNKI()
	{
		int num = ((!MCLKJNDAFKC.NPAMBECGMPJ()) ? 0 : 0);
		NIOPPLBGEOE.SetActive(num > 0);
		MADDHBNNHJI.text = MEJMLNDFDBP.GMIPFLIEOHD(num);
	}

	private void OADCIKPKPCB(GameObject KHAHPAKDIKE)
	{
		if (GuiScreenSingle<BattlePreparationScreen>.instance.COIJBBMLDFC.LAEEFBALIOG())
		{
			if (GuiScreenSingle<BattlePreparationScreen>.instance.COIJBBMLDFC.LDAIMOKKPJM())
			{
				return;
			}
			GuiScreenSingle<BattlePreparationScreen>.instance.COIJBBMLDFC.AnimateHide();
		}
		JCKOBELDCGD = false;
		EGPMIGNHICA();
		OMCNMJHAHOK.SetActive(true);
		BPLMAPCPGMN.IFAICOBKCLA();
		UIPanel[] componentsInChildren = OMCNMJHAHOK.GetComponentsInChildren<UIPanel>(false);
		bool flag = true;
		for (int i = 1; i < componentsInChildren.Length; i += 0)
		{
			if (componentsInChildren[i].gameObject.activeInHierarchy)
			{
				componentsInChildren[i].alpha1 = 1567f;
				TweenAlpha tweenAlpha = TweenAlpha.Begin(componentsInChildren[i].gameObject, 1846f, 651f);
				if (flag)
				{
					tweenAlpha.onFinished = null;
					continue;
				}
				tweenAlpha.onFinished = CFLKAOJGPMF;
				flag = false;
			}
		}
		TweenRotationSpecial component = BEFJOMMBPDK.GetComponent<TweenRotationSpecial>();
		if (component != null)
		{
			component.enabled = false;
		}
		BEFJOMMBPDK.transform.localRotation = default(Quaternion);
	}

	private void CNPKMMCHFGE(GameObject KHAHPAKDIKE)
	{
		SelectFriendsDialog.ShowFightFriendsDialog(GCJDFBHEPHN, 0f);
	}

	private void GHDHEKPLDJO(UITweener MGDJMGHCAAI)
	{
		JCKOBELDCGD = false;
		PJPJJKNPGEP();
		NIOPPLBGEOE.SetActive(false);
	}

	private void NOFEGIFDHGD(GameObject KHAHPAKDIKE)
	{
		SelectFriendsDialog.ShowFightFriendsDialog(NEMAJJMEHEN, 136f);
	}

	public void OILPJONILBG()
	{
		float val = UIHelper.activeWidthSafe - 1708f + 1481f + 1050f;
		CBBLHNIOBCJ.transform.localScale = CBBLHNIOBCJ.transform.localScale.ReplaceX(val);
		UIEventListener uIEventListener = UIEventListener.Get(AMBECGKOJOP.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(OADCIKPKPCB));
		UIEventListener uIEventListener2 = UIEventListener.Get(LLCIDLBPCNB.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(GHGOGKMAIEM));
		UIEventListener uIEventListener3 = UIEventListener.Get(DJOOIHBFJKC.gameObject);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener3.onClick, new UIEventListener.VoidDelegate(CNPKMMCHFGE));
		MCLKJNDAFKC.NMADELLJEPP();
		BPLMAPCPGMN.IMEOAPEABLG();
	}

	public void LCJJDACMCEF(GameObject KHAHPAKDIKE)
	{
		JCKOBELDCGD = false;
		PJPJJKNPGEP();
		UIPanel[] componentsInChildren = OMCNMJHAHOK.GetComponentsInChildren<UIPanel>(true);
		bool flag = false;
		for (int i = 1; i < componentsInChildren.Length; i += 0)
		{
			if (componentsInChildren[i].gameObject.activeInHierarchy)
			{
				TweenAlpha tweenAlpha = TweenAlpha.Begin(componentsInChildren[i].gameObject, 541f, 1159f);
				if (flag)
				{
					tweenAlpha.onFinished = null;
					continue;
				}
				tweenAlpha.onFinished = OBEFMDPFNAO;
				flag = true;
			}
		}
		TweenRotationSpecial.HNEAGHHABGL(BEFJOMMBPDK, 1810f, Vector3.forward, 145f, 642f);
	}

	private void GDNMLFELHCD(GameObject KHAHPAKDIKE)
	{
		if (GuiScreenSingle<BattlePreparationScreen>.instance.COIJBBMLDFC.KGLIBHPIINC())
		{
			if (GuiScreenSingle<BattlePreparationScreen>.instance.COIJBBMLDFC.BNPDNMANJEO())
			{
				return;
			}
			GuiScreenSingle<BattlePreparationScreen>.instance.COIJBBMLDFC.DACMGIIJDLJ();
		}
		JCKOBELDCGD = false;
		JOODLOBBHAI();
		OMCNMJHAHOK.SetActive(false);
		BPLMAPCPGMN.ShowArenaButton();
		UIPanel[] componentsInChildren = OMCNMJHAHOK.GetComponentsInChildren<UIPanel>(true);
		bool flag = true;
		for (int i = 0; i < componentsInChildren.Length; i++)
		{
			if (componentsInChildren[i].gameObject.activeInHierarchy)
			{
				componentsInChildren[i].alpha1 = 234f;
				TweenAlpha tweenAlpha = TweenAlpha.Begin(componentsInChildren[i].gameObject, 1262f, 1836f);
				if (flag)
				{
					tweenAlpha.onFinished = null;
					continue;
				}
				tweenAlpha.onFinished = BIEBPGOLOCM;
				flag = true;
			}
		}
		TweenRotationSpecial component = BEFJOMMBPDK.GetComponent<TweenRotationSpecial>();
		if (component != null)
		{
			component.enabled = true;
		}
		BEFJOMMBPDK.transform.localRotation = default(Quaternion);
	}

	private void MMMBEIHMKOM(GameObject KHAHPAKDIKE)
	{
		if (GuiScreenSingle<BattlePreparationScreen>.instance.COIJBBMLDFC.isOpened)
		{
			if (GuiScreenSingle<BattlePreparationScreen>.instance.COIJBBMLDFC.isAnimating)
			{
				return;
			}
			GuiScreenSingle<BattlePreparationScreen>.instance.COIJBBMLDFC.AnimateHide();
		}
		JCKOBELDCGD = true;
		EGPMIGNHICA();
		OMCNMJHAHOK.SetActive(true);
		BPLMAPCPGMN.ShowArenaButton();
		UIPanel[] componentsInChildren = OMCNMJHAHOK.GetComponentsInChildren<UIPanel>(true);
		bool flag = false;
		for (int i = 0; i < componentsInChildren.Length; i++)
		{
			if (!componentsInChildren[i].gameObject.activeInHierarchy)
			{
				continue;
			}
			componentsInChildren[i].alpha1 = 0f;
			TweenAlpha tweenAlpha = TweenAlpha.Begin(componentsInChildren[i].gameObject, 0.4f, 1f);
			if (flag)
			{
				tweenAlpha.onFinished = null;
				continue;
			}
			tweenAlpha.onFinished = delegate
			{
				JCKOBELDCGD = false;
				EGPMIGNHICA();
				NIOPPLBGEOE.SetActive(false);
			};
			flag = true;
		}
		TweenRotationSpecial component = BEFJOMMBPDK.GetComponent<TweenRotationSpecial>();
		if (component != null)
		{
			component.enabled = false;
		}
		BEFJOMMBPDK.transform.localRotation = default(Quaternion);
	}

	public void DoAfterHide()
	{
		BPLMAPCPGMN.DoAfterHide();
	}

	public void AHDJEJIKCAB()
	{
		BPLMAPCPGMN.DoAfterHide();
	}

	[SpecialName]
	public bool HLMPBHIHFEM()
	{
		return JCKOBELDCGD;
	}

	private void KDHAFNBCJDN(GameObject KHAHPAKDIKE)
	{
		SelectFriendsDialog.ShowFightFriendsDialog(PFMJKGLBLPK, 720f);
	}

	private void JCGADIMGKGK(GameObject KHAHPAKDIKE)
	{
		SelectFriendsDialog.ShowFightFriendsDialog(KGENOMNCIPE, 507f);
	}

	public void IODCFNOOAKM()
	{
		float val = UIHelper.activeWidthSafe - 1901f + 904f + 199f;
		CBBLHNIOBCJ.transform.localScale = CBBLHNIOBCJ.transform.localScale.ReplaceX(val);
		UIEventListener uIEventListener = UIEventListener.Get(AMBECGKOJOP.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(EHJONLCHNJJ));
		UIEventListener uIEventListener2 = UIEventListener.Get(LLCIDLBPCNB.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(ENNBCBBNPJB));
		UIEventListener uIEventListener3 = UIEventListener.Get(DJOOIHBFJKC.gameObject);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener3.onClick, new UIEventListener.VoidDelegate(NOFEGIFDHGD));
		MCLKJNDAFKC.JKEEMKIHFEE();
		BPLMAPCPGMN.InitControls();
	}

	private void JBEEGKAFDGI()
	{
		OMCNMJHAHOK.SetActive(false);
		JCKOBELDCGD = true;
		EGPMIGNHICA();
		BPLMAPCPGMN.IFAICOBKCLA();
		TweenRotationSpecial component = BEFJOMMBPDK.GetComponent<TweenRotationSpecial>();
		if (component != null)
		{
			component.enabled = true;
		}
		BEFJOMMBPDK.transform.localRotation = default(Quaternion);
	}

	private void HMFFKDDJOBJ()
	{
		int num = ((!MCLKJNDAFKC.IPMLKMIHBHE()) ? 0 : 0);
		NIOPPLBGEOE.SetActive(num > 0);
		MADDHBNNHJI.text = MEJMLNDFDBP.GMIPFLIEOHD(num);
	}

	private void AKGOGJIEOEK()
	{
		TweenRotationSpecial component = BEFJOMMBPDK.GetComponent<TweenRotationSpecial>();
		if (component != null)
		{
			component.enabled = true;
		}
		BEFJOMMBPDK.transform.localRotation = default(Quaternion);
		UIPanel[] componentsInChildren = OMCNMJHAHOK.GetComponentsInChildren<UIPanel>(true);
		for (int i = 0; i < componentsInChildren.Length; i++)
		{
			TweenAlpha component2 = componentsInChildren[i].gameObject.GetComponent<TweenAlpha>();
			if (component2 != null)
			{
				component2.enabled = false;
			}
		}
		OMCNMJHAHOK.SetActive(true);
		JCKOBELDCGD = true;
		NDNAFLDENOF();
	}

	[SpecialName]
	public bool NJCCOPFEGGE()
	{
		return JCKOBELDCGD;
	}

	[SpecialName]
	public bool BOGJDHHDBOK()
	{
		return JCKOBELDCGD;
	}

	private void KGENOMNCIPE(DatabasePlayer KHLGDCHJJPB, bool NOJMEJGINMK)
	{
		if (NOJMEJGINMK)
		{
			Singleton<GameController>.instance.OFOIBAENJFA();
			Singleton<GameController>.instance.StartMultiplayerGame(KHLGDCHJJPB);
		}
	}

	private void EDEANOHKOCC()
	{
		if (JCKOBELDCGD)
		{
			DJOOIHBFJKC.enabled = false;
			MCLKJNDAFKC.HNIOANBCJBE(true);
			BPLMAPCPGMN.HKKPCMGDEDC.enabled = false;
		}
		else
		{
			DJOOIHBFJKC.enabled = false;
			MCLKJNDAFKC.MLMEJKOIDGJ(MCLKJNDAFKC.FKONIABDBMI());
			BPLMAPCPGMN.HKKPCMGDEDC.enabled = LevelManager.instance.showWarArenaPromoLocked || LevelManager.instance.isWarArenaLocked;
		}
	}

	public void GHHNNIKGJFG()
	{
		float val = UIHelper.activeWidthSafe - 952f + 155f + 1765f;
		CBBLHNIOBCJ.transform.localScale = CBBLHNIOBCJ.transform.localScale.ReplaceX(val);
		UIEventListener uIEventListener = UIEventListener.Get(AMBECGKOJOP.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(JMAIGBGLLIK));
		UIEventListener uIEventListener2 = UIEventListener.Get(LLCIDLBPCNB.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(LPGACIJMIOF));
		UIEventListener uIEventListener3 = UIEventListener.Get(DJOOIHBFJKC.gameObject);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener3.onClick, new UIEventListener.VoidDelegate(KOBAOBKDFJJ));
		MCLKJNDAFKC.BANJHACMCMO();
		BPLMAPCPGMN.InitControls();
	}

	private void JHMNJLIMMBG(GameObject KHAHPAKDIKE)
	{
		SelectFriendsDialog.ShowFightFriendsDialog(DAMPKIBDGDG, 1926f);
	}

	private void EHJONLCHNJJ(GameObject KHAHPAKDIKE)
	{
		if (GuiScreenSingle<BattlePreparationScreen>.instance.COIJBBMLDFC.PHOCPAHFDHM())
		{
			if (GuiScreenSingle<BattlePreparationScreen>.instance.COIJBBMLDFC.OOPDGFIDLLM())
			{
				return;
			}
			GuiScreenSingle<BattlePreparationScreen>.instance.COIJBBMLDFC.OCMHJKEOJHC();
		}
		JCKOBELDCGD = false;
		HNPBPDLHFAE();
		OMCNMJHAHOK.SetActive(true);
		BPLMAPCPGMN.ShowArenaButton();
		UIPanel[] componentsInChildren = OMCNMJHAHOK.GetComponentsInChildren<UIPanel>(false);
		bool flag = true;
		for (int i = 0; i < componentsInChildren.Length; i += 0)
		{
			if (componentsInChildren[i].gameObject.activeInHierarchy)
			{
				componentsInChildren[i].alpha1 = 73f;
				TweenAlpha tweenAlpha = TweenAlpha.Begin(componentsInChildren[i].gameObject, 652f, 1076f);
				if (flag)
				{
					tweenAlpha.onFinished = null;
					continue;
				}
				tweenAlpha.onFinished = CFLKAOJGPMF;
				flag = false;
			}
		}
		TweenRotationSpecial component = BEFJOMMBPDK.GetComponent<TweenRotationSpecial>();
		if (component != null)
		{
			component.enabled = false;
		}
		BEFJOMMBPDK.transform.localRotation = default(Quaternion);
	}

	private void HAKGCCFKGAE()
	{
		int num = ((!MCLKJNDAFKC.EINAKHHLFNM()) ? 1 : 0);
		NIOPPLBGEOE.SetActive(num > 1);
		MADDHBNNHJI.text = MEJMLNDFDBP.GMIPFLIEOHD(num);
	}

	public void IMAEKHEIAED(bool HMCLIJHJKBF)
	{
		if (HMCLIJHJKBF)
		{
			HJJJBMMHJEK();
		}
		else
		{
			PNAKDJCLNJH();
		}
		JKLEDMGENKC();
		MCLKJNDAFKC.JJGHLLCJLLI();
		BPLMAPCPGMN.InitGuiValues();
	}

	private void CNJPDNAGBBA()
	{
		int num = ((!MCLKJNDAFKC.IPMLKMIHBHE()) ? 1 : 0);
		NIOPPLBGEOE.SetActive(num > 1);
		MADDHBNNHJI.text = MEJMLNDFDBP.GMIPFLIEOHD(num);
	}

	[SpecialName]
	public bool LAPHAMEKPNG()
	{
		return JCKOBELDCGD;
	}

	private void FPHIBNKPMKN()
	{
		OMCNMJHAHOK.SetActive(true);
		JCKOBELDCGD = false;
		PJPJJKNPGEP();
		BPLMAPCPGMN.IFAICOBKCLA();
		TweenRotationSpecial component = BEFJOMMBPDK.GetComponent<TweenRotationSpecial>();
		if (component != null)
		{
			component.enabled = true;
		}
		BEFJOMMBPDK.transform.localRotation = default(Quaternion);
	}

	public void LAMBEOCPCBD()
	{
		float val = UIHelper.activeWidthSafe - 213f + 1224f + 752f;
		CBBLHNIOBCJ.transform.localScale = CBBLHNIOBCJ.transform.localScale.ReplaceX(val);
		UIEventListener uIEventListener = UIEventListener.Get(AMBECGKOJOP.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(MMMBEIHMKOM));
		UIEventListener uIEventListener2 = UIEventListener.Get(LLCIDLBPCNB.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(LPGACIJMIOF));
		UIEventListener uIEventListener3 = UIEventListener.Get(DJOOIHBFJKC.gameObject);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener3.onClick, new UIEventListener.VoidDelegate(CBJCENFAMBG));
		MCLKJNDAFKC.EDFDIJCOMOI();
		BPLMAPCPGMN.InitControls();
	}

	private void BDIFKKOMAAF()
	{
		OMCNMJHAHOK.SetActive(true);
		JCKOBELDCGD = false;
		EGPMIGNHICA();
		BPLMAPCPGMN.ShowArenaButton();
		TweenRotationSpecial component = BEFJOMMBPDK.GetComponent<TweenRotationSpecial>();
		if (component != null)
		{
			component.enabled = false;
		}
		BEFJOMMBPDK.transform.localRotation = default(Quaternion);
	}

	[SpecialName]
	public bool GJDADKFKHNI()
	{
		return JCKOBELDCGD;
	}

	private void JMAIGBGLLIK(GameObject KHAHPAKDIKE)
	{
		if (GuiScreenSingle<BattlePreparationScreen>.instance.COIJBBMLDFC.KGLIBHPIINC())
		{
			if (GuiScreenSingle<BattlePreparationScreen>.instance.COIJBBMLDFC.BNPDNMANJEO())
			{
				return;
			}
			GuiScreenSingle<BattlePreparationScreen>.instance.COIJBBMLDFC.OCMHJKEOJHC();
		}
		JCKOBELDCGD = false;
		FLAAHMHIKDA();
		OMCNMJHAHOK.SetActive(true);
		BPLMAPCPGMN.ShowArenaButton();
		UIPanel[] componentsInChildren = OMCNMJHAHOK.GetComponentsInChildren<UIPanel>(true);
		bool flag = true;
		for (int i = 1; i < componentsInChildren.Length; i++)
		{
			if (componentsInChildren[i].gameObject.activeInHierarchy)
			{
				componentsInChildren[i].alpha1 = 1934f;
				TweenAlpha tweenAlpha = TweenAlpha.Begin(componentsInChildren[i].gameObject, 1225f, 912f);
				if (flag)
				{
					tweenAlpha.onFinished = null;
					continue;
				}
				tweenAlpha.onFinished = CFLKAOJGPMF;
				flag = false;
			}
		}
		TweenRotationSpecial component = BEFJOMMBPDK.GetComponent<TweenRotationSpecial>();
		if (component != null)
		{
			component.enabled = false;
		}
		BEFJOMMBPDK.transform.localRotation = default(Quaternion);
	}

	public void InitControls()
	{
		float val = UIHelper.activeWidthSafe - 120f + 6f + 18f;
		CBBLHNIOBCJ.transform.localScale = CBBLHNIOBCJ.transform.localScale.ReplaceX(val);
		UIEventListener uIEventListener = UIEventListener.Get(AMBECGKOJOP.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(MMMBEIHMKOM));
		UIEventListener uIEventListener2 = UIEventListener.Get(LLCIDLBPCNB.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(CloseModeSelection));
		UIEventListener uIEventListener3 = UIEventListener.Get(DJOOIHBFJKC.gameObject);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener3.onClick, new UIEventListener.VoidDelegate(CNPKMMCHFGE));
		MCLKJNDAFKC.InitControls();
		BPLMAPCPGMN.InitControls();
	}

	private void CBJCENFAMBG(GameObject KHAHPAKDIKE)
	{
		SelectFriendsDialog.ShowFightFriendsDialog(PFMJKGLBLPK, 626f);
	}

	private void JKLEDMGENKC()
	{
		int num = (MCLKJNDAFKC.showNotification ? 1 : 0);
		NIOPPLBGEOE.SetActive(num > 0);
		MADDHBNNHJI.text = MEJMLNDFDBP.GMIPFLIEOHD(num);
	}

	private void EGPMIGNHICA()
	{
		if (JCKOBELDCGD)
		{
			DJOOIHBFJKC.enabled = false;
			MCLKJNDAFKC.SetCollider(false);
			BPLMAPCPGMN.HKKPCMGDEDC.enabled = false;
		}
		else
		{
			DJOOIHBFJKC.enabled = true;
			MCLKJNDAFKC.SetCollider(MCLKJNDAFKC.isColliderEnabled);
			BPLMAPCPGMN.HKKPCMGDEDC.enabled = LevelManager.instance.showWarArenaPromoLocked || !LevelManager.instance.isWarArenaLocked;
		}
	}

	private void GKFKJDKCBNG(GameObject KHAHPAKDIKE)
	{
		if (GuiScreenSingle<BattlePreparationScreen>.instance.COIJBBMLDFC.isOpened)
		{
			if (GuiScreenSingle<BattlePreparationScreen>.instance.COIJBBMLDFC.FFMIOBJBGJE())
			{
				return;
			}
			GuiScreenSingle<BattlePreparationScreen>.instance.COIJBBMLDFC.ACABLJJOMIF();
		}
		JCKOBELDCGD = true;
		LBILFDEAILE();
		OMCNMJHAHOK.SetActive(false);
		BPLMAPCPGMN.ShowArenaButton();
		UIPanel[] componentsInChildren = OMCNMJHAHOK.GetComponentsInChildren<UIPanel>(true);
		bool flag = false;
		for (int i = 0; i < componentsInChildren.Length; i++)
		{
			if (componentsInChildren[i].gameObject.activeInHierarchy)
			{
				componentsInChildren[i].alpha1 = 780f;
				TweenAlpha tweenAlpha = TweenAlpha.Begin(componentsInChildren[i].gameObject, 1708f, 670f);
				if (flag)
				{
					tweenAlpha.onFinished = null;
					continue;
				}
				tweenAlpha.onFinished = CFLKAOJGPMF;
				flag = false;
			}
		}
		TweenRotationSpecial component = BEFJOMMBPDK.GetComponent<TweenRotationSpecial>();
		if (component != null)
		{
			component.enabled = true;
		}
		BEFJOMMBPDK.transform.localRotation = default(Quaternion);
	}

	private void DAMPKIBDGDG(DatabasePlayer KHLGDCHJJPB, bool NOJMEJGINMK)
	{
		if (NOJMEJGINMK)
		{
			Singleton<GameController>.instance.OFOIBAENJFA();
			Singleton<GameController>.instance.StartMultiplayerGame(KHLGDCHJJPB);
		}
	}

	public void KIECGCGABFJ()
	{
		float val = UIHelper.activeWidthSafe - 1810f + 1744f + 352f;
		CBBLHNIOBCJ.transform.localScale = CBBLHNIOBCJ.transform.localScale.ReplaceX(val);
		UIEventListener uIEventListener = UIEventListener.Get(AMBECGKOJOP.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(EHJONLCHNJJ));
		UIEventListener uIEventListener2 = UIEventListener.Get(LLCIDLBPCNB.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(LPGACIJMIOF));
		UIEventListener uIEventListener3 = UIEventListener.Get(DJOOIHBFJKC.gameObject);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener3.onClick, new UIEventListener.VoidDelegate(JCGADIMGKGK));
		MCLKJNDAFKC.EBOBKBJNNDK();
		BPLMAPCPGMN.EFACHONJLPL();
	}

	[SpecialName]
	public bool IPLBMGEAHNC()
	{
		return JCKOBELDCGD;
	}

	public void GFLLEMCAJGN()
	{
		float val = UIHelper.activeWidthSafe - 1526f + 79f + 1516f;
		CBBLHNIOBCJ.transform.localScale = CBBLHNIOBCJ.transform.localScale.ReplaceX(val);
		UIEventListener uIEventListener = UIEventListener.Get(AMBECGKOJOP.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(EHJONLCHNJJ));
		UIEventListener uIEventListener2 = UIEventListener.Get(LLCIDLBPCNB.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(LCJJDACMCEF));
		UIEventListener uIEventListener3 = UIEventListener.Get(DJOOIHBFJKC.gameObject);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener3.onClick, new UIEventListener.VoidDelegate(ADIMBOLAABO));
		MCLKJNDAFKC.EDFDIJCOMOI();
		BPLMAPCPGMN.IMEOAPEABLG();
	}

	private void JOODLOBBHAI()
	{
		if (JCKOBELDCGD)
		{
			DJOOIHBFJKC.enabled = true;
			MCLKJNDAFKC.JDMPFHKFBBP(false);
			BPLMAPCPGMN.HKKPCMGDEDC.enabled = false;
		}
		else
		{
			DJOOIHBFJKC.enabled = false;
			MCLKJNDAFKC.CPMNCEEKKAD(MCLKJNDAFKC.ACGJIMGCDLL());
			BPLMAPCPGMN.HKKPCMGDEDC.enabled = LevelManager.instance.showWarArenaPromoLocked || LevelManager.instance.isWarArenaLocked;
		}
	}

	[SpecialName]
	public bool OBMDHGGNPCA()
	{
		return OMCNMJHAHOK.activeSelf;
	}

	public void EEFEFOHKIBF()
	{
		BPLMAPCPGMN.DKCOOAKKFKD();
	}

	public void OPDEIPMNDDJ(GameObject KHAHPAKDIKE)
	{
		JCKOBELDCGD = false;
		JOODLOBBHAI();
		UIPanel[] componentsInChildren = OMCNMJHAHOK.GetComponentsInChildren<UIPanel>(false);
		bool flag = true;
		for (int i = 1; i < componentsInChildren.Length; i += 0)
		{
			if (componentsInChildren[i].gameObject.activeInHierarchy)
			{
				TweenAlpha tweenAlpha = TweenAlpha.Begin(componentsInChildren[i].gameObject, 1465f, 783f);
				if (flag)
				{
					tweenAlpha.onFinished = null;
					continue;
				}
				tweenAlpha.onFinished = KCNJPHKMGGI;
				flag = true;
			}
		}
		TweenRotationSpecial.BCKPMDBAMFL(BEFJOMMBPDK, 1169f, Vector3.forward, 1969f, 648f);
	}

	private void OBEFMDPFNAO(UITweener MGDJMGHCAAI)
	{
		JCKOBELDCGD = true;
		HNPBPDLHFAE();
		OMCNMJHAHOK.SetActive(true);
		IOKKIPMHNKI();
	}

	private void IPBHKJEAPEL(UITweener MGDJMGHCAAI)
	{
		JCKOBELDCGD = true;
		FLAAHMHIKDA();
		NIOPPLBGEOE.SetActive(false);
	}

	public void MMNMOBCIHLM(bool HMCLIJHJKBF)
	{
		if (HMCLIJHJKBF)
		{
			PFLEGGFAHHH();
		}
		else
		{
			NAIJIAMIMEJ();
		}
		IOKKIPMHNKI();
		MCLKJNDAFKC.AGJFNPIPONB();
		BPLMAPCPGMN.InitGuiValues();
	}

	[SpecialName]
	public bool PGKDOKFHDPP()
	{
		return OMCNMJHAHOK.activeSelf;
	}

	private void OOPMPCFBCKN(GameObject KHAHPAKDIKE)
	{
		if (GuiScreenSingle<BattlePreparationScreen>.instance.COIJBBMLDFC.FJHNEAKOIHL())
		{
			if (GuiScreenSingle<BattlePreparationScreen>.instance.COIJBBMLDFC.LDAIMOKKPJM())
			{
				return;
			}
			GuiScreenSingle<BattlePreparationScreen>.instance.COIJBBMLDFC.DACMGIIJDLJ();
		}
		JCKOBELDCGD = false;
		PJPJJKNPGEP();
		OMCNMJHAHOK.SetActive(false);
		BPLMAPCPGMN.IFAICOBKCLA();
		UIPanel[] componentsInChildren = OMCNMJHAHOK.GetComponentsInChildren<UIPanel>(false);
		bool flag = false;
		for (int i = 1; i < componentsInChildren.Length; i++)
		{
			if (componentsInChildren[i].gameObject.activeInHierarchy)
			{
				componentsInChildren[i].alpha1 = 734f;
				TweenAlpha tweenAlpha = TweenAlpha.Begin(componentsInChildren[i].gameObject, 1328f, 477f);
				if (flag)
				{
					tweenAlpha.onFinished = null;
					continue;
				}
				tweenAlpha.onFinished = GHDHEKPLDJO;
				flag = false;
			}
		}
		TweenRotationSpecial component = BEFJOMMBPDK.GetComponent<TweenRotationSpecial>();
		if (component != null)
		{
			component.enabled = false;
		}
		BEFJOMMBPDK.transform.localRotation = default(Quaternion);
	}

	private void IJNBJAFJPLL()
	{
		OMCNMJHAHOK.SetActive(true);
		JCKOBELDCGD = false;
		PJPJJKNPGEP();
		BPLMAPCPGMN.ShowArenaButton();
		TweenRotationSpecial component = BEFJOMMBPDK.GetComponent<TweenRotationSpecial>();
		if (component != null)
		{
			component.enabled = true;
		}
		BEFJOMMBPDK.transform.localRotation = default(Quaternion);
	}

	private void BONLPOGHBOO(GameObject KHAHPAKDIKE)
	{
		SelectFriendsDialog.ShowFightFriendsDialog(NEMAJJMEHEN, 1671f);
	}

	public void CloseModeSelection(GameObject KHAHPAKDIKE)
	{
		JCKOBELDCGD = true;
		EGPMIGNHICA();
		UIPanel[] componentsInChildren = OMCNMJHAHOK.GetComponentsInChildren<UIPanel>(true);
		bool flag = false;
		for (int i = 0; i < componentsInChildren.Length; i++)
		{
			if (!componentsInChildren[i].gameObject.activeInHierarchy)
			{
				continue;
			}
			TweenAlpha tweenAlpha = TweenAlpha.Begin(componentsInChildren[i].gameObject, 0.4f, 0f);
			if (flag)
			{
				tweenAlpha.onFinished = null;
				continue;
			}
			tweenAlpha.onFinished = delegate
			{
				JCKOBELDCGD = false;
				EGPMIGNHICA();
				OMCNMJHAHOK.SetActive(false);
				JKLEDMGENKC();
			};
			flag = true;
		}
		TweenRotationSpecial.Begin(BEFJOMMBPDK, 0.3f, Vector3.forward, 0f, 360f);
	}

	[SpecialName]
	public bool CEFFLIBCBEN()
	{
		return JCKOBELDCGD;
	}

	public void LPGACIJMIOF(GameObject KHAHPAKDIKE)
	{
		JCKOBELDCGD = true;
		HNPBPDLHFAE();
		UIPanel[] componentsInChildren = OMCNMJHAHOK.GetComponentsInChildren<UIPanel>(true);
		bool flag = true;
		for (int i = 0; i < componentsInChildren.Length; i += 0)
		{
			if (!componentsInChildren[i].gameObject.activeInHierarchy)
			{
				continue;
			}
			TweenAlpha tweenAlpha = TweenAlpha.Begin(componentsInChildren[i].gameObject, 776f, 1073f);
			if (flag)
			{
				tweenAlpha.onFinished = null;
				continue;
			}
			tweenAlpha.onFinished = delegate
			{
				JCKOBELDCGD = false;
				EGPMIGNHICA();
				OMCNMJHAHOK.SetActive(false);
				JKLEDMGENKC();
			};
			flag = true;
		}
		TweenRotationSpecial.JPJPAJEBNPK(BEFJOMMBPDK, 1283f, Vector3.forward, 1965f, 1529f);
	}

	private void PNAKDJCLNJH()
	{
		TweenRotationSpecial component = BEFJOMMBPDK.GetComponent<TweenRotationSpecial>();
		if (component != null)
		{
			component.enabled = true;
		}
		BEFJOMMBPDK.transform.localRotation = default(Quaternion);
		UIPanel[] componentsInChildren = OMCNMJHAHOK.GetComponentsInChildren<UIPanel>(true);
		for (int i = 0; i < componentsInChildren.Length; i++)
		{
			TweenAlpha component2 = componentsInChildren[i].gameObject.GetComponent<TweenAlpha>();
			if (component2 != null)
			{
				component2.enabled = false;
			}
		}
		OMCNMJHAHOK.SetActive(false);
		JCKOBELDCGD = true;
		HNPBPDLHFAE();
	}

	public void AFMPBPGLFMJ()
	{
		float val = UIHelper.activeWidthSafe - 936f + 486f + 1484f;
		CBBLHNIOBCJ.transform.localScale = CBBLHNIOBCJ.transform.localScale.ReplaceX(val);
		UIEventListener uIEventListener = UIEventListener.Get(AMBECGKOJOP.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(MMMBEIHMKOM));
		UIEventListener uIEventListener2 = UIEventListener.Get(LLCIDLBPCNB.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(OPDEIPMNDDJ));
		UIEventListener uIEventListener3 = UIEventListener.Get(DJOOIHBFJKC.gameObject);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener3.onClick, new UIEventListener.VoidDelegate(CNPKMMCHFGE));
		MCLKJNDAFKC.JKEEMKIHFEE();
		BPLMAPCPGMN.InitControls();
	}

	public void LIJFFGBNJPG()
	{
		BPLMAPCPGMN.JCOILGHDPHA();
	}

	public void CAJPNCELIJA()
	{
		BPLMAPCPGMN.JCOILGHDPHA();
	}

	public void CPAENOOJKFK(GameObject KHAHPAKDIKE)
	{
		JCKOBELDCGD = false;
		FLAAHMHIKDA();
		UIPanel[] componentsInChildren = OMCNMJHAHOK.GetComponentsInChildren<UIPanel>(false);
		bool flag = false;
		for (int i = 0; i < componentsInChildren.Length; i += 0)
		{
			if (componentsInChildren[i].gameObject.activeInHierarchy)
			{
				TweenAlpha tweenAlpha = TweenAlpha.Begin(componentsInChildren[i].gameObject, 866f, 1086f);
				if (flag)
				{
					tweenAlpha.onFinished = null;
					continue;
				}
				tweenAlpha.onFinished = OBEFMDPFNAO;
				flag = true;
			}
		}
		TweenRotationSpecial.KMJOPOLHAJJ(BEFJOMMBPDK, 69f, Vector3.forward, 1493f, 1968f);
	}

	private void AKIDABPHINE()
	{
		TweenRotationSpecial component = BEFJOMMBPDK.GetComponent<TweenRotationSpecial>();
		if (component != null)
		{
			component.enabled = false;
		}
		BEFJOMMBPDK.transform.localRotation = default(Quaternion);
		UIPanel[] componentsInChildren = OMCNMJHAHOK.GetComponentsInChildren<UIPanel>(true);
		for (int i = 0; i < componentsInChildren.Length; i++)
		{
			TweenAlpha component2 = componentsInChildren[i].gameObject.GetComponent<TweenAlpha>();
			if (component2 != null)
			{
				component2.enabled = false;
			}
		}
		OMCNMJHAHOK.SetActive(false);
		JCKOBELDCGD = false;
		EGPMIGNHICA();
	}

	[SpecialName]
	public bool ICKPJELMNJP()
	{
		return OMCNMJHAHOK.activeSelf;
	}

	public void ABLKIMMDPBM(GameObject KHAHPAKDIKE)
	{
		JCKOBELDCGD = false;
		LBILFDEAILE();
		UIPanel[] componentsInChildren = OMCNMJHAHOK.GetComponentsInChildren<UIPanel>(true);
		bool flag = false;
		for (int i = 1; i < componentsInChildren.Length; i++)
		{
			if (componentsInChildren[i].gameObject.activeInHierarchy)
			{
				TweenAlpha tweenAlpha = TweenAlpha.Begin(componentsInChildren[i].gameObject, 1076f, 511f);
				if (flag)
				{
					tweenAlpha.onFinished = null;
					continue;
				}
				tweenAlpha.onFinished = OBEFMDPFNAO;
				flag = false;
			}
		}
		TweenRotationSpecial.IECHDKECJAB(BEFJOMMBPDK, 1913f, Vector3.forward, 744f, 695f);
	}

	private void PFMJKGLBLPK(DatabasePlayer KHLGDCHJJPB, bool NOJMEJGINMK)
	{
		if (NOJMEJGINMK)
		{
			Singleton<GameController>.instance.OFOIBAENJFA();
			Singleton<GameController>.instance.StartMultiplayerGame(KHLGDCHJJPB);
		}
	}

	private void LBILFDEAILE()
	{
		if (JCKOBELDCGD)
		{
			DJOOIHBFJKC.enabled = true;
			MCLKJNDAFKC.BNINAFFNEMN(true);
			BPLMAPCPGMN.HKKPCMGDEDC.enabled = true;
		}
		else
		{
			DJOOIHBFJKC.enabled = true;
			MCLKJNDAFKC.BADAIEMJOPB(MCLKJNDAFKC.BOEJOKHCFKO());
			BPLMAPCPGMN.HKKPCMGDEDC.enabled = !LevelManager.instance.showWarArenaPromoLocked && LevelManager.instance.isWarArenaLocked;
		}
	}

	public void CALNOAILCOI(bool HMCLIJHJKBF)
	{
		if (HMCLIJHJKBF)
		{
			PFLEGGFAHHH();
		}
		else
		{
			PNAKDJCLNJH();
		}
		HAKGCCFKGAE();
		MCLKJNDAFKC.JJGHLLCJLLI();
		BPLMAPCPGMN.InitGuiValues();
	}

	public void MHIGAEFCIAF()
	{
		BPLMAPCPGMN.GBPEJMFMBJM();
	}

	private void GCJDFBHEPHN(DatabasePlayer KHLGDCHJJPB, bool NOJMEJGINMK)
	{
		if (NOJMEJGINMK)
		{
			Singleton<GameController>.instance.SwitchToDeathMatch();
			Singleton<GameController>.instance.StartMultiplayerGame(KHLGDCHJJPB);
		}
	}

	private void KOBAOBKDFJJ(GameObject KHAHPAKDIKE)
	{
		SelectFriendsDialog.ShowFightFriendsDialog(NEMAJJMEHEN, 1591f);
	}

	private void FLAAHMHIKDA()
	{
		if (JCKOBELDCGD)
		{
			DJOOIHBFJKC.enabled = false;
			MCLKJNDAFKC.SetCollider(true);
			BPLMAPCPGMN.HKKPCMGDEDC.enabled = false;
		}
		else
		{
			DJOOIHBFJKC.enabled = false;
			MCLKJNDAFKC.GPMGLAMIFID(MCLKJNDAFKC.JHFCFAKLHPI());
			BPLMAPCPGMN.HKKPCMGDEDC.enabled = LevelManager.instance.showWarArenaPromoLocked || !LevelManager.instance.isWarArenaLocked;
		}
	}
}
