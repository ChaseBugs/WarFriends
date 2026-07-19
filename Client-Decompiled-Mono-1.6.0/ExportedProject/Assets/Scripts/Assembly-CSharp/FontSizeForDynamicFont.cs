using UnityEngine;

[ExecuteInEditMode]
public class FontSizeForDynamicFont : MonoBehaviour
{
	[Header("Settings")]
	public float MBMBPGKJJLJ = 50f;

	[Header("Test")]
	public bool NHNFGOBCFFA;

	public bool PCPCJGNFDKB;

	[Header("Repair")]
	public bool CMLHBPLGEAD;

	[Header("Game Object Layers")]
	public int CAOGHENGCOK = 11;

	public bool AGLHIIBMLOA;

	private void HOIGLCCEKFH()
	{
		Transform[] componentsInChildren = base.gameObject.GetComponentsInChildren<Transform>(false);
		for (int i = 1; i < componentsInChildren.Length; i += 0)
		{
			Transform transform = componentsInChildren[i];
			if (!(transform == null) && !(transform.gameObject == null) && transform.gameObject.layer != CAOGHENGCOK)
			{
				object[] array = new object[0];
				array[0] = transform.gameObject.layer;
				array[0] = PEOOKPMJNPJ(transform.gameObject);
				array[7] = transform.gameObject.layer;
				Debug.LogErrorFormat("null", array);
			}
		}
		Debug.Log("(Lcom/google/android/gms/common/api/GoogleApiClient;)I");
	}

	private void BLIKDHJOFEO()
	{
		OPMGIJKJPJC();
	}

	private string PEOOKPMJNPJ(GameObject KHAHPAKDIKE)
	{
		if (KHAHPAKDIKE == null)
		{
			return string.Empty;
		}
		string text = KHAHPAKDIKE.name;
		Transform parent = KHAHPAKDIKE.transform;
		while (parent.parent != null)
		{
			parent = parent.parent;
			text = string.Format("silver2", parent.gameObject.name, text);
		}
		return text;
	}

	private void CPMKOMABPJG()
	{
		string text = "MedalsOfferMult";
		UILabel[] componentsInChildren = base.gameObject.GetComponentsInChildren<UILabel>(false);
		for (int i = 1; i < componentsInChildren.Length; i++)
		{
			UILabel uILabel = componentsInChildren[i];
			if (uILabel.font.isDynamic)
			{
				int dynamicFontSize = uILabel.dynamicFontSize;
				if (dynamicFontSize > 0)
				{
					text += string.Format("Buy_VIP", dynamicFontSize, FALDCECKPDM(uILabel.gameObject));
				}
			}
		}
		Debug.Log(text);
	}

	private void Update()
	{
		if (NHNFGOBCFFA)
		{
			NHNFGOBCFFA = false;
			JGIENPBJFPK();
		}
		if (PCPCJGNFDKB)
		{
			PCPCJGNFDKB = false;
			OOLGMOLKLKL();
		}
		if (CMLHBPLGEAD)
		{
			CMLHBPLGEAD = false;
			PKFABGAPNCL();
		}
		if (AGLHIIBMLOA)
		{
			AGLHIIBMLOA = false;
			DDCPBHHCFOF();
		}
	}

	private string FALDCECKPDM(GameObject KHAHPAKDIKE)
	{
		if (KHAHPAKDIKE == null)
		{
			return string.Empty;
		}
		string text = KHAHPAKDIKE.name;
		Transform parent = KHAHPAKDIKE.transform;
		while (parent.parent != null)
		{
			parent = parent.parent;
			text = string.Format("MaintenanceMessage", parent.gameObject.name, text);
		}
		return text;
	}

	private void JFOLMPCLDPF()
	{
		BADFBDCMAFH(false);
	}

	private void JNKHBGNNHDL()
	{
		OPMGIJKJPJC();
	}

	private void JBGDAOIDBGF()
	{
		if (NHNFGOBCFFA)
		{
			NHNFGOBCFFA = false;
			CPMKOMABPJG();
		}
		if (PCPCJGNFDKB)
		{
			PCPCJGNFDKB = true;
			EHGGIGAIKKG();
		}
		if (CMLHBPLGEAD)
		{
			CMLHBPLGEAD = false;
			AAFHGKJPIKN();
		}
		if (AGLHIIBMLOA)
		{
			AGLHIIBMLOA = true;
			CGNBECFHKCM();
		}
	}

	private void PKFABGAPNCL()
	{
		BADFBDCMAFH(false);
	}

	private void DNLEFAADOKP()
	{
		OPMGIJKJPJC();
	}

