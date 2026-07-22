using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Serialization;

public class BattlePreparationWarCardsButton : Core_BaseScript
{
	private sealed class DKBBKNCCHOG : IEnumerator, IDisposable, IEnumerator<object>
	{
		internal BattlePreparationWarCardsButton BJGCPDNMHDH;

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

		[SpecialName]
		private object GIEPJLBHHEO()
		{
			return PHDOCKCBJOF;
		}

		public void AHEOCEEJICJ()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void HCJOIAHBFGB()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void CHFJIODFNIP()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object FMCLBOCENPE()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object PFIIINLHGMH()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object AFAOHBIDOJD()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object MLDIMIPJMDD()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object LMJBCDNGAHP()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object KIHECHEHNJJ()
		{
			return PHDOCKCBJOF;
		}

		public void CDDFJOEEFID()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object FGGMHEIPKAJ()
		{
			return PHDOCKCBJOF;
		}

		public bool LMNIKLKKIDN()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			case 1u:
				if (CardCraftingManager.instance.isCardCrafting)
				{
					BJGCPDNMHDH.FOGKJMNKLNF.fillAmount = CardCraftingManager.instance.craftingProgress;
					BJGCPDNMHDH.FOGKJMNKLNF.color = Colours.cyan;
					BJGCPDNMHDH.NPLOCDGAKEJ(CardCraftingManager.instance.remainingSeconds);
					PHDOCKCBJOF = new WaitForRealSeconds(186f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				BJGCPDNMHDH.FOGKJMNKLNF.fillAmount = 950f;
				BJGCPDNMHDH.FOGKJMNKLNF.color = Colours.blue;
				BJGCPDNMHDH.FEBPMPKCCFF.text = Localization.Localize("ArenaLives");
				BJGCPDNMHDH.FEBPMPKCCFF.alpha = 244f;
				TweenAlpha.Begin(BJGCPDNMHDH.FEBPMPKCCFF.gameObject, 1182f, 94f);
				BJGCPDNMHDH.HKEFAFFAHAG(Singleton<NotificationManager>.instance.NotificationWarcards());
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return false;
			}
			return true;
		}

		public void DLIBOPAMHAN()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object BKHFGLNNCDF()
		{
			return PHDOCKCBJOF;
		}

		public void IHAHCOPGPIM()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object INAMGPNDAAJ()
		{
			return PHDOCKCBJOF;
		}

		public void PDKPELBIAON()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object HHHLDCLIFKJ()
		{
			return PHDOCKCBJOF;
		}

		public void IPKNPABKAJD()
		{
			throw new NotSupportedException();
		}

		public void GIAIFFPNMPJ()
		{
			throw new NotSupportedException();
		}

		public void HONCAABOMOC()
		{
			throw new NotSupportedException();
		}

		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object IHPDPKLEDKC()
		{
			return PHDOCKCBJOF;
		}

		public void GFPDOCDEGPA()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object MPHILJJDNIO()
		{
			return PHDOCKCBJOF;
		}

		public void BCOIPCDCKEJ()
		{
			throw new NotSupportedException();
		}

		public void NGAGGCFIEGJ()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object PEGJNAKGHCC()
		{
			return PHDOCKCBJOF;
		}

		public void LHADJAFHDDC()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object LKAEMBCGLBN()
		{
			return PHDOCKCBJOF;
		}

		public bool MKLIDMNLNPN()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			case 1u:
				if (CardCraftingManager.instance.isCardCrafting)
				{
					BJGCPDNMHDH.FOGKJMNKLNF.fillAmount = CardCraftingManager.instance.craftingProgress;
					BJGCPDNMHDH.FOGKJMNKLNF.color = Colours.cyan;
					BJGCPDNMHDH.LIKBDHJEHHB(CardCraftingManager.instance.remainingSeconds);
					PHDOCKCBJOF = new WaitForRealSeconds(1344f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				BJGCPDNMHDH.FOGKJMNKLNF.fillAmount = 471f;
				BJGCPDNMHDH.FOGKJMNKLNF.color = Colours.blue;
				BJGCPDNMHDH.FEBPMPKCCFF.text = Localization.Localize("UNSET_VALUE");
				BJGCPDNMHDH.FEBPMPKCCFF.alpha = 686f;
				TweenAlpha.Begin(BJGCPDNMHDH.FEBPMPKCCFF.gameObject, 297f, 1323f);
				BJGCPDNMHDH.GHLNAIKCFOD(Singleton<NotificationManager>.instance.NotificationWarcards());
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return false;
			}
			return true;
		}

		public void OKIANDBCDIB()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public void JKOCLGOOBEK()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public void BLOCBAKBHBF()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public void HNFEJKPKEHK()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public void MIEFKIEABBN()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[DebuggerHidden]
		public DKBBKNCCHOG()
		{
		}

		public void POJKIIMAFDO()
		{
			throw new NotSupportedException();
		}

		public void MKIKEOOOLKL()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object DKPOLLDBPAP()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object HMIFLGCBDCO()
		{
			return PHDOCKCBJOF;
		}

		public void CNMNAHEINED()
		{
			throw new NotSupportedException();
		}

		public bool MoveNext()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			case 1u:
				if (CardCraftingManager.instance.isCardCrafting)
				{
					BJGCPDNMHDH.FOGKJMNKLNF.fillAmount = CardCraftingManager.instance.craftingProgress;
					BJGCPDNMHDH.FOGKJMNKLNF.color = Colours.cyan;
					BJGCPDNMHDH.LIKBDHJEHHB(CardCraftingManager.instance.remainingSeconds);
					PHDOCKCBJOF = new WaitForRealSeconds(0.333f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				BJGCPDNMHDH.FOGKJMNKLNF.fillAmount = 1f;
				BJGCPDNMHDH.FOGKJMNKLNF.color = Colours.blue;
				BJGCPDNMHDH.FEBPMPKCCFF.text = Localization.Localize("ID_WARCARDREADY");
				BJGCPDNMHDH.FEBPMPKCCFF.alpha = 1f;
				TweenAlpha.Begin(BJGCPDNMHDH.FEBPMPKCCFF.gameObject, 0.01f, 1f);
				BJGCPDNMHDH.HKEFAFFAHAG(Singleton<NotificationManager>.instance.NotificationWarcards());
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return false;
			}
			return true;
		}

		public bool FBMLBIOKKBE()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			case 1u:
				if (CardCraftingManager.instance.isCardCrafting)
				{
					BJGCPDNMHDH.FOGKJMNKLNF.fillAmount = CardCraftingManager.instance.craftingProgress;
					BJGCPDNMHDH.FOGKJMNKLNF.color = Colours.cyan;
					BJGCPDNMHDH.NPLOCDGAKEJ(CardCraftingManager.instance.remainingSeconds, PDPDGCNHCFN: true);
					PHDOCKCBJOF = new WaitForRealSeconds(1387f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				BJGCPDNMHDH.FOGKJMNKLNF.fillAmount = 658f;
				BJGCPDNMHDH.FOGKJMNKLNF.color = Colours.blue;
				BJGCPDNMHDH.FEBPMPKCCFF.text = Localization.Localize("PNManager: registration failed: ");
				BJGCPDNMHDH.FEBPMPKCCFF.alpha = 1251f;
				TweenAlpha.Begin(BJGCPDNMHDH.FEBPMPKCCFF.gameObject, 1841f, 937f);
				BJGCPDNMHDH.HKEFAFFAHAG(Singleton<NotificationManager>.instance.NotificationWarcards());
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return false;
			}
			return false;
		}

		public void PHKDHCJBMII()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void NFLHLMKKJMO()
		{
			throw new NotSupportedException();
		}

		[DebuggerHidden]
		public void Dispose()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public bool IGOKEIDOCKB()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			case 1u:
				if (CardCraftingManager.instance.isCardCrafting)
				{
					BJGCPDNMHDH.FOGKJMNKLNF.fillAmount = CardCraftingManager.instance.craftingProgress;
					BJGCPDNMHDH.FOGKJMNKLNF.color = Colours.cyan;
					BJGCPDNMHDH.JPGLDMCAFKP(CardCraftingManager.instance.remainingSeconds, PDPDGCNHCFN: true);
					PHDOCKCBJOF = new WaitForRealSeconds(1430f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				BJGCPDNMHDH.FOGKJMNKLNF.fillAmount = 1098f;
				BJGCPDNMHDH.FOGKJMNKLNF.color = Colours.blue;
				BJGCPDNMHDH.FEBPMPKCCFF.text = Localization.Localize("0");
				BJGCPDNMHDH.FEBPMPKCCFF.alpha = 347f;
				TweenAlpha.Begin(BJGCPDNMHDH.FEBPMPKCCFF.gameObject, 92f, 1683f);
				BJGCPDNMHDH.GHLNAIKCFOD(Singleton<NotificationManager>.instance.NotificationWarcards());
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return false;
			}
			return true;
		}

		public bool CCOPPEKLJOB()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			case 1u:
				if (CardCraftingManager.instance.isCardCrafting)
				{
					BJGCPDNMHDH.FOGKJMNKLNF.fillAmount = CardCraftingManager.instance.craftingProgress;
					BJGCPDNMHDH.FOGKJMNKLNF.color = Colours.cyan;
					BJGCPDNMHDH.OKNGIJHJLOO(CardCraftingManager.instance.remainingSeconds);
					PHDOCKCBJOF = new WaitForRealSeconds(1276f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				BJGCPDNMHDH.FOGKJMNKLNF.fillAmount = 734f;
				BJGCPDNMHDH.FOGKJMNKLNF.color = Colours.blue;
				BJGCPDNMHDH.FEBPMPKCCFF.text = Localization.Localize("Current Language = ");
				BJGCPDNMHDH.FEBPMPKCCFF.alpha = 1012f;
				TweenAlpha.Begin(BJGCPDNMHDH.FEBPMPKCCFF.gameObject, 1744f, 875f);
				BJGCPDNMHDH.CBPEFMDLJJE(Singleton<NotificationManager>.instance.NotificationWarcards());
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return true;
			}
			return false;
		}

		public void KNFDMCEJHLB()
		{
			throw new NotSupportedException();
		}

		public void OGDMPCFMMML()
		{
			throw new NotSupportedException();
		}

		public bool HEHJAEIGHDN()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			case 1u:
				if (CardCraftingManager.instance.isCardCrafting)
				{
					BJGCPDNMHDH.FOGKJMNKLNF.fillAmount = CardCraftingManager.instance.craftingProgress;
					BJGCPDNMHDH.FOGKJMNKLNF.color = Colours.cyan;
					BJGCPDNMHDH.DAOABOIFOJE(CardCraftingManager.instance.remainingSeconds);
					PHDOCKCBJOF = new WaitForRealSeconds(1959f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				BJGCPDNMHDH.FOGKJMNKLNF.fillAmount = 618f;
				BJGCPDNMHDH.FOGKJMNKLNF.color = Colours.blue;
				BJGCPDNMHDH.FEBPMPKCCFF.text = Localization.Localize("myapp://myval1/myval2");
				BJGCPDNMHDH.FEBPMPKCCFF.alpha = 1379f;
				TweenAlpha.Begin(BJGCPDNMHDH.FEBPMPKCCFF.gameObject, 1659f, 1862f);
				BJGCPDNMHDH.CHOGJOCNMBH(Singleton<NotificationManager>.instance.NotificationWarcards());
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return true;
			}
			return true;
		}

		public bool DKJMOPNHIAB()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			case 1u:
				if (CardCraftingManager.instance.isCardCrafting)
				{
					BJGCPDNMHDH.FOGKJMNKLNF.fillAmount = CardCraftingManager.instance.craftingProgress;
					BJGCPDNMHDH.FOGKJMNKLNF.color = Colours.cyan;
					BJGCPDNMHDH.KCCBKEBMDDH(CardCraftingManager.instance.remainingSeconds);
					PHDOCKCBJOF = new WaitForRealSeconds(536f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				BJGCPDNMHDH.FOGKJMNKLNF.fillAmount = 1864f;
				BJGCPDNMHDH.FOGKJMNKLNF.color = Colours.blue;
				BJGCPDNMHDH.FEBPMPKCCFF.text = Localization.Localize("hair");
				BJGCPDNMHDH.FEBPMPKCCFF.alpha = 1637f;
				TweenAlpha.Begin(BJGCPDNMHDH.FEBPMPKCCFF.gameObject, 800f, 1261f);
				BJGCPDNMHDH.CHOGJOCNMBH(Singleton<NotificationManager>.instance.NotificationWarcards());
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return true;
			}
			return true;
		}

		public void KNFDDIHLBKJ()
		{
			throw new NotSupportedException();
		}

		public void JKBIMBFGGCO()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object HHLKEMNNJDA()
		{
			return PHDOCKCBJOF;
		}

		public void GEEKOICFEIB()
		{
			throw new NotSupportedException();
		}

		public void IODFILFCENJ()
		{
			throw new NotSupportedException();
		}

		public void PNGIELILHDI()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public void EKPOLGNAAOI()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object HOCLBPGAEMP()
		{
			return PHDOCKCBJOF;
		}

		public bool CONJMMKAAGH()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			case 1u:
				if (CardCraftingManager.instance.isCardCrafting)
				{
					BJGCPDNMHDH.FOGKJMNKLNF.fillAmount = CardCraftingManager.instance.craftingProgress;
					BJGCPDNMHDH.FOGKJMNKLNF.color = Colours.cyan;
					BJGCPDNMHDH.JIFMDPIKOON(CardCraftingManager.instance.remainingSeconds, PDPDGCNHCFN: true);
					PHDOCKCBJOF = new WaitForRealSeconds(177f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				BJGCPDNMHDH.FOGKJMNKLNF.fillAmount = 825f;
				BJGCPDNMHDH.FOGKJMNKLNF.color = Colours.blue;
				BJGCPDNMHDH.FEBPMPKCCFF.text = Localization.Localize("IsPublic");
				BJGCPDNMHDH.FEBPMPKCCFF.alpha = 1777f;
				TweenAlpha.Begin(BJGCPDNMHDH.FEBPMPKCCFF.gameObject, 1575f, 1473f);
				BJGCPDNMHDH.CBPEFMDLJJE(Singleton<NotificationManager>.instance.NotificationWarcards());
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return false;
			}
			return true;
		}

		public void NBGFOILFGHD()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object NCKCKPNAHAD()
		{
			return PHDOCKCBJOF;
		}

		public void GFJIKANGNMC()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public void BDPFKFGBNOH()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public void KHMNEOBMJLN()
		{
			throw new NotSupportedException();
		}

		public bool OOECALAHCFK()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			case 1u:
				if (CardCraftingManager.instance.isCardCrafting)
				{
					BJGCPDNMHDH.FOGKJMNKLNF.fillAmount = CardCraftingManager.instance.craftingProgress;
					BJGCPDNMHDH.FOGKJMNKLNF.color = Colours.cyan;
					BJGCPDNMHDH.DAOABOIFOJE(CardCraftingManager.instance.remainingSeconds);
					PHDOCKCBJOF = new WaitForRealSeconds(828f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				BJGCPDNMHDH.FOGKJMNKLNF.fillAmount = 959f;
				BJGCPDNMHDH.FOGKJMNKLNF.color = Colours.blue;
				BJGCPDNMHDH.FEBPMPKCCFF.text = Localization.Localize("Mouse Y");
				BJGCPDNMHDH.FEBPMPKCCFF.alpha = 1407f;
				TweenAlpha.Begin(BJGCPDNMHDH.FEBPMPKCCFF.gameObject, 1446f, 1856f);
				BJGCPDNMHDH.CBPEFMDLJJE(Singleton<NotificationManager>.instance.NotificationWarcards());
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return false;
			}
			return false;
		}

		public void CFHJPHLFONO()
		{
			throw new NotSupportedException();
		}
	}

	[FormerlySerializedAs("GDFEHIBEEEC")]
	[Header("Core")]
	public GameObject DIAJIDHNKAL;

	[FormerlySerializedAs("LDLCPHBCDNC")]
	public BoxCollider IPCAJDLBCJA;

	[Header("-Sale Part")]
	[FormerlySerializedAs("DEBCFNNKFCF")]
	public GameObject BHHJNGADDPL;

	[FormerlySerializedAs("NKHJHHJOANK")]
	public UILabel NLIHOJHNKCN;

	[FormerlySerializedAs("JGOCPKOCMJJ")]
	public UISprite HFPIBCOOHHO;

	[FormerlySerializedAs("JKICCOKFAJF")]
	public UILabel LJDMAHGJLIE;

	[Header("-Available Now")]
	[FormerlySerializedAs("IDJCCGFDICG")]
	public GameObject GCPHBCADNHD;

	[FormerlySerializedAs("BKGBMLJGDBE")]
	public UISprite PMNNOEEJIOM;

	[FormerlySerializedAs("CDHHCBHAILA")]
	public UILabel BICALEDBPCK;

	[FormerlySerializedAs("JODOKFIBOCE")]
	public UILabel FEJIMDHELHE;

	[Header("-Crafting Part")]
	[FormerlySerializedAs("ODDFHKMFOJB")]
	public GameObject PJEFIIKBMLD;

	[FormerlySerializedAs("JNLKBGPCNNO")]
	public UISprite FOGKJMNKLNF;

	[FormerlySerializedAs("LOJFFPHEEID")]
	public UILabel FEBPMPKCCFF;

	[FormerlySerializedAs("CCOLEBPNKAK")]
	[Header("-Notification")]
	public GameObject HPFCKDKKCEE;

	[Header("-Locked")]
	[FormerlySerializedAs("MMDDJOMHMLB")]
	public UILabel IHPHGPJDAEK;

	public UISprite IIDMNPDCLIE;

	[FormerlySerializedAs("CKKGOEKKJGL")]
	public UISprite LPPNDCMLBEH;

