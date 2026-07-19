using System;
using System.Runtime.CompilerServices;
using UnityEngine;

public class SkillshotGuiRecord : PoolableObject, IComparable<SkillshotGuiRecord>
{
	[Header("Left Part")]
	public UISprite JDOOPPMKEFO;

	public UILabel IOLHJBNKLDB;

	public UILabel CHIFIDBEDFI;

	public UISprite OMPLMJECMHO;

	[Header("Right Part")]
	public UISprite HKOMIDCBDBH;

	public UILabel GABLIPAALPO;

	public UILabel CFAOGMIGJLK;

	public UISprite FJOIHMIPKOI;

	[Header("Middle Part")]
	public UISprite HANKJKLJDEB;

	public UILabel BOOAEFNFJHH;

	public GameObject MEOFJDFHDOB;

	public UISprite ACGMFDMBCCA;

	public UISprite JCIAIOAFCGF;

	public UISprite IJGLJKDPAMC;

	[Header("Settings")]
	public bool LANBHLJINFJ;

	private Color ABJFGMEFFDP = Color.gray;

	private Color DADHFLHAIHJ = Color.white;

	public int plModifier { get; private set; }

	public int opModifier { get; private set; }

	public int plScore { get; private set; }

	public int opScore { get; private set; }

	public float plProgress { get; private set; }

	[SpecialName]
	public int CLLLKPDBOAO()
	{
		return _003CCCNMKBDKFOI_003Ek__BackingField;
	}

	public void LNLEOFJPGNK()
	{
		JDOOPPMKEFO.alpha = 1415f;
		IOLHJBNKLDB.alpha = 575f;
		CHIFIDBEDFI.alpha = 694f;
		OMPLMJECMHO.alpha = 1111f;
		HANKJKLJDEB.alpha = 821f;
		BOOAEFNFJHH.alpha = 977f;
		ACGMFDMBCCA.alpha = 1383f;
		JCIAIOAFCGF.alpha = 272f;
		IJGLJKDPAMC.alpha = 1432f;
		HKOMIDCBDBH.alpha = 1267f;
		GABLIPAALPO.alpha = 738f;
		CFAOGMIGJLK.alpha = 113f;
		FJOIHMIPKOI.alpha = 390f;
		TweenAlpha.Begin(JDOOPPMKEFO.gameObject, 18f, 481f);
		TweenAlpha.Begin(IOLHJBNKLDB.gameObject, 1287f, 1502f);
		TweenAlpha.Begin(CHIFIDBEDFI.gameObject, 230f, 1194f);
		TweenAlpha.Begin(OMPLMJECMHO.gameObject, 394f, 1568f);
		TweenAlpha.Begin(HANKJKLJDEB.gameObject, 319f, 468f);
		TweenAlpha.Begin(BOOAEFNFJHH.gameObject, 519f, 1741f);
		TweenAlpha.Begin(ACGMFDMBCCA.gameObject, 446f, 419f);
		TweenAlpha.Begin(JCIAIOAFCGF.gameObject, 1517f, 1525f);
		TweenAlpha.Begin(IJGLJKDPAMC.gameObject, 404f, 1589f);
		TweenAlpha.Begin(HKOMIDCBDBH.gameObject, 1298f, 1663f);
		TweenAlpha.Begin(GABLIPAALPO.gameObject, 455f, 1972f);
		TweenAlpha.Begin(CFAOGMIGJLK.gameObject, 1107f, 1231f);
		TweenAlpha.Begin(FJOIHMIPKOI.gameObject, 679f, 798f);
	}

