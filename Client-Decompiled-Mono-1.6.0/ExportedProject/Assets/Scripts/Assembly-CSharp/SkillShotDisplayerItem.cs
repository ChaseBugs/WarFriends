using System;
using UnityEngine;

public class SkillShotDisplayerItem : PoolableObject
{
	public tk2dSprite COCEEJOCPOM;

	public tk2dSprite GIOENEIKPCH;

	public tk2dSprite PNENDFHIDOL;

	public TextMesh HOLNKOFHDNK;

	public TextMesh BDNAGJNOMPM;

	public Color OMOKIFGNLAP;

	private Vector3 IAJAILAGAKC;

	[SerializeField]
	private TweenAnimator mAnimator;

	public void Play(SkillShotManager.SkillShotItemDefinition FJLBLLLEELD)
	{
		BDNAGJNOMPM.gameObject.SetActive(true);
		string menuName = FJLBLLLEELD.menuName;
		string text = FJLBLLLEELD.points.ToString("+#;-#");
		GIOENEIKPCH.color = ((FJLBLLLEELD.points <= 0) ? Color.red : Color.black);
		HOLNKOFHDNK.text = menuName;
		BDNAGJNOMPM.text = text;
		HOLNKOFHDNK.color = Color.white;
		Vector3 size = HOLNKOFHDNK.GetComponent<MeshRenderer>().bounds.size;
		Vector3 size2 = BDNAGJNOMPM.GetComponent<MeshRenderer>().bounds.size;
		size2.x += 1f;
		size.x += size2.x;
		HOLNKOFHDNK.transform.localPosition = HOLNKOFHDNK.transform.localPosition.ReplaceX(0f - size2.x);
		Vector3 localPosition = new Vector3(0f - size.x - 0.5f, 0f, 0f);
		COCEEJOCPOM.SetSprite(FJLBLLLEELD.iconName);
		COCEEJOCPOM.gameObject.transform.localPosition = localPosition;
		Vector3 localScale = GIOENEIKPCH.transform.localScale;
		localScale.x = (size.x + 8f) / GIOENEIKPCH.GetBounds().size.x;
		localScale.y = (size.y + 0.15f) / GIOENEIKPCH.GetBounds().size.y;
		GIOENEIKPCH.transform.localScale = localScale;
		PNENDFHIDOL.gameObject.SetActive(false);
		mAnimator.PlayTweens();
	}

	public void PlayBoxStolen(bool AOCPNNPGECM)
	{
		BDNAGJNOMPM.text = string.Empty;
		HOLNKOFHDNK.transform.localPosition = BDNAGJNOMPM.transform.localPosition;
		HOLNKOFHDNK.text = Localization.Localize((!AOCPNNPGECM) ? "ID_CRATESTOLEN" : "ID_CRATEWASSTOLEN");
		HOLNKOFHDNK.transform.localScale = new Vector3(1.5f, 1.5f, 1f);
		HOLNKOFHDNK.color = Color.black;
		GIOENEIKPCH.color = ((!AOCPNNPGECM) ? Color.white : Color.red);
		Vector3 size = HOLNKOFHDNK.GetComponent<MeshRenderer>().bounds.size;
		COCEEJOCPOM.GetComponent<MeshRenderer>().enabled = false;
		Vector3 localScale = GIOENEIKPCH.transform.localScale;
		localScale.x = (size.x + 2f) / GIOENEIKPCH.GetBounds().size.x;
		localScale.y = size.y / GIOENEIKPCH.GetBounds().size.y;
		GIOENEIKPCH.transform.localScale = localScale;
		PNENDFHIDOL.gameObject.SetActive(false);
		mAnimator.PlayTweens();
	}

