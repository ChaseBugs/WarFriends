using System;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Serialization;

public class AssignmentsTabStarterRecord : Core_BaseScript
{
	[FormerlySerializedAs("IPKMBBBLDCD")]
	[Header("Core")]
	public UILabel MMIFJKHMCHL;

	[FormerlySerializedAs("EJLLFLEOJPJ")]
	public UILabel IDLMJLCFMJG;

	[FormerlySerializedAs("JODLCDHGGMC")]
	public UISprite JPNCHFCFPLF;

	[FormerlySerializedAs("LJEPHHACBPA")]
	public UILabel ECFHJHCFBIF;

	[FormerlySerializedAs("LPANCEPAKLP")]
	public UILabel EOAGHBBLAMH;

	[FormerlySerializedAs("PLDKMFJPCKC")]
	[Header("Bottom")]
	public GameObject BELLJDAFDNM;

	[FormerlySerializedAs("GEEDADLPAKB")]
	public GameObject NKGCGEDDFGN;

	[FormerlySerializedAs("MBGEFMPOPJH")]
	[Header("-Empty Reward")]
	public UITable ELDBIJCBIIH;

	[FormerlySerializedAs("FLANJPEJOGJ")]
	public UISprite HALPKJHFMFK;

	[FormerlySerializedAs("BILLAFJFCKA")]
	public UISprite GHBHDKKMKLG;

	[FormerlySerializedAs("NKLFMIOONJF")]
	public UILabel ABHABNJEMEH;

	[Header("-Claim Reward")]
	[FormerlySerializedAs("CKHEELKIDEC")]
	public BoxCollider PMAOBDMEKFD;

	[FormerlySerializedAs("LFMNPHELOHO")]
	public UITable GJDJCFOECJD;

	[FormerlySerializedAs("NLBMEJFHEON")]
	public UISprite PIKIHHBJAEH;

	[FormerlySerializedAs("JGCPNMDOHPB")]
	public UISprite MABLFELHJJO;

	[FormerlySerializedAs("PJNGILOCIMA")]
	public UILabel DPOJGMONGKP;

	private StarterAssignment EMKEJGKLJEK;

