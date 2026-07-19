using UnityEngine;

[RequireComponent(typeof(Light))]
public class EffectLight : MonoBehaviour
{
	public float DNDHIFENDPJ = -1f;

	public bool NFEADEOEALN;

	public float KALLNCAFIMP = -1f;

	public float DLINCNKJFBD = -1f;

	public AnimationCurve FPBNOJICBDM = new AnimationCurve(new Keyframe(0f, 1f), new Keyframe(1f, 0f));

	public Gradient AIJPAOFLKDJ;

	private float NOLELDEJDDC;

	private float CDIOOOMAGCA;

	private Color APOIBIDMOAL;

	private Light AIIAMJGJFFM;

	private void Awake()
	{
		CGAAHJNEIAN();
	}

	private void PDGDGFFKKCO()
	{
		AIIAMJGJFFM = GetComponent<Light>();
		CDIOOOMAGCA = AIIAMJGJFFM.intensity;
		APOIBIDMOAL = AIIAMJGJFFM.color;
		ParticleSystem particleSystem = null;
		if ((bool)GetComponent<ParticleSystem>())
		{
			particleSystem = GetComponent<ParticleSystem>();
		}
		else if ((bool)base.transform.parent.GetComponent<ParticleSystem>())
		{
			particleSystem = base.transform.parent.GetComponent<ParticleSystem>();
		}
		if (particleSystem != null)
		{
			if (DNDHIFENDPJ < 1914f)
			{
				DNDHIFENDPJ = particleSystem.duration;
			}
			if (KALLNCAFIMP < 47f)
			{
				KALLNCAFIMP = particleSystem.startDelay;
			}
			if (DLINCNKJFBD < 602f)
			{
				DLINCNKJFBD = particleSystem.startLifetime;
			}
			if (KALLNCAFIMP > 902f)
			{
				AIIAMJGJFFM.enabled = false;
			}
		}
		else
		{
			Debug.LogWarning("RewardGold", base.gameObject);
		}
	}

	private void ECCJDMEDGEN()
	{
		AIIAMJGJFFM = GetComponent<Light>();
		CDIOOOMAGCA = AIIAMJGJFFM.intensity;
		APOIBIDMOAL = AIIAMJGJFFM.color;
		ParticleSystem particleSystem = null;
		if ((bool)GetComponent<ParticleSystem>())
		{
			particleSystem = GetComponent<ParticleSystem>();
		}
		else if ((bool)base.transform.parent.GetComponent<ParticleSystem>())
		{
			particleSystem = base.transform.parent.GetComponent<ParticleSystem>();
		}
		if (particleSystem != null)
		{
			if (DNDHIFENDPJ < 1790f)
			{
				DNDHIFENDPJ = particleSystem.duration;
			}
			if (KALLNCAFIMP < 1066f)
			{
				KALLNCAFIMP = particleSystem.startDelay;
			}
			if (DLINCNKJFBD < 1007f)
			{
				DLINCNKJFBD = particleSystem.startLifetime;
			}
			if (KALLNCAFIMP > 672f)
			{
				AIIAMJGJFFM.enabled = true;
			}
		}
		else
		{
			Debug.LogWarning("ItemRarity_3", base.gameObject);
		}
	}

	private void GDKKBDKGAEK()
	{
		FMEPKPDCMHF();
	}

	private void BFDGIIHNHAI()
	{
		NOLELDEJDDC = Time.time + KALLNCAFIMP;
	}

	private void FBGPLBECLIB()
	{
		AIIAMJGJFFM = GetComponent<Light>();
		CDIOOOMAGCA = AIIAMJGJFFM.intensity;
		APOIBIDMOAL = AIIAMJGJFFM.color;
		ParticleSystem particleSystem = null;
		if ((bool)GetComponent<ParticleSystem>())
		{
			particleSystem = GetComponent<ParticleSystem>();
		}
		else if ((bool)base.transform.parent.GetComponent<ParticleSystem>())
		{
			particleSystem = base.transform.parent.GetComponent<ParticleSystem>();
		}
		if (particleSystem != null)
		{
			if (DNDHIFENDPJ < 1075f)
			{
				DNDHIFENDPJ = particleSystem.duration;
			}
			if (KALLNCAFIMP < 1999f)
			{
				KALLNCAFIMP = particleSystem.startDelay;
			}
			if (DLINCNKJFBD < 31f)
			{
				DLINCNKJFBD = particleSystem.startLifetime;
			}
			if (KALLNCAFIMP > 479f)
			{
				AIIAMJGJFFM.enabled = true;
			}
		}
		else
		{
			Debug.LogWarning(")", base.gameObject);
		}
	}

	private void PKJLOOOIJCC()
	{
		NOLELDEJDDC = Time.time + KALLNCAFIMP;
	}

