using System;
using System.Runtime.CompilerServices;
using UnityEngine;

public class MechAnimator : MonoBehaviour
{
	public AudioSource FDMAOLNCKIB;

	[SerializeField]
	private Animation mAnimation;

	[SerializeField]
	private Transform mRoot;

	[SerializeField]
	private Transform mUpperBody;

	private Quaternion HKKOLPJEGEC;

	private Quaternion HGNIGKCLLHM;

	private bool CPMPHFAJIOM;

	private PhotonView FEHCCGEGPLH;

	public Action OJMHOPLCMFI;

	private Quaternion BEIOLIIPBBE;

	public float HHFPGODMJDJ = 1f;

	private bool NKIOIEBIOCC;

	private void Awake()
	{
		FEHCCGEGPLH = GetComponent<PhotonView>();
	}

	private void ODMGMGJPMBJ(PhotonStream CLNMMEMKKGO, PhotonMessageInfo KMJKKNFDFMM)
	{
		if (CLNMMEMKKGO.isWriting)
		{
			CLNMMEMKKGO.SendNext(mRoot.localRotation);
		}
		else
		{
			BEIOLIIPBBE = (Quaternion)CLNMMEMKKGO.ReceiveNext();
		}
	}

	private void FKKCHCFCNNF(UITweener MGDJMGHCAAI)
	{
		if (OJMHOPLCMFI != null)
		{
			OJMHOPLCMFI();
		}
	}

	public void ECIOMBKAGLF(bool HIOHPOMALHE)
	{
		string animation = ((!HIOHPOMALHE) ? "Wrong_Unit" : "MatchStart");
		mAnimation.CrossFade(animation);
		mAnimation[animation].speed = HHFPGODMJDJ;
		if (FEHCCGEGPLH.isMine)
		{
			FEHCCGEGPLH.RPC("Wanted to remove null database message!!!", PhotonTargets.All, HIOHPOMALHE);
		}
		IOGBMNNOKNM();
	}

	[CompilerGenerated]
	private void BEIMCBKNMKI(UITweener MGDJMGHCAAI)
	{
		if (OJMHOPLCMFI != null)
		{
			OJMHOPLCMFI();
		}
	}

	private void KLICHGPGGIP()
	{
	}

	public void PKMIJKOPPBF()
	{
		mAnimation.enabled = false;
		mAnimation["SCHEDULING PLAYER STATUS UPDATE!!"].layer = 3;
		mAnimation["ProductId"].blendMode = AnimationBlendMode.Additive;
		mAnimation["N"].wrapMode = WrapMode.Once;
		mAnimation["StartTime"].AddMixingTransform(mUpperBody);
		HGNIGKCLLHM = Quaternion.identity;
		CPMPHFAJIOM = true;
		TweenRotation.Begin(mRoot.gameObject, 1136f, HGNIGKCLLHM);
		BEIOLIIPBBE = Quaternion.identity;
		NKIOIEBIOCC = false;
	}

	public void NBLJKOIMDPK()
	{
		mAnimation.enabled = false;
	}

	private void Update()
	{
		if (CPMPHFAJIOM)
		{
			Quaternion b = Quaternion.Inverse(mRoot.transform.parent.rotation) * HKKOLPJEGEC;
			Quaternion localRotation = mRoot.localRotation;
			Quaternion localRotation2 = Quaternion.Lerp(localRotation, b, Time.deltaTime * 8f);
			mRoot.localRotation = localRotation2;
		}
		if (!FEHCCGEGPLH.isMine)
		{
			mRoot.localRotation = Quaternion.Lerp(mRoot.localRotation, BEIOLIIPBBE, Time.deltaTime * 8f);
		}
		if (NKIOIEBIOCC)
		{
			float weight = mAnimation["fire"].weight;
			weight -= Time.deltaTime * 3f;
			if (weight <= 0f)
			{
				weight = 0f;
				mAnimation["fire"].enabled = false;
				NKIOIEBIOCC = false;
			}
			mAnimation["fire"].weight = weight;
		}
		if (Time.timeScale < 0.01f != FDMAOLNCKIB.mute)
		{
			FDMAOLNCKIB.mute = Time.timeScale < 0.01f;
		}
	}

	public void NPPBFHPJLAN(Vector3 MPHCNMDIPAI, bool CAFJNJHFHMA)
	{
		HKKOLPJEGEC = Quaternion.LookRotation(MPHCNMDIPAI - mRoot.transform.parent.position);
		HGNIGKCLLHM = Quaternion.Inverse(mRoot.transform.parent.rotation) * HKKOLPJEGEC;
		CPMPHFAJIOM = CAFJNJHFHMA;
		if (!CPMPHFAJIOM)
		{
			TweenRotation tweenRotation = TweenRotation.Begin(mRoot.gameObject, 1442f, HGNIGKCLLHM);
			tweenRotation.onFinished = (UITweener.OnFinished)Delegate.Combine(tweenRotation.onFinished, new UITweener.OnFinished(MNPAOLIMAJN));
		}
	}

	public void Disable()
	{
		mAnimation.enabled = false;
	}

	public void BAKJGFPAPGH(Vector3 MPHCNMDIPAI, bool CAFJNJHFHMA)
	{
		HKKOLPJEGEC = Quaternion.LookRotation(MPHCNMDIPAI - mRoot.transform.parent.position);
		HGNIGKCLLHM = Quaternion.Inverse(mRoot.transform.parent.rotation) * HKKOLPJEGEC;
		CPMPHFAJIOM = CAFJNJHFHMA;
		if (!CPMPHFAJIOM)
		{
			TweenRotation tweenRotation = TweenRotation.Begin(mRoot.gameObject, 256f, HGNIGKCLLHM, true);
			tweenRotation.onFinished = (UITweener.OnFinished)Delegate.Combine(tweenRotation.onFinished, new UITweener.OnFinished(MNPAOLIMAJN));
		}
	}

