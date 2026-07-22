using UnityEngine;
using UnityEngine.Serialization;

[ExecuteInEditMode]
[AddComponentMenu("NGUI/Interaction/Draggable Panel with paralax")]
[RequireComponent(typeof(UIPanel))]
public class UIDraggablePanelWithScale : UIDraggablePanel
{
	[FormerlySerializedAs("MBJHBEGAABI")]
	public Transform JOPLDCDHCAF;

	[FormerlySerializedAs("PCBBFCPLMLL")]
	public float HMNLFKFGEPD = 0.01f;

	public virtual void BNDLBNDOICC(Vector3 CKAFNIAKKIF)
	{
		if (JOPLDCDHCAF == null)
		{
			base.MoveRelative(CKAFNIAKKIF);
			return;
		}
		mTrans.localPosition += CKAFNIAKKIF;
		JOPLDCDHCAF.localPosition += CKAFNIAKKIF * HMNLFKFGEPD;
		Vector4 clipRange = base.panel.clipRange;
		clipRange.x -= CKAFNIAKKIF.x;
		clipRange.y -= CKAFNIAKKIF.y;
		base.panel.clipRange = clipRange;
		UpdateScrollbars(recalculateBounds: false);
	}

	public virtual void OFGPCEJJACE(Vector3 CKAFNIAKKIF)
	{
		if (JOPLDCDHCAF == null)
		{
			base.MoveRelative(CKAFNIAKKIF);
			return;
		}
		mTrans.localPosition += CKAFNIAKKIF;
		JOPLDCDHCAF.localPosition += CKAFNIAKKIF * HMNLFKFGEPD;
		Vector4 clipRange = base.panel.clipRange;
		clipRange.x -= CKAFNIAKKIF.x;
		clipRange.y -= CKAFNIAKKIF.y;
		base.panel.clipRange = clipRange;
		UpdateScrollbars(recalculateBounds: true);
	}

	public virtual void IJBDELHHFLM(Vector3 CKAFNIAKKIF)
	{
		if (JOPLDCDHCAF == null)
		{
			base.MoveRelative(CKAFNIAKKIF);
			return;
		}
		mTrans.localPosition += CKAFNIAKKIF;
		JOPLDCDHCAF.localPosition += CKAFNIAKKIF * HMNLFKFGEPD;
		Vector4 clipRange = base.panel.clipRange;
		clipRange.x -= CKAFNIAKKIF.x;
		clipRange.y -= CKAFNIAKKIF.y;
		base.panel.clipRange = clipRange;
		UpdateScrollbars(recalculateBounds: true);
	}

	public virtual void CCJDEPEMOLH(Vector3 CKAFNIAKKIF)
	{
		if (JOPLDCDHCAF == null)
		{
			base.MoveRelative(CKAFNIAKKIF);
			return;
		}
		mTrans.localPosition += CKAFNIAKKIF;
		JOPLDCDHCAF.localPosition += CKAFNIAKKIF * HMNLFKFGEPD;
		Vector4 clipRange = base.panel.clipRange;
		clipRange.x -= CKAFNIAKKIF.x;
		clipRange.y -= CKAFNIAKKIF.y;
		base.panel.clipRange = clipRange;
		UpdateScrollbars(recalculateBounds: true);
	}

	public virtual void MCMHOEMKJIN(Vector3 CKAFNIAKKIF)
	{
		if (JOPLDCDHCAF == null)
		{
			base.MoveRelative(CKAFNIAKKIF);
			return;
		}
		mTrans.localPosition += CKAFNIAKKIF;
		JOPLDCDHCAF.localPosition += CKAFNIAKKIF * HMNLFKFGEPD;
		Vector4 clipRange = base.panel.clipRange;
		clipRange.x -= CKAFNIAKKIF.x;
		clipRange.y -= CKAFNIAKKIF.y;
		base.panel.clipRange = clipRange;
		UpdateScrollbars(recalculateBounds: false);
	}

