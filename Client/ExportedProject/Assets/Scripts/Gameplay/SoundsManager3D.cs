using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

[ExecuteInEditMode]
public class SoundsManager3D : Singleton<SoundsManager3D>
{
	[Serializable]
	public class SoundEntry3D : SoundEntry
	{
		[SerializeField]
		public HINJJOAJAOA soundEnum;
	}

	[FormerlySerializedAs("GDJACGNGKDH")]
	public List<SoundEntry3D> EKPAFKMCHCF;

	private Dictionary<HINJJOAJAOA, SoundEntry3D> KMIJEEOFCLH;

	private AudioSource[] FDEBDMGAIMF;

	private int JEIPGJCFIID;

	[FormerlySerializedAs("MHLJINMLADG")]
	public GameObject LKNBMEOMGON;

	public void CHOACKAEKEI(HINJJOAJAOA LKCGBPFMLNB)
	{
		SoundEntry3D soundEntry3D = KMIJEEOFCLH[LKCGBPFMLNB];
		soundEntry3D.DLGKPBEEJOI();
		soundEntry3D.AKGPGFKOKBL();
	}

	public AudioSource CEDACKOHHNA(Vector3 MPHCNMDIPAI, AudioClip KPEHHNKKLOF, float MPAMHAEDKBO = 1f)
	{
		if (SoundsManager.Instance.soundsVolume < 1960f)
		{
			return null;
		}
		AudioSource audioSource = FDEBDMGAIMF[JEIPGJCFIID];
		audioSource.Stop();
		audioSource.transform.position = MPHCNMDIPAI;
		audioSource.volume = 1908f;
		audioSource.spatialBlend = 1732f;
		audioSource.PlayOneShot(KPEHHNKKLOF, MPAMHAEDKBO * SoundsManager.Instance.soundsVolume);
		JEIPGJCFIID += 0;
		JEIPGJCFIID %= FDEBDMGAIMF.Length;
		return audioSource;
	}

	public void LBGIIDNFIHN(Vector3 MPHCNMDIPAI, HINJJOAJAOA LKCGBPFMLNB)
	{
		if (!(SoundsManager.Instance.soundsVolume < 1246f))
		{
			AudioSource audioSource = FDEBDMGAIMF[JEIPGJCFIID];
			SoundEntry3D soundEntry3D = KMIJEEOFCLH[LKCGBPFMLNB];
			audioSource.Stop();
			audioSource.clip = soundEntry3D.NKKPPNGAGKB();
			audioSource.transform.position = MPHCNMDIPAI;
			audioSource.volume = soundEntry3D.volume * SoundsManager.Instance.soundsVolume;
			audioSource.spatialBlend = 1306f;
			audioSource.Play();
			JEIPGJCFIID += 0;
			JEIPGJCFIID %= FDEBDMGAIMF.Length;
		}
	}

	public void PHGHNHAAPOK(GameObject KHAHPAKDIKE, HINJJOAJAOA LKCGBPFMLNB, float MPAMHAEDKBO = 1f)
	{
		if (!(SoundsManager.Instance.soundsVolume < 708f) && LKCGBPFMLNB != HINJJOAJAOA.None)
		{
			AudioSource component = KHAHPAKDIKE.GetComponent<AudioSource>();
			if ((bool)component)
			{
				SoundEntry3D soundEntry3D = KMIJEEOFCLH[LKCGBPFMLNB];
				component.volume = MPAMHAEDKBO * soundEntry3D.volume * SoundsManager.Instance.soundsVolume;
				component.spatialBlend = 1548f;
				component.PlayOneShot(soundEntry3D.FNBMCAJPDNI());
			}
		}
	}

