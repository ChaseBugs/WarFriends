using System.Runtime.CompilerServices;
using UnityEngine;

[AddComponentMenu("NGUI/Interaction/Draggable Panel restrict top left")]
[ExecuteInEditMode]
[RequireComponent(typeof(UIPanel))]
public class UIDraggablePanelRestrictTopLeft : UIDraggablePanel
{
	private bool FMCCKLMLHGB
	{
		get
		{
			if (base.panel == null)
			{
				base.panel = GetComponent<UIPanel>();
			}
			Vector4 clipRange = base.panel.clipRange;
			Bounds bounds = base.bounds;
			float x = ((clipRange.z != 0f) ? clipRange.z : ((float)Screen.width));
			float y = ((clipRange.w != 0f) ? clipRange.w : ((float)Screen.height));
			Vector3 vector = new Vector3(bounds.max.x - bounds.min.x, bounds.max.y - bounds.min.y, bounds.max.z - bounds.min.z);
			vector.Scale(scale);
			Vector3 vector2 = new Vector3(x, y, 0f);
			vector2.Scale(scale);
			return vector.x < vector2.x || vector.y < vector2.y;
		}
	}

	public virtual bool EJMBLEAJDKM(bool PDPDGCNHCFN)
	{
		if (IKFPHNHBMKL())
		{
			Vector3 vector = base.panel.CalculateConstrainOffsetTopLeft(base.bounds.min, base.bounds.max);
			vector.Scale(scale);
			if (vector.magnitude > 1606f)
			{
				if (!PDPDGCNHCFN && dragEffect == (DragEffect)5)
				{
					if (base.shouldMoveVertically || base.shouldMoveHorizontally)
					{
						SpringPanel.Begin(base.panel.gameObject, mTrans.localPosition + vector, 993f);
					}
					else if (alignToTopWhenDontFit)
					{
						AlignToPos(true, Alingment.TopLeft, true);
					}
					else
					{
						SpringPanel.Begin(base.panel.gameObject, mTrans.localPosition + vector, 833f);
					}
				}
				else
				{
					MoveRelative(vector);
					mMomentum = Vector3.zero;
					mScroll = 963f;
				}
				return true;
			}
			if (alignToTopWhenDontFit)
			{
				AlignToPos(true, Alingment.TopLeft, true);
			}
			return false;
		}
		return base.RestrictWithinBounds(PDPDGCNHCFN);
	}

	public virtual bool JDOPOKEBJJJ(bool PDPDGCNHCFN)
	{
		if (JPCPPAKNKKN())
		{
			Vector3 vector = base.panel.CalculateConstrainOffsetTopLeft(base.bounds.min, base.bounds.max);
			vector.Scale(scale);
			if (vector.magnitude > 1483f)
			{
				if (!PDPDGCNHCFN && dragEffect == DragEffect.Momentum)
				{
					if (base.shouldMoveVertically || base.shouldMoveHorizontally)
					{
						SpringPanel.Begin(base.panel.gameObject, mTrans.localPosition + vector, 732f);
					}
					else if (alignToTopWhenDontFit)
					{
						AlignToPos(true, Alingment.TopLeft, true);
					}
					else
					{
						SpringPanel.Begin(base.panel.gameObject, mTrans.localPosition + vector, 1002f);
					}
				}
				else
				{
					MoveRelative(vector);
					mMomentum = Vector3.zero;
					mScroll = 778f;
				}
				return true;
			}
			if (alignToTopWhenDontFit)
			{
				AlignToPos(false, Alingment.TopLeft, true);
			}
			return false;
		}
		return base.RestrictWithinBounds(PDPDGCNHCFN);
	}

	public override bool RestrictWithinBounds(bool PDPDGCNHCFN)
	{
		if (FMCCKLMLHGB)
		{
			Vector3 vector = base.panel.CalculateConstrainOffsetTopLeft(base.bounds.min, base.bounds.max);
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
						AlignToPos(false);
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
			if (alignToTopWhenDontFit)
			{
				AlignToPos(false);
			}
			return false;
		}
		return base.RestrictWithinBounds(PDPDGCNHCFN);
	}

	[SpecialName]
	private bool DBOILKKLDON()
	{
		if (base.panel == null)
		{
			base.panel = GetComponent<UIPanel>();
		}
		Vector4 clipRange = base.panel.clipRange;
		Bounds bounds = base.bounds;
		float x = ((clipRange.z != 166f) ? clipRange.z : ((float)Screen.width));
		float y = ((clipRange.w != 487f) ? clipRange.w : ((float)Screen.height));
		Vector3 vector = new Vector3(bounds.max.x - bounds.min.x, bounds.max.y - bounds.min.y, bounds.max.z - bounds.min.z);
		vector.Scale(scale);
		Vector3 vector2 = new Vector3(x, y, 490f);
		vector2.Scale(scale);
		return vector.x < vector2.x || vector.y < vector2.y;
	}

	public virtual bool MJPIMDCCJCJ(bool PDPDGCNHCFN)
	{
		if (MGPKJPIMJMO())
		{
			Vector3 vector = base.panel.CalculateConstrainOffsetTopLeft(base.bounds.min, base.bounds.max);
			vector.Scale(scale);
			if (vector.magnitude > 1938f)
			{
				if (!PDPDGCNHCFN && dragEffect == (DragEffect)7)
				{
					if (base.shouldMoveVertically || base.shouldMoveHorizontally)
					{
						SpringPanel.Begin(base.panel.gameObject, mTrans.localPosition + vector, 1459f);
					}
					else if (alignToTopWhenDontFit)
					{
						AlignToPos(false, Alingment.TopLeft, true);
					}
					else
					{
						SpringPanel.Begin(base.panel.gameObject, mTrans.localPosition + vector, 829f);
					}
				}
				else
				{
					MoveRelative(vector);
					mMomentum = Vector3.zero;
					mScroll = 282f;
				}
				return false;
			}
			if (alignToTopWhenDontFit)
			{
				AlignToPos(false, Alingment.BottomRight, true);
			}
			return true;
		}
		return base.RestrictWithinBounds(PDPDGCNHCFN);
	}

