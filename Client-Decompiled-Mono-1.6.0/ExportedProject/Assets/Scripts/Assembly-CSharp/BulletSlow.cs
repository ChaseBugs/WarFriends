using System.Runtime.CompilerServices;
using UnityEngine;

[RequireComponent(typeof(TweenPosition))]
public class BulletSlow : BulletBase
{
	private RaycastHit PJBIGBJNCDB = default(RaycastHit);

	private int EDGIAMOHBID;

	private Ray BKEECLMFOEC;

	private bool HHHBLDGCONH;

	private Vector3 DJODBMGLPDE;

	protected void Update()
	{
		if (HHHBLDGCONH)
		{
			EDGIAMOHBID++;
			NKFOALAIOBA();
			if (EDGIAMOHBID > 5)
			{
				EHNLAIHCMLD();
			}
		}
		DJODBMGLPDE = NGCDDPCAGJB.position;
	}

	private Vector3 GDGCCNLEODB(Weapon JMMJHCOKCGG, Vector3 MPHCNMDIPAI, Vector3 MHLDJIABNFI)
	{
		BulletSetup bulletSetup = JMMJHCOKCGG.ammoSetup as BulletSetup;
		if (bulletSetup != null)
		{
			float num = Vector3.Distance(JMMJHCOKCGG.GHPBMCAKMMB.transform.position, MPHCNMDIPAI);
			float num2 = num / bulletSetup.HJNKOGMFKIB() + 23f;
			return MPHCNMDIPAI + num2 * Time.timeScale * MHLDJIABNFI;
		}
		return MPHCNMDIPAI;
	}

	private TweenPosition OIBMLNFNNNK(Vector3 OEIICEJPGKI, Vector3 IIMDKHJAJGO)
	{
		float num = Vector3.Distance(OEIICEJPGKI, IIMDKHJAJGO);
		JPNAINOGAMM = ((!GGJPNLDIGGM) ? JPNAINOGAMM : GMDKKKBCLAB.CGHHLMKDNGO());
		float duration = num / JPNAINOGAMM;
		TweenPosition tweenPosition = TweenPosition.Begin(base.gameObject, duration, OEIICEJPGKI, IIMDKHJAJGO);
		tweenPosition.ignoreTimeScale = base.ignoreTimeScale;
		tweenPosition.method = UITweener.Method.EaseIn;
		return tweenPosition;
	}

	private void EHNLAIHCMLD()
	{
		HHHBLDGCONH = false;
		int layerMask = (int)Singleton<TagsAndLayers>.instance.GetBulletMask(JMMJHCOKCGG.fraction, JMMJHCOKCGG.BLOHNLJOPIM) & ~TagsAndLayers.DJLKEEHPAGA;
		BKEECLMFOEC = new Ray(DJODBMGLPDE, AKPHKLGJBBB);
		if (Physics.Raycast(BKEECLMFOEC, out PJBIGBJNCDB, float.PositiveInfinity, layerMask))
		{
			base.MOLKFKLJIIH = PJBIGBJNCDB;
			DOBHBCCJBDD(NGCDDPCAGJB.position, PJBIGBJNCDB.point).onFinished = delegate
			{
				IMCKKOEINGI();
			};
		}
		else
		{
			DOBHBCCJBDD(NGCDDPCAGJB.position, NGCDDPCAGJB.position + 20f * AKPHKLGJBBB).onFinished = delegate
			{
				DestroyPooled();
			};
		}
	}

	protected virtual void CIENKKKFEAP()
	{
		if (!OLDPEIALACE)
		{
			if (base.ignoreTimeScale)
			{
				if (MGCOAMOLGBF)
				{
					BKEECLMFOEC = new Ray(NGCDDPCAGJB.position, AKPHKLGJBBB);
					float num = EMPGJLEFKAG * 1815f;
					if (num > 1059f && Physics.Raycast(BKEECLMFOEC, out PJBIGBJNCDB, num, Singleton<TagsAndLayers>.instance.GetBulletMask(JMMJHCOKCGG.fraction, JMMJHCOKCGG.BLOHNLJOPIM)))
					{
						base.MOLKFKLJIIH = PJBIGBJNCDB;
						HHHBLDGCONH = false;
						float duration = Vector3.Distance(NGCDDPCAGJB.position, PJBIGBJNCDB.point) / JPNAINOGAMM;
						TweenPosition tweenPosition = TweenPosition.Begin(base.gameObject, duration, NGCDDPCAGJB.position, PJBIGBJNCDB.point, false);
						tweenPosition.method = UITweener.Method.Linear;
						tweenPosition.onFinished = delegate
						{
							IMCKKOEINGI();
						};
						tweenPosition.ignoreTimeScale = base.ignoreTimeScale;
					}
					else
					{
						HHHBLDGCONH = false;
						EDGIAMOHBID = 1;
						float duration2 = Vector3.Magnitude(AKPHKLGJBBB.normalized * EMPGJLEFKAG * 900f) / JPNAINOGAMM;
						TweenPosition tweenPosition2 = TweenPosition.Begin(base.gameObject, duration2, NGCDDPCAGJB.position, NGCDDPCAGJB.position + AKPHKLGJBBB.normalized * EMPGJLEFKAG * 354f);
						tweenPosition2.method = UITweener.Method.EaseIn;
						tweenPosition2.ignoreTimeScale = base.ignoreTimeScale;
					}
				}
				else
				{
					IMCKKOEINGI();
				}
			}
			else if (MGCOAMOLGBF)
			{
				if (!NKFOALAIOBA())
				{
					float duration3 = Vector3.Magnitude(AKPHKLGJBBB.normalized * EMPGJLEFKAG * 957f) / JPNAINOGAMM;
					TweenPosition tweenPosition3 = TweenPosition.Begin(base.gameObject, duration3, NGCDDPCAGJB.position, NGCDDPCAGJB.position + AKPHKLGJBBB.normalized * EMPGJLEFKAG * 106f, false);
					tweenPosition3.method = UITweener.Method.EaseIn;
					tweenPosition3.onFinished = IMJJLEDCAOD;
					tweenPosition3.ignoreTimeScale = base.ignoreTimeScale;
					HHHBLDGCONH = false;
					EDGIAMOHBID = 30;
				}
			}
			else
			{
				IMCKKOEINGI();
			}
		}
		else
		{
			IMCKKOEINGI();
		}
	}