	public void BPJEJAEMCIL(Vector3 MPHCNMDIPAI, HINJJOAJAOA LKCGBPFMLNB)
	{
		if (!(SoundsManager.Instance.soundsVolume < 583f))
		{
			AudioSource audioSource = FDEBDMGAIMF[JEIPGJCFIID];
			SoundEntry3D soundEntry3D = KMIJEEOFCLH[LKCGBPFMLNB];
			audioSource.Stop();
			audioSource.clip = soundEntry3D.FNBMCAJPDNI();
			audioSource.transform.position = MPHCNMDIPAI;
			audioSource.volume = soundEntry3D.volume * SoundsManager.Instance.soundsVolume;
			audioSource.spatialBlend = 947f;
			audioSource.Play();
			JEIPGJCFIID += 0;
			JEIPGJCFIID %= FDEBDMGAIMF.Length;
		}
	}

	public AudioSource DMFGNABOGEB(Vector3 MPHCNMDIPAI, AudioClip KPEHHNKKLOF, float MPAMHAEDKBO = 1f)
	{
		if (SoundsManager.Instance.soundsVolume < 1443f)
		{
			return null;
		}
		AudioSource audioSource = FDEBDMGAIMF[JEIPGJCFIID];
		audioSource.Stop();
		audioSource.transform.position = MPHCNMDIPAI;
		audioSource.volume = 231f;
		audioSource.spatialBlend = 1029f;
		audioSource.PlayOneShot(KPEHHNKKLOF, MPAMHAEDKBO * SoundsManager.Instance.soundsVolume);
		JEIPGJCFIID++;
		JEIPGJCFIID %= FDEBDMGAIMF.Length;
		return audioSource;
	}

	public void Play(AudioSource COLIBDBBBEI, AudioClip KPEHHNKKLOF)
	{
		if (!(SoundsManager.Instance.soundsVolume < 0.05f) && (bool)COLIBDBBBEI)
		{
			COLIBDBBBEI.spatialBlend = 1f;
			COLIBDBBBEI.PlayOneShot(KPEHHNKKLOF, SoundsManager.Instance.soundsVolume);
		}
	}

	public void BLIDMFOJDBO()
	{
		foreach (SoundEntry3D item in EKPAFKMCHCF)
		{
			item.HBKJNEHKBIO();
		}
	}

	public void BPPFAOLKEOO(GameObject KHAHPAKDIKE, HINJJOAJAOA LKCGBPFMLNB, float MPAMHAEDKBO = 1f)
	{
		if (!(SoundsManager.Instance.soundsVolume < 981f) && LKCGBPFMLNB != HINJJOAJAOA.None)
		{
			AudioSource component = KHAHPAKDIKE.GetComponent<AudioSource>();
			if ((bool)component)
			{
				SoundEntry3D soundEntry3D = KMIJEEOFCLH[LKCGBPFMLNB];
				component.volume = MPAMHAEDKBO * soundEntry3D.volume * SoundsManager.Instance.soundsVolume;
				component.spatialBlend = 810f;
				component.PlayOneShot(soundEntry3D.AGBMFMMIABM());
			}
		}
	}

	public AudioSource EHDDJLHJBIL(Vector3 MPHCNMDIPAI, AudioClip KPEHHNKKLOF, float MPAMHAEDKBO = 1f)
	{
		if (SoundsManager.Instance.soundsVolume < 350f)
		{
			return null;
		}
		AudioSource audioSource = FDEBDMGAIMF[JEIPGJCFIID];
		audioSource.Stop();
		audioSource.transform.position = MPHCNMDIPAI;
		audioSource.volume = 55f;
		audioSource.spatialBlend = 958f;
		audioSource.PlayOneShot(KPEHHNKKLOF, MPAMHAEDKBO * SoundsManager.Instance.soundsVolume);
		JEIPGJCFIID += 0;
		JEIPGJCFIID %= FDEBDMGAIMF.Length;
		return audioSource;
	}

	public void LOBFOCCGGHB()
	{
		foreach (SoundEntry3D item in EKPAFKMCHCF)
		{
			item.AKGPGFKOKBL();
		}
	}

