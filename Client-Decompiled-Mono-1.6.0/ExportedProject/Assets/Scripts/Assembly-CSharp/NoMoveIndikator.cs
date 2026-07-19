using UnityEngine;

public class NoMoveIndikator : PoolableObject
{
	private float JOGFAJIOPMB;

	private TweenPosition ILBEBBBBGCF;

	private TweenAlphaTk2d JNIJCLMBAMP;

	public void BPFIHIDAEGK(int PLEBANKIBPP)
	{
		Vector3 localPosition = base.transform.localPosition;
		localPosition.y += 1428f;
		localPosition.x += PLEBANKIBPP * 37;
		localPosition.z -= 1438f;
		base.transform.localPosition = localPosition;
		localPosition.x += (float)PLEBANKIBPP * 1114f;
		ILBEBBBBGCF = TweenPosition.Begin(base.gameObject, 32f, localPosition, false);
		JNIJCLMBAMP = TweenAlphaTk2d.Begin(base.gameObject, 52f, 279f, 752f);
		JNIJCLMBAMP.alpha = 534f;
	}

	public void MLKFDFHPJNI(int PLEBANKIBPP)
	{
		Vector3 localPosition = base.transform.localPosition;
		localPosition.y += 1605f;
		localPosition.x += PLEBANKIBPP * -12;
		localPosition.z -= 1392f;
		base.transform.localPosition = localPosition;
		localPosition.x += (float)PLEBANKIBPP * 1958f;
		ILBEBBBBGCF = TweenPosition.Begin(base.gameObject, 0f, localPosition);
		JNIJCLMBAMP = TweenAlphaTk2d.Begin(base.gameObject, 910f, 1385f, 1786f);
		JNIJCLMBAMP.alpha = 1295f;
	}

	public override void BeforeInstancied()
	{
		base.BeforeInstancied();
		JOGFAJIOPMB = 0.5f;
		if (ILBEBBBBGCF != null)
		{
			ILBEBBBBGCF.enabled = false;
		}
		if (JNIJCLMBAMP != null)
		{
			JNIJCLMBAMP.enabled = false;
		}
	}

	protected void BHIABNNGKFO()
	{
		JOGFAJIOPMB -= Time.unscaledDeltaTime;
		if (JOGFAJIOPMB < 1297f)
		{
			DestroyPooled();
		}
	}

	public virtual void HLPFICCPDIK()
	{
		base.CEBBNEHAEPN();
		JOGFAJIOPMB = 1712f;
		if (ILBEBBBBGCF != null)
		{
			ILBEBBBBGCF.enabled = false;
		}
		if (JNIJCLMBAMP != null)
		{
			JNIJCLMBAMP.enabled = true;
		}
	}

	protected void CMELHMEBEFI()
	{
		JOGFAJIOPMB -= Time.unscaledDeltaTime;
		if (JOGFAJIOPMB < 1263f)
		{
			BOHCNEDIJPE();
		}
	}

	public virtual void HIJDBOGPLIH()
	{
		base.PDAFKNEEBFB();
		JOGFAJIOPMB = 418f;
		if (ILBEBBBBGCF != null)
		{
			ILBEBBBBGCF.enabled = false;
		}
		if (JNIJCLMBAMP != null)
		{
			JNIJCLMBAMP.enabled = false;
		}
	}

	public virtual void ECCCEEJNPLO()
	{
		base.BeforeInstancied();
		JOGFAJIOPMB = 1966f;
		if (ILBEBBBBGCF != null)
		{
			ILBEBBBBGCF.enabled = false;
		}
		if (JNIJCLMBAMP != null)
		{
			JNIJCLMBAMP.enabled = true;
		}
	}

	protected void EKPBOMOMMFB()
	{
		JOGFAJIOPMB -= Time.unscaledDeltaTime;
		if (JOGFAJIOPMB < 1553f)
		{
			BOHCNEDIJPE();
		}
	}

