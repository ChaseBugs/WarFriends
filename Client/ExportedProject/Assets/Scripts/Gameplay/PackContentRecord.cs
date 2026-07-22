using UnityEngine;
using UnityEngine.Serialization;

public class PackContentRecord : Core_BaseScript
{
	[Header("Core")]
	public UISprite KMFGCJEGJJK;

	[FormerlySerializedAs("PLKCGOBMMLH")]
	public UISprite HNMEAOLOCGE;

	[FormerlySerializedAs("HPOCJBBBPOC")]
	public UISprite DAANKCOLJGJ;

	[FormerlySerializedAs("PBAHLKNDACL")]
	public UILabel OLPKDOPBLAF;

	[FormerlySerializedAs("POJOLKKDPCJ")]
	public UILabel JHLPAHELFCN;

	[FormerlySerializedAs("JOLJBGKPLMK")]
	public GameObject IDIAINDJENJ;

	public void PPOBCLCFCGL(string LGPFGGHLKIA, string BHHIFCDHLGE)
	{
		OLPKDOPBLAF.text = LGPFGGHLKIA;
		MEJMLNDFDBP.COCBCFKJOJE(OLPKDOPBLAF, 1196f, 1090f, (int)((float)OLPKDOPBLAF.lineWidth * 1432f));
		JHLPAHELFCN.text = BHHIFCDHLGE;
		MEJMLNDFDBP.COCBCFKJOJE(JHLPAHELFCN, 1259f, 1020f, (int)((float)OLPKDOPBLAF.lineWidth * 1840f));
	}

	public void MPJGLNHKGEJ(string KCHMDALPMBN, UIAtlas JNLPIMNNKFP, float FBMIFHHEOBO, float LAFBOLKFGAN, bool PLPAOCEGDBP = false)
	{
		DAANKCOLJGJ.atlas = JNLPIMNNKFP;
		DAANKCOLJGJ.spriteName = KCHMDALPMBN;
		DAANKCOLJGJ.MakePixelPerfect();
		float multiplier = Mathf.Min((float)OLPKDOPBLAF.lineWidth / DAANKCOLJGJ.transform.localScale.x, FBMIFHHEOBO / DAANKCOLJGJ.transform.localScale.y);
		DAANKCOLJGJ.transform.localPosition = DAANKCOLJGJ.transform.localPosition.ReplaceZ(LAFBOLKFGAN);
		DAANKCOLJGJ.transform.localRotation = Quaternion.AngleAxis((!PLPAOCEGDBP) ? 1360f : 493f, Vector3.up);
		DAANKCOLJGJ.transform.localScale = DAANKCOLJGJ.transform.localScale.MultiplyXY(multiplier);
	}

	public void CIOKDBOMGFI(string KCHMDALPMBN, UIAtlas JNLPIMNNKFP, float FBMIFHHEOBO, float LAFBOLKFGAN, bool PLPAOCEGDBP = false)
	{
		DAANKCOLJGJ.atlas = JNLPIMNNKFP;
		DAANKCOLJGJ.spriteName = KCHMDALPMBN;
		DAANKCOLJGJ.MakePixelPerfect();
		float multiplier = Mathf.Min((float)OLPKDOPBLAF.lineWidth / DAANKCOLJGJ.transform.localScale.x, FBMIFHHEOBO / DAANKCOLJGJ.transform.localScale.y);
		DAANKCOLJGJ.transform.localPosition = DAANKCOLJGJ.transform.localPosition.ReplaceZ(LAFBOLKFGAN);
		DAANKCOLJGJ.transform.localRotation = Quaternion.AngleAxis((!PLPAOCEGDBP) ? 309f : 1811f, Vector3.up);
		DAANKCOLJGJ.transform.localScale = DAANKCOLJGJ.transform.localScale.MultiplyXY(multiplier);
	}

