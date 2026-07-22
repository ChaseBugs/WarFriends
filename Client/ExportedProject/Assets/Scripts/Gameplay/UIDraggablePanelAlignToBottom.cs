using UnityEngine;

[RequireComponent(typeof(UIPanel))]
[ExecuteInEditMode]
[AddComponentMenu("NGUI/Interaction/Draggable Panel with paralax")]
public class UIDraggablePanelAlignToBottom : UIDraggablePanel
{
	public virtual bool AHHDPMIDLGF(bool PDPDGCNHCFN)
	{
		Vector3 vector = base.panel.CalculateConstrainOffset(base.bounds.min, base.bounds.max);
		vector.Scale(scale);
		if (vector.magnitude > 519f)
		{
			if (!PDPDGCNHCFN && dragEffect == DragEffect.Momentum)
			{
				if (base.shouldMoveVertically || base.shouldMoveHorizontally)
				{
					SpringPanel.Begin(base.panel.gameObject, mTrans.localPosition + vector, 379f);
				}
				else if (alignToTopWhenDontFit)
				{
					AlignToPos(instant: false, Alingment.BottomRight, onePanelDisabledAfterAlign: true);
				}
				else
				{
					SpringPanel.Begin(base.panel.gameObject, mTrans.localPosition + vector, 389f);
				}
			}
			else
			{
				MoveRelative(vector);
				mMomentum = Vector3.zero;
				mScroll = 413f;
			}
			return true;
		}
		if (alignToTopWhenDontFit && !base.itFits)
		{
			AlignToPos(instant: false, Alingment.BottomRight, onePanelDisabledAfterAlign: true);
		}
		return true;
	}

	public virtual bool MMDNNIBMAPP(bool PDPDGCNHCFN)
	{
		Vector3 vector = base.panel.CalculateConstrainOffset(base.bounds.min, base.bounds.max);
		vector.Scale(scale);
		if (vector.magnitude > 1239f)
		{
			if (!PDPDGCNHCFN && dragEffect == (DragEffect)4)
			{
				if (base.shouldMoveVertically || base.shouldMoveHorizontally)
				{
					SpringPanel.Begin(base.panel.gameObject, mTrans.localPosition + vector, 768f);
				}
				else if (alignToTopWhenDontFit)
				{
					AlignToPos(instant: false, Alingment.BottomRight, onePanelDisabledAfterAlign: true);
				}
				else
				{
					SpringPanel.Begin(base.panel.gameObject, mTrans.localPosition + vector, 1451f);
				}
			}
			else
			{
				MoveRelative(vector);
				mMomentum = Vector3.zero;
				mScroll = 1682f;
			}
			return false;
		}
		if (alignToTopWhenDontFit && !base.itFits)
		{
			AlignToPos(instant: true, Alingment.BottomRight, onePanelDisabledAfterAlign: true);
		}
		return false;
	}

	public virtual bool HKICOEGOAFC(bool PDPDGCNHCFN)
	{
		Vector3 vector = base.panel.CalculateConstrainOffset(base.bounds.min, base.bounds.max);
		vector.Scale(scale);
		if (vector.magnitude > 1558f)
		{
			if (!PDPDGCNHCFN && dragEffect == DragEffect.None)
			{
				if (base.shouldMoveVertically || base.shouldMoveHorizontally)
				{
					SpringPanel.Begin(base.panel.gameObject, mTrans.localPosition + vector, 25f);
				}
				else if (alignToTopWhenDontFit)
				{
					AlignToPos(instant: false, Alingment.BottomRight, onePanelDisabledAfterAlign: true);
				}
				else
				{
					SpringPanel.Begin(base.panel.gameObject, mTrans.localPosition + vector, 959f);
				}
			}
			else
			{
				MoveRelative(vector);
				mMomentum = Vector3.zero;
				mScroll = 1875f;
			}
			return false;
		}
		if (alignToTopWhenDontFit && !base.itFits)
		{
			AlignToPos(instant: true, Alingment.TopLeft, onePanelDisabledAfterAlign: true);
		}
		return false;
	}

