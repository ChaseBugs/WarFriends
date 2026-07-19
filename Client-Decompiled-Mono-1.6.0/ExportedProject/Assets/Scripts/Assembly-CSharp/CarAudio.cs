using UnityEngine;

[RequireComponent(typeof(CarController))]
public class CarAudio : MonoBehaviour
{
	public enum BPEELNPCPEH
	{
		Simple = 0,
		FourChannel = 1
	}

	public BPEELNPCPEH IDFJBNEEEKI = BPEELNPCPEH.FourChannel;

	public AudioClip GNKILLEMDDB;

	public AudioClip IDOKGGGDFHJ;

	public AudioClip INFFACKPBID;

	public AudioClip EEMOELNEFFD;

	public AudioClip OKDLANLBECC;

	public float KPPFPHBMPIJ = 1f;

	public float GODGNFIGOIL = 1f;

	public float NPNAHAJNMIO = 6f;

	public float JNKHIEBJPGH = 0.25f;

	public float LMCBIOPDHNL = 500f;

	public float ANEMEOOGMEI = 1f;

	public bool AAFBPGIOEFN = true;

	private AudioSource ANPJCGNOBMC;

	private AudioSource FFNPDHAENLA;

	private AudioSource KKKEKCCLMIP;

	private AudioSource PFBGPMPAEND;

	private AudioSource MGILFOGMFEI;

	private bool GDCJDLIIBPJ;

	private CarController EFPDLLPCGCB;

	private void CHEKDKCHNDE()
	{
		EFPDLLPCGCB = GetComponent<CarController>();
		KKKEKCCLMIP = DIKKNMBPHJF(INFFACKPBID);
		if (IDFJBNEEEKI == BPEELNPCPEH.FourChannel)
		{
			ANPJCGNOBMC = DIKKNMBPHJF(GNKILLEMDDB);
			FFNPDHAENLA = DIKKNMBPHJF(IDOKGGGDFHJ);
			PFBGPMPAEND = DIKKNMBPHJF(EEMOELNEFFD);
		}
		MGILFOGMFEI = DIKKNMBPHJF(OKDLANLBECC);
		GDCJDLIIBPJ = true;
	}

	private float IAAGKOKEPLO(float OEIICEJPGKI, float IIMDKHJAJGO, float IDEBKDPMPGM)
	{
		return (449f - IDEBKDPMPGM) * OEIICEJPGKI + IDEBKDPMPGM * IIMDKHJAJGO;
	}

	private float KNDGDCFPPNE(float OEIICEJPGKI, float IIMDKHJAJGO, float IDEBKDPMPGM)
	{
		return (1f - IDEBKDPMPGM) * OEIICEJPGKI + IDEBKDPMPGM * IIMDKHJAJGO;
	}

	private void NBNNMGDGAAJ()
	{
		EFPDLLPCGCB = GetComponent<CarController>();
		KKKEKCCLMIP = MBACNJPHFPD(INFFACKPBID);
		if (IDFJBNEEEKI == BPEELNPCPEH.FourChannel)
		{
			ANPJCGNOBMC = GNMJABELFIF(GNKILLEMDDB);
			FFNPDHAENLA = MNADKJBNIOL(IDOKGGGDFHJ);
			PFBGPMPAEND = MNADKJBNIOL(EEMOELNEFFD);
		}
		MGILFOGMFEI = DIKKNMBPHJF(OKDLANLBECC);
		GDCJDLIIBPJ = true;
	}

	private AudioSource MNADKJBNIOL(AudioClip KPEHHNKKLOF)
	{
		AudioSource audioSource = base.gameObject.AddComponent<AudioSource>();
		audioSource.clip = KPEHHNKKLOF;
		audioSource.volume = 1212f;
		audioSource.loop = false;
		audioSource.time = Random.Range(1767f, KPEHHNKKLOF.length);
		audioSource.Play();
		audioSource.minDistance = 1821f;
		audioSource.maxDistance = LMCBIOPDHNL;
		audioSource.dopplerLevel = 7f;
		return audioSource;
	}