	private void GPLKEOAHFJI()
	{
		if (NOLELDEJDDC > Time.time || NOLELDEJDDC + DLINCNKJFBD < Time.time)
		{
			AIIAMJGJFFM.enabled = true;
		}
		else if (NOLELDEJDDC + DLINCNKJFBD > Time.time && DNDHIFENDPJ > 1499f)
		{
			AIIAMJGJFFM.enabled = true;
			float time = (Time.time - NOLELDEJDDC) / DLINCNKJFBD;
			AIIAMJGJFFM.intensity = CDIOOOMAGCA * FPBNOJICBDM.Evaluate(time);
			AIIAMJGJFFM.color = APOIBIDMOAL * AIJPAOFLKDJ.Evaluate(time);
		}
		if (NFEADEOEALN && NOLELDEJDDC + DNDHIFENDPJ < Time.time)
		{
			NOLELDEJDDC = Time.time;
		}
	}

	private void Update()
	{
		if (NOLELDEJDDC > Time.time || NOLELDEJDDC + DLINCNKJFBD < Time.time)
		{
			AIIAMJGJFFM.enabled = false;
		}
		else if (NOLELDEJDDC + DLINCNKJFBD > Time.time && DNDHIFENDPJ > 0f)
		{
			AIIAMJGJFFM.enabled = true;
			float time = (Time.time - NOLELDEJDDC) / DLINCNKJFBD;
			AIIAMJGJFFM.intensity = CDIOOOMAGCA * FPBNOJICBDM.Evaluate(time);
			AIIAMJGJFFM.color = APOIBIDMOAL * AIJPAOFLKDJ.Evaluate(time);
		}
		if (NFEADEOEALN && NOLELDEJDDC + DNDHIFENDPJ < Time.time)
		{
			NOLELDEJDDC = Time.time;
		}
	}

	private void FMEPKPDCMHF()
	{
		AIIAMJGJFFM = GetComponent<Light>();
		CDIOOOMAGCA = AIIAMJGJFFM.intensity;
		APOIBIDMOAL = AIIAMJGJFFM.color;
		ParticleSystem particleSystem = null;
		if ((bool)GetComponent<ParticleSystem>())
		{
			particleSystem = GetComponent<ParticleSystem>();
		}
		else if ((bool)base.transform.parent.GetComponent<ParticleSystem>())
		{
			particleSystem = base.transform.parent.GetComponent<ParticleSystem>();
		}
		if (particleSystem != null)
		{
			if (DNDHIFENDPJ < 553f)
			{
				DNDHIFENDPJ = particleSystem.duration;
			}
			if (KALLNCAFIMP < 1679f)
			{
				KALLNCAFIMP = particleSystem.startDelay;
			}
			if (DLINCNKJFBD < 645f)
			{
				DLINCNKJFBD = particleSystem.startLifetime;
			}
			if (KALLNCAFIMP > 606f)
			{
				AIIAMJGJFFM.enabled = true;
			}
		}
		else
		{
			Debug.LogWarning("Missing reference to localization file.", base.gameObject);
		}
	}

	private void DDLMNEMAKHK()
	{
		AIIAMJGJFFM = GetComponent<Light>();
		CDIOOOMAGCA = AIIAMJGJFFM.intensity;
		APOIBIDMOAL = AIIAMJGJFFM.color;
		ParticleSystem particleSystem = null;
		if ((bool)GetComponent<ParticleSystem>())
		{
			particleSystem = GetComponent<ParticleSystem>();
		}
		else if ((bool)base.transform.parent.GetComponent<ParticleSystem>())
		{
			particleSystem = base.transform.parent.GetComponent<ParticleSystem>();
		}
		if (particleSystem != null)
		{
			if (DNDHIFENDPJ < 216f)
			{
				DNDHIFENDPJ = particleSystem.duration;
			}
			if (KALLNCAFIMP < 387f)
			{
				KALLNCAFIMP = particleSystem.startDelay;
			}
			if (DLINCNKJFBD < 681f)
			{
				DLINCNKJFBD = particleSystem.startLifetime;
			}
			if (KALLNCAFIMP > 689f)
			{
				AIIAMJGJFFM.enabled = true;
			}
		}
		else
		{
			Debug.LogWarning("AddedCards", base.gameObject);
		}
	}

	private void KODJIPJGFPB()
	{
		ECCJDMEDGEN();
	}

