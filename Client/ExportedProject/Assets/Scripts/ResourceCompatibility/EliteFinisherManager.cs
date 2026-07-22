using System;
using System.Runtime.CompilerServices;
using Google2u;
using UnityEngine;
using UnityEngine.Scripting;

public class EliteFinisherManager : DatabaseSerializedObjectGeneric<EliteFinisherManager.EliteFinisherData>
{
	[Preserve]
	public class EliteFinisherData
	{
		public int offerExpiration;

		public string packId;

		public string unitName;
	}

	[SerializeField]
	private EliteFinisherPacks mConfigs;

	[CompilerGenerated]
	private Action POMILDDPJMJ;

	private static EliteFinisherManager DJDBDKFAKHN;

	public static EliteFinisherManager instance => null;

	public int warbucks => 0;

	public int parts => 0;

	public int scraps => 0;

	public LevelBehaviour unitBehaviour => null;

	public string currentPriceWithCurrency => null;

	public int deadline
	{
		get
		{
			return 0;
		}
		set
		{
		}
	}

	public bool isOfferActive => false;

	public int timeUntilExpiration => 0;

	public bool isLoaded => false;

	public BHDAFNGBMHF eliteFiniherPack => null;

	private EliteFinisherPacks.rowIds BHCIHPIBPLJ => default(EliteFinisherPacks.rowIds);

	public event Action LoadedOfferEliteFinisher
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

	private void ANICBIBDDDO()
	{
	}

	protected override void Awake()
	{
	}

	public void LoadEliteFinisherOffer(string CLHAAFBCFIF)
	{
	}

	private void EFANDMMKBND()
	{
	}
}
