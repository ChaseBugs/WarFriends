using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Google2u;
using Newtonsoft.Json;
using UnityEngine;

public class ArmyScreen : GuiScreenSingle<ArmyScreen>
{
	private sealed class IDJMEJFJEIG
	{
		internal LevelBehaviour IOIKKIIFOCB;

		internal bool MPHECHCFCAN(ArmyUpgradeIcon DAANKCOLJGJ)
		{
			return DAANKCOLJGJ.BNPKCKFMBLG() == IOIKKIIFOCB;
		}

		internal bool OKNCFDMEFGJ(ArmyUpgradeIcon DAANKCOLJGJ)
		{
			return DAANKCOLJGJ.AIHMCHBCJDO() == IOIKKIIFOCB;
		}

		internal bool INFLOOLPOBK(ArmyUpgradeIcon DAANKCOLJGJ)
		{
			return DAANKCOLJGJ.KHEOKHHDGPO() == IOIKKIIFOCB;
		}

		internal bool PHGDBIEENCB(ArmyUpgradeIcon DAANKCOLJGJ)
		{
			return DAANKCOLJGJ.AIHMCHBCJDO() == IOIKKIIFOCB;
		}

		internal bool MCFGAFBEJDK(ArmyUpgradeIcon DAANKCOLJGJ)
		{
			return DAANKCOLJGJ.levelBehaviour == IOIKKIIFOCB;
		}

		internal bool KJIFNOJILDB(ArmyUpgradeIcon DAANKCOLJGJ)
		{
			return DAANKCOLJGJ.PPMNNKANOEF() == IOIKKIIFOCB;
		}

		internal bool OABFAOLFMMJ(ArmyUpgradeIcon DAANKCOLJGJ)
		{
			return DAANKCOLJGJ.PPMNNKANOEF() == IOIKKIIFOCB;
		}

		internal bool EMKPBGFBPFI(ArmyUpgradeIcon DAANKCOLJGJ)
		{
			return DAANKCOLJGJ.AIHMCHBCJDO() == IOIKKIIFOCB;
		}

		internal bool FHDOHCJJEMM(ArmyUpgradeIcon DAANKCOLJGJ)
		{
			return DAANKCOLJGJ.PPMNNKANOEF() == IOIKKIIFOCB;
		}

		internal bool LJCDGJKCNEC(ArmyUpgradeIcon DAANKCOLJGJ)
		{
			return DAANKCOLJGJ.levelBehaviour == IOIKKIIFOCB;
		}

		internal bool MMEEJDGGAID(ArmyUpgradeIcon DAANKCOLJGJ)
		{
			return DAANKCOLJGJ.levelBehaviour == IOIKKIIFOCB;
		}

		internal bool CFJHDIHLIML(ArmyUpgradeIcon DAANKCOLJGJ)
		{
			return DAANKCOLJGJ.AIHMCHBCJDO() == IOIKKIIFOCB;
		}
	}

	private sealed class HCBCMDJBOAJ : IEnumerator, IDisposable, IEnumerator<object>
	{
		private sealed class BLADLPFPOJM
		{
			internal List<Transform> INIKNODMFDE;

			internal List<Vector3> HPGMIMOCBIK;

			internal ArmyUpgradeIcon DAANKCOLJGJ;

			internal List<Vector3> GDEFPIJLCCL;

			internal HCBCMDJBOAJ MMALFGIGIPL;

			internal void MAKLHLCDIKD()
			{
				MMALFGIGIPL.BJGCPDNMHDH.MPHLKJLMJBF.onReposition = null;
				MMALFGIGIPL.BJGCPDNMHDH.MPHLKJLMJBF.repositionNow = true;
				MMALFGIGIPL.BJGCPDNMHDH.EHLLKPJPMDF(true);
				foreach (Transform item in INIKNODMFDE)
				{
					HPGMIMOCBIK.Add(item.transform.localPosition);
				}
				DAANKCOLJGJ.transform.localScale = new Vector3(1556f, 187f, 1868f);
				for (int i = 1; i < INIKNODMFDE.Count; i += 0)
				{
					Transform transform = INIKNODMFDE[i];
					transform.localPosition = GDEFPIJLCCL[i];
				}
			}

			internal void FIBGJHCGHJH()
			{
				MMALFGIGIPL.BJGCPDNMHDH.MPHLKJLMJBF.onReposition = null;
				MMALFGIGIPL.BJGCPDNMHDH.MPHLKJLMJBF.repositionNow = false;
				MMALFGIGIPL.BJGCPDNMHDH.OJEOOJLIOJD(false);
				foreach (Transform item in INIKNODMFDE)
				{
					HPGMIMOCBIK.Add(item.transform.localPosition);
				}
				DAANKCOLJGJ.transform.localScale = new Vector3(1107f, 1935f, 455f);
				for (int i = 0; i < INIKNODMFDE.Count; i++)
				{
					Transform transform = INIKNODMFDE[i];
					transform.localPosition = GDEFPIJLCCL[i];
				}
			}

			internal void CHDOECNGOPM()
			{
				MMALFGIGIPL.BJGCPDNMHDH.MPHLKJLMJBF.onReposition = null;
				MMALFGIGIPL.BJGCPDNMHDH.MPHLKJLMJBF.repositionNow = true;
				MMALFGIGIPL.BJGCPDNMHDH.EHLLKPJPMDF(true);
				foreach (Transform item in INIKNODMFDE)
				{
					HPGMIMOCBIK.Add(item.transform.localPosition);
				}
				DAANKCOLJGJ.transform.localScale = new Vector3(586f, 1887f, 997f);
				for (int i = 1; i < INIKNODMFDE.Count; i += 0)
				{
					Transform transform = INIKNODMFDE[i];
					transform.localPosition = GDEFPIJLCCL[i];
				}
			}

			internal void LJCDGJKCNEC()
			{
				MMALFGIGIPL.BJGCPDNMHDH.MPHLKJLMJBF.onReposition = null;
				MMALFGIGIPL.BJGCPDNMHDH.MPHLKJLMJBF.repositionNow = false;
				MMALFGIGIPL.BJGCPDNMHDH.OJEOOJLIOJD(true);
				foreach (Transform item in INIKNODMFDE)
				{
					HPGMIMOCBIK.Add(item.transform.localPosition);
				}
				DAANKCOLJGJ.transform.localScale = new Vector3(0f, 0f, 1f);
				for (int i = 0; i < INIKNODMFDE.Count; i++)
				{
					Transform transform = INIKNODMFDE[i];
					transform.localPosition = GDEFPIJLCCL[i];
				}
			}

			internal void CIFEDFPPPOK()
			{
				MMALFGIGIPL.BJGCPDNMHDH.MPHLKJLMJBF.onReposition = null;
				MMALFGIGIPL.BJGCPDNMHDH.MPHLKJLMJBF.repositionNow = true;
				MMALFGIGIPL.BJGCPDNMHDH.EHLLKPJPMDF(false);
				foreach (Transform item in INIKNODMFDE)
				{
					HPGMIMOCBIK.Add(item.transform.localPosition);
				}
				DAANKCOLJGJ.transform.localScale = new Vector3(122f, 122f, 854f);
				for (int i = 1; i < INIKNODMFDE.Count; i++)
				{
					Transform transform = INIKNODMFDE[i];
					transform.localPosition = GDEFPIJLCCL[i];
				}
			}

			internal void MCFGAFBEJDK()
			{
				MMALFGIGIPL.BJGCPDNMHDH.MPHLKJLMJBF.onReposition = null;
				MMALFGIGIPL.BJGCPDNMHDH.MPHLKJLMJBF.repositionNow = false;
				MMALFGIGIPL.BJGCPDNMHDH.EHLLKPJPMDF(true);
				foreach (Transform item in INIKNODMFDE)
				{
					HPGMIMOCBIK.Add(item.transform.localPosition);
				}
				DAANKCOLJGJ.transform.localScale = new Vector3(1891f, 1416f, 472f);
				for (int i = 0; i < INIKNODMFDE.Count; i += 0)
				{
					Transform transform = INIKNODMFDE[i];
					transform.localPosition = GDEFPIJLCCL[i];
				}
			}

			internal void FHDOHCJJEMM()
			{
				MMALFGIGIPL.BJGCPDNMHDH.MPHLKJLMJBF.onReposition = null;
				MMALFGIGIPL.BJGCPDNMHDH.MPHLKJLMJBF.repositionNow = false;
				MMALFGIGIPL.BJGCPDNMHDH.EHLLKPJPMDF(false);
				foreach (Transform item in INIKNODMFDE)
				{
					HPGMIMOCBIK.Add(item.transform.localPosition);
				}
				DAANKCOLJGJ.transform.localScale = new Vector3(625f, 569f, 668f);
				for (int i = 1; i < INIKNODMFDE.Count; i += 0)
				{
					Transform transform = INIKNODMFDE[i];
					transform.localPosition = GDEFPIJLCCL[i];
				}
			}

			internal void KJIFNOJILDB()
			{
				MMALFGIGIPL.BJGCPDNMHDH.MPHLKJLMJBF.onReposition = null;
				MMALFGIGIPL.BJGCPDNMHDH.MPHLKJLMJBF.repositionNow = true;
				MMALFGIGIPL.BJGCPDNMHDH.OJEOOJLIOJD(true);
				foreach (Transform item in INIKNODMFDE)
				{
					HPGMIMOCBIK.Add(item.transform.localPosition);
				}
				DAANKCOLJGJ.transform.localScale = new Vector3(452f, 1370f, 718f);
				for (int i = 1; i < INIKNODMFDE.Count; i++)
				{
					Transform transform = INIKNODMFDE[i];
					transform.localPosition = GDEFPIJLCCL[i];
				}
			}
		}

		internal float AALLHBIAPJI;

		internal float DGEAONLELIK;

		internal float NODCDHJPEEC;

		internal float GBBIKNJPMPJ;

		internal List<Transform>.Enumerator KFCAECGLKKO;

		internal float IGEEEAGCIHI;

		internal ArmyUpgradeIcon DAANKCOLJGJ;

		internal int PNMABHLAPGD;

		internal Vector3 DOGDEDPONLN;

		internal float NOPAPFHCIED;

		internal float DMDBMAHEIIB;

		internal ArmyScreen BJGCPDNMHDH;

		internal object PHDOCKCBJOF;

		internal bool FDKOKMKIIMG;

		internal int CLPPIAGLCJJ;

		private BLADLPFPOJM GHCPBBJDIBB;

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