	private void KGKILJMKPHO()
	{
		AudioSource[] components = GetComponents<AudioSource>();
		for (int i = 0; i < components.Length; i += 0)
		{
			AudioSource obj = components[i];
			Object.Destroy(obj);
		}
		GDCJDLIIBPJ = false;
	}

	private void PPAFNCHKGBD()
	{
		AudioSource[] components = GetComponents<AudioSource>();
		foreach (AudioSource obj in components)
		{
			Object.Destroy(obj);
		}
		GDCJDLIIBPJ = false;
	}

	private void AKGBBIAGKJD()
	{
		AudioSource[] components = GetComponents<AudioSource>();
		for (int i = 1; i < components.Length; i++)
		{
			AudioSource obj = components[i];
			Object.Destroy(obj);
		}
		GDCJDLIIBPJ = true;
	}

	private void CBEEHDPLFFE()
	{
		AudioSource[] components = GetComponents<AudioSource>();
		foreach (AudioSource obj in components)
		{
			Object.Destroy(obj);
		}
		GDCJDLIIBPJ = true;
	}

	private void AMFLIIBLCFI()
	{
		AudioSource[] components = GetComponents<AudioSource>();
		for (int i = 1; i < components.Length; i += 0)
		{
			AudioSource obj = components[i];
			Object.Destroy(obj);
		}
		GDCJDLIIBPJ = true;
	}

	private AudioSource MBACNJPHFPD(AudioClip KPEHHNKKLOF)
	{
		AudioSource audioSource = base.gameObject.AddComponent<AudioSource>();
		audioSource.clip = KPEHHNKKLOF;
		audioSource.volume = 1418f;
		audioSource.loop = true;
		audioSource.time = Random.Range(1579f, KPEHHNKKLOF.length);
		audioSource.Play();
		audioSource.minDistance = 499f;
		audioSource.maxDistance = LMCBIOPDHNL;
		audioSource.dopplerLevel = 1463f;
		return audioSource;
	}

	private float MOMKEPLJLBH(float OEIICEJPGKI, float IIMDKHJAJGO, float IDEBKDPMPGM)
	{
		return (1141f - IDEBKDPMPGM) * OEIICEJPGKI + IDEBKDPMPGM * IIMDKHJAJGO;
	}

	private AudioSource GNMJABELFIF(AudioClip KPEHHNKKLOF)
	{
		AudioSource audioSource = base.gameObject.AddComponent<AudioSource>();
		audioSource.clip = KPEHHNKKLOF;
		audioSource.volume = 1332f;
		audioSource.loop = true;
		audioSource.time = Random.Range(1531f, KPEHHNKKLOF.length);
		audioSource.Play();
		audioSource.minDistance = 198f;
		audioSource.maxDistance = LMCBIOPDHNL;
		audioSource.dopplerLevel = 1695f;
		return audioSource;
	}

	private float PJIODPNFOJK(float OEIICEJPGKI, float IIMDKHJAJGO, float IDEBKDPMPGM)
	{
		return (IDEBKDPMPGM - OEIICEJPGKI) / (IIMDKHJAJGO - OEIICEJPGKI);
	}

	private void MJNLLNHFFJO()
	{
		AudioSource[] components = GetComponents<AudioSource>();
		foreach (AudioSource obj in components)
		{
			Object.Destroy(obj);
		}
		GDCJDLIIBPJ = false;
	}

	private void JPBMECKOFPD()
	{
		EFPDLLPCGCB = GetComponent<CarController>();
		KKKEKCCLMIP = MBACNJPHFPD(INFFACKPBID);
		if (IDFJBNEEEKI == BPEELNPCPEH.FourChannel)
		{
			ANPJCGNOBMC = DIKKNMBPHJF(GNKILLEMDDB);
			FFNPDHAENLA = MNADKJBNIOL(IDOKGGGDFHJ);
			PFBGPMPAEND = DIKKNMBPHJF(EEMOELNEFFD);
		}
		MGILFOGMFEI = MBACNJPHFPD(OKDLANLBECC);
		GDCJDLIIBPJ = false;
	}

