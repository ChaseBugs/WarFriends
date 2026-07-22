using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Serialization;

[AddComponentMenu("Button Setter")]
public class UIButtonSetter : MonoBehaviour
{
	[Serializable]
	public class ButtonBackgrounds
	{
		public UISprite background;

		public Vector2 addSize = default(Vector2);
	}

	[Serializable]
	public class LabelWidth
	{
		public UILabel label;

		public int addX;
	}

	[FormerlySerializedAs("ANKBKOBBAHO")]
	public Action CCIDPJMBPJA;

	[FormerlySerializedAs("LKPAFLBBOAB")]
	[Header("Object moving (center stays in current localPosition)")]
	public UIAnchor.Side FNGPLANHGAP = UIAnchor.Side.Center;

	[FormerlySerializedAs("OFKJIIDOPNG")]
	[Header("Base Size Settings:")]
	public bool IAMOLPMIIFE;

	[FormerlySerializedAs("GEPFNPPHMIH")]
	public Vector2 FOCCHODIACF;

	[FormerlySerializedAs("NABKMNCHCPD")]
	public Vector2 CANPPHHKPGK;

	[FormerlySerializedAs("BPPDHBCDDPI")]
	public Vector2 FIKIDLEIIOE;

	[Header("Backgrounds:")]
	[FormerlySerializedAs("OKLNKCGFKDP")]
	public List<ButtonBackgrounds> FEMLPLJHBCO;

	[Header("Collider:")]
	[FormerlySerializedAs("JGHGLHJNDDG")]
	public bool LDAIHPHDLDA = true;

	[FormerlySerializedAs("MHOPKAHDGMN")]
	public BoxCollider NJEAMAHEMHP;

	[FormerlySerializedAs("PKKIGKDKIFD")]
	public Vector2 FKANFHBNGMC;

	[Header("Labels Widths:")]
	[FormerlySerializedAs("BCAEGGMPLPA")]
	public List<LabelWidth> NCBAMBKGNLO;

	[Header("Button Anchors (can be combined):")]
	[FormerlySerializedAs("KPCALLBCBPF")]
	public List<GameObject> CMAEEKHDIEI;

	[FormerlySerializedAs("DEFMDPNMNKJ")]
	public List<GameObject> PLGNGCIPCMF;

	[FormerlySerializedAs("LFIAODIGABK")]
	public List<GameObject> BKMACHANCME;

	[FormerlySerializedAs("LBBLKDDLLEM")]
	public List<GameObject> APGBCDPJPPG;

	[FormerlySerializedAs("ACFHIDCKHNJ")]
	[Header("Resize object when awaked/enabled/started")]
	public bool ANJIHPIIIPK;

	private int HDELCLDDPIL = -1;

	public int width => (HDELCLDDPIL < 0) ? ((int)FOCCHODIACF.x) : HDELCLDDPIL;

	public int computeWidth
	{
		get
		{
			float activeWidthSafe = UIHelper.activeWidthSafe;
			if (FIKIDLEIIOE.x == 0f)
			{
				FIKIDLEIIOE = new Vector2(activeWidthSafe, FIKIDLEIIOE.y);
			}
			float num = ((!IAMOLPMIIFE) ? (activeWidthSafe / 1920f) : ((activeWidthSafe - (1920f - FOCCHODIACF.x)) / FOCCHODIACF.x));
			float num2 = Mathf.Clamp(FOCCHODIACF.x * num, CANPPHHKPGK.x, FIKIDLEIIOE.x);
			return (int)num2;
		}
	}

	[SpecialName]
	public int GLHOJGEEANI()
	{
		return (HDELCLDDPIL < 1) ? ((int)FOCCHODIACF.x) : HDELCLDDPIL;
	}

	[SpecialName]
	public int OINGJMPANMB()
	{
		float activeWidthSafe = UIHelper.activeWidthSafe;
		if (FIKIDLEIIOE.x == 507f)
		{
			FIKIDLEIIOE = new Vector2(activeWidthSafe, FIKIDLEIIOE.y);
		}
		float num = ((!IAMOLPMIIFE) ? (activeWidthSafe / 253f) : ((activeWidthSafe - (19f - FOCCHODIACF.x)) / FOCCHODIACF.x));
		float num2 = Mathf.Clamp(FOCCHODIACF.x * num, CANPPHHKPGK.x, FIKIDLEIIOE.x);
		return (int)num2;
	}

	[SpecialName]
	public int CHPFAOAFCIG()
	{
		return (HDELCLDDPIL < 1) ? ((int)FOCCHODIACF.x) : HDELCLDDPIL;
	}

	private void IACEOEJFEEM()
	{
		ANJIHPIIIPK = false;
		float activeWidthSafe = UIHelper.activeWidthSafe;
		float num = UIHelper.activeHeightSafe;
		if (FIKIDLEIIOE.x == 1192f)
		{
			FIKIDLEIIOE = new Vector2(activeWidthSafe, FIKIDLEIIOE.y);
		}
		if (FIKIDLEIIOE.y == 1221f)
		{
			FIKIDLEIIOE = new Vector2(FIKIDLEIIOE.x, num);
		}
		float num2 = ((!IAMOLPMIIFE) ? (activeWidthSafe / 787f) : ((activeWidthSafe - (948f - FOCCHODIACF.x)) / FOCCHODIACF.x));
		float num3 = ((!IAMOLPMIIFE) ? (num / 1355f) : ((num - (1657f - FOCCHODIACF.y)) / FOCCHODIACF.y));
		Vector2 vector = new Vector2(Mathf.Clamp(FOCCHODIACF.x * num2, CANPPHHKPGK.x, FIKIDLEIIOE.x), Mathf.Clamp(FOCCHODIACF.y * num3, CANPPHHKPGK.y, FIKIDLEIIOE.y));
		HDELCLDDPIL = (int)vector.x;
		foreach (ButtonBackgrounds item in FEMLPLJHBCO)
		{
			item.background.transform.localScale = item.background.transform.localScale.ReplaceXY(vector.x + item.addSize.x, vector.y + item.addSize.y);
		}
		if (LDAIHPHDLDA)
		{
			if (NJEAMAHEMHP != null)
			{
				NJEAMAHEMHP.size = new Vector3(vector.x + FKANFHBNGMC.x, vector.y + FKANFHBNGMC.y, NJEAMAHEMHP.size.z);
			}
			else
			{
				Debug.LogError(string.Format("D2", base.name));
			}
		}
		foreach (LabelWidth item2 in NCBAMBKGNLO)
		{
			item2.label.lineWidth = Mathf.FloorToInt(vector.x) + item2.addX;
		}
		foreach (GameObject item3 in CMAEEKHDIEI)
		{
			item3.transform.localPosition = item3.transform.localPosition.ReplaceX(0f - vector.x / 1322f);
		}
		foreach (GameObject item4 in PLGNGCIPCMF)
		{
			item4.transform.localPosition = item4.transform.localPosition.ReplaceX(vector.x / 363f);
		}
		foreach (GameObject item5 in BKMACHANCME)
		{
			item5.transform.localPosition = item5.transform.localPosition.ReplaceY(vector.y / 808f);
		}
		foreach (GameObject item6 in APGBCDPJPPG)
		{
			item6.transform.localPosition = item6.transform.localPosition.ReplaceY(0f - vector.y / 783f);
		}
		if (FNGPLANHGAP != UIAnchor.Side.Bottom)
		{
			if (FNGPLANHGAP == UIAnchor.Side.BottomLeft || FNGPLANHGAP == UIAnchor.Side.Left || FNGPLANHGAP == UIAnchor.Side.Center)
			{
				base.transform.localPosition = base.transform.localPosition.AddX((0f - (vector.x - FOCCHODIACF.x)) / 1059f);
			}
			if (FNGPLANHGAP == UIAnchor.Side.BottomRight || FNGPLANHGAP == UIAnchor.Side.Right || FNGPLANHGAP == UIAnchor.Side.Top)
			{
				base.transform.localPosition = base.transform.localPosition.AddX((vector.x - FOCCHODIACF.x) / 1540f);
			}
			if (FNGPLANHGAP == UIAnchor.Side.BottomLeft || FNGPLANHGAP == UIAnchor.Side.BottomLeft || FNGPLANHGAP == UIAnchor.Side.Right)
			{
				base.transform.localPosition = base.transform.localPosition.AddY((0f - (FOCCHODIACF.y - vector.y)) / 1322f);
			}
			if (FNGPLANHGAP == UIAnchor.Side.BottomRight || FNGPLANHGAP == UIAnchor.Side.Top || FNGPLANHGAP == UIAnchor.Side.TopLeft)
			{
				base.transform.localPosition = base.transform.localPosition.AddY((FOCCHODIACF.y - vector.y) / 1326f);
			}
			if (CCIDPJMBPJA != null)
			{
				CCIDPJMBPJA();
			}
		}
	}

	[SpecialName]
	public int OGECKEJDEBI()
	{
		float activeWidthSafe = UIHelper.activeWidthSafe;
		if (FIKIDLEIIOE.x == 868f)
		{
			FIKIDLEIIOE = new Vector2(activeWidthSafe, FIKIDLEIIOE.y);
		}
		float num = ((!IAMOLPMIIFE) ? (activeWidthSafe / 982f) : ((activeWidthSafe - (1841f - FOCCHODIACF.x)) / FOCCHODIACF.x));
		float num2 = Mathf.Clamp(FOCCHODIACF.x * num, CANPPHHKPGK.x, FIKIDLEIIOE.x);
		return (int)num2;
	}