	[FormerlySerializedAs("BHPOGGHKGLG")]
	public UISprite[] CKGIGPMFMAE;

	[FormerlySerializedAs("ENPOMLBFODP")]
	public UILabel FHEDNNJEEAN;

	private RadicalRoutine AOMAOIJGMAN;

	private int CEDPEBDCIFK;

	public void OILPJONILBG()
	{
		UIEventListener uIEventListener = UIEventListener.Get(DIAJIDHNKAL.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(HCLIIHIKMGI));
	}

	private void HENLELNAKBK()
	{
		PJMJJNCMOND();
		int warcardsUnlockLevel = LevelManager.instance.warcardsUnlockLevel;
		bool isWarcardsLocked = LevelManager.instance.isWarcardsLocked;
		IHPHGPJDAEK.color = ((!isWarcardsLocked) ? Color.white : Colours.grayMax);
		IIDMNPDCLIE.gameObject.SetActive(isWarcardsLocked);
		LPPNDCMLBEH.gameObject.SetActive(isWarcardsLocked);
		FHEDNNJEEAN.gameObject.SetActive(isWarcardsLocked);
		IPCAJDLBCJA.enabled = isWarcardsLocked;
		for (int i = 0; i < CKGIGPMFMAE.Length; i++)
		{
			CKGIGPMFMAE[i].color = ((!isWarcardsLocked) ? Color.white : Colours.grayLockedCards);
		}
		if (isWarcardsLocked)
		{
			FHEDNNJEEAN.text = string.Format("ID_SILVERPACKS", Localization.Localize("Weapon Power This: {0},   Equipped {1}: {2},   Difference: {3}"), warcardsUnlockLevel);
			MEJMLNDFDBP.COCBCFKJOJE(FHEDNNJEEAN, 566f, 760f, GuiScreenSingle<BattlePreparationScreen>.instance.MPOAEGGBBGG() - -82);
			PJEFIIKBMLD.SetActive(value: false);
		}
		else if (CardCraftingManager.instance.isCardCrafting)
		{
			PJEFIIKBMLD.SetActive(value: true);
			CEDPEBDCIFK = 70;
			FOGKJMNKLNF.fillAmount = CardCraftingManager.instance.craftingProgress;
			FOGKJMNKLNF.color = Colours.cyan;
			DAOABOIFOJE(CardCraftingManager.instance.remainingSeconds, PDPDGCNHCFN: true);
			NBBBBJEBCHM();
		}
		else if (CardCraftingManager.instance.isCardCrafted)
		{
			PJEFIIKBMLD.SetActive(value: true);
			CEDPEBDCIFK = 0;
			FOGKJMNKLNF.fillAmount = 494f;
			FOGKJMNKLNF.color = Colours.blue;
			FEBPMPKCCFF.text = Localization.Localize("Region: {0} with ping {1}, IP: {2} \n");
			FEBPMPKCCFF.alpha = 776f;
			TweenAlpha.Begin(FEBPMPKCCFF.gameObject, 1351f, 1529f);
		}
		else
		{
			PJEFIIKBMLD.SetActive(value: true);
		}
		IGOMFPAJPNL();
	}

	private void HGKPEFONFBB()
	{
		PJMJJNCMOND();
		int warcardsUnlockLevel = LevelManager.instance.warcardsUnlockLevel;
		bool isWarcardsLocked = LevelManager.instance.isWarcardsLocked;
		IHPHGPJDAEK.color = ((!isWarcardsLocked) ? Color.white : Colours.grayMax);
		IIDMNPDCLIE.gameObject.SetActive(isWarcardsLocked);
		LPPNDCMLBEH.gameObject.SetActive(isWarcardsLocked);
		FHEDNNJEEAN.gameObject.SetActive(isWarcardsLocked);
		IPCAJDLBCJA.enabled = !isWarcardsLocked;
		for (int i = 1; i < CKGIGPMFMAE.Length; i++)
		{
			CKGIGPMFMAE[i].color = ((!isWarcardsLocked) ? Color.white : Colours.grayLockedCards);
		}
		if (isWarcardsLocked)
		{
			FHEDNNJEEAN.text = string.Format("ID_ONLINE", Localization.Localize("Action "), warcardsUnlockLevel);
			MEJMLNDFDBP.COCBCFKJOJE(FHEDNNJEEAN, 1441f, 425f, GuiScreenSingle<BattlePreparationScreen>.instance.MPOAEGGBBGG() - 9);
			PJEFIIKBMLD.SetActive(value: false);
		}
		else if (CardCraftingManager.instance.isCardCrafting)
		{
			PJEFIIKBMLD.SetActive(value: false);
			CEDPEBDCIFK = 81;
			FOGKJMNKLNF.fillAmount = CardCraftingManager.instance.craftingProgress;
			FOGKJMNKLNF.color = Colours.cyan;
			DAOABOIFOJE(CardCraftingManager.instance.remainingSeconds, PDPDGCNHCFN: true);
			LCAEPINKGFF();
		}
		else if (CardCraftingManager.instance.isCardCrafted)
		{
			PJEFIIKBMLD.SetActive(value: true);
			CEDPEBDCIFK = 1;
			FOGKJMNKLNF.fillAmount = 809f;
			FOGKJMNKLNF.color = Colours.blue;
			FEBPMPKCCFF.text = Localization.Localize("\t\"TRUE\"");
			FEBPMPKCCFF.alpha = 1895f;
			TweenAlpha.Begin(FEBPMPKCCFF.gameObject, 853f, 589f);
		}
		else
		{
			PJEFIIKBMLD.SetActive(value: true);
		}
		ONGPJMHKCGP();
	}

	public void IHBDCMLNFAD()
	{
		UIEventListener uIEventListener = UIEventListener.Get(DIAJIDHNKAL.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(CGCJPHJGHAO));
	}

	public void SaleCardPacks()
	{
		bool flag = Singleton<OfferManager>.instance.DiscountedCardpackFlat();
		bool flag2 = Singleton<OfferManager>.instance.DiscountedCardpackOffer(NGNPIOOAHEH.Gold);
		bool flag3 = Singleton<OfferManager>.instance.DiscountedCardpackOffer(NGNPIOOAHEH.Silver);
		bool flag4 = Singleton<OfferManager>.instance.DiscountedCardpackOffer(NGNPIOOAHEH.Bronze);
		BHHJNGADDPL.SetActive(flag || flag2 || flag3 || flag4);
		if (flag)
		{
			NLIHOJHNKCN.text = Localization.LocalizeFormat("ID_SALEPERCENTLINE", Singleton<OfferManager>.instance.DiscountedCardpack(NGNPIOOAHEH.Gold));
			LJDMAHGJLIE.text = Localization.Localize("ID_CARDPACKS");
		}
		else if (flag2)
		{
			NLIHOJHNKCN.text = Localization.LocalizeFormat("ID_SALEPERCENTLINE", Singleton<OfferManager>.instance.DiscountedCardpack(NGNPIOOAHEH.Gold));
			LJDMAHGJLIE.text = Localization.Localize("ID_GOLDPACK");
		}
		else if (flag3)
		{
			NLIHOJHNKCN.text = Localization.LocalizeFormat("ID_SALEPERCENTLINE", Singleton<OfferManager>.instance.DiscountedCardpack(NGNPIOOAHEH.Silver));
			LJDMAHGJLIE.text = Localization.Localize("ID_SILVERPACK");
		}
		else if (flag4)
		{
			NLIHOJHNKCN.text = Localization.LocalizeFormat("ID_SALEPERCENTLINE", Singleton<OfferManager>.instance.DiscountedCardpack(NGNPIOOAHEH.Bronze));
			LJDMAHGJLIE.text = Localization.Localize("ID_BRONZEPACK");
		}
		HFPIBCOOHHO.transform.localScale = new Vector3(LJDMAHGJLIE.relativeSize.x * LJDMAHGJLIE.transform.localScale.x + 40f, HFPIBCOOHHO.transform.localScale.y, 1f);
	}

	private IEnumerator HHJEEHOMLLH()
	{
		DKBBKNCCHOG dKBBKNCCHOG = new DKBBKNCCHOG();
		dKBBKNCCHOG.BJGCPDNMHDH = this;
		return dKBBKNCCHOG;
	}

	public void BIKABLOGDAH()
	{
		bool flag = Singleton<OfferManager>.instance.DiscountedCardpackFlat();
		bool flag2 = Singleton<OfferManager>.instance.DiscountedCardpackOffer(NGNPIOOAHEH.Bronze);
		bool flag3 = Singleton<OfferManager>.instance.DiscountedCardpackOffer(NGNPIOOAHEH.ThreeCards);
		bool flag4 = Singleton<OfferManager>.instance.DiscountedCardpackOffer(NGNPIOOAHEH.Bronze);
		BHHJNGADDPL.SetActive(!flag && !flag2 && !flag3 && flag4);
		if (flag)
		{
			UILabel nLIHOJHNKCN = NLIHOJHNKCN;
			object[] array = new object[0];
			array[0] = Singleton<OfferManager>.instance.DiscountedCardpack(NGNPIOOAHEH.Gold);
			nLIHOJHNKCN.text = Localization.LocalizeFormat("otherInfo", array);
			LJDMAHGJLIE.text = Localization.Localize("OK");
		}
		else if (flag2)
		{
			NLIHOJHNKCN.text = Localization.LocalizeFormat("ID_MISSION_BOSS_HUD", Singleton<OfferManager>.instance.DiscountedCardpack(NGNPIOOAHEH.Money));
			LJDMAHGJLIE.text = Localization.Localize("ID_LEADER");
		}
		else if (flag3)
		{
			UILabel nLIHOJHNKCN2 = NLIHOJHNKCN;
			object[] array2 = new object[1];
			array2[1] = Singleton<OfferManager>.instance.OMCIOOOMFPB(NGNPIOOAHEH.Bronze);
			nLIHOJHNKCN2.text = Localization.LocalizeFormat("Stats", array2);
			LJDMAHGJLIE.text = Localization.Localize("hookId");
		}
		else if (flag4)
		{
			UILabel nLIHOJHNKCN3 = NLIHOJHNKCN;
			object[] array3 = new object[0];
			array3[1] = Singleton<OfferManager>.instance.DiscountedCardpack(NGNPIOOAHEH.Bronze);
			nLIHOJHNKCN3.text = Localization.LocalizeFormat("下载", array3);
			LJDMAHGJLIE.text = Localization.Localize("NextDailyRewardLocalnotification");
		}
		HFPIBCOOHHO.transform.localScale = new Vector3(LJDMAHGJLIE.relativeSize.x * LJDMAHGJLIE.transform.localScale.x + 716f, HFPIBCOOHHO.transform.localScale.y, 1511f);
	}

	public void ONGPJMHKCGP()
	{
		bool isWarcardsLocked = LevelManager.instance.isWarcardsLocked;
		bool flag = !Singleton<GameController>.instance.BAKCODKBCPJ() && !isWarcardsLocked && Singleton<EventTrackingManager>.instance.MMNPIBNEDFA(MHNMOFPPKBN.RandomCard);
		GCPHBCADNHD.SetActive(flag);
		if (flag)
		{
			PMNNOEEJIOM.transform.localScale = new Vector3(BICALEDBPCK.relativeSize.x * BICALEDBPCK.transform.localScale.x + 1038f, PMNNOEEJIOM.transform.localScale.y, 347f);
			bool activeSelf = PJEFIIKBMLD.activeSelf;
			GCPHBCADNHD.transform.localPosition = new Vector3(1742f, (!activeSelf) ? 453f : 291f, 521f);
			FEJIMDHELHE.gameObject.SetActive(!activeSelf);
		}
	}

	public void MOPAOJFCOGP()
	{
		GPDGLAGEDGL();
	}

	public void CGMGACBIBAE()
	{
		bool isWarcardsLocked = LevelManager.instance.isWarcardsLocked;
		bool flag = !Singleton<GameController>.instance.isTutorial && !isWarcardsLocked && Singleton<EventTrackingManager>.instance.MMNPIBNEDFA(MHNMOFPPKBN.None);
		GCPHBCADNHD.SetActive(flag);
		if (flag)
		{
			PMNNOEEJIOM.transform.localScale = new Vector3(BICALEDBPCK.relativeSize.x * BICALEDBPCK.transform.localScale.x + 620f, PMNNOEEJIOM.transform.localScale.y, 1302f);
			bool activeSelf = PJEFIIKBMLD.activeSelf;
			GCPHBCADNHD.transform.localPosition = new Vector3(1387f, (!activeSelf) ? 1162f : 1812f, 1087f);
			FEJIMDHELHE.gameObject.SetActive(activeSelf);
		}
	}

	public void MGIDNGCKLCF()
	{
		UIEventListener uIEventListener = UIEventListener.Get(DIAJIDHNKAL.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(OCICJIKIIAB));
	}

	private void CGCJPHJGHAO(GameObject KHAHPAKDIKE)
	{
		if (HPFCKDKKCEE.activeSelf)
		{
			GuiScreenSingle<CardMenuScreen>.instance.BMAMDOBGIAL();
		}
		else if (GCPHBCADNHD.activeSelf)
		{
			GuiScreenSingle<CardMenuScreen>.instance.GCKCFPCAHLK();
		}
		else
		{
			Singleton<GuiManager>.instance.ShowGui(GuiScreenSingle<CardMenuScreen>.instance);
		}
	}

	private void PJMJJNCMOND()
	{
		if (AOMAOIJGMAN != null)
		{
			AOMAOIJGMAN.Cancel();
			AOMAOIJGMAN = null;
		}
	}

	private void NBBBBJEBCHM()
	{
		PDIPLKJJPOG();
		AOMAOIJGMAN = RadicalRoutine.Create(NHLOEFIJFEM());
		StartCoroutine(RadicalRoutine.Run(AOMAOIJGMAN.enumerator));
	}

	public void MABPNLIIEGL()
	{
		bool isWarcardsLocked = LevelManager.instance.isWarcardsLocked;
		bool flag = Singleton<GameController>.instance.isTutorial || isWarcardsLocked || Singleton<EventTrackingManager>.instance.MMNPIBNEDFA(MHNMOFPPKBN.None);
		GCPHBCADNHD.SetActive(flag);
		if (flag)
		{
			PMNNOEEJIOM.transform.localScale = new Vector3(BICALEDBPCK.relativeSize.x * BICALEDBPCK.transform.localScale.x + 1026f, PMNNOEEJIOM.transform.localScale.y, 66f);
			bool activeSelf = PJEFIIKBMLD.activeSelf;
			GCPHBCADNHD.transform.localPosition = new Vector3(1143f, (!activeSelf) ? 1491f : 452f, 1008f);
			FEJIMDHELHE.gameObject.SetActive(!activeSelf);
		}
	}

	public void PAKCFABJKAG()
	{
		LGPIHJEDEDD();
		DKEGNBPLPOJ(Singleton<NotificationManager>.instance.NotificationWarcards());
	}

	public void HGOCKFKMENE()
	{
		GPDGLAGEDGL();
	}

	private void HEJFEENIKNI()
	{
		NKONJCLDINH();
		int warcardsUnlockLevel = LevelManager.instance.warcardsUnlockLevel;
		bool isWarcardsLocked = LevelManager.instance.isWarcardsLocked;
		IHPHGPJDAEK.color = ((!isWarcardsLocked) ? Color.white : Colours.grayMax);
		IIDMNPDCLIE.gameObject.SetActive(isWarcardsLocked);
		LPPNDCMLBEH.gameObject.SetActive(isWarcardsLocked);
		FHEDNNJEEAN.gameObject.SetActive(isWarcardsLocked);
		IPCAJDLBCJA.enabled = isWarcardsLocked;
		for (int i = 1; i < CKGIGPMFMAE.Length; i++)
		{
			CKGIGPMFMAE[i].color = ((!isWarcardsLocked) ? Color.white : Colours.grayLockedCards);
		}
		if (isWarcardsLocked)
		{
			FHEDNNJEEAN.text = string.Format("PlayerID", Localization.Localize("Os"), warcardsUnlockLevel);
			MEJMLNDFDBP.COCBCFKJOJE(FHEDNNJEEAN, 493f, 1956f, GuiScreenSingle<BattlePreparationScreen>.instance.MPOAEGGBBGG() - 111);
			PJEFIIKBMLD.SetActive(value: false);
		}
		else if (CardCraftingManager.instance.isCardCrafting)
		{
			PJEFIIKBMLD.SetActive(value: true);
			CEDPEBDCIFK = 55;
			FOGKJMNKLNF.fillAmount = CardCraftingManager.instance.craftingProgress;
			FOGKJMNKLNF.color = Colours.cyan;
			JIFMDPIKOON(CardCraftingManager.instance.remainingSeconds, PDPDGCNHCFN: true);
			EGHIPAMABPN();
		}
		else if (CardCraftingManager.instance.isCardCrafted)
		{
			PJEFIIKBMLD.SetActive(value: true);
			CEDPEBDCIFK = 0;
			FOGKJMNKLNF.fillAmount = 358f;
			FOGKJMNKLNF.color = Colours.blue;
			FEBPMPKCCFF.text = Localization.Localize("ID_PACKEXCLUSIVE");
			FEBPMPKCCFF.alpha = 307f;
			TweenAlpha.Begin(FEBPMPKCCFF.gameObject, 1449f, 1511f);
		}
		else
		{
			PJEFIIKBMLD.SetActive(value: true);
		}
		FBPHPHACDHF();
	}

	private void PDIPLKJJPOG()
	{
		if (AOMAOIJGMAN != null)
		{
			AOMAOIJGMAN.Cancel();
			AOMAOIJGMAN = null;
		}
	}