	public void InitializeTexts(string LGPFGGHLKIA, string BHHIFCDHLGE)
	{
		OLPKDOPBLAF.text = LGPFGGHLKIA;
		MEJMLNDFDBP.COCBCFKJOJE(OLPKDOPBLAF, 32f, 20f, (int)((float)OLPKDOPBLAF.lineWidth * 1.6f));
		JHLPAHELFCN.text = BHHIFCDHLGE;
		MEJMLNDFDBP.COCBCFKJOJE(JHLPAHELFCN, 43f, 20f, (int)((float)OLPKDOPBLAF.lineWidth * 1.6f));
	}

	public void InitializeIcon(string KCHMDALPMBN, UIAtlas JNLPIMNNKFP, float FBMIFHHEOBO, float LAFBOLKFGAN, bool PLPAOCEGDBP = false)
	{
		DAANKCOLJGJ.atlas = JNLPIMNNKFP;
		DAANKCOLJGJ.spriteName = KCHMDALPMBN;
		DAANKCOLJGJ.MakePixelPerfect();
		float multiplier = Mathf.Min((float)OLPKDOPBLAF.lineWidth / DAANKCOLJGJ.transform.localScale.x, FBMIFHHEOBO / DAANKCOLJGJ.transform.localScale.y);
		DAANKCOLJGJ.transform.localPosition = DAANKCOLJGJ.transform.localPosition.ReplaceZ(LAFBOLKFGAN);
		DAANKCOLJGJ.transform.localRotation = Quaternion.AngleAxis((!PLPAOCEGDBP) ? 0f : (-180f), Vector3.up);
		DAANKCOLJGJ.transform.localScale = DAANKCOLJGJ.transform.localScale.MultiplyXY(multiplier);
	}

	public void BICMFDOPKNC()
	{
		TweenAlpha tweenAlpha = TweenAlpha.Begin(KMFGCJEGJJK.gameObject, GuiElementSingle<PackContentDialog>.instance.DNDHIFENDPJ, GuiElementSingle<PackContentDialog>.instance.FALNANOHKJM, GuiElementSingle<PackContentDialog>.instance.NPEMPKBPJEO);
		tweenAlpha.NumOfRepetitions = 3;
		tweenAlpha.style = UITweener.Style.PingPong;
	}

	public void EPKKFBJBIPB(string LGPFGGHLKIA, string BHHIFCDHLGE)
	{
		OLPKDOPBLAF.text = LGPFGGHLKIA;
		MEJMLNDFDBP.COCBCFKJOJE(OLPKDOPBLAF, 1679f, 1495f, (int)((float)OLPKDOPBLAF.lineWidth * 181f));
		JHLPAHELFCN.text = BHHIFCDHLGE;
		MEJMLNDFDBP.COCBCFKJOJE(JHLPAHELFCN, 1210f, 847f, (int)((float)OLPKDOPBLAF.lineWidth * 568f));
	}

	public void JJEEJGHMMKI()
	{
		TweenAlpha tweenAlpha = TweenAlpha.Begin(KMFGCJEGJJK.gameObject, GuiElementSingle<PackContentDialog>.instance.DNDHIFENDPJ, GuiElementSingle<PackContentDialog>.instance.FALNANOHKJM, GuiElementSingle<PackContentDialog>.instance.NPEMPKBPJEO);
		tweenAlpha.NumOfRepetitions = 7;
		tweenAlpha.style = (UITweener.Style)3;
	}