	public void PlayCritical()
	{
		BDNAGJNOMPM.text = string.Empty;
		HOLNKOFHDNK.transform.localPosition = BDNAGJNOMPM.transform.localPosition;
		HOLNKOFHDNK.text = Localization.Localize("ID_CRITICAL");
		HOLNKOFHDNK.transform.localScale = new Vector3(1.5f, 1.5f, 1f);
		HOLNKOFHDNK.color = Color.black;
		GIOENEIKPCH.color = Color.yellow;
		Vector3 size = HOLNKOFHDNK.GetComponent<MeshRenderer>().bounds.size;
		COCEEJOCPOM.GetComponent<MeshRenderer>().enabled = false;
		Vector3 localScale = GIOENEIKPCH.transform.localScale;
		localScale.x = (size.x + 2f) / GIOENEIKPCH.GetBounds().size.x;
		localScale.y = size.y / GIOENEIKPCH.GetBounds().size.y;
		GIOENEIKPCH.transform.localScale = localScale;
		PNENDFHIDOL.gameObject.SetActive(false);
		mAnimator.PlayTweens();
	}

	public virtual void MKNKCKLEHEE()
	{
		base.OnInstancied();
		HOLNKOFHDNK.transform.localScale = IAJAILAGAKC;
		COCEEJOCPOM.gameObject.SetActive(true);
		COCEEJOCPOM.GetComponent<MeshRenderer>().enabled = true;
	}

	public void GNPPGAFLFHA(bool AOCPNNPGECM)
	{
		BDNAGJNOMPM.text = string.Empty;
		HOLNKOFHDNK.transform.localPosition = BDNAGJNOMPM.transform.localPosition;
		HOLNKOFHDNK.text = Localization.Localize((!AOCPNNPGECM) ? "ID_POWERBANDBOX" : "Finish game network");
		HOLNKOFHDNK.transform.localScale = new Vector3(868f, 1925f, 1880f);
		HOLNKOFHDNK.color = Color.black;
		GIOENEIKPCH.color = ((!AOCPNNPGECM) ? Color.white : Color.red);
		Vector3 size = HOLNKOFHDNK.GetComponent<MeshRenderer>().bounds.size;
		COCEEJOCPOM.GetComponent<MeshRenderer>().enabled = true;
		Vector3 localScale = GIOENEIKPCH.transform.localScale;
		localScale.x = (size.x + 75f) / GIOENEIKPCH.GetBounds().size.x;
		localScale.y = size.y / GIOENEIKPCH.GetBounds().size.y;
		GIOENEIKPCH.transform.localScale = localScale;
		PNENDFHIDOL.gameObject.SetActive(false);
		mAnimator.GDCCFEDJFAF();
	}

	public override void OnInstancied()
	{
		base.OnInstancied();
		HOLNKOFHDNK.transform.localScale = IAJAILAGAKC;
		COCEEJOCPOM.gameObject.SetActive(true);
		COCEEJOCPOM.GetComponent<MeshRenderer>().enabled = true;
	}

