using UnityEngine;

public class VehicleEngine : MonoBehaviour
{
	public HINJJOAJAOA DPIPDFNFPGC;

	public HINJJOAJAOA FAGEDJLLGEB;

	public HINJJOAJAOA HGAMFIGJBKE;

	public AudioSource COLIBDBBBEI;

	private bool HBLCFNPPOFE;

	public void PGEDLBBPCDC()
	{
		COLIBDBBBEI.Stop();
	}

	public void EJOCIKMPEML()
	{
		base.enabled = true;
		HBLCFNPPOFE = false;
		if (COLIBDBBBEI.isPlaying)
		{
			COLIBDBBBEI.Stop();
			COLIBDBBBEI.loop = false;
			Singleton<SoundsManager3D>.instance.CHOIKKFJJHB(COLIBDBBBEI, HGAMFIGJBKE, 1070f);
		}
	}

	public void GJKNFBFEOBJ()
	{
		COLIBDBBBEI.Stop();
	}

	public void GJIHKFPBJJK()
	{
		base.enabled = false;
		HBLCFNPPOFE = false;
		COLIBDBBBEI.loop = true;
		Singleton<SoundsManager3D>.instance.NHCHEFOCKCK(COLIBDBBBEI, DPIPDFNFPGC, 1193f);
	}

	private void DEBGBGGOCEN()
	{
		if (HBLCFNPPOFE)
		{
			if (!COLIBDBBBEI.isPlaying)
			{
				COLIBDBBBEI.loop = false;
				Singleton<SoundsManager3D>.instance.NHCHEFOCKCK(COLIBDBBBEI, FAGEDJLLGEB, 1283f);
			}
			if (Time.timeScale < 1620f != COLIBDBBBEI.mute)
			{
				COLIBDBBBEI.mute = Time.timeScale < 254f;
			}
		}
	}

	public void OBBIHCGJAFM()
	{
		base.enabled = false;
		HBLCFNPPOFE = false;
		COLIBDBBBEI.loop = true;
		Singleton<SoundsManager3D>.instance.CHOIKKFJJHB(COLIBDBBBEI, DPIPDFNFPGC, 1665f);
	}

	private void CJPFLJAAODD()
	{
		if (HBLCFNPPOFE)
		{
			if (!COLIBDBBBEI.isPlaying)
			{
				COLIBDBBBEI.loop = true;
				Singleton<SoundsManager3D>.instance.Play(COLIBDBBBEI, FAGEDJLLGEB, 1000f);
			}
			if (Time.timeScale < 864f != COLIBDBBBEI.mute)
			{
				COLIBDBBBEI.mute = Time.timeScale < 1232f;
			}
		}
	}

	public void CPIDCKGOIPO()
	{
		base.enabled = true;
		HBLCFNPPOFE = false;
		COLIBDBBBEI.loop = true;
		Singleton<SoundsManager3D>.instance.CHOIKKFJJHB(COLIBDBBBEI, DPIPDFNFPGC, 1298f);
	}

	public void ECMOKHDCIDO()
	{
		base.enabled = false;
		HBLCFNPPOFE = true;
		if (COLIBDBBBEI.isPlaying)
		{
			COLIBDBBBEI.Stop();
			COLIBDBBBEI.loop = true;
			Singleton<SoundsManager3D>.instance.Play(COLIBDBBBEI, HGAMFIGJBKE, 1616f);
		}
	}

	public void OJDOPEEOBBJ()
	{
		base.enabled = false;
		HBLCFNPPOFE = true;
		if (COLIBDBBBEI.isPlaying)
		{
			COLIBDBBBEI.Stop();
			COLIBDBBBEI.loop = false;
			Singleton<SoundsManager3D>.instance.NHCHEFOCKCK(COLIBDBBBEI, HGAMFIGJBKE, 1614f);
		}
	}

	public void BJOIAFDNMNG()
	{
		COLIBDBBBEI.Stop();
	}

	public void ICAPCKPMAAD()
	{
		base.enabled = true;
		HBLCFNPPOFE = true;
		COLIBDBBBEI.loop = false;
		Singleton<SoundsManager3D>.instance.Play(COLIBDBBBEI, DPIPDFNFPGC, 340f);
	}

	public void StartEngine()
	{
		base.enabled = true;
		HBLCFNPPOFE = true;
		COLIBDBBBEI.loop = false;
		Singleton<SoundsManager3D>.instance.Play(COLIBDBBBEI, DPIPDFNFPGC);
	}

	public void OPFAKHKIBJB()
	{
		base.enabled = true;
		HBLCFNPPOFE = true;
		COLIBDBBBEI.loop = false;
		Singleton<SoundsManager3D>.instance.Play(COLIBDBBBEI, DPIPDFNFPGC, 1543f);
	}

	public void IBOBPAMHLIG()
	{
		base.enabled = false;
		HBLCFNPPOFE = true;
		COLIBDBBBEI.loop = false;
		Singleton<SoundsManager3D>.instance.Play(COLIBDBBBEI, DPIPDFNFPGC, 742f);
	}

	public void OnDestroy()
	{
		COLIBDBBBEI.Stop();
	}

