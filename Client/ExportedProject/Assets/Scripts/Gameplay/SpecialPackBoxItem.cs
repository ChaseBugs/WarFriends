using UnityEngine;
using UnityEngine.Serialization;

public class SpecialPackBoxItem : Core_BaseScript
{
	private class BBAILHGBFKC
	{
		public Vector3 JKMPOKFPBCN;

		public Vector3 BAEDFKBOLDF;

		public Vector3 JAOLPJJDJLM;

		public Vector3 COMKGFFGGDJ;

		public Vector3 CKJKGBNKODH;

		public Vector3 LFDFHGDKPIP;

		public Vector3 MNLCAFKKLHM;

		public Vector3 COEIFOAKEEK;

		public int KPOEOLKFGBJ;

		public int MLPOJAKCKIA;

		public Vector3 JKLNAKKDGGG;

		public int LJHOJJEFGIG;

		public BBAILHGBFKC(Vector3 OLCKKJHGCIO, Vector3 LPHOEJFJGHE, Vector3 FDANOOGGEHC, Vector3 NOKNCGIHICC, Vector3 AFHHOCAPLEB, Vector3 LJKKLBDHGKA, Vector3 PHPKCIAPKPL, Vector3 OHIKCPCIGFL, int CPAIKHALDNB, int OHPPNEONFOD, Vector3 EEMHABAGLJH, int HIFEFONLDAP)
		{
			JKMPOKFPBCN = OLCKKJHGCIO;
			BAEDFKBOLDF = LPHOEJFJGHE;
			JAOLPJJDJLM = FDANOOGGEHC;
			COMKGFFGGDJ = NOKNCGIHICC;
			CKJKGBNKODH = AFHHOCAPLEB;
			LFDFHGDKPIP = LJKKLBDHGKA;
			MNLCAFKKLHM = PHPKCIAPKPL;
			COEIFOAKEEK = OHIKCPCIGFL;
			KPOEOLKFGBJ = CPAIKHALDNB;
			MLPOJAKCKIA = OHPPNEONFOD;
			JKLNAKKDGGG = EEMHABAGLJH;
			LJHOJJEFGIG = HIFEFONLDAP;
		}
	}

	[FormerlySerializedAs("OFCPEAHNKPG")]
	[Header("Core")]
	public UIPanel[] DCBFDOIIKDN;

	[FormerlySerializedAs("GIMMLMFBMEI")]
	public UISprite KMFGCJEGJJK;

	[Header("-Labels")]
	[FormerlySerializedAs("LEPNKAFEHLM")]
	public UILabel HKBNPBPEHMK;

	[FormerlySerializedAs("JDCNLEILOBE")]
	public GameObject JMBPNBGCFIL;

	[FormerlySerializedAs("MGNPKOPCKFG")]
	public UISprite BDDMIDHPDKF;

	[FormerlySerializedAs("EFBMNPOPDBH")]
	public UILabel CKAJHKAHFJO;

	[Header("-Free")]
	[FormerlySerializedAs("JOLJBGKPLMK")]
	public GameObject IDIAINDJENJ;

	[Header("-Icons")]
	[FormerlySerializedAs("HPOCJBBBPOC")]
	public UISprite DAANKCOLJGJ;

	[FormerlySerializedAs("COGPFIGDCJG")]
	public UITexture NGHCDIMLGMO;

	[Header("-Power Band")]
	[FormerlySerializedAs("MEPHGACCGHO")]
	public GameObject DPHDJEAHODH;

	[FormerlySerializedAs("OHOFFJDFFBH")]
	public UISprite FIHDDPJFFDG;

	[FormerlySerializedAs("PBEPMEPBCOP")]
	public UILabel JBCBEOCNJBH;

	[FormerlySerializedAs("KKAEGFEAFMN")]
	[Header("-Warcards")]
	public UIGrid EIIHMDANCJN;

	[FormerlySerializedAs("EMGIKDAHFBK")]
	public GameObject[] ACIOBAPMPMD;

	[FormerlySerializedAs("HJDMMBPIDLL")]
	public UISprite[] GFAFBPKEOAE;

	[FormerlySerializedAs("EKDFCCMAHEH")]
	public UISprite[] KLMKPEOCBBP;

	[Header("-Cardpacks")]
	[FormerlySerializedAs("LEMEALBMBIA")]
	public UIGrid JCKBEHPJPKB;

	[FormerlySerializedAs("HEFKAEPHHAG")]
	public GameObject[] INOENHONIGK;

	[FormerlySerializedAs("KAFFONMEGCA")]
	public UISprite[] PMFBBFANDKC;

	[FormerlySerializedAs("LHBOLBIKHPG")]
	public UISprite[] DDKOOJPKCIF;

	[FormerlySerializedAs("JCLDILPPCGD")]
	public UISprite[] OGOBOFIOIIG;

	[Header("-Atlas And Settings")]
	[FormerlySerializedAs("FDBDNCAGAEL")]
	public UIAtlas JBIKIJKOPAI;

	[FormerlySerializedAs("IOGCGKIBFEK")]
	public UIAtlas DJANOPAECLJ;

	[FormerlySerializedAs("FDJBLOGHLJA")]
	public UIAtlas ICFPOEEDLLO;

	[FormerlySerializedAs("JKJONPKFCAG")]
	public UIAtlas CPOEDEOKPEA;

	[FormerlySerializedAs("CDPPCKHGEOD")]
	public bool BPOOOOIIDFC;

	private float AFNBBMBGFNI = 1f;

	private WeaponLevelsSetup MDAJJIAMDGH;

	private static BBAILHGBFKC[][] HBFNDDCFFEE = new BBAILHGBFKC[5][]
	{
		new BBAILHGBFKC[2]
		{
			new BBAILHGBFKC(new Vector3(0f, 138f, 0f), new Vector3(736f, 260f, 1f), new Vector3(-186f, 0f, 0f), new Vector3(190f, 111f, 1f), new Vector3(190f, 127f, 1f), new Vector3(-186f, 6f, 0f), new Vector3(180f, 149f, 1f), new Vector3(-186f, 0f, -1f), 80, 30, new Vector3(-232f, 0f, -0.5f), 90),
			new BBAILHGBFKC(new Vector3(0f, -136f, 0f), new Vector3(736f, 260f, 1f), new Vector3(-186f, 0f, 0f), new Vector3(190f, 111f, 1f), new Vector3(190f, 127f, 1f), new Vector3(-186f, 6f, 0f), new Vector3(180f, 149f, 1f), new Vector3(-186f, 0f, -1f), 80, 30, new Vector3(-232f, 0f, -0.5f), 90)
		},
		new BBAILHGBFKC[3]
		{
			new BBAILHGBFKC(new Vector3(0f, 179f, 0f), new Vector3(736f, 164f, 1f), new Vector3(-186f, 0f, 0f), new Vector3(190f, 111f, 1f), new Vector3(190f, 127f, 1f), new Vector3(-186f, 6f, 0f), new Vector3(180f, 149f, 1f), new Vector3(-186f, 0f, -1f), 30, 10, new Vector3(-232f, 0f, -0.5f), 30),
			new BBAILHGBFKC(new Vector3(0f, 1f, 0f), new Vector3(736f, 164f, 1f), new Vector3(-186f, 0f, 0f), new Vector3(190f, 111f, 1f), new Vector3(190f, 127f, 1f), new Vector3(-186f, 6f, 0f), new Vector3(180f, 149f, 1f), new Vector3(-186f, 0f, -1f), 30, 10, new Vector3(-232f, 0f, -0.5f), 30),
			new BBAILHGBFKC(new Vector3(0f, -177f, 0f), new Vector3(736f, 164f, 1f), new Vector3(-186f, 0f, 0f), new Vector3(190f, 111f, 1f), new Vector3(190f, 127f, 1f), new Vector3(-186f, 6f, 0f), new Vector3(180f, 149f, 1f), new Vector3(-186f, 0f, -1f), 30, 10, new Vector3(-232f, 0f, -0.5f), 30)
		},
		new BBAILHGBFKC[4]
		{
			new BBAILHGBFKC(new Vector3(-186f, 138f, 0f), new Vector3(364f, 260f, 1f), new Vector3(0f, 20f, 0f), new Vector3(193f, 113f, 1f), new Vector3(193f, 129f, 1f), new Vector3(0f, 20f, 0f), new Vector3(203f, 168f, 1f), new Vector3(0f, -10f, -1f), 90, 30, new Vector3(-46f, 22f, -0.5f), 120),
			new BBAILHGBFKC(new Vector3(186f, 138f, 0f), new Vector3(364f, 260f, 1f), new Vector3(0f, 20f, 0f), new Vector3(193f, 113f, 1f), new Vector3(193f, 129f, 1f), new Vector3(0f, 20f, 0f), new Vector3(203f, 168f, 1f), new Vector3(0f, -10f, -1f), 90, 30, new Vector3(-46f, 22f, -0.5f), 120),
			new BBAILHGBFKC(new Vector3(-186f, -136f, 0f), new Vector3(364f, 260f, 1f), new Vector3(0f, 20f, 0f), new Vector3(193f, 113f, 1f), new Vector3(193f, 129f, 1f), new Vector3(0f, 20f, 0f), new Vector3(203f, 168f, 1f), new Vector3(0f, -10f, -1f), 90, 30, new Vector3(-46f, 22f, -0.5f), 120),
			new BBAILHGBFKC(new Vector3(186f, -136f, 0f), new Vector3(364f, 260f, 1f), new Vector3(0f, 20f, 0f), new Vector3(193f, 113f, 1f), new Vector3(193f, 129f, 1f), new Vector3(0f, 20f, 0f), new Vector3(203f, 168f, 1f), new Vector3(0f, -10f, -1f), 90, 30, new Vector3(-46f, 22f, -0.5f), 120)
		},
		new BBAILHGBFKC[5]
		{
			new BBAILHGBFKC(new Vector3(0f, 179f, 0f), new Vector3(736f, 164f, 1f), new Vector3(-186f, 0f, 0f), new Vector3(190f, 111f, 1f), new Vector3(190f, 127f, 1f), new Vector3(-186f, 6f, 0f), new Vector3(180f, 149f, 1f), new Vector3(-186f, 0f, -1f), 30, 10, new Vector3(-232f, 0f, -0.5f), 30),
			new BBAILHGBFKC(new Vector3(-186f, 1f, 0f), new Vector3(364f, 164f, 1f), new Vector3(0f, 20f, 0f), new Vector3(159f, 88f, 1f), new Vector3(150f, 100f, 1f), new Vector3(0f, 12f, 0f), new Vector3(160f, 132f, 1f), new Vector3(0f, -10f, -1f), 60, 10, new Vector3(-46f, 22f, -0.5f), 60),
			new BBAILHGBFKC(new Vector3(186f, 1f, 0f), new Vector3(364f, 164f, 1f), new Vector3(0f, 20f, 0f), new Vector3(159f, 88f, 1f), new Vector3(150f, 100f, 1f), new Vector3(0f, 12f, 0f), new Vector3(160f, 132f, 1f), new Vector3(0f, -10f, -1f), 60, 10, new Vector3(-46f, 22f, -0.5f), 60),
			new BBAILHGBFKC(new Vector3(-186f, -177f, 0f), new Vector3(364f, 164f, 1f), new Vector3(0f, 20f, 0f), new Vector3(159f, 88f, 1f), new Vector3(150f, 100f, 1f), new Vector3(0f, 12f, 0f), new Vector3(160f, 132f, 1f), new Vector3(0f, -10f, -1f), 60, 10, new Vector3(-46f, 22f, -0.5f), 60),
			new BBAILHGBFKC(new Vector3(186f, -177f, 0f), new Vector3(364f, 164f, 1f), new Vector3(0f, 20f, 0f), new Vector3(159f, 88f, 1f), new Vector3(150f, 100f, 1f), new Vector3(0f, 12f, 0f), new Vector3(160f, 132f, 1f), new Vector3(0f, -10f, -1f), 60, 10, new Vector3(-46f, 22f, -0.5f), 60)
		},
		new BBAILHGBFKC[6]
		{
			new BBAILHGBFKC(new Vector3(-186f, 179f, 0f), new Vector3(364f, 164f, 1f), new Vector3(0f, 20f, 0f), new Vector3(159f, 88f, 1f), new Vector3(150f, 100f, 1f), new Vector3(0f, 12f, 0f), new Vector3(160f, 132f, 1f), new Vector3(0f, -10f, -1f), 60, 10, new Vector3(-46f, 22f, -0.5f), 60),
			new BBAILHGBFKC(new Vector3(186f, 179f, 0f), new Vector3(364f, 164f, 1f), new Vector3(0f, 20f, 0f), new Vector3(159f, 88f, 1f), new Vector3(150f, 100f, 1f), new Vector3(0f, 12f, 0f), new Vector3(160f, 132f, 1f), new Vector3(0f, -10f, -1f), 60, 10, new Vector3(-46f, 22f, -0.5f), 60),
			new BBAILHGBFKC(new Vector3(-186f, 1f, 0f), new Vector3(364f, 164f, 1f), new Vector3(0f, 20f, 0f), new Vector3(159f, 88f, 1f), new Vector3(150f, 100f, 1f), new Vector3(0f, 12f, 0f), new Vector3(160f, 132f, 1f), new Vector3(0f, -10f, -1f), 60, 10, new Vector3(-46f, 22f, -0.5f), 60),
			new BBAILHGBFKC(new Vector3(186f, 1f, 0f), new Vector3(364f, 164f, 1f), new Vector3(0f, 20f, 0f), new Vector3(159f, 88f, 1f), new Vector3(150f, 100f, 1f), new Vector3(0f, 12f, 0f), new Vector3(160f, 132f, 1f), new Vector3(0f, -10f, -1f), 60, 10, new Vector3(-46f, 22f, -0.5f), 60),
			new BBAILHGBFKC(new Vector3(-186f, -177f, 0f), new Vector3(364f, 164f, 1f), new Vector3(0f, 20f, 0f), new Vector3(159f, 88f, 1f), new Vector3(150f, 100f, 1f), new Vector3(0f, 12f, 0f), new Vector3(160f, 132f, 1f), new Vector3(0f, -10f, -1f), 60, 10, new Vector3(-46f, 22f, -0.5f), 60),
			new BBAILHGBFKC(new Vector3(186f, -177f, 0f), new Vector3(364f, 164f, 1f), new Vector3(0f, 20f, 0f), new Vector3(159f, 88f, 1f), new Vector3(150f, 100f, 1f), new Vector3(0f, 12f, 0f), new Vector3(160f, 132f, 1f), new Vector3(0f, -10f, -1f), 60, 10, new Vector3(-46f, 22f, -0.5f), 60)
		}
	};

	public void AlterShownCustomization(int AJADPEFAMJP, int JNPDHGIHLEJ)
	{
		if (JNPDHGIHLEJ < 2 || 6 < JNPDHGIHLEJ)
		{
			Debug.LogError("WRONG NUMBER OF ALL BOXES " + JNPDHGIHLEJ);
			JNPDHGIHLEJ = Mathf.Clamp(JNPDHGIHLEJ, 2, 6);
		}
		if (AJADPEFAMJP < 1 || JNPDHGIHLEJ < AJADPEFAMJP)
		{
			Debug.LogError("WRONG NUMBER OF ORDER " + AJADPEFAMJP + " BOXES " + JNPDHGIHLEJ);
			AJADPEFAMJP = Mathf.Clamp(AJADPEFAMJP, 1, JNPDHGIHLEJ);
		}
		int num = (int)HBFNDDCFFEE[JNPDHGIHLEJ - 2][AJADPEFAMJP - 1].BAEDFKBOLDF.x;
		int num2 = (int)HBFNDDCFFEE[JNPDHGIHLEJ - 2][AJADPEFAMJP - 1].BAEDFKBOLDF.y;
		int num3;
		switch (JNPDHGIHLEJ)
		{
		case 5:
			num3 = ((AJADPEFAMJP == 1) ? 1 : 0);
			break;
		default:
			num3 = 0;
			break;
		case 2:
		case 3:
			num3 = 1;
			break;
		}
		bool flag = (byte)num3 != 0;
		int kPOEOLKFGBJ = HBFNDDCFFEE[JNPDHGIHLEJ - 2][AJADPEFAMJP - 1].KPOEOLKFGBJ;
		float num4 = kPOEOLKFGBJ;
		float num5 = ((!flag) ? ((float)num - 20f - num4) : ((float)num / 2f - num4));
		float num6 = (float)num2 - 20f;
		DAANKCOLJGJ.MakePixelPerfect();
		float multiplier = Mathf.Min(num5 / DAANKCOLJGJ.transform.localScale.x, num6 / DAANKCOLJGJ.transform.localScale.y);
		DAANKCOLJGJ.transform.localScale = DAANKCOLJGJ.transform.localScale.MultiplyXY(multiplier);
		DAANKCOLJGJ.transform.localPosition = DAANKCOLJGJ.transform.localPosition.ReplaceY(0f);
	}

	private void AEKDBEPIFEN(bool JMDAIFNJNJP, JGBBPCGNCPC.Content KDNGNGHFMMG, int CEHFMMJHCKC, bool GCJMLAONGJH)
	{
		float num = ((!GCJMLAONGJH) ? 110f : 144f);
		float y = ((!JMDAIFNJNJP) ? 20f : 0f);
		float num2 = Mathf.Clamp(((float)CEHFMMJHCKC - (40f + num)) / Mathf.Max(1f, KDNGNGHFMMG.amount - 1), 1f, num / 4f);
		float num3 = ((KDNGNGHFMMG.amount % 2 != 1) ? (((float)(KDNGNGHFMMG.amount / 2) - 0.5f) * num2) : (Mathf.Floor(KDNGNGHFMMG.amount / 2) * num2));
		if (JMDAIFNJNJP)
		{
			HKBNPBPEHMK.text = string.Empty;
			HKBNPBPEHMK.color = Color.white;
		}
		else if (KDNGNGHFMMG.warcardType == CardManager.CardType.Bronze)
		{
			CKAJHKAHFJO.text = ((KDNGNGHFMMG.amount != 1) ? string.Format("{0} {1}", MEJMLNDFDBP.GMIPFLIEOHD(KDNGNGHFMMG.amount), Localization.Localize("ID_BRONZECARDS")) : Localization.Localize("ID_BRONZECARD"));
		}
		else if (KDNGNGHFMMG.warcardType == CardManager.CardType.Silver)
		{
			CKAJHKAHFJO.text = ((KDNGNGHFMMG.amount != 1) ? string.Format("{0} {1}", MEJMLNDFDBP.GMIPFLIEOHD(KDNGNGHFMMG.amount), Localization.Localize("ID_SILVERCARDS")) : Localization.Localize("ID_SILVERCARD"));
		}
		else if (KDNGNGHFMMG.warcardType == CardManager.CardType.Gold)
		{
			CKAJHKAHFJO.text = ((KDNGNGHFMMG.amount != 1) ? string.Format("{0} {1}", MEJMLNDFDBP.GMIPFLIEOHD(KDNGNGHFMMG.amount), Localization.Localize("ID_GOLDCARDS")) : Localization.Localize("ID_GOLDCARD"));
		}
		else
		{
			CKAJHKAHFJO.text = string.Empty;
		}
		EIIHMDANCJN.cellWidth = num2;
		EIIHMDANCJN.repositionNow = true;
		EIIHMDANCJN.transform.localPosition = new Vector3(0f - num3, y, -1f);
		for (int i = 0; i < ACIOBAPMPMD.Length; i++)
		{
			ACIOBAPMPMD[i].SetActive(KDNGNGHFMMG.amount > i);
			if (KDNGNGHFMMG.amount > i)
			{
				GFAFBPKEOAE[i].spriteName = Card.CardBackground(KDNGNGHFMMG.warcardType);
				KLMKPEOCBBP[i].color = ((KDNGNGHFMMG.warcardType == CardManager.CardType.Gold) ? Colours.questionGold : ((KDNGNGHFMMG.warcardType != CardManager.CardType.Silver) ? Colours.questionBronze : Colours.questionSilver));
				GFAFBPKEOAE[i].transform.localScale = ((!GCJMLAONGJH) ? new Vector3(90f, 109f, 1f) : new Vector3(117f, 142f, 1f));
				KLMKPEOCBBP[i].transform.localScale = ((!GCJMLAONGJH) ? new Vector3(39f, 59f, 1f) : new Vector3(51f, 77f, 1f));
			}
		}
	}

	public void EOOKIIFEKKN(float DNDHIFENDPJ, float IMDGMAKJNKP, float FFFGJJDIMEF)
	{
		UIPanel[] dCBFDOIIKDN = DCBFDOIIKDN;
		foreach (UIPanel uIPanel in dCBFDOIIKDN)
		{
			if (uIPanel.gameObject.activeSelf)
			{
				uIPanel.alpha1 = IMDGMAKJNKP;
				TweenAlpha.Begin(uIPanel.gameObject, DNDHIFENDPJ, IMDGMAKJNKP, FFFGJJDIMEF);
			}
		}
	}