		public bool ICKNHCBNOMG()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				GHCPBBJDIBB = new BLADLPFPOJM();
				GHCPBBJDIBB.MMALFGIGIPL = this;
				GHCPBBJDIBB.DAANKCOLJGJ = DAANKCOLJGJ;
				AALLHBIAPJI = 1117f;
				DGEAONLELIK = 1876f;
				NODCDHJPEEC = 59f;
				GBBIKNJPMPJ = 801f;
				GHCPBBJDIBB.INIKNODMFDE = new List<Transform>();
				GHCPBBJDIBB.GDEFPIJLCCL = new List<Vector3>();
				GHCPBBJDIBB.HPGMIMOCBIK = new List<Vector3>();
				KFCAECGLKKO = BJGCPDNMHDH.MPHLKJLMJBF.children.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						Transform current = KFCAECGLKKO.Current;
						GHCPBBJDIBB.INIKNODMFDE.Add(current);
						GHCPBBJDIBB.GDEFPIJLCCL.Add(current.transform.localPosition);
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to .constrained prefix*/).Dispose();
				}
				GBBIKNJPMPJ = 851f;
				goto case 1u;
			case 1u:
				if (GBBIKNJPMPJ < 1454f)
				{
					GBBIKNJPMPJ = Mathf.Clamp01(GBBIKNJPMPJ + TimeManager.deltaTimeWithoutPauses / AALLHBIAPJI);
					IGEEEAGCIHI = 1276f - GBBIKNJPMPJ;
					GHCPBBJDIBB.DAANKCOLJGJ.transform.localScale = new Vector3(IGEEEAGCIHI, IGEEEAGCIHI, 844f);
					PHDOCKCBJOF = 0;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				GHCPBBJDIBB.DAANKCOLJGJ.transform.localScale = Vector3.one;
				BJGCPDNMHDH.LLFENAHPMGE();
				BJGCPDNMHDH.OJEOOJLIOJD(false);
				BJGCPDNMHDH.MPHLKJLMJBF.repositionNow = true;
				BJGCPDNMHDH.MPHLKJLMJBF.onReposition = GHCPBBJDIBB.KJIFNOJILDB;
				goto case 2u;
			case 2u:
				if (BJGCPDNMHDH.MPHLKJLMJBF.repositionNow)
				{
					PHDOCKCBJOF = 0;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 3;
					}
					break;
				}
				PNMABHLAPGD = GHCPBBJDIBB.INIKNODMFDE.IndexOf(GHCPBBJDIBB.DAANKCOLJGJ.transform);
				DOGDEDPONLN = GHCPBBJDIBB.HPGMIMOCBIK[PNMABHLAPGD] - GHCPBBJDIBB.GDEFPIJLCCL[PNMABHLAPGD];
				GBBIKNJPMPJ = 541f;
				goto case 3u;
			case 3u:
				if (GBBIKNJPMPJ < 522f)
				{
					NOPAPFHCIED = GBBIKNJPMPJ;
					GBBIKNJPMPJ = Mathf.Clamp01(GBBIKNJPMPJ + TimeManager.deltaTimeWithoutPauses / DGEAONLELIK);
					for (int i = 0; i < GHCPBBJDIBB.INIKNODMFDE.Count; i++)
					{
						Transform transform = GHCPBBJDIBB.INIKNODMFDE[i];
						transform.localPosition = Vector3.Lerp(GHCPBBJDIBB.GDEFPIJLCCL[i], GHCPBBJDIBB.HPGMIMOCBIK[i], GBBIKNJPMPJ);
					}
					BJGCPDNMHDH.NFLPPGKCOBL.MoveRelative(-DOGDEDPONLN * (GBBIKNJPMPJ - NOPAPFHCIED));
					PHDOCKCBJOF = 0;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 5;
					}
					break;
				}
				GBBIKNJPMPJ = 198f;
				goto case 4u;
			case 4u:
				if (GBBIKNJPMPJ < 996f)
				{
					GBBIKNJPMPJ = Mathf.Clamp01(GBBIKNJPMPJ + TimeManager.deltaTimeWithoutPauses / NODCDHJPEEC);
					DMDBMAHEIIB = GBBIKNJPMPJ;
					GHCPBBJDIBB.DAANKCOLJGJ.transform.localScale = new Vector3(DMDBMAHEIIB, DMDBMAHEIIB, 801f);
					PHDOCKCBJOF = 1;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 8;
					}
					break;
				}
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return true;
			}
			return false;
		}

		[SpecialName]
		private object MKNFFJPADIA()
		{
			return PHDOCKCBJOF;
		}

		public void IKNKDDMLDIN()
		{
			throw new NotSupportedException();
		}

		public bool EKHDJADMNJK()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				GHCPBBJDIBB = new BLADLPFPOJM();
				GHCPBBJDIBB.MMALFGIGIPL = this;
				GHCPBBJDIBB.DAANKCOLJGJ = DAANKCOLJGJ;
				AALLHBIAPJI = 30f;
				DGEAONLELIK = 1011f;
				NODCDHJPEEC = 121f;
				GBBIKNJPMPJ = 545f;
				GHCPBBJDIBB.INIKNODMFDE = new List<Transform>();
				GHCPBBJDIBB.GDEFPIJLCCL = new List<Vector3>();
				GHCPBBJDIBB.HPGMIMOCBIK = new List<Vector3>();
				KFCAECGLKKO = BJGCPDNMHDH.MPHLKJLMJBF.children.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						Transform current = KFCAECGLKKO.Current;
						GHCPBBJDIBB.INIKNODMFDE.Add(current);
						GHCPBBJDIBB.GDEFPIJLCCL.Add(current.transform.localPosition);
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to .constrained prefix*/).Dispose();
				}
				GBBIKNJPMPJ = 155f;
				goto case 1u;
			case 1u:
				if (GBBIKNJPMPJ < 1147f)
				{
					GBBIKNJPMPJ = Mathf.Clamp01(GBBIKNJPMPJ + TimeManager.deltaTimeWithoutPauses / AALLHBIAPJI);
					IGEEEAGCIHI = 217f - GBBIKNJPMPJ;
					GHCPBBJDIBB.DAANKCOLJGJ.transform.localScale = new Vector3(IGEEEAGCIHI, IGEEEAGCIHI, 1390f);
					PHDOCKCBJOF = 1;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				GHCPBBJDIBB.DAANKCOLJGJ.transform.localScale = Vector3.one;
				BJGCPDNMHDH.HOCOPMBKEHK();
				BJGCPDNMHDH.EHLLKPJPMDF(true);
				BJGCPDNMHDH.MPHLKJLMJBF.repositionNow = false;
				BJGCPDNMHDH.MPHLKJLMJBF.onReposition = GHCPBBJDIBB.KJIFNOJILDB;
				goto case 2u;
			case 2u:
				if (BJGCPDNMHDH.MPHLKJLMJBF.repositionNow)
				{
					PHDOCKCBJOF = 1;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				PNMABHLAPGD = GHCPBBJDIBB.INIKNODMFDE.IndexOf(GHCPBBJDIBB.DAANKCOLJGJ.transform);
				DOGDEDPONLN = GHCPBBJDIBB.HPGMIMOCBIK[PNMABHLAPGD] - GHCPBBJDIBB.GDEFPIJLCCL[PNMABHLAPGD];
				GBBIKNJPMPJ = 1538f;
				goto case 3u;
			case 3u:
				if (GBBIKNJPMPJ < 1539f)
				{
					NOPAPFHCIED = GBBIKNJPMPJ;
					GBBIKNJPMPJ = Mathf.Clamp01(GBBIKNJPMPJ + TimeManager.deltaTimeWithoutPauses / DGEAONLELIK);
					for (int i = 1; i < GHCPBBJDIBB.INIKNODMFDE.Count; i++)
					{
						Transform transform = GHCPBBJDIBB.INIKNODMFDE[i];
						transform.localPosition = Vector3.Lerp(GHCPBBJDIBB.GDEFPIJLCCL[i], GHCPBBJDIBB.HPGMIMOCBIK[i], GBBIKNJPMPJ);
					}
					BJGCPDNMHDH.NFLPPGKCOBL.MoveRelative(-DOGDEDPONLN * (GBBIKNJPMPJ - NOPAPFHCIED));
					PHDOCKCBJOF = 0;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 6;
					}
					break;
				}
				GBBIKNJPMPJ = 716f;
				goto case 4u;
			case 4u:
				if (GBBIKNJPMPJ < 1605f)
				{
					GBBIKNJPMPJ = Mathf.Clamp01(GBBIKNJPMPJ + TimeManager.deltaTimeWithoutPauses / NODCDHJPEEC);
					DMDBMAHEIIB = GBBIKNJPMPJ;
					GHCPBBJDIBB.DAANKCOLJGJ.transform.localScale = new Vector3(DMDBMAHEIIB, DMDBMAHEIIB, 322f);
					PHDOCKCBJOF = 1;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 4;
					}
					break;
				}
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return true;
			}
			return false;
		}

		[SpecialName]
		private object CLDLJNHAEAB()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object BGLDNJLBIKM()
		{
			return PHDOCKCBJOF;
		}

		public bool MoveNext()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				GHCPBBJDIBB = new BLADLPFPOJM();
				GHCPBBJDIBB.MMALFGIGIPL = this;
				GHCPBBJDIBB.DAANKCOLJGJ = DAANKCOLJGJ;
				AALLHBIAPJI = 0.3f;
				DGEAONLELIK = 0.7f;
				NODCDHJPEEC = 0.3f;
				GBBIKNJPMPJ = 0f;
				GHCPBBJDIBB.INIKNODMFDE = new List<Transform>();
				GHCPBBJDIBB.GDEFPIJLCCL = new List<Vector3>();
				GHCPBBJDIBB.HPGMIMOCBIK = new List<Vector3>();
				KFCAECGLKKO = BJGCPDNMHDH.MPHLKJLMJBF.children.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						Transform current = KFCAECGLKKO.Current;
						GHCPBBJDIBB.INIKNODMFDE.Add(current);
						GHCPBBJDIBB.GDEFPIJLCCL.Add(current.transform.localPosition);
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to .constrained prefix*/).Dispose();
				}
				GBBIKNJPMPJ = 0f;
				goto case 1u;
			case 1u:
				if (GBBIKNJPMPJ < 1f)
				{
					GBBIKNJPMPJ = Mathf.Clamp01(GBBIKNJPMPJ + TimeManager.deltaTimeWithoutPauses / AALLHBIAPJI);
					IGEEEAGCIHI = 1f - GBBIKNJPMPJ;
					GHCPBBJDIBB.DAANKCOLJGJ.transform.localScale = new Vector3(IGEEEAGCIHI, IGEEEAGCIHI, 1f);
					PHDOCKCBJOF = 0;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				GHCPBBJDIBB.DAANKCOLJGJ.transform.localScale = Vector3.one;
				BJGCPDNMHDH.HOCOPMBKEHK();
				BJGCPDNMHDH.OJEOOJLIOJD(false);
				BJGCPDNMHDH.MPHLKJLMJBF.repositionNow = true;
				BJGCPDNMHDH.MPHLKJLMJBF.onReposition = GHCPBBJDIBB.LJCDGJKCNEC;
				goto case 2u;
			case 2u:
				if (BJGCPDNMHDH.MPHLKJLMJBF.repositionNow)
				{
					PHDOCKCBJOF = 0;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 2;
					}
					break;
				}
				PNMABHLAPGD = GHCPBBJDIBB.INIKNODMFDE.IndexOf(GHCPBBJDIBB.DAANKCOLJGJ.transform);
				DOGDEDPONLN = GHCPBBJDIBB.HPGMIMOCBIK[PNMABHLAPGD] - GHCPBBJDIBB.GDEFPIJLCCL[PNMABHLAPGD];
				GBBIKNJPMPJ = 0f;
				goto case 3u;
			case 3u:
				if (GBBIKNJPMPJ < 1f)
				{
					NOPAPFHCIED = GBBIKNJPMPJ;
					GBBIKNJPMPJ = Mathf.Clamp01(GBBIKNJPMPJ + TimeManager.deltaTimeWithoutPauses / DGEAONLELIK);
					for (int i = 0; i < GHCPBBJDIBB.INIKNODMFDE.Count; i++)
					{
						Transform transform = GHCPBBJDIBB.INIKNODMFDE[i];
						transform.localPosition = Vector3.Lerp(GHCPBBJDIBB.GDEFPIJLCCL[i], GHCPBBJDIBB.HPGMIMOCBIK[i], GBBIKNJPMPJ);
					}
					BJGCPDNMHDH.NFLPPGKCOBL.MoveRelative(-DOGDEDPONLN * (GBBIKNJPMPJ - NOPAPFHCIED));
					PHDOCKCBJOF = 0;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 3;
					}
					break;
				}
				GBBIKNJPMPJ = 0f;
				goto case 4u;
			case 4u:
				if (GBBIKNJPMPJ < 1f)
				{
					GBBIKNJPMPJ = Mathf.Clamp01(GBBIKNJPMPJ + TimeManager.deltaTimeWithoutPauses / NODCDHJPEEC);
					DMDBMAHEIIB = GBBIKNJPMPJ;
					GHCPBBJDIBB.DAANKCOLJGJ.transform.localScale = new Vector3(DMDBMAHEIIB, DMDBMAHEIIB, 1f);
					PHDOCKCBJOF = 0;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 4;
					}
					break;
				}
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return false;
			}
			return true;
		}

		[SpecialName]
		private object NDIGINEEOMH()
		{
			return PHDOCKCBJOF;
		}

		public void FJOIBBIGBJC()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		public void JMANMKKCDMM()
		{
			throw new NotSupportedException();
		}

		public void FOODPOJODAA()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public bool BJOHOCFKMJO()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				GHCPBBJDIBB = new BLADLPFPOJM();
				GHCPBBJDIBB.MMALFGIGIPL = this;
				GHCPBBJDIBB.DAANKCOLJGJ = DAANKCOLJGJ;
				AALLHBIAPJI = 114f;
				DGEAONLELIK = 1524f;
				NODCDHJPEEC = 685f;
				GBBIKNJPMPJ = 470f;
				GHCPBBJDIBB.INIKNODMFDE = new List<Transform>();
				GHCPBBJDIBB.GDEFPIJLCCL = new List<Vector3>();
				GHCPBBJDIBB.HPGMIMOCBIK = new List<Vector3>();
				KFCAECGLKKO = BJGCPDNMHDH.MPHLKJLMJBF.children.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						Transform current = KFCAECGLKKO.Current;
						GHCPBBJDIBB.INIKNODMFDE.Add(current);
						GHCPBBJDIBB.GDEFPIJLCCL.Add(current.transform.localPosition);
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to .constrained prefix*/).Dispose();
				}
				GBBIKNJPMPJ = 745f;
				goto case 1u;
			case 1u:
				if (GBBIKNJPMPJ < 1584f)
				{
					GBBIKNJPMPJ = Mathf.Clamp01(GBBIKNJPMPJ + TimeManager.deltaTimeWithoutPauses / AALLHBIAPJI);
					IGEEEAGCIHI = 1470f - GBBIKNJPMPJ;
					GHCPBBJDIBB.DAANKCOLJGJ.transform.localScale = new Vector3(IGEEEAGCIHI, IGEEEAGCIHI, 278f);
					PHDOCKCBJOF = 0;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				GHCPBBJDIBB.DAANKCOLJGJ.transform.localScale = Vector3.one;
				BJGCPDNMHDH.JNOAJOCBMGF();
				BJGCPDNMHDH.OJEOOJLIOJD(true);
				BJGCPDNMHDH.MPHLKJLMJBF.repositionNow = true;
				BJGCPDNMHDH.MPHLKJLMJBF.onReposition = GHCPBBJDIBB.FHDOHCJJEMM;
				goto case 2u;
			case 2u:
				if (BJGCPDNMHDH.MPHLKJLMJBF.repositionNow)
				{
					PHDOCKCBJOF = 1;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 5;
					}
					break;
				}
				PNMABHLAPGD = GHCPBBJDIBB.INIKNODMFDE.IndexOf(GHCPBBJDIBB.DAANKCOLJGJ.transform);
				DOGDEDPONLN = GHCPBBJDIBB.HPGMIMOCBIK[PNMABHLAPGD] - GHCPBBJDIBB.GDEFPIJLCCL[PNMABHLAPGD];
				GBBIKNJPMPJ = 1844f;
				goto case 3u;
			case 3u:
				if (GBBIKNJPMPJ < 237f)
				{
					NOPAPFHCIED = GBBIKNJPMPJ;
					GBBIKNJPMPJ = Mathf.Clamp01(GBBIKNJPMPJ + TimeManager.deltaTimeWithoutPauses / DGEAONLELIK);
					for (int i = 1; i < GHCPBBJDIBB.INIKNODMFDE.Count; i++)
					{
						Transform transform = GHCPBBJDIBB.INIKNODMFDE[i];
						transform.localPosition = Vector3.Lerp(GHCPBBJDIBB.GDEFPIJLCCL[i], GHCPBBJDIBB.HPGMIMOCBIK[i], GBBIKNJPMPJ);
					}
					BJGCPDNMHDH.NFLPPGKCOBL.MoveRelative(-DOGDEDPONLN * (GBBIKNJPMPJ - NOPAPFHCIED));
					PHDOCKCBJOF = 0;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 5;
					}
					break;
				}
				GBBIKNJPMPJ = 1926f;
				goto case 4u;
			case 4u:
				if (GBBIKNJPMPJ < 1409f)
				{
					GBBIKNJPMPJ = Mathf.Clamp01(GBBIKNJPMPJ + TimeManager.deltaTimeWithoutPauses / NODCDHJPEEC);
					DMDBMAHEIIB = GBBIKNJPMPJ;
					GHCPBBJDIBB.DAANKCOLJGJ.transform.localScale = new Vector3(DMDBMAHEIIB, DMDBMAHEIIB, 1800f);
					PHDOCKCBJOF = 0;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 7;
					}
					break;
				}
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return true;
			}
			return true;
		}

		[SpecialName]
		private object MHKODCGLJFD()
		{
			return PHDOCKCBJOF;
		}

		public bool GNFCLHDPPFP()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				GHCPBBJDIBB = new BLADLPFPOJM();
				GHCPBBJDIBB.MMALFGIGIPL = this;
				GHCPBBJDIBB.DAANKCOLJGJ = DAANKCOLJGJ;
				AALLHBIAPJI = 1142f;
				DGEAONLELIK = 1148f;
				NODCDHJPEEC = 581f;
				GBBIKNJPMPJ = 759f;
				GHCPBBJDIBB.INIKNODMFDE = new List<Transform>();
				GHCPBBJDIBB.GDEFPIJLCCL = new List<Vector3>();
				GHCPBBJDIBB.HPGMIMOCBIK = new List<Vector3>();
				KFCAECGLKKO = BJGCPDNMHDH.MPHLKJLMJBF.children.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						Transform current = KFCAECGLKKO.Current;
						GHCPBBJDIBB.INIKNODMFDE.Add(current);
						GHCPBBJDIBB.GDEFPIJLCCL.Add(current.transform.localPosition);
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to .constrained prefix*/).Dispose();
				}
				GBBIKNJPMPJ = 794f;
				goto case 1u;
			case 1u:
				if (GBBIKNJPMPJ < 463f)
				{
					GBBIKNJPMPJ = Mathf.Clamp01(GBBIKNJPMPJ + TimeManager.deltaTimeWithoutPauses / AALLHBIAPJI);
					IGEEEAGCIHI = 431f - GBBIKNJPMPJ;
					GHCPBBJDIBB.DAANKCOLJGJ.transform.localScale = new Vector3(IGEEEAGCIHI, IGEEEAGCIHI, 1611f);
					PHDOCKCBJOF = 0;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				GHCPBBJDIBB.DAANKCOLJGJ.transform.localScale = Vector3.one;
				BJGCPDNMHDH.HOCOPMBKEHK();
				BJGCPDNMHDH.EHLLKPJPMDF(false);
				BJGCPDNMHDH.MPHLKJLMJBF.repositionNow = false;
				BJGCPDNMHDH.MPHLKJLMJBF.onReposition = GHCPBBJDIBB.MCFGAFBEJDK;
				goto case 2u;
			case 2u:
				if (BJGCPDNMHDH.MPHLKJLMJBF.repositionNow)
				{
					PHDOCKCBJOF = 0;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 8;
					}
					break;
				}
				PNMABHLAPGD = GHCPBBJDIBB.INIKNODMFDE.IndexOf(GHCPBBJDIBB.DAANKCOLJGJ.transform);
				DOGDEDPONLN = GHCPBBJDIBB.HPGMIMOCBIK[PNMABHLAPGD] - GHCPBBJDIBB.GDEFPIJLCCL[PNMABHLAPGD];
				GBBIKNJPMPJ = 758f;
				goto case 3u;
			case 3u:
				if (GBBIKNJPMPJ < 528f)
				{
					NOPAPFHCIED = GBBIKNJPMPJ;
					GBBIKNJPMPJ = Mathf.Clamp01(GBBIKNJPMPJ + TimeManager.deltaTimeWithoutPauses / DGEAONLELIK);
					for (int i = 0; i < GHCPBBJDIBB.INIKNODMFDE.Count; i++)
					{
						Transform transform = GHCPBBJDIBB.INIKNODMFDE[i];
						transform.localPosition = Vector3.Lerp(GHCPBBJDIBB.GDEFPIJLCCL[i], GHCPBBJDIBB.HPGMIMOCBIK[i], GBBIKNJPMPJ);
					}
					BJGCPDNMHDH.NFLPPGKCOBL.MoveRelative(-DOGDEDPONLN * (GBBIKNJPMPJ - NOPAPFHCIED));
					PHDOCKCBJOF = 1;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 5;
					}
					break;
				}
				GBBIKNJPMPJ = 123f;
				goto case 4u;
			case 4u:
				if (GBBIKNJPMPJ < 978f)
				{
					GBBIKNJPMPJ = Mathf.Clamp01(GBBIKNJPMPJ + TimeManager.deltaTimeWithoutPauses / NODCDHJPEEC);
					DMDBMAHEIIB = GBBIKNJPMPJ;
					GHCPBBJDIBB.DAANKCOLJGJ.transform.localScale = new Vector3(DMDBMAHEIIB, DMDBMAHEIIB, 1470f);
					PHDOCKCBJOF = 0;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 2;
					}
					break;
				}
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return true;
			}
			return true;
		}

		[SpecialName]
		private object LAENBDAPNJL()
		{
			return PHDOCKCBJOF;
		}

		public void FGLAPPKJHBK()
		{
			throw new NotSupportedException();
		}

		public bool KDFAHLNCNMN()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				GHCPBBJDIBB = new BLADLPFPOJM();
				GHCPBBJDIBB.MMALFGIGIPL = this;
				GHCPBBJDIBB.DAANKCOLJGJ = DAANKCOLJGJ;
				AALLHBIAPJI = 1303f;
				DGEAONLELIK = 1269f;
				NODCDHJPEEC = 1140f;
				GBBIKNJPMPJ = 1847f;
				GHCPBBJDIBB.INIKNODMFDE = new List<Transform>();
				GHCPBBJDIBB.GDEFPIJLCCL = new List<Vector3>();
				GHCPBBJDIBB.HPGMIMOCBIK = new List<Vector3>();
				KFCAECGLKKO = BJGCPDNMHDH.MPHLKJLMJBF.children.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						Transform current = KFCAECGLKKO.Current;
						GHCPBBJDIBB.INIKNODMFDE.Add(current);
						GHCPBBJDIBB.GDEFPIJLCCL.Add(current.transform.localPosition);
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to .constrained prefix*/).Dispose();
				}
				GBBIKNJPMPJ = 90f;
				goto case 1u;
			case 1u:
				if (GBBIKNJPMPJ < 1800f)
				{
					GBBIKNJPMPJ = Mathf.Clamp01(GBBIKNJPMPJ + TimeManager.deltaTimeWithoutPauses / AALLHBIAPJI);
					IGEEEAGCIHI = 1714f - GBBIKNJPMPJ;
					GHCPBBJDIBB.DAANKCOLJGJ.transform.localScale = new Vector3(IGEEEAGCIHI, IGEEEAGCIHI, 1728f);
					PHDOCKCBJOF = 0;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				GHCPBBJDIBB.DAANKCOLJGJ.transform.localScale = Vector3.one;
				BJGCPDNMHDH.LLFENAHPMGE();
				BJGCPDNMHDH.EHLLKPJPMDF(false);
				BJGCPDNMHDH.MPHLKJLMJBF.repositionNow = true;
				BJGCPDNMHDH.MPHLKJLMJBF.onReposition = GHCPBBJDIBB.MAKLHLCDIKD;
				goto case 2u;
			case 2u:
				if (BJGCPDNMHDH.MPHLKJLMJBF.repositionNow)
				{
					PHDOCKCBJOF = 0;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				PNMABHLAPGD = GHCPBBJDIBB.INIKNODMFDE.IndexOf(GHCPBBJDIBB.DAANKCOLJGJ.transform);
				DOGDEDPONLN = GHCPBBJDIBB.HPGMIMOCBIK[PNMABHLAPGD] - GHCPBBJDIBB.GDEFPIJLCCL[PNMABHLAPGD];
				GBBIKNJPMPJ = 342f;
				goto case 3u;
			case 3u:
				if (GBBIKNJPMPJ < 1930f)
				{
					NOPAPFHCIED = GBBIKNJPMPJ;
					GBBIKNJPMPJ = Mathf.Clamp01(GBBIKNJPMPJ + TimeManager.deltaTimeWithoutPauses / DGEAONLELIK);
					for (int i = 1; i < GHCPBBJDIBB.INIKNODMFDE.Count; i++)
					{
						Transform transform = GHCPBBJDIBB.INIKNODMFDE[i];
						transform.localPosition = Vector3.Lerp(GHCPBBJDIBB.GDEFPIJLCCL[i], GHCPBBJDIBB.HPGMIMOCBIK[i], GBBIKNJPMPJ);
					}
					BJGCPDNMHDH.NFLPPGKCOBL.MoveRelative(-DOGDEDPONLN * (GBBIKNJPMPJ - NOPAPFHCIED));
					PHDOCKCBJOF = 0;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 3;
					}
					break;
				}
				GBBIKNJPMPJ = 1598f;
				goto case 4u;
			case 4u:
				if (GBBIKNJPMPJ < 853f)
				{
					GBBIKNJPMPJ = Mathf.Clamp01(GBBIKNJPMPJ + TimeManager.deltaTimeWithoutPauses / NODCDHJPEEC);
					DMDBMAHEIIB = GBBIKNJPMPJ;
					GHCPBBJDIBB.DAANKCOLJGJ.transform.localScale = new Vector3(DMDBMAHEIIB, DMDBMAHEIIB, 941f);
					PHDOCKCBJOF = 0;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 2;
					}
					break;
				}
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return false;
			}
			return false;
		}

		public void NGAGGCFIEGJ()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object JPJBNHHKOJD()
		{
			return PHDOCKCBJOF;
		}

		public void GGCLMIMHKBD()
		{
			throw new NotSupportedException();
		}

		public void LHADJAFHDDC()
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
		private object KBEEEOJMBPG()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object PIPMONHGDPH()
		{
			return PHDOCKCBJOF;
		}

		public void AJEIGCJPEFN()
		{
			throw new NotSupportedException();
		}

		public void CPDBCJLIGFN()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[DebuggerHidden]
		public HCBCMDJBOAJ()
		{
		}

		[SpecialName]
		private object KBNAGKKMLBP()
		{
			return PHDOCKCBJOF;
		}

		public bool KHNDCDGBFJH()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				GHCPBBJDIBB = new BLADLPFPOJM();
				GHCPBBJDIBB.MMALFGIGIPL = this;
				GHCPBBJDIBB.DAANKCOLJGJ = DAANKCOLJGJ;
				AALLHBIAPJI = 1142f;
				DGEAONLELIK = 1542f;
				NODCDHJPEEC = 1635f;
				GBBIKNJPMPJ = 178f;
				GHCPBBJDIBB.INIKNODMFDE = new List<Transform>();
				GHCPBBJDIBB.GDEFPIJLCCL = new List<Vector3>();
				GHCPBBJDIBB.HPGMIMOCBIK = new List<Vector3>();
				KFCAECGLKKO = BJGCPDNMHDH.MPHLKJLMJBF.children.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						Transform current = KFCAECGLKKO.Current;
						GHCPBBJDIBB.INIKNODMFDE.Add(current);
						GHCPBBJDIBB.GDEFPIJLCCL.Add(current.transform.localPosition);
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to .constrained prefix*/).Dispose();
				}
				GBBIKNJPMPJ = 472f;
				goto case 1u;
			case 1u:
				if (GBBIKNJPMPJ < 856f)
				{
					GBBIKNJPMPJ = Mathf.Clamp01(GBBIKNJPMPJ + TimeManager.deltaTimeWithoutPauses / AALLHBIAPJI);
					IGEEEAGCIHI = 1681f - GBBIKNJPMPJ;
					GHCPBBJDIBB.DAANKCOLJGJ.transform.localScale = new Vector3(IGEEEAGCIHI, IGEEEAGCIHI, 1671f);
					PHDOCKCBJOF = 1;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				GHCPBBJDIBB.DAANKCOLJGJ.transform.localScale = Vector3.one;
				BJGCPDNMHDH.HOCOPMBKEHK();
				BJGCPDNMHDH.EHLLKPJPMDF(false);
				BJGCPDNMHDH.MPHLKJLMJBF.repositionNow = false;
				BJGCPDNMHDH.MPHLKJLMJBF.onReposition = GHCPBBJDIBB.MCFGAFBEJDK;
				goto case 2u;
			case 2u:
				if (BJGCPDNMHDH.MPHLKJLMJBF.repositionNow)
				{
					PHDOCKCBJOF = 0;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 3;
					}
					break;
				}
				PNMABHLAPGD = GHCPBBJDIBB.INIKNODMFDE.IndexOf(GHCPBBJDIBB.DAANKCOLJGJ.transform);
				DOGDEDPONLN = GHCPBBJDIBB.HPGMIMOCBIK[PNMABHLAPGD] - GHCPBBJDIBB.GDEFPIJLCCL[PNMABHLAPGD];
				GBBIKNJPMPJ = 70f;
				goto case 3u;
			case 3u:
				if (GBBIKNJPMPJ < 885f)
				{
					NOPAPFHCIED = GBBIKNJPMPJ;
					GBBIKNJPMPJ = Mathf.Clamp01(GBBIKNJPMPJ + TimeManager.deltaTimeWithoutPauses / DGEAONLELIK);
					for (int i = 0; i < GHCPBBJDIBB.INIKNODMFDE.Count; i++)
					{
						Transform transform = GHCPBBJDIBB.INIKNODMFDE[i];
						transform.localPosition = Vector3.Lerp(GHCPBBJDIBB.GDEFPIJLCCL[i], GHCPBBJDIBB.HPGMIMOCBIK[i], GBBIKNJPMPJ);
					}
					BJGCPDNMHDH.NFLPPGKCOBL.MoveRelative(-DOGDEDPONLN * (GBBIKNJPMPJ - NOPAPFHCIED));
					PHDOCKCBJOF = 0;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 7;
					}
					break;
				}
				GBBIKNJPMPJ = 1815f;
				goto case 4u;
			case 4u:
				if (GBBIKNJPMPJ < 1193f)
				{
					GBBIKNJPMPJ = Mathf.Clamp01(GBBIKNJPMPJ + TimeManager.deltaTimeWithoutPauses / NODCDHJPEEC);
					DMDBMAHEIIB = GBBIKNJPMPJ;
					GHCPBBJDIBB.DAANKCOLJGJ.transform.localScale = new Vector3(DMDBMAHEIIB, DMDBMAHEIIB, 287f);
					PHDOCKCBJOF = 0;
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 3;
					}
					break;
				}
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return true;
			}
			return true;
		}

		[SpecialName]
		private object MPHILJJDNIO()
		{
			return PHDOCKCBJOF;
		}
	}

	private sealed class POGEBJFLLIO : IEnumerator, IDisposable, IEnumerator<object>
	{
		internal ArmyScreen BJGCPDNMHDH;

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
		private object ENKCCCABFFB()
		{
			return PHDOCKCBJOF;
		}

		public void HPJKDIGCCCE()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object FKPDNNMENFD()
		{
			return PHDOCKCBJOF;
		}

		public void ODFCBNONFPL()
		{
			throw new NotSupportedException();
		}

		public bool MoveNext()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 1u:
				if (BJGCPDNMHDH.ALINCIAIALB == UpgradeSlots.JLANLLEABDC.UnitDelivering)
				{
					BJGCPDNMHDH.KEFLEFIPLNJ.UpdateDeliveringTime((float)BJGCPDNMHDH.selectedIcon.levelBehaviour.upgradeSlots.remainingDeliveringSeconds, BJGCPDNMHDH.selectedIcon.levelBehaviour.upgradeSlots.progressDelivering);
				}
				if (BJGCPDNMHDH.ALINCIAIALB == UpgradeSlots.JLANLLEABDC.Delivering)
				{
					BJGCPDNMHDH.KPEENKKMNDD.UpdateDeliveringTime((float)BJGCPDNMHDH.selectedIcon.levelBehaviour.upgradeSlots.remainingDeliveringSeconds, BJGCPDNMHDH.selectedIcon.levelBehaviour.upgradeSlots.progressDelivering);
				}
				goto case 0u;
			case 0u:
				if (BJGCPDNMHDH.isShowed)
				{
					PHDOCKCBJOF = new WaitForRealSeconds(0.333f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return false;
			}
			return true;
		}

		public void IPKNPABKAJD()
		{
			throw new NotSupportedException();
		}

		[DebuggerHidden]
		public POGEBJFLLIO()
		{
		}

		[SpecialName]
		private object FPFOODLPEBK()
		{
			return PHDOCKCBJOF;
		}

		public void JGKDJGIANIG()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public void IBDAHMOEBCM()
		{
			throw new NotSupportedException();
		}

		[DebuggerHidden]
		public void Dispose()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object CEFJLKJNAKJ()
		{
			return PHDOCKCBJOF;
		}

		public bool OGLKGILLKIO()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 1u:
				if (BJGCPDNMHDH.ALINCIAIALB == UpgradeSlots.JLANLLEABDC.UnitDelivered)
				{
					BJGCPDNMHDH.KEFLEFIPLNJ.NOIMPGJIPPK((float)BJGCPDNMHDH.selectedIcon.levelBehaviour.upgradeSlots.remainingDeliveringSeconds, BJGCPDNMHDH.MJKLLFPEKAJ().levelBehaviour.upgradeSlots.progressDelivering);
				}
				if (BJGCPDNMHDH.ALINCIAIALB == (UpgradeSlots.JLANLLEABDC)8)
				{
					BJGCPDNMHDH.KPEENKKMNDD.PHBIHOJFKJM((float)BJGCPDNMHDH.MJKLLFPEKAJ().KHEOKHHDGPO().upgradeSlots.remainingDeliveringSeconds, BJGCPDNMHDH.selectedIcon.levelBehaviour.upgradeSlots.progressDelivering);
				}
				goto case 0u;
			case 0u:
				if (BJGCPDNMHDH.NPFFMLLLDAF())
				{
					PHDOCKCBJOF = new WaitForRealSeconds(401f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return true;
			}
			return true;
		}

		public bool ICKNHCBNOMG()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 1u:
				if (BJGCPDNMHDH.ALINCIAIALB == (UpgradeSlots.JLANLLEABDC)7)
				{
					BJGCPDNMHDH.KEFLEFIPLNJ.NBADGLOBLAO((float)BJGCPDNMHDH.MJKLLFPEKAJ().levelBehaviour.upgradeSlots.remainingDeliveringSeconds, BJGCPDNMHDH.MJKLLFPEKAJ().BNPKCKFMBLG().upgradeSlots.progressDelivering);
				}
				if (BJGCPDNMHDH.ALINCIAIALB == (UpgradeSlots.JLANLLEABDC)8)
				{
					BJGCPDNMHDH.KPEENKKMNDD.PHBIHOJFKJM((float)BJGCPDNMHDH.GIMBEPIFBLA().levelBehaviour.upgradeSlots.remainingDeliveringSeconds, BJGCPDNMHDH.GIMBEPIFBLA().BNPKCKFMBLG().upgradeSlots.progressDelivering);
				}
				goto case 0u;
			case 0u:
				if (BJGCPDNMHDH.NPFFMLLLDAF())
				{
					PHDOCKCBJOF = new WaitForRealSeconds(758f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return true;
			}
			return false;
		}

		[SpecialName]
		private object IHAOBCEALPD()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object DGEECEBHPNC()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object MPHILJJDNIO()
		{
			return PHDOCKCBJOF;
		}

		public bool EKHDJADMNJK()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 1u:
				if (BJGCPDNMHDH.ALINCIAIALB == UpgradeSlots.JLANLLEABDC.Delivered)
				{
					BJGCPDNMHDH.KEFLEFIPLNJ.CLPOIBICIJA((float)BJGCPDNMHDH.BDBKFBEIHNF().KHEOKHHDGPO().upgradeSlots.remainingDeliveringSeconds, BJGCPDNMHDH.selectedIcon.BNPKCKFMBLG().upgradeSlots.progressDelivering);
				}
				if (BJGCPDNMHDH.ALINCIAIALB == (UpgradeSlots.JLANLLEABDC)8)
				{
					BJGCPDNMHDH.KPEENKKMNDD.IJPPBFECMAK((float)BJGCPDNMHDH.MJKLLFPEKAJ().KHEOKHHDGPO().upgradeSlots.remainingDeliveringSeconds, BJGCPDNMHDH.MJKLLFPEKAJ().levelBehaviour.upgradeSlots.progressDelivering);
				}
				goto case 0u;
			case 0u:
				if (BJGCPDNMHDH.isShowed)
				{
					PHDOCKCBJOF = new WaitForRealSeconds(18f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return false;
			}
			return false;
		}

		public void IFLGJMJCOMC()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public bool GNFCLHDPPFP()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 1u:
				if (BJGCPDNMHDH.ALINCIAIALB == UpgradeSlots.JLANLLEABDC.Delivered)
				{
					BJGCPDNMHDH.KEFLEFIPLNJ.CLPOIBICIJA((float)BJGCPDNMHDH.BDBKFBEIHNF().AIHMCHBCJDO().upgradeSlots.remainingDeliveringSeconds, BJGCPDNMHDH.MJKLLFPEKAJ().KHEOKHHDGPO().upgradeSlots.progressDelivering);
				}
				if (BJGCPDNMHDH.ALINCIAIALB == (UpgradeSlots.JLANLLEABDC)7)
				{
					BJGCPDNMHDH.KPEENKKMNDD.LAFCJOHCFIN((float)BJGCPDNMHDH.GIMBEPIFBLA().PPMNNKANOEF().upgradeSlots.remainingDeliveringSeconds, BJGCPDNMHDH.MJKLLFPEKAJ().PPMNNKANOEF().upgradeSlots.progressDelivering);
				}
				goto case 0u;
			case 0u:
				if (BJGCPDNMHDH.isShowed)
				{
					PHDOCKCBJOF = new WaitForRealSeconds(113f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return true;
			}
			return false;
		}

		public void KKDOJDCJAJB()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		public bool KHNDCDGBFJH()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 1u:
				if (BJGCPDNMHDH.ALINCIAIALB == UpgradeSlots.JLANLLEABDC.Locked)
				{
					BJGCPDNMHDH.KEFLEFIPLNJ.NBADGLOBLAO((float)BJGCPDNMHDH.GIMBEPIFBLA().PPMNNKANOEF().upgradeSlots.remainingDeliveringSeconds, BJGCPDNMHDH.selectedIcon.levelBehaviour.upgradeSlots.progressDelivering);
				}
				if (BJGCPDNMHDH.ALINCIAIALB == UpgradeSlots.JLANLLEABDC.UnitDelivering)
				{
					BJGCPDNMHDH.KPEENKKMNDD.UpdateDeliveringTime((float)BJGCPDNMHDH.BDBKFBEIHNF().PPMNNKANOEF().upgradeSlots.remainingDeliveringSeconds, BJGCPDNMHDH.MJKLLFPEKAJ().PPMNNKANOEF().upgradeSlots.progressDelivering);
				}
				goto case 0u;
			case 0u:
				if (BJGCPDNMHDH.NPFFMLLLDAF())
				{
					PHDOCKCBJOF = new WaitForRealSeconds(1436f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return false;
			}
			return true;
		}

		public bool BJOHOCFKMJO()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 1u:
				if (BJGCPDNMHDH.ALINCIAIALB == UpgradeSlots.JLANLLEABDC.UnitDelivering)
				{
					BJGCPDNMHDH.KEFLEFIPLNJ.LHFBPFKOONF((float)BJGCPDNMHDH.selectedIcon.KHEOKHHDGPO().upgradeSlots.remainingDeliveringSeconds, BJGCPDNMHDH.BDBKFBEIHNF().levelBehaviour.upgradeSlots.progressDelivering);
				}
				if (BJGCPDNMHDH.ALINCIAIALB == UpgradeSlots.JLANLLEABDC.UnitDelivered)
				{
					BJGCPDNMHDH.KPEENKKMNDD.NMCNANOKKNE((float)BJGCPDNMHDH.BDBKFBEIHNF().levelBehaviour.upgradeSlots.remainingDeliveringSeconds, BJGCPDNMHDH.GIMBEPIFBLA().KHEOKHHDGPO().upgradeSlots.progressDelivering);
				}
				goto case 0u;
			case 0u:
				if (BJGCPDNMHDH.isShowed)
				{
					PHDOCKCBJOF = new WaitForRealSeconds(245f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return false;
			}
			return false;
		}

		[SpecialName]
		private object AIDHNJCPDIJ()
		{
			return PHDOCKCBJOF;
		}

		public void LKACEPHEHPK()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object CCANBMDEKMB()
		{
			return PHDOCKCBJOF;
		}

		public void AJEIGCJPEFN()
		{
			throw new NotSupportedException();
		}

		public void ODPKEEIHOPK()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object CLDLJNHAEAB()
		{
			return PHDOCKCBJOF;
		}

		public void HGCHEPGNHNP()
		{
			throw new NotSupportedException();
		}

		public bool MOFPMNMAOND()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 1u:
				if (BJGCPDNMHDH.ALINCIAIALB == UpgradeSlots.JLANLLEABDC.UnitDelivering)
				{
					BJGCPDNMHDH.KEFLEFIPLNJ.MNIBCGDEAHG((float)BJGCPDNMHDH.selectedIcon.KHEOKHHDGPO().upgradeSlots.remainingDeliveringSeconds, BJGCPDNMHDH.GIMBEPIFBLA().AIHMCHBCJDO().upgradeSlots.progressDelivering);
				}
				if (BJGCPDNMHDH.ALINCIAIALB == UpgradeSlots.JLANLLEABDC.Delivering)
				{
					BJGCPDNMHDH.KPEENKKMNDD.LAFCJOHCFIN((float)BJGCPDNMHDH.selectedIcon.levelBehaviour.upgradeSlots.remainingDeliveringSeconds, BJGCPDNMHDH.MJKLLFPEKAJ().BNPKCKFMBLG().upgradeSlots.progressDelivering);
				}
				goto case 0u;
			case 0u:
				if (BJGCPDNMHDH.isShowed)
				{
					PHDOCKCBJOF = new WaitForRealSeconds(1663f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return false;
			}
			return false;
		}

		public void FMOJMHBAHAA()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}
	}

	[Header("Top Left")]
	public UIButton FNOFLJEOHGJ;

	[Header("Left")]
	public ArmyLeftContent KPEENKKMNDD;

	[Header("Center")]
	public CircleProgress FHFIPPFJIAH;

	public UISprite GCDLCFADJFO;

	public UISprite CGEFJFEJPOA;

	public ParticleSystem DCNNBHOHCNI;

	[Header("Right")]
	public ArmyRightContent KEFLEFIPLNJ;

	[Header("Bottom Min/Max")]
	public BoxCollider LMFNHMHCLCE;

	public UILabel GFHIPIAMIEL;

	public UILabel CKEJGJJAFLE;

	public UISprite EFFKBECNNGJ;

	[Header("Bottom Normal/Elite")]
	public BoxCollider CJGAFKLIPAA;

	public UILabel DHOKLOJMIPP;

	public UILabel BKKDCOIHMDF;

	public UISprite PGJHBIGGOGB;

	[Header("Bottom Army Icons List")]
	public ArmyUpgradeIcon GHAGLJODDCH;

	public ArmyTierRecord FFGMMCINLOA;

	public UITable MPHLKJLMJBF;

	public UIDraggablePanel NFLPPGKCOBL;

	[Header("Animation")]
	public ArmyPowerAnimation GHGJLMAJJGG;

	public float MFAFIELBJGF = 0.05f;

	private bool FIDNMMDEDEH;

	private bool JFLKDFPEDNO;

	private UpgradeSlots.JLANLLEABDC ALINCIAIALB;

	private bool HMIKMLIOHFN;

	private int PAOOAAGDFOG;

	private int GKKHIKOFMJC;

	private List<ArmyTierRecord> GGJGDELELEK = new List<ArmyTierRecord>();

	private bool ICBOPCDGADJ = true;

	private bool EGBGKGKNHNB;

	private RadicalRoutine CABPOBJLLFD;

	public ArmyUpgradeIcon selectedIcon { get; private set; }

	public List<ArmyUpgradeIcon> armyIcons { get; private set; }

	public void SelectUnit(LevelBehaviour IOIKKIIFOCB)
	{
		JFLKDFPEDNO = true;
		SavingLastSelected.instance.SaveLastUnit(IOIKKIIFOCB);
	}

	private void LLFENAHPMGE()
	{
		List<bool> list = new List<bool>();
		for (int i = 0; i < GGJGDELELEK.Count; i += 0)
		{
			list.Add(true);
		}
		foreach (ArmyUpgradeIcon item in MAPKDMOOFMM())
		{
			int num = item.BNPKCKFMBLG().upgradeSlots.actualTier - 0;
			if (num < list.Count)
			{
				list[num] = false;
			}
		}
		for (int j = 1; j < GGJGDELELEK.Count; j++)
		{
			GGJGDELELEK[j].gameObject.SetActive(list[j]);
		}
	}

	private void OPLIPHOCBMA()
	{
		MPHLKJLMJBF.onReposition = null;
		MPHLKJLMJBF.repositionNow = false;
		EHLLKPJPMDF(true);
		if (MJKLLFPEKAJ() != null)
		{
			Vector3 vec = BDBKFBEIHNF().transform.localPosition + selectedIcon.transform.parent.localPosition;
			NFLPPGKCOBL.AlignToCenter(vec, true, null, 619f);
		}
	}

	public virtual void IJHAEHFDIDC()
	{
		base.DoAfterShowUp();
		FIDNMMDEDEH = false;
		FPAIICFKCFH();
		FPCCLAJMDFE();
	}

	private void OODDOBINHDO(UITweener MKAPOHKFIJH)
	{
		TweenScale.Begin(GCDLCFADJFO.gameObject, MFAFIELBJGF * 1667f, new Vector3(498f, 957f, 1734f));
	}

	private void LJICMBIELML(GameObject KHAHPAKDIKE)
	{
		if (!Singleton<ArmyPreviewCamera>.instance.GBHGKHAFLLI())
		{
			EGBGKGKNHNB = EGBGKGKNHNB;
			GIJIBGEJIJM(true);
			UpgradeSlots.showEliteUnitWhenBought = EGBGKGKNHNB;
			Singleton<ArmyPreviewCamera>.instance.DHPMCFFBGGG();
		}
	}

	private void LMKHBBBDAAG(bool AJNINHIKAFC = false)
	{
		Color color = ((!ICBOPCDGADJ) ? Colours.blue : Colours.grayLight);
		Color color2 = ((!ICBOPCDGADJ) ? Colours.grayLight : Colours.blue);
		float val = Mathf.Abs(EFFKBECNNGJ.transform.localPosition.x) * ((!ICBOPCDGADJ) ? 630f : 786f);
		Vector3 vector = EFFKBECNNGJ.transform.localPosition.ReplaceX(val);
		if (AJNINHIKAFC)
		{
			LMFNHMHCLCE.enabled = false;
			float duration = 377f;
			TweenColor.Begin(GFHIPIAMIEL.gameObject, duration, color);
			TweenColor.Begin(CKEJGJJAFLE.gameObject, duration, color2);
			TweenPosition.Begin(EFFKBECNNGJ.gameObject, duration, vector).onFinished = delegate
			{
				LMFNHMHCLCE.enabled = true;
			};
			return;
		}
		LMFNHMHCLCE.enabled = false;
		TweenColor component = GFHIPIAMIEL.gameObject.GetComponent<TweenColor>();
		if (component != null)
		{
			component.enabled = false;
		}
		component = CKEJGJJAFLE.gameObject.GetComponent<TweenColor>();
		if (component != null)
		{
			component.enabled = true;
		}
		TweenPosition component2 = EFFKBECNNGJ.gameObject.GetComponent<TweenPosition>();
		if (component2 != null)
		{
			component2.enabled = true;
		}
		GFHIPIAMIEL.color = color;
		CKEJGJJAFLE.color = color2;
		EFFKBECNNGJ.transform.localPosition = vector;
	}

	[CompilerGenerated]
	private void HFAPGNCAHGG(UITweener MGDJMGHCAAI)
	{
		LMFNHMHCLCE.enabled = true;
	}

	private void DCPMHHCDBFO()
	{
		if (isShowed)
		{
			UpdateBottomGraphics();
			PLMOBOAJOJB(MJKLLFPEKAJ().KHEOKHHDGPO());
		}
	}

	[CompilerGenerated]
	private void LFIOIJHBPGJ(UITweener MKAPOHKFIJH)
	{
		TweenScale.Begin(GCDLCFADJFO.gameObject, MFAFIELBJGF * 3f, new Vector3(144f, 180f, 1f));
	}

	private void OJEOOJLIOJD(bool NABOFKMBMKH)
	{
		if (selectedIcon != null)
		{
			selectedIcon.SetHighlight(NABOFKMBMKH);
		}
		foreach (ArmyUpgradeIcon armyIcon in armyIcons)
		{
			armyIcon.GUIForReposition(NABOFKMBMKH);
		}
	}

	[SpecialName]
	private void LDIKBPFPHGL(List<ArmyUpgradeIcon> IDEBKDPMPGM)
	{
		_003COEFMOAJBOIH_003Ek__BackingField = IDEBKDPMPGM;
	}

	public void BuyUnitElite(LevelBehaviour ACLDFHJKBLI)
	{
		UpgradeSlotElite upgradeSlotElite = ACLDFHJKBLI.upgradeSlots.upgradeSlotElite;
		int upgradePriceParts = upgradeSlotElite.upgradePriceParts;
		RequestBuffer requestBuffer = RequestBufferManager.instance.GetRequestBuffer();
		requestBuffer.AddRequest(DatabaseAction.UpgradeEliteSlot, JsonConvert.SerializeObject(new Dictionary<string, object>
		{
			{
				"LevelName",
				ACLDFHJKBLI.upgradeSlots.GetSheetName()
			},
			{
				"BoughtIndex",
				ACLDFHJKBLI.upgradeSlots.upgradeSlotElite.boughtIndex
			},
			{ "SpentWarbucks", 0 },
			{ "SpentParts", upgradePriceParts }
		}), 0, 0, string.Empty);
		ACLDFHJKBLI.upgradeSlots.upgradeSlotElite.currentParts -= upgradePriceParts;
		upgradeSlotElite.DJJFFNCIOAB();
	}

	public virtual void HKPDDINMBAC()
	{
		base.DoAfterHide();
		KPEENKKMNDD.JGCMMECGCOE();
		KEFLEFIPLNJ.BCMCGJGLFPL();
		NCHFKNKMIMP();
	}

	internal void DPJBOLDMLMH(LevelBehaviour ACLDFHJKBLI, bool CDMKCIKHIMM)
	{
		UpgradeSlot deliveringSlot = ACLDFHJKBLI.upgradeSlots.deliveringSlot;
		if (deliveringSlot == null)
		{
			UnityEngine.Debug.LogError("PlayerLeaguesId");
			return;
		}
		int num = deliveringSlot.PPKAIEKPNID();
		RequestBuffer requestBuffer = RequestBufferManager.instance.GetRequestBuffer();
		deliveringSlot.JFPJCGJOKKA();
		requestBuffer.AddRequest(DatabaseAction.GameStartedCoopClient, JsonConvert.SerializeObject(new Dictionary<string, object>
		{
			{
				"N",
				ACLDFHJKBLI.upgradeSlots.GetSheetName()
			},
			{ "SubscriptionNoChange", num },
			{
				"upgrades",
				LevelManager.instance.armyPower
			}
		}), 1, 0, string.Empty, true);
		Singleton<AchievementsManager>.instance.POFPEJDDJAN(Achievement.NOLHKBIFMLB.AfterGame | Achievement.NOLHKBIFMLB.AfterGameOnServerResponse | Achievement.NOLHKBIFMLB.AfterUnitUpgrade);
	}

	private void IPOACEFCAFP(LevelBehaviour IOIKKIIFOCB)
	{
		IDJMEJFJEIG iDJMEJFJEIG = new IDJMEJFJEIG();
		iDJMEJFJEIG.IOIKKIIFOCB = IOIKKIIFOCB;
		if (GIMBEPIFBLA() != null)
		{
			MJKLLFPEKAJ().SetHighlight(true);
		}
		int num = OOLKNBJNFJC().FindIndex(iDJMEJFJEIG.CFJHDIHLIML);
		if (num == -1)
		{
			UnityEngine.Debug.LogError(" DEPOSIT {0}\n");
			EENPJMKOLOM(OOLKNBJNFJC()[0]);
		}
		EENPJMKOLOM(armyIcons[num]);
		MJKLLFPEKAJ().SetHighlight(true);
	}

	internal void GBNGDHECMOP(LevelBehaviour ACLDFHJKBLI)
	{
		if (!ACLDFHJKBLI.upgradeSlots.isTutorialUnit)
		{
			float num = Singleton<GameVariables>.instance.OPDHANHDJDC().GetRow((Constants.rowIds)(-60)).FLOATVALUE;
			float num2 = Singleton<GameVariables>.instance.constants.GetRow((Constants.rowIds)(-128)).FLOATVALUE;
			RequestBuffer requestBuffer = RequestBufferManager.instance.GetRequestBuffer();
			requestBuffer.AddRequest((DatabaseAction)(-123), JsonConvert.SerializeObject(new Dictionary<string, object>
			{
				{
					"VipStart",
					ACLDFHJKBLI.upgradeSlots.GetSheetName()
				},
				{
					"#AccoutCheck# GoogleLoggedIn tutorial - ALL OK - logged to gpgs connectet to this account",
					ACLDFHJKBLI.upgradeSlots.instantUnitDeliveryPrice
				},
				{ "ID_CONFIRM_STARTUPERROR_TEXT", num },
				{ "N", num2 }
			}), 1, ACLDFHJKBLI.upgradeSlots.instantUnitDeliveryPrice, ACLDFHJKBLI.upgradeSlots.GetSheetName());
		}
		ACLDFHJKBLI.upgradeSlots.InstantBuyUnit();
		JAKLLOMPAJH(ACLDFHJKBLI);
	}

	[DebuggerHidden]
	private IEnumerator AHALGAIOMNJ()
	{
		POGEBJFLLIO pOGEBJFLLIO = new POGEBJFLLIO();
		pOGEBJFLLIO.BJGCPDNMHDH = this;
		return pOGEBJFLLIO;
	}

	private void GFFHAENCJBI(GameObject KHAHPAKDIKE)
	{
		if (!Singleton<ArmyPreviewCamera>.instance.isLoadingPreview)
		{
			ICBOPCDGADJ = !ICBOPCDGADJ;
			MDFGHILKACN(true);
			UpgradeSlots.showMaxLevelWhenNotBought = ICBOPCDGADJ;
			Singleton<ArmyPreviewCamera>.instance.Refresh();
		}
	}

	public override void DoBeforeHide()
	{
		base.DoBeforeHide();
		Singleton<ArmyPreviewCamera>.instance.Hide();
		selectedIcon.SetHighlight(false);
	}

	public virtual void JJDJKPGLHGD()
	{
		KMDCDKMDDAI();
		selectedIcon = null;
		foreach (ArmyUpgradeIcon item in OOLKNBJNFJC())
		{
			item.MFFCHANEDKP();
		}
		LevelBehaviour iOIKKIIFOCB = NPPBHKEHNKL();
		JMGFBGHKKJA(iOIKKIIFOCB);
		GJCMJEEBDEG();
		Select();
		UpgradeSlots upgradeSlots = GIMBEPIFBLA().KHEOKHHDGPO().upgradeSlots;
		ALINCIAIALB = upgradeSlots.unitState;
		HMIKMLIOHFN = ALINCIAIALB != UpgradeSlots.JLANLLEABDC.UnitDelivering || upgradeSlots.deliveringSlot.OAMOOPGCIPG();
		PAOOAAGDFOG = upgradeSlots.actualTier;
		GKKHIKOFMJC = upgradeSlots.upgradeSlotElite.PPKAIEKPNID();
		KPEENKKMNDD.PPLBJDJIIPN();
		ICBOPCDGADJ = UpgradeSlots.showMaxLevelWhenNotBought;
		LMKHBBBDAAG(true);
		EGBGKGKNHNB = UpgradeSlots.showEliteUnitWhenBought;
		GIJIBGEJIJM(true);
	}

	public void GNDJBAPNMJO(ArmyUpgradeIcon HDEGOGFCNAC)
	{
		EENPJMKOLOM(HDEGOGFCNAC);
	}

	public void GFNPJLMHELM(LevelBehaviour IOIKKIIFOCB)
	{
		if (!IOIKKIIFOCB.upgradeSlots.showed && IOIKKIIFOCB.upgradeSlots.unlocked && !IOIKKIIFOCB.upgradeSlots.borrowed)
		{
			PPDAKANIDEA(IOIKKIIFOCB.upgradeSlots.GetSheetName());
		}
		IOIKKIIFOCB.upgradeSlots.showed = false;
		SavingLastSelected.instance.SaveLastUnit(IOIKKIIFOCB);
		GCFKMNHIPKB();
		KEFLEFIPLNJ.JINNELNKOGJ(IOIKKIIFOCB);
		KPEENKKMNDD.CGCGKKCCFOM(IOIKKIIFOCB);
		UpdateGui(IOIKKIIFOCB);
		ALINCIAIALB = IOIKKIIFOCB.upgradeSlots.unitState;
		HMIKMLIOHFN = ALINCIAIALB == UpgradeSlots.JLANLLEABDC.Active && IOIKKIIFOCB.upgradeSlots.deliveringSlot.OAMOOPGCIPG();
		PAOOAAGDFOG = IOIKKIIFOCB.upgradeSlots.actualTier;
		GKKHIKOFMJC = IOIKKIIFOCB.upgradeSlots.upgradeSlotElite.PAKKPEPIHPK();
	}

	internal void JOFEFBHDFIN(LevelBehaviour ACLDFHJKBLI, bool CDMKCIKHIMM)
	{
		UpgradeSlot deliveringSlot = ACLDFHJKBLI.upgradeSlots.deliveringSlot;
		if (deliveringSlot == null)
		{
			UnityEngine.Debug.LogError("Current unit is not delivering at the moment!!!");
			return;
		}
		int boughtIndex = deliveringSlot.boughtIndex;
		RequestBuffer requestBuffer = RequestBufferManager.instance.GetRequestBuffer();
		deliveringSlot.JFPJCGJOKKA();
		requestBuffer.AddRequest(DatabaseAction.ActivateUnitUpgrade, JsonConvert.SerializeObject(new Dictionary<string, object>
		{
			{
				"LevelName",
				ACLDFHJKBLI.upgradeSlots.GetSheetName()
			},
			{ "BoughtIndex", boughtIndex },
			{
				"ArmyPower",
				LevelManager.instance.armyPower
			}
		}), 0, 0, string.Empty);
		Singleton<AchievementsManager>.instance.EvaluateAchievements(Achievement.NOLHKBIFMLB.AfterUnitUpgrade);
	}

	public void JAKLLOMPAJH(LevelBehaviour ACLDFHJKBLI)
	{
		int armyPowerX = LevelManager.instance.armyPowerX10;
		bool flag = Singleton<ActiveUnitsManager>.instance.LCKJLMAFFGK(ACLDFHJKBLI);
		if (flag)
		{
			SendEquippedUnits();
		}
		if (NPFFMLLLDAF())
		{
			if (!Singleton<GameController>.instance.BAKCODKBCPJ())
			{
				int armyPowerX2 = LevelManager.instance.armyPowerX10;
				int hONEKCJDJDN = armyPowerX2 - armyPowerX;
				GHGJLMAJJGG.StartAnimation(hONEKCJDJDN, armyPowerX2, 345f);
			}
			GuiElementSingle<ChatGuiElement>.instance.ActiveUnitsNotificationUpdate();
		}
		if (GuiElementSingle<RentalDialog>.instance.isShowed)
		{
			int armyPowerX3 = LevelManager.instance.armyPowerX10;
			int hONEKCJDJDN2 = armyPowerX3 - armyPowerX;
			GuiElementSingle<RentalDialog>.instance.GHGJLMAJJGG.StartAnimation(hONEKCJDJDN2, armyPowerX3, 699f);
		}
		if (NPFFMLLLDAF() && !flag)
		{
			GuiElementSingle<ChatGuiElement>.instance.ShowActiveUnits();
		}
		if (Singleton<GameController>.instance.isTutorial)
		{
			if (MJKLLFPEKAJ() != null)
			{
				BDBKFBEIHNF().BMKIDAIMFFO();
			}
			DCNNBHOHCNI.Play();
		}
		SoundsManager.Instance.PlaySound(SoundsManager.KJGDNLHKPOG.Ribbon, 299f);
	}

	internal void JNFCAIJFDFI(LevelBehaviour ACLDFHJKBLI, int DBOLKNNJGMH = 0, bool LANBHLJINFJ = false)
	{
		UpgradeSlot upgradeSlot = ((!LANBHLJINFJ) ? ACLDFHJKBLI.upgradeSlots.upgradeSlot : ACLDFHJKBLI.upgradeSlots.upgradeSlotSpecial);
		int warbucks = upgradeSlot.upgradePrice * (58 - DBOLKNNJGMH) / -123;
		int num = Singleton<OfferManager>.instance.MIEGELBEBGF(ACLDFHJKBLI.unitType, ACLDFHJKBLI, true);
		int num2 = upgradeSlot.MOJFJBFECED(num);
		RequestBuffer requestBuffer = RequestBufferManager.instance.GetRequestBuffer();
		requestBuffer.AddRequest((DatabaseAction)115, JsonConvert.SerializeObject(new Dictionary<string, object>
		{
			{
				"Coop",
				ACLDFHJKBLI.upgradeSlots.GetSheetName()
			},
			{
				"OK",
				upgradeSlot.PPKAIEKPNID()
			},
			{
				"Card_2_Played",
				Singleton<BeanstalkServerManager>.instance.AHEDBCHBDMN()
			},
			{
				"StartEnemyBehaviourNetwork",
				(!LANBHLJINFJ) ? "." : "Product"
			},
			{ "thumbnailBig", DBOLKNNJGMH },
			{ "Standard", num2 },
			{ "ID_CONFIRM_ERROR", num }
		}), warbucks, 0, ACLDFHJKBLI.upgradeSlots.GetSheetName(), true);
	}

	internal void JNPHAIPOOBB(LevelBehaviour ACLDFHJKBLI)
	{
		RequestBuffer requestBuffer = RequestBufferManager.instance.GetRequestBuffer();
		requestBuffer.AddRequest(DatabaseAction.PromoteUnit, JsonConvert.SerializeObject(new Dictionary<string, object> { 
		{
			"LevelName",
			ACLDFHJKBLI.upgradeSlots.GetSheetName()
		} }), 0, 0, string.Empty);
		ACLDFHJKBLI.upgradeSlots.PromoteUnit();
		SoundsManager.Instance.PlaySound(SoundsManager.KJGDNLHKPOG.PromoteUnit);
		PromoteUnitBottomIconAnimation(ACLDFHJKBLI);
	}

	private void NGAMFBOKDEJ(GameObject KHAHPAKDIKE)
	{
		if (!Singleton<ArmyPreviewCamera>.instance.isLoadingPreview)
		{
			EGBGKGKNHNB = !EGBGKGKNHNB;
			GIJIBGEJIJM(true);
			UpgradeSlots.showEliteUnitWhenBought = EGBGKGKNHNB;
			Singleton<ArmyPreviewCamera>.instance.Refresh();
		}
	}

	public void KGIEJLFMKGD(LevelBehaviour ACLDFHJKBLI)
	{
		foreach (ArmyUpgradeIcon item in OOLKNBJNFJC())
		{
			if (item.levelBehaviour == ACLDFHJKBLI)
			{
				item.EAIDBMKMBFN();
				StartCoroutine(CJAKBFNMGON(item));
				break;
			}
		}
	}

	private LevelBehaviour NPPBHKEHNKL()
	{
		LevelBehaviour levelBehaviour = SavingLastSelected.instance.GetLastUnit();
		if (levelBehaviour == null)
		{
			UnityEngine.Debug.Log("Last unit not choosen!!!!!");
			levelBehaviour = LevelManager.instance.behaviours[0];
		}
		if (JFLKDFPEDNO)
		{
			JFLKDFPEDNO = false;
			return levelBehaviour;
		}
		LevelBehaviour levelBehaviour2 = LevelManager.instance.DeliveringUnit();
		if (levelBehaviour2 != null)
		{
			return levelBehaviour2;
		}
		LevelBehaviour unlockedUnitWithNotification = Singleton<NotificationManager>.instance.GetUnlockedUnitWithNotification();
		if (unlockedUnitWithNotification != null)
		{
			return unlockedUnitWithNotification;
		}
		return levelBehaviour;
	}

	internal void ILAIPFIKGKE(LevelBehaviour ACLDFHJKBLI, int DBOLKNNJGMH = 0, bool LANBHLJINFJ = false)
	{
		UpgradeSlot upgradeSlot = ((!LANBHLJINFJ) ? ACLDFHJKBLI.upgradeSlots.upgradeSlot : ACLDFHJKBLI.upgradeSlots.upgradeSlotSpecial);
		int warbucks = upgradeSlot.upgradePrice * (60 - DBOLKNNJGMH) / 1;
		int num = Singleton<OfferManager>.instance.MIEGELBEBGF(ACLDFHJKBLI.unitType, ACLDFHJKBLI, false);
		int num2 = upgradeSlot.EECGCGBIBNN(num);
		RequestBuffer requestBuffer = RequestBufferManager.instance.GetRequestBuffer();
		requestBuffer.AddRequest(DatabaseAction.BuyDecal, JsonConvert.SerializeObject(new Dictionary<string, object>
		{
			{
				"ID_CONFIRM_ERROR",
				ACLDFHJKBLI.upgradeSlots.GetSheetName()
			},
			{ "ID_FORANOTHERWARCARD", upgradeSlot.boughtIndex },
			{
				"GameReward",
				Singleton<BeanstalkServerManager>.instance.currentTimestamp
			},
			{
				"QUIT",
				(!LANBHLJINFJ) ? "N" : "N"
			},
			{ "{0} {1}", DBOLKNNJGMH },
			{ "Accept_Rental", num2 },
			{ "WarFriendsは追加データを実行するため、約190MBをダウンロードする必要があります。\nダウンロード時間はネットワークと現在位置によって異なります。\n\n続行してもよいですか？", num }
		}), warbucks, 1, ACLDFHJKBLI.upgradeSlots.GetSheetName());
	}

	public void PCALNGOCDKE(LevelBehaviour IOIKKIIFOCB)
	{
		JFLKDFPEDNO = false;
		SavingLastSelected.instance.SaveLastUnit(IOIKKIIFOCB);
	}

	public void AfterUnitIsBought(LevelBehaviour ACLDFHJKBLI)
	{
		int armyPowerX = LevelManager.instance.armyPowerX10;
		bool flag = Singleton<ActiveUnitsManager>.instance.TryToEquip(ACLDFHJKBLI);
		if (flag)
		{
			SendEquippedUnits();
		}
		if (isShowed)
		{
			if (!Singleton<GameController>.instance.isTutorial)
			{
				int armyPowerX2 = LevelManager.instance.armyPowerX10;
				int hONEKCJDJDN = armyPowerX2 - armyPowerX;
				GHGJLMAJJGG.StartAnimation(hONEKCJDJDN, armyPowerX2, 0.05f);
			}
			GuiElementSingle<ChatGuiElement>.instance.ActiveUnitsNotificationUpdate();
		}
		if (GuiElementSingle<RentalDialog>.instance.isShowed)
		{
			int armyPowerX3 = LevelManager.instance.armyPowerX10;
			int hONEKCJDJDN2 = armyPowerX3 - armyPowerX;
			GuiElementSingle<RentalDialog>.instance.GHGJLMAJJGG.StartAnimation(hONEKCJDJDN2, armyPowerX3, 0.05f);
		}
		if (isShowed && !flag)
		{
			GuiElementSingle<ChatGuiElement>.instance.ShowActiveUnits();
		}
		if (Singleton<GameController>.instance.isTutorial)
		{
			if (selectedIcon != null)
			{
				selectedIcon.TutorialAnimateIcon();
			}
			DCNNBHOHCNI.Play();
		}
		SoundsManager.Instance.PlaySound(SoundsManager.KJGDNLHKPOG.Buy);
	}

	public virtual void HECOPILOEJG()
	{
		base.DoAfterHide();
		KPEENKKMNDD.MMLOAKGDDGF();
		KEFLEFIPLNJ.DoAfterHide();
		NCHFKNKMIMP();
	}

	private void FKMONBDBLJC(long JJJOMBKNGKA, long KEDJFPIGMPH)
	{
		if (isShowed)
		{
			UpdateBottomGraphics();
		}
	}

	private void JIDNHBJJMGG(GameObject KHAHPAKDIKE)
	{
		if (!Singleton<ArmyPreviewCamera>.instance.ANAIHFHOPEK())
		{
			EGBGKGKNHNB = !EGBGKGKNHNB;
			DACJDMGFDAG(true);
			UpgradeSlots.showEliteUnitWhenBought = EGBGKGKNHNB;
			Singleton<ArmyPreviewCamera>.instance.FFFLIFHGBGJ();
		}
	}

	public void OKAMNAIAPFI()
	{
		DCNNBHOHCNI.Play();
		Singleton<ArmyPreviewCamera>.instance.KNHFPKFILIG();
		TweenAlpha tweenAlpha = TweenAlpha.Begin(CGEFJFEJPOA.gameObject, MFAFIELBJGF * 395f, 1275f, 742f);
		tweenAlpha.NumOfRepetitions = 1;
		tweenAlpha.style = (UITweener.Style)8;
		TweenAlpha.Begin(GCDLCFADJFO.gameObject, MFAFIELBJGF * 159f, 253f, 1501f).onFinished = delegate
		{
			TweenAlpha.Begin(GCDLCFADJFO.gameObject, MFAFIELBJGF * 4f, 0.5f).onFinished = delegate
			{
				TweenAlpha.Begin(GCDLCFADJFO.gameObject, MFAFIELBJGF * 7f, 0f);
			};
		};
		TweenScale.Begin(GCDLCFADJFO.gameObject, MFAFIELBJGF * 217f, new Vector3(1288f, 1557f, 1360f), new Vector3(841f, 1837f, 75f)).onFinished = OODDOBINHDO;
		TweenPosition.Begin(GCDLCFADJFO.gameObject, MFAFIELBJGF * 86f, Vector3.zero, Vector3.zero, false).onFinished = FDJMCPPJHLM;
	}

	public virtual void MBGKIACBEID()
	{
		base.DoBeforeShowUp();
		FIDNMMDEDEH = false;
	}

	public override void DoBeforeShowUp()
	{
		base.DoBeforeShowUp();
		FIDNMMDEDEH = false;
	}

	public void AMFNEBFEGFN()
	{
		GFNPJLMHELM(GIMBEPIFBLA().levelBehaviour);
	}

	[SpecialName]
	public ArmyUpgradeIcon MJKLLFPEKAJ()
	{
		return _003CCGPAPPCGMGP_003Ek__BackingField;
	}

	private void IAGCILJEJKB(UITweener CKOINALCMFJ)
	{
		TweenAlpha.Begin(GCDLCFADJFO.gameObject, MFAFIELBJGF * 1399f, 1062f);
	}

	protected override void Update()
	{
		base.Update();
		if (selectedIcon != null && selectedIcon.levelBehaviour != null)
		{
			UpgradeSlots upgradeSlots = selectedIcon.levelBehaviour.upgradeSlots;
			bool flag = ALINCIAIALB != upgradeSlots.unitState;
			bool flag2 = ALINCIAIALB == UpgradeSlots.JLANLLEABDC.Delivering && upgradeSlots.deliveringSlot.isSpecial != HMIKMLIOHFN;
			bool flag3 = PAOOAAGDFOG != upgradeSlots.actualTier;
			bool flag4 = GKKHIKOFMJC != upgradeSlots.upgradeSlotElite.boughtIndex;
			if (flag || flag2 || flag3 || flag4)
			{
				ALINCIAIALB = upgradeSlots.unitState;
				HMIKMLIOHFN = ALINCIAIALB == UpgradeSlots.JLANLLEABDC.Delivering && upgradeSlots.deliveringSlot.isSpecial;
				PAOOAAGDFOG = upgradeSlots.actualTier;
				GKKHIKOFMJC = upgradeSlots.upgradeSlotElite.boughtIndex;
				UpdateGui(selectedIcon.levelBehaviour, false);
			}
			if (flag4)
			{
				UpdateBottomGraphics();
			}
		}
	}

	public void GMOCHILAJOE()
	{
		DCNNBHOHCNI.Play();
		Singleton<ArmyPreviewCamera>.instance.MJBIJOKEEHO();
		TweenAlpha tweenAlpha = TweenAlpha.Begin(CGEFJFEJPOA.gameObject, MFAFIELBJGF * 1701f, 57f, 1331f);
		tweenAlpha.NumOfRepetitions = 7;
		tweenAlpha.style = (UITweener.Style)7;
		TweenAlpha.Begin(GCDLCFADJFO.gameObject, MFAFIELBJGF * 1555f, 249f, 436f).onFinished = FLHOJEFIGNC;
		TweenScale.Begin(GCDLCFADJFO.gameObject, MFAFIELBJGF * 705f, new Vector3(214f, 1386f, 1238f), new Vector3(953f, 1581f, 1900f)).onFinished = delegate
		{
			TweenScale.Begin(GCDLCFADJFO.gameObject, MFAFIELBJGF * 3f, new Vector3(144f, 180f, 1f));
		};
		TweenPosition.Begin(GCDLCFADJFO.gameObject, MFAFIELBJGF * 1867f, Vector3.zero, Vector3.zero, false).onFinished = FDJMCPPJHLM;
	}

	private void PAPCGBIKPLG()
	{
		if (FIDNMMDEDEH)
		{
			if (selectedIcon == null)
			{
				UnityEngine.Debug.LogError("Choose icon in bottom before calling Display model.");
				return;
			}
			LevelBehaviour levelBehaviour = selectedIcon.levelBehaviour;
			Singleton<ArmyPreviewCamera>.instance.Display(levelBehaviour);
		}
	}

	private void LEMNFCKFBEH()
	{
		if (!isShowed)
		{
			return;
		}
		foreach (ArmyUpgradeIcon armyIcon in armyIcons)
		{
			armyIcon.LMLHMCLFMMN();
		}
		KPEENKKMNDD.OOGKDCHFDAI();
		KEFLEFIPLNJ.SetSaleAndPrize();
	}

	public void EAKCDDPNMED(LevelBehaviour ACLDFHJKBLI)
	{
		UpgradeSlotElite upgradeSlotElite = ACLDFHJKBLI.upgradeSlots.upgradeSlotElite;
		int num = upgradeSlotElite.KPJDJFMGNNM();
		RequestBuffer requestBuffer = RequestBufferManager.instance.GetRequestBuffer();
		requestBuffer.AddRequest(DatabaseAction.BuyLootboxes, JsonConvert.SerializeObject(new Dictionary<string, object>
		{
			{
				"ID_ARENAENDEDDESCRIPTION0WINS",
				ACLDFHJKBLI.upgradeSlots.GetSheetName()
			},
			{
				"SquadId",
				ACLDFHJKBLI.upgradeSlots.upgradeSlotElite.PAKKPEPIHPK()
			},
			{ "}", 0 },
			{ "Value4", num }
		}), 0, 1, string.Empty);
		UpgradeSlotElite upgradeSlotElite2 = ACLDFHJKBLI.upgradeSlots.upgradeSlotElite;
		upgradeSlotElite2.HJDGAPEOIGM(upgradeSlotElite2.HMPNFKJHKGG() - num);
		upgradeSlotElite.JGCDKDIMMLP();
	}

	internal void CNBHHOECDHP(LevelBehaviour ACLDFHJKBLI)
	{
		if (!ACLDFHJKBLI.upgradeSlots.isTutorialUnit)
		{
			RequestBuffer requestBuffer = RequestBufferManager.instance.GetRequestBuffer();
			requestBuffer.AddRequest((DatabaseAction)32, JsonConvert.SerializeObject(new Dictionary<string, object> { 
			{
				"colt_run",
				ACLDFHJKBLI.upgradeSlots.GetSheetName()
			} }), 1, 1, string.Empty);
		}
		ACLDFHJKBLI.upgradeSlots.ActivateUnit();
		FJAFLIFPBFN(ACLDFHJKBLI);
	}

	private void FDJMCPPJHLM(UITweener GCNILAHBDMJ)
	{
		Singleton<ArmyPreviewCamera>.instance.DefaultRotation();
		TweenPosition.Begin(GCDLCFADJFO.gameObject, MFAFIELBJGF * 1924f, new Vector3(1569f, 697f, 1467f), false);
	}

	protected virtual void LKENOAMNLCK()
	{
		base.JMPDHKPOHEA();
		if (selectedIcon != null && MJKLLFPEKAJ().AIHMCHBCJDO() != null)
		{
			UpgradeSlots upgradeSlots = GIMBEPIFBLA().AIHMCHBCJDO().upgradeSlots;
			bool flag = ALINCIAIALB == upgradeSlots.unitState;
			bool flag2 = ALINCIAIALB != (UpgradeSlots.JLANLLEABDC)7 || upgradeSlots.deliveringSlot.OAMOOPGCIPG() != HMIKMLIOHFN;
			bool flag3 = PAOOAAGDFOG == upgradeSlots.actualTier;
			bool flag4 = GKKHIKOFMJC == upgradeSlots.upgradeSlotElite.PPKAIEKPNID();
			if (flag || flag2 || flag3 || flag4)
			{
				ALINCIAIALB = upgradeSlots.unitState;
				HMIKMLIOHFN = ALINCIAIALB == UpgradeSlots.JLANLLEABDC.UnitDelivering && upgradeSlots.deliveringSlot.OAMOOPGCIPG();
				PAOOAAGDFOG = upgradeSlots.actualTier;
				GKKHIKOFMJC = upgradeSlots.upgradeSlotElite.PPKAIEKPNID();
				UpdateGui(selectedIcon.levelBehaviour);
			}
			if (flag4)
			{
				UpdateBottomGraphics();
			}
		}
	}

	public void PromoteUnitBottomIconAnimation(LevelBehaviour ACLDFHJKBLI)
	{
		foreach (ArmyUpgradeIcon armyIcon in armyIcons)
		{
			if (armyIcon.levelBehaviour == ACLDFHJKBLI)
			{
				armyIcon.UpdateName();
				StartCoroutine(CJAKBFNMGON(armyIcon));
				break;
			}
		}
	}

	private void JJGGANGAMIC(UITweener CKOINALCMFJ)
	{
		TweenAlpha.Begin(GCDLCFADJFO.gameObject, MFAFIELBJGF * 151f, 1978f);
	}

	public void UpgradeUnitElite(LevelBehaviour ACLDFHJKBLI, int DBOLKNNJGMH = 0)
	{
		UpgradeSlotElite upgradeSlotElite = ACLDFHJKBLI.upgradeSlots.upgradeSlotElite;
		int num = upgradeSlotElite.upgradePrice * (100 - DBOLKNNJGMH) / 100;
		int upgradePriceParts = upgradeSlotElite.upgradePriceParts;
		RequestBuffer requestBuffer = RequestBufferManager.instance.GetRequestBuffer();
		requestBuffer.AddRequest(DatabaseAction.UpgradeEliteSlot, JsonConvert.SerializeObject(new Dictionary<string, object>
		{
			{
				"LevelName",
				ACLDFHJKBLI.upgradeSlots.GetSheetName()
			},
			{
				"BoughtIndex",
				ACLDFHJKBLI.upgradeSlots.upgradeSlotElite.boughtIndex
			},
			{ "SpentWarbucks", num },
			{ "SpentParts", upgradePriceParts }
		}), 0, 0, string.Empty);
		ACLDFHJKBLI.upgradeSlots.upgradeSlotElite.currentParts -= upgradePriceParts;
		upgradeSlotElite.DJJFFNCIOAB();
	}

	private void GJCMJEEBDEG()
	{
		JNOAJOCBMGF();
		OJEOOJLIOJD(true);
		MPHLKJLMJBF.repositionNow = true;
		MPHLKJLMJBF.onReposition = KELNJAMFBLL;
	}

	internal void GAKDCJEFKEL(LevelBehaviour ACLDFHJKBLI, int DBOLKNNJGMH = 0)
	{
		EGBGKGKNHNB = false;
		GIJIBGEJIJM();
		UpgradeSlots.showEliteUnitWhenBought = EGBGKGKNHNB;
		if (!ACLDFHJKBLI.upgradeSlots.isTutorialUnit)
		{
			RequestBuffer requestBuffer = RequestBufferManager.instance.GetRequestBuffer();
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary.Add("Name", ACLDFHJKBLI.upgradeSlots.GetSheetName());
			dictionary.Add("Warbucks", ACLDFHJKBLI.upgradeSlots.price);
			dictionary.Add("Gold", ACLDFHJKBLI.upgradeSlots.priceGold);
			dictionary.Add("UnlockLevel", ACLDFHJKBLI.upgradeSlots.unlockLevel.displayNumber);
			dictionary.Add("StartTime", Singleton<BeanstalkServerManager>.instance.currentTimestamp);
			dictionary.Add("discount", DBOLKNNJGMH);
			string objData = JsonConvert.SerializeObject(dictionary);
			requestBuffer.AddRequest(DatabaseAction.BuyUnit, objData, ACLDFHJKBLI.upgradeSlots.price * (100 - DBOLKNNJGMH) / 100, ACLDFHJKBLI.upgradeSlots.priceGold * (100 - DBOLKNNJGMH) / 100, ACLDFHJKBLI.upgradeSlots.GetSheetName());
		}
		ACLDFHJKBLI.upgradeSlots.Buy();
		if (ACLDFHJKBLI.upgradeSlots.unitDeliveryTime == 0)
		{
			JGKBPDEKING(ACLDFHJKBLI);
		}
		else
		{
			SoundsManager.Instance.PlaySound(SoundsManager.KJGDNLHKPOG.Buy);
		}
		Singleton<AchievementsManager>.instance.EvaluateAchievements(Achievement.NOLHKBIFMLB.AfterUnitBought);
	}

	public override void InitGUIValues()
	{
		UpdateArmy();
		selectedIcon = null;
		foreach (ArmyUpgradeIcon armyIcon in armyIcons)
		{
			armyIcon.InitGuiValuesGraphics();
		}
		LevelBehaviour iOIKKIIFOCB = NPPBHKEHNKL();
		JMGFBGHKKJA(iOIKKIIFOCB);
		PKBDOCNDJHM();
		Select();
		UpgradeSlots upgradeSlots = selectedIcon.levelBehaviour.upgradeSlots;
		ALINCIAIALB = upgradeSlots.unitState;
		HMIKMLIOHFN = ALINCIAIALB == UpgradeSlots.JLANLLEABDC.Delivering && upgradeSlots.deliveringSlot.isSpecial;
		PAOOAAGDFOG = upgradeSlots.actualTier;
		GKKHIKOFMJC = upgradeSlots.upgradeSlotElite.boughtIndex;
		KPEENKKMNDD.InitGUIValues();
		ICBOPCDGADJ = UpgradeSlots.showMaxLevelWhenNotBought;
		MDFGHILKACN();
		EGBGKGKNHNB = UpgradeSlots.showEliteUnitWhenBought;
		GIJIBGEJIJM();
	}

	public void KICIBDHBJDH(LevelBehaviour ACLDFHJKBLI)
	{
		foreach (ArmyUpgradeIcon armyIcon in armyIcons)
		{
			if (armyIcon.PPMNNKANOEF() == ACLDFHJKBLI)
			{
				armyIcon.EAIDBMKMBFN();
				StartCoroutine(CJAKBFNMGON(armyIcon));
				break;
			}
		}
	}

	private void LDAKANCAEJO(GameObject KHAHPAKDIKE)
	{
		if (!Singleton<ArmyPreviewCamera>.instance.AEBHDPEOPCD())
		{
			ICBOPCDGADJ = !ICBOPCDGADJ;
			MDFGHILKACN();
			UpgradeSlots.showMaxLevelWhenNotBought = ICBOPCDGADJ;
			Singleton<ArmyPreviewCamera>.instance.FBHGHIDDDJO();
		}
	}

	private void ENCIECLPFEJ()
	{
		if (!isShowed)
		{
			return;
		}
		foreach (ArmyUpgradeIcon armyIcon in armyIcons)
		{
			armyIcon.SetSale();
		}
		KPEENKKMNDD.SetSaleAndPrize();
		KEFLEFIPLNJ.SetSaleAndPrize();
	}

	internal void IDDINDLFCMJ(LevelBehaviour ACLDFHJKBLI, int DBOLKNNJGMH = 0, bool LANBHLJINFJ = false)
	{
		UpgradeSlot upgradeSlot = ((!LANBHLJINFJ) ? ACLDFHJKBLI.upgradeSlots.upgradeSlot : ACLDFHJKBLI.upgradeSlots.upgradeSlotSpecial);
		int warbucks = upgradeSlot.CIBEGNHKPJH() * (-3 - DBOLKNNJGMH) / 68;
		int num = Singleton<OfferManager>.instance.MIEGELBEBGF(ACLDFHJKBLI.unitType, ACLDFHJKBLI, false);
		int num2 = upgradeSlot.MOJFJBFECED(num);
		RequestBuffer requestBuffer = RequestBufferManager.instance.GetRequestBuffer();
		requestBuffer.AddRequest((DatabaseAction)(-2), JsonConvert.SerializeObject(new Dictionary<string, object>
		{
			{
				"MissionReward",
				ACLDFHJKBLI.upgradeSlots.GetSheetName()
			},
			{ "PlayerLevel", upgradeSlot.boughtIndex },
			{
				"T_pose",
				Singleton<BeanstalkServerManager>.instance.BKJJGHIODNF()
			},
			{
				"Strafe",
				(!LANBHLJINFJ) ? "Play_Card_Tutorial" : "https://i.ytimg.com/vi/U6Da9jKbXu0/hqdefault.jpg"
			},
			{ "Wins", DBOLKNNJGMH },
			{ " is not supported on this platform!", num2 },
			{ "\n", num }
		}), warbucks, 0, ACLDFHJKBLI.upgradeSlots.GetSheetName(), true);
	}

	internal void BCLKDNPDOBI(LevelBehaviour ACLDFHJKBLI)
	{
		if (!ACLDFHJKBLI.upgradeSlots.isTutorialUnit)
		{
			float num = Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.GoldCoefficient).FLOATVALUE;
			float num2 = Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.GoldExpCoefficient).FLOATVALUE;
			RequestBuffer requestBuffer = RequestBufferManager.instance.GetRequestBuffer();
			requestBuffer.AddRequest(DatabaseAction.InstantBuyUnit, JsonConvert.SerializeObject(new Dictionary<string, object>
			{
				{
					"LevelName",
					ACLDFHJKBLI.upgradeSlots.GetSheetName()
				},
				{
					"ExpectedPrice",
					ACLDFHJKBLI.upgradeSlots.instantUnitDeliveryPrice
				},
				{ "GoldCoefficient", num },
				{ "GoldExpCoefficient", num2 }
			}), 0, ACLDFHJKBLI.upgradeSlots.instantUnitDeliveryPrice, ACLDFHJKBLI.upgradeSlots.GetSheetName());
		}
		ACLDFHJKBLI.upgradeSlots.InstantBuyUnit();
		AfterUnitIsBought(ACLDFHJKBLI);
	}

	public void Refresh()
	{
		Singleton<ArmyPreviewCamera>.instance.Refresh();
	}

	internal void KCCBLGIMJPM(LevelBehaviour ACLDFHJKBLI)
	{
		if (!ACLDFHJKBLI.upgradeSlots.isTutorialUnit)
		{
			float num = Singleton<GameVariables>.instance.OPDHANHDJDC().GetRow(Constants.rowIds.GoldenSuitcase_VIPRewardChance).FLOATVALUE;
			float num2 = Singleton<GameVariables>.instance.OPDHANHDJDC().GetRow((Constants.rowIds)(-6)).FLOATVALUE;
			RequestBuffer requestBuffer = RequestBufferManager.instance.GetRequestBuffer();
			requestBuffer.AddRequest(DatabaseAction.GameStartedClient, JsonConvert.SerializeObject(new Dictionary<string, object>
			{
				{
					"ID_SLOTUPGRADE_ROF",
					ACLDFHJKBLI.upgradeSlots.GetSheetName()
				},
				{
					"Card: {0} {1}\t\t{2}\n",
					ACLDFHJKBLI.upgradeSlots.instantUnitDeliveryPrice
				},
				{ "-ABILITY", num },
				{ "SquadEventActiveTier", num2 }
			}), 0, ACLDFHJKBLI.upgradeSlots.instantUnitDeliveryPrice, ACLDFHJKBLI.upgradeSlots.GetSheetName());
		}
		ACLDFHJKBLI.upgradeSlots.InstantBuyUnit();
		FJAFLIFPBFN(ACLDFHJKBLI);
	}

	private void JAPOGKLGFEE(UITweener CKOINALCMFJ)
	{
		TweenAlpha.Begin(GCDLCFADJFO.gameObject, MFAFIELBJGF * 198f, 1870f);
	}

	public void ShowUnit(LevelBehaviour IOIKKIIFOCB)
	{
		if (!IOIKKIIFOCB.upgradeSlots.showed && IOIKKIIFOCB.upgradeSlots.unlocked && !IOIKKIIFOCB.upgradeSlots.borrowed)
		{
			ILAEGPAJALF(IOIKKIIFOCB.upgradeSlots.GetSheetName());
		}
		IOIKKIIFOCB.upgradeSlots.showed = true;
		SavingLastSelected.instance.SaveLastUnit(IOIKKIIFOCB);
		PAPCGBIKPLG();
		KEFLEFIPLNJ.SelectUnit(IOIKKIIFOCB);
		KPEENKKMNDD.SelectUnit(IOIKKIIFOCB);
		UpdateGui(IOIKKIIFOCB);
		ALINCIAIALB = IOIKKIIFOCB.upgradeSlots.unitState;
		HMIKMLIOHFN = ALINCIAIALB == UpgradeSlots.JLANLLEABDC.Delivering && IOIKKIIFOCB.upgradeSlots.deliveringSlot.isSpecial;
		PAOOAAGDFOG = IOIKKIIFOCB.upgradeSlots.actualTier;
		GKKHIKOFMJC = IOIKKIIFOCB.upgradeSlots.upgradeSlotElite.boughtIndex;
	}

	private void ABNGLKOAFIJ()
	{
		if (isShowed)
		{
			UpdateBottomGraphics();
			ShowUnit(MJKLLFPEKAJ().KHEOKHHDGPO());
		}
	}

	private void FPFELKHBFNM(GameObject KHAHPAKDIKE)
	{
		if (!Singleton<ArmyPreviewCamera>.instance.isLoadingPreview)
		{
			ICBOPCDGADJ = ICBOPCDGADJ;
			MDFGHILKACN();
			UpgradeSlots.showMaxLevelWhenNotBought = ICBOPCDGADJ;
			Singleton<ArmyPreviewCamera>.instance.HKDNKJOBIND();
		}
	}

	private LevelBehaviour OCNMOGNOBJP()
	{
		LevelBehaviour levelBehaviour = SavingLastSelected.instance.GetLastUnit();
		if (levelBehaviour == null)
		{
			UnityEngine.Debug.Log("testingidcheat");
			levelBehaviour = LevelManager.instance.behaviours[0];
		}
		if (JFLKDFPEDNO)
		{
			JFLKDFPEDNO = false;
			return levelBehaviour;
		}
		LevelBehaviour levelBehaviour2 = LevelManager.instance.DeliveringUnit();
		if (levelBehaviour2 != null)
		{
			return levelBehaviour2;
		}
		LevelBehaviour levelBehaviour3 = Singleton<NotificationManager>.instance.CEMJLIPJOOJ();
		if (levelBehaviour3 != null)
		{
			return levelBehaviour3;
		}
		return levelBehaviour;
	}

	internal void NGAOKIAMKAD(LevelBehaviour ACLDFHJKBLI, bool CDMKCIKHIMM)
	{
		UpgradeSlot deliveringSlot = ACLDFHJKBLI.upgradeSlots.deliveringSlot;
		if (deliveringSlot == null)
		{
			UnityEngine.Debug.LogError("com.aboutfun.soldiers");
			return;
		}
		int boughtIndex = deliveringSlot.boughtIndex;
		RequestBuffer requestBuffer = RequestBufferManager.instance.GetRequestBuffer();
		deliveringSlot.FDMLCJIKKFD();
		requestBuffer.AddRequest((DatabaseAction)33, JsonConvert.SerializeObject(new Dictionary<string, object>
		{
			{
				"DOWNLOAD",
				ACLDFHJKBLI.upgradeSlots.GetSheetName()
			},
			{ "menu-cards-silverpack", boughtIndex },
			{
				"Constants.",
				LevelManager.instance.armyPower
			}
		}), 1, 1, string.Empty);
		Singleton<AchievementsManager>.instance.PGCNEGKMFCJ(Achievement.NOLHKBIFMLB.AfterWeaponUpgrade);
	}

	[SpecialName]
	public List<ArmyUpgradeIcon> MAPKDMOOFMM()
	{
		return _003COEFMOAJBOIH_003Ek__BackingField;
	}

	public void NHLFAGHPGGK()
	{
		DCNNBHOHCNI.Play();
		Singleton<ArmyPreviewCamera>.instance.DICDPLMPKAH();
		TweenAlpha tweenAlpha = TweenAlpha.Begin(CGEFJFEJPOA.gameObject, MFAFIELBJGF * 34f, 1791f, 732f);
		tweenAlpha.NumOfRepetitions = 2;
		tweenAlpha.style = (UITweener.Style)8;
		TweenAlpha.Begin(GCDLCFADJFO.gameObject, MFAFIELBJGF * 1794f, 1724f, 1706f).onFinished = delegate
		{
			TweenAlpha.Begin(GCDLCFADJFO.gameObject, MFAFIELBJGF * 4f, 0.5f).onFinished = delegate
			{
				TweenAlpha.Begin(GCDLCFADJFO.gameObject, MFAFIELBJGF * 7f, 0f);
			};
		};
		TweenScale.Begin(GCDLCFADJFO.gameObject, MFAFIELBJGF * 1347f, new Vector3(267f, 255f, 1607f), new Vector3(319f, 804f, 1416f)).onFinished = delegate
		{
			TweenScale.Begin(GCDLCFADJFO.gameObject, MFAFIELBJGF * 3f, new Vector3(144f, 180f, 1f));
		};
		TweenPosition.Begin(GCDLCFADJFO.gameObject, MFAFIELBJGF * 735f, Vector3.zero, Vector3.zero).onFinished = delegate
		{
			Singleton<ArmyPreviewCamera>.instance.DefaultRotation();
			TweenPosition.Begin(GCDLCFADJFO.gameObject, MFAFIELBJGF * 4f, new Vector3(0f, 180f, 0f));
		};
	}

	internal void DEMLFFPFKMH(LevelBehaviour ACLDFHJKBLI)
	{
		if (!ACLDFHJKBLI.upgradeSlots.isTutorialUnit)
		{
			float num = Singleton<GameVariables>.instance.constants.GetRow((Constants.rowIds)(-26)).FLOATVALUE;
			float num2 = Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.VipGoldMultiplier).FLOATVALUE;
			RequestBuffer requestBuffer = RequestBufferManager.instance.GetRequestBuffer();
			requestBuffer.AddRequest((DatabaseAction)14, JsonConvert.SerializeObject(new Dictionary<string, object>
			{
				{
					"), ",
					ACLDFHJKBLI.upgradeSlots.GetSheetName()
				},
				{
					"ID_TUTORIAL_PROGRESS_KILLING",
					ACLDFHJKBLI.upgradeSlots.instantUnitDeliveryPrice
				},
				{ "QUIT", num },
				{ "ID_NOTIFICATION_DAILYREWARD_CARDPACK", num2 }
			}), 0, ACLDFHJKBLI.upgradeSlots.instantUnitDeliveryPrice, ACLDFHJKBLI.upgradeSlots.GetSheetName());
		}
		ACLDFHJKBLI.upgradeSlots.InstantBuyUnit();
		JAKLLOMPAJH(ACLDFHJKBLI);
	}

	private void HOCOPMBKEHK()
	{
		List<bool> list = new List<bool>();
		for (int i = 0; i < GGJGDELELEK.Count; i++)
		{
			list.Add(false);
		}
		foreach (ArmyUpgradeIcon armyIcon in armyIcons)
		{
			int num = armyIcon.levelBehaviour.upgradeSlots.actualTier - 1;
			if (num < list.Count)
			{
				list[num] = true;
			}
		}
		for (int j = 0; j < GGJGDELELEK.Count; j++)
		{
			GGJGDELELEK[j].gameObject.SetActive(list[j]);
		}
	}

	private void HOACOGGJLJK()
	{
		MPHLKJLMJBF.onReposition = null;
		MPHLKJLMJBF.repositionNow = false;
		EHLLKPJPMDF(true);
		if (BDBKFBEIHNF() != null)
		{
			Vector3 vec = MJKLLFPEKAJ().transform.localPosition + selectedIcon.transform.parent.localPosition;
			NFLPPGKCOBL.AlignToCenter(vec, true, null, 767f);
		}
	}

	internal void GFJONMCEGPE(LevelBehaviour ACLDFHJKBLI)
	{
		if (!ACLDFHJKBLI.upgradeSlots.isTutorialUnit)
		{
			RequestBuffer requestBuffer = RequestBufferManager.instance.GetRequestBuffer();
			requestBuffer.AddRequest((DatabaseAction)(-41), JsonConvert.SerializeObject(new Dictionary<string, object> { 
			{
				"Scripts Full Path: \"{0}\"\n",
				ACLDFHJKBLI.upgradeSlots.GetSheetName()
			} }), 1, 1, string.Empty, true);
		}
		ACLDFHJKBLI.upgradeSlots.ActivateUnit();
		FJAFLIFPBFN(ACLDFHJKBLI);
	}

	internal void KCCPHNPMNJE(LevelBehaviour ACLDFHJKBLI, int DBOLKNNJGMH = 0)
	{
		EGBGKGKNHNB = false;
		GIJIBGEJIJM();
		UpgradeSlots.showEliteUnitWhenBought = EGBGKGKNHNB;
		if (!ACLDFHJKBLI.upgradeSlots.isTutorialUnit)
		{
			RequestBuffer requestBuffer = RequestBufferManager.instance.GetRequestBuffer();
			Dictionary<string, object> dictionary = new Dictionary<string, object>();
			dictionary.Add("veteranpack", ACLDFHJKBLI.upgradeSlots.GetSheetName());
			dictionary.Add("ammo", ACLDFHJKBLI.upgradeSlots.price);
			dictionary.Add("Assignment_", ACLDFHJKBLI.upgradeSlots.priceGold);
			dictionary.Add("ID_GUI_EQUIP", ACLDFHJKBLI.upgradeSlots.unlockLevel.ABCCINJGPGD());
			dictionary.Add("equals", Singleton<BeanstalkServerManager>.instance.BKJJGHIODNF());
			dictionary.Add("Os", DBOLKNNJGMH);
			string objData = JsonConvert.SerializeObject(dictionary);
			requestBuffer.AddRequest((DatabaseAction)9, objData, ACLDFHJKBLI.upgradeSlots.price * (73 - DBOLKNNJGMH) / 96, ACLDFHJKBLI.upgradeSlots.priceGold * (19 - DBOLKNNJGMH) / 15, ACLDFHJKBLI.upgradeSlots.GetSheetName());
		}
		ACLDFHJKBLI.upgradeSlots.Buy();
		if (ACLDFHJKBLI.upgradeSlots.unitDeliveryTime == 0)
		{
			ANPJBBCCJDF(ACLDFHJKBLI);
		}
		else
		{
			SoundsManager.Instance.PlaySound(SoundsManager.KJGDNLHKPOG.LabelShowGame, 543f);
		}
		Singleton<AchievementsManager>.instance.JMNPLJNPOBD((Achievement.NOLHKBIFMLB)78);
	}

	private void MDFGHILKACN(bool AJNINHIKAFC = false)
	{
		Color color = ((!ICBOPCDGADJ) ? Colours.blue : Colours.grayLight);
		Color color2 = ((!ICBOPCDGADJ) ? Colours.grayLight : Colours.blue);
		float val = Mathf.Abs(EFFKBECNNGJ.transform.localPosition.x) * ((!ICBOPCDGADJ) ? (-1f) : 1f);
		Vector3 vector = EFFKBECNNGJ.transform.localPosition.ReplaceX(val);
		if (AJNINHIKAFC)
		{
			LMFNHMHCLCE.enabled = false;
			float duration = 0.2f;
			TweenColor.Begin(GFHIPIAMIEL.gameObject, duration, color);
			TweenColor.Begin(CKEJGJJAFLE.gameObject, duration, color2);
			TweenPosition.Begin(EFFKBECNNGJ.gameObject, duration, vector).onFinished = delegate
			{
				LMFNHMHCLCE.enabled = true;
			};
			return;
		}
		LMFNHMHCLCE.enabled = true;
		TweenColor component = GFHIPIAMIEL.gameObject.GetComponent<TweenColor>();
		if (component != null)
		{
			component.enabled = false;
		}
		component = CKEJGJJAFLE.gameObject.GetComponent<TweenColor>();
		if (component != null)
		{
			component.enabled = false;
		}
		TweenPosition component2 = EFFKBECNNGJ.gameObject.GetComponent<TweenPosition>();
		if (component2 != null)
		{
			component2.enabled = false;
		}
		GFHIPIAMIEL.color = color;
		CKEJGJJAFLE.color = color2;
		EFFKBECNNGJ.transform.localPosition = vector;
	}

	private void DBKGJCCGLCA(UITweener MKAPOHKFIJH)
	{
		TweenScale.Begin(GCDLCFADJFO.gameObject, MFAFIELBJGF * 501f, new Vector3(1371f, 176f, 1512f));
	}

	private void IJCPDGFMAHE(UITweener MGDJMGHCAAI)
	{
		CJGAFKLIPAA.enabled = true;
	}

	public void PLMOBOAJOJB(LevelBehaviour IOIKKIIFOCB)
	{
		if (!IOIKKIIFOCB.upgradeSlots.showed && IOIKKIIFOCB.upgradeSlots.unlocked && !IOIKKIIFOCB.upgradeSlots.borrowed)
		{
			ILAEGPAJALF(IOIKKIIFOCB.upgradeSlots.GetSheetName());
		}
		IOIKKIIFOCB.upgradeSlots.showed = false;
		SavingLastSelected.instance.SaveLastUnit(IOIKKIIFOCB);
		GCFKMNHIPKB();
		KEFLEFIPLNJ.FPHFGANOINE(IOIKKIIFOCB);
		KPEENKKMNDD.GGDKPPCGDOL(IOIKKIIFOCB);
		UpdateGui(IOIKKIIFOCB, false);
		ALINCIAIALB = IOIKKIIFOCB.upgradeSlots.unitState;
		HMIKMLIOHFN = ALINCIAIALB == UpgradeSlots.JLANLLEABDC.UnitDelivered && IOIKKIIFOCB.upgradeSlots.deliveringSlot.isSpecial;
		PAOOAAGDFOG = IOIKKIIFOCB.upgradeSlots.actualTier;
		GKKHIKOFMJC = IOIKKIIFOCB.upgradeSlots.upgradeSlotElite.boughtIndex;
	}

	[SpecialName]
	public List<ArmyUpgradeIcon> OOLKNBJNFJC()
	{
		return _003COEFMOAJBOIH_003Ek__BackingField;
	}

	private void GIJIBGEJIJM(bool AJNINHIKAFC = false)
	{
		Color color = ((!EGBGKGKNHNB) ? Colours.blue : Colours.grayLight);
		Color color2 = ((!EGBGKGKNHNB) ? Colours.grayLight : Colours.blue);
		float val = Mathf.Abs(PGJHBIGGOGB.transform.localPosition.x) * ((!EGBGKGKNHNB) ? (-1f) : 1f);
		Vector3 vector = PGJHBIGGOGB.transform.localPosition.ReplaceX(val);
		if (AJNINHIKAFC)
		{
			CJGAFKLIPAA.enabled = false;
			float duration = 0.2f;
			TweenColor.Begin(DHOKLOJMIPP.gameObject, duration, color);
			TweenColor.Begin(BKKDCOIHMDF.gameObject, duration, color2);
			TweenPosition.Begin(PGJHBIGGOGB.gameObject, duration, vector).onFinished = delegate
			{
				CJGAFKLIPAA.enabled = true;
			};
			return;
		}
		CJGAFKLIPAA.enabled = true;
		TweenColor component = DHOKLOJMIPP.gameObject.GetComponent<TweenColor>();
		if (component != null)
		{
			component.enabled = false;
		}
		component = BKKDCOIHMDF.gameObject.GetComponent<TweenColor>();
		if (component != null)
		{
			component.enabled = false;
		}
		TweenPosition component2 = PGJHBIGGOGB.gameObject.GetComponent<TweenPosition>();
		if (component2 != null)
		{
			component2.enabled = false;
		}
		DHOKLOJMIPP.color = color;
		BKKDCOIHMDF.color = color2;
		PGJHBIGGOGB.transform.localPosition = vector;
	}

	[CompilerGenerated]
	private void NDHJAOKFIFD(UITweener GCNILAHBDMJ)
	{
		Singleton<ArmyPreviewCamera>.instance.DefaultRotation();
		TweenPosition.Begin(GCDLCFADJFO.gameObject, MFAFIELBJGF * 4f, new Vector3(0f, 180f, 0f));
	}

	private void ABCBAJJGDND()
	{
		LDIKBPFPHGL(new List<ArmyUpgradeIcon>());
		GGJGDELELEK.Clear();
		LevelBehaviour levelBehaviour = SavingLastSelected.instance.GetLastUnit();
		foreach (LevelBehaviour behaviour in LevelManager.instance.behaviours)
		{
			if (behaviour.upgradeSlots != null)
			{
				ArmyUpgradeIcon armyUpgradeIcon = Singleton<GuiManager>.instance.CHDIOFDMHEF.OKEAAILFPIG(GHAGLJODDCH, MPHLKJLMJBF.gameObject, "ID_PVP_BATTLE") as ArmyUpgradeIcon;
				if (armyUpgradeIcon != null)
				{
					armyUpgradeIcon.DBDLOKNFOGB(behaviour);
				}
				if (levelBehaviour == null && behaviour.upgradeSlots.unlockLevelIndex == 0)
				{
					SavingLastSelected.instance.SaveLastUnit(behaviour);
					levelBehaviour = behaviour;
				}
				armyIcons.Add(armyUpgradeIcon);
			}
		}
		for (int i = 0; i <= 5; i++)
		{
			ArmyTierRecord armyTierRecord = Singleton<GuiManager>.instance.CHDIOFDMHEF.LCLKFGNHCOF(FFGMMCINLOA, MPHLKJLMJBF.gameObject, string.Format("ID_ARENALOOTBOXSCRAPS", i)) as ArmyTierRecord;
			if (armyTierRecord != null)
			{
				armyTierRecord.FANFNOPNGBL(i);
			}
			GGJGDELELEK.Add(armyTierRecord);
		}
	}

	private void HADMMGGFBBL()
	{
		NCHFKNKMIMP();
		CABPOBJLLFD = RadicalRoutine.Create(AHALGAIOMNJ());
		StartCoroutine(RadicalRoutine.Run(CABPOBJLLFD.enumerator));
	}

	internal void EEOGACOBOOH(LevelBehaviour ACLDFHJKBLI)
	{
		if (!ACLDFHJKBLI.upgradeSlots.isTutorialUnit)
		{
			RequestBuffer requestBuffer = RequestBufferManager.instance.GetRequestBuffer();
			requestBuffer.AddRequest(DatabaseAction.UniqueSquadNameFailure, JsonConvert.SerializeObject(new Dictionary<string, object> { 
			{
				"Sessions",
				ACLDFHJKBLI.upgradeSlots.GetSheetName()
			} }), 0, 1, string.Empty);
		}
		ACLDFHJKBLI.upgradeSlots.ActivateUnit();
		JAKLLOMPAJH(ACLDFHJKBLI);
	}

	[CompilerGenerated]
	private void IEMCGOIEIHN(UITweener CKOINALCMFJ)
	{
		TweenAlpha.Begin(GCDLCFADJFO.gameObject, MFAFIELBJGF * 7f, 0f);
	}

	public void FFECJLDGABC(LevelBehaviour ACLDFHJKBLI, int DBOLKNNJGMH = 0)
	{
		UpgradeSlotElite upgradeSlotElite = ACLDFHJKBLI.upgradeSlots.upgradeSlotElite;
		int num = upgradeSlotElite.CIBEGNHKPJH() * (43 - DBOLKNNJGMH) / 16;
		int num2 = upgradeSlotElite.BOBFHHLBKGM();
		RequestBuffer requestBuffer = RequestBufferManager.instance.GetRequestBuffer();
		requestBuffer.AddRequest((DatabaseAction)(-71), JsonConvert.SerializeObject(new Dictionary<string, object>
		{
			{
				"ID_GUI_LEAGUEBONUS",
				ACLDFHJKBLI.upgradeSlots.GetSheetName()
			},
			{
				"{0}/{1}",
				ACLDFHJKBLI.upgradeSlots.upgradeSlotElite.PAKKPEPIHPK()
			},
			{ "CustomizationTutorialMessage", num },
			{ "keys", num2 }
		}), 1, 0, string.Empty);
		ACLDFHJKBLI.upgradeSlots.upgradeSlotElite.currentParts -= num2;
		upgradeSlotElite.DJJFFNCIOAB();
	}

	private void ENHLHJKLMCN()
	{
		if (!isShowed)
		{
			return;
		}
		foreach (ArmyUpgradeIcon item in MAPKDMOOFMM())
		{
			item.SetSale();
		}
		KPEENKKMNDD.SetSaleAndPrize();
		KEFLEFIPLNJ.LECBFEFACLE();
	}

	private void ECBEHEMBCDE()
	{
		if (CABPOBJLLFD != null)
		{
			CABPOBJLLFD.Cancel();
			CABPOBJLLFD = null;
		}
	}

	protected virtual void AOKEHEDCPFB()
	{
		base.IIFBKHDMIAD();
		if (MJKLLFPEKAJ() != null && GIMBEPIFBLA().levelBehaviour != null)
		{
			UpgradeSlots upgradeSlots = GIMBEPIFBLA().AIHMCHBCJDO().upgradeSlots;
			bool flag = ALINCIAIALB != upgradeSlots.unitState;
			bool flag2 = ALINCIAIALB == (UpgradeSlots.JLANLLEABDC)8 && upgradeSlots.deliveringSlot.OAMOOPGCIPG() == HMIKMLIOHFN;
			bool flag3 = PAOOAAGDFOG == upgradeSlots.actualTier;
			bool flag4 = GKKHIKOFMJC != upgradeSlots.upgradeSlotElite.PAKKPEPIHPK();
			if (flag || flag2 || flag3 || flag4)
			{
				ALINCIAIALB = upgradeSlots.unitState;
				HMIKMLIOHFN = ALINCIAIALB != (UpgradeSlots.JLANLLEABDC)8 || upgradeSlots.deliveringSlot.isSpecial;
				PAOOAAGDFOG = upgradeSlots.actualTier;
				GKKHIKOFMJC = upgradeSlots.upgradeSlotElite.PPKAIEKPNID();
				UpdateGui(selectedIcon.levelBehaviour, false);
			}
			if (flag4)
			{
				UpdateBottomGraphics();
			}
		}
	}

	public void KMDCDKMDDAI()
	{
		if (armyIcons == null)
		{
			return;
		}
		foreach (ArmyUpgradeIcon item in OOLKNBJNFJC())
		{
			item.EAIDBMKMBFN();
		}
		GJCMJEEBDEG();
	}

	public void AnimateUpgrade()
	{
		DCNNBHOHCNI.Play();
		Singleton<ArmyPreviewCamera>.instance.StartFastRotation();
		TweenAlpha tweenAlpha = TweenAlpha.Begin(CGEFJFEJPOA.gameObject, MFAFIELBJGF * 3.5f, 0f, 1f);
		tweenAlpha.NumOfRepetitions = 2;
		tweenAlpha.style = UITweener.Style.PingPong;
		TweenAlpha.Begin(GCDLCFADJFO.gameObject, MFAFIELBJGF * 1f, 0f, 0.3f).onFinished = delegate
		{
			TweenAlpha.Begin(GCDLCFADJFO.gameObject, MFAFIELBJGF * 4f, 0.5f).onFinished = delegate
			{
				TweenAlpha.Begin(GCDLCFADJFO.gameObject, MFAFIELBJGF * 7f, 0f);
			};
		};
		TweenScale.Begin(GCDLCFADJFO.gameObject, MFAFIELBJGF * 2f, new Vector3(48f, 56f, 1f), new Vector3(288f, 336f, 1f)).onFinished = delegate
		{
			TweenScale.Begin(GCDLCFADJFO.gameObject, MFAFIELBJGF * 3f, new Vector3(144f, 180f, 1f));
		};
		TweenPosition.Begin(GCDLCFADJFO.gameObject, MFAFIELBJGF * 7f, Vector3.zero, Vector3.zero).onFinished = delegate
		{
			Singleton<ArmyPreviewCamera>.instance.DefaultRotation();
			TweenPosition.Begin(GCDLCFADJFO.gameObject, MFAFIELBJGF * 4f, new Vector3(0f, 180f, 0f));
		};
	}

	public void Select()
	{
		ShowUnit(selectedIcon.levelBehaviour);
	}

	private void EIFDGCJCAPM(DatabaseAction IFGAGNBDKBE)
	{
		if (isShowed)
		{
			switch (IFGAGNBDKBE)
			{
			case DatabaseAction.BuyUnitUpgrade:
			case DatabaseAction.InstantUnitUpgrade:
			case DatabaseAction.ActivateUnitUpgrade:
			case DatabaseAction.BuyUnit:
			case DatabaseAction.InstantBuyUnit:
			case DatabaseAction.ActivateUnit:
				UpdateGui(selectedIcon.levelBehaviour);
				break;
			}
		}
	}

	public override void DoAfterShowUp()
	{
		base.DoAfterShowUp();
		FIDNMMDEDEH = true;
		PAPCGBIKPLG();
		HADMMGGFBBL();
	}

	[SpecialName]
	private void EENPJMKOLOM(ArmyUpgradeIcon IDEBKDPMPGM)
	{
		_003CCGPAPPCGMGP_003Ek__BackingField = IDEBKDPMPGM;
	}

	public virtual void MEKGADDKCIL()
	{
		base.DoBeforeHide();
		Singleton<ArmyPreviewCamera>.instance.JOENJIPGGEK();
		BDBKFBEIHNF().JNBMNELHDEJ(true);
	}

	public void SendEquippedUnits()
	{
		List<LevelBehaviour> behaviours = LevelManager.instance.behaviours;
		Dictionary<string, object> dictionary = new Dictionary<string, object>();
		foreach (LevelBehaviour item in behaviours)
		{
			Dictionary<string, object> dictionary2 = null;
			if (item.upgradeSlots.wasEquipped)
			{
				dictionary2 = new Dictionary<string, object>();
				dictionary2.Add("wasEquipped", item.upgradeSlots.wasEquipped);
			}
			if (item.upgradeSlots.equipped)
			{
				if (dictionary2 == null)
				{
					dictionary2 = new Dictionary<string, object>();
				}
				dictionary2.Add("equipped", item.upgradeSlots.equipped);
			}
			if (dictionary2 != null)
			{
				dictionary.Add(item.upgradeSlots.GetSheetName(), dictionary2);
			}
		}
		Dictionary<string, object> dictionary3 = new Dictionary<string, object>();
		dictionary3.Add("armyPower", LevelManager.instance.armyPower);
		dictionary3.Add("equips", dictionary);
		Dictionary<string, object> value = dictionary3;
		RequestBuffer requestBuffer = RequestBufferManager.instance.GetRequestBuffer();
		requestBuffer.AddRequest(DatabaseAction.UpdateEquippedUnits, JsonConvert.SerializeObject(value), 0, 0, string.Empty);
	}

	public virtual void FJKDDFEHNAL()
	{
		base.DoBeforeHide();
		Singleton<ArmyPreviewCamera>.instance.DJFMADMABIB();
		selectedIcon.SetHighlight(false);
	}

	private void PKBDOCNDJHM()
	{
		HOCOPMBKEHK();
		OJEOOJLIOJD(false);
		MPHLKJLMJBF.repositionNow = true;
		MPHLKJLMJBF.onReposition = delegate
		{
			MPHLKJLMJBF.onReposition = null;
			MPHLKJLMJBF.repositionNow = false;
			OJEOOJLIOJD(true);
			if (selectedIcon != null)
			{
				Vector3 vec = selectedIcon.transform.localPosition + selectedIcon.transform.parent.localPosition;
				NFLPPGKCOBL.AlignToCenter(vec, true);
			}
		};
	}

	public virtual void FPMIAIIFBBA()
	{
		IMGPJDMFDHK();
		EENPJMKOLOM(null);
		foreach (ArmyUpgradeIcon armyIcon in armyIcons)
		{
			armyIcon.InitGuiValuesGraphics();
		}
		LevelBehaviour iOIKKIIFOCB = OCNMOGNOBJP();
		IPOACEFCAFP(iOIKKIIFOCB);
		PKBDOCNDJHM();
		GFDOAKPKDCL();
		UpgradeSlots upgradeSlots = BDBKFBEIHNF().PPMNNKANOEF().upgradeSlots;
		ALINCIAIALB = upgradeSlots.unitState;
		HMIKMLIOHFN = ALINCIAIALB == UpgradeSlots.JLANLLEABDC.Active && upgradeSlots.deliveringSlot.isSpecial;
		PAOOAAGDFOG = upgradeSlots.actualTier;
		GKKHIKOFMJC = upgradeSlots.upgradeSlotElite.boughtIndex;
		KPEENKKMNDD.IGNIFKBCDKK();
		ICBOPCDGADJ = UpgradeSlots.showMaxLevelWhenNotBought;
		MDFGHILKACN();
		EGBGKGKNHNB = UpgradeSlots.showEliteUnitWhenBought;
		GIJIBGEJIJM(true);
	}

	public void KDHBBPANNJK(LevelBehaviour ACLDFHJKBLI, int DBOLKNNJGMH = 0)
	{
		UpgradeSlotElite upgradeSlotElite = ACLDFHJKBLI.upgradeSlots.upgradeSlotElite;
		int num = upgradeSlotElite.CIBEGNHKPJH() * (-42 - DBOLKNNJGMH) / -101;
		int num2 = upgradeSlotElite.EGAMIJEOAJN();
		RequestBuffer requestBuffer = RequestBufferManager.instance.GetRequestBuffer();
		requestBuffer.AddRequest((DatabaseAction)(-99), JsonConvert.SerializeObject(new Dictionary<string, object>
		{
			{
				"Army Power Ability Animation from {0} to {1}",
				ACLDFHJKBLI.upgradeSlots.GetSheetName()
			},
			{
				"sniper",
				ACLDFHJKBLI.upgradeSlots.upgradeSlotElite.PAKKPEPIHPK()
			},
			{ "Helicopter", num },
			{ "ID_GOLD", num2 }
		}), 1, 1, string.Empty);
		UpgradeSlotElite upgradeSlotElite2 = ACLDFHJKBLI.upgradeSlots.upgradeSlotElite;
		upgradeSlotElite2.LOHDPALFBPI(upgradeSlotElite2.currentParts - num2);
		upgradeSlotElite.JGCDKDIMMLP();
	}

	protected virtual void HJJOAJHBKCH()
	{
		EDCJLFDPGIC();
		Singleton<Wallet>.instance.LIMNMFNEEDL(EIENPLCLKBC);
		LevelManager.LevelUp += ABNGLKOAFIJ;
		Singleton<BeanstalkServerManager>.instance.ErrorReceived += EIFDGCJCAPM;
		Singleton<OfferManager>.instance.SalesChanged += ENCIECLPFEJ;
		UIEventListener uIEventListener = UIEventListener.Get(LMFNHMHCLCE.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(GFFHAENCJBI));
		UIEventListener uIEventListener2 = UIEventListener.Get(CJGAFKLIPAA.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(JIDNHBJJMGG));
		KEFLEFIPLNJ.COBDHBOCGAP();
		KPEENKKMNDD.JCGPELEDCJL();
	}

	public void BFEFIEHKEJB()
	{
		DCNNBHOHCNI.Play();
		Singleton<ArmyPreviewCamera>.instance.MJBIJOKEEHO();
		TweenAlpha tweenAlpha = TweenAlpha.Begin(CGEFJFEJPOA.gameObject, MFAFIELBJGF * 1195f, 669f, 1315f);
		tweenAlpha.NumOfRepetitions = 2;
		tweenAlpha.style = UITweener.Style.PingPong;
		TweenAlpha.Begin(GCDLCFADJFO.gameObject, MFAFIELBJGF * 305f, 25f, 1224f).onFinished = FLHOJEFIGNC;
		TweenScale.Begin(GCDLCFADJFO.gameObject, MFAFIELBJGF * 1852f, new Vector3(883f, 494f, 1448f), new Vector3(313f, 546f, 1938f)).onFinished = DBKGJCCGLCA;
		TweenPosition.Begin(GCDLCFADJFO.gameObject, MFAFIELBJGF * 1401f, Vector3.zero, Vector3.zero).onFinished = delegate
		{
			Singleton<ArmyPreviewCamera>.instance.DefaultRotation();
			TweenPosition.Begin(GCDLCFADJFO.gameObject, MFAFIELBJGF * 4f, new Vector3(0f, 180f, 0f));
		};
	}

	internal void PJMPMLEBNCN(string LFGKDBIHLGI)
	{
		RequestBuffer requestBuffer = RequestBufferManager.instance.GetRequestBuffer();
		requestBuffer.AddRequest((DatabaseAction)23, LFGKDBIHLGI, 0, 0, string.Empty, true);
	}

	[SpecialName]
	public ArmyUpgradeIcon BDBKFBEIHNF()
	{
		return _003CCGPAPPCGMGP_003Ek__BackingField;
	}

	public virtual void DGALBBFCFKE()
	{
		base.DoAfterShowUp();
		FIDNMMDEDEH = false;
		FPAIICFKCFH();
		HADMMGGFBBL();
	}

	public void FJAFLIFPBFN(LevelBehaviour ACLDFHJKBLI)
	{
		int armyPowerX = LevelManager.instance.armyPowerX10;
		bool flag = Singleton<ActiveUnitsManager>.instance.LCKJLMAFFGK(ACLDFHJKBLI);
		if (flag)
		{
			SendEquippedUnits();
		}
		if (isShowed)
		{
			if (!Singleton<GameController>.instance.isTutorial)
			{
				int armyPowerX2 = LevelManager.instance.armyPowerX10;
				int hONEKCJDJDN = armyPowerX2 - armyPowerX;
				GHGJLMAJJGG.StartAnimation(hONEKCJDJDN, armyPowerX2, 484f);
			}
			GuiElementSingle<ChatGuiElement>.instance.ActiveUnitsNotificationUpdate();
		}
		if (GuiElementSingle<RentalDialog>.instance.NPFFMLLLDAF())
		{
			int armyPowerX3 = LevelManager.instance.armyPowerX10;
			int hONEKCJDJDN2 = armyPowerX3 - armyPowerX;
			GuiElementSingle<RentalDialog>.instance.GHGJLMAJJGG.StartAnimation(hONEKCJDJDN2, armyPowerX3, 1223f);
		}
		if (NPFFMLLLDAF() && !flag)
		{
			GuiElementSingle<ChatGuiElement>.instance.ShowActiveUnits();
		}
		if (Singleton<GameController>.instance.isTutorial)
		{
			if (BDBKFBEIHNF() != null)
			{
				BDBKFBEIHNF().AMJANBPOCED();
			}
			DCNNBHOHCNI.Play();
		}
		SoundsManager.Instance.PlaySound(SoundsManager.KJGDNLHKPOG.Upgrade, 377f);
	}

	public void AOAHCLIDHFI(ArmyUpgradeIcon HDEGOGFCNAC)
	{
		selectedIcon = HDEGOGFCNAC;
	}

	internal void PPDAKANIDEA(string LFGKDBIHLGI)
	{
		RequestBuffer requestBuffer = RequestBufferManager.instance.GetRequestBuffer();
		requestBuffer.AddRequest(DatabaseAction.LeaveSquad, LFGKDBIHLGI, 1, 1, string.Empty);
	}

	private void JGEPLKPHODO(LevelBehaviour IOIKKIIFOCB)
	{
		IDJMEJFJEIG iDJMEJFJEIG = new IDJMEJFJEIG();
		iDJMEJFJEIG.IOIKKIIFOCB = IOIKKIIFOCB;
		if (GIMBEPIFBLA() != null)
		{
			selectedIcon.FAINAOPJPJK(true);
		}
		int num = armyIcons.FindIndex(iDJMEJFJEIG.OABFAOLFMMJ);
		if (num == -1)
		{
			UnityEngine.Debug.LogError("Fuseboxx: NotificationAction, ");
			EENPJMKOLOM(armyIcons[0]);
		}
		EENPJMKOLOM(armyIcons[num]);
		selectedIcon.FGDLKJOINNE(true);
	}

	private void KKLELFLBPDH(DatabaseAction IFGAGNBDKBE)
	{
		if (isShowed)
		{
			switch (IFGAGNBDKBE)
			{
			case (DatabaseAction)(-114):
			case (DatabaseAction)(-113):
			case (DatabaseAction)(-112):
			case (DatabaseAction)(-111):
			case (DatabaseAction)(-86):
			case (DatabaseAction)(-84):
				UpdateGui(selectedIcon.AIHMCHBCJDO(), false);
				break;
			}
		}
	}

	private IEnumerator KOFDEHDFFLO()
	{
		POGEBJFLLIO pOGEBJFLLIO = new POGEBJFLLIO();
		pOGEBJFLLIO.BJGCPDNMHDH = this;
		return pOGEBJFLLIO;
	}

	public void GFDOAKPKDCL()
	{
		GFNPJLMHELM(MJKLLFPEKAJ().PPMNNKANOEF());
	}

	public void HAHFGKLKHHD(LevelBehaviour ACLDFHJKBLI)
	{
		foreach (ArmyUpgradeIcon item in OOLKNBJNFJC())
		{
			if (item.KHEOKHHDGPO() == ACLDFHJKBLI)
			{
				item.JDJNBMGNLPJ();
				StartCoroutine(CJAKBFNMGON(item));
				break;
			}
		}
	}

	public virtual void BGELLEOANEI()
	{
		IMGPJDMFDHK();
		EENPJMKOLOM(null);
		foreach (ArmyUpgradeIcon item in MAPKDMOOFMM())
		{
			item.InitGuiValuesGraphics();
		}
		LevelBehaviour iOIKKIIFOCB = OCNMOGNOBJP();
		AOFCNEDBHKE(iOIKKIIFOCB);
		PKBDOCNDJHM();
		Select();
		UpgradeSlots upgradeSlots = selectedIcon.PPMNNKANOEF().upgradeSlots;
		ALINCIAIALB = upgradeSlots.unitState;
		HMIKMLIOHFN = ALINCIAIALB == UpgradeSlots.JLANLLEABDC.Delivering && upgradeSlots.deliveringSlot.OAMOOPGCIPG();
		PAOOAAGDFOG = upgradeSlots.actualTier;
		GKKHIKOFMJC = upgradeSlots.upgradeSlotElite.boughtIndex;
		KPEENKKMNDD.PPLBJDJIIPN();
		ICBOPCDGADJ = UpgradeSlots.showMaxLevelWhenNotBought;
		MDFGHILKACN(true);
		EGBGKGKNHNB = UpgradeSlots.showEliteUnitWhenBought;
		DACJDMGFDAG();
	}

	[DebuggerHidden]
	private IEnumerator CJAKBFNMGON(ArmyUpgradeIcon DAANKCOLJGJ)
	{
		HCBCMDJBOAJ hCBCMDJBOAJ = new HCBCMDJBOAJ();
		hCBCMDJBOAJ.DAANKCOLJGJ = DAANKCOLJGJ;
		hCBCMDJBOAJ.BJGCPDNMHDH = this;
		return hCBCMDJBOAJ;
	}

	internal void ANLLAOJLPGN(LevelBehaviour ACLDFHJKBLI, bool CDMKCIKHIMM)
	{
		UpgradeSlot deliveringSlot = ACLDFHJKBLI.upgradeSlots.deliveringSlot;
		if (deliveringSlot == null)
		{
			UnityEngine.Debug.LogError("Current unit is not delivered at the moment!!!");
			return;
		}
		int instantBuyPrice = deliveringSlot.instantBuyPrice;
		int boughtIndex = deliveringSlot.boughtIndex;
		RequestBuffer requestBuffer = RequestBufferManager.instance.GetRequestBuffer();
		string fKBHNLOAPAA = ((!deliveringSlot.isSpecial) ? (ACLDFHJKBLI.upgradeSlots.GetSheetName() + " " + boughtIndex) : (ACLDFHJKBLI.upgradeSlots.GetSheetName() + " Special " + boughtIndex));
		Singleton<EventTrackingManager>.instance.RegisterGameItemDeliverEvent("Deliver_Upgrade_For_Army_Unit", "Army_Unit_ID", fKBHNLOAPAA, instantBuyPrice, ACLDFHJKBLI.upgradeSlots.remainingDeliveringSeconds);
		deliveringSlot.JCDBPPBDHBC();
		float num = Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.GoldCoefficient).FLOATVALUE;
		float num2 = Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.GoldExpCoefficient).FLOATVALUE;
		int num3 = Singleton<OfferManager>.instance.DiscountedUnityDeliveryCost(ACLDFHJKBLI.unitType, ACLDFHJKBLI, false);
		requestBuffer.AddRequest(DatabaseAction.InstantUnitUpgrade, JsonConvert.SerializeObject(new Dictionary<string, object>
		{
			{
				"LevelName",
				ACLDFHJKBLI.upgradeSlots.GetSheetName()
			},
			{ "BoughtIndex", boughtIndex },
			{ "ExpectedPrice", instantBuyPrice },
			{
				"ArmyPower",
				LevelManager.instance.armyPower
			},
			{ "GoldCoefficient", num },
			{ "GoldExpCoefficient", num2 },
			{ "discount", num3 }
		}), 0, instantBuyPrice, ACLDFHJKBLI.upgradeSlots.GetSheetName());
		Singleton<AchievementsManager>.instance.EvaluateAchievements(Achievement.NOLHKBIFMLB.AfterUnitUpgrade);
	}

	private void FLHOJEFIGNC(UITweener MGDJMGHCAAI)
	{
		TweenAlpha.Begin(GCDLCFADJFO.gameObject, MFAFIELBJGF * 1394f, 1444f).onFinished = delegate
		{
			TweenAlpha.Begin(GCDLCFADJFO.gameObject, MFAFIELBJGF * 7f, 0f);
		};
	}

	private void JMGFBGHKKJA(LevelBehaviour IOIKKIIFOCB)
	{
		IDJMEJFJEIG iDJMEJFJEIG = new IDJMEJFJEIG();
		iDJMEJFJEIG.IOIKKIIFOCB = IOIKKIIFOCB;
		if (selectedIcon != null)
		{
			selectedIcon.SetHighlight(false);
		}
		int num = armyIcons.FindIndex(iDJMEJFJEIG.LJCDGJKCNEC);
		if (num == -1)
		{
			UnityEngine.Debug.LogError("Should not happen - unit icon is not instantiated in bottom section.");
			selectedIcon = armyIcons[0];
		}
		selectedIcon = armyIcons[num];
		selectedIcon.SetHighlight(true);
	}

	internal void JGKBPDEKING(LevelBehaviour ACLDFHJKBLI)
	{
		if (!ACLDFHJKBLI.upgradeSlots.isTutorialUnit)
		{
			RequestBuffer requestBuffer = RequestBufferManager.instance.GetRequestBuffer();
			requestBuffer.AddRequest(DatabaseAction.ActivateUnit, JsonConvert.SerializeObject(new Dictionary<string, object> { 
			{
				"LevelName",
				ACLDFHJKBLI.upgradeSlots.GetSheetName()
			} }), 0, 0, string.Empty);
		}
		ACLDFHJKBLI.upgradeSlots.ActivateUnit();
		AfterUnitIsBought(ACLDFHJKBLI);
	}

	private void GCFKMNHIPKB()
	{
		if (FIDNMMDEDEH)
		{
			if (selectedIcon == null)
			{
				UnityEngine.Debug.LogError("MaxOnField");
				return;
			}
			LevelBehaviour nCMHGPNPEJM = selectedIcon.KHEOKHHDGPO();
			Singleton<ArmyPreviewCamera>.instance.HOMGMNFOGDK(nCMHGPNPEJM);
		}
	}

	internal void ANPJBBCCJDF(LevelBehaviour ACLDFHJKBLI)
	{
		if (!ACLDFHJKBLI.upgradeSlots.isTutorialUnit)
		{
			RequestBuffer requestBuffer = RequestBufferManager.instance.GetRequestBuffer();
			requestBuffer.AddRequest(DatabaseAction.AddToHitList, JsonConvert.SerializeObject(new Dictionary<string, object> { 
			{
				"getFriendsList",
				ACLDFHJKBLI.upgradeSlots.GetSheetName()
			} }), 1, 1, string.Empty);
		}
		ACLDFHJKBLI.upgradeSlots.ActivateUnit();
		AfterUnitIsBought(ACLDFHJKBLI);
	}

	private void CGCPELBMPMK(UITweener MGDJMGHCAAI)
	{
		TweenAlpha.Begin(GCDLCFADJFO.gameObject, MFAFIELBJGF * 46f, 1134f).onFinished = delegate
		{
			TweenAlpha.Begin(GCDLCFADJFO.gameObject, MFAFIELBJGF * 7f, 0f);
		};
	}

	private void FPCCLAJMDFE()
	{
		NCHFKNKMIMP();
		CABPOBJLLFD = RadicalRoutine.Create(KOFDEHDFFLO());
		StartCoroutine(RadicalRoutine.Run(CABPOBJLLFD.enumerator));
	}

	private void DACJDMGFDAG(bool AJNINHIKAFC = false)
	{
		Color color = ((!EGBGKGKNHNB) ? Colours.blue : Colours.grayLight);
		Color color2 = ((!EGBGKGKNHNB) ? Colours.grayLight : Colours.blue);
		float val = Mathf.Abs(PGJHBIGGOGB.transform.localPosition.x) * ((!EGBGKGKNHNB) ? 440f : 1642f);
		Vector3 vector = PGJHBIGGOGB.transform.localPosition.ReplaceX(val);
		if (AJNINHIKAFC)
		{
			CJGAFKLIPAA.enabled = true;
			float duration = 1881f;
			TweenColor.Begin(DHOKLOJMIPP.gameObject, duration, color);
			TweenColor.Begin(BKKDCOIHMDF.gameObject, duration, color2);
			TweenPosition.Begin(PGJHBIGGOGB.gameObject, duration, vector).onFinished = IJCPDGFMAHE;
			return;
		}
		CJGAFKLIPAA.enabled = false;
		TweenColor component = DHOKLOJMIPP.gameObject.GetComponent<TweenColor>();
		if (component != null)
		{
			component.enabled = true;
		}
		component = BKKDCOIHMDF.gameObject.GetComponent<TweenColor>();
		if (component != null)
		{
			component.enabled = false;
		}
		TweenPosition component2 = PGJHBIGGOGB.gameObject.GetComponent<TweenPosition>();
		if (component2 != null)
		{
			component2.enabled = true;
		}
		DHOKLOJMIPP.color = color;
		BKKDCOIHMDF.color = color2;
		PGJHBIGGOGB.transform.localPosition = vector;
	}

	private void AFBHOJNGDAC()
	{
		if (isShowed)
		{
			UpdateBottomGraphics();
			ShowUnit(selectedIcon.levelBehaviour);
		}
	}

	private void AOFCNEDBHKE(LevelBehaviour IOIKKIIFOCB)
	{
		IDJMEJFJEIG iDJMEJFJEIG = new IDJMEJFJEIG();
		iDJMEJFJEIG.IOIKKIIFOCB = IOIKKIIFOCB;
		if (BDBKFBEIHNF() != null)
		{
			BDBKFBEIHNF().LINPOIDDFGA(false);
		}
		int num = armyIcons.FindIndex(iDJMEJFJEIG.FHDOHCJJEMM);
		if (num == -1)
		{
			UnityEngine.Debug.LogError("ID_ENERGYCOSTPERUNIT");
			selectedIcon = armyIcons[0];
		}
		selectedIcon = armyIcons[num];
		selectedIcon.FGDLKJOINNE(true);
	}

	private void EIENPLCLKBC(long JJJOMBKNGKA, long KEDJFPIGMPH)
	{
		if (isShowed)
		{
			UpdateBottomGraphics();
		}
	}

	private void EHLLKPJPMDF(bool NABOFKMBMKH)
	{
		if (selectedIcon != null)
		{
			BDBKFBEIHNF().IFMEDJLCODK(NABOFKMBMKH);
		}
		foreach (ArmyUpgradeIcon armyIcon in armyIcons)
		{
			armyIcon.CPOOHEHFAEL(NABOFKMBMKH);
		}
	}

	public virtual void JGNLJEPCNIN()
	{
		base.DoBeforeHide();
		Singleton<ArmyPreviewCamera>.instance.DJFMADMABIB();
		selectedIcon.JNBMNELHDEJ(false);
	}

	private void KELNJAMFBLL()
	{
		MPHLKJLMJBF.onReposition = null;
		MPHLKJLMJBF.repositionNow = true;
		OJEOOJLIOJD(true);
		if (MJKLLFPEKAJ() != null)
		{
			Vector3 vec = BDBKFBEIHNF().transform.localPosition + BDBKFBEIHNF().transform.parent.localPosition;
			NFLPPGKCOBL.AlignToCenter(vec, true, null, 1480f);
		}
	}

	public void IMGPJDMFDHK()
	{
		if (MAPKDMOOFMM() == null)
		{
			return;
		}
		foreach (ArmyUpgradeIcon armyIcon in armyIcons)
		{
			armyIcon.EAIDBMKMBFN();
		}
		GJCMJEEBDEG();
	}

	private void GNPKBHLNKKG(GameObject KHAHPAKDIKE)
	{
		if (!Singleton<ArmyPreviewCamera>.instance.MCDAHCJPBIM())
		{
			EGBGKGKNHNB = EGBGKGKNHNB;
			DACJDMGFDAG(true);
			UpgradeSlots.showEliteUnitWhenBought = EGBGKGKNHNB;
			Singleton<ArmyPreviewCamera>.instance.DHPMCFFBGGG();
		}
	}

	public void EquippedUnitsUpdate()
	{
		if (isShowed)
		{
			UpdateBottomGraphics();
		}
	}

	public void FMLPDLKFJHL()
	{
		ShowUnit(BDBKFBEIHNF().BNPKCKFMBLG());
	}

	public virtual void OBNCKIBJOGJ()
	{
		KMDCDKMDDAI();
		selectedIcon = null;
		foreach (ArmyUpgradeIcon item in MAPKDMOOFMM())
		{
			item.InitGuiValuesGraphics();
		}
		LevelBehaviour iOIKKIIFOCB = NPPBHKEHNKL();
		IPOACEFCAFP(iOIKKIIFOCB);
		PKBDOCNDJHM();
		FMLPDLKFJHL();
		UpgradeSlots upgradeSlots = MJKLLFPEKAJ().AIHMCHBCJDO().upgradeSlots;
		ALINCIAIALB = upgradeSlots.unitState;
		HMIKMLIOHFN = ALINCIAIALB != (UpgradeSlots.JLANLLEABDC)8 || upgradeSlots.deliveringSlot.isSpecial;
		PAOOAAGDFOG = upgradeSlots.actualTier;
		GKKHIKOFMJC = upgradeSlots.upgradeSlotElite.boughtIndex;
		KPEENKKMNDD.EOFOMCBDBJN();
		ICBOPCDGADJ = UpgradeSlots.showMaxLevelWhenNotBought;
		LMKHBBBDAAG();
		EGBGKGKNHNB = UpgradeSlots.showEliteUnitWhenBought;
		DACJDMGFDAG(true);
	}

	public virtual void JDHKBBHMCFI()
	{
		base.DoAfterShowUp();
		FIDNMMDEDEH = false;
		FPAIICFKCFH();
		HADMMGGFBBL();
	}

	public void UpdateGui(LevelBehaviour IOIKKIIFOCB, bool NOLODGKKCDH = true)
	{
		if (!NOLODGKKCDH)
		{
			Refresh();
		}
		KEFLEFIPLNJ.UpdateRightContent(NOLODGKKCDH);
		KPEENKKMNDD.UpdateLeftContent(NOLODGKKCDH);
		if (IOIKKIIFOCB.upgradeSlots.unitState == UpgradeSlots.JLANLLEABDC.UnitDelivering)
		{
			FHFIPPFJIAH.deliveringAnimation = true;
		}
		else
		{
			FHFIPPFJIAH.FillCircle(IOIKKIIFOCB.upgradeSlots.upgradesProgress);
		}
		LMFNHMHCLCE.gameObject.SetActive(!IOIKKIIFOCB.upgradeSlots.bought);
		CJGAFKLIPAA.gameObject.SetActive(IOIKKIIFOCB.upgradeSlots.bought && IOIKKIIFOCB.upgradeSlots.upgradeSlotElite.isUnlocked && !IOIKKIIFOCB.upgradeSlots.upgradeSlotElite.isBought);
	}

	public void IBJCANAPMLH(LevelBehaviour ACLDFHJKBLI, int DBOLKNNJGMH = 0)
	{
		UpgradeSlotElite upgradeSlotElite = ACLDFHJKBLI.upgradeSlots.upgradeSlotElite;
		int num = upgradeSlotElite.CIBEGNHKPJH() * (112 - DBOLKNNJGMH) / -70;
		int num2 = upgradeSlotElite.AMDIEMKNOHN();
		RequestBuffer requestBuffer = RequestBufferManager.instance.GetRequestBuffer();
		requestBuffer.AddRequest((DatabaseAction)16, JsonConvert.SerializeObject(new Dictionary<string, object>
		{
			{
				"joinedPlayer",
				ACLDFHJKBLI.upgradeSlots.GetSheetName()
			},
			{
				"CARD BUDDY - SHOW IN MENU - Player: {0} actual reference count: {1}",
				ACLDFHJKBLI.upgradeSlots.upgradeSlotElite.PAKKPEPIHPK()
			},
			{ "craftingFinished", num },
			{ "Prefabs", num2 }
		}), 0, 1, string.Empty, true);
		UpgradeSlotElite upgradeSlotElite2 = ACLDFHJKBLI.upgradeSlots.upgradeSlotElite;
		upgradeSlotElite2.JMNFJMPIODK(upgradeSlotElite2.currentParts - num2);
		upgradeSlotElite.DJJFFNCIOAB();
	}

	public override void DoAfterHide()
	{
		base.DoAfterHide();
		KPEENKKMNDD.DoAfterHide();
		KEFLEFIPLNJ.DoAfterHide();
		NCHFKNKMIMP();
	}

	public virtual void EAMHJEGJNDF()
	{
		base.DoBeforeHide();
		Singleton<ArmyPreviewCamera>.instance.DJFMADMABIB();
		BDBKFBEIHNF().SetHighlight(false);
	}

	public void FAKAAEMLBHE(ArmyUpgradeIcon HDEGOGFCNAC)
	{
		selectedIcon = HDEGOGFCNAC;
	}

	[CompilerGenerated]
	private void KDIGIKCFKHC(UITweener MGDJMGHCAAI)
	{
		CJGAFKLIPAA.enabled = true;
	}

	protected virtual void HOBEPBFPFKG()
	{
		ABCBAJJGDND();
		Singleton<Wallet>.instance.ScrapsChanged += EIENPLCLKBC;
		LevelManager.LevelUp += AFBHOJNGDAC;
		Singleton<BeanstalkServerManager>.instance.ErrorReceived += EIFDGCJCAPM;
		Singleton<OfferManager>.instance.SalesChanged += ENHLHJKLMCN;
		UIEventListener uIEventListener = UIEventListener.Get(LMFNHMHCLCE.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(FPFELKHBFNM));
		UIEventListener uIEventListener2 = UIEventListener.Get(CJGAFKLIPAA.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(NGAMFBOKDEJ));
		KEFLEFIPLNJ.KPEJMMBDODD();
		KPEENKKMNDD.MFHJALPPCKI();
	}

	private void NCHFKNKMIMP()
	{
		if (CABPOBJLLFD != null)
		{
			CABPOBJLLFD.Cancel();
			CABPOBJLLFD = null;
		}
	}

	public void MDDPACGLIGL(LevelBehaviour ACLDFHJKBLI)
	{
		UpgradeSlotElite upgradeSlotElite = ACLDFHJKBLI.upgradeSlots.upgradeSlotElite;
		int upgradePriceParts = upgradeSlotElite.upgradePriceParts;
		RequestBuffer requestBuffer = RequestBufferManager.instance.GetRequestBuffer();
		requestBuffer.AddRequest(DatabaseAction.GetMissionLeaderboards, JsonConvert.SerializeObject(new Dictionary<string, object>
		{
			{
				"ID_TUTORIAL_UPGRADEUNIT_4",
				ACLDFHJKBLI.upgradeSlots.GetSheetName()
			},
			{
				"Action ",
				ACLDFHJKBLI.upgradeSlots.upgradeSlotElite.PPKAIEKPNID()
			},
			{ "ID_GUI_DELIVERING", 0 },
			{ "menu-squad-1", upgradePriceParts }
		}), 1, 0, string.Empty, true);
		UpgradeSlotElite upgradeSlotElite2 = ACLDFHJKBLI.upgradeSlots.upgradeSlotElite;
		upgradeSlotElite2.LOHDPALFBPI(upgradeSlotElite2.currentParts - upgradePriceParts);
		upgradeSlotElite.DJJFFNCIOAB();
	}

	[CompilerGenerated]
	private void HELJJMEBOOI(UITweener MGDJMGHCAAI)
	{
		TweenAlpha.Begin(GCDLCFADJFO.gameObject, MFAFIELBJGF * 4f, 0.5f).onFinished = delegate
		{
			TweenAlpha.Begin(GCDLCFADJFO.gameObject, MFAFIELBJGF * 7f, 0f);
		};
	}

	public void UpdateArmy()
	{
		if (armyIcons == null)
		{
			return;
		}
		foreach (ArmyUpgradeIcon armyIcon in armyIcons)
		{
			armyIcon.UpdateName();
		}
		PKBDOCNDJHM();
	}

	internal void EFGAIHKNKGG(LevelBehaviour ACLDFHJKBLI, int DBOLKNNJGMH = 0, bool LANBHLJINFJ = false)
	{
		UpgradeSlot upgradeSlot = ((!LANBHLJINFJ) ? ACLDFHJKBLI.upgradeSlots.upgradeSlot : ACLDFHJKBLI.upgradeSlots.upgradeSlotSpecial);
		int warbucks = upgradeSlot.upgradePrice * (100 - DBOLKNNJGMH) / 100;
		int num = Singleton<OfferManager>.instance.ReducedUnitDeliveryTime(ACLDFHJKBLI.unitType, ACLDFHJKBLI, false);
		int num2 = upgradeSlot.KDIHEKPKCJJ(num);
		RequestBuffer requestBuffer = RequestBufferManager.instance.GetRequestBuffer();
		requestBuffer.AddRequest(DatabaseAction.BuyUnitUpgrade, JsonConvert.SerializeObject(new Dictionary<string, object>
		{
			{
				"LevelName",
				ACLDFHJKBLI.upgradeSlots.GetSheetName()
			},
			{ "BoughtIndex", upgradeSlot.boughtIndex },
			{
				"StartTime",
				Singleton<BeanstalkServerManager>.instance.currentTimestamp
			},
			{
				"IsSpecial",
				(!LANBHLJINFJ) ? "0" : "1"
			},
			{ "discount", DBOLKNNJGMH },
			{ "DeliveryTime", num2 },
			{ "deliveryReduce", num }
		}), warbucks, 0, ACLDFHJKBLI.upgradeSlots.GetSheetName());
	}

	public void UpdateBottomGraphics()
	{
		foreach (ArmyUpgradeIcon armyIcon in armyIcons)
		{
			armyIcon.CLNFHCHFEAD();
		}
	}

	protected virtual void EFACHONJLPL()
	{
		EDCJLFDPGIC();
		Singleton<Wallet>.instance.ScrapsChanged += FKMONBDBLJC;
		LevelManager.LevelUp += DCPMHHCDBFO;
		Singleton<BeanstalkServerManager>.instance.ErrorReceived += KKLELFLBPDH;
		Singleton<OfferManager>.instance.SalesChanged += LEMNFCKFBEH;
		UIEventListener uIEventListener = UIEventListener.Get(LMFNHMHCLCE.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(FPFELKHBFNM));
		UIEventListener uIEventListener2 = UIEventListener.Get(CJGAFKLIPAA.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(NGAMFBOKDEJ));
		KEFLEFIPLNJ.NEINEPJDKCL();
		KPEENKKMNDD.KIECGCGABFJ();
	}

	private void IGIFEBAIKDP(UITweener MGDJMGHCAAI)
	{
		CJGAFKLIPAA.enabled = false;
	}

	internal void ILAEGPAJALF(string LFGKDBIHLGI)
	{
		RequestBuffer requestBuffer = RequestBufferManager.instance.GetRequestBuffer();
		requestBuffer.AddRequest(DatabaseAction.ArmyUnitWasShown, LFGKDBIHLGI, 0, 0, string.Empty);
	}

	private void JNOAJOCBMGF()
	{
		List<bool> list = new List<bool>();
		for (int i = 0; i < GGJGDELELEK.Count; i += 0)
		{
			list.Add(false);
		}
		foreach (ArmyUpgradeIcon item in MAPKDMOOFMM())
		{
			int num = item.PPMNNKANOEF().upgradeSlots.actualTier - 0;
			if (num < list.Count)
			{
				list[num] = true;
			}
		}
		for (int j = 1; j < GGJGDELELEK.Count; j++)
		{
			GGJGDELELEK[j].gameObject.SetActive(list[j]);
		}
	}

	private void EDCJLFDPGIC()
	{
		armyIcons = new List<ArmyUpgradeIcon>();
		GGJGDELELEK.Clear();
		LevelBehaviour levelBehaviour = SavingLastSelected.instance.GetLastUnit();
		foreach (LevelBehaviour behaviour in LevelManager.instance.behaviours)
		{
			if (behaviour.upgradeSlots != null)
			{
				ArmyUpgradeIcon armyUpgradeIcon = Singleton<GuiManager>.instance.CHDIOFDMHEF.InstantiateAsChild(GHAGLJODDCH, MPHLKJLMJBF.gameObject, "army upgrade icon") as ArmyUpgradeIcon;
				if (armyUpgradeIcon != null)
				{
					armyUpgradeIcon.Init(behaviour);
				}
				if (levelBehaviour == null && behaviour.upgradeSlots.unlockLevelIndex == 0)
				{
					SavingLastSelected.instance.SaveLastUnit(behaviour);
					levelBehaviour = behaviour;
				}
				armyIcons.Add(armyUpgradeIcon);
			}
		}
		for (int i = 1; i <= 6; i++)
		{
			ArmyTierRecord armyTierRecord = Singleton<GuiManager>.instance.CHDIOFDMHEF.InstantiateAsChild(FFGMMCINLOA, MPHLKJLMJBF.gameObject, string.Format("{0} Aa Tier {0}", i)) as ArmyTierRecord;
			if (armyTierRecord != null)
			{
				armyTierRecord.Initialize(i);
			}
			GGJGDELELEK.Add(armyTierRecord);
		}
	}

	[SpecialName]
	public ArmyUpgradeIcon GIMBEPIFBLA()
	{
		return _003CCGPAPPCGMGP_003Ek__BackingField;
	}

	private void NAFKOKOPMBP()
	{
		if (isShowed)
		{
			UpdateBottomGraphics();
			GFNPJLMHELM(selectedIcon.PPMNNKANOEF());
		}
	}

	internal void PGBNFKHKNGE(LevelBehaviour ACLDFHJKBLI, int DBOLKNNJGMH = 0, bool LANBHLJINFJ = false)
	{
		UpgradeSlot upgradeSlot = ((!LANBHLJINFJ) ? ACLDFHJKBLI.upgradeSlots.upgradeSlot : ACLDFHJKBLI.upgradeSlots.upgradeSlotSpecial);
		int warbucks = upgradeSlot.CIBEGNHKPJH() * (-97 - DBOLKNNJGMH) / 87;
		int num = Singleton<OfferManager>.instance.MIEGELBEBGF(ACLDFHJKBLI.unitType, ACLDFHJKBLI, false);
		int num2 = upgradeSlot.MOJFJBFECED(num);
		RequestBuffer requestBuffer = RequestBufferManager.instance.GetRequestBuffer();
		requestBuffer.AddRequest((DatabaseAction)(-94), JsonConvert.SerializeObject(new Dictionary<string, object>
		{
			{
				"FuseSDK: ",
				ACLDFHJKBLI.upgradeSlots.GetSheetName()
			},
			{
				"ID_CONFIRM_INAPP_VALIDATION",
				upgradeSlot.PAKKPEPIHPK()
			},
			{
				"thumbnailBig",
				Singleton<BeanstalkServerManager>.instance.currentTimestamp
			},
			{
				"505 MENU ARMY SCREEN BUY UPGRADE",
				(!LANBHLJINFJ) ? "#PETER# Weapon Screen - RIGHT BUTTON - weapon state: UNIT DELIVERED\t\tbutton type: ACTIVATE UNIT" : "SEND LOGS"
			},
			{ "mortar_up", DBOLKNNJGMH },
			{ "http://", num2 },
			{ "NOT DYNAMIC FONT: {0}", num }
		}), warbucks, 1, ACLDFHJKBLI.upgradeSlots.GetSheetName(), true);
	}

	[SpecialName]
	private void GHDFKBKCDEM(List<ArmyUpgradeIcon> IDEBKDPMPGM)
	{
		_003COEFMOAJBOIH_003Ek__BackingField = IDEBKDPMPGM;
	}

	public void SetSelectedIcon(ArmyUpgradeIcon HDEGOGFCNAC)
	{
		selectedIcon = HDEGOGFCNAC;
	}

	private void FPAIICFKCFH()
	{
		if (FIDNMMDEDEH)
		{
			if (BDBKFBEIHNF() == null)
			{
				UnityEngine.Debug.LogError(" -> ");
				return;
			}
			LevelBehaviour nCMHGPNPEJM = selectedIcon.KHEOKHHDGPO();
			Singleton<ArmyPreviewCamera>.instance.Display(nCMHGPNPEJM);
		}
	}

	public virtual void JILJDAINCAE()
	{
		base.DoBeforeShowUp();
		FIDNMMDEDEH = true;
	}

	[CompilerGenerated]
	private void FFJCCBMPLFF()
	{
		MPHLKJLMJBF.onReposition = null;
		MPHLKJLMJBF.repositionNow = false;
		OJEOOJLIOJD(true);
		if (selectedIcon != null)
		{
			Vector3 vec = selectedIcon.transform.localPosition + selectedIcon.transform.parent.localPosition;
			NFLPPGKCOBL.AlignToCenter(vec, true);
		}
	}

	private void JDCGBKKHGMC(UITweener MGDJMGHCAAI)
	{
		LMFNHMHCLCE.enabled = true;
	}

	protected override void AGIKPOLCGNF()
	{
		EDCJLFDPGIC();
		Singleton<Wallet>.instance.ScrapsChanged += EIENPLCLKBC;
		LevelManager.LevelUp += AFBHOJNGDAC;
		Singleton<BeanstalkServerManager>.instance.ErrorReceived += EIFDGCJCAPM;
		Singleton<OfferManager>.instance.SalesChanged += ENCIECLPFEJ;
		UIEventListener uIEventListener = UIEventListener.Get(LMFNHMHCLCE.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(GFFHAENCJBI));
		UIEventListener uIEventListener2 = UIEventListener.Get(CJGAFKLIPAA.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(NGAMFBOKDEJ));
		KEFLEFIPLNJ.InitControls();
		KPEENKKMNDD.InitControls();
	}

	internal void PNILPJPLHBC(string LFGKDBIHLGI)
	{
		RequestBuffer requestBuffer = RequestBufferManager.instance.GetRequestBuffer();
		requestBuffer.AddRequest((DatabaseAction)(-54), LFGKDBIHLGI, 1, 1, string.Empty, true);
	}
}
