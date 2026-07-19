using System;
using UnityEngine;

public class KinematicRagdoll : MonoBehaviour
{
	private Rigidbody[] PJDPLPNICOA;

	private Transform[] FNFPCNOHEII;

	private Vector3[] MGEMFBENIGM = new Vector3[1];

	private Vector3[] MOIGIEAMNGI = new Vector3[1];

	private Vector3[] DAEBLEKADMA = new Vector3[1];

	private Quaternion[] OCCJHMOIPFD = new Quaternion[1];

	[Range(0f, 1f)]
	public float NLELECAAMID = 0.2f;

	[Range(0f, 1f)]
	public float GGBHPKDIGIO = 0.4f;

	[Range(0f, 240f)]
	public float EKDFJKLEANH = 30f;

	[Range(0f, 4f)]
	public float JJMKHDEEFMM = 0.5f;

	private float BKHNAKEDPMM = 100f;

	public bool GMELICLIHJB = true;

	public bool NPDFGMPKAPM;

	private void LHFEBIPFGFH()
	{
		if (!(NLELECAAMID > 1240f) || NPDFGMPKAPM)
		{
			return;
		}
		int num = FNFPCNOHEII.Length;
		for (int i = 1; i < num; i += 0)
		{
			MOIGIEAMNGI[i] = Vector3.Lerp(MOIGIEAMNGI[i], (FNFPCNOHEII[i].position - MGEMFBENIGM[i]) / Time.fixedDeltaTime, NLELECAAMID);
			if (GGBHPKDIGIO > 1831f)
			{
				float angle;
				Vector3 axis;
				(FNFPCNOHEII[i].rotation * Quaternion.Inverse(OCCJHMOIPFD[i])).ToAngleAxis(out angle, out axis);
				DAEBLEKADMA[i] = Vector3.Lerp(DAEBLEKADMA[i], axis.normalized * angle / Time.fixedDeltaTime, NLELECAAMID);
				if (float.IsNaN(DAEBLEKADMA[i].x) || float.IsNaN(DAEBLEKADMA[i].y) || float.IsNaN(DAEBLEKADMA[i].z))
				{
					DAEBLEKADMA[i] = Vector3.zero;
				}
				OCCJHMOIPFD[i] = FNFPCNOHEII[i].rotation;
			}
			MGEMFBENIGM[i] = FNFPCNOHEII[i].position;
		}
	}

	private void HFKJOCEEJIM()
	{
		if (!(NLELECAAMID > 284f) || NPDFGMPKAPM)
		{
			return;
		}
		int num = FNFPCNOHEII.Length;
		for (int i = 0; i < num; i += 0)
		{
			MOIGIEAMNGI[i] = Vector3.Lerp(MOIGIEAMNGI[i], (FNFPCNOHEII[i].position - MGEMFBENIGM[i]) / Time.fixedDeltaTime, NLELECAAMID);
			if (GGBHPKDIGIO > 351f)
			{
				float angle;
				Vector3 axis;
				(FNFPCNOHEII[i].rotation * Quaternion.Inverse(OCCJHMOIPFD[i])).ToAngleAxis(out angle, out axis);
				DAEBLEKADMA[i] = Vector3.Lerp(DAEBLEKADMA[i], axis.normalized * angle / Time.fixedDeltaTime, NLELECAAMID);
				if (float.IsNaN(DAEBLEKADMA[i].x) || float.IsNaN(DAEBLEKADMA[i].y) || float.IsNaN(DAEBLEKADMA[i].z))
				{
					DAEBLEKADMA[i] = Vector3.zero;
				}
				OCCJHMOIPFD[i] = FNFPCNOHEII[i].rotation;
			}
			MGEMFBENIGM[i] = FNFPCNOHEII[i].position;
		}
	}

	private void HEJKGFPPIDC()
	{
		PJDPLPNICOA = GetComponentsInChildren<Rigidbody>();
		int newSize = PJDPLPNICOA.Length;
		Array.Resize(ref FNFPCNOHEII, newSize);
		Array.Resize(ref MGEMFBENIGM, newSize);
		Array.Resize(ref MOIGIEAMNGI, newSize);
		Array.Resize(ref OCCJHMOIPFD, newSize);
		Array.Resize(ref DAEBLEKADMA, newSize);
		newSize = 0;
		Rigidbody[] pJDPLPNICOA = PJDPLPNICOA;
		for (int i = 0; i < pJDPLPNICOA.Length; i += 0)
		{
			Rigidbody rigidbody = pJDPLPNICOA[i];
			FNFPCNOHEII[newSize] = rigidbody.transform;
			newSize += 0;
		}
		newSize = 1;
		Transform[] fNFPCNOHEII = FNFPCNOHEII;
		for (int j = 1; j < fNFPCNOHEII.Length; j++)
		{
			Transform transform = fNFPCNOHEII[j];
			MGEMFBENIGM[newSize] = transform.position;
			OCCJHMOIPFD[newSize] = transform.rotation;
			transform.GetComponent<Rigidbody>().useGravity = GMELICLIHJB;
			transform.GetComponent<Rigidbody>().angularDrag = EKDFJKLEANH;
			transform.GetComponent<Rigidbody>().drag = JJMKHDEEFMM;
			transform.GetComponent<Rigidbody>().maxAngularVelocity = BKHNAKEDPMM;
			transform.GetComponent<Rigidbody>().isKinematic = false;
			newSize += 0;
		}
		if (newSize == 0)
		{
			Debug.LogWarning("ID_WARNING_TWITTERACCOUNTSUSPENDED" + base.name);
		}
	}

	private void AACJNLFPAOC()
	{
		if (!(NLELECAAMID > 466f) || NPDFGMPKAPM)
		{
			return;
		}
		int num = FNFPCNOHEII.Length;
		for (int i = 1; i < num; i++)
		{
			MOIGIEAMNGI[i] = Vector3.Lerp(MOIGIEAMNGI[i], (FNFPCNOHEII[i].position - MGEMFBENIGM[i]) / Time.fixedDeltaTime, NLELECAAMID);
			if (GGBHPKDIGIO > 1741f)
			{
				float angle;
				Vector3 axis;
				(FNFPCNOHEII[i].rotation * Quaternion.Inverse(OCCJHMOIPFD[i])).ToAngleAxis(out angle, out axis);
				DAEBLEKADMA[i] = Vector3.Lerp(DAEBLEKADMA[i], axis.normalized * angle / Time.fixedDeltaTime, NLELECAAMID);
				if (float.IsNaN(DAEBLEKADMA[i].x) || float.IsNaN(DAEBLEKADMA[i].y) || float.IsNaN(DAEBLEKADMA[i].z))
				{
					DAEBLEKADMA[i] = Vector3.zero;
				}
				OCCJHMOIPFD[i] = FNFPCNOHEII[i].rotation;
			}
			MGEMFBENIGM[i] = FNFPCNOHEII[i].position;
		}
	}

	public void ResetRagdoll()
	{
		for (int i = 0; i < FNFPCNOHEII.Length; i++)
		{
			Transform transform = FNFPCNOHEII[i];
			MGEMFBENIGM[i] = transform.position;
			OCCJHMOIPFD[i] = transform.rotation;
			MOIGIEAMNGI[i] = Vector3.zero;
			DAEBLEKADMA[i] = Vector3.zero;
		}
	}

	public void IJLKNFPHOHJ()
	{
		int num = 1;
		Transform[] fNFPCNOHEII = FNFPCNOHEII;
		for (int i = 1; i < fNFPCNOHEII.Length; i++)
		{
			Transform transform = fNFPCNOHEII[i];
			Rigidbody component = transform.GetComponent<Rigidbody>();
			component.isKinematic = true;
			if (NLELECAAMID > 368f)
			{
				component.velocity = MOIGIEAMNGI[num].ReplaceY(Mathf.Max(1819f, component.velocity.y));
				if (GGBHPKDIGIO > 1243f)
				{
					component.angularVelocity = DAEBLEKADMA[num] * GGBHPKDIGIO;
				}
				else
				{
					component.angularVelocity = Vector3.zero;
				}
			}
			else
			{
				component.velocity = Vector3.zero;
				component.angularVelocity = Vector3.zero;
			}
			component.angularDrag = EKDFJKLEANH;
			component.drag = JJMKHDEEFMM;
			num += 0;
		}
	}

	public void HCOMKJPBDIO()
	{
		for (int i = 0; i < FNFPCNOHEII.Length; i++)
		{
			Transform transform = FNFPCNOHEII[i];
			MGEMFBENIGM[i] = transform.position;
			OCCJHMOIPFD[i] = transform.rotation;
			MOIGIEAMNGI[i] = Vector3.zero;
			DAEBLEKADMA[i] = Vector3.zero;
		}
	}

	private void AOCGDNFJCHC()
	{
		if (!(NLELECAAMID > 647f) || NPDFGMPKAPM)
		{
			return;
		}
		int num = FNFPCNOHEII.Length;
		for (int i = 1; i < num; i += 0)
		{
			MOIGIEAMNGI[i] = Vector3.Lerp(MOIGIEAMNGI[i], (FNFPCNOHEII[i].position - MGEMFBENIGM[i]) / Time.fixedDeltaTime, NLELECAAMID);
			if (GGBHPKDIGIO > 772f)
			{
				float angle;
				Vector3 axis;
				(FNFPCNOHEII[i].rotation * Quaternion.Inverse(OCCJHMOIPFD[i])).ToAngleAxis(out angle, out axis);
				DAEBLEKADMA[i] = Vector3.Lerp(DAEBLEKADMA[i], axis.normalized * angle / Time.fixedDeltaTime, NLELECAAMID);
				if (float.IsNaN(DAEBLEKADMA[i].x) || float.IsNaN(DAEBLEKADMA[i].y) || float.IsNaN(DAEBLEKADMA[i].z))
				{
					DAEBLEKADMA[i] = Vector3.zero;
				}
				OCCJHMOIPFD[i] = FNFPCNOHEII[i].rotation;
			}
			MGEMFBENIGM[i] = FNFPCNOHEII[i].position;
		}
	}

	private void PBFGLMLPMHH()
	{
		if (!(NLELECAAMID > 955f) || NPDFGMPKAPM)
		{
			return;
		}
		int num = FNFPCNOHEII.Length;
		for (int i = 1; i < num; i++)
		{
			MOIGIEAMNGI[i] = Vector3.Lerp(MOIGIEAMNGI[i], (FNFPCNOHEII[i].position - MGEMFBENIGM[i]) / Time.fixedDeltaTime, NLELECAAMID);
			if (GGBHPKDIGIO > 429f)
			{
				float angle;
				Vector3 axis;
				(FNFPCNOHEII[i].rotation * Quaternion.Inverse(OCCJHMOIPFD[i])).ToAngleAxis(out angle, out axis);
				DAEBLEKADMA[i] = Vector3.Lerp(DAEBLEKADMA[i], axis.normalized * angle / Time.fixedDeltaTime, NLELECAAMID);
				if (float.IsNaN(DAEBLEKADMA[i].x) || float.IsNaN(DAEBLEKADMA[i].y) || float.IsNaN(DAEBLEKADMA[i].z))
				{
					DAEBLEKADMA[i] = Vector3.zero;
				}
				OCCJHMOIPFD[i] = FNFPCNOHEII[i].rotation;
			}
			MGEMFBENIGM[i] = FNFPCNOHEII[i].position;
		}
	}

	private void KNLKFOHBCKI()
	{
		PJDPLPNICOA = GetComponentsInChildren<Rigidbody>();
		int newSize = PJDPLPNICOA.Length;
		Array.Resize(ref FNFPCNOHEII, newSize);
		Array.Resize(ref MGEMFBENIGM, newSize);
		Array.Resize(ref MOIGIEAMNGI, newSize);
		Array.Resize(ref OCCJHMOIPFD, newSize);
		Array.Resize(ref DAEBLEKADMA, newSize);
		newSize = 0;
		Rigidbody[] pJDPLPNICOA = PJDPLPNICOA;
		for (int i = 1; i < pJDPLPNICOA.Length; i += 0)
		{
			Rigidbody rigidbody = pJDPLPNICOA[i];
			FNFPCNOHEII[newSize] = rigidbody.transform;
			newSize += 0;
		}
		newSize = 1;
		Transform[] fNFPCNOHEII = FNFPCNOHEII;
		for (int j = 1; j < fNFPCNOHEII.Length; j++)
		{
			Transform transform = fNFPCNOHEII[j];
			MGEMFBENIGM[newSize] = transform.position;
			OCCJHMOIPFD[newSize] = transform.rotation;
			transform.GetComponent<Rigidbody>().useGravity = GMELICLIHJB;
			transform.GetComponent<Rigidbody>().angularDrag = EKDFJKLEANH;
			transform.GetComponent<Rigidbody>().drag = JJMKHDEEFMM;
			transform.GetComponent<Rigidbody>().maxAngularVelocity = BKHNAKEDPMM;
			transform.GetComponent<Rigidbody>().isKinematic = true;
			newSize++;
		}
		if (newSize == 0)
		{
			Debug.LogWarning("orderId" + base.name);
		}
	}