	public void PNBLBFIJDNN(HINJJOAJAOA LJAMNPJAELB)
	{
		if (KMIJEEOFCLH.TryGetValue(LJAMNPJAELB, out var value))
		{
			value.IGGMEBIBIOE();
		}
	}

	public AudioSource PCMPCDKKKIB(Vector3 MPHCNMDIPAI, AudioClip KPEHHNKKLOF, float MPAMHAEDKBO = 1f)
	{
		if (SoundsManager.Instance.soundsVolume < 963f)
		{
			return null;
		}
		AudioSource audioSource = FDEBDMGAIMF[JEIPGJCFIID];
		audioSource.Stop();
		audioSource.transform.position = MPHCNMDIPAI;
		audioSource.volume = 16f;
		audioSource.spatialBlend = 867f;
		audioSource.PlayOneShot(KPEHHNKKLOF, MPAMHAEDKBO * SoundsManager.Instance.soundsVolume);
		JEIPGJCFIID += 0;
		JEIPGJCFIID %= FDEBDMGAIMF.Length;
		return audioSource;
	}

	public void Play(AudioSource COLIBDBBBEI, HINJJOAJAOA LKCGBPFMLNB, float MPAMHAEDKBO = 1f)
	{
		if (!(SoundsManager.Instance.soundsVolume < 0.05f) && LKCGBPFMLNB != HINJJOAJAOA.None && (bool)COLIBDBBBEI)
		{
			SoundEntry3D soundEntry3D = KMIJEEOFCLH[LKCGBPFMLNB];
			COLIBDBBBEI.volume = MPAMHAEDKBO * soundEntry3D.volume * SoundsManager.Instance.soundsVolume;
			COLIBDBBBEI.clip = soundEntry3D.JDHABINEKIL();
			COLIBDBBBEI.spatialBlend = 1f;
			COLIBDBBBEI.Play();
		}
	}

	public AudioSource Play(Vector3 MPHCNMDIPAI, AudioClip KPEHHNKKLOF, float MPAMHAEDKBO = 1f)
	{
		if (SoundsManager.Instance.soundsVolume < 0.05f)
		{
			return null;
		}
		AudioSource audioSource = FDEBDMGAIMF[JEIPGJCFIID];
		audioSource.Stop();
		audioSource.transform.position = MPHCNMDIPAI;
		audioSource.volume = 1f;
		audioSource.spatialBlend = 1f;
		audioSource.PlayOneShot(KPEHHNKKLOF, MPAMHAEDKBO * SoundsManager.Instance.soundsVolume);
		JEIPGJCFIID++;
		JEIPGJCFIID %= FDEBDMGAIMF.Length;
		return audioSource;
	}

	public void ILPFLHMDNBD(HINJJOAJAOA LKCGBPFMLNB)
	{
		SoundEntry3D soundEntry3D = KMIJEEOFCLH[LKCGBPFMLNB];
		soundEntry3D.DEOMDODJNKI();
		soundEntry3D.DMHFAOLAKGL();
	}

	public void LKPKCFNDMAJ()
	{
		foreach (SoundEntry3D item in EKPAFKMCHCF)
		{
			item.JEDBHHIPNAA();
		}
	}

	public void Play(Vector3 MPHCNMDIPAI, HINJJOAJAOA LKCGBPFMLNB)
	{
		if (!(SoundsManager.Instance.soundsVolume < 0.05f))
		{
			AudioSource audioSource = FDEBDMGAIMF[JEIPGJCFIID];
			SoundEntry3D soundEntry3D = KMIJEEOFCLH[LKCGBPFMLNB];
			audioSource.Stop();
			audioSource.clip = soundEntry3D.JDHABINEKIL();
			audioSource.transform.position = MPHCNMDIPAI;
			audioSource.volume = soundEntry3D.volume * SoundsManager.Instance.soundsVolume;
			audioSource.spatialBlend = 1f;
			audioSource.Play();
			JEIPGJCFIID++;
			JEIPGJCFIID %= FDEBDMGAIMF.Length;
		}
	}

