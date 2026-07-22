using UnityEngine;
using UnityEngine.Serialization;

public class BonusTakeDisplayer : PoolableObject
{
	[FormerlySerializedAs("BALEOFOKIOC")]
	public TextMesh HOLNKOFHDNK;

	[FormerlySerializedAs("HKBMOKJPJDC")]
	public tk2dSprite HICMNHGFOAG;

	[FormerlySerializedAs("PLMIILLHPPL")]
	public tk2dSprite NNONONBHHKM;

	[FormerlySerializedAs("HPOCJBBBPOC")]
	public tk2dSprite DAANKCOLJGJ;

	[FormerlySerializedAs("NHPOPPPLHKO")]
	public tk2dSprite NEJHICHPJIK;

	[SerializeField]
	private TweenAnimator mAnimator;

	[FormerlySerializedAs("FOGJKNKIBJL")]
	public Color FDGBJAMNIEM;

	[FormerlySerializedAs("PGOHBHOKKJB")]
	public GameObject HHMFINFGMGD;

	[FormerlySerializedAs("KAGHBJDIBLI")]
	public GameObject BPBHIIAMDDL;

	protected virtual void FNJKFDOMGOO()
	{
		base.Awake();
		IJFKFIGAINA();
	}

	public void Play()
	{
		HICMNHGFOAG.transform.localScale = new Vector3(0.01f, 0.01f, 0.01f);
		NNONONBHHKM.transform.localScale = new Vector3(0.01f, 0.01f, 0.01f);
		DAANKCOLJGJ.transform.localScale = new Vector3(0.01f, 0.01f, 0.01f);
		HOLNKOFHDNK.color = Colours.blackTransparent;
		NEJHICHPJIK.transform.localScale = new Vector3(0.001f, 1f, 1f);
		HHMFINFGMGD.transform.localScale = Vector3.one;
		BPBHIIAMDDL.transform.localScale = Vector3.one;
		mAnimator.PlayTweens();
		DestroyPooled(2f);
	}

	public void Play(string BKEFLAHMMJI, string CONCDNAJKHN, string FPFCCDCGEHC, bool EIFNJDOEPPA = false)
	{
		HOLNKOFHDNK.text = BKEFLAHMMJI;
		HOLNKOFHDNK.color = FDGBJAMNIEM;
		HICMNHGFOAG.SetSprite("game-scorestreak-bg" + CONCDNAJKHN);
		DAANKCOLJGJ.SetSprite(FPFCCDCGEHC);
		if (CONCDNAJKHN == string.Empty || EIFNJDOEPPA)
		{
			HOLNKOFHDNK.anchor = TextAnchor.MiddleLeft;
			HOLNKOFHDNK.transform.localPosition = default(Vector3);
			HOLNKOFHDNK.transform.localScale = Vector3.one;
		}
		else
		{
			HOLNKOFHDNK.anchor = TextAnchor.MiddleCenter;
			HOLNKOFHDNK.transform.localPosition = new Vector3(32f, 0f, 0f);
			HOLNKOFHDNK.transform.localScale = Vector3.one.ReplaceXY(2.2f, 2.2f);
		}
		float x = HOLNKOFHDNK.GetComponent<MeshRenderer>().bounds.size.x;
		float num = 31f;
		if (x > num)
		{
			Debug.Log("BONUS: size: " + x + " name:" + BKEFLAHMMJI);
			float num2 = num / (x / HOLNKOFHDNK.transform.localScale.x);
			HOLNKOFHDNK.transform.localScale = new Vector3(num2, num2, 1f);
		}
		Play();
	}

	public void Play(KillStreakBonus DFJCEKGDMJH)
	{
		Play(DFJCEKGDMJH.fullName, DFJCEKGDMJH.CONCDNAJKHN, DFJCEKGDMJH.FPFCCDCGEHC);
	}

	public void NJCHPFPACHC(KillStreakBonus DFJCEKGDMJH)
	{
		Play(DFJCEKGDMJH.fullName, DFJCEKGDMJH.CONCDNAJKHN, DFJCEKGDMJH.FPFCCDCGEHC);
	}