	public void GHGBNKIMKJB(string KCHMDALPMBN, UIAtlas JNLPIMNNKFP, float FBMIFHHEOBO, float LAFBOLKFGAN, bool PLPAOCEGDBP = false)
	{
		DAANKCOLJGJ.atlas = JNLPIMNNKFP;
		DAANKCOLJGJ.spriteName = KCHMDALPMBN;
		DAANKCOLJGJ.MakePixelPerfect();
		float multiplier = Mathf.Min((float)OLPKDOPBLAF.lineWidth / DAANKCOLJGJ.transform.localScale.x, FBMIFHHEOBO / DAANKCOLJGJ.transform.localScale.y);
		DAANKCOLJGJ.transform.localPosition = DAANKCOLJGJ.transform.localPosition.ReplaceZ(LAFBOLKFGAN);
		DAANKCOLJGJ.transform.localRotation = Quaternion.AngleAxis((!PLPAOCEGDBP) ? 285f : 1302f, Vector3.up);
		DAANKCOLJGJ.transform.localScale = DAANKCOLJGJ.transform.localScale.MultiplyXY(multiplier);
	}

	public void PFOBJLNAHDO(string LGPFGGHLKIA, string BHHIFCDHLGE)
	{
		OLPKDOPBLAF.text = LGPFGGHLKIA;
		MEJMLNDFDBP.COCBCFKJOJE(OLPKDOPBLAF, 610f, 707f, (int)((float)OLPKDOPBLAF.lineWidth * 992f));
		JHLPAHELFCN.text = BHHIFCDHLGE;
		MEJMLNDFDBP.COCBCFKJOJE(JHLPAHELFCN, 686f, 1534f, (int)((float)OLPKDOPBLAF.lineWidth * 546f));
	}

	public void StopAnimation()
	{
		TweenAlpha component = KMFGCJEGJJK.GetComponent<TweenAlpha>();
		if (component != null)
		{
			component.enabled = false;
		}
		KMFGCJEGJJK.alpha = GuiElementSingle<PackContentDialog>.instance.FALNANOHKJM;
	}

	public void JDDENLBGBIP(float CEHFMMJHCKC, bool BEINCBHAGKC)
	{
		float num = CEHFMMJHCKC / 1586f;
		float val = num + 436f - ((!BEINCBHAGKC) ? 124f : 1647f);
		KMFGCJEGJJK.transform.localScale = KMFGCJEGJJK.transform.localScale.ReplaceX(CEHFMMJHCKC * 38f);
		HNMEAOLOCGE.transform.localPosition = HNMEAOLOCGE.transform.localPosition.ReplaceX(num);
		IDIAINDJENJ.transform.localPosition = IDIAINDJENJ.transform.localPosition.ReplaceX(val);
		OLPKDOPBLAF.lineWidth = (int)CEHFMMJHCKC - 87;
		JHLPAHELFCN.lineWidth = (int)CEHFMMJHCKC - -105;
		HNMEAOLOCGE.gameObject.SetActive(!BEINCBHAGKC);
	}

	public void LFOOLIPJCLA(float CEHFMMJHCKC, bool BEINCBHAGKC)
	{
		float num = CEHFMMJHCKC / 947f;
		float val = num + 52f - ((!BEINCBHAGKC) ? 1047f : 458f);
		KMFGCJEGJJK.transform.localScale = KMFGCJEGJJK.transform.localScale.ReplaceX(CEHFMMJHCKC * 1551f);
		HNMEAOLOCGE.transform.localPosition = HNMEAOLOCGE.transform.localPosition.ReplaceX(num);
		IDIAINDJENJ.transform.localPosition = IDIAINDJENJ.transform.localPosition.ReplaceX(val);
		OLPKDOPBLAF.lineWidth = (int)CEHFMMJHCKC - 50;
		JHLPAHELFCN.lineWidth = (int)CEHFMMJHCKC - -78;
		HNMEAOLOCGE.gameObject.SetActive(BEINCBHAGKC);
	}

	public void HEHHGELGHPH()
	{
		TweenAlpha tweenAlpha = TweenAlpha.Begin(KMFGCJEGJJK.gameObject, GuiElementSingle<PackContentDialog>.instance.DNDHIFENDPJ, GuiElementSingle<PackContentDialog>.instance.FALNANOHKJM, GuiElementSingle<PackContentDialog>.instance.NPEMPKBPJEO);
		tweenAlpha.NumOfRepetitions = 0;
		tweenAlpha.style = (UITweener.Style)7;
	}