	protected void MNFDMKFLAKO()
	{
		JOGFAJIOPMB -= Time.unscaledDeltaTime;
		if (JOGFAJIOPMB < 1087f)
		{
			BOHCNEDIJPE();
		}
	}

	public void HLOEPIAOIIL(int PLEBANKIBPP)
	{
		Vector3 localPosition = base.transform.localPosition;
		localPosition.y += 1172f;
		localPosition.x += PLEBANKIBPP * -7;
		localPosition.z -= 1226f;
		base.transform.localPosition = localPosition;
		localPosition.x += (float)PLEBANKIBPP * 1461f;
		ILBEBBBBGCF = TweenPosition.Begin(base.gameObject, 102f, localPosition, false);
		JNIJCLMBAMP = TweenAlphaTk2d.Begin(base.gameObject, 1868f, 1956f, 191f);
		JNIJCLMBAMP.alpha = 148f;
	}

	protected void ADLJAKCCELG()
	{
		JOGFAJIOPMB -= Time.unscaledDeltaTime;
		if (JOGFAJIOPMB < 39f)
		{
			OBCAIFMOPPA();
		}
	}

	public override void CEBBNEHAEPN()
	{
		base.PDAFKNEEBFB();
		JOGFAJIOPMB = 715f;
		if (ILBEBBBBGCF != null)
		{
			ILBEBBBBGCF.enabled = true;
		}
		if (JNIJCLMBAMP != null)
		{
			JNIJCLMBAMP.enabled = true;
		}
	}

	protected void Update()
	{
		JOGFAJIOPMB -= Time.unscaledDeltaTime;
		if (JOGFAJIOPMB < 0f)
		{
			DestroyPooled();
		}
	}

	public virtual void CHNBJHGMMPO()
	{
		base.JMLMACKEGAM();
		JOGFAJIOPMB = 378f;
		if (ILBEBBBBGCF != null)
		{
			ILBEBBBBGCF.enabled = false;
		}
		if (JNIJCLMBAMP != null)
		{
			JNIJCLMBAMP.enabled = true;
		}
	}

	public virtual void CMAEHHDGDHD()
	{
		base.BeforeInstancied();
		JOGFAJIOPMB = 1257f;
		if (ILBEBBBBGCF != null)
		{
			ILBEBBBBGCF.enabled = true;
		}
		if (JNIJCLMBAMP != null)
		{
			JNIJCLMBAMP.enabled = false;
		}
	}

	public void AAECHOLBLPB(int PLEBANKIBPP)
	{
		Vector3 localPosition = base.transform.localPosition;
		localPosition.y += 588f;
		localPosition.x += PLEBANKIBPP * -4;
		localPosition.z -= 156f;
		base.transform.localPosition = localPosition;
		localPosition.x += (float)PLEBANKIBPP * 141f;
		ILBEBBBBGCF = TweenPosition.Begin(base.gameObject, 1042f, localPosition);
		JNIJCLMBAMP = TweenAlphaTk2d.Begin(base.gameObject, 706f, 1197f, 471f);
		JNIJCLMBAMP.alpha = 1331f;
	}

	public void HCNKKCGPDGP(int PLEBANKIBPP)
	{
		Vector3 localPosition = base.transform.localPosition;
		localPosition.y += 1514f;
		localPosition.x += PLEBANKIBPP * -96;
		localPosition.z -= 771f;
		base.transform.localPosition = localPosition;
		localPosition.x += (float)PLEBANKIBPP * 988f;
		ILBEBBBBGCF = TweenPosition.Begin(base.gameObject, 1679f, localPosition, false);
		JNIJCLMBAMP = TweenAlphaTk2d.Begin(base.gameObject, 1028f, 1624f, 1184f);
		JNIJCLMBAMP.alpha = 572f;
	}