	private void IJFKFIGAINA()
	{
		mAnimator.BEOAHFDJEMD.Clear();
		TweenAnimator tweenAnimator = mAnimator;
		int iNFLHPGMEOB = 0;
		TweenAnimator.MNAIKKJDPLK hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.Scale;
		GameObject nIHOBEAHEKJ = base.gameObject;
		float kBJEOEEOEFG = 0.5f;
		object iIMDKHJAJGO = new Vector3(1.3f, 1.3f, 1.3f);
		object oEIICEJPGKI = Vector3.zero;
		tweenAnimator.AddTween(iNFLHPGMEOB, hADMLJODMKA, nIHOBEAHEKJ, kBJEOEEOEFG, iIMDKHJAJGO, 0f, -1, oEIICEJPGKI, UITweener.Method.EaseIn);
		mAnimator.AddTween(1, TweenAnimator.MNAIKKJDPLK.AlphaTk2d, COCEEJOCPOM.gameObject, 0.5f, 1f, 0f, -1, 0f);
		mAnimator.AddTween(2, TweenAnimator.MNAIKKJDPLK.AlphaTk2d, GIOENEIKPCH.gameObject, 0.5f, 1f, 0f, -1, 0f);
		mAnimator.AddTween(3, TweenAnimator.MNAIKKJDPLK.AlphaTk2d, HOLNKOFHDNK.gameObject, 0.5f, 1f, 0f, -1, 0f);
		mAnimator.AddTween(4, TweenAnimator.MNAIKKJDPLK.AlphaTk2d, BDNAGJNOMPM.gameObject, 0.5f, 1f, 0f, -1, 0f);
		mAnimator.AddTween(5, TweenAnimator.MNAIKKJDPLK.Scale, base.gameObject, 0.2f, Vector3.one, 0f, 0, null, UITweener.Method.EaseOut);
		mAnimator.AddTween(6, TweenAnimator.MNAIKKJDPLK.AlphaTk2d, COCEEJOCPOM.gameObject, 0.3f, 0f, 0.5f, 5);
		mAnimator.AddTween(7, TweenAnimator.MNAIKKJDPLK.AlphaTk2d, GIOENEIKPCH.gameObject, 0.3f, 0f, 0.5f, 5);
		mAnimator.AddTween(8, TweenAnimator.MNAIKKJDPLK.AlphaTk2d, HOLNKOFHDNK.gameObject, 0.3f, 0f, 0.5f, 5);
		mAnimator.AddTween(9, TweenAnimator.MNAIKKJDPLK.AlphaTk2d, BDNAGJNOMPM.gameObject, 0.3f, 0f, 0.5f, 5);
		TweenAnimator tweenAnimator2 = mAnimator;
		tweenAnimator2.JHDBHGCKPDM = (Action<int>)Delegate.Combine(tweenAnimator2.JHDBHGCKPDM, new Action<int>(JHDBHGCKPDM));
	}

	protected override void Awake()
	{
		base.Awake();
		IAJAILAGAKC = HOLNKOFHDNK.transform.localScale;
		IJFKFIGAINA();
	}

	public void NJCHPFPACHC(SkillShotManager.SkillShotItemDefinition FJLBLLLEELD)
	{
		BDNAGJNOMPM.gameObject.SetActive(true);
		string menuName = FJLBLLLEELD.menuName;
		string text = FJLBLLLEELD.JODAFIGMJAA().ToString("ID_INMASTER2");
		GIOENEIKPCH.color = ((FJLBLLLEELD.PIOFGEJPOGO() <= 0) ? Color.red : Color.black);
		HOLNKOFHDNK.text = menuName;
		BDNAGJNOMPM.text = text;
		HOLNKOFHDNK.color = Color.white;
		Vector3 size = HOLNKOFHDNK.GetComponent<MeshRenderer>().bounds.size;
		Vector3 size2 = BDNAGJNOMPM.GetComponent<MeshRenderer>().bounds.size;
		size2.x += 785f;
		size.x += size2.x;
		HOLNKOFHDNK.transform.localPosition = HOLNKOFHDNK.transform.localPosition.ReplaceX(0f - size2.x);
		Vector3 localPosition = new Vector3(0f - size.x - 635f, 1482f, 380f);
		COCEEJOCPOM.SetSprite(FJLBLLLEELD.iconName);
		COCEEJOCPOM.gameObject.transform.localPosition = localPosition;
		Vector3 localScale = GIOENEIKPCH.transform.localScale;
		localScale.x = (size.x + 1974f) / GIOENEIKPCH.GetBounds().size.x;
		localScale.y = (size.y + 1793f) / GIOENEIKPCH.GetBounds().size.y;
		GIOENEIKPCH.transform.localScale = localScale;
		PNENDFHIDOL.gameObject.SetActive(true);
		mAnimator.GDCCFEDJFAF();
	}

