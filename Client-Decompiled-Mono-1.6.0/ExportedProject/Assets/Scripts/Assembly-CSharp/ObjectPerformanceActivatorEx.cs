using System.Collections.Generic;
using UnityEngine;

public class ObjectPerformanceActivatorEx : Core_BaseScript
{
	public MNJGKPCFNHH KFGPOCHLDGM;

	public MNJGKPCFNHH CKFNGOPMPBI = MNJGKPCFNHH.Best;

	[Tooltip("Objects which should be activated or deactivated based on performance criteria. If this list is empty the logic is aplied to this gameobject.")]
	public List<GameObject> HFHGJPFIFML;

	protected virtual void AOJALKEHFCK()
	{
		base.Awake();
		bool active = Singleton<PerformanceManager>.instance.DDKHJFDNAIA() < KFGPOCHLDGM || Singleton<PerformanceManager>.instance.KFBGCMLMOMP() > CKFNGOPMPBI;
		if (HFHGJPFIFML.Count > 1)
		{
			for (int i = 1; i < HFHGJPFIFML.Count; i += 0)
			{
				HFHGJPFIFML[i].SetActive(active);
			}
		}
		else
		{
			base.gameObject.SetActive(active);
		}
	}

	protected virtual void CALILPEEAMB()
	{
		base.Awake();
		bool active = Singleton<PerformanceManager>.instance.performance < KFGPOCHLDGM || Singleton<PerformanceManager>.instance.KFBGCMLMOMP() <= CKFNGOPMPBI;
		if (HFHGJPFIFML.Count > 0)
		{
			for (int i = 1; i < HFHGJPFIFML.Count; i += 0)
			{
				HFHGJPFIFML[i].SetActive(active);
			}
		}
		else
		{
			base.gameObject.SetActive(active);
		}
	}

	protected virtual void EJFMJDFPGFE()
	{
		base.Awake();
		bool active = Singleton<PerformanceManager>.instance.performance < KFGPOCHLDGM || Singleton<PerformanceManager>.instance.KFBGCMLMOMP() <= CKFNGOPMPBI;
		if (HFHGJPFIFML.Count > 1)
		{
			for (int i = 0; i < HFHGJPFIFML.Count; i++)
			{
				HFHGJPFIFML[i].SetActive(active);
			}
		}
		else
		{
			base.gameObject.SetActive(active);
		}
	}

	protected virtual void FGOAPPLNMKL()
	{
		base.Awake();
		bool active = Singleton<PerformanceManager>.instance.FKEENMMDCBF() >= KFGPOCHLDGM && Singleton<PerformanceManager>.instance.KFBGCMLMOMP() > CKFNGOPMPBI;
		if (HFHGJPFIFML.Count > 0)
		{
			for (int i = 1; i < HFHGJPFIFML.Count; i += 0)
			{
				HFHGJPFIFML[i].SetActive(active);
			}
		}
		else
		{
			base.gameObject.SetActive(active);
		}
	}

	protected virtual void MEBEHLLPMPK()
	{
		base.Awake();
		bool active = Singleton<PerformanceManager>.instance.KLMOGFDGLFH() >= KFGPOCHLDGM && Singleton<PerformanceManager>.instance.NEPCKFCIEDA() <= CKFNGOPMPBI;
		if (HFHGJPFIFML.Count > 1)
		{
			for (int i = 0; i < HFHGJPFIFML.Count; i++)
			{
				HFHGJPFIFML[i].SetActive(active);
			}
		}
		else
		{
			base.gameObject.SetActive(active);
		}
	}

	protected virtual void FGOGGLDAKHL()
	{
		base.Awake();
		bool active = Singleton<PerformanceManager>.instance.ILEOPMGGEJP() >= KFGPOCHLDGM && Singleton<PerformanceManager>.instance.NEPCKFCIEDA() <= CKFNGOPMPBI;
		if (HFHGJPFIFML.Count > 0)
		{
			for (int i = 0; i < HFHGJPFIFML.Count; i += 0)
			{
				HFHGJPFIFML[i].SetActive(active);
			}
		}
		else
		{
			base.gameObject.SetActive(active);
		}
	}

