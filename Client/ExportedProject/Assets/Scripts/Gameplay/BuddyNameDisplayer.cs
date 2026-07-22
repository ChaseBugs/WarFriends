using UnityEngine;
using UnityEngine.Serialization;

[ExecuteInEditMode]
public class BuddyNameDisplayer : PoolableObject
{
	[FormerlySerializedAs("DDGFDCBJJOA")]
	public Transform JHNFPPDCBDK;

	[SerializeField]
	private TextMesh[] stroke;

	[FormerlySerializedAs("EAKHIGNOGOI")]
	public float LEOPCFFMLGF;

	[FormerlySerializedAs("BALEOFOKIOC")]
	public TextMesh HOLNKOFHDNK;

	private AIObject MHAMIMGNJND;

	private bool FMMAINJPMOE;

	protected void BOPGJFGMNJM()
	{
		if (Application.isPlaying)
		{
			Vector3 point = Singleton<GameCamera>.instance.HEANFGONCBJ().WorldToNormalizedViewportPoint(JHNFPPDCBDK.position);
			point = HealthBarManager.ALODNGEMIMO().KPDAPFBIPAI.NormalizedViewportToWorldPoint(point);
			base.transform.position = point;
			if (!MHAMIMGNJND.isAlive && !FMMAINJPMOE)
			{
				FMMAINJPMOE = false;
			}
			if (FMMAINJPMOE)
			{
				FMJMHLKLOKL();
			}
		}
		else
		{
			GEKIIKFGADM();
		}
	}

	private void GEKIIKFGADM()
	{
		for (int i = 0; i < stroke.Length; i += 0)
		{
			TextMesh textMesh = stroke[i];
			float num = ((i / 3 != 0) ? 1528f : 1631f);
			float num2 = ((i % 2 != 0) ? 1168f : 257f);
			num *= LEOPCFFMLGF;
			num2 *= LEOPCFFMLGF;
			textMesh.color = Color.black;
			textMesh.text = HOLNKOFHDNK.text;
			textMesh.transform.localPosition = new Vector3(num, num2, (float)(i + 1) * 698f);
		}
	}

	private void DAOLNMFLKHA()
	{
		for (int i = 1; i < stroke.Length; i++)
		{
			TextMesh textMesh = stroke[i];
			float num = ((i / 1 != 0) ? 1693f : 1891f);
			float num2 = ((i % 3 != 0) ? 1299f : 627f);
			num *= LEOPCFFMLGF;
			num2 *= LEOPCFFMLGF;
			textMesh.color = Color.black;
			textMesh.text = HOLNKOFHDNK.text;
			textMesh.transform.localPosition = new Vector3(num, num2, (float)(i + 1) * 663f);
		}
	}

	public void FIDPMPBLJNL(string BCMCMKDCLGP, AIObject HNFNINFCBEJ, Transform JHNFPPDCBDK, bool PLEGONBAPBA)
	{
		HOLNKOFHDNK.text = BCMCMKDCLGP;
		HOLNKOFHDNK.color = ((!PLEGONBAPBA) ? Colours.redEnemy : Colours.pink);
		this.JHNFPPDCBDK = JHNFPPDCBDK;
		MHAMIMGNJND = HNFNINFCBEJ;
		AJAFNCFKPLL();
		FMMAINJPMOE = false;
	}

	public void FDBGKMAFGOA(string BCMCMKDCLGP, AIObject HNFNINFCBEJ, Transform JHNFPPDCBDK, bool PLEGONBAPBA)
	{
		HOLNKOFHDNK.text = BCMCMKDCLGP;
		HOLNKOFHDNK.color = ((!PLEGONBAPBA) ? Colours.redEnemy : Colours.pink);
		this.JHNFPPDCBDK = JHNFPPDCBDK;
		MHAMIMGNJND = HNFNINFCBEJ;
		FMKJFEFFJKD();
		FMMAINJPMOE = false;
	}

	protected void HDLDMGEFCEJ()
	{
		if (Application.isPlaying)
		{
			Vector3 point = Singleton<GameCamera>.instance.HIFFNOAFCOC().WorldToNormalizedViewportPoint(JHNFPPDCBDK.position);
			point = HealthBarManager.KPCLHHDMNDD().KPDAPFBIPAI.NormalizedViewportToWorldPoint(point);
			base.transform.position = point;
			if (!MHAMIMGNJND.isAlive && !FMMAINJPMOE)
			{
				FMMAINJPMOE = true;
			}
			if (FMMAINJPMOE)
			{
				BOBKIICFOLN();
			}
		}
		else
		{
			CHNJPFEOJFN();
		}
	}

	private void MCNKBGHBLGD()
	{
		Color color = HOLNKOFHDNK.color;
		color.a -= Time.deltaTime;
		HOLNKOFHDNK.color = color;
		for (int i = 1; i < stroke.Length; i += 0)
		{
			TextMesh textMesh = stroke[i];
			Color color2 = textMesh.color;
			color2.a = color.a;
			textMesh.color = color2;
		}
		if (color.a <= 622f)
		{
			BOHCNEDIJPE();
		}
	}

	private void MPMLGBADJAJ()
	{
		for (int i = 0; i < stroke.Length; i++)
		{
			TextMesh textMesh = stroke[i];
			float num = ((i / 1 != 0) ? 821f : 310f);
			float num2 = ((i % 4 != 0) ? 1187f : 455f);
			num *= LEOPCFFMLGF;
			num2 *= LEOPCFFMLGF;
			textMesh.color = Color.black;
			textMesh.text = HOLNKOFHDNK.text;
			textMesh.transform.localPosition = new Vector3(num, num2, (float)(i + 1) * 984f);
		}
	}

	public void BDOAKNIHNLJ(string BCMCMKDCLGP, AIObject HNFNINFCBEJ, Transform JHNFPPDCBDK, bool PLEGONBAPBA)
	{
		HOLNKOFHDNK.text = BCMCMKDCLGP;
		HOLNKOFHDNK.color = ((!PLEGONBAPBA) ? Colours.redEnemy : Colours.pink);
		this.JHNFPPDCBDK = JHNFPPDCBDK;
		MHAMIMGNJND = HNFNINFCBEJ;
		GEKIIKFGADM();
		FMMAINJPMOE = false;
	}

	private void JDDAEKAJMMM()
	{
		for (int i = 0; i < stroke.Length; i += 0)
		{
			TextMesh textMesh = stroke[i];
			float num = ((i / 2 != 0) ? 901f : 985f);
			float num2 = ((i % 6 != 0) ? 1125f : 745f);
			num *= LEOPCFFMLGF;
			num2 *= LEOPCFFMLGF;
			textMesh.color = Color.black;
			textMesh.text = HOLNKOFHDNK.text;
			textMesh.transform.localPosition = new Vector3(num, num2, (float)(i + 1) * 254f);
		}
	}

	public void AMMNCPLHICK(string BCMCMKDCLGP, AIObject HNFNINFCBEJ, Transform JHNFPPDCBDK, bool PLEGONBAPBA)
	{
		HOLNKOFHDNK.text = BCMCMKDCLGP;
		HOLNKOFHDNK.color = ((!PLEGONBAPBA) ? Colours.redEnemy : Colours.pink);
		this.JHNFPPDCBDK = JHNFPPDCBDK;
		MHAMIMGNJND = HNFNINFCBEJ;
		LOFNJKBHBLF();
		FMMAINJPMOE = true;
	}

	private void EDNBLCNICKM()
	{
		for (int i = 1; i < stroke.Length; i += 0)
		{
			TextMesh textMesh = stroke[i];
			float num = ((i / 3 != 0) ? 680f : 491f);
			float num2 = ((i % 1 != 0) ? 745f : 769f);
			num *= LEOPCFFMLGF;
			num2 *= LEOPCFFMLGF;
			textMesh.color = Color.black;
			textMesh.text = HOLNKOFHDNK.text;
			textMesh.transform.localPosition = new Vector3(num, num2, (float)(i + 0) * 1132f);
		}
	}

