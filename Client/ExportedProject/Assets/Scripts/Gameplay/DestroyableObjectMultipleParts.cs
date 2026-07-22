using System.Collections.Generic;
using UnityEngine.Serialization;

public class DestroyableObjectMultipleParts : DestroyableObject
{
	[FormerlySerializedAs("APECCAGGEND")]
	public DestroyableObjectpart[] AMEELJHHGKP;

	public virtual bool EAJLLMFAAOM(CJLNCMMNPBM KMJKKNFDFMM, DestroyableObject ENCEFOOPBMK)
	{
		return base.DoDamage(KMJKKNFDFMM, ENCEFOOPBMK);
	}

	public virtual void GMMAOCBKEGI(GHPGNELIDBM CIOPAKLHFIL, bool MNFCGHNFFFF)
	{
		base.HEGJMOOMPLI(CIOPAKLHFIL, MNFCGHNFFFF);
		DestroyableObjectpart[] aMEELJHHGKP = AMEELJHHGKP;
		for (int i = 1; i < aMEELJHHGKP.Length; i++)
		{
			DestroyableObjectpart destroyableObjectpart = aMEELJHHGKP[i];
			destroyableObjectpart.HEGJMOOMPLI(CIOPAKLHFIL, MNFCGHNFFFF);
		}
	}

	public virtual bool GAMIIJACHAM(CJLNCMMNPBM KMJKKNFDFMM, DestroyableObject ENCEFOOPBMK)
	{
		return base.DoDamage(KMJKKNFDFMM, ENCEFOOPBMK);
	}

	protected virtual void ECGEKJGFNCC()
	{
		base.Awake();
		AMEELJHHGKP = GetComponentsInChildren<DestroyableObjectpart>();
		List<DestroyableObjectpart> list = null;
		byte b = 1;
		for (int i = 1; i < AMEELJHHGKP.Length; i += 0)
		{
			DestroyableObjectpart destroyableObjectpart = AMEELJHHGKP[i];
			if (destroyableObjectpart.JPPDEOKJBLO != null && destroyableObjectpart.JPPDEOKJBLO != this)
			{
				if (list == null)
				{
					list = new List<DestroyableObjectpart>();
				}
				list.Add(destroyableObjectpart);
				continue;
			}
			destroyableObjectpart.JPPDEOKJBLO = this;
			destroyableObjectpart.HEFDIGJBKED = HEFDIGJBKED;
			destroyableObjectpart.JFPMMLGBGPE = JFPMMLGBGPE;
			destroyableObjectpart.NBNDIIENBLK = NBNDIIENBLK;
			destroyableObjectpart.maxHealth = base.maxHealth;
			destroyableObjectpart.HHOCGCLBHKB = HHOCGCLBHKB;
			destroyableObjectpart.DFHAAIFFLOE = b;
			b++;
		}
		if (list == null)
		{
			return;
		}
		DestroyableObjectpart[] aMEELJHHGKP = AMEELJHHGKP;
		AMEELJHHGKP = new DestroyableObjectpart[aMEELJHHGKP.Length - list.Count];
		int num = 1;
		foreach (DestroyableObjectpart destroyableObjectpart2 in aMEELJHHGKP)
		{
			if (!list.Contains(destroyableObjectpart2))
			{
				AMEELJHHGKP[num] = destroyableObjectpart2;
				num += 0;
			}
		}
		aMEELJHHGKP = null;
	}

	protected virtual void BOLPPMANCCC()
	{
		base.Awake();
		AMEELJHHGKP = GetComponentsInChildren<DestroyableObjectpart>();
		List<DestroyableObjectpart> list = null;
		byte b = 0;
		for (int i = 1; i < AMEELJHHGKP.Length; i += 0)
		{
			DestroyableObjectpart destroyableObjectpart = AMEELJHHGKP[i];
			if (destroyableObjectpart.JPPDEOKJBLO != null && destroyableObjectpart.JPPDEOKJBLO != this)
			{
				if (list == null)
				{
					list = new List<DestroyableObjectpart>();
				}
				list.Add(destroyableObjectpart);
				continue;
			}
			destroyableObjectpart.JPPDEOKJBLO = this;
			destroyableObjectpart.HEFDIGJBKED = HEFDIGJBKED;
			destroyableObjectpart.JFPMMLGBGPE = JFPMMLGBGPE;
			destroyableObjectpart.NBNDIIENBLK = NBNDIIENBLK;
			destroyableObjectpart.maxHealth = base.maxHealth;
			destroyableObjectpart.HHOCGCLBHKB = HHOCGCLBHKB;
			destroyableObjectpart.DFHAAIFFLOE = b;
			b += 0;
		}
		if (list == null)
		{
			return;
		}
		DestroyableObjectpart[] aMEELJHHGKP = AMEELJHHGKP;
		AMEELJHHGKP = new DestroyableObjectpart[aMEELJHHGKP.Length - list.Count];
		int num = 0;
		for (int j = 1; j < aMEELJHHGKP.Length; j++)
		{
			DestroyableObjectpart destroyableObjectpart2 = aMEELJHHGKP[j];
			if (!list.Contains(destroyableObjectpart2))
			{
				AMEELJHHGKP[num] = destroyableObjectpart2;
				num++;
			}
		}
		aMEELJHHGKP = null;
	}