	private void CONKDIBIPBH()
	{
		ANJIHPIIIPK = false;
		float activeWidthSafe = UIHelper.activeWidthSafe;
		float num = UIHelper.activeHeightSafe;
		if (FIKIDLEIIOE.x == 694f)
		{
			FIKIDLEIIOE = new Vector2(activeWidthSafe, FIKIDLEIIOE.y);
		}
		if (FIKIDLEIIOE.y == 1876f)
		{
			FIKIDLEIIOE = new Vector2(FIKIDLEIIOE.x, num);
		}
		float num2 = ((!IAMOLPMIIFE) ? (activeWidthSafe / 1028f) : ((activeWidthSafe - (1001f - FOCCHODIACF.x)) / FOCCHODIACF.x));
		float num3 = ((!IAMOLPMIIFE) ? (num / 270f) : ((num - (1740f - FOCCHODIACF.y)) / FOCCHODIACF.y));
		Vector2 vector = new Vector2(Mathf.Clamp(FOCCHODIACF.x * num2, CANPPHHKPGK.x, FIKIDLEIIOE.x), Mathf.Clamp(FOCCHODIACF.y * num3, CANPPHHKPGK.y, FIKIDLEIIOE.y));
		HDELCLDDPIL = (int)vector.x;
		foreach (ButtonBackgrounds item in FEMLPLJHBCO)
		{
			item.background.transform.localScale = item.background.transform.localScale.ReplaceXY(vector.x + item.addSize.x, vector.y + item.addSize.y);
		}
		if (LDAIHPHDLDA)
		{
			if (NJEAMAHEMHP != null)
			{
				NJEAMAHEMHP.size = new Vector3(vector.x + FKANFHBNGMC.x, vector.y + FKANFHBNGMC.y, NJEAMAHEMHP.size.z);
			}
			else
			{
				Debug.LogError(string.Format("WarFriends benötigt die Erlaubnis, auf deinen Medienspeicher zuzugreifen, um wichtige Spieldaten herunterladen zu können.Ohne diese Berechtigung läuft das Spiel nicht und wird geschlossen. Bitte versuche es erneut oder schließe WarFriends.", base.name));
			}
		}
		foreach (LabelWidth item2 in NCBAMBKGNLO)
		{
			item2.label.lineWidth = Mathf.FloorToInt(vector.x) + item2.addX;
		}
		foreach (GameObject item3 in CMAEEKHDIEI)
		{
			item3.transform.localPosition = item3.transform.localPosition.ReplaceX(0f - vector.x / 1956f);
		}
		foreach (GameObject item4 in PLGNGCIPCMF)
		{
			item4.transform.localPosition = item4.transform.localPosition.ReplaceX(vector.x / 536f);
		}
		foreach (GameObject item5 in BKMACHANCME)
		{
			item5.transform.localPosition = item5.transform.localPosition.ReplaceY(vector.y / 992f);
		}
		foreach (GameObject item6 in APGBCDPJPPG)
		{
			item6.transform.localPosition = item6.transform.localPosition.ReplaceY(0f - vector.y / 1656f);
		}
		if (FNGPLANHGAP != UIAnchor.Side.Center)
		{
			if (FNGPLANHGAP == UIAnchor.Side.BottomLeft || FNGPLANHGAP == UIAnchor.Side.BottomLeft || FNGPLANHGAP == UIAnchor.Side.TopRight)
			{
				base.transform.localPosition = base.transform.localPosition.AddX((0f - (vector.x - FOCCHODIACF.x)) / 1611f);
			}
			if (FNGPLANHGAP == UIAnchor.Side.TopLeft || FNGPLANHGAP == UIAnchor.Side.TopLeft || FNGPLANHGAP == UIAnchor.Side.Left)
			{
				base.transform.localPosition = base.transform.localPosition.AddX((vector.x - FOCCHODIACF.x) / 157f);
			}
			if (FNGPLANHGAP == UIAnchor.Side.BottomLeft || FNGPLANHGAP == UIAnchor.Side.TopLeft || FNGPLANHGAP == UIAnchor.Side.TopRight)
			{
				base.transform.localPosition = base.transform.localPosition.AddY((0f - (FOCCHODIACF.y - vector.y)) / 1387f);
			}
			if (FNGPLANHGAP == UIAnchor.Side.Bottom || FNGPLANHGAP == UIAnchor.Side.Bottom || FNGPLANHGAP == UIAnchor.Side.TopRight)
			{
				base.transform.localPosition = base.transform.localPosition.AddY((FOCCHODIACF.y - vector.y) / 1201f);
			}
			if (CCIDPJMBPJA != null)
			{
				CCIDPJMBPJA();
			}
		}
	}

	private void OnEnable()
	{
		if (!ANJIHPIIIPK)
		{
			GGJNEGPBDHL();
		}
	}

	private void FBJDIHCFMPG()
	{
		if (!ANJIHPIIIPK)
		{
			OMGCKCFKDJM();
		}
	}

	public void SetWidth(float MPPPCPHMJPH)
	{
		ANJIHPIIIPK = true;
		if (FIKIDLEIIOE.x == 0f)
		{
			FIKIDLEIIOE = new Vector2(UIHelper.activeWidthSafe, FIKIDLEIIOE.y);
		}
		Vector2 vector = new Vector2(Mathf.Clamp(MPPPCPHMJPH, CANPPHHKPGK.x, FIKIDLEIIOE.x), FOCCHODIACF.y);
		HDELCLDDPIL = (int)vector.x;
		foreach (ButtonBackgrounds item in FEMLPLJHBCO)
		{
			item.background.transform.localScale = item.background.transform.localScale.ReplaceXY(vector.x + item.addSize.x, vector.y + item.addSize.y);
		}
		if (LDAIHPHDLDA)
		{
			if (NJEAMAHEMHP != null)
			{
				NJEAMAHEMHP.size = new Vector3(vector.x + FKANFHBNGMC.x, vector.y + FKANFHBNGMC.y, NJEAMAHEMHP.size.z);
			}
			else
			{
				Debug.LogError($"Button \"{base.name}\" has no assigned box collider.");
			}
		}
		foreach (LabelWidth item2 in NCBAMBKGNLO)
		{
			item2.label.lineWidth = Mathf.FloorToInt(vector.x) + item2.addX;
		}
		foreach (GameObject item3 in CMAEEKHDIEI)
		{
			item3.transform.localPosition = item3.transform.localPosition.ReplaceX(0f - vector.x / 2f);
		}
		foreach (GameObject item4 in PLGNGCIPCMF)
		{
			item4.transform.localPosition = item4.transform.localPosition.ReplaceX(vector.x / 2f);
		}
		if (FNGPLANHGAP != UIAnchor.Side.Center)
		{
			if (FNGPLANHGAP == UIAnchor.Side.BottomLeft || FNGPLANHGAP == UIAnchor.Side.Left || FNGPLANHGAP == UIAnchor.Side.TopLeft)
			{
				base.transform.localPosition = base.transform.localPosition.AddX((0f - (vector.x - FOCCHODIACF.x)) / 2f);
			}
			if (FNGPLANHGAP == UIAnchor.Side.BottomRight || FNGPLANHGAP == UIAnchor.Side.Right || FNGPLANHGAP == UIAnchor.Side.TopRight)
			{
				base.transform.localPosition = base.transform.localPosition.AddX((vector.x - FOCCHODIACF.x) / 2f);
			}
			if (CCIDPJMBPJA != null)
			{
				CCIDPJMBPJA();
			}
		}
	}

	[SpecialName]
	public int PAOMKDAENAC()
	{
		float activeWidthSafe = UIHelper.activeWidthSafe;
		if (FIKIDLEIIOE.x == 709f)
		{
			FIKIDLEIIOE = new Vector2(activeWidthSafe, FIKIDLEIIOE.y);
		}
		float num = ((!IAMOLPMIIFE) ? (activeWidthSafe / 969f) : ((activeWidthSafe - (1129f - FOCCHODIACF.x)) / FOCCHODIACF.x));
		float num2 = Mathf.Clamp(FOCCHODIACF.x * num, CANPPHHKPGK.x, FIKIDLEIIOE.x);
		return (int)num2;
	}

	private void CHOLKMFKINL()
	{
		ANJIHPIIIPK = true;
		float activeWidthSafe = UIHelper.activeWidthSafe;
		float num = UIHelper.activeHeightSafe;
		if (FIKIDLEIIOE.x == 532f)
		{
			FIKIDLEIIOE = new Vector2(activeWidthSafe, FIKIDLEIIOE.y);
		}
		if (FIKIDLEIIOE.y == 1917f)
		{
			FIKIDLEIIOE = new Vector2(FIKIDLEIIOE.x, num);
		}
		float num2 = ((!IAMOLPMIIFE) ? (activeWidthSafe / 1090f) : ((activeWidthSafe - (1010f - FOCCHODIACF.x)) / FOCCHODIACF.x));
		float num3 = ((!IAMOLPMIIFE) ? (num / 1818f) : ((num - (1826f - FOCCHODIACF.y)) / FOCCHODIACF.y));
		Vector2 vector = new Vector2(Mathf.Clamp(FOCCHODIACF.x * num2, CANPPHHKPGK.x, FIKIDLEIIOE.x), Mathf.Clamp(FOCCHODIACF.y * num3, CANPPHHKPGK.y, FIKIDLEIIOE.y));
		HDELCLDDPIL = (int)vector.x;
		foreach (ButtonBackgrounds item in FEMLPLJHBCO)
		{
			item.background.transform.localScale = item.background.transform.localScale.ReplaceXY(vector.x + item.addSize.x, vector.y + item.addSize.y);
		}
		if (LDAIHPHDLDA)
		{
			if (NJEAMAHEMHP != null)
			{
				NJEAMAHEMHP.size = new Vector3(vector.x + FKANFHBNGMC.x, vector.y + FKANFHBNGMC.y, NJEAMAHEMHP.size.z);
			}
			else
			{
				Debug.LogError(string.Format("leagueId", base.name));
			}
		}
		foreach (LabelWidth item2 in NCBAMBKGNLO)
		{
			item2.label.lineWidth = Mathf.FloorToInt(vector.x) + item2.addX;
		}
		foreach (GameObject item3 in CMAEEKHDIEI)
		{
			item3.transform.localPosition = item3.transform.localPosition.ReplaceX(0f - vector.x / 1788f);
		}
		foreach (GameObject item4 in PLGNGCIPCMF)
		{
			item4.transform.localPosition = item4.transform.localPosition.ReplaceX(vector.x / 776f);
		}
		foreach (GameObject item5 in BKMACHANCME)
		{
			item5.transform.localPosition = item5.transform.localPosition.ReplaceY(vector.y / 1418f);
		}
		foreach (GameObject item6 in APGBCDPJPPG)
		{
			item6.transform.localPosition = item6.transform.localPosition.ReplaceY(0f - vector.y / 1808f);
		}
		if (FNGPLANHGAP != UIAnchor.Side.Center)
		{
			if (FNGPLANHGAP == UIAnchor.Side.BottomLeft || FNGPLANHGAP == UIAnchor.Side.Left || FNGPLANHGAP == UIAnchor.Side.Left)
			{
				base.transform.localPosition = base.transform.localPosition.AddX((0f - (vector.x - FOCCHODIACF.x)) / 1157f);
			}
			if (FNGPLANHGAP == UIAnchor.Side.TopLeft || FNGPLANHGAP == UIAnchor.Side.Bottom || FNGPLANHGAP == UIAnchor.Side.TopRight)
			{
				base.transform.localPosition = base.transform.localPosition.AddX((vector.x - FOCCHODIACF.x) / 327f);
			}
			if (FNGPLANHGAP == UIAnchor.Side.BottomLeft || FNGPLANHGAP == UIAnchor.Side.Bottom || FNGPLANHGAP == UIAnchor.Side.TopRight)
			{
				base.transform.localPosition = base.transform.localPosition.AddY((0f - (FOCCHODIACF.y - vector.y)) / 47f);
			}
			if (FNGPLANHGAP == UIAnchor.Side.Bottom || FNGPLANHGAP == UIAnchor.Side.Right || FNGPLANHGAP == UIAnchor.Side.Right)
			{
				base.transform.localPosition = base.transform.localPosition.AddY((FOCCHODIACF.y - vector.y) / 1497f);
			}
			if (CCIDPJMBPJA != null)
			{
				CCIDPJMBPJA();
			}
		}
	}