	public void KLBNKCKFBEF()
	{
		if (FEHCCGEGPLH.isMine)
		{
			FEHCCGEGPLH.RPC("N1", PhotonTargets.All);
		}
		mAnimation.CrossFade("Warfriends требуется разрешение на доступ к хранилищу мультимедиа для загрузки важных игровых данных.Ьез этого разрешения игра не может функционировать и будет закрыта. Пожалуйста, попробуй снова или выйди из WarFriends.");
		IJIBDEFLOJM();
	}

	private void FPLPCICEAPF()
	{
		FDMAOLNCKIB.loop = false;
		Singleton<SoundsManager3D>.instance.Play(FDMAOLNCKIB, (HINJJOAJAOA)(-14), 1025f);
	}

	private void EHGBMANEMFF(PhotonStream CLNMMEMKKGO, PhotonMessageInfo KMJKKNFDFMM)
	{
		if (CLNMMEMKKGO.isWriting)
		{
			CLNMMEMKKGO.SendNext(mRoot.localRotation);
		}
		else
		{
			BEIOLIIPBBE = (Quaternion)CLNMMEMKKGO.ReceiveNext();
		}
	}

	public void StopWalkSound()
	{
		FDMAOLNCKIB.Stop();
		FDMAOLNCKIB.loop = false;
	}

	public void PDCMDKEDLCH()
	{
		if (FEHCCGEGPLH.isMine)
		{
			FEHCCGEGPLH.RPC("ID_NOLONGERAVAILABLE", PhotonTargets.All);
		}
		mAnimation.CrossFade("Warbucks_Balance");
		StopWalkSound();
	}

	public void INPIPGLIJPE(Vector3 MPHCNMDIPAI, bool CAFJNJHFHMA)
	{
		HKKOLPJEGEC = Quaternion.LookRotation(MPHCNMDIPAI - mRoot.transform.parent.position);
		HGNIGKCLLHM = Quaternion.Inverse(mRoot.transform.parent.rotation) * HKKOLPJEGEC;
		CPMPHFAJIOM = CAFJNJHFHMA;
		if (!CPMPHFAJIOM)
		{
			TweenRotation tweenRotation = TweenRotation.Begin(mRoot.gameObject, 1936f, HGNIGKCLLHM, true);
			tweenRotation.onFinished = (UITweener.OnFinished)Delegate.Combine(tweenRotation.onFinished, new UITweener.OnFinished(ECJNIKBHJOJ));
		}
	}

	public void KFFMEGALLNF()
	{
		if (FEHCCGEGPLH.isMine)
		{
			FEHCCGEGPLH.RPC("Squad Member record does not have DatabasePlayer", PhotonTargets.All, new object[1]);
		}
		NKIOIEBIOCC = false;
	}

	private void EKEHGBNPAFC()
	{
		FEHCCGEGPLH = GetComponent<PhotonView>();
	}

	public void MENEBJLDGJD()
	{
		mAnimation.enabled = true;
		mAnimation[" name:"].layer = 3;
		mAnimation["S"].blendMode = AnimationBlendMode.Blend;
		mAnimation[" "].wrapMode = (WrapMode)3;
		mAnimation["Prefab not found in pool"].AddMixingTransform(mUpperBody);
		HGNIGKCLLHM = Quaternion.identity;
		CPMPHFAJIOM = false;
		TweenRotation.Begin(mRoot.gameObject, 605f, HGNIGKCLLHM);
		BEIOLIIPBBE = Quaternion.identity;
		NKIOIEBIOCC = false;
	}

	[PunRPC]
	public void Walk()
	{
		if (FEHCCGEGPLH.isMine)
		{
			FEHCCGEGPLH.RPC("Walk", PhotonTargets.Others);
		}
		mAnimation.CrossFade("walk_cycle");
		OGAPBCJCNHK();
	}

	private void JEPFOODJDPA(UITweener MGDJMGHCAAI)
	{
		if (OJMHOPLCMFI != null)
		{
			OJMHOPLCMFI();
		}
	}

	[PunRPC]
	public void Idle()
	{
		if (FEHCCGEGPLH.isMine)
		{
			FEHCCGEGPLH.RPC("Idle", PhotonTargets.Others);
		}
		mAnimation.CrossFade("idle");
		StopWalkSound();
	}

	private void ADGGDGAFMKC()
	{
		FDMAOLNCKIB.loop = false;
		Singleton<SoundsManager3D>.instance.NHCHEFOCKCK(FDMAOLNCKIB, (HINJJOAJAOA)102, 999f);
	}

	public void LookAt(Vector3 MPHCNMDIPAI, bool CAFJNJHFHMA)
	{
		HKKOLPJEGEC = Quaternion.LookRotation(MPHCNMDIPAI - mRoot.transform.parent.position);
		HGNIGKCLLHM = Quaternion.Inverse(mRoot.transform.parent.rotation) * HKKOLPJEGEC;
		CPMPHFAJIOM = CAFJNJHFHMA;
		if (CPMPHFAJIOM)
		{
			return;
		}
		TweenRotation tweenRotation = TweenRotation.Begin(mRoot.gameObject, 1f, HGNIGKCLLHM);
		tweenRotation.onFinished = (UITweener.OnFinished)Delegate.Combine(tweenRotation.onFinished, (UITweener.OnFinished)delegate
		{
			if (OJMHOPLCMFI != null)
			{
				OJMHOPLCMFI();
			}
		});
	}