	public virtual void ICBHEMFLACJ(Vector3 CKAFNIAKKIF)
	{
		if (JOPLDCDHCAF == null)
		{
			base.MoveRelative(CKAFNIAKKIF);
			return;
		}
		mTrans.localPosition += CKAFNIAKKIF;
		JOPLDCDHCAF.localPosition += CKAFNIAKKIF * HMNLFKFGEPD;
		Vector4 clipRange = base.panel.clipRange;
		clipRange.x -= CKAFNIAKKIF.x;
		clipRange.y -= CKAFNIAKKIF.y;
		base.panel.clipRange = clipRange;
		UpdateScrollbars(recalculateBounds: true);
	}

	public virtual void ALBNALNPEHG(Vector3 CKAFNIAKKIF)
	{
		if (JOPLDCDHCAF == null)
		{
			base.MoveRelative(CKAFNIAKKIF);
			return;
		}
		mTrans.localPosition += CKAFNIAKKIF;
		JOPLDCDHCAF.localPosition += CKAFNIAKKIF * HMNLFKFGEPD;
		Vector4 clipRange = base.panel.clipRange;
		clipRange.x -= CKAFNIAKKIF.x;
		clipRange.y -= CKAFNIAKKIF.y;
		base.panel.clipRange = clipRange;
		UpdateScrollbars(recalculateBounds: true);
	}

	public virtual void MDLGEBICLLA(Vector3 CKAFNIAKKIF)
	{
		if (JOPLDCDHCAF == null)
		{
			base.MoveRelative(CKAFNIAKKIF);
			return;
		}
		mTrans.localPosition += CKAFNIAKKIF;
		JOPLDCDHCAF.localPosition += CKAFNIAKKIF * HMNLFKFGEPD;
		Vector4 clipRange = base.panel.clipRange;
		clipRange.x -= CKAFNIAKKIF.x;
		clipRange.y -= CKAFNIAKKIF.y;
		base.panel.clipRange = clipRange;
		UpdateScrollbars(recalculateBounds: false);
	}

	public virtual void LHJJPJLAHDN(Vector3 CKAFNIAKKIF)
	{
		if (JOPLDCDHCAF == null)
		{
			base.MoveRelative(CKAFNIAKKIF);
			return;
		}
		mTrans.localPosition += CKAFNIAKKIF;
		JOPLDCDHCAF.localPosition += CKAFNIAKKIF * HMNLFKFGEPD;
		Vector4 clipRange = base.panel.clipRange;
		clipRange.x -= CKAFNIAKKIF.x;
		clipRange.y -= CKAFNIAKKIF.y;
		base.panel.clipRange = clipRange;
		UpdateScrollbars(recalculateBounds: true);
	}

	public virtual void OGBNKCKJMPK(Vector3 CKAFNIAKKIF)
	{
		if (JOPLDCDHCAF == null)
		{
			base.MoveRelative(CKAFNIAKKIF);
			return;
		}
		mTrans.localPosition += CKAFNIAKKIF;
		JOPLDCDHCAF.localPosition += CKAFNIAKKIF * HMNLFKFGEPD;
		Vector4 clipRange = base.panel.clipRange;
		clipRange.x -= CKAFNIAKKIF.x;
		clipRange.y -= CKAFNIAKKIF.y;
		base.panel.clipRange = clipRange;
		UpdateScrollbars(recalculateBounds: true);
	}

	public virtual void KMHEKEDOBAC(Vector3 CKAFNIAKKIF)
	{
		if (JOPLDCDHCAF == null)
		{
			base.MoveRelative(CKAFNIAKKIF);
			return;
		}
		mTrans.localPosition += CKAFNIAKKIF;
		JOPLDCDHCAF.localPosition += CKAFNIAKKIF * HMNLFKFGEPD;
		Vector4 clipRange = base.panel.clipRange;
		clipRange.x -= CKAFNIAKKIF.x;
		clipRange.y -= CKAFNIAKKIF.y;
		base.panel.clipRange = clipRange;
		UpdateScrollbars(recalculateBounds: true);
	}

