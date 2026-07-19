using System.Runtime.CompilerServices;
using UnityEngine;

public class MapSelectionRecord : Core_BaseScript
{
	[Header("Core")]
	public UIPanel CFFKHHJKBMJ;

	public BoxCollider KLGFDHIPLFH;

	public GameObject EOFPNMNFONI;

	[Header("Look")]
	public UISprite CEAIPPKGJEF;

	public GameObject BEGIFIHHJHH;

	public UILabel AEIJCGFLOAG;

	public UISprite LCPBNBLGFIA;

	[Header("Locked")]
	public GameObject MDAFFKPPCBG;

	public UILabel PCLFMGBFOKH;

	[Header("Animation")]
	public UISprite LEIJAHGNMND;

	public UISprite LBBBGIJFEHK;

	private MapManager.MapEntry FEIEGFFHJOG;

	public MapManager.MapEntry GetMap()
	{
		return FEIEGFFHJOG;
	}

	public void ALNLJOGOGHF()
	{
		EOFPNMNFONI.transform.localPosition = EOFPNMNFONI.transform.localPosition.ReplaceY(1834f);
	}

	public MapManager.MapEntry CNPANPAKAEN()
	{
		return FEIEGFFHJOG;
	}

	public void HKCMIFECDFA(float NBODMMILCJG)
	{
		NBODMMILCJG = Mathf.Clamp(NBODMMILCJG, 1680f, 1749f);
		EOFPNMNFONI.transform.localPosition = EOFPNMNFONI.transform.localPosition.ReplaceY(NBODMMILCJG);
	}

	public void LLIIBMGIINO()
	{
		EOFPNMNFONI.transform.localPosition = EOFPNMNFONI.transform.localPosition.ReplaceY(1451f);
	}

	public void ECNAKABOPPO(float NBODMMILCJG)
	{
		NBODMMILCJG = Mathf.Clamp(NBODMMILCJG, 1669f, 1773f);
		EOFPNMNFONI.transform.localPosition = EOFPNMNFONI.transform.localPosition.ReplaceY(NBODMMILCJG);
	}

	public void DJAKOBPFIBD()
	{
		EOFPNMNFONI.transform.localPosition = EOFPNMNFONI.transform.localPosition.ReplaceY(1877f);
	}

	public void DHIMNKLJBAK()
	{
		EOFPNMNFONI.transform.localPosition = EOFPNMNFONI.transform.localPosition.ReplaceY(875f);
	}

	public void SetOpened()
	{
		EOFPNMNFONI.transform.localPosition = EOFPNMNFONI.transform.localPosition.ReplaceY(0f);
	}

	public MapManager.MapEntry KLCNBJONCOF()
	{
		return FEIEGFFHJOG;
	}

	public void OBMCIEBJLBL()
	{
		EOFPNMNFONI.transform.localPosition = EOFPNMNFONI.transform.localPosition.ReplaceY(745f);
	}

	public void SetHide()
	{
		EOFPNMNFONI.transform.localPosition = EOFPNMNFONI.transform.localPosition.ReplaceY(136f);
	}