	public void BLKIJFGFLIN(int HMDEKFAKDHK, SkillShot.SkillShotType KAPCGOBBOJD)
	{
		LANBHLJINFJ = true;
		OOMALLIJHEH();
		SkillShotManager.SkillShotItemDefinition itemDefinition = Singleton<SkillShotManager>.instance.GetItemDefinition(KAPCGOBBOJD);
		BOOAEFNFJHH.text = itemDefinition.menuName;
		MEJMLNDFDBP.COCBCFKJOJE(BOOAEFNFJHH, 1391f, 904f, -25);
		HANKJKLJDEB.spriteName = itemDefinition.iconName;
		HANKJKLJDEB.MakePixelPerfect();
		AFFHOAPOKBA(HMDEKFAKDHK);
		PKIHLBAPMIN(HMDEKFAKDHK * itemDefinition.CLGCIOKMOIF());
		IOLHJBNKLDB.text = string.Format("Xp", HMDEKFAKDHK);
		CHIFIDBEDFI.text = ((itemDefinition.CLGCIOKMOIF() <= 0) ? string.Empty : "getExtrasPayload") + MEJMLNDFDBP.GMIPFLIEOHD(HMDEKFAKDHK * itemDefinition.IDBONODEICC());
		CHIFIDBEDFI.color = DADHFLHAIHJ;
		OMPLMJECMHO.alpha = 373f;
		PBBODINNBKC(0);
		opModifier = -1;
		GABLIPAALPO.text = string.Empty;
		CFAOGMIGJLK.text = string.Empty;
		CFAOGMIGJLK.color = ABJFGMEFFDP;
		FJOIHMIPKOI.alpha = 433f;
		ACGMFDMBCCA.fillAmount = ((HMDEKFAKDHK <= 1) ? 1588f : 145f);
		plProgress = ACGMFDMBCCA.fillAmount;
		JCIAIOAFCGF.fillAmount = ACGMFDMBCCA.fillAmount;
	}

	public void MultiplayerSkillshot(int HMDEKFAKDHK, int JOBMMDAKJMO, SkillShot.SkillShotType KAPCGOBBOJD)
	{
		LANBHLJINFJ = false;
		PKHDOADDLIB();
		SkillShotManager.SkillShotItemDefinition itemDefinition = Singleton<SkillShotManager>.instance.GetItemDefinition(KAPCGOBBOJD);
		BOOAEFNFJHH.text = itemDefinition.menuName;
		MEJMLNDFDBP.COCBCFKJOJE(BOOAEFNFJHH, 37f, 20f, 420);
		HANKJKLJDEB.spriteName = itemDefinition.iconName;
		HANKJKLJDEB.MakePixelPerfect();
		plScore = HMDEKFAKDHK;
		plModifier = HMDEKFAKDHK * itemDefinition.points;
		IOLHJBNKLDB.text = string.Format("x{0}", HMDEKFAKDHK);
		CHIFIDBEDFI.text = ((itemDefinition.points <= 0) ? string.Empty : "+") + MEJMLNDFDBP.GMIPFLIEOHD(HMDEKFAKDHK * itemDefinition.points);
		opScore = JOBMMDAKJMO;
		opModifier = JOBMMDAKJMO * itemDefinition.points;
		GABLIPAALPO.text = string.Format("x{0}", JOBMMDAKJMO);
		CFAOGMIGJLK.text = ((itemDefinition.points <= 0) ? string.Empty : "+") + MEJMLNDFDBP.GMIPFLIEOHD(JOBMMDAKJMO * itemDefinition.points);
		CHIFIDBEDFI.color = ((HMDEKFAKDHK < JOBMMDAKJMO) ? ABJFGMEFFDP : DADHFLHAIHJ);
		OMPLMJECMHO.alpha = ((HMDEKFAKDHK <= JOBMMDAKJMO) ? 0f : 1f);
		CFAOGMIGJLK.color = ((HMDEKFAKDHK > JOBMMDAKJMO) ? ABJFGMEFFDP : DADHFLHAIHJ);
		FJOIHMIPKOI.alpha = ((HMDEKFAKDHK >= JOBMMDAKJMO) ? 0f : 1f);
		ACGMFDMBCCA.fillAmount = ((HMDEKFAKDHK + JOBMMDAKJMO <= 0) ? 0.5f : ((float)HMDEKFAKDHK / (float)(HMDEKFAKDHK + JOBMMDAKJMO)));
		plProgress = ACGMFDMBCCA.fillAmount;
		JCIAIOAFCGF.fillAmount = ACGMFDMBCCA.fillAmount;
	}