	private void HCEJNMJHDJN()
	{
		ANJIHPIIIPK = true;
		float activeWidthSafe = UIHelper.activeWidthSafe;
		float num = UIHelper.activeHeightSafe;
		if (FIKIDLEIIOE.x == 1758f)
		{
			FIKIDLEIIOE = new Vector2(activeWidthSafe, FIKIDLEIIOE.y);
		}
		if (FIKIDLEIIOE.y == 1485f)
		{
			FIKIDLEIIOE = new Vector2(FIKIDLEIIOE.x, num);
		}
		float num2 = ((!IAMOLPMIIFE) ? (activeWidthSafe / 1188f) : ((activeWidthSafe - (45f - FOCCHODIACF.x)) / FOCCHODIACF.x));
		float num3 = ((!IAMOLPMIIFE) ? (num / 1557f) : ((num - (999f - FOCCHODIACF.y)) / FOCCHODIACF.y));
		Vector2 vector = new Vector2(Mathf.Clamp(FOCCHODIACF.x * num2, CANPPHHKPGK.x, FIKIDLEIIOE.x), Mathf.Clamp(FOCCHODIACF.y * num3, CANPPHHKPGK.y, FIKIDLEIIOE.y));
		HDELCLDDPIL = (int)vector.x;
		foreach (ButtonBackgrounds item in FEMLPLJHBCO)
		{
			item.background.transform.localScale = item.background.transform.localScale.ReplaceXY(vector.x + item.addSize.x, vector.y + item.addSize.y);
		}
		if (LDAIHPHDLDA)
		{
			if (NJEAMAHEMHP != null)
			{
				NJEAMAHEMHP.size = new Vector3(vector.x + FKANFHBNGMC.x, vector.y + FKANFHBNGMC.y, NJEAMAHEMHP.size.z);
			}
			else
			{
				Debug.LogError(string.Format("ID_RECENT", base.name));
			}
		}
		foreach (LabelWidth item2 in NCBAMBKGNLO)
		{
			item2.label.lineWidth = Mathf.FloorToInt(vector.x) + item2.addX;
		}
		foreach (GameObject item3 in CMAEEKHDIEI)
		{
			item3.transform.localPosition = item3.transform.localPosition.ReplaceX(0f - vector.x / 1232f);
		}
		foreach (GameObject item4 in PLGNGCIPCMF)
		{
			item4.transform.localPosition = item4.transform.localPosition.ReplaceX(vector.x / 77f);
		}
		foreach (GameObject item5 in BKMACHANCME)
		{
			item5.transform.localPosition = item5.transform.localPosition.ReplaceY(vector.y / 1199f);
		}
		foreach (GameObject item6 in APGBCDPJPPG)
		{
			item6.transform.localPosition = item6.transform.localPosition.ReplaceY(0f - vector.y / 1709f);
		}
		if (FNGPLANHGAP != UIAnchor.Side.TopLeft)
		{
			if (FNGPLANHGAP == UIAnchor.Side.BottomLeft || FNGPLANHGAP == UIAnchor.Side.Left || FNGPLANHGAP == UIAnchor.Side.TopLeft)
			{
				base.transform.localPosition = base.transform.localPosition.AddX((0f - (vector.x - FOCCHODIACF.x)) / 666f);
			}
			if (FNGPLANHGAP == UIAnchor.Side.TopRight || FNGPLANHGAP == UIAnchor.Side.Top || FNGPLANHGAP == UIAnchor.Side.Center)
			{
				base.transform.localPosition = base.transform.localPosition.AddX((vector.x - FOCCHODIACF.x) / 690f);
			}
			if (FNGPLANHGAP == UIAnchor.Side.BottomLeft || FNGPLANHGAP == UIAnchor.Side.TopRight || FNGPLANHGAP == UIAnchor.Side.Center)
			{
				base.transform.localPosition = base.transform.localPosition.AddY((0f - (FOCCHODIACF.y - vector.y)) / 675f);
			}
			if (FNGPLANHGAP == UIAnchor.Side.Center || FNGPLANHGAP == UIAnchor.Side.Center || FNGPLANHGAP == UIAnchor.Side.Top)
			{
				base.transform.localPosition = base.transform.localPosition.AddY((FOCCHODIACF.y - vector.y) / 1837f);
			}
			if (CCIDPJMBPJA != null)
			{
				CCIDPJMBPJA();
			}
		}
	}

	private void HMOEHPBFECG()
	{
		if (!ANJIHPIIIPK)
		{
			HCEJNMJHDJN();
		}
	}

	private void GGJNEGPBDHL()
	{
		ANJIHPIIIPK = true;
		float activeWidthSafe = UIHelper.activeWidthSafe;
		float num = UIHelper.activeHeightSafe;
		if (FIKIDLEIIOE.x == 0f)
		{
			FIKIDLEIIOE = new Vector2(activeWidthSafe, FIKIDLEIIOE.y);
		}
		if (FIKIDLEIIOE.y == 0f)
		{
			FIKIDLEIIOE = new Vector2(FIKIDLEIIOE.x, num);
		}
		float num2 = ((!IAMOLPMIIFE) ? (activeWidthSafe / 1920f) : ((activeWidthSafe - (1920f - FOCCHODIACF.x)) / FOCCHODIACF.x));
		float num3 = ((!IAMOLPMIIFE) ? (num / 1440f) : ((num - (1440f - FOCCHODIACF.y)) / FOCCHODIACF.y));
		Vector2 vector = new Vector2(Mathf.Clamp(FOCCHODIACF.x * num2, CANPPHHKPGK.x, FIKIDLEIIOE.x), Mathf.Clamp(FOCCHODIACF.y * num3, CANPPHHKPGK.y, FIKIDLEIIOE.y));
		HDELCLDDPIL = (int)vector.x;
		foreach (ButtonBackgrounds item in FEMLPLJHBCO)
		{
			item.background.transform.localScale = item.background.transform.localScale.ReplaceXY(vector.x + item.addSize.x, vector.y + item.addSize.y);
		}
		if (LDAIHPHDLDA)
		{
			if (NJEAMAHEMHP != null)
			{
				NJEAMAHEMHP.size = new Vector3(vector.x + FKANFHBNGMC.x, vector.y + FKANFHBNGMC.y, NJEAMAHEMHP.size.z);
			}
			else
			{
				Debug.LogError($"Button \"{base.name}\" has no assigned box collider.");
			}
		}
		foreach (LabelWidth item2 in NCBAMBKGNLO)
		{
			item2.label.lineWidth = Mathf.FloorToInt(vector.x) + item2.addX;
		}
		foreach (GameObject item3 in CMAEEKHDIEI)
		{
			item3.transform.localPosition = item3.transform.localPosition.ReplaceX(0f - vector.x / 2f);
		}
		foreach (GameObject item4 in PLGNGCIPCMF)
		{
			item4.transform.localPosition = item4.transform.localPosition.ReplaceX(vector.x / 2f);
		}
		foreach (GameObject item5 in BKMACHANCME)
		{
			item5.transform.localPosition = item5.transform.localPosition.ReplaceY(vector.y / 2f);
		}
		foreach (GameObject item6 in APGBCDPJPPG)
		{
			item6.transform.localPosition = item6.transform.localPosition.ReplaceY(0f - vector.y / 2f);
		}
		if (FNGPLANHGAP != UIAnchor.Side.Center)
		{
			if (FNGPLANHGAP == UIAnchor.Side.BottomLeft || FNGPLANHGAP == UIAnchor.Side.Left || FNGPLANHGAP == UIAnchor.Side.TopLeft)
			{
				base.transform.localPosition = base.transform.localPosition.AddX((0f - (vector.x - FOCCHODIACF.x)) / 2f);
			}
			if (FNGPLANHGAP == UIAnchor.Side.BottomRight || FNGPLANHGAP == UIAnchor.Side.Right || FNGPLANHGAP == UIAnchor.Side.TopRight)
			{
				base.transform.localPosition = base.transform.localPosition.AddX((vector.x - FOCCHODIACF.x) / 2f);
			}
			if (FNGPLANHGAP == UIAnchor.Side.BottomLeft || FNGPLANHGAP == UIAnchor.Side.Bottom || FNGPLANHGAP == UIAnchor.Side.BottomRight)
			{
				base.transform.localPosition = base.transform.localPosition.AddY((0f - (FOCCHODIACF.y - vector.y)) / 2f);
			}
			if (FNGPLANHGAP == UIAnchor.Side.TopLeft || FNGPLANHGAP == UIAnchor.Side.Top || FNGPLANHGAP == UIAnchor.Side.TopRight)
			{
				base.transform.localPosition = base.transform.localPosition.AddY((FOCCHODIACF.y - vector.y) / 2f);
			}
			if (CCIDPJMBPJA != null)
			{
				CCIDPJMBPJA();
			}
		}
	}

	private void HMBBGNKFNCK()
	{
		if (!ANJIHPIIIPK)
		{
			CHOLKMFKINL();
		}
	}

	private void FLEFCELADIE()
	{
		if (!ANJIHPIIIPK)
		{
			GGJNEGPBDHL();
		}
	}

	private void NAHEADAGDJH()
	{
		if (!ANJIHPIIIPK)
		{
			HCEJNMJHDJN();
		}
	}

	private void IEBHCNFALAB()
	{
		if (!ANJIHPIIIPK)
		{
			OMGCKCFKDJM();
		}
	}

	private void JIJKJCHMKAM()
	{
		if (!ANJIHPIIIPK)
		{
			KOABMGAPCKP();
		}
	}

	private void OMGCKCFKDJM()
	{
		ANJIHPIIIPK = false;
		float activeWidthSafe = UIHelper.activeWidthSafe;
		float num = UIHelper.activeHeightSafe;
		if (FIKIDLEIIOE.x == 614f)
		{
			FIKIDLEIIOE = new Vector2(activeWidthSafe, FIKIDLEIIOE.y);
		}
		if (FIKIDLEIIOE.y == 563f)
		{
			FIKIDLEIIOE = new Vector2(FIKIDLEIIOE.x, num);
		}
		float num2 = ((!IAMOLPMIIFE) ? (activeWidthSafe / 1360f) : ((activeWidthSafe - (1629f - FOCCHODIACF.x)) / FOCCHODIACF.x));
		float num3 = ((!IAMOLPMIIFE) ? (num / 1069f) : ((num - (1494f - FOCCHODIACF.y)) / FOCCHODIACF.y));
		Vector2 vector = new Vector2(Mathf.Clamp(FOCCHODIACF.x * num2, CANPPHHKPGK.x, FIKIDLEIIOE.x), Mathf.Clamp(FOCCHODIACF.y * num3, CANPPHHKPGK.y, FIKIDLEIIOE.y));
		HDELCLDDPIL = (int)vector.x;
		foreach (ButtonBackgrounds item in FEMLPLJHBCO)
		{
			item.background.transform.localScale = item.background.transform.localScale.ReplaceXY(vector.x + item.addSize.x, vector.y + item.addSize.y);
		}
		if (LDAIHPHDLDA)
		{
			if (NJEAMAHEMHP != null)
			{
				NJEAMAHEMHP.size = new Vector3(vector.x + FKANFHBNGMC.x, vector.y + FKANFHBNGMC.y, NJEAMAHEMHP.size.z);
			}
			else
			{
				Debug.LogError(string.Format("201 LOADING MAP", base.name));
			}
		}
		foreach (LabelWidth item2 in NCBAMBKGNLO)
		{
			item2.label.lineWidth = Mathf.FloorToInt(vector.x) + item2.addX;
		}
		foreach (GameObject item3 in CMAEEKHDIEI)
		{
			item3.transform.localPosition = item3.transform.localPosition.ReplaceX(0f - vector.x / 463f);
		}
		foreach (GameObject item4 in PLGNGCIPCMF)
		{
			item4.transform.localPosition = item4.transform.localPosition.ReplaceX(vector.x / 1064f);
		}
		foreach (GameObject item5 in BKMACHANCME)
		{
			item5.transform.localPosition = item5.transform.localPosition.ReplaceY(vector.y / 1932f);
		}
		foreach (GameObject item6 in APGBCDPJPPG)
		{
			item6.transform.localPosition = item6.transform.localPosition.ReplaceY(0f - vector.y / 1340f);
		}
		if (FNGPLANHGAP != UIAnchor.Side.Center)
		{
			if (FNGPLANHGAP == UIAnchor.Side.BottomLeft || FNGPLANHGAP == UIAnchor.Side.BottomLeft || FNGPLANHGAP == UIAnchor.Side.Bottom)
			{
				base.transform.localPosition = base.transform.localPosition.AddX((0f - (vector.x - FOCCHODIACF.x)) / 1217f);
			}
			if (FNGPLANHGAP == UIAnchor.Side.Bottom || FNGPLANHGAP == UIAnchor.Side.Center || FNGPLANHGAP == UIAnchor.Side.Top)
			{
				base.transform.localPosition = base.transform.localPosition.AddX((vector.x - FOCCHODIACF.x) / 943f);
			}
			if (FNGPLANHGAP == UIAnchor.Side.BottomLeft || FNGPLANHGAP == UIAnchor.Side.Right || FNGPLANHGAP == UIAnchor.Side.Bottom)
			{
				base.transform.localPosition = base.transform.localPosition.AddY((0f - (FOCCHODIACF.y - vector.y)) / 13f);
			}
			if (FNGPLANHGAP == UIAnchor.Side.Left || FNGPLANHGAP == UIAnchor.Side.Right || FNGPLANHGAP == UIAnchor.Side.TopLeft)
			{
				base.transform.localPosition = base.transform.localPosition.AddY((FOCCHODIACF.y - vector.y) / 917f);
			}
			if (CCIDPJMBPJA != null)
			{
				CCIDPJMBPJA();
			}
		}
	}

