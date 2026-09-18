using System;
using System.Collections;
using System.Collections.Generic;
using Beebyte.Obfuscator;
using UnityEngine;

[Skip]
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
		OpenLootboxLegendary
	}

	[Serializable]
	public class SoundEntry2D : SoundEntry
	{
		[SerializeField]
		public SoundsEnum soundEnum;
	}

	[Skip]
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

	private static SoundsManager mInstance;

	public AudioSource musicMenu;

	private string mMenuAssetBundle = "audio/menu";

	private readonly string[] mGameAssetBundles = new string[2] { "audio/game0", "audio/game1" };

	private AudioClip mMusicClip;

	public List<SoundEntry2D> SoundEntries;

	private Dictionary<SoundsEnum, SoundEntry2D> mAllSounds;

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
		mAllSounds = new Dictionary<SoundsEnum, SoundEntry2D>();
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

	private IEnumerator StartMenuMusic()
	{
		yield return null;
		yield return null;
		yield return StartCoroutine(LoadMusic(mMenuAssetBundle));
		if (data.musicVolume > 0.05f)
		{
			StartCoroutine(DoFadeIn(musicMenu, 2f, 0.7f));
		}
	}

	private IEnumerator StartGameMusic()
	{
		yield return StartCoroutine(LoadMusic(mGameAssetBundles[UnityEngine.Random.Range(0, mGameAssetBundles.Length)]));
		musicMenu.Play();
		musicMenu.volume = 0.35f * data.musicVolume;
	}

	private IEnumerator LoadMusic(string musicName)
	{
		mMusicClip = Resources.Load<AudioClip>(musicName);
		musicMenu.clip = mMusicClip;
		yield break;
	}

	private void InstanceOnGameEnded(GameController.GameEndReason obj)
	{
		mMusicFadingOut = false;
		if (data.musicVolume > 0.05f)
		{
			musicMenu.Play();
		}
		musicMenu.volume = 0.7f * data.musicVolume;
		StartCoroutine(StartMenuMusic());
	}

	private IEnumerator DoFadeOut(AudioSource audio, float timeToFade, float volume)
	{
		float startTime = Time.time;
		float elapsedTime = 0f;
		do
		{
			elapsedTime = Time.time - startTime;
			audio.volume = Mathf.Lerp(volume, 0f, elapsedTime / timeToFade);
			yield return null;
		}
		while (mMusicFadingOut && elapsedTime < timeToFade);
		if (!mMusicFadingIn)
		{
			mMusicFadingIn = false;
			audio.Stop();
		}
	}

	private IEnumerator DoFadeIn(AudioSource audio, float timeToFade, float volume)
	{
		audio.Play();
		mMusicFadingIn = true;
		float startTime = Time.time;
		float elapsedTime = 0f;
		do
		{
			elapsedTime = Time.time - startTime;
			audio.volume = Mathf.Lerp(0f, volume * data.musicVolume, elapsedTime / timeToFade);
			yield return null;
		}
		while (mMusicFadingIn && elapsedTime < timeToFade);
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
		PlaySound(SoundsEnum.Button);
	}

	public void PlaySound(SoundsEnum sound, float volume = 1f)
	{
		if (mAllSounds.TryGetValue(sound, out var value))
		{
			_audioSource.PlayOneShot(value.GetClip(), volume * value.volume * data.soundVolume);
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
			soundEntry.Load();
		}
	}

	public void UnloadSounds()
	{
		foreach (SoundEntry2D soundEntry in SoundEntries)
		{
			soundEntry.UnLoad();
		}
	}

	public void UseSound(SoundsEnum sound)
	{
		if (mAllSounds.TryGetValue(sound, out var value))
		{
			value.MarkAsUsed();
		}
	}
}
