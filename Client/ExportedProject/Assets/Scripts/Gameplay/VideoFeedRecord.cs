using System;
using System.Runtime.CompilerServices;
using UnityEngine;

public class VideoFeedRecord : PoolableObject
{
	[SerializeField]
	[Header("Core")]
	private BoxCollider mCollider;

	[SerializeField]
	private GameObject mHighlight;

	[SerializeField]
	private UISprite mVideoIcon;

	[SerializeField]
	[Header("Content")]
	private UILabel mVideoName;

	[SerializeField]
	private UISprite mServiceLogo;

	[SerializeField]
	private UILabel mUserName;

	private VideoFeedManager.VideoFeed AGLCHFLACPL;

	public VideoFeedManager.VideoFeed video => AGLCHFLACPL;

	public void EPAHIKLPNNB(VideoFeedManager.VideoFeed HNGNDECFCPO)
	{
		AGLCHFLACPL = HNGNDECFCPO;
		mVideoName.text = HNGNDECFCPO.videoName;
		mUserName.text = HNGNDECFCPO.author;
		mServiceLogo.spriteName = HNGNDECFCPO.iconName;
		mServiceLogo.MakePixelPerfect();
		UIEventListener uIEventListener = UIEventListener.Get(mCollider.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(EGLKALEBIMB));
		UIEventListener uIEventListener2 = UIEventListener.Get(mCollider.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(KDAENCDLEFH));
	}

	public override void DestroyPooled()
	{
		base.DestroyPooled();
		UIEventListener uIEventListener = UIEventListener.Get(mCollider.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(KDAENCDLEFH));
	}

	public void MFMJPBCIHEH(VideoFeedManager.VideoFeed HNGNDECFCPO)
	{
		AGLCHFLACPL = HNGNDECFCPO;
		mVideoName.text = HNGNDECFCPO.videoName;
		mUserName.text = HNGNDECFCPO.author;
		mServiceLogo.spriteName = HNGNDECFCPO.iconName;
		mServiceLogo.MakePixelPerfect();
		UIEventListener uIEventListener = UIEventListener.Get(mCollider.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(EGLKALEBIMB));
		UIEventListener uIEventListener2 = UIEventListener.Get(mCollider.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(EGLKALEBIMB));
	}

	public virtual void HOCPBJGFEON()
	{
		base.OBCAIFMOPPA();
		UIEventListener uIEventListener = UIEventListener.Get(mCollider.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(FAGKCGBLFEC));
	}

	private void NNJENHDENLK(GameObject KHAHPAKDIKE)
	{
		GuiScreenSingle<VideoFeedScreen>.instance.BPCNLKOFKMM(GCGOGMDOBED: false, this);
	}

	public void OAJGLLMNDPI(bool LIJGDCFAKAI)
	{
		mHighlight.SetActive(LIJGDCFAKAI);
		mVideoIcon.spriteName = ((!LIJGDCFAKAI) ? ") " : "S");
	}

	public void JMLALKIGLGK(bool LIJGDCFAKAI)
	{
		mHighlight.SetActive(LIJGDCFAKAI);
		mVideoIcon.spriteName = ((!LIJGDCFAKAI) ? "ID_DEBUG_GUIERROR" : "N");
	}

	public virtual void HBAPDIOFMPI()
	{
		base.DestroyPooled();
		UIEventListener uIEventListener = UIEventListener.Get(mCollider.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(KDAENCDLEFH));
	}

	public void GOMJAFCDKDD(VideoFeedManager.VideoFeed HNGNDECFCPO)
	{
		AGLCHFLACPL = HNGNDECFCPO;
		mVideoName.text = HNGNDECFCPO.videoName;
		mUserName.text = HNGNDECFCPO.author;
		mServiceLogo.spriteName = HNGNDECFCPO.iconName;
		mServiceLogo.MakePixelPerfect();
		UIEventListener uIEventListener = UIEventListener.Get(mCollider.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(KEKJNDGOBPL));
		UIEventListener uIEventListener2 = UIEventListener.Get(mCollider.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(EGLKALEBIMB));
	}