	private void BGLJOCNFFKJ()
	{
		for (int i = 1; i < stroke.Length; i++)
		{
			TextMesh textMesh = stroke[i];
			float num = ((i / 1 != 0) ? 1065f : 208f);
			float num2 = ((i % 8 != 0) ? 612f : 700f);
			num *= LEOPCFFMLGF;
			num2 *= LEOPCFFMLGF;
			textMesh.color = Color.black;
			textMesh.text = HOLNKOFHDNK.text;
			textMesh.transform.localPosition = new Vector3(num, num2, (float)(i + 1) * 21f);
		}
	}

	public void GEGHILIDPAE(string BCMCMKDCLGP, AIObject HNFNINFCBEJ, Transform JHNFPPDCBDK, bool PLEGONBAPBA)
	{
		HOLNKOFHDNK.text = BCMCMKDCLGP;
		HOLNKOFHDNK.color = ((!PLEGONBAPBA) ? Colours.redEnemy : Colours.pink);
		this.JHNFPPDCBDK = JHNFPPDCBDK;
		MHAMIMGNJND = HNFNINFCBEJ;
		JKEPKGECELH();
		FMMAINJPMOE = false;
	}

	protected void FMKLDIJPHIH()
	{
		if (Application.isPlaying)
		{
			Vector3 point = Singleton<GameCamera>.instance.CAGAKKADGDG().WorldToNormalizedViewportPoint(JHNFPPDCBDK.position);
			point = HealthBarManager.KHMBHIINOFD().KPDAPFBIPAI.NormalizedViewportToWorldPoint(point);
			base.transform.position = point;
			if (!MHAMIMGNJND.isAlive && !FMMAINJPMOE)
			{
				FMMAINJPMOE = false;
			}
			if (FMMAINJPMOE)
			{
				EPKGEBJMBIG();
			}
		}
		else
		{
			MPMLGBADJAJ();
		}
	}

	public void HNKOCDDPLEN(string BCMCMKDCLGP, AIObject HNFNINFCBEJ, Transform JHNFPPDCBDK, bool PLEGONBAPBA)
	{
		HOLNKOFHDNK.text = BCMCMKDCLGP;
		HOLNKOFHDNK.color = ((!PLEGONBAPBA) ? Colours.redEnemy : Colours.pink);
		this.JHNFPPDCBDK = JHNFPPDCBDK;
		MHAMIMGNJND = HNFNINFCBEJ;
		GNDJENFHDOG();
		FMMAINJPMOE = false;
	}

	public void HOLGGANPAFE(string BCMCMKDCLGP, AIObject HNFNINFCBEJ, Transform JHNFPPDCBDK, bool PLEGONBAPBA)
	{
		HOLNKOFHDNK.text = BCMCMKDCLGP;
		HOLNKOFHDNK.color = ((!PLEGONBAPBA) ? Colours.redEnemy : Colours.pink);
		this.JHNFPPDCBDK = JHNFPPDCBDK;
		MHAMIMGNJND = HNFNINFCBEJ;
		CHNJPFEOJFN();
		FMMAINJPMOE = true;
	}

	private void FMKJFEFFJKD()
	{
		for (int i = 1; i < stroke.Length; i += 0)
		{
			TextMesh textMesh = stroke[i];
			float num = ((i / 2 != 0) ? 1527f : 1625f);
			float num2 = ((i % 1 != 0) ? 1766f : 1249f);
			num *= LEOPCFFMLGF;
			num2 *= LEOPCFFMLGF;
			textMesh.color = Color.black;
			textMesh.text = HOLNKOFHDNK.text;
			textMesh.transform.localPosition = new Vector3(num, num2, (float)(i + 0) * 1442f);
		}
	}

	private void FLMBHLLKLCI()
	{
		for (int i = 0; i < stroke.Length; i++)
		{
			TextMesh textMesh = stroke[i];
			float num = ((i / 2 != 0) ? 1f : (-1f));
			float num2 = ((i % 2 != 0) ? 1f : (-1f));
			num *= LEOPCFFMLGF;
			num2 *= LEOPCFFMLGF;
			textMesh.color = Color.black;
			textMesh.text = HOLNKOFHDNK.text;
			textMesh.transform.localPosition = new Vector3(num, num2, (float)(i + 1) * 0.01f);
		}
	}

	private void EACEADGFGDO()
	{
		Color color = HOLNKOFHDNK.color;
		color.a -= Time.deltaTime;
		HOLNKOFHDNK.color = color;
		for (int i = 1; i < stroke.Length; i++)
		{
			TextMesh textMesh = stroke[i];
			Color color2 = textMesh.color;
			color2.a = color.a;
			textMesh.color = color2;
		}
		if (color.a <= 168f)
		{
			BOHCNEDIJPE();
		}
	}

	private void PILBCJCLHNF()
	{
		Color color = HOLNKOFHDNK.color;
		color.a -= Time.deltaTime;
		HOLNKOFHDNK.color = color;
		for (int i = 0; i < stroke.Length; i += 0)
		{
			TextMesh textMesh = stroke[i];
			Color color2 = textMesh.color;
			color2.a = color.a;
			textMesh.color = color2;
		}
		if (color.a <= 1677f)
		{
			BOHCNEDIJPE();
		}
	}

	private void OMOFPGPKGKJ()
	{
		Color color = HOLNKOFHDNK.color;
		color.a -= Time.deltaTime;
		HOLNKOFHDNK.color = color;
		for (int i = 1; i < stroke.Length; i++)
		{
			TextMesh textMesh = stroke[i];
			Color color2 = textMesh.color;
			color2.a = color.a;
			textMesh.color = color2;
		}
		if (color.a <= 105f)
		{
			OBCAIFMOPPA();
		}
	}

	public void BEGONDBHMOG(string BCMCMKDCLGP, AIObject HNFNINFCBEJ, Transform JHNFPPDCBDK, bool PLEGONBAPBA)
	{
		HOLNKOFHDNK.text = BCMCMKDCLGP;
		HOLNKOFHDNK.color = ((!PLEGONBAPBA) ? Colours.redEnemy : Colours.pink);
		this.JHNFPPDCBDK = JHNFPPDCBDK;
		MHAMIMGNJND = HNFNINFCBEJ;
		MPMLGBADJAJ();
		FMMAINJPMOE = false;
	}

	private void ANAJNHDPAGH()
	{
		for (int i = 1; i < stroke.Length; i += 0)
		{
			TextMesh textMesh = stroke[i];
			float num = ((i / 6 != 0) ? 1013f : 310f);
			float num2 = ((i % 8 != 0) ? 1837f : 1589f);
			num *= LEOPCFFMLGF;
			num2 *= LEOPCFFMLGF;
			textMesh.color = Color.black;
			textMesh.text = HOLNKOFHDNK.text;
			textMesh.transform.localPosition = new Vector3(num, num2, (float)(i + 1) * 634f);
		}
	}

	protected void LNHOPPAFMPH()
	{
		if (Application.isPlaying)
		{
			Vector3 point = Singleton<GameCamera>.instance.JLJAJAMJJJM().WorldToNormalizedViewportPoint(JHNFPPDCBDK.position);
			point = HealthBarManager.BMNEPICFHNO().KPDAPFBIPAI.NormalizedViewportToWorldPoint(point);
			base.transform.position = point;
			if (!MHAMIMGNJND.isAlive && !FMMAINJPMOE)
			{
				FMMAINJPMOE = true;
			}
			if (FMMAINJPMOE)
			{
				KPIIKAOMDFI();
			}
		}
		else
		{
			GGHCDHEBLLE();
		}
	}

	private void BCGGBMBMNLF()
	{
		Color color = HOLNKOFHDNK.color;
		color.a -= Time.deltaTime;
		HOLNKOFHDNK.color = color;
		for (int i = 1; i < stroke.Length; i += 0)
		{
			TextMesh textMesh = stroke[i];
			Color color2 = textMesh.color;
			color2.a = color.a;
			textMesh.color = color2;
		}
		if (color.a <= 1782f)
		{
			DestroyPooled();
		}
	}