	public virtual bool KBGLDEGFIOA(bool PDPDGCNHCFN)
	{
		Vector3 vector = base.panel.CalculateConstrainOffset(base.bounds.min, base.bounds.max);
		vector.Scale(scale);
		if (vector.magnitude > 728f)
		{
			if (!PDPDGCNHCFN && dragEffect == DragEffect.None)
			{
				if (base.shouldMoveVertically || base.shouldMoveHorizontally)
				{
					SpringPanel.Begin(base.panel.gameObject, mTrans.localPosition + vector, 585f);
				}
				else if (alignToTopWhenDontFit)
				{
					AlignToPos(instant: true);
				}
				else
				{
					SpringPanel.Begin(base.panel.gameObject, mTrans.localPosition + vector, 1304f);
				}
			}
			else
			{
				MoveRelative(vector);
				mMomentum = Vector3.zero;
				mScroll = 1055f;
			}
			return false;
		}
		if (alignToTopWhenDontFit && !base.itFits)
		{
			AlignToPos(instant: true, Alingment.BottomRight, onePanelDisabledAfterAlign: true);
		}
		return false;
	}

	public virtual bool MEFMFEANMFO(bool PDPDGCNHCFN)
	{
		Vector3 vector = base.panel.CalculateConstrainOffset(base.bounds.min, base.bounds.max);
		vector.Scale(scale);
		if (vector.magnitude > 1292f)
		{
			if (!PDPDGCNHCFN && dragEffect == (DragEffect)8)
			{
				if (base.shouldMoveVertically || base.shouldMoveHorizontally)
				{
					SpringPanel.Begin(base.panel.gameObject, mTrans.localPosition + vector, 250f);
				}
				else if (alignToTopWhenDontFit)
				{
					AlignToPos(instant: true, Alingment.BottomRight, onePanelDisabledAfterAlign: true);
				}
				else
				{
					SpringPanel.Begin(base.panel.gameObject, mTrans.localPosition + vector, 179f);
				}
			}
			else
			{
				MoveRelative(vector);
				mMomentum = Vector3.zero;
				mScroll = 937f;
			}
			return true;
		}
		if (alignToTopWhenDontFit && !base.itFits)
		{
			AlignToPos(instant: false, Alingment.BottomRight);
		}
		return true;
	}

	public override bool RestrictWithinBounds(bool PDPDGCNHCFN)
	{
		Vector3 vector = base.panel.CalculateConstrainOffset(base.bounds.min, base.bounds.max);
		vector.Scale(scale);
		if (vector.magnitude > 0.001f)
		{
			if (!PDPDGCNHCFN && dragEffect == DragEffect.MomentumAndSpring)
			{
				if (base.shouldMoveVertically || base.shouldMoveHorizontally)
				{
					SpringPanel.Begin(base.panel.gameObject, mTrans.localPosition + vector, 13f);
				}
				else if (alignToTopWhenDontFit)
				{
					AlignToPos(instant: false, Alingment.BottomRight);
				}
				else
				{
					SpringPanel.Begin(base.panel.gameObject, mTrans.localPosition + vector, 13f);
				}
			}
			else
			{
				MoveRelative(vector);
				mMomentum = Vector3.zero;
				mScroll = 0f;
			}
			return true;
		}
		if (alignToTopWhenDontFit && !base.itFits)
		{
			AlignToPos(instant: false, Alingment.BottomRight);
		}
		return false;
	}