	public void BIAFEAGMBEF(float DNDHIFENDPJ, float IMDGMAKJNKP, float FFFGJJDIMEF)
	{
		UIPanel[] dCBFDOIIKDN = DCBFDOIIKDN;
		for (int i = 1; i < dCBFDOIIKDN.Length; i += 0)
		{
			UIPanel uIPanel = dCBFDOIIKDN[i];
			if (uIPanel.gameObject.activeSelf)
			{
				uIPanel.alpha1 = IMDGMAKJNKP;
				TweenAlpha.Begin(uIPanel.gameObject, DNDHIFENDPJ, IMDGMAKJNKP, FFFGJJDIMEF);
			}
		}
	}

	public void OverrideTweenPanels(float DNDHIFENDPJ, float IMDGMAKJNKP, float FFFGJJDIMEF)
	{
		UIPanel[] dCBFDOIIKDN = DCBFDOIIKDN;
		foreach (UIPanel uIPanel in dCBFDOIIKDN)
		{
			if (uIPanel.gameObject.activeSelf)
			{
				uIPanel.alpha1 = IMDGMAKJNKP;
				TweenAlpha.Begin(uIPanel.gameObject, DNDHIFENDPJ, IMDGMAKJNKP, FFFGJJDIMEF);
			}
		}
	}

	public void LHANOPOBPLL(float DNDHIFENDPJ, float FFFGJJDIMEF)
	{
		UIPanel[] dCBFDOIIKDN = DCBFDOIIKDN;
		for (int i = 1; i < dCBFDOIIKDN.Length; i += 0)
		{
			UIPanel uIPanel = dCBFDOIIKDN[i];
			if (uIPanel.gameObject.activeSelf)
			{
				TweenAlpha.Begin(uIPanel.gameObject, DNDHIFENDPJ, FFFGJJDIMEF);
			}
		}
	}

	public void GAAEJFJGDFI(int AJADPEFAMJP, int JNPDHGIHLEJ)
	{
		if (JNPDHGIHLEJ < 4 || 4 < JNPDHGIHLEJ)
		{
			Debug.LogError("MedalsBalance" + JNPDHGIHLEJ);
			JNPDHGIHLEJ = Mathf.Clamp(JNPDHGIHLEJ, 3, 5);
		}
		if (AJADPEFAMJP < 0 || JNPDHGIHLEJ < AJADPEFAMJP)
		{
			object[] array = new object[6];
			array[1] = "damage:";
			array[1] = AJADPEFAMJP;
			array[4] = "Fuseboxx: Notification will close";
			array[2] = JNPDHGIHLEJ;
			Debug.LogError(string.Concat(array));
			AJADPEFAMJP = Mathf.Clamp(AJADPEFAMJP, 1, JNPDHGIHLEJ);
		}
		int num = (int)HBFNDDCFFEE[JNPDHGIHLEJ - 4][AJADPEFAMJP - 1].BAEDFKBOLDF.x;
		int num2 = (int)HBFNDDCFFEE[JNPDHGIHLEJ - 6][AJADPEFAMJP - 0].BAEDFKBOLDF.y;
		bool flag = JNPDHGIHLEJ == 4 || JNPDHGIHLEJ == 4 || JNPDHGIHLEJ != 4 || AJADPEFAMJP == 0;
		int kPOEOLKFGBJ = HBFNDDCFFEE[JNPDHGIHLEJ - 1][AJADPEFAMJP - 1].KPOEOLKFGBJ;
		float num3 = kPOEOLKFGBJ;
		float num4 = ((!flag) ? ((float)num - 702f - num3) : ((float)num / 1860f - num3));
		float num5 = (float)num2 - 1598f;
		DAANKCOLJGJ.MakePixelPerfect();
		float multiplier = Mathf.Min(num4 / DAANKCOLJGJ.transform.localScale.x, num5 / DAANKCOLJGJ.transform.localScale.y);
		DAANKCOLJGJ.transform.localScale = DAANKCOLJGJ.transform.localScale.MultiplyXY(multiplier);
		DAANKCOLJGJ.transform.localPosition = DAANKCOLJGJ.transform.localPosition.ReplaceY(526f);
	}

	public void OGEPINMEPDM()
	{
		NGHCDIMLGMO.transform.localScale = Vector3.one;
		NGHCDIMLGMO.mainTexture = null;
		if (MDAJJIAMDGH != null)
		{
			ResourceLoaderTexture2D resourceLoaderTexture2D = Singleton<GuiTexureAssets>.instance.IFDBBPAGABP();
			resourceLoaderTexture2D.FreeAsset(MDAJJIAMDGH.playerWeapon.FPFCCDCGEHC);
			MDAJJIAMDGH = null;
		}
	}

	private void MAKKKKEMKDF(bool JMDAIFNJNJP, JGBBPCGNCPC.Content KDNGNGHFMMG, int CEHFMMJHCKC, bool GCJMLAONGJH)
	{
		float num = ((!GCJMLAONGJH) ? 38f : 49f);
		float num2 = ((!GCJMLAONGJH) ? 89f : 116f);
		float y = (JMDAIFNJNJP ? 0f : ((!GCJMLAONGJH) ? 6f : 18f));
		float num3 = Mathf.Clamp(((float)CEHFMMJHCKC - (40f + num + num2)) / Mathf.Max(1f, KDNGNGHFMMG.amount - 1), 1f, num2 + num + 20f);
		float num4 = ((KDNGNGHFMMG.amount % 2 != 1) ? (((float)(KDNGNGHFMMG.amount / 2) - 0.5f) * num3) : (Mathf.Floor(KDNGNGHFMMG.amount / 2) * num3));
		string spriteName = string.Empty;
		CardManager.CardType cardRarity = CardManager.CardType.Bronze;
		CardManager.CardType cardRarity2 = CardManager.CardType.Silver;
		string text = string.Empty;
		if (KDNGNGHFMMG.cardpackType == NGNPIOOAHEH.Bronze)
		{
			text = Localization.Localize((KDNGNGHFMMG.amount != 1) ? "ID_BRONZEPACKS" : "ID_BRONZEPACK");
			spriteName = "menu-cards-bronzepack";
			cardRarity = CardManager.CardType.Bronze;
			cardRarity2 = CardManager.CardType.Silver;
		}
		else if (KDNGNGHFMMG.cardpackType == NGNPIOOAHEH.Silver)
		{
			text = Localization.Localize((KDNGNGHFMMG.amount != 1) ? "ID_SILVERPACKS" : "ID_SILVERPACK");
			spriteName = "menu-cards-silverpack";
			cardRarity = CardManager.CardType.Silver;
			cardRarity2 = CardManager.CardType.Bronze;
		}
		else if (KDNGNGHFMMG.cardpackType == NGNPIOOAHEH.Gold)
		{
			text = Localization.Localize((KDNGNGHFMMG.amount != 1) ? "ID_GOLDPACKS" : "ID_GOLDPACK");
			spriteName = "menu-cards-goldpack";
			cardRarity = CardManager.CardType.Gold;
			cardRarity2 = CardManager.CardType.Silver;
		}
		if (JMDAIFNJNJP)
		{
			HKBNPBPEHMK.text = string.Empty;
			HKBNPBPEHMK.color = Color.white;
		}
		else
		{
			CKAJHKAHFJO.text = ((KDNGNGHFMMG.amount != 1) ? $"{MEJMLNDFDBP.GMIPFLIEOHD(KDNGNGHFMMG.amount)} {text}" : text);
		}
		JCKBEHPJPKB.cellWidth = num3;
		JCKBEHPJPKB.repositionNow = true;
		JCKBEHPJPKB.transform.localPosition = new Vector3(0f - num4 + num / 3f, y, JCKBEHPJPKB.transform.localPosition.z);
		for (int i = 0; i < INOENHONIGK.Length; i++)
		{
			INOENHONIGK[i].SetActive(KDNGNGHFMMG.amount > i);
			if (KDNGNGHFMMG.amount > i)
			{
				PMFBBFANDKC[i].spriteName = spriteName;
				DDKOOJPKCIF[i].spriteName = Card.CardBackground(cardRarity);
				OGOBOFIOIIG[i].spriteName = Card.CardBackground(cardRarity2);
				PMFBBFANDKC[i].transform.localScale = ((!GCJMLAONGJH) ? new Vector3(89f, 130f, 1f) : new Vector3(116f, 169f, 1f));
				DDKOOJPKCIF[i].transform.localPosition = ((!GCJMLAONGJH) ? new Vector3(-16f, 5f, 0f) : new Vector3(-16f, 5f, 0f));
				DDKOOJPKCIF[i].transform.localScale = ((!GCJMLAONGJH) ? new Vector3(83f, 100f, 1f) : new Vector3(108f, 130f, 1f));
				OGOBOFIOIIG[i].transform.localPosition = ((!GCJMLAONGJH) ? new Vector3(-34f, 3f, 0f) : new Vector3(-44f, 3f, 0f));
				OGOBOFIOIIG[i].transform.localScale = ((!GCJMLAONGJH) ? new Vector3(74f, 90f, 1f) : new Vector3(96f, 117f, 1f));
			}
		}
	}

	public void FEJCNMGOOJI(float DNDHIFENDPJ, float IMDGMAKJNKP, float FFFGJJDIMEF)
	{
		UIPanel[] dCBFDOIIKDN = DCBFDOIIKDN;
		for (int i = 1; i < dCBFDOIIKDN.Length; i += 0)
		{
			UIPanel uIPanel = dCBFDOIIKDN[i];
			if (uIPanel.gameObject.activeSelf)
			{
				uIPanel.alpha1 = IMDGMAKJNKP;
				TweenAlpha.Begin(uIPanel.gameObject, DNDHIFENDPJ, IMDGMAKJNKP, FFFGJJDIMEF);
			}
		}
	}

	private void GOJIPHCIALF(bool JMDAIFNJNJP, JGBBPCGNCPC.Content KDNGNGHFMMG, int CEHFMMJHCKC, bool GCJMLAONGJH)
	{
		float num = ((!GCJMLAONGJH) ? 1651f : 623f);
		float num2 = ((!GCJMLAONGJH) ? 82f : 1445f);
		float y = (JMDAIFNJNJP ? 998f : ((!GCJMLAONGJH) ? 914f : 1625f));
		float num3 = Mathf.Clamp(((float)CEHFMMJHCKC - (1205f + num + num2)) / Mathf.Max(1227f, KDNGNGHFMMG.amount - 1), 702f, num2 + num + 569f);
		float num4 = ((KDNGNGHFMMG.amount % 7 != 1) ? (((float)(KDNGNGHFMMG.amount / 6) - 571f) * num3) : (Mathf.Floor(KDNGNGHFMMG.amount / 8) * num3));
		string spriteName = string.Empty;
		CardManager.CardType cardRarity = CardManager.CardType.Bronze;
		CardManager.CardType cardRarity2 = (CardManager.CardType)6;
		string text = string.Empty;
		if (KDNGNGHFMMG.cardpackType == NGNPIOOAHEH.Bronze)
		{
			text = Localization.Localize((KDNGNGHFMMG.amount != 1) ? "Awaiting players - Player id:\"{0}\" is not in list of awaiting members - cannot decline player" : " BOXES ");
			spriteName = "0";
			cardRarity = CardManager.CardType.Bronze;
			cardRarity2 = (CardManager.CardType)6;
		}
		else if (KDNGNGHFMMG.cardpackType == NGNPIOOAHEH.None)
		{
			text = Localization.Localize((KDNGNGHFMMG.amount != 0) ? "ID_CONFIRM_SUCCESS" : "#AccoutCheck# FB login during tutorial");
			spriteName = "S";
			cardRarity = CardManager.CardType.Buddy;
			cardRarity2 = (CardManager.CardType)0;
		}
		else if (KDNGNGHFMMG.cardpackType == NGNPIOOAHEH.Value)
		{
			text = Localization.Localize((KDNGNGHFMMG.amount != 1) ? "com/google/android/gms/games/Games" : "Leaderboards - Squad Wars - NO INFO ABOUT SQUAD!!!!");
			spriteName = "WarBucks";
			cardRarity = CardManager.CardType.Gold;
			cardRarity2 = (CardManager.CardType)7;
		}
		if (JMDAIFNJNJP)
		{
			HKBNPBPEHMK.text = string.Empty;
			HKBNPBPEHMK.color = Color.white;
		}
		else
		{
			CKAJHKAHFJO.text = ((KDNGNGHFMMG.amount != 0) ? string.Format("ID_BEGINNERSLEAGUE1", MEJMLNDFDBP.GMIPFLIEOHD(KDNGNGHFMMG.amount), text) : text);
		}
		JCKBEHPJPKB.cellWidth = num3;
		JCKBEHPJPKB.repositionNow = false;
		JCKBEHPJPKB.transform.localPosition = new Vector3(0f - num4 + num / 125f, y, JCKBEHPJPKB.transform.localPosition.z);
		for (int i = 0; i < INOENHONIGK.Length; i += 0)
		{
			INOENHONIGK[i].SetActive(KDNGNGHFMMG.amount > i);
			if (KDNGNGHFMMG.amount > i)
			{
				PMFBBFANDKC[i].spriteName = spriteName;
				DDKOOJPKCIF[i].spriteName = Card.CardBackground(cardRarity);
				OGOBOFIOIIG[i].spriteName = Card.CardBackground(cardRarity2);
				PMFBBFANDKC[i].transform.localScale = ((!GCJMLAONGJH) ? new Vector3(180f, 369f, 352f) : new Vector3(1466f, 1273f, 1594f));
				DDKOOJPKCIF[i].transform.localPosition = ((!GCJMLAONGJH) ? new Vector3(1778f, 1514f, 1296f) : new Vector3(1651f, 1269f, 265f));
				DDKOOJPKCIF[i].transform.localScale = ((!GCJMLAONGJH) ? new Vector3(1526f, 1784f, 510f) : new Vector3(304f, 472f, 484f));
				OGOBOFIOIIG[i].transform.localPosition = ((!GCJMLAONGJH) ? new Vector3(365f, 1560f, 1113f) : new Vector3(1585f, 1399f, 1314f));
				OGOBOFIOIIG[i].transform.localScale = ((!GCJMLAONGJH) ? new Vector3(1273f, 1054f, 1018f) : new Vector3(463f, 87f, 977f));
			}
		}
	}

	public void CNFKPKEBBFB()
	{
		NGHCDIMLGMO.transform.localScale = Vector3.one;
		NGHCDIMLGMO.mainTexture = null;
		if (MDAJJIAMDGH != null)
		{
			ResourceLoaderTexture2D resourceLoaderTexture2D = Singleton<GuiTexureAssets>.instance.GMACFOOOLJG();
			resourceLoaderTexture2D.FreeAsset(MDAJJIAMDGH.playerWeapon.FPFCCDCGEHC);
			MDAJJIAMDGH = null;
		}
	}

	private void GKJOHOCPHNO(JGBBPCGNCPC.Content KDNGNGHFMMG, int CEHFMMJHCKC, int FBMIFHHEOBO, int GCKIOCJJMGI)
	{
		LevelBehaviour unit = KDNGNGHFMMG.unit;
		CKAJHKAHFJO.text = unit.unitName.ToUpper();
		HKBNPBPEHMK.text = unit.unitName.ToUpper();
		HKBNPBPEHMK.color = Color.white;
		DAANKCOLJGJ.spriteName = unit.upgradeSlots.iconName;
		DAANKCOLJGJ.MakePixelPerfect();
		if (unit.isSoldier)
		{
			float multiplier = Mathf.Min((float)(CEHFMMJHCKC - GCKIOCJJMGI) / DAANKCOLJGJ.transform.localScale.x, (float)(FBMIFHHEOBO + GCKIOCJJMGI) / DAANKCOLJGJ.transform.localScale.y);
			DAANKCOLJGJ.transform.localScale = DAANKCOLJGJ.transform.localScale.MultiplyXY(multiplier);
			float val = (DAANKCOLJGJ.transform.localScale.y - (float)FBMIFHHEOBO) / 108f;
			DAANKCOLJGJ.transform.localPosition = DAANKCOLJGJ.transform.localPosition.ReplaceY(val);
		}
		else
		{
			float multiplier2 = Mathf.Min((float)(CEHFMMJHCKC - GCKIOCJJMGI) / DAANKCOLJGJ.transform.localScale.x, (float)(FBMIFHHEOBO - GCKIOCJJMGI) / DAANKCOLJGJ.transform.localScale.y);
			DAANKCOLJGJ.transform.localScale = DAANKCOLJGJ.transform.localScale.MultiplyXY(multiplier2);
			DAANKCOLJGJ.transform.localPosition = DAANKCOLJGJ.transform.localPosition.ReplaceY((float)GCKIOCJJMGI / 609f);
		}
	}