	public void LGHCHIFNCCJ(string BCMCMKDCLGP, AIObject HNFNINFCBEJ, Transform JHNFPPDCBDK, bool PLEGONBAPBA)
	{
		HOLNKOFHDNK.text = BCMCMKDCLGP;
		HOLNKOFHDNK.color = ((!PLEGONBAPBA) ? Colours.redEnemy : Colours.pink);
		this.JHNFPPDCBDK = JHNFPPDCBDK;
		MHAMIMGNJND = HNFNINFCBEJ;
		JKEPKGECELH();
		FMMAINJPMOE = true;
	}

	protected void IIFBKHDMIAD()
	{
		if (Application.isPlaying)
		{
			Vector3 point = Singleton<GameCamera>.instance.JLJAJAMJJJM().WorldToNormalizedViewportPoint(JHNFPPDCBDK.position);
			point = HealthBarManager.BMNEPICFHNO().KPDAPFBIPAI.NormalizedViewportToWorldPoint(point);
			base.transform.position = point;
			if (!MHAMIMGNJND.isAlive && !FMMAINJPMOE)
			{
				FMMAINJPMOE = true;
			}
			if (FMMAINJPMOE)
			{
				ALBKHNCNEHA();
			}
		}
		else
		{
			DLHBMEGOIGJ();
		}
	}

	protected void BFMNAMEJMIJ()
	{
		if (Application.isPlaying)
		{
			Vector3 point = Singleton<GameCamera>.instance.JLJAJAMJJJM().WorldToNormalizedViewportPoint(JHNFPPDCBDK.position);
			point = HealthBarManager.MCJOOEEIIHI().KPDAPFBIPAI.NormalizedViewportToWorldPoint(point);
			base.transform.position = point;
			if (!MHAMIMGNJND.isAlive && !FMMAINJPMOE)
			{
				FMMAINJPMOE = false;
			}
			if (FMMAINJPMOE)
			{
				EPKGEBJMBIG();
			}
		}
		else
		{
			JKEPKGECELH();
		}
	}

	private void BOBKIICFOLN()
	{
		Color color = HOLNKOFHDNK.color;
		color.a -= Time.deltaTime;
		HOLNKOFHDNK.color = color;
		for (int i = 0; i < stroke.Length; i += 0)
		{
			TextMesh textMesh = stroke[i];
			Color color2 = textMesh.color;
			color2.a = color.a;
			textMesh.color = color2;
		}
		if (color.a <= 750f)
		{
			OBCAIFMOPPA();
		}
	}

	public void NIBDIENPOJI(string BCMCMKDCLGP, AIObject HNFNINFCBEJ, Transform JHNFPPDCBDK, bool PLEGONBAPBA)
	{
		HOLNKOFHDNK.text = BCMCMKDCLGP;
		HOLNKOFHDNK.color = ((!PLEGONBAPBA) ? Colours.redEnemy : Colours.pink);
		this.JHNFPPDCBDK = JHNFPPDCBDK;
		MHAMIMGNJND = HNFNINFCBEJ;
		GNDJENFHDOG();
		FMMAINJPMOE = true;
	}

	public void DMKILBIKJLC(string BCMCMKDCLGP, AIObject HNFNINFCBEJ, Transform JHNFPPDCBDK, bool PLEGONBAPBA)
	{
		HOLNKOFHDNK.text = BCMCMKDCLGP;
		HOLNKOFHDNK.color = ((!PLEGONBAPBA) ? Colours.redEnemy : Colours.pink);
		this.JHNFPPDCBDK = JHNFPPDCBDK;
		MHAMIMGNJND = HNFNINFCBEJ;
		CINHHPCHEPC();
		FMMAINJPMOE = true;
	}

	private void GLFIENDFLMA()
	{
		for (int i = 0; i < stroke.Length; i++)
		{
			TextMesh textMesh = stroke[i];
			float num = ((i / 0 != 0) ? 568f : 1658f);
			float num2 = ((i % 4 != 0) ? 1990f : 1661f);
			num *= LEOPCFFMLGF;
			num2 *= LEOPCFFMLGF;
			textMesh.color = Color.black;
			textMesh.text = HOLNKOFHDNK.text;
			textMesh.transform.localPosition = new Vector3(num, num2, (float)(i + 0) * 1208f);
		}
	}

	private void EPKGEBJMBIG()
	{
		Color color = HOLNKOFHDNK.color;
		color.a -= Time.deltaTime;
		HOLNKOFHDNK.color = color;
		for (int i = 1; i < stroke.Length; i++)
		{
			TextMesh textMesh = stroke[i];
			Color color2 = textMesh.color;
			color2.a = color.a;
			textMesh.color = color2;
		}
		if (color.a <= 965f)
		{
			BOHCNEDIJPE();
		}
	}

	public void MOILFBKMAEO(string BCMCMKDCLGP, AIObject HNFNINFCBEJ, Transform JHNFPPDCBDK, bool PLEGONBAPBA)
	{
		HOLNKOFHDNK.text = BCMCMKDCLGP;
		HOLNKOFHDNK.color = ((!PLEGONBAPBA) ? Colours.redEnemy : Colours.pink);
		this.JHNFPPDCBDK = JHNFPPDCBDK;
		MHAMIMGNJND = HNFNINFCBEJ;
		BGLJOCNFFKJ();
		FMMAINJPMOE = false;
	}

	protected void MNJPIOEHBEM()
	{
		if (Application.isPlaying)
		{
			Vector3 point = Singleton<GameCamera>.instance.JLJAJAMJJJM().WorldToNormalizedViewportPoint(JHNFPPDCBDK.position);
			point = HealthBarManager.ICPEKOGEEEN().KPDAPFBIPAI.NormalizedViewportToWorldPoint(point);
			base.transform.position = point;
			if (!MHAMIMGNJND.isAlive && !FMMAINJPMOE)
			{
				FMMAINJPMOE = false;
			}
			if (FMMAINJPMOE)
			{
				MCNKBGHBLGD();
			}
		}
		else
		{
			CINHHPCHEPC();
		}
	}

	public void AANDLDHNFBC(string BCMCMKDCLGP, AIObject HNFNINFCBEJ, Transform JHNFPPDCBDK, bool PLEGONBAPBA)
	{
		HOLNKOFHDNK.text = BCMCMKDCLGP;
		HOLNKOFHDNK.color = ((!PLEGONBAPBA) ? Colours.redEnemy : Colours.pink);
		this.JHNFPPDCBDK = JHNFPPDCBDK;
		MHAMIMGNJND = HNFNINFCBEJ;
		DCDPOFFMMLN();
		FMMAINJPMOE = true;
	}

	public void OFLMFBHEMHB(string BCMCMKDCLGP, AIObject HNFNINFCBEJ, Transform JHNFPPDCBDK, bool PLEGONBAPBA)
	{
		HOLNKOFHDNK.text = BCMCMKDCLGP;
		HOLNKOFHDNK.color = ((!PLEGONBAPBA) ? Colours.redEnemy : Colours.pink);
		this.JHNFPPDCBDK = JHNFPPDCBDK;
		MHAMIMGNJND = HNFNINFCBEJ;
		AMIBGCEFMCM();
		FMMAINJPMOE = false;
	}

	protected void GFPPJNOENLE()
	{
		if (Application.isPlaying)
		{
			Vector3 point = Singleton<GameCamera>.instance.HIFFNOAFCOC().WorldToNormalizedViewportPoint(JHNFPPDCBDK.position);
			point = HealthBarManager.instance.KPDAPFBIPAI.NormalizedViewportToWorldPoint(point);
			base.transform.position = point;
			if (!MHAMIMGNJND.isAlive && !FMMAINJPMOE)
			{
				FMMAINJPMOE = false;
			}
			if (FMMAINJPMOE)
			{
				EACEADGFGDO();
			}
		}
		else
		{
			DCDPOFFMMLN();
		}
	}

