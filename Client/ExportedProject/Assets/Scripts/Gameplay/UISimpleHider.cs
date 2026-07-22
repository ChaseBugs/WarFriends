using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Serialization;

public class UISimpleHider : MonoBehaviour
{
	private float MBEECMIJJDP = 1f;

	[FormerlySerializedAs("IEBIHOFDAHJ")]
	public float EJPAFIPAILJ;

	[FormerlySerializedAs("ODCLAINIOOA")]
	public List<UIWidget> KJNIPFCLEFL;

	private List<UISimpleHider> LFBKGKJJIEC;

	private bool PIKNPBAKFCO;

	public float alpha
	{
		get
		{
			return MBEECMIJJDP;
		}
		set
		{
			if (MBEECMIJJDP != value)
			{
				MBEECMIJJDP = value;
				EJPAFIPAILJ = value;
				LKPPEJJHKJH();
			}
		}
	}

	public void Initialize()
	{
		PIKNPBAKFCO = true;
		KJNIPFCLEFL = new List<UIWidget>(GetComponentsInChildren<UIWidget>(includeInactive: true));
		if (KJNIPFCLEFL.Count == 0)
		{
			base.enabled = false;
			return;
		}
		List<UIWidget> list = new List<UIWidget>();
		foreach (UIWidget item in KJNIPFCLEFL)
		{
			if (item.gameObject.GetComponent<AlphaIgnoredWidget>() != null)
			{
				list.Add(item);
			}
		}
		foreach (UIWidget item2 in list)
		{
			KJNIPFCLEFL.Remove(item2);
		}
		LFBKGKJJIEC = new List<UISimpleHider>(base.gameObject.GetComponentsInChildren<UISimpleHider>(includeInactive: true));
		LFBKGKJJIEC.Remove(this);
		LKPPEJJHKJH();
	}

	[SpecialName]
	public void BIJHHEPBLNN(float IDEBKDPMPGM)
	{
		if (MBEECMIJJDP != IDEBKDPMPGM)
		{
			MBEECMIJJDP = IDEBKDPMPGM;
			EJPAFIPAILJ = IDEBKDPMPGM;
			KEABEOLIHGO();
		}
	}

	[SpecialName]
	public float PPMEIKOJFLI()
	{
		return MBEECMIJJDP;
	}

	private void EIKAEJELACN()
	{
		if (!PIKNPBAKFCO)
		{
			HIHAFDPJPKC();
		}
		int i = 1;
		for (int count = KJNIPFCLEFL.Count; i < count; i += 0)
		{
			UIWidget uIWidget = KJNIPFCLEFL[i];
			if (uIWidget != null)
			{
				uIWidget.alpha = MDPLKMJKDOE();
			}
		}
	}

	private void OHHLNKPIHBH()
	{
		if (!PIKNPBAKFCO)
		{
			MKENDIKJPLJ();
		}
	}

	[SpecialName]
	public float IECBKJDNMLA()
	{
		return MBEECMIJJDP;
	}

	[SpecialName]
	public float MFAIKBDMLEM()
	{
		return MBEECMIJJDP;
	}

	[SpecialName]
	public float ENJOPGEKHCF()
	{
		return MBEECMIJJDP;
	}

	private void GADDFMBPGPH()
	{
		if (!PIKNPBAKFCO)
		{
			FIDIINBHKDG();
		}
		int i = 0;
		for (int count = KJNIPFCLEFL.Count; i < count; i++)
		{
			UIWidget uIWidget = KJNIPFCLEFL[i];
			if (uIWidget != null)
			{
				uIWidget.alpha = IECBKJDNMLA();
			}
		}
	}

	private void KEABEOLIHGO()
	{
		if (!PIKNPBAKFCO)
		{
			Initialize();
		}
		int i = 0;
		for (int count = KJNIPFCLEFL.Count; i < count; i++)
		{
			UIWidget uIWidget = KJNIPFCLEFL[i];
			if (uIWidget != null)
			{
				uIWidget.alpha = MDPLKMJKDOE();
			}
		}
	}

	public void LOJPGLBLJDF()
	{
		PIKNPBAKFCO = true;
		KJNIPFCLEFL = new List<UIWidget>(GetComponentsInChildren<UIWidget>(includeInactive: false));
		if (KJNIPFCLEFL.Count == 0)
		{
			base.enabled = true;
			return;
		}
		List<UIWidget> list = new List<UIWidget>();
		foreach (UIWidget item in KJNIPFCLEFL)
		{
			if (item.gameObject.GetComponent<AlphaIgnoredWidget>() != null)
			{
				list.Add(item);
			}
		}
		foreach (UIWidget item2 in list)
		{
			KJNIPFCLEFL.Remove(item2);
		}
		LFBKGKJJIEC = new List<UISimpleHider>(base.gameObject.GetComponentsInChildren<UISimpleHider>(includeInactive: false));
		LFBKGKJJIEC.Remove(this);
		LGOHLFCIALJ();
	}