	[CompilerGenerated]
	private void EOMGFKKJFIH(UITweener MGDJMGHCAAI)
	{
		IMCKKOEINGI();
	}

	protected virtual void KODJIPJGFPB()
	{
		base.Awake();
	}

	protected virtual void ODKNBDAFMMP()
	{
		if (!OLDPEIALACE)
		{
			if (base.ignoreTimeScale)
			{
				if (MGCOAMOLGBF)
				{
					BKEECLMFOEC = new Ray(NGCDDPCAGJB.position, AKPHKLGJBBB);
					float num = EMPGJLEFKAG * 1473f;
					if (num > 1259f && Physics.Raycast(BKEECLMFOEC, out PJBIGBJNCDB, num, Singleton<TagsAndLayers>.instance.CMHMEJDGIBJ(JMMJHCOKCGG.fraction, JMMJHCOKCGG.BLOHNLJOPIM)))
					{
						base.MOLKFKLJIIH = PJBIGBJNCDB;
						HHHBLDGCONH = true;
						float duration = Vector3.Distance(NGCDDPCAGJB.position, PJBIGBJNCDB.point) / JPNAINOGAMM;
						TweenPosition tweenPosition = TweenPosition.Begin(base.gameObject, duration, NGCDDPCAGJB.position, PJBIGBJNCDB.point);
						tweenPosition.method = UITweener.Method.Linear;
						tweenPosition.onFinished = IMJNPDCGDAC;
						tweenPosition.ignoreTimeScale = base.ignoreTimeScale;
					}
					else
					{
						HHHBLDGCONH = true;
						EDGIAMOHBID = 0;
						float duration2 = Vector3.Magnitude(AKPHKLGJBBB.normalized * EMPGJLEFKAG * 423f) / JPNAINOGAMM;
						TweenPosition tweenPosition2 = TweenPosition.Begin(base.gameObject, duration2, NGCDDPCAGJB.position, NGCDDPCAGJB.position + AKPHKLGJBBB.normalized * EMPGJLEFKAG * 61f);
						tweenPosition2.method = UITweener.Method.EaseIn;
						tweenPosition2.ignoreTimeScale = base.ignoreTimeScale;
					}
				}
				else
				{
					IMCKKOEINGI();
				}
			}
			else if (MGCOAMOLGBF)
			{
				if (!NHACNNBGCEP())
				{
					float duration3 = Vector3.Magnitude(AKPHKLGJBBB.normalized * EMPGJLEFKAG * 965f) / JPNAINOGAMM;
					TweenPosition tweenPosition3 = TweenPosition.Begin(base.gameObject, duration3, NGCDDPCAGJB.position, NGCDDPCAGJB.position + AKPHKLGJBBB.normalized * EMPGJLEFKAG * 369f, false);
					tweenPosition3.method = UITweener.Method.Linear;
					tweenPosition3.onFinished = IMJJLEDCAOD;
					tweenPosition3.ignoreTimeScale = base.ignoreTimeScale;
					HHHBLDGCONH = true;
					EDGIAMOHBID = -144;
				}
			}
			else
			{
				IMCKKOEINGI();
			}
		}
		else
		{
			IMCKKOEINGI();
		}
	}

	private bool NKFOALAIOBA()
	{
		BKEECLMFOEC = new Ray(DJODBMGLPDE, AKPHKLGJBBB);
		float magnitude = (NGCDDPCAGJB.position - DJODBMGLPDE).magnitude;
		float maxDistance = magnitude + 2f * Time.deltaTime;
		if (magnitude > 0f && Physics.Raycast(BKEECLMFOEC, out PJBIGBJNCDB, maxDistance, Singleton<TagsAndLayers>.instance.GetBulletMask(JMMJHCOKCGG.fraction, JMMJHCOKCGG.BLOHNLJOPIM)))
		{
			base.MOLKFKLJIIH = PJBIGBJNCDB;
			IMCKKOEINGI();
			HHHBLDGCONH = false;
			return true;
		}
		return false;
	}

	[CompilerGenerated]
	private void EIAFFPJLDAH(UITweener MGDJMGHCAAI)
	{
		IMCKKOEINGI();
	}