	public virtual void NPHEDAFHFBB(Vector3 CKAFNIAKKIF)
	{
		if (JOPLDCDHCAF == null)
		{
			base.MoveRelative(CKAFNIAKKIF);
			return;
		}
		mTrans.localPosition += CKAFNIAKKIF;
		JOPLDCDHCAF.localPosition += CKAFNIAKKIF * HMNLFKFGEPD;
		Vector4 clipRange = base.panel.clipRange;
		clipRange.x -= CKAFNIAKKIF.x;
		clipRange.y -= CKAFNIAKKIF.y;
		base.panel.clipRange = clipRange;
		UpdateScrollbars(recalculateBounds: true);
	}

	public virtual void HDGDFMMOHGK(Vector3 CKAFNIAKKIF)
	{
		if (JOPLDCDHCAF == null)
		{
			base.MoveRelative(CKAFNIAKKIF);
			return;
		}
		mTrans.localPosition += CKAFNIAKKIF;
		JOPLDCDHCAF.localPosition += CKAFNIAKKIF * HMNLFKFGEPD;
		Vector4 clipRange = base.panel.clipRange;
		clipRange.x -= CKAFNIAKKIF.x;
		clipRange.y -= CKAFNIAKKIF.y;
		base.panel.clipRange = clipRange;
		UpdateScrollbars(recalculateBounds: false);
	}

	public virtual void GAIBNDAEFCF(Vector3 CKAFNIAKKIF)
	{
		if (JOPLDCDHCAF == null)
		{
			base.MoveRelative(CKAFNIAKKIF);
			return;
		}
		mTrans.localPosition += CKAFNIAKKIF;
		JOPLDCDHCAF.localPosition += CKAFNIAKKIF * HMNLFKFGEPD;
		Vector4 clipRange = base.panel.clipRange;
		clipRange.x -= CKAFNIAKKIF.x;
		clipRange.y -= CKAFNIAKKIF.y;
		base.panel.clipRange = clipRange;
		UpdateScrollbars(recalculateBounds: false);
	}

	public virtual void NBIDKNGDCMM(Vector3 CKAFNIAKKIF)
	{
		if (JOPLDCDHCAF == null)
		{
			base.MoveRelative(CKAFNIAKKIF);
			return;
		}
		mTrans.localPosition += CKAFNIAKKIF;
		JOPLDCDHCAF.localPosition += CKAFNIAKKIF * HMNLFKFGEPD;
		Vector4 clipRange = base.panel.clipRange;
		clipRange.x -= CKAFNIAKKIF.x;
		clipRange.y -= CKAFNIAKKIF.y;
		base.panel.clipRange = clipRange;
		UpdateScrollbars(recalculateBounds: false);
	}

	public virtual void CPEMCMGFBIO(Vector3 CKAFNIAKKIF)
	{
		if (JOPLDCDHCAF == null)
		{
			base.MoveRelative(CKAFNIAKKIF);
			return;
		}
		mTrans.localPosition += CKAFNIAKKIF;
		JOPLDCDHCAF.localPosition += CKAFNIAKKIF * HMNLFKFGEPD;
		Vector4 clipRange = base.panel.clipRange;
		clipRange.x -= CKAFNIAKKIF.x;
		clipRange.y -= CKAFNIAKKIF.y;
		base.panel.clipRange = clipRange;
		UpdateScrollbars(recalculateBounds: true);
	}

