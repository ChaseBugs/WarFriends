using UnityEngine;

public class WSP_LaserBeamWS : MonoBehaviour
{
	public bool LaserBeamActive;

	public ParticleSystem LevelUpEffect;

	public Renderer[] LevelIndicatorRenderers;

	public Renderer TurretColorRender;

	public Transform LaserFireEmitPointTrans;

	public ParticleSystem LaserFireCenterEmitter;

	public float FiringParticleSize = 1f;

	public Transform TargetHitTransform;

	public ParticleSystem TargetHitEmitter;

	public float HitParticleSize = 1f;

	public LineRenderer InnerLaserLineRender;

	public LineRenderer OuterLaserLineRender;

	public Color LaserBeamColor;

	public Material LaserYBeamMaterial;

	private Vector3 laserStartPoint = Vector3.zero;

	private Vector3 laserEndPoint = Vector3.zero;

	public bool LaserFiring;

	public float InnerLaserStartWidth = 1f;

	public float InnerLaserEndWidth = 1f;

	public float OuterLaserStartWidth = 1f;

	public float OuterLaserEndWidth = 1f;

	public float LaserGrowSpeed = 1f;

	public float innerLaserTileAmount = 1f;

	private float innerLaserStartWidth = 1f;

	private float innerLaserEndWidth = 1f;

	public float outerLaserTileAmount = 1f;

	private float outerLaserStartWidth = 1f;

	private float outerLaserEndWidth = 1f;

	public float FireSpeed = 20f;

	public bool OffsetMaterialTexture = true;

	public float ScrollSpeed = 2.5f;

	private float laserLifeTimer;

	public float LaserFireTime = 1f;

	public Transform CurrentTarget;

	public void UpdateLevelIndicators(int levelIn, Color levelColorIn)
	{
		if (!(LevelUpEffect != null))
		{
			return;
		}
		LevelUpEffect.startColor = levelColorIn;
		LevelUpEffect.Play();
		if (LevelIndicatorRenderers.Length <= 0)
		{
			return;
		}
		for (int i = 0; i < LevelIndicatorRenderers.Length; i++)
		{
			if (i <= levelIn)
			{
				if (!LevelIndicatorRenderers[i].gameObject.activeSelf)
				{
					LevelIndicatorRenderers[i].gameObject.SetActive(value: true);
				}
			}
			else if (LevelIndicatorRenderers[i].gameObject.activeSelf)
			{
				LevelIndicatorRenderers[i].gameObject.SetActive(value: false);
			}
			LevelIndicatorRenderers[i].material.color = levelColorIn;
		}
	}

	public void AssignNewTarget(Transform target)
	{
		if (CurrentTarget == null)
		{
			CurrentTarget = target;
			FireLaser();
		}
	}

	public void FireLaser()
	{
		InnerLaserLineRender.SetColors(LaserBeamColor, LaserBeamColor);
		if ((bool)OuterLaserLineRender)
		{
			OuterLaserLineRender.SetColors(LaserBeamColor, LaserBeamColor);
		}
		LaserFireCenterEmitter.startColor = LaserBeamColor;
		TargetHitEmitter.startColor = LaserBeamColor;
		innerLaserStartWidth = 0f;
		innerLaserEndWidth = 0f;
		outerLaserStartWidth = 0f;
		outerLaserEndWidth = 0f;
		laserLifeTimer = 0f;
		LaserFiring = true;
	}

	public void StopLaserFire()
	{
		LaserFireCenterEmitter.emissionRate = 0f;
		LaserFiring = false;
	}

	private void Start()
	{
		if (LaserFireCenterEmitter != null)
		{
			LaserFireCenterEmitter.emissionRate = 0f;
		}
		if (TargetHitEmitter != null)
		{
			TargetHitEmitter.emissionRate = 0f;
		}
		if (InnerLaserLineRender != null)
		{
			InnerLaserLineRender.enabled = false;
		}
		if (OuterLaserLineRender != null)
		{
			OuterLaserLineRender.enabled = false;
		}
	}