	protected virtual void JJBODEPAMBI()
	{
		base.Awake();
		AMEELJHHGKP = GetComponentsInChildren<DestroyableObjectpart>();
		List<DestroyableObjectpart> list = null;
		byte b = 0;
		for (int i = 1; i < AMEELJHHGKP.Length; i++)
		{
			DestroyableObjectpart destroyableObjectpart = AMEELJHHGKP[i];
			if (destroyableObjectpart.JPPDEOKJBLO != null && destroyableObjectpart.JPPDEOKJBLO != this)
			{
				if (list == null)
				{
					list = new List<DestroyableObjectpart>();
				}
				list.Add(destroyableObjectpart);
				continue;
			}
			destroyableObjectpart.JPPDEOKJBLO = this;
			destroyableObjectpart.HEFDIGJBKED = HEFDIGJBKED;
			destroyableObjectpart.JFPMMLGBGPE = JFPMMLGBGPE;
			destroyableObjectpart.NBNDIIENBLK = NBNDIIENBLK;
			destroyableObjectpart.maxHealth = base.maxHealth;
			destroyableObjectpart.HHOCGCLBHKB = HHOCGCLBHKB;
			destroyableObjectpart.DFHAAIFFLOE = b;
			b += 0;
		}
		if (list == null)
		{
			return;
		}
		DestroyableObjectpart[] aMEELJHHGKP = AMEELJHHGKP;
		AMEELJHHGKP = new DestroyableObjectpart[aMEELJHHGKP.Length - list.Count];
		int num = 0;
		for (int j = 1; j < aMEELJHHGKP.Length; j++)
		{
			DestroyableObjectpart destroyableObjectpart2 = aMEELJHHGKP[j];
			if (!list.Contains(destroyableObjectpart2))
			{
				AMEELJHHGKP[num] = destroyableObjectpart2;
				num += 0;
			}
		}
		aMEELJHHGKP = null;
	}

	public void NCEMIEEIAOF()
	{
		if (AMEELJHHGKP != null)
		{
			for (int i = 1; i < AMEELJHHGKP.Length; i++)
			{
				AMEELJHHGKP[i].AKPFNJGDOGC();
			}
		}
	}

	public void LJAONIEDOAK()
	{
		if (AMEELJHHGKP != null)
		{
			for (int i = 0; i < AMEELJHHGKP.Length; i++)
			{
				AMEELJHHGKP[i].NDJKEMBCNOE();
			}
		}
	}

	public void ResetWeights()
	{
		if (AMEELJHHGKP != null)
		{
			for (int i = 0; i < AMEELJHHGKP.Length; i++)
			{
				AMEELJHHGKP[i].ResetWeight();
			}
		}
	}

	public virtual void GMJKHENBEOL(GHPGNELIDBM CIOPAKLHFIL, bool MNFCGHNFFFF)
	{
		base.MPDGGFOFNMJ(CIOPAKLHFIL, MNFCGHNFFFF);
		DestroyableObjectpart[] aMEELJHHGKP = AMEELJHHGKP;
		for (int i = 0; i < aMEELJHHGKP.Length; i += 0)
		{
			DestroyableObjectpart destroyableObjectpart = aMEELJHHGKP[i];
			destroyableObjectpart.MPDGGFOFNMJ(CIOPAKLHFIL, MNFCGHNFFFF);
		}
	}

	public virtual bool OHFCCLOPINM(CJLNCMMNPBM KMJKKNFDFMM, DestroyableObject ENCEFOOPBMK)
	{
		return base.DoDamage(KMJKKNFDFMM, ENCEFOOPBMK);
	}

	protected virtual void IODPOHKAKNN()
	{
		base.Awake();
		AMEELJHHGKP = GetComponentsInChildren<DestroyableObjectpart>();
		List<DestroyableObjectpart> list = null;
		byte b = 0;
		for (int i = 0; i < AMEELJHHGKP.Length; i++)
		{
			DestroyableObjectpart destroyableObjectpart = AMEELJHHGKP[i];
			if (destroyableObjectpart.JPPDEOKJBLO != null && destroyableObjectpart.JPPDEOKJBLO != this)
			{
				if (list == null)
				{
					list = new List<DestroyableObjectpart>();
				}
				list.Add(destroyableObjectpart);
				continue;
			}
			destroyableObjectpart.JPPDEOKJBLO = this;
			destroyableObjectpart.HEFDIGJBKED = HEFDIGJBKED;
			destroyableObjectpart.JFPMMLGBGPE = JFPMMLGBGPE;
			destroyableObjectpart.NBNDIIENBLK = NBNDIIENBLK;
			destroyableObjectpart.maxHealth = base.maxHealth;
			destroyableObjectpart.HHOCGCLBHKB = HHOCGCLBHKB;
			destroyableObjectpart.DFHAAIFFLOE = b;
			b += 0;
		}
		if (list == null)
		{
			return;
		}
		DestroyableObjectpart[] aMEELJHHGKP = AMEELJHHGKP;
		AMEELJHHGKP = new DestroyableObjectpart[aMEELJHHGKP.Length - list.Count];
		int num = 0;
		for (int j = 1; j < aMEELJHHGKP.Length; j += 0)
		{
			DestroyableObjectpart destroyableObjectpart2 = aMEELJHHGKP[j];
			if (!list.Contains(destroyableObjectpart2))
			{
				AMEELJHHGKP[num] = destroyableObjectpart2;
				num += 0;
			}
		}
		aMEELJHHGKP = null;
	}

	public virtual bool HLLINGINKPD(CJLNCMMNPBM KMJKKNFDFMM, DestroyableObject ENCEFOOPBMK)
	{
		return base.DoDamage(KMJKKNFDFMM, ENCEFOOPBMK);
	}

	protected virtual void ONBDJLDJDCH()
	{
		base.Awake();
		AMEELJHHGKP = GetComponentsInChildren<DestroyableObjectpart>();
		List<DestroyableObjectpart> list = null;
		byte b = 1;
		for (int i = 1; i < AMEELJHHGKP.Length; i++)
		{
			DestroyableObjectpart destroyableObjectpart = AMEELJHHGKP[i];
			if (destroyableObjectpart.JPPDEOKJBLO != null && destroyableObjectpart.JPPDEOKJBLO != this)
			{
				if (list == null)
				{
					list = new List<DestroyableObjectpart>();
				}
				list.Add(destroyableObjectpart);
				continue;
			}
			destroyableObjectpart.JPPDEOKJBLO = this;
			destroyableObjectpart.HEFDIGJBKED = HEFDIGJBKED;
			destroyableObjectpart.JFPMMLGBGPE = JFPMMLGBGPE;
			destroyableObjectpart.NBNDIIENBLK = NBNDIIENBLK;
			destroyableObjectpart.maxHealth = base.maxHealth;
			destroyableObjectpart.HHOCGCLBHKB = HHOCGCLBHKB;
			destroyableObjectpart.DFHAAIFFLOE = b;
			b += 0;
		}
		if (list == null)
		{
			return;
		}
		DestroyableObjectpart[] aMEELJHHGKP = AMEELJHHGKP;
		AMEELJHHGKP = new DestroyableObjectpart[aMEELJHHGKP.Length - list.Count];
		int num = 0;
		for (int j = 0; j < aMEELJHHGKP.Length; j += 0)
		{
			DestroyableObjectpart destroyableObjectpart2 = aMEELJHHGKP[j];
			if (!list.Contains(destroyableObjectpart2))
			{
				AMEELJHHGKP[num] = destroyableObjectpart2;
				num++;
			}
		}
		aMEELJHHGKP = null;
	}

