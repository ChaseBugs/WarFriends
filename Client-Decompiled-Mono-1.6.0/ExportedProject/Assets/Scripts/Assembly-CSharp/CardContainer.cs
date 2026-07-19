using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;
using UnityEngine;

public class CardContainer : Core_BaseScript
{
	private enum IAOAHCIDOCE
	{
		None = 0,
		Drag = 1
	}

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private Action CCLMJGPACAF;

	[Header("Empty Part")]
	public GameObject HJGMIDONKBE;

	public UISprite OGMIHCBHKJL;

	public UILabel CNDKEHAAOFF;

	[Header("Card Present Part")]
	public UIPanel PPAGHBKNOKL;

	public UISprite BBJGODFHBCI;

	public UISprite DPMLMAOJPNL;

	public UITexture PJEPGKLGMLO;

	public UISprite IBKLPHAIOOG;

	public UILabel FFEHGPICCMK;

	[Header("Locked Part")]
	public GameObject NIMIJBOGLAB;

	[Header("VIP locked Part")]
	public GameObject CKMPDDMFJGN;

	[Header("Draggable Card")]
	public UIPanel AKKOEPGGEHP;

	public UISprite AMPHFKILGKE;

	public UITexture BIHGMGFKPLK;

	public UISprite JALFJLGBBFH;

	public UILabel LBJEGIPAJMF;

	public UISprite GDCBNMEGJNA;

	[Header("Highlight")]
	public UISprite DIOPLMHPJFF;

	private int AFBBPCBCOLC;

	private Card GHINGDGFNJC;

	private CardContainer FLLODMAOGLE;

	private bool BMMKKGHPAIP;

	private Vector3 PDIOAEBJBFH;

	private bool MKCDLIHODBA;

	private IAOAHCIDOCE IENCFHPINDI;

	private bool OBOGCALIAPJ;

	private bool OFDBKKPCNCJ = true;

	public bool isBuddyContainer
	{
		get
		{
			return AFBBPCBCOLC == 6;
		}
	}

	public Card card
	{
		get
		{
			return GHINGDGFNJC;
		}
		private set
		{
			if (value == null && GHINGDGFNJC != null)
			{
				GHINGDGFNJC.HideInMenu();
			}
			GHINGDGFNJC = value;
			if (GHINGDGFNJC != null)
			{
				GHINGDGFNJC.ShowInMenu();
			}
		}
	}

	public bool isAvailable
	{
		get
		{
			return !OBOGCALIAPJ && !CKMPDDMFJGN.activeSelf && !NIMIJBOGLAB.activeSelf;
		}
	}

	public bool isEmpty
	{
		get
		{
			return GHINGDGFNJC == null;
		}
	}

	public bool isDragAndDropEnabled
	{
		get
		{
			return OFDBKKPCNCJ;
		}
		set
		{
			OFDBKKPCNCJ = value;
		}
	}

	private bool KLNNNAGCJDO
	{
		get
		{
			return AFBBPCBCOLC == 4;
		}
	}

	public event Action ChangedContent
	{
		add
		{
			Action action = CCLMJGPACAF;
			Action action2;
			do
			{
				action2 = action;
				action = Interlocked.CompareExchange(ref CCLMJGPACAF, (Action)Delegate.Combine(action2, value), action);
			}
			while ((object)action != action2);
		}
		remove
		{
			Action action = CCLMJGPACAF;
			Action action2;
			do
			{
				action2 = action;
				action = Interlocked.CompareExchange(ref CCLMJGPACAF, (Action)Delegate.Remove(action2, value), action);
			}
			while ((object)action != action2);
		}
	}

	public void EEMNNJNJFBL()
	{
		HJGMIDONKBE.SetActive(true);
		CNDKEHAAOFF.gameObject.SetActive(true);
		if (LECPIFCMFKK())
		{
			OGMIHCBHKJL.color = Colours.yellowVIPBg.ReplaceA(475f);
		}
		else if (FEBNGMKAGJD())
		{
			OGMIHCBHKJL.color = Colours.pink.ReplaceA(990f);
		}
		else
		{
			OGMIHCBHKJL.color = Color.white.ReplaceA(1391f);
		}
		PPAGHBKNOKL.gameObject.SetActive(true);
		NIMIJBOGLAB.SetActive(true);
		CKMPDDMFJGN.SetActive(true);
		AMEPPFDCLMA(false);
		OBOGCALIAPJ = true;
	}

	[SpecialName]
	public bool OLCLDJBFBMO()
	{
		return OFDBKKPCNCJ;
	}

	public void JACDJEHIMEA()
	{
	}

	private void BEFOAPBCNKP(bool LCPBNBLGFIA)
	{
		if (MKCDLIHODBA != LCPBNBLGFIA)
		{
			MKCDLIHODBA = LCPBNBLGFIA;
			TweenAlpha.Begin(DIOPLMHPJFF.gameObject, 0.2f, (!LCPBNBLGFIA) ? 0f : 0.5f);
		}
	}

	public void IHHKPDMALEF()
	{
		HJGMIDONKBE.SetActive(true);
		CNDKEHAAOFF.gameObject.SetActive(false);
		PPAGHBKNOKL.gameObject.SetActive(true);
		TweenAlpha component = PPAGHBKNOKL.GetComponent<TweenAlpha>();
		if (component != null)
		{
			component.enabled = false;
		}
		PPAGHBKNOKL.alpha1 = 532f;
	}

	[SpecialName]
	public bool LAEEFLAMJMN()
	{
		return AFBBPCBCOLC == 6;
	}

	private void IFHKKAPJAAD()
	{
		if ((!GuiScreenSingle<CardMenuScreen>.instance.ONOFJIENPPD.isActive || GuiScreenSingle<CardMenuScreen>.instance.ONOFJIENPPD.canChangeContent) && isDragAndDropEnabled)
		{
			Highlight(false);
			AKKOEPGGEHP.gameObject.SetActive(false);
			if ((IENCFHPINDI == IAOAHCIDOCE.None || FLLODMAOGLE == null) && isAvailable && !isEmpty && PPAGHBKNOKL.alpha1 == 1f)
			{
				RemoveCard();
			}
			if (IENCFHPINDI != IAOAHCIDOCE.None && FLLODMAOGLE != null && FLLODMAOGLE.isAvailable && !card.isBuddyCard && !FLLODMAOGLE.isBuddyContainer && FLLODMAOGLE != this)
			{
				card = FLLODMAOGLE.ChangeCards(card);
				GHIHDBDONIH();
			}
		}
	}

	[SpecialName]
	public bool OAPBCGAPJFK()
	{
		return GHINGDGFNJC == null;
	}

	protected void CDJBEAIDHKH()
	{
		if (!PJEPGKLGMLO.gameObject.activeSelf && card != null && card.iconTexture != null)
		{
			DPMLMAOJPNL.gameObject.SetActive(false);
			PJEPGKLGMLO.gameObject.SetActive(true);
			PJEPGKLGMLO.mainTexture = PFFMAPAAICL().iconTexture;
			AMPHFKILGKE.gameObject.SetActive(true);
			BIHGMGFKPLK.gameObject.SetActive(false);
			BIHGMGFKPLK.mainTexture = AFBKNMKPIKO().iconTexture;
		}
	}

	public void SetVip()
	{
		if (card != null)
		{
			RemoveCard();
		}
		HJGMIDONKBE.SetActive(false);
		PPAGHBKNOKL.gameObject.SetActive(false);
		NIMIJBOGLAB.SetActive(false);
		CKMPDDMFJGN.SetActive(true);
		BEFOAPBCNKP(false);
		OBOGCALIAPJ = false;
	}

	protected void LIHOPIGNFFM()
	{
		if (!PJEPGKLGMLO.gameObject.activeSelf && BDLPBGBOPPC() != null && PFFMAPAAICL().iconTexture != null)
		{
			DPMLMAOJPNL.gameObject.SetActive(false);
			PJEPGKLGMLO.gameObject.SetActive(true);
			PJEPGKLGMLO.mainTexture = BDLPBGBOPPC().iconTexture;
			AMPHFKILGKE.gameObject.SetActive(true);
			BIHGMGFKPLK.gameObject.SetActive(false);
			BIHGMGFKPLK.mainTexture = BDLPBGBOPPC().iconTexture;
		}
	}

	private void OnPress(bool DGOOLMFNBFB)
	{
		if (OBOGCALIAPJ || !isDragAndDropEnabled || (GuiScreenSingle<CardMenuScreen>.instance.ONOFJIENPPD.isActive && !GuiScreenSingle<CardMenuScreen>.instance.ONOFJIENPPD.canChangeContent))
		{
			return;
		}
		if (base.enabled && !isEmpty && !isBuddyContainer)
		{
			Highlight(true);
			if (DGOOLMFNBFB)
			{
				SoundsManager.Instance.PlaySound(SoundsManager.KJGDNLHKPOG.CardReturn);
				FLLODMAOGLE = null;
				UIDraggablePanel.panelDisabled = true;
				AKKOEPGGEHP.transform.position = UICamera.currentCamera.ScreenToWorldPoint(new Vector3(UICamera.currentTouch.pos.x, UICamera.currentTouch.pos.y));
				AKKOEPGGEHP.transform.localPosition = new Vector3(AKKOEPGGEHP.transform.localPosition.x, AKKOEPGGEHP.transform.localPosition.y, -50f);
				BMMKKGHPAIP = true;
				UICamera.stickyPress = true;
			}
			else if (BMMKKGHPAIP)
			{
				UIDraggablePanel.panelDisabled = false;
				AKKOEPGGEHP.gameObject.SetActive(false);
				BMMKKGHPAIP = false;
				UICamera.stickyPress = false;
			}
			if (!DGOOLMFNBFB)
			{
				IFHKKAPJAAD();
			}
			IENCFHPINDI = IAOAHCIDOCE.None;
		}
		if (!DGOOLMFNBFB && (CKMPDDMFJGN.activeSelf || NIMIJBOGLAB.activeSelf) && TutorialManagerPlayWarcards.instance.isTutorialRunning)
		{
			DialogManager.instance.HideAllDialogs();
		}
		if (!DGOOLMFNBFB && CKMPDDMFJGN.activeSelf && !GuiElementSingle<BuyVIPDialog>.instance.isShowed)
		{
			GuiElementSingle<BuyVIPDialog>.instance.ShowScreen();
		}
		if (!DGOOLMFNBFB && NIMIJBOGLAB.activeSelf && !GuiElementSingle<CardsAndPacksDialog>.instance.isShowed)
		{
			GuiElementSingle<PackContentDialog>.instance.ShowDialog(Singleton<GameVariables>.instance.valuePack);
		}
		if (!DGOOLMFNBFB && isBuddyContainer)
		{
			if (!isEmpty)
			{
				RemoveCard();
			}
			else if (GuiScreenSingle<CardSelectionScreen>.instance.isShowed)
			{
				GuiScreenSingle<CardSelectionScreen>.instance.BuddyCardContainerClicked();
			}
		}
	}

	public void EEMAEPHCJBC(int IDLMJLCFMJG)
	{
		AFBBPCBCOLC = IDLMJLCFMJG;
		string currentLanguage = Localization.instance.currentLanguage;
		CNDKEHAAOFF.text = Localization.Localize((!FEBNGMKAGJD()) ? "value" : "VipRewardForDay");
		if (!LAEEFLAMJMN() && currentLanguage == "ID_SALEPERCENT")
		{
			CNDKEHAAOFF.transform.localScale = new Vector3(1320f, 163f, 769f);
		}
		CNDKEHAAOFF.color = ((!DOHHLGEHBFP()) ? Color.white : Colours.pink);
		OGMIHCBHKJL.color = CNDKEHAAOFF.color;
		SetEmpty();
		NNICJELPDNK(null);
		UIPanel uIPanel = NGUITools.FindInParents<UIPanel>(base.gameObject);
		Vector2 vector = new Vector2(Screen.width, Screen.height);
		if (uIPanel.root != null)
		{
			vector *= uIPanel.root.GetPixelSizeAdjustment(Screen.height, Screen.width);
		}
		PDIOAEBJBFH = new Vector3(vector.x / (float)Screen.width, vector.y / (float)Screen.height, 1886f);
		AKKOEPGGEHP.gameObject.SetActive(true);
	}