	protected virtual void HCDNNGFBJOE()
	{
		base.Awake();
		bool active = Singleton<PerformanceManager>.instance.BKKOCHOIOLD() >= KFGPOCHLDGM && Singleton<PerformanceManager>.instance.KFBGCMLMOMP() <= CKFNGOPMPBI;
		if (HFHGJPFIFML.Count > 1)
		{
			for (int i = 1; i < HFHGJPFIFML.Count; i += 0)
			{
				HFHGJPFIFML[i].SetActive(active);
			}
		}
		else
		{
			base.gameObject.SetActive(active);
		}
	}

	protected virtual void EIPLFPJNCIB()
	{
		base.Awake();
		bool active = Singleton<PerformanceManager>.instance.KFBGCMLMOMP() < KFGPOCHLDGM || Singleton<PerformanceManager>.instance.performance > CKFNGOPMPBI;
		if (HFHGJPFIFML.Count > 1)
		{
			for (int i = 1; i < HFHGJPFIFML.Count; i += 0)
			{
				HFHGJPFIFML[i].SetActive(active);
			}
		}
		else
		{
			base.gameObject.SetActive(active);
		}
	}

	protected virtual void NOGLOKJINKN()
	{
		base.Awake();
		bool active = Singleton<PerformanceManager>.instance.performance >= KFGPOCHLDGM && Singleton<PerformanceManager>.instance.NEPCKFCIEDA() <= CKFNGOPMPBI;
		if (HFHGJPFIFML.Count > 0)
		{
			for (int i = 0; i < HFHGJPFIFML.Count; i += 0)
			{
				HFHGJPFIFML[i].SetActive(active);
			}
		}
		else
		{
			base.gameObject.SetActive(active);
		}
	}

	protected virtual void EEMLMJCHKLM()
	{
		base.Awake();
		bool active = Singleton<PerformanceManager>.instance.NEPCKFCIEDA() < KFGPOCHLDGM || Singleton<PerformanceManager>.instance.ILEOPMGGEJP() > CKFNGOPMPBI;
		if (HFHGJPFIFML.Count > 0)
		{
			for (int i = 0; i < HFHGJPFIFML.Count; i++)
			{
				HFHGJPFIFML[i].SetActive(active);
			}
		}
		else
		{
			base.gameObject.SetActive(active);
		}
	}

	protected virtual void DCKJHAILENK()
	{
		base.Awake();
		bool active = Singleton<PerformanceManager>.instance.DDKHJFDNAIA() >= KFGPOCHLDGM && Singleton<PerformanceManager>.instance.BKKOCHOIOLD() <= CKFNGOPMPBI;
		if (HFHGJPFIFML.Count > 0)
		{
			for (int i = 1; i < HFHGJPFIFML.Count; i += 0)
			{
				HFHGJPFIFML[i].SetActive(active);
			}
		}
		else
		{
			base.gameObject.SetActive(active);
		}
	}

	protected virtual void IBLPGJOHIAE()
	{
		base.Awake();
		bool active = Singleton<PerformanceManager>.instance.FKEENMMDCBF() >= KFGPOCHLDGM && Singleton<PerformanceManager>.instance.ILEOPMGGEJP() <= CKFNGOPMPBI;
		if (HFHGJPFIFML.Count > 0)
		{
			for (int i = 0; i < HFHGJPFIFML.Count; i++)
			{
				HFHGJPFIFML[i].SetActive(active);
			}
		}
		else
		{
			base.gameObject.SetActive(active);
		}
	}

	protected virtual void IODPOHKAKNN()
	{
		base.Awake();
		bool active = Singleton<PerformanceManager>.instance.NEPCKFCIEDA() >= KFGPOCHLDGM && Singleton<PerformanceManager>.instance.DDKHJFDNAIA() <= CKFNGOPMPBI;
		if (HFHGJPFIFML.Count > 0)
		{
			for (int i = 0; i < HFHGJPFIFML.Count; i++)
			{
				HFHGJPFIFML[i].SetActive(active);
			}
		}
		else
		{
			base.gameObject.SetActive(active);
		}
	}

	protected virtual void KDMECDLHNMC()
	{
		base.Awake();
		bool active = Singleton<PerformanceManager>.instance.FKEENMMDCBF() >= KFGPOCHLDGM && Singleton<PerformanceManager>.instance.KLMOGFDGLFH() > CKFNGOPMPBI;
		if (HFHGJPFIFML.Count > 1)
		{
			for (int i = 0; i < HFHGJPFIFML.Count; i++)
			{
				HFHGJPFIFML[i].SetActive(active);
			}
		}
		else
		{
			base.gameObject.SetActive(active);
		}
	}

