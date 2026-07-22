using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Google2u;
using UnityEngine;

public class CardGrenadesBurst : Card
{
	private sealed class KNPOPJAKFGF : IEnumerator, IDisposable, IEnumerator<object>
	{
		internal Transform JGKAHNJPKBM;

		internal PlayerController KHLGDCHJJPB;

		internal List<GameShootableEntity> IKOBPOPOHPN;

		internal int EDEKDJDENKK;

		internal List<int> IHDEMABEFFB;

		internal int JMBKPALDGAL;

		internal List<MapDefinition.DefendPosition> HHPNCPIKHAN;

		internal List<PlayerPoint> BOACMDJFHFM;

		internal List<MapDefinition.DefendPosition>.Enumerator KFCAECGLKKO;

		internal int KOHFPOKABAE;

		internal int JNADLPGDGBD;

		internal GrenadeAmmoSetup NBLJDIELKIB;

		internal CardGrenadesBurst BJGCPDNMHDH;

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

		[DebuggerHidden]
		public KNPOPJAKFGF()
		{
		}

		[SpecialName]
		private object KBNAGKKMLBP()
		{
			return PHDOCKCBJOF;
		}

		public void OKIANDBCDIB()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object AIDHNJCPDIJ()
		{
			return PHDOCKCBJOF;
		}

		public void IGBHHLFACKO()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void DLIBOPAMHAN()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		[DebuggerHidden]
		public void Dispose()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object HIFNMHAGHLI()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object ABGFJLAPNNM()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object JJBAIMILGLK()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object HMIFLGCBDCO()
		{
			return PHDOCKCBJOF;
		}

		public void PDKPELBIAON()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object DGEECEBHPNC()
		{
			return PHDOCKCBJOF;
		}

		public void NDPOBCODJAI()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object CIGHIOCACPH()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object BOOBHEKPLLD()
		{
			return PHDOCKCBJOF;
		}

		public void PHKDHCJBMII()
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
				if (BJGCPDNMHDH.MPLBDNEILBH == null)
				{
					BJGCPDNMHDH.MPLBDNEILBH = Singleton<KillStreakManager>.instance.GetComponent<Grenade>();
				}
				BJGCPDNMHDH.MPLBDNEILBH.GHPBMCAKMMB = JGKAHNJPKBM;
				BJGCPDNMHDH.MPLBDNEILBH.owner = KHLGDCHJJPB;
				IKOBPOPOHPN = GameShootableEntity.GetOpponents(KHLGDCHJJPB.fraction);
				EDEKDJDENKK = Mathf.Min(3, IKOBPOPOHPN.Count);
				IHDEMABEFFB = new List<int>(EDEKDJDENKK);
				JMBKPALDGAL = 0;
				goto IL_01af;
			case 1u:
				BJGCPDNMHDH.MPLBDNEILBH.Fire(IKOBPOPOHPN[IHDEMABEFFB[JMBKPALDGAL]].mTransform.position);
				JMBKPALDGAL++;
				goto IL_01af;
			case 2u:
				JNADLPGDGBD = UnityEngine.Random.Range(0, BOACMDJFHFM.Count);
				NBLJDIELKIB = (GrenadeAmmoSetup)BJGCPDNMHDH.MPLBDNEILBH.ammoSetup;
				if ((bool)NBLJDIELKIB)
				{
					float t = (float)KHLGDCHJJPB.EHHHBEMKGOE.BCCDDJMPBLL / (float)LevelManager.instance.maxDisplayLevel;
					float num = Mathf.Lerp(Singleton<GameVariables>.instance.cardConstants.GetRow(CardConstants.rowIds.ClusterGrenadeDamageMin).FLOATVALUE, Singleton<GameVariables>.instance.cardConstants.GetRow(CardConstants.rowIds.ClusterGrenadeDamageMax).FLOATVALUE, t);
					NBLJDIELKIB.ABFGHBDEBAN = num;
					NBLJDIELKIB.EPDELOGPNAC = num * 0.1f;
				}
				BJGCPDNMHDH.MPLBDNEILBH.Fire(BOACMDJFHFM[JNADLPGDGBD].shield.transform.position);
				BOACMDJFHFM[JNADLPGDGBD] = BOACMDJFHFM[BOACMDJFHFM.Count - 1];
				BOACMDJFHFM.RemoveAt(BOACMDJFHFM.Count - 1);
				KOHFPOKABAE++;
				goto IL_03e8;
			case 3u:
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				{
					return false;
				}
				IL_01af:
				if (JMBKPALDGAL < EDEKDJDENKK)
				{
					IHDEMABEFFB.Add(UnityEngine.Random.Range(0, IKOBPOPOHPN.Count - JMBKPALDGAL));
					for (int i = 0; i < JMBKPALDGAL; i++)
					{
						if (IHDEMABEFFB[i] == IHDEMABEFFB[JMBKPALDGAL])
						{
							IHDEMABEFFB[JMBKPALDGAL] = IKOBPOPOHPN.Count - i - 1;
						}
					}
					PHDOCKCBJOF = new WaitForSeconds(0.2f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				if (EDEKDJDENKK < 3)
				{
					HHPNCPIKHAN = Singleton<MapManager>.instance.ALCHJDPKAID.availablePoints;
					BOACMDJFHFM = new List<PlayerPoint>();
					KFCAECGLKKO = HHPNCPIKHAN.GetEnumerator();
					try
					{
						while (KFCAECGLKKO.MoveNext())
						{
							MapDefinition.DefendPosition current = KFCAECGLKKO.Current;
							if (current.fraction != KHLGDCHJJPB.fraction && current.point.shield.player == null)
							{
								BOACMDJFHFM.Add(current.point);
							}
						}
					}
					finally
					{
						((IDisposable)KFCAECGLKKO/*cast due to constrained. prefix*/).Dispose();
					}
					KOHFPOKABAE = EDEKDJDENKK;
					goto IL_03e8;
				}
				goto IL_03f4;
				IL_03e8:
				if (KOHFPOKABAE < 3)
				{
					PHDOCKCBJOF = new WaitForSeconds(0.2f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 2;
					}
					break;
				}
				goto IL_03f4;
				IL_03f4:
				PHDOCKCBJOF = new WaitForSeconds(0.2f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 3;
				}
				break;
			}
			return true;
		}