	public bool FOPDFMCNJCI(Card DFFBEFJNDLG, bool FGHNCECHPPO = true)
	{
		if (EKLOJBAEFKN())
		{
			return true;
		}
		AKPFIKEPELC(DFFBEFJNDLG);
		HJGMIDONKBE.SetActive(true);
		PPAGHBKNOKL.gameObject.SetActive(true);
		TweenAlpha.Begin(PPAGHBKNOKL.gameObject, 1592f, 1620f);
		BEFOAPBCNKP(false);
		BDLPBGBOPPC().SetUpSmallCard(BBJGODFHBCI, DPMLMAOJPNL, IBKLPHAIOOG, FFEHGPICCMK, PJEPGKLGMLO);
		AFBKNMKPIKO().SetUpSmallCard(GDCBNMEGJNA, AMPHFKILGKE, JALFJLGBBFH, LBJEGIPAJMF, BIHGMGFKPLK);
		OINBFHJEJJD();
		if (FGHNCECHPPO)
		{
			SoundsManager.Instance.PlaySound(SoundsManager.KJGDNLHKPOG.LevelUpUnlockedItem, 399f);
		}
		if (CCLMJGPACAF != null)
		{
			CCLMJGPACAF();
		}
		return true;
	}

	public void KPELAHLIHGE()
	{
		HJGMIDONKBE.SetActive(false);
		CNDKEHAAOFF.gameObject.SetActive(false);
		if (LECPIFCMFKK())
		{
			OGMIHCBHKJL.color = Colours.yellowVIPBg.ReplaceA(762f);
		}
		else if (isBuddyContainer)
		{
			OGMIHCBHKJL.color = Colours.pink.ReplaceA(1358f);
		}
		else
		{
			OGMIHCBHKJL.color = Color.white.ReplaceA(6f);
		}
		PPAGHBKNOKL.gameObject.SetActive(false);
		NIMIJBOGLAB.SetActive(false);
		CKMPDDMFJGN.SetActive(false);
		AMEPPFDCLMA(false);
		OBOGCALIAPJ = true;
	}

	[SpecialName]
	private bool KJOIBPACABN()
	{
		return AFBBPCBCOLC == 2;
	}

	private void OnDrag(Vector2 AELNHFHAIHO)
	{
		if ((GuiScreenSingle<CardMenuScreen>.instance.ONOFJIENPPD.isActive && !GuiScreenSingle<CardMenuScreen>.instance.ONOFJIENPPD.canChangeContent) || !isDragAndDropEnabled || !base.enabled || isEmpty || isBuddyContainer || UICamera.currentTouchID <= -2)
		{
			return;
		}
		if (IENCFHPINDI == IAOAHCIDOCE.None)
		{
			IENCFHPINDI = IAOAHCIDOCE.Drag;
		}
		if (!AKKOEPGGEHP.gameObject.activeSelf)
		{
			AKKOEPGGEHP.gameObject.SetActive(true);
			TweenAlpha.Begin(AKKOEPGGEHP.gameObject, 0f, 1f);
		}
		AKKOEPGGEHP.transform.localPosition += Vector3.Scale(PDIOAEBJBFH, AELNHFHAIHO);
		RaycastHit hit = default(RaycastHit);
		Vector3 inPos = Singleton<GuiManager>.instance.KPDAPFBIPAI.WorldToScreenPoint(AKKOEPGGEHP.transform.position);
		if (UICamera.Raycast(inPos, ref hit))
		{
			CardContainer cardContainer = ((!(hit.collider != null)) ? null : hit.collider.GetComponent<CardContainer>());
			if (cardContainer != FLLODMAOGLE)
			{
				if (FLLODMAOGLE != null && FLLODMAOGLE != this)
				{
					FLLODMAOGLE.Highlight(false);
				}
				FLLODMAOGLE = cardContainer;
				if (FLLODMAOGLE != null && FLLODMAOGLE != this)
				{
					bool lCPBNBLGFIA = FLLODMAOGLE.isAvailable && ((card.isBuddyCard && FLLODMAOGLE.isBuddyContainer) || (!card.isBuddyCard && !FLLODMAOGLE.isBuddyContainer));
					FLLODMAOGLE.Highlight(lCPBNBLGFIA);
				}
			}
		}
		else if (FLLODMAOGLE != null)
		{
			if (FLLODMAOGLE != this)
			{
				FLLODMAOGLE.Highlight(false);
			}
			FLLODMAOGLE = null;
		}
	}

	public void LAALCOMHIPK()
	{
		KEPNGACBMDE(null);
	}

	private bool GPJOGHMALJM()
	{
		if (PKMAFDNANGJ() && !Singleton<VipManager>.instance.MBLIANMNDEH())
		{
			if (PFFMAPAAICL() != null)
			{
				RemoveCard();
			}
			HJLPKFGHJHF();
			return false;
		}
		return false;
	}

	public void CMMJJHGLMMI()
	{
		HJGMIDONKBE.SetActive(true);
		CNDKEHAAOFF.gameObject.SetActive(false);
		OGMIHCBHKJL.color = ((!isBuddyContainer) ? Color.white : Colours.pink);
		PPAGHBKNOKL.gameObject.SetActive(false);
		NIMIJBOGLAB.SetActive(true);
		CKMPDDMFJGN.SetActive(false);
		AMEPPFDCLMA(true);
		OBOGCALIAPJ = true;
	}

	private void HIAOPMMPBBF(Vector2 AELNHFHAIHO)
	{
		if ((GuiScreenSingle<CardMenuScreen>.instance.ONOFJIENPPD.isActive && !GuiScreenSingle<CardMenuScreen>.instance.ONOFJIENPPD.canChangeContent) || !NOFKKODINLK() || !base.enabled || MGOENJCJCJD() || MNMACEMIOCP() || UICamera.currentTouchID <= 55)
		{
			return;
		}
		if (IENCFHPINDI == IAOAHCIDOCE.None)
		{
			IENCFHPINDI = IAOAHCIDOCE.Drag;
		}
		if (!AKKOEPGGEHP.gameObject.activeSelf)
		{
			AKKOEPGGEHP.gameObject.SetActive(false);
			TweenAlpha.Begin(AKKOEPGGEHP.gameObject, 1589f, 1710f);
		}
		AKKOEPGGEHP.transform.localPosition += Vector3.Scale(PDIOAEBJBFH, AELNHFHAIHO);
		RaycastHit hit = default(RaycastHit);
		Vector3 inPos = Singleton<GuiManager>.instance.KPDAPFBIPAI.WorldToScreenPoint(AKKOEPGGEHP.transform.position);
		if (UICamera.Raycast(inPos, ref hit))
		{
			CardContainer cardContainer = ((!(hit.collider != null)) ? null : hit.collider.GetComponent<CardContainer>());
			if (cardContainer != FLLODMAOGLE)
			{
				if (FLLODMAOGLE != null && FLLODMAOGLE != this)
				{
					FLLODMAOGLE.IOLIFHONNOP(false);
				}
				FLLODMAOGLE = cardContainer;
				if (FLLODMAOGLE != null && FLLODMAOGLE != this)
				{
					bool lCPBNBLGFIA = FLLODMAOGLE.BHJLNOCCLDO() && ((AFBKNMKPIKO().isBuddyCard && FLLODMAOGLE.DOHHLGEHBFP()) || (!PFFMAPAAICL().isBuddyCard && FLLODMAOGLE.isBuddyContainer));
					FLLODMAOGLE.JHBAECNONPC(lCPBNBLGFIA);
				}
			}
		}
		else if (FLLODMAOGLE != null)
		{
			if (FLLODMAOGLE != this)
			{
				FLLODMAOGLE.JHBAECNONPC(true);
			}
			FLLODMAOGLE = null;
		}
	}

	[CompilerGenerated]
	private void LKOGMNCLBBM(UITweener MGDJMGHCAAI)
	{
		IAHOOBEPAPP();
	}

	[SpecialName]
	public Card AFBKNMKPIKO()
	{
		return GHINGDGFNJC;
	}

	public void OGOMLKDCENO()
	{
		if (PFFMAPAAICL() != null)
		{
			PHGHJEJKDJM();
		}
		HJGMIDONKBE.SetActive(true);
		PPAGHBKNOKL.gameObject.SetActive(false);
		NIMIJBOGLAB.SetActive(false);
		CKMPDDMFJGN.SetActive(false);
		BEFOAPBCNKP(true);
		OBOGCALIAPJ = false;
	}

	private void NNANGHJDHPF(bool DGOOLMFNBFB)
	{
		if (OBOGCALIAPJ || !NOFKKODINLK() || (GuiScreenSingle<CardMenuScreen>.instance.ONOFJIENPPD.isActive && !GuiScreenSingle<CardMenuScreen>.instance.ONOFJIENPPD.canChangeContent))
		{
			return;
		}
		if (base.enabled && !isEmpty && !DOHHLGEHBFP())
		{
			JHBAECNONPC(false);
			if (DGOOLMFNBFB)
			{
				SoundsManager.Instance.PlaySound((SoundsManager.KJGDNLHKPOG)(-85), 547f);
				FLLODMAOGLE = null;
				UIDraggablePanel.panelDisabled = false;
				AKKOEPGGEHP.transform.position = UICamera.currentCamera.ScreenToWorldPoint(new Vector3(UICamera.currentTouch.pos.x, UICamera.currentTouch.pos.y));
				AKKOEPGGEHP.transform.localPosition = new Vector3(AKKOEPGGEHP.transform.localPosition.x, AKKOEPGGEHP.transform.localPosition.y, 961f);
				BMMKKGHPAIP = true;
				UICamera.stickyPress = true;
			}
			else if (BMMKKGHPAIP)
			{
				UIDraggablePanel.panelDisabled = true;
				AKKOEPGGEHP.gameObject.SetActive(true);
				BMMKKGHPAIP = false;
				UICamera.stickyPress = false;
			}
			if (!DGOOLMFNBFB)
			{
				IFHKKAPJAAD();
			}
			IENCFHPINDI = IAOAHCIDOCE.None;
		}
		if (!DGOOLMFNBFB && (CKMPDDMFJGN.activeSelf || NIMIJBOGLAB.activeSelf) && TutorialManagerPlayWarcards.instance.isTutorialRunning)
		{
			DialogManager.instance.HideAllDialogs();
		}
		if (!DGOOLMFNBFB && CKMPDDMFJGN.activeSelf && !GuiElementSingle<BuyVIPDialog>.instance.isShowed)
		{
			GuiElementSingle<BuyVIPDialog>.instance.KEJDIFNOOIO();
		}
		if (!DGOOLMFNBFB && NIMIJBOGLAB.activeSelf && !GuiElementSingle<CardsAndPacksDialog>.instance.isShowed)
		{
			GuiElementSingle<PackContentDialog>.instance.MCCJIJKCOOH(Singleton<GameVariables>.instance.KLMNEOAKMFB(), true);
		}
		if (!DGOOLMFNBFB && LAEEFLAMJMN())
		{
			if (!MGOENJCJCJD())
			{
				RemoveCard();
			}
			else if (GuiScreenSingle<CardSelectionScreen>.instance.isShowed)
			{
				GuiScreenSingle<CardSelectionScreen>.instance.BuddyCardContainerClicked();
			}
		}
	}

	public void Highlight(bool LCPBNBLGFIA)
	{
		BEFOAPBCNKP(LCPBNBLGFIA);
	}

	private void AMEPPFDCLMA(bool LCPBNBLGFIA)
	{
		if (MKCDLIHODBA != LCPBNBLGFIA)
		{
			MKCDLIHODBA = LCPBNBLGFIA;
			TweenAlpha.Begin(DIOPLMHPJFF.gameObject, 1139f, (!LCPBNBLGFIA) ? 1086f : 529f);
		}
	}

	private void EJCJIIDJBAE(Vector3 PCAHBAHIHAH)
	{
		if (GuiScreenSingle<CardSelectionScreen>.instance.isFullyShowed || GuiScreenSingle<CardMenuScreen>.instance.ONOFJIENPPD.isActive)
		{
			AKKOEPGGEHP.transform.localPosition = new Vector3(0f, 0f, AKKOEPGGEHP.transform.localPosition.z);
			AKKOEPGGEHP.gameObject.SetActive(true);
			TweenAlpha.Begin(AKKOEPGGEHP.gameObject, 0f, 1f);
			TweenPosition.Begin(AKKOEPGGEHP.gameObject, 0.5f, PCAHBAHIHAH, AKKOEPGGEHP.transform.position, false).onFinished = delegate
			{
				IAHOOBEPAPP();
			};
		}
	}