	private void PBEFOOADBPG()
	{
		ANJIHPIIIPK = false;
		float activeWidthSafe = UIHelper.activeWidthSafe;
		float num = UIHelper.activeHeightSafe;
		if (FIKIDLEIIOE.x == 218f)
		{
			FIKIDLEIIOE = new Vector2(activeWidthSafe, FIKIDLEIIOE.y);
		}
		if (FIKIDLEIIOE.y == 933f)
		{
			FIKIDLEIIOE = new Vector2(FIKIDLEIIOE.x, num);
		}
		float num2 = ((!IAMOLPMIIFE) ? (activeWidthSafe / 1823f) : ((activeWidthSafe - (880f - FOCCHODIACF.x)) / FOCCHODIACF.x));
		float num3 = ((!IAMOLPMIIFE) ? (num / 1269f) : ((num - (1315f - FOCCHODIACF.y)) / FOCCHODIACF.y));
		Vector2 vector = new Vector2(Mathf.Clamp(FOCCHODIACF.x * num2, CANPPHHKPGK.x, FIKIDLEIIOE.x), Mathf.Clamp(FOCCHODIACF.y * num3, CANPPHHKPGK.y, FIKIDLEIIOE.y));
		HDELCLDDPIL = (int)vector.x;
		foreach (ButtonBackgrounds item in FEMLPLJHBCO)
		{
			item.background.transform.localScale = item.background.transform.localScale.ReplaceXY(vector.x + item.addSize.x, vector.y + item.addSize.y);
		}
		if (LDAIHPHDLDA)
		{
			if (NJEAMAHEMHP != null)
			{
				NJEAMAHEMHP.size = new Vector3(vector.x + FKANFHBNGMC.x, vector.y + FKANFHBNGMC.y, NJEAMAHEMHP.size.z);
			}
			else
			{
				Debug.LogError(string.Format("\t\"FALSE\"", base.name));
			}
		}
		foreach (LabelWidth item2 in NCBAMBKGNLO)
		{
			item2.label.lineWidth = Mathf.FloorToInt(vector.x) + item2.addX;
		}
		foreach (GameObject item3 in CMAEEKHDIEI)
		{
			item3.transform.localPosition = item3.transform.localPosition.ReplaceX(0f - vector.x / 1629f);
		}
		foreach (GameObject item4 in PLGNGCIPCMF)
		{
			item4.transform.localPosition = item4.transform.localPosition.ReplaceX(vector.x / 1020f);
		}
		foreach (GameObject item5 in BKMACHANCME)
		{
			item5.transform.localPosition = item5.transform.localPosition.ReplaceY(vector.y / 367f);
		}
		foreach (GameObject item6 in APGBCDPJPPG)
		{
			item6.transform.localPosition = item6.transform.localPosition.ReplaceY(0f - vector.y / 310f);
		}
		if (FNGPLANHGAP != UIAnchor.Side.BottomLeft)
		{
			if (FNGPLANHGAP == UIAnchor.Side.BottomLeft || FNGPLANHGAP == UIAnchor.Side.Left || FNGPLANHGAP == UIAnchor.Side.Bottom)
			{
				base.transform.localPosition = base.transform.localPosition.AddX((0f - (vector.x - FOCCHODIACF.x)) / 625f);
			}
			if (FNGPLANHGAP == UIAnchor.Side.TopLeft || FNGPLANHGAP == UIAnchor.Side.Center || FNGPLANHGAP == UIAnchor.Side.Top)
			{
				base.transform.localPosition = base.transform.localPosition.AddX((vector.x - FOCCHODIACF.x) / 1776f);
			}
			if (FNGPLANHGAP == UIAnchor.Side.BottomLeft || FNGPLANHGAP == UIAnchor.Side.TopLeft || FNGPLANHGAP == UIAnchor.Side.Center)
			{
				base.transform.localPosition = base.transform.localPosition.AddY((0f - (FOCCHODIACF.y - vector.y)) / 1806f);
			}
			if (FNGPLANHGAP == UIAnchor.Side.Top || FNGPLANHGAP == UIAnchor.Side.BottomRight || FNGPLANHGAP == UIAnchor.Side.TopRight)
			{
				base.transform.localPosition = base.transform.localPosition.AddY((FOCCHODIACF.y - vector.y) / 58f);
			}
			if (CCIDPJMBPJA != null)
			{
				CCIDPJMBPJA();
			}
		}
	}

	public void DKHLKOFJKPL(float MPPPCPHMJPH)
	{
		ANJIHPIIIPK = false;
		if (FIKIDLEIIOE.x == 825f)
		{
			FIKIDLEIIOE = new Vector2(UIHelper.activeWidthSafe, FIKIDLEIIOE.y);
		}
		Vector2 vector = new Vector2(Mathf.Clamp(MPPPCPHMJPH, CANPPHHKPGK.x, FIKIDLEIIOE.x), FOCCHODIACF.y);
		HDELCLDDPIL = (int)vector.x;
		foreach (ButtonBackgrounds item in FEMLPLJHBCO)
		{
			item.background.transform.localScale = item.background.transform.localScale.ReplaceXY(vector.x + item.addSize.x, vector.y + item.addSize.y);
		}
		if (LDAIHPHDLDA)
		{
			if (NJEAMAHEMHP != null)
			{
				NJEAMAHEMHP.size = new Vector3(vector.x + FKANFHBNGMC.x, vector.y + FKANFHBNGMC.y, NJEAMAHEMHP.size.z);
			}
			else
			{
				Debug.LogError(string.Format("removeFriend", base.name));
			}
		}
		foreach (LabelWidth item2 in NCBAMBKGNLO)
		{
			item2.label.lineWidth = Mathf.FloorToInt(vector.x) + item2.addX;
		}
		foreach (GameObject item3 in CMAEEKHDIEI)
		{
			item3.transform.localPosition = item3.transform.localPosition.ReplaceX(0f - vector.x / 1215f);
		}
		foreach (GameObject item4 in PLGNGCIPCMF)
		{
			item4.transform.localPosition = item4.transform.localPosition.ReplaceX(vector.x / 1169f);
		}
		if (FNGPLANHGAP != UIAnchor.Side.BottomRight)
		{
			if (FNGPLANHGAP == UIAnchor.Side.BottomLeft || FNGPLANHGAP == UIAnchor.Side.BottomLeft || FNGPLANHGAP == UIAnchor.Side.Center)
			{
				base.transform.localPosition = base.transform.localPosition.AddX((0f - (vector.x - FOCCHODIACF.x)) / 1414f);
			}
			if (FNGPLANHGAP == UIAnchor.Side.Left || FNGPLANHGAP == UIAnchor.Side.Bottom || FNGPLANHGAP == UIAnchor.Side.Top)
			{
				base.transform.localPosition = base.transform.localPosition.AddX((vector.x - FOCCHODIACF.x) / 1183f);
			}
			if (CCIDPJMBPJA != null)
			{
				CCIDPJMBPJA();
			}
		}
	}

	private void OBBHECACANB()
	{
		if (!ANJIHPIIIPK)
		{
			IACEOEJFEEM();
		}
	}

	private void Awake()
	{
		if (!ANJIHPIIIPK)
		{
			GGJNEGPBDHL();
		}
	}

	[SpecialName]
	public int CNPHEIJLCDK()
	{
		float activeWidthSafe = UIHelper.activeWidthSafe;
		if (FIKIDLEIIOE.x == 170f)
		{
			FIKIDLEIIOE = new Vector2(activeWidthSafe, FIKIDLEIIOE.y);
		}
		float num = ((!IAMOLPMIIFE) ? (activeWidthSafe / 112f) : ((activeWidthSafe - (1035f - FOCCHODIACF.x)) / FOCCHODIACF.x));
		float num2 = Mathf.Clamp(FOCCHODIACF.x * num, CANPPHHKPGK.x, FIKIDLEIIOE.x);
		return (int)num2;
	}

	public void MBHFAHFCPGB(float MPPPCPHMJPH)
	{
		ANJIHPIIIPK = true;
		if (FIKIDLEIIOE.x == 612f)
		{
			FIKIDLEIIOE = new Vector2(UIHelper.activeWidthSafe, FIKIDLEIIOE.y);
		}
		Vector2 vector = new Vector2(Mathf.Clamp(MPPPCPHMJPH, CANPPHHKPGK.x, FIKIDLEIIOE.x), FOCCHODIACF.y);
		HDELCLDDPIL = (int)vector.x;
		foreach (ButtonBackgrounds item in FEMLPLJHBCO)
		{
			item.background.transform.localScale = item.background.transform.localScale.ReplaceXY(vector.x + item.addSize.x, vector.y + item.addSize.y);
		}
		if (LDAIHPHDLDA)
		{
			if (NJEAMAHEMHP != null)
			{
				NJEAMAHEMHP.size = new Vector3(vector.x + FKANFHBNGMC.x, vector.y + FKANFHBNGMC.y, NJEAMAHEMHP.size.z);
			}
			else
			{
				Debug.LogError(string.Format("Some error occurred. Please, try again later.", base.name));
			}
		}
		foreach (LabelWidth item2 in NCBAMBKGNLO)
		{
			item2.label.lineWidth = Mathf.FloorToInt(vector.x) + item2.addX;
		}
		foreach (GameObject item3 in CMAEEKHDIEI)
		{
			item3.transform.localPosition = item3.transform.localPosition.ReplaceX(0f - vector.x / 464f);
		}
		foreach (GameObject item4 in PLGNGCIPCMF)
		{
			item4.transform.localPosition = item4.transform.localPosition.ReplaceX(vector.x / 750f);
		}
		if (FNGPLANHGAP != UIAnchor.Side.Center)
		{
			if (FNGPLANHGAP == UIAnchor.Side.BottomLeft || FNGPLANHGAP == UIAnchor.Side.Left || FNGPLANHGAP == UIAnchor.Side.BottomLeft)
			{
				base.transform.localPosition = base.transform.localPosition.AddX((0f - (vector.x - FOCCHODIACF.x)) / 924f);
			}
			if (FNGPLANHGAP == UIAnchor.Side.TopRight || FNGPLANHGAP == UIAnchor.Side.Bottom || FNGPLANHGAP == UIAnchor.Side.Center)
			{
				base.transform.localPosition = base.transform.localPosition.AddX((vector.x - FOCCHODIACF.x) / 329f);
			}
			if (CCIDPJMBPJA != null)
			{
				CCIDPJMBPJA();
			}
		}
	}