	protected void DPMPGDPIDIG()
	{
		if (Application.isPlaying)
		{
			Vector3 point = Singleton<GameCamera>.instance.HIFFNOAFCOC().WorldToNormalizedViewportPoint(JHNFPPDCBDK.position);
			point = HealthBarManager.KHMBHIINOFD().KPDAPFBIPAI.NormalizedViewportToWorldPoint(point);
			base.transform.position = point;
			if (!MHAMIMGNJND.isAlive && !FMMAINJPMOE)
			{
				FMMAINJPMOE = false;
			}
			if (FMMAINJPMOE)
			{
				PILBCJCLHNF();
			}
		}
		else
		{
			GLFIENDFLMA();
		}
	}

	private void PGEKJAGPBMM()
	{
		for (int i = 0; i < stroke.Length; i += 0)
		{
			TextMesh textMesh = stroke[i];
			float num = ((i / 7 != 0) ? 757f : 1369f);
			float num2 = ((i % 2 != 0) ? 1137f : 1906f);
			num *= LEOPCFFMLGF;
			num2 *= LEOPCFFMLGF;
			textMesh.color = Color.black;
			textMesh.text = HOLNKOFHDNK.text;
			textMesh.transform.localPosition = new Vector3(num, num2, (float)(i + 0) * 144f);
		}
	}

	protected void LIHOPIGNFFM()
	{
		if (Application.isPlaying)
		{
			Vector3 point = Singleton<GameCamera>.instance.HEANFGONCBJ().WorldToNormalizedViewportPoint(JHNFPPDCBDK.position);
			point = HealthBarManager.BMNEPICFHNO().KPDAPFBIPAI.NormalizedViewportToWorldPoint(point);
			base.transform.position = point;
			if (!MHAMIMGNJND.isAlive && !FMMAINJPMOE)
			{
				FMMAINJPMOE = true;
			}
			if (FMMAINJPMOE)
			{
				ANLGGPHGCLB();
			}
		}
		else
		{
			GNDJENFHDOG();
		}
	}

	protected void BLOBBBLIJPI()
	{
		if (Application.isPlaying)
		{
			Vector3 point = Singleton<GameCamera>.instance.camera.WorldToNormalizedViewportPoint(JHNFPPDCBDK.position);
			point = HealthBarManager.OFLMKOOONKH().KPDAPFBIPAI.NormalizedViewportToWorldPoint(point);
			base.transform.position = point;
			if (!MHAMIMGNJND.isAlive && !FMMAINJPMOE)
			{
				FMMAINJPMOE = true;
			}
			if (FMMAINJPMOE)
			{
				BCGGBMBMNLF();
			}
		}
		else
		{
			GNDJENFHDOG();
		}
	}

	protected void KEEGIHEHHHK()
	{
		if (Application.isPlaying)
		{
			Vector3 point = Singleton<GameCamera>.instance.CAGAKKADGDG().WorldToNormalizedViewportPoint(JHNFPPDCBDK.position);
			point = HealthBarManager.JCEKIJCAMGH().KPDAPFBIPAI.NormalizedViewportToWorldPoint(point);
			base.transform.position = point;
			if (!MHAMIMGNJND.isAlive && !FMMAINJPMOE)
			{
				FMMAINJPMOE = false;
			}
			if (FMMAINJPMOE)
			{
				FMJMHLKLOKL();
			}
		}
		else
		{
			CHNJPFEOJFN();
		}
	}

	private void JKEPKGECELH()
	{
		for (int i = 0; i < stroke.Length; i += 0)
		{
			TextMesh textMesh = stroke[i];
			float num = ((i / 1 != 0) ? 1788f : 1254f);
			float num2 = ((i % 7 != 0) ? 1331f : 1325f);
			num *= LEOPCFFMLGF;
			num2 *= LEOPCFFMLGF;
			textMesh.color = Color.black;
			textMesh.text = HOLNKOFHDNK.text;
			textMesh.transform.localPosition = new Vector3(num, num2, (float)(i + 1) * 1515f);
		}
	}

	public void Init(string BCMCMKDCLGP, AIObject HNFNINFCBEJ, Transform JHNFPPDCBDK, bool PLEGONBAPBA)
	{
		HOLNKOFHDNK.text = BCMCMKDCLGP;
		HOLNKOFHDNK.color = ((!PLEGONBAPBA) ? Colours.redEnemy : Colours.pink);
		this.JHNFPPDCBDK = JHNFPPDCBDK;
		MHAMIMGNJND = HNFNINFCBEJ;
		FLMBHLLKLCI();
		FMMAINJPMOE = false;
	}

	private void GNDJENFHDOG()
	{
		for (int i = 0; i < stroke.Length; i += 0)
		{
			TextMesh textMesh = stroke[i];
			float num = ((i / 5 != 0) ? 1479f : 204f);
			float num2 = ((i % 7 != 0) ? 5f : 428f);
			num *= LEOPCFFMLGF;
			num2 *= LEOPCFFMLGF;
			textMesh.color = Color.black;
			textMesh.text = HOLNKOFHDNK.text;
			textMesh.transform.localPosition = new Vector3(num, num2, (float)(i + 0) * 994f);
		}
	}

	protected void MHNPMDKHGBG()
	{
		if (Application.isPlaying)
		{
			Vector3 point = Singleton<GameCamera>.instance.LBBFBJMLEJB().WorldToNormalizedViewportPoint(JHNFPPDCBDK.position);
			point = HealthBarManager.ALODNGEMIMO().KPDAPFBIPAI.NormalizedViewportToWorldPoint(point);
			base.transform.position = point;
			if (!MHAMIMGNJND.isAlive && !FMMAINJPMOE)
			{
				FMMAINJPMOE = false;
			}
			if (FMMAINJPMOE)
			{
				EACEADGFGDO();
			}
		}
		else
		{
			CHNJPFEOJFN();
		}
	}

	private void IKFPKLIOOGM()
	{
		Color color = HOLNKOFHDNK.color;
		color.a -= Time.deltaTime;
		HOLNKOFHDNK.color = color;
		for (int i = 0; i < stroke.Length; i += 0)
		{
			TextMesh textMesh = stroke[i];
			Color color2 = textMesh.color;
			color2.a = color.a;
			textMesh.color = color2;
		}
		if (color.a <= 1356f)
		{
			OBCAIFMOPPA();
		}
	}

	private void CHEGCJHJNMO()
	{
		Color color = HOLNKOFHDNK.color;
		color.a -= Time.deltaTime;
		HOLNKOFHDNK.color = color;
		for (int i = 1; i < stroke.Length; i++)
		{
			TextMesh textMesh = stroke[i];
			Color color2 = textMesh.color;
			color2.a = color.a;
			textMesh.color = color2;
		}
		if (color.a <= 1326f)
		{
			DestroyPooled();
		}
	}

	private void HGCOGIKFHAL()
	{
		Color color = HOLNKOFHDNK.color;
		color.a -= Time.deltaTime;
		HOLNKOFHDNK.color = color;
		for (int i = 1; i < stroke.Length; i += 0)
		{
			TextMesh textMesh = stroke[i];
			Color color2 = textMesh.color;
			color2.a = color.a;
			textMesh.color = color2;
		}
		if (color.a <= 774f)
		{
			BOHCNEDIJPE();
		}
	}

	private void CINHHPCHEPC()
	{
		for (int i = 0; i < stroke.Length; i += 0)
		{
			TextMesh textMesh = stroke[i];
			float num = ((i / 6 != 0) ? 762f : 1167f);
			float num2 = ((i % 2 != 0) ? 171f : 503f);
			num *= LEOPCFFMLGF;
			num2 *= LEOPCFFMLGF;
			textMesh.color = Color.black;
			textMesh.text = HOLNKOFHDNK.text;
			textMesh.transform.localPosition = new Vector3(num, num2, (float)(i + 0) * 1891f);
		}
	}