	public void BDMNPDBOCGN(VideoFeedManager.VideoFeed HNGNDECFCPO)
	{
		AGLCHFLACPL = HNGNDECFCPO;
		mVideoName.text = HNGNDECFCPO.videoName;
		mUserName.text = HNGNDECFCPO.author;
		mServiceLogo.spriteName = HNGNDECFCPO.iconName;
		mServiceLogo.MakePixelPerfect();
		UIEventListener uIEventListener = UIEventListener.Get(mCollider.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(KEKJNDGOBPL));
		UIEventListener uIEventListener2 = UIEventListener.Get(mCollider.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(KDAENCDLEFH));
	}

	public virtual void PONDIDGALJM()
	{
		base.OBCAIFMOPPA();
		UIEventListener uIEventListener = UIEventListener.Get(mCollider.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(MDMAJPKKHAN));
	}

	public void GBCFOFKPPJP(VideoFeedManager.VideoFeed HNGNDECFCPO)
	{
		AGLCHFLACPL = HNGNDECFCPO;
		mVideoName.text = HNGNDECFCPO.videoName;
		mUserName.text = HNGNDECFCPO.author;
		mServiceLogo.spriteName = HNGNDECFCPO.iconName;
		mServiceLogo.MakePixelPerfect();
		UIEventListener uIEventListener = UIEventListener.Get(mCollider.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(HHIGCBNBJMG));
		UIEventListener uIEventListener2 = UIEventListener.Get(mCollider.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(LHCEHKGAEEE));
	}

	public virtual void LCNEMJLLIOH()
	{
		base.DestroyPooled();
		UIEventListener uIEventListener = UIEventListener.Get(mCollider.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(OHLMOAOIOID));
	}

	private void KDAENCDLEFH(GameObject KHAHPAKDIKE)
	{
		GuiScreenSingle<VideoFeedScreen>.instance.SelectVideo(GCGOGMDOBED: true, this);
	}

	public void CKOIIPAGCNO(VideoFeedManager.VideoFeed HNGNDECFCPO)
	{
		AGLCHFLACPL = HNGNDECFCPO;
		mVideoName.text = HNGNDECFCPO.videoName;
		mUserName.text = HNGNDECFCPO.author;
		mServiceLogo.spriteName = HNGNDECFCPO.iconName;
		mServiceLogo.MakePixelPerfect();
		UIEventListener uIEventListener = UIEventListener.Get(mCollider.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(FPAIBKAAGHK));
		UIEventListener uIEventListener2 = UIEventListener.Get(mCollider.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(HHIGCBNBJMG));
	}

	[SpecialName]
	public VideoFeedManager.VideoFeed IBDJHKDMAKJ()
	{
		return AGLCHFLACPL;
	}

	[SpecialName]
	public VideoFeedManager.VideoFeed FAHPIGMBIDO()
	{
		return AGLCHFLACPL;
	}

	public void MIGAJMHMCFO(bool LIJGDCFAKAI)
	{
		mHighlight.SetActive(LIJGDCFAKAI);
		mVideoIcon.spriteName = ((!LIJGDCFAKAI) ? "ID_GETSOMEWARBUCKS" : "ID_CATEGORY_LOW_SG_SPECIAL");
	}

	public virtual void HFFLPBCIDOF()
	{
		base.BOHCNEDIJPE();
		UIEventListener uIEventListener = UIEventListener.Get(mCollider.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(LHCEHKGAEEE));
	}

	public void PPFGIHIODHP(bool LIJGDCFAKAI)
	{
		mHighlight.SetActive(LIJGDCFAKAI);
		mVideoIcon.spriteName = ((!LIJGDCFAKAI) ? "Skipping instant battle notification" : "groundBoxHit");
	}

	public void AJEGOKKKLOL(VideoFeedManager.VideoFeed HNGNDECFCPO)
	{
		AGLCHFLACPL = HNGNDECFCPO;
		mVideoName.text = HNGNDECFCPO.videoName;
		mUserName.text = HNGNDECFCPO.author;
		mServiceLogo.spriteName = HNGNDECFCPO.iconName;
		mServiceLogo.MakePixelPerfect();
		UIEventListener uIEventListener = UIEventListener.Get(mCollider.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(MADEGNHPOIA));
		UIEventListener uIEventListener2 = UIEventListener.Get(mCollider.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(FAGKCGBLFEC));
	}

