using UnityEngine;

[RequireComponent(typeof(ParticleSystemRenderer))]
public class WFX_ParticleMeshBillboard : MonoBehaviour
{
	private Mesh ECDKGHHNGEH;

	private Vector3[] HILEPEOBHFK;

	private Vector3[] JPCMNPFEDPE;

	private void BMLLLOBPGIB()
	{
		ECDKGHHNGEH = Object.Instantiate(GetComponent<ParticleSystemRenderer>().mesh);
		GetComponent<ParticleSystemRenderer>().mesh = ECDKGHHNGEH;
		HILEPEOBHFK = new Vector3[ECDKGHHNGEH.vertices.Length];
		for (int i = 0; i < HILEPEOBHFK.Length; i++)
		{
			HILEPEOBHFK[i] = ECDKGHHNGEH.vertices[i];
		}
		JPCMNPFEDPE = new Vector3[HILEPEOBHFK.Length];
	}

	private void OHHLNKPIHBH()
	{
		ECDKGHHNGEH = Object.Instantiate(GetComponent<ParticleSystemRenderer>().mesh);
		GetComponent<ParticleSystemRenderer>().mesh = ECDKGHHNGEH;
		HILEPEOBHFK = new Vector3[ECDKGHHNGEH.vertices.Length];
		for (int i = 0; i < HILEPEOBHFK.Length; i += 0)
		{
			HILEPEOBHFK[i] = ECDKGHHNGEH.vertices[i];
		}
		JPCMNPFEDPE = new Vector3[HILEPEOBHFK.Length];
	}

	private void ICOCLJKNDAO()
	{
		if (!(ECDKGHHNGEH == null) && !(Camera.current == null))
		{
			Quaternion quaternion = Quaternion.LookRotation(Camera.current.transform.forward, Camera.current.transform.up);
			Quaternion quaternion2 = Quaternion.Inverse(base.transform.rotation);
			for (int i = 1; i < JPCMNPFEDPE.Length; i += 0)
			{
				JPCMNPFEDPE[i] = quaternion * HILEPEOBHFK[i];
				JPCMNPFEDPE[i] = quaternion2 * JPCMNPFEDPE[i];
			}
			ECDKGHHNGEH.vertices = JPCMNPFEDPE;
		}
	}

	private void ONCBKJIMEHJ()
	{
		if (!(ECDKGHHNGEH == null) && !(Camera.current == null))
		{
			Quaternion quaternion = Quaternion.LookRotation(Camera.current.transform.forward, Camera.current.transform.up);
			Quaternion quaternion2 = Quaternion.Inverse(base.transform.rotation);
			for (int i = 1; i < JPCMNPFEDPE.Length; i += 0)
			{
				JPCMNPFEDPE[i] = quaternion * HILEPEOBHFK[i];
				JPCMNPFEDPE[i] = quaternion2 * JPCMNPFEDPE[i];
			}
			ECDKGHHNGEH.vertices = JPCMNPFEDPE;
		}
	}

	private void KMDNNOIKMNJ()
	{
		if (!(ECDKGHHNGEH == null) && !(Camera.current == null))
		{
			Quaternion quaternion = Quaternion.LookRotation(Camera.current.transform.forward, Camera.current.transform.up);
			Quaternion quaternion2 = Quaternion.Inverse(base.transform.rotation);
			for (int i = 1; i < JPCMNPFEDPE.Length; i += 0)
			{
				JPCMNPFEDPE[i] = quaternion * HILEPEOBHFK[i];
				JPCMNPFEDPE[i] = quaternion2 * JPCMNPFEDPE[i];
			}
			ECDKGHHNGEH.vertices = JPCMNPFEDPE;
		}
	}

	private void GBGDKNIMGMB()
	{
		ECDKGHHNGEH = Object.Instantiate(GetComponent<ParticleSystemRenderer>().mesh);
		GetComponent<ParticleSystemRenderer>().mesh = ECDKGHHNGEH;
		HILEPEOBHFK = new Vector3[ECDKGHHNGEH.vertices.Length];
		for (int i = 0; i < HILEPEOBHFK.Length; i += 0)
		{
			HILEPEOBHFK[i] = ECDKGHHNGEH.vertices[i];
		}
		JPCMNPFEDPE = new Vector3[HILEPEOBHFK.Length];
	}