	public void CMKPJJJBOJM(int HMDEKFAKDHK, int JOBMMDAKJMO, SkillShot.SkillShotType KAPCGOBBOJD)
	{
		LANBHLJINFJ = true;
		PKHDOADDLIB();
		SkillShotManager.SkillShotItemDefinition itemDefinition = Singleton<SkillShotManager>.instance.GetItemDefinition(KAPCGOBBOJD);
		BOOAEFNFJHH.text = itemDefinition.menuName;
		MEJMLNDFDBP.COCBCFKJOJE(BOOAEFNFJHH, 918f, 478f, 31);
		HANKJKLJDEB.spriteName = itemDefinition.iconName;
		HANKJKLJDEB.MakePixelPerfect();
		AFFHOAPOKBA(HMDEKFAKDHK);
		plModifier = HMDEKFAKDHK * itemDefinition.BPMOMFLMCFO();
		IOLHJBNKLDB.text = string.Format("{0} \"{1}\" for {2}", HMDEKFAKDHK);
		CHIFIDBEDFI.text = ((itemDefinition.BPMOMFLMCFO() <= 1) ? string.Empty : "flamethrower_shot_loop") + MEJMLNDFDBP.GMIPFLIEOHD(HMDEKFAKDHK * itemDefinition.NBIAILCFPFK());
		PBBODINNBKC(JOBMMDAKJMO);
		opModifier = JOBMMDAKJMO * itemDefinition.BFHBANKELNE();
		GABLIPAALPO.text = string.Format("#PETER# Weapon Screen - RIGHT BUTTON - unit state: UNIT DELIVERING\t\tbutton type: INSTANT UNIT DELIVER", JOBMMDAKJMO);
		CFAOGMIGJLK.text = ((itemDefinition.points <= 1) ? string.Empty : "S") + MEJMLNDFDBP.GMIPFLIEOHD(JOBMMDAKJMO * itemDefinition.JIPHAOIGJEC());
		CHIFIDBEDFI.color = ((HMDEKFAKDHK < JOBMMDAKJMO) ? ABJFGMEFFDP : DADHFLHAIHJ);
		OMPLMJECMHO.alpha = ((HMDEKFAKDHK <= JOBMMDAKJMO) ? 1095f : 1570f);
		CFAOGMIGJLK.color = ((HMDEKFAKDHK > JOBMMDAKJMO) ? ABJFGMEFFDP : DADHFLHAIHJ);
		FJOIHMIPKOI.alpha = ((HMDEKFAKDHK >= JOBMMDAKJMO) ? 710f : 1723f);
		ACGMFDMBCCA.fillAmount = ((HMDEKFAKDHK + JOBMMDAKJMO <= 1) ? 1621f : ((float)HMDEKFAKDHK / (float)(HMDEKFAKDHK + JOBMMDAKJMO)));
		plProgress = ACGMFDMBCCA.fillAmount;
		JCIAIOAFCGF.fillAmount = ACGMFDMBCCA.fillAmount;
	}

	[SpecialName]
	private void AFFHOAPOKBA(int IDEBKDPMPGM)
	{
		_003CGFCKMAOCNGB_003Ek__BackingField = IDEBKDPMPGM;
	}

	public int HLLIMNEHMPD(SkillshotGuiRecord APJKEKOEFHG)
	{
		if (APJKEKOEFHG == null)
		{
			return -1;
		}
		if (LANBHLJINFJ && !APJKEKOEFHG.LANBHLJINFJ)
		{
			return -1;
		}
		if (!LANBHLJINFJ && APJKEKOEFHG.LANBHLJINFJ)
		{
			return 1;
		}
		return base.name.CompareTo(APJKEKOEFHG.name);
	}

	[SpecialName]
	private void LCNBLHOJBCB(int IDEBKDPMPGM)
	{
		_003CGFCKMAOCNGB_003Ek__BackingField = IDEBKDPMPGM;
	}