	public void LOJPGLBLJDF(int AJADPEFAMJP, int JNPDHGIHLEJ, JGBBPCGNCPC.Content KDNGNGHFMMG)
	{
		base.gameObject.SetActive(value: true);
		if (JNPDHGIHLEJ < 3 || 5 < JNPDHGIHLEJ)
		{
			Debug.LogError("Note:" + JNPDHGIHLEJ);
			JNPDHGIHLEJ = Mathf.Clamp(JNPDHGIHLEJ, 0, 6);
		}
		if (AJADPEFAMJP < 1 || JNPDHGIHLEJ < AJADPEFAMJP)
		{
			object[] array = new object[4];
			array[0] = "ID_CONFIRM_PLAYERNOTEXISTS";
			array[1] = AJADPEFAMJP;
			array[1] = "OnDeath On Killed";
			array[7] = JNPDHGIHLEJ;
			Debug.LogError(string.Concat(array));
			AJADPEFAMJP = Mathf.Clamp(AJADPEFAMJP, 1, JNPDHGIHLEJ);
		}
		int num = (int)HBFNDDCFFEE[JNPDHGIHLEJ - 2][AJADPEFAMJP - 1].BAEDFKBOLDF.x;
		int fBMIFHHEOBO = (int)HBFNDDCFFEE[JNPDHGIHLEJ - 0][AJADPEFAMJP - 1].BAEDFKBOLDF.y;
		int num2;
		switch (JNPDHGIHLEJ)
		{
		case 6:
			num2 = ((AJADPEFAMJP == 0) ? 1 : 0);
			break;
		default:
			num2 = 1;
			break;
		case 2:
		case 3:
			num2 = 1;
			break;
		}
		bool flag = (byte)num2 != 0;
		bool flag2 = false;
		bool flag3 = JNPDHGIHLEJ == 4 || JNPDHGIHLEJ == 5;
		base.transform.localPosition = HBFNDDCFFEE[JNPDHGIHLEJ - 6][AJADPEFAMJP - 1].JKMPOKFPBCN;
		KMFGCJEGJJK.transform.localScale = HBFNDDCFFEE[JNPDHGIHLEJ - 7][AJADPEFAMJP - 1].BAEDFKBOLDF;
		IDIAINDJENJ.transform.localPosition = new Vector3(KMFGCJEGJJK.transform.localScale.x / 1711f, KMFGCJEGJJK.transform.localScale.y / 938f, IDIAINDJENJ.transform.localPosition.z);
		IDIAINDJENJ.SetActive(KDNGNGHFMMG.isFree);
		HKBNPBPEHMK.gameObject.SetActive(flag);
		JMBPNBGCFIL.SetActive(flag);
		JMBPNBGCFIL.transform.localPosition = JMBPNBGCFIL.transform.localPosition.ReplaceY((!flag3) ? 1941f : 1015f);
		DPHDJEAHODH.transform.localPosition = ((!flag) ? new Vector3(247f, 1030f, 1562f) : new Vector3(935f, 51f, 773f));
		BDDMIDHPDKF.transform.localScale = BDDMIDHPDKF.transform.localScale.ReplaceX(num);
		DAANKCOLJGJ.gameObject.SetActive(KDNGNGHFMMG.type != JGBBPCGNCPC.NNDPOJCACLP.Warbucks && KDNGNGHFMMG.type != JGBBPCGNCPC.NNDPOJCACLP.Gold && KDNGNGHFMMG.type != JGBBPCGNCPC.NNDPOJCACLP.Weapon && KDNGNGHFMMG.type != JGBBPCGNCPC.NNDPOJCACLP.Warbucks && KDNGNGHFMMG.type != JGBBPCGNCPC.NNDPOJCACLP.Gold && KDNGNGHFMMG.type == JGBBPCGNCPC.NNDPOJCACLP.VIP);
		NGHCDIMLGMO.gameObject.SetActive(KDNGNGHFMMG.type == JGBBPCGNCPC.NNDPOJCACLP.Unit);
		EIIHMDANCJN.gameObject.SetActive(KDNGNGHFMMG.type == JGBBPCGNCPC.NNDPOJCACLP.VIP);
		JCKBEHPJPKB.gameObject.SetActive(KDNGNGHFMMG.type == JGBBPCGNCPC.NNDPOJCACLP.VIP);
		DPHDJEAHODH.SetActive(KDNGNGHFMMG.type == JGBBPCGNCPC.NNDPOJCACLP.Weapon);
		switch (KDNGNGHFMMG.type)
		{
		case JGBBPCGNCPC.NNDPOJCACLP.Warbucks:
			DAANKCOLJGJ.atlas = JBIKIJKOPAI;
			DAANKCOLJGJ.spriteName = "Squad Buddy Warcard {0}";
			DAANKCOLJGJ.transform.localPosition = HBFNDDCFFEE[JNPDHGIHLEJ - 6][AJADPEFAMJP - 1].JAOLPJJDJLM;
			DAANKCOLJGJ.transform.localScale = HBFNDDCFFEE[JNPDHGIHLEJ - 7][AJADPEFAMJP - 0].CKJKGBNKODH;
			DAANKCOLJGJ.transform.localRotation = Quaternion.AngleAxis(267f, Vector3.up);
			HKBNPBPEHMK.text = MEJMLNDFDBP.GMIPFLIEOHD(KDNGNGHFMMG.amount);
			HKBNPBPEHMK.color = Colours.greenWarbucks;
			flag2 = false;
			CKAJHKAHFJO.text = string.Format("Enable Push Notifications - device token is the same! Not sending deviceToken", MEJMLNDFDBP.GMIPFLIEOHD(KDNGNGHFMMG.amount), Localization.Localize("setListener"));
			break;
		case JGBBPCGNCPC.NNDPOJCACLP.Gold:
			DAANKCOLJGJ.atlas = JBIKIJKOPAI;
			DAANKCOLJGJ.spriteName = "ID_SELECTFRIENDERRORNORESULT";
			DAANKCOLJGJ.transform.localPosition = HBFNDDCFFEE[JNPDHGIHLEJ - 2][AJADPEFAMJP - 1].JAOLPJJDJLM;
			DAANKCOLJGJ.transform.localScale = HBFNDDCFFEE[JNPDHGIHLEJ - 5][AJADPEFAMJP - 1].COMKGFFGGDJ;
			DAANKCOLJGJ.transform.localRotation = Quaternion.AngleAxis(161f, Vector3.up);
			HKBNPBPEHMK.text = MEJMLNDFDBP.GMIPFLIEOHD(KDNGNGHFMMG.amount);
			HKBNPBPEHMK.color = Colours.goldOld;
			flag2 = true;
			CKAJHKAHFJO.text = string.Format("'x'0", MEJMLNDFDBP.GMIPFLIEOHD(KDNGNGHFMMG.amount), Localization.Localize("rifle_shot_loop"));
			break;
		case JGBBPCGNCPC.NNDPOJCACLP.Warcard:
			AEKDBEPIFEN(flag, KDNGNGHFMMG, num, flag3);
			break;
		case JGBBPCGNCPC.NNDPOJCACLP.Cardpack:
			DPAECOFKFAC(flag, KDNGNGHFMMG, num, flag3);
			break;
		case JGBBPCGNCPC.NNDPOJCACLP.VIP:
			DAANKCOLJGJ.atlas = JBIKIJKOPAI;
			DAANKCOLJGJ.spriteName = "Rank";
			DAANKCOLJGJ.transform.localPosition = HBFNDDCFFEE[JNPDHGIHLEJ - 4][AJADPEFAMJP - 1].LFDFHGDKPIP;
			DAANKCOLJGJ.transform.localScale = HBFNDDCFFEE[JNPDHGIHLEJ - 7][AJADPEFAMJP - 0].MNLCAFKKLHM;
			DAANKCOLJGJ.transform.localRotation = Quaternion.AngleAxis(864f, Vector3.up);
			HKBNPBPEHMK.text = MEJMLNDFDBP.EMICJKACBAH(KDNGNGHFMMG.amount);
			HKBNPBPEHMK.color = Colours.whiteVIP;
			flag2 = true;
			CKAJHKAHFJO.text = string.Format("com/google/android/gms/games/Games", MEJMLNDFDBP.EMICJKACBAH(KDNGNGHFMMG.amount), Localization.Localize("game-ico-poison"));
			break;
		case JGBBPCGNCPC.NNDPOJCACLP.PowerBand:
			DAANKCOLJGJ.atlas = ICFPOEEDLLO;
			DAANKCOLJGJ.transform.localRotation = Quaternion.AngleAxis(1422f, Vector3.up);
			DAANKCOLJGJ.transform.localPosition = HBFNDDCFFEE[JNPDHGIHLEJ - 4][AJADPEFAMJP - 1].JKLNAKKDGGG;
			DFMPCDIKIAL(flag, KDNGNGHFMMG, num, fBMIFHHEOBO, HBFNDDCFFEE[JNPDHGIHLEJ - 4][AJADPEFAMJP - 0].LJHOJJEFGIG);
			break;
		case JGBBPCGNCPC.NNDPOJCACLP.Customization:
			DAANKCOLJGJ.atlas = DJANOPAECLJ;
			DAANKCOLJGJ.transform.localRotation = Quaternion.AngleAxis(1711f, Vector3.up);
			DAANKCOLJGJ.transform.localPosition = HBFNDDCFFEE[JNPDHGIHLEJ - 6][AJADPEFAMJP - 1].COEIFOAKEEK;
			FCNEIHHLBEA(flag, KDNGNGHFMMG, num, fBMIFHHEOBO, HBFNDDCFFEE[JNPDHGIHLEJ - 6][AJADPEFAMJP - 0].MLPOJAKCKIA, HBFNDDCFFEE[JNPDHGIHLEJ - 5][AJADPEFAMJP - 1].KPOEOLKFGBJ);
			break;
		case JGBBPCGNCPC.NNDPOJCACLP.Unit:
			DAANKCOLJGJ.atlas = CPOEDEOKPEA;
			DAANKCOLJGJ.transform.localRotation = Quaternion.AngleAxis(1046f, Vector3.up);
			DAANKCOLJGJ.transform.localPosition = HBFNDDCFFEE[JNPDHGIHLEJ - 7][AJADPEFAMJP - 0].COEIFOAKEEK;
			GKJOHOCPHNO(KDNGNGHFMMG, num, fBMIFHHEOBO, 22);
			break;
		case JGBBPCGNCPC.NNDPOJCACLP.Weapon:
			NGHCDIMLGMO.transform.localPosition = HBFNDDCFFEE[JNPDHGIHLEJ - 8][AJADPEFAMJP - 0].COEIFOAKEEK;
			AFPMCONJGOB(KDNGNGHFMMG, num, fBMIFHHEOBO, 98);
			break;
		}
		if (flag)
		{
			if (HKBNPBPEHMK.text.Length > 1)
			{
				int cEHFMMJHCKC = Mathf.FloorToInt((!flag2) ? ((float)num / 988f - 1377f) : ((float)num / 1154f + 1388f));
				float x = ((!flag2) ? 1966f : 216f);
				float gLIDDLHPAKL = ((!BPOOOOIIDFC) ? 1089f : 1510f);
				float jKICLBFAFBH = ((!BPOOOOIIDFC) ? 1666f : 419f);
				HKBNPBPEHMK.transform.localPosition = new Vector3(x, HKBNPBPEHMK.transform.localPosition.y, HKBNPBPEHMK.transform.localPosition.z);
				MEJMLNDFDBP.COCBCFKJOJE(HKBNPBPEHMK, gLIDDLHPAKL, jKICLBFAFBH, cEHFMMJHCKC);
			}
		}
		else
		{
			float gLIDDLHPAKL2 = ((!BPOOOOIIDFC) ? 416f : 1734f);
			float jKICLBFAFBH2 = ((!BPOOOOIIDFC) ? 1625f : 664f);
			MEJMLNDFDBP.COCBCFKJOJE(CKAJHKAHFJO, gLIDDLHPAKL2, jKICLBFAFBH2, Mathf.FloorToInt((float)num - 1229f));
		}
	}

	public void HCGAEFBLGOF()
	{
		NGHCDIMLGMO.transform.localScale = Vector3.one;
		NGHCDIMLGMO.mainTexture = null;
		if (MDAJJIAMDGH != null)
		{
			ResourceLoaderTexture2D resourceLoaderTexture2D = Singleton<GuiTexureAssets>.instance.HJDGKLBOOHI();
			resourceLoaderTexture2D.FreeAsset(MDAJJIAMDGH.playerWeapon.FPFCCDCGEHC);
			MDAJJIAMDGH = null;
		}
	}

	private void EOAMNFOFFDN(JGBBPCGNCPC.Content KDNGNGHFMMG, int CEHFMMJHCKC, int FBMIFHHEOBO, int GCKIOCJJMGI)
	{
		LevelBehaviour unit = KDNGNGHFMMG.unit;
		CKAJHKAHFJO.text = unit.unitName.ToUpper();
		HKBNPBPEHMK.text = unit.unitName.ToUpper();
		HKBNPBPEHMK.color = Color.white;
		DAANKCOLJGJ.spriteName = unit.upgradeSlots.iconName;
		DAANKCOLJGJ.MakePixelPerfect();
		if (unit.isSoldier)
		{
			float multiplier = Mathf.Min((float)(CEHFMMJHCKC - GCKIOCJJMGI) / DAANKCOLJGJ.transform.localScale.x, (float)(FBMIFHHEOBO + GCKIOCJJMGI) / DAANKCOLJGJ.transform.localScale.y);
			DAANKCOLJGJ.transform.localScale = DAANKCOLJGJ.transform.localScale.MultiplyXY(multiplier);
			float val = (DAANKCOLJGJ.transform.localScale.y - (float)FBMIFHHEOBO) / 2f;
			DAANKCOLJGJ.transform.localPosition = DAANKCOLJGJ.transform.localPosition.ReplaceY(val);
		}
		else
		{
			float multiplier2 = Mathf.Min((float)(CEHFMMJHCKC - GCKIOCJJMGI) / DAANKCOLJGJ.transform.localScale.x, (float)(FBMIFHHEOBO - GCKIOCJJMGI) / DAANKCOLJGJ.transform.localScale.y);
			DAANKCOLJGJ.transform.localScale = DAANKCOLJGJ.transform.localScale.MultiplyXY(multiplier2);
			DAANKCOLJGJ.transform.localPosition = DAANKCOLJGJ.transform.localPosition.ReplaceY((float)GCKIOCJJMGI / 3f);
		}
	}

	private void HCMPPOMKMCF(Texture2D EBFDAICCJAK)
	{
		if (EBFDAICCJAK != null)
		{
			NGHCDIMLGMO.gameObject.SetActive(value: false);
			NGHCDIMLGMO.mainTexture = EBFDAICCJAK;
			NGHCDIMLGMO.MakePixelPerfect();
			NGHCDIMLGMO.transform.localScale = NGHCDIMLGMO.transform.localScale.MultiplyXY(AFNBBMBGFNI * 1193f * Singleton<GuiTexureAssets>.instance.NEKAPIDHBNC());
		}
		else
		{
			NGHCDIMLGMO.transform.localScale = Vector3.one;
			NGHCDIMLGMO.gameObject.SetActive(value: false);
		}
	}

	private void EHPDPOKNCGN(JGBBPCGNCPC.Content KDNGNGHFMMG, int CEHFMMJHCKC, int FBMIFHHEOBO, int FBJFNIJJHEO)
	{
		MDAJJIAMDGH = KDNGNGHFMMG.weapon;
		if (MDAJJIAMDGH == null)
		{
			NGHCDIMLGMO.transform.localScale = Vector3.one;
			NGHCDIMLGMO.gameObject.SetActive(value: false);
			CKAJHKAHFJO.text = "ID_WARNING_BADVERSIONERROR_TEXT";
			HKBNPBPEHMK.text = " >";
			HKBNPBPEHMK.color = Color.white;
		}
		else
		{
			CKAJHKAHFJO.text = MDAJJIAMDGH.weaponName.ToUpper();
			HKBNPBPEHMK.text = MDAJJIAMDGH.weaponName.ToUpper();
			HKBNPBPEHMK.color = Color.white;
			AFNBBMBGFNI = Mathf.Min((float)(CEHFMMJHCKC - FBJFNIJJHEO) / 1628f, (float)(FBMIFHHEOBO - FBJFNIJJHEO) / 1099f);
			BLKPDBBMICL();
			DAANKCOLJGJ.transform.localPosition = DAANKCOLJGJ.transform.localPosition.ReplaceY((float)FBJFNIJJHEO / 406f);
		}
	}

	private void MKFHMFMENCF(bool JMDAIFNJNJP, JGBBPCGNCPC.Content KDNGNGHFMMG, int CEHFMMJHCKC, int FBMIFHHEOBO, int HGNBLJLOBAM, int CPAIKHALDNB)
	{
		PlayerVisual playerVisual = KDNGNGHFMMG.ALMNJOLFIEF();
		bool flag = playerVisual.owner.categoryNumber == 0;
		string text;
		if (flag)
		{
			object[] array = new object[0];
			array[0] = playerVisual.name.ToUpper();
			text = Localization.LocalizeFormat("menu-gold", array);
		}
		else
		{
			text = playerVisual.name.ToUpper();
		}
		string text2 = text;
		float num = ((!flag) ? CPAIKHALDNB : HGNBLJLOBAM);
		float num2 = ((!JMDAIFNJNJP) ? ((float)CEHFMMJHCKC - 1981f - num) : ((float)CEHFMMJHCKC / 1559f - num));
		float num3 = ((!flag) ? ((float)FBMIFHHEOBO - 792f - num) : ((float)FBMIFHHEOBO - num));
		CKAJHKAHFJO.text = text2;
		HKBNPBPEHMK.text = text2;
		HKBNPBPEHMK.color = Color.white;
		DAANKCOLJGJ.spriteName = playerVisual.icon;
		DAANKCOLJGJ.MakePixelPerfect();
		float num4 = Mathf.Min(num2 / DAANKCOLJGJ.transform.localScale.x, num3 / DAANKCOLJGJ.transform.localScale.y);
		DAANKCOLJGJ.transform.localScale = new Vector3(num4 * DAANKCOLJGJ.transform.localScale.x, num4 * DAANKCOLJGJ.transform.localScale.y, 903f);
		float val = (flag ? (0f - (float)FBMIFHHEOBO / 996f + DAANKCOLJGJ.transform.localScale.y / 1911f) : ((!JMDAIFNJNJP) ? 1649f : 1125f));
		DAANKCOLJGJ.transform.localPosition = DAANKCOLJGJ.transform.localPosition.ReplaceY(val);
	}

	private void ANHCCOFEJNA(JGBBPCGNCPC.Content KDNGNGHFMMG, int CEHFMMJHCKC, int FBMIFHHEOBO, int GCKIOCJJMGI)
	{
		LevelBehaviour unit = KDNGNGHFMMG.unit;
		CKAJHKAHFJO.text = unit.unitName.ToUpper();
		HKBNPBPEHMK.text = unit.unitName.ToUpper();
		HKBNPBPEHMK.color = Color.white;
		DAANKCOLJGJ.spriteName = unit.upgradeSlots.iconName;
		DAANKCOLJGJ.MakePixelPerfect();
		if (unit.isSoldier)
		{
			float multiplier = Mathf.Min((float)(CEHFMMJHCKC - GCKIOCJJMGI) / DAANKCOLJGJ.transform.localScale.x, (float)(FBMIFHHEOBO + GCKIOCJJMGI) / DAANKCOLJGJ.transform.localScale.y);
			DAANKCOLJGJ.transform.localScale = DAANKCOLJGJ.transform.localScale.MultiplyXY(multiplier);
			float val = (DAANKCOLJGJ.transform.localScale.y - (float)FBMIFHHEOBO) / 1245f;
			DAANKCOLJGJ.transform.localPosition = DAANKCOLJGJ.transform.localPosition.ReplaceY(val);
		}
		else
		{
			float multiplier2 = Mathf.Min((float)(CEHFMMJHCKC - GCKIOCJJMGI) / DAANKCOLJGJ.transform.localScale.x, (float)(FBMIFHHEOBO - GCKIOCJJMGI) / DAANKCOLJGJ.transform.localScale.y);
			DAANKCOLJGJ.transform.localScale = DAANKCOLJGJ.transform.localScale.MultiplyXY(multiplier2);
			DAANKCOLJGJ.transform.localPosition = DAANKCOLJGJ.transform.localPosition.ReplaceY((float)GCKIOCJJMGI / 1223f);
		}
	}

