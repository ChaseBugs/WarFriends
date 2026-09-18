using CodeStage.AntiCheat.Detectors;
using CodeStage.AntiCheat.ObscuredTypes;
using UnityEngine;

public class AntiCheatDetector : Singleton<AntiCheatDetector>
{
	public enum Cheat
	{
		MemoryHack,
		SpeedHack,
		PlayerPrefsHack,
		JailBreak
	}

	public string x1;

	public string y2;

	public bool playerCheated { get; private set; }

	public Cheat cheatType { get; private set; }

	protected override void Awake()
	{
		base.Awake();
		ObscuredCheatingDetector.StartDetection(OnMemoryTampered);
		ObscuredPrefs.onAlterationDetected += OnPlayerPrefsHack;
		SpeedHackDetector.StartDetection(OnSpeedHackDetected);
		CheckJailBreak();
	}

	private void CheckJailBreak()
	{
		if (BundleVersionBindings.IsJailBreak())
		{
			playerCheated = true;
			cheatType = Cheat.JailBreak;
			Debug.LogError("ACD: Phone jail braked");
		}
	}

	public void TestHack()
	{
		OnMemoryTampered();
	}

	public void Clear()
	{
		playerCheated = false;
	}

	private void OnSpeedHackDetected()
	{
		Debug.LogError("ACD: Speedhack detected!");
		playerCheated = true;
		cheatType = Cheat.SpeedHack;
	}

	private void OnPlayerPrefsHack()
	{
		Debug.LogError("ACD: Player prefs were hacked!");
		playerCheated = true;
		cheatType = Cheat.PlayerPrefsHack;
	}

	private void OnMemoryTampered()
	{
		Debug.LogError("ACD: Memory was tampered, cheater detected!");
		playerCheated = true;
		cheatType = Cheat.MemoryHack;
	}
}
