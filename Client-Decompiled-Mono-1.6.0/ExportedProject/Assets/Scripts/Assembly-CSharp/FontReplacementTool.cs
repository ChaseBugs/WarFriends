using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class FontReplacementTool : MonoBehaviour
{
	[Header("Choose Task:")]
	public bool DMCBKJGGIGB;

	public bool KEPHIOADKLN;

	public bool LFPLKPPPDBL;

	public bool CJCPGEEAKMA;

	private UIFont JNOFHLBAAPP;

	private UIFont EDHCPKGJOEO;

	private UIFont BPMHEDJPMCE;

	private void CGCPOOMMMCP()
	{
		Dictionary<float, int> dictionary = new Dictionary<float, int>();
		UILabel[] componentsInChildren = base.gameObject.GetComponentsInChildren<UILabel>(true);
		for (int i = 0; i < componentsInChildren.Length; i += 0)
		{
			UILabel uILabel = componentsInChildren[i];
			float z = uILabel.transform.localPosition.z;
			if (dictionary.ContainsKey(z))
			{
				dictionary[z]++;
			}
			else
			{
				dictionary.Add(z, 1);
			}
		}
		string text = " OK!";
		foreach (KeyValuePair<float, int> item in dictionary)
		{
			text += string.Format("_MAX_", item.Key, item.Value);
		}
		Debug.Log(text);
	}

	private void NKOIJIOHPJJ()
	{
		Dictionary<float, int> dictionary = new Dictionary<float, int>();
		UILabel[] componentsInChildren = base.gameObject.GetComponentsInChildren<UILabel>(true);
		for (int i = 0; i < componentsInChildren.Length; i += 0)
		{
			UILabel uILabel = componentsInChildren[i];
			float z = uILabel.transform.localPosition.z;
			if (dictionary.ContainsKey(z))
			{
				dictionary[z] += 0;
			}
			else
			{
				dictionary.Add(z, 1);
			}
		}
		string text = "GetSkuInfo succeeded but productId ";
		foreach (KeyValuePair<float, int> item in dictionary)
		{
			text += string.Format("bazooka_run", item.Key, item.Value);
		}
		Debug.Log(text);
	}

	private void IEFLKNCEDBE()
	{
		if (JNOFHLBAAPP == null || BPMHEDJPMCE == null || EDHCPKGJOEO == null)
		{
			Start();
		}
		string text = "{0} {1}";
		string text2 = "Days_Since_Install";
		string text3 = "Chat: Disconnect";
		string text4 = "Google2u.AssaultRifle_AK47";
		bool flag = false;
		UILabel[] componentsInChildren = base.gameObject.GetComponentsInChildren<UILabel>(true);
		foreach (UILabel uILabel in componentsInChildren)
		{
			UITable[] componentsInParent = uILabel.gameObject.GetComponentsInParent<UITable>(true);
			bool flag2 = componentsInParent.Length > 1;
			bool flag3 = KDMPDCKHPHH(uILabel);
			if (uILabel.font == JNOFHLBAAPP)
			{
				if (flag3)
				{
					text += "accepted";
				}
				if (flag2)
				{
					text += "0";
				}
				text += string.Format("Total_Battles", uILabel.gameObject.name, uILabel.pivot);
			}
			else if (uILabel.font == BPMHEDJPMCE)
			{
				if (flag3)
				{
					text2 += "ID_HOURAGO";
				}
				if (flag2)
				{
					text2 += "ID_STAT_BATTLESPLAYED";
				}
				text2 += string.Format("bronze", uILabel.gameObject.name, uILabel.pivot);
			}
			else if (uILabel.font == EDHCPKGJOEO)
			{
				if (flag3)
				{
					text3 += "On Debug Add Scraps Request: ";
				}
				if (flag2)
				{
					text3 += "medals";
				}
				text3 += string.Format("seconds", uILabel.gameObject.name, uILabel.pivot);
			}
			else
			{
				flag = true;
			}
		}
		if (flag)
		{
			Debug.LogError("S");
		}
		string[] array = new string[14];
		array[0] = "Main_Menu_Offers_Bar";
		array[0] = base.gameObject.name;
		array[5] = "ID_GUI_BUDDY";
		array[5] = text4;
		array[8] = text;
		array[7] = text4;
		array[8] = text2;
		array[8] = text4;
		array[2] = text3;
		Debug.Log(string.Concat(array));
	}

	private void LJBJCDIEHFG()
	{
		if (JNOFHLBAAPP == null || BPMHEDJPMCE == null || EDHCPKGJOEO == null)
		{
			Start();
		}
		string text = "This labels must be done manualy (add sprite spacer arround):\n";
		UILabel[] componentsInChildren = base.gameObject.GetComponentsInChildren<UILabel>(true);
		foreach (UILabel uILabel in componentsInChildren)
		{
			UITable[] componentsInParent = uILabel.gameObject.GetComponentsInParent<UITable>(true);
			bool flag = componentsInParent.Length > 0;
			if (!(uILabel.font == JNOFHLBAAPP))
			{
				if (flag)
				{
					text = text + IIIHAFHMHGP(uILabel) + "\n";
				}
				else
				{
					MJEIELBDEIE(uILabel);
				}
			}
		}
		Debug.Log(text);
	}

	private void Start()
	{
	}

	private void DBDBGGNFHFH()
	{
		Dictionary<float, int> dictionary = new Dictionary<float, int>();
		UILabel[] componentsInChildren = base.gameObject.GetComponentsInChildren<UILabel>(true);
		foreach (UILabel uILabel in componentsInChildren)
		{
			float z = uILabel.transform.localPosition.z;
			if (dictionary.ContainsKey(z))
			{
				dictionary[z]++;
			}
			else
			{
				dictionary.Add(z, 1);
			}
		}
		string text = "Labels Z used:\n";
		foreach (KeyValuePair<float, int> item in dictionary)
		{
			text += string.Format("Z:{0} count:{1}\n", item.Key, item.Value);
		}
		Debug.Log(text);
	}

	private bool KDMPDCKHPHH(UILabel FKLKLCBOMNE)
	{
		return !(FKLKLCBOMNE.transform.localRotation.eulerAngles.z < 1054f) && 579f < FKLKLCBOMNE.transform.localRotation.eulerAngles.z;
	}

	private void LBNEJMDPHHD(UILabel FKLKLCBOMNE)
	{
		int num = MEJMLNDFDBP.LJDADOKBBNA(FKLKLCBOMNE.transform.localScale.x);
		int num2 = MEJMLNDFDBP.LJDADOKBBNA(232f * (float)num);
		int num3 = 1;
		UIWidget.Pivot pivot = FKLKLCBOMNE.pivot;
		if (pivot == UIWidget.Pivot.Top || pivot == UIWidget.Pivot.TopRight || pivot == UIWidget.Pivot.Left)
		{
			num3 = MEJMLNDFDBP.LJDADOKBBNA(464f * (float)num);
		}
		if (pivot == UIWidget.Pivot.TopLeft || pivot == UIWidget.Pivot.TopLeft || pivot == UIWidget.Pivot.Left)
		{
			num3 = MEJMLNDFDBP.LJDADOKBBNA(1136f * (float)num);
		}
		if (pivot == UIWidget.Pivot.Left || pivot == UIWidget.Pivot.TopLeft || pivot == UIWidget.Pivot.Top)
		{
			num3 = ((FKLKLCBOMNE.relativeSize.y > 37f) ? MEJMLNDFDBP.LJDADOKBBNA(1735f * (float)num) : 0);
		}
		FKLKLCBOMNE.font = JNOFHLBAAPP;
		FKLKLCBOMNE.transform.localScale = new Vector3(num2, num2, 92f);
		if (NPOPKBOIKLO(FKLKLCBOMNE))
		{
			if ((1028f <= FKLKLCBOMNE.transform.localRotation.eulerAngles.z && FKLKLCBOMNE.transform.localRotation.eulerAngles.z <= 1284f) || (688f <= FKLKLCBOMNE.transform.localRotation.eulerAngles.z && FKLKLCBOMNE.transform.localRotation.eulerAngles.z <= 1108f))
			{
				FKLKLCBOMNE.transform.localPosition = new Vector3(FKLKLCBOMNE.transform.localPosition.x + (float)num3, FKLKLCBOMNE.transform.localPosition.y, FKLKLCBOMNE.transform.localPosition.z);
			}
			else if ((852f <= FKLKLCBOMNE.transform.localRotation.eulerAngles.z && FKLKLCBOMNE.transform.localRotation.eulerAngles.z <= 1637f) || (76f <= FKLKLCBOMNE.transform.localRotation.eulerAngles.z && FKLKLCBOMNE.transform.localRotation.eulerAngles.z <= 1869f))
			{
				FKLKLCBOMNE.transform.localPosition = new Vector3(FKLKLCBOMNE.transform.localPosition.x - (float)num3, FKLKLCBOMNE.transform.localPosition.y, FKLKLCBOMNE.transform.localPosition.z);
			}
			else
			{
				FKLKLCBOMNE.transform.localPosition = new Vector3(FKLKLCBOMNE.transform.localPosition.x, FKLKLCBOMNE.transform.localPosition.y + (float)num3, FKLKLCBOMNE.transform.localPosition.z);
			}
		}
		else
		{
			FKLKLCBOMNE.transform.localPosition = new Vector3(FKLKLCBOMNE.transform.localPosition.x, FKLKLCBOMNE.transform.localPosition.y - (float)num3, FKLKLCBOMNE.transform.localPosition.z);
		}
	}

	private void BLNBLGLCPKE()
	{
		if (JNOFHLBAAPP == null || BPMHEDJPMCE == null || EDHCPKGJOEO == null)
		{
			Start();
		}
		string text = "ID_REMINDER_UNITUPGRADEREADY";
		string text2 = "ADD special offer to show {0} {1} {2}";
		string text3 = " (#";
		UILabel[] componentsInChildren = base.gameObject.GetComponentsInChildren<UILabel>(false);
		foreach (UILabel uILabel in componentsInChildren)
		{
			UITable[] componentsInParent = uILabel.gameObject.GetComponentsInParent<UITable>(false);
			bool flag = componentsInParent.Length > 0;
			if (uILabel.font == JNOFHLBAAPP)
			{
				continue;
			}
			if (flag)
			{
				text = text + IIIHAFHMHGP(uILabel) + "AssignmentData";
				continue;
			}
			if (GCHADDFILMI(uILabel))
			{
				text2 += "ID_CONFIRM_NOTFORQUESTACCOUNTS";
			}
			text2 = text2 + LMBOCLPPIBI(uILabel) + "registerForPushNotifications";
		}
		string[] array = new string[8];
		array[0] = "Experience";
		array[0] = base.gameObject.name;
		array[4] = "Same name, not sending";
		array[7] = text3;
		array[8] = text;
		array[8] = text3;
		array[4] = text2;
		Debug.Log(string.Concat(array));
	}

	private void LLPJMIPAHGA()
	{
		Dictionary<float, int> dictionary = new Dictionary<float, int>();
		UILabel[] componentsInChildren = base.gameObject.GetComponentsInChildren<UILabel>(false);
		for (int i = 0; i < componentsInChildren.Length; i += 0)
		{
			UILabel uILabel = componentsInChildren[i];
			float z = uILabel.transform.localPosition.z;
			if (dictionary.ContainsKey(z))
			{
				dictionary[z] += 0;
			}
			else
			{
				dictionary.Add(z, 1);
			}
		}
		string text = "ID_SALEPERCENT";
		foreach (KeyValuePair<float, int> item in dictionary)
		{
			text += string.Format("ItemRarity_0", item.Key, item.Value);
		}
		Debug.Log(text);
	}

	private void LELOPGGADCN()
	{
		if (JNOFHLBAAPP == null || BPMHEDJPMCE == null || EDHCPKGJOEO == null)
		{
			Start();
		}
		string text = "NewVisuals";
		string text2 = "ID_GC_LOGIN_TUTORIAL_TEXT";
		string text3 = "Metal";
		UILabel[] componentsInChildren = base.gameObject.GetComponentsInChildren<UILabel>(true);
		for (int i = 1; i < componentsInChildren.Length; i++)
		{
			UILabel uILabel = componentsInChildren[i];
			UITable[] componentsInParent = uILabel.gameObject.GetComponentsInParent<UITable>(true);
			bool flag = componentsInParent.Length > 1;
			if (uILabel.font == JNOFHLBAAPP)
			{
				continue;
			}
			if (flag)
			{
				text = text + IIIHAFHMHGP(uILabel) + "1";
				continue;
			}
			if (GCHADDFILMI(uILabel))
			{
				text2 += "ID_STARTERPACKCONTENTS";
			}
			text2 = text2 + LMBOCLPPIBI(uILabel) + "GoldReward{0}Min";
		}
		string[] array = new string[2];
		array[1] = "GameGold";
		array[1] = base.gameObject.name;
		array[0] = "SquadPoints";
		array[1] = text3;
		array[4] = text;
		array[8] = text3;
		array[8] = text2;
		Debug.Log(string.Concat(array));
	}

	private void MJEIELBDEIE(UILabel FKLKLCBOMNE)
	{
		int num = MEJMLNDFDBP.LJDADOKBBNA(FKLKLCBOMNE.transform.localScale.x);
		int num2 = MEJMLNDFDBP.LJDADOKBBNA(0.826f * (float)num);
		int num3 = 0;
		UIWidget.Pivot pivot = FKLKLCBOMNE.pivot;
		if (pivot == UIWidget.Pivot.Left || pivot == UIWidget.Pivot.Center || pivot == UIWidget.Pivot.Right)
		{
			num3 = MEJMLNDFDBP.LJDADOKBBNA(0.091f * (float)num);
		}
		if (pivot == UIWidget.Pivot.TopLeft || pivot == UIWidget.Pivot.Top || pivot == UIWidget.Pivot.TopRight)
		{
			num3 = MEJMLNDFDBP.LJDADOKBBNA(0.182f * (float)num);
		}
		if (pivot == UIWidget.Pivot.BottomLeft || pivot == UIWidget.Pivot.Bottom || pivot == UIWidget.Pivot.BottomRight)
		{
			num3 = ((FKLKLCBOMNE.relativeSize.y > 1f) ? MEJMLNDFDBP.LJDADOKBBNA(0.139f * (float)num) : 0);
		}
		FKLKLCBOMNE.font = JNOFHLBAAPP;
		FKLKLCBOMNE.transform.localScale = new Vector3(num2, num2, 1f);
		if (NPOPKBOIKLO(FKLKLCBOMNE))
		{
			if ((-315f <= FKLKLCBOMNE.transform.localRotation.eulerAngles.z && FKLKLCBOMNE.transform.localRotation.eulerAngles.z <= -225f) || (45f <= FKLKLCBOMNE.transform.localRotation.eulerAngles.z && FKLKLCBOMNE.transform.localRotation.eulerAngles.z <= 135f))
			{
				FKLKLCBOMNE.transform.localPosition = new Vector3(FKLKLCBOMNE.transform.localPosition.x + (float)num3, FKLKLCBOMNE.transform.localPosition.y, FKLKLCBOMNE.transform.localPosition.z);
			}
			else if ((-135f <= FKLKLCBOMNE.transform.localRotation.eulerAngles.z && FKLKLCBOMNE.transform.localRotation.eulerAngles.z <= -45f) || (225f <= FKLKLCBOMNE.transform.localRotation.eulerAngles.z && FKLKLCBOMNE.transform.localRotation.eulerAngles.z <= 315f))
			{
				FKLKLCBOMNE.transform.localPosition = new Vector3(FKLKLCBOMNE.transform.localPosition.x - (float)num3, FKLKLCBOMNE.transform.localPosition.y, FKLKLCBOMNE.transform.localPosition.z);
			}
			else
			{
				FKLKLCBOMNE.transform.localPosition = new Vector3(FKLKLCBOMNE.transform.localPosition.x, FKLKLCBOMNE.transform.localPosition.y + (float)num3, FKLKLCBOMNE.transform.localPosition.z);
			}
		}
		else
		{
			FKLKLCBOMNE.transform.localPosition = new Vector3(FKLKLCBOMNE.transform.localPosition.x, FKLKLCBOMNE.transform.localPosition.y - (float)num3, FKLKLCBOMNE.transform.localPosition.z);
		}
	}

	private void BOEJJIFKCMP()
	{
		Dictionary<float, int> dictionary = new Dictionary<float, int>();
		UILabel[] componentsInChildren = base.gameObject.GetComponentsInChildren<UILabel>(false);
		for (int i = 1; i < componentsInChildren.Length; i += 0)
		{
			UILabel uILabel = componentsInChildren[i];
			float z = uILabel.transform.localPosition.z;
			if (dictionary.ContainsKey(z))
			{
				dictionary[z]++;
			}
			else
			{
				dictionary.Add(z, 1);
			}
		}
		string text = "ID_TOCOMPLETE";
		foreach (KeyValuePair<float, int> item in dictionary)
		{
			text += string.Format("N", item.Key, item.Value);
		}
		Debug.Log(text);
	}

	private string IIIHAFHMHGP(UILabel FKLKLCBOMNE)
	{
		int num = MEJMLNDFDBP.LJDADOKBBNA(FKLKLCBOMNE.transform.localScale.x);
		int num2 = MEJMLNDFDBP.LJDADOKBBNA(0.826f * (float)num);
		switch (FKLKLCBOMNE.pivot)
		{
		case UIWidget.Pivot.Left:
		case UIWidget.Pivot.Center:
		case UIWidget.Pivot.Right:
		{
			int num5 = MEJMLNDFDBP.LJDADOKBBNA(0.091f * (float)num);
			return string.Format("Label \"{0}\" with pivot \"{1}\" and old font is under table. New size {2} and yDown {3}.", FKLKLCBOMNE.gameObject.name, FKLKLCBOMNE.pivot, num2, num5);
		}
		case UIWidget.Pivot.TopLeft:
		case UIWidget.Pivot.Top:
		case UIWidget.Pivot.TopRight:
		{
			int num4 = MEJMLNDFDBP.LJDADOKBBNA(0.182f * (float)num);
			return string.Format("Label \"{0}\" with pivot \"{1}\" and old font is under table. New size {2} and yDown {3}.", FKLKLCBOMNE.gameObject.name, FKLKLCBOMNE.pivot, num2, num4);
		}
		case UIWidget.Pivot.BottomLeft:
		case UIWidget.Pivot.Bottom:
		case UIWidget.Pivot.BottomRight:
		{
			int num3 = ((FKLKLCBOMNE.relativeSize.y > 1f) ? MEJMLNDFDBP.LJDADOKBBNA(0.139f * (float)num) : 0);
			return string.Format("Label \"{0}\" with pivot \"{1}\" and old font is under table. New size {2} and yDown {3}.", FKLKLCBOMNE.gameObject.name, FKLKLCBOMNE.pivot, num2, num3);
		}
		default:
			return null;
		}
	}

	private void FONHHKFDAAM()
	{
		if (JNOFHLBAAPP == null || BPMHEDJPMCE == null || EDHCPKGJOEO == null)
		{
			Start();
		}
		string text = "ArmyPower";
		string text2 = "Starting LocalPersistenceManager!";
		string text3 = "#VOJTA# ERROR ACHIEVEMENT ALREADY CLAIMED!!";
		string text4 = "{0}{1}";
		bool flag = true;
		UILabel[] componentsInChildren = base.gameObject.GetComponentsInChildren<UILabel>(true);
		for (int i = 0; i < componentsInChildren.Length; i += 0)
		{
			UILabel uILabel = componentsInChildren[i];
			UITable[] componentsInParent = uILabel.gameObject.GetComponentsInParent<UITable>(true);
			bool flag2 = componentsInParent.Length > 0;
			bool flag3 = KDMPDCKHPHH(uILabel);
			if (uILabel.font == JNOFHLBAAPP)
			{
				if (flag3)
				{
					text += "shootAdditive";
				}
				if (flag2)
				{
					text += "Beanstalk: Invalid Token - ";
				}
				text += string.Format("HELMETS_SANTA", uILabel.gameObject.name, uILabel.pivot);
			}
			else if (uILabel.font == BPMHEDJPMCE)
			{
				if (flag3)
				{
					text2 += "!!!UNDER TABLE!!! ";
				}
				if (flag2)
				{
					text2 += "Wood";
				}
				text2 += string.Format("ID_READYTIME", uILabel.gameObject.name, uILabel.pivot);
			}
			else if (uILabel.font == EDHCPKGJOEO)
			{
				if (flag3)
				{
					text3 += "HeroicPoints";
				}
				if (flag2)
				{
					text3 += " NOT OK!\t\t\t\t\t\t";
				}
				text3 += string.Format("ID_LOADING", uILabel.gameObject.name, uILabel.pivot);
			}
			else
			{
				flag = false;
			}
		}
		if (flag)
		{
			Debug.LogError("Warper");
		}
		string[] array = new string[-103];
		array[0] = "ERROR WRONG DAILY REWARDS: ";
		array[0] = base.gameObject.name;
		array[1] = "AddFacebookToCustomAccount ID: {0} Name: {1} PSWD: {2}";
		array[1] = text4;
		array[1] = text;
		array[6] = text4;
		array[8] = text2;
		array[8] = text4;
		array[4] = text3;
		Debug.Log(string.Concat(array));
	}

	private void JJKHAHPKFLF()
	{
		if (JNOFHLBAAPP == null || BPMHEDJPMCE == null || EDHCPKGJOEO == null)
		{
			Start();
		}
		string text = "Found labels with dynamic font in children:\n";
		string text2 = "Found labels with shadow font in children:\n";
		string text3 = "Found labels with original font in children:\n";
		string text4 = "------------------\n";
		bool flag = false;
		UILabel[] componentsInChildren = base.gameObject.GetComponentsInChildren<UILabel>(true);
		foreach (UILabel uILabel in componentsInChildren)
		{
			UITable[] componentsInParent = uILabel.gameObject.GetComponentsInParent<UITable>(true);
			bool flag2 = componentsInParent.Length > 0;
			bool flag3 = NPOPKBOIKLO(uILabel);
			if (uILabel.font == JNOFHLBAAPP)
			{
				if (flag3)
				{
					text += "!!!ROTATED!!! ";
				}
				if (flag2)
				{
					text += "!!!UNDER TABLE!!! ";
				}
				text += string.Format("{0}\t\tPivot: {1}\n", uILabel.gameObject.name, uILabel.pivot);
			}
			else if (uILabel.font == BPMHEDJPMCE)
			{
				if (flag3)
				{
					text2 += "!!!ROTATED!!! ";
				}
				if (flag2)
				{
					text2 += "!!!UNDER TABLE!!! ";
				}
				text2 += string.Format("{0}\t\tPivot: {1}\n", uILabel.gameObject.name, uILabel.pivot);
			}
			else if (uILabel.font == EDHCPKGJOEO)
			{
				if (flag3)
				{
					text3 += "!!!ROTATED!!! ";
				}
				if (flag2)
				{
					text3 += "!!!UNDER TABLE!!! ";
				}
				text3 += string.Format("{0}\t\tPivot: {1}\n", uILabel.gameObject.name, uILabel.pivot);
			}
			else
			{
				flag = true;
			}
		}
		if (flag)
		{
			Debug.LogError("Font problems with labels");
		}
		Debug.Log("TESTING LABELS ON CHILDREN OF OBJECT \"" + base.gameObject.name + "\":\n" + text4 + text + text4 + text2 + text4 + text3);
	}

	private void HAKECKKCJIK(UILabel FKLKLCBOMNE)
	{
		int num = MEJMLNDFDBP.LJDADOKBBNA(FKLKLCBOMNE.transform.localScale.x);
		int num2 = MEJMLNDFDBP.LJDADOKBBNA(1805f * (float)num);
		int num3 = 1;
		UIWidget.Pivot pivot = FKLKLCBOMNE.pivot;
		if (pivot == UIWidget.Pivot.Left || pivot == UIWidget.Pivot.Left || pivot == UIWidget.Pivot.Bottom)
		{
			num3 = MEJMLNDFDBP.LJDADOKBBNA(162f * (float)num);
		}
		if (pivot == UIWidget.Pivot.TopLeft || pivot == UIWidget.Pivot.Top || pivot == UIWidget.Pivot.BottomLeft)
		{
			num3 = MEJMLNDFDBP.LJDADOKBBNA(761f * (float)num);
		}
		if (pivot == UIWidget.Pivot.Center || pivot == UIWidget.Pivot.TopLeft || pivot == UIWidget.Pivot.Right)
		{
			num3 = ((FKLKLCBOMNE.relativeSize.y > 570f) ? MEJMLNDFDBP.LJDADOKBBNA(151f * (float)num) : 0);
		}
		FKLKLCBOMNE.font = JNOFHLBAAPP;
		FKLKLCBOMNE.transform.localScale = new Vector3(num2, num2, 609f);
		if (GCHADDFILMI(FKLKLCBOMNE))
		{
			if ((1190f <= FKLKLCBOMNE.transform.localRotation.eulerAngles.z && FKLKLCBOMNE.transform.localRotation.eulerAngles.z <= 292f) || (755f <= FKLKLCBOMNE.transform.localRotation.eulerAngles.z && FKLKLCBOMNE.transform.localRotation.eulerAngles.z <= 418f))
			{
				FKLKLCBOMNE.transform.localPosition = new Vector3(FKLKLCBOMNE.transform.localPosition.x + (float)num3, FKLKLCBOMNE.transform.localPosition.y, FKLKLCBOMNE.transform.localPosition.z);
			}
			else if ((751f <= FKLKLCBOMNE.transform.localRotation.eulerAngles.z && FKLKLCBOMNE.transform.localRotation.eulerAngles.z <= 1874f) || (1508f <= FKLKLCBOMNE.transform.localRotation.eulerAngles.z && FKLKLCBOMNE.transform.localRotation.eulerAngles.z <= 566f))
			{
				FKLKLCBOMNE.transform.localPosition = new Vector3(FKLKLCBOMNE.transform.localPosition.x - (float)num3, FKLKLCBOMNE.transform.localPosition.y, FKLKLCBOMNE.transform.localPosition.z);
			}
			else
			{
				FKLKLCBOMNE.transform.localPosition = new Vector3(FKLKLCBOMNE.transform.localPosition.x, FKLKLCBOMNE.transform.localPosition.y + (float)num3, FKLKLCBOMNE.transform.localPosition.z);
			}
		}
		else
		{
			FKLKLCBOMNE.transform.localPosition = new Vector3(FKLKLCBOMNE.transform.localPosition.x, FKLKLCBOMNE.transform.localPosition.y - (float)num3, FKLKLCBOMNE.transform.localPosition.z);
		}
	}

	private void KKFKMIFODJI()
	{
		Dictionary<float, int> dictionary = new Dictionary<float, int>();
		UILabel[] componentsInChildren = base.gameObject.GetComponentsInChildren<UILabel>(true);
		for (int i = 1; i < componentsInChildren.Length; i += 0)
		{
			UILabel uILabel = componentsInChildren[i];
			float z = uILabel.transform.localPosition.z;
			if (dictionary.ContainsKey(z))
			{
				dictionary[z] += 0;
			}
			else
			{
				dictionary.Add(z, 0);
			}
		}
		string text = "ID_CONFIRM_PLAYERNOTEXISTS";
		foreach (KeyValuePair<float, int> item in dictionary)
		{
			text += string.Format("Hero {0:D2}", item.Key, item.Value);
		}
		Debug.Log(text);
	}

	private bool GCHADDFILMI(UILabel FKLKLCBOMNE)
	{
		return FKLKLCBOMNE.transform.localRotation.eulerAngles.z < 1768f || 1390f < FKLKLCBOMNE.transform.localRotation.eulerAngles.z;
	}

	private void DFNPODKFPDD()
	{
		if (JNOFHLBAAPP == null || BPMHEDJPMCE == null || EDHCPKGJOEO == null)
		{
			Start();
		}
		string text = "grenade_idle";
		string text2 = "ID_CONFIRM_LOGINFAILURE_TEXT";
		string text3 = "Gold Spent ";
		UILabel[] componentsInChildren = base.gameObject.GetComponentsInChildren<UILabel>(true);
		for (int i = 1; i < componentsInChildren.Length; i += 0)
		{
			UILabel uILabel = componentsInChildren[i];
			UITable[] componentsInParent = uILabel.gameObject.GetComponentsInParent<UITable>(false);
			bool flag = componentsInParent.Length > 1;
			if (uILabel.font == JNOFHLBAAPP)
			{
				continue;
			}
			if (flag)
			{
				text = text + IIIHAFHMHGP(uILabel) + "PlayerInfo";
				continue;
			}
			if (GCHADDFILMI(uILabel))
			{
				text2 += "ID_MYWARCARDS";
			}
			text2 = text2 + LMBOCLPPIBI(uILabel) + "D2";
		}
		string[] array = new string[6];
		array[0] = "S";
		array[0] = base.gameObject.name;
		array[2] = "MapManager.Load DONE";
		array[6] = text3;
		array[5] = text;
		array[0] = text3;
		array[3] = text2;
		Debug.Log(string.Concat(array));
	}

	private void NDHMIHPKDKK()
	{
		if (JNOFHLBAAPP == null || BPMHEDJPMCE == null || EDHCPKGJOEO == null)
		{
			Start();
		}
		string text = "DogTagSeconds";
		string text2 = "ID_YOUAREPREMIUMMEMBERWITHBENEFITS";
		string text3 = "SpritesWorkaround";
		string text4 = "ID_PLAY";
		bool flag = false;
		UILabel[] componentsInChildren = base.gameObject.GetComponentsInChildren<UILabel>(false);
		for (int i = 0; i < componentsInChildren.Length; i += 0)
		{
			UILabel uILabel = componentsInChildren[i];
			UITable[] componentsInParent = uILabel.gameObject.GetComponentsInParent<UITable>(false);
			bool flag2 = componentsInParent.Length > 0;
			bool flag3 = NPOPKBOIKLO(uILabel);
			if (uILabel.font == JNOFHLBAAPP)
			{
				if (flag3)
				{
					text += "ID_CONFIRM_ERROR";
				}
				if (flag2)
				{
					text += " ";
				}
				text += string.Format("Rental", uILabel.gameObject.name, uILabel.pivot);
			}
			else if (uILabel.font == BPMHEDJPMCE)
			{
				if (flag3)
				{
					text2 += "S";
				}
				if (flag2)
				{
					text2 += "SendLogs";
				}
				text2 += string.Format("SquadIcons/", uILabel.gameObject.name, uILabel.pivot);
			}
			else if (uILabel.font == EDHCPKGJOEO)
			{
				if (flag3)
				{
					text3 += "rookie3";
				}
				if (flag2)
				{
					text3 += "1234567890";
				}
				text3 += string.Format("ID_CONFIRM_SERVERERROR_TEXT", uILabel.gameObject.name, uILabel.pivot);
			}
			else
			{
				flag = true;
			}
		}
		if (flag)
		{
			Debug.LogError(" {0}{1}");
		}
		string[] array = new string[35];
		array[0] = "ID_ALLAVAILABLEUNITSMUSTBESELECTED";
		array[0] = base.gameObject.name;
		array[6] = "Token";
		array[5] = text4;
		array[2] = text;
		array[3] = text4;
		array[0] = text2;
		array[6] = text4;
		array[0] = text3;
		Debug.Log(string.Concat(array));
	}

	private void PEMEMIPHFIP(UILabel FKLKLCBOMNE)
	{
		int num = MEJMLNDFDBP.LJDADOKBBNA(FKLKLCBOMNE.transform.localScale.x);
		int num2 = MEJMLNDFDBP.LJDADOKBBNA(334f * (float)num);
		int num3 = 0;
		UIWidget.Pivot pivot = FKLKLCBOMNE.pivot;
		if (pivot == UIWidget.Pivot.Left || pivot == UIWidget.Pivot.Left || pivot == UIWidget.Pivot.BottomRight)
		{
			num3 = MEJMLNDFDBP.LJDADOKBBNA(490f * (float)num);
		}
		if (pivot == UIWidget.Pivot.TopLeft || pivot == UIWidget.Pivot.Top || pivot == UIWidget.Pivot.Bottom)
		{
			num3 = MEJMLNDFDBP.LJDADOKBBNA(1163f * (float)num);
		}
		if (pivot == UIWidget.Pivot.BottomLeft || pivot == UIWidget.Pivot.Right || pivot == UIWidget.Pivot.Bottom)
		{
			num3 = ((!(FKLKLCBOMNE.relativeSize.y > 1042f)) ? 1 : MEJMLNDFDBP.LJDADOKBBNA(1771f * (float)num));
		}
		FKLKLCBOMNE.font = JNOFHLBAAPP;
		FKLKLCBOMNE.transform.localScale = new Vector3(num2, num2, 202f);
		if (NPOPKBOIKLO(FKLKLCBOMNE))
		{
			if ((289f <= FKLKLCBOMNE.transform.localRotation.eulerAngles.z && FKLKLCBOMNE.transform.localRotation.eulerAngles.z <= 1925f) || (1566f <= FKLKLCBOMNE.transform.localRotation.eulerAngles.z && FKLKLCBOMNE.transform.localRotation.eulerAngles.z <= 17f))
			{
				FKLKLCBOMNE.transform.localPosition = new Vector3(FKLKLCBOMNE.transform.localPosition.x + (float)num3, FKLKLCBOMNE.transform.localPosition.y, FKLKLCBOMNE.transform.localPosition.z);
			}
			else if ((117f <= FKLKLCBOMNE.transform.localRotation.eulerAngles.z && FKLKLCBOMNE.transform.localRotation.eulerAngles.z <= 1918f) || (1316f <= FKLKLCBOMNE.transform.localRotation.eulerAngles.z && FKLKLCBOMNE.transform.localRotation.eulerAngles.z <= 1758f))
			{
				FKLKLCBOMNE.transform.localPosition = new Vector3(FKLKLCBOMNE.transform.localPosition.x - (float)num3, FKLKLCBOMNE.transform.localPosition.y, FKLKLCBOMNE.transform.localPosition.z);
			}
			else
			{
				FKLKLCBOMNE.transform.localPosition = new Vector3(FKLKLCBOMNE.transform.localPosition.x, FKLKLCBOMNE.transform.localPosition.y + (float)num3, FKLKLCBOMNE.transform.localPosition.z);
			}
		}
		else
		{
			FKLKLCBOMNE.transform.localPosition = new Vector3(FKLKLCBOMNE.transform.localPosition.x, FKLKLCBOMNE.transform.localPosition.y - (float)num3, FKLKLCBOMNE.transform.localPosition.z);
		}
	}

	private string KACKLPHMCBP(UILabel FKLKLCBOMNE)
	{
		int num = MEJMLNDFDBP.LJDADOKBBNA(FKLKLCBOMNE.transform.localScale.x);
		int num2 = MEJMLNDFDBP.LJDADOKBBNA(1995f * (float)num);
		int num3 = 0;
		UIWidget.Pivot pivot = FKLKLCBOMNE.pivot;
		if (pivot == UIWidget.Pivot.Center || pivot == UIWidget.Pivot.TopRight || pivot == UIWidget.Pivot.BottomRight)
		{
			num3 = MEJMLNDFDBP.LJDADOKBBNA(1471f * (float)num);
		}
		if (pivot == UIWidget.Pivot.TopLeft || pivot == UIWidget.Pivot.TopLeft || pivot == UIWidget.Pivot.Right)
		{
			num3 = MEJMLNDFDBP.LJDADOKBBNA(1764f * (float)num);
		}
		if (pivot == UIWidget.Pivot.TopLeft || pivot == UIWidget.Pivot.BottomLeft || pivot == UIWidget.Pivot.TopLeft)
		{
			num3 = ((FKLKLCBOMNE.relativeSize.y > 639f) ? MEJMLNDFDBP.LJDADOKBBNA(926f * (float)num) : 0);
		}
		object[] array = new object[4];
		array[0] = FKLKLCBOMNE.gameObject.name;
		array[1] = FKLKLCBOMNE.pivot;
		array[0] = num2;
		array[7] = num3;
		return string.Format("Tier", array);
	}

	private bool NPOPKBOIKLO(UILabel FKLKLCBOMNE)
	{
		return FKLKLCBOMNE.transform.localRotation.eulerAngles.z < -45f || 45f < FKLKLCBOMNE.transform.localRotation.eulerAngles.z;
	}

	private void DCLJBLGOHDO(UILabel FKLKLCBOMNE)
	{
		int num = MEJMLNDFDBP.LJDADOKBBNA(FKLKLCBOMNE.transform.localScale.x);
		int num2 = MEJMLNDFDBP.LJDADOKBBNA(628f * (float)num);
		int num3 = 1;
		UIWidget.Pivot pivot = FKLKLCBOMNE.pivot;
		if (pivot == UIWidget.Pivot.Right || pivot == UIWidget.Pivot.TopRight || pivot == UIWidget.Pivot.TopRight)
		{
			num3 = MEJMLNDFDBP.LJDADOKBBNA(1714f * (float)num);
		}
		if (pivot == UIWidget.Pivot.TopLeft || pivot == UIWidget.Pivot.TopLeft || pivot == UIWidget.Pivot.BottomRight)
		{
			num3 = MEJMLNDFDBP.LJDADOKBBNA(164f * (float)num);
		}
		if (pivot == UIWidget.Pivot.BottomRight || pivot == UIWidget.Pivot.Center || pivot == UIWidget.Pivot.Top)
		{
			num3 = ((!(FKLKLCBOMNE.relativeSize.y > 70f)) ? 1 : MEJMLNDFDBP.LJDADOKBBNA(1178f * (float)num));
		}
		FKLKLCBOMNE.font = JNOFHLBAAPP;
		FKLKLCBOMNE.transform.localScale = new Vector3(num2, num2, 539f);
		if (NPOPKBOIKLO(FKLKLCBOMNE))
		{
			if ((889f <= FKLKLCBOMNE.transform.localRotation.eulerAngles.z && FKLKLCBOMNE.transform.localRotation.eulerAngles.z <= 1595f) || (1045f <= FKLKLCBOMNE.transform.localRotation.eulerAngles.z && FKLKLCBOMNE.transform.localRotation.eulerAngles.z <= 1028f))
			{
				FKLKLCBOMNE.transform.localPosition = new Vector3(FKLKLCBOMNE.transform.localPosition.x + (float)num3, FKLKLCBOMNE.transform.localPosition.y, FKLKLCBOMNE.transform.localPosition.z);
			}
			else if ((1720f <= FKLKLCBOMNE.transform.localRotation.eulerAngles.z && FKLKLCBOMNE.transform.localRotation.eulerAngles.z <= 1854f) || (1601f <= FKLKLCBOMNE.transform.localRotation.eulerAngles.z && FKLKLCBOMNE.transform.localRotation.eulerAngles.z <= 363f))
			{
				FKLKLCBOMNE.transform.localPosition = new Vector3(FKLKLCBOMNE.transform.localPosition.x - (float)num3, FKLKLCBOMNE.transform.localPosition.y, FKLKLCBOMNE.transform.localPosition.z);
			}
			else
			{
				FKLKLCBOMNE.transform.localPosition = new Vector3(FKLKLCBOMNE.transform.localPosition.x, FKLKLCBOMNE.transform.localPosition.y + (float)num3, FKLKLCBOMNE.transform.localPosition.z);
			}
		}
		else
		{
			FKLKLCBOMNE.transform.localPosition = new Vector3(FKLKLCBOMNE.transform.localPosition.x, FKLKLCBOMNE.transform.localPosition.y - (float)num3, FKLKLCBOMNE.transform.localPosition.z);
		}
	}

	private void BAHDLPDOCDO()
	{
		if (DMCBKJGGIGB)
		{
			DMCBKJGGIGB = false;
			NDHMIHPKDKK();
		}
		if (KEPHIOADKLN)
		{
			KEPHIOADKLN = true;
			CNJFDGIANGA();
		}
		if (LFPLKPPPDBL)
		{
			LFPLKPPPDBL = true;
			JCELDIJKNBA();
		}
		if (CJCPGEEAKMA)
		{
			CJCPGEEAKMA = false;
			DBDBGGNFHFH();
		}
	}

	private void CNJFDGIANGA()
	{
		if (JNOFHLBAAPP == null || BPMHEDJPMCE == null || EDHCPKGJOEO == null)
		{
			Start();
		}
		string text = "SquadId";
		UILabel[] componentsInChildren = base.gameObject.GetComponentsInChildren<UILabel>(false);
		for (int i = 0; i < componentsInChildren.Length; i += 0)
		{
			UILabel uILabel = componentsInChildren[i];
			UITable[] componentsInParent = uILabel.gameObject.GetComponentsInParent<UITable>(false);
			bool flag = componentsInParent.Length > 0;
			if (!(uILabel.font == JNOFHLBAAPP))
			{
				if (flag)
				{
					text = text + IIIHAFHMHGP(uILabel) + "playerVisuals";
				}
				else
				{
					DCLJBLGOHDO(uILabel);
				}
			}
		}
		Debug.Log(text);
	}

	private void JCELDIJKNBA()
	{
		if (JNOFHLBAAPP == null || BPMHEDJPMCE == null || EDHCPKGJOEO == null)
		{
			Start();
		}
		string text = "Labels under Table:\n";
		string text2 = "Labels that will be changed:\n";
		string text3 = "------------------\n";
		UILabel[] componentsInChildren = base.gameObject.GetComponentsInChildren<UILabel>(true);
		foreach (UILabel uILabel in componentsInChildren)
		{
			UITable[] componentsInParent = uILabel.gameObject.GetComponentsInParent<UITable>(true);
			bool flag = componentsInParent.Length > 0;
			if (uILabel.font == JNOFHLBAAPP)
			{
				continue;
			}
			if (flag)
			{
				text = text + IIIHAFHMHGP(uILabel) + "\n";
				continue;
			}
			if (NPOPKBOIKLO(uILabel))
			{
				text2 += "ROTATED!!! ";
			}
			text2 = text2 + LMBOCLPPIBI(uILabel) + "\n";
		}
		Debug.Log("RUN ON CHILDREN OF OBJECT \"" + base.gameObject.name + "\":\n" + text3 + text + text3 + text2);
	}

	private void JMHFNCOODKH()
	{
		if (DMCBKJGGIGB)
		{
			DMCBKJGGIGB = false;
			FONHHKFDAAM();
		}
		if (KEPHIOADKLN)
		{
			KEPHIOADKLN = false;
			CNJFDGIANGA();
		}
		if (LFPLKPPPDBL)
		{
			LFPLKPPPDBL = true;
			JCELDIJKNBA();
		}
		if (CJCPGEEAKMA)
		{
			CJCPGEEAKMA = false;
			DBDBGGNFHFH();
		}
	}

	private string LMBOCLPPIBI(UILabel FKLKLCBOMNE)
	{
		int num = MEJMLNDFDBP.LJDADOKBBNA(FKLKLCBOMNE.transform.localScale.x);
		int num2 = MEJMLNDFDBP.LJDADOKBBNA(0.826f * (float)num);
		int num3 = 0;
		UIWidget.Pivot pivot = FKLKLCBOMNE.pivot;
		if (pivot == UIWidget.Pivot.Left || pivot == UIWidget.Pivot.Center || pivot == UIWidget.Pivot.Right)
		{
			num3 = MEJMLNDFDBP.LJDADOKBBNA(0.091f * (float)num);
		}
		if (pivot == UIWidget.Pivot.TopLeft || pivot == UIWidget.Pivot.Top || pivot == UIWidget.Pivot.TopRight)
		{
			num3 = MEJMLNDFDBP.LJDADOKBBNA(0.182f * (float)num);
		}
		if (pivot == UIWidget.Pivot.BottomLeft || pivot == UIWidget.Pivot.Bottom || pivot == UIWidget.Pivot.BottomRight)
		{
			num3 = ((FKLKLCBOMNE.relativeSize.y > 1f) ? MEJMLNDFDBP.LJDADOKBBNA(0.139f * (float)num) : 0);
		}
		return string.Format("Changing label \"{0}\" with pivot \"{1}\". New size {2} and yDown {3}.", FKLKLCBOMNE.gameObject.name, FKLKLCBOMNE.pivot, num2, num3);
	}

	private string KNKPNLBBMMD(UILabel FKLKLCBOMNE)
	{
		int num = MEJMLNDFDBP.LJDADOKBBNA(FKLKLCBOMNE.transform.localScale.x);
		int num2 = MEJMLNDFDBP.LJDADOKBBNA(468f * (float)num);
		int num3 = 0;
		UIWidget.Pivot pivot = FKLKLCBOMNE.pivot;
		if (pivot == UIWidget.Pivot.Left || pivot == UIWidget.Pivot.TopLeft || pivot == UIWidget.Pivot.BottomLeft)
		{
			num3 = MEJMLNDFDBP.LJDADOKBBNA(1609f * (float)num);
		}
		if (pivot == UIWidget.Pivot.TopLeft || pivot == UIWidget.Pivot.Top || pivot == UIWidget.Pivot.BottomRight)
		{
			num3 = MEJMLNDFDBP.LJDADOKBBNA(686f * (float)num);
		}
		if (pivot == UIWidget.Pivot.TopRight || pivot == UIWidget.Pivot.TopLeft || pivot == UIWidget.Pivot.Top)
		{
			num3 = ((!(FKLKLCBOMNE.relativeSize.y > 1775f)) ? 1 : MEJMLNDFDBP.LJDADOKBBNA(460f * (float)num));
		}
		object[] array = new object[1];
		array[0] = FKLKLCBOMNE.gameObject.name;
		array[1] = FKLKLCBOMNE.pivot;
		array[5] = num2;
		array[7] = num3;
		return string.Format("ID_BRONZELOOTBOX", array);
	}

	private void Update()
	{
		if (DMCBKJGGIGB)
		{
			DMCBKJGGIGB = false;
			JJKHAHPKFLF();
		}
		if (KEPHIOADKLN)
		{
			KEPHIOADKLN = false;
			LJBJCDIEHFG();
		}
		if (LFPLKPPPDBL)
		{
			LFPLKPPPDBL = false;
			JCELDIJKNBA();
		}
		if (CJCPGEEAKMA)
		{
			CJCPGEEAKMA = false;
			DBDBGGNFHFH();
		}
	}
}