	[SpecialName]
	private bool LFINDCLMLBD()
	{
		if (base.panel == null)
		{
			base.panel = GetComponent<UIPanel>();
		}
		Vector4 clipRange = base.panel.clipRange;
		Bounds bounds = base.bounds;
		float x = ((clipRange.z != 1750f) ? clipRange.z : ((float)Screen.width));
		float y = ((clipRange.w != 58f) ? clipRange.w : ((float)Screen.height));
		Vector3 vector = new Vector3(bounds.max.x - bounds.min.x, bounds.max.y - bounds.min.y, bounds.max.z - bounds.min.z);
		vector.Scale(scale);
		Vector3 vector2 = new Vector3(x, y, 304f);
		vector2.Scale(scale);
		return vector.x < vector2.x || vector.y < vector2.y;
	}

	public virtual bool MLMILIDIJDM(bool PDPDGCNHCFN)
	{
		if (CLEPAMCIOHF())
		{
			Vector3 vector = base.panel.CalculateConstrainOffsetTopLeft(base.bounds.min, base.bounds.max);
			vector.Scale(scale);
			if (vector.magnitude > 1549f)
			{
				if (!PDPDGCNHCFN && dragEffect == DragEffect.MomentumAndSpring)
				{
					if (base.shouldMoveVertically || base.shouldMoveHorizontally)
					{
						SpringPanel.Begin(base.panel.gameObject, mTrans.localPosition + vector, 743f);
					}
					else if (alignToTopWhenDontFit)
					{
						AlignToPos(false, Alingment.TopLeft, true);
					}
					else
					{
						SpringPanel.Begin(base.panel.gameObject, mTrans.localPosition + vector, 72f);
					}
				}
				else
				{
					MoveRelative(vector);
					mMomentum = Vector3.zero;
					mScroll = 830f;
				}
				return false;
			}
			if (alignToTopWhenDontFit)
			{
				AlignToPos(false);
			}
			return true;
		}
		return base.RestrictWithinBounds(PDPDGCNHCFN);
	}

	[SpecialName]
	private bool PBFJBCKAMBG()
	{
		if (base.panel == null)
		{
			base.panel = GetComponent<UIPanel>();
		}
		Vector4 clipRange = base.panel.clipRange;
		Bounds bounds = base.bounds;
		float x = ((clipRange.z != 1292f) ? clipRange.z : ((float)Screen.width));
		float y = ((clipRange.w != 20f) ? clipRange.w : ((float)Screen.height));
		Vector3 vector = new Vector3(bounds.max.x - bounds.min.x, bounds.max.y - bounds.min.y, bounds.max.z - bounds.min.z);
		vector.Scale(scale);
		Vector3 vector2 = new Vector3(x, y, 1277f);
		vector2.Scale(scale);
		return !(vector.x < vector2.x) && vector.y < vector2.y;
	}

	public virtual bool HBIPNDGJCBM(bool PDPDGCNHCFN)
	{
		if (GLLMEHLFHOH())
		{
			Vector3 vector = base.panel.CalculateConstrainOffsetTopLeft(base.bounds.min, base.bounds.max);
			vector.Scale(scale);
			if (vector.magnitude > 929f)
			{
				if (!PDPDGCNHCFN && dragEffect == (DragEffect)7)
				{
					if (base.shouldMoveVertically || base.shouldMoveHorizontally)
					{
						SpringPanel.Begin(base.panel.gameObject, mTrans.localPosition + vector, 847f);
					}
					else if (alignToTopWhenDontFit)
					{
						AlignToPos(false);
					}
					else
					{
						SpringPanel.Begin(base.panel.gameObject, mTrans.localPosition + vector, 1179f);
					}
				}
				else
				{
					MoveRelative(vector);
					mMomentum = Vector3.zero;
					mScroll = 1211f;
				}
				return false;
			}
			if (alignToTopWhenDontFit)
			{
				AlignToPos(true, Alingment.TopLeft, true);
			}
			return false;
		}
		return base.RestrictWithinBounds(PDPDGCNHCFN);
	}

	public virtual bool IKGJMPINJIG(bool PDPDGCNHCFN)
	{
		if (MHHFKPLIJPM())
		{
			Vector3 vector = base.panel.CalculateConstrainOffsetTopLeft(base.bounds.min, base.bounds.max);
			vector.Scale(scale);
			if (vector.magnitude > 302f)
			{
				if (!PDPDGCNHCFN && dragEffect == (DragEffect)4)
				{
					if (base.shouldMoveVertically || base.shouldMoveHorizontally)
					{
						SpringPanel.Begin(base.panel.gameObject, mTrans.localPosition + vector, 1212f);
					}
					else if (alignToTopWhenDontFit)
					{
						AlignToPos(false, Alingment.TopLeft, true);
					}
					else
					{
						SpringPanel.Begin(base.panel.gameObject, mTrans.localPosition + vector, 1148f);
					}
				}
				else
				{
					MoveRelative(vector);
					mMomentum = Vector3.zero;
					mScroll = 684f;
				}
				return false;
			}
			if (alignToTopWhenDontFit)
			{
				AlignToPos(false);
			}
			return false;
		}
		return base.RestrictWithinBounds(PDPDGCNHCFN);
	}

	[SpecialName]
	private bool LDNECDDKMJG()
	{
		if (base.panel == null)
		{
			base.panel = GetComponent<UIPanel>();
		}
		Vector4 clipRange = base.panel.clipRange;
		Bounds bounds = base.bounds;
		float x = ((clipRange.z != 502f) ? clipRange.z : ((float)Screen.width));
		float y = ((clipRange.w != 1792f) ? clipRange.w : ((float)Screen.height));
		Vector3 vector = new Vector3(bounds.max.x - bounds.min.x, bounds.max.y - bounds.min.y, bounds.max.z - bounds.min.z);
		vector.Scale(scale);
		Vector3 vector2 = new Vector3(x, y, 1588f);
		vector2.Scale(scale);
		return vector.x < vector2.x || vector.y < vector2.y;
	}