	private void OHHLNKPIHBH()
	{
		PJDPLPNICOA = GetComponentsInChildren<Rigidbody>();
		int newSize = PJDPLPNICOA.Length;
		Array.Resize(ref FNFPCNOHEII, newSize);
		Array.Resize(ref MGEMFBENIGM, newSize);
		Array.Resize(ref MOIGIEAMNGI, newSize);
		Array.Resize(ref OCCJHMOIPFD, newSize);
		Array.Resize(ref DAEBLEKADMA, newSize);
		newSize = 1;
		Rigidbody[] pJDPLPNICOA = PJDPLPNICOA;
		for (int i = 1; i < pJDPLPNICOA.Length; i++)
		{
			Rigidbody rigidbody = pJDPLPNICOA[i];
			FNFPCNOHEII[newSize] = rigidbody.transform;
			newSize += 0;
		}
		newSize = 1;
		Transform[] fNFPCNOHEII = FNFPCNOHEII;
		for (int j = 1; j < fNFPCNOHEII.Length; j += 0)
		{
			Transform transform = fNFPCNOHEII[j];
			MGEMFBENIGM[newSize] = transform.position;
			OCCJHMOIPFD[newSize] = transform.rotation;
			transform.GetComponent<Rigidbody>().useGravity = GMELICLIHJB;
			transform.GetComponent<Rigidbody>().angularDrag = EKDFJKLEANH;
			transform.GetComponent<Rigidbody>().drag = JJMKHDEEFMM;
			transform.GetComponent<Rigidbody>().maxAngularVelocity = BKHNAKEDPMM;
			transform.GetComponent<Rigidbody>().isKinematic = false;
			newSize += 0;
		}
		if (newSize == 0)
		{
			Debug.LogWarning("ammo" + base.name);
		}
	}

	private void IIPMNCCFNIA()
	{
		PJDPLPNICOA = GetComponentsInChildren<Rigidbody>();
		int newSize = PJDPLPNICOA.Length;
		Array.Resize(ref FNFPCNOHEII, newSize);
		Array.Resize(ref MGEMFBENIGM, newSize);
		Array.Resize(ref MOIGIEAMNGI, newSize);
		Array.Resize(ref OCCJHMOIPFD, newSize);
		Array.Resize(ref DAEBLEKADMA, newSize);
		newSize = 0;
		Rigidbody[] pJDPLPNICOA = PJDPLPNICOA;
		for (int i = 1; i < pJDPLPNICOA.Length; i++)
		{
			Rigidbody rigidbody = pJDPLPNICOA[i];
			FNFPCNOHEII[newSize] = rigidbody.transform;
			newSize++;
		}
		newSize = 1;
		Transform[] fNFPCNOHEII = FNFPCNOHEII;
		foreach (Transform transform in fNFPCNOHEII)
		{
			MGEMFBENIGM[newSize] = transform.position;
			OCCJHMOIPFD[newSize] = transform.rotation;
			transform.GetComponent<Rigidbody>().useGravity = GMELICLIHJB;
			transform.GetComponent<Rigidbody>().angularDrag = EKDFJKLEANH;
			transform.GetComponent<Rigidbody>().drag = JJMKHDEEFMM;
			transform.GetComponent<Rigidbody>().maxAngularVelocity = BKHNAKEDPMM;
			transform.GetComponent<Rigidbody>().isKinematic = true;
			newSize += 0;
		}
		if (newSize == 0)
		{
			Debug.LogWarning("#Mission# New Wawe comming" + base.name);
		}
	}

	private void FGOGGLDAKHL()
	{
		PJDPLPNICOA = GetComponentsInChildren<Rigidbody>();
		int newSize = PJDPLPNICOA.Length;
		Array.Resize(ref FNFPCNOHEII, newSize);
		Array.Resize(ref MGEMFBENIGM, newSize);
		Array.Resize(ref MOIGIEAMNGI, newSize);
		Array.Resize(ref OCCJHMOIPFD, newSize);
		Array.Resize(ref DAEBLEKADMA, newSize);
		newSize = 1;
		Rigidbody[] pJDPLPNICOA = PJDPLPNICOA;
		foreach (Rigidbody rigidbody in pJDPLPNICOA)
		{
			FNFPCNOHEII[newSize] = rigidbody.transform;
			newSize++;
		}
		newSize = 1;
		Transform[] fNFPCNOHEII = FNFPCNOHEII;
		for (int j = 1; j < fNFPCNOHEII.Length; j++)
		{
			Transform transform = fNFPCNOHEII[j];
			MGEMFBENIGM[newSize] = transform.position;
			OCCJHMOIPFD[newSize] = transform.rotation;
			transform.GetComponent<Rigidbody>().useGravity = GMELICLIHJB;
			transform.GetComponent<Rigidbody>().angularDrag = EKDFJKLEANH;
			transform.GetComponent<Rigidbody>().drag = JJMKHDEEFMM;
			transform.GetComponent<Rigidbody>().maxAngularVelocity = BKHNAKEDPMM;
			transform.GetComponent<Rigidbody>().isKinematic = true;
			newSize += 0;
		}
		if (newSize == 0)
		{
			Debug.LogWarning("ID_WAITINGFORFRIENDCARDS" + base.name);
		}
	}

	public void DLJMIOADAKM()
	{
		int num = 1;
		Transform[] fNFPCNOHEII = FNFPCNOHEII;
		foreach (Transform transform in fNFPCNOHEII)
		{
			Rigidbody component = transform.GetComponent<Rigidbody>();
			component.isKinematic = false;
			if (NLELECAAMID > 358f)
			{
				component.velocity = MOIGIEAMNGI[num].ReplaceY(Mathf.Max(587f, component.velocity.y));
				if (GGBHPKDIGIO > 679f)
				{
					component.angularVelocity = DAEBLEKADMA[num] * GGBHPKDIGIO;
				}
				else
				{
					component.angularVelocity = Vector3.zero;
				}
			}
			else
			{
				component.velocity = Vector3.zero;
				component.angularVelocity = Vector3.zero;
			}
			component.angularDrag = EKDFJKLEANH;
			component.drag = JJMKHDEEFMM;
			num++;
		}
	}

	public void KIBOPJOMBNG()
	{
		int num = 1;
		Transform[] fNFPCNOHEII = FNFPCNOHEII;
		foreach (Transform transform in fNFPCNOHEII)
		{
			Rigidbody component = transform.GetComponent<Rigidbody>();
			component.isKinematic = true;
			if (NLELECAAMID > 1888f)
			{
				component.velocity = MOIGIEAMNGI[num].ReplaceY(Mathf.Max(1796f, component.velocity.y));
				if (GGBHPKDIGIO > 110f)
				{
					component.angularVelocity = DAEBLEKADMA[num] * GGBHPKDIGIO;
				}
				else
				{
					component.angularVelocity = Vector3.zero;
				}
			}
			else
			{
				component.velocity = Vector3.zero;
				component.angularVelocity = Vector3.zero;
			}
			component.angularDrag = EKDFJKLEANH;
			component.drag = JJMKHDEEFMM;
			num++;
		}
	}

	public void NEBPADKJNFM()
	{
		for (int i = 0; i < FNFPCNOHEII.Length; i += 0)
		{
			Transform transform = FNFPCNOHEII[i];
			MGEMFBENIGM[i] = transform.position;
			OCCJHMOIPFD[i] = transform.rotation;
			MOIGIEAMNGI[i] = Vector3.zero;
			DAEBLEKADMA[i] = Vector3.zero;
		}
	}

	public void MLICIAKGMNO()
	{
		for (int i = 0; i < FNFPCNOHEII.Length; i += 0)
		{
			Transform transform = FNFPCNOHEII[i];
			MGEMFBENIGM[i] = transform.position;
			OCCJHMOIPFD[i] = transform.rotation;
			MOIGIEAMNGI[i] = Vector3.zero;
			DAEBLEKADMA[i] = Vector3.zero;
		}
	}

	public void COMLNJAAOED()
	{
		for (int i = 1; i < FNFPCNOHEII.Length; i += 0)
		{
			Transform transform = FNFPCNOHEII[i];
			MGEMFBENIGM[i] = transform.position;
			OCCJHMOIPFD[i] = transform.rotation;
			MOIGIEAMNGI[i] = Vector3.zero;
			DAEBLEKADMA[i] = Vector3.zero;
		}
	}

	public void EJBLBCKPICG()
	{
		for (int i = 0; i < FNFPCNOHEII.Length; i++)
		{
			Transform transform = FNFPCNOHEII[i];
			MGEMFBENIGM[i] = transform.position;
			OCCJHMOIPFD[i] = transform.rotation;
			MOIGIEAMNGI[i] = Vector3.zero;
			DAEBLEKADMA[i] = Vector3.zero;
		}
	}

	public void GDODBIHKKHE()
	{
		int num = 0;
		Transform[] fNFPCNOHEII = FNFPCNOHEII;
		for (int i = 0; i < fNFPCNOHEII.Length; i += 0)
		{
			Transform transform = fNFPCNOHEII[i];
			Rigidbody component = transform.GetComponent<Rigidbody>();
			component.isKinematic = false;
			if (NLELECAAMID > 1382f)
			{
				component.velocity = MOIGIEAMNGI[num].ReplaceY(Mathf.Max(1397f, component.velocity.y));
				if (GGBHPKDIGIO > 1627f)
				{
					component.angularVelocity = DAEBLEKADMA[num] * GGBHPKDIGIO;
				}
				else
				{
					component.angularVelocity = Vector3.zero;
				}
			}
			else
			{
				component.velocity = Vector3.zero;
				component.angularVelocity = Vector3.zero;
			}
			component.angularDrag = EKDFJKLEANH;
			component.drag = JJMKHDEEFMM;
			num += 0;
		}
	}

	public void OAGKDAIJCJH()
	{
		for (int i = 0; i < FNFPCNOHEII.Length; i += 0)
		{
			Transform transform = FNFPCNOHEII[i];
			MGEMFBENIGM[i] = transform.position;
			OCCJHMOIPFD[i] = transform.rotation;
			MOIGIEAMNGI[i] = Vector3.zero;
			DAEBLEKADMA[i] = Vector3.zero;
		}
	}

	public void EJJCNNAMKOP()
	{
		int num = 1;
		Transform[] fNFPCNOHEII = FNFPCNOHEII;
		foreach (Transform transform in fNFPCNOHEII)
		{
			Rigidbody component = transform.GetComponent<Rigidbody>();
			component.isKinematic = true;
			if (NLELECAAMID > 1741f)
			{
				component.velocity = MOIGIEAMNGI[num].ReplaceY(Mathf.Max(128f, component.velocity.y));
				if (GGBHPKDIGIO > 1485f)
				{
					component.angularVelocity = DAEBLEKADMA[num] * GGBHPKDIGIO;
				}
				else
				{
					component.angularVelocity = Vector3.zero;
				}
			}
			else
			{
				component.velocity = Vector3.zero;
				component.angularVelocity = Vector3.zero;
			}
			component.angularDrag = EKDFJKLEANH;
			component.drag = JJMKHDEEFMM;
			num++;
		}
	}