	private void Update()
	{
		if (((bool)OuterLaserLineRender && OuterLaserLineRender.enabled) || InnerLaserLineRender.enabled)
		{
			LaserBeamActive = true;
		}
		else
		{
			LaserBeamActive = false;
		}
		if (LaserFiring)
		{
			if (laserLifeTimer < LaserFireTime)
			{
				laserLifeTimer += Time.deltaTime;
			}
			else
			{
				laserLifeTimer = 0f;
				StopLaserFire();
			}
		}
		UpdateLaserBeam();
	}

	public void UpdateLaserBeamTiling()
	{
		InnerLaserLineRender.material.mainTextureScale = new Vector2(innerLaserTileAmount, 1f);
		if ((bool)OuterLaserLineRender)
		{
			OuterLaserLineRender.material.mainTextureScale = new Vector2(outerLaserTileAmount, 1f);
		}
	}

	private void UpdateLaserBeam()
	{
		if (LaserFireCenterEmitter.startSize != FiringParticleSize)
		{
			LaserFireCenterEmitter.startSize = FiringParticleSize;
		}
		if (TargetHitEmitter.startSize != HitParticleSize)
		{
			TargetHitEmitter.startSize = HitParticleSize;
		}
		laserStartPoint = LaserFireEmitPointTrans.position;
		if (CurrentTarget != null && LaserFiring)
		{
			LaserFireCenterEmitter.emissionRate = 10f;
			if (innerLaserStartWidth < InnerLaserStartWidth)
			{
				innerLaserStartWidth += LaserGrowSpeed * Time.deltaTime;
			}
			if (innerLaserEndWidth < InnerLaserEndWidth)
			{
				innerLaserEndWidth += LaserGrowSpeed * Time.deltaTime;
			}
			if (outerLaserStartWidth < OuterLaserStartWidth)
			{
				outerLaserStartWidth += LaserGrowSpeed * Time.deltaTime;
			}
			if (outerLaserEndWidth < OuterLaserEndWidth)
			{
				outerLaserEndWidth += LaserGrowSpeed * Time.deltaTime;
			}
			InnerLaserLineRender.SetWidth(innerLaserStartWidth, innerLaserEndWidth);
			if ((bool)OuterLaserLineRender)
			{
				OuterLaserLineRender.SetWidth(outerLaserStartWidth, outerLaserEndWidth);
			}
			if (!InnerLaserLineRender.enabled)
			{
				InnerLaserLineRender.enabled = true;
			}
			if ((bool)OuterLaserLineRender && !OuterLaserLineRender.enabled)
			{
				OuterLaserLineRender.enabled = true;
			}
			Vector3 position = CurrentTarget.position;
			float num = Vector3.Distance(laserEndPoint, position);
			if (num > 1f)
			{
				laserEndPoint = Vector3.Lerp(laserEndPoint, position, FireSpeed * Time.deltaTime);
				TargetHitEmitter.emissionRate = 0f;
			}
			else
			{
				laserEndPoint = position;
				TargetHitTransform.position = position;
				TargetHitEmitter.emissionRate = 10f;
			}
			if (OffsetMaterialTexture)
			{
				float num2 = Time.time * ScrollSpeed;
				InnerLaserLineRender.material.SetTextureOffset("_MainTex", new Vector2(0f - num2, 0f));
			}
		}
		else
		{
			if (InnerLaserLineRender.enabled)
			{
				InnerLaserLineRender.enabled = false;
			}
			if ((bool)OuterLaserLineRender && OuterLaserLineRender.enabled)
			{
				OuterLaserLineRender.enabled = false;
			}
			LaserFireCenterEmitter.emissionRate = 0f;
			TargetHitEmitter.emissionRate = 0f;
			laserEndPoint = laserStartPoint;
		}
		if (InnerLaserLineRender != null)
		{
			InnerLaserLineRender.SetPosition(0, laserStartPoint);
			InnerLaserLineRender.SetPosition(1, laserEndPoint);
		}
		if (OuterLaserLineRender != null)
		{
			laserStartPoint.y += 0.1f;
			laserEndPoint.y += 0.1f;
			OuterLaserLineRender.SetPosition(0, laserStartPoint);
			OuterLaserLineRender.SetPosition(1, laserEndPoint);
		}
	}
}