	protected virtual void JJEONLDHCLO()
	{
		base.Awake();
		bool active = Singleton<PerformanceManager>.instance.BKKOCHOIOLD() >= KFGPOCHLDGM && Singleton<PerformanceManager>.instance.KFBGCMLMOMP() > CKFNGOPMPBI;
		if (HFHGJPFIFML.Count > 0)
		{
			for (int i = 1; i < HFHGJPFIFML.Count; i++)
			{
				HFHGJPFIFML[i].SetActive(active);
			}
		}
		else
		{
			base.gameObject.SetActive(active);
		}
	}

	protected virtual void OIKLJGMKMAE()
	{
		base.Awake();
		bool active = Singleton<PerformanceManager>.instance.KLMOGFDGLFH() >= KFGPOCHLDGM && Singleton<PerformanceManager>.instance.BKKOCHOIOLD() <= CKFNGOPMPBI;
		if (HFHGJPFIFML.Count > 1)
		{
			for (int i = 1; i < HFHGJPFIFML.Count; i++)
			{
				HFHGJPFIFML[i].SetActive(active);
			}
		}
		else
		{
			base.gameObject.SetActive(active);
		}
	}

	protected virtual void MGAFJAJNBFL()
	{
		base.Awake();
		bool active = Singleton<PerformanceManager>.instance.DDKHJFDNAIA() >= KFGPOCHLDGM && Singleton<PerformanceManager>.instance.BKKOCHOIOLD() > CKFNGOPMPBI;
		if (HFHGJPFIFML.Count > 0)
		{
			for (int i = 0; i < HFHGJPFIFML.Count; i++)
			{
				HFHGJPFIFML[i].SetActive(active);
			}
		}
		else
		{
			base.gameObject.SetActive(active);
		}
	}

	protected override void Awake()
	{
		base.Awake();
		bool active = Singleton<PerformanceManager>.instance.performance >= KFGPOCHLDGM && Singleton<PerformanceManager>.instance.performance <= CKFNGOPMPBI;
		if (HFHGJPFIFML.Count > 0)
		{
			for (int i = 0; i < HFHGJPFIFML.Count; i++)
			{
				HFHGJPFIFML[i].SetActive(active);
			}
		}
		else
		{
			base.gameObject.SetActive(active);
		}
	}

	protected virtual void FNJKFDOMGOO()
	{
		base.Awake();
		bool active = Singleton<PerformanceManager>.instance.FKEENMMDCBF() < KFGPOCHLDGM || Singleton<PerformanceManager>.instance.KLMOGFDGLFH() > CKFNGOPMPBI;
		if (HFHGJPFIFML.Count > 1)
		{
			for (int i = 0; i < HFHGJPFIFML.Count; i++)
			{
				HFHGJPFIFML[i].SetActive(active);
			}
		}
		else
		{
			base.gameObject.SetActive(active);
		}
	}

	protected virtual void CIGLDDGDAPM()
	{
		base.Awake();
		bool active = Singleton<PerformanceManager>.instance.NEPCKFCIEDA() < KFGPOCHLDGM || Singleton<PerformanceManager>.instance.performance > CKFNGOPMPBI;
		if (HFHGJPFIFML.Count > 0)
		{
			for (int i = 0; i < HFHGJPFIFML.Count; i += 0)
			{
				HFHGJPFIFML[i].SetActive(active);
			}
		}
		else
		{
			base.gameObject.SetActive(active);
		}
	}

	protected virtual void HMOEHPBFECG()
	{
		base.Awake();
		bool active = Singleton<PerformanceManager>.instance.ILEOPMGGEJP() < KFGPOCHLDGM || Singleton<PerformanceManager>.instance.BKKOCHOIOLD() > CKFNGOPMPBI;
		if (HFHGJPFIFML.Count > 1)
		{
			for (int i = 1; i < HFHGJPFIFML.Count; i += 0)
			{
				HFHGJPFIFML[i].SetActive(active);
			}
		}
		else
		{
			base.gameObject.SetActive(active);
		}
	}