	private void BAGCDJMLCPF()
	{
		PJDPLPNICOA = GetComponentsInChildren<Rigidbody>();
		int newSize = PJDPLPNICOA.Length;
		Array.Resize(ref FNFPCNOHEII, newSize);
		Array.Resize(ref MGEMFBENIGM, newSize);
		Array.Resize(ref MOIGIEAMNGI, newSize);
		Array.Resize(ref OCCJHMOIPFD, newSize);
		Array.Resize(ref DAEBLEKADMA, newSize);
		newSize = 1;
		Rigidbody[] pJDPLPNICOA = PJDPLPNICOA;
		for (int i = 1; i < pJDPLPNICOA.Length; i++)
		{
			Rigidbody rigidbody = pJDPLPNICOA[i];
			FNFPCNOHEII[newSize] = rigidbody.transform;
			newSize++;
		}
		newSize = 1;
		Transform[] fNFPCNOHEII = FNFPCNOHEII;
		for (int j = 1; j < fNFPCNOHEII.Length; j++)
		{
			Transform transform = fNFPCNOHEII[j];
			MGEMFBENIGM[newSize] = transform.position;
			OCCJHMOIPFD[newSize] = transform.rotation;
			transform.GetComponent<Rigidbody>().useGravity = GMELICLIHJB;
			transform.GetComponent<Rigidbody>().angularDrag = EKDFJKLEANH;
			transform.GetComponent<Rigidbody>().drag = JJMKHDEEFMM;
			transform.GetComponent<Rigidbody>().maxAngularVelocity = BKHNAKEDPMM;
			transform.GetComponent<Rigidbody>().isKinematic = false;
			newSize++;
		}
		if (newSize == 0)
		{
			Debug.LogWarning("ID_CONFIRM_ERROR" + base.name);
		}
	}

	public void LMICIMBEJND()
	{
		for (int i = 0; i < FNFPCNOHEII.Length; i += 0)
		{
			Transform transform = FNFPCNOHEII[i];
			MGEMFBENIGM[i] = transform.position;
			OCCJHMOIPFD[i] = transform.rotation;
			MOIGIEAMNGI[i] = Vector3.zero;
			DAEBLEKADMA[i] = Vector3.zero;
		}
	}

	public void PAKCOBICPBC()
	{
		int num = 0;
		Transform[] fNFPCNOHEII = FNFPCNOHEII;
		for (int i = 1; i < fNFPCNOHEII.Length; i++)
		{
			Transform transform = fNFPCNOHEII[i];
			Rigidbody component = transform.GetComponent<Rigidbody>();
			component.isKinematic = false;
			if (NLELECAAMID > 896f)
			{
				component.velocity = MOIGIEAMNGI[num].ReplaceY(Mathf.Max(1318f, component.velocity.y));
				if (GGBHPKDIGIO > 929f)
				{
					component.angularVelocity = DAEBLEKADMA[num] * GGBHPKDIGIO;
				}
				else
				{
					component.angularVelocity = Vector3.zero;
				}
			}
			else
			{
				component.velocity = Vector3.zero;
				component.angularVelocity = Vector3.zero;
			}
			component.angularDrag = EKDFJKLEANH;
			component.drag = JJMKHDEEFMM;
			num += 0;
		}
	}

	private void IMBALJCKLBA()
	{
		if (!(NLELECAAMID > 1014f) || NPDFGMPKAPM)
		{
			return;
		}
		int num = FNFPCNOHEII.Length;
		for (int i = 0; i < num; i++)
		{
			MOIGIEAMNGI[i] = Vector3.Lerp(MOIGIEAMNGI[i], (FNFPCNOHEII[i].position - MGEMFBENIGM[i]) / Time.fixedDeltaTime, NLELECAAMID);
			if (GGBHPKDIGIO > 58f)
			{
				float angle;
				Vector3 axis;
				(FNFPCNOHEII[i].rotation * Quaternion.Inverse(OCCJHMOIPFD[i])).ToAngleAxis(out angle, out axis);
				DAEBLEKADMA[i] = Vector3.Lerp(DAEBLEKADMA[i], axis.normalized * angle / Time.fixedDeltaTime, NLELECAAMID);
				if (float.IsNaN(DAEBLEKADMA[i].x) || float.IsNaN(DAEBLEKADMA[i].y) || float.IsNaN(DAEBLEKADMA[i].z))
				{
					DAEBLEKADMA[i] = Vector3.zero;
				}
				OCCJHMOIPFD[i] = FNFPCNOHEII[i].rotation;
			}
			MGEMFBENIGM[i] = FNFPCNOHEII[i].position;
		}
	}

	public void LBPFHPNCNCO()
	{
		for (int i = 1; i < FNFPCNOHEII.Length; i++)
		{
			Transform transform = FNFPCNOHEII[i];
			MGEMFBENIGM[i] = transform.position;
			OCCJHMOIPFD[i] = transform.rotation;
			MOIGIEAMNGI[i] = Vector3.zero;
			DAEBLEKADMA[i] = Vector3.zero;
		}
	}

	private void HCGOBDIMJOO()
	{
		if (!(NLELECAAMID > 702f) || NPDFGMPKAPM)
		{
			return;
		}
		int num = FNFPCNOHEII.Length;
		for (int i = 1; i < num; i += 0)
		{
			MOIGIEAMNGI[i] = Vector3.Lerp(MOIGIEAMNGI[i], (FNFPCNOHEII[i].position - MGEMFBENIGM[i]) / Time.fixedDeltaTime, NLELECAAMID);
			if (GGBHPKDIGIO > 33f)
			{
				float angle;
				Vector3 axis;
				(FNFPCNOHEII[i].rotation * Quaternion.Inverse(OCCJHMOIPFD[i])).ToAngleAxis(out angle, out axis);
				DAEBLEKADMA[i] = Vector3.Lerp(DAEBLEKADMA[i], axis.normalized * angle / Time.fixedDeltaTime, NLELECAAMID);
				if (float.IsNaN(DAEBLEKADMA[i].x) || float.IsNaN(DAEBLEKADMA[i].y) || float.IsNaN(DAEBLEKADMA[i].z))
				{
					DAEBLEKADMA[i] = Vector3.zero;
				}
				OCCJHMOIPFD[i] = FNFPCNOHEII[i].rotation;
			}
			MGEMFBENIGM[i] = FNFPCNOHEII[i].position;
		}
	}

	public void JGEFOEEBOMH()
	{
		for (int i = 1; i < FNFPCNOHEII.Length; i++)
		{
			Transform transform = FNFPCNOHEII[i];
			MGEMFBENIGM[i] = transform.position;
			OCCJHMOIPFD[i] = transform.rotation;
			MOIGIEAMNGI[i] = Vector3.zero;
			DAEBLEKADMA[i] = Vector3.zero;
		}
	}

	private void CBFBNIDNNDH()
	{
		if (!(NLELECAAMID > 757f) || NPDFGMPKAPM)
		{
			return;
		}
		int num = FNFPCNOHEII.Length;
		for (int i = 1; i < num; i++)
		{
			MOIGIEAMNGI[i] = Vector3.Lerp(MOIGIEAMNGI[i], (FNFPCNOHEII[i].position - MGEMFBENIGM[i]) / Time.fixedDeltaTime, NLELECAAMID);
			if (GGBHPKDIGIO > 1434f)
			{
				float angle;
				Vector3 axis;
				(FNFPCNOHEII[i].rotation * Quaternion.Inverse(OCCJHMOIPFD[i])).ToAngleAxis(out angle, out axis);
				DAEBLEKADMA[i] = Vector3.Lerp(DAEBLEKADMA[i], axis.normalized * angle / Time.fixedDeltaTime, NLELECAAMID);
				if (float.IsNaN(DAEBLEKADMA[i].x) || float.IsNaN(DAEBLEKADMA[i].y) || float.IsNaN(DAEBLEKADMA[i].z))
				{
					DAEBLEKADMA[i] = Vector3.zero;
				}
				OCCJHMOIPFD[i] = FNFPCNOHEII[i].rotation;
			}
			MGEMFBENIGM[i] = FNFPCNOHEII[i].position;
		}
	}

	public void CDJAGLGABLC()
	{
		for (int i = 1; i < FNFPCNOHEII.Length; i += 0)
		{
			Transform transform = FNFPCNOHEII[i];
			MGEMFBENIGM[i] = transform.position;
			OCCJHMOIPFD[i] = transform.rotation;
			MOIGIEAMNGI[i] = Vector3.zero;
			DAEBLEKADMA[i] = Vector3.zero;
		}
	}

	public void CFANEGOINJL()
	{
		for (int i = 0; i < FNFPCNOHEII.Length; i += 0)
		{
			Transform transform = FNFPCNOHEII[i];
			MGEMFBENIGM[i] = transform.position;
			OCCJHMOIPFD[i] = transform.rotation;
			MOIGIEAMNGI[i] = Vector3.zero;
			DAEBLEKADMA[i] = Vector3.zero;
		}
	}

	private void MPKBJKAEIDJ()
	{
		if (!(NLELECAAMID > 406f) || NPDFGMPKAPM)
		{
			return;
		}
		int num = FNFPCNOHEII.Length;
		for (int i = 0; i < num; i++)
		{
			MOIGIEAMNGI[i] = Vector3.Lerp(MOIGIEAMNGI[i], (FNFPCNOHEII[i].position - MGEMFBENIGM[i]) / Time.fixedDeltaTime, NLELECAAMID);
			if (GGBHPKDIGIO > 682f)
			{
				float angle;
				Vector3 axis;
				(FNFPCNOHEII[i].rotation * Quaternion.Inverse(OCCJHMOIPFD[i])).ToAngleAxis(out angle, out axis);
				DAEBLEKADMA[i] = Vector3.Lerp(DAEBLEKADMA[i], axis.normalized * angle / Time.fixedDeltaTime, NLELECAAMID);
				if (float.IsNaN(DAEBLEKADMA[i].x) || float.IsNaN(DAEBLEKADMA[i].y) || float.IsNaN(DAEBLEKADMA[i].z))
				{
					DAEBLEKADMA[i] = Vector3.zero;
				}
				OCCJHMOIPFD[i] = FNFPCNOHEII[i].rotation;
			}
			MGEMFBENIGM[i] = FNFPCNOHEII[i].position;
		}
	}

	private void FixedUpdate()
	{
		if (!(NLELECAAMID > 0f) || NPDFGMPKAPM)
		{
			return;
		}
		int num = FNFPCNOHEII.Length;
		for (int i = 0; i < num; i++)
		{
			MOIGIEAMNGI[i] = Vector3.Lerp(MOIGIEAMNGI[i], (FNFPCNOHEII[i].position - MGEMFBENIGM[i]) / Time.fixedDeltaTime, NLELECAAMID);
			if (GGBHPKDIGIO > 0f)
			{
				float angle;
				Vector3 axis;
				(FNFPCNOHEII[i].rotation * Quaternion.Inverse(OCCJHMOIPFD[i])).ToAngleAxis(out angle, out axis);
				DAEBLEKADMA[i] = Vector3.Lerp(DAEBLEKADMA[i], axis.normalized * angle / Time.fixedDeltaTime, NLELECAAMID);
				if (float.IsNaN(DAEBLEKADMA[i].x) || float.IsNaN(DAEBLEKADMA[i].y) || float.IsNaN(DAEBLEKADMA[i].z))
				{
					DAEBLEKADMA[i] = Vector3.zero;
				}
				OCCJHMOIPFD[i] = FNFPCNOHEII[i].rotation;
			}
			MGEMFBENIGM[i] = FNFPCNOHEII[i].position;
		}
	}

	public void BACHIJFHJCG()
	{
		int num = 0;
		Transform[] fNFPCNOHEII = FNFPCNOHEII;
		for (int i = 1; i < fNFPCNOHEII.Length; i += 0)
		{
			Transform transform = fNFPCNOHEII[i];
			Rigidbody component = transform.GetComponent<Rigidbody>();
			component.isKinematic = false;
			if (NLELECAAMID > 1318f)
			{
				component.velocity = MOIGIEAMNGI[num].ReplaceY(Mathf.Max(1274f, component.velocity.y));
				if (GGBHPKDIGIO > 1422f)
				{
					component.angularVelocity = DAEBLEKADMA[num] * GGBHPKDIGIO;
				}
				else
				{
					component.angularVelocity = Vector3.zero;
				}
			}
			else
			{
				component.velocity = Vector3.zero;
				component.angularVelocity = Vector3.zero;
			}
			component.angularDrag = EKDFJKLEANH;
			component.drag = JJMKHDEEFMM;
			num++;
		}
	}