	public virtual void HBKAJDEKELP(Vector3 CKAFNIAKKIF)
	{
		if (JOPLDCDHCAF == null)
		{
			base.MoveRelative(CKAFNIAKKIF);
			return;
		}
		mTrans.localPosition += CKAFNIAKKIF;
		JOPLDCDHCAF.localPosition += CKAFNIAKKIF * HMNLFKFGEPD;
		Vector4 clipRange = base.panel.clipRange;
		clipRange.x -= CKAFNIAKKIF.x;
		clipRange.y -= CKAFNIAKKIF.y;
		base.panel.clipRange = clipRange;
		UpdateScrollbars(recalculateBounds: false);
	}

	public virtual void EJCIODBDAAC(Vector3 CKAFNIAKKIF)
	{
		if (JOPLDCDHCAF == null)
		{
			base.MoveRelative(CKAFNIAKKIF);
			return;
		}
		mTrans.localPosition += CKAFNIAKKIF;
		JOPLDCDHCAF.localPosition += CKAFNIAKKIF * HMNLFKFGEPD;
		Vector4 clipRange = base.panel.clipRange;
		clipRange.x -= CKAFNIAKKIF.x;
		clipRange.y -= CKAFNIAKKIF.y;
		base.panel.clipRange = clipRange;
		UpdateScrollbars(recalculateBounds: true);
	}

	public virtual void AKOOFCFDDNB(Vector3 CKAFNIAKKIF)
	{
		if (JOPLDCDHCAF == null)
		{
			base.MoveRelative(CKAFNIAKKIF);
			return;
		}
		mTrans.localPosition += CKAFNIAKKIF;
		JOPLDCDHCAF.localPosition += CKAFNIAKKIF * HMNLFKFGEPD;
		Vector4 clipRange = base.panel.clipRange;
		clipRange.x -= CKAFNIAKKIF.x;
		clipRange.y -= CKAFNIAKKIF.y;
		base.panel.clipRange = clipRange;
		UpdateScrollbars(recalculateBounds: true);
	}

	public virtual void BCBGHICONHJ(Vector3 CKAFNIAKKIF)
	{
		if (JOPLDCDHCAF == null)
		{
			base.MoveRelative(CKAFNIAKKIF);
			return;
		}
		mTrans.localPosition += CKAFNIAKKIF;
		JOPLDCDHCAF.localPosition += CKAFNIAKKIF * HMNLFKFGEPD;
		Vector4 clipRange = base.panel.clipRange;
		clipRange.x -= CKAFNIAKKIF.x;
		clipRange.y -= CKAFNIAKKIF.y;
		base.panel.clipRange = clipRange;
		UpdateScrollbars(recalculateBounds: false);
	}

	public virtual void JCHNFKOKDMI(Vector3 CKAFNIAKKIF)
	{
		if (JOPLDCDHCAF == null)
		{
			base.MoveRelative(CKAFNIAKKIF);
			return;
		}
		mTrans.localPosition += CKAFNIAKKIF;
		JOPLDCDHCAF.localPosition += CKAFNIAKKIF * HMNLFKFGEPD;
		Vector4 clipRange = base.panel.clipRange;
		clipRange.x -= CKAFNIAKKIF.x;
		clipRange.y -= CKAFNIAKKIF.y;
		base.panel.clipRange = clipRange;
		UpdateScrollbars(recalculateBounds: false);
	}

	public virtual void BDFFFMLCOCP(Vector3 CKAFNIAKKIF)
	{
		if (JOPLDCDHCAF == null)
		{
			base.MoveRelative(CKAFNIAKKIF);
			return;
		}
		mTrans.localPosition += CKAFNIAKKIF;
		JOPLDCDHCAF.localPosition += CKAFNIAKKIF * HMNLFKFGEPD;
		Vector4 clipRange = base.panel.clipRange;
		clipRange.x -= CKAFNIAKKIF.x;
		clipRange.y -= CKAFNIAKKIF.y;
		base.panel.clipRange = clipRange;
		UpdateScrollbars(recalculateBounds: true);
	}