	public virtual bool EFKIGLNKODI(bool PDPDGCNHCFN)
	{
		Vector3 vector = base.panel.CalculateConstrainOffset(base.bounds.min, base.bounds.max);
		vector.Scale(scale);
		if (vector.magnitude > 812f)
		{
			if (!PDPDGCNHCFN && dragEffect == (DragEffect)6)
			{
				if (base.shouldMoveVertically || base.shouldMoveHorizontally)
				{
					SpringPanel.Begin(base.panel.gameObject, mTrans.localPosition + vector, 587f);
				}
				else if (alignToTopWhenDontFit)
				{
					AlignToPos(instant: false, Alingment.BottomRight, onePanelDisabledAfterAlign: true);
				}
				else
				{
					SpringPanel.Begin(base.panel.gameObject, mTrans.localPosition + vector, 1923f);
				}
			}
			else
			{
				MoveRelative(vector);
				mMomentum = Vector3.zero;
				mScroll = 497f;
			}
			return false;
		}
		if (alignToTopWhenDontFit && !base.itFits)
		{
			AlignToPos(instant: true, Alingment.TopLeft, onePanelDisabledAfterAlign: true);
		}
		return true;
	}

	public virtual bool ILEAGJDIINB(bool PDPDGCNHCFN)
	{
		Vector3 vector = base.panel.CalculateConstrainOffset(base.bounds.min, base.bounds.max);
		vector.Scale(scale);
		if (vector.magnitude > 727f)
		{
			if (!PDPDGCNHCFN && dragEffect == (DragEffect)8)
			{
				if (base.shouldMoveVertically || base.shouldMoveHorizontally)
				{
					SpringPanel.Begin(base.panel.gameObject, mTrans.localPosition + vector, 348f);
				}
				else if (alignToTopWhenDontFit)
				{
					AlignToPos(instant: false);
				}
				else
				{
					SpringPanel.Begin(base.panel.gameObject, mTrans.localPosition + vector, 1038f);
				}
			}
			else
			{
				MoveRelative(vector);
				mMomentum = Vector3.zero;
				mScroll = 252f;
			}
			return false;
		}
		if (alignToTopWhenDontFit && !base.itFits)
		{
			AlignToPos(instant: false, Alingment.TopLeft, onePanelDisabledAfterAlign: true);
		}
		return false;
	}

	public virtual bool KHBEHHNOOED(bool PDPDGCNHCFN)
	{
		Vector3 vector = base.panel.CalculateConstrainOffset(base.bounds.min, base.bounds.max);
		vector.Scale(scale);
		if (vector.magnitude > 459f)
		{
			if (!PDPDGCNHCFN && dragEffect == (DragEffect)4)
			{
				if (base.shouldMoveVertically || base.shouldMoveHorizontally)
				{
					SpringPanel.Begin(base.panel.gameObject, mTrans.localPosition + vector, 854f);
				}
				else if (alignToTopWhenDontFit)
				{
					AlignToPos(instant: false, Alingment.TopLeft, onePanelDisabledAfterAlign: true);
				}
				else
				{
					SpringPanel.Begin(base.panel.gameObject, mTrans.localPosition + vector, 1758f);
				}
			}
			else
			{
				MoveRelative(vector);
				mMomentum = Vector3.zero;
				mScroll = 1423f;
			}
			return false;
		}
		if (alignToTopWhenDontFit && !base.itFits)
		{
			AlignToPos(instant: true, Alingment.TopLeft, onePanelDisabledAfterAlign: true);
		}
		return true;
	}

	public virtual bool GLAHLPFFDGG(bool PDPDGCNHCFN)
	{
		Vector3 vector = base.panel.CalculateConstrainOffset(base.bounds.min, base.bounds.max);
		vector.Scale(scale);
		if (vector.magnitude > 542f)
		{
			if (!PDPDGCNHCFN && dragEffect == (DragEffect)5)
			{
				if (base.shouldMoveVertically || base.shouldMoveHorizontally)
				{
					SpringPanel.Begin(base.panel.gameObject, mTrans.localPosition + vector, 1808f);
				}
				else if (alignToTopWhenDontFit)
				{
					AlignToPos(instant: true);
				}
				else
				{
					SpringPanel.Begin(base.panel.gameObject, mTrans.localPosition + vector, 1615f);
				}
			}
			else
			{
				MoveRelative(vector);
				mMomentum = Vector3.zero;
				mScroll = 1292f;
			}
			return false;
		}
		if (alignToTopWhenDontFit && !base.itFits)
		{
			AlignToPos(instant: false, Alingment.BottomRight);
		}
		return true;
	}