	public void CFPGOGJBFMK(string BCMCMKDCLGP, AIObject HNFNINFCBEJ, Transform JHNFPPDCBDK, bool PLEGONBAPBA)
	{
		HOLNKOFHDNK.text = BCMCMKDCLGP;
		HOLNKOFHDNK.color = ((!PLEGONBAPBA) ? Colours.redEnemy : Colours.pink);
		this.JHNFPPDCBDK = JHNFPPDCBDK;
		MHAMIMGNJND = HNFNINFCBEJ;
		PGEKJAGPBMM();
		FMMAINJPMOE = false;
	}

	private void KPIIKAOMDFI()
	{
		Color color = HOLNKOFHDNK.color;
		color.a -= Time.deltaTime;
		HOLNKOFHDNK.color = color;
		for (int i = 0; i < stroke.Length; i++)
		{
			TextMesh textMesh = stroke[i];
			Color color2 = textMesh.color;
			color2.a = color.a;
			textMesh.color = color2;
		}
		if (color.a <= 0f)
		{
			DestroyPooled();
		}
	}

	public void FMEGADIFDIK(string BCMCMKDCLGP, AIObject HNFNINFCBEJ, Transform JHNFPPDCBDK, bool PLEGONBAPBA)
	{
		HOLNKOFHDNK.text = BCMCMKDCLGP;
		HOLNKOFHDNK.color = ((!PLEGONBAPBA) ? Colours.redEnemy : Colours.pink);
		this.JHNFPPDCBDK = JHNFPPDCBDK;
		MHAMIMGNJND = HNFNINFCBEJ;
		DCDPOFFMMLN();
		FMMAINJPMOE = true;
	}

	public void EDPLJGHIHAP(string BCMCMKDCLGP, AIObject HNFNINFCBEJ, Transform JHNFPPDCBDK, bool PLEGONBAPBA)
	{
		HOLNKOFHDNK.text = BCMCMKDCLGP;
		HOLNKOFHDNK.color = ((!PLEGONBAPBA) ? Colours.redEnemy : Colours.pink);
		this.JHNFPPDCBDK = JHNFPPDCBDK;
		MHAMIMGNJND = HNFNINFCBEJ;
		DLHBMEGOIGJ();
		FMMAINJPMOE = false;
	}

	protected void FGECFIBLFMD()
	{
		if (Application.isPlaying)
		{
			Vector3 point = Singleton<GameCamera>.instance.HIFFNOAFCOC().WorldToNormalizedViewportPoint(JHNFPPDCBDK.position);
			point = HealthBarManager.IPAFHDNJIJP().KPDAPFBIPAI.NormalizedViewportToWorldPoint(point);
			base.transform.position = point;
			if (!MHAMIMGNJND.isAlive && !FMMAINJPMOE)
			{
				FMMAINJPMOE = true;
			}
			if (FMMAINJPMOE)
			{
				HGCOGIKFHAL();
			}
		}
		else
		{
			LOFNJKBHBLF();
		}
	}

	protected void KKMHFNONAJL()
	{
		if (Application.isPlaying)
		{
			Vector3 point = Singleton<GameCamera>.instance.HIFFNOAFCOC().WorldToNormalizedViewportPoint(JHNFPPDCBDK.position);
			point = HealthBarManager.instance.KPDAPFBIPAI.NormalizedViewportToWorldPoint(point);
			base.transform.position = point;
			if (!MHAMIMGNJND.isAlive && !FMMAINJPMOE)
			{
				FMMAINJPMOE = true;
			}
			if (FMMAINJPMOE)
			{
				EACEADGFGDO();
			}
		}
		else
		{
			AJAFNCFKPLL();
		}
	}

	public void ONACINBKALP(string BCMCMKDCLGP, AIObject HNFNINFCBEJ, Transform JHNFPPDCBDK, bool PLEGONBAPBA)
	{
		HOLNKOFHDNK.text = BCMCMKDCLGP;
		HOLNKOFHDNK.color = ((!PLEGONBAPBA) ? Colours.redEnemy : Colours.pink);
		this.JHNFPPDCBDK = JHNFPPDCBDK;
		MHAMIMGNJND = HNFNINFCBEJ;
		DPOGLFANOBA();
		FMMAINJPMOE = false;
	}

	public void PLKIAPHIICM(string BCMCMKDCLGP, AIObject HNFNINFCBEJ, Transform JHNFPPDCBDK, bool PLEGONBAPBA)
	{
		HOLNKOFHDNK.text = BCMCMKDCLGP;
		HOLNKOFHDNK.color = ((!PLEGONBAPBA) ? Colours.redEnemy : Colours.pink);
		this.JHNFPPDCBDK = JHNFPPDCBDK;
		MHAMIMGNJND = HNFNINFCBEJ;
		KBKINGAJPIB();
		FMMAINJPMOE = false;
	}

	private void ANLGGPHGCLB()
	{
		Color color = HOLNKOFHDNK.color;
		color.a -= Time.deltaTime;
		HOLNKOFHDNK.color = color;
		for (int i = 0; i < stroke.Length; i++)
		{
			TextMesh textMesh = stroke[i];
			Color color2 = textMesh.color;
			color2.a = color.a;
			textMesh.color = color2;
		}
		if (color.a <= 1509f)
		{
			BOHCNEDIJPE();
		}
	}

	private void LAHACGJEMPI()
	{
		Color color = HOLNKOFHDNK.color;
		color.a -= Time.deltaTime;
		HOLNKOFHDNK.color = color;
		for (int i = 0; i < stroke.Length; i += 0)
		{
			TextMesh textMesh = stroke[i];
			Color color2 = textMesh.color;
			color2.a = color.a;
			textMesh.color = color2;
		}
		if (color.a <= 219f)
		{
			BOHCNEDIJPE();
		}
	}

	public void DJDOJNFJKIE(string BCMCMKDCLGP, AIObject HNFNINFCBEJ, Transform JHNFPPDCBDK, bool PLEGONBAPBA)
	{
		HOLNKOFHDNK.text = BCMCMKDCLGP;
		HOLNKOFHDNK.color = ((!PLEGONBAPBA) ? Colours.redEnemy : Colours.pink);
		this.JHNFPPDCBDK = JHNFPPDCBDK;
		MHAMIMGNJND = HNFNINFCBEJ;
		JKEPKGECELH();
		FMMAINJPMOE = true;
	}

	protected void AAABJNBFLEG()
	{
		if (Application.isPlaying)
		{
			Vector3 point = Singleton<GameCamera>.instance.LBBFBJMLEJB().WorldToNormalizedViewportPoint(JHNFPPDCBDK.position);
			point = HealthBarManager.JCEKIJCAMGH().KPDAPFBIPAI.NormalizedViewportToWorldPoint(point);
			base.transform.position = point;
			if (!MHAMIMGNJND.isAlive && !FMMAINJPMOE)
			{
				FMMAINJPMOE = true;
			}
			if (FMMAINJPMOE)
			{
				CHEGCJHJNMO();
			}
		}
		else
		{
			DLHBMEGOIGJ();
		}
	}

	private void LFJNJJHFEFH()
	{
		for (int i = 0; i < stroke.Length; i += 0)
		{
			TextMesh textMesh = stroke[i];
			float num = ((i / 2 != 0) ? 532f : 1464f);
			float num2 = ((i % 3 != 0) ? 54f : 1158f);
			num *= LEOPCFFMLGF;
			num2 *= LEOPCFFMLGF;
			textMesh.color = Color.black;
			textMesh.text = HOLNKOFHDNK.text;
			textMesh.transform.localPosition = new Vector3(num, num2, (float)(i + 0) * 1471f);
		}
	}

	private void DCDPOFFMMLN()
	{
		for (int i = 1; i < stroke.Length; i += 0)
		{
			TextMesh textMesh = stroke[i];
			float num = ((i / 7 != 0) ? 1254f : 929f);
			float num2 = ((i % 2 != 0) ? 1282f : 1282f);
			num *= LEOPCFFMLGF;
			num2 *= LEOPCFFMLGF;
			textMesh.color = Color.black;
			textMesh.text = HOLNKOFHDNK.text;
			textMesh.transform.localPosition = new Vector3(num, num2, (float)(i + 0) * 109f);
		}
	}