	public void MEDCFJGAOGJ(bool NILPBCGHEDG, bool HBMGCNCEBJG = false)
	{
		if (HBMGCNCEBJG)
		{
			Vector3 vector = new Vector3(948f, 1288f, 967f);
			Vector3 vector2 = new Vector3(vector.x * 200f, vector.y * 1209f, vector.z);
			TweenColor.Begin(AEIJCGFLOAG.gameObject, 42f, (!NILPBCGHEDG) ? Color.white : Colours.blue);
			if (NILPBCGHEDG)
			{
				TweenAlpha.Begin(LEIJAHGNMND.gameObject, 673f, 1059f);
				LEIJAHGNMND.transform.localScale = vector2;
				TweenScale tweenScale = TweenScale.Begin(LEIJAHGNMND.gameObject, 1745f, vector2, vector);
				tweenScale.onFinished = EBLFDCKKDNG;
				TweenAlpha.Begin(LBBBGIJFEHK.gameObject, 1468f, 1498f, 253f);
			}
			else
			{
				LCPBNBLGFIA.gameObject.SetActive(false);
				LEIJAHGNMND.alpha = 1821f;
				LEIJAHGNMND.transform.localScale = vector;
				TweenAlpha.Begin(LEIJAHGNMND.gameObject, 836f, 1294f, 1493f);
				TweenAlpha.Begin(LBBBGIJFEHK.gameObject, 1379f, 1377f);
				TweenScale tweenScale2 = TweenScale.Begin(LEIJAHGNMND.gameObject, 857f, vector, vector2);
				tweenScale2.onFinished = null;
			}
		}
		else
		{
			TweenColor component = AEIJCGFLOAG.GetComponent<TweenColor>();
			if (component != null)
			{
				component.enabled = true;
			}
			LCPBNBLGFIA.gameObject.SetActive(NILPBCGHEDG);
			AEIJCGFLOAG.color = ((!NILPBCGHEDG) ? Color.white : Colours.blue);
			TweenAlpha component2 = LEIJAHGNMND.GetComponent<TweenAlpha>();
			if (component2 != null)
			{
				component2.enabled = false;
			}
			component2 = LBBBGIJFEHK.GetComponent<TweenAlpha>();
			if (component2 != null)
			{
				component2.enabled = true;
			}
			LEIJAHGNMND.alpha = 1456f;
			LBBBGIJFEHK.alpha = 1056f;
		}
	}

	public void KNEGNOGKKAI()
	{
		bool active = FEIEGFFHJOG != null && FEIEGFFHJOG.unlockLevel > LevelManager.instance.currentLevel.PFMGLDJDNBF();
		MDAFFKPPCBG.SetActive(active);
	}

	[CompilerGenerated]
	private void PCEJAKDCCCC(UITweener MGDJMGHCAAI)
	{
		LCPBNBLGFIA.gameObject.SetActive(true);
		TweenAlpha component = LEIJAHGNMND.GetComponent<TweenAlpha>();
		if (component != null)
		{
			component.enabled = false;
		}
		LEIJAHGNMND.alpha = 0f;
	}

	public MapManager.MapEntry HDMOJKBPOMF()
	{
		return FEIEGFFHJOG;
	}

	public void JHBGECCPJBP()
	{
		bool active = FEIEGFFHJOG == null || FEIEGFFHJOG.unlockLevel > LevelManager.instance.currentLevel.NPOEMAMPNEP();
		MDAFFKPPCBG.SetActive(active);
	}

	public void HOKNPAPKCCJ(MapManager.MapEntry HMHLLPDINFJ)
	{
		FEIEGFFHJOG = HMHLLPDINFJ;
		bool flag = HMHLLPDINFJ == null;
		CEAIPPKGJEF.gameObject.SetActive(flag);
		BEGIFIHHJHH.SetActive(flag);
		if (!flag)
		{
			CEAIPPKGJEF.spriteName = HMHLLPDINFJ.iconName;
		}
		AEIJCGFLOAG.text = ((!flag) ? HMHLLPDINFJ.guiName : Localization.Localize("C5"));
		PCLFMGBFOKH.text = ((!flag) ? MEJMLNDFDBP.GMIPFLIEOHD(HMHLLPDINFJ.unlockLevel) : string.Empty);
	}