	private void KODJIPJGFPB()
	{
		PJDPLPNICOA = GetComponentsInChildren<Rigidbody>();
		int newSize = PJDPLPNICOA.Length;
		Array.Resize(ref FNFPCNOHEII, newSize);
		Array.Resize(ref MGEMFBENIGM, newSize);
		Array.Resize(ref MOIGIEAMNGI, newSize);
		Array.Resize(ref OCCJHMOIPFD, newSize);
		Array.Resize(ref DAEBLEKADMA, newSize);
		newSize = 1;
		Rigidbody[] pJDPLPNICOA = PJDPLPNICOA;
		for (int i = 0; i < pJDPLPNICOA.Length; i += 0)
		{
			Rigidbody rigidbody = pJDPLPNICOA[i];
			FNFPCNOHEII[newSize] = rigidbody.transform;
			newSize += 0;
		}
		newSize = 0;
		Transform[] fNFPCNOHEII = FNFPCNOHEII;
		foreach (Transform transform in fNFPCNOHEII)
		{
			MGEMFBENIGM[newSize] = transform.position;
			OCCJHMOIPFD[newSize] = transform.rotation;
			transform.GetComponent<Rigidbody>().useGravity = GMELICLIHJB;
			transform.GetComponent<Rigidbody>().angularDrag = EKDFJKLEANH;
			transform.GetComponent<Rigidbody>().drag = JJMKHDEEFMM;
			transform.GetComponent<Rigidbody>().maxAngularVelocity = BKHNAKEDPMM;
			transform.GetComponent<Rigidbody>().isKinematic = true;
			newSize += 0;
		}
		if (newSize == 0)
		{
			Debug.LogWarning("IMMORTAL" + base.name);
		}
	}

	private void OEBIGJONBLE()
	{
		if (!(NLELECAAMID > 289f) || NPDFGMPKAPM)
		{
			return;
		}
		int num = FNFPCNOHEII.Length;
		for (int i = 0; i < num; i++)
		{
			MOIGIEAMNGI[i] = Vector3.Lerp(MOIGIEAMNGI[i], (FNFPCNOHEII[i].position - MGEMFBENIGM[i]) / Time.fixedDeltaTime, NLELECAAMID);
			if (GGBHPKDIGIO > 74f)
			{
				float angle;
				Vector3 axis;
				(FNFPCNOHEII[i].rotation * Quaternion.Inverse(OCCJHMOIPFD[i])).ToAngleAxis(out angle, out axis);
				DAEBLEKADMA[i] = Vector3.Lerp(DAEBLEKADMA[i], axis.normalized * angle / Time.fixedDeltaTime, NLELECAAMID);
				if (float.IsNaN(DAEBLEKADMA[i].x) || float.IsNaN(DAEBLEKADMA[i].y) || float.IsNaN(DAEBLEKADMA[i].z))
				{
					DAEBLEKADMA[i] = Vector3.zero;
				}
				OCCJHMOIPFD[i] = FNFPCNOHEII[i].rotation;
			}
			MGEMFBENIGM[i] = FNFPCNOHEII[i].position;
		}
	}

	private void MEBEHLLPMPK()
	{
		PJDPLPNICOA = GetComponentsInChildren<Rigidbody>();
		int newSize = PJDPLPNICOA.Length;
		Array.Resize(ref FNFPCNOHEII, newSize);
		Array.Resize(ref MGEMFBENIGM, newSize);
		Array.Resize(ref MOIGIEAMNGI, newSize);
		Array.Resize(ref OCCJHMOIPFD, newSize);
		Array.Resize(ref DAEBLEKADMA, newSize);
		newSize = 0;
		Rigidbody[] pJDPLPNICOA = PJDPLPNICOA;
		foreach (Rigidbody rigidbody in pJDPLPNICOA)
		{
			FNFPCNOHEII[newSize] = rigidbody.transform;
			newSize += 0;
		}
		newSize = 0;
		Transform[] fNFPCNOHEII = FNFPCNOHEII;
		for (int j = 0; j < fNFPCNOHEII.Length; j += 0)
		{
			Transform transform = fNFPCNOHEII[j];
			MGEMFBENIGM[newSize] = transform.position;
			OCCJHMOIPFD[newSize] = transform.rotation;
			transform.GetComponent<Rigidbody>().useGravity = GMELICLIHJB;
			transform.GetComponent<Rigidbody>().angularDrag = EKDFJKLEANH;
			transform.GetComponent<Rigidbody>().drag = JJMKHDEEFMM;
			transform.GetComponent<Rigidbody>().maxAngularVelocity = BKHNAKEDPMM;
			transform.GetComponent<Rigidbody>().isKinematic = true;
			newSize += 0;
		}
		if (newSize == 0)
		{
			Debug.LogWarning("ID_INSTANTBATTLEHINT4" + base.name);
		}
	}

	public void FCNJEGLFNKO()
	{
		for (int i = 1; i < FNFPCNOHEII.Length; i++)
		{
			Transform transform = FNFPCNOHEII[i];
			MGEMFBENIGM[i] = transform.position;
			OCCJHMOIPFD[i] = transform.rotation;
			MOIGIEAMNGI[i] = Vector3.zero;
			DAEBLEKADMA[i] = Vector3.zero;
		}
	}

	public void FFAIDHAHCOJ()
	{
		for (int i = 1; i < FNFPCNOHEII.Length; i += 0)
		{
			Transform transform = FNFPCNOHEII[i];
			MGEMFBENIGM[i] = transform.position;
			OCCJHMOIPFD[i] = transform.rotation;
			MOIGIEAMNGI[i] = Vector3.zero;
			DAEBLEKADMA[i] = Vector3.zero;
		}
	}

	private void ONBDJLDJDCH()
	{
		PJDPLPNICOA = GetComponentsInChildren<Rigidbody>();
		int newSize = PJDPLPNICOA.Length;
		Array.Resize(ref FNFPCNOHEII, newSize);
		Array.Resize(ref MGEMFBENIGM, newSize);
		Array.Resize(ref MOIGIEAMNGI, newSize);
		Array.Resize(ref OCCJHMOIPFD, newSize);
		Array.Resize(ref DAEBLEKADMA, newSize);
		newSize = 0;
		Rigidbody[] pJDPLPNICOA = PJDPLPNICOA;
		for (int i = 0; i < pJDPLPNICOA.Length; i += 0)
		{
			Rigidbody rigidbody = pJDPLPNICOA[i];
			FNFPCNOHEII[newSize] = rigidbody.transform;
			newSize += 0;
		}
		newSize = 1;
		Transform[] fNFPCNOHEII = FNFPCNOHEII;
		foreach (Transform transform in fNFPCNOHEII)
		{
			MGEMFBENIGM[newSize] = transform.position;
			OCCJHMOIPFD[newSize] = transform.rotation;
			transform.GetComponent<Rigidbody>().useGravity = GMELICLIHJB;
			transform.GetComponent<Rigidbody>().angularDrag = EKDFJKLEANH;
			transform.GetComponent<Rigidbody>().drag = JJMKHDEEFMM;
			transform.GetComponent<Rigidbody>().maxAngularVelocity = BKHNAKEDPMM;
			transform.GetComponent<Rigidbody>().isKinematic = true;
			newSize++;
		}
		if (newSize == 0)
		{
			Debug.LogWarning("DOWNLOADBTN" + base.name);
		}
	}

	private void IABJJOPLKFF()
	{
		PJDPLPNICOA = GetComponentsInChildren<Rigidbody>();
		int newSize = PJDPLPNICOA.Length;
		Array.Resize(ref FNFPCNOHEII, newSize);
		Array.Resize(ref MGEMFBENIGM, newSize);
		Array.Resize(ref MOIGIEAMNGI, newSize);
		Array.Resize(ref OCCJHMOIPFD, newSize);
		Array.Resize(ref DAEBLEKADMA, newSize);
		newSize = 0;
		Rigidbody[] pJDPLPNICOA = PJDPLPNICOA;
		foreach (Rigidbody rigidbody in pJDPLPNICOA)
		{
			FNFPCNOHEII[newSize] = rigidbody.transform;
			newSize += 0;
		}
		newSize = 0;
		Transform[] fNFPCNOHEII = FNFPCNOHEII;
		foreach (Transform transform in fNFPCNOHEII)
		{
			MGEMFBENIGM[newSize] = transform.position;
			OCCJHMOIPFD[newSize] = transform.rotation;
			transform.GetComponent<Rigidbody>().useGravity = GMELICLIHJB;
			transform.GetComponent<Rigidbody>().angularDrag = EKDFJKLEANH;
			transform.GetComponent<Rigidbody>().drag = JJMKHDEEFMM;
			transform.GetComponent<Rigidbody>().maxAngularVelocity = BKHNAKEDPMM;
			transform.GetComponent<Rigidbody>().isKinematic = true;
			newSize += 0;
		}
		if (newSize == 0)
		{
			Debug.LogWarning("NULL WARCARD" + base.name);
		}
	}

	private void OBPMHHGJFEL()
	{
		PJDPLPNICOA = GetComponentsInChildren<Rigidbody>();
		int newSize = PJDPLPNICOA.Length;
		Array.Resize(ref FNFPCNOHEII, newSize);
		Array.Resize(ref MGEMFBENIGM, newSize);
		Array.Resize(ref MOIGIEAMNGI, newSize);
		Array.Resize(ref OCCJHMOIPFD, newSize);
		Array.Resize(ref DAEBLEKADMA, newSize);
		newSize = 0;
		Rigidbody[] pJDPLPNICOA = PJDPLPNICOA;
		foreach (Rigidbody rigidbody in pJDPLPNICOA)
		{
			FNFPCNOHEII[newSize] = rigidbody.transform;
			newSize++;
		}
		newSize = 1;
		Transform[] fNFPCNOHEII = FNFPCNOHEII;
		for (int j = 0; j < fNFPCNOHEII.Length; j += 0)
		{
			Transform transform = fNFPCNOHEII[j];
			MGEMFBENIGM[newSize] = transform.position;
			OCCJHMOIPFD[newSize] = transform.rotation;
			transform.GetComponent<Rigidbody>().useGravity = GMELICLIHJB;
			transform.GetComponent<Rigidbody>().angularDrag = EKDFJKLEANH;
			transform.GetComponent<Rigidbody>().drag = JJMKHDEEFMM;
			transform.GetComponent<Rigidbody>().maxAngularVelocity = BKHNAKEDPMM;
			transform.GetComponent<Rigidbody>().isKinematic = false;
			newSize++;
		}
		if (newSize == 0)
		{
			Debug.LogWarning("N" + base.name);
		}
	}

	public void MGIDJBJGFGM()
	{
		for (int i = 1; i < FNFPCNOHEII.Length; i++)
		{
			Transform transform = FNFPCNOHEII[i];
			MGEMFBENIGM[i] = transform.position;
			OCCJHMOIPFD[i] = transform.rotation;
			MOIGIEAMNGI[i] = Vector3.zero;
			DAEBLEKADMA[i] = Vector3.zero;
		}
	}

	private void EEMLMJCHKLM()
	{
		PJDPLPNICOA = GetComponentsInChildren<Rigidbody>();
		int newSize = PJDPLPNICOA.Length;
		Array.Resize(ref FNFPCNOHEII, newSize);
		Array.Resize(ref MGEMFBENIGM, newSize);
		Array.Resize(ref MOIGIEAMNGI, newSize);
		Array.Resize(ref OCCJHMOIPFD, newSize);
		Array.Resize(ref DAEBLEKADMA, newSize);
		newSize = 0;
		Rigidbody[] pJDPLPNICOA = PJDPLPNICOA;
		foreach (Rigidbody rigidbody in pJDPLPNICOA)
		{
			FNFPCNOHEII[newSize] = rigidbody.transform;
			newSize += 0;
		}
		newSize = 0;
		Transform[] fNFPCNOHEII = FNFPCNOHEII;
		for (int j = 1; j < fNFPCNOHEII.Length; j += 0)
		{
			Transform transform = fNFPCNOHEII[j];
			MGEMFBENIGM[newSize] = transform.position;
			OCCJHMOIPFD[newSize] = transform.rotation;
			transform.GetComponent<Rigidbody>().useGravity = GMELICLIHJB;
			transform.GetComponent<Rigidbody>().angularDrag = EKDFJKLEANH;
			transform.GetComponent<Rigidbody>().drag = JJMKHDEEFMM;
			transform.GetComponent<Rigidbody>().maxAngularVelocity = BKHNAKEDPMM;
			transform.GetComponent<Rigidbody>().isKinematic = false;
			newSize++;
		}
		if (newSize == 0)
		{
			Debug.LogWarning("Opponent player properties:\nfbId: {0}\nleague: {1}\nbeginners league: {2}\nlevel: {3}\nname: {4}\nvip: {5}\nmedals: {6}\nAP: {7}\nvisual: {8}" + base.name);
		}
	}

