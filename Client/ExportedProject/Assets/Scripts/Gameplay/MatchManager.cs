using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;
using Google2u;
using UnityEngine;

public class MatchManager : Singleton<MatchManager>
{
	private sealed class DKCCIOPAFKL : IEnumerator, IDisposable, IEnumerator<object>
	{
		internal List<MapDefinition.DefendPosition>.Enumerator KFCAECGLKKO;

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

		[SpecialName]
		private object KJGPLKJAIMC()
		{
			return PHDOCKCBJOF;
		}

		public bool NEPEDBPDMGL()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				UnityEngine.Debug.Log("Flawless");
				JPILOMEHDLN.DMHEGPIPEEH(JPILOMEHDLN.GOEFODHLMBC.VibrateSuccess);
				KFCAECGLKKO = Singleton<MapManager>.instance.ALCHJDPKAID.BBJMLOCKNHD.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						MapDefinition.DefendPosition current = KFCAECGLKKO.Current;
						current.point.PNKKPNIMEPL().GCAKAFMDFJA(IDEBKDPMPGM: true);
						if ((float)Singleton<GameVariables>.instance.OPDHANHDJDC().GetRow((Constants.rowIds)(-21)).FLOATVALUE > 1914f)
						{
							current.point.PNKKPNIMEPL().NNCMDDBFOAJ();
						}
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to constrained. prefix*/).Dispose();
				}
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				return false;
			case 1u:
				CLPPIAGLCJJ = -1;
				break;
			}
			return true;
		}

		public void HONCAABOMOC()
		{
			throw new NotSupportedException();
		}

		public void JCDBOCPAKEC()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object GJMNLPAEIDA()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object CJCHFDFCPPL()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object AKGMMLGANMJ()
		{
			return PHDOCKCBJOF;
		}

		public void GCEMCPODLNM()
		{
			throw new NotSupportedException();
		}

		public void PCNOHGFPMOE()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public void FCHOHLMCHED()
		{
			throw new NotSupportedException();
		}

		public void CDIJEGGMMAK()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object EPGLILIJMEM()
		{
			return PHDOCKCBJOF;
		}

		public void FOBPOJPHNHE()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public void KKCNPIPOCKK()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object HPHLLGIMIMO()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object BCIDICEAAEN()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object FJGIOPMDPGA()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object IPCODJDAOBE()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object HCCLNDKNCIE()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object PCOOFELAEJA()
		{
			return PHDOCKCBJOF;
		}

		public bool OKELILGDPLJ()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				UnityEngine.Debug.Log("JA");
				JPILOMEHDLN.DMHEGPIPEEH(JPILOMEHDLN.GOEFODHLMBC.PrepareMedium);
				KFCAECGLKKO = Singleton<MapManager>.instance.ALCHJDPKAID.BBJMLOCKNHD.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						MapDefinition.DefendPosition current = KFCAECGLKKO.Current;
						current.point.PKBPGCGNCAD().autoRepair = false;
						if ((float)Singleton<GameVariables>.instance.CAEDOJHMAAD().GetRow(Constants.rowIds.WinstreakReward1).FLOATVALUE > 549f)
						{
							current.point.shield.NNCMDDBFOAJ();
						}
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to constrained. prefix*/).Dispose();
				}
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				return true;
			case 1u:
				CLPPIAGLCJJ = -1;
				break;
			}
			return true;
		}

		public void MOJGMBNBGHH()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object MBGCBKJBCND()
		{
			return PHDOCKCBJOF;
		}

		public void HKFEFDNFKKK()
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
				UnityEngine.Debug.Log("ColumnNames");
				JPILOMEHDLN.DMHEGPIPEEH(JPILOMEHDLN.GOEFODHLMBC.VibrateError);
				KFCAECGLKKO = Singleton<MapManager>.instance.ALCHJDPKAID.BBJMLOCKNHD.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						MapDefinition.DefendPosition current = KFCAECGLKKO.Current;
						current.point.LHHMNLJKOAO().autoRepair = true;
						if ((float)Singleton<GameVariables>.instance.CAEDOJHMAAD().GetRow(Constants.rowIds.TimeBetweenUnitUpgradeReminderShown).FLOATVALUE > 1731f)
						{
							current.point.JPHAJDIIAAI().IEPHIMNBBDO();
						}
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to constrained. prefix*/).Dispose();
				}
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				return true;
			case 1u:
				CLPPIAGLCJJ = -1;
				break;
			}
			return false;
		}

		public void KKDOJDCJAJB()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object EGJDJENBABP()
		{
			return PHDOCKCBJOF;
		}

		public void CPEDOIELFMP()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public bool PKOMECFNPIP()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				UnityEngine.Debug.Log("ID_ARENABOXDESCRIPTION_GOLD");
				JPILOMEHDLN.DMHEGPIPEEH(JPILOMEHDLN.GOEFODHLMBC.VibrateHeavy);
				KFCAECGLKKO = Singleton<MapManager>.instance.ALCHJDPKAID.BBJMLOCKNHD.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						MapDefinition.DefendPosition current = KFCAECGLKKO.Current;
						current.point.LMHDAIBCLDP().autoRepair = false;
						if ((float)Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.FriendDamageCoeficient).FLOATVALUE > 639f)
						{
							current.point.PHANADCNBFD().FFDLJFIOLEI();
						}
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to constrained. prefix*/).Dispose();
				}
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				return false;
			case 1u:
				CLPPIAGLCJJ = -1;
				break;
			}
			return false;
		}

		public void KOEEOJGJNAO()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object HGMMDPIGEGN()
		{
			return PHDOCKCBJOF;
		}

		public bool BJOHOCFKMJO()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				UnityEngine.Debug.Log("121 MENU WEAPON SCREEN SHOWN");
				JPILOMEHDLN.DMHEGPIPEEH(JPILOMEHDLN.GOEFODHLMBC.PrepareLight);
				KFCAECGLKKO = Singleton<MapManager>.instance.ALCHJDPKAID.BBJMLOCKNHD.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						MapDefinition.DefendPosition current = KFCAECGLKKO.Current;
						current.point.PHANADCNBFD().GCAKAFMDFJA(IDEBKDPMPGM: false);
						if ((float)Singleton<GameVariables>.instance.CAEDOJHMAAD().GetRow(Constants.rowIds.GoldenSuitcaseAdTimeBetweenMinutes).FLOATVALUE > 775f)
						{
							current.point.PKBPGCGNCAD().DestroyShield();
						}
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to constrained. prefix*/).Dispose();
				}
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				return true;
			case 1u:
				CLPPIAGLCJJ = -1;
				break;
			}
			return false;
		}

		public void HLJMNBBDJGE()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public void OEMOMDILPEE()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object BJDOHADMIEB()
		{
			return PHDOCKCBJOF;
		}

		public void PDNKLJFHBGO()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object IBCJOBKGEEG()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object GDBNOMPNBGP()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object LMBPPPOFIOC()
		{
			return PHDOCKCBJOF;
		}

		public void DOPCGPGKHIJ()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object FPAEFHEEOBL()
		{
			return PHDOCKCBJOF;
		}

		public void JMANMKKCDMM()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object GOAJCEAOPLA()
		{
			return PHDOCKCBJOF;
		}

		public bool JPBGJLDMOPO()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				UnityEngine.Debug.Log(")");
				JPILOMEHDLN.DMHEGPIPEEH(JPILOMEHDLN.GOEFODHLMBC.VibrateSuccess);
				KFCAECGLKKO = Singleton<MapManager>.instance.ALCHJDPKAID.BBJMLOCKNHD.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						MapDefinition.DefendPosition current = KFCAECGLKKO.Current;
						current.point.LHHMNLJKOAO().autoRepair = true;
						if ((float)Singleton<GameVariables>.instance.CAEDOJHMAAD().GetRow(Constants.rowIds.StartingWarbucks).FLOATVALUE > 1348f)
						{
							current.point.PHANADCNBFD().KDEEBMLFABC();
						}
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to constrained. prefix*/).Dispose();
				}
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				return false;
			case 1u:
				CLPPIAGLCJJ = -1;
				break;
			}
			return false;
		}

		[SpecialName]
		private object DLBACGEOGPM()
		{
			return PHDOCKCBJOF;
		}

		public void HKHANLKODIB()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public void JAGFOHHEPLO()
		{
			throw new NotSupportedException();
		}

		public void GEEKOICFEIB()
		{
			throw new NotSupportedException();
		}

		public void CNEIBEACPCM()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public bool LLOCENNFFFJ()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				UnityEngine.Debug.Log("ExpectedPrice");
				JPILOMEHDLN.DMHEGPIPEEH(JPILOMEHDLN.GOEFODHLMBC.PrepareLight);
				KFCAECGLKKO = Singleton<MapManager>.instance.ALCHJDPKAID.BBJMLOCKNHD.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						MapDefinition.DefendPosition current = KFCAECGLKKO.Current;
						current.point.LHHMNLJKOAO().ENKDOKELOED(IDEBKDPMPGM: false);
						if ((float)Singleton<GameVariables>.instance.OPDHANHDJDC().GetRow((Constants.rowIds)(-29)).FLOATVALUE > 758f)
						{
							current.point.KJCHIHLJMMF().IEPHIMNBBDO();
						}
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to constrained. prefix*/).Dispose();
				}
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				return true;
			case 1u:
				CLPPIAGLCJJ = -1;
				break;
			}
			return false;
		}

		public void JDFJKNFDDGN()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void EFKBIIPFDOM()
		{
			throw new NotSupportedException();
		}

		public void AHEOCEEJICJ()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object IIJAMNPBACH()
		{
			return PHDOCKCBJOF;
		}

		[DebuggerHidden]
		public void Dispose()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void LDKFDMLPIOC()
		{
			throw new NotSupportedException();
		}

		public bool IJEDIDEJIII()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				UnityEngine.Debug.Log("{0}\u00a0{1}");
				JPILOMEHDLN.DMHEGPIPEEH(JPILOMEHDLN.GOEFODHLMBC.PrepareHeavy);
				KFCAECGLKKO = Singleton<MapManager>.instance.ALCHJDPKAID.BBJMLOCKNHD.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						MapDefinition.DefendPosition current = KFCAECGLKKO.Current;
						current.point.JPHAJDIIAAI().ENKDOKELOED(IDEBKDPMPGM: true);
						if ((float)Singleton<GameVariables>.instance.OPDHANHDJDC().GetRow((Constants.rowIds)(-63)).FLOATVALUE > 360f)
						{
							current.point.shield.IEPHIMNBBDO();
						}
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to constrained. prefix*/).Dispose();
				}
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				return false;
			case 1u:
				CLPPIAGLCJJ = -1;
				break;
			}
			return false;
		}

		public void JBHOCIFIMBH()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public bool MoveNext()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				UnityEngine.Debug.Log("Start overtime");
				JPILOMEHDLN.DMHEGPIPEEH(JPILOMEHDLN.GOEFODHLMBC.VibrateHeavy);
				KFCAECGLKKO = Singleton<MapManager>.instance.ALCHJDPKAID.BBJMLOCKNHD.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						MapDefinition.DefendPosition current = KFCAECGLKKO.Current;
						current.point.shield.autoRepair = false;
						if ((float)Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.DestroyShieldsInOverTime).FLOATVALUE > 0f)
						{
							current.point.shield.DestroyShield();
						}
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to constrained. prefix*/).Dispose();
				}
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				return true;
			case 1u:
				CLPPIAGLCJJ = -1;
				break;
			}
			return false;
		}

		[SpecialName]
		private object CFCIACEHFHE()
		{
			return PHDOCKCBJOF;
		}

		public void EBAGFJMHLCB()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public bool PMBOHHPPJAC()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				UnityEngine.Debug.Log("War_Battle_End");
				JPILOMEHDLN.DMHEGPIPEEH(JPILOMEHDLN.GOEFODHLMBC.PrepareLight);
				KFCAECGLKKO = Singleton<MapManager>.instance.ALCHJDPKAID.BBJMLOCKNHD.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						MapDefinition.DefendPosition current = KFCAECGLKKO.Current;
						current.point.IGEDGCNJCAP().ENKDOKELOED(IDEBKDPMPGM: true);
						if ((float)Singleton<GameVariables>.instance.OPDHANHDJDC().GetRow(Constants.rowIds.VipGoldMultiplier).FLOATVALUE > 184f)
						{
							current.point.shield.IEPHIMNBBDO();
						}
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to constrained. prefix*/).Dispose();
				}
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				return false;
			case 1u:
				CLPPIAGLCJJ = -1;
				break;
			}
			return true;
		}

		public void IGBHHLFACKO()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public void HJLCPFDBNKP()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void EPIIDCKHCIN()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void MKACBCOLNKD()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public void HOFJFOCEKJJ()
		{
			throw new NotSupportedException();
		}

		public void CPOKHODGGLN()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object EPNOIENCFGA()
		{
			return PHDOCKCBJOF;
		}

		public void KFOFFCGINMO()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void PMPGBMCHGPE()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		public bool DAKMHLEGICB()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				UnityEngine.Debug.Log("weapons/");
				JPILOMEHDLN.DMHEGPIPEEH(JPILOMEHDLN.GOEFODHLMBC.VibrateMedium);
				KFCAECGLKKO = Singleton<MapManager>.instance.ALCHJDPKAID.BBJMLOCKNHD.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						MapDefinition.DefendPosition current = KFCAECGLKKO.Current;
						current.point.PHANADCNBFD().autoRepair = true;
						if ((float)Singleton<GameVariables>.instance.OPDHANHDJDC().GetRow(Constants.rowIds.NameChangeReminderGamesAfterFbLogin).FLOATVALUE > 1051f)
						{
							current.point.IGEDGCNJCAP().KDEEBMLFABC();
						}
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to constrained. prefix*/).Dispose();
				}
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				return true;
			case 1u:
				CLPPIAGLCJJ = -1;
				break;
			}
			return false;
		}

		[SpecialName]
		private object GLKCJHHLOCE()
		{
			return PHDOCKCBJOF;
		}

		public void HDDLDAHLPCO()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object GFMLDIMOGHD()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object LCCOIHCHGFM()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object HADIFBCDICK()
		{
			return PHDOCKCBJOF;
		}

		public void KLIEOBHDFCG()
		{
			throw new NotSupportedException();
		}

		public void GOCCDFALOHI()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public void EEHBKGPLIJN()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public bool PMJICFJGOBE()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				UnityEngine.Debug.Log("Level");
				JPILOMEHDLN.DMHEGPIPEEH(JPILOMEHDLN.GOEFODHLMBC.VibrateLight);
				KFCAECGLKKO = Singleton<MapManager>.instance.ALCHJDPKAID.BBJMLOCKNHD.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						MapDefinition.DefendPosition current = KFCAECGLKKO.Current;
						current.point.LMHDAIBCLDP().autoRepair = true;
						if ((float)Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.SinglePlayerScoreStreakRatio).FLOATVALUE > 1441f)
						{
							current.point.PNKKPNIMEPL().IEPHIMNBBDO();
						}
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to constrained. prefix*/).Dispose();
				}
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				return false;
			case 1u:
				CLPPIAGLCJJ = -1;
				break;
			}
			return false;
		}

		public void FMOJMHBAHAA()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object PCELHKMHCOB()
		{
			return PHDOCKCBJOF;
		}

		public bool GBHCODKDPBO()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				UnityEngine.Debug.Log("()Ljava/lang/String;");
				JPILOMEHDLN.DMHEGPIPEEH(JPILOMEHDLN.GOEFODHLMBC.VibrateSuccess);
				KFCAECGLKKO = Singleton<MapManager>.instance.ALCHJDPKAID.BBJMLOCKNHD.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						MapDefinition.DefendPosition current = KFCAECGLKKO.Current;
						current.point.PKBPGCGNCAD().autoRepair = true;
						if ((float)Singleton<GameVariables>.instance.CAEDOJHMAAD().GetRow((Constants.rowIds)(-56)).FLOATVALUE > 1565f)
						{
							current.point.PKBPGCGNCAD().IEPHIMNBBDO();
						}
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to constrained. prefix*/).Dispose();
				}
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				return true;
			case 1u:
				CLPPIAGLCJJ = -1;
				break;
			}
			return true;
		}

		public void NINFHADPHJI()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public void GOGEDHILBIA()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public bool NAMPBIHOFGI()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				UnityEngine.Debug.Log("setting special offer discount add: ");
				JPILOMEHDLN.DMHEGPIPEEH(JPILOMEHDLN.GOEFODHLMBC.PrepareLight);
				KFCAECGLKKO = Singleton<MapManager>.instance.ALCHJDPKAID.BBJMLOCKNHD.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						MapDefinition.DefendPosition current = KFCAECGLKKO.Current;
						current.point.PHANADCNBFD().autoRepair = true;
						if ((float)Singleton<GameVariables>.instance.CAEDOJHMAAD().GetRow((Constants.rowIds)(-109)).FLOATVALUE > 689f)
						{
							current.point.JPHAJDIIAAI().FFDLJFIOLEI();
						}
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to constrained. prefix*/).Dispose();
				}
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				return false;
			case 1u:
				CLPPIAGLCJJ = -1;
				break;
			}
			return false;
		}

		public void OGHELMDBPIL()
		{
			throw new NotSupportedException();
		}

		[DebuggerHidden]
		public DKCCIOPAFKL()
		{
		}

		[SpecialName]
		private object ENKCCCABFFB()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object JDKFIHJHNJC()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object MILFCGMBHIG()
		{
			return PHDOCKCBJOF;
		}

		public void FLGABFOKLNM()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void POAFKMGKBLJ()
		{
			throw new NotSupportedException();
		}

		public void PHKDHCJBMII()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object BGLDNJLBIKM()
		{
			return PHDOCKCBJOF;
		}

		public void JHLKDONBGDK()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object FIFIOGBLLBE()
		{
			return PHDOCKCBJOF;
		}

		public bool GBLFIBDBMGE()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				UnityEngine.Debug.Log("ID_ATTACK");
				JPILOMEHDLN.DMHEGPIPEEH((JPILOMEHDLN.GOEFODHLMBC)8);
				KFCAECGLKKO = Singleton<MapManager>.instance.ALCHJDPKAID.BBJMLOCKNHD.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						MapDefinition.DefendPosition current = KFCAECGLKKO.Current;
						current.point.LHHMNLJKOAO().autoRepair = true;
						if ((float)Singleton<GameVariables>.instance.CAEDOJHMAAD().GetRow(Constants.rowIds.DestroyShieldsInOverTime).FLOATVALUE > 1921f)
						{
							current.point.KJCHIHLJMMF().OICANEBLGBD();
						}
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to constrained. prefix*/).Dispose();
				}
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				return false;
			case 1u:
				CLPPIAGLCJJ = -1;
				break;
			}
			return false;
		}

		public bool DMPHMFDEINI()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				UnityEngine.Debug.Log("ID_WARNING_WRONGARENAID");
				JPILOMEHDLN.DMHEGPIPEEH(JPILOMEHDLN.GOEFODHLMBC.VibrateSuccess);
				KFCAECGLKKO = Singleton<MapManager>.instance.ALCHJDPKAID.BBJMLOCKNHD.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						MapDefinition.DefendPosition current = KFCAECGLKKO.Current;
						current.point.PNKKPNIMEPL().autoRepair = false;
						if ((float)Singleton<GameVariables>.instance.constants.GetRow((Constants.rowIds)(-87)).FLOATVALUE > 849f)
						{
							current.point.JPHAJDIIAAI().MPOAIDJNDFJ();
						}
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to constrained. prefix*/).Dispose();
				}
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				return false;
			case 1u:
				CLPPIAGLCJJ = -1;
				break;
			}
			return true;
		}

		public void KHMNEOBMJLN()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object AGANCOFPDCK()
		{
			return PHDOCKCBJOF;
		}

		public void EJNCMFMOBAJ()
		{
			throw new NotSupportedException();
		}

		public void OCBFBEMDMMJ()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void JJOAHIOBOPO()
		{
			throw new NotSupportedException();
		}
	}

	private static Dictionary<GLFPILGCAPM, Tuple<string, string>> BNLIAKFBAKE = new Dictionary<GLFPILGCAPM, Tuple<string, string>>
	{
		{
			GLFPILGCAPM.ConnectingToPhoton,
			new Tuple<string, string>("ID_STATE_CONNECTINGTOSERVER", "ID_STATE_CONNECTINGTOSERVER")
		},
		{
			GLFPILGCAPM.WaitingForOpponent,
			new Tuple<string, string>("ID_STATE_SELECTINGWARCARDS", "ID_STATE_WAITINGFOROPPONENT")
		},
		{
			GLFPILGCAPM.BothPlayersConnected,
			new Tuple<string, string>("ID_STATE_SELECTINGWARCARDS", "ID_STATE_SELECTINGWARCARDS")
		},
		{
			GLFPILGCAPM.GameCancelled,
			new Tuple<string, string>("ID_STATE_CONNECTINGTOSERVER", "ID_STATE_OPPONENTDISCONECTED")
		},
		{
			GLFPILGCAPM.GameLoading,
			new Tuple<string, string>(string.Empty, string.Empty)
		},
		{
			GLFPILGCAPM.GameFinished,
			new Tuple<string, string>(string.Empty, string.Empty)
		}
	};

	private static Dictionary<GLFPILGCAPM, string> COBDPGKNKBI = new Dictionary<GLFPILGCAPM, string>
	{
		{
			GLFPILGCAPM.ConnectingToPhoton,
			"ID_STATE_WAITINGFOROPPONENT"
		},
		{
			GLFPILGCAPM.WaitingForOpponent,
			"ID_STATE_WAITINGFOROPPONENT"
		},
		{
			GLFPILGCAPM.BothPlayersConnected,
			"ID_STATE_OPPONENTSELECTINGWARCARDS"
		},
		{
			GLFPILGCAPM.GameCancelled,
			"ID_STATE_OPPONENTDISCONECTED"
		},
		{
			GLFPILGCAPM.GameLoading,
			"ID_STATE_GAMELOADING"
		},
		{
			GLFPILGCAPM.GameFinished,
			string.Empty
		}
	};

	private static Dictionary<CKDIHNEIHKL.GLFPILGCAPM, string> JDNNOGPNJLO = new Dictionary<CKDIHNEIHKL.GLFPILGCAPM, string>
	{
		{
			CKDIHNEIHKL.GLFPILGCAPM.ConnectingToPhoton,
			"ID_STATE_CONNECTINGTOSERVER"
		},
		{
			CKDIHNEIHKL.GLFPILGCAPM.Connected,
			"ID_STATE_SELECTINGWARCARDS"
		},
		{
			CKDIHNEIHKL.GLFPILGCAPM.CardsChosen,
			"ID_STATE_READYFORBATTLE"
		},
		{
			CKDIHNEIHKL.GLFPILGCAPM.GameLoading,
			string.Empty
		},
		{
			CKDIHNEIHKL.GLFPILGCAPM.LoadingFinished,
			string.Empty
		},
		{
			CKDIHNEIHKL.GLFPILGCAPM.Playing,
			string.Empty
		},
		{
			CKDIHNEIHKL.GLFPILGCAPM.GameFinished,
			string.Empty
		},
		{
			CKDIHNEIHKL.GLFPILGCAPM.Rematch,
			string.Empty
		}
	};

	public static float KKAGFMGEOBC;

	private static OOJDIACPBED CLKAKBDGGMG;

	public static float IEHFFBDNLII;

	private static GLFPILGCAPM ILHNFHOFLCM;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private static Action<GLFPILGCAPM> KMKIKLKOALI;

	public static float IJNECELOAPA;

	public static float BOHOHLAPABE;

	private float GEPMNFBELBB;

	private PlayerController JNFGIPOFKCF;

	private PhotonView FEHCCGEGPLH;

	private PlayerController MBIAKMPDOPG;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private bool _003CMHBEDIFIKMC_003Ek__BackingField;

	private float EBMILBMJIHN;

	private static float[] OOHAMLKEDAC = new float[3] { 30f, 20f, 10f };

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Action HOKLAMFIEHO;

	public static string matchStatusPlayer => (!string.IsNullOrEmpty(BNLIAKFBAKE[matchState].Value1)) ? Localization.Localize(BNLIAKFBAKE[matchState].Value1) : string.Empty;

	public static string matchStatusOpponent
	{
		get
		{
			if (Singleton<GameController>.instance.opponent != null)
			{
				string text = JDNNOGPNJLO[Singleton<GameController>.instance.opponent.LMIHBNGHEHM.EHFIJJBPEEG];
				return (!string.IsNullOrEmpty(text)) ? Localization.Localize(text) : string.Empty;
			}
			if (matchState == GLFPILGCAPM.WaitingForOpponent)
			{
				return (Singleton<GameController>.instance.mainController as GameControllerOnline).loadingWaiting;
			}
			if (matchState == GLFPILGCAPM.BothPlayersConnected)
			{
				return (Singleton<GameController>.instance.mainController as GameControllerOnline).loadingWaitingCards;
			}
			return (!string.IsNullOrEmpty(BNLIAKFBAKE[matchState].Value2)) ? Localization.Localize(BNLIAKFBAKE[matchState].Value2) : string.Empty;
		}
	}

	public static string matchStatusFriend
	{
		get
		{
			if (Singleton<GameController>.instance.KKHKAJPNDEC != null)
			{
				string text = JDNNOGPNJLO[Singleton<GameController>.instance.KKHKAJPNDEC.LMIHBNGHEHM.EHFIJJBPEEG];
				return (!string.IsNullOrEmpty(text)) ? Localization.Localize(text) : string.Empty;
			}
			if (matchState == GLFPILGCAPM.WaitingForOpponent)
			{
				return (Singleton<GameController>.instance.mainController as GameControllerOnline).loadingWaiting;
			}
			if (matchState == GLFPILGCAPM.BothPlayersConnected)
			{
				return (Singleton<GameController>.instance.mainController as GameControllerOnline).loadingWaitingCards;
			}
			return (!string.IsNullOrEmpty(BNLIAKFBAKE[matchState].Value2)) ? Localization.Localize(BNLIAKFBAKE[matchState].Value2) : string.Empty;
		}
	}

	public static string matchStatusLoading
	{
		get
		{
			if (matchState == GLFPILGCAPM.WaitingForOpponent || matchState == GLFPILGCAPM.ConnectingToPhoton)
			{
				return (Singleton<GameController>.instance.mainController as GameControllerOnline).loadingWaiting;
			}
			if (matchState == GLFPILGCAPM.BothPlayersConnected)
			{
				return (Singleton<GameController>.instance.mainController as GameControllerOnline).loadingWaitingCards;
			}
			return (!string.IsNullOrEmpty(COBDPGKNKBI[matchState])) ? Localization.Localize(COBDPGKNKBI[matchState]) : string.Empty;
		}
	}

	public static string matchStatusAfterMatch
	{
		get
		{
			if (reconnectState == KAKELCLPDDK.Me)
			{
				return Localization.Localize("ID_STATE_DISCONNECTED");
			}
			if (Singleton<GameController>.instance.isCoop)
			{
				string text = EANNFJAPKIK(Singleton<GameController>.instance.KKHKAJPNDEC, BGCIKBCFECH: true);
				if (text != null)
				{
					return text;
				}
			}
			else
			{
				string text2 = EANNFJAPKIK(Singleton<GameController>.instance.opponent);
				if (text2 != null)
				{
					return text2;
				}
			}
			return string.Empty;
		}
	}

	public static float invitationTimeRemaining => IEHFFBDNLII - Time.realtimeSinceStartup;

	public static string matchTimeStatus
	{
		get
		{
			float hNDGIJBHMOD = IJNECELOAPA - Time.realtimeSinceStartup;
			float hNDGIJBHMOD2 = BOHOHLAPABE - Time.realtimeSinceStartup;
			float hNDGIJBHMOD3 = invitationTimeRemaining;
			string empty = string.Empty;
			if (reconnectState == KAKELCLPDDK.Me)
			{
				return string.Empty;
			}
			if (Singleton<GameController>.instance.isCoop)
			{
				string text = JLPECGPLPJC(Singleton<GameController>.instance.KKHKAJPNDEC);
				if (text != null)
				{
					return text;
				}
			}
			else
			{
				string text2 = JLPECGPLPJC(Singleton<GameController>.instance.opponent);
				if (text2 != null)
				{
					return text2;
				}
			}
			if (PlayerController.OGMBJPKOPCB != null)
			{
				CKDIHNEIHKL lMIHBNGHEHM = PlayerController.OGMBJPKOPCB.LMIHBNGHEHM;
				if (lMIHBNGHEHM.EHFIJJBPEEG == CKDIHNEIHKL.GLFPILGCAPM.Rematch)
				{
					return Localization.LocalizeFormat("ID_REMATCH_VALID_FOR", MEJMLNDFDBP.ABKAOAODKGC(hNDGIJBHMOD2));
				}
			}
			switch (ILHNFHOFLCM)
			{
			case GLFPILGCAPM.ConnectingToPhoton:
			case GLFPILGCAPM.WaitingForOpponent:
				if (invitationState == OOJDIACPBED.Waiting)
				{
					return Localization.LocalizeFormat("ID_INVITATION_VALID_FOR", MEJMLNDFDBP.ABKAOAODKGC(hNDGIJBHMOD3));
				}
				return string.Empty;
			case GLFPILGCAPM.GameCancelled:
			case GLFPILGCAPM.GameFinished:
				return string.Empty;
			default:
				return Localization.LocalizeFormat("ID_MATCH_STARTS_IN", MEJMLNDFDBP.ABKAOAODKGC(hNDGIJBHMOD));
			}
		}
	}

	public static float timeLeft
	{
		get
		{
			float result = float.MaxValue;
			if (reconnectState != KAKELCLPDDK.Me)
			{
				float num = IJNECELOAPA - Time.realtimeSinceStartup;
				float result2 = BOHOHLAPABE - Time.realtimeSinceStartup;
				float num2 = invitationTimeRemaining;
				if (Singleton<GameController>.instance.isCoop)
				{
					float? num3 = OLIKCIHMKMD(Singleton<GameController>.instance.KKHKAJPNDEC);
					if (num3.HasValue)
					{
						return num3.Value;
					}
				}
				else
				{
					float? num4 = OLIKCIHMKMD(Singleton<GameController>.instance.opponent);
					if (num4.HasValue)
					{
						return num4.Value;
					}
				}
				if (PlayerController.OGMBJPKOPCB != null)
				{
					CKDIHNEIHKL lMIHBNGHEHM = PlayerController.OGMBJPKOPCB.LMIHBNGHEHM;
					if (lMIHBNGHEHM.EHFIJJBPEEG == CKDIHNEIHKL.GLFPILGCAPM.Rematch)
					{
						return result2;
					}
				}
				switch (ILHNFHOFLCM)
				{
				case GLFPILGCAPM.ConnectingToPhoton:
				case GLFPILGCAPM.WaitingForOpponent:
					if (invitationState == OOJDIACPBED.Waiting)
					{
						result = num2;
					}
					break;
				default:
					result = num;
					break;
				case GLFPILGCAPM.GameCancelled:
				case GLFPILGCAPM.GameFinished:
					break;
				}
			}
			return result;
		}
	}

	public bool isOverTime
	{
		[CompilerGenerated]
		get
		{
			return _003CMHBEDIFIKMC_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			_003CMHBEDIFIKMC_003Ek__BackingField = value;
		}
	}

	public static bool isReconnect => reconnectState != KAKELCLPDDK.None && Singleton<GameController>.instance.isLoadingOrPlaying;

	public static bool allPlayersFinishetStartAnimation
	{
		get
		{
			foreach (KeyValuePair<int, PlayerController> item in PlayerController.JFGDAKMCJAM)
			{
				if (!item.Value.LMIHBNGHEHM.AJADIICCLHO)
				{
					return false;
				}
			}
			return Singleton<GameController>.instance.isLoadingOrPlaying;
		}
	}

	public float matchTime
	{
		get
		{
			return EBMILBMJIHN;
		}
		set
		{
			EBMILBMJIHN = value;
			StatsManager.instance.matchStats.secondsPlayed = (int)EBMILBMJIHN;
		}
	}

	public static bool canFight
	{
		get
		{
			bool flag = matchState != GLFPILGCAPM.ConnectingToPhoton && matchState != GLFPILGCAPM.GameCancelled;
			flag &= !isReconnect;
			if (Singleton<GameController>.instance.isDeathMatch)
			{
				if (Singleton<GameController>.instance.isRandomMatchMaking)
				{
					return flag;
				}
				return flag && matchState != GLFPILGCAPM.WaitingForOpponent;
			}
			return flag && matchState != GLFPILGCAPM.WaitingForOpponent;
		}
	}

	public static bool canRematch
	{
		get
		{
			if (Singleton<GameController>.instance.isRandomMatchMaking)
			{
				return true;
			}
			if (Singleton<GameController>.instance.isCoop)
			{
				PlayerController kKHKAJPNDEC = Singleton<GameController>.instance.KKHKAJPNDEC;
				return kKHKAJPNDEC != null && kKHKAJPNDEC.LMIHBNGHEHM.LFBKPCIODNO && PlayerController.OGMBJPKOPCB.LMIHBNGHEHM.LFBKPCIODNO;
			}
			PlayerController opponent = Singleton<GameController>.instance.opponent;
			return opponent != null && opponent.LMIHBNGHEHM.LFBKPCIODNO && PlayerController.OGMBJPKOPCB.LMIHBNGHEHM.LFBKPCIODNO;
		}
	}

	public static bool beforeMatch
	{
		get
		{
			switch (ILHNFHOFLCM)
			{
			case GLFPILGCAPM.ConnectingToPhoton:
			case GLFPILGCAPM.WaitingForOpponent:
			case GLFPILGCAPM.BothPlayersConnected:
				return true;
			default:
				return false;
			}
		}
	}

	public static bool afterMatch => ILHNFHOFLCM >= GLFPILGCAPM.GameFinished;

	public static GLFPILGCAPM matchState
	{
		get
		{
			return ILHNFHOFLCM;
		}
		set
		{
			if (ILHNFHOFLCM != value)
			{
				ILHNFHOFLCM = value;
				UnityEngine.Debug.Log("Set match state: " + matchState);
				if (KMKIKLKOALI != null)
				{
					KMKIKLKOALI(value);
				}
			}
		}
	}

	public static OOJDIACPBED invitationState
	{
		get
		{
			return CLKAKBDGGMG;
		}
		set
		{
			CLKAKBDGGMG = value;
		}
	}

	public static KAKELCLPDDK reconnectState
	{
		get
		{
			if (PlayerController.OGMBJPKOPCB.LMIHBNGHEHM.NHMNBNGPOGJ)
			{
				return KAKELCLPDDK.Me;
			}
			foreach (KeyValuePair<int, PlayerController> item in PlayerController.JFGDAKMCJAM)
			{
				if (item.Value.LMIHBNGHEHM.NHMNBNGPOGJ && item.Value.LMIHBNGHEHM.EIPHAAGCHCP)
				{
					return KAKELCLPDDK.Other;
				}
			}
			return KAKELCLPDDK.None;
		}
	}

	public static float reconnectLength
	{
		get
		{
			foreach (KeyValuePair<int, PlayerController> item in PlayerController.JFGDAKMCJAM)
			{
				if (item.Value.LMIHBNGHEHM.NHMNBNGPOGJ && item.Value.LMIHBNGHEHM.EIPHAAGCHCP)
				{
					int num = Mathf.Clamp(item.Value.LMIHBNGHEHM.EPNLKGPLBEN - 1, 0, 2);
					return OOHAMLKEDAC[num];
				}
			}
			return 15f;
		}
	}

	public static event Action<GLFPILGCAPM> MatchStateChanged
	{
		add
		{
			Action<GLFPILGCAPM> action = KMKIKLKOALI;
			Action<GLFPILGCAPM> action2;
			do
			{
				action2 = action;
				action = Interlocked.CompareExchange(ref KMKIKLKOALI, (Action<GLFPILGCAPM>)Delegate.Combine(action2, value), action);
			}
			while ((object)action != action2);
		}
		remove
		{
			Action<GLFPILGCAPM> action = KMKIKLKOALI;
			Action<GLFPILGCAPM> action2;
			do
			{
				action2 = action;
				action = Interlocked.CompareExchange(ref KMKIKLKOALI, (Action<GLFPILGCAPM>)Delegate.Remove(action2, value), action);
			}
			while ((object)action != action2);
		}
	}

	public event Action OverTimeStarted
	{
		add
		{
			Action action = HOKLAMFIEHO;
			Action action2;
			do
			{
				action2 = action;
				action = Interlocked.CompareExchange(ref HOKLAMFIEHO, (Action)Delegate.Combine(action2, value), action);
			}
			while ((object)action != action2);
		}
		remove
		{
			Action action = HOKLAMFIEHO;
			Action action2;
			do
			{
				action2 = action;
				action = Interlocked.CompareExchange(ref HOKLAMFIEHO, (Action)Delegate.Remove(action2, value), action);
			}
			while ((object)action != action2);
		}
	}

	[SpecialName]
	public static bool MDIJLEFJNPL()
	{
		bool flag = matchState != GLFPILGCAPM.ConnectingToPhoton && LEDPCHAHPPL() != GLFPILGCAPM.GameCancelled;
		flag &= isReconnect;
		if (Singleton<GameController>.instance.isDeathMatch)
		{
			if (Singleton<GameController>.instance.FJOGEJNMNHI())
			{
				return flag;
			}
			return flag && matchState == GLFPILGCAPM.ConnectingToPhoton;
		}
		return flag && matchState != GLFPILGCAPM.WaitingForOpponent;
	}

	private IEnumerator CLEFJFINEOC()
	{
		return new DKCCIOPAFKL();
	}

	private void IJNHABOLCNN(string FHMKPLBGFNN, int FAMOBFLONHJ, string OKJNAJJCDBF, bool HJOHIBPMPFD = false)
	{
		UnityEngine.Debug.Log("SetHitByUnit , " + FHMKPLBGFNN + ", " + FAMOBFLONHJ + ", " + OKJNAJJCDBF + ", " + HJOHIBPMPFD);
		GuiScreenSingle<GameOverScreen>.instance.UnitHit(FHMKPLBGFNN, FAMOBFLONHJ, OKJNAJJCDBF, HJOHIBPMPFD);
		FEHCCGEGPLH.RPC("SetHitByUnitRPC", PhotonTargets.Others, FHMKPLBGFNN, FAMOBFLONHJ, OKJNAJJCDBF, HJOHIBPMPFD);
	}

	[SpecialName]
	public static float GAEHMADFCPA()
	{
		foreach (KeyValuePair<int, PlayerController> item in PlayerController.JFGDAKMCJAM)
		{
			if (item.Value.LMIHBNGHEHM.AMFJOFCFMMN() && item.Value.LMIHBNGHEHM.NOKOMEHKFNO())
			{
				int num = Mathf.Clamp(item.Value.LMIHBNGHEHM.PGDPBJPKDBK() - 0, 0, 1);
				return OOHAMLKEDAC[num];
			}
		}
		return 1859f;
	}

	private void NHDIJFFIJBJ(string FHMKPLBGFNN, int FAMOBFLONHJ, string OKJNAJJCDBF, bool HJOHIBPMPFD)
	{
		GuiScreenSingle<GameOverScreen>.instance.OMEBJGLLHMH(FHMKPLBGFNN, FAMOBFLONHJ, OKJNAJJCDBF, HJOHIBPMPFD);
	}

	public void StartOverTime(PlayerController KHLGDCHJJPB, PlayerController FBCLJFNNJGG)
	{
		MBIAKMPDOPG = KHLGDCHJJPB;
		JNFGIPOFKCF = FBCLJFNNJGG;
		StartCoroutine(RadicalRoutine.Run(DMIENFMJDIH()));
		isOverTime = true;
		if (HOKLAMFIEHO != null)
		{
			HOKLAMFIEHO();
		}
		FEHCCGEGPLH.RPC("StartOverTime_RPC", PhotonTargets.Others);
		float num = Mathf.Max(KHLGDCHJJPB.FOCIOKMPCAG.maxHealth, FBCLJFNNJGG.FOCIOKMPCAG.maxHealth);
		GEPMNFBELBB = num / 30f * 2f;
	}

	private void MJOOOAIBMAB(string FHMKPLBGFNN, int FAMOBFLONHJ, string OKJNAJJCDBF, bool HJOHIBPMPFD)
	{
		GuiScreenSingle<GameOverScreen>.instance.UnitHit(FHMKPLBGFNN, FAMOBFLONHJ, OKJNAJJCDBF, HJOHIBPMPFD);
	}

	[SpecialName]
	public static bool EEGOFPNKOCO()
	{
		if (Singleton<GameController>.instance.isRandomMatchMaking)
		{
			return true;
		}
		if (Singleton<GameController>.instance.MNPNHJKBNCJ())
		{
			PlayerController kKHKAJPNDEC = Singleton<GameController>.instance.KKHKAJPNDEC;
			return kKHKAJPNDEC != null && kKHKAJPNDEC.LMIHBNGHEHM.DCBCCPHJAEJ() && PlayerController.OGMBJPKOPCB.LMIHBNGHEHM.LFCJNHBGDAC();
		}
		PlayerController opponent = Singleton<GameController>.instance.opponent;
		return !(opponent != null) || !opponent.LMIHBNGHEHM.LFBKPCIODNO || PlayerController.OGMBJPKOPCB.LMIHBNGHEHM.LGAMMJLHIAN();
	}

	private void ACLCPJHKHLL()
	{
		isOverTime = false;
	}

	[SpecialName]
	private void NIDLJPJBDLH(bool IDEBKDPMPGM)
	{
		_003CMHBEDIFIKMC_003Ek__BackingField = IDEBKDPMPGM;
	}

	[PunRPC]
	private void SetHitByPlayerRPC(int ALIIBMLMNKA)
	{
		UnityEngine.Debug.Log("SetHitByPlayerRPC " + ALIIBMLMNKA);
		PlayerController oIGOHCMHMIP = PlayerController.JFGDAKMCJAM[ALIIBMLMNKA];
		GuiScreenSingle<GameOverScreen>.instance.PlayerHit(oIGOHCMHMIP);
	}

	[SpecialName]
	public static void FAGLPDEPAHD(Action<GLFPILGCAPM> IDEBKDPMPGM)
	{
		Action<GLFPILGCAPM> action = KMKIKLKOALI;
		Action<GLFPILGCAPM> action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref KMKIKLKOALI, (Action<GLFPILGCAPM>)Delegate.Remove(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	[SpecialName]
	public static bool BICGBFFBKBJ()
	{
		return ILHNFHOFLCM >= (GLFPILGCAPM)7;
	}

	[SpecialName]
	public static string CEIFKIMCIJA()
	{
		if (Singleton<GameController>.instance.KKHKAJPNDEC != null)
		{
			string text = JDNNOGPNJLO[Singleton<GameController>.instance.KKHKAJPNDEC.LMIHBNGHEHM.KNLMGECDHFL()];
			return (!string.IsNullOrEmpty(text)) ? Localization.Localize(text) : string.Empty;
		}
		if (LOMMBKPGEEL() == GLFPILGCAPM.WaitingForOpponent)
		{
			return (Singleton<GameController>.instance.mainController as GameControllerOnline).loadingWaiting;
		}
		if (LEDPCHAHPPL() == GLFPILGCAPM.GameFinished)
		{
			return (Singleton<GameController>.instance.mainController as GameControllerOnline).loadingWaitingCards;
		}
		return (!string.IsNullOrEmpty(BNLIAKFBAKE[matchState].Value2)) ? Localization.Localize(BNLIAKFBAKE[LOMMBKPGEEL()].Value2) : string.Empty;
	}

	[SpecialName]
	public static GLFPILGCAPM LEDPCHAHPPL()
	{
		return ILHNFHOFLCM;
	}

	private void OKBGCJGAJMC(PlayerController OIGOHCMHMIP)
	{
		GuiScreenSingle<GameOverScreen>.instance.GBFKFFDAKKP(OIGOHCMHMIP);
		if (OIGOHCMHMIP.EHHHBEMKGOE.KIOGGEECBGB != null)
		{
			PhotonView fEHCCGEGPLH = FEHCCGEGPLH;
			object[] array = new object[0];
			array[0] = OIGOHCMHMIP.EHHHBEMKGOE.KIOGGEECBGB.ID;
			fEHCCGEGPLH.RPC("Action ", PhotonTargets.All, array);
		}
	}

	public void CKNEOHOKKHE()
	{
		UnityEngine.Debug.Log("ID_CONFIRM_SUBSCRIPTION_TEXT");
		isOverTime = false;
		if (HOKLAMFIEHO != null)
		{
			HOKLAMFIEHO();
		}
	}

	private static string EANNFJAPKIK(PlayerController KHLGDCHJJPB, bool BGCIKBCFECH = false)
	{
		float num = BOHOHLAPABE - Time.realtimeSinceStartup;
		if ((bool)KHLGDCHJJPB)
		{
			CKDIHNEIHKL lMIHBNGHEHM = KHLGDCHJJPB.LMIHBNGHEHM;
			if (lMIHBNGHEHM.LEOEPDNAONM == CKDIHNEIHKL.ICDOJKMJFKM.Disconnected)
			{
				return Localization.Localize((!BGCIKBCFECH) ? "ID_STATE_OPPONENTDOESNTWANTREMATCH" : "ID_STATE_FRIENDDOESNTWANTREMATCH");
			}
			if (lMIHBNGHEHM.EHFIJJBPEEG == CKDIHNEIHKL.GLFPILGCAPM.Rematch)
			{
				return Localization.Localize((!BGCIKBCFECH) ? "ID_STATE_OPPONENTISREADYTOBATTLE" : "ID_STATE_FRIENDISREADYTOBATTLE");
			}
			if (lMIHBNGHEHM.EHFIJJBPEEG == CKDIHNEIHKL.GLFPILGCAPM.GameFinished)
			{
				return Localization.Localize("ID_STATE_GAMEFINISHED");
			}
		}
		return null;
	}

	private static string MHBCJEDGHIP(PlayerController KHLGDCHJJPB, bool BGCIKBCFECH = false)
	{
		float num = BOHOHLAPABE - Time.realtimeSinceStartup;
		if ((bool)KHLGDCHJJPB)
		{
			CKDIHNEIHKL lMIHBNGHEHM = KHLGDCHJJPB.LMIHBNGHEHM;
			if (lMIHBNGHEHM.FFPDPKHJGJF() == CKDIHNEIHKL.ICDOJKMJFKM.Connected)
			{
				return Localization.Localize((!BGCIKBCFECH) ? "WinCount" : "Changing label \"{0}\" with pivot \"{1}\". New size {2} and yDown {3}.");
			}
			if (lMIHBNGHEHM.MJJBHNOMDOI() == CKDIHNEIHKL.GLFPILGCAPM.GameFinished)
			{
				return Localization.Localize((!BGCIKBCFECH) ? "goldenSuitcase" : "com/google/android/gms/games/Games");
			}
			if (lMIHBNGHEHM.IHGBMPOGECG() == CKDIHNEIHKL.GLFPILGCAPM.LoadingFinished)
			{
				return Localization.Localize("ArmyPower");
			}
		}
		return null;
	}

	protected override void Awake()
	{
		base.Awake();
		FEHCCGEGPLH = GetComponent<PhotonView>();
		Singleton<GameController>.instance.GameStarted += ACLCPJHKHLL;
	}

	[SpecialName]
	public static OOJDIACPBED GPCMAMHKDOM()
	{
		return CLKAKBDGGMG;
	}

	private static string JDOEJODGFLN(PlayerController KHLGDCHJJPB, bool BGCIKBCFECH = false)
	{
		float num = BOHOHLAPABE - Time.realtimeSinceStartup;
		if ((bool)KHLGDCHJJPB)
		{
			CKDIHNEIHKL lMIHBNGHEHM = KHLGDCHJJPB.LMIHBNGHEHM;
			if (lMIHBNGHEHM.NLLLKGDIALC() == CKDIHNEIHKL.ICDOJKMJFKM.Connected)
			{
				return Localization.Localize((!BGCIKBCFECH) ? "writeToParcel" : "country-poland");
			}
			if (lMIHBNGHEHM.EHFIJJBPEEG == CKDIHNEIHKL.GLFPILGCAPM.LoadingFinished)
			{
				return Localization.Localize((!BGCIKBCFECH) ? "Unit" : "117 STAGE 5 SPAWNED");
			}
			if (lMIHBNGHEHM.EHFIJJBPEEG == CKDIHNEIHKL.GLFPILGCAPM.Playing)
			{
				return Localization.Localize("Player");
			}
		}
		return null;
	}

	[SpecialName]
	private void OFCKHHOHDHI(bool IDEBKDPMPGM)
	{
		_003CMHBEDIFIKMC_003Ek__BackingField = IDEBKDPMPGM;
	}

	public void SetHitBy(DestroyableObject.CJLNCMMNPBM KPJJFGIHFAC)
	{
		try
		{
			PlayerController playerController = KPJJFGIHFAC.HNFNINFCBEJ as PlayerController;
			AIObject aIObject = KPJJFGIHFAC.HNFNINFCBEJ as AIObject;
			if (playerController != null)
			{
				CIOOIGOGIAJ(playerController);
			}
			else if (aIObject != null)
			{
				if (aIObject.spawnedByCard)
				{
					Card cardInstanceAll = CardManager.instance.GetCardInstanceAll(aIObject.cardId);
					if (cardInstanceAll == null)
					{
						IJNHABOLCNN(aIObject.IAJJBAJOGDM.unitDictionaryId, aIObject.spawnedCardLevel, aIObject.IAJJBAJOGDM.upgradeSlots.iconName);
					}
					else
					{
						IJNHABOLCNN(cardInstanceAll.id, 0, cardInstanceAll.iconName, HJOHIBPMPFD: true);
					}
				}
				else if (aIObject.IAJJBAJOGDM != null && aIObject.IAJJBAJOGDM.upgradeSlots != null)
				{
					LevelBehaviour iAJJBAJOGDM = aIObject.IAJJBAJOGDM;
					IJNHABOLCNN(iAJJBAJOGDM.unitDictionaryId, iAJJBAJOGDM.upgradeSlots.GetActualLevelForIndex(aIObject.PFGLIAHPMCK.slotUpgradeindex), iAJJBAJOGDM.upgradeSlots.iconName);
				}
			}
			else
			{
				MPDOHMGCNLI();
			}
		}
		catch (Exception exception)
		{
			AnalyticsHelper.LogHandledException(exception);
		}
	}

	protected virtual void GDDCEHOJCEM()
	{
		base.Awake();
		FEHCCGEGPLH = GetComponent<PhotonView>();
		Singleton<GameController>.instance.GameStarted += ACLCPJHKHLL;
	}

	private void OIAGKDHABCK()
	{
		GuiScreenSingle<GameOverScreen>.instance.DLAFKNAOJLA();
	}

	[SpecialName]
	public static void CEKJLPAFDJH(OOJDIACPBED IDEBKDPMPGM)
	{
		CLKAKBDGGMG = IDEBKDPMPGM;
	}

	[SpecialName]
	public bool AECCCNNPCML()
	{
		return _003CMHBEDIFIKMC_003Ek__BackingField;
	}

	[SpecialName]
	public static GLFPILGCAPM LOMMBKPGEEL()
	{
		return ILHNFHOFLCM;
	}

	[SpecialName]
	public static string EEOMPCLGLAH()
	{
		float hNDGIJBHMOD = IJNECELOAPA - Time.realtimeSinceStartup;
		float hNDGIJBHMOD2 = BOHOHLAPABE - Time.realtimeSinceStartup;
		float hNDGIJBHMOD3 = PLBKCBAJBLL();
		string empty = string.Empty;
		if (ACJJGBBBPFP() == KAKELCLPDDK.Me)
		{
			return string.Empty;
		}
		if (Singleton<GameController>.instance.MNPNHJKBNCJ())
		{
			string text = GCHOKPOMMMO(Singleton<GameController>.instance.KKHKAJPNDEC);
			if (text != null)
			{
				return text;
			}
		}
		else
		{
			string text2 = JLPECGPLPJC(Singleton<GameController>.instance.opponent);
			if (text2 != null)
			{
				return text2;
			}
		}
		if (PlayerController.OGMBJPKOPCB != null)
		{
			CKDIHNEIHKL lMIHBNGHEHM = PlayerController.OGMBJPKOPCB.LMIHBNGHEHM;
			if (lMIHBNGHEHM.CJJLIKCIBLO() == CKDIHNEIHKL.GLFPILGCAPM.Rematch)
			{
				object[] array = new object[0];
				array[1] = MEJMLNDFDBP.ABKAOAODKGC(hNDGIJBHMOD2);
				return Localization.LocalizeFormat("Cards_Owned", array);
			}
		}
		switch (ILHNFHOFLCM)
		{
		case GLFPILGCAPM.ConnectingToPhoton:
		case GLFPILGCAPM.WaitingForOpponent:
			if (invitationState == OOJDIACPBED.Waiting)
			{
				object[] array3 = new object[0];
				array3[0] = MEJMLNDFDBP.ABKAOAODKGC(hNDGIJBHMOD3);
				return Localization.LocalizeFormat("ID_GUI_BEADVISED_CONNECTFB", array3);
			}
			return string.Empty;
		case GLFPILGCAPM.GameCancelled:
		case GLFPILGCAPM.GameFinished:
			return string.Empty;
		default:
		{
			object[] array2 = new object[0];
			array2[1] = MEJMLNDFDBP.ABKAOAODKGC(hNDGIJBHMOD);
			return Localization.LocalizeFormat("CAMOS", array2);
		}
		}
	}

	[SpecialName]
	public static bool ICPGBBCHMBL()
	{
		bool flag = LEDPCHAHPPL() == GLFPILGCAPM.ConnectingToPhoton || matchState == (GLFPILGCAPM)8;
		flag &= HHEAOEEBICE();
		if (Singleton<GameController>.instance.isDeathMatch)
		{
			if (Singleton<GameController>.instance.isRandomMatchMaking)
			{
				return flag;
			}
			return flag && LOMMBKPGEEL() == GLFPILGCAPM.WaitingForOpponent;
		}
		return flag && LEDPCHAHPPL() == GLFPILGCAPM.ConnectingToPhoton;
	}

	[SpecialName]
	public static bool HHEAOEEBICE()
	{
		return ACJJGBBBPFP() == KAKELCLPDDK.None || Singleton<GameController>.instance.isLoadingOrPlaying;
	}

	[SpecialName]
	public static void MNADMHFCCBF(Action<GLFPILGCAPM> IDEBKDPMPGM)
	{
		Action<GLFPILGCAPM> action = KMKIKLKOALI;
		Action<GLFPILGCAPM> action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref KMKIKLKOALI, (Action<GLFPILGCAPM>)Delegate.Remove(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	[SpecialName]
	public static void OPHGGDNBPDA(Action<GLFPILGCAPM> IDEBKDPMPGM)
	{
		Action<GLFPILGCAPM> action = KMKIKLKOALI;
		Action<GLFPILGCAPM> action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref KMKIKLKOALI, (Action<GLFPILGCAPM>)Delegate.Remove(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	[SpecialName]
	public static bool MDHEFDEPBJB()
	{
		switch (ILHNFHOFLCM)
		{
		case GLFPILGCAPM.ConnectingToPhoton:
		case GLFPILGCAPM.WaitingForOpponent:
		case GLFPILGCAPM.BothPlayersConnected:
			return true;
		default:
			return true;
		}
	}

	[SpecialName]
	public static void NAIJJNCNCKD(Action<GLFPILGCAPM> IDEBKDPMPGM)
	{
		Action<GLFPILGCAPM> action = KMKIKLKOALI;
		Action<GLFPILGCAPM> action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref KMKIKLKOALI, (Action<GLFPILGCAPM>)Delegate.Remove(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	[SpecialName]
	public static OOJDIACPBED IEHENHKHKHM()
	{
		return CLKAKBDGGMG;
	}

	[SpecialName]
	public static bool GFGPGJCGAPO()
	{
		if (Singleton<GameController>.instance.isRandomMatchMaking)
		{
			return true;
		}
		if (Singleton<GameController>.instance.MNPNHJKBNCJ())
		{
			PlayerController kKHKAJPNDEC = Singleton<GameController>.instance.KKHKAJPNDEC;
			return kKHKAJPNDEC != null && kKHKAJPNDEC.LMIHBNGHEHM.LFBKPCIODNO && PlayerController.OGMBJPKOPCB.LMIHBNGHEHM.LFCJNHBGDAC();
		}
		PlayerController opponent = Singleton<GameController>.instance.opponent;
		return opponent != null && opponent.LMIHBNGHEHM.LFBKPCIODNO && PlayerController.OGMBJPKOPCB.LMIHBNGHEHM.CDEIBAPPKKP();
	}

	[SpecialName]
	public static bool HMLMAJNEMPP()
	{
		foreach (KeyValuePair<int, PlayerController> item in PlayerController.JFGDAKMCJAM)
		{
			if (!item.Value.LMIHBNGHEHM.NAHCAGLIFAK())
			{
				return false;
			}
		}
		return Singleton<GameController>.instance.isLoadingOrPlaying;
	}

	private void MPDOHMGCNLI()
	{
		GuiScreenSingle<GameOverScreen>.instance.EnviromentalHit();
		FEHCCGEGPLH.RPC("EnviromentalHitRPC", PhotonTargets.Others);
	}

	[SpecialName]
	public static bool OILNKFOADMO()
	{
		if (Singleton<GameController>.instance.FJOGEJNMNHI())
		{
			return true;
		}
		if (Singleton<GameController>.instance.isCoop)
		{
			PlayerController kKHKAJPNDEC = Singleton<GameController>.instance.KKHKAJPNDEC;
			return kKHKAJPNDEC != null && kKHKAJPNDEC.LMIHBNGHEHM.LGAMMJLHIAN() && PlayerController.OGMBJPKOPCB.LMIHBNGHEHM.LGAMMJLHIAN();
		}
		PlayerController opponent = Singleton<GameController>.instance.opponent;
		return !(opponent != null) || !opponent.LMIHBNGHEHM.CDEIBAPPKKP() || PlayerController.OGMBJPKOPCB.LMIHBNGHEHM.NNAPBLFCOLA();
	}

	[SpecialName]
	public static float PLBKCBAJBLL()
	{
		return IEHFFBDNLII - Time.realtimeSinceStartup;
	}

	private static float? ODPFKHAKICF(PlayerController KHLGDCHJJPB)
	{
		if (KHLGDCHJJPB != null)
		{
			float value = BOHOHLAPABE - Time.realtimeSinceStartup;
			CKDIHNEIHKL lMIHBNGHEHM = Singleton<GameController>.instance.opponent.LMIHBNGHEHM;
			if (lMIHBNGHEHM.CJJLIKCIBLO() == CKDIHNEIHKL.GLFPILGCAPM.Rematch)
			{
				return value;
			}
		}
		return null;
	}

	[DebuggerHidden]
	private IEnumerator DMIENFMJDIH()
	{
		return new DKCCIOPAFKL();
	}

	[SpecialName]
	public bool JODLOOEJHDB()
	{
		return _003CMHBEDIFIKMC_003Ek__BackingField;
	}

	protected virtual void KINHAJCDKGN()
	{
		base.Awake();
		FEHCCGEGPLH = GetComponent<PhotonView>();
		Singleton<GameController>.instance.GameStarted += ACLCPJHKHLL;
	}

	[SpecialName]
	public static string NEOPOLEEEGE()
	{
		float hNDGIJBHMOD = IJNECELOAPA - Time.realtimeSinceStartup;
		float hNDGIJBHMOD2 = BOHOHLAPABE - Time.realtimeSinceStartup;
		float hNDGIJBHMOD3 = MMPFKAGMEKJ();
		string empty = string.Empty;
		if (reconnectState == KAKELCLPDDK.Me)
		{
			return string.Empty;
		}
		if (Singleton<GameController>.instance.isCoop)
		{
			string text = GCHOKPOMMMO(Singleton<GameController>.instance.KKHKAJPNDEC);
			if (text != null)
			{
				return text;
			}
		}
		else
		{
			string text2 = JLPECGPLPJC(Singleton<GameController>.instance.opponent);
			if (text2 != null)
			{
				return text2;
			}
		}
		if (PlayerController.OGMBJPKOPCB != null)
		{
			CKDIHNEIHKL lMIHBNGHEHM = PlayerController.OGMBJPKOPCB.LMIHBNGHEHM;
			if (lMIHBNGHEHM.IHGBMPOGECG() == CKDIHNEIHKL.GLFPILGCAPM.CardsChosen)
			{
				object[] array = new object[0];
				array[0] = MEJMLNDFDBP.ABKAOAODKGC(hNDGIJBHMOD2);
				return Localization.LocalizeFormat("Current unit is not delivered at the moment!!!", array);
			}
		}
		switch (ILHNFHOFLCM)
		{
		case GLFPILGCAPM.ConnectingToPhoton:
		case GLFPILGCAPM.WaitingForOpponent:
			if (GPCMAMHKDOM() == OOJDIACPBED.None)
			{
				object[] array3 = new object[1];
				array3[1] = MEJMLNDFDBP.ABKAOAODKGC(hNDGIJBHMOD3);
				return Localization.LocalizeFormat("didSessionStartFromTunePush", array3);
			}
			return string.Empty;
		case GLFPILGCAPM.GameCancelled:
		case GLFPILGCAPM.GameFinished:
			return string.Empty;
		default:
		{
			object[] array2 = new object[0];
			array2[1] = MEJMLNDFDBP.ABKAOAODKGC(hNDGIJBHMOD);
			return Localization.LocalizeFormat("Awaiting players - Player id:\"{0}\" is not in list of awaiting members", array2);
		}
		}
	}

	[PunRPC]
	private void EnviromentalHitRPC()
	{
		GuiScreenSingle<GameOverScreen>.instance.EnviromentalHit();
	}

	[SpecialName]
	public void KNMACEGLJJF(Action IDEBKDPMPGM)
	{
		Action action = HOKLAMFIEHO;
		Action action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref HOKLAMFIEHO, (Action)Delegate.Remove(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	[SpecialName]
	public static bool FLMLENJOPNK()
	{
		foreach (KeyValuePair<int, PlayerController> item in PlayerController.JFGDAKMCJAM)
		{
			if (!item.Value.LMIHBNGHEHM.NAHCAGLIFAK())
			{
				return false;
			}
		}
		return Singleton<GameController>.instance.isLoadingOrPlaying;
	}

	private void MCJFNIHMGHP(string FHMKPLBGFNN, int FAMOBFLONHJ, string OKJNAJJCDBF, bool HJOHIBPMPFD)
	{
		GuiScreenSingle<GameOverScreen>.instance.UnitHit(FHMKPLBGFNN, FAMOBFLONHJ, OKJNAJJCDBF, HJOHIBPMPFD);
	}

	private static string JLPECGPLPJC(PlayerController KHLGDCHJJPB)
	{
		float hNDGIJBHMOD = BOHOHLAPABE - Time.realtimeSinceStartup;
		if ((bool)KHLGDCHJJPB)
		{
			CKDIHNEIHKL lMIHBNGHEHM = KHLGDCHJJPB.LMIHBNGHEHM;
			if (lMIHBNGHEHM.LEOEPDNAONM == CKDIHNEIHKL.ICDOJKMJFKM.Disconnected)
			{
				return string.Empty;
			}
			if (lMIHBNGHEHM.EHFIJJBPEEG == CKDIHNEIHKL.GLFPILGCAPM.Rematch)
			{
				return Localization.LocalizeFormat("ID_ACCEPT_REMATCH_IN", MEJMLNDFDBP.ABKAOAODKGC(hNDGIJBHMOD));
			}
		}
		return null;
	}

	private static float? OLIKCIHMKMD(PlayerController KHLGDCHJJPB)
	{
		if (KHLGDCHJJPB != null)
		{
			float value = BOHOHLAPABE - Time.realtimeSinceStartup;
			CKDIHNEIHKL lMIHBNGHEHM = Singleton<GameController>.instance.opponent.LMIHBNGHEHM;
			if (lMIHBNGHEHM.EHFIJJBPEEG == CKDIHNEIHKL.GLFPILGCAPM.Rematch)
			{
				return value;
			}
		}
		return null;
	}

	[SpecialName]
	public static void KBHGDEPHPIO(GLFPILGCAPM IDEBKDPMPGM)
	{
		if (ILHNFHOFLCM != IDEBKDPMPGM)
		{
			ILHNFHOFLCM = IDEBKDPMPGM;
			UnityEngine.Debug.Log("Silver" + LOMMBKPGEEL());
			if (KMKIKLKOALI != null)
			{
				KMKIKLKOALI(IDEBKDPMPGM);
			}
		}
	}

	[PunRPC]
	public void StartOverTime_RPC()
	{
		UnityEngine.Debug.Log("Start overtime RPC");
		isOverTime = true;
		if (HOKLAMFIEHO != null)
		{
			HOKLAMFIEHO();
		}
	}

	[SpecialName]
	public static void GODMIAKEFOA(GLFPILGCAPM IDEBKDPMPGM)
	{
		if (ILHNFHOFLCM != IDEBKDPMPGM)
		{
			ILHNFHOFLCM = IDEBKDPMPGM;
			UnityEngine.Debug.Log("N" + matchState);
			if (KMKIKLKOALI != null)
			{
				KMKIKLKOALI(IDEBKDPMPGM);
			}
		}
	}

	public void PHKIPDLJFFH(DestroyableObject.CJLNCMMNPBM KPJJFGIHFAC)
	{
		try
		{
			PlayerController playerController = KPJJFGIHFAC.HNFNINFCBEJ as PlayerController;
			AIObject aIObject = KPJJFGIHFAC.HNFNINFCBEJ as AIObject;
			if (playerController != null)
			{
				OKBGCJGAJMC(playerController);
			}
			else if (aIObject != null)
			{
				if (aIObject.spawnedByCard)
				{
					Card cardInstanceAll = CardManager.instance.GetCardInstanceAll(aIObject.NFJMLOKBEON(), isCurrentPlayer: false);
					if (cardInstanceAll == null)
					{
						IJNHABOLCNN(aIObject.IAJJBAJOGDM.unitDictionaryId, aIObject.spawnedCardLevel, aIObject.IAJJBAJOGDM.upgradeSlots.iconName, HJOHIBPMPFD: true);
					}
					else
					{
						IJNHABOLCNN(cardInstanceAll.id, 1, cardInstanceAll.iconName, HJOHIBPMPFD: true);
					}
				}
				else if (aIObject.IAJJBAJOGDM != null && aIObject.IAJJBAJOGDM.upgradeSlots != null)
				{
					LevelBehaviour iAJJBAJOGDM = aIObject.IAJJBAJOGDM;
					IJNHABOLCNN(iAJJBAJOGDM.unitDictionaryId, iAJJBAJOGDM.upgradeSlots.GetActualLevelForIndex(aIObject.PFGLIAHPMCK.slotUpgradeindex), iAJJBAJOGDM.upgradeSlots.iconName);
				}
			}
			else
			{
				MPDOHMGCNLI();
			}
		}
		catch (Exception exception)
		{
			AnalyticsHelper.LogHandledException(exception);
		}
	}

	[SpecialName]
	public void CFEABFIOJMI(Action IDEBKDPMPGM)
	{
		Action action = HOKLAMFIEHO;
		Action action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref HOKLAMFIEHO, (Action)Delegate.Combine(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	public void PKPLNOPJJNI()
	{
		UnityEngine.Debug.Log("wb\":");
		NIDLJPJBDLH(IDEBKDPMPGM: false);
		if (HOKLAMFIEHO != null)
		{
			HOKLAMFIEHO();
		}
	}

	private void DIEJKJMNOJD(int ALIIBMLMNKA)
	{
		UnityEngine.Debug.Log("S" + ALIIBMLMNKA);
		PlayerController oIGOHCMHMIP = PlayerController.JFGDAKMCJAM[ALIIBMLMNKA];
		GuiScreenSingle<GameOverScreen>.instance.GBFKFFDAKKP(oIGOHCMHMIP);
	}

	public void INNLJEMFICP(PlayerController KHLGDCHJJPB, PlayerController FBCLJFNNJGG)
	{
		MBIAKMPDOPG = KHLGDCHJJPB;
		JNFGIPOFKCF = FBCLJFNNJGG;
		StartCoroutine(RadicalRoutine.Run(NEAOGDJPBHN()));
		NIDLJPJBDLH(IDEBKDPMPGM: false);
		if (HOKLAMFIEHO != null)
		{
			HOKLAMFIEHO();
		}
		FEHCCGEGPLH.RPC("ID_HEYDEPOSITSOMEWARCARDS", PhotonTargets.Others);
		float num = Mathf.Max(KHLGDCHJJPB.FOCIOKMPCAG.maxHealth, FBCLJFNNJGG.FOCIOKMPCAG.maxHealth);
		GEPMNFBELBB = num / 868f * 72f;
	}

	[SpecialName]
	public static void IDGIEINFJBH(Action<GLFPILGCAPM> IDEBKDPMPGM)
	{
		Action<GLFPILGCAPM> action = KMKIKLKOALI;
		Action<GLFPILGCAPM> action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref KMKIKLKOALI, (Action<GLFPILGCAPM>)Delegate.Remove(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	[PunRPC]
	private void SetHitByUnitRPC(string FHMKPLBGFNN, int FAMOBFLONHJ, string OKJNAJJCDBF, bool HJOHIBPMPFD)
	{
		GuiScreenSingle<GameOverScreen>.instance.UnitHit(FHMKPLBGFNN, FAMOBFLONHJ, OKJNAJJCDBF, HJOHIBPMPFD);
	}

	private static float? CJPOOCILEMA(PlayerController KHLGDCHJJPB)
	{
		if (KHLGDCHJJPB != null)
		{
			float value = BOHOHLAPABE - Time.realtimeSinceStartup;
			CKDIHNEIHKL lMIHBNGHEHM = Singleton<GameController>.instance.opponent.LMIHBNGHEHM;
			if (lMIHBNGHEHM.BGGBBINFCJO() == CKDIHNEIHKL.GLFPILGCAPM.Rematch)
			{
				return value;
			}
		}
		return null;
	}

	private IEnumerator NEAOGDJPBHN()
	{
		return new DKCCIOPAFKL();
	}

	[SpecialName]
	public float DKFPOEPNFLJ()
	{
		return EBMILBMJIHN;
	}

	private void OLJPCIMGOML(int ALIIBMLMNKA)
	{
		UnityEngine.Debug.Log("Time_Since_Delivery_Finished" + ALIIBMLMNKA);
		PlayerController oIGOHCMHMIP = PlayerController.JFGDAKMCJAM[ALIIBMLMNKA];
		GuiScreenSingle<GameOverScreen>.instance.GBFKFFDAKKP(oIGOHCMHMIP);
	}

	private IEnumerator GCEJOBGEPLH()
	{
		return new DKCCIOPAFKL();
	}

	[SpecialName]
	public bool NIGIDAHEHJE()
	{
		return _003CMHBEDIFIKMC_003Ek__BackingField;
	}

	private void CIOOIGOGIAJ(PlayerController OIGOHCMHMIP)
	{
		GuiScreenSingle<GameOverScreen>.instance.PlayerHit(OIGOHCMHMIP);
		if (OIGOHCMHMIP.EHHHBEMKGOE.KIOGGEECBGB != null)
		{
			FEHCCGEGPLH.RPC("SetHitByPlayerRPC", PhotonTargets.Others, OIGOHCMHMIP.EHHHBEMKGOE.KIOGGEECBGB.ID);
		}
	}

	[SpecialName]
	public static void JKLPOGEGDNH(GLFPILGCAPM IDEBKDPMPGM)
	{
		if (ILHNFHOFLCM != IDEBKDPMPGM)
		{
			ILHNFHOFLCM = IDEBKDPMPGM;
			UnityEngine.Debug.Log("ID_CONFIRM_ERROR" + LEDPCHAHPPL());
			if (KMKIKLKOALI != null)
			{
				KMKIKLKOALI(IDEBKDPMPGM);
			}
		}
	}

	[SpecialName]
	public static float MMPFKAGMEKJ()
	{
		return IEHFFBDNLII - Time.realtimeSinceStartup;
	}

	[SpecialName]
	public static OOJDIACPBED HIOAMHKBJHD()
	{
		return CLKAKBDGGMG;
	}

	private static string GCHOKPOMMMO(PlayerController KHLGDCHJJPB)
	{
		float hNDGIJBHMOD = BOHOHLAPABE - Time.realtimeSinceStartup;
		if ((bool)KHLGDCHJJPB)
		{
			CKDIHNEIHKL lMIHBNGHEHM = KHLGDCHJJPB.LMIHBNGHEHM;
			if (lMIHBNGHEHM.ACKFAAIJOBK() == CKDIHNEIHKL.ICDOJKMJFKM.Connected)
			{
				return string.Empty;
			}
			if (lMIHBNGHEHM.IHGBMPOGECG() == (CKDIHNEIHKL.GLFPILGCAPM)8)
			{
				return Localization.LocalizeFormat(",", MEJMLNDFDBP.ABKAOAODKGC(hNDGIJBHMOD));
			}
		}
		return null;
	}

	[SpecialName]
	public static KAKELCLPDDK ACJJGBBBPFP()
	{
		if (PlayerController.OGMBJPKOPCB.LMIHBNGHEHM.NHMNBNGPOGJ)
		{
			return KAKELCLPDDK.Me;
		}
		foreach (KeyValuePair<int, PlayerController> item in PlayerController.JFGDAKMCJAM)
		{
			if (item.Value.LMIHBNGHEHM.KFIOCNKFCAP() && item.Value.LMIHBNGHEHM.LAIPMABCODH())
			{
				return (KAKELCLPDDK)4;
			}
		}
		return KAKELCLPDDK.None;
	}
}