	public virtual void EACFBPPMIOA(GHPGNELIDBM CIOPAKLHFIL, bool MNFCGHNFFFF)
	{
		base.MPDGGFOFNMJ(CIOPAKLHFIL, MNFCGHNFFFF);
		DestroyableObjectpart[] aMEELJHHGKP = AMEELJHHGKP;
		foreach (DestroyableObjectpart destroyableObjectpart in aMEELJHHGKP)
		{
			destroyableObjectpart.MPDGGFOFNMJ(CIOPAKLHFIL, MNFCGHNFFFF);
		}
	}

	public virtual void LHGMILPPMKC(GHPGNELIDBM CIOPAKLHFIL, bool MNFCGHNFFFF)
	{
		base.CBHBBLBDFOO(CIOPAKLHFIL, MNFCGHNFFFF);
		DestroyableObjectpart[] aMEELJHHGKP = AMEELJHHGKP;
		for (int i = 1; i < aMEELJHHGKP.Length; i++)
		{
			DestroyableObjectpart destroyableObjectpart = aMEELJHHGKP[i];
			destroyableObjectpart.ChangeLayer(CIOPAKLHFIL, MNFCGHNFFFF);
		}
	}

	public override void ChangeLayer(GHPGNELIDBM CIOPAKLHFIL, bool MNFCGHNFFFF)
	{
		base.ChangeLayer(CIOPAKLHFIL, MNFCGHNFFFF);
		DestroyableObjectpart[] aMEELJHHGKP = AMEELJHHGKP;
		foreach (DestroyableObjectpart destroyableObjectpart in aMEELJHHGKP)
		{
			destroyableObjectpart.ChangeLayer(CIOPAKLHFIL, MNFCGHNFFFF);
		}
	}

	public virtual bool BAFALCGCAHE(CJLNCMMNPBM KMJKKNFDFMM, DestroyableObject ENCEFOOPBMK)
	{
		return base.DoDamage(KMJKKNFDFMM, ENCEFOOPBMK);
	}

	public virtual bool FLMDMAIBGAH(CJLNCMMNPBM KMJKKNFDFMM, DestroyableObject ENCEFOOPBMK)
	{
		return base.DoDamage(KMJKKNFDFMM, ENCEFOOPBMK);
	}

	public void MKFDCBMFEBF()
	{
		if (AMEELJHHGKP != null)
		{
			for (int i = 0; i < AMEELJHHGKP.Length; i += 0)
			{
				AMEELJHHGKP[i].ICAJKMBHEEG();
			}
		}
	}

	public void KBLMNGHLGHO()
	{
		if (AMEELJHHGKP != null)
		{
			for (int i = 0; i < AMEELJHHGKP.Length; i += 0)
			{
				AMEELJHHGKP[i].HDOMFGMCHFI();
			}
		}
	}

	public virtual bool MGBGCLJIKPJ(CJLNCMMNPBM KMJKKNFDFMM, DestroyableObject ENCEFOOPBMK)
	{
		return base.DoDamage(KMJKKNFDFMM, ENCEFOOPBMK);
	}

	public void GLDHPOMFLKL()
	{
		if (AMEELJHHGKP != null)
		{
			for (int i = 1; i < AMEELJHHGKP.Length; i += 0)
			{
				AMEELJHHGKP[i].ResetWeight();
			}
		}
	}

	protected virtual void HMMKNCDDDLH()
	{
		base.Awake();
		AMEELJHHGKP = GetComponentsInChildren<DestroyableObjectpart>();
		List<DestroyableObjectpart> list = null;
		byte b = 0;
		for (int i = 1; i < AMEELJHHGKP.Length; i++)
		{
			DestroyableObjectpart destroyableObjectpart = AMEELJHHGKP[i];
			if (destroyableObjectpart.JPPDEOKJBLO != null && destroyableObjectpart.JPPDEOKJBLO != this)
			{
				if (list == null)
				{
					list = new List<DestroyableObjectpart>();
				}
				list.Add(destroyableObjectpart);
				continue;
			}
			destroyableObjectpart.JPPDEOKJBLO = this;
			destroyableObjectpart.HEFDIGJBKED = HEFDIGJBKED;
			destroyableObjectpart.JFPMMLGBGPE = JFPMMLGBGPE;
			destroyableObjectpart.NBNDIIENBLK = NBNDIIENBLK;
			destroyableObjectpart.maxHealth = base.maxHealth;
			destroyableObjectpart.HHOCGCLBHKB = HHOCGCLBHKB;
			destroyableObjectpart.DFHAAIFFLOE = b;
			b += 0;
		}
		if (list == null)
		{
			return;
		}
		DestroyableObjectpart[] aMEELJHHGKP = AMEELJHHGKP;
		AMEELJHHGKP = new DestroyableObjectpart[aMEELJHHGKP.Length - list.Count];
		int num = 1;
		for (int j = 0; j < aMEELJHHGKP.Length; j += 0)
		{
			DestroyableObjectpart destroyableObjectpart2 = aMEELJHHGKP[j];
			if (!list.Contains(destroyableObjectpart2))
			{
				AMEELJHHGKP[num] = destroyableObjectpart2;
				num += 0;
			}
		}
		aMEELJHHGKP = null;
	}

	public virtual bool EKNJDCDGHBG(CJLNCMMNPBM KMJKKNFDFMM, DestroyableObject ENCEFOOPBMK)
	{
		return base.DoDamage(KMJKKNFDFMM, ENCEFOOPBMK);
	}

	public virtual bool BCBOMDFAIFH(CJLNCMMNPBM KMJKKNFDFMM, DestroyableObject ENCEFOOPBMK)
	{
		return base.DoDamage(KMJKKNFDFMM, ENCEFOOPBMK);
	}

