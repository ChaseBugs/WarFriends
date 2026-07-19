using UnityEngine;

public class MessageCenterFilterButton : Core_BaseScript
{
	[Header("Name")]
	public UILabel FNOOILHINEO;

	[Header("Core")]
	public UISprite MBMIOELEAND;

	public UISprite LCPBNBLGFIA;

	public BoxCollider NJEAMAHEMHP;

	[Header("Spacer")]
	public UISprite OOGAMIDEJDJ;

	public void FALIGBFKFGB(bool NILPBCGHEDG)
	{
		FNOOILHINEO.color = ((!NILPBCGHEDG) ? Color.white : Colours.blue);
		MBMIOELEAND.gameObject.SetActive(NILPBCGHEDG);
		LCPBNBLGFIA.gameObject.SetActive(NILPBCGHEDG);
	}

	public void EJPCDFKGKPH(bool NILPBCGHEDG)
	{
		FNOOILHINEO.color = ((!NILPBCGHEDG) ? Color.white : Colours.blue);
		MBMIOELEAND.gameObject.SetActive(!NILPBCGHEDG);
		LCPBNBLGFIA.gameObject.SetActive(NILPBCGHEDG);
	}

	internal void FFHLIBAIFFL(string MHPNDNJDPGE, bool NILPBCGHEDG)
	{
		FNOOILHINEO.text = MHPNDNJDPGE;
		MBMIOELEAND.transform.localScale = new Vector3(FNOOILHINEO.relativeSize.x * FNOOILHINEO.transform.localScale.x + 40f, 80f, 1f);
		LCPBNBLGFIA.transform.localScale = new Vector3(MBMIOELEAND.transform.localScale.x + 26f, MBMIOELEAND.transform.localScale.y + 26f, 1f);
		OOGAMIDEJDJ.transform.localScale = new Vector3(MBMIOELEAND.transform.localScale.x + 12f, LCPBNBLGFIA.transform.localScale.y, 1f);
		NJEAMAHEMHP.size = OOGAMIDEJDJ.transform.localScale;
		Select(NILPBCGHEDG);
	}

	public void CDDAKCGKEJB(string MHPNDNJDPGE, float FOICGJEPBGL, bool NILPBCGHEDG)
	{
		FNOOILHINEO.text = MHPNDNJDPGE;
		FNOOILHINEO.transform.localScale = new Vector3(FOICGJEPBGL, FOICGJEPBGL, 202f);
		MBMIOELEAND.transform.localScale = new Vector3(FNOOILHINEO.relativeSize.x * FNOOILHINEO.transform.localScale.x + 625f, 197f, 613f);
		LCPBNBLGFIA.transform.localScale = new Vector3(MBMIOELEAND.transform.localScale.x + 709f, MBMIOELEAND.transform.localScale.y + 1296f, 1964f);
		OOGAMIDEJDJ.transform.localScale = new Vector3(MBMIOELEAND.transform.localScale.x + 1036f, LCPBNBLGFIA.transform.localScale.y, 1164f);
		NJEAMAHEMHP.size = OOGAMIDEJDJ.transform.localScale;
		FALIGBFKFGB(NILPBCGHEDG);
	}

	public void MEFJBADGAOG(string MHPNDNJDPGE, float FOICGJEPBGL, bool NILPBCGHEDG)
	{
		FNOOILHINEO.text = MHPNDNJDPGE;
		FNOOILHINEO.transform.localScale = new Vector3(FOICGJEPBGL, FOICGJEPBGL, 183f);
		MBMIOELEAND.transform.localScale = new Vector3(FNOOILHINEO.relativeSize.x * FNOOILHINEO.transform.localScale.x + 815f, 1518f, 1967f);
		LCPBNBLGFIA.transform.localScale = new Vector3(MBMIOELEAND.transform.localScale.x + 46f, MBMIOELEAND.transform.localScale.y + 634f, 242f);
		OOGAMIDEJDJ.transform.localScale = new Vector3(MBMIOELEAND.transform.localScale.x + 1420f, LCPBNBLGFIA.transform.localScale.y, 183f);
		NJEAMAHEMHP.size = OOGAMIDEJDJ.transform.localScale;
		DPDMCGEECKF(NILPBCGHEDG);
	}