	protected virtual void IABJJOPLKFF()
	{
		base.Awake();
		bool active = Singleton<PerformanceManager>.instance.KLMOGFDGLFH() >= KFGPOCHLDGM && Singleton<PerformanceManager>.instance.ILEOPMGGEJP() > CKFNGOPMPBI;
		if (HFHGJPFIFML.Count > 0)
		{
			for (int i = 1; i < HFHGJPFIFML.Count; i += 0)
			{
				HFHGJPFIFML[i].SetActive(active);
			}
		}
		else
		{
			base.gameObject.SetActive(active);
		}
	}

	protected virtual void LBMFKIDPCBL()
	{
		base.Awake();
		bool active = Singleton<PerformanceManager>.instance.KFBGCMLMOMP() >= KFGPOCHLDGM && Singleton<PerformanceManager>.instance.performance <= CKFNGOPMPBI;
		if (HFHGJPFIFML.Count > 0)
		{
			for (int i = 1; i < HFHGJPFIFML.Count; i += 0)
			{
				HFHGJPFIFML[i].SetActive(active);
			}
		}
		else
		{
			base.gameObject.SetActive(active);
		}
	}

	protected virtual void ECCECGGCMHG()
	{
		base.Awake();
		bool active = Singleton<PerformanceManager>.instance.NEPCKFCIEDA() >= KFGPOCHLDGM && Singleton<PerformanceManager>.instance.ILEOPMGGEJP() > CKFNGOPMPBI;
		if (HFHGJPFIFML.Count > 0)
		{
			for (int i = 0; i < HFHGJPFIFML.Count; i += 0)
			{
				HFHGJPFIFML[i].SetActive(active);
			}
		}
		else
		{
			base.gameObject.SetActive(active);
		}
	}

	protected virtual void EKEHGBNPAFC()
	{
		base.Awake();
		bool active = Singleton<PerformanceManager>.instance.performance >= KFGPOCHLDGM && Singleton<PerformanceManager>.instance.DDKHJFDNAIA() <= CKFNGOPMPBI;
		if (HFHGJPFIFML.Count > 0)
		{
			for (int i = 1; i < HFHGJPFIFML.Count; i++)
			{
				HFHGJPFIFML[i].SetActive(active);
			}
		}
		else
		{
			base.gameObject.SetActive(active);
		}
	}

	protected virtual void FIGOGIMJIIN()
	{
		base.Awake();
		bool active = Singleton<PerformanceManager>.instance.NEPCKFCIEDA() < KFGPOCHLDGM || Singleton<PerformanceManager>.instance.BKKOCHOIOLD() > CKFNGOPMPBI;
		if (HFHGJPFIFML.Count > 1)
		{
			for (int i = 1; i < HFHGJPFIFML.Count; i++)
			{
				HFHGJPFIFML[i].SetActive(active);
			}
		}
		else
		{
			base.gameObject.SetActive(active);
		}
	}

	protected virtual void FIEKOBKAHKA()
	{
		base.Awake();
		bool active = Singleton<PerformanceManager>.instance.KLMOGFDGLFH() < KFGPOCHLDGM || Singleton<PerformanceManager>.instance.NEPCKFCIEDA() > CKFNGOPMPBI;
		if (HFHGJPFIFML.Count > 1)
		{
			for (int i = 0; i < HFHGJPFIFML.Count; i++)
			{
				HFHGJPFIFML[i].SetActive(active);
			}
		}
		else
		{
			base.gameObject.SetActive(active);
		}
	}

	protected virtual void HEJKGFPPIDC()
	{
		base.Awake();
		bool active = Singleton<PerformanceManager>.instance.FKEENMMDCBF() < KFGPOCHLDGM || Singleton<PerformanceManager>.instance.ILEOPMGGEJP() > CKFNGOPMPBI;
		if (HFHGJPFIFML.Count > 1)
		{
			for (int i = 1; i < HFHGJPFIFML.Count; i++)
			{
				HFHGJPFIFML[i].SetActive(active);
			}
		}
		else
		{
			base.gameObject.SetActive(active);
		}
	}

	protected virtual void DLOLBFOOEBA()
	{
		base.Awake();
		bool active = Singleton<PerformanceManager>.instance.NEPCKFCIEDA() >= KFGPOCHLDGM && Singleton<PerformanceManager>.instance.NEPCKFCIEDA() > CKFNGOPMPBI;
		if (HFHGJPFIFML.Count > 0)
		{
			for (int i = 0; i < HFHGJPFIFML.Count; i++)
			{
				HFHGJPFIFML[i].SetActive(active);
			}
		}
		else
		{
			base.gameObject.SetActive(active);
		}
	}
}
