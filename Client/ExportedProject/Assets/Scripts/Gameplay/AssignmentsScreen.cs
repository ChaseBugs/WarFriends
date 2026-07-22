using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class AssignmentsScreen : GuiScreenSingle<AssignmentsScreen>
{
	[FormerlySerializedAs("LIAHCIJAOCM")]
	[Header("Contents")]
	public DailyPart POCILDLIHAB;

	[FormerlySerializedAs("LAGCCONJDHA")]
	public StarterAssignmentPart KLEMMCBBABJ;

	[FormerlySerializedAs("OEFCCFBCALF")]
	[Header("Others")]
	public UISprite KOPOAEPDIDP;

	[Header("Debug")]
	[FormerlySerializedAs("BGCGLIJKDJO")]
	public GameObject IJMGEOECBHN;

	[FormerlySerializedAs("BECBOFNJFDG")]
	public GameObject MBOCMCJHNNF;

	[FormerlySerializedAs("KFJHGIBAAGK")]
	public GameObject PFMIFNHFCHC;

	[FormerlySerializedAs("GELGEBAMDII")]
	public GameObject LIINBIBKBNC;

	[FormerlySerializedAs("OLMAHGLMCED")]
	public GameObject BOABLHFMPHG;

	[FormerlySerializedAs("GFPGAOABMDF")]
	public readonly float HAMKIKMJHDP = 0.2f;

	public void EELOJAINBLK()
	{
		POCILDLIHAB.NAJDAPMNDPJ();
	}

	private void LAGPBPMHMEG(GameObject KHAHPAKDIKE)
	{
		RequestBufferManager.instance.ForceSendClaimAssignment();
		Singleton<BeanstalkServerManager>.instance.BJNADDOCENE();
	}

	private void JEAPPHBBMNA()
	{
		IJMGEOECBHN.SetActive(value: false);
		LIINBIBKBNC.SetActive(value: false);
	}

	public virtual void DNFPEBEDLIG()
	{
		KBLKGMEKGAI();
		HJKLHKGHCJK();
	}

	protected override void AGIKPOLCGNF()
	{
		POCILDLIHAB.InitControls();
		KLEMMCBBABJ.InitControls();
	}

	public virtual void BFLHENDLPLK()
	{
		KBLKGMEKGAI();
		HJKLHKGHCJK();
	}

	public virtual void OFCCACPEBHD()
	{
		JEAPPHBBMNA();
		HJKLHKGHCJK();
	}

	public virtual void JCIBDJMFOLI()
	{
		KBLKGMEKGAI();
		HJKLHKGHCJK(PDPDGCNHCFN: true);
	}

	public virtual void KDDJHIMDKBN()
	{
		KBLKGMEKGAI();
		HJKLHKGHCJK(PDPDGCNHCFN: true);
	}

	protected virtual void LPFPAKGNNIO()
	{
		POCILDLIHAB.NINGMLNMLLP();
		KLEMMCBBABJ.AOKOKHGEIBE();
	}

	public override void InitGUIValues()
	{
		KBLKGMEKGAI();
		HJKLHKGHCJK(PDPDGCNHCFN: true);
	}

	public void FBMJGBACAGK()
	{
		POCILDLIHAB.BNCJGGDJKFG();
	}

	private void PCLMIDNCIJG(GameObject KHAHPAKDIKE)
	{
		if (StarterAssignmentsManager.instance.currentAssignment != null)
		{
			StarterAssignmentsManager.instance.currentAssignment.completed = true;
			List<string> list = new List<string>();
			list.Add(StarterAssignmentsManager.instance.currentAssignment.id);
			Singleton<BeanstalkServerManager>.instance.PMOJKOPHHEL(list);
		}
	}

	private void KMNIDMGAKNN(GameObject KHAHPAKDIKE)
	{
		RequestBufferManager.instance.ForceSendClaimAssignment();
		Singleton<BeanstalkServerManager>.instance.BJNADDOCENE();
	}

	private void OKKHKLPNHHK(bool PDPDGCNHCFN)
	{
		bool flag = !StarterAssignmentsManager.instance.isActiveAndNotCompleted;
		bool isActiveAndNotCompleted = StarterAssignmentsManager.instance.isActiveAndNotCompleted;
		if (PDPDGCNHCFN)
		{
			POCILDLIHAB.Animate(flag, PDPDGCNHCFN: true);
			KLEMMCBBABJ.Animate(isActiveAndNotCompleted, PDPDGCNHCFN: true);
			return;
		}
		if (POCILDLIHAB.gameObject.activeSelf && !flag)
		{
			POCILDLIHAB.Animate(flag, PDPDGCNHCFN: false);
		}
		if (KLEMMCBBABJ.gameObject.activeSelf && !isActiveAndNotCompleted)
		{
			KLEMMCBBABJ.Animate(isActiveAndNotCompleted, PDPDGCNHCFN: false);
		}
		if (!POCILDLIHAB.gameObject.activeSelf && flag)
		{
			POCILDLIHAB.Animate(flag, PDPDGCNHCFN: false);
		}
		if (!KLEMMCBBABJ.gameObject.activeSelf && isActiveAndNotCompleted)
		{
			KLEMMCBBABJ.Animate(isActiveAndNotCompleted, PDPDGCNHCFN: false);
		}
		if (POCILDLIHAB.gameObject.activeSelf && flag)
		{
			POCILDLIHAB.Animate(flag, PDPDGCNHCFN: false);
		}
		if (KLEMMCBBABJ.gameObject.activeSelf && isActiveAndNotCompleted)
		{
			KLEMMCBBABJ.Animate(isActiveAndNotCompleted, PDPDGCNHCFN: false);
		}
	}

	private void KBLKGMEKGAI()
	{
		IJMGEOECBHN.SetActive(value: false);
		LIINBIBKBNC.SetActive(value: false);
	}

	public void ReinitializeMegaReward()
	{
		POCILDLIHAB.ReinitializeMegaReward();
	}

	public virtual void AOJLEKOMJOH()
	{
		POCILDLIHAB.ALDOOKEMKPN();
	}

	private void LIBDNPHNIHP(bool PDPDGCNHCFN)
	{
		bool flag = !StarterAssignmentsManager.instance.isActiveAndNotCompleted;
		bool isActiveAndNotCompleted = StarterAssignmentsManager.instance.isActiveAndNotCompleted;
		if (PDPDGCNHCFN)
		{
			POCILDLIHAB.PKLJHBFJJJO(flag, PDPDGCNHCFN: true);
			KLEMMCBBABJ.BCLDACBBJPO(isActiveAndNotCompleted, PDPDGCNHCFN: false);
			return;
		}
		if (POCILDLIHAB.gameObject.activeSelf && !flag)
		{
			POCILDLIHAB.PKLJHBFJJJO(flag, PDPDGCNHCFN: false);
		}
		if (KLEMMCBBABJ.gameObject.activeSelf && !isActiveAndNotCompleted)
		{
			KLEMMCBBABJ.Animate(isActiveAndNotCompleted, PDPDGCNHCFN: true);
		}
		if (!POCILDLIHAB.gameObject.activeSelf && flag)
		{
			POCILDLIHAB.Animate(flag, PDPDGCNHCFN: false);
		}
		if (!KLEMMCBBABJ.gameObject.activeSelf && isActiveAndNotCompleted)
		{
			KLEMMCBBABJ.DBGBPLFENBG(isActiveAndNotCompleted, PDPDGCNHCFN: true);
		}
		if (POCILDLIHAB.gameObject.activeSelf && flag)
		{
			POCILDLIHAB.PKLJHBFJJJO(flag, PDPDGCNHCFN: true);
		}
		if (KLEMMCBBABJ.gameObject.activeSelf && isActiveAndNotCompleted)
		{
			KLEMMCBBABJ.BCLDACBBJPO(isActiveAndNotCompleted, PDPDGCNHCFN: true);
		}
	}

	private void DFHOFIADIED(GameObject KHAHPAKDIKE)
	{
		AssignmentsManager.instance.SetAllAssignmentsCompletedDebug();
	}

	private void HJKLHKGHCJK(bool PDPDGCNHCFN = false)
	{
		OKKHKLPNHHK(PDPDGCNHCFN);
	}

	public override void InitEvents()
	{
		POCILDLIHAB.InitEvents();
	}

	public override void DoAfterHide()
	{
		base.DoAfterHide();
		POCILDLIHAB.DoAfterHide();
		KLEMMCBBABJ.DoAfterHide();
	}
}