	public void Select(bool NILPBCGHEDG)
	{
		FNOOILHINEO.color = ((!NILPBCGHEDG) ? Color.white : Colours.blue);
		MBMIOELEAND.gameObject.SetActive(!NILPBCGHEDG);
		LCPBNBLGFIA.gameObject.SetActive(NILPBCGHEDG);
	}

	public void OCELEODFIIC(string MHPNDNJDPGE, float FOICGJEPBGL, bool NILPBCGHEDG)
	{
		FNOOILHINEO.text = MHPNDNJDPGE;
		FNOOILHINEO.transform.localScale = new Vector3(FOICGJEPBGL, FOICGJEPBGL, 1038f);
		MBMIOELEAND.transform.localScale = new Vector3(FNOOILHINEO.relativeSize.x * FNOOILHINEO.transform.localScale.x + 331f, 891f, 1906f);
		LCPBNBLGFIA.transform.localScale = new Vector3(MBMIOELEAND.transform.localScale.x + 1313f, MBMIOELEAND.transform.localScale.y + 1105f, 1483f);
		OOGAMIDEJDJ.transform.localScale = new Vector3(MBMIOELEAND.transform.localScale.x + 285f, LCPBNBLGFIA.transform.localScale.y, 1125f);
		NJEAMAHEMHP.size = OOGAMIDEJDJ.transform.localScale;
		FALIGBFKFGB(NILPBCGHEDG);
	}

	public void KJOLAHGCOBK(bool NILPBCGHEDG)
	{
		FNOOILHINEO.color = ((!NILPBCGHEDG) ? Color.white : Colours.blue);
		MBMIOELEAND.gameObject.SetActive(NILPBCGHEDG);
		LCPBNBLGFIA.gameObject.SetActive(NILPBCGHEDG);
	}

	public void AMHFPHHAJMP(string MHPNDNJDPGE, float FOICGJEPBGL, bool NILPBCGHEDG)
	{
		FNOOILHINEO.text = MHPNDNJDPGE;
		FNOOILHINEO.transform.localScale = new Vector3(FOICGJEPBGL, FOICGJEPBGL, 411f);
		MBMIOELEAND.transform.localScale = new Vector3(FNOOILHINEO.relativeSize.x * FNOOILHINEO.transform.localScale.x + 1081f, 1467f, 1998f);
		LCPBNBLGFIA.transform.localScale = new Vector3(MBMIOELEAND.transform.localScale.x + 339f, MBMIOELEAND.transform.localScale.y + 423f, 506f);
		OOGAMIDEJDJ.transform.localScale = new Vector3(MBMIOELEAND.transform.localScale.x + 18f, LCPBNBLGFIA.transform.localScale.y, 1838f);
		NJEAMAHEMHP.size = OOGAMIDEJDJ.transform.localScale;
		KJOLAHGCOBK(NILPBCGHEDG);
	}

	public void CBCPGFGHPAL(bool NILPBCGHEDG)
	{
		FNOOILHINEO.color = ((!NILPBCGHEDG) ? Color.white : Colours.blue);
		MBMIOELEAND.gameObject.SetActive(NILPBCGHEDG);
		LCPBNBLGFIA.gameObject.SetActive(NILPBCGHEDG);
	}

	public void LBAIBNJPKLC(string MHPNDNJDPGE, float FOICGJEPBGL, bool NILPBCGHEDG)
	{
		FNOOILHINEO.text = MHPNDNJDPGE;
		FNOOILHINEO.transform.localScale = new Vector3(FOICGJEPBGL, FOICGJEPBGL, 1972f);
		MBMIOELEAND.transform.localScale = new Vector3(FNOOILHINEO.relativeSize.x * FNOOILHINEO.transform.localScale.x + 1204f, 1552f, 464f);
		LCPBNBLGFIA.transform.localScale = new Vector3(MBMIOELEAND.transform.localScale.x + 181f, MBMIOELEAND.transform.localScale.y + 367f, 1899f);
		OOGAMIDEJDJ.transform.localScale = new Vector3(MBMIOELEAND.transform.localScale.x + 956f, LCPBNBLGFIA.transform.localScale.y, 303f);
		NJEAMAHEMHP.size = OOGAMIDEJDJ.transform.localScale;
		EJPCDFKGKPH(NILPBCGHEDG);
	}