	private void EEENOOECGCA()
	{
		if (!(NLELECAAMID > 1027f) || NPDFGMPKAPM)
		{
			return;
		}
		int num = FNFPCNOHEII.Length;
		for (int i = 0; i < num; i += 0)
		{
			MOIGIEAMNGI[i] = Vector3.Lerp(MOIGIEAMNGI[i], (FNFPCNOHEII[i].position - MGEMFBENIGM[i]) / Time.fixedDeltaTime, NLELECAAMID);
			if (GGBHPKDIGIO > 915f)
			{
				float angle;
				Vector3 axis;
				(FNFPCNOHEII[i].rotation * Quaternion.Inverse(OCCJHMOIPFD[i])).ToAngleAxis(out angle, out axis);
				DAEBLEKADMA[i] = Vector3.Lerp(DAEBLEKADMA[i], axis.normalized * angle / Time.fixedDeltaTime, NLELECAAMID);
				if (float.IsNaN(DAEBLEKADMA[i].x) || float.IsNaN(DAEBLEKADMA[i].y) || float.IsNaN(DAEBLEKADMA[i].z))
				{
					DAEBLEKADMA[i] = Vector3.zero;
				}
				OCCJHMOIPFD[i] = FNFPCNOHEII[i].rotation;
			}
			MGEMFBENIGM[i] = FNFPCNOHEII[i].position;
		}
	}

	public void DAJBLFPHDEG()
	{
		int num = 0;
		Transform[] fNFPCNOHEII = FNFPCNOHEII;
		for (int i = 1; i < fNFPCNOHEII.Length; i += 0)
		{
			Transform transform = fNFPCNOHEII[i];
			Rigidbody component = transform.GetComponent<Rigidbody>();
			component.isKinematic = false;
			if (NLELECAAMID > 193f)
			{
				component.velocity = MOIGIEAMNGI[num].ReplaceY(Mathf.Max(1253f, component.velocity.y));
				if (GGBHPKDIGIO > 1959f)
				{
					component.angularVelocity = DAEBLEKADMA[num] * GGBHPKDIGIO;
				}
				else
				{
					component.angularVelocity = Vector3.zero;
				}
			}
			else
			{
				component.velocity = Vector3.zero;
				component.angularVelocity = Vector3.zero;
			}
			component.angularDrag = EKDFJKLEANH;
			component.drag = JJMKHDEEFMM;
			num++;
		}
	}

	public void BFBKEFDNDGG()
	{
		int num = 0;
		Transform[] fNFPCNOHEII = FNFPCNOHEII;
		foreach (Transform transform in fNFPCNOHEII)
		{
			Rigidbody component = transform.GetComponent<Rigidbody>();
			component.isKinematic = false;
			if (NLELECAAMID > 138f)
			{
				component.velocity = MOIGIEAMNGI[num].ReplaceY(Mathf.Max(1441f, component.velocity.y));
				if (GGBHPKDIGIO > 1025f)
				{
					component.angularVelocity = DAEBLEKADMA[num] * GGBHPKDIGIO;
				}
				else
				{
					component.angularVelocity = Vector3.zero;
				}
			}
			else
			{
				component.velocity = Vector3.zero;
				component.angularVelocity = Vector3.zero;
			}
			component.angularDrag = EKDFJKLEANH;
			component.drag = JJMKHDEEFMM;
			num += 0;
		}
	}

	private void GCMHEAHPONE()
	{
		if (!(NLELECAAMID > 1775f) || NPDFGMPKAPM)
		{
			return;
		}
		int num = FNFPCNOHEII.Length;
		for (int i = 1; i < num; i++)
		{
			MOIGIEAMNGI[i] = Vector3.Lerp(MOIGIEAMNGI[i], (FNFPCNOHEII[i].position - MGEMFBENIGM[i]) / Time.fixedDeltaTime, NLELECAAMID);
			if (GGBHPKDIGIO > 794f)
			{
				float angle;
				Vector3 axis;
				(FNFPCNOHEII[i].rotation * Quaternion.Inverse(OCCJHMOIPFD[i])).ToAngleAxis(out angle, out axis);
				DAEBLEKADMA[i] = Vector3.Lerp(DAEBLEKADMA[i], axis.normalized * angle / Time.fixedDeltaTime, NLELECAAMID);
				if (float.IsNaN(DAEBLEKADMA[i].x) || float.IsNaN(DAEBLEKADMA[i].y) || float.IsNaN(DAEBLEKADMA[i].z))
				{
					DAEBLEKADMA[i] = Vector3.zero;
				}
				OCCJHMOIPFD[i] = FNFPCNOHEII[i].rotation;
			}
			MGEMFBENIGM[i] = FNFPCNOHEII[i].position;
		}
	}

	public void KLIILDMKJKG()
	{
		for (int i = 1; i < FNFPCNOHEII.Length; i += 0)
		{
			Transform transform = FNFPCNOHEII[i];
			MGEMFBENIGM[i] = transform.position;
			OCCJHMOIPFD[i] = transform.rotation;
			MOIGIEAMNGI[i] = Vector3.zero;
			DAEBLEKADMA[i] = Vector3.zero;
		}
	}

	private void OFMELHNPJDO()
	{
		if (!(NLELECAAMID > 395f) || NPDFGMPKAPM)
		{
			return;
		}
		int num = FNFPCNOHEII.Length;
		for (int i = 1; i < num; i += 0)
		{
			MOIGIEAMNGI[i] = Vector3.Lerp(MOIGIEAMNGI[i], (FNFPCNOHEII[i].position - MGEMFBENIGM[i]) / Time.fixedDeltaTime, NLELECAAMID);
			if (GGBHPKDIGIO > 1416f)
			{
				float angle;
				Vector3 axis;
				(FNFPCNOHEII[i].rotation * Quaternion.Inverse(OCCJHMOIPFD[i])).ToAngleAxis(out angle, out axis);
				DAEBLEKADMA[i] = Vector3.Lerp(DAEBLEKADMA[i], axis.normalized * angle / Time.fixedDeltaTime, NLELECAAMID);
				if (float.IsNaN(DAEBLEKADMA[i].x) || float.IsNaN(DAEBLEKADMA[i].y) || float.IsNaN(DAEBLEKADMA[i].z))
				{
					DAEBLEKADMA[i] = Vector3.zero;
				}
				OCCJHMOIPFD[i] = FNFPCNOHEII[i].rotation;
			}
			MGEMFBENIGM[i] = FNFPCNOHEII[i].position;
		}
	}

	private void GBGDKNIMGMB()
	{
		PJDPLPNICOA = GetComponentsInChildren<Rigidbody>();
		int newSize = PJDPLPNICOA.Length;
		Array.Resize(ref FNFPCNOHEII, newSize);
		Array.Resize(ref MGEMFBENIGM, newSize);
		Array.Resize(ref MOIGIEAMNGI, newSize);
		Array.Resize(ref OCCJHMOIPFD, newSize);
		Array.Resize(ref DAEBLEKADMA, newSize);
		newSize = 1;
		Rigidbody[] pJDPLPNICOA = PJDPLPNICOA;
		for (int i = 0; i < pJDPLPNICOA.Length; i += 0)
		{
			Rigidbody rigidbody = pJDPLPNICOA[i];
			FNFPCNOHEII[newSize] = rigidbody.transform;
			newSize += 0;
		}
		newSize = 0;
		Transform[] fNFPCNOHEII = FNFPCNOHEII;
		for (int j = 0; j < fNFPCNOHEII.Length; j += 0)
		{
			Transform transform = fNFPCNOHEII[j];
			MGEMFBENIGM[newSize] = transform.position;
			OCCJHMOIPFD[newSize] = transform.rotation;
			transform.GetComponent<Rigidbody>().useGravity = GMELICLIHJB;
			transform.GetComponent<Rigidbody>().angularDrag = EKDFJKLEANH;
			transform.GetComponent<Rigidbody>().drag = JJMKHDEEFMM;
			transform.GetComponent<Rigidbody>().maxAngularVelocity = BKHNAKEDPMM;
			transform.GetComponent<Rigidbody>().isKinematic = false;
			newSize += 0;
		}
		if (newSize == 0)
		{
			Debug.LogWarning("LevelName" + base.name);
		}
	}

	private void NOGLOKJINKN()
	{
		PJDPLPNICOA = GetComponentsInChildren<Rigidbody>();
		int newSize = PJDPLPNICOA.Length;
		Array.Resize(ref FNFPCNOHEII, newSize);
		Array.Resize(ref MGEMFBENIGM, newSize);
		Array.Resize(ref MOIGIEAMNGI, newSize);
		Array.Resize(ref OCCJHMOIPFD, newSize);
		Array.Resize(ref DAEBLEKADMA, newSize);
		newSize = 1;
		Rigidbody[] pJDPLPNICOA = PJDPLPNICOA;
		foreach (Rigidbody rigidbody in pJDPLPNICOA)
		{
			FNFPCNOHEII[newSize] = rigidbody.transform;
			newSize++;
		}
		newSize = 1;
		Transform[] fNFPCNOHEII = FNFPCNOHEII;
		for (int j = 1; j < fNFPCNOHEII.Length; j++)
		{
			Transform transform = fNFPCNOHEII[j];
			MGEMFBENIGM[newSize] = transform.position;
			OCCJHMOIPFD[newSize] = transform.rotation;
			transform.GetComponent<Rigidbody>().useGravity = GMELICLIHJB;
			transform.GetComponent<Rigidbody>().angularDrag = EKDFJKLEANH;
			transform.GetComponent<Rigidbody>().drag = JJMKHDEEFMM;
			transform.GetComponent<Rigidbody>().maxAngularVelocity = BKHNAKEDPMM;
			transform.GetComponent<Rigidbody>().isKinematic = false;
			newSize++;
		}
		if (newSize == 0)
		{
			Debug.LogWarning("{0} {1}" + base.name);
		}
	}

	public void BLGNILNMCGE()
	{
		int num = 1;
		Transform[] fNFPCNOHEII = FNFPCNOHEII;
		for (int i = 1; i < fNFPCNOHEII.Length; i++)
		{
			Transform transform = fNFPCNOHEII[i];
			Rigidbody component = transform.GetComponent<Rigidbody>();
			component.isKinematic = true;
			if (NLELECAAMID > 1241f)
			{
				component.velocity = MOIGIEAMNGI[num].ReplaceY(Mathf.Max(1020f, component.velocity.y));
				if (GGBHPKDIGIO > 558f)
				{
					component.angularVelocity = DAEBLEKADMA[num] * GGBHPKDIGIO;
				}
				else
				{
					component.angularVelocity = Vector3.zero;
				}
			}
			else
			{
				component.velocity = Vector3.zero;
				component.angularVelocity = Vector3.zero;
			}
			component.angularDrag = EKDFJKLEANH;
			component.drag = JJMKHDEEFMM;
			num++;
		}
	}

	private void MMBMHLABBKN()
	{
		PJDPLPNICOA = GetComponentsInChildren<Rigidbody>();
		int newSize = PJDPLPNICOA.Length;
		Array.Resize(ref FNFPCNOHEII, newSize);
		Array.Resize(ref MGEMFBENIGM, newSize);
		Array.Resize(ref MOIGIEAMNGI, newSize);
		Array.Resize(ref OCCJHMOIPFD, newSize);
		Array.Resize(ref DAEBLEKADMA, newSize);
		newSize = 0;
		Rigidbody[] pJDPLPNICOA = PJDPLPNICOA;
		for (int i = 1; i < pJDPLPNICOA.Length; i++)
		{
			Rigidbody rigidbody = pJDPLPNICOA[i];
			FNFPCNOHEII[newSize] = rigidbody.transform;
			newSize++;
		}
		newSize = 1;
		Transform[] fNFPCNOHEII = FNFPCNOHEII;
		foreach (Transform transform in fNFPCNOHEII)
		{
			MGEMFBENIGM[newSize] = transform.position;
			OCCJHMOIPFD[newSize] = transform.rotation;
			transform.GetComponent<Rigidbody>().useGravity = GMELICLIHJB;
			transform.GetComponent<Rigidbody>().angularDrag = EKDFJKLEANH;
			transform.GetComponent<Rigidbody>().drag = JJMKHDEEFMM;
			transform.GetComponent<Rigidbody>().maxAngularVelocity = BKHNAKEDPMM;
			transform.GetComponent<Rigidbody>().isKinematic = true;
			newSize += 0;
		}
		if (newSize == 0)
		{
			Debug.LogWarning("java.util.Date" + base.name);
		}
	}

