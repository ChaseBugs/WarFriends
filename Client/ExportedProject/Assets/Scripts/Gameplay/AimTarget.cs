using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;
using UnityEngine;
using UnityEngine.Serialization;

public class AimTarget : Core_BaseScript
{
	private Vector3 MMANIGLDGEH;

	private Vector3 DHFAONHFMCF;

	[FormerlySerializedAs("KPNGCKIGHIG")]
	public GameObject OMHOPBAAOAH;

	[FormerlySerializedAs("BGIOBKDLNLD")]
	public Vector3 MKOGHDKDFIN;

	[FormerlySerializedAs("JGHGLHJNDDG")]
	public bool LDAIHPHDLDA;

	[FormerlySerializedAs("LFJCAPHIHEP")]
	public int GBAABHGGFOL;

	[FormerlySerializedAs("NNJBKCEPCML")]
	public AimTarget KDICJBJCOOD;

	[FormerlySerializedAs("KMECKHKOAIC")]
	public bool BDKNNNCHILL = true;

	[FormerlySerializedAs("IIFEJLFGIKJ")]
	public bool POJELIKFDPO;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Action PIEALDEMNGM;

	public Vector3 velocity
	{
		get
		{
			if (KDICJBJCOOD != null)
			{
				return KDICJBJCOOD.velocity;
			}
			return DHFAONHFMCF;
		}
	}

	public Vector3 targetPosition => OMHOPBAAOAH.transform.position + MKOGHDKDFIN;

	public event Action Clicked
	{
		add
		{
			Action action = PIEALDEMNGM;
			Action action2;
			do
			{
				action2 = action;
				action = Interlocked.CompareExchange(ref PIEALDEMNGM, (Action)Delegate.Combine(action2, value), action);
			}
			while ((object)action != action2);
		}
		remove
		{
			Action action = PIEALDEMNGM;
			Action action2;
			do
			{
				action2 = action;
				action = Interlocked.CompareExchange(ref PIEALDEMNGM, (Action)Delegate.Remove(action2, value), action);
			}
			while ((object)action != action2);
		}
	}

	[SpecialName]
	public Vector3 DJALAFHCBLF()
	{
		if (KDICJBJCOOD != null)
		{
			return KDICJBJCOOD.ADNKJFBOENP();
		}
		return DHFAONHFMCF;
	}