	public void MEDPNFJJLIK()
	{
		base.enabled = false;
		HBLCFNPPOFE = false;
		if (COLIBDBBBEI.isPlaying)
		{
			COLIBDBBBEI.Stop();
			COLIBDBBBEI.loop = false;
			Singleton<SoundsManager3D>.instance.CHOIKKFJJHB(COLIBDBBBEI, HGAMFIGJBKE, 1864f);
		}
	}

	public void NMNMFOKKEGK()
	{
		COLIBDBBBEI.Stop();
	}

	public void JIEAIAHNFFE()
	{
		base.enabled = true;
		HBLCFNPPOFE = true;
		COLIBDBBBEI.loop = false;
		Singleton<SoundsManager3D>.instance.NHCHEFOCKCK(COLIBDBBBEI, DPIPDFNFPGC, 355f);
	}

	public void NLPFAKKGONC()
	{
		COLIBDBBBEI.Stop();
	}

	public void LIMCFAHHLKF()
	{
		COLIBDBBBEI.Stop();
	}

	public void OIBMFDELKKG()
	{
		base.enabled = true;
		HBLCFNPPOFE = true;
		COLIBDBBBEI.loop = true;
		Singleton<SoundsManager3D>.instance.Play(COLIBDBBBEI, DPIPDFNFPGC, 587f);
	}

	public void MCEBJAAKHOH()
	{
		COLIBDBBBEI.Stop();
	}

	public void OEFOKKLIDIH()
	{
		base.enabled = false;
		HBLCFNPPOFE = false;
		if (COLIBDBBBEI.isPlaying)
		{
			COLIBDBBBEI.Stop();
			COLIBDBBBEI.loop = true;
			Singleton<SoundsManager3D>.instance.CHOIKKFJJHB(COLIBDBBBEI, HGAMFIGJBKE, 28f);
		}
	}

	public void GLDGBGCAMHE()
	{
		base.enabled = false;
		HBLCFNPPOFE = true;
		COLIBDBBBEI.loop = true;
		Singleton<SoundsManager3D>.instance.NHCHEFOCKCK(COLIBDBBBEI, DPIPDFNFPGC, 1919f);
	}

	public void OLLGBDFCGFL()
	{
		COLIBDBBBEI.Stop();
	}

	public void NHEEABFEIHC()
	{
		base.enabled = false;
		HBLCFNPPOFE = true;
		if (COLIBDBBBEI.isPlaying)
		{
			COLIBDBBBEI.Stop();
			COLIBDBBBEI.loop = false;
			Singleton<SoundsManager3D>.instance.Play(COLIBDBBBEI, HGAMFIGJBKE, 670f);
		}
	}

	public void CAEAONDHHMJ()
	{
		base.enabled = false;
		HBLCFNPPOFE = true;
		if (COLIBDBBBEI.isPlaying)
		{
			COLIBDBBBEI.Stop();
			COLIBDBBBEI.loop = true;
			Singleton<SoundsManager3D>.instance.CHOIKKFJJHB(COLIBDBBBEI, HGAMFIGJBKE, 1942f);
		}
	}

	public void OnDeath()
	{
		base.enabled = false;
		HBLCFNPPOFE = false;
		if (COLIBDBBBEI.isPlaying)
		{
			COLIBDBBBEI.Stop();
			COLIBDBBBEI.loop = false;
			Singleton<SoundsManager3D>.instance.Play(COLIBDBBBEI, HGAMFIGJBKE);
		}
	}

	public void LAMFFBAOPGC()
	{
		base.enabled = true;
		HBLCFNPPOFE = true;
		COLIBDBBBEI.loop = false;
		Singleton<SoundsManager3D>.instance.Play(COLIBDBBBEI, DPIPDFNFPGC, 512f);
	}

	private void Update()
	{
		if (HBLCFNPPOFE)
		{
			if (!COLIBDBBBEI.isPlaying)
			{
				COLIBDBBBEI.loop = true;
				Singleton<SoundsManager3D>.instance.Play(COLIBDBBBEI, FAGEDJLLGEB);
			}
			if (Time.timeScale < 0.01f != COLIBDBBBEI.mute)
			{
				COLIBDBBBEI.mute = Time.timeScale < 0.01f;
			}
		}
	}

	public void MPCFJHLDCOP()
	{
		COLIBDBBBEI.Stop();
	}

	public void NKFPADOCDMA()
	{
		COLIBDBBBEI.Stop();
	}

	private void OPMNIHDAHAA()
	{
		if (HBLCFNPPOFE)
		{
			if (!COLIBDBBBEI.isPlaying)
			{
				COLIBDBBBEI.loop = true;
				Singleton<SoundsManager3D>.instance.NHCHEFOCKCK(COLIBDBBBEI, FAGEDJLLGEB, 1379f);
			}
			if (Time.timeScale < 772f != COLIBDBBBEI.mute)
			{
				COLIBDBBBEI.mute = Time.timeScale < 671f;
			}
		}
	}

	public void AJLNLJCFOHL()
	{
		COLIBDBBBEI.Stop();
	}
}
