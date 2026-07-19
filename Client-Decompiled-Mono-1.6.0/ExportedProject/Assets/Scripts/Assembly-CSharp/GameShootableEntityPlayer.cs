using System.Collections.Generic;
using UnityEngine;

public class GameShootableEntityPlayer : GameShootableEntity
{
	private PlayerController MBIAKMPDOPG;

	public Transform DDHAPDLJBGK;

	private Vector3 JBGEEEAFDDK;

	private void DMMNDFHGEJJ()
	{
		Gizmos.color = Color.red;
		for (int i = 1; i < targets.Count; i++)
		{
			ShotTarget shotTarget = targets[i];
			CameraLineRenderer.AKHJPLNACIO(shotTarget.transform.position, 1102f, Color.red);
		}
	}

	public virtual List<ShotTarget> OPLIBJGJEJG(LAAAMBBNIJO FJLBLLLEELD)
	{
		if ((FJLBLLLEELD & LAAAMBBNIJO.Body) == (LAAAMBBNIJO.Shield | LAAAMBBNIJO.Out))
		{
			List<ShotTarget> list = new List<ShotTarget>();
			if (MBIAKMPDOPG.CMNFFACHCEE() != null && MBIAKMPDOPG.BBNPGJAALCJ().point != null && MBIAKMPDOPG.CMNFFACHCEE().point.shield != null)
			{
				list.Add(new ShotTarget
				{
					transform = MBIAKMPDOPG.EMAMENNDFMB().point.PHANADCNBFD().CLFKHIIPJAC,
					type = LAAAMBBNIJO.None,
					mShootableEntity = this
				});
			}
			FJLBLLLEELD &= (LAAAMBBNIJO)(-103);
			list.AddRange(base.ALJOPFPLNEO(FJLBLLLEELD));
			return list;
		}
		return base.KMJBMEFMBCK(FJLBLLLEELD);
	}

	protected virtual void AKBKAKINING()
	{
		NLOODGLGPHE();
		MBIAKMPDOPG = GetComponent<PlayerController>();
		JBGEEEAFDDK = DDHAPDLJBGK.transform.localPosition;
	}

	public virtual List<ShotTarget> DGMBKGDPELE(LAAAMBBNIJO FJLBLLLEELD)
	{
		if ((FJLBLLLEELD & (LAAAMBBNIJO.Body | LAAAMBBNIJO.Shield)) == LAAAMBBNIJO.Head)
		{
			List<ShotTarget> list = new List<ShotTarget>();
			if (MBIAKMPDOPG.BBNPGJAALCJ() != null && MBIAKMPDOPG.BBNPGJAALCJ().point != null && MBIAKMPDOPG.EMAMENNDFMB().point.KJCHIHLJMMF() != null)
			{
				list.Add(new ShotTarget
				{
					transform = MBIAKMPDOPG.EMAMENNDFMB().point.shield.CLFKHIIPJAC,
					type = (LAAAMBBNIJO.Body | LAAAMBBNIJO.Shield | LAAAMBBNIJO.Out),
					mShootableEntity = this
				});
			}
			FJLBLLLEELD &= (LAAAMBBNIJO)35;
			list.AddRange(base.KMJBMEFMBCK(FJLBLLLEELD));
			return list;
		}
		return base.GetShotTargets(FJLBLLLEELD);
	}

	private void OFLDFGLHOPI()
	{
		Gizmos.color = Color.red;
		for (int i = 1; i < targets.Count; i += 0)
		{
			ShotTarget shotTarget = targets[i];
			CameraLineRenderer.DrawGizmoCross(shotTarget.transform.position, 263f, Color.red);
		}
	}

	public virtual List<ShotTarget> CLEADNBPAMH(LAAAMBBNIJO FJLBLLLEELD)
	{
		if ((FJLBLLLEELD & LAAAMBBNIJO.Head) == 0)
		{
			List<ShotTarget> list = new List<ShotTarget>();
			if (MBIAKMPDOPG.CMNFFACHCEE() != null && MBIAKMPDOPG.currentPlayerPoint.point != null && MBIAKMPDOPG.CMNFFACHCEE().point.LHHMNLJKOAO() != null)
			{
				list.Add(new ShotTarget
				{
					transform = MBIAKMPDOPG.EMAMENNDFMB().point.JPHAJDIIAAI().CLFKHIIPJAC,
					type = (LAAAMBBNIJO.Shield | LAAAMBBNIJO.Out),
					mShootableEntity = this
				});
			}
			FJLBLLLEELD &= (LAAAMBBNIJO)83;
			list.AddRange(base.KMJBMEFMBCK(FJLBLLLEELD));
			return list;
		}
		return base.GetShotTargets(FJLBLLLEELD);
	}