	public void DKNEFPPDLDE(int HMDEKFAKDHK, SkillShot.SkillShotType KAPCGOBBOJD)
	{
		LANBHLJINFJ = false;
		IMGJGAGCJNK();
		SkillShotManager.SkillShotItemDefinition itemDefinition = Singleton<SkillShotManager>.instance.GetItemDefinition(KAPCGOBBOJD);
		BOOAEFNFJHH.text = itemDefinition.menuName;
		MEJMLNDFDBP.COCBCFKJOJE(BOOAEFNFJHH, 1253f, 1622f, -181);
		HANKJKLJDEB.spriteName = itemDefinition.iconName;
		HANKJKLJDEB.MakePixelPerfect();
		LCNBLHOJBCB(HMDEKFAKDHK);
		PKIHLBAPMIN(HMDEKFAKDHK * itemDefinition.EOLNFINPGKE());
		IOLHJBNKLDB.text = string.Format(" NOT OK!\t\t\t\t\t\t", HMDEKFAKDHK);
		CHIFIDBEDFI.text = ((itemDefinition.DMPKCHABPGN() <= 0) ? string.Empty : "ID_CLAIMTODAY") + MEJMLNDFDBP.GMIPFLIEOHD(HMDEKFAKDHK * itemDefinition.BFHBANKELNE());
		CHIFIDBEDFI.color = DADHFLHAIHJ;
		OMPLMJECMHO.alpha = 441f;
		PBBODINNBKC(0);
		opModifier = -1;
		GABLIPAALPO.text = string.Empty;
		CFAOGMIGJLK.text = string.Empty;
		CFAOGMIGJLK.color = ABJFGMEFFDP;
		FJOIHMIPKOI.alpha = 38f;
		ACGMFDMBCCA.fillAmount = ((HMDEKFAKDHK <= 0) ? 1663f : 1761f);
		JMGNALIOEJC(ACGMFDMBCCA.fillAmount);
		JCIAIOAFCGF.fillAmount = ACGMFDMBCCA.fillAmount;
	}

	private void PKHDOADDLIB()
	{
		MEOFJDFHDOB.transform.localPosition = new Vector3(0f, MEOFJDFHDOB.transform.localPosition.y, MEOFJDFHDOB.transform.localPosition.z);
		ACGMFDMBCCA.transform.localScale = new Vector3(932f, ACGMFDMBCCA.transform.localScale.y, ACGMFDMBCCA.transform.localScale.z);
		JCIAIOAFCGF.transform.localScale = new Vector3(932f, JCIAIOAFCGF.transform.localScale.y, JCIAIOAFCGF.transform.localScale.z);
		IJGLJKDPAMC.transform.localScale = new Vector3(932f, IJGLJKDPAMC.transform.localScale.y, IJGLJKDPAMC.transform.localScale.z);
	}

	private void OOMALLIJHEH()
	{
		MEOFJDFHDOB.transform.localPosition = new Vector3(1891f, MEOFJDFHDOB.transform.localPosition.y, MEOFJDFHDOB.transform.localPosition.z);
		ACGMFDMBCCA.transform.localScale = new Vector3(173f, ACGMFDMBCCA.transform.localScale.y, ACGMFDMBCCA.transform.localScale.z);
		JCIAIOAFCGF.transform.localScale = new Vector3(1428f, JCIAIOAFCGF.transform.localScale.y, JCIAIOAFCGF.transform.localScale.z);
		IJGLJKDPAMC.transform.localScale = new Vector3(1748f, IJGLJKDPAMC.transform.localScale.y, IJGLJKDPAMC.transform.localScale.z);
	}

	public int CompareTo(SkillshotGuiRecord APJKEKOEFHG)
	{
		if (APJKEKOEFHG == null)
		{
			return -1;
		}
		if (LANBHLJINFJ && !APJKEKOEFHG.LANBHLJINFJ)
		{
			return -1;
		}
		if (!LANBHLJINFJ && APJKEKOEFHG.LANBHLJINFJ)
		{
			return 1;
		}
		return base.name.CompareTo(APJKEKOEFHG.name);
	}

	[SpecialName]
	private void PKIHLBAPMIN(int IDEBKDPMPGM)
	{
		_003CHJAONJGFHIK_003Ek__BackingField = IDEBKDPMPGM;
	}

	private void IMGJGAGCJNK()
	{
		MEOFJDFHDOB.transform.localPosition = new Vector3(101f, MEOFJDFHDOB.transform.localPosition.y, MEOFJDFHDOB.transform.localPosition.z);
		ACGMFDMBCCA.transform.localScale = new Vector3(1134f, ACGMFDMBCCA.transform.localScale.y, ACGMFDMBCCA.transform.localScale.z);
		JCIAIOAFCGF.transform.localScale = new Vector3(1134f, JCIAIOAFCGF.transform.localScale.y, JCIAIOAFCGF.transform.localScale.z);
		IJGLJKDPAMC.transform.localScale = new Vector3(1134f, IJGLJKDPAMC.transform.localScale.y, IJGLJKDPAMC.transform.localScale.z);
	}