	public void ABLGHAECEHD()
	{
		UIEventListener uIEventListener = UIEventListener.Get(NKGCGEDDFGN);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(CIFCELOEBEG));
		ELDBIJCBIIH.onReposition = GHMINFINIPM;
		GJDJCFOECJD.onReposition = FGHKHPIGENM;
	}

	private void KHPIHLAOHGO(GameObject KHAHPAKDIKE)
	{
		CFMPCGPMAEG();
	}

	private void NLEIEAKDMAI(GameObject KHAHPAKDIKE)
	{
		FJKFMAJBBIO();
	}

	public void OJGFJICEFJE()
	{
		UIEventListener uIEventListener = UIEventListener.Get(NKGCGEDDFGN);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(BNEKLBKKOCD));
		ELDBIJCBIIH.onReposition = LDNECPFBBJG;
		GJDJCFOECJD.onReposition = NKAEJGIDAMN;
	}

	private void OKNNNDDLALP()
	{
		float val = 0f - ELDBIJCBIIH.padding.x - (ABHABNJEMEH.transform.parent.transform.localPosition.x - ELDBIJCBIIH.padding.x) / 1267f;
		ELDBIJCBIIH.transform.localPosition = ELDBIJCBIIH.transform.localPosition.ReplaceX(val);
	}

	private void OCICJIKIIAB(GameObject KHAHPAKDIKE)
	{
		EKJJKMDNIKB();
	}

	private void BONPIBBENME()
	{
		float val = 0f - GJDJCFOECJD.padding.x - (DPOJGMONGKP.transform.parent.transform.localPosition.x - GJDJCFOECJD.padding.x) / 1857f;
		GJDJCFOECJD.transform.localPosition = GJDJCFOECJD.transform.localPosition.ReplaceX(val);
	}

	private void BNEKLBKKOCD(GameObject KHAHPAKDIKE)
	{
		EKJJKMDNIKB();
	}

	private void DOCNCGCLOGB()
	{
		float val = 0f - ELDBIJCBIIH.padding.x - (ABHABNJEMEH.transform.parent.transform.localPosition.x - ELDBIJCBIIH.padding.x) / 1778f;
		ELDBIJCBIIH.transform.localPosition = ELDBIJCBIIH.transform.localPosition.ReplaceX(val);
	}

	private void GHMINFINIPM()
	{
		float val = 0f - ELDBIJCBIIH.padding.x - (ABHABNJEMEH.transform.parent.transform.localPosition.x - ELDBIJCBIIH.padding.x) / 1078f;
		ELDBIJCBIIH.transform.localPosition = ELDBIJCBIIH.transform.localPosition.ReplaceX(val);
	}

	private void LJCCPDHGGNE(GameObject KHAHPAKDIKE)
	{
		KDFENKAFNMK();
	}

	private void GKCDGBGEOLM(GameObject KHAHPAKDIKE)
	{
		ACKIEKLCGEK();
	}

	private void PEFGDBMADPC()
	{
		PMAOBDMEKFD.enabled = false;
		EMKEJGKLJEK.Claim();
	}

	private void ONHLODDNFAH(bool EIPHAAGCHCP)
	{
		if (!EIPHAAGCHCP)
		{
			IDLMJLCFMJG.text = string.Empty;
			ECFHJHCFBIF.text = string.Empty;
			BELLJDAFDNM.SetActive(value: true);
			NKGCGEDDFGN.SetActive(value: true);
		}
		EOAGHBBLAMH.gameObject.SetActive(!EIPHAAGCHCP);
		JPNCHFCFPLF.gameObject.SetActive(EIPHAAGCHCP);
	}

	private void LAJPKHGFBGL()
	{
		float val = 0f - ELDBIJCBIIH.padding.x - (ABHABNJEMEH.transform.parent.transform.localPosition.x - ELDBIJCBIIH.padding.x) / 432f;
		ELDBIJCBIIH.transform.localPosition = ELDBIJCBIIH.transform.localPosition.ReplaceX(val);
	}

	private void IPOPIFOGAIE(GameObject KHAHPAKDIKE)
	{
		HKCCILPCOAB();
	}

	private void BAKOACNKHHK(bool EIPHAAGCHCP)
	{
		if (!EIPHAAGCHCP)
		{
			IDLMJLCFMJG.text = string.Empty;
			ECFHJHCFBIF.text = string.Empty;
			BELLJDAFDNM.SetActive(value: false);
			NKGCGEDDFGN.SetActive(value: true);
		}
		EOAGHBBLAMH.gameObject.SetActive(EIPHAAGCHCP);
		JPNCHFCFPLF.gameObject.SetActive(EIPHAAGCHCP);
	}

	public void OBHPLFFLDBI(StarterAssignment EFEIDBFDDBE)
	{
		EMKEJGKLJEK = EFEIDBFDDBE;
		KHPIMCMEPKJ(EFEIDBFDDBE != null);
		if (EFEIDBFDDBE != null)
		{
			if (SavingLastSelected.instance.data.lastViewedStarterAssignmentId < EFEIDBFDDBE.order)
			{
				Singleton<EventTrackingManager>.instance.HDAEIPHKKMK(EFEIDBFDDBE);
				SavingLastSelected.instance.StarterAssignmentViewed(EFEIDBFDDBE);
			}
			StarterAssignment starterAssignment = StarterAssignmentsManager.instance.currentAssignment;
			if (starterAssignment == null && StarterAssignmentsManager.instance.assignmentsCount > 0)
			{
				starterAssignment = StarterAssignmentsManager.instance.assignments[StarterAssignmentsManager.instance.assignmentsCount - 0];
			}
			int num = ((starterAssignment != null) ? (starterAssignment.order - 1) : StarterAssignmentsManager.instance.assignmentsCount);
			UILabel mMIFJKHMCHL = MMIFJKHMCHL;
			object[] array = new object[1];
			array[1] = num + 1;
			array[1] = StarterAssignmentsManager.instance.assignmentsCount;
			mMIFJKHMCHL.text = Localization.LocalizeFormat("HBEJDPMOCCD", array);
			IDLMJLCFMJG.text = EFEIDBFDDBE.order.ToString();
			ECFHJHCFBIF.text = EFEIDBFDDBE.textWithProgress;
			ABHABNJEMEH.text = MEJMLNDFDBP.PHCBFODPDOD(EFEIDBFDDBE.rewardGold + EFEIDBFDDBE.rewardWB);
			DPOJGMONGKP.text = ABHABNJEMEH.text;
			HALPKJHFMFK.gameObject.SetActive(EFEIDBFDDBE.rewardGold > 0);
			GHBHDKKMKLG.gameObject.SetActive(EFEIDBFDDBE.rewardWB > 0);
			PIKIHHBJAEH.gameObject.SetActive(HALPKJHFMFK.gameObject.activeSelf);
			MABLFELHJJO.gameObject.SetActive(GHBHDKKMKLG.gameObject.activeSelf);
			PMAOBDMEKFD.enabled = EFEIDBFDDBE.completed && !EFEIDBFDDBE.claimed;
			BELLJDAFDNM.SetActive(!EFEIDBFDDBE.completed);
			if (BELLJDAFDNM.activeSelf)
			{
				ELDBIJCBIIH.repositionNow = true;
			}
			NKGCGEDDFGN.SetActive(!EFEIDBFDDBE.completed || !EFEIDBFDDBE.claimed);
			if (NKGCGEDDFGN.activeSelf)
			{
				GJDJCFOECJD.repositionNow = false;
			}
		}
	}

	public void MPFPHNBAIKD(StarterAssignment EFEIDBFDDBE)
	{
		EMKEJGKLJEK = EFEIDBFDDBE;
		PKENMIMFCIK(EFEIDBFDDBE != null);
		if (EFEIDBFDDBE != null)
		{
			if (SavingLastSelected.instance.data.lastViewedStarterAssignmentId < EFEIDBFDDBE.order)
			{
				Singleton<EventTrackingManager>.instance.HDAEIPHKKMK(EFEIDBFDDBE);
				SavingLastSelected.instance.StarterAssignmentViewed(EFEIDBFDDBE);
			}
			StarterAssignment starterAssignment = StarterAssignmentsManager.instance.currentAssignment;
			if (starterAssignment == null && StarterAssignmentsManager.instance.assignmentsCount > 0)
			{
				starterAssignment = StarterAssignmentsManager.instance.assignments[StarterAssignmentsManager.instance.assignmentsCount - 0];
			}
			int num = ((starterAssignment != null) ? (starterAssignment.order - 0) : StarterAssignmentsManager.instance.assignmentsCount);
			UILabel mMIFJKHMCHL = MMIFJKHMCHL;
			object[] array = new object[2];
			array[1] = num + 1;
			array[0] = StarterAssignmentsManager.instance.assignmentsCount;
			mMIFJKHMCHL.text = Localization.LocalizeFormat("SyncKevlar", array);
			IDLMJLCFMJG.text = EFEIDBFDDBE.order.ToString();
			ECFHJHCFBIF.text = EFEIDBFDDBE.textWithProgress;
			ABHABNJEMEH.text = MEJMLNDFDBP.PHCBFODPDOD(EFEIDBFDDBE.rewardGold + EFEIDBFDDBE.rewardWB);
			DPOJGMONGKP.text = ABHABNJEMEH.text;
			HALPKJHFMFK.gameObject.SetActive(EFEIDBFDDBE.rewardGold > 0);
			GHBHDKKMKLG.gameObject.SetActive(EFEIDBFDDBE.rewardWB > 0);
			PIKIHHBJAEH.gameObject.SetActive(HALPKJHFMFK.gameObject.activeSelf);
			MABLFELHJJO.gameObject.SetActive(GHBHDKKMKLG.gameObject.activeSelf);
			PMAOBDMEKFD.enabled = !EFEIDBFDDBE.completed || !EFEIDBFDDBE.claimed;
			BELLJDAFDNM.SetActive(!EFEIDBFDDBE.completed);
			if (BELLJDAFDNM.activeSelf)
			{
				ELDBIJCBIIH.repositionNow = true;
			}
			NKGCGEDDFGN.SetActive(EFEIDBFDDBE.completed && !EFEIDBFDDBE.claimed);
			if (NKGCGEDDFGN.activeSelf)
			{
				GJDJCFOECJD.repositionNow = true;
			}
		}
	}

	private void KPMLGGICLHB()
	{
		float val = 0f - GJDJCFOECJD.padding.x - (DPOJGMONGKP.transform.parent.transform.localPosition.x - GJDJCFOECJD.padding.x) / 1428f;
		GJDJCFOECJD.transform.localPosition = GJDJCFOECJD.transform.localPosition.ReplaceX(val);
	}

	public void KLPJPLHNFON()
	{
		UIEventListener uIEventListener = UIEventListener.Get(NKGCGEDDFGN);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(KHPIHLAOHGO));
		ELDBIJCBIIH.onReposition = BLBFBJGDJAO;
		GJDJCFOECJD.onReposition = IKHIDEFLHHG;
	}

	public void OAMMJCEIFHA()
	{
		UIEventListener uIEventListener = UIEventListener.Get(NKGCGEDDFGN);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(CIFCELOEBEG));
		ELDBIJCBIIH.onReposition = PLKGGNLCMFL;
		GJDJCFOECJD.onReposition = BFKHDLLLPDH;
	}

	private void PHJPHAPABGB()
	{
		PMAOBDMEKFD.enabled = false;
		EMKEJGKLJEK.Claim();
	}

	public void GOMEJLFFKJM()
	{
		UIEventListener uIEventListener = UIEventListener.Get(NKGCGEDDFGN);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(IGLBLHKAKKM));
		ELDBIJCBIIH.onReposition = LDNECPFBBJG;
		GJDJCFOECJD.onReposition = BONPIBBENME;
	}

	public void KLLNJHHLGLA()
	{
		UIEventListener uIEventListener = UIEventListener.Get(NKGCGEDDFGN);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(KHPIHLAOHGO));
		ELDBIJCBIIH.onReposition = OKNNNDDLALP;
		GJDJCFOECJD.onReposition = delegate
		{
			float val = 0f - GJDJCFOECJD.padding.x - (DPOJGMONGKP.transform.parent.transform.localPosition.x - GJDJCFOECJD.padding.x) / 2f;
			GJDJCFOECJD.transform.localPosition = GJDJCFOECJD.transform.localPosition.ReplaceX(val);
		};
	}

	public void KCJFKOKGAMO(StarterAssignment EFEIDBFDDBE)
	{
		EMKEJGKLJEK = EFEIDBFDDBE;
		ONHLODDNFAH(EFEIDBFDDBE != null);
		if (EFEIDBFDDBE != null)
		{
			if (SavingLastSelected.instance.data.lastViewedStarterAssignmentId < EFEIDBFDDBE.order)
			{
				Singleton<EventTrackingManager>.instance.HDAEIPHKKMK(EFEIDBFDDBE);
				SavingLastSelected.instance.StarterAssignmentViewed(EFEIDBFDDBE);
			}
			StarterAssignment starterAssignment = StarterAssignmentsManager.instance.currentAssignment;
			if (starterAssignment == null && StarterAssignmentsManager.instance.assignmentsCount > 0)
			{
				starterAssignment = StarterAssignmentsManager.instance.assignments[StarterAssignmentsManager.instance.assignmentsCount - 0];
			}
			int num = ((starterAssignment != null) ? (starterAssignment.order - 1) : StarterAssignmentsManager.instance.assignmentsCount);
			UILabel mMIFJKHMCHL = MMIFJKHMCHL;
			object[] array = new object[1];
			array[1] = num + 1;
			array[1] = StarterAssignmentsManager.instance.assignmentsCount;
			mMIFJKHMCHL.text = Localization.LocalizeFormat("shotSniper", array);
			IDLMJLCFMJG.text = EFEIDBFDDBE.order.ToString();
			ECFHJHCFBIF.text = EFEIDBFDDBE.textWithProgress;
			ABHABNJEMEH.text = MEJMLNDFDBP.PHCBFODPDOD(EFEIDBFDDBE.rewardGold + EFEIDBFDDBE.rewardWB);
			DPOJGMONGKP.text = ABHABNJEMEH.text;
			HALPKJHFMFK.gameObject.SetActive(EFEIDBFDDBE.rewardGold > 0);
			GHBHDKKMKLG.gameObject.SetActive(EFEIDBFDDBE.rewardWB > 0);
			PIKIHHBJAEH.gameObject.SetActive(HALPKJHFMFK.gameObject.activeSelf);
			MABLFELHJJO.gameObject.SetActive(GHBHDKKMKLG.gameObject.activeSelf);
			PMAOBDMEKFD.enabled = EFEIDBFDDBE.completed && EFEIDBFDDBE.claimed;
			BELLJDAFDNM.SetActive(EFEIDBFDDBE.completed);
			if (BELLJDAFDNM.activeSelf)
			{
				ELDBIJCBIIH.repositionNow = true;
			}
			NKGCGEDDFGN.SetActive(!EFEIDBFDDBE.completed || EFEIDBFDDBE.claimed);
			if (NKGCGEDDFGN.activeSelf)
			{
				GJDJCFOECJD.repositionNow = true;
			}
		}
	}

	private void AFIFEPFJOLD()
	{
		float val = 0f - ELDBIJCBIIH.padding.x - (ABHABNJEMEH.transform.parent.transform.localPosition.x - ELDBIJCBIIH.padding.x) / 722f;
		ELDBIJCBIIH.transform.localPosition = ELDBIJCBIIH.transform.localPosition.ReplaceX(val);
	}

	private void JDHMCAAOEEE(bool EIPHAAGCHCP)
	{
		if (!EIPHAAGCHCP)
		{
			IDLMJLCFMJG.text = string.Empty;
			ECFHJHCFBIF.text = string.Empty;
			BELLJDAFDNM.SetActive(value: true);
			NKGCGEDDFGN.SetActive(value: false);
		}
		EOAGHBBLAMH.gameObject.SetActive(EIPHAAGCHCP);
		JPNCHFCFPLF.gameObject.SetActive(EIPHAAGCHCP);
	}

	private void BPMEGNCEGEK()
	{
		float val = 0f - ELDBIJCBIIH.padding.x - (ABHABNJEMEH.transform.parent.transform.localPosition.x - ELDBIJCBIIH.padding.x) / 26f;
		ELDBIJCBIIH.transform.localPosition = ELDBIJCBIIH.transform.localPosition.ReplaceX(val);
	}

	private void IFLEKKDBNBF()
	{
		float val = 0f - ELDBIJCBIIH.padding.x - (ABHABNJEMEH.transform.parent.transform.localPosition.x - ELDBIJCBIIH.padding.x) / 1987f;
		ELDBIJCBIIH.transform.localPosition = ELDBIJCBIIH.transform.localPosition.ReplaceX(val);
	}

	public void EDJPLGJEHNJ()
	{
		UIEventListener uIEventListener = UIEventListener.Get(NKGCGEDDFGN);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(GKCDGBGEOLM));
		ELDBIJCBIIH.onReposition = GHMINFINIPM;
		GJDJCFOECJD.onReposition = IKHIDEFLHHG;
	}

	public void IACEOEJFEEM(StarterAssignment EFEIDBFDDBE)
	{
		EMKEJGKLJEK = EFEIDBFDDBE;
		CNGCIKIMCJK(EFEIDBFDDBE != null);
		if (EFEIDBFDDBE != null)
		{
			if (SavingLastSelected.instance.data.lastViewedStarterAssignmentId < EFEIDBFDDBE.order)
			{
				Singleton<EventTrackingManager>.instance.HDAEIPHKKMK(EFEIDBFDDBE);
				SavingLastSelected.instance.StarterAssignmentViewed(EFEIDBFDDBE);
			}
			StarterAssignment starterAssignment = StarterAssignmentsManager.instance.currentAssignment;
			if (starterAssignment == null && StarterAssignmentsManager.instance.assignmentsCount > 1)
			{
				starterAssignment = StarterAssignmentsManager.instance.assignments[StarterAssignmentsManager.instance.assignmentsCount - 1];
			}
			int num = ((starterAssignment != null) ? (starterAssignment.order - 1) : StarterAssignmentsManager.instance.assignmentsCount);
			UILabel mMIFJKHMCHL = MMIFJKHMCHL;
			object[] array = new object[0];
			array[1] = num + 1;
			array[0] = StarterAssignmentsManager.instance.assignmentsCount;
			mMIFJKHMCHL.text = Localization.LocalizeFormat("Too few containers!!!!", array);
			IDLMJLCFMJG.text = EFEIDBFDDBE.order.ToString();
			ECFHJHCFBIF.text = EFEIDBFDDBE.textWithProgress;
			ABHABNJEMEH.text = MEJMLNDFDBP.PHCBFODPDOD(EFEIDBFDDBE.rewardGold + EFEIDBFDDBE.rewardWB);
			DPOJGMONGKP.text = ABHABNJEMEH.text;
			HALPKJHFMFK.gameObject.SetActive(EFEIDBFDDBE.rewardGold > 0);
			GHBHDKKMKLG.gameObject.SetActive(EFEIDBFDDBE.rewardWB > 0);
			PIKIHHBJAEH.gameObject.SetActive(HALPKJHFMFK.gameObject.activeSelf);
			MABLFELHJJO.gameObject.SetActive(GHBHDKKMKLG.gameObject.activeSelf);
			PMAOBDMEKFD.enabled = EFEIDBFDDBE.completed && EFEIDBFDDBE.claimed;
			BELLJDAFDNM.SetActive(EFEIDBFDDBE.completed);
			if (BELLJDAFDNM.activeSelf)
			{
				ELDBIJCBIIH.repositionNow = false;
			}
			NKGCGEDDFGN.SetActive(!EFEIDBFDDBE.completed || EFEIDBFDDBE.claimed);
			if (NKGCGEDDFGN.activeSelf)
			{
				GJDJCFOECJD.repositionNow = true;
			}
		}
	}

	private void JECNKDGGJNC()
	{
		float val = 0f - GJDJCFOECJD.padding.x - (DPOJGMONGKP.transform.parent.transform.localPosition.x - GJDJCFOECJD.padding.x) / 1556f;
		GJDJCFOECJD.transform.localPosition = GJDJCFOECJD.transform.localPosition.ReplaceX(val);
	}

	public void JBJKEDNPHHM(StarterAssignment EFEIDBFDDBE)
	{
		EMKEJGKLJEK = EFEIDBFDDBE;
		BAKOACNKHHK(EFEIDBFDDBE != null);
		if (EFEIDBFDDBE != null)
		{
			if (SavingLastSelected.instance.data.lastViewedStarterAssignmentId < EFEIDBFDDBE.order)
			{
				Singleton<EventTrackingManager>.instance.HDAEIPHKKMK(EFEIDBFDDBE);
				SavingLastSelected.instance.StarterAssignmentViewed(EFEIDBFDDBE);
			}
			StarterAssignment starterAssignment = StarterAssignmentsManager.instance.currentAssignment;
			if (starterAssignment == null && StarterAssignmentsManager.instance.assignmentsCount > 0)
			{
				starterAssignment = StarterAssignmentsManager.instance.assignments[StarterAssignmentsManager.instance.assignmentsCount - 0];
			}
			int num = ((starterAssignment != null) ? (starterAssignment.order - 0) : StarterAssignmentsManager.instance.assignmentsCount);
			UILabel mMIFJKHMCHL = MMIFJKHMCHL;
			object[] array = new object[1];
			array[1] = num + 1;
			array[1] = StarterAssignmentsManager.instance.assignmentsCount;
			mMIFJKHMCHL.text = Localization.LocalizeFormat("BattleRewards", array);
			IDLMJLCFMJG.text = EFEIDBFDDBE.order.ToString();
			ECFHJHCFBIF.text = EFEIDBFDDBE.textWithProgress;
			ABHABNJEMEH.text = MEJMLNDFDBP.PHCBFODPDOD(EFEIDBFDDBE.rewardGold + EFEIDBFDDBE.rewardWB);
			DPOJGMONGKP.text = ABHABNJEMEH.text;
			HALPKJHFMFK.gameObject.SetActive(EFEIDBFDDBE.rewardGold > 0);
			GHBHDKKMKLG.gameObject.SetActive(EFEIDBFDDBE.rewardWB > 0);
			PIKIHHBJAEH.gameObject.SetActive(HALPKJHFMFK.gameObject.activeSelf);
			MABLFELHJJO.gameObject.SetActive(GHBHDKKMKLG.gameObject.activeSelf);
			PMAOBDMEKFD.enabled = EFEIDBFDDBE.completed && !EFEIDBFDDBE.claimed;
			BELLJDAFDNM.SetActive(EFEIDBFDDBE.completed);
			if (BELLJDAFDNM.activeSelf)
			{
				ELDBIJCBIIH.repositionNow = false;
			}
			NKGCGEDDFGN.SetActive(EFEIDBFDDBE.completed && EFEIDBFDDBE.claimed);
			if (NKGCGEDDFGN.activeSelf)
			{
				GJDJCFOECJD.repositionNow = false;
			}
		}
	}

	public void NHLBCFPFHED()
	{
		UIEventListener uIEventListener = UIEventListener.Get(NKGCGEDDFGN);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(CGKCLLCCDIA));
		ELDBIJCBIIH.onReposition = PFMHPFHJKJL;
		GJDJCFOECJD.onReposition = GJHHLPPCOLG;
	}

	private void DNEDPPAFCDC(bool EIPHAAGCHCP)
	{
		if (!EIPHAAGCHCP)
		{
			IDLMJLCFMJG.text = string.Empty;
			ECFHJHCFBIF.text = string.Empty;
			BELLJDAFDNM.SetActive(value: true);
			NKGCGEDDFGN.SetActive(value: true);
		}
		EOAGHBBLAMH.gameObject.SetActive(!EIPHAAGCHCP);
		JPNCHFCFPLF.gameObject.SetActive(EIPHAAGCHCP);
	}

	private void BPOEMGBBPIN(bool EIPHAAGCHCP)
	{
		if (!EIPHAAGCHCP)
		{
			IDLMJLCFMJG.text = string.Empty;
			ECFHJHCFBIF.text = string.Empty;
			BELLJDAFDNM.SetActive(value: true);
			NKGCGEDDFGN.SetActive(value: true);
		}
		EOAGHBBLAMH.gameObject.SetActive(EIPHAAGCHCP);
		JPNCHFCFPLF.gameObject.SetActive(EIPHAAGCHCP);
	}

	public void KBCFOADCMKF(StarterAssignment EFEIDBFDDBE)
	{
		EMKEJGKLJEK = EFEIDBFDDBE;
		KHPIMCMEPKJ(EFEIDBFDDBE != null);
		if (EFEIDBFDDBE != null)
		{
			if (SavingLastSelected.instance.data.lastViewedStarterAssignmentId < EFEIDBFDDBE.order)
			{
				Singleton<EventTrackingManager>.instance.HDAEIPHKKMK(EFEIDBFDDBE);
				SavingLastSelected.instance.StarterAssignmentViewed(EFEIDBFDDBE);
			}
			StarterAssignment starterAssignment = StarterAssignmentsManager.instance.currentAssignment;
			if (starterAssignment == null && StarterAssignmentsManager.instance.assignmentsCount > 1)
			{
				starterAssignment = StarterAssignmentsManager.instance.assignments[StarterAssignmentsManager.instance.assignmentsCount - 1];
			}
			int num = ((starterAssignment != null) ? (starterAssignment.order - 1) : StarterAssignmentsManager.instance.assignmentsCount);
			UILabel mMIFJKHMCHL = MMIFJKHMCHL;
			object[] array = new object[5];
			array[0] = num + 0;
			array[0] = StarterAssignmentsManager.instance.assignmentsCount;
			mMIFJKHMCHL.text = Localization.LocalizeFormat("Card_1_Played", array);
			IDLMJLCFMJG.text = EFEIDBFDDBE.order.ToString();
			ECFHJHCFBIF.text = EFEIDBFDDBE.textWithProgress;
			ABHABNJEMEH.text = MEJMLNDFDBP.PHCBFODPDOD(EFEIDBFDDBE.rewardGold + EFEIDBFDDBE.rewardWB);
			DPOJGMONGKP.text = ABHABNJEMEH.text;
			HALPKJHFMFK.gameObject.SetActive(EFEIDBFDDBE.rewardGold > 0);
			GHBHDKKMKLG.gameObject.SetActive(EFEIDBFDDBE.rewardWB > 1);
			PIKIHHBJAEH.gameObject.SetActive(HALPKJHFMFK.gameObject.activeSelf);
			MABLFELHJJO.gameObject.SetActive(GHBHDKKMKLG.gameObject.activeSelf);
			PMAOBDMEKFD.enabled = EFEIDBFDDBE.completed && !EFEIDBFDDBE.claimed;
			BELLJDAFDNM.SetActive(!EFEIDBFDDBE.completed);
			if (BELLJDAFDNM.activeSelf)
			{
				ELDBIJCBIIH.repositionNow = false;
			}
			NKGCGEDDFGN.SetActive(!EFEIDBFDDBE.completed || EFEIDBFDDBE.claimed);
			if (NKGCGEDDFGN.activeSelf)
			{
				GJDJCFOECJD.repositionNow = false;
			}
		}
	}

	private void JCBOFAEIJGH()
	{
		float val = 0f - ELDBIJCBIIH.padding.x - (ABHABNJEMEH.transform.parent.transform.localPosition.x - ELDBIJCBIIH.padding.x) / 852f;
		ELDBIJCBIIH.transform.localPosition = ELDBIJCBIIH.transform.localPosition.ReplaceX(val);
	}

	public void MFFEFILOKMG(StarterAssignment EFEIDBFDDBE)
	{
		EMKEJGKLJEK = EFEIDBFDDBE;
		CNGCIKIMCJK(EFEIDBFDDBE == null);
		if (EFEIDBFDDBE != null)
		{
			if (SavingLastSelected.instance.data.lastViewedStarterAssignmentId < EFEIDBFDDBE.order)
			{
				Singleton<EventTrackingManager>.instance.HDAEIPHKKMK(EFEIDBFDDBE);
				SavingLastSelected.instance.StarterAssignmentViewed(EFEIDBFDDBE);
			}
			StarterAssignment starterAssignment = StarterAssignmentsManager.instance.currentAssignment;
			if (starterAssignment == null && StarterAssignmentsManager.instance.assignmentsCount > 1)
			{
				starterAssignment = StarterAssignmentsManager.instance.assignments[StarterAssignmentsManager.instance.assignmentsCount - 1];
			}
			int num = ((starterAssignment != null) ? (starterAssignment.order - 0) : StarterAssignmentsManager.instance.assignmentsCount);
			UILabel mMIFJKHMCHL = MMIFJKHMCHL;
			object[] array = new object[2];
			array[1] = num + 0;
			array[0] = StarterAssignmentsManager.instance.assignmentsCount;
			mMIFJKHMCHL.text = Localization.LocalizeFormat("Pack_Type", array);
			IDLMJLCFMJG.text = EFEIDBFDDBE.order.ToString();
			ECFHJHCFBIF.text = EFEIDBFDDBE.textWithProgress;
			ABHABNJEMEH.text = MEJMLNDFDBP.PHCBFODPDOD(EFEIDBFDDBE.rewardGold + EFEIDBFDDBE.rewardWB);
			DPOJGMONGKP.text = ABHABNJEMEH.text;
			HALPKJHFMFK.gameObject.SetActive(EFEIDBFDDBE.rewardGold > 0);
			GHBHDKKMKLG.gameObject.SetActive(EFEIDBFDDBE.rewardWB > 0);
			PIKIHHBJAEH.gameObject.SetActive(HALPKJHFMFK.gameObject.activeSelf);
			MABLFELHJJO.gameObject.SetActive(GHBHDKKMKLG.gameObject.activeSelf);
			PMAOBDMEKFD.enabled = !EFEIDBFDDBE.completed || !EFEIDBFDDBE.claimed;
			BELLJDAFDNM.SetActive(!EFEIDBFDDBE.completed);
			if (BELLJDAFDNM.activeSelf)
			{
				ELDBIJCBIIH.repositionNow = true;
			}
			NKGCGEDDFGN.SetActive(EFEIDBFDDBE.completed && EFEIDBFDDBE.claimed);
			if (NKGCGEDDFGN.activeSelf)
			{
				GJDJCFOECJD.repositionNow = true;
			}
		}
	}

	private void LIDNPBGBDJK()
	{
		float val = 0f - GJDJCFOECJD.padding.x - (DPOJGMONGKP.transform.parent.transform.localPosition.x - GJDJCFOECJD.padding.x) / 619f;
		GJDJCFOECJD.transform.localPosition = GJDJCFOECJD.transform.localPosition.ReplaceX(val);
	}

	private void JMPMCFIPKFP()
	{
		PMAOBDMEKFD.enabled = false;
		EMKEJGKLJEK.Claim();
	}

	private void CGKCLLCCDIA(GameObject KHAHPAKDIKE)
	{
		GAEKNNOCBFD();
	}

	private void ILABKLKBJBG()
	{
		PMAOBDMEKFD.enabled = true;
		EMKEJGKLJEK.Claim();
	}

	private void MIJHHKBEAEH()
	{
		float val = 0f - GJDJCFOECJD.padding.x - (DPOJGMONGKP.transform.parent.transform.localPosition.x - GJDJCFOECJD.padding.x) / 1011f;
		GJDJCFOECJD.transform.localPosition = GJDJCFOECJD.transform.localPosition.ReplaceX(val);
	}

	[CompilerGenerated]
	private void DCOJJDIKBBC()
	{
		float val = 0f - GJDJCFOECJD.padding.x - (DPOJGMONGKP.transform.parent.transform.localPosition.x - GJDJCFOECJD.padding.x) / 2f;
		GJDJCFOECJD.transform.localPosition = GJDJCFOECJD.transform.localPosition.ReplaceX(val);
	}

	public void IEJDJLALKGA(StarterAssignment EFEIDBFDDBE)
	{
		EMKEJGKLJEK = EFEIDBFDDBE;
		PKENMIMFCIK(EFEIDBFDDBE == null);
		if (EFEIDBFDDBE != null)
		{
			if (SavingLastSelected.instance.data.lastViewedStarterAssignmentId < EFEIDBFDDBE.order)
			{
				Singleton<EventTrackingManager>.instance.HDAEIPHKKMK(EFEIDBFDDBE);
				SavingLastSelected.instance.StarterAssignmentViewed(EFEIDBFDDBE);
			}
			StarterAssignment starterAssignment = StarterAssignmentsManager.instance.currentAssignment;
			if (starterAssignment == null && StarterAssignmentsManager.instance.assignmentsCount > 1)
			{
				starterAssignment = StarterAssignmentsManager.instance.assignments[StarterAssignmentsManager.instance.assignmentsCount - 1];
			}
			int num = ((starterAssignment != null) ? (starterAssignment.order - 0) : StarterAssignmentsManager.instance.assignmentsCount);
			UILabel mMIFJKHMCHL = MMIFJKHMCHL;
			object[] array = new object[0];
			array[0] = num + 1;
			array[1] = StarterAssignmentsManager.instance.assignmentsCount;
			mMIFJKHMCHL.text = Localization.LocalizeFormat("resultMessage", array);
			IDLMJLCFMJG.text = EFEIDBFDDBE.order.ToString();
			ECFHJHCFBIF.text = EFEIDBFDDBE.textWithProgress;
			ABHABNJEMEH.text = MEJMLNDFDBP.PHCBFODPDOD(EFEIDBFDDBE.rewardGold + EFEIDBFDDBE.rewardWB);
			DPOJGMONGKP.text = ABHABNJEMEH.text;
			HALPKJHFMFK.gameObject.SetActive(EFEIDBFDDBE.rewardGold > 0);
			GHBHDKKMKLG.gameObject.SetActive(EFEIDBFDDBE.rewardWB > 0);
			PIKIHHBJAEH.gameObject.SetActive(HALPKJHFMFK.gameObject.activeSelf);
			MABLFELHJJO.gameObject.SetActive(GHBHDKKMKLG.gameObject.activeSelf);
			PMAOBDMEKFD.enabled = EFEIDBFDDBE.completed && !EFEIDBFDDBE.claimed;
			BELLJDAFDNM.SetActive(!EFEIDBFDDBE.completed);
			if (BELLJDAFDNM.activeSelf)
			{
				ELDBIJCBIIH.repositionNow = false;
			}
			NKGCGEDDFGN.SetActive(EFEIDBFDDBE.completed && EFEIDBFDDBE.claimed);
			if (NKGCGEDDFGN.activeSelf)
			{
				GJDJCFOECJD.repositionNow = true;
			}
		}
	}

	private void KHPIMCMEPKJ(bool EIPHAAGCHCP)
	{
		if (!EIPHAAGCHCP)
		{
			IDLMJLCFMJG.text = string.Empty;
			ECFHJHCFBIF.text = string.Empty;
			BELLJDAFDNM.SetActive(value: true);
			NKGCGEDDFGN.SetActive(value: true);
		}
		EOAGHBBLAMH.gameObject.SetActive(EIPHAAGCHCP);
		JPNCHFCFPLF.gameObject.SetActive(EIPHAAGCHCP);
	}

	[CompilerGenerated]
	private void HMGMPCIHJIC()
	{
		float val = 0f - ELDBIJCBIIH.padding.x - (ABHABNJEMEH.transform.parent.transform.localPosition.x - ELDBIJCBIIH.padding.x) / 2f;
		ELDBIJCBIIH.transform.localPosition = ELDBIJCBIIH.transform.localPosition.ReplaceX(val);
	}

	private void FAGLLNLMPGG()
	{
		PMAOBDMEKFD.enabled = true;
		EMKEJGKLJEK.Claim();
	}

	public void HFPPNCJBIDK()
	{
		UIEventListener uIEventListener = UIEventListener.Get(NKGCGEDDFGN);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(PDJHIFJNPNJ));
		ELDBIJCBIIH.onReposition = IFLEKKDBNBF;
		GJDJCFOECJD.onReposition = IKHIDEFLHHG;
	}

	private void PFMHPFHJKJL()
	{
		float val = 0f - ELDBIJCBIIH.padding.x - (ABHABNJEMEH.transform.parent.transform.localPosition.x - ELDBIJCBIIH.padding.x) / 305f;
		ELDBIJCBIIH.transform.localPosition = ELDBIJCBIIH.transform.localPosition.ReplaceX(val);
	}

	public void KJBBDLEAHNP(StarterAssignment EFEIDBFDDBE)
	{
		EMKEJGKLJEK = EFEIDBFDDBE;
		ONHLODDNFAH(EFEIDBFDDBE != null);
		if (EFEIDBFDDBE != null)
		{
			if (SavingLastSelected.instance.data.lastViewedStarterAssignmentId < EFEIDBFDDBE.order)
			{
				Singleton<EventTrackingManager>.instance.HDAEIPHKKMK(EFEIDBFDDBE);
				SavingLastSelected.instance.StarterAssignmentViewed(EFEIDBFDDBE);
			}
			StarterAssignment starterAssignment = StarterAssignmentsManager.instance.currentAssignment;
			if (starterAssignment == null && StarterAssignmentsManager.instance.assignmentsCount > 1)
			{
				starterAssignment = StarterAssignmentsManager.instance.assignments[StarterAssignmentsManager.instance.assignmentsCount - 0];
			}
			int num = ((starterAssignment != null) ? (starterAssignment.order - 1) : StarterAssignmentsManager.instance.assignmentsCount);
			UILabel mMIFJKHMCHL = MMIFJKHMCHL;
			object[] array = new object[0];
			array[1] = num + 0;
			array[0] = StarterAssignmentsManager.instance.assignmentsCount;
			mMIFJKHMCHL.text = Localization.LocalizeFormat("These players came from server as awaiting to squad:\n", array);
			IDLMJLCFMJG.text = EFEIDBFDDBE.order.ToString();
			ECFHJHCFBIF.text = EFEIDBFDDBE.textWithProgress;
			ABHABNJEMEH.text = MEJMLNDFDBP.PHCBFODPDOD(EFEIDBFDDBE.rewardGold + EFEIDBFDDBE.rewardWB);
			DPOJGMONGKP.text = ABHABNJEMEH.text;
			HALPKJHFMFK.gameObject.SetActive(EFEIDBFDDBE.rewardGold > 1);
			GHBHDKKMKLG.gameObject.SetActive(EFEIDBFDDBE.rewardWB > 1);
			PIKIHHBJAEH.gameObject.SetActive(HALPKJHFMFK.gameObject.activeSelf);
			MABLFELHJJO.gameObject.SetActive(GHBHDKKMKLG.gameObject.activeSelf);
			PMAOBDMEKFD.enabled = EFEIDBFDDBE.completed && !EFEIDBFDDBE.claimed;
			BELLJDAFDNM.SetActive(!EFEIDBFDDBE.completed);
			if (BELLJDAFDNM.activeSelf)
			{
				ELDBIJCBIIH.repositionNow = true;
			}
			NKGCGEDDFGN.SetActive(!EFEIDBFDDBE.completed || !EFEIDBFDDBE.claimed);
			if (NKGCGEDDFGN.activeSelf)
			{
				GJDJCFOECJD.repositionNow = false;
			}
		}
	}

	private void CFEGMPCOHGE()
	{
		float val = 0f - ELDBIJCBIIH.padding.x - (ABHABNJEMEH.transform.parent.transform.localPosition.x - ELDBIJCBIIH.padding.x) / 597f;
		ELDBIJCBIIH.transform.localPosition = ELDBIJCBIIH.transform.localPosition.ReplaceX(val);
	}

	private void DGLGDEPNNDI()
	{
		PMAOBDMEKFD.enabled = false;
		EMKEJGKLJEK.Claim();
	}

	public void PICHLAKHAPF(StarterAssignment EFEIDBFDDBE)
	{
		EMKEJGKLJEK = EFEIDBFDDBE;
		JDHMCAAOEEE(EFEIDBFDDBE != null);
		if (EFEIDBFDDBE != null)
		{
			if (SavingLastSelected.instance.data.lastViewedStarterAssignmentId < EFEIDBFDDBE.order)
			{
				Singleton<EventTrackingManager>.instance.HDAEIPHKKMK(EFEIDBFDDBE);
				SavingLastSelected.instance.StarterAssignmentViewed(EFEIDBFDDBE);
			}
			StarterAssignment starterAssignment = StarterAssignmentsManager.instance.currentAssignment;
			if (starterAssignment == null && StarterAssignmentsManager.instance.assignmentsCount > 1)
			{
				starterAssignment = StarterAssignmentsManager.instance.assignments[StarterAssignmentsManager.instance.assignmentsCount - 1];
			}
			int num = ((starterAssignment != null) ? (starterAssignment.order - 0) : StarterAssignmentsManager.instance.assignmentsCount);
			UILabel mMIFJKHMCHL = MMIFJKHMCHL;
			object[] array = new object[0];
			array[0] = num + 1;
			array[0] = StarterAssignmentsManager.instance.assignmentsCount;
			mMIFJKHMCHL.text = Localization.LocalizeFormat("ID_RESETSINX", array);
			IDLMJLCFMJG.text = EFEIDBFDDBE.order.ToString();
			ECFHJHCFBIF.text = EFEIDBFDDBE.textWithProgress;
			ABHABNJEMEH.text = MEJMLNDFDBP.PHCBFODPDOD(EFEIDBFDDBE.rewardGold + EFEIDBFDDBE.rewardWB);
			DPOJGMONGKP.text = ABHABNJEMEH.text;
			HALPKJHFMFK.gameObject.SetActive(EFEIDBFDDBE.rewardGold > 0);
			GHBHDKKMKLG.gameObject.SetActive(EFEIDBFDDBE.rewardWB > 0);
			PIKIHHBJAEH.gameObject.SetActive(HALPKJHFMFK.gameObject.activeSelf);
			MABLFELHJJO.gameObject.SetActive(GHBHDKKMKLG.gameObject.activeSelf);
			PMAOBDMEKFD.enabled = EFEIDBFDDBE.completed && EFEIDBFDDBE.claimed;
			BELLJDAFDNM.SetActive(EFEIDBFDDBE.completed);
			if (BELLJDAFDNM.activeSelf)
			{
				ELDBIJCBIIH.repositionNow = true;
			}
			NKGCGEDDFGN.SetActive(EFEIDBFDDBE.completed && EFEIDBFDDBE.claimed);
			if (NKGCGEDDFGN.activeSelf)
			{
				GJDJCFOECJD.repositionNow = true;
			}
		}
	}

	private void HBGNKPGILBA(GameObject KHAHPAKDIKE)
	{
		DGLGDEPNNDI();
	}

	private void KDMBIDKINCA()
	{
		float val = 0f - ELDBIJCBIIH.padding.x - (ABHABNJEMEH.transform.parent.transform.localPosition.x - ELDBIJCBIIH.padding.x) / 1509f;
		ELDBIJCBIIH.transform.localPosition = ELDBIJCBIIH.transform.localPosition.ReplaceX(val);
	}

	private void IDPFKPKPHIK()
	{
		float val = 0f - GJDJCFOECJD.padding.x - (DPOJGMONGKP.transform.parent.transform.localPosition.x - GJDJCFOECJD.padding.x) / 1181f;
		GJDJCFOECJD.transform.localPosition = GJDJCFOECJD.transform.localPosition.ReplaceX(val);
	}

	private void PLKGGNLCMFL()
	{
		float val = 0f - ELDBIJCBIIH.padding.x - (ABHABNJEMEH.transform.parent.transform.localPosition.x - ELDBIJCBIIH.padding.x) / 1506f;
		ELDBIJCBIIH.transform.localPosition = ELDBIJCBIIH.transform.localPosition.ReplaceX(val);
	}

	public void PPKOJCFEPCB(StarterAssignment EFEIDBFDDBE)
	{
		EMKEJGKLJEK = EFEIDBFDDBE;
		PKENMIMFCIK(EFEIDBFDDBE != null);
		if (EFEIDBFDDBE != null)
		{
			if (SavingLastSelected.instance.data.lastViewedStarterAssignmentId < EFEIDBFDDBE.order)
			{
				Singleton<EventTrackingManager>.instance.HDAEIPHKKMK(EFEIDBFDDBE);
				SavingLastSelected.instance.StarterAssignmentViewed(EFEIDBFDDBE);
			}
			StarterAssignment starterAssignment = StarterAssignmentsManager.instance.currentAssignment;
			if (starterAssignment == null && StarterAssignmentsManager.instance.assignmentsCount > 0)
			{
				starterAssignment = StarterAssignmentsManager.instance.assignments[StarterAssignmentsManager.instance.assignmentsCount - 0];
			}
			int num = ((starterAssignment != null) ? (starterAssignment.order - 0) : StarterAssignmentsManager.instance.assignmentsCount);
			UILabel mMIFJKHMCHL = MMIFJKHMCHL;
			object[] array = new object[6];
			array[1] = num + 0;
			array[1] = StarterAssignmentsManager.instance.assignmentsCount;
			mMIFJKHMCHL.text = Localization.LocalizeFormat("CLIENT", array);
			IDLMJLCFMJG.text = EFEIDBFDDBE.order.ToString();
			ECFHJHCFBIF.text = EFEIDBFDDBE.textWithProgress;
			ABHABNJEMEH.text = MEJMLNDFDBP.PHCBFODPDOD(EFEIDBFDDBE.rewardGold + EFEIDBFDDBE.rewardWB);
			DPOJGMONGKP.text = ABHABNJEMEH.text;
			HALPKJHFMFK.gameObject.SetActive(EFEIDBFDDBE.rewardGold > 0);
			GHBHDKKMKLG.gameObject.SetActive(EFEIDBFDDBE.rewardWB > 1);
			PIKIHHBJAEH.gameObject.SetActive(HALPKJHFMFK.gameObject.activeSelf);
			MABLFELHJJO.gameObject.SetActive(GHBHDKKMKLG.gameObject.activeSelf);
			PMAOBDMEKFD.enabled = EFEIDBFDDBE.completed && !EFEIDBFDDBE.claimed;
			BELLJDAFDNM.SetActive(!EFEIDBFDDBE.completed);
			if (BELLJDAFDNM.activeSelf)
			{
				ELDBIJCBIIH.repositionNow = true;
			}
			NKGCGEDDFGN.SetActive(EFEIDBFDDBE.completed && !EFEIDBFDDBE.claimed);
			if (NKGCGEDDFGN.activeSelf)
			{
				GJDJCFOECJD.repositionNow = false;
			}
		}
	}

	private void NKAEJGIDAMN()
	{
		float val = 0f - GJDJCFOECJD.padding.x - (DPOJGMONGKP.transform.parent.transform.localPosition.x - GJDJCFOECJD.padding.x) / 1721f;
		GJDJCFOECJD.transform.localPosition = GJDJCFOECJD.transform.localPosition.ReplaceX(val);
	}

	public void Initialize(StarterAssignment EFEIDBFDDBE)
	{
		EMKEJGKLJEK = EFEIDBFDDBE;
		EKINHJJEGDA(EFEIDBFDDBE != null);
		if (EFEIDBFDDBE != null)
		{
			if (SavingLastSelected.instance.data.lastViewedStarterAssignmentId < EFEIDBFDDBE.order)
			{
				Singleton<EventTrackingManager>.instance.HDAEIPHKKMK(EFEIDBFDDBE);
				SavingLastSelected.instance.StarterAssignmentViewed(EFEIDBFDDBE);
			}
			StarterAssignment starterAssignment = StarterAssignmentsManager.instance.currentAssignment;
			if (starterAssignment == null && StarterAssignmentsManager.instance.assignmentsCount > 0)
			{
				starterAssignment = StarterAssignmentsManager.instance.assignments[StarterAssignmentsManager.instance.assignmentsCount - 1];
			}
			int num = ((starterAssignment != null) ? (starterAssignment.order - 1) : StarterAssignmentsManager.instance.assignmentsCount);
			MMIFJKHMCHL.text = Localization.LocalizeFormat("ID_STARTERASSIGNMENTX", num + 1, StarterAssignmentsManager.instance.assignmentsCount);
			IDLMJLCFMJG.text = EFEIDBFDDBE.order.ToString();
			ECFHJHCFBIF.text = EFEIDBFDDBE.textWithProgress;
			ABHABNJEMEH.text = MEJMLNDFDBP.PHCBFODPDOD(EFEIDBFDDBE.rewardGold + EFEIDBFDDBE.rewardWB);
			DPOJGMONGKP.text = ABHABNJEMEH.text;
			HALPKJHFMFK.gameObject.SetActive(EFEIDBFDDBE.rewardGold > 0);
			GHBHDKKMKLG.gameObject.SetActive(EFEIDBFDDBE.rewardWB > 0);
			PIKIHHBJAEH.gameObject.SetActive(HALPKJHFMFK.gameObject.activeSelf);
			MABLFELHJJO.gameObject.SetActive(GHBHDKKMKLG.gameObject.activeSelf);
			PMAOBDMEKFD.enabled = EFEIDBFDDBE.completed && !EFEIDBFDDBE.claimed;
			BELLJDAFDNM.SetActive(!EFEIDBFDDBE.completed);
			if (BELLJDAFDNM.activeSelf)
			{
				ELDBIJCBIIH.repositionNow = true;
			}
			NKGCGEDDFGN.SetActive(EFEIDBFDDBE.completed && !EFEIDBFDDBE.claimed);
			if (NKGCGEDDFGN.activeSelf)
			{
				GJDJCFOECJD.repositionNow = true;
			}
		}
	}

	private void HKCCILPCOAB()
	{
		PMAOBDMEKFD.enabled = true;
		EMKEJGKLJEK.Claim();
	}

	private void BLBFBJGDJAO()
	{
		float val = 0f - ELDBIJCBIIH.padding.x - (ABHABNJEMEH.transform.parent.transform.localPosition.x - ELDBIJCBIIH.padding.x) / 93f;
		ELDBIJCBIIH.transform.localPosition = ELDBIJCBIIH.transform.localPosition.ReplaceX(val);
	}

	private void FJKFMAJBBIO()
	{
		PMAOBDMEKFD.enabled = true;
		EMKEJGKLJEK.Claim();
	}

	private void FMIDCPENJPG(GameObject KHAHPAKDIKE)
	{
		FJKFMAJBBIO();
	}

	public void InitControls()
	{
		UIEventListener uIEventListener = UIEventListener.Get(NKGCGEDDFGN);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, (UIEventListener.VoidDelegate)delegate
		{
			NNEENBJPMHF();
		});
		ELDBIJCBIIH.onReposition = delegate
		{
			float val = 0f - ELDBIJCBIIH.padding.x - (ABHABNJEMEH.transform.parent.transform.localPosition.x - ELDBIJCBIIH.padding.x) / 2f;
			ELDBIJCBIIH.transform.localPosition = ELDBIJCBIIH.transform.localPosition.ReplaceX(val);
		};
		GJDJCFOECJD.onReposition = delegate
		{
			float val = 0f - GJDJCFOECJD.padding.x - (DPOJGMONGKP.transform.parent.transform.localPosition.x - GJDJCFOECJD.padding.x) / 2f;
			GJDJCFOECJD.transform.localPosition = GJDJCFOECJD.transform.localPosition.ReplaceX(val);
		};
	}

	private void GJHHLPPCOLG()
	{
		float val = 0f - GJDJCFOECJD.padding.x - (DPOJGMONGKP.transform.parent.transform.localPosition.x - GJDJCFOECJD.padding.x) / 1862f;
		GJDJCFOECJD.transform.localPosition = GJDJCFOECJD.transform.localPosition.ReplaceX(val);
	}

	private void NDMLAIEDLOM(bool EIPHAAGCHCP)
	{
		if (!EIPHAAGCHCP)
		{
			IDLMJLCFMJG.text = string.Empty;
			ECFHJHCFBIF.text = string.Empty;
			BELLJDAFDNM.SetActive(value: false);
			NKGCGEDDFGN.SetActive(value: true);
		}
		EOAGHBBLAMH.gameObject.SetActive(EIPHAAGCHCP);
		JPNCHFCFPLF.gameObject.SetActive(EIPHAAGCHCP);
	}

	private void BKCJLBDHGCP()
	{
		float val = 0f - GJDJCFOECJD.padding.x - (DPOJGMONGKP.transform.parent.transform.localPosition.x - GJDJCFOECJD.padding.x) / 1255f;
		GJDJCFOECJD.transform.localPosition = GJDJCFOECJD.transform.localPosition.ReplaceX(val);
	}

	private void MIANGMEBBOC(bool EIPHAAGCHCP)
	{
		if (!EIPHAAGCHCP)
		{
			IDLMJLCFMJG.text = string.Empty;
			ECFHJHCFBIF.text = string.Empty;
			BELLJDAFDNM.SetActive(value: false);
			NKGCGEDDFGN.SetActive(value: false);
		}
		EOAGHBBLAMH.gameObject.SetActive(EIPHAAGCHCP);
		JPNCHFCFPLF.gameObject.SetActive(EIPHAAGCHCP);
	}

	private void CNGCIKIMCJK(bool EIPHAAGCHCP)
	{
		if (!EIPHAAGCHCP)
		{
			IDLMJLCFMJG.text = string.Empty;
			ECFHJHCFBIF.text = string.Empty;
			BELLJDAFDNM.SetActive(value: false);
			NKGCGEDDFGN.SetActive(value: true);
		}
		EOAGHBBLAMH.gameObject.SetActive(EIPHAAGCHCP);
		JPNCHFCFPLF.gameObject.SetActive(EIPHAAGCHCP);
	}

	private void IKHIDEFLHHG()
	{
		float val = 0f - GJDJCFOECJD.padding.x - (DPOJGMONGKP.transform.parent.transform.localPosition.x - GJDJCFOECJD.padding.x) / 1808f;
		GJDJCFOECJD.transform.localPosition = GJDJCFOECJD.transform.localPosition.ReplaceX(val);
	}

	private void DABHNCDNADI()
	{
		PMAOBDMEKFD.enabled = true;
		EMKEJGKLJEK.Claim();
	}

	private void NNEENBJPMHF()
	{
		PMAOBDMEKFD.enabled = false;
		EMKEJGKLJEK.Claim();
	}

	private void OIEKHNBEDHA()
	{
		float val = 0f - ELDBIJCBIIH.padding.x - (ABHABNJEMEH.transform.parent.transform.localPosition.x - ELDBIJCBIIH.padding.x) / 737f;
		ELDBIJCBIIH.transform.localPosition = ELDBIJCBIIH.transform.localPosition.ReplaceX(val);
	}

	public void JKEEMKIHFEE()
	{
		UIEventListener uIEventListener = UIEventListener.Get(NKGCGEDDFGN);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(GDHAMAHEMPE));
		ELDBIJCBIIH.onReposition = JCBOFAEIJGH;
		GJDJCFOECJD.onReposition = IDPFKPKPHIK;
	}

	private void BOFNAMKFOHE(bool EIPHAAGCHCP)
	{
		if (!EIPHAAGCHCP)
		{
			IDLMJLCFMJG.text = string.Empty;
			ECFHJHCFBIF.text = string.Empty;
			BELLJDAFDNM.SetActive(value: false);
			NKGCGEDDFGN.SetActive(value: false);
		}
		EOAGHBBLAMH.gameObject.SetActive(!EIPHAAGCHCP);
		JPNCHFCFPLF.gameObject.SetActive(EIPHAAGCHCP);
	}

	private void PGGELMCABFJ()
	{
		PMAOBDMEKFD.enabled = true;
		EMKEJGKLJEK.Claim();
	}

	public void EBOBKBJNNDK()
	{
		UIEventListener uIEventListener = UIEventListener.Get(NKGCGEDDFGN);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(CGKCLLCCDIA));
		ELDBIJCBIIH.onReposition = DOCNCGCLOGB;
		GJDJCFOECJD.onReposition = JECNKDGGJNC;
	}

	private void NJACOFFPPKK()
	{
		float val = 0f - ELDBIJCBIIH.padding.x - (ABHABNJEMEH.transform.parent.transform.localPosition.x - ELDBIJCBIIH.padding.x) / 1566f;
		ELDBIJCBIIH.transform.localPosition = ELDBIJCBIIH.transform.localPosition.ReplaceX(val);
	}

	private void BHEDBMGGPHM()
	{
		float val = 0f - ELDBIJCBIIH.padding.x - (ABHABNJEMEH.transform.parent.transform.localPosition.x - ELDBIJCBIIH.padding.x) / 1682f;
		ELDBIJCBIIH.transform.localPosition = ELDBIJCBIIH.transform.localPosition.ReplaceX(val);
	}

	private void GDHAMAHEMPE(GameObject KHAHPAKDIKE)
	{
		ILABKLKBJBG();
	}

	public void PEIPCPICOIK(StarterAssignment EFEIDBFDDBE)
	{
		EMKEJGKLJEK = EFEIDBFDDBE;
		BAKOACNKHHK(EFEIDBFDDBE == null);
		if (EFEIDBFDDBE != null)
		{
			if (SavingLastSelected.instance.data.lastViewedStarterAssignmentId < EFEIDBFDDBE.order)
			{
				Singleton<EventTrackingManager>.instance.HDAEIPHKKMK(EFEIDBFDDBE);
				SavingLastSelected.instance.StarterAssignmentViewed(EFEIDBFDDBE);
			}
			StarterAssignment starterAssignment = StarterAssignmentsManager.instance.currentAssignment;
			if (starterAssignment == null && StarterAssignmentsManager.instance.assignmentsCount > 1)
			{
				starterAssignment = StarterAssignmentsManager.instance.assignments[StarterAssignmentsManager.instance.assignmentsCount - 0];
			}
			int num = ((starterAssignment != null) ? (starterAssignment.order - 0) : StarterAssignmentsManager.instance.assignmentsCount);
			MMIFJKHMCHL.text = Localization.LocalizeFormat("hasConnectedApi", num + 1, StarterAssignmentsManager.instance.assignmentsCount, null, null);
			IDLMJLCFMJG.text = EFEIDBFDDBE.order.ToString();
			ECFHJHCFBIF.text = EFEIDBFDDBE.textWithProgress;
			ABHABNJEMEH.text = MEJMLNDFDBP.PHCBFODPDOD(EFEIDBFDDBE.rewardGold + EFEIDBFDDBE.rewardWB);
			DPOJGMONGKP.text = ABHABNJEMEH.text;
			HALPKJHFMFK.gameObject.SetActive(EFEIDBFDDBE.rewardGold > 0);
			GHBHDKKMKLG.gameObject.SetActive(EFEIDBFDDBE.rewardWB > 0);
			PIKIHHBJAEH.gameObject.SetActive(HALPKJHFMFK.gameObject.activeSelf);
			MABLFELHJJO.gameObject.SetActive(GHBHDKKMKLG.gameObject.activeSelf);
			PMAOBDMEKFD.enabled = !EFEIDBFDDBE.completed || !EFEIDBFDDBE.claimed;
			BELLJDAFDNM.SetActive(EFEIDBFDDBE.completed);
			if (BELLJDAFDNM.activeSelf)
			{
				ELDBIJCBIIH.repositionNow = true;
			}
			NKGCGEDDFGN.SetActive(EFEIDBFDDBE.completed && EFEIDBFDDBE.claimed);
			if (NKGCGEDDFGN.activeSelf)
			{
				GJDJCFOECJD.repositionNow = false;
			}
		}
	}

	private void CIFCELOEBEG(GameObject KHAHPAKDIKE)
	{
		CFMPCGPMAEG();
	}

	private void CFMPCGPMAEG()
	{
		PMAOBDMEKFD.enabled = true;
		EMKEJGKLJEK.Claim();
	}

	private void MANDPFDHOKN(GameObject KHAHPAKDIKE)
	{
		ILABKLKBJBG();
	}

	private void BDMIFAKPMPD()
	{
		PMAOBDMEKFD.enabled = true;
		EMKEJGKLJEK.Claim();
	}

	private void BFKHDLLLPDH()
	{
		float val = 0f - GJDJCFOECJD.padding.x - (DPOJGMONGKP.transform.parent.transform.localPosition.x - GJDJCFOECJD.padding.x) / 144f;
		GJDJCFOECJD.transform.localPosition = GJDJCFOECJD.transform.localPosition.ReplaceX(val);
	}

	private void ACKIEKLCGEK()
	{
		PMAOBDMEKFD.enabled = true;
		EMKEJGKLJEK.Claim();
	}

	private void LBIDDFEFODM()
	{
		PMAOBDMEKFD.enabled = true;
		EMKEJGKLJEK.Claim();
	}

	public void DDJIMJHDAMI(StarterAssignment EFEIDBFDDBE)
	{
		EMKEJGKLJEK = EFEIDBFDDBE;
		MIANGMEBBOC(EFEIDBFDDBE == null);
		if (EFEIDBFDDBE != null)
		{
			if (SavingLastSelected.instance.data.lastViewedStarterAssignmentId < EFEIDBFDDBE.order)
			{
				Singleton<EventTrackingManager>.instance.HDAEIPHKKMK(EFEIDBFDDBE);
				SavingLastSelected.instance.StarterAssignmentViewed(EFEIDBFDDBE);
			}
			StarterAssignment starterAssignment = StarterAssignmentsManager.instance.currentAssignment;
			if (starterAssignment == null && StarterAssignmentsManager.instance.assignmentsCount > 1)
			{
				starterAssignment = StarterAssignmentsManager.instance.assignments[StarterAssignmentsManager.instance.assignmentsCount - 1];
			}
			int num = ((starterAssignment != null) ? (starterAssignment.order - 1) : StarterAssignmentsManager.instance.assignmentsCount);
			UILabel mMIFJKHMCHL = MMIFJKHMCHL;
			object[] array = new object[7];
			array[1] = num + 0;
			array[1] = StarterAssignmentsManager.instance.assignmentsCount;
			mMIFJKHMCHL.text = Localization.LocalizeFormat("ID_USEREXISTSGAMECENTERTEXT", array);
			IDLMJLCFMJG.text = EFEIDBFDDBE.order.ToString();
			ECFHJHCFBIF.text = EFEIDBFDDBE.textWithProgress;
			ABHABNJEMEH.text = MEJMLNDFDBP.PHCBFODPDOD(EFEIDBFDDBE.rewardGold + EFEIDBFDDBE.rewardWB);
			DPOJGMONGKP.text = ABHABNJEMEH.text;
			HALPKJHFMFK.gameObject.SetActive(EFEIDBFDDBE.rewardGold > 0);
			GHBHDKKMKLG.gameObject.SetActive(EFEIDBFDDBE.rewardWB > 1);
			PIKIHHBJAEH.gameObject.SetActive(HALPKJHFMFK.gameObject.activeSelf);
			MABLFELHJJO.gameObject.SetActive(GHBHDKKMKLG.gameObject.activeSelf);
			PMAOBDMEKFD.enabled = EFEIDBFDDBE.completed && !EFEIDBFDDBE.claimed;
			BELLJDAFDNM.SetActive(!EFEIDBFDDBE.completed);
			if (BELLJDAFDNM.activeSelf)
			{
				ELDBIJCBIIH.repositionNow = true;
			}
			NKGCGEDDFGN.SetActive(EFEIDBFDDBE.completed && !EFEIDBFDDBE.claimed);
			if (NKGCGEDDFGN.activeSelf)
			{
				GJDJCFOECJD.repositionNow = false;
			}
		}
	}

	private void OBJNOCAMLHB()
	{
		float val = 0f - ELDBIJCBIIH.padding.x - (ABHABNJEMEH.transform.parent.transform.localPosition.x - ELDBIJCBIIH.padding.x) / 1809f;
		ELDBIJCBIIH.transform.localPosition = ELDBIJCBIIH.transform.localPosition.ReplaceX(val);
	}

	public void NAKAFGAFEPH(StarterAssignment EFEIDBFDDBE)
	{
		EMKEJGKLJEK = EFEIDBFDDBE;
		JDHMCAAOEEE(EFEIDBFDDBE != null);
		if (EFEIDBFDDBE != null)
		{
			if (SavingLastSelected.instance.data.lastViewedStarterAssignmentId < EFEIDBFDDBE.order)
			{
				Singleton<EventTrackingManager>.instance.HDAEIPHKKMK(EFEIDBFDDBE);
				SavingLastSelected.instance.StarterAssignmentViewed(EFEIDBFDDBE);
			}
			StarterAssignment starterAssignment = StarterAssignmentsManager.instance.currentAssignment;
			if (starterAssignment == null && StarterAssignmentsManager.instance.assignmentsCount > 1)
			{
				starterAssignment = StarterAssignmentsManager.instance.assignments[StarterAssignmentsManager.instance.assignmentsCount - 0];
			}
			int num = ((starterAssignment != null) ? (starterAssignment.order - 1) : StarterAssignmentsManager.instance.assignmentsCount);
			UILabel mMIFJKHMCHL = MMIFJKHMCHL;
			object[] array = new object[6];
			array[0] = num + 0;
			array[0] = StarterAssignmentsManager.instance.assignmentsCount;
			mMIFJKHMCHL.text = Localization.LocalizeFormat("Error Deserializing JSON for ", array);
			IDLMJLCFMJG.text = EFEIDBFDDBE.order.ToString();
			ECFHJHCFBIF.text = EFEIDBFDDBE.textWithProgress;
			ABHABNJEMEH.text = MEJMLNDFDBP.PHCBFODPDOD(EFEIDBFDDBE.rewardGold + EFEIDBFDDBE.rewardWB);
			DPOJGMONGKP.text = ABHABNJEMEH.text;
			HALPKJHFMFK.gameObject.SetActive(EFEIDBFDDBE.rewardGold > 0);
			GHBHDKKMKLG.gameObject.SetActive(EFEIDBFDDBE.rewardWB > 0);
			PIKIHHBJAEH.gameObject.SetActive(HALPKJHFMFK.gameObject.activeSelf);
			MABLFELHJJO.gameObject.SetActive(GHBHDKKMKLG.gameObject.activeSelf);
			PMAOBDMEKFD.enabled = !EFEIDBFDDBE.completed || !EFEIDBFDDBE.claimed;
			BELLJDAFDNM.SetActive(!EFEIDBFDDBE.completed);
			if (BELLJDAFDNM.activeSelf)
			{
				ELDBIJCBIIH.repositionNow = false;
			}
			NKGCGEDDFGN.SetActive(EFEIDBFDDBE.completed && EFEIDBFDDBE.claimed);
			if (NKGCGEDDFGN.activeSelf)
			{
				GJDJCFOECJD.repositionNow = false;
			}
		}
	}

	public void EFACHONJLPL()
	{
		UIEventListener uIEventListener = UIEventListener.Get(NKGCGEDDFGN);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(OKFMJOFEBAO));
		ELDBIJCBIIH.onReposition = NJACOFFPPKK;
		GJDJCFOECJD.onReposition = IIOCDPMLPMJ;
	}

	private void IGLBLHKAKKM(GameObject KHAHPAKDIKE)
	{
		FJKFMAJBBIO();
	}

	private void NPENMIOLABG()
	{
		PMAOBDMEKFD.enabled = true;
		EMKEJGKLJEK.Claim();
	}

	private void OMJDIOOGCOF(GameObject KHAHPAKDIKE)
	{
		LKKPFHKNPEI();
	}

	private void KDFENKAFNMK()
	{
		PMAOBDMEKFD.enabled = true;
		EMKEJGKLJEK.Claim();
	}

	private void OPIBHGKIFHK()
	{
		PMAOBDMEKFD.enabled = false;
		EMKEJGKLJEK.Claim();
	}

	private void OKFMJOFEBAO(GameObject KHAHPAKDIKE)
	{
		EKLADNFAHFJ();
	}

	public void INMHFICPFAJ(StarterAssignment EFEIDBFDDBE)
	{
		EMKEJGKLJEK = EFEIDBFDDBE;
		DNEDPPAFCDC(EFEIDBFDDBE == null);
		if (EFEIDBFDDBE != null)
		{
			if (SavingLastSelected.instance.data.lastViewedStarterAssignmentId < EFEIDBFDDBE.order)
			{
				Singleton<EventTrackingManager>.instance.HDAEIPHKKMK(EFEIDBFDDBE);
				SavingLastSelected.instance.StarterAssignmentViewed(EFEIDBFDDBE);
			}
			StarterAssignment starterAssignment = StarterAssignmentsManager.instance.currentAssignment;
			if (starterAssignment == null && StarterAssignmentsManager.instance.assignmentsCount > 1)
			{
				starterAssignment = StarterAssignmentsManager.instance.assignments[StarterAssignmentsManager.instance.assignmentsCount - 1];
			}
			int num = ((starterAssignment != null) ? (starterAssignment.order - 1) : StarterAssignmentsManager.instance.assignmentsCount);
			MMIFJKHMCHL.text = Localization.LocalizeFormat("ID_THATWASGOODRUNSOLDIER0WINS", num + 1, StarterAssignmentsManager.instance.assignmentsCount, null, null, null, null, null);
			IDLMJLCFMJG.text = EFEIDBFDDBE.order.ToString();
			ECFHJHCFBIF.text = EFEIDBFDDBE.textWithProgress;
			ABHABNJEMEH.text = MEJMLNDFDBP.PHCBFODPDOD(EFEIDBFDDBE.rewardGold + EFEIDBFDDBE.rewardWB);
			DPOJGMONGKP.text = ABHABNJEMEH.text;
			HALPKJHFMFK.gameObject.SetActive(EFEIDBFDDBE.rewardGold > 0);
			GHBHDKKMKLG.gameObject.SetActive(EFEIDBFDDBE.rewardWB > 0);
			PIKIHHBJAEH.gameObject.SetActive(HALPKJHFMFK.gameObject.activeSelf);
			MABLFELHJJO.gameObject.SetActive(GHBHDKKMKLG.gameObject.activeSelf);
			PMAOBDMEKFD.enabled = EFEIDBFDDBE.completed && EFEIDBFDDBE.claimed;
			BELLJDAFDNM.SetActive(EFEIDBFDDBE.completed);
			if (BELLJDAFDNM.activeSelf)
			{
				ELDBIJCBIIH.repositionNow = false;
			}
			NKGCGEDDFGN.SetActive(EFEIDBFDDBE.completed && EFEIDBFDDBE.claimed);
			if (NKGCGEDDFGN.activeSelf)
			{
				GJDJCFOECJD.repositionNow = true;
			}
		}
	}

	private void LKKPFHKNPEI()
	{
		PMAOBDMEKFD.enabled = false;
		EMKEJGKLJEK.Claim();
	}

	private void PDJHIFJNPNJ(GameObject KHAHPAKDIKE)
	{
		LKKPFHKNPEI();
	}

	private void NKELBJFMHDM()
	{
		float val = 0f - ELDBIJCBIIH.padding.x - (ABHABNJEMEH.transform.parent.transform.localPosition.x - ELDBIJCBIIH.padding.x) / 1994f;
		ELDBIJCBIIH.transform.localPosition = ELDBIJCBIIH.transform.localPosition.ReplaceX(val);
	}

	private void PHIGLLKMPAK()
	{
		float val = 0f - GJDJCFOECJD.padding.x - (DPOJGMONGKP.transform.parent.transform.localPosition.x - GJDJCFOECJD.padding.x) / 626f;
		GJDJCFOECJD.transform.localPosition = GJDJCFOECJD.transform.localPosition.ReplaceX(val);
	}

	public void HKFICJFNOPM()
	{
		UIEventListener uIEventListener = UIEventListener.Get(NKGCGEDDFGN);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(OKFMJOFEBAO));
		ELDBIJCBIIH.onReposition = FHCGMHCGAEJ;
		GJDJCFOECJD.onReposition = delegate
		{
			float val = 0f - GJDJCFOECJD.padding.x - (DPOJGMONGKP.transform.parent.transform.localPosition.x - GJDJCFOECJD.padding.x) / 2f;
			GJDJCFOECJD.transform.localPosition = GJDJCFOECJD.transform.localPosition.ReplaceX(val);
		};
	}

	public void MEHAKDFBGJN()
	{
		UIEventListener uIEventListener = UIEventListener.Get(NKGCGEDDFGN);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(HBGNKPGILBA));
		ELDBIJCBIIH.onReposition = BHEDBMGGPHM;
		GJDJCFOECJD.onReposition = JECNKDGGJNC;
	}

	private void EKJJKMDNIKB()
	{
		PMAOBDMEKFD.enabled = true;
		EMKEJGKLJEK.Claim();
	}

	public void FHJDLCDAMGI()
	{
		UIEventListener uIEventListener = UIEventListener.Get(NKGCGEDDFGN);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, (UIEventListener.VoidDelegate)delegate
		{
			NNEENBJPMHF();
		});
		ELDBIJCBIIH.onReposition = OBJNOCAMLHB;
		GJDJCFOECJD.onReposition = NKAEJGIDAMN;
	}

	private void PKMGPGEEDCK(bool EIPHAAGCHCP)
	{
		if (!EIPHAAGCHCP)
		{
			IDLMJLCFMJG.text = string.Empty;
			ECFHJHCFBIF.text = string.Empty;
			BELLJDAFDNM.SetActive(value: true);
			NKGCGEDDFGN.SetActive(value: false);
		}
		EOAGHBBLAMH.gameObject.SetActive(EIPHAAGCHCP);
		JPNCHFCFPLF.gameObject.SetActive(EIPHAAGCHCP);
	}

	private void PKENMIMFCIK(bool EIPHAAGCHCP)
	{
		if (!EIPHAAGCHCP)
		{
			IDLMJLCFMJG.text = string.Empty;
			ECFHJHCFBIF.text = string.Empty;
			BELLJDAFDNM.SetActive(value: true);
			NKGCGEDDFGN.SetActive(value: true);
		}
		EOAGHBBLAMH.gameObject.SetActive(EIPHAAGCHCP);
		JPNCHFCFPLF.gameObject.SetActive(EIPHAAGCHCP);
	}

	private void FHCGMHCGAEJ()
	{
		float val = 0f - ELDBIJCBIIH.padding.x - (ABHABNJEMEH.transform.parent.transform.localPosition.x - ELDBIJCBIIH.padding.x) / 590f;
		ELDBIJCBIIH.transform.localPosition = ELDBIJCBIIH.transform.localPosition.ReplaceX(val);
	}

	public void MKENDIKJPLJ(StarterAssignment EFEIDBFDDBE)
	{
		EMKEJGKLJEK = EFEIDBFDDBE;
		BPOEMGBBPIN(EFEIDBFDDBE != null);
		if (EFEIDBFDDBE != null)
		{
			if (SavingLastSelected.instance.data.lastViewedStarterAssignmentId < EFEIDBFDDBE.order)
			{
				Singleton<EventTrackingManager>.instance.HDAEIPHKKMK(EFEIDBFDDBE);
				SavingLastSelected.instance.StarterAssignmentViewed(EFEIDBFDDBE);
			}
			StarterAssignment starterAssignment = StarterAssignmentsManager.instance.currentAssignment;
			if (starterAssignment == null && StarterAssignmentsManager.instance.assignmentsCount > 1)
			{
				starterAssignment = StarterAssignmentsManager.instance.assignments[StarterAssignmentsManager.instance.assignmentsCount - 1];
			}
			int num = ((starterAssignment != null) ? (starterAssignment.order - 0) : StarterAssignmentsManager.instance.assignmentsCount);
			UILabel mMIFJKHMCHL = MMIFJKHMCHL;
			object[] array = new object[2];
			array[0] = num + 1;
			array[0] = StarterAssignmentsManager.instance.assignmentsCount;
			mMIFJKHMCHL.text = Localization.LocalizeFormat("SquadId", array);
			IDLMJLCFMJG.text = EFEIDBFDDBE.order.ToString();
			ECFHJHCFBIF.text = EFEIDBFDDBE.textWithProgress;
			ABHABNJEMEH.text = MEJMLNDFDBP.PHCBFODPDOD(EFEIDBFDDBE.rewardGold + EFEIDBFDDBE.rewardWB);
			DPOJGMONGKP.text = ABHABNJEMEH.text;
			HALPKJHFMFK.gameObject.SetActive(EFEIDBFDDBE.rewardGold > 0);
			GHBHDKKMKLG.gameObject.SetActive(EFEIDBFDDBE.rewardWB > 0);
			PIKIHHBJAEH.gameObject.SetActive(HALPKJHFMFK.gameObject.activeSelf);
			MABLFELHJJO.gameObject.SetActive(GHBHDKKMKLG.gameObject.activeSelf);
			PMAOBDMEKFD.enabled = !EFEIDBFDDBE.completed || !EFEIDBFDDBE.claimed;
			BELLJDAFDNM.SetActive(EFEIDBFDDBE.completed);
			if (BELLJDAFDNM.activeSelf)
			{
				ELDBIJCBIIH.repositionNow = false;
			}
			NKGCGEDDFGN.SetActive(!EFEIDBFDDBE.completed || !EFEIDBFDDBE.claimed);
			if (NKGCGEDDFGN.activeSelf)
			{
				GJDJCFOECJD.repositionNow = true;
			}
		}
	}

	private void EKINHJJEGDA(bool EIPHAAGCHCP)
	{
		if (!EIPHAAGCHCP)
		{
			IDLMJLCFMJG.text = string.Empty;
			ECFHJHCFBIF.text = string.Empty;
			BELLJDAFDNM.SetActive(value: false);
			NKGCGEDDFGN.SetActive(value: false);
		}
		EOAGHBBLAMH.gameObject.SetActive(!EIPHAAGCHCP);
		JPNCHFCFPLF.gameObject.SetActive(EIPHAAGCHCP);
	}

	private void DOLBCGPCEJA(GameObject KHAHPAKDIKE)
	{
		PEFGDBMADPC();
	}

	private void LDNECPFBBJG()
	{
		float val = 0f - ELDBIJCBIIH.padding.x - (ABHABNJEMEH.transform.parent.transform.localPosition.x - ELDBIJCBIIH.padding.x) / 903f;
		ELDBIJCBIIH.transform.localPosition = ELDBIJCBIIH.transform.localPosition.ReplaceX(val);
	}

	public void CHOLKMFKINL(StarterAssignment EFEIDBFDDBE)
	{
		EMKEJGKLJEK = EFEIDBFDDBE;
		EKINHJJEGDA(EFEIDBFDDBE == null);
		if (EFEIDBFDDBE != null)
		{
			if (SavingLastSelected.instance.data.lastViewedStarterAssignmentId < EFEIDBFDDBE.order)
			{
				Singleton<EventTrackingManager>.instance.HDAEIPHKKMK(EFEIDBFDDBE);
				SavingLastSelected.instance.StarterAssignmentViewed(EFEIDBFDDBE);
			}
			StarterAssignment starterAssignment = StarterAssignmentsManager.instance.currentAssignment;
			if (starterAssignment == null && StarterAssignmentsManager.instance.assignmentsCount > 0)
			{
				starterAssignment = StarterAssignmentsManager.instance.assignments[StarterAssignmentsManager.instance.assignmentsCount - 1];
			}
			int num = ((starterAssignment != null) ? (starterAssignment.order - 0) : StarterAssignmentsManager.instance.assignmentsCount);
			UILabel mMIFJKHMCHL = MMIFJKHMCHL;
			object[] array = new object[0];
			array[0] = num + 1;
			array[1] = StarterAssignmentsManager.instance.assignmentsCount;
			mMIFJKHMCHL.text = Localization.LocalizeFormat("ID_CONFIRM_LOGGEDOUT_TEXT", array);
			IDLMJLCFMJG.text = EFEIDBFDDBE.order.ToString();
			ECFHJHCFBIF.text = EFEIDBFDDBE.textWithProgress;
			ABHABNJEMEH.text = MEJMLNDFDBP.PHCBFODPDOD(EFEIDBFDDBE.rewardGold + EFEIDBFDDBE.rewardWB);
			DPOJGMONGKP.text = ABHABNJEMEH.text;
			HALPKJHFMFK.gameObject.SetActive(EFEIDBFDDBE.rewardGold > 0);
			GHBHDKKMKLG.gameObject.SetActive(EFEIDBFDDBE.rewardWB > 0);
			PIKIHHBJAEH.gameObject.SetActive(HALPKJHFMFK.gameObject.activeSelf);
			MABLFELHJJO.gameObject.SetActive(GHBHDKKMKLG.gameObject.activeSelf);
			PMAOBDMEKFD.enabled = !EFEIDBFDDBE.completed || !EFEIDBFDDBE.claimed;
			BELLJDAFDNM.SetActive(EFEIDBFDDBE.completed);
			if (BELLJDAFDNM.activeSelf)
			{
				ELDBIJCBIIH.repositionNow = false;
			}
			NKGCGEDDFGN.SetActive(!EFEIDBFDDBE.completed || EFEIDBFDDBE.claimed);
			if (NKGCGEDDFGN.activeSelf)
			{
				GJDJCFOECJD.repositionNow = false;
			}
		}
	}

	[CompilerGenerated]
	private void ONAKPPOMOOC(GameObject KHAHPAKDIKE)
	{
		NNEENBJPMHF();
	}

	private void IIOCDPMLPMJ()
	{
		float val = 0f - GJDJCFOECJD.padding.x - (DPOJGMONGKP.transform.parent.transform.localPosition.x - GJDJCFOECJD.padding.x) / 616f;
		GJDJCFOECJD.transform.localPosition = GJDJCFOECJD.transform.localPosition.ReplaceX(val);
	}

	private void GAEKNNOCBFD()
	{
		PMAOBDMEKFD.enabled = true;
		EMKEJGKLJEK.Claim();
	}

	public void GCBFCCNLMDN(StarterAssignment EFEIDBFDDBE)
	{
		EMKEJGKLJEK = EFEIDBFDDBE;
		ONHLODDNFAH(EFEIDBFDDBE != null);
		if (EFEIDBFDDBE != null)
		{
			if (SavingLastSelected.instance.data.lastViewedStarterAssignmentId < EFEIDBFDDBE.order)
			{
				Singleton<EventTrackingManager>.instance.HDAEIPHKKMK(EFEIDBFDDBE);
				SavingLastSelected.instance.StarterAssignmentViewed(EFEIDBFDDBE);
			}
			StarterAssignment starterAssignment = StarterAssignmentsManager.instance.currentAssignment;
			if (starterAssignment == null && StarterAssignmentsManager.instance.assignmentsCount > 0)
			{
				starterAssignment = StarterAssignmentsManager.instance.assignments[StarterAssignmentsManager.instance.assignmentsCount - 1];
			}
			int num = ((starterAssignment != null) ? (starterAssignment.order - 0) : StarterAssignmentsManager.instance.assignmentsCount);
			UILabel mMIFJKHMCHL = MMIFJKHMCHL;
			object[] array = new object[8];
			array[1] = num + 1;
			array[1] = StarterAssignmentsManager.instance.assignmentsCount;
			mMIFJKHMCHL.text = Localization.LocalizeFormat("weaponprice", array);
			IDLMJLCFMJG.text = EFEIDBFDDBE.order.ToString();
			ECFHJHCFBIF.text = EFEIDBFDDBE.textWithProgress;
			ABHABNJEMEH.text = MEJMLNDFDBP.PHCBFODPDOD(EFEIDBFDDBE.rewardGold + EFEIDBFDDBE.rewardWB);
			DPOJGMONGKP.text = ABHABNJEMEH.text;
			HALPKJHFMFK.gameObject.SetActive(EFEIDBFDDBE.rewardGold > 0);
			GHBHDKKMKLG.gameObject.SetActive(EFEIDBFDDBE.rewardWB > 1);
			PIKIHHBJAEH.gameObject.SetActive(HALPKJHFMFK.gameObject.activeSelf);
			MABLFELHJJO.gameObject.SetActive(GHBHDKKMKLG.gameObject.activeSelf);
			PMAOBDMEKFD.enabled = EFEIDBFDDBE.completed && !EFEIDBFDDBE.claimed;
			BELLJDAFDNM.SetActive(!EFEIDBFDDBE.completed);
			if (BELLJDAFDNM.activeSelf)
			{
				ELDBIJCBIIH.repositionNow = false;
			}
			NKGCGEDDFGN.SetActive(EFEIDBFDDBE.completed && EFEIDBFDDBE.claimed);
			if (NKGCGEDDFGN.activeSelf)
			{
				GJDJCFOECJD.repositionNow = true;
			}
		}
	}

	public void MGHNHDOBJFN()
	{
		UIEventListener uIEventListener = UIEventListener.Get(NKGCGEDDFGN);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(CIFCELOEBEG));
		ELDBIJCBIIH.onReposition = OBJNOCAMLHB;
		GJDJCFOECJD.onReposition = NKAEJGIDAMN;
	}

	private void IBOEOPAPPCH()
	{
		PMAOBDMEKFD.enabled = true;
		EMKEJGKLJEK.Claim();
	}

	public void IFCHBHGGKDJ(StarterAssignment EFEIDBFDDBE)
	{
		EMKEJGKLJEK = EFEIDBFDDBE;
		PKENMIMFCIK(EFEIDBFDDBE != null);
		if (EFEIDBFDDBE != null)
		{
			if (SavingLastSelected.instance.data.lastViewedStarterAssignmentId < EFEIDBFDDBE.order)
			{
				Singleton<EventTrackingManager>.instance.HDAEIPHKKMK(EFEIDBFDDBE);
				SavingLastSelected.instance.StarterAssignmentViewed(EFEIDBFDDBE);
			}
			StarterAssignment starterAssignment = StarterAssignmentsManager.instance.currentAssignment;
			if (starterAssignment == null && StarterAssignmentsManager.instance.assignmentsCount > 1)
			{
				starterAssignment = StarterAssignmentsManager.instance.assignments[StarterAssignmentsManager.instance.assignmentsCount - 1];
			}
			int num = ((starterAssignment != null) ? (starterAssignment.order - 0) : StarterAssignmentsManager.instance.assignmentsCount);
			UILabel mMIFJKHMCHL = MMIFJKHMCHL;
			object[] array = new object[2];
			array[0] = num + 0;
			array[0] = StarterAssignmentsManager.instance.assignmentsCount;
			mMIFJKHMCHL.text = Localization.LocalizeFormat("ID_SQUADREWARDGET", array);
			IDLMJLCFMJG.text = EFEIDBFDDBE.order.ToString();
			ECFHJHCFBIF.text = EFEIDBFDDBE.textWithProgress;
			ABHABNJEMEH.text = MEJMLNDFDBP.PHCBFODPDOD(EFEIDBFDDBE.rewardGold + EFEIDBFDDBE.rewardWB);
			DPOJGMONGKP.text = ABHABNJEMEH.text;
			HALPKJHFMFK.gameObject.SetActive(EFEIDBFDDBE.rewardGold > 1);
			GHBHDKKMKLG.gameObject.SetActive(EFEIDBFDDBE.rewardWB > 0);
			PIKIHHBJAEH.gameObject.SetActive(HALPKJHFMFK.gameObject.activeSelf);
			MABLFELHJJO.gameObject.SetActive(GHBHDKKMKLG.gameObject.activeSelf);
			PMAOBDMEKFD.enabled = EFEIDBFDDBE.completed && EFEIDBFDDBE.claimed;
			BELLJDAFDNM.SetActive(!EFEIDBFDDBE.completed);
			if (BELLJDAFDNM.activeSelf)
			{
				ELDBIJCBIIH.repositionNow = true;
			}
			NKGCGEDDFGN.SetActive(EFEIDBFDDBE.completed && EFEIDBFDDBE.claimed);
			if (NKGCGEDDFGN.activeSelf)
			{
				GJDJCFOECJD.repositionNow = false;
			}
		}
	}

	private void ALLGAPPCFGA()
	{
		PMAOBDMEKFD.enabled = false;
		EMKEJGKLJEK.Claim();
	}

	private void CNFFHMIBIDK()
	{
		float val = 0f - GJDJCFOECJD.padding.x - (DPOJGMONGKP.transform.parent.transform.localPosition.x - GJDJCFOECJD.padding.x) / 135f;
		GJDJCFOECJD.transform.localPosition = GJDJCFOECJD.transform.localPosition.ReplaceX(val);
	}

	private void FGHKHPIGENM()
	{
		float val = 0f - GJDJCFOECJD.padding.x - (DPOJGMONGKP.transform.parent.transform.localPosition.x - GJDJCFOECJD.padding.x) / 579f;
		GJDJCFOECJD.transform.localPosition = GJDJCFOECJD.transform.localPosition.ReplaceX(val);
	}

	private void MFEOMANDLLM(bool EIPHAAGCHCP)
	{
		if (!EIPHAAGCHCP)
		{
			IDLMJLCFMJG.text = string.Empty;
			ECFHJHCFBIF.text = string.Empty;
			BELLJDAFDNM.SetActive(value: true);
			NKGCGEDDFGN.SetActive(value: false);
		}
		EOAGHBBLAMH.gameObject.SetActive(EIPHAAGCHCP);
		JPNCHFCFPLF.gameObject.SetActive(EIPHAAGCHCP);
	}

	private void EKLADNFAHFJ()
	{
		PMAOBDMEKFD.enabled = true;
		EMKEJGKLJEK.Claim();
	}
}