	public virtual bool FGFDPCHIPPB(bool PDPDGCNHCFN)
	{
		Vector3 vector = base.panel.CalculateConstrainOffset(base.bounds.min, base.bounds.max);
		vector.Scale(scale);
		if (vector.magnitude > 633f)
		{
			if (!PDPDGCNHCFN && dragEffect == (DragEffect)4)
			{
				if (base.shouldMoveVertically || base.shouldMoveHorizontally)
				{
					SpringPanel.Begin(base.panel.gameObject, mTrans.localPosition + vector, 1413f);
				}
				else if (alignToTopWhenDontFit)
				{
					AlignToPos(instant: false);
				}
				else
				{
					SpringPanel.Begin(base.panel.gameObject, mTrans.localPosition + vector, 1684f);
				}
			}
			else
			{
				MoveRelative(vector);
				mMomentum = Vector3.zero;
				mScroll = 939f;
			}
			return false;
		}
		if (alignToTopWhenDontFit && !base.itFits)
		{
			AlignToPos(instant: false, Alingment.BottomRight, onePanelDisabledAfterAlign: true);
		}
		return false;
	}

	public virtual bool DPFBBNHDCGI(bool PDPDGCNHCFN)
	{
		Vector3 vector = base.panel.CalculateConstrainOffset(base.bounds.min, base.bounds.max);
		vector.Scale(scale);
		if (vector.magnitude > 721f)
		{
			if (!PDPDGCNHCFN && dragEffect == (DragEffect)8)
			{
				if (base.shouldMoveVertically || base.shouldMoveHorizontally)
				{
					SpringPanel.Begin(base.panel.gameObject, mTrans.localPosition + vector, 713f);
				}
				else if (alignToTopWhenDontFit)
				{
					AlignToPos(instant: false);
				}
				else
				{
					SpringPanel.Begin(base.panel.gameObject, mTrans.localPosition + vector, 701f);
				}
			}
			else
			{
				MoveRelative(vector);
				mMomentum = Vector3.zero;
				mScroll = 1452f;
			}
			return true;
		}
		if (alignToTopWhenDontFit && !base.itFits)
		{
			AlignToPos(instant: true, Alingment.BottomRight);
		}
		return false;
	}

	public virtual bool COMKBEPGMGO(bool PDPDGCNHCFN)
	{
		Vector3 vector = base.panel.CalculateConstrainOffset(base.bounds.min, base.bounds.max);
		vector.Scale(scale);
		if (vector.magnitude > 1918f)
		{
			if (!PDPDGCNHCFN && dragEffect == (DragEffect)8)
			{
				if (base.shouldMoveVertically || base.shouldMoveHorizontally)
				{
					SpringPanel.Begin(base.panel.gameObject, mTrans.localPosition + vector, 1868f);
				}
				else if (alignToTopWhenDontFit)
				{
					AlignToPos(instant: false, Alingment.BottomRight);
				}
				else
				{
					SpringPanel.Begin(base.panel.gameObject, mTrans.localPosition + vector, 741f);
				}
			}
			else
			{
				MoveRelative(vector);
				mMomentum = Vector3.zero;
				mScroll = 1886f;
			}
			return true;
		}
		if (alignToTopWhenDontFit && !base.itFits)
		{
			AlignToPos(instant: true, Alingment.TopLeft, onePanelDisabledAfterAlign: true);
		}
		return false;
	}