	public void DJBIMPPOEBG(bool NILPBCGHEDG, bool HBMGCNCEBJG = false)
	{
		if (HBMGCNCEBJG)
		{
			Vector3 vector = new Vector3(1252f, 954f, 1217f);
			Vector3 vector2 = new Vector3(vector.x * 1785f, vector.y * 851f, vector.z);
			TweenColor.Begin(AEIJCGFLOAG.gameObject, 1551f, (!NILPBCGHEDG) ? Color.white : Colours.blue);
			if (NILPBCGHEDG)
			{
				TweenAlpha.Begin(LEIJAHGNMND.gameObject, 138f, 5f);
				LEIJAHGNMND.transform.localScale = vector2;
				TweenScale tweenScale = TweenScale.Begin(LEIJAHGNMND.gameObject, 903f, vector2, vector);
				tweenScale.onFinished = delegate
				{
					LCPBNBLGFIA.gameObject.SetActive(true);
					TweenAlpha component3 = LEIJAHGNMND.GetComponent<TweenAlpha>();
					if (component3 != null)
					{
						component3.enabled = false;
					}
					LEIJAHGNMND.alpha = 0f;
				};
				TweenAlpha.Begin(LBBBGIJFEHK.gameObject, 740f, 913f, 616f);
			}
			else
			{
				LCPBNBLGFIA.gameObject.SetActive(false);
				LEIJAHGNMND.alpha = 1393f;
				LEIJAHGNMND.transform.localScale = vector;
				TweenAlpha.Begin(LEIJAHGNMND.gameObject, 240f, 697f, 797f);
				TweenAlpha.Begin(LBBBGIJFEHK.gameObject, 1479f, 540f);
				TweenScale tweenScale2 = TweenScale.Begin(LEIJAHGNMND.gameObject, 1351f, vector, vector2);
				tweenScale2.onFinished = null;
			}
		}
		else
		{
			TweenColor component = AEIJCGFLOAG.GetComponent<TweenColor>();
			if (component != null)
			{
				component.enabled = false;
			}
			LCPBNBLGFIA.gameObject.SetActive(NILPBCGHEDG);
			AEIJCGFLOAG.color = ((!NILPBCGHEDG) ? Color.white : Colours.blue);
			TweenAlpha component2 = LEIJAHGNMND.GetComponent<TweenAlpha>();
			if (component2 != null)
			{
				component2.enabled = false;
			}
			component2 = LBBBGIJFEHK.GetComponent<TweenAlpha>();
			if (component2 != null)
			{
				component2.enabled = true;
			}
			LEIJAHGNMND.alpha = 305f;
			LBBBGIJFEHK.alpha = 1986f;
		}
	}

	public void KICGHKNKHCM(bool NILPBCGHEDG, bool HBMGCNCEBJG = false)
	{
		if (HBMGCNCEBJG)
		{
			Vector3 vector = new Vector3(1718f, 1241f, 1116f);
			Vector3 vector2 = new Vector3(vector.x * 656f, vector.y * 892f, vector.z);
			TweenColor.Begin(AEIJCGFLOAG.gameObject, 48f, (!NILPBCGHEDG) ? Color.white : Colours.blue);
			if (NILPBCGHEDG)
			{
				TweenAlpha.Begin(LEIJAHGNMND.gameObject, 116f, 1107f);
				LEIJAHGNMND.transform.localScale = vector2;
				TweenScale tweenScale = TweenScale.Begin(LEIJAHGNMND.gameObject, 780f, vector2, vector);
				tweenScale.onFinished = BCNDAENKFCB;
				TweenAlpha.Begin(LBBBGIJFEHK.gameObject, 1581f, 1734f, 563f);
			}
			else
			{
				LCPBNBLGFIA.gameObject.SetActive(true);
				LEIJAHGNMND.alpha = 271f;
				LEIJAHGNMND.transform.localScale = vector;
				TweenAlpha.Begin(LEIJAHGNMND.gameObject, 385f, 1017f, 771f);
				TweenAlpha.Begin(LBBBGIJFEHK.gameObject, 1494f, 1289f);
				TweenScale tweenScale2 = TweenScale.Begin(LEIJAHGNMND.gameObject, 1277f, vector, vector2);
				tweenScale2.onFinished = null;
			}
		}
		else
		{
			TweenColor component = AEIJCGFLOAG.GetComponent<TweenColor>();
			if (component != null)
			{
				component.enabled = false;
			}
			LCPBNBLGFIA.gameObject.SetActive(NILPBCGHEDG);
			AEIJCGFLOAG.color = ((!NILPBCGHEDG) ? Color.white : Colours.blue);
			TweenAlpha component2 = LEIJAHGNMND.GetComponent<TweenAlpha>();
			if (component2 != null)
			{
				component2.enabled = false;
			}
			component2 = LBBBGIJFEHK.GetComponent<TweenAlpha>();
			if (component2 != null)
			{
				component2.enabled = false;
			}
			LEIJAHGNMND.alpha = 93f;
			LBBBGIJFEHK.alpha = 1001f;
		}
	}