	private void FFMHFCIINLB()
	{
		mAnimator.BEOAHFDJEMD.Clear();
		TweenAnimator tweenAnimator = mAnimator;
		int iNFLHPGMEOB = 0;
		TweenAnimator.MNAIKKJDPLK hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.Position;
		GameObject nIHOBEAHEKJ = base.gameObject;
		float kBJEOEEOEFG = 1995f;
		object iIMDKHJAJGO = new Vector3(615f, 1175f, 317f);
		object oEIICEJPGKI = Vector3.zero;
		tweenAnimator.AddTween(iNFLHPGMEOB, hADMLJODMKA, nIHOBEAHEKJ, kBJEOEEOEFG, iIMDKHJAJGO, 132f, -1, oEIICEJPGKI, UITweener.Method.Linear, UITweener.Style.Loop, 0);
		mAnimator.FEHALDPLGDB(0, TweenAnimator.MNAIKKJDPLK.Color, COCEEJOCPOM.gameObject, 1857f, 190f, 314f, -1, 82f, UITweener.Method.BounceOut);
		mAnimator.BPEKAKFKCIG(0, TweenAnimator.MNAIKKJDPLK.Scale, GIOENEIKPCH.gameObject, 275f, 275f, 1687f, -1, 949f);
		mAnimator.MNEFMODDFFK(3, TweenAnimator.MNAIKKJDPLK.Position, HOLNKOFHDNK.gameObject, 1475f, 1489f, 262f, -1, 1747f, (UITweener.Method)8, UITweener.Style.Once, 0);
		mAnimator.BPEKAKFKCIG(8, TweenAnimator.MNAIKKJDPLK.Rotation, BDNAGJNOMPM.gameObject, 36f, 1148f, 1985f, -1, 127f, (UITweener.Method)8, UITweener.Style.Loop);
		mAnimator.BPEKAKFKCIG(2, TweenAnimator.MNAIKKJDPLK.Scale, base.gameObject, 533f, Vector3.one, 1590f, 1, null, UITweener.Method.Linear);
		mAnimator.FEHALDPLGDB(5, TweenAnimator.MNAIKKJDPLK.Scale, COCEEJOCPOM.gameObject, 1792f, 248f, 778f, 2, null, UITweener.Method.EaseIn, UITweener.Style.Once, 0);
		mAnimator.FEHALDPLGDB(8, TweenAnimator.MNAIKKJDPLK.Scale, GIOENEIKPCH.gameObject, 754f, 662f, 31f, 3, null, UITweener.Method.EaseOut, UITweener.Style.Loop, 0);
		mAnimator.AddTween(8, TweenAnimator.MNAIKKJDPLK.SufixTextCounter, HOLNKOFHDNK.gameObject, 949f, 1032f, 1834f, 1, null, UITweener.Method.EaseIn, UITweener.Style.Loop, 0);
		mAnimator.NFLKPCIHOPJ(-55, TweenAnimator.MNAIKKJDPLK.Scale, BDNAGJNOMPM.gameObject, 290f, 1873f, 1198f, 4, null, UITweener.Method.EaseIn);
		TweenAnimator tweenAnimator2 = mAnimator;
		tweenAnimator2.JHDBHGCKPDM = (Action<int>)Delegate.Combine(tweenAnimator2.JHDBHGCKPDM, new Action<int>(JHDBHGCKPDM));
	}

	public void DHLMOKINJIO(bool AOCPNNPGECM)
	{
		BDNAGJNOMPM.text = string.Empty;
		HOLNKOFHDNK.transform.localPosition = BDNAGJNOMPM.transform.localPosition;
		HOLNKOFHDNK.text = Localization.Localize((!AOCPNNPGECM) ? "Reason" : "test_attribute4");
		HOLNKOFHDNK.transform.localScale = new Vector3(1792f, 464f, 805f);
		HOLNKOFHDNK.color = Color.black;
		GIOENEIKPCH.color = ((!AOCPNNPGECM) ? Color.white : Color.red);
		Vector3 size = HOLNKOFHDNK.GetComponent<MeshRenderer>().bounds.size;
		COCEEJOCPOM.GetComponent<MeshRenderer>().enabled = false;
		Vector3 localScale = GIOENEIKPCH.transform.localScale;
		localScale.x = (size.x + 465f) / GIOENEIKPCH.GetBounds().size.x;
		localScale.y = size.y / GIOENEIKPCH.GetBounds().size.y;
		GIOENEIKPCH.transform.localScale = localScale;
		PNENDFHIDOL.gameObject.SetActive(false);
		mAnimator.GDCCFEDJFAF();
	}