	private TweenPosition CJHLEDNIFBP(Vector3 OEIICEJPGKI, Vector3 IIMDKHJAJGO)
	{
		float num = Vector3.Distance(OEIICEJPGKI, IIMDKHJAJGO);
		JPNAINOGAMM = ((!GGJPNLDIGGM) ? JPNAINOGAMM : GMDKKKBCLAB.MCDEMEAONOK());
		float duration = num / JPNAINOGAMM;
		TweenPosition tweenPosition = TweenPosition.Begin(base.gameObject, duration, OEIICEJPGKI, IIMDKHJAJGO);
		tweenPosition.ignoreTimeScale = base.ignoreTimeScale;
		tweenPosition.method = UITweener.Method.Linear;
		return tweenPosition;
	}

	private Vector3 NDMNFEDBMAD(Weapon JMMJHCOKCGG, Vector3 MPHCNMDIPAI, Vector3 MHLDJIABNFI)
	{
		BulletSetup bulletSetup = JMMJHCOKCGG.ammoSetup as BulletSetup;
		if (bulletSetup != null)
		{
			float num = Vector3.Distance(JMMJHCOKCGG.GHPBMCAKMMB.transform.position, MPHCNMDIPAI);
			float num2 = num / bulletSetup.bulletSpeed + 0.1f;
			return MPHCNMDIPAI + num2 * Time.timeScale * MHLDJIABNFI;
		}
		return MPHCNMDIPAI;
	}

	private bool NHACNNBGCEP()
	{
		BKEECLMFOEC = new Ray(DJODBMGLPDE, AKPHKLGJBBB);
		float magnitude = (NGCDDPCAGJB.position - DJODBMGLPDE).magnitude;
		float maxDistance = magnitude + 1871f * Time.deltaTime;
		if (magnitude > 76f && Physics.Raycast(BKEECLMFOEC, out PJBIGBJNCDB, maxDistance, Singleton<TagsAndLayers>.instance.CMHMEJDGIBJ(JMMJHCOKCGG.fraction, JMMJHCOKCGG.BLOHNLJOPIM)))
		{
			base.MOLKFKLJIIH = PJBIGBJNCDB;
			IMCKKOEINGI();
			HHHBLDGCONH = false;
			return false;
		}
		return true;
	}

	public virtual void GDJAPADHAEH()
	{
		base.DestroyPooled();
		ACPFIFCCKDF.Reset();
		StopAllCoroutines();
		GetComponent<TweenPosition>().enabled = true;
	}

	private void NBBJMGLDLPN(UITweener MGDJMGHCAAI)
	{
		IMCKKOEINGI();
	}

	protected virtual void ILHKPHJMKCN()
	{
		if (!OLDPEIALACE)
		{
			if (base.ignoreTimeScale)
			{
				if (MGCOAMOLGBF)
				{
					BKEECLMFOEC = new Ray(NGCDDPCAGJB.position, AKPHKLGJBBB);
					float num = EMPGJLEFKAG * 655f;
					if (num > 362f && Physics.Raycast(BKEECLMFOEC, out PJBIGBJNCDB, num, Singleton<TagsAndLayers>.instance.CMHMEJDGIBJ(JMMJHCOKCGG.fraction, JMMJHCOKCGG.BLOHNLJOPIM)))
					{
						base.MOLKFKLJIIH = PJBIGBJNCDB;
						HHHBLDGCONH = false;
						float duration = Vector3.Distance(NGCDDPCAGJB.position, PJBIGBJNCDB.point) / JPNAINOGAMM;
						TweenPosition tweenPosition = TweenPosition.Begin(base.gameObject, duration, NGCDDPCAGJB.position, PJBIGBJNCDB.point, false);
						tweenPosition.method = UITweener.Method.EaseIn;
						tweenPosition.onFinished = IMJNPDCGDAC;
						tweenPosition.ignoreTimeScale = base.ignoreTimeScale;
					}
					else
					{
						HHHBLDGCONH = false;
						EDGIAMOHBID = 0;
						float duration2 = Vector3.Magnitude(AKPHKLGJBBB.normalized * EMPGJLEFKAG * 1683f) / JPNAINOGAMM;
						TweenPosition tweenPosition2 = TweenPosition.Begin(base.gameObject, duration2, NGCDDPCAGJB.position, NGCDDPCAGJB.position + AKPHKLGJBBB.normalized * EMPGJLEFKAG * 1252f);
						tweenPosition2.method = UITweener.Method.EaseIn;
						tweenPosition2.ignoreTimeScale = base.ignoreTimeScale;
					}
				}
				else
				{
					IMCKKOEINGI();
				}
			}
			else if (MGCOAMOLGBF)
			{
				if (!NHACNNBGCEP())
				{
					float duration3 = Vector3.Magnitude(AKPHKLGJBBB.normalized * EMPGJLEFKAG * 1772f) / JPNAINOGAMM;
					TweenPosition tweenPosition3 = TweenPosition.Begin(base.gameObject, duration3, NGCDDPCAGJB.position, NGCDDPCAGJB.position + AKPHKLGJBBB.normalized * EMPGJLEFKAG * 585f, false);
					tweenPosition3.method = UITweener.Method.Linear;
					tweenPosition3.onFinished = IMJJLEDCAOD;
					tweenPosition3.ignoreTimeScale = base.ignoreTimeScale;
					HHHBLDGCONH = true;
					EDGIAMOHBID = -95;
				}
			}
			else
			{
				IMCKKOEINGI();
			}
		}
		else
		{
			IMCKKOEINGI();
		}
	}

