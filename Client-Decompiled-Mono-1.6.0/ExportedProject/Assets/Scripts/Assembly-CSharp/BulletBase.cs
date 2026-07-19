using System;
using System.Runtime.CompilerServices;
using UnityEngine;

[RequireComponent(typeof(TweenPosition))]
public abstract class BulletBase : Ammo
{
	public float JPNAINOGAMM = 1f;

	public float EMPGJLEFKAG = 1.5f;

	protected LineTrailRenderer ACPFIFCCKDF;

	protected Vector3 AKPHKLGJBBB;

	protected bool MGCOAMOLGBF;

	public float INJHHNAAOIO = 1f;

	protected BulletSetup GMDKKKBCLAB;

	protected float JGGGDHJEIKB;

	public bool NOLLONIMIGF;

	protected Transform NGCDDPCAGJB;

	public bool OLDPEIALACE;

	private RaycastHit? PJAFEJFGEGH;

	protected RaycastHit? MOLKFKLJIIH
	{
		get
		{
			return PJAFEJFGEGH;
		}
		set
		{
			PJAFEJFGEGH = value;
		}
	}

	public override void OnInstancied()
	{
		base.OnInstancied();
		NOLLONIMIGF = false;
	}

	protected override void Awake()
	{
		base.Awake();
		ACPFIFCCKDF = GetComponent<LineTrailRenderer>();
		NGCDDPCAGJB = base.transform;
	}

	public override void Fire(Vector3 OEIICEJPGKI, Vector3 IIMDKHJAJGO)
	{
		if (JMMJHCOKCGG == null)
		{
			throw new NullReferenceException("WEAPON IS NULL");
		}
	}

	public void AnimateShot(Vector3 OEIICEJPGKI, Vector3 IIMDKHJAJGO, bool DCGHNDLLFHH)
	{
		MGCOAMOLGBF = DCGHNDLLFHH;
		AKPHKLGJBBB = IIMDKHJAJGO - OEIICEJPGKI;
		NGCDDPCAGJB.rotation = Quaternion.LookRotation(OEIICEJPGKI - IIMDKHJAJGO) * Quaternion.AngleAxis(-90f, Vector3.up);
		float num = Vector3.Distance(OEIICEJPGKI, IIMDKHJAJGO);
		float num2 = 1f - Mathf.Clamp01(EMPGJLEFKAG / num);
		if (!MGCOAMOLGBF)
		{
			num2 = 1f;
		}
		Vector3 toPos = OEIICEJPGKI + num2 * AKPHKLGJBBB;
		JPNAINOGAMM = ((!GGJPNLDIGGM) ? JPNAINOGAMM : GMDKKKBCLAB.fakeSpeed);
		float num3 = num / JPNAINOGAMM;
		ACPFIFCCKDF.Reset();
		if (GGJPNLDIGGM)
		{
			if (!string.IsNullOrEmpty(GMDKKKBCLAB.KPPDKJNBHIN))
			{
				ACPFIFCCKDF.SetSprite(GMDKKKBCLAB.KPPDKJNBHIN);
			}
			ACPFIFCCKDF.SetWidth(GMDKKKBCLAB.GetTrailFakeWidth());
			ACPFIFCCKDF.NCLALEDKDAE = INJHHNAAOIO;
			ACPFIFCCKDF.FFPDBEIMELD = TimeManager.GetTimeScaledInterval(INJHHNAAOIO / JPNAINOGAMM, base.ignoreTimeScale);
		}
		else
		{
			if (FJLBLLLEELD == ILIOELBBLDM.Real && !string.IsNullOrEmpty(GMDKKKBCLAB.KLGJDBCMCAA))
			{
				ACPFIFCCKDF.SetSprite(GMDKKKBCLAB.KLGJDBCMCAA);
			}
			if (FJLBLLLEELD == ILIOELBBLDM.Shield && !string.IsNullOrEmpty(GMDKKKBCLAB.ONBKCLKGKKK))
			{
				ACPFIFCCKDF.SetSprite(GMDKKKBCLAB.ONBKCLKGKKK);
			}
			ACPFIFCCKDF.SetWidth(GMDKKKBCLAB.GetTrailWidth());
			ACPFIFCCKDF.NCLALEDKDAE = INJHHNAAOIO * 2f;
			ACPFIFCCKDF.FFPDBEIMELD = TimeManager.GetTimeScaledInterval(INJHHNAAOIO / JPNAINOGAMM, base.ignoreTimeScale);
		}
		if (!GGJPNLDIGGM)
		{
			TweenPosition tweenPosition = TweenPosition.Begin(base.gameObject, num3, OEIICEJPGKI, toPos, false);
			tweenPosition.ignoreTimeScale = base.ignoreTimeScale;
			tweenPosition.method = UITweener.Method.Linear;
			tweenPosition.onFinished = ELCFLLANIKE;
		}
		else
		{
			TweenPosition tweenPosition2 = TweenPosition.Begin(base.gameObject, num3 * 2f, OEIICEJPGKI, IIMDKHJAJGO + AKPHKLGJBBB, false);
			tweenPosition2.onFinished = delegate
			{
				DestroyPooled();
			};
		}
	}

	private void ELCFLLANIKE(UITweener MGDJMGHCAAI)
	{
		CFIPHHJKBCK();
	}

	protected abstract void CFIPHHJKBCK();

	protected virtual void IMCKKOEINGI()
	{
		TweenPosition component = GetComponent<TweenPosition>();
		if ((bool)component)
		{
			component.enabled = false;
		}
		if (MOLKFKLJIIH.HasValue)
		{
			DestroyableObject CMNFMDJEOIK = null;
			if (!(MOLKFKLJIIH.Value.collider != null) || !DoDamage(MOLKFKLJIIH.Value.collider.gameObject, MOLKFKLJIIH.Value, AKPHKLGJBBB.normalized * JGGGDHJEIKB, false, out CMNFMDJEOIK))
			{
				Singleton<HitParticleSystem>.instance.PlayParticle(MOLKFKLJIIH.Value.point, MOLKFKLJIIH.Value.normal, 0);
				DecalSystem.Instance.PlayDecal(MOLKFKLJIIH.Value.point, MOLKFKLJIIH.Value.normal, 0);
			}
			if (JMMJHCOKCGG != null)
			{
				JMMJHCOKCGG.ReportShotHit(this, MOLKFKLJIIH.Value.point, CAKABHIPCDF, CMNFMDJEOIK);
			}
			else
			{
				Debug.LogError("Bullet with NO weapon");
			}
		}
		DestroyPooled(0.5f);
	}

	public override void LoadAmmoSetup(AmmoSetup MBNLFKHLDBH)
	{
		base.LoadAmmoSetup(MBNLFKHLDBH);
		BulletSetup bulletSetup = MBNLFKHLDBH as BulletSetup;
		if (bulletSetup != null)
		{
			GMDKKKBCLAB = bulletSetup;
			JPNAINOGAMM = bulletSetup.bulletSpeed;
			EMPGJLEFKAG = bulletSetup.JCGKIALPJNL;
			INJHHNAAOIO = bulletSetup.GetTrailSize();
			JGGGDHJEIKB = bulletSetup.JGGGDHJEIKB;
		}
		else
		{
			Debug.LogError("You probably assigned bad type of AmmoSetup to gun");
		}
	}

	public override void DestroyPooled()
	{
		base.DestroyPooled();
	}

	[CompilerGenerated]
	private void EEJOAEHLGDB(UITweener MGDJMGHCAAI)
	{
		DestroyPooled();
	}
}
