using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class CardRecord : PoolableObject
{
	public enum OKFEEKEMCKP
	{
		MyWarcards,
		CraftCards,
		Lobby,
		Withdraw,
		CountDownBuddy,
		Deposit,
		Other
	}

	private enum AJBJJJPHGPA
	{
		None,
		Move,
		Scroll
	}

	private sealed class NJJDFJJLLDD
	{
		public CardRecord HNNCIECPFEJ;

		public bool MNADNEEFDNG;

		public UITweener.OnFinished KKHLOMJLHEE;

		public UITweener.OnFinished JBILNPCLHKH;

		public UITweener.OnFinished KNJLKJEIFEL;

		internal void JCOBMPNFOML(UITweener GDPAJADKOPD)
		{
		}

		internal void DKCCCOICFGN(UITweener BBKBLLNOMPK)
		{
		}

		internal void PJGCDHCPMFM(UITweener DLKGNDEDKJA)
		{
		}

		internal void ALOAMCDKPBC(UITweener GFJJPNCPDAB)
		{
		}
	}

	private sealed class JLIBJMALNFI
	{
		public CardRecord HNNCIECPFEJ;

		public float GFPGAOABMDF;

		internal void JLCCCLAAOII(UITweener GDPAJADKOPD)
		{
		}
	}

	[CompilerGenerated]
	private Action<CardRecord> BOIKPGNNOHE;

	public UIPanel KGLGDGCFCJC;

	public TweenAlpha HBMLLLPEGMK;

	public BoxCollider MHOPKAHDGMN;

	public UISprite GIMMLMFBMEI;

	public UISprite HKOBAANEKHJ;

	public UISprite PKCAOLNKADK;

	public UITexture EKIAGNIBEBA;

	public UILabel ENNBPJIFMCK;

	public UILabel LINHEOKNIEE;

	public UITable FHJLNPEAHJF;

	public UISprite HLJBCNKMOEH;

	public UILabel PHKKDKKJFMJ;

	public UILabel GPIGFNJADGK;

	public UILabel POHFKGMHJDJ;

	public GameObject EMHJMPCIFGL;

	public UISprite AFIGDMKNGOB;

	public UISprite BKBDKPLIOOD;

	public UISprite LGKALODLHOB;

	public GameObject JPDJMFPJJPG;

	public UISprite MHIHKNBFIHH;

	public GameObject GLGFIMOMGJN;

	public UILabel BGCAJDMGEGN;

	public GameObject CDAMBPGLKIA;

	public UISprite ELBLBCKLOAA;

	public GameObject FNJAAKPOIOK;

	public UILabel NPLBCKKKKJJ;

	public GameObject FMLJFDJGIIH;

	public GameObject CLPNANKNNGC;

	public UISprite DDMMGDLEACC;

	public UILabel HJKKAGIAMED;

	public GameObject DAEJHMKGLDE;

	public UISprite KBHOCCBIGBC;

	public UISprite ELLECACMDDJ;

	public UITexture IFDDDOBFFBL;

	public UILabel LOCNFMKDODD;

	public UISprite OMCEELCBKJJ;

	[SerializeField]
	private GameObject mBuddyLimitPart;

	[SerializeField]
	private UISprite mBuddyLimitBackground;

	[SerializeField]
	private UILabel mBuddyLimitLabel;

	[SerializeField]
	private UILabel mBuddyLimitAmount;

	[SerializeField]
	private List<UISprite> mLinesLimit;

	[CompilerGenerated]
	private Card _003CCMCAAGPEDDD_003Ek__BackingField;

	[CompilerGenerated]
	private bool _003CNPLMJACHFPB_003Ek__BackingField;

	[CompilerGenerated]
	private OKFEEKEMCKP _003CDBEKDMJKLMP_003Ek__BackingField;

	private bool AEFIHENLEFH;

	private AJBJJJPHGPA OOJKLCFCLOD;

	private bool EMFAEAHNPMD;

	private Vector3 PACKGAJMHDJ;

	private CardContainer PCELHCFBDJE;

	private Vector3 CNICJJPIEPC;

	private bool IPCOFENIFJF;

	private float GPLIOBPBGDO;

	public Card card
	{
		[CompilerGenerated]
		get
		{
			return null;
		}
		[CompilerGenerated]
		private set
		{
		}
	}

	public bool isAvailable => false;

	public bool isAnimatingCard => false;

	public bool cardFlipped
	{
		[CompilerGenerated]
		get
		{
			return false;
		}
		[CompilerGenerated]
		private set
		{
		}
	}

	public Transform dragCardTransform => null;

	public OKFEEKEMCKP behaviour
	{
		[CompilerGenerated]
		get
		{
			return default(OKFEEKEMCKP);
		}
		[CompilerGenerated]
		set
		{
		}
	}

	public event Action<CardRecord> OnCardClick
	{
		[CompilerGenerated]
		add
		{
		}
		[CompilerGenerated]
		remove
		{
		}
	}

	protected override void Start()
	{
	}

	public void Initialize(Card JINBEOLCLNP, OKFEEKEMCKP DJDKOBKAJEO = OKFEEKEMCKP.Other, bool DDOJCAILFHB = true)
	{
	}

	public void SetAmount(int JPIPAIOGHFE)
	{
	}

	public void UnhookAndStopAllTweens()
	{
	}

	public override void OnInstancied()
	{
	}

	public override void DestroyPooled()
	{
	}

	public void InitBigCardLook()
	{
	}

	protected void Update()
	{
	}

	private void HFLJLKEJIAH()
	{
	}

	private void OnDrag(Vector2 NLPAIJAEIOM)
	{
	}

	private void OnPress(bool HGDCEBEMHFK)
	{
	}

	private void JOLHECACJDA()
	{
	}

	public void EndScreenAnimation(bool MNADNEEFDNG)
	{
	}

	public void HideCardInEndScreen()
	{
	}

	private bool EEPHFBPLKDJ()
	{
		return false;
	}

	public void SetInvisible()
	{
	}

	private void GLIFDHMBJBF()
	{
	}

	public void PrepareBuyAnimation()
	{
	}

	public void FlipBuyAnimation(int EPNGMAHENPA)
	{
	}

	public void SelectForCraftingAnimation()
	{
	}

	public void SetHighlight(bool FDADEAHAIKP)
	{
	}

	public void SetBuddyLimitUnAvailable()
	{
	}

	public void SetUnAvailable()
	{
	}

	internal void BCBHGBLEEJK()
	{
	}

	[CompilerGenerated]
	private void JBKHLGEFKJG(UITweener GDPAJADKOPD)
	{
	}

	[CompilerGenerated]
	private void DBNAJLIKNEH(UITweener MDENPKGFENL)
	{
	}

	[CompilerGenerated]
	private void OJDCABNMIFO(UITweener BPEKJCFJGBO)
	{
	}

	[CompilerGenerated]
	private void OHEFFOCNEEH(UITweener IFEENDOMNDE)
	{
	}

	[CompilerGenerated]
	private void FBPODOBIKCC(UITweener LBEGNPNBFKI)
	{
	}

	[CompilerGenerated]
	private void LKGKMHIKODC(UITweener HKJICEAAGPA)
	{
	}

	[CompilerGenerated]
	private void PFKDDOPJOIE(UITweener GDPAJADKOPD)
	{
	}
}