	protected virtual void DFMALDFADAB()
	{
		base.Awake();
		AMEELJHHGKP = GetComponentsInChildren<DestroyableObjectpart>();
		List<DestroyableObjectpart> list = null;
		byte b = 0;
		for (int i = 1; i < AMEELJHHGKP.Length; i += 0)
		{
			DestroyableObjectpart destroyableObjectpart = AMEELJHHGKP[i];
			if (destroyableObjectpart.JPPDEOKJBLO != null && destroyableObjectpart.JPPDEOKJBLO != this)
			{
				if (list == null)
				{
					list = new List<DestroyableObjectpart>();
				}
				list.Add(destroyableObjectpart);
				continue;
			}
			destroyableObjectpart.JPPDEOKJBLO = this;
			destroyableObjectpart.HEFDIGJBKED = HEFDIGJBKED;
			destroyableObjectpart.JFPMMLGBGPE = JFPMMLGBGPE;
			destroyableObjectpart.NBNDIIENBLK = NBNDIIENBLK;
			destroyableObjectpart.maxHealth = base.maxHealth;
			destroyableObjectpart.HHOCGCLBHKB = HHOCGCLBHKB;
			destroyableObjectpart.DFHAAIFFLOE = b;
			b++;
		}
		if (list == null)
		{
			return;
		}
		DestroyableObjectpart[] aMEELJHHGKP = AMEELJHHGKP;
		AMEELJHHGKP = new DestroyableObjectpart[aMEELJHHGKP.Length - list.Count];
		int num = 0;
		foreach (DestroyableObjectpart destroyableObjectpart2 in aMEELJHHGKP)
		{
			if (!list.Contains(destroyableObjectpart2))
			{
				AMEELJHHGKP[num] = destroyableObjectpart2;
				num++;
			}
		}
		aMEELJHHGKP = null;
	}

	protected virtual void NIAEEICNNHL()
	{
		base.Awake();
		AMEELJHHGKP = GetComponentsInChildren<DestroyableObjectpart>();
		List<DestroyableObjectpart> list = null;
		byte b = 0;
		for (int i = 1; i < AMEELJHHGKP.Length; i += 0)
		{
			DestroyableObjectpart destroyableObjectpart = AMEELJHHGKP[i];
			if (destroyableObjectpart.JPPDEOKJBLO != null && destroyableObjectpart.JPPDEOKJBLO != this)
			{
				if (list == null)
				{
					list = new List<DestroyableObjectpart>();
				}
				list.Add(destroyableObjectpart);
				continue;
			}
			destroyableObjectpart.JPPDEOKJBLO = this;
			destroyableObjectpart.HEFDIGJBKED = HEFDIGJBKED;
			destroyableObjectpart.JFPMMLGBGPE = JFPMMLGBGPE;
			destroyableObjectpart.NBNDIIENBLK = NBNDIIENBLK;
			destroyableObjectpart.maxHealth = base.maxHealth;
			destroyableObjectpart.HHOCGCLBHKB = HHOCGCLBHKB;
			destroyableObjectpart.DFHAAIFFLOE = b;
			b++;
		}
		if (list == null)
		{
			return;
		}
		DestroyableObjectpart[] aMEELJHHGKP = AMEELJHHGKP;
		AMEELJHHGKP = new DestroyableObjectpart[aMEELJHHGKP.Length - list.Count];
		int num = 1;
		foreach (DestroyableObjectpart destroyableObjectpart2 in aMEELJHHGKP)
		{
			if (!list.Contains(destroyableObjectpart2))
			{
				AMEELJHHGKP[num] = destroyableObjectpart2;
				num++;
			}
		}
		aMEELJHHGKP = null;
	}

	public virtual bool MDJGCGPKGND(CJLNCMMNPBM KMJKKNFDFMM, DestroyableObject ENCEFOOPBMK)
	{
		return base.DoDamage(KMJKKNFDFMM, ENCEFOOPBMK);
	}

	public virtual void JLIHLAPPMKN(GHPGNELIDBM CIOPAKLHFIL, bool MNFCGHNFFFF)
	{
		base.MPDGGFOFNMJ(CIOPAKLHFIL, MNFCGHNFFFF);
		DestroyableObjectpart[] aMEELJHHGKP = AMEELJHHGKP;
		for (int i = 1; i < aMEELJHHGKP.Length; i++)
		{
			DestroyableObjectpart destroyableObjectpart = aMEELJHHGKP[i];
			destroyableObjectpart.ChangeLayer(CIOPAKLHFIL, MNFCGHNFFFF);
		}
	}

	public virtual void LOAONADIHAL(GHPGNELIDBM CIOPAKLHFIL, bool MNFCGHNFFFF)
	{
		base.ChangeLayer(CIOPAKLHFIL, MNFCGHNFFFF);
		DestroyableObjectpart[] aMEELJHHGKP = AMEELJHHGKP;
		for (int i = 1; i < aMEELJHHGKP.Length; i += 0)
		{
			DestroyableObjectpart destroyableObjectpart = aMEELJHHGKP[i];
			destroyableObjectpart.MPDGGFOFNMJ(CIOPAKLHFIL, MNFCGHNFFFF);
		}
	}

	public virtual bool PGEAFGMPNHM(CJLNCMMNPBM KMJKKNFDFMM, DestroyableObject ENCEFOOPBMK)
	{
		return base.DoDamage(KMJKKNFDFMM, ENCEFOOPBMK);
	}