	private TweenPosition DOBHBCCJBDD(Vector3 OEIICEJPGKI, Vector3 IIMDKHJAJGO)
	{
		float num = Vector3.Distance(OEIICEJPGKI, IIMDKHJAJGO);
		JPNAINOGAMM = ((!GGJPNLDIGGM) ? JPNAINOGAMM : GMDKKKBCLAB.fakeSpeed);
		float duration = num / JPNAINOGAMM;
		TweenPosition tweenPosition = TweenPosition.Begin(base.gameObject, duration, OEIICEJPGKI, IIMDKHJAJGO, false);
		tweenPosition.ignoreTimeScale = base.ignoreTimeScale;
		tweenPosition.method = UITweener.Method.Linear;
		return tweenPosition;
	}

	public virtual void JKGHLIFCLCC(Vector3 OEIICEJPGKI, Vector3 IIMDKHJAJGO)
	{
		if (!OLDPEIALACE)
		{
			base.Fire(OEIICEJPGKI, IIMDKHJAJGO);
			AKPHKLGJBBB = IIMDKHJAJGO - OEIICEJPGKI;
			HHHBLDGCONH = false;
			Vector3 normalized = (IIMDKHJAJGO - OEIICEJPGKI).normalized;
			if (Vector3.Distance(OEIICEJPGKI, IIMDKHJAJGO) > 1772f)
			{
				IIMDKHJAJGO = OEIICEJPGKI + normalized * 1621f;
				AKPHKLGJBBB = IIMDKHJAJGO - OEIICEJPGKI;
			}
			base.MOLKFKLJIIH = null;
			Ray ray = new Ray(OEIICEJPGKI + normalized * 525f, normalized);
			if (GGJPNLDIGGM)
			{
				AnimateShot(OEIICEJPGKI, IIMDKHJAJGO, true);
			}
			else if (Physics.Raycast(ray, out PJBIGBJNCDB, Vector3.Distance(OEIICEJPGKI, OEIICEJPGKI + normalized * (AKPHKLGJBBB.magnitude - 1341f)), Singleton<TagsAndLayers>.instance.BAFPJAGNEHI(JMMJHCOKCGG.fraction, JMMJHCOKCGG.BLOHNLJOPIM)))
			{
				if (TagsAndLayers.IsStatic(PJBIGBJNCDB.transform.gameObject))
				{
					AnimateShot(OEIICEJPGKI, PJBIGBJNCDB.point, false);
					base.MOLKFKLJIIH = PJBIGBJNCDB;
				}
				else
				{
					AnimateShot(OEIICEJPGKI, PJBIGBJNCDB.point, true);
				}
			}
			else
			{
				AnimateShot(OEIICEJPGKI, OEIICEJPGKI + AKPHKLGJBBB, false);
			}
			return;
		}
		base.Fire(OEIICEJPGKI, IIMDKHJAJGO);
		AKPHKLGJBBB = IIMDKHJAJGO - OEIICEJPGKI;
		Vector3 normalized2 = (IIMDKHJAJGO - OEIICEJPGKI).normalized;
		if (Vector3.Distance(OEIICEJPGKI, IIMDKHJAJGO) > 99f)
		{
			IIMDKHJAJGO = OEIICEJPGKI + normalized2 * 1573f;
			AKPHKLGJBBB = IIMDKHJAJGO - OEIICEJPGKI;
		}
		base.MOLKFKLJIIH = null;
		Ray ray2 = new Ray(OEIICEJPGKI + normalized2 * 1987f, normalized2);
		if (GGJPNLDIGGM)
		{
			AnimateShot(OEIICEJPGKI, IIMDKHJAJGO, false);
			return;
		}
		int layerMask = ((!NOLLONIMIGF) ? ((int)Singleton<TagsAndLayers>.instance.BAFPJAGNEHI(JMMJHCOKCGG.fraction, JMMJHCOKCGG.BLOHNLJOPIM)) : ((int)Singleton<TagsAndLayers>.instance.CMHMEJDGIBJ(JMMJHCOKCGG.fraction, JMMJHCOKCGG.BLOHNLJOPIM) & ~TagsAndLayers.DJLKEEHPAGA));
		RaycastHit hitInfo;
		if (Physics.Raycast(ray2, out hitInfo, 684f, layerMask))
		{
			if (TagsAndLayers.LKIJKDCGCMI(hitInfo.transform.gameObject))
			{
				AnimateShot(OEIICEJPGKI, hitInfo.point, false);
				base.MOLKFKLJIIH = hitInfo;
				return;
			}
			base.MOLKFKLJIIH = hitInfo;
			AnimateShot(OEIICEJPGKI, IIMDKHJAJGO, true);
			DestroyableObject component = hitInfo.collider.transform.GetComponent<DestroyableObject>();
			if (component != null)
			{
				Vector3 vector = GDGCCNLEODB(JMMJHCOKCGG, hitInfo.point, component.velocity);
				AnimateShot(OEIICEJPGKI, vector, true);
				hitInfo.point = vector;
				base.MOLKFKLJIIH = hitInfo;
			}
			else
			{
				AnimateShot(OEIICEJPGKI, IIMDKHJAJGO, true);
			}
		}
		else
		{
			AnimateShot(OEIICEJPGKI, IIMDKHJAJGO + AKPHKLGJBBB, false);
		}
	}

