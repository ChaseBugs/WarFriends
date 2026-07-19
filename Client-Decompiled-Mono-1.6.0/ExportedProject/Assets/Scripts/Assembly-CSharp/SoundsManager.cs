using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

[ExecuteInEditMode]
public class SoundsManager : InGameSerializedObjectGeneric<SoundsManager.SoundSettingsSerialized>
{
	public enum KJGDNLHKPOG
	{
		Button = 0,
		LabelShowGame = 1,
		SwitchWeapon_Primary = 2,
		DeplyUnits = 3,
		Ribbon = 4,
		Critical = 5,
		Buy = 6,
		Upgrade = 7,
		ActivateUpgrade = 8,
		CounterSoundExperience = 9,
		CardEquiped = 10,
		AssigmentCompleted = 11,
		AirStrikeJet = 12,
		CounterSoundMoney = 13,
		OpponentFound = 14,
		Overtime = 15,
		OvertimeAlarm = 16,
		SwitchWeapon_Secondary = 17,
		SwitchWeapon_Explosive = 18,
		SwitchWeapon_Pistol = 19,
		CardReturn = 20,
		AssigmentBarCompleted = 21,
		BootcampDialog = 22,
		BootcampObjectiveComplete = 23,
		BootcampCongratulations = 24,
		BootcampIntro = 25,
		BootcampEnemyPresent = 26,
		BootcampWoosh = 27,
		BootcampUnitPresent = 28,
		BootcampClick = 29,
		BootcampDialogDissapear = 30,
		AssignmentDayCompleted = 31,
		AssignmentMegaReward = 32,
		DogTagUsed = 33,
		LevelUp = 34,
		LevelUpUnlockedItem = 35,
		LeagueIconShowed = 36,
		LeagueRewardShowed = 37,
		EquipWeapon = 38,
		PromoteUnit = 39,
		BuyVIP = 40,
		CardFlip = 41,
		DailyRewardShow = 42,
		DailyRewardClaim = 43,
		DailyVIPCardsShow = 44,
		CoinPurchase = 45,
		KilledInAction = 46,
		FlashEndScreen = 47,
		StarGained = 48,
		CardPlayed = 49,
		EnemyCardPlayed = 50,
		OpponentSearch = 51,
		DogTagGain = 52,
		Fight = 53,
		GameOverWin = 54,
		GameOverLost = 55,
		CraftingStart = 56,
		CraftingClaim = 57,
		CountdownSound = 58,
		StartGameVsSound = 59,
		StartGamePhotoSound = 60,
		OpenLootbox = 61,
		OpenLootboxCompleted = 62,
		OpenLootboxLegendary = 63,
		MissionNewWave = 64,
		MissionWaveCompleted = 65,
		MissionCountdownSound = 66,
		MissionCompleted = 67
	}

	[Serializable]
	public class SoundEntry2D : SoundEntry
	{
		[SerializeField]
		public KJGDNLHKPOG soundEnum;
	}

	public class SoundSettingsSerialized
	{
		public float musicVolume;

		public float soundVolume;

		public SoundSettingsSerialized()
		{
			soundVolume = 1f;
			musicVolume = 1f;
		}
	}

