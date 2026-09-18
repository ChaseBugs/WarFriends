using UnityEngine.AI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardAirstrike : Card
{
	public float effectTime;

	public float flightTime;

	public float rocketsDropTime;

	public float rocketsDropDistance;

	public float explosionDelay;

	public GameObject flightShadowProjector;

	public GameObject[] rockets;

	public float flightDistance;

	public int explosionCount;

	private bool mAnimate;

	private float mPhase;

	private int mCurrentExplosion;

	private PlayerController mPlayer;

	private List<GameShootableEntity> mVictims = new List<GameShootableEntity>();

	private Vector3 mExplosionsStartPoint;

	private Vector3 mExplosionsEndPoint;

	private Vector3 mExplosionsDirection;

	private float mExplosionLocalDistanceX;

	private float mExplosionLocalDistanceZ;

	private Vector3 mFlightStartPoint;

	private Vector3 mFlightEndPoint;

	private float mViableTimer;

	public override IEnumerator InitCard(bool isOpponentCard)
	{
		mViableTimer = 0f;
		yield break;
	}

	protected void Update()
	{
		if (!mAnimate)
		{
			return;
		}
		mPhase = Mathf.Clamp01(mPhase + Time.deltaTime / effectTime);
		float num = mPhase * effectTime;
		float num2 = Mathf.Clamp01((num - explosionDelay) / (effectTime - explosionDelay));
		float num3 = num / flightTime;
		flightShadowProjector.transform.position = mFlightStartPoint + (mFlightEndPoint - mFlightStartPoint) * num3;
		int num4 = (int)(num2 * (float)explosionCount);
		if (num4 != mCurrentExplosion)
		{
			mCurrentExplosion = num4;
			Vector3 vector = Vector3.Lerp(mExplosionsStartPoint, mExplosionsEndPoint, (float)mCurrentExplosion / (float)explosionCount);
			Explode(GetExplosionPosition(mCurrentExplosion, left: true));
			Explode(GetExplosionPosition(mCurrentExplosion, left: false));
			foreach (GameShootableEntity mVictim in mVictims)
			{
				bool flag = Vector3.Dot(mVictim.transform.position - vector, mExplosionsDirection) > 0f || mCurrentExplosion == explosionCount;
				if (!mVictim.destroyableObject.isDead && flag)
				{
					mVictim.destroyableObject.Suicide(mVictim.destroyableObject.maxHealth, Vector3.zero, null, mPlayer, isNetworkCopy: false);
				}
			}
		}
		if (mPhase >= 1f)
		{
			mAnimate = false;
			flightShadowProjector.SetActive(value: false);
		}
	}

	private void Explode(Vector3 position)
	{
		Explosion.ExplosionInfo explosionInfo = new Explosion.ExplosionInfo();
		explosionInfo.position = position;
		explosionInfo.explodeDamage = 0f;
		explosionInfo.damageAmount = 0f;
		explosionInfo.owner = mPlayer;
		explosionInfo.isNetworkCopy = true;
		explosionInfo.exposionCoef = new Vector3(5f, 8f, 5f);
		explosionInfo.deadRadius = 1.5f;
		explosionInfo.hurtRadius = 2.2f;
		explosionInfo.type = Explosion.ExplosionType.Big;
		Explosion.ExplosionInfo i = explosionInfo;
		Explosion.Explode(i);
	}

	private IEnumerator RocketsDrop()
	{
		yield return new WaitForSeconds(explosionDelay);
		for (int explosionIndex = 1; explosionIndex <= explosionCount; explosionIndex++)
		{
			yield return new WaitForSeconds((effectTime - explosionDelay) / (float)explosionCount - rocketsDropTime);
			rockets[0].SetActive(value: true);
			rockets[1].SetActive(value: true);
			Vector3 position0 = GetExplosionPosition(explosionIndex, left: true);
			Vector3 position1 = GetExplosionPosition(explosionIndex, left: false);
			float phase = 0f;
			while (phase < 1f)
			{
				phase = Mathf.Clamp01(phase + Time.deltaTime / rocketsDropTime);
				rockets[0].transform.position = position0 + Vector3.up * (1f - phase) * rocketsDropDistance;
				rockets[1].transform.position = position1 + Vector3.up * (1f - phase) * rocketsDropDistance;
				yield return 0;
			}
			rockets[0].SetActive(value: false);
			rockets[1].SetActive(value: false);
		}
	}

	private Vector3 GetExplosionPosition(int index, bool left)
	{
		Vector3 vector = Vector3.Lerp(mExplosionsStartPoint, mExplosionsEndPoint, (float)index / (float)explosionCount);
		Vector3 sourcePosition = vector + mExplosionsDirection * mExplosionLocalDistanceX + ((!left) ? (-Vector3.forward * mExplosionLocalDistanceZ) : (Vector3.forward * mExplosionLocalDistanceZ));
		NavMesh.SamplePosition(sourcePosition, out var hit, 10f, 1);
		return hit.position;
	}

	private void InitAirstrike(Fractions fraction, bool killUnits)
	{
		SoundsManager.Instance.PlaySound(SoundsManager.SoundsEnum.AirStrikeJet);
		mAnimate = true;
		mPhase = 0f;
		mCurrentExplosion = 0;
		mPlayer = PlayerController.GetPlayerOld(fraction);
		BoxCollider fieldArea = Singleton<MapManager>.instance.currentMapDef.fieldArea;
		mExplosionsDirection = ((fraction == Fractions.Allies) ? fieldArea.transform.right : (-fieldArea.transform.right));
		mExplosionsStartPoint = fieldArea.transform.position + fieldArea.center + mExplosionsDirection * fieldArea.size.x / 2f;
		mExplosionsEndPoint = mExplosionsStartPoint - mExplosionsDirection * fieldArea.size.x;
		mExplosionLocalDistanceX = fieldArea.size.x / 2f / (float)explosionCount;
		mExplosionLocalDistanceZ = fieldArea.size.z / 6f;
		mFlightStartPoint = fieldArea.transform.position + fieldArea.center + mExplosionsDirection * flightDistance / 2f;
		mFlightEndPoint = mFlightStartPoint - mExplosionsDirection * flightDistance;
		mFlightStartPoint.y = flightShadowProjector.transform.position.y;
		mFlightEndPoint.y = flightShadowProjector.transform.position.y;
		flightShadowProjector.transform.rotation = ((fraction == Fractions.Allies) ? Quaternion.Euler(90f, 270f, 0f) : Quaternion.Euler(90f, 90f, 0f));
		flightShadowProjector.SetActive(value: true);
		mVictims.Clear();
		if (killUnits)
		{
			List<GameShootableEntity> entities = GameShootableEntity.GetEntities(Fractions.Allies);
			foreach (GameShootableEntity item in entities)
			{
				if (item.GetComponent<PlayerController>() == null)
				{
					mVictims.Add(item);
				}
			}
			List<GameShootableEntity> entities2 = GameShootableEntity.GetEntities(Fractions.Enemies);
			foreach (GameShootableEntity item2 in entities2)
			{
				if (item2.GetComponent<PlayerController>() == null)
				{
					mVictims.Add(item2);
				}
			}
		}
		StartCoroutine(RocketsDrop());
	}

	public override void UseCard(ICardManager cardManager, Fractions fraction)
	{
		base.UseCard(cardManager, fraction);
		InitAirstrike(fraction, PhotonNetwork.isMasterClient);
		cardManager.CardWasUsed(this, fraction);
	}

	public override void UseCardOnline(ICardManager cardManager, Fractions fraction)
	{
		base.UseCardOnline(cardManager, fraction);
		if (base.isOnlineMaster)
		{
			InitAirstrike(fraction, killUnits: true);
		}
		if (!mAnimate)
		{
			InitAirstrike(fraction, killUnits: false);
		}
	}

	public override bool IsViableForBotNow(Fractions botFraction, float botHealthRatio, List<GameShootableEntity> botUnits, List<GameShootableEntity> opponentUnits, List<GameShootableEntity> botMechanicalUnits, List<GameShootableEntity> opponentMechanicalUnits)
	{
		BoxCollider fieldArea = Singleton<MapManager>.instance.currentMapDef.fieldArea;
		int num = 0;
		foreach (GameShootableEntity opponentUnit in opponentUnits)
		{
			if (fieldArea.bounds.Contains(opponentUnit.transform.position))
			{
				num++;
			}
		}
		int num2 = 0;
		foreach (GameShootableEntity botUnit in botUnits)
		{
			if (fieldArea.bounds.Contains(botUnit.transform.position))
			{
				num2++;
			}
		}
		if (num - num2 < 4)
		{
			mViableTimer = 0f;
			return false;
		}
		mViableTimer += TimeManager.deltaTimeWithoutPauses;
		if (mViableTimer > 3f)
		{
			return base.IsViableForBotNow(botFraction, botHealthRatio, botUnits, opponentUnits, botMechanicalUnits, opponentMechanicalUnits);
		}
		return false;
	}
}
