using System.Collections.Generic;
using UnityEngine;

public class AssignmentsScreen : GuiScreenSingle<AssignmentsScreen>
{
	[Header("Contents")]
	public DailyPart POCILDLIHAB;

	public StarterAssignmentPart KLEMMCBBABJ;

	[Header("Others")]
	public UISprite KOPOAEPDIDP;

	[Header("Debug")]
	public GameObject IJMGEOECBHN;

	public GameObject MBOCMCJHNNF;

	public GameObject PFMIFNHFCHC;

	public GameObject LIINBIBKBNC;

	public GameObject BOABLHFMPHG;

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
		IJMGEOECBHN.SetActive(false);
		LIINBIBKBNC.SetActive(false);
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
		HJKLHKGHCJK(true);
	}

	public virtual void KDDJHIMDKBN()
	{
		KBLKGMEKGAI();
		HJKLHKGHCJK(true);
	}

	protected virtual void LPFPAKGNNIO()
	{
		POCILDLIHAB.NINGMLNMLLP();
		KLEMMCBBABJ.AOKOKHGEIBE();
	}

	public override void InitGUIValues()
	{
		KBLKGMEKGAI();
		HJKLHKGHCJK(true);
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
			POCILDLIHAB.Animate(flag, true);
			KLEMMCBBABJ.Animate(isActiveAndNotCompleted, true);
			return;
		}
		if (POCILDLIHAB.gameObject.activeSelf && !flag)
		{
			POCILDLIHAB.Animate(flag, false);
		}
		if (KLEMMCBBABJ.gameObject.activeSelf && !isActiveAndNotCompleted)
		{
			KLEMMCBBABJ.Animate(isActiveAndNotCompleted, false);
		}
		if (!POCILDLIHAB.gameObject.activeSelf && flag)
		{
			POCILDLIHAB.Animate(flag, false);
		}
		if (!KLEMMCBBABJ.gameObject.activeSelf && isActiveAndNotCompleted)
		{
			KLEMMCBBABJ.Animate(isActiveAndNotCompleted, false);
		}
		if (POCILDLIHAB.gameObject.activeSelf && flag)
		{
			POCILDLIHAB.Animate(flag, false);
		}
		if (KLEMMCBBABJ.gameObject.activeSelf && isActiveAndNotCompleted)
		{
			KLEMMCBBABJ.Animate(isActiveAndNotCompleted, false);
		}
	}

	private void KBLKGMEKGAI()
	{
		IJMGEOECBHN.SetActive(false);
		LIINBIBKBNC.SetActive(false);
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
			POCILDLIHAB.PKLJHBFJJJO(flag, true);
			KLEMMCBBABJ.BCLDACBBJPO(isActiveAndNotCompleted, false);
			return;
		}
		if (POCILDLIHAB.gameObject.activeSelf && !flag)
		{
			POCILDLIHAB.PKLJHBFJJJO(flag, false);
		}
		if (KLEMMCBBABJ.gameObject.activeSelf && !isActiveAndNotCompleted)
		{
			KLEMMCBBABJ.Animate(isActiveAndNotCompleted, true);
		}
		if (!POCILDLIHAB.gameObject.activeSelf && flag)
		{
			POCILDLIHAB.Animate(flag, false);
		}
		if (!KLEMMCBBABJ.gameObject.activeSelf && isActiveAndNotCompleted)
		{
			KLEMMCBBABJ.DBGBPLFENBG(isActiveAndNotCompleted, true);
		}
		if (POCILDLIHAB.gameObject.activeSelf && flag)
		{
			POCILDLIHAB.PKLJHBFJJJO(flag, true);
		}
		if (KLEMMCBBABJ.gameObject.activeSelf && isActiveAndNotCompleted)
		{
			KLEMMCBBABJ.BCLDACBBJPO(isActiveAndNotCompleted, true);
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