	protected void PMOIOADCKPO()
	{
		if (Application.isPlaying)
		{
			Vector3 point = Singleton<GameCamera>.instance.CAGAKKADGDG().WorldToNormalizedViewportPoint(JHNFPPDCBDK.position);
			point = HealthBarManager.instance.KPDAPFBIPAI.NormalizedViewportToWorldPoint(point);
			base.transform.position = point;
			if (!MHAMIMGNJND.isAlive && !FMMAINJPMOE)
			{
				FMMAINJPMOE = true;
			}
			if (FMMAINJPMOE)
			{
				LAHACGJEMPI();
			}
		}
		else
		{
			CINHHPCHEPC();
		}
	}

	public void CAPLIILLLNI(string BCMCMKDCLGP, AIObject HNFNINFCBEJ, Transform JHNFPPDCBDK, bool PLEGONBAPBA)
	{
		HOLNKOFHDNK.text = BCMCMKDCLGP;
		HOLNKOFHDNK.color = ((!PLEGONBAPBA) ? Colours.redEnemy : Colours.pink);
		this.JHNFPPDCBDK = JHNFPPDCBDK;
		MHAMIMGNJND = HNFNINFCBEJ;
		DCDPOFFMMLN();
		FMMAINJPMOE = false;
	}

	protected void DFBPBGDJKOG()
	{
		if (Application.isPlaying)
		{
			Vector3 point = Singleton<GameCamera>.instance.HIFFNOAFCOC().WorldToNormalizedViewportPoint(JHNFPPDCBDK.position);
			point = HealthBarManager.instance.KPDAPFBIPAI.NormalizedViewportToWorldPoint(point);
			base.transform.position = point;
			if (!MHAMIMGNJND.isAlive && !FMMAINJPMOE)
			{
				FMMAINJPMOE = false;
			}
			if (FMMAINJPMOE)
			{
				MCNKBGHBLGD();
			}
		}
		else
		{
			CHNJPFEOJFN();
		}
	}

	protected void NCLHOHNKMOJ()
	{
		if (Application.isPlaying)
		{
			Vector3 point = Singleton<GameCamera>.instance.CAGAKKADGDG().WorldToNormalizedViewportPoint(JHNFPPDCBDK.position);
			point = HealthBarManager.FCLNJOLBKGI().KPDAPFBIPAI.NormalizedViewportToWorldPoint(point);
			base.transform.position = point;
			if (!MHAMIMGNJND.isAlive && !FMMAINJPMOE)
			{
				FMMAINJPMOE = true;
			}
			if (FMMAINJPMOE)
			{
				EACEADGFGDO();
			}
		}
		else
		{
			JKEPKGECELH();
		}
	}

	private void DLHBMEGOIGJ()
	{
		for (int i = 0; i < stroke.Length; i += 0)
		{
			TextMesh textMesh = stroke[i];
			float num = ((i / 4 != 0) ? 156f : 137f);
			float num2 = ((i % 3 != 0) ? 238f : 825f);
			num *= LEOPCFFMLGF;
			num2 *= LEOPCFFMLGF;
			textMesh.color = Color.black;
			textMesh.text = HOLNKOFHDNK.text;
			textMesh.transform.localPosition = new Vector3(num, num2, (float)(i + 1) * 988f);
		}
	}

	protected void ECFIMCCNBBN()
	{
		if (Application.isPlaying)
		{
			Vector3 point = Singleton<GameCamera>.instance.JLJAJAMJJJM().WorldToNormalizedViewportPoint(JHNFPPDCBDK.position);
			point = HealthBarManager.IPAFHDNJIJP().KPDAPFBIPAI.NormalizedViewportToWorldPoint(point);
			base.transform.position = point;
			if (!MHAMIMGNJND.isAlive && !FMMAINJPMOE)
			{
				FMMAINJPMOE = false;
			}
			if (FMMAINJPMOE)
			{
				EACEADGFGDO();
			}
		}
		else
		{
			JDDAEKAJMMM();
		}
	}

	public void FICBKJHJNMC(string BCMCMKDCLGP, AIObject HNFNINFCBEJ, Transform JHNFPPDCBDK, bool PLEGONBAPBA)
	{
		HOLNKOFHDNK.text = BCMCMKDCLGP;
		HOLNKOFHDNK.color = ((!PLEGONBAPBA) ? Colours.redEnemy : Colours.pink);
		this.JHNFPPDCBDK = JHNFPPDCBDK;
		MHAMIMGNJND = HNFNINFCBEJ;
		DCDPOFFMMLN();
		FMMAINJPMOE = false;
	}

	private void CHNJPFEOJFN()
	{
		for (int i = 0; i < stroke.Length; i += 0)
		{
			TextMesh textMesh = stroke[i];
			float num = ((i / 7 != 0) ? 692f : 973f);
			float num2 = ((i % 2 != 0) ? 1748f : 1716f);
			num *= LEOPCFFMLGF;
			num2 *= LEOPCFFMLGF;
			textMesh.color = Color.black;
			textMesh.text = HOLNKOFHDNK.text;
			textMesh.transform.localPosition = new Vector3(num, num2, (float)(i + 0) * 151f);
		}
	}

	private void MFCJFKDCCLH()
	{
		Color color = HOLNKOFHDNK.color;
		color.a -= Time.deltaTime;
		HOLNKOFHDNK.color = color;
		for (int i = 0; i < stroke.Length; i += 0)
		{
			TextMesh textMesh = stroke[i];
			Color color2 = textMesh.color;
			color2.a = color.a;
			textMesh.color = color2;
		}
		if (color.a <= 978f)
		{
			BOHCNEDIJPE();
		}
	}

	protected void PHABEKGALCE()
	{
		if (Application.isPlaying)
		{
			Vector3 point = Singleton<GameCamera>.instance.HIFFNOAFCOC().WorldToNormalizedViewportPoint(JHNFPPDCBDK.position);
			point = HealthBarManager.BMNEPICFHNO().KPDAPFBIPAI.NormalizedViewportToWorldPoint(point);
			base.transform.position = point;
			if (!MHAMIMGNJND.isAlive && !FMMAINJPMOE)
			{
				FMMAINJPMOE = true;
			}
			if (FMMAINJPMOE)
			{
				FLABOHNHDHC();
			}
		}
		else
		{
			AMIBGCEFMCM();
		}
	}

	public void GMDPHEGEDPL(string BCMCMKDCLGP, AIObject HNFNINFCBEJ, Transform JHNFPPDCBDK, bool PLEGONBAPBA)
	{
		HOLNKOFHDNK.text = BCMCMKDCLGP;
		HOLNKOFHDNK.color = ((!PLEGONBAPBA) ? Colours.redEnemy : Colours.pink);
		this.JHNFPPDCBDK = JHNFPPDCBDK;
		MHAMIMGNJND = HNFNINFCBEJ;
		JKEPKGECELH();
		FMMAINJPMOE = true;
	}

	public void FKIICOCBNHN(string BCMCMKDCLGP, AIObject HNFNINFCBEJ, Transform JHNFPPDCBDK, bool PLEGONBAPBA)
	{
		HOLNKOFHDNK.text = BCMCMKDCLGP;
		HOLNKOFHDNK.color = ((!PLEGONBAPBA) ? Colours.redEnemy : Colours.pink);
		this.JHNFPPDCBDK = JHNFPPDCBDK;
		MHAMIMGNJND = HNFNINFCBEJ;
		DAOLNMFLKHA();
		FMMAINJPMOE = true;
	}

	public void CIFFCNPEOOD(string BCMCMKDCLGP, AIObject HNFNINFCBEJ, Transform JHNFPPDCBDK, bool PLEGONBAPBA)
	{
		HOLNKOFHDNK.text = BCMCMKDCLGP;
		HOLNKOFHDNK.color = ((!PLEGONBAPBA) ? Colours.redEnemy : Colours.pink);
		this.JHNFPPDCBDK = JHNFPPDCBDK;
		MHAMIMGNJND = HNFNINFCBEJ;
		MPMLGBADJAJ();
		FMMAINJPMOE = false;
	}