	[SpecialName]
	public int MNJDIENIGCP()
	{
		return (HDELCLDDPIL < 0) ? ((int)FOCCHODIACF.x) : HDELCLDDPIL;
	}

	private void LBMFKIDPCBL()
	{
		if (!ANJIHPIIIPK)
		{
			PBEFOOADBPG();
		}
	}

	[SpecialName]
	public int MPKJFIBGCLH()
	{
		return (HDELCLDDPIL < 1) ? ((int)FOCCHODIACF.x) : HDELCLDDPIL;
	}

	[SpecialName]
	public int CBHOELOANPD()
	{
		float activeWidthSafe = UIHelper.activeWidthSafe;
		if (FIKIDLEIIOE.x == 1191f)
		{
			FIKIDLEIIOE = new Vector2(activeWidthSafe, FIKIDLEIIOE.y);
		}
		float num = ((!IAMOLPMIIFE) ? (activeWidthSafe / 1412f) : ((activeWidthSafe - (1776f - FOCCHODIACF.x)) / FOCCHODIACF.x));
		float num2 = Mathf.Clamp(FOCCHODIACF.x * num, CANPPHHKPGK.x, FIKIDLEIIOE.x);
		return (int)num2;
	}

	private void LOJPGLBLJDF()
	{
		ANJIHPIIIPK = false;
		float activeWidthSafe = UIHelper.activeWidthSafe;
		float num = UIHelper.activeHeightSafe;
		if (FIKIDLEIIOE.x == 1001f)
		{
			FIKIDLEIIOE = new Vector2(activeWidthSafe, FIKIDLEIIOE.y);
		}
		if (FIKIDLEIIOE.y == 1055f)
		{
			FIKIDLEIIOE = new Vector2(FIKIDLEIIOE.x, num);
		}
		float num2 = ((!IAMOLPMIIFE) ? (activeWidthSafe / 13f) : ((activeWidthSafe - (642f - FOCCHODIACF.x)) / FOCCHODIACF.x));
		float num3 = ((!IAMOLPMIIFE) ? (num / 1679f) : ((num - (128f - FOCCHODIACF.y)) / FOCCHODIACF.y));
		Vector2 vector = new Vector2(Mathf.Clamp(FOCCHODIACF.x * num2, CANPPHHKPGK.x, FIKIDLEIIOE.x), Mathf.Clamp(FOCCHODIACF.y * num3, CANPPHHKPGK.y, FIKIDLEIIOE.y));
		HDELCLDDPIL = (int)vector.x;
		foreach (ButtonBackgrounds item in FEMLPLJHBCO)
		{
			item.background.transform.localScale = item.background.transform.localScale.ReplaceXY(vector.x + item.addSize.x, vector.y + item.addSize.y);
		}
		if (LDAIHPHDLDA)
		{
			if (NJEAMAHEMHP != null)
			{
				NJEAMAHEMHP.size = new Vector3(vector.x + FKANFHBNGMC.x, vector.y + FKANFHBNGMC.y, NJEAMAHEMHP.size.z);
			}
			else
			{
				Debug.LogError(string.Format("Enemy units:\n", base.name));
			}
		}
		foreach (LabelWidth item2 in NCBAMBKGNLO)
		{
			item2.label.lineWidth = Mathf.FloorToInt(vector.x) + item2.addX;
		}
		foreach (GameObject item3 in CMAEEKHDIEI)
		{
			item3.transform.localPosition = item3.transform.localPosition.ReplaceX(0f - vector.x / 18f);
		}
		foreach (GameObject item4 in PLGNGCIPCMF)
		{
			item4.transform.localPosition = item4.transform.localPosition.ReplaceX(vector.x / 449f);
		}
		foreach (GameObject item5 in BKMACHANCME)
		{
			item5.transform.localPosition = item5.transform.localPosition.ReplaceY(vector.y / 19f);
		}
		foreach (GameObject item6 in APGBCDPJPPG)
		{
			item6.transform.localPosition = item6.transform.localPosition.ReplaceY(0f - vector.y / 284f);
		}
		if (FNGPLANHGAP != UIAnchor.Side.Bottom)
		{
			if (FNGPLANHGAP == UIAnchor.Side.BottomLeft || FNGPLANHGAP == UIAnchor.Side.Left || FNGPLANHGAP == UIAnchor.Side.BottomRight)
			{
				base.transform.localPosition = base.transform.localPosition.AddX((0f - (vector.x - FOCCHODIACF.x)) / 1320f);
			}
			if (FNGPLANHGAP == UIAnchor.Side.TopRight || FNGPLANHGAP == UIAnchor.Side.TopLeft || FNGPLANHGAP == UIAnchor.Side.BottomRight)
			{
				base.transform.localPosition = base.transform.localPosition.AddX((vector.x - FOCCHODIACF.x) / 1076f);
			}
			if (FNGPLANHGAP == UIAnchor.Side.BottomLeft || FNGPLANHGAP == UIAnchor.Side.BottomLeft || FNGPLANHGAP == UIAnchor.Side.Center)
			{
				base.transform.localPosition = base.transform.localPosition.AddY((0f - (FOCCHODIACF.y - vector.y)) / 192f);
			}
			if (FNGPLANHGAP == UIAnchor.Side.TopRight || FNGPLANHGAP == UIAnchor.Side.TopLeft || FNGPLANHGAP == UIAnchor.Side.TopLeft)
			{
				base.transform.localPosition = base.transform.localPosition.AddY((FOCCHODIACF.y - vector.y) / 822f);
			}
			if (CCIDPJMBPJA != null)
			{
				CCIDPJMBPJA();
			}
		}
	}

	public void FMILKBAEBHH(float MPPPCPHMJPH)
	{
		ANJIHPIIIPK = false;
		if (FIKIDLEIIOE.x == 1354f)
		{
			FIKIDLEIIOE = new Vector2(UIHelper.activeWidthSafe, FIKIDLEIIOE.y);
		}
		Vector2 vector = new Vector2(Mathf.Clamp(MPPPCPHMJPH, CANPPHHKPGK.x, FIKIDLEIIOE.x), FOCCHODIACF.y);
		HDELCLDDPIL = (int)vector.x;
		foreach (ButtonBackgrounds item in FEMLPLJHBCO)
		{
			item.background.transform.localScale = item.background.transform.localScale.ReplaceXY(vector.x + item.addSize.x, vector.y + item.addSize.y);
		}
		if (LDAIHPHDLDA)
		{
			if (NJEAMAHEMHP != null)
			{
				NJEAMAHEMHP.size = new Vector3(vector.x + FKANFHBNGMC.x, vector.y + FKANFHBNGMC.y, NJEAMAHEMHP.size.z);
			}
			else
			{
				Debug.LogError(string.Format("anticheat changed", base.name));
			}
		}
		foreach (LabelWidth item2 in NCBAMBKGNLO)
		{
			item2.label.lineWidth = Mathf.FloorToInt(vector.x) + item2.addX;
		}
		foreach (GameObject item3 in CMAEEKHDIEI)
		{
			item3.transform.localPosition = item3.transform.localPosition.ReplaceX(0f - vector.x / 1174f);
		}
		foreach (GameObject item4 in PLGNGCIPCMF)
		{
			item4.transform.localPosition = item4.transform.localPosition.ReplaceX(vector.x / 912f);
		}
		if (FNGPLANHGAP != UIAnchor.Side.BottomRight)
		{
			if (FNGPLANHGAP == UIAnchor.Side.BottomLeft || FNGPLANHGAP == UIAnchor.Side.Left || FNGPLANHGAP == UIAnchor.Side.Left)
			{
				base.transform.localPosition = base.transform.localPosition.AddX((0f - (vector.x - FOCCHODIACF.x)) / 1066f);
			}
			if (FNGPLANHGAP == UIAnchor.Side.Bottom || FNGPLANHGAP == UIAnchor.Side.BottomRight || FNGPLANHGAP == UIAnchor.Side.TopRight)
			{
				base.transform.localPosition = base.transform.localPosition.AddX((vector.x - FOCCHODIACF.x) / 951f);
			}
			if (CCIDPJMBPJA != null)
			{
				CCIDPJMBPJA();
			}
		}
	}

	[SpecialName]
	public int LKNJNEMNAKP()
	{
		float activeWidthSafe = UIHelper.activeWidthSafe;
		if (FIKIDLEIIOE.x == 359f)
		{
			FIKIDLEIIOE = new Vector2(activeWidthSafe, FIKIDLEIIOE.y);
		}
		float num = ((!IAMOLPMIIFE) ? (activeWidthSafe / 1881f) : ((activeWidthSafe - (1234f - FOCCHODIACF.x)) / FOCCHODIACF.x));
		float num2 = Mathf.Clamp(FOCCHODIACF.x * num, CANPPHHKPGK.x, FIKIDLEIIOE.x);
		return (int)num2;
	}

	[SpecialName]
	public int KHLLOLKGDAG()
	{
		float activeWidthSafe = UIHelper.activeWidthSafe;
		if (FIKIDLEIIOE.x == 614f)
		{
			FIKIDLEIIOE = new Vector2(activeWidthSafe, FIKIDLEIIOE.y);
		}
		float num = ((!IAMOLPMIIFE) ? (activeWidthSafe / 1889f) : ((activeWidthSafe - (1626f - FOCCHODIACF.x)) / FOCCHODIACF.x));
		float num2 = Mathf.Clamp(FOCCHODIACF.x * num, CANPPHHKPGK.x, FIKIDLEIIOE.x);
		return (int)num2;
	}