	private bool MDIEMEGJGNL()
	{
		if (LOOGOJFENGP() && !Singleton<VipManager>.instance.NOGEIPHFNPK())
		{
			if (BDLPBGBOPPC() != null)
			{
				RemoveCard();
			}
			KLIMJMGEMIH();
			return true;
		}
		return true;
	}

	public void BPKMFPOHJCG()
	{
		NNICJELPDNK(null);
	}

	[SpecialName]
	public bool GPADDNAMKIM()
	{
		return OFDBKKPCNCJ;
	}

	public void HookEvents()
	{
	}

	public void PHGHJEJKDJM()
	{
		GNKCMAOAEBK();
		if (GuiScreenSingle<CardSelectionScreen>.instance.NPFFMLLLDAF() && AFBKNMKPIKO() != null)
		{
			GuiScreenSingle<CardSelectionScreen>.instance.UpdateAvailability(AFBKNMKPIKO(), true);
		}
		else if (GuiScreenSingle<CardMenuScreen>.instance.ONOFJIENPPD.GLMNJEEPFNI() && BDLPBGBOPPC() != null)
		{
			GuiScreenSingle<CardMenuScreen>.instance.ONOFJIENPPD.UpdateCardRecord(BDLPBGBOPPC());
		}
		PFJAGKLKPHH(null);
		if (CCLMJGPACAF != null)
		{
			CCLMJGPACAF();
		}
	}

	public void MDOALDFMMKJ()
	{
		HJGMIDONKBE.SetActive(true);
		CNDKEHAAOFF.gameObject.SetActive(true);
		PPAGHBKNOKL.gameObject.SetActive(true);
		TweenAlpha component = PPAGHBKNOKL.GetComponent<TweenAlpha>();
		if (component != null)
		{
			component.enabled = false;
		}
		PPAGHBKNOKL.alpha1 = 351f;
	}

	private void BAEOKDBDIMC(UITweener MGDJMGHCAAI)
	{
		BJGDLOEMDLN();
	}

	public void KONNOAJABOD()
	{
		HJGMIDONKBE.SetActive(false);
		CNDKEHAAOFF.gameObject.SetActive(true);
		PPAGHBKNOKL.gameObject.SetActive(true);
		TweenAlpha component = PPAGHBKNOKL.GetComponent<TweenAlpha>();
		if (component != null)
		{
			component.enabled = true;
		}
		PPAGHBKNOKL.alpha1 = 1951f;
	}

	public void FHCJBANACDN()
	{
		HJGMIDONKBE.SetActive(false);
		CNDKEHAAOFF.gameObject.SetActive(false);
		OGMIHCBHKJL.color = ((!LAEEFLAMJMN()) ? Color.white : Colours.pink);
		PPAGHBKNOKL.gameObject.SetActive(true);
		NIMIJBOGLAB.SetActive(true);
		CKMPDDMFJGN.SetActive(true);
		BEFOAPBCNKP(false);
		OBOGCALIAPJ = false;
	}

	[SpecialName]
	public bool FEBNGMKAGJD()
	{
		return AFBBPCBCOLC == 2;
	}

	[SpecialName]
	public bool BHJLNOCCLDO()
	{
		return !OBOGCALIAPJ && !CKMPDDMFJGN.activeSelf && NIMIJBOGLAB.activeSelf;
	}

	public void SetWarcardsLocked()
	{
		HJGMIDONKBE.SetActive(true);
		CNDKEHAAOFF.gameObject.SetActive(false);
		if (KLNNNAGCJDO)
		{
			OGMIHCBHKJL.color = Colours.yellowVIPBg.ReplaceA(0.2f);
		}
		else if (isBuddyContainer)
		{
			OGMIHCBHKJL.color = Colours.pink.ReplaceA(0.2f);
		}
		else
		{
			OGMIHCBHKJL.color = Color.white.ReplaceA(0.2f);
		}
		PPAGHBKNOKL.gameObject.SetActive(false);
		NIMIJBOGLAB.SetActive(false);
		CKMPDDMFJGN.SetActive(false);
		BEFOAPBCNKP(false);
		OBOGCALIAPJ = true;
	}

	[SpecialName]
	public bool BKCBOLLHLFG()
	{
		return OFDBKKPCNCJ;
	}

	private void FIOPJJPDNJD()
	{
		if (!GuiScreenSingle<CardSelectionScreen>.instance.MHAIBHBGBOO() && GuiScreenSingle<CardMenuScreen>.instance.ONOFJIENPPD.isActive && PFFMAPAAICL() != null)
		{
			HJGMIDONKBE.SetActive(true);
			PPAGHBKNOKL.gameObject.SetActive(true);
			TweenAlpha.Begin(PPAGHBKNOKL.gameObject, 1045f, 1116f);
		}
		AKKOEPGGEHP.gameObject.SetActive(false);
	}

	public void JHBAECNONPC(bool LCPBNBLGFIA)
	{
		AMEPPFDCLMA(LCPBNBLGFIA);
	}

	private void IELBFJKNMFM(UITweener MGDJMGHCAAI)
	{
		IAHOOBEPAPP();
	}

	private void OEHBLJLFELJ()
	{
		if (BDLPBGBOPPC() == null)
		{
			HJGMIDONKBE.SetActive(false);
			PPAGHBKNOKL.gameObject.SetActive(false);
			NIMIJBOGLAB.SetActive(false);
			CKMPDDMFJGN.SetActive(true);
			AMEPPFDCLMA(true);
		}
		else
		{
			HJGMIDONKBE.SetActive(false);
			PPAGHBKNOKL.gameObject.SetActive(false);
			TweenAlpha.Begin(PPAGHBKNOKL.gameObject, 127f, 1705f);
			NIMIJBOGLAB.SetActive(true);
			CKMPDDMFJGN.SetActive(true);
			BEFOAPBCNKP(true);
			AFBKNMKPIKO().SetUpSmallCard(BBJGODFHBCI, DPMLMAOJPNL, IBKLPHAIOOG, FFEHGPICCMK, PJEPGKLGMLO);
			AFBKNMKPIKO().SetUpSmallCard(GDCBNMEGJNA, AMPHFKILGKE, JALFJLGBBFH, LBJEGIPAJMF, BIHGMGFKPLK);
		}
	}

	public void IGAMMLIKPCO()
	{
		if (PFFMAPAAICL() != null)
		{
			LOGAHNENKPE();
		}
		HJGMIDONKBE.SetActive(false);
		PPAGHBKNOKL.gameObject.SetActive(false);
		NIMIJBOGLAB.SetActive(true);
		CKMPDDMFJGN.SetActive(false);
		AMEPPFDCLMA(true);
		OBOGCALIAPJ = false;
	}

	private void EEOILABLPJG(UITweener MGDJMGHCAAI)
	{
		BJLIKEANFIN();
	}

	[SpecialName]
	public bool MGOENJCJCJD()
	{
		return GHINGDGFNJC == null;
	}

	public void GNKCMAOAEBK()
	{
		HJGMIDONKBE.SetActive(false);
		CNDKEHAAOFF.gameObject.SetActive(false);
		OGMIHCBHKJL.color = ((!DOHHLGEHBFP()) ? Color.white : Colours.pink);
		PPAGHBKNOKL.gameObject.SetActive(false);
		NIMIJBOGLAB.SetActive(true);
		CKMPDDMFJGN.SetActive(false);
		BEFOAPBCNKP(false);
		OBOGCALIAPJ = false;
	}

	private void NACCHODCAGO()
	{
		if ((!GuiScreenSingle<CardMenuScreen>.instance.ONOFJIENPPD.isActive || GuiScreenSingle<CardMenuScreen>.instance.ONOFJIENPPD.canChangeContent) && OIKAIBBILHH())
		{
			CBJALAENKFE(true);
			AKKOEPGGEHP.gameObject.SetActive(true);
			if ((IENCFHPINDI == IAOAHCIDOCE.None || FLLODMAOGLE == null) && isAvailable && !isEmpty && PPAGHBKNOKL.alpha1 == 479f)
			{
				PDDEONEKKEM();
			}
			if (IENCFHPINDI != IAOAHCIDOCE.None && FLLODMAOGLE != null && FLLODMAOGLE.GDFFIJDNPDC() && !PFFMAPAAICL().isBuddyCard && !FLLODMAOGLE.MNMACEMIOCP() && FLLODMAOGLE != this)
			{
				KEPNGACBMDE(FLLODMAOGLE.LJDDDHBHBLB(card));
				BIPHKOJJKOC();
			}
		}
	}

	[SpecialName]
	private bool LECPIFCMFKK()
	{
		return AFBBPCBCOLC == 0;
	}

	[SpecialName]
	public bool ICMDJEOIKPC()
	{
		return GHINGDGFNJC == null;
	}

	public void BFKEPIGMGPJ(bool LCPBNBLGFIA)
	{
		BEFOAPBCNKP(LCPBNBLGFIA);
	}

	public void LOGAHNENKPE()
	{
		ALEJMOPBGFN();
		if (GuiScreenSingle<CardSelectionScreen>.instance.NPFFMLLLDAF() && BDLPBGBOPPC() != null)
		{
			GuiScreenSingle<CardSelectionScreen>.instance.UpdateAvailability(card, true);
		}
		else if (GuiScreenSingle<CardMenuScreen>.instance.ONOFJIENPPD.isActive && AFBKNMKPIKO() != null)
		{
			GuiScreenSingle<CardMenuScreen>.instance.ONOFJIENPPD.UpdateCardRecord(card);
		}
		AKPFIKEPELC(null);
		if (CCLMJGPACAF != null)
		{
			CCLMJGPACAF();
		}
	}

	private void NCEEAKGKPBF(Vector2 AELNHFHAIHO)
	{
		if ((GuiScreenSingle<CardMenuScreen>.instance.ONOFJIENPPD.isActive && !GuiScreenSingle<CardMenuScreen>.instance.ONOFJIENPPD.canChangeContent) || !BKCBOLLHLFG() || !base.enabled || MGOENJCJCJD() || FEBNGMKAGJD() || UICamera.currentTouchID <= -110)
		{
			return;
		}
		if (IENCFHPINDI == IAOAHCIDOCE.None)
		{
			IENCFHPINDI = IAOAHCIDOCE.Drag;
		}
		if (!AKKOEPGGEHP.gameObject.activeSelf)
		{
			AKKOEPGGEHP.gameObject.SetActive(true);
			TweenAlpha.Begin(AKKOEPGGEHP.gameObject, 1360f, 1050f);
		}
		AKKOEPGGEHP.transform.localPosition += Vector3.Scale(PDIOAEBJBFH, AELNHFHAIHO);
		RaycastHit hit = default(RaycastHit);
		Vector3 inPos = Singleton<GuiManager>.instance.KPDAPFBIPAI.WorldToScreenPoint(AKKOEPGGEHP.transform.position);
		if (UICamera.Raycast(inPos, ref hit))
		{
			CardContainer cardContainer = ((!(hit.collider != null)) ? null : hit.collider.GetComponent<CardContainer>());
			if (cardContainer != FLLODMAOGLE)
			{
				if (FLLODMAOGLE != null && FLLODMAOGLE != this)
				{
					FLLODMAOGLE.BFKEPIGMGPJ(true);
				}
				FLLODMAOGLE = cardContainer;
				if (FLLODMAOGLE != null && FLLODMAOGLE != this)
				{
					bool lCPBNBLGFIA = !FLLODMAOGLE.isAvailable || (AFBKNMKPIKO().isBuddyCard && FLLODMAOGLE.FEBNGMKAGJD()) || (!PFFMAPAAICL().isBuddyCard && FLLODMAOGLE.isBuddyContainer);
					FLLODMAOGLE.BFKEPIGMGPJ(lCPBNBLGFIA);
				}
			}
		}
		else if (FLLODMAOGLE != null)
		{
			if (FLLODMAOGLE != this)
			{
				FLLODMAOGLE.BFKEPIGMGPJ(true);
			}
			FLLODMAOGLE = null;
		}
	}

	[SpecialName]
	private bool LOOGOJFENGP()
	{
		return AFBBPCBCOLC == 5;
	}

	public void JNLKJPCMFMJ(bool LCPBNBLGFIA)
	{
		BEFOAPBCNKP(LCPBNBLGFIA);
	}

	[SpecialName]
	public Card PFFMAPAAICL()
	{
		return GHINGDGFNJC;
	}