	public virtual void EPAFHAFHAGG(Vector3 CKAFNIAKKIF)
	{
		if (JOPLDCDHCAF == null)
		{
			base.MoveRelative(CKAFNIAKKIF);
			return;
		}
		mTrans.localPosition += CKAFNIAKKIF;
		JOPLDCDHCAF.localPosition += CKAFNIAKKIF * HMNLFKFGEPD;
		Vector4 clipRange = base.panel.clipRange;
		clipRange.x -= CKAFNIAKKIF.x;
		clipRange.y -= CKAFNIAKKIF.y;
		base.panel.clipRange = clipRange;
		UpdateScrollbars(recalculateBounds: true);
	}

	public virtual void KALHNIDJBEG(Vector3 CKAFNIAKKIF)
	{
		if (JOPLDCDHCAF == null)
		{
			base.MoveRelative(CKAFNIAKKIF);
			return;
		}
		mTrans.localPosition += CKAFNIAKKIF;
		JOPLDCDHCAF.localPosition += CKAFNIAKKIF * HMNLFKFGEPD;
		Vector4 clipRange = base.panel.clipRange;
		clipRange.x -= CKAFNIAKKIF.x;
		clipRange.y -= CKAFNIAKKIF.y;
		base.panel.clipRange = clipRange;
		UpdateScrollbars(recalculateBounds: false);
	}

	public virtual void BNPEAHIEPPP(Vector3 CKAFNIAKKIF)
	{
		if (JOPLDCDHCAF == null)
		{
			base.MoveRelative(CKAFNIAKKIF);
			return;
		}
		mTrans.localPosition += CKAFNIAKKIF;
		JOPLDCDHCAF.localPosition += CKAFNIAKKIF * HMNLFKFGEPD;
		Vector4 clipRange = base.panel.clipRange;
		clipRange.x -= CKAFNIAKKIF.x;
		clipRange.y -= CKAFNIAKKIF.y;
		base.panel.clipRange = clipRange;
		UpdateScrollbars(recalculateBounds: false);
	}

	public virtual void BHFMGJDEPOL(Vector3 CKAFNIAKKIF)
	{
		if (JOPLDCDHCAF == null)
		{
			base.MoveRelative(CKAFNIAKKIF);
			return;
		}
		mTrans.localPosition += CKAFNIAKKIF;
		JOPLDCDHCAF.localPosition += CKAFNIAKKIF * HMNLFKFGEPD;
		Vector4 clipRange = base.panel.clipRange;
		clipRange.x -= CKAFNIAKKIF.x;
		clipRange.y -= CKAFNIAKKIF.y;
		base.panel.clipRange = clipRange;
		UpdateScrollbars(recalculateBounds: true);
	}

	public virtual void LNNBGIAKIED(Vector3 CKAFNIAKKIF)
	{
		if (JOPLDCDHCAF == null)
		{
			base.MoveRelative(CKAFNIAKKIF);
			return;
		}
		mTrans.localPosition += CKAFNIAKKIF;
		JOPLDCDHCAF.localPosition += CKAFNIAKKIF * HMNLFKFGEPD;
		Vector4 clipRange = base.panel.clipRange;
		clipRange.x -= CKAFNIAKKIF.x;
		clipRange.y -= CKAFNIAKKIF.y;
		base.panel.clipRange = clipRange;
		UpdateScrollbars(recalculateBounds: false);
	}

	public virtual void OJKHJDDGABB(Vector3 CKAFNIAKKIF)
	{
		if (JOPLDCDHCAF == null)
		{
			base.MoveRelative(CKAFNIAKKIF);
			return;
		}
		mTrans.localPosition += CKAFNIAKKIF;
		JOPLDCDHCAF.localPosition += CKAFNIAKKIF * HMNLFKFGEPD;
		Vector4 clipRange = base.panel.clipRange;
		clipRange.x -= CKAFNIAKKIF.x;
		clipRange.y -= CKAFNIAKKIF.y;
		base.panel.clipRange = clipRange;
		UpdateScrollbars(recalculateBounds: false);
	}