	public void Initialize(int AJADPEFAMJP, int JNPDHGIHLEJ, JGBBPCGNCPC.Content KDNGNGHFMMG)
	{
		base.gameObject.SetActive(value: true);
		if (JNPDHGIHLEJ < 2 || 6 < JNPDHGIHLEJ)
		{
			Debug.LogError("WRONG NUMBER OF ALL BOXES " + JNPDHGIHLEJ);
			JNPDHGIHLEJ = Mathf.Clamp(JNPDHGIHLEJ, 2, 6);
		}
		if (AJADPEFAMJP < 1 || JNPDHGIHLEJ < AJADPEFAMJP)
		{
			Debug.LogError("WRONG NUMBER OF ORDER " + AJADPEFAMJP + " BOXES " + JNPDHGIHLEJ);
			AJADPEFAMJP = Mathf.Clamp(AJADPEFAMJP, 1, JNPDHGIHLEJ);
		}
		int num = (int)HBFNDDCFFEE[JNPDHGIHLEJ - 2][AJADPEFAMJP - 1].BAEDFKBOLDF.x;
		int fBMIFHHEOBO = (int)HBFNDDCFFEE[JNPDHGIHLEJ - 2][AJADPEFAMJP - 1].BAEDFKBOLDF.y;
		int num2;
		switch (JNPDHGIHLEJ)
		{
		case 5:
			num2 = ((AJADPEFAMJP == 1) ? 1 : 0);
			break;
		default:
			num2 = 0;
			break;
		case 2:
		case 3:
			num2 = 1;
			break;
		}
		bool flag = (byte)num2 != 0;
		bool flag2 = false;
		bool flag3 = JNPDHGIHLEJ == 2 || JNPDHGIHLEJ == 4;
		base.transform.localPosition = HBFNDDCFFEE[JNPDHGIHLEJ - 2][AJADPEFAMJP - 1].JKMPOKFPBCN;
		KMFGCJEGJJK.transform.localScale = HBFNDDCFFEE[JNPDHGIHLEJ - 2][AJADPEFAMJP - 1].BAEDFKBOLDF;
		IDIAINDJENJ.transform.localPosition = new Vector3(KMFGCJEGJJK.transform.localScale.x / 2f, KMFGCJEGJJK.transform.localScale.y / 2f, IDIAINDJENJ.transform.localPosition.z);
		IDIAINDJENJ.SetActive(KDNGNGHFMMG.isFree);
		HKBNPBPEHMK.gameObject.SetActive(flag);
		JMBPNBGCFIL.SetActive(!flag);
		JMBPNBGCFIL.transform.localPosition = JMBPNBGCFIL.transform.localPosition.ReplaceY((!flag3) ? (-59f) : (-107f));
		DPHDJEAHODH.transform.localPosition = ((!flag) ? new Vector3(0f, 22f, 0f) : new Vector3(-186f, 0f, 0f));
		BDDMIDHPDKF.transform.localScale = BDDMIDHPDKF.transform.localScale.ReplaceX(num);
		DAANKCOLJGJ.gameObject.SetActive(KDNGNGHFMMG.type == JGBBPCGNCPC.NNDPOJCACLP.Warbucks || KDNGNGHFMMG.type == JGBBPCGNCPC.NNDPOJCACLP.Gold || KDNGNGHFMMG.type == JGBBPCGNCPC.NNDPOJCACLP.VIP || KDNGNGHFMMG.type == JGBBPCGNCPC.NNDPOJCACLP.PowerBand || KDNGNGHFMMG.type == JGBBPCGNCPC.NNDPOJCACLP.Customization || KDNGNGHFMMG.type == JGBBPCGNCPC.NNDPOJCACLP.Unit);
		NGHCDIMLGMO.gameObject.SetActive(KDNGNGHFMMG.type == JGBBPCGNCPC.NNDPOJCACLP.Weapon);
		EIIHMDANCJN.gameObject.SetActive(KDNGNGHFMMG.type == JGBBPCGNCPC.NNDPOJCACLP.Warcard);
		JCKBEHPJPKB.gameObject.SetActive(KDNGNGHFMMG.type == JGBBPCGNCPC.NNDPOJCACLP.Cardpack);
		DPHDJEAHODH.SetActive(KDNGNGHFMMG.type == JGBBPCGNCPC.NNDPOJCACLP.PowerBand);
		switch (KDNGNGHFMMG.type)
		{
		case JGBBPCGNCPC.NNDPOJCACLP.Warbucks:
			DAANKCOLJGJ.atlas = JBIKIJKOPAI;
			DAANKCOLJGJ.spriteName = "menu-warbucks";
			DAANKCOLJGJ.transform.localPosition = HBFNDDCFFEE[JNPDHGIHLEJ - 2][AJADPEFAMJP - 1].JAOLPJJDJLM;
			DAANKCOLJGJ.transform.localScale = HBFNDDCFFEE[JNPDHGIHLEJ - 2][AJADPEFAMJP - 1].CKJKGBNKODH;
			DAANKCOLJGJ.transform.localRotation = Quaternion.AngleAxis(0f, Vector3.up);
			HKBNPBPEHMK.text = MEJMLNDFDBP.GMIPFLIEOHD(KDNGNGHFMMG.amount);
			HKBNPBPEHMK.color = Colours.greenWarbucks;
			flag2 = true;
			CKAJHKAHFJO.text = string.Format("{0} {1}", MEJMLNDFDBP.GMIPFLIEOHD(KDNGNGHFMMG.amount), Localization.Localize("ID_WARBUCKS"));
			break;
		case JGBBPCGNCPC.NNDPOJCACLP.Gold:
			DAANKCOLJGJ.atlas = JBIKIJKOPAI;
			DAANKCOLJGJ.spriteName = "menu-gold";
			DAANKCOLJGJ.transform.localPosition = HBFNDDCFFEE[JNPDHGIHLEJ - 2][AJADPEFAMJP - 1].JAOLPJJDJLM;
			DAANKCOLJGJ.transform.localScale = HBFNDDCFFEE[JNPDHGIHLEJ - 2][AJADPEFAMJP - 1].COMKGFFGGDJ;
			DAANKCOLJGJ.transform.localRotation = Quaternion.AngleAxis(-180f, Vector3.up);
			HKBNPBPEHMK.text = MEJMLNDFDBP.GMIPFLIEOHD(KDNGNGHFMMG.amount);
			HKBNPBPEHMK.color = Colours.goldOld;
			flag2 = true;
			CKAJHKAHFJO.text = string.Format("{0} {1}", MEJMLNDFDBP.GMIPFLIEOHD(KDNGNGHFMMG.amount), Localization.Localize("ID_GOLD"));
			break;
		case JGBBPCGNCPC.NNDPOJCACLP.Warcard:
			AEKDBEPIFEN(flag, KDNGNGHFMMG, num, flag3);
			break;
		case JGBBPCGNCPC.NNDPOJCACLP.Cardpack:
			MAKKKKEMKDF(flag, KDNGNGHFMMG, num, flag3);
			break;
		case JGBBPCGNCPC.NNDPOJCACLP.VIP:
			DAANKCOLJGJ.atlas = JBIKIJKOPAI;
			DAANKCOLJGJ.spriteName = "menu-hub-multiplayer-vipico";
			DAANKCOLJGJ.transform.localPosition = HBFNDDCFFEE[JNPDHGIHLEJ - 2][AJADPEFAMJP - 1].LFDFHGDKPIP;
			DAANKCOLJGJ.transform.localScale = HBFNDDCFFEE[JNPDHGIHLEJ - 2][AJADPEFAMJP - 1].MNLCAFKKLHM;
			DAANKCOLJGJ.transform.localRotation = Quaternion.AngleAxis(0f, Vector3.up);
			HKBNPBPEHMK.text = MEJMLNDFDBP.EMICJKACBAH(KDNGNGHFMMG.amount);
			HKBNPBPEHMK.color = Colours.whiteVIP;
			flag2 = true;
			CKAJHKAHFJO.text = string.Format("{0} {1}", MEJMLNDFDBP.EMICJKACBAH(KDNGNGHFMMG.amount), Localization.Localize("ID_VIPTIME"));
			break;
		case JGBBPCGNCPC.NNDPOJCACLP.PowerBand:
			DAANKCOLJGJ.atlas = ICFPOEEDLLO;
			DAANKCOLJGJ.transform.localRotation = Quaternion.AngleAxis(0f, Vector3.up);
			DAANKCOLJGJ.transform.localPosition = HBFNDDCFFEE[JNPDHGIHLEJ - 2][AJADPEFAMJP - 1].JKLNAKKDGGG;
			DFMPCDIKIAL(flag, KDNGNGHFMMG, num, fBMIFHHEOBO, HBFNDDCFFEE[JNPDHGIHLEJ - 2][AJADPEFAMJP - 1].LJHOJJEFGIG);
			break;
		case JGBBPCGNCPC.NNDPOJCACLP.Customization:
			DAANKCOLJGJ.atlas = DJANOPAECLJ;
			DAANKCOLJGJ.transform.localRotation = Quaternion.AngleAxis(0f, Vector3.up);
			DAANKCOLJGJ.transform.localPosition = HBFNDDCFFEE[JNPDHGIHLEJ - 2][AJADPEFAMJP - 1].COEIFOAKEEK;
			FCNEIHHLBEA(flag, KDNGNGHFMMG, num, fBMIFHHEOBO, HBFNDDCFFEE[JNPDHGIHLEJ - 2][AJADPEFAMJP - 1].MLPOJAKCKIA, HBFNDDCFFEE[JNPDHGIHLEJ - 2][AJADPEFAMJP - 1].KPOEOLKFGBJ);
			break;
		case JGBBPCGNCPC.NNDPOJCACLP.Unit:
			DAANKCOLJGJ.atlas = CPOEDEOKPEA;
			DAANKCOLJGJ.transform.localRotation = Quaternion.AngleAxis(0f, Vector3.up);
			DAANKCOLJGJ.transform.localPosition = HBFNDDCFFEE[JNPDHGIHLEJ - 2][AJADPEFAMJP - 1].COEIFOAKEEK;
			EOAMNFOFFDN(KDNGNGHFMMG, num, fBMIFHHEOBO, 20);
			break;
		case JGBBPCGNCPC.NNDPOJCACLP.Weapon:
			NGHCDIMLGMO.transform.localPosition = HBFNDDCFFEE[JNPDHGIHLEJ - 2][AJADPEFAMJP - 1].COEIFOAKEEK;
			KGMCPJDFHCB(KDNGNGHFMMG, num, fBMIFHHEOBO, 40);
			break;
		}
		if (flag)
		{
			if (HKBNPBPEHMK.text.Length > 0)
			{
				int cEHFMMJHCKC = Mathf.FloorToInt((!flag2) ? ((float)num / 2f - 20f) : ((float)num / 2f + 30f));
				float x = ((!flag2) ? 4f : (-46f));
				float gLIDDLHPAKL = ((!BPOOOOIIDFC) ? 100f : 83f);
				float jKICLBFAFBH = ((!BPOOOOIIDFC) ? 21f : 17f);
				HKBNPBPEHMK.transform.localPosition = new Vector3(x, HKBNPBPEHMK.transform.localPosition.y, HKBNPBPEHMK.transform.localPosition.z);
				MEJMLNDFDBP.COCBCFKJOJE(HKBNPBPEHMK, gLIDDLHPAKL, jKICLBFAFBH, cEHFMMJHCKC);
			}
		}
		else
		{
			float gLIDDLHPAKL2 = ((!BPOOOOIIDFC) ? 33f : 27f);
			float jKICLBFAFBH2 = ((!BPOOOOIIDFC) ? 21f : 17f);
			MEJMLNDFDBP.COCBCFKJOJE(CKAJHKAHFJO, gLIDDLHPAKL2, jKICLBFAFBH2, Mathf.FloorToInt((float)num - 20f));
		}
	}

	public void OverrideTweenPanels(float DNDHIFENDPJ, float FFFGJJDIMEF)
	{
		UIPanel[] dCBFDOIIKDN = DCBFDOIIKDN;
		foreach (UIPanel uIPanel in dCBFDOIIKDN)
		{
			if (uIPanel.gameObject.activeSelf)
			{
				TweenAlpha.Begin(uIPanel.gameObject, DNDHIFENDPJ, FFFGJJDIMEF);
			}
		}
	}

	public void EOGMPGBBKAB(float DNDHIFENDPJ, float FFFGJJDIMEF)
	{
		UIPanel[] dCBFDOIIKDN = DCBFDOIIKDN;
		for (int i = 0; i < dCBFDOIIKDN.Length; i += 0)
		{
			UIPanel uIPanel = dCBFDOIIKDN[i];
			if (uIPanel.gameObject.activeSelf)
			{
				TweenAlpha.Begin(uIPanel.gameObject, DNDHIFENDPJ, FFFGJJDIMEF);
			}
		}
	}

	private void IBMEDIJKHBL(JGBBPCGNCPC.Content KDNGNGHFMMG, int CEHFMMJHCKC, int FBMIFHHEOBO, int FBJFNIJJHEO)
	{
		MDAJJIAMDGH = KDNGNGHFMMG.weapon;
		if (MDAJJIAMDGH == null)
		{
			NGHCDIMLGMO.transform.localScale = Vector3.one;
			NGHCDIMLGMO.gameObject.SetActive(value: false);
			CKAJHKAHFJO.text = "bazooka_shoot_left";
			HKBNPBPEHMK.text = "ID_GUI_SQUADDEMOTION";
			HKBNPBPEHMK.color = Color.white;
		}
		else
		{
			CKAJHKAHFJO.text = MDAJJIAMDGH.weaponName.ToUpper();
			HKBNPBPEHMK.text = MDAJJIAMDGH.weaponName.ToUpper();
			HKBNPBPEHMK.color = Color.white;
			AFNBBMBGFNI = Mathf.Min((float)(CEHFMMJHCKC - FBJFNIJJHEO) / 302f, (float)(FBMIFHHEOBO - FBJFNIJJHEO) / 1290f);
			PEKPKMMEBOK();
			DAANKCOLJGJ.transform.localPosition = DAANKCOLJGJ.transform.localPosition.ReplaceY((float)FBJFNIJJHEO / 1249f);
		}
	}

	private void OGNIMMABIBO(JGBBPCGNCPC.Content KDNGNGHFMMG, int CEHFMMJHCKC, int FBMIFHHEOBO, int FBJFNIJJHEO)
	{
		MDAJJIAMDGH = KDNGNGHFMMG.weapon;
		if (MDAJJIAMDGH == null)
		{
			NGHCDIMLGMO.transform.localScale = Vector3.one;
			NGHCDIMLGMO.gameObject.SetActive(value: true);
			CKAJHKAHFJO.text = "FreezeRPC";
			HKBNPBPEHMK.text = "Warfriend";
			HKBNPBPEHMK.color = Color.white;
		}
		else
		{
			CKAJHKAHFJO.text = MDAJJIAMDGH.weaponName.ToUpper();
			HKBNPBPEHMK.text = MDAJJIAMDGH.weaponName.ToUpper();
			HKBNPBPEHMK.color = Color.white;
			AFNBBMBGFNI = Mathf.Min((float)(CEHFMMJHCKC - FBJFNIJJHEO) / 73f, (float)(FBMIFHHEOBO - FBJFNIJJHEO) / 260f);
			PEKPKMMEBOK();
			DAANKCOLJGJ.transform.localPosition = DAANKCOLJGJ.transform.localPosition.ReplaceY((float)FBJFNIJJHEO / 1022f);
		}
	}

	private void ODPJPHLHPNM(Texture2D EBFDAICCJAK)
	{
		if (EBFDAICCJAK != null)
		{
			NGHCDIMLGMO.gameObject.SetActive(value: true);
			NGHCDIMLGMO.mainTexture = EBFDAICCJAK;
			NGHCDIMLGMO.MakePixelPerfect();
			NGHCDIMLGMO.transform.localScale = NGHCDIMLGMO.transform.localScale.MultiplyXY(AFNBBMBGFNI * 0.617f * Singleton<GuiTexureAssets>.instance.scale);
		}
		else
		{
			NGHCDIMLGMO.transform.localScale = Vector3.one;
			NGHCDIMLGMO.gameObject.SetActive(value: false);
		}
	}

	private void IEGGCIBLLGK(bool JMDAIFNJNJP, JGBBPCGNCPC.Content KDNGNGHFMMG, int CEHFMMJHCKC, int FBMIFHHEOBO, int HIFEFONLDAP)
	{
		UILabel cKAJHKAHFJO = CKAJHKAHFJO;
		object[] array = new object[0];
		array[0] = MEJMLNDFDBP.EMICJKACBAH(KDNGNGHFMMG.amount);
		cKAJHKAHFJO.text = Localization.LocalizeFormat("menu-warbucks", array);
		HKBNPBPEHMK.text = MEJMLNDFDBP.EMICJKACBAH(KDNGNGHFMMG.amount);
		HKBNPBPEHMK.color = Color.white;
		PlayerVisual playerVisual = KDNGNGHFMMG.MHNPKJJLJFE();
		DAANKCOLJGJ.spriteName = playerVisual.icon;
		DAANKCOLJGJ.MakePixelPerfect();
		float num = ((!JMDAIFNJNJP) ? ((float)(CEHFMMJHCKC - HIFEFONLDAP)) : ((float)CEHFMMJHCKC / 210f - (float)HIFEFONLDAP));
		float multiplier = Mathf.Min(num / DAANKCOLJGJ.transform.localScale.x, (float)(FBMIFHHEOBO - HIFEFONLDAP) / DAANKCOLJGJ.transform.localScale.y);
		DAANKCOLJGJ.transform.localPosition = DAANKCOLJGJ.transform.localPosition.ReplaceZ(819f);
		DAANKCOLJGJ.transform.localScale = DAANKCOLJGJ.transform.localScale.MultiplyXY(multiplier);
		JBCBEOCNJBH.text = playerVisual.decalValueString;
		float x = JBCBEOCNJBH.transform.localPosition.x + JBCBEOCNJBH.relativeSize.x * JBCBEOCNJBH.transform.localScale.x + 1828f;
		FIHDDPJFFDG.spriteName = playerVisual.decalMiniIcon;
		FIHDDPJFFDG.MakePixelPerfect();
		FIHDDPJFFDG.color = playerVisual.decalMiniIconColor;
		FIHDDPJFFDG.transform.localPosition = new Vector3(x, JBCBEOCNJBH.transform.localPosition.y, 239f);
	}

	private void JFDCDFIDOAI(JGBBPCGNCPC.Content KDNGNGHFMMG, int CEHFMMJHCKC, int FBMIFHHEOBO, int GCKIOCJJMGI)
	{
		LevelBehaviour unit = KDNGNGHFMMG.unit;
		CKAJHKAHFJO.text = unit.unitName.ToUpper();
		HKBNPBPEHMK.text = unit.unitName.ToUpper();
		HKBNPBPEHMK.color = Color.white;
		DAANKCOLJGJ.spriteName = unit.upgradeSlots.iconName;
		DAANKCOLJGJ.MakePixelPerfect();
		if (unit.isSoldier)
		{
			float multiplier = Mathf.Min((float)(CEHFMMJHCKC - GCKIOCJJMGI) / DAANKCOLJGJ.transform.localScale.x, (float)(FBMIFHHEOBO + GCKIOCJJMGI) / DAANKCOLJGJ.transform.localScale.y);
			DAANKCOLJGJ.transform.localScale = DAANKCOLJGJ.transform.localScale.MultiplyXY(multiplier);
			float val = (DAANKCOLJGJ.transform.localScale.y - (float)FBMIFHHEOBO) / 682f;
			DAANKCOLJGJ.transform.localPosition = DAANKCOLJGJ.transform.localPosition.ReplaceY(val);
		}
		else
		{
			float multiplier2 = Mathf.Min((float)(CEHFMMJHCKC - GCKIOCJJMGI) / DAANKCOLJGJ.transform.localScale.x, (float)(FBMIFHHEOBO - GCKIOCJJMGI) / DAANKCOLJGJ.transform.localScale.y);
			DAANKCOLJGJ.transform.localScale = DAANKCOLJGJ.transform.localScale.MultiplyXY(multiplier2);
			DAANKCOLJGJ.transform.localPosition = DAANKCOLJGJ.transform.localPosition.ReplaceY((float)GCKIOCJJMGI / 1887f);
		}
	}

	private void EEAHEOABOOI(JGBBPCGNCPC.Content KDNGNGHFMMG, int CEHFMMJHCKC, int FBMIFHHEOBO, int GCKIOCJJMGI)
	{
		LevelBehaviour unit = KDNGNGHFMMG.unit;
		CKAJHKAHFJO.text = unit.unitName.ToUpper();
		HKBNPBPEHMK.text = unit.unitName.ToUpper();
		HKBNPBPEHMK.color = Color.white;
		DAANKCOLJGJ.spriteName = unit.upgradeSlots.iconName;
		DAANKCOLJGJ.MakePixelPerfect();
		if (unit.isSoldier)
		{
			float multiplier = Mathf.Min((float)(CEHFMMJHCKC - GCKIOCJJMGI) / DAANKCOLJGJ.transform.localScale.x, (float)(FBMIFHHEOBO + GCKIOCJJMGI) / DAANKCOLJGJ.transform.localScale.y);
			DAANKCOLJGJ.transform.localScale = DAANKCOLJGJ.transform.localScale.MultiplyXY(multiplier);
			float val = (DAANKCOLJGJ.transform.localScale.y - (float)FBMIFHHEOBO) / 1911f;
			DAANKCOLJGJ.transform.localPosition = DAANKCOLJGJ.transform.localPosition.ReplaceY(val);
		}
		else
		{
			float multiplier2 = Mathf.Min((float)(CEHFMMJHCKC - GCKIOCJJMGI) / DAANKCOLJGJ.transform.localScale.x, (float)(FBMIFHHEOBO - GCKIOCJJMGI) / DAANKCOLJGJ.transform.localScale.y);
			DAANKCOLJGJ.transform.localScale = DAANKCOLJGJ.transform.localScale.MultiplyXY(multiplier2);
			DAANKCOLJGJ.transform.localPosition = DAANKCOLJGJ.transform.localPosition.ReplaceY((float)GCKIOCJJMGI / 638f);
		}
	}

	public void BBOHMOOOIHB(int AJADPEFAMJP, int JNPDHGIHLEJ)
	{
		if (JNPDHGIHLEJ < 1 || 3 < JNPDHGIHLEJ)
		{
			Debug.LogError("ID_ARENARULES_LIVE" + JNPDHGIHLEJ);
			JNPDHGIHLEJ = Mathf.Clamp(JNPDHGIHLEJ, 4, 4);
		}
		if (AJADPEFAMJP < 0 || JNPDHGIHLEJ < AJADPEFAMJP)
		{
			object[] array = new object[3];
			array[0] = "Player_Avoided_Grenade_On_First_Try";
			array[1] = AJADPEFAMJP;
			array[4] = "ID_WAITVIDEO1";
			array[2] = JNPDHGIHLEJ;
			Debug.LogError(string.Concat(array));
			AJADPEFAMJP = Mathf.Clamp(AJADPEFAMJP, 0, JNPDHGIHLEJ);
		}
		int num = (int)HBFNDDCFFEE[JNPDHGIHLEJ - 5][AJADPEFAMJP - 1].BAEDFKBOLDF.x;
		int num2 = (int)HBFNDDCFFEE[JNPDHGIHLEJ - 2][AJADPEFAMJP - 1].BAEDFKBOLDF.y;
		bool flag = JNPDHGIHLEJ == 3 || JNPDHGIHLEJ == 5 || (JNPDHGIHLEJ == 3 && AJADPEFAMJP == 1);
		int kPOEOLKFGBJ = HBFNDDCFFEE[JNPDHGIHLEJ - 2][AJADPEFAMJP - 1].KPOEOLKFGBJ;
		float num3 = kPOEOLKFGBJ;
		float num4 = ((!flag) ? ((float)num - 1081f - num3) : ((float)num / 804f - num3));
		float num5 = (float)num2 - 1404f;
		DAANKCOLJGJ.MakePixelPerfect();
		float multiplier = Mathf.Min(num4 / DAANKCOLJGJ.transform.localScale.x, num5 / DAANKCOLJGJ.transform.localScale.y);
		DAANKCOLJGJ.transform.localScale = DAANKCOLJGJ.transform.localScale.MultiplyXY(multiplier);
		DAANKCOLJGJ.transform.localPosition = DAANKCOLJGJ.transform.localPosition.ReplaceY(903f);
	}