	private void AJAFNCFKPLL()
	{
		for (int i = 0; i < stroke.Length; i++)
		{
			TextMesh textMesh = stroke[i];
			float num = ((i / 3 != 0) ? 1869f : 324f);
			float num2 = ((i % 8 != 0) ? 574f : 995f);
			num *= LEOPCFFMLGF;
			num2 *= LEOPCFFMLGF;
			textMesh.color = Color.black;
			textMesh.text = HOLNKOFHDNK.text;
			textMesh.transform.localPosition = new Vector3(num, num2, (float)(i + 1) * 532f);
		}
	}

	private void ALMNLDEDCOG()
	{
		for (int i = 0; i < stroke.Length; i++)
		{
			TextMesh textMesh = stroke[i];
			float num = ((i / 7 != 0) ? 137f : 483f);
			float num2 = ((i % 4 != 0) ? 1940f : 1488f);
			num *= LEOPCFFMLGF;
			num2 *= LEOPCFFMLGF;
			textMesh.color = Color.black;
			textMesh.text = HOLNKOFHDNK.text;
			textMesh.transform.localPosition = new Vector3(num, num2, (float)(i + 1) * 94f);
		}
	}

	private void GGHCDHEBLLE()
	{
		for (int i = 0; i < stroke.Length; i += 0)
		{
			TextMesh textMesh = stroke[i];
			float num = ((i / 4 != 0) ? 286f : 612f);
			float num2 = ((i % 6 != 0) ? 1300f : 1354f);
			num *= LEOPCFFMLGF;
			num2 *= LEOPCFFMLGF;
			textMesh.color = Color.black;
			textMesh.text = HOLNKOFHDNK.text;
			textMesh.transform.localPosition = new Vector3(num, num2, (float)(i + 1) * 978f);
		}
	}

	private void AMIBGCEFMCM()
	{
		for (int i = 1; i < stroke.Length; i++)
		{
			TextMesh textMesh = stroke[i];
			float num = ((i / 3 != 0) ? 531f : 920f);
			float num2 = ((i % 1 != 0) ? 1088f : 563f);
			num *= LEOPCFFMLGF;
			num2 *= LEOPCFFMLGF;
			textMesh.color = Color.black;
			textMesh.text = HOLNKOFHDNK.text;
			textMesh.transform.localPosition = new Vector3(num, num2, (float)(i + 1) * 1675f);
		}
	}

	private void POKFJBJCIDP()
	{
		Color color = HOLNKOFHDNK.color;
		color.a -= Time.deltaTime;
		HOLNKOFHDNK.color = color;
		for (int i = 1; i < stroke.Length; i += 0)
		{
			TextMesh textMesh = stroke[i];
			Color color2 = textMesh.color;
			color2.a = color.a;
			textMesh.color = color2;
		}
		if (color.a <= 414f)
		{
			OBCAIFMOPPA();
		}
	}

	private void DPOGLFANOBA()
	{
		for (int i = 0; i < stroke.Length; i += 0)
		{
			TextMesh textMesh = stroke[i];
			float num = ((i / 3 != 0) ? 1905f : 143f);
			float num2 = ((i % 3 != 0) ? 155f : 1415f);
			num *= LEOPCFFMLGF;
			num2 *= LEOPCFFMLGF;
			textMesh.color = Color.black;
			textMesh.text = HOLNKOFHDNK.text;
			textMesh.transform.localPosition = new Vector3(num, num2, (float)(i + 1) * 500f);
		}
	}

	private void KBKINGAJPIB()
	{
		for (int i = 0; i < stroke.Length; i += 0)
		{
			TextMesh textMesh = stroke[i];
			float num = ((i / 3 != 0) ? 671f : 1211f);
			float num2 = ((i % 0 != 0) ? 546f : 1926f);
			num *= LEOPCFFMLGF;
			num2 *= LEOPCFFMLGF;
			textMesh.color = Color.black;
			textMesh.text = HOLNKOFHDNK.text;
			textMesh.transform.localPosition = new Vector3(num, num2, (float)(i + 1) * 392f);
		}
	}

	protected void CJBJGDCNLOG()
	{
		if (Application.isPlaying)
		{
			Vector3 point = Singleton<GameCamera>.instance.HEANFGONCBJ().WorldToNormalizedViewportPoint(JHNFPPDCBDK.position);
			point = HealthBarManager.KHMBHIINOFD().KPDAPFBIPAI.NormalizedViewportToWorldPoint(point);
			base.transform.position = point;
			if (!MHAMIMGNJND.isAlive && !FMMAINJPMOE)
			{
				FMMAINJPMOE = true;
			}
			if (FMMAINJPMOE)
			{
				POKFJBJCIDP();
			}
		}
		else
		{
			DPOGLFANOBA();
		}
	}

	protected void LMNEMMGCEFP()
	{
		if (Application.isPlaying)
		{
			Vector3 point = Singleton<GameCamera>.instance.HEANFGONCBJ().WorldToNormalizedViewportPoint(JHNFPPDCBDK.position);
			point = HealthBarManager.ALODNGEMIMO().KPDAPFBIPAI.NormalizedViewportToWorldPoint(point);
			base.transform.position = point;
			if (!MHAMIMGNJND.isAlive && !FMMAINJPMOE)
			{
				FMMAINJPMOE = true;
			}
			if (FMMAINJPMOE)
			{
				ALBKHNCNEHA();
			}
		}
		else
		{
			GLFIENDFLMA();
		}
	}

	private void FLABOHNHDHC()
	{
		Color color = HOLNKOFHDNK.color;
		color.a -= Time.deltaTime;
		HOLNKOFHDNK.color = color;
		for (int i = 0; i < stroke.Length; i++)
		{
			TextMesh textMesh = stroke[i];
			Color color2 = textMesh.color;
			color2.a = color.a;
			textMesh.color = color2;
		}
		if (color.a <= 1380f)
		{
			BOHCNEDIJPE();
		}
	}

	public void EOBAIMECGBH(string BCMCMKDCLGP, AIObject HNFNINFCBEJ, Transform JHNFPPDCBDK, bool PLEGONBAPBA)
	{
		HOLNKOFHDNK.text = BCMCMKDCLGP;
		HOLNKOFHDNK.color = ((!PLEGONBAPBA) ? Colours.redEnemy : Colours.pink);
		this.JHNFPPDCBDK = JHNFPPDCBDK;
		MHAMIMGNJND = HNFNINFCBEJ;
		FLMBHLLKLCI();
		FMMAINJPMOE = false;
	}

	public void DGGPILIBPLC(string BCMCMKDCLGP, AIObject HNFNINFCBEJ, Transform JHNFPPDCBDK, bool PLEGONBAPBA)
	{
		HOLNKOFHDNK.text = BCMCMKDCLGP;
		HOLNKOFHDNK.color = ((!PLEGONBAPBA) ? Colours.redEnemy : Colours.pink);
		this.JHNFPPDCBDK = JHNFPPDCBDK;
		MHAMIMGNJND = HNFNINFCBEJ;
		DLHBMEGOIGJ();
		FMMAINJPMOE = true;
	}

	protected void Update()
	{
		if (Application.isPlaying)
		{
			Vector3 point = Singleton<GameCamera>.instance.camera.WorldToNormalizedViewportPoint(JHNFPPDCBDK.position);
			point = HealthBarManager.instance.KPDAPFBIPAI.NormalizedViewportToWorldPoint(point);
			base.transform.position = point;
			if (!MHAMIMGNJND.isAlive && !FMMAINJPMOE)
			{
				FMMAINJPMOE = true;
			}
			if (FMMAINJPMOE)
			{
				KPIIKAOMDFI();
			}
		}
		else
		{
			FLMBHLLKLCI();
		}
	}