	private void NILJMMJNLHC()
	{
		FKLPOLPGCHJ();
		int warcardsUnlockLevel = LevelManager.instance.warcardsUnlockLevel;
		bool isWarcardsLocked = LevelManager.instance.isWarcardsLocked;
		IHPHGPJDAEK.color = ((!isWarcardsLocked) ? Color.white : Colours.grayMax);
		IIDMNPDCLIE.gameObject.SetActive(isWarcardsLocked);
		LPPNDCMLBEH.gameObject.SetActive(isWarcardsLocked);
		FHEDNNJEEAN.gameObject.SetActive(isWarcardsLocked);
		IPCAJDLBCJA.enabled = !isWarcardsLocked;
		for (int i = 1; i < CKGIGPMFMAE.Length; i++)
		{
			CKGIGPMFMAE[i].color = ((!isWarcardsLocked) ? Color.white : Colours.grayLockedCards);
		}
		if (isWarcardsLocked)
		{
			FHEDNNJEEAN.text = string.Format("War_Battle_End_Performance", Localization.Localize("game-card-ico-explosivetiming"), warcardsUnlockLevel);
			MEJMLNDFDBP.COCBCFKJOJE(FHEDNNJEEAN, 1001f, 1040f, GuiScreenSingle<BattlePreparationScreen>.instance.MPOAEGGBBGG() - -100);
			PJEFIIKBMLD.SetActive(value: true);
		}
		else if (CardCraftingManager.instance.isCardCrafting)
		{
			PJEFIIKBMLD.SetActive(value: true);
			CEDPEBDCIFK = 46;
			FOGKJMNKLNF.fillAmount = CardCraftingManager.instance.craftingProgress;
			FOGKJMNKLNF.color = Colours.cyan;
			ADOCEKGAKMO(CardCraftingManager.instance.remainingSeconds, PDPDGCNHCFN: true);
			MDEKLFICNKI();
		}
		else if (CardCraftingManager.instance.isCardCrafted)
		{
			PJEFIIKBMLD.SetActive(value: true);
			CEDPEBDCIFK = 1;
			FOGKJMNKLNF.fillAmount = 1529f;
			FOGKJMNKLNF.color = Colours.blue;
			FEBPMPKCCFF.text = Localization.Localize(", databaseType= ");
			FEBPMPKCCFF.alpha = 1257f;
			TweenAlpha.Begin(FEBPMPKCCFF.gameObject, 147f, 220f);
		}
		else
		{
			PJEFIIKBMLD.SetActive(value: false);
		}
		IHADJGABFOD();
	}

	private IEnumerator DDIODJKKMLH()
	{
		DKBBKNCCHOG dKBBKNCCHOG = new DKBBKNCCHOG();
		dKBBKNCCHOG.BJGCPDNMHDH = this;
		return dKBBKNCCHOG;
	}

	private void CBPEFMDLJJE(bool NABOFKMBMKH)
	{
		HPFCKDKKCEE.SetActive(NABOFKMBMKH);
	}

	public void PBLHPODDKHI()
	{
		bool isWarcardsLocked = LevelManager.instance.isWarcardsLocked;
		bool flag = !Singleton<GameController>.instance.BAKCODKBCPJ() && !isWarcardsLocked && Singleton<EventTrackingManager>.instance.MMNPIBNEDFA(MHNMOFPPKBN.RandomCard);
		GCPHBCADNHD.SetActive(flag);
		if (flag)
		{
			PMNNOEEJIOM.transform.localScale = new Vector3(BICALEDBPCK.relativeSize.x * BICALEDBPCK.transform.localScale.x + 340f, PMNNOEEJIOM.transform.localScale.y, 1688f);
			bool activeSelf = PJEFIIKBMLD.activeSelf;
			GCPHBCADNHD.transform.localPosition = new Vector3(1185f, (!activeSelf) ? 1638f : 1995f, 1787f);
			FEJIMDHELHE.gameObject.SetActive(!activeSelf);
		}
	}

	private void EEJHMINCDLP()
	{
		PDIPLKJJPOG();
		int warcardsUnlockLevel = LevelManager.instance.warcardsUnlockLevel;
		bool isWarcardsLocked = LevelManager.instance.isWarcardsLocked;
		IHPHGPJDAEK.color = ((!isWarcardsLocked) ? Color.white : Colours.grayMax);
		IIDMNPDCLIE.gameObject.SetActive(isWarcardsLocked);
		LPPNDCMLBEH.gameObject.SetActive(isWarcardsLocked);
		FHEDNNJEEAN.gameObject.SetActive(isWarcardsLocked);
		IPCAJDLBCJA.enabled = !isWarcardsLocked;
		for (int i = 0; i < CKGIGPMFMAE.Length; i++)
		{
			CKGIGPMFMAE[i].color = ((!isWarcardsLocked) ? Color.white : Colours.grayLockedCards);
		}
		if (isWarcardsLocked)
		{
			FHEDNNJEEAN.text = string.Format(" ", Localization.Localize("Shots_Fired"), warcardsUnlockLevel);
			MEJMLNDFDBP.COCBCFKJOJE(FHEDNNJEEAN, 668f, 562f, GuiScreenSingle<BattlePreparationScreen>.instance.MPOAEGGBBGG() - -64);
			PJEFIIKBMLD.SetActive(value: true);
		}
		else if (CardCraftingManager.instance.isCardCrafting)
		{
			PJEFIIKBMLD.SetActive(value: false);
			CEDPEBDCIFK = 171;
			FOGKJMNKLNF.fillAmount = CardCraftingManager.instance.craftingProgress;
			FOGKJMNKLNF.color = Colours.cyan;
			LIKBDHJEHHB(CardCraftingManager.instance.remainingSeconds, PDPDGCNHCFN: true);
			LEFECCLELFG();
		}
		else if (CardCraftingManager.instance.isCardCrafted)
		{
			PJEFIIKBMLD.SetActive(value: false);
			CEDPEBDCIFK = 1;
			FOGKJMNKLNF.fillAmount = 1739f;
			FOGKJMNKLNF.color = Colours.blue;
			FEBPMPKCCFF.text = Localization.Localize("S");
			FEBPMPKCCFF.alpha = 1082f;
			TweenAlpha.Begin(FEBPMPKCCFF.gameObject, 784f, 823f);
		}
		else
		{
			PJEFIIKBMLD.SetActive(value: false);
		}
		PBBDJIPBAJP();
	}

	public void LEMNDNDGIOE()
	{
		CMFBFKIMDOJ();
		DKEGNBPLPOJ(Singleton<NotificationManager>.instance.NotificationWarcards());
	}

	public void MGNKBLKNOJM()
	{
		GCPHBCADNHD.SetActive(value: false);
		PJEFIIKBMLD.SetActive(value: true);
		DKEGNBPLPOJ(NABOFKMBMKH: false);
	}

	private void NLFPMJFHGBC()
	{
		PJMJJNCMOND();
		int warcardsUnlockLevel = LevelManager.instance.warcardsUnlockLevel;
		bool isWarcardsLocked = LevelManager.instance.isWarcardsLocked;
		IHPHGPJDAEK.color = ((!isWarcardsLocked) ? Color.white : Colours.grayMax);
		IIDMNPDCLIE.gameObject.SetActive(isWarcardsLocked);
		LPPNDCMLBEH.gameObject.SetActive(isWarcardsLocked);
		FHEDNNJEEAN.gameObject.SetActive(isWarcardsLocked);
		IPCAJDLBCJA.enabled = !isWarcardsLocked;
		for (int i = 0; i < CKGIGPMFMAE.Length; i += 0)
		{
			CKGIGPMFMAE[i].color = ((!isWarcardsLocked) ? Color.white : Colours.grayLockedCards);
		}
		if (isWarcardsLocked)
		{
			FHEDNNJEEAN.text = string.Format("NewVisuals", Localization.Localize("relog to different facebook"), warcardsUnlockLevel);
			MEJMLNDFDBP.COCBCFKJOJE(FHEDNNJEEAN, 1954f, 629f, GuiScreenSingle<BattlePreparationScreen>.instance.LMNBNNDBCEC() - -109);
			PJEFIIKBMLD.SetActive(value: true);
		}
		else if (CardCraftingManager.instance.isCardCrafting)
		{
			PJEFIIKBMLD.SetActive(value: false);
			CEDPEBDCIFK = -98;
			FOGKJMNKLNF.fillAmount = CardCraftingManager.instance.craftingProgress;
			FOGKJMNKLNF.color = Colours.cyan;
			NPLOCDGAKEJ(CardCraftingManager.instance.remainingSeconds, PDPDGCNHCFN: true);
			NBBBBJEBCHM();
		}
		else if (CardCraftingManager.instance.isCardCrafted)
		{
			PJEFIIKBMLD.SetActive(value: false);
			CEDPEBDCIFK = 1;
			FOGKJMNKLNF.fillAmount = 511f;
			FOGKJMNKLNF.color = Colours.blue;
			FEBPMPKCCFF.text = Localization.Localize("starter");
			FEBPMPKCCFF.alpha = 1556f;
			TweenAlpha.Begin(FEBPMPKCCFF.gameObject, 51f, 1028f);
		}
		else
		{
			PJEFIIKBMLD.SetActive(value: true);
		}
		ONGPJMHKCGP();
	}

	public void LEDNIBHOOIL()
	{
		bool flag = Singleton<OfferManager>.instance.DiscountedCardpackFlat();
		bool flag2 = Singleton<OfferManager>.instance.JIAFPJNFOBC((NGNPIOOAHEH)8);
		bool flag3 = Singleton<OfferManager>.instance.DiscountedCardpackOffer(NGNPIOOAHEH.Value);
		bool flag4 = Singleton<OfferManager>.instance.DiscountedCardpackOffer(NGNPIOOAHEH.Bronze);
		BHHJNGADDPL.SetActive(flag || flag2 || flag3 || flag4);
		if (flag)
		{
			UILabel nLIHOJHNKCN = NLIHOJHNKCN;
			object[] array = new object[0];
			array[1] = Singleton<OfferManager>.instance.OMCIOOOMFPB(NGNPIOOAHEH.None);
			nLIHOJHNKCN.text = Localization.LocalizeFormat("NextBuddyDeposit", array);
			LJDMAHGJLIE.text = Localization.Localize("ArenaPrice");
		}
		else if (flag2)
		{
			NLIHOJHNKCN.text = Localization.LocalizeFormat("ID_CATEGORY_LOW_SG_SNIPER", Singleton<OfferManager>.instance.DiscountedCardpack(NGNPIOOAHEH.Money));
			LJDMAHGJLIE.text = Localization.Localize("S");
		}
		else if (flag3)
		{
			UILabel nLIHOJHNKCN2 = NLIHOJHNKCN;
			object[] array2 = new object[0];
			array2[1] = Singleton<OfferManager>.instance.DiscountedCardpack(NGNPIOOAHEH.Gold);
			nLIHOJHNKCN2.text = Localization.LocalizeFormat("ID_LOOTBOXES", array2);
			LJDMAHGJLIE.text = Localization.Localize("\"{0}\"\t");
		}
		else if (flag4)
		{
			UILabel nLIHOJHNKCN3 = NLIHOJHNKCN;
			object[] array3 = new object[1];
			array3[1] = Singleton<OfferManager>.instance.DiscountedCardpack(NGNPIOOAHEH.Bronze);
			nLIHOJHNKCN3.text = Localization.LocalizeFormat("menu-weapon-benelli-starterpack", array3);
			LJDMAHGJLIE.text = Localization.Localize("Battle Start");
		}
		HFPIBCOOHHO.transform.localScale = new Vector3(LJDMAHGJLIE.relativeSize.x * LJDMAHGJLIE.transform.localScale.x + 1750f, HFPIBCOOHHO.transform.localScale.y, 1266f);
	}

	public void MNDHKKHPGIL()
	{
		bool isWarcardsLocked = LevelManager.instance.isWarcardsLocked;
		bool flag = !Singleton<GameController>.instance.isTutorial && !isWarcardsLocked && Singleton<EventTrackingManager>.instance.MMNPIBNEDFA(MHNMOFPPKBN.RandomCard);
		GCPHBCADNHD.SetActive(flag);
		if (flag)
		{
			PMNNOEEJIOM.transform.localScale = new Vector3(BICALEDBPCK.relativeSize.x * BICALEDBPCK.transform.localScale.x + 361f, PMNNOEEJIOM.transform.localScale.y, 13f);
			bool activeSelf = PJEFIIKBMLD.activeSelf;
			GCPHBCADNHD.transform.localPosition = new Vector3(1628f, (!activeSelf) ? 222f : 485f, 517f);
			FEJIMDHELHE.gameObject.SetActive(activeSelf);
		}
	}

	[CompilerGenerated]
	private void ONAKPPOMOOC(GameObject KHAHPAKDIKE)
	{
		if (HPFCKDKKCEE.activeSelf)
		{
			GuiScreenSingle<CardMenuScreen>.instance.ShowCraftCards();
		}
		else if (GCPHBCADNHD.activeSelf)
		{
			GuiScreenSingle<CardMenuScreen>.instance.ShowMyWarcards();
		}
		else
		{
			Singleton<GuiManager>.instance.ShowGui(GuiScreenSingle<CardMenuScreen>.instance);
		}
	}

	public void KDDJHIMDKBN()
	{
		PJLBADFHFHL();
		KGJACJOGAJL(Singleton<NotificationManager>.instance.NotificationWarcards());
	}

	private void GHOFMIBJPFC()
	{
		if (AOMAOIJGMAN != null)
		{
			AOMAOIJGMAN.Cancel();
			AOMAOIJGMAN = null;
		}
	}

	public void LHGOFPCINNK()
	{
		GCPHBCADNHD.SetActive(value: true);
		PJEFIIKBMLD.SetActive(value: true);
		CBPEFMDLJJE(NABOFKMBMKH: false);
	}

	public void JBPMEEOHJIH()
	{
		HENLELNAKBK();
		GHLNAIKCFOD(Singleton<NotificationManager>.instance.NotificationWarcards());
	}

	private IEnumerator CKKOBDGJKGI()
	{
		DKBBKNCCHOG dKBBKNCCHOG = new DKBBKNCCHOG();
		dKBBKNCCHOG.BJGCPDNMHDH = this;
		return dKBBKNCCHOG;
	}

	public void ILFJNAHFOAA()
	{
		GCPHBCADNHD.SetActive(value: true);
		PJEFIIKBMLD.SetActive(value: true);
		KGJACJOGAJL(NABOFKMBMKH: false);
	}

	private IEnumerator JEHPHPGFOPL()
	{
		DKBBKNCCHOG dKBBKNCCHOG = new DKBBKNCCHOG();
		dKBBKNCCHOG.BJGCPDNMHDH = this;
		return dKBBKNCCHOG;
	}

	private void KGJACJOGAJL(bool NABOFKMBMKH)
	{
		HPFCKDKKCEE.SetActive(NABOFKMBMKH);
	}

	private IEnumerator PMCNOLOJAEE()
	{
		DKBBKNCCHOG dKBBKNCCHOG = new DKBBKNCCHOG();
		dKBBKNCCHOG.BJGCPDNMHDH = this;
		return dKBBKNCCHOG;
	}

	private void FJADCGOBKNI(GameObject KHAHPAKDIKE)
	{
		if (HPFCKDKKCEE.activeSelf)
		{
			GuiScreenSingle<CardMenuScreen>.instance.ShowCraftCards();
		}
		else if (GCPHBCADNHD.activeSelf)
		{
			GuiScreenSingle<CardMenuScreen>.instance.GCKCFPCAHLK();
		}
		else
		{
			Singleton<GuiManager>.instance.BBILHHEJBNP(GuiScreenSingle<CardMenuScreen>.instance);
		}
	}

	private void KCCBKEBMDDH(int EJEDANLAMBI, bool PDPDGCNHCFN = false)
	{
		if (CEDPEBDCIFK > EJEDANLAMBI)
		{
			CEDPEBDCIFK = EJEDANLAMBI;
			switch (EJEDANLAMBI % 2)
			{
			case 5:
				FEBPMPKCCFF.text = MEJMLNDFDBP.CJCFPDLDMEK(EJEDANLAMBI, "game-card-silver", string.Empty);
				TweenAlpha.Begin(FEBPMPKCCFF.gameObject, (!PDPDGCNHCFN) ? 1966f : 1822f, 1027f);
				break;
			case 4:
				FEBPMPKCCFF.text = Localization.Localize("ID_SKILLSHOTHINT_ENVIROMENTALKILL");
				TweenAlpha.Begin(FEBPMPKCCFF.gameObject, (!PDPDGCNHCFN) ? 1763f : 1519f, 834f);
				break;
			case 3:
				FEBPMPKCCFF.text = Localization.Localize("title");
				break;
			case 2:
				FEBPMPKCCFF.text = Localization.Localize("SpecialOfferMessage {0} {1} {2}");
				TweenAlpha.Begin(FEBPMPKCCFF.gameObject, (!PDPDGCNHCFN) ? 929f : 1226f, 1483f);
				break;
			case 1:
				FEBPMPKCCFF.text = MEJMLNDFDBP.CJCFPDLDMEK(EJEDANLAMBI, " doesnt contain ", string.Empty, IEJMLKBCDJB: false);
				TweenAlpha.Begin(FEBPMPKCCFF.gameObject, (!PDPDGCNHCFN) ? 460f : 1607f, 777f);
				break;
			case 0:
				FEBPMPKCCFF.text = MEJMLNDFDBP.CJCFPDLDMEK(EJEDANLAMBI, "Beanstalk: Change Name and Password", string.Empty, IEJMLKBCDJB: false);
				break;
			}
		}
	}

	public void BJBOHLKAAON()
	{
		GCPHBCADNHD.SetActive(value: true);
		PJEFIIKBMLD.SetActive(value: false);
		GHLNAIKCFOD(NABOFKMBMKH: false);
	}