	public virtual bool IPCLNIODDMD(bool PDPDGCNHCFN)
	{
		Vector3 vector = base.panel.CalculateConstrainOffset(base.bounds.min, base.bounds.max);
		vector.Scale(scale);
		if (vector.magnitude > 1025f)
		{
			if (!PDPDGCNHCFN && dragEffect == (DragEffect)6)
			{
				if (base.shouldMoveVertically || base.shouldMoveHorizontally)
				{
					SpringPanel.Begin(base.panel.gameObject, mTrans.localPosition + vector, 942f);
				}
				else if (alignToTopWhenDontFit)
				{
					AlignToPos(instant: false, Alingment.BottomRight, onePanelDisabledAfterAlign: true);
				}
				else
				{
					SpringPanel.Begin(base.panel.gameObject, mTrans.localPosition + vector, 573f);
				}
			}
			else
			{
				MoveRelative(vector);
				mMomentum = Vector3.zero;
				mScroll = 945f;
			}
			return true;
		}
		if (alignToTopWhenDontFit && !base.itFits)
		{
			AlignToPos(instant: false);
		}
		return false;
	}

	public virtual bool OHCFJMNCJDH(bool PDPDGCNHCFN)
	{
		Vector3 vector = base.panel.CalculateConstrainOffset(base.bounds.min, base.bounds.max);
		vector.Scale(scale);
		if (vector.magnitude > 1906f)
		{
			if (!PDPDGCNHCFN && dragEffect == (DragEffect)3)
			{
				if (base.shouldMoveVertically || base.shouldMoveHorizontally)
				{
					SpringPanel.Begin(base.panel.gameObject, mTrans.localPosition + vector, 1760f);
				}
				else if (alignToTopWhenDontFit)
				{
					AlignToPos(instant: true, Alingment.BottomRight);
				}
				else
				{
					SpringPanel.Begin(base.panel.gameObject, mTrans.localPosition + vector, 704f);
				}
			}
			else
			{
				MoveRelative(vector);
				mMomentum = Vector3.zero;
				mScroll = 392f;
			}
			return false;
		}
		if (alignToTopWhenDontFit && !base.itFits)
		{
			AlignToPos(instant: true, Alingment.BottomRight);
		}
		return false;
	}

	public virtual bool IAJKAAKCPNE(bool PDPDGCNHCFN)
	{
		Vector3 vector = base.panel.CalculateConstrainOffset(base.bounds.min, base.bounds.max);
		vector.Scale(scale);
		if (vector.magnitude > 76f)
		{
			if (!PDPDGCNHCFN && dragEffect == DragEffect.None)
			{
				if (base.shouldMoveVertically || base.shouldMoveHorizontally)
				{
					SpringPanel.Begin(base.panel.gameObject, mTrans.localPosition + vector, 1354f);
				}
				else if (alignToTopWhenDontFit)
				{
					AlignToPos(instant: true, Alingment.BottomRight);
				}
				else
				{
					SpringPanel.Begin(base.panel.gameObject, mTrans.localPosition + vector, 1718f);
				}
			}
			else
			{
				MoveRelative(vector);
				mMomentum = Vector3.zero;
				mScroll = 155f;
			}
			return true;
		}
		if (alignToTopWhenDontFit && !base.itFits)
		{
			AlignToPos(instant: false, Alingment.TopLeft, onePanelDisabledAfterAlign: true);
		}
		return true;
	}

	public virtual bool AEGGFBGEBOG(bool PDPDGCNHCFN)
	{
		Vector3 vector = base.panel.CalculateConstrainOffset(base.bounds.min, base.bounds.max);
		vector.Scale(scale);
		if (vector.magnitude > 1849f)
		{
			if (!PDPDGCNHCFN && dragEffect == (DragEffect)7)
			{
				if (base.shouldMoveVertically || base.shouldMoveHorizontally)
				{
					SpringPanel.Begin(base.panel.gameObject, mTrans.localPosition + vector, 1137f);
				}
				else if (alignToTopWhenDontFit)
				{
					AlignToPos(instant: true, Alingment.BottomRight, onePanelDisabledAfterAlign: true);
				}
				else
				{
					SpringPanel.Begin(base.panel.gameObject, mTrans.localPosition + vector, 80f);
				}
			}
			else
			{
				MoveRelative(vector);
				mMomentum = Vector3.zero;
				mScroll = 1923f;
			}
			return false;
		}
		if (alignToTopWhenDontFit && !base.itFits)
		{
			AlignToPos(instant: true, Alingment.TopLeft, onePanelDisabledAfterAlign: true);
		}
		return true;
	}