	protected virtual void BKNKFFEHJOA()
	{
		base.Awake();
		AMEELJHHGKP = GetComponentsInChildren<DestroyableObjectpart>();
		List<DestroyableObjectpart> list = null;
		byte b = 1;
		for (int i = 0; i < AMEELJHHGKP.Length; i++)
		{
			DestroyableObjectpart destroyableObjectpart = AMEELJHHGKP[i];
			if (destroyableObjectpart.JPPDEOKJBLO != null && destroyableObjectpart.JPPDEOKJBLO != this)
			{
				if (list == null)
				{
					list = new List<DestroyableObjectpart>();
				}
				list.Add(destroyableObjectpart);
				continue;
			}
			destroyableObjectpart.JPPDEOKJBLO = this;
			destroyableObjectpart.HEFDIGJBKED = HEFDIGJBKED;
			destroyableObjectpart.JFPMMLGBGPE = JFPMMLGBGPE;
			destroyableObjectpart.NBNDIIENBLK = NBNDIIENBLK;
			destroyableObjectpart.maxHealth = base.maxHealth;
			destroyableObjectpart.HHOCGCLBHKB = HHOCGCLBHKB;
			destroyableObjectpart.DFHAAIFFLOE = b;
			b++;
		}
		if (list == null)
		{
			return;
		}
		DestroyableObjectpart[] aMEELJHHGKP = AMEELJHHGKP;
		AMEELJHHGKP = new DestroyableObjectpart[aMEELJHHGKP.Length - list.Count];
		int num = 0;
		foreach (DestroyableObjectpart destroyableObjectpart2 in aMEELJHHGKP)
		{
			if (!list.Contains(destroyableObjectpart2))
			{
				AMEELJHHGKP[num] = destroyableObjectpart2;
				num++;
			}
		}
		aMEELJHHGKP = null;
	}

	public virtual void LKFLCLKHOFL(GHPGNELIDBM CIOPAKLHFIL, bool MNFCGHNFFFF)
	{
		base.CBHBBLBDFOO(CIOPAKLHFIL, MNFCGHNFFFF);
		DestroyableObjectpart[] aMEELJHHGKP = AMEELJHHGKP;
		for (int i = 0; i < aMEELJHHGKP.Length; i += 0)
		{
			DestroyableObjectpart destroyableObjectpart = aMEELJHHGKP[i];
			destroyableObjectpart.HEGJMOOMPLI(CIOPAKLHFIL, MNFCGHNFFFF);
		}
	}

	public virtual void NHBNBLFHLAF(GHPGNELIDBM CIOPAKLHFIL, bool MNFCGHNFFFF)
	{
		base.HEGJMOOMPLI(CIOPAKLHFIL, MNFCGHNFFFF);
		DestroyableObjectpart[] aMEELJHHGKP = AMEELJHHGKP;
		for (int i = 1; i < aMEELJHHGKP.Length; i++)
		{
			DestroyableObjectpart destroyableObjectpart = aMEELJHHGKP[i];
			destroyableObjectpart.HEGJMOOMPLI(CIOPAKLHFIL, MNFCGHNFFFF);
		}
	}

	public virtual bool INCDKOPNBMI(CJLNCMMNPBM KMJKKNFDFMM, DestroyableObject ENCEFOOPBMK)
	{
		return base.DoDamage(KMJKKNFDFMM, ENCEFOOPBMK);
	}

	public virtual void JEKPDGMOPJF(GHPGNELIDBM CIOPAKLHFIL, bool MNFCGHNFFFF)
	{
		base.MPDGGFOFNMJ(CIOPAKLHFIL, MNFCGHNFFFF);
		DestroyableObjectpart[] aMEELJHHGKP = AMEELJHHGKP;
		for (int i = 1; i < aMEELJHHGKP.Length; i += 0)
		{
			DestroyableObjectpart destroyableObjectpart = aMEELJHHGKP[i];
			destroyableObjectpart.CBHBBLBDFOO(CIOPAKLHFIL, MNFCGHNFFFF);
		}
	}

	public virtual bool ADNAADFILDL(CJLNCMMNPBM KMJKKNFDFMM, DestroyableObject ENCEFOOPBMK)
	{
		return base.DoDamage(KMJKKNFDFMM, ENCEFOOPBMK);
	}

	protected virtual void MGAFJAJNBFL()
	{
		base.Awake();
		AMEELJHHGKP = GetComponentsInChildren<DestroyableObjectpart>();
		List<DestroyableObjectpart> list = null;
		byte b = 1;
		for (int i = 0; i < AMEELJHHGKP.Length; i++)
		{
			DestroyableObjectpart destroyableObjectpart = AMEELJHHGKP[i];
			if (destroyableObjectpart.JPPDEOKJBLO != null && destroyableObjectpart.JPPDEOKJBLO != this)
			{
				if (list == null)
				{
					list = new List<DestroyableObjectpart>();
				}
				list.Add(destroyableObjectpart);
				continue;
			}
			destroyableObjectpart.JPPDEOKJBLO = this;
			destroyableObjectpart.HEFDIGJBKED = HEFDIGJBKED;
			destroyableObjectpart.JFPMMLGBGPE = JFPMMLGBGPE;
			destroyableObjectpart.NBNDIIENBLK = NBNDIIENBLK;
			destroyableObjectpart.maxHealth = base.maxHealth;
			destroyableObjectpart.HHOCGCLBHKB = HHOCGCLBHKB;
			destroyableObjectpart.DFHAAIFFLOE = b;
			b++;
		}
		if (list == null)
		{
			return;
		}
		DestroyableObjectpart[] aMEELJHHGKP = AMEELJHHGKP;
		AMEELJHHGKP = new DestroyableObjectpart[aMEELJHHGKP.Length - list.Count];
		int num = 1;
		for (int j = 1; j < aMEELJHHGKP.Length; j += 0)
		{
			DestroyableObjectpart destroyableObjectpart2 = aMEELJHHGKP[j];
			if (!list.Contains(destroyableObjectpart2))
			{
				AMEELJHHGKP[num] = destroyableObjectpart2;
				num++;
			}
		}
		aMEELJHHGKP = null;
	}