	public override void Fire(Vector3 OEIICEJPGKI, Vector3 IIMDKHJAJGO)
	{
		if (!OLDPEIALACE)
		{
			base.Fire(OEIICEJPGKI, IIMDKHJAJGO);
			AKPHKLGJBBB = IIMDKHJAJGO - OEIICEJPGKI;
			HHHBLDGCONH = false;
			Vector3 normalized = (IIMDKHJAJGO - OEIICEJPGKI).normalized;
			if (Vector3.Distance(OEIICEJPGKI, IIMDKHJAJGO) > 50f)
			{
				IIMDKHJAJGO = OEIICEJPGKI + normalized * 50f;
				AKPHKLGJBBB = IIMDKHJAJGO - OEIICEJPGKI;
			}
			base.MOLKFKLJIIH = null;
			Ray ray = new Ray(OEIICEJPGKI + normalized * 0.1f, normalized);
			if (GGJPNLDIGGM)
			{
				AnimateShot(OEIICEJPGKI, IIMDKHJAJGO, false);
			}
			else if (Physics.Raycast(ray, out PJBIGBJNCDB, Vector3.Distance(OEIICEJPGKI, OEIICEJPGKI + normalized * (AKPHKLGJBBB.magnitude - 0.2f)), Singleton<TagsAndLayers>.instance.GetBulletMask(JMMJHCOKCGG.fraction, JMMJHCOKCGG.BLOHNLJOPIM)))
			{
				if (TagsAndLayers.IsStatic(PJBIGBJNCDB.transform.gameObject))
				{
					AnimateShot(OEIICEJPGKI, PJBIGBJNCDB.point, false);
					base.MOLKFKLJIIH = PJBIGBJNCDB;
				}
				else
				{
					AnimateShot(OEIICEJPGKI, PJBIGBJNCDB.point, true);
				}
			}
			else
			{
				AnimateShot(OEIICEJPGKI, OEIICEJPGKI + AKPHKLGJBBB, true);
			}
			return;
		}
		base.Fire(OEIICEJPGKI, IIMDKHJAJGO);
		AKPHKLGJBBB = IIMDKHJAJGO - OEIICEJPGKI;
		Vector3 normalized2 = (IIMDKHJAJGO - OEIICEJPGKI).normalized;
		if (Vector3.Distance(OEIICEJPGKI, IIMDKHJAJGO) > 50f)
		{
			IIMDKHJAJGO = OEIICEJPGKI + normalized2 * 50f;
			AKPHKLGJBBB = IIMDKHJAJGO - OEIICEJPGKI;
		}
		base.MOLKFKLJIIH = null;
		Ray ray2 = new Ray(OEIICEJPGKI + normalized2 * 0.1f, normalized2);
		if (GGJPNLDIGGM)
		{
			AnimateShot(OEIICEJPGKI, IIMDKHJAJGO, false);
			return;
		}
		int layerMask = ((!NOLLONIMIGF) ? ((int)Singleton<TagsAndLayers>.instance.GetBulletMask(JMMJHCOKCGG.fraction, JMMJHCOKCGG.BLOHNLJOPIM)) : ((int)Singleton<TagsAndLayers>.instance.GetBulletMask(JMMJHCOKCGG.fraction, JMMJHCOKCGG.BLOHNLJOPIM) & ~TagsAndLayers.DJLKEEHPAGA));
		RaycastHit hitInfo;
		if (Physics.Raycast(ray2, out hitInfo, float.PositiveInfinity, layerMask))
		{
			if (TagsAndLayers.IsStatic(hitInfo.transform.gameObject))
			{
				AnimateShot(OEIICEJPGKI, hitInfo.point, false);
				base.MOLKFKLJIIH = hitInfo;
				return;
			}
			base.MOLKFKLJIIH = hitInfo;
			AnimateShot(OEIICEJPGKI, IIMDKHJAJGO, false);
			DestroyableObject component = hitInfo.collider.transform.GetComponent<DestroyableObject>();
			if (component != null)
			{
				Vector3 vector = NDMNFEDBMAD(JMMJHCOKCGG, hitInfo.point, component.velocity);
				AnimateShot(OEIICEJPGKI, vector, false);
				hitInfo.point = vector;
				base.MOLKFKLJIIH = hitInfo;
			}
			else
			{
				AnimateShot(OEIICEJPGKI, IIMDKHJAJGO, false);
			}
		}
		else
		{
			AnimateShot(OEIICEJPGKI, IIMDKHJAJGO + AKPHKLGJBBB, false);
		}
	}

	public override void DestroyPooled()
	{
		base.DestroyPooled();
		ACPFIFCCKDF.Reset();
		StopAllCoroutines();
		GetComponent<TweenPosition>().enabled = true;
	}

	protected void DIOAOBFDPMH()
	{
		if (HHHBLDGCONH)
		{
			EDGIAMOHBID += 0;
			NKFOALAIOBA();
			if (EDGIAMOHBID > 4)
			{
				EHNLAIHCMLD();
			}
		}
		DJODBMGLPDE = NGCDDPCAGJB.position;
	}

	protected override void Awake()
	{
		base.Awake();
	}

	private void OCPBLGBFBLM(UITweener MGDJMGHCAAI)
	{
		IMCKKOEINGI();
	}

	[CompilerGenerated]
	private void LFHAMGKFOMK(UITweener MGDJMGHCAAI)
	{
		DestroyPooled();
	}