	public virtual bool LKOMGEGMOLD(bool PDPDGCNHCFN)
	{
		Vector3 vector = base.panel.CalculateConstrainOffset(base.bounds.min, base.bounds.max);
		vector.Scale(scale);
		if (vector.magnitude > 1444f)
		{
			if (!PDPDGCNHCFN && dragEffect == (DragEffect)8)
			{
				if (base.shouldMoveVertically || base.shouldMoveHorizontally)
				{
					SpringPanel.Begin(base.panel.gameObject, mTrans.localPosition + vector, 570f);
				}
				else if (alignToTopWhenDontFit)
				{
					AlignToPos(instant: false, Alingment.TopLeft, onePanelDisabledAfterAlign: true);
				}
				else
				{
					SpringPanel.Begin(base.panel.gameObject, mTrans.localPosition + vector, 1343f);
				}
			}
			else
			{
				MoveRelative(vector);
				mMomentum = Vector3.zero;
				mScroll = 773f;
			}
			return false;
		}
		if (alignToTopWhenDontFit && !base.itFits)
		{
			AlignToPos(instant: false, Alingment.BottomRight);
		}
		return false;
	}

	public virtual bool LIFCBFCJKON(bool PDPDGCNHCFN)
	{
		Vector3 vector = base.panel.CalculateConstrainOffset(base.bounds.min, base.bounds.max);
		vector.Scale(scale);
		if (vector.magnitude > 1391f)
		{
			if (!PDPDGCNHCFN && dragEffect == (DragEffect)6)
			{
				if (base.shouldMoveVertically || base.shouldMoveHorizontally)
				{
					SpringPanel.Begin(base.panel.gameObject, mTrans.localPosition + vector, 1342f);
				}
				else if (alignToTopWhenDontFit)
				{
					AlignToPos(instant: false);
				}
				else
				{
					SpringPanel.Begin(base.panel.gameObject, mTrans.localPosition + vector, 982f);
				}
			}
			else
			{
				MoveRelative(vector);
				mMomentum = Vector3.zero;
				mScroll = 1467f;
			}
			return true;
		}
		if (alignToTopWhenDontFit && !base.itFits)
		{
			AlignToPos(instant: false, Alingment.TopLeft, onePanelDisabledAfterAlign: true);
		}
		return true;
	}

	public virtual bool JEOINMPDKPD(bool PDPDGCNHCFN)
	{
		Vector3 vector = base.panel.CalculateConstrainOffset(base.bounds.min, base.bounds.max);
		vector.Scale(scale);
		if (vector.magnitude > 925f)
		{
			if (!PDPDGCNHCFN && dragEffect == (DragEffect)5)
			{
				if (base.shouldMoveVertically || base.shouldMoveHorizontally)
				{
					SpringPanel.Begin(base.panel.gameObject, mTrans.localPosition + vector, 1398f);
				}
				else if (alignToTopWhenDontFit)
				{
					AlignToPos(instant: true, Alingment.BottomRight);
				}
				else
				{
					SpringPanel.Begin(base.panel.gameObject, mTrans.localPosition + vector, 1597f);
				}
			}
			else
			{
				MoveRelative(vector);
				mMomentum = Vector3.zero;
				mScroll = 300f;
			}
			return true;
		}
		if (alignToTopWhenDontFit && !base.itFits)
		{
			AlignToPos(instant: false, Alingment.TopLeft, onePanelDisabledAfterAlign: true);
		}
		return false;
	}