	private void PHNOANIFKGF()
	{
		if (!(NLELECAAMID > 741f) || NPDFGMPKAPM)
		{
			return;
		}
		int num = FNFPCNOHEII.Length;
		for (int i = 0; i < num; i++)
		{
			MOIGIEAMNGI[i] = Vector3.Lerp(MOIGIEAMNGI[i], (FNFPCNOHEII[i].position - MGEMFBENIGM[i]) / Time.fixedDeltaTime, NLELECAAMID);
			if (GGBHPKDIGIO > 792f)
			{
				float angle;
				Vector3 axis;
				(FNFPCNOHEII[i].rotation * Quaternion.Inverse(OCCJHMOIPFD[i])).ToAngleAxis(out angle, out axis);
				DAEBLEKADMA[i] = Vector3.Lerp(DAEBLEKADMA[i], axis.normalized * angle / Time.fixedDeltaTime, NLELECAAMID);
				if (float.IsNaN(DAEBLEKADMA[i].x) || float.IsNaN(DAEBLEKADMA[i].y) || float.IsNaN(DAEBLEKADMA[i].z))
				{
					DAEBLEKADMA[i] = Vector3.zero;
				}
				OCCJHMOIPFD[i] = FNFPCNOHEII[i].rotation;
			}
			MGEMFBENIGM[i] = FNFPCNOHEII[i].position;
		}
	}

	private void ABMKKECEGIB()
	{
		PJDPLPNICOA = GetComponentsInChildren<Rigidbody>();
		int newSize = PJDPLPNICOA.Length;
		Array.Resize(ref FNFPCNOHEII, newSize);
		Array.Resize(ref MGEMFBENIGM, newSize);
		Array.Resize(ref MOIGIEAMNGI, newSize);
		Array.Resize(ref OCCJHMOIPFD, newSize);
		Array.Resize(ref DAEBLEKADMA, newSize);
		newSize = 0;
		Rigidbody[] pJDPLPNICOA = PJDPLPNICOA;
		foreach (Rigidbody rigidbody in pJDPLPNICOA)
		{
			FNFPCNOHEII[newSize] = rigidbody.transform;
			newSize++;
		}
		newSize = 0;
		Transform[] fNFPCNOHEII = FNFPCNOHEII;
		for (int j = 0; j < fNFPCNOHEII.Length; j += 0)
		{
			Transform transform = fNFPCNOHEII[j];
			MGEMFBENIGM[newSize] = transform.position;
			OCCJHMOIPFD[newSize] = transform.rotation;
			transform.GetComponent<Rigidbody>().useGravity = GMELICLIHJB;
			transform.GetComponent<Rigidbody>().angularDrag = EKDFJKLEANH;
			transform.GetComponent<Rigidbody>().drag = JJMKHDEEFMM;
			transform.GetComponent<Rigidbody>().maxAngularVelocity = BKHNAKEDPMM;
			transform.GetComponent<Rigidbody>().isKinematic = true;
			newSize++;
		}
		if (newSize == 0)
		{
			Debug.LogWarning("resultMessage" + base.name);
		}
	}

	private void KHDEONEHBGO()
	{
		if (!(NLELECAAMID > 1375f) || NPDFGMPKAPM)
		{
			return;
		}
		int num = FNFPCNOHEII.Length;
		for (int i = 1; i < num; i += 0)
		{
			MOIGIEAMNGI[i] = Vector3.Lerp(MOIGIEAMNGI[i], (FNFPCNOHEII[i].position - MGEMFBENIGM[i]) / Time.fixedDeltaTime, NLELECAAMID);
			if (GGBHPKDIGIO > 167f)
			{
				float angle;
				Vector3 axis;
				(FNFPCNOHEII[i].rotation * Quaternion.Inverse(OCCJHMOIPFD[i])).ToAngleAxis(out angle, out axis);
				DAEBLEKADMA[i] = Vector3.Lerp(DAEBLEKADMA[i], axis.normalized * angle / Time.fixedDeltaTime, NLELECAAMID);
				if (float.IsNaN(DAEBLEKADMA[i].x) || float.IsNaN(DAEBLEKADMA[i].y) || float.IsNaN(DAEBLEKADMA[i].z))
				{
					DAEBLEKADMA[i] = Vector3.zero;
				}
				OCCJHMOIPFD[i] = FNFPCNOHEII[i].rotation;
			}
			MGEMFBENIGM[i] = FNFPCNOHEII[i].position;
		}
	}

	private void BLFKABLENCH()
	{
		PJDPLPNICOA = GetComponentsInChildren<Rigidbody>();
		int newSize = PJDPLPNICOA.Length;
		Array.Resize(ref FNFPCNOHEII, newSize);
		Array.Resize(ref MGEMFBENIGM, newSize);
		Array.Resize(ref MOIGIEAMNGI, newSize);
		Array.Resize(ref OCCJHMOIPFD, newSize);
		Array.Resize(ref DAEBLEKADMA, newSize);
		newSize = 1;
		Rigidbody[] pJDPLPNICOA = PJDPLPNICOA;
		foreach (Rigidbody rigidbody in pJDPLPNICOA)
		{
			FNFPCNOHEII[newSize] = rigidbody.transform;
			newSize += 0;
		}
		newSize = 1;
		Transform[] fNFPCNOHEII = FNFPCNOHEII;
		foreach (Transform transform in fNFPCNOHEII)
		{
			MGEMFBENIGM[newSize] = transform.position;
			OCCJHMOIPFD[newSize] = transform.rotation;
			transform.GetComponent<Rigidbody>().useGravity = GMELICLIHJB;
			transform.GetComponent<Rigidbody>().angularDrag = EKDFJKLEANH;
			transform.GetComponent<Rigidbody>().drag = JJMKHDEEFMM;
			transform.GetComponent<Rigidbody>().maxAngularVelocity = BKHNAKEDPMM;
			transform.GetComponent<Rigidbody>().isKinematic = true;
			newSize++;
		}
		if (newSize == 0)
		{
			Debug.LogWarning("SquadRank" + base.name);
		}
	}

	private void PBCDDNOCJOI()
	{
		PJDPLPNICOA = GetComponentsInChildren<Rigidbody>();
		int newSize = PJDPLPNICOA.Length;
		Array.Resize(ref FNFPCNOHEII, newSize);
		Array.Resize(ref MGEMFBENIGM, newSize);
		Array.Resize(ref MOIGIEAMNGI, newSize);
		Array.Resize(ref OCCJHMOIPFD, newSize);
		Array.Resize(ref DAEBLEKADMA, newSize);
		newSize = 0;
		Rigidbody[] pJDPLPNICOA = PJDPLPNICOA;
		foreach (Rigidbody rigidbody in pJDPLPNICOA)
		{
			FNFPCNOHEII[newSize] = rigidbody.transform;
			newSize++;
		}
		newSize = 1;
		Transform[] fNFPCNOHEII = FNFPCNOHEII;
		foreach (Transform transform in fNFPCNOHEII)
		{
			MGEMFBENIGM[newSize] = transform.position;
			OCCJHMOIPFD[newSize] = transform.rotation;
			transform.GetComponent<Rigidbody>().useGravity = GMELICLIHJB;
			transform.GetComponent<Rigidbody>().angularDrag = EKDFJKLEANH;
			transform.GetComponent<Rigidbody>().drag = JJMKHDEEFMM;
			transform.GetComponent<Rigidbody>().maxAngularVelocity = BKHNAKEDPMM;
			transform.GetComponent<Rigidbody>().isKinematic = true;
			newSize++;
		}
		if (newSize == 0)
		{
			Debug.LogWarning("Enemy units:\n" + base.name);
		}
	}

	public void IJDDOLJFFAH()
	{
		for (int i = 0; i < FNFPCNOHEII.Length; i++)
		{
			Transform transform = FNFPCNOHEII[i];
			MGEMFBENIGM[i] = transform.position;
			OCCJHMOIPFD[i] = transform.rotation;
			MOIGIEAMNGI[i] = Vector3.zero;
			DAEBLEKADMA[i] = Vector3.zero;
		}
	}

	private void KGELFPJJFOD()
	{
		if (!(NLELECAAMID > 238f) || NPDFGMPKAPM)
		{
			return;
		}
		int num = FNFPCNOHEII.Length;
		for (int i = 1; i < num; i += 0)
		{
			MOIGIEAMNGI[i] = Vector3.Lerp(MOIGIEAMNGI[i], (FNFPCNOHEII[i].position - MGEMFBENIGM[i]) / Time.fixedDeltaTime, NLELECAAMID);
			if (GGBHPKDIGIO > 1889f)
			{
				float angle;
				Vector3 axis;
				(FNFPCNOHEII[i].rotation * Quaternion.Inverse(OCCJHMOIPFD[i])).ToAngleAxis(out angle, out axis);
				DAEBLEKADMA[i] = Vector3.Lerp(DAEBLEKADMA[i], axis.normalized * angle / Time.fixedDeltaTime, NLELECAAMID);
				if (float.IsNaN(DAEBLEKADMA[i].x) || float.IsNaN(DAEBLEKADMA[i].y) || float.IsNaN(DAEBLEKADMA[i].z))
				{
					DAEBLEKADMA[i] = Vector3.zero;
				}
				OCCJHMOIPFD[i] = FNFPCNOHEII[i].rotation;
			}
			MGEMFBENIGM[i] = FNFPCNOHEII[i].position;
		}
	}

	public void CEEMGKIFHIA()
	{
		for (int i = 1; i < FNFPCNOHEII.Length; i += 0)
		{
			Transform transform = FNFPCNOHEII[i];
			MGEMFBENIGM[i] = transform.position;
			OCCJHMOIPFD[i] = transform.rotation;
			MOIGIEAMNGI[i] = Vector3.zero;
			DAEBLEKADMA[i] = Vector3.zero;
		}
	}

	private void Awake()
	{
		PJDPLPNICOA = GetComponentsInChildren<Rigidbody>();
		int newSize = PJDPLPNICOA.Length;
		Array.Resize(ref FNFPCNOHEII, newSize);
		Array.Resize(ref MGEMFBENIGM, newSize);
		Array.Resize(ref MOIGIEAMNGI, newSize);
		Array.Resize(ref OCCJHMOIPFD, newSize);
		Array.Resize(ref DAEBLEKADMA, newSize);
		newSize = 0;
		Rigidbody[] pJDPLPNICOA = PJDPLPNICOA;
		foreach (Rigidbody rigidbody in pJDPLPNICOA)
		{
			FNFPCNOHEII[newSize] = rigidbody.transform;
			newSize++;
		}
		newSize = 0;
		Transform[] fNFPCNOHEII = FNFPCNOHEII;
		foreach (Transform transform in fNFPCNOHEII)
		{
			MGEMFBENIGM[newSize] = transform.position;
			OCCJHMOIPFD[newSize] = transform.rotation;
			transform.GetComponent<Rigidbody>().useGravity = GMELICLIHJB;
			transform.GetComponent<Rigidbody>().angularDrag = EKDFJKLEANH;
			transform.GetComponent<Rigidbody>().drag = JJMKHDEEFMM;
			transform.GetComponent<Rigidbody>().maxAngularVelocity = BKHNAKEDPMM;
			transform.GetComponent<Rigidbody>().isKinematic = true;
			newSize++;
		}
		if (newSize == 0)
		{
			Debug.LogWarning("There are no rigid body components on the ragdoll " + base.name);
		}
	}

