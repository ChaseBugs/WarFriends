using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerPoint : Core_BaseScript
{
	[FormerlySerializedAs("LMIPHKAKDAL")]
	public ElectricTrap LJCCGFIOHEN;

	[FormerlySerializedAs("BIAIICJMODD")]
	public List<Transform> MGBJKGHGELH;

	[FormerlySerializedAs("EMJBPPACFJK")]
	public List<TurretPosition> IFDJIGAPAPP;

	private Shield LIMFPEDEOJA;

	[FormerlySerializedAs("LOIFOKHCNNN")]
	public List<EnemyPointRusher> JGAIPICHEDP;

	public Shield shield => LIMFPEDEOJA ?? (LIMFPEDEOJA = GetComponentInChildren<Shield>());

	private void KALEMFKOGLE()
	{
		foreach (EnemyPointRusher item in JGAIPICHEDP)
		{
			item.CMMOLNHPODD(this);
		}
	}

	private void FIGOGIMJIIN()
	{
		foreach (EnemyPointRusher item in JGAIPICHEDP)
		{
			item.OFPMLKNCBGK(this);
		}
	}

	private void NGGJHDCOLEC()
	{
		foreach (EnemyPointRusher item in JGAIPICHEDP)
		{
			item.HMILLGDMBGD(this);
		}
	}

	private void HCDNNGFBJOE()
	{
		foreach (EnemyPointRusher item in JGAIPICHEDP)
		{
			item.HMILLGDMBGD(this);
		}
	}

	[SpecialName]
	public Shield CGKKGILAAPG()
	{
		return LIMFPEDEOJA ?? (LIMFPEDEOJA = GetComponentInChildren<Shield>());
	}

	private new void Awake()
	{
		foreach (EnemyPointRusher item in JGAIPICHEDP)
		{
			item.playerPoint = this;
		}
	}

	[SpecialName]
	public Shield LHHMNLJKOAO()
	{
		return LIMFPEDEOJA ?? (LIMFPEDEOJA = GetComponentInChildren<Shield>());
	}

	private void BAGCDJMLCPF()
	{
		foreach (EnemyPointRusher item in JGAIPICHEDP)
		{
			item.NEIJFNBAIKE(this);
		}
	}

	[SpecialName]
	public Shield JPHAJDIIAAI()
	{
		return LIMFPEDEOJA ?? (LIMFPEDEOJA = GetComponentInChildren<Shield>());
	}

	[SpecialName]
	public Shield PKBPGCGNCAD()
	{
		return LIMFPEDEOJA ?? (LIMFPEDEOJA = GetComponentInChildren<Shield>());
	}

	private void KECNIEGEDBP()
	{
		foreach (EnemyPointRusher item in JGAIPICHEDP)
		{
			item.CMMOLNHPODD(this);
		}
	}

	private void HOINLOMCGFD()
	{
		foreach (EnemyPointRusher item in JGAIPICHEDP)
		{
			item.NDJMBFGHAHH(this);
		}
	}

	private void CFGDCEOLKJG()
	{
		foreach (EnemyPointRusher item in JGAIPICHEDP)
		{
			item.IPLKJJPJIBM(this);
		}
	}

	private void DLOLBFOOEBA()
	{
		foreach (EnemyPointRusher item in JGAIPICHEDP)
		{
			item.KABIBEFIGII(this);
		}
	}

	private void FNJKFDOMGOO()
	{
		foreach (EnemyPointRusher item in JGAIPICHEDP)
		{
			item.KABIBEFIGII(this);
		}
	}

	private void JDPDEKENPLD()
	{
		foreach (EnemyPointRusher item in JGAIPICHEDP)
		{
			item.BNGGFALDICO(this);
		}
	}

	[SpecialName]
	public Shield PNKKPNIMEPL()
	{
		return LIMFPEDEOJA ?? (LIMFPEDEOJA = GetComponentInChildren<Shield>());
	}

	[SpecialName]
	public Shield PHANADCNBFD()
	{
		return LIMFPEDEOJA ?? (LIMFPEDEOJA = GetComponentInChildren<Shield>());
	}

	[SpecialName]
	public Shield KJCHIHLJMMF()
	{
		return LIMFPEDEOJA ?? (LIMFPEDEOJA = GetComponentInChildren<Shield>());
	}

	private void BMLLLOBPGIB()
	{
		foreach (EnemyPointRusher item in JGAIPICHEDP)
		{
			item.KEMMALMOAPD(this);
		}
	}

	private void GDKKBDKGAEK()
	{
		foreach (EnemyPointRusher item in JGAIPICHEDP)
		{
			item.HMILLGDMBGD(this);
		}
	}

	private void IBLPGJOHIAE()
	{
		foreach (EnemyPointRusher item in JGAIPICHEDP)
		{
			item.JJOFLOMLFPI(this);
		}
	}

	private void IABJJOPLKFF()
	{
		foreach (EnemyPointRusher item in JGAIPICHEDP)
		{
			item.NEIJFNBAIKE(this);
		}
	}

	[SpecialName]
	public Shield IGEDGCNJCAP()
	{
		return LIMFPEDEOJA ?? (LIMFPEDEOJA = GetComponentInChildren<Shield>());
	}

	private void IOKMAFLIJEG()
	{
		foreach (EnemyPointRusher item in JGAIPICHEDP)
		{
			item.NEIJFNBAIKE(this);
		}
	}

	[SpecialName]
	public Shield LMHDAIBCLDP()
	{
		return LIMFPEDEOJA ?? (LIMFPEDEOJA = GetComponentInChildren<Shield>());
	}

	private void GDDCEHOJCEM()
	{
		foreach (EnemyPointRusher item in JGAIPICHEDP)
		{
			item.CMMOLNHPODD(this);
		}
	}
}