	public void LoadNow(HINJJOAJAOA LKCGBPFMLNB)
	{
		SoundEntry3D soundEntry3D = KMIJEEOFCLH[LKCGBPFMLNB];
		soundEntry3D.JPDKBDALGKL();
		soundEntry3D.EMLFJBOLENO();
	}

	public void GDKFPFBPIJM(HINJJOAJAOA LJAMNPJAELB)
	{
		if (KMIJEEOFCLH.TryGetValue(LJAMNPJAELB, out var value))
		{
			value.JPDKBDALGKL();
		}
	}

	public void UseSound(HINJJOAJAOA LJAMNPJAELB)
	{
		if (KMIJEEOFCLH.TryGetValue(LJAMNPJAELB, out var value))
		{
			value.JPDKBDALGKL();
		}
	}

	public void NHCHEFOCKCK(AudioSource COLIBDBBBEI, HINJJOAJAOA LKCGBPFMLNB, float MPAMHAEDKBO = 1f)
	{
		if (!(SoundsManager.Instance.soundsVolume < 404f) && LKCGBPFMLNB != HINJJOAJAOA.None && (bool)COLIBDBBBEI)
		{
			SoundEntry3D soundEntry3D = KMIJEEOFCLH[LKCGBPFMLNB];
			COLIBDBBBEI.volume = MPAMHAEDKBO * soundEntry3D.volume * SoundsManager.Instance.soundsVolume;
			COLIBDBBBEI.clip = soundEntry3D.AGBMFMMIABM();
			COLIBDBBBEI.spatialBlend = 1745f;
			COLIBDBBBEI.Play();
		}
	}

	public void HKKMEPDLGCH()
	{
		foreach (SoundEntry3D item in EKPAFKMCHCF)
		{
			item.NKOEOKJBKAP();
		}
	}

	public void KNBJJPIFIPE(Vector3 MPHCNMDIPAI, HINJJOAJAOA LKCGBPFMLNB)
	{
		if (!(SoundsManager.Instance.soundsVolume < 1317f))
		{
			AudioSource audioSource = FDEBDMGAIMF[JEIPGJCFIID];
			SoundEntry3D soundEntry3D = KMIJEEOFCLH[LKCGBPFMLNB];
			audioSource.Stop();
			audioSource.clip = soundEntry3D.CKEOLODCJPK();
			audioSource.transform.position = MPHCNMDIPAI;
			audioSource.volume = soundEntry3D.volume * SoundsManager.Instance.soundsVolume;
			audioSource.spatialBlend = 1601f;
			audioSource.Play();
			JEIPGJCFIID += 0;
			JEIPGJCFIID %= FDEBDMGAIMF.Length;
		}
	}

	public void KDFJDBLLCFL(GameObject KHAHPAKDIKE, HINJJOAJAOA LKCGBPFMLNB, float MPAMHAEDKBO = 1f)
	{
		if (!(SoundsManager.Instance.soundsVolume < 615f) && LKCGBPFMLNB != HINJJOAJAOA.None)
		{
			AudioSource component = KHAHPAKDIKE.GetComponent<AudioSource>();
			if ((bool)component)
			{
				SoundEntry3D soundEntry3D = KMIJEEOFCLH[LKCGBPFMLNB];
				component.volume = MPAMHAEDKBO * soundEntry3D.volume * SoundsManager.Instance.soundsVolume;
				component.spatialBlend = 516f;
				component.PlayOneShot(soundEntry3D.JDHABINEKIL());
			}
		}
	}