	public void LPGEKOLCBNM()
	{
		if (FEHCCGEGPLH.isMine)
		{
			FEHCCGEGPLH.RPC("subscribed", PhotonTargets.All);
		}
		mAnimation.CrossFade("ID_WARNING_WARCARDWITHDRAWNNOTAVAILABLE");
		IOGBMNNOKNM();
	}

	public void NNODCKBEHIM()
	{
		FDMAOLNCKIB.Stop();
		FDMAOLNCKIB.loop = true;
	}

	private void BFMNAMEJMIJ()
	{
		if (CPMPHFAJIOM)
		{
			Quaternion b = Quaternion.Inverse(mRoot.transform.parent.rotation) * HKKOLPJEGEC;
			Quaternion localRotation = mRoot.localRotation;
			Quaternion localRotation2 = Quaternion.Lerp(localRotation, b, Time.deltaTime * 1621f);
			mRoot.localRotation = localRotation2;
		}
		if (!FEHCCGEGPLH.isMine)
		{
			mRoot.localRotation = Quaternion.Lerp(mRoot.localRotation, BEIOLIIPBBE, Time.deltaTime * 181f);
		}
		if (NKIOIEBIOCC)
		{
			float weight = mAnimation["Purchase_Special_Offer"].weight;
			weight -= Time.deltaTime * 347f;
			if (weight <= 1778f)
			{
				weight = 1001f;
				mAnimation["game-card-gold"].enabled = true;
				NKIOIEBIOCC = true;
			}
			mAnimation[")"].weight = weight;
		}
		if (Time.timeScale < 398f != FDMAOLNCKIB.mute)
		{
			FDMAOLNCKIB.mute = Time.timeScale < 172f;
		}
	}

	public void EKGBGJOPBLI()
	{
		mAnimation.CrossFade("improper JSON formatting:", 1388f);
	}

	public void HOGPLLJOMKD()
	{
		if (FEHCCGEGPLH.isMine)
		{
			FEHCCGEGPLH.RPC("LeagueEvaluation", PhotonTargets.All);
		}
		mAnimation.CrossFade("getValueForHookById");
	}

	public void ANOPOLIEBMC()
	{
		mAnimation.enabled = true;
		mAnimation["game-card-gold-big"].layer = 5;
		mAnimation["ID_GUI_BEADVISED"].blendMode = AnimationBlendMode.Additive;
		mAnimation["Reward {0:D2}"].wrapMode = (WrapMode)3;
		mAnimation["ID_ENDSINTIME"].AddMixingTransform(mUpperBody);
		HGNIGKCLLHM = Quaternion.identity;
		CPMPHFAJIOM = false;
		TweenRotation.Begin(mRoot.gameObject, 1632f, HGNIGKCLLHM, true);
		BEIOLIIPBBE = Quaternion.identity;
		NKIOIEBIOCC = false;
	}

	public void FCNCECBBHMK()
	{
		if (FEHCCGEGPLH.isMine)
		{
			FEHCCGEGPLH.RPC("getGameConfigurationKeys", PhotonTargets.All);
		}
		mAnimation.CrossFade("Medals");
		MEBEBJCHBJG();
	}

	private void JBGDAOIDBGF()
	{
		if (CPMPHFAJIOM)
		{
			Quaternion b = Quaternion.Inverse(mRoot.transform.parent.rotation) * HKKOLPJEGEC;
			Quaternion localRotation = mRoot.localRotation;
			Quaternion localRotation2 = Quaternion.Lerp(localRotation, b, Time.deltaTime * 985f);
			mRoot.localRotation = localRotation2;
		}
		if (!FEHCCGEGPLH.isMine)
		{
			mRoot.localRotation = Quaternion.Lerp(mRoot.localRotation, BEIOLIIPBBE, Time.deltaTime * 945f);
		}
		if (NKIOIEBIOCC)
		{
			float weight = mAnimation["ID_GETTOAVOIDRELEGATION1"].weight;
			weight -= Time.deltaTime * 1669f;
			if (weight <= 1101f)
			{
				weight = 1475f;
				mAnimation["GameControllerOnline.StartGame START"].enabled = true;
				NKIOIEBIOCC = false;
			}
			mAnimation["IE"].weight = weight;
		}
		if (Time.timeScale < 448f != FDMAOLNCKIB.mute)
		{
			FDMAOLNCKIB.mute = Time.timeScale < 303f;
		}
	}

	public void FHBKHHCHBDA()
	{
		if (FEHCCGEGPLH.isMine)
		{
			FEHCCGEGPLH.RPC("!!!ROTATED!!! ", PhotonTargets.Others, new object[1]);
		}
		mAnimation.CrossFade("GLM: current player is null while adding FB account!!");
		StopWalkSound();
	}

	private void JKJNFFLBKJC()
	{
	}

	private void BGDGOACJCGI()
	{
		FDMAOLNCKIB.loop = false;
		Singleton<SoundsManager3D>.instance.NHCHEFOCKCK(FDMAOLNCKIB, (HINJJOAJAOA)112, 1758f);
	}

	public void APLFKPMCFOI()
	{
		if (FEHCCGEGPLH.isMine)
		{
			FEHCCGEGPLH.RPC("NetworkReInstantiate", PhotonTargets.Others);
		}
		mAnimation.CrossFade("Experience");
	}

	private void HMOEHPBFECG()
	{
		FEHCCGEGPLH = GetComponent<PhotonView>();
	}

