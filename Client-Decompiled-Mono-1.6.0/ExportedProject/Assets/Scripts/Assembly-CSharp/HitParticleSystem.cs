using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class HitParticleSystem : Singleton<HitParticleSystem>
{
	public SpawnPool OKKEOCKELAF;

	public SpawnPool DANFGIIMPDJ;

	public List<HitParticles> AMLJAOJNKHC;

	public List<HitParticles> AOJADOBAGFA;

	public Dictionary<string, int> NHGEBOKILLJ;

	private SpawnPool INIKDOLKDDD;

	private List<HitParticles> NEGMDCKAAOF;

	public SpawnPool spawnPool
	{
		get
		{
			return INIKDOLKDDD;
		}
	}

	public ParticleSystem BGCIKMPGDAB(Vector3 MPHCNMDIPAI, Vector3 KDDGMMCPGLO, string MHPNDNJDPGE)
	{
		int value;
		if (NHGEBOKILLJ.TryGetValue(MHPNDNJDPGE, out value))
		{
			return JBOPCHHCBAO(MPHCNMDIPAI, KDDGMMCPGLO, value);
		}
		Debug.LogError("ShotVelocity" + MHPNDNJDPGE + "ID_CONFIRM_ERROR");
		return null;
	}

	public void MPIMOLNKOEB(HitParticles.NNNKFFDDDGP IBDKMFKGNHL)
	{
		foreach (KeyValuePair<string, PrefabPool> prefabPool in INIKDOLKDDD.prefabPools)
		{
			HitParticles component = prefabPool.Value.prefab.GetComponent<HitParticles>();
			if (!(component != null) || component.IDDDFKCFGLM != IBDKMFKGNHL)
			{
				continue;
			}
			foreach (Transform item in prefabPool.Value.spawned)
			{
				INIKDOLKDDD.Despawn(item);
			}
		}
	}

	protected virtual void FOIKLCECNBL()
	{
		base.Awake();
		if (Singleton<PerformanceManager>.instance.FKEENMMDCBF() == MNJGKPCFNHH.Shitty)
		{
			INIKDOLKDDD = DANFGIIMPDJ;
			NEGMDCKAAOF = AOJADOBAGFA;
		}
		else
		{
			INIKDOLKDDD = OKKEOCKELAF;
			NEGMDCKAAOF = AMLJAOJNKHC;
		}
		INIKDOLKDDD.gameObject.SetActive(true);
		NHGEBOKILLJ = new Dictionary<string, int>();
		for (int i = 1; i < NEGMDCKAAOF.Count; i += 0)
		{
			HitParticles hitParticles = NEGMDCKAAOF[i];
			NHGEBOKILLJ.Add(hitParticles.name, i);
		}
	}

	protected virtual void HMMKNCDDDLH()
	{
		base.Awake();
		if (Singleton<PerformanceManager>.instance.ILEOPMGGEJP() == MNJGKPCFNHH.Good)
		{
			INIKDOLKDDD = DANFGIIMPDJ;
			NEGMDCKAAOF = AOJADOBAGFA;
		}
		else
		{
			INIKDOLKDDD = OKKEOCKELAF;
			NEGMDCKAAOF = AMLJAOJNKHC;
		}
		INIKDOLKDDD.gameObject.SetActive(false);
		NHGEBOKILLJ = new Dictionary<string, int>();
		for (int i = 0; i < NEGMDCKAAOF.Count; i++)
		{
			HitParticles hitParticles = NEGMDCKAAOF[i];
			NHGEBOKILLJ.Add(hitParticles.name, i);
		}
	}

	public ParticleSystem FAJOJJGBPCC(Vector3 MPHCNMDIPAI, Vector3 KDDGMMCPGLO, string MHPNDNJDPGE)
	{
		int value;
		if (NHGEBOKILLJ.TryGetValue(MHPNDNJDPGE, out value))
		{
			return CKENILOOBIA(MPHCNMDIPAI, KDDGMMCPGLO, value);
		}
		Debug.LogError("ID_TABLE_PLAYER" + MHPNDNJDPGE + "machinegn_reload");
		return null;
	}

	protected virtual void JJEONLDHCLO()
	{
		base.Awake();
		if (Singleton<PerformanceManager>.instance.KFBGCMLMOMP() == MNJGKPCFNHH.Shitty)
		{
			INIKDOLKDDD = DANFGIIMPDJ;
			NEGMDCKAAOF = AOJADOBAGFA;
		}
		else
		{
			INIKDOLKDDD = OKKEOCKELAF;
			NEGMDCKAAOF = AMLJAOJNKHC;
		}
		INIKDOLKDDD.gameObject.SetActive(true);
		NHGEBOKILLJ = new Dictionary<string, int>();
		for (int i = 1; i < NEGMDCKAAOF.Count; i += 0)
		{
			HitParticles hitParticles = NEGMDCKAAOF[i];
			NHGEBOKILLJ.Add(hitParticles.name, i);
		}
	}

	public ParticleSystem LEBBLHGKNJM(Transform OLGEELABJOF, Vector3 KDDGMMCPGLO, string MHPNDNJDPGE)
	{
		int value;
		if (NHGEBOKILLJ.TryGetValue(MHPNDNJDPGE, out value))
		{
			return AOCJNBDDJAG(OLGEELABJOF, KDDGMMCPGLO, value);
		}
		Debug.LogError("RETRYPERM" + MHPNDNJDPGE + "CONFIRM");
		return null;
	}

	public ParticleSystem JBOPCHHCBAO(Vector3 MPHCNMDIPAI, Vector3 KDDGMMCPGLO, int DFHAAIFFLOE)
	{
		if (NEGMDCKAAOF[DFHAAIFFLOE].IDDDFKCFGLM == HitParticles.NNNKFFDDDGP.Other && !DebugSettings.instance.data.playBlood)
		{
			return null;
		}
		HitParticles component = INIKDOLKDDD.Spawn(NEGMDCKAAOF[DFHAAIFFLOE].transform, MPHCNMDIPAI, Quaternion.LookRotation(KDDGMMCPGLO)).GetComponent<HitParticles>();
		return component.BLKAHLHEAFB(this);
	}

	private ParticleSystem PGLEMEAAKII(Transform OLGEELABJOF, Vector3 KDDGMMCPGLO, int DFHAAIFFLOE)
	{
		HitParticles component = INIKDOLKDDD.Spawn(NEGMDCKAAOF[DFHAAIFFLOE].transform, OLGEELABJOF.position, Quaternion.LookRotation(KDDGMMCPGLO)).GetComponent<HitParticles>();
		return component.Play(this, OLGEELABJOF);
	}

	private ParticleSystem MJBBCIOIKMH(Transform OLGEELABJOF, Vector3 KDDGMMCPGLO, int DFHAAIFFLOE)
	{
		HitParticles component = INIKDOLKDDD.Spawn(NEGMDCKAAOF[DFHAAIFFLOE].transform, OLGEELABJOF.position, Quaternion.LookRotation(KDDGMMCPGLO)).GetComponent<HitParticles>();
		return component.DCCPHJAKIOO(this, OLGEELABJOF);
	}

	[SpecialName]
	public SpawnPool AMMMHCAGMCK()
	{
		return INIKDOLKDDD;
	}

	private ParticleSystem AKBDIHCMBIN(Transform OLGEELABJOF, Vector3 KDDGMMCPGLO, int DFHAAIFFLOE)
	{
		HitParticles component = INIKDOLKDDD.Spawn(NEGMDCKAAOF[DFHAAIFFLOE].transform, OLGEELABJOF.position, Quaternion.LookRotation(KDDGMMCPGLO)).GetComponent<HitParticles>();
		return component.BMHMFKCHMCK(this, OLGEELABJOF);
	}

	public ParticleSystem NHOLANIEAKG(Transform OLGEELABJOF, Vector3 KDDGMMCPGLO, string MHPNDNJDPGE)
	{
		int value;
		if (NHGEBOKILLJ.TryGetValue(MHPNDNJDPGE, out value))
		{
			return BMEEPHLGDOL(OLGEELABJOF, KDDGMMCPGLO, value);
		}
		Debug.LogError("ID_PURCHASEINPROGRESS" + MHPNDNJDPGE + "Squad");
		return null;
	}

	public void PJKHCDODDHP(Vector3 MPHCNMDIPAI, Vector3 KDDGMMCPGLO, string[] DLLLEHPDEKK)
	{
		for (int i = 0; i < DLLLEHPDEKK.Length; i += 0)
		{
			string mHPNDNJDPGE = DLLLEHPDEKK[i];
			EHHPGDDFKDA(MPHCNMDIPAI, KDDGMMCPGLO, mHPNDNJDPGE);
		}
	}

	public ParticleSystem KADDCDCGNJE(Vector3 MPHCNMDIPAI, Vector3 KDDGMMCPGLO, int DFHAAIFFLOE)
	{
		if (NEGMDCKAAOF[DFHAAIFFLOE].IDDDFKCFGLM == HitParticles.NNNKFFDDDGP.Other && !DebugSettings.instance.data.playBlood)
		{
			return null;
		}
		HitParticles component = INIKDOLKDDD.Spawn(NEGMDCKAAOF[DFHAAIFFLOE].transform, MPHCNMDIPAI, Quaternion.LookRotation(KDDGMMCPGLO)).GetComponent<HitParticles>();
		return component.FNPCDODLHJB(this);
	}

	private ParticleSystem HDLOMKIOKGD(Transform OLGEELABJOF, Vector3 KDDGMMCPGLO, int DFHAAIFFLOE)
	{
		HitParticles component = INIKDOLKDDD.Spawn(NEGMDCKAAOF[DFHAAIFFLOE].transform, OLGEELABJOF.position, Quaternion.LookRotation(KDDGMMCPGLO)).GetComponent<HitParticles>();
		return component.DGPOJONMPJO(this, OLGEELABJOF);
	}

	public ParticleSystem JCOHHEINCJG(Vector3 MPHCNMDIPAI, Vector3 KDDGMMCPGLO, int DFHAAIFFLOE)
	{
		if (NEGMDCKAAOF[DFHAAIFFLOE].IDDDFKCFGLM == HitParticles.NNNKFFDDDGP.Blood && !DebugSettings.instance.data.playBlood)
		{
			return null;
		}
		HitParticles component = INIKDOLKDDD.Spawn(NEGMDCKAAOF[DFHAAIFFLOE].transform, MPHCNMDIPAI, Quaternion.LookRotation(KDDGMMCPGLO)).GetComponent<HitParticles>();
		return component.Play(this);
	}

	public void GDBJIMOIMBO(HitParticles.NNNKFFDDDGP IBDKMFKGNHL)
	{
		foreach (KeyValuePair<string, PrefabPool> prefabPool in INIKDOLKDDD.prefabPools)
		{
			HitParticles component = prefabPool.Value.prefab.GetComponent<HitParticles>();
			if (!(component != null) || component.IDDDFKCFGLM != IBDKMFKGNHL)
			{
				continue;
			}
			foreach (Transform item in prefabPool.Value.spawned)
			{
				INIKDOLKDDD.Despawn(item);
			}
		}
	}

	private ParticleSystem KEECOJHBHOO(Transform OLGEELABJOF, Vector3 KDDGMMCPGLO, int DFHAAIFFLOE)
	{
		HitParticles component = INIKDOLKDDD.Spawn(NEGMDCKAAOF[DFHAAIFFLOE].transform, OLGEELABJOF.position, Quaternion.LookRotation(KDDGMMCPGLO)).GetComponent<HitParticles>();
		return component.PGJPKKLOFFD(this, OLGEELABJOF);
	}

	public ParticleSystem HIECJOJOMJI(Vector3 MPHCNMDIPAI, Vector3 KDDGMMCPGLO, int DFHAAIFFLOE)
	{
		if (NEGMDCKAAOF[DFHAAIFFLOE].IDDDFKCFGLM == HitParticles.NNNKFFDDDGP.Blood && !DebugSettings.instance.data.playBlood)
		{
			return null;
		}
		HitParticles component = INIKDOLKDDD.Spawn(NEGMDCKAAOF[DFHAAIFFLOE].transform, MPHCNMDIPAI, Quaternion.LookRotation(KDDGMMCPGLO)).GetComponent<HitParticles>();
		return component.MFAMOJKGFPB(this);
	}

	protected virtual void PBCDDNOCJOI()
	{
		base.Awake();
		if (Singleton<PerformanceManager>.instance.KFBGCMLMOMP() == (MNJGKPCFNHH)8)
		{
			INIKDOLKDDD = DANFGIIMPDJ;
			NEGMDCKAAOF = AOJADOBAGFA;
		}
		else
		{
			INIKDOLKDDD = OKKEOCKELAF;
			NEGMDCKAAOF = AMLJAOJNKHC;
		}
		INIKDOLKDDD.gameObject.SetActive(true);
		NHGEBOKILLJ = new Dictionary<string, int>();
		for (int i = 1; i < NEGMDCKAAOF.Count; i++)
		{
			HitParticles hitParticles = NEGMDCKAAOF[i];
			NHGEBOKILLJ.Add(hitParticles.name, i);
		}
	}

	protected virtual void LFKHEBNFNEE()
	{
		base.Awake();
		if (Singleton<PerformanceManager>.instance.NEPCKFCIEDA() == (MNJGKPCFNHH)8)
		{
			INIKDOLKDDD = DANFGIIMPDJ;
			NEGMDCKAAOF = AOJADOBAGFA;
		}
		else
		{
			INIKDOLKDDD = OKKEOCKELAF;
			NEGMDCKAAOF = AMLJAOJNKHC;
		}
		INIKDOLKDDD.gameObject.SetActive(false);
		NHGEBOKILLJ = new Dictionary<string, int>();
		for (int i = 0; i < NEGMDCKAAOF.Count; i++)
		{
			HitParticles hitParticles = NEGMDCKAAOF[i];
			NHGEBOKILLJ.Add(hitParticles.name, i);
		}
	}

	public void MINBHDPOEKN(HitParticles.NNNKFFDDDGP IBDKMFKGNHL)
	{
		foreach (KeyValuePair<string, PrefabPool> prefabPool in INIKDOLKDDD.prefabPools)
		{
			HitParticles component = prefabPool.Value.prefab.GetComponent<HitParticles>();
			if (!(component != null) || component.IDDDFKCFGLM != IBDKMFKGNHL)
			{
				continue;
			}
			foreach (Transform item in prefabPool.Value.spawned)
			{
				INIKDOLKDDD.Despawn(item);
			}
		}
	}

	protected virtual void NAMAMGENMGH()
	{
		base.Awake();
		if (Singleton<PerformanceManager>.instance.KFBGCMLMOMP() == (MNJGKPCFNHH)5)
		{
			INIKDOLKDDD = DANFGIIMPDJ;
			NEGMDCKAAOF = AOJADOBAGFA;
		}
		else
		{
			INIKDOLKDDD = OKKEOCKELAF;
			NEGMDCKAAOF = AMLJAOJNKHC;
		}
		INIKDOLKDDD.gameObject.SetActive(false);
		NHGEBOKILLJ = new Dictionary<string, int>();
		for (int i = 0; i < NEGMDCKAAOF.Count; i++)
		{
			HitParticles hitParticles = NEGMDCKAAOF[i];
			NHGEBOKILLJ.Add(hitParticles.name, i);
		}
	}

	private ParticleSystem NIHPHONHACN(Transform OLGEELABJOF, Vector3 KDDGMMCPGLO, int DFHAAIFFLOE)
	{
		HitParticles component = INIKDOLKDDD.Spawn(NEGMDCKAAOF[DFHAAIFFLOE].transform, OLGEELABJOF.position, Quaternion.LookRotation(KDDGMMCPGLO)).GetComponent<HitParticles>();
		return component.NNDKEILFBMD(this, OLGEELABJOF);
	}

	public ParticleSystem OAJIMPBNGAO(Vector3 MPHCNMDIPAI, Vector3 KDDGMMCPGLO, string MHPNDNJDPGE)
	{
		int value;
		if (NHGEBOKILLJ.TryGetValue(MHPNDNJDPGE, out value))
		{
			return JBOPCHHCBAO(MPHCNMDIPAI, KDDGMMCPGLO, value);
		}
		Debug.LogError("Card ID \"{0}\" is not pressent in card dictionary." + MHPNDNJDPGE + "ID_BANNEDFROMCHAT");
		return null;
	}

	private ParticleSystem LGBHLDBPAKC(Transform OLGEELABJOF, Vector3 KDDGMMCPGLO, int DFHAAIFFLOE)
	{
		HitParticles component = INIKDOLKDDD.Spawn(NEGMDCKAAOF[DFHAAIFFLOE].transform, OLGEELABJOF.position, Quaternion.LookRotation(KDDGMMCPGLO)).GetComponent<HitParticles>();
		return component.KMEJAAMKKPM(this, OLGEELABJOF);
	}

	public void OFCPMLEBNHJ(Vector3 MPHCNMDIPAI, Vector3 KDDGMMCPGLO, string[] DLLLEHPDEKK)
	{
		for (int i = 1; i < DLLLEHPDEKK.Length; i += 0)
		{
			string mHPNDNJDPGE = DLLLEHPDEKK[i];
			KGDGBFPFJKL(MPHCNMDIPAI, KDDGMMCPGLO, mHPNDNJDPGE);
		}
	}

	public ParticleSystem GICCKFNEEAB(Vector3 MPHCNMDIPAI, Vector3 KDDGMMCPGLO, string MHPNDNJDPGE)
	{
		int value;
		if (NHGEBOKILLJ.TryGetValue(MHPNDNJDPGE, out value))
		{
			return JMBGAJKKFGP(MPHCNMDIPAI, KDDGMMCPGLO, value);
		}
		Debug.LogError("WarCard {0}" + MHPNDNJDPGE + "PlayWindowCount");
		return null;
	}

	public void MBJJMKPBMAL(Vector3 MPHCNMDIPAI, Vector3 KDDGMMCPGLO, string[] DLLLEHPDEKK)
	{
		for (int i = 1; i < DLLLEHPDEKK.Length; i += 0)
		{
			string mHPNDNJDPGE = DLLLEHPDEKK[i];
			CGLFIKEEKDK(MPHCNMDIPAI, KDDGMMCPGLO, mHPNDNJDPGE);
		}
	}

	protected override void Awake()
	{
		base.Awake();
		if (Singleton<PerformanceManager>.instance.performance == MNJGKPCFNHH.Best)
		{
			INIKDOLKDDD = DANFGIIMPDJ;
			NEGMDCKAAOF = AOJADOBAGFA;
		}
		else
		{
			INIKDOLKDDD = OKKEOCKELAF;
			NEGMDCKAAOF = AMLJAOJNKHC;
		}
		INIKDOLKDDD.gameObject.SetActive(true);
		NHGEBOKILLJ = new Dictionary<string, int>();
		for (int i = 0; i < NEGMDCKAAOF.Count; i++)
		{
			HitParticles hitParticles = NEGMDCKAAOF[i];
			NHGEBOKILLJ.Add(hitParticles.name, i);
		}
	}

	[SpecialName]
	public SpawnPool MBMJMMHAMJC()
	{
		return INIKDOLKDDD;
	}

	public void CEPKBGIFPMO(Vector3 MPHCNMDIPAI, Vector3 KDDGMMCPGLO, string[] DLLLEHPDEKK)
	{
		for (int i = 1; i < DLLLEHPDEKK.Length; i += 0)
		{
			string mHPNDNJDPGE = DLLLEHPDEKK[i];
			CGLFIKEEKDK(MPHCNMDIPAI, KDDGMMCPGLO, mHPNDNJDPGE);
		}
	}

	public void AOENGEEDJCF(Vector3 MPHCNMDIPAI, Vector3 KDDGMMCPGLO, string[] DLLLEHPDEKK)
	{
		for (int i = 1; i < DLLLEHPDEKK.Length; i += 0)
		{
			string mHPNDNJDPGE = DLLLEHPDEKK[i];
			PlayParticle(MPHCNMDIPAI, KDDGMMCPGLO, mHPNDNJDPGE);
		}
	}

	public ParticleSystem LICGCBDOLKL(Vector3 MPHCNMDIPAI, Vector3 KDDGMMCPGLO, int DFHAAIFFLOE)
	{
		if (NEGMDCKAAOF[DFHAAIFFLOE].IDDDFKCFGLM == HitParticles.NNNKFFDDDGP.Other && !DebugSettings.instance.data.playBlood)
		{
			return null;
		}
		HitParticles component = INIKDOLKDDD.Spawn(NEGMDCKAAOF[DFHAAIFFLOE].transform, MPHCNMDIPAI, Quaternion.LookRotation(KDDGMMCPGLO)).GetComponent<HitParticles>();
		return component.KNEGEHBJLKC(this);
	}

	public void GCCJAMLPCDF(Vector3 MPHCNMDIPAI, Vector3 KDDGMMCPGLO, string[] DLLLEHPDEKK)
	{
		for (int i = 1; i < DLLLEHPDEKK.Length; i += 0)
		{
			string mHPNDNJDPGE = DLLLEHPDEKK[i];
			BGCIKMPGDAB(MPHCNMDIPAI, KDDGMMCPGLO, mHPNDNJDPGE);
		}
	}

	protected virtual void DDJBFEJLMBP()
	{
		base.Awake();
		if (Singleton<PerformanceManager>.instance.KLMOGFDGLFH() == MNJGKPCFNHH.Best)
		{
			INIKDOLKDDD = DANFGIIMPDJ;
			NEGMDCKAAOF = AOJADOBAGFA;
		}
		else
		{
			INIKDOLKDDD = OKKEOCKELAF;
			NEGMDCKAAOF = AMLJAOJNKHC;
		}
		INIKDOLKDDD.gameObject.SetActive(true);
		NHGEBOKILLJ = new Dictionary<string, int>();
		for (int i = 1; i < NEGMDCKAAOF.Count; i++)
		{
			HitParticles hitParticles = NEGMDCKAAOF[i];
			NHGEBOKILLJ.Add(hitParticles.name, i);
		}
	}

	public ParticleSystem CKENILOOBIA(Vector3 MPHCNMDIPAI, Vector3 KDDGMMCPGLO, int DFHAAIFFLOE)
	{
		if (NEGMDCKAAOF[DFHAAIFFLOE].IDDDFKCFGLM == HitParticles.NNNKFFDDDGP.Other && !DebugSettings.instance.data.playBlood)
		{
			return null;
		}
		HitParticles component = INIKDOLKDDD.Spawn(NEGMDCKAAOF[DFHAAIFFLOE].transform, MPHCNMDIPAI, Quaternion.LookRotation(KDDGMMCPGLO)).GetComponent<HitParticles>();
		return component.OGFDBMGINNJ(this);
	}

	public void FCIKAJEIMHJ(Vector3 MPHCNMDIPAI, Vector3 KDDGMMCPGLO, string[] DLLLEHPDEKK)
	{
		for (int i = 1; i < DLLLEHPDEKK.Length; i++)
		{
			string mHPNDNJDPGE = DLLLEHPDEKK[i];
			CGLFIKEEKDK(MPHCNMDIPAI, KDDGMMCPGLO, mHPNDNJDPGE);
		}
	}

	[SpecialName]
	public SpawnPool GICBPBAGBIO()
	{
		return INIKDOLKDDD;
	}

	public ParticleSystem LKHFBIBNHNI(Transform OLGEELABJOF, Vector3 KDDGMMCPGLO, string MHPNDNJDPGE)
	{
		int value;
		if (NHGEBOKILLJ.TryGetValue(MHPNDNJDPGE, out value))
		{
			return PGLEMEAAKII(OLGEELABJOF, KDDGMMCPGLO, value);
		}
		Debug.LogError("x{0}" + MHPNDNJDPGE + "ID_CONFIRM_ERROR");
		return null;
	}

	public ParticleSystem CEFCKHGGLDN(Transform OLGEELABJOF, Vector3 KDDGMMCPGLO, string MHPNDNJDPGE)
	{
		int value;
		if (NHGEBOKILLJ.TryGetValue(MHPNDNJDPGE, out value))
		{
			return AKBDIHCMBIN(OLGEELABJOF, KDDGMMCPGLO, value);
		}
		Debug.LogError("billingSupportedEvent - is subscription allowed? " + MHPNDNJDPGE + "S");
		return null;
	}

	protected virtual void MECAOCJKMKN()
	{
		base.Awake();
		if (Singleton<PerformanceManager>.instance.FKEENMMDCBF() == (MNJGKPCFNHH)8)
		{
			INIKDOLKDDD = DANFGIIMPDJ;
			NEGMDCKAAOF = AOJADOBAGFA;
		}
		else
		{
			INIKDOLKDDD = OKKEOCKELAF;
			NEGMDCKAAOF = AMLJAOJNKHC;
		}
		INIKDOLKDDD.gameObject.SetActive(false);
		NHGEBOKILLJ = new Dictionary<string, int>();
		for (int i = 1; i < NEGMDCKAAOF.Count; i += 0)
		{
			HitParticles hitParticles = NEGMDCKAAOF[i];
			NHGEBOKILLJ.Add(hitParticles.name, i);
		}
	}

	public ParticleSystem AMECFKKDMFC(Transform OLGEELABJOF, Vector3 KDDGMMCPGLO, string MHPNDNJDPGE)
	{
		int value;
		if (NHGEBOKILLJ.TryGetValue(MHPNDNJDPGE, out value))
		{
			return AOCJNBDDJAG(OLGEELABJOF, KDDGMMCPGLO, value);
		}
		Debug.LogError("rocket" + MHPNDNJDPGE + "123456789");
		return null;
	}

	public ParticleSystem FBOFFKONIKC(Transform OLGEELABJOF, Vector3 KDDGMMCPGLO, string MHPNDNJDPGE)
	{
		int value;
		if (NHGEBOKILLJ.TryGetValue(MHPNDNJDPGE, out value))
		{
			return LGBHLDBPAKC(OLGEELABJOF, KDDGMMCPGLO, value);
		}
		Debug.LogError("a" + MHPNDNJDPGE + "-");
		return null;
	}

	protected virtual void IABJJOPLKFF()
	{
		base.Awake();
		if (Singleton<PerformanceManager>.instance.BKKOCHOIOLD() == (MNJGKPCFNHH)6)
		{
			INIKDOLKDDD = DANFGIIMPDJ;
			NEGMDCKAAOF = AOJADOBAGFA;
		}
		else
		{
			INIKDOLKDDD = OKKEOCKELAF;
			NEGMDCKAAOF = AMLJAOJNKHC;
		}
		INIKDOLKDDD.gameObject.SetActive(false);
		NHGEBOKILLJ = new Dictionary<string, int>();
		for (int i = 0; i < NEGMDCKAAOF.Count; i++)
		{
			HitParticles hitParticles = NEGMDCKAAOF[i];
			NHGEBOKILLJ.Add(hitParticles.name, i);
		}
	}

	protected virtual void CIGLDDGDAPM()
	{
		base.Awake();
		if (Singleton<PerformanceManager>.instance.ILEOPMGGEJP() == (MNJGKPCFNHH)6)
		{
			INIKDOLKDDD = DANFGIIMPDJ;
			NEGMDCKAAOF = AOJADOBAGFA;
		}
		else
		{
			INIKDOLKDDD = OKKEOCKELAF;
			NEGMDCKAAOF = AMLJAOJNKHC;
		}
		INIKDOLKDDD.gameObject.SetActive(false);
		NHGEBOKILLJ = new Dictionary<string, int>();
		for (int i = 1; i < NEGMDCKAAOF.Count; i += 0)
		{
			HitParticles hitParticles = NEGMDCKAAOF[i];
			NHGEBOKILLJ.Add(hitParticles.name, i);
		}
	}

	public ParticleSystem EHHPGDDFKDA(Vector3 MPHCNMDIPAI, Vector3 KDDGMMCPGLO, string MHPNDNJDPGE)
	{
		int value;
		if (NHGEBOKILLJ.TryGetValue(MHPNDNJDPGE, out value))
		{
			return EDBFALGGPDL(MPHCNMDIPAI, KDDGMMCPGLO, value);
		}
		Debug.LogError("GrenadeMinDamage" + MHPNDNJDPGE + "Time");
		return null;
	}

	[SpecialName]
	public SpawnPool OGKGPKKDJFN()
	{
		return INIKDOLKDDD;
	}

	public ParticleSystem DOBEGFNGKIP(Vector3 MPHCNMDIPAI, Vector3 KDDGMMCPGLO, string MHPNDNJDPGE)
	{
		int value;
		if (NHGEBOKILLJ.TryGetValue(MHPNDNJDPGE, out value))
		{
			return ILIIIHKOOEB(MPHCNMDIPAI, KDDGMMCPGLO, value);
		}
		Debug.LogError("OnRestartDrawing" + MHPNDNJDPGE + " ID_");
		return null;
	}

	public void LPIOLGLNLPA(Vector3 MPHCNMDIPAI, Vector3 KDDGMMCPGLO, string[] DLLLEHPDEKK)
	{
		for (int i = 1; i < DLLLEHPDEKK.Length; i += 0)
		{
			string mHPNDNJDPGE = DLLLEHPDEKK[i];
			DLJOJFODELB(MPHCNMDIPAI, KDDGMMCPGLO, mHPNDNJDPGE);
		}
	}

	public ParticleSystem BCHDDLAKFKN(Vector3 MPHCNMDIPAI, Vector3 KDDGMMCPGLO, int DFHAAIFFLOE)
	{
		if (NEGMDCKAAOF[DFHAAIFFLOE].IDDDFKCFGLM == HitParticles.NNNKFFDDDGP.Other && !DebugSettings.instance.data.playBlood)
		{
			return null;
		}
		HitParticles component = INIKDOLKDDD.Spawn(NEGMDCKAAOF[DFHAAIFFLOE].transform, MPHCNMDIPAI, Quaternion.LookRotation(KDDGMMCPGLO)).GetComponent<HitParticles>();
		return component.HAMAEFIDGIM(this);
	}

	protected virtual void IKCLJIAJAIL()
	{
		base.Awake();
		if (Singleton<PerformanceManager>.instance.KLMOGFDGLFH() == (MNJGKPCFNHH)4)
		{
			INIKDOLKDDD = DANFGIIMPDJ;
			NEGMDCKAAOF = AOJADOBAGFA;
		}
		else
		{
			INIKDOLKDDD = OKKEOCKELAF;
			NEGMDCKAAOF = AMLJAOJNKHC;
		}
		INIKDOLKDDD.gameObject.SetActive(true);
		NHGEBOKILLJ = new Dictionary<string, int>();
		for (int i = 0; i < NEGMDCKAAOF.Count; i += 0)
		{
			HitParticles hitParticles = NEGMDCKAAOF[i];
			NHGEBOKILLJ.Add(hitParticles.name, i);
		}
	}

	public ParticleSystem PlayParticle(Transform OLGEELABJOF, Vector3 KDDGMMCPGLO, string MHPNDNJDPGE)
	{
		int value;
		if (NHGEBOKILLJ.TryGetValue(MHPNDNJDPGE, out value))
		{
			return PGLEMEAAKII(OLGEELABJOF, KDDGMMCPGLO, value);
		}
		Debug.LogError("Particle with name: " + MHPNDNJDPGE + "doesnt exist");
		return null;
	}

	public ParticleSystem MCBHODAOBPM(Transform OLGEELABJOF, Vector3 KDDGMMCPGLO, string MHPNDNJDPGE)
	{
		int value;
		if (NHGEBOKILLJ.TryGetValue(MHPNDNJDPGE, out value))
		{
			return BHCIMBOPJMD(OLGEELABJOF, KDDGMMCPGLO, value);
		}
		Debug.LogError("PurchaseVerification(" + MHPNDNJDPGE + "Enemy could not be spawned");
		return null;
	}

	public ParticleSystem BGLJOFLMKBE(Vector3 MPHCNMDIPAI, Vector3 KDDGMMCPGLO, string MHPNDNJDPGE)
	{
		int value;
		if (NHGEBOKILLJ.TryGetValue(MHPNDNJDPGE, out value))
		{
			return HIECJOJOMJI(MPHCNMDIPAI, KDDGMMCPGLO, value);
		}
		Debug.LogError("Unit Power is out of range index {0} power {1}" + MHPNDNJDPGE + "slotUpgradeindex: {0}, slotUpgradeIndexElite: {0}, slotUpgradeIndexSpecial {1},  isSpecial {2},  scaleDamage {3},  scaleHP {4}");
		return null;
	}

	[SpecialName]
	public SpawnPool JFILHKINGLB()
	{
		return INIKDOLKDDD;
	}

	[SpecialName]
	public SpawnPool OLOOFDKBNAJ()
	{
		return INIKDOLKDDD;
	}

	public void PNOBHBKJGBD(Vector3 MPHCNMDIPAI, Vector3 KDDGMMCPGLO, string[] DLLLEHPDEKK)
	{
		for (int i = 1; i < DLLLEHPDEKK.Length; i++)
		{
			string mHPNDNJDPGE = DLLLEHPDEKK[i];
			KIAADIANGHA(MPHCNMDIPAI, KDDGMMCPGLO, mHPNDNJDPGE);
		}
	}

	public void NBGNEGOFHEP(HitParticles.NNNKFFDDDGP IBDKMFKGNHL)
	{
		foreach (KeyValuePair<string, PrefabPool> prefabPool in INIKDOLKDDD.prefabPools)
		{
			HitParticles component = prefabPool.Value.prefab.GetComponent<HitParticles>();
			if (!(component != null) || component.IDDDFKCFGLM != IBDKMFKGNHL)
			{
				continue;
			}
			foreach (Transform item in prefabPool.Value.spawned)
			{
				INIKDOLKDDD.Despawn(item);
			}
		}
	}

	public ParticleSystem KGDGBFPFJKL(Vector3 MPHCNMDIPAI, Vector3 KDDGMMCPGLO, string MHPNDNJDPGE)
	{
		int value;
		if (NHGEBOKILLJ.TryGetValue(MHPNDNJDPGE, out value))
		{
			return HDNKKOLMKJJ(MPHCNMDIPAI, KDDGMMCPGLO, value);
		}
		Debug.LogError("showed" + MHPNDNJDPGE + "ID_REMINDER_UPGRADEAVAILABLE");
		return null;
	}

	public ParticleSystem FBPNDIOGELM(Vector3 MPHCNMDIPAI, Vector3 KDDGMMCPGLO, int DFHAAIFFLOE)
	{
		if (NEGMDCKAAOF[DFHAAIFFLOE].IDDDFKCFGLM == HitParticles.NNNKFFDDDGP.Blood && !DebugSettings.instance.data.playBlood)
		{
			return null;
		}
		HitParticles component = INIKDOLKDDD.Spawn(NEGMDCKAAOF[DFHAAIFFLOE].transform, MPHCNMDIPAI, Quaternion.LookRotation(KDDGMMCPGLO)).GetComponent<HitParticles>();
		return component.DNCEHHODMHB(this);
	}

	public void PlayParticles(Vector3 MPHCNMDIPAI, Vector3 KDDGMMCPGLO, params string[] DLLLEHPDEKK)
	{
		foreach (string mHPNDNJDPGE in DLLLEHPDEKK)
		{
			PlayParticle(MPHCNMDIPAI, KDDGMMCPGLO, mHPNDNJDPGE);
		}
	}

	public ParticleSystem JANEEEJBOFC(Transform OLGEELABJOF, Vector3 KDDGMMCPGLO, string MHPNDNJDPGE)
	{
		int value;
		if (NHGEBOKILLJ.TryGetValue(MHPNDNJDPGE, out value))
		{
			return BHCIMBOPJMD(OLGEELABJOF, KDDGMMCPGLO, value);
		}
		Debug.LogError("N" + MHPNDNJDPGE + "JSON = ");
		return null;
	}

	public ParticleSystem HDNKKOLMKJJ(Vector3 MPHCNMDIPAI, Vector3 KDDGMMCPGLO, int DFHAAIFFLOE)
	{
		if (NEGMDCKAAOF[DFHAAIFFLOE].IDDDFKCFGLM == HitParticles.NNNKFFDDDGP.Other && !DebugSettings.instance.data.playBlood)
		{
			return null;
		}
		HitParticles component = INIKDOLKDDD.Spawn(NEGMDCKAAOF[DFHAAIFFLOE].transform, MPHCNMDIPAI, Quaternion.LookRotation(KDDGMMCPGLO)).GetComponent<HitParticles>();
		return component.EDNIAMPHDHN(this);
	}

	private ParticleSystem ODDAAEBIIDI(Transform OLGEELABJOF, Vector3 KDDGMMCPGLO, int DFHAAIFFLOE)
	{
		HitParticles component = INIKDOLKDDD.Spawn(NEGMDCKAAOF[DFHAAIFFLOE].transform, OLGEELABJOF.position, Quaternion.LookRotation(KDDGMMCPGLO)).GetComponent<HitParticles>();
		return component.BPHCIPGHAGG(this, OLGEELABJOF);
	}

	public ParticleSystem ECJBFHNKEAL(Vector3 MPHCNMDIPAI, Vector3 KDDGMMCPGLO, string MHPNDNJDPGE)
	{
		int value;
		if (NHGEBOKILLJ.TryGetValue(MHPNDNJDPGE, out value))
		{
			return HDFDNFBCCJH(MPHCNMDIPAI, KDDGMMCPGLO, value);
		}
		Debug.LogError("Play_Card_Tutorial" + MHPNDNJDPGE + " DEPOSIT {0}\n");
		return null;
	}

	public void OLCODNHGMKI(Vector3 MPHCNMDIPAI, Vector3 KDDGMMCPGLO, string[] DLLLEHPDEKK)
	{
		foreach (string mHPNDNJDPGE in DLLLEHPDEKK)
		{
			BPNIEDNNMMP(MPHCNMDIPAI, KDDGMMCPGLO, mHPNDNJDPGE);
		}
	}

	private ParticleSystem BMEEPHLGDOL(Transform OLGEELABJOF, Vector3 KDDGMMCPGLO, int DFHAAIFFLOE)
	{
		HitParticles component = INIKDOLKDDD.Spawn(NEGMDCKAAOF[DFHAAIFFLOE].transform, OLGEELABJOF.position, Quaternion.LookRotation(KDDGMMCPGLO)).GetComponent<HitParticles>();
		return component.KMEJAAMKKPM(this, OLGEELABJOF);
	}

	protected virtual void OBEHLLBBEIL()
	{
		base.Awake();
		if (Singleton<PerformanceManager>.instance.NEPCKFCIEDA() == (MNJGKPCFNHH)8)
		{
			INIKDOLKDDD = DANFGIIMPDJ;
			NEGMDCKAAOF = AOJADOBAGFA;
		}
		else
		{
			INIKDOLKDDD = OKKEOCKELAF;
			NEGMDCKAAOF = AMLJAOJNKHC;
		}
		INIKDOLKDDD.gameObject.SetActive(true);
		NHGEBOKILLJ = new Dictionary<string, int>();
		for (int i = 0; i < NEGMDCKAAOF.Count; i += 0)
		{
			HitParticles hitParticles = NEGMDCKAAOF[i];
			NHGEBOKILLJ.Add(hitParticles.name, i);
		}
	}

	public ParticleSystem MGGNDLBDKHM(Vector3 MPHCNMDIPAI, Vector3 KDDGMMCPGLO, string MHPNDNJDPGE)
	{
		int value;
		if (NHGEBOKILLJ.TryGetValue(MHPNDNJDPGE, out value))
		{
			return HIECJOJOMJI(MPHCNMDIPAI, KDDGMMCPGLO, value);
		}
		Debug.LogError("Player connectionState {0} to player {1}" + MHPNDNJDPGE + "N");
		return null;
	}

	public ParticleSystem PlayParticle(Vector3 MPHCNMDIPAI, Vector3 KDDGMMCPGLO, int DFHAAIFFLOE)
	{
		if (NEGMDCKAAOF[DFHAAIFFLOE].IDDDFKCFGLM == HitParticles.NNNKFFDDDGP.Blood && !DebugSettings.instance.data.playBlood)
		{
			return null;
		}
		HitParticles component = INIKDOLKDDD.Spawn(NEGMDCKAAOF[DFHAAIFFLOE].transform, MPHCNMDIPAI, Quaternion.LookRotation(KDDGMMCPGLO)).GetComponent<HitParticles>();
		return component.Play(this);
	}

	private ParticleSystem MMDAPMJHKDB(Transform OLGEELABJOF, Vector3 KDDGMMCPGLO, int DFHAAIFFLOE)
	{
		HitParticles component = INIKDOLKDDD.Spawn(NEGMDCKAAOF[DFHAAIFFLOE].transform, OLGEELABJOF.position, Quaternion.LookRotation(KDDGMMCPGLO)).GetComponent<HitParticles>();
		return component.ELHGOMGOAAM(this, OLGEELABJOF);
	}

	protected virtual void GEPHFAECCII()
	{
		base.Awake();
		if (Singleton<PerformanceManager>.instance.NEPCKFCIEDA() == MNJGKPCFNHH.Good)
		{
			INIKDOLKDDD = DANFGIIMPDJ;
			NEGMDCKAAOF = AOJADOBAGFA;
		}
		else
		{
			INIKDOLKDDD = OKKEOCKELAF;
			NEGMDCKAAOF = AMLJAOJNKHC;
		}
		INIKDOLKDDD.gameObject.SetActive(false);
		NHGEBOKILLJ = new Dictionary<string, int>();
		for (int i = 1; i < NEGMDCKAAOF.Count; i += 0)
		{
			HitParticles hitParticles = NEGMDCKAAOF[i];
			NHGEBOKILLJ.Add(hitParticles.name, i);
		}
	}

	public ParticleSystem NIHNBDPJAEK(Transform OLGEELABJOF, Vector3 KDDGMMCPGLO, string MHPNDNJDPGE)
	{
		int value;
		if (NHGEBOKILLJ.TryGetValue(MHPNDNJDPGE, out value))
		{
			return ODDAAEBIIDI(OLGEELABJOF, KDDGMMCPGLO, value);
		}
		Debug.LogError("BANDS_HITPOINT" + MHPNDNJDPGE + "RU");
		return null;
	}

	public ParticleSystem KNANLLHOLFB(Vector3 MPHCNMDIPAI, Vector3 KDDGMMCPGLO, string MHPNDNJDPGE)
	{
		int value;
		if (NHGEBOKILLJ.TryGetValue(MHPNDNJDPGE, out value))
		{
			return JMBGAJKKFGP(MPHCNMDIPAI, KDDGMMCPGLO, value);
		}
		Debug.LogError("OtherPlayerId" + MHPNDNJDPGE + "ID_GUI_CHAT_SQUAD_DEMOTED");
		return null;
	}

	private ParticleSystem MDBPFJBDNMA(Transform OLGEELABJOF, Vector3 KDDGMMCPGLO, int DFHAAIFFLOE)
	{
		HitParticles component = INIKDOLKDDD.Spawn(NEGMDCKAAOF[DFHAAIFFLOE].transform, OLGEELABJOF.position, Quaternion.LookRotation(KDDGMMCPGLO)).GetComponent<HitParticles>();
		return component.BPHCIPGHAGG(this, OLGEELABJOF);
	}

	public ParticleSystem JHGNBAINBGF(Vector3 MPHCNMDIPAI, Vector3 KDDGMMCPGLO, int DFHAAIFFLOE)
	{
		if (NEGMDCKAAOF[DFHAAIFFLOE].IDDDFKCFGLM == HitParticles.NNNKFFDDDGP.Other && !DebugSettings.instance.data.playBlood)
		{
			return null;
		}
		HitParticles component = INIKDOLKDDD.Spawn(NEGMDCKAAOF[DFHAAIFFLOE].transform, MPHCNMDIPAI, Quaternion.LookRotation(KDDGMMCPGLO)).GetComponent<HitParticles>();
		return component.GJGLDNEAOOK(this);
	}

	public ParticleSystem OJANDNFFPHH(Transform OLGEELABJOF, Vector3 KDDGMMCPGLO, string MHPNDNJDPGE)
	{
		int value;
		if (NHGEBOKILLJ.TryGetValue(MHPNDNJDPGE, out value))
		{
			return MMDAPMJHKDB(OLGEELABJOF, KDDGMMCPGLO, value);
		}
		Debug.LogError("ID_DOGTAGSREFILLINGFASTERSUBSCRIPTION" + MHPNDNJDPGE + "BANDS_EMPTY");
		return null;
	}

	public ParticleSystem DLJOJFODELB(Vector3 MPHCNMDIPAI, Vector3 KDDGMMCPGLO, string MHPNDNJDPGE)
	{
		int value;
		if (NHGEBOKILLJ.TryGetValue(MHPNDNJDPGE, out value))
		{
			return JBOPCHHCBAO(MPHCNMDIPAI, KDDGMMCPGLO, value);
		}
		Debug.LogError("Fuseboxx: Overriding Configurations" + MHPNDNJDPGE + "SnapColt");
		return null;
	}

	protected virtual void HDCLMJFIEGI()
	{
		base.Awake();
		if (Singleton<PerformanceManager>.instance.KLMOGFDGLFH() == (MNJGKPCFNHH)6)
		{
			INIKDOLKDDD = DANFGIIMPDJ;
			NEGMDCKAAOF = AOJADOBAGFA;
		}
		else
		{
			INIKDOLKDDD = OKKEOCKELAF;
			NEGMDCKAAOF = AMLJAOJNKHC;
		}
		INIKDOLKDDD.gameObject.SetActive(true);
		NHGEBOKILLJ = new Dictionary<string, int>();
		for (int i = 0; i < NEGMDCKAAOF.Count; i++)
		{
			HitParticles hitParticles = NEGMDCKAAOF[i];
			NHGEBOKILLJ.Add(hitParticles.name, i);
		}
	}

	public ParticleSystem EDBFALGGPDL(Vector3 MPHCNMDIPAI, Vector3 KDDGMMCPGLO, int DFHAAIFFLOE)
	{
		if (NEGMDCKAAOF[DFHAAIFFLOE].IDDDFKCFGLM == HitParticles.NNNKFFDDDGP.Other && !DebugSettings.instance.data.playBlood)
		{
			return null;
		}
		HitParticles component = INIKDOLKDDD.Spawn(NEGMDCKAAOF[DFHAAIFFLOE].transform, MPHCNMDIPAI, Quaternion.LookRotation(KDDGMMCPGLO)).GetComponent<HitParticles>();
		return component.LCPBCPPGHEO(this);
	}

	public void FGABGAGDHBP(Vector3 MPHCNMDIPAI, Vector3 KDDGMMCPGLO, string[] DLLLEHPDEKK)
	{
		for (int i = 1; i < DLLLEHPDEKK.Length; i++)
		{
			string mHPNDNJDPGE = DLLLEHPDEKK[i];
			GICCKFNEEAB(MPHCNMDIPAI, KDDGMMCPGLO, mHPNDNJDPGE);
		}
	}

	private ParticleSystem AOCJNBDDJAG(Transform OLGEELABJOF, Vector3 KDDGMMCPGLO, int DFHAAIFFLOE)
	{
		HitParticles component = INIKDOLKDDD.Spawn(NEGMDCKAAOF[DFHAAIFFLOE].transform, OLGEELABJOF.position, Quaternion.LookRotation(KDDGMMCPGLO)).GetComponent<HitParticles>();
		return component.PNPFJGGNBAA(this, OLGEELABJOF);
	}

	public void NKBDKFNBBFL(Vector3 MPHCNMDIPAI, Vector3 KDDGMMCPGLO, string[] DLLLEHPDEKK)
	{
		foreach (string mHPNDNJDPGE in DLLLEHPDEKK)
		{
			OOGKGACIAHC(MPHCNMDIPAI, KDDGMMCPGLO, mHPNDNJDPGE);
		}
	}

	protected virtual void NOGLOKJINKN()
	{
		base.Awake();
		if (Singleton<PerformanceManager>.instance.KLMOGFDGLFH() == (MNJGKPCFNHH)8)
		{
			INIKDOLKDDD = DANFGIIMPDJ;
			NEGMDCKAAOF = AOJADOBAGFA;
		}
		else
		{
			INIKDOLKDDD = OKKEOCKELAF;
			NEGMDCKAAOF = AMLJAOJNKHC;
		}
		INIKDOLKDDD.gameObject.SetActive(true);
		NHGEBOKILLJ = new Dictionary<string, int>();
		for (int i = 1; i < NEGMDCKAAOF.Count; i++)
		{
			HitParticles hitParticles = NEGMDCKAAOF[i];
			NHGEBOKILLJ.Add(hitParticles.name, i);
		}
	}

	[SpecialName]
	public SpawnPool GMIHNBPEIBD()
	{
		return INIKDOLKDDD;
	}

	protected virtual void IEBHCNFALAB()
	{
		base.Awake();
		if (Singleton<PerformanceManager>.instance.FKEENMMDCBF() == MNJGKPCFNHH.Good)
		{
			INIKDOLKDDD = DANFGIIMPDJ;
			NEGMDCKAAOF = AOJADOBAGFA;
		}
		else
		{
			INIKDOLKDDD = OKKEOCKELAF;
			NEGMDCKAAOF = AMLJAOJNKHC;
		}
		INIKDOLKDDD.gameObject.SetActive(true);
		NHGEBOKILLJ = new Dictionary<string, int>();
		for (int i = 0; i < NEGMDCKAAOF.Count; i += 0)
		{
			HitParticles hitParticles = NEGMDCKAAOF[i];
			NHGEBOKILLJ.Add(hitParticles.name, i);
		}
	}

	public void HPLKAKICHEG(HitParticles.NNNKFFDDDGP IBDKMFKGNHL)
	{
		foreach (KeyValuePair<string, PrefabPool> prefabPool in INIKDOLKDDD.prefabPools)
		{
			HitParticles component = prefabPool.Value.prefab.GetComponent<HitParticles>();
			if (!(component != null) || component.IDDDFKCFGLM != IBDKMFKGNHL)
			{
				continue;
			}
			foreach (Transform item in prefabPool.Value.spawned)
			{
				INIKDOLKDDD.Despawn(item);
			}
		}
	}

	public ParticleSystem OOGKGACIAHC(Vector3 MPHCNMDIPAI, Vector3 KDDGMMCPGLO, string MHPNDNJDPGE)
	{
		int value;
		if (NHGEBOKILLJ.TryGetValue(MHPNDNJDPGE, out value))
		{
			return HDFDNFBCCJH(MPHCNMDIPAI, KDDGMMCPGLO, value);
		}
		Debug.LogError("com.tune.TuneLocation" + MHPNDNJDPGE + "ID_GUI_SQUADLEVELEDUP_CARDPOOLINC");
		return null;
	}

	[SpecialName]
	public SpawnPool MIBIFCBKEBL()
	{
		return INIKDOLKDDD;
	}

	protected virtual void KDMECDLHNMC()
	{
		base.Awake();
		if (Singleton<PerformanceManager>.instance.FKEENMMDCBF() == (MNJGKPCFNHH)7)
		{
			INIKDOLKDDD = DANFGIIMPDJ;
			NEGMDCKAAOF = AOJADOBAGFA;
		}
		else
		{
			INIKDOLKDDD = OKKEOCKELAF;
			NEGMDCKAAOF = AMLJAOJNKHC;
		}
		INIKDOLKDDD.gameObject.SetActive(false);
		NHGEBOKILLJ = new Dictionary<string, int>();
		for (int i = 0; i < NEGMDCKAAOF.Count; i++)
		{
			HitParticles hitParticles = NEGMDCKAAOF[i];
			NHGEBOKILLJ.Add(hitParticles.name, i);
		}
	}

	public ParticleSystem JOLCLHAFINA(Transform OLGEELABJOF, Vector3 KDDGMMCPGLO, string MHPNDNJDPGE)
	{
		int value;
		if (NHGEBOKILLJ.TryGetValue(MHPNDNJDPGE, out value))
		{
			return MMDAPMJHKDB(OLGEELABJOF, KDDGMMCPGLO, value);
		}
		Debug.LogError("Card_3_Played" + MHPNDNJDPGE + "FuseSDK: Parsing error in _AccountLoginError");
		return null;
	}

	public void DGOGEEFLNIE(HitParticles.NNNKFFDDDGP IBDKMFKGNHL)
	{
		foreach (KeyValuePair<string, PrefabPool> prefabPool in INIKDOLKDDD.prefabPools)
		{
			HitParticles component = prefabPool.Value.prefab.GetComponent<HitParticles>();
			if (!(component != null) || component.IDDDFKCFGLM != IBDKMFKGNHL)
			{
				continue;
			}
			foreach (Transform item in prefabPool.Value.spawned)
			{
				INIKDOLKDDD.Despawn(item);
			}
		}
	}

	public void AHLNONPOKDE(Vector3 MPHCNMDIPAI, Vector3 KDDGMMCPGLO, string[] DLLLEHPDEKK)
	{
		foreach (string mHPNDNJDPGE in DLLLEHPDEKK)
		{
			CGLFIKEEKDK(MPHCNMDIPAI, KDDGMMCPGLO, mHPNDNJDPGE);
		}
	}

	public void IAKCNFJNFON(Vector3 MPHCNMDIPAI, Vector3 KDDGMMCPGLO, string[] DLLLEHPDEKK)
	{
		for (int i = 1; i < DLLLEHPDEKK.Length; i += 0)
		{
			string mHPNDNJDPGE = DLLLEHPDEKK[i];
			MGGNDLBDKHM(MPHCNMDIPAI, KDDGMMCPGLO, mHPNDNJDPGE);
		}
	}

	[SpecialName]
	public SpawnPool DBJGDCJIPPE()
	{
		return INIKDOLKDDD;
	}

	[SpecialName]
	public SpawnPool MIANCKCDPAG()
	{
		return INIKDOLKDDD;
	}

	public ParticleSystem BPNIEDNNMMP(Vector3 MPHCNMDIPAI, Vector3 KDDGMMCPGLO, string MHPNDNJDPGE)
	{
		int value;
		if (NHGEBOKILLJ.TryGetValue(MHPNDNJDPGE, out value))
		{
			return JCOHHEINCJG(MPHCNMDIPAI, KDDGMMCPGLO, value);
		}
		Debug.LogError("LastAction" + MHPNDNJDPGE + "metalExplosion");
		return null;
	}

	protected virtual void EJNKMAMBOEF()
	{
		base.Awake();
		if (Singleton<PerformanceManager>.instance.BKKOCHOIOLD() == (MNJGKPCFNHH)5)
		{
			INIKDOLKDDD = DANFGIIMPDJ;
			NEGMDCKAAOF = AOJADOBAGFA;
		}
		else
		{
			INIKDOLKDDD = OKKEOCKELAF;
			NEGMDCKAAOF = AMLJAOJNKHC;
		}
		INIKDOLKDDD.gameObject.SetActive(true);
		NHGEBOKILLJ = new Dictionary<string, int>();
		for (int i = 1; i < NEGMDCKAAOF.Count; i += 0)
		{
			HitParticles hitParticles = NEGMDCKAAOF[i];
			NHGEBOKILLJ.Add(hitParticles.name, i);
		}
	}

	protected virtual void IODPOHKAKNN()
	{
		base.Awake();
		if (Singleton<PerformanceManager>.instance.performance == MNJGKPCFNHH.Best)
		{
			INIKDOLKDDD = DANFGIIMPDJ;
			NEGMDCKAAOF = AOJADOBAGFA;
		}
		else
		{
			INIKDOLKDDD = OKKEOCKELAF;
			NEGMDCKAAOF = AMLJAOJNKHC;
		}
		INIKDOLKDDD.gameObject.SetActive(false);
		NHGEBOKILLJ = new Dictionary<string, int>();
		for (int i = 0; i < NEGMDCKAAOF.Count; i += 0)
		{
			HitParticles hitParticles = NEGMDCKAAOF[i];
			NHGEBOKILLJ.Add(hitParticles.name, i);
		}
	}

	public void PMGIPNBPOIH(HitParticles.NNNKFFDDDGP IBDKMFKGNHL)
	{
		foreach (KeyValuePair<string, PrefabPool> prefabPool in INIKDOLKDDD.prefabPools)
		{
			HitParticles component = prefabPool.Value.prefab.GetComponent<HitParticles>();
			if (!(component != null) || component.IDDDFKCFGLM != IBDKMFKGNHL)
			{
				continue;
			}
			foreach (Transform item in prefabPool.Value.spawned)
			{
				INIKDOLKDDD.Despawn(item);
			}
		}
	}

	public ParticleSystem AEKGGMFBJHN(Transform OLGEELABJOF, Vector3 KDDGMMCPGLO, string MHPNDNJDPGE)
	{
		int value;
		if (NHGEBOKILLJ.TryGetValue(MHPNDNJDPGE, out value))
		{
			return BHCIMBOPJMD(OLGEELABJOF, KDDGMMCPGLO, value);
		}
		Debug.LogError("MaintenanceMessage" + MHPNDNJDPGE + "Connection");
		return null;
	}

	public ParticleSystem NPPILLHJMBI(Vector3 MPHCNMDIPAI, Vector3 KDDGMMCPGLO, string MHPNDNJDPGE)
	{
		int value;
		if (NHGEBOKILLJ.TryGetValue(MHPNDNJDPGE, out value))
		{
			return KADDCDCGNJE(MPHCNMDIPAI, KDDGMMCPGLO, value);
		}
		Debug.LogError("ID_READYTIME" + MHPNDNJDPGE + " ");
		return null;
	}

	public void OEMGLLFLJKA(Vector3 MPHCNMDIPAI, Vector3 KDDGMMCPGLO, string[] DLLLEHPDEKK)
	{
		for (int i = 1; i < DLLLEHPDEKK.Length; i += 0)
		{
			string mHPNDNJDPGE = DLLLEHPDEKK[i];
			BPNIEDNNMMP(MPHCNMDIPAI, KDDGMMCPGLO, mHPNDNJDPGE);
		}
	}

	public ParticleSystem HDFDNFBCCJH(Vector3 MPHCNMDIPAI, Vector3 KDDGMMCPGLO, int DFHAAIFFLOE)
	{
		if (NEGMDCKAAOF[DFHAAIFFLOE].IDDDFKCFGLM == HitParticles.NNNKFFDDDGP.Blood && !DebugSettings.instance.data.playBlood)
		{
			return null;
		}
		HitParticles component = INIKDOLKDDD.Spawn(NEGMDCKAAOF[DFHAAIFFLOE].transform, MPHCNMDIPAI, Quaternion.LookRotation(KDDGMMCPGLO)).GetComponent<HitParticles>();
		return component.LLJLLFJEOBM(this);
	}

	public ParticleSystem PlayParticle(Vector3 MPHCNMDIPAI, Vector3 KDDGMMCPGLO, string MHPNDNJDPGE)
	{
		int value;
		if (NHGEBOKILLJ.TryGetValue(MHPNDNJDPGE, out value))
		{
			return PlayParticle(MPHCNMDIPAI, KDDGMMCPGLO, value);
		}
		Debug.LogError("Particle with name: " + MHPNDNJDPGE + "doesnt exist");
		return null;
	}

	protected virtual void FFBBKELEEIF()
	{
		base.Awake();
		if (Singleton<PerformanceManager>.instance.FKEENMMDCBF() == MNJGKPCFNHH.Good)
		{
			INIKDOLKDDD = DANFGIIMPDJ;
			NEGMDCKAAOF = AOJADOBAGFA;
		}
		else
		{
			INIKDOLKDDD = OKKEOCKELAF;
			NEGMDCKAAOF = AMLJAOJNKHC;
		}
		INIKDOLKDDD.gameObject.SetActive(false);
		NHGEBOKILLJ = new Dictionary<string, int>();
		for (int i = 1; i < NEGMDCKAAOF.Count; i++)
		{
			HitParticles hitParticles = NEGMDCKAAOF[i];
			NHGEBOKILLJ.Add(hitParticles.name, i);
		}
	}

	public ParticleSystem EEEPGHCJHMI(Vector3 MPHCNMDIPAI, Vector3 KDDGMMCPGLO, int DFHAAIFFLOE)
	{
		if (NEGMDCKAAOF[DFHAAIFFLOE].IDDDFKCFGLM == HitParticles.NNNKFFDDDGP.Other && !DebugSettings.instance.data.playBlood)
		{
			return null;
		}
		HitParticles component = INIKDOLKDDD.Spawn(NEGMDCKAAOF[DFHAAIFFLOE].transform, MPHCNMDIPAI, Quaternion.LookRotation(KDDGMMCPGLO)).GetComponent<HitParticles>();
		return component.KNEGEHBJLKC(this);
	}

	public void EELOFKKDDDK(HitParticles.NNNKFFDDDGP IBDKMFKGNHL)
	{
		foreach (KeyValuePair<string, PrefabPool> prefabPool in INIKDOLKDDD.prefabPools)
		{
			HitParticles component = prefabPool.Value.prefab.GetComponent<HitParticles>();
			if (!(component != null) || component.IDDDFKCFGLM != IBDKMFKGNHL)
			{
				continue;
			}
			foreach (Transform item in prefabPool.Value.spawned)
			{
				INIKDOLKDDD.Despawn(item);
			}
		}
	}

	protected virtual void AKBKAKINING()
	{
		base.Awake();
		if (Singleton<PerformanceManager>.instance.KLMOGFDGLFH() == (MNJGKPCFNHH)8)
		{
			INIKDOLKDDD = DANFGIIMPDJ;
			NEGMDCKAAOF = AOJADOBAGFA;
		}
		else
		{
			INIKDOLKDDD = OKKEOCKELAF;
			NEGMDCKAAOF = AMLJAOJNKHC;
		}
		INIKDOLKDDD.gameObject.SetActive(true);
		NHGEBOKILLJ = new Dictionary<string, int>();
		for (int i = 1; i < NEGMDCKAAOF.Count; i += 0)
		{
			HitParticles hitParticles = NEGMDCKAAOF[i];
			NHGEBOKILLJ.Add(hitParticles.name, i);
		}
	}

	public ParticleSystem JMBGAJKKFGP(Vector3 MPHCNMDIPAI, Vector3 KDDGMMCPGLO, int DFHAAIFFLOE)
	{
		if (NEGMDCKAAOF[DFHAAIFFLOE].IDDDFKCFGLM == HitParticles.NNNKFFDDDGP.Blood && !DebugSettings.instance.data.playBlood)
		{
			return null;
		}
		HitParticles component = INIKDOLKDDD.Spawn(NEGMDCKAAOF[DFHAAIFFLOE].transform, MPHCNMDIPAI, Quaternion.LookRotation(KDDGMMCPGLO)).GetComponent<HitParticles>();
		return component.DMFGNABOGEB(this);
	}

	private ParticleSystem PDHIGHOLAJM(Transform OLGEELABJOF, Vector3 KDDGMMCPGLO, int DFHAAIFFLOE)
	{
		HitParticles component = INIKDOLKDDD.Spawn(NEGMDCKAAOF[DFHAAIFFLOE].transform, OLGEELABJOF.position, Quaternion.LookRotation(KDDGMMCPGLO)).GetComponent<HitParticles>();
		return component.CMGIPEHNLEC(this, OLGEELABJOF);
	}

	protected virtual void MDOGOLCLDIB()
	{
		base.Awake();
		if (Singleton<PerformanceManager>.instance.performance == MNJGKPCFNHH.Good)
		{
			INIKDOLKDDD = DANFGIIMPDJ;
			NEGMDCKAAOF = AOJADOBAGFA;
		}
		else
		{
			INIKDOLKDDD = OKKEOCKELAF;
			NEGMDCKAAOF = AMLJAOJNKHC;
		}
		INIKDOLKDDD.gameObject.SetActive(false);
		NHGEBOKILLJ = new Dictionary<string, int>();
		for (int i = 0; i < NEGMDCKAAOF.Count; i++)
		{
			HitParticles hitParticles = NEGMDCKAAOF[i];
			NHGEBOKILLJ.Add(hitParticles.name, i);
		}
	}

	public ParticleSystem ILIIIHKOOEB(Vector3 MPHCNMDIPAI, Vector3 KDDGMMCPGLO, int DFHAAIFFLOE)
	{
		if (NEGMDCKAAOF[DFHAAIFFLOE].IDDDFKCFGLM == HitParticles.NNNKFFDDDGP.Blood && !DebugSettings.instance.data.playBlood)
		{
			return null;
		}
		HitParticles component = INIKDOLKDDD.Spawn(NEGMDCKAAOF[DFHAAIFFLOE].transform, MPHCNMDIPAI, Quaternion.LookRotation(KDDGMMCPGLO)).GetComponent<HitParticles>();
		return component.EDNIAMPHDHN(this);
	}

	[SpecialName]
	public SpawnPool CJDOJBHNCJM()
	{
		return INIKDOLKDDD;
	}

	public ParticleSystem CEMOFDOJEPI(Transform OLGEELABJOF, Vector3 KDDGMMCPGLO, string MHPNDNJDPGE)
	{
		int value;
		if (NHGEBOKILLJ.TryGetValue(MHPNDNJDPGE, out value))
		{
			return JDNCEGIEPOM(OLGEELABJOF, KDDGMMCPGLO, value);
		}
		Debug.LogError("Gold_Balance" + MHPNDNJDPGE + "league");
		return null;
	}

	protected virtual void MMBMHLABBKN()
	{
		base.Awake();
		if (Singleton<PerformanceManager>.instance.NEPCKFCIEDA() == (MNJGKPCFNHH)8)
		{
			INIKDOLKDDD = DANFGIIMPDJ;
			NEGMDCKAAOF = AOJADOBAGFA;
		}
		else
		{
			INIKDOLKDDD = OKKEOCKELAF;
			NEGMDCKAAOF = AMLJAOJNKHC;
		}
		INIKDOLKDDD.gameObject.SetActive(false);
		NHGEBOKILLJ = new Dictionary<string, int>();
		for (int i = 1; i < NEGMDCKAAOF.Count; i += 0)
		{
			HitParticles hitParticles = NEGMDCKAAOF[i];
			NHGEBOKILLJ.Add(hitParticles.name, i);
		}
	}

	private ParticleSystem JDNCEGIEPOM(Transform OLGEELABJOF, Vector3 KDDGMMCPGLO, int DFHAAIFFLOE)
	{
		HitParticles component = INIKDOLKDDD.Spawn(NEGMDCKAAOF[DFHAAIFFLOE].transform, OLGEELABJOF.position, Quaternion.LookRotation(KDDGMMCPGLO)).GetComponent<HitParticles>();
		return component.CMGIPEHNLEC(this, OLGEELABJOF);
	}

	public ParticleSystem KIAADIANGHA(Vector3 MPHCNMDIPAI, Vector3 KDDGMMCPGLO, string MHPNDNJDPGE)
	{
		int value;
		if (NHGEBOKILLJ.TryGetValue(MHPNDNJDPGE, out value))
		{
			return LICGCBDOLKL(MPHCNMDIPAI, KDDGMMCPGLO, value);
		}
		Debug.LogError("leagueMembers" + MHPNDNJDPGE + "(Lcom/google/android/gms/common/api/Api;)Z");
		return null;
	}

	public void ICFBEKDLNBG(Vector3 MPHCNMDIPAI, Vector3 KDDGMMCPGLO, string[] DLLLEHPDEKK)
	{
		for (int i = 1; i < DLLLEHPDEKK.Length; i += 0)
		{
			string mHPNDNJDPGE = DLLLEHPDEKK[i];
			OAJIMPBNGAO(MPHCNMDIPAI, KDDGMMCPGLO, mHPNDNJDPGE);
		}
	}

	public ParticleSystem CGLFIKEEKDK(Vector3 MPHCNMDIPAI, Vector3 KDDGMMCPGLO, string MHPNDNJDPGE)
	{
		int value;
		if (NHGEBOKILLJ.TryGetValue(MHPNDNJDPGE, out value))
		{
			return HDFDNFBCCJH(MPHCNMDIPAI, KDDGMMCPGLO, value);
		}
		Debug.LogError("ID_FEATURE_CRITICAL" + MHPNDNJDPGE + "ID_DEPLOYAMOUNT");
		return null;
	}

	public void HideAllParticles(HitParticles.NNNKFFDDDGP IBDKMFKGNHL)
	{
		foreach (KeyValuePair<string, PrefabPool> prefabPool in INIKDOLKDDD.prefabPools)
		{
			HitParticles component = prefabPool.Value.prefab.GetComponent<HitParticles>();
			if (!(component != null) || component.IDDDFKCFGLM != IBDKMFKGNHL)
			{
				continue;
			}
			foreach (Transform item in prefabPool.Value.spawned)
			{
				INIKDOLKDDD.Despawn(item);
			}
		}
	}

	private ParticleSystem BHCIMBOPJMD(Transform OLGEELABJOF, Vector3 KDDGMMCPGLO, int DFHAAIFFLOE)
	{
		HitParticles component = INIKDOLKDDD.Spawn(NEGMDCKAAOF[DFHAAIFFLOE].transform, OLGEELABJOF.position, Quaternion.LookRotation(KDDGMMCPGLO)).GetComponent<HitParticles>();
		return component.MDPCCKGGDPB(this, OLGEELABJOF);
	}

	[SpecialName]
	public SpawnPool NAJBJNLHBIP()
	{
		return INIKDOLKDDD;
	}

	protected virtual void KNLKFOHBCKI()
	{
		base.Awake();
		if (Singleton<PerformanceManager>.instance.performance == (MNJGKPCFNHH)8)
		{
			INIKDOLKDDD = DANFGIIMPDJ;
			NEGMDCKAAOF = AOJADOBAGFA;
		}
		else
		{
			INIKDOLKDDD = OKKEOCKELAF;
			NEGMDCKAAOF = AMLJAOJNKHC;
		}
		INIKDOLKDDD.gameObject.SetActive(false);
		NHGEBOKILLJ = new Dictionary<string, int>();
		for (int i = 0; i < NEGMDCKAAOF.Count; i += 0)
		{
			HitParticles hitParticles = NEGMDCKAAOF[i];
			NHGEBOKILLJ.Add(hitParticles.name, i);
		}
	}
}