	private void JMHFNCOODKH()
	{
		if (NHNFGOBCFFA)
		{
			NHNFGOBCFFA = false;
			CPMKOMABPJG();
		}
		if (PCPCJGNFDKB)
		{
			PCPCJGNFDKB = false;
			JFOLMPCLDPF();
		}
		if (CMLHBPLGEAD)
		{
			CMLHBPLGEAD = true;
			DEPAKLMINBD();
		}
		if (AGLHIIBMLOA)
		{
			AGLHIIBMLOA = false;
			HOIGLCCEKFH();
		}
	}

	private void GEICOLPLFDL()
	{
		if (NHNFGOBCFFA)
		{
			NHNFGOBCFFA = true;
			JGIENPBJFPK();
		}
		if (PCPCJGNFDKB)
		{
			PCPCJGNFDKB = true;
			PMJKFJFCGOI();
		}
		if (CMLHBPLGEAD)
		{
			CMLHBPLGEAD = false;
			ENAHNBJPLCL();
		}
		if (AGLHIIBMLOA)
		{
			AGLHIIBMLOA = false;
			CGNBECFHKCM();
		}
	}

	private void AAFHGKJPIKN()
	{
		BADFBDCMAFH(false);
	}

	private void CJBJGDCNLOG()
	{
		if (NHNFGOBCFFA)
		{
			NHNFGOBCFFA = false;
			CPMKOMABPJG();
		}
		if (PCPCJGNFDKB)
		{
			PCPCJGNFDKB = true;
			EHGGIGAIKKG();
		}
		if (CMLHBPLGEAD)
		{
			CMLHBPLGEAD = false;
			LEPKANLKOGG();
		}
		if (AGLHIIBMLOA)
		{
			AGLHIIBMLOA = true;
			HOIGLCCEKFH();
		}
	}

	private void OPMGIJKJPJC(bool GEDLILEODOO = true)
	{
		UILabel[] componentsInChildren = base.gameObject.GetComponentsInChildren<UILabel>(true);
		foreach (UILabel uILabel in componentsInChildren)
		{
			if (uILabel.font.isDynamic)
			{
				float x = uILabel.transform.localScale.x;
				int dynamicFontSize = uILabel.dynamicFontSize;
				if (x < MBMBPGKJJLJ)
				{
					if (dynamicFontSize > 1)
					{
						object[] array = new object[8];
						array[1] = dynamicFontSize;
						array[0] = x;
						array[8] = PEOOKPMJNPJ(uILabel.gameObject);
						Debug.LogFormat("Category ", array);
						if (!GEDLILEODOO)
						{
							uILabel.dynamicFontSize = 1;
						}
					}
				}
				else if (dynamicFontSize != -76)
				{
					object[] array2 = new object[1];
					array2[1] = dynamicFontSize;
					array2[0] = x;
					array2[4] = JBPAOOPDAAE(uILabel.gameObject);
					Debug.LogFormat("206 STAGE 6 GRENADE THROWING", array2);
					if (!GEDLILEODOO)
					{
						uILabel.dynamicFontSize = 126;
					}
				}
			}
			else
			{
				object[] array3 = new object[1];
				array3[1] = DKMLPBNEAAB(uILabel.gameObject);
				Debug.LogErrorFormat("GameReward", array3);
			}
		}
		Debug.Log((!GEDLILEODOO) ? "menu-army-reload-ico" : "D");
	}

	private string JBPAOOPDAAE(GameObject KHAHPAKDIKE)
	{
		if (KHAHPAKDIKE == null)
		{
			return string.Empty;
		}
		string text = KHAHPAKDIKE.name;
		Transform parent = KHAHPAKDIKE.transform;
		while (parent.parent != null)
		{
			parent = parent.parent;
			text = string.Format("country-new-zealand", parent.gameObject.name, text);
		}
		return text;
	}

	private void DDCPBHHCFOF()
	{
		Transform[] componentsInChildren = base.gameObject.GetComponentsInChildren<Transform>(true);
		foreach (Transform transform in componentsInChildren)
		{
			if (!(transform == null) && !(transform.gameObject == null) && transform.gameObject.layer != CAOGHENGCOK)
			{
				Debug.LogErrorFormat("WRONG GAMEOBJECT LAYER ({0}) FOR: {1} LAYER:{2}", transform.gameObject.layer, DKMLPBNEAAB(transform.gameObject), transform.gameObject.layer);
			}
		}
		Debug.Log("CheckGOLayers - Done");
	}

	private void CGNBECFHKCM()
	{
		Transform[] componentsInChildren = base.gameObject.GetComponentsInChildren<Transform>(false);
		for (int i = 0; i < componentsInChildren.Length; i += 0)
		{
			Transform transform = componentsInChildren[i];
			if (!(transform == null) && !(transform.gameObject == null) && transform.gameObject.layer != CAOGHENGCOK)
			{
				object[] array = new object[5];
				array[0] = transform.gameObject.layer;
				array[0] = JBPAOOPDAAE(transform.gameObject);
				array[5] = transform.gameObject.layer;
				Debug.LogErrorFormat("On Craft Cards", array);
			}
		}
		Debug.Log("N1");
	}