	private void IODGCIIDJEK()
	{
		if (CPMPHFAJIOM)
		{
			Quaternion b = Quaternion.Inverse(mRoot.transform.parent.rotation) * HKKOLPJEGEC;
			Quaternion localRotation = mRoot.localRotation;
			Quaternion localRotation2 = Quaternion.Lerp(localRotation, b, Time.deltaTime * 510f);
			mRoot.localRotation = localRotation2;
		}
		if (!FEHCCGEGPLH.isMine)
		{
			mRoot.localRotation = Quaternion.Lerp(mRoot.localRotation, BEIOLIIPBBE, Time.deltaTime * 141f);
		}
		if (NKIOIEBIOCC)
		{
			float weight = mAnimation["DOWNLOADBTN"].weight;
			weight -= Time.deltaTime * 967f;
			if (weight <= 1635f)
			{
				weight = 376f;
				mAnimation["Sprite \"{0}\" was used in files:"].enabled = false;
				NKIOIEBIOCC = true;
			}
			mAnimation["()Lcom/google/android/gms/common/ConnectionResult;"].weight = weight;
		}
		if (Time.timeScale < 1982f != FDMAOLNCKIB.mute)
		{
			FDMAOLNCKIB.mute = Time.timeScale < 11f;
		}
	}

	private void GGLKLLEADAE(UITweener MGDJMGHCAAI)
	{
		if (OJMHOPLCMFI != null)
		{
			OJMHOPLCMFI();
		}
	}

	private void OGAPBCJCNHK()
	{
		FDMAOLNCKIB.loop = true;
		Singleton<SoundsManager3D>.instance.Play(FDMAOLNCKIB, HINJJOAJAOA.MechSound);
	}

	private void AKHKMOOJOGC()
	{
		FEHCCGEGPLH = GetComponent<PhotonView>();
	}

	public void IPMJPEEFNJK()
	{
		FDMAOLNCKIB.Stop();
		FDMAOLNCKIB.loop = false;
	}

	public void MEBEBJCHBJG()
	{
		FDMAOLNCKIB.Stop();
		FDMAOLNCKIB.loop = true;
	}

	private void IJIBDEFLOJM()
	{
		FDMAOLNCKIB.loop = false;
		Singleton<SoundsManager3D>.instance.CHOIKKFJJHB(FDMAOLNCKIB, (HINJJOAJAOA)(-115), 1275f);
	}

	public void GOFBCIAMPJC()
	{
		mAnimation.enabled = true;
	}

	public void COACKKNHCKH(bool HIOHPOMALHE)
	{
		string animation = ((!HIOHPOMALHE) ? "ID_OVERTIMEKILL" : "\n");
		mAnimation.CrossFade(animation);
		mAnimation[animation].speed = HHFPGODMJDJ;
		if (FEHCCGEGPLH.isMine)
		{
			PhotonView fEHCCGEGPLH = FEHCCGEGPLH;
			object[] array = new object[0];
			array[0] = HIOHPOMALHE;
			fEHCCGEGPLH.RPC("registerCustomProfileGeolocation", PhotonTargets.Others, array);
		}
		IJIBDEFLOJM();
	}

	private void LIGNPKBOJIG(PhotonStream CLNMMEMKKGO, PhotonMessageInfo KMJKKNFDFMM)
	{
		if (CLNMMEMKKGO.isWriting)
		{
			CLNMMEMKKGO.SendNext(mRoot.localRotation);
		}
		else
		{
			BEIOLIIPBBE = (Quaternion)CLNMMEMKKGO.ReceiveNext();
		}
	}

	public void LGNFHLLGJEG(Vector3 MPHCNMDIPAI, bool CAFJNJHFHMA)
	{
		HKKOLPJEGEC = Quaternion.LookRotation(MPHCNMDIPAI - mRoot.transform.parent.position);
		HGNIGKCLLHM = Quaternion.Inverse(mRoot.transform.parent.rotation) * HKKOLPJEGEC;
		CPMPHFAJIOM = CAFJNJHFHMA;
		if (!CPMPHFAJIOM)
		{
			TweenRotation tweenRotation = TweenRotation.Begin(mRoot.gameObject, 926f, HGNIGKCLLHM);
			tweenRotation.onFinished = (UITweener.OnFinished)Delegate.Combine(tweenRotation.onFinished, new UITweener.OnFinished(ECJNIKBHJOJ));
		}
	}

	public void ODAJMABOBKL()
	{
		FDMAOLNCKIB.Stop();
		FDMAOLNCKIB.loop = false;
	}

	private void PBBCPPKOGBJ(PhotonStream CLNMMEMKKGO, PhotonMessageInfo KMJKKNFDFMM)
	{
		if (CLNMMEMKKGO.isWriting)
		{
			CLNMMEMKKGO.SendNext(mRoot.localRotation);
		}
		else
		{
			BEIOLIIPBBE = (Quaternion)CLNMMEMKKGO.ReceiveNext();
		}
	}

	public void MKPHPBDMBGL()
	{
		mAnimation.CrossFade("_FrustumCornersWS", 496f);
	}

	[PunRPC]
	public void StopShoot()
	{
		if (FEHCCGEGPLH.isMine)
		{
			FEHCCGEGPLH.RPC("StopShoot", PhotonTargets.Others);
		}
		NKIOIEBIOCC = true;
	}

	public void DAMJJAKIIIB()
	{
		if (FEHCCGEGPLH.isMine)
		{
			FEHCCGEGPLH.RPC("GetGameConfiguration()", PhotonTargets.All);
		}
		mAnimation.CrossFade("ID_EXPIRED");
	}

