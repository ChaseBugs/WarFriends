using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class DailyRewardButton : PoolableObject
{
	private enum PBBFHDPJEBN
	{
		Claimed,
		Claimable,
		Tomorrow,
		LoginInXDays
	}

	[SerializeField]
	private UISprite mBorder;

	[SerializeField]
	private GameObject mHighlightPart;

	[SerializeField]
	private UISprite mHighlight;

	[SerializeField]
	private UISprite mSelectedHighlight;

	[SerializeField]
	private GameObject mTopPart;

	[SerializeField]
	private UISprite mTopBonusIcon;

	[SerializeField]
	private Transform mImageContent;

	[SerializeField]
	private UILabel mCountLabel;

	[SerializeField]
	private List<UISprite> mImages;

	[SerializeField]
	private UILabel mSecondLabel;

	[SerializeField]
	private GameObject mDoubleForTransitionPart;

	[SerializeField]
	private UISprite mCheckIcon;

	[SerializeField]
	private UILabel mBottomLabel;

	[SerializeField]
	private UISprite mBottomBackground;

	[SerializeField]
	private UIAtlas mMainAtlas;

	[SerializeField]
	private UIAtlas mBigAtlas;

	[SerializeField]
	private UIAtlas mCommonAtlas;

	[SerializeField]
	private UIAtlas mCommonIconsAtlas;

	[SerializeField]
	private UIAtlas mCardAtlas;

	[SerializeField]
	private UIAtlas mVisualAtlas;

	[SerializeField]
	private UIAtlas mArmyAtlas;

	private Vector3 PGFIHEIJGGK;

	private List<UITweener> PNFCMFLMLFO;

	private Vector3 DAOCJFIPALD;

	private Vector3 FBOAECLKONM;

	private Dictionary<PBBFHDPJEBN, Color> FFIICBAPKMN;

	private Dictionary<PBBFHDPJEBN, Color> OICCPPJLMCN;

	private Dictionary<PBBFHDPJEBN, Color> GHPHLBHAIHP;

	private Dictionary<PBBFHDPJEBN, string> OEAPCOJIGCF;

	private PBBFHDPJEBN LGFHNCIHFBA;

	private int BDLHBOAKMFD;

	[CompilerGenerated]
	private int _003CGABGHKOHHGC_003Ek__BackingField;

	public int index
	{
		[CompilerGenerated]
		get
		{
			return 0;
		}
		[CompilerGenerated]
		private set
		{
		}
	}

	public void Initialize(GameReward BMIADLFBMEN, int NIEFEOLGKEF, int OJDCBEDKLCH, bool MJHKJJAKCCP, int BNHJFECJNOI)
	{
	}

	private void KNGDHONFJOC(GameObject LJFDGDIAGIN)
	{
	}

	private void NNHPOKKLGBL(GameReward GAMKCDKDPKL)
	{
	}

	public void SetSelected(bool PPKMMEGPLJP, bool OBMKHFAJIOB = false)
	{
	}

	private void HKNJDDFMJLO()
	{
	}

	private PBBFHDPJEBN GPIMIEFGGCI(int NIEFEOLGKEF, int OJDCBEDKLCH, bool MJHKJJAKCCP)
	{
		return default(PBBFHDPJEBN);
	}

	private void LMOFABNNOGI()
	{
	}

	public void AnimateClaim()
	{
	}

	public override void DestroyPooled()
	{
	}

	[CompilerGenerated]
	private void DFEKPIGGDAC(UITweener GDPAJADKOPD)
	{
	}

	[CompilerGenerated]
	private void BGHABAEDCCH(UITweener HKJICEAAGPA)
	{
	}

	[CompilerGenerated]
	private void IJMAAHIPFDK(UITweener HKJICEAAGPA)
	{
	}
}