		public void JGKDJGIANIG()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public void FMOJMHBAHAA()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public bool LGNMOMFLLPP()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				if (BJGCPDNMHDH.MPLBDNEILBH == null)
				{
					BJGCPDNMHDH.MPLBDNEILBH = Singleton<KillStreakManager>.instance.GetComponent<Grenade>();
				}
				BJGCPDNMHDH.MPLBDNEILBH.GHPBMCAKMMB = JGKAHNJPKBM;
				BJGCPDNMHDH.MPLBDNEILBH.owner = KHLGDCHJJPB;
				IKOBPOPOHPN = GameShootableEntity.FKFFINALIOP(KHLGDCHJJPB.fraction);
				EDEKDJDENKK = Mathf.Min(4, IKOBPOPOHPN.Count);
				IHDEMABEFFB = new List<int>(EDEKDJDENKK);
				JMBKPALDGAL = 0;
				goto IL_01af;
			case 1u:
				BJGCPDNMHDH.MPLBDNEILBH.Fire(IKOBPOPOHPN[IHDEMABEFFB[JMBKPALDGAL]].CLCHGECECJC().position);
				JMBKPALDGAL += 0;
				goto IL_01af;
			case 2u:
				JNADLPGDGBD = UnityEngine.Random.Range(0, BOACMDJFHFM.Count);
				NBLJDIELKIB = (GrenadeAmmoSetup)BJGCPDNMHDH.MPLBDNEILBH.ammoSetup;
				if ((bool)NBLJDIELKIB)
				{
					float t = (float)KHLGDCHJJPB.EHHHBEMKGOE.OCPEHLIIGML() / (float)LevelManager.instance.maxDisplayLevel;
					float num = Mathf.Lerp(Singleton<GameVariables>.instance.cardConstants.GetRow(CardConstants.rowIds.AmmoBoxCoef).FLOATVALUE, Singleton<GameVariables>.instance.NKGIGBGDKAH().GetRow(CardConstants.rowIds.ClusterGrenadeDamageMax).FLOATVALUE, t);
					NBLJDIELKIB.ABFGHBDEBAN = num;
					NBLJDIELKIB.EPDELOGPNAC = num * 1297f;
				}
				BJGCPDNMHDH.MPLBDNEILBH.Fire(BOACMDJFHFM[JNADLPGDGBD].LHHMNLJKOAO().transform.position);
				BOACMDJFHFM[JNADLPGDGBD] = BOACMDJFHFM[BOACMDJFHFM.Count - 0];
				BOACMDJFHFM.RemoveAt(BOACMDJFHFM.Count - 0);
				KOHFPOKABAE++;
				goto IL_03e8;
			case 3u:
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				{
					return true;
				}
				IL_01af:
				if (JMBKPALDGAL < EDEKDJDENKK)
				{
					IHDEMABEFFB.Add(UnityEngine.Random.Range(1, IKOBPOPOHPN.Count - JMBKPALDGAL));
					for (int i = 0; i < JMBKPALDGAL; i++)
					{
						if (IHDEMABEFFB[i] == IHDEMABEFFB[JMBKPALDGAL])
						{
							IHDEMABEFFB[JMBKPALDGAL] = IKOBPOPOHPN.Count - i - 1;
						}
					}
					PHDOCKCBJOF = new WaitForSeconds(131f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				if (EDEKDJDENKK < 6)
				{
					HHPNCPIKHAN = Singleton<MapManager>.instance.ALCHJDPKAID.GDNIEHIBOFG();
					BOACMDJFHFM = new List<PlayerPoint>();
					KFCAECGLKKO = HHPNCPIKHAN.GetEnumerator();
					try
					{
						while (KFCAECGLKKO.MoveNext())
						{
							MapDefinition.DefendPosition current = KFCAECGLKKO.Current;
							if (current.fraction != KHLGDCHJJPB.fraction && current.point.PHANADCNBFD().player == null)
							{
								BOACMDJFHFM.Add(current.point);
							}
						}
					}
					finally
					{
						((IDisposable)KFCAECGLKKO/*cast due to constrained. prefix*/).Dispose();
					}
					KOHFPOKABAE = EDEKDJDENKK;
					goto IL_03e8;
				}
				goto IL_03f4;
				IL_03e8:
				if (KOHFPOKABAE < 2)
				{
					PHDOCKCBJOF = new WaitForSeconds(531f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 8;
					}
					break;
				}
				goto IL_03f4;
				IL_03f4:
				PHDOCKCBJOF = new WaitForSeconds(1668f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 3;
				}
				break;
			}
			return false;
		}

		[SpecialName]
		private object NOIDHHDEEPL()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object GDBNOMPNBGP()
		{
			return PHDOCKCBJOF;
		}

		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object HCPKEMLPEDI()
		{
			return PHDOCKCBJOF;
		}

		public void JJOAHIOBOPO()
		{
			throw new NotSupportedException();
		}