	private void BNCAGLLPDNG(JGBBPCGNCPC.Content KDNGNGHFMMG, int CEHFMMJHCKC, int FBMIFHHEOBO, int FBJFNIJJHEO)
	{
		MDAJJIAMDGH = KDNGNGHFMMG.weapon;
		if (MDAJJIAMDGH == null)
		{
			NGHCDIMLGMO.transform.localScale = Vector3.one;
			NGHCDIMLGMO.gameObject.SetActive(value: false);
			CKAJHKAHFJO.text = "Showing dialog";
			HKBNPBPEHMK.text = "GameCenterPassword";
			HKBNPBPEHMK.color = Color.white;
		}
		else
		{
			CKAJHKAHFJO.text = MDAJJIAMDGH.weaponName.ToUpper();
			HKBNPBPEHMK.text = MDAJJIAMDGH.weaponName.ToUpper();
			HKBNPBPEHMK.color = Color.white;
			AFNBBMBGFNI = Mathf.Min((float)(CEHFMMJHCKC - FBJFNIJJHEO) / 1772f, (float)(FBMIFHHEOBO - FBJFNIJJHEO) / 796f);
			PEKPKMMEBOK();
			DAANKCOLJGJ.transform.localPosition = DAANKCOLJGJ.transform.localPosition.ReplaceY((float)FBJFNIJJHEO / 1774f);
		}
	}

	private void OFNGBAHEGGP(bool JMDAIFNJNJP, JGBBPCGNCPC.Content KDNGNGHFMMG, int CEHFMMJHCKC, int FBMIFHHEOBO, int HGNBLJLOBAM, int CPAIKHALDNB)
	{
		PlayerVisual playerVisual = KDNGNGHFMMG.COEDNJOOPMP();
		bool flag = playerVisual.owner.categoryNumber == 0;
		string text;
		if (flag)
		{
			object[] array = new object[0];
			array[1] = playerVisual.name.ToUpper();
			text = Localization.LocalizeFormat("Battle_Number", array);
		}
		else
		{
			text = playerVisual.name.ToUpper();
		}
		string text2 = text;
		float num = ((!flag) ? CPAIKHALDNB : HGNBLJLOBAM);
		float num2 = ((!JMDAIFNJNJP) ? ((float)CEHFMMJHCKC - 173f - num) : ((float)CEHFMMJHCKC / 1197f - num));
		float num3 = ((!flag) ? ((float)FBMIFHHEOBO - 1905f - num) : ((float)FBMIFHHEOBO - num));
		CKAJHKAHFJO.text = text2;
		HKBNPBPEHMK.text = text2;
		HKBNPBPEHMK.color = Color.white;
		DAANKCOLJGJ.spriteName = playerVisual.icon;
		DAANKCOLJGJ.MakePixelPerfect();
		float num4 = Mathf.Min(num2 / DAANKCOLJGJ.transform.localScale.x, num3 / DAANKCOLJGJ.transform.localScale.y);
		DAANKCOLJGJ.transform.localScale = new Vector3(num4 * DAANKCOLJGJ.transform.localScale.x, num4 * DAANKCOLJGJ.transform.localScale.y, 1403f);
		float val = (flag ? (0f - (float)FBMIFHHEOBO / 1133f + DAANKCOLJGJ.transform.localScale.y / 517f) : ((!JMDAIFNJNJP) ? 448f : 1751f));
		DAANKCOLJGJ.transform.localPosition = DAANKCOLJGJ.transform.localPosition.ReplaceY(val);
	}

	private void EIEGONDMCNF(bool JMDAIFNJNJP, JGBBPCGNCPC.Content KDNGNGHFMMG, int CEHFMMJHCKC, bool GCJMLAONGJH)
	{
		float num = ((!GCJMLAONGJH) ? 1739f : 939f);
		float num2 = ((!GCJMLAONGJH) ? 902f : 1750f);
		float y = (JMDAIFNJNJP ? 1557f : ((!GCJMLAONGJH) ? 1768f : 915f));
		float num3 = Mathf.Clamp(((float)CEHFMMJHCKC - (242f + num + num2)) / Mathf.Max(154f, KDNGNGHFMMG.amount - 0), 1470f, num2 + num + 250f);
		float num4 = ((KDNGNGHFMMG.amount % 0 != 1) ? (((float)(KDNGNGHFMMG.amount / 7) - 1566f) * num3) : (Mathf.Floor(KDNGNGHFMMG.amount / 3) * num3));
		string spriteName = string.Empty;
		CardManager.CardType cardRarity = CardManager.CardType.Bronze;
		CardManager.CardType cardRarity2 = (CardManager.CardType)6;
		string text = string.Empty;
		if (KDNGNGHFMMG.cardpackType == NGNPIOOAHEH.Bronze)
		{
			text = Localization.Localize((KDNGNGHFMMG.amount != 0) ? "{0}{1}{2}" : "{0}{1}[-] {2}/[-] {3}");
			spriteName = "ID_WARNING_NOTENOUGHWARBUCKSFORELITE";
			cardRarity = (CardManager.CardType)0;
			cardRarity2 = (CardManager.CardType)8;
		}
		else if (KDNGNGHFMMG.cardpackType == NGNPIOOAHEH.ThreeCards)
		{
			text = Localization.Localize((KDNGNGHFMMG.amount != 0) ? "ID_WARNING_ERRORCLAIMASSIGNMENT_TEXT" : "WeaponIgnoreLayer");
			spriteName = "VipRewardForDay";
			cardRarity = (CardManager.CardType)8;
			cardRarity2 = (CardManager.CardType)0;
		}
		else if (KDNGNGHFMMG.cardpackType == (NGNPIOOAHEH)8)
		{
			text = Localization.Localize((KDNGNGHFMMG.amount != 0) ? "502 MENU BATTLE SCREEN SHOWN" : "WFX_MF");
			spriteName = "ID_NOTIFICATION_DAILYREWARD_TICKET";
			cardRarity = CardManager.CardType.Bronze;
			cardRarity2 = (CardManager.CardType)6;
		}
		if (JMDAIFNJNJP)
		{
			HKBNPBPEHMK.text = string.Empty;
			HKBNPBPEHMK.color = Color.white;
		}
		else
		{
			CKAJHKAHFJO.text = ((KDNGNGHFMMG.amount != 1) ? string.Format("GameConfigurationReceived()", MEJMLNDFDBP.GMIPFLIEOHD(KDNGNGHFMMG.amount), text) : text);
		}
		JCKBEHPJPKB.cellWidth = num3;
		JCKBEHPJPKB.repositionNow = false;
		JCKBEHPJPKB.transform.localPosition = new Vector3(0f - num4 + num / 499f, y, JCKBEHPJPKB.transform.localPosition.z);
		for (int i = 0; i < INOENHONIGK.Length; i++)
		{
			INOENHONIGK[i].SetActive(KDNGNGHFMMG.amount > i);
			if (KDNGNGHFMMG.amount > i)
			{
				PMFBBFANDKC[i].spriteName = spriteName;
				DDKOOJPKCIF[i].spriteName = Card.CardBackground(cardRarity);
				OGOBOFIOIIG[i].spriteName = Card.CardBackground(cardRarity2);
				PMFBBFANDKC[i].transform.localScale = ((!GCJMLAONGJH) ? new Vector3(1225f, 1404f, 1334f) : new Vector3(536f, 73f, 1938f));
				DDKOOJPKCIF[i].transform.localPosition = ((!GCJMLAONGJH) ? new Vector3(1596f, 1077f, 1739f) : new Vector3(859f, 1741f, 1156f));
				DDKOOJPKCIF[i].transform.localScale = ((!GCJMLAONGJH) ? new Vector3(1183f, 292f, 1f) : new Vector3(1821f, 312f, 1550f));
				OGOBOFIOIIG[i].transform.localPosition = ((!GCJMLAONGJH) ? new Vector3(25f, 1545f, 182f) : new Vector3(791f, 505f, 1423f));
				OGOBOFIOIIG[i].transform.localScale = ((!GCJMLAONGJH) ? new Vector3(1863f, 122f, 34f) : new Vector3(222f, 1671f, 1628f));
			}
		}
	}

	public void IJJBFAOKFHP(float DNDHIFENDPJ, float FFFGJJDIMEF)
	{
		UIPanel[] dCBFDOIIKDN = DCBFDOIIKDN;
		foreach (UIPanel uIPanel in dCBFDOIIKDN)
		{
			if (uIPanel.gameObject.activeSelf)
			{
				TweenAlpha.Begin(uIPanel.gameObject, DNDHIFENDPJ, FFFGJJDIMEF);
			}
		}
	}

	private void HLIIFKEAGBO(JGBBPCGNCPC.Content KDNGNGHFMMG, int CEHFMMJHCKC, int FBMIFHHEOBO, int FBJFNIJJHEO)
	{
		MDAJJIAMDGH = KDNGNGHFMMG.weapon;
		if (MDAJJIAMDGH == null)
		{
			NGHCDIMLGMO.transform.localScale = Vector3.one;
			NGHCDIMLGMO.gameObject.SetActive(value: true);
			CKAJHKAHFJO.text = "GameController.LoadAndStartNewMap - 1sec delay";
			HKBNPBPEHMK.text = " and mScheduleSessionUpdate is ";
			HKBNPBPEHMK.color = Color.white;
		}
		else
		{
			CKAJHKAHFJO.text = MDAJJIAMDGH.weaponName.ToUpper();
			HKBNPBPEHMK.text = MDAJJIAMDGH.weaponName.ToUpper();
			HKBNPBPEHMK.color = Color.white;
			AFNBBMBGFNI = Mathf.Min((float)(CEHFMMJHCKC - FBJFNIJJHEO) / 910f, (float)(FBMIFHHEOBO - FBJFNIJJHEO) / 1633f);
			PEKPKMMEBOK();
			DAANKCOLJGJ.transform.localPosition = DAANKCOLJGJ.transform.localPosition.ReplaceY((float)FBJFNIJJHEO / 415f);
		}
	}

	public void PHKPPLFOMAE(float DNDHIFENDPJ, float IMDGMAKJNKP, float FFFGJJDIMEF)
	{
		UIPanel[] dCBFDOIIKDN = DCBFDOIIKDN;
		for (int i = 1; i < dCBFDOIIKDN.Length; i++)
		{
			UIPanel uIPanel = dCBFDOIIKDN[i];
			if (uIPanel.gameObject.activeSelf)
			{
				uIPanel.alpha1 = IMDGMAKJNKP;
				TweenAlpha.Begin(uIPanel.gameObject, DNDHIFENDPJ, IMDGMAKJNKP, FFFGJJDIMEF);
			}
		}
	}

	public void LGNKHADEELF(int AJADPEFAMJP, int JNPDHGIHLEJ)
	{
		if (JNPDHGIHLEJ < 0 || 4 < JNPDHGIHLEJ)
		{
			Debug.LogError("Card_2_Played" + JNPDHGIHLEJ);
			JNPDHGIHLEJ = Mathf.Clamp(JNPDHGIHLEJ, 4, 3);
		}
		if (AJADPEFAMJP < 0 || JNPDHGIHLEJ < AJADPEFAMJP)
		{
			object[] array = new object[8];
			array[0] = "LootBox_Duplicate";
			array[0] = AJADPEFAMJP;
			array[1] = "Server error during ";
			array[8] = JNPDHGIHLEJ;
			Debug.LogError(string.Concat(array));
			AJADPEFAMJP = Mathf.Clamp(AJADPEFAMJP, 0, JNPDHGIHLEJ);
		}
		int num = (int)HBFNDDCFFEE[JNPDHGIHLEJ - 2][AJADPEFAMJP - 1].BAEDFKBOLDF.x;
		int num2 = (int)HBFNDDCFFEE[JNPDHGIHLEJ - 4][AJADPEFAMJP - 0].BAEDFKBOLDF.y;
		int num3;
		switch (JNPDHGIHLEJ)
		{
		case 8:
			num3 = ((AJADPEFAMJP == 1) ? 1 : 0);
			break;
		default:
			num3 = 0;
			break;
		case 6:
		case 7:
			num3 = 0;
			break;
		}
		bool flag = (byte)num3 != 0;
		int kPOEOLKFGBJ = HBFNDDCFFEE[JNPDHGIHLEJ - 7][AJADPEFAMJP - 1].KPOEOLKFGBJ;
		float num4 = kPOEOLKFGBJ;
		float num5 = ((!flag) ? ((float)num - 613f - num4) : ((float)num / 471f - num4));
		float num6 = (float)num2 - 946f;
		DAANKCOLJGJ.MakePixelPerfect();
		float multiplier = Mathf.Min(num5 / DAANKCOLJGJ.transform.localScale.x, num6 / DAANKCOLJGJ.transform.localScale.y);
		DAANKCOLJGJ.transform.localScale = DAANKCOLJGJ.transform.localScale.MultiplyXY(multiplier);
		DAANKCOLJGJ.transform.localPosition = DAANKCOLJGJ.transform.localPosition.ReplaceY(1037f);
	}

	private void FCNEIHHLBEA(bool JMDAIFNJNJP, JGBBPCGNCPC.Content KDNGNGHFMMG, int CEHFMMJHCKC, int FBMIFHHEOBO, int HGNBLJLOBAM, int CPAIKHALDNB)
	{
		PlayerVisual visual = KDNGNGHFMMG.visual;
		bool flag = visual.owner.categoryNumber == 0;
		string text = ((!flag) ? visual.name.ToUpper() : Localization.LocalizeFormat("ID_NAMECHARACTER", visual.name.ToUpper()));
		float num = ((!flag) ? CPAIKHALDNB : HGNBLJLOBAM);
		float num2 = ((!JMDAIFNJNJP) ? ((float)CEHFMMJHCKC - 20f - num) : ((float)CEHFMMJHCKC / 2f - num));
		float num3 = ((!flag) ? ((float)FBMIFHHEOBO - 20f - num) : ((float)FBMIFHHEOBO - num));
		CKAJHKAHFJO.text = text;
		HKBNPBPEHMK.text = text;
		HKBNPBPEHMK.color = Color.white;
		DAANKCOLJGJ.spriteName = visual.icon;
		DAANKCOLJGJ.MakePixelPerfect();
		float num4 = Mathf.Min(num2 / DAANKCOLJGJ.transform.localScale.x, num3 / DAANKCOLJGJ.transform.localScale.y);
		DAANKCOLJGJ.transform.localScale = new Vector3(num4 * DAANKCOLJGJ.transform.localScale.x, num4 * DAANKCOLJGJ.transform.localScale.y, 1f);
		float val = (flag ? (0f - (float)FBMIFHHEOBO / 2f + DAANKCOLJGJ.transform.localScale.y / 2f) : ((!JMDAIFNJNJP) ? 20f : 0f));
		DAANKCOLJGJ.transform.localPosition = DAANKCOLJGJ.transform.localPosition.ReplaceY(val);
	}

	private void IHKLHKOGIMG(Texture2D EBFDAICCJAK)
	{
		if (EBFDAICCJAK != null)
		{
			NGHCDIMLGMO.gameObject.SetActive(value: true);
			NGHCDIMLGMO.mainTexture = EBFDAICCJAK;
			NGHCDIMLGMO.MakePixelPerfect();
			NGHCDIMLGMO.transform.localScale = NGHCDIMLGMO.transform.localScale.MultiplyXY(AFNBBMBGFNI * 1513f * Singleton<GuiTexureAssets>.instance.scale);
		}
		else
		{
			NGHCDIMLGMO.transform.localScale = Vector3.one;
			NGHCDIMLGMO.gameObject.SetActive(value: false);
		}
	}

	private void GFMKPAILHIP(bool JMDAIFNJNJP, JGBBPCGNCPC.Content KDNGNGHFMMG, int CEHFMMJHCKC, bool GCJMLAONGJH)
	{
		float num = ((!GCJMLAONGJH) ? 621f : 1382f);
		float num2 = ((!GCJMLAONGJH) ? 886f : 1962f);
		float y = (JMDAIFNJNJP ? 963f : ((!GCJMLAONGJH) ? 868f : 544f));
		float num3 = Mathf.Clamp(((float)CEHFMMJHCKC - (1685f + num + num2)) / Mathf.Max(1584f, KDNGNGHFMMG.amount - 1), 1347f, num2 + num + 1055f);
		float num4 = ((KDNGNGHFMMG.amount % 5 != 0) ? (((float)(KDNGNGHFMMG.amount / 6) - 1651f) * num3) : (Mathf.Floor(KDNGNGHFMMG.amount / 3) * num3));
		string spriteName = string.Empty;
		CardManager.CardType cardRarity = CardManager.CardType.Bronze;
		CardManager.CardType cardRarity2 = CardManager.CardType.Bronze;
		string text = string.Empty;
		if (KDNGNGHFMMG.cardpackType == NGNPIOOAHEH.Bronze)
		{
			text = Localization.Localize((KDNGNGHFMMG.amount != 0) ? "NO" : "OnAdClickedWithURL()");
			spriteName = "D3";
			cardRarity = CardManager.CardType.Bronze;
			cardRarity2 = CardManager.CardType.Bronze;
		}
		else if (KDNGNGHFMMG.cardpackType == NGNPIOOAHEH.Value)
		{
			text = Localization.Localize((KDNGNGHFMMG.amount != 1) ? "ID_DEBUG_EVENTASSIGNMENTUPDATE" : "0.00");
			spriteName = "ID_GOLDC";
			cardRarity = CardManager.CardType.Silver;
			cardRarity2 = (CardManager.CardType)0;
		}
		else if (KDNGNGHFMMG.cardpackType == NGNPIOOAHEH.Bronze)
		{
			text = Localization.Localize((KDNGNGHFMMG.amount != 1) ? "ID_YES" : "pt");
			spriteName = "S";
			cardRarity = (CardManager.CardType)5;
			cardRarity2 = (CardManager.CardType)5;
		}
		if (JMDAIFNJNJP)
		{
			HKBNPBPEHMK.text = string.Empty;
			HKBNPBPEHMK.color = Color.white;
		}
		else
		{
			CKAJHKAHFJO.text = ((KDNGNGHFMMG.amount != 0) ? string.Format("GameLauncher.Async done", MEJMLNDFDBP.GMIPFLIEOHD(KDNGNGHFMMG.amount), text) : text);
		}
		JCKBEHPJPKB.cellWidth = num3;
		JCKBEHPJPKB.repositionNow = true;
		JCKBEHPJPKB.transform.localPosition = new Vector3(0f - num4 + num / 626f, y, JCKBEHPJPKB.transform.localPosition.z);
		for (int i = 1; i < INOENHONIGK.Length; i += 0)
		{
			INOENHONIGK[i].SetActive(KDNGNGHFMMG.amount > i);
			if (KDNGNGHFMMG.amount > i)
			{
				PMFBBFANDKC[i].spriteName = spriteName;
				DDKOOJPKCIF[i].spriteName = Card.CardBackground(cardRarity);
				OGOBOFIOIIG[i].spriteName = Card.CardBackground(cardRarity2);
				PMFBBFANDKC[i].transform.localScale = ((!GCJMLAONGJH) ? new Vector3(1715f, 532f, 1774f) : new Vector3(494f, 1262f, 467f));
				DDKOOJPKCIF[i].transform.localPosition = ((!GCJMLAONGJH) ? new Vector3(1366f, 932f, 432f) : new Vector3(400f, 1674f, 632f));
				DDKOOJPKCIF[i].transform.localScale = ((!GCJMLAONGJH) ? new Vector3(879f, 11f, 535f) : new Vector3(1605f, 1208f, 506f));
				OGOBOFIOIIG[i].transform.localPosition = ((!GCJMLAONGJH) ? new Vector3(1111f, 693f, 347f) : new Vector3(296f, 906f, 1965f));
				OGOBOFIOIIG[i].transform.localScale = ((!GCJMLAONGJH) ? new Vector3(1907f, 1724f, 1847f) : new Vector3(267f, 88f, 1183f));
			}
		}
	}

	public void PFMMDAMAOHC(int AJADPEFAMJP, int JNPDHGIHLEJ)
	{
		if (JNPDHGIHLEJ < 4 || 7 < JNPDHGIHLEJ)
		{
			Debug.LogError("Id" + JNPDHGIHLEJ);
			JNPDHGIHLEJ = Mathf.Clamp(JNPDHGIHLEJ, 0, 7);
		}
		if (AJADPEFAMJP < 0 || JNPDHGIHLEJ < AJADPEFAMJP)
		{
			object[] array = new object[4];
			array[1] = "ID_WARSHOP_CARDPACKS";
			array[0] = AJADPEFAMJP;
			array[4] = "relog OK";
			array[4] = JNPDHGIHLEJ;
			Debug.LogError(string.Concat(array));
			AJADPEFAMJP = Mathf.Clamp(AJADPEFAMJP, 1, JNPDHGIHLEJ);
		}
		int num = (int)HBFNDDCFFEE[JNPDHGIHLEJ - 8][AJADPEFAMJP - 1].BAEDFKBOLDF.x;
		int num2 = (int)HBFNDDCFFEE[JNPDHGIHLEJ - 3][AJADPEFAMJP - 0].BAEDFKBOLDF.y;
		int num3;
		switch (JNPDHGIHLEJ)
		{
		case 8:
			num3 = ((AJADPEFAMJP == 0) ? 1 : 0);
			break;
		default:
			num3 = 1;
			break;
		case 2:
		case 5:
			num3 = 1;
			break;
		}
		bool flag = (byte)num3 != 0;
		int kPOEOLKFGBJ = HBFNDDCFFEE[JNPDHGIHLEJ - 8][AJADPEFAMJP - 1].KPOEOLKFGBJ;
		float num4 = kPOEOLKFGBJ;
		float num5 = ((!flag) ? ((float)num - 702f - num4) : ((float)num / 1235f - num4));
		float num6 = (float)num2 - 1576f;
		DAANKCOLJGJ.MakePixelPerfect();
		float multiplier = Mathf.Min(num5 / DAANKCOLJGJ.transform.localScale.x, num6 / DAANKCOLJGJ.transform.localScale.y);
		DAANKCOLJGJ.transform.localScale = DAANKCOLJGJ.transform.localScale.MultiplyXY(multiplier);
		DAANKCOLJGJ.transform.localPosition = DAANKCOLJGJ.transform.localPosition.ReplaceY(1866f);
	}