	public virtual void AKBHIINCJFM(Vector3 OEIICEJPGKI, Vector3 IIMDKHJAJGO)
	{
		if (!OLDPEIALACE)
		{
			base.Fire(OEIICEJPGKI, IIMDKHJAJGO);
			AKPHKLGJBBB = IIMDKHJAJGO - OEIICEJPGKI;
			HHHBLDGCONH = true;
			Vector3 normalized = (IIMDKHJAJGO - OEIICEJPGKI).normalized;
			if (Vector3.Distance(OEIICEJPGKI, IIMDKHJAJGO) > 872f)
			{
				IIMDKHJAJGO = OEIICEJPGKI + normalized * 1686f;
				AKPHKLGJBBB = IIMDKHJAJGO - OEIICEJPGKI;
			}
			base.MOLKFKLJIIH = null;
			Ray ray = new Ray(OEIICEJPGKI + normalized * 537f, normalized);
			if (GGJPNLDIGGM)
			{
				AnimateShot(OEIICEJPGKI, IIMDKHJAJGO, false);
			}
			else if (Physics.Raycast(ray, out PJBIGBJNCDB, Vector3.Distance(OEIICEJPGKI, OEIICEJPGKI + normalized * (AKPHKLGJBBB.magnitude - 1682f)), Singleton<TagsAndLayers>.instance.GetBulletMask(JMMJHCOKCGG.fraction, JMMJHCOKCGG.BLOHNLJOPIM)))
			{
				if (TagsAndLayers.KHKNLLDEBMA(PJBIGBJNCDB.transform.gameObject))
				{
					AnimateShot(OEIICEJPGKI, PJBIGBJNCDB.point, false);
					base.MOLKFKLJIIH = PJBIGBJNCDB;
				}
				else
				{
					AnimateShot(OEIICEJPGKI, PJBIGBJNCDB.point, true);
				}
			}
			else
			{
				AnimateShot(OEIICEJPGKI, OEIICEJPGKI + AKPHKLGJBBB, false);
			}
			return;
		}
		base.Fire(OEIICEJPGKI, IIMDKHJAJGO);
		AKPHKLGJBBB = IIMDKHJAJGO - OEIICEJPGKI;
		Vector3 normalized2 = (IIMDKHJAJGO - OEIICEJPGKI).normalized;
		if (Vector3.Distance(OEIICEJPGKI, IIMDKHJAJGO) > 184f)
		{
			IIMDKHJAJGO = OEIICEJPGKI + normalized2 * 1930f;
			AKPHKLGJBBB = IIMDKHJAJGO - OEIICEJPGKI;
		}
		base.MOLKFKLJIIH = null;
		Ray ray2 = new Ray(OEIICEJPGKI + normalized2 * 1912f, normalized2);
		if (GGJPNLDIGGM)
		{
			AnimateShot(OEIICEJPGKI, IIMDKHJAJGO, true);
			return;
		}
		int layerMask = ((!NOLLONIMIGF) ? ((int)Singleton<TagsAndLayers>.instance.CMHMEJDGIBJ(JMMJHCOKCGG.fraction, JMMJHCOKCGG.BLOHNLJOPIM)) : ((int)Singleton<TagsAndLayers>.instance.BAFPJAGNEHI(JMMJHCOKCGG.fraction, JMMJHCOKCGG.BLOHNLJOPIM) & ~TagsAndLayers.DJLKEEHPAGA));
		RaycastHit hitInfo;
		if (Physics.Raycast(ray2, out hitInfo, 603f, layerMask))
		{
			if (TagsAndLayers.IsStatic(hitInfo.transform.gameObject))
			{
				AnimateShot(OEIICEJPGKI, hitInfo.point, false);
				base.MOLKFKLJIIH = hitInfo;
				return;
			}
			base.MOLKFKLJIIH = hitInfo;
			AnimateShot(OEIICEJPGKI, IIMDKHJAJGO, false);
			DestroyableObject component = hitInfo.collider.transform.GetComponent<DestroyableObject>();
			if (component != null)
			{
				Vector3 vector = NDMNFEDBMAD(JMMJHCOKCGG, hitInfo.point, component.velocity);
				AnimateShot(OEIICEJPGKI, vector, true);
				hitInfo.point = vector;
				base.MOLKFKLJIIH = hitInfo;
			}
			else
			{
				AnimateShot(OEIICEJPGKI, IIMDKHJAJGO, true);
			}
		}
		else
		{
			AnimateShot(OEIICEJPGKI, IIMDKHJAJGO + AKPHKLGJBBB, false);
		}
	}