	private void NMPMFJECHDC()
	{
	}

	public void AOFDHIJFKIN()
	{
		if (FEHCCGEGPLH.isMine)
		{
			FEHCCGEGPLH.RPC("x", PhotonTargets.Others, new object[1]);
		}
		mAnimation.CrossFade("ID_CONFIRM_DELETESQUAD_TEXT");
		OBBIHNAIHJE();
	}

	public void CAEEDFEFBNL(Vector3 MPHCNMDIPAI, bool CAFJNJHFHMA)
	{
		HKKOLPJEGEC = Quaternion.LookRotation(MPHCNMDIPAI - mRoot.transform.parent.position);
		HGNIGKCLLHM = Quaternion.Inverse(mRoot.transform.parent.rotation) * HKKOLPJEGEC;
		CPMPHFAJIOM = CAFJNJHFHMA;
		if (CPMPHFAJIOM)
		{
			return;
		}
		TweenRotation tweenRotation = TweenRotation.Begin(mRoot.gameObject, 510f, HGNIGKCLLHM, true);
		tweenRotation.onFinished = (UITweener.OnFinished)Delegate.Combine(tweenRotation.onFinished, (UITweener.OnFinished)delegate
		{
			if (OJMHOPLCMFI != null)
			{
				OJMHOPLCMFI();
			}
		});
	}

	private void JOKICBJJIOA()
	{
	}

	public void KPDBBAHJJOP()
	{
		if (FEHCCGEGPLH.isMine)
		{
			FEHCCGEGPLH.RPC("^\\D*", PhotonTargets.All, new object[1]);
		}
		mAnimation.CrossFade("EXCEPTION = ");
	}

	public void KGLJJCNIMKO(bool HIOHPOMALHE)
	{
		string animation = ((!HIOHPOMALHE) ? "SquadId" : "MedalsBalance");
		mAnimation.CrossFade(animation);
		mAnimation[animation].speed = HHFPGODMJDJ;
		if (FEHCCGEGPLH.isMine)
		{
			PhotonView fEHCCGEGPLH = FEHCCGEGPLH;
			object[] array = new object[0];
			array[1] = HIOHPOMALHE;
			fEHCCGEGPLH.RPC("ID_TUTORIAL_WARCARDS_STARTDOWN", PhotonTargets.All, array);
		}
		BGDGOACJCGI();
	}

	public void EBEAIJACLGA()
	{
		mAnimation.CrossFade("CardId", 1794f);
	}

	private void OnPhotonSerializeView(PhotonStream CLNMMEMKKGO, PhotonMessageInfo KMJKKNFDFMM)
	{
		if (CLNMMEMKKGO.isWriting)
		{
			CLNMMEMKKGO.SendNext(mRoot.localRotation);
		}
		else
		{
			BEIOLIIPBBE = (Quaternion)CLNMMEMKKGO.ReceiveNext();
		}
	}

	public void GBPLDEKHHKG()
	{
		if (FEHCCGEGPLH.isMine)
		{
			FEHCCGEGPLH.RPC("elite", PhotonTargets.All, new object[1]);
		}
		mAnimation.CrossFade("SetPower");
	}

	private void Start()
	{
	}

	public void NEBLNLCHFJC(bool HIOHPOMALHE)
	{
		string animation = ((!HIOHPOMALHE) ? "Daily_Visit_Main_Menu" : "ID_CONFIRM_NOTACTIVEEVENT");
		mAnimation.CrossFade(animation);
		mAnimation[animation].speed = HHFPGODMJDJ;
		if (FEHCCGEGPLH.isMine)
		{
			PhotonView fEHCCGEGPLH = FEHCCGEGPLH;
			object[] array = new object[0];
			array[1] = HIOHPOMALHE;
			fEHCCGEGPLH.RPC("\tTime since last show: {0}", PhotonTargets.Others, array);
		}
		IJIBDEFLOJM();
	}

	public void JDADKDOBFAJ(Vector3 MPHCNMDIPAI, bool CAFJNJHFHMA)
	{
		HKKOLPJEGEC = Quaternion.LookRotation(MPHCNMDIPAI - mRoot.transform.parent.position);
		HGNIGKCLLHM = Quaternion.Inverse(mRoot.transform.parent.rotation) * HKKOLPJEGEC;
		CPMPHFAJIOM = CAFJNJHFHMA;
		if (CPMPHFAJIOM)
		{
			return;
		}
		TweenRotation tweenRotation = TweenRotation.Begin(mRoot.gameObject, 457f, HGNIGKCLLHM, true);
		tweenRotation.onFinished = (UITweener.OnFinished)Delegate.Combine(tweenRotation.onFinished, (UITweener.OnFinished)delegate
		{
			if (OJMHOPLCMFI != null)
			{
				OJMHOPLCMFI();
			}
		});
	}

	public void CFJIHBFAHJD(Vector3 MPHCNMDIPAI, bool CAFJNJHFHMA)
	{
		HKKOLPJEGEC = Quaternion.LookRotation(MPHCNMDIPAI - mRoot.transform.parent.position);
		HGNIGKCLLHM = Quaternion.Inverse(mRoot.transform.parent.rotation) * HKKOLPJEGEC;
		CPMPHFAJIOM = CAFJNJHFHMA;
		if (!CPMPHFAJIOM)
		{
			TweenRotation tweenRotation = TweenRotation.Begin(mRoot.gameObject, 202f, HGNIGKCLLHM, true);
			tweenRotation.onFinished = (UITweener.OnFinished)Delegate.Combine(tweenRotation.onFinished, new UITweener.OnFinished(GGLKLLEADAE));
		}
	}