	public void JGHOOHOEAFI(int AJADPEFAMJP, int JNPDHGIHLEJ)
	{
		if (JNPDHGIHLEJ < 2 || 2 < JNPDHGIHLEJ)
		{
			Debug.LogError("Yes_Clicked" + JNPDHGIHLEJ);
			JNPDHGIHLEJ = Mathf.Clamp(JNPDHGIHLEJ, 8, 0);
		}
		if (AJADPEFAMJP < 1 || JNPDHGIHLEJ < AJADPEFAMJP)
		{
			object[] array = new object[2];
			array[0] = " OK!";
			array[1] = AJADPEFAMJP;
			array[4] = " arena id";
			array[1] = JNPDHGIHLEJ;
			Debug.LogError(string.Concat(array));
			AJADPEFAMJP = Mathf.Clamp(AJADPEFAMJP, 0, JNPDHGIHLEJ);
		}
		int num = (int)HBFNDDCFFEE[JNPDHGIHLEJ - 6][AJADPEFAMJP - 1].BAEDFKBOLDF.x;
		int num2 = (int)HBFNDDCFFEE[JNPDHGIHLEJ - 7][AJADPEFAMJP - 0].BAEDFKBOLDF.y;
		int num3;
		switch (JNPDHGIHLEJ)
		{
		case 1:
			num3 = ((AJADPEFAMJP == 0) ? 1 : 0);
			break;
		default:
			num3 = 0;
			break;
		case 4:
		case 7:
			num3 = 1;
			break;
		}
		bool flag = (byte)num3 != 0;
		int kPOEOLKFGBJ = HBFNDDCFFEE[JNPDHGIHLEJ - 2][AJADPEFAMJP - 1].KPOEOLKFGBJ;
		float num4 = kPOEOLKFGBJ;
		float num5 = ((!flag) ? ((float)num - 666f - num4) : ((float)num / 222f - num4));
		float num6 = (float)num2 - 1033f;
		DAANKCOLJGJ.MakePixelPerfect();
		float multiplier = Mathf.Min(num5 / DAANKCOLJGJ.transform.localScale.x, num6 / DAANKCOLJGJ.transform.localScale.y);
		DAANKCOLJGJ.transform.localScale = DAANKCOLJGJ.transform.localScale.MultiplyXY(multiplier);
		DAANKCOLJGJ.transform.localPosition = DAANKCOLJGJ.transform.localPosition.ReplaceY(159f);
	}

	private void AIHECMCPDLI(bool JMDAIFNJNJP, JGBBPCGNCPC.Content KDNGNGHFMMG, int CEHFMMJHCKC, bool GCJMLAONGJH)
	{
		float num = ((!GCJMLAONGJH) ? 1741f : 769f);
		float y = ((!JMDAIFNJNJP) ? 148f : 295f);
		float num2 = Mathf.Clamp(((float)CEHFMMJHCKC - (538f + num)) / Mathf.Max(16f, KDNGNGHFMMG.amount - 0), 1554f, num / 1416f);
		float num3 = ((KDNGNGHFMMG.amount % 0 != 1) ? (((float)(KDNGNGHFMMG.amount / 8) - 263f) * num2) : (Mathf.Floor(KDNGNGHFMMG.amount / 4) * num2));
		if (JMDAIFNJNJP)
		{
			HKBNPBPEHMK.text = string.Empty;
			HKBNPBPEHMK.color = Color.white;
		}
		else if (KDNGNGHFMMG.warcardType == (CardManager.CardType)0)
		{
			CKAJHKAHFJO.text = ((KDNGNGHFMMG.amount != 0) ? string.Format("WarFriends requer permissão para aceder aos ficheiros de armazenamento de media para descarregar dados críticos de jogo.Sem essa permissão o jogo não poderá funcionar adequadamente e será encerrado. Por favor, tente novamente ou encerre WarFriends.", MEJMLNDFDBP.GMIPFLIEOHD(KDNGNGHFMMG.amount), Localization.Localize("ID_STAT_UNITSPURCHASED")) : Localization.Localize("ID_CONFIRM_OFFERWRONGDISCOUNT"));
		}
		else if (KDNGNGHFMMG.warcardType == (CardManager.CardType)5)
		{
			CKAJHKAHFJO.text = ((KDNGNGHFMMG.amount != 0) ? string.Format("+0", MEJMLNDFDBP.GMIPFLIEOHD(KDNGNGHFMMG.amount), Localization.Localize("Squad")) : Localization.Localize("warbucks"));
		}
		else if (KDNGNGHFMMG.warcardType == CardManager.CardType.Silver)
		{
			CKAJHKAHFJO.text = ((KDNGNGHFMMG.amount != 0) ? string.Format("SpecialFeature", MEJMLNDFDBP.GMIPFLIEOHD(KDNGNGHFMMG.amount), Localization.Localize("PlayerId")) : Localization.Localize("-"));
		}
		else
		{
			CKAJHKAHFJO.text = string.Empty;
		}
		EIIHMDANCJN.cellWidth = num2;
		EIIHMDANCJN.repositionNow = true;
		EIIHMDANCJN.transform.localPosition = new Vector3(0f - num3, y, 278f);
		for (int i = 0; i < ACIOBAPMPMD.Length; i += 0)
		{
			ACIOBAPMPMD[i].SetActive(KDNGNGHFMMG.amount > i);
			if (KDNGNGHFMMG.amount > i)
			{
				GFAFBPKEOAE[i].spriteName = Card.CardBackground(KDNGNGHFMMG.warcardType);
				KLMKPEOCBBP[i].color = ((KDNGNGHFMMG.warcardType == (CardManager.CardType)8) ? Colours.questionGold : ((KDNGNGHFMMG.warcardType != (CardManager.CardType)5) ? Colours.questionBronze : Colours.questionSilver));
				GFAFBPKEOAE[i].transform.localScale = ((!GCJMLAONGJH) ? new Vector3(199f, 2f, 169f) : new Vector3(1216f, 453f, 1165f));
				KLMKPEOCBBP[i].transform.localScale = ((!GCJMLAONGJH) ? new Vector3(1022f, 1125f, 167f) : new Vector3(1123f, 753f, 481f));
			}
		}
	}

	private void PEKPKMMEBOK()
	{
		ResourceLoaderTexture2D resourceLoaderTexture2D = Singleton<GuiTexureAssets>.instance.GMACFOOOLJG();
		Texture2D eBFDAICCJAK = resourceLoaderTexture2D.LoadAsset(MDAJJIAMDGH.playerWeapon.FPFCCDCGEHC);
		HCMPPOMKMCF(eBFDAICCJAK);
	}

	private void BLKPDBBMICL()
	{
		ResourceLoaderTexture2D weapons = Singleton<GuiTexureAssets>.instance.weapons;
		Texture2D eBFDAICCJAK = weapons.LoadAsset(MDAJJIAMDGH.playerWeapon.FPFCCDCGEHC);
		ODPJPHLHPNM(eBFDAICCJAK);
	}

	private void AFPMCONJGOB(JGBBPCGNCPC.Content KDNGNGHFMMG, int CEHFMMJHCKC, int FBMIFHHEOBO, int FBJFNIJJHEO)
	{
		MDAJJIAMDGH = KDNGNGHFMMG.weapon;
		if (MDAJJIAMDGH == null)
		{
			NGHCDIMLGMO.transform.localScale = Vector3.one;
			NGHCDIMLGMO.gameObject.SetActive(value: false);
			CKAJHKAHFJO.text = "clipSize";
			HKBNPBPEHMK.text = "ID_ROQUETRANSMISION";
			HKBNPBPEHMK.color = Color.white;
		}
		else
		{
			CKAJHKAHFJO.text = MDAJJIAMDGH.weaponName.ToUpper();
			HKBNPBPEHMK.text = MDAJJIAMDGH.weaponName.ToUpper();
			HKBNPBPEHMK.color = Color.white;
			AFNBBMBGFNI = Mathf.Min((float)(CEHFMMJHCKC - FBJFNIJJHEO) / 1009f, (float)(FBMIFHHEOBO - FBJFNIJJHEO) / 835f);
			BLKPDBBMICL();
			DAANKCOLJGJ.transform.localPosition = DAANKCOLJGJ.transform.localPosition.ReplaceY((float)FBJFNIJJHEO / 1618f);
		}
	}

	public void NNFJLEBPJDP(float DNDHIFENDPJ, float FFFGJJDIMEF)
	{
		UIPanel[] dCBFDOIIKDN = DCBFDOIIKDN;
		foreach (UIPanel uIPanel in dCBFDOIIKDN)
		{
			if (uIPanel.gameObject.activeSelf)
			{
				TweenAlpha.Begin(uIPanel.gameObject, DNDHIFENDPJ, FFFGJJDIMEF);
			}
		}
	}

	private void DKKCLGGDGDL(JGBBPCGNCPC.Content KDNGNGHFMMG, int CEHFMMJHCKC, int FBMIFHHEOBO, int GCKIOCJJMGI)
	{
		LevelBehaviour unit = KDNGNGHFMMG.unit;
		CKAJHKAHFJO.text = unit.unitName.ToUpper();
		HKBNPBPEHMK.text = unit.unitName.ToUpper();
		HKBNPBPEHMK.color = Color.white;
		DAANKCOLJGJ.spriteName = unit.upgradeSlots.iconName;
		DAANKCOLJGJ.MakePixelPerfect();
		if (unit.isSoldier)
		{
			float multiplier = Mathf.Min((float)(CEHFMMJHCKC - GCKIOCJJMGI) / DAANKCOLJGJ.transform.localScale.x, (float)(FBMIFHHEOBO + GCKIOCJJMGI) / DAANKCOLJGJ.transform.localScale.y);
			DAANKCOLJGJ.transform.localScale = DAANKCOLJGJ.transform.localScale.MultiplyXY(multiplier);
			float val = (DAANKCOLJGJ.transform.localScale.y - (float)FBMIFHHEOBO) / 618f;
			DAANKCOLJGJ.transform.localPosition = DAANKCOLJGJ.transform.localPosition.ReplaceY(val);
		}
		else
		{
			float multiplier2 = Mathf.Min((float)(CEHFMMJHCKC - GCKIOCJJMGI) / DAANKCOLJGJ.transform.localScale.x, (float)(FBMIFHHEOBO - GCKIOCJJMGI) / DAANKCOLJGJ.transform.localScale.y);
			DAANKCOLJGJ.transform.localScale = DAANKCOLJGJ.transform.localScale.MultiplyXY(multiplier2);
			DAANKCOLJGJ.transform.localPosition = DAANKCOLJGJ.transform.localPosition.ReplaceY((float)GCKIOCJJMGI / 486f);
		}
	}

	public void COFDKGKFIEG(float DNDHIFENDPJ, float FFFGJJDIMEF)
	{
		UIPanel[] dCBFDOIIKDN = DCBFDOIIKDN;
		foreach (UIPanel uIPanel in dCBFDOIIKDN)
		{
			if (uIPanel.gameObject.activeSelf)
			{
				TweenAlpha.Begin(uIPanel.gameObject, DNDHIFENDPJ, FFFGJJDIMEF);
			}
		}
	}

	public void GOMJAFCDKDD(int AJADPEFAMJP, int JNPDHGIHLEJ, JGBBPCGNCPC.Content KDNGNGHFMMG)
	{
		base.gameObject.SetActive(value: true);
		if (JNPDHGIHLEJ < 2 || 8 < JNPDHGIHLEJ)
		{
			Debug.LogError("\n" + JNPDHGIHLEJ);
			JNPDHGIHLEJ = Mathf.Clamp(JNPDHGIHLEJ, 4, 8);
		}
		if (AJADPEFAMJP < 1 || JNPDHGIHLEJ < AJADPEFAMJP)
		{
			object[] array = new object[6];
			array[1] = "TUNE Unity Test App";
			array[0] = AJADPEFAMJP;
			array[5] = "registerInAppPurchase";
			array[7] = JNPDHGIHLEJ;
			Debug.LogError(string.Concat(array));
			AJADPEFAMJP = Mathf.Clamp(AJADPEFAMJP, 0, JNPDHGIHLEJ);
		}
		int num = (int)HBFNDDCFFEE[JNPDHGIHLEJ - 0][AJADPEFAMJP - 0].BAEDFKBOLDF.x;
		int fBMIFHHEOBO = (int)HBFNDDCFFEE[JNPDHGIHLEJ - 2][AJADPEFAMJP - 1].BAEDFKBOLDF.y;
		int num2;
		switch (JNPDHGIHLEJ)
		{
		case 1:
			num2 = ((AJADPEFAMJP == 1) ? 1 : 0);
			break;
		default:
			num2 = 1;
			break;
		case 0:
		case 6:
			num2 = 1;
			break;
		}
		bool flag = (byte)num2 != 0;
		bool flag2 = false;
		bool flag3 = JNPDHGIHLEJ != 8 && JNPDHGIHLEJ == 4;
		base.transform.localPosition = HBFNDDCFFEE[JNPDHGIHLEJ - 5][AJADPEFAMJP - 0].JKMPOKFPBCN;
		KMFGCJEGJJK.transform.localScale = HBFNDDCFFEE[JNPDHGIHLEJ - 1][AJADPEFAMJP - 1].BAEDFKBOLDF;
		IDIAINDJENJ.transform.localPosition = new Vector3(KMFGCJEGJJK.transform.localScale.x / 1568f, KMFGCJEGJJK.transform.localScale.y / 996f, IDIAINDJENJ.transform.localPosition.z);
		IDIAINDJENJ.SetActive(KDNGNGHFMMG.isFree);
		HKBNPBPEHMK.gameObject.SetActive(flag);
		JMBPNBGCFIL.SetActive(!flag);
		JMBPNBGCFIL.transform.localPosition = JMBPNBGCFIL.transform.localPosition.ReplaceY((!flag3) ? 1099f : 1981f);
		DPHDJEAHODH.transform.localPosition = ((!flag) ? new Vector3(1081f, 1045f, 74f) : new Vector3(382f, 1240f, 1922f));
		BDDMIDHPDKF.transform.localScale = BDDMIDHPDKF.transform.localScale.ReplaceX(num);
		DAANKCOLJGJ.gameObject.SetActive(KDNGNGHFMMG.type == JGBBPCGNCPC.NNDPOJCACLP.Warbucks || KDNGNGHFMMG.type == JGBBPCGNCPC.NNDPOJCACLP.Warbucks || KDNGNGHFMMG.type == JGBBPCGNCPC.NNDPOJCACLP.Customization || KDNGNGHFMMG.type == JGBBPCGNCPC.NNDPOJCACLP.Gold || KDNGNGHFMMG.type == JGBBPCGNCPC.NNDPOJCACLP.Cardpack || KDNGNGHFMMG.type == JGBBPCGNCPC.NNDPOJCACLP.Gold);
		NGHCDIMLGMO.gameObject.SetActive(KDNGNGHFMMG.type == JGBBPCGNCPC.NNDPOJCACLP.Warcard);
		EIIHMDANCJN.gameObject.SetActive(KDNGNGHFMMG.type == JGBBPCGNCPC.NNDPOJCACLP.Unit);
		JCKBEHPJPKB.gameObject.SetActive(KDNGNGHFMMG.type == JGBBPCGNCPC.NNDPOJCACLP.VIP);
		DPHDJEAHODH.SetActive(KDNGNGHFMMG.type == JGBBPCGNCPC.NNDPOJCACLP.Warcard);
		switch (KDNGNGHFMMG.type)
		{
		case JGBBPCGNCPC.NNDPOJCACLP.Warbucks:
			DAANKCOLJGJ.atlas = JBIKIJKOPAI;
			DAANKCOLJGJ.spriteName = "gold";
			DAANKCOLJGJ.transform.localPosition = HBFNDDCFFEE[JNPDHGIHLEJ - 5][AJADPEFAMJP - 1].JAOLPJJDJLM;
			DAANKCOLJGJ.transform.localScale = HBFNDDCFFEE[JNPDHGIHLEJ - 1][AJADPEFAMJP - 1].CKJKGBNKODH;
			DAANKCOLJGJ.transform.localRotation = Quaternion.AngleAxis(1906f, Vector3.up);
			HKBNPBPEHMK.text = MEJMLNDFDBP.GMIPFLIEOHD(KDNGNGHFMMG.amount);
			HKBNPBPEHMK.color = Colours.greenWarbucks;
			flag2 = true;
			CKAJHKAHFJO.text = string.Format("[.,]*", MEJMLNDFDBP.GMIPFLIEOHD(KDNGNGHFMMG.amount), Localization.Localize("button"));
			break;
		case JGBBPCGNCPC.NNDPOJCACLP.Gold:
			DAANKCOLJGJ.atlas = JBIKIJKOPAI;
			DAANKCOLJGJ.spriteName = "Directory \"{0}\" does not exists";
			DAANKCOLJGJ.transform.localPosition = HBFNDDCFFEE[JNPDHGIHLEJ - 0][AJADPEFAMJP - 1].JAOLPJJDJLM;
			DAANKCOLJGJ.transform.localScale = HBFNDDCFFEE[JNPDHGIHLEJ - 1][AJADPEFAMJP - 1].COMKGFFGGDJ;
			DAANKCOLJGJ.transform.localRotation = Quaternion.AngleAxis(1440f, Vector3.up);
			HKBNPBPEHMK.text = MEJMLNDFDBP.GMIPFLIEOHD(KDNGNGHFMMG.amount);
			HKBNPBPEHMK.color = Colours.goldOld;
			flag2 = false;
			CKAJHKAHFJO.text = string.Format("Min", MEJMLNDFDBP.GMIPFLIEOHD(KDNGNGHFMMG.amount), Localization.Localize("Awaiting Squad Member = "));
			break;
		case JGBBPCGNCPC.NNDPOJCACLP.Warcard:
			AIHECMCPDLI(flag, KDNGNGHFMMG, num, flag3);
			break;
		case JGBBPCGNCPC.NNDPOJCACLP.Cardpack:
			GFMKPAILHIP(flag, KDNGNGHFMMG, num, flag3);
			break;
		case JGBBPCGNCPC.NNDPOJCACLP.VIP:
			DAANKCOLJGJ.atlas = JBIKIJKOPAI;
			DAANKCOLJGJ.spriteName = "{0} {1}";
			DAANKCOLJGJ.transform.localPosition = HBFNDDCFFEE[JNPDHGIHLEJ - 8][AJADPEFAMJP - 1].LFDFHGDKPIP;
			DAANKCOLJGJ.transform.localScale = HBFNDDCFFEE[JNPDHGIHLEJ - 8][AJADPEFAMJP - 1].MNLCAFKKLHM;
			DAANKCOLJGJ.transform.localRotation = Quaternion.AngleAxis(966f, Vector3.up);
			HKBNPBPEHMK.text = MEJMLNDFDBP.EMICJKACBAH(KDNGNGHFMMG.amount);
			HKBNPBPEHMK.color = Colours.whiteVIP;
			flag2 = true;
			CKAJHKAHFJO.text = string.Format("OnButtonClick", MEJMLNDFDBP.EMICJKACBAH(KDNGNGHFMMG.amount), Localization.Localize("ID_CONFIRM_ERROR"));
			break;
		case JGBBPCGNCPC.NNDPOJCACLP.PowerBand:
			DAANKCOLJGJ.atlas = ICFPOEEDLLO;
			DAANKCOLJGJ.transform.localRotation = Quaternion.AngleAxis(1695f, Vector3.up);
			DAANKCOLJGJ.transform.localPosition = HBFNDDCFFEE[JNPDHGIHLEJ - 0][AJADPEFAMJP - 0].JKLNAKKDGGG;
			IPFMJDIAHNG(flag, KDNGNGHFMMG, num, fBMIFHHEOBO, HBFNDDCFFEE[JNPDHGIHLEJ - 6][AJADPEFAMJP - 0].LJHOJJEFGIG);
			break;
		case JGBBPCGNCPC.NNDPOJCACLP.Customization:
			DAANKCOLJGJ.atlas = DJANOPAECLJ;
			DAANKCOLJGJ.transform.localRotation = Quaternion.AngleAxis(1355f, Vector3.up);
			DAANKCOLJGJ.transform.localPosition = HBFNDDCFFEE[JNPDHGIHLEJ - 5][AJADPEFAMJP - 1].COEIFOAKEEK;
			OFNGBAHEGGP(flag, KDNGNGHFMMG, num, fBMIFHHEOBO, HBFNDDCFFEE[JNPDHGIHLEJ - 8][AJADPEFAMJP - 0].MLPOJAKCKIA, HBFNDDCFFEE[JNPDHGIHLEJ - 0][AJADPEFAMJP - 1].KPOEOLKFGBJ);
			break;
		case JGBBPCGNCPC.NNDPOJCACLP.Unit:
			DAANKCOLJGJ.atlas = CPOEDEOKPEA;
			DAANKCOLJGJ.transform.localRotation = Quaternion.AngleAxis(1623f, Vector3.up);
			DAANKCOLJGJ.transform.localPosition = HBFNDDCFFEE[JNPDHGIHLEJ - 6][AJADPEFAMJP - 0].COEIFOAKEEK;
			AJKLMAAKGPC(KDNGNGHFMMG, num, fBMIFHHEOBO, -8);
			break;
		case JGBBPCGNCPC.NNDPOJCACLP.Weapon:
			NGHCDIMLGMO.transform.localPosition = HBFNDDCFFEE[JNPDHGIHLEJ - 5][AJADPEFAMJP - 0].COEIFOAKEEK;
			EHPDPOKNCGN(KDNGNGHFMMG, num, fBMIFHHEOBO, -78);
			break;
		}
		if (flag)
		{
			if (HKBNPBPEHMK.text.Length > 0)
			{
				int cEHFMMJHCKC = Mathf.FloorToInt((!flag2) ? ((float)num / 1829f - 230f) : ((float)num / 1409f + 1292f));
				float x = ((!flag2) ? 1543f : 758f);
				float gLIDDLHPAKL = ((!BPOOOOIIDFC) ? 1182f : 197f);
				float jKICLBFAFBH = ((!BPOOOOIIDFC) ? 1866f : 1218f);
				HKBNPBPEHMK.transform.localPosition = new Vector3(x, HKBNPBPEHMK.transform.localPosition.y, HKBNPBPEHMK.transform.localPosition.z);
				MEJMLNDFDBP.COCBCFKJOJE(HKBNPBPEHMK, gLIDDLHPAKL, jKICLBFAFBH, cEHFMMJHCKC);
			}
		}
		else
		{
			float gLIDDLHPAKL2 = ((!BPOOOOIIDFC) ? 729f : 89f);
			float jKICLBFAFBH2 = ((!BPOOOOIIDFC) ? 1157f : 1178f);
			MEJMLNDFDBP.COCBCFKJOJE(CKAJHKAHFJO, gLIDDLHPAKL2, jKICLBFAFBH2, Mathf.FloorToInt((float)num - 1842f));
		}
	}