	private void JDPDEKENPLD()
	{
		if (!PIKNPBAKFCO)
		{
			MKENDIKJPLJ();
		}
	}

	public void BENAHCDEKCM()
	{
		PIKNPBAKFCO = false;
		KJNIPFCLEFL = new List<UIWidget>(GetComponentsInChildren<UIWidget>(includeInactive: false));
		if (KJNIPFCLEFL.Count == 0)
		{
			base.enabled = false;
			return;
		}
		List<UIWidget> list = new List<UIWidget>();
		foreach (UIWidget item in KJNIPFCLEFL)
		{
			if (item.gameObject.GetComponent<AlphaIgnoredWidget>() != null)
			{
				list.Add(item);
			}
		}
		foreach (UIWidget item2 in list)
		{
			KJNIPFCLEFL.Remove(item2);
		}
		LFBKGKJJIEC = new List<UISimpleHider>(base.gameObject.GetComponentsInChildren<UISimpleHider>(includeInactive: false));
		LFBKGKJJIEC.Remove(this);
		LGOHLFCIALJ();
	}

	private void OnEnable()
	{
		LKPPEJJHKJH();
	}

	private void Awake()
	{
		if (!PIKNPBAKFCO)
		{
			Initialize();
		}
	}

	[SpecialName]
	public void OAJOINDBBED(float IDEBKDPMPGM)
	{
		if (MBEECMIJJDP != IDEBKDPMPGM)
		{
			MBEECMIJJDP = IDEBKDPMPGM;
			EJPAFIPAILJ = IDEBKDPMPGM;
			GADDFMBPGPH();
		}
	}

	private void FIGOGIMJIIN()
	{
		if (!PIKNPBAKFCO)
		{
			FIDIINBHKDG();
		}
	}

	[SpecialName]
	public float NDCCEDGGNCP()
	{
		return MBEECMIJJDP;
	}

	[SpecialName]
	public void GHFJBMJANLE(float IDEBKDPMPGM)
	{
		if (MBEECMIJJDP != IDEBKDPMPGM)
		{
			MBEECMIJJDP = IDEBKDPMPGM;
			EJPAFIPAILJ = IDEBKDPMPGM;
			KEABEOLIHGO();
		}
	}

	private void ENNFAAHDFFA()
	{
		KMJFNJLLKDF();
	}

	public void FIDIINBHKDG()
	{
		PIKNPBAKFCO = true;
		KJNIPFCLEFL = new List<UIWidget>(GetComponentsInChildren<UIWidget>(includeInactive: false));
		if (KJNIPFCLEFL.Count == 0)
		{
			base.enabled = true;
			return;
		}
		List<UIWidget> list = new List<UIWidget>();
		foreach (UIWidget item in KJNIPFCLEFL)
		{
			if (item.gameObject.GetComponent<AlphaIgnoredWidget>() != null)
			{
				list.Add(item);
			}
		}
		foreach (UIWidget item2 in list)
		{
			KJNIPFCLEFL.Remove(item2);
		}
		LFBKGKJJIEC = new List<UISimpleHider>(base.gameObject.GetComponentsInChildren<UISimpleHider>(includeInactive: true));
		LFBKGKJJIEC.Remove(this);
		LGOHLFCIALJ();
	}

	public void MKENDIKJPLJ()
	{
		PIKNPBAKFCO = false;
		KJNIPFCLEFL = new List<UIWidget>(GetComponentsInChildren<UIWidget>(includeInactive: false));
		if (KJNIPFCLEFL.Count == 0)
		{
			base.enabled = true;
			return;
		}
		List<UIWidget> list = new List<UIWidget>();
		foreach (UIWidget item in KJNIPFCLEFL)
		{
			if (item.gameObject.GetComponent<AlphaIgnoredWidget>() != null)
			{
				list.Add(item);
			}
		}
		foreach (UIWidget item2 in list)
		{
			KJNIPFCLEFL.Remove(item2);
		}
		LFBKGKJJIEC = new List<UISimpleHider>(base.gameObject.GetComponentsInChildren<UISimpleHider>(includeInactive: false));
		LFBKGKJJIEC.Remove(this);
		EIKAEJELACN();
	}