	public virtual void PPGPMJBLLLI(Vector3 CKAFNIAKKIF)
	{
		if (JOPLDCDHCAF == null)
		{
			base.MoveRelative(CKAFNIAKKIF);
			return;
		}
		mTrans.localPosition += CKAFNIAKKIF;
		JOPLDCDHCAF.localPosition += CKAFNIAKKIF * HMNLFKFGEPD;
		Vector4 clipRange = base.panel.clipRange;
		clipRange.x -= CKAFNIAKKIF.x;
		clipRange.y -= CKAFNIAKKIF.y;
		base.panel.clipRange = clipRange;
		UpdateScrollbars(recalculateBounds: true);
	}

	public virtual void MNPNKAENIGE(Vector3 CKAFNIAKKIF)
	{
		if (JOPLDCDHCAF == null)
		{
			base.MoveRelative(CKAFNIAKKIF);
			return;
		}
		mTrans.localPosition += CKAFNIAKKIF;
		JOPLDCDHCAF.localPosition += CKAFNIAKKIF * HMNLFKFGEPD;
		Vector4 clipRange = base.panel.clipRange;
		clipRange.x -= CKAFNIAKKIF.x;
		clipRange.y -= CKAFNIAKKIF.y;
		base.panel.clipRange = clipRange;
		UpdateScrollbars(recalculateBounds: false);
	}

	public virtual void OFCPLMAGPCM(Vector3 CKAFNIAKKIF)
	{
		if (JOPLDCDHCAF == null)
		{
			base.MoveRelative(CKAFNIAKKIF);
			return;
		}
		mTrans.localPosition += CKAFNIAKKIF;
		JOPLDCDHCAF.localPosition += CKAFNIAKKIF * HMNLFKFGEPD;
		Vector4 clipRange = base.panel.clipRange;
		clipRange.x -= CKAFNIAKKIF.x;
		clipRange.y -= CKAFNIAKKIF.y;
		base.panel.clipRange = clipRange;
		UpdateScrollbars(recalculateBounds: false);
	}

	public virtual void EFALPLJFMBP(Vector3 CKAFNIAKKIF)
	{
		if (JOPLDCDHCAF == null)
		{
			base.MoveRelative(CKAFNIAKKIF);
			return;
		}
		mTrans.localPosition += CKAFNIAKKIF;
		JOPLDCDHCAF.localPosition += CKAFNIAKKIF * HMNLFKFGEPD;
		Vector4 clipRange = base.panel.clipRange;
		clipRange.x -= CKAFNIAKKIF.x;
		clipRange.y -= CKAFNIAKKIF.y;
		base.panel.clipRange = clipRange;
		UpdateScrollbars(recalculateBounds: true);
	}

	public virtual void GFOGKCNGNFL(Vector3 CKAFNIAKKIF)
	{
		if (JOPLDCDHCAF == null)
		{
			base.MoveRelative(CKAFNIAKKIF);
			return;
		}
		mTrans.localPosition += CKAFNIAKKIF;
		JOPLDCDHCAF.localPosition += CKAFNIAKKIF * HMNLFKFGEPD;
		Vector4 clipRange = base.panel.clipRange;
		clipRange.x -= CKAFNIAKKIF.x;
		clipRange.y -= CKAFNIAKKIF.y;
		base.panel.clipRange = clipRange;
		UpdateScrollbars(recalculateBounds: false);
	}

	public virtual void FPNIAADKGEJ(Vector3 CKAFNIAKKIF)
	{
		if (JOPLDCDHCAF == null)
		{
			base.MoveRelative(CKAFNIAKKIF);
			return;
		}
		mTrans.localPosition += CKAFNIAKKIF;
		JOPLDCDHCAF.localPosition += CKAFNIAKKIF * HMNLFKFGEPD;
		Vector4 clipRange = base.panel.clipRange;
		clipRange.x -= CKAFNIAKKIF.x;
		clipRange.y -= CKAFNIAKKIF.y;
		base.panel.clipRange = clipRange;
		UpdateScrollbars(recalculateBounds: true);
	}