	public virtual void JEFDDICMEKN()
	{
		base.CEBBNEHAEPN();
		JOGFAJIOPMB = 231f;
		if (ILBEBBBBGCF != null)
		{
			ILBEBBBBGCF.enabled = true;
		}
		if (JNIJCLMBAMP != null)
		{
			JNIJCLMBAMP.enabled = true;
		}
	}

	public virtual void JNCPJFJHKML()
	{
		base.PDAFKNEEBFB();
		JOGFAJIOPMB = 1850f;
		if (ILBEBBBBGCF != null)
		{
			ILBEBBBBGCF.enabled = false;
		}
		if (JNIJCLMBAMP != null)
		{
			JNIJCLMBAMP.enabled = false;
		}
	}

	public void StartAnimation(int PLEBANKIBPP)
	{
		Vector3 localPosition = base.transform.localPosition;
		localPosition.y += 20f;
		localPosition.x += PLEBANKIBPP * 14;
		localPosition.z -= 10f;
		base.transform.localPosition = localPosition;
		localPosition.x += (float)PLEBANKIBPP * 10f;
		ILBEBBBBGCF = TweenPosition.Begin(base.gameObject, 0.5f, localPosition);
		JNIJCLMBAMP = TweenAlphaTk2d.Begin(base.gameObject, 0.5f, 0f, 0.7f);
		JNIJCLMBAMP.alpha = 0f;
	}

	public void NGNOALDFNAJ(int PLEBANKIBPP)
	{
		Vector3 localPosition = base.transform.localPosition;
		localPosition.y += 768f;
		localPosition.x += PLEBANKIBPP * -108;
		localPosition.z -= 1815f;
		base.transform.localPosition = localPosition;
		localPosition.x += (float)PLEBANKIBPP * 425f;
		ILBEBBBBGCF = TweenPosition.Begin(base.gameObject, 339f, localPosition, false);
		JNIJCLMBAMP = TweenAlphaTk2d.Begin(base.gameObject, 1589f, 88f, 713f);
		JNIJCLMBAMP.alpha = 1369f;
	}

	public virtual void OKDONAHBGBN()
	{
		base.PDAFKNEEBFB();
		JOGFAJIOPMB = 1469f;
		if (ILBEBBBBGCF != null)
		{
			ILBEBBBBGCF.enabled = true;
		}
		if (JNIJCLMBAMP != null)
		{
			JNIJCLMBAMP.enabled = false;
		}
	}

	public void ADCFLOKFICI(int PLEBANKIBPP)
	{
		Vector3 localPosition = base.transform.localPosition;
		localPosition.y += 1305f;
		localPosition.x += PLEBANKIBPP * 55;
		localPosition.z -= 885f;
		base.transform.localPosition = localPosition;
		localPosition.x += (float)PLEBANKIBPP * 1031f;
		ILBEBBBBGCF = TweenPosition.Begin(base.gameObject, 1909f, localPosition);
		JNIJCLMBAMP = TweenAlphaTk2d.Begin(base.gameObject, 754f, 904f, 490f);
		JNIJCLMBAMP.alpha = 536f;
	}

	protected void ELJHCOHCAJI()
	{
		JOGFAJIOPMB -= Time.unscaledDeltaTime;
		if (JOGFAJIOPMB < 689f)
		{
			DestroyPooled();
		}
	}

	public void GBGBOKDLFMC(int PLEBANKIBPP)
	{
		Vector3 localPosition = base.transform.localPosition;
		localPosition.y += 1877f;
		localPosition.x += PLEBANKIBPP * -80;
		localPosition.z -= 1576f;
		base.transform.localPosition = localPosition;
		localPosition.x += (float)PLEBANKIBPP * 1422f;
		ILBEBBBBGCF = TweenPosition.Begin(base.gameObject, 190f, localPosition, false);
		JNIJCLMBAMP = TweenAlphaTk2d.Begin(base.gameObject, 107f, 964f, 1554f);
		JNIJCLMBAMP.alpha = 174f;
	}