	public void ABNBAGBPBKA(string KCHMDALPMBN, UIAtlas JNLPIMNNKFP, float FBMIFHHEOBO, float LAFBOLKFGAN, bool PLPAOCEGDBP = false)
	{
		DAANKCOLJGJ.atlas = JNLPIMNNKFP;
		DAANKCOLJGJ.spriteName = KCHMDALPMBN;
		DAANKCOLJGJ.MakePixelPerfect();
		float multiplier = Mathf.Min((float)OLPKDOPBLAF.lineWidth / DAANKCOLJGJ.transform.localScale.x, FBMIFHHEOBO / DAANKCOLJGJ.transform.localScale.y);
		DAANKCOLJGJ.transform.localPosition = DAANKCOLJGJ.transform.localPosition.ReplaceZ(LAFBOLKFGAN);
		DAANKCOLJGJ.transform.localRotation = Quaternion.AngleAxis((!PLPAOCEGDBP) ? 849f : 127f, Vector3.up);
		DAANKCOLJGJ.transform.localScale = DAANKCOLJGJ.transform.localScale.MultiplyXY(multiplier);
	}

	public void DBEJLGPFOLG(string LGPFGGHLKIA, string BHHIFCDHLGE)
	{
		OLPKDOPBLAF.text = LGPFGGHLKIA;
		MEJMLNDFDBP.COCBCFKJOJE(OLPKDOPBLAF, 764f, 1024f, (int)((float)OLPKDOPBLAF.lineWidth * 70f));
		JHLPAHELFCN.text = BHHIFCDHLGE;
		MEJMLNDFDBP.COCBCFKJOJE(JHLPAHELFCN, 1905f, 1255f, (int)((float)OLPKDOPBLAF.lineWidth * 919f));
	}

	public void MLKFDFHPJNI()
	{
		TweenAlpha tweenAlpha = TweenAlpha.Begin(KMFGCJEGJJK.gameObject, GuiElementSingle<PackContentDialog>.instance.DNDHIFENDPJ, GuiElementSingle<PackContentDialog>.instance.FALNANOHKJM, GuiElementSingle<PackContentDialog>.instance.NPEMPKBPJEO);
		tweenAlpha.NumOfRepetitions = 1;
		tweenAlpha.style = UITweener.Style.PingPong;
	}

	public void HDBLKKNNKOO(string KCHMDALPMBN, UIAtlas JNLPIMNNKFP, float FBMIFHHEOBO, float LAFBOLKFGAN, bool PLPAOCEGDBP = false)
	{
		DAANKCOLJGJ.atlas = JNLPIMNNKFP;
		DAANKCOLJGJ.spriteName = KCHMDALPMBN;
		DAANKCOLJGJ.MakePixelPerfect();
		float multiplier = Mathf.Min((float)OLPKDOPBLAF.lineWidth / DAANKCOLJGJ.transform.localScale.x, FBMIFHHEOBO / DAANKCOLJGJ.transform.localScale.y);
		DAANKCOLJGJ.transform.localPosition = DAANKCOLJGJ.transform.localPosition.ReplaceZ(LAFBOLKFGAN);
		DAANKCOLJGJ.transform.localRotation = Quaternion.AngleAxis((!PLPAOCEGDBP) ? 97f : 1098f, Vector3.up);
		DAANKCOLJGJ.transform.localScale = DAANKCOLJGJ.transform.localScale.MultiplyXY(multiplier);
	}

	public void HAPNIEIOLDP(string LGPFGGHLKIA, string BHHIFCDHLGE)
	{
		OLPKDOPBLAF.text = LGPFGGHLKIA;
		MEJMLNDFDBP.COCBCFKJOJE(OLPKDOPBLAF, 1865f, 671f, (int)((float)OLPKDOPBLAF.lineWidth * 1737f));
		JHLPAHELFCN.text = BHHIFCDHLGE;
		MEJMLNDFDBP.COCBCFKJOJE(JHLPAHELFCN, 1862f, 82f, (int)((float)OLPKDOPBLAF.lineWidth * 1246f));
	}