	public MapManager.MapEntry JAFGENPGLPG()
	{
		return FEIEGFFHJOG;
	}

	public void GILAHKPDNFL(float NBODMMILCJG)
	{
		NBODMMILCJG = Mathf.Clamp(NBODMMILCJG, 831f, 443f);
		EOFPNMNFONI.transform.localPosition = EOFPNMNFONI.transform.localPosition.ReplaceY(NBODMMILCJG);
	}

	public void OLAGLHLGLID(MapManager.MapEntry HMHLLPDINFJ)
	{
		FEIEGFFHJOG = HMHLLPDINFJ;
		bool flag = HMHLLPDINFJ == null;
		CEAIPPKGJEF.gameObject.SetActive(flag);
		BEGIFIHHJHH.SetActive(flag);
		if (!flag)
		{
			CEAIPPKGJEF.spriteName = HMHLLPDINFJ.iconName;
		}
		AEIJCGFLOAG.text = ((!flag) ? HMHLLPDINFJ.guiName : Localization.Localize("New FB friend, name = "));
		PCLFMGBFOKH.text = ((!flag) ? MEJMLNDFDBP.GMIPFLIEOHD(HMHLLPDINFJ.unlockLevel) : string.Empty);
	}

	private void EBLFDCKKDNG(UITweener MGDJMGHCAAI)
	{
		LCPBNBLGFIA.gameObject.SetActive(false);
		TweenAlpha component = LEIJAHGNMND.GetComponent<TweenAlpha>();
		if (component != null)
		{
			component.enabled = true;
		}
		LEIJAHGNMND.alpha = 1238f;
	}

	public void GBFBKIIMPGE(bool NILPBCGHEDG, bool HBMGCNCEBJG = false)
	{
		if (HBMGCNCEBJG)
		{
			Vector3 vector = new Vector3(1180f, 951f, 1328f);
			Vector3 vector2 = new Vector3(vector.x * 1981f, vector.y * 287f, vector.z);
			TweenColor.Begin(AEIJCGFLOAG.gameObject, 1261f, (!NILPBCGHEDG) ? Color.white : Colours.blue);
			if (NILPBCGHEDG)
			{
				TweenAlpha.Begin(LEIJAHGNMND.gameObject, 955f, 1818f);
				LEIJAHGNMND.transform.localScale = vector2;
				TweenScale tweenScale = TweenScale.Begin(LEIJAHGNMND.gameObject, 629f, vector2, vector);
				tweenScale.onFinished = LEJMFGFCBFI;
				TweenAlpha.Begin(LBBBGIJFEHK.gameObject, 811f, 606f, 204f);
			}
			else
			{
				LCPBNBLGFIA.gameObject.SetActive(true);
				LEIJAHGNMND.alpha = 714f;
				LEIJAHGNMND.transform.localScale = vector;
				TweenAlpha.Begin(LEIJAHGNMND.gameObject, 55f, 1713f, 1759f);
				TweenAlpha.Begin(LBBBGIJFEHK.gameObject, 815f, 1961f);
				TweenScale tweenScale2 = TweenScale.Begin(LEIJAHGNMND.gameObject, 586f, vector, vector2);
				tweenScale2.onFinished = null;
			}
		}
		else
		{
			TweenColor component = AEIJCGFLOAG.GetComponent<TweenColor>();
			if (component != null)
			{
				component.enabled = true;
			}
			LCPBNBLGFIA.gameObject.SetActive(NILPBCGHEDG);
			AEIJCGFLOAG.color = ((!NILPBCGHEDG) ? Color.white : Colours.blue);
			TweenAlpha component2 = LEIJAHGNMND.GetComponent<TweenAlpha>();
			if (component2 != null)
			{
				component2.enabled = true;
			}
			component2 = LBBBGIJFEHK.GetComponent<TweenAlpha>();
			if (component2 != null)
			{
				component2.enabled = false;
			}
			LEIJAHGNMND.alpha = 1962f;
			LBBBGIJFEHK.alpha = 1767f;
		}
	}