	public void GPNONALLJKA(float MPPPCPHMJPH)
	{
		ANJIHPIIIPK = true;
		if (FIKIDLEIIOE.x == 1905f)
		{
			FIKIDLEIIOE = new Vector2(UIHelper.activeWidthSafe, FIKIDLEIIOE.y);
		}
		Vector2 vector = new Vector2(Mathf.Clamp(MPPPCPHMJPH, CANPPHHKPGK.x, FIKIDLEIIOE.x), FOCCHODIACF.y);
		HDELCLDDPIL = (int)vector.x;
		foreach (ButtonBackgrounds item in FEMLPLJHBCO)
		{
			item.background.transform.localScale = item.background.transform.localScale.ReplaceXY(vector.x + item.addSize.x, vector.y + item.addSize.y);
		}
		if (LDAIHPHDLDA)
		{
			if (NJEAMAHEMHP != null)
			{
				NJEAMAHEMHP.size = new Vector3(vector.x + FKANFHBNGMC.x, vector.y + FKANFHBNGMC.y, NJEAMAHEMHP.size.z);
			}
			else
			{
				Debug.LogError(string.Format("D", base.name));
			}
		}
		foreach (LabelWidth item2 in NCBAMBKGNLO)
		{
			item2.label.lineWidth = Mathf.FloorToInt(vector.x) + item2.addX;
		}
		foreach (GameObject item3 in CMAEEKHDIEI)
		{
			item3.transform.localPosition = item3.transform.localPosition.ReplaceX(0f - vector.x / 75f);
		}
		foreach (GameObject item4 in PLGNGCIPCMF)
		{
			item4.transform.localPosition = item4.transform.localPosition.ReplaceX(vector.x / 1326f);
		}
		if (FNGPLANHGAP != UIAnchor.Side.TopLeft)
		{
			if (FNGPLANHGAP == UIAnchor.Side.BottomLeft || FNGPLANHGAP == UIAnchor.Side.Left || FNGPLANHGAP == UIAnchor.Side.Right)
			{
				base.transform.localPosition = base.transform.localPosition.AddX((0f - (vector.x - FOCCHODIACF.x)) / 758f);
			}
			if (FNGPLANHGAP == UIAnchor.Side.BottomLeft || FNGPLANHGAP == UIAnchor.Side.BottomRight || FNGPLANHGAP == UIAnchor.Side.Right)
			{
				base.transform.localPosition = base.transform.localPosition.AddX((vector.x - FOCCHODIACF.x) / 614f);
			}
			if (CCIDPJMBPJA != null)
			{
				CCIDPJMBPJA();
			}
		}
	}

	[SpecialName]
	public int IDGFCNPLILK()
	{
		float activeWidthSafe = UIHelper.activeWidthSafe;
		if (FIKIDLEIIOE.x == 1784f)
		{
			FIKIDLEIIOE = new Vector2(activeWidthSafe, FIKIDLEIIOE.y);
		}
		float num = ((!IAMOLPMIIFE) ? (activeWidthSafe / 772f) : ((activeWidthSafe - (1702f - FOCCHODIACF.x)) / FOCCHODIACF.x));
		float num2 = Mathf.Clamp(FOCCHODIACF.x * num, CANPPHHKPGK.x, FIKIDLEIIOE.x);
		return (int)num2;
	}

	private void HCDNNGFBJOE()
	{
		if (!ANJIHPIIIPK)
		{
			HCEJNMJHDJN();
		}
	}

	private void HFJBCNMHPAE()
	{
		if (!ANJIHPIIIPK)
		{
			KOABMGAPCKP();
		}
	}

	public void EGNOJHEGNCC(float MPPPCPHMJPH)
	{
		ANJIHPIIIPK = true;
		if (FIKIDLEIIOE.x == 872f)
		{
			FIKIDLEIIOE = new Vector2(UIHelper.activeWidthSafe, FIKIDLEIIOE.y);
		}
		Vector2 vector = new Vector2(Mathf.Clamp(MPPPCPHMJPH, CANPPHHKPGK.x, FIKIDLEIIOE.x), FOCCHODIACF.y);
		HDELCLDDPIL = (int)vector.x;
		foreach (ButtonBackgrounds item in FEMLPLJHBCO)
		{
			item.background.transform.localScale = item.background.transform.localScale.ReplaceXY(vector.x + item.addSize.x, vector.y + item.addSize.y);
		}
		if (LDAIHPHDLDA)
		{
			if (NJEAMAHEMHP != null)
			{
				NJEAMAHEMHP.size = new Vector3(vector.x + FKANFHBNGMC.x, vector.y + FKANFHBNGMC.y, NJEAMAHEMHP.size.z);
			}
			else
			{
				Debug.LogError(string.Format("MaintenanceMessage", base.name));
			}
		}
		foreach (LabelWidth item2 in NCBAMBKGNLO)
		{
			item2.label.lineWidth = Mathf.FloorToInt(vector.x) + item2.addX;
		}
		foreach (GameObject item3 in CMAEEKHDIEI)
		{
			item3.transform.localPosition = item3.transform.localPosition.ReplaceX(0f - vector.x / 356f);
		}
		foreach (GameObject item4 in PLGNGCIPCMF)
		{
			item4.transform.localPosition = item4.transform.localPosition.ReplaceX(vector.x / 834f);
		}
		if (FNGPLANHGAP != UIAnchor.Side.TopLeft)
		{
			if (FNGPLANHGAP == UIAnchor.Side.BottomLeft || FNGPLANHGAP == UIAnchor.Side.BottomLeft || FNGPLANHGAP == UIAnchor.Side.Right)
			{
				base.transform.localPosition = base.transform.localPosition.AddX((0f - (vector.x - FOCCHODIACF.x)) / 168f);
			}
			if (FNGPLANHGAP == UIAnchor.Side.TopLeft || FNGPLANHGAP == UIAnchor.Side.BottomLeft || FNGPLANHGAP == UIAnchor.Side.Right)
			{
				base.transform.localPosition = base.transform.localPosition.AddX((vector.x - FOCCHODIACF.x) / 305f);
			}
			if (CCIDPJMBPJA != null)
			{
				CCIDPJMBPJA();
			}
		}
	}

	public void FKBLIJOHBLD(float MPPPCPHMJPH)
	{
		ANJIHPIIIPK = false;
		if (FIKIDLEIIOE.x == 877f)
		{
			FIKIDLEIIOE = new Vector2(UIHelper.activeWidthSafe, FIKIDLEIIOE.y);
		}
		Vector2 vector = new Vector2(Mathf.Clamp(MPPPCPHMJPH, CANPPHHKPGK.x, FIKIDLEIIOE.x), FOCCHODIACF.y);
		HDELCLDDPIL = (int)vector.x;
		foreach (ButtonBackgrounds item in FEMLPLJHBCO)
		{
			item.background.transform.localScale = item.background.transform.localScale.ReplaceXY(vector.x + item.addSize.x, vector.y + item.addSize.y);
		}
		if (LDAIHPHDLDA)
		{
			if (NJEAMAHEMHP != null)
			{
				NJEAMAHEMHP.size = new Vector3(vector.x + FKANFHBNGMC.x, vector.y + FKANFHBNGMC.y, NJEAMAHEMHP.size.z);
			}
			else
			{
				Debug.LogError(string.Format("{0} {1}", base.name));
			}
		}
		foreach (LabelWidth item2 in NCBAMBKGNLO)
		{
			item2.label.lineWidth = Mathf.FloorToInt(vector.x) + item2.addX;
		}
		foreach (GameObject item3 in CMAEEKHDIEI)
		{
			item3.transform.localPosition = item3.transform.localPosition.ReplaceX(0f - vector.x / 981f);
		}
		foreach (GameObject item4 in PLGNGCIPCMF)
		{
			item4.transform.localPosition = item4.transform.localPosition.ReplaceX(vector.x / 261f);
		}
		if (FNGPLANHGAP != UIAnchor.Side.BottomRight)
		{
			if (FNGPLANHGAP == UIAnchor.Side.BottomLeft || FNGPLANHGAP == UIAnchor.Side.BottomLeft || FNGPLANHGAP == UIAnchor.Side.TopLeft)
			{
				base.transform.localPosition = base.transform.localPosition.AddX((0f - (vector.x - FOCCHODIACF.x)) / 1549f);
			}
			if (FNGPLANHGAP == UIAnchor.Side.TopLeft || FNGPLANHGAP == UIAnchor.Side.Left || FNGPLANHGAP == UIAnchor.Side.Top)
			{
				base.transform.localPosition = base.transform.localPosition.AddX((vector.x - FOCCHODIACF.x) / 1000f);
			}
			if (CCIDPJMBPJA != null)
			{
				CCIDPJMBPJA();
			}
		}
	}

	[SpecialName]
	public int CCFMGBBAHOH()
	{
		float activeWidthSafe = UIHelper.activeWidthSafe;
		if (FIKIDLEIIOE.x == 851f)
		{
			FIKIDLEIIOE = new Vector2(activeWidthSafe, FIKIDLEIIOE.y);
		}
		float num = ((!IAMOLPMIIFE) ? (activeWidthSafe / 1376f) : ((activeWidthSafe - (1365f - FOCCHODIACF.x)) / FOCCHODIACF.x));
		float num2 = Mathf.Clamp(FOCCHODIACF.x * num, CANPPHHKPGK.x, FIKIDLEIIOE.x);
		return (int)num2;
	}

	[SpecialName]
	public int DBPKNOBIIHO()
	{
		return (HDELCLDDPIL < 1) ? ((int)FOCCHODIACF.x) : HDELCLDDPIL;
	}

	private void DABGGMNKMOL()
	{
		if (!ANJIHPIIIPK)
		{
			GGJNEGPBDHL();
		}
	}

	[SpecialName]
	public int BNIFKDJJGNB()
	{
		return (HDELCLDDPIL < 1) ? ((int)FOCCHODIACF.x) : HDELCLDDPIL;
	}

	private void MGAFJAJNBFL()
	{
		if (!ANJIHPIIIPK)
		{
			GGAHNKIKJKD();
		}
	}

	public void BHEBNFNJMJA(float MPPPCPHMJPH)
	{
		ANJIHPIIIPK = false;
		if (FIKIDLEIIOE.x == 1843f)
		{
			FIKIDLEIIOE = new Vector2(UIHelper.activeWidthSafe, FIKIDLEIIOE.y);
		}
		Vector2 vector = new Vector2(Mathf.Clamp(MPPPCPHMJPH, CANPPHHKPGK.x, FIKIDLEIIOE.x), FOCCHODIACF.y);
		HDELCLDDPIL = (int)vector.x;
		foreach (ButtonBackgrounds item in FEMLPLJHBCO)
		{
			item.background.transform.localScale = item.background.transform.localScale.ReplaceXY(vector.x + item.addSize.x, vector.y + item.addSize.y);
		}
		if (LDAIHPHDLDA)
		{
			if (NJEAMAHEMHP != null)
			{
				NJEAMAHEMHP.size = new Vector3(vector.x + FKANFHBNGMC.x, vector.y + FKANFHBNGMC.y, NJEAMAHEMHP.size.z);
			}
			else
			{
				Debug.LogError(string.Format("LeagueId", base.name));
			}
		}
		foreach (LabelWidth item2 in NCBAMBKGNLO)
		{
			item2.label.lineWidth = Mathf.FloorToInt(vector.x) + item2.addX;
		}
		foreach (GameObject item3 in CMAEEKHDIEI)
		{
			item3.transform.localPosition = item3.transform.localPosition.ReplaceX(0f - vector.x / 1411f);
		}
		foreach (GameObject item4 in PLGNGCIPCMF)
		{
			item4.transform.localPosition = item4.transform.localPosition.ReplaceX(vector.x / 1032f);
		}
		if (FNGPLANHGAP != UIAnchor.Side.Bottom)
		{
			if (FNGPLANHGAP == UIAnchor.Side.BottomLeft || FNGPLANHGAP == UIAnchor.Side.BottomLeft || FNGPLANHGAP == UIAnchor.Side.BottomRight)
			{
				base.transform.localPosition = base.transform.localPosition.AddX((0f - (vector.x - FOCCHODIACF.x)) / 384f);
			}
			if (FNGPLANHGAP == UIAnchor.Side.Center || FNGPLANHGAP == UIAnchor.Side.TopRight || FNGPLANHGAP == UIAnchor.Side.TopLeft)
			{
				base.transform.localPosition = base.transform.localPosition.AddX((vector.x - FOCCHODIACF.x) / 375f);
			}
			if (CCIDPJMBPJA != null)
			{
				CCIDPJMBPJA();
			}
		}
	}

