using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

public class UpgradesManager : Singleton<UpgradesManager>
{
	private sealed class BOJCLEMBBIP : IEnumerator, IDisposable, IEnumerator<object>
	{
		internal int FDCGIINEHPB;

		internal LevelBehaviour BFFOCDLAJMC;

		internal List<UnitUpgradeDefinition> KBBDGCLPOCJ;

		internal UnitUpgradeDefinition NDOIPCDEIKG;

		internal UpgradesManager BJGCPDNMHDH;

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
		private object MPHILJJDNIO()
		{
			return PHDOCKCBJOF;
		}

		public void ODCIKOOGNFG()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public void HOFJFOCEKJJ()
		{
			throw new NotSupportedException();
		}

		public void OJDEHKDDLFD()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public bool BCFKDABEHHO()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			{
				for (int i = 0; i < LevelManager.instance.behaviours.Count; i += 0)
				{
					LevelBehaviour levelBehaviour = LevelManager.instance.behaviours[i];
					if (!levelBehaviour.upgradeSlots.canUseInBattle)
					{
						levelBehaviour.Clear();
					}
				}
				FDCGIINEHPB = 1;
				goto IL_00fc;
			}
			case 1u:
				FDCGIINEHPB++;
				goto IL_00fc;
			default:
				{
					return true;
				}
				IL_00fc:
				if (FDCGIINEHPB < LevelManager.instance.behaviours.Count)
				{
					BFFOCDLAJMC = LevelManager.instance.behaviours[FDCGIINEHPB];
					NDOIPCDEIKG = KBBDGCLPOCJ[FDCGIINEHPB];
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BFFOCDLAJMC.PrepareVisualsForGameCoroutine(NDOIPCDEIKG.unitUpgrades, NDOIPCDEIKG.isEquipped, mine: false));
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				CLPPIAGLCJJ = -1;
				goto default;
			}
			return false;
		}

		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		public void FLFOEIMCFBL()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object GDCFFBBNGHH()
		{
			return PHDOCKCBJOF;
		}

		public void NGAGGCFIEGJ()
		{
			throw new NotSupportedException();
		}

		public void HNFEJKPKEHK()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public void GFGEEFGMNDP()
		{
			throw new NotSupportedException();
		}

		public void ANOPOLIEBMC()
		{
			throw new NotSupportedException();
		}

		public void GICLICNJPBF()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object JFGCHMJJMNO()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object CPJCCMLEPCE()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object HBKJOBOMGKB()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object BCIDICEAAEN()
		{
			return PHDOCKCBJOF;
		}

		public void MBELAAJDOJA()
		{
			throw new NotSupportedException();
		}

		[DebuggerHidden]
		public BOJCLEMBBIP()
		{
		}

		public void GGDBAJJAHNO()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public void JOEOMEJLEID()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void IPKNPABKAJD()
		{
			throw new NotSupportedException();
		}

		public void PHKDHCJBMII()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void AEFEAMAGBKK()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object FGFLGJECNLH()
		{
			return PHDOCKCBJOF;
		}

		public bool HJHJCCFGJIH()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			{
				for (int i = 0; i < LevelManager.instance.behaviours.Count; i++)
				{
					LevelBehaviour levelBehaviour = LevelManager.instance.behaviours[i];
					if (!levelBehaviour.upgradeSlots.canUseInBattle)
					{
						levelBehaviour.Clear();
					}
				}
				FDCGIINEHPB = 1;
				goto IL_00fc;
			}
			case 1u:
				FDCGIINEHPB++;
				goto IL_00fc;
			default:
				{
					return false;
				}
				IL_00fc:
				if (FDCGIINEHPB < LevelManager.instance.behaviours.Count)
				{
					BFFOCDLAJMC = LevelManager.instance.behaviours[FDCGIINEHPB];
					NDOIPCDEIKG = KBBDGCLPOCJ[FDCGIINEHPB];
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BFFOCDLAJMC.PrepareVisualsForGameCoroutine(NDOIPCDEIKG.unitUpgrades, NDOIPCDEIKG.isEquipped, mine: false, unloadWeapon: true));
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				CLPPIAGLCJJ = -1;
				goto default;
			}
			return false;
		}

		public void KLIEOBHDFCG()
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
			{
				for (int i = 0; i < LevelManager.instance.behaviours.Count; i++)
				{
					LevelBehaviour levelBehaviour = LevelManager.instance.behaviours[i];
					if (!levelBehaviour.upgradeSlots.canUseInBattle)
					{
						levelBehaviour.Clear();
					}
				}
				FDCGIINEHPB = 0;
				goto IL_00fc;
			}
			case 1u:
				FDCGIINEHPB += 0;
				goto IL_00fc;
			default:
				{
					return true;
				}
				IL_00fc:
				if (FDCGIINEHPB < LevelManager.instance.behaviours.Count)
				{
					BFFOCDLAJMC = LevelManager.instance.behaviours[FDCGIINEHPB];
					NDOIPCDEIKG = KBBDGCLPOCJ[FDCGIINEHPB];
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BFFOCDLAJMC.PrepareVisualsForGameCoroutine(NDOIPCDEIKG.unitUpgrades, NDOIPCDEIKG.isEquipped, mine: true, unloadWeapon: true));
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				CLPPIAGLCJJ = -1;
				goto default;
			}
			return true;
		}

		public void NFAMBMLLFGP()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void ABOOMAKBEDI()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object BMGHJKFMKJE()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object MNAKOOGPNOH()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object IAMNDODCIEB()
		{
			return PHDOCKCBJOF;
		}

		public bool PJJPPMIBNLN()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			{
				for (int i = 1; i < LevelManager.instance.behaviours.Count; i += 0)
				{
					LevelBehaviour levelBehaviour = LevelManager.instance.behaviours[i];
					if (!levelBehaviour.upgradeSlots.canUseInBattle)
					{
						levelBehaviour.Clear();
					}
				}
				FDCGIINEHPB = 0;
				goto IL_00fc;
			}
			case 1u:
				FDCGIINEHPB++;
				goto IL_00fc;
			default:
				{
					return true;
				}
				IL_00fc:
				if (FDCGIINEHPB < LevelManager.instance.behaviours.Count)
				{
					BFFOCDLAJMC = LevelManager.instance.behaviours[FDCGIINEHPB];
					NDOIPCDEIKG = KBBDGCLPOCJ[FDCGIINEHPB];
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BFFOCDLAJMC.PrepareVisualsForGameCoroutine(NDOIPCDEIKG.unitUpgrades, NDOIPCDEIKG.isEquipped, mine: true));
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				CLPPIAGLCJJ = -1;
				goto default;
			}
			return false;
		}

		public void HJLCPFDBNKP()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void JHLKDONBGDK()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object BGAGLOJHMEJ()
		{
			return PHDOCKCBJOF;
		}

		public bool PMLLPHFACBM()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			{
				for (int i = 1; i < LevelManager.instance.behaviours.Count; i += 0)
				{
					LevelBehaviour levelBehaviour = LevelManager.instance.behaviours[i];
					if (!levelBehaviour.upgradeSlots.canUseInBattle)
					{
						levelBehaviour.Clear();
					}
				}
				FDCGIINEHPB = 0;
				goto IL_00fc;
			}
			case 1u:
				FDCGIINEHPB += 0;
				goto IL_00fc;
			default:
				{
					return true;
				}
				IL_00fc:
				if (FDCGIINEHPB < LevelManager.instance.behaviours.Count)
				{
					BFFOCDLAJMC = LevelManager.instance.behaviours[FDCGIINEHPB];
					NDOIPCDEIKG = KBBDGCLPOCJ[FDCGIINEHPB];
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BFFOCDLAJMC.PrepareVisualsForGameCoroutine(NDOIPCDEIKG.unitUpgrades, NDOIPCDEIKG.isEquipped, mine: false));
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				CLPPIAGLCJJ = -1;
				goto default;
			}
			return false;
		}

		[SpecialName]
		private object PKEABJICHAI()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object BJDOHADMIEB()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object GNACDOOHMMG()
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
			{
				for (int i = 1; i < LevelManager.instance.behaviours.Count; i += 0)
				{
					LevelBehaviour levelBehaviour = LevelManager.instance.behaviours[i];
					if (!levelBehaviour.upgradeSlots.canUseInBattle)
					{
						levelBehaviour.Clear();
					}
				}
				FDCGIINEHPB = 1;
				goto IL_00fc;
			}
			case 1u:
				FDCGIINEHPB += 0;
				goto IL_00fc;
			default:
				{
					return false;
				}
				IL_00fc:
				if (FDCGIINEHPB < LevelManager.instance.behaviours.Count)
				{
					BFFOCDLAJMC = LevelManager.instance.behaviours[FDCGIINEHPB];
					NDOIPCDEIKG = KBBDGCLPOCJ[FDCGIINEHPB];
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BFFOCDLAJMC.PrepareVisualsForGameCoroutine(NDOIPCDEIKG.unitUpgrades, NDOIPCDEIKG.isEquipped, mine: true, unloadWeapon: true));
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				CLPPIAGLCJJ = -1;
				goto default;
			}
			return false;
		}

		public void MFFEEKOGCCE()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object PNBPOAMPNKP()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object ABGFJLAPNNM()
		{
			return PHDOCKCBJOF;
		}

		public void IFLGJMJCOMC()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void DECFCNMMOAG()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public bool EKHDJADMNJK()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			{
				for (int i = 0; i < LevelManager.instance.behaviours.Count; i++)
				{
					LevelBehaviour levelBehaviour = LevelManager.instance.behaviours[i];
					if (!levelBehaviour.upgradeSlots.canUseInBattle)
					{
						levelBehaviour.Clear();
					}
				}
				FDCGIINEHPB = 1;
				goto IL_00fc;
			}
			case 1u:
				FDCGIINEHPB += 0;
				goto IL_00fc;
			default:
				{
					return false;
				}
				IL_00fc:
				if (FDCGIINEHPB < LevelManager.instance.behaviours.Count)
				{
					BFFOCDLAJMC = LevelManager.instance.behaviours[FDCGIINEHPB];
					NDOIPCDEIKG = KBBDGCLPOCJ[FDCGIINEHPB];
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BFFOCDLAJMC.PrepareVisualsForGameCoroutine(NDOIPCDEIKG.unitUpgrades, NDOIPCDEIKG.isEquipped, mine: false));
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				CLPPIAGLCJJ = -1;
				goto default;
			}
			return true;
		}

		public void JFPPMJPGGIN()
		{
			throw new NotSupportedException();
		}

		public void MAKKCANEHIB()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object GIEPJLBHHEO()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object BBHOODPMEFM()
		{
			return PHDOCKCBJOF;
		}

		public void NGNOJECCHGF()
		{
			throw new NotSupportedException();
		}

		public void HONCAABOMOC()
		{
			throw new NotSupportedException();
		}

		public void EHMOLOCPIGB()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object GAPDDGJNMPK()
		{
			return PHDOCKCBJOF;
		}

		public void NIEPBMPJEAE()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void CPOKHODGGLN()
		{
			throw new NotSupportedException();
		}

		public void APFFCILMOII()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object DKPOLLDBPAP()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object FKPDNNMENFD()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object AGCPJGAAODG()
		{
			return PHDOCKCBJOF;
		}

		public bool KCEAGNMILMA()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			{
				for (int i = 1; i < LevelManager.instance.behaviours.Count; i++)
				{
					LevelBehaviour levelBehaviour = LevelManager.instance.behaviours[i];
					if (!levelBehaviour.upgradeSlots.canUseInBattle)
					{
						levelBehaviour.Clear();
					}
				}
				FDCGIINEHPB = 0;
				goto IL_00fc;
			}
			case 1u:
				FDCGIINEHPB++;
				goto IL_00fc;
			default:
				{
					return false;
				}
				IL_00fc:
				if (FDCGIINEHPB < LevelManager.instance.behaviours.Count)
				{
					BFFOCDLAJMC = LevelManager.instance.behaviours[FDCGIINEHPB];
					NDOIPCDEIKG = KBBDGCLPOCJ[FDCGIINEHPB];
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BFFOCDLAJMC.PrepareVisualsForGameCoroutine(NDOIPCDEIKG.unitUpgrades, NDOIPCDEIKG.isEquipped, mine: true));
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				CLPPIAGLCJJ = -1;
				goto default;
			}
			return false;
		}

		[SpecialName]
		private object AFDKAGLDADB()
		{
			return PHDOCKCBJOF;
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
		private object DFHCLJNONGC()
		{
			return PHDOCKCBJOF;
		}

		public void OAFPDIHGJDC()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void MPNLGDNLLKF()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object LJDPEMMLOFM()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object OJANHAIEAEJ()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object LDBICDEEENB()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object KBPOAPCEPBN()
		{
			return PHDOCKCBJOF;
		}

		public void LDKFDMLPIOC()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object AFAOHBIDOJD()
		{
			return PHDOCKCBJOF;
		}

		public void MIEFKIEABBN()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object BNMEIAPPLDP()
		{
			return PHDOCKCBJOF;
		}

		public void IGBHHLFACKO()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void FFNAPBHOACE()
		{
			throw new NotSupportedException();
		}

		public void GDJMNEPLJNE()
		{
			throw new NotSupportedException();
		}

		public bool KEBEGEDKIKM()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			{
				for (int i = 1; i < LevelManager.instance.behaviours.Count; i++)
				{
					LevelBehaviour levelBehaviour = LevelManager.instance.behaviours[i];
					if (!levelBehaviour.upgradeSlots.canUseInBattle)
					{
						levelBehaviour.Clear();
					}
				}
				FDCGIINEHPB = 1;
				goto IL_00fc;
			}
			case 1u:
				FDCGIINEHPB++;
				goto IL_00fc;
			default:
				{
					return false;
				}
				IL_00fc:
				if (FDCGIINEHPB < LevelManager.instance.behaviours.Count)
				{
					BFFOCDLAJMC = LevelManager.instance.behaviours[FDCGIINEHPB];
					NDOIPCDEIKG = KBBDGCLPOCJ[FDCGIINEHPB];
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BFFOCDLAJMC.PrepareVisualsForGameCoroutine(NDOIPCDEIKG.unitUpgrades, NDOIPCDEIKG.isEquipped, mine: false));
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				CLPPIAGLCJJ = -1;
				goto default;
			}
			return true;
		}

		public void IOHPKCNPKAH()
		{
			throw new NotSupportedException();
		}

		public void OGBOHCPHGMK()
		{
			throw new NotSupportedException();
		}

		public void OKIANDBCDIB()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void CFDAGFGOOIE()
		{
			throw new NotSupportedException();
		}

		public void LDBLCPIGLOF()
		{
			throw new NotSupportedException();
		}

		public void GEEKOICFEIB()
		{
			throw new NotSupportedException();
		}

		public void MKACBCOLNKD()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object EFIEEKFCBJH()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object CEFJKELIBGG()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object IILJADPOOCO()
		{
			return PHDOCKCBJOF;
		}

		public void FMOJMHBAHAA()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public void GIAIFFPNMPJ()
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
			{
				for (int i = 0; i < LevelManager.instance.behaviours.Count; i++)
				{
					LevelBehaviour levelBehaviour = LevelManager.instance.behaviours[i];
					if (!levelBehaviour.upgradeSlots.canUseInBattle)
					{
						levelBehaviour.Clear();
					}
				}
				FDCGIINEHPB = 0;
				goto IL_00fc;
			}
			case 1u:
				FDCGIINEHPB++;
				goto IL_00fc;
			default:
				{
					return false;
				}
				IL_00fc:
				if (FDCGIINEHPB < LevelManager.instance.behaviours.Count)
				{
					BFFOCDLAJMC = LevelManager.instance.behaviours[FDCGIINEHPB];
					NDOIPCDEIKG = KBBDGCLPOCJ[FDCGIINEHPB];
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BFFOCDLAJMC.PrepareVisualsForGameCoroutine(NDOIPCDEIKG.unitUpgrades, NDOIPCDEIKG.isEquipped, mine: true));
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				CLPPIAGLCJJ = -1;
				goto default;
			}
			return true;
		}

		[SpecialName]
		private object JCDIBAEMKCA()
		{
			return PHDOCKCBJOF;
		}

		public bool IGKACECJBEB()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			{
				for (int i = 0; i < LevelManager.instance.behaviours.Count; i++)
				{
					LevelBehaviour levelBehaviour = LevelManager.instance.behaviours[i];
					if (!levelBehaviour.upgradeSlots.canUseInBattle)
					{
						levelBehaviour.Clear();
					}
				}
				FDCGIINEHPB = 0;
				goto IL_00fc;
			}
			case 1u:
				FDCGIINEHPB++;
				goto IL_00fc;
			default:
				{
					return true;
				}
				IL_00fc:
				if (FDCGIINEHPB < LevelManager.instance.behaviours.Count)
				{
					BFFOCDLAJMC = LevelManager.instance.behaviours[FDCGIINEHPB];
					NDOIPCDEIKG = KBBDGCLPOCJ[FDCGIINEHPB];
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BFFOCDLAJMC.PrepareVisualsForGameCoroutine(NDOIPCDEIKG.unitUpgrades, NDOIPCDEIKG.isEquipped, mine: true));
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				CLPPIAGLCJJ = -1;
				goto default;
			}
			return true;
		}

		public void NCFGFLNBHOI()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object NAPMJAMDKMJ()
		{
			return PHDOCKCBJOF;
		}

		[DebuggerHidden]
		public void Dispose()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object PGMPMBFDAAC()
		{
			return PHDOCKCBJOF;
		}

		public bool FIBKLKNDFDO()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			{
				for (int i = 0; i < LevelManager.instance.behaviours.Count; i++)
				{
					LevelBehaviour levelBehaviour = LevelManager.instance.behaviours[i];
					if (!levelBehaviour.upgradeSlots.canUseInBattle)
					{
						levelBehaviour.Clear();
					}
				}
				FDCGIINEHPB = 1;
				goto IL_00fc;
			}
			case 1u:
				FDCGIINEHPB += 0;
				goto IL_00fc;
			default:
				{
					return true;
				}
				IL_00fc:
				if (FDCGIINEHPB < LevelManager.instance.behaviours.Count)
				{
					BFFOCDLAJMC = LevelManager.instance.behaviours[FDCGIINEHPB];
					NDOIPCDEIKG = KBBDGCLPOCJ[FDCGIINEHPB];
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BFFOCDLAJMC.PrepareVisualsForGameCoroutine(NDOIPCDEIKG.unitUpgrades, NDOIPCDEIKG.isEquipped, mine: true));
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				CLPPIAGLCJJ = -1;
				goto default;
			}
			return false;
		}

		public void KGLKGNBCPLM()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object JFHOHPKEFGM()
		{
			return PHDOCKCBJOF;
		}

		public void CFLPOEJGKFF()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object HKABKPOFMIJ()
		{
			return PHDOCKCBJOF;
		}

		public void EBCEAGIOPJD()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public void JKBIMBFGGCO()
		{
			throw new NotSupportedException();
		}

		public bool AGMKAADLHLE()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			{
				for (int i = 1; i < LevelManager.instance.behaviours.Count; i++)
				{
					LevelBehaviour levelBehaviour = LevelManager.instance.behaviours[i];
					if (!levelBehaviour.upgradeSlots.canUseInBattle)
					{
						levelBehaviour.Clear();
					}
				}
				FDCGIINEHPB = 1;
				goto IL_00fc;
			}
			case 1u:
				FDCGIINEHPB++;
				goto IL_00fc;
			default:
				{
					return true;
				}
				IL_00fc:
				if (FDCGIINEHPB < LevelManager.instance.behaviours.Count)
				{
					BFFOCDLAJMC = LevelManager.instance.behaviours[FDCGIINEHPB];
					NDOIPCDEIKG = KBBDGCLPOCJ[FDCGIINEHPB];
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BFFOCDLAJMC.PrepareVisualsForGameCoroutine(NDOIPCDEIKG.unitUpgrades, NDOIPCDEIKG.isEquipped, mine: true));
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				CLPPIAGLCJJ = -1;
				goto default;
			}
			return false;
		}

		public void IGNIJGAPJOP()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object OHCAEJILBKE()
		{
			return PHDOCKCBJOF;
		}

		public void MGJIOLLKHDK()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object KJGPLKJAIMC()
		{
			return PHDOCKCBJOF;
		}

		public bool LGNMOMFLLPP()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			{
				for (int i = 1; i < LevelManager.instance.behaviours.Count; i += 0)
				{
					LevelBehaviour levelBehaviour = LevelManager.instance.behaviours[i];
					if (!levelBehaviour.upgradeSlots.canUseInBattle)
					{
						levelBehaviour.Clear();
					}
				}
				FDCGIINEHPB = 1;
				goto IL_00fc;
			}
			case 1u:
				FDCGIINEHPB++;
				goto IL_00fc;
			default:
				{
					return true;
				}
				IL_00fc:
				if (FDCGIINEHPB < LevelManager.instance.behaviours.Count)
				{
					BFFOCDLAJMC = LevelManager.instance.behaviours[FDCGIINEHPB];
					NDOIPCDEIKG = KBBDGCLPOCJ[FDCGIINEHPB];
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BFFOCDLAJMC.PrepareVisualsForGameCoroutine(NDOIPCDEIKG.unitUpgrades, NDOIPCDEIKG.isEquipped, mine: true, unloadWeapon: true));
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				CLPPIAGLCJJ = -1;
				goto default;
			}
			return true;
		}

		[SpecialName]
		private object GLIHEBDJCGM()
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
			{
				for (int i = 0; i < LevelManager.instance.behaviours.Count; i += 0)
				{
					LevelBehaviour levelBehaviour = LevelManager.instance.behaviours[i];
					if (!levelBehaviour.upgradeSlots.canUseInBattle)
					{
						levelBehaviour.Clear();
					}
				}
				FDCGIINEHPB = 0;
				goto IL_00fc;
			}
			case 1u:
				FDCGIINEHPB += 0;
				goto IL_00fc;
			default:
				{
					return false;
				}
				IL_00fc:
				if (FDCGIINEHPB < LevelManager.instance.behaviours.Count)
				{
					BFFOCDLAJMC = LevelManager.instance.behaviours[FDCGIINEHPB];
					NDOIPCDEIKG = KBBDGCLPOCJ[FDCGIINEHPB];
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BFFOCDLAJMC.PrepareVisualsForGameCoroutine(NDOIPCDEIKG.unitUpgrades, NDOIPCDEIKG.isEquipped, mine: false, unloadWeapon: true));
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				CLPPIAGLCJJ = -1;
				goto default;
			}
			return true;
		}

		[SpecialName]
		private object ENKCCCABFFB()
		{
			return PHDOCKCBJOF;
		}
	}

	private sealed class CGPLLMGEKCN : IEnumerator, IDisposable, IEnumerator<object>
	{
		internal int FDCGIINEHPB;

		internal LevelBehaviour BFFOCDLAJMC;

		internal List<UnitUpgradeDefinition> KBBDGCLPOCJ;

		internal UnitUpgradeDefinition NDOIPCDEIKG;

		internal bool HMPNHIBCGKD;

		internal UpgradesManager BJGCPDNMHDH;

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
		private object PIPMONHGDPH()
		{
			return PHDOCKCBJOF;
		}

		public void GGCLMIMHKBD()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object JJBAIMILGLK()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object BNFADGLHBAH()
		{
			return PHDOCKCBJOF;
		}

		public void FGLAPPKJHBK()
		{
			throw new NotSupportedException();
		}

		[DebuggerHidden]
		public void Dispose()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		public void FJOIBBIGBJC()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[DebuggerHidden]
		public CGPLLMGEKCN()
		{
		}

		public void FOODPOJODAA()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public bool DDLMLOJGJMA()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				FDCGIINEHPB = 0;
				goto IL_0142;
			case 1u:
				FDCGIINEHPB += 0;
				goto IL_0142;
			default:
				{
					return false;
				}
				IL_0142:
				if (FDCGIINEHPB < LevelManager.instance.behaviours.Count)
				{
					BFFOCDLAJMC = LevelManager.instance.behaviours[FDCGIINEHPB];
					NDOIPCDEIKG = KBBDGCLPOCJ[FDCGIINEHPB];
					HMPNHIBCGKD = KBBDGCLPOCJ[FDCGIINEHPB].isEquipped;
					if (Singleton<GameController>.instance.isTutorial && (BFFOCDLAJMC is SoldierBehaviourBazooka || BFFOCDLAJMC is SoldierBehaviourGrennader || BFFOCDLAJMC is SoldierBehaviourSniper || BFFOCDLAJMC is SoldierBehaviourParachuter || BFFOCDLAJMC is SoldierBehaviourAssaulter || BFFOCDLAJMC is SoldierBehaviourShotgunner))
					{
						HMPNHIBCGKD = false;
					}
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BFFOCDLAJMC.PrepareVisualsForGameCoroutine(NDOIPCDEIKG.unitUpgrades, HMPNHIBCGKD, mine: true, unloadWeapon: true));
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				CLPPIAGLCJJ = -1;
				goto default;
			}
			return false;
		}

		public bool MoveNext()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				FDCGIINEHPB = 0;
				goto IL_0142;
			case 1u:
				FDCGIINEHPB++;
				goto IL_0142;
			default:
				{
					return false;
				}
				IL_0142:
				if (FDCGIINEHPB < LevelManager.instance.behaviours.Count)
				{
					BFFOCDLAJMC = LevelManager.instance.behaviours[FDCGIINEHPB];
					NDOIPCDEIKG = KBBDGCLPOCJ[FDCGIINEHPB];
					HMPNHIBCGKD = KBBDGCLPOCJ[FDCGIINEHPB].isEquipped;
					if (Singleton<GameController>.instance.isTutorial && (BFFOCDLAJMC is SoldierBehaviourBazooka || BFFOCDLAJMC is SoldierBehaviourGrennader || BFFOCDLAJMC is SoldierBehaviourSniper || BFFOCDLAJMC is SoldierBehaviourParachuter || BFFOCDLAJMC is SoldierBehaviourAssaulter || BFFOCDLAJMC is SoldierBehaviourShotgunner))
					{
						HMPNHIBCGKD = true;
					}
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BFFOCDLAJMC.PrepareVisualsForGameCoroutine(NDOIPCDEIKG.unitUpgrades, HMPNHIBCGKD, mine: false));
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				CLPPIAGLCJJ = -1;
				goto default;
			}
			return true;
		}

		[SpecialName]
		private object MPEPJNIDBLI()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object HCCLNDKNCIE()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object LMBPPPOFIOC()
		{
			return PHDOCKCBJOF;
		}
	}

	public IEnumerator OJFAHJCHLAI(List<UnitUpgradeDefinition> KBBDGCLPOCJ)
	{
		CGPLLMGEKCN cGPLLMGEKCN = new CGPLLMGEKCN();
		cGPLLMGEKCN.KBBDGCLPOCJ = KBBDGCLPOCJ;
		cGPLLMGEKCN.BJGCPDNMHDH = this;
		return cGPLLMGEKCN;
	}

	public void LMLELPFGNHG()
	{
		foreach (LevelBehaviour behaviour in LevelManager.instance.behaviours)
		{
			behaviour.upgradeSlots.NullMineVisuals();
			behaviour.upgradeSlots.NullOpponentVisuals();
			behaviour.upgradeSlots.NullCardVisuals(mine: true, opponent: true);
			behaviour.Unload();
		}
	}

	public IEnumerator NGBBFLOKOHP(List<UnitUpgradeDefinition> KBBDGCLPOCJ)
	{
		CGPLLMGEKCN cGPLLMGEKCN = new CGPLLMGEKCN();
		cGPLLMGEKCN.KBBDGCLPOCJ = KBBDGCLPOCJ;
		cGPLLMGEKCN.BJGCPDNMHDH = this;
		return cGPLLMGEKCN;
	}

	public IEnumerator LFDPAEFMHNG(List<UnitUpgradeDefinition> KBBDGCLPOCJ)
	{
		BOJCLEMBBIP bOJCLEMBBIP = new BOJCLEMBBIP();
		bOJCLEMBBIP.KBBDGCLPOCJ = KBBDGCLPOCJ;
		bOJCLEMBBIP.BJGCPDNMHDH = this;
		return bOJCLEMBBIP;
	}

	public IEnumerator IPBIJGDBFEF(List<UnitUpgradeDefinition> KBBDGCLPOCJ)
	{
		CGPLLMGEKCN cGPLLMGEKCN = new CGPLLMGEKCN();
		cGPLLMGEKCN.KBBDGCLPOCJ = KBBDGCLPOCJ;
		cGPLLMGEKCN.BJGCPDNMHDH = this;
		return cGPLLMGEKCN;
	}

	public IEnumerator DEGFJFCDLAF(List<UnitUpgradeDefinition> KBBDGCLPOCJ)
	{
		CGPLLMGEKCN cGPLLMGEKCN = new CGPLLMGEKCN();
		cGPLLMGEKCN.KBBDGCLPOCJ = KBBDGCLPOCJ;
		cGPLLMGEKCN.BJGCPDNMHDH = this;
		return cGPLLMGEKCN;
	}

	public IEnumerator DLEEGIADBFP(List<UnitUpgradeDefinition> KBBDGCLPOCJ)
	{
		BOJCLEMBBIP bOJCLEMBBIP = new BOJCLEMBBIP();
		bOJCLEMBBIP.KBBDGCLPOCJ = KBBDGCLPOCJ;
		bOJCLEMBBIP.BJGCPDNMHDH = this;
		return bOJCLEMBBIP;
	}

	public void EDKEHIEOCIG()
	{
		foreach (LevelBehaviour behaviour in LevelManager.instance.behaviours)
		{
			behaviour.upgradeSlots.NullMineVisuals();
			behaviour.upgradeSlots.NullOpponentVisuals();
			behaviour.upgradeSlots.NullCardVisuals(mine: false, opponent: true);
			behaviour.Unload();
		}
	}

	public void BCCFDFLCCLH()
	{
		foreach (LevelBehaviour behaviour in LevelManager.instance.behaviours)
		{
			behaviour.upgradeSlots.NullMineVisuals();
			behaviour.upgradeSlots.NullOpponentVisuals();
			behaviour.upgradeSlots.NullCardVisuals(mine: false, opponent: true);
			behaviour.Unload();
		}
	}

	public IEnumerator EPIKALEKDPB(List<UnitUpgradeDefinition> KBBDGCLPOCJ)
	{
		CGPLLMGEKCN cGPLLMGEKCN = new CGPLLMGEKCN();
		cGPLLMGEKCN.KBBDGCLPOCJ = KBBDGCLPOCJ;
		cGPLLMGEKCN.BJGCPDNMHDH = this;
		return cGPLLMGEKCN;
	}

	public void ADDPMDKHBFN()
	{
		foreach (LevelBehaviour behaviour in LevelManager.instance.behaviours)
		{
			behaviour.upgradeSlots.NullMineVisuals();
			behaviour.upgradeSlots.NullOpponentVisuals();
			behaviour.upgradeSlots.NullCardVisuals(mine: false, opponent: true);
			behaviour.Unload();
		}
	}

	public void BGGIGDFAHPM()
	{
		foreach (LevelBehaviour behaviour in LevelManager.instance.behaviours)
		{
			behaviour.upgradeSlots.NullMineVisuals();
			behaviour.upgradeSlots.NullOpponentVisuals();
			behaviour.upgradeSlots.NullCardVisuals(mine: true, opponent: false);
			behaviour.Unload();
		}
	}

	public void JEDJPCINKDP()
	{
		foreach (LevelBehaviour behaviour in LevelManager.instance.behaviours)
		{
			behaviour.upgradeSlots.NullMineVisuals();
			behaviour.upgradeSlots.NullOpponentVisuals();
			behaviour.upgradeSlots.NullCardVisuals(mine: false, opponent: true);
			behaviour.Unload();
		}
	}

	public IEnumerator CJACIIBMHOC(List<UnitUpgradeDefinition> KBBDGCLPOCJ)
	{
		CGPLLMGEKCN cGPLLMGEKCN = new CGPLLMGEKCN();
		cGPLLMGEKCN.KBBDGCLPOCJ = KBBDGCLPOCJ;
		cGPLLMGEKCN.BJGCPDNMHDH = this;
		return cGPLLMGEKCN;
	}

	public void AFMPNNPHFPK()
	{
		foreach (LevelBehaviour behaviour in LevelManager.instance.behaviours)
		{
			behaviour.upgradeSlots.NullMineVisuals();
			behaviour.upgradeSlots.NullOpponentVisuals();
			behaviour.upgradeSlots.NullCardVisuals(mine: false, opponent: false);
			behaviour.Unload();
		}
	}

	public IEnumerator HNMOPDMAONP(List<UnitUpgradeDefinition> KBBDGCLPOCJ)
	{
		CGPLLMGEKCN cGPLLMGEKCN = new CGPLLMGEKCN();
		cGPLLMGEKCN.KBBDGCLPOCJ = KBBDGCLPOCJ;
		cGPLLMGEKCN.BJGCPDNMHDH = this;
		return cGPLLMGEKCN;
	}

	public void AJAGCKMCGMH()
	{
		foreach (LevelBehaviour behaviour in LevelManager.instance.behaviours)
		{
			behaviour.upgradeSlots.NullMineVisuals();
			behaviour.upgradeSlots.NullOpponentVisuals();
			behaviour.upgradeSlots.NullCardVisuals(mine: true, opponent: false);
			behaviour.Unload();
		}
	}

	public IEnumerator LOIIIKBCICM(List<UnitUpgradeDefinition> KBBDGCLPOCJ)
	{
		CGPLLMGEKCN cGPLLMGEKCN = new CGPLLMGEKCN();
		cGPLLMGEKCN.KBBDGCLPOCJ = KBBDGCLPOCJ;
		cGPLLMGEKCN.BJGCPDNMHDH = this;
		return cGPLLMGEKCN;
	}

	public IEnumerator EDAMCGMGPAH(List<UnitUpgradeDefinition> KBBDGCLPOCJ)
	{
		CGPLLMGEKCN cGPLLMGEKCN = new CGPLLMGEKCN();
		cGPLLMGEKCN.KBBDGCLPOCJ = KBBDGCLPOCJ;
		cGPLLMGEKCN.BJGCPDNMHDH = this;
		return cGPLLMGEKCN;
	}

	public void JALOLJJEOGE()
	{
		foreach (LevelBehaviour behaviour in LevelManager.instance.behaviours)
		{
			behaviour.upgradeSlots.NullMineVisuals();
			behaviour.upgradeSlots.NullOpponentVisuals();
			behaviour.upgradeSlots.NullCardVisuals(mine: false, opponent: true);
			behaviour.Unload();
		}
	}

	public void AIJBNAHDIGJ()
	{
		foreach (LevelBehaviour behaviour in LevelManager.instance.behaviours)
		{
			behaviour.upgradeSlots.NullMineVisuals();
			behaviour.upgradeSlots.NullOpponentVisuals();
			behaviour.upgradeSlots.NullCardVisuals(mine: false, opponent: false);
			behaviour.Unload();
		}
	}

	public void IGHBMJJCPFH()
	{
		foreach (LevelBehaviour behaviour in LevelManager.instance.behaviours)
		{
			behaviour.upgradeSlots.NullMineVisuals();
			behaviour.upgradeSlots.NullOpponentVisuals();
			behaviour.upgradeSlots.NullCardVisuals(mine: false, opponent: false);
			behaviour.Unload();
		}
	}

	public IEnumerator PKOMOKDMNPE(List<UnitUpgradeDefinition> KBBDGCLPOCJ)
	{
		CGPLLMGEKCN cGPLLMGEKCN = new CGPLLMGEKCN();
		cGPLLMGEKCN.KBBDGCLPOCJ = KBBDGCLPOCJ;
		cGPLLMGEKCN.BJGCPDNMHDH = this;
		return cGPLLMGEKCN;
	}

	public IEnumerator MKMJAPMBMLH(List<UnitUpgradeDefinition> KBBDGCLPOCJ)
	{
		BOJCLEMBBIP bOJCLEMBBIP = new BOJCLEMBBIP();
		bOJCLEMBBIP.KBBDGCLPOCJ = KBBDGCLPOCJ;
		bOJCLEMBBIP.BJGCPDNMHDH = this;
		return bOJCLEMBBIP;
	}

	public void CNMFDAPDEDH()
	{
		foreach (LevelBehaviour behaviour in LevelManager.instance.behaviours)
		{
			behaviour.upgradeSlots.NullMineVisuals();
			behaviour.upgradeSlots.NullOpponentVisuals();
			behaviour.upgradeSlots.NullCardVisuals(mine: false, opponent: false);
			behaviour.Unload();
		}
	}

	public IEnumerator INPOHMCEPNK(List<UnitUpgradeDefinition> KBBDGCLPOCJ)
	{
		CGPLLMGEKCN cGPLLMGEKCN = new CGPLLMGEKCN();
		cGPLLMGEKCN.KBBDGCLPOCJ = KBBDGCLPOCJ;
		cGPLLMGEKCN.BJGCPDNMHDH = this;
		return cGPLLMGEKCN;
	}

	public void MELNDDADJBI()
	{
		foreach (LevelBehaviour behaviour in LevelManager.instance.behaviours)
		{
			behaviour.upgradeSlots.NullMineVisuals();
			behaviour.upgradeSlots.NullOpponentVisuals();
			behaviour.upgradeSlots.NullCardVisuals(mine: false, opponent: false);
			behaviour.Unload();
		}
	}

	public void BNDNGPKOAPB()
	{
		foreach (LevelBehaviour behaviour in LevelManager.instance.behaviours)
		{
			behaviour.upgradeSlots.NullMineVisuals();
			behaviour.upgradeSlots.NullOpponentVisuals();
			behaviour.upgradeSlots.NullCardVisuals(mine: true, opponent: false);
			behaviour.Unload();
		}
	}

	public IEnumerator AIDCKEPBKLD(List<UnitUpgradeDefinition> KBBDGCLPOCJ)
	{
		BOJCLEMBBIP bOJCLEMBBIP = new BOJCLEMBBIP();
		bOJCLEMBBIP.KBBDGCLPOCJ = KBBDGCLPOCJ;
		bOJCLEMBBIP.BJGCPDNMHDH = this;
		return bOJCLEMBBIP;
	}

	public IEnumerator ELANPOJLEPN(List<UnitUpgradeDefinition> KBBDGCLPOCJ)
	{
		CGPLLMGEKCN cGPLLMGEKCN = new CGPLLMGEKCN();
		cGPLLMGEKCN.KBBDGCLPOCJ = KBBDGCLPOCJ;
		cGPLLMGEKCN.BJGCPDNMHDH = this;
		return cGPLLMGEKCN;
	}

	public void AHJHNOILNME()
	{
		foreach (LevelBehaviour behaviour in LevelManager.instance.behaviours)
		{
			behaviour.upgradeSlots.NullMineVisuals();
			behaviour.upgradeSlots.NullOpponentVisuals();
			behaviour.upgradeSlots.NullCardVisuals(mine: false, opponent: false);
			behaviour.Unload();
		}
	}

	public IEnumerator FFMAGHFENAP(List<UnitUpgradeDefinition> KBBDGCLPOCJ)
	{
		BOJCLEMBBIP bOJCLEMBBIP = new BOJCLEMBBIP();
		bOJCLEMBBIP.KBBDGCLPOCJ = KBBDGCLPOCJ;
		bOJCLEMBBIP.BJGCPDNMHDH = this;
		return bOJCLEMBBIP;
	}

	public void CDCKAKCFEPH()
	{
		foreach (LevelBehaviour behaviour in LevelManager.instance.behaviours)
		{
			behaviour.upgradeSlots.NullMineVisuals();
			behaviour.upgradeSlots.NullOpponentVisuals();
			behaviour.upgradeSlots.NullCardVisuals(mine: false, opponent: true);
			behaviour.Unload();
		}
	}

	public IEnumerator HFHGAMPKNEK(List<UnitUpgradeDefinition> KBBDGCLPOCJ)
	{
		BOJCLEMBBIP bOJCLEMBBIP = new BOJCLEMBBIP();
		bOJCLEMBBIP.KBBDGCLPOCJ = KBBDGCLPOCJ;
		bOJCLEMBBIP.BJGCPDNMHDH = this;
		return bOJCLEMBBIP;
	}

	public IEnumerator JEEGJEPKMKM(List<UnitUpgradeDefinition> KBBDGCLPOCJ)
	{
		CGPLLMGEKCN cGPLLMGEKCN = new CGPLLMGEKCN();
		cGPLLMGEKCN.KBBDGCLPOCJ = KBBDGCLPOCJ;
		cGPLLMGEKCN.BJGCPDNMHDH = this;
		return cGPLLMGEKCN;
	}

	public void HJAFLPLCCAP()
	{
		foreach (LevelBehaviour behaviour in LevelManager.instance.behaviours)
		{
			behaviour.upgradeSlots.NullMineVisuals();
			behaviour.upgradeSlots.NullOpponentVisuals();
			behaviour.upgradeSlots.NullCardVisuals(mine: true, opponent: true);
			behaviour.Unload();
		}
	}

	public IEnumerator IJEIKPBIJPE(List<UnitUpgradeDefinition> KBBDGCLPOCJ)
	{
		BOJCLEMBBIP bOJCLEMBBIP = new BOJCLEMBBIP();
		bOJCLEMBBIP.KBBDGCLPOCJ = KBBDGCLPOCJ;
		bOJCLEMBBIP.BJGCPDNMHDH = this;
		return bOJCLEMBBIP;
	}

	public IEnumerator EGDEBLOHHBK(List<UnitUpgradeDefinition> KBBDGCLPOCJ)
	{
		BOJCLEMBBIP bOJCLEMBBIP = new BOJCLEMBBIP();
		bOJCLEMBBIP.KBBDGCLPOCJ = KBBDGCLPOCJ;
		bOJCLEMBBIP.BJGCPDNMHDH = this;
		return bOJCLEMBBIP;
	}

	public IEnumerator HAMMNLGJFON(List<UnitUpgradeDefinition> KBBDGCLPOCJ)
	{
		BOJCLEMBBIP bOJCLEMBBIP = new BOJCLEMBBIP();
		bOJCLEMBBIP.KBBDGCLPOCJ = KBBDGCLPOCJ;
		bOJCLEMBBIP.BJGCPDNMHDH = this;
		return bOJCLEMBBIP;
	}

	public IEnumerator OKHFKDNNLNA(List<UnitUpgradeDefinition> KBBDGCLPOCJ)
	{
		CGPLLMGEKCN cGPLLMGEKCN = new CGPLLMGEKCN();
		cGPLLMGEKCN.KBBDGCLPOCJ = KBBDGCLPOCJ;
		cGPLLMGEKCN.BJGCPDNMHDH = this;
		return cGPLLMGEKCN;
	}

	public IEnumerator NLOKMAOGIDK(List<UnitUpgradeDefinition> KBBDGCLPOCJ)
	{
		BOJCLEMBBIP bOJCLEMBBIP = new BOJCLEMBBIP();
		bOJCLEMBBIP.KBBDGCLPOCJ = KBBDGCLPOCJ;
		bOJCLEMBBIP.BJGCPDNMHDH = this;
		return bOJCLEMBBIP;
	}

	public IEnumerator LKNNHEPKDJP(List<UnitUpgradeDefinition> KBBDGCLPOCJ)
	{
		BOJCLEMBBIP bOJCLEMBBIP = new BOJCLEMBBIP();
		bOJCLEMBBIP.KBBDGCLPOCJ = KBBDGCLPOCJ;
		bOJCLEMBBIP.BJGCPDNMHDH = this;
		return bOJCLEMBBIP;
	}

	public IEnumerator KJNOGMEMINN(List<UnitUpgradeDefinition> KBBDGCLPOCJ)
	{
		BOJCLEMBBIP bOJCLEMBBIP = new BOJCLEMBBIP();
		bOJCLEMBBIP.KBBDGCLPOCJ = KBBDGCLPOCJ;
		bOJCLEMBBIP.BJGCPDNMHDH = this;
		return bOJCLEMBBIP;
	}

	public IEnumerator AJHAILODAHM(List<UnitUpgradeDefinition> KBBDGCLPOCJ)
	{
		BOJCLEMBBIP bOJCLEMBBIP = new BOJCLEMBBIP();
		bOJCLEMBBIP.KBBDGCLPOCJ = KBBDGCLPOCJ;
		bOJCLEMBBIP.BJGCPDNMHDH = this;
		return bOJCLEMBBIP;
	}

	public IEnumerator HACBEEBGCMO(List<UnitUpgradeDefinition> KBBDGCLPOCJ)
	{
		BOJCLEMBBIP bOJCLEMBBIP = new BOJCLEMBBIP();
		bOJCLEMBBIP.KBBDGCLPOCJ = KBBDGCLPOCJ;
		bOJCLEMBBIP.BJGCPDNMHDH = this;
		return bOJCLEMBBIP;
	}

	public IEnumerator DPOACGBGFIA(List<UnitUpgradeDefinition> KBBDGCLPOCJ)
	{
		CGPLLMGEKCN cGPLLMGEKCN = new CGPLLMGEKCN();
		cGPLLMGEKCN.KBBDGCLPOCJ = KBBDGCLPOCJ;
		cGPLLMGEKCN.BJGCPDNMHDH = this;
		return cGPLLMGEKCN;
	}

	public void GPIBOOAEOOD()
	{
		foreach (LevelBehaviour behaviour in LevelManager.instance.behaviours)
		{
			behaviour.upgradeSlots.NullMineVisuals();
			behaviour.upgradeSlots.NullOpponentVisuals();
			behaviour.upgradeSlots.NullCardVisuals(mine: true, opponent: false);
			behaviour.Unload();
		}
	}

	public void IEOLNHPFIBJ()
	{
		foreach (LevelBehaviour behaviour in LevelManager.instance.behaviours)
		{
			behaviour.upgradeSlots.NullMineVisuals();
			behaviour.upgradeSlots.NullOpponentVisuals();
			behaviour.upgradeSlots.NullCardVisuals(mine: true, opponent: false);
			behaviour.Unload();
		}
	}

	public IEnumerator HGPDIMKPINN(List<UnitUpgradeDefinition> KBBDGCLPOCJ)
	{
		CGPLLMGEKCN cGPLLMGEKCN = new CGPLLMGEKCN();
		cGPLLMGEKCN.KBBDGCLPOCJ = KBBDGCLPOCJ;
		cGPLLMGEKCN.BJGCPDNMHDH = this;
		return cGPLLMGEKCN;
	}

	public void BAAEIJHCOAJ()
	{
		foreach (LevelBehaviour behaviour in LevelManager.instance.behaviours)
		{
			behaviour.upgradeSlots.NullMineVisuals();
			behaviour.upgradeSlots.NullOpponentVisuals();
			behaviour.upgradeSlots.NullCardVisuals(mine: false, opponent: false);
			behaviour.Unload();
		}
	}

	public void CNDAFPABGAK()
	{
		foreach (LevelBehaviour behaviour in LevelManager.instance.behaviours)
		{
			behaviour.upgradeSlots.NullMineVisuals();
			behaviour.upgradeSlots.NullOpponentVisuals();
			behaviour.upgradeSlots.NullCardVisuals(mine: true, opponent: true);
			behaviour.Unload();
		}
	}

	public IEnumerator IHHKIGIJOHJ(List<UnitUpgradeDefinition> KBBDGCLPOCJ)
	{
		BOJCLEMBBIP bOJCLEMBBIP = new BOJCLEMBBIP();
		bOJCLEMBBIP.KBBDGCLPOCJ = KBBDGCLPOCJ;
		bOJCLEMBBIP.BJGCPDNMHDH = this;
		return bOJCLEMBBIP;
	}

	public IEnumerator ALCJENMGIMJ(List<UnitUpgradeDefinition> KBBDGCLPOCJ)
	{
		BOJCLEMBBIP bOJCLEMBBIP = new BOJCLEMBBIP();
		bOJCLEMBBIP.KBBDGCLPOCJ = KBBDGCLPOCJ;
		bOJCLEMBBIP.BJGCPDNMHDH = this;
		return bOJCLEMBBIP;
	}

	public IEnumerator NLIALMAJDAF(List<UnitUpgradeDefinition> KBBDGCLPOCJ)
	{
		BOJCLEMBBIP bOJCLEMBBIP = new BOJCLEMBBIP();
		bOJCLEMBBIP.KBBDGCLPOCJ = KBBDGCLPOCJ;
		bOJCLEMBBIP.BJGCPDNMHDH = this;
		return bOJCLEMBBIP;
	}

	public void PKNCJFPMBHG()
	{
		foreach (LevelBehaviour behaviour in LevelManager.instance.behaviours)
		{
			behaviour.upgradeSlots.NullMineVisuals();
			behaviour.upgradeSlots.NullOpponentVisuals();
			behaviour.upgradeSlots.NullCardVisuals(mine: true, opponent: true);
			behaviour.Unload();
		}
	}

	public IEnumerator HDPBDHCCBGO(List<UnitUpgradeDefinition> KBBDGCLPOCJ)
	{
		CGPLLMGEKCN cGPLLMGEKCN = new CGPLLMGEKCN();
		cGPLLMGEKCN.KBBDGCLPOCJ = KBBDGCLPOCJ;
		cGPLLMGEKCN.BJGCPDNMHDH = this;
		return cGPLLMGEKCN;
	}

	public IEnumerator CFKLBBOHAOB(List<UnitUpgradeDefinition> KBBDGCLPOCJ)
	{
		CGPLLMGEKCN cGPLLMGEKCN = new CGPLLMGEKCN();
		cGPLLMGEKCN.KBBDGCLPOCJ = KBBDGCLPOCJ;
		cGPLLMGEKCN.BJGCPDNMHDH = this;
		return cGPLLMGEKCN;
	}

	public IEnumerator DFLCBPJJNJM(List<UnitUpgradeDefinition> KBBDGCLPOCJ)
	{
		BOJCLEMBBIP bOJCLEMBBIP = new BOJCLEMBBIP();
		bOJCLEMBBIP.KBBDGCLPOCJ = KBBDGCLPOCJ;
		bOJCLEMBBIP.BJGCPDNMHDH = this;
		return bOJCLEMBBIP;
	}

	public void FEIPHDMGGEK()
	{
		foreach (LevelBehaviour behaviour in LevelManager.instance.behaviours)
		{
			behaviour.upgradeSlots.NullMineVisuals();
			behaviour.upgradeSlots.NullOpponentVisuals();
			behaviour.upgradeSlots.NullCardVisuals(mine: false, opponent: true);
			behaviour.Unload();
		}
	}

	public IEnumerator OJLCPFNGKNI(List<UnitUpgradeDefinition> KBBDGCLPOCJ)
	{
		BOJCLEMBBIP bOJCLEMBBIP = new BOJCLEMBBIP();
		bOJCLEMBBIP.KBBDGCLPOCJ = KBBDGCLPOCJ;
		bOJCLEMBBIP.BJGCPDNMHDH = this;
		return bOJCLEMBBIP;
	}

	[DebuggerHidden]
	public IEnumerator LoadOpponentUpgradesForGame(List<UnitUpgradeDefinition> KBBDGCLPOCJ)
	{
		CGPLLMGEKCN cGPLLMGEKCN = new CGPLLMGEKCN();
		cGPLLMGEKCN.KBBDGCLPOCJ = KBBDGCLPOCJ;
		cGPLLMGEKCN.BJGCPDNMHDH = this;
		return cGPLLMGEKCN;
	}

	public IEnumerator INOELOHHGOF(List<UnitUpgradeDefinition> KBBDGCLPOCJ)
	{
		BOJCLEMBBIP bOJCLEMBBIP = new BOJCLEMBBIP();
		bOJCLEMBBIP.KBBDGCLPOCJ = KBBDGCLPOCJ;
		bOJCLEMBBIP.BJGCPDNMHDH = this;
		return bOJCLEMBBIP;
	}

	public IEnumerator DICNMOCOEPN(List<UnitUpgradeDefinition> KBBDGCLPOCJ)
	{
		CGPLLMGEKCN cGPLLMGEKCN = new CGPLLMGEKCN();
		cGPLLMGEKCN.KBBDGCLPOCJ = KBBDGCLPOCJ;
		cGPLLMGEKCN.BJGCPDNMHDH = this;
		return cGPLLMGEKCN;
	}

	public IEnumerator ALLMFMGKLOC(List<UnitUpgradeDefinition> KBBDGCLPOCJ)
	{
		BOJCLEMBBIP bOJCLEMBBIP = new BOJCLEMBBIP();
		bOJCLEMBBIP.KBBDGCLPOCJ = KBBDGCLPOCJ;
		bOJCLEMBBIP.BJGCPDNMHDH = this;
		return bOJCLEMBBIP;
	}

	public IEnumerator NHKNGKPLBPG(List<UnitUpgradeDefinition> KBBDGCLPOCJ)
	{
		CGPLLMGEKCN cGPLLMGEKCN = new CGPLLMGEKCN();
		cGPLLMGEKCN.KBBDGCLPOCJ = KBBDGCLPOCJ;
		cGPLLMGEKCN.BJGCPDNMHDH = this;
		return cGPLLMGEKCN;
	}

	public void MLNNPBMEOOM()
	{
		foreach (LevelBehaviour behaviour in LevelManager.instance.behaviours)
		{
			behaviour.upgradeSlots.NullMineVisuals();
			behaviour.upgradeSlots.NullOpponentVisuals();
			behaviour.upgradeSlots.NullCardVisuals(mine: true, opponent: false);
			behaviour.Unload();
		}
	}

	public IEnumerator AAIMOEBAGCB(List<UnitUpgradeDefinition> KBBDGCLPOCJ)
	{
		BOJCLEMBBIP bOJCLEMBBIP = new BOJCLEMBBIP();
		bOJCLEMBBIP.KBBDGCLPOCJ = KBBDGCLPOCJ;
		bOJCLEMBBIP.BJGCPDNMHDH = this;
		return bOJCLEMBBIP;
	}

	public IEnumerator BMKKDAANFFE(List<UnitUpgradeDefinition> KBBDGCLPOCJ)
	{
		CGPLLMGEKCN cGPLLMGEKCN = new CGPLLMGEKCN();
		cGPLLMGEKCN.KBBDGCLPOCJ = KBBDGCLPOCJ;
		cGPLLMGEKCN.BJGCPDNMHDH = this;
		return cGPLLMGEKCN;
	}

	public IEnumerator PMFPOMKHLLA(List<UnitUpgradeDefinition> KBBDGCLPOCJ)
	{
		BOJCLEMBBIP bOJCLEMBBIP = new BOJCLEMBBIP();
		bOJCLEMBBIP.KBBDGCLPOCJ = KBBDGCLPOCJ;
		bOJCLEMBBIP.BJGCPDNMHDH = this;
		return bOJCLEMBBIP;
	}

	public IEnumerator POCCHKOAMOG(List<UnitUpgradeDefinition> KBBDGCLPOCJ)
	{
		BOJCLEMBBIP bOJCLEMBBIP = new BOJCLEMBBIP();
		bOJCLEMBBIP.KBBDGCLPOCJ = KBBDGCLPOCJ;
		bOJCLEMBBIP.BJGCPDNMHDH = this;
		return bOJCLEMBBIP;
	}

	public void DKGMPHOIHHF()
	{
		foreach (LevelBehaviour behaviour in LevelManager.instance.behaviours)
		{
			behaviour.upgradeSlots.NullMineVisuals();
			behaviour.upgradeSlots.NullOpponentVisuals();
			behaviour.upgradeSlots.NullCardVisuals(mine: false, opponent: true);
			behaviour.Unload();
		}
	}

	public IEnumerator PMIBKCKBIME(List<UnitUpgradeDefinition> KBBDGCLPOCJ)
	{
		BOJCLEMBBIP bOJCLEMBBIP = new BOJCLEMBBIP();
		bOJCLEMBBIP.KBBDGCLPOCJ = KBBDGCLPOCJ;
		bOJCLEMBBIP.BJGCPDNMHDH = this;
		return bOJCLEMBBIP;
	}

	public IEnumerator AEBBBEFIBHB(List<UnitUpgradeDefinition> KBBDGCLPOCJ)
	{
		BOJCLEMBBIP bOJCLEMBBIP = new BOJCLEMBBIP();
		bOJCLEMBBIP.KBBDGCLPOCJ = KBBDGCLPOCJ;
		bOJCLEMBBIP.BJGCPDNMHDH = this;
		return bOJCLEMBBIP;
	}

	public void UnloadAll()
	{
		foreach (LevelBehaviour behaviour in LevelManager.instance.behaviours)
		{
			behaviour.upgradeSlots.NullMineVisuals();
			behaviour.upgradeSlots.NullOpponentVisuals();
			behaviour.upgradeSlots.NullCardVisuals(mine: true, opponent: true);
			behaviour.Unload();
		}
	}

	public IEnumerator MENLJAJLFOM(List<UnitUpgradeDefinition> KBBDGCLPOCJ)
	{
		CGPLLMGEKCN cGPLLMGEKCN = new CGPLLMGEKCN();
		cGPLLMGEKCN.KBBDGCLPOCJ = KBBDGCLPOCJ;
		cGPLLMGEKCN.BJGCPDNMHDH = this;
		return cGPLLMGEKCN;
	}

	public IEnumerator EGBFNBAHFAH(List<UnitUpgradeDefinition> KBBDGCLPOCJ)
	{
		BOJCLEMBBIP bOJCLEMBBIP = new BOJCLEMBBIP();
		bOJCLEMBBIP.KBBDGCLPOCJ = KBBDGCLPOCJ;
		bOJCLEMBBIP.BJGCPDNMHDH = this;
		return bOJCLEMBBIP;
	}

	public IEnumerator EGDONFCBPKL(List<UnitUpgradeDefinition> KBBDGCLPOCJ)
	{
		CGPLLMGEKCN cGPLLMGEKCN = new CGPLLMGEKCN();
		cGPLLMGEKCN.KBBDGCLPOCJ = KBBDGCLPOCJ;
		cGPLLMGEKCN.BJGCPDNMHDH = this;
		return cGPLLMGEKCN;
	}

	public IEnumerator MEJDHGEOJFM(List<UnitUpgradeDefinition> KBBDGCLPOCJ)
	{
		CGPLLMGEKCN cGPLLMGEKCN = new CGPLLMGEKCN();
		cGPLLMGEKCN.KBBDGCLPOCJ = KBBDGCLPOCJ;
		cGPLLMGEKCN.BJGCPDNMHDH = this;
		return cGPLLMGEKCN;
	}

	public IEnumerator LMPNIBKNJKP(List<UnitUpgradeDefinition> KBBDGCLPOCJ)
	{
		BOJCLEMBBIP bOJCLEMBBIP = new BOJCLEMBBIP();
		bOJCLEMBBIP.KBBDGCLPOCJ = KBBDGCLPOCJ;
		bOJCLEMBBIP.BJGCPDNMHDH = this;
		return bOJCLEMBBIP;
	}

	public IEnumerator PHLEEDHECMI(List<UnitUpgradeDefinition> KBBDGCLPOCJ)
	{
		BOJCLEMBBIP bOJCLEMBBIP = new BOJCLEMBBIP();
		bOJCLEMBBIP.KBBDGCLPOCJ = KBBDGCLPOCJ;
		bOJCLEMBBIP.BJGCPDNMHDH = this;
		return bOJCLEMBBIP;
	}

	[DebuggerHidden]
	public IEnumerator LoadMineUpgrades(List<UnitUpgradeDefinition> KBBDGCLPOCJ)
	{
		BOJCLEMBBIP bOJCLEMBBIP = new BOJCLEMBBIP();
		bOJCLEMBBIP.KBBDGCLPOCJ = KBBDGCLPOCJ;
		bOJCLEMBBIP.BJGCPDNMHDH = this;
		return bOJCLEMBBIP;
	}

	public IEnumerator AHLLPIMMHPE(List<UnitUpgradeDefinition> KBBDGCLPOCJ)
	{
		BOJCLEMBBIP bOJCLEMBBIP = new BOJCLEMBBIP();
		bOJCLEMBBIP.KBBDGCLPOCJ = KBBDGCLPOCJ;
		bOJCLEMBBIP.BJGCPDNMHDH = this;
		return bOJCLEMBBIP;
	}

	public void LANBGBKDOPF()
	{
		foreach (LevelBehaviour behaviour in LevelManager.instance.behaviours)
		{
			behaviour.upgradeSlots.NullMineVisuals();
			behaviour.upgradeSlots.NullOpponentVisuals();
			behaviour.upgradeSlots.NullCardVisuals(mine: false, opponent: false);
			behaviour.Unload();
		}
	}
}