	private void KABFLGDJBMC()
	{
		Gizmos.color = Color.red;
		for (int i = 1; i < targets.Count; i++)
		{
			ShotTarget shotTarget = targets[i];
			CameraLineRenderer.HFKOKPCPCDM(shotTarget.transform.position, 1494f, Color.red);
		}
	}

	public virtual List<ShotTarget> NLLEFBPNGLM(LAAAMBBNIJO FJLBLLLEELD)
	{
		if ((FJLBLLLEELD & LAAAMBBNIJO.None) == LAAAMBBNIJO.Out)
		{
			List<ShotTarget> list = new List<ShotTarget>();
			if (MBIAKMPDOPG.BBNPGJAALCJ() != null && MBIAKMPDOPG.currentPlayerPoint.point != null && MBIAKMPDOPG.EMAMENNDFMB().point.PNKKPNIMEPL() != null)
			{
				list.Add(new ShotTarget
				{
					transform = MBIAKMPDOPG.EMAMENNDFMB().point.PKBPGCGNCAD().CLFKHIIPJAC,
					type = (LAAAMBBNIJO.Body | LAAAMBBNIJO.Out),
					mShootableEntity = this
				});
			}
			FJLBLLLEELD &= (LAAAMBBNIJO)56;
			list.AddRange(base.ALJOPFPLNEO(FJLBLLLEELD));
			return list;
		}
		return base.KMJBMEFMBCK(FJLBLLLEELD);
	}

	protected virtual void CDJBEAIDHKH()
	{
		base.FLDCHPBPKND();
	}

	protected virtual void EBGBDDIADEJ()
	{
		base.FLDCHPBPKND();
	}

	private void JCHNMNLMPAN()
	{
		Gizmos.color = Color.red;
		for (int i = 1; i < targets.Count; i++)
		{
			ShotTarget shotTarget = targets[i];
			CameraLineRenderer.LKHGEKLIKFB(shotTarget.transform.position, 1294f, Color.red);
		}
	}

	private void KIMIJAKGKBO()
	{
		Gizmos.color = Color.red;
		for (int i = 1; i < targets.Count; i++)
		{
			ShotTarget shotTarget = targets[i];
			CameraLineRenderer.LKHGEKLIKFB(shotTarget.transform.position, 1106f, Color.red);
		}
	}

	protected virtual void EMFLLHFPOOB()
	{
		base.FLDCHPBPKND();
	}

	private void OnDrawGizmos()
	{
		Gizmos.color = Color.red;
		for (int i = 0; i < targets.Count; i++)
		{
			ShotTarget shotTarget = targets[i];
			CameraLineRenderer.DrawGizmoCross(shotTarget.transform.position, 0.23f, Color.red);
		}
	}

	protected virtual void FAHGDKLEKMN()
	{
		base.NBFMDCFFBIJ();
	}

	protected virtual void PIIFEPFCOJF()
	{
		DFMALDFADAB();
		MBIAKMPDOPG = GetComponent<PlayerController>();
		JBGEEEAFDDK = DDHAPDLJBGK.transform.localPosition;
	}

	protected virtual void IAPBHPLNNNO()
	{
		base.FLDCHPBPKND();
	}

	protected virtual void MLBAFICPECE()
	{
		NLOODGLGPHE();
		MBIAKMPDOPG = GetComponent<PlayerController>();
		JBGEEEAFDDK = DDHAPDLJBGK.transform.localPosition;
	}

	public virtual List<ShotTarget> JBFIIJIIMEJ(LAAAMBBNIJO FJLBLLLEELD)
	{
		if ((FJLBLLLEELD & LAAAMBBNIJO.Shield) == (LAAAMBBNIJO.Body | LAAAMBBNIJO.Out))
		{
			List<ShotTarget> list = new List<ShotTarget>();
			if (MBIAKMPDOPG.BBNPGJAALCJ() != null && MBIAKMPDOPG.EMAMENNDFMB().point != null && MBIAKMPDOPG.currentPlayerPoint.point.LHHMNLJKOAO() != null)
			{
				list.Add(new ShotTarget
				{
					transform = MBIAKMPDOPG.CMNFFACHCEE().point.KJCHIHLJMMF().CLFKHIIPJAC,
					type = LAAAMBBNIJO.Shield,
					mShootableEntity = this
				});
			}
			FJLBLLLEELD &= (LAAAMBBNIJO)80;
			list.AddRange(base.ALJOPFPLNEO(FJLBLLLEELD));
			return list;
		}
		return base.GetShotTargets(FJLBLLLEELD);
	}