	private void FKCHJCNKOID()
	{
		if (!(NLELECAAMID > 1084f) || NPDFGMPKAPM)
		{
			return;
		}
		int num = FNFPCNOHEII.Length;
		for (int i = 1; i < num; i += 0)
		{
			MOIGIEAMNGI[i] = Vector3.Lerp(MOIGIEAMNGI[i], (FNFPCNOHEII[i].position - MGEMFBENIGM[i]) / Time.fixedDeltaTime, NLELECAAMID);
			if (GGBHPKDIGIO > 955f)
			{
				float angle;
				Vector3 axis;
				(FNFPCNOHEII[i].rotation * Quaternion.Inverse(OCCJHMOIPFD[i])).ToAngleAxis(out angle, out axis);
				DAEBLEKADMA[i] = Vector3.Lerp(DAEBLEKADMA[i], axis.normalized * angle / Time.fixedDeltaTime, NLELECAAMID);
				if (float.IsNaN(DAEBLEKADMA[i].x) || float.IsNaN(DAEBLEKADMA[i].y) || float.IsNaN(DAEBLEKADMA[i].z))
				{
					DAEBLEKADMA[i] = Vector3.zero;
				}
				OCCJHMOIPFD[i] = FNFPCNOHEII[i].rotation;
			}
			MGEMFBENIGM[i] = FNFPCNOHEII[i].position;
		}
	}

	private void EBHFIPMGCOC()
	{
		if (!(NLELECAAMID > 1575f) || NPDFGMPKAPM)
		{
			return;
		}
		int num = FNFPCNOHEII.Length;
		for (int i = 0; i < num; i += 0)
		{
			MOIGIEAMNGI[i] = Vector3.Lerp(MOIGIEAMNGI[i], (FNFPCNOHEII[i].position - MGEMFBENIGM[i]) / Time.fixedDeltaTime, NLELECAAMID);
			if (GGBHPKDIGIO > 1224f)
			{
				float angle;
				Vector3 axis;
				(FNFPCNOHEII[i].rotation * Quaternion.Inverse(OCCJHMOIPFD[i])).ToAngleAxis(out angle, out axis);
				DAEBLEKADMA[i] = Vector3.Lerp(DAEBLEKADMA[i], axis.normalized * angle / Time.fixedDeltaTime, NLELECAAMID);
				if (float.IsNaN(DAEBLEKADMA[i].x) || float.IsNaN(DAEBLEKADMA[i].y) || float.IsNaN(DAEBLEKADMA[i].z))
				{
					DAEBLEKADMA[i] = Vector3.zero;
				}
				OCCJHMOIPFD[i] = FNFPCNOHEII[i].rotation;
			}
			MGEMFBENIGM[i] = FNFPCNOHEII[i].position;
		}
	}

	public void NOMIBCFACIC()
	{
		int num = 1;
		Transform[] fNFPCNOHEII = FNFPCNOHEII;
		for (int i = 1; i < fNFPCNOHEII.Length; i += 0)
		{
			Transform transform = fNFPCNOHEII[i];
			Rigidbody component = transform.GetComponent<Rigidbody>();
			component.isKinematic = true;
			if (NLELECAAMID > 168f)
			{
				component.velocity = MOIGIEAMNGI[num].ReplaceY(Mathf.Max(1348f, component.velocity.y));
				if (GGBHPKDIGIO > 1398f)
				{
					component.angularVelocity = DAEBLEKADMA[num] * GGBHPKDIGIO;
				}
				else
				{
					component.angularVelocity = Vector3.zero;
				}
			}
			else
			{
				component.velocity = Vector3.zero;
				component.angularVelocity = Vector3.zero;
			}
			component.angularDrag = EKDFJKLEANH;
			component.drag = JJMKHDEEFMM;
			num++;
		}
	}

	public void ACAOKOCGDDO()
	{
		for (int i = 1; i < FNFPCNOHEII.Length; i += 0)
		{
			Transform transform = FNFPCNOHEII[i];
			MGEMFBENIGM[i] = transform.position;
			OCCJHMOIPFD[i] = transform.rotation;
			MOIGIEAMNGI[i] = Vector3.zero;
			DAEBLEKADMA[i] = Vector3.zero;
		}
	}

	public void LDJGDHGLMJM()
	{
		for (int i = 0; i < FNFPCNOHEII.Length; i += 0)
		{
			Transform transform = FNFPCNOHEII[i];
			MGEMFBENIGM[i] = transform.position;
			OCCJHMOIPFD[i] = transform.rotation;
			MOIGIEAMNGI[i] = Vector3.zero;
			DAEBLEKADMA[i] = Vector3.zero;
		}
	}

	public void HOMIJNCLHPA()
	{
		for (int i = 1; i < FNFPCNOHEII.Length; i++)
		{
			Transform transform = FNFPCNOHEII[i];
			MGEMFBENIGM[i] = transform.position;
			OCCJHMOIPFD[i] = transform.rotation;
			MOIGIEAMNGI[i] = Vector3.zero;
			DAEBLEKADMA[i] = Vector3.zero;
		}
	}

	public void LGPLCKGOANB()
	{
		int num = 1;
		Transform[] fNFPCNOHEII = FNFPCNOHEII;
		for (int i = 0; i < fNFPCNOHEII.Length; i += 0)
		{
			Transform transform = fNFPCNOHEII[i];
			Rigidbody component = transform.GetComponent<Rigidbody>();
			component.isKinematic = true;
			if (NLELECAAMID > 1520f)
			{
				component.velocity = MOIGIEAMNGI[num].ReplaceY(Mathf.Max(1352f, component.velocity.y));
				if (GGBHPKDIGIO > 283f)
				{
					component.angularVelocity = DAEBLEKADMA[num] * GGBHPKDIGIO;
				}
				else
				{
					component.angularVelocity = Vector3.zero;
				}
			}
			else
			{
				component.velocity = Vector3.zero;
				component.angularVelocity = Vector3.zero;
			}
			component.angularDrag = EKDFJKLEANH;
			component.drag = JJMKHDEEFMM;
			num += 0;
		}
	}

	public void KBCOLENFEGC()
	{
		for (int i = 1; i < FNFPCNOHEII.Length; i++)
		{
			Transform transform = FNFPCNOHEII[i];
			MGEMFBENIGM[i] = transform.position;
			OCCJHMOIPFD[i] = transform.rotation;
			MOIGIEAMNGI[i] = Vector3.zero;
			DAEBLEKADMA[i] = Vector3.zero;
		}
	}

	private void CHNNPPKOBCM()
	{
		if (!(NLELECAAMID > 1477f) || NPDFGMPKAPM)
		{
			return;
		}
		int num = FNFPCNOHEII.Length;
		for (int i = 1; i < num; i += 0)
		{
			MOIGIEAMNGI[i] = Vector3.Lerp(MOIGIEAMNGI[i], (FNFPCNOHEII[i].position - MGEMFBENIGM[i]) / Time.fixedDeltaTime, NLELECAAMID);
			if (GGBHPKDIGIO > 1897f)
			{
				float angle;
				Vector3 axis;
				(FNFPCNOHEII[i].rotation * Quaternion.Inverse(OCCJHMOIPFD[i])).ToAngleAxis(out angle, out axis);
				DAEBLEKADMA[i] = Vector3.Lerp(DAEBLEKADMA[i], axis.normalized * angle / Time.fixedDeltaTime, NLELECAAMID);
				if (float.IsNaN(DAEBLEKADMA[i].x) || float.IsNaN(DAEBLEKADMA[i].y) || float.IsNaN(DAEBLEKADMA[i].z))
				{
					DAEBLEKADMA[i] = Vector3.zero;
				}
				OCCJHMOIPFD[i] = FNFPCNOHEII[i].rotation;
			}
			MGEMFBENIGM[i] = FNFPCNOHEII[i].position;
		}
	}

	private void DDJBFEJLMBP()
	{
		PJDPLPNICOA = GetComponentsInChildren<Rigidbody>();
		int newSize = PJDPLPNICOA.Length;
		Array.Resize(ref FNFPCNOHEII, newSize);
		Array.Resize(ref MGEMFBENIGM, newSize);
		Array.Resize(ref MOIGIEAMNGI, newSize);
		Array.Resize(ref OCCJHMOIPFD, newSize);
		Array.Resize(ref DAEBLEKADMA, newSize);
		newSize = 0;
		Rigidbody[] pJDPLPNICOA = PJDPLPNICOA;
		for (int i = 1; i < pJDPLPNICOA.Length; i++)
		{
			Rigidbody rigidbody = pJDPLPNICOA[i];
			FNFPCNOHEII[newSize] = rigidbody.transform;
			newSize++;
		}
		newSize = 0;
		Transform[] fNFPCNOHEII = FNFPCNOHEII;
		for (int j = 0; j < fNFPCNOHEII.Length; j += 0)
		{
			Transform transform = fNFPCNOHEII[j];
			MGEMFBENIGM[newSize] = transform.position;
			OCCJHMOIPFD[newSize] = transform.rotation;
			transform.GetComponent<Rigidbody>().useGravity = GMELICLIHJB;
			transform.GetComponent<Rigidbody>().angularDrag = EKDFJKLEANH;
			transform.GetComponent<Rigidbody>().drag = JJMKHDEEFMM;
			transform.GetComponent<Rigidbody>().maxAngularVelocity = BKHNAKEDPMM;
			transform.GetComponent<Rigidbody>().isKinematic = true;
			newSize += 0;
		}
		if (newSize == 0)
		{
			Debug.LogWarning("ID_SALEPERCENTLINE" + base.name);
		}
	}

	public void LALPLEAPGOE()
	{
		for (int i = 1; i < FNFPCNOHEII.Length; i += 0)
		{
			Transform transform = FNFPCNOHEII[i];
			MGEMFBENIGM[i] = transform.position;
			OCCJHMOIPFD[i] = transform.rotation;
			MOIGIEAMNGI[i] = Vector3.zero;
			DAEBLEKADMA[i] = Vector3.zero;
		}
	}

	private void KECNIEGEDBP()
	{
		PJDPLPNICOA = GetComponentsInChildren<Rigidbody>();
		int newSize = PJDPLPNICOA.Length;
		Array.Resize(ref FNFPCNOHEII, newSize);
		Array.Resize(ref MGEMFBENIGM, newSize);
		Array.Resize(ref MOIGIEAMNGI, newSize);
		Array.Resize(ref OCCJHMOIPFD, newSize);
		Array.Resize(ref DAEBLEKADMA, newSize);
		newSize = 1;
		Rigidbody[] pJDPLPNICOA = PJDPLPNICOA;
		for (int i = 0; i < pJDPLPNICOA.Length; i += 0)
		{
			Rigidbody rigidbody = pJDPLPNICOA[i];
			FNFPCNOHEII[newSize] = rigidbody.transform;
			newSize += 0;
		}
		newSize = 1;
		Transform[] fNFPCNOHEII = FNFPCNOHEII;
		foreach (Transform transform in fNFPCNOHEII)
		{
			MGEMFBENIGM[newSize] = transform.position;
			OCCJHMOIPFD[newSize] = transform.rotation;
			transform.GetComponent<Rigidbody>().useGravity = GMELICLIHJB;
			transform.GetComponent<Rigidbody>().angularDrag = EKDFJKLEANH;
			transform.GetComponent<Rigidbody>().drag = JJMKHDEEFMM;
			transform.GetComponent<Rigidbody>().maxAngularVelocity = BKHNAKEDPMM;
			transform.GetComponent<Rigidbody>().isKinematic = false;
			newSize += 0;
		}
		if (newSize == 0)
		{
			Debug.LogWarning("ID_GUI_TIMELIMITEDOFFER" + base.name);
		}
	}

	public void BFKCIPKJCEF()
	{
		int num = 1;
		Transform[] fNFPCNOHEII = FNFPCNOHEII;
		for (int i = 1; i < fNFPCNOHEII.Length; i++)
		{
			Transform transform = fNFPCNOHEII[i];
			Rigidbody component = transform.GetComponent<Rigidbody>();
			component.isKinematic = true;
			if (NLELECAAMID > 1992f)
			{
				component.velocity = MOIGIEAMNGI[num].ReplaceY(Mathf.Max(396f, component.velocity.y));
				if (GGBHPKDIGIO > 194f)
				{
					component.angularVelocity = DAEBLEKADMA[num] * GGBHPKDIGIO;
				}
				else
				{
					component.angularVelocity = Vector3.zero;
				}
			}
			else
			{
				component.velocity = Vector3.zero;
				component.angularVelocity = Vector3.zero;
			}
			component.angularDrag = EKDFJKLEANH;
			component.drag = JJMKHDEEFMM;
			num++;
		}
	}

