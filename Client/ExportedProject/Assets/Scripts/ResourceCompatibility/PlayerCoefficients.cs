using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerCoefficients : MonoBehaviour
{
	public delegate void OCEBMLNCFJF(float GHMOCCOCDNO, float BBGNGLEDNCC);

	private PhotonView IBBJLFJLAFA;

	private HHKLMPHEBFH OEFGINFPFCE;

	[CompilerGenerated]
	private float _003CAKBDIKJDGHO_003Ek__BackingField;

	[CompilerGenerated]
	private float _003CHMCDNOIDCAP_003Ek__BackingField;

	[CompilerGenerated]
	private float _003CKBELPNPAGKI_003Ek__BackingField;

	[CompilerGenerated]
	private float _003CKMBPOIMFLDF_003Ek__BackingField;

	[CompilerGenerated]
	private float _003CBDJFPIMNLFD_003Ek__BackingField;

	[CompilerGenerated]
	private float _003CCDEIGLCIMIJ_003Ek__BackingField;

	[CompilerGenerated]
	private OCEBMLNCFJF IEBAOAOHJOO;

	[CompilerGenerated]
	private OCEBMLNCFJF JPFFAJHIJDM;

	[CompilerGenerated]
	private OCEBMLNCFJF OPNKCFBLLKC;

	[CompilerGenerated]
	private float _003CECPIPOKNNOG_003Ek__BackingField;

	[CompilerGenerated]
	private float _003CCIMAFJAJIHN_003Ek__BackingField;

	[CompilerGenerated]
	private float _003CDBOJDKJHLMM_003Ek__BackingField;

	[CompilerGenerated]
	private float _003CLNICCLACFDJ_003Ek__BackingField;

	[CompilerGenerated]
	private float _003CDBDPPGNMPHB_003Ek__BackingField;

	[CompilerGenerated]
	private float _003CMOMBAPEHBIA_003Ek__BackingField;

	public float unitDeploymentCooldown
	{
		[CompilerGenerated]
		get
		{
			return 0f;
		}
		[CompilerGenerated]
		private set
		{
		}
	}

	public float warcardUsageCooldown
	{
		[CompilerGenerated]
		get
		{
			return 0f;
		}
		[CompilerGenerated]
		private set
		{
		}
	}

	public float scorestreakGain
	{
		[CompilerGenerated]
		get
		{
			return 0f;
		}
		[CompilerGenerated]
		private set
		{
		}
	}

	public float scorestreakBoxReward
	{
		[CompilerGenerated]
		get
		{
			return 0f;
		}
		[CompilerGenerated]
		private set
		{
		}
	}

	public float movementSpeed
	{
		[CompilerGenerated]
		get
		{
			return 0f;
		}
		[CompilerGenerated]
		private set
		{
		}
	}

	public float healingMultiplier
	{
		[CompilerGenerated]
		get
		{
			return 0f;
		}
		[CompilerGenerated]
		private set
		{
		}
	}

	public float warcardsDisabledUntil
	{
		[CompilerGenerated]
		get
		{
			return 0f;
		}
		[CompilerGenerated]
		private set
		{
		}
	}

	public float totalWarcardDisableDuration
	{
		[CompilerGenerated]
		get
		{
			return 0f;
		}
		[CompilerGenerated]
		private set
		{
		}
	}

	public float warcardDisableProgress => 0f;

	public bool IsWarcardUsageDisabled => false;

	public float healingBlockedUntil
	{
		[CompilerGenerated]
		get
		{
			return 0f;
		}
		[CompilerGenerated]
		private set
		{
		}
	}

	public float totalHealingBlockedDuration
	{
		[CompilerGenerated]
		get
		{
			return 0f;
		}
		[CompilerGenerated]
		private set
		{
		}
	}

	public bool IsHealingBlocked => false;

	public float augCannotTriggerUntil
	{
		[CompilerGenerated]
		get
		{
			return 0f;
		}
		[CompilerGenerated]
		private set
		{
		}
	}

	public float totalAugCannotTriggerDuration
	{
		[CompilerGenerated]
		get
		{
			return 0f;
		}
		[CompilerGenerated]
		private set
		{
		}
	}

	public bool IsAugCannotTrigger => false;

	public event OCEBMLNCFJF onUnitDeploymentCooldownChanged
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

	public event OCEBMLNCFJF onWarcardUsageCooldownChanged
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

	public event OCEBMLNCFJF onMovementSpeedChanged
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

	private void Awake()
	{
	}

	private void Start()
	{
	}

	private void OnDestroy()
	{
	}

	private void MGPIKMNCAGO()
	{
	}

	public void MultiplyUnitDeploymentCooldown(float HHDCBKDKICG)
	{
	}

	[PunRPC]
	private void MultiplyUnitDeploymentCooldownRPC(float HHDCBKDKICG)
	{
	}

	public void MultiplyWarcardUsageCooldown(float HHDCBKDKICG)
	{
	}

	[PunRPC]
	private void MultiplyWarcardUsageCooldownRPC(float HHDCBKDKICG)
	{
	}

	public void MultiplyScorestreakGain(float HHDCBKDKICG)
	{
	}

	[PunRPC]
	private void MultiplyScorestreakGainRPC(float HHDCBKDKICG)
	{
	}

	public void MultiplyScorestreakBoxReward(float HHDCBKDKICG)
	{
	}

	[PunRPC]
	private void MultiplyScorestreakBoxRewardRPC(float HHDCBKDKICG)
	{
	}

	public void BlockUnitType(LevelBehaviour.UnitType AHCLLPDBLGB)
	{
	}

	[PunRPC]
	private void BlockUnitTypeRPC(int JONLPHAJEFI)
	{
	}

	public void UnblockUnitType(LevelBehaviour.UnitType AHCLLPDBLGB)
	{
	}

	[PunRPC]
	private void UnblockUnitTypeRPC(int JONLPHAJEFI)
	{
	}

	public bool IsUnitBlocked(LevelBehaviour.UnitType AHCLLPDBLGB)
	{
		return false;
	}

	public void MultiplyMovementSpeed(float HHDCBKDKICG)
	{
	}

	[PunRPC]
	private void MultiplyMovementSpeedRPC(float HHDCBKDKICG)
	{
	}

	public void DisableWarcardUsage(float OBENMFCILPH)
	{
	}

	[PunRPC]
	private void DisableWarcardUsageRPC(float OBENMFCILPH)
	{
	}

	public void BlockHealing(float OBENMFCILPH)
	{
	}

	[PunRPC]
	private void BlockHealingRPC(float OBENMFCILPH)
	{
	}

	public void AugCannotTrigger(float OBENMFCILPH)
	{
	}

	[PunRPC]
	private void AugCannotTriggerRPC(float OBENMFCILPH)
	{
	}

	public void MultiplyHealingEffect(float HHDCBKDKICG)
	{
	}

	[PunRPC]
	private void MultiplyHealingEffectRPC(float HHDCBKDKICG)
	{
	}
}