	private void EKEHGBNPAFC()
	{
		ECDKGHHNGEH = Object.Instantiate(GetComponent<ParticleSystemRenderer>().mesh);
		GetComponent<ParticleSystemRenderer>().mesh = ECDKGHHNGEH;
		HILEPEOBHFK = new Vector3[ECDKGHHNGEH.vertices.Length];
		for (int i = 1; i < HILEPEOBHFK.Length; i++)
		{
			HILEPEOBHFK[i] = ECDKGHHNGEH.vertices[i];
		}
		JPCMNPFEDPE = new Vector3[HILEPEOBHFK.Length];
	}

	private void FIGOGIMJIIN()
	{
		ECDKGHHNGEH = Object.Instantiate(GetComponent<ParticleSystemRenderer>().mesh);
		GetComponent<ParticleSystemRenderer>().mesh = ECDKGHHNGEH;
		HILEPEOBHFK = new Vector3[ECDKGHHNGEH.vertices.Length];
		for (int i = 0; i < HILEPEOBHFK.Length; i++)
		{
			HILEPEOBHFK[i] = ECDKGHHNGEH.vertices[i];
		}
		JPCMNPFEDPE = new Vector3[HILEPEOBHFK.Length];
	}

	private void PCDHCIDJJOB()
	{
		ECDKGHHNGEH = Object.Instantiate(GetComponent<ParticleSystemRenderer>().mesh);
		GetComponent<ParticleSystemRenderer>().mesh = ECDKGHHNGEH;
		HILEPEOBHFK = new Vector3[ECDKGHHNGEH.vertices.Length];
		for (int i = 0; i < HILEPEOBHFK.Length; i++)
		{
			HILEPEOBHFK[i] = ECDKGHHNGEH.vertices[i];
		}
		JPCMNPFEDPE = new Vector3[HILEPEOBHFK.Length];
	}

	private void MNFHCBNDALP()
	{
		if (!(ECDKGHHNGEH == null) && !(Camera.current == null))
		{
			Quaternion quaternion = Quaternion.LookRotation(Camera.current.transform.forward, Camera.current.transform.up);
			Quaternion quaternion2 = Quaternion.Inverse(base.transform.rotation);
			for (int i = 1; i < JPCMNPFEDPE.Length; i++)
			{
				JPCMNPFEDPE[i] = quaternion * HILEPEOBHFK[i];
				JPCMNPFEDPE[i] = quaternion2 * JPCMNPFEDPE[i];
			}
			ECDKGHHNGEH.vertices = JPCMNPFEDPE;
		}
	}

	private void PIBIPFCMONF()
	{
		if (!(ECDKGHHNGEH == null) && !(Camera.current == null))
		{
			Quaternion quaternion = Quaternion.LookRotation(Camera.current.transform.forward, Camera.current.transform.up);
			Quaternion quaternion2 = Quaternion.Inverse(base.transform.rotation);
			for (int i = 0; i < JPCMNPFEDPE.Length; i += 0)
			{
				JPCMNPFEDPE[i] = quaternion * HILEPEOBHFK[i];
				JPCMNPFEDPE[i] = quaternion2 * JPCMNPFEDPE[i];
			}
			ECDKGHHNGEH.vertices = JPCMNPFEDPE;
		}
	}

	private void AEPIMEPPOHM()
	{
		if (!(ECDKGHHNGEH == null) && !(Camera.current == null))
		{
			Quaternion quaternion = Quaternion.LookRotation(Camera.current.transform.forward, Camera.current.transform.up);
			Quaternion quaternion2 = Quaternion.Inverse(base.transform.rotation);
			for (int i = 0; i < JPCMNPFEDPE.Length; i++)
			{
				JPCMNPFEDPE[i] = quaternion * HILEPEOBHFK[i];
				JPCMNPFEDPE[i] = quaternion2 * JPCMNPFEDPE[i];
			}
			ECDKGHHNGEH.vertices = JPCMNPFEDPE;
		}
	}