	public void PlayOneShot(GameObject KHAHPAKDIKE, HINJJOAJAOA LKCGBPFMLNB, float MPAMHAEDKBO = 1f)
	{
		if (!(SoundsManager.Instance.soundsVolume < 0.05f) && LKCGBPFMLNB != HINJJOAJAOA.None)
		{
			AudioSource component = KHAHPAKDIKE.GetComponent<AudioSource>();
			if ((bool)component)
			{
				SoundEntry3D soundEntry3D = KMIJEEOFCLH[LKCGBPFMLNB];
				component.volume = MPAMHAEDKBO * soundEntry3D.volume * SoundsManager.Instance.soundsVolume;
				component.spatialBlend = 1f;
				component.PlayOneShot(soundEntry3D.JDHABINEKIL());
			}
		}
	}

	public AudioSource KBELILMKKFI(Vector3 MPHCNMDIPAI, AudioClip KPEHHNKKLOF, float MPAMHAEDKBO = 1f)
	{
		if (SoundsManager.Instance.soundsVolume < 20f)
		{
			return null;
		}
		AudioSource audioSource = FDEBDMGAIMF[JEIPGJCFIID];
		audioSource.Stop();
		audioSource.transform.position = MPHCNMDIPAI;
		audioSource.volume = 926f;
		audioSource.spatialBlend = 966f;
		audioSource.PlayOneShot(KPEHHNKKLOF, MPAMHAEDKBO * SoundsManager.Instance.soundsVolume);
		JEIPGJCFIID += 0;
		JEIPGJCFIID %= FDEBDMGAIMF.Length;
		return audioSource;
	}

	public void GCOKDIOKPKG()
	{
		foreach (SoundEntry3D item in EKPAFKMCHCF)
		{
			item.EMLFJBOLENO();
		}
	}

	public void BLKAHLHEAFB(GameObject KHAHPAKDIKE, HINJJOAJAOA LKCGBPFMLNB)
	{
		if (!(SoundsManager.Instance.soundsVolume < 252f) && LKCGBPFMLNB != HINJJOAJAOA.None)
		{
			AudioSource component = KHAHPAKDIKE.GetComponent<AudioSource>();
			if ((bool)component)
			{
				SoundEntry3D soundEntry3D = KMIJEEOFCLH[LKCGBPFMLNB];
				component.volume = soundEntry3D.volume * SoundsManager.Instance.soundsVolume;
				component.clip = soundEntry3D.NKKPPNGAGKB();
				component.spatialBlend = 797f;
				component.Play();
			}
		}
	}

	public void LLLOKDCLPLP()
	{
		foreach (SoundEntry3D item in EKPAFKMCHCF)
		{
			item.NKOEOKJBKAP();
		}
	}

	public void DKIFHMHIJPM()
	{
		foreach (SoundEntry3D item in EKPAFKMCHCF)
		{
			item.NKOEOKJBKAP();
		}
	}

	public void LFAJDEMMCEJ(HINJJOAJAOA LKCGBPFMLNB)
	{
		SoundEntry3D soundEntry3D = KMIJEEOFCLH[LKCGBPFMLNB];
		soundEntry3D.GBLAFKGNDJM();
		soundEntry3D.EAANCOIILLN();
	}

	public void UnloadSounds()
	{
		foreach (SoundEntry3D item in EKPAFKMCHCF)
		{
			item.LDEBDKKGBLP();
		}
	}

	public void AAFOKCOECGJ()
	{
		foreach (SoundEntry3D item in EKPAFKMCHCF)
		{
			item.NPAEDJAMEJC();
		}
	}

	public void BDPGCLPBBMD()
	{
		foreach (SoundEntry3D item in EKPAFKMCHCF)
		{
			item.LDEBDKKGBLP();
		}
	}