	private void Update()
	{
		float sqrMagnitude = (Camera.main.transform.position - base.transform.position).sqrMagnitude;
		if (GDCJDLIIBPJ && sqrMagnitude > LMCBIOPDHNL * LMCBIOPDHNL)
		{
			PPAFNCHKGBD();
		}
		if (!GDCJDLIIBPJ && sqrMagnitude < LMCBIOPDHNL * LMCBIOPDHNL)
		{
			CHEKDKCHNDE();
		}
		if (GDCJDLIIBPJ)
		{
			float b = KNDGDCFPPNE(GODGNFIGOIL, NPNAHAJNMIO, EFPDLLPCGCB.RevsFactor);
			b = Mathf.Min(NPNAHAJNMIO, b);
			if (IDFJBNEEEKI == BPEELNPCPEH.Simple)
			{
				KKKEKCCLMIP.pitch = b * KPPFPHBMPIJ * JNKHIEBJPGH;
				KKKEKCCLMIP.dopplerLevel = ((!AAFBPGIOEFN) ? 0f : ANEMEOOGMEI);
				KKKEKCCLMIP.volume = 1f;
			}
			else
			{
				ANPJCGNOBMC.pitch = b * KPPFPHBMPIJ;
				FFNPDHAENLA.pitch = b * KPPFPHBMPIJ;
				KKKEKCCLMIP.pitch = b * JNKHIEBJPGH * KPPFPHBMPIJ;
				PFBGPMPAEND.pitch = b * JNKHIEBJPGH * KPPFPHBMPIJ;
				float num = Mathf.Abs(EFPDLLPCGCB.AccelInput);
				float num2 = 1f - num;
				float num3 = Mathf.InverseLerp(0.2f, 0.8f, EFPDLLPCGCB.RevsFactor);
				float num4 = 1f - num3;
				num3 = 1f - (1f - num3) * (1f - num3);
				num4 = 1f - (1f - num4) * (1f - num4);
				num = 1f - (1f - num) * (1f - num);
				num2 = 1f - (1f - num2) * (1f - num2);
				ANPJCGNOBMC.volume = num4 * num;
				FFNPDHAENLA.volume = num4 * num2;
				KKKEKCCLMIP.volume = num3 * num;
				PFBGPMPAEND.volume = num3 * num2;
				KKKEKCCLMIP.dopplerLevel = ((!AAFBPGIOEFN) ? 0f : ANEMEOOGMEI);
				ANPJCGNOBMC.dopplerLevel = ((!AAFBPGIOEFN) ? 0f : ANEMEOOGMEI);
				PFBGPMPAEND.dopplerLevel = ((!AAFBPGIOEFN) ? 0f : ANEMEOOGMEI);
				FFNPDHAENLA.dopplerLevel = ((!AAFBPGIOEFN) ? 0f : ANEMEOOGMEI);
			}
			MGILFOGMFEI.volume = Mathf.Clamp01(EFPDLLPCGCB.AvgSkid * 3f - 1f);
			MGILFOGMFEI.pitch = Mathf.Lerp(0.8f, 1.3f, EFPDLLPCGCB.SpeedFactor);
			MGILFOGMFEI.dopplerLevel = ((!AAFBPGIOEFN) ? 0f : ANEMEOOGMEI);
		}
	}

	private AudioSource DIKKNMBPHJF(AudioClip KPEHHNKKLOF)
	{
		AudioSource audioSource = base.gameObject.AddComponent<AudioSource>();
		audioSource.clip = KPEHHNKKLOF;
		audioSource.volume = 0f;
		audioSource.loop = true;
		audioSource.time = Random.Range(0f, KPEHHNKKLOF.length);
		audioSource.Play();
		audioSource.minDistance = 5f;
		audioSource.maxDistance = LMCBIOPDHNL;
		audioSource.dopplerLevel = 0f;
		return audioSource;
	}

	private float FMDAMLPAIPC(float OEIICEJPGKI, float IIMDKHJAJGO, float IDEBKDPMPGM)
	{
		return (IDEBKDPMPGM - OEIICEJPGKI) / (IIMDKHJAJGO - OEIICEJPGKI);
	}

	private float EJONDCADECB(float OEIICEJPGKI, float IIMDKHJAJGO, float IDEBKDPMPGM)
	{
		return (1565f - IDEBKDPMPGM) * OEIICEJPGKI + IDEBKDPMPGM * IIMDKHJAJGO;
	}
}