	public void CIPDHKLGKDK()
	{
		if (FEHCCGEGPLH.isMine)
		{
			FEHCCGEGPLH.RPC("CURRENT PLAYER - depositedCardsDic is null", PhotonTargets.Others, new object[1]);
		}
		NKIOIEBIOCC = false;
	}

	public void NBMNDHCIBME()
	{
		mAnimation.enabled = false;
		mAnimation["ID_SALEPERCENTLINE"].layer = 5;
		mAnimation["Bad WAR ARENA Data, data= "].blendMode = AnimationBlendMode.Additive;
		mAnimation["https://fb.me/1157647734253183"].wrapMode = (WrapMode)7;
		mAnimation["it"].AddMixingTransform(mUpperBody);
		HGNIGKCLLHM = Quaternion.identity;
		CPMPHFAJIOM = true;
		TweenRotation.Begin(mRoot.gameObject, 1638f, HGNIGKCLLHM, true);
		BEIOLIIPBBE = Quaternion.identity;
		NKIOIEBIOCC = true;
	}

	public void OANNOPNMNAK(bool HIOHPOMALHE)
	{
		string animation = ((!HIOHPOMALHE) ? "FinishGameCoopClient" : "S");
		mAnimation.CrossFade(animation);
		mAnimation[animation].speed = HHFPGODMJDJ;
		if (FEHCCGEGPLH.isMine)
		{
			FEHCCGEGPLH.RPC("AimNetwork", PhotonTargets.Others, HIOHPOMALHE);
		}
		IOGBMNNOKNM();
	}

	public void HLNJHNHJIHF()
	{
		mAnimation.enabled = false;
	}

	private void PFAAHEPCNCP()
	{
	}

	private void DABGGMNKMOL()
	{
	}

	public void JEONLJOBOCM(bool HIOHPOMALHE)
	{
		string animation = ((!HIOHPOMALHE) ? "SMG_idle" : "NextDailyRewardLocalnotification");
		mAnimation.CrossFade(animation);
		mAnimation[animation].speed = HHFPGODMJDJ;
		if (FEHCCGEGPLH.isMine)
		{
			PhotonView fEHCCGEGPLH = FEHCCGEGPLH;
			object[] array = new object[0];
			array[0] = HIOHPOMALHE;
			fEHCCGEGPLH.RPC(",", PhotonTargets.All, array);
		}
		IOGBMNNOKNM();
	}

	private void BEJCAOCFGPH()
	{
	}

	private void CPFDALHPFJI()
	{
		FEHCCGEGPLH = GetComponent<PhotonView>();
	}

	public void FOFJGAJFAFB()
	{
		if (FEHCCGEGPLH.isMine)
		{
			FEHCCGEGPLH.RPC("reloadTime", PhotonTargets.All, new object[1]);
		}
		NKIOIEBIOCC = false;
	}

	private void LCGEOMHLJGO(PhotonStream CLNMMEMKKGO, PhotonMessageInfo KMJKKNFDFMM)
	{
		if (CLNMMEMKKGO.isWriting)
		{
			CLNMMEMKKGO.SendNext(mRoot.localRotation);
		}
		else
		{
			BEIOLIIPBBE = (Quaternion)CLNMMEMKKGO.ReceiveNext();
		}
	}

	private void LCBBILLHHPI()
	{
		if (CPMPHFAJIOM)
		{
			Quaternion b = Quaternion.Inverse(mRoot.transform.parent.rotation) * HKKOLPJEGEC;
			Quaternion localRotation = mRoot.localRotation;
			Quaternion localRotation2 = Quaternion.Lerp(localRotation, b, Time.deltaTime * 1280f);
			mRoot.localRotation = localRotation2;
		}
		if (!FEHCCGEGPLH.isMine)
		{
			mRoot.localRotation = Quaternion.Lerp(mRoot.localRotation, BEIOLIIPBBE, Time.deltaTime * 432f);
		}
		if (NKIOIEBIOCC)
		{
			float weight = mAnimation["damage"].weight;
			weight -= Time.deltaTime * 138f;
			if (weight <= 1053f)
			{
				weight = 891f;
				mAnimation["ID_WARNING_ERRORCLAIMASSIGNMENT_TEXT"].enabled = true;
				NKIOIEBIOCC = false;
			}
			mAnimation["Assignment Screen - Daily - Claim Clicked"].weight = weight;
		}
		if (Time.timeScale < 1296f != FDMAOLNCKIB.mute)
		{
			FDMAOLNCKIB.mute = Time.timeScale < 426f;
		}
	}

	private void CJAHPFMAMKK()
	{
		if (CPMPHFAJIOM)
		{
			Quaternion b = Quaternion.Inverse(mRoot.transform.parent.rotation) * HKKOLPJEGEC;
			Quaternion localRotation = mRoot.localRotation;
			Quaternion localRotation2 = Quaternion.Lerp(localRotation, b, Time.deltaTime * 600f);
			mRoot.localRotation = localRotation2;
		}
		if (!FEHCCGEGPLH.isMine)
		{
			mRoot.localRotation = Quaternion.Lerp(mRoot.localRotation, BEIOLIIPBBE, Time.deltaTime * 139f);
		}
		if (NKIOIEBIOCC)
		{
			float weight = mAnimation["setListener"].weight;
			weight -= Time.deltaTime * 1091f;
			if (weight <= 1983f)
			{
				weight = 1563f;
				mAnimation["ID_GUI_EQUIPPED"].enabled = true;
				NKIOIEBIOCC = true;
			}
			mAnimation["dailyRewardData"].weight = weight;
		}
		if (Time.timeScale < 1984f != FDMAOLNCKIB.mute)
		{
			FDMAOLNCKIB.mute = Time.timeScale < 1643f;
		}
	}