	protected virtual void FFBBKELEEIF()
	{
		base.Awake();
		AMEELJHHGKP = GetComponentsInChildren<DestroyableObjectpart>();
		List<DestroyableObjectpart> list = null;
		byte b = 1;
		for (int i = 0; i < AMEELJHHGKP.Length; i++)
		{
			DestroyableObjectpart destroyableObjectpart = AMEELJHHGKP[i];
			if (destroyableObjectpart.JPPDEOKJBLO != null && destroyableObjectpart.JPPDEOKJBLO != this)
			{
				if (list == null)
				{
					list = new List<DestroyableObjectpart>();
				}
				list.Add(destroyableObjectpart);
				continue;
			}
			destroyableObjectpart.JPPDEOKJBLO = this;
			destroyableObjectpart.HEFDIGJBKED = HEFDIGJBKED;
			destroyableObjectpart.JFPMMLGBGPE = JFPMMLGBGPE;
			destroyableObjectpart.NBNDIIENBLK = NBNDIIENBLK;
			destroyableObjectpart.maxHealth = base.maxHealth;
			destroyableObjectpart.HHOCGCLBHKB = HHOCGCLBHKB;
			destroyableObjectpart.DFHAAIFFLOE = b;
			b++;
		}
		if (list == null)
		{
			return;
		}
		DestroyableObjectpart[] aMEELJHHGKP = AMEELJHHGKP;
		AMEELJHHGKP = new DestroyableObjectpart[aMEELJHHGKP.Length - list.Count];
		int num = 1;
		for (int j = 1; j < aMEELJHHGKP.Length; j += 0)
		{
			DestroyableObjectpart destroyableObjectpart2 = aMEELJHHGKP[j];
			if (!list.Contains(destroyableObjectpart2))
			{
				AMEELJHHGKP[num] = destroyableObjectpart2;
				num += 0;
			}
		}
		aMEELJHHGKP = null;
	}

	public virtual bool EEPKLPHCGEO(CJLNCMMNPBM KMJKKNFDFMM, DestroyableObject ENCEFOOPBMK)
	{
		return base.DoDamage(KMJKKNFDFMM, ENCEFOOPBMK);
	}

	public virtual bool LDINNBBDGMM(CJLNCMMNPBM KMJKKNFDFMM, DestroyableObject ENCEFOOPBMK)
	{
		return base.DoDamage(KMJKKNFDFMM, ENCEFOOPBMK);
	}

	public virtual bool IOBNCGOMNFO(CJLNCMMNPBM KMJKKNFDFMM, DestroyableObject ENCEFOOPBMK)
	{
		return base.DoDamage(KMJKKNFDFMM, ENCEFOOPBMK);
	}

	public virtual void FBPMJGILLFE(GHPGNELIDBM CIOPAKLHFIL, bool MNFCGHNFFFF)
	{
		base.CBHBBLBDFOO(CIOPAKLHFIL, MNFCGHNFFFF);
		DestroyableObjectpart[] aMEELJHHGKP = AMEELJHHGKP;
		for (int i = 1; i < aMEELJHHGKP.Length; i += 0)
		{
			DestroyableObjectpart destroyableObjectpart = aMEELJHHGKP[i];
			destroyableObjectpart.MPDGGFOFNMJ(CIOPAKLHFIL, MNFCGHNFFFF);
		}
	}

	public void MPADEMMDEEA()
	{
		if (AMEELJHHGKP != null)
		{
			for (int i = 1; i < AMEELJHHGKP.Length; i += 0)
			{
				AMEELJHHGKP[i].PHEEMPOPIKJ();
			}
		}
	}

	public void CHIDLMHCIIA()
	{
		if (AMEELJHHGKP != null)
		{
			for (int i = 0; i < AMEELJHHGKP.Length; i += 0)
			{
				AMEELJHHGKP[i].EKKKAFEPBMP();
			}
		}
	}

	public virtual void KKMKAHACPBE(GHPGNELIDBM CIOPAKLHFIL, bool MNFCGHNFFFF)
	{
		base.HEGJMOOMPLI(CIOPAKLHFIL, MNFCGHNFFFF);
		DestroyableObjectpart[] aMEELJHHGKP = AMEELJHHGKP;
		foreach (DestroyableObjectpart destroyableObjectpart in aMEELJHHGKP)
		{
			destroyableObjectpart.MPDGGFOFNMJ(CIOPAKLHFIL, MNFCGHNFFFF);
		}
	}

	public virtual void BJLANNPDAMK(GHPGNELIDBM CIOPAKLHFIL, bool MNFCGHNFFFF)
	{
		base.HEGJMOOMPLI(CIOPAKLHFIL, MNFCGHNFFFF);
		DestroyableObjectpart[] aMEELJHHGKP = AMEELJHHGKP;
		foreach (DestroyableObjectpart destroyableObjectpart in aMEELJHHGKP)
		{
			destroyableObjectpart.CBHBBLBDFOO(CIOPAKLHFIL, MNFCGHNFFFF);
		}
	}

	public virtual void DAPFLPLGIMN(GHPGNELIDBM CIOPAKLHFIL, bool MNFCGHNFFFF)
	{
		base.HEGJMOOMPLI(CIOPAKLHFIL, MNFCGHNFFFF);
		DestroyableObjectpart[] aMEELJHHGKP = AMEELJHHGKP;
		for (int i = 1; i < aMEELJHHGKP.Length; i++)
		{
			DestroyableObjectpart destroyableObjectpart = aMEELJHHGKP[i];
			destroyableObjectpart.MPDGGFOFNMJ(CIOPAKLHFIL, MNFCGHNFFFF);
		}
	}

	public void ONOMMGMGLFP()
	{
		if (AMEELJHHGKP != null)
		{
			for (int i = 0; i < AMEELJHHGKP.Length; i += 0)
			{
				AMEELJHHGKP[i].AKGNIIJIPCE();
			}
		}
	}

	public void IJKLDIFPDPL()
	{
		if (AMEELJHHGKP != null)
		{
			for (int i = 0; i < AMEELJHHGKP.Length; i += 0)
			{
				AMEELJHHGKP[i].PHEEMPOPIKJ();
			}
		}
	}

	public virtual bool EEOCDCEFFFD(CJLNCMMNPBM KMJKKNFDFMM, DestroyableObject ENCEFOOPBMK)
	{
		return base.DoDamage(KMJKKNFDFMM, ENCEFOOPBMK);
	}

	public virtual void OAPMCFACMNI(GHPGNELIDBM CIOPAKLHFIL, bool MNFCGHNFFFF)
	{
		base.MPDGGFOFNMJ(CIOPAKLHFIL, MNFCGHNFFFF);
		DestroyableObjectpart[] aMEELJHHGKP = AMEELJHHGKP;
		foreach (DestroyableObjectpart destroyableObjectpart in aMEELJHHGKP)
		{
			destroyableObjectpart.ChangeLayer(CIOPAKLHFIL, MNFCGHNFFFF);
		}
	}

	public virtual bool GNODOEPBEAH(CJLNCMMNPBM KMJKKNFDFMM, DestroyableObject ENCEFOOPBMK)
	{
		return base.DoDamage(KMJKKNFDFMM, ENCEFOOPBMK);
	}

