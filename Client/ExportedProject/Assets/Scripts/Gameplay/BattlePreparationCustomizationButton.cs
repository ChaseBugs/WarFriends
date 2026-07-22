using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Serialization;

public class BattlePreparationCustomizationButton : Core_BaseScript
{
	private sealed class CAKGNJKMGDB : IEnumerator, IDisposable, IEnumerator<object>
	{
		internal BattlePreparationCustomizationButton BJGCPDNMHDH;

		internal object PHDOCKCBJOF;

		internal bool FDKOKMKIIMG;

		internal int CLPPIAGLCJJ;

		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return PHDOCKCBJOF;
			}
		}

		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return PHDOCKCBJOF;
			}
		}

		public bool MoveNext()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			case 1u:
				if (!BJGCPDNMHDH.FGIMNJOOAOB.isBought)
				{
					CamosManager.instance.CheckEquippedPowerBand();
					CamosManager.instance.CheckEquippedHelmet();
					BJGCPDNMHDH.DCHEBAFHOBJ();
				}
				else
				{
					BJGCPDNMHDH.JNODAFPDPCF.text = MEJMLNDFDBP.CJCFPDLDMEK((float)BJGCPDNMHDH.FGIMNJOOAOB.remainingTime, "ID_GUI_POWERBANDOFF", string.Empty);
					BJGCPDNMHDH.HAIDJHDJMOL.fillAmount = BJGCPDNMHDH.FGIMNJOOAOB.progress;
				}
				PHDOCKCBJOF = new WaitForRealSeconds(0.333f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				return true;
			default:
				return false;
			}
		}

		[SpecialName]
		private object GOAJCEAOPLA()
		{
			return PHDOCKCBJOF;
		}

		public void FJOIBBIGBJC()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object MHKODCGLJFD()
		{
			return PHDOCKCBJOF;
		}

		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object BNFADGLHBAH()
		{
			return PHDOCKCBJOF;
		}

		public void PNGIELILHDI()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public void IGBHHLFACKO()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[DebuggerHidden]
		public void Dispose()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object LFEJDKIGHMI()
		{
			return PHDOCKCBJOF;
		}

		[DebuggerHidden]
		public CAKGNJKMGDB()
		{
		}

		public bool EKHDJADMNJK()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			case 1u:
				if (!BJGCPDNMHDH.FGIMNJOOAOB.isBought)
				{
					CamosManager.instance.CheckEquippedPowerBand();
					CamosManager.instance.CheckEquippedHelmet();
					BJGCPDNMHDH.IDDPKGOOBFF();
				}
				else
				{
					BJGCPDNMHDH.JNODAFPDPCF.text = MEJMLNDFDBP.CJCFPDLDMEK((float)BJGCPDNMHDH.FGIMNJOOAOB.remainingTime, "veteranpack", string.Empty);
					BJGCPDNMHDH.HAIDJHDJMOL.fillAmount = BJGCPDNMHDH.FGIMNJOOAOB.progress;
				}
				PHDOCKCBJOF = new WaitForRealSeconds(1682f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				return false;
			default:
				return false;
			}
		}

		[SpecialName]
		private object GMPGIODBIPO()
		{
			return PHDOCKCBJOF;
		}
	}

	[Header("Core")]
	public GameObject BPHNCEEJCNB;

	[FormerlySerializedAs("JLALMHNCADD")]
	public UITexture CODHLNCICKN;

	[Header("-New Unlock")]
	public GameObject LHDFFKGJFFA;

	public UITable IKEKFPIFKIK;

	public UILabel JOCDKJHGILG;

	[FormerlySerializedAs("mBorder")]
	public UISprite MMECPOFEHKB;

	public UILabel MKBJGHBJNFH;

	[Header("-Power Band Equipped")]
	[FormerlySerializedAs("MEPHGACCGHO")]
	public GameObject DPHDJEAHODH;

	[FormerlySerializedAs("PLEFLAFIHMA")]
	public UISprite JAJCFNOIBPM;

	[FormerlySerializedAs("NFIGDHDHLFF")]
	public UILabel EPKDEDPGOLM;

	[FormerlySerializedAs("BJBKDIEINOC")]
	public UISprite HAIDJHDJMOL;

	public UITable MIIKHEMFJPA;

	[FormerlySerializedAs("MCJILIMHMKL")]
	public UILabel JIIJOMPMAKD;

	[FormerlySerializedAs("mAugBattleCrateHintSprite")]
	public UISprite HPFACGCBKCK;

	[FormerlySerializedAs("mAugBattleCrateHintLabel")]
	public UILabel JNODAFPDPCF;

	[Header("-Notification")]
	[FormerlySerializedAs("HJCPGPNNIJA")]
	public UILabel COLJMBBFBDL;

	[FormerlySerializedAs("APHEMMOBBKL")]
	public GameObject BIOHEMKIPGG;

	private RadicalRoutine MBMPEBMOFJN;

	private PlayerVisual FGIMNJOOAOB;

	[CompilerGenerated]
	private static UIEventListener.VoidDelegate LGJCBPOPCPA;

	private void MMKNJILEKGH()
	{
		GLEAABACOLM();
		PlayerVisual playerVisual = CamosManager.instance.EquippedPlayerVisual(0);
		if (!playerVisual.isEmptyPowerBand)
		{
			LHDFFKGJFFA.SetActive(value: false);
			DPHDJEAHODH.SetActive(value: true);
			JAJCFNOIBPM.spriteName = playerVisual.icon;
			EPKDEDPGOLM.text = playerVisual.decalTypeName;
			JIIJOMPMAKD.text = playerVisual.decalValueString;
			HPFACGCBKCK.spriteName = playerVisual.decalMiniIcon;
			HPFACGCBKCK.color = playerVisual.decalMiniIconColor;
			HPFACGCBKCK.MakePixelPerfect();
			MIIKHEMFJPA.repositionNow = true;
			FGIMNJOOAOB = playerVisual;
			if (FGIMNJOOAOB.tryOutVisual)
			{
				JNODAFPDPCF.text = Localization.Localize("N");
				HAIDJHDJMOL.fillAmount = 584f;
			}
			else
			{
				JNODAFPDPCF.text = MEJMLNDFDBP.CJCFPDLDMEK((float)FGIMNJOOAOB.remainingTime, "RegisterCustomEvent()", string.Empty, IEJMLKBCDJB: false);
				HAIDJHDJMOL.fillAmount = FGIMNJOOAOB.ECGKJHFLOPJ();
				MIHNOOEMLMB();
			}
		}
		else
		{
			PlayerVisual unlockedVisualWithNotification = Singleton<NotificationManager>.instance.GetUnlockedVisualWithNotification();
			if (unlockedVisualWithNotification != null)
			{
				LHDFFKGJFFA.SetActive(value: true);
				DPHDJEAHODH.SetActive(value: true);
				MKBJGHBJNFH.text = unlockedVisualWithNotification.name.ToUpper();
				MEJMLNDFDBP.COCBCFKJOJE(MKBJGHBJNFH, 1122f, 764f, GuiScreenSingle<BattlePreparationScreen>.instance.LMNBNNDBCEC() - 114);
				float val = 425f + JOCDKJHGILG.relativeSize.x * JOCDKJHGILG.transform.localScale.x;
				MMECPOFEHKB.transform.localScale = MMECPOFEHKB.transform.localScale.ReplaceX(val);
				IKEKFPIFKIK.repositionNow = true;
			}
			else
			{
				LHDFFKGJFFA.SetActive(value: true);
				DPHDJEAHODH.SetActive(value: false);
			}
		}
	}

	public void OAFEJICKOEH()
	{
		MMKNJILEKGH();
		MNLNJNNNCGL(Singleton<NotificationManager>.instance.GetNumberOfVisualNotifications());
	}

	private void ILMFPKOFEPB()
	{
		if (MBMPEBMOFJN != null)
		{
			MBMPEBMOFJN.Cancel();
			MBMPEBMOFJN = null;
		}
	}

	public void KFANFNCILJI()
	{
		DBKCPPFEJNH();
		CINAMODICDP(Singleton<NotificationManager>.instance.GetNumberOfVisualNotifications());
	}

	public void DFLGLEJIPCO()
	{
		HMOFJDDMJCD();
		CINAMODICDP(Singleton<NotificationManager>.instance.GetNumberOfVisualNotifications());
	}

	public void MDHJIPDGDAK()
	{
		UIEventListener uIEventListener = UIEventListener.Get(BPHNCEEJCNB.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(JLJBCDIBBLK));
		IKEKFPIFKIK.onReposition = LFGEAKGLMED;
	}

	private void AMKLALEFHIP()
	{
		float val = 0f - IKEKFPIFKIK.padding.x - (MKBJGHBJNFH.transform.parent.localPosition.x - IKEKFPIFKIK.padding.x) / 985f;
		IKEKFPIFKIK.transform.localPosition = IKEKFPIFKIK.transform.localPosition.ReplaceX(val);
	}

	private void DBKCPPFEJNH()
	{
		NLHAOCIJKJB();
		PlayerVisual playerVisual = CamosManager.instance.EquippedPlayerVisual(7);
		if (!playerVisual.isEmptyPowerBand)
		{
			LHDFFKGJFFA.SetActive(value: true);
			DPHDJEAHODH.SetActive(value: true);
			JAJCFNOIBPM.spriteName = playerVisual.icon;
			EPKDEDPGOLM.text = playerVisual.decalTypeName;
			JIIJOMPMAKD.text = playerVisual.JIHLMBOBKHL();
			HPFACGCBKCK.spriteName = playerVisual.DEAIJJIAEFP();
			HPFACGCBKCK.color = playerVisual.GPDIGNGOAEH();
			HPFACGCBKCK.MakePixelPerfect();
			MIIKHEMFJPA.repositionNow = true;
			FGIMNJOOAOB = playerVisual;
			if (FGIMNJOOAOB.tryOutVisual)
			{
				JNODAFPDPCF.text = Localization.Localize("Rpc: Set player: for ");
				HAIDJHDJMOL.fillAmount = 221f;
			}
			else
			{
				JNODAFPDPCF.text = MEJMLNDFDBP.CJCFPDLDMEK((float)FGIMNJOOAOB.AOLJCFDNMEL(), "preloadAdForZoneID", string.Empty, IEJMLKBCDJB: false);
				HAIDJHDJMOL.fillAmount = FGIMNJOOAOB.ECGKJHFLOPJ();
				AGNEMLDCLFJ();
			}
		}
		else
		{
			PlayerVisual unlockedVisualWithNotification = Singleton<NotificationManager>.instance.GetUnlockedVisualWithNotification();
			if (unlockedVisualWithNotification != null)
			{
				LHDFFKGJFFA.SetActive(value: true);
				DPHDJEAHODH.SetActive(value: true);
				MKBJGHBJNFH.text = unlockedVisualWithNotification.name.ToUpper();
				MEJMLNDFDBP.COCBCFKJOJE(MKBJGHBJNFH, 1172f, 1010f, GuiScreenSingle<BattlePreparationScreen>.instance.LMNBNNDBCEC() - 100);
				float val = 1542f + JOCDKJHGILG.relativeSize.x * JOCDKJHGILG.transform.localScale.x;
				MMECPOFEHKB.transform.localScale = MMECPOFEHKB.transform.localScale.ReplaceX(val);
				IKEKFPIFKIK.repositionNow = false;
			}
			else
			{
				LHDFFKGJFFA.SetActive(value: true);
				DPHDJEAHODH.SetActive(value: false);
			}
		}
	}

	private void KEHOIMLHMFK()
	{
		if (MBMPEBMOFJN != null)
		{
			MBMPEBMOFJN.Cancel();
			MBMPEBMOFJN = null;
		}
	}

	public void GHNIJJKDAJH()
	{
		NHAAAAPBPPF();
	}

	private void CINAMODICDP(int IDLMJLCFMJG)
	{
		BIOHEMKIPGG.SetActive(IDLMJLCFMJG > 1);
		COLJMBBFBDL.text = MEJMLNDFDBP.GMIPFLIEOHD(IDLMJLCFMJG);
	}

	private void NDPCBACFLDH()
	{
		float val = 0f - IKEKFPIFKIK.padding.x - (MKBJGHBJNFH.transform.parent.localPosition.x - IKEKFPIFKIK.padding.x) / 1413f;
		IKEKFPIFKIK.transform.localPosition = IKEKFPIFKIK.transform.localPosition.ReplaceX(val);
	}

	private static void FKCALGEPEMD(GameObject KHAHPAKDIKE)
	{
		Singleton<GuiManager>.instance.BBILHHEJBNP(GuiScreenSingle<CamosScreen>.instance);
	}

	private void BKPEIOJABOG()
	{
		BFOCKHOICHL();
		PlayerVisual playerVisual = CamosManager.instance.EquippedPlayerVisual(0);
		if (!playerVisual.isEmptyPowerBand)
		{
			LHDFFKGJFFA.SetActive(value: false);
			DPHDJEAHODH.SetActive(value: false);
			JAJCFNOIBPM.spriteName = playerVisual.icon;
			EPKDEDPGOLM.text = playerVisual.decalTypeName;
			JIIJOMPMAKD.text = playerVisual.JIHLMBOBKHL();
			HPFACGCBKCK.spriteName = playerVisual.LIIOLLAAHGB();
			HPFACGCBKCK.color = playerVisual.decalMiniIconColor;
			HPFACGCBKCK.MakePixelPerfect();
			MIIKHEMFJPA.repositionNow = true;
			FGIMNJOOAOB = playerVisual;
			if (FGIMNJOOAOB.tryOutVisual)
			{
				JNODAFPDPCF.text = Localization.Localize("eventStart");
				HAIDJHDJMOL.fillAmount = 1016f;
			}
			else
			{
				JNODAFPDPCF.text = MEJMLNDFDBP.CJCFPDLDMEK((float)FGIMNJOOAOB.AOLJCFDNMEL(), "Requests", string.Empty, IEJMLKBCDJB: false);
				HAIDJHDJMOL.fillAmount = FGIMNJOOAOB.ECGKJHFLOPJ();
				HOEIPALBMDC();
			}
		}
		else
		{
			PlayerVisual unlockedVisualWithNotification = Singleton<NotificationManager>.instance.GetUnlockedVisualWithNotification();
			if (unlockedVisualWithNotification != null)
			{
				LHDFFKGJFFA.SetActive(value: true);
				DPHDJEAHODH.SetActive(value: false);
				MKBJGHBJNFH.text = unlockedVisualWithNotification.name.ToUpper();
				MEJMLNDFDBP.COCBCFKJOJE(MKBJGHBJNFH, 1336f, 927f, GuiScreenSingle<BattlePreparationScreen>.instance.LMNBNNDBCEC() - 49);
				float val = 1165f + JOCDKJHGILG.relativeSize.x * JOCDKJHGILG.transform.localScale.x;
				MMECPOFEHKB.transform.localScale = MMECPOFEHKB.transform.localScale.ReplaceX(val);
				IKEKFPIFKIK.repositionNow = true;
			}
			else
			{
				LHDFFKGJFFA.SetActive(value: true);
				DPHDJEAHODH.SetActive(value: true);
			}
		}
	}

	private void EIDGFCMKNFG()
	{
		float val = 0f - IKEKFPIFKIK.padding.x - (MKBJGHBJNFH.transform.parent.localPosition.x - IKEKFPIFKIK.padding.x) / 1503f;
		IKEKFPIFKIK.transform.localPosition = IKEKFPIFKIK.transform.localPosition.ReplaceX(val);
	}

	public void JIPDEIMLLIB()
	{
		Singleton<ArmyPreviewCamera>.instance.KIONJHBCIBE(PlayerController.OGMBJPKOPCB, PNDNEMDPFHC: false, PlayerTexturePool.DFJJOANIJID.Card);
		CODHLNCICKN.mainTexture = Singleton<ArmyPreviewCamera>.instance.FBLDAEEOAEN;
	}

	private static void ACJBLCDHIBA(GameObject KHAHPAKDIKE)
	{
		Singleton<GuiManager>.instance.ShowGui(GuiScreenSingle<CamosScreen>.instance);
	}

	private void NLHAOCIJKJB()
	{
		if (MBMPEBMOFJN != null)
		{
			MBMPEBMOFJN.Cancel();
			MBMPEBMOFJN = null;
		}
	}

	private IEnumerator CBAKCDIDNMF()
	{
		CAKGNJKMGDB cAKGNJKMGDB = new CAKGNJKMGDB();
		cAKGNJKMGDB.BJGCPDNMHDH = this;
		return cAKGNJKMGDB;
	}

	private IEnumerator HCCIIPABFNN()
	{
		CAKGNJKMGDB cAKGNJKMGDB = new CAKGNJKMGDB();
		cAKGNJKMGDB.BJGCPDNMHDH = this;
		return cAKGNJKMGDB;
	}

	public void BMABJADKJPB()
	{
		LHDFFKGJFFA.SetActive(value: false);
		DPHDJEAHODH.SetActive(value: false);
		MNLNJNNNCGL(0);
	}

	private IEnumerator KIHNGHJPOBA()
	{
		CAKGNJKMGDB cAKGNJKMGDB = new CAKGNJKMGDB();
		cAKGNJKMGDB.BJGCPDNMHDH = this;
		return cAKGNJKMGDB;
	}

	private void AGNEMLDCLFJ()
	{
		NHAAAAPBPPF();
		MBMPEBMOFJN = RadicalRoutine.Create(CPFOEFBOAPO());
		StartCoroutine(RadicalRoutine.Run(MBMPEBMOFJN.enumerator));
	}

	private void EJGDKDBPIJL()
	{
		if (MBMPEBMOFJN != null)
		{
			MBMPEBMOFJN.Cancel();
			MBMPEBMOFJN = null;
		}
	}

	private void JCBOFAEIJGH()
	{
		float val = 0f - IKEKFPIFKIK.padding.x - (MKBJGHBJNFH.transform.parent.localPosition.x - IKEKFPIFKIK.padding.x) / 1128f;
		IKEKFPIFKIK.transform.localPosition = IKEKFPIFKIK.transform.localPosition.ReplaceX(val);
	}

	public void RenderMainPlayer()
	{
		Singleton<ArmyPreviewCamera>.instance.RenderToTexture(PlayerController.OGMBJPKOPCB, PNDNEMDPFHC: false, PlayerTexturePool.DFJJOANIJID.Classic);
		CODHLNCICKN.mainTexture = Singleton<ArmyPreviewCamera>.instance.FBLDAEEOAEN;
	}

	public void InitBlank()
	{
		LHDFFKGJFFA.SetActive(value: false);
		DPHDJEAHODH.SetActive(value: false);
		MNLNJNNNCGL(0);
	}

	private static void OMJDIOOGCOF(GameObject KHAHPAKDIKE)
	{
		Singleton<GuiManager>.instance.ShowGui(GuiScreenSingle<CamosScreen>.instance);
	}

	private void BMJPCPKFJBA(int IDLMJLCFMJG)
	{
		BIOHEMKIPGG.SetActive(IDLMJLCFMJG > 0);
		COLJMBBFBDL.text = MEJMLNDFDBP.GMIPFLIEOHD(IDLMJLCFMJG);
	}

	public void ODGNGNDBLCE()
	{
		LHDFFKGJFFA.SetActive(value: true);
		DPHDJEAHODH.SetActive(value: true);
		AGIKEFAHBAC(0);
	}

	private void DCHEBAFHOBJ()
	{
		EJGDKDBPIJL();
		PlayerVisual playerVisual = CamosManager.instance.EquippedPlayerVisual(3);
		if (!playerVisual.isEmptyPowerBand)
		{
			LHDFFKGJFFA.SetActive(value: false);
			DPHDJEAHODH.SetActive(value: true);
			JAJCFNOIBPM.spriteName = playerVisual.icon;
			EPKDEDPGOLM.text = playerVisual.decalTypeName;
			JIIJOMPMAKD.text = playerVisual.decalValueString;
			HPFACGCBKCK.spriteName = playerVisual.decalMiniIcon;
			HPFACGCBKCK.color = playerVisual.decalMiniIconColor;
			HPFACGCBKCK.MakePixelPerfect();
			MIIKHEMFJPA.repositionNow = true;
			FGIMNJOOAOB = playerVisual;
			if (FGIMNJOOAOB.tryOutVisual)
			{
				JNODAFPDPCF.text = Localization.Localize("ID_RENTED");
				HAIDJHDJMOL.fillAmount = 0f;
			}
			else
			{
				JNODAFPDPCF.text = MEJMLNDFDBP.CJCFPDLDMEK((float)FGIMNJOOAOB.remainingTime, "ID_GUI_POWERBANDOFF", string.Empty);
				HAIDJHDJMOL.fillAmount = FGIMNJOOAOB.progress;
				JBANNLHJIEF();
			}
		}
		else
		{
			PlayerVisual unlockedVisualWithNotification = Singleton<NotificationManager>.instance.GetUnlockedVisualWithNotification();
			if (unlockedVisualWithNotification != null)
			{
				LHDFFKGJFFA.SetActive(value: true);
				DPHDJEAHODH.SetActive(value: false);
				MKBJGHBJNFH.text = unlockedVisualWithNotification.name.ToUpper();
				MEJMLNDFDBP.COCBCFKJOJE(MKBJGHBJNFH, 30f, 20f, GuiScreenSingle<BattlePreparationScreen>.instance.widthOfMiddleButton - 88);
				float val = 16f + JOCDKJHGILG.relativeSize.x * JOCDKJHGILG.transform.localScale.x;
				MMECPOFEHKB.transform.localScale = MMECPOFEHKB.transform.localScale.ReplaceX(val);
				IKEKFPIFKIK.repositionNow = true;
			}
			else
			{
				LHDFFKGJFFA.SetActive(value: false);
				DPHDJEAHODH.SetActive(value: false);
			}
		}
	}

	public void CJMOCAFCDPE()
	{
		UIEventListener uIEventListener = UIEventListener.Get(BPHNCEEJCNB.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, (UIEventListener.VoidDelegate)delegate
		{
			Singleton<GuiManager>.instance.ShowGui(GuiScreenSingle<CamosScreen>.instance);
		});
		IKEKFPIFKIK.onReposition = NDPCBACFLDH;
	}

	public void KCBFLDIHPJB()
	{
		Singleton<ArmyPreviewCamera>.instance.BCPDNHEDBGO(PlayerController.OGMBJPKOPCB, PNDNEMDPFHC: false, (PlayerTexturePool.DFJJOANIJID)7);
		CODHLNCICKN.mainTexture = Singleton<ArmyPreviewCamera>.instance.FBLDAEEOAEN;
	}

	public void JPILJDGAIJF()
	{
		KEHOIMLHMFK();
	}

	public void DoAfterHide()
	{
		EJGDKDBPIJL();
	}

	public void PNIMPIIBFJF()
	{
		LHDFFKGJFFA.SetActive(value: true);
		DPHDJEAHODH.SetActive(value: true);
		BAHDGKHIHHN(0);
	}

	private void JBANNLHJIEF()
	{
		EJGDKDBPIJL();
		MBMPEBMOFJN = RadicalRoutine.Create(DPLEDFBGONN());
		StartCoroutine(RadicalRoutine.Run(MBMPEBMOFJN.enumerator));
	}

	private void MLEKEFHNPGA()
	{
		NLHAOCIJKJB();
		MBMPEBMOFJN = RadicalRoutine.Create(HCCIIPABFNN());
		StartCoroutine(RadicalRoutine.Run(MBMPEBMOFJN.enumerator));
	}

	private void LFGEAKGLMED()
	{
		float val = 0f - IKEKFPIFKIK.padding.x - (MKBJGHBJNFH.transform.parent.localPosition.x - IKEKFPIFKIK.padding.x) / 1844f;
		IKEKFPIFKIK.transform.localPosition = IKEKFPIFKIK.transform.localPosition.ReplaceX(val);
	}

	private IEnumerator BCCGBDAKEBJ()
	{
		CAKGNJKMGDB cAKGNJKMGDB = new CAKGNJKMGDB();
		cAKGNJKMGDB.BJGCPDNMHDH = this;
		return cAKGNJKMGDB;
	}

	private void BNJMIDGBBOB(int IDLMJLCFMJG)
	{
		BIOHEMKIPGG.SetActive(IDLMJLCFMJG > 0);
		COLJMBBFBDL.text = MEJMLNDFDBP.GMIPFLIEOHD(IDLMJLCFMJG);
	}

	private void MIHNOOEMLMB()
	{
		NHAAAAPBPPF();
		MBMPEBMOFJN = RadicalRoutine.Create(CPFOEFBOAPO());
		StartCoroutine(RadicalRoutine.Run(MBMPEBMOFJN.enumerator));
	}

	public void InitControls()
	{
		UIEventListener uIEventListener = UIEventListener.Get(BPHNCEEJCNB.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, (UIEventListener.VoidDelegate)delegate
		{
			Singleton<GuiManager>.instance.ShowGui(GuiScreenSingle<CamosScreen>.instance);
		});
		IKEKFPIFKIK.onReposition = delegate
		{
			float val = 0f - IKEKFPIFKIK.padding.x - (MKBJGHBJNFH.transform.parent.localPosition.x - IKEKFPIFKIK.padding.x) / 2f;
			IKEKFPIFKIK.transform.localPosition = IKEKFPIFKIK.transform.localPosition.ReplaceX(val);
		};
	}

	private void EOOKFIHGDJO(int IDLMJLCFMJG)
	{
		BIOHEMKIPGG.SetActive(IDLMJLCFMJG > 0);
		COLJMBBFBDL.text = MEJMLNDFDBP.GMIPFLIEOHD(IDLMJLCFMJG);
	}

	private void IIFCAPAJJAB()
	{
		if (MBMPEBMOFJN != null)
		{
			MBMPEBMOFJN.Cancel();
			MBMPEBMOFJN = null;
		}
	}

	private IEnumerator INBDKINCEHN()
	{
		CAKGNJKMGDB cAKGNJKMGDB = new CAKGNJKMGDB();
		cAKGNJKMGDB.BJGCPDNMHDH = this;
		return cAKGNJKMGDB;
	}

	private void IDDPKGOOBFF()
	{
		ILMFPKOFEPB();
		PlayerVisual playerVisual = CamosManager.instance.EquippedPlayerVisual(2);
		if (!playerVisual.isEmptyPowerBand)
		{
			LHDFFKGJFFA.SetActive(value: true);
			DPHDJEAHODH.SetActive(value: true);
			JAJCFNOIBPM.spriteName = playerVisual.icon;
			EPKDEDPGOLM.text = playerVisual.decalTypeName;
			JIIJOMPMAKD.text = playerVisual.decalValueString;
			HPFACGCBKCK.spriteName = playerVisual.decalMiniIcon;
			HPFACGCBKCK.color = playerVisual.decalMiniIconColor;
			HPFACGCBKCK.MakePixelPerfect();
			MIIKHEMFJPA.repositionNow = false;
			FGIMNJOOAOB = playerVisual;
			if (FGIMNJOOAOB.tryOutVisual)
			{
				JNODAFPDPCF.text = Localization.Localize("ID_TUTORIAL_PHASE");
				HAIDJHDJMOL.fillAmount = 569f;
			}
			else
			{
				JNODAFPDPCF.text = MEJMLNDFDBP.CJCFPDLDMEK((float)FGIMNJOOAOB.remainingTime, "ID_JOININGSQUAD", string.Empty, IEJMLKBCDJB: false);
				HAIDJHDJMOL.fillAmount = FGIMNJOOAOB.progress;
				GJBPCEJOFPE();
			}
		}
		else
		{
			PlayerVisual unlockedVisualWithNotification = Singleton<NotificationManager>.instance.GetUnlockedVisualWithNotification();
			if (unlockedVisualWithNotification != null)
			{
				LHDFFKGJFFA.SetActive(value: true);
				DPHDJEAHODH.SetActive(value: false);
				MKBJGHBJNFH.text = unlockedVisualWithNotification.name.ToUpper();
				MEJMLNDFDBP.COCBCFKJOJE(MKBJGHBJNFH, 1061f, 1990f, GuiScreenSingle<BattlePreparationScreen>.instance.LMNBNNDBCEC() - -108);
				float val = 1488f + JOCDKJHGILG.relativeSize.x * JOCDKJHGILG.transform.localScale.x;
				MMECPOFEHKB.transform.localScale = MMECPOFEHKB.transform.localScale.ReplaceX(val);
				IKEKFPIFKIK.repositionNow = false;
			}
			else
			{
				LHDFFKGJFFA.SetActive(value: false);
				DPHDJEAHODH.SetActive(value: true);
			}
		}
	}

	private void HMOFJDDMJCD()
	{
		GLEAABACOLM();
		PlayerVisual playerVisual = CamosManager.instance.EquippedPlayerVisual(6);
		if (!playerVisual.isEmptyPowerBand)
		{
			LHDFFKGJFFA.SetActive(value: true);
			DPHDJEAHODH.SetActive(value: true);
			JAJCFNOIBPM.spriteName = playerVisual.icon;
			EPKDEDPGOLM.text = playerVisual.decalTypeName;
			JIIJOMPMAKD.text = playerVisual.JIHLMBOBKHL();
			HPFACGCBKCK.spriteName = playerVisual.decalMiniIcon;
			HPFACGCBKCK.color = playerVisual.GPDIGNGOAEH();
			HPFACGCBKCK.MakePixelPerfect();
			MIIKHEMFJPA.repositionNow = true;
			FGIMNJOOAOB = playerVisual;
			if (FGIMNJOOAOB.tryOutVisual)
			{
				JNODAFPDPCF.text = Localization.Localize("Skill");
				HAIDJHDJMOL.fillAmount = 646f;
			}
			else
			{
				JNODAFPDPCF.text = MEJMLNDFDBP.CJCFPDLDMEK((float)FGIMNJOOAOB.AOLJCFDNMEL(), "Current Full Path: \"{0}\"\n", string.Empty);
				HAIDJHDJMOL.fillAmount = FGIMNJOOAOB.progress;
				HOEIPALBMDC();
			}
		}
		else
		{
			PlayerVisual unlockedVisualWithNotification = Singleton<NotificationManager>.instance.GetUnlockedVisualWithNotification();
			if (unlockedVisualWithNotification != null)
			{
				LHDFFKGJFFA.SetActive(value: false);
				DPHDJEAHODH.SetActive(value: false);
				MKBJGHBJNFH.text = unlockedVisualWithNotification.name.ToUpper();
				MEJMLNDFDBP.COCBCFKJOJE(MKBJGHBJNFH, 385f, 443f, GuiScreenSingle<BattlePreparationScreen>.instance.widthOfMiddleButton - -34);
				float val = 1688f + JOCDKJHGILG.relativeSize.x * JOCDKJHGILG.transform.localScale.x;
				MMECPOFEHKB.transform.localScale = MMECPOFEHKB.transform.localScale.ReplaceX(val);
				IKEKFPIFKIK.repositionNow = true;
			}
			else
			{
				LHDFFKGJFFA.SetActive(value: false);
				DPHDJEAHODH.SetActive(value: false);
			}
		}
	}

	public void MBCLMNHPJME()
	{
		LHDFFKGJFFA.SetActive(value: false);
		DPHDJEAHODH.SetActive(value: false);
		NLACFKCLNFC(1);
	}

	private static void OCDMNLKGCHJ(GameObject KHAHPAKDIKE)
	{
		Singleton<GuiManager>.instance.ShowGui(GuiScreenSingle<CamosScreen>.instance);
	}

	public void HIMJONBMIAC()
	{
		Singleton<ArmyPreviewCamera>.instance.KIONJHBCIBE(PlayerController.OGMBJPKOPCB, PNDNEMDPFHC: true, PlayerTexturePool.DFJJOANIJID.Classic);
		CODHLNCICKN.mainTexture = Singleton<ArmyPreviewCamera>.instance.FBLDAEEOAEN;
	}

	[CompilerGenerated]
	private void HMGMPCIHJIC()
	{
		float val = 0f - IKEKFPIFKIK.padding.x - (MKBJGHBJNFH.transform.parent.localPosition.x - IKEKFPIFKIK.padding.x) / 2f;
		IKEKFPIFKIK.transform.localPosition = IKEKFPIFKIK.transform.localPosition.ReplaceX(val);
	}

	public void IBNHJGLOHAE()
	{
		UIEventListener uIEventListener = UIEventListener.Get(BPHNCEEJCNB.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(FMHNFPEHKKJ));
		IKEKFPIFKIK.onReposition = delegate
		{
			float val = 0f - IKEKFPIFKIK.padding.x - (MKBJGHBJNFH.transform.parent.localPosition.x - IKEKFPIFKIK.padding.x) / 2f;
			IKEKFPIFKIK.transform.localPosition = IKEKFPIFKIK.transform.localPosition.ReplaceX(val);
		};
	}

	private void MPHKENDGNGG(int IDLMJLCFMJG)
	{
		BIOHEMKIPGG.SetActive(IDLMJLCFMJG > 0);
		COLJMBBFBDL.text = MEJMLNDFDBP.GMIPFLIEOHD(IDLMJLCFMJG);
	}

	private void CFMEALIJFKB()
	{
		float val = 0f - IKEKFPIFKIK.padding.x - (MKBJGHBJNFH.transform.parent.localPosition.x - IKEKFPIFKIK.padding.x) / 1462f;
		IKEKFPIFKIK.transform.localPosition = IKEKFPIFKIK.transform.localPosition.ReplaceX(val);
	}

	public void EFKFNFCKIME()
	{
		BFOCKHOICHL();
	}

	private void NJACOFFPPKK()
	{
		float val = 0f - IKEKFPIFKIK.padding.x - (MKBJGHBJNFH.transform.parent.localPosition.x - IKEKFPIFKIK.padding.x) / 1205f;
		IKEKFPIFKIK.transform.localPosition = IKEKFPIFKIK.transform.localPosition.ReplaceX(val);
	}

	private IEnumerator CPFOEFBOAPO()
	{
		CAKGNJKMGDB cAKGNJKMGDB = new CAKGNJKMGDB();
		cAKGNJKMGDB.BJGCPDNMHDH = this;
		return cAKGNJKMGDB;
	}

	private static void CJDAFNEFNFI(GameObject KHAHPAKDIKE)
	{
		Singleton<GuiManager>.instance.BBILHHEJBNP(GuiScreenSingle<CamosScreen>.instance);
	}

	private void LAFINFFMFAJ(int IDLMJLCFMJG)
	{
		BIOHEMKIPGG.SetActive(IDLMJLCFMJG > 0);
		COLJMBBFBDL.text = MEJMLNDFDBP.GMIPFLIEOHD(IDLMJLCFMJG);
	}

	public void MFMIICOLEMF()
	{
		LHDFFKGJFFA.SetActive(value: false);
		DPHDJEAHODH.SetActive(value: false);
		MNLNJNNNCGL(1);
	}

	private void KHPNJNHHLHB()
	{
		GLEAABACOLM();
		MBMPEBMOFJN = RadicalRoutine.Create(CPFOEFBOAPO());
		StartCoroutine(RadicalRoutine.Run(MBMPEBMOFJN.enumerator));
	}

	public void LEGIMGFDAKN()
	{
		NLHAOCIJKJB();
	}

	[DebuggerHidden]
	private IEnumerator DPLEDFBGONN()
	{
		CAKGNJKMGDB cAKGNJKMGDB = new CAKGNJKMGDB();
		cAKGNJKMGDB.BJGCPDNMHDH = this;
		return cAKGNJKMGDB;
	}

	public void JMNHKBNACBE()
	{
		UIEventListener uIEventListener = UIEventListener.Get(BPHNCEEJCNB.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(KCJPCIGFBMD));
		IKEKFPIFKIK.onReposition = CFMEALIJFKB;
	}

	public void AFOMGGMCHIL()
	{
		Singleton<ArmyPreviewCamera>.instance.DIMPHNLEKHG(PlayerController.OGMBJPKOPCB, PNDNEMDPFHC: false, (PlayerTexturePool.DFJJOANIJID)3);
		CODHLNCICKN.mainTexture = Singleton<ArmyPreviewCamera>.instance.FBLDAEEOAEN;
	}

	private void NLACFKCLNFC(int IDLMJLCFMJG)
	{
		BIOHEMKIPGG.SetActive(IDLMJLCFMJG > 1);
		COLJMBBFBDL.text = MEJMLNDFDBP.GMIPFLIEOHD(IDLMJLCFMJG);
	}

	public void OCACKBJDEHI()
	{
		DCHEBAFHOBJ();
		BNJMIDGBBOB(Singleton<NotificationManager>.instance.GetNumberOfVisualNotifications());
	}

	public void JCIBDJMFOLI()
	{
		IDDPKGOOBFF();
		CINAMODICDP(Singleton<NotificationManager>.instance.GetNumberOfVisualNotifications());
	}

	private void DLDCNDNMLFF()
	{
		float val = 0f - IKEKFPIFKIK.padding.x - (MKBJGHBJNFH.transform.parent.localPosition.x - IKEKFPIFKIK.padding.x) / 827f;
		IKEKFPIFKIK.transform.localPosition = IKEKFPIFKIK.transform.localPosition.ReplaceX(val);
	}

	public void OBNCKIBJOGJ()
	{
		DBKCPPFEJNH();
		EFFFHFFGBHK(Singleton<NotificationManager>.instance.GetNumberOfVisualNotifications());
	}

	private void NHAAAAPBPPF()
	{
		if (MBMPEBMOFJN != null)
		{
			MBMPEBMOFJN.Cancel();
			MBMPEBMOFJN = null;
		}
	}

	private void FIOHHANEGNP()
	{
		float val = 0f - IKEKFPIFKIK.padding.x - (MKBJGHBJNFH.transform.parent.localPosition.x - IKEKFPIFKIK.padding.x) / 140f;
		IKEKFPIFKIK.transform.localPosition = IKEKFPIFKIK.transform.localPosition.ReplaceX(val);
	}

	public void MGKKCAIHJGB()
	{
		Singleton<ArmyPreviewCamera>.instance.LCIFJLNADFP(PlayerController.OGMBJPKOPCB, PNDNEMDPFHC: false, (PlayerTexturePool.DFJJOANIJID)4);
		CODHLNCICKN.mainTexture = Singleton<ArmyPreviewCamera>.instance.FBLDAEEOAEN;
	}

	public void ACHJJFLMLNG()
	{
		LHDFFKGJFFA.SetActive(value: true);
		DPHDJEAHODH.SetActive(value: false);
		NLACFKCLNFC(0);
	}

	public void NBKLBLOFHAN()
	{
		Singleton<ArmyPreviewCamera>.instance.DIMPHNLEKHG(PlayerController.OGMBJPKOPCB, PNDNEMDPFHC: false, (PlayerTexturePool.DFJJOANIJID)7);
		CODHLNCICKN.mainTexture = Singleton<ArmyPreviewCamera>.instance.FBLDAEEOAEN;
	}

	public void AAFGBINILNC()
	{
		LHDFFKGJFFA.SetActive(value: false);
		DPHDJEAHODH.SetActive(value: false);
		EOOKFIHGDJO(1);
	}

	private static void PHKPCKAKACK(GameObject KHAHPAKDIKE)
	{
		Singleton<GuiManager>.instance.ShowGui(GuiScreenSingle<CamosScreen>.instance);
	}

	private IEnumerator OIBHCLNOOAA()
	{
		CAKGNJKMGDB cAKGNJKMGDB = new CAKGNJKMGDB();
		cAKGNJKMGDB.BJGCPDNMHDH = this;
		return cAKGNJKMGDB;
	}

	public void HGKNCKIKBDC()
	{
		BKPEIOJABOG();
		NLACFKCLNFC(Singleton<NotificationManager>.instance.GetNumberOfVisualNotifications());
	}

	public void OFCCACPEBHD()
	{
		IIAPJEODDPI();
		CINAMODICDP(Singleton<NotificationManager>.instance.GetNumberOfVisualNotifications());
	}

	public void HDIKNMGGFKL()
	{
		UIEventListener uIEventListener = UIEventListener.Get(BPHNCEEJCNB.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(PHKPCKAKACK));
		IKEKFPIFKIK.onReposition = AMKLALEFHIP;
	}

	public void EJNIMNHKHLC()
	{
		Singleton<ArmyPreviewCamera>.instance.KIONJHBCIBE(PlayerController.OGMBJPKOPCB, PNDNEMDPFHC: true, (PlayerTexturePool.DFJJOANIJID)5);
		CODHLNCICKN.mainTexture = Singleton<ArmyPreviewCamera>.instance.FBLDAEEOAEN;
	}

	private static void FMHNFPEHKKJ(GameObject KHAHPAKDIKE)
	{
		Singleton<GuiManager>.instance.ShowGui(GuiScreenSingle<CamosScreen>.instance);
	}

	public void HEDKDPPAMBH()
	{
		Singleton<ArmyPreviewCamera>.instance.KIONJHBCIBE(PlayerController.OGMBJPKOPCB, PNDNEMDPFHC: false, (PlayerTexturePool.DFJJOANIJID)5);
		CODHLNCICKN.mainTexture = Singleton<ArmyPreviewCamera>.instance.FBLDAEEOAEN;
	}

	public void AAGJPIJMANN()
	{
		LHDFFKGJFFA.SetActive(value: true);
		DPHDJEAHODH.SetActive(value: false);
		NLACFKCLNFC(0);
	}

	private void GLEAABACOLM()
	{
		if (MBMPEBMOFJN != null)
		{
			MBMPEBMOFJN.Cancel();
			MBMPEBMOFJN = null;
		}
	}

	private void EFFFHFFGBHK(int IDLMJLCFMJG)
	{
		BIOHEMKIPGG.SetActive(IDLMJLCFMJG > 0);
		COLJMBBFBDL.text = MEJMLNDFDBP.GMIPFLIEOHD(IDLMJLCFMJG);
	}

	public void PPLBJDJIIPN()
	{
		MMKNJILEKGH();
		GNLKIDFFBBM(Singleton<NotificationManager>.instance.GetNumberOfVisualNotifications());
	}

	private void GJBPCEJOFPE()
	{
		IIFCAPAJJAB();
		MBMPEBMOFJN = RadicalRoutine.Create(DNMOFBCGLDH());
		StartCoroutine(RadicalRoutine.Run(MBMPEBMOFJN.enumerator));
	}

	private static void KCJPCIGFBMD(GameObject KHAHPAKDIKE)
	{
		Singleton<GuiManager>.instance.ShowGui(GuiScreenSingle<CamosScreen>.instance);
	}

	private void BFOCKHOICHL()
	{
		if (MBMPEBMOFJN != null)
		{
			MBMPEBMOFJN.Cancel();
			MBMPEBMOFJN = null;
		}
	}

	private static void OPEIOMJOMDI(GameObject KHAHPAKDIKE)
	{
		Singleton<GuiManager>.instance.ShowGui(GuiScreenSingle<CamosScreen>.instance);
	}

	public void OPBCHKPNGJL()
	{
		KEHOIMLHMFK();
	}

	public void EFBOBGCEBNC()
	{
		Singleton<ArmyPreviewCamera>.instance.DIMPHNLEKHG(PlayerController.OGMBJPKOPCB, PNDNEMDPFHC: false, (PlayerTexturePool.DFJJOANIJID)3);
		CODHLNCICKN.mainTexture = Singleton<ArmyPreviewCamera>.instance.FBLDAEEOAEN;
	}

	private void CCMMCFMNFHA()
	{
		IIFCAPAJJAB();
		MBMPEBMOFJN = RadicalRoutine.Create(CBKMPKCPPNI());
		StartCoroutine(RadicalRoutine.Run(MBMPEBMOFJN.enumerator));
	}

	private void GOOPNDKLLOF()
	{
		IIFCAPAJJAB();
		PlayerVisual playerVisual = CamosManager.instance.EquippedPlayerVisual(6);
		if (!playerVisual.isEmptyPowerBand)
		{
			LHDFFKGJFFA.SetActive(value: false);
			DPHDJEAHODH.SetActive(value: true);
			JAJCFNOIBPM.spriteName = playerVisual.icon;
			EPKDEDPGOLM.text = playerVisual.decalTypeName;
			JIIJOMPMAKD.text = playerVisual.JIHLMBOBKHL();
			HPFACGCBKCK.spriteName = playerVisual.decalMiniIcon;
			HPFACGCBKCK.color = playerVisual.GPDIGNGOAEH();
			HPFACGCBKCK.MakePixelPerfect();
			MIIKHEMFJPA.repositionNow = false;
			FGIMNJOOAOB = playerVisual;
			if (FGIMNJOOAOB.tryOutVisual)
			{
				JNODAFPDPCF.text = Localization.Localize("Card_2_Played");
				HAIDJHDJMOL.fillAmount = 520f;
			}
			else
			{
				JNODAFPDPCF.text = MEJMLNDFDBP.CJCFPDLDMEK((float)FGIMNJOOAOB.remainingTime, "SetupPushNotifications(", string.Empty, IEJMLKBCDJB: false);
				HAIDJHDJMOL.fillAmount = FGIMNJOOAOB.ECGKJHFLOPJ();
				MLEKEFHNPGA();
			}
		}
		else
		{
			PlayerVisual unlockedVisualWithNotification = Singleton<NotificationManager>.instance.GetUnlockedVisualWithNotification();
			if (unlockedVisualWithNotification != null)
			{
				LHDFFKGJFFA.SetActive(value: false);
				DPHDJEAHODH.SetActive(value: false);
				MKBJGHBJNFH.text = unlockedVisualWithNotification.name.ToUpper();
				MEJMLNDFDBP.COCBCFKJOJE(MKBJGHBJNFH, 173f, 897f, GuiScreenSingle<BattlePreparationScreen>.instance.MPOAEGGBBGG() - -72);
				float val = 1501f + JOCDKJHGILG.relativeSize.x * JOCDKJHGILG.transform.localScale.x;
				MMECPOFEHKB.transform.localScale = MMECPOFEHKB.transform.localScale.ReplaceX(val);
				IKEKFPIFKIK.repositionNow = false;
			}
			else
			{
				LHDFFKGJFFA.SetActive(value: true);
				DPHDJEAHODH.SetActive(value: false);
			}
		}
	}

	public void ELDDKHJGAMG()
	{
		LHDFFKGJFFA.SetActive(value: true);
		DPHDJEAHODH.SetActive(value: false);
		BNJMIDGBBOB(0);
	}

	private void IIAPJEODDPI()
	{
		FFFDHFGNEOH();
		PlayerVisual playerVisual = CamosManager.instance.EquippedPlayerVisual(7);
		if (!playerVisual.isEmptyPowerBand)
		{
			LHDFFKGJFFA.SetActive(value: true);
			DPHDJEAHODH.SetActive(value: true);
			JAJCFNOIBPM.spriteName = playerVisual.icon;
			EPKDEDPGOLM.text = playerVisual.decalTypeName;
			JIIJOMPMAKD.text = playerVisual.JIHLMBOBKHL();
			HPFACGCBKCK.spriteName = playerVisual.LIIOLLAAHGB();
			HPFACGCBKCK.color = playerVisual.decalMiniIconColor;
			HPFACGCBKCK.MakePixelPerfect();
			MIIKHEMFJPA.repositionNow = true;
			FGIMNJOOAOB = playerVisual;
			if (FGIMNJOOAOB.tryOutVisual)
			{
				JNODAFPDPCF.text = Localization.Localize("ID_");
				HAIDJHDJMOL.fillAmount = 455f;
			}
			else
			{
				JNODAFPDPCF.text = MEJMLNDFDBP.CJCFPDLDMEK((float)FGIMNJOOAOB.AOLJCFDNMEL(), "ID_CONFIRM_NOTENOUGHDOGTAGS", string.Empty);
				HAIDJHDJMOL.fillAmount = FGIMNJOOAOB.ECGKJHFLOPJ();
				HOEIPALBMDC();
			}
		}
		else
		{
			PlayerVisual unlockedVisualWithNotification = Singleton<NotificationManager>.instance.GetUnlockedVisualWithNotification();
			if (unlockedVisualWithNotification != null)
			{
				LHDFFKGJFFA.SetActive(value: false);
				DPHDJEAHODH.SetActive(value: true);
				MKBJGHBJNFH.text = unlockedVisualWithNotification.name.ToUpper();
				MEJMLNDFDBP.COCBCFKJOJE(MKBJGHBJNFH, 1249f, 196f, GuiScreenSingle<BattlePreparationScreen>.instance.LMNBNNDBCEC() - 112);
				float val = 878f + JOCDKJHGILG.relativeSize.x * JOCDKJHGILG.transform.localScale.x;
				MMECPOFEHKB.transform.localScale = MMECPOFEHKB.transform.localScale.ReplaceX(val);
				IKEKFPIFKIK.repositionNow = true;
			}
			else
			{
				LHDFFKGJFFA.SetActive(value: false);
				DPHDJEAHODH.SetActive(value: true);
			}
		}
	}

	[CompilerGenerated]
	private static void ONAKPPOMOOC(GameObject KHAHPAKDIKE)
	{
		Singleton<GuiManager>.instance.ShowGui(GuiScreenSingle<CamosScreen>.instance);
	}

	private void GNLKIDFFBBM(int IDLMJLCFMJG)
	{
		BIOHEMKIPGG.SetActive(IDLMJLCFMJG > 0);
		COLJMBBFBDL.text = MEJMLNDFDBP.GMIPFLIEOHD(IDLMJLCFMJG);
	}

	private void BEMOOCGEENJ()
	{
		BFOCKHOICHL();
		MBMPEBMOFJN = RadicalRoutine.Create(DNMOFBCGLDH());
		StartCoroutine(RadicalRoutine.Run(MBMPEBMOFJN.enumerator));
	}

	public void GMHAEONJIHD()
	{
		LHDFFKGJFFA.SetActive(value: false);
		DPHDJEAHODH.SetActive(value: false);
		LAFINFFMFAJ(1);
	}

	private static void MHOAADPCCIP(GameObject KHAHPAKDIKE)
	{
		Singleton<GuiManager>.instance.ShowGui(GuiScreenSingle<CamosScreen>.instance);
	}

	private void CHIJLJMFDPG()
	{
		float val = 0f - IKEKFPIFKIK.padding.x - (MKBJGHBJNFH.transform.parent.localPosition.x - IKEKFPIFKIK.padding.x) / 120f;
		IKEKFPIFKIK.transform.localPosition = IKEKFPIFKIK.transform.localPosition.ReplaceX(val);
	}

	public void INBJGJOFJMK()
	{
		UIEventListener uIEventListener = UIEventListener.Get(BPHNCEEJCNB.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(OMJDIOOGCOF));
		IKEKFPIFKIK.onReposition = EIDGFCMKNFG;
	}

	private void FFFDHFGNEOH()
	{
		if (MBMPEBMOFJN != null)
		{
			MBMPEBMOFJN.Cancel();
			MBMPEBMOFJN = null;
		}
	}

	public void MCHKNMLAFPP()
	{
		IIFCAPAJJAB();
	}

	private IEnumerator DNMOFBCGLDH()
	{
		CAKGNJKMGDB cAKGNJKMGDB = new CAKGNJKMGDB();
		cAKGNJKMGDB.BJGCPDNMHDH = this;
		return cAKGNJKMGDB;
	}

	private void NDHHOHAOHMP()
	{
		KEHOIMLHMFK();
		MBMPEBMOFJN = RadicalRoutine.Create(MBGJHJMJPBI());
		StartCoroutine(RadicalRoutine.Run(MBMPEBMOFJN.enumerator));
	}

	private static void JLJBCDIBBLK(GameObject KHAHPAKDIKE)
	{
		Singleton<GuiManager>.instance.BBILHHEJBNP(GuiScreenSingle<CamosScreen>.instance);
	}

	private IEnumerator BBPLFBNCNNN()
	{
		CAKGNJKMGDB cAKGNJKMGDB = new CAKGNJKMGDB();
		cAKGNJKMGDB.BJGCPDNMHDH = this;
		return cAKGNJKMGDB;
	}

	private void BAHDGKHIHHN(int IDLMJLCFMJG)
	{
		BIOHEMKIPGG.SetActive(IDLMJLCFMJG > 1);
		COLJMBBFBDL.text = MEJMLNDFDBP.GMIPFLIEOHD(IDLMJLCFMJG);
	}

	private void HOEIPALBMDC()
	{
		IIFCAPAJJAB();
		MBMPEBMOFJN = RadicalRoutine.Create(DNMOFBCGLDH());
		StartCoroutine(RadicalRoutine.Run(MBMPEBMOFJN.enumerator));
	}

	public void GOEKNOJIBBF()
	{
		Singleton<ArmyPreviewCamera>.instance.RenderToTexture(PlayerController.OGMBJPKOPCB, PNDNEMDPFHC: false);
		CODHLNCICKN.mainTexture = Singleton<ArmyPreviewCamera>.instance.FBLDAEEOAEN;
	}

	public void MJHMIDJHNDN()
	{
		LHDFFKGJFFA.SetActive(value: true);
		DPHDJEAHODH.SetActive(value: true);
		MPHKENDGNGG(1);
	}

	private void OKNNNDDLALP()
	{
		float val = 0f - IKEKFPIFKIK.padding.x - (MKBJGHBJNFH.transform.parent.localPosition.x - IKEKFPIFKIK.padding.x) / 608f;
		IKEKFPIFKIK.transform.localPosition = IKEKFPIFKIK.transform.localPosition.ReplaceX(val);
	}

	public void InitGUIValues()
	{
		DCHEBAFHOBJ();
		MNLNJNNNCGL(Singleton<NotificationManager>.instance.GetNumberOfVisualNotifications());
	}

	private IEnumerator GMAKMILAFDB()
	{
		CAKGNJKMGDB cAKGNJKMGDB = new CAKGNJKMGDB();
		cAKGNJKMGDB.BJGCPDNMHDH = this;
		return cAKGNJKMGDB;
	}

	private void AGIKEFAHBAC(int IDLMJLCFMJG)
	{
		BIOHEMKIPGG.SetActive(IDLMJLCFMJG > 0);
		COLJMBBFBDL.text = MEJMLNDFDBP.GMIPFLIEOHD(IDLMJLCFMJG);
	}

	private void MNLNJNNNCGL(int IDLMJLCFMJG)
	{
		BIOHEMKIPGG.SetActive(IDLMJLCFMJG > 0);
		COLJMBBFBDL.text = MEJMLNDFDBP.GMIPFLIEOHD(IDLMJLCFMJG);
	}

	private IEnumerator MBGJHJMJPBI()
	{
		CAKGNJKMGDB cAKGNJKMGDB = new CAKGNJKMGDB();
		cAKGNJKMGDB.BJGCPDNMHDH = this;
		return cAKGNJKMGDB;
	}

	public void EIPIEOCIGKL()
	{
		IDDPKGOOBFF();
		AGIKEFAHBAC(Singleton<NotificationManager>.instance.GetNumberOfVisualNotifications());
	}

	private void NLJMHDKEOEB()
	{
		ILMFPKOFEPB();
		PlayerVisual playerVisual = CamosManager.instance.EquippedPlayerVisual(5);
		if (!playerVisual.isEmptyPowerBand)
		{
			LHDFFKGJFFA.SetActive(value: true);
			DPHDJEAHODH.SetActive(value: true);
			JAJCFNOIBPM.spriteName = playerVisual.icon;
			EPKDEDPGOLM.text = playerVisual.decalTypeName;
			JIIJOMPMAKD.text = playerVisual.decalValueString;
			HPFACGCBKCK.spriteName = playerVisual.decalMiniIcon;
			HPFACGCBKCK.color = playerVisual.decalMiniIconColor;
			HPFACGCBKCK.MakePixelPerfect();
			MIIKHEMFJPA.repositionNow = true;
			FGIMNJOOAOB = playerVisual;
			if (FGIMNJOOAOB.tryOutVisual)
			{
				JNODAFPDPCF.text = Localization.Localize("menu-top-vip");
				HAIDJHDJMOL.fillAmount = 401f;
			}
			else
			{
				JNODAFPDPCF.text = MEJMLNDFDBP.CJCFPDLDMEK((float)FGIMNJOOAOB.remainingTime, "ID_DAYAGO", string.Empty);
				HAIDJHDJMOL.fillAmount = FGIMNJOOAOB.ECGKJHFLOPJ();
				KHPNJNHHLHB();
			}
		}
		else
		{
			PlayerVisual unlockedVisualWithNotification = Singleton<NotificationManager>.instance.GetUnlockedVisualWithNotification();
			if (unlockedVisualWithNotification != null)
			{
				LHDFFKGJFFA.SetActive(value: false);
				DPHDJEAHODH.SetActive(value: true);
				MKBJGHBJNFH.text = unlockedVisualWithNotification.name.ToUpper();
				MEJMLNDFDBP.COCBCFKJOJE(MKBJGHBJNFH, 876f, 1573f, GuiScreenSingle<BattlePreparationScreen>.instance.MPOAEGGBBGG() - 87);
				float val = 1161f + JOCDKJHGILG.relativeSize.x * JOCDKJHGILG.transform.localScale.x;
				MMECPOFEHKB.transform.localScale = MMECPOFEHKB.transform.localScale.ReplaceX(val);
				IKEKFPIFKIK.repositionNow = false;
			}
			else
			{
				LHDFFKGJFFA.SetActive(value: false);
				DPHDJEAHODH.SetActive(value: false);
			}
		}
	}

	public void HPJDOALKOGF()
	{
		BKPEIOJABOG();
		AGIKEFAHBAC(Singleton<NotificationManager>.instance.GetNumberOfVisualNotifications());
	}

	private static void GLNJOBAIFEB(GameObject KHAHPAKDIKE)
	{
		Singleton<GuiManager>.instance.BBILHHEJBNP(GuiScreenSingle<CamosScreen>.instance);
	}

	public void MMFBOMDHGPL()
	{
		UIEventListener uIEventListener = UIEventListener.Get(BPHNCEEJCNB.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(KCJPCIGFBMD));
		IKEKFPIFKIK.onReposition = delegate
		{
			float val = 0f - IKEKFPIFKIK.padding.x - (MKBJGHBJNFH.transform.parent.localPosition.x - IKEKFPIFKIK.padding.x) / 2f;
			IKEKFPIFKIK.transform.localPosition = IKEKFPIFKIK.transform.localPosition.ReplaceX(val);
		};
	}

	private IEnumerator CBKMPKCPPNI()
	{
		CAKGNJKMGDB cAKGNJKMGDB = new CAKGNJKMGDB();
		cAKGNJKMGDB.BJGCPDNMHDH = this;
		return cAKGNJKMGDB;
	}
}