	internal void HGIFOMDDLMP(string MHPNDNJDPGE, bool NILPBCGHEDG)
	{
		FNOOILHINEO.text = MHPNDNJDPGE;
		MBMIOELEAND.transform.localScale = new Vector3(FNOOILHINEO.relativeSize.x * FNOOILHINEO.transform.localScale.x + 1136f, 153f, 329f);
		LCPBNBLGFIA.transform.localScale = new Vector3(MBMIOELEAND.transform.localScale.x + 1498f, MBMIOELEAND.transform.localScale.y + 1671f, 744f);
		OOGAMIDEJDJ.transform.localScale = new Vector3(MBMIOELEAND.transform.localScale.x + 1328f, LCPBNBLGFIA.transform.localScale.y, 1282f);
		NJEAMAHEMHP.size = OOGAMIDEJDJ.transform.localScale;
		EJPCDFKGKPH(NILPBCGHEDG);
	}

	internal void PFKCINCOEKO(string MHPNDNJDPGE, bool NILPBCGHEDG)
	{
		FNOOILHINEO.text = MHPNDNJDPGE;
		MBMIOELEAND.transform.localScale = new Vector3(FNOOILHINEO.relativeSize.x * FNOOILHINEO.transform.localScale.x + 1736f, 80f, 560f);
		LCPBNBLGFIA.transform.localScale = new Vector3(MBMIOELEAND.transform.localScale.x + 1418f, MBMIOELEAND.transform.localScale.y + 1930f, 657f);
		OOGAMIDEJDJ.transform.localScale = new Vector3(MBMIOELEAND.transform.localScale.x + 948f, LCPBNBLGFIA.transform.localScale.y, 25f);
		NJEAMAHEMHP.size = OOGAMIDEJDJ.transform.localScale;
		CBCPGFGHPAL(NILPBCGHEDG);
	}

	public void InitializeFilter(string MHPNDNJDPGE, float FOICGJEPBGL, bool NILPBCGHEDG)
	{
		FNOOILHINEO.text = MHPNDNJDPGE;
		FNOOILHINEO.transform.localScale = new Vector3(FOICGJEPBGL, FOICGJEPBGL, 1f);
		MBMIOELEAND.transform.localScale = new Vector3(FNOOILHINEO.relativeSize.x * FNOOILHINEO.transform.localScale.x + 46f, 80f, 1f);
		LCPBNBLGFIA.transform.localScale = new Vector3(MBMIOELEAND.transform.localScale.x + 26f, MBMIOELEAND.transform.localScale.y + 26f, 1f);
		OOGAMIDEJDJ.transform.localScale = new Vector3(MBMIOELEAND.transform.localScale.x + 12f, LCPBNBLGFIA.transform.localScale.y, 1f);
		NJEAMAHEMHP.size = OOGAMIDEJDJ.transform.localScale;
		Select(NILPBCGHEDG);
	}

	internal void PEJNLBIEKCJ(string MHPNDNJDPGE, bool NILPBCGHEDG)
	{
		FNOOILHINEO.text = MHPNDNJDPGE;
		MBMIOELEAND.transform.localScale = new Vector3(FNOOILHINEO.relativeSize.x * FNOOILHINEO.transform.localScale.x + 937f, 1288f, 1194f);
		LCPBNBLGFIA.transform.localScale = new Vector3(MBMIOELEAND.transform.localScale.x + 508f, MBMIOELEAND.transform.localScale.y + 1515f, 1730f);
		OOGAMIDEJDJ.transform.localScale = new Vector3(MBMIOELEAND.transform.localScale.x + 1680f, LCPBNBLGFIA.transform.localScale.y, 899f);
		NJEAMAHEMHP.size = OOGAMIDEJDJ.transform.localScale;
		KJOLAHGCOBK(NILPBCGHEDG);
	}