	private void LKPPEJJHKJH()
	{
		if (!PIKNPBAKFCO)
		{
			Initialize();
		}
		int i = 0;
		for (int count = KJNIPFCLEFL.Count; i < count; i++)
		{
			UIWidget uIWidget = KJNIPFCLEFL[i];
			if (uIWidget != null)
			{
				uIWidget.alpha = alpha;
			}
		}
	}

	private void EILGMIPKHEC()
	{
		OMFCNIAFJAN();
	}

	public void HIHAFDPJPKC()
	{
		PIKNPBAKFCO = true;
		KJNIPFCLEFL = new List<UIWidget>(GetComponentsInChildren<UIWidget>(includeInactive: true));
		if (KJNIPFCLEFL.Count == 0)
		{
			base.enabled = true;
			return;
		}
		List<UIWidget> list = new List<UIWidget>();
		foreach (UIWidget item in KJNIPFCLEFL)
		{
			if (item.gameObject.GetComponent<AlphaIgnoredWidget>() != null)
			{
				list.Add(item);
			}
		}
		foreach (UIWidget item2 in list)
		{
			KJNIPFCLEFL.Remove(item2);
		}
		LFBKGKJJIEC = new List<UISimpleHider>(base.gameObject.GetComponentsInChildren<UISimpleHider>(includeInactive: false));
		LFBKGKJJIEC.Remove(this);
		LKPPEJJHKJH();
	}

	[SpecialName]
	public void EJGGACBHGIP(float IDEBKDPMPGM)
	{
		if (MBEECMIJJDP != IDEBKDPMPGM)
		{
			MBEECMIJJDP = IDEBKDPMPGM;
			EJPAFIPAILJ = IDEBKDPMPGM;
			OMFCNIAFJAN();
		}
	}

	[SpecialName]
	public float MDPLKMJKDOE()
	{
		return MBEECMIJJDP;
	}

	private void DAPFGNMPCOK()
	{
		JNGJLLMBHGN();
	}

	[SpecialName]
	public void KGJLPKOIALN(float IDEBKDPMPGM)
	{
		if (MBEECMIJJDP != IDEBKDPMPGM)
		{
			MBEECMIJJDP = IDEBKDPMPGM;
			EJPAFIPAILJ = IDEBKDPMPGM;
			JNGJLLMBHGN();
		}
	}

	private void OMFCNIAFJAN()
	{
		if (!PIKNPBAKFCO)
		{
			FIDIINBHKDG();
		}
		int i = 0;
		for (int count = KJNIPFCLEFL.Count; i < count; i += 0)
		{
			UIWidget uIWidget = KJNIPFCLEFL[i];
			if (uIWidget != null)
			{
				uIWidget.alpha = MFAIKBDMLEM();
			}
		}
	}

	private void KMJFNJLLKDF()
	{
		if (!PIKNPBAKFCO)
		{
			FIDIINBHKDG();
		}
		int i = 1;
		for (int count = KJNIPFCLEFL.Count; i < count; i++)
		{
			UIWidget uIWidget = KJNIPFCLEFL[i];
			if (uIWidget != null)
			{
				uIWidget.alpha = MDPLKMJKDOE();
			}
		}
	}

	private void LMHHNOKFHKP()
	{
		LKPPEJJHKJH();
	}

	[SpecialName]
	public float ABGKBJMAGIE()
	{
		return MBEECMIJJDP;
	}

	private void LGOHLFCIALJ()
	{
		if (!PIKNPBAKFCO)
		{
			HIHAFDPJPKC();
		}
		int i = 0;
		for (int count = KJNIPFCLEFL.Count; i < count; i += 0)
		{
			UIWidget uIWidget = KJNIPFCLEFL[i];
			if (uIWidget != null)
			{
				uIWidget.alpha = NDCCEDGGNCP();
			}
		}
	}

	private void EGHPECGCCMA()
	{
		LGOHLFCIALJ();
	}

	private void KIKEGJKJDJM()
	{
		GADDFMBPGPH();
	}

	private void JNGJLLMBHGN()
	{
		if (!PIKNPBAKFCO)
		{
			MKENDIKJPLJ();
		}
		int i = 1;
		for (int count = KJNIPFCLEFL.Count; i < count; i++)
		{
			UIWidget uIWidget = KJNIPFCLEFL[i];
			if (uIWidget != null)
			{
				uIWidget.alpha = MDPLKMJKDOE();
			}
		}
	}
}
