using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEngine.Scripting;

public sealed class TournamentsManager : DatabaseSerializedObjectGeneric<TournamentsManager.TournamentsData>
{
	[Preserve]
	public sealed class TournamentsData
	{
		[JsonProperty]
		public float damageToEnemyUnits;

		[JsonProperty]
		public float damageToEnemyPlayer;

		[JsonProperty]
		public int unitsSpawned;

		[JsonProperty]
		public int criticalHits;

		[JsonProperty]
		public float accuracy;

		[JsonProperty]
		public int cratesStolen;

		[JsonProperty]
		public bool survivor;

		[JsonProperty]
		public bool untouchable;

		[JsonProperty]
		public int bestUnit;

		[JsonProperty]
		public float bestUnitDamage;

		[JsonProperty]
		public string lastHitOwnerId;

		[JsonProperty]
		public int bestWeapon;

		[JsonProperty]
		public float bestWeaponDamage;
	}

	private const float ALOOEDLBBIO = 0.05f;

	private static TournamentsManager DJDBDKFAKHN;

	public Dictionary<int, float> BNGHOCKICGC;

	public Dictionary<int, float> PPPCBKKHKPK;

	private DestroyableObject.LDOKCBNNLCH? KBOCKCAFDHA;

	public float survivorHealthRatio => 0f;

	public static TournamentsManager instance => null;

	public DestroyableObject.LDOKCBNNLCH? opponentLastHitDamageInfo
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

	private static string CJHGNBJBBPC(DestroyableObject.LDOKCBNNLCH KJBEGLIAFJA)
	{
		return null;
	}

	protected override void Awake()
	{
	}

	private void OnDestroy()
	{
	}

	private void DJIKBALBFCM()
	{
	}

	private void OIDBKOGLAHP(DestroyableObject KIHIFIBOOIM, DestroyableObject.LDOKCBNNLCH INADGPICPMO)
	{
	}

	public void Evaluate(GameController.ALOAMODMHMO DFEHIADKKNO)
	{
	}

	internal string NKMPKFMMOBH()
	{
		return null;
	}
}