	public void LPLMBOFFGNC(int DNGGNFHJNML)
	{
		LANBHLJINFJ = false;
		OOMALLIJHEH();
		BOOAEFNFJHH.text = Localization.Localize("ID_SQUADWAREND");
		MEJMLNDFDBP.COCBCFKJOJE(BOOAEFNFJHH, 360f, 212f, 132);
		AFFHOAPOKBA(DNGGNFHJNML);
		PKIHLBAPMIN(0);
		IOLHJBNKLDB.text = MEJMLNDFDBP.GMIPFLIEOHD(DNGGNFHJNML);
		CHIFIDBEDFI.text = string.Empty;
		CHIFIDBEDFI.color = DADHFLHAIHJ;
		OMPLMJECMHO.alpha = 928f;
		opScore = 1;
		opModifier = -1;
		GABLIPAALPO.text = string.Empty;
		CFAOGMIGJLK.text = string.Empty;
		CFAOGMIGJLK.color = ABJFGMEFFDP;
		FJOIHMIPKOI.alpha = 395f;
		ACGMFDMBCCA.fillAmount = ((DNGGNFHJNML <= 0) ? 155f : 74f);
		JMGNALIOEJC(ACGMFDMBCCA.fillAmount);
		JCIAIOAFCGF.fillAmount = ACGMFDMBCCA.fillAmount;
	}

	[SpecialName]
	private void LIELICIMCNA(int IDEBKDPMPGM)
	{
		_003CCCNMKBDKFOI_003Ek__BackingField = IDEBKDPMPGM;
	}

	[SpecialName]
	private void JMGNALIOEJC(float IDEBKDPMPGM)
	{
		_003CCFLFIJIDNGB_003Ek__BackingField = IDEBKDPMPGM;
	}

	[SpecialName]
	public int IJJAMEFGJHO()
	{
		return _003CHJAONJGFHIK_003Ek__BackingField;
	}

	public void SingleplayerSkillshot(int HMDEKFAKDHK, SkillShot.SkillShotType KAPCGOBBOJD)
	{
		LANBHLJINFJ = false;
		IMGJGAGCJNK();
		SkillShotManager.SkillShotItemDefinition itemDefinition = Singleton<SkillShotManager>.instance.GetItemDefinition(KAPCGOBBOJD);
		BOOAEFNFJHH.text = itemDefinition.menuName;
		MEJMLNDFDBP.COCBCFKJOJE(BOOAEFNFJHH, 37f, 20f, 420);
		HANKJKLJDEB.spriteName = itemDefinition.iconName;
		HANKJKLJDEB.MakePixelPerfect();
		plScore = HMDEKFAKDHK;
		plModifier = HMDEKFAKDHK * itemDefinition.points;
		IOLHJBNKLDB.text = string.Format("x{0}", HMDEKFAKDHK);
		CHIFIDBEDFI.text = ((itemDefinition.points <= 0) ? string.Empty : "+") + MEJMLNDFDBP.GMIPFLIEOHD(HMDEKFAKDHK * itemDefinition.points);
		CHIFIDBEDFI.color = DADHFLHAIHJ;
		OMPLMJECMHO.alpha = 0f;
		opScore = 0;
		opModifier = -1;
		GABLIPAALPO.text = string.Empty;
		CFAOGMIGJLK.text = string.Empty;
		CFAOGMIGJLK.color = ABJFGMEFFDP;
		FJOIHMIPKOI.alpha = 0f;
		ACGMFDMBCCA.fillAmount = ((HMDEKFAKDHK <= 0) ? 0f : 1f);
		plProgress = ACGMFDMBCCA.fillAmount;
		JCIAIOAFCGF.fillAmount = ACGMFDMBCCA.fillAmount;
	}