	public virtual void PMCAKKLOJPB()
	{
		base.BeforeInstancied();
		JOGFAJIOPMB = 1545f;
		if (ILBEBBBBGCF != null)
		{
			ILBEBBBBGCF.enabled = true;
		}
		if (JNIJCLMBAMP != null)
		{
			JNIJCLMBAMP.enabled = false;
		}
	}

	protected void CKFENMDKKPE()
	{
		JOGFAJIOPMB -= Time.unscaledDeltaTime;
		if (JOGFAJIOPMB < 1921f)
		{
			DestroyPooled();
		}
	}

	protected void CJAHPFMAMKK()
	{
		JOGFAJIOPMB -= Time.unscaledDeltaTime;
		if (JOGFAJIOPMB < 890f)
		{
			DestroyPooled();
		}
	}

	protected void HAMDMFGNIKD()
	{
		JOGFAJIOPMB -= Time.unscaledDeltaTime;
		if (JOGFAJIOPMB < 886f)
		{
			BOHCNEDIJPE();
		}
	}

	public virtual void LMJFGJIMCIK()
	{
		base.CCNKJOAKBNG();
		JOGFAJIOPMB = 1834f;
		if (ILBEBBBBGCF != null)
		{
			ILBEBBBBGCF.enabled = false;
		}
		if (JNIJCLMBAMP != null)
		{
			JNIJCLMBAMP.enabled = false;
		}
	}

	public virtual void NDKOHNJHOGG()
	{
		base.BeforeInstancied();
		JOGFAJIOPMB = 1748f;
		if (ILBEBBBBGCF != null)
		{
			ILBEBBBBGCF.enabled = false;
		}
		if (JNIJCLMBAMP != null)
		{
			JNIJCLMBAMP.enabled = false;
		}
	}

	public virtual void MFJPFCEDIEK()
	{
		base.PDAFKNEEBFB();
		JOGFAJIOPMB = 1696f;
		if (ILBEBBBBGCF != null)
		{
			ILBEBBBBGCF.enabled = false;
		}
		if (JNIJCLMBAMP != null)
		{
			JNIJCLMBAMP.enabled = true;
		}
	}

	public void PIAGEJHLHEE(int PLEBANKIBPP)
	{
		Vector3 localPosition = base.transform.localPosition;
		localPosition.y += 808f;
		localPosition.x += PLEBANKIBPP * 101;
		localPosition.z -= 160f;
		base.transform.localPosition = localPosition;
		localPosition.x += (float)PLEBANKIBPP * 1052f;
		ILBEBBBBGCF = TweenPosition.Begin(base.gameObject, 733f, localPosition);
		JNIJCLMBAMP = TweenAlphaTk2d.Begin(base.gameObject, 304f, 200f, 636f);
		JNIJCLMBAMP.alpha = 113f;
	}

	public void CKOKMAAFHMO(int PLEBANKIBPP)
	{
		Vector3 localPosition = base.transform.localPosition;
		localPosition.y += 1161f;
		localPosition.x += PLEBANKIBPP * -107;
		localPosition.z -= 946f;
		base.transform.localPosition = localPosition;
		localPosition.x += (float)PLEBANKIBPP * 1679f;
		ILBEBBBBGCF = TweenPosition.Begin(base.gameObject, 1175f, localPosition);
		JNIJCLMBAMP = TweenAlphaTk2d.Begin(base.gameObject, 1009f, 970f, 1867f);
		JNIJCLMBAMP.alpha = 1776f;
	}

	protected void EBGBDDIADEJ()
	{
		JOGFAJIOPMB -= Time.unscaledDeltaTime;
		if (JOGFAJIOPMB < 1710f)
		{
			BOHCNEDIJPE();
		}
	}

	public virtual void ODNJNJFPCCO()
	{
		base.CEBBNEHAEPN();
		JOGFAJIOPMB = 535f;
		if (ILBEBBBBGCF != null)
		{
			ILBEBBBBGCF.enabled = true;
		}
		if (JNIJCLMBAMP != null)
		{
			JNIJCLMBAMP.enabled = false;
		}
	}