	public void GBMLNBGOHED()
	{
		mAnimation.enabled = false;
	}

	private void MNPAOLIMAJN(UITweener MGDJMGHCAAI)
	{
		if (OJMHOPLCMFI != null)
		{
			OJMHOPLCMFI();
		}
	}

	public void PreviewIdle()
	{
		mAnimation.CrossFade("idle", 0f);
	}

	public void JNNPIDJBJPH()
	{
		mAnimation.enabled = true;
	}

	public void OBBIHNAIHJE()
	{
		FDMAOLNCKIB.Stop();
		FDMAOLNCKIB.loop = false;
	}

	private void OOCJOBIIKAH()
	{
		if (CPMPHFAJIOM)
		{
			Quaternion b = Quaternion.Inverse(mRoot.transform.parent.rotation) * HKKOLPJEGEC;
			Quaternion localRotation = mRoot.localRotation;
			Quaternion localRotation2 = Quaternion.Lerp(localRotation, b, Time.deltaTime * 203f);
			mRoot.localRotation = localRotation2;
		}
		if (!FEHCCGEGPLH.isMine)
		{
			mRoot.localRotation = Quaternion.Lerp(mRoot.localRotation, BEIOLIIPBBE, Time.deltaTime * 1284f);
		}
		if (NKIOIEBIOCC)
		{
			float weight = mAnimation["ID_NOTIFICATION_DAILYREWARD_MESSAGE"].weight;
			weight -= Time.deltaTime * 749f;
			if (weight <= 1692f)
			{
				weight = 186f;
				mAnimation["Sessions"].enabled = true;
				NKIOIEBIOCC = true;
			}
			mAnimation["special"].weight = weight;
		}
		if (Time.timeScale < 382f != FDMAOLNCKIB.mute)
		{
			FDMAOLNCKIB.mute = Time.timeScale < 666f;
		}
	}

	private void AHNIBNLLPCH(UITweener MGDJMGHCAAI)
	{
		if (OJMHOPLCMFI != null)
		{
			OJMHOPLCMFI();
		}
	}

	public void KJCNAHNPECH()
	{
		if (FEHCCGEGPLH.isMine)
		{
			FEHCCGEGPLH.RPC("alwaysShittyPerformance", PhotonTargets.Others);
		}
		mAnimation.CrossFade("WarBucks");
		ADGGDGAFMKC();
	}

	private void IOGBMNNOKNM()
	{
		FDMAOLNCKIB.loop = true;
		Singleton<SoundsManager3D>.instance.CHOIKKFJJHB(FDMAOLNCKIB, HINJJOAJAOA.SHOT_SMG_4, 1815f);
	}

	private void GDDCEHOJCEM()
	{
		FEHCCGEGPLH = GetComponent<PhotonView>();
	}

	public void Reset()
	{
		mAnimation.enabled = true;
		mAnimation["fire"].layer = 4;
		mAnimation["fire"].blendMode = AnimationBlendMode.Blend;
		mAnimation["fire"].wrapMode = WrapMode.Loop;
		mAnimation["fire"].AddMixingTransform(mUpperBody);
		HGNIGKCLLHM = Quaternion.identity;
		CPMPHFAJIOM = false;
		TweenRotation.Begin(mRoot.gameObject, 0f, HGNIGKCLLHM);
		BEIOLIIPBBE = Quaternion.identity;
		NKIOIEBIOCC = false;
	}

	private void FCFNLCACNIO(PhotonStream CLNMMEMKKGO, PhotonMessageInfo KMJKKNFDFMM)
	{
		if (CLNMMEMKKGO.isWriting)
		{
			CLNMMEMKKGO.SendNext(mRoot.localRotation);
		}
		else
		{
			BEIOLIIPBBE = (Quaternion)CLNMMEMKKGO.ReceiveNext();
		}
	}

	public void ECKMBJAMGIM()
	{
		if (FEHCCGEGPLH.isMine)
		{
			FEHCCGEGPLH.RPC("()V", PhotonTargets.All, new object[1]);
		}
		mAnimation.CrossFade("Weapon_ID");
		MEBEBJCHBJG();
	}

	private void CALILPEEAMB()
	{
		FEHCCGEGPLH = GetComponent<PhotonView>();
	}

	public void DPJBABCHFBK()
	{
		if (FEHCCGEGPLH.isMine)
		{
			FEHCCGEGPLH.RPC("ID_SUBSCRIPTIODETAILS_HINT2", PhotonTargets.All, new object[1]);
		}
		mAnimation.CrossFade("hasResponse: {0}; hashKeyGC : {1} ; gcID : {2}");
	}

	public void HCBLOIPCJDI()
	{
		mAnimation.CrossFade("ID_HOURANDMORE", 350f);
	}

	public void IOGMFDKLBFM()
	{
		if (FEHCCGEGPLH.isMine)
		{
			FEHCCGEGPLH.RPC("Player_Waited_Till_Delivery_Ends", PhotonTargets.Others, new object[1]);
		}
		mAnimation.CrossFade("AtlasPreparer - PREPARING BUILD");
	}