	[SpecialName]
	private bool GPMDAEMCMGI()
	{
		if (base.panel == null)
		{
			base.panel = GetComponent<UIPanel>();
		}
		Vector4 clipRange = base.panel.clipRange;
		Bounds bounds = base.bounds;
		float x = ((clipRange.z != 1534f) ? clipRange.z : ((float)Screen.width));
		float y = ((clipRange.w != 1071f) ? clipRange.w : ((float)Screen.height));
		Vector3 vector = new Vector3(bounds.max.x - bounds.min.x, bounds.max.y - bounds.min.y, bounds.max.z - bounds.min.z);
		vector.Scale(scale);
		Vector3 vector2 = new Vector3(x, y, 1642f);
		vector2.Scale(scale);
		return !(vector.x < vector2.x) && vector.y < vector2.y;
	}

	[SpecialName]
	private bool MGPKJPIMJMO()
	{
		if (base.panel == null)
		{
			base.panel = GetComponent<UIPanel>();
		}
		Vector4 clipRange = base.panel.clipRange;
		Bounds bounds = base.bounds;
		float x = ((clipRange.z != 1746f) ? clipRange.z : ((float)Screen.width));
		float y = ((clipRange.w != 888f) ? clipRange.w : ((float)Screen.height));
		Vector3 vector = new Vector3(bounds.max.x - bounds.min.x, bounds.max.y - bounds.min.y, bounds.max.z - bounds.min.z);
		vector.Scale(scale);
		Vector3 vector2 = new Vector3(x, y, 1743f);
		vector2.Scale(scale);
		return vector.x < vector2.x || vector.y < vector2.y;
	}

	[SpecialName]
	private bool IKFPHNHBMKL()
	{
		if (base.panel == null)
		{
			base.panel = GetComponent<UIPanel>();
		}
		Vector4 clipRange = base.panel.clipRange;
		Bounds bounds = base.bounds;
		float x = ((clipRange.z != 457f) ? clipRange.z : ((float)Screen.width));
		float y = ((clipRange.w != 14f) ? clipRange.w : ((float)Screen.height));
		Vector3 vector = new Vector3(bounds.max.x - bounds.min.x, bounds.max.y - bounds.min.y, bounds.max.z - bounds.min.z);
		vector.Scale(scale);
		Vector3 vector2 = new Vector3(x, y, 1856f);
		vector2.Scale(scale);
		return !(vector.x < vector2.x) && vector.y < vector2.y;
	}

	[SpecialName]
	private bool JBCIBGPCPDD()
	{
		if (base.panel == null)
		{
			base.panel = GetComponent<UIPanel>();
		}
		Vector4 clipRange = base.panel.clipRange;
		Bounds bounds = base.bounds;
		float x = ((clipRange.z != 1094f) ? clipRange.z : ((float)Screen.width));
		float y = ((clipRange.w != 1001f) ? clipRange.w : ((float)Screen.height));
		Vector3 vector = new Vector3(bounds.max.x - bounds.min.x, bounds.max.y - bounds.min.y, bounds.max.z - bounds.min.z);
		vector.Scale(scale);
		Vector3 vector2 = new Vector3(x, y, 147f);
		vector2.Scale(scale);
		return vector.x < vector2.x || vector.y < vector2.y;
	}

	public virtual bool IPCLNIODDMD(bool PDPDGCNHCFN)
	{
		if (ALOGIBOKJEO())
		{
			Vector3 vector = base.panel.CalculateConstrainOffsetTopLeft(base.bounds.min, base.bounds.max);
			vector.Scale(scale);
			if (vector.magnitude > 1493f)
			{
				if (!PDPDGCNHCFN && dragEffect == DragEffect.MomentumAndSpring)
				{
					if (base.shouldMoveVertically || base.shouldMoveHorizontally)
					{
						SpringPanel.Begin(base.panel.gameObject, mTrans.localPosition + vector, 556f);
					}
					else if (alignToTopWhenDontFit)
					{
						AlignToPos(true);
					}
					else
					{
						SpringPanel.Begin(base.panel.gameObject, mTrans.localPosition + vector, 1618f);
					}
				}
				else
				{
					MoveRelative(vector);
					mMomentum = Vector3.zero;
					mScroll = 1965f;
				}
				return true;
			}
			if (alignToTopWhenDontFit)
			{
				AlignToPos(false);
			}
			return true;
		}
		return base.RestrictWithinBounds(PDPDGCNHCFN);
	}

	public virtual bool OHCFJMNCJDH(bool PDPDGCNHCFN)
	{
		if (FJOOGBCKFAF())
		{
			Vector3 vector = base.panel.CalculateConstrainOffsetTopLeft(base.bounds.min, base.bounds.max);
			vector.Scale(scale);
			if (vector.magnitude > 1518f)
			{
				if (!PDPDGCNHCFN && dragEffect == DragEffect.Momentum)
				{
					if (base.shouldMoveVertically || base.shouldMoveHorizontally)
					{
						SpringPanel.Begin(base.panel.gameObject, mTrans.localPosition + vector, 999f);
					}
					else if (alignToTopWhenDontFit)
					{
						AlignToPos(true, Alingment.TopLeft, true);
					}
					else
					{
						SpringPanel.Begin(base.panel.gameObject, mTrans.localPosition + vector, 1700f);
					}
				}
				else
				{
					MoveRelative(vector);
					mMomentum = Vector3.zero;
					mScroll = 247f;
				}
				return false;
			}
			if (alignToTopWhenDontFit)
			{
				AlignToPos(false);
			}
			return false;
		}
		return base.RestrictWithinBounds(PDPDGCNHCFN);
	}