	public virtual void EGEAFDFNEAP()
	{
		base.BOHCNEDIJPE();
		UIEventListener uIEventListener = UIEventListener.Get(mCollider.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(OHLMOAOIOID));
	}

	[SpecialName]
	public VideoFeedManager.VideoFeed LDOAHHCIBIB()
	{
		return AGLCHFLACPL;
	}

	private void KAPACEOMCLJ(GameObject KHAHPAKDIKE)
	{
		GuiScreenSingle<VideoFeedScreen>.instance.BPCNLKOFKMM(GCGOGMDOBED: false, this);
	}

	private void MADEGNHPOIA(GameObject KHAHPAKDIKE)
	{
		GuiScreenSingle<VideoFeedScreen>.instance.SelectVideo(GCGOGMDOBED: true, this);
	}

	[SpecialName]
	public VideoFeedManager.VideoFeed JBPHHGCLBJB()
	{
		return AGLCHFLACPL;
	}

	private void MDMAJPKKHAN(GameObject KHAHPAKDIKE)
	{
		GuiScreenSingle<VideoFeedScreen>.instance.FOEBLIINLFE(GCGOGMDOBED: true, this);
	}

	private void OHLFDFEJKIL(GameObject KHAHPAKDIKE)
	{
		GuiScreenSingle<VideoFeedScreen>.instance.FOEBLIINLFE(GCGOGMDOBED: false, this);
	}

	public virtual void IFHBPEAKGDN()
	{
		base.OBCAIFMOPPA();
		UIEventListener uIEventListener = UIEventListener.Get(mCollider.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(KAPACEOMCLJ));
	}

	public virtual void GDJAPADHAEH()
	{
		base.DestroyPooled();
		UIEventListener uIEventListener = UIEventListener.Get(mCollider.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(MADEGNHPOIA));
	}

	public void PFAACMOGBLC(bool LIJGDCFAKAI)
	{
		mHighlight.SetActive(LIJGDCFAKAI);
		mVideoIcon.spriteName = ((!LIJGDCFAKAI) ? "isRunning" : "{0} x {1}{2}[-]");
	}

	public void Highlight(bool LIJGDCFAKAI)
	{
		mHighlight.SetActive(LIJGDCFAKAI);
		mVideoIcon.spriteName = ((!LIJGDCFAKAI) ? "menu-wftv-play-logo-small-black" : "menu-wftv-play-logo");
	}

	private void KEKJNDGOBPL(GameObject KHAHPAKDIKE)
	{
		GuiScreenSingle<VideoFeedScreen>.instance.FOEBLIINLFE(GCGOGMDOBED: false, this);
	}

	public virtual void IKICBEFAGPE()
	{
		base.OBCAIFMOPPA();
		UIEventListener uIEventListener = UIEventListener.Get(mCollider.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(MDMAJPKKHAN));
	}

	private void FPAIBKAAGHK(GameObject KHAHPAKDIKE)
	{
		GuiScreenSingle<VideoFeedScreen>.instance.BPCNLKOFKMM(GCGOGMDOBED: false, this);
	}

	private void LHCEHKGAEEE(GameObject KHAHPAKDIKE)
	{
		GuiScreenSingle<VideoFeedScreen>.instance.BPCNLKOFKMM(GCGOGMDOBED: true, this);
	}

	private void FAGKCGBLFEC(GameObject KHAHPAKDIKE)
	{
		GuiScreenSingle<VideoFeedScreen>.instance.SelectVideo(GCGOGMDOBED: true, this);
	}

	public virtual void GLMGMOICPFK()
	{
		base.BOHCNEDIJPE();
		UIEventListener uIEventListener = UIEventListener.Get(mCollider.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(OHLFDFEJKIL));
	}

	private void AOMGNGEAAHO(GameObject KHAHPAKDIKE)
	{
		GuiScreenSingle<VideoFeedScreen>.instance.SelectVideo(GCGOGMDOBED: true, this);
	}