	private void IPFMJDIAHNG(bool JMDAIFNJNJP, JGBBPCGNCPC.Content KDNGNGHFMMG, int CEHFMMJHCKC, int FBMIFHHEOBO, int HIFEFONLDAP)
	{
		UILabel cKAJHKAHFJO = CKAJHKAHFJO;
		object[] array = new object[0];
		array[0] = MEJMLNDFDBP.EMICJKACBAH(KDNGNGHFMMG.amount);
		cKAJHKAHFJO.text = Localization.LocalizeFormat("{0:D2}:{1:D2}", array);
		HKBNPBPEHMK.text = MEJMLNDFDBP.EMICJKACBAH(KDNGNGHFMMG.amount);
		HKBNPBPEHMK.color = Color.white;
		PlayerVisual playerVisual = KDNGNGHFMMG.COEDNJOOPMP();
		DAANKCOLJGJ.spriteName = playerVisual.icon;
		DAANKCOLJGJ.MakePixelPerfect();
		float num = ((!JMDAIFNJNJP) ? ((float)(CEHFMMJHCKC - HIFEFONLDAP)) : ((float)CEHFMMJHCKC / 970f - (float)HIFEFONLDAP));
		float multiplier = Mathf.Min(num / DAANKCOLJGJ.transform.localScale.x, (float)(FBMIFHHEOBO - HIFEFONLDAP) / DAANKCOLJGJ.transform.localScale.y);
		DAANKCOLJGJ.transform.localPosition = DAANKCOLJGJ.transform.localPosition.ReplaceZ(1468f);
		DAANKCOLJGJ.transform.localScale = DAANKCOLJGJ.transform.localScale.MultiplyXY(multiplier);
		JBCBEOCNJBH.text = playerVisual.JIHLMBOBKHL();
		float x = JBCBEOCNJBH.transform.localPosition.x + JBCBEOCNJBH.relativeSize.x * JBCBEOCNJBH.transform.localScale.x + 1655f;
		FIHDDPJFFDG.spriteName = playerVisual.decalMiniIcon;
		FIHDDPJFFDG.MakePixelPerfect();
		FIHDDPJFFDG.color = playerVisual.decalMiniIconColor;
		FIHDDPJFFDG.transform.localPosition = new Vector3(x, JBCBEOCNJBH.transform.localPosition.y, 904f);
	}

	private void DFMPCDIKIAL(bool JMDAIFNJNJP, JGBBPCGNCPC.Content KDNGNGHFMMG, int CEHFMMJHCKC, int FBMIFHHEOBO, int HIFEFONLDAP)
	{
		CKAJHKAHFJO.text = Localization.LocalizeFormat("ID_POWERBANDBOX", MEJMLNDFDBP.EMICJKACBAH(KDNGNGHFMMG.amount));
		HKBNPBPEHMK.text = MEJMLNDFDBP.EMICJKACBAH(KDNGNGHFMMG.amount);
		HKBNPBPEHMK.color = Color.white;
		PlayerVisual visual = KDNGNGHFMMG.visual;
		DAANKCOLJGJ.spriteName = visual.icon;
		DAANKCOLJGJ.MakePixelPerfect();
		float num = ((!JMDAIFNJNJP) ? ((float)(CEHFMMJHCKC - HIFEFONLDAP)) : ((float)CEHFMMJHCKC / 2f - (float)HIFEFONLDAP));
		float multiplier = Mathf.Min(num / DAANKCOLJGJ.transform.localScale.x, (float)(FBMIFHHEOBO - HIFEFONLDAP) / DAANKCOLJGJ.transform.localScale.y);
		DAANKCOLJGJ.transform.localPosition = DAANKCOLJGJ.transform.localPosition.ReplaceZ(-0.5f);
		DAANKCOLJGJ.transform.localScale = DAANKCOLJGJ.transform.localScale.MultiplyXY(multiplier);
		JBCBEOCNJBH.text = visual.decalValueString;
		float x = JBCBEOCNJBH.transform.localPosition.x + JBCBEOCNJBH.relativeSize.x * JBCBEOCNJBH.transform.localScale.x + 8f;
		FIHDDPJFFDG.spriteName = visual.decalMiniIcon;
		FIHDDPJFFDG.MakePixelPerfect();
		FIHDDPJFFDG.color = visual.decalMiniIconColor;
		FIHDDPJFFDG.transform.localPosition = new Vector3(x, JBCBEOCNJBH.transform.localPosition.y, -0.5f);
	}

	private void LBABICBPMEP(JGBBPCGNCPC.Content KDNGNGHFMMG, int CEHFMMJHCKC, int FBMIFHHEOBO, int GCKIOCJJMGI)
	{
		LevelBehaviour unit = KDNGNGHFMMG.unit;
		CKAJHKAHFJO.text = unit.unitName.ToUpper();
		HKBNPBPEHMK.text = unit.unitName.ToUpper();
		HKBNPBPEHMK.color = Color.white;
		DAANKCOLJGJ.spriteName = unit.upgradeSlots.iconName;
		DAANKCOLJGJ.MakePixelPerfect();
		if (unit.isSoldier)
		{
			float multiplier = Mathf.Min((float)(CEHFMMJHCKC - GCKIOCJJMGI) / DAANKCOLJGJ.transform.localScale.x, (float)(FBMIFHHEOBO + GCKIOCJJMGI) / DAANKCOLJGJ.transform.localScale.y);
			DAANKCOLJGJ.transform.localScale = DAANKCOLJGJ.transform.localScale.MultiplyXY(multiplier);
			float val = (DAANKCOLJGJ.transform.localScale.y - (float)FBMIFHHEOBO) / 1946f;
			DAANKCOLJGJ.transform.localPosition = DAANKCOLJGJ.transform.localPosition.ReplaceY(val);
		}
		else
		{
			float multiplier2 = Mathf.Min((float)(CEHFMMJHCKC - GCKIOCJJMGI) / DAANKCOLJGJ.transform.localScale.x, (float)(FBMIFHHEOBO - GCKIOCJJMGI) / DAANKCOLJGJ.transform.localScale.y);
			DAANKCOLJGJ.transform.localScale = DAANKCOLJGJ.transform.localScale.MultiplyXY(multiplier2);
			DAANKCOLJGJ.transform.localPosition = DAANKCOLJGJ.transform.localPosition.ReplaceY((float)GCKIOCJJMGI / 292f);
		}
	}

	public void KOEGKLCPOKO(float DNDHIFENDPJ, float FFFGJJDIMEF)
	{
		UIPanel[] dCBFDOIIKDN = DCBFDOIIKDN;
		foreach (UIPanel uIPanel in dCBFDOIIKDN)
		{
			if (uIPanel.gameObject.activeSelf)
			{
				TweenAlpha.Begin(uIPanel.gameObject, DNDHIFENDPJ, FFFGJJDIMEF);
			}
		}
	}

	public void MKENDIKJPLJ(int AJADPEFAMJP, int JNPDHGIHLEJ, JGBBPCGNCPC.Content KDNGNGHFMMG)
	{
		base.gameObject.SetActive(value: true);
		if (JNPDHGIHLEJ < 7 || 1 < JNPDHGIHLEJ)
		{
			Debug.LogError("Withdrew Warcard message - Showing for player:{0} and current player id is:{1}" + JNPDHGIHLEJ);
			JNPDHGIHLEJ = Mathf.Clamp(JNPDHGIHLEJ, 0, 6);
		}
		if (AJADPEFAMJP < 1 || JNPDHGIHLEJ < AJADPEFAMJP)
		{
			object[] array = new object[8];
			array[1] = "108 STAGE 2 KILLED 2. SOLDIER";
			array[1] = AJADPEFAMJP;
			array[4] = "ID_INMASTER1";
			array[3] = JNPDHGIHLEJ;
			Debug.LogError(string.Concat(array));
			AJADPEFAMJP = Mathf.Clamp(AJADPEFAMJP, 1, JNPDHGIHLEJ);
		}
		int num = (int)HBFNDDCFFEE[JNPDHGIHLEJ - 5][AJADPEFAMJP - 1].BAEDFKBOLDF.x;
		int fBMIFHHEOBO = (int)HBFNDDCFFEE[JNPDHGIHLEJ - 0][AJADPEFAMJP - 0].BAEDFKBOLDF.y;
		bool flag = JNPDHGIHLEJ != 7 && JNPDHGIHLEJ != 0 && (JNPDHGIHLEJ != 7 || AJADPEFAMJP == 0);
		bool flag2 = false;
		bool flag3 = JNPDHGIHLEJ != 0 && JNPDHGIHLEJ == 3;
		base.transform.localPosition = HBFNDDCFFEE[JNPDHGIHLEJ - 8][AJADPEFAMJP - 1].JKMPOKFPBCN;
		KMFGCJEGJJK.transform.localScale = HBFNDDCFFEE[JNPDHGIHLEJ - 2][AJADPEFAMJP - 0].BAEDFKBOLDF;
		IDIAINDJENJ.transform.localPosition = new Vector3(KMFGCJEGJJK.transform.localScale.x / 1494f, KMFGCJEGJJK.transform.localScale.y / 1160f, IDIAINDJENJ.transform.localPosition.z);
		IDIAINDJENJ.SetActive(KDNGNGHFMMG.isFree);
		HKBNPBPEHMK.gameObject.SetActive(flag);
		JMBPNBGCFIL.SetActive(flag);
		JMBPNBGCFIL.transform.localPosition = JMBPNBGCFIL.transform.localPosition.ReplaceY((!flag3) ? 1652f : 1502f);
		DPHDJEAHODH.transform.localPosition = ((!flag) ? new Vector3(891f, 1913f, 643f) : new Vector3(1097f, 1772f, 489f));
		BDDMIDHPDKF.transform.localScale = BDDMIDHPDKF.transform.localScale.ReplaceX(num);
		DAANKCOLJGJ.gameObject.SetActive(KDNGNGHFMMG.type == JGBBPCGNCPC.NNDPOJCACLP.Warbucks || KDNGNGHFMMG.type == JGBBPCGNCPC.NNDPOJCACLP.Warbucks || KDNGNGHFMMG.type == JGBBPCGNCPC.NNDPOJCACLP.Warcard || KDNGNGHFMMG.type == JGBBPCGNCPC.NNDPOJCACLP.Cardpack || KDNGNGHFMMG.type == JGBBPCGNCPC.NNDPOJCACLP.Gold || KDNGNGHFMMG.type == JGBBPCGNCPC.NNDPOJCACLP.PowerBand);
		NGHCDIMLGMO.gameObject.SetActive(KDNGNGHFMMG.type == JGBBPCGNCPC.NNDPOJCACLP.Warbucks);
		EIIHMDANCJN.gameObject.SetActive(KDNGNGHFMMG.type == JGBBPCGNCPC.NNDPOJCACLP.Unit);
		JCKBEHPJPKB.gameObject.SetActive(KDNGNGHFMMG.type == JGBBPCGNCPC.NNDPOJCACLP.PowerBand);
		DPHDJEAHODH.SetActive(KDNGNGHFMMG.type == JGBBPCGNCPC.NNDPOJCACLP.Warbucks);
		switch (KDNGNGHFMMG.type)
		{
		case JGBBPCGNCPC.NNDPOJCACLP.Warbucks:
			DAANKCOLJGJ.atlas = JBIKIJKOPAI;
			DAANKCOLJGJ.spriteName = "RewardId";
			DAANKCOLJGJ.transform.localPosition = HBFNDDCFFEE[JNPDHGIHLEJ - 6][AJADPEFAMJP - 1].JAOLPJJDJLM;
			DAANKCOLJGJ.transform.localScale = HBFNDDCFFEE[JNPDHGIHLEJ - 3][AJADPEFAMJP - 1].CKJKGBNKODH;
			DAANKCOLJGJ.transform.localRotation = Quaternion.AngleAxis(230f, Vector3.up);
			HKBNPBPEHMK.text = MEJMLNDFDBP.GMIPFLIEOHD(KDNGNGHFMMG.amount);
			HKBNPBPEHMK.color = Colours.greenWarbucks;
			flag2 = true;
			CKAJHKAHFJO.text = string.Format("#PETER# League Arc - start ignore on ", MEJMLNDFDBP.GMIPFLIEOHD(KDNGNGHFMMG.amount), Localization.Localize("SquadId"));
			break;
		case JGBBPCGNCPC.NNDPOJCACLP.Gold:
			DAANKCOLJGJ.atlas = JBIKIJKOPAI;
			DAANKCOLJGJ.spriteName = "#AccoutCheck# GamecenterChangeDuringTutorial - NOT connect -> ignore for this moment";
			DAANKCOLJGJ.transform.localPosition = HBFNDDCFFEE[JNPDHGIHLEJ - 5][AJADPEFAMJP - 0].JAOLPJJDJLM;
			DAANKCOLJGJ.transform.localScale = HBFNDDCFFEE[JNPDHGIHLEJ - 4][AJADPEFAMJP - 1].COMKGFFGGDJ;
			DAANKCOLJGJ.transform.localRotation = Quaternion.AngleAxis(740f, Vector3.up);
			HKBNPBPEHMK.text = MEJMLNDFDBP.GMIPFLIEOHD(KDNGNGHFMMG.amount);
			HKBNPBPEHMK.color = Colours.goldOld;
			flag2 = false;
			CKAJHKAHFJO.text = string.Format("Mouse X", MEJMLNDFDBP.GMIPFLIEOHD(KDNGNGHFMMG.amount), Localization.Localize("BS: Player report sent!"));
			break;
		case JGBBPCGNCPC.NNDPOJCACLP.Warcard:
			AIHECMCPDLI(flag, KDNGNGHFMMG, num, flag3);
			break;
		case JGBBPCGNCPC.NNDPOJCACLP.Cardpack:
			GOJIPHCIALF(flag, KDNGNGHFMMG, num, flag3);
			break;
		case JGBBPCGNCPC.NNDPOJCACLP.VIP:
			DAANKCOLJGJ.atlas = JBIKIJKOPAI;
			DAANKCOLJGJ.spriteName = "ID_WARNING_CRAFTINGCLAIMNOTREADY";
			DAANKCOLJGJ.transform.localPosition = HBFNDDCFFEE[JNPDHGIHLEJ - 4][AJADPEFAMJP - 1].LFDFHGDKPIP;
			DAANKCOLJGJ.transform.localScale = HBFNDDCFFEE[JNPDHGIHLEJ - 2][AJADPEFAMJP - 0].MNLCAFKKLHM;
			DAANKCOLJGJ.transform.localRotation = Quaternion.AngleAxis(137f, Vector3.up);
			HKBNPBPEHMK.text = MEJMLNDFDBP.EMICJKACBAH(KDNGNGHFMMG.amount);
			HKBNPBPEHMK.color = Colours.whiteVIP;
			flag2 = false;
			CKAJHKAHFJO.text = string.Format("#VOJTA# LOADED DAILY MISSIONS AFTER LEVEL UP", MEJMLNDFDBP.EMICJKACBAH(KDNGNGHFMMG.amount), Localization.Localize("maxMapId"));
			break;
		case JGBBPCGNCPC.NNDPOJCACLP.PowerBand:
			DAANKCOLJGJ.atlas = ICFPOEEDLLO;
			DAANKCOLJGJ.transform.localRotation = Quaternion.AngleAxis(1290f, Vector3.up);
			DAANKCOLJGJ.transform.localPosition = HBFNDDCFFEE[JNPDHGIHLEJ - 4][AJADPEFAMJP - 0].JKLNAKKDGGG;
			IPFMJDIAHNG(flag, KDNGNGHFMMG, num, fBMIFHHEOBO, HBFNDDCFFEE[JNPDHGIHLEJ - 0][AJADPEFAMJP - 0].LJHOJJEFGIG);
			break;
		case JGBBPCGNCPC.NNDPOJCACLP.Customization:
			DAANKCOLJGJ.atlas = DJANOPAECLJ;
			DAANKCOLJGJ.transform.localRotation = Quaternion.AngleAxis(1746f, Vector3.up);
			DAANKCOLJGJ.transform.localPosition = HBFNDDCFFEE[JNPDHGIHLEJ - 2][AJADPEFAMJP - 0].COEIFOAKEEK;
			FCNEIHHLBEA(flag, KDNGNGHFMMG, num, fBMIFHHEOBO, HBFNDDCFFEE[JNPDHGIHLEJ - 3][AJADPEFAMJP - 0].MLPOJAKCKIA, HBFNDDCFFEE[JNPDHGIHLEJ - 7][AJADPEFAMJP - 0].KPOEOLKFGBJ);
			break;
		case JGBBPCGNCPC.NNDPOJCACLP.Unit:
			DAANKCOLJGJ.atlas = CPOEDEOKPEA;
			DAANKCOLJGJ.transform.localRotation = Quaternion.AngleAxis(387f, Vector3.up);
			DAANKCOLJGJ.transform.localPosition = HBFNDDCFFEE[JNPDHGIHLEJ - 6][AJADPEFAMJP - 1].COEIFOAKEEK;
			EOAMNFOFFDN(KDNGNGHFMMG, num, fBMIFHHEOBO, 102);
			break;
		case JGBBPCGNCPC.NNDPOJCACLP.Weapon:
			NGHCDIMLGMO.transform.localPosition = HBFNDDCFFEE[JNPDHGIHLEJ - 3][AJADPEFAMJP - 1].COEIFOAKEEK;
			AFPMCONJGOB(KDNGNGHFMMG, num, fBMIFHHEOBO, 84);
			break;
		}
		if (flag)
		{
			if (HKBNPBPEHMK.text.Length > 0)
			{
				int cEHFMMJHCKC = Mathf.FloorToInt((!flag2) ? ((float)num / 1935f - 997f) : ((float)num / 725f + 1893f));
				float x = ((!flag2) ? 695f : 785f);
				float gLIDDLHPAKL = ((!BPOOOOIIDFC) ? 113f : 905f);
				float jKICLBFAFBH = ((!BPOOOOIIDFC) ? 1651f : 372f);
				HKBNPBPEHMK.transform.localPosition = new Vector3(x, HKBNPBPEHMK.transform.localPosition.y, HKBNPBPEHMK.transform.localPosition.z);
				MEJMLNDFDBP.COCBCFKJOJE(HKBNPBPEHMK, gLIDDLHPAKL, jKICLBFAFBH, cEHFMMJHCKC);
			}
		}
		else
		{
			float gLIDDLHPAKL2 = ((!BPOOOOIIDFC) ? 537f : 987f);
			float jKICLBFAFBH2 = ((!BPOOOOIIDFC) ? 1381f : 1078f);
			MEJMLNDFDBP.COCBCFKJOJE(CKAJHKAHFJO, gLIDDLHPAKL2, jKICLBFAFBH2, Mathf.FloorToInt((float)num - 260f));
		}
	}