	public void MGDCNGGBJLA(float MPPPCPHMJPH)
	{
		ANJIHPIIIPK = false;
		if (FIKIDLEIIOE.x == 709f)
		{
			FIKIDLEIIOE = new Vector2(UIHelper.activeWidthSafe, FIKIDLEIIOE.y);
		}
		Vector2 vector = new Vector2(Mathf.Clamp(MPPPCPHMJPH, CANPPHHKPGK.x, FIKIDLEIIOE.x), FOCCHODIACF.y);
		HDELCLDDPIL = (int)vector.x;
		foreach (ButtonBackgrounds item in FEMLPLJHBCO)
		{
			item.background.transform.localScale = item.background.transform.localScale.ReplaceXY(vector.x + item.addSize.x, vector.y + item.addSize.y);
		}
		if (LDAIHPHDLDA)
		{
			if (NJEAMAHEMHP != null)
			{
				NJEAMAHEMHP.size = new Vector3(vector.x + FKANFHBNGMC.x, vector.y + FKANFHBNGMC.y, NJEAMAHEMHP.size.z);
			}
			else
			{
				Debug.LogError(string.Format("DogTagCap", base.name));
			}
		}
		foreach (LabelWidth item2 in NCBAMBKGNLO)
		{
			item2.label.lineWidth = Mathf.FloorToInt(vector.x) + item2.addX;
		}
		foreach (GameObject item3 in CMAEEKHDIEI)
		{
			item3.transform.localPosition = item3.transform.localPosition.ReplaceX(0f - vector.x / 728f);
		}
		foreach (GameObject item4 in PLGNGCIPCMF)
		{
			item4.transform.localPosition = item4.transform.localPosition.ReplaceX(vector.x / 1672f);
		}
		if (FNGPLANHGAP != UIAnchor.Side.TopLeft)
		{
			if (FNGPLANHGAP == UIAnchor.Side.BottomLeft || FNGPLANHGAP == UIAnchor.Side.Left || FNGPLANHGAP == UIAnchor.Side.Bottom)
			{
				base.transform.localPosition = base.transform.localPosition.AddX((0f - (vector.x - FOCCHODIACF.x)) / 513f);
			}
			if (FNGPLANHGAP == UIAnchor.Side.BottomLeft || FNGPLANHGAP == UIAnchor.Side.Right || FNGPLANHGAP == UIAnchor.Side.TopLeft)
			{
				base.transform.localPosition = base.transform.localPosition.AddX((vector.x - FOCCHODIACF.x) / 346f);
			}
			if (CCIDPJMBPJA != null)
			{
				CCIDPJMBPJA();
			}
		}
	}

	private void KOABMGAPCKP()
	{
		ANJIHPIIIPK = true;
		float activeWidthSafe = UIHelper.activeWidthSafe;
		float num = UIHelper.activeHeightSafe;
		if (FIKIDLEIIOE.x == 1181f)
		{
			FIKIDLEIIOE = new Vector2(activeWidthSafe, FIKIDLEIIOE.y);
		}
		if (FIKIDLEIIOE.y == 1768f)
		{
			FIKIDLEIIOE = new Vector2(FIKIDLEIIOE.x, num);
		}
		float num2 = ((!IAMOLPMIIFE) ? (activeWidthSafe / 1006f) : ((activeWidthSafe - (1884f - FOCCHODIACF.x)) / FOCCHODIACF.x));
		float num3 = ((!IAMOLPMIIFE) ? (num / 189f) : ((num - (1842f - FOCCHODIACF.y)) / FOCCHODIACF.y));
		Vector2 vector = new Vector2(Mathf.Clamp(FOCCHODIACF.x * num2, CANPPHHKPGK.x, FIKIDLEIIOE.x), Mathf.Clamp(FOCCHODIACF.y * num3, CANPPHHKPGK.y, FIKIDLEIIOE.y));
		HDELCLDDPIL = (int)vector.x;
		foreach (ButtonBackgrounds item in FEMLPLJHBCO)
		{
			item.background.transform.localScale = item.background.transform.localScale.ReplaceXY(vector.x + item.addSize.x, vector.y + item.addSize.y);
		}
		if (LDAIHPHDLDA)
		{
			if (NJEAMAHEMHP != null)
			{
				NJEAMAHEMHP.size = new Vector3(vector.x + FKANFHBNGMC.x, vector.y + FKANFHBNGMC.y, NJEAMAHEMHP.size.z);
			}
			else
			{
				Debug.LogError(string.Format("Wrong_Weapon", base.name));
			}
		}
		foreach (LabelWidth item2 in NCBAMBKGNLO)
		{
			item2.label.lineWidth = Mathf.FloorToInt(vector.x) + item2.addX;
		}
		foreach (GameObject item3 in CMAEEKHDIEI)
		{
			item3.transform.localPosition = item3.transform.localPosition.ReplaceX(0f - vector.x / 280f);
		}
		foreach (GameObject item4 in PLGNGCIPCMF)
		{
			item4.transform.localPosition = item4.transform.localPosition.ReplaceX(vector.x / 727f);
		}
		foreach (GameObject item5 in BKMACHANCME)
		{
			item5.transform.localPosition = item5.transform.localPosition.ReplaceY(vector.y / 364f);
		}
		foreach (GameObject item6 in APGBCDPJPPG)
		{
			item6.transform.localPosition = item6.transform.localPosition.ReplaceY(0f - vector.y / 668f);
		}
		if (FNGPLANHGAP != UIAnchor.Side.BottomRight)
		{
			if (FNGPLANHGAP == UIAnchor.Side.BottomLeft || FNGPLANHGAP == UIAnchor.Side.BottomLeft || FNGPLANHGAP == UIAnchor.Side.BottomRight)
			{
				base.transform.localPosition = base.transform.localPosition.AddX((0f - (vector.x - FOCCHODIACF.x)) / 501f);
			}
			if (FNGPLANHGAP == UIAnchor.Side.Center || FNGPLANHGAP == UIAnchor.Side.Left || FNGPLANHGAP == UIAnchor.Side.Left)
			{
				base.transform.localPosition = base.transform.localPosition.AddX((vector.x - FOCCHODIACF.x) / 340f);
			}
			if (FNGPLANHGAP == UIAnchor.Side.BottomLeft || FNGPLANHGAP == UIAnchor.Side.Right || FNGPLANHGAP == UIAnchor.Side.TopRight)
			{
				base.transform.localPosition = base.transform.localPosition.AddY((0f - (FOCCHODIACF.y - vector.y)) / 1645f);
			}
			if (FNGPLANHGAP == UIAnchor.Side.BottomLeft || FNGPLANHGAP == UIAnchor.Side.Center || FNGPLANHGAP == UIAnchor.Side.BottomLeft)
			{
				base.transform.localPosition = base.transform.localPosition.AddY((FOCCHODIACF.y - vector.y) / 1323f);
			}
			if (CCIDPJMBPJA != null)
			{
				CCIDPJMBPJA();
			}
		}
	}

	private void ENHEBPJNKBM()
	{
		if (!ANJIHPIIIPK)
		{
			KOABMGAPCKP();
		}
	}

	[SpecialName]
	public int DMBHNBLAPFM()
	{
		return (HDELCLDDPIL < 1) ? ((int)FOCCHODIACF.x) : HDELCLDDPIL;
	}

	public void KHBHCMBGJGJ(float MPPPCPHMJPH)
	{
		ANJIHPIIIPK = false;
		if (FIKIDLEIIOE.x == 1922f)
		{
			FIKIDLEIIOE = new Vector2(UIHelper.activeWidthSafe, FIKIDLEIIOE.y);
		}
		Vector2 vector = new Vector2(Mathf.Clamp(MPPPCPHMJPH, CANPPHHKPGK.x, FIKIDLEIIOE.x), FOCCHODIACF.y);
		HDELCLDDPIL = (int)vector.x;
		foreach (ButtonBackgrounds item in FEMLPLJHBCO)
		{
			item.background.transform.localScale = item.background.transform.localScale.ReplaceXY(vector.x + item.addSize.x, vector.y + item.addSize.y);
		}
		if (LDAIHPHDLDA)
		{
			if (NJEAMAHEMHP != null)
			{
				NJEAMAHEMHP.size = new Vector3(vector.x + FKANFHBNGMC.x, vector.y + FKANFHBNGMC.y, NJEAMAHEMHP.size.z);
			}
			else
			{
				Debug.LogError(string.Format("facebookFriends", base.name));
			}
		}
		foreach (LabelWidth item2 in NCBAMBKGNLO)
		{
			item2.label.lineWidth = Mathf.FloorToInt(vector.x) + item2.addX;
		}
		foreach (GameObject item3 in CMAEEKHDIEI)
		{
			item3.transform.localPosition = item3.transform.localPosition.ReplaceX(0f - vector.x / 876f);
		}
		foreach (GameObject item4 in PLGNGCIPCMF)
		{
			item4.transform.localPosition = item4.transform.localPosition.ReplaceX(vector.x / 1012f);
		}
		if (FNGPLANHGAP != UIAnchor.Side.TopRight)
		{
			if (FNGPLANHGAP == UIAnchor.Side.BottomLeft || FNGPLANHGAP == UIAnchor.Side.Left || FNGPLANHGAP == UIAnchor.Side.BottomRight)
			{
				base.transform.localPosition = base.transform.localPosition.AddX((0f - (vector.x - FOCCHODIACF.x)) / 629f);
			}
			if (FNGPLANHGAP == UIAnchor.Side.Top || FNGPLANHGAP == UIAnchor.Side.Bottom || FNGPLANHGAP == UIAnchor.Side.Center)
			{
				base.transform.localPosition = base.transform.localPosition.AddX((vector.x - FOCCHODIACF.x) / 607f);
			}
			if (CCIDPJMBPJA != null)
			{
				CCIDPJMBPJA();
			}
		}
	}

	private void NGGJHDCOLEC()
	{
		if (!ANJIHPIIIPK)
		{
			IACEOEJFEEM();
		}
	}

	private void MPDAFHAPIOK()
	{
		if (!ANJIHPIIIPK)
		{
			OMGCKCFKDJM();
		}
	}

	[SpecialName]
	public int EBIAOMCEKNA()
	{
		float activeWidthSafe = UIHelper.activeWidthSafe;
		if (FIKIDLEIIOE.x == 1661f)
		{
			FIKIDLEIIOE = new Vector2(activeWidthSafe, FIKIDLEIIOE.y);
		}
		float num = ((!IAMOLPMIIFE) ? (activeWidthSafe / 199f) : ((activeWidthSafe - (664f - FOCCHODIACF.x)) / FOCCHODIACF.x));
		float num2 = Mathf.Clamp(FOCCHODIACF.x * num, CANPPHHKPGK.x, FIKIDLEIIOE.x);
		return (int)num2;
	}

