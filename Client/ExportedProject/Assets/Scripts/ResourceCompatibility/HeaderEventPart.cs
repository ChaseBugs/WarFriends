using System.Collections.Generic;
using UnityEngine;

public class HeaderEventPart : Core_BaseScript
{
	private enum LNOBLCCJHMJ
	{
		Empty,
		NewAssignment,
		AssignmnetProgress,
		EventProgress
	}

	[SerializeField]
	private GameObject mLeftAnchor;

	[SerializeField]
	private GameObject mRightAnchor;

	[SerializeField]
	private UISprite mBackground;

	[SerializeField]
	private BoxCollider mButtonCollider;

	[SerializeField]
	private UILabel mTitle;

	[SerializeField]
	private UISprite mIcon;

	[SerializeField]
	private UITexture mGlow;

	[SerializeField]
	private UILabel mCountLabel;

	[SerializeField]
	private UILabel mNewAssignmentsLabel;

	[SerializeField]
	private ParticleSystem mFallingSnow;

	[SerializeField]
	private ParticleSystem mFallingStars;

	[SerializeField]
	private ParticleSystem mFlyingBats;

	[SerializeField]
	private List<ParticleSystem> mFallingFlags;

	[SerializeField]
	private GameObject mDailyPart;

	[SerializeField]
	private UISprite mDailyProgress;

	[SerializeField]
	private UISprite mDailyBackground;

	[SerializeField]
	private UISprite mDailyIcon;

	[SerializeField]
	private UILabel mDailyNumber;

	[SerializeField]
	private GameObject mEventPart;

	[SerializeField]
	private UISprite mEventProgress;

	[SerializeField]
	private UISprite mEventBackground;

	[SerializeField]
	private UISprite mEventIcon;

	[SerializeField]
	private GameObject mNotification;

	[SerializeField]
	private UILabel mNotificationNumber;

	private int GGMFHEEOLBK;

	public bool showPart => false;

	private LNOBLCCJHMJ HNFDDNHGMCA => default(LNOBLCCJHMJ);

	private bool JLJKDANLJLC => false;

	private int LNLBHJFANGK => 0;

	public void InitControls()
	{
	}

	private void DDBOOOAJDBD(GameObject LJFDGDIAGIN)
	{
	}

	private void GJKJECFFNIJ(int FJGJIIPMGAF)
	{
	}

	public void InitGUIValues()
	{
	}

	private EventAssignment GJIJJOLKGNO(out int EPNGMAHENPA)
	{
		EPNGMAHENPA = default(int);
		return null;
	}

	public void SetWidth()
	{
	}
}