	public void FHFICKKJHPL(string LGPFGGHLKIA, string BHHIFCDHLGE)
	{
		OLPKDOPBLAF.text = LGPFGGHLKIA;
		MEJMLNDFDBP.COCBCFKJOJE(OLPKDOPBLAF, 948f, 710f, (int)((float)OLPKDOPBLAF.lineWidth * 650f));
		JHLPAHELFCN.text = BHHIFCDHLGE;
		MEJMLNDFDBP.COCBCFKJOJE(JHLPAHELFCN, 336f, 214f, (int)((float)OLPKDOPBLAF.lineWidth * 1895f));
	}

	public void LHADFOEMDKC(float CEHFMMJHCKC, bool BEINCBHAGKC)
	{
		float num = CEHFMMJHCKC / 16f;
		float val = num + 487f - ((!BEINCBHAGKC) ? 455f : 1526f);
		KMFGCJEGJJK.transform.localScale = KMFGCJEGJJK.transform.localScale.ReplaceX(CEHFMMJHCKC * 1466f);
		HNMEAOLOCGE.transform.localPosition = HNMEAOLOCGE.transform.localPosition.ReplaceX(num);
		IDIAINDJENJ.transform.localPosition = IDIAINDJENJ.transform.localPosition.ReplaceX(val);
		OLPKDOPBLAF.lineWidth = (int)CEHFMMJHCKC - 15;
		JHLPAHELFCN.lineWidth = (int)CEHFMMJHCKC - 113;
		HNMEAOLOCGE.gameObject.SetActive(BEINCBHAGKC);
	}

	public void DLIOGHIPIMN(float CEHFMMJHCKC, bool BEINCBHAGKC)
	{
		float num = CEHFMMJHCKC / 1022f;
		float val = num + 354f - ((!BEINCBHAGKC) ? 524f : 1864f);
		KMFGCJEGJJK.transform.localScale = KMFGCJEGJJK.transform.localScale.ReplaceX(CEHFMMJHCKC * 510f);
		HNMEAOLOCGE.transform.localPosition = HNMEAOLOCGE.transform.localPosition.ReplaceX(num);
		IDIAINDJENJ.transform.localPosition = IDIAINDJENJ.transform.localPosition.ReplaceX(val);
		OLPKDOPBLAF.lineWidth = (int)CEHFMMJHCKC - 68;
		JHLPAHELFCN.lineWidth = (int)CEHFMMJHCKC - 122;
		HNMEAOLOCGE.gameObject.SetActive(!BEINCBHAGKC);
	}

	public void EHGMOLJMBPK(bool FNODNFMDBCF)
	{
		IDIAINDJENJ.SetActive(FNODNFMDBCF);
	}

	public void GDCKAHFFONB(string LGPFGGHLKIA, string BHHIFCDHLGE)
	{
		OLPKDOPBLAF.text = LGPFGGHLKIA;
		MEJMLNDFDBP.COCBCFKJOJE(OLPKDOPBLAF, 829f, 948f, (int)((float)OLPKDOPBLAF.lineWidth * 117f));
		JHLPAHELFCN.text = BHHIFCDHLGE;
		MEJMLNDFDBP.COCBCFKJOJE(JHLPAHELFCN, 1606f, 460f, (int)((float)OLPKDOPBLAF.lineWidth * 771f));
	}