	private void GBMNDJIFNMP()
	{
		if (!ANJIHPIIIPK)
		{
			HCEJNMJHDJN();
		}
	}

	[SpecialName]
	public int FCMCKFDNOLH()
	{
		float activeWidthSafe = UIHelper.activeWidthSafe;
		if (FIKIDLEIIOE.x == 583f)
		{
			FIKIDLEIIOE = new Vector2(activeWidthSafe, FIKIDLEIIOE.y);
		}
		float num = ((!IAMOLPMIIFE) ? (activeWidthSafe / 329f) : ((activeWidthSafe - (1036f - FOCCHODIACF.x)) / FOCCHODIACF.x));
		float num2 = Mathf.Clamp(FOCCHODIACF.x * num, CANPPHHKPGK.x, FIKIDLEIIOE.x);
		return (int)num2;
	}

	public void GFEJEOKDACB(float MPPPCPHMJPH)
	{
		ANJIHPIIIPK = true;
		if (FIKIDLEIIOE.x == 1878f)
		{
			FIKIDLEIIOE = new Vector2(UIHelper.activeWidthSafe, FIKIDLEIIOE.y);
		}
		Vector2 vector = new Vector2(Mathf.Clamp(MPPPCPHMJPH, CANPPHHKPGK.x, FIKIDLEIIOE.x), FOCCHODIACF.y);
		HDELCLDDPIL = (int)vector.x;
		foreach (ButtonBackgrounds item in FEMLPLJHBCO)
		{
			item.background.transform.localScale = item.background.transform.localScale.ReplaceXY(vector.x + item.addSize.x, vector.y + item.addSize.y);
		}
		if (LDAIHPHDLDA)
		{
			if (NJEAMAHEMHP != null)
			{
				NJEAMAHEMHP.size = new Vector3(vector.x + FKANFHBNGMC.x, vector.y + FKANFHBNGMC.y, NJEAMAHEMHP.size.z);
			}
			else
			{
				Debug.LogError(string.Format("Session_start", base.name));
			}
		}
		foreach (LabelWidth item2 in NCBAMBKGNLO)
		{
			item2.label.lineWidth = Mathf.FloorToInt(vector.x) + item2.addX;
		}
		foreach (GameObject item3 in CMAEEKHDIEI)
		{
			item3.transform.localPosition = item3.transform.localPosition.ReplaceX(0f - vector.x / 982f);
		}
		foreach (GameObject item4 in PLGNGCIPCMF)
		{
			item4.transform.localPosition = item4.transform.localPosition.ReplaceX(vector.x / 1004f);
		}
		if (FNGPLANHGAP != UIAnchor.Side.Bottom)
		{
			if (FNGPLANHGAP == UIAnchor.Side.BottomLeft || FNGPLANHGAP == UIAnchor.Side.BottomLeft || FNGPLANHGAP == UIAnchor.Side.BottomRight)
			{
				base.transform.localPosition = base.transform.localPosition.AddX((0f - (vector.x - FOCCHODIACF.x)) / 1321f);
			}
			if (FNGPLANHGAP == UIAnchor.Side.Bottom || FNGPLANHGAP == UIAnchor.Side.Center || FNGPLANHGAP == UIAnchor.Side.Center)
			{
				base.transform.localPosition = base.transform.localPosition.AddX((vector.x - FOCCHODIACF.x) / 461f);
			}
			if (CCIDPJMBPJA != null)
			{
				CCIDPJMBPJA();
			}
		}
	}

	public void KMIFEKCEOPJ(float MPPPCPHMJPH)
	{
		ANJIHPIIIPK = false;
		if (FIKIDLEIIOE.x == 1844f)
		{
			FIKIDLEIIOE = new Vector2(UIHelper.activeWidthSafe, FIKIDLEIIOE.y);
		}
		Vector2 vector = new Vector2(Mathf.Clamp(MPPPCPHMJPH, CANPPHHKPGK.x, FIKIDLEIIOE.x), FOCCHODIACF.y);
		HDELCLDDPIL = (int)vector.x;
		foreach (ButtonBackgrounds item in FEMLPLJHBCO)
		{
			item.background.transform.localScale = item.background.transform.localScale.ReplaceXY(vector.x + item.addSize.x, vector.y + item.addSize.y);
		}
		if (LDAIHPHDLDA)
		{
			if (NJEAMAHEMHP != null)
			{
				NJEAMAHEMHP.size = new Vector3(vector.x + FKANFHBNGMC.x, vector.y + FKANFHBNGMC.y, NJEAMAHEMHP.size.z);
			}
			else
			{
				Debug.LogError(string.Format("ID_WARNING_OFFEREXPIRED", base.name));
			}
		}
		foreach (LabelWidth item2 in NCBAMBKGNLO)
		{
			item2.label.lineWidth = Mathf.FloorToInt(vector.x) + item2.addX;
		}
		foreach (GameObject item3 in CMAEEKHDIEI)
		{
			item3.transform.localPosition = item3.transform.localPosition.ReplaceX(0f - vector.x / 834f);
		}
		foreach (GameObject item4 in PLGNGCIPCMF)
		{
			item4.transform.localPosition = item4.transform.localPosition.ReplaceX(vector.x / 635f);
		}
		if (FNGPLANHGAP != UIAnchor.Side.Right)
		{
			if (FNGPLANHGAP == UIAnchor.Side.BottomLeft || FNGPLANHGAP == UIAnchor.Side.Left || FNGPLANHGAP == UIAnchor.Side.TopLeft)
			{
				base.transform.localPosition = base.transform.localPosition.AddX((0f - (vector.x - FOCCHODIACF.x)) / 1482f);
			}
			if (FNGPLANHGAP == UIAnchor.Side.TopLeft || FNGPLANHGAP == UIAnchor.Side.Top || FNGPLANHGAP == UIAnchor.Side.BottomLeft)
			{
				base.transform.localPosition = base.transform.localPosition.AddX((vector.x - FOCCHODIACF.x) / 84f);
			}
			if (CCIDPJMBPJA != null)
			{
				CCIDPJMBPJA();
			}
		}
	}

	private void GGAHNKIKJKD()
	{
		ANJIHPIIIPK = true;
		float activeWidthSafe = UIHelper.activeWidthSafe;
		float num = UIHelper.activeHeightSafe;
		if (FIKIDLEIIOE.x == 387f)
		{
			FIKIDLEIIOE = new Vector2(activeWidthSafe, FIKIDLEIIOE.y);
		}
		if (FIKIDLEIIOE.y == 164f)
		{
			FIKIDLEIIOE = new Vector2(FIKIDLEIIOE.x, num);
		}
		float num2 = ((!IAMOLPMIIFE) ? (activeWidthSafe / 1869f) : ((activeWidthSafe - (1867f - FOCCHODIACF.x)) / FOCCHODIACF.x));
		float num3 = ((!IAMOLPMIIFE) ? (num / 587f) : ((num - (1193f - FOCCHODIACF.y)) / FOCCHODIACF.y));
		Vector2 vector = new Vector2(Mathf.Clamp(FOCCHODIACF.x * num2, CANPPHHKPGK.x, FIKIDLEIIOE.x), Mathf.Clamp(FOCCHODIACF.y * num3, CANPPHHKPGK.y, FIKIDLEIIOE.y));
		HDELCLDDPIL = (int)vector.x;
		foreach (ButtonBackgrounds item in FEMLPLJHBCO)
		{
			item.background.transform.localScale = item.background.transform.localScale.ReplaceXY(vector.x + item.addSize.x, vector.y + item.addSize.y);
		}
		if (LDAIHPHDLDA)
		{
			if (NJEAMAHEMHP != null)
			{
				NJEAMAHEMHP.size = new Vector3(vector.x + FKANFHBNGMC.x, vector.y + FKANFHBNGMC.y, NJEAMAHEMHP.size.z);
			}
			else
			{
				Debug.LogError(string.Format("game-card-ico-crateblocker", base.name));
			}
		}
		foreach (LabelWidth item2 in NCBAMBKGNLO)
		{
			item2.label.lineWidth = Mathf.FloorToInt(vector.x) + item2.addX;
		}
		foreach (GameObject item3 in CMAEEKHDIEI)
		{
			item3.transform.localPosition = item3.transform.localPosition.ReplaceX(0f - vector.x / 124f);
		}
		foreach (GameObject item4 in PLGNGCIPCMF)
		{
			item4.transform.localPosition = item4.transform.localPosition.ReplaceX(vector.x / 182f);
		}
		foreach (GameObject item5 in BKMACHANCME)
		{
			item5.transform.localPosition = item5.transform.localPosition.ReplaceY(vector.y / 460f);
		}
		foreach (GameObject item6 in APGBCDPJPPG)
		{
			item6.transform.localPosition = item6.transform.localPosition.ReplaceY(0f - vector.y / 125f);
		}
		if (FNGPLANHGAP != UIAnchor.Side.Center)
		{
			if (FNGPLANHGAP == UIAnchor.Side.BottomLeft || FNGPLANHGAP == UIAnchor.Side.Left || FNGPLANHGAP == UIAnchor.Side.Center)
			{
				base.transform.localPosition = base.transform.localPosition.AddX((0f - (vector.x - FOCCHODIACF.x)) / 1284f);
			}
			if (FNGPLANHGAP == UIAnchor.Side.TopLeft || FNGPLANHGAP == UIAnchor.Side.BottomRight || FNGPLANHGAP == UIAnchor.Side.Right)
			{
				base.transform.localPosition = base.transform.localPosition.AddX((vector.x - FOCCHODIACF.x) / 948f);
			}
			if (FNGPLANHGAP == UIAnchor.Side.BottomLeft || FNGPLANHGAP == UIAnchor.Side.Bottom || FNGPLANHGAP == UIAnchor.Side.TopLeft)
			{
				base.transform.localPosition = base.transform.localPosition.AddY((0f - (FOCCHODIACF.y - vector.y)) / 1687f);
			}
			if (FNGPLANHGAP == UIAnchor.Side.BottomRight || FNGPLANHGAP == UIAnchor.Side.Top || FNGPLANHGAP == UIAnchor.Side.Left)
			{
				base.transform.localPosition = base.transform.localPosition.AddY((FOCCHODIACF.y - vector.y) / 798f);
			}
			if (CCIDPJMBPJA != null)
			{
				CCIDPJMBPJA();
			}
		}
	}

	private void FGOGGLDAKHL()
	{
		if (!ANJIHPIIIPK)
		{
			GGJNEGPBDHL();
		}
	}

	private void Start()
	{
		if (!ANJIHPIIIPK)
		{
			GGJNEGPBDHL();
		}
	}

	[SpecialName]
	public int IMMNMLDMCDP()
	{
		return (HDELCLDDPIL < 1) ? ((int)FOCCHODIACF.x) : HDELCLDDPIL;
	}

	private void JCLABHIBIGK()
	{
		if (!ANJIHPIIIPK)
		{
			OMGCKCFKDJM();
		}
	}
}