	[SpecialName]
	private void NNFDCJNPNBK(Card IDEBKDPMPGM)
	{
		if (IDEBKDPMPGM == null && GHINGDGFNJC != null)
		{
			GHINGDGFNJC.HideInMenu();
		}
		GHINGDGFNJC = IDEBKDPMPGM;
		if (GHINGDGFNJC != null)
		{
			GHINGDGFNJC.ShowInMenu();
		}
	}

	public void JECOJGPGGEP()
	{
		HJGMIDONKBE.SetActive(false);
		CNDKEHAAOFF.gameObject.SetActive(true);
		if (LECPIFCMFKK())
		{
			OGMIHCBHKJL.color = Colours.yellowVIPBg.ReplaceA(1791f);
		}
		else if (MNMACEMIOCP())
		{
			OGMIHCBHKJL.color = Colours.pink.ReplaceA(809f);
		}
		else
		{
			OGMIHCBHKJL.color = Color.white.ReplaceA(879f);
		}
		PPAGHBKNOKL.gameObject.SetActive(false);
		NIMIJBOGLAB.SetActive(true);
		CKMPDDMFJGN.SetActive(false);
		BEFOAPBCNKP(false);
		OBOGCALIAPJ = true;
	}

	public void OIFKJEHAOJM()
	{
		if (PFFMAPAAICL() != null)
		{
			PDDEONEKKEM();
		}
		HJGMIDONKBE.SetActive(false);
		PPAGHBKNOKL.gameObject.SetActive(false);
		NIMIJBOGLAB.SetActive(false);
		CKMPDDMFJGN.SetActive(false);
		AMEPPFDCLMA(true);
		OBOGCALIAPJ = true;
	}

