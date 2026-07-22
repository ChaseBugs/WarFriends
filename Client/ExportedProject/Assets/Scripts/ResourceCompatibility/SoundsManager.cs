using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Scripting;

[ExecuteInEditMode]
public class SoundsManager : InGameSerializedObjectGeneric<SoundsManager.SoundSettingsSerialized>
{
	public enum SoundsEnum
	{
		Button,
		LabelShowGame,
		SwitchWeapon_Primary,
		DeplyUnits,
		Ribbon,
		Critical,
		Buy,
		Upgrade,
		ActivateUpgrade,
		CounterSoundExperience,
		CardEquiped,
		AssigmentCompleted,
		AirStrikeJet,
		CounterSoundMoney,
		OpponentFound,
		Overtime,
		OvertimeAlarm,
		SwitchWeapon_Secondary,
		SwitchWeapon_Explosive,
		SwitchWeapon_Pistol,
		CardReturn,
		AssigmentBarCompleted,
		BootcampDialog,
		BootcampObjectiveComplete,
		BootcampCongratulations,
		BootcampIntro,
		BootcampEnemyPresent,
		BootcampWoosh,
		BootcampUnitPresent,
		BootcampClick,
		BootcampDialogDissapear,
		AssignmentDayCompleted,
		AssignmentMegaReward,
		DogTagUsed,
		LevelUp,
		LevelUpUnlockedItem,
		LeagueIconShowed,
		LeagueRewardShowed,
		EquipWeapon,
		PromoteUnit,
		BuyVIP,
		CardFlip,
		DailyRewardShow,
		DailyRewardClaim,
		DailyVIPCardsShow,
		CoinPurchase,
		KilledInAction,
		FlashEndScreen,
		StarGained,
		CardPlayed,
		EnemyCardPlayed,
		OpponentSearch,
		DogTagGain,
		Fight,
		GameOverWin,
		GameOverLost,
		CraftingStart,
		CraftingClaim,
		CountdownSound,
		StartGameVsSound,
		StartGamePhotoSound,
		OpenLootbox,
		OpenLootboxCompleted,
		OpenLootboxLegendary,
		MissionNewWave,
		MissionWaveCompleted,
		MissionCountdownSound,
		MissionCompleted,
		AugPlayerPlayed,
		AugEnemyPlayed,
		AugCrateOpen,
		AugShown,
		InvasionDogtagLost,
		InvaderSpawned,
		InvaderCountdown,
		Dismantle,
		PulseRifleChargeMax,
		PulseRifleScopeOpen
	}

	[Serializable]
	public class SoundEntry2D : SoundEntry
	{
		[SerializeField]
		public SoundsEnum soundEnum;
	}

	[Preserve]
	public class SoundSettingsSerialized
	{
		public float musicVolume;

		public float soundVolume;
	}

	private static SoundsManager mInstance;

	public AudioSource musicMenu;

	private string mMenuAssetBundle;

	private readonly string[] mGameAssetBundles;

	private AudioClip mMusicClip;

	public List<SoundEntry2D> SoundEntries;

	private Dictionary<SoundsEnum, SoundEntry2D> mAllSounds;

	private AudioListener mListener;

	private AudioSource _audioSource;

	private bool mMusicFadingIn;

	private bool mMusicFadingOut;

	public bool autoLoad;

	public List<AudioClip> clipsForGame;

	private int mClipsCounter;

	public static SoundsManager Instance => null;

	public float soundsVolume
	{
		get
		{
			return 0f;
		}
		set
		{
		}
	}

	public float musicVolume
	{
		get
		{
			return 0f;
		}
		set
		{
		}
	}

	public event Action onSoundVolumeChange
	{
		[CompilerGenerated]
		add
		{
		}
		[CompilerGenerated]
		remove
		{
		}
	}

	public void OnDestroy()
	{
	}

	public void DisableMusic()
	{
	}

	public void EnableMusic()
	{
	}

	protected override void Awake()
	{
	}

	private IEnumerator StartMenuMusic()
	{
		return null;
	}

	private IEnumerator StartGameMusic()
	{
		return null;
	}

	private IEnumerator LoadMusic(string musicName)
	{
		return null;
	}

	private void InstanceOnGameEnded(GameController.ALOAMODMHMO obj)
	{
	}

	private IEnumerator DoFadeOut(AudioSource audio, float timeToFade, float volume)
	{
		return null;
	}

	private IEnumerator DoFadeIn(AudioSource audio, float timeToFade, float volume)
	{
		return null;
	}

	public void PlaySound(AudioClip sound, float volume = 1f)
	{
	}

	public void PlayButtonClickedSound()
	{
	}

	public void PlaySound(SoundsEnum sound, float volume = 1f)
	{
	}

	public void PlayGameMusic()
	{
	}

	public void LoadSounds()
	{
	}

	public void UnloadSounds()
	{
	}

	public void UseSound(SoundsEnum sound)
	{
	}
}