	private void IJFKFIGAINA()
	{
		mAnimator.BEOAHFDJEMD.Clear();
		TweenAnimator tweenAnimator = mAnimator;
		int iNFLHPGMEOB = 0;
		TweenAnimator.MNAIKKJDPLK hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.Scale;
		GameObject nIHOBEAHEKJ = HICMNHGFOAG.gameObject;
		float kBJEOEEOEFG = 0.2f;
		object iIMDKHJAJGO = new Vector3(1.3f, 1.3f, 1.3f);
		object oEIICEJPGKI = Vector3.zero;
		tweenAnimator.AddTween(iNFLHPGMEOB, hADMLJODMKA, nIHOBEAHEKJ, kBJEOEEOEFG, iIMDKHJAJGO, 0f, -1, oEIICEJPGKI, UITweener.Method.EaseIn);
		mAnimator.AddTween(1, TweenAnimator.MNAIKKJDPLK.Scale, HICMNHGFOAG.gameObject, 0.1f, Vector3.one, 0f, 0, null, UITweener.Method.EaseOut);
		TweenAnimator tweenAnimator2 = mAnimator;
		iNFLHPGMEOB = 2;
		hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.Scale;
		nIHOBEAHEKJ = NNONONBHHKM.gameObject;
		kBJEOEEOEFG = 0.2f;
		oEIICEJPGKI = new Vector3(1.3f, 1.3f, 1.3f);
		float kALLNCAFIMP = 0.1f;
		iIMDKHJAJGO = Vector3.zero;
		tweenAnimator2.AddTween(iNFLHPGMEOB, hADMLJODMKA, nIHOBEAHEKJ, kBJEOEEOEFG, oEIICEJPGKI, kALLNCAFIMP, -1, iIMDKHJAJGO, UITweener.Method.EaseIn);
		mAnimator.AddTween(3, TweenAnimator.MNAIKKJDPLK.Scale, NNONONBHHKM.gameObject, 0.1f, Vector3.one, 0f, 2, null, UITweener.Method.EaseOut);
		TweenAnimator tweenAnimator3 = mAnimator;
		iNFLHPGMEOB = 4;
		hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.Scale;
		nIHOBEAHEKJ = DAANKCOLJGJ.gameObject;
		kALLNCAFIMP = 0.2f;
		iIMDKHJAJGO = new Vector3(1.6f, 1.6f, 1.6f);
		kBJEOEEOEFG = 0.2f;
		oEIICEJPGKI = Vector3.zero;
		tweenAnimator3.AddTween(iNFLHPGMEOB, hADMLJODMKA, nIHOBEAHEKJ, kALLNCAFIMP, iIMDKHJAJGO, kBJEOEEOEFG, -1, oEIICEJPGKI, UITweener.Method.EaseIn);
		mAnimator.AddTween(5, TweenAnimator.MNAIKKJDPLK.Scale, DAANKCOLJGJ.gameObject, 0.1f, Vector3.one, 0f, 4, null, UITweener.Method.EaseOut);
		TweenAnimator tweenAnimator4 = mAnimator;
		iNFLHPGMEOB = 6;
		hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.Scale;
		nIHOBEAHEKJ = NEJHICHPJIK.gameObject;
		kBJEOEEOEFG = 0.3f;
		oEIICEJPGKI = Vector3.one;
		kALLNCAFIMP = 0.2f;
		iIMDKHJAJGO = new Vector3(0.001f, 1f, 1f);
		tweenAnimator4.AddTween(iNFLHPGMEOB, hADMLJODMKA, nIHOBEAHEKJ, kBJEOEEOEFG, oEIICEJPGKI, kALLNCAFIMP, -1, iIMDKHJAJGO);
		mAnimator.AddTween(7, TweenAnimator.MNAIKKJDPLK.AlphaTk2d, HOLNKOFHDNK.gameObject, 0.08f, 1f, 0f, 6, 0f, UITweener.Method.EaseInOut, UITweener.Style.PingPong, 5);
		mAnimator.AddTween(8, TweenAnimator.MNAIKKJDPLK.Scale, HHMFINFGMGD, 0.4f, new Vector3(0f, 1f, 1f), 0.2f, 7);
		mAnimator.AddTween(9, TweenAnimator.MNAIKKJDPLK.Scale, BPBHIIAMDDL, 0.4f, new Vector3(1f, 0f, 1f), 0.2f, 7);
	}