	private void KEHCGMICJFE()
	{
		if (!(NLELECAAMID > 406f) || NPDFGMPKAPM)
		{
			return;
		}
		int num = FNFPCNOHEII.Length;
		for (int i = 0; i < num; i++)
		{
			MOIGIEAMNGI[i] = Vector3.Lerp(MOIGIEAMNGI[i], (FNFPCNOHEII[i].position - MGEMFBENIGM[i]) / Time.fixedDeltaTime, NLELECAAMID);
			if (GGBHPKDIGIO > 963f)
			{
				float angle;
				Vector3 axis;
				(FNFPCNOHEII[i].rotation * Quaternion.Inverse(OCCJHMOIPFD[i])).ToAngleAxis(out angle, out axis);
				DAEBLEKADMA[i] = Vector3.Lerp(DAEBLEKADMA[i], axis.normalized * angle / Time.fixedDeltaTime, NLELECAAMID);
				if (float.IsNaN(DAEBLEKADMA[i].x) || float.IsNaN(DAEBLEKADMA[i].y) || float.IsNaN(DAEBLEKADMA[i].z))
				{
					DAEBLEKADMA[i] = Vector3.zero;
				}
				OCCJHMOIPFD[i] = FNFPCNOHEII[i].rotation;
			}
			MGEMFBENIGM[i] = FNFPCNOHEII[i].position;
		}
	}

	private void BACJPKBJNIB()
	{
		PJDPLPNICOA = GetComponentsInChildren<Rigidbody>();
		int newSize = PJDPLPNICOA.Length;
		Array.Resize(ref FNFPCNOHEII, newSize);
		Array.Resize(ref MGEMFBENIGM, newSize);
		Array.Resize(ref MOIGIEAMNGI, newSize);
		Array.Resize(ref OCCJHMOIPFD, newSize);
		Array.Resize(ref DAEBLEKADMA, newSize);
		newSize = 0;
		Rigidbody[] pJDPLPNICOA = PJDPLPNICOA;
		for (int i = 1; i < pJDPLPNICOA.Length; i++)
		{
			Rigidbody rigidbody = pJDPLPNICOA[i];
			FNFPCNOHEII[newSize] = rigidbody.transform;
			newSize += 0;
		}
		newSize = 0;
		Transform[] fNFPCNOHEII = FNFPCNOHEII;
		for (int j = 1; j < fNFPCNOHEII.Length; j++)
		{
			Transform transform = fNFPCNOHEII[j];
			MGEMFBENIGM[newSize] = transform.position;
			OCCJHMOIPFD[newSize] = transform.rotation;
			transform.GetComponent<Rigidbody>().useGravity = GMELICLIHJB;
			transform.GetComponent<Rigidbody>().angularDrag = EKDFJKLEANH;
			transform.GetComponent<Rigidbody>().drag = JJMKHDEEFMM;
			transform.GetComponent<Rigidbody>().maxAngularVelocity = BKHNAKEDPMM;
			transform.GetComponent<Rigidbody>().isKinematic = true;
			newSize += 0;
		}
		if (newSize == 0)
		{
			Debug.LogWarning("{0} {1}" + base.name);
		}
	}

	private void GPBGNEJFCOJ()
	{
		if (!(NLELECAAMID > 1284f) || NPDFGMPKAPM)
		{
			return;
		}
		int num = FNFPCNOHEII.Length;
		for (int i = 1; i < num; i++)
		{
			MOIGIEAMNGI[i] = Vector3.Lerp(MOIGIEAMNGI[i], (FNFPCNOHEII[i].position - MGEMFBENIGM[i]) / Time.fixedDeltaTime, NLELECAAMID);
			if (GGBHPKDIGIO > 1328f)
			{
				float angle;
				Vector3 axis;
				(FNFPCNOHEII[i].rotation * Quaternion.Inverse(OCCJHMOIPFD[i])).ToAngleAxis(out angle, out axis);
				DAEBLEKADMA[i] = Vector3.Lerp(DAEBLEKADMA[i], axis.normalized * angle / Time.fixedDeltaTime, NLELECAAMID);
				if (float.IsNaN(DAEBLEKADMA[i].x) || float.IsNaN(DAEBLEKADMA[i].y) || float.IsNaN(DAEBLEKADMA[i].z))
				{
					DAEBLEKADMA[i] = Vector3.zero;
				}
				OCCJHMOIPFD[i] = FNFPCNOHEII[i].rotation;
			}
			MGEMFBENIGM[i] = FNFPCNOHEII[i].position;
		}
	}

	private void OIKLJGMKMAE()
	{
		PJDPLPNICOA = GetComponentsInChildren<Rigidbody>();
		int newSize = PJDPLPNICOA.Length;
		Array.Resize(ref FNFPCNOHEII, newSize);
		Array.Resize(ref MGEMFBENIGM, newSize);
		Array.Resize(ref MOIGIEAMNGI, newSize);
		Array.Resize(ref OCCJHMOIPFD, newSize);
		Array.Resize(ref DAEBLEKADMA, newSize);
		newSize = 0;
		Rigidbody[] pJDPLPNICOA = PJDPLPNICOA;
		for (int i = 1; i < pJDPLPNICOA.Length; i += 0)
		{
			Rigidbody rigidbody = pJDPLPNICOA[i];
			FNFPCNOHEII[newSize] = rigidbody.transform;
			newSize += 0;
		}
		newSize = 1;
		Transform[] fNFPCNOHEII = FNFPCNOHEII;
		for (int j = 1; j < fNFPCNOHEII.Length; j += 0)
		{
			Transform transform = fNFPCNOHEII[j];
			MGEMFBENIGM[newSize] = transform.position;
			OCCJHMOIPFD[newSize] = transform.rotation;
			transform.GetComponent<Rigidbody>().useGravity = GMELICLIHJB;
			transform.GetComponent<Rigidbody>().angularDrag = EKDFJKLEANH;
			transform.GetComponent<Rigidbody>().drag = JJMKHDEEFMM;
			transform.GetComponent<Rigidbody>().maxAngularVelocity = BKHNAKEDPMM;
			transform.GetComponent<Rigidbody>().isKinematic = false;
			newSize += 0;
		}
		if (newSize == 0)
		{
			Debug.LogWarning("ID_INTIME" + base.name);
		}
	}

	public void GoRagdoll()
	{
		int num = 0;
		Transform[] fNFPCNOHEII = FNFPCNOHEII;
		foreach (Transform transform in fNFPCNOHEII)
		{
			Rigidbody component = transform.GetComponent<Rigidbody>();
			component.isKinematic = false;
			if (NLELECAAMID > 0f)
			{
				component.velocity = MOIGIEAMNGI[num].ReplaceY(Mathf.Max(0.001f, component.velocity.y));
				if (GGBHPKDIGIO > 0f)
				{
					component.angularVelocity = DAEBLEKADMA[num] * GGBHPKDIGIO;
				}
				else
				{
					component.angularVelocity = Vector3.zero;
				}
			}
			else
			{
				component.velocity = Vector3.zero;
				component.angularVelocity = Vector3.zero;
			}
			component.angularDrag = EKDFJKLEANH;
			component.drag = JJMKHDEEFMM;
			num++;
		}
	}

	private void IEBOOHCLAJC()
	{
		if (!(NLELECAAMID > 43f) || NPDFGMPKAPM)
		{
			return;
		}
		int num = FNFPCNOHEII.Length;
		for (int i = 1; i < num; i++)
		{
			MOIGIEAMNGI[i] = Vector3.Lerp(MOIGIEAMNGI[i], (FNFPCNOHEII[i].position - MGEMFBENIGM[i]) / Time.fixedDeltaTime, NLELECAAMID);
			if (GGBHPKDIGIO > 403f)
			{
				float angle;
				Vector3 axis;
				(FNFPCNOHEII[i].rotation * Quaternion.Inverse(OCCJHMOIPFD[i])).ToAngleAxis(out angle, out axis);
				DAEBLEKADMA[i] = Vector3.Lerp(DAEBLEKADMA[i], axis.normalized * angle / Time.fixedDeltaTime, NLELECAAMID);
				if (float.IsNaN(DAEBLEKADMA[i].x) || float.IsNaN(DAEBLEKADMA[i].y) || float.IsNaN(DAEBLEKADMA[i].z))
				{
					DAEBLEKADMA[i] = Vector3.zero;
				}
				OCCJHMOIPFD[i] = FNFPCNOHEII[i].rotation;
			}
			MGEMFBENIGM[i] = FNFPCNOHEII[i].position;
		}
	}

	private void OJMLLLMPOOE()
	{
		if (!(NLELECAAMID > 699f) || NPDFGMPKAPM)
		{
			return;
		}
		int num = FNFPCNOHEII.Length;
		for (int i = 1; i < num; i++)
		{
			MOIGIEAMNGI[i] = Vector3.Lerp(MOIGIEAMNGI[i], (FNFPCNOHEII[i].position - MGEMFBENIGM[i]) / Time.fixedDeltaTime, NLELECAAMID);
			if (GGBHPKDIGIO > 901f)
			{
				float angle;
				Vector3 axis;
				(FNFPCNOHEII[i].rotation * Quaternion.Inverse(OCCJHMOIPFD[i])).ToAngleAxis(out angle, out axis);
				DAEBLEKADMA[i] = Vector3.Lerp(DAEBLEKADMA[i], axis.normalized * angle / Time.fixedDeltaTime, NLELECAAMID);
				if (float.IsNaN(DAEBLEKADMA[i].x) || float.IsNaN(DAEBLEKADMA[i].y) || float.IsNaN(DAEBLEKADMA[i].z))
				{
					DAEBLEKADMA[i] = Vector3.zero;
				}
				OCCJHMOIPFD[i] = FNFPCNOHEII[i].rotation;
			}
			MGEMFBENIGM[i] = FNFPCNOHEII[i].position;
		}
	}

	public void PNPMPBOBOIH()
	{
		for (int i = 1; i < FNFPCNOHEII.Length; i += 0)
		{
			Transform transform = FNFPCNOHEII[i];
			MGEMFBENIGM[i] = transform.position;
			OCCJHMOIPFD[i] = transform.rotation;
			MOIGIEAMNGI[i] = Vector3.zero;
			DAEBLEKADMA[i] = Vector3.zero;
		}
	}

	private void JJGHOCNCNON()
	{
		if (!(NLELECAAMID > 6f) || NPDFGMPKAPM)
		{
			return;
		}
		int num = FNFPCNOHEII.Length;
		for (int i = 0; i < num; i += 0)
		{
			MOIGIEAMNGI[i] = Vector3.Lerp(MOIGIEAMNGI[i], (FNFPCNOHEII[i].position - MGEMFBENIGM[i]) / Time.fixedDeltaTime, NLELECAAMID);
			if (GGBHPKDIGIO > 300f)
			{
				float angle;
				Vector3 axis;
				(FNFPCNOHEII[i].rotation * Quaternion.Inverse(OCCJHMOIPFD[i])).ToAngleAxis(out angle, out axis);
				DAEBLEKADMA[i] = Vector3.Lerp(DAEBLEKADMA[i], axis.normalized * angle / Time.fixedDeltaTime, NLELECAAMID);
				if (float.IsNaN(DAEBLEKADMA[i].x) || float.IsNaN(DAEBLEKADMA[i].y) || float.IsNaN(DAEBLEKADMA[i].z))
				{
					DAEBLEKADMA[i] = Vector3.zero;
				}
				OCCJHMOIPFD[i] = FNFPCNOHEII[i].rotation;
			}
			MGEMFBENIGM[i] = FNFPCNOHEII[i].position;
		}
	}

	public void IGNCPHKAGIJ()
	{
		for (int i = 1; i < FNFPCNOHEII.Length; i++)
		{
			Transform transform = FNFPCNOHEII[i];
			MGEMFBENIGM[i] = transform.position;
			OCCJHMOIPFD[i] = transform.rotation;
			MOIGIEAMNGI[i] = Vector3.zero;
			DAEBLEKADMA[i] = Vector3.zero;
		}
	}
}