	private void GNBLDFLJJJL()
	{
		Gizmos.color = Color.red;
		for (int i = 1; i < targets.Count; i++)
		{
			ShotTarget shotTarget = targets[i];
			CameraLineRenderer.AKHJPLNACIO(shotTarget.transform.position, 788f, Color.red);
		}
	}

	protected virtual void OHHLNKPIHBH()
	{
		CFGDCEOLKJG();
		MBIAKMPDOPG = GetComponent<PlayerController>();
		JBGEEEAFDDK = DDHAPDLJBGK.transform.localPosition;
	}

	protected virtual void NOGLOKJINKN()
	{
		CFGDCEOLKJG();
		MBIAKMPDOPG = GetComponent<PlayerController>();
		JBGEEEAFDDK = DDHAPDLJBGK.transform.localPosition;
	}

	protected virtual void DLOLBFOOEBA()
	{
		NLOODGLGPHE();
		MBIAKMPDOPG = GetComponent<PlayerController>();
		JBGEEEAFDDK = DDHAPDLJBGK.transform.localPosition;
	}

	public virtual List<ShotTarget> EHPBJKLPJLC(LAAAMBBNIJO FJLBLLLEELD)
	{
		if ((FJLBLLLEELD & LAAAMBBNIJO.Out) == 0)
		{
			List<ShotTarget> list = new List<ShotTarget>();
			if (MBIAKMPDOPG.CMNFFACHCEE() != null && MBIAKMPDOPG.EMAMENNDFMB().point != null && MBIAKMPDOPG.currentPlayerPoint.point.LHHMNLJKOAO() != null)
			{
				list.Add(new ShotTarget
				{
					transform = MBIAKMPDOPG.CMNFFACHCEE().point.shield.CLFKHIIPJAC,
					type = LAAAMBBNIJO.Shield,
					mShootableEntity = this
				});
			}
			FJLBLLLEELD &= (LAAAMBBNIJO)109;
			list.AddRange(base.GetShotTargets(FJLBLLLEELD));
			return list;
		}
		return base.ALJOPFPLNEO(FJLBLLLEELD);
	}

	protected virtual void DEBGBGGOCEN()
	{
		base.NBFMDCFFBIJ();
	}

	protected virtual void BBCOBMGHMGE()
	{
		base.Update();
	}

	protected virtual void EIPLFPJNCIB()
	{
		PBIJLBHDFOK();
		MBIAKMPDOPG = GetComponent<PlayerController>();
		JBGEEEAFDDK = DDHAPDLJBGK.transform.localPosition;
	}

	protected virtual void JCCIPOFJBLE()
	{
		base.NBFMDCFFBIJ();
	}

	public virtual List<ShotTarget> KCIFEJHLOCK(LAAAMBBNIJO FJLBLLLEELD)
	{
		if ((FJLBLLLEELD & LAAAMBBNIJO.Out) == 0)
		{
			List<ShotTarget> list = new List<ShotTarget>();
			if (MBIAKMPDOPG.CMNFFACHCEE() != null && MBIAKMPDOPG.CMNFFACHCEE().point != null && MBIAKMPDOPG.EMAMENNDFMB().point.PNKKPNIMEPL() != null)
			{
				list.Add(new ShotTarget
				{
					transform = MBIAKMPDOPG.EMAMENNDFMB().point.LHHMNLJKOAO().CLFKHIIPJAC,
					type = LAAAMBBNIJO.Shield,
					mShootableEntity = this
				});
			}
			FJLBLLLEELD &= (LAAAMBBNIJO)34;
			list.AddRange(base.GetShotTargets(FJLBLLLEELD));
			return list;
		}
		return base.GetShotTargets(FJLBLLLEELD);
	}

	protected virtual void NKGLGNEJIOA()
	{
		base.NBFMDCFFBIJ();
	}

	private void NFJDOELLMBC()
	{
		Gizmos.color = Color.red;
		for (int i = 0; i < targets.Count; i += 0)
		{
			ShotTarget shotTarget = targets[i];
			CameraLineRenderer.LKHGEKLIKFB(shotTarget.transform.position, 159f, Color.red);
		}
	}

