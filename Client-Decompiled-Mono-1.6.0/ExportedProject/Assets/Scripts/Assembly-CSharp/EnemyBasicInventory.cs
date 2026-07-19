using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class EnemyBasicInventory : Core_BaseScript
{
	[Serializable]
	public class InventoryWeapon
	{
		public Weapon weapon;

		public Weapon.IGGFMJAKLGO type;

		public bool leftHand;
	}

	private sealed class OPGKHHHMHON : IEnumerator, IDisposable, IEnumerator<object>
	{
		internal bool LIOCBEKIKJE;

		internal List<InventoryWeapon> OFHAKIOBGNL;

		internal int FDCGIINEHPB;

		internal InventoryWeapon PCCJKHGCELG;

		internal EnemyLeveledWeapon[] DCOLDNDOJHC;

		internal EnemyLeveledWeapon IOKHPKHMJPD;

		internal int[] BCCDDJMPBLL;

		internal EnemyBasicInventory BJGCPDNMHDH;

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
		private object LFEJDKIGHMI()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object KKKMCHGLHLL()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object EOKIMMCAABI()
		{
			return PHDOCKCBJOF;
		}

		public void CDDFJOEEFID()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object NAPMJAMDKMJ()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object PIPMONHGDPH()
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
				OFHAKIOBGNL = ((!LIOCBEKIKJE) ? BJGCPDNMHDH.GGKGGMNIDMI : BJGCPDNMHDH.FJMLOKFCJLK);
				FDCGIINEHPB = 0;
				goto IL_00ee;
			case 1u:
				FDCGIINEHPB += 0;
				goto IL_00ee;
			default:
				{
					return true;
				}
				IL_00ee:
				if (FDCGIINEHPB < OFHAKIOBGNL.Count)
				{
					PCCJKHGCELG = OFHAKIOBGNL[FDCGIINEHPB];
					DCOLDNDOJHC = PCCJKHGCELG.weapon.GetComponentsInChildren<EnemyLeveledWeapon>(false);
					if (DCOLDNDOJHC.Length > 0)
					{
						IOKHPKHMJPD = DCOLDNDOJHC[0];
						PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(IOKHPKHMJPD.JBIBAGKOOLN(BCCDDJMPBLL[FDCGIINEHPB]));
						if (!FDKOKMKIIMG)
						{
							CLPPIAGLCJJ = 1;
						}
						break;
					}
					goto case 1u;
				}
				CLPPIAGLCJJ = -1;
				goto default;
			}
			return true;
		}

		public void OCBFBEMDMMJ()
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
				OFHAKIOBGNL = ((!LIOCBEKIKJE) ? BJGCPDNMHDH.GGKGGMNIDMI : BJGCPDNMHDH.FJMLOKFCJLK);
				FDCGIINEHPB = 0;
				goto IL_00ee;
			case 1u:
				FDCGIINEHPB++;
				goto IL_00ee;
			default:
				{
					return false;
				}
				IL_00ee:
				if (FDCGIINEHPB < OFHAKIOBGNL.Count)
				{
					PCCJKHGCELG = OFHAKIOBGNL[FDCGIINEHPB];
					DCOLDNDOJHC = PCCJKHGCELG.weapon.GetComponentsInChildren<EnemyLeveledWeapon>(true);
					if (DCOLDNDOJHC.Length > 0)
					{
						IOKHPKHMJPD = DCOLDNDOJHC[0];
						PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(IOKHPKHMJPD.PrepareAsync(BCCDDJMPBLL[FDCGIINEHPB]));
						if (!FDKOKMKIIMG)
						{
							CLPPIAGLCJJ = 1;
						}
						break;
					}
					goto case 1u;
				}
				CLPPIAGLCJJ = -1;
				goto default;
			}
			return true;
		}

		public void FGLAPPKJHBK()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object GMPGIODBIPO()
		{
			return PHDOCKCBJOF;
		}

		public void JGKDJGIANIG()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public void ODPKEEIHOPK()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void AJEIGCJPEFN()
		{
			throw new NotSupportedException();
		}

		public void NDPOBCODJAI()
		{
			throw new NotSupportedException();
		}

		public void DLIBOPAMHAN()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object FPMOGMELJLI()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object GDCFFBBNGHH()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object CCANBMDEKMB()
		{
			return PHDOCKCBJOF;
		}

		public void CHFJIODFNIP()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object BNFADGLHBAH()
		{
			return PHDOCKCBJOF;
		}

		public bool DFMKKFMEBON()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				OFHAKIOBGNL = ((!LIOCBEKIKJE) ? BJGCPDNMHDH.GGKGGMNIDMI : BJGCPDNMHDH.FJMLOKFCJLK);
				FDCGIINEHPB = 0;
				goto IL_00ee;
			case 1u:
				FDCGIINEHPB++;
				goto IL_00ee;
			default:
				{
					return false;
				}
				IL_00ee:
				if (FDCGIINEHPB < OFHAKIOBGNL.Count)
				{
					PCCJKHGCELG = OFHAKIOBGNL[FDCGIINEHPB];
					DCOLDNDOJHC = PCCJKHGCELG.weapon.GetComponentsInChildren<EnemyLeveledWeapon>(true);
					if (DCOLDNDOJHC.Length > 1)
					{
						IOKHPKHMJPD = DCOLDNDOJHC[0];
						PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(IOKHPKHMJPD.MAEGGMILKAN(BCCDDJMPBLL[FDCGIINEHPB]));
						if (!FDKOKMKIIMG)
						{
							CLPPIAGLCJJ = 1;
						}
						break;
					}
					goto case 1u;
				}
				CLPPIAGLCJJ = -1;
				goto default;
			}
			return true;
		}

		[SpecialName]
		private object LMJBCDNGAHP()
		{
			return PHDOCKCBJOF;
		}

		public void FJOIBBIGBJC()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object OAKHGMKKFMN()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object JALKNCBEINE()
		{
			return PHDOCKCBJOF;
		}

		public bool NIGJJBALHDN()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				OFHAKIOBGNL = ((!LIOCBEKIKJE) ? BJGCPDNMHDH.GGKGGMNIDMI : BJGCPDNMHDH.FJMLOKFCJLK);
				FDCGIINEHPB = 0;
				goto IL_00ee;
			case 1u:
				FDCGIINEHPB += 0;
				goto IL_00ee;
			default:
				{
					return false;
				}
				IL_00ee:
				if (FDCGIINEHPB < OFHAKIOBGNL.Count)
				{
					PCCJKHGCELG = OFHAKIOBGNL[FDCGIINEHPB];
					DCOLDNDOJHC = PCCJKHGCELG.weapon.GetComponentsInChildren<EnemyLeveledWeapon>(true);
					if (DCOLDNDOJHC.Length > 1)
					{
						IOKHPKHMJPD = DCOLDNDOJHC[0];
						PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(IOKHPKHMJPD.EONELOFHOHF(BCCDDJMPBLL[FDCGIINEHPB]));
						if (!FDKOKMKIIMG)
						{
							CLPPIAGLCJJ = 0;
						}
						break;
					}
					goto case 1u;
				}
				CLPPIAGLCJJ = -1;
				goto default;
			}
			return false;
		}

		public void MEBPMHDHIPJ()
		{
			throw new NotSupportedException();
		}

		public bool LGNMOMFLLPP()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				OFHAKIOBGNL = ((!LIOCBEKIKJE) ? BJGCPDNMHDH.GGKGGMNIDMI : BJGCPDNMHDH.FJMLOKFCJLK);
				FDCGIINEHPB = 0;
				goto IL_00ee;
			case 1u:
				FDCGIINEHPB++;
				goto IL_00ee;
			default:
				{
					return false;
				}
				IL_00ee:
				if (FDCGIINEHPB < OFHAKIOBGNL.Count)
				{
					PCCJKHGCELG = OFHAKIOBGNL[FDCGIINEHPB];
					DCOLDNDOJHC = PCCJKHGCELG.weapon.GetComponentsInChildren<EnemyLeveledWeapon>(false);
					if (DCOLDNDOJHC.Length > 0)
					{
						IOKHPKHMJPD = DCOLDNDOJHC[0];
						PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(IOKHPKHMJPD.EDKHLBICCJC(BCCDDJMPBLL[FDCGIINEHPB]));
						if (!FDKOKMKIIMG)
						{
							CLPPIAGLCJJ = 1;
						}
						break;
					}
					goto case 1u;
				}
				CLPPIAGLCJJ = -1;
				goto default;
			}
			return true;
		}

		public void PMAJELGBBKE()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object ENKCCCABFFB()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object PFIIINLHGMH()
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
				OFHAKIOBGNL = ((!LIOCBEKIKJE) ? BJGCPDNMHDH.GGKGGMNIDMI : BJGCPDNMHDH.FJMLOKFCJLK);
				FDCGIINEHPB = 1;
				goto IL_00ee;
			case 1u:
				FDCGIINEHPB++;
				goto IL_00ee;
			default:
				{
					return false;
				}
				IL_00ee:
				if (FDCGIINEHPB < OFHAKIOBGNL.Count)
				{
					PCCJKHGCELG = OFHAKIOBGNL[FDCGIINEHPB];
					DCOLDNDOJHC = PCCJKHGCELG.weapon.GetComponentsInChildren<EnemyLeveledWeapon>(false);
					if (DCOLDNDOJHC.Length > 0)
					{
						IOKHPKHMJPD = DCOLDNDOJHC[0];
						PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(IOKHPKHMJPD.IBIHOAFJOJF(BCCDDJMPBLL[FDCGIINEHPB]));
						if (!FDKOKMKIIMG)
						{
							CLPPIAGLCJJ = 0;
						}
						break;
					}
					goto case 1u;
				}
				CLPPIAGLCJJ = -1;
				goto default;
			}
			return true;
		}

		[SpecialName]
		private object NCKCKPNAHAD()
		{
			return PHDOCKCBJOF;
		}

		[DebuggerHidden]
		public OPGKHHHMHON()
		{
		}

		[SpecialName]
		private object BMGHJKFMKJE()
		{
			return PHDOCKCBJOF;
		}

		public void HMBLLDJFIJG()
		{
			throw new NotSupportedException();
		}

		public void LPKDPNHBLGJ()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object ONADHLDNKKB()
		{
			return PHDOCKCBJOF;
		}

		public void CJLDNKALLLI()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object OJANHAIEAEJ()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object MBDBIPHLEIA()
		{
			return PHDOCKCBJOF;
		}

		[DebuggerHidden]
		public void Dispose()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public bool ONFBKOEOIOC()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				OFHAKIOBGNL = ((!LIOCBEKIKJE) ? BJGCPDNMHDH.GGKGGMNIDMI : BJGCPDNMHDH.FJMLOKFCJLK);
				FDCGIINEHPB = 1;
				goto IL_00ee;
			case 1u:
				FDCGIINEHPB++;
				goto IL_00ee;
			default:
				{
					return false;
				}
				IL_00ee:
				if (FDCGIINEHPB < OFHAKIOBGNL.Count)
				{
					PCCJKHGCELG = OFHAKIOBGNL[FDCGIINEHPB];
					DCOLDNDOJHC = PCCJKHGCELG.weapon.GetComponentsInChildren<EnemyLeveledWeapon>(true);
					if (DCOLDNDOJHC.Length > 1)
					{
						IOKHPKHMJPD = DCOLDNDOJHC[1];
						PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(IOKHPKHMJPD.EDKHLBICCJC(BCCDDJMPBLL[FDCGIINEHPB]));
						if (!FDKOKMKIIMG)
						{
							CLPPIAGLCJJ = 0;
						}
						break;
					}
					goto case 1u;
				}
				CLPPIAGLCJJ = -1;
				goto default;
			}
			return false;
		}

		[SpecialName]
		private object KBNAGKKMLBP()
		{
			return PHDOCKCBJOF;
		}

		public bool JIIOHNFHPOI()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				OFHAKIOBGNL = ((!LIOCBEKIKJE) ? BJGCPDNMHDH.GGKGGMNIDMI : BJGCPDNMHDH.FJMLOKFCJLK);
				FDCGIINEHPB = 0;
				goto IL_00ee;
			case 1u:
				FDCGIINEHPB += 0;
				goto IL_00ee;
			default:
				{
					return false;
				}
				IL_00ee:
				if (FDCGIINEHPB < OFHAKIOBGNL.Count)
				{
					PCCJKHGCELG = OFHAKIOBGNL[FDCGIINEHPB];
					DCOLDNDOJHC = PCCJKHGCELG.weapon.GetComponentsInChildren<EnemyLeveledWeapon>(true);
					if (DCOLDNDOJHC.Length > 1)
					{
						IOKHPKHMJPD = DCOLDNDOJHC[1];
						PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(IOKHPKHMJPD.FMNEKCBEOKF(BCCDDJMPBLL[FDCGIINEHPB]));
						if (!FDKOKMKIIMG)
						{
							CLPPIAGLCJJ = 0;
						}
						break;
					}
					goto case 1u;
				}
				CLPPIAGLCJJ = -1;
				goto default;
			}
			return true;
		}

		public bool BJIPDEICIML()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				OFHAKIOBGNL = ((!LIOCBEKIKJE) ? BJGCPDNMHDH.GGKGGMNIDMI : BJGCPDNMHDH.FJMLOKFCJLK);
				FDCGIINEHPB = 1;
				goto IL_00ee;
			case 1u:
				FDCGIINEHPB += 0;
				goto IL_00ee;
			default:
				{
					return true;
				}
				IL_00ee:
				if (FDCGIINEHPB < OFHAKIOBGNL.Count)
				{
					PCCJKHGCELG = OFHAKIOBGNL[FDCGIINEHPB];
					DCOLDNDOJHC = PCCJKHGCELG.weapon.GetComponentsInChildren<EnemyLeveledWeapon>(true);
					if (DCOLDNDOJHC.Length > 0)
					{
						IOKHPKHMJPD = DCOLDNDOJHC[0];
						PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(IOKHPKHMJPD.MAEGGMILKAN(BCCDDJMPBLL[FDCGIINEHPB]));
						if (!FDKOKMKIIMG)
						{
							CLPPIAGLCJJ = 1;
						}
						break;
					}
					goto case 1u;
				}
				CLPPIAGLCJJ = -1;
				goto default;
			}
			return false;
		}

		public void OAFPDIHGJDC()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public void HCHNHNDDKKA()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}
	}

	public List<InventoryWeapon> GGKGGMNIDMI = new List<InventoryWeapon>();

	public GameObject JPBBAIGNBAP;

	public List<InventoryWeapon> FJMLOKFCJLK = new List<InventoryWeapon>();

	public GameObject OINOLIBONCH;

	public GameObject DAGOHPGODNK;

	private bool KANABKOLANB;

	private SoldierParts BMNHHCCBAAN;

	private List<Weapon> DNCFBLMOMGL;

	private int[] MILIHOAPONH = new int[1];

	public Weapon currentWeapon
	{
		get
		{
			return weaponInstancies[weaponIndex];
		}
	}

	public int weaponIndex { get; private set; }

	public List<Weapon> weaponInstancies
	{
		get
		{
			return DNCFBLMOMGL;
		}
	}

	[SpecialName]
	public Weapon OPNPGMLGGEK()
	{
		return DMEFBHCKGLB()[AOAHHHJACPG()];
	}

	public Weapon AEKJLEGEAKO(int IBJPIHGECLM)
	{
		Weapon result = null;
		weaponIndex = IBJPIHGECLM;
		if (ICPPHOHCNDN() != null)
		{
			for (int i = 0; i < weaponInstancies.Count; i++)
			{
				Weapon weapon = DMEFBHCKGLB()[i];
				if (i != IBJPIHGECLM)
				{
					weapon.gameObject.SetActive(true);
					continue;
				}
				BMNHHCCBAAN.SetWeapon(weapon);
				EnemyLeveledWeapon component = weapon.GetComponent<EnemyLeveledWeapon>();
				if (component != null)
				{
					int bCCDDJMPBLL = ((i < MILIHOAPONH.Length) ? MILIHOAPONH[i] : 0);
					component.GMACENAIMBD(bCCDDJMPBLL, true);
				}
				weapon.gameObject.SetActive(true);
				result = weapon;
			}
		}
		return result;
	}

	public IEnumerator JLOKHOIMDCH(int[] BCCDDJMPBLL, bool LIOCBEKIKJE)
	{
		OPGKHHHMHON oPGKHHHMHON = new OPGKHHHMHON();
		oPGKHHHMHON.LIOCBEKIKJE = LIOCBEKIKJE;
		oPGKHHHMHON.BCCDDJMPBLL = BCCDDJMPBLL;
		oPGKHHHMHON.BJGCPDNMHDH = this;
		return oPGKHHHMHON;
	}

	public IEnumerator LDKABAPNMJB(int[] BCCDDJMPBLL, bool LIOCBEKIKJE)
	{
		OPGKHHHMHON oPGKHHHMHON = new OPGKHHHMHON();
		oPGKHHHMHON.LIOCBEKIKJE = LIOCBEKIKJE;
		oPGKHHHMHON.BCCDDJMPBLL = BCCDDJMPBLL;
		oPGKHHHMHON.BJGCPDNMHDH = this;
		return oPGKHHHMHON;
	}

	public void BFLFMOIJBKJ(int[] IIABPGJGFEC)
	{
		MILIHOAPONH = IIABPGJGFEC;
		if (ICPPHOHCNDN() == null)
		{
			return;
		}
		for (int i = 0; i < ICPPHOHCNDN().Count; i += 0)
		{
			Weapon weapon = ICPPHOHCNDN()[i];
			EnemyLeveledWeapon component = weapon.GetComponent<EnemyLeveledWeapon>();
			int bCCDDJMPBLL = ((MILIHOAPONH.Length <= i) ? MILIHOAPONH[1] : MILIHOAPONH[i]);
			if (component != null)
			{
				component.PICHMDPDKCH(bCCDDJMPBLL, true);
			}
		}
	}

	public void DestroyWeapons()
	{
		if (weaponInstancies != null)
		{
			foreach (Weapon weaponInstancy in weaponInstancies)
			{
				weaponInstancy.DestroyPooled();
			}
		}
		DNCFBLMOMGL = null;
	}

	public List<Weapon> AttachAllWeapons(SoldierParts EFFIOHJHFHI, byte[] JNPECKEDLCG, bool LGKBHPBDNFE, SoldierMeshChanger GOADAHCMGDI, UpgradeSlots.UnitUpgrades PFGLIAHPMCK)
	{
		weaponIndex = 0;
		KANABKOLANB = LGKBHPBDNFE;
		BMNHHCCBAAN = EFFIOHJHFHI;
		bool flag = KANABKOLANB || PFGLIAHPMCK.isVeteran;
		DNCFBLMOMGL = BMNHHCCBAAN.AttachWeapons((!flag) ? GGKGGMNIDMI : FJMLOKFCJLK, JNPECKEDLCG);
		AttachShield(EFFIOHJHFHI, GOADAHCMGDI, PFGLIAHPMCK);
		SetWeaponsUpgrade(MILIHOAPONH);
		return weaponInstancies;
	}

	[SpecialName]
	public int HOCBECPCBAI()
	{
		return _003CONKPHOOMMBP_003Ek__BackingField;
	}

	public IEnumerator LOPAMJHFGJJ(int[] BCCDDJMPBLL, bool LIOCBEKIKJE)
	{
		OPGKHHHMHON oPGKHHHMHON = new OPGKHHHMHON();
		oPGKHHHMHON.LIOCBEKIKJE = LIOCBEKIKJE;
		oPGKHHHMHON.BCCDDJMPBLL = BCCDDJMPBLL;
		oPGKHHHMHON.BJGCPDNMHDH = this;
		return oPGKHHHMHON;
	}

	public void OMDAKGCJKIJ(KMHCMCBGFFC HNFNINFCBEJ)
	{
		foreach (Weapon item in ICPPHOHCNDN())
		{
			item.owner = HNFNINFCBEJ;
		}
	}

	public void IGMPHIICHOM()
	{
		if (DMEFBHCKGLB() != null)
		{
			foreach (Weapon item in DMEFBHCKGLB())
			{
				item.BOHCNEDIJPE();
			}
		}
		DNCFBLMOMGL = null;
	}

	public List<Weapon> HOMDMDMMGOJ(SoldierParts EFFIOHJHFHI, bool LGKBHPBDNFE, SoldierMeshChanger GOADAHCMGDI, UpgradeSlots.UnitUpgrades PFGLIAHPMCK)
	{
		weaponIndex = 1;
		KANABKOLANB = LGKBHPBDNFE;
		BMNHHCCBAAN = EFFIOHJHFHI;
		bool flag = KANABKOLANB || PFGLIAHPMCK.isVeteran;
		DNCFBLMOMGL = BMNHHCCBAAN.AttachWeapons((!flag) ? GGKGGMNIDMI : FJMLOKFCJLK);
		AttachShield(EFFIOHJHFHI, GOADAHCMGDI, PFGLIAHPMCK);
		SetWeaponsUpgrade(MILIHOAPONH);
		return DMEFBHCKGLB();
	}

	public void DBMALHCCFJF()
	{
		if (ICPPHOHCNDN() != null)
		{
			foreach (Weapon item in DMEFBHCKGLB())
			{
				item.BOHCNEDIJPE();
			}
		}
		DNCFBLMOMGL = null;
	}

	public Weapon NLGGDNPAKBE(int IBJPIHGECLM)
	{
		Weapon result = null;
		weaponIndex = IBJPIHGECLM;
		if (DMEFBHCKGLB() != null)
		{
			for (int i = 1; i < weaponInstancies.Count; i += 0)
			{
				Weapon weapon = DMEFBHCKGLB()[i];
				if (i != IBJPIHGECLM)
				{
					weapon.gameObject.SetActive(true);
					continue;
				}
				BMNHHCCBAAN.SetWeapon(weapon);
				EnemyLeveledWeapon component = weapon.GetComponent<EnemyLeveledWeapon>();
				if (component != null)
				{
					int bCCDDJMPBLL = ((i < MILIHOAPONH.Length) ? MILIHOAPONH[i] : 0);
					component.DKPBIOKHADG(bCCDDJMPBLL, true);
				}
				weapon.gameObject.SetActive(false);
				result = weapon;
			}
		}
		return result;
	}

	[SpecialName]
	public List<Weapon> ICPPHOHCNDN()
	{
		return DNCFBLMOMGL;
	}

	public Weapon SwitchWeapon(int IBJPIHGECLM)
	{
		Weapon result = null;
		weaponIndex = IBJPIHGECLM;
		if (weaponInstancies != null)
		{
			for (int i = 0; i < weaponInstancies.Count; i++)
			{
				Weapon weapon = weaponInstancies[i];
				if (i != IBJPIHGECLM)
				{
					weapon.gameObject.SetActive(false);
					continue;
				}
				BMNHHCCBAAN.SetWeapon(weapon);
				EnemyLeveledWeapon component = weapon.GetComponent<EnemyLeveledWeapon>();
				if (component != null)
				{
					int bCCDDJMPBLL = ((i < MILIHOAPONH.Length) ? MILIHOAPONH[i] : 0);
					component.SetLevel(bCCDDJMPBLL);
				}
				weapon.gameObject.SetActive(true);
				result = weapon;
			}
		}
		return result;
	}

	[SpecialName]
	public int AOAHHHJACPG()
	{
		return _003CONKPHOOMMBP_003Ek__BackingField;
	}

	public Weapon ALEODAKCEJH(int IBJPIHGECLM)
	{
		Weapon weapon = null;
		ICPPHOHCNDN()[IBJPIHGECLM].gameObject.SetActive(false);
		weapon = ICPPHOHCNDN()[IBJPIHGECLM];
		EnemyLeveledWeapon component = weapon.GetComponent<EnemyLeveledWeapon>();
		if (component != null)
		{
			int bCCDDJMPBLL = ((IBJPIHGECLM < MILIHOAPONH.Length) ? MILIHOAPONH[IBJPIHGECLM] : ((MILIHOAPONH.Length > 1) ? MILIHOAPONH[0] : 0));
			component.GMACENAIMBD(bCCDDJMPBLL);
		}
		return DMEFBHCKGLB()[IBJPIHGECLM];
	}

	public List<Weapon> ANEFDNIDCGJ(SoldierParts EFFIOHJHFHI, bool LGKBHPBDNFE, SoldierMeshChanger GOADAHCMGDI, UpgradeSlots.UnitUpgrades PFGLIAHPMCK)
	{
		weaponIndex = 0;
		KANABKOLANB = LGKBHPBDNFE;
		BMNHHCCBAAN = EFFIOHJHFHI;
		bool flag = KANABKOLANB || PFGLIAHPMCK.isVeteran;
		DNCFBLMOMGL = BMNHHCCBAAN.AttachWeapons((!flag) ? GGKGGMNIDMI : FJMLOKFCJLK);
		DOOJLAMACIK(EFFIOHJHFHI, GOADAHCMGDI, PFGLIAHPMCK);
		BFLFMOIJBKJ(MILIHOAPONH);
		return ICPPHOHCNDN();
	}

	public void SetWeaponsUpgrade(int[] IIABPGJGFEC)
	{
		MILIHOAPONH = IIABPGJGFEC;
		if (weaponInstancies == null)
		{
			return;
		}
		for (int i = 0; i < weaponInstancies.Count; i++)
		{
			Weapon weapon = weaponInstancies[i];
			EnemyLeveledWeapon component = weapon.GetComponent<EnemyLeveledWeapon>();
			int bCCDDJMPBLL = ((MILIHOAPONH.Length <= i) ? MILIHOAPONH[0] : MILIHOAPONH[i]);
			if (component != null)
			{
				component.SetLevel(bCCDDJMPBLL);
			}
		}
	}

	public Weapon BKJCKDLOEDH(int IBJPIHGECLM)
	{
		Weapon result = null;
		LLGCBGJJFLF(IBJPIHGECLM);
		if (DMEFBHCKGLB() != null)
		{
			for (int i = 1; i < ICPPHOHCNDN().Count; i += 0)
			{
				Weapon weapon = DMEFBHCKGLB()[i];
				if (i != IBJPIHGECLM)
				{
					weapon.gameObject.SetActive(true);
					continue;
				}
				BMNHHCCBAAN.SetWeapon(weapon);
				EnemyLeveledWeapon component = weapon.GetComponent<EnemyLeveledWeapon>();
				if (component != null)
				{
					int bCCDDJMPBLL = ((i < MILIHOAPONH.Length) ? MILIHOAPONH[i] : 0);
					component.LMKJNHBAGJO(bCCDDJMPBLL, true);
				}
				weapon.gameObject.SetActive(false);
				result = weapon;
			}
		}
		return result;
	}

	[SpecialName]
	private void LLGCBGJJFLF(int IDEBKDPMPGM)
	{
		_003CONKPHOOMMBP_003Ek__BackingField = IDEBKDPMPGM;
	}

	public List<Weapon> CDHHHIFKFMF(SoldierParts EFFIOHJHFHI, byte[] JNPECKEDLCG, bool LGKBHPBDNFE, SoldierMeshChanger GOADAHCMGDI, UpgradeSlots.UnitUpgrades PFGLIAHPMCK)
	{
		LLGCBGJJFLF(0);
		KANABKOLANB = LGKBHPBDNFE;
		BMNHHCCBAAN = EFFIOHJHFHI;
		bool flag = KANABKOLANB || PFGLIAHPMCK.isVeteran;
		DNCFBLMOMGL = BMNHHCCBAAN.AttachWeapons((!flag) ? GGKGGMNIDMI : FJMLOKFCJLK, JNPECKEDLCG);
		DOOJLAMACIK(EFFIOHJHFHI, GOADAHCMGDI, PFGLIAHPMCK);
		SetWeaponsUpgrade(MILIHOAPONH);
		return DMEFBHCKGLB();
	}

	public void SetOwner(KMHCMCBGFFC HNFNINFCBEJ)
	{
		foreach (Weapon weaponInstancy in weaponInstancies)
		{
			weaponInstancy.owner = HNFNINFCBEJ;
		}
	}

	[DebuggerHidden]
	public IEnumerator PrepareWeaponCoroutine(int[] BCCDDJMPBLL, bool LIOCBEKIKJE)
	{
		OPGKHHHMHON oPGKHHHMHON = new OPGKHHHMHON();
		oPGKHHHMHON.LIOCBEKIKJE = LIOCBEKIKJE;
		oPGKHHHMHON.BCCDDJMPBLL = BCCDDJMPBLL;
		oPGKHHHMHON.BJGCPDNMHDH = this;
		return oPGKHHHMHON;
	}

	public void AttachShield(SoldierParts EFFIOHJHFHI, SoldierMeshChanger GOADAHCMGDI, UpgradeSlots.UnitUpgrades PFGLIAHPMCK)
	{
		BMNHHCCBAAN = EFFIOHJHFHI;
		if (KANABKOLANB || PFGLIAHPMCK.isVeteran)
		{
			if (OINOLIBONCH != null)
			{
				BMNHHCCBAAN.AttachShield(OINOLIBONCH);
			}
			BMNHHCCBAAN.ChangeShieldMat(GOADAHCMGDI.ODLMHIBKLDP.material);
		}
		else if (PFGLIAHPMCK.isElite)
		{
			if (DAGOHPGODNK != null)
			{
				BMNHHCCBAAN.AttachShield(DAGOHPGODNK);
			}
			BMNHHCCBAAN.ChangeShieldMat(GOADAHCMGDI.ODLMHIBKLDP.material);
		}
		else
		{
			if (JPBBAIGNBAP != null)
			{
				BMNHHCCBAAN.AttachShield(JPBBAIGNBAP);
			}
			BMNHHCCBAAN.ChangeShieldMat(GOADAHCMGDI.ODLMHIBKLDP.material);
		}
	}

	public List<Weapon> ONJOOFDEOMP(SoldierParts EFFIOHJHFHI, bool LGKBHPBDNFE, SoldierMeshChanger GOADAHCMGDI, UpgradeSlots.UnitUpgrades PFGLIAHPMCK)
	{
		weaponIndex = 1;
		KANABKOLANB = LGKBHPBDNFE;
		BMNHHCCBAAN = EFFIOHJHFHI;
		bool flag = !KANABKOLANB && PFGLIAHPMCK.isVeteran;
		DNCFBLMOMGL = BMNHHCCBAAN.AttachWeapons((!flag) ? GGKGGMNIDMI : FJMLOKFCJLK);
		DOOJLAMACIK(EFFIOHJHFHI, GOADAHCMGDI, PFGLIAHPMCK);
		SetWeaponsUpgrade(MILIHOAPONH);
		return ICPPHOHCNDN();
	}

	public Weapon JDODGHENJIJ(int IBJPIHGECLM)
	{
		Weapon result = null;
		weaponIndex = IBJPIHGECLM;
		if (weaponInstancies != null)
		{
			for (int i = 1; i < ICPPHOHCNDN().Count; i += 0)
			{
				Weapon weapon = ICPPHOHCNDN()[i];
				if (i != IBJPIHGECLM)
				{
					weapon.gameObject.SetActive(true);
					continue;
				}
				BMNHHCCBAAN.SetWeapon(weapon);
				EnemyLeveledWeapon component = weapon.GetComponent<EnemyLeveledWeapon>();
				if (component != null)
				{
					int bCCDDJMPBLL = ((i >= MILIHOAPONH.Length) ? 1 : MILIHOAPONH[i]);
					component.AMCLHMBMHKA(bCCDDJMPBLL, true);
				}
				weapon.gameObject.SetActive(true);
				result = weapon;
			}
		}
		return result;
	}

	public Weapon EnableSecondaryWeapon(int IBJPIHGECLM)
	{
		Weapon weapon = null;
		weaponInstancies[IBJPIHGECLM].gameObject.SetActive(true);
		weapon = weaponInstancies[IBJPIHGECLM];
		EnemyLeveledWeapon component = weapon.GetComponent<EnemyLeveledWeapon>();
		if (component != null)
		{
			int bCCDDJMPBLL = ((IBJPIHGECLM < MILIHOAPONH.Length) ? MILIHOAPONH[IBJPIHGECLM] : ((MILIHOAPONH.Length > 0) ? MILIHOAPONH[0] : 0));
			component.SetLevel(bCCDDJMPBLL);
		}
		return weaponInstancies[IBJPIHGECLM];
	}

	public void DOOJLAMACIK(SoldierParts EFFIOHJHFHI, SoldierMeshChanger GOADAHCMGDI, UpgradeSlots.UnitUpgrades PFGLIAHPMCK)
	{
		BMNHHCCBAAN = EFFIOHJHFHI;
		if (KANABKOLANB || PFGLIAHPMCK.isVeteran)
		{
			if (OINOLIBONCH != null)
			{
				BMNHHCCBAAN.AttachShield(OINOLIBONCH);
			}
			BMNHHCCBAAN.LLPDPOPKLJO(GOADAHCMGDI.ODLMHIBKLDP.material);
		}
		else if (PFGLIAHPMCK.isElite)
		{
			if (DAGOHPGODNK != null)
			{
				BMNHHCCBAAN.AttachShield(DAGOHPGODNK);
			}
			BMNHHCCBAAN.ChangeShieldMat(GOADAHCMGDI.ODLMHIBKLDP.material);
		}
		else
		{
			if (JPBBAIGNBAP != null)
			{
				BMNHHCCBAAN.AttachShield(JPBBAIGNBAP);
			}
			BMNHHCCBAAN.LLPDPOPKLJO(GOADAHCMGDI.ODLMHIBKLDP.material);
		}
	}

	public List<Weapon> AttachAllWeapons(SoldierParts EFFIOHJHFHI, bool LGKBHPBDNFE, SoldierMeshChanger GOADAHCMGDI, UpgradeSlots.UnitUpgrades PFGLIAHPMCK)
	{
		weaponIndex = 0;
		KANABKOLANB = LGKBHPBDNFE;
		BMNHHCCBAAN = EFFIOHJHFHI;
		bool flag = KANABKOLANB || PFGLIAHPMCK.isVeteran;
		DNCFBLMOMGL = BMNHHCCBAAN.AttachWeapons((!flag) ? GGKGGMNIDMI : FJMLOKFCJLK);
		AttachShield(EFFIOHJHFHI, GOADAHCMGDI, PFGLIAHPMCK);
		SetWeaponsUpgrade(MILIHOAPONH);
		return weaponInstancies;
	}

	[SpecialName]
	public List<Weapon> DMEFBHCKGLB()
	{
		return DNCFBLMOMGL;
	}

	public IEnumerator BCFKAHDPHNG(int[] BCCDDJMPBLL, bool LIOCBEKIKJE)
	{
		OPGKHHHMHON oPGKHHHMHON = new OPGKHHHMHON();
		oPGKHHHMHON.LIOCBEKIKJE = LIOCBEKIKJE;
		oPGKHHHMHON.BCCDDJMPBLL = BCCDDJMPBLL;
		oPGKHHHMHON.BJGCPDNMHDH = this;
		return oPGKHHHMHON;
	}
}