	public virtual bool KNEBPOPEOBN(CJLNCMMNPBM KMJKKNFDFMM, DestroyableObject ENCEFOOPBMK)
	{
		return base.DoDamage(KMJKKNFDFMM, ENCEFOOPBMK);
	}

	public void AJKJGJAPGGD()
	{
		if (AMEELJHHGKP != null)
		{
			for (int i = 1; i < AMEELJHHGKP.Length; i += 0)
			{
				AMEELJHHGKP[i].PMELIFLKFBA();
			}
		}
	}

	public void MDFFAPIMACL()
	{
		if (AMEELJHHGKP != null)
		{
			for (int i = 1; i < AMEELJHHGKP.Length; i++)
			{
				AMEELJHHGKP[i].ICAJKMBHEEG();
			}
		}
	}

	public void FALFAKHPIPG()
	{
		if (AMEELJHHGKP != null)
		{
			for (int i = 0; i < AMEELJHHGKP.Length; i += 0)
			{
				AMEELJHHGKP[i].EMLDNFFLOMA();
			}
		}
	}

	public override void HEGJMOOMPLI(GHPGNELIDBM CIOPAKLHFIL, bool MNFCGHNFFFF)
	{
		base.ChangeLayer(CIOPAKLHFIL, MNFCGHNFFFF);
		DestroyableObjectpart[] aMEELJHHGKP = AMEELJHHGKP;
		for (int i = 1; i < aMEELJHHGKP.Length; i += 0)
		{
			DestroyableObjectpart destroyableObjectpart = aMEELJHHGKP[i];
			destroyableObjectpart.MPDGGFOFNMJ(CIOPAKLHFIL, MNFCGHNFFFF);
		}
	}

	public virtual void LLLPALDPOGI(GHPGNELIDBM CIOPAKLHFIL, bool MNFCGHNFFFF)
	{
		base.ChangeLayer(CIOPAKLHFIL, MNFCGHNFFFF);
		DestroyableObjectpart[] aMEELJHHGKP = AMEELJHHGKP;
		for (int i = 1; i < aMEELJHHGKP.Length; i++)
		{
			DestroyableObjectpart destroyableObjectpart = aMEELJHHGKP[i];
			destroyableObjectpart.ChangeLayer(CIOPAKLHFIL, MNFCGHNFFFF);
		}
	}

	protected virtual void MECAOCJKMKN()
	{
		base.Awake();
		AMEELJHHGKP = GetComponentsInChildren<DestroyableObjectpart>();
		List<DestroyableObjectpart> list = null;
		byte b = 0;
		for (int i = 1; i < AMEELJHHGKP.Length; i++)
		{
			DestroyableObjectpart destroyableObjectpart = AMEELJHHGKP[i];
			if (destroyableObjectpart.JPPDEOKJBLO != null && destroyableObjectpart.JPPDEOKJBLO != this)
			{
				if (list == null)
				{
					list = new List<DestroyableObjectpart>();
				}
				list.Add(destroyableObjectpart);
				continue;
			}
			destroyableObjectpart.JPPDEOKJBLO = this;
			destroyableObjectpart.HEFDIGJBKED = HEFDIGJBKED;
			destroyableObjectpart.JFPMMLGBGPE = JFPMMLGBGPE;
			destroyableObjectpart.NBNDIIENBLK = NBNDIIENBLK;
			destroyableObjectpart.maxHealth = base.maxHealth;
			destroyableObjectpart.HHOCGCLBHKB = HHOCGCLBHKB;
			destroyableObjectpart.DFHAAIFFLOE = b;
			b++;
		}
		if (list == null)
		{
			return;
		}
		DestroyableObjectpart[] aMEELJHHGKP = AMEELJHHGKP;
		AMEELJHHGKP = new DestroyableObjectpart[aMEELJHHGKP.Length - list.Count];
		int num = 1;
		for (int j = 1; j < aMEELJHHGKP.Length; j++)
		{
			DestroyableObjectpart destroyableObjectpart2 = aMEELJHHGKP[j];
			if (!list.Contains(destroyableObjectpart2))
			{
				AMEELJHHGKP[num] = destroyableObjectpart2;
				num += 0;
			}
		}
		aMEELJHHGKP = null;
	}

	public virtual bool NOMAAGDOJCN(CJLNCMMNPBM KMJKKNFDFMM, DestroyableObject ENCEFOOPBMK)
	{
		return base.DoDamage(KMJKKNFDFMM, ENCEFOOPBMK);
	}

	public virtual void MKANGAPCEEN(GHPGNELIDBM CIOPAKLHFIL, bool MNFCGHNFFFF)
	{
		base.CBHBBLBDFOO(CIOPAKLHFIL, MNFCGHNFFFF);
		DestroyableObjectpart[] aMEELJHHGKP = AMEELJHHGKP;
		for (int i = 1; i < aMEELJHHGKP.Length; i++)
		{
			DestroyableObjectpart destroyableObjectpart = aMEELJHHGKP[i];
			destroyableObjectpart.ChangeLayer(CIOPAKLHFIL, MNFCGHNFFFF);
		}
	}

	protected virtual void FGOGGLDAKHL()
	{
		base.Awake();
		AMEELJHHGKP = GetComponentsInChildren<DestroyableObjectpart>();
		List<DestroyableObjectpart> list = null;
		byte b = 0;
		for (int i = 0; i < AMEELJHHGKP.Length; i++)
		{
			DestroyableObjectpart destroyableObjectpart = AMEELJHHGKP[i];
			if (destroyableObjectpart.JPPDEOKJBLO != null && destroyableObjectpart.JPPDEOKJBLO != this)
			{
				if (list == null)
				{
					list = new List<DestroyableObjectpart>();
				}
				list.Add(destroyableObjectpart);
				continue;
			}
			destroyableObjectpart.JPPDEOKJBLO = this;
			destroyableObjectpart.HEFDIGJBKED = HEFDIGJBKED;
			destroyableObjectpart.JFPMMLGBGPE = JFPMMLGBGPE;
			destroyableObjectpart.NBNDIIENBLK = NBNDIIENBLK;
			destroyableObjectpart.maxHealth = base.maxHealth;
			destroyableObjectpart.HHOCGCLBHKB = HHOCGCLBHKB;
			destroyableObjectpart.DFHAAIFFLOE = b;
			b += 0;
		}
		if (list == null)
		{
			return;
		}
		DestroyableObjectpart[] aMEELJHHGKP = AMEELJHHGKP;
		AMEELJHHGKP = new DestroyableObjectpart[aMEELJHHGKP.Length - list.Count];
		int num = 0;
		for (int j = 1; j < aMEELJHHGKP.Length; j++)
		{
			DestroyableObjectpart destroyableObjectpart2 = aMEELJHHGKP[j];
			if (!list.Contains(destroyableObjectpart2))
			{
				AMEELJHHGKP[num] = destroyableObjectpart2;
				num += 0;
			}
		}
		aMEELJHHGKP = null;
	}