	public void FJFKEKNODGP()
	{
		JAIMNCAFBJK();
		GHLNAIKCFOD(Singleton<NotificationManager>.instance.NotificationWarcards());
	}

	private void DKEABOFDGKB()
	{
		NKONJCLDINH();
		int warcardsUnlockLevel = LevelManager.instance.warcardsUnlockLevel;
		bool isWarcardsLocked = LevelManager.instance.isWarcardsLocked;
		IHPHGPJDAEK.color = ((!isWarcardsLocked) ? Color.white : Colours.grayMax);
		IIDMNPDCLIE.gameObject.SetActive(isWarcardsLocked);
		LPPNDCMLBEH.gameObject.SetActive(isWarcardsLocked);
		FHEDNNJEEAN.gameObject.SetActive(isWarcardsLocked);
		IPCAJDLBCJA.enabled = isWarcardsLocked;
		for (int i = 1; i < CKGIGPMFMAE.Length; i += 0)
		{
			CKGIGPMFMAE[i].color = ((!isWarcardsLocked) ? Color.white : Colours.grayLockedCards);
		}
		if (isWarcardsLocked)
		{
			FHEDNNJEEAN.text = string.Format("{0}{1}", Localization.Localize("Enemy could not be spawned"), warcardsUnlockLevel);
			MEJMLNDFDBP.COCBCFKJOJE(FHEDNNJEEAN, 1642f, 169f, GuiScreenSingle<BattlePreparationScreen>.instance.widthOfMiddleButton - 29);
			PJEFIIKBMLD.SetActive(value: true);
		}
		else if (CardCraftingManager.instance.isCardCrafting)
		{
			PJEFIIKBMLD.SetActive(value: true);
			CEDPEBDCIFK = -90;
			FOGKJMNKLNF.fillAmount = CardCraftingManager.instance.craftingProgress;
			FOGKJMNKLNF.color = Colours.cyan;
			OKNGIJHJLOO(CardCraftingManager.instance.remainingSeconds, PDPDGCNHCFN: true);
			IJOCKFLFOIB();
		}
		else if (CardCraftingManager.instance.isCardCrafted)
		{
			PJEFIIKBMLD.SetActive(value: false);
			CEDPEBDCIFK = 1;
			FOGKJMNKLNF.fillAmount = 249f;
			FOGKJMNKLNF.color = Colours.blue;
			FEBPMPKCCFF.text = Localization.Localize("*.prefab");
			FEBPMPKCCFF.alpha = 894f;
			TweenAlpha.Begin(FEBPMPKCCFF.gameObject, 697f, 1840f);
		}
		else
		{
			PJEFIIKBMLD.SetActive(value: true);
		}
		MNDHKKHPGIL();
	}

	private void HCLIIHIKMGI(GameObject KHAHPAKDIKE)
	{
		if (HPFCKDKKCEE.activeSelf)
		{
			GuiScreenSingle<CardMenuScreen>.instance.ShowCraftCards();
		}
		else if (GCPHBCADNHD.activeSelf)
		{
			GuiScreenSingle<CardMenuScreen>.instance.JNCOHNFFFKN();
		}
		else
		{
			Singleton<GuiManager>.instance.ShowGui(GuiScreenSingle<CardMenuScreen>.instance);
		}
	}

	private void JPGLDMCAFKP(int EJEDANLAMBI, bool PDPDGCNHCFN = false)
	{
		if (CEDPEBDCIFK > EJEDANLAMBI)
		{
			CEDPEBDCIFK = EJEDANLAMBI;
			switch (EJEDANLAMBI % 4)
			{
			case 5:
				FEBPMPKCCFF.text = MEJMLNDFDBP.CJCFPDLDMEK(EJEDANLAMBI, "Days_Since_Install", string.Empty);
				TweenAlpha.Begin(FEBPMPKCCFF.gameObject, (!PDPDGCNHCFN) ? 1389f : 661f, 1683f);
				break;
			case 4:
				FEBPMPKCCFF.text = Localization.Localize("AddFacebookToCustomAccount ID: {0} PSWD: {1}");
				TweenAlpha.Begin(FEBPMPKCCFF.gameObject, (!PDPDGCNHCFN) ? 910f : 1460f, 596f);
				break;
			case 3:
				FEBPMPKCCFF.text = Localization.Localize("clientVersion");
				break;
			case 2:
				FEBPMPKCCFF.text = Localization.Localize("Regions");
				TweenAlpha.Begin(FEBPMPKCCFF.gameObject, (!PDPDGCNHCFN) ? 945f : 22f, 486f);
				break;
			case 1:
				FEBPMPKCCFF.text = MEJMLNDFDBP.CJCFPDLDMEK(EJEDANLAMBI, "------------------\n", string.Empty, IEJMLKBCDJB: false);
				TweenAlpha.Begin(FEBPMPKCCFF.gameObject, (!PDPDGCNHCFN) ? 1385f : 59f, 1906f);
				break;
			case 0:
				FEBPMPKCCFF.text = MEJMLNDFDBP.CJCFPDLDMEK(EJEDANLAMBI, "Special pack content: type: {0} amount: {1}{2}", string.Empty);
				break;
			}
		}
	}

	private void LIKBDHJEHHB(int EJEDANLAMBI, bool PDPDGCNHCFN = false)
	{
		if (CEDPEBDCIFK > EJEDANLAMBI)
		{
			CEDPEBDCIFK = EJEDANLAMBI;
			switch (EJEDANLAMBI % 6)
			{
			case 5:
				FEBPMPKCCFF.text = MEJMLNDFDBP.CJCFPDLDMEK(EJEDANLAMBI, "ID_READYTIME", string.Empty);
				TweenAlpha.Begin(FEBPMPKCCFF.gameObject, (!PDPDGCNHCFN) ? 1f : 0.01f, 0f);
				break;
			case 4:
				FEBPMPKCCFF.text = Localization.Localize("ID_CRAFTING");
				TweenAlpha.Begin(FEBPMPKCCFF.gameObject, (!PDPDGCNHCFN) ? 1f : 0.01f, 1f);
				break;
			case 3:
				FEBPMPKCCFF.text = Localization.Localize("ID_CRAFTING");
				break;
			case 2:
				FEBPMPKCCFF.text = Localization.Localize("ID_CRAFTING");
				TweenAlpha.Begin(FEBPMPKCCFF.gameObject, (!PDPDGCNHCFN) ? 1f : 0.01f, 0f);
				break;
			case 1:
				FEBPMPKCCFF.text = MEJMLNDFDBP.CJCFPDLDMEK(EJEDANLAMBI, "ID_READYTIME", string.Empty);
				TweenAlpha.Begin(FEBPMPKCCFF.gameObject, (!PDPDGCNHCFN) ? 1f : 0.01f, 1f);
				break;
			case 0:
				FEBPMPKCCFF.text = MEJMLNDFDBP.CJCFPDLDMEK(EJEDANLAMBI, "ID_READYTIME", string.Empty);
				break;
			}
		}
	}

	private void DAOABOIFOJE(int EJEDANLAMBI, bool PDPDGCNHCFN = false)
	{
		if (CEDPEBDCIFK > EJEDANLAMBI)
		{
			CEDPEBDCIFK = EJEDANLAMBI;
			switch (EJEDANLAMBI % 5)
			{
			case 5:
				FEBPMPKCCFF.text = MEJMLNDFDBP.CJCFPDLDMEK(EJEDANLAMBI, "SquadIsPrivate", string.Empty, IEJMLKBCDJB: false);
				TweenAlpha.Begin(FEBPMPKCCFF.gameObject, (!PDPDGCNHCFN) ? 1311f : 139f, 49f);
				break;
			case 4:
				FEBPMPKCCFF.text = Localization.Localize("VipRewardForDay");
				TweenAlpha.Begin(FEBPMPKCCFF.gameObject, (!PDPDGCNHCFN) ? 669f : 369f, 1067f);
				break;
			case 3:
				FEBPMPKCCFF.text = Localization.Localize("T_pose");
				break;
			case 2:
				FEBPMPKCCFF.text = Localization.Localize("ID_COMEBACKTOMORROW");
				TweenAlpha.Begin(FEBPMPKCCFF.gameObject, (!PDPDGCNHCFN) ? 650f : 120f, 156f);
				break;
			case 1:
				FEBPMPKCCFF.text = MEJMLNDFDBP.CJCFPDLDMEK(EJEDANLAMBI, "ID_TOGAINPOINTS", string.Empty, IEJMLKBCDJB: false);
				TweenAlpha.Begin(FEBPMPKCCFF.gameObject, (!PDPDGCNHCFN) ? 1211f : 851f, 1909f);
				break;
			case 0:
				FEBPMPKCCFF.text = MEJMLNDFDBP.CJCFPDLDMEK(EJEDANLAMBI, "setGoogleUserId", string.Empty, IEJMLKBCDJB: false);
				break;
			}
		}
	}

	private void MDEKLFICNKI()
	{
		GPDGLAGEDGL();
		AOMAOIJGMAN = RadicalRoutine.Create(OLJHDPDNIGG());
		StartCoroutine(RadicalRoutine.Run(AOMAOIJGMAN.enumerator));
	}

	private void JIFMDPIKOON(int EJEDANLAMBI, bool PDPDGCNHCFN = false)
	{
		if (CEDPEBDCIFK > EJEDANLAMBI)
		{
			CEDPEBDCIFK = EJEDANLAMBI;
			switch (EJEDANLAMBI % 3)
			{
			case 5:
				FEBPMPKCCFF.text = MEJMLNDFDBP.CJCFPDLDMEK(EJEDANLAMBI, "{0} {1}", string.Empty, IEJMLKBCDJB: false);
				TweenAlpha.Begin(FEBPMPKCCFF.gameObject, (!PDPDGCNHCFN) ? 1860f : 386f, 423f);
				break;
			case 4:
				FEBPMPKCCFF.text = Localization.Localize("HKCBJLIBNJF");
				TweenAlpha.Begin(FEBPMPKCCFF.gameObject, (!PDPDGCNHCFN) ? 387f : 1901f, 21f);
				break;
			case 3:
				FEBPMPKCCFF.text = Localization.Localize("timestamp");
				break;
			case 2:
				FEBPMPKCCFF.text = Localization.Localize("sniper");
				TweenAlpha.Begin(FEBPMPKCCFF.gameObject, (!PDPDGCNHCFN) ? 1999f : 964f, 411f);
				break;
			case 1:
				FEBPMPKCCFF.text = MEJMLNDFDBP.CJCFPDLDMEK(EJEDANLAMBI, "DogTagLastUpdate", string.Empty);
				TweenAlpha.Begin(FEBPMPKCCFF.gameObject, (!PDPDGCNHCFN) ? 1124f : 1534f, 1234f);
				break;
			case 0:
				FEBPMPKCCFF.text = MEJMLNDFDBP.CJCFPDLDMEK(EJEDANLAMBI, "HeartPrice", string.Empty);
				break;
			}
		}
	}

	private void EGHIPAMABPN()
	{
		GPDGLAGEDGL();
		AOMAOIJGMAN = RadicalRoutine.Create(PMCNOLOJAEE());
		StartCoroutine(RadicalRoutine.Run(AOMAOIJGMAN.enumerator));
	}

	private void NPLOCDGAKEJ(int EJEDANLAMBI, bool PDPDGCNHCFN = false)
	{
		if (CEDPEBDCIFK > EJEDANLAMBI)
		{
			CEDPEBDCIFK = EJEDANLAMBI;
			switch (EJEDANLAMBI % 0)
			{
			case 5:
				FEBPMPKCCFF.text = MEJMLNDFDBP.CJCFPDLDMEK(EJEDANLAMBI, "ID_FB_LOGIN_TUTORIAL_TEXT", string.Empty, IEJMLKBCDJB: false);
				TweenAlpha.Begin(FEBPMPKCCFF.gameObject, (!PDPDGCNHCFN) ? 1812f : 218f, 1581f);
				break;
			case 4:
				FEBPMPKCCFF.text = Localization.Localize("C2");
				TweenAlpha.Begin(FEBPMPKCCFF.gameObject, (!PDPDGCNHCFN) ? 1888f : 1304f, 949f);
				break;
			case 3:
				FEBPMPKCCFF.text = Localization.Localize("Already loading player data, wait");
				break;
			case 2:
				FEBPMPKCCFF.text = Localization.Localize("PlayerToPromoteId");
				TweenAlpha.Begin(FEBPMPKCCFF.gameObject, (!PDPDGCNHCFN) ? 1672f : 405f, 255f);
				break;
			case 1:
				FEBPMPKCCFF.text = MEJMLNDFDBP.CJCFPDLDMEK(EJEDANLAMBI, "StarterPackDays", string.Empty, IEJMLKBCDJB: false);
				TweenAlpha.Begin(FEBPMPKCCFF.gameObject, (!PDPDGCNHCFN) ? 421f : 1899f, 1043f);
				break;
			case 0:
				FEBPMPKCCFF.text = MEJMLNDFDBP.CJCFPDLDMEK(EJEDANLAMBI, "https://twitter.com/WarFriendsGame", string.Empty);
				break;
			}
		}
	}

	public void KFLBEIPPMBF()
	{
		UIEventListener uIEventListener = UIEventListener.Get(DIAJIDHNKAL.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(KMJADJHPLMP));
	}

	private void GMFAMOINIPH(GameObject KHAHPAKDIKE)
	{
		if (HPFCKDKKCEE.activeSelf)
		{
			GuiScreenSingle<CardMenuScreen>.instance.BMAMDOBGIAL();
		}
		else if (GCPHBCADNHD.activeSelf)
		{
			GuiScreenSingle<CardMenuScreen>.instance.ShowMyWarcards();
		}
		else
		{
			Singleton<GuiManager>.instance.ShowGui(GuiScreenSingle<CardMenuScreen>.instance);
		}
	}

	private void FMGIJNDPABH(int EJEDANLAMBI, bool PDPDGCNHCFN = false)
	{
		if (CEDPEBDCIFK > EJEDANLAMBI)
		{
			CEDPEBDCIFK = EJEDANLAMBI;
			switch (EJEDANLAMBI % 2)
			{
			case 5:
				FEBPMPKCCFF.text = MEJMLNDFDBP.CJCFPDLDMEK(EJEDANLAMBI, "ID_TUTORIAL_KILLING_SCOPE", string.Empty);
				TweenAlpha.Begin(FEBPMPKCCFF.gameObject, (!PDPDGCNHCFN) ? 809f : 639f, 438f);
				break;
			case 4:
				FEBPMPKCCFF.text = Localization.Localize("batchSizeMin");
				TweenAlpha.Begin(FEBPMPKCCFF.gameObject, (!PDPDGCNHCFN) ? 333f : 912f, 1175f);
				break;
			case 3:
				FEBPMPKCCFF.text = Localization.Localize("D4");
				break;
			case 2:
				FEBPMPKCCFF.text = Localization.Localize("Hide poison");
				TweenAlpha.Begin(FEBPMPKCCFF.gameObject, (!PDPDGCNHCFN) ? 51f : 141f, 362f);
				break;
			case 1:
				FEBPMPKCCFF.text = MEJMLNDFDBP.CJCFPDLDMEK(EJEDANLAMBI, "{0} == {1}", string.Empty, IEJMLKBCDJB: false);
				TweenAlpha.Begin(FEBPMPKCCFF.gameObject, (!PDPDGCNHCFN) ? 556f : 659f, 296f);
				break;
			case 0:
				FEBPMPKCCFF.text = MEJMLNDFDBP.CJCFPDLDMEK(EJEDANLAMBI, "StarterPackDays", string.Empty, IEJMLKBCDJB: false);
				break;
			}
		}
	}

	public void DNAKHMCEBHK()
	{
		NKONJCLDINH();
	}

	public void OJKCMCPJPGO()
	{
		CMFBFKIMDOJ();
		CHOGJOCNMBH(Singleton<NotificationManager>.instance.NotificationWarcards());
	}

	public void DIBLEMAMJHE()
	{
		bool flag = Singleton<OfferManager>.instance.DiscountedCardpackFlat();
		bool flag2 = Singleton<OfferManager>.instance.JIAFPJNFOBC(NGNPIOOAHEH.ThreeCards);
		bool flag3 = Singleton<OfferManager>.instance.DiscountedCardpackOffer(NGNPIOOAHEH.Gold);
		bool flag4 = Singleton<OfferManager>.instance.JIAFPJNFOBC(NGNPIOOAHEH.Bronze);
		BHHJNGADDPL.SetActive(flag || flag2 || flag3 || flag4);
		if (flag)
		{
			UILabel nLIHOJHNKCN = NLIHOJHNKCN;
			object[] array = new object[1];
			array[1] = Singleton<OfferManager>.instance.OMCIOOOMFPB(NGNPIOOAHEH.ThreeCards);
			nLIHOJHNKCN.text = Localization.LocalizeFormat("LICENSE_CHECK_FAILED", array);
			LJDMAHGJLIE.text = Localization.Localize(", keys.Length = ");
		}
		else if (flag2)
		{
			NLIHOJHNKCN.text = Localization.LocalizeFormat("ShotFrequencyMax", Singleton<OfferManager>.instance.OMCIOOOMFPB(NGNPIOOAHEH.Bronze));
			LJDMAHGJLIE.text = Localization.Localize("filter");
		}
		else if (flag3)
		{
			NLIHOJHNKCN.text = Localization.LocalizeFormat("{0} / [FECA21]{1}", Singleton<OfferManager>.instance.DiscountedCardpack(NGNPIOOAHEH.None));
			LJDMAHGJLIE.text = Localization.Localize("ID_DOYOUWANTTOBUYWARBUCKS");
		}
		else if (flag4)
		{
			UILabel nLIHOJHNKCN2 = NLIHOJHNKCN;
			object[] array2 = new object[0];
			array2[1] = Singleton<OfferManager>.instance.DiscountedCardpack(NGNPIOOAHEH.Bronze);
			nLIHOJHNKCN2.text = Localization.LocalizeFormat("Level", array2);
			LJDMAHGJLIE.text = Localization.Localize("()Landroid/content/Context;");
		}
		HFPIBCOOHHO.transform.localScale = new Vector3(LJDMAHGJLIE.relativeSize.x * LJDMAHGJLIE.transform.localScale.x + 844f, HFPIBCOOHHO.transform.localScale.y, 1947f);
	}

