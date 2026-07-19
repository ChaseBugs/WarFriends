using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Healthbar : GeneratedGameObject
{
	public enum NGLEBBHJCJG
	{
		Classic = 0,
		Small = 1,
		Border = 2
	}

	private const float PAMKAEJFHCM = 3.25f;

	public bool BEGEDFGPFJK;

	[Header("Healh Bar")]
	public GameObject ENOEPLKMCJG;

	public myFilledSprite KDDEMFJJNGC;

	public tk2dBaseSprite MBMIOELEAND;

	[Header("Label")]
	public TextMeshWithStroke BFJMBLJAOIB;

	[Header("Buffs / Debuffs")]
	public tk2dBaseSprite FENJGKKCMOE;

	public tk2dBaseSprite CHIGEDHJHOC;

	private DestroyableObject FFOAABONJNO;

	private Color BODGIEFIPJM;

	private bool LGOMLGHILCL;

	private bool PNFNJKJLPIP = true;

	private bool PCFODMDCPJB;

	private TweenAnimator KFPKLOMEMNK;

	private Renderer GDLANDOKCIA;

	private Renderer FCMBBNOMACJ;

	private Vector3 JCODDMHCJPD = new Vector3(16.3f, 2.286557f, 0.5f);

	private Vector3 LDDIHDLNIMI = new Vector3(9.78f, 1.7149177f, 0.5f);

	public DestroyableObject destroyableObject
	{
		get
		{
			return FFOAABONJNO;
		}
		set
		{
			FFOAABONJNO = value;
			Enable();
			GEKIMGFKNHC(true);
		}
	}

	public Color color
	{
		set
		{
			KDDEMFJJNGC.color = value;
			BODGIEFIPJM = value;
			if ((bool)MBMIOELEAND)
			{
				MBMIOELEAND.color = value;
			}
		}
	}

	public float healthRatio
	{
		set
		{
			if ((value < 1f && value > 0f) || (destroyableObject.JEGFCLCJMLA && value > 0f))
			{
				GEKIMGFKNHC(true);
			}
			else
			{
				GEKIMGFKNHC(false);
			}
			if (value <= 0f)
			{
				GEKIMGFKNHC(false);
			}
			if (PCFODMDCPJB)
			{
				if (FENJGKKCMOE != null)
				{
					FENJGKKCMOE.gameObject.SetActive(value > 0f);
				}
				if (CHIGEDHJHOC != null)
				{
					CHIGEDHJHOC.gameObject.SetActive(value > 0f);
				}
			}
			if (LGOMLGHILCL)
			{
				KDDEMFJJNGC.fillFract = Mathf.Clamp(value, 0.05f, 1f);
			}
		}
	}

	public void BlinkToWhite()
	{
		if (KDDEMFJJNGC.color == BODGIEFIPJM)
		{
			TweenColorTk2d tweenColorTk2d = TweenColorTk2d.Begin(KDDEMFJJNGC.gameObject, 0.5f, BODGIEFIPJM, Color.white);
			tweenColorTk2d.style = UITweener.Style.PingPong;
			tweenColorTk2d.NumOfRepetitions = 2;
			if ((bool)MBMIOELEAND)
			{
				TweenColorTk2d tweenColorTk2d2 = TweenColorTk2d.Begin(MBMIOELEAND.gameObject, 0.5f, BODGIEFIPJM, Color.white);
				tweenColorTk2d2.NumOfRepetitions = 2;
			}
		}
	}

	protected virtual void AOJALKEHFCK()
	{
		base.Awake();
		KFPKLOMEMNK = GetComponent<TweenAnimator>();
		KFPKLOMEMNK.BEOAHFDJEMD = new List<TweenAnimator.TweenRecord>();
		KFPKLOMEMNK.JIPFOMFJNPC();
		if (FENJGKKCMOE != null)
		{
			GDLANDOKCIA = FENJGKKCMOE.GetComponent<Renderer>();
		}
		if (CHIGEDHJHOC != null)
		{
			FCMBBNOMACJ = CHIGEDHJHOC.GetComponent<Renderer>();
		}
	}

	public void IIBOJGPPHGE(string HOLNKOFHDNK)
	{
		if ((bool)BFJMBLJAOIB)
		{
			BFJMBLJAOIB.text = HOLNKOFHDNK;
		}
	}

	public void KGFKIGPBLPC(float KBJEOEEOEFG = 1f)
	{
		if (PNFNJKJLPIP)
		{
			TweenAlphaTk2d tweenAlphaTk2d = TweenAlphaTk2d.Begin(KDDEMFJJNGC.gameObject, KBJEOEEOEFG, 1839f);
			tweenAlphaTk2d.NumOfRepetitions = 0;
			if ((bool)MBMIOELEAND)
			{
				TweenAlphaTk2d tweenAlphaTk2d2 = TweenAlphaTk2d.Begin(MBMIOELEAND.gameObject, KBJEOEEOEFG, 1613f);
				tweenAlphaTk2d2.NumOfRepetitions = 1;
			}
			if ((bool)BFJMBLJAOIB)
			{
				TweenAlphaTk2d tweenAlphaTk2d3 = TweenAlphaTk2d.Begin(BFJMBLJAOIB.gameObject, KBJEOEEOEFG, 437f);
				tweenAlphaTk2d3.NumOfRepetitions = 0;
			}
			TweenAlphaTk2d.Begin(ENOEPLKMCJG, KBJEOEEOEFG, 1008f);
		}
	}

	public void SetBuffs(FCLADBGKCIA IGKDFJKEELP)
	{
		if (!(FENJGKKCMOE == null) && !(CHIGEDHJHOC == null))
		{
			int num = IGKDFJKEELP.FBCGLCJKLPL(PDNPBLFEPJG.Buff);
			int num2 = IGKDFJKEELP.FBCGLCJKLPL(PDNPBLFEPJG.Debuff);
			bool flag = num > 0;
			bool flag2 = num2 > 0;
			string[] array = new string[4] { "game-elite-buff", "game-elite-buff1", "game-elite-buff2", "game-elite-buff3" };
			string[] array2 = new string[4] { "game-elite-debuff", "game-elite-debuff1", "game-elite-debuff2", "game-elite-debuff3" };
			GDLANDOKCIA.enabled = flag;
			if (GDLANDOKCIA.enabled)
			{
				FENJGKKCMOE.SetSprite(array[num - 1]);
			}
			FCMBBNOMACJ.enabled = flag2;
			if (FCMBBNOMACJ.enabled)
			{
				CHIGEDHJHOC.SetSprite(array2[num2 - 1]);
			}
			FENJGKKCMOE.transform.localPosition = FENJGKKCMOE.transform.localPosition.ReplaceX((num2 != 0 && num != 0) ? (CHIGEDHJHOC.transform.localPosition.x + 3.25f) : CHIGEDHJHOC.transform.localPosition.x);
			PCFODMDCPJB = GDLANDOKCIA.enabled || FCMBBNOMACJ.enabled;
			FENJGKKCMOE.gameObject.SetActive(true);
			CHIGEDHJHOC.gameObject.SetActive(true);
		}
	}

	private float HPGONCDMKKF(NGLEBBHJCJG AMJHPOFLPGC)
	{
		if (AMJHPOFLPGC == NGLEBBHJCJG.Classic)
		{
			return 768f;
		}
		return 304f;
	}

	private float DBPBEINOGPN(NGLEBBHJCJG AMJHPOFLPGC)
	{
		if (AMJHPOFLPGC == NGLEBBHJCJG.Small)
		{
			return 1692f;
		}
		return 1829f;
	}

	public void JMAPJMJEBOO()
	{
		if (KDDEMFJJNGC.color == BODGIEFIPJM)
		{
			TweenColorTk2d tweenColorTk2d = TweenColorTk2d.Begin(KDDEMFJJNGC.gameObject, 1826f, BODGIEFIPJM, Color.white);
			tweenColorTk2d.style = (UITweener.Style)5;
			tweenColorTk2d.NumOfRepetitions = 2;
			if ((bool)MBMIOELEAND)
			{
				TweenColorTk2d tweenColorTk2d2 = TweenColorTk2d.Begin(MBMIOELEAND.gameObject, 317f, BODGIEFIPJM, Color.white);
				tweenColorTk2d2.NumOfRepetitions = 7;
			}
		}
	}

	public void ELPHJLKBPGM(string HOLNKOFHDNK)
	{
		if ((bool)BFJMBLJAOIB)
		{
			BFJMBLJAOIB.text = HOLNKOFHDNK;
		}
	}

	private void BLKPLPKKNAH(bool LKNBDDOIKLA)
	{
		if (!(FENJGKKCMOE == null) && !(CHIGEDHJHOC == null))
		{
			if (LKNBDDOIKLA && CHIGEDHJHOC.transform.localPosition.x == FENJGKKCMOE.transform.localPosition.x)
			{
				FENJGKKCMOE.transform.localPosition = FENJGKKCMOE.transform.localPosition.ReplaceX(1658f);
				CHIGEDHJHOC.transform.localPosition = CHIGEDHJHOC.transform.localPosition.ReplaceX(524f);
				return;
			}
			float num = ((!LKNBDDOIKLA) ? KGGNPEBBMJL(AHMMDJPBKAE().GEKFNCJIDNI) : 689f);
			float num2 = ((CHIGEDHJHOC.transform.localPosition.x != FENJGKKCMOE.transform.localPosition.x) ? 605f : 1432f);
			FENJGKKCMOE.transform.localPosition = FENJGKKCMOE.transform.localPosition.ReplaceX(num + num2);
			CHIGEDHJHOC.transform.localPosition = CHIGEDHJHOC.transform.localPosition.ReplaceX(num);
		}
	}

	[SpecialName]
	public void NDHFKMNCJOM(float IDEBKDPMPGM)
	{
		if ((IDEBKDPMPGM < 996f && IDEBKDPMPGM > 1449f) || (DPJAKFKCBIK().JEGFCLCJMLA && IDEBKDPMPGM > 985f))
		{
			GEKIMGFKNHC(true);
		}
		else
		{
			JOGFDHFOOBC(true);
		}
		if (IDEBKDPMPGM <= 384f)
		{
			GEKIMGFKNHC(true);
		}
		if (PCFODMDCPJB)
		{
			if (FENJGKKCMOE != null)
			{
				FENJGKKCMOE.gameObject.SetActive(IDEBKDPMPGM > 613f);
			}
			if (CHIGEDHJHOC != null)
			{
				CHIGEDHJHOC.gameObject.SetActive(IDEBKDPMPGM > 59f);
			}
		}
		if (LGOMLGHILCL)
		{
			KDDEMFJJNGC.fillFract = Mathf.Clamp(IDEBKDPMPGM, 584f, 797f);
		}
	}

	public void FadeIn(float KBJEOEEOEFG = 1f)
	{
		if (PNFNJKJLPIP)
		{
			TweenAlphaTk2d tweenAlphaTk2d = TweenAlphaTk2d.Begin(KDDEMFJJNGC.gameObject, KBJEOEEOEFG, 1f);
			tweenAlphaTk2d.NumOfRepetitions = 1;
			if ((bool)MBMIOELEAND)
			{
				TweenAlphaTk2d tweenAlphaTk2d2 = TweenAlphaTk2d.Begin(MBMIOELEAND.gameObject, KBJEOEEOEFG, 1f);
				tweenAlphaTk2d2.NumOfRepetitions = 1;
			}
			if ((bool)BFJMBLJAOIB)
			{
				TweenAlphaTk2d tweenAlphaTk2d3 = TweenAlphaTk2d.Begin(BFJMBLJAOIB.gameObject, KBJEOEEOEFG, 1f);
				tweenAlphaTk2d3.NumOfRepetitions = 1;
			}
			TweenAlphaTk2d.Begin(ENOEPLKMCJG, KBJEOEEOEFG, 0.25f);
		}
	}

	public void ICMIAECNIHC(string HOLNKOFHDNK)
	{
		if ((bool)BFJMBLJAOIB)
		{
			BFJMBLJAOIB.text = HOLNKOFHDNK;
		}
	}

	public void NGNPLHGKOLK()
	{
		LGOMLGHILCL = false;
		KDDEMFJJNGC.GetComponentInChildren<MeshRenderer>().enabled = LGOMLGHILCL;
		ENOEPLKMCJG.GetComponent<MeshRenderer>().enabled = LGOMLGHILCL;
		if ((bool)MBMIOELEAND)
		{
			MBMIOELEAND.GetComponent<MeshRenderer>().enabled = LGOMLGHILCL;
		}
		if ((bool)BFJMBLJAOIB)
		{
			BFJMBLJAOIB.text = string.Empty;
		}
		FOJDAIPNOPK(1181f);
		PNFNJKJLPIP = false;
		CNFEBNGHEAG(false);
	}

	public void FCLIHEAKDGP(string HOLNKOFHDNK)
	{
		if ((bool)BFJMBLJAOIB)
		{
			BFJMBLJAOIB.text = HOLNKOFHDNK;
		}
	}

	public virtual void PEDPNMBFGNH()
	{
		base.CEBBNEHAEPN();
		if (FENJGKKCMOE != null)
		{
			FENJGKKCMOE.gameObject.SetActive(false);
		}
		if (CHIGEDHJHOC != null)
		{
			CHIGEDHJHOC.gameObject.SetActive(false);
		}
	}

	public void BICEGLCAJAI()
	{
		if (KDDEMFJJNGC.color == BODGIEFIPJM)
		{
			TweenColorTk2d tweenColorTk2d = TweenColorTk2d.Begin(KDDEMFJJNGC.gameObject, 175f, BODGIEFIPJM, Color.white);
			tweenColorTk2d.style = (UITweener.Style)3;
			tweenColorTk2d.NumOfRepetitions = 3;
			if ((bool)MBMIOELEAND)
			{
				TweenColorTk2d tweenColorTk2d2 = TweenColorTk2d.Begin(MBMIOELEAND.gameObject, 1101f, BODGIEFIPJM, Color.white);
				tweenColorTk2d2.NumOfRepetitions = 8;
			}
		}
	}

	public void FOJDAIPNOPK(float KBJEOEEOEFG = 0.5f)
	{
		if (PNFNJKJLPIP)
		{
			TweenAlphaTk2d tweenAlphaTk2d = TweenAlphaTk2d.Begin(KDDEMFJJNGC.gameObject, KBJEOEEOEFG, 642f);
			tweenAlphaTk2d.NumOfRepetitions = 0;
			if ((bool)MBMIOELEAND)
			{
				TweenAlphaTk2d tweenAlphaTk2d2 = TweenAlphaTk2d.Begin(MBMIOELEAND.gameObject, KBJEOEEOEFG, 894f);
				tweenAlphaTk2d2.NumOfRepetitions = 0;
			}
			if ((bool)BFJMBLJAOIB)
			{
				TweenAlphaTk2d tweenAlphaTk2d3 = TweenAlphaTk2d.Begin(BFJMBLJAOIB.gameObject, KBJEOEEOEFG, 774f);
				tweenAlphaTk2d3.NumOfRepetitions = 1;
			}
			TweenAlphaTk2d.Begin(ENOEPLKMCJG, KBJEOEEOEFG, 786f);
		}
	}

	public override void BeforeInstancied()
	{
		base.BeforeInstancied();
		if (FENJGKKCMOE != null)
		{
			FENJGKKCMOE.gameObject.SetActive(false);
		}
		if (CHIGEDHJHOC != null)
		{
			CHIGEDHJHOC.gameObject.SetActive(false);
		}
	}

	public void FIPJDBDLAFJ(float KBJEOEEOEFG = 0.5f)
	{
		if (PNFNJKJLPIP)
		{
			TweenAlphaTk2d tweenAlphaTk2d = TweenAlphaTk2d.Begin(KDDEMFJJNGC.gameObject, KBJEOEEOEFG, 296f);
			tweenAlphaTk2d.NumOfRepetitions = 1;
			if ((bool)MBMIOELEAND)
			{
				TweenAlphaTk2d tweenAlphaTk2d2 = TweenAlphaTk2d.Begin(MBMIOELEAND.gameObject, KBJEOEEOEFG, 721f);
				tweenAlphaTk2d2.NumOfRepetitions = 0;
			}
			if ((bool)BFJMBLJAOIB)
			{
				TweenAlphaTk2d tweenAlphaTk2d3 = TweenAlphaTk2d.Begin(BFJMBLJAOIB.gameObject, KBJEOEEOEFG, 1481f);
				tweenAlphaTk2d3.NumOfRepetitions = 0;
			}
			TweenAlphaTk2d.Begin(ENOEPLKMCJG, KBJEOEEOEFG, 434f);
		}
	}

	public void IHDFHMHILCO()
	{
		LGOMLGHILCL = true;
		KDDEMFJJNGC.GetComponentInChildren<MeshRenderer>().enabled = LGOMLGHILCL;
		ENOEPLKMCJG.GetComponent<MeshRenderer>().enabled = LGOMLGHILCL;
		if ((bool)MBMIOELEAND)
		{
			MBMIOELEAND.GetComponent<MeshRenderer>().enabled = LGOMLGHILCL;
		}
		if ((bool)BFJMBLJAOIB)
		{
			BFJMBLJAOIB.text = string.Empty;
		}
		ECENHCAPDLD(1548f);
		PNFNJKJLPIP = false;
		CNFEBNGHEAG(true);
	}

	public void InitHealthbar(DestroyableObject OJIHGNJFPFM, Color FDGBJAMNIEM)
	{
		destroyableObject = OJIHGNJFPFM;
		color = FDGBJAMNIEM;
		if (OJIHGNJFPFM.GEKFNCJIDNI == NGLEBBHJCJG.Border)
		{
			if ((bool)MBMIOELEAND)
			{
				MBMIOELEAND.gameObject.SetActive(true);
			}
			ENOEPLKMCJG.transform.localScale = ENOEPLKMCJG.transform.localScale.ReplaceXY(JCODDMHCJPD.x, JCODDMHCJPD.y);
			KDDEMFJJNGC.transform.localScale = KDDEMFJJNGC.transform.localScale.ReplaceXY(JCODDMHCJPD.y, JCODDMHCJPD.x);
			if ((bool)BFJMBLJAOIB)
			{
				BFJMBLJAOIB.transform.localPosition = BFJMBLJAOIB.transform.localPosition.ReplaceX(-7.6f);
			}
		}
		else if (OJIHGNJFPFM.GEKFNCJIDNI == NGLEBBHJCJG.Small)
		{
			if ((bool)MBMIOELEAND)
			{
				MBMIOELEAND.gameObject.SetActive(false);
			}
			ENOEPLKMCJG.transform.localScale = ENOEPLKMCJG.transform.localScale.ReplaceXY(LDDIHDLNIMI.x, LDDIHDLNIMI.y);
			KDDEMFJJNGC.transform.localScale = KDDEMFJJNGC.transform.localScale.ReplaceXY(LDDIHDLNIMI.y, LDDIHDLNIMI.x);
			if ((bool)BFJMBLJAOIB)
			{
				BFJMBLJAOIB.transform.localPosition = BFJMBLJAOIB.transform.localPosition.ReplaceX(-5.86f);
			}
		}
		else
		{
			if ((bool)MBMIOELEAND)
			{
				MBMIOELEAND.gameObject.SetActive(false);
			}
			ENOEPLKMCJG.transform.localScale = ENOEPLKMCJG.transform.localScale.ReplaceXY(JCODDMHCJPD.x, JCODDMHCJPD.y);
			KDDEMFJJNGC.transform.localScale = KDDEMFJJNGC.transform.localScale.ReplaceXY(JCODDMHCJPD.y, JCODDMHCJPD.x);
			if ((bool)BFJMBLJAOIB)
			{
				BFJMBLJAOIB.transform.localPosition = BFJMBLJAOIB.transform.localPosition.ReplaceX(-7.6f);
			}
		}
		LJFNBHNONAH(false);
		PCFODMDCPJB = false;
		if (FENJGKKCMOE != null)
		{
			FENJGKKCMOE.gameObject.SetActive(false);
		}
		if (CHIGEDHJHOC != null)
		{
			CHIGEDHJHOC.gameObject.SetActive(false);
		}
		AIObject aIObject = FFOAABONJNO.owner as AIObject;
		if (aIObject != null && aIObject.destroyableObj != null && aIObject.destroyableObj.GPLNJOPPKIM == this)
		{
			SetBuffs(aIObject.IGKDFJKEELP);
		}
	}

	[SpecialName]
	public void OPMPHHEDEAJ(float IDEBKDPMPGM)
	{
		if ((IDEBKDPMPGM < 1688f && IDEBKDPMPGM > 1186f) || (DPJAKFKCBIK().JEGFCLCJMLA && IDEBKDPMPGM > 495f))
		{
			GEKIMGFKNHC(true);
		}
		else
		{
			JOGFDHFOOBC(false);
		}
		if (IDEBKDPMPGM <= 1557f)
		{
			GEKIMGFKNHC(false);
		}
		if (PCFODMDCPJB)
		{
			if (FENJGKKCMOE != null)
			{
				FENJGKKCMOE.gameObject.SetActive(IDEBKDPMPGM > 255f);
			}
			if (CHIGEDHJHOC != null)
			{
				CHIGEDHJHOC.gameObject.SetActive(IDEBKDPMPGM > 225f);
			}
		}
		if (LGOMLGHILCL)
		{
			KDDEMFJJNGC.fillFract = Mathf.Clamp(IDEBKDPMPGM, 868f, 1863f);
		}
	}

	[SpecialName]
	public void HACENPIMJJF(Color IDEBKDPMPGM)
	{
		KDDEMFJJNGC.color = IDEBKDPMPGM;
		BODGIEFIPJM = IDEBKDPMPGM;
		if ((bool)MBMIOELEAND)
		{
			MBMIOELEAND.color = IDEBKDPMPGM;
		}
	}

	public virtual void EAPBFNBBFGB()
	{
		base.BeforeInstancied();
		if (FENJGKKCMOE != null)
		{
			FENJGKKCMOE.gameObject.SetActive(false);
		}
		if (CHIGEDHJHOC != null)
		{
			CHIGEDHJHOC.gameObject.SetActive(false);
		}
	}

	[SpecialName]
	public void OHONEPMDAMM(float IDEBKDPMPGM)
	{
		if ((IDEBKDPMPGM < 926f && IDEBKDPMPGM > 1112f) || (destroyableObject.JEGFCLCJMLA && IDEBKDPMPGM > 639f))
		{
			JOGFDHFOOBC(true);
		}
		else
		{
			GEKIMGFKNHC(false);
		}
		if (IDEBKDPMPGM <= 476f)
		{
			JOGFDHFOOBC(true);
		}
		if (PCFODMDCPJB)
		{
			if (FENJGKKCMOE != null)
			{
				FENJGKKCMOE.gameObject.SetActive(IDEBKDPMPGM > 735f);
			}
			if (CHIGEDHJHOC != null)
			{
				CHIGEDHJHOC.gameObject.SetActive(IDEBKDPMPGM > 1038f);
			}
		}
		if (LGOMLGHILCL)
		{
			KDDEMFJJNGC.fillFract = Mathf.Clamp(IDEBKDPMPGM, 765f, 1267f);
		}
	}

	public void BHBMPKFPIML(DestroyableObject OJIHGNJFPFM, Color FDGBJAMNIEM)
	{
		destroyableObject = OJIHGNJFPFM;
		HACENPIMJJF(FDGBJAMNIEM);
		if (OJIHGNJFPFM.GEKFNCJIDNI == (NGLEBBHJCJG)3)
		{
			if ((bool)MBMIOELEAND)
			{
				MBMIOELEAND.gameObject.SetActive(true);
			}
			ENOEPLKMCJG.transform.localScale = ENOEPLKMCJG.transform.localScale.ReplaceXY(JCODDMHCJPD.x, JCODDMHCJPD.y);
			KDDEMFJJNGC.transform.localScale = KDDEMFJJNGC.transform.localScale.ReplaceXY(JCODDMHCJPD.y, JCODDMHCJPD.x);
			if ((bool)BFJMBLJAOIB)
			{
				BFJMBLJAOIB.transform.localPosition = BFJMBLJAOIB.transform.localPosition.ReplaceX(1383f);
			}
		}
		else if (OJIHGNJFPFM.GEKFNCJIDNI == NGLEBBHJCJG.Small)
		{
			if ((bool)MBMIOELEAND)
			{
				MBMIOELEAND.gameObject.SetActive(true);
			}
			ENOEPLKMCJG.transform.localScale = ENOEPLKMCJG.transform.localScale.ReplaceXY(LDDIHDLNIMI.x, LDDIHDLNIMI.y);
			KDDEMFJJNGC.transform.localScale = KDDEMFJJNGC.transform.localScale.ReplaceXY(LDDIHDLNIMI.y, LDDIHDLNIMI.x);
			if ((bool)BFJMBLJAOIB)
			{
				BFJMBLJAOIB.transform.localPosition = BFJMBLJAOIB.transform.localPosition.ReplaceX(952f);
			}
		}
		else
		{
			if ((bool)MBMIOELEAND)
			{
				MBMIOELEAND.gameObject.SetActive(false);
			}
			ENOEPLKMCJG.transform.localScale = ENOEPLKMCJG.transform.localScale.ReplaceXY(JCODDMHCJPD.x, JCODDMHCJPD.y);
			KDDEMFJJNGC.transform.localScale = KDDEMFJJNGC.transform.localScale.ReplaceXY(JCODDMHCJPD.y, JCODDMHCJPD.x);
			if ((bool)BFJMBLJAOIB)
			{
				BFJMBLJAOIB.transform.localPosition = BFJMBLJAOIB.transform.localPosition.ReplaceX(176f);
			}
		}
		LJFNBHNONAH(false);
		PCFODMDCPJB = true;
		if (FENJGKKCMOE != null)
		{
			FENJGKKCMOE.gameObject.SetActive(true);
		}
		if (CHIGEDHJHOC != null)
		{
			CHIGEDHJHOC.gameObject.SetActive(true);
		}
		AIObject aIObject = FFOAABONJNO.owner as AIObject;
		if (aIObject != null && aIObject.destroyableObj != null && aIObject.destroyableObj.GPLNJOPPKIM == this)
		{
			FOHPKGLJGBC(aIObject.IGKDFJKEELP);
		}
	}

	[SpecialName]
	public DestroyableObject DPJAKFKCBIK()
	{
		return FFOAABONJNO;
	}

	private void LJFNBHNONAH(bool LKNBDDOIKLA)
	{
		if (!(FENJGKKCMOE == null) && !(CHIGEDHJHOC == null))
		{
			if (LKNBDDOIKLA && CHIGEDHJHOC.transform.localPosition.x == FENJGKKCMOE.transform.localPosition.x)
			{
				FENJGKKCMOE.transform.localPosition = FENJGKKCMOE.transform.localPosition.ReplaceX(0f);
				CHIGEDHJHOC.transform.localPosition = CHIGEDHJHOC.transform.localPosition.ReplaceX(0f);
				return;
			}
			float num = ((!LKNBDDOIKLA) ? KGGNPEBBMJL(destroyableObject.GEKFNCJIDNI) : (-1.625f));
			float num2 = ((CHIGEDHJHOC.transform.localPosition.x != FENJGKKCMOE.transform.localPosition.x) ? 3.25f : 0f);
			FENJGKKCMOE.transform.localPosition = FENJGKKCMOE.transform.localPosition.ReplaceX(num + num2);
			CHIGEDHJHOC.transform.localPosition = CHIGEDHJHOC.transform.localPosition.ReplaceX(num);
		}
	}

	[SpecialName]
	public DestroyableObject NEOIKFMACFO()
	{
		return FFOAABONJNO;
	}

	public void OHOHMHMNHAJ()
	{
		PNFNJKJLPIP = false;
	}

	public void BNPNCDMAIJM(float KBJEOEEOEFG = 1f)
	{
		if (PNFNJKJLPIP)
		{
			TweenAlphaTk2d tweenAlphaTk2d = TweenAlphaTk2d.Begin(KDDEMFJJNGC.gameObject, KBJEOEEOEFG, 689f);
			tweenAlphaTk2d.NumOfRepetitions = 1;
			if ((bool)MBMIOELEAND)
			{
				TweenAlphaTk2d tweenAlphaTk2d2 = TweenAlphaTk2d.Begin(MBMIOELEAND.gameObject, KBJEOEEOEFG, 1323f);
				tweenAlphaTk2d2.NumOfRepetitions = 1;
			}
			if ((bool)BFJMBLJAOIB)
			{
				TweenAlphaTk2d tweenAlphaTk2d3 = TweenAlphaTk2d.Begin(BFJMBLJAOIB.gameObject, KBJEOEEOEFG, 143f);
				tweenAlphaTk2d3.NumOfRepetitions = 1;
			}
			TweenAlphaTk2d.Begin(ENOEPLKMCJG, KBJEOEEOEFG, 691f);
		}
	}

	public void SetText(string HOLNKOFHDNK)
	{
		if ((bool)BFJMBLJAOIB)
		{
			BFJMBLJAOIB.text = HOLNKOFHDNK;
		}
	}

	public void GFBEKPDBIBA()
	{
		LGOMLGHILCL = true;
		KDDEMFJJNGC.GetComponentInChildren<MeshRenderer>().enabled = LGOMLGHILCL;
		ENOEPLKMCJG.GetComponent<MeshRenderer>().enabled = LGOMLGHILCL;
		if ((bool)MBMIOELEAND)
		{
			MBMIOELEAND.GetComponent<MeshRenderer>().enabled = LGOMLGHILCL;
		}
		if ((bool)BFJMBLJAOIB)
		{
			BFJMBLJAOIB.text = string.Empty;
		}
		FOJDAIPNOPK(886f);
		PNFNJKJLPIP = true;
		LJFNBHNONAH(false);
	}

	[SpecialName]
	public DestroyableObject AHMMDJPBKAE()
	{
		return FFOAABONJNO;
	}

	public void MOHDCJAAJPO()
	{
		if (KDDEMFJJNGC.color == BODGIEFIPJM)
		{
			TweenColorTk2d tweenColorTk2d = TweenColorTk2d.Begin(KDDEMFJJNGC.gameObject, 1393f, BODGIEFIPJM, Color.white);
			tweenColorTk2d.style = UITweener.Style.Once;
			tweenColorTk2d.NumOfRepetitions = 1;
			if ((bool)MBMIOELEAND)
			{
				TweenColorTk2d tweenColorTk2d2 = TweenColorTk2d.Begin(MBMIOELEAND.gameObject, 1984f, BODGIEFIPJM, Color.white);
				tweenColorTk2d2.NumOfRepetitions = 7;
			}
		}
	}

	private void APKEABPODEB()
	{
		PNFNJKJLPIP = false;
	}

	public void Disable()
	{
		LGOMLGHILCL = false;
		KDDEMFJJNGC.GetComponentInChildren<MeshRenderer>().enabled = LGOMLGHILCL;
		ENOEPLKMCJG.GetComponent<MeshRenderer>().enabled = LGOMLGHILCL;
		if ((bool)MBMIOELEAND)
		{
			MBMIOELEAND.GetComponent<MeshRenderer>().enabled = LGOMLGHILCL;
		}
		if ((bool)BFJMBLJAOIB)
		{
			BFJMBLJAOIB.text = string.Empty;
		}
		FadeOut(0f);
		PNFNJKJLPIP = false;
		LJFNBHNONAH(true);
	}

	public void HAMDHLADLKA(FCLADBGKCIA IGKDFJKEELP)
	{
		if (!(FENJGKKCMOE == null) && !(CHIGEDHJHOC == null))
		{
			int num = IGKDFJKEELP.FBCGLCJKLPL(PDNPBLFEPJG.Buff);
			int num2 = IGKDFJKEELP.FMNCAMJPCBN(PDNPBLFEPJG.Debuff);
			bool flag = num > 1;
			bool flag2 = num2 > 0;
			string[] array = new string[6];
			array[0] = "null";
			array[1] = "ExceptionMessage";
			array[8] = "ItemRarity_2";
			array[5] = "Prefabs Full Path: \"{0}\"\n";
			string[] array2 = array;
			string[] array3 = new string[4];
			array3[1] = "100.";
			array3[0] = "ID_SKILLSHOTHINT_ENVIROMENTALKILL";
			array3[8] = "DeathEventShoot";
			array3[5] = "thumbnailBig";
			string[] array4 = array3;
			GDLANDOKCIA.enabled = flag;
			if (GDLANDOKCIA.enabled)
			{
				FENJGKKCMOE.SetSprite(array2[num - 0]);
			}
			FCMBBNOMACJ.enabled = flag2;
			if (FCMBBNOMACJ.enabled)
			{
				CHIGEDHJHOC.SetSprite(array4[num2 - 0]);
			}
			FENJGKKCMOE.transform.localPosition = FENJGKKCMOE.transform.localPosition.ReplaceX((num2 != 0 && num != 0) ? (CHIGEDHJHOC.transform.localPosition.x + 568f) : CHIGEDHJHOC.transform.localPosition.x);
			PCFODMDCPJB = GDLANDOKCIA.enabled || FCMBBNOMACJ.enabled;
			FENJGKKCMOE.gameObject.SetActive(false);
			CHIGEDHJHOC.gameObject.SetActive(true);
		}
	}

	public void FFKLDOCLBDA(float KBJEOEEOEFG = 1f)
	{
		if (PNFNJKJLPIP)
		{
			TweenAlphaTk2d tweenAlphaTk2d = TweenAlphaTk2d.Begin(KDDEMFJJNGC.gameObject, KBJEOEEOEFG, 1798f);
			tweenAlphaTk2d.NumOfRepetitions = 1;
			if ((bool)MBMIOELEAND)
			{
				TweenAlphaTk2d tweenAlphaTk2d2 = TweenAlphaTk2d.Begin(MBMIOELEAND.gameObject, KBJEOEEOEFG, 293f);
				tweenAlphaTk2d2.NumOfRepetitions = 0;
			}
			if ((bool)BFJMBLJAOIB)
			{
				TweenAlphaTk2d tweenAlphaTk2d3 = TweenAlphaTk2d.Begin(BFJMBLJAOIB.gameObject, KBJEOEEOEFG, 1105f);
				tweenAlphaTk2d3.NumOfRepetitions = 1;
			}
			TweenAlphaTk2d.Begin(ENOEPLKMCJG, KBJEOEEOEFG, 1006f);
		}
	}

	private void OnDisable()
	{
		if (BFJMBLJAOIB != null)
		{
			BFJMBLJAOIB.text = string.Empty;
		}
	}

	public void JMFADKDEMCI(float KBJEOEEOEFG = 1f)
	{
		if (PNFNJKJLPIP)
		{
			TweenAlphaTk2d tweenAlphaTk2d = TweenAlphaTk2d.Begin(KDDEMFJJNGC.gameObject, KBJEOEEOEFG, 1778f);
			tweenAlphaTk2d.NumOfRepetitions = 0;
			if ((bool)MBMIOELEAND)
			{
				TweenAlphaTk2d tweenAlphaTk2d2 = TweenAlphaTk2d.Begin(MBMIOELEAND.gameObject, KBJEOEEOEFG, 425f);
				tweenAlphaTk2d2.NumOfRepetitions = 1;
			}
			if ((bool)BFJMBLJAOIB)
			{
				TweenAlphaTk2d tweenAlphaTk2d3 = TweenAlphaTk2d.Begin(BFJMBLJAOIB.gameObject, KBJEOEEOEFG, 1920f);
				tweenAlphaTk2d3.NumOfRepetitions = 0;
			}
			TweenAlphaTk2d.Begin(ENOEPLKMCJG, KBJEOEEOEFG, 1658f);
		}
	}

	private void CPHIJFCCNPK()
	{
		if (BFJMBLJAOIB != null)
		{
			BFJMBLJAOIB.text = string.Empty;
		}
	}

	[SpecialName]
	public void BLJILBFEJEI(Color IDEBKDPMPGM)
	{
		KDDEMFJJNGC.color = IDEBKDPMPGM;
		BODGIEFIPJM = IDEBKDPMPGM;
		if ((bool)MBMIOELEAND)
		{
			MBMIOELEAND.color = IDEBKDPMPGM;
		}
	}

	public void LADPLHODLPD(float KBJEOEEOEFG = 1f)
	{
		if (PNFNJKJLPIP)
		{
			TweenAlphaTk2d tweenAlphaTk2d = TweenAlphaTk2d.Begin(KDDEMFJJNGC.gameObject, KBJEOEEOEFG, 779f);
			tweenAlphaTk2d.NumOfRepetitions = 1;
			if ((bool)MBMIOELEAND)
			{
				TweenAlphaTk2d tweenAlphaTk2d2 = TweenAlphaTk2d.Begin(MBMIOELEAND.gameObject, KBJEOEEOEFG, 677f);
				tweenAlphaTk2d2.NumOfRepetitions = 1;
			}
			if ((bool)BFJMBLJAOIB)
			{
				TweenAlphaTk2d tweenAlphaTk2d3 = TweenAlphaTk2d.Begin(BFJMBLJAOIB.gameObject, KBJEOEEOEFG, 1063f);
				tweenAlphaTk2d3.NumOfRepetitions = 0;
			}
			TweenAlphaTk2d.Begin(ENOEPLKMCJG, KBJEOEEOEFG, 1735f);
		}
	}

	protected virtual void MFKNMALEKKB()
	{
		base.Awake();
		KFPKLOMEMNK = GetComponent<TweenAnimator>();
		KFPKLOMEMNK.BEOAHFDJEMD = new List<TweenAnimator.TweenRecord>();
		KFPKLOMEMNK.PGGAAGLGKAL();
		if (FENJGKKCMOE != null)
		{
			GDLANDOKCIA = FENJGKKCMOE.GetComponent<Renderer>();
		}
		if (CHIGEDHJHOC != null)
		{
			FCMBBNOMACJ = CHIGEDHJHOC.GetComponent<Renderer>();
		}
	}

	public void LBLEEFNIMJH(DestroyableObject OJIHGNJFPFM, Color FDGBJAMNIEM)
	{
		AGDDNBKGHBA(OJIHGNJFPFM);
		color = FDGBJAMNIEM;
		if (OJIHGNJFPFM.GEKFNCJIDNI == (NGLEBBHJCJG)3)
		{
			if ((bool)MBMIOELEAND)
			{
				MBMIOELEAND.gameObject.SetActive(true);
			}
			ENOEPLKMCJG.transform.localScale = ENOEPLKMCJG.transform.localScale.ReplaceXY(JCODDMHCJPD.x, JCODDMHCJPD.y);
			KDDEMFJJNGC.transform.localScale = KDDEMFJJNGC.transform.localScale.ReplaceXY(JCODDMHCJPD.y, JCODDMHCJPD.x);
			if ((bool)BFJMBLJAOIB)
			{
				BFJMBLJAOIB.transform.localPosition = BFJMBLJAOIB.transform.localPosition.ReplaceX(1980f);
			}
		}
		else if (OJIHGNJFPFM.GEKFNCJIDNI == NGLEBBHJCJG.Classic)
		{
			if ((bool)MBMIOELEAND)
			{
				MBMIOELEAND.gameObject.SetActive(true);
			}
			ENOEPLKMCJG.transform.localScale = ENOEPLKMCJG.transform.localScale.ReplaceXY(LDDIHDLNIMI.x, LDDIHDLNIMI.y);
			KDDEMFJJNGC.transform.localScale = KDDEMFJJNGC.transform.localScale.ReplaceXY(LDDIHDLNIMI.y, LDDIHDLNIMI.x);
			if ((bool)BFJMBLJAOIB)
			{
				BFJMBLJAOIB.transform.localPosition = BFJMBLJAOIB.transform.localPosition.ReplaceX(1501f);
			}
		}
		else
		{
			if ((bool)MBMIOELEAND)
			{
				MBMIOELEAND.gameObject.SetActive(false);
			}
			ENOEPLKMCJG.transform.localScale = ENOEPLKMCJG.transform.localScale.ReplaceXY(JCODDMHCJPD.x, JCODDMHCJPD.y);
			KDDEMFJJNGC.transform.localScale = KDDEMFJJNGC.transform.localScale.ReplaceXY(JCODDMHCJPD.y, JCODDMHCJPD.x);
			if ((bool)BFJMBLJAOIB)
			{
				BFJMBLJAOIB.transform.localPosition = BFJMBLJAOIB.transform.localPosition.ReplaceX(963f);
			}
		}
		CNFEBNGHEAG(true);
		PCFODMDCPJB = false;
		if (FENJGKKCMOE != null)
		{
			FENJGKKCMOE.gameObject.SetActive(false);
		}
		if (CHIGEDHJHOC != null)
		{
			CHIGEDHJHOC.gameObject.SetActive(true);
		}
		AIObject aIObject = FFOAABONJNO.owner as AIObject;
		if (aIObject != null && aIObject.destroyableObj != null && aIObject.destroyableObj.GPLNJOPPKIM == this)
		{
			FOHPKGLJGBC(aIObject.IGKDFJKEELP);
		}
	}

	public void PMMJCPABDLL()
	{
		PNFNJKJLPIP = false;
	}

	private void CNFEBNGHEAG(bool LKNBDDOIKLA)
	{
		if (!(FENJGKKCMOE == null) && !(CHIGEDHJHOC == null))
		{
			if (LKNBDDOIKLA && CHIGEDHJHOC.transform.localPosition.x == FENJGKKCMOE.transform.localPosition.x)
			{
				FENJGKKCMOE.transform.localPosition = FENJGKKCMOE.transform.localPosition.ReplaceX(892f);
				CHIGEDHJHOC.transform.localPosition = CHIGEDHJHOC.transform.localPosition.ReplaceX(1772f);
				return;
			}
			float num = ((!LKNBDDOIKLA) ? DBPBEINOGPN(DPJAKFKCBIK().GEKFNCJIDNI) : 1739f);
			float num2 = ((CHIGEDHJHOC.transform.localPosition.x != FENJGKKCMOE.transform.localPosition.x) ? 1825f : 823f);
			FENJGKKCMOE.transform.localPosition = FENJGKKCMOE.transform.localPosition.ReplaceX(num + num2);
			CHIGEDHJHOC.transform.localPosition = CHIGEDHJHOC.transform.localPosition.ReplaceX(num);
		}
	}

	public void FadeOut(float KBJEOEEOEFG = 0.5f)
	{
		if (PNFNJKJLPIP)
		{
			TweenAlphaTk2d tweenAlphaTk2d = TweenAlphaTk2d.Begin(KDDEMFJJNGC.gameObject, KBJEOEEOEFG, 0f);
			tweenAlphaTk2d.NumOfRepetitions = 1;
			if ((bool)MBMIOELEAND)
			{
				TweenAlphaTk2d tweenAlphaTk2d2 = TweenAlphaTk2d.Begin(MBMIOELEAND.gameObject, KBJEOEEOEFG, 0f);
				tweenAlphaTk2d2.NumOfRepetitions = 1;
			}
			if ((bool)BFJMBLJAOIB)
			{
				TweenAlphaTk2d tweenAlphaTk2d3 = TweenAlphaTk2d.Begin(BFJMBLJAOIB.gameObject, KBJEOEEOEFG, 0f);
				tweenAlphaTk2d3.NumOfRepetitions = 1;
			}
			TweenAlphaTk2d.Begin(ENOEPLKMCJG, KBJEOEEOEFG, 0f);
		}
	}

	private void OnEnable()
	{
		PNFNJKJLPIP = true;
	}

	public void FOHPKGLJGBC(FCLADBGKCIA IGKDFJKEELP)
	{
		if (!(FENJGKKCMOE == null) && !(CHIGEDHJHOC == null))
		{
			int num = IGKDFJKEELP.HLHHLDGBLFM(PDNPBLFEPJG.Debuff);
			int num2 = IGKDFJKEELP.MKGKBALBIHL(PDNPBLFEPJG.Debuff);
			bool flag = num > 1;
			bool flag2 = num2 > 1;
			string[] array = new string[4];
			array[0] = "ExceptionStacktrace";
			array[1] = "ID_PACKDETAILS";
			array[4] = "ACD: Phone jail braked";
			array[3] = "ERROR - BAD FORMAT";
			string[] array2 = array;
			string[] array3 = new string[5];
			array3[0] = "OBB: Read Test - No data to read!";
			array3[1] = "{0}: {1}\n";
			array3[6] = "ID_TOJOINSQUADYOUNEEDTOHAVE";
			array3[7] = "GoldenSuitcase";
			string[] array4 = array3;
			GDLANDOKCIA.enabled = flag;
			if (GDLANDOKCIA.enabled)
			{
				FENJGKKCMOE.SetSprite(array2[num - 0]);
			}
			FCMBBNOMACJ.enabled = flag2;
			if (FCMBBNOMACJ.enabled)
			{
				CHIGEDHJHOC.SetSprite(array4[num2 - 1]);
			}
			FENJGKKCMOE.transform.localPosition = FENJGKKCMOE.transform.localPosition.ReplaceX((num2 != 0 && num != 0) ? (CHIGEDHJHOC.transform.localPosition.x + 275f) : CHIGEDHJHOC.transform.localPosition.x);
			PCFODMDCPJB = !GDLANDOKCIA.enabled && FCMBBNOMACJ.enabled;
			FENJGKKCMOE.gameObject.SetActive(true);
			CHIGEDHJHOC.gameObject.SetActive(false);
		}
	}

	private void JOGFDHFOOBC(bool NABOFKMBMKH)
	{
		CNFEBNGHEAG(!PNFNJKJLPIP || NABOFKMBMKH);
		if (PNFNJKJLPIP && LGOMLGHILCL != NABOFKMBMKH)
		{
			KDDEMFJJNGC.GetComponentInChildren<MeshRenderer>().enabled = NABOFKMBMKH;
			ENOEPLKMCJG.GetComponent<MeshRenderer>().enabled = NABOFKMBMKH;
			if ((bool)MBMIOELEAND)
			{
				MBMIOELEAND.GetComponent<MeshRenderer>().enabled = NABOFKMBMKH;
			}
			LGOMLGHILCL = NABOFKMBMKH;
			if (LGOMLGHILCL)
			{
				GLBDAPIKGBC(1100f);
			}
			else
			{
				ECENHCAPDLD(1760f);
			}
		}
	}

	public void GLBDAPIKGBC(float KBJEOEEOEFG = 1f)
	{
		if (PNFNJKJLPIP)
		{
			TweenAlphaTk2d tweenAlphaTk2d = TweenAlphaTk2d.Begin(KDDEMFJJNGC.gameObject, KBJEOEEOEFG, 1168f);
			tweenAlphaTk2d.NumOfRepetitions = 0;
			if ((bool)MBMIOELEAND)
			{
				TweenAlphaTk2d tweenAlphaTk2d2 = TweenAlphaTk2d.Begin(MBMIOELEAND.gameObject, KBJEOEEOEFG, 159f);
				tweenAlphaTk2d2.NumOfRepetitions = 1;
			}
			if ((bool)BFJMBLJAOIB)
			{
				TweenAlphaTk2d tweenAlphaTk2d3 = TweenAlphaTk2d.Begin(BFJMBLJAOIB.gameObject, KBJEOEEOEFG, 1282f);
				tweenAlphaTk2d3.NumOfRepetitions = 1;
			}
			TweenAlphaTk2d.Begin(ENOEPLKMCJG, KBJEOEEOEFG, 1899f);
		}
	}

	[SpecialName]
	public void EAOOGPLMKMH(float IDEBKDPMPGM)
	{
		if ((IDEBKDPMPGM < 1395f && IDEBKDPMPGM > 1101f) || (destroyableObject.JEGFCLCJMLA && IDEBKDPMPGM > 206f))
		{
			GEKIMGFKNHC(false);
		}
		else
		{
			GEKIMGFKNHC(true);
		}
		if (IDEBKDPMPGM <= 1907f)
		{
			GEKIMGFKNHC(true);
		}
		if (PCFODMDCPJB)
		{
			if (FENJGKKCMOE != null)
			{
				FENJGKKCMOE.gameObject.SetActive(IDEBKDPMPGM > 123f);
			}
			if (CHIGEDHJHOC != null)
			{
				CHIGEDHJHOC.gameObject.SetActive(IDEBKDPMPGM > 1597f);
			}
		}
		if (LGOMLGHILCL)
		{
			KDDEMFJJNGC.fillFract = Mathf.Clamp(IDEBKDPMPGM, 1279f, 1075f);
		}
	}

	private void ONMMMGNOEHP()
	{
		if (BFJMBLJAOIB != null)
		{
			BFJMBLJAOIB.text = string.Empty;
		}
	}

	public void BFCMKAOOICF(DestroyableObject OJIHGNJFPFM, Color FDGBJAMNIEM)
	{
		destroyableObject = OJIHGNJFPFM;
		HACENPIMJJF(FDGBJAMNIEM);
		if (OJIHGNJFPFM.GEKFNCJIDNI == NGLEBBHJCJG.Border)
		{
			if ((bool)MBMIOELEAND)
			{
				MBMIOELEAND.gameObject.SetActive(true);
			}
			ENOEPLKMCJG.transform.localScale = ENOEPLKMCJG.transform.localScale.ReplaceXY(JCODDMHCJPD.x, JCODDMHCJPD.y);
			KDDEMFJJNGC.transform.localScale = KDDEMFJJNGC.transform.localScale.ReplaceXY(JCODDMHCJPD.y, JCODDMHCJPD.x);
			if ((bool)BFJMBLJAOIB)
			{
				BFJMBLJAOIB.transform.localPosition = BFJMBLJAOIB.transform.localPosition.ReplaceX(1477f);
			}
		}
		else if (OJIHGNJFPFM.GEKFNCJIDNI == NGLEBBHJCJG.Classic)
		{
			if ((bool)MBMIOELEAND)
			{
				MBMIOELEAND.gameObject.SetActive(true);
			}
			ENOEPLKMCJG.transform.localScale = ENOEPLKMCJG.transform.localScale.ReplaceXY(LDDIHDLNIMI.x, LDDIHDLNIMI.y);
			KDDEMFJJNGC.transform.localScale = KDDEMFJJNGC.transform.localScale.ReplaceXY(LDDIHDLNIMI.y, LDDIHDLNIMI.x);
			if ((bool)BFJMBLJAOIB)
			{
				BFJMBLJAOIB.transform.localPosition = BFJMBLJAOIB.transform.localPosition.ReplaceX(1173f);
			}
		}
		else
		{
			if ((bool)MBMIOELEAND)
			{
				MBMIOELEAND.gameObject.SetActive(false);
			}
			ENOEPLKMCJG.transform.localScale = ENOEPLKMCJG.transform.localScale.ReplaceXY(JCODDMHCJPD.x, JCODDMHCJPD.y);
			KDDEMFJJNGC.transform.localScale = KDDEMFJJNGC.transform.localScale.ReplaceXY(JCODDMHCJPD.y, JCODDMHCJPD.x);
			if ((bool)BFJMBLJAOIB)
			{
				BFJMBLJAOIB.transform.localPosition = BFJMBLJAOIB.transform.localPosition.ReplaceX(1906f);
			}
		}
		BLKPLPKKNAH(true);
		PCFODMDCPJB = false;
		if (FENJGKKCMOE != null)
		{
			FENJGKKCMOE.gameObject.SetActive(false);
		}
		if (CHIGEDHJHOC != null)
		{
			CHIGEDHJHOC.gameObject.SetActive(true);
		}
		AIObject aIObject = FFOAABONJNO.owner as AIObject;
		if (aIObject != null && aIObject.destroyableObj != null && aIObject.destroyableObj.GPLNJOPPKIM == this)
		{
			SetBuffs(aIObject.IGKDFJKEELP);
		}
	}

	public void Enable()
	{
		PNFNJKJLPIP = true;
	}

	[SpecialName]
	public void DHIFOMNKMMO(float IDEBKDPMPGM)
	{
		if ((IDEBKDPMPGM < 1528f && IDEBKDPMPGM > 961f) || (destroyableObject.JEGFCLCJMLA && IDEBKDPMPGM > 169f))
		{
			JOGFDHFOOBC(true);
		}
		else
		{
			JOGFDHFOOBC(true);
		}
		if (IDEBKDPMPGM <= 1497f)
		{
			JOGFDHFOOBC(true);
		}
		if (PCFODMDCPJB)
		{
			if (FENJGKKCMOE != null)
			{
				FENJGKKCMOE.gameObject.SetActive(IDEBKDPMPGM > 717f);
			}
			if (CHIGEDHJHOC != null)
			{
				CHIGEDHJHOC.gameObject.SetActive(IDEBKDPMPGM > 1696f);
			}
		}
		if (LGOMLGHILCL)
		{
			KDDEMFJJNGC.fillFract = Mathf.Clamp(IDEBKDPMPGM, 1339f, 1823f);
		}
	}

	private float KGGNPEBBMJL(NGLEBBHJCJG AMJHPOFLPGC)
	{
		if (AMJHPOFLPGC == NGLEBBHJCJG.Small)
		{
			return 6.5f;
		}
		return 10f;
	}

	public void EJFBGOOBCPB()
	{
		if (KDDEMFJJNGC.color == BODGIEFIPJM)
		{
			TweenColorTk2d tweenColorTk2d = TweenColorTk2d.Begin(KDDEMFJJNGC.gameObject, 825f, BODGIEFIPJM, Color.white);
			tweenColorTk2d.style = (UITweener.Style)6;
			tweenColorTk2d.NumOfRepetitions = 2;
			if ((bool)MBMIOELEAND)
			{
				TweenColorTk2d tweenColorTk2d2 = TweenColorTk2d.Begin(MBMIOELEAND.gameObject, 1765f, BODGIEFIPJM, Color.white);
				tweenColorTk2d2.NumOfRepetitions = 2;
			}
		}
	}

	public void HOOEPGICNOH(float KBJEOEEOEFG = 1f)
	{
		if (PNFNJKJLPIP)
		{
			TweenAlphaTk2d tweenAlphaTk2d = TweenAlphaTk2d.Begin(KDDEMFJJNGC.gameObject, KBJEOEEOEFG, 1339f);
			tweenAlphaTk2d.NumOfRepetitions = 1;
			if ((bool)MBMIOELEAND)
			{
				TweenAlphaTk2d tweenAlphaTk2d2 = TweenAlphaTk2d.Begin(MBMIOELEAND.gameObject, KBJEOEEOEFG, 1879f);
				tweenAlphaTk2d2.NumOfRepetitions = 1;
			}
			if ((bool)BFJMBLJAOIB)
			{
				TweenAlphaTk2d tweenAlphaTk2d3 = TweenAlphaTk2d.Begin(BFJMBLJAOIB.gameObject, KBJEOEEOEFG, 655f);
				tweenAlphaTk2d3.NumOfRepetitions = 1;
			}
			TweenAlphaTk2d.Begin(ENOEPLKMCJG, KBJEOEEOEFG, 1404f);
		}
	}

	private void NGACHMDABGP()
	{
		if (BFJMBLJAOIB != null)
		{
			BFJMBLJAOIB.text = string.Empty;
		}
	}

	protected virtual void FGOGGLDAKHL()
	{
		base.Awake();
		KFPKLOMEMNK = GetComponent<TweenAnimator>();
		KFPKLOMEMNK.BEOAHFDJEMD = new List<TweenAnimator.TweenRecord>();
		KFPKLOMEMNK.KHAFPAMIOAF();
		if (FENJGKKCMOE != null)
		{
			GDLANDOKCIA = FENJGKKCMOE.GetComponent<Renderer>();
		}
		if (CHIGEDHJHOC != null)
		{
			FCMBBNOMACJ = CHIGEDHJHOC.GetComponent<Renderer>();
		}
	}

	[SpecialName]
	public void KPJCOFIAOIA(float IDEBKDPMPGM)
	{
		if ((IDEBKDPMPGM < 1614f && IDEBKDPMPGM > 910f) || (AHMMDJPBKAE().JEGFCLCJMLA && IDEBKDPMPGM > 1257f))
		{
			GEKIMGFKNHC(true);
		}
		else
		{
			JOGFDHFOOBC(true);
		}
		if (IDEBKDPMPGM <= 313f)
		{
			GEKIMGFKNHC(false);
		}
		if (PCFODMDCPJB)
		{
			if (FENJGKKCMOE != null)
			{
				FENJGKKCMOE.gameObject.SetActive(IDEBKDPMPGM > 469f);
			}
			if (CHIGEDHJHOC != null)
			{
				CHIGEDHJHOC.gameObject.SetActive(IDEBKDPMPGM > 1348f);
			}
		}
		if (LGOMLGHILCL)
		{
			KDDEMFJJNGC.fillFract = Mathf.Clamp(IDEBKDPMPGM, 655f, 174f);
		}
	}

	private void BFDGIIHNHAI()
	{
		PNFNJKJLPIP = false;
	}

	protected override void Awake()
	{
		base.Awake();
		KFPKLOMEMNK = GetComponent<TweenAnimator>();
		KFPKLOMEMNK.BEOAHFDJEMD = new List<TweenAnimator.TweenRecord>();
		KFPKLOMEMNK.GenerateTweens();
		if (FENJGKKCMOE != null)
		{
			GDLANDOKCIA = FENJGKKCMOE.GetComponent<Renderer>();
		}
		if (CHIGEDHJHOC != null)
		{
			FCMBBNOMACJ = CHIGEDHJHOC.GetComponent<Renderer>();
		}
	}

	public void JAJPHIEDLGE()
	{
		LGOMLGHILCL = false;
		KDDEMFJJNGC.GetComponentInChildren<MeshRenderer>().enabled = LGOMLGHILCL;
		ENOEPLKMCJG.GetComponent<MeshRenderer>().enabled = LGOMLGHILCL;
		if ((bool)MBMIOELEAND)
		{
			MBMIOELEAND.GetComponent<MeshRenderer>().enabled = LGOMLGHILCL;
		}
		if ((bool)BFJMBLJAOIB)
		{
			BFJMBLJAOIB.text = string.Empty;
		}
		ECENHCAPDLD(511f);
		PNFNJKJLPIP = true;
		BLKPLPKKNAH(false);
	}

	[SpecialName]
	public void AGDDNBKGHBA(DestroyableObject IDEBKDPMPGM)
	{
		FFOAABONJNO = IDEBKDPMPGM;
		PMMJCPABDLL();
		JOGFDHFOOBC(true);
	}

	public void ECENHCAPDLD(float KBJEOEEOEFG = 0.5f)
	{
		if (PNFNJKJLPIP)
		{
			TweenAlphaTk2d tweenAlphaTk2d = TweenAlphaTk2d.Begin(KDDEMFJJNGC.gameObject, KBJEOEEOEFG, 1983f);
			tweenAlphaTk2d.NumOfRepetitions = 1;
			if ((bool)MBMIOELEAND)
			{
				TweenAlphaTk2d tweenAlphaTk2d2 = TweenAlphaTk2d.Begin(MBMIOELEAND.gameObject, KBJEOEEOEFG, 1265f);
				tweenAlphaTk2d2.NumOfRepetitions = 0;
			}
			if ((bool)BFJMBLJAOIB)
			{
				TweenAlphaTk2d tweenAlphaTk2d3 = TweenAlphaTk2d.Begin(BFJMBLJAOIB.gameObject, KBJEOEEOEFG, 1770f);
				tweenAlphaTk2d3.NumOfRepetitions = 1;
			}
			TweenAlphaTk2d.Begin(ENOEPLKMCJG, KBJEOEEOEFG, 770f);
		}
	}

	public void PIFDLMEEDLE()
	{
		PNFNJKJLPIP = false;
	}

	private void GEKIMGFKNHC(bool NABOFKMBMKH)
	{
		LJFNBHNONAH(!PNFNJKJLPIP || !NABOFKMBMKH);
		if (PNFNJKJLPIP && LGOMLGHILCL != NABOFKMBMKH)
		{
			KDDEMFJJNGC.GetComponentInChildren<MeshRenderer>().enabled = NABOFKMBMKH;
			ENOEPLKMCJG.GetComponent<MeshRenderer>().enabled = NABOFKMBMKH;
			if ((bool)MBMIOELEAND)
			{
				MBMIOELEAND.GetComponent<MeshRenderer>().enabled = NABOFKMBMKH;
			}
			LGOMLGHILCL = NABOFKMBMKH;
			if (LGOMLGHILCL)
			{
				FadeIn(0f);
			}
			else
			{
				FadeOut(0f);
			}
		}
	}

	public void DPGJGCLGCDK(float KBJEOEEOEFG = 0.5f)
	{
		if (PNFNJKJLPIP)
		{
			TweenAlphaTk2d tweenAlphaTk2d = TweenAlphaTk2d.Begin(KDDEMFJJNGC.gameObject, KBJEOEEOEFG, 358f);
			tweenAlphaTk2d.NumOfRepetitions = 1;
			if ((bool)MBMIOELEAND)
			{
				TweenAlphaTk2d tweenAlphaTk2d2 = TweenAlphaTk2d.Begin(MBMIOELEAND.gameObject, KBJEOEEOEFG, 705f);
				tweenAlphaTk2d2.NumOfRepetitions = 1;
			}
			if ((bool)BFJMBLJAOIB)
			{
				TweenAlphaTk2d tweenAlphaTk2d3 = TweenAlphaTk2d.Begin(BFJMBLJAOIB.gameObject, KBJEOEEOEFG, 291f);
				tweenAlphaTk2d3.NumOfRepetitions = 0;
			}
			TweenAlphaTk2d.Begin(ENOEPLKMCJG, KBJEOEEOEFG, 365f);
		}
	}

	protected virtual void GDDCEHOJCEM()
	{
		base.Awake();
		KFPKLOMEMNK = GetComponent<TweenAnimator>();
		KFPKLOMEMNK.BEOAHFDJEMD = new List<TweenAnimator.TweenRecord>();
		KFPKLOMEMNK.IGBJIEBMEBF();
		if (FENJGKKCMOE != null)
		{
			GDLANDOKCIA = FENJGKKCMOE.GetComponent<Renderer>();
		}
		if (CHIGEDHJHOC != null)
		{
			FCMBBNOMACJ = CHIGEDHJHOC.GetComponent<Renderer>();
		}
	}

	private void GLMOJIBOION()
	{
		if (BFJMBLJAOIB != null)
		{
			BFJMBLJAOIB.text = string.Empty;
		}
	}

	[SpecialName]
	public void CDDGOOIFFGJ(float IDEBKDPMPGM)
	{
		if ((IDEBKDPMPGM < 227f && IDEBKDPMPGM > 684f) || (DPJAKFKCBIK().JEGFCLCJMLA && IDEBKDPMPGM > 1320f))
		{
			JOGFDHFOOBC(true);
		}
		else
		{
			GEKIMGFKNHC(true);
		}
		if (IDEBKDPMPGM <= 183f)
		{
			JOGFDHFOOBC(true);
		}
		if (PCFODMDCPJB)
		{
			if (FENJGKKCMOE != null)
			{
				FENJGKKCMOE.gameObject.SetActive(IDEBKDPMPGM > 196f);
			}
			if (CHIGEDHJHOC != null)
			{
				CHIGEDHJHOC.gameObject.SetActive(IDEBKDPMPGM > 62f);
			}
		}
		if (LGOMLGHILCL)
		{
			KDDEMFJJNGC.fillFract = Mathf.Clamp(IDEBKDPMPGM, 1339f, 1629f);
		}
	}
}