	public void GCOEJJEENJM()
	{
		HICMNHGFOAG.transform.localScale = new Vector3(217f, 361f, 641f);
		NNONONBHHKM.transform.localScale = new Vector3(1250f, 468f, 543f);
		DAANKCOLJGJ.transform.localScale = new Vector3(1549f, 879f, 190f);
		HOLNKOFHDNK.color = Colours.blackTransparent;
		NEJHICHPJIK.transform.localScale = new Vector3(236f, 1408f, 308f);
		HHMFINFGMGD.transform.localScale = Vector3.one;
		BPBHIIAMDDL.transform.localScale = Vector3.one;
		mAnimator.ODIJFGCDJNH();
		NFJEOLKAONC(1758f, ENGGOAPADCP: true);
	}

	protected virtual void AOJALKEHFCK()
	{
		base.Awake();
		IJFKFIGAINA();
	}

	protected virtual void HEJKGFPPIDC()
	{
		base.Awake();
		DNGODLGOPFF();
	}

	public void MJHMJPCJEBG()
	{
		HICMNHGFOAG.transform.localScale = new Vector3(535f, 142f, 846f);
		NNONONBHHKM.transform.localScale = new Vector3(1926f, 207f, 1042f);
		DAANKCOLJGJ.transform.localScale = new Vector3(520f, 1700f, 1648f);
		HOLNKOFHDNK.color = Colours.blackTransparent;
		NEJHICHPJIK.transform.localScale = new Vector3(1170f, 488f, 439f);
		HHMFINFGMGD.transform.localScale = Vector3.one;
		BPBHIIAMDDL.transform.localScale = Vector3.one;
		mAnimator.ODIJFGCDJNH();
		MIDOLDHLMAF(54f, ENGGOAPADCP: true);
	}

	public void MPAMAMFPJHK()
	{
		HICMNHGFOAG.transform.localScale = new Vector3(276f, 1209f, 153f);
		NNONONBHHKM.transform.localScale = new Vector3(429f, 1618f, 614f);
		DAANKCOLJGJ.transform.localScale = new Vector3(665f, 1620f, 886f);
		HOLNKOFHDNK.color = Colours.blackTransparent;
		NEJHICHPJIK.transform.localScale = new Vector3(1223f, 1882f, 376f);
		HHMFINFGMGD.transform.localScale = Vector3.one;
		BPBHIIAMDDL.transform.localScale = Vector3.one;
		mAnimator.AGFMCNDAEEC();
		DestroyPooled(1875f, ENGGOAPADCP: true);
	}