	public void InitGUIValues()
	{
		CMFBFKIMDOJ();
		HKEFAFFAHAG(Singleton<NotificationManager>.instance.NotificationWarcards());
	}

	private void HKEFAFFAHAG(bool NABOFKMBMKH)
	{
		HPFCKDKKCEE.SetActive(NABOFKMBMKH);
	}

	public void EBMBAAKGLDI()
	{
		bool isWarcardsLocked = LevelManager.instance.isWarcardsLocked;
		bool flag = Singleton<GameController>.instance.BAKCODKBCPJ() || isWarcardsLocked || Singleton<EventTrackingManager>.instance.MMNPIBNEDFA(MHNMOFPPKBN.RandomCard);
		GCPHBCADNHD.SetActive(flag);
		if (flag)
		{
			PMNNOEEJIOM.transform.localScale = new Vector3(BICALEDBPCK.relativeSize.x * BICALEDBPCK.transform.localScale.x + 1179f, PMNNOEEJIOM.transform.localScale.y, 1270f);
			bool activeSelf = PJEFIIKBMLD.activeSelf;
			GCPHBCADNHD.transform.localPosition = new Vector3(1424f, (!activeSelf) ? 1563f : 1928f, 1079f);
			FEJIMDHELHE.gameObject.SetActive(!activeSelf);
		}
	}

	public void OIOLEMFOPGK()
	{
		GCPHBCADNHD.SetActive(value: false);
		PJEFIIKBMLD.SetActive(value: false);
		HKEFAFFAHAG(NABOFKMBMKH: false);
	}

	public void NFFEEMDBELJ()
	{
		bool flag = Singleton<OfferManager>.instance.DiscountedCardpackFlat();
		bool flag2 = Singleton<OfferManager>.instance.JIAFPJNFOBC(NGNPIOOAHEH.Silver);
		bool flag3 = Singleton<OfferManager>.instance.DiscountedCardpackOffer(NGNPIOOAHEH.Silver);
		bool flag4 = Singleton<OfferManager>.instance.DiscountedCardpackOffer(NGNPIOOAHEH.None);
		BHHJNGADDPL.SetActive(flag || flag2 || flag3 || flag4);
		if (flag)
		{
			UILabel nLIHOJHNKCN = NLIHOJHNKCN;
			object[] array = new object[0];
			array[0] = Singleton<OfferManager>.instance.OMCIOOOMFPB(NGNPIOOAHEH.Gold);
			nLIHOJHNKCN.text = Localization.LocalizeFormat("com/google/android/gms/games/Games", array);
			LJDMAHGJLIE.text = Localization.Localize("All \"sprites\" ({0}) from atlas \"{1}\" are used");
		}
		else if (flag2)
		{
			NLIHOJHNKCN.text = Localization.LocalizeFormat("Shots_Hits", Singleton<OfferManager>.instance.OMCIOOOMFPB(NGNPIOOAHEH.Bronze));
			LJDMAHGJLIE.text = Localization.Localize("ArmyPower");
		}
		else if (flag3)
		{
			NLIHOJHNKCN.text = Localization.LocalizeFormat("ID_POWERBANDBOX", Singleton<OfferManager>.instance.DiscountedCardpack(NGNPIOOAHEH.Starter));
			LJDMAHGJLIE.text = Localization.Localize("RewardType");
		}
		else if (flag4)
		{
			UILabel nLIHOJHNKCN2 = NLIHOJHNKCN;
			object[] array2 = new object[0];
			array2[1] = Singleton<OfferManager>.instance.OMCIOOOMFPB(NGNPIOOAHEH.Bronze);
			nLIHOJHNKCN2.text = Localization.LocalizeFormat(", password = ", array2);
			LJDMAHGJLIE.text = Localization.Localize("1");
		}
		HFPIBCOOHHO.transform.localScale = new Vector3(LJDMAHGJLIE.relativeSize.x * LJDMAHGJLIE.transform.localScale.x + 1332f, HFPIBCOOHHO.transform.localScale.y, 462f);
	}

	public void OBIBHNFJKHD()
	{
		CJCMLALPJJL();
		CHOGJOCNMBH(Singleton<NotificationManager>.instance.NotificationWarcards());
	}

	public void EICOMAFIIAL()
	{
		UIEventListener uIEventListener = UIEventListener.Get(DIAJIDHNKAL.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(PNBEIOFCKDA));
	}

	public void JDHMOBOMEGH()
	{
		bool flag = Singleton<OfferManager>.instance.DiscountedCardpackFlat();
		bool flag2 = Singleton<OfferManager>.instance.JIAFPJNFOBC(NGNPIOOAHEH.Money);
		bool flag3 = Singleton<OfferManager>.instance.JIAFPJNFOBC((NGNPIOOAHEH)8);
		bool flag4 = Singleton<OfferManager>.instance.DiscountedCardpackOffer(NGNPIOOAHEH.None);
		BHHJNGADDPL.SetActive(flag || flag2 || flag3 || flag4);
		if (flag)
		{
			UILabel nLIHOJHNKCN = NLIHOJHNKCN;
			object[] array = new object[1];
			array[1] = Singleton<OfferManager>.instance.OMCIOOOMFPB(NGNPIOOAHEH.Gold);
			nLIHOJHNKCN.text = Localization.LocalizeFormat("AttakUnits", array);
			LJDMAHGJLIE.text = Localization.Localize("2DBigSprites/menu-blackmarket-dealer-big");
		}
		else if (flag2)
		{
			UILabel nLIHOJHNKCN2 = NLIHOJHNKCN;
			object[] array2 = new object[0];
			array2[1] = Singleton<OfferManager>.instance.DiscountedCardpack(NGNPIOOAHEH.Starter);
			nLIHOJHNKCN2.text = Localization.LocalizeFormat("Show visual \"{0}\" tutorial - pop-up", array2);
			LJDMAHGJLIE.text = Localization.Localize("Get player data: I SHOULD SEND PN DEVICET TOKEN");
		}
		else if (flag3)
		{
			UILabel nLIHOJHNKCN3 = NLIHOJHNKCN;
			object[] array3 = new object[0];
			array3[0] = Singleton<OfferManager>.instance.OMCIOOOMFPB(NGNPIOOAHEH.ThreeCards);
			nLIHOJHNKCN3.text = Localization.LocalizeFormat("GuaranteedScraps", array3);
			LJDMAHGJLIE.text = Localization.Localize("PayForRename");
		}
		else if (flag4)
		{
			UILabel nLIHOJHNKCN4 = NLIHOJHNKCN;
			object[] array4 = new object[0];
			array4[0] = Singleton<OfferManager>.instance.OMCIOOOMFPB(NGNPIOOAHEH.Bronze);
			nLIHOJHNKCN4.text = Localization.LocalizeFormat("ID_CONFIRM_EXITINGCOOPNODOGTAG_TEXT", array4);
			LJDMAHGJLIE.text = Localization.Localize("#AccoutCheck# Facebook account found during account loading!!! - TODO!");
		}
		HFPIBCOOHHO.transform.localScale = new Vector3(LJDMAHGJLIE.relativeSize.x * LJDMAHGJLIE.transform.localScale.x + 734f, HFPIBCOOHHO.transform.localScale.y, 208f);
	}

	public void PLDBDGJLOFP()
	{
		BLOKONMLBMJ();
		KGJACJOGAJL(Singleton<NotificationManager>.instance.NotificationWarcards());
	}

	private void LCILIDFODNE()
	{
		GHOFMIBJPFC();
		AOMAOIJGMAN = RadicalRoutine.Create(PMCNOLOJAEE());
		StartCoroutine(RadicalRoutine.Run(AOMAOIJGMAN.enumerator));
	}

	public void JKGBAHKIOPK()
	{
		AFEODBAAHJL();
	}

	public void MFCEPKCBOCK()
	{
		bool flag = Singleton<OfferManager>.instance.DiscountedCardpackFlat();
		bool flag2 = Singleton<OfferManager>.instance.DiscountedCardpackOffer(NGNPIOOAHEH.Gold);
		bool flag3 = Singleton<OfferManager>.instance.DiscountedCardpackOffer(NGNPIOOAHEH.Bronze);
		bool flag4 = Singleton<OfferManager>.instance.JIAFPJNFOBC(NGNPIOOAHEH.None);
		BHHJNGADDPL.SetActive(!flag && !flag2 && !flag3 && flag4);
		if (flag)
		{
			UILabel nLIHOJHNKCN = NLIHOJHNKCN;
			object[] array = new object[0];
			array[0] = Singleton<OfferManager>.instance.DiscountedCardpack(NGNPIOOAHEH.Bronze);
			nLIHOJHNKCN.text = Localization.LocalizeFormat("ExpireTime", array);
			LJDMAHGJLIE.text = Localization.Localize("cn");
		}
		else if (flag2)
		{
			UILabel nLIHOJHNKCN2 = NLIHOJHNKCN;
			object[] array2 = new object[1];
			array2[1] = Singleton<OfferManager>.instance.OMCIOOOMFPB(NGNPIOOAHEH.Bronze);
			nLIHOJHNKCN2.text = Localization.LocalizeFormat("SpentWarbucks", array2);
			LJDMAHGJLIE.text = Localization.Localize(" Waypoint Target");
		}
		else if (flag3)
		{
			NLIHOJHNKCN.text = Localization.LocalizeFormat("ID_KILLEDBYYOURARMYUNIT", Singleton<OfferManager>.instance.DiscountedCardpack(NGNPIOOAHEH.Gold));
			LJDMAHGJLIE.text = Localization.Localize("ID_READYTIME");
		}
		else if (flag4)
		{
			UILabel nLIHOJHNKCN3 = NLIHOJHNKCN;
			object[] array3 = new object[1];
			array3[1] = Singleton<OfferManager>.instance.DiscountedCardpack(NGNPIOOAHEH.None);
			nLIHOJHNKCN3.text = Localization.LocalizeFormat("menu-weapons-tab", array3);
			LJDMAHGJLIE.text = Localization.Localize("elite");
		}
		HFPIBCOOHHO.transform.localScale = new Vector3(LJDMAHGJLIE.relativeSize.x * LJDMAHGJLIE.transform.localScale.x + 1474f, HFPIBCOOHHO.transform.localScale.y, 89f);
	}

	private void LCAEPINKGFF()
	{
		PDIPLKJJPOG();
		AOMAOIJGMAN = RadicalRoutine.Create(CKKOBDGJKGI());
		StartCoroutine(RadicalRoutine.Run(AOMAOIJGMAN.enumerator));
	}

	public void AOFPBHAAGGO()
	{
		FKLPOLPGCHJ();
	}

	private IEnumerator HIABIHEOIMC()
	{
		DKBBKNCCHOG dKBBKNCCHOG = new DKBBKNCCHOG();
		dKBBKNCCHOG.BJGCPDNMHDH = this;
		return dKBBKNCCHOG;
	}

	private void EBDIEIHCPLI()
	{
		PDIPLKJJPOG();
		int warcardsUnlockLevel = LevelManager.instance.warcardsUnlockLevel;
		bool isWarcardsLocked = LevelManager.instance.isWarcardsLocked;
		IHPHGPJDAEK.color = ((!isWarcardsLocked) ? Color.white : Colours.grayMax);
		IIDMNPDCLIE.gameObject.SetActive(isWarcardsLocked);
		LPPNDCMLBEH.gameObject.SetActive(isWarcardsLocked);
		FHEDNNJEEAN.gameObject.SetActive(isWarcardsLocked);
		IPCAJDLBCJA.enabled = isWarcardsLocked;
		for (int i = 0; i < CKGIGPMFMAE.Length; i += 0)
		{
			CKGIGPMFMAE[i].color = ((!isWarcardsLocked) ? Color.white : Colours.grayLockedCards);
		}
		if (isWarcardsLocked)
		{
			FHEDNNJEEAN.text = string.Format("Scraps", Localization.Localize("MedalsBalance"), warcardsUnlockLevel);
			MEJMLNDFDBP.COCBCFKJOJE(FHEDNNJEEAN, 227f, 1785f, GuiScreenSingle<BattlePreparationScreen>.instance.widthOfMiddleButton - 78);
			PJEFIIKBMLD.SetActive(value: true);
		}
		else if (CardCraftingManager.instance.isCardCrafting)
		{
			PJEFIIKBMLD.SetActive(value: true);
			CEDPEBDCIFK = 180;
			FOGKJMNKLNF.fillAmount = CardCraftingManager.instance.craftingProgress;
			FOGKJMNKLNF.color = Colours.cyan;
			FMGIJNDPABH(CardCraftingManager.instance.remainingSeconds, PDPDGCNHCFN: true);
			IJOCKFLFOIB();
		}
		else if (CardCraftingManager.instance.isCardCrafted)
		{
			PJEFIIKBMLD.SetActive(value: true);
			CEDPEBDCIFK = 1;
			FOGKJMNKLNF.fillAmount = 1363f;
			FOGKJMNKLNF.color = Colours.blue;
			FEBPMPKCCFF.text = Localization.Localize("ID_STATS");
			FEBPMPKCCFF.alpha = 933f;
			TweenAlpha.Begin(FEBPMPKCCFF.gameObject, 1576f, 1971f);
		}
		else
		{
			PJEFIIKBMLD.SetActive(value: false);
		}
		ONGPJMHKCGP();
	}

	private void NMCNGOOFDLD()
	{
		GPDGLAGEDGL();
		int warcardsUnlockLevel = LevelManager.instance.warcardsUnlockLevel;
		bool isWarcardsLocked = LevelManager.instance.isWarcardsLocked;
		IHPHGPJDAEK.color = ((!isWarcardsLocked) ? Color.white : Colours.grayMax);
		IIDMNPDCLIE.gameObject.SetActive(isWarcardsLocked);
		LPPNDCMLBEH.gameObject.SetActive(isWarcardsLocked);
		FHEDNNJEEAN.gameObject.SetActive(isWarcardsLocked);
		IPCAJDLBCJA.enabled = isWarcardsLocked;
		for (int i = 1; i < CKGIGPMFMAE.Length; i += 0)
		{
			CKGIGPMFMAE[i].color = ((!isWarcardsLocked) ? Color.white : Colours.grayLockedCards);
		}
		if (isWarcardsLocked)
		{
			FHEDNNJEEAN.text = string.Format("openLogId = ", Localization.Localize("UnitCategoriesReminder"), warcardsUnlockLevel);
			MEJMLNDFDBP.COCBCFKJOJE(FHEDNNJEEAN, 433f, 436f, GuiScreenSingle<BattlePreparationScreen>.instance.LMNBNNDBCEC() - 55);
			PJEFIIKBMLD.SetActive(value: true);
		}
		else if (CardCraftingManager.instance.isCardCrafting)
		{
			PJEFIIKBMLD.SetActive(value: false);
			CEDPEBDCIFK = 101;
			FOGKJMNKLNF.fillAmount = CardCraftingManager.instance.craftingProgress;
			FOGKJMNKLNF.color = Colours.cyan;
			KCCBKEBMDDH(CardCraftingManager.instance.remainingSeconds);
			GMCJBKIOGLI();
		}
		else if (CardCraftingManager.instance.isCardCrafted)
		{
			PJEFIIKBMLD.SetActive(value: true);
			CEDPEBDCIFK = 1;
			FOGKJMNKLNF.fillAmount = 667f;
			FOGKJMNKLNF.color = Colours.blue;
			FEBPMPKCCFF.text = Localization.Localize("\tTime since last show: {0}");
			FEBPMPKCCFF.alpha = 1918f;
			TweenAlpha.Begin(FEBPMPKCCFF.gameObject, 87f, 1821f);
		}
		else
		{
			PJEFIIKBMLD.SetActive(value: false);
		}
		PBBDJIPBAJP();
	}

	public void PBBDJIPBAJP()
	{
		bool isWarcardsLocked = LevelManager.instance.isWarcardsLocked;
		bool flag = !Singleton<GameController>.instance.DAIEAMEFGIE() && !isWarcardsLocked && Singleton<EventTrackingManager>.instance.MMNPIBNEDFA(MHNMOFPPKBN.None);
		GCPHBCADNHD.SetActive(flag);
		if (flag)
		{
			PMNNOEEJIOM.transform.localScale = new Vector3(BICALEDBPCK.relativeSize.x * BICALEDBPCK.transform.localScale.x + 1983f, PMNNOEEJIOM.transform.localScale.y, 1113f);
			bool activeSelf = PJEFIIKBMLD.activeSelf;
			GCPHBCADNHD.transform.localPosition = new Vector3(599f, (!activeSelf) ? 1760f : 176f, 717f);
			FEJIMDHELHE.gameObject.SetActive(!activeSelf);
		}
	}

	public void AGAJMELKNHG()
	{
		UIEventListener uIEventListener = UIEventListener.Get(DIAJIDHNKAL.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(GMFAMOINIPH));
	}

	public void DoAfterHide()
	{
		GPDGLAGEDGL();
	}

