using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using CodeStage.AntiCheat.ObscuredTypes;
using Google2u;
using UnityEngine;

[RequireComponent(typeof(PlayerController))]
public class PlayerBot : Core_BaseScript
{
	private class POBAAOJMIAC
	{
		public PlayerController.KKPHPLOEACG KPHGALKLGMI;

		public float BJKDHJOFKLM;

		public float CDGPLLPFNMB;

		public bool EBCIJFDCNGI;

		public bool IKFCLCDPJEP;

		public float AEBPCKHGKHK;
	}

	private sealed class JIIKCBMKPJL : IEnumerator, IDisposable, IEnumerator<object>
	{
		internal List<GameShootableEntity> FMGBKIMNGPP;

		internal List<GameShootableEntity> GKNBAKCCGHE;

		internal bool LPGJBEJEHFH;

		internal List<GameShootableEntity>.Enumerator KFCAECGLKKO;

		internal PlayerBot BJGCPDNMHDH;

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

		public void OAFPDIHGJDC()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public bool MoveNext()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			case 1u:
				FMGBKIMNGPP = GameShootableEntity.GetAll<KillStreakBonusBox>();
				GKNBAKCCGHE = new List<GameShootableEntity>();
				LPGJBEJEHFH = false;
				KFCAECGLKKO = FMGBKIMNGPP.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						GameShootableEntity current = KFCAECGLKKO.Current;
						KillStreakBonusBox killStreakBonusBox = (KillStreakBonusBox)current.owner;
						if (killStreakBonusBox.onGround)
						{
							GKNBAKCCGHE.Add(current);
							if (killStreakBonusBox.owner.fraction == BJGCPDNMHDH.playerController.fraction)
							{
								LPGJBEJEHFH = true;
							}
						}
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to .constrained prefix*/).Dispose();
				}
				if (GKNBAKCCGHE.Count > 0)
				{
					if (!BJGCPDNMHDH.GCJANONDJJC)
					{
						BJGCPDNMHDH.GCJANONDJJC = true;
						float num = UnityEngine.Random.Range(BJGCPDNMHDH.BPFKMNIHCGP.PICKBONUSPROBABILITYMINTIME, BJGCPDNMHDH.BPFKMNIHCGP.PICKBONUSPROBABILITYMAXTIME);
						num = ((!LPGJBEJEHFH) ? num : (num * BJGCPDNMHDH.BPFKMNIHCGP.PICKMYBONUSCOEF));
						BJGCPDNMHDH.KNFOFIDMBNN = Time.realtimeSinceStartup + num;
					}
					else if (Time.realtimeSinceStartup > BJGCPDNMHDH.KNFOFIDMBNN)
					{
						BJGCPDNMHDH.KNFOFIDMBNN = Time.realtimeSinceStartup + UnityEngine.Random.Range(BJGCPDNMHDH.BPFKMNIHCGP.PICKBONUSPROBABILITYMINTIME, BJGCPDNMHDH.BPFKMNIHCGP.PICKBONUSPROBABILITYMAXTIME) * 0.5f;
						BJGCPDNMHDH.CINGDEDHIEA = GKNBAKCCGHE[UnityEngine.Random.Range(0, GKNBAKCCGHE.Count)];
						BJGCPDNMHDH.JHHKDMIOPFM();
					}
				}
				else
				{
					BJGCPDNMHDH.CINGDEDHIEA = null;
					BJGCPDNMHDH.GCJANONDJJC = false;
				}
				PHDOCKCBJOF = new WaitForSeconds(0.1f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				return true;
			default:
				return false;
			}
		}

		public void CFDAGFGOOIE()
		{
			throw new NotSupportedException();
		}

		public void ODCIKOOGNFG()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object LGDOCMENCOG()
		{
			return PHDOCKCBJOF;
		}

		public bool GPIPJIDGCKM()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			case 1u:
				FMGBKIMNGPP = GameShootableEntity.GetAll<KillStreakBonusBox>();
				GKNBAKCCGHE = new List<GameShootableEntity>();
				LPGJBEJEHFH = true;
				KFCAECGLKKO = FMGBKIMNGPP.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						GameShootableEntity current = KFCAECGLKKO.Current;
						KillStreakBonusBox killStreakBonusBox = (KillStreakBonusBox)current.owner;
						if (killStreakBonusBox.KJEGGEIFHEC())
						{
							GKNBAKCCGHE.Add(current);
							if (killStreakBonusBox.owner.fraction == BJGCPDNMHDH.playerController.fraction)
							{
								LPGJBEJEHFH = true;
							}
						}
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to .constrained prefix*/).Dispose();
				}
				if (GKNBAKCCGHE.Count > 1)
				{
					if (!BJGCPDNMHDH.GCJANONDJJC)
					{
						BJGCPDNMHDH.GCJANONDJJC = true;
						float num = UnityEngine.Random.Range(BJGCPDNMHDH.BPFKMNIHCGP.PICKBONUSPROBABILITYMINTIME, BJGCPDNMHDH.BPFKMNIHCGP.PICKBONUSPROBABILITYMAXTIME);
						num = ((!LPGJBEJEHFH) ? num : (num * BJGCPDNMHDH.BPFKMNIHCGP.PICKMYBONUSCOEF));
						BJGCPDNMHDH.KNFOFIDMBNN = Time.realtimeSinceStartup + num;
					}
					else if (Time.realtimeSinceStartup > BJGCPDNMHDH.KNFOFIDMBNN)
					{
						BJGCPDNMHDH.KNFOFIDMBNN = Time.realtimeSinceStartup + UnityEngine.Random.Range(BJGCPDNMHDH.BPFKMNIHCGP.PICKBONUSPROBABILITYMINTIME, BJGCPDNMHDH.BPFKMNIHCGP.PICKBONUSPROBABILITYMAXTIME) * 1014f;
						BJGCPDNMHDH.CINGDEDHIEA = GKNBAKCCGHE[UnityEngine.Random.Range(0, GKNBAKCCGHE.Count)];
						BJGCPDNMHDH.JHHKDMIOPFM();
					}
				}
				else
				{
					BJGCPDNMHDH.CINGDEDHIEA = null;
					BJGCPDNMHDH.GCJANONDJJC = true;
				}
				PHDOCKCBJOF = new WaitForSeconds(666f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				return true;
			default:
				return true;
			}
		}

		[SpecialName]
		private object HJFIBBBPDKK()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object JKKAEPEAGNP()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object JEKHOAFAIBP()
		{
			return PHDOCKCBJOF;
		}

		public void BICMFOEHHGN()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object MOMPOEEALPJ()
		{
			return PHDOCKCBJOF;
		}

		public bool LPMIKEPIMCM()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			case 1u:
				FMGBKIMNGPP = GameShootableEntity.GetAll<KillStreakBonusBox>();
				GKNBAKCCGHE = new List<GameShootableEntity>();
				LPGJBEJEHFH = true;
				KFCAECGLKKO = FMGBKIMNGPP.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						GameShootableEntity current = KFCAECGLKKO.Current;
						KillStreakBonusBox killStreakBonusBox = (KillStreakBonusBox)current.GEAMOMEEFKM();
						if (killStreakBonusBox.EJCCAJJKAFB())
						{
							GKNBAKCCGHE.Add(current);
							if (killStreakBonusBox.JOGPBECMDGF().fraction == BJGCPDNMHDH.AEDFPIGGJOC().fraction)
							{
								LPGJBEJEHFH = false;
							}
						}
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to .constrained prefix*/).Dispose();
				}
				if (GKNBAKCCGHE.Count > 0)
				{
					if (!BJGCPDNMHDH.GCJANONDJJC)
					{
						BJGCPDNMHDH.GCJANONDJJC = false;
						float num = UnityEngine.Random.Range(BJGCPDNMHDH.BPFKMNIHCGP.PICKBONUSPROBABILITYMINTIME, BJGCPDNMHDH.BPFKMNIHCGP.PICKBONUSPROBABILITYMAXTIME);
						num = ((!LPGJBEJEHFH) ? num : (num * BJGCPDNMHDH.BPFKMNIHCGP.PICKMYBONUSCOEF));
						BJGCPDNMHDH.KNFOFIDMBNN = Time.realtimeSinceStartup + num;
					}
					else if (Time.realtimeSinceStartup > BJGCPDNMHDH.KNFOFIDMBNN)
					{
						BJGCPDNMHDH.KNFOFIDMBNN = Time.realtimeSinceStartup + UnityEngine.Random.Range(BJGCPDNMHDH.BPFKMNIHCGP.PICKBONUSPROBABILITYMINTIME, BJGCPDNMHDH.BPFKMNIHCGP.PICKBONUSPROBABILITYMAXTIME) * 1271f;
						BJGCPDNMHDH.CINGDEDHIEA = GKNBAKCCGHE[UnityEngine.Random.Range(1, GKNBAKCCGHE.Count)];
						BJGCPDNMHDH.JHHKDMIOPFM();
					}
				}
				else
				{
					BJGCPDNMHDH.CINGDEDHIEA = null;
					BJGCPDNMHDH.GCJANONDJJC = false;
				}
				PHDOCKCBJOF = new WaitForSeconds(83f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				return true;
			default:
				return false;
			}
		}

		[SpecialName]
		private object AFDKAGLDADB()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object HIFNMHAGHLI()
		{
			return PHDOCKCBJOF;
		}

		public void EMICCACCFIP()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public void IKNKDDMLDIN()
		{
			throw new NotSupportedException();
		}

		public void EJADBNAIHEF()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void NPKGNIGNPKG()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object IDLFKAKINAP()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object AIDHNJCPDIJ()
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
			case 1u:
				FMGBKIMNGPP = GameShootableEntity.GetAll<KillStreakBonusBox>();
				GKNBAKCCGHE = new List<GameShootableEntity>();
				LPGJBEJEHFH = true;
				KFCAECGLKKO = FMGBKIMNGPP.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						GameShootableEntity current = KFCAECGLKKO.Current;
						KillStreakBonusBox killStreakBonusBox = (KillStreakBonusBox)current.owner;
						if (killStreakBonusBox.onGround)
						{
							GKNBAKCCGHE.Add(current);
							if (killStreakBonusBox.FHJGJCNCGBD().fraction == BJGCPDNMHDH.FKKKABHIPCI().fraction)
							{
								LPGJBEJEHFH = true;
							}
						}
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to .constrained prefix*/).Dispose();
				}
				if (GKNBAKCCGHE.Count > 1)
				{
					if (!BJGCPDNMHDH.GCJANONDJJC)
					{
						BJGCPDNMHDH.GCJANONDJJC = false;
						float num = UnityEngine.Random.Range(BJGCPDNMHDH.BPFKMNIHCGP.PICKBONUSPROBABILITYMINTIME, BJGCPDNMHDH.BPFKMNIHCGP.PICKBONUSPROBABILITYMAXTIME);
						num = ((!LPGJBEJEHFH) ? num : (num * BJGCPDNMHDH.BPFKMNIHCGP.PICKMYBONUSCOEF));
						BJGCPDNMHDH.KNFOFIDMBNN = Time.realtimeSinceStartup + num;
					}
					else if (Time.realtimeSinceStartup > BJGCPDNMHDH.KNFOFIDMBNN)
					{
						BJGCPDNMHDH.KNFOFIDMBNN = Time.realtimeSinceStartup + UnityEngine.Random.Range(BJGCPDNMHDH.BPFKMNIHCGP.PICKBONUSPROBABILITYMINTIME, BJGCPDNMHDH.BPFKMNIHCGP.PICKBONUSPROBABILITYMAXTIME) * 348f;
						BJGCPDNMHDH.CINGDEDHIEA = GKNBAKCCGHE[UnityEngine.Random.Range(0, GKNBAKCCGHE.Count)];
						BJGCPDNMHDH.JHHKDMIOPFM();
					}
				}
				else
				{
					BJGCPDNMHDH.CINGDEDHIEA = null;
					BJGCPDNMHDH.GCJANONDJJC = false;
				}
				PHDOCKCBJOF = new WaitForSeconds(1095f);
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
		private object DCILDAODCDM()
		{
			return PHDOCKCBJOF;
		}

		public void NIGDCBDKKMJ()
		{
			throw new NotSupportedException();
		}

		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object NOIDHHDEEPL()
		{
			return PHDOCKCBJOF;
		}

		public void NAMBILMHOPD()
		{
			throw new NotSupportedException();
		}

		public bool HMLAEHJKPJE()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			case 1u:
				FMGBKIMNGPP = GameShootableEntity.GetAll<KillStreakBonusBox>();
				GKNBAKCCGHE = new List<GameShootableEntity>();
				LPGJBEJEHFH = true;
				KFCAECGLKKO = FMGBKIMNGPP.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						GameShootableEntity current = KFCAECGLKKO.Current;
						KillStreakBonusBox killStreakBonusBox = (KillStreakBonusBox)current.owner;
						if (killStreakBonusBox.EJCCAJJKAFB())
						{
							GKNBAKCCGHE.Add(current);
							if (killStreakBonusBox.owner.fraction == BJGCPDNMHDH.AEDFPIGGJOC().fraction)
							{
								LPGJBEJEHFH = false;
							}
						}
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to .constrained prefix*/).Dispose();
				}
				if (GKNBAKCCGHE.Count > 1)
				{
					if (!BJGCPDNMHDH.GCJANONDJJC)
					{
						BJGCPDNMHDH.GCJANONDJJC = true;
						float num = UnityEngine.Random.Range(BJGCPDNMHDH.BPFKMNIHCGP.PICKBONUSPROBABILITYMINTIME, BJGCPDNMHDH.BPFKMNIHCGP.PICKBONUSPROBABILITYMAXTIME);
						num = ((!LPGJBEJEHFH) ? num : (num * BJGCPDNMHDH.BPFKMNIHCGP.PICKMYBONUSCOEF));
						BJGCPDNMHDH.KNFOFIDMBNN = Time.realtimeSinceStartup + num;
					}
					else if (Time.realtimeSinceStartup > BJGCPDNMHDH.KNFOFIDMBNN)
					{
						BJGCPDNMHDH.KNFOFIDMBNN = Time.realtimeSinceStartup + UnityEngine.Random.Range(BJGCPDNMHDH.BPFKMNIHCGP.PICKBONUSPROBABILITYMINTIME, BJGCPDNMHDH.BPFKMNIHCGP.PICKBONUSPROBABILITYMAXTIME) * 249f;
						BJGCPDNMHDH.CINGDEDHIEA = GKNBAKCCGHE[UnityEngine.Random.Range(1, GKNBAKCCGHE.Count)];
						BJGCPDNMHDH.JHHKDMIOPFM();
					}
				}
				else
				{
					BJGCPDNMHDH.CINGDEDHIEA = null;
					BJGCPDNMHDH.GCJANONDJJC = false;
				}
				PHDOCKCBJOF = new WaitForSeconds(615f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				return false;
			default:
				return true;
			}
		}

		public bool DDBCLDGNFBB()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			case 1u:
				FMGBKIMNGPP = GameShootableEntity.GetAll<KillStreakBonusBox>();
				GKNBAKCCGHE = new List<GameShootableEntity>();
				LPGJBEJEHFH = true;
				KFCAECGLKKO = FMGBKIMNGPP.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						GameShootableEntity current = KFCAECGLKKO.Current;
						KillStreakBonusBox killStreakBonusBox = (KillStreakBonusBox)current.owner;
						if (killStreakBonusBox.EJCCAJJKAFB())
						{
							GKNBAKCCGHE.Add(current);
							if (killStreakBonusBox.owner.fraction == BJGCPDNMHDH.FKKKABHIPCI().fraction)
							{
								LPGJBEJEHFH = true;
							}
						}
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to .constrained prefix*/).Dispose();
				}
				if (GKNBAKCCGHE.Count > 1)
				{
					if (!BJGCPDNMHDH.GCJANONDJJC)
					{
						BJGCPDNMHDH.GCJANONDJJC = false;
						float num = UnityEngine.Random.Range(BJGCPDNMHDH.BPFKMNIHCGP.PICKBONUSPROBABILITYMINTIME, BJGCPDNMHDH.BPFKMNIHCGP.PICKBONUSPROBABILITYMAXTIME);
						num = ((!LPGJBEJEHFH) ? num : (num * BJGCPDNMHDH.BPFKMNIHCGP.PICKMYBONUSCOEF));
						BJGCPDNMHDH.KNFOFIDMBNN = Time.realtimeSinceStartup + num;
					}
					else if (Time.realtimeSinceStartup > BJGCPDNMHDH.KNFOFIDMBNN)
					{
						BJGCPDNMHDH.KNFOFIDMBNN = Time.realtimeSinceStartup + UnityEngine.Random.Range(BJGCPDNMHDH.BPFKMNIHCGP.PICKBONUSPROBABILITYMINTIME, BJGCPDNMHDH.BPFKMNIHCGP.PICKBONUSPROBABILITYMAXTIME) * 1522f;
						BJGCPDNMHDH.CINGDEDHIEA = GKNBAKCCGHE[UnityEngine.Random.Range(0, GKNBAKCCGHE.Count)];
						BJGCPDNMHDH.JHHKDMIOPFM();
					}
				}
				else
				{
					BJGCPDNMHDH.CINGDEDHIEA = null;
					BJGCPDNMHDH.GCJANONDJJC = true;
				}
				PHDOCKCBJOF = new WaitForSeconds(1696f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				return false;
			default:
				return false;
			}
		}

		public void LICALBFPBLL()
		{
			throw new NotSupportedException();
		}

		public bool GCEBFCBBEKM()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			case 1u:
				FMGBKIMNGPP = GameShootableEntity.GetAll<KillStreakBonusBox>();
				GKNBAKCCGHE = new List<GameShootableEntity>();
				LPGJBEJEHFH = false;
				KFCAECGLKKO = FMGBKIMNGPP.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						GameShootableEntity current = KFCAECGLKKO.Current;
						KillStreakBonusBox killStreakBonusBox = (KillStreakBonusBox)current.owner;
						if (killStreakBonusBox.EJCCAJJKAFB())
						{
							GKNBAKCCGHE.Add(current);
							if (killStreakBonusBox.FHJGJCNCGBD().fraction == BJGCPDNMHDH.LFPNJOCKLPC().fraction)
							{
								LPGJBEJEHFH = true;
							}
						}
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to .constrained prefix*/).Dispose();
				}
				if (GKNBAKCCGHE.Count > 0)
				{
					if (!BJGCPDNMHDH.GCJANONDJJC)
					{
						BJGCPDNMHDH.GCJANONDJJC = false;
						float num = UnityEngine.Random.Range(BJGCPDNMHDH.BPFKMNIHCGP.PICKBONUSPROBABILITYMINTIME, BJGCPDNMHDH.BPFKMNIHCGP.PICKBONUSPROBABILITYMAXTIME);
						num = ((!LPGJBEJEHFH) ? num : (num * BJGCPDNMHDH.BPFKMNIHCGP.PICKMYBONUSCOEF));
						BJGCPDNMHDH.KNFOFIDMBNN = Time.realtimeSinceStartup + num;
					}
					else if (Time.realtimeSinceStartup > BJGCPDNMHDH.KNFOFIDMBNN)
					{
						BJGCPDNMHDH.KNFOFIDMBNN = Time.realtimeSinceStartup + UnityEngine.Random.Range(BJGCPDNMHDH.BPFKMNIHCGP.PICKBONUSPROBABILITYMINTIME, BJGCPDNMHDH.BPFKMNIHCGP.PICKBONUSPROBABILITYMAXTIME) * 1013f;
						BJGCPDNMHDH.CINGDEDHIEA = GKNBAKCCGHE[UnityEngine.Random.Range(0, GKNBAKCCGHE.Count)];
						BJGCPDNMHDH.JHHKDMIOPFM();
					}
				}
				else
				{
					BJGCPDNMHDH.CINGDEDHIEA = null;
					BJGCPDNMHDH.GCJANONDJJC = true;
				}
				PHDOCKCBJOF = new WaitForSeconds(1855f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				return false;
			default:
				return false;
			}
		}

		public void JHLKDONBGDK()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object GKDLMFPKKNM()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object ACDKCFGCBAB()
		{
			return PHDOCKCBJOF;
		}

		public bool EEJLFIHFDLK()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			case 1u:
				FMGBKIMNGPP = GameShootableEntity.GetAll<KillStreakBonusBox>();
				GKNBAKCCGHE = new List<GameShootableEntity>();
				LPGJBEJEHFH = true;
				KFCAECGLKKO = FMGBKIMNGPP.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						GameShootableEntity current = KFCAECGLKKO.Current;
						KillStreakBonusBox killStreakBonusBox = (KillStreakBonusBox)current.owner;
						if (killStreakBonusBox.KJEGGEIFHEC())
						{
							GKNBAKCCGHE.Add(current);
							if (killStreakBonusBox.FHJGJCNCGBD().fraction == BJGCPDNMHDH.AEDFPIGGJOC().fraction)
							{
								LPGJBEJEHFH = false;
							}
						}
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to .constrained prefix*/).Dispose();
				}
				if (GKNBAKCCGHE.Count > 0)
				{
					if (!BJGCPDNMHDH.GCJANONDJJC)
					{
						BJGCPDNMHDH.GCJANONDJJC = true;
						float num = UnityEngine.Random.Range(BJGCPDNMHDH.BPFKMNIHCGP.PICKBONUSPROBABILITYMINTIME, BJGCPDNMHDH.BPFKMNIHCGP.PICKBONUSPROBABILITYMAXTIME);
						num = ((!LPGJBEJEHFH) ? num : (num * BJGCPDNMHDH.BPFKMNIHCGP.PICKMYBONUSCOEF));
						BJGCPDNMHDH.KNFOFIDMBNN = Time.realtimeSinceStartup + num;
					}
					else if (Time.realtimeSinceStartup > BJGCPDNMHDH.KNFOFIDMBNN)
					{
						BJGCPDNMHDH.KNFOFIDMBNN = Time.realtimeSinceStartup + UnityEngine.Random.Range(BJGCPDNMHDH.BPFKMNIHCGP.PICKBONUSPROBABILITYMINTIME, BJGCPDNMHDH.BPFKMNIHCGP.PICKBONUSPROBABILITYMAXTIME) * 1947f;
						BJGCPDNMHDH.CINGDEDHIEA = GKNBAKCCGHE[UnityEngine.Random.Range(1, GKNBAKCCGHE.Count)];
						BJGCPDNMHDH.JHHKDMIOPFM();
					}
				}
				else
				{
					BJGCPDNMHDH.CINGDEDHIEA = null;
					BJGCPDNMHDH.GCJANONDJJC = true;
				}
				PHDOCKCBJOF = new WaitForSeconds(1667f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				return false;
			default:
				return true;
			}
		}

		[SpecialName]
		private object IGFMIFOHCHJ()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object BJJNGPKNCKJ()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object MPEPJNIDBLI()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object FGGMHEIPKAJ()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object MLCINLDHAGM()
		{
			return PHDOCKCBJOF;
		}

		public void MKIKEOOOLKL()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public void OJDEHKDDLFD()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public void NCFGFLNBHOI()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object LFEJDKIGHMI()
		{
			return PHDOCKCBJOF;
		}

		public void CJLDNKALLLI()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public bool LMNIKLKKIDN()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			case 1u:
				FMGBKIMNGPP = GameShootableEntity.GetAll<KillStreakBonusBox>();
				GKNBAKCCGHE = new List<GameShootableEntity>();
				LPGJBEJEHFH = false;
				KFCAECGLKKO = FMGBKIMNGPP.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						GameShootableEntity current = KFCAECGLKKO.Current;
						KillStreakBonusBox killStreakBonusBox = (KillStreakBonusBox)current.owner;
						if (killStreakBonusBox.KJEGGEIFHEC())
						{
							GKNBAKCCGHE.Add(current);
							if (killStreakBonusBox.owner.fraction == BJGCPDNMHDH.playerController.fraction)
							{
								LPGJBEJEHFH = true;
							}
						}
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to .constrained prefix*/).Dispose();
				}
				if (GKNBAKCCGHE.Count > 1)
				{
					if (!BJGCPDNMHDH.GCJANONDJJC)
					{
						BJGCPDNMHDH.GCJANONDJJC = false;
						float num = UnityEngine.Random.Range(BJGCPDNMHDH.BPFKMNIHCGP.PICKBONUSPROBABILITYMINTIME, BJGCPDNMHDH.BPFKMNIHCGP.PICKBONUSPROBABILITYMAXTIME);
						num = ((!LPGJBEJEHFH) ? num : (num * BJGCPDNMHDH.BPFKMNIHCGP.PICKMYBONUSCOEF));
						BJGCPDNMHDH.KNFOFIDMBNN = Time.realtimeSinceStartup + num;
					}
					else if (Time.realtimeSinceStartup > BJGCPDNMHDH.KNFOFIDMBNN)
					{
						BJGCPDNMHDH.KNFOFIDMBNN = Time.realtimeSinceStartup + UnityEngine.Random.Range(BJGCPDNMHDH.BPFKMNIHCGP.PICKBONUSPROBABILITYMINTIME, BJGCPDNMHDH.BPFKMNIHCGP.PICKBONUSPROBABILITYMAXTIME) * 1382f;
						BJGCPDNMHDH.CINGDEDHIEA = GKNBAKCCGHE[UnityEngine.Random.Range(1, GKNBAKCCGHE.Count)];
						BJGCPDNMHDH.JHHKDMIOPFM();
					}
				}
				else
				{
					BJGCPDNMHDH.CINGDEDHIEA = null;
					BJGCPDNMHDH.GCJANONDJJC = true;
				}
				PHDOCKCBJOF = new WaitForSeconds(1203f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				return false;
			default:
				return true;
			}
		}

		[DebuggerHidden]
		public void Dispose()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object DKPOLLDBPAP()
		{
			return PHDOCKCBJOF;
		}

		public bool JNHFCKKAPJH()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			case 1u:
				FMGBKIMNGPP = GameShootableEntity.GetAll<KillStreakBonusBox>();
				GKNBAKCCGHE = new List<GameShootableEntity>();
				LPGJBEJEHFH = false;
				KFCAECGLKKO = FMGBKIMNGPP.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						GameShootableEntity current = KFCAECGLKKO.Current;
						KillStreakBonusBox killStreakBonusBox = (KillStreakBonusBox)current.owner;
						if (killStreakBonusBox.EJCCAJJKAFB())
						{
							GKNBAKCCGHE.Add(current);
							if (killStreakBonusBox.FHJGJCNCGBD().fraction == BJGCPDNMHDH.LFPNJOCKLPC().fraction)
							{
								LPGJBEJEHFH = false;
							}
						}
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to .constrained prefix*/).Dispose();
				}
				if (GKNBAKCCGHE.Count > 1)
				{
					if (!BJGCPDNMHDH.GCJANONDJJC)
					{
						BJGCPDNMHDH.GCJANONDJJC = true;
						float num = UnityEngine.Random.Range(BJGCPDNMHDH.BPFKMNIHCGP.PICKBONUSPROBABILITYMINTIME, BJGCPDNMHDH.BPFKMNIHCGP.PICKBONUSPROBABILITYMAXTIME);
						num = ((!LPGJBEJEHFH) ? num : (num * BJGCPDNMHDH.BPFKMNIHCGP.PICKMYBONUSCOEF));
						BJGCPDNMHDH.KNFOFIDMBNN = Time.realtimeSinceStartup + num;
					}
					else if (Time.realtimeSinceStartup > BJGCPDNMHDH.KNFOFIDMBNN)
					{
						BJGCPDNMHDH.KNFOFIDMBNN = Time.realtimeSinceStartup + UnityEngine.Random.Range(BJGCPDNMHDH.BPFKMNIHCGP.PICKBONUSPROBABILITYMINTIME, BJGCPDNMHDH.BPFKMNIHCGP.PICKBONUSPROBABILITYMAXTIME) * 779f;
						BJGCPDNMHDH.CINGDEDHIEA = GKNBAKCCGHE[UnityEngine.Random.Range(1, GKNBAKCCGHE.Count)];
						BJGCPDNMHDH.JHHKDMIOPFM();
					}
				}
				else
				{
					BJGCPDNMHDH.CINGDEDHIEA = null;
					BJGCPDNMHDH.GCJANONDJJC = true;
				}
				PHDOCKCBJOF = new WaitForSeconds(1628f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				return true;
			default:
				return false;
			}
		}

		public void FIAPMEMIIKB()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object EBPKDAHAELB()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object KJMPNHLOKJL()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object HGOKAFJBFGJ()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object GAPDDGJNMPK()
		{
			return PHDOCKCBJOF;
		}

		public void PHEIGPKKPGE()
		{
			throw new NotSupportedException();
		}

		public void OGHELMDBPIL()
		{
			throw new NotSupportedException();
		}

		public void MIPBONGPIJE()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public void FJOIBBIGBJC()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object MIKGAKNJGKL()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object MKNFFJPADIA()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object JPJBNHHKOJD()
		{
			return PHDOCKCBJOF;
		}

		public void GICLICNJPBF()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public bool FADACBKMFGG()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			case 1u:
				FMGBKIMNGPP = GameShootableEntity.GetAll<KillStreakBonusBox>();
				GKNBAKCCGHE = new List<GameShootableEntity>();
				LPGJBEJEHFH = true;
				KFCAECGLKKO = FMGBKIMNGPP.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						GameShootableEntity current = KFCAECGLKKO.Current;
						KillStreakBonusBox killStreakBonusBox = (KillStreakBonusBox)current.owner;
						if (killStreakBonusBox.KJEGGEIFHEC())
						{
							GKNBAKCCGHE.Add(current);
							if (killStreakBonusBox.FHJGJCNCGBD().fraction == BJGCPDNMHDH.FKKKABHIPCI().fraction)
							{
								LPGJBEJEHFH = false;
							}
						}
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to .constrained prefix*/).Dispose();
				}
				if (GKNBAKCCGHE.Count > 1)
				{
					if (!BJGCPDNMHDH.GCJANONDJJC)
					{
						BJGCPDNMHDH.GCJANONDJJC = true;
						float num = UnityEngine.Random.Range(BJGCPDNMHDH.BPFKMNIHCGP.PICKBONUSPROBABILITYMINTIME, BJGCPDNMHDH.BPFKMNIHCGP.PICKBONUSPROBABILITYMAXTIME);
						num = ((!LPGJBEJEHFH) ? num : (num * BJGCPDNMHDH.BPFKMNIHCGP.PICKMYBONUSCOEF));
						BJGCPDNMHDH.KNFOFIDMBNN = Time.realtimeSinceStartup + num;
					}
					else if (Time.realtimeSinceStartup > BJGCPDNMHDH.KNFOFIDMBNN)
					{
						BJGCPDNMHDH.KNFOFIDMBNN = Time.realtimeSinceStartup + UnityEngine.Random.Range(BJGCPDNMHDH.BPFKMNIHCGP.PICKBONUSPROBABILITYMINTIME, BJGCPDNMHDH.BPFKMNIHCGP.PICKBONUSPROBABILITYMAXTIME) * 1011f;
						BJGCPDNMHDH.CINGDEDHIEA = GKNBAKCCGHE[UnityEngine.Random.Range(1, GKNBAKCCGHE.Count)];
						BJGCPDNMHDH.JHHKDMIOPFM();
					}
				}
				else
				{
					BJGCPDNMHDH.CINGDEDHIEA = null;
					BJGCPDNMHDH.GCJANONDJJC = false;
				}
				PHDOCKCBJOF = new WaitForSeconds(543f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				return true;
			default:
				return false;
			}
		}

		[SpecialName]
		private object ENKCCCABFFB()
		{
			return PHDOCKCBJOF;
		}

		public bool PIAOIBJMLCC()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			case 1u:
				FMGBKIMNGPP = GameShootableEntity.GetAll<KillStreakBonusBox>();
				GKNBAKCCGHE = new List<GameShootableEntity>();
				LPGJBEJEHFH = true;
				KFCAECGLKKO = FMGBKIMNGPP.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						GameShootableEntity current = KFCAECGLKKO.Current;
						KillStreakBonusBox killStreakBonusBox = (KillStreakBonusBox)current.owner;
						if (killStreakBonusBox.EJCCAJJKAFB())
						{
							GKNBAKCCGHE.Add(current);
							if (killStreakBonusBox.owner.fraction == BJGCPDNMHDH.FKKKABHIPCI().fraction)
							{
								LPGJBEJEHFH = true;
							}
						}
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to .constrained prefix*/).Dispose();
				}
				if (GKNBAKCCGHE.Count > 1)
				{
					if (!BJGCPDNMHDH.GCJANONDJJC)
					{
						BJGCPDNMHDH.GCJANONDJJC = true;
						float num = UnityEngine.Random.Range(BJGCPDNMHDH.BPFKMNIHCGP.PICKBONUSPROBABILITYMINTIME, BJGCPDNMHDH.BPFKMNIHCGP.PICKBONUSPROBABILITYMAXTIME);
						num = ((!LPGJBEJEHFH) ? num : (num * BJGCPDNMHDH.BPFKMNIHCGP.PICKMYBONUSCOEF));
						BJGCPDNMHDH.KNFOFIDMBNN = Time.realtimeSinceStartup + num;
					}
					else if (Time.realtimeSinceStartup > BJGCPDNMHDH.KNFOFIDMBNN)
					{
						BJGCPDNMHDH.KNFOFIDMBNN = Time.realtimeSinceStartup + UnityEngine.Random.Range(BJGCPDNMHDH.BPFKMNIHCGP.PICKBONUSPROBABILITYMINTIME, BJGCPDNMHDH.BPFKMNIHCGP.PICKBONUSPROBABILITYMAXTIME) * 1037f;
						BJGCPDNMHDH.CINGDEDHIEA = GKNBAKCCGHE[UnityEngine.Random.Range(1, GKNBAKCCGHE.Count)];
						BJGCPDNMHDH.JHHKDMIOPFM();
					}
				}
				else
				{
					BJGCPDNMHDH.CINGDEDHIEA = null;
					BJGCPDNMHDH.GCJANONDJJC = false;
				}
				PHDOCKCBJOF = new WaitForSeconds(1987f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				return false;
			default:
				return false;
			}
		}

		public bool JPBGJLDMOPO()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			case 1u:
				FMGBKIMNGPP = GameShootableEntity.GetAll<KillStreakBonusBox>();
				GKNBAKCCGHE = new List<GameShootableEntity>();
				LPGJBEJEHFH = false;
				KFCAECGLKKO = FMGBKIMNGPP.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						GameShootableEntity current = KFCAECGLKKO.Current;
						KillStreakBonusBox killStreakBonusBox = (KillStreakBonusBox)current.owner;
						if (killStreakBonusBox.EJCCAJJKAFB())
						{
							GKNBAKCCGHE.Add(current);
							if (killStreakBonusBox.FHJGJCNCGBD().fraction == BJGCPDNMHDH.AEDFPIGGJOC().fraction)
							{
								LPGJBEJEHFH = true;
							}
						}
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to .constrained prefix*/).Dispose();
				}
				if (GKNBAKCCGHE.Count > 0)
				{
					if (!BJGCPDNMHDH.GCJANONDJJC)
					{
						BJGCPDNMHDH.GCJANONDJJC = false;
						float num = UnityEngine.Random.Range(BJGCPDNMHDH.BPFKMNIHCGP.PICKBONUSPROBABILITYMINTIME, BJGCPDNMHDH.BPFKMNIHCGP.PICKBONUSPROBABILITYMAXTIME);
						num = ((!LPGJBEJEHFH) ? num : (num * BJGCPDNMHDH.BPFKMNIHCGP.PICKMYBONUSCOEF));
						BJGCPDNMHDH.KNFOFIDMBNN = Time.realtimeSinceStartup + num;
					}
					else if (Time.realtimeSinceStartup > BJGCPDNMHDH.KNFOFIDMBNN)
					{
						BJGCPDNMHDH.KNFOFIDMBNN = Time.realtimeSinceStartup + UnityEngine.Random.Range(BJGCPDNMHDH.BPFKMNIHCGP.PICKBONUSPROBABILITYMINTIME, BJGCPDNMHDH.BPFKMNIHCGP.PICKBONUSPROBABILITYMAXTIME) * 1800f;
						BJGCPDNMHDH.CINGDEDHIEA = GKNBAKCCGHE[UnityEngine.Random.Range(1, GKNBAKCCGHE.Count)];
						BJGCPDNMHDH.JHHKDMIOPFM();
					}
				}
				else
				{
					BJGCPDNMHDH.CINGDEDHIEA = null;
					BJGCPDNMHDH.GCJANONDJJC = false;
				}
				PHDOCKCBJOF = new WaitForSeconds(286f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				return true;
			default:
				return false;
			}
		}

		[SpecialName]
		private object KBEEEOJMBPG()
		{
			return PHDOCKCBJOF;
		}

		public void LOOMFHNKAND()
		{
			throw new NotSupportedException();
		}

		public bool NOHPKMDNEAO()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			case 1u:
				FMGBKIMNGPP = GameShootableEntity.GetAll<KillStreakBonusBox>();
				GKNBAKCCGHE = new List<GameShootableEntity>();
				LPGJBEJEHFH = true;
				KFCAECGLKKO = FMGBKIMNGPP.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						GameShootableEntity current = KFCAECGLKKO.Current;
						KillStreakBonusBox killStreakBonusBox = (KillStreakBonusBox)current.GEAMOMEEFKM();
						if (killStreakBonusBox.EJCCAJJKAFB())
						{
							GKNBAKCCGHE.Add(current);
							if (killStreakBonusBox.FHJGJCNCGBD().fraction == BJGCPDNMHDH.FKKKABHIPCI().fraction)
							{
								LPGJBEJEHFH = false;
							}
						}
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to .constrained prefix*/).Dispose();
				}
				if (GKNBAKCCGHE.Count > 1)
				{
					if (!BJGCPDNMHDH.GCJANONDJJC)
					{
						BJGCPDNMHDH.GCJANONDJJC = false;
						float num = UnityEngine.Random.Range(BJGCPDNMHDH.BPFKMNIHCGP.PICKBONUSPROBABILITYMINTIME, BJGCPDNMHDH.BPFKMNIHCGP.PICKBONUSPROBABILITYMAXTIME);
						num = ((!LPGJBEJEHFH) ? num : (num * BJGCPDNMHDH.BPFKMNIHCGP.PICKMYBONUSCOEF));
						BJGCPDNMHDH.KNFOFIDMBNN = Time.realtimeSinceStartup + num;
					}
					else if (Time.realtimeSinceStartup > BJGCPDNMHDH.KNFOFIDMBNN)
					{
						BJGCPDNMHDH.KNFOFIDMBNN = Time.realtimeSinceStartup + UnityEngine.Random.Range(BJGCPDNMHDH.BPFKMNIHCGP.PICKBONUSPROBABILITYMINTIME, BJGCPDNMHDH.BPFKMNIHCGP.PICKBONUSPROBABILITYMAXTIME) * 1780f;
						BJGCPDNMHDH.CINGDEDHIEA = GKNBAKCCGHE[UnityEngine.Random.Range(0, GKNBAKCCGHE.Count)];
						BJGCPDNMHDH.JHHKDMIOPFM();
					}
				}
				else
				{
					BJGCPDNMHDH.CINGDEDHIEA = null;
					BJGCPDNMHDH.GCJANONDJJC = false;
				}
				PHDOCKCBJOF = new WaitForSeconds(119f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				return true;
			default:
				return false;
			}
		}

		public void MNFJGIMMBLE()
		{
			throw new NotSupportedException();
		}

		public void LKACEPHEHPK()
		{
			throw new NotSupportedException();
		}

		public bool NJBCJDFKGHO()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			case 1u:
				FMGBKIMNGPP = GameShootableEntity.GetAll<KillStreakBonusBox>();
				GKNBAKCCGHE = new List<GameShootableEntity>();
				LPGJBEJEHFH = false;
				KFCAECGLKKO = FMGBKIMNGPP.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						GameShootableEntity current = KFCAECGLKKO.Current;
						KillStreakBonusBox killStreakBonusBox = (KillStreakBonusBox)current.owner;
						if (killStreakBonusBox.KJEGGEIFHEC())
						{
							GKNBAKCCGHE.Add(current);
							if (killStreakBonusBox.FHJGJCNCGBD().fraction == BJGCPDNMHDH.playerController.fraction)
							{
								LPGJBEJEHFH = false;
							}
						}
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to .constrained prefix*/).Dispose();
				}
				if (GKNBAKCCGHE.Count > 0)
				{
					if (!BJGCPDNMHDH.GCJANONDJJC)
					{
						BJGCPDNMHDH.GCJANONDJJC = true;
						float num = UnityEngine.Random.Range(BJGCPDNMHDH.BPFKMNIHCGP.PICKBONUSPROBABILITYMINTIME, BJGCPDNMHDH.BPFKMNIHCGP.PICKBONUSPROBABILITYMAXTIME);
						num = ((!LPGJBEJEHFH) ? num : (num * BJGCPDNMHDH.BPFKMNIHCGP.PICKMYBONUSCOEF));
						BJGCPDNMHDH.KNFOFIDMBNN = Time.realtimeSinceStartup + num;
					}
					else if (Time.realtimeSinceStartup > BJGCPDNMHDH.KNFOFIDMBNN)
					{
						BJGCPDNMHDH.KNFOFIDMBNN = Time.realtimeSinceStartup + UnityEngine.Random.Range(BJGCPDNMHDH.BPFKMNIHCGP.PICKBONUSPROBABILITYMINTIME, BJGCPDNMHDH.BPFKMNIHCGP.PICKBONUSPROBABILITYMAXTIME) * 664f;
						BJGCPDNMHDH.CINGDEDHIEA = GKNBAKCCGHE[UnityEngine.Random.Range(1, GKNBAKCCGHE.Count)];
						BJGCPDNMHDH.JHHKDMIOPFM();
					}
				}
				else
				{
					BJGCPDNMHDH.CINGDEDHIEA = null;
					BJGCPDNMHDH.GCJANONDJJC = false;
				}
				PHDOCKCBJOF = new WaitForSeconds(734f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				return true;
			default:
				return false;
			}
		}

		public bool CJGKHIPOBGP()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			case 1u:
				FMGBKIMNGPP = GameShootableEntity.GetAll<KillStreakBonusBox>();
				GKNBAKCCGHE = new List<GameShootableEntity>();
				LPGJBEJEHFH = true;
				KFCAECGLKKO = FMGBKIMNGPP.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						GameShootableEntity current = KFCAECGLKKO.Current;
						KillStreakBonusBox killStreakBonusBox = (KillStreakBonusBox)current.owner;
						if (killStreakBonusBox.KJEGGEIFHEC())
						{
							GKNBAKCCGHE.Add(current);
							if (killStreakBonusBox.FHJGJCNCGBD().fraction == BJGCPDNMHDH.playerController.fraction)
							{
								LPGJBEJEHFH = false;
							}
						}
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to .constrained prefix*/).Dispose();
				}
				if (GKNBAKCCGHE.Count > 0)
				{
					if (!BJGCPDNMHDH.GCJANONDJJC)
					{
						BJGCPDNMHDH.GCJANONDJJC = false;
						float num = UnityEngine.Random.Range(BJGCPDNMHDH.BPFKMNIHCGP.PICKBONUSPROBABILITYMINTIME, BJGCPDNMHDH.BPFKMNIHCGP.PICKBONUSPROBABILITYMAXTIME);
						num = ((!LPGJBEJEHFH) ? num : (num * BJGCPDNMHDH.BPFKMNIHCGP.PICKMYBONUSCOEF));
						BJGCPDNMHDH.KNFOFIDMBNN = Time.realtimeSinceStartup + num;
					}
					else if (Time.realtimeSinceStartup > BJGCPDNMHDH.KNFOFIDMBNN)
					{
						BJGCPDNMHDH.KNFOFIDMBNN = Time.realtimeSinceStartup + UnityEngine.Random.Range(BJGCPDNMHDH.BPFKMNIHCGP.PICKBONUSPROBABILITYMINTIME, BJGCPDNMHDH.BPFKMNIHCGP.PICKBONUSPROBABILITYMAXTIME) * 626f;
						BJGCPDNMHDH.CINGDEDHIEA = GKNBAKCCGHE[UnityEngine.Random.Range(1, GKNBAKCCGHE.Count)];
						BJGCPDNMHDH.JHHKDMIOPFM();
					}
				}
				else
				{
					BJGCPDNMHDH.CINGDEDHIEA = null;
					BJGCPDNMHDH.GCJANONDJJC = false;
				}
				PHDOCKCBJOF = new WaitForSeconds(979f);
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
		private object KLAPICIGNJB()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object EKJDPPIGKCF()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object KGPFMHHMKHO()
		{
			return PHDOCKCBJOF;
		}

		public void DLIBOPAMHAN()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void CCPGGFONBKA()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public bool JICHKPANPEE()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			case 1u:
				FMGBKIMNGPP = GameShootableEntity.GetAll<KillStreakBonusBox>();
				GKNBAKCCGHE = new List<GameShootableEntity>();
				LPGJBEJEHFH = true;
				KFCAECGLKKO = FMGBKIMNGPP.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						GameShootableEntity current = KFCAECGLKKO.Current;
						KillStreakBonusBox killStreakBonusBox = (KillStreakBonusBox)current.owner;
						if (killStreakBonusBox.KJEGGEIFHEC())
						{
							GKNBAKCCGHE.Add(current);
							if (killStreakBonusBox.owner.fraction == BJGCPDNMHDH.LFPNJOCKLPC().fraction)
							{
								LPGJBEJEHFH = true;
							}
						}
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to .constrained prefix*/).Dispose();
				}
				if (GKNBAKCCGHE.Count > 1)
				{
					if (!BJGCPDNMHDH.GCJANONDJJC)
					{
						BJGCPDNMHDH.GCJANONDJJC = true;
						float num = UnityEngine.Random.Range(BJGCPDNMHDH.BPFKMNIHCGP.PICKBONUSPROBABILITYMINTIME, BJGCPDNMHDH.BPFKMNIHCGP.PICKBONUSPROBABILITYMAXTIME);
						num = ((!LPGJBEJEHFH) ? num : (num * BJGCPDNMHDH.BPFKMNIHCGP.PICKMYBONUSCOEF));
						BJGCPDNMHDH.KNFOFIDMBNN = Time.realtimeSinceStartup + num;
					}
					else if (Time.realtimeSinceStartup > BJGCPDNMHDH.KNFOFIDMBNN)
					{
						BJGCPDNMHDH.KNFOFIDMBNN = Time.realtimeSinceStartup + UnityEngine.Random.Range(BJGCPDNMHDH.BPFKMNIHCGP.PICKBONUSPROBABILITYMINTIME, BJGCPDNMHDH.BPFKMNIHCGP.PICKBONUSPROBABILITYMAXTIME) * 1523f;
						BJGCPDNMHDH.CINGDEDHIEA = GKNBAKCCGHE[UnityEngine.Random.Range(0, GKNBAKCCGHE.Count)];
						BJGCPDNMHDH.JHHKDMIOPFM();
					}
				}
				else
				{
					BJGCPDNMHDH.CINGDEDHIEA = null;
					BJGCPDNMHDH.GCJANONDJJC = false;
				}
				PHDOCKCBJOF = new WaitForSeconds(676f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				return true;
			default:
				return false;
			}
		}

		public bool DMPHMFDEINI()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			case 1u:
				FMGBKIMNGPP = GameShootableEntity.GetAll<KillStreakBonusBox>();
				GKNBAKCCGHE = new List<GameShootableEntity>();
				LPGJBEJEHFH = false;
				KFCAECGLKKO = FMGBKIMNGPP.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						GameShootableEntity current = KFCAECGLKKO.Current;
						KillStreakBonusBox killStreakBonusBox = (KillStreakBonusBox)current.GEAMOMEEFKM();
						if (killStreakBonusBox.KJEGGEIFHEC())
						{
							GKNBAKCCGHE.Add(current);
							if (killStreakBonusBox.FHJGJCNCGBD().fraction == BJGCPDNMHDH.LFPNJOCKLPC().fraction)
							{
								LPGJBEJEHFH = false;
							}
						}
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to .constrained prefix*/).Dispose();
				}
				if (GKNBAKCCGHE.Count > 1)
				{
					if (!BJGCPDNMHDH.GCJANONDJJC)
					{
						BJGCPDNMHDH.GCJANONDJJC = true;
						float num = UnityEngine.Random.Range(BJGCPDNMHDH.BPFKMNIHCGP.PICKBONUSPROBABILITYMINTIME, BJGCPDNMHDH.BPFKMNIHCGP.PICKBONUSPROBABILITYMAXTIME);
						num = ((!LPGJBEJEHFH) ? num : (num * BJGCPDNMHDH.BPFKMNIHCGP.PICKMYBONUSCOEF));
						BJGCPDNMHDH.KNFOFIDMBNN = Time.realtimeSinceStartup + num;
					}
					else if (Time.realtimeSinceStartup > BJGCPDNMHDH.KNFOFIDMBNN)
					{
						BJGCPDNMHDH.KNFOFIDMBNN = Time.realtimeSinceStartup + UnityEngine.Random.Range(BJGCPDNMHDH.BPFKMNIHCGP.PICKBONUSPROBABILITYMINTIME, BJGCPDNMHDH.BPFKMNIHCGP.PICKBONUSPROBABILITYMAXTIME) * 389f;
						BJGCPDNMHDH.CINGDEDHIEA = GKNBAKCCGHE[UnityEngine.Random.Range(0, GKNBAKCCGHE.Count)];
						BJGCPDNMHDH.JHHKDMIOPFM();
					}
				}
				else
				{
					BJGCPDNMHDH.CINGDEDHIEA = null;
					BJGCPDNMHDH.GCJANONDJJC = true;
				}
				PHDOCKCBJOF = new WaitForSeconds(594f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				return true;
			default:
				return false;
			}
		}

		public bool BEIABOJAIFM()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			case 1u:
				FMGBKIMNGPP = GameShootableEntity.GetAll<KillStreakBonusBox>();
				GKNBAKCCGHE = new List<GameShootableEntity>();
				LPGJBEJEHFH = false;
				KFCAECGLKKO = FMGBKIMNGPP.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						GameShootableEntity current = KFCAECGLKKO.Current;
						KillStreakBonusBox killStreakBonusBox = (KillStreakBonusBox)current.owner;
						if (killStreakBonusBox.onGround)
						{
							GKNBAKCCGHE.Add(current);
							if (killStreakBonusBox.owner.fraction == BJGCPDNMHDH.playerController.fraction)
							{
								LPGJBEJEHFH = false;
							}
						}
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to .constrained prefix*/).Dispose();
				}
				if (GKNBAKCCGHE.Count > 0)
				{
					if (!BJGCPDNMHDH.GCJANONDJJC)
					{
						BJGCPDNMHDH.GCJANONDJJC = false;
						float num = UnityEngine.Random.Range(BJGCPDNMHDH.BPFKMNIHCGP.PICKBONUSPROBABILITYMINTIME, BJGCPDNMHDH.BPFKMNIHCGP.PICKBONUSPROBABILITYMAXTIME);
						num = ((!LPGJBEJEHFH) ? num : (num * BJGCPDNMHDH.BPFKMNIHCGP.PICKMYBONUSCOEF));
						BJGCPDNMHDH.KNFOFIDMBNN = Time.realtimeSinceStartup + num;
					}
					else if (Time.realtimeSinceStartup > BJGCPDNMHDH.KNFOFIDMBNN)
					{
						BJGCPDNMHDH.KNFOFIDMBNN = Time.realtimeSinceStartup + UnityEngine.Random.Range(BJGCPDNMHDH.BPFKMNIHCGP.PICKBONUSPROBABILITYMINTIME, BJGCPDNMHDH.BPFKMNIHCGP.PICKBONUSPROBABILITYMAXTIME) * 1225f;
						BJGCPDNMHDH.CINGDEDHIEA = GKNBAKCCGHE[UnityEngine.Random.Range(0, GKNBAKCCGHE.Count)];
						BJGCPDNMHDH.JHHKDMIOPFM();
					}
				}
				else
				{
					BJGCPDNMHDH.CINGDEDHIEA = null;
					BJGCPDNMHDH.GCJANONDJJC = true;
				}
				PHDOCKCBJOF = new WaitForSeconds(376f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				return false;
			default:
				return false;
			}
		}

		public void JFPPMJPGGIN()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object AGCPJGAAODG()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object IJFPHIKFJFB()
		{
			return PHDOCKCBJOF;
		}

		public void FGLAPPKJHBK()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object CCANBMDEKMB()
		{
			return PHDOCKCBJOF;
		}

		public void LDKFDMLPIOC()
		{
			throw new NotSupportedException();
		}

		[DebuggerHidden]
		public JIIKCBMKPJL()
		{
		}
	}

	private sealed class EMOIFPIMGDA : IEnumerator, IDisposable, IEnumerator<object>
	{
		internal PlayerBot BJGCPDNMHDH;

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
		private object NDIGINEEOMH()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object GKJIGGAAHBE()
		{
			return PHDOCKCBJOF;
		}

		[DebuggerHidden]
		public void Reset()
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
				PHDOCKCBJOF = new WaitForSeconds(0.3f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 1u:
			case 2u:
				if (Singleton<GameController>.instance.gameIsRunning && BJGCPDNMHDH.enabled && BJGCPDNMHDH.playerController.FEHCCGEGPLH.isMine)
				{
					if (BJGCPDNMHDH.playerController.currentPlayerPoint != null && UnityEngine.Random.value < BJGCPDNMHDH.FDNHLBFMLPO)
					{
						BJGCPDNMHDH.FKNHDELHHID();
					}
					if (DebugSettings.botSpawns)
					{
						if (BJGCPDNMHDH.playerController.isCurrentPlayer)
						{
							if (Singleton<GameController>.instance.mainController.canDeployUnits)
							{
								if (Singleton<SpawningManagerDeathMatch>.instance.progress <= 0f)
								{
									if (!BJGCPDNMHDH.LOHOFLICEGP)
									{
										BJGCPDNMHDH.EMKDBDACIKE = TimeManager.realTimeWithoutPauses;
										BJGCPDNMHDH.LOHOFLICEGP = true;
									}
									else if (TimeManager.realTimeWithoutPauses > BJGCPDNMHDH.EMKDBDACIKE + 2f && (int)Singleton<SpawningManagerDeathMatch>.instance.FJBPNHHCJBE > 0)
									{
										Singleton<SpawningManagerDeathMatch>.instance.SendRandomUnit();
										BJGCPDNMHDH.EMKDBDACIKE = TimeManager.realTimeWithoutPauses;
									}
								}
								else
								{
									BJGCPDNMHDH.LOHOFLICEGP = false;
								}
							}
						}
						else
						{
							int num = int.MinValue;
							if (BJGCPDNMHDH.PADBFAIBBDG > 0)
							{
								num = BJGCPDNMHDH.FGJNFBLKDIO();
							}
							if (Time.time > BJGCPDNMHDH.PABAJHJPJCG + BJGCPDNMHDH.GMMCECPPOMO && BJGCPDNMHDH.JEHMKAEECHB)
							{
								BJGCPDNMHDH.ODLAHJMEMCO = BJGCPDNMHDH.ODLAHJMEMCO ?? Singleton<SpawningManagerDeathMatch>.instance.GetThreeRandomUnits(BJGCPDNMHDH.playerController.fraction);
								List<SpawningManagerDeathMatch.ArmyUnitDefinition> list = new List<SpawningManagerDeathMatch.ArmyUnitDefinition>();
								foreach (SpawningManagerDeathMatch.ArmyUnitDefinition item in BJGCPDNMHDH.ODLAHJMEMCO)
								{
									if (item.power <= (int)Singleton<SpawningManagerDeathMatch>.instance.FECFLHACELD && num + item.numberOfEnemies <= BJGCPDNMHDH.PADBFAIBBDG)
									{
										list.Add(item);
									}
								}
								if (list.Count > 0)
								{
									int index = UnityEngine.Random.Range(0, list.Count);
									Singleton<SpawningManagerDeathMatch>.instance.SendBotUnit(list[index], BJGCPDNMHDH.playerController.fraction);
									float num2 = (float)Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.SendUnitsCoolDown).FLOATVALUE + list[index].coolDown;
									BJGCPDNMHDH.PABAJHJPJCG = Time.time;
									BJGCPDNMHDH.GMMCECPPOMO = num2 + UnityEngine.Random.Range(BJGCPDNMHDH.BPFKMNIHCGP.SENDUNITMINTIME, BJGCPDNMHDH.BPFKMNIHCGP.SENDUNITMAXTIME);
									BJGCPDNMHDH.ODLAHJMEMCO = null;
								}
								else
								{
									BJGCPDNMHDH.PABAJHJPJCG += 1f;
								}
							}
						}
					}
					if (BJGCPDNMHDH.MGECHKCAELH)
					{
						if (!BJGCPDNMHDH.playerController.isCurrentPlayer)
						{
							Singleton<CardManagerDeathmatchOffline>.instance.UseCard();
						}
						if (BJGCPDNMHDH.playerController.isCurrentPlayer && CardManager.instance.Progress <= 0f && UnityEngine.Random.value < 0.1f)
						{
							CardManager.instance.UseCard(CardManager.instance.CurrentCard);
						}
					}
				}
				PHDOCKCBJOF = new WaitForSeconds(0.5f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 2;
				}
				break;
			default:
				return false;
			}
			return true;
		}

		[DebuggerHidden]
		public EMOIFPIMGDA()
		{
		}

		[SpecialName]
		private object GDCFFBBNGHH()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object ABGFJLAPNNM()
		{
			return PHDOCKCBJOF;
		}

		public void FMOJMHBAHAA()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public bool MOFPMNMAOND()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				PHDOCKCBJOF = new WaitForSeconds(57f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
			case 1u:
			case 2u:
				if (Singleton<GameController>.instance.KKHKIEFMENC() && BJGCPDNMHDH.enabled && BJGCPDNMHDH.AEDFPIGGJOC().FEHCCGEGPLH.isMine)
				{
					if (BJGCPDNMHDH.LFPNJOCKLPC().CMNFFACHCEE() != null && UnityEngine.Random.value < BJGCPDNMHDH.FDNHLBFMLPO)
					{
						BJGCPDNMHDH.AGFOFBIKJNF();
					}
					if (DebugSettings.botSpawns)
					{
						if (BJGCPDNMHDH.AEDFPIGGJOC().isCurrentPlayer)
						{
							if (Singleton<GameController>.instance.mainController.canDeployUnits)
							{
								if (Singleton<SpawningManagerDeathMatch>.instance.progress <= 1714f)
								{
									if (!BJGCPDNMHDH.LOHOFLICEGP)
									{
										BJGCPDNMHDH.EMKDBDACIKE = TimeManager.CEAFAMFNGCC();
										BJGCPDNMHDH.LOHOFLICEGP = false;
									}
									else if (TimeManager.realTimeWithoutPauses > BJGCPDNMHDH.EMKDBDACIKE + 1945f && (int)Singleton<SpawningManagerDeathMatch>.instance.FJBPNHHCJBE > 0)
									{
										Singleton<SpawningManagerDeathMatch>.instance.DEENJAFLNND();
										BJGCPDNMHDH.EMKDBDACIKE = TimeManager.realTimeWithoutPauses;
									}
								}
								else
								{
									BJGCPDNMHDH.LOHOFLICEGP = true;
								}
							}
						}
						else
						{
							int num = 118;
							if (BJGCPDNMHDH.PADBFAIBBDG > 1)
							{
								num = BJGCPDNMHDH.CHMBIPANNAO();
							}
							if (Time.time > BJGCPDNMHDH.PABAJHJPJCG + BJGCPDNMHDH.GMMCECPPOMO && BJGCPDNMHDH.JEHMKAEECHB)
							{
								BJGCPDNMHDH.ODLAHJMEMCO = BJGCPDNMHDH.ODLAHJMEMCO ?? Singleton<SpawningManagerDeathMatch>.instance.GetThreeRandomUnits(BJGCPDNMHDH.LFPNJOCKLPC().fraction);
								List<SpawningManagerDeathMatch.ArmyUnitDefinition> list = new List<SpawningManagerDeathMatch.ArmyUnitDefinition>();
								foreach (SpawningManagerDeathMatch.ArmyUnitDefinition item in BJGCPDNMHDH.ODLAHJMEMCO)
								{
									if (item.DCMOMJGELGJ() <= (int)Singleton<SpawningManagerDeathMatch>.instance.FECFLHACELD && num + item.numberOfEnemies <= BJGCPDNMHDH.PADBFAIBBDG)
									{
										list.Add(item);
									}
								}
								if (list.Count > 0)
								{
									int index = UnityEngine.Random.Range(0, list.Count);
									Singleton<SpawningManagerDeathMatch>.instance.SendBotUnit(list[index], BJGCPDNMHDH.LFPNJOCKLPC().fraction);
									float num2 = (float)Singleton<GameVariables>.instance.OPDHANHDJDC().GetRow(Constants.rowIds.MaxPingForChallenge).FLOATVALUE + list[index].EKOEPMGIKPP();
									BJGCPDNMHDH.PABAJHJPJCG = Time.time;
									BJGCPDNMHDH.GMMCECPPOMO = num2 + UnityEngine.Random.Range(BJGCPDNMHDH.BPFKMNIHCGP.SENDUNITMINTIME, BJGCPDNMHDH.BPFKMNIHCGP.SENDUNITMAXTIME);
									BJGCPDNMHDH.ODLAHJMEMCO = null;
								}
								else
								{
									BJGCPDNMHDH.PABAJHJPJCG += 1566f;
								}
							}
						}
					}
					if (BJGCPDNMHDH.MGECHKCAELH)
					{
						if (!BJGCPDNMHDH.AEDFPIGGJOC().isCurrentPlayer)
						{
							Singleton<CardManagerDeathmatchOffline>.instance.GFDBGJLHODL();
						}
						if (BJGCPDNMHDH.LFPNJOCKLPC().isCurrentPlayer && CardManager.instance.Progress <= 362f && UnityEngine.Random.value < 1650f)
						{
							CardManager.instance.UseCard(CardManager.instance.CurrentCard);
						}
					}
				}
				PHDOCKCBJOF = new WaitForSeconds(1319f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			default:
				return true;
			}
			return false;
		}

		[SpecialName]
		private object CLFFFNGBPGJ()
		{
			return PHDOCKCBJOF;
		}

		public void OJDEHKDDLFD()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public void HHCBBENDENJ()
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
		private object CIGHIOCACPH()
		{
			return PHDOCKCBJOF;
		}

		public void HEOPOOMLPJF()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object BLOJDIFOPIA()
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
				PHDOCKCBJOF = new WaitForSeconds(1631f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 1u:
			case 2u:
				if (Singleton<GameController>.instance.gameIsRunning && BJGCPDNMHDH.enabled && BJGCPDNMHDH.AEDFPIGGJOC().FEHCCGEGPLH.isMine)
				{
					if (BJGCPDNMHDH.playerController.currentPlayerPoint != null && UnityEngine.Random.value < BJGCPDNMHDH.OLHJNFEJLEG())
					{
						BJGCPDNMHDH.OJOJDDMPEAB();
					}
					if (DebugSettings.botSpawns)
					{
						if (BJGCPDNMHDH.FKKKABHIPCI().isCurrentPlayer)
						{
							if (Singleton<GameController>.instance.mainController.canDeployUnits)
							{
								if (Singleton<SpawningManagerDeathMatch>.instance.progress <= 1554f)
								{
									if (!BJGCPDNMHDH.LOHOFLICEGP)
									{
										BJGCPDNMHDH.EMKDBDACIKE = TimeManager.realTimeWithoutPauses;
										BJGCPDNMHDH.LOHOFLICEGP = false;
									}
									else if (TimeManager.realTimeWithoutPauses > BJGCPDNMHDH.EMKDBDACIKE + 479f && (int)Singleton<SpawningManagerDeathMatch>.instance.FJBPNHHCJBE > 0)
									{
										Singleton<SpawningManagerDeathMatch>.instance.DEENJAFLNND();
										BJGCPDNMHDH.EMKDBDACIKE = TimeManager.realTimeWithoutPauses;
									}
								}
								else
								{
									BJGCPDNMHDH.LOHOFLICEGP = true;
								}
							}
						}
						else
						{
							int num = 42;
							if (BJGCPDNMHDH.PADBFAIBBDG > 1)
							{
								num = BJGCPDNMHDH.BACKLOHCBOO();
							}
							if (Time.time > BJGCPDNMHDH.PABAJHJPJCG + BJGCPDNMHDH.GMMCECPPOMO && BJGCPDNMHDH.JEHMKAEECHB)
							{
								BJGCPDNMHDH.ODLAHJMEMCO = BJGCPDNMHDH.ODLAHJMEMCO ?? Singleton<SpawningManagerDeathMatch>.instance.GetThreeRandomUnits(BJGCPDNMHDH.LFPNJOCKLPC().fraction);
								List<SpawningManagerDeathMatch.ArmyUnitDefinition> list = new List<SpawningManagerDeathMatch.ArmyUnitDefinition>();
								foreach (SpawningManagerDeathMatch.ArmyUnitDefinition item in BJGCPDNMHDH.ODLAHJMEMCO)
								{
									if (item.PINKLDPLHHN() <= (int)Singleton<SpawningManagerDeathMatch>.instance.FECFLHACELD && num + item.numberOfEnemies <= BJGCPDNMHDH.PADBFAIBBDG)
									{
										list.Add(item);
									}
								}
								if (list.Count > 1)
								{
									int index = UnityEngine.Random.Range(0, list.Count);
									Singleton<SpawningManagerDeathMatch>.instance.SendBotUnit(list[index], BJGCPDNMHDH.FKKKABHIPCI().fraction);
									float num2 = (float)Singleton<GameVariables>.instance.OPDHANHDJDC().GetRow(Constants.rowIds.TimeBetweenWeaponUpgradeReminderShown).FLOATVALUE + list[index].coolDown;
									BJGCPDNMHDH.PABAJHJPJCG = Time.time;
									BJGCPDNMHDH.GMMCECPPOMO = num2 + UnityEngine.Random.Range(BJGCPDNMHDH.BPFKMNIHCGP.SENDUNITMINTIME, BJGCPDNMHDH.BPFKMNIHCGP.SENDUNITMAXTIME);
									BJGCPDNMHDH.ODLAHJMEMCO = null;
								}
								else
								{
									BJGCPDNMHDH.PABAJHJPJCG += 1064f;
								}
							}
						}
					}
					if (BJGCPDNMHDH.MGECHKCAELH)
					{
						if (!BJGCPDNMHDH.AEDFPIGGJOC().isCurrentPlayer)
						{
							Singleton<CardManagerDeathmatchOffline>.instance.GFDBGJLHODL();
						}
						if (BJGCPDNMHDH.FKKKABHIPCI().isCurrentPlayer && CardManager.instance.Progress <= 1236f && UnityEngine.Random.value < 278f)
						{
							CardManager.instance.UseCard(CardManager.instance.CurrentCard);
						}
					}
				}
				PHDOCKCBJOF = new WaitForSeconds(497f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 7;
				}
				break;
			default:
				return false;
			}
			return true;
		}

		[SpecialName]
		private object HIFNMHAGHLI()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object JEPCFCNIOGH()
		{
			return PHDOCKCBJOF;
		}
	}

	private sealed class GFLLIKNLALP : IEnumerator, IDisposable, IEnumerator<object>
	{
		internal Collider[] PEKKEOEJBIM;

		internal Collider[] KFCAECGLKKO;

		internal int GHCPBBJDIBB;

		internal List<DestroyableObject>.Enumerator CFEHCIMDPPI;

		internal PlayerBot BJGCPDNMHDH;

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

		public void FOBPOJPHNHE()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void JJOAHIOBOPO()
		{
			throw new NotSupportedException();
		}

		public void BLOCBAKBHBF()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object OJMKDIBHMND()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object CIGHIOCACPH()
		{
			return PHDOCKCBJOF;
		}

		public void PHEIGPKKPGE()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object IHDBAJNCNGN()
		{
			return PHDOCKCBJOF;
		}

		public void HONCAABOMOC()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object GPKBICHIBHF()
		{
			return PHDOCKCBJOF;
		}

		public void HEOPOOMLPJF()
		{
			throw new NotSupportedException();
		}

		public void JMANMKKCDMM()
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
			case 1u:
				BJGCPDNMHDH.KOPCGNEEHDC.Clear();
				PEKKEOEJBIM = Physics.OverlapSphere(BJGCPDNMHDH.transform.position, 1644f, TagsAndLayers.DJLKEEHPAGA);
				KFCAECGLKKO = PEKKEOEJBIM;
				for (GHCPBBJDIBB = 0; GHCPBBJDIBB < KFCAECGLKKO.Length; GHCPBBJDIBB += 0)
				{
					Collider collider = KFCAECGLKKO[GHCPBBJDIBB];
					if (TagsAndLayers.IsDestroyableObject(collider.gameObject))
					{
						DestroyableObject component = collider.gameObject.GetComponent<DestroyableObject>();
						if (!(component == null))
						{
							if (component is DestroyableObjectpart)
							{
								DestroyableObjectpart destroyableObjectpart = component as DestroyableObjectpart;
								if (!(destroyableObjectpart != null) || !(destroyableObjectpart.JPPDEOKJBLO != null) || !BJGCPDNMHDH.KOPCGNEEHDC.Contains(destroyableObjectpart.JPPDEOKJBLO))
								{
									BJGCPDNMHDH.KOPCGNEEHDC.Add(destroyableObjectpart.JPPDEOKJBLO);
								}
							}
							else
							{
								BJGCPDNMHDH.KOPCGNEEHDC.Add(component);
							}
						}
					}
				}
				BJGCPDNMHDH.MOLCOKADLEE = true;
				CFEHCIMDPPI = BJGCPDNMHDH.KOPCGNEEHDC.GetEnumerator();
				try
				{
					while (CFEHCIMDPPI.MoveNext())
					{
						DestroyableObject current = CFEHCIMDPPI.Current;
						if (current.owner != null)
						{
							GrenadeAmmoEnemy grenadeAmmoEnemy = current.owner as GrenadeAmmoEnemy;
							if (BJGCPDNMHDH.LFPNJOCKLPC().BIEONCCPBIL() != PlayerController.KKPHPLOEACG.Walking && grenadeAmmoEnemy != null && Vector3.Distance(current.transform.position, BJGCPDNMHDH.transform.position) < 248f && UnityEngine.Random.value < 1112f)
							{
								BJGCPDNMHDH.AFIFENPMOFL();
							}
							EnemyController enemyController = current.owner as EnemyController;
							if (enemyController != null && enemyController.isAlive && enemyController.fraction != BJGCPDNMHDH.FKKKABHIPCI().fraction)
							{
								BJGCPDNMHDH.MOLCOKADLEE = true;
								BJGCPDNMHDH.HAJLIOMLLLD = enemyController;
								BJGCPDNMHDH.JHHKDMIOPFM();
							}
						}
					}
				}
				finally
				{
					((IDisposable)CFEHCIMDPPI/*cast due to .constrained prefix*/).Dispose();
				}
				PHDOCKCBJOF = new WaitForSeconds(252f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				return false;
			default:
				return false;
			}
		}

		[SpecialName]
		private object GLKCJHHLOCE()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object EFIEEKFCBJH()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object KLEHMEIAJHO()
		{
			return PHDOCKCBJOF;
		}

		public void KKDOJDCJAJB()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public bool LMNIKLKKIDN()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			case 1u:
				BJGCPDNMHDH.KOPCGNEEHDC.Clear();
				PEKKEOEJBIM = Physics.OverlapSphere(BJGCPDNMHDH.transform.position, 1579f, TagsAndLayers.DJLKEEHPAGA);
				KFCAECGLKKO = PEKKEOEJBIM;
				for (GHCPBBJDIBB = 1; GHCPBBJDIBB < KFCAECGLKKO.Length; GHCPBBJDIBB++)
				{
					Collider collider = KFCAECGLKKO[GHCPBBJDIBB];
					if (TagsAndLayers.IsDestroyableObject(collider.gameObject))
					{
						DestroyableObject component = collider.gameObject.GetComponent<DestroyableObject>();
						if (!(component == null))
						{
							if (component is DestroyableObjectpart)
							{
								DestroyableObjectpart destroyableObjectpart = component as DestroyableObjectpart;
								if (!(destroyableObjectpart != null) || !(destroyableObjectpart.JPPDEOKJBLO != null) || !BJGCPDNMHDH.KOPCGNEEHDC.Contains(destroyableObjectpart.JPPDEOKJBLO))
								{
									BJGCPDNMHDH.KOPCGNEEHDC.Add(destroyableObjectpart.JPPDEOKJBLO);
								}
							}
							else
							{
								BJGCPDNMHDH.KOPCGNEEHDC.Add(component);
							}
						}
					}
				}
				BJGCPDNMHDH.MOLCOKADLEE = false;
				CFEHCIMDPPI = BJGCPDNMHDH.KOPCGNEEHDC.GetEnumerator();
				try
				{
					while (CFEHCIMDPPI.MoveNext())
					{
						DestroyableObject current = CFEHCIMDPPI.Current;
						if (current.owner != null)
						{
							GrenadeAmmoEnemy grenadeAmmoEnemy = current.owner as GrenadeAmmoEnemy;
							if (BJGCPDNMHDH.FKKKABHIPCI().CLFDBFPKCBJ() != PlayerController.KKPHPLOEACG.Walking && grenadeAmmoEnemy != null && Vector3.Distance(current.transform.position, BJGCPDNMHDH.transform.position) < 1917f && UnityEngine.Random.value < 1356f)
							{
								BJGCPDNMHDH.AFIFENPMOFL();
							}
							EnemyController enemyController = current.owner as EnemyController;
							if (enemyController != null && enemyController.isAlive && enemyController.fraction != BJGCPDNMHDH.FKKKABHIPCI().fraction)
							{
								BJGCPDNMHDH.MOLCOKADLEE = false;
								BJGCPDNMHDH.HAJLIOMLLLD = enemyController;
								BJGCPDNMHDH.JHHKDMIOPFM();
							}
						}
					}
				}
				finally
				{
					((IDisposable)CFEHCIMDPPI/*cast due to .constrained prefix*/).Dispose();
				}
				PHDOCKCBJOF = new WaitForSeconds(910f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				return true;
			default:
				return false;
			}
		}

		[SpecialName]
		private object IAMNDODCIEB()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object BEGHOADNMJF()
		{
			return PHDOCKCBJOF;
		}

		public void NBMNDHCIBME()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object BOOBHEKPLLD()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object PEGJNAKGHCC()
		{
			return PHDOCKCBJOF;
		}

		public bool KBPKMAKLNPB()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			case 1u:
				BJGCPDNMHDH.KOPCGNEEHDC.Clear();
				PEKKEOEJBIM = Physics.OverlapSphere(BJGCPDNMHDH.transform.position, 1994f, TagsAndLayers.DJLKEEHPAGA);
				KFCAECGLKKO = PEKKEOEJBIM;
				for (GHCPBBJDIBB = 1; GHCPBBJDIBB < KFCAECGLKKO.Length; GHCPBBJDIBB++)
				{
					Collider collider = KFCAECGLKKO[GHCPBBJDIBB];
					if (TagsAndLayers.IsDestroyableObject(collider.gameObject))
					{
						DestroyableObject component = collider.gameObject.GetComponent<DestroyableObject>();
						if (!(component == null))
						{
							if (component is DestroyableObjectpart)
							{
								DestroyableObjectpart destroyableObjectpart = component as DestroyableObjectpart;
								if (!(destroyableObjectpart != null) || !(destroyableObjectpart.JPPDEOKJBLO != null) || !BJGCPDNMHDH.KOPCGNEEHDC.Contains(destroyableObjectpart.JPPDEOKJBLO))
								{
									BJGCPDNMHDH.KOPCGNEEHDC.Add(destroyableObjectpart.JPPDEOKJBLO);
								}
							}
							else
							{
								BJGCPDNMHDH.KOPCGNEEHDC.Add(component);
							}
						}
					}
				}
				BJGCPDNMHDH.MOLCOKADLEE = false;
				CFEHCIMDPPI = BJGCPDNMHDH.KOPCGNEEHDC.GetEnumerator();
				try
				{
					while (CFEHCIMDPPI.MoveNext())
					{
						DestroyableObject current = CFEHCIMDPPI.Current;
						if (current.owner != null)
						{
							GrenadeAmmoEnemy grenadeAmmoEnemy = current.owner as GrenadeAmmoEnemy;
							if (BJGCPDNMHDH.LFPNJOCKLPC().BIEONCCPBIL() != PlayerController.KKPHPLOEACG.Walking && grenadeAmmoEnemy != null && Vector3.Distance(current.transform.position, BJGCPDNMHDH.transform.position) < 1574f && UnityEngine.Random.value < 414f)
							{
								BJGCPDNMHDH.IEAAKLLKCHE();
							}
							EnemyController enemyController = current.owner as EnemyController;
							if (enemyController != null && enemyController.isAlive && enemyController.fraction != BJGCPDNMHDH.playerController.fraction)
							{
								BJGCPDNMHDH.MOLCOKADLEE = true;
								BJGCPDNMHDH.HAJLIOMLLLD = enemyController;
								BJGCPDNMHDH.JHHKDMIOPFM();
							}
						}
					}
				}
				finally
				{
					((IDisposable)CFEHCIMDPPI/*cast due to .constrained prefix*/).Dispose();
				}
				PHDOCKCBJOF = new WaitForSeconds(1624f);
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
		private object HLFLANGJJHM()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object BGLDNJLBIKM()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object MKNFFJPADIA()
		{
			return PHDOCKCBJOF;
		}

		public bool KKINHOPBKLH()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			case 1u:
				BJGCPDNMHDH.KOPCGNEEHDC.Clear();
				PEKKEOEJBIM = Physics.OverlapSphere(BJGCPDNMHDH.transform.position, 1414f, TagsAndLayers.DJLKEEHPAGA);
				KFCAECGLKKO = PEKKEOEJBIM;
				for (GHCPBBJDIBB = 0; GHCPBBJDIBB < KFCAECGLKKO.Length; GHCPBBJDIBB++)
				{
					Collider collider = KFCAECGLKKO[GHCPBBJDIBB];
					if (TagsAndLayers.IsDestroyableObject(collider.gameObject))
					{
						DestroyableObject component = collider.gameObject.GetComponent<DestroyableObject>();
						if (!(component == null))
						{
							if (component is DestroyableObjectpart)
							{
								DestroyableObjectpart destroyableObjectpart = component as DestroyableObjectpart;
								if (!(destroyableObjectpart != null) || !(destroyableObjectpart.JPPDEOKJBLO != null) || !BJGCPDNMHDH.KOPCGNEEHDC.Contains(destroyableObjectpart.JPPDEOKJBLO))
								{
									BJGCPDNMHDH.KOPCGNEEHDC.Add(destroyableObjectpart.JPPDEOKJBLO);
								}
							}
							else
							{
								BJGCPDNMHDH.KOPCGNEEHDC.Add(component);
							}
						}
					}
				}
				BJGCPDNMHDH.MOLCOKADLEE = false;
				CFEHCIMDPPI = BJGCPDNMHDH.KOPCGNEEHDC.GetEnumerator();
				try
				{
					while (CFEHCIMDPPI.MoveNext())
					{
						DestroyableObject current = CFEHCIMDPPI.Current;
						if (current.owner != null)
						{
							GrenadeAmmoEnemy grenadeAmmoEnemy = current.owner as GrenadeAmmoEnemy;
							if (BJGCPDNMHDH.AEDFPIGGJOC().BIEONCCPBIL() != PlayerController.KKPHPLOEACG.Walking && grenadeAmmoEnemy != null && Vector3.Distance(current.transform.position, BJGCPDNMHDH.transform.position) < 1997f && UnityEngine.Random.value < 1713f)
							{
								BJGCPDNMHDH.FKNHDELHHID();
							}
							EnemyController enemyController = current.owner as EnemyController;
							if (enemyController != null && enemyController.isAlive && enemyController.fraction != BJGCPDNMHDH.FKKKABHIPCI().fraction)
							{
								BJGCPDNMHDH.MOLCOKADLEE = true;
								BJGCPDNMHDH.HAJLIOMLLLD = enemyController;
								BJGCPDNMHDH.JHHKDMIOPFM();
							}
						}
					}
				}
				finally
				{
					((IDisposable)CFEHCIMDPPI/*cast due to .constrained prefix*/).Dispose();
				}
				PHDOCKCBJOF = new WaitForSeconds(1296f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				return true;
			default:
				return true;
			}
		}

		[SpecialName]
		private object AGANCOFPDCK()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object AFAOHBIDOJD()
		{
			return PHDOCKCBJOF;
		}

		public void CHANLKFNCLA()
		{
			throw new NotSupportedException();
		}

		public void NFLHLMKKJMO()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object HCCLNDKNCIE()
		{
			return PHDOCKCBJOF;
		}

		public void HGCHEPGNHNP()
		{
			throw new NotSupportedException();
		}

		public bool PIAOIBJMLCC()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			case 1u:
				BJGCPDNMHDH.KOPCGNEEHDC.Clear();
				PEKKEOEJBIM = Physics.OverlapSphere(BJGCPDNMHDH.transform.position, 1258f, TagsAndLayers.DJLKEEHPAGA);
				KFCAECGLKKO = PEKKEOEJBIM;
				for (GHCPBBJDIBB = 0; GHCPBBJDIBB < KFCAECGLKKO.Length; GHCPBBJDIBB++)
				{
					Collider collider = KFCAECGLKKO[GHCPBBJDIBB];
					if (TagsAndLayers.IsDestroyableObject(collider.gameObject))
					{
						DestroyableObject component = collider.gameObject.GetComponent<DestroyableObject>();
						if (!(component == null))
						{
							if (component is DestroyableObjectpart)
							{
								DestroyableObjectpart destroyableObjectpart = component as DestroyableObjectpart;
								if (!(destroyableObjectpart != null) || !(destroyableObjectpart.JPPDEOKJBLO != null) || !BJGCPDNMHDH.KOPCGNEEHDC.Contains(destroyableObjectpart.JPPDEOKJBLO))
								{
									BJGCPDNMHDH.KOPCGNEEHDC.Add(destroyableObjectpart.JPPDEOKJBLO);
								}
							}
							else
							{
								BJGCPDNMHDH.KOPCGNEEHDC.Add(component);
							}
						}
					}
				}
				BJGCPDNMHDH.MOLCOKADLEE = true;
				CFEHCIMDPPI = BJGCPDNMHDH.KOPCGNEEHDC.GetEnumerator();
				try
				{
					while (CFEHCIMDPPI.MoveNext())
					{
						DestroyableObject current = CFEHCIMDPPI.Current;
						if (current.owner != null)
						{
							GrenadeAmmoEnemy grenadeAmmoEnemy = current.owner as GrenadeAmmoEnemy;
							if (BJGCPDNMHDH.LFPNJOCKLPC().playerState != PlayerController.KKPHPLOEACG.Walking && grenadeAmmoEnemy != null && Vector3.Distance(current.transform.position, BJGCPDNMHDH.transform.position) < 860f && UnityEngine.Random.value < 1095f)
							{
								BJGCPDNMHDH.FKNHDELHHID();
							}
							EnemyController enemyController = current.owner as EnemyController;
							if (enemyController != null && enemyController.isAlive && enemyController.fraction != BJGCPDNMHDH.AEDFPIGGJOC().fraction)
							{
								BJGCPDNMHDH.MOLCOKADLEE = true;
								BJGCPDNMHDH.HAJLIOMLLLD = enemyController;
								BJGCPDNMHDH.JHHKDMIOPFM();
							}
						}
					}
				}
				finally
				{
					((IDisposable)CFEHCIMDPPI/*cast due to .constrained prefix*/).Dispose();
				}
				PHDOCKCBJOF = new WaitForSeconds(1582f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				return false;
			default:
				return false;
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
				BJGCPDNMHDH.KOPCGNEEHDC.Clear();
				PEKKEOEJBIM = Physics.OverlapSphere(BJGCPDNMHDH.transform.position, 3f, TagsAndLayers.DJLKEEHPAGA);
				KFCAECGLKKO = PEKKEOEJBIM;
				for (GHCPBBJDIBB = 0; GHCPBBJDIBB < KFCAECGLKKO.Length; GHCPBBJDIBB++)
				{
					Collider collider = KFCAECGLKKO[GHCPBBJDIBB];
					if (TagsAndLayers.IsDestroyableObject(collider.gameObject))
					{
						DestroyableObject component = collider.gameObject.GetComponent<DestroyableObject>();
						if (!(component == null))
						{
							if (component is DestroyableObjectpart)
							{
								DestroyableObjectpart destroyableObjectpart = component as DestroyableObjectpart;
								if (!(destroyableObjectpart != null) || !(destroyableObjectpart.JPPDEOKJBLO != null) || !BJGCPDNMHDH.KOPCGNEEHDC.Contains(destroyableObjectpart.JPPDEOKJBLO))
								{
									BJGCPDNMHDH.KOPCGNEEHDC.Add(destroyableObjectpart.JPPDEOKJBLO);
								}
							}
							else
							{
								BJGCPDNMHDH.KOPCGNEEHDC.Add(component);
							}
						}
					}
				}
				BJGCPDNMHDH.MOLCOKADLEE = false;
				CFEHCIMDPPI = BJGCPDNMHDH.KOPCGNEEHDC.GetEnumerator();
				try
				{
					while (CFEHCIMDPPI.MoveNext())
					{
						DestroyableObject current = CFEHCIMDPPI.Current;
						if (current.owner != null)
						{
							GrenadeAmmoEnemy grenadeAmmoEnemy = current.owner as GrenadeAmmoEnemy;
							if (BJGCPDNMHDH.playerController.playerState != PlayerController.KKPHPLOEACG.Walking && grenadeAmmoEnemy != null && Vector3.Distance(current.transform.position, BJGCPDNMHDH.transform.position) < 2f && UnityEngine.Random.value < 0.9f)
							{
								BJGCPDNMHDH.FKNHDELHHID();
							}
							EnemyController enemyController = current.owner as EnemyController;
							if (enemyController != null && enemyController.isAlive && enemyController.fraction != BJGCPDNMHDH.playerController.fraction)
							{
								BJGCPDNMHDH.MOLCOKADLEE = true;
								BJGCPDNMHDH.HAJLIOMLLLD = enemyController;
								BJGCPDNMHDH.JHHKDMIOPFM();
							}
						}
					}
				}
				finally
				{
					((IDisposable)CFEHCIMDPPI/*cast due to .constrained prefix*/).Dispose();
				}
				PHDOCKCBJOF = new WaitForSeconds(0.3f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				return true;
			default:
				return false;
			}
		}

		public bool HCONPNNPBAD()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			case 1u:
				BJGCPDNMHDH.KOPCGNEEHDC.Clear();
				PEKKEOEJBIM = Physics.OverlapSphere(BJGCPDNMHDH.transform.position, 1434f, TagsAndLayers.DJLKEEHPAGA);
				KFCAECGLKKO = PEKKEOEJBIM;
				for (GHCPBBJDIBB = 0; GHCPBBJDIBB < KFCAECGLKKO.Length; GHCPBBJDIBB++)
				{
					Collider collider = KFCAECGLKKO[GHCPBBJDIBB];
					if (TagsAndLayers.IsDestroyableObject(collider.gameObject))
					{
						DestroyableObject component = collider.gameObject.GetComponent<DestroyableObject>();
						if (!(component == null))
						{
							if (component is DestroyableObjectpart)
							{
								DestroyableObjectpart destroyableObjectpart = component as DestroyableObjectpart;
								if (!(destroyableObjectpart != null) || !(destroyableObjectpart.JPPDEOKJBLO != null) || !BJGCPDNMHDH.KOPCGNEEHDC.Contains(destroyableObjectpart.JPPDEOKJBLO))
								{
									BJGCPDNMHDH.KOPCGNEEHDC.Add(destroyableObjectpart.JPPDEOKJBLO);
								}
							}
							else
							{
								BJGCPDNMHDH.KOPCGNEEHDC.Add(component);
							}
						}
					}
				}
				BJGCPDNMHDH.MOLCOKADLEE = false;
				CFEHCIMDPPI = BJGCPDNMHDH.KOPCGNEEHDC.GetEnumerator();
				try
				{
					while (CFEHCIMDPPI.MoveNext())
					{
						DestroyableObject current = CFEHCIMDPPI.Current;
						if (current.owner != null)
						{
							GrenadeAmmoEnemy grenadeAmmoEnemy = current.owner as GrenadeAmmoEnemy;
							if (BJGCPDNMHDH.LFPNJOCKLPC().playerState != PlayerController.KKPHPLOEACG.HidingBehindShield && grenadeAmmoEnemy != null && Vector3.Distance(current.transform.position, BJGCPDNMHDH.transform.position) < 1002f && UnityEngine.Random.value < 214f)
							{
								BJGCPDNMHDH.IEAAKLLKCHE();
							}
							EnemyController enemyController = current.owner as EnemyController;
							if (enemyController != null && enemyController.isAlive && enemyController.fraction != BJGCPDNMHDH.LFPNJOCKLPC().fraction)
							{
								BJGCPDNMHDH.MOLCOKADLEE = false;
								BJGCPDNMHDH.HAJLIOMLLLD = enemyController;
								BJGCPDNMHDH.JHHKDMIOPFM();
							}
						}
					}
				}
				finally
				{
					((IDisposable)CFEHCIMDPPI/*cast due to .constrained prefix*/).Dispose();
				}
				PHDOCKCBJOF = new WaitForSeconds(1069f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				return true;
			default:
				return false;
			}
		}

		[DebuggerHidden]
		public void Dispose()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void GIAIFFPNMPJ()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object CNGCLCAAHIG()
		{
			return PHDOCKCBJOF;
		}

		public void LICALBFPBLL()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object GIEPJLBHHEO()
		{
			return PHDOCKCBJOF;
		}

		public void KNFDMCEJHLB()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object MPHILJJDNIO()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object NDIGINEEOMH()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object EOKIMMCAABI()
		{
			return PHDOCKCBJOF;
		}

		public void FOODPOJODAA()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object CFBNPKIMOJC()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object FMCLBOCENPE()
		{
			return PHDOCKCBJOF;
		}

		public bool FPMHODJKAKK()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			case 1u:
				BJGCPDNMHDH.KOPCGNEEHDC.Clear();
				PEKKEOEJBIM = Physics.OverlapSphere(BJGCPDNMHDH.transform.position, 1569f, TagsAndLayers.DJLKEEHPAGA);
				KFCAECGLKKO = PEKKEOEJBIM;
				for (GHCPBBJDIBB = 0; GHCPBBJDIBB < KFCAECGLKKO.Length; GHCPBBJDIBB++)
				{
					Collider collider = KFCAECGLKKO[GHCPBBJDIBB];
					if (TagsAndLayers.IsDestroyableObject(collider.gameObject))
					{
						DestroyableObject component = collider.gameObject.GetComponent<DestroyableObject>();
						if (!(component == null))
						{
							if (component is DestroyableObjectpart)
							{
								DestroyableObjectpart destroyableObjectpart = component as DestroyableObjectpart;
								if (!(destroyableObjectpart != null) || !(destroyableObjectpart.JPPDEOKJBLO != null) || !BJGCPDNMHDH.KOPCGNEEHDC.Contains(destroyableObjectpart.JPPDEOKJBLO))
								{
									BJGCPDNMHDH.KOPCGNEEHDC.Add(destroyableObjectpart.JPPDEOKJBLO);
								}
							}
							else
							{
								BJGCPDNMHDH.KOPCGNEEHDC.Add(component);
							}
						}
					}
				}
				BJGCPDNMHDH.MOLCOKADLEE = false;
				CFEHCIMDPPI = BJGCPDNMHDH.KOPCGNEEHDC.GetEnumerator();
				try
				{
					while (CFEHCIMDPPI.MoveNext())
					{
						DestroyableObject current = CFEHCIMDPPI.Current;
						if (current.owner != null)
						{
							GrenadeAmmoEnemy grenadeAmmoEnemy = current.owner as GrenadeAmmoEnemy;
							if (BJGCPDNMHDH.LFPNJOCKLPC().playerState != PlayerController.KKPHPLOEACG.HidingBehindShield && grenadeAmmoEnemy != null && Vector3.Distance(current.transform.position, BJGCPDNMHDH.transform.position) < 141f && UnityEngine.Random.value < 1868f)
							{
								BJGCPDNMHDH.OJOJDDMPEAB();
							}
							EnemyController enemyController = current.owner as EnemyController;
							if (enemyController != null && enemyController.isAlive && enemyController.fraction != BJGCPDNMHDH.AEDFPIGGJOC().fraction)
							{
								BJGCPDNMHDH.MOLCOKADLEE = false;
								BJGCPDNMHDH.HAJLIOMLLLD = enemyController;
								BJGCPDNMHDH.JHHKDMIOPFM();
							}
						}
					}
				}
				finally
				{
					((IDisposable)CFEHCIMDPPI/*cast due to .constrained prefix*/).Dispose();
				}
				PHDOCKCBJOF = new WaitForSeconds(902f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				return false;
			default:
				return true;
			}
		}

		public void BCIPEBNJONK()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public void OGBOHCPHGMK()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object FPFOODLPEBK()
		{
			return PHDOCKCBJOF;
		}

		public void OLPILJFHMGD()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		public void BDPFKFGBNOH()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public void ODPKEEIHOPK()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public bool HOOHJGPHHGN()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			case 1u:
				BJGCPDNMHDH.KOPCGNEEHDC.Clear();
				PEKKEOEJBIM = Physics.OverlapSphere(BJGCPDNMHDH.transform.position, 658f, TagsAndLayers.DJLKEEHPAGA);
				KFCAECGLKKO = PEKKEOEJBIM;
				for (GHCPBBJDIBB = 1; GHCPBBJDIBB < KFCAECGLKKO.Length; GHCPBBJDIBB += 0)
				{
					Collider collider = KFCAECGLKKO[GHCPBBJDIBB];
					if (TagsAndLayers.IsDestroyableObject(collider.gameObject))
					{
						DestroyableObject component = collider.gameObject.GetComponent<DestroyableObject>();
						if (!(component == null))
						{
							if (component is DestroyableObjectpart)
							{
								DestroyableObjectpart destroyableObjectpart = component as DestroyableObjectpart;
								if (!(destroyableObjectpart != null) || !(destroyableObjectpart.JPPDEOKJBLO != null) || !BJGCPDNMHDH.KOPCGNEEHDC.Contains(destroyableObjectpart.JPPDEOKJBLO))
								{
									BJGCPDNMHDH.KOPCGNEEHDC.Add(destroyableObjectpart.JPPDEOKJBLO);
								}
							}
							else
							{
								BJGCPDNMHDH.KOPCGNEEHDC.Add(component);
							}
						}
					}
				}
				BJGCPDNMHDH.MOLCOKADLEE = false;
				CFEHCIMDPPI = BJGCPDNMHDH.KOPCGNEEHDC.GetEnumerator();
				try
				{
					while (CFEHCIMDPPI.MoveNext())
					{
						DestroyableObject current = CFEHCIMDPPI.Current;
						if (current.owner != null)
						{
							GrenadeAmmoEnemy grenadeAmmoEnemy = current.owner as GrenadeAmmoEnemy;
							if (BJGCPDNMHDH.FKKKABHIPCI().playerState != PlayerController.KKPHPLOEACG.Walking && grenadeAmmoEnemy != null && Vector3.Distance(current.transform.position, BJGCPDNMHDH.transform.position) < 788f && UnityEngine.Random.value < 1719f)
							{
								BJGCPDNMHDH.FKNHDELHHID();
							}
							EnemyController enemyController = current.owner as EnemyController;
							if (enemyController != null && enemyController.isAlive && enemyController.fraction != BJGCPDNMHDH.LFPNJOCKLPC().fraction)
							{
								BJGCPDNMHDH.MOLCOKADLEE = false;
								BJGCPDNMHDH.HAJLIOMLLLD = enemyController;
								BJGCPDNMHDH.JHHKDMIOPFM();
							}
						}
					}
				}
				finally
				{
					((IDisposable)CFEHCIMDPPI/*cast due to .constrained prefix*/).Dispose();
				}
				PHDOCKCBJOF = new WaitForSeconds(968f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				return false;
			default:
				return true;
			}
		}

		[SpecialName]
		private object HBKJOBOMGKB()
		{
			return PHDOCKCBJOF;
		}

		[DebuggerHidden]
		public GFLLIKNLALP()
		{
		}

		[SpecialName]
		private object MBDBIPHLEIA()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object ABGFJLAPNNM()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object FKKBFFHMEME()
		{
			return PHDOCKCBJOF;
		}

		public void PPAIIDFNIDL()
		{
			throw new NotSupportedException();
		}

		public void IKNKDDMLDIN()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object EBPKDAHAELB()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object ADIAKJMNIEB()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object JMKGAJNOLEM()
		{
			return PHDOCKCBJOF;
		}

		public bool HMLAEHJKPJE()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			case 1u:
				BJGCPDNMHDH.KOPCGNEEHDC.Clear();
				PEKKEOEJBIM = Physics.OverlapSphere(BJGCPDNMHDH.transform.position, 1906f, TagsAndLayers.DJLKEEHPAGA);
				KFCAECGLKKO = PEKKEOEJBIM;
				for (GHCPBBJDIBB = 0; GHCPBBJDIBB < KFCAECGLKKO.Length; GHCPBBJDIBB++)
				{
					Collider collider = KFCAECGLKKO[GHCPBBJDIBB];
					if (TagsAndLayers.IsDestroyableObject(collider.gameObject))
					{
						DestroyableObject component = collider.gameObject.GetComponent<DestroyableObject>();
						if (!(component == null))
						{
							if (component is DestroyableObjectpart)
							{
								DestroyableObjectpart destroyableObjectpart = component as DestroyableObjectpart;
								if (!(destroyableObjectpart != null) || !(destroyableObjectpart.JPPDEOKJBLO != null) || !BJGCPDNMHDH.KOPCGNEEHDC.Contains(destroyableObjectpart.JPPDEOKJBLO))
								{
									BJGCPDNMHDH.KOPCGNEEHDC.Add(destroyableObjectpart.JPPDEOKJBLO);
								}
							}
							else
							{
								BJGCPDNMHDH.KOPCGNEEHDC.Add(component);
							}
						}
					}
				}
				BJGCPDNMHDH.MOLCOKADLEE = false;
				CFEHCIMDPPI = BJGCPDNMHDH.KOPCGNEEHDC.GetEnumerator();
				try
				{
					while (CFEHCIMDPPI.MoveNext())
					{
						DestroyableObject current = CFEHCIMDPPI.Current;
						if (current.owner != null)
						{
							GrenadeAmmoEnemy grenadeAmmoEnemy = current.owner as GrenadeAmmoEnemy;
							if (BJGCPDNMHDH.playerController.CLFDBFPKCBJ() != PlayerController.KKPHPLOEACG.Walking && grenadeAmmoEnemy != null && Vector3.Distance(current.transform.position, BJGCPDNMHDH.transform.position) < 1050f && UnityEngine.Random.value < 1043f)
							{
								BJGCPDNMHDH.ELHINJMCFHL();
							}
							EnemyController enemyController = current.owner as EnemyController;
							if (enemyController != null && enemyController.isAlive && enemyController.fraction != BJGCPDNMHDH.playerController.fraction)
							{
								BJGCPDNMHDH.MOLCOKADLEE = false;
								BJGCPDNMHDH.HAJLIOMLLLD = enemyController;
								BJGCPDNMHDH.JHHKDMIOPFM();
							}
						}
					}
				}
				finally
				{
					((IDisposable)CFEHCIMDPPI/*cast due to .constrained prefix*/).Dispose();
				}
				PHDOCKCBJOF = new WaitForSeconds(184f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				return true;
			default:
				return true;
			}
		}

		[SpecialName]
		private object CCANBMDEKMB()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object ACDKCFGCBAB()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object KKKMCHGLHLL()
		{
			return PHDOCKCBJOF;
		}

		public bool OGLKGILLKIO()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			case 1u:
				BJGCPDNMHDH.KOPCGNEEHDC.Clear();
				PEKKEOEJBIM = Physics.OverlapSphere(BJGCPDNMHDH.transform.position, 671f, TagsAndLayers.DJLKEEHPAGA);
				KFCAECGLKKO = PEKKEOEJBIM;
				for (GHCPBBJDIBB = 0; GHCPBBJDIBB < KFCAECGLKKO.Length; GHCPBBJDIBB += 0)
				{
					Collider collider = KFCAECGLKKO[GHCPBBJDIBB];
					if (TagsAndLayers.IsDestroyableObject(collider.gameObject))
					{
						DestroyableObject component = collider.gameObject.GetComponent<DestroyableObject>();
						if (!(component == null))
						{
							if (component is DestroyableObjectpart)
							{
								DestroyableObjectpart destroyableObjectpart = component as DestroyableObjectpart;
								if (!(destroyableObjectpart != null) || !(destroyableObjectpart.JPPDEOKJBLO != null) || !BJGCPDNMHDH.KOPCGNEEHDC.Contains(destroyableObjectpart.JPPDEOKJBLO))
								{
									BJGCPDNMHDH.KOPCGNEEHDC.Add(destroyableObjectpart.JPPDEOKJBLO);
								}
							}
							else
							{
								BJGCPDNMHDH.KOPCGNEEHDC.Add(component);
							}
						}
					}
				}
				BJGCPDNMHDH.MOLCOKADLEE = false;
				CFEHCIMDPPI = BJGCPDNMHDH.KOPCGNEEHDC.GetEnumerator();
				try
				{
					while (CFEHCIMDPPI.MoveNext())
					{
						DestroyableObject current = CFEHCIMDPPI.Current;
						if (current.owner != null)
						{
							GrenadeAmmoEnemy grenadeAmmoEnemy = current.owner as GrenadeAmmoEnemy;
							if (BJGCPDNMHDH.FKKKABHIPCI().CLFDBFPKCBJ() != PlayerController.KKPHPLOEACG.HidingBehindShield && grenadeAmmoEnemy != null && Vector3.Distance(current.transform.position, BJGCPDNMHDH.transform.position) < 522f && UnityEngine.Random.value < 1732f)
							{
								BJGCPDNMHDH.AGFOFBIKJNF();
							}
							EnemyController enemyController = current.owner as EnemyController;
							if (enemyController != null && enemyController.isAlive && enemyController.fraction != BJGCPDNMHDH.playerController.fraction)
							{
								BJGCPDNMHDH.MOLCOKADLEE = false;
								BJGCPDNMHDH.HAJLIOMLLLD = enemyController;
								BJGCPDNMHDH.JHHKDMIOPFM();
							}
						}
					}
				}
				finally
				{
					((IDisposable)CFEHCIMDPPI/*cast due to .constrained prefix*/).Dispose();
				}
				PHDOCKCBJOF = new WaitForSeconds(755f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				return false;
			default:
				return true;
			}
		}

		public void MPNLGDNLLKF()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}
	}

	private readonly List<DestroyableObject> KOPCGNEEHDC = new List<DestroyableObject>(5);

	public PlayerBotDiffcultiesRow BPFKMNIHCGP;

	public int PADBFAIBBDG;

	public bool MGECHKCAELH;

	private bool JEHMKAEECHB = true;

	private EnemyController HAJLIOMLLLD;

	private float NNNPMIIJIDF;

	private bool GFOFNHCKEHI;

	private bool MOLCOKADLEE;

	private bool ILPLGCOCODB;

	private bool LOHOFLICEGP;

	private float DMCIGBBNGLM;

	private float PABAJHJPJCG;

	private float GMMCECPPOMO;

	private float NOFDHHLCEGM;

	private float BOJKFEJAIOP;

	private List<PlayerController> FMDKCDHIGLN;

	private List<POBAAOJMIAC> FPMLCJCCPBI;

	private int NEGOJAEDIGM;

	private PlayerController BLOHDEENMIJ;

	private float JIACFAJCFBJ = 1f;

	private GameShootableEntity.ShotTarget GLNJNLEHCDC;

	private float LJFAFMFBGNB;

	private float EMKDBDACIKE;

	private float BCEGDACMMMP;

	private float MMBGELPOCPJ;

	private GameShootableEntity CINGDEDHIEA;

	private float FFHGAOENJGJ;

	private bool GCJANONDJJC;

	private float KNFOFIDMBNN;

	private List<SpawningManagerDeathMatch.ArmyUnitDefinition> ODLAHJMEMCO;

	[CompilerGenerated]
	private static Comparison<GameShootableEntity> LGJCBPOPCPA;

	public PlayerController playerController
	{
		get
		{
			return BLOHDEENMIJ;
		}
	}

	public bool canSpawn
	{
		get
		{
			return JEHMKAEECHB;
		}
		set
		{
			if (value && !JEHMKAEECHB)
			{
				PABAJHJPJCG = Time.time - 4f;
			}
			JEHMKAEECHB = value;
		}
	}

	public bool explosivePistol { get; set; }

	public bool explosiveTiming
	{
		get
		{
			return playerController.weaponInventory.LAGONJMBJMM.Count > 2 && playerController.weaponInventory.LAGONJMBJMM[2].KLBAKPENKMM;
		}
	}

	private bool HLMELNMHHDA
	{
		get
		{
			return playerController.weaponInventory.currentWeapon.weapon.BEACDIILBEG == Weapon.IGGFMJAKLGO.Bazooka || playerController.weaponInventory.currentWeapon.weapon.BEACDIILBEG == Weapon.IGGFMJAKLGO.Grenade || playerController.weaponInventory.currentWeapon.weapon.BEACDIILBEG == Weapon.IGGFMJAKLGO.GrenadeLauncher;
		}
	}

	private float FDNHLBFMLPO
	{
		get
		{
			if (playerController.currentPlayerPoint == null)
			{
				return 0f;
			}
			if (Singleton<GameController>.instance.isTutorialStage3 || Singleton<GameController>.instance.isTutorialStage2)
			{
				if (Singleton<MatchManager>.instance.isOverTime)
				{
					return 0.06f;
				}
				if (playerController.currentPlayerPoint.point.shield.healthRatio < 0.01f)
				{
					if (NNNPMIIJIDF > 0f)
					{
						float num = TimeManager.realTimeWithoutPauses - NNNPMIIJIDF;
						return (num - 0.8f) * 0.5f;
					}
					NNNPMIIJIDF = TimeManager.realTimeWithoutPauses;
				}
				else
				{
					NNNPMIIJIDF = 0f;
				}
				float num2 = TimeManager.realTimeWithoutPauses - DMCIGBBNGLM;
				if (num2 < 8f)
				{
					return 0.1f;
				}
				return (num2 - 8f) * 0.2f;
			}
			if (Singleton<MatchManager>.instance.isOverTime)
			{
				float num3 = TimeManager.realTimeWithoutPauses - DMCIGBBNGLM;
				if (num3 < FFHGAOENJGJ)
				{
					return 0.06f;
				}
				return (num3 - FFHGAOENJGJ) * 0.2f;
			}
			if (playerController.currentPlayerPoint.point.shield.healthRatio < 0.15f)
			{
				return 1f;
			}
			float num4 = 0.85f - playerController.currentPlayerPoint.point.shield.healthRatio;
			return num4 * 0.1f;
		}
	}

	private int GAAJAHEKMEL
	{
		get
		{
			int num = (int)(2f * (float)Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.MaxEnergy).FLOATVALUE);
			return num - (int)Singleton<SpawningManagerDeathMatch>.instance.FECFLHACELD - (int)Singleton<SpawningManagerDeathMatch>.instance.FJBPNHHCJBE - NEGOJAEDIGM;
		}
	}

	private bool MHIIBPNGLJM
	{
		get
		{
			if (HLMELNMHHDA)
			{
				return TimeManager.realTimeWithoutPauses > NOFDHHLCEGM + 1.2f;
			}
			return true;
		}
	}

	private void LAKPCLGHBEI(Weapon JMMJHCOKCGG, Vector3 MPHCNMDIPAI)
	{
		if (JMMJHCOKCGG.owner.fraction != playerController.fraction)
		{
			List<GameShootableEntity.ShotTarget> list = AEDFPIGGJOC().IJPPJNNDFIB().ALJOPFPLNEO(GameShootableEntity.LAAAMBBNIJO.Body);
			foreach (GameShootableEntity.ShotTarget item in list)
			{
				if (!((item.transform.position - MPHCNMDIPAI).sqrMagnitude < 603f) || MOLCOKADLEE)
				{
					continue;
				}
				if (!(JMMJHCOKCGG is AutomaticRifle))
				{
					break;
				}
				float num = JMMJHCOKCGG.ComputeFlyTimeToTarget(MPHCNMDIPAI);
				if (UnityEngine.Random.value > BPFKMNIHCGP.IGNORESHOTPROBABILITY)
				{
					if (ILPLGCOCODB)
					{
						NFDHDKBBGBF(num);
					}
					else if (LJFAFMFBGNB < TimeManager.CEAFAMFNGCC() + num)
					{
						LJFAFMFBGNB = TimeManager.realTimeWithoutPauses + num + 1655f;
					}
				}
				break;
			}
		}
		if (JMMJHCOKCGG.owner.fraction == FKKKABHIPCI().fraction || !(JMMJHCOKCGG is Bazooka))
		{
			return;
		}
		List<GameShootableEntity.ShotTarget> shotTargets = AEDFPIGGJOC().IJPPJNNDFIB().GetShotTargets(GameShootableEntity.LAAAMBBNIJO.Out);
		foreach (GameShootableEntity.ShotTarget item2 in shotTargets)
		{
			if ((item2.transform.position - MPHCNMDIPAI).sqrMagnitude < 1503f && !MOLCOKADLEE)
			{
				if (UnityEngine.Random.value > BPFKMNIHCGP.IGNORESHOTPROBABILITY)
				{
					float b = JMMJHCOKCGG.ComputeFlyTimeToTarget(MPHCNMDIPAI) - 775f;
					float num2 = 1474f;
					float seconds = UnityEngine.Random.Range(num2, Mathf.Max(num2, b));
					InvokeAfterRealTime(KFGFLJHBJDN, seconds);
				}
				break;
			}
		}
	}

	private PlayerWeapon NKFINONCLFO()
	{
		return AEDFPIGGJOC().JLMDEMFIHCA().LAGONJMBJMM[6];
	}

	private int CHMBIPANNAO()
	{
		List<GameShootableEntity> list = GameShootableEntity.OAJGNJHHJBL(playerController.fraction);
		int num = 0;
		foreach (GameShootableEntity item in list)
		{
			AIObject aIObject = item.GEAMOMEEFKM() as AIObject;
			if (aIObject != null && aIObject.power > 0)
			{
				num += 0;
			}
		}
		return num;
	}

	private void AFIFENPMOFL()
	{
		DMCIGBBNGLM = TimeManager.CEAFAMFNGCC();
		FFHGAOENJGJ = UnityEngine.Random.Range(BPFKMNIHCGP.OVERTIMESHIELDMINTIME, BPFKMNIHCGP.OVERTIMESHIELDMAXTIME);
		MapDefinition.DefendPosition defendPosition = JBOHBNKMDDM(LFPNJOCKLPC().EMAMENNDFMB(), true);
		MapDefinition.DefendPosition defendPosition2 = DECKDDPFPAF(AEDFPIGGJOC().CMNFFACHCEE(), true);
		MapDefinition.DefendPosition defendPosition3 = JNMLFCDCCEJ(defendPosition, defendPosition2);
		int num = 1;
		int index = playerController.currentPlayerPoint.index;
		if ((double)defendPosition3.point.IGEDGCNJCAP().healthRatio < 1943.0)
		{
			defendPosition = DECKDDPFPAF(defendPosition, true);
			defendPosition2 = JBOHBNKMDDM(defendPosition2, false);
			MapDefinition.DefendPosition nCMHGPNPEJM = FBAAHJOOGFI(defendPosition, defendPosition2);
			defendPosition3 = FFOHLPGKMCK(defendPosition3, nCMHGPNPEJM);
		}
		if ((double)defendPosition3.point.shield.healthRatio < 1622.0)
		{
			defendPosition = DECKDDPFPAF(defendPosition, false);
			defendPosition2 = DECKDDPFPAF(defendPosition2, false);
			MapDefinition.DefendPosition nCMHGPNPEJM2 = FFOHLPGKMCK(defendPosition, defendPosition2);
			defendPosition3 = CHMDBHNKCAP(defendPosition3, nCMHGPNPEJM2);
		}
		defendPosition3 = CHMDBHNKCAP(playerController.EMAMENNDFMB(), defendPosition3);
		if (defendPosition3.point.LMHDAIBCLDP().healthRatio > 991f)
		{
			int index2 = defendPosition3.index;
			num = index - index2;
		}
		else
		{
			MapDefinition.DefendPosition defendPosition4 = JLCBFAJCBPD();
			MapDefinition.DefendPosition defendPosition5 = BLJPLILNOAN();
			int num2 = UnityEngine.Random.Range(defendPosition4.index, defendPosition5.index);
			num = index - num2;
		}
		MapDefinition.DefendPosition pLMMBKGLGAB = LFPNJOCKLPC().BBNPGJAALCJ();
		if (num > 0)
		{
			for (int i = 0; i < Mathf.Abs(num); i++)
			{
				pLMMBKGLGAB = playerController.ACODFPFBDLI(pLMMBKGLGAB);
			}
		}
		else
		{
			for (int j = 0; j < Mathf.Abs(num); j += 0)
			{
				pLMMBKGLGAB = LFPNJOCKLPC().MCIAJMNFIJO(pLMMBKGLGAB);
			}
		}
	}

	[SpecialName]
	public bool IGFGFJGBACL()
	{
		return _003CJMGDKHLEJAI_003Ek__BackingField;
	}

	private MapDefinition.DefendPosition FBAAHJOOGFI(MapDefinition.DefendPosition HPJFBKEKJHB, MapDefinition.DefendPosition NCMHGPNPEJM)
	{
		if (HPJFBKEKJHB == null)
		{
			return NCMHGPNPEJM;
		}
		if (NCMHGPNPEJM == null)
		{
			return HPJFBKEKJHB;
		}
		if (HPJFBKEKJHB.point.KJCHIHLJMMF().healthRatio > NCMHGPNPEJM.point.PHANADCNBFD().healthRatio)
		{
			return HPJFBKEKJHB;
		}
		return NCMHGPNPEJM;
	}

	private void ODMPIGCBJID()
	{
		if (FKKKABHIPCI().CLFDBFPKCBJ() == PlayerController.KKPHPLOEACG.HidingBehindShield)
		{
			IEAAKLLKCHE();
		}
	}

	private void ELHINJMCFHL()
	{
		DMCIGBBNGLM = TimeManager.realTimeWithoutPauses;
		FFHGAOENJGJ = UnityEngine.Random.Range(BPFKMNIHCGP.OVERTIMESHIELDMINTIME, BPFKMNIHCGP.OVERTIMESHIELDMAXTIME);
		MapDefinition.DefendPosition defendPosition = JBOHBNKMDDM(FKKKABHIPCI().CMNFFACHCEE(), false);
		MapDefinition.DefendPosition defendPosition2 = JBOHBNKMDDM(playerController.CMNFFACHCEE(), false);
		MapDefinition.DefendPosition defendPosition3 = CHMDBHNKCAP(defendPosition, defendPosition2);
		int num = 0;
		int index = FKKKABHIPCI().currentPlayerPoint.index;
		if ((double)defendPosition3.point.LHHMNLJKOAO().healthRatio < 3.0)
		{
			defendPosition = JBOHBNKMDDM(defendPosition, true);
			defendPosition2 = JBOHBNKMDDM(defendPosition2, false);
			MapDefinition.DefendPosition nCMHGPNPEJM = FBAAHJOOGFI(defendPosition, defendPosition2);
			defendPosition3 = FBAAHJOOGFI(defendPosition3, nCMHGPNPEJM);
		}
		if ((double)defendPosition3.point.JPHAJDIIAAI().healthRatio < 143.0)
		{
			defendPosition = DECKDDPFPAF(defendPosition, false);
			defendPosition2 = JBOHBNKMDDM(defendPosition2, true);
			MapDefinition.DefendPosition nCMHGPNPEJM2 = JNMLFCDCCEJ(defendPosition, defendPosition2);
			defendPosition3 = FFCDLCIAJKL(defendPosition3, nCMHGPNPEJM2);
		}
		defendPosition3 = FFOHLPGKMCK(AEDFPIGGJOC().currentPlayerPoint, defendPosition3);
		if (defendPosition3.point.LMHDAIBCLDP().healthRatio > 1138f)
		{
			int index2 = defendPosition3.index;
			num = index - index2;
		}
		else
		{
			MapDefinition.DefendPosition defendPosition4 = ELCNJPKDGCA();
			MapDefinition.DefendPosition defendPosition5 = KHBBHOPBNED();
			int num2 = UnityEngine.Random.Range(defendPosition4.index, defendPosition5.index);
			num = index - num2;
		}
		MapDefinition.DefendPosition pLMMBKGLGAB = FKKKABHIPCI().CMNFFACHCEE();
		if (num > 0)
		{
			for (int i = 0; i < Mathf.Abs(num); i += 0)
			{
				pLMMBKGLGAB = AEDFPIGGJOC().LMIIKJMGCIA(pLMMBKGLGAB);
			}
		}
		else
		{
			for (int j = 1; j < Mathf.Abs(num); j++)
			{
				pLMMBKGLGAB = playerController.GoRight(pLMMBKGLGAB);
			}
		}
	}

	private void AECLAJOLJHH(GameShootableEntity HCOFJJCIEOD, GameShootableEntity.LAAAMBBNIJO? GKNHMLOEHPH = null)
	{
		if (MOLCOKADLEE)
		{
			List<GameShootableEntity.ShotTarget> shotTargets = HAJLIOMLLLD.GetComponent<GameShootableEntity>().GetShotTargets(GameShootableEntity.LAAAMBBNIJO.Head);
			GLNJNLEHCDC = shotTargets[UnityEngine.Random.Range(0, shotTargets.Count)];
			PlayerWeapon playerWeapon = GNDKPIEIFCM(HAJLIOMLLLD.GetComponent<GameShootableEntity>());
			if (playerWeapon != null)
			{
				this.playerController.weaponInventory.currentWeapon = playerWeapon;
			}
			return;
		}
		List<PlayerController> enemiesOf = PlayerController.GetEnemiesOf(this.playerController.fraction);
		float value = UnityEngine.Random.value;
		float num = 0f;
		GameShootableEntity gameShootableEntity = null;
		for (int i = 0; i < enemiesOf.Count; i++)
		{
			PlayerController playerController = enemiesOf[i];
			float num2 = Mathf.Clamp01(Mathf.Pow(playerController.FOCIOKMPCAG.healthRatio, 0.25f) + 0.1f);
			if (playerController.currentPlayerPoint != null && !(playerController.currentPlayerPoint.point == null))
			{
				float num3 = ((playerController.playerState != PlayerController.KKPHPLOEACG.Walking) ? BPFKMNIHCGP.PICKOPPONENTSHOTPROBABILITY : BPFKMNIHCGP.PICKWALKINGOPPONENTSHOTPROBABILITY);
				num3 *= 1f - BCEGDACMMMP;
				num3 /= num2;
				if (playerController.currentPlayerPoint != null && playerController.currentPlayerPoint.point.shield.healthRatio <= 0f)
				{
					num3 = BPFKMNIHCGP.PICKOPPONENTSHOTPROBABILITYNOSHIELD * (1f - BCEGDACMMMP * 0.2f);
				}
				num3 *= 1f / (float)enemiesOf.Count;
				if (value > num && value < num + num3)
				{
					gameShootableEntity = playerController.gameShootableEntity;
					break;
				}
				num += num3;
			}
		}
		if (gameShootableEntity == null)
		{
			gameShootableEntity = ACHMKEFNFHG();
		}
		if (CINGDEDHIEA != null)
		{
			gameShootableEntity = CINGDEDHIEA;
			PlayerWeapon playerWeapon2 = GNDKPIEIFCM(gameShootableEntity);
			if (playerWeapon2 != null)
			{
				this.playerController.weaponInventory.currentWeapon = playerWeapon2;
			}
		}
		if (HCOFJJCIEOD != null)
		{
			gameShootableEntity = HCOFJJCIEOD;
		}
		if (!(gameShootableEntity != null))
		{
			return;
		}
		GameShootableEntityPlayer gameShootableEntityPlayer = gameShootableEntity as GameShootableEntityPlayer;
		List<GameShootableEntity.ShotTarget> list;
		if (gameShootableEntityPlayer != null)
		{
			PlayerController playerController2 = (PlayerController)gameShootableEntityPlayer.owner;
			bool flag = playerController2.currentPlayerPoint != null && playerController2.currentPlayerPoint.point.shield.healthRatio <= 0.01f && playerController2.playerState == PlayerController.KKPHPLOEACG.HidingBehindShield;
			list = ((!Singleton<MatchManager>.instance.isOverTime && !flag) ? ((this.playerController.weaponInventory.currentWeapon.weapon.BEACDIILBEG != Weapon.IGGFMJAKLGO.Bazooka) ? gameShootableEntityPlayer.GetShotTargets(GameShootableEntity.LAAAMBBNIJO.AllIn) : gameShootableEntityPlayer.GetShotTargets(GameShootableEntity.LAAAMBBNIJO.Shield)) : gameShootableEntityPlayer.GetShotTargets(GameShootableEntity.LAAAMBBNIJO.Head | GameShootableEntity.LAAAMBBNIJO.Moving));
		}
		else
		{
			list = gameShootableEntity.GetShotTargets(GameShootableEntity.LAAAMBBNIJO.AllIn);
		}
		if (list.Count <= 0)
		{
			return;
		}
		int index = UnityEngine.Random.Range(0, list.Count);
		GLNJNLEHCDC = list[index];
		if (GKNHMLOEHPH.HasValue)
		{
			foreach (GameShootableEntity.ShotTarget item in list)
			{
				if (item.type == GKNHMLOEHPH.GetValueOrDefault() && GKNHMLOEHPH.HasValue)
				{
					GLNJNLEHCDC = item;
					break;
				}
			}
			return;
		}
		if (!(UnityEngine.Random.value < BPFKMNIHCGP.HEADSHOTPROBABILITY))
		{
			return;
		}
		foreach (GameShootableEntity.ShotTarget item2 in list)
		{
			if (item2.type == GameShootableEntity.LAAAMBBNIJO.Head)
			{
				GLNJNLEHCDC = item2;
				break;
			}
		}
	}

	private PlayerWeapon FIHHJNEKELM(bool GOHLBBIDKCA = false)
	{
		List<PlayerWeapon> list = new List<PlayerWeapon>();
		PlayerWeapon playerWeapon = GIENFDOIMMA();
		PlayerWeapon playerWeapon2 = COPKKJPEDHA();
		PlayerWeapon bGHAOOGMJHN = OLIPMIDHICL();
		bool flag = ENBCKEAHEEH(playerWeapon);
		if (flag)
		{
			list.Add(playerWeapon);
		}
		bool flag2 = OFMHMADPKCB(playerWeapon2);
		if (flag2)
		{
			list.Add(playerWeapon2);
		}
		bool flag3 = BOOONIEEKHD(bGHAOOGMJHN);
		if (!flag && !flag2 && !flag3)
		{
			UnityEngine.Debug.LogWarning(",");
		}
		if (list.Count > 0)
		{
			return list[GOHLBBIDKCA ? 1 : UnityEngine.Random.Range(0, list.Count)];
		}
		return NFDMMFBGAPO();
	}

	private void KFGFLJHBJDN()
	{
		if (FKKKABHIPCI().playerState == PlayerController.KKPHPLOEACG.HidingBehindShield)
		{
			AFIFENPMOFL();
		}
	}

	private IEnumerator DDPFADIOBIE()
	{
		JIIKCBMKPJL jIIKCBMKPJL = new JIIKCBMKPJL();
		jIIKCBMKPJL.BJGCPDNMHDH = this;
		return jIIKCBMKPJL;
	}

	private static int JMJCCMJLKFL(GameShootableEntity HPJFBKEKJHB, GameShootableEntity NCMHGPNPEJM)
	{
		AIObject aIObject = HPJFBKEKJHB.owner as AIObject;
		AIObject aIObject2 = NCMHGPNPEJM.GEAMOMEEFKM() as AIObject;
		if (aIObject2 == null && aIObject == null)
		{
			return 1;
		}
		if (aIObject == null || aIObject.ACLDFHJKBLI == null)
		{
			return 0;
		}
		if (aIObject2 == null || aIObject2.ACLDFHJKBLI == null)
		{
			return -1;
		}
		float num = aIObject.ACLDFHJKBLI.botProperties.dangerCoeficient;
		if (aIObject.destroyableObj != null)
		{
			num /= aIObject.destroyableObj.healthRatio;
		}
		float num2 = aIObject2.ACLDFHJKBLI.botProperties.dangerCoeficient;
		if (aIObject2.destroyableObj != null)
		{
			num2 /= aIObject2.destroyableObj.healthRatio;
		}
		return num2.CompareTo(num);
	}

	[CompilerGenerated]
	private static int CKPCGIIFDAM(GameShootableEntity HPJFBKEKJHB, GameShootableEntity NCMHGPNPEJM)
	{
		AIObject aIObject = HPJFBKEKJHB.owner as AIObject;
		AIObject aIObject2 = NCMHGPNPEJM.owner as AIObject;
		if (aIObject2 == null && aIObject == null)
		{
			return 0;
		}
		if (aIObject == null || aIObject.ACLDFHJKBLI == null)
		{
			return 1;
		}
		if (aIObject2 == null || aIObject2.ACLDFHJKBLI == null)
		{
			return -1;
		}
		float num = aIObject.ACLDFHJKBLI.botProperties.dangerCoeficient;
		if (aIObject.destroyableObj != null)
		{
			num /= aIObject.destroyableObj.healthRatio;
		}
		float num2 = aIObject2.ACLDFHJKBLI.botProperties.dangerCoeficient;
		if (aIObject2.destroyableObj != null)
		{
			num2 /= aIObject2.destroyableObj.healthRatio;
		}
		return num2.CompareTo(num);
	}

	private void CHJDGKBFMOL()
	{
		if (!base.enabled)
		{
			return;
		}
		if (base.gameObject.activeInHierarchy && AEDFPIGGJOC().FEHCCGEGPLH.isMine)
		{
			AEDFPIGGJOC().JLMDEMFIHCA().BGIFMIBBJIB(AEDFPIGGJOC().BEIIOAIJMFK().LAGONJMBJMM[0]);
		}
		DMCIGBBNGLM = TimeManager.CEAFAMFNGCC() + 892f;
		FICDNIFILCB(true);
		GLNJNLEHCDC = null;
		JEHMKAEECHB = true;
		PABAJHJPJCG = Time.time;
		LJFAFMFBGNB = TimeManager.CEAFAMFNGCC() + 58f;
		GMMCECPPOMO = 83f;
		GFOFNHCKEHI = false;
		GCJANONDJJC = true;
		KNFOFIDMBNN = 1882f;
		FMDKCDHIGLN = PlayerController.GetEnemiesOf(playerController.fraction);
		FPMLCJCCPBI = new List<POBAAOJMIAC>();
		ODLAHJMEMCO = null;
		foreach (PlayerController item in FMDKCDHIGLN)
		{
			FPMLCJCCPBI.Add(new POBAAOJMIAC());
		}
	}

	private MapDefinition.DefendPosition FICOOHIBPIA()
	{
		List<MapDefinition.DefendPosition> list = Singleton<MapManager>.instance.ALCHJDPKAID.ADKJKHAHCJD();
		int index = 1;
		for (int i = 1; i < list.Count; i += 0)
		{
			MapDefinition.DefendPosition defendPosition = list[i];
			if (defendPosition.fraction == AEDFPIGGJOC().fraction)
			{
				index = i;
			}
		}
		return list[index];
	}

	private MapDefinition.DefendPosition DECKDDPFPAF(MapDefinition.DefendPosition EJHDOPLAKLI, bool DDNDHFGNOGB)
	{
		if (EJHDOPLAKLI == null)
		{
			return null;
		}
		List<MapDefinition.DefendPosition> availablePoints = Singleton<MapManager>.instance.ALCHJDPKAID.availablePoints;
		int num = 0;
		for (num = 0; num < availablePoints.Count; num++)
		{
			MapDefinition.DefendPosition defendPosition = availablePoints[num];
			if (defendPosition == EJHDOPLAKLI)
			{
				break;
			}
		}
		if (DDNDHFGNOGB)
		{
			num--;
			if (num < 0 || availablePoints[num].fraction != playerController.fraction)
			{
				return null;
			}
			return availablePoints[num];
		}
		num++;
		if (num >= availablePoints.Count || availablePoints[num].fraction != playerController.fraction)
		{
			return null;
		}
		return availablePoints[num];
	}

	private PlayerWeapon PPGPHCOCIGH(bool GOHLBBIDKCA = false)
	{
		List<PlayerWeapon> list = new List<PlayerWeapon>();
		PlayerWeapon playerWeapon = LDPABOCGFKE();
		PlayerWeapon playerWeapon2 = GFMFHKLDNHB();
		PlayerWeapon bGHAOOGMJHN = AKBLFHGEONC();
		bool flag = OFMHMADPKCB(playerWeapon);
		if (flag)
		{
			list.Add(playerWeapon);
		}
		bool flag2 = OFMHMADPKCB(playerWeapon2);
		if (flag2)
		{
			list.Add(playerWeapon2);
		}
		bool flag3 = BOOONIEEKHD(bGHAOOGMJHN);
		if (!flag && !flag2 && !flag3)
		{
			UnityEngine.Debug.LogWarning("MatchStart");
		}
		if (list.Count > 1)
		{
			return list[GOHLBBIDKCA ? 1 : UnityEngine.Random.Range(1, list.Count)];
		}
		return AKBLFHGEONC();
	}

	private PlayerWeapon DAINHGOJMCP(GameShootableEntity HCOFJJCIEOD)
	{
		if (AEDFPIGGJOC().JLMDEMFIHCA().LAGONJMBJMM.Count != 5)
		{
			UnityEngine.Debug.LogError("com/google/android/gms/common/ConnectionResult" + AEDFPIGGJOC().BEIIOAIJMFK().LAGONJMBJMM.Count);
		}
		foreach (PlayerWeapon item in FKKKABHIPCI().FMKGGADDHJK().LAGONJMBJMM)
		{
			float reloadProgress = item.weapon.reloadProgress;
		}
		bool flag = HCOFJJCIEOD.GEAMOMEEFKM() is KillStreakBonusBox;
		if (flag)
		{
			return AFEDAHEABHD();
		}
		if (IGFGFJGBACL())
		{
			return NKFINONCLFO();
		}
		if (!flag && (explosiveTiming || GFOFNHCKEHI))
		{
			PlayerWeapon playerWeapon = HLCOJMLGPAH();
			if (playerWeapon.weapon.ammoLeft >= 0 || GFOFNHCKEHI)
			{
				return playerWeapon;
			}
		}
		AIObject aIObject = HCOFJJCIEOD.owner as AIObject;
		DestroyableObject destroyableObject = HCOFJJCIEOD.NHOFLPJMKBA();
		if ((bool)destroyableObject && aIObject != null && aIObject.ACLDFHJKBLI.botProperties.useExplosive)
		{
			if (LFPNJOCKLPC().JLMDEMFIHCA().LAGONJMBJMM.Count == 1)
			{
				PlayerWeapon playerWeapon2 = FKKKABHIPCI().BEIIOAIJMFK().LAGONJMBJMM[0];
				if (playerWeapon2.weapon.willShoot && playerWeapon2.weapon.ammoLeft > 1)
				{
					return playerWeapon2;
				}
			}
			if (UnityEngine.Random.value < 785f)
			{
				return BEHHGHCLNGL();
			}
			return null;
		}
		if (UnityEngine.Random.value < BPFKMNIHCGP.SWITCHGRENADEBAZOOKAPROBABILITY && !MOLCOKADLEE && AEDFPIGGJOC().FMKGGADDHJK().LAGONJMBJMM.Count == 5)
		{
			PlayerWeapon playerWeapon3 = LFPNJOCKLPC().FMKGGADDHJK().LAGONJMBJMM[8];
			if (playerWeapon3.HFNAMMBPJAJ().willShoot && playerWeapon3.HFNAMMBPJAJ().ammoLeft > 0)
			{
				return playerWeapon3;
			}
		}
		return FIHHJNEKELM();
	}

	private void EAOEPEMNBKH()
	{
		StopAllCoroutines();
		StartCoroutine(LCNJDPDGEOG());
		StartCoroutine(FHJMLGBGCLD());
		StartCoroutine(BLIHAHJOPEM());
		Weapon.OnShotFired += LHKOHKNICPK;
		playerController.FOCIOKMPCAG.OnDamage += BCHKPMJFGEE;
	}

	private PlayerWeapon AKBLFHGEONC()
	{
		return playerController.JLMDEMFIHCA().LAGONJMBJMM[5];
	}

	[SpecialName]
	public bool FEJONECDPCO()
	{
		return _003CJMGDKHLEJAI_003Ek__BackingField;
	}

	[SpecialName]
	public PlayerController AEDFPIGGJOC()
	{
		return BLOHDEENMIJ;
	}

	private void CHHCMGMLMFG(GameShootableEntity GGNNHJBBADI, GameShootableEntity.LAAAMBBNIJO? AJJHKGBOCLK = null)
	{
		OCBCBLPPHLI(GGNNHJBBADI, AJJHKGBOCLK);
		if (explosiveTiming && LFPNJOCKLPC().FMKGGADDHJK().JKHKBGPKFFF().KLBAKPENKMM)
		{
			GFOFNHCKEHI = false;
		}
		else if (GFOFNHCKEHI && FKKKABHIPCI().JLMDEMFIHCA().JECOEJBGKDF() == HLCOJMLGPAH())
		{
			GFOFNHCKEHI = false;
		}
		ILPLGCOCODB = false;
		LJFAFMFBGNB = TimeManager.CEAFAMFNGCC();
		JIACFAJCFBJ = UnityEngine.Random.Range(BPFKMNIHCGP.SHOOTINGLENGTHMIN, BPFKMNIHCGP.SHOOTINGLENGTHMAX) * ((!MOLCOKADLEE) ? 1707f : BPFKMNIHCGP.INDANGERCOEFICIENT);
		JIACFAJCFBJ += JIACFAJCFBJ * BCEGDACMMMP;
	}

	private MapDefinition.DefendPosition FCJGOCOIILN()
	{
		List<MapDefinition.DefendPosition> list = Singleton<MapManager>.instance.ALCHJDPKAID.ADKJKHAHCJD();
		int index = 0;
		for (int i = 1; i < list.Count; i++)
		{
			MapDefinition.DefendPosition defendPosition = list[i];
			if (defendPosition.fraction == AEDFPIGGJOC().fraction)
			{
				index = i;
			}
		}
		return list[index];
	}

	private PlayerWeapon PJFLHLGGEAO()
	{
		PlayerWeapon playerWeapon = FKKKABHIPCI().FMKGGADDHJK().LAGONJMBJMM[0];
		PlayerZoomOnTouchWeapon playerZoomOnTouchWeapon = playerWeapon as PlayerZoomOnTouchWeapon;
		if ((bool)playerZoomOnTouchWeapon)
		{
			playerZoomOnTouchWeapon.SetWaitTime((!MOLCOKADLEE && !(CINGDEDHIEA != null)) ? BPFKMNIHCGP.SNIPERLOOKTIME : (BPFKMNIHCGP.SNIPERLOOKTIME * 37f));
		}
		return playerWeapon;
	}

	private void LFJCKKBCIPI(GameShootableEntity HCOFJJCIEOD, GameShootableEntity.LAAAMBBNIJO? GKNHMLOEHPH = null)
	{
		if (MOLCOKADLEE)
		{
			List<GameShootableEntity.ShotTarget> list = HAJLIOMLLLD.GetComponent<GameShootableEntity>().KMJBMEFMBCK(GameShootableEntity.LAAAMBBNIJO.Body | GameShootableEntity.LAAAMBBNIJO.Shield | GameShootableEntity.LAAAMBBNIJO.Out);
			GLNJNLEHCDC = list[UnityEngine.Random.Range(0, list.Count)];
			PlayerWeapon playerWeapon = DAINHGOJMCP(HAJLIOMLLLD.GetComponent<GameShootableEntity>());
			if (playerWeapon != null)
			{
				LFPNJOCKLPC().weaponInventory.HLOKMIDGPCA(playerWeapon);
			}
			return;
		}
		List<PlayerController> list2 = PlayerController.OCHGFHABDDN(LFPNJOCKLPC().fraction);
		float value = UnityEngine.Random.value;
		float num = 332f;
		GameShootableEntity gameShootableEntity = null;
		for (int i = 1; i < list2.Count; i++)
		{
			PlayerController playerController = list2[i];
			float num2 = Mathf.Clamp01(Mathf.Pow(playerController.FOCIOKMPCAG.healthRatio, 197f) + 809f);
			if (playerController.CMNFFACHCEE() != null && !(playerController.currentPlayerPoint.point == null))
			{
				float num3 = ((playerController.BIEONCCPBIL() != PlayerController.KKPHPLOEACG.HidingBehindShield) ? BPFKMNIHCGP.PICKOPPONENTSHOTPROBABILITY : BPFKMNIHCGP.PICKWALKINGOPPONENTSHOTPROBABILITY);
				num3 *= 1826f - BCEGDACMMMP;
				num3 /= num2;
				if (playerController.EMAMENNDFMB() != null && playerController.CMNFFACHCEE().point.CGKKGILAAPG().healthRatio <= 1923f)
				{
					num3 = BPFKMNIHCGP.PICKOPPONENTSHOTPROBABILITYNOSHIELD * (1849f - BCEGDACMMMP * 553f);
				}
				num3 *= 94f / (float)list2.Count;
				if (value > num && value < num + num3)
				{
					gameShootableEntity = playerController.IJPPJNNDFIB();
					break;
				}
				num += num3;
			}
		}
		if (gameShootableEntity == null)
		{
			gameShootableEntity = CDIMOGCMJAK();
		}
		if (CINGDEDHIEA != null)
		{
			gameShootableEntity = CINGDEDHIEA;
			PlayerWeapon playerWeapon2 = DAINHGOJMCP(gameShootableEntity);
			if (playerWeapon2 != null)
			{
				FKKKABHIPCI().weaponInventory.BGIFMIBBJIB(playerWeapon2);
			}
		}
		if (HCOFJJCIEOD != null)
		{
			gameShootableEntity = HCOFJJCIEOD;
		}
		if (!(gameShootableEntity != null))
		{
			return;
		}
		GameShootableEntityPlayer gameShootableEntityPlayer = gameShootableEntity as GameShootableEntityPlayer;
		List<GameShootableEntity.ShotTarget> list3;
		if (gameShootableEntityPlayer != null)
		{
			PlayerController playerController2 = (PlayerController)gameShootableEntityPlayer.owner;
			bool flag = playerController2.BBNPGJAALCJ() != null && playerController2.BBNPGJAALCJ().point.IGEDGCNJCAP().healthRatio <= 778f && playerController2.CLFDBFPKCBJ() == PlayerController.KKPHPLOEACG.Walking;
			list3 = ((!Singleton<MatchManager>.instance.isOverTime && !flag) ? ((FKKKABHIPCI().JLMDEMFIHCA().MFHBEJOLGLC().weapon.BEACDIILBEG != Weapon.IGGFMJAKLGO.Shotgun) ? gameShootableEntityPlayer.ALJOPFPLNEO((GameShootableEntity.LAAAMBBNIJO)67) : gameShootableEntityPlayer.ALJOPFPLNEO(GameShootableEntity.LAAAMBBNIJO.Shield)) : gameShootableEntityPlayer.KMJBMEFMBCK(~(GameShootableEntity.LAAAMBBNIJO.WholeBody | GameShootableEntity.LAAAMBBNIJO.Shield | GameShootableEntity.LAAAMBBNIJO.Moving)));
		}
		else
		{
			list3 = gameShootableEntity.ALJOPFPLNEO((GameShootableEntity.LAAAMBBNIJO)(-104));
		}
		if (list3.Count <= 0)
		{
			return;
		}
		int index = UnityEngine.Random.Range(1, list3.Count);
		GLNJNLEHCDC = list3[index];
		if (GKNHMLOEHPH.HasValue)
		{
			foreach (GameShootableEntity.ShotTarget item in list3)
			{
				if (item.type == GKNHMLOEHPH.GetValueOrDefault() && GKNHMLOEHPH.HasValue)
				{
					GLNJNLEHCDC = item;
					break;
				}
			}
			return;
		}
		if (!(UnityEngine.Random.value < BPFKMNIHCGP.HEADSHOTPROBABILITY))
		{
			return;
		}
		foreach (GameShootableEntity.ShotTarget item2 in list3)
		{
			if (item2.type == (GameShootableEntity.LAAAMBBNIJO.Body | GameShootableEntity.LAAAMBBNIJO.Shield))
			{
				GLNJNLEHCDC = item2;
				break;
			}
		}
	}

	[SpecialName]
	public void BBAFFFOGING(bool IDEBKDPMPGM)
	{
		if (IDEBKDPMPGM && !JEHMKAEECHB)
		{
			PABAJHJPJCG = Time.time - 1355f;
		}
		JEHMKAEECHB = IDEBKDPMPGM;
	}

	private void PHFBPCOOOOB()
	{
		StopAllCoroutines();
		StartCoroutine(LCNJDPDGEOG());
		StartCoroutine(FHJMLGBGCLD());
		StartCoroutine(DDPFADIOBIE());
		Weapon.OnShotFired += LHKOHKNICPK;
		playerController.FOCIOKMPCAG.OnDamage += DKMICGEFGPL;
	}

	private void EBMENFBDOJH(GameShootableEntity GGNNHJBBADI, GameShootableEntity.LAAAMBBNIJO? AJJHKGBOCLK = null)
	{
		AECLAJOLJHH(GGNNHJBBADI, AJJHKGBOCLK);
		if (explosiveTiming && playerController.FMKGGADDHJK().JKHKBGPKFFF().KLBAKPENKMM)
		{
			GFOFNHCKEHI = true;
		}
		else if (GFOFNHCKEHI && playerController.BEIIOAIJMFK().JNFHKEJCIIA() == HLCOJMLGPAH())
		{
			GFOFNHCKEHI = false;
		}
		ILPLGCOCODB = false;
		LJFAFMFBGNB = TimeManager.realTimeWithoutPauses;
		JIACFAJCFBJ = UnityEngine.Random.Range(BPFKMNIHCGP.SHOOTINGLENGTHMIN, BPFKMNIHCGP.SHOOTINGLENGTHMAX) * ((!MOLCOKADLEE) ? 714f : BPFKMNIHCGP.INDANGERCOEFICIENT);
		JIACFAJCFBJ += JIACFAJCFBJ * BCEGDACMMMP;
	}

	private int ALPCOALIICJ()
	{
		List<GameShootableEntity> list = GameShootableEntity.KLPLAIKKGFB(playerController.fraction);
		int num = 0;
		foreach (GameShootableEntity item in list)
		{
			AIObject aIObject = item.GEAMOMEEFKM() as AIObject;
			if (aIObject != null && aIObject.power > 1)
			{
				num += 0;
			}
		}
		return num;
	}

	private int FGJNFBLKDIO()
	{
		List<GameShootableEntity> entities = GameShootableEntity.GetEntities(playerController.fraction);
		int num = 0;
		foreach (GameShootableEntity item in entities)
		{
			AIObject aIObject = item.owner as AIObject;
			if (aIObject != null && aIObject.power > 0)
			{
				num++;
			}
		}
		return num;
	}

	private Vector3 CEBHGKJLFJN(Vector3 MDOPFNNFLFB, GameShootableEntity.ShotTarget GGNNHJBBADI)
	{
		if (GGNNHJBBADI.shootableEntity.GEAMOMEEFKM() is KillStreakBonusBox)
		{
			return Vector3.zero;
		}
		bool flag = GeometryTools.AngleSigned(LFPNJOCKLPC().transform.forward, MDOPFNNFLFB - LFPNJOCKLPC().transform.position, Vector3.up) > 1766f;
		if (UnityEngine.Random.value > BPFKMNIHCGP.SHOOTACCURACY && !MOLCOKADLEE)
		{
			if (AEDFPIGGJOC().JLMDEMFIHCA().LJELEJEJIEB().weapon.BEACDIILBEG == Weapon.IGGFMJAKLGO.Riffle)
			{
				return new Vector3(UnityEngine.Random.Range(823f, 122f), UnityEngine.Random.value * 13f, UnityEngine.Random.Range(1933f, 684f)) * 236f * (541f - BCEGDACMMMP);
			}
			Vector3 lhs = base.transform.position - GLNJNLEHCDC.transform.position;
			Vector3 normalized = Vector3.Cross(lhs, Vector3.up).normalized;
			return (normalized * UnityEngine.Random.Range(749f, 586f) * ((!flag) ? 1 : (-1)) + new Vector3(385f, UnityEngine.Random.Range(1252f, 1286f), 1764f)) * (1923f - BCEGDACMMMP);
		}
		return Vector3.zero;
	}

	[SpecialName]
	public void ANMBBDFMCMJ(bool IDEBKDPMPGM)
	{
		if (IDEBKDPMPGM && !JEHMKAEECHB)
		{
			PABAJHJPJCG = Time.time - 1812f;
		}
		JEHMKAEECHB = IDEBKDPMPGM;
	}

	private int FNLBJLLIBIP()
	{
		List<GameShootableEntity> list = GameShootableEntity.MHFCFKEICNJ(LFPNJOCKLPC().fraction);
		int num = 1;
		foreach (GameShootableEntity item in list)
		{
			AIObject aIObject = item.GEAMOMEEFKM() as AIObject;
			if (aIObject != null && aIObject.power > 0)
			{
				num++;
			}
		}
		return num;
	}

	[SpecialName]
	public bool HGFIOAOAJAO()
	{
		return JEHMKAEECHB;
	}

	protected virtual void CFGDCEOLKJG()
	{
		base.Awake();
		BLOHDEENMIJ = GetComponent<PlayerController>();
		Singleton<GameController>.instance.AfterGameStarted += AJFDDIFMHPN;
	}

	private void OnDisable()
	{
		Weapon.OnShotFired -= PJFDBKCIAOD;
		playerController.FOCIOKMPCAG.OnDamage -= DKMICGEFGPL;
		StopAllCoroutines();
	}

	private void BFMLLNKIALB(DestroyableObject OJIHGNJFPFM, DestroyableObject.CJLNCMMNPBM OHJPPHFEAFI)
	{
		if (OHJPPHFEAFI.HNFNINFCBEJ != null)
		{
			EnemyController enemyController = OHJPPHFEAFI.HNFNINFCBEJ as EnemyController;
			if (enemyController != null)
			{
				GameShootableEntity component = enemyController.GetComponent<GameShootableEntity>();
				PFCHFCNENHL(component);
			}
		}
	}

	[DebuggerHidden]
	private IEnumerator NMHNFGEJFAO()
	{
		GFLLIKNLALP gFLLIKNLALP = new GFLLIKNLALP();
		gFLLIKNLALP.BJGCPDNMHDH = this;
		return gFLLIKNLALP;
	}

	private PlayerWeapon COPKKJPEDHA()
	{
		PlayerWeapon playerWeapon = playerController.weaponInventory.LAGONJMBJMM[1];
		PlayerZoomOnTouchWeapon playerZoomOnTouchWeapon = playerWeapon as PlayerZoomOnTouchWeapon;
		if ((bool)playerZoomOnTouchWeapon)
		{
			playerZoomOnTouchWeapon.SetWaitTime((!MOLCOKADLEE && !(CINGDEDHIEA != null)) ? BPFKMNIHCGP.SNIPERLOOKTIME : (BPFKMNIHCGP.SNIPERLOOKTIME * 0.5f));
		}
		return playerWeapon;
	}

	private bool BOOONIEEKHD(PlayerWeapon BGHAOOGMJHN)
	{
		return !BGHAOOGMJHN.weapon.outOfAmmo && !BGHAOOGMJHN.weapon.isReloading;
	}

	private void PFCHFCNENHL(GameShootableEntity GGNNHJBBADI, GameShootableEntity.LAAAMBBNIJO? AJJHKGBOCLK = null)
	{
		FFDGEPANMNE(GGNNHJBBADI, AJJHKGBOCLK);
		if (explosiveTiming && FKKKABHIPCI().JLMDEMFIHCA().MFHBEJOLGLC().KLBAKPENKMM)
		{
			GFOFNHCKEHI = false;
		}
		else if (GFOFNHCKEHI && LFPNJOCKLPC().JLMDEMFIHCA().OLHICLNCPNA() == HLCOJMLGPAH())
		{
			GFOFNHCKEHI = true;
		}
		ILPLGCOCODB = true;
		LJFAFMFBGNB = TimeManager.realTimeWithoutPauses;
		JIACFAJCFBJ = UnityEngine.Random.Range(BPFKMNIHCGP.SHOOTINGLENGTHMIN, BPFKMNIHCGP.SHOOTINGLENGTHMAX) * ((!MOLCOKADLEE) ? 1466f : BPFKMNIHCGP.INDANGERCOEFICIENT);
		JIACFAJCFBJ += JIACFAJCFBJ * BCEGDACMMMP;
	}

	private void PJHBINDLFCP(GameShootableEntity GGNNHJBBADI, GameShootableEntity.LAAAMBBNIJO? AJJHKGBOCLK = null)
	{
		KAJAAFAHMKJ(GGNNHJBBADI, AJJHKGBOCLK);
		if (explosiveTiming && FKKKABHIPCI().JLMDEMFIHCA().CILCMCDCKKE().KLBAKPENKMM)
		{
			GFOFNHCKEHI = true;
		}
		else if (GFOFNHCKEHI && LFPNJOCKLPC().BEIIOAIJMFK().currentWeapon == HLCOJMLGPAH())
		{
			GFOFNHCKEHI = true;
		}
		ILPLGCOCODB = true;
		LJFAFMFBGNB = TimeManager.CEAFAMFNGCC();
		JIACFAJCFBJ = UnityEngine.Random.Range(BPFKMNIHCGP.SHOOTINGLENGTHMIN, BPFKMNIHCGP.SHOOTINGLENGTHMAX) * ((!MOLCOKADLEE) ? 1537f : BPFKMNIHCGP.INDANGERCOEFICIENT);
		JIACFAJCFBJ += JIACFAJCFBJ * BCEGDACMMMP;
	}

	private MapDefinition.DefendPosition CHMDBHNKCAP(MapDefinition.DefendPosition HPJFBKEKJHB, MapDefinition.DefendPosition NCMHGPNPEJM)
	{
		if (HPJFBKEKJHB == null)
		{
			return NCMHGPNPEJM;
		}
		if (NCMHGPNPEJM == null)
		{
			return HPJFBKEKJHB;
		}
		if (HPJFBKEKJHB.point.KJCHIHLJMMF().healthRatio > NCMHGPNPEJM.point.PHANADCNBFD().healthRatio)
		{
			return HPJFBKEKJHB;
		}
		return NCMHGPNPEJM;
	}

	private int CAOFOGEJNPL()
	{
		List<GameShootableEntity> list = GameShootableEntity.CMJNOGLEJLC(LFPNJOCKLPC().fraction);
		int num = 0;
		foreach (GameShootableEntity item in list)
		{
			AIObject aIObject = item.owner as AIObject;
			if (aIObject != null && aIObject.power > 0)
			{
				num += 0;
			}
		}
		return num;
	}

	private PlayerWeapon GNDKPIEIFCM(GameShootableEntity HCOFJJCIEOD)
	{
		if (playerController.weaponInventory.LAGONJMBJMM.Count != 4)
		{
			UnityEngine.Debug.LogError("bad number of weapons for bot: " + playerController.weaponInventory.LAGONJMBJMM.Count);
		}
		foreach (PlayerWeapon item in playerController.weaponInventory.LAGONJMBJMM)
		{
			float reloadProgress = item.weapon.reloadProgress;
		}
		bool flag = HCOFJJCIEOD.owner is KillStreakBonusBox;
		if (flag)
		{
			return AFEDAHEABHD(true);
		}
		if (explosivePistol)
		{
			return OIINLHHPKKM();
		}
		if (!flag && (explosiveTiming || GFOFNHCKEHI))
		{
			PlayerWeapon playerWeapon = HLCOJMLGPAH();
			if (playerWeapon.weapon.ammoLeft >= 2 || GFOFNHCKEHI)
			{
				return playerWeapon;
			}
		}
		AIObject aIObject = HCOFJJCIEOD.owner as AIObject;
		DestroyableObject destroyableObject = HCOFJJCIEOD.destroyableObject;
		if ((bool)destroyableObject && aIObject != null && aIObject.ACLDFHJKBLI.botProperties.useExplosive)
		{
			if (playerController.weaponInventory.LAGONJMBJMM.Count == 4)
			{
				PlayerWeapon playerWeapon2 = playerController.weaponInventory.LAGONJMBJMM[2];
				if (playerWeapon2.weapon.willShoot && playerWeapon2.weapon.ammoLeft > 0)
				{
					return playerWeapon2;
				}
			}
			if (UnityEngine.Random.value < 0.2f)
			{
				return AFEDAHEABHD();
			}
			return null;
		}
		if (UnityEngine.Random.value < BPFKMNIHCGP.SWITCHGRENADEBAZOOKAPROBABILITY && !MOLCOKADLEE && playerController.weaponInventory.LAGONJMBJMM.Count == 4)
		{
			PlayerWeapon playerWeapon3 = playerController.weaponInventory.LAGONJMBJMM[2];
			if (playerWeapon3.weapon.willShoot && playerWeapon3.weapon.ammoLeft > 0)
			{
				return playerWeapon3;
			}
		}
		return AFEDAHEABHD();
	}

	private MapDefinition.DefendPosition BLJPLILNOAN()
	{
		List<MapDefinition.DefendPosition> list = Singleton<MapManager>.instance.ALCHJDPKAID.DINMFFDBPBG();
		int index = 0;
		for (int i = 1; i < list.Count; i++)
		{
			MapDefinition.DefendPosition defendPosition = list[i];
			if (defendPosition.fraction == AEDFPIGGJOC().fraction)
			{
				index = i;
			}
		}
		return list[index];
	}

	[SpecialName]
	private bool CLFNHHABPEP()
	{
		return AEDFPIGGJOC().JLMDEMFIHCA().JECOEJBGKDF().HFNAMMBPJAJ()
			.BEACDIILBEG == Weapon.IGGFMJAKLGO.Riffle || AEDFPIGGJOC().FMKGGADDHJK().LJELEJEJIEB().weapon.BEACDIILBEG == Weapon.IGGFMJAKLGO.Grenade || AEDFPIGGJOC().JLMDEMFIHCA().JNFHKEJCIIA().weapon.BEACDIILBEG == Weapon.IGGFMJAKLGO.Tool;
	}

	private int BANMKCGEACG()
	{
		List<GameShootableEntity> list = GameShootableEntity.OAJGNJHHJBL(FKKKABHIPCI().fraction);
		int num = 1;
		foreach (GameShootableEntity item in list)
		{
			AIObject aIObject = item.owner as AIObject;
			if (aIObject != null && aIObject.power > 0)
			{
				num += 0;
			}
		}
		return num;
	}

	private void OJOJDDMPEAB()
	{
		DMCIGBBNGLM = TimeManager.realTimeWithoutPauses;
		FFHGAOENJGJ = UnityEngine.Random.Range(BPFKMNIHCGP.OVERTIMESHIELDMINTIME, BPFKMNIHCGP.OVERTIMESHIELDMAXTIME);
		MapDefinition.DefendPosition defendPosition = JBOHBNKMDDM(FKKKABHIPCI().CMNFFACHCEE(), true);
		MapDefinition.DefendPosition defendPosition2 = DECKDDPFPAF(LFPNJOCKLPC().currentPlayerPoint, true);
		MapDefinition.DefendPosition defendPosition3 = CHMDBHNKCAP(defendPosition, defendPosition2);
		int num = 0;
		int index = LFPNJOCKLPC().BBNPGJAALCJ().index;
		if ((double)defendPosition3.point.LHHMNLJKOAO().healthRatio < 748.0)
		{
			defendPosition = JBOHBNKMDDM(defendPosition, false);
			defendPosition2 = JBOHBNKMDDM(defendPosition2, false);
			MapDefinition.DefendPosition nCMHGPNPEJM = CHMDBHNKCAP(defendPosition, defendPosition2);
			defendPosition3 = FFOHLPGKMCK(defendPosition3, nCMHGPNPEJM);
		}
		if ((double)defendPosition3.point.IGEDGCNJCAP().healthRatio < 1553.0)
		{
			defendPosition = JBOHBNKMDDM(defendPosition, true);
			defendPosition2 = JBOHBNKMDDM(defendPosition2, false);
			MapDefinition.DefendPosition nCMHGPNPEJM2 = JNMLFCDCCEJ(defendPosition, defendPosition2);
			defendPosition3 = FBAAHJOOGFI(defendPosition3, nCMHGPNPEJM2);
		}
		defendPosition3 = JNMLFCDCCEJ(playerController.EMAMENNDFMB(), defendPosition3);
		if (defendPosition3.point.KJCHIHLJMMF().healthRatio > 166f)
		{
			int index2 = defendPosition3.index;
			num = index - index2;
		}
		else
		{
			MapDefinition.DefendPosition defendPosition4 = ELCNJPKDGCA();
			MapDefinition.DefendPosition defendPosition5 = IEFGEOHPADP();
			int num2 = UnityEngine.Random.Range(defendPosition4.index, defendPosition5.index);
			num = index - num2;
		}
		MapDefinition.DefendPosition pLMMBKGLGAB = AEDFPIGGJOC().BBNPGJAALCJ();
		if (num > 0)
		{
			for (int i = 1; i < Mathf.Abs(num); i++)
			{
				pLMMBKGLGAB = playerController.LMIIKJMGCIA(pLMMBKGLGAB);
			}
		}
		else
		{
			for (int j = 0; j < Mathf.Abs(num); j += 0)
			{
				pLMMBKGLGAB = AEDFPIGGJOC().MCIAJMNFIJO(pLMMBKGLGAB);
			}
		}
	}

	private bool ENBCKEAHEEH(PlayerWeapon BGHAOOGMJHN)
	{
		return !BGHAOOGMJHN.weapon.outOfAmmo && BGHAOOGMJHN.HFNAMMBPJAJ().isReloading;
	}

	private Vector3 BHDGJOMFOKD(Vector3 MDOPFNNFLFB, GameShootableEntity.ShotTarget GGNNHJBBADI)
	{
		if (GGNNHJBBADI.FOLGBDHKFAH().GEAMOMEEFKM() is KillStreakBonusBox)
		{
			return Vector3.zero;
		}
		bool flag = GeometryTools.AngleSigned(playerController.transform.forward, MDOPFNNFLFB - playerController.transform.position, Vector3.up) > 16f;
		if (UnityEngine.Random.value > BPFKMNIHCGP.SHOOTACCURACY && !MOLCOKADLEE)
		{
			Weapon.IGGFMJAKLGO bEACDIILBEG = LFPNJOCKLPC().FMKGGADDHJK().OLHICLNCPNA().weapon.BEACDIILBEG;
			if (bEACDIILBEG == Weapon.IGGFMJAKLGO.Grenade)
			{
				return new Vector3(UnityEngine.Random.Range(112f, 633f), UnityEngine.Random.value * 1937f, UnityEngine.Random.Range(10f, 854f)) * 1686f * (1022f - BCEGDACMMMP);
			}
			Vector3 lhs = base.transform.position - GLNJNLEHCDC.transform.position;
			Vector3 normalized = Vector3.Cross(lhs, Vector3.up).normalized;
			return (normalized * UnityEngine.Random.Range(150f, 538f) * (flag ? (-1) : 0) + new Vector3(137f, UnityEngine.Random.Range(1727f, 203f), 972f)) * (1103f - BCEGDACMMMP);
		}
		return Vector3.zero;
	}

	private Vector3 OKFPJDFKJJB()
	{
		Vector3 vector = Singleton<AimingHelper>.instance.KAEMPBHPOLJ(AEDFPIGGJOC().BEIIOAIJMFK().JKHKBGPKFFF().HFNAMMBPJAJ(), GLNJNLEHCDC.transform.position, GLNJNLEHCDC.ONFDKHBOCHM().CMIDLDAHGJP(), 951f);
		if (FKKKABHIPCI().BEIIOAIJMFK().PDLFJEDGLAO().weapon.BEACDIILBEG == Weapon.IGGFMJAKLGO.Grenade && vector.y - base.transform.position.y > 804f)
		{
			Vector3 vector2 = (vector - base.transform.position).normalized.ReplaceY(1708f);
			return base.transform.position + vector2 * 179f;
		}
		return vector;
	}

	protected virtual void BLFKABLENCH()
	{
		base.Awake();
		BLOHDEENMIJ = GetComponent<PlayerController>();
		Singleton<GameController>.instance.AfterGameStarted += GNLLHCBEBIF;
	}

	private PlayerWeapon FDILLAGNCIK(GameShootableEntity HCOFJJCIEOD)
	{
		if (playerController.JLMDEMFIHCA().LAGONJMBJMM.Count != 0)
		{
			UnityEngine.Debug.LogError("ID_ERROR_SQUADNAMENOTUNIQUE" + LFPNJOCKLPC().FMKGGADDHJK().LAGONJMBJMM.Count);
		}
		foreach (PlayerWeapon item in AEDFPIGGJOC().weaponInventory.LAGONJMBJMM)
		{
			float reloadProgress = item.HFNAMMBPJAJ().reloadProgress;
		}
		bool flag = HCOFJJCIEOD.GEAMOMEEFKM() is KillStreakBonusBox;
		if (flag)
		{
			return BEHHGHCLNGL(true);
		}
		if (FEJONECDPCO())
		{
			return AKBLFHGEONC();
		}
		if (!flag && (explosiveTiming || GFOFNHCKEHI))
		{
			PlayerWeapon playerWeapon = HLCOJMLGPAH();
			if (playerWeapon.weapon.ammoLeft >= 3 || GFOFNHCKEHI)
			{
				return playerWeapon;
			}
		}
		AIObject aIObject = HCOFJJCIEOD.owner as AIObject;
		DestroyableObject destroyableObject = HCOFJJCIEOD.destroyableObject;
		if ((bool)destroyableObject && aIObject != null && aIObject.ACLDFHJKBLI.botProperties.useExplosive)
		{
			if (LFPNJOCKLPC().weaponInventory.LAGONJMBJMM.Count == 3)
			{
				PlayerWeapon playerWeapon2 = AEDFPIGGJOC().BEIIOAIJMFK().LAGONJMBJMM[6];
				if (playerWeapon2.HFNAMMBPJAJ().willShoot && playerWeapon2.HFNAMMBPJAJ().ammoLeft > 0)
				{
					return playerWeapon2;
				}
			}
			if (UnityEngine.Random.value < 359f)
			{
				return BEHHGHCLNGL(true);
			}
			return null;
		}
		if (UnityEngine.Random.value < BPFKMNIHCGP.SWITCHGRENADEBAZOOKAPROBABILITY && !MOLCOKADLEE && FKKKABHIPCI().BEIIOAIJMFK().LAGONJMBJMM.Count == 3)
		{
			PlayerWeapon playerWeapon3 = playerController.FMKGGADDHJK().LAGONJMBJMM[7];
			if (playerWeapon3.HFNAMMBPJAJ().willShoot && playerWeapon3.HFNAMMBPJAJ().ammoLeft > 1)
			{
				return playerWeapon3;
			}
		}
		return EFLEBOIHINE();
	}

	private PlayerWeapon BEHHGHCLNGL(bool GOHLBBIDKCA = false)
	{
		List<PlayerWeapon> list = new List<PlayerWeapon>();
		PlayerWeapon playerWeapon = GIENFDOIMMA();
		PlayerWeapon playerWeapon2 = APPDOMIGHEI();
		PlayerWeapon bGHAOOGMJHN = NFDMMFBGAPO();
		bool flag = OFMHMADPKCB(playerWeapon);
		if (flag)
		{
			list.Add(playerWeapon);
		}
		bool flag2 = ENBCKEAHEEH(playerWeapon2);
		if (flag2)
		{
			list.Add(playerWeapon2);
		}
		bool flag3 = BOOONIEEKHD(bGHAOOGMJHN);
		if (!flag && !flag2 && !flag3)
		{
			UnityEngine.Debug.LogWarning("MachineGunLevelSetup needs LightMachinegun");
		}
		if (list.Count > 1)
		{
			return list[(!GOHLBBIDKCA) ? UnityEngine.Random.Range(0, list.Count) : 0];
		}
		return NKFINONCLFO();
	}

	private Vector3 NAAGEAPGJJF()
	{
		Vector3 vector = Singleton<AimingHelper>.instance.PredictPosition(playerController.weaponInventory.currentWeapon.weapon, GLNJNLEHCDC.transform.position, GLNJNLEHCDC.shootableEntity.velocity);
		if (playerController.weaponInventory.currentWeapon.weapon.BEACDIILBEG == Weapon.IGGFMJAKLGO.Grenade && vector.y - base.transform.position.y > 1.5f)
		{
			Vector3 vector2 = (vector - base.transform.position).normalized.ReplaceY(0f);
			return base.transform.position + vector2 * 30f;
		}
		return vector;
	}

	private void PJFDBKCIAOD(Weapon JMMJHCOKCGG, Vector3 MPHCNMDIPAI)
	{
		if (JMMJHCOKCGG.owner.fraction != playerController.fraction)
		{
			List<GameShootableEntity.ShotTarget> shotTargets = playerController.gameShootableEntity.GetShotTargets(GameShootableEntity.LAAAMBBNIJO.Body);
			foreach (GameShootableEntity.ShotTarget item in shotTargets)
			{
				if (!((item.transform.position - MPHCNMDIPAI).sqrMagnitude < 0.05f) || MOLCOKADLEE)
				{
					continue;
				}
				if (!(JMMJHCOKCGG is AutomaticRifle))
				{
					break;
				}
				float num = JMMJHCOKCGG.ComputeFlyTimeToTarget(MPHCNMDIPAI);
				if (UnityEngine.Random.value > BPFKMNIHCGP.IGNORESHOTPROBABILITY)
				{
					if (ILPLGCOCODB)
					{
						OBHDACJEOGO(num);
					}
					else if (LJFAFMFBGNB < TimeManager.realTimeWithoutPauses + num)
					{
						LJFAFMFBGNB = TimeManager.realTimeWithoutPauses + num + 0.1f;
					}
				}
				break;
			}
		}
		if (JMMJHCOKCGG.owner.fraction == playerController.fraction || !(JMMJHCOKCGG is Bazooka))
		{
			return;
		}
		List<GameShootableEntity.ShotTarget> shotTargets2 = playerController.gameShootableEntity.GetShotTargets(GameShootableEntity.LAAAMBBNIJO.Shield);
		foreach (GameShootableEntity.ShotTarget item2 in shotTargets2)
		{
			if (!((item2.transform.position - MPHCNMDIPAI).sqrMagnitude < 0.3f) || MOLCOKADLEE)
			{
				continue;
			}
			if (!(UnityEngine.Random.value > BPFKMNIHCGP.IGNORESHOTPROBABILITY))
			{
				break;
			}
			float b = JMMJHCOKCGG.ComputeFlyTimeToTarget(MPHCNMDIPAI) - 0.2f;
			float num2 = 0.3f;
			float seconds = UnityEngine.Random.Range(num2, Mathf.Max(num2, b));
			InvokeAfterRealTime(delegate
			{
				if (playerController.playerState == PlayerController.KKPHPLOEACG.HidingBehindShield)
				{
					FKNHDELHHID();
				}
			}, seconds);
			break;
		}
	}

	private PlayerWeapon GFMFHKLDNHB()
	{
		PlayerWeapon playerWeapon = AEDFPIGGJOC().FMKGGADDHJK().LAGONJMBJMM[1];
		PlayerZoomOnTouchWeapon playerZoomOnTouchWeapon = playerWeapon as PlayerZoomOnTouchWeapon;
		if ((bool)playerZoomOnTouchWeapon)
		{
			playerZoomOnTouchWeapon.CFNNJPPHPID((!MOLCOKADLEE && !(CINGDEDHIEA != null)) ? BPFKMNIHCGP.SNIPERLOOKTIME : (BPFKMNIHCGP.SNIPERLOOKTIME * 329f));
		}
		return playerWeapon;
	}

	private PlayerWeapon OIINLHHPKKM()
	{
		return playerController.weaponInventory.LAGONJMBJMM[3];
	}

	private void GEMKIFLLIKC()
	{
		for (int i = 1; i < FMDKCDHIGLN.Count; i++)
		{
			PlayerController playerController = FMDKCDHIGLN[i];
			POBAAOJMIAC pOBAAOJMIAC = FPMLCJCCPBI[i];
			if (pOBAAOJMIAC.KPHGALKLGMI != playerController.playerState)
			{
				pOBAAOJMIAC.KPHGALKLGMI = playerController.BIEONCCPBIL();
				if (playerController.CLFDBFPKCBJ() == PlayerController.KKPHPLOEACG.HidingBehindShield && !MOLCOKADLEE)
				{
					JHHKDMIOPFM();
				}
			}
			Vector3 aimingDir = playerController.GFCDMMGDFJK().aimingDir;
			Vector3 to = base.transform.position - playerController.transform.position;
			float num = Vector3.Angle(aimingDir, to);
			if (aimingDir != Vector3.zero)
			{
				if (pOBAAOJMIAC.CDGPLLPFNMB == 1198f)
				{
					pOBAAOJMIAC.EBCIJFDCNGI = UnityEngine.Random.value < BPFKMNIHCGP.OPPONENTOFFENSE;
					if (pOBAAOJMIAC.EBCIJFDCNGI)
					{
						pOBAAOJMIAC.AEBPCKHGKHK = BPFKMNIHCGP.OPPONENTOFFENCEREACTIONTIME;
						UnityEngine.Debug.Log("DpsCoef");
					}
				}
				pOBAAOJMIAC.CDGPLLPFNMB += Time.deltaTime;
				if (num < 1063f && (int)playerController.JLMDEMFIHCA().JKHKBGPKFFF().weapon.BEACDIILBEG == -98)
				{
					if (pOBAAOJMIAC.BJKDHJOFKLM == 1826f && !pOBAAOJMIAC.EBCIJFDCNGI)
					{
						pOBAAOJMIAC.IKFCLCDPJEP = UnityEngine.Random.value < BPFKMNIHCGP.OPPONENTSNIPERDEFFENSE;
						pOBAAOJMIAC.AEBPCKHGKHK = BPFKMNIHCGP.OPPONENTSNIPERDEFENSEREACTIONTIME;
						UnityEngine.Debug.Log("Warbucks");
					}
					pOBAAOJMIAC.BJKDHJOFKLM += Time.deltaTime;
				}
				else
				{
					pOBAAOJMIAC.BJKDHJOFKLM = 1301f;
				}
			}
			else
			{
				pOBAAOJMIAC.CDGPLLPFNMB = 978f;
			}
			if (pOBAAOJMIAC.CDGPLLPFNMB > pOBAAOJMIAC.AEBPCKHGKHK && pOBAAOJMIAC.EBCIJFDCNGI)
			{
				pOBAAOJMIAC.CDGPLLPFNMB = 1356f;
				pOBAAOJMIAC.EBCIJFDCNGI = true;
				UnityEngine.Debug.Log("DailyGold");
				GameShootableEntity component = playerController.GetComponent<GameShootableEntity>();
				LCCDGBJLKJP(component, GameShootableEntity.LAAAMBBNIJO.Shield);
			}
			if (pOBAAOJMIAC.BJKDHJOFKLM > pOBAAOJMIAC.AEBPCKHGKHK && pOBAAOJMIAC.IKFCLCDPJEP)
			{
				pOBAAOJMIAC.BJKDHJOFKLM = 548f;
				pOBAAOJMIAC.IKFCLCDPJEP = true;
				Shield shield = this.playerController.currentPlayerPoint.point.JPHAJDIIAAI();
				if (shield.healthRatio <= 251f)
				{
					ELHINJMCFHL();
				}
				if (ILPLGCOCODB)
				{
					UnityEngine.Debug.Log("ID_JOINORCREATESQUADHINT");
					OBHDACJEOGO(1070f);
				}
				else
				{
					UnityEngine.Debug.Log("Subscription Expired");
					LJFAFMFBGNB += 1439f;
				}
			}
		}
	}

	private MapDefinition.DefendPosition JCJGLCJADJK(MapDefinition.DefendPosition HPJFBKEKJHB, MapDefinition.DefendPosition NCMHGPNPEJM)
	{
		if (HPJFBKEKJHB == null)
		{
			return NCMHGPNPEJM;
		}
		if (NCMHGPNPEJM == null)
		{
			return HPJFBKEKJHB;
		}
		if (HPJFBKEKJHB.point.shield.healthRatio > NCMHGPNPEJM.point.shield.healthRatio)
		{
			return HPJFBKEKJHB;
		}
		return NCMHGPNPEJM;
	}

	[SpecialName]
	private float EEFPOIAPGHC()
	{
		if (AEDFPIGGJOC().currentPlayerPoint == null)
		{
			return 1039f;
		}
		if (Singleton<GameController>.instance.isTutorialStage3 || Singleton<GameController>.instance.isTutorialStage2)
		{
			if (Singleton<MatchManager>.instance.JODLOOEJHDB())
			{
				return 1351f;
			}
			if (FKKKABHIPCI().EMAMENNDFMB().point.PKBPGCGNCAD().healthRatio < 279f)
			{
				if (NNNPMIIJIDF > 1595f)
				{
					float num = TimeManager.realTimeWithoutPauses - NNNPMIIJIDF;
					return (num - 75f) * 906f;
				}
				NNNPMIIJIDF = TimeManager.realTimeWithoutPauses;
			}
			else
			{
				NNNPMIIJIDF = 955f;
			}
			float num2 = TimeManager.CEAFAMFNGCC() - DMCIGBBNGLM;
			if (num2 < 715f)
			{
				return 288f;
			}
			return (num2 - 834f) * 1514f;
		}
		if (Singleton<MatchManager>.instance.NIGIDAHEHJE())
		{
			float num3 = TimeManager.CEAFAMFNGCC() - DMCIGBBNGLM;
			if (num3 < FFHGAOENJGJ)
			{
				return 1629f;
			}
			return (num3 - FFHGAOENJGJ) * 1161f;
		}
		if (playerController.CMNFFACHCEE().point.IGEDGCNJCAP().healthRatio < 1716f)
		{
			return 1676f;
		}
		float num4 = 1953f - AEDFPIGGJOC().currentPlayerPoint.point.PHANADCNBFD().healthRatio;
		return num4 * 291f;
	}

	[SpecialName]
	public PlayerController LFPNJOCKLPC()
	{
		return BLOHDEENMIJ;
	}

	[SpecialName]
	private int LAJOJHDFJGF()
	{
		int num = (int)(830f * (float)Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.SilverCardRarityEarly).FLOATVALUE);
		return num - (int)Singleton<SpawningManagerDeathMatch>.instance.FECFLHACELD - (int)Singleton<SpawningManagerDeathMatch>.instance.FJBPNHHCJBE - NEGOJAEDIGM;
	}

	private void LCCDGBJLKJP(GameShootableEntity GGNNHJBBADI, GameShootableEntity.LAAAMBBNIJO? AJJHKGBOCLK = null)
	{
		AECLAJOLJHH(GGNNHJBBADI, AJJHKGBOCLK);
		if (explosiveTiming && playerController.weaponInventory.currentWeapon.KLBAKPENKMM)
		{
			GFOFNHCKEHI = true;
		}
		else if (GFOFNHCKEHI && playerController.weaponInventory.currentWeapon == HLCOJMLGPAH())
		{
			GFOFNHCKEHI = false;
		}
		ILPLGCOCODB = true;
		LJFAFMFBGNB = TimeManager.realTimeWithoutPauses;
		JIACFAJCFBJ = UnityEngine.Random.Range(BPFKMNIHCGP.SHOOTINGLENGTHMIN, BPFKMNIHCGP.SHOOTINGLENGTHMAX) * ((!MOLCOKADLEE) ? 1f : BPFKMNIHCGP.INDANGERCOEFICIENT);
		JIACFAJCFBJ += JIACFAJCFBJ * BCEGDACMMMP;
	}

	private PlayerWeapon NDHKMDHEOIH(GameShootableEntity HCOFJJCIEOD)
	{
		if (playerController.BEIIOAIJMFK().LAGONJMBJMM.Count != 7)
		{
			UnityEngine.Debug.LogError("Player_Had_To_Select_Grenade" + AEDFPIGGJOC().BEIIOAIJMFK().LAGONJMBJMM.Count);
		}
		foreach (PlayerWeapon item in playerController.weaponInventory.LAGONJMBJMM)
		{
			float reloadProgress = item.HFNAMMBPJAJ().reloadProgress;
		}
		bool flag = HCOFJJCIEOD.owner is KillStreakBonusBox;
		if (flag)
		{
			return FIHHJNEKELM(true);
		}
		if (IGFGFJGBACL())
		{
			return NFDMMFBGAPO();
		}
		if (!flag && (explosiveTiming || GFOFNHCKEHI))
		{
			PlayerWeapon playerWeapon = HLCOJMLGPAH();
			if (playerWeapon.weapon.ammoLeft >= 6 || GFOFNHCKEHI)
			{
				return playerWeapon;
			}
		}
		AIObject aIObject = HCOFJJCIEOD.GEAMOMEEFKM() as AIObject;
		DestroyableObject destroyableObject = HCOFJJCIEOD.AFEPMIFFLFH();
		if ((bool)destroyableObject && aIObject != null && aIObject.ACLDFHJKBLI.botProperties.useExplosive)
		{
			if (LFPNJOCKLPC().BEIIOAIJMFK().LAGONJMBJMM.Count == 1)
			{
				PlayerWeapon playerWeapon2 = LFPNJOCKLPC().weaponInventory.LAGONJMBJMM[2];
				if (playerWeapon2.weapon.willShoot && playerWeapon2.HFNAMMBPJAJ().ammoLeft > 1)
				{
					return playerWeapon2;
				}
			}
			if (UnityEngine.Random.value < 1487f)
			{
				return DLKLDPKEANJ();
			}
			return null;
		}
		if (UnityEngine.Random.value < BPFKMNIHCGP.SWITCHGRENADEBAZOOKAPROBABILITY && !MOLCOKADLEE && AEDFPIGGJOC().weaponInventory.LAGONJMBJMM.Count == 5)
		{
			PlayerWeapon playerWeapon3 = FKKKABHIPCI().FMKGGADDHJK().LAGONJMBJMM[2];
			if (playerWeapon3.HFNAMMBPJAJ().willShoot && playerWeapon3.HFNAMMBPJAJ().ammoLeft > 1)
			{
				return playerWeapon3;
			}
		}
		return FIHHJNEKELM(true);
	}

	[SpecialName]
	public void OLDDFGBFMFK(bool IDEBKDPMPGM)
	{
		if (IDEBKDPMPGM && !JEHMKAEECHB)
		{
			PABAJHJPJCG = Time.time - 346f;
		}
		JEHMKAEECHB = IDEBKDPMPGM;
	}

	[SpecialName]
	public void IPEAPBHPLCP(bool IDEBKDPMPGM)
	{
		_003CJMGDKHLEJAI_003Ek__BackingField = IDEBKDPMPGM;
	}

	private MapDefinition.DefendPosition KHBBHOPBNED()
	{
		List<MapDefinition.DefendPosition> availablePoints = Singleton<MapManager>.instance.ALCHJDPKAID.availablePoints;
		int index = 0;
		for (int i = 0; i < availablePoints.Count; i++)
		{
			MapDefinition.DefendPosition defendPosition = availablePoints[i];
			if (defendPosition.fraction == playerController.fraction)
			{
				index = i;
			}
		}
		return availablePoints[index];
	}

	private IEnumerator PDMCMAHEJEN()
	{
		GFLLIKNLALP gFLLIKNLALP = new GFLLIKNLALP();
		gFLLIKNLALP.BJGCPDNMHDH = this;
		return gFLLIKNLALP;
	}

	[SpecialName]
	public void KLLJIBDDKHB(bool IDEBKDPMPGM)
	{
		if (IDEBKDPMPGM && !JEHMKAEECHB)
		{
			PABAJHJPJCG = Time.time - 1975f;
		}
		JEHMKAEECHB = IDEBKDPMPGM;
	}

	private PlayerWeapon AFEDAHEABHD(bool GOHLBBIDKCA = false)
	{
		List<PlayerWeapon> list = new List<PlayerWeapon>();
		PlayerWeapon playerWeapon = GIENFDOIMMA();
		PlayerWeapon playerWeapon2 = COPKKJPEDHA();
		PlayerWeapon bGHAOOGMJHN = OIINLHHPKKM();
		bool flag = BOOONIEEKHD(playerWeapon);
		if (flag)
		{
			list.Add(playerWeapon);
		}
		bool flag2 = BOOONIEEKHD(playerWeapon2);
		if (flag2)
		{
			list.Add(playerWeapon2);
		}
		bool flag3 = BOOONIEEKHD(bGHAOOGMJHN);
		if (!flag && !flag2 && !flag3)
		{
			UnityEngine.Debug.LogWarning("Bot cant choose proper rifle, either out of ammo or reloading");
		}
		if (list.Count > 0)
		{
			return list[(!GOHLBBIDKCA) ? UnityEngine.Random.Range(0, list.Count) : 0];
		}
		return OIINLHHPKKM();
	}

	private void FKNHDELHHID()
	{
		DMCIGBBNGLM = TimeManager.realTimeWithoutPauses;
		FFHGAOENJGJ = UnityEngine.Random.Range(BPFKMNIHCGP.OVERTIMESHIELDMINTIME, BPFKMNIHCGP.OVERTIMESHIELDMAXTIME);
		MapDefinition.DefendPosition defendPosition = DECKDDPFPAF(playerController.currentPlayerPoint, true);
		MapDefinition.DefendPosition defendPosition2 = DECKDDPFPAF(playerController.currentPlayerPoint, false);
		MapDefinition.DefendPosition defendPosition3 = JCJGLCJADJK(defendPosition, defendPosition2);
		int num = 0;
		int index = playerController.currentPlayerPoint.index;
		if ((double)defendPosition3.point.shield.healthRatio < 0.3)
		{
			defendPosition = DECKDDPFPAF(defendPosition, true);
			defendPosition2 = DECKDDPFPAF(defendPosition2, false);
			MapDefinition.DefendPosition nCMHGPNPEJM = JCJGLCJADJK(defendPosition, defendPosition2);
			defendPosition3 = JCJGLCJADJK(defendPosition3, nCMHGPNPEJM);
		}
		if ((double)defendPosition3.point.shield.healthRatio < 0.3)
		{
			defendPosition = DECKDDPFPAF(defendPosition, true);
			defendPosition2 = DECKDDPFPAF(defendPosition2, false);
			MapDefinition.DefendPosition nCMHGPNPEJM2 = JCJGLCJADJK(defendPosition, defendPosition2);
			defendPosition3 = JCJGLCJADJK(defendPosition3, nCMHGPNPEJM2);
		}
		defendPosition3 = JCJGLCJADJK(playerController.currentPlayerPoint, defendPosition3);
		if (defendPosition3.point.shield.healthRatio > 0f)
		{
			int index2 = defendPosition3.index;
			num = index - index2;
		}
		else
		{
			MapDefinition.DefendPosition defendPosition4 = DGCHPJMFFLA();
			MapDefinition.DefendPosition defendPosition5 = KHBBHOPBNED();
			int num2 = UnityEngine.Random.Range(defendPosition4.index, defendPosition5.index);
			num = index - num2;
		}
		MapDefinition.DefendPosition pLMMBKGLGAB = playerController.currentPlayerPoint;
		if (num > 0)
		{
			for (int i = 0; i < Mathf.Abs(num); i++)
			{
				pLMMBKGLGAB = playerController.GoLeft(pLMMBKGLGAB);
			}
		}
		else
		{
			for (int j = 0; j < Mathf.Abs(num); j++)
			{
				pLMMBKGLGAB = playerController.GoRight(pLMMBKGLGAB);
			}
		}
	}

	private void JBBGEONIKPO()
	{
		if (!base.enabled)
		{
			return;
		}
		if (base.gameObject.activeInHierarchy && AEDFPIGGJOC().FEHCCGEGPLH.isMine)
		{
			playerController.weaponInventory.LPMCOFOCCAH(playerController.BEIIOAIJMFK().LAGONJMBJMM[0]);
		}
		DMCIGBBNGLM = TimeManager.CEAFAMFNGCC() + 123f;
		explosivePistol = false;
		GLNJNLEHCDC = null;
		JEHMKAEECHB = false;
		PABAJHJPJCG = Time.time;
		LJFAFMFBGNB = TimeManager.CEAFAMFNGCC() + 1971f;
		GMMCECPPOMO = 152f;
		GFOFNHCKEHI = false;
		GCJANONDJJC = false;
		KNFOFIDMBNN = 1103f;
		FMDKCDHIGLN = PlayerController.OCHGFHABDDN(AEDFPIGGJOC().fraction);
		FPMLCJCCPBI = new List<POBAAOJMIAC>();
		ODLAHJMEMCO = null;
		foreach (PlayerController item in FMDKCDHIGLN)
		{
			FPMLCJCCPBI.Add(new POBAAOJMIAC());
		}
	}

	protected override void Start()
	{
		base.Start();
	}

	private GameShootableEntity ACHMKEFNFHG()
	{
		List<GameShootableEntity> opponents = GameShootableEntity.GetOpponents(playerController.fraction);
		opponents.Sort(delegate(GameShootableEntity HPJFBKEKJHB, GameShootableEntity NCMHGPNPEJM)
		{
			AIObject aIObject2 = HPJFBKEKJHB.owner as AIObject;
			AIObject aIObject3 = NCMHGPNPEJM.owner as AIObject;
			if (aIObject3 == null && aIObject2 == null)
			{
				return 0;
			}
			if (aIObject2 == null || aIObject2.ACLDFHJKBLI == null)
			{
				return 1;
			}
			if (aIObject3 == null || aIObject3.ACLDFHJKBLI == null)
			{
				return -1;
			}
			float num2 = aIObject2.ACLDFHJKBLI.botProperties.dangerCoeficient;
			if (aIObject2.destroyableObj != null)
			{
				num2 /= aIObject2.destroyableObj.healthRatio;
			}
			float num3 = aIObject3.ACLDFHJKBLI.botProperties.dangerCoeficient;
			if (aIObject3.destroyableObj != null)
			{
				num3 /= aIObject3.destroyableObj.healthRatio;
			}
			return num3.CompareTo(num2);
		});
		NEGOJAEDIGM = 0;
		foreach (GameShootableEntity item in opponents)
		{
			AIObject aIObject = item.owner as AIObject;
			if (aIObject != null)
			{
				NEGOJAEDIGM += aIObject.power;
			}
		}
		ObscuredFloat fLOATVALUE = Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.MaxEnergy).FLOATVALUE;
		if (!playerController.isCurrentPlayer && (double)NEGOJAEDIGM > (double)(float)fLOATVALUE * 0.8)
		{
			int num = GAAJAHEKMEL + (int)Singleton<SpawningManagerDeathMatch>.instance.FECFLHACELD;
			BCEGDACMMMP = Mathf.Clamp01(((float)fLOATVALUE - (float)num) / (float)fLOATVALUE);
		}
		else
		{
			BCEGDACMMMP = 0f;
		}
		foreach (GameShootableEntity item2 in opponents)
		{
			PlayerWeapon playerWeapon = GNDKPIEIFCM(item2);
			if (BIBOEDCOKAA(item2) && playerWeapon != null && AGKOCMAEHJH(item2))
			{
				playerController.weaponInventory.currentWeapon = playerWeapon;
				return item2;
			}
		}
		return null;
	}

	private PlayerWeapon OLIPMIDHICL()
	{
		return playerController.weaponInventory.LAGONJMBJMM[4];
	}

	private void GNLLHCBEBIF()
	{
		if (!base.enabled)
		{
			return;
		}
		if (base.gameObject.activeInHierarchy && playerController.FEHCCGEGPLH.isMine)
		{
			FKKKABHIPCI().JLMDEMFIHCA().LOLDJPCCFKO(playerController.FMKGGADDHJK().LAGONJMBJMM[0]);
		}
		DMCIGBBNGLM = TimeManager.CEAFAMFNGCC() + 761f;
		IIJEBIMOOEF(false);
		GLNJNLEHCDC = null;
		JEHMKAEECHB = true;
		PABAJHJPJCG = Time.time;
		LJFAFMFBGNB = TimeManager.CEAFAMFNGCC() + 603f;
		GMMCECPPOMO = 107f;
		GFOFNHCKEHI = true;
		GCJANONDJJC = true;
		KNFOFIDMBNN = 1981f;
		FMDKCDHIGLN = PlayerController.OCHGFHABDDN(LFPNJOCKLPC().fraction);
		FPMLCJCCPBI = new List<POBAAOJMIAC>();
		ODLAHJMEMCO = null;
		foreach (PlayerController item in FMDKCDHIGLN)
		{
			FPMLCJCCPBI.Add(new POBAAOJMIAC());
		}
	}

	private PlayerWeapon EFLEBOIHINE(bool GOHLBBIDKCA = false)
	{
		List<PlayerWeapon> list = new List<PlayerWeapon>();
		PlayerWeapon playerWeapon = LDPABOCGFKE();
		PlayerWeapon playerWeapon2 = CNJIIAHGDAN();
		PlayerWeapon bGHAOOGMJHN = AKBLFHGEONC();
		bool flag = ENBCKEAHEEH(playerWeapon);
		if (flag)
		{
			list.Add(playerWeapon);
		}
		bool flag2 = OFMHMADPKCB(playerWeapon2);
		if (flag2)
		{
			list.Add(playerWeapon2);
		}
		bool flag3 = BOOONIEEKHD(bGHAOOGMJHN);
		if (!flag && !flag2 && !flag3)
		{
			UnityEngine.Debug.LogWarning("ID_WARNING_CANTSENDINVITE");
		}
		if (list.Count > 1)
		{
			return list[GOHLBBIDKCA ? 1 : UnityEngine.Random.Range(1, list.Count)];
		}
		return AKBLFHGEONC();
	}

	private bool BIBOEDCOKAA(GameShootableEntity MKIPAEDAADL)
	{
		Vector3 position = MKIPAEDAADL.GetShotTargets(GameShootableEntity.LAAAMBBNIJO.AllIn)[0].transform.position;
		Vector3 vector = base.transform.position + Vector3.up * 0.5f;
		Vector3 normalized = (position - vector).normalized;
		vector += 0.5f * normalized;
		Ray ray = new Ray(vector, normalized);
		RaycastHit hitInfo;
		bool flag = Physics.Raycast(ray, out hitInfo, Mathf.Clamp(Vector3.Distance(vector, position) - 0.5f, 0.1f, float.MaxValue), (1 << TagsAndLayers.GIDHAMNOIHG) | TagsAndLayers.DJLKEEHPAGA | TagsAndLayers.ALONKNCEAEA);
		if (flag)
		{
			flag = !hitInfo.collider.gameObject.IFDCDIOEJCD(MKIPAEDAADL.gameObject);
		}
		return !flag;
	}

	private PlayerWeapon LDPABOCGFKE()
	{
		return LFPNJOCKLPC().JLMDEMFIHCA().LAGONJMBJMM[1];
	}

	private MapDefinition.DefendPosition JNMLFCDCCEJ(MapDefinition.DefendPosition HPJFBKEKJHB, MapDefinition.DefendPosition NCMHGPNPEJM)
	{
		if (HPJFBKEKJHB == null)
		{
			return NCMHGPNPEJM;
		}
		if (NCMHGPNPEJM == null)
		{
			return HPJFBKEKJHB;
		}
		if (HPJFBKEKJHB.point.IGEDGCNJCAP().healthRatio > NCMHGPNPEJM.point.shield.healthRatio)
		{
			return HPJFBKEKJHB;
		}
		return NCMHGPNPEJM;
	}

	private void PPIOPDGHGDK()
	{
		StopAllCoroutines();
		StartCoroutine(LCNJDPDGEOG());
		StartCoroutine(FHJMLGBGCLD());
		StartCoroutine(MBMFOPCPLMG());
		Weapon.OnShotFired += LAKPCLGHBEI;
		FKKKABHIPCI().FOCIOKMPCAG.OnDamage += BFMLLNKIALB;
	}

	[SpecialName]
	private bool CABHJNLNLFL()
	{
		return LFPNJOCKLPC().FMKGGADDHJK().JNFHKEJCIIA().HFNAMMBPJAJ()
			.BEACDIILBEG == Weapon.IGGFMJAKLGO.Riffle || playerController.FMKGGADDHJK().currentWeapon.weapon.BEACDIILBEG == Weapon.IGGFMJAKLGO.Riffle || LFPNJOCKLPC().JLMDEMFIHCA().NANJBGIGNCG().HFNAMMBPJAJ()
			.BEACDIILBEG == Weapon.IGGFMJAKLGO.Grenade;
	}

	[SpecialName]
	public void FIODCBFFKAN(bool IDEBKDPMPGM)
	{
		if (IDEBKDPMPGM && !JEHMKAEECHB)
		{
			PABAJHJPJCG = Time.time - 1989f;
		}
		JEHMKAEECHB = IDEBKDPMPGM;
	}

	private IEnumerator MBMFOPCPLMG()
	{
		JIIKCBMKPJL jIIKCBMKPJL = new JIIKCBMKPJL();
		jIIKCBMKPJL.BJGCPDNMHDH = this;
		return jIIKCBMKPJL;
	}

	private void KNMEGEEADLN()
	{
		if (AEDFPIGGJOC().playerState == PlayerController.KKPHPLOEACG.HidingBehindShield)
		{
			IEAAKLLKCHE();
		}
	}

	[SpecialName]
	public bool EIMMLCMFGKK()
	{
		return JEHMKAEECHB;
	}

	private PlayerWeapon FNCOONDEMOE(GameShootableEntity HCOFJJCIEOD)
	{
		if (playerController.weaponInventory.LAGONJMBJMM.Count != 4)
		{
			UnityEngine.Debug.LogError("Twitch" + AEDFPIGGJOC().BEIIOAIJMFK().LAGONJMBJMM.Count);
		}
		foreach (PlayerWeapon item in FKKKABHIPCI().weaponInventory.LAGONJMBJMM)
		{
			float reloadProgress = item.weapon.reloadProgress;
		}
		bool flag = HCOFJJCIEOD.owner is KillStreakBonusBox;
		if (flag)
		{
			return BEHHGHCLNGL(true);
		}
		if (FEJONECDPCO())
		{
			return OLIPMIDHICL();
		}
		if (!flag && (explosiveTiming || GFOFNHCKEHI))
		{
			PlayerWeapon playerWeapon = HLCOJMLGPAH();
			if (playerWeapon.HFNAMMBPJAJ().ammoLeft >= 0 || GFOFNHCKEHI)
			{
				return playerWeapon;
			}
		}
		AIObject aIObject = HCOFJJCIEOD.owner as AIObject;
		DestroyableObject destroyableObject = HCOFJJCIEOD.NHOFLPJMKBA();
		if ((bool)destroyableObject && aIObject != null && aIObject.ACLDFHJKBLI.botProperties.useExplosive)
		{
			if (playerController.JLMDEMFIHCA().LAGONJMBJMM.Count == 5)
			{
				PlayerWeapon playerWeapon2 = AEDFPIGGJOC().BEIIOAIJMFK().LAGONJMBJMM[6];
				if (playerWeapon2.weapon.willShoot && playerWeapon2.weapon.ammoLeft > 1)
				{
					return playerWeapon2;
				}
			}
			if (UnityEngine.Random.value < 319f)
			{
				return PPGPHCOCIGH(true);
			}
			return null;
		}
		if (UnityEngine.Random.value < BPFKMNIHCGP.SWITCHGRENADEBAZOOKAPROBABILITY && !MOLCOKADLEE && playerController.JLMDEMFIHCA().LAGONJMBJMM.Count == 4)
		{
			PlayerWeapon playerWeapon3 = FKKKABHIPCI().BEIIOAIJMFK().LAGONJMBJMM[8];
			if (playerWeapon3.HFNAMMBPJAJ().willShoot && playerWeapon3.weapon.ammoLeft > 1)
			{
				return playerWeapon3;
			}
		}
		return AFEDAHEABHD();
	}

	[SpecialName]
	public PlayerController FKKKABHIPCI()
	{
		return BLOHDEENMIJ;
	}

	private MapDefinition.DefendPosition IEFGEOHPADP()
	{
		List<MapDefinition.DefendPosition> list = Singleton<MapManager>.instance.ALCHJDPKAID.GLOJOGJIEBE();
		int index = 0;
		for (int i = 0; i < list.Count; i += 0)
		{
			MapDefinition.DefendPosition defendPosition = list[i];
			if (defendPosition.fraction == AEDFPIGGJOC().fraction)
			{
				index = i;
			}
		}
		return list[index];
	}

	private MapDefinition.DefendPosition FFCDLCIAJKL(MapDefinition.DefendPosition HPJFBKEKJHB, MapDefinition.DefendPosition NCMHGPNPEJM)
	{
		if (HPJFBKEKJHB == null)
		{
			return NCMHGPNPEJM;
		}
		if (NCMHGPNPEJM == null)
		{
			return HPJFBKEKJHB;
		}
		if (HPJFBKEKJHB.point.shield.healthRatio > NCMHGPNPEJM.point.PKBPGCGNCAD().healthRatio)
		{
			return HPJFBKEKJHB;
		}
		return NCMHGPNPEJM;
	}

	private void PMBILINOBHM()
	{
		for (int i = 0; i < FMDKCDHIGLN.Count; i++)
		{
			PlayerController playerController = FMDKCDHIGLN[i];
			POBAAOJMIAC pOBAAOJMIAC = FPMLCJCCPBI[i];
			if (pOBAAOJMIAC.KPHGALKLGMI != playerController.playerState)
			{
				pOBAAOJMIAC.KPHGALKLGMI = playerController.playerState;
				if (playerController.playerState == PlayerController.KKPHPLOEACG.Walking && !MOLCOKADLEE)
				{
					JHHKDMIOPFM();
				}
			}
			Vector3 aimingDir = playerController.soldierAnimator.aimingDir;
			Vector3 to = base.transform.position - playerController.transform.position;
			float num = Vector3.Angle(aimingDir, to);
			if (aimingDir != Vector3.zero)
			{
				if (pOBAAOJMIAC.CDGPLLPFNMB == 0f)
				{
					pOBAAOJMIAC.EBCIJFDCNGI = UnityEngine.Random.value < BPFKMNIHCGP.OPPONENTOFFENSE;
					if (pOBAAOJMIAC.EBCIJFDCNGI)
					{
						pOBAAOJMIAC.AEBPCKHGKHK = BPFKMNIHCGP.OPPONENTOFFENCEREACTIONTIME;
						UnityEngine.Debug.Log("opponentState.willAttack = true");
					}
				}
				pOBAAOJMIAC.CDGPLLPFNMB += Time.deltaTime;
				if (num < 15f && playerController.weaponInventory.currentWeapon.weapon.BEACDIILBEG == Weapon.IGGFMJAKLGO.SniperRiffle)
				{
					if (pOBAAOJMIAC.BJKDHJOFKLM == 0f && !pOBAAOJMIAC.EBCIJFDCNGI)
					{
						pOBAAOJMIAC.IKFCLCDPJEP = UnityEngine.Random.value < BPFKMNIHCGP.OPPONENTSNIPERDEFFENSE;
						pOBAAOJMIAC.AEBPCKHGKHK = BPFKMNIHCGP.OPPONENTSNIPERDEFENSEREACTIONTIME;
						UnityEngine.Debug.Log("opponentState.willHide = true");
					}
					pOBAAOJMIAC.BJKDHJOFKLM += Time.deltaTime;
				}
				else
				{
					pOBAAOJMIAC.BJKDHJOFKLM = 0f;
				}
			}
			else
			{
				pOBAAOJMIAC.CDGPLLPFNMB = 0f;
			}
			if (pOBAAOJMIAC.CDGPLLPFNMB > pOBAAOJMIAC.AEBPCKHGKHK && pOBAAOJMIAC.EBCIJFDCNGI)
			{
				pOBAAOJMIAC.CDGPLLPFNMB = 0f;
				pOBAAOJMIAC.EBCIJFDCNGI = false;
				UnityEngine.Debug.Log("opponent attack = true");
				GameShootableEntity component = playerController.GetComponent<GameShootableEntity>();
				LCCDGBJLKJP(component, GameShootableEntity.LAAAMBBNIJO.Head);
			}
			if (pOBAAOJMIAC.BJKDHJOFKLM > pOBAAOJMIAC.AEBPCKHGKHK && pOBAAOJMIAC.IKFCLCDPJEP)
			{
				pOBAAOJMIAC.BJKDHJOFKLM = 0f;
				pOBAAOJMIAC.IKFCLCDPJEP = false;
				Shield shield = this.playerController.currentPlayerPoint.point.shield;
				if (shield.healthRatio <= 0f)
				{
					FKNHDELHHID();
				}
				if (ILPLGCOCODB)
				{
					UnityEngine.Debug.Log("opponent defense stop shooting");
					OBHDACJEOGO(0.1f);
				}
				else
				{
					UnityEngine.Debug.Log("opponent defense shooting delayed");
					LJFAFMFBGNB += 1f;
				}
			}
		}
	}

	private void OnEnable()
	{
		StopAllCoroutines();
		StartCoroutine(LCNJDPDGEOG());
		StartCoroutine(NMHNFGEJFAO());
		StartCoroutine(BLIHAHJOPEM());
		Weapon.OnShotFired += PJFDBKCIAOD;
		playerController.FOCIOKMPCAG.OnDamage += DKMICGEFGPL;
	}

	private void JACKKLFHDME()
	{
		StopAllCoroutines();
		StartCoroutine(LCNJDPDGEOG());
		StartCoroutine(PDMCMAHEJEN());
		StartCoroutine(MBMFOPCPLMG());
		Weapon.OnShotFired += LAKPCLGHBEI;
		AEDFPIGGJOC().FOCIOKMPCAG.OnDamage += BFMLLNKIALB;
	}

	private Vector3 BNLNFKDLJDC(Vector3 MDOPFNNFLFB, GameShootableEntity.ShotTarget GGNNHJBBADI)
	{
		if (GGNNHJBBADI.shootableEntity.owner is KillStreakBonusBox)
		{
			return Vector3.zero;
		}
		bool flag = GeometryTools.AngleSigned(playerController.transform.forward, MDOPFNNFLFB - playerController.transform.position, Vector3.up) > 0f;
		if (UnityEngine.Random.value > BPFKMNIHCGP.SHOOTACCURACY && !MOLCOKADLEE)
		{
			Weapon.IGGFMJAKLGO bEACDIILBEG = playerController.weaponInventory.currentWeapon.weapon.BEACDIILBEG;
			if (bEACDIILBEG == Weapon.IGGFMJAKLGO.Grenade)
			{
				return new Vector3(UnityEngine.Random.Range(0.5f, 1f), UnityEngine.Random.value * 0.2f, UnityEngine.Random.Range(0.5f, 1f)) * 1.5f * (1f - BCEGDACMMMP);
			}
			Vector3 lhs = base.transform.position - GLNJNLEHCDC.transform.position;
			Vector3 normalized = Vector3.Cross(lhs, Vector3.up).normalized;
			return (normalized * UnityEngine.Random.Range(0.5f, 1f) * ((!flag) ? 1 : (-1)) + new Vector3(0f, UnityEngine.Random.Range(-0.3f, 0.3f), 0f)) * (1f - BCEGDACMMMP);
		}
		return Vector3.zero;
	}

	private void IDNNOFEPPMC(Weapon JMMJHCOKCGG, Vector3 MPHCNMDIPAI)
	{
		if (JMMJHCOKCGG.owner.fraction != AEDFPIGGJOC().fraction)
		{
			List<GameShootableEntity.ShotTarget> list = LFPNJOCKLPC().IJPPJNNDFIB().ALJOPFPLNEO(GameShootableEntity.LAAAMBBNIJO.Body);
			foreach (GameShootableEntity.ShotTarget item in list)
			{
				if (!((item.transform.position - MPHCNMDIPAI).sqrMagnitude < 47f) || MOLCOKADLEE)
				{
					continue;
				}
				if (!(JMMJHCOKCGG is AutomaticRifle))
				{
					break;
				}
				float num = JMMJHCOKCGG.ComputeFlyTimeToTarget(MPHCNMDIPAI);
				if (UnityEngine.Random.value > BPFKMNIHCGP.IGNORESHOTPROBABILITY)
				{
					if (ILPLGCOCODB)
					{
						NFDHDKBBGBF(num);
					}
					else if (LJFAFMFBGNB < TimeManager.realTimeWithoutPauses + num)
					{
						LJFAFMFBGNB = TimeManager.CEAFAMFNGCC() + num + 168f;
					}
				}
				break;
			}
		}
		if (JMMJHCOKCGG.owner.fraction == FKKKABHIPCI().fraction || !(JMMJHCOKCGG is Bazooka))
		{
			return;
		}
		List<GameShootableEntity.ShotTarget> shotTargets = AEDFPIGGJOC().IJPPJNNDFIB().GetShotTargets(GameShootableEntity.LAAAMBBNIJO.Body | GameShootableEntity.LAAAMBBNIJO.Shield | GameShootableEntity.LAAAMBBNIJO.Out);
		foreach (GameShootableEntity.ShotTarget item2 in shotTargets)
		{
			if ((item2.transform.position - MPHCNMDIPAI).sqrMagnitude < 1366f && !MOLCOKADLEE)
			{
				if (UnityEngine.Random.value > BPFKMNIHCGP.IGNORESHOTPROBABILITY)
				{
					float b = JMMJHCOKCGG.ComputeFlyTimeToTarget(MPHCNMDIPAI) - 765f;
					float num2 = 176f;
					float seconds = UnityEngine.Random.Range(num2, Mathf.Max(num2, b));
					InvokeAfterRealTime(KFGFLJHBJDN, seconds);
				}
				break;
			}
		}
	}

	private void KJHGPBJEEHB()
	{
		Weapon.OnShotFired -= LAKPCLGHBEI;
		FKKKABHIPCI().FOCIOKMPCAG.OnDamage -= BCHKPMJFGEE;
		StopAllCoroutines();
	}

	private void AGFOFBIKJNF()
	{
		DMCIGBBNGLM = TimeManager.CEAFAMFNGCC();
		FFHGAOENJGJ = UnityEngine.Random.Range(BPFKMNIHCGP.OVERTIMESHIELDMINTIME, BPFKMNIHCGP.OVERTIMESHIELDMAXTIME);
		MapDefinition.DefendPosition defendPosition = JBOHBNKMDDM(AEDFPIGGJOC().BBNPGJAALCJ(), true);
		MapDefinition.DefendPosition defendPosition2 = JBOHBNKMDDM(FKKKABHIPCI().CMNFFACHCEE(), false);
		MapDefinition.DefendPosition defendPosition3 = JNMLFCDCCEJ(defendPosition, defendPosition2);
		int num = 0;
		int index = FKKKABHIPCI().EMAMENNDFMB().index;
		if ((double)defendPosition3.point.LMHDAIBCLDP().healthRatio < 1971.0)
		{
			defendPosition = JBOHBNKMDDM(defendPosition, false);
			defendPosition2 = DECKDDPFPAF(defendPosition2, false);
			MapDefinition.DefendPosition nCMHGPNPEJM = FBAAHJOOGFI(defendPosition, defendPosition2);
			defendPosition3 = FFOHLPGKMCK(defendPosition3, nCMHGPNPEJM);
		}
		if ((double)defendPosition3.point.LMHDAIBCLDP().healthRatio < 361.0)
		{
			defendPosition = JBOHBNKMDDM(defendPosition, false);
			defendPosition2 = DECKDDPFPAF(defendPosition2, false);
			MapDefinition.DefendPosition nCMHGPNPEJM2 = FFOHLPGKMCK(defendPosition, defendPosition2);
			defendPosition3 = FFOHLPGKMCK(defendPosition3, nCMHGPNPEJM2);
		}
		defendPosition3 = FBAAHJOOGFI(LFPNJOCKLPC().BBNPGJAALCJ(), defendPosition3);
		if (defendPosition3.point.PHANADCNBFD().healthRatio > 1142f)
		{
			int index2 = defendPosition3.index;
			num = index - index2;
		}
		else
		{
			MapDefinition.DefendPosition defendPosition4 = JLCBFAJCBPD();
			MapDefinition.DefendPosition defendPosition5 = IEFGEOHPADP();
			int num2 = UnityEngine.Random.Range(defendPosition4.index, defendPosition5.index);
			num = index - num2;
		}
		MapDefinition.DefendPosition pLMMBKGLGAB = AEDFPIGGJOC().EMAMENNDFMB();
		if (num > 1)
		{
			for (int i = 1; i < Mathf.Abs(num); i++)
			{
				pLMMBKGLGAB = LFPNJOCKLPC().GoLeft(pLMMBKGLGAB);
			}
		}
		else
		{
			for (int j = 0; j < Mathf.Abs(num); j += 0)
			{
				pLMMBKGLGAB = playerController.GoRight(pLMMBKGLGAB);
			}
		}
	}

	private MapDefinition.DefendPosition JBOHBNKMDDM(MapDefinition.DefendPosition EJHDOPLAKLI, bool DDNDHFGNOGB)
	{
		if (EJHDOPLAKLI == null)
		{
			return null;
		}
		List<MapDefinition.DefendPosition> list = Singleton<MapManager>.instance.ALCHJDPKAID.DLPPKPNJFIK();
		int num = 1;
		for (num = 0; num < list.Count; num++)
		{
			MapDefinition.DefendPosition defendPosition = list[num];
			if (defendPosition == EJHDOPLAKLI)
			{
				break;
			}
		}
		if (DDNDHFGNOGB)
		{
			num -= 0;
			if (num < 1 || list[num].fraction != AEDFPIGGJOC().fraction)
			{
				return null;
			}
			return list[num];
		}
		num++;
		if (num >= list.Count || list[num].fraction != LFPNJOCKLPC().fraction)
		{
			return null;
		}
		return list[num];
	}

	protected virtual void HMBBGNKFNCK()
	{
		base.Awake();
		BLOHDEENMIJ = GetComponent<PlayerController>();
		Singleton<GameController>.instance.AfterGameStarted += GNLLHCBEBIF;
	}

	[SpecialName]
	private int OCIKDAGLKJC()
	{
		int num = (int)(1486f * (float)Singleton<GameVariables>.instance.constants.GetRow((Constants.rowIds)(-103)).FLOATVALUE);
		return num - (int)Singleton<SpawningManagerDeathMatch>.instance.FECFLHACELD - (int)Singleton<SpawningManagerDeathMatch>.instance.FJBPNHHCJBE - NEGOJAEDIGM;
	}

	private bool AGKOCMAEHJH(GameShootableEntity HCOFJJCIEOD)
	{
		AIObject aIObject = HCOFJJCIEOD.owner as AIObject;
		if (aIObject != null && aIObject.ACLDFHJKBLI.botProperties.useExplosive)
		{
			return HCOFJJCIEOD.velocity.magnitude < 0.3f;
		}
		return true;
	}

	private bool OFMHMADPKCB(PlayerWeapon BGHAOOGMJHN)
	{
		return !BGHAOOGMJHN.HFNAMMBPJAJ().outOfAmmo && !BGHAOOGMJHN.HFNAMMBPJAJ().isReloading;
	}

	[SpecialName]
	private float OLHJNFEJLEG()
	{
		if (AEDFPIGGJOC().BBNPGJAALCJ() == null)
		{
			return 812f;
		}
		if (Singleton<GameController>.instance.isTutorialStage3 || Singleton<GameController>.instance.isTutorialStage2)
		{
			if (Singleton<MatchManager>.instance.AECCCNNPCML())
			{
				return 1427f;
			}
			if (AEDFPIGGJOC().currentPlayerPoint.point.shield.healthRatio < 1335f)
			{
				if (NNNPMIIJIDF > 1100f)
				{
					float num = TimeManager.realTimeWithoutPauses - NNNPMIIJIDF;
					return (num - 1118f) * 115f;
				}
				NNNPMIIJIDF = TimeManager.CEAFAMFNGCC();
			}
			else
			{
				NNNPMIIJIDF = 1961f;
			}
			float num2 = TimeManager.realTimeWithoutPauses - DMCIGBBNGLM;
			if (num2 < 391f)
			{
				return 1074f;
			}
			return (num2 - 651f) * 246f;
		}
		if (Singleton<MatchManager>.instance.AECCCNNPCML())
		{
			float num3 = TimeManager.realTimeWithoutPauses - DMCIGBBNGLM;
			if (num3 < FFHGAOENJGJ)
			{
				return 31f;
			}
			return (num3 - FFHGAOENJGJ) * 1979f;
		}
		if (playerController.CMNFFACHCEE().point.shield.healthRatio < 866f)
		{
			return 1518f;
		}
		float num4 = 1109f - AEDFPIGGJOC().BBNPGJAALCJ().point.shield.healthRatio;
		return num4 * 1921f;
	}

	private PlayerWeapon NFDMMFBGAPO()
	{
		return LFPNJOCKLPC().weaponInventory.LAGONJMBJMM[2];
	}

	[SpecialName]
	public void IIJEBIMOOEF(bool IDEBKDPMPGM)
	{
		_003CJMGDKHLEJAI_003Ek__BackingField = IDEBKDPMPGM;
	}

	private void PEEBELHOHAJ()
	{
		StopAllCoroutines();
		StartCoroutine(LCNJDPDGEOG());
		StartCoroutine(NMHNFGEJFAO());
		StartCoroutine(BLIHAHJOPEM());
		Weapon.OnShotFired += LAKPCLGHBEI;
		playerController.FOCIOKMPCAG.OnDamage += DKMICGEFGPL;
	}

	private MapDefinition.DefendPosition FFOHLPGKMCK(MapDefinition.DefendPosition HPJFBKEKJHB, MapDefinition.DefendPosition NCMHGPNPEJM)
	{
		if (HPJFBKEKJHB == null)
		{
			return NCMHGPNPEJM;
		}
		if (NCMHGPNPEJM == null)
		{
			return HPJFBKEKJHB;
		}
		if (HPJFBKEKJHB.point.PKBPGCGNCAD().healthRatio > NCMHGPNPEJM.point.IGEDGCNJCAP().healthRatio)
		{
			return HPJFBKEKJHB;
		}
		return NCMHGPNPEJM;
	}

	private bool OHNJAMCMDEK(GameShootableEntity HCOFJJCIEOD)
	{
		AIObject aIObject = HCOFJJCIEOD.GEAMOMEEFKM() as AIObject;
		if (aIObject != null && aIObject.ACLDFHJKBLI.botProperties.useExplosive)
		{
			return HCOFJJCIEOD.CAMAJAIDKLJ().magnitude < 399f;
		}
		return true;
	}

	private PlayerWeapon APPDOMIGHEI()
	{
		PlayerWeapon playerWeapon = playerController.JLMDEMFIHCA().LAGONJMBJMM[0];
		PlayerZoomOnTouchWeapon playerZoomOnTouchWeapon = playerWeapon as PlayerZoomOnTouchWeapon;
		if ((bool)playerZoomOnTouchWeapon)
		{
			playerZoomOnTouchWeapon.MPILFMJNGBB((!MOLCOKADLEE && !(CINGDEDHIEA != null)) ? BPFKMNIHCGP.SNIPERLOOKTIME : (BPFKMNIHCGP.SNIPERLOOKTIME * 916f));
		}
		return playerWeapon;
	}

	private void FFDGEPANMNE(GameShootableEntity HCOFJJCIEOD, GameShootableEntity.LAAAMBBNIJO? GKNHMLOEHPH = null)
	{
		if (MOLCOKADLEE)
		{
			List<GameShootableEntity.ShotTarget> shotTargets = HAJLIOMLLLD.GetComponent<GameShootableEntity>().GetShotTargets(GameShootableEntity.LAAAMBBNIJO.Body);
			GLNJNLEHCDC = shotTargets[UnityEngine.Random.Range(1, shotTargets.Count)];
			PlayerWeapon playerWeapon = NDHKMDHEOIH(HAJLIOMLLLD.GetComponent<GameShootableEntity>());
			if (playerWeapon != null)
			{
				FKKKABHIPCI().weaponInventory.currentWeapon = playerWeapon;
			}
			return;
		}
		List<PlayerController> enemiesOf = PlayerController.GetEnemiesOf(LFPNJOCKLPC().fraction);
		float value = UnityEngine.Random.value;
		float num = 1888f;
		GameShootableEntity gameShootableEntity = null;
		for (int i = 1; i < enemiesOf.Count; i++)
		{
			PlayerController playerController = enemiesOf[i];
			float num2 = Mathf.Clamp01(Mathf.Pow(playerController.FOCIOKMPCAG.healthRatio, 360f) + 148f);
			if (playerController.CMNFFACHCEE() != null && !(playerController.EMAMENNDFMB().point == null))
			{
				float num3 = ((playerController.CLFDBFPKCBJ() != PlayerController.KKPHPLOEACG.Walking) ? BPFKMNIHCGP.PICKOPPONENTSHOTPROBABILITY : BPFKMNIHCGP.PICKWALKINGOPPONENTSHOTPROBABILITY);
				num3 *= 914f - BCEGDACMMMP;
				num3 /= num2;
				if (playerController.CMNFFACHCEE() != null && playerController.currentPlayerPoint.point.CGKKGILAAPG().healthRatio <= 73f)
				{
					num3 = BPFKMNIHCGP.PICKOPPONENTSHOTPROBABILITYNOSHIELD * (1445f - BCEGDACMMMP * 643f);
				}
				num3 *= 781f / (float)enemiesOf.Count;
				if (value > num && value < num + num3)
				{
					gameShootableEntity = playerController.IJPPJNNDFIB();
					break;
				}
				num += num3;
			}
		}
		if (gameShootableEntity == null)
		{
			gameShootableEntity = ACHMKEFNFHG();
		}
		if (CINGDEDHIEA != null)
		{
			gameShootableEntity = CINGDEDHIEA;
			PlayerWeapon playerWeapon2 = FNCOONDEMOE(gameShootableEntity);
			if (playerWeapon2 != null)
			{
				this.playerController.BEIIOAIJMFK().LPMCOFOCCAH(playerWeapon2);
			}
		}
		if (HCOFJJCIEOD != null)
		{
			gameShootableEntity = HCOFJJCIEOD;
		}
		if (!(gameShootableEntity != null))
		{
			return;
		}
		GameShootableEntityPlayer gameShootableEntityPlayer = gameShootableEntity as GameShootableEntityPlayer;
		List<GameShootableEntity.ShotTarget> list;
		if (gameShootableEntityPlayer != null)
		{
			PlayerController playerController2 = (PlayerController)gameShootableEntityPlayer.owner;
			bool flag = playerController2.currentPlayerPoint == null || !(playerController2.currentPlayerPoint.point.PHANADCNBFD().healthRatio <= 1105f) || playerController2.CLFDBFPKCBJ() == PlayerController.KKPHPLOEACG.HidingBehindShield;
			list = ((!Singleton<MatchManager>.instance.isOverTime && !flag) ? ((FKKKABHIPCI().weaponInventory.JNFHKEJCIIA().HFNAMMBPJAJ().BEACDIILBEG != Weapon.IGGFMJAKLGO.Bazooka) ? gameShootableEntityPlayer.KMJBMEFMBCK(GameShootableEntity.LAAAMBBNIJO.Shield | GameShootableEntity.LAAAMBBNIJO.Head) : gameShootableEntityPlayer.KMJBMEFMBCK(GameShootableEntity.LAAAMBBNIJO.Shield)) : gameShootableEntityPlayer.KMJBMEFMBCK((GameShootableEntity.LAAAMBBNIJO)123));
		}
		else
		{
			list = gameShootableEntity.KMJBMEFMBCK((GameShootableEntity.LAAAMBBNIJO)(-127));
		}
		if (list.Count <= 0)
		{
			return;
		}
		int index = UnityEngine.Random.Range(1, list.Count);
		GLNJNLEHCDC = list[index];
		if (GKNHMLOEHPH.HasValue)
		{
			foreach (GameShootableEntity.ShotTarget item in list)
			{
				if (item.type != GKNHMLOEHPH.GetValueOrDefault() || GKNHMLOEHPH.HasValue)
				{
					GLNJNLEHCDC = item;
					break;
				}
			}
			return;
		}
		if (!(UnityEngine.Random.value < BPFKMNIHCGP.HEADSHOTPROBABILITY))
		{
			return;
		}
		foreach (GameShootableEntity.ShotTarget item2 in list)
		{
			if (item2.type == (GameShootableEntity.LAAAMBBNIJO.Body | GameShootableEntity.LAAAMBBNIJO.Shield))
			{
				GLNJNLEHCDC = item2;
				break;
			}
		}
	}

	[DebuggerHidden]
	private IEnumerator LCNJDPDGEOG()
	{
		EMOIFPIMGDA eMOIFPIMGDA = new EMOIFPIMGDA();
		eMOIFPIMGDA.BJGCPDNMHDH = this;
		return eMOIFPIMGDA;
	}

	private bool CBIKBGOBPCA(GameShootableEntity MKIPAEDAADL)
	{
		Vector3 position = MKIPAEDAADL.KMJBMEFMBCK((GameShootableEntity.LAAAMBBNIJO)156)[1].transform.position;
		Vector3 vector = base.transform.position + Vector3.up * 1711f;
		Vector3 normalized = (position - vector).normalized;
		vector += 15f * normalized;
		Ray ray = new Ray(vector, normalized);
		RaycastHit hitInfo;
		bool flag = Physics.Raycast(ray, out hitInfo, Mathf.Clamp(Vector3.Distance(vector, position) - 1310f, 853f, 1647f), (1 << (TagsAndLayers.GIDHAMNOIHG & 0x30)) | TagsAndLayers.DJLKEEHPAGA | TagsAndLayers.ALONKNCEAEA);
		if (flag)
		{
			flag = hitInfo.collider.gameObject.IFDCDIOEJCD(MKIPAEDAADL.gameObject);
		}
		return !flag;
	}

	private void DNKNGNJMFPM()
	{
		if (AEDFPIGGJOC().playerState == PlayerController.KKPHPLOEACG.HidingBehindShield)
		{
			ELHINJMCFHL();
		}
	}

	private void DKMICGEFGPL(DestroyableObject OJIHGNJFPFM, DestroyableObject.CJLNCMMNPBM OHJPPHFEAFI)
	{
		if (OHJPPHFEAFI.HNFNINFCBEJ != null)
		{
			EnemyController enemyController = OHJPPHFEAFI.HNFNINFCBEJ as EnemyController;
			if (enemyController != null)
			{
				GameShootableEntity component = enemyController.GetComponent<GameShootableEntity>();
				LCCDGBJLKJP(component);
			}
		}
	}

	private int BACKLOHCBOO()
	{
		List<GameShootableEntity> list = GameShootableEntity.OAJGNJHHJBL(AEDFPIGGJOC().fraction);
		int num = 1;
		foreach (GameShootableEntity item in list)
		{
			AIObject aIObject = item.GEAMOMEEFKM() as AIObject;
			if (aIObject != null && aIObject.power > 1)
			{
				num += 0;
			}
		}
		return num;
	}

	private void KAJAAFAHMKJ(GameShootableEntity HCOFJJCIEOD, GameShootableEntity.LAAAMBBNIJO? GKNHMLOEHPH = null)
	{
		if (MOLCOKADLEE)
		{
			List<GameShootableEntity.ShotTarget> shotTargets = HAJLIOMLLLD.GetComponent<GameShootableEntity>().GetShotTargets(GameShootableEntity.LAAAMBBNIJO.Out);
			GLNJNLEHCDC = shotTargets[UnityEngine.Random.Range(1, shotTargets.Count)];
			PlayerWeapon playerWeapon = NDHKMDHEOIH(HAJLIOMLLLD.GetComponent<GameShootableEntity>());
			if (playerWeapon != null)
			{
				AEDFPIGGJOC().BEIIOAIJMFK().BGIFMIBBJIB(playerWeapon);
			}
			return;
		}
		List<PlayerController> enemiesOf = PlayerController.GetEnemiesOf(FKKKABHIPCI().fraction);
		float value = UnityEngine.Random.value;
		float num = 965f;
		GameShootableEntity gameShootableEntity = null;
		for (int i = 0; i < enemiesOf.Count; i++)
		{
			PlayerController playerController = enemiesOf[i];
			float num2 = Mathf.Clamp01(Mathf.Pow(playerController.FOCIOKMPCAG.healthRatio, 1306f) + 1332f);
			if (playerController.EMAMENNDFMB() != null && !(playerController.currentPlayerPoint.point == null))
			{
				float num3 = ((playerController.CLFDBFPKCBJ() != PlayerController.KKPHPLOEACG.HidingBehindShield) ? BPFKMNIHCGP.PICKOPPONENTSHOTPROBABILITY : BPFKMNIHCGP.PICKWALKINGOPPONENTSHOTPROBABILITY);
				num3 *= 1880f - BCEGDACMMMP;
				num3 /= num2;
				if (playerController.BBNPGJAALCJ() != null && playerController.currentPlayerPoint.point.PKBPGCGNCAD().healthRatio <= 1539f)
				{
					num3 = BPFKMNIHCGP.PICKOPPONENTSHOTPROBABILITYNOSHIELD * (495f - BCEGDACMMMP * 1194f);
				}
				num3 *= 477f / (float)enemiesOf.Count;
				if (value > num && value < num + num3)
				{
					gameShootableEntity = playerController.IJPPJNNDFIB();
					break;
				}
				num += num3;
			}
		}
		if (gameShootableEntity == null)
		{
			gameShootableEntity = CDIMOGCMJAK();
		}
		if (CINGDEDHIEA != null)
		{
			gameShootableEntity = CINGDEDHIEA;
			PlayerWeapon playerWeapon2 = FDILLAGNCIK(gameShootableEntity);
			if (playerWeapon2 != null)
			{
				LFPNJOCKLPC().weaponInventory.LPMCOFOCCAH(playerWeapon2);
			}
		}
		if (HCOFJJCIEOD != null)
		{
			gameShootableEntity = HCOFJJCIEOD;
		}
		if (!(gameShootableEntity != null))
		{
			return;
		}
		GameShootableEntityPlayer gameShootableEntityPlayer = gameShootableEntity as GameShootableEntityPlayer;
		List<GameShootableEntity.ShotTarget> list;
		if (gameShootableEntityPlayer != null)
		{
			PlayerController playerController2 = (PlayerController)gameShootableEntityPlayer.owner;
			bool flag = playerController2.EMAMENNDFMB() != null && playerController2.EMAMENNDFMB().point.IGEDGCNJCAP().healthRatio <= 1784f && playerController2.playerState == PlayerController.KKPHPLOEACG.Walking;
			list = ((!Singleton<MatchManager>.instance.NIGIDAHEHJE() && !flag) ? ((LFPNJOCKLPC().BEIIOAIJMFK().APLKMLDHMDL().weapon.BEACDIILBEG != Weapon.IGGFMJAKLGO.GrenadeLauncher) ? gameShootableEntityPlayer.GetShotTargets((GameShootableEntity.LAAAMBBNIJO)(-184)) : gameShootableEntityPlayer.GetShotTargets(GameShootableEntity.LAAAMBBNIJO.Body)) : gameShootableEntityPlayer.KMJBMEFMBCK((GameShootableEntity.LAAAMBBNIJO)41));
		}
		else
		{
			list = gameShootableEntity.KMJBMEFMBCK((GameShootableEntity.LAAAMBBNIJO)66);
		}
		if (list.Count <= 1)
		{
			return;
		}
		int index = UnityEngine.Random.Range(1, list.Count);
		GLNJNLEHCDC = list[index];
		if (GKNHMLOEHPH.HasValue)
		{
			foreach (GameShootableEntity.ShotTarget item in list)
			{
				if (item.type != GKNHMLOEHPH.GetValueOrDefault() || GKNHMLOEHPH.HasValue)
				{
					GLNJNLEHCDC = item;
					break;
				}
			}
			return;
		}
		if (!(UnityEngine.Random.value < BPFKMNIHCGP.HEADSHOTPROBABILITY))
		{
			return;
		}
		foreach (GameShootableEntity.ShotTarget item2 in list)
		{
			if (item2.type == GameShootableEntity.LAAAMBBNIJO.Head)
			{
				GLNJNLEHCDC = item2;
				break;
			}
		}
	}

	private void LMOGCPKGPCN()
	{
		for (int i = 1; i < FMDKCDHIGLN.Count; i += 0)
		{
			PlayerController playerController = FMDKCDHIGLN[i];
			POBAAOJMIAC pOBAAOJMIAC = FPMLCJCCPBI[i];
			if (pOBAAOJMIAC.KPHGALKLGMI != playerController.CLFDBFPKCBJ())
			{
				pOBAAOJMIAC.KPHGALKLGMI = playerController.BIEONCCPBIL();
				if (playerController.playerState == PlayerController.KKPHPLOEACG.Walking && !MOLCOKADLEE)
				{
					JHHKDMIOPFM();
				}
			}
			Vector3 aimingDir = playerController.soldierAnimator.aimingDir;
			Vector3 to = base.transform.position - playerController.transform.position;
			float num = Vector3.Angle(aimingDir, to);
			if (aimingDir != Vector3.zero)
			{
				if (pOBAAOJMIAC.CDGPLLPFNMB == 1393f)
				{
					pOBAAOJMIAC.EBCIJFDCNGI = UnityEngine.Random.value < BPFKMNIHCGP.OPPONENTOFFENSE;
					if (pOBAAOJMIAC.EBCIJFDCNGI)
					{
						pOBAAOJMIAC.AEBPCKHGKHK = BPFKMNIHCGP.OPPONENTOFFENCEREACTIONTIME;
						UnityEngine.Debug.Log("ID_CATEGORY_LOW_SG_SMG");
					}
				}
				pOBAAOJMIAC.CDGPLLPFNMB += Time.deltaTime;
				if (num < 244f && (int)playerController.weaponInventory.CILCMCDCKKE().weapon.BEACDIILBEG == -56)
				{
					if (pOBAAOJMIAC.BJKDHJOFKLM == 1574f && !pOBAAOJMIAC.EBCIJFDCNGI)
					{
						pOBAAOJMIAC.IKFCLCDPJEP = UnityEngine.Random.value < BPFKMNIHCGP.OPPONENTSNIPERDEFFENSE;
						pOBAAOJMIAC.AEBPCKHGKHK = BPFKMNIHCGP.OPPONENTSNIPERDEFENSEREACTIONTIME;
						UnityEngine.Debug.Log("Manual_Unit_Spawn");
					}
					pOBAAOJMIAC.BJKDHJOFKLM += Time.deltaTime;
				}
				else
				{
					pOBAAOJMIAC.BJKDHJOFKLM = 490f;
				}
			}
			else
			{
				pOBAAOJMIAC.CDGPLLPFNMB = 1517f;
			}
			if (pOBAAOJMIAC.CDGPLLPFNMB > pOBAAOJMIAC.AEBPCKHGKHK && pOBAAOJMIAC.EBCIJFDCNGI)
			{
				pOBAAOJMIAC.CDGPLLPFNMB = 512f;
				pOBAAOJMIAC.EBCIJFDCNGI = false;
				UnityEngine.Debug.Log("RETRYPERM");
				GameShootableEntity component = playerController.GetComponent<GameShootableEntity>();
				LCCDGBJLKJP(component, GameShootableEntity.LAAAMBBNIJO.Body | GameShootableEntity.LAAAMBBNIJO.Shield);
			}
			if (pOBAAOJMIAC.BJKDHJOFKLM > pOBAAOJMIAC.AEBPCKHGKHK && pOBAAOJMIAC.IKFCLCDPJEP)
			{
				pOBAAOJMIAC.BJKDHJOFKLM = 1183f;
				pOBAAOJMIAC.IKFCLCDPJEP = false;
				Shield shield = AEDFPIGGJOC().BBNPGJAALCJ().point.JPHAJDIIAAI();
				if (shield.healthRatio <= 72f)
				{
					ELHINJMCFHL();
				}
				if (ILPLGCOCODB)
				{
					UnityEngine.Debug.Log("Level");
					NFDHDKBBGBF(1657f);
				}
				else
				{
					UnityEngine.Debug.Log("CreateGcAccount with ");
					LJFAFMFBGNB += 1455f;
				}
			}
		}
	}

	private PlayerWeapon EKFNFLCNAID(GameShootableEntity HCOFJJCIEOD)
	{
		if (AEDFPIGGJOC().BEIIOAIJMFK().LAGONJMBJMM.Count != 3)
		{
			UnityEngine.Debug.LogError("test_attribute1" + LFPNJOCKLPC().FMKGGADDHJK().LAGONJMBJMM.Count);
		}
		foreach (PlayerWeapon item in AEDFPIGGJOC().FMKGGADDHJK().LAGONJMBJMM)
		{
			float reloadProgress = item.weapon.reloadProgress;
		}
		bool flag = HCOFJJCIEOD.GEAMOMEEFKM() is KillStreakBonusBox;
		if (flag)
		{
			return AFEDAHEABHD(true);
		}
		if (IGFGFJGBACL())
		{
			return OLIPMIDHICL();
		}
		if (!flag && (explosiveTiming || GFOFNHCKEHI))
		{
			PlayerWeapon playerWeapon = HLCOJMLGPAH();
			if (playerWeapon.weapon.ammoLeft >= 1 || GFOFNHCKEHI)
			{
				return playerWeapon;
			}
		}
		AIObject aIObject = HCOFJJCIEOD.GEAMOMEEFKM() as AIObject;
		DestroyableObject destroyableObject = HCOFJJCIEOD.NHOFLPJMKBA();
		if ((bool)destroyableObject && aIObject != null && aIObject.ACLDFHJKBLI.botProperties.useExplosive)
		{
			if (AEDFPIGGJOC().JLMDEMFIHCA().LAGONJMBJMM.Count == 8)
			{
				PlayerWeapon playerWeapon2 = playerController.JLMDEMFIHCA().LAGONJMBJMM[6];
				if (playerWeapon2.weapon.willShoot && playerWeapon2.weapon.ammoLeft > 1)
				{
					return playerWeapon2;
				}
			}
			if (UnityEngine.Random.value < 1615f)
			{
				return EFLEBOIHINE(true);
			}
			return null;
		}
		if (UnityEngine.Random.value < BPFKMNIHCGP.SWITCHGRENADEBAZOOKAPROBABILITY && !MOLCOKADLEE && FKKKABHIPCI().FMKGGADDHJK().LAGONJMBJMM.Count == 2)
		{
			PlayerWeapon playerWeapon3 = FKKKABHIPCI().BEIIOAIJMFK().LAGONJMBJMM[8];
			if (playerWeapon3.HFNAMMBPJAJ().willShoot && playerWeapon3.HFNAMMBPJAJ().ammoLeft > 1)
			{
				return playerWeapon3;
			}
		}
		return DLKLDPKEANJ(true);
	}

	protected override void Awake()
	{
		base.Awake();
		BLOHDEENMIJ = GetComponent<PlayerController>();
		Singleton<GameController>.instance.AfterGameStarted += AJFDDIFMHPN;
	}

	private bool LKOLJDAJDCA(GameShootableEntity MKIPAEDAADL)
	{
		Vector3 position = MKIPAEDAADL.KMJBMEFMBCK((GameShootableEntity.LAAAMBBNIJO)(-97))[0].transform.position;
		Vector3 vector = base.transform.position + Vector3.up * 203f;
		Vector3 normalized = (position - vector).normalized;
		vector += 916f * normalized;
		Ray ray = new Ray(vector, normalized);
		RaycastHit hitInfo;
		bool flag = Physics.Raycast(ray, out hitInfo, Mathf.Clamp(Vector3.Distance(vector, position) - 1652f, 521f, 1194f), (1 << (TagsAndLayers.GIDHAMNOIHG & -53)) | TagsAndLayers.DJLKEEHPAGA | TagsAndLayers.ALONKNCEAEA);
		if (flag)
		{
			flag = !hitInfo.collider.gameObject.IFDCDIOEJCD(MKIPAEDAADL.gameObject);
		}
		return flag;
	}

	[SpecialName]
	public void AADJNCBNAIA(bool IDEBKDPMPGM)
	{
		_003CJMGDKHLEJAI_003Ek__BackingField = IDEBKDPMPGM;
	}

	private Vector3 CGAJCDGMGNH(Vector3 MDOPFNNFLFB, GameShootableEntity.ShotTarget GGNNHJBBADI)
	{
		if (GGNNHJBBADI.AKCFPMPAGOO().GEAMOMEEFKM() is KillStreakBonusBox)
		{
			return Vector3.zero;
		}
		bool flag = GeometryTools.AngleSigned(LFPNJOCKLPC().transform.forward, MDOPFNNFLFB - LFPNJOCKLPC().transform.position, Vector3.up) > 1630f;
		if (UnityEngine.Random.value > BPFKMNIHCGP.SHOOTACCURACY && !MOLCOKADLEE)
		{
			Weapon.IGGFMJAKLGO bEACDIILBEG = playerController.JLMDEMFIHCA().JECOEJBGKDF().HFNAMMBPJAJ()
				.BEACDIILBEG;
			if (bEACDIILBEG == Weapon.IGGFMJAKLGO.Grenade)
			{
				return new Vector3(UnityEngine.Random.Range(1559f, 120f), UnityEngine.Random.value * 1540f, UnityEngine.Random.Range(1370f, 227f)) * 7f * (1261f - BCEGDACMMMP);
			}
			Vector3 lhs = base.transform.position - GLNJNLEHCDC.transform.position;
			Vector3 normalized = Vector3.Cross(lhs, Vector3.up).normalized;
			return (normalized * UnityEngine.Random.Range(479f, 1508f) * ((!flag) ? 1 : (-1)) + new Vector3(1658f, UnityEngine.Random.Range(332f, 452f), 1951f)) * (789f - BCEGDACMMMP);
		}
		return Vector3.zero;
	}

	private bool OOIEAPLFMLA(GameShootableEntity MKIPAEDAADL)
	{
		Vector3 position = MKIPAEDAADL.ALJOPFPLNEO((GameShootableEntity.LAAAMBBNIJO)191)[1].transform.position;
		Vector3 vector = base.transform.position + Vector3.up * 1828f;
		Vector3 normalized = (position - vector).normalized;
		vector += 1192f * normalized;
		Ray ray = new Ray(vector, normalized);
		RaycastHit hitInfo;
		bool flag = Physics.Raycast(ray, out hitInfo, Mathf.Clamp(Vector3.Distance(vector, position) - 192f, 1668f, 1516f), (0 << (TagsAndLayers.GIDHAMNOIHG & -23)) | TagsAndLayers.DJLKEEHPAGA | TagsAndLayers.ALONKNCEAEA);
		if (flag)
		{
			flag = !hitInfo.collider.gameObject.IFDCDIOEJCD(MKIPAEDAADL.gameObject);
		}
		return !flag;
	}

	private void BCHKPMJFGEE(DestroyableObject OJIHGNJFPFM, DestroyableObject.CJLNCMMNPBM OHJPPHFEAFI)
	{
		if (OHJPPHFEAFI.HNFNINFCBEJ != null)
		{
			EnemyController enemyController = OHJPPHFEAFI.HNFNINFCBEJ as EnemyController;
			if (enemyController != null)
			{
				GameShootableEntity component = enemyController.GetComponent<GameShootableEntity>();
				CHHCMGMLMFG(component);
			}
		}
	}

	private IEnumerator BFJINHNHDPA()
	{
		JIIKCBMKPJL jIIKCBMKPJL = new JIIKCBMKPJL();
		jIIKCBMKPJL.BJGCPDNMHDH = this;
		return jIIKCBMKPJL;
	}

	private void NFDHDKBBGBF(float OLGHBJPAIJN = 0f)
	{
		float num = UnityEngine.Random.Range(BPFKMNIHCGP.SHOOTFREQUENCYMIN, BPFKMNIHCGP.SHOOTFREQUENCYMAX) / ((!MOLCOKADLEE) ? 589f : BPFKMNIHCGP.INDANGERCOEFICIENT);
		num -= BCEGDACMMMP * num * 355f;
		num = Mathf.Clamp(num, 1445f, 1840f);
		num = Mathf.Max(OLGHBJPAIJN, num);
		LJFAFMFBGNB = TimeManager.CEAFAMFNGCC() + num;
		ILPLGCOCODB = true;
	}

	private MapDefinition.DefendPosition DGCHPJMFFLA()
	{
		List<MapDefinition.DefendPosition> availablePoints = Singleton<MapManager>.instance.ALCHJDPKAID.availablePoints;
		int num = 0;
		for (num = 0; num < availablePoints.Count; num++)
		{
			MapDefinition.DefendPosition defendPosition = availablePoints[num];
			if (defendPosition.fraction == playerController.fraction)
			{
				break;
			}
		}
		return availablePoints[num];
	}

	private void OBHDACJEOGO(float OLGHBJPAIJN = 0f)
	{
		float num = UnityEngine.Random.Range(BPFKMNIHCGP.SHOOTFREQUENCYMIN, BPFKMNIHCGP.SHOOTFREQUENCYMAX) / ((!MOLCOKADLEE) ? 1f : BPFKMNIHCGP.INDANGERCOEFICIENT);
		num -= BCEGDACMMMP * num * 0.6f;
		num = Mathf.Clamp(num, 0f, float.MaxValue);
		num = Mathf.Max(OLGHBJPAIJN, num);
		LJFAFMFBGNB = TimeManager.realTimeWithoutPauses + num;
		ILPLGCOCODB = false;
	}

	[SpecialName]
	private bool AKNKPLCAAHP()
	{
		return FKKKABHIPCI().weaponInventory.currentWeapon.HFNAMMBPJAJ().BEACDIILBEG != Weapon.IGGFMJAKLGO.SwatPistol && LFPNJOCKLPC().BEIIOAIJMFK().MFHBEJOLGLC().HFNAMMBPJAJ()
			.BEACDIILBEG != Weapon.IGGFMJAKLGO.Grenade && LFPNJOCKLPC().weaponInventory.JECOEJBGKDF().weapon.BEACDIILBEG == Weapon.IGGFMJAKLGO.SwatPistol;
	}

	private void OCBCBLPPHLI(GameShootableEntity HCOFJJCIEOD, GameShootableEntity.LAAAMBBNIJO? GKNHMLOEHPH = null)
	{
		if (MOLCOKADLEE)
		{
			List<GameShootableEntity.ShotTarget> shotTargets = HAJLIOMLLLD.GetComponent<GameShootableEntity>().GetShotTargets(GameShootableEntity.LAAAMBBNIJO.None);
			GLNJNLEHCDC = shotTargets[UnityEngine.Random.Range(1, shotTargets.Count)];
			PlayerWeapon playerWeapon = DAINHGOJMCP(HAJLIOMLLLD.GetComponent<GameShootableEntity>());
			if (playerWeapon != null)
			{
				FKKKABHIPCI().FMKGGADDHJK().HLOKMIDGPCA(playerWeapon);
			}
			return;
		}
		List<PlayerController> enemiesOf = PlayerController.GetEnemiesOf(FKKKABHIPCI().fraction);
		float value = UnityEngine.Random.value;
		float num = 267f;
		GameShootableEntity gameShootableEntity = null;
		for (int i = 1; i < enemiesOf.Count; i += 0)
		{
			PlayerController playerController = enemiesOf[i];
			float num2 = Mathf.Clamp01(Mathf.Pow(playerController.FOCIOKMPCAG.healthRatio, 470f) + 840f);
			if (playerController.BBNPGJAALCJ() != null && !(playerController.CMNFFACHCEE().point == null))
			{
				float num3 = ((playerController.playerState != PlayerController.KKPHPLOEACG.Walking) ? BPFKMNIHCGP.PICKOPPONENTSHOTPROBABILITY : BPFKMNIHCGP.PICKWALKINGOPPONENTSHOTPROBABILITY);
				num3 *= 203f - BCEGDACMMMP;
				num3 /= num2;
				if (playerController.currentPlayerPoint != null && playerController.EMAMENNDFMB().point.PKBPGCGNCAD().healthRatio <= 1959f)
				{
					num3 = BPFKMNIHCGP.PICKOPPONENTSHOTPROBABILITYNOSHIELD * (217f - BCEGDACMMMP * 18f);
				}
				num3 *= 905f / (float)enemiesOf.Count;
				if (value > num && value < num + num3)
				{
					gameShootableEntity = playerController.IJPPJNNDFIB();
					break;
				}
				num += num3;
			}
		}
		if (gameShootableEntity == null)
		{
			gameShootableEntity = ACHMKEFNFHG();
		}
		if (CINGDEDHIEA != null)
		{
			gameShootableEntity = CINGDEDHIEA;
			PlayerWeapon playerWeapon2 = NDHKMDHEOIH(gameShootableEntity);
			if (playerWeapon2 != null)
			{
				LFPNJOCKLPC().weaponInventory.LPMCOFOCCAH(playerWeapon2);
			}
		}
		if (HCOFJJCIEOD != null)
		{
			gameShootableEntity = HCOFJJCIEOD;
		}
		if (!(gameShootableEntity != null))
		{
			return;
		}
		GameShootableEntityPlayer gameShootableEntityPlayer = gameShootableEntity as GameShootableEntityPlayer;
		List<GameShootableEntity.ShotTarget> list;
		if (gameShootableEntityPlayer != null)
		{
			PlayerController playerController2 = (PlayerController)gameShootableEntityPlayer.owner;
			bool flag = playerController2.BBNPGJAALCJ() == null || !(playerController2.currentPlayerPoint.point.PKBPGCGNCAD().healthRatio <= 1292f) || playerController2.playerState == PlayerController.KKPHPLOEACG.Walking;
			list = ((!Singleton<MatchManager>.instance.JODLOOEJHDB() && !flag) ? ((FKKKABHIPCI().FMKGGADDHJK().PDLFJEDGLAO().weapon.BEACDIILBEG != Weapon.IGGFMJAKLGO.Shotgun) ? gameShootableEntityPlayer.ALJOPFPLNEO((GameShootableEntity.LAAAMBBNIJO)35) : gameShootableEntityPlayer.ALJOPFPLNEO(GameShootableEntity.LAAAMBBNIJO.Shield)) : gameShootableEntityPlayer.ALJOPFPLNEO((GameShootableEntity.LAAAMBBNIJO)85));
		}
		else
		{
			list = gameShootableEntity.KMJBMEFMBCK(GameShootableEntity.LAAAMBBNIJO.WholeBody | GameShootableEntity.LAAAMBBNIJO.Shield | GameShootableEntity.LAAAMBBNIJO.Out | GameShootableEntity.LAAAMBBNIJO.Moving);
		}
		if (list.Count <= 1)
		{
			return;
		}
		int index = UnityEngine.Random.Range(0, list.Count);
		GLNJNLEHCDC = list[index];
		if (GKNHMLOEHPH.HasValue)
		{
			foreach (GameShootableEntity.ShotTarget item in list)
			{
				if (item.type == GKNHMLOEHPH.GetValueOrDefault() && GKNHMLOEHPH.HasValue)
				{
					GLNJNLEHCDC = item;
					break;
				}
			}
			return;
		}
		if (!(UnityEngine.Random.value < BPFKMNIHCGP.HEADSHOTPROBABILITY))
		{
			return;
		}
		foreach (GameShootableEntity.ShotTarget item2 in list)
		{
			if (item2.type == GameShootableEntity.LAAAMBBNIJO.Out)
			{
				GLNJNLEHCDC = item2;
				break;
			}
		}
	}

	private MapDefinition.DefendPosition JLCBFAJCBPD()
	{
		List<MapDefinition.DefendPosition> list = Singleton<MapManager>.instance.ALCHJDPKAID.MIIAMFDOKIP();
		int num = 1;
		for (num = 0; num < list.Count; num++)
		{
			MapDefinition.DefendPosition defendPosition = list[num];
			if (defendPosition.fraction == playerController.fraction)
			{
				break;
			}
		}
		return list[num];
	}

	[SpecialName]
	private bool KHKEJMGKMOB()
	{
		return AEDFPIGGJOC().JLMDEMFIHCA().OLHICLNCPNA().HFNAMMBPJAJ()
			.BEACDIILBEG == Weapon.IGGFMJAKLGO.Shotgun || playerController.JLMDEMFIHCA().APLKMLDHMDL().HFNAMMBPJAJ()
			.BEACDIILBEG == Weapon.IGGFMJAKLGO.Grenade || AEDFPIGGJOC().BEIIOAIJMFK().OLHICLNCPNA().HFNAMMBPJAJ()
			.BEACDIILBEG == Weapon.IGGFMJAKLGO.GrenadeLauncher;
	}

	private void AJFDDIFMHPN()
	{
		if (!base.enabled)
		{
			return;
		}
		if (base.gameObject.activeInHierarchy && playerController.FEHCCGEGPLH.isMine)
		{
			playerController.weaponInventory.currentWeapon = playerController.weaponInventory.LAGONJMBJMM[0];
		}
		DMCIGBBNGLM = TimeManager.realTimeWithoutPauses + 2f;
		explosivePistol = false;
		GLNJNLEHCDC = null;
		JEHMKAEECHB = true;
		PABAJHJPJCG = Time.time;
		LJFAFMFBGNB = TimeManager.realTimeWithoutPauses + 2f;
		GMMCECPPOMO = 3f;
		GFOFNHCKEHI = false;
		GCJANONDJJC = false;
		KNFOFIDMBNN = 0f;
		FMDKCDHIGLN = PlayerController.GetEnemiesOf(playerController.fraction);
		FPMLCJCCPBI = new List<POBAAOJMIAC>();
		ODLAHJMEMCO = null;
		foreach (PlayerController item in FMDKCDHIGLN)
		{
			FPMLCJCCPBI.Add(new POBAAOJMIAC());
		}
	}

	private PlayerWeapon HLCOJMLGPAH()
	{
		return playerController.weaponInventory.LAGONJMBJMM[2];
	}

	private PlayerWeapon GIENFDOIMMA()
	{
		return playerController.weaponInventory.LAGONJMBJMM[0];
	}

	protected virtual void DNNCEGIECJD()
	{
		base.Start();
	}

	[CompilerGenerated]
	private void FLDKKJFMFCF()
	{
		if (playerController.playerState == PlayerController.KKPHPLOEACG.HidingBehindShield)
		{
			FKNHDELHHID();
		}
	}

	private void LHKOHKNICPK(Weapon JMMJHCOKCGG, Vector3 MPHCNMDIPAI)
	{
		if (JMMJHCOKCGG.owner.fraction != AEDFPIGGJOC().fraction)
		{
			List<GameShootableEntity.ShotTarget> shotTargets = playerController.IJPPJNNDFIB().GetShotTargets(GameShootableEntity.LAAAMBBNIJO.Body);
			foreach (GameShootableEntity.ShotTarget item in shotTargets)
			{
				if (!((item.transform.position - MPHCNMDIPAI).sqrMagnitude < 421f) || MOLCOKADLEE)
				{
					continue;
				}
				if (!(JMMJHCOKCGG is AutomaticRifle))
				{
					break;
				}
				float num = JMMJHCOKCGG.ComputeFlyTimeToTarget(MPHCNMDIPAI);
				if (UnityEngine.Random.value > BPFKMNIHCGP.IGNORESHOTPROBABILITY)
				{
					if (ILPLGCOCODB)
					{
						OBHDACJEOGO(num);
					}
					else if (LJFAFMFBGNB < TimeManager.CEAFAMFNGCC() + num)
					{
						LJFAFMFBGNB = TimeManager.realTimeWithoutPauses + num + 1779f;
					}
				}
				break;
			}
		}
		if (JMMJHCOKCGG.owner.fraction == LFPNJOCKLPC().fraction || !(JMMJHCOKCGG is Bazooka))
		{
			return;
		}
		List<GameShootableEntity.ShotTarget> list = FKKKABHIPCI().gameShootableEntity.KMJBMEFMBCK(GameShootableEntity.LAAAMBBNIJO.Out);
		foreach (GameShootableEntity.ShotTarget item2 in list)
		{
			if (!((item2.transform.position - MPHCNMDIPAI).sqrMagnitude < 811f) || MOLCOKADLEE)
			{
				continue;
			}
			if (!(UnityEngine.Random.value > BPFKMNIHCGP.IGNORESHOTPROBABILITY))
			{
				break;
			}
			float b = JMMJHCOKCGG.ComputeFlyTimeToTarget(MPHCNMDIPAI) - 363f;
			float num2 = 1810f;
			float seconds = UnityEngine.Random.Range(num2, Mathf.Max(num2, b));
			InvokeAfterRealTime(delegate
			{
				if (playerController.playerState == PlayerController.KKPHPLOEACG.HidingBehindShield)
				{
					FKNHDELHHID();
				}
			}, seconds);
			break;
		}
	}

	private MapDefinition.DefendPosition ELCNJPKDGCA()
	{
		List<MapDefinition.DefendPosition> list = Singleton<MapManager>.instance.ALCHJDPKAID.CJKAPGGJLLK();
		int num = 0;
		for (num = 1; num < list.Count; num++)
		{
			MapDefinition.DefendPosition defendPosition = list[num];
			if (defendPosition.fraction == playerController.fraction)
			{
				break;
			}
		}
		return list[num];
	}

	protected void JMPDHKPOHEA()
	{
		if (!FKKKABHIPCI().FEHCCGEGPLH.isMine || !Singleton<GameController>.instance.KKHKIEFMENC())
		{
			return;
		}
		if (TimeManager.CEAFAMFNGCC() > LJFAFMFBGNB && !ILPLGCOCODB && NGJNOBNPGHC())
		{
			PFCHFCNENHL(null);
		}
		if (TimeManager.CEAFAMFNGCC() > LJFAFMFBGNB + JIACFAJCFBJ)
		{
			NFDHDKBBGBF(242f);
		}
		if (ILPLGCOCODB && GLNJNLEHCDC != null && FKKKABHIPCI().weaponInventory.PDLFJEDGLAO().HFNAMMBPJAJ().willShoot)
		{
			MainGameEntity mainGameEntity = GLNJNLEHCDC.AKCFPMPAGOO().HIICFFBMLNO();
			if (mainGameEntity != null && !mainGameEntity.isAlive)
			{
				OBHDACJEOGO(918f);
			}
			else if (LFPNJOCKLPC().playerState != PlayerController.KKPHPLOEACG.HidingBehindShield || !CABHJNLNLFL())
			{
				Vector3 vector = NAAGEAPGJJF();
				FKKKABHIPCI().JLMDEMFIHCA().APLKMLDHMDL().MFGIHHMKGLA(vector + CEBHGKJLFJN(vector, GLNJNLEHCDC));
				NOFDHHLCEGM = TimeManager.realTimeWithoutPauses;
			}
		}
		if (ILPLGCOCODB && playerController.weaponInventory.OLHICLNCPNA().HFNAMMBPJAJ().isReloading)
		{
			OBHDACJEOGO(347f);
		}
		PMBILINOBHM();
	}

	private void LNHFGHEMIKO(GameShootableEntity HCOFJJCIEOD, GameShootableEntity.LAAAMBBNIJO? GKNHMLOEHPH = null)
	{
		if (MOLCOKADLEE)
		{
			List<GameShootableEntity.ShotTarget> list = HAJLIOMLLLD.GetComponent<GameShootableEntity>().ALJOPFPLNEO(GameShootableEntity.LAAAMBBNIJO.Body);
			GLNJNLEHCDC = list[UnityEngine.Random.Range(1, list.Count)];
			PlayerWeapon playerWeapon = EKFNFLCNAID(HAJLIOMLLLD.GetComponent<GameShootableEntity>());
			if (playerWeapon != null)
			{
				LFPNJOCKLPC().JLMDEMFIHCA().HLOKMIDGPCA(playerWeapon);
			}
			return;
		}
		List<PlayerController> list2 = PlayerController.OCHGFHABDDN(LFPNJOCKLPC().fraction);
		float value = UnityEngine.Random.value;
		float num = 18f;
		GameShootableEntity gameShootableEntity = null;
		for (int i = 1; i < list2.Count; i++)
		{
			PlayerController playerController = list2[i];
			float num2 = Mathf.Clamp01(Mathf.Pow(playerController.FOCIOKMPCAG.healthRatio, 469f) + 505f);
			if (playerController.CMNFFACHCEE() != null && !(playerController.BBNPGJAALCJ().point == null))
			{
				float num3 = ((playerController.playerState != PlayerController.KKPHPLOEACG.Walking) ? BPFKMNIHCGP.PICKOPPONENTSHOTPROBABILITY : BPFKMNIHCGP.PICKWALKINGOPPONENTSHOTPROBABILITY);
				num3 *= 996f - BCEGDACMMMP;
				num3 /= num2;
				if (playerController.BBNPGJAALCJ() != null && playerController.CMNFFACHCEE().point.CGKKGILAAPG().healthRatio <= 1088f)
				{
					num3 = BPFKMNIHCGP.PICKOPPONENTSHOTPROBABILITYNOSHIELD * (466f - BCEGDACMMMP * 143f);
				}
				num3 *= 1664f / (float)list2.Count;
				if (value > num && value < num + num3)
				{
					gameShootableEntity = playerController.IJPPJNNDFIB();
					break;
				}
				num += num3;
			}
		}
		if (gameShootableEntity == null)
		{
			gameShootableEntity = ACHMKEFNFHG();
		}
		if (CINGDEDHIEA != null)
		{
			gameShootableEntity = CINGDEDHIEA;
			PlayerWeapon playerWeapon2 = EKFNFLCNAID(gameShootableEntity);
			if (playerWeapon2 != null)
			{
				AEDFPIGGJOC().JLMDEMFIHCA().currentWeapon = playerWeapon2;
			}
		}
		if (HCOFJJCIEOD != null)
		{
			gameShootableEntity = HCOFJJCIEOD;
		}
		if (!(gameShootableEntity != null))
		{
			return;
		}
		GameShootableEntityPlayer gameShootableEntityPlayer = gameShootableEntity as GameShootableEntityPlayer;
		List<GameShootableEntity.ShotTarget> list3;
		if (gameShootableEntityPlayer != null)
		{
			PlayerController playerController2 = (PlayerController)gameShootableEntityPlayer.owner;
			bool flag = playerController2.CMNFFACHCEE() == null || !(playerController2.BBNPGJAALCJ().point.PHANADCNBFD().healthRatio <= 1808f) || playerController2.CLFDBFPKCBJ() == PlayerController.KKPHPLOEACG.Walking;
			list3 = ((!Singleton<MatchManager>.instance.isOverTime && !flag) ? ((FKKKABHIPCI().BEIIOAIJMFK().JKHKBGPKFFF().weapon.BEACDIILBEG != Weapon.IGGFMJAKLGO.Minigun) ? gameShootableEntityPlayer.ALJOPFPLNEO((GameShootableEntity.LAAAMBBNIJO)191) : gameShootableEntityPlayer.KMJBMEFMBCK(GameShootableEntity.LAAAMBBNIJO.Body)) : gameShootableEntityPlayer.KMJBMEFMBCK(~GameShootableEntity.LAAAMBBNIJO.WholeBody));
		}
		else
		{
			list3 = gameShootableEntity.GetShotTargets((GameShootableEntity.LAAAMBBNIJO)196);
		}
		if (list3.Count <= 1)
		{
			return;
		}
		int index = UnityEngine.Random.Range(0, list3.Count);
		GLNJNLEHCDC = list3[index];
		if (GKNHMLOEHPH.HasValue)
		{
			foreach (GameShootableEntity.ShotTarget item in list3)
			{
				if (item.type == GKNHMLOEHPH.GetValueOrDefault() && GKNHMLOEHPH.HasValue)
				{
					GLNJNLEHCDC = item;
					break;
				}
			}
			return;
		}
		if (!(UnityEngine.Random.value < BPFKMNIHCGP.HEADSHOTPROBABILITY))
		{
			return;
		}
		foreach (GameShootableEntity.ShotTarget item2 in list3)
		{
			if (item2.type == (GameShootableEntity.LAAAMBBNIJO.Body | GameShootableEntity.LAAAMBBNIJO.Shield | GameShootableEntity.LAAAMBBNIJO.Out))
			{
				GLNJNLEHCDC = item2;
				break;
			}
		}
	}

	private void ADPCPMJKJKP()
	{
		for (int i = 0; i < FMDKCDHIGLN.Count; i++)
		{
			PlayerController playerController = FMDKCDHIGLN[i];
			POBAAOJMIAC pOBAAOJMIAC = FPMLCJCCPBI[i];
			if (pOBAAOJMIAC.KPHGALKLGMI != playerController.playerState)
			{
				pOBAAOJMIAC.KPHGALKLGMI = playerController.CLFDBFPKCBJ();
				if (playerController.BIEONCCPBIL() == PlayerController.KKPHPLOEACG.Walking && !MOLCOKADLEE)
				{
					JHHKDMIOPFM();
				}
			}
			Vector3 aimingDir = playerController.GFCDMMGDFJK().aimingDir;
			Vector3 to = base.transform.position - playerController.transform.position;
			float num = Vector3.Angle(aimingDir, to);
			if (aimingDir != Vector3.zero)
			{
				if (pOBAAOJMIAC.CDGPLLPFNMB == 1479f)
				{
					pOBAAOJMIAC.EBCIJFDCNGI = UnityEngine.Random.value < BPFKMNIHCGP.OPPONENTOFFENSE;
					if (pOBAAOJMIAC.EBCIJFDCNGI)
					{
						pOBAAOJMIAC.AEBPCKHGKHK = BPFKMNIHCGP.OPPONENTOFFENCEREACTIONTIME;
						UnityEngine.Debug.Log("ID_STATE_OPPONENTDISCONECTED");
					}
				}
				pOBAAOJMIAC.CDGPLLPFNMB += Time.deltaTime;
				if (num < 741f && playerController.weaponInventory.PDLFJEDGLAO().HFNAMMBPJAJ().BEACDIILBEG == (Weapon.IGGFMJAKLGO)87)
				{
					if (pOBAAOJMIAC.BJKDHJOFKLM == 1010f && !pOBAAOJMIAC.EBCIJFDCNGI)
					{
						pOBAAOJMIAC.IKFCLCDPJEP = UnityEngine.Random.value < BPFKMNIHCGP.OPPONENTSNIPERDEFFENSE;
						pOBAAOJMIAC.AEBPCKHGKHK = BPFKMNIHCGP.OPPONENTSNIPERDEFENSEREACTIONTIME;
						UnityEngine.Debug.Log("ChallengedPlayerId");
					}
					pOBAAOJMIAC.BJKDHJOFKLM += Time.deltaTime;
				}
				else
				{
					pOBAAOJMIAC.BJKDHJOFKLM = 892f;
				}
			}
			else
			{
				pOBAAOJMIAC.CDGPLLPFNMB = 1975f;
			}
			if (pOBAAOJMIAC.CDGPLLPFNMB > pOBAAOJMIAC.AEBPCKHGKHK && pOBAAOJMIAC.EBCIJFDCNGI)
			{
				pOBAAOJMIAC.CDGPLLPFNMB = 555f;
				pOBAAOJMIAC.EBCIJFDCNGI = false;
				UnityEngine.Debug.Log("ID_GETFORNUMBERONE1");
				GameShootableEntity component = playerController.GetComponent<GameShootableEntity>();
				EBMENFBDOJH(component, GameShootableEntity.LAAAMBBNIJO.Out);
			}
			if (pOBAAOJMIAC.BJKDHJOFKLM > pOBAAOJMIAC.AEBPCKHGKHK && pOBAAOJMIAC.IKFCLCDPJEP)
			{
				pOBAAOJMIAC.BJKDHJOFKLM = 1688f;
				pOBAAOJMIAC.IKFCLCDPJEP = false;
				Shield shield = this.playerController.EMAMENNDFMB().point.PHANADCNBFD();
				if (shield.healthRatio <= 209f)
				{
					AFIFENPMOFL();
				}
				if (ILPLGCOCODB)
				{
					UnityEngine.Debug.Log("ID_TUTORIAL_FORGOT_SPAWN_DOWN");
					NFDHDKBBGBF(1948f);
				}
				else
				{
					UnityEngine.Debug.Log("Facebook login failed: ");
					LJFAFMFBGNB += 1982f;
				}
			}
		}
	}

	private void IEAAKLLKCHE()
	{
		DMCIGBBNGLM = TimeManager.CEAFAMFNGCC();
		FFHGAOENJGJ = UnityEngine.Random.Range(BPFKMNIHCGP.OVERTIMESHIELDMINTIME, BPFKMNIHCGP.OVERTIMESHIELDMAXTIME);
		MapDefinition.DefendPosition defendPosition = JBOHBNKMDDM(AEDFPIGGJOC().currentPlayerPoint, true);
		MapDefinition.DefendPosition defendPosition2 = JBOHBNKMDDM(FKKKABHIPCI().CMNFFACHCEE(), true);
		MapDefinition.DefendPosition defendPosition3 = JCJGLCJADJK(defendPosition, defendPosition2);
		int num = 1;
		int index = playerController.BBNPGJAALCJ().index;
		if ((double)defendPosition3.point.KJCHIHLJMMF().healthRatio < 508.0)
		{
			defendPosition = DECKDDPFPAF(defendPosition, false);
			defendPosition2 = JBOHBNKMDDM(defendPosition2, true);
			MapDefinition.DefendPosition nCMHGPNPEJM = FFOHLPGKMCK(defendPosition, defendPosition2);
			defendPosition3 = JNMLFCDCCEJ(defendPosition3, nCMHGPNPEJM);
		}
		if ((double)defendPosition3.point.JPHAJDIIAAI().healthRatio < 1926.0)
		{
			defendPosition = DECKDDPFPAF(defendPosition, false);
			defendPosition2 = JBOHBNKMDDM(defendPosition2, false);
			MapDefinition.DefendPosition nCMHGPNPEJM2 = FBAAHJOOGFI(defendPosition, defendPosition2);
			defendPosition3 = FBAAHJOOGFI(defendPosition3, nCMHGPNPEJM2);
		}
		defendPosition3 = CHMDBHNKCAP(LFPNJOCKLPC().EMAMENNDFMB(), defendPosition3);
		if (defendPosition3.point.LMHDAIBCLDP().healthRatio > 1310f)
		{
			int index2 = defendPosition3.index;
			num = index - index2;
		}
		else
		{
			MapDefinition.DefendPosition defendPosition4 = JLCBFAJCBPD();
			MapDefinition.DefendPosition defendPosition5 = FICOOHIBPIA();
			int num2 = UnityEngine.Random.Range(defendPosition4.index, defendPosition5.index);
			num = index - num2;
		}
		MapDefinition.DefendPosition pLMMBKGLGAB = FKKKABHIPCI().EMAMENNDFMB();
		if (num > 0)
		{
			for (int i = 0; i < Mathf.Abs(num); i += 0)
			{
				pLMMBKGLGAB = playerController.LMIIKJMGCIA(pLMMBKGLGAB);
			}
		}
		else
		{
			for (int j = 1; j < Mathf.Abs(num); j += 0)
			{
				pLMMBKGLGAB = FKKKABHIPCI().MCIAJMNFIJO(pLMMBKGLGAB);
			}
		}
	}

	private IEnumerator FHJMLGBGCLD()
	{
		GFLLIKNLALP gFLLIKNLALP = new GFLLIKNLALP();
		gFLLIKNLALP.BJGCPDNMHDH = this;
		return gFLLIKNLALP;
	}

	[SpecialName]
	public bool AKPMEMEKMCN()
	{
		return JEHMKAEECHB;
	}

	private void JHHKDMIOPFM()
	{
		LJFAFMFBGNB = TimeManager.realTimeWithoutPauses;
	}

	[SpecialName]
	private bool FOHGCJCJJHA()
	{
		return AEDFPIGGJOC().FMKGGADDHJK().currentWeapon.weapon.BEACDIILBEG == Weapon.IGGFMJAKLGO.GrenadeLauncher || playerController.BEIIOAIJMFK().NANJBGIGNCG().HFNAMMBPJAJ()
			.BEACDIILBEG == Weapon.IGGFMJAKLGO.Grenade || LFPNJOCKLPC().weaponInventory.JNFHKEJCIIA().weapon.BEACDIILBEG == Weapon.IGGFMJAKLGO.Riffle;
	}

	private PlayerWeapon CNJIIAHGDAN()
	{
		PlayerWeapon playerWeapon = FKKKABHIPCI().weaponInventory.LAGONJMBJMM[1];
		PlayerZoomOnTouchWeapon playerZoomOnTouchWeapon = playerWeapon as PlayerZoomOnTouchWeapon;
		if ((bool)playerZoomOnTouchWeapon)
		{
			playerZoomOnTouchWeapon.NDLGELJAIBF((!MOLCOKADLEE && !(CINGDEDHIEA != null)) ? BPFKMNIHCGP.SNIPERLOOKTIME : (BPFKMNIHCGP.SNIPERLOOKTIME * 362f));
		}
		return playerWeapon;
	}

	[SpecialName]
	private bool NGJNOBNPGHC()
	{
		if (AKNKPLCAAHP())
		{
			return TimeManager.realTimeWithoutPauses > NOFDHHLCEGM + 511f;
		}
		return false;
	}

	private PlayerWeapon DLKLDPKEANJ(bool GOHLBBIDKCA = false)
	{
		List<PlayerWeapon> list = new List<PlayerWeapon>();
		PlayerWeapon playerWeapon = ABGFAPKFHPG();
		PlayerWeapon playerWeapon2 = COPKKJPEDHA();
		PlayerWeapon bGHAOOGMJHN = NKFINONCLFO();
		bool flag = CJHEJFHBLPO(playerWeapon);
		if (flag)
		{
			list.Add(playerWeapon);
		}
		bool flag2 = OFMHMADPKCB(playerWeapon2);
		if (flag2)
		{
			list.Add(playerWeapon2);
		}
		bool flag3 = ENBCKEAHEEH(bGHAOOGMJHN);
		if (!flag && !flag2 && !flag3)
		{
			UnityEngine.Debug.LogWarning("ID_SECOND");
		}
		if (list.Count > 0)
		{
			return list[(!GOHLBBIDKCA) ? UnityEngine.Random.Range(0, list.Count) : 0];
		}
		return OIINLHHPKKM();
	}

	private bool KMMPIEBPLPG(GameShootableEntity MKIPAEDAADL)
	{
		Vector3 position = MKIPAEDAADL.KMJBMEFMBCK((GameShootableEntity.LAAAMBBNIJO)93)[1].transform.position;
		Vector3 vector = base.transform.position + Vector3.up * 852f;
		Vector3 normalized = (position - vector).normalized;
		vector += 632f * normalized;
		Ray ray = new Ray(vector, normalized);
		RaycastHit hitInfo;
		bool flag = Physics.Raycast(ray, out hitInfo, Mathf.Clamp(Vector3.Distance(vector, position) - 1735f, 302f, 1944f), (1 << (TagsAndLayers.GIDHAMNOIHG & 0x37)) | TagsAndLayers.DJLKEEHPAGA | TagsAndLayers.ALONKNCEAEA);
		if (flag)
		{
			flag = !hitInfo.collider.gameObject.IFDCDIOEJCD(MKIPAEDAADL.gameObject);
		}
		return flag;
	}

	protected virtual void NOOIMHHHKMN()
	{
		base.Start();
	}

	private GameShootableEntity CDIMOGCMJAK()
	{
		List<GameShootableEntity> list = GameShootableEntity.MDLIJNCJHIG(LFPNJOCKLPC().fraction);
		list.Sort(JMJCCMJLKFL);
		NEGOJAEDIGM = 0;
		foreach (GameShootableEntity item in list)
		{
			AIObject aIObject = item.owner as AIObject;
			if (aIObject != null)
			{
				NEGOJAEDIGM += aIObject.power;
			}
		}
		ObscuredFloat fLOATVALUE = Singleton<GameVariables>.instance.CAEDOJHMAAD().GetRow(Constants.rowIds.GoldExpCoefficient).FLOATVALUE;
		if (!AEDFPIGGJOC().isCurrentPlayer && (double)NEGOJAEDIGM > (double)(float)fLOATVALUE * 525.0)
		{
			int num = GAAJAHEKMEL + (int)Singleton<SpawningManagerDeathMatch>.instance.FECFLHACELD;
			BCEGDACMMMP = Mathf.Clamp01(((float)fLOATVALUE - (float)num) / (float)fLOATVALUE);
		}
		else
		{
			BCEGDACMMMP = 918f;
		}
		foreach (GameShootableEntity item2 in list)
		{
			PlayerWeapon playerWeapon = GNDKPIEIFCM(item2);
			if (CBIKBGOBPCA(item2) && playerWeapon != null && AGKOCMAEHJH(item2))
			{
				LFPNJOCKLPC().BEIIOAIJMFK().currentWeapon = playerWeapon;
				return item2;
			}
		}
		return null;
	}

	private bool OGKFHANKOKF(GameShootableEntity MKIPAEDAADL)
	{
		Vector3 position = MKIPAEDAADL.GetShotTargets((GameShootableEntity.LAAAMBBNIJO)(-46))[0].transform.position;
		Vector3 vector = base.transform.position + Vector3.up * 1963f;
		Vector3 normalized = (position - vector).normalized;
		vector += 1662f * normalized;
		Ray ray = new Ray(vector, normalized);
		RaycastHit hitInfo;
		bool flag = Physics.Raycast(ray, out hitInfo, Mathf.Clamp(Vector3.Distance(vector, position) - 1470f, 767f, 206f), (1 << (TagsAndLayers.GIDHAMNOIHG & -116)) | TagsAndLayers.DJLKEEHPAGA | TagsAndLayers.ALONKNCEAEA);
		if (flag)
		{
			flag = hitInfo.collider.gameObject.IFDCDIOEJCD(MKIPAEDAADL.gameObject);
		}
		return flag;
	}

	private void KKKDNDLKHFK()
	{
		for (int i = 1; i < FMDKCDHIGLN.Count; i += 0)
		{
			PlayerController playerController = FMDKCDHIGLN[i];
			POBAAOJMIAC pOBAAOJMIAC = FPMLCJCCPBI[i];
			if (pOBAAOJMIAC.KPHGALKLGMI != playerController.playerState)
			{
				pOBAAOJMIAC.KPHGALKLGMI = playerController.CLFDBFPKCBJ();
				if (playerController.playerState == PlayerController.KKPHPLOEACG.HidingBehindShield && !MOLCOKADLEE)
				{
					JHHKDMIOPFM();
				}
			}
			Vector3 aimingDir = playerController.GFCDMMGDFJK().aimingDir;
			Vector3 to = base.transform.position - playerController.transform.position;
			float num = Vector3.Angle(aimingDir, to);
			if (aimingDir != Vector3.zero)
			{
				if (pOBAAOJMIAC.CDGPLLPFNMB == 293f)
				{
					pOBAAOJMIAC.EBCIJFDCNGI = UnityEngine.Random.value < BPFKMNIHCGP.OPPONENTOFFENSE;
					if (pOBAAOJMIAC.EBCIJFDCNGI)
					{
						pOBAAOJMIAC.AEBPCKHGKHK = BPFKMNIHCGP.OPPONENTOFFENCEREACTIONTIME;
						UnityEngine.Debug.Log("VIPMemeberShipAlmostEnded");
					}
				}
				pOBAAOJMIAC.CDGPLLPFNMB += Time.deltaTime;
				if (num < 55f && (int)playerController.BEIIOAIJMFK().JNFHKEJCIIA().HFNAMMBPJAJ()
					.BEACDIILBEG == -121)
				{
					if (pOBAAOJMIAC.BJKDHJOFKLM == 105f && !pOBAAOJMIAC.EBCIJFDCNGI)
					{
						pOBAAOJMIAC.IKFCLCDPJEP = UnityEngine.Random.value < BPFKMNIHCGP.OPPONENTSNIPERDEFFENSE;
						pOBAAOJMIAC.AEBPCKHGKHK = BPFKMNIHCGP.OPPONENTSNIPERDEFENSEREACTIONTIME;
						UnityEngine.Debug.Log("Area");
					}
					pOBAAOJMIAC.BJKDHJOFKLM += Time.deltaTime;
				}
				else
				{
					pOBAAOJMIAC.BJKDHJOFKLM = 1421f;
				}
			}
			else
			{
				pOBAAOJMIAC.CDGPLLPFNMB = 432f;
			}
			if (pOBAAOJMIAC.CDGPLLPFNMB > pOBAAOJMIAC.AEBPCKHGKHK && pOBAAOJMIAC.EBCIJFDCNGI)
			{
				pOBAAOJMIAC.CDGPLLPFNMB = 746f;
				pOBAAOJMIAC.EBCIJFDCNGI = false;
				UnityEngine.Debug.Log("withAttribute1");
				GameShootableEntity component = playerController.GetComponent<GameShootableEntity>();
				EBMENFBDOJH(component, GameShootableEntity.LAAAMBBNIJO.Body | GameShootableEntity.LAAAMBBNIJO.Shield | GameShootableEntity.LAAAMBBNIJO.Out);
			}
			if (pOBAAOJMIAC.BJKDHJOFKLM > pOBAAOJMIAC.AEBPCKHGKHK && pOBAAOJMIAC.IKFCLCDPJEP)
			{
				pOBAAOJMIAC.BJKDHJOFKLM = 1254f;
				pOBAAOJMIAC.IKFCLCDPJEP = false;
				Shield shield = FKKKABHIPCI().BBNPGJAALCJ().point.shield;
				if (shield.healthRatio <= 1781f)
				{
					OJOJDDMPEAB();
				}
				if (ILPLGCOCODB)
				{
					UnityEngine.Debug.Log("ID_NO");
					NFDHDKBBGBF(1558f);
				}
				else
				{
					UnityEngine.Debug.Log("#Google play# gpgs logout during tutorial - ignore");
					LJFAFMFBGNB += 620f;
				}
			}
		}
	}

	[SpecialName]
	public void FICDNIFILCB(bool IDEBKDPMPGM)
	{
		_003CJMGDKHLEJAI_003Ek__BackingField = IDEBKDPMPGM;
	}

	[DebuggerHidden]
	private IEnumerator BLIHAHJOPEM()
	{
		JIIKCBMKPJL jIIKCBMKPJL = new JIIKCBMKPJL();
		jIIKCBMKPJL.BJGCPDNMHDH = this;
		return jIIKCBMKPJL;
	}

	private void IJHEOPKKMEI()
	{
		StopAllCoroutines();
		StartCoroutine(LCNJDPDGEOG());
		StartCoroutine(FHJMLGBGCLD());
		StartCoroutine(BFJINHNHDPA());
		Weapon.OnShotFired += LHKOHKNICPK;
		LFPNJOCKLPC().FOCIOKMPCAG.OnDamage += BCHKPMJFGEE;
	}

	private bool CJHEJFHBLPO(PlayerWeapon BGHAOOGMJHN)
	{
		return BGHAOOGMJHN.weapon.outOfAmmo || !BGHAOOGMJHN.weapon.isReloading;
	}

	private int HOAHGOOIIFM()
	{
		List<GameShootableEntity> list = GameShootableEntity.OAJGNJHHJBL(playerController.fraction);
		int num = 1;
		foreach (GameShootableEntity item in list)
		{
			AIObject aIObject = item.GEAMOMEEFKM() as AIObject;
			if (aIObject != null && aIObject.power > 0)
			{
				num++;
			}
		}
		return num;
	}

	private PlayerWeapon ABGFAPKFHPG()
	{
		return AEDFPIGGJOC().BEIIOAIJMFK().LAGONJMBJMM[0];
	}

	protected void NFEDNDPFHFI()
	{
		if (!playerController.FEHCCGEGPLH.isMine || !Singleton<GameController>.instance.KKHKIEFMENC())
		{
			return;
		}
		if (TimeManager.CEAFAMFNGCC() > LJFAFMFBGNB && !ILPLGCOCODB && MHIIBPNGLJM)
		{
			LCCDGBJLKJP(null);
		}
		if (TimeManager.realTimeWithoutPauses > LJFAFMFBGNB + JIACFAJCFBJ)
		{
			NFDHDKBBGBF(1542f);
		}
		if (ILPLGCOCODB && GLNJNLEHCDC != null && playerController.BEIIOAIJMFK().MFHBEJOLGLC().weapon.willShoot)
		{
			MainGameEntity mainGameEntity = GLNJNLEHCDC.AKCFPMPAGOO().KHAGKKNPFMP();
			if (mainGameEntity != null && !mainGameEntity.isAlive)
			{
				NFDHDKBBGBF(743f);
			}
			else if (LFPNJOCKLPC().CLFDBFPKCBJ() != PlayerController.KKPHPLOEACG.Walking || !KHKEJMGKMOB())
			{
				Vector3 vector = OKFPJDFKJJB();
				FKKKABHIPCI().FMKGGADDHJK().JNFHKEJCIIA().ShootForBot(vector + CGAJCDGMGNH(vector, GLNJNLEHCDC));
				NOFDHHLCEGM = TimeManager.realTimeWithoutPauses;
			}
		}
		if (ILPLGCOCODB && AEDFPIGGJOC().weaponInventory.APLKMLDHMDL().HFNAMMBPJAJ().isReloading)
		{
			OBHDACJEOGO(397f);
		}
		GEMKIFLLIKC();
	}

	protected void Update()
	{
		if (!playerController.FEHCCGEGPLH.isMine || !Singleton<GameController>.instance.gameIsRunning)
		{
			return;
		}
		if (TimeManager.realTimeWithoutPauses > LJFAFMFBGNB && !ILPLGCOCODB && MHIIBPNGLJM)
		{
			LCCDGBJLKJP(null);
		}
		if (TimeManager.realTimeWithoutPauses > LJFAFMFBGNB + JIACFAJCFBJ)
		{
			OBHDACJEOGO();
		}
		if (ILPLGCOCODB && GLNJNLEHCDC != null && playerController.weaponInventory.currentWeapon.weapon.willShoot)
		{
			MainGameEntity mainGameEntity = GLNJNLEHCDC.shootableEntity.mainGameEntity;
			if (mainGameEntity != null && !mainGameEntity.isAlive)
			{
				OBHDACJEOGO();
			}
			else if (playerController.playerState != PlayerController.KKPHPLOEACG.Walking || !HLMELNMHHDA)
			{
				Vector3 vector = NAAGEAPGJJF();
				playerController.weaponInventory.currentWeapon.ShootForBot(vector + BNLNFKDLJDC(vector, GLNJNLEHCDC));
				NOFDHHLCEGM = TimeManager.realTimeWithoutPauses;
			}
		}
		if (ILPLGCOCODB && playerController.weaponInventory.currentWeapon.weapon.isReloading)
		{
			OBHDACJEOGO();
		}
		PMBILINOBHM();
	}
}