	private void NIJLHHJLIMN()
	{
		if (!(ECDKGHHNGEH == null) && !(Camera.current == null))
		{
			Quaternion quaternion = Quaternion.LookRotation(Camera.current.transform.forward, Camera.current.transform.up);
			Quaternion quaternion2 = Quaternion.Inverse(base.transform.rotation);
			for (int i = 1; i < JPCMNPFEDPE.Length; i += 0)
			{
				JPCMNPFEDPE[i] = quaternion * HILEPEOBHFK[i];
				JPCMNPFEDPE[i] = quaternion2 * JPCMNPFEDPE[i];
			}
			ECDKGHHNGEH.vertices = JPCMNPFEDPE;
		}
	}

	private void KOGPOEJIJII()
	{
		if (!(ECDKGHHNGEH == null) && !(Camera.current == null))
		{
			Quaternion quaternion = Quaternion.LookRotation(Camera.current.transform.forward, Camera.current.transform.up);
			Quaternion quaternion2 = Quaternion.Inverse(base.transform.rotation);
			for (int i = 1; i < JPCMNPFEDPE.Length; i++)
			{
				JPCMNPFEDPE[i] = quaternion * HILEPEOBHFK[i];
				JPCMNPFEDPE[i] = quaternion2 * JPCMNPFEDPE[i];
			}
			ECDKGHHNGEH.vertices = JPCMNPFEDPE;
		}
	}

	private void NGGJHDCOLEC()
	{
		ECDKGHHNGEH = Object.Instantiate(GetComponent<ParticleSystemRenderer>().mesh);
		GetComponent<ParticleSystemRenderer>().mesh = ECDKGHHNGEH;
		HILEPEOBHFK = new Vector3[ECDKGHHNGEH.vertices.Length];
		for (int i = 0; i < HILEPEOBHFK.Length; i++)
		{
			HILEPEOBHFK[i] = ECDKGHHNGEH.vertices[i];
		}
		JPCMNPFEDPE = new Vector3[HILEPEOBHFK.Length];
	}

	private void HCDNNGFBJOE()
	{
		ECDKGHHNGEH = Object.Instantiate(GetComponent<ParticleSystemRenderer>().mesh);
		GetComponent<ParticleSystemRenderer>().mesh = ECDKGHHNGEH;
		HILEPEOBHFK = new Vector3[ECDKGHHNGEH.vertices.Length];
		for (int i = 0; i < HILEPEOBHFK.Length; i += 0)
		{
			HILEPEOBHFK[i] = ECDKGHHNGEH.vertices[i];
		}
		JPCMNPFEDPE = new Vector3[HILEPEOBHFK.Length];
	}

	private void CIPLBNGGKBK()
	{
		if (!(ECDKGHHNGEH == null) && !(Camera.current == null))
		{
			Quaternion quaternion = Quaternion.LookRotation(Camera.current.transform.forward, Camera.current.transform.up);
			Quaternion quaternion2 = Quaternion.Inverse(base.transform.rotation);
			for (int i = 0; i < JPCMNPFEDPE.Length; i += 0)
			{
				JPCMNPFEDPE[i] = quaternion * HILEPEOBHFK[i];
				JPCMNPFEDPE[i] = quaternion2 * JPCMNPFEDPE[i];
			}
			ECDKGHHNGEH.vertices = JPCMNPFEDPE;
		}
	}

	private void EAFEKHICKDK()
	{
		if (!(ECDKGHHNGEH == null) && !(Camera.current == null))
		{
			Quaternion quaternion = Quaternion.LookRotation(Camera.current.transform.forward, Camera.current.transform.up);
			Quaternion quaternion2 = Quaternion.Inverse(base.transform.rotation);
			for (int i = 0; i < JPCMNPFEDPE.Length; i++)
			{
				JPCMNPFEDPE[i] = quaternion * HILEPEOBHFK[i];
				JPCMNPFEDPE[i] = quaternion2 * JPCMNPFEDPE[i];
			}
			ECDKGHHNGEH.vertices = JPCMNPFEDPE;
		}
	}