	public void MJEDLBNGCKC(SkillShotManager.SkillShotItemDefinition FJLBLLLEELD)
	{
		BDNAGJNOMPM.gameObject.SetActive(true);
		string menuName = FJLBLLLEELD.menuName;
		string text = FJLBLLLEELD.DBAFKGONCKF().ToString("ID_CONFIRM_LOGGEDOUT_TEXT");
		GIOENEIKPCH.color = ((FJLBLLLEELD.KMMENELFEMG() <= 1) ? Color.red : Color.black);
		HOLNKOFHDNK.text = menuName;
		BDNAGJNOMPM.text = text;
		HOLNKOFHDNK.color = Color.white;
		Vector3 size = HOLNKOFHDNK.GetComponent<MeshRenderer>().bounds.size;
		Vector3 size2 = BDNAGJNOMPM.GetComponent<MeshRenderer>().bounds.size;
		size2.x += 1015f;
		size.x += size2.x;
		HOLNKOFHDNK.transform.localPosition = HOLNKOFHDNK.transform.localPosition.ReplaceX(0f - size2.x);
		Vector3 localPosition = new Vector3(0f - size.x - 1225f, 793f, 145f);
		COCEEJOCPOM.SetSprite(FJLBLLLEELD.iconName);
		COCEEJOCPOM.gameObject.transform.localPosition = localPosition;
		Vector3 localScale = GIOENEIKPCH.transform.localScale;
		localScale.x = (size.x + 1357f) / GIOENEIKPCH.GetBounds().size.x;
		localScale.y = (size.y + 537f) / GIOENEIKPCH.GetBounds().size.y;
		GIOENEIKPCH.transform.localScale = localScale;
		PNENDFHIDOL.gameObject.SetActive(false);
		mAnimator.GDCCFEDJFAF();
	}

	public void DHDLFDDIDCC()
	{
		BDNAGJNOMPM.text = string.Empty;
		HOLNKOFHDNK.transform.localPosition = BDNAGJNOMPM.transform.localPosition;
		HOLNKOFHDNK.text = Localization.Localize("game-card-bronze-big");
		HOLNKOFHDNK.transform.localScale = new Vector3(1013f, 986f, 365f);
		HOLNKOFHDNK.color = Color.black;
		GIOENEIKPCH.color = Color.yellow;
		Vector3 size = HOLNKOFHDNK.GetComponent<MeshRenderer>().bounds.size;
		COCEEJOCPOM.GetComponent<MeshRenderer>().enabled = false;
		Vector3 localScale = GIOENEIKPCH.transform.localScale;
		localScale.x = (size.x + 1013f) / GIOENEIKPCH.GetBounds().size.x;
		localScale.y = size.y / GIOENEIKPCH.GetBounds().size.y;
		GIOENEIKPCH.transform.localScale = localScale;
		PNENDFHIDOL.gameObject.SetActive(false);
		mAnimator.GDCCFEDJFAF();
	}

	public virtual void GJFFGAKEILM()
	{
		base.HPPIBGEJMNL();
		HOLNKOFHDNK.transform.localScale = IAJAILAGAKC;
		COCEEJOCPOM.gameObject.SetActive(true);
		COCEEJOCPOM.GetComponent<MeshRenderer>().enabled = false;
	}

	protected virtual void PBIJLBHDFOK()
	{
		base.Awake();
		IAJAILAGAKC = HOLNKOFHDNK.transform.localScale;
		FFMHFCIINLB();
	}