	private void CFMMCJLKBLM(GameObject KHAHPAKDIKE)
	{
		GuiScreenSingle<VideoFeedScreen>.instance.BPCNLKOFKMM(GCGOGMDOBED: false, this);
	}

	public void HCEJNMJHDJN(VideoFeedManager.VideoFeed HNGNDECFCPO)
	{
		AGLCHFLACPL = HNGNDECFCPO;
		mVideoName.text = HNGNDECFCPO.videoName;
		mUserName.text = HNGNDECFCPO.author;
		mServiceLogo.spriteName = HNGNDECFCPO.iconName;
		mServiceLogo.MakePixelPerfect();
		UIEventListener uIEventListener = UIEventListener.Get(mCollider.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(AOMGNGEAAHO));
		UIEventListener uIEventListener2 = UIEventListener.Get(mCollider.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(MDMAJPKKHAN));
	}

	private void HHIGCBNBJMG(GameObject KHAHPAKDIKE)
	{
		GuiScreenSingle<VideoFeedScreen>.instance.SelectVideo(GCGOGMDOBED: true, this);
	}

	public void MKENDIKJPLJ(VideoFeedManager.VideoFeed HNGNDECFCPO)
	{
		AGLCHFLACPL = HNGNDECFCPO;
		mVideoName.text = HNGNDECFCPO.videoName;
		mUserName.text = HNGNDECFCPO.author;
		mServiceLogo.spriteName = HNGNDECFCPO.iconName;
		mServiceLogo.MakePixelPerfect();
		UIEventListener uIEventListener = UIEventListener.Get(mCollider.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(NNJENHDENLK));
		UIEventListener uIEventListener2 = UIEventListener.Get(mCollider.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(FAGKCGBLFEC));
	}

	public void CHOLKMFKINL(VideoFeedManager.VideoFeed HNGNDECFCPO)
	{
		AGLCHFLACPL = HNGNDECFCPO;
		mVideoName.text = HNGNDECFCPO.videoName;
		mUserName.text = HNGNDECFCPO.author;
		mServiceLogo.spriteName = HNGNDECFCPO.iconName;
		mServiceLogo.MakePixelPerfect();
		UIEventListener uIEventListener = UIEventListener.Get(mCollider.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(NNJENHDENLK));
		UIEventListener uIEventListener2 = UIEventListener.Get(mCollider.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(AOMGNGEAAHO));
	}

	public void HHMCBKDGGGL(bool LIJGDCFAKAI)
	{
		mHighlight.SetActive(LIJGDCFAKAI);
		mVideoIcon.spriteName = ((!LIJGDCFAKAI) ? "Shots_Fired" : "get");
	}

	[SpecialName]
	public VideoFeedManager.VideoFeed AALFPMGJBNB()
	{
		return AGLCHFLACPL;
	}

	public void FOPDJBDDFLP(bool LIJGDCFAKAI)
	{
		mHighlight.SetActive(LIJGDCFAKAI);
		mVideoIcon.spriteName = ((!LIJGDCFAKAI) ? "champion" : "NZ");
	}

	public void ACCNFEPGPJA(bool LIJGDCFAKAI)
	{
		mHighlight.SetActive(LIJGDCFAKAI);
		mVideoIcon.spriteName = ((!LIJGDCFAKAI) ? "ImproveAllWeaponsRPC" : "was:{0} is:{1} removed:{2}");
	}

	public void HFDLIOIGEJG(bool LIJGDCFAKAI)
	{
		mHighlight.SetActive(LIJGDCFAKAI);
		mVideoIcon.spriteName = ((!LIJGDCFAKAI) ? "#PETER# Weapon Screen - RIGHT BUTTON - should not happen" : "Prefabs");
	}

	public virtual void JHDEIGOECKK()
	{
		base.OBCAIFMOPPA();
		UIEventListener uIEventListener = UIEventListener.Get(mCollider.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(EGLKALEBIMB));
	}

	public virtual void MBJBGBFLJCM()
	{
		base.OBCAIFMOPPA();
		UIEventListener uIEventListener = UIEventListener.Get(mCollider.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(NNJENHDENLK));
	}

	[SpecialName]
	public VideoFeedManager.VideoFeed FFPJJFNIGJB()
	{
		return AGLCHFLACPL;
	}