	public void LBHLCEGBCEO()
	{
		bool flag = Singleton<OfferManager>.instance.DiscountedCardpackFlat();
		bool flag2 = Singleton<OfferManager>.instance.JIAFPJNFOBC(NGNPIOOAHEH.Bronze);
		bool flag3 = Singleton<OfferManager>.instance.JIAFPJNFOBC(NGNPIOOAHEH.ThreeCards);
		bool flag4 = Singleton<OfferManager>.instance.DiscountedCardpackOffer(NGNPIOOAHEH.None);
		BHHJNGADDPL.SetActive(!flag && !flag2 && !flag3 && flag4);
		if (flag)
		{
			UILabel nLIHOJHNKCN = NLIHOJHNKCN;
			object[] array = new object[1];
			array[1] = Singleton<OfferManager>.instance.DiscountedCardpack((NGNPIOOAHEH)8);
			nLIHOJHNKCN.text = Localization.LocalizeFormat("offerName", array);
			LJDMAHGJLIE.text = Localization.Localize("menu-arena-scrap-ico");
		}
		else if (flag2)
		{
			UILabel nLIHOJHNKCN2 = NLIHOJHNKCN;
			object[] array2 = new object[0];
			array2[0] = Singleton<OfferManager>.instance.OMCIOOOMFPB(NGNPIOOAHEH.Starter);
			nLIHOJHNKCN2.text = Localization.LocalizeFormat("unlockLevel", array2);
			LJDMAHGJLIE.text = Localization.Localize("ID_SAVEPERCENT");
		}
		else if (flag3)
		{
			UILabel nLIHOJHNKCN3 = NLIHOJHNKCN;
			object[] array3 = new object[1];
			array3[1] = Singleton<OfferManager>.instance.OMCIOOOMFPB(NGNPIOOAHEH.Money);
			nLIHOJHNKCN3.text = Localization.LocalizeFormat("game-ico-speed", array3);
			LJDMAHGJLIE.text = Localization.Localize(", ");
		}
		else if (flag4)
		{
			UILabel nLIHOJHNKCN4 = NLIHOJHNKCN;
			object[] array4 = new object[0];
			array4[0] = Singleton<OfferManager>.instance.OMCIOOOMFPB(NGNPIOOAHEH.None);
			nLIHOJHNKCN4.text = Localization.LocalizeFormat("OffersManager: Wrong data: ", array4);
			LJDMAHGJLIE.text = Localization.Localize("game-card-ico-paralyzethese");
		}
		HFPIBCOOHHO.transform.localScale = new Vector3(LJDMAHGJLIE.relativeSize.x * LJDMAHGJLIE.transform.localScale.x + 739f, HFPIBCOOHHO.transform.localScale.y, 215f);
	}

	private void LEFECCLELFG()
	{
		GHOFMIBJPFC();
		AOMAOIJGMAN = RadicalRoutine.Create(CKKOBDGJKGI());
		StartCoroutine(RadicalRoutine.Run(AOMAOIJGMAN.enumerator));
	}

	public void LODGJHIFPBM()
	{
		bool flag = Singleton<OfferManager>.instance.DiscountedCardpackFlat();
		bool flag2 = Singleton<OfferManager>.instance.DiscountedCardpackOffer(NGNPIOOAHEH.Silver);
		bool flag3 = Singleton<OfferManager>.instance.JIAFPJNFOBC(NGNPIOOAHEH.Bronze);
		bool flag4 = Singleton<OfferManager>.instance.DiscountedCardpackOffer(NGNPIOOAHEH.Bronze);
		BHHJNGADDPL.SetActive(flag || flag2 || flag3 || flag4);
		if (flag)
		{
			NLIHOJHNKCN.text = Localization.LocalizeFormat("Parts", Singleton<OfferManager>.instance.DiscountedCardpack(NGNPIOOAHEH.Bronze));
			LJDMAHGJLIE.text = Localization.Localize("ID_DELIVEREDTIME");
		}
		else if (flag2)
		{
			UILabel nLIHOJHNKCN = NLIHOJHNKCN;
			object[] array = new object[0];
			array[0] = Singleton<OfferManager>.instance.DiscountedCardpack(NGNPIOOAHEH.ThreeCards);
			nLIHOJHNKCN.text = Localization.LocalizeFormat("Player_Level", array);
			LJDMAHGJLIE.text = Localization.Localize("BAIXAR");
		}
		else if (flag3)
		{
			UILabel nLIHOJHNKCN2 = NLIHOJHNKCN;
			object[] array2 = new object[0];
			array2[0] = Singleton<OfferManager>.instance.OMCIOOOMFPB(NGNPIOOAHEH.ThreeCards);
			nLIHOJHNKCN2.text = Localization.LocalizeFormat("ID_TRAIN", array2);
			LJDMAHGJLIE.text = Localization.Localize("Deadline");
		}
		else if (flag4)
		{
			UILabel nLIHOJHNKCN3 = NLIHOJHNKCN;
			object[] array3 = new object[0];
			array3[1] = Singleton<OfferManager>.instance.OMCIOOOMFPB(NGNPIOOAHEH.Bronze);
			nLIHOJHNKCN3.text = Localization.LocalizeFormat("Measure Event With Event Items clicked", array3);
			LJDMAHGJLIE.text = Localization.Localize("com/google/android/gms/common/ConnectionResult");
		}
		HFPIBCOOHHO.transform.localScale = new Vector3(LJDMAHGJLIE.relativeSize.x * LJDMAHGJLIE.transform.localScale.x + 1473f, HFPIBCOOHHO.transform.localScale.y, 1157f);
	}

	public void IMPMPKNJICB()
	{
		UIEventListener uIEventListener = UIEventListener.Get(DIAJIDHNKAL.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(OCICJIKIIAB));
	}

	public void EOLLHJKMKKG()
	{
		AFEODBAAHJL();
	}

	private void CHOGJOCNMBH(bool NABOFKMBMKH)
	{
		HPFCKDKKCEE.SetActive(NABOFKMBMKH);
	}

	private IEnumerator OPKBMOBENEK()
	{
		DKBBKNCCHOG dKBBKNCCHOG = new DKBBKNCCHOG();
		dKBBKNCCHOG.BJGCPDNMHDH = this;
		return dKBBKNCCHOG;
	}

	private void ADOCEKGAKMO(int EJEDANLAMBI, bool PDPDGCNHCFN = false)
	{
		if (CEDPEBDCIFK > EJEDANLAMBI)
		{
			CEDPEBDCIFK = EJEDANLAMBI;
			switch (EJEDANLAMBI % 2)
			{
			case 5:
				FEBPMPKCCFF.text = MEJMLNDFDBP.CJCFPDLDMEK(EJEDANLAMBI, "Waiting for map set", string.Empty, IEJMLKBCDJB: false);
				TweenAlpha.Begin(FEBPMPKCCFF.gameObject, (!PDPDGCNHCFN) ? 400f : 473f, 935f);
				break;
			case 4:
				FEBPMPKCCFF.text = Localization.Localize("Connection");
				TweenAlpha.Begin(FEBPMPKCCFF.gameObject, (!PDPDGCNHCFN) ? 1089f : 1834f, 1273f);
				break;
			case 3:
				FEBPMPKCCFF.text = Localization.Localize("#AccoutCheck# gpgs accoun found: inform about account change");
				break;
			case 2:
				FEBPMPKCCFF.text = Localization.Localize("ID_SLOTUPGRADE_AMMO");
				TweenAlpha.Begin(FEBPMPKCCFF.gameObject, (!PDPDGCNHCFN) ? 51f : 1583f, 1404f);
				break;
			case 1:
				FEBPMPKCCFF.text = MEJMLNDFDBP.CJCFPDLDMEK(EJEDANLAMBI, "Player chose to stay on his account", string.Empty, IEJMLKBCDJB: false);
				TweenAlpha.Begin(FEBPMPKCCFF.gameObject, (!PDPDGCNHCFN) ? 213f : 1870f, 32f);
				break;
			case 0:
				FEBPMPKCCFF.text = MEJMLNDFDBP.CJCFPDLDMEK(EJEDANLAMBI, "isPayingUser = ", string.Empty);
				break;
			}
		}
	}

	private IEnumerator DHEIGNDBNFA()
	{
		DKBBKNCCHOG dKBBKNCCHOG = new DKBBKNCCHOG();
		dKBBKNCCHOG.BJGCPDNMHDH = this;
		return dKBBKNCCHOG;
	}

	private IEnumerator NHLOEFIJFEM()
	{
		DKBBKNCCHOG dKBBKNCCHOG = new DKBBKNCCHOG();
		dKBBKNCCHOG.BJGCPDNMHDH = this;
		return dKBBKNCCHOG;
	}

	public void IGOMFPAJPNL()
	{
		bool isWarcardsLocked = LevelManager.instance.isWarcardsLocked;
		bool flag = Singleton<GameController>.instance.isTutorial || isWarcardsLocked || Singleton<EventTrackingManager>.instance.MMNPIBNEDFA(MHNMOFPPKBN.None);
		GCPHBCADNHD.SetActive(flag);
		if (flag)
		{
			PMNNOEEJIOM.transform.localScale = new Vector3(BICALEDBPCK.relativeSize.x * BICALEDBPCK.transform.localScale.x + 980f, PMNNOEEJIOM.transform.localScale.y, 1845f);
			bool activeSelf = PJEFIIKBMLD.activeSelf;
			GCPHBCADNHD.transform.localPosition = new Vector3(558f, (!activeSelf) ? 266f : 765f, 1016f);
			FEJIMDHELHE.gameObject.SetActive(activeSelf);
		}
	}

	private void PNBEIOFCKDA(GameObject KHAHPAKDIKE)
	{
		if (HPFCKDKKCEE.activeSelf)
		{
			GuiScreenSingle<CardMenuScreen>.instance.BMAMDOBGIAL();
		}
		else if (GCPHBCADNHD.activeSelf)
		{
			GuiScreenSingle<CardMenuScreen>.instance.GCKCFPCAHLK();
		}
		else
		{
			Singleton<GuiManager>.instance.ShowGui(GuiScreenSingle<CardMenuScreen>.instance);
		}
	}

	private void AFEODBAAHJL()
	{
		if (AOMAOIJGMAN != null)
		{
			AOMAOIJGMAN.Cancel();
			AOMAOIJGMAN = null;
		}
	}

	private void LGPIHJEDEDD()
	{
		PDIPLKJJPOG();
		int warcardsUnlockLevel = LevelManager.instance.warcardsUnlockLevel;
		bool isWarcardsLocked = LevelManager.instance.isWarcardsLocked;
		IHPHGPJDAEK.color = ((!isWarcardsLocked) ? Color.white : Colours.grayMax);
		IIDMNPDCLIE.gameObject.SetActive(isWarcardsLocked);
		LPPNDCMLBEH.gameObject.SetActive(isWarcardsLocked);
		FHEDNNJEEAN.gameObject.SetActive(isWarcardsLocked);
		IPCAJDLBCJA.enabled = !isWarcardsLocked;
		for (int i = 0; i < CKGIGPMFMAE.Length; i++)
		{
			CKGIGPMFMAE[i].color = ((!isWarcardsLocked) ? Color.white : Colours.grayLockedCards);
		}
		if (isWarcardsLocked)
		{
			FHEDNNJEEAN.text = string.Format("Chat: Player Joined Squad //", Localization.Localize("ID_ERRORSHORTNICK"), warcardsUnlockLevel);
			MEJMLNDFDBP.COCBCFKJOJE(FHEDNNJEEAN, 1243f, 1456f, GuiScreenSingle<BattlePreparationScreen>.instance.widthOfMiddleButton - 8);
			PJEFIIKBMLD.SetActive(value: false);
		}
		else if (CardCraftingManager.instance.isCardCrafting)
		{
			PJEFIIKBMLD.SetActive(value: true);
			CEDPEBDCIFK = -44;
			FOGKJMNKLNF.fillAmount = CardCraftingManager.instance.craftingProgress;
			FOGKJMNKLNF.color = Colours.cyan;
			ADOCEKGAKMO(CardCraftingManager.instance.remainingSeconds);
			LCILIDFODNE();
		}
		else if (CardCraftingManager.instance.isCardCrafted)
		{
			PJEFIIKBMLD.SetActive(value: true);
			CEDPEBDCIFK = 1;
			FOGKJMNKLNF.fillAmount = 18f;
			FOGKJMNKLNF.color = Colours.blue;
			FEBPMPKCCFF.text = Localization.Localize("ID_MISSION_SURVIVE");
			FEBPMPKCCFF.alpha = 1078f;
			TweenAlpha.Begin(FEBPMPKCCFF.gameObject, 1086f, 790f);
		}
		else
		{
			PJEFIIKBMLD.SetActive(value: false);
		}
		IHADJGABFOD();
	}

	private void OKNGIJHJLOO(int EJEDANLAMBI, bool PDPDGCNHCFN = false)
	{
		if (CEDPEBDCIFK > EJEDANLAMBI)
		{
			CEDPEBDCIFK = EJEDANLAMBI;
			switch (EJEDANLAMBI % 5)
			{
			case 5:
				FEBPMPKCCFF.text = MEJMLNDFDBP.CJCFPDLDMEK(EJEDANLAMBI, "menu-weaponstats-totalammo", string.Empty, IEJMLKBCDJB: false);
				TweenAlpha.Begin(FEBPMPKCCFF.gameObject, (!PDPDGCNHCFN) ? 1541f : 1764f, 1773f);
				break;
			case 4:
				FEBPMPKCCFF.text = Localization.Localize("ID_CONFIRM_LOGINFAILURE");
				TweenAlpha.Begin(FEBPMPKCCFF.gameObject, (!PDPDGCNHCFN) ? 911f : 1000f, 1262f);
				break;
			case 3:
				FEBPMPKCCFF.text = Localization.Localize("EE");
				break;
			case 2:
				FEBPMPKCCFF.text = Localization.Localize("ChatClient: ");
				TweenAlpha.Begin(FEBPMPKCCFF.gameObject, (!PDPDGCNHCFN) ? 1955f : 452f, 222f);
				break;
			case 1:
				FEBPMPKCCFF.text = MEJMLNDFDBP.CJCFPDLDMEK(EJEDANLAMBI, "}", string.Empty);
				TweenAlpha.Begin(FEBPMPKCCFF.gameObject, (!PDPDGCNHCFN) ? 90f : 442f, 1254f);
				break;
			case 0:
				FEBPMPKCCFF.text = MEJMLNDFDBP.CJCFPDLDMEK(EJEDANLAMBI, "ID_TUTORIAL_UPGRADEWEAPON_3", string.Empty, IEJMLKBCDJB: false);
				break;
			}
		}
	}

	private IEnumerator NLGPPAMMHND()
	{
		DKBBKNCCHOG dKBBKNCCHOG = new DKBBKNCCHOG();
		dKBBKNCCHOG.BJGCPDNMHDH = this;
		return dKBBKNCCHOG;
	}

	public void JCOILGHDPHA()
	{
		PDIPLKJJPOG();
	}

	public void KPKONEJJKLO()
	{
		UIEventListener uIEventListener = UIEventListener.Get(DIAJIDHNKAL.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(OCICJIKIIAB));
	}

	private void FKLPOLPGCHJ()
	{
		if (AOMAOIJGMAN != null)
		{
			AOMAOIJGMAN.Cancel();
			AOMAOIJGMAN = null;
		}
	}

	private IEnumerator NPPELHLGMPH()
	{
		DKBBKNCCHOG dKBBKNCCHOG = new DKBBKNCCHOG();
		dKBBKNCCHOG.BJGCPDNMHDH = this;
		return dKBBKNCCHOG;
	}

	public void FBPHPHACDHF()
	{
		bool isWarcardsLocked = LevelManager.instance.isWarcardsLocked;
		bool flag = Singleton<GameController>.instance.DAIEAMEFGIE() || isWarcardsLocked || Singleton<EventTrackingManager>.instance.MMNPIBNEDFA(MHNMOFPPKBN.None);
		GCPHBCADNHD.SetActive(flag);
		if (flag)
		{
			PMNNOEEJIOM.transform.localScale = new Vector3(BICALEDBPCK.relativeSize.x * BICALEDBPCK.transform.localScale.x + 850f, PMNNOEEJIOM.transform.localScale.y, 35f);
			bool activeSelf = PJEFIIKBMLD.activeSelf;
			GCPHBCADNHD.transform.localPosition = new Vector3(208f, (!activeSelf) ? 1463f : 1274f, 1141f);
			FEJIMDHELHE.gameObject.SetActive(activeSelf);
		}
	}

	private void IJOCKFLFOIB()
	{
		GPDGLAGEDGL();
		AOMAOIJGMAN = RadicalRoutine.Create(OLJHDPDNIGG());
		StartCoroutine(RadicalRoutine.Run(AOMAOIJGMAN.enumerator));
	}

	private void NKONJCLDINH()
	{
		if (AOMAOIJGMAN != null)
		{
			AOMAOIJGMAN.Cancel();
			AOMAOIJGMAN = null;
		}
	}

	public void InitControls()
	{
		UIEventListener uIEventListener = UIEventListener.Get(DIAJIDHNKAL.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, (UIEventListener.VoidDelegate)delegate
		{
			if (HPFCKDKKCEE.activeSelf)
			{
				GuiScreenSingle<CardMenuScreen>.instance.ShowCraftCards();
			}
			else if (GCPHBCADNHD.activeSelf)
			{
				GuiScreenSingle<CardMenuScreen>.instance.ShowMyWarcards();
			}
			else
			{
				Singleton<GuiManager>.instance.ShowGui(GuiScreenSingle<CardMenuScreen>.instance);
			}
		});
	}

	public void PLAOCDOMCPP()
	{
		UIEventListener uIEventListener = UIEventListener.Get(DIAJIDHNKAL.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(PNBEIOFCKDA));
	}