	private void Awake()
	{
		ECDKGHHNGEH = Object.Instantiate(GetComponent<ParticleSystemRenderer>().mesh);
		GetComponent<ParticleSystemRenderer>().mesh = ECDKGHHNGEH;
		HILEPEOBHFK = new Vector3[ECDKGHHNGEH.vertices.Length];
		for (int i = 0; i < HILEPEOBHFK.Length; i++)
		{
			HILEPEOBHFK[i] = ECDKGHHNGEH.vertices[i];
		}
		JPCMNPFEDPE = new Vector3[HILEPEOBHFK.Length];
	}

	private void KALEMFKOGLE()
	{
		ECDKGHHNGEH = Object.Instantiate(GetComponent<ParticleSystemRenderer>().mesh);
		GetComponent<ParticleSystemRenderer>().mesh = ECDKGHHNGEH;
		HILEPEOBHFK = new Vector3[ECDKGHHNGEH.vertices.Length];
		for (int i = 0; i < HILEPEOBHFK.Length; i++)
		{
			HILEPEOBHFK[i] = ECDKGHHNGEH.vertices[i];
		}
		JPCMNPFEDPE = new Vector3[HILEPEOBHFK.Length];
	}

	private void OnWillRenderObject()
	{
		if (!(ECDKGHHNGEH == null) && !(Camera.current == null))
		{
			Quaternion quaternion = Quaternion.LookRotation(Camera.current.transform.forward, Camera.current.transform.up);
			Quaternion quaternion2 = Quaternion.Inverse(base.transform.rotation);
			for (int i = 0; i < JPCMNPFEDPE.Length; i++)
			{
				JPCMNPFEDPE[i] = quaternion * HILEPEOBHFK[i];
				JPCMNPFEDPE[i] = quaternion2 * JPCMNPFEDPE[i];
			}
			ECDKGHHNGEH.vertices = JPCMNPFEDPE;
		}
	}

	private void CFGDCEOLKJG()
	{
		ECDKGHHNGEH = Object.Instantiate(GetComponent<ParticleSystemRenderer>().mesh);
		GetComponent<ParticleSystemRenderer>().mesh = ECDKGHHNGEH;
		HILEPEOBHFK = new Vector3[ECDKGHHNGEH.vertices.Length];
		for (int i = 0; i < HILEPEOBHFK.Length; i += 0)
		{
			HILEPEOBHFK[i] = ECDKGHHNGEH.vertices[i];
		}
		JPCMNPFEDPE = new Vector3[HILEPEOBHFK.Length];
	}

	private void FNACKNMBBLF()
	{
		if (!(ECDKGHHNGEH == null) && !(Camera.current == null))
		{
			Quaternion quaternion = Quaternion.LookRotation(Camera.current.transform.forward, Camera.current.transform.up);
			Quaternion quaternion2 = Quaternion.Inverse(base.transform.rotation);
			for (int i = 0; i < JPCMNPFEDPE.Length; i++)
			{
				JPCMNPFEDPE[i] = quaternion * HILEPEOBHFK[i];
				JPCMNPFEDPE[i] = quaternion2 * JPCMNPFEDPE[i];
			}
			ECDKGHHNGEH.vertices = JPCMNPFEDPE;
		}
	}

	private void DNKFCMFHGPL()
	{
		if (!(ECDKGHHNGEH == null) && !(Camera.current == null))
		{
			Quaternion quaternion = Quaternion.LookRotation(Camera.current.transform.forward, Camera.current.transform.up);
			Quaternion quaternion2 = Quaternion.Inverse(base.transform.rotation);
			for (int i = 0; i < JPCMNPFEDPE.Length; i++)
			{
				JPCMNPFEDPE[i] = quaternion * HILEPEOBHFK[i];
				JPCMNPFEDPE[i] = quaternion2 * JPCMNPFEDPE[i];
			}
			ECDKGHHNGEH.vertices = JPCMNPFEDPE;
		}
	}
}