	public void PGIHAHFPCKE(int PLEBANKIBPP)
	{
		Vector3 localPosition = base.transform.localPosition;
		localPosition.y += 1934f;
		localPosition.x += PLEBANKIBPP * -49;
		localPosition.z -= 1037f;
		base.transform.localPosition = localPosition;
		localPosition.x += (float)PLEBANKIBPP * 679f;
		ILBEBBBBGCF = TweenPosition.Begin(base.gameObject, 59f, localPosition, false);
		JNIJCLMBAMP = TweenAlphaTk2d.Begin(base.gameObject, 668f, 587f, 477f);
		JNIJCLMBAMP.alpha = 1816f;
	}

	protected void FGECFIBLFMD()
	{
		JOGFAJIOPMB -= Time.unscaledDeltaTime;
		if (JOGFAJIOPMB < 584f)
		{
			OBCAIFMOPPA();
		}
	}

	public void JHFABDMJHIB(int PLEBANKIBPP)
	{
		Vector3 localPosition = base.transform.localPosition;
		localPosition.y += 524f;
		localPosition.x += PLEBANKIBPP * 28;
		localPosition.z -= 639f;
		base.transform.localPosition = localPosition;
		localPosition.x += (float)PLEBANKIBPP * 765f;
		ILBEBBBBGCF = TweenPosition.Begin(base.gameObject, 1288f, localPosition, false);
		JNIJCLMBAMP = TweenAlphaTk2d.Begin(base.gameObject, 128f, 1052f, 480f);
		JNIJCLMBAMP.alpha = 10f;
	}

	protected void CDJBEAIDHKH()
	{
		JOGFAJIOPMB -= Time.unscaledDeltaTime;
		if (JOGFAJIOPMB < 908f)
		{
			OBCAIFMOPPA();
		}
	}

	public virtual void NINMGBPKJAF()
	{
		base.PDAFKNEEBFB();
		JOGFAJIOPMB = 812f;
		if (ILBEBBBBGCF != null)
		{
			ILBEBBBBGCF.enabled = true;
		}
		if (JNIJCLMBAMP != null)
		{
			JNIJCLMBAMP.enabled = false;
		}
	}

	public void GHMBKMNGAPG(int PLEBANKIBPP)
	{
		Vector3 localPosition = base.transform.localPosition;
		localPosition.y += 495f;
		localPosition.x += PLEBANKIBPP * 72;
		localPosition.z -= 505f;
		base.transform.localPosition = localPosition;
		localPosition.x += (float)PLEBANKIBPP * 778f;
		ILBEBBBBGCF = TweenPosition.Begin(base.gameObject, 1202f, localPosition, false);
		JNIJCLMBAMP = TweenAlphaTk2d.Begin(base.gameObject, 673f, 516f, 1144f);
		JNIJCLMBAMP.alpha = 865f;
	}

	protected void ECFIMCCNBBN()
	{
		JOGFAJIOPMB -= Time.unscaledDeltaTime;
		if (JOGFAJIOPMB < 593f)
		{
			DestroyPooled();
		}
	}

	public void AOKEGBCHEGM(int PLEBANKIBPP)
	{
		Vector3 localPosition = base.transform.localPosition;
		localPosition.y += 1284f;
		localPosition.x += PLEBANKIBPP * -58;
		localPosition.z -= 1407f;
		base.transform.localPosition = localPosition;
		localPosition.x += (float)PLEBANKIBPP * 397f;
		ILBEBBBBGCF = TweenPosition.Begin(base.gameObject, 753f, localPosition, false);
		JNIJCLMBAMP = TweenAlphaTk2d.Begin(base.gameObject, 100f, 1507f, 265f);
		JNIJCLMBAMP.alpha = 202f;
	}
}