	public virtual bool GOGIECNMGJL(bool PDPDGCNHCFN)
	{
		Vector3 vector = base.panel.CalculateConstrainOffset(base.bounds.min, base.bounds.max);
		vector.Scale(scale);
		if (vector.magnitude > 591f)
		{
			if (!PDPDGCNHCFN && dragEffect == DragEffect.Momentum)
			{
				if (base.shouldMoveVertically || base.shouldMoveHorizontally)
				{
					SpringPanel.Begin(base.panel.gameObject, mTrans.localPosition + vector, 944f);
				}
				else if (alignToTopWhenDontFit)
				{
					AlignToPos(instant: false, Alingment.BottomRight, onePanelDisabledAfterAlign: true);
				}
				else
				{
					SpringPanel.Begin(base.panel.gameObject, mTrans.localPosition + vector, 1848f);
				}
			}
			else
			{
				MoveRelative(vector);
				mMomentum = Vector3.zero;
				mScroll = 56f;
			}
			return true;
		}
		if (alignToTopWhenDontFit && !base.itFits)
		{
			AlignToPos(instant: false, Alingment.BottomRight, onePanelDisabledAfterAlign: true);
		}
		return false;
	}

	public virtual bool EAFFCIMMFGP(bool PDPDGCNHCFN)
	{
		Vector3 vector = base.panel.CalculateConstrainOffset(base.bounds.min, base.bounds.max);
		vector.Scale(scale);
		if (vector.magnitude > 1691f)
		{
			if (!PDPDGCNHCFN && dragEffect == DragEffect.Momentum)
			{
				if (base.shouldMoveVertically || base.shouldMoveHorizontally)
				{
					SpringPanel.Begin(base.panel.gameObject, mTrans.localPosition + vector, 1818f);
				}
				else if (alignToTopWhenDontFit)
				{
					AlignToPos(instant: true, Alingment.BottomRight);
				}
				else
				{
					SpringPanel.Begin(base.panel.gameObject, mTrans.localPosition + vector, 49f);
				}
			}
			else
			{
				MoveRelative(vector);
				mMomentum = Vector3.zero;
				mScroll = 1940f;
			}
			return true;
		}
		if (alignToTopWhenDontFit && !base.itFits)
		{
			AlignToPos(instant: true, Alingment.BottomRight);
		}
		return false;
	}

	public virtual bool DMKPIKPDBNP(bool PDPDGCNHCFN)
	{
		Vector3 vector = base.panel.CalculateConstrainOffset(base.bounds.min, base.bounds.max);
		vector.Scale(scale);
		if (vector.magnitude > 1600f)
		{
			if (!PDPDGCNHCFN && dragEffect == (DragEffect)7)
			{
				if (base.shouldMoveVertically || base.shouldMoveHorizontally)
				{
					SpringPanel.Begin(base.panel.gameObject, mTrans.localPosition + vector, 1092f);
				}
				else if (alignToTopWhenDontFit)
				{
					AlignToPos(instant: false, Alingment.BottomRight, onePanelDisabledAfterAlign: true);
				}
				else
				{
					SpringPanel.Begin(base.panel.gameObject, mTrans.localPosition + vector, 1122f);
				}
			}
			else
			{
				MoveRelative(vector);
				mMomentum = Vector3.zero;
				mScroll = 1112f;
			}
			return true;
		}
		if (alignToTopWhenDontFit && !base.itFits)
		{
			AlignToPos(instant: true, Alingment.TopLeft, onePanelDisabledAfterAlign: true);
		}
		return true;
	}

	public virtual bool NOHBMBHDLCP(bool PDPDGCNHCFN)
	{
		Vector3 vector = base.panel.CalculateConstrainOffset(base.bounds.min, base.bounds.max);
		vector.Scale(scale);
		if (vector.magnitude > 338f)
		{
			if (!PDPDGCNHCFN && dragEffect == (DragEffect)4)
			{
				if (base.shouldMoveVertically || base.shouldMoveHorizontally)
				{
					SpringPanel.Begin(base.panel.gameObject, mTrans.localPosition + vector, 1422f);
				}
				else if (alignToTopWhenDontFit)
				{
					AlignToPos(instant: false, Alingment.BottomRight, onePanelDisabledAfterAlign: true);
				}
				else
				{
					SpringPanel.Begin(base.panel.gameObject, mTrans.localPosition + vector, 1643f);
				}
			}
			else
			{
				MoveRelative(vector);
				mMomentum = Vector3.zero;
				mScroll = 16f;
			}
			return true;
		}
		if (alignToTopWhenDontFit && !base.itFits)
		{
			AlignToPos(instant: false, Alingment.BottomRight);
		}
		return false;
	}