	public virtual void MGMNPMOKPEA(Vector3 OEIICEJPGKI, Vector3 IIMDKHJAJGO)
	{
		if (!OLDPEIALACE)
		{
			base.Fire(OEIICEJPGKI, IIMDKHJAJGO);
			AKPHKLGJBBB = IIMDKHJAJGO - OEIICEJPGKI;
			HHHBLDGCONH = true;
			Vector3 normalized = (IIMDKHJAJGO - OEIICEJPGKI).normalized;
			if (Vector3.Distance(OEIICEJPGKI, IIMDKHJAJGO) > 1291f)
			{
				IIMDKHJAJGO = OEIICEJPGKI + normalized * 1867f;
				AKPHKLGJBBB = IIMDKHJAJGO - OEIICEJPGKI;
			}
			base.MOLKFKLJIIH = null;
			Ray ray = new Ray(OEIICEJPGKI + normalized * 1908f, normalized);
			if (GGJPNLDIGGM)
			{
				AnimateShot(OEIICEJPGKI, IIMDKHJAJGO, false);
			}
			else if (Physics.Raycast(ray, out PJBIGBJNCDB, Vector3.Distance(OEIICEJPGKI, OEIICEJPGKI + normalized * (AKPHKLGJBBB.magnitude - 892f)), Singleton<TagsAndLayers>.instance.BAFPJAGNEHI(JMMJHCOKCGG.fraction, JMMJHCOKCGG.BLOHNLJOPIM)))
			{
				if (TagsAndLayers.KHKNLLDEBMA(PJBIGBJNCDB.transform.gameObject))
				{
					AnimateShot(OEIICEJPGKI, PJBIGBJNCDB.point, false);
					base.MOLKFKLJIIH = PJBIGBJNCDB;
				}
				else
				{
					AnimateShot(OEIICEJPGKI, PJBIGBJNCDB.point, true);
				}
			}
			else
			{
				AnimateShot(OEIICEJPGKI, OEIICEJPGKI + AKPHKLGJBBB, true);
			}
			return;
		}
		base.Fire(OEIICEJPGKI, IIMDKHJAJGO);
		AKPHKLGJBBB = IIMDKHJAJGO - OEIICEJPGKI;
		Vector3 normalized2 = (IIMDKHJAJGO - OEIICEJPGKI).normalized;
		if (Vector3.Distance(OEIICEJPGKI, IIMDKHJAJGO) > 837f)
		{
			IIMDKHJAJGO = OEIICEJPGKI + normalized2 * 837f;
			AKPHKLGJBBB = IIMDKHJAJGO - OEIICEJPGKI;
		}
		base.MOLKFKLJIIH = null;
		Ray ray2 = new Ray(OEIICEJPGKI + normalized2 * 602f, normalized2);
		if (GGJPNLDIGGM)
		{
			AnimateShot(OEIICEJPGKI, IIMDKHJAJGO, true);
			return;
		}
		int layerMask = ((!NOLLONIMIGF) ? ((int)Singleton<TagsAndLayers>.instance.CMHMEJDGIBJ(JMMJHCOKCGG.fraction, JMMJHCOKCGG.BLOHNLJOPIM)) : ((int)Singleton<TagsAndLayers>.instance.GetBulletMask(JMMJHCOKCGG.fraction, JMMJHCOKCGG.BLOHNLJOPIM) & ~TagsAndLayers.DJLKEEHPAGA));
		RaycastHit hitInfo;
		if (Physics.Raycast(ray2, out hitInfo, 68f, layerMask))
		{
			if (TagsAndLayers.IsStatic(hitInfo.transform.gameObject))
			{
				AnimateShot(OEIICEJPGKI, hitInfo.point, false);
				base.MOLKFKLJIIH = hitInfo;
				return;
			}
			base.MOLKFKLJIIH = hitInfo;
			AnimateShot(OEIICEJPGKI, IIMDKHJAJGO, false);
			DestroyableObject component = hitInfo.collider.transform.GetComponent<DestroyableObject>();
			if (component != null)
			{
				Vector3 vector = NDMNFEDBMAD(JMMJHCOKCGG, hitInfo.point, component.velocity);
				AnimateShot(OEIICEJPGKI, vector, true);
				hitInfo.point = vector;
				base.MOLKFKLJIIH = hitInfo;
			}
			else
			{
				AnimateShot(OEIICEJPGKI, IIMDKHJAJGO, false);
			}
		}
		else
		{
			AnimateShot(OEIICEJPGKI, IIMDKHJAJGO + AKPHKLGJBBB, true);
		}
	}

	private void IMJNPDCGDAC(UITweener MGDJMGHCAAI)
	{
		IMCKKOEINGI();
	}

	protected override void CFIPHHJKBCK()
	{
		if (!OLDPEIALACE)
		{
			if (base.ignoreTimeScale)
			{
				if (MGCOAMOLGBF)
				{
					BKEECLMFOEC = new Ray(NGCDDPCAGJB.position, AKPHKLGJBBB);
					float num = EMPGJLEFKAG * 2f;
					if (num > 0f && Physics.Raycast(BKEECLMFOEC, out PJBIGBJNCDB, num, Singleton<TagsAndLayers>.instance.GetBulletMask(JMMJHCOKCGG.fraction, JMMJHCOKCGG.BLOHNLJOPIM)))
					{
						base.MOLKFKLJIIH = PJBIGBJNCDB;
						HHHBLDGCONH = false;
						float duration = Vector3.Distance(NGCDDPCAGJB.position, PJBIGBJNCDB.point) / JPNAINOGAMM;
						TweenPosition tweenPosition = TweenPosition.Begin(base.gameObject, duration, NGCDDPCAGJB.position, PJBIGBJNCDB.point, false);
						tweenPosition.method = UITweener.Method.Linear;
						tweenPosition.onFinished = delegate
						{
							IMCKKOEINGI();
						};
						tweenPosition.ignoreTimeScale = base.ignoreTimeScale;
					}
					else
					{
						HHHBLDGCONH = true;
						EDGIAMOHBID = 0;
						float duration2 = Vector3.Magnitude(AKPHKLGJBBB.normalized * EMPGJLEFKAG * 7f) / JPNAINOGAMM;
						TweenPosition tweenPosition2 = TweenPosition.Begin(base.gameObject, duration2, NGCDDPCAGJB.position, NGCDDPCAGJB.position + AKPHKLGJBBB.normalized * EMPGJLEFKAG * 5f, false);
						tweenPosition2.method = UITweener.Method.Linear;
						tweenPosition2.ignoreTimeScale = base.ignoreTimeScale;
					}
				}
				else
				{
					IMCKKOEINGI();
				}
			}
			else if (MGCOAMOLGBF)
			{
				if (!NKFOALAIOBA())
				{
					float duration3 = Vector3.Magnitude(AKPHKLGJBBB.normalized * EMPGJLEFKAG * 3f) / JPNAINOGAMM;
					TweenPosition tweenPosition3 = TweenPosition.Begin(base.gameObject, duration3, NGCDDPCAGJB.position, NGCDDPCAGJB.position + AKPHKLGJBBB.normalized * EMPGJLEFKAG * 2f, false);
					tweenPosition3.method = UITweener.Method.Linear;
					tweenPosition3.onFinished = KDBKKFFDKOB;
					tweenPosition3.ignoreTimeScale = base.ignoreTimeScale;
					HHHBLDGCONH = true;
					EDGIAMOHBID = int.MinValue;
				}
			}
			else
			{
				IMCKKOEINGI();
			}
		}
		else
		{
			IMCKKOEINGI();
		}
	}