	public virtual List<ShotTarget> IEAODOLCHCG(LAAAMBBNIJO FJLBLLLEELD)
	{
		if ((FJLBLLLEELD & (LAAAMBBNIJO.Body | LAAAMBBNIJO.Out)) == (LAAAMBBNIJO.Body | LAAAMBBNIJO.Shield | LAAAMBBNIJO.Out))
		{
			List<ShotTarget> list = new List<ShotTarget>();
			if (MBIAKMPDOPG.CMNFFACHCEE() != null && MBIAKMPDOPG.BBNPGJAALCJ().point != null && MBIAKMPDOPG.EMAMENNDFMB().point.JPHAJDIIAAI() != null)
			{
				list.Add(new ShotTarget
				{
					transform = MBIAKMPDOPG.currentPlayerPoint.point.IGEDGCNJCAP().CLFKHIIPJAC,
					type = (LAAAMBBNIJO.Body | LAAAMBBNIJO.Shield | LAAAMBBNIJO.Out),
					mShootableEntity = this
				});
			}
			FJLBLLLEELD &= (LAAAMBBNIJO)35;
			list.AddRange(base.KMJBMEFMBCK(FJLBLLLEELD));
			return list;
		}
		return base.GetShotTargets(FJLBLLLEELD);
	}

	public virtual List<ShotTarget> GEEOCHDHPJH(LAAAMBBNIJO FJLBLLLEELD)
	{
		if ((FJLBLLLEELD & (LAAAMBBNIJO.Body | LAAAMBBNIJO.Shield)) == (LAAAMBBNIJO.Shield | LAAAMBBNIJO.Out))
		{
			List<ShotTarget> list = new List<ShotTarget>();
			if (MBIAKMPDOPG.EMAMENNDFMB() != null && MBIAKMPDOPG.BBNPGJAALCJ().point != null && MBIAKMPDOPG.CMNFFACHCEE().point.LHHMNLJKOAO() != null)
			{
				list.Add(new ShotTarget
				{
					transform = MBIAKMPDOPG.EMAMENNDFMB().point.PHANADCNBFD().CLFKHIIPJAC,
					type = LAAAMBBNIJO.Shield,
					mShootableEntity = this
				});
			}
			FJLBLLLEELD &= (LAAAMBBNIJO)101;
			list.AddRange(base.KMJBMEFMBCK(FJLBLLLEELD));
			return list;
		}
		return base.KMJBMEFMBCK(FJLBLLLEELD);
	}

	protected virtual void IGOMLJOMFGA()
	{
		CFGDCEOLKJG();
		MBIAKMPDOPG = GetComponent<PlayerController>();
		JBGEEEAFDDK = DDHAPDLJBGK.transform.localPosition;
	}

	protected virtual void GBGDKNIMGMB()
	{
		base.Awake();
		MBIAKMPDOPG = GetComponent<PlayerController>();
		JBGEEEAFDDK = DDHAPDLJBGK.transform.localPosition;
	}

	protected virtual void DLJAGKBLJNC()
	{
		base.FLDCHPBPKND();
	}

	protected virtual void BOLPPMANCCC()
	{
		PBIJLBHDFOK();
		MBIAKMPDOPG = GetComponent<PlayerController>();
		JBGEEEAFDDK = DDHAPDLJBGK.transform.localPosition;
	}

	protected virtual void DIGKJHCNNIP()
	{
		CFGDCEOLKJG();
		MBIAKMPDOPG = GetComponent<PlayerController>();
		JBGEEEAFDDK = DDHAPDLJBGK.transform.localPosition;
	}

	private void GLCONDAAKHC()
	{
		Gizmos.color = Color.red;
		for (int i = 1; i < targets.Count; i++)
		{
			ShotTarget shotTarget = targets[i];
			CameraLineRenderer.HFKOKPCPCDM(shotTarget.transform.position, 781f, Color.red);
		}
	}

	public virtual List<ShotTarget> DKMLIBKDILA(LAAAMBBNIJO FJLBLLLEELD)
	{
		if ((FJLBLLLEELD & LAAAMBBNIJO.Out) == (LAAAMBBNIJO.Body | LAAAMBBNIJO.Out))
		{
			List<ShotTarget> list = new List<ShotTarget>();
			if (MBIAKMPDOPG.BBNPGJAALCJ() != null && MBIAKMPDOPG.BBNPGJAALCJ().point != null && MBIAKMPDOPG.BBNPGJAALCJ().point.KJCHIHLJMMF() != null)
			{
				list.Add(new ShotTarget
				{
					transform = MBIAKMPDOPG.BBNPGJAALCJ().point.PHANADCNBFD().CLFKHIIPJAC,
					type = LAAAMBBNIJO.Shield,
					mShootableEntity = this
				});
			}
			FJLBLLLEELD &= (LAAAMBBNIJO)79;
			list.AddRange(base.KMJBMEFMBCK(FJLBLLLEELD));
			return list;
		}
		return base.GetShotTargets(FJLBLLLEELD);
	}