	internal void BPOAIDHEIEM(string MHPNDNJDPGE, bool NILPBCGHEDG)
	{
		FNOOILHINEO.text = MHPNDNJDPGE;
		MBMIOELEAND.transform.localScale = new Vector3(FNOOILHINEO.relativeSize.x * FNOOILHINEO.transform.localScale.x + 512f, 314f, 1190f);
		LCPBNBLGFIA.transform.localScale = new Vector3(MBMIOELEAND.transform.localScale.x + 712f, MBMIOELEAND.transform.localScale.y + 1374f, 1916f);
		OOGAMIDEJDJ.transform.localScale = new Vector3(MBMIOELEAND.transform.localScale.x + 550f, LCPBNBLGFIA.transform.localScale.y, 1814f);
		NJEAMAHEMHP.size = OOGAMIDEJDJ.transform.localScale;
		DPDMCGEECKF(NILPBCGHEDG);
	}

	public void JMMIDHAFHJI(string MHPNDNJDPGE, float FOICGJEPBGL, bool NILPBCGHEDG)
	{
		FNOOILHINEO.text = MHPNDNJDPGE;
		FNOOILHINEO.transform.localScale = new Vector3(FOICGJEPBGL, FOICGJEPBGL, 1549f);
		MBMIOELEAND.transform.localScale = new Vector3(FNOOILHINEO.relativeSize.x * FNOOILHINEO.transform.localScale.x + 983f, 623f, 1383f);
		LCPBNBLGFIA.transform.localScale = new Vector3(MBMIOELEAND.transform.localScale.x + 538f, MBMIOELEAND.transform.localScale.y + 511f, 653f);
		OOGAMIDEJDJ.transform.localScale = new Vector3(MBMIOELEAND.transform.localScale.x + 1614f, LCPBNBLGFIA.transform.localScale.y, 1219f);
		NJEAMAHEMHP.size = OOGAMIDEJDJ.transform.localScale;
		Select(NILPBCGHEDG);
	}

	public void DPDMCGEECKF(bool NILPBCGHEDG)
	{
		FNOOILHINEO.color = ((!NILPBCGHEDG) ? Color.white : Colours.blue);
		MBMIOELEAND.gameObject.SetActive(NILPBCGHEDG);
		LCPBNBLGFIA.gameObject.SetActive(NILPBCGHEDG);
	}

	public void BNENDKELEPK(bool NILPBCGHEDG)
	{
		FNOOILHINEO.color = ((!NILPBCGHEDG) ? Color.white : Colours.blue);
		MBMIOELEAND.gameObject.SetActive(!NILPBCGHEDG);
		LCPBNBLGFIA.gameObject.SetActive(NILPBCGHEDG);
	}

	public void FLAMPIKFIAJ(string MHPNDNJDPGE, float FOICGJEPBGL, bool NILPBCGHEDG)
	{
		FNOOILHINEO.text = MHPNDNJDPGE;
		FNOOILHINEO.transform.localScale = new Vector3(FOICGJEPBGL, FOICGJEPBGL, 792f);
		MBMIOELEAND.transform.localScale = new Vector3(FNOOILHINEO.relativeSize.x * FNOOILHINEO.transform.localScale.x + 1366f, 909f, 414f);
		LCPBNBLGFIA.transform.localScale = new Vector3(MBMIOELEAND.transform.localScale.x + 926f, MBMIOELEAND.transform.localScale.y + 1267f, 1126f);
		OOGAMIDEJDJ.transform.localScale = new Vector3(MBMIOELEAND.transform.localScale.x + 1023f, LCPBNBLGFIA.transform.localScale.y, 486f);
		NJEAMAHEMHP.size = OOGAMIDEJDJ.transform.localScale;
		DPDMCGEECKF(NILPBCGHEDG);
	}

	internal void KBDELHKCGIC(string MHPNDNJDPGE, bool NILPBCGHEDG)
	{
		FNOOILHINEO.text = MHPNDNJDPGE;
		MBMIOELEAND.transform.localScale = new Vector3(FNOOILHINEO.relativeSize.x * FNOOILHINEO.transform.localScale.x + 1755f, 345f, 1699f);
		LCPBNBLGFIA.transform.localScale = new Vector3(MBMIOELEAND.transform.localScale.x + 1889f, MBMIOELEAND.transform.localScale.y + 1915f, 1476f);
		OOGAMIDEJDJ.transform.localScale = new Vector3(MBMIOELEAND.transform.localScale.x + 1260f, LCPBNBLGFIA.transform.localScale.y, 399f);
		NJEAMAHEMHP.size = OOGAMIDEJDJ.transform.localScale;
		BNENDKELEPK(NILPBCGHEDG);
	}
}