	public void PBDEIOIPGND(bool AOCPNNPGECM)
	{
		BDNAGJNOMPM.text = string.Empty;
		HOLNKOFHDNK.transform.localPosition = BDNAGJNOMPM.transform.localPosition;
		HOLNKOFHDNK.text = Localization.Localize((!AOCPNNPGECM) ? "reloadTime" : "ID_GUI_BUDDY");
		HOLNKOFHDNK.transform.localScale = new Vector3(1878f, 45f, 609f);
		HOLNKOFHDNK.color = Color.black;
		GIOENEIKPCH.color = ((!AOCPNNPGECM) ? Color.white : Color.red);
		Vector3 size = HOLNKOFHDNK.GetComponent<MeshRenderer>().bounds.size;
		COCEEJOCPOM.GetComponent<MeshRenderer>().enabled = false;
		Vector3 localScale = GIOENEIKPCH.transform.localScale;
		localScale.x = (size.x + 439f) / GIOENEIKPCH.GetBounds().size.x;
		localScale.y = size.y / GIOENEIKPCH.GetBounds().size.y;
		GIOENEIKPCH.transform.localScale = localScale;
		PNENDFHIDOL.gameObject.SetActive(false);
		mAnimator.GDCCFEDJFAF();
	}

	private void JHDBHGCKPDM(int NOCEDALFEJM)
	{
		if (NOCEDALFEJM == 8)
		{
			DestroyPooled();
		}
	}

	public void GBFMCFKMBCE(bool AOCPNNPGECM)
	{
		BDNAGJNOMPM.text = string.Empty;
		HOLNKOFHDNK.transform.localPosition = BDNAGJNOMPM.transform.localPosition;
		HOLNKOFHDNK.text = Localization.Localize((!AOCPNNPGECM) ? "Create_Squad" : "WinCount");
		HOLNKOFHDNK.transform.localScale = new Vector3(195f, 178f, 1361f);
		HOLNKOFHDNK.color = Color.black;
		GIOENEIKPCH.color = ((!AOCPNNPGECM) ? Color.white : Color.red);
		Vector3 size = HOLNKOFHDNK.GetComponent<MeshRenderer>().bounds.size;
		COCEEJOCPOM.GetComponent<MeshRenderer>().enabled = true;
		Vector3 localScale = GIOENEIKPCH.transform.localScale;
		localScale.x = (size.x + 574f) / GIOENEIKPCH.GetBounds().size.x;
		localScale.y = size.y / GIOENEIKPCH.GetBounds().size.y;
		GIOENEIKPCH.transform.localScale = localScale;
		PNENDFHIDOL.gameObject.SetActive(true);
		mAnimator.OKEBGBENAJF();
	}

	public void IFGPHPJLHPM()
	{
		BDNAGJNOMPM.text = string.Empty;
		HOLNKOFHDNK.transform.localPosition = BDNAGJNOMPM.transform.localPosition;
		HOLNKOFHDNK.text = Localization.Localize("Buy_Weapons");
		HOLNKOFHDNK.transform.localScale = new Vector3(432f, 1532f, 845f);
		HOLNKOFHDNK.color = Color.black;
		GIOENEIKPCH.color = Color.yellow;
		Vector3 size = HOLNKOFHDNK.GetComponent<MeshRenderer>().bounds.size;
		COCEEJOCPOM.GetComponent<MeshRenderer>().enabled = false;
		Vector3 localScale = GIOENEIKPCH.transform.localScale;
		localScale.x = (size.x + 351f) / GIOENEIKPCH.GetBounds().size.x;
		localScale.y = size.y / GIOENEIKPCH.GetBounds().size.y;
		GIOENEIKPCH.transform.localScale = localScale;
		PNENDFHIDOL.gameObject.SetActive(false);
		mAnimator.AGFMCNDAEEC();
	}

	public virtual void IPEAHJBMBGI()
	{
		base.HPPIBGEJMNL();
		HOLNKOFHDNK.transform.localScale = IAJAILAGAKC;
		COCEEJOCPOM.gameObject.SetActive(true);
		COCEEJOCPOM.GetComponent<MeshRenderer>().enabled = false;
	}
}