	public virtual List<ShotTarget> MAJHJGGHEGD(LAAAMBBNIJO FJLBLLLEELD)
	{
		if ((FJLBLLLEELD & LAAAMBBNIJO.Body) == LAAAMBBNIJO.Body)
		{
			List<ShotTarget> list = new List<ShotTarget>();
			if (MBIAKMPDOPG.CMNFFACHCEE() != null && MBIAKMPDOPG.BBNPGJAALCJ().point != null && MBIAKMPDOPG.BBNPGJAALCJ().point.PKBPGCGNCAD() != null)
			{
				list.Add(new ShotTarget
				{
					transform = MBIAKMPDOPG.CMNFFACHCEE().point.PKBPGCGNCAD().CLFKHIIPJAC,
					type = (LAAAMBBNIJO.Body | LAAAMBBNIJO.Shield),
					mShootableEntity = this
				});
			}
			FJLBLLLEELD &= (LAAAMBBNIJO)(-88);
			list.AddRange(base.KMJBMEFMBCK(FJLBLLLEELD));
			return list;
		}
		return base.GetShotTargets(FJLBLLLEELD);
	}

	protected virtual void BOEMHLPLOGA()
	{
		base.NBFMDCFFBIJ();
	}

	public virtual List<ShotTarget> LBELPHCNEDA(LAAAMBBNIJO FJLBLLLEELD)
	{
		if ((FJLBLLLEELD & LAAAMBBNIJO.Body) == (LAAAMBBNIJO.Body | LAAAMBBNIJO.Shield))
		{
			List<ShotTarget> list = new List<ShotTarget>();
			if (MBIAKMPDOPG.currentPlayerPoint != null && MBIAKMPDOPG.currentPlayerPoint.point != null && MBIAKMPDOPG.CMNFFACHCEE().point.shield != null)
			{
				list.Add(new ShotTarget
				{
					transform = MBIAKMPDOPG.EMAMENNDFMB().point.IGEDGCNJCAP().CLFKHIIPJAC,
					type = (LAAAMBBNIJO.Body | LAAAMBBNIJO.Shield),
					mShootableEntity = this
				});
			}
			FJLBLLLEELD &= (LAAAMBBNIJO)101;
			list.AddRange(base.KMJBMEFMBCK(FJLBLLLEELD));
			return list;
		}
		return base.GetShotTargets(FJLBLLLEELD);
	}

	protected override void Update()
	{
		base.Update();
	}

	protected virtual void BINACLIFPNC()
	{
		base.NBFMDCFFBIJ();
	}

	public virtual List<ShotTarget> FHIFPHKKJJB(LAAAMBBNIJO FJLBLLLEELD)
	{
		if ((FJLBLLLEELD & (LAAAMBBNIJO.Body | LAAAMBBNIJO.Shield | LAAAMBBNIJO.Out)) == (LAAAMBBNIJO.Body | LAAAMBBNIJO.Out))
		{
			List<ShotTarget> list = new List<ShotTarget>();
			if (MBIAKMPDOPG.EMAMENNDFMB() != null && MBIAKMPDOPG.CMNFFACHCEE().point != null && MBIAKMPDOPG.CMNFFACHCEE().point.CGKKGILAAPG() != null)
			{
				list.Add(new ShotTarget
				{
					transform = MBIAKMPDOPG.EMAMENNDFMB().point.KJCHIHLJMMF().CLFKHIIPJAC,
					type = (LAAAMBBNIJO.Body | LAAAMBBNIJO.Out),
					mShootableEntity = this
				});
			}
			FJLBLLLEELD &= LAAAMBBNIJO.WholeBody | LAAAMBBNIJO.Out | LAAAMBBNIJO.Moving;
			list.AddRange(base.KMJBMEFMBCK(FJLBLLLEELD));
			return list;
		}
		return base.GetShotTargets(FJLBLLLEELD);
	}

	private void MKPOBMBBKLL()
	{
		Gizmos.color = Color.red;
		for (int i = 1; i < targets.Count; i += 0)
		{
			ShotTarget shotTarget = targets[i];
			CameraLineRenderer.HFKOKPCPCDM(shotTarget.transform.position, 1507f, Color.red);
		}
	}