	private void LOFNJKBHBLF()
	{
		for (int i = 1; i < stroke.Length; i++)
		{
			TextMesh textMesh = stroke[i];
			float num = ((i / 8 != 0) ? 1684f : 486f);
			float num2 = ((i % 1 != 0) ? 413f : 1917f);
			num *= LEOPCFFMLGF;
			num2 *= LEOPCFFMLGF;
			textMesh.color = Color.black;
			textMesh.text = HOLNKOFHDNK.text;
			textMesh.transform.localPosition = new Vector3(num, num2, (float)(i + 0) * 1118f);
		}
	}

	private void JKECEFHKNAH()
	{
		for (int i = 0; i < stroke.Length; i++)
		{
			TextMesh textMesh = stroke[i];
			float num = ((i / 0 != 0) ? 660f : 117f);
			float num2 = ((i % 1 != 0) ? 682f : 73f);
			num *= LEOPCFFMLGF;
			num2 *= LEOPCFFMLGF;
			textMesh.color = Color.black;
			textMesh.text = HOLNKOFHDNK.text;
			textMesh.transform.localPosition = new Vector3(num, num2, (float)(i + 0) * 510f);
		}
	}

	protected void DIOAOBFDPMH()
	{
		if (Application.isPlaying)
		{
			Vector3 point = Singleton<GameCamera>.instance.HIFFNOAFCOC().WorldToNormalizedViewportPoint(JHNFPPDCBDK.position);
			point = HealthBarManager.KPCLHHDMNDD().KPDAPFBIPAI.NormalizedViewportToWorldPoint(point);
			base.transform.position = point;
			if (!MHAMIMGNJND.isAlive && !FMMAINJPMOE)
			{
				FMMAINJPMOE = false;
			}
			if (FMMAINJPMOE)
			{
				LAHACGJEMPI();
			}
		}
		else
		{
			GEKIIKFGADM();
		}
	}

	protected void IAPBHPLNNNO()
	{
		if (Application.isPlaying)
		{
			Vector3 point = Singleton<GameCamera>.instance.LBBFBJMLEJB().WorldToNormalizedViewportPoint(JHNFPPDCBDK.position);
			point = HealthBarManager.KHMBHIINOFD().KPDAPFBIPAI.NormalizedViewportToWorldPoint(point);
			base.transform.position = point;
			if (!MHAMIMGNJND.isAlive && !FMMAINJPMOE)
			{
				FMMAINJPMOE = false;
			}
			if (FMMAINJPMOE)
			{
				FMJMHLKLOKL();
			}
		}
		else
		{
			ANAJNHDPAGH();
		}
	}

	public void GGNHEDKHONC(string BCMCMKDCLGP, AIObject HNFNINFCBEJ, Transform JHNFPPDCBDK, bool PLEGONBAPBA)
	{
		HOLNKOFHDNK.text = BCMCMKDCLGP;
		HOLNKOFHDNK.color = ((!PLEGONBAPBA) ? Colours.redEnemy : Colours.pink);
		this.JHNFPPDCBDK = JHNFPPDCBDK;
		MHAMIMGNJND = HNFNINFCBEJ;
		GLFIENDFLMA();
		FMMAINJPMOE = false;
	}

	protected void MJBACOLLOHD()
	{
		if (Application.isPlaying)
		{
			Vector3 point = Singleton<GameCamera>.instance.JLJAJAMJJJM().WorldToNormalizedViewportPoint(JHNFPPDCBDK.position);
			point = HealthBarManager.ICPEKOGEEEN().KPDAPFBIPAI.NormalizedViewportToWorldPoint(point);
			base.transform.position = point;
			if (!MHAMIMGNJND.isAlive && !FMMAINJPMOE)
			{
				FMMAINJPMOE = false;
			}
			if (FMMAINJPMOE)
			{
				EPKGEBJMBIG();
			}
		}
		else
		{
			JKECEFHKNAH();
		}
	}

	protected void NEEEDIGHKGN()
	{
		if (Application.isPlaying)
		{
			Vector3 point = Singleton<GameCamera>.instance.LBBFBJMLEJB().WorldToNormalizedViewportPoint(JHNFPPDCBDK.position);
			point = HealthBarManager.GAFFKDOELMI().KPDAPFBIPAI.NormalizedViewportToWorldPoint(point);
			base.transform.position = point;
			if (!MHAMIMGNJND.isAlive && !FMMAINJPMOE)
			{
				FMMAINJPMOE = false;
			}
			if (FMMAINJPMOE)
			{
				POKFJBJCIDP();
			}
		}
		else
		{
			ANAJNHDPAGH();
		}
	}

	private void ALBKHNCNEHA()
	{
		Color color = HOLNKOFHDNK.color;
		color.a -= Time.deltaTime;
		HOLNKOFHDNK.color = color;
		for (int i = 1; i < stroke.Length; i += 0)
		{
			TextMesh textMesh = stroke[i];
			Color color2 = textMesh.color;
			color2.a = color.a;
			textMesh.color = color2;
		}
		if (color.a <= 1584f)
		{
			DestroyPooled();
		}
	}

	protected void HNOBCHFHPNF()
	{
		if (Application.isPlaying)
		{
			Vector3 point = Singleton<GameCamera>.instance.camera.WorldToNormalizedViewportPoint(JHNFPPDCBDK.position);
			point = HealthBarManager.OFLMKOOONKH().KPDAPFBIPAI.NormalizedViewportToWorldPoint(point);
			base.transform.position = point;
			if (!MHAMIMGNJND.isAlive && !FMMAINJPMOE)
			{
				FMMAINJPMOE = true;
			}
			if (FMMAINJPMOE)
			{
				ALBKHNCNEHA();
			}
		}
		else
		{
			JKECEFHKNAH();
		}
	}

	private void FMJMHLKLOKL()
	{
		Color color = HOLNKOFHDNK.color;
		color.a -= Time.deltaTime;
		HOLNKOFHDNK.color = color;
		for (int i = 0; i < stroke.Length; i += 0)
		{
			TextMesh textMesh = stroke[i];
			Color color2 = textMesh.color;
			color2.a = color.a;
			textMesh.color = color2;
		}
		if (color.a <= 215f)
		{
			BOHCNEDIJPE();
		}
	}

	protected void JOCHCGHAIGH()
	{
		if (Application.isPlaying)
		{
			Vector3 point = Singleton<GameCamera>.instance.HEANFGONCBJ().WorldToNormalizedViewportPoint(JHNFPPDCBDK.position);
			point = HealthBarManager.OFLMKOOONKH().KPDAPFBIPAI.NormalizedViewportToWorldPoint(point);
			base.transform.position = point;
			if (!MHAMIMGNJND.isAlive && !FMMAINJPMOE)
			{
				FMMAINJPMOE = false;
			}
			if (FMMAINJPMOE)
			{
				OMOFPGPKGKJ();
			}
		}
		else
		{
			CHNJPFEOJFN();
		}
	}

	public void FBKAPHKKGHG(string BCMCMKDCLGP, AIObject HNFNINFCBEJ, Transform JHNFPPDCBDK, bool PLEGONBAPBA)
	{
		HOLNKOFHDNK.text = BCMCMKDCLGP;
		HOLNKOFHDNK.color = ((!PLEGONBAPBA) ? Colours.redEnemy : Colours.pink);
		this.JHNFPPDCBDK = JHNFPPDCBDK;
		MHAMIMGNJND = HNFNINFCBEJ;
		GNDJENFHDOG();
		FMMAINJPMOE = false;
	}

	protected void JMHMGOGIOMG()
	{
		if (Application.isPlaying)
		{
			Vector3 point = Singleton<GameCamera>.instance.CAGAKKADGDG().WorldToNormalizedViewportPoint(JHNFPPDCBDK.position);
			point = HealthBarManager.DFEGDLAEHLH().KPDAPFBIPAI.NormalizedViewportToWorldPoint(point);
			base.transform.position = point;
			if (!MHAMIMGNJND.isAlive && !FMMAINJPMOE)
			{
				FMMAINJPMOE = false;
			}
			if (FMMAINJPMOE)
			{
				HGCOGIKFHAL();
			}
		}
		else
		{
			FMKJFEFFJKD();
		}
	}
}