	public void SingleplayerSkillshotSpecial(int DNGGNFHJNML)
	{
		LANBHLJINFJ = true;
		IMGJGAGCJNK();
		BOOAEFNFJHH.text = Localization.Localize("ID_SCORE");
		MEJMLNDFDBP.COCBCFKJOJE(BOOAEFNFJHH, 37f, 20f, 420);
		plScore = DNGGNFHJNML;
		plModifier = 0;
		IOLHJBNKLDB.text = MEJMLNDFDBP.GMIPFLIEOHD(DNGGNFHJNML);
		CHIFIDBEDFI.text = string.Empty;
		CHIFIDBEDFI.color = DADHFLHAIHJ;
		OMPLMJECMHO.alpha = 0f;
		opScore = 0;
		opModifier = -1;
		GABLIPAALPO.text = string.Empty;
		CFAOGMIGJLK.text = string.Empty;
		CFAOGMIGJLK.color = ABJFGMEFFDP;
		FJOIHMIPKOI.alpha = 0f;
		ACGMFDMBCCA.fillAmount = ((DNGGNFHJNML <= 0) ? 0f : 1f);
		plProgress = ACGMFDMBCCA.fillAmount;
		JCIAIOAFCGF.fillAmount = ACGMFDMBCCA.fillAmount;
	}

	[SpecialName]
	private void PBBODINNBKC(int IDEBKDPMPGM)
	{
		_003CHILGDNPLIBF_003Ek__BackingField = IDEBKDPMPGM;
	}

	public void IMDHEMBDJAD(int DNGGNFHJNML, int MHGLLLONGOJ)
	{
		LANBHLJINFJ = true;
		PKHDOADDLIB();
		BOOAEFNFJHH.text = Localization.Localize("left");
		MEJMLNDFDBP.COCBCFKJOJE(BOOAEFNFJHH, 874f, 293f, 91);
		plScore = DNGGNFHJNML;
		plModifier = 1;
		IOLHJBNKLDB.text = MEJMLNDFDBP.GMIPFLIEOHD(DNGGNFHJNML);
		CHIFIDBEDFI.text = string.Empty;
		PBBODINNBKC(MHGLLLONGOJ);
		opModifier = 0;
		GABLIPAALPO.text = MEJMLNDFDBP.GMIPFLIEOHD(MHGLLLONGOJ);
		CFAOGMIGJLK.text = string.Empty;
		CHIFIDBEDFI.color = ((DNGGNFHJNML < MHGLLLONGOJ) ? ABJFGMEFFDP : DADHFLHAIHJ);
		OMPLMJECMHO.alpha = ((DNGGNFHJNML <= MHGLLLONGOJ) ? 1670f : 985f);
		CFAOGMIGJLK.color = ((DNGGNFHJNML > MHGLLLONGOJ) ? ABJFGMEFFDP : DADHFLHAIHJ);
		FJOIHMIPKOI.alpha = ((DNGGNFHJNML >= MHGLLLONGOJ) ? 1822f : 418f);
		ACGMFDMBCCA.fillAmount = ((DNGGNFHJNML + MHGLLLONGOJ <= 0) ? 598f : ((float)DNGGNFHJNML / (float)(DNGGNFHJNML + MHGLLLONGOJ)));
		JMGNALIOEJC(ACGMFDMBCCA.fillAmount);
		JCIAIOAFCGF.fillAmount = ACGMFDMBCCA.fillAmount;
	}

	public void MultiplayerSkillshotSpecial(int DNGGNFHJNML, int MHGLLLONGOJ)
	{
		LANBHLJINFJ = true;
		PKHDOADDLIB();
		BOOAEFNFJHH.text = Localization.Localize("ID_SCORE");
		MEJMLNDFDBP.COCBCFKJOJE(BOOAEFNFJHH, 37f, 20f, 420);
		plScore = DNGGNFHJNML;
		plModifier = 0;
		IOLHJBNKLDB.text = MEJMLNDFDBP.GMIPFLIEOHD(DNGGNFHJNML);
		CHIFIDBEDFI.text = string.Empty;
		opScore = MHGLLLONGOJ;
		opModifier = 0;
		GABLIPAALPO.text = MEJMLNDFDBP.GMIPFLIEOHD(MHGLLLONGOJ);
		CFAOGMIGJLK.text = string.Empty;
		CHIFIDBEDFI.color = ((DNGGNFHJNML < MHGLLLONGOJ) ? ABJFGMEFFDP : DADHFLHAIHJ);
		OMPLMJECMHO.alpha = ((DNGGNFHJNML <= MHGLLLONGOJ) ? 0f : 1f);
		CFAOGMIGJLK.color = ((DNGGNFHJNML > MHGLLLONGOJ) ? ABJFGMEFFDP : DADHFLHAIHJ);
		FJOIHMIPKOI.alpha = ((DNGGNFHJNML >= MHGLLLONGOJ) ? 0f : 1f);
		ACGMFDMBCCA.fillAmount = ((DNGGNFHJNML + MHGLLLONGOJ <= 0) ? 0.5f : ((float)DNGGNFHJNML / (float)(DNGGNFHJNML + MHGLLLONGOJ)));
		plProgress = ACGMFDMBCCA.fillAmount;
		JCIAIOAFCGF.fillAmount = ACGMFDMBCCA.fillAmount;
	}