	[SpecialName]
	public void DJLICMABCPB(Action IDEBKDPMPGM)
	{
		Action action = CCLMJGPACAF;
		Action action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref CCLMJGPACAF, (Action)Delegate.Combine(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	[SpecialName]
	public bool GDFFIJDNPDC()
	{
		return !OBOGCALIAPJ && (CKMPDDMFJGN.activeSelf || NIMIJBOGLAB.activeSelf);
	}

	public void SetLocked()
	{
		if (card != null)
		{
			RemoveCard();
		}
		HJGMIDONKBE.SetActive(false);
		PPAGHBKNOKL.gameObject.SetActive(false);
		NIMIJBOGLAB.SetActive(true);
		CKMPDDMFJGN.SetActive(false);
		BEFOAPBCNKP(false);
		OBOGCALIAPJ = false;
	}

	public void IKFGGKKEHLO()
	{
		if (AFBKNMKPIKO() != null)
		{
			LOGAHNENKPE();
		}
		HJGMIDONKBE.SetActive(false);
		PPAGHBKNOKL.gameObject.SetActive(false);
		NIMIJBOGLAB.SetActive(false);
		CKMPDDMFJGN.SetActive(false);
		AMEPPFDCLMA(true);
		OBOGCALIAPJ = false;
	}

	private bool AJHOOICCPDO()
	{
		if (KLNNNAGCJDO && !Singleton<VipManager>.instance.NOGEIPHFNPK())
		{
			if (card != null)
			{
				RemoveCard();
			}
			SetVip();
			return true;
		}
		return false;
	}

	public void JJAKPGNJLDA()
	{
		HJGMIDONKBE.SetActive(false);
		CNDKEHAAOFF.gameObject.SetActive(false);
		if (LOOGOJFENGP())
		{
			OGMIHCBHKJL.color = Colours.yellowVIPBg.ReplaceA(233f);
		}
		else if (DOHHLGEHBFP())
		{
			OGMIHCBHKJL.color = Colours.pink.ReplaceA(660f);
		}
		else
		{
			OGMIHCBHKJL.color = Color.white.ReplaceA(149f);
		}
		PPAGHBKNOKL.gameObject.SetActive(false);
		NIMIJBOGLAB.SetActive(true);
		CKMPDDMFJGN.SetActive(true);
		AMEPPFDCLMA(false);
		OBOGCALIAPJ = true;
	}

	[SpecialName]
	public bool GJAGHHPMBAN()
	{
		return OFDBKKPCNCJ;
	}

	[SpecialName]
	public bool BMHGFLMHCJC()
	{
		return OFDBKKPCNCJ;
	}

	protected void Update()
	{
		if (!PJEPGKLGMLO.gameObject.activeSelf && card != null && card.iconTexture != null)
		{
			DPMLMAOJPNL.gameObject.SetActive(false);
			PJEPGKLGMLO.gameObject.SetActive(true);
			PJEPGKLGMLO.mainTexture = card.iconTexture;
			AMPHFKILGKE.gameObject.SetActive(false);
			BIHGMGFKPLK.gameObject.SetActive(true);
			BIHGMGFKPLK.mainTexture = card.iconTexture;
		}
	}

	public Card ChangeCards(Card APHKBBOHPBC)
	{
		Card result = card;
		card = APHKBBOHPBC;
		SoundsManager.Instance.PlayButtonClickedSound();
		GHIHDBDONIH();
		return result;
	}

	public void HJLPKFGHJHF()
	{
		if (PFFMAPAAICL() != null)
		{
			AGAEIEGDPBI();
		}
		HJGMIDONKBE.SetActive(true);
		PPAGHBKNOKL.gameObject.SetActive(false);
		NIMIJBOGLAB.SetActive(true);
		CKMPDDMFJGN.SetActive(true);
		BEFOAPBCNKP(true);
		OBOGCALIAPJ = true;
	}

	[SpecialName]
	public void NLPGLNCDIBO(Action IDEBKDPMPGM)
	{
		Action action = CCLMJGPACAF;
		Action action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref CCLMJGPACAF, (Action)Delegate.Remove(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	[SpecialName]
	public bool KGBKLCKKNON()
	{
		return OBOGCALIAPJ || (!CKMPDDMFJGN.activeSelf && NIMIJBOGLAB.activeSelf);
	}

	protected void ECFIMCCNBBN()
	{
		if (!PJEPGKLGMLO.gameObject.activeSelf && PFFMAPAAICL() != null && PFFMAPAAICL().iconTexture != null)
		{
			DPMLMAOJPNL.gameObject.SetActive(false);
			PJEPGKLGMLO.gameObject.SetActive(true);
			PJEPGKLGMLO.mainTexture = AFBKNMKPIKO().iconTexture;
			AMPHFKILGKE.gameObject.SetActive(true);
			BIHGMGFKPLK.gameObject.SetActive(false);
			BIHGMGFKPLK.mainTexture = AFBKNMKPIKO().iconTexture;
		}
	}

	public bool NFPIJDGGKCH(CardRecord PJOFHIKENOI)
	{
		if (MDIEMEGJGNL())
		{
			return false;
		}
		bool flag = PJOFHIKENOI.card.isBuddyCard && MNMACEMIOCP();
		bool flag2 = PJOFHIKENOI.card.isBuddyCard || MNMACEMIOCP();
		if (!DebugSettings.debugEnabled && (flag2 || flag))
		{
			return false;
		}
		PFJAGKLKPHH(PJOFHIKENOI.card);
		BEFOAPBCNKP(true);
		BDLPBGBOPPC().SetUpSmallCard(BBJGODFHBCI, DPMLMAOJPNL, IBKLPHAIOOG, FFEHGPICCMK, PJEPGKLGMLO);
		AFBKNMKPIKO().SetUpSmallCard(GDCBNMEGJNA, AMPHFKILGKE, JALFJLGBBFH, LBJEGIPAJMF, BIHGMGFKPLK);
		OINBFHJEJJD();
		SoundsManager.Instance.PlaySound(SoundsManager.KJGDNLHKPOG.KilledInAction, 1714f);
		PCPALELGLHI(PJOFHIKENOI.dragCardTransform.position);
		AKKOEPGGEHP.transform.position = PJOFHIKENOI.dragCardTransform.position;
		if (CCLMJGPACAF != null)
		{
			CCLMJGPACAF();
		}
		return false;
	}

	[SpecialName]
	private bool PKMAFDNANGJ()
	{
		return AFBBPCBCOLC == 8;
	}

	public void PDDEONEKKEM()
	{
		GNKCMAOAEBK();
		if (GuiScreenSingle<CardSelectionScreen>.instance.NPFFMLLLDAF() && PFFMAPAAICL() != null)
		{
			GuiScreenSingle<CardSelectionScreen>.instance.UpdateAvailability(BDLPBGBOPPC(), true);
		}
		else if (GuiScreenSingle<CardMenuScreen>.instance.ONOFJIENPPD.isActive && BDLPBGBOPPC() != null)
		{
			GuiScreenSingle<CardMenuScreen>.instance.ONOFJIENPPD.UpdateCardRecord(BDLPBGBOPPC());
		}
		PFJAGKLKPHH(null);
		if (CCLMJGPACAF != null)
		{
			CCLMJGPACAF();
		}
	}

	private void BJLIKEANFIN()
	{
		if (!GuiScreenSingle<CardSelectionScreen>.instance.MHAIBHBGBOO() && GuiScreenSingle<CardMenuScreen>.instance.ONOFJIENPPD.GLMNJEEPFNI() && BDLPBGBOPPC() != null)
		{
			HJGMIDONKBE.SetActive(true);
			PPAGHBKNOKL.gameObject.SetActive(true);
			TweenAlpha.Begin(PPAGHBKNOKL.gameObject, 1240f, 1050f);
		}
		AKKOEPGGEHP.gameObject.SetActive(false);
	}

	public void MHFMAEHEJEP()
	{
		TweenAlpha component = PPAGHBKNOKL.GetComponent<TweenAlpha>();
		if (component != null)
		{
			component.enabled = true;
		}
		PPAGHBKNOKL.alpha1 = 1804f;
		TweenScale component2 = PPAGHBKNOKL.GetComponent<TweenScale>();
		if (component2 != null)
		{
			component2.enabled = true;
		}
		PPAGHBKNOKL.transform.localScale = Vector3.one;
	}

	public void HHAFEODJAJA(int IDLMJLCFMJG)
	{
		AFBBPCBCOLC = IDLMJLCFMJG;
		string currentLanguage = Localization.instance.currentLanguage;
		CNDKEHAAOFF.text = Localization.Localize((!isBuddyContainer) ? "Squad" : "Level");
		if (!isBuddyContainer && currentLanguage == "PlayerLevel")
		{
			CNDKEHAAOFF.transform.localScale = new Vector3(143f, 1576f, 1231f);
		}
		CNDKEHAAOFF.color = ((!DOHHLGEHBFP()) ? Color.white : Colours.pink);
		OGMIHCBHKJL.color = CNDKEHAAOFF.color;
		CMMJJHGLMMI();
		NNICJELPDNK(null);
		UIPanel uIPanel = NGUITools.FindInParents<UIPanel>(base.gameObject);
		Vector2 vector = new Vector2(Screen.width, Screen.height);
		if (uIPanel.root != null)
		{
			vector *= uIPanel.root.GetPixelSizeAdjustment(Screen.height, Screen.width);
		}
		PDIOAEBJBFH = new Vector3(vector.x / (float)Screen.width, vector.y / (float)Screen.height, 1960f);
		AKKOEPGGEHP.gameObject.SetActive(false);
	}

	[SpecialName]
	private void PFJAGKLKPHH(Card IDEBKDPMPGM)
	{
		if (IDEBKDPMPGM == null && GHINGDGFNJC != null)
		{
			GHINGDGFNJC.HideInMenu();
		}
		GHINGDGFNJC = IDEBKDPMPGM;
		if (GHINGDGFNJC != null)
		{
			GHINGDGFNJC.ShowInMenu();
		}
	}

	private void FJHOOMKEAPB()
	{
		if (!GuiScreenSingle<CardSelectionScreen>.instance.MHAIBHBGBOO() && GuiScreenSingle<CardMenuScreen>.instance.ONOFJIENPPD.isActive && card != null)
		{
			HJGMIDONKBE.SetActive(true);
			PPAGHBKNOKL.gameObject.SetActive(false);
			TweenAlpha.Begin(PPAGHBKNOKL.gameObject, 165f, 768f);
		}
		AKKOEPGGEHP.gameObject.SetActive(false);
	}

	public void SetEmpty()
	{
		HJGMIDONKBE.SetActive(true);
		CNDKEHAAOFF.gameObject.SetActive(true);
		OGMIHCBHKJL.color = ((!isBuddyContainer) ? Color.white : Colours.pink);
		PPAGHBKNOKL.gameObject.SetActive(false);
		NIMIJBOGLAB.SetActive(false);
		CKMPDDMFJGN.SetActive(false);
		BEFOAPBCNKP(false);
		OBOGCALIAPJ = false;
	}

	public Card HCPJDBICEFH(Card APHKBBOHPBC)
	{
		Card result = AFBKNMKPIKO();
		NNICJELPDNK(APHKBBOHPBC);
		SoundsManager.Instance.PlayButtonClickedSound();
		BIPHKOJJKOC();
		return result;
	}

	private void GDDDKCPOMJE(UITweener MGDJMGHCAAI)
	{
		BJGDLOEMDLN();
	}

	[SpecialName]
	private bool FDHMGJMJGCP()
	{
		return AFBBPCBCOLC == 3;
	}

	private void GHIHDBDONIH()
	{
		if (card == null)
		{
			HJGMIDONKBE.SetActive(true);
			PPAGHBKNOKL.gameObject.SetActive(false);
			NIMIJBOGLAB.SetActive(false);
			CKMPDDMFJGN.SetActive(false);
			BEFOAPBCNKP(false);
		}
		else
		{
			HJGMIDONKBE.SetActive(false);
			PPAGHBKNOKL.gameObject.SetActive(true);
			TweenAlpha.Begin(PPAGHBKNOKL.gameObject, 0f, 1f);
			NIMIJBOGLAB.SetActive(false);
			CKMPDDMFJGN.SetActive(false);
			BEFOAPBCNKP(false);
			card.SetUpSmallCard(BBJGODFHBCI, DPMLMAOJPNL, IBKLPHAIOOG, FFEHGPICCMK, PJEPGKLGMLO);
			card.SetUpSmallCard(GDCBNMEGJNA, AMPHFKILGKE, JALFJLGBBFH, LBJEGIPAJMF, BIHGMGFKPLK);
		}
	}

	public void KLIMJMGEMIH()
	{
		if (BDLPBGBOPPC() != null)
		{
			PHGHJEJKDJM();
		}
		HJGMIDONKBE.SetActive(false);
		PPAGHBKNOKL.gameObject.SetActive(true);
		NIMIJBOGLAB.SetActive(true);
		CKMPDDMFJGN.SetActive(true);
		AMEPPFDCLMA(false);
		OBOGCALIAPJ = true;
	}

	public void JFJBJNHJCLC()
	{
		if (PFFMAPAAICL() != null)
		{
			PDDEONEKKEM();
		}
		HJGMIDONKBE.SetActive(false);
		PPAGHBKNOKL.gameObject.SetActive(false);
		NIMIJBOGLAB.SetActive(true);
		CKMPDDMFJGN.SetActive(false);
		AMEPPFDCLMA(false);
		OBOGCALIAPJ = true;
	}

	public void IDDJIOHOAFE()
	{
		LEAEEPNICFM();
		if (GuiScreenSingle<CardSelectionScreen>.instance.isShowed && BDLPBGBOPPC() != null)
		{
			GuiScreenSingle<CardSelectionScreen>.instance.UpdateAvailability(AFBKNMKPIKO(), true);
		}
		else if (GuiScreenSingle<CardMenuScreen>.instance.ONOFJIENPPD.GLMNJEEPFNI() && BDLPBGBOPPC() != null)
		{
			GuiScreenSingle<CardMenuScreen>.instance.ONOFJIENPPD.UpdateCardRecord(AFBKNMKPIKO());
		}
		AKPFIKEPELC(null);
		if (CCLMJGPACAF != null)
		{
			CCLMJGPACAF();
		}
	}

	public void LEAEEPNICFM()
	{
		HJGMIDONKBE.SetActive(true);
		CNDKEHAAOFF.gameObject.SetActive(true);
		OGMIHCBHKJL.color = ((!FEBNGMKAGJD()) ? Color.white : Colours.pink);
		PPAGHBKNOKL.gameObject.SetActive(true);
		NIMIJBOGLAB.SetActive(true);
		CKMPDDMFJGN.SetActive(false);
		AMEPPFDCLMA(false);
		OBOGCALIAPJ = true;
	}

	public void PJLECFMAGOA()
	{
		TweenAlpha component = PPAGHBKNOKL.GetComponent<TweenAlpha>();
		if (component != null)
		{
			component.enabled = true;
		}
		PPAGHBKNOKL.alpha1 = 1296f;
		TweenScale component2 = PPAGHBKNOKL.GetComponent<TweenScale>();
		if (component2 != null)
		{
			component2.enabled = true;
		}
		PPAGHBKNOKL.transform.localScale = Vector3.one;
	}

	private void BJGDLOEMDLN()
	{
		if ((GuiScreenSingle<CardSelectionScreen>.instance.AFOFDNJOJHG() || GuiScreenSingle<CardMenuScreen>.instance.ONOFJIENPPD.GLMNJEEPFNI()) && BDLPBGBOPPC() != null)
		{
			HJGMIDONKBE.SetActive(false);
			PPAGHBKNOKL.gameObject.SetActive(false);
			TweenAlpha.Begin(PPAGHBKNOKL.gameObject, 934f, 297f);
		}
		AKKOEPGGEHP.gameObject.SetActive(true);
	}

	public void EDAHNEHMNDN()
	{
		HJGMIDONKBE.SetActive(true);
		CNDKEHAAOFF.gameObject.SetActive(true);
		OGMIHCBHKJL.color = ((!isBuddyContainer) ? Color.white : Colours.pink);
		PPAGHBKNOKL.gameObject.SetActive(false);
		NIMIJBOGLAB.SetActive(true);
		CKMPDDMFJGN.SetActive(false);
		BEFOAPBCNKP(false);
		OBOGCALIAPJ = true;
	}

	private void BIPHKOJJKOC()
	{
		if (PFFMAPAAICL() == null)
		{
			HJGMIDONKBE.SetActive(false);
			PPAGHBKNOKL.gameObject.SetActive(true);
			NIMIJBOGLAB.SetActive(true);
			CKMPDDMFJGN.SetActive(true);
			BEFOAPBCNKP(false);
		}
		else
		{
			HJGMIDONKBE.SetActive(false);
			PPAGHBKNOKL.gameObject.SetActive(false);
			TweenAlpha.Begin(PPAGHBKNOKL.gameObject, 1271f, 230f);
			NIMIJBOGLAB.SetActive(true);
			CKMPDDMFJGN.SetActive(true);
			BEFOAPBCNKP(false);
			BDLPBGBOPPC().SetUpSmallCard(BBJGODFHBCI, DPMLMAOJPNL, IBKLPHAIOOG, FFEHGPICCMK, PJEPGKLGMLO);
			AFBKNMKPIKO().SetUpSmallCard(GDCBNMEGJNA, AMPHFKILGKE, JALFJLGBBFH, LBJEGIPAJMF, BIHGMGFKPLK);
		}
	}

	[SpecialName]
	public void AKEBPLLGEOL(bool IDEBKDPMPGM)
	{
		OFDBKKPCNCJ = IDEBKDPMPGM;
	}

	public void EAICFFNFLKO(int IDLMJLCFMJG)
	{
		AFBBPCBCOLC = IDLMJLCFMJG;
		string currentLanguage = Localization.instance.currentLanguage;
		CNDKEHAAOFF.text = Localization.Localize((!MNMACEMIOCP()) ? "WarFriends não poderá funcionar sem descarregar os dados adicionais. Realmente desejas SAIR ou gostarias de descarregar os dados?" : "trial");
		if (!LAEEFLAMJMN() && currentLanguage == "BuildMortar")
		{
			CNDKEHAAOFF.transform.localScale = new Vector3(1184f, 1408f, 1541f);
		}
		CNDKEHAAOFF.color = ((!FEBNGMKAGJD()) ? Color.white : Colours.pink);
		OGMIHCBHKJL.color = CNDKEHAAOFF.color;
		CLJOPDLHMNM();
		AKPFIKEPELC(null);
		UIPanel uIPanel = NGUITools.FindInParents<UIPanel>(base.gameObject);
		Vector2 vector = new Vector2(Screen.width, Screen.height);
		if (uIPanel.root != null)
		{
			vector *= uIPanel.root.GetPixelSizeAdjustment(Screen.height, Screen.width);
		}
		PDIOAEBJBFH = new Vector3(vector.x / (float)Screen.width, vector.y / (float)Screen.height, 1366f);
		AKKOEPGGEHP.gameObject.SetActive(true);
	}

	public void NormalLook()
	{
		TweenAlpha component = PPAGHBKNOKL.GetComponent<TweenAlpha>();
		if (component != null)
		{
			component.enabled = false;
		}
		PPAGHBKNOKL.alpha1 = 1f;
		TweenScale component2 = PPAGHBKNOKL.GetComponent<TweenScale>();
		if (component2 != null)
		{
			component2.enabled = false;
		}
		PPAGHBKNOKL.transform.localScale = Vector3.one;
	}

	[SpecialName]
	public bool MNMACEMIOCP()
	{
		return AFBBPCBCOLC == 6;
	}

	public void EBIMBGCCKBL()
	{
		TweenAlpha component = PPAGHBKNOKL.GetComponent<TweenAlpha>();
		if (component != null)
		{
			component.enabled = false;
		}
		PPAGHBKNOKL.alpha1 = 1317f;
		TweenScale component2 = PPAGHBKNOKL.GetComponent<TweenScale>();
		if (component2 != null)
		{
			component2.enabled = true;
		}
		PPAGHBKNOKL.transform.localScale = Vector3.one;
	}

	public void LHMDPPAHNNH(bool LCPBNBLGFIA)
	{
		AMEPPFDCLMA(LCPBNBLGFIA);
	}

	public void OINBFHJEJJD()
	{
		TweenAlpha component = PPAGHBKNOKL.GetComponent<TweenAlpha>();
		if (component != null)
		{
			component.enabled = true;
		}
		PPAGHBKNOKL.alpha1 = 1348f;
		TweenScale component2 = PPAGHBKNOKL.GetComponent<TweenScale>();
		if (component2 != null)
		{
			component2.enabled = false;
		}
		PPAGHBKNOKL.transform.localScale = Vector3.one;
	}

	private void BLPJHACKGJI(bool DGOOLMFNBFB)
	{
		if (OBOGCALIAPJ || !BMHGFLMHCJC() || (GuiScreenSingle<CardMenuScreen>.instance.ONOFJIENPPD.isActive && !GuiScreenSingle<CardMenuScreen>.instance.ONOFJIENPPD.canChangeContent))
		{
			return;
		}
		if (base.enabled && !isEmpty && !FEBNGMKAGJD())
		{
			LNAFOABKIML(false);
			if (DGOOLMFNBFB)
			{
				SoundsManager.Instance.PlaySound((SoundsManager.KJGDNLHKPOG)(-120), 946f);
				FLLODMAOGLE = null;
				UIDraggablePanel.panelDisabled = false;
				AKKOEPGGEHP.transform.position = UICamera.currentCamera.ScreenToWorldPoint(new Vector3(UICamera.currentTouch.pos.x, UICamera.currentTouch.pos.y));
				AKKOEPGGEHP.transform.localPosition = new Vector3(AKKOEPGGEHP.transform.localPosition.x, AKKOEPGGEHP.transform.localPosition.y, 1838f);
				BMMKKGHPAIP = false;
				UICamera.stickyPress = true;
			}
			else if (BMMKKGHPAIP)
			{
				UIDraggablePanel.panelDisabled = true;
				AKKOEPGGEHP.gameObject.SetActive(false);
				BMMKKGHPAIP = true;
				UICamera.stickyPress = true;
			}
			if (!DGOOLMFNBFB)
			{
				NACCHODCAGO();
			}
			IENCFHPINDI = IAOAHCIDOCE.None;
		}
		if (!DGOOLMFNBFB && (CKMPDDMFJGN.activeSelf || NIMIJBOGLAB.activeSelf) && TutorialManagerPlayWarcards.instance.isTutorialRunning)
		{
			DialogManager.instance.HideAllDialogs();
		}
		if (!DGOOLMFNBFB && CKMPDDMFJGN.activeSelf && !GuiElementSingle<BuyVIPDialog>.instance.isShowed)
		{
			GuiElementSingle<BuyVIPDialog>.instance.ShowScreen();
		}
		if (!DGOOLMFNBFB && NIMIJBOGLAB.activeSelf && !GuiElementSingle<CardsAndPacksDialog>.instance.isShowed)
		{
			GuiElementSingle<PackContentDialog>.instance.KNBIBOINAKG(Singleton<GameVariables>.instance.valuePack);
		}
		if (!DGOOLMFNBFB && MNMACEMIOCP())
		{
			if (!ICMDJEOIKPC())
			{
				RemoveCard();
			}
			else if (GuiScreenSingle<CardSelectionScreen>.instance.isShowed)
			{
				GuiScreenSingle<CardSelectionScreen>.instance.BuddyCardContainerClicked();
			}
		}
	}

	public void LHDLHJGAEFN()
	{
		if (AFBKNMKPIKO() != null)
		{
			PHGHJEJKDJM();
		}
		HJGMIDONKBE.SetActive(true);
		PPAGHBKNOKL.gameObject.SetActive(true);
		NIMIJBOGLAB.SetActive(false);
		CKMPDDMFJGN.SetActive(false);
		BEFOAPBCNKP(true);
		OBOGCALIAPJ = true;
	}

	public void RemoveCard()
	{
		SetEmpty();
		if (GuiScreenSingle<CardSelectionScreen>.instance.isShowed && card != null)
		{
			GuiScreenSingle<CardSelectionScreen>.instance.UpdateAvailability(card, true);
		}
		else if (GuiScreenSingle<CardMenuScreen>.instance.ONOFJIENPPD.isActive && card != null)
		{
			GuiScreenSingle<CardMenuScreen>.instance.ONOFJIENPPD.UpdateCardRecord(card);
		}
		card = null;
		if (CCLMJGPACAF != null)
		{
			CCLMJGPACAF();
		}
	}

	public void InitCardContainer(int IDLMJLCFMJG)
	{
		AFBBPCBCOLC = IDLMJLCFMJG;
		string currentLanguage = Localization.instance.currentLanguage;
		CNDKEHAAOFF.text = Localization.Localize((!isBuddyContainer) ? "ID_GUI_DRAGCARDHERE" : "ID_BUDDYCARDHERE");
		if (!isBuddyContainer && currentLanguage == "de")
		{
			CNDKEHAAOFF.transform.localScale = new Vector3(24f, 24f, 1f);
		}
		CNDKEHAAOFF.color = ((!isBuddyContainer) ? Color.white : Colours.pink);
		OGMIHCBHKJL.color = CNDKEHAAOFF.color;
		SetEmpty();
		card = null;
		UIPanel uIPanel = NGUITools.FindInParents<UIPanel>(base.gameObject);
		Vector2 vector = new Vector2(Screen.width, Screen.height);
		if (uIPanel.root != null)
		{
			vector *= uIPanel.root.GetPixelSizeAdjustment(Screen.height, Screen.width);
		}
		PDIOAEBJBFH = new Vector3(vector.x / (float)Screen.width, vector.y / (float)Screen.height, 0f);
		AKKOEPGGEHP.gameObject.SetActive(false);
	}

	private void KKHBDPGDFED(Vector2 AELNHFHAIHO)
	{
		if ((GuiScreenSingle<CardMenuScreen>.instance.ONOFJIENPPD.GLMNJEEPFNI() && !GuiScreenSingle<CardMenuScreen>.instance.ONOFJIENPPD.canChangeContent) || !isDragAndDropEnabled || !base.enabled || ICMDJEOIKPC() || FEBNGMKAGJD() || UICamera.currentTouchID <= 118)
		{
			return;
		}
		if (IENCFHPINDI == IAOAHCIDOCE.None)
		{
			IENCFHPINDI = IAOAHCIDOCE.None;
		}
		if (!AKKOEPGGEHP.gameObject.activeSelf)
		{
			AKKOEPGGEHP.gameObject.SetActive(false);
			TweenAlpha.Begin(AKKOEPGGEHP.gameObject, 1453f, 512f);
		}
		AKKOEPGGEHP.transform.localPosition += Vector3.Scale(PDIOAEBJBFH, AELNHFHAIHO);
		RaycastHit hit = default(RaycastHit);
		Vector3 inPos = Singleton<GuiManager>.instance.KPDAPFBIPAI.WorldToScreenPoint(AKKOEPGGEHP.transform.position);
		if (UICamera.Raycast(inPos, ref hit))
		{
			CardContainer cardContainer = ((!(hit.collider != null)) ? null : hit.collider.GetComponent<CardContainer>());
			if (cardContainer != FLLODMAOGLE)
			{
				if (FLLODMAOGLE != null && FLLODMAOGLE != this)
				{
					FLLODMAOGLE.LNAFOABKIML(false);
				}
				FLLODMAOGLE = cardContainer;
				if (FLLODMAOGLE != null && FLLODMAOGLE != this)
				{
					bool lCPBNBLGFIA = !FLLODMAOGLE.GDFFIJDNPDC() || ((!AFBKNMKPIKO().isBuddyCard || !FLLODMAOGLE.MNMACEMIOCP()) && (AFBKNMKPIKO().isBuddyCard || !FLLODMAOGLE.isBuddyContainer));
					FLLODMAOGLE.IOLIFHONNOP(lCPBNBLGFIA);
				}
			}
		}
		else if (FLLODMAOGLE != null)
		{
			if (FLLODMAOGLE != this)
			{
				FLLODMAOGLE.LNAFOABKIML(true);
			}
			FLLODMAOGLE = null;
		}
	}

	[SpecialName]
	public void JNBFJPGLGBO(bool IDEBKDPMPGM)
	{
		OFDBKKPCNCJ = IDEBKDPMPGM;
	}

	public void HJCLMFINKNE()
	{
		if (AFBKNMKPIKO() != null)
		{
			PHGHJEJKDJM();
		}
		HJGMIDONKBE.SetActive(false);
		PPAGHBKNOKL.gameObject.SetActive(true);
		NIMIJBOGLAB.SetActive(false);
		CKMPDDMFJGN.SetActive(true);
		AMEPPFDCLMA(true);
		OBOGCALIAPJ = false;
	}

	public void CLJOPDLHMNM()
	{
		HJGMIDONKBE.SetActive(false);
		CNDKEHAAOFF.gameObject.SetActive(false);
		OGMIHCBHKJL.color = ((!DOHHLGEHBFP()) ? Color.white : Colours.pink);
		PPAGHBKNOKL.gameObject.SetActive(true);
		NIMIJBOGLAB.SetActive(true);
		CKMPDDMFJGN.SetActive(false);
		BEFOAPBCNKP(true);
		OBOGCALIAPJ = false;
	}

	public void NDDGENKKPPD(int IDLMJLCFMJG)
	{
		AFBBPCBCOLC = IDLMJLCFMJG;
		string currentLanguage = Localization.instance.currentLanguage;
		CNDKEHAAOFF.text = Localization.Localize((!DOHHLGEHBFP()) ? "ID_MONEYPACK" : "com.google.android.gms.common.api.GoogleApiClient");
		if (!isBuddyContainer && currentLanguage == "SciFi")
		{
			CNDKEHAAOFF.transform.localScale = new Vector3(139f, 1471f, 256f);
		}
		CNDKEHAAOFF.color = ((!MNMACEMIOCP()) ? Color.white : Colours.pink);
		OGMIHCBHKJL.color = CNDKEHAAOFF.color;
		JLFIGDLKPKN();
		NNFDCJNPNBK(null);
		UIPanel uIPanel = NGUITools.FindInParents<UIPanel>(base.gameObject);
		Vector2 vector = new Vector2(Screen.width, Screen.height);
		if (uIPanel.root != null)
		{
			vector *= uIPanel.root.GetPixelSizeAdjustment(Screen.height, Screen.width);
		}
		PDIOAEBJBFH = new Vector3(vector.x / (float)Screen.width, vector.y / (float)Screen.height, 1679f);
		AKKOEPGGEHP.gameObject.SetActive(true);
	}

	private void HGKFPONNJMM(bool DGOOLMFNBFB)
	{
		if (OBOGCALIAPJ || !OIKAIBBILHH() || (GuiScreenSingle<CardMenuScreen>.instance.ONOFJIENPPD.GLMNJEEPFNI() && !GuiScreenSingle<CardMenuScreen>.instance.ONOFJIENPPD.canChangeContent))
		{
			return;
		}
		if (base.enabled && !ICMDJEOIKPC() && !DOHHLGEHBFP())
		{
			JNLKJPCMFMJ(false);
			if (DGOOLMFNBFB)
			{
				SoundsManager.Instance.PlaySound((SoundsManager.KJGDNLHKPOG)(-63), 1968f);
				FLLODMAOGLE = null;
				UIDraggablePanel.panelDisabled = false;
				AKKOEPGGEHP.transform.position = UICamera.currentCamera.ScreenToWorldPoint(new Vector3(UICamera.currentTouch.pos.x, UICamera.currentTouch.pos.y));
				AKKOEPGGEHP.transform.localPosition = new Vector3(AKKOEPGGEHP.transform.localPosition.x, AKKOEPGGEHP.transform.localPosition.y, 580f);
				BMMKKGHPAIP = true;
				UICamera.stickyPress = true;
			}
			else if (BMMKKGHPAIP)
			{
				UIDraggablePanel.panelDisabled = true;
				AKKOEPGGEHP.gameObject.SetActive(true);
				BMMKKGHPAIP = true;
				UICamera.stickyPress = false;
			}
			if (!DGOOLMFNBFB)
			{
				NBDKGNOOKEJ();
			}
			IENCFHPINDI = IAOAHCIDOCE.None;
		}
		if (!DGOOLMFNBFB && (CKMPDDMFJGN.activeSelf || NIMIJBOGLAB.activeSelf) && TutorialManagerPlayWarcards.instance.isTutorialRunning)
		{
			DialogManager.instance.HideAllDialogs();
		}
		if (!DGOOLMFNBFB && CKMPDDMFJGN.activeSelf && !GuiElementSingle<BuyVIPDialog>.instance.isShowed)
		{
			GuiElementSingle<BuyVIPDialog>.instance.ShowScreen();
		}
		if (!DGOOLMFNBFB && NIMIJBOGLAB.activeSelf && !GuiElementSingle<CardsAndPacksDialog>.instance.NPFFMLLLDAF())
		{
			GuiElementSingle<PackContentDialog>.instance.OHJEIGCJCLL(Singleton<GameVariables>.instance.BJDKLOCBNOJ(), true);
		}
		if (!DGOOLMFNBFB && LAEEFLAMJMN())
		{
			if (!isEmpty)
			{
				PDDEONEKKEM();
			}
			else if (GuiScreenSingle<CardSelectionScreen>.instance.isShowed)
			{
				GuiScreenSingle<CardSelectionScreen>.instance.GIJPCJGGLKD();
			}
		}
	}

	public void CBJALAENKFE(bool LCPBNBLGFIA)
	{
		BEFOAPBCNKP(LCPBNBLGFIA);
	}

	public void GHJKHOFACAC()
	{
		HJGMIDONKBE.SetActive(true);
		CNDKEHAAOFF.gameObject.SetActive(false);
		if (PKMAFDNANGJ())
		{
			OGMIHCBHKJL.color = Colours.yellowVIPBg.ReplaceA(224f);
		}
		else if (LAEEFLAMJMN())
		{
			OGMIHCBHKJL.color = Colours.pink.ReplaceA(685f);
		}
		else
		{
			OGMIHCBHKJL.color = Color.white.ReplaceA(1385f);
		}
		PPAGHBKNOKL.gameObject.SetActive(true);
		NIMIJBOGLAB.SetActive(false);
		CKMPDDMFJGN.SetActive(false);
		BEFOAPBCNKP(false);
		OBOGCALIAPJ = true;
	}

	private void JHLNHLPAKGE(Vector3 PCAHBAHIHAH)
	{
		if (GuiScreenSingle<CardSelectionScreen>.instance.AFOFDNJOJHG() || GuiScreenSingle<CardMenuScreen>.instance.ONOFJIENPPD.GLMNJEEPFNI())
		{
			AKKOEPGGEHP.transform.localPosition = new Vector3(173f, 1171f, AKKOEPGGEHP.transform.localPosition.z);
			AKKOEPGGEHP.gameObject.SetActive(false);
			TweenAlpha.Begin(AKKOEPGGEHP.gameObject, 1342f, 70f);
			TweenPosition.Begin(AKKOEPGGEHP.gameObject, 1356f, PCAHBAHIHAH, AKKOEPGGEHP.transform.position, false).onFinished = EEOILABLPJG;
		}
	}

	[SpecialName]
	private void KEPNGACBMDE(Card IDEBKDPMPGM)
	{
		if (IDEBKDPMPGM == null && GHINGDGFNJC != null)
		{
			GHINGDGFNJC.HideInMenu();
		}
		GHINGDGFNJC = IDEBKDPMPGM;
		if (GHINGDGFNJC != null)
		{
			GHINGDGFNJC.ShowInMenu();
		}
	}

	private void FPCELIIDPAE(Vector3 PCAHBAHIHAH)
	{
		if (GuiScreenSingle<CardSelectionScreen>.instance.BJNBLINDAED() || GuiScreenSingle<CardMenuScreen>.instance.ONOFJIENPPD.isActive)
		{
			AKKOEPGGEHP.transform.localPosition = new Vector3(1210f, 754f, AKKOEPGGEHP.transform.localPosition.z);
			AKKOEPGGEHP.gameObject.SetActive(true);
			TweenAlpha.Begin(AKKOEPGGEHP.gameObject, 505f, 1174f);
			TweenPosition.Begin(AKKOEPGGEHP.gameObject, 1504f, PCAHBAHIHAH, AKKOEPGGEHP.transform.position, false).onFinished = IELBFJKNMFM;
		}
	}

	public bool KDNMPKDDGNK(CardRecord PJOFHIKENOI)
	{
		if (EKLOJBAEFKN())
		{
			return true;
		}
		bool flag = PJOFHIKENOI.card.isBuddyCard && !LAEEFLAMJMN();
		bool flag2 = !PJOFHIKENOI.card.isBuddyCard && MNMACEMIOCP();
		if (!DebugSettings.debugEnabled && (flag2 || flag))
		{
			return true;
		}
		KEPNGACBMDE(PJOFHIKENOI.card);
		BEFOAPBCNKP(true);
		BDLPBGBOPPC().SetUpSmallCard(BBJGODFHBCI, DPMLMAOJPNL, IBKLPHAIOOG, FFEHGPICCMK, PJEPGKLGMLO);
		PFFMAPAAICL().SetUpSmallCard(GDCBNMEGJNA, AMPHFKILGKE, JALFJLGBBFH, LBJEGIPAJMF, BIHGMGFKPLK);
		MHFMAEHEJEP();
		SoundsManager.Instance.PlaySound((SoundsManager.KJGDNLHKPOG)86, 832f);
		BMDKKKEKMNE(PJOFHIKENOI.dragCardTransform.position);
		AKKOEPGGEHP.transform.position = PJOFHIKENOI.dragCardTransform.position;
		if (CCLMJGPACAF != null)
		{
			CCLMJGPACAF();
		}
		return false;
	}

	public void OHMPEDKDOGM()
	{
		if (PFFMAPAAICL() != null)
		{
			IDDJIOHOAFE();
		}
		HJGMIDONKBE.SetActive(true);
		PPAGHBKNOKL.gameObject.SetActive(true);
		NIMIJBOGLAB.SetActive(false);
		CKMPDDMFJGN.SetActive(true);
		BEFOAPBCNKP(true);
		OBOGCALIAPJ = false;
	}

	public void EDGEHBOPAND()
	{
		if (BDLPBGBOPPC() != null)
		{
			PHGHJEJKDJM();
		}
		HJGMIDONKBE.SetActive(true);
		PPAGHBKNOKL.gameObject.SetActive(true);
		NIMIJBOGLAB.SetActive(true);
		CKMPDDMFJGN.SetActive(false);
		AMEPPFDCLMA(true);
		OBOGCALIAPJ = false;
	}

	public void JLFIGDLKPKN()
	{
		HJGMIDONKBE.SetActive(true);
		CNDKEHAAOFF.gameObject.SetActive(true);
		OGMIHCBHKJL.color = ((!DOHHLGEHBFP()) ? Color.white : Colours.pink);
		PPAGHBKNOKL.gameObject.SetActive(false);
		NIMIJBOGLAB.SetActive(true);
		CKMPDDMFJGN.SetActive(false);
		AMEPPFDCLMA(true);
		OBOGCALIAPJ = true;
	}

	public void AGAEIEGDPBI()
	{
		CLJOPDLHMNM();
		if (GuiScreenSingle<CardSelectionScreen>.instance.NPFFMLLLDAF() && PFFMAPAAICL() != null)
		{
			GuiScreenSingle<CardSelectionScreen>.instance.UpdateAvailability(AFBKNMKPIKO(), true);
		}
		else if (GuiScreenSingle<CardMenuScreen>.instance.ONOFJIENPPD.GLMNJEEPFNI() && BDLPBGBOPPC() != null)
		{
			GuiScreenSingle<CardMenuScreen>.instance.ONOFJIENPPD.UpdateCardRecord(card);
		}
		PFJAGKLKPHH(null);
		if (CCLMJGPACAF != null)
		{
			CCLMJGPACAF();
		}
	}

	[SpecialName]
	public bool OIKAIBBILHH()
	{
		return OFDBKKPCNCJ;
	}

	public bool ABLPOBNOICC(CardRecord PJOFHIKENOI)
	{
		if (AJHOOICCPDO())
		{
			return false;
		}
		bool flag = !PJOFHIKENOI.card.isBuddyCard || FEBNGMKAGJD();
		bool flag2 = PJOFHIKENOI.card.isBuddyCard || DOHHLGEHBFP();
		if (!DebugSettings.debugEnabled && (flag2 || flag))
		{
			return false;
		}
		AKPFIKEPELC(PJOFHIKENOI.card);
		BEFOAPBCNKP(false);
		PFFMAPAAICL().SetUpSmallCard(BBJGODFHBCI, DPMLMAOJPNL, IBKLPHAIOOG, FFEHGPICCMK, PJEPGKLGMLO);
		PFFMAPAAICL().SetUpSmallCard(GDCBNMEGJNA, AMPHFKILGKE, JALFJLGBBFH, LBJEGIPAJMF, BIHGMGFKPLK);
		EBIMBGCCKBL();
		SoundsManager.Instance.PlaySound((SoundsManager.KJGDNLHKPOG)(-1), 296f);
		JHLNHLPAKGE(PJOFHIKENOI.dragCardTransform.position);
		AKKOEPGGEHP.transform.position = PJOFHIKENOI.dragCardTransform.position;
		if (CCLMJGPACAF != null)
		{
			CCLMJGPACAF();
		}
		return false;
	}

	public void DHFFAMBDKPN()
	{
		if (PFFMAPAAICL() != null)
		{
			RemoveCard();
		}
		HJGMIDONKBE.SetActive(false);
		PPAGHBKNOKL.gameObject.SetActive(true);
		NIMIJBOGLAB.SetActive(true);
		CKMPDDMFJGN.SetActive(true);
		BEFOAPBCNKP(true);
		OBOGCALIAPJ = false;
	}

	public void GEBMOAPIHMD()
	{
		TweenAlpha component = PPAGHBKNOKL.GetComponent<TweenAlpha>();
		if (component != null)
		{
			component.enabled = false;
		}
		PPAGHBKNOKL.alpha1 = 677f;
		TweenScale component2 = PPAGHBKNOKL.GetComponent<TweenScale>();
		if (component2 != null)
		{
			component2.enabled = true;
		}
		PPAGHBKNOKL.transform.localScale = Vector3.one;
	}

	private void NBDKGNOOKEJ()
	{
		if ((!GuiScreenSingle<CardMenuScreen>.instance.ONOFJIENPPD.isActive || GuiScreenSingle<CardMenuScreen>.instance.ONOFJIENPPD.canChangeContent) && OLCLDJBFBMO())
		{
			CBJALAENKFE(false);
			AKKOEPGGEHP.gameObject.SetActive(true);
			if ((IENCFHPINDI == IAOAHCIDOCE.None || FLLODMAOGLE == null) && BHJLNOCCLDO() && !isEmpty && PPAGHBKNOKL.alpha1 == 876f)
			{
				RemoveCard();
			}
			if (IENCFHPINDI != IAOAHCIDOCE.None && FLLODMAOGLE != null && FLLODMAOGLE.BHJLNOCCLDO() && !PFFMAPAAICL().isBuddyCard && !FLLODMAOGLE.isBuddyContainer && FLLODMAOGLE != this)
			{
				card = FLLODMAOGLE.ChangeCards(AFBKNMKPIKO());
				GHIHDBDONIH();
			}
		}
	}

	public void HNPCBFNILBD()
	{
		card = null;
	}

	public void LNPDKPAPMIH(bool LCPBNBLGFIA)
	{
		BEFOAPBCNKP(LCPBNBLGFIA);
	}

	public void LOLIIPICMPK()
	{
	}

	public void MBPMGBOOCLM(int IDLMJLCFMJG)
	{
		AFBBPCBCOLC = IDLMJLCFMJG;
		string currentLanguage = Localization.instance.currentLanguage;
		CNDKEHAAOFF.text = Localization.Localize((!DOHHLGEHBFP()) ? "-[0-9]*$" : "CSV saved");
		if (!MNMACEMIOCP() && currentLanguage == "N")
		{
			CNDKEHAAOFF.transform.localScale = new Vector3(1986f, 1791f, 1599f);
		}
		CNDKEHAAOFF.color = ((!MNMACEMIOCP()) ? Color.white : Colours.pink);
		OGMIHCBHKJL.color = CNDKEHAAOFF.color;
		EDAHNEHMNDN();
		card = null;
		UIPanel uIPanel = NGUITools.FindInParents<UIPanel>(base.gameObject);
		Vector2 vector = new Vector2(Screen.width, Screen.height);
		if (uIPanel.root != null)
		{
			vector *= uIPanel.root.GetPixelSizeAdjustment(Screen.height, Screen.width);
		}
		PDIOAEBJBFH = new Vector3(vector.x / (float)Screen.width, vector.y / (float)Screen.height, 1630f);
		AKKOEPGGEHP.gameObject.SetActive(false);
	}

	public bool InsertCardRecord(CardRecord PJOFHIKENOI)
	{
		if (AJHOOICCPDO())
		{
			return false;
		}
		bool flag = PJOFHIKENOI.card.isBuddyCard && !isBuddyContainer;
		bool flag2 = !PJOFHIKENOI.card.isBuddyCard && isBuddyContainer;
		if (!DebugSettings.debugEnabled && (flag2 || flag))
		{
			return false;
		}
		card = PJOFHIKENOI.card;
		BEFOAPBCNKP(false);
		card.SetUpSmallCard(BBJGODFHBCI, DPMLMAOJPNL, IBKLPHAIOOG, FFEHGPICCMK, PJEPGKLGMLO);
		card.SetUpSmallCard(GDCBNMEGJNA, AMPHFKILGKE, JALFJLGBBFH, LBJEGIPAJMF, BIHGMGFKPLK);
		NormalLook();
		SoundsManager.Instance.PlaySound(SoundsManager.KJGDNLHKPOG.CardEquiped);
		EJCJIIDJBAE(PJOFHIKENOI.dragCardTransform.position);
		AKKOEPGGEHP.transform.position = PJOFHIKENOI.dragCardTransform.position;
		if (CCLMJGPACAF != null)
		{
			CCLMJGPACAF();
		}
		return true;
	}

	public void ALEJMOPBGFN()
	{
		HJGMIDONKBE.SetActive(true);
		CNDKEHAAOFF.gameObject.SetActive(false);
		OGMIHCBHKJL.color = ((!isBuddyContainer) ? Color.white : Colours.pink);
		PPAGHBKNOKL.gameObject.SetActive(false);
		NIMIJBOGLAB.SetActive(false);
		CKMPDDMFJGN.SetActive(true);
		AMEPPFDCLMA(false);
		OBOGCALIAPJ = true;
	}

	private void NOAGGPGKMGK()
	{
		if ((GuiScreenSingle<CardSelectionScreen>.instance.AFOFDNJOJHG() || GuiScreenSingle<CardMenuScreen>.instance.ONOFJIENPPD.GLMNJEEPFNI()) && card != null)
		{
			HJGMIDONKBE.SetActive(true);
			PPAGHBKNOKL.gameObject.SetActive(false);
			TweenAlpha.Begin(PPAGHBKNOKL.gameObject, 1263f, 887f);
		}
		AKKOEPGGEHP.gameObject.SetActive(true);
	}

	[SpecialName]
	public bool NOFKKODINLK()
	{
		return OFDBKKPCNCJ;
	}

	private void DFNPLCJBGOE(Vector3 PCAHBAHIHAH)
	{
		if (!GuiScreenSingle<CardSelectionScreen>.instance.MHAIBHBGBOO() && GuiScreenSingle<CardMenuScreen>.instance.ONOFJIENPPD.GLMNJEEPFNI())
		{
			AKKOEPGGEHP.transform.localPosition = new Vector3(1220f, 1578f, AKKOEPGGEHP.transform.localPosition.z);
			AKKOEPGGEHP.gameObject.SetActive(false);
			TweenAlpha.Begin(AKKOEPGGEHP.gameObject, 190f, 1493f);
			TweenPosition.Begin(AKKOEPGGEHP.gameObject, 1726f, PCAHBAHIHAH, AKKOEPGGEHP.transform.position).onFinished = BAEOKDBDIMC;
		}
	}

	[SpecialName]
	public Card BDLPBGBOPPC()
	{
		return GHINGDGFNJC;
	}

	private void HOEJFMNMMLK()
	{
		if (!GuiScreenSingle<CardSelectionScreen>.instance.MHAIBHBGBOO() && GuiScreenSingle<CardMenuScreen>.instance.ONOFJIENPPD.isActive && card != null)
		{
			HJGMIDONKBE.SetActive(false);
			PPAGHBKNOKL.gameObject.SetActive(false);
			TweenAlpha.Begin(PPAGHBKNOKL.gameObject, 1595f, 1419f);
		}
		AKKOEPGGEHP.gameObject.SetActive(false);
	}

	[SpecialName]
	private void AKPFIKEPELC(Card IDEBKDPMPGM)
	{
		if (IDEBKDPMPGM == null && GHINGDGFNJC != null)
		{
			GHINGDGFNJC.HideInMenu();
		}
		GHINGDGFNJC = IDEBKDPMPGM;
		if (GHINGDGFNJC != null)
		{
			GHINGDGFNJC.ShowInMenu();
		}
	}

	[SpecialName]
	public void AOENBDMJEGO(bool IDEBKDPMPGM)
	{
		OFDBKKPCNCJ = IDEBKDPMPGM;
	}

	public Card LJDDDHBHBLB(Card APHKBBOHPBC)
	{
		Card result = BDLPBGBOPPC();
		card = APHKBBOHPBC;
		SoundsManager.Instance.PlayButtonClickedSound();
		BIPHKOJJKOC();
		return result;
	}

	public void AHJKLKEILGM()
	{
		if (PFFMAPAAICL() != null)
		{
			AGAEIEGDPBI();
		}
		HJGMIDONKBE.SetActive(false);
		PPAGHBKNOKL.gameObject.SetActive(false);
		NIMIJBOGLAB.SetActive(false);
		CKMPDDMFJGN.SetActive(false);
		AMEPPFDCLMA(true);
		OBOGCALIAPJ = true;
	}

	private void IAHOOBEPAPP()
	{
		if ((GuiScreenSingle<CardSelectionScreen>.instance.isFullyShowed || GuiScreenSingle<CardMenuScreen>.instance.ONOFJIENPPD.isActive) && card != null)
		{
			HJGMIDONKBE.SetActive(false);
			PPAGHBKNOKL.gameObject.SetActive(true);
			TweenAlpha.Begin(PPAGHBKNOKL.gameObject, 0f, 1f);
		}
		AKKOEPGGEHP.gameObject.SetActive(false);
	}

	public void CraftingLook()
	{
		HJGMIDONKBE.SetActive(true);
		CNDKEHAAOFF.gameObject.SetActive(false);
		PPAGHBKNOKL.gameObject.SetActive(true);
		TweenAlpha component = PPAGHBKNOKL.GetComponent<TweenAlpha>();
		if (component != null)
		{
			component.enabled = false;
		}
		PPAGHBKNOKL.alpha1 = 0.8f;
	}

	protected void MJBACOLLOHD()
	{
		if (!PJEPGKLGMLO.gameObject.activeSelf && AFBKNMKPIKO() != null && card.iconTexture != null)
		{
			DPMLMAOJPNL.gameObject.SetActive(false);
			PJEPGKLGMLO.gameObject.SetActive(true);
			PJEPGKLGMLO.mainTexture = PFFMAPAAICL().iconTexture;
			AMPHFKILGKE.gameObject.SetActive(true);
			BIHGMGFKPLK.gameObject.SetActive(true);
			BIHGMGFKPLK.mainTexture = PFFMAPAAICL().iconTexture;
		}
	}

	private void BMDKKKEKMNE(Vector3 PCAHBAHIHAH)
	{
		if (!GuiScreenSingle<CardSelectionScreen>.instance.BKIGLABDGCP() && GuiScreenSingle<CardMenuScreen>.instance.ONOFJIENPPD.isActive)
		{
			AKKOEPGGEHP.transform.localPosition = new Vector3(1250f, 639f, AKKOEPGGEHP.transform.localPosition.z);
			AKKOEPGGEHP.gameObject.SetActive(false);
			TweenAlpha.Begin(AKKOEPGGEHP.gameObject, 219f, 1182f);
			TweenPosition.Begin(AKKOEPGGEHP.gameObject, 1432f, PCAHBAHIHAH, AKKOEPGGEHP.transform.position, false).onFinished = BAEOKDBDIMC;
		}
	}

	public bool InsertCard(Card DFFBEFJNDLG, bool FGHNCECHPPO = true)
	{
		if (AJHOOICCPDO())
		{
			return false;
		}
		card = DFFBEFJNDLG;
		HJGMIDONKBE.SetActive(false);
		PPAGHBKNOKL.gameObject.SetActive(true);
		TweenAlpha.Begin(PPAGHBKNOKL.gameObject, 0f, 1f);
		BEFOAPBCNKP(false);
		card.SetUpSmallCard(BBJGODFHBCI, DPMLMAOJPNL, IBKLPHAIOOG, FFEHGPICCMK, PJEPGKLGMLO);
		card.SetUpSmallCard(GDCBNMEGJNA, AMPHFKILGKE, JALFJLGBBFH, LBJEGIPAJMF, BIHGMGFKPLK);
		NormalLook();
		if (FGHNCECHPPO)
		{
			SoundsManager.Instance.PlaySound(SoundsManager.KJGDNLHKPOG.CardEquiped);
		}
		if (CCLMJGPACAF != null)
		{
			CCLMJGPACAF();
		}
		return true;
	}

	private void KEBBKGBHFAF(bool DGOOLMFNBFB)
	{
		if (OBOGCALIAPJ || !BMHGFLMHCJC() || (GuiScreenSingle<CardMenuScreen>.instance.ONOFJIENPPD.GLMNJEEPFNI() && !GuiScreenSingle<CardMenuScreen>.instance.ONOFJIENPPD.canChangeContent))
		{
			return;
		}
		if (base.enabled && !ICMDJEOIKPC() && !FEBNGMKAGJD())
		{
			Highlight(true);
			if (DGOOLMFNBFB)
			{
				SoundsManager.Instance.PlaySound((SoundsManager.KJGDNLHKPOG)(-41), 1431f);
				FLLODMAOGLE = null;
				UIDraggablePanel.panelDisabled = true;
				AKKOEPGGEHP.transform.position = UICamera.currentCamera.ScreenToWorldPoint(new Vector3(UICamera.currentTouch.pos.x, UICamera.currentTouch.pos.y));
				AKKOEPGGEHP.transform.localPosition = new Vector3(AKKOEPGGEHP.transform.localPosition.x, AKKOEPGGEHP.transform.localPosition.y, 1944f);
				BMMKKGHPAIP = false;
				UICamera.stickyPress = true;
			}
			else if (BMMKKGHPAIP)
			{
				UIDraggablePanel.panelDisabled = false;
				AKKOEPGGEHP.gameObject.SetActive(false);
				BMMKKGHPAIP = false;
				UICamera.stickyPress = true;
			}
			if (!DGOOLMFNBFB)
			{
				IFHKKAPJAAD();
			}
			IENCFHPINDI = IAOAHCIDOCE.Drag;
		}
		if (!DGOOLMFNBFB && (CKMPDDMFJGN.activeSelf || NIMIJBOGLAB.activeSelf) && TutorialManagerPlayWarcards.instance.isTutorialRunning)
		{
			DialogManager.instance.HideAllDialogs();
		}
		if (!DGOOLMFNBFB && CKMPDDMFJGN.activeSelf && !GuiElementSingle<BuyVIPDialog>.instance.isShowed)
		{
			GuiElementSingle<BuyVIPDialog>.instance.BFLBFOKFDIM();
		}
		if (!DGOOLMFNBFB && NIMIJBOGLAB.activeSelf && !GuiElementSingle<CardsAndPacksDialog>.instance.NPFFMLLLDAF())
		{
			GuiElementSingle<PackContentDialog>.instance.MCCJIJKCOOH(Singleton<GameVariables>.instance.BJDKLOCBNOJ(), true);
		}
		if (!DGOOLMFNBFB && DOHHLGEHBFP())
		{
			if (!ICMDJEOIKPC())
			{
				LOGAHNENKPE();
			}
			else if (GuiScreenSingle<CardSelectionScreen>.instance.NPFFMLLLDAF())
			{
				GuiScreenSingle<CardSelectionScreen>.instance.GIJPCJGGLKD();
			}
		}
	}

	public void LNAFOABKIML(bool LCPBNBLGFIA)
	{
		AMEPPFDCLMA(LCPBNBLGFIA);
	}

	private bool EKLOJBAEFKN()
	{
		if (KJOIBPACABN() && !Singleton<VipManager>.instance.NOIHCEPINJJ())
		{
			if (PFFMAPAAICL() != null)
			{
				IDDJIOHOAFE();
			}
			SetVip();
			return false;
		}
		return false;
	}

	private void PCPALELGLHI(Vector3 PCAHBAHIHAH)
	{
		if (!GuiScreenSingle<CardSelectionScreen>.instance.AFOFDNJOJHG() && GuiScreenSingle<CardMenuScreen>.instance.ONOFJIENPPD.isActive)
		{
			AKKOEPGGEHP.transform.localPosition = new Vector3(776f, 398f, AKKOEPGGEHP.transform.localPosition.z);
			AKKOEPGGEHP.gameObject.SetActive(false);
			TweenAlpha.Begin(AKKOEPGGEHP.gameObject, 568f, 669f);
			TweenPosition.Begin(AKKOEPGGEHP.gameObject, 1003f, PCAHBAHIHAH, AKKOEPGGEHP.transform.position, false).onFinished = IELBFJKNMFM;
		}
	}

	public bool ENPJPDEBNNL(CardRecord PJOFHIKENOI)
	{
		if (EKLOJBAEFKN())
		{
			return false;
		}
		bool flag = !PJOFHIKENOI.card.isBuddyCard || !LAEEFLAMJMN();
		bool flag2 = !PJOFHIKENOI.card.isBuddyCard && LAEEFLAMJMN();
		if (!DebugSettings.debugEnabled && (flag2 || flag))
		{
			return false;
		}
		PFJAGKLKPHH(PJOFHIKENOI.card);
		BEFOAPBCNKP(false);
		PFFMAPAAICL().SetUpSmallCard(BBJGODFHBCI, DPMLMAOJPNL, IBKLPHAIOOG, FFEHGPICCMK, PJEPGKLGMLO);
		card.SetUpSmallCard(GDCBNMEGJNA, AMPHFKILGKE, JALFJLGBBFH, LBJEGIPAJMF, BIHGMGFKPLK);
		EBIMBGCCKBL();
		SoundsManager.Instance.PlaySound((SoundsManager.KJGDNLHKPOG)92, 1670f);
		PCPALELGLHI(PJOFHIKENOI.dragCardTransform.position);
		AKKOEPGGEHP.transform.position = PJOFHIKENOI.dragCardTransform.position;
		if (CCLMJGPACAF != null)
		{
			CCLMJGPACAF();
		}
		return false;
	}

	public void DoAfterHide()
	{
		card = null;
	}

	[SpecialName]
	public bool DOHHLGEHBFP()
	{
		return AFBBPCBCOLC == 2;
	}

	[SpecialName]
	private void NNICJELPDNK(Card IDEBKDPMPGM)
	{
		if (IDEBKDPMPGM == null && GHINGDGFNJC != null)
		{
			GHINGDGFNJC.HideInMenu();
		}
		GHINGDGFNJC = IDEBKDPMPGM;
		if (GHINGDGFNJC != null)
		{
			GHINGDGFNJC.ShowInMenu();
		}
	}

	public void IOLIFHONNOP(bool LCPBNBLGFIA)
	{
		BEFOAPBCNKP(LCPBNBLGFIA);
	}
}