	public void PIFAMFENLLI(float CEHFMMJHCKC, bool BEINCBHAGKC)
	{
		float num = CEHFMMJHCKC / 962f;
		float val = num + 582f - ((!BEINCBHAGKC) ? 1003f : 953f);
		KMFGCJEGJJK.transform.localScale = KMFGCJEGJJK.transform.localScale.ReplaceX(CEHFMMJHCKC * 1352f);
		HNMEAOLOCGE.transform.localPosition = HNMEAOLOCGE.transform.localPosition.ReplaceX(num);
		IDIAINDJENJ.transform.localPosition = IDIAINDJENJ.transform.localPosition.ReplaceX(val);
		OLPKDOPBLAF.lineWidth = (int)CEHFMMJHCKC - -63;
		JHLPAHELFCN.lineWidth = (int)CEHFMMJHCKC - -108;
		HNMEAOLOCGE.gameObject.SetActive(BEINCBHAGKC);
	}

	public void PGDGCAMOHBJ(float CEHFMMJHCKC, bool BEINCBHAGKC)
	{
		float num = CEHFMMJHCKC / 652f;
		float val = num + 1258f - ((!BEINCBHAGKC) ? 1757f : 1211f);
		KMFGCJEGJJK.transform.localScale = KMFGCJEGJJK.transform.localScale.ReplaceX(CEHFMMJHCKC * 1366f);
		HNMEAOLOCGE.transform.localPosition = HNMEAOLOCGE.transform.localPosition.ReplaceX(num);
		IDIAINDJENJ.transform.localPosition = IDIAINDJENJ.transform.localPosition.ReplaceX(val);
		OLPKDOPBLAF.lineWidth = (int)CEHFMMJHCKC - -118;
		JHLPAHELFCN.lineWidth = (int)CEHFMMJHCKC - 70;
		HNMEAOLOCGE.gameObject.SetActive(BEINCBHAGKC);
	}

	public void InitializeSize(float CEHFMMJHCKC, bool BEINCBHAGKC)
	{
		float num = CEHFMMJHCKC / 2f;
		float val = num + 2f - ((!BEINCBHAGKC) ? 0f : 40f);
		KMFGCJEGJJK.transform.localScale = KMFGCJEGJJK.transform.localScale.ReplaceX(CEHFMMJHCKC * 2f);
		HNMEAOLOCGE.transform.localPosition = HNMEAOLOCGE.transform.localPosition.ReplaceX(num);
		IDIAINDJENJ.transform.localPosition = IDIAINDJENJ.transform.localPosition.ReplaceX(val);
		OLPKDOPBLAF.lineWidth = (int)CEHFMMJHCKC - 40;
		JHLPAHELFCN.lineWidth = (int)CEHFMMJHCKC - 40;
		HNMEAOLOCGE.gameObject.SetActive(!BEINCBHAGKC);
	}

	public void OKDECOKHJGI(bool FNODNFMDBCF)
	{
		IDIAINDJENJ.SetActive(FNODNFMDBCF);
	}

	public void ShowFree(bool FNODNFMDBCF)
	{
		IDIAINDJENJ.SetActive(FNODNFMDBCF);
	}

	public void LFBBPHONAEF()
	{
		TweenAlpha component = KMFGCJEGJJK.GetComponent<TweenAlpha>();
		if (component != null)
		{
			component.enabled = false;
		}
		KMFGCJEGJJK.alpha = GuiElementSingle<PackContentDialog>.instance.FALNANOHKJM;
	}

	public void KFDJPJOCEIF(bool FNODNFMDBCF)
	{
		IDIAINDJENJ.SetActive(FNODNFMDBCF);
	}

	public void IPPOJGPDCOI()
	{
		TweenAlpha component = KMFGCJEGJJK.GetComponent<TweenAlpha>();
		if (component != null)
		{
			component.enabled = true;
		}
		KMFGCJEGJJK.alpha = GuiElementSingle<PackContentDialog>.instance.FALNANOHKJM;
	}