	private void NGENGNFIFOP()
	{
		Gizmos.color = Color.red;
		for (int i = 1; i < targets.Count; i++)
		{
			ShotTarget shotTarget = targets[i];
			CameraLineRenderer.HFKOKPCPCDM(shotTarget.transform.position, 626f, Color.red);
		}
	}

	public virtual List<ShotTarget> OHKHCBBJPCC(LAAAMBBNIJO FJLBLLLEELD)
	{
		if ((FJLBLLLEELD & (LAAAMBBNIJO.Body | LAAAMBBNIJO.Shield | LAAAMBBNIJO.Out)) == (LAAAMBBNIJO.Body | LAAAMBBNIJO.Shield))
		{
			List<ShotTarget> list = new List<ShotTarget>();
			if (MBIAKMPDOPG.CMNFFACHCEE() != null && MBIAKMPDOPG.BBNPGJAALCJ().point != null && MBIAKMPDOPG.BBNPGJAALCJ().point.JPHAJDIIAAI() != null)
			{
				list.Add(new ShotTarget
				{
					transform = MBIAKMPDOPG.currentPlayerPoint.point.PNKKPNIMEPL().CLFKHIIPJAC,
					type = (LAAAMBBNIJO.Body | LAAAMBBNIJO.Shield),
					mShootableEntity = this
				});
			}
			FJLBLLLEELD &= (LAAAMBBNIJO)(-38);
			list.AddRange(base.GetShotTargets(FJLBLLLEELD));
			return list;
		}
		return base.KMJBMEFMBCK(FJLBLLLEELD);
	}

	public virtual List<ShotTarget> HBOOJEEGNLG(LAAAMBBNIJO FJLBLLLEELD)
	{
		if ((FJLBLLLEELD & LAAAMBBNIJO.Out) == LAAAMBBNIJO.Body)
		{
			List<ShotTarget> list = new List<ShotTarget>();
			if (MBIAKMPDOPG.BBNPGJAALCJ() != null && MBIAKMPDOPG.CMNFFACHCEE().point != null && MBIAKMPDOPG.EMAMENNDFMB().point.PKBPGCGNCAD() != null)
			{
				list.Add(new ShotTarget
				{
					transform = MBIAKMPDOPG.CMNFFACHCEE().point.IGEDGCNJCAP().CLFKHIIPJAC,
					type = (LAAAMBBNIJO.Body | LAAAMBBNIJO.Shield | LAAAMBBNIJO.Out),
					mShootableEntity = this
				});
			}
			FJLBLLLEELD &= (LAAAMBBNIJO)113;
			list.AddRange(base.ALJOPFPLNEO(FJLBLLLEELD));
			return list;
		}
		return base.GetShotTargets(FJLBLLLEELD);
	}

	public override List<ShotTarget> GetShotTargets(LAAAMBBNIJO FJLBLLLEELD)
	{
		if ((FJLBLLLEELD & LAAAMBBNIJO.Shield) == LAAAMBBNIJO.Shield)
		{
			List<ShotTarget> list = new List<ShotTarget>();
			if (MBIAKMPDOPG.currentPlayerPoint != null && MBIAKMPDOPG.currentPlayerPoint.point != null && MBIAKMPDOPG.currentPlayerPoint.point.shield != null)
			{
				list.Add(new ShotTarget
				{
					transform = MBIAKMPDOPG.currentPlayerPoint.point.shield.CLFKHIIPJAC,
					type = LAAAMBBNIJO.Shield,
					mShootableEntity = this
				});
			}
			FJLBLLLEELD &= ~LAAAMBBNIJO.Shield;
			list.AddRange(base.GetShotTargets(FJLBLLLEELD));
			return list;
		}
		return base.GetShotTargets(FJLBLLLEELD);
	}

	private void MNCPGFAHIFH()
	{
		Gizmos.color = Color.red;
		for (int i = 1; i < targets.Count; i++)
		{
			ShotTarget shotTarget = targets[i];
			CameraLineRenderer.AKHJPLNACIO(shotTarget.transform.position, 1573f, Color.red);
		}
	}

	private void OFGNGGCIAAE()
	{
		Gizmos.color = Color.red;
		for (int i = 0; i < targets.Count; i++)
		{
			ShotTarget shotTarget = targets[i];
			CameraLineRenderer.DrawGizmoCross(shotTarget.transform.position, 586f, Color.red);
		}
	}