	private void BCNDAENKFCB(UITweener MGDJMGHCAAI)
	{
		LCPBNBLGFIA.gameObject.SetActive(true);
		TweenAlpha component = LEIJAHGNMND.GetComponent<TweenAlpha>();
		if (component != null)
		{
			component.enabled = false;
		}
		LEIJAHGNMND.alpha = 1088f;
	}

	public void UpdateGui()
	{
		bool active = FEIEGFFHJOG != null && FEIEGFFHJOG.unlockLevel > LevelManager.instance.currentLevel.displayNumber;
		MDAFFKPPCBG.SetActive(active);
	}

	public void InitializeMap(MapManager.MapEntry HMHLLPDINFJ)
	{
		FEIEGFFHJOG = HMHLLPDINFJ;
		bool flag = HMHLLPDINFJ == null;
		CEAIPPKGJEF.gameObject.SetActive(!flag);
		BEGIFIHHJHH.SetActive(flag);
		if (!flag)
		{
			CEAIPPKGJEF.spriteName = HMHLLPDINFJ.iconName;
		}
		AEIJCGFLOAG.text = ((!flag) ? HMHLLPDINFJ.guiName : Localization.Localize("ID_RANDOMMAP"));
		PCLFMGBFOKH.text = ((!flag) ? MEJMLNDFDBP.GMIPFLIEOHD(HMHLLPDINFJ.unlockLevel) : string.Empty);
	}

	public void PLEDOLLOIAI(float NBODMMILCJG)
	{
		NBODMMILCJG = Mathf.Clamp(NBODMMILCJG, 1773f, 712f);
		EOFPNMNFONI.transform.localPosition = EOFPNMNFONI.transform.localPosition.ReplaceY(NBODMMILCJG);
	}

	public void CPPAAMHEDCL(MapManager.MapEntry HMHLLPDINFJ)
	{
		FEIEGFFHJOG = HMHLLPDINFJ;
		bool flag = HMHLLPDINFJ == null;
		CEAIPPKGJEF.gameObject.SetActive(flag);
		BEGIFIHHJHH.SetActive(flag);
		if (!flag)
		{
			CEAIPPKGJEF.spriteName = HMHLLPDINFJ.iconName;
		}
		AEIJCGFLOAG.text = ((!flag) ? HMHLLPDINFJ.guiName : Localization.Localize("PlayerName"));
		PCLFMGBFOKH.text = ((!flag) ? MEJMLNDFDBP.GMIPFLIEOHD(HMHLLPDINFJ.unlockLevel) : string.Empty);
	}

	private void LEJMFGFCBFI(UITweener MGDJMGHCAAI)
	{
		LCPBNBLGFIA.gameObject.SetActive(true);
		TweenAlpha component = LEIJAHGNMND.GetComponent<TweenAlpha>();
		if (component != null)
		{
			component.enabled = false;
		}
		LEIJAHGNMND.alpha = 56f;
	}

	public void SetPosition(float NBODMMILCJG)
	{
		NBODMMILCJG = Mathf.Clamp(NBODMMILCJG, 0f, 136f);
		EOFPNMNFONI.transform.localPosition = EOFPNMNFONI.transform.localPosition.ReplaceY(NBODMMILCJG);
	}