	public virtual void MHJIILBDBCK(Vector3 CKAFNIAKKIF)
	{
		if (JOPLDCDHCAF == null)
		{
			base.MoveRelative(CKAFNIAKKIF);
			return;
		}
		mTrans.localPosition += CKAFNIAKKIF;
		JOPLDCDHCAF.localPosition += CKAFNIAKKIF * HMNLFKFGEPD;
		Vector4 clipRange = base.panel.clipRange;
		clipRange.x -= CKAFNIAKKIF.x;
		clipRange.y -= CKAFNIAKKIF.y;
		base.panel.clipRange = clipRange;
		UpdateScrollbars(recalculateBounds: false);
	}

	public virtual void NGKIGKMCADG(Vector3 CKAFNIAKKIF)
	{
		if (JOPLDCDHCAF == null)
		{
			base.MoveRelative(CKAFNIAKKIF);
			return;
		}
		mTrans.localPosition += CKAFNIAKKIF;
		JOPLDCDHCAF.localPosition += CKAFNIAKKIF * HMNLFKFGEPD;
		Vector4 clipRange = base.panel.clipRange;
		clipRange.x -= CKAFNIAKKIF.x;
		clipRange.y -= CKAFNIAKKIF.y;
		base.panel.clipRange = clipRange;
		UpdateScrollbars(recalculateBounds: false);
	}

	public virtual void JGDCDBDBJNA(Vector3 CKAFNIAKKIF)
	{
		if (JOPLDCDHCAF == null)
		{
			base.MoveRelative(CKAFNIAKKIF);
			return;
		}
		mTrans.localPosition += CKAFNIAKKIF;
		JOPLDCDHCAF.localPosition += CKAFNIAKKIF * HMNLFKFGEPD;
		Vector4 clipRange = base.panel.clipRange;
		clipRange.x -= CKAFNIAKKIF.x;
		clipRange.y -= CKAFNIAKKIF.y;
		base.panel.clipRange = clipRange;
		UpdateScrollbars(recalculateBounds: true);
	}

	public virtual void ENEMFIBLDFP(Vector3 CKAFNIAKKIF)
	{
		if (JOPLDCDHCAF == null)
		{
			base.MoveRelative(CKAFNIAKKIF);
			return;
		}
		mTrans.localPosition += CKAFNIAKKIF;
		JOPLDCDHCAF.localPosition += CKAFNIAKKIF * HMNLFKFGEPD;
		Vector4 clipRange = base.panel.clipRange;
		clipRange.x -= CKAFNIAKKIF.x;
		clipRange.y -= CKAFNIAKKIF.y;
		base.panel.clipRange = clipRange;
		UpdateScrollbars(recalculateBounds: false);
	}

	public virtual void EMCFLKLGFCC(Vector3 CKAFNIAKKIF)
	{
		if (JOPLDCDHCAF == null)
		{
			base.MoveRelative(CKAFNIAKKIF);
			return;
		}
		mTrans.localPosition += CKAFNIAKKIF;
		JOPLDCDHCAF.localPosition += CKAFNIAKKIF * HMNLFKFGEPD;
		Vector4 clipRange = base.panel.clipRange;
		clipRange.x -= CKAFNIAKKIF.x;
		clipRange.y -= CKAFNIAKKIF.y;
		base.panel.clipRange = clipRange;
		UpdateScrollbars(recalculateBounds: true);
	}