	private void DNGODLGOPFF()
	{
		mAnimator.BEOAHFDJEMD.Clear();
		TweenAnimator tweenAnimator = mAnimator;
		int iNFLHPGMEOB = 0;
		TweenAnimator.MNAIKKJDPLK hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.Color;
		GameObject nIHOBEAHEKJ = HICMNHGFOAG.gameObject;
		float kBJEOEEOEFG = 814f;
		object iIMDKHJAJGO = new Vector3(344f, 1169f, 1248f);
		object oEIICEJPGKI = Vector3.zero;
		tweenAnimator.AddTween(iNFLHPGMEOB, hADMLJODMKA, nIHOBEAHEKJ, kBJEOEEOEFG, iIMDKHJAJGO, 856f, -1, oEIICEJPGKI, UITweener.Method.Linear);
		mAnimator.AddTween(1, TweenAnimator.MNAIKKJDPLK.Position, HICMNHGFOAG.gameObject, 1016f, Vector3.one, 175f, 1, null, UITweener.Method.EaseIn, UITweener.Style.Once, 0);
		TweenAnimator tweenAnimator2 = mAnimator;
		iNFLHPGMEOB = 7;
		hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.TextCounter;
		nIHOBEAHEKJ = NNONONBHHKM.gameObject;
		kBJEOEEOEFG = 581f;
		oEIICEJPGKI = new Vector3(132f, 1127f, 298f);
		float kALLNCAFIMP = 1101f;
		iIMDKHJAJGO = Vector3.zero;
		tweenAnimator2.NFLKPCIHOPJ(iNFLHPGMEOB, hADMLJODMKA, nIHOBEAHEKJ, kBJEOEEOEFG, oEIICEJPGKI, kALLNCAFIMP, -1, iIMDKHJAJGO, UITweener.Method.EaseIn, UITweener.Style.Loop, 0);
		mAnimator.NFLKPCIHOPJ(0, TweenAnimator.MNAIKKJDPLK.Alpha, NNONONBHHKM.gameObject, 1687f, Vector3.one, 1231f, 0, null, UITweener.Method.BounceIn);
		TweenAnimator tweenAnimator3 = mAnimator;
		iNFLHPGMEOB = 5;
		hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.SufixTextCounter;
		nIHOBEAHEKJ = DAANKCOLJGJ.gameObject;
		kALLNCAFIMP = 171f;
		iIMDKHJAJGO = new Vector3(1455f, 1823f, 220f);
		kBJEOEEOEFG = 424f;
		oEIICEJPGKI = Vector3.zero;
		tweenAnimator3.BPEKAKFKCIG(iNFLHPGMEOB, hADMLJODMKA, nIHOBEAHEKJ, kALLNCAFIMP, iIMDKHJAJGO, kBJEOEEOEFG, -1, oEIICEJPGKI, UITweener.Method.Linear, UITweener.Style.Loop, 0);
		mAnimator.BPEKAKFKCIG(6, TweenAnimator.MNAIKKJDPLK.Alpha, DAANKCOLJGJ.gameObject, 1785f, Vector3.one, 1772f, 1, null, UITweener.Method.Linear, UITweener.Style.Loop, 0);
		TweenAnimator tweenAnimator4 = mAnimator;
		iNFLHPGMEOB = 4;
		hADMLJODMKA = TweenAnimator.MNAIKKJDPLK.TextCounter;
		nIHOBEAHEKJ = NEJHICHPJIK.gameObject;
		kBJEOEEOEFG = 721f;
		oEIICEJPGKI = Vector3.one;
		kALLNCAFIMP = 1731f;
		iIMDKHJAJGO = new Vector3(1919f, 1934f, 1955f);
		tweenAnimator4.AddTween(iNFLHPGMEOB, hADMLJODMKA, nIHOBEAHEKJ, kBJEOEEOEFG, oEIICEJPGKI, kALLNCAFIMP, -1, iIMDKHJAJGO, UITweener.Method.BounceOut);
		mAnimator.MNEFMODDFFK(5, TweenAnimator.MNAIKKJDPLK.SufixTextCounter, HOLNKOFHDNK.gameObject, 1747f, 41f, 1138f, 3, 845f, UITweener.Method.BounceOut, (UITweener.Style)5, 8);
		mAnimator.MNEFMODDFFK(5, TweenAnimator.MNAIKKJDPLK.AlphaTk2d, HHMFINFGMGD, 338f, new Vector3(691f, 1395f, 1577f), 729f, 8, null, UITweener.Method.EaseIn);
		mAnimator.MNEFMODDFFK(-76, TweenAnimator.MNAIKKJDPLK.Scale, BPBHIIAMDDL, 666f, new Vector3(1798f, 833f, 1487f), 1251f, 2, null, (UITweener.Method)6, UITweener.Style.Once, 0);
	}

	protected override void Awake()
	{
		base.Awake();
		IJFKFIGAINA();
	}

	public void BHPFDOOONEP(KillStreakBonus DFJCEKGDMJH)
	{
		Play(DFJCEKGDMJH.MLPCGNBFFCO(), DFJCEKGDMJH.CONCDNAJKHN, DFJCEKGDMJH.FPFCCDCGEHC);
	}

	protected virtual void BMLLLOBPGIB()
	{
		base.Awake();
		IJFKFIGAINA();
	}
}