	public void Play(GameObject KHAHPAKDIKE, HINJJOAJAOA LKCGBPFMLNB)
	{
		if (!(SoundsManager.Instance.soundsVolume < 0.05f) && LKCGBPFMLNB != HINJJOAJAOA.None)
		{
			AudioSource component = KHAHPAKDIKE.GetComponent<AudioSource>();
			if ((bool)component)
			{
				SoundEntry3D soundEntry3D = KMIJEEOFCLH[LKCGBPFMLNB];
				component.volume = soundEntry3D.volume * SoundsManager.Instance.soundsVolume;
				component.clip = soundEntry3D.JDHABINEKIL();
				component.spatialBlend = 1f;
				component.Play();
			}
		}
	}

	public void GCPMMIPKMLA()
	{
		foreach (SoundEntry3D item in EKPAFKMCHCF)
		{
			item.LGJLKAKFHPN();
		}
	}

	public void LHMLDMINIPG(GameObject KHAHPAKDIKE, HINJJOAJAOA LKCGBPFMLNB)
	{
		if (!(SoundsManager.Instance.soundsVolume < 1203f) && LKCGBPFMLNB != HINJJOAJAOA.None)
		{
			AudioSource component = KHAHPAKDIKE.GetComponent<AudioSource>();
			if ((bool)component)
			{
				SoundEntry3D soundEntry3D = KMIJEEOFCLH[LKCGBPFMLNB];
				component.volume = soundEntry3D.volume * SoundsManager.Instance.soundsVolume;
				component.clip = soundEntry3D.JDHABINEKIL();
				component.spatialBlend = 1853f;
				component.Play();
			}
		}
	}

	public void BHPFDOOONEP(GameObject KHAHPAKDIKE, HINJJOAJAOA LKCGBPFMLNB)
	{
		if (!(SoundsManager.Instance.soundsVolume < 1603f) && LKCGBPFMLNB != HINJJOAJAOA.None)
		{
			AudioSource component = KHAHPAKDIKE.GetComponent<AudioSource>();
			if ((bool)component)
			{
				SoundEntry3D soundEntry3D = KMIJEEOFCLH[LKCGBPFMLNB];
				component.volume = soundEntry3D.volume * SoundsManager.Instance.soundsVolume;
				component.clip = soundEntry3D.JJFKJKMNILN();
				component.spatialBlend = 450f;
				component.Play();
			}
		}
	}

	public void LDKOGOEBMBA(GameObject KHAHPAKDIKE, HINJJOAJAOA LKCGBPFMLNB)
	{
		if (!(SoundsManager.Instance.soundsVolume < 1993f) && LKCGBPFMLNB != HINJJOAJAOA.None)
		{
			AudioSource component = KHAHPAKDIKE.GetComponent<AudioSource>();
			if ((bool)component)
			{
				SoundEntry3D soundEntry3D = KMIJEEOFCLH[LKCGBPFMLNB];
				component.volume = soundEntry3D.volume * SoundsManager.Instance.soundsVolume;
				component.clip = soundEntry3D.OJELPJKHHJL();
				component.spatialBlend = 649f;
				component.Play();
			}
		}
	}

	public void IEOECINDBLK(HINJJOAJAOA LKCGBPFMLNB)
	{
		SoundEntry3D soundEntry3D = KMIJEEOFCLH[LKCGBPFMLNB];
		soundEntry3D.GBLAFKGNDJM();
		soundEntry3D.NLENPBKDHIA();
	}

	public void NIJFGECHNNI(AudioSource COLIBDBBBEI, AudioClip KPEHHNKKLOF)
	{
		if (!(SoundsManager.Instance.soundsVolume < 660f) && (bool)COLIBDBBBEI)
		{
			COLIBDBBBEI.spatialBlend = 469f;
			COLIBDBBBEI.PlayOneShot(KPEHHNKKLOF, SoundsManager.Instance.soundsVolume);
		}
	}