	private sealed class BJNCMCLNONK : IEnumerator, IDisposable, IEnumerator<object>
	{
		internal SoundsManager BJGCPDNMHDH;

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
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 1u:
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 2;
				}
				break;
			case 2u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.LoadMusic(BJGCPDNMHDH.mMenuAssetBundle));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 3;
				}
				break;
			case 3u:
				if (BJGCPDNMHDH.data.musicVolume > 0.05f)
				{
					BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.DoFadeIn(BJGCPDNMHDH.musicMenu, 2f, 0.7f));
				}
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return false;
			}
			return true;
		}

		[SpecialName]
		private object CLFFFNGBPGJ()
		{
			return PHDOCKCBJOF;
		}

		public bool NJBCJDFKGHO()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
			case 1u:
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
			case 2u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.LoadMusic(BJGCPDNMHDH.mMenuAssetBundle));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
			case 3u:
				if (BJGCPDNMHDH.data.musicVolume > 324f)
				{
					BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.DoFadeIn(BJGCPDNMHDH.musicMenu, 1388f, 1655f));
				}
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return false;
			}
			return true;
		}

		[SpecialName]
		private object HMIFLGCBDCO()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object LFEJDKIGHMI()
		{
			return PHDOCKCBJOF;
		}

		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object BLOJDIFOPIA()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object BNFADGLHBAH()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object CLDLJNHAEAB()
		{
			return PHDOCKCBJOF;
		}

		[DebuggerHidden]
		public BJNCMCLNONK()
		{
		}

		public bool HDGDKCMIOGK()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 1u:
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 4;
				}
				break;
			case 2u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.LoadMusic(BJGCPDNMHDH.mMenuAssetBundle));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
			case 3u:
				if (BJGCPDNMHDH.data.musicVolume > 1366f)
				{
					BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.DoFadeIn(BJGCPDNMHDH.musicMenu, 682f, 1992f));
				}
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return false;
			}
			return true;
		}

		public void AKEKFBGEJBG()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public bool KHNDCDGBFJH()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 1u:
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 8;
				}
				break;
			case 2u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.LoadMusic(BJGCPDNMHDH.mMenuAssetBundle));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 5;
				}
				break;
			case 3u:
				if (BJGCPDNMHDH.data.musicVolume > 1368f)
				{
					BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.DoFadeIn(BJGCPDNMHDH.musicMenu, 638f, 1375f));
				}
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return true;
			}
			return false;
		}

		public bool NEMOAIBCODB()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
			case 1u:
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 5;
				}
				break;
			case 2u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.LoadMusic(BJGCPDNMHDH.mMenuAssetBundle));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 8;
				}
				break;
			case 3u:
				if (BJGCPDNMHDH.data.musicVolume > 1331f)
				{
					BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.DoFadeIn(BJGCPDNMHDH.musicMenu, 1466f, 839f));
				}
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return false;
			}
			return true;
		}

		[SpecialName]
		private object JEPCFCNIOGH()
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
		private object MPEPJNIDBLI()
		{
			return PHDOCKCBJOF;
		}
	}

	private sealed class KALJKDABPFH : IEnumerator, IDisposable, IEnumerator<object>
	{
		internal SoundsManager BJGCPDNMHDH;

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

		public bool GMBFJOBKMMN()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.LoadMusic(BJGCPDNMHDH.mGameAssetBundles[UnityEngine.Random.Range(1, BJGCPDNMHDH.mGameAssetBundles.Length)]));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				return true;
			case 1u:
				BJGCPDNMHDH.musicMenu.Play();
				BJGCPDNMHDH.musicMenu.volume = 1076f * BJGCPDNMHDH.data.musicVolume;
				CLPPIAGLCJJ = -1;
				break;
			}
			return false;
		}

		public bool NEMOAIBCODB()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.LoadMusic(BJGCPDNMHDH.mGameAssetBundles[UnityEngine.Random.Range(1, BJGCPDNMHDH.mGameAssetBundles.Length)]));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				return false;
			case 1u:
				BJGCPDNMHDH.musicMenu.Play();
				BJGCPDNMHDH.musicMenu.volume = 1122f * BJGCPDNMHDH.data.musicVolume;
				CLPPIAGLCJJ = -1;
				break;
			}
			return false;
		}

		public void HHCBBENDENJ()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object OJANHAIEAEJ()
		{
			return PHDOCKCBJOF;
		}

		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		public bool HDGDKCMIOGK()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.LoadMusic(BJGCPDNMHDH.mGameAssetBundles[UnityEngine.Random.Range(1, BJGCPDNMHDH.mGameAssetBundles.Length)]));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				return false;
			case 1u:
				BJGCPDNMHDH.musicMenu.Play();
				BJGCPDNMHDH.musicMenu.volume = 1563f * BJGCPDNMHDH.data.musicVolume;
				CLPPIAGLCJJ = -1;
				break;
			}
			return false;
		}

		public void PCNOHGFPMOE()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void OMDFNFHKFBK()
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
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.LoadMusic(BJGCPDNMHDH.mGameAssetBundles[UnityEngine.Random.Range(0, BJGCPDNMHDH.mGameAssetBundles.Length)]));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				return true;
			case 1u:
				BJGCPDNMHDH.musicMenu.Play();
				BJGCPDNMHDH.musicMenu.volume = 0.35f * BJGCPDNMHDH.data.musicVolume;
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

		[SpecialName]
		private object FCMAGGLJCMG()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object EGJDJENBABP()
		{
			return PHDOCKCBJOF;
		}

		public void ODJLLLFJIOB()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object HCCLNDKNCIE()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object FGFLGJECNLH()
		{
			return PHDOCKCBJOF;
		}

		public void KNFDMCEJHLB()
		{
			throw new NotSupportedException();
		}

		public void MIEFKIEABBN()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public void PHKDHCJBMII()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public void IODFILFCENJ()
		{
			throw new NotSupportedException();
		}

		public void MHKKAFGKBJK()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object FKKBFFHMEME()
		{
			return PHDOCKCBJOF;
		}

		public bool EKGEDEKHBME()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.LoadMusic(BJGCPDNMHDH.mGameAssetBundles[UnityEngine.Random.Range(0, BJGCPDNMHDH.mGameAssetBundles.Length)]));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				return true;
			case 1u:
				BJGCPDNMHDH.musicMenu.Play();
				BJGCPDNMHDH.musicMenu.volume = 623f * BJGCPDNMHDH.data.musicVolume;
				CLPPIAGLCJJ = -1;
				break;
			}
			return true;
		}

		[SpecialName]
		private object LMBPPPOFIOC()
		{
			return PHDOCKCBJOF;
		}

		public bool FNEPBDLIKOD()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.LoadMusic(BJGCPDNMHDH.mGameAssetBundles[UnityEngine.Random.Range(1, BJGCPDNMHDH.mGameAssetBundles.Length)]));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				return false;
			case 1u:
				BJGCPDNMHDH.musicMenu.Play();
				BJGCPDNMHDH.musicMenu.volume = 1379f * BJGCPDNMHDH.data.musicVolume;
				CLPPIAGLCJJ = -1;
				break;
			}
			return false;
		}

		public bool KKINHOPBKLH()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.LoadMusic(BJGCPDNMHDH.mGameAssetBundles[UnityEngine.Random.Range(0, BJGCPDNMHDH.mGameAssetBundles.Length)]));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				return false;
			case 1u:
				BJGCPDNMHDH.musicMenu.Play();
				BJGCPDNMHDH.musicMenu.volume = 498f * BJGCPDNMHDH.data.musicVolume;
				CLPPIAGLCJJ = -1;
				break;
			}
			return true;
		}

		public bool MKLIDMNLNPN()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.LoadMusic(BJGCPDNMHDH.mGameAssetBundles[UnityEngine.Random.Range(1, BJGCPDNMHDH.mGameAssetBundles.Length)]));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				return false;
			case 1u:
				BJGCPDNMHDH.musicMenu.Play();
				BJGCPDNMHDH.musicMenu.volume = 796f * BJGCPDNMHDH.data.musicVolume;
				CLPPIAGLCJJ = -1;
				break;
			}
			return false;
		}

		public void POJKIIMAFDO()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object CNGCLCAAHIG()
		{
			return PHDOCKCBJOF;
		}

		public void CDDFJOEEFID()
		{
			throw new NotSupportedException();
		}

		public void OLPILJFHMGD()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void CPOKHODGGLN()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object CJCHFDFCPPL()
		{
			return PHDOCKCBJOF;
		}

		public void HDDLDAHLPCO()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object GMPGIODBIPO()
		{
			return PHDOCKCBJOF;
		}

		public void IMFLNKIMEFA()
		{
			throw new NotSupportedException();
		}

		public void GBGMIJNBLNH()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public void LFIGPJBHPBH()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public void PDNKLJFHBGO()
		{
			throw new NotSupportedException();
		}

		public bool MOFPMNMAOND()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.LoadMusic(BJGCPDNMHDH.mGameAssetBundles[UnityEngine.Random.Range(1, BJGCPDNMHDH.mGameAssetBundles.Length)]));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				return false;
			case 1u:
				BJGCPDNMHDH.musicMenu.Play();
				BJGCPDNMHDH.musicMenu.volume = 1685f * BJGCPDNMHDH.data.musicVolume;
				CLPPIAGLCJJ = -1;
				break;
			}
			return false;
		}

		public bool BIGKCFMEBJE()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.LoadMusic(BJGCPDNMHDH.mGameAssetBundles[UnityEngine.Random.Range(1, BJGCPDNMHDH.mGameAssetBundles.Length)]));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				return false;
			case 1u:
				BJGCPDNMHDH.musicMenu.Play();
				BJGCPDNMHDH.musicMenu.volume = 989f * BJGCPDNMHDH.data.musicVolume;
				CLPPIAGLCJJ = -1;
				break;
			}
			return false;
		}

		[SpecialName]
		private object EAGBDDECKHF()
		{
			return PHDOCKCBJOF;
		}

		[DebuggerHidden]
		public KALJKDABPFH()
		{
		}

		[SpecialName]
		private object BKHFGLNNCDF()
		{
			return PHDOCKCBJOF;
		}

		public void GCEMCPODLNM()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object PCOOFELAEJA()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object LKAEMBCGLBN()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object BEGHOADNMJF()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object HHLKEMNNJDA()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object KLEHMEIAJHO()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object KIHECHEHNJJ()
		{
			return PHDOCKCBJOF;
		}

		public void PKMIJKOPPBF()
		{
			throw new NotSupportedException();
		}

		public void LJPIDOKGNBF()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public bool LPMIKEPIMCM()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.LoadMusic(BJGCPDNMHDH.mGameAssetBundles[UnityEngine.Random.Range(0, BJGCPDNMHDH.mGameAssetBundles.Length)]));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				return false;
			case 1u:
				BJGCPDNMHDH.musicMenu.Play();
				BJGCPDNMHDH.musicMenu.volume = 577f * BJGCPDNMHDH.data.musicVolume;
				CLPPIAGLCJJ = -1;
				break;
			}
			return false;
		}

		[SpecialName]
		private object MPHILJJDNIO()
		{
			return PHDOCKCBJOF;
		}

		public bool IGOKEIDOCKB()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.LoadMusic(BJGCPDNMHDH.mGameAssetBundles[UnityEngine.Random.Range(1, BJGCPDNMHDH.mGameAssetBundles.Length)]));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				return true;
			case 1u:
				BJGCPDNMHDH.musicMenu.Play();
				BJGCPDNMHDH.musicMenu.volume = 831f * BJGCPDNMHDH.data.musicVolume;
				CLPPIAGLCJJ = -1;
				break;
			}
			return true;
		}

		public void ABBPOMCBIIH()
		{
			throw new NotSupportedException();
		}

		public void JHLKDONBGDK()
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
		private object GCJFGIKENJA()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object HFKDIPEKENH()
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
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(BJGCPDNMHDH.LoadMusic(BJGCPDNMHDH.mGameAssetBundles[UnityEngine.Random.Range(1, BJGCPDNMHDH.mGameAssetBundles.Length)]));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				return true;
			case 1u:
				BJGCPDNMHDH.musicMenu.Play();
				BJGCPDNMHDH.musicMenu.volume = 1486f * BJGCPDNMHDH.data.musicVolume;
				CLPPIAGLCJJ = -1;
				break;
			}
			return false;
		}

		public void GIAIFFPNMPJ()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object BGMNDLEJNHH()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object DCILDAODCDM()
		{
			return PHDOCKCBJOF;
		}

		public void JMANMKKCDMM()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object JALKNCBEINE()
		{
			return PHDOCKCBJOF;
		}

		public void KKDOJDCJAJB()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void ODFCBNONFPL()
		{
			throw new NotSupportedException();
		}
	}

	private sealed class DIOIAJMAFJH : IEnumerator, IDisposable, IEnumerator<object>
	{
		internal string JMLGMFFKGNM;

		internal SoundsManager BJGCPDNMHDH;

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

		public void NCOPKHMOMMK()
		{
		}

		[SpecialName]
		private object BJJNGPKNCKJ()
		{
			return PHDOCKCBJOF;
		}

		public void MIPBONGPIJE()
		{
		}

		[SpecialName]
		private object PFIIINLHGMH()
		{
			return PHDOCKCBJOF;
		}

		public void IGBHHLFACKO()
		{
		}

		public void FIENOOBNNGD()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object HHLKEMNNJDA()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object NMGBFNNHIPN()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object FPMOGMELJLI()
		{
			return PHDOCKCBJOF;
		}

		public void NMEJKACLHKJ()
		{
			throw new NotSupportedException();
		}

		public void PNGIELILHDI()
		{
		}

		[SpecialName]
		private object LFEJDKIGHMI()
		{
			return PHDOCKCBJOF;
		}

		public bool HKPECDLGFJB()
		{
			int cLPPIAGLCJJ = CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			if (cLPPIAGLCJJ == 0)
			{
				BJGCPDNMHDH.mMusicClip = Resources.Load<AudioClip>(JMLGMFFKGNM);
				BJGCPDNMHDH.musicMenu.clip = BJGCPDNMHDH.mMusicClip;
			}
			return false;
		}

		[SpecialName]
		private object CNGCLCAAHIG()
		{
			return PHDOCKCBJOF;
		}

		public void ODCIKOOGNFG()
		{
		}

		public bool PIAOIBJMLCC()
		{
			int cLPPIAGLCJJ = CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			if (cLPPIAGLCJJ == 0)
			{
				BJGCPDNMHDH.mMusicClip = Resources.Load<AudioClip>(JMLGMFFKGNM);
				BJGCPDNMHDH.musicMenu.clip = BJGCPDNMHDH.mMusicClip;
			}
			return false;
		}

		[SpecialName]
		private object KBNAGKKMLBP()
		{
			return PHDOCKCBJOF;
		}

		public void CPDBCJLIGFN()
		{
		}

		public bool DEEBEBGBMKK()
		{
			int cLPPIAGLCJJ = CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			if (cLPPIAGLCJJ == 0)
			{
				BJGCPDNMHDH.mMusicClip = Resources.Load<AudioClip>(JMLGMFFKGNM);
				BJGCPDNMHDH.musicMenu.clip = BJGCPDNMHDH.mMusicClip;
			}
			return false;
		}

		public bool IIJKAMFGNKA()
		{
			int cLPPIAGLCJJ = CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			if (cLPPIAGLCJJ == 0)
			{
				BJGCPDNMHDH.mMusicClip = Resources.Load<AudioClip>(JMLGMFFKGNM);
				BJGCPDNMHDH.musicMenu.clip = BJGCPDNMHDH.mMusicClip;
			}
			return false;
		}

		public void DBJCDLFKDDI()
		{
			throw new NotSupportedException();
		}

		public void FOBPOJPHNHE()
		{
		}

		public void IDCJDJMGKFG()
		{
		}

		public void PAOPOFJHFGD()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object OJMKDIBHMND()
		{
			return PHDOCKCBJOF;
		}

		public bool JNHFCKKAPJH()
		{
			int cLPPIAGLCJJ = CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			if (cLPPIAGLCJJ == 0)
			{
				BJGCPDNMHDH.mMusicClip = Resources.Load<AudioClip>(JMLGMFFKGNM);
				BJGCPDNMHDH.musicMenu.clip = BJGCPDNMHDH.mMusicClip;
			}
			return true;
		}

		public bool MoveNext()
		{
			int cLPPIAGLCJJ = CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			if (cLPPIAGLCJJ == 0)
			{
				BJGCPDNMHDH.mMusicClip = Resources.Load<AudioClip>(JMLGMFFKGNM);
				BJGCPDNMHDH.musicMenu.clip = BJGCPDNMHDH.mMusicClip;
			}
			return false;
		}

		public void OKIANDBCDIB()
		{
		}

		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		public bool GAPIFMKNJBN()
		{
			int cLPPIAGLCJJ = CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			if (cLPPIAGLCJJ == 0)
			{
				BJGCPDNMHDH.mMusicClip = Resources.Load<AudioClip>(JMLGMFFKGNM);
				BJGCPDNMHDH.musicMenu.clip = BJGCPDNMHDH.mMusicClip;
			}
			return true;
		}

		public bool HCONPNNPBAD()
		{
			int cLPPIAGLCJJ = CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			if (cLPPIAGLCJJ == 0)
			{
				BJGCPDNMHDH.mMusicClip = Resources.Load<AudioClip>(JMLGMFFKGNM);
				BJGCPDNMHDH.musicMenu.clip = BJGCPDNMHDH.mMusicClip;
			}
			return false;
		}

		public void LOOMFHNKAND()
		{
			throw new NotSupportedException();
		}

		public void ODPKEEIHOPK()
		{
		}

		public void ODACICLOMHJ()
		{
			throw new NotSupportedException();
		}

		public void JJOAHIOBOPO()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object CLDLJNHAEAB()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object CMNCAPEMEJI()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object CIGHIOCACPH()
		{
			return PHDOCKCBJOF;
		}

		public void GIAIFFPNMPJ()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object FKKBFFHMEME()
		{
			return PHDOCKCBJOF;
		}

		public void FOODPOJODAA()
		{
		}

		public void CHANLKFNCLA()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object BGLDNJLBIKM()
		{
			return PHDOCKCBJOF;
		}

		public void MHKKAFGKBJK()
		{
			throw new NotSupportedException();
		}

		public void MNFJGIMMBLE()
		{
			throw new NotSupportedException();
		}

		[DebuggerHidden]
		public DIOIAJMAFJH()
		{
		}

		public void AKEKFBGEJBG()
		{
		}

		[SpecialName]
		private object CFBNPKIMOJC()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object KIHECHEHNJJ()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object BNMEIAPPLDP()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object PEGJNAKGHCC()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object MILFCGMBHIG()
		{
			return PHDOCKCBJOF;
		}

		public void KGLKGNBCPLM()
		{
		}

		[SpecialName]
		private object BGBGCFGNJLA()
		{
			return PHDOCKCBJOF;
		}

		public bool CGOKGPGALLH()
		{
			int cLPPIAGLCJJ = CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			if (cLPPIAGLCJJ == 0)
			{
				BJGCPDNMHDH.mMusicClip = Resources.Load<AudioClip>(JMLGMFFKGNM);
				BJGCPDNMHDH.musicMenu.clip = BJGCPDNMHDH.mMusicClip;
			}
			return true;
		}

		public void FLCIMHOJPDF()
		{
		}

		public void JMANMKKCDMM()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object EOKIMMCAABI()
		{
			return PHDOCKCBJOF;
		}

		public void JOEOMEJLEID()
		{
		}

		[SpecialName]
		private object GDBNOMPNBGP()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object JKKAEPEAGNP()
		{
			return PHDOCKCBJOF;
		}

		public void CDIJEGGMMAK()
		{
		}

		public void HONCAABOMOC()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object KKKMCHGLHLL()
		{
			return PHDOCKCBJOF;
		}

		[DebuggerHidden]
		public void Dispose()
		{
		}

		public void DNNJONPPIED()
		{
			throw new NotSupportedException();
		}

		public bool GBLFIBDBMGE()
		{
			int cLPPIAGLCJJ = CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			if (cLPPIAGLCJJ == 0)
			{
				BJGCPDNMHDH.mMusicClip = Resources.Load<AudioClip>(JMLGMFFKGNM);
				BJGCPDNMHDH.musicMenu.clip = BJGCPDNMHDH.mMusicClip;
			}
			return true;
		}

		public void CDDFJOEEFID()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object OAMLLHEMBIK()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object LJDPEMMLOFM()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object ADNCCLOOEAD()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object BBHOODPMEFM()
		{
			return PHDOCKCBJOF;
		}
	}

	private sealed class LJNIJIFPHDB : IEnumerator, IDisposable, IEnumerator<object>
	{
		internal float LADMMFLMOLE;

		internal float PBGMILNLOBJ;

		internal float MPAMHAEDKBO;

		internal float OGJDHCIOKCB;

		internal AudioSource BENGENAMIGD;

		internal SoundsManager BJGCPDNMHDH;

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
		public LJNIJIFPHDB()
		{
		}

		public bool FADACBKMFGG()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				LADMMFLMOLE = Time.time;
				PBGMILNLOBJ = 1671f;
				goto IL_0037;
			case 1u:
				{
					if (!BJGCPDNMHDH.mMusicFadingOut || !(PBGMILNLOBJ < OGJDHCIOKCB))
					{
						if (!BJGCPDNMHDH.mMusicFadingIn)
						{
							BJGCPDNMHDH.mMusicFadingIn = false;
							BENGENAMIGD.Stop();
						}
						CLPPIAGLCJJ = -1;
						break;
					}
					goto IL_0037;
				}
				IL_0037:
				PBGMILNLOBJ = Time.time - LADMMFLMOLE;
				BENGENAMIGD.volume = Mathf.Lerp(MPAMHAEDKBO, 1624f, PBGMILNLOBJ / OGJDHCIOKCB);
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				return false;
			}
			return false;
		}

		[SpecialName]
		private object FPFOODLPEBK()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object HCPKEMLPEDI()
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
				LADMMFLMOLE = Time.time;
				PBGMILNLOBJ = 1723f;
				goto IL_0037;
			case 1u:
				{
					if (!BJGCPDNMHDH.mMusicFadingOut || !(PBGMILNLOBJ < OGJDHCIOKCB))
					{
						if (!BJGCPDNMHDH.mMusicFadingIn)
						{
							BJGCPDNMHDH.mMusicFadingIn = false;
							BENGENAMIGD.Stop();
						}
						CLPPIAGLCJJ = -1;
						break;
					}
					goto IL_0037;
				}
				IL_0037:
				PBGMILNLOBJ = Time.time - LADMMFLMOLE;
				BENGENAMIGD.volume = Mathf.Lerp(MPAMHAEDKBO, 1100f, PBGMILNLOBJ / OGJDHCIOKCB);
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				return false;
			}
			return false;
		}

		public bool GBLFIBDBMGE()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				LADMMFLMOLE = Time.time;
				PBGMILNLOBJ = 625f;
				goto IL_0037;
			case 1u:
				{
					if (!BJGCPDNMHDH.mMusicFadingOut || !(PBGMILNLOBJ < OGJDHCIOKCB))
					{
						if (!BJGCPDNMHDH.mMusicFadingIn)
						{
							BJGCPDNMHDH.mMusicFadingIn = true;
							BENGENAMIGD.Stop();
						}
						CLPPIAGLCJJ = -1;
						break;
					}
					goto IL_0037;
				}
				IL_0037:
				PBGMILNLOBJ = Time.time - LADMMFLMOLE;
				BENGENAMIGD.volume = Mathf.Lerp(MPAMHAEDKBO, 92f, PBGMILNLOBJ / OGJDHCIOKCB);
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				return true;
			}
			return true;
		}

		public void NINFNJOMJOD()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object GLKCJHHLOCE()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object DFHCLJNONGC()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object HBKJOBOMGKB()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object AFAOHBIDOJD()
		{
			return PHDOCKCBJOF;
		}

		public void DBJCDLFKDDI()
		{
			throw new NotSupportedException();
		}

		public void CNOEDCFDILG()
		{
			throw new NotSupportedException();
		}

		public void MAKKCANEHIB()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void FJOIBBIGBJC()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public bool KKINHOPBKLH()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				LADMMFLMOLE = Time.time;
				PBGMILNLOBJ = 11f;
				goto IL_0037;
			case 1u:
				{
					if (!BJGCPDNMHDH.mMusicFadingOut || !(PBGMILNLOBJ < OGJDHCIOKCB))
					{
						if (!BJGCPDNMHDH.mMusicFadingIn)
						{
							BJGCPDNMHDH.mMusicFadingIn = false;
							BENGENAMIGD.Stop();
						}
						CLPPIAGLCJJ = -1;
						break;
					}
					goto IL_0037;
				}
				IL_0037:
				PBGMILNLOBJ = Time.time - LADMMFLMOLE;
				BENGENAMIGD.volume = Mathf.Lerp(MPAMHAEDKBO, 320f, PBGMILNLOBJ / OGJDHCIOKCB);
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				return true;
			}
			return false;
		}

		[SpecialName]
		private object KBNAGKKMLBP()
		{
			return PHDOCKCBJOF;
		}

		public void MKACBCOLNKD()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void PHEIGPKKPGE()
		{
			throw new NotSupportedException();
		}

		public void OCBFBEMDMMJ()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object BGLDNJLBIKM()
		{
			return PHDOCKCBJOF;
		}

		public void CPOKHODGGLN()
		{
			throw new NotSupportedException();
		}

		public void MIPBONGPIJE()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void AHEOCEEJICJ()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object FKKBFFHMEME()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object EPNOIENCFGA()
		{
			return PHDOCKCBJOF;
		}

		[DebuggerHidden]
		public void Dispose()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void FOODPOJODAA()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object GJMNLPAEIDA()
		{
			return PHDOCKCBJOF;
		}

		public void IHAHCOPGPIM()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object BGAGLOJHMEJ()
		{
			return PHDOCKCBJOF;
		}

		public void LBNGPPPKLHI()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void EPKPNKGJHEC()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public void FGLAPPKJHBK()
		{
			throw new NotSupportedException();
		}

		public void FLCIMHOJPDF()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public void NINFHADPHJI()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public void LPKDPNHBLGJ()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public bool DFMKKFMEBON()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				LADMMFLMOLE = Time.time;
				PBGMILNLOBJ = 1916f;
				goto IL_0037;
			case 1u:
				{
					if (!BJGCPDNMHDH.mMusicFadingOut || !(PBGMILNLOBJ < OGJDHCIOKCB))
					{
						if (!BJGCPDNMHDH.mMusicFadingIn)
						{
							BJGCPDNMHDH.mMusicFadingIn = true;
							BENGENAMIGD.Stop();
						}
						CLPPIAGLCJJ = -1;
						break;
					}
					goto IL_0037;
				}
				IL_0037:
				PBGMILNLOBJ = Time.time - LADMMFLMOLE;
				BENGENAMIGD.volume = Mathf.Lerp(MPAMHAEDKBO, 1442f, PBGMILNLOBJ / OGJDHCIOKCB);
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				return true;
			}
			return true;
		}

		public void IJHCIJLDKHK()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object HIFNMHAGHLI()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object ACDKCFGCBAB()
		{
			return PHDOCKCBJOF;
		}

		public void NMEJKACLHKJ()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object PEGJNAKGHCC()
		{
			return PHDOCKCBJOF;
		}

		public bool BLHOCNMMPNP()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				LADMMFLMOLE = Time.time;
				PBGMILNLOBJ = 1504f;
				goto IL_0037;
			case 1u:
				{
					if (!BJGCPDNMHDH.mMusicFadingOut || !(PBGMILNLOBJ < OGJDHCIOKCB))
					{
						if (!BJGCPDNMHDH.mMusicFadingIn)
						{
							BJGCPDNMHDH.mMusicFadingIn = false;
							BENGENAMIGD.Stop();
						}
						CLPPIAGLCJJ = -1;
						break;
					}
					goto IL_0037;
				}
				IL_0037:
				PBGMILNLOBJ = Time.time - LADMMFLMOLE;
				BENGENAMIGD.volume = Mathf.Lerp(MPAMHAEDKBO, 1905f, PBGMILNLOBJ / OGJDHCIOKCB);
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				return true;
			}
			return true;
		}

		public void HHMPMPLLJCC()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object GNFCCLCPCBO()
		{
			return PHDOCKCBJOF;
		}

		public void MEBPMHDHIPJ()
		{
			throw new NotSupportedException();
		}

		public void NBMNDHCIBME()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object MBDBIPHLEIA()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object NEGMMIBLJLP()
		{
			return PHDOCKCBJOF;
		}

		public void ONGBFFAENBP()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object GEFKCGOOFFP()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object CNGCLCAAHIG()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object MHKODCGLJFD()
		{
			return PHDOCKCBJOF;
		}

		public void PHKDHCJBMII()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void ODACICLOMHJ()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object EOKIMMCAABI()
		{
			return PHDOCKCBJOF;
		}

		public void BLOCBAKBHBF()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public void IDCJDJMGKFG()
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
				LADMMFLMOLE = Time.time;
				PBGMILNLOBJ = 717f;
				goto IL_0037;
			case 1u:
				{
					if (!BJGCPDNMHDH.mMusicFadingOut || !(PBGMILNLOBJ < OGJDHCIOKCB))
					{
						if (!BJGCPDNMHDH.mMusicFadingIn)
						{
							BJGCPDNMHDH.mMusicFadingIn = false;
							BENGENAMIGD.Stop();
						}
						CLPPIAGLCJJ = -1;
						break;
					}
					goto IL_0037;
				}
				IL_0037:
				PBGMILNLOBJ = Time.time - LADMMFLMOLE;
				BENGENAMIGD.volume = Mathf.Lerp(MPAMHAEDKBO, 1693f, PBGMILNLOBJ / OGJDHCIOKCB);
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				return false;
			}
			return true;
		}

		public bool MoveNext()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				LADMMFLMOLE = Time.time;
				PBGMILNLOBJ = 0f;
				goto IL_0037;
			case 1u:
				{
					if (!BJGCPDNMHDH.mMusicFadingOut || !(PBGMILNLOBJ < OGJDHCIOKCB))
					{
						if (!BJGCPDNMHDH.mMusicFadingIn)
						{
							BJGCPDNMHDH.mMusicFadingIn = false;
							BENGENAMIGD.Stop();
						}
						CLPPIAGLCJJ = -1;
						break;
					}
					goto IL_0037;
				}
				IL_0037:
				PBGMILNLOBJ = Time.time - LADMMFLMOLE;
				BENGENAMIGD.volume = Mathf.Lerp(MPAMHAEDKBO, 0f, PBGMILNLOBJ / OGJDHCIOKCB);
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				return true;
			}
			return false;
		}

		[SpecialName]
		private object NAPMJAMDKMJ()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object JFGCHMJJMNO()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object NCKCKPNAHAD()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object IHDBAJNCNGN()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object ADIAKJMNIEB()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object GDCFFBBNGHH()
		{
			return PHDOCKCBJOF;
		}

		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		public void GIAIFFPNMPJ()
		{
			throw new NotSupportedException();
		}
	}

	private sealed class FLBEAODJGOP : IEnumerator, IDisposable, IEnumerator<object>
	{
		internal AudioSource BENGENAMIGD;

		internal float LADMMFLMOLE;

		internal float PBGMILNLOBJ;

		internal float MPAMHAEDKBO;

		internal float OGJDHCIOKCB;

		internal SoundsManager BJGCPDNMHDH;

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

		public void HHCBBENDENJ()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public void PCNOHGFPMOE()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public void ODJLLLFJIOB()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public bool IEDGDDDADFM()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				BENGENAMIGD.Play();
				BJGCPDNMHDH.mMusicFadingIn = true;
				LADMMFLMOLE = Time.time;
				PBGMILNLOBJ = 1628f;
				goto IL_004e;
			case 1u:
				{
					if (!BJGCPDNMHDH.mMusicFadingIn || !(PBGMILNLOBJ < OGJDHCIOKCB))
					{
						CLPPIAGLCJJ = -1;
						break;
					}
					goto IL_004e;
				}
				IL_004e:
				PBGMILNLOBJ = Time.time - LADMMFLMOLE;
				BENGENAMIGD.volume = Mathf.Lerp(1644f, MPAMHAEDKBO * BJGCPDNMHDH.data.musicVolume, PBGMILNLOBJ / OGJDHCIOKCB);
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				return true;
			}
			return true;
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

		[SpecialName]
		private object GOAJCEAOPLA()
		{
			return PHDOCKCBJOF;
		}

		public void CDDFJOEEFID()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object HHLKEMNNJDA()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object GCJFGIKENJA()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object APECNPGKOFC()
		{
			return PHDOCKCBJOF;
		}

		public void KHMNEOBMJLN()
		{
			throw new NotSupportedException();
		}

		public void HHMPMPLLJCC()
		{
			throw new NotSupportedException();
		}

		public void OMDFNFHKFBK()
		{
			throw new NotSupportedException();
		}

		[DebuggerHidden]
		public FLBEAODJGOP()
		{
		}

		public void NAMBILMHOPD()
		{
			throw new NotSupportedException();
		}

		public bool JIIOHNFHPOI()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				BENGENAMIGD.Play();
				BJGCPDNMHDH.mMusicFadingIn = true;
				LADMMFLMOLE = Time.time;
				PBGMILNLOBJ = 100f;
				goto IL_004e;
			case 1u:
				{
					if (!BJGCPDNMHDH.mMusicFadingIn || !(PBGMILNLOBJ < OGJDHCIOKCB))
					{
						CLPPIAGLCJJ = -1;
						break;
					}
					goto IL_004e;
				}
				IL_004e:
				PBGMILNLOBJ = Time.time - LADMMFLMOLE;
				BENGENAMIGD.volume = Mathf.Lerp(1716f, MPAMHAEDKBO * BJGCPDNMHDH.data.musicVolume, PBGMILNLOBJ / OGJDHCIOKCB);
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				return true;
			}
			return true;
		}

		[SpecialName]
		private object FKPDNNMENFD()
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
				BENGENAMIGD.Play();
				BJGCPDNMHDH.mMusicFadingIn = false;
				LADMMFLMOLE = Time.time;
				PBGMILNLOBJ = 751f;
				goto IL_004e;
			case 1u:
				{
					if (!BJGCPDNMHDH.mMusicFadingIn || !(PBGMILNLOBJ < OGJDHCIOKCB))
					{
						CLPPIAGLCJJ = -1;
						break;
					}
					goto IL_004e;
				}
				IL_004e:
				PBGMILNLOBJ = Time.time - LADMMFLMOLE;
				BENGENAMIGD.volume = Mathf.Lerp(1612f, MPAMHAEDKBO * BJGCPDNMHDH.data.musicVolume, PBGMILNLOBJ / OGJDHCIOKCB);
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				return false;
			}
			return false;
		}

		public bool KHNDCDGBFJH()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				BENGENAMIGD.Play();
				BJGCPDNMHDH.mMusicFadingIn = true;
				LADMMFLMOLE = Time.time;
				PBGMILNLOBJ = 1134f;
				goto IL_004e;
			case 1u:
				{
					if (!BJGCPDNMHDH.mMusicFadingIn || !(PBGMILNLOBJ < OGJDHCIOKCB))
					{
						CLPPIAGLCJJ = -1;
						break;
					}
					goto IL_004e;
				}
				IL_004e:
				PBGMILNLOBJ = Time.time - LADMMFLMOLE;
				BENGENAMIGD.volume = Mathf.Lerp(670f, MPAMHAEDKBO * BJGCPDNMHDH.data.musicVolume, PBGMILNLOBJ / OGJDHCIOKCB);
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				return false;
			}
			return false;
		}

		public void IODFILFCENJ()
		{
			throw new NotSupportedException();
		}

		public void FOODPOJODAA()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void KNFDMCEJHLB()
		{
			throw new NotSupportedException();
		}

		public bool CIIHKFDLDKN()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				BENGENAMIGD.Play();
				BJGCPDNMHDH.mMusicFadingIn = false;
				LADMMFLMOLE = Time.time;
				PBGMILNLOBJ = 232f;
				goto IL_004e;
			case 1u:
				{
					if (!BJGCPDNMHDH.mMusicFadingIn || !(PBGMILNLOBJ < OGJDHCIOKCB))
					{
						CLPPIAGLCJJ = -1;
						break;
					}
					goto IL_004e;
				}
				IL_004e:
				PBGMILNLOBJ = Time.time - LADMMFLMOLE;
				BENGENAMIGD.volume = Mathf.Lerp(1028f, MPAMHAEDKBO * BJGCPDNMHDH.data.musicVolume, PBGMILNLOBJ / OGJDHCIOKCB);
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				return true;
			}
			return true;
		}

		public void LICALBFPBLL()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object OAKHGMKKFMN()
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
				BENGENAMIGD.Play();
				BJGCPDNMHDH.mMusicFadingIn = false;
				LADMMFLMOLE = Time.time;
				PBGMILNLOBJ = 476f;
				goto IL_004e;
			case 1u:
				{
					if (!BJGCPDNMHDH.mMusicFadingIn || !(PBGMILNLOBJ < OGJDHCIOKCB))
					{
						CLPPIAGLCJJ = -1;
						break;
					}
					goto IL_004e;
				}
				IL_004e:
				PBGMILNLOBJ = Time.time - LADMMFLMOLE;
				BENGENAMIGD.volume = Mathf.Lerp(946f, MPAMHAEDKBO * BJGCPDNMHDH.data.musicVolume, PBGMILNLOBJ / OGJDHCIOKCB);
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				return true;
			}
			return false;
		}

		public void CHANLKFNCLA()
		{
			throw new NotSupportedException();
		}

		public void EMICCACCFIP()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void BCKMHLBBBCK()
		{
			throw new NotSupportedException();
		}

		public void LDBLCPIGLOF()
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
				BENGENAMIGD.Play();
				BJGCPDNMHDH.mMusicFadingIn = true;
				LADMMFLMOLE = Time.time;
				PBGMILNLOBJ = 0f;
				goto IL_004e;
			case 1u:
				{
					if (!BJGCPDNMHDH.mMusicFadingIn || !(PBGMILNLOBJ < OGJDHCIOKCB))
					{
						CLPPIAGLCJJ = -1;
						break;
					}
					goto IL_004e;
				}
				IL_004e:
				PBGMILNLOBJ = Time.time - LADMMFLMOLE;
				BENGENAMIGD.volume = Mathf.Lerp(0f, MPAMHAEDKBO * BJGCPDNMHDH.data.musicVolume, PBGMILNLOBJ / OGJDHCIOKCB);
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				return true;
			}
			return false;
		}

		public void PKMIJKOPPBF()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object GPKBICHIBHF()
		{
			return PHDOCKCBJOF;
		}

		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object FMCLBOCENPE()
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
				BENGENAMIGD.Play();
				BJGCPDNMHDH.mMusicFadingIn = false;
				LADMMFLMOLE = Time.time;
				PBGMILNLOBJ = 1581f;
				goto IL_004e;
			case 1u:
				{
					if (!BJGCPDNMHDH.mMusicFadingIn || !(PBGMILNLOBJ < OGJDHCIOKCB))
					{
						CLPPIAGLCJJ = -1;
						break;
					}
					goto IL_004e;
				}
				IL_004e:
				PBGMILNLOBJ = Time.time - LADMMFLMOLE;
				BENGENAMIGD.volume = Mathf.Lerp(1850f, MPAMHAEDKBO * BJGCPDNMHDH.data.musicVolume, PBGMILNLOBJ / OGJDHCIOKCB);
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				return true;
			}
			return true;
		}

		[DebuggerHidden]
		public void Dispose()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void DEPEHNFEJEE()
		{
			throw new NotSupportedException();
		}

		public void NBMNDHCIBME()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object NDIGINEEOMH()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object MOMPOEEALPJ()
		{
			return PHDOCKCBJOF;
		}

		public bool DDLMLOJGJMA()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				BENGENAMIGD.Play();
				BJGCPDNMHDH.mMusicFadingIn = false;
				LADMMFLMOLE = Time.time;
				PBGMILNLOBJ = 513f;
				goto IL_004e;
			case 1u:
				{
					if (!BJGCPDNMHDH.mMusicFadingIn || !(PBGMILNLOBJ < OGJDHCIOKCB))
					{
						CLPPIAGLCJJ = -1;
						break;
					}
					goto IL_004e;
				}
				IL_004e:
				PBGMILNLOBJ = Time.time - LADMMFLMOLE;
				BENGENAMIGD.volume = Mathf.Lerp(1000f, MPAMHAEDKBO * BJGCPDNMHDH.data.musicVolume, PBGMILNLOBJ / OGJDHCIOKCB);
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				return false;
			}
			return true;
		}

		public void OLPILJFHMGD()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
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

		public bool FNEPBDLIKOD()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				BENGENAMIGD.Play();
				BJGCPDNMHDH.mMusicFadingIn = true;
				LADMMFLMOLE = Time.time;
				PBGMILNLOBJ = 1470f;
				goto IL_004e;
			case 1u:
				{
					if (!BJGCPDNMHDH.mMusicFadingIn || !(PBGMILNLOBJ < OGJDHCIOKCB))
					{
						CLPPIAGLCJJ = -1;
						break;
					}
					goto IL_004e;
				}
				IL_004e:
				PBGMILNLOBJ = Time.time - LADMMFLMOLE;
				BENGENAMIGD.volume = Mathf.Lerp(1646f, MPAMHAEDKBO * BJGCPDNMHDH.data.musicVolume, PBGMILNLOBJ / OGJDHCIOKCB);
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				return false;
			}
			return false;
		}

		public void ODFCBNONFPL()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object PCOOFELAEJA()
		{
			return PHDOCKCBJOF;
		}

		public bool BCFKDABEHHO()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				BENGENAMIGD.Play();
				BJGCPDNMHDH.mMusicFadingIn = false;
				LADMMFLMOLE = Time.time;
				PBGMILNLOBJ = 1091f;
				goto IL_004e;
			case 1u:
				{
					if (!BJGCPDNMHDH.mMusicFadingIn || !(PBGMILNLOBJ < OGJDHCIOKCB))
					{
						CLPPIAGLCJJ = -1;
						break;
					}
					goto IL_004e;
				}
				IL_004e:
				PBGMILNLOBJ = Time.time - LADMMFLMOLE;
				BENGENAMIGD.volume = Mathf.Lerp(1869f, MPAMHAEDKBO * BJGCPDNMHDH.data.musicVolume, PBGMILNLOBJ / OGJDHCIOKCB);
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				return false;
			}
			return true;
		}

		public bool JFPOOBJNEPF()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				BENGENAMIGD.Play();
				BJGCPDNMHDH.mMusicFadingIn = true;
				LADMMFLMOLE = Time.time;
				PBGMILNLOBJ = 1158f;
				goto IL_004e;
			case 1u:
				{
					if (!BJGCPDNMHDH.mMusicFadingIn || !(PBGMILNLOBJ < OGJDHCIOKCB))
					{
						CLPPIAGLCJJ = -1;
						break;
					}
					goto IL_004e;
				}
				IL_004e:
				PBGMILNLOBJ = Time.time - LADMMFLMOLE;
				BENGENAMIGD.volume = Mathf.Lerp(386f, MPAMHAEDKBO * BJGCPDNMHDH.data.musicVolume, PBGMILNLOBJ / OGJDHCIOKCB);
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				return false;
			}
			return true;
		}

		[SpecialName]
		private object IGMIIAODMNF()
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
				BENGENAMIGD.Play();
				BJGCPDNMHDH.mMusicFadingIn = false;
				LADMMFLMOLE = Time.time;
				PBGMILNLOBJ = 767f;
				goto IL_004e;
			case 1u:
				{
					if (!BJGCPDNMHDH.mMusicFadingIn || !(PBGMILNLOBJ < OGJDHCIOKCB))
					{
						CLPPIAGLCJJ = -1;
						break;
					}
					goto IL_004e;
				}
				IL_004e:
				PBGMILNLOBJ = Time.time - LADMMFLMOLE;
				BENGENAMIGD.volume = Mathf.Lerp(1050f, MPAMHAEDKBO * BJGCPDNMHDH.data.musicVolume, PBGMILNLOBJ / OGJDHCIOKCB);
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				return false;
			}
			return true;
		}

		[SpecialName]
		private object OJANHAIEAEJ()
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
				BENGENAMIGD.Play();
				BJGCPDNMHDH.mMusicFadingIn = true;
				LADMMFLMOLE = Time.time;
				PBGMILNLOBJ = 321f;
				goto IL_004e;
			case 1u:
				{
					if (!BJGCPDNMHDH.mMusicFadingIn || !(PBGMILNLOBJ < OGJDHCIOKCB))
					{
						CLPPIAGLCJJ = -1;
						break;
					}
					goto IL_004e;
				}
				IL_004e:
				PBGMILNLOBJ = Time.time - LADMMFLMOLE;
				BENGENAMIGD.volume = Mathf.Lerp(494f, MPAMHAEDKBO * BJGCPDNMHDH.data.musicVolume, PBGMILNLOBJ / OGJDHCIOKCB);
				PHDOCKCBJOF = null;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				return false;
			}
			return false;
		}
	}

	private static SoundsManager mInstance;

	public AudioSource musicMenu;

	private string mMenuAssetBundle = "audio/menu";

	private readonly string[] mGameAssetBundles = new string[2] { "audio/game0", "audio/game1" };

	private AudioClip mMusicClip;

	public List<SoundEntry2D> SoundEntries;

	private Dictionary<KJGDNLHKPOG, SoundEntry2D> mAllSounds;

	private AudioListener mListener;

	private AudioSource _audioSource;

	private bool mMusicFadingIn;

	private bool mMusicFadingOut;

	public bool autoLoad = true;

	public List<AudioClip> clipsForGame;

	private int mClipsCounter;

	public static SoundsManager Instance
	{
		get
		{
			mInstance = mInstance ?? ((SoundsManager)UnityEngine.Object.FindObjectsOfType(typeof(SoundsManager))[0]);
			return mInstance;
		}
	}

	public float soundsVolume
	{
		get
		{
			return data.soundVolume;
		}
		set
		{
			data.soundVolume = value;
			if (this.onSoundVolumeChange != null)
			{
				this.onSoundVolumeChange();
			}
		}
	}

	public float musicVolume
	{
		get
		{
			return data.musicVolume;
		}
		set
		{
			data.musicVolume = value;
			if (musicMenu.isPlaying && value < 0.05f)
			{
				musicMenu.Stop();
			}
			else if (!musicMenu.isPlaying && value > 0.05f)
			{
				musicMenu.Play();
			}
			musicMenu.volume = 0.7f * data.musicVolume;
		}
	}

	public event Action onSoundVolumeChange;

	public void OnDestroy()
	{
		mInstance = null;
	}

	public void DisableMusic()
	{
		musicMenu.volume = 0f;
	}

	public void EnableMusic()
	{
		musicMenu.volume = 0.7f * data.musicVolume;
	}

	protected override void Awake()
	{
		if (!Application.isPlaying)
		{
			return;
		}
		base.Awake();
		mAllSounds = new Dictionary<KJGDNLHKPOG, SoundEntry2D>();
		foreach (SoundEntry2D soundEntry in SoundEntries)
		{
			mAllSounds[soundEntry.soundEnum] = soundEntry;
		}
		Singleton<GameController>.instance.GameEnded += InstanceOnGameEnded;
		UIButtonSound.onClicked = PlayButtonClickedSound;
		_audioSource = base.gameObject.GetComponent<AudioSource>() ?? base.gameObject.AddComponent<AudioSource>();
		StartCoroutine(StartMenuMusic());
		if (autoLoad)
		{
			LoadSounds();
		}
	}

	[DebuggerHidden]
	private IEnumerator StartMenuMusic()
	{
		BJNCMCLNONK bJNCMCLNONK = new BJNCMCLNONK();
		bJNCMCLNONK.BJGCPDNMHDH = this;
		return bJNCMCLNONK;
	}

	[DebuggerHidden]
	private IEnumerator StartGameMusic()
	{
		KALJKDABPFH kALJKDABPFH = new KALJKDABPFH();
		kALJKDABPFH.BJGCPDNMHDH = this;
		return kALJKDABPFH;
	}

	[DebuggerHidden]
	private IEnumerator LoadMusic(string musicName)
	{
		DIOIAJMAFJH dIOIAJMAFJH = new DIOIAJMAFJH();
		dIOIAJMAFJH.JMLGMFFKGNM = musicName;
		dIOIAJMAFJH.BJGCPDNMHDH = this;
		return dIOIAJMAFJH;
	}

	private void InstanceOnGameEnded(GameController.HKGHCIEPGEL obj)
	{
		mMusicFadingOut = false;
		if (data.musicVolume > 0.05f)
		{
			musicMenu.Play();
		}
		musicMenu.volume = 0.7f * data.musicVolume;
		StartCoroutine(StartMenuMusic());
	}

	[DebuggerHidden]
	private IEnumerator DoFadeOut(AudioSource audio, float timeToFade, float volume)
	{
		LJNIJIFPHDB lJNIJIFPHDB = new LJNIJIFPHDB();
		lJNIJIFPHDB.MPAMHAEDKBO = volume;
		lJNIJIFPHDB.OGJDHCIOKCB = timeToFade;
		lJNIJIFPHDB.BENGENAMIGD = audio;
		lJNIJIFPHDB.BJGCPDNMHDH = this;
		return lJNIJIFPHDB;
	}

	[DebuggerHidden]
	private IEnumerator DoFadeIn(AudioSource audio, float timeToFade, float volume)
	{
		FLBEAODJGOP fLBEAODJGOP = new FLBEAODJGOP();
		fLBEAODJGOP.BENGENAMIGD = audio;
		fLBEAODJGOP.MPAMHAEDKBO = volume;
		fLBEAODJGOP.OGJDHCIOKCB = timeToFade;
		fLBEAODJGOP.BJGCPDNMHDH = this;
		return fLBEAODJGOP;
	}

	public void PlaySound(AudioClip sound, float volume = 1f)
	{
		if (data.soundVolume > 0.01f)
		{
			_audioSource.PlayOneShot(sound, volume * data.soundVolume);
		}
	}

	public void PlayButtonClickedSound()
	{
		PlaySound(KJGDNLHKPOG.Button);
	}

	public void PlaySound(KJGDNLHKPOG sound, float volume = 1f)
	{
		SoundEntry2D value;
		if (mAllSounds.TryGetValue(sound, out value))
		{
			_audioSource.PlayOneShot(value.JDHABINEKIL(), volume * value.volume * data.soundVolume);
		}
	}

	public void PlayGameMusic()
	{
		mMusicFadingIn = false;
		musicMenu.Stop();
		mClipsCounter++;
		StartCoroutine(StartGameMusic());
	}

	public void LoadSounds()
	{
		foreach (SoundEntry2D soundEntry in SoundEntries)
		{
			soundEntry.EMLFJBOLENO();
		}
	}

	public void UnloadSounds()
	{
		foreach (SoundEntry2D soundEntry in SoundEntries)
		{
			soundEntry.LDEBDKKGBLP();
		}
	}

	public void UseSound(KJGDNLHKPOG sound)
	{
		SoundEntry2D value;
		if (mAllSounds.TryGetValue(sound, out value))
		{
			value.JPDKBDALGKL();
		}
	}
}