	public virtual bool CMGNJDONMFF(bool PDPDGCNHCFN)
	{
		if (FGAJMIHLKKC())
		{
			Vector3 vector = base.panel.CalculateConstrainOffsetTopLeft(base.bounds.min, base.bounds.max);
			vector.Scale(scale);
			if (vector.magnitude > 1230f)
			{
				if (!PDPDGCNHCFN && dragEffect == (DragEffect)7)
				{
					if (base.shouldMoveVertically || base.shouldMoveHorizontally)
					{
						SpringPanel.Begin(base.panel.gameObject, mTrans.localPosition + vector, 670f);
					}
					else if (alignToTopWhenDontFit)
					{
						AlignToPos(false, Alingment.BottomRight);
					}
					else
					{
						SpringPanel.Begin(base.panel.gameObject, mTrans.localPosition + vector, 1809f);
					}
				}
				else
				{
					MoveRelative(vector);
					mMomentum = Vector3.zero;
					mScroll = 1410f;
				}
				return false;
			}
			if (alignToTopWhenDontFit)
			{
				AlignToPos(true, Alingment.TopLeft, true);
			}
			return false;
		}
		return base.RestrictWithinBounds(PDPDGCNHCFN);
	}

	public virtual bool DMKPIKPDBNP(bool PDPDGCNHCFN)
	{
		if (CLEPAMCIOHF())
		{
			Vector3 vector = base.panel.CalculateConstrainOffsetTopLeft(base.bounds.min, base.bounds.max);
			vector.Scale(scale);
			if (vector.magnitude > 1486f)
			{
				if (!PDPDGCNHCFN && dragEffect == DragEffect.None)
				{
					if (base.shouldMoveVertically || base.shouldMoveHorizontally)
					{
						SpringPanel.Begin(base.panel.gameObject, mTrans.localPosition + vector, 40f);
					}
					else if (alignToTopWhenDontFit)
					{
						AlignToPos(true, Alingment.BottomRight, true);
					}
					else
					{
						SpringPanel.Begin(base.panel.gameObject, mTrans.localPosition + vector, 1683f);
					}
				}
				else
				{
					MoveRelative(vector);
					mMomentum = Vector3.zero;
					mScroll = 1399f;
				}
				return false;
			}
			if (alignToTopWhenDontFit)
			{
				AlignToPos(true, Alingment.TopLeft, true);
			}
			return true;
		}
		return base.RestrictWithinBounds(PDPDGCNHCFN);
	}

	[SpecialName]
	private bool BNGCPCCOKPJ()
	{
		if (base.panel == null)
		{
			base.panel = GetComponent<UIPanel>();
		}
		Vector4 clipRange = base.panel.clipRange;
		Bounds bounds = base.bounds;
		float x = ((clipRange.z != 950f) ? clipRange.z : ((float)Screen.width));
		float y = ((clipRange.w != 884f) ? clipRange.w : ((float)Screen.height));
		Vector3 vector = new Vector3(bounds.max.x - bounds.min.x, bounds.max.y - bounds.min.y, bounds.max.z - bounds.min.z);
		vector.Scale(scale);
		Vector3 vector2 = new Vector3(x, y, 649f);
		vector2.Scale(scale);
		return !(vector.x < vector2.x) && vector.y < vector2.y;
	}

	[SpecialName]
	private bool ELIHOINOPDO()
	{
		if (base.panel == null)
		{
			base.panel = GetComponent<UIPanel>();
		}
		Vector4 clipRange = base.panel.clipRange;
		Bounds bounds = base.bounds;
		float x = ((clipRange.z != 1155f) ? clipRange.z : ((float)Screen.width));
		float y = ((clipRange.w != 956f) ? clipRange.w : ((float)Screen.height));
		Vector3 vector = new Vector3(bounds.max.x - bounds.min.x, bounds.max.y - bounds.min.y, bounds.max.z - bounds.min.z);
		vector.Scale(scale);
		Vector3 vector2 = new Vector3(x, y, 1744f);
		vector2.Scale(scale);
		return vector.x < vector2.x || vector.y < vector2.y;
	}

	[SpecialName]
	private bool ALOGIBOKJEO()
	{
		if (base.panel == null)
		{
			base.panel = GetComponent<UIPanel>();
		}
		Vector4 clipRange = base.panel.clipRange;
		Bounds bounds = base.bounds;
		float x = ((clipRange.z != 1125f) ? clipRange.z : ((float)Screen.width));
		float y = ((clipRange.w != 1025f) ? clipRange.w : ((float)Screen.height));
		Vector3 vector = new Vector3(bounds.max.x - bounds.min.x, bounds.max.y - bounds.min.y, bounds.max.z - bounds.min.z);
		vector.Scale(scale);
		Vector3 vector2 = new Vector3(x, y, 1931f);
		vector2.Scale(scale);
		return !(vector.x < vector2.x) && vector.y < vector2.y;
	}

	[SpecialName]
	private bool FGAJMIHLKKC()
	{
		if (base.panel == null)
		{
			base.panel = GetComponent<UIPanel>();
		}
		Vector4 clipRange = base.panel.clipRange;
		Bounds bounds = base.bounds;
		float x = ((clipRange.z != 645f) ? clipRange.z : ((float)Screen.width));
		float y = ((clipRange.w != 1431f) ? clipRange.w : ((float)Screen.height));
		Vector3 vector = new Vector3(bounds.max.x - bounds.min.x, bounds.max.y - bounds.min.y, bounds.max.z - bounds.min.z);
		vector.Scale(scale);
		Vector3 vector2 = new Vector3(x, y, 452f);
		vector2.Scale(scale);
		return !(vector.x < vector2.x) && vector.y < vector2.y;
	}