	protected virtual void IPOMEJKFBMH()
	{
		if (!OLDPEIALACE)
		{
			if (base.ignoreTimeScale)
			{
				if (MGCOAMOLGBF)
				{
					BKEECLMFOEC = new Ray(NGCDDPCAGJB.position, AKPHKLGJBBB);
					float num = EMPGJLEFKAG * 630f;
					if (num > 1394f && Physics.Raycast(BKEECLMFOEC, out PJBIGBJNCDB, num, Singleton<TagsAndLayers>.instance.BAFPJAGNEHI(JMMJHCOKCGG.fraction, JMMJHCOKCGG.BLOHNLJOPIM)))
					{
						base.MOLKFKLJIIH = PJBIGBJNCDB;
						HHHBLDGCONH = true;
						float duration = Vector3.Distance(NGCDDPCAGJB.position, PJBIGBJNCDB.point) / JPNAINOGAMM;
						TweenPosition tweenPosition = TweenPosition.Begin(base.gameObject, duration, NGCDDPCAGJB.position, PJBIGBJNCDB.point);
						tweenPosition.method = UITweener.Method.EaseIn;
						tweenPosition.onFinished = OCPBLGBFBLM;
						tweenPosition.ignoreTimeScale = base.ignoreTimeScale;
					}
					else
					{
						HHHBLDGCONH = false;
						EDGIAMOHBID = 0;
						float duration2 = Vector3.Magnitude(AKPHKLGJBBB.normalized * EMPGJLEFKAG * 1468f) / JPNAINOGAMM;
						TweenPosition tweenPosition2 = TweenPosition.Begin(base.gameObject, duration2, NGCDDPCAGJB.position, NGCDDPCAGJB.position + AKPHKLGJBBB.normalized * EMPGJLEFKAG * 1203f);
						tweenPosition2.method = UITweener.Method.EaseIn;
						tweenPosition2.ignoreTimeScale = base.ignoreTimeScale;
					}
				}
				else
				{
					IMCKKOEINGI();
				}
			}
			else if (MGCOAMOLGBF)
			{
				if (!NHACNNBGCEP())
				{
					float duration3 = Vector3.Magnitude(AKPHKLGJBBB.normalized * EMPGJLEFKAG * 632f) / JPNAINOGAMM;
					TweenPosition tweenPosition3 = TweenPosition.Begin(base.gameObject, duration3, NGCDDPCAGJB.position, NGCDDPCAGJB.position + AKPHKLGJBBB.normalized * EMPGJLEFKAG * 1751f);
					tweenPosition3.method = UITweener.Method.Linear;
					tweenPosition3.onFinished = KDBKKFFDKOB;
					tweenPosition3.ignoreTimeScale = base.ignoreTimeScale;
					HHHBLDGCONH = true;
					EDGIAMOHBID = 143;
				}
			}
			else
			{
				IMCKKOEINGI();
			}
		}
		else
		{
			IMCKKOEINGI();
		}
	}

	private void KDBKKFFDKOB(UITweener MGDJMGHCAAI)
	{
		HHHBLDGCONH = false;
		if (!NKFOALAIOBA())
		{
			float duration = Vector3.Magnitude(AKPHKLGJBBB) / JPNAINOGAMM;
			TweenPosition tweenPosition = TweenPosition.Begin(base.gameObject, duration, NGCDDPCAGJB.position, NGCDDPCAGJB.position + AKPHKLGJBBB, false);
			tweenPosition.ignoreTimeScale = base.ignoreTimeScale;
			tweenPosition.method = UITweener.Method.Linear;
			tweenPosition.onFinished = delegate
			{
				DestroyPooled();
			};
		}
	}

	[CompilerGenerated]
	private void GCLMFPHBDOO(UITweener NGADLHBIHGL)
	{
		DestroyPooled();
	}

	private void IMJJLEDCAOD(UITweener MGDJMGHCAAI)
	{
		HHHBLDGCONH = false;
		if (!NHACNNBGCEP())
		{
			float duration = Vector3.Magnitude(AKPHKLGJBBB) / JPNAINOGAMM;
			TweenPosition tweenPosition = TweenPosition.Begin(base.gameObject, duration, NGCDDPCAGJB.position, NGCDDPCAGJB.position + AKPHKLGJBBB, false);
			tweenPosition.ignoreTimeScale = base.ignoreTimeScale;
			tweenPosition.method = UITweener.Method.EaseIn;
			tweenPosition.onFinished = delegate
			{
				DestroyPooled();
			};
		}
	}
}