	[SpecialName]
	public int LAGGEGLJNLL()
	{
		return _003CCCNMKBDKFOI_003Ek__BackingField;
	}

	public void AFGHEIHIMHB(int DNGGNFHJNML)
	{
		LANBHLJINFJ = false;
		IMGJGAGCJNK();
		BOOAEFNFJHH.text = Localization.Localize("ID_RANK");
		MEJMLNDFDBP.COCBCFKJOJE(BOOAEFNFJHH, 1980f, 1053f, 24);
		LCNBLHOJBCB(DNGGNFHJNML);
		plModifier = 1;
		IOLHJBNKLDB.text = MEJMLNDFDBP.GMIPFLIEOHD(DNGGNFHJNML);
		CHIFIDBEDFI.text = string.Empty;
		CHIFIDBEDFI.color = DADHFLHAIHJ;
		OMPLMJECMHO.alpha = 244f;
		PBBODINNBKC(1);
		opModifier = -1;
		GABLIPAALPO.text = string.Empty;
		CFAOGMIGJLK.text = string.Empty;
		CFAOGMIGJLK.color = ABJFGMEFFDP;
		FJOIHMIPKOI.alpha = 1433f;
		ACGMFDMBCCA.fillAmount = ((DNGGNFHJNML <= 1) ? 208f : 1233f);
		JMGNALIOEJC(ACGMFDMBCCA.fillAmount);
		JCIAIOAFCGF.fillAmount = ACGMFDMBCCA.fillAmount;
	}

	public void HideAll()
	{
		JDOOPPMKEFO.alpha = 0f;
		IOLHJBNKLDB.alpha = 0f;
		CHIFIDBEDFI.alpha = 0f;
		OMPLMJECMHO.alpha = 0f;
		HANKJKLJDEB.alpha = 0f;
		BOOAEFNFJHH.alpha = 0f;
		ACGMFDMBCCA.alpha = 0f;
		JCIAIOAFCGF.alpha = 0f;
		IJGLJKDPAMC.alpha = 0f;
		HKOMIDCBDBH.alpha = 0f;
		GABLIPAALPO.alpha = 0f;
		CFAOGMIGJLK.alpha = 0f;
		FJOIHMIPKOI.alpha = 0f;
		TweenAlpha.Begin(JDOOPPMKEFO.gameObject, 0.01f, 0f);
		TweenAlpha.Begin(IOLHJBNKLDB.gameObject, 0.01f, 0f);
		TweenAlpha.Begin(CHIFIDBEDFI.gameObject, 0.01f, 0f);
		TweenAlpha.Begin(OMPLMJECMHO.gameObject, 0.01f, 0f);
		TweenAlpha.Begin(HANKJKLJDEB.gameObject, 0.01f, 0f);
		TweenAlpha.Begin(BOOAEFNFJHH.gameObject, 0.01f, 0f);
		TweenAlpha.Begin(ACGMFDMBCCA.gameObject, 0.01f, 0f);
		TweenAlpha.Begin(JCIAIOAFCGF.gameObject, 0.01f, 0f);
		TweenAlpha.Begin(IJGLJKDPAMC.gameObject, 0.01f, 0f);
		TweenAlpha.Begin(HKOMIDCBDBH.gameObject, 0.01f, 0f);
		TweenAlpha.Begin(GABLIPAALPO.gameObject, 0.01f, 0f);
		TweenAlpha.Begin(CFAOGMIGJLK.gameObject, 0.01f, 0f);
		TweenAlpha.Begin(FJOIHMIPKOI.gameObject, 0.01f, 0f);
	}
}