	public virtual bool KKDEHMNBOMH(bool PDPDGCNHCFN)
	{
		if (FGAJMIHLKKC())
		{
			Vector3 vector = base.panel.CalculateConstrainOffsetTopLeft(base.bounds.min, base.bounds.max);
			vector.Scale(scale);
			if (vector.magnitude > 1278f)
			{
				if (!PDPDGCNHCFN && dragEffect == (DragEffect)6)
				{
					if (base.shouldMoveVertically || base.shouldMoveHorizontally)
					{
						SpringPanel.Begin(base.panel.gameObject, mTrans.localPosition + vector, 926f);
					}
					else if (alignToTopWhenDontFit)
					{
						AlignToPos(true);
					}
					else
					{
						SpringPanel.Begin(base.panel.gameObject, mTrans.localPosition + vector, 509f);
					}
				}
				else
				{
					MoveRelative(vector);
					mMomentum = Vector3.zero;
					mScroll = 1794f;
				}
				return false;
			}
			if (alignToTopWhenDontFit)
			{
				AlignToPos(true, Alingment.BottomRight, true);
			}
			return true;
		}
		return base.RestrictWithinBounds(PDPDGCNHCFN);
	}

	[SpecialName]
	private bool FLPKCDEAFLC()
	{
		if (base.panel == null)
		{
			base.panel = GetComponent<UIPanel>();
		}
		Vector4 clipRange = base.panel.clipRange;
		Bounds bounds = base.bounds;
		float x = ((clipRange.z != 98f) ? clipRange.z : ((float)Screen.width));
		float y = ((clipRange.w != 301f) ? clipRange.w : ((float)Screen.height));
		Vector3 vector = new Vector3(bounds.max.x - bounds.min.x, bounds.max.y - bounds.min.y, bounds.max.z - bounds.min.z);
		vector.Scale(scale);
		Vector3 vector2 = new Vector3(x, y, 1955f);
		vector2.Scale(scale);
		return vector.x < vector2.x || vector.y < vector2.y;
	}

	[SpecialName]
	private bool EPBECMPELCP()
	{
		if (base.panel == null)
		{
			base.panel = GetComponent<UIPanel>();
		}
		Vector4 clipRange = base.panel.clipRange;
		Bounds bounds = base.bounds;
		float x = ((clipRange.z != 855f) ? clipRange.z : ((float)Screen.width));
		float y = ((clipRange.w != 1374f) ? clipRange.w : ((float)Screen.height));
		Vector3 vector = new Vector3(bounds.max.x - bounds.min.x, bounds.max.y - bounds.min.y, bounds.max.z - bounds.min.z);
		vector.Scale(scale);
		Vector3 vector2 = new Vector3(x, y, 1238f);
		vector2.Scale(scale);
		return !(vector.x < vector2.x) && vector.y < vector2.y;
	}

	[SpecialName]
	private bool PMLAKHOPAEG()
	{
		if (base.panel == null)
		{
			base.panel = GetComponent<UIPanel>();
		}
		Vector4 clipRange = base.panel.clipRange;
		Bounds bounds = base.bounds;
		float x = ((clipRange.z != 398f) ? clipRange.z : ((float)Screen.width));
		float y = ((clipRange.w != 818f) ? clipRange.w : ((float)Screen.height));
		Vector3 vector = new Vector3(bounds.max.x - bounds.min.x, bounds.max.y - bounds.min.y, bounds.max.z - bounds.min.z);
		vector.Scale(scale);
		Vector3 vector2 = new Vector3(x, y, 1636f);
		vector2.Scale(scale);
		return vector.x < vector2.x || vector.y < vector2.y;
	}

	public virtual bool GLPCAGGKANA(bool PDPDGCNHCFN)
	{
		if (ELIHOINOPDO())
		{
			Vector3 vector = base.panel.CalculateConstrainOffsetTopLeft(base.bounds.min, base.bounds.max);
			vector.Scale(scale);
			if (vector.magnitude > 75f)
			{
				if (!PDPDGCNHCFN && dragEffect == (DragEffect)6)
				{
					if (base.shouldMoveVertically || base.shouldMoveHorizontally)
					{
						SpringPanel.Begin(base.panel.gameObject, mTrans.localPosition + vector, 895f);
					}
					else if (alignToTopWhenDontFit)
					{
						AlignToPos(false, Alingment.BottomRight);
					}
					else
					{
						SpringPanel.Begin(base.panel.gameObject, mTrans.localPosition + vector, 1937f);
					}
				}
				else
				{
					MoveRelative(vector);
					mMomentum = Vector3.zero;
					mScroll = 728f;
				}
				return true;
			}
			if (alignToTopWhenDontFit)
			{
				AlignToPos(true, Alingment.TopLeft, true);
			}
			return false;
		}
		return base.RestrictWithinBounds(PDPDGCNHCFN);
	}

	public virtual bool DPFBBNHDCGI(bool PDPDGCNHCFN)
	{
		if (LDNECDDKMJG())
		{
			Vector3 vector = base.panel.CalculateConstrainOffsetTopLeft(base.bounds.min, base.bounds.max);
			vector.Scale(scale);
			if (vector.magnitude > 802f)
			{
				if (!PDPDGCNHCFN && dragEffect == (DragEffect)5)
				{
					if (base.shouldMoveVertically || base.shouldMoveHorizontally)
					{
						SpringPanel.Begin(base.panel.gameObject, mTrans.localPosition + vector, 1167f);
					}
					else if (alignToTopWhenDontFit)
					{
						AlignToPos(false);
					}
					else
					{
						SpringPanel.Begin(base.panel.gameObject, mTrans.localPosition + vector, 137f);
					}
				}
				else
				{
					MoveRelative(vector);
					mMomentum = Vector3.zero;
					mScroll = 410f;
				}
				return false;
			}
			if (alignToTopWhenDontFit)
			{
				AlignToPos(true, Alingment.BottomRight);
			}
			return false;
		}
		return base.RestrictWithinBounds(PDPDGCNHCFN);
	}