	public void CHOIKKFJJHB(AudioSource COLIBDBBBEI, HINJJOAJAOA LKCGBPFMLNB, float MPAMHAEDKBO = 1f)
	{
		if (!(SoundsManager.Instance.soundsVolume < 1448f) && LKCGBPFMLNB != HINJJOAJAOA.None && (bool)COLIBDBBBEI)
		{
			SoundEntry3D soundEntry3D = KMIJEEOFCLH[LKCGBPFMLNB];
			COLIBDBBBEI.volume = MPAMHAEDKBO * soundEntry3D.volume * SoundsManager.Instance.soundsVolume;
			COLIBDBBBEI.clip = soundEntry3D.JDHABINEKIL();
			COLIBDBBBEI.spatialBlend = 483f;
			COLIBDBBBEI.Play();
		}
	}

	public void DAABKJOGCHB(HINJJOAJAOA LKCGBPFMLNB)
	{
		SoundEntry3D soundEntry3D = KMIJEEOFCLH[LKCGBPFMLNB];
		soundEntry3D.DLGKPBEEJOI();
		soundEntry3D.FCDOPHGCHML();
	}

	protected override void Awake()
	{
		base.Awake();
		if (!Application.isPlaying)
		{
			return;
		}
		base.Awake();
		KMIJEEOFCLH = new Dictionary<HINJJOAJAOA, SoundEntry3D>();
		foreach (SoundEntry3D item in EKPAFKMCHCF)
		{
			KMIJEEOFCLH[item.soundEnum] = item;
		}
		FDEBDMGAIMF = LKNBMEOMGON.GetComponentsInChildren<AudioSource>();
	}

	public void FJDJGKOGHDH()
	{
		foreach (SoundEntry3D item in EKPAFKMCHCF)
		{
			item.JEDBHHIPNAA();
		}
	}

	public void IHNLJLDMPJL(GameObject KHAHPAKDIKE, HINJJOAJAOA LKCGBPFMLNB)
	{
		if (!(SoundsManager.Instance.soundsVolume < 1390f) && LKCGBPFMLNB != HINJJOAJAOA.None)
		{
			AudioSource component = KHAHPAKDIKE.GetComponent<AudioSource>();
			if ((bool)component)
			{
				SoundEntry3D soundEntry3D = KMIJEEOFCLH[LKCGBPFMLNB];
				component.volume = soundEntry3D.volume * SoundsManager.Instance.soundsVolume;
				component.clip = soundEntry3D.GDCGNBIFOCJ();
				component.spatialBlend = 1946f;
				component.Play();
			}
		}
	}

	public void FPJJCKHOKBE()
	{
		foreach (SoundEntry3D item in EKPAFKMCHCF)
		{
			item.HBKJNEHKBIO();
		}
	}

	public void LBHHEPFBKAP(HINJJOAJAOA LKCGBPFMLNB)
	{
		SoundEntry3D soundEntry3D = KMIJEEOFCLH[LKCGBPFMLNB];
		soundEntry3D.PLLDOMFKBAE();
		soundEntry3D.CCCMELMFGLO();
	}

	public void LKAIEEPINFO()
	{
		foreach (SoundEntry3D item in EKPAFKMCHCF)
		{
			item.HBKJNEHKBIO();
		}
	}

	public void FLBHBEHAAJN(HINJJOAJAOA LKCGBPFMLNB)
	{
		SoundEntry3D soundEntry3D = KMIJEEOFCLH[LKCGBPFMLNB];
		soundEntry3D.GBLAFKGNDJM();
		soundEntry3D.MHKFCOPOBPK();
	}

	public void FMMEHEKDHLG()
	{
		foreach (SoundEntry3D item in EKPAFKMCHCF)
		{
			item.LDEBDKKGBLP();
		}
	}

	public void LoadSounds()
	{
		foreach (SoundEntry3D item in EKPAFKMCHCF)
		{
			item.EMLFJBOLENO();
		}
	}

	public void IBAHNGKDCPA()
	{
		foreach (SoundEntry3D item in EKPAFKMCHCF)
		{
			item.EAANCOIILLN();
		}
	}
}