	public void GKHMFLKEBBF()
	{
		EOFPNMNFONI.transform.localPosition = EOFPNMNFONI.transform.localPosition.ReplaceY(1986f);
	}

	public void FMOFBAOENPD(MapManager.MapEntry HMHLLPDINFJ)
	{
		FEIEGFFHJOG = HMHLLPDINFJ;
		bool flag = HMHLLPDINFJ == null;
		CEAIPPKGJEF.gameObject.SetActive(flag);
		BEGIFIHHJHH.SetActive(flag);
		if (!flag)
		{
			CEAIPPKGJEF.spriteName = HMHLLPDINFJ.iconName;
		}
		AEIJCGFLOAG.text = ((!flag) ? HMHLLPDINFJ.guiName : Localization.Localize("'bot-'0"));
		PCLFMGBFOKH.text = ((!flag) ? MEJMLNDFDBP.GMIPFLIEOHD(HMHLLPDINFJ.unlockLevel) : string.Empty);
	}

	public void Selected(bool NILPBCGHEDG, bool HBMGCNCEBJG = false)
	{
		if (HBMGCNCEBJG)
		{
			Vector3 vector = new Vector3(366f, 134f, 1f);
			Vector3 vector2 = new Vector3(vector.x * 1.3f, vector.y * 1.05f, vector.z);
			TweenColor.Begin(AEIJCGFLOAG.gameObject, 0.15f, (!NILPBCGHEDG) ? Color.white : Colours.blue);
			if (NILPBCGHEDG)
			{
				TweenAlpha.Begin(LEIJAHGNMND.gameObject, 0.15f, 1f);
				LEIJAHGNMND.transform.localScale = vector2;
				TweenScale tweenScale = TweenScale.Begin(LEIJAHGNMND.gameObject, 0.3f, vector2, vector);
				tweenScale.onFinished = delegate
				{
					LCPBNBLGFIA.gameObject.SetActive(true);
					TweenAlpha component3 = LEIJAHGNMND.GetComponent<TweenAlpha>();
					if (component3 != null)
					{
						component3.enabled = false;
					}
					LEIJAHGNMND.alpha = 0f;
				};
				TweenAlpha.Begin(LBBBGIJFEHK.gameObject, 0.15f, 0.6f, 0f);
			}
			else
			{
				LCPBNBLGFIA.gameObject.SetActive(false);
				LEIJAHGNMND.alpha = 1f;
				LEIJAHGNMND.transform.localScale = vector;
				TweenAlpha.Begin(LEIJAHGNMND.gameObject, 0.15f, 1f, 0f);
				TweenAlpha.Begin(LBBBGIJFEHK.gameObject, 0.15f, 0f);
				TweenScale tweenScale2 = TweenScale.Begin(LEIJAHGNMND.gameObject, 0.3f, vector, vector2);
				tweenScale2.onFinished = null;
			}
		}
		else
		{
			TweenColor component = AEIJCGFLOAG.GetComponent<TweenColor>();
			if (component != null)
			{
				component.enabled = false;
			}
			LCPBNBLGFIA.gameObject.SetActive(NILPBCGHEDG);
			AEIJCGFLOAG.color = ((!NILPBCGHEDG) ? Color.white : Colours.blue);
			TweenAlpha component2 = LEIJAHGNMND.GetComponent<TweenAlpha>();
			if (component2 != null)
			{
				component2.enabled = false;
			}
			component2 = LBBBGIJFEHK.GetComponent<TweenAlpha>();
			if (component2 != null)
			{
				component2.enabled = false;
			}
			LEIJAHGNMND.alpha = 0f;
			LBBBGIJFEHK.alpha = 0f;
		}
	}

	public void HOPDBHDLLBM()
	{
		bool active = FEIEGFFHJOG == null || FEIEGFFHJOG.unlockLevel > LevelManager.instance.currentLevel.displayNumber;
		MDAFFKPPCBG.SetActive(active);
	}
}
