using System.Runtime.CompilerServices;
using UnityEngine;

public class HudObjectIndicator2D : PoolableObject
{
	public Transform NGCDDPCAGJB;

	public myFilledSprite GMPADNOGGNL;

	public tk2dSprite MBMIOELEAND;

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
			base.gameObject.SetActive(false);
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
			base.gameObject.SetActive(false);
		}
	}

	public virtual void JIMPCGDILNF()
	{
		if (base.gameObject != null)
		{
			base.gameObject.SetActive(true);
		}
	}
}