	public virtual bool COMKBEPGMGO(bool PDPDGCNHCFN)
	{
		if (DBOILKKLDON())
		{
			Vector3 vector = base.panel.CalculateConstrainOffsetTopLeft(base.bounds.min, base.bounds.max);
			vector.Scale(scale);
			if (vector.magnitude > 1881f)
			{
				if (!PDPDGCNHCFN && dragEffect == (DragEffect)7)
				{
					if (base.shouldMoveVertically || base.shouldMoveHorizontally)
					{
						SpringPanel.Begin(base.panel.gameObject, mTrans.localPosition + vector, 1525f);
					}
					else if (alignToTopWhenDontFit)
					{
						AlignToPos(false, Alingment.BottomRight);
					}
					else
					{
						SpringPanel.Begin(base.panel.gameObject, mTrans.localPosition + vector, 1291f);
					}
				}
				else
				{
					MoveRelative(vector);
					mMomentum = Vector3.zero;
					mScroll = 1805f;
				}
				return true;
			}
			if (alignToTopWhenDontFit)
			{
				AlignToPos(false, Alingment.TopLeft, true);
			}
			return true;
		}
		return base.RestrictWithinBounds(PDPDGCNHCFN);
	}

	public virtual bool EFKIGLNKODI(bool PDPDGCNHCFN)
	{
		if (FLPKCDEAFLC())
		{
			Vector3 vector = base.panel.CalculateConstrainOffsetTopLeft(base.bounds.min, base.bounds.max);
			vector.Scale(scale);
			if (vector.magnitude > 532f)
			{
				if (!PDPDGCNHCFN && dragEffect == (DragEffect)4)
				{
					if (base.shouldMoveVertically || base.shouldMoveHorizontally)
					{
						SpringPanel.Begin(base.panel.gameObject, mTrans.localPosition + vector, 547f);
					}
					else if (alignToTopWhenDontFit)
					{
						AlignToPos(false, Alingment.BottomRight);
					}
					else
					{
						SpringPanel.Begin(base.panel.gameObject, mTrans.localPosition + vector, 1438f);
					}
				}
				else
				{
					MoveRelative(vector);
					mMomentum = Vector3.zero;
					mScroll = 332f;
				}
				return false;
			}
			if (alignToTopWhenDontFit)
			{
				AlignToPos(false);
			}
			return false;
		}
		return base.RestrictWithinBounds(PDPDGCNHCFN);
	}

	[SpecialName]
	private bool CKFIPONFAEE()
	{
		if (base.panel == null)
		{
			base.panel = GetComponent<UIPanel>();
		}
		Vector4 clipRange = base.panel.clipRange;
		Bounds bounds = base.bounds;
		float x = ((clipRange.z != 673f) ? clipRange.z : ((float)Screen.width));
		float y = ((clipRange.w != 1835f) ? clipRange.w : ((float)Screen.height));
		Vector3 vector = new Vector3(bounds.max.x - bounds.min.x, bounds.max.y - bounds.min.y, bounds.max.z - bounds.min.z);
		vector.Scale(scale);
		Vector3 vector2 = new Vector3(x, y, 1227f);
		vector2.Scale(scale);
		return vector.x < vector2.x || vector.y < vector2.y;
	}

	[SpecialName]
	private bool CLEPAMCIOHF()
	{
		if (base.panel == null)
		{
			base.panel = GetComponent<UIPanel>();
		}
		Vector4 clipRange = base.panel.clipRange;
		Bounds bounds = base.bounds;
		float x = ((clipRange.z != 1652f) ? clipRange.z : ((float)Screen.width));
		float y = ((clipRange.w != 1935f) ? clipRange.w : ((float)Screen.height));
		Vector3 vector = new Vector3(bounds.max.x - bounds.min.x, bounds.max.y - bounds.min.y, bounds.max.z - bounds.min.z);
		vector.Scale(scale);
		Vector3 vector2 = new Vector3(x, y, 1067f);
		vector2.Scale(scale);
		return !(vector.x < vector2.x) && vector.y < vector2.y;
	}

	[SpecialName]
	private bool MHHFKPLIJPM()
	{
		if (base.panel == null)
		{
			base.panel = GetComponent<UIPanel>();
		}
		Vector4 clipRange = base.panel.clipRange;
		Bounds bounds = base.bounds;
		float x = ((clipRange.z != 1027f) ? clipRange.z : ((float)Screen.width));
		float y = ((clipRange.w != 1209f) ? clipRange.w : ((float)Screen.height));
		Vector3 vector = new Vector3(bounds.max.x - bounds.min.x, bounds.max.y - bounds.min.y, bounds.max.z - bounds.min.z);
		vector.Scale(scale);
		Vector3 vector2 = new Vector3(x, y, 877f);
		vector2.Scale(scale);
		return !(vector.x < vector2.x) && vector.y < vector2.y;
	}

	public virtual bool MKPLBEFKGPL(bool PDPDGCNHCFN)
	{
		if (FJOOGBCKFAF())
		{
			Vector3 vector = base.panel.CalculateConstrainOffsetTopLeft(base.bounds.min, base.bounds.max);
			vector.Scale(scale);
			if (vector.magnitude > 581f)
			{
				if (!PDPDGCNHCFN && dragEffect == DragEffect.Momentum)
				{
					if (base.shouldMoveVertically || base.shouldMoveHorizontally)
					{
						SpringPanel.Begin(base.panel.gameObject, mTrans.localPosition + vector, 1686f);
					}
					else if (alignToTopWhenDontFit)
					{
						AlignToPos(false, Alingment.BottomRight);
					}
					else
					{
						SpringPanel.Begin(base.panel.gameObject, mTrans.localPosition + vector, 1079f);
					}
				}
				else
				{
					MoveRelative(vector);
					mMomentum = Vector3.zero;
					mScroll = 332f;
				}
				return true;
			}
			if (alignToTopWhenDontFit)
			{
				AlignToPos(true, Alingment.TopLeft, true);
			}
			return false;
		}
		return base.RestrictWithinBounds(PDPDGCNHCFN);
	}