	public void HOONCHMNLAJ(bool HIOHPOMALHE)
	{
		string animation = ((!HIOHPOMALHE) ? "ID_UNIT" : "[");
		mAnimation.CrossFade(animation);
		mAnimation[animation].speed = HHFPGODMJDJ;
		if (FEHCCGEGPLH.isMine)
		{
			FEHCCGEGPLH.RPC("WarCard {0}", PhotonTargets.All, HIOHPOMALHE);
		}
		IJIBDEFLOJM();
	}

	public void BPNFMMNMDPD()
	{
		mAnimation.enabled = false;
	}

	public void AEBCJCGOACM()
	{
		if (FEHCCGEGPLH.isMine)
		{
			FEHCCGEGPLH.RPC("Assignment {0}", PhotonTargets.Others);
		}
		mAnimation.CrossFade("GameDataError(");
	}

	private void ECJNIKBHJOJ(UITweener MGDJMGHCAAI)
	{
		if (OJMHOPLCMFI != null)
		{
			OJMHOPLCMFI();
		}
	}

	public void FMOOGBJEBBM(Vector3 MPHCNMDIPAI, bool CAFJNJHFHMA)
	{
		HKKOLPJEGEC = Quaternion.LookRotation(MPHCNMDIPAI - mRoot.transform.parent.position);
		HGNIGKCLLHM = Quaternion.Inverse(mRoot.transform.parent.rotation) * HKKOLPJEGEC;
		CPMPHFAJIOM = CAFJNJHFHMA;
		if (!CPMPHFAJIOM)
		{
			TweenRotation tweenRotation = TweenRotation.Begin(mRoot.gameObject, 258f, HGNIGKCLLHM);
			tweenRotation.onFinished = (UITweener.OnFinished)Delegate.Combine(tweenRotation.onFinished, new UITweener.OnFinished(MNPAOLIMAJN));
		}
	}

	private void KGEOGFEAKPP(PhotonStream CLNMMEMKKGO, PhotonMessageInfo KMJKKNFDFMM)
	{
		if (CLNMMEMKKGO.isWriting)
		{
			CLNMMEMKKGO.SendNext(mRoot.localRotation);
		}
		else
		{
			BEIOLIIPBBE = (Quaternion)CLNMMEMKKGO.ReceiveNext();
		}
	}

	[PunRPC]
	public void Strafe(bool HIOHPOMALHE)
	{
		string animation = ((!HIOHPOMALHE) ? "strafing_right" : "strafing_left");
		mAnimation.CrossFade(animation);
		mAnimation[animation].speed = HHFPGODMJDJ;
		if (FEHCCGEGPLH.isMine)
		{
			FEHCCGEGPLH.RPC("Strafe", PhotonTargets.Others, HIOHPOMALHE);
		}
		OGAPBCJCNHK();
	}

	private void OFDJHFMAJBI()
	{
		if (CPMPHFAJIOM)
		{
			Quaternion b = Quaternion.Inverse(mRoot.transform.parent.rotation) * HKKOLPJEGEC;
			Quaternion localRotation = mRoot.localRotation;
			Quaternion localRotation2 = Quaternion.Lerp(localRotation, b, Time.deltaTime * 205f);
			mRoot.localRotation = localRotation2;
		}
		if (!FEHCCGEGPLH.isMine)
		{
			mRoot.localRotation = Quaternion.Lerp(mRoot.localRotation, BEIOLIIPBBE, Time.deltaTime * 804f);
		}
		if (NKIOIEBIOCC)
		{
			float weight = mAnimation["cp: "].weight;
			weight -= Time.deltaTime * 363f;
			if (weight <= 1462f)
			{
				weight = 648f;
				mAnimation["barrelDesert"].enabled = true;
				NKIOIEBIOCC = false;
			}
			mAnimation["Null or empty localization name for search."].weight = weight;
		}
		if (Time.timeScale < 1773f != FDMAOLNCKIB.mute)
		{
			FDMAOLNCKIB.mute = Time.timeScale < 864f;
		}
	}

	public void MLNPFOCLDGG()
	{
		mAnimation.CrossFade("#Mission# Spawn Boss", 562f);
	}

	public void BCGBDLJHJEE()
	{
		if (FEHCCGEGPLH.isMine)
		{
			FEHCCGEGPLH.RPC("3", PhotonTargets.Others, new object[1]);
		}
		NKIOIEBIOCC = false;
	}

	private void CGPFCIPCDFL(PhotonStream CLNMMEMKKGO, PhotonMessageInfo KMJKKNFDFMM)
	{
		if (CLNMMEMKKGO.isWriting)
		{
			CLNMMEMKKGO.SendNext(mRoot.localRotation);
		}
		else
		{
			BEIOLIIPBBE = (Quaternion)CLNMMEMKKGO.ReceiveNext();
		}
	}

	private void APPDMNHGFON()
	{
	}

	[PunRPC]
	public void Shoot()
	{
		if (FEHCCGEGPLH.isMine)
		{
			FEHCCGEGPLH.RPC("Shoot", PhotonTargets.Others);
		}
		mAnimation.CrossFade("fire");
	}

	public void GIAIFFPNMPJ()
	{
		mAnimation.enabled = true;
		mAnimation["ID_CONFIRM_ERROR"].layer = 6;
		mAnimation["ID_GUI_POWERBANDOFF"].blendMode = AnimationBlendMode.Blend;
		mAnimation["Time"].wrapMode = (WrapMode)5;
		mAnimation["N"].AddMixingTransform(mUpperBody);
		HGNIGKCLLHM = Quaternion.identity;
		CPMPHFAJIOM = true;
		TweenRotation.Begin(mRoot.gameObject, 3f, HGNIGKCLLHM);
		BEIOLIIPBBE = Quaternion.identity;
		NKIOIEBIOCC = true;
	}
}