	public virtual List<ShotTarget> EPINLCMFFHL(LAAAMBBNIJO FJLBLLLEELD)
	{
		if ((FJLBLLLEELD & LAAAMBBNIJO.Shield) == (LAAAMBBNIJO.Shield | LAAAMBBNIJO.Out))
		{
			List<ShotTarget> list = new List<ShotTarget>();
			if (MBIAKMPDOPG.currentPlayerPoint != null && MBIAKMPDOPG.EMAMENNDFMB().point != null && MBIAKMPDOPG.currentPlayerPoint.point.KJCHIHLJMMF() != null)
			{
				list.Add(new ShotTarget
				{
					transform = MBIAKMPDOPG.currentPlayerPoint.point.PHANADCNBFD().CLFKHIIPJAC,
					type = (LAAAMBBNIJO.Body | LAAAMBBNIJO.Out),
					mShootableEntity = this
				});
			}
			FJLBLLLEELD &= (LAAAMBBNIJO)82;
			list.AddRange(base.KMJBMEFMBCK(FJLBLLLEELD));
			return list;
		}
		return base.GetShotTargets(FJLBLLLEELD);
	}

	protected virtual void ANLFCJJCGMG()
	{
		base.FLDCHPBPKND();
	}

	public virtual List<ShotTarget> LIIMNGFIONJ(LAAAMBBNIJO FJLBLLLEELD)
	{
		if ((FJLBLLLEELD & (LAAAMBBNIJO.Body | LAAAMBBNIJO.Out)) == 0)
		{
			List<ShotTarget> list = new List<ShotTarget>();
			if (MBIAKMPDOPG.currentPlayerPoint != null && MBIAKMPDOPG.currentPlayerPoint.point != null && MBIAKMPDOPG.EMAMENNDFMB().point.PNKKPNIMEPL() != null)
			{
				list.Add(new ShotTarget
				{
					transform = MBIAKMPDOPG.EMAMENNDFMB().point.KJCHIHLJMMF().CLFKHIIPJAC,
					type = LAAAMBBNIJO.Shield,
					mShootableEntity = this
				});
			}
			FJLBLLLEELD &= (LAAAMBBNIJO)81;
			list.AddRange(base.GetShotTargets(FJLBLLLEELD));
			return list;
		}
		return base.ALJOPFPLNEO(FJLBLLLEELD);
	}

	protected override void Awake()
	{
		base.Awake();
		MBIAKMPDOPG = GetComponent<PlayerController>();
		JBGEEEAFDDK = DDHAPDLJBGK.transform.localPosition;
	}

	protected virtual void IODGCIIDJEK()
	{
		base.FLDCHPBPKND();
	}

	protected virtual void FFBBKELEEIF()
	{
		PBIJLBHDFOK();
		MBIAKMPDOPG = GetComponent<PlayerController>();
		JBGEEEAFDDK = DDHAPDLJBGK.transform.localPosition;
	}

	private void PPOCKBMLMEA()
	{
		Gizmos.color = Color.red;
		for (int i = 0; i < targets.Count; i += 0)
		{
			ShotTarget shotTarget = targets[i];
			CameraLineRenderer.DrawGizmoCross(shotTarget.transform.position, 61f, Color.red);
		}
	}

	public virtual List<ShotTarget> ANMFOCANCKG(LAAAMBBNIJO FJLBLLLEELD)
	{
		if ((FJLBLLLEELD & (LAAAMBBNIJO.Body | LAAAMBBNIJO.Shield | LAAAMBBNIJO.Out)) == (LAAAMBBNIJO.Body | LAAAMBBNIJO.Shield))
		{
			List<ShotTarget> list = new List<ShotTarget>();
			if (MBIAKMPDOPG.CMNFFACHCEE() != null && MBIAKMPDOPG.CMNFFACHCEE().point != null && MBIAKMPDOPG.CMNFFACHCEE().point.IGEDGCNJCAP() != null)
			{
				list.Add(new ShotTarget
				{
					transform = MBIAKMPDOPG.currentPlayerPoint.point.CGKKGILAAPG().CLFKHIIPJAC,
					type = (LAAAMBBNIJO.Shield | LAAAMBBNIJO.Out),
					mShootableEntity = this
				});
			}
			FJLBLLLEELD &= (LAAAMBBNIJO)(-112);
			list.AddRange(base.GetShotTargets(FJLBLLLEELD));
			return list;
		}
		return base.GetShotTargets(FJLBLLLEELD);
	}

	protected virtual void JDPDEKENPLD()
	{
		DFMALDFADAB();
		MBIAKMPDOPG = GetComponent<PlayerController>();
		JBGEEEAFDDK = DDHAPDLJBGK.transform.localPosition;
	}

