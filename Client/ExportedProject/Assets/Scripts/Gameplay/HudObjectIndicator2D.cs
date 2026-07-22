using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Serialization;

public class HudObjectIndicator2D : PoolableObject
{
	[FormerlySerializedAs("APAECJDOAIL")]
	public Transform NGCDDPCAGJB;

	[FormerlySerializedAs("BHEADGAMNNF")]
	public myFilledSprite GMPADNOGGNL;

	[FormerlySerializedAs("ONIHPKHLGNH")]
	public tk2dSprite MBMIOELEAND;

	[FormerlySerializedAs("LEMGJODHNMP")]
	public tk2dSprite IGLDDJNNEHE;

	public float progress
	{
		set
		{
			if (GMPADNOGGNL != null)
			{
				GMPADNOGGNL.fillFract = value;
			}
		}
	}

	public Color colour
	{
		set
		{
			if (GMPADNOGGNL != null)
			{
				GMPADNOGGNL.color = value;
			}
		}
	}

	protected virtual void EJFMJDFPGFE()
	{
		base.Awake();
		NGCDDPCAGJB = base.transform;
	}

	public virtual void Hide()
	{
		if (base.gameObject != null)
		{
			base.gameObject.SetActive(value: false);
		}
	}

	public void LIAFHKPDAPB(Vector3 MPHCNMDIPAI)
	{
		NGCDDPCAGJB.position = MPHCNMDIPAI;
	}

	[SpecialName]
	public void AAAOPFFJJNF(Color IDEBKDPMPGM)
	{
		if (GMPADNOGGNL != null)
		{
			GMPADNOGGNL.color = IDEBKDPMPGM;
		}
	}

	[SpecialName]
	public void HOEHKMNGBFJ(Color IDEBKDPMPGM)
	{
		if (GMPADNOGGNL != null)
		{
			GMPADNOGGNL.color = IDEBKDPMPGM;
		}
	}

	[SpecialName]
	public void NKMMLDJDJBI(Color IDEBKDPMPGM)
	{
		if (GMPADNOGGNL != null)
		{
			GMPADNOGGNL.color = IDEBKDPMPGM;
		}
	}

	protected virtual void KALEMFKOGLE()
	{
		base.Awake();
		NGCDDPCAGJB = base.transform;
	}

	protected override void Awake()
	{
		base.Awake();
		NGCDDPCAGJB = base.transform;
	}

	public void SetPosition(Vector3 MPHCNMDIPAI)
	{
		NGCDDPCAGJB.position = MPHCNMDIPAI;
	}

	public void LAKPAMIMPEJ(string KCHMDALPMBN)
	{
		if (GMPADNOGGNL != null)
		{
			GMPADNOGGNL.SetSprite(KCHMDALPMBN);
		}
	}

	public void SetSprite(string KCHMDALPMBN)
	{
		if (GMPADNOGGNL != null)
		{
			GMPADNOGGNL.SetSprite(KCHMDALPMBN);
		}
	}

	public virtual void OPMMMPCGHHB()
	{
		if (base.gameObject != null)
		{
			base.gameObject.SetActive(value: false);
		}
	}

	public virtual void JIMPCGDILNF()
	{
		if (base.gameObject != null)
		{
			base.gameObject.SetActive(value: true);
		}
	}
}