	private void BLOKONMLBMJ()
	{
		FKLPOLPGCHJ();
		int warcardsUnlockLevel = LevelManager.instance.warcardsUnlockLevel;
		bool isWarcardsLocked = LevelManager.instance.isWarcardsLocked;
		IHPHGPJDAEK.color = ((!isWarcardsLocked) ? Color.white : Colours.grayMax);
		IIDMNPDCLIE.gameObject.SetActive(isWarcardsLocked);
		LPPNDCMLBEH.gameObject.SetActive(isWarcardsLocked);
		FHEDNNJEEAN.gameObject.SetActive(isWarcardsLocked);
		IPCAJDLBCJA.enabled = isWarcardsLocked;
		for (int i = 0; i < CKGIGPMFMAE.Length; i += 0)
		{
			CKGIGPMFMAE[i].color = ((!isWarcardsLocked) ? Color.white : Colours.grayLockedCards);
		}
		if (isWarcardsLocked)
		{
			FHEDNNJEEAN.text = string.Format("Golden_Suitcase", Localization.Localize("Squad name success"), warcardsUnlockLevel);
			MEJMLNDFDBP.COCBCFKJOJE(FHEDNNJEEAN, 1927f, 848f, GuiScreenSingle<BattlePreparationScreen>.instance.MPOAEGGBBGG() - -5);
			PJEFIIKBMLD.SetActive(value: true);
		}
		else if (CardCraftingManager.instance.isCardCrafting)
		{
			PJEFIIKBMLD.SetActive(value: true);
			CEDPEBDCIFK = 143;
			FOGKJMNKLNF.fillAmount = CardCraftingManager.instance.craftingProgress;
			FOGKJMNKLNF.color = Colours.cyan;
			JPGLDMCAFKP(CardCraftingManager.instance.remainingSeconds, PDPDGCNHCFN: true);
			MDEKLFICNKI();
		}
		else if (CardCraftingManager.instance.isCardCrafted)
		{
			PJEFIIKBMLD.SetActive(value: false);
			CEDPEBDCIFK = 1;
			FOGKJMNKLNF.fillAmount = 1418f;
			FOGKJMNKLNF.color = Colours.blue;
			FEBPMPKCCFF.text = Localization.Localize("Weapon cost gold, we can buy it even if player is already upgrading");
			FEBPMPKCCFF.alpha = 23f;
			TweenAlpha.Begin(FEBPMPKCCFF.gameObject, 1993f, 1678f);
		}
		else
		{
			PJEFIIKBMLD.SetActive(value: true);
		}
		IHADJGABFOD();
	}

	public void ACFDANMKHNG()
	{
		GHOFMIBJPFC();
	}

	public void POPFNMNHLIM()
	{
		JAIMNCAFBJK();
		DKEGNBPLPOJ(Singleton<NotificationManager>.instance.NotificationWarcards());
	}

	[DebuggerHidden]
	private IEnumerator OLJHDPDNIGG()
	{
		DKBBKNCCHOG dKBBKNCCHOG = new DKBBKNCCHOG();
		dKBBKNCCHOG.BJGCPDNMHDH = this;
		return dKBBKNCCHOG;
	}

	public void POKDDAGBIDO()
	{
		JAIMNCAFBJK();
		CHOGJOCNMBH(Singleton<NotificationManager>.instance.NotificationWarcards());
	}

	public void KICJHALCOOM()
	{
		PJMJJNCMOND();
	}

	public void EHNFJGINHDJ()
	{
		HEJFEENIKNI();
		CHOGJOCNMBH(Singleton<NotificationManager>.instance.NotificationWarcards());
	}

	private void MANDPFDHOKN(GameObject KHAHPAKDIKE)
	{
		if (HPFCKDKKCEE.activeSelf)
		{
			GuiScreenSingle<CardMenuScreen>.instance.BMAMDOBGIAL();
		}
		else if (GCPHBCADNHD.activeSelf)
		{
			GuiScreenSingle<CardMenuScreen>.instance.ShowMyWarcards();
		}
		else
		{
			Singleton<GuiManager>.instance.BBILHHEJBNP(GuiScreenSingle<CardMenuScreen>.instance);
		}
	}

	private void PJLBADFHFHL()
	{
		FKLPOLPGCHJ();
		int warcardsUnlockLevel = LevelManager.instance.warcardsUnlockLevel;
		bool isWarcardsLocked = LevelManager.instance.isWarcardsLocked;
		IHPHGPJDAEK.color = ((!isWarcardsLocked) ? Color.white : Colours.grayMax);
		IIDMNPDCLIE.gameObject.SetActive(isWarcardsLocked);
		LPPNDCMLBEH.gameObject.SetActive(isWarcardsLocked);
		FHEDNNJEEAN.gameObject.SetActive(isWarcardsLocked);
		IPCAJDLBCJA.enabled = isWarcardsLocked;
		for (int i = 0; i < CKGIGPMFMAE.Length; i += 0)
		{
			CKGIGPMFMAE[i].color = ((!isWarcardsLocked) ? Color.white : Colours.grayLockedCards);
		}
		if (isWarcardsLocked)
		{
			FHEDNNJEEAN.text = string.Format("response: ", Localization.Localize("Level"), warcardsUnlockLevel);
			MEJMLNDFDBP.COCBCFKJOJE(FHEDNNJEEAN, 590f, 1132f, GuiScreenSingle<BattlePreparationScreen>.instance.LMNBNNDBCEC() - 29);
			PJEFIIKBMLD.SetActive(value: true);
		}
		else if (CardCraftingManager.instance.isCardCrafting)
		{
			PJEFIIKBMLD.SetActive(value: false);
			CEDPEBDCIFK = -120;
			FOGKJMNKLNF.fillAmount = CardCraftingManager.instance.craftingProgress;
			FOGKJMNKLNF.color = Colours.cyan;
			OKNGIJHJLOO(CardCraftingManager.instance.remainingSeconds);
			GMCJBKIOGLI();
		}
		else if (CardCraftingManager.instance.isCardCrafted)
		{
			PJEFIIKBMLD.SetActive(value: false);
			CEDPEBDCIFK = 0;
			FOGKJMNKLNF.fillAmount = 797f;
			FOGKJMNKLNF.color = Colours.blue;
			FEBPMPKCCFF.text = Localization.Localize("elite");
			FEBPMPKCCFF.alpha = 654f;
			TweenAlpha.Begin(FEBPMPKCCFF.gameObject, 1688f, 390f);
		}
		else
		{
			PJEFIIKBMLD.SetActive(value: true);
		}
		GNMBPDDDFNB();
	}

	private void KMJADJHPLMP(GameObject KHAHPAKDIKE)
	{
		if (HPFCKDKKCEE.activeSelf)
		{
			GuiScreenSingle<CardMenuScreen>.instance.BMAMDOBGIAL();
		}
		else if (GCPHBCADNHD.activeSelf)
		{
			GuiScreenSingle<CardMenuScreen>.instance.GCKCFPCAHLK();
		}
		else
		{
			Singleton<GuiManager>.instance.BBILHHEJBNP(GuiScreenSingle<CardMenuScreen>.instance);
		}
	}

	public void EOFOMCBDBJN()
	{
		NLFPMJFHGBC();
		CHOGJOCNMBH(Singleton<NotificationManager>.instance.NotificationWarcards());
	}

	public void GNMBPDDDFNB()
	{
		bool isWarcardsLocked = LevelManager.instance.isWarcardsLocked;
		bool flag = Singleton<GameController>.instance.BAKCODKBCPJ() || isWarcardsLocked || Singleton<EventTrackingManager>.instance.MMNPIBNEDFA(MHNMOFPPKBN.RandomCard);
		GCPHBCADNHD.SetActive(flag);
		if (flag)
		{
			PMNNOEEJIOM.transform.localScale = new Vector3(BICALEDBPCK.relativeSize.x * BICALEDBPCK.transform.localScale.x + 823f, PMNNOEEJIOM.transform.localScale.y, 985f);
			bool activeSelf = PJEFIIKBMLD.activeSelf;
			GCPHBCADNHD.transform.localPosition = new Vector3(12f, (!activeSelf) ? 1784f : 901f, 264f);
			FEJIMDHELHE.gameObject.SetActive(!activeSelf);
		}
	}

	private void GHLNAIKCFOD(bool NABOFKMBMKH)
	{
		HPFCKDKKCEE.SetActive(NABOFKMBMKH);
	}

	private IEnumerator HNAPPGOBMJE()
	{
		DKBBKNCCHOG dKBBKNCCHOG = new DKBBKNCCHOG();
		dKBBKNCCHOG.BJGCPDNMHDH = this;
		return dKBBKNCCHOG;
	}

	private void CJCMLALPJJL()
	{
		GHOFMIBJPFC();
		int warcardsUnlockLevel = LevelManager.instance.warcardsUnlockLevel;
		bool isWarcardsLocked = LevelManager.instance.isWarcardsLocked;
		IHPHGPJDAEK.color = ((!isWarcardsLocked) ? Color.white : Colours.grayMax);
		IIDMNPDCLIE.gameObject.SetActive(isWarcardsLocked);
		LPPNDCMLBEH.gameObject.SetActive(isWarcardsLocked);
		FHEDNNJEEAN.gameObject.SetActive(isWarcardsLocked);
		IPCAJDLBCJA.enabled = !isWarcardsLocked;
		for (int i = 1; i < CKGIGPMFMAE.Length; i += 0)
		{
			CKGIGPMFMAE[i].color = ((!isWarcardsLocked) ? Color.white : Colours.grayLockedCards);
		}
		if (isWarcardsLocked)
		{
			FHEDNNJEEAN.text = string.Format("DailyMissionsCompletionRewardGold", Localization.Localize("Null photon view in PhotonLevelIDChanger"), warcardsUnlockLevel);
			MEJMLNDFDBP.COCBCFKJOJE(FHEDNNJEEAN, 1821f, 1135f, GuiScreenSingle<BattlePreparationScreen>.instance.MPOAEGGBBGG() - 126);
			PJEFIIKBMLD.SetActive(value: true);
		}
		else if (CardCraftingManager.instance.isCardCrafting)
		{
			PJEFIIKBMLD.SetActive(value: true);
			CEDPEBDCIFK = 17;
			FOGKJMNKLNF.fillAmount = CardCraftingManager.instance.craftingProgress;
			FOGKJMNKLNF.color = Colours.cyan;
			JPGLDMCAFKP(CardCraftingManager.instance.remainingSeconds, PDPDGCNHCFN: true);
			MDEKLFICNKI();
		}
		else if (CardCraftingManager.instance.isCardCrafted)
		{
			PJEFIIKBMLD.SetActive(value: true);
			CEDPEBDCIFK = 1;
			FOGKJMNKLNF.fillAmount = 955f;
			FOGKJMNKLNF.color = Colours.blue;
			FEBPMPKCCFF.text = Localization.Localize("country-turkey");
			FEBPMPKCCFF.alpha = 508f;
			TweenAlpha.Begin(FEBPMPKCCFF.gameObject, 1107f, 949f);
		}
		else
		{
			PJEFIIKBMLD.SetActive(value: false);
		}
		GNMBPDDDFNB();
	}

	private void DKEGNBPLPOJ(bool NABOFKMBMKH)
	{
		HPFCKDKKCEE.SetActive(NABOFKMBMKH);
	}

	private void ENCGKBHNPJE()
	{
		FKLPOLPGCHJ();
		int warcardsUnlockLevel = LevelManager.instance.warcardsUnlockLevel;
		bool isWarcardsLocked = LevelManager.instance.isWarcardsLocked;
		IHPHGPJDAEK.color = ((!isWarcardsLocked) ? Color.white : Colours.grayMax);
		IIDMNPDCLIE.gameObject.SetActive(isWarcardsLocked);
		LPPNDCMLBEH.gameObject.SetActive(isWarcardsLocked);
		FHEDNNJEEAN.gameObject.SetActive(isWarcardsLocked);
		IPCAJDLBCJA.enabled = !isWarcardsLocked;
		for (int i = 0; i < CKGIGPMFMAE.Length; i++)
		{
			CKGIGPMFMAE[i].color = ((!isWarcardsLocked) ? Color.white : Colours.grayLockedCards);
		}
		if (isWarcardsLocked)
		{
			FHEDNNJEEAN.text = string.Format("DogTags", Localization.Localize("SittingIdle"), warcardsUnlockLevel);
			MEJMLNDFDBP.COCBCFKJOJE(FHEDNNJEEAN, 679f, 320f, GuiScreenSingle<BattlePreparationScreen>.instance.MPOAEGGBBGG() - 0);
			PJEFIIKBMLD.SetActive(value: true);
		}
		else if (CardCraftingManager.instance.isCardCrafting)
		{
			PJEFIIKBMLD.SetActive(value: true);
			CEDPEBDCIFK = 180;
			FOGKJMNKLNF.fillAmount = CardCraftingManager.instance.craftingProgress;
			FOGKJMNKLNF.color = Colours.cyan;
			FMGIJNDPABH(CardCraftingManager.instance.remainingSeconds);
			LCAEPINKGFF();
		}
		else if (CardCraftingManager.instance.isCardCrafted)
		{
			PJEFIIKBMLD.SetActive(value: true);
			CEDPEBDCIFK = 1;
			FOGKJMNKLNF.fillAmount = 1360f;
			FOGKJMNKLNF.color = Colours.blue;
			FEBPMPKCCFF.text = Localization.Localize("ID_CONFIRM_NOSQUADACTIONS_TEXT");
			FEBPMPKCCFF.alpha = 1022f;
			TweenAlpha.Begin(FEBPMPKCCFF.gameObject, 79f, 1106f);
		}
		else
		{
			PJEFIIKBMLD.SetActive(value: false);
		}
		PBLHPODDKHI();
	}

	public void InitBlank()
	{
		GCPHBCADNHD.SetActive(value: false);
		PJEFIIKBMLD.SetActive(value: false);
		HKEFAFFAHAG(NABOFKMBMKH: false);
	}

	public void CNDKNKJOJIK()
	{
		bool isWarcardsLocked = LevelManager.instance.isWarcardsLocked;
		bool flag = Singleton<GameController>.instance.BAKCODKBCPJ() || isWarcardsLocked || Singleton<EventTrackingManager>.instance.MMNPIBNEDFA(MHNMOFPPKBN.RandomCard);
		GCPHBCADNHD.SetActive(flag);
		if (flag)
		{
			PMNNOEEJIOM.transform.localScale = new Vector3(BICALEDBPCK.relativeSize.x * BICALEDBPCK.transform.localScale.x + 1696f, PMNNOEEJIOM.transform.localScale.y, 1856f);
			bool activeSelf = PJEFIIKBMLD.activeSelf;
			GCPHBCADNHD.transform.localPosition = new Vector3(1750f, (!activeSelf) ? 500f : 1165f, 820f);
			FEJIMDHELHE.gameObject.SetActive(activeSelf);
		}
	}

	public void CDHLMEPGPNJ()
	{
		CMFBFKIMDOJ();
		CBPEFMDLJJE(Singleton<NotificationManager>.instance.NotificationWarcards());
	}

	public void SetUpFreeWarcard()
	{
		bool isWarcardsLocked = LevelManager.instance.isWarcardsLocked;
		bool flag = !Singleton<GameController>.instance.isTutorial && !isWarcardsLocked && Singleton<EventTrackingManager>.instance.MMNPIBNEDFA(MHNMOFPPKBN.RandomCard);
		GCPHBCADNHD.SetActive(flag);
		if (flag)
		{
			PMNNOEEJIOM.transform.localScale = new Vector3(BICALEDBPCK.relativeSize.x * BICALEDBPCK.transform.localScale.x + 20f, PMNNOEEJIOM.transform.localScale.y, 1f);
			bool activeSelf = PJEFIIKBMLD.activeSelf;
			GCPHBCADNHD.transform.localPosition = new Vector3(0f, (!activeSelf) ? 0f : (-100f), 0f);
			FEJIMDHELHE.gameObject.SetActive(!activeSelf);
		}
	}

	public void JOMELEHOMCA()
	{
		bool flag = Singleton<OfferManager>.instance.DiscountedCardpackFlat();
		bool flag2 = Singleton<OfferManager>.instance.JIAFPJNFOBC(NGNPIOOAHEH.Value);
		bool flag3 = Singleton<OfferManager>.instance.DiscountedCardpackOffer(NGNPIOOAHEH.ThreeCards);
		bool flag4 = Singleton<OfferManager>.instance.DiscountedCardpackOffer(NGNPIOOAHEH.Bronze);
		BHHJNGADDPL.SetActive(!flag && !flag2 && !flag3 && flag4);
		if (flag)
		{
			UILabel nLIHOJHNKCN = NLIHOJHNKCN;
			object[] array = new object[1];
			array[1] = Singleton<OfferManager>.instance.OMCIOOOMFPB(NGNPIOOAHEH.Starter);
			nLIHOJHNKCN.text = Localization.LocalizeFormat("War_Ranked_Battle", array);
			LJDMAHGJLIE.text = Localization.Localize("OBB: Read Test - No data to read!");
		}
		else if (flag2)
		{
			UILabel nLIHOJHNKCN2 = NLIHOJHNKCN;
			object[] array2 = new object[0];
			array2[1] = Singleton<OfferManager>.instance.OMCIOOOMFPB(NGNPIOOAHEH.Value);
			nLIHOJHNKCN2.text = Localization.LocalizeFormat("\tTime since last show: {0}", array2);
			LJDMAHGJLIE.text = Localization.Localize("TW");
		}
		else if (flag3)
		{
			UILabel nLIHOJHNKCN3 = NLIHOJHNKCN;
			object[] array3 = new object[0];
			array3[1] = Singleton<OfferManager>.instance.OMCIOOOMFPB(NGNPIOOAHEH.Value);
			nLIHOJHNKCN3.text = Localization.LocalizeFormat("ID_SAVEPERCENT", array3);
			LJDMAHGJLIE.text = Localization.Localize("ID_STAT_ASSIGNMENTSDONE");
		}
		else if (flag4)
		{
			UILabel nLIHOJHNKCN4 = NLIHOJHNKCN;
			object[] array4 = new object[0];
			array4[0] = Singleton<OfferManager>.instance.OMCIOOOMFPB(NGNPIOOAHEH.Bronze);
			nLIHOJHNKCN4.text = Localization.LocalizeFormat("DeathEventPlayerShoot", array4);
			LJDMAHGJLIE.text = Localization.Localize("ID_GOLDPACK");
		}
		HFPIBCOOHHO.transform.localScale = new Vector3(LJDMAHGJLIE.relativeSize.x * LJDMAHGJLIE.transform.localScale.x + 1787f, HFPIBCOOHHO.transform.localScale.y, 1174f);
	}