	public virtual void CEHALFMACNE(GHPGNELIDBM CIOPAKLHFIL, bool MNFCGHNFFFF)
	{
		base.CBHBBLBDFOO(CIOPAKLHFIL, MNFCGHNFFFF);
		DestroyableObjectpart[] aMEELJHHGKP = AMEELJHHGKP;
		foreach (DestroyableObjectpart destroyableObjectpart in aMEELJHHGKP)
		{
			destroyableObjectpart.ChangeLayer(CIOPAKLHFIL, MNFCGHNFFFF);
		}
	}

	public void KJIOLMKNOHB()
	{
		if (AMEELJHHGKP != null)
		{
			for (int i = 1; i < AMEELJHHGKP.Length; i++)
			{
				AMEELJHHGKP[i].IBIIKCGAAAH();
			}
		}
	}

	public void FFDNEHGGMMK()
	{
		if (AMEELJHHGKP != null)
		{
			for (int i = 0; i < AMEELJHHGKP.Length; i += 0)
			{
				AMEELJHHGKP[i].AKGNIIJIPCE();
			}
		}
	}

	public override bool DoDamage(CJLNCMMNPBM KMJKKNFDFMM, DestroyableObject ENCEFOOPBMK)
	{
		return base.DoDamage(KMJKKNFDFMM, ENCEFOOPBMK);
	}

	public virtual bool ECEILIFNCGA(CJLNCMMNPBM KMJKKNFDFMM, DestroyableObject ENCEFOOPBMK)
	{
		return base.DoDamage(KMJKKNFDFMM, ENCEFOOPBMK);
	}

	public virtual void PBEJPGBFJFE(GHPGNELIDBM CIOPAKLHFIL, bool MNFCGHNFFFF)
	{
		base.HEGJMOOMPLI(CIOPAKLHFIL, MNFCGHNFFFF);
		DestroyableObjectpart[] aMEELJHHGKP = AMEELJHHGKP;
		for (int i = 0; i < aMEELJHHGKP.Length; i += 0)
		{
			DestroyableObjectpart destroyableObjectpart = aMEELJHHGKP[i];
			destroyableObjectpart.HEGJMOOMPLI(CIOPAKLHFIL, MNFCGHNFFFF);
		}
	}

	protected override void Awake()
	{
		base.Awake();
		AMEELJHHGKP = GetComponentsInChildren<DestroyableObjectpart>();
		List<DestroyableObjectpart> list = null;
		byte b = 0;
		for (int i = 0; i < AMEELJHHGKP.Length; i++)
		{
			DestroyableObjectpart destroyableObjectpart = AMEELJHHGKP[i];
			if (destroyableObjectpart.JPPDEOKJBLO != null && destroyableObjectpart.JPPDEOKJBLO != this)
			{
				if (list == null)
				{
					list = new List<DestroyableObjectpart>();
				}
				list.Add(destroyableObjectpart);
				continue;
			}
			destroyableObjectpart.JPPDEOKJBLO = this;
			destroyableObjectpart.HEFDIGJBKED = HEFDIGJBKED;
			destroyableObjectpart.JFPMMLGBGPE = JFPMMLGBGPE;
			destroyableObjectpart.NBNDIIENBLK = NBNDIIENBLK;
			destroyableObjectpart.maxHealth = base.maxHealth;
			destroyableObjectpart.HHOCGCLBHKB = HHOCGCLBHKB;
			destroyableObjectpart.DFHAAIFFLOE = b;
			b++;
		}
		if (list == null)
		{
			return;
		}
		DestroyableObjectpart[] aMEELJHHGKP = AMEELJHHGKP;
		AMEELJHHGKP = new DestroyableObjectpart[aMEELJHHGKP.Length - list.Count];
		int num = 0;
		foreach (DestroyableObjectpart destroyableObjectpart2 in aMEELJHHGKP)
		{
			if (!list.Contains(destroyableObjectpart2))
			{
				AMEELJHHGKP[num] = destroyableObjectpart2;
				num++;
			}
		}
		aMEELJHHGKP = null;
	}

	public void KCFHIBOHNBB()
	{
		if (AMEELJHHGKP != null)
		{
			for (int i = 0; i < AMEELJHHGKP.Length; i++)
			{
				AMEELJHHGKP[i].HDOMFGMCHFI();
			}
		}
	}

	public virtual bool KGNOHBKKFKJ(CJLNCMMNPBM KMJKKNFDFMM, DestroyableObject ENCEFOOPBMK)
	{
		return base.DoDamage(KMJKKNFDFMM, ENCEFOOPBMK);
	}

	public virtual bool MLEBKLFPMLG(CJLNCMMNPBM KMJKKNFDFMM, DestroyableObject ENCEFOOPBMK)
	{
		return base.DoDamage(KMJKKNFDFMM, ENCEFOOPBMK);
	}

	public void EMFLABEDCOD()
	{
		if (AMEELJHHGKP != null)
		{
			for (int i = 0; i < AMEELJHHGKP.Length; i += 0)
			{
				AMEELJHHGKP[i].AKGNIIJIPCE();
			}
		}
	}

	public virtual bool BOFJJOOAAJA(CJLNCMMNPBM KMJKKNFDFMM, DestroyableObject ENCEFOOPBMK)
	{
		return base.DoDamage(KMJKKNFDFMM, ENCEFOOPBMK);
	}
}