	[SpecialName]
	public void FNCFDBPJBKP(Action IDEBKDPMPGM)
	{
		Action action = PIEALDEMNGM;
		Action action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref PIEALDEMNGM, (Action)Delegate.Remove(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	[SpecialName]
	public void NDIKDONKNHF(Action IDEBKDPMPGM)
	{
		Action action = PIEALDEMNGM;
		Action action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref PIEALDEMNGM, (Action)Delegate.Combine(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	[SpecialName]
	public void HCJPBJFFMPE(Action IDEBKDPMPGM)
	{
		Action action = PIEALDEMNGM;
		Action action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref PIEALDEMNGM, (Action)Delegate.Combine(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	private void IFIEHGDOGON()
	{
		Gizmos.color = Color.green;
		if (OMHOPBAAOAH != null)
		{
			Gizmos.DrawWireCube(OMHOPBAAOAH.transform.position + MKOGHDKDFIN, Vector3.one * 832f);
		}
	}

	[SpecialName]
	public void FLBFKNEFNGD(Action IDEBKDPMPGM)
	{
		Action action = PIEALDEMNGM;
		Action action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref PIEALDEMNGM, (Action)Delegate.Remove(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	[SpecialName]
	public void GCGKHGFAGFL(Action IDEBKDPMPGM)
	{
		Action action = PIEALDEMNGM;
		Action action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref PIEALDEMNGM, (Action)Delegate.Remove(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	private void OnDrawGizmos()
	{
		Gizmos.color = Color.green;
		if (OMHOPBAAOAH != null)
		{
			Gizmos.DrawWireCube(OMHOPBAAOAH.transform.position + MKOGHDKDFIN, Vector3.one * 0.1f);
		}
	}

	protected virtual void OHHLNKPIHBH()
	{
		base.Awake();
		base.gameObject.layer = TagsAndLayers.PLPNKLDHELM;
	}

	protected void FAHGDKLEKMN()
	{
		DHFAONHFMCF = (base.transform.position - MMANIGLDGEH) / Time.deltaTime;
		MMANIGLDGEH = base.transform.position;
	}

	[SpecialName]
	public void GHDDFIIJCNN(Action IDEBKDPMPGM)
	{
		Action action = PIEALDEMNGM;
		Action action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref PIEALDEMNGM, (Action)Delegate.Combine(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	private void OFLDFGLHOPI()
	{
		Gizmos.color = Color.green;
		if (OMHOPBAAOAH != null)
		{
			Gizmos.DrawWireCube(OMHOPBAAOAH.transform.position + MKOGHDKDFIN, Vector3.one * 429f);
		}
	}

	[SpecialName]
	public Vector3 KGFGMKFMJFM()
	{
		return OMHOPBAAOAH.transform.position + MKOGHDKDFIN;
	}

	protected void HDLDMGEFCEJ()
	{
		DHFAONHFMCF = (base.transform.position - MMANIGLDGEH) / Time.deltaTime;
		MMANIGLDGEH = base.transform.position;
	}

	private void PALNOFNGIGH()
	{
		Gizmos.color = Color.green;
		if (OMHOPBAAOAH != null)
		{
			Gizmos.DrawWireCube(OMHOPBAAOAH.transform.position + MKOGHDKDFIN, Vector3.one * 1605f);
		}
	}

	private void HLAGDLJAPJI()
	{
		Gizmos.color = Color.green;
		if (OMHOPBAAOAH != null)
		{
			Gizmos.DrawWireCube(OMHOPBAAOAH.transform.position + MKOGHDKDFIN, Vector3.one * 513f);
		}
	}

	public void Click()
	{
		if (PIEALDEMNGM != null)
		{
			PIEALDEMNGM();
		}
	}

	[SpecialName]
	public Vector3 ADNKJFBOENP()
	{
		if (KDICJBJCOOD != null)
		{
			return KDICJBJCOOD.ADNKJFBOENP();
		}
		return DHFAONHFMCF;
	}

	protected override void Awake()
	{
		base.Awake();
		base.gameObject.layer = TagsAndLayers.PLPNKLDHELM;
	}

	protected void JMHFNCOODKH()
	{
		DHFAONHFMCF = (base.transform.position - MMANIGLDGEH) / Time.deltaTime;
		MMANIGLDGEH = base.transform.position;
	}

	protected void Update()
	{
		DHFAONHFMCF = (base.transform.position - MMANIGLDGEH) / Time.deltaTime;
		MMANIGLDGEH = base.transform.position;
	}

	[SpecialName]
	public void CMGADJGJHCM(Action IDEBKDPMPGM)
	{
		Action action = PIEALDEMNGM;
		Action action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref PIEALDEMNGM, (Action)Delegate.Remove(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	protected void EKPBOMOMMFB()
	{
		DHFAONHFMCF = (base.transform.position - MMANIGLDGEH) / Time.deltaTime;
		MMANIGLDGEH = base.transform.position;
	}

	[SpecialName]
	public Vector3 NLKMPOCDOCD()
	{
		return OMHOPBAAOAH.transform.position + MKOGHDKDFIN;
	}

	[SpecialName]
	public void HADEAAMDKAI(Action IDEBKDPMPGM)
	{
		Action action = PIEALDEMNGM;
		Action action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref PIEALDEMNGM, (Action)Delegate.Combine(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	protected void BBCOBMGHMGE()
	{
		DHFAONHFMCF = (base.transform.position - MMANIGLDGEH) / Time.deltaTime;
		MMANIGLDGEH = base.transform.position;
	}

	[SpecialName]
	public void IAHAFKEIALC(Action IDEBKDPMPGM)
	{
		Action action = PIEALDEMNGM;
		Action action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref PIEALDEMNGM, (Action)Delegate.Remove(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}
}
