using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerAugmentations : MonoBehaviour
{
	public enum BHCPMIHNHHP
	{
		Started,
		Ended
	}

	public delegate void NMKDNNMJJLP(KGIMIHGHKMD HILNKGONIOM, BHCPMIHNHHP KINCJIBBDLP);

	private sealed class HJFDCDKIKPG
	{
		public PlayerAugmentations HNNCIECPFEJ;

		public KGIMIHGHKMD HILNKGONIOM;

		internal void MKKCAMBJHFN()
		{
		}

		internal void NHNLPCHGJOM()
		{
		}
	}

	private sealed class GJCHDDNJLOC
	{
		public PlayerAugmentations HNNCIECPFEJ;

		public int FHOHMEMIBMG;

		internal void EEMJFPHOACG()
		{
		}

		internal void GBJOGAIHGPH()
		{
		}

		internal void FOIEGEGFBPD()
		{
		}
	}

	private PhotonView IBBJLFJLAFA;

	[CompilerGenerated]
	private bool _003CHPPNIHGNABO_003Ek__BackingField;

	public KGIMIHGHKMD[] GACDAGPAONH;

	[CompilerGenerated]
	private NMKDNNMJJLP JIOKFHCEAFC;

	private PEEMNNNBDJE[] FPPNBJLKFJC;

	private List<Tuple<Action, KGIMIHGHKMD>> KMGGCNGFFAF;

	private List<Tuple<Action, KGIMIHGHKMD>> MNIABJBEKBP;

	private List<Tuple<Action, KGIMIHGHKMD>> HFHELOGPBLC;

	public bool IsDataReady
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

	public event NMKDNNMJJLP onEffectStatusChanged
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

	private void Awake()
	{
	}

	private void Start()
	{
	}

	private void OnDestroy()
	{
	}

	private void DJIKBALBFCM()
	{
	}

	private void HCOCHDHHLPC(GameController.ALOAMODMHMO KIHIFIBOOIM)
	{
	}

	private void EJKPOMEMKGB()
	{
	}

	[PunRPC]
	private void LoadOpponentAugmentationsRPC(AugmentationManager.Augmentation[] MLEMHDIDGMN)
	{
	}

	private void ACJIMJDGEEL(KGIMIHGHKMD HILNKGONIOM)
	{
	}

	private void HEJGPNHJMDC(DJLLCPELJDB HILNKGONIOM, int EPNGMAHENPA)
	{
	}

	private void OMGEJLJPADK()
	{
	}

	[PunRPC]
	private void AugmentationEffectStartedRPC(int EPNGMAHENPA)
	{
	}

	[PunRPC]
	private void AugmentationEffectEndedRPC(int EPNGMAHENPA)
	{
	}

	[PunRPC]
	private void AugmentationEffectRefreshedRPC(int EPNGMAHENPA)
	{
	}
}