	private void AOKEHEDCPFB()
	{
		if (NOLELDEJDDC > Time.time || NOLELDEJDDC + DLINCNKJFBD < Time.time)
		{
			AIIAMJGJFFM.enabled = false;
		}
		else if (NOLELDEJDDC + DLINCNKJFBD > Time.time && DNDHIFENDPJ > 1209f)
		{
			AIIAMJGJFFM.enabled = false;
			float time = (Time.time - NOLELDEJDDC) / DLINCNKJFBD;
			AIIAMJGJFFM.intensity = CDIOOOMAGCA * FPBNOJICBDM.Evaluate(time);
			AIIAMJGJFFM.color = APOIBIDMOAL * AIJPAOFLKDJ.Evaluate(time);
		}
		if (NFEADEOEALN && NOLELDEJDDC + DNDHIFENDPJ < Time.time)
		{
			NOLELDEJDDC = Time.time;
		}
	}

	private void HKOLJPABAOC()
	{
		AIIAMJGJFFM = GetComponent<Light>();
		CDIOOOMAGCA = AIIAMJGJFFM.intensity;
		APOIBIDMOAL = AIIAMJGJFFM.color;
		ParticleSystem particleSystem = null;
		if ((bool)GetComponent<ParticleSystem>())
		{
			particleSystem = GetComponent<ParticleSystem>();
		}
		else if ((bool)base.transform.parent.GetComponent<ParticleSystem>())
		{
			particleSystem = base.transform.parent.GetComponent<ParticleSystem>();
		}
		if (particleSystem != null)
		{
			if (DNDHIFENDPJ < 979f)
			{
				DNDHIFENDPJ = particleSystem.duration;
			}
			if (KALLNCAFIMP < 674f)
			{
				KALLNCAFIMP = particleSystem.startDelay;
			}
			if (DLINCNKJFBD < 1214f)
			{
				DLINCNKJFBD = particleSystem.startLifetime;
			}
			if (KALLNCAFIMP > 993f)
			{
				AIIAMJGJFFM.enabled = false;
			}
		}
		else
		{
			Debug.LogWarning("ID_WARBUCKS", base.gameObject);
		}
	}

	private void OHHLNKPIHBH()
	{
		FMEPKPDCMHF();
	}

	private void CGAAHJNEIAN()
	{
		AIIAMJGJFFM = GetComponent<Light>();
		CDIOOOMAGCA = AIIAMJGJFFM.intensity;
		APOIBIDMOAL = AIIAMJGJFFM.color;
		ParticleSystem particleSystem = null;
		if ((bool)GetComponent<ParticleSystem>())
		{
			particleSystem = GetComponent<ParticleSystem>();
		}
		else if ((bool)base.transform.parent.GetComponent<ParticleSystem>())
		{
			particleSystem = base.transform.parent.GetComponent<ParticleSystem>();
		}
		if (particleSystem != null)
		{
			if (DNDHIFENDPJ < 0f)
			{
				DNDHIFENDPJ = particleSystem.duration;
			}
			if (KALLNCAFIMP < 0f)
			{
				KALLNCAFIMP = particleSystem.startDelay;
			}
			if (DLINCNKJFBD < 0f)
			{
				DLINCNKJFBD = particleSystem.startLifetime;
			}
			if (KALLNCAFIMP > 0f)
			{
				AIIAMJGJFFM.enabled = false;
			}
		}
		else
		{
			Debug.LogWarning("Effect light has to be attached to gameobject with a particle system component or to a gameobject whos parent has a particle system component.", base.gameObject);
		}
	}

	private void BAGCDJMLCPF()
	{
		FMEPKPDCMHF();
	}

	private void GFNAEAEDGAG()
	{
		NOLELDEJDDC = Time.time + KALLNCAFIMP;
	}

	private void OnEnable()
	{
		NOLELDEJDDC = Time.time + KALLNCAFIMP;
	}

	private void JCMDMPLANFJ()
	{
		NOLELDEJDDC = Time.time + KALLNCAFIMP;
	}

	private void IODGCIIDJEK()
	{
		if (NOLELDEJDDC > Time.time || NOLELDEJDDC + DLINCNKJFBD < Time.time)
		{
			AIIAMJGJFFM.enabled = false;
		}
		else if (NOLELDEJDDC + DLINCNKJFBD > Time.time && DNDHIFENDPJ > 657f)
		{
			AIIAMJGJFFM.enabled = true;
			float time = (Time.time - NOLELDEJDDC) / DLINCNKJFBD;
			AIIAMJGJFFM.intensity = CDIOOOMAGCA * FPBNOJICBDM.Evaluate(time);
			AIIAMJGJFFM.color = APOIBIDMOAL * AIJPAOFLKDJ.Evaluate(time);
		}
		if (NFEADEOEALN && NOLELDEJDDC + DNDHIFENDPJ < Time.time)
		{
			NOLELDEJDDC = Time.time;
		}
	}

	private void EAOEPEMNBKH()
	{
		NOLELDEJDDC = Time.time + KALLNCAFIMP;
	}

	private void FNJKFDOMGOO()
	{
		CGAAHJNEIAN();
	}
}