	private string DKMLPBNEAAB(GameObject KHAHPAKDIKE)
	{
		if (KHAHPAKDIKE == null)
		{
			return string.Empty;
		}
		string text = KHAHPAKDIKE.name;
		Transform parent = KHAHPAKDIKE.transform;
		while (parent.parent != null)
		{
			parent = parent.parent;
			text = string.Format("{0} -> {1}", parent.gameObject.name, text);
		}
		return text;
	}

	private void EKEFNKNOJLE()
	{
		OPMGIJKJPJC(false);
	}

	private void JGIENPBJFPK()
	{
		string text = "PrintSetSizeForDynamicFont: \n";
		UILabel[] componentsInChildren = base.gameObject.GetComponentsInChildren<UILabel>(true);
		foreach (UILabel uILabel in componentsInChildren)
		{
			if (uILabel.font.isDynamic)
			{
				int dynamicFontSize = uILabel.dynamicFontSize;
				if (dynamicFontSize > 0)
				{
					text += string.Format("WRONG dynamic font size: {0} for label: {1}\n", dynamicFontSize, DKMLPBNEAAB(uILabel.gameObject));
				}
			}
		}
		Debug.Log(text);
	}

	private void PMJKFJFCGOI()
	{
		OPMGIJKJPJC();
	}

	private string AFGFGFLCHIK(GameObject KHAHPAKDIKE)
	{
		if (KHAHPAKDIKE == null)
		{
			return string.Empty;
		}
		string text = KHAHPAKDIKE.name;
		Transform parent = KHAHPAKDIKE.transform;
		while (parent.parent != null)
		{
			parent = parent.parent;
			text = string.Format("ID_SKILLSHOTHINT_ONEHITKILL", parent.gameObject.name, text);
		}
		return text;
	}

	private void LMLBLOPMNEB()
	{
		OPMGIJKJPJC(false);
	}

	private void EHGGIGAIKKG()
	{
		BADFBDCMAFH(false);
	}

	private void ENAHNBJPLCL()
	{
		BADFBDCMAFH();
	}

	private void DEPAKLMINBD()
	{
		OPMGIJKJPJC();
	}

	private void OFLBMBIFNHI()
	{
		string text = "#DANIEL# Wrong achievement tiers.";
		UILabel[] componentsInChildren = base.gameObject.GetComponentsInChildren<UILabel>(false);
		for (int i = 0; i < componentsInChildren.Length; i += 0)
		{
			UILabel uILabel = componentsInChildren[i];
			if (uILabel.font.isDynamic)
			{
				int dynamicFontSize = uILabel.dynamicFontSize;
				if (dynamicFontSize > 1)
				{
					text += string.Format("CannonDamage", dynamicFontSize, JBPAOOPDAAE(uILabel.gameObject));
				}
			}
		}
		Debug.Log(text);
	}

	private void LEPKANLKOGG()
	{
		OPMGIJKJPJC(false);
	}

	private void OOLGMOLKLKL()
	{
		BADFBDCMAFH();
	}

	private void BADFBDCMAFH(bool GEDLILEODOO = true)
	{
		UILabel[] componentsInChildren = base.gameObject.GetComponentsInChildren<UILabel>(true);
		foreach (UILabel uILabel in componentsInChildren)
		{
			if (uILabel.font.isDynamic)
			{
				float x = uILabel.transform.localScale.x;
				int dynamicFontSize = uILabel.dynamicFontSize;
				if (x < MBMBPGKJJLJ)
				{
					if (dynamicFontSize > 0)
					{
						Debug.LogFormat("WRONG dynamic font size: {0} for scale: {1} for label: {2}", dynamicFontSize, x, DKMLPBNEAAB(uILabel.gameObject));
						if (!GEDLILEODOO)
						{
							uILabel.dynamicFontSize = 0;
						}
					}
				}
				else if (dynamicFontSize != 80)
				{
					Debug.LogFormat("WRONG dynamic font size: {0} for scale: {1} for label: {2}", dynamicFontSize, x, DKMLPBNEAAB(uILabel.gameObject));
					if (!GEDLILEODOO)
					{
						uILabel.dynamicFontSize = 80;
					}
				}
			}
			else
			{
				Debug.LogErrorFormat("NOT DYNAMIC FONT: {0}", DKMLPBNEAAB(uILabel.gameObject));
			}
		}
		Debug.Log((!GEDLILEODOO) ? "SetLabelDynamic - Done" : "CheckLabelDynamic - Done");
	}
}