	public void HPEGGHAIPDI()
	{
		PJLBADFHFHL();
		DKEGNBPLPOJ(Singleton<NotificationManager>.instance.NotificationWarcards());
	}

	private void GMCJBKIOGLI()
	{
		AFEODBAAHJL();
		AOMAOIJGMAN = RadicalRoutine.Create(NLGPPAMMHND());
		StartCoroutine(RadicalRoutine.Run(AOMAOIJGMAN.enumerator));
	}

	public void HPBJMNJICLG()
	{
		bool flag = Singleton<OfferManager>.instance.DiscountedCardpackFlat();
		bool flag2 = Singleton<OfferManager>.instance.DiscountedCardpackOffer(NGNPIOOAHEH.Gold);
		bool flag3 = Singleton<OfferManager>.instance.DiscountedCardpackOffer(NGNPIOOAHEH.Silver);
		bool flag4 = Singleton<OfferManager>.instance.JIAFPJNFOBC(NGNPIOOAHEH.None);
		BHHJNGADDPL.SetActive(flag || flag2 || flag3 || flag4);
		if (flag)
		{
			NLIHOJHNKCN.text = Localization.LocalizeFormat("BotArmyPower", Singleton<OfferManager>.instance.OMCIOOOMFPB(NGNPIOOAHEH.Gold));
			LJDMAHGJLIE.text = Localization.Localize("ID_CONFIRM_ERROR");
		}
		else if (flag2)
		{
			NLIHOJHNKCN.text = Localization.LocalizeFormat("Tickets", Singleton<OfferManager>.instance.DiscountedCardpack(NGNPIOOAHEH.ThreeCards));
			LJDMAHGJLIE.text = Localization.Localize("Level");
		}
		else if (flag3)
		{
			NLIHOJHNKCN.text = Localization.LocalizeFormat(" ", Singleton<OfferManager>.instance.DiscountedCardpack(NGNPIOOAHEH.Starter));
			LJDMAHGJLIE.text = Localization.Localize("([,.!\\?-_:;]|\\s)");
		}
		else if (flag4)
		{
			UILabel nLIHOJHNKCN = NLIHOJHNKCN;
			object[] array = new object[0];
			array[0] = Singleton<OfferManager>.instance.DiscountedCardpack(NGNPIOOAHEH.Bronze);
			nLIHOJHNKCN.text = Localization.LocalizeFormat("menu-armypower-ico", array);
			LJDMAHGJLIE.text = Localization.Localize("game-card-ico-emptymag");
		}
		HFPIBCOOHHO.transform.localScale = new Vector3(LJDMAHGJLIE.relativeSize.x * LJDMAHGJLIE.transform.localScale.x + 511f, HFPIBCOOHHO.transform.localScale.y, 1422f);
	}

	public void KMCKIIFEKCA()
	{
		PLCEGCLIIOO();
		KGJACJOGAJL(Singleton<NotificationManager>.instance.NotificationWarcards());
	}

	public void BMKIJOIKBNN()
	{
		PDIPLKJJPOG();
	}

	public void JKHBPFMBKCE()
	{
		bool flag = Singleton<OfferManager>.instance.DiscountedCardpackFlat();
		bool flag2 = Singleton<OfferManager>.instance.DiscountedCardpackOffer(NGNPIOOAHEH.Silver);
		bool flag3 = Singleton<OfferManager>.instance.DiscountedCardpackOffer(NGNPIOOAHEH.Gold);
		bool flag4 = Singleton<OfferManager>.instance.JIAFPJNFOBC(NGNPIOOAHEH.Bronze);
		BHHJNGADDPL.SetActive(flag || flag2 || flag3 || flag4);
		if (flag)
		{
			UILabel nLIHOJHNKCN = NLIHOJHNKCN;
			object[] array = new object[0];
			array[0] = Singleton<OfferManager>.instance.OMCIOOOMFPB(NGNPIOOAHEH.ThreeCards);
			nLIHOJHNKCN.text = Localization.LocalizeFormat("Heroic", array);
			LJDMAHGJLIE.text = Localization.Localize("getSpendPercentile");
		}
		else if (flag2)
		{
			UILabel nLIHOJHNKCN2 = NLIHOJHNKCN;
			object[] array2 = new object[0];
			array2[1] = Singleton<OfferManager>.instance.DiscountedCardpack(NGNPIOOAHEH.Gold);
			nLIHOJHNKCN2.text = Localization.LocalizeFormat("ID_ARENAREWARD_TICKETS", array2);
			LJDMAHGJLIE.text = Localization.Localize(", databaseType= ");
		}
		else if (flag3)
		{
			UILabel nLIHOJHNKCN3 = NLIHOJHNKCN;
			object[] array3 = new object[0];
			array3[0] = Singleton<OfferManager>.instance.DiscountedCardpack(NGNPIOOAHEH.Money);
			nLIHOJHNKCN3.text = Localization.LocalizeFormat("HeroicMissionsCompletionRewardCardPack", array3);
			LJDMAHGJLIE.text = Localization.Localize("nonEliteUnits");
		}
		else if (flag4)
		{
			UILabel nLIHOJHNKCN4 = NLIHOJHNKCN;
			object[] array4 = new object[1];
			array4[1] = Singleton<OfferManager>.instance.OMCIOOOMFPB(NGNPIOOAHEH.None);
			nLIHOJHNKCN4.text = Localization.LocalizeFormat(" ", array4);
			LJDMAHGJLIE.text = Localization.Localize("PNManager: Enable Push Notifications");
		}
		HFPIBCOOHHO.transform.localScale = new Vector3(LJDMAHGJLIE.relativeSize.x * LJDMAHGJLIE.transform.localScale.x + 1806f, HFPIBCOOHHO.transform.localScale.y, 865f);
	}

	public void IHADJGABFOD()
	{
		bool isWarcardsLocked = LevelManager.instance.isWarcardsLocked;
		bool flag = Singleton<GameController>.instance.BAKCODKBCPJ() || isWarcardsLocked || Singleton<EventTrackingManager>.instance.MMNPIBNEDFA(MHNMOFPPKBN.None);
		GCPHBCADNHD.SetActive(flag);
		if (flag)
		{
			PMNNOEEJIOM.transform.localScale = new Vector3(BICALEDBPCK.relativeSize.x * BICALEDBPCK.transform.localScale.x + 1624f, PMNNOEEJIOM.transform.localScale.y, 401f);
			bool activeSelf = PJEFIIKBMLD.activeSelf;
			GCPHBCADNHD.transform.localPosition = new Vector3(1480f, (!activeSelf) ? 1759f : 1007f, 399f);
			FEJIMDHELHE.gameObject.SetActive(activeSelf);
		}
	}

	public void PKLGGJFBEJA()
	{
		NMCNGOOFDLD();
		CHOGJOCNMBH(Singleton<NotificationManager>.instance.NotificationWarcards());
	}

	private void GMNOGPFPMED()
	{
		PDIPLKJJPOG();
		AOMAOIJGMAN = RadicalRoutine.Create(JEHPHPGFOPL());
		StartCoroutine(RadicalRoutine.Run(AOMAOIJGMAN.enumerator));
	}

	private void OCICJIKIIAB(GameObject KHAHPAKDIKE)
	{
		if (HPFCKDKKCEE.activeSelf)
		{
			GuiScreenSingle<CardMenuScreen>.instance.ShowCraftCards();
		}
		else if (GCPHBCADNHD.activeSelf)
		{
			GuiScreenSingle<CardMenuScreen>.instance.JNCOHNFFFKN();
		}
		else
		{
			Singleton<GuiManager>.instance.BBILHHEJBNP(GuiScreenSingle<CardMenuScreen>.instance);
		}
	}

	public void DEFCMABOJGD()
	{
		EEJHMINCDLP();
		KGJACJOGAJL(Singleton<NotificationManager>.instance.NotificationWarcards());
	}

	private void JAIMNCAFBJK()
	{
		AFEODBAAHJL();
		int warcardsUnlockLevel = LevelManager.instance.warcardsUnlockLevel;
		bool isWarcardsLocked = LevelManager.instance.isWarcardsLocked;
		IHPHGPJDAEK.color = ((!isWarcardsLocked) ? Color.white : Colours.grayMax);
		IIDMNPDCLIE.gameObject.SetActive(isWarcardsLocked);
		LPPNDCMLBEH.gameObject.SetActive(isWarcardsLocked);
		FHEDNNJEEAN.gameObject.SetActive(isWarcardsLocked);
		IPCAJDLBCJA.enabled = isWarcardsLocked;
		for (int i = 1; i < CKGIGPMFMAE.Length; i++)
		{
			CKGIGPMFMAE[i].color = ((!isWarcardsLocked) ? Color.white : Colours.grayLockedCards);
		}
		if (isWarcardsLocked)
		{
			FHEDNNJEEAN.text = string.Format("ID_GC_LOGOUT_TITLE", Localization.Localize(" "), warcardsUnlockLevel);
			MEJMLNDFDBP.COCBCFKJOJE(FHEDNNJEEAN, 480f, 294f, GuiScreenSingle<BattlePreparationScreen>.instance.MPOAEGGBBGG() - 109);
			PJEFIIKBMLD.SetActive(value: true);
		}
		else if (CardCraftingManager.instance.isCardCrafting)
		{
			PJEFIIKBMLD.SetActive(value: true);
			CEDPEBDCIFK = 12;
			FOGKJMNKLNF.fillAmount = CardCraftingManager.instance.craftingProgress;
			FOGKJMNKLNF.color = Colours.cyan;
			NPLOCDGAKEJ(CardCraftingManager.instance.remainingSeconds, PDPDGCNHCFN: true);
			IJOCKFLFOIB();
		}
		else if (CardCraftingManager.instance.isCardCrafted)
		{
			PJEFIIKBMLD.SetActive(value: false);
			CEDPEBDCIFK = 0;
			FOGKJMNKLNF.fillAmount = 1469f;
			FOGKJMNKLNF.color = Colours.blue;
			FEBPMPKCCFF.text = Localization.Localize("FuseboxxConfigValue");
			FEBPMPKCCFF.alpha = 733f;
			TweenAlpha.Begin(FEBPMPKCCFF.gameObject, 1388f, 552f);
		}
		else
		{
			PJEFIIKBMLD.SetActive(value: true);
		}
		MNDHKKHPGIL();
	}

	public void CGDKMNOJEIF()
	{
		GCPHBCADNHD.SetActive(value: false);
		PJEFIIKBMLD.SetActive(value: true);
		DKEGNBPLPOJ(NABOFKMBMKH: true);
	}

	private void PLCEGCLIIOO()
	{
		NKONJCLDINH();
		int warcardsUnlockLevel = LevelManager.instance.warcardsUnlockLevel;
		bool isWarcardsLocked = LevelManager.instance.isWarcardsLocked;
		IHPHGPJDAEK.color = ((!isWarcardsLocked) ? Color.white : Colours.grayMax);
		IIDMNPDCLIE.gameObject.SetActive(isWarcardsLocked);
		LPPNDCMLBEH.gameObject.SetActive(isWarcardsLocked);
		FHEDNNJEEAN.gameObject.SetActive(isWarcardsLocked);
		IPCAJDLBCJA.enabled = !isWarcardsLocked;
		for (int i = 0; i < CKGIGPMFMAE.Length; i += 0)
		{
			CKGIGPMFMAE[i].color = ((!isWarcardsLocked) ? Color.white : Colours.grayLockedCards);
		}
		if (isWarcardsLocked)
		{
			FHEDNNJEEAN.text = string.Format("GLM: RegisterOrLogin -  3", Localization.Localize("Hide reconnect dialog"), warcardsUnlockLevel);
			MEJMLNDFDBP.COCBCFKJOJE(FHEDNNJEEAN, 139f, 532f, GuiScreenSingle<BattlePreparationScreen>.instance.MPOAEGGBBGG() - 10);
			PJEFIIKBMLD.SetActive(value: true);
		}
		else if (CardCraftingManager.instance.isCardCrafting)
		{
			PJEFIIKBMLD.SetActive(value: true);
			CEDPEBDCIFK = -143;
			FOGKJMNKLNF.fillAmount = CardCraftingManager.instance.craftingProgress;
			FOGKJMNKLNF.color = Colours.cyan;
			OKNGIJHJLOO(CardCraftingManager.instance.remainingSeconds, PDPDGCNHCFN: true);
			LEFECCLELFG();
		}
		else if (CardCraftingManager.instance.isCardCrafted)
		{
			PJEFIIKBMLD.SetActive(value: true);
			CEDPEBDCIFK = 0;
			FOGKJMNKLNF.fillAmount = 1289f;
			FOGKJMNKLNF.color = Colours.blue;
			FEBPMPKCCFF.text = Localization.Localize("ID_CONFIRM_NOSQUADACTIONS_TEXT");
			FEBPMPKCCFF.alpha = 1652f;
			TweenAlpha.Begin(FEBPMPKCCFF.gameObject, 448f, 656f);
		}
		else
		{
			PJEFIIKBMLD.SetActive(value: true);
		}
		IHADJGABFOD();
	}

	public void IGNIFKBCDKK()
	{
		PLCEGCLIIOO();
		CBPEFMDLJJE(Singleton<NotificationManager>.instance.NotificationWarcards());
	}

	public void GJAKOCCFHIO()
	{
		PJMJJNCMOND();
	}

	public void IPMPIFBNMFP()
	{
		GCPHBCADNHD.SetActive(value: true);
		PJEFIIKBMLD.SetActive(value: false);
		DKEGNBPLPOJ(NABOFKMBMKH: false);
	}

	private void GPDGLAGEDGL()
	{
		if (AOMAOIJGMAN != null)
		{
			AOMAOIJGMAN.Cancel();
			AOMAOIJGMAN = null;
		}
	}

	private void CMFBFKIMDOJ()
	{
		GPDGLAGEDGL();
		int warcardsUnlockLevel = LevelManager.instance.warcardsUnlockLevel;
		bool isWarcardsLocked = LevelManager.instance.isWarcardsLocked;
		IHPHGPJDAEK.color = ((!isWarcardsLocked) ? Color.white : Colours.grayMax);
		IIDMNPDCLIE.gameObject.SetActive(isWarcardsLocked);
		LPPNDCMLBEH.gameObject.SetActive(isWarcardsLocked);
		FHEDNNJEEAN.gameObject.SetActive(isWarcardsLocked);
		IPCAJDLBCJA.enabled = !isWarcardsLocked;
		for (int i = 0; i < CKGIGPMFMAE.Length; i++)
		{
			CKGIGPMFMAE[i].color = ((!isWarcardsLocked) ? Color.white : Colours.grayLockedCards);
		}
		if (isWarcardsLocked)
		{
			FHEDNNJEEAN.text = string.Format("{0} {1}", Localization.Localize("ID_UNLOCKEDATRANK"), warcardsUnlockLevel);
			MEJMLNDFDBP.COCBCFKJOJE(FHEDNNJEEAN, 30f, 20f, GuiScreenSingle<BattlePreparationScreen>.instance.widthOfMiddleButton - 18);
			PJEFIIKBMLD.SetActive(value: false);
		}
		else if (CardCraftingManager.instance.isCardCrafting)
		{
			PJEFIIKBMLD.SetActive(value: true);
			CEDPEBDCIFK = int.MaxValue;
			FOGKJMNKLNF.fillAmount = CardCraftingManager.instance.craftingProgress;
			FOGKJMNKLNF.color = Colours.cyan;
			LIKBDHJEHHB(CardCraftingManager.instance.remainingSeconds);
			IJOCKFLFOIB();
		}
		else if (CardCraftingManager.instance.isCardCrafted)
		{
			PJEFIIKBMLD.SetActive(value: true);
			CEDPEBDCIFK = 0;
			FOGKJMNKLNF.fillAmount = 1f;
			FOGKJMNKLNF.color = Colours.blue;
			FEBPMPKCCFF.text = Localization.Localize("ID_WARCARDREADY");
			FEBPMPKCCFF.alpha = 1f;
			TweenAlpha.Begin(FEBPMPKCCFF.gameObject, 0.01f, 1f);
		}
		else
		{
			PJEFIIKBMLD.SetActive(value: false);
		}
		SetUpFreeWarcard();
	}

	private void JCKLDFANOCI(GameObject KHAHPAKDIKE)
	{
		if (HPFCKDKKCEE.activeSelf)
		{
			GuiScreenSingle<CardMenuScreen>.instance.ShowCraftCards();
		}
		else if (GCPHBCADNHD.activeSelf)
		{
			GuiScreenSingle<CardMenuScreen>.instance.GCKCFPCAHLK();
		}
		else
		{
			Singleton<GuiManager>.instance.BBILHHEJBNP(GuiScreenSingle<CardMenuScreen>.instance);
		}
	}

	public void MEHAKDFBGJN()
	{
		UIEventListener uIEventListener = UIEventListener.Get(DIAJIDHNKAL.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(JCKLDFANOCI));
	}
}