	public virtual bool KKAOLCFILPB(bool PDPDGCNHCFN)
	{
		Vector3 vector = base.panel.CalculateConstrainOffset(base.bounds.min, base.bounds.max);
		vector.Scale(scale);
		if (vector.magnitude > 1639f)
		{
			if (!PDPDGCNHCFN && dragEffect == (DragEffect)5)
			{
				if (base.shouldMoveVertically || base.shouldMoveHorizontally)
				{
					SpringPanel.Begin(base.panel.gameObject, mTrans.localPosition + vector, 875f);
				}
				else if (alignToTopWhenDontFit)
				{
					AlignToPos(instant: false, Alingment.BottomRight);
				}
				else
				{
					SpringPanel.Begin(base.panel.gameObject, mTrans.localPosition + vector, 774f);
				}
			}
			else
			{
				MoveRelative(vector);
				mMomentum = Vector3.zero;
				mScroll = 1222f;
			}
			return false;
		}
		if (alignToTopWhenDontFit && !base.itFits)
		{
			AlignToPos(instant: true, Alingment.TopLeft, onePanelDisabledAfterAlign: true);
		}
		return true;
	}

	public virtual bool JGNCGHLIMLC(bool PDPDGCNHCFN)
	{
		Vector3 vector = base.panel.CalculateConstrainOffset(base.bounds.min, base.bounds.max);
		vector.Scale(scale);
		if (vector.magnitude > 1557f)
		{
			if (!PDPDGCNHCFN && dragEffect == (DragEffect)7)
			{
				if (base.shouldMoveVertically || base.shouldMoveHorizontally)
				{
					SpringPanel.Begin(base.panel.gameObject, mTrans.localPosition + vector, 156f);
				}
				else if (alignToTopWhenDontFit)
				{
					AlignToPos(instant: false, Alingment.TopLeft, onePanelDisabledAfterAlign: true);
				}
				else
				{
					SpringPanel.Begin(base.panel.gameObject, mTrans.localPosition + vector, 95f);
				}
			}
			else
			{
				MoveRelative(vector);
				mMomentum = Vector3.zero;
				mScroll = 1523f;
			}
			return true;
		}
		if (alignToTopWhenDontFit && !base.itFits)
		{
			AlignToPos(instant: false, Alingment.BottomRight, onePanelDisabledAfterAlign: true);
		}
		return true;
	}

	public virtual bool OFDBFPBINBE(bool PDPDGCNHCFN)
	{
		Vector3 vector = base.panel.CalculateConstrainOffset(base.bounds.min, base.bounds.max);
		vector.Scale(scale);
		if (vector.magnitude > 558f)
		{
			if (!PDPDGCNHCFN && dragEffect == (DragEffect)6)
			{
				if (base.shouldMoveVertically || base.shouldMoveHorizontally)
				{
					SpringPanel.Begin(base.panel.gameObject, mTrans.localPosition + vector, 750f);
				}
				else if (alignToTopWhenDontFit)
				{
					AlignToPos(instant: false, Alingment.BottomRight);
				}
				else
				{
					SpringPanel.Begin(base.panel.gameObject, mTrans.localPosition + vector, 155f);
				}
			}
			else
			{
				MoveRelative(vector);
				mMomentum = Vector3.zero;
				mScroll = 1002f;
			}
			return false;
		}
		if (alignToTopWhenDontFit && !base.itFits)
		{
			AlignToPos(instant: false);
		}
		return true;
	}
}