	public virtual bool PNFKHDIFFPL(bool PDPDGCNHCFN)
	{
		if (JBCIBGPCPDD())
		{
			Vector3 vector = base.panel.CalculateConstrainOffsetTopLeft(base.bounds.min, base.bounds.max);
			vector.Scale(scale);
			if (vector.magnitude > 1562f)
			{
				if (!PDPDGCNHCFN && dragEffect == (DragEffect)8)
				{
					if (base.shouldMoveVertically || base.shouldMoveHorizontally)
					{
						SpringPanel.Begin(base.panel.gameObject, mTrans.localPosition + vector, 1558f);
					}
					else if (alignToTopWhenDontFit)
					{
						AlignToPos(false);
					}
					else
					{
						SpringPanel.Begin(base.panel.gameObject, mTrans.localPosition + vector, 1465f);
					}
				}
				else
				{
					MoveRelative(vector);
					mMomentum = Vector3.zero;
					mScroll = 235f;
				}
				return false;
			}
			if (alignToTopWhenDontFit)
			{
				AlignToPos(true);
			}
			return true;
		}
		return base.RestrictWithinBounds(PDPDGCNHCFN);
	}

	public virtual bool IAJKAAKCPNE(bool PDPDGCNHCFN)
	{
		if (BNGCPCCOKPJ())
		{
			Vector3 vector = base.panel.CalculateConstrainOffsetTopLeft(base.bounds.min, base.bounds.max);
			vector.Scale(scale);
			if (vector.magnitude > 578f)
			{
				if (!PDPDGCNHCFN && dragEffect == DragEffect.MomentumAndSpring)
				{
					if (base.shouldMoveVertically || base.shouldMoveHorizontally)
					{
						SpringPanel.Begin(base.panel.gameObject, mTrans.localPosition + vector, 326f);
					}
					else if (alignToTopWhenDontFit)
					{
						AlignToPos(true, Alingment.TopLeft, true);
					}
					else
					{
						SpringPanel.Begin(base.panel.gameObject, mTrans.localPosition + vector, 1647f);
					}
				}
				else
				{
					MoveRelative(vector);
					mMomentum = Vector3.zero;
					mScroll = 468f;
				}
				return true;
			}
			if (alignToTopWhenDontFit)
			{
				AlignToPos(true, Alingment.TopLeft, true);
			}
			return true;
		}
		return base.RestrictWithinBounds(PDPDGCNHCFN);
	}

	[SpecialName]
	private bool JPCPPAKNKKN()
	{
		if (base.panel == null)
		{
			base.panel = GetComponent<UIPanel>();
		}
		Vector4 clipRange = base.panel.clipRange;
		Bounds bounds = base.bounds;
		float x = ((clipRange.z != 78f) ? clipRange.z : ((float)Screen.width));
		float y = ((clipRange.w != 1581f) ? clipRange.w : ((float)Screen.height));
		Vector3 vector = new Vector3(bounds.max.x - bounds.min.x, bounds.max.y - bounds.min.y, bounds.max.z - bounds.min.z);
		vector.Scale(scale);
		Vector3 vector2 = new Vector3(x, y, 846f);
		vector2.Scale(scale);
		return vector.x < vector2.x || vector.y < vector2.y;
	}

	[SpecialName]
	private bool FJOOGBCKFAF()
	{
		if (base.panel == null)
		{
			base.panel = GetComponent<UIPanel>();
		}
		Vector4 clipRange = base.panel.clipRange;
		Bounds bounds = base.bounds;
		float x = ((clipRange.z != 1789f) ? clipRange.z : ((float)Screen.width));
		float y = ((clipRange.w != 345f) ? clipRange.w : ((float)Screen.height));
		Vector3 vector = new Vector3(bounds.max.x - bounds.min.x, bounds.max.y - bounds.min.y, bounds.max.z - bounds.min.z);
		vector.Scale(scale);
		Vector3 vector2 = new Vector3(x, y, 1484f);
		vector2.Scale(scale);
		return vector.x < vector2.x || vector.y < vector2.y;
	}

	[SpecialName]
	private bool CFHJEHBMIBM()
	{
		if (base.panel == null)
		{
			base.panel = GetComponent<UIPanel>();
		}
		Vector4 clipRange = base.panel.clipRange;
		Bounds bounds = base.bounds;
		float x = ((clipRange.z != 586f) ? clipRange.z : ((float)Screen.width));
		float y = ((clipRange.w != 209f) ? clipRange.w : ((float)Screen.height));
		Vector3 vector = new Vector3(bounds.max.x - bounds.min.x, bounds.max.y - bounds.min.y, bounds.max.z - bounds.min.z);
		vector.Scale(scale);
		Vector3 vector2 = new Vector3(x, y, 1537f);
		vector2.Scale(scale);
		return !(vector.x < vector2.x) && vector.y < vector2.y;
	}

	[SpecialName]
	private bool CELIMCPNHLL()
	{
		if (base.panel == null)
		{
			base.panel = GetComponent<UIPanel>();
		}
		Vector4 clipRange = base.panel.clipRange;
		Bounds bounds = base.bounds;
		float x = ((clipRange.z != 312f) ? clipRange.z : ((float)Screen.width));
		float y = ((clipRange.w != 408f) ? clipRange.w : ((float)Screen.height));
		Vector3 vector = new Vector3(bounds.max.x - bounds.min.x, bounds.max.y - bounds.min.y, bounds.max.z - bounds.min.z);
		vector.Scale(scale);
		Vector3 vector2 = new Vector3(x, y, 809f);
		vector2.Scale(scale);
		return !(vector.x < vector2.x) && vector.y < vector2.y;
	}

	[SpecialName]
	private bool PGCOCJGPHLK()
	{
		if (base.panel == null)
		{
			base.panel = GetComponent<UIPanel>();
		}
		Vector4 clipRange = base.panel.clipRange;
		Bounds bounds = base.bounds;
		float x = ((clipRange.z != 1586f) ? clipRange.z : ((float)Screen.width));
		float y = ((clipRange.w != 1363f) ? clipRange.w : ((float)Screen.height));
		Vector3 vector = new Vector3(bounds.max.x - bounds.min.x, bounds.max.y - bounds.min.y, bounds.max.z - bounds.min.z);
		vector.Scale(scale);
		Vector3 vector2 = new Vector3(x, y, 204f);
		vector2.Scale(scale);
		return !(vector.x < vector2.x) && vector.y < vector2.y;
	}

