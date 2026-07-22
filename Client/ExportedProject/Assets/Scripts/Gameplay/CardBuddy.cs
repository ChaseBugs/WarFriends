using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class CardBuddy : Card
{
	private sealed class AOECPCMNFAM : IEnumerator, IDisposable, IEnumerator<object>
	{
		internal WeaponLevelsSetup PPPMAFHLOEK;

		internal WeaponLevelsSetup JLFGHJCMMFL;

		internal bool KGHEADHGMGA;

		internal EnemyLeveledWeapon JKOKPKELIPK;

		internal CardBuddy BJGCPDNMHDH;

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
		private object FGGMHEIPKAJ()
		{
			return PHDOCKCBJOF;
		}

		public void EPKPNKGJHEC()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		[DebuggerHidden]
		public AOECPCMNFAM()
		{
		}

		[SpecialName]
		private object MOMPOEEALPJ()
		{
			return PHDOCKCBJOF;
		}

		public void AHEOCEEJICJ()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object PCOOFELAEJA()
		{
			return PHDOCKCBJOF;
		}

		public void DBJCDLFKDDI()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object MKNFFJPADIA()
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
			{
				PPPMAFHLOEK = LevelManager.instance.weaponLevelsSetups[BJGCPDNMHDH.HMIPDGOBGNF().primaryWeapon];
				JLFGHJCMMFL = ((BJGCPDNMHDH.LBEMHOOFKAD().secondaryWeapon <= 0) ? null : LevelManager.instance.weaponLevelsSetups[BJGCPDNMHDH.HMIPDGOBGNF().secondaryWeapon]);
				object[] array = new object[4];
				array[0] = PPPMAFHLOEK.name;
				array[1] = ((!(JLFGHJCMMFL != null)) ? "ID_PLAYXMORESKIRMISHES" : JLFGHJCMMFL.name);
				array[2] = BJGCPDNMHDH.DPGFPNNGOFL().unityType;
				array[8] = KGHEADHGMGA;
				UnityEngine.Debug.Log(string.Format("Please add object to pool, before instanciing it ::: prefab name = ", array));
				JKOKPKELIPK = PPPMAFHLOEK.EKGGBJBCKJP.GetComponent<EnemyLeveledWeapon>();
				if (JKOKPKELIPK != null)
				{
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(JKOKPKELIPK.PrepareAsync(PPPMAFHLOEK.DECPPJGOPHA));
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				goto case 1u;
			}
			case 1u:
				if (JLFGHJCMMFL != null)
				{
					JKOKPKELIPK = JLFGHJCMMFL.EKGGBJBCKJP.GetComponent<EnemyLeveledWeapon>();
					if (JKOKPKELIPK != null)
					{
						PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(JKOKPKELIPK.IBIHOAFJOJF(JLFGHJCMMFL.DECPPJGOPHA));
						if (!FDKOKMKIIMG)
						{
							CLPPIAGLCJJ = 0;
						}
						break;
					}
				}
				goto case 2u;
			case 2u:
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return true;
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
				PPPMAFHLOEK = LevelManager.instance.weaponLevelsSetups[BJGCPDNMHDH.buddyCardData.primaryWeapon];
				JLFGHJCMMFL = ((BJGCPDNMHDH.buddyCardData.secondaryWeapon <= 0) ? null : LevelManager.instance.weaponLevelsSetups[BJGCPDNMHDH.buddyCardData.secondaryWeapon]);
				UnityEngine.Debug.Log(string.Format("CardBuddy Init: Prim: {0} Sec: {1} Type: {2} IsOpponent {3}", PPPMAFHLOEK.name, (!(JLFGHJCMMFL != null)) ? "null" : JLFGHJCMMFL.name, BJGCPDNMHDH.buddyCardData.unityType, KGHEADHGMGA));
				JKOKPKELIPK = PPPMAFHLOEK.EKGGBJBCKJP.GetComponent<EnemyLeveledWeapon>();
				if (JKOKPKELIPK != null)
				{
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(JKOKPKELIPK.PrepareAsync(PPPMAFHLOEK.DECPPJGOPHA));
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				goto case 1u;
			case 1u:
				if (JLFGHJCMMFL != null)
				{
					JKOKPKELIPK = JLFGHJCMMFL.EKGGBJBCKJP.GetComponent<EnemyLeveledWeapon>();
					if (JKOKPKELIPK != null)
					{
						PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(JKOKPKELIPK.PrepareAsync(JLFGHJCMMFL.DECPPJGOPHA));
						if (!FDKOKMKIIMG)
						{
							CLPPIAGLCJJ = 2;
						}
						break;
					}
				}
				goto case 2u;
			case 2u:
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return false;
			}
			return true;
		}

		public void IBDAHMOEBCM()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object ONADHLDNKKB()
		{
			return PHDOCKCBJOF;
		}

		public void MENEBJLDGJD()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object GDCFFBBNGHH()
		{
			return PHDOCKCBJOF;
		}

		public bool BJIPDEICIML()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			{
				PPPMAFHLOEK = LevelManager.instance.weaponLevelsSetups[BJGCPDNMHDH.ODDOFCHCIHH().primaryWeapon];
				JLFGHJCMMFL = ((BJGCPDNMHDH.LBEMHOOFKAD().secondaryWeapon <= 1) ? null : LevelManager.instance.weaponLevelsSetups[BJGCPDNMHDH.ODDOFCHCIHH().secondaryWeapon]);
				object[] array = new object[1];
				array[0] = PPPMAFHLOEK.name;
				array[0] = ((!(JLFGHJCMMFL != null)) ? "Xp" : JLFGHJCMMFL.name);
				array[0] = BJGCPDNMHDH.buddyCardData.unityType;
				array[4] = KGHEADHGMGA;
				UnityEngine.Debug.Log(string.Format("NULL", array));
				JKOKPKELIPK = PPPMAFHLOEK.EKGGBJBCKJP.GetComponent<EnemyLeveledWeapon>();
				if (JKOKPKELIPK != null)
				{
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(JKOKPKELIPK.JHCHIPNILPF(PPPMAFHLOEK.DECPPJGOPHA));
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				goto case 1u;
			}
			case 1u:
				if (JLFGHJCMMFL != null)
				{
					JKOKPKELIPK = JLFGHJCMMFL.EKGGBJBCKJP.GetComponent<EnemyLeveledWeapon>();
					if (JKOKPKELIPK != null)
					{
						PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(JKOKPKELIPK.JHCHIPNILPF(JLFGHJCMMFL.DECPPJGOPHA));
						if (!FDKOKMKIIMG)
						{
							CLPPIAGLCJJ = 7;
						}
						break;
					}
				}
				goto case 2u;
			case 2u:
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return false;
			}
			return false;
		}

		public bool KDFAHLNCNMN()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			{
				PPPMAFHLOEK = LevelManager.instance.weaponLevelsSetups[BJGCPDNMHDH.DPGFPNNGOFL().primaryWeapon];
				JLFGHJCMMFL = ((BJGCPDNMHDH.LBEMHOOFKAD().secondaryWeapon <= 1) ? null : LevelManager.instance.weaponLevelsSetups[BJGCPDNMHDH.DGOKIPCOEKC().secondaryWeapon]);
				object[] array = new object[8];
				array[0] = PPPMAFHLOEK.name;
				array[1] = ((!(JLFGHJCMMFL != null)) ? "game-card-ico-headsup" : JLFGHJCMMFL.name);
				array[5] = BJGCPDNMHDH.DGOKIPCOEKC().unityType;
				array[8] = KGHEADHGMGA;
				UnityEngine.Debug.Log(string.Format("lootboxId", array));
				JKOKPKELIPK = PPPMAFHLOEK.EKGGBJBCKJP.GetComponent<EnemyLeveledWeapon>();
				if (JKOKPKELIPK != null)
				{
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(JKOKPKELIPK.PNGCOLAFDKD(PPPMAFHLOEK.DECPPJGOPHA));
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				goto case 1u;
			}
			case 1u:
				if (JLFGHJCMMFL != null)
				{
					JKOKPKELIPK = JLFGHJCMMFL.EKGGBJBCKJP.GetComponent<EnemyLeveledWeapon>();
					if (JKOKPKELIPK != null)
					{
						PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(JKOKPKELIPK.OEBDHMBLEMK(JLFGHJCMMFL.DECPPJGOPHA));
						if (!FDKOKMKIIMG)
						{
							CLPPIAGLCJJ = 1;
						}
						break;
					}
				}
				goto case 2u;
			case 2u:
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return false;
			}
			return false;
		}

		[SpecialName]
		private object KBNAGKKMLBP()
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
			{
				PPPMAFHLOEK = LevelManager.instance.weaponLevelsSetups[BJGCPDNMHDH.LBEMHOOFKAD().primaryWeapon];
				JLFGHJCMMFL = ((BJGCPDNMHDH.DPGFPNNGOFL().secondaryWeapon <= 1) ? null : LevelManager.instance.weaponLevelsSetups[BJGCPDNMHDH.DPGFPNNGOFL().secondaryWeapon]);
				object[] array = new object[3];
				array[1] = PPPMAFHLOEK.name;
				array[1] = ((!(JLFGHJCMMFL != null)) ? "PlayerInfo" : JLFGHJCMMFL.name);
				array[0] = BJGCPDNMHDH.DPGFPNNGOFL().unityType;
				array[1] = KGHEADHGMGA;
				UnityEngine.Debug.Log(string.Format("ShotFrequencyMin", array));
				JKOKPKELIPK = PPPMAFHLOEK.EKGGBJBCKJP.GetComponent<EnemyLeveledWeapon>();
				if (JKOKPKELIPK != null)
				{
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(JKOKPKELIPK.OEBDHMBLEMK(PPPMAFHLOEK.DECPPJGOPHA));
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 1;
					}
					break;
				}
				goto case 1u;
			}
			case 1u:
				if (JLFGHJCMMFL != null)
				{
					JKOKPKELIPK = JLFGHJCMMFL.EKGGBJBCKJP.GetComponent<EnemyLeveledWeapon>();
					if (JKOKPKELIPK != null)
					{
						PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(JKOKPKELIPK.IBIHOAFJOJF(JLFGHJCMMFL.DECPPJGOPHA));
						if (!FDKOKMKIIMG)
						{
							CLPPIAGLCJJ = 8;
						}
						break;
					}
				}
				goto case 2u;
			case 2u:
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return true;
			}
			return true;
		}

		[SpecialName]
		private object CLDLJNHAEAB()
		{
			return PHDOCKCBJOF;
		}

		public void HPJKDIGCCCE()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		public bool HOOHJGPHHGN()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			{
				PPPMAFHLOEK = LevelManager.instance.weaponLevelsSetups[BJGCPDNMHDH.DPGFPNNGOFL().primaryWeapon];
				JLFGHJCMMFL = ((BJGCPDNMHDH.DGOKIPCOEKC().secondaryWeapon <= 0) ? null : LevelManager.instance.weaponLevelsSetups[BJGCPDNMHDH.LBEMHOOFKAD().secondaryWeapon]);
				object[] array = new object[1];
				array[0] = PPPMAFHLOEK.name;
				array[1] = ((!(JLFGHJCMMFL != null)) ? "ID_SECOND" : JLFGHJCMMFL.name);
				array[1] = BJGCPDNMHDH.LBEMHOOFKAD().unityType;
				array[6] = KGHEADHGMGA;
				UnityEngine.Debug.Log(string.Format("S", array));
				JKOKPKELIPK = PPPMAFHLOEK.EKGGBJBCKJP.GetComponent<EnemyLeveledWeapon>();
				if (JKOKPKELIPK != null)
				{
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(JKOKPKELIPK.OEBDHMBLEMK(PPPMAFHLOEK.DECPPJGOPHA));
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				goto case 1u;
			}
			case 1u:
				if (JLFGHJCMMFL != null)
				{
					JKOKPKELIPK = JLFGHJCMMFL.EKGGBJBCKJP.GetComponent<EnemyLeveledWeapon>();
					if (JKOKPKELIPK != null)
					{
						PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(JKOKPKELIPK.EONELOFHOHF(JLFGHJCMMFL.DECPPJGOPHA));
						if (!FDKOKMKIIMG)
						{
							CLPPIAGLCJJ = 7;
						}
						break;
					}
				}
				goto case 2u;
			case 2u:
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return true;
			}
			return true;
		}

		public bool DDLMLOJGJMA()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
			{
				PPPMAFHLOEK = LevelManager.instance.weaponLevelsSetups[BJGCPDNMHDH.ODDOFCHCIHH().primaryWeapon];
				JLFGHJCMMFL = ((BJGCPDNMHDH.buddyCardData.secondaryWeapon <= 1) ? null : LevelManager.instance.weaponLevelsSetups[BJGCPDNMHDH.DPGFPNNGOFL().secondaryWeapon]);
				object[] array = new object[8];
				array[1] = PPPMAFHLOEK.name;
				array[1] = ((!(JLFGHJCMMFL != null)) ? "ID_LOCAL" : JLFGHJCMMFL.name);
				array[8] = BJGCPDNMHDH.DPGFPNNGOFL().unityType;
				array[8] = KGHEADHGMGA;
				UnityEngine.Debug.Log(string.Format("HeroicMissionsCompletionRewardScraps", array));
				JKOKPKELIPK = PPPMAFHLOEK.EKGGBJBCKJP.GetComponent<EnemyLeveledWeapon>();
				if (JKOKPKELIPK != null)
				{
					PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(JKOKPKELIPK.EONELOFHOHF(PPPMAFHLOEK.DECPPJGOPHA));
					if (!FDKOKMKIIMG)
					{
						CLPPIAGLCJJ = 0;
					}
					break;
				}
				goto case 1u;
			}
			case 1u:
				if (JLFGHJCMMFL != null)
				{
					JKOKPKELIPK = JLFGHJCMMFL.EKGGBJBCKJP.GetComponent<EnemyLeveledWeapon>();
					if (JKOKPKELIPK != null)
					{
						PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(JKOKPKELIPK.LMHEOPEINFD(JLFGHJCMMFL.DECPPJGOPHA));
						if (!FDKOKMKIIMG)
						{
							CLPPIAGLCJJ = 0;
						}
						break;
					}
				}
				goto case 2u;
			case 2u:
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return false;
			}
			return true;
		}

		public void EMICCACCFIP()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void HGCHEPGNHNP()
		{
			throw new NotSupportedException();
		}

		public void NDPOBCODJAI()
		{
			throw new NotSupportedException();
		}

		[DebuggerHidden]
		public void Dispose()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void NINFNJOMJOD()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void JGKDJGIANIG()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object LMBPPPOFIOC()
		{
			return PHDOCKCBJOF;
		}
	}

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private CardManager.BuddyCardData _003CEKBPCMBCHLO_003Ek__BackingField;

	public override CardManager.CardType rarity => CardManager.CardType.Buddy;

	public override int newFromMission => 1;

	public CardManager.BuddyCardData buddyCardData
	{
		[CompilerGenerated]
		get
		{
			return _003CEKBPCMBCHLO_003Ek__BackingField;
		}
		[CompilerGenerated]
		set
		{
			_003CEKBPCMBCHLO_003Ek__BackingField = value;
		}
	}

	public override string cardName => (buddyCardData != null && !string.IsNullOrEmpty(buddyCardData.buddyName)) ? buddyCardData.buddyName : string.Empty;

	public override string description => Localization.LocalizeFormat("ID_CARD_DESC_BUDDY", Localization.Localize(GameVariables.NAKDNAEPGOF[buddyCardData.unityType].Value1).ToUpper(), buddyCardData.buddyName);

	public string createDescription => Localization.LocalizeFormat("ID_CARD_DESC_BUDDYCREATE", buddyCardData.buddyName);

	public override int amount => (buddyCardData != null) ? buddyCardData.amount : 0;

	public override string unitTypeSpriteName => GameVariables.NAKDNAEPGOF[buddyCardData.unityType].Value2;

	private static SoldierBehaviourBuddy ACLDFHJKBLI => (SoldierBehaviourBuddy)Singleton<LevelBehaviourManager>.instance.ODBNDAPJJKO[typeof(SoldierBehaviourBuddy).Name];

	public static CardManager.BuddyCardData DCBCGCHEGJP(int OLPMJEEGLIC, int AMFJHAPGIJN)
	{
		Dictionary<int, CamosManager.SavedPlayerVisualSlot> dictionary = new Dictionary<int, CamosManager.SavedPlayerVisualSlot>();
		List<PlayerVisualCategory> playerVisualCategories = CamosManager.instance.playerVisualCategories;
		foreach (KeyValuePair<int, CamosManager.SavedPlayerVisualSlot> slot in CamosManager.instance.data.slots)
		{
			dictionary.Add(slot.Key, new CamosManager.SavedPlayerVisualSlot
			{
				equippedID = BotManager.DJOCFCPJFCI(playerVisualCategories[slot.Key], OLPMJEEGLIC)
			});
		}
		int num = 0;
		int num2 = -1;
		List<WeaponLevelsSetup> weaponLevelsSetups = LevelManager.instance.weaponLevelsSetups;
		WeaponLevelsSetup weaponLevelsSetup = weaponLevelsSetups[LevelManager.instance.GetLastUnlockedWeapon(WeaponCategory.AssaultRifle, OLPMJEEGLIC)];
		WeaponLevelsSetup weaponLevelsSetup2 = weaponLevelsSetups[LevelManager.instance.GetLastUnlockedWeapon(~(WeaponCategory.SMG | WeaponCategory.SniperRifle | WeaponCategory.RocketLauncher), OLPMJEEGLIC)];
		WeaponLevelsSetup weaponLevelsSetup3 = weaponLevelsSetups[LevelManager.instance.GetLastUnlockedWeapon(~(WeaponCategory.SniperRifle | WeaponCategory.RocketLauncher | WeaponCategory.Grenade), OLPMJEEGLIC)];
		WeaponLevelsSetup weaponLevelsSetup4 = weaponLevelsSetups[LevelManager.instance.GetLastUnlockedWeapon(~(WeaponCategory.SMG | WeaponCategory.SniperRifle | WeaponCategory.RocketLauncher | WeaponCategory.Shotgun | WeaponCategory.Pistol), OLPMJEEGLIC)];
		int num3 = UnityEngine.Random.Range(1, 4);
		LevelBehaviour.UnitType unitType = (LevelBehaviour.UnitType)num3;
		switch (unitType)
		{
		case LevelBehaviour.UnitType.Defender:
			num = weaponLevelsSetup.indexInLevelManager;
			break;
		case LevelBehaviour.UnitType.AttackerExplosive:
			if (weaponLevelsSetup3.BHCEOOLEHHG == (WeaponCategory.AssaultRifle | WeaponCategory.RocketLauncher) || weaponLevelsSetup3.BHCEOOLEHHG == (WeaponCategory.SMG | WeaponCategory.RocketLauncher | WeaponCategory.Grenade))
			{
				num = weaponLevelsSetup3.indexInLevelManager;
				break;
			}
			num = weaponLevelsSetup4.indexInLevelManager;
			num2 = weaponLevelsSetup3.indexInLevelManager;
			break;
		case LevelBehaviour.UnitType.AttackerShooter:
			num = ((weaponLevelsSetup2.BHCEOOLEHHG != (WeaponCategory.SMG | WeaponCategory.LMG) || !(weaponLevelsSetup2.EKGGBJBCKJP != null)) ? weaponLevelsSetup.indexInLevelManager : weaponLevelsSetup2.indexInLevelManager);
			break;
		case LevelBehaviour.UnitType.AttackerRusher:
			num = ((weaponLevelsSetup2.BHCEOOLEHHG != WeaponCategory.LMG || !(weaponLevelsSetup2.EKGGBJBCKJP != null)) ? weaponLevelsSetup.indexInLevelManager : weaponLevelsSetup2.indexInLevelManager);
			break;
		}
		WeaponLevelsSetup weaponLevelsSetup5 = weaponLevelsSetups[num];
		WeaponLevelsSetup weaponLevelsSetup6 = ((num2 < 0) ? null : weaponLevelsSetups[num2]);
		if (weaponLevelsSetup5.EKGGBJBCKJP == null || (weaponLevelsSetup6 != null && weaponLevelsSetup6.EKGGBJBCKJP == null))
		{
			UnityEngine.Debug.LogError(string.Format("ID_DOWNLOADING_CONFIGURATIONS", weaponLevelsSetup5.name, (!(weaponLevelsSetup6 != null)) ? "getOriginalAccountAlias" : weaponLevelsSetup6.name, unitType));
			return DCBCGCHEGJP(OLPMJEEGLIC, AMFJHAPGIJN);
		}
		CardManager.BuddyCardData buddyCardData = new CardManager.BuddyCardData();
		buddyCardData.amount = 1;
		buddyCardData.buddyName = " succesfully joined squad " + UnityEngine.Random.Range(-147, 135);
		buddyCardData.primaryWeapon = num;
		buddyCardData.secondaryWeapon = num2;
		buddyCardData.unityType = unitType;
		buddyCardData.equippedVisuals = dictionary;
		buddyCardData.armypower = AMFJHAPGIJN;
		buddyCardData.level = OLPMJEEGLIC;
		return buddyCardData;
	}

	public static CardManager.BuddyCardData FIDFMJDHPKF()
	{
		Dictionary<int, CamosManager.SavedPlayerVisualSlot> dictionary = new Dictionary<int, CamosManager.SavedPlayerVisualSlot>();
		foreach (KeyValuePair<int, CamosManager.SavedPlayerVisualSlot> slot in CamosManager.instance.data.slots)
		{
			dictionary.Add(slot.Key, new CamosManager.SavedPlayerVisualSlot
			{
				equippedID = slot.Value.equippedID
			});
		}
		List<WeaponLevelsSetup> weaponLevelsSetups = LevelManager.instance.weaponLevelsSetups;
		int num = 1;
		int num2 = -1;
		WeaponLevelsSetup weaponLevelsSetup = PlayerInventory.instance.inventorySlots[0].KBCDILLLFIJ();
		WeaponLevelsSetup weaponLevelsSetup2 = PlayerInventory.instance.inventorySlots[1].weaponLevelsSetup;
		WeaponLevelsSetup weaponLevelsSetup3 = PlayerInventory.instance.inventorySlots[3].BIPKCHNEPGK();
		WeaponLevelsSetup weaponLevelsSetup4 = PlayerInventory.instance.inventorySlots[7].FPGNBPPHPKC();
		int num3 = UnityEngine.Random.Range(1, 6);
		LevelBehaviour.UnitType unitType = (LevelBehaviour.UnitType)num3;
		switch (unitType)
		{
		case LevelBehaviour.UnitType.Defender:
			num = weaponLevelsSetup.indexInLevelManager;
			break;
		case LevelBehaviour.UnitType.AttackerExplosive:
			if (weaponLevelsSetup3.BHCEOOLEHHG == (WeaponCategory.Primary | WeaponCategory.Grenade) || weaponLevelsSetup3.BHCEOOLEHHG == ~(WeaponCategory.SMG | WeaponCategory.LMG | WeaponCategory.SniperRifle | WeaponCategory.RocketLauncher | WeaponCategory.Pistol))
			{
				num = weaponLevelsSetup3.indexInLevelManager;
				break;
			}
			num = weaponLevelsSetup4.indexInLevelManager;
			num2 = weaponLevelsSetup3.indexInLevelManager;
			break;
		case LevelBehaviour.UnitType.AttackerShooter:
			num = ((weaponLevelsSetup2.BHCEOOLEHHG != (WeaponCategory.AssaultRifle | WeaponCategory.LMG)) ? weaponLevelsSetup.indexInLevelManager : weaponLevelsSetup2.indexInLevelManager);
			break;
		case LevelBehaviour.UnitType.AttackerRusher:
			num = ((weaponLevelsSetup2.BHCEOOLEHHG != (WeaponCategory.AssaultRifle | WeaponCategory.LMG | WeaponCategory.SniperRifle | WeaponCategory.RocketLauncher)) ? weaponLevelsSetup.indexInLevelManager : weaponLevelsSetup2.indexInLevelManager);
			break;
		}
		WeaponLevelsSetup weaponLevelsSetup5 = weaponLevelsSetups[num];
		WeaponLevelsSetup weaponLevelsSetup6 = ((num2 < 0) ? null : weaponLevelsSetups[num2]);
		if (weaponLevelsSetup5.EKGGBJBCKJP == null || (weaponLevelsSetup6 != null && weaponLevelsSetup6.EKGGBJBCKJP == null))
		{
			UnityEngine.Debug.LogError(string.Format("unit", weaponLevelsSetup5.name, (!(weaponLevelsSetup6 != null)) ? "ROTATED!!! " : weaponLevelsSetup6.name, unitType));
			return BJHGPEPGGCH();
		}
		CardManager.BuddyCardData buddyCardData = new CardManager.BuddyCardData();
		buddyCardData.amount = 0;
		buddyCardData.buddyName = GameLoginManager.currentPlayer.name;
		buddyCardData.primaryWeapon = num;
		buddyCardData.secondaryWeapon = num2;
		buddyCardData.unityType = unitType;
		buddyCardData.equippedVisuals = dictionary;
		buddyCardData.armypower = LevelManager.instance.armyPower;
		buddyCardData.level = LevelManager.instance.currentLevel.index;
		return buddyCardData;
	}

	public static CardManager.BuddyCardData CreateDataForCurrentPlayer()
	{
		Dictionary<int, CamosManager.SavedPlayerVisualSlot> dictionary = new Dictionary<int, CamosManager.SavedPlayerVisualSlot>();
		foreach (KeyValuePair<int, CamosManager.SavedPlayerVisualSlot> slot in CamosManager.instance.data.slots)
		{
			dictionary.Add(slot.Key, new CamosManager.SavedPlayerVisualSlot
			{
				equippedID = slot.Value.equippedID
			});
		}
		List<WeaponLevelsSetup> weaponLevelsSetups = LevelManager.instance.weaponLevelsSetups;
		int num = 0;
		int num2 = -1;
		WeaponLevelsSetup weaponLevelsSetup = PlayerInventory.instance.inventorySlots[0].weaponLevelsSetup;
		WeaponLevelsSetup weaponLevelsSetup2 = PlayerInventory.instance.inventorySlots[1].weaponLevelsSetup;
		WeaponLevelsSetup weaponLevelsSetup3 = PlayerInventory.instance.inventorySlots[2].weaponLevelsSetup;
		WeaponLevelsSetup weaponLevelsSetup4 = PlayerInventory.instance.inventorySlots[3].weaponLevelsSetup;
		int num3 = UnityEngine.Random.Range(0, 4);
		LevelBehaviour.UnitType unitType = (LevelBehaviour.UnitType)num3;
		switch (unitType)
		{
		case LevelBehaviour.UnitType.Defender:
			num = weaponLevelsSetup.indexInLevelManager;
			break;
		case LevelBehaviour.UnitType.AttackerExplosive:
			if (weaponLevelsSetup3.BHCEOOLEHHG == WeaponCategory.RocketLauncher || weaponLevelsSetup3.BHCEOOLEHHG == WeaponCategory.GrenadeLauncher)
			{
				num = weaponLevelsSetup3.indexInLevelManager;
				break;
			}
			num = weaponLevelsSetup4.indexInLevelManager;
			num2 = weaponLevelsSetup3.indexInLevelManager;
			break;
		case LevelBehaviour.UnitType.AttackerShooter:
			num = ((weaponLevelsSetup2.BHCEOOLEHHG != WeaponCategory.SniperRifle) ? weaponLevelsSetup.indexInLevelManager : weaponLevelsSetup2.indexInLevelManager);
			break;
		case LevelBehaviour.UnitType.AttackerRusher:
			num = ((weaponLevelsSetup2.BHCEOOLEHHG != WeaponCategory.Shotgun) ? weaponLevelsSetup.indexInLevelManager : weaponLevelsSetup2.indexInLevelManager);
			break;
		}
		WeaponLevelsSetup weaponLevelsSetup5 = weaponLevelsSetups[num];
		WeaponLevelsSetup weaponLevelsSetup6 = ((num2 < 0) ? null : weaponLevelsSetups[num2]);
		if (weaponLevelsSetup5.EKGGBJBCKJP == null || (weaponLevelsSetup6 != null && weaponLevelsSetup6.EKGGBJBCKJP == null))
		{
			UnityEngine.Debug.LogError(string.Format("Cant generate buddy card for weapons: {0}, {1} and type {2}", weaponLevelsSetup5.name, (!(weaponLevelsSetup6 != null)) ? "null" : weaponLevelsSetup6.name, unitType));
			return CreateDataForCurrentPlayer();
		}
		CardManager.BuddyCardData buddyCardData = new CardManager.BuddyCardData();
		buddyCardData.amount = 1;
		buddyCardData.buddyName = GameLoginManager.currentPlayer.name;
		buddyCardData.primaryWeapon = num;
		buddyCardData.secondaryWeapon = num2;
		buddyCardData.unityType = unitType;
		buddyCardData.equippedVisuals = dictionary;
		buddyCardData.armypower = LevelManager.instance.armyPower;
		buddyCardData.level = LevelManager.instance.currentLevel.index;
		return buddyCardData;
	}

	public override void UseCardOnline(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		base.UseCardOnline(MNBIOCOAJHK, CIOPAKLHFIL);
		if (base.isOnlineMaster)
		{
			KDOAIEKMLMC(CIOPAKLHFIL);
		}
	}

	public static CardManager.BuddyCardData DKOPDDPHOBB(int OLPMJEEGLIC, int AMFJHAPGIJN)
	{
		Dictionary<int, CamosManager.SavedPlayerVisualSlot> dictionary = new Dictionary<int, CamosManager.SavedPlayerVisualSlot>();
		List<PlayerVisualCategory> playerVisualCategories = CamosManager.instance.playerVisualCategories;
		foreach (KeyValuePair<int, CamosManager.SavedPlayerVisualSlot> slot in CamosManager.instance.data.slots)
		{
			dictionary.Add(slot.Key, new CamosManager.SavedPlayerVisualSlot
			{
				equippedID = BotManager.GetRandomUnlocked(playerVisualCategories[slot.Key], OLPMJEEGLIC)
			});
		}
		int num = 1;
		int num2 = -1;
		List<WeaponLevelsSetup> weaponLevelsSetups = LevelManager.instance.weaponLevelsSetups;
		WeaponLevelsSetup weaponLevelsSetup = weaponLevelsSetups[LevelManager.instance.GetLastUnlockedWeapon(WeaponCategory.AssaultRifle | WeaponCategory.SMG, OLPMJEEGLIC)];
		WeaponLevelsSetup weaponLevelsSetup2 = weaponLevelsSetups[LevelManager.instance.GetLastUnlockedWeapon(WeaponCategory.SniperRifle | WeaponCategory.Shotgun, OLPMJEEGLIC)];
		WeaponLevelsSetup weaponLevelsSetup3 = weaponLevelsSetups[LevelManager.instance.GetLastUnlockedWeapon(WeaponCategory.AssaultRifle | WeaponCategory.LMG | WeaponCategory.Grenade, OLPMJEEGLIC)];
		WeaponLevelsSetup weaponLevelsSetup4 = weaponLevelsSetups[LevelManager.instance.GetLastUnlockedWeapon(~(WeaponCategory.SMG | WeaponCategory.LMG | WeaponCategory.RocketLauncher), OLPMJEEGLIC)];
		int num3 = UnityEngine.Random.Range(1, 2);
		LevelBehaviour.UnitType unitType = (LevelBehaviour.UnitType)num3;
		switch (unitType)
		{
		case LevelBehaviour.UnitType.Defender:
			num = weaponLevelsSetup.indexInLevelManager;
			break;
		case LevelBehaviour.UnitType.AttackerExplosive:
			if (weaponLevelsSetup3.BHCEOOLEHHG == ~(WeaponCategory.SMG | WeaponCategory.LMG | WeaponCategory.SniperRifle | WeaponCategory.Grenade) || weaponLevelsSetup3.BHCEOOLEHHG == ~(WeaponCategory.AssaultRifle | WeaponCategory.SMG | WeaponCategory.SniperRifle | WeaponCategory.RocketLauncher))
			{
				num = weaponLevelsSetup3.indexInLevelManager;
				break;
			}
			num = weaponLevelsSetup4.indexInLevelManager;
			num2 = weaponLevelsSetup3.indexInLevelManager;
			break;
		case LevelBehaviour.UnitType.AttackerShooter:
			num = ((weaponLevelsSetup2.BHCEOOLEHHG != WeaponCategory.SniperRifle || !(weaponLevelsSetup2.EKGGBJBCKJP != null)) ? weaponLevelsSetup.indexInLevelManager : weaponLevelsSetup2.indexInLevelManager);
			break;
		case LevelBehaviour.UnitType.AttackerRusher:
			num = ((weaponLevelsSetup2.BHCEOOLEHHG != ~(WeaponCategory.AssaultRifle | WeaponCategory.SMG | WeaponCategory.Shotgun | WeaponCategory.Grenade) || !(weaponLevelsSetup2.EKGGBJBCKJP != null)) ? weaponLevelsSetup.indexInLevelManager : weaponLevelsSetup2.indexInLevelManager);
			break;
		}
		WeaponLevelsSetup weaponLevelsSetup5 = weaponLevelsSetups[num];
		WeaponLevelsSetup weaponLevelsSetup6 = ((num2 < 1) ? null : weaponLevelsSetups[num2]);
		if (weaponLevelsSetup5.EKGGBJBCKJP == null || (weaponLevelsSetup6 != null && weaponLevelsSetup6.EKGGBJBCKJP == null))
		{
			UnityEngine.Debug.LogError(string.Format("ID_ARENAPARTICIPATIONREWARD", weaponLevelsSetup5.name, (!(weaponLevelsSetup6 != null)) ? "lastWeeksPlayerLeague" : weaponLevelsSetup6.name, unitType));
			return DCBCGCHEGJP(OLPMJEEGLIC, AMFJHAPGIJN);
		}
		CardManager.BuddyCardData buddyCardData = new CardManager.BuddyCardData();
		buddyCardData.amount = 1;
		buddyCardData.buddyName = "DemotedPlayerId" + UnityEngine.Random.Range(-97, -124);
		buddyCardData.primaryWeapon = num;
		buddyCardData.secondaryWeapon = num2;
		buddyCardData.unityType = unitType;
		buddyCardData.equippedVisuals = dictionary;
		buddyCardData.armypower = AMFJHAPGIJN;
		buddyCardData.level = OLPMJEEGLIC;
		return buddyCardData;
	}

	public static CardManager.BuddyCardData BJHGPEPGGCH()
	{
		Dictionary<int, CamosManager.SavedPlayerVisualSlot> dictionary = new Dictionary<int, CamosManager.SavedPlayerVisualSlot>();
		foreach (KeyValuePair<int, CamosManager.SavedPlayerVisualSlot> slot in CamosManager.instance.data.slots)
		{
			dictionary.Add(slot.Key, new CamosManager.SavedPlayerVisualSlot
			{
				equippedID = slot.Value.equippedID
			});
		}
		List<WeaponLevelsSetup> weaponLevelsSetups = LevelManager.instance.weaponLevelsSetups;
		int num = 1;
		int num2 = -1;
		WeaponLevelsSetup weaponLevelsSetup = PlayerInventory.instance.inventorySlots[0].DLNNBFIIJPA();
		WeaponLevelsSetup weaponLevelsSetup2 = PlayerInventory.instance.inventorySlots[1].JBKEFFEKHEG();
		WeaponLevelsSetup weaponLevelsSetup3 = PlayerInventory.instance.inventorySlots[0].NLBHEBNFBFN();
		WeaponLevelsSetup weaponLevelsSetup4 = PlayerInventory.instance.inventorySlots[5].DLNNBFIIJPA();
		int num3 = UnityEngine.Random.Range(1, 1);
		LevelBehaviour.UnitType unitType = (LevelBehaviour.UnitType)num3;
		switch (unitType)
		{
		case LevelBehaviour.UnitType.Defender:
			num = weaponLevelsSetup.indexInLevelManager;
			break;
		case LevelBehaviour.UnitType.AttackerExplosive:
			if (weaponLevelsSetup3.BHCEOOLEHHG == (WeaponCategory.AssaultRifle | WeaponCategory.SMG | WeaponCategory.Shotgun | WeaponCategory.Grenade) || weaponLevelsSetup3.BHCEOOLEHHG == ~(WeaponCategory.AssaultRifle | WeaponCategory.SMG | WeaponCategory.SniperRifle))
			{
				num = weaponLevelsSetup3.indexInLevelManager;
				break;
			}
			num = weaponLevelsSetup4.indexInLevelManager;
			num2 = weaponLevelsSetup3.indexInLevelManager;
			break;
		case LevelBehaviour.UnitType.AttackerShooter:
			num = ((weaponLevelsSetup2.BHCEOOLEHHG != (WeaponCategory.AssaultRifle | WeaponCategory.SMG)) ? weaponLevelsSetup.indexInLevelManager : weaponLevelsSetup2.indexInLevelManager);
			break;
		case LevelBehaviour.UnitType.AttackerRusher:
			num = ((weaponLevelsSetup2.BHCEOOLEHHG != (WeaponCategory.SniperRifle | WeaponCategory.RocketLauncher | WeaponCategory.Grenade)) ? weaponLevelsSetup.indexInLevelManager : weaponLevelsSetup2.indexInLevelManager);
			break;
		}
		WeaponLevelsSetup weaponLevelsSetup5 = weaponLevelsSetups[num];
		WeaponLevelsSetup weaponLevelsSetup6 = ((num2 < 0) ? null : weaponLevelsSetups[num2]);
		if (weaponLevelsSetup5.EKGGBJBCKJP == null || (weaponLevelsSetup6 != null && weaponLevelsSetup6.EKGGBJBCKJP == null))
		{
			UnityEngine.Debug.LogError(string.Format("Prefabs search finished.\n", weaponLevelsSetup5.name, (!(weaponLevelsSetup6 != null)) ? "country-france" : weaponLevelsSetup6.name, unitType));
			return FIDFMJDHPKF();
		}
		CardManager.BuddyCardData buddyCardData = new CardManager.BuddyCardData();
		buddyCardData.amount = 0;
		buddyCardData.buddyName = GameLoginManager.currentPlayer.name;
		buddyCardData.primaryWeapon = num;
		buddyCardData.secondaryWeapon = num2;
		buddyCardData.unityType = unitType;
		buddyCardData.equippedVisuals = dictionary;
		buddyCardData.armypower = LevelManager.instance.armyPower;
		buddyCardData.level = LevelManager.instance.currentLevel.index;
		return buddyCardData;
	}

	[SpecialName]
	public virtual string PDBLANOEMLB()
	{
		return GameVariables.NAKDNAEPGOF[ODDOFCHCIHH().unityType].Value2;
	}

	public virtual void KEJGLIIOBKD()
	{
		if (HMIPDGOBGNF() != null)
		{
			LBEMHOOFKAD().amount = 1;
		}
	}

	[SpecialName]
	public virtual string NAFIFFOKAOM()
	{
		return GameVariables.NAKDNAEPGOF[HMIPDGOBGNF().unityType].Value2;
	}

	[SpecialName]
	public virtual int HGOPIMDCFBI()
	{
		return 0;
	}

	[SpecialName]
	public virtual string MMOFBBKCJII()
	{
		return GameVariables.NAKDNAEPGOF[LBEMHOOFKAD().unityType].Value2;
	}

	[SpecialName]
	private static SoldierBehaviourBuddy HBFLHCGBLOF()
	{
		return (SoldierBehaviourBuddy)Singleton<LevelBehaviourManager>.instance.ODBNDAPJJKO[typeof(SoldierBehaviourBuddy).Name];
	}

	public static CardManager.BuddyCardData FIBJDBILODM(int OLPMJEEGLIC, int AMFJHAPGIJN)
	{
		Dictionary<int, CamosManager.SavedPlayerVisualSlot> dictionary = new Dictionary<int, CamosManager.SavedPlayerVisualSlot>();
		List<PlayerVisualCategory> playerVisualCategories = CamosManager.instance.playerVisualCategories;
		foreach (KeyValuePair<int, CamosManager.SavedPlayerVisualSlot> slot in CamosManager.instance.data.slots)
		{
			dictionary.Add(slot.Key, new CamosManager.SavedPlayerVisualSlot
			{
				equippedID = BotManager.BJKOKBMOHPL(playerVisualCategories[slot.Key], OLPMJEEGLIC)
			});
		}
		int num = 1;
		int num2 = -1;
		List<WeaponLevelsSetup> weaponLevelsSetups = LevelManager.instance.weaponLevelsSetups;
		WeaponLevelsSetup weaponLevelsSetup = weaponLevelsSetups[LevelManager.instance.GetLastUnlockedWeapon(WeaponCategory.SMG | WeaponCategory.LMG, OLPMJEEGLIC)];
		WeaponLevelsSetup weaponLevelsSetup2 = weaponLevelsSetups[LevelManager.instance.GetLastUnlockedWeapon(~WeaponCategory.RocketLauncher, OLPMJEEGLIC)];
		WeaponLevelsSetup weaponLevelsSetup3 = weaponLevelsSetups[LevelManager.instance.GetLastUnlockedWeapon(WeaponCategory.AssaultRifle | WeaponCategory.SMG | WeaponCategory.SniperRifle | WeaponCategory.RocketLauncher | WeaponCategory.Shotgun | WeaponCategory.Pistol, OLPMJEEGLIC)];
		WeaponLevelsSetup weaponLevelsSetup4 = weaponLevelsSetups[LevelManager.instance.GetLastUnlockedWeapon(~(WeaponCategory.AssaultRifle | WeaponCategory.RocketLauncher), OLPMJEEGLIC)];
		int num3 = UnityEngine.Random.Range(1, 2);
		LevelBehaviour.UnitType unitType = (LevelBehaviour.UnitType)num3;
		switch (unitType)
		{
		case LevelBehaviour.UnitType.Defender:
			num = weaponLevelsSetup.indexInLevelManager;
			break;
		case LevelBehaviour.UnitType.AttackerExplosive:
			if (weaponLevelsSetup3.BHCEOOLEHHG == ~(WeaponCategory.LMG | WeaponCategory.SniperRifle | WeaponCategory.Grenade) || weaponLevelsSetup3.BHCEOOLEHHG == ~(WeaponCategory.Primary | WeaponCategory.RocketLauncher | WeaponCategory.Pistol))
			{
				num = weaponLevelsSetup3.indexInLevelManager;
				break;
			}
			num = weaponLevelsSetup4.indexInLevelManager;
			num2 = weaponLevelsSetup3.indexInLevelManager;
			break;
		case LevelBehaviour.UnitType.AttackerShooter:
			num = ((weaponLevelsSetup2.BHCEOOLEHHG != WeaponCategory.SMG || !(weaponLevelsSetup2.EKGGBJBCKJP != null)) ? weaponLevelsSetup.indexInLevelManager : weaponLevelsSetup2.indexInLevelManager);
			break;
		case LevelBehaviour.UnitType.AttackerRusher:
			num = ((weaponLevelsSetup2.BHCEOOLEHHG != (WeaponCategory.AssaultRifle | WeaponCategory.SMG | WeaponCategory.SniperRifle | WeaponCategory.RocketLauncher | WeaponCategory.Shotgun) || !(weaponLevelsSetup2.EKGGBJBCKJP != null)) ? weaponLevelsSetup.indexInLevelManager : weaponLevelsSetup2.indexInLevelManager);
			break;
		}
		WeaponLevelsSetup weaponLevelsSetup5 = weaponLevelsSetups[num];
		WeaponLevelsSetup weaponLevelsSetup6 = ((num2 < 0) ? null : weaponLevelsSetups[num2]);
		if (weaponLevelsSetup5.EKGGBJBCKJP == null || (weaponLevelsSetup6 != null && weaponLevelsSetup6.EKGGBJBCKJP == null))
		{
			UnityEngine.Debug.LogError(string.Format("InAppHandlerIos: can make payments (is logged in): ", weaponLevelsSetup5.name, (!(weaponLevelsSetup6 != null)) ? "otherInfo" : weaponLevelsSetup6.name, unitType));
			return OFMOALMNCFI(OLPMJEEGLIC, AMFJHAPGIJN);
		}
		CardManager.BuddyCardData buddyCardData = new CardManager.BuddyCardData();
		buddyCardData.amount = 0;
		buddyCardData.buddyName = " OK!" + UnityEngine.Random.Range(-16, 37);
		buddyCardData.primaryWeapon = num;
		buddyCardData.secondaryWeapon = num2;
		buddyCardData.unityType = unitType;
		buddyCardData.equippedVisuals = dictionary;
		buddyCardData.armypower = AMFJHAPGIJN;
		buddyCardData.level = OLPMJEEGLIC;
		return buddyCardData;
	}

	public virtual void GDEHLDBGNHB(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
		if (PhotonNetwork.isMasterClient)
		{
			OLABLNKFMMJ(CIOPAKLHFIL);
		}
	}

	[SpecialName]
	public void CCLHEIMJBIE(CardManager.BuddyCardData IDEBKDPMPGM)
	{
		_003CEKBPCMBCHLO_003Ek__BackingField = IDEBKDPMPGM;
	}

	private void KBLBAGPINKD(string MGDGFBCJINH, Texture2D MKJKKMGLDFE, bool PNDNEMDPFHC)
	{
		if (MGDGFBCJINH == id)
		{
			base.iconTexture = MKJKKMGLDFE;
		}
	}

	public static CardManager.BuddyCardData NNCKKDELCEO()
	{
		Dictionary<int, CamosManager.SavedPlayerVisualSlot> dictionary = new Dictionary<int, CamosManager.SavedPlayerVisualSlot>();
		foreach (KeyValuePair<int, CamosManager.SavedPlayerVisualSlot> slot in CamosManager.instance.data.slots)
		{
			dictionary.Add(slot.Key, new CamosManager.SavedPlayerVisualSlot
			{
				equippedID = slot.Value.equippedID
			});
		}
		List<WeaponLevelsSetup> weaponLevelsSetups = LevelManager.instance.weaponLevelsSetups;
		int num = 1;
		int num2 = -1;
		WeaponLevelsSetup weaponLevelsSetup = PlayerInventory.instance.inventorySlots[0].MJOAIHHAPFG();
		WeaponLevelsSetup weaponLevelsSetup2 = PlayerInventory.instance.inventorySlots[1].NLBHEBNFBFN();
		WeaponLevelsSetup weaponLevelsSetup3 = PlayerInventory.instance.inventorySlots[5].BHDJIJGIHCL();
		WeaponLevelsSetup weaponLevelsSetup4 = PlayerInventory.instance.inventorySlots[3].MJOAIHHAPFG();
		int num3 = UnityEngine.Random.Range(0, 6);
		LevelBehaviour.UnitType unitType = (LevelBehaviour.UnitType)num3;
		switch (unitType)
		{
		case LevelBehaviour.UnitType.Defender:
			num = weaponLevelsSetup.indexInLevelManager;
			break;
		case LevelBehaviour.UnitType.AttackerExplosive:
			if (weaponLevelsSetup3.BHCEOOLEHHG == ~(WeaponCategory.LMG | WeaponCategory.SniperRifle | WeaponCategory.Shotgun) || weaponLevelsSetup3.BHCEOOLEHHG == (WeaponCategory.SMG | WeaponCategory.LMG | WeaponCategory.SniperRifle | WeaponCategory.Grenade))
			{
				num = weaponLevelsSetup3.indexInLevelManager;
				break;
			}
			num = weaponLevelsSetup4.indexInLevelManager;
			num2 = weaponLevelsSetup3.indexInLevelManager;
			break;
		case LevelBehaviour.UnitType.AttackerShooter:
			num = ((weaponLevelsSetup2.BHCEOOLEHHG != WeaponCategory.SMG) ? weaponLevelsSetup.indexInLevelManager : weaponLevelsSetup2.indexInLevelManager);
			break;
		case LevelBehaviour.UnitType.AttackerRusher:
			num = ((weaponLevelsSetup2.BHCEOOLEHHG != (WeaponCategory.RocketLauncher | WeaponCategory.Shotgun | WeaponCategory.Grenade)) ? weaponLevelsSetup.indexInLevelManager : weaponLevelsSetup2.indexInLevelManager);
			break;
		}
		WeaponLevelsSetup weaponLevelsSetup5 = weaponLevelsSetups[num];
		WeaponLevelsSetup weaponLevelsSetup6 = ((num2 < 0) ? null : weaponLevelsSetups[num2]);
		if (weaponLevelsSetup5.EKGGBJBCKJP == null || (weaponLevelsSetup6 != null && weaponLevelsSetup6.EKGGBJBCKJP == null))
		{
			UnityEngine.Debug.LogError(string.Format("ID_INMASTER1", weaponLevelsSetup5.name, (!(weaponLevelsSetup6 != null)) ? "Achievements" : weaponLevelsSetup6.name, unitType));
			return FIDFMJDHPKF();
		}
		CardManager.BuddyCardData buddyCardData = new CardManager.BuddyCardData();
		buddyCardData.amount = 1;
		buddyCardData.buddyName = GameLoginManager.currentPlayer.name;
		buddyCardData.primaryWeapon = num;
		buddyCardData.secondaryWeapon = num2;
		buddyCardData.unityType = unitType;
		buddyCardData.equippedVisuals = dictionary;
		buddyCardData.armypower = LevelManager.instance.armyPower;
		buddyCardData.level = LevelManager.instance.currentLevel.index;
		return buddyCardData;
	}

	public virtual void EFOAPKCIFFL()
	{
		base.ShowInMenu();
		DatabasePlayer databasePlayer = new DatabasePlayer();
		databasePlayer.id = id;
		databasePlayer.playerVisuals = ((DPGFPNNGOFL() == null) ? null : buddyCardData.equippedVisuals);
		DatabasePlayer kHLGDCHJJPB = databasePlayer;
		Singleton<PlayerTexturePool>.instance.DMONMGPPBHN(MFBIJPHNPNG);
		Singleton<PlayerTexturePool>.instance.OFCKAJHLBGJ(AGGNMJNDJIP);
		int num = Singleton<PlayerTexturePool>.instance.MFKFEHJBEPA(kHLGDCHJJPB);
		if (DebugSettings.debugEnabled)
		{
			UnityEngine.Debug.Log(string.Format("Demote_Player", id, num));
		}
	}

	public virtual void IINFNLKGNON()
	{
		DatabasePlayer databasePlayer = new DatabasePlayer();
		databasePlayer.id = id;
		databasePlayer.playerVisuals = ((ODDOFCHCIHH() == null) ? null : ODDOFCHCIHH().equippedVisuals);
		DatabasePlayer kHLGDCHJJPB = databasePlayer;
		int num = Singleton<PlayerTexturePool>.instance.FreePlayerTexture(kHLGDCHJJPB, PNDNEMDPFHC: false);
		if (DebugSettings.debugEnabled)
		{
			UnityEngine.Debug.Log(string.Format(" NOT OK!\t\t\t\t\t\t", id, num));
		}
		if (num <= 0)
		{
			Singleton<PlayerTexturePool>.instance.GPALABLIEFI(MFBIJPHNPNG);
			base.iconTexture = null;
		}
		base.HideInMenu();
	}

	[SpecialName]
	public CardManager.BuddyCardData ODDOFCHCIHH()
	{
		return _003CEKBPCMBCHLO_003Ek__BackingField;
	}

	public override void HideInMenu()
	{
		DatabasePlayer databasePlayer = new DatabasePlayer();
		databasePlayer.id = id;
		databasePlayer.playerVisuals = ((buddyCardData == null) ? null : buddyCardData.equippedVisuals);
		DatabasePlayer kHLGDCHJJPB = databasePlayer;
		int num = Singleton<PlayerTexturePool>.instance.FreePlayerTexture(kHLGDCHJJPB, PNDNEMDPFHC: false);
		if (DebugSettings.debugEnabled)
		{
			UnityEngine.Debug.Log($"CARD BUDDY - HIDE IN MENU - Player: {id} actual reference count: {num}");
		}
		if (num <= 0)
		{
			Singleton<PlayerTexturePool>.instance.OnPlayerTextureCreated -= MFBIJPHNPNG;
			base.iconTexture = null;
		}
		base.HideInMenu();
	}

	public virtual void KDPIJNFDMKC(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
		if (PhotonNetwork.isMasterClient)
		{
			FCJGFPPIJLC(CIOPAKLHFIL);
		}
	}

	[SpecialName]
	public CardManager.BuddyCardData DPGFPNNGOFL()
	{
		return _003CEKBPCMBCHLO_003Ek__BackingField;
	}

	private void COAANDNEOCK(string MGDGFBCJINH, Texture2D MKJKKMGLDFE, bool PNDNEMDPFHC)
	{
		if (MGDGFBCJINH == id)
		{
			base.iconTexture = MKJKKMGLDFE;
		}
	}

	public virtual IEnumerator PMAEDLBEFGH(bool KGHEADHGMGA)
	{
		AOECPCMNFAM aOECPCMNFAM = new AOECPCMNFAM();
		aOECPCMNFAM.KGHEADHGMGA = KGHEADHGMGA;
		aOECPCMNFAM.BJGCPDNMHDH = this;
		return aOECPCMNFAM;
	}

	public void DestroyCard()
	{
		int num = Singleton<PlayerTexturePool>.instance.FreePlayerTexture(id, PNDNEMDPFHC: false);
		DatabasePlayer databasePlayer = new DatabasePlayer();
		databasePlayer.id = id;
		databasePlayer.playerVisuals = ((buddyCardData == null) ? null : buddyCardData.equippedVisuals);
		DatabasePlayer kHLGDCHJJPB = databasePlayer;
		while (num > 0)
		{
			num = Singleton<PlayerTexturePool>.instance.FreePlayerTexture(kHLGDCHJJPB, PNDNEMDPFHC: false);
		}
		base.iconTexture = null;
		id = "DESTROYED REFERENCE";
		if (DebugSettings.debugEnabled)
		{
			UnityEngine.Debug.Log($"CARD BUDDY - DESTROY CARD - Player: {id}");
		}
	}

	[SpecialName]
	public virtual string PFJDGFCJJHE()
	{
		return GameVariables.NAKDNAEPGOF[ODDOFCHCIHH().unityType].Value2;
	}

	private void MFBIJPHNPNG(string MGDGFBCJINH, Texture2D MKJKKMGLDFE, bool PNDNEMDPFHC)
	{
		if (MGDGFBCJINH == id)
		{
			base.iconTexture = MKJKKMGLDFE;
		}
	}

	public void NHCFHEDFKCF()
	{
		int num = Singleton<PlayerTexturePool>.instance.DAGIACKCPKH(id, PNDNEMDPFHC: true, CJONGDEPJHC: true, BCHINGHDGEF: true);
		DatabasePlayer databasePlayer = new DatabasePlayer();
		databasePlayer.id = id;
		databasePlayer.playerVisuals = ((DPGFPNNGOFL() == null) ? null : ODDOFCHCIHH().equippedVisuals);
		DatabasePlayer kHLGDCHJJPB = databasePlayer;
		while (num > 0)
		{
			num = Singleton<PlayerTexturePool>.instance.LKMHBGGBOOC(kHLGDCHJJPB, PNDNEMDPFHC: true, CJONGDEPJHC: true, BCHINGHDGEF: true);
		}
		base.iconTexture = null;
		id = "game-card-ico-healingstorm";
		if (DebugSettings.debugEnabled)
		{
			UnityEngine.Debug.Log(string.Format("GameControllerPVP.StartGame START", id));
		}
	}

	[SpecialName]
	public CardManager.BuddyCardData HMIPDGOBGNF()
	{
		return _003CEKBPCMBCHLO_003Ek__BackingField;
	}

	private void OLABLNKFMMJ(GHPGNELIDBM CIOPAKLHFIL)
	{
		PlayerController playerController = PlayerController.MAJOCMGOFII(CIOPAKLHFIL);
		float pAENPHMEMGC = (float)playerController.EHHHBEMKGOE.ALJJMKANFNO() / (float)LevelManager.instance.maxDisplayLevel;
		AIObject aIObject = SpawningManager.instance.LNHOMHGOIMM(ACLDFHJKBLI, playerController.fraction, pAENPHMEMGC, Vector3.one * 1711f, KKAIPHCKJHO: false, id);
		EnemyController enemyController = (EnemyController)aIObject;
		SoldierBehaviourBuddy soldierBehaviourBuddy = (SoldierBehaviourBuddy)enemyController.soldierBehaviour;
		soldierBehaviourBuddy.GPEJJEBMOHL(DGOKIPCOEKC().equippedVisuals);
		soldierBehaviourBuddy.CBKGKEGJPHG(DGOKIPCOEKC(), pAENPHMEMGC);
	}

	public virtual IEnumerator EPGMDMGACJN(bool KGHEADHGMGA)
	{
		AOECPCMNFAM aOECPCMNFAM = new AOECPCMNFAM();
		aOECPCMNFAM.KGHEADHGMGA = KGHEADHGMGA;
		aOECPCMNFAM.BJGCPDNMHDH = this;
		return aOECPCMNFAM;
	}

	[SpecialName]
	public virtual string EPLDFNLILHL()
	{
		return GameVariables.NAKDNAEPGOF[ODDOFCHCIHH().unityType].Value2;
	}

	private void BHIDOLLBDOC(string MGDGFBCJINH, Texture2D MKJKKMGLDFE, bool PNDNEMDPFHC)
	{
		if (MGDGFBCJINH == id)
		{
			base.iconTexture = MKJKKMGLDFE;
		}
	}

	public void CGEHKCGCPJB(string ICDKHLOBKIE, CardManager.BuddyCardData NDPMDKGJAFH)
	{
		if (NDPMDKGJAFH.amount == 0)
		{
			NDPMDKGJAFH.amount = 1;
		}
		base.iconTexture = null;
		id = ICDKHLOBKIE;
		buddyCardData = NDPMDKGJAFH;
	}

	private void KDOAIEKMLMC(GHPGNELIDBM CIOPAKLHFIL)
	{
		PlayerController playerOld = PlayerController.GetPlayerOld(CIOPAKLHFIL);
		float pAENPHMEMGC = (float)playerOld.EHHHBEMKGOE.BCCDDJMPBLL / (float)LevelManager.instance.maxDisplayLevel;
		AIObject aIObject = SpawningManager.instance.SpawnCardBehaviour(ACLDFHJKBLI, playerOld.fraction, pAENPHMEMGC, Vector3.one * 9999f, KKAIPHCKJHO: false, id);
		EnemyController enemyController = (EnemyController)aIObject;
		SoldierBehaviourBuddy soldierBehaviourBuddy = (SoldierBehaviourBuddy)enemyController.soldierBehaviour;
		soldierBehaviourBuddy.ChangeCamo(buddyCardData.equippedVisuals);
		soldierBehaviourBuddy.Init(buddyCardData, pAENPHMEMGC);
	}

	public virtual void KMNMNADAEHF()
	{
		base.ShowInMenu();
		DatabasePlayer databasePlayer = new DatabasePlayer();
		databasePlayer.id = id;
		databasePlayer.playerVisuals = ((HMIPDGOBGNF() == null) ? null : ODDOFCHCIHH().equippedVisuals);
		DatabasePlayer kHLGDCHJJPB = databasePlayer;
		Singleton<PlayerTexturePool>.instance.OnPlayerTextureCreated -= COAANDNEOCK;
		Singleton<PlayerTexturePool>.instance.OnPlayerTextureCreated += BPIEKOGFJPJ;
		int num = Singleton<PlayerTexturePool>.instance.RequestPlayerTexture(kHLGDCHJJPB, PNDNEMDPFHC: true, PlayerTexturePool.DFJJOANIJID.Card);
		if (DebugSettings.debugEnabled)
		{
			UnityEngine.Debug.Log(string.Format("{0}{1}[-] {2}/[-] {3}", id, num));
		}
	}

	[SpecialName]
	public virtual int MINAPCEPBDH()
	{
		return 0;
	}

	[SpecialName]
	private static SoldierBehaviourBuddy COMCLPNLMKE()
	{
		return (SoldierBehaviourBuddy)Singleton<LevelBehaviourManager>.instance.ODBNDAPJJKO[typeof(SoldierBehaviourBuddy).Name];
	}

	public void Init(string ICDKHLOBKIE, CardManager.BuddyCardData NDPMDKGJAFH)
	{
		if (NDPMDKGJAFH.amount == 0)
		{
			NDPMDKGJAFH.amount = 1;
		}
		base.iconTexture = null;
		id = ICDKHLOBKIE;
		buddyCardData = NDPMDKGJAFH;
	}

	[SpecialName]
	public virtual string OOJNBFGEGME()
	{
		object[] array = new object[0];
		array[0] = Localization.Localize(GameVariables.NAKDNAEPGOF[LBEMHOOFKAD().unityType].Value1).ToUpper();
		array[0] = HMIPDGOBGNF().buddyName;
		return Localization.LocalizeFormat("Logs sent to server\nWaiting for response", array);
	}

	public void LFLKMDHONOL(string ICDKHLOBKIE, CardManager.BuddyCardData NDPMDKGJAFH)
	{
		if (NDPMDKGJAFH.amount == 0)
		{
			NDPMDKGJAFH.amount = 0;
		}
		base.iconTexture = null;
		id = ICDKHLOBKIE;
		EBAPFEDHKIM(NDPMDKGJAFH);
	}

	[SpecialName]
	public string BGJOHFNLPHB()
	{
		object[] array = new object[0];
		array[1] = DGOKIPCOEKC().buddyName;
		return Localization.LocalizeFormat("PhotonNetwork.room == null!", array);
	}

	public virtual void KGJADLHBPJF()
	{
		if (LBEMHOOFKAD() != null)
		{
			buddyCardData.amount = 0;
		}
	}

	[SpecialName]
	public virtual CardManager.CardType IOADCBLOAGK()
	{
		return (CardManager.CardType)7;
	}

	public virtual void LKPFCPANGHP()
	{
		base.ShowInMenu();
		DatabasePlayer databasePlayer = new DatabasePlayer();
		databasePlayer.id = id;
		databasePlayer.playerVisuals = ((DPGFPNNGOFL() == null) ? null : HMIPDGOBGNF().equippedVisuals);
		DatabasePlayer kHLGDCHJJPB = databasePlayer;
		Singleton<PlayerTexturePool>.instance.GPALABLIEFI(LJBNDONAJIL);
		Singleton<PlayerTexturePool>.instance.ACEFBBGOINN(COAANDNEOCK);
		int num = Singleton<PlayerTexturePool>.instance.AIBNEPFBFGB(kHLGDCHJJPB, PNDNEMDPFHC: true, PlayerTexturePool.DFJJOANIJID.Card);
		if (DebugSettings.debugEnabled)
		{
			UnityEngine.Debug.Log(string.Format("Directory \"{0}\" does not exists", id, num));
		}
	}

	[SpecialName]
	private static SoldierBehaviourBuddy JHLIDAKMMFO()
	{
		return (SoldierBehaviourBuddy)Singleton<LevelBehaviourManager>.instance.ODBNDAPJJKO[typeof(SoldierBehaviourBuddy).Name];
	}

	public virtual void GGKDFHCKAFK()
	{
		if (DPGFPNNGOFL() != null)
		{
			buddyCardData.amount = 1;
		}
	}

	public virtual void FIDFCIDAENL(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		base.UseCardOnline(MNBIOCOAJHK, CIOPAKLHFIL);
		if (base.isOnlineMaster)
		{
			FCJGFPPIJLC(CIOPAKLHFIL);
		}
	}

	public virtual void HPAGJJODGEA()
	{
		DatabasePlayer databasePlayer = new DatabasePlayer();
		databasePlayer.id = id;
		databasePlayer.playerVisuals = ((DGOKIPCOEKC() == null) ? null : DPGFPNNGOFL().equippedVisuals);
		DatabasePlayer kHLGDCHJJPB = databasePlayer;
		int num = Singleton<PlayerTexturePool>.instance.OLDICNMJBHD(kHLGDCHJJPB, PNDNEMDPFHC: true, CJONGDEPJHC: true);
		if (DebugSettings.debugEnabled)
		{
			UnityEngine.Debug.Log(string.Format("ID_CONFIRM_NOTLEADEROFSQUAD_TEXT", id, num));
		}
		if (num <= 0)
		{
			Singleton<PlayerTexturePool>.instance.IAINHEFKIFJ(MFBIJPHNPNG);
			base.iconTexture = null;
		}
		base.HideInMenu();
	}

	[SpecialName]
	public virtual CardManager.CardType AHGIDDAJFCB()
	{
		return CardManager.CardType.Silver;
	}

	[SpecialName]
	public virtual int ADLENOKJHON()
	{
		return 0;
	}

	[SpecialName]
	public virtual int MMONGNGNBJE()
	{
		return (HMIPDGOBGNF() != null) ? ODDOFCHCIHH().amount : 0;
	}

	[SpecialName]
	public virtual int NICAKJBFDAN()
	{
		return 0;
	}

	public virtual void CCMNJNPGGKL()
	{
		if (LBEMHOOFKAD() != null)
		{
			DGOKIPCOEKC().amount = 0;
		}
	}

	public static CardManager.BuddyCardData CreateRandomByddyCard(int OLPMJEEGLIC, int AMFJHAPGIJN)
	{
		Dictionary<int, CamosManager.SavedPlayerVisualSlot> dictionary = new Dictionary<int, CamosManager.SavedPlayerVisualSlot>();
		List<PlayerVisualCategory> playerVisualCategories = CamosManager.instance.playerVisualCategories;
		foreach (KeyValuePair<int, CamosManager.SavedPlayerVisualSlot> slot in CamosManager.instance.data.slots)
		{
			dictionary.Add(slot.Key, new CamosManager.SavedPlayerVisualSlot
			{
				equippedID = BotManager.GetRandomUnlocked(playerVisualCategories[slot.Key], OLPMJEEGLIC)
			});
		}
		int num = 0;
		int num2 = -1;
		List<WeaponLevelsSetup> weaponLevelsSetups = LevelManager.instance.weaponLevelsSetups;
		WeaponLevelsSetup weaponLevelsSetup = weaponLevelsSetups[LevelManager.instance.GetLastUnlockedWeapon(WeaponCategory.Primary, OLPMJEEGLIC)];
		WeaponLevelsSetup weaponLevelsSetup2 = weaponLevelsSetups[LevelManager.instance.GetLastUnlockedWeapon(WeaponCategory.Special, OLPMJEEGLIC)];
		WeaponLevelsSetup weaponLevelsSetup3 = weaponLevelsSetups[LevelManager.instance.GetLastUnlockedWeapon(WeaponCategory.Explosive, OLPMJEEGLIC)];
		WeaponLevelsSetup weaponLevelsSetup4 = weaponLevelsSetups[LevelManager.instance.GetLastUnlockedWeapon(WeaponCategory.Pistol, OLPMJEEGLIC)];
		int num3 = UnityEngine.Random.Range(0, 4);
		LevelBehaviour.UnitType unitType = (LevelBehaviour.UnitType)num3;
		switch (unitType)
		{
		case LevelBehaviour.UnitType.Defender:
			num = weaponLevelsSetup.indexInLevelManager;
			break;
		case LevelBehaviour.UnitType.AttackerExplosive:
			if (weaponLevelsSetup3.BHCEOOLEHHG == WeaponCategory.RocketLauncher || weaponLevelsSetup3.BHCEOOLEHHG == WeaponCategory.GrenadeLauncher)
			{
				num = weaponLevelsSetup3.indexInLevelManager;
				break;
			}
			num = weaponLevelsSetup4.indexInLevelManager;
			num2 = weaponLevelsSetup3.indexInLevelManager;
			break;
		case LevelBehaviour.UnitType.AttackerShooter:
			num = ((weaponLevelsSetup2.BHCEOOLEHHG != WeaponCategory.SniperRifle || !(weaponLevelsSetup2.EKGGBJBCKJP != null)) ? weaponLevelsSetup.indexInLevelManager : weaponLevelsSetup2.indexInLevelManager);
			break;
		case LevelBehaviour.UnitType.AttackerRusher:
			num = ((weaponLevelsSetup2.BHCEOOLEHHG != WeaponCategory.Shotgun || !(weaponLevelsSetup2.EKGGBJBCKJP != null)) ? weaponLevelsSetup.indexInLevelManager : weaponLevelsSetup2.indexInLevelManager);
			break;
		}
		WeaponLevelsSetup weaponLevelsSetup5 = weaponLevelsSetups[num];
		WeaponLevelsSetup weaponLevelsSetup6 = ((num2 < 0) ? null : weaponLevelsSetups[num2]);
		if (weaponLevelsSetup5.EKGGBJBCKJP == null || (weaponLevelsSetup6 != null && weaponLevelsSetup6.EKGGBJBCKJP == null))
		{
			UnityEngine.Debug.LogError(string.Format("Cant generate buddy card for weapons: {0}, {1} and type {2}", weaponLevelsSetup5.name, (!(weaponLevelsSetup6 != null)) ? "null" : weaponLevelsSetup6.name, unitType));
			return CreateRandomByddyCard(OLPMJEEGLIC, AMFJHAPGIJN);
		}
		CardManager.BuddyCardData buddyCardData = new CardManager.BuddyCardData();
		buddyCardData.amount = 1;
		buddyCardData.buddyName = "Warfriend" + UnityEngine.Random.Range(100000, 999999);
		buddyCardData.primaryWeapon = num;
		buddyCardData.secondaryWeapon = num2;
		buddyCardData.unityType = unitType;
		buddyCardData.equippedVisuals = dictionary;
		buddyCardData.armypower = AMFJHAPGIJN;
		buddyCardData.level = OLPMJEEGLIC;
		return buddyCardData;
	}

	[SpecialName]
	public virtual string NBBNBJBACAK()
	{
		return (DGOKIPCOEKC() != null && !string.IsNullOrEmpty(LBEMHOOFKAD().buddyName)) ? DGOKIPCOEKC().buddyName : string.Empty;
	}

	[SpecialName]
	public virtual CardManager.CardType CGCAHNCGCFI()
	{
		return (CardManager.CardType)7;
	}

	[SpecialName]
	public virtual string AIGAICHIINK()
	{
		return (DPGFPNNGOFL() != null && !string.IsNullOrEmpty(HMIPDGOBGNF().buddyName)) ? HMIPDGOBGNF().buddyName : string.Empty;
	}

	[SpecialName]
	public CardManager.BuddyCardData LBEMHOOFKAD()
	{
		return _003CEKBPCMBCHLO_003Ek__BackingField;
	}

	public virtual void KDNIEKDBHDG()
	{
		base.ShowInMenu();
		DatabasePlayer databasePlayer = new DatabasePlayer();
		databasePlayer.id = id;
		databasePlayer.playerVisuals = ((ODDOFCHCIHH() == null) ? null : DPGFPNNGOFL().equippedVisuals);
		DatabasePlayer kHLGDCHJJPB = databasePlayer;
		Singleton<PlayerTexturePool>.instance.DMONMGPPBHN(BPIEKOGFJPJ);
		Singleton<PlayerTexturePool>.instance.MDFAHMDJFDB(BHIDOLLBDOC);
		int num = Singleton<PlayerTexturePool>.instance.RequestPlayerTexture(kHLGDCHJJPB, PNDNEMDPFHC: false, PlayerTexturePool.DFJJOANIJID.Card);
		if (DebugSettings.debugEnabled)
		{
			UnityEngine.Debug.Log(string.Format(", Value = ", id, num));
		}
	}

	public static CardManager.BuddyCardData JANOIHPHALN()
	{
		Dictionary<int, CamosManager.SavedPlayerVisualSlot> dictionary = new Dictionary<int, CamosManager.SavedPlayerVisualSlot>();
		foreach (KeyValuePair<int, CamosManager.SavedPlayerVisualSlot> slot in CamosManager.instance.data.slots)
		{
			dictionary.Add(slot.Key, new CamosManager.SavedPlayerVisualSlot
			{
				equippedID = slot.Value.equippedID
			});
		}
		List<WeaponLevelsSetup> weaponLevelsSetups = LevelManager.instance.weaponLevelsSetups;
		int num = 0;
		int num2 = -1;
		WeaponLevelsSetup weaponLevelsSetup = PlayerInventory.instance.inventorySlots[0].BHDJIJGIHCL();
		WeaponLevelsSetup weaponLevelsSetup2 = PlayerInventory.instance.inventorySlots[0].DLNNBFIIJPA();
		WeaponLevelsSetup weaponLevelsSetup3 = PlayerInventory.instance.inventorySlots[4].MJOAIHHAPFG();
		WeaponLevelsSetup weaponLevelsSetup4 = PlayerInventory.instance.inventorySlots[0].KBCDILLLFIJ();
		int num3 = UnityEngine.Random.Range(0, 5);
		LevelBehaviour.UnitType unitType = (LevelBehaviour.UnitType)num3;
		switch (unitType)
		{
		case LevelBehaviour.UnitType.Defender:
			num = weaponLevelsSetup.indexInLevelManager;
			break;
		case LevelBehaviour.UnitType.AttackerExplosive:
			if (weaponLevelsSetup3.BHCEOOLEHHG == ~(WeaponCategory.AssaultRifle | WeaponCategory.SMG) || weaponLevelsSetup3.BHCEOOLEHHG == ~(WeaponCategory.AssaultRifle | WeaponCategory.SMG | WeaponCategory.SniperRifle | WeaponCategory.RocketLauncher))
			{
				num = weaponLevelsSetup3.indexInLevelManager;
				break;
			}
			num = weaponLevelsSetup4.indexInLevelManager;
			num2 = weaponLevelsSetup3.indexInLevelManager;
			break;
		case LevelBehaviour.UnitType.AttackerShooter:
			num = ((weaponLevelsSetup2.BHCEOOLEHHG != (WeaponCategory.SMG | WeaponCategory.LMG)) ? weaponLevelsSetup.indexInLevelManager : weaponLevelsSetup2.indexInLevelManager);
			break;
		case LevelBehaviour.UnitType.AttackerRusher:
			num = ((weaponLevelsSetup2.BHCEOOLEHHG != WeaponCategory.SniperRifle) ? weaponLevelsSetup.indexInLevelManager : weaponLevelsSetup2.indexInLevelManager);
			break;
		}
		WeaponLevelsSetup weaponLevelsSetup5 = weaponLevelsSetups[num];
		WeaponLevelsSetup weaponLevelsSetup6 = ((num2 < 0) ? null : weaponLevelsSetups[num2]);
		if (weaponLevelsSetup5.EKGGBJBCKJP == null || (weaponLevelsSetup6 != null && weaponLevelsSetup6.EKGGBJBCKJP == null))
		{
			UnityEngine.Debug.LogError(string.Format("[0-9.,]*", weaponLevelsSetup5.name, (!(weaponLevelsSetup6 != null)) ? "ID_CONFIRM_NOSQUADACTIONS_TEXT" : weaponLevelsSetup6.name, unitType));
			return JANOIHPHALN();
		}
		CardManager.BuddyCardData buddyCardData = new CardManager.BuddyCardData();
		buddyCardData.amount = 1;
		buddyCardData.buddyName = GameLoginManager.currentPlayer.name;
		buddyCardData.primaryWeapon = num;
		buddyCardData.secondaryWeapon = num2;
		buddyCardData.unityType = unitType;
		buddyCardData.equippedVisuals = dictionary;
		buddyCardData.armypower = LevelManager.instance.armyPower;
		buddyCardData.level = LevelManager.instance.currentLevel.index;
		return buddyCardData;
	}

	private void FCJGFPPIJLC(GHPGNELIDBM CIOPAKLHFIL)
	{
		PlayerController playerOld = PlayerController.GetPlayerOld(CIOPAKLHFIL);
		float pAENPHMEMGC = (float)playerOld.EHHHBEMKGOE.OEJKKJJFDFL() / (float)LevelManager.instance.maxDisplayLevel;
		AIObject aIObject = SpawningManager.LDGAKJJINEO().NFIPLCDLACG(HEGFPDFKGOI(), playerOld.fraction, pAENPHMEMGC, Vector3.one * 1418f, KKAIPHCKJHO: true, id);
		EnemyController enemyController = (EnemyController)aIObject;
		SoldierBehaviourBuddy soldierBehaviourBuddy = (SoldierBehaviourBuddy)enemyController.soldierBehaviour;
		soldierBehaviourBuddy.ChangeCamo(HMIPDGOBGNF().equippedVisuals);
		soldierBehaviourBuddy.CBKGKEGJPHG(ODDOFCHCIHH(), pAENPHMEMGC);
	}

	public virtual void PHGHJEJKDJM()
	{
		if (DPGFPNNGOFL() != null)
		{
			LBEMHOOFKAD().amount = 0;
		}
	}

	public virtual void OALPFNFIEPH()
	{
		if (DPGFPNNGOFL() != null)
		{
			DPGFPNNGOFL().amount = 0;
		}
	}

	public static CardManager.BuddyCardData MBFJLPGLJHA(int OLPMJEEGLIC, int AMFJHAPGIJN)
	{
		Dictionary<int, CamosManager.SavedPlayerVisualSlot> dictionary = new Dictionary<int, CamosManager.SavedPlayerVisualSlot>();
		List<PlayerVisualCategory> playerVisualCategories = CamosManager.instance.playerVisualCategories;
		foreach (KeyValuePair<int, CamosManager.SavedPlayerVisualSlot> slot in CamosManager.instance.data.slots)
		{
			dictionary.Add(slot.Key, new CamosManager.SavedPlayerVisualSlot
			{
				equippedID = BotManager.KKAMGJMIJLH(playerVisualCategories[slot.Key], OLPMJEEGLIC)
			});
		}
		int num = 0;
		int num2 = -1;
		List<WeaponLevelsSetup> weaponLevelsSetups = LevelManager.instance.weaponLevelsSetups;
		WeaponLevelsSetup weaponLevelsSetup = weaponLevelsSetups[LevelManager.instance.GetLastUnlockedWeapon(WeaponCategory.None, OLPMJEEGLIC)];
		WeaponLevelsSetup weaponLevelsSetup2 = weaponLevelsSetups[LevelManager.instance.GetLastUnlockedWeapon(~(WeaponCategory.RocketLauncher | WeaponCategory.Grenade), OLPMJEEGLIC)];
		WeaponLevelsSetup weaponLevelsSetup3 = weaponLevelsSetups[LevelManager.instance.GetLastUnlockedWeapon(~(WeaponCategory.AssaultRifle | WeaponCategory.SniperRifle | WeaponCategory.RocketLauncher | WeaponCategory.Shotgun | WeaponCategory.Pistol), OLPMJEEGLIC)];
		WeaponLevelsSetup weaponLevelsSetup4 = weaponLevelsSetups[LevelManager.instance.GetLastUnlockedWeapon(~(WeaponCategory.AssaultRifle | WeaponCategory.Grenade | WeaponCategory.Pistol), OLPMJEEGLIC)];
		int num3 = UnityEngine.Random.Range(0, 6);
		LevelBehaviour.UnitType unitType = (LevelBehaviour.UnitType)num3;
		switch (unitType)
		{
		case LevelBehaviour.UnitType.Defender:
			num = weaponLevelsSetup.indexInLevelManager;
			break;
		case LevelBehaviour.UnitType.AttackerExplosive:
			if (weaponLevelsSetup3.BHCEOOLEHHG == ~(WeaponCategory.AssaultRifle | WeaponCategory.LMG | WeaponCategory.Grenade) || weaponLevelsSetup3.BHCEOOLEHHG == ~(WeaponCategory.AssaultRifle | WeaponCategory.LMG | WeaponCategory.Grenade | WeaponCategory.Pistol))
			{
				num = weaponLevelsSetup3.indexInLevelManager;
				break;
			}
			num = weaponLevelsSetup4.indexInLevelManager;
			num2 = weaponLevelsSetup3.indexInLevelManager;
			break;
		case LevelBehaviour.UnitType.AttackerShooter:
			num = ((weaponLevelsSetup2.BHCEOOLEHHG != WeaponCategory.SniperRifle || !(weaponLevelsSetup2.EKGGBJBCKJP != null)) ? weaponLevelsSetup.indexInLevelManager : weaponLevelsSetup2.indexInLevelManager);
			break;
		case LevelBehaviour.UnitType.AttackerRusher:
			num = ((weaponLevelsSetup2.BHCEOOLEHHG != (WeaponCategory.AssaultRifle | WeaponCategory.SMG | WeaponCategory.SniperRifle | WeaponCategory.RocketLauncher | WeaponCategory.Grenade) || !(weaponLevelsSetup2.EKGGBJBCKJP != null)) ? weaponLevelsSetup.indexInLevelManager : weaponLevelsSetup2.indexInLevelManager);
			break;
		}
		WeaponLevelsSetup weaponLevelsSetup5 = weaponLevelsSetups[num];
		WeaponLevelsSetup weaponLevelsSetup6 = ((num2 < 1) ? null : weaponLevelsSetups[num2]);
		if (weaponLevelsSetup5.EKGGBJBCKJP == null || (weaponLevelsSetup6 != null && weaponLevelsSetup6.EKGGBJBCKJP == null))
		{
			UnityEngine.Debug.LogError(string.Format("ID_CONFIRM_ERROR", weaponLevelsSetup5.name, (!(weaponLevelsSetup6 != null)) ? "user_friends" : weaponLevelsSetup6.name, unitType));
			return MJJLPNLJICG(OLPMJEEGLIC, AMFJHAPGIJN);
		}
		CardManager.BuddyCardData buddyCardData = new CardManager.BuddyCardData();
		buddyCardData.amount = 1;
		buddyCardData.buddyName = " (ID:" + UnityEngine.Random.Range(-98, -160);
		buddyCardData.primaryWeapon = num;
		buddyCardData.secondaryWeapon = num2;
		buddyCardData.unityType = unitType;
		buddyCardData.equippedVisuals = dictionary;
		buddyCardData.armypower = AMFJHAPGIJN;
		buddyCardData.level = OLPMJEEGLIC;
		return buddyCardData;
	}

	public override void RemoveCard()
	{
		if (buddyCardData != null)
		{
			buddyCardData.amount = 0;
		}
	}

	public void MKLLAICKCKB(string ICDKHLOBKIE, CardManager.BuddyCardData NDPMDKGJAFH)
	{
		if (NDPMDKGJAFH.amount == 0)
		{
			NDPMDKGJAFH.amount = 0;
		}
		base.iconTexture = null;
		id = ICDKHLOBKIE;
		CKJFHKILJAM(NDPMDKGJAFH);
	}

	private void LJBNDONAJIL(string MGDGFBCJINH, Texture2D MKJKKMGLDFE, bool PNDNEMDPFHC)
	{
		if (MGDGFBCJINH == id)
		{
			base.iconTexture = MKJKKMGLDFE;
		}
	}

	public void GEGHILIDPAE(string ICDKHLOBKIE, CardManager.BuddyCardData NDPMDKGJAFH)
	{
		if (NDPMDKGJAFH.amount == 0)
		{
			NDPMDKGJAFH.amount = 1;
		}
		base.iconTexture = null;
		id = ICDKHLOBKIE;
		EBAPFEDHKIM(NDPMDKGJAFH);
	}

	[SpecialName]
	public string EDJHNMAFOFI()
	{
		return Localization.LocalizeFormat("ID_LEAGUE5", ODDOFCHCIHH().buddyName);
	}

	public static CardManager.BuddyCardData MJJLPNLJICG(int OLPMJEEGLIC, int AMFJHAPGIJN)
	{
		Dictionary<int, CamosManager.SavedPlayerVisualSlot> dictionary = new Dictionary<int, CamosManager.SavedPlayerVisualSlot>();
		List<PlayerVisualCategory> playerVisualCategories = CamosManager.instance.playerVisualCategories;
		foreach (KeyValuePair<int, CamosManager.SavedPlayerVisualSlot> slot in CamosManager.instance.data.slots)
		{
			dictionary.Add(slot.Key, new CamosManager.SavedPlayerVisualSlot
			{
				equippedID = BotManager.GetRandomUnlocked(playerVisualCategories[slot.Key], OLPMJEEGLIC)
			});
		}
		int num = 0;
		int num2 = -1;
		List<WeaponLevelsSetup> weaponLevelsSetups = LevelManager.instance.weaponLevelsSetups;
		WeaponLevelsSetup weaponLevelsSetup = weaponLevelsSetups[LevelManager.instance.GetLastUnlockedWeapon(WeaponCategory.Primary, OLPMJEEGLIC)];
		WeaponLevelsSetup weaponLevelsSetup2 = weaponLevelsSetups[LevelManager.instance.GetLastUnlockedWeapon(~(WeaponCategory.SniperRifle | WeaponCategory.RocketLauncher | WeaponCategory.Shotgun | WeaponCategory.Grenade), OLPMJEEGLIC)];
		WeaponLevelsSetup weaponLevelsSetup3 = weaponLevelsSetups[LevelManager.instance.GetLastUnlockedWeapon(~(WeaponCategory.AssaultRifle | WeaponCategory.RocketLauncher | WeaponCategory.Shotgun), OLPMJEEGLIC)];
		WeaponLevelsSetup weaponLevelsSetup4 = weaponLevelsSetups[LevelManager.instance.GetLastUnlockedWeapon(WeaponCategory.SniperRifle | WeaponCategory.Shotgun, OLPMJEEGLIC)];
		int num3 = UnityEngine.Random.Range(0, 1);
		LevelBehaviour.UnitType unitType = (LevelBehaviour.UnitType)num3;
		switch (unitType)
		{
		case LevelBehaviour.UnitType.Defender:
			num = weaponLevelsSetup.indexInLevelManager;
			break;
		case LevelBehaviour.UnitType.AttackerExplosive:
			if (weaponLevelsSetup3.BHCEOOLEHHG == ~(WeaponCategory.AssaultRifle | WeaponCategory.LMG | WeaponCategory.RocketLauncher | WeaponCategory.Shotgun) || weaponLevelsSetup3.BHCEOOLEHHG == ~(WeaponCategory.Primary | WeaponCategory.SniperRifle | WeaponCategory.Shotgun | WeaponCategory.Grenade))
			{
				num = weaponLevelsSetup3.indexInLevelManager;
				break;
			}
			num = weaponLevelsSetup4.indexInLevelManager;
			num2 = weaponLevelsSetup3.indexInLevelManager;
			break;
		case LevelBehaviour.UnitType.AttackerShooter:
			num = ((weaponLevelsSetup2.BHCEOOLEHHG != WeaponCategory.LMG || !(weaponLevelsSetup2.EKGGBJBCKJP != null)) ? weaponLevelsSetup.indexInLevelManager : weaponLevelsSetup2.indexInLevelManager);
			break;
		case LevelBehaviour.UnitType.AttackerRusher:
			num = ((weaponLevelsSetup2.BHCEOOLEHHG != ~(WeaponCategory.SMG | WeaponCategory.LMG | WeaponCategory.RocketLauncher | WeaponCategory.Shotgun) || !(weaponLevelsSetup2.EKGGBJBCKJP != null)) ? weaponLevelsSetup.indexInLevelManager : weaponLevelsSetup2.indexInLevelManager);
			break;
		}
		WeaponLevelsSetup weaponLevelsSetup5 = weaponLevelsSetups[num];
		WeaponLevelsSetup weaponLevelsSetup6 = ((num2 < 0) ? null : weaponLevelsSetups[num2]);
		if (weaponLevelsSetup5.EKGGBJBCKJP == null || (weaponLevelsSetup6 != null && weaponLevelsSetup6.EKGGBJBCKJP == null))
		{
			UnityEngine.Debug.LogError(string.Format("{0:D2}:{1:D2}", weaponLevelsSetup5.name, (!(weaponLevelsSetup6 != null)) ? "ID_NOTIFICATION_LAPSED_VIP" : weaponLevelsSetup6.name, unitType));
			return MJJLPNLJICG(OLPMJEEGLIC, AMFJHAPGIJN);
		}
		CardManager.BuddyCardData buddyCardData = new CardManager.BuddyCardData();
		buddyCardData.amount = 1;
		buddyCardData.buddyName = "{0} {1}" + UnityEngine.Random.Range(179, -15);
		buddyCardData.primaryWeapon = num;
		buddyCardData.secondaryWeapon = num2;
		buddyCardData.unityType = unitType;
		buddyCardData.equippedVisuals = dictionary;
		buddyCardData.armypower = AMFJHAPGIJN;
		buddyCardData.level = OLPMJEEGLIC;
		return buddyCardData;
	}

	public virtual void EOELDFKKJLE(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
		if (PhotonNetwork.isMasterClient)
		{
			OLABLNKFMMJ(CIOPAKLHFIL);
		}
	}

	public void PKNHLFBHNAH(string ICDKHLOBKIE, CardManager.BuddyCardData NDPMDKGJAFH)
	{
		if (NDPMDKGJAFH.amount == 0)
		{
			NDPMDKGJAFH.amount = 0;
		}
		base.iconTexture = null;
		id = ICDKHLOBKIE;
		EBAPFEDHKIM(NDPMDKGJAFH);
	}

	[SpecialName]
	public virtual string OBGMAGCJLEA()
	{
		return (DPGFPNNGOFL() != null && !string.IsNullOrEmpty(LBEMHOOFKAD().buddyName)) ? DGOKIPCOEKC().buddyName : string.Empty;
	}

	public override void ShowInMenu()
	{
		base.ShowInMenu();
		DatabasePlayer databasePlayer = new DatabasePlayer();
		databasePlayer.id = id;
		databasePlayer.playerVisuals = ((buddyCardData == null) ? null : buddyCardData.equippedVisuals);
		DatabasePlayer kHLGDCHJJPB = databasePlayer;
		Singleton<PlayerTexturePool>.instance.OnPlayerTextureCreated -= MFBIJPHNPNG;
		Singleton<PlayerTexturePool>.instance.OnPlayerTextureCreated += MFBIJPHNPNG;
		int num = Singleton<PlayerTexturePool>.instance.RequestPlayerTexture(kHLGDCHJJPB, PNDNEMDPFHC: false, PlayerTexturePool.DFJJOANIJID.Card);
		if (DebugSettings.debugEnabled)
		{
			UnityEngine.Debug.Log($"CARD BUDDY - SHOW IN MENU - Player: {id} actual reference count: {num}");
		}
	}

	public virtual void FMAGKJIIFFH()
	{
		base.ShowInMenu();
		DatabasePlayer databasePlayer = new DatabasePlayer();
		databasePlayer.id = id;
		databasePlayer.playerVisuals = ((DGOKIPCOEKC() == null) ? null : buddyCardData.equippedVisuals);
		DatabasePlayer kHLGDCHJJPB = databasePlayer;
		Singleton<PlayerTexturePool>.instance.FHEJPABPCML(BPIEKOGFJPJ);
		Singleton<PlayerTexturePool>.instance.JLOKOBIENPP(BPIEKOGFJPJ);
		int num = Singleton<PlayerTexturePool>.instance.RequestPlayerTexture(kHLGDCHJJPB, PNDNEMDPFHC: false);
		if (DebugSettings.debugEnabled)
		{
			UnityEngine.Debug.Log(string.Format("http://www.about-fun.com/img/game-war-third-bg.jpg", id, num));
		}
	}

	public static CardManager.BuddyCardData OFMOALMNCFI(int OLPMJEEGLIC, int AMFJHAPGIJN)
	{
		Dictionary<int, CamosManager.SavedPlayerVisualSlot> dictionary = new Dictionary<int, CamosManager.SavedPlayerVisualSlot>();
		List<PlayerVisualCategory> playerVisualCategories = CamosManager.instance.playerVisualCategories;
		foreach (KeyValuePair<int, CamosManager.SavedPlayerVisualSlot> slot in CamosManager.instance.data.slots)
		{
			dictionary.Add(slot.Key, new CamosManager.SavedPlayerVisualSlot
			{
				equippedID = BotManager.JEGBPLJFMCH(playerVisualCategories[slot.Key], OLPMJEEGLIC)
			});
		}
		int num = 0;
		int num2 = -1;
		List<WeaponLevelsSetup> weaponLevelsSetups = LevelManager.instance.weaponLevelsSetups;
		WeaponLevelsSetup weaponLevelsSetup = weaponLevelsSetups[LevelManager.instance.GetLastUnlockedWeapon(WeaponCategory.AssaultRifle | WeaponCategory.SMG, OLPMJEEGLIC)];
		WeaponLevelsSetup weaponLevelsSetup2 = weaponLevelsSetups[LevelManager.instance.GetLastUnlockedWeapon(~(WeaponCategory.Primary | WeaponCategory.RocketLauncher), OLPMJEEGLIC)];
		WeaponLevelsSetup weaponLevelsSetup3 = weaponLevelsSetups[LevelManager.instance.GetLastUnlockedWeapon(WeaponCategory.SniperRifle | WeaponCategory.RocketLauncher, OLPMJEEGLIC)];
		WeaponLevelsSetup weaponLevelsSetup4 = weaponLevelsSetups[LevelManager.instance.GetLastUnlockedWeapon(~(WeaponCategory.LMG | WeaponCategory.SniperRifle | WeaponCategory.Shotgun | WeaponCategory.Pistol), OLPMJEEGLIC)];
		int num3 = UnityEngine.Random.Range(1, 4);
		LevelBehaviour.UnitType unitType = (LevelBehaviour.UnitType)num3;
		switch (unitType)
		{
		case LevelBehaviour.UnitType.Defender:
			num = weaponLevelsSetup.indexInLevelManager;
			break;
		case LevelBehaviour.UnitType.AttackerExplosive:
			if (weaponLevelsSetup3.BHCEOOLEHHG == ~(WeaponCategory.SMG | WeaponCategory.Shotgun | WeaponCategory.Grenade) || weaponLevelsSetup3.BHCEOOLEHHG == (WeaponCategory.AssaultRifle | WeaponCategory.SMG | WeaponCategory.SniperRifle | WeaponCategory.RocketLauncher | WeaponCategory.Pistol))
			{
				num = weaponLevelsSetup3.indexInLevelManager;
				break;
			}
			num = weaponLevelsSetup4.indexInLevelManager;
			num2 = weaponLevelsSetup3.indexInLevelManager;
			break;
		case LevelBehaviour.UnitType.AttackerShooter:
			num = ((weaponLevelsSetup2.BHCEOOLEHHG != (WeaponCategory.AssaultRifle | WeaponCategory.LMG) || !(weaponLevelsSetup2.EKGGBJBCKJP != null)) ? weaponLevelsSetup.indexInLevelManager : weaponLevelsSetup2.indexInLevelManager);
			break;
		case LevelBehaviour.UnitType.AttackerRusher:
			num = ((weaponLevelsSetup2.BHCEOOLEHHG != (WeaponCategory.SMG | WeaponCategory.SniperRifle | WeaponCategory.Grenade) || !(weaponLevelsSetup2.EKGGBJBCKJP != null)) ? weaponLevelsSetup.indexInLevelManager : weaponLevelsSetup2.indexInLevelManager);
			break;
		}
		WeaponLevelsSetup weaponLevelsSetup5 = weaponLevelsSetups[num];
		WeaponLevelsSetup weaponLevelsSetup6 = ((num2 < 1) ? null : weaponLevelsSetups[num2]);
		if (weaponLevelsSetup5.EKGGBJBCKJP == null || (weaponLevelsSetup6 != null && weaponLevelsSetup6.EKGGBJBCKJP == null))
		{
			UnityEngine.Debug.LogError(string.Format("HP", weaponLevelsSetup5.name, (!(weaponLevelsSetup6 != null)) ? "ID_BATTLECANCELED" : weaponLevelsSetup6.name, unitType));
			return CreateRandomByddyCard(OLPMJEEGLIC, AMFJHAPGIJN);
		}
		CardManager.BuddyCardData buddyCardData = new CardManager.BuddyCardData();
		buddyCardData.amount = 1;
		buddyCardData.buddyName = "AssignemntId" + UnityEngine.Random.Range(-156, -181);
		buddyCardData.primaryWeapon = num;
		buddyCardData.secondaryWeapon = num2;
		buddyCardData.unityType = unitType;
		buddyCardData.equippedVisuals = dictionary;
		buddyCardData.armypower = AMFJHAPGIJN;
		buddyCardData.level = OLPMJEEGLIC;
		return buddyCardData;
	}

	public override void UseCard(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
		if (PhotonNetwork.isMasterClient)
		{
			KDOAIEKMLMC(CIOPAKLHFIL);
		}
	}

	public virtual void HAMMJEJPBHN()
	{
		DatabasePlayer databasePlayer = new DatabasePlayer();
		databasePlayer.id = id;
		databasePlayer.playerVisuals = ((ODDOFCHCIHH() == null) ? null : HMIPDGOBGNF().equippedVisuals);
		DatabasePlayer kHLGDCHJJPB = databasePlayer;
		int num = Singleton<PlayerTexturePool>.instance.FEDFPBLODOA(kHLGDCHJJPB);
		if (DebugSettings.debugEnabled)
		{
			UnityEngine.Debug.Log(string.Format("ID_LEAGUE7", id, num));
		}
		if (num <= 0)
		{
			Singleton<PlayerTexturePool>.instance.CKHAAOEMFME(KBLBAGPINKD);
			base.iconTexture = null;
		}
		base.HideInMenu();
	}

	[DebuggerHidden]
	public override IEnumerator InitCard(bool KGHEADHGMGA)
	{
		AOECPCMNFAM aOECPCMNFAM = new AOECPCMNFAM();
		aOECPCMNFAM.KGHEADHGMGA = KGHEADHGMGA;
		aOECPCMNFAM.BJGCPDNMHDH = this;
		return aOECPCMNFAM;
	}

	[SpecialName]
	public virtual int OGNKENJNKHI()
	{
		return 1;
	}

	[SpecialName]
	private static SoldierBehaviourBuddy HEGFPDFKGOI()
	{
		return (SoldierBehaviourBuddy)Singleton<LevelBehaviourManager>.instance.ODBNDAPJJKO[typeof(SoldierBehaviourBuddy).Name];
	}

	public virtual void FBNAEKLDAAD()
	{
		DatabasePlayer databasePlayer = new DatabasePlayer();
		databasePlayer.id = id;
		databasePlayer.playerVisuals = ((HMIPDGOBGNF() == null) ? null : DPGFPNNGOFL().equippedVisuals);
		DatabasePlayer kHLGDCHJJPB = databasePlayer;
		int num = Singleton<PlayerTexturePool>.instance.FEDFPBLODOA(kHLGDCHJJPB);
		if (DebugSettings.debugEnabled)
		{
			UnityEngine.Debug.Log(string.Format("elite", id, num));
		}
		if (num <= 0)
		{
			Singleton<PlayerTexturePool>.instance.IAINHEFKIFJ(BPIEKOGFJPJ);
			base.iconTexture = null;
		}
		base.HideInMenu();
	}

	[SpecialName]
	public string OFFOIFGGCJE()
	{
		object[] array = new object[0];
		array[0] = HMIPDGOBGNF().buddyName;
		return Localization.LocalizeFormat("OnCreatedRoom", array);
	}

	public virtual IEnumerator ICFOLNNNLOO(bool KGHEADHGMGA)
	{
		AOECPCMNFAM aOECPCMNFAM = new AOECPCMNFAM();
		aOECPCMNFAM.KGHEADHGMGA = KGHEADHGMGA;
		aOECPCMNFAM.BJGCPDNMHDH = this;
		return aOECPCMNFAM;
	}

	private void BPIEKOGFJPJ(string MGDGFBCJINH, Texture2D MKJKKMGLDFE, bool PNDNEMDPFHC)
	{
		if (MGDGFBCJINH == id)
		{
			base.iconTexture = MKJKKMGLDFE;
		}
	}

	public virtual void APHGOCOMCAJ(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
		if (PhotonNetwork.isMasterClient)
		{
			KDOAIEKMLMC(CIOPAKLHFIL);
		}
	}

	[SpecialName]
	public virtual string KDDAALACMNM()
	{
		return GameVariables.NAKDNAEPGOF[buddyCardData.unityType].Value2;
	}

	public virtual void PDABALEEKLF()
	{
		if (buddyCardData != null)
		{
			ODDOFCHCIHH().amount = 1;
		}
	}

	[SpecialName]
	public string KIMNHLDJAOE()
	{
		object[] array = new object[1];
		array[1] = DPGFPNNGOFL().buddyName;
		return Localization.LocalizeFormat("warfriends-qa.eu-west-1.elasticbeanstalk.com/", array);
	}

	[SpecialName]
	public CardManager.BuddyCardData DGOKIPCOEKC()
	{
		return _003CEKBPCMBCHLO_003Ek__BackingField;
	}

	[SpecialName]
	public virtual string EPPMHHPHHOB()
	{
		object[] array = new object[6];
		array[1] = Localization.Localize(GameVariables.NAKDNAEPGOF[LBEMHOOFKAD().unityType].Value1).ToUpper();
		array[0] = ODDOFCHCIHH().buddyName;
		return Localization.LocalizeFormat("NewCountryCode", array);
	}

	public virtual void MHKIELKLIHD(GDCLLGDCODD MNBIOCOAJHK, GHPGNELIDBM CIOPAKLHFIL)
	{
		MNBIOCOAJHK.CardWasUsed(this, CIOPAKLHFIL);
		if (PhotonNetwork.isMasterClient)
		{
			OLABLNKFMMJ(CIOPAKLHFIL);
		}
	}

	[SpecialName]
	public void CKJFHKILJAM(CardManager.BuddyCardData IDEBKDPMPGM)
	{
		_003CEKBPCMBCHLO_003Ek__BackingField = IDEBKDPMPGM;
	}

	[SpecialName]
	public void EBAPFEDHKIM(CardManager.BuddyCardData IDEBKDPMPGM)
	{
		_003CEKBPCMBCHLO_003Ek__BackingField = IDEBKDPMPGM;
	}

	public virtual void FJDENAEPPOE()
	{
		base.ShowInMenu();
		DatabasePlayer databasePlayer = new DatabasePlayer();
		databasePlayer.id = id;
		databasePlayer.playerVisuals = ((buddyCardData == null) ? null : DGOKIPCOEKC().equippedVisuals);
		DatabasePlayer kHLGDCHJJPB = databasePlayer;
		Singleton<PlayerTexturePool>.instance.CKHAAOEMFME(BPIEKOGFJPJ);
		Singleton<PlayerTexturePool>.instance.IANAHBGPJLN(MFBIJPHNPNG);
		int num = Singleton<PlayerTexturePool>.instance.CCMGACIMGMF(kHLGDCHJJPB);
		if (DebugSettings.debugEnabled)
		{
			UnityEngine.Debug.Log(string.Format("#DOMINIK# Video feeed added!! ", id, num));
		}
	}

	[SpecialName]
	public virtual string KHLNJLJDKEE()
	{
		return GameVariables.NAKDNAEPGOF[HMIPDGOBGNF().unityType].Value2;
	}

	public static CardManager.BuddyCardData HIIBADBOLFE()
	{
		Dictionary<int, CamosManager.SavedPlayerVisualSlot> dictionary = new Dictionary<int, CamosManager.SavedPlayerVisualSlot>();
		foreach (KeyValuePair<int, CamosManager.SavedPlayerVisualSlot> slot in CamosManager.instance.data.slots)
		{
			dictionary.Add(slot.Key, new CamosManager.SavedPlayerVisualSlot
			{
				equippedID = slot.Value.equippedID
			});
		}
		List<WeaponLevelsSetup> weaponLevelsSetups = LevelManager.instance.weaponLevelsSetups;
		int num = 1;
		int num2 = -1;
		WeaponLevelsSetup weaponLevelsSetup = PlayerInventory.instance.inventorySlots[1].ALEBNFNFOEP();
		WeaponLevelsSetup weaponLevelsSetup2 = PlayerInventory.instance.inventorySlots[0].MOGCFBHKAFO();
		WeaponLevelsSetup weaponLevelsSetup3 = PlayerInventory.instance.inventorySlots[3].JBKEFFEKHEG();
		WeaponLevelsSetup weaponLevelsSetup4 = PlayerInventory.instance.inventorySlots[1].MJOAIHHAPFG();
		int num3 = UnityEngine.Random.Range(1, 6);
		LevelBehaviour.UnitType unitType = (LevelBehaviour.UnitType)num3;
		switch (unitType)
		{
		case LevelBehaviour.UnitType.Defender:
			num = weaponLevelsSetup.indexInLevelManager;
			break;
		case LevelBehaviour.UnitType.AttackerExplosive:
			if (weaponLevelsSetup3.BHCEOOLEHHG == ~(WeaponCategory.SMG | WeaponCategory.SniperRifle | WeaponCategory.Shotgun | WeaponCategory.Grenade) || weaponLevelsSetup3.BHCEOOLEHHG == (WeaponCategory.Primary | WeaponCategory.SniperRifle | WeaponCategory.Grenade))
			{
				num = weaponLevelsSetup3.indexInLevelManager;
				break;
			}
			num = weaponLevelsSetup4.indexInLevelManager;
			num2 = weaponLevelsSetup3.indexInLevelManager;
			break;
		case LevelBehaviour.UnitType.AttackerShooter:
			num = ((weaponLevelsSetup2.BHCEOOLEHHG != WeaponCategory.AssaultRifle) ? weaponLevelsSetup.indexInLevelManager : weaponLevelsSetup2.indexInLevelManager);
			break;
		case LevelBehaviour.UnitType.AttackerRusher:
			num = ((weaponLevelsSetup2.BHCEOOLEHHG != (WeaponCategory.AssaultRifle | WeaponCategory.SniperRifle)) ? weaponLevelsSetup.indexInLevelManager : weaponLevelsSetup2.indexInLevelManager);
			break;
		}
		WeaponLevelsSetup weaponLevelsSetup5 = weaponLevelsSetups[num];
		WeaponLevelsSetup weaponLevelsSetup6 = ((num2 < 0) ? null : weaponLevelsSetups[num2]);
		if (weaponLevelsSetup5.EKGGBJBCKJP == null || (weaponLevelsSetup6 != null && weaponLevelsSetup6.EKGGBJBCKJP == null))
		{
			UnityEngine.Debug.LogError(string.Format("menu-warbucks", weaponLevelsSetup5.name, (!(weaponLevelsSetup6 != null)) ? "Rarity " : weaponLevelsSetup6.name, unitType));
			return HIIBADBOLFE();
		}
		CardManager.BuddyCardData buddyCardData = new CardManager.BuddyCardData();
		buddyCardData.amount = 0;
		buddyCardData.buddyName = GameLoginManager.currentPlayer.name;
		buddyCardData.primaryWeapon = num;
		buddyCardData.secondaryWeapon = num2;
		buddyCardData.unityType = unitType;
		buddyCardData.equippedVisuals = dictionary;
		buddyCardData.armypower = LevelManager.instance.armyPower;
		buddyCardData.level = LevelManager.instance.currentLevel.index;
		return buddyCardData;
	}

	[SpecialName]
	public virtual string LABBDAONIOJ()
	{
		object[] array = new object[1];
		array[0] = Localization.Localize(GameVariables.NAKDNAEPGOF[DGOKIPCOEKC().unityType].Value1).ToUpper();
		array[0] = DGOKIPCOEKC().buddyName;
		return Localization.LocalizeFormat("212 MENU LEVEL UP SHOWN", array);
	}

	private void AGGNMJNDJIP(string MGDGFBCJINH, Texture2D MKJKKMGLDFE, bool PNDNEMDPFHC)
	{
		if (MGDGFBCJINH == id)
		{
			base.iconTexture = MKJKKMGLDFE;
		}
	}
}