	public virtual void EJDOMPDOCKD()
	{
		base.BOHCNEDIJPE();
		UIEventListener uIEventListener = UIEventListener.Get(mCollider.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(OHLMOAOIOID));
	}

	private void ADMIKNNOIGO(GameObject KHAHPAKDIKE)
	{
		GuiScreenSingle<VideoFeedScreen>.instance.KIFDPFEMLGH(GCGOGMDOBED: true, this);
	}

	public void LNAFOABKIML(bool LIJGDCFAKAI)
	{
		mHighlight.SetActive(LIJGDCFAKAI);
		mVideoIcon.spriteName = ((!LIJGDCFAKAI) ? "Card_1_Played" : "weapon");
	}

	public void HPGMLHPPODK(bool LIJGDCFAKAI)
	{
		mHighlight.SetActive(LIJGDCFAKAI);
		mVideoIcon.spriteName = ((!LIJGDCFAKAI) ? "ID_SECOND" : "^[0-9]*-");
	}

	public void OJJHCFFEFGI(VideoFeedManager.VideoFeed HNGNDECFCPO)
	{
		AGLCHFLACPL = HNGNDECFCPO;
		mVideoName.text = HNGNDECFCPO.videoName;
		mUserName.text = HNGNDECFCPO.author;
		mServiceLogo.spriteName = HNGNDECFCPO.iconName;
		mServiceLogo.MakePixelPerfect();
		UIEventListener uIEventListener = UIEventListener.Get(mCollider.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(ADMIKNNOIGO));
		UIEventListener uIEventListener2 = UIEventListener.Get(mCollider.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(LHCEHKGAEEE));
	}

	public void OMGCKCFKDJM(VideoFeedManager.VideoFeed HNGNDECFCPO)
	{
		AGLCHFLACPL = HNGNDECFCPO;
		mVideoName.text = HNGNDECFCPO.videoName;
		mUserName.text = HNGNDECFCPO.author;
		mServiceLogo.spriteName = HNGNDECFCPO.iconName;
		mServiceLogo.MakePixelPerfect();
		UIEventListener uIEventListener = UIEventListener.Get(mCollider.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(OHLFDFEJKIL));
		UIEventListener uIEventListener2 = UIEventListener.Get(mCollider.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(LHCEHKGAEEE));
	}

	public void PJICLEMEBID(VideoFeedManager.VideoFeed HNGNDECFCPO)
	{
		AGLCHFLACPL = HNGNDECFCPO;
		mVideoName.text = HNGNDECFCPO.videoName;
		mUserName.text = HNGNDECFCPO.author;
		mServiceLogo.spriteName = HNGNDECFCPO.iconName;
		mServiceLogo.MakePixelPerfect();
		UIEventListener uIEventListener = UIEventListener.Get(mCollider.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(KEKJNDGOBPL));
		UIEventListener uIEventListener2 = UIEventListener.Get(mCollider.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(MDMAJPKKHAN));
	}

	public virtual void ACMEEPFIDBD()
	{
		base.BOHCNEDIJPE();
		UIEventListener uIEventListener = UIEventListener.Get(mCollider.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(EGLKALEBIMB));
	}

	public void IACEOEJFEEM(VideoFeedManager.VideoFeed HNGNDECFCPO)
	{
		AGLCHFLACPL = HNGNDECFCPO;
		mVideoName.text = HNGNDECFCPO.videoName;
		mUserName.text = HNGNDECFCPO.author;
		mServiceLogo.spriteName = HNGNDECFCPO.iconName;
		mServiceLogo.MakePixelPerfect();
		UIEventListener uIEventListener = UIEventListener.Get(mCollider.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(EGLKALEBIMB));
		UIEventListener uIEventListener2 = UIEventListener.Get(mCollider.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(ADMIKNNOIGO));
	}

	[SpecialName]
	public VideoFeedManager.VideoFeed LLGPAMFJIIA()
	{
		return AGLCHFLACPL;
	}

	public virtual void ICCLFDKECEA()
	{
		base.OBCAIFMOPPA();
		UIEventListener uIEventListener = UIEventListener.Get(mCollider.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(MDMAJPKKHAN));
	}