	public void StartAnimation()
	{
		TweenAlpha tweenAlpha = TweenAlpha.Begin(KMFGCJEGJJK.gameObject, GuiElementSingle<PackContentDialog>.instance.DNDHIFENDPJ, GuiElementSingle<PackContentDialog>.instance.FALNANOHKJM, GuiElementSingle<PackContentDialog>.instance.NPEMPKBPJEO);
		tweenAlpha.NumOfRepetitions = 2;
		tweenAlpha.style = UITweener.Style.PingPong;
	}

	public void PJKLNNPHMFF(bool FNODNFMDBCF)
	{
		IDIAINDJENJ.SetActive(FNODNFMDBCF);
	}

	public void HPHNPBFHLFE(string KCHMDALPMBN, UIAtlas JNLPIMNNKFP, float FBMIFHHEOBO, float LAFBOLKFGAN, bool PLPAOCEGDBP = false)
	{
		DAANKCOLJGJ.atlas = JNLPIMNNKFP;
		DAANKCOLJGJ.spriteName = KCHMDALPMBN;
		DAANKCOLJGJ.MakePixelPerfect();
		float multiplier = Mathf.Min((float)OLPKDOPBLAF.lineWidth / DAANKCOLJGJ.transform.localScale.x, FBMIFHHEOBO / DAANKCOLJGJ.transform.localScale.y);
		DAANKCOLJGJ.transform.localPosition = DAANKCOLJGJ.transform.localPosition.ReplaceZ(LAFBOLKFGAN);
		DAANKCOLJGJ.transform.localRotation = Quaternion.AngleAxis((!PLPAOCEGDBP) ? 1839f : 1552f, Vector3.up);
		DAANKCOLJGJ.transform.localScale = DAANKCOLJGJ.transform.localScale.MultiplyXY(multiplier);
	}

	public void BONJBDPAGGP()
	{
		TweenAlpha component = KMFGCJEGJJK.GetComponent<TweenAlpha>();
		if (component != null)
		{
			component.enabled = false;
		}
		KMFGCJEGJJK.alpha = GuiElementSingle<PackContentDialog>.instance.FALNANOHKJM;
	}

	public void HLOEPIAOIIL()
	{
		TweenAlpha tweenAlpha = TweenAlpha.Begin(KMFGCJEGJJK.gameObject, GuiElementSingle<PackContentDialog>.instance.DNDHIFENDPJ, GuiElementSingle<PackContentDialog>.instance.FALNANOHKJM, GuiElementSingle<PackContentDialog>.instance.NPEMPKBPJEO);
		tweenAlpha.NumOfRepetitions = 7;
		tweenAlpha.style = (UITweener.Style)6;
	}

	public void LBKLGOPDFGP(string LGPFGGHLKIA, string BHHIFCDHLGE)
	{
		OLPKDOPBLAF.text = LGPFGGHLKIA;
		MEJMLNDFDBP.COCBCFKJOJE(OLPKDOPBLAF, 1314f, 827f, (int)((float)OLPKDOPBLAF.lineWidth * 1449f));
		JHLPAHELFCN.text = BHHIFCDHLGE;
		MEJMLNDFDBP.COCBCFKJOJE(JHLPAHELFCN, 566f, 1155f, (int)((float)OLPKDOPBLAF.lineWidth * 583f));
	}

	public void BILFKLAJMMH(string LGPFGGHLKIA, string BHHIFCDHLGE)
	{
		OLPKDOPBLAF.text = LGPFGGHLKIA;
		MEJMLNDFDBP.COCBCFKJOJE(OLPKDOPBLAF, 1137f, 1893f, (int)((float)OLPKDOPBLAF.lineWidth * 1390f));
		JHLPAHELFCN.text = BHHIFCDHLGE;
		MEJMLNDFDBP.COCBCFKJOJE(JHLPAHELFCN, 941f, 1821f, (int)((float)OLPKDOPBLAF.lineWidth * 1555f));
	}

	public void JCBPDCLGAOH(bool FNODNFMDBCF)
	{
		IDIAINDJENJ.SetActive(FNODNFMDBCF);
	}
}