		public bool BJIPDEICIML()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				if (BJGCPDNMHDH.MPLBDNEILBH == null)
				{
					BJGCPDNMHDH.MPLBDNEILBH = Singleton<KillStreakManager>.instance.GetComponent<Grenade>();
				}
				BJGCPDNMHDH.MPLBDNEILBH.GHPBMCAKMMB = JGKAHNJPKBM;
				BJGCPDNMHDH.MPLBDNEILBH.owner = KHLGDCHJJPB;
				IKOBPOPOHPN = GameShootableEntity.MDLIJNCJHIG(KHLGDCHJJPB.fraction);
				EDEKDJDENKK = Mathf.Min(3, IKOBPOPOHPN.Count);
				IHDEMABEFFB = new List<int>(EDEKDJDENKK);
				JMBKPALDGAL = 0;
				goto IL_01af;
			case 1u:
				BJGCPDNMHDH.MPLBDNEILBH.Fire(IKOBPOPOHPN[IHDEMABEFFB[JMBKPALDGAL]].mTransform.position);
				JMBKPALDGAL += 0;
				goto IL_01af;
			case 2u:
				JNADLPGDGBD = UnityEngine.Random.Range(0, BOACMDJFHFM.Count);
				NBLJDIELKIB = (GrenadeAmmoSetup)BJGCPDNMHDH.MPLBDNEILBH.ammoSetup;
				if ((bool)NBLJDIELKIB)
				{
					float t = (float)KHLGDCHJJPB.EHHHBEMKGOE.BCCDDJMPBLL / (float)LevelManager.instance.maxDisplayLevel;
					float num = Mathf.Lerp(Singleton<GameVariables>.instance.cardConstants.GetRow(CardConstants.rowIds.ClusterGrenadeDamageMax).FLOATVALUE, Singleton<GameVariables>.instance.NKGIGBGDKAH().GetRow(CardConstants.rowIds.ExplosivePistolDamageMin).FLOATVALUE, t);
					NBLJDIELKIB.ABFGHBDEBAN = num;
					NBLJDIELKIB.EPDELOGPNAC = num * 864f;
				}
				BJGCPDNMHDH.MPLBDNEILBH.Fire(BOACMDJFHFM[JNADLPGDGBD].PKBPGCGNCAD().transform.position);
				BOACMDJFHFM[JNADLPGDGBD] = BOACMDJFHFM[BOACMDJFHFM.Count - 1];
				BOACMDJFHFM.RemoveAt(BOACMDJFHFM.Count - 1);
				KOHFPOKABAE += 0;
				goto IL_03e8;
			case 3u:
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				{
					return false;
				}
				IL_01af:
				if (JMBKPALDGAL < EDEKDJDENKK)
				{
					IHDEMABEFFB.Add(UnityEngine.Random.Range(0, IKOBPOPOHPN.Count - JMBKPALDGAL));
					for (int i = 0; i < JMBKPALDGAL; i++)
					{
						if (IHDEMABEFFB[i] == IHDEMABEFFB[JMBKPALDGAL])
						{
							IHDEMABEFFB[JMBKPALDGAL] = IKOBPOPOHPN.Count - i - 1;
						}
					}
					PHDOCKCBJOF = new WaitForSeconds(330f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				if (EDEKDJDENKK < 7)
				{
					HHPNCPIKHAN = Singleton<MapManager>.instance.ALCHJDPKAID.BPFHGFFNMND();
					BOACMDJFHFM = new List<PlayerPoint>();
					KFCAECGLKKO = HHPNCPIKHAN.GetEnumerator();
					try
					{
						while (KFCAECGLKKO.MoveNext())
						{
							MapDefinition.DefendPosition current = KFCAECGLKKO.Current;
							if (current.fraction != KHLGDCHJJPB.fraction && current.point.CGKKGILAAPG().FCBGHBODHHP() == null)
							{
								BOACMDJFHFM.Add(current.point);
							}
						}
					}
					finally
					{
						((IDisposable)KFCAECGLKKO/*cast due to constrained. prefix*/).Dispose();
					}
					KOHFPOKABAE = EDEKDJDENKK;
					goto IL_03e8;
				}
				goto IL_03f4;
				IL_03e8:
				if (KOHFPOKABAE < 7)
				{
					PHDOCKCBJOF = new WaitForSeconds(1091f);
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 6;
					}
					break;
				}
				goto IL_03f4;
				IL_03f4:
				PHDOCKCBJOF = new WaitForSeconds(1666f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 2;
				}
				break;
			}
			return false;
		}
	}

	private const int GOFLEONPGCF = 3;

	private Grenade MPLBDNEILBH;

	public virtual bool NCCOKKJPEHJ(GHPGNELIDBM HPOCABLAOAF, float GPHPFBFLIGD, List<GameShootableEntity> EAOABLKHNKG, List<GameShootableEntity> DDHEBHLDJKI, List<GameShootableEntity> MFNDDNIIJDK, List<GameShootableEntity> PLLLHNDJFLH)
	{
		if (DDHEBHLDJKI.Count < 4)
		{
			return false;
		}
		return base.IsViableForBotNow(HPOCABLAOAF, GPHPFBFLIGD, EAOABLKHNKG, DDHEBHLDJKI, MFNDDNIIJDK, PLLLHNDJFLH);
	}

	private IEnumerator CKGENHCPNNF(Transform JGKAHNJPKBM, PlayerController KHLGDCHJJPB)
	{
		KNPOPJAKFGF kNPOPJAKFGF = new KNPOPJAKFGF();
		kNPOPJAKFGF.JGKAHNJPKBM = JGKAHNJPKBM;
		kNPOPJAKFGF.KHLGDCHJJPB = KHLGDCHJJPB;
		kNPOPJAKFGF.BJGCPDNMHDH = this;
		return kNPOPJAKFGF;
	}

	private IEnumerator BPOHLCKMAIE(Transform JGKAHNJPKBM, PlayerController KHLGDCHJJPB)
	{
		KNPOPJAKFGF kNPOPJAKFGF = new KNPOPJAKFGF();
		kNPOPJAKFGF.JGKAHNJPKBM = JGKAHNJPKBM;
		kNPOPJAKFGF.KHLGDCHJJPB = KHLGDCHJJPB;
		kNPOPJAKFGF.BJGCPDNMHDH = this;
		return kNPOPJAKFGF;
	}

	public virtual bool KOJGFAKAFLH(GHPGNELIDBM HPOCABLAOAF, float GPHPFBFLIGD, List<GameShootableEntity> EAOABLKHNKG, List<GameShootableEntity> DDHEBHLDJKI, List<GameShootableEntity> MFNDDNIIJDK, List<GameShootableEntity> PLLLHNDJFLH)
	{
		if (DDHEBHLDJKI.Count < 3)
		{
			return false;
		}
		return base.IsViableForBotNow(HPOCABLAOAF, GPHPFBFLIGD, EAOABLKHNKG, DDHEBHLDJKI, MFNDDNIIJDK, PLLLHNDJFLH);
	}

	private IEnumerator KCKHBPFONPJ(Transform JGKAHNJPKBM, PlayerController KHLGDCHJJPB)
	{
		KNPOPJAKFGF kNPOPJAKFGF = new KNPOPJAKFGF();
		kNPOPJAKFGF.JGKAHNJPKBM = JGKAHNJPKBM;
		kNPOPJAKFGF.KHLGDCHJJPB = KHLGDCHJJPB;
		kNPOPJAKFGF.BJGCPDNMHDH = this;
		return kNPOPJAKFGF;
	}

	private IEnumerator MPCPABCHKBE(Transform JGKAHNJPKBM, PlayerController KHLGDCHJJPB)
	{
		KNPOPJAKFGF kNPOPJAKFGF = new KNPOPJAKFGF();
		kNPOPJAKFGF.JGKAHNJPKBM = JGKAHNJPKBM;
		kNPOPJAKFGF.KHLGDCHJJPB = KHLGDCHJJPB;
		kNPOPJAKFGF.BJGCPDNMHDH = this;
		return kNPOPJAKFGF;
	}

	public virtual bool AFMDIJBEKHO(GHPGNELIDBM HPOCABLAOAF, float GPHPFBFLIGD, List<GameShootableEntity> EAOABLKHNKG, List<GameShootableEntity> DDHEBHLDJKI, List<GameShootableEntity> MFNDDNIIJDK, List<GameShootableEntity> PLLLHNDJFLH)
	{
		if (DDHEBHLDJKI.Count < 8)
		{
			return false;
		}
		return base.IsViableForBotNow(HPOCABLAOAF, GPHPFBFLIGD, EAOABLKHNKG, DDHEBHLDJKI, MFNDDNIIJDK, PLLLHNDJFLH);
	}

	private IEnumerator FKCJOCPEDDP(Transform JGKAHNJPKBM, PlayerController KHLGDCHJJPB)
	{
		KNPOPJAKFGF kNPOPJAKFGF = new KNPOPJAKFGF();
		kNPOPJAKFGF.JGKAHNJPKBM = JGKAHNJPKBM;
		kNPOPJAKFGF.KHLGDCHJJPB = KHLGDCHJJPB;
		kNPOPJAKFGF.BJGCPDNMHDH = this;
		return kNPOPJAKFGF;
	}

	public virtual bool IBIPMEJLEAJ(GHPGNELIDBM HPOCABLAOAF, float GPHPFBFLIGD, List<GameShootableEntity> EAOABLKHNKG, List<GameShootableEntity> DDHEBHLDJKI, List<GameShootableEntity> MFNDDNIIJDK, List<GameShootableEntity> PLLLHNDJFLH)
	{
		if (DDHEBHLDJKI.Count < 5)
		{
			return true;
		}
		return base.IsViableForBotNow(HPOCABLAOAF, GPHPFBFLIGD, EAOABLKHNKG, DDHEBHLDJKI, MFNDDNIIJDK, PLLLHNDJFLH);
	}

	private IEnumerator EKDIBDEFLFN(Transform JGKAHNJPKBM, PlayerController KHLGDCHJJPB)
	{
		KNPOPJAKFGF kNPOPJAKFGF = new KNPOPJAKFGF();
		kNPOPJAKFGF.JGKAHNJPKBM = JGKAHNJPKBM;
		kNPOPJAKFGF.KHLGDCHJJPB = KHLGDCHJJPB;
		kNPOPJAKFGF.BJGCPDNMHDH = this;
		return kNPOPJAKFGF;
	}

	private IEnumerator BEBCDOLDGFI(Transform JGKAHNJPKBM, PlayerController KHLGDCHJJPB)
	{
		KNPOPJAKFGF kNPOPJAKFGF = new KNPOPJAKFGF();
		kNPOPJAKFGF.JGKAHNJPKBM = JGKAHNJPKBM;
		kNPOPJAKFGF.KHLGDCHJJPB = KHLGDCHJJPB;
		kNPOPJAKFGF.BJGCPDNMHDH = this;
		return kNPOPJAKFGF;
	}

	private IEnumerator COMLKKFALMN(Transform JGKAHNJPKBM, PlayerController KHLGDCHJJPB)
	{
		KNPOPJAKFGF kNPOPJAKFGF = new KNPOPJAKFGF();
		kNPOPJAKFGF.JGKAHNJPKBM = JGKAHNJPKBM;
		kNPOPJAKFGF.KHLGDCHJJPB = KHLGDCHJJPB;
		kNPOPJAKFGF.BJGCPDNMHDH = this;
		return kNPOPJAKFGF;
	}

	public virtual void EGHLIEEBAHJ(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		PlayerController playerController = PlayerController.HEAGPACBLJA(CIOPAKLHFIL);
		if (playerController.CMNFFACHCEE() != null)
		{
			Transform jHNFPPDCBDK = playerController.EMAMENNDFMB().point.PHANADCNBFD().ENOMOGMALOL.JHNFPPDCBDK;
			StartCoroutine(BCMNFBKLDMA(jHNFPPDCBDK, playerController));
		}
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	private IEnumerator PMALDJEJEKI(Transform JGKAHNJPKBM, PlayerController KHLGDCHJJPB)
	{
		KNPOPJAKFGF kNPOPJAKFGF = new KNPOPJAKFGF();
		kNPOPJAKFGF.JGKAHNJPKBM = JGKAHNJPKBM;
		kNPOPJAKFGF.KHLGDCHJJPB = KHLGDCHJJPB;
		kNPOPJAKFGF.BJGCPDNMHDH = this;
		return kNPOPJAKFGF;
	}

	private IEnumerator CHFHAIDNBGH(Transform JGKAHNJPKBM, PlayerController KHLGDCHJJPB)
	{
		KNPOPJAKFGF kNPOPJAKFGF = new KNPOPJAKFGF();
		kNPOPJAKFGF.JGKAHNJPKBM = JGKAHNJPKBM;
		kNPOPJAKFGF.KHLGDCHJJPB = KHLGDCHJJPB;
		kNPOPJAKFGF.BJGCPDNMHDH = this;
		return kNPOPJAKFGF;
	}

	public virtual bool CCGNMBEAEEK(GHPGNELIDBM HPOCABLAOAF, float GPHPFBFLIGD, List<GameShootableEntity> EAOABLKHNKG, List<GameShootableEntity> DDHEBHLDJKI, List<GameShootableEntity> MFNDDNIIJDK, List<GameShootableEntity> PLLLHNDJFLH)
	{
		if (DDHEBHLDJKI.Count < 7)
		{
			return false;
		}
		return base.IsViableForBotNow(HPOCABLAOAF, GPHPFBFLIGD, EAOABLKHNKG, DDHEBHLDJKI, MFNDDNIIJDK, PLLLHNDJFLH);
	}

	[DebuggerHidden]
	private IEnumerator MAPCDLJMFHC(Transform JGKAHNJPKBM, PlayerController KHLGDCHJJPB)
	{
		KNPOPJAKFGF kNPOPJAKFGF = new KNPOPJAKFGF();
		kNPOPJAKFGF.JGKAHNJPKBM = JGKAHNJPKBM;
		kNPOPJAKFGF.KHLGDCHJJPB = KHLGDCHJJPB;
		kNPOPJAKFGF.BJGCPDNMHDH = this;
		return kNPOPJAKFGF;
	}

	private IEnumerator BCMNFBKLDMA(Transform JGKAHNJPKBM, PlayerController KHLGDCHJJPB)
	{
		KNPOPJAKFGF kNPOPJAKFGF = new KNPOPJAKFGF();
		kNPOPJAKFGF.JGKAHNJPKBM = JGKAHNJPKBM;
		kNPOPJAKFGF.KHLGDCHJJPB = KHLGDCHJJPB;
		kNPOPJAKFGF.BJGCPDNMHDH = this;
		return kNPOPJAKFGF;
	}

	private IEnumerator GCEFACAPAEG(Transform JGKAHNJPKBM, PlayerController KHLGDCHJJPB)
	{
		KNPOPJAKFGF kNPOPJAKFGF = new KNPOPJAKFGF();
		kNPOPJAKFGF.JGKAHNJPKBM = JGKAHNJPKBM;
		kNPOPJAKFGF.KHLGDCHJJPB = KHLGDCHJJPB;
		kNPOPJAKFGF.BJGCPDNMHDH = this;
		return kNPOPJAKFGF;
	}

	public virtual void PNLOEOGDGHD(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		PlayerController playerController = PlayerController.MAJOCMGOFII(CIOPAKLHFIL);
		if (playerController.BBNPGJAALCJ() != null)
		{
			Transform jHNFPPDCBDK = playerController.CMNFFACHCEE().point.shield.ENOMOGMALOL.JHNFPPDCBDK;
			StartCoroutine(MAPCDLJMFHC(jHNFPPDCBDK, playerController));
		}
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	public virtual void APIMDACOKLE(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		PlayerController playerController = PlayerController.CCPHMCAIJNA(CIOPAKLHFIL);
		if (playerController.EMAMENNDFMB() != null)
		{
			Transform jHNFPPDCBDK = playerController.EMAMENNDFMB().point.shield.ENOMOGMALOL.JHNFPPDCBDK;
			StartCoroutine(BPOHLCKMAIE(jHNFPPDCBDK, playerController));
		}
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	public virtual bool OLLOGGELAHL(GHPGNELIDBM HPOCABLAOAF, float GPHPFBFLIGD, List<GameShootableEntity> EAOABLKHNKG, List<GameShootableEntity> DDHEBHLDJKI, List<GameShootableEntity> MFNDDNIIJDK, List<GameShootableEntity> PLLLHNDJFLH)
	{
		if (DDHEBHLDJKI.Count < 8)
		{
			return false;
		}
		return base.IsViableForBotNow(HPOCABLAOAF, GPHPFBFLIGD, EAOABLKHNKG, DDHEBHLDJKI, MFNDDNIIJDK, PLLLHNDJFLH);
	}

	public virtual void KELMJCLFCJG(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		PlayerController playerController = PlayerController.MAJOCMGOFII(CIOPAKLHFIL);
		if (playerController.currentPlayerPoint != null)
		{
			Transform jHNFPPDCBDK = playerController.EMAMENNDFMB().point.CGKKGILAAPG().ENOMOGMALOL.JHNFPPDCBDK;
			StartCoroutine(PEMABNICHML(jHNFPPDCBDK, playerController));
		}
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	public override bool IsViableForBotNow(GHPGNELIDBM HPOCABLAOAF, float GPHPFBFLIGD, List<GameShootableEntity> EAOABLKHNKG, List<GameShootableEntity> DDHEBHLDJKI, List<GameShootableEntity> MFNDDNIIJDK, List<GameShootableEntity> PLLLHNDJFLH)
	{
		if (DDHEBHLDJKI.Count < 3)
		{
			return false;
		}
		return base.IsViableForBotNow(HPOCABLAOAF, GPHPFBFLIGD, EAOABLKHNKG, DDHEBHLDJKI, MFNDDNIIJDK, PLLLHNDJFLH);
	}

	public virtual bool HAJOOIDGAEJ(GHPGNELIDBM HPOCABLAOAF, float GPHPFBFLIGD, List<GameShootableEntity> EAOABLKHNKG, List<GameShootableEntity> DDHEBHLDJKI, List<GameShootableEntity> MFNDDNIIJDK, List<GameShootableEntity> PLLLHNDJFLH)
	{
		if (DDHEBHLDJKI.Count < 3)
		{
			return false;
		}
		return base.IsViableForBotNow(HPOCABLAOAF, GPHPFBFLIGD, EAOABLKHNKG, DDHEBHLDJKI, MFNDDNIIJDK, PLLLHNDJFLH);
	}

	private IEnumerator MBLHFBLADBA(Transform JGKAHNJPKBM, PlayerController KHLGDCHJJPB)
	{
		KNPOPJAKFGF kNPOPJAKFGF = new KNPOPJAKFGF();
		kNPOPJAKFGF.JGKAHNJPKBM = JGKAHNJPKBM;
		kNPOPJAKFGF.KHLGDCHJJPB = KHLGDCHJJPB;
		kNPOPJAKFGF.BJGCPDNMHDH = this;
		return kNPOPJAKFGF;
	}

	public virtual void ACIOLBGILBP(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		PlayerController playerController = PlayerController.MAJOCMGOFII(CIOPAKLHFIL);
		if (playerController.currentPlayerPoint != null)
		{
			Transform jHNFPPDCBDK = playerController.BBNPGJAALCJ().point.LMHDAIBCLDP().ENOMOGMALOL.JHNFPPDCBDK;
			StartCoroutine(ONFMCMKPPFB(jHNFPPDCBDK, playerController));
		}
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	private IEnumerator FDHNDBKKBHJ(Transform JGKAHNJPKBM, PlayerController KHLGDCHJJPB)
	{
		KNPOPJAKFGF kNPOPJAKFGF = new KNPOPJAKFGF();
		kNPOPJAKFGF.JGKAHNJPKBM = JGKAHNJPKBM;
		kNPOPJAKFGF.KHLGDCHJJPB = KHLGDCHJJPB;
		kNPOPJAKFGF.BJGCPDNMHDH = this;
		return kNPOPJAKFGF;
	}

	private IEnumerator FGPBOKALPCF(Transform JGKAHNJPKBM, PlayerController KHLGDCHJJPB)
	{
		KNPOPJAKFGF kNPOPJAKFGF = new KNPOPJAKFGF();
		kNPOPJAKFGF.JGKAHNJPKBM = JGKAHNJPKBM;
		kNPOPJAKFGF.KHLGDCHJJPB = KHLGDCHJJPB;
		kNPOPJAKFGF.BJGCPDNMHDH = this;
		return kNPOPJAKFGF;
	}

	public virtual void OBNPMMDGFME(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		PlayerController playerController = PlayerController.MAJOCMGOFII(CIOPAKLHFIL);
		if (playerController.BBNPGJAALCJ() != null)
		{
			Transform jHNFPPDCBDK = playerController.currentPlayerPoint.point.shield.ENOMOGMALOL.JHNFPPDCBDK;
			StartCoroutine(HGJONCFDOAG(jHNFPPDCBDK, playerController));
		}
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	public virtual bool NAHJCMJEDBM(GHPGNELIDBM HPOCABLAOAF, float GPHPFBFLIGD, List<GameShootableEntity> EAOABLKHNKG, List<GameShootableEntity> DDHEBHLDJKI, List<GameShootableEntity> MFNDDNIIJDK, List<GameShootableEntity> PLLLHNDJFLH)
	{
		if (DDHEBHLDJKI.Count < 4)
		{
			return true;
		}
		return base.IsViableForBotNow(HPOCABLAOAF, GPHPFBFLIGD, EAOABLKHNKG, DDHEBHLDJKI, MFNDDNIIJDK, PLLLHNDJFLH);
	}

	public virtual bool OPKJFNONDPG(GHPGNELIDBM HPOCABLAOAF, float GPHPFBFLIGD, List<GameShootableEntity> EAOABLKHNKG, List<GameShootableEntity> DDHEBHLDJKI, List<GameShootableEntity> MFNDDNIIJDK, List<GameShootableEntity> PLLLHNDJFLH)
	{
		if (DDHEBHLDJKI.Count < 2)
		{
			return true;
		}
		return base.IsViableForBotNow(HPOCABLAOAF, GPHPFBFLIGD, EAOABLKHNKG, DDHEBHLDJKI, MFNDDNIIJDK, PLLLHNDJFLH);
	}

	private IEnumerator DGLNOOFOFJK(Transform JGKAHNJPKBM, PlayerController KHLGDCHJJPB)
	{
		KNPOPJAKFGF kNPOPJAKFGF = new KNPOPJAKFGF();
		kNPOPJAKFGF.JGKAHNJPKBM = JGKAHNJPKBM;
		kNPOPJAKFGF.KHLGDCHJJPB = KHLGDCHJJPB;
		kNPOPJAKFGF.BJGCPDNMHDH = this;
		return kNPOPJAKFGF;
	}

	public virtual bool MDOHFKCFLDN(GHPGNELIDBM HPOCABLAOAF, float GPHPFBFLIGD, List<GameShootableEntity> EAOABLKHNKG, List<GameShootableEntity> DDHEBHLDJKI, List<GameShootableEntity> MFNDDNIIJDK, List<GameShootableEntity> PLLLHNDJFLH)
	{
		if (DDHEBHLDJKI.Count < 2)
		{
			return false;
		}
		return base.IsViableForBotNow(HPOCABLAOAF, GPHPFBFLIGD, EAOABLKHNKG, DDHEBHLDJKI, MFNDDNIIJDK, PLLLHNDJFLH);
	}

	public virtual bool MOINKNKPCMN(GHPGNELIDBM HPOCABLAOAF, float GPHPFBFLIGD, List<GameShootableEntity> EAOABLKHNKG, List<GameShootableEntity> DDHEBHLDJKI, List<GameShootableEntity> MFNDDNIIJDK, List<GameShootableEntity> PLLLHNDJFLH)
	{
		if (DDHEBHLDJKI.Count < 2)
		{
			return false;
		}
		return base.IsViableForBotNow(HPOCABLAOAF, GPHPFBFLIGD, EAOABLKHNKG, DDHEBHLDJKI, MFNDDNIIJDK, PLLLHNDJFLH);
	}

	public virtual bool HBIDPIBONKB(GHPGNELIDBM HPOCABLAOAF, float GPHPFBFLIGD, List<GameShootableEntity> EAOABLKHNKG, List<GameShootableEntity> DDHEBHLDJKI, List<GameShootableEntity> MFNDDNIIJDK, List<GameShootableEntity> PLLLHNDJFLH)
	{
		if (DDHEBHLDJKI.Count < 0)
		{
			return false;
		}
		return base.IsViableForBotNow(HPOCABLAOAF, GPHPFBFLIGD, EAOABLKHNKG, DDHEBHLDJKI, MFNDDNIIJDK, PLLLHNDJFLH);
	}

	private IEnumerator NGFMEBCELFC(Transform JGKAHNJPKBM, PlayerController KHLGDCHJJPB)
	{
		KNPOPJAKFGF kNPOPJAKFGF = new KNPOPJAKFGF();
		kNPOPJAKFGF.JGKAHNJPKBM = JGKAHNJPKBM;
		kNPOPJAKFGF.KHLGDCHJJPB = KHLGDCHJJPB;
		kNPOPJAKFGF.BJGCPDNMHDH = this;
		return kNPOPJAKFGF;
	}

	public virtual bool MOEJABKCDGK(GHPGNELIDBM HPOCABLAOAF, float GPHPFBFLIGD, List<GameShootableEntity> EAOABLKHNKG, List<GameShootableEntity> DDHEBHLDJKI, List<GameShootableEntity> MFNDDNIIJDK, List<GameShootableEntity> PLLLHNDJFLH)
	{
		if (DDHEBHLDJKI.Count < 4)
		{
			return true;
		}
		return base.IsViableForBotNow(HPOCABLAOAF, GPHPFBFLIGD, EAOABLKHNKG, DDHEBHLDJKI, MFNDDNIIJDK, PLLLHNDJFLH);
	}

	public virtual void DKOMGEKACEK(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		PlayerController playerController = PlayerController.MAJOCMGOFII(CIOPAKLHFIL);
		if (playerController.EMAMENNDFMB() != null)
		{
			Transform jHNFPPDCBDK = playerController.EMAMENNDFMB().point.LMHDAIBCLDP().ENOMOGMALOL.JHNFPPDCBDK;
			StartCoroutine(IEDEFNOBNOF(jHNFPPDCBDK, playerController));
		}
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	public virtual bool IMLMNKKFGBJ(GHPGNELIDBM HPOCABLAOAF, float GPHPFBFLIGD, List<GameShootableEntity> EAOABLKHNKG, List<GameShootableEntity> DDHEBHLDJKI, List<GameShootableEntity> MFNDDNIIJDK, List<GameShootableEntity> PLLLHNDJFLH)
	{
		if (DDHEBHLDJKI.Count < 8)
		{
			return true;
		}
		return base.IsViableForBotNow(HPOCABLAOAF, GPHPFBFLIGD, EAOABLKHNKG, DDHEBHLDJKI, MFNDDNIIJDK, PLLLHNDJFLH);
	}

	public virtual bool OFBIPJIEDPP(GHPGNELIDBM HPOCABLAOAF, float GPHPFBFLIGD, List<GameShootableEntity> EAOABLKHNKG, List<GameShootableEntity> DDHEBHLDJKI, List<GameShootableEntity> MFNDDNIIJDK, List<GameShootableEntity> PLLLHNDJFLH)
	{
		if (DDHEBHLDJKI.Count < 2)
		{
			return true;
		}
		return base.IsViableForBotNow(HPOCABLAOAF, GPHPFBFLIGD, EAOABLKHNKG, DDHEBHLDJKI, MFNDDNIIJDK, PLLLHNDJFLH);
	}

	public virtual bool FOHDOIFCPNP(GHPGNELIDBM HPOCABLAOAF, float GPHPFBFLIGD, List<GameShootableEntity> EAOABLKHNKG, List<GameShootableEntity> DDHEBHLDJKI, List<GameShootableEntity> MFNDDNIIJDK, List<GameShootableEntity> PLLLHNDJFLH)
	{
		if (DDHEBHLDJKI.Count < 7)
		{
			return true;
		}
		return base.IsViableForBotNow(HPOCABLAOAF, GPHPFBFLIGD, EAOABLKHNKG, DDHEBHLDJKI, MFNDDNIIJDK, PLLLHNDJFLH);
	}

	public virtual bool GAPAJHFLCCN(GHPGNELIDBM HPOCABLAOAF, float GPHPFBFLIGD, List<GameShootableEntity> EAOABLKHNKG, List<GameShootableEntity> DDHEBHLDJKI, List<GameShootableEntity> MFNDDNIIJDK, List<GameShootableEntity> PLLLHNDJFLH)
	{
		if (DDHEBHLDJKI.Count < 2)
		{
			return false;
		}
		return base.IsViableForBotNow(HPOCABLAOAF, GPHPFBFLIGD, EAOABLKHNKG, DDHEBHLDJKI, MFNDDNIIJDK, PLLLHNDJFLH);
	}

	private IEnumerator FKMLFDGAJMF(Transform JGKAHNJPKBM, PlayerController KHLGDCHJJPB)
	{
		KNPOPJAKFGF kNPOPJAKFGF = new KNPOPJAKFGF();
		kNPOPJAKFGF.JGKAHNJPKBM = JGKAHNJPKBM;
		kNPOPJAKFGF.KHLGDCHJJPB = KHLGDCHJJPB;
		kNPOPJAKFGF.BJGCPDNMHDH = this;
		return kNPOPJAKFGF;
	}

	public override void UseCard(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		PlayerController playerOld = PlayerController.GetPlayerOld(CIOPAKLHFIL);
		if (playerOld.currentPlayerPoint != null)
		{
			Transform jHNFPPDCBDK = playerOld.currentPlayerPoint.point.shield.ENOMOGMALOL.JHNFPPDCBDK;
			StartCoroutine(MAPCDLJMFHC(jHNFPPDCBDK, playerOld));
		}
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	public virtual void INPLMEOCGKE(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		PlayerController playerOld = PlayerController.GetPlayerOld(CIOPAKLHFIL);
		if (playerOld.currentPlayerPoint != null)
		{
			Transform jHNFPPDCBDK = playerOld.currentPlayerPoint.point.KJCHIHLJMMF().ENOMOGMALOL.JHNFPPDCBDK;
			StartCoroutine(DILBJCMDFLM(jHNFPPDCBDK, playerOld));
		}
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	private IEnumerator AJIGCKHEKJG(Transform JGKAHNJPKBM, PlayerController KHLGDCHJJPB)
	{
		KNPOPJAKFGF kNPOPJAKFGF = new KNPOPJAKFGF();
		kNPOPJAKFGF.JGKAHNJPKBM = JGKAHNJPKBM;
		kNPOPJAKFGF.KHLGDCHJJPB = KHLGDCHJJPB;
		kNPOPJAKFGF.BJGCPDNMHDH = this;
		return kNPOPJAKFGF;
	}

	private IEnumerator MJGJLINGGDD(Transform JGKAHNJPKBM, PlayerController KHLGDCHJJPB)
	{
		KNPOPJAKFGF kNPOPJAKFGF = new KNPOPJAKFGF();
		kNPOPJAKFGF.JGKAHNJPKBM = JGKAHNJPKBM;
		kNPOPJAKFGF.KHLGDCHJJPB = KHLGDCHJJPB;
		kNPOPJAKFGF.BJGCPDNMHDH = this;
		return kNPOPJAKFGF;
	}

	private IEnumerator ONFMCMKPPFB(Transform JGKAHNJPKBM, PlayerController KHLGDCHJJPB)
	{
		KNPOPJAKFGF kNPOPJAKFGF = new KNPOPJAKFGF();
		kNPOPJAKFGF.JGKAHNJPKBM = JGKAHNJPKBM;
		kNPOPJAKFGF.KHLGDCHJJPB = KHLGDCHJJPB;
		kNPOPJAKFGF.BJGCPDNMHDH = this;
		return kNPOPJAKFGF;
	}

	public virtual bool CAMHHFDPLOF(GHPGNELIDBM HPOCABLAOAF, float GPHPFBFLIGD, List<GameShootableEntity> EAOABLKHNKG, List<GameShootableEntity> DDHEBHLDJKI, List<GameShootableEntity> MFNDDNIIJDK, List<GameShootableEntity> PLLLHNDJFLH)
	{
		if (DDHEBHLDJKI.Count < 6)
		{
			return true;
		}
		return base.IsViableForBotNow(HPOCABLAOAF, GPHPFBFLIGD, EAOABLKHNKG, DDHEBHLDJKI, MFNDDNIIJDK, PLLLHNDJFLH);
	}

	private IEnumerator DILBJCMDFLM(Transform JGKAHNJPKBM, PlayerController KHLGDCHJJPB)
	{
		KNPOPJAKFGF kNPOPJAKFGF = new KNPOPJAKFGF();
		kNPOPJAKFGF.JGKAHNJPKBM = JGKAHNJPKBM;
		kNPOPJAKFGF.KHLGDCHJJPB = KHLGDCHJJPB;
		kNPOPJAKFGF.BJGCPDNMHDH = this;
		return kNPOPJAKFGF;
	}

	public virtual void OFNENBNMMOO(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		PlayerController playerController = PlayerController.HEAGPACBLJA(CIOPAKLHFIL);
		if (playerController.EMAMENNDFMB() != null)
		{
			Transform jHNFPPDCBDK = playerController.CMNFFACHCEE().point.PKBPGCGNCAD().ENOMOGMALOL.JHNFPPDCBDK;
			StartCoroutine(DBAAMJGILJL(jHNFPPDCBDK, playerController));
		}
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	public virtual void DPELJDNCGHG(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		PlayerController playerController = PlayerController.MAJOCMGOFII(CIOPAKLHFIL);
		if (playerController.BBNPGJAALCJ() != null)
		{
			Transform jHNFPPDCBDK = playerController.CMNFFACHCEE().point.KJCHIHLJMMF().ENOMOGMALOL.JHNFPPDCBDK;
			StartCoroutine(BCMNFBKLDMA(jHNFPPDCBDK, playerController));
		}
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	public virtual bool NODGDHANJMH(GHPGNELIDBM HPOCABLAOAF, float GPHPFBFLIGD, List<GameShootableEntity> EAOABLKHNKG, List<GameShootableEntity> DDHEBHLDJKI, List<GameShootableEntity> MFNDDNIIJDK, List<GameShootableEntity> PLLLHNDJFLH)
	{
		if (DDHEBHLDJKI.Count < 5)
		{
			return true;
		}
		return base.IsViableForBotNow(HPOCABLAOAF, GPHPFBFLIGD, EAOABLKHNKG, DDHEBHLDJKI, MFNDDNIIJDK, PLLLHNDJFLH);
	}

	private IEnumerator ALPFPBBGAPH(Transform JGKAHNJPKBM, PlayerController KHLGDCHJJPB)
	{
		KNPOPJAKFGF kNPOPJAKFGF = new KNPOPJAKFGF();
		kNPOPJAKFGF.JGKAHNJPKBM = JGKAHNJPKBM;
		kNPOPJAKFGF.KHLGDCHJJPB = KHLGDCHJJPB;
		kNPOPJAKFGF.BJGCPDNMHDH = this;
		return kNPOPJAKFGF;
	}

	public virtual bool CEBFCMPDFMB(GHPGNELIDBM HPOCABLAOAF, float GPHPFBFLIGD, List<GameShootableEntity> EAOABLKHNKG, List<GameShootableEntity> DDHEBHLDJKI, List<GameShootableEntity> MFNDDNIIJDK, List<GameShootableEntity> PLLLHNDJFLH)
	{
		if (DDHEBHLDJKI.Count < 8)
		{
			return false;
		}
		return base.IsViableForBotNow(HPOCABLAOAF, GPHPFBFLIGD, EAOABLKHNKG, DDHEBHLDJKI, MFNDDNIIJDK, PLLLHNDJFLH);
	}

	private IEnumerator PEMABNICHML(Transform JGKAHNJPKBM, PlayerController KHLGDCHJJPB)
	{
		KNPOPJAKFGF kNPOPJAKFGF = new KNPOPJAKFGF();
		kNPOPJAKFGF.JGKAHNJPKBM = JGKAHNJPKBM;
		kNPOPJAKFGF.KHLGDCHJJPB = KHLGDCHJJPB;
		kNPOPJAKFGF.BJGCPDNMHDH = this;
		return kNPOPJAKFGF;
	}

	public virtual bool GEAPEEMABAL(GHPGNELIDBM HPOCABLAOAF, float GPHPFBFLIGD, List<GameShootableEntity> EAOABLKHNKG, List<GameShootableEntity> DDHEBHLDJKI, List<GameShootableEntity> MFNDDNIIJDK, List<GameShootableEntity> PLLLHNDJFLH)
	{
		if (DDHEBHLDJKI.Count < 8)
		{
			return false;
		}
		return base.IsViableForBotNow(HPOCABLAOAF, GPHPFBFLIGD, EAOABLKHNKG, DDHEBHLDJKI, MFNDDNIIJDK, PLLLHNDJFLH);
	}

	private IEnumerator IEDEFNOBNOF(Transform JGKAHNJPKBM, PlayerController KHLGDCHJJPB)
	{
		KNPOPJAKFGF kNPOPJAKFGF = new KNPOPJAKFGF();
		kNPOPJAKFGF.JGKAHNJPKBM = JGKAHNJPKBM;
		kNPOPJAKFGF.KHLGDCHJJPB = KHLGDCHJJPB;
		kNPOPJAKFGF.BJGCPDNMHDH = this;
		return kNPOPJAKFGF;
	}

	private IEnumerator HGJONCFDOAG(Transform JGKAHNJPKBM, PlayerController KHLGDCHJJPB)
	{
		KNPOPJAKFGF kNPOPJAKFGF = new KNPOPJAKFGF();
		kNPOPJAKFGF.JGKAHNJPKBM = JGKAHNJPKBM;
		kNPOPJAKFGF.KHLGDCHJJPB = KHLGDCHJJPB;
		kNPOPJAKFGF.BJGCPDNMHDH = this;
		return kNPOPJAKFGF;
	}

	public virtual bool ACOBGNBBAJE(GHPGNELIDBM HPOCABLAOAF, float GPHPFBFLIGD, List<GameShootableEntity> EAOABLKHNKG, List<GameShootableEntity> DDHEBHLDJKI, List<GameShootableEntity> MFNDDNIIJDK, List<GameShootableEntity> PLLLHNDJFLH)
	{
		if (DDHEBHLDJKI.Count < 4)
		{
			return true;
		}
		return base.IsViableForBotNow(HPOCABLAOAF, GPHPFBFLIGD, EAOABLKHNKG, DDHEBHLDJKI, MFNDDNIIJDK, PLLLHNDJFLH);
	}

	public virtual void CCODFGNHBOJ(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		PlayerController playerController = PlayerController.CCPHMCAIJNA(CIOPAKLHFIL);
		if (playerController.currentPlayerPoint != null)
		{
			Transform jHNFPPDCBDK = playerController.BBNPGJAALCJ().point.shield.ENOMOGMALOL.JHNFPPDCBDK;
			StartCoroutine(BPOHLCKMAIE(jHNFPPDCBDK, playerController));
		}
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	public virtual void EKFKAICCHLI(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		PlayerController playerController = PlayerController.HEAGPACBLJA(CIOPAKLHFIL);
		if (playerController.EMAMENNDFMB() != null)
		{
			Transform jHNFPPDCBDK = playerController.BBNPGJAALCJ().point.IGEDGCNJCAP().ENOMOGMALOL.JHNFPPDCBDK;
			StartCoroutine(NGFMEBCELFC(jHNFPPDCBDK, playerController));
		}
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	public virtual void JCCNJNMBKBO(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		PlayerController playerController = PlayerController.MAJOCMGOFII(CIOPAKLHFIL);
		if (playerController.currentPlayerPoint != null)
		{
			Transform jHNFPPDCBDK = playerController.EMAMENNDFMB().point.shield.ENOMOGMALOL.JHNFPPDCBDK;
			StartCoroutine(CHFHAIDNBGH(jHNFPPDCBDK, playerController));
		}
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	public virtual bool OPMCMADKMJE(GHPGNELIDBM HPOCABLAOAF, float GPHPFBFLIGD, List<GameShootableEntity> EAOABLKHNKG, List<GameShootableEntity> DDHEBHLDJKI, List<GameShootableEntity> MFNDDNIIJDK, List<GameShootableEntity> PLLLHNDJFLH)
	{
		if (DDHEBHLDJKI.Count < 7)
		{
			return true;
		}
		return base.IsViableForBotNow(HPOCABLAOAF, GPHPFBFLIGD, EAOABLKHNKG, DDHEBHLDJKI, MFNDDNIIJDK, PLLLHNDJFLH);
	}

	public virtual bool BDLAEEMLDDP(GHPGNELIDBM HPOCABLAOAF, float GPHPFBFLIGD, List<GameShootableEntity> EAOABLKHNKG, List<GameShootableEntity> DDHEBHLDJKI, List<GameShootableEntity> MFNDDNIIJDK, List<GameShootableEntity> PLLLHNDJFLH)
	{
		if (DDHEBHLDJKI.Count < 5)
		{
			return false;
		}
		return base.IsViableForBotNow(HPOCABLAOAF, GPHPFBFLIGD, EAOABLKHNKG, DDHEBHLDJKI, MFNDDNIIJDK, PLLLHNDJFLH);
	}

	public virtual bool NIFCNKPHIMP(GHPGNELIDBM HPOCABLAOAF, float GPHPFBFLIGD, List<GameShootableEntity> EAOABLKHNKG, List<GameShootableEntity> DDHEBHLDJKI, List<GameShootableEntity> MFNDDNIIJDK, List<GameShootableEntity> PLLLHNDJFLH)
	{
		if (DDHEBHLDJKI.Count < 6)
		{
			return false;
		}
		return base.IsViableForBotNow(HPOCABLAOAF, GPHPFBFLIGD, EAOABLKHNKG, DDHEBHLDJKI, MFNDDNIIJDK, PLLLHNDJFLH);
	}

	public virtual void BDLHMMDHGMP(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		PlayerController playerOld = PlayerController.GetPlayerOld(CIOPAKLHFIL);
		if (playerOld.CMNFFACHCEE() != null)
		{
			Transform jHNFPPDCBDK = playerOld.BBNPGJAALCJ().point.IGEDGCNJCAP().ENOMOGMALOL.JHNFPPDCBDK;
			StartCoroutine(DGLNOOFOFJK(jHNFPPDCBDK, playerOld));
		}
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	public virtual void PPIOIELILIJ(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		PlayerController playerController = PlayerController.MAJOCMGOFII(CIOPAKLHFIL);
		if (playerController.currentPlayerPoint != null)
		{
			Transform jHNFPPDCBDK = playerController.currentPlayerPoint.point.LMHDAIBCLDP().ENOMOGMALOL.JHNFPPDCBDK;
			StartCoroutine(GCEFACAPAEG(jHNFPPDCBDK, playerController));
		}
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	private IEnumerator INEGLCEAFAI(Transform JGKAHNJPKBM, PlayerController KHLGDCHJJPB)
	{
		KNPOPJAKFGF kNPOPJAKFGF = new KNPOPJAKFGF();
		kNPOPJAKFGF.JGKAHNJPKBM = JGKAHNJPKBM;
		kNPOPJAKFGF.KHLGDCHJJPB = KHLGDCHJJPB;
		kNPOPJAKFGF.BJGCPDNMHDH = this;
		return kNPOPJAKFGF;
	}

	public virtual void BKMGMNGKBMB(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		PlayerController playerOld = PlayerController.GetPlayerOld(CIOPAKLHFIL);
		if (playerOld.EMAMENNDFMB() != null)
		{
			Transform jHNFPPDCBDK = playerOld.currentPlayerPoint.point.shield.ENOMOGMALOL.JHNFPPDCBDK;
			StartCoroutine(AJIGCKHEKJG(jHNFPPDCBDK, playerOld));
		}
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	public virtual void JGNCOJLCGFH(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		PlayerController playerController = PlayerController.HEAGPACBLJA(CIOPAKLHFIL);
		if (playerController.EMAMENNDFMB() != null)
		{
			Transform jHNFPPDCBDK = playerController.EMAMENNDFMB().point.LHHMNLJKOAO().ENOMOGMALOL.JHNFPPDCBDK;
			StartCoroutine(IEDEFNOBNOF(jHNFPPDCBDK, playerController));
		}
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	public virtual void DBAPEPJHJMH(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		PlayerController playerController = PlayerController.CCPHMCAIJNA(CIOPAKLHFIL);
		if (playerController.CMNFFACHCEE() != null)
		{
			Transform jHNFPPDCBDK = playerController.EMAMENNDFMB().point.KJCHIHLJMMF().ENOMOGMALOL.JHNFPPDCBDK;
			StartCoroutine(NGFMEBCELFC(jHNFPPDCBDK, playerController));
		}
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	public virtual void DGAOKHJIADO(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		PlayerController playerController = PlayerController.MAJOCMGOFII(CIOPAKLHFIL);
		if (playerController.CMNFFACHCEE() != null)
		{
			Transform jHNFPPDCBDK = playerController.CMNFFACHCEE().point.JPHAJDIIAAI().ENOMOGMALOL.JHNFPPDCBDK;
			StartCoroutine(FKMLFDGAJMF(jHNFPPDCBDK, playerController));
		}
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	public virtual bool BJODPJNOMLK(GHPGNELIDBM HPOCABLAOAF, float GPHPFBFLIGD, List<GameShootableEntity> EAOABLKHNKG, List<GameShootableEntity> DDHEBHLDJKI, List<GameShootableEntity> MFNDDNIIJDK, List<GameShootableEntity> PLLLHNDJFLH)
	{
		if (DDHEBHLDJKI.Count < 7)
		{
			return true;
		}
		return base.IsViableForBotNow(HPOCABLAOAF, GPHPFBFLIGD, EAOABLKHNKG, DDHEBHLDJKI, MFNDDNIIJDK, PLLLHNDJFLH);
	}

	public virtual void GGBPLMCEGML(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		PlayerController playerController = PlayerController.HEAGPACBLJA(CIOPAKLHFIL);
		if (playerController.currentPlayerPoint != null)
		{
			Transform jHNFPPDCBDK = playerController.EMAMENNDFMB().point.JPHAJDIIAAI().ENOMOGMALOL.JHNFPPDCBDK;
			StartCoroutine(FKMLFDGAJMF(jHNFPPDCBDK, playerController));
		}
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	private IEnumerator KDMPAJPAJOO(Transform JGKAHNJPKBM, PlayerController KHLGDCHJJPB)
	{
		KNPOPJAKFGF kNPOPJAKFGF = new KNPOPJAKFGF();
		kNPOPJAKFGF.JGKAHNJPKBM = JGKAHNJPKBM;
		kNPOPJAKFGF.KHLGDCHJJPB = KHLGDCHJJPB;
		kNPOPJAKFGF.BJGCPDNMHDH = this;
		return kNPOPJAKFGF;
	}

	public virtual bool KCMGOHFNLOL(GHPGNELIDBM HPOCABLAOAF, float GPHPFBFLIGD, List<GameShootableEntity> EAOABLKHNKG, List<GameShootableEntity> DDHEBHLDJKI, List<GameShootableEntity> MFNDDNIIJDK, List<GameShootableEntity> PLLLHNDJFLH)
	{
		if (DDHEBHLDJKI.Count < 8)
		{
			return false;
		}
		return base.IsViableForBotNow(HPOCABLAOAF, GPHPFBFLIGD, EAOABLKHNKG, DDHEBHLDJKI, MFNDDNIIJDK, PLLLHNDJFLH);
	}

	public virtual bool IHFBJPEDJOE(GHPGNELIDBM HPOCABLAOAF, float GPHPFBFLIGD, List<GameShootableEntity> EAOABLKHNKG, List<GameShootableEntity> DDHEBHLDJKI, List<GameShootableEntity> MFNDDNIIJDK, List<GameShootableEntity> PLLLHNDJFLH)
	{
		if (DDHEBHLDJKI.Count < 0)
		{
			return false;
		}
		return base.IsViableForBotNow(HPOCABLAOAF, GPHPFBFLIGD, EAOABLKHNKG, DDHEBHLDJKI, MFNDDNIIJDK, PLLLHNDJFLH);
	}

	public virtual void ILNLEEBPHIH(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		PlayerController playerController = PlayerController.CCPHMCAIJNA(CIOPAKLHFIL);
		if (playerController.EMAMENNDFMB() != null)
		{
			Transform jHNFPPDCBDK = playerController.CMNFFACHCEE().point.KJCHIHLJMMF().ENOMOGMALOL.JHNFPPDCBDK;
			StartCoroutine(MBLHFBLADBA(jHNFPPDCBDK, playerController));
		}
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
	}

	private IEnumerator DBAAMJGILJL(Transform JGKAHNJPKBM, PlayerController KHLGDCHJJPB)
	{
		KNPOPJAKFGF kNPOPJAKFGF = new KNPOPJAKFGF();
		kNPOPJAKFGF.JGKAHNJPKBM = JGKAHNJPKBM;
		kNPOPJAKFGF.KHLGDCHJJPB = KHLGDCHJJPB;
		kNPOPJAKFGF.BJGCPDNMHDH = this;
		return kNPOPJAKFGF;
	}
}