	[SpecialName]
	public VideoFeedManager.VideoFeed KOPAKIGKJOC()
	{
		return AGLCHFLACPL;
	}

	public void LMPNFLGMNBG(VideoFeedManager.VideoFeed HNGNDECFCPO)
	{
		AGLCHFLACPL = HNGNDECFCPO;
		mVideoName.text = HNGNDECFCPO.videoName;
		mUserName.text = HNGNDECFCPO.author;
		mServiceLogo.spriteName = HNGNDECFCPO.iconName;
		mServiceLogo.MakePixelPerfect();
		UIEventListener uIEventListener = UIEventListener.Get(mCollider.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(MADEGNHPOIA));
		UIEventListener uIEventListener2 = UIEventListener.Get(mCollider.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(KDAENCDLEFH));
	}

	public virtual void LAJKINDAEEO()
	{
		base.BOHCNEDIJPE();
		UIEventListener uIEventListener = UIEventListener.Get(mCollider.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(FAGKCGBLFEC));
	}

	private void OHLMOAOIOID(GameObject KHAHPAKDIKE)
	{
		GuiScreenSingle<VideoFeedScreen>.instance.BPCNLKOFKMM(GCGOGMDOBED: false, this);
	}

	public void MMPPOOCEMPM(bool LIJGDCFAKAI)
	{
		mHighlight.SetActive(LIJGDCFAKAI);
		mVideoIcon.spriteName = ((!LIJGDCFAKAI) ? "TiersCompleted" : "ID_BRONZE");
	}

	public void FLNHKDHCFKF(bool LIJGDCFAKAI)
	{
		mHighlight.SetActive(LIJGDCFAKAI);
		mVideoIcon.spriteName = ((!LIJGDCFAKAI) ? "DeliveryTime" : "withRevenue");
	}

	public void KMMNELDFLNA(bool LIJGDCFAKAI)
	{
		mHighlight.SetActive(LIJGDCFAKAI);
		mVideoIcon.spriteName = ((!LIJGDCFAKAI) ? "Refresh_Skirmish" : "Used {0} cards od rarity {1}");
	}

	public virtual void NFJEOLKAONC()
	{
		base.OBCAIFMOPPA();
		UIEventListener uIEventListener = UIEventListener.Get(mCollider.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(AOMGNGEAAHO));
	}

	[SpecialName]
	public VideoFeedManager.VideoFeed EOBDCBFNAFJ()
	{
		return AGLCHFLACPL;
	}

	private void EGLKALEBIMB(GameObject KHAHPAKDIKE)
	{
		GuiScreenSingle<VideoFeedScreen>.instance.SelectVideo(GCGOGMDOBED: false, this);
	}

	public void PALKDIAONDP(VideoFeedManager.VideoFeed HNGNDECFCPO)
	{
		AGLCHFLACPL = HNGNDECFCPO;
		mVideoName.text = HNGNDECFCPO.videoName;
		mUserName.text = HNGNDECFCPO.author;
		mServiceLogo.spriteName = HNGNDECFCPO.iconName;
		mServiceLogo.MakePixelPerfect();
		UIEventListener uIEventListener = UIEventListener.Get(mCollider.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(FAGKCGBLFEC));
		UIEventListener uIEventListener2 = UIEventListener.Get(mCollider.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(OHLFDFEJKIL));
	}

	[SpecialName]
	public VideoFeedManager.VideoFeed GINFFLHODEN()
	{
		return AGLCHFLACPL;
	}

	public void Initialize(VideoFeedManager.VideoFeed HNGNDECFCPO)
	{
		AGLCHFLACPL = HNGNDECFCPO;
		mVideoName.text = HNGNDECFCPO.videoName;
		mUserName.text = HNGNDECFCPO.author;
		mServiceLogo.spriteName = HNGNDECFCPO.iconName;
		mServiceLogo.MakePixelPerfect();
		UIEventListener uIEventListener = UIEventListener.Get(mCollider.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Remove(uIEventListener.onClick, new UIEventListener.VoidDelegate(KDAENCDLEFH));
		UIEventListener uIEventListener2 = UIEventListener.Get(mCollider.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(KDAENCDLEFH));
	}
}