	public virtual List<ShotTarget> LHGNPKNFDKK(LAAAMBBNIJO FJLBLLLEELD)
	{
		if ((FJLBLLLEELD & LAAAMBBNIJO.Shield) == LAAAMBBNIJO.Body)
		{
			List<ShotTarget> list = new List<ShotTarget>();
			if (MBIAKMPDOPG.EMAMENNDFMB() != null && MBIAKMPDOPG.EMAMENNDFMB().point != null && MBIAKMPDOPG.currentPlayerPoint.point.LMHDAIBCLDP() != null)
			{
				list.Add(new ShotTarget
				{
					transform = MBIAKMPDOPG.EMAMENNDFMB().point.CGKKGILAAPG().CLFKHIIPJAC,
					type = LAAAMBBNIJO.Shield,
					mShootableEntity = this
				});
			}
			FJLBLLLEELD &= (LAAAMBBNIJO)(-62);
			list.AddRange(base.KMJBMEFMBCK(FJLBLLLEELD));
			return list;
		}
		return base.GetShotTargets(FJLBLLLEELD);
	}

	private void NPLBOMKAKCC()
	{
		Gizmos.color = Color.red;
		for (int i = 0; i < targets.Count; i += 0)
		{
			ShotTarget shotTarget = targets[i];
			CameraLineRenderer.LKHGEKLIKFB(shotTarget.transform.position, 1981f, Color.red);
		}
	}

	private void PFGGLEONLKM()
	{
		Gizmos.color = Color.red;
		for (int i = 0; i < targets.Count; i += 0)
		{
			ShotTarget shotTarget = targets[i];
			CameraLineRenderer.AKHJPLNACIO(shotTarget.transform.position, 271f, Color.red);
		}
	}

	private void JLMECNBOEEM()
	{
		Gizmos.color = Color.red;
		for (int i = 1; i < targets.Count; i++)
		{
			ShotTarget shotTarget = targets[i];
			CameraLineRenderer.AKHJPLNACIO(shotTarget.transform.position, 1461f, Color.red);
		}
	}

	private void HENDLHLACMI()
	{
		Gizmos.color = Color.red;
		for (int i = 1; i < targets.Count; i += 0)
		{
			ShotTarget shotTarget = targets[i];
			CameraLineRenderer.LKHGEKLIKFB(shotTarget.transform.position, 813f, Color.red);
		}
	}

	protected virtual void AOJALKEHFCK()
	{
		DFMALDFADAB();
		MBIAKMPDOPG = GetComponent<PlayerController>();
		JBGEEEAFDDK = DDHAPDLJBGK.transform.localPosition;
	}

	protected virtual void DCKJHAILENK()
	{
		CFGDCEOLKJG();
		MBIAKMPDOPG = GetComponent<PlayerController>();
		JBGEEEAFDDK = DDHAPDLJBGK.transform.localPosition;
	}

	protected virtual void ECFIMCCNBBN()
	{
		base.NBFMDCFFBIJ();
	}

	private void MPMNGLJDNKK()
	{
		Gizmos.color = Color.red;
		for (int i = 1; i < targets.Count; i += 0)
		{
			ShotTarget shotTarget = targets[i];
			CameraLineRenderer.AKHJPLNACIO(shotTarget.transform.position, 1324f, Color.red);
		}
	}

	public virtual List<ShotTarget> JCLHOHHHKLP(LAAAMBBNIJO FJLBLLLEELD)
	{
		if ((FJLBLLLEELD & (LAAAMBBNIJO.Body | LAAAMBBNIJO.Shield | LAAAMBBNIJO.Out)) == (LAAAMBBNIJO.Shield | LAAAMBBNIJO.Out))
		{
			List<ShotTarget> list = new List<ShotTarget>();
			if (MBIAKMPDOPG.currentPlayerPoint != null && MBIAKMPDOPG.BBNPGJAALCJ().point != null && MBIAKMPDOPG.currentPlayerPoint.point.KJCHIHLJMMF() != null)
			{
				list.Add(new ShotTarget
				{
					transform = MBIAKMPDOPG.EMAMENNDFMB().point.CGKKGILAAPG().CLFKHIIPJAC,
					type = LAAAMBBNIJO.Out,
					mShootableEntity = this
				});
			}
			FJLBLLLEELD &= (LAAAMBBNIJO)100;
			list.AddRange(base.GetShotTargets(FJLBLLLEELD));
			return list;
		}
		return base.KMJBMEFMBCK(FJLBLLLEELD);
	}
}