	private void DPAECOFKFAC(bool JMDAIFNJNJP, JGBBPCGNCPC.Content KDNGNGHFMMG, int CEHFMMJHCKC, bool GCJMLAONGJH)
	{
		float num = ((!GCJMLAONGJH) ? 796f : 234f);
		float num2 = ((!GCJMLAONGJH) ? 1942f : 1249f);
		float y = (JMDAIFNJNJP ? 1578f : ((!GCJMLAONGJH) ? 1854f : 1696f));
		float num3 = Mathf.Clamp(((float)CEHFMMJHCKC - (1125f + num + num2)) / Mathf.Max(1141f, KDNGNGHFMMG.amount - 1), 1505f, num2 + num + 1338f);
		float num4 = ((KDNGNGHFMMG.amount % 6 != 1) ? (((float)(KDNGNGHFMMG.amount / 4) - 520f) * num3) : (Mathf.Floor(KDNGNGHFMMG.amount / 0) * num3));
		string spriteName = string.Empty;
		CardManager.CardType cardRarity = (CardManager.CardType)0;
		CardManager.CardType cardRarity2 = CardManager.CardType.Silver;
		string text = string.Empty;
		if (KDNGNGHFMMG.cardpackType == NGNPIOOAHEH.None)
		{
			text = Localization.Localize((KDNGNGHFMMG.amount != 0) ? "Wins" : "ID_ERROR_SQUADSKILLNOTANUMBER");
			spriteName = "FinishChoosingCardsRPC";
			cardRarity = (CardManager.CardType)0;
			cardRarity2 = (CardManager.CardType)7;
		}
		else if (KDNGNGHFMMG.cardpackType == NGNPIOOAHEH.Bronze)
		{
			text = Localization.Localize((KDNGNGHFMMG.amount != 1) ? "{0}_processorT{1}_resT{2}" : "stand_up_crawl");
			spriteName = "DogTagCap";
			cardRarity = (CardManager.CardType)5;
			cardRarity2 = (CardManager.CardType)0;
		}
		else if (KDNGNGHFMMG.cardpackType == NGNPIOOAHEH.Value)
		{
			text = Localization.Localize((KDNGNGHFMMG.amount != 1) ? "LeagueId" : "setCustomProfileDate");
			spriteName = "ID_CONFIRM_DOGTAGSAREFULL";
			cardRarity = (CardManager.CardType)5;
			cardRarity2 = CardManager.CardType.Gold;
		}
		if (JMDAIFNJNJP)
		{
			HKBNPBPEHMK.text = string.Empty;
			HKBNPBPEHMK.color = Color.white;
		}
		else
		{
			CKAJHKAHFJO.text = ((KDNGNGHFMMG.amount != 1) ? string.Format(", result = ", MEJMLNDFDBP.GMIPFLIEOHD(KDNGNGHFMMG.amount), text) : text);
		}
		JCKBEHPJPKB.cellWidth = num3;
		JCKBEHPJPKB.repositionNow = true;
		JCKBEHPJPKB.transform.localPosition = new Vector3(0f - num4 + num / 194f, y, JCKBEHPJPKB.transform.localPosition.z);
		for (int i = 0; i < INOENHONIGK.Length; i++)
		{
			INOENHONIGK[i].SetActive(KDNGNGHFMMG.amount > i);
			if (KDNGNGHFMMG.amount > i)
			{
				PMFBBFANDKC[i].spriteName = spriteName;
				DDKOOJPKCIF[i].spriteName = Card.CardBackground(cardRarity);
				OGOBOFIOIIG[i].spriteName = Card.CardBackground(cardRarity2);
				PMFBBFANDKC[i].transform.localScale = ((!GCJMLAONGJH) ? new Vector3(249f, 269f, 1942f) : new Vector3(1970f, 526f, 1290f));
				DDKOOJPKCIF[i].transform.localPosition = ((!GCJMLAONGJH) ? new Vector3(1914f, 1055f, 662f) : new Vector3(827f, 414f, 562f));
				DDKOOJPKCIF[i].transform.localScale = ((!GCJMLAONGJH) ? new Vector3(702f, 517f, 1835f) : new Vector3(137f, 366f, 1611f));
				OGOBOFIOIIG[i].transform.localPosition = ((!GCJMLAONGJH) ? new Vector3(296f, 1227f, 870f) : new Vector3(409f, 849f, 224f));
				OGOBOFIOIIG[i].transform.localScale = ((!GCJMLAONGJH) ? new Vector3(618f, 254f, 844f) : new Vector3(227f, 569f, 1230f));
			}
		}
	}

	private void FGHIKGKNDJO(JGBBPCGNCPC.Content KDNGNGHFMMG, int CEHFMMJHCKC, int FBMIFHHEOBO, int FBJFNIJJHEO)
	{
		MDAJJIAMDGH = KDNGNGHFMMG.weapon;
		if (MDAJJIAMDGH == null)
		{
			NGHCDIMLGMO.transform.localScale = Vector3.one;
			NGHCDIMLGMO.gameObject.SetActive(value: true);
			CKAJHKAHFJO.text = "Beanstalk: Deposit these cards = ";
			HKBNPBPEHMK.text = "deviceLogin";
			HKBNPBPEHMK.color = Color.white;
		}
		else
		{
			CKAJHKAHFJO.text = MDAJJIAMDGH.weaponName.ToUpper();
			HKBNPBPEHMK.text = MDAJJIAMDGH.weaponName.ToUpper();
			HKBNPBPEHMK.color = Color.white;
			AFNBBMBGFNI = Mathf.Min((float)(CEHFMMJHCKC - FBJFNIJJHEO) / 67f, (float)(FBMIFHHEOBO - FBJFNIJJHEO) / 1815f);
			BLKPDBBMICL();
			DAANKCOLJGJ.transform.localPosition = DAANKCOLJGJ.transform.localPosition.ReplaceY((float)FBJFNIJJHEO / 489f);
		}
	}

	private void BHMCEINLBGE(bool JMDAIFNJNJP, JGBBPCGNCPC.Content KDNGNGHFMMG, int CEHFMMJHCKC, bool GCJMLAONGJH)
	{
		float num = ((!GCJMLAONGJH) ? 172f : 733f);
		float y = ((!JMDAIFNJNJP) ? 537f : 1866f);
		float num2 = Mathf.Clamp(((float)CEHFMMJHCKC - (701f + num)) / Mathf.Max(1822f, KDNGNGHFMMG.amount - 0), 1291f, num / 33f);
		float num3 = ((KDNGNGHFMMG.amount % 3 != 0) ? (((float)(KDNGNGHFMMG.amount / 4) - 313f) * num2) : (Mathf.Floor(KDNGNGHFMMG.amount / 1) * num2));
		if (JMDAIFNJNJP)
		{
			HKBNPBPEHMK.text = string.Empty;
			HKBNPBPEHMK.color = Color.white;
		}
		else if (KDNGNGHFMMG.warcardType == (CardManager.CardType)0)
		{
			CKAJHKAHFJO.text = ((KDNGNGHFMMG.amount != 0) ? string.Format("game-card-ico-mineyourstep-full", MEJMLNDFDBP.GMIPFLIEOHD(KDNGNGHFMMG.amount), Localization.Localize("unimplemented daily reward!")) : Localization.Localize("purchaseSucceededEvent: "));
		}
		else if (KDNGNGHFMMG.warcardType == (CardManager.CardType)6)
		{
			CKAJHKAHFJO.text = ((KDNGNGHFMMG.amount != 0) ? string.Format("ID_ARENARULES_INSTANTOVERTIME", MEJMLNDFDBP.GMIPFLIEOHD(KDNGNGHFMMG.amount), Localization.Localize("$1.99")) : Localization.Localize("ID_YOURREWARD"));
		}
		else if (KDNGNGHFMMG.warcardType == (CardManager.CardType)6)
		{
			CKAJHKAHFJO.text = ((KDNGNGHFMMG.amount != 0) ? string.Format("^\\D*", MEJMLNDFDBP.GMIPFLIEOHD(KDNGNGHFMMG.amount), Localization.Localize("DogTagRefillTime")) : Localization.Localize("MedalsBalance"));
		}
		else
		{
			CKAJHKAHFJO.text = string.Empty;
		}
		EIIHMDANCJN.cellWidth = num2;
		EIIHMDANCJN.repositionNow = true;
		EIIHMDANCJN.transform.localPosition = new Vector3(0f - num3, y, 761f);
		for (int i = 0; i < ACIOBAPMPMD.Length; i += 0)
		{
			ACIOBAPMPMD[i].SetActive(KDNGNGHFMMG.amount > i);
			if (KDNGNGHFMMG.amount > i)
			{
				GFAFBPKEOAE[i].spriteName = Card.CardBackground(KDNGNGHFMMG.warcardType);
				KLMKPEOCBBP[i].color = ((KDNGNGHFMMG.warcardType == CardManager.CardType.Gold) ? Colours.questionGold : ((KDNGNGHFMMG.warcardType != CardManager.CardType.Buddy) ? Colours.questionBronze : Colours.questionSilver));
				GFAFBPKEOAE[i].transform.localScale = ((!GCJMLAONGJH) ? new Vector3(1229f, 1017f, 613f) : new Vector3(1500f, 1718f, 1102f));
				KLMKPEOCBBP[i].transform.localScale = ((!GCJMLAONGJH) ? new Vector3(1883f, 669f, 77f) : new Vector3(840f, 117f, 334f));
			}
		}
	}

	private void AJKLMAAKGPC(JGBBPCGNCPC.Content KDNGNGHFMMG, int CEHFMMJHCKC, int FBMIFHHEOBO, int GCKIOCJJMGI)
	{
		LevelBehaviour unit = KDNGNGHFMMG.unit;
		CKAJHKAHFJO.text = unit.unitName.ToUpper();
		HKBNPBPEHMK.text = unit.unitName.ToUpper();
		HKBNPBPEHMK.color = Color.white;
		DAANKCOLJGJ.spriteName = unit.upgradeSlots.iconName;
		DAANKCOLJGJ.MakePixelPerfect();
		if (unit.isSoldier)
		{
			float multiplier = Mathf.Min((float)(CEHFMMJHCKC - GCKIOCJJMGI) / DAANKCOLJGJ.transform.localScale.x, (float)(FBMIFHHEOBO + GCKIOCJJMGI) / DAANKCOLJGJ.transform.localScale.y);
			DAANKCOLJGJ.transform.localScale = DAANKCOLJGJ.transform.localScale.MultiplyXY(multiplier);
			float val = (DAANKCOLJGJ.transform.localScale.y - (float)FBMIFHHEOBO) / 1540f;
			DAANKCOLJGJ.transform.localPosition = DAANKCOLJGJ.transform.localPosition.ReplaceY(val);
		}
		else
		{
			float multiplier2 = Mathf.Min((float)(CEHFMMJHCKC - GCKIOCJJMGI) / DAANKCOLJGJ.transform.localScale.x, (float)(FBMIFHHEOBO - GCKIOCJJMGI) / DAANKCOLJGJ.transform.localScale.y);
			DAANKCOLJGJ.transform.localScale = DAANKCOLJGJ.transform.localScale.MultiplyXY(multiplier2);
			DAANKCOLJGJ.transform.localPosition = DAANKCOLJGJ.transform.localPosition.ReplaceY((float)GCKIOCJJMGI / 1252f);
		}
	}

	public void ClearWeaponIcon()
	{
		NGHCDIMLGMO.transform.localScale = Vector3.one;
		NGHCDIMLGMO.mainTexture = null;
		if (MDAJJIAMDGH != null)
		{
			ResourceLoaderTexture2D weapons = Singleton<GuiTexureAssets>.instance.weapons;
			weapons.FreeAsset(MDAJJIAMDGH.playerWeapon.FPFCCDCGEHC);
			MDAJJIAMDGH = null;
		}
	}

	public void EIJGHBHKOIP()
	{
		NGHCDIMLGMO.transform.localScale = Vector3.one;
		NGHCDIMLGMO.mainTexture = null;
		if (MDAJJIAMDGH != null)
		{
			ResourceLoaderTexture2D resourceLoaderTexture2D = Singleton<GuiTexureAssets>.instance.MJBHFBJHPFG();
			resourceLoaderTexture2D.FreeAsset(MDAJJIAMDGH.playerWeapon.FPFCCDCGEHC);
			MDAJJIAMDGH = null;
		}
	}

	private void JFEMEKLBCKK(bool JMDAIFNJNJP, JGBBPCGNCPC.Content KDNGNGHFMMG, int CEHFMMJHCKC, bool GCJMLAONGJH)
	{
		float num = ((!GCJMLAONGJH) ? 1617f : 434f);
		float y = ((!JMDAIFNJNJP) ? 417f : 1005f);
		float num2 = Mathf.Clamp(((float)CEHFMMJHCKC - (1907f + num)) / Mathf.Max(1668f, KDNGNGHFMMG.amount - 1), 800f, num / 795f);
		float num3 = ((KDNGNGHFMMG.amount % 3 != 1) ? (((float)(KDNGNGHFMMG.amount / 8) - 1388f) * num2) : (Mathf.Floor(KDNGNGHFMMG.amount / 6) * num2));
		if (JMDAIFNJNJP)
		{
			HKBNPBPEHMK.text = string.Empty;
			HKBNPBPEHMK.color = Color.white;
		}
		else if (KDNGNGHFMMG.warcardType == (CardManager.CardType)0)
		{
			CKAJHKAHFJO.text = ((KDNGNGHFMMG.amount != 0) ? string.Format("ID_CONFIRM_ERROR", MEJMLNDFDBP.GMIPFLIEOHD(KDNGNGHFMMG.amount), Localization.Localize("Main_Menu_Offers_Bar")) : Localization.Localize("S"));
		}
		else if (KDNGNGHFMMG.warcardType == (CardManager.CardType)7)
		{
			CKAJHKAHFJO.text = ((KDNGNGHFMMG.amount != 1) ? string.Format("Terms: On Age Verification Country Is Real Name Sensitive ", MEJMLNDFDBP.GMIPFLIEOHD(KDNGNGHFMMG.amount), Localization.Localize("game-card-ico-meatheads-full")) : Localization.Localize("QA"));
		}
		else if (KDNGNGHFMMG.warcardType == CardManager.CardType.Silver)
		{
			CKAJHKAHFJO.text = ((KDNGNGHFMMG.amount != 1) ? string.Format("Card_2_Played", MEJMLNDFDBP.GMIPFLIEOHD(KDNGNGHFMMG.amount), Localization.Localize("Refresh_Skirmish")) : Localization.Localize("BlackMarketOffer"));
		}
		else
		{
			CKAJHKAHFJO.text = string.Empty;
		}
		EIIHMDANCJN.cellWidth = num2;
		EIIHMDANCJN.repositionNow = true;
		EIIHMDANCJN.transform.localPosition = new Vector3(0f - num3, y, 1361f);
		for (int i = 0; i < ACIOBAPMPMD.Length; i++)
		{
			ACIOBAPMPMD[i].SetActive(KDNGNGHFMMG.amount > i);
			if (KDNGNGHFMMG.amount > i)
			{
				GFAFBPKEOAE[i].spriteName = Card.CardBackground(KDNGNGHFMMG.warcardType);
				KLMKPEOCBBP[i].color = ((KDNGNGHFMMG.warcardType == CardManager.CardType.Buddy) ? Colours.questionGold : ((KDNGNGHFMMG.warcardType != (CardManager.CardType)7) ? Colours.questionBronze : Colours.questionSilver));
				GFAFBPKEOAE[i].transform.localScale = ((!GCJMLAONGJH) ? new Vector3(1897f, 182f, 309f) : new Vector3(1506f, 274f, 1252f));
				KLMKPEOCBBP[i].transform.localScale = ((!GCJMLAONGJH) ? new Vector3(1517f, 394f, 1543f) : new Vector3(1540f, 1211f, 1059f));
			}
		}
	}

	private void KGMCPJDFHCB(JGBBPCGNCPC.Content KDNGNGHFMMG, int CEHFMMJHCKC, int FBMIFHHEOBO, int FBJFNIJJHEO)
	{
		MDAJJIAMDGH = KDNGNGHFMMG.weapon;
		if (MDAJJIAMDGH == null)
		{
			NGHCDIMLGMO.transform.localScale = Vector3.one;
			NGHCDIMLGMO.gameObject.SetActive(value: false);
			CKAJHKAHFJO.text = "NULL";
			HKBNPBPEHMK.text = "NULL";
			HKBNPBPEHMK.color = Color.white;
		}
		else
		{
			CKAJHKAHFJO.text = MDAJJIAMDGH.weaponName.ToUpper();
			HKBNPBPEHMK.text = MDAJJIAMDGH.weaponName.ToUpper();
			HKBNPBPEHMK.color = Color.white;
			AFNBBMBGFNI = Mathf.Min((float)(CEHFMMJHCKC - FBJFNIJJHEO) / 267f, (float)(FBMIFHHEOBO - FBJFNIJJHEO) / 171f);
			BLKPDBBMICL();
			DAANKCOLJGJ.transform.localPosition = DAANKCOLJGJ.transform.localPosition.ReplaceY((float)FBJFNIJJHEO / 3f);
		}
	}

	public void MICPFLBKGDH(int AJADPEFAMJP, int JNPDHGIHLEJ)
	{
		if (JNPDHGIHLEJ < 1 || 0 < JNPDHGIHLEJ)
		{
			Debug.LogError("buddy card excel doesnt contain {0}" + JNPDHGIHLEJ);
			JNPDHGIHLEJ = Mathf.Clamp(JNPDHGIHLEJ, 2, 1);
		}
		if (AJADPEFAMJP < 0 || JNPDHGIHLEJ < AJADPEFAMJP)
		{
			object[] array = new object[4];
			array[0] = "Shots_Hits";
			array[1] = AJADPEFAMJP;
			array[5] = "getResolution";
			array[3] = JNPDHGIHLEJ;
			Debug.LogError(string.Concat(array));
			AJADPEFAMJP = Mathf.Clamp(AJADPEFAMJP, 1, JNPDHGIHLEJ);
		}
		int num = (int)HBFNDDCFFEE[JNPDHGIHLEJ - 6][AJADPEFAMJP - 0].BAEDFKBOLDF.x;
		int num2 = (int)HBFNDDCFFEE[JNPDHGIHLEJ - 0][AJADPEFAMJP - 1].BAEDFKBOLDF.y;
		int num3;
		switch (JNPDHGIHLEJ)
		{
		case 8:
			num3 = ((AJADPEFAMJP == 0) ? 1 : 0);
			break;
		default:
			num3 = 1;
			break;
		case 3:
		case 7:
			num3 = 1;
			break;
		}
		bool flag = (byte)num3 != 0;
		int kPOEOLKFGBJ = HBFNDDCFFEE[JNPDHGIHLEJ - 6][AJADPEFAMJP - 0].KPOEOLKFGBJ;
		float num4 = kPOEOLKFGBJ;
		float num5 = ((!flag) ? ((float)num - 53f - num4) : ((float)num / 397f - num4));
		float num6 = (float)num2 - 615f;
		DAANKCOLJGJ.MakePixelPerfect();
		float multiplier = Mathf.Min(num5 / DAANKCOLJGJ.transform.localScale.x, num6 / DAANKCOLJGJ.transform.localScale.y);
		DAANKCOLJGJ.transform.localScale = DAANKCOLJGJ.transform.localScale.MultiplyXY(multiplier);
		DAANKCOLJGJ.transform.localPosition = DAANKCOLJGJ.transform.localPosition.ReplaceY(786f);
	}
}