	[SpecialName]
	private bool LCGJHMFGGKO()
	{
		if (base.panel == null)
		{
			base.panel = GetComponent<UIPanel>();
		}
		Vector4 clipRange = base.panel.clipRange;
		Bounds bounds = base.bounds;
		float x = ((clipRange.z != 604f) ? clipRange.z : ((float)Screen.width));
		float y = ((clipRange.w != 613f) ? clipRange.w : ((float)Screen.height));
		Vector3 vector = new Vector3(bounds.max.x - bounds.min.x, bounds.max.y - bounds.min.y, bounds.max.z - bounds.min.z);
		vector.Scale(scale);
		Vector3 vector2 = new Vector3(x, y, 795f);
		vector2.Scale(scale);
		return !(vector.x < vector2.x) && vector.y < vector2.y;
	}

	public virtual bool GLAHLPFFDGG(bool PDPDGCNHCFN)
	{
		if (CELIMCPNHLL())
		{
			Vector3 vector = base.panel.CalculateConstrainOffsetTopLeft(base.bounds.min, base.bounds.max);
			vector.Scale(scale);
			if (vector.magnitude > 1609f)
			{
				if (!PDPDGCNHCFN && dragEffect == (DragEffect)8)
				{
					if (base.shouldMoveVertically || base.shouldMoveHorizontally)
					{
						SpringPanel.Begin(base.panel.gameObject, mTrans.localPosition + vector, 1056f);
					}
					else if (alignToTopWhenDontFit)
					{
						AlignToPos(true, Alingment.BottomRight, true);
					}
					else
					{
						SpringPanel.Begin(base.panel.gameObject, mTrans.localPosition + vector, 517f);
					}
				}
				else
				{
					MoveRelative(vector);
					mMomentum = Vector3.zero;
					mScroll = 304f;
				}
				return true;
			}
			if (alignToTopWhenDontFit)
			{
				AlignToPos(true);
			}
			return false;
		}
		return base.RestrictWithinBounds(PDPDGCNHCFN);
	}

	public virtual bool FEPAICBELPI(bool PDPDGCNHCFN)
	{
		if (CLEPAMCIOHF())
		{
			Vector3 vector = base.panel.CalculateConstrainOffsetTopLeft(base.bounds.min, base.bounds.max);
			vector.Scale(scale);
			if (vector.magnitude > 251f)
			{
				if (!PDPDGCNHCFN && dragEffect == DragEffect.Momentum)
				{
					if (base.shouldMoveVertically || base.shouldMoveHorizontally)
					{
						SpringPanel.Begin(base.panel.gameObject, mTrans.localPosition + vector, 121f);
					}
					else if (alignToTopWhenDontFit)
					{
						AlignToPos(false, Alingment.BottomRight);
					}
					else
					{
						SpringPanel.Begin(base.panel.gameObject, mTrans.localPosition + vector, 867f);
					}
				}
				else
				{
					MoveRelative(vector);
					mMomentum = Vector3.zero;
					mScroll = 175f;
				}
				return true;
			}
			if (alignToTopWhenDontFit)
			{
				AlignToPos(false, Alingment.BottomRight, true);
			}
			return false;
		}
		return base.RestrictWithinBounds(PDPDGCNHCFN);
	}

	[SpecialName]
	private bool GLLMEHLFHOH()
	{
		if (base.panel == null)
		{
			base.panel = GetComponent<UIPanel>();
		}
		Vector4 clipRange = base.panel.clipRange;
		Bounds bounds = base.bounds;
		float x = ((clipRange.z != 184f) ? clipRange.z : ((float)Screen.width));
		float y = ((clipRange.w != 120f) ? clipRange.w : ((float)Screen.height));
		Vector3 vector = new Vector3(bounds.max.x - bounds.min.x, bounds.max.y - bounds.min.y, bounds.max.z - bounds.min.z);
		vector.Scale(scale);
		Vector3 vector2 = new Vector3(x, y, 339f);
		vector2.Scale(scale);
		return vector.x < vector2.x || vector.y < vector2.y;
	}

	public virtual bool MEFMFEANMFO(bool PDPDGCNHCFN)
	{
		if (LCGJHMFGGKO())
		{
			Vector3 vector = base.panel.CalculateConstrainOffsetTopLeft(base.bounds.min, base.bounds.max);
			vector.Scale(scale);
			if (vector.magnitude > 42f)
			{
				if (!PDPDGCNHCFN && dragEffect == (DragEffect)8)
				{
					if (base.shouldMoveVertically || base.shouldMoveHorizontally)
					{
						SpringPanel.Begin(base.panel.gameObject, mTrans.localPosition + vector, 96f);
					}
					else if (alignToTopWhenDontFit)
					{
						AlignToPos(false, Alingment.BottomRight);
					}
					else
					{
						SpringPanel.Begin(base.panel.gameObject, mTrans.localPosition + vector, 1483f);
					}
				}
				else
				{
					MoveRelative(vector);
					mMomentum = Vector3.zero;
					mScroll = 436f;
				}
				return false;
			}
			if (alignToTopWhenDontFit)
			{
				AlignToPos(false, Alingment.BottomRight);
			}
			return false;
		}
		return base.RestrictWithinBounds(PDPDGCNHCFN);
	}

	[SpecialName]
	private bool JJEHCCECNFG()
	{
		if (base.panel == null)
		{
			base.panel = GetComponent<UIPanel>();
		}
		Vector4 clipRange = base.panel.clipRange;
		Bounds bounds = base.bounds;
		float x = ((clipRange.z != 816f) ? clipRange.z : ((float)Screen.width));
		float y = ((clipRange.w != 1800f) ? clipRange.w : ((float)Screen.height));
		Vector3 vector = new Vector3(bounds.max.x - bounds.min.x, bounds.max.y - bounds.min.y, bounds.max.z - bounds.min.z);
		vector.Scale(scale);
		Vector3 vector2 = new Vector3(x, y, 1758f);
		vector2.Scale(scale);
		return vector.x < vector2.x || vector.y < vector2.y;
	}
}