	public virtual void EACHKPINCBI(Vector3 CKAFNIAKKIF)
	{
		if (JOPLDCDHCAF == null)
		{
			base.MoveRelative(CKAFNIAKKIF);
			return;
		}
		mTrans.localPosition += CKAFNIAKKIF;
		JOPLDCDHCAF.localPosition += CKAFNIAKKIF * HMNLFKFGEPD;
		Vector4 clipRange = base.panel.clipRange;
		clipRange.x -= CKAFNIAKKIF.x;
		clipRange.y -= CKAFNIAKKIF.y;
		base.panel.clipRange = clipRange;
		UpdateScrollbars(recalculateBounds: false);
	}

	public override void MoveRelative(Vector3 CKAFNIAKKIF)
	{
		if (JOPLDCDHCAF == null)
		{
			base.MoveRelative(CKAFNIAKKIF);
			return;
		}
		mTrans.localPosition += CKAFNIAKKIF;
		JOPLDCDHCAF.localPosition += CKAFNIAKKIF * HMNLFKFGEPD;
		Vector4 clipRange = base.panel.clipRange;
		clipRange.x -= CKAFNIAKKIF.x;
		clipRange.y -= CKAFNIAKKIF.y;
		base.panel.clipRange = clipRange;
		UpdateScrollbars(recalculateBounds: false);
	}

	public virtual void FDGJOPODECH(Vector3 CKAFNIAKKIF)
	{
		if (JOPLDCDHCAF == null)
		{
			base.MoveRelative(CKAFNIAKKIF);
			return;
		}
		mTrans.localPosition += CKAFNIAKKIF;
		JOPLDCDHCAF.localPosition += CKAFNIAKKIF * HMNLFKFGEPD;
		Vector4 clipRange = base.panel.clipRange;
		clipRange.x -= CKAFNIAKKIF.x;
		clipRange.y -= CKAFNIAKKIF.y;
		base.panel.clipRange = clipRange;
		UpdateScrollbars(recalculateBounds: true);
	}

	public virtual void MBEGPDDLMEB(Vector3 CKAFNIAKKIF)
	{
		if (JOPLDCDHCAF == null)
		{
			base.MoveRelative(CKAFNIAKKIF);
			return;
		}
		mTrans.localPosition += CKAFNIAKKIF;
		JOPLDCDHCAF.localPosition += CKAFNIAKKIF * HMNLFKFGEPD;
		Vector4 clipRange = base.panel.clipRange;
		clipRange.x -= CKAFNIAKKIF.x;
		clipRange.y -= CKAFNIAKKIF.y;
		base.panel.clipRange = clipRange;
		UpdateScrollbars(recalculateBounds: true);
	}

	public virtual void AGKKOHJJCGM(Vector3 CKAFNIAKKIF)
	{
		if (JOPLDCDHCAF == null)
		{
			base.MoveRelative(CKAFNIAKKIF);
			return;
		}
		mTrans.localPosition += CKAFNIAKKIF;
		JOPLDCDHCAF.localPosition += CKAFNIAKKIF * HMNLFKFGEPD;
		Vector4 clipRange = base.panel.clipRange;
		clipRange.x -= CKAFNIAKKIF.x;
		clipRange.y -= CKAFNIAKKIF.y;
		base.panel.clipRange = clipRange;
		UpdateScrollbars(recalculateBounds: false);
	}

	public virtual void GNKCLBMMNEO(Vector3 CKAFNIAKKIF)
	{
		if (JOPLDCDHCAF == null)
		{
			base.MoveRelative(CKAFNIAKKIF);
			return;
		}
		mTrans.localPosition += CKAFNIAKKIF;
		JOPLDCDHCAF.localPosition += CKAFNIAKKIF * HMNLFKFGEPD;
		Vector4 clipRange = base.panel.clipRange;
		clipRange.x -= CKAFNIAKKIF.x;
		clipRange.y -= CKAFNIAKKIF.y;
		base.panel.clipRange = clipRange;
		UpdateScrollbars(recalculateBounds: false);
	}
}
