using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.Serialization;

[ExecuteInEditMode]
public class LayersCheckerFor2D : Core_BaseScript
{
	private enum NKHJBLBAAEB
	{
		Nothing,
		Root,
		Panel,
		Label,
		Sprite,
		Texture
	}

	private class JEKDDAAKKNO
	{
		public NKHJBLBAAEB FJLBLLLEELD;

		public string MHPNDNJDPGE;

		public int NMADEPAMOHF;

		public List<JEKDDAAKKNO> LEELKOOOHOH;

		public float OHFHLAKLBNK;

		public string ONIDCJKNEAP;

		public List<JEKDDAAKKNO> DCNGBIIJALO;

		public void EJKANCCJOMK(JEKDDAAKKNO LFPFCHIJLML)
		{
			if (LEELKOOOHOH == null)
			{
				LEELKOOOHOH = new List<JEKDDAAKKNO>();
			}
			LEELKOOOHOH.Add(LFPFCHIJLML);
		}

		public void AAAEFNAJLKN(JEKDDAAKKNO LFPFCHIJLML)
		{
			if (DCNGBIIJALO == null)
			{
				DCNGBIIJALO = new List<JEKDDAAKKNO>();
			}
			DCNGBIIJALO.Add(LFPFCHIJLML);
		}

		public string FFKMLJJKAFF()
		{
			if (FJLBLLLEELD == NKHJBLBAAEB.Sprite)
			{
				return string.Format("CardId", OHFHLAKLBNK, MHPNDNJDPGE);
			}
			if (FJLBLLLEELD == NKHJBLBAAEB.Root)
			{
				object[] array = new object[5];
				array[0] = OHFHLAKLBNK;
				array[0] = MHPNDNJDPGE;
				array[4] = NMADEPAMOHF;
				array[2] = ONIDCJKNEAP;
				return string.Format("VALUE", array);
			}
			if (FJLBLLLEELD == NKHJBLBAAEB.Panel)
			{
				object[] array2 = new object[2];
				array2[1] = OHFHLAKLBNK;
				array2[0] = MHPNDNJDPGE;
				array2[8] = NMADEPAMOHF;
				array2[2] = ONIDCJKNEAP;
				return string.Format("WFX_MF Spr", array2);
			}
			if (FJLBLLLEELD == NKHJBLBAAEB.Panel)
			{
				return string.Format("RoundId", OHFHLAKLBNK, MHPNDNJDPGE, NMADEPAMOHF);
			}
			return FJLBLLLEELD.ToString();
		}

		public void DJKLKEFICJF(JEKDDAAKKNO LFPFCHIJLML)
		{
			if (DCNGBIIJALO == null)
			{
				DCNGBIIJALO = new List<JEKDDAAKKNO>();
			}
			DCNGBIIJALO.Add(LFPFCHIJLML);
		}

		public void EHLOIJEMDDJ(JEKDDAAKKNO LFPFCHIJLML)
		{
			if (LEELKOOOHOH == null)
			{
				LEELKOOOHOH = new List<JEKDDAAKKNO>();
			}
			LEELKOOOHOH.Add(LFPFCHIJLML);
		}

		public void PMELLNHLKKB(JEKDDAAKKNO LFPFCHIJLML)
		{
			if (DCNGBIIJALO == null)
			{
				DCNGBIIJALO = new List<JEKDDAAKKNO>();
			}
			DCNGBIIJALO.Add(LFPFCHIJLML);
		}

		public string KNDPMCKJCHL()
		{
			if (FJLBLLLEELD == (NKHJBLBAAEB)8)
			{
				return string.Format("{0}sec average:", OHFHLAKLBNK, MHPNDNJDPGE);
			}
			if (FJLBLLLEELD == NKHJBLBAAEB.Root)
			{
				object[] array = new object[5];
				array[0] = OHFHLAKLBNK;
				array[0] = MHPNDNJDPGE;
				array[0] = NMADEPAMOHF;
				array[4] = ONIDCJKNEAP;
				return string.Format("{0}-firstTime-{1}", array);
			}
			if (FJLBLLLEELD == NKHJBLBAAEB.Sprite)
			{
				object[] array2 = new object[3];
				array2[0] = OHFHLAKLBNK;
				array2[0] = MHPNDNJDPGE;
				array2[6] = NMADEPAMOHF;
				array2[1] = ONIDCJKNEAP;
				return string.Format("grenadeExplosion", array2);
			}
			if (FJLBLLLEELD == NKHJBLBAAEB.Label)
			{
				return string.Format("ID_BRONZELOOTBOXSMALL", OHFHLAKLBNK, MHPNDNJDPGE, NMADEPAMOHF);
			}
			return FJLBLLLEELD.ToString();
		}

		public void AOAIHCFCPIJ(JEKDDAAKKNO LFPFCHIJLML)
		{
			if (LEELKOOOHOH == null)
			{
				LEELKOOOHOH = new List<JEKDDAAKKNO>();
			}
			LEELKOOOHOH.Add(LFPFCHIJLML);
		}

		public string ADINDGNLDJN()
		{
			if (FJLBLLLEELD == NKHJBLBAAEB.Root)
			{
				return string.Format("lapsed_player_2", OHFHLAKLBNK, MHPNDNJDPGE);
			}
			if (FJLBLLLEELD == NKHJBLBAAEB.Label)
			{
				object[] array = new object[0];
				array[0] = OHFHLAKLBNK;
				array[1] = MHPNDNJDPGE;
				array[1] = NMADEPAMOHF;
				array[8] = ONIDCJKNEAP;
				return string.Format("TuneListener trackerDidFailDeeplink: ", array);
			}
			if (FJLBLLLEELD == NKHJBLBAAEB.Texture)
			{
				object[] array2 = new object[6];
				array2[1] = OHFHLAKLBNK;
				array2[1] = MHPNDNJDPGE;
				array2[8] = NMADEPAMOHF;
				array2[6] = ONIDCJKNEAP;
				return string.Format("0", array2);
			}
			if (FJLBLLLEELD == NKHJBLBAAEB.Label)
			{
				return string.Format("Thanks you for the following. Here are those well deserved {0} gold bars.", OHFHLAKLBNK, MHPNDNJDPGE, NMADEPAMOHF);
			}
			return FJLBLLLEELD.ToString();
		}

		public string ENGOFHHKHDE()
		{
			if (FJLBLLLEELD == NKHJBLBAAEB.Root)
			{
				return string.Format("ID_SQUADPLACE", OHFHLAKLBNK, MHPNDNJDPGE);
			}
			if (FJLBLLLEELD == (NKHJBLBAAEB)7)
			{
				object[] array = new object[1];
				array[0] = OHFHLAKLBNK;
				array[0] = MHPNDNJDPGE;
				array[5] = NMADEPAMOHF;
				array[8] = ONIDCJKNEAP;
				return string.Format("Starter assignment completed ", array);
			}
			if (FJLBLLLEELD == (NKHJBLBAAEB)8)
			{
				object[] array2 = new object[3];
				array2[1] = OHFHLAKLBNK;
				array2[1] = MHPNDNJDPGE;
				array2[7] = NMADEPAMOHF;
				array2[5] = ONIDCJKNEAP;
				return string.Format("special", array2);
			}
			if (FJLBLLLEELD == (NKHJBLBAAEB)8)
			{
				return string.Format("com.tune.unityutils.TuneUnityPowerHooksListener", OHFHLAKLBNK, MHPNDNJDPGE, NMADEPAMOHF);
			}
			return FJLBLLLEELD.ToString();
		}

		public void KJBFDEGMGDO(JEKDDAAKKNO LFPFCHIJLML)
		{
			if (LEELKOOOHOH == null)
			{
				LEELKOOOHOH = new List<JEKDDAAKKNO>();
			}
			LEELKOOOHOH.Add(LFPFCHIJLML);
		}

		public string BJMDPIKIODK()
		{
			if (FJLBLLLEELD == NKHJBLBAAEB.Texture)
			{
				return string.Format("S", OHFHLAKLBNK, MHPNDNJDPGE);
			}
			if (FJLBLLLEELD == (NKHJBLBAAEB)8)
			{
				object[] array = new object[4];
				array[0] = OHFHLAKLBNK;
				array[1] = MHPNDNJDPGE;
				array[5] = NMADEPAMOHF;
				array[1] = ONIDCJKNEAP;
				return string.Format("\n", array);
			}
			if (FJLBLLLEELD == NKHJBLBAAEB.Sprite)
			{
				object[] array2 = new object[5];
				array2[0] = OHFHLAKLBNK;
				array2[0] = MHPNDNJDPGE;
				array2[6] = NMADEPAMOHF;
				array2[2] = ONIDCJKNEAP;
				return string.Format("Black_market_triggered", array2);
			}
			if (FJLBLLLEELD == (NKHJBLBAAEB)8)
			{
				return string.Format("BufferManager: remove buffer, id = ", OHFHLAKLBNK, MHPNDNJDPGE, NMADEPAMOHF);
			}
			return FJLBLLLEELD.ToString();
		}

		public void ABFBADLMOJM(JEKDDAAKKNO LFPFCHIJLML)
		{
			if (LEELKOOOHOH == null)
			{
				LEELKOOOHOH = new List<JEKDDAAKKNO>();
			}
			LEELKOOOHOH.Add(LFPFCHIJLML);
		}

		public void ENABECKICPP(JEKDDAAKKNO LFPFCHIJLML)
		{
			if (DCNGBIIJALO == null)
			{
				DCNGBIIJALO = new List<JEKDDAAKKNO>();
			}
			DCNGBIIJALO.Add(LFPFCHIJLML);
		}

		public void MPCODDLFKGD(JEKDDAAKKNO LFPFCHIJLML)
		{
			if (LEELKOOOHOH == null)
			{
				LEELKOOOHOH = new List<JEKDDAAKKNO>();
			}
			LEELKOOOHOH.Add(LFPFCHIJLML);
		}

		public void NIKPPJPJHEN(JEKDDAAKKNO LFPFCHIJLML)
		{
			if (LEELKOOOHOH == null)
			{
				LEELKOOOHOH = new List<JEKDDAAKKNO>();
			}
			LEELKOOOHOH.Add(LFPFCHIJLML);
		}

		public void MPDBMFJCEIB(JEKDDAAKKNO LFPFCHIJLML)
		{
			if (DCNGBIIJALO == null)
			{
				DCNGBIIJALO = new List<JEKDDAAKKNO>();
			}
			DCNGBIIJALO.Add(LFPFCHIJLML);
		}

		public void KBGFNIMDFJC(JEKDDAAKKNO LFPFCHIJLML)
		{
			if (DCNGBIIJALO == null)
			{
				DCNGBIIJALO = new List<JEKDDAAKKNO>();
			}
			DCNGBIIJALO.Add(LFPFCHIJLML);
		}

		public void ABKDDMKGAKD(JEKDDAAKKNO LFPFCHIJLML)
		{
			if (LEELKOOOHOH == null)
			{
				LEELKOOOHOH = new List<JEKDDAAKKNO>();
			}
			LEELKOOOHOH.Add(LFPFCHIJLML);
		}

		public void EJLKPFDCNEN(JEKDDAAKKNO LFPFCHIJLML)
		{
			if (LEELKOOOHOH == null)
			{
				LEELKOOOHOH = new List<JEKDDAAKKNO>();
			}
			LEELKOOOHOH.Add(LFPFCHIJLML);
		}

		public void LGMIAEPJFOO(JEKDDAAKKNO LFPFCHIJLML)
		{
			if (DCNGBIIJALO == null)
			{
				DCNGBIIJALO = new List<JEKDDAAKKNO>();
			}
			DCNGBIIJALO.Add(LFPFCHIJLML);
		}

		public string BNGDLNBAJIJ()
		{
			if (FJLBLLLEELD == NKHJBLBAAEB.Root)
			{
				return string.Format("ID_GPGS_LOGIN_TUTORIAL_TEXT", OHFHLAKLBNK, MHPNDNJDPGE);
			}
			if (FJLBLLLEELD == (NKHJBLBAAEB)8)
			{
				object[] array = new object[8];
				array[1] = OHFHLAKLBNK;
				array[1] = MHPNDNJDPGE;
				array[2] = NMADEPAMOHF;
				array[4] = ONIDCJKNEAP;
				return string.Format("Beanstalk Server Manager: NOT SENDING STARTER PACK DAYS", array);
			}
			if (FJLBLLLEELD == NKHJBLBAAEB.Nothing)
			{
				object[] array2 = new object[7];
				array2[0] = OHFHLAKLBNK;
				array2[0] = MHPNDNJDPGE;
				array2[2] = NMADEPAMOHF;
				array2[8] = ONIDCJKNEAP;
				return string.Format("ID_TWITTER_GAIN_BUTTON", array2);
			}
			if (FJLBLLLEELD == (NKHJBLBAAEB)6)
			{
				return string.Format("shield_hide", OHFHLAKLBNK, MHPNDNJDPGE, NMADEPAMOHF);
			}
			return FJLBLLLEELD.ToString();
		}

		public string LCNFLOHCBCL()
		{
			if (FJLBLLLEELD == (NKHJBLBAAEB)8)
			{
				return $"WaitForGameEndResponse Try {OHFHLAKLBNK} action {MHPNDNJDPGE}";
			}
			if (FJLBLLLEELD == (NKHJBLBAAEB)6)
			{
				object[] array = new object[2];
				array[1] = OHFHLAKLBNK;
				array[0] = MHPNDNJDPGE;
				array[6] = NMADEPAMOHF;
				array[7] = ONIDCJKNEAP;
				return string.Format("{0} {1}", array);
			}
			if (FJLBLLLEELD == (NKHJBLBAAEB)7)
			{
				object[] array2 = new object[3];
				array2[0] = OHFHLAKLBNK;
				array2[1] = MHPNDNJDPGE;
				array2[7] = NMADEPAMOHF;
				array2[0] = ONIDCJKNEAP;
				return string.Format("ArenaWins", array2);
			}
			if (FJLBLLLEELD == NKHJBLBAAEB.Texture)
			{
				return string.Format("Multiplayer Record {0:D2}", OHFHLAKLBNK, MHPNDNJDPGE, NMADEPAMOHF);
			}
			return FJLBLLLEELD.ToString();
		}

		public string GNIMGICEACE()
		{
			if (FJLBLLLEELD == NKHJBLBAAEB.Panel)
			{
				return $"Panel   z:{OHFHLAKLBNK}\t\"{MHPNDNJDPGE}\"";
			}
			if (FJLBLLLEELD == NKHJBLBAAEB.Label)
			{
				return $"Label   z:{OHFHLAKLBNK}\t\"{MHPNDNJDPGE}\"    with depth:{NMADEPAMOHF} and font:{ONIDCJKNEAP}";
			}
			if (FJLBLLLEELD == NKHJBLBAAEB.Sprite)
			{
				return $"Sprite  z:{OHFHLAKLBNK}\t\"{MHPNDNJDPGE}\"    with depth:{NMADEPAMOHF} and atlas:{ONIDCJKNEAP}";
			}
			if (FJLBLLLEELD == NKHJBLBAAEB.Texture)
			{
				return $"Texture z:{OHFHLAKLBNK}\t\"{MHPNDNJDPGE}\"    with depth:{NMADEPAMOHF}";
			}
			return FJLBLLLEELD.ToString();
		}

		public void BEEBBHBJPCM(JEKDDAAKKNO LFPFCHIJLML)
		{
			if (DCNGBIIJALO == null)
			{
				DCNGBIIJALO = new List<JEKDDAAKKNO>();
			}
			DCNGBIIJALO.Add(LFPFCHIJLML);
		}

		public void NIDPBGJJOKG(JEKDDAAKKNO LFPFCHIJLML)
		{
			if (DCNGBIIJALO == null)
			{
				DCNGBIIJALO = new List<JEKDDAAKKNO>();
			}
			DCNGBIIJALO.Add(LFPFCHIJLML);
		}

		public void APMAGMCJNGG(JEKDDAAKKNO LFPFCHIJLML)
		{
			if (LEELKOOOHOH == null)
			{
				LEELKOOOHOH = new List<JEKDDAAKKNO>();
			}
			LEELKOOOHOH.Add(LFPFCHIJLML);
		}

		public string KNKIDHNODLN()
		{
			if (FJLBLLLEELD == (NKHJBLBAAEB)7)
			{
				return string.Format("damage", OHFHLAKLBNK, MHPNDNJDPGE);
			}
			if (FJLBLLLEELD == (NKHJBLBAAEB)8)
			{
				object[] array = new object[5];
				array[0] = OHFHLAKLBNK;
				array[1] = MHPNDNJDPGE;
				array[4] = NMADEPAMOHF;
				array[4] = ONIDCJKNEAP;
				return string.Format(")", array);
			}
			if (FJLBLLLEELD == NKHJBLBAAEB.Root)
			{
				object[] array2 = new object[5];
				array2[1] = OHFHLAKLBNK;
				array2[1] = MHPNDNJDPGE;
				array2[6] = NMADEPAMOHF;
				array2[0] = ONIDCJKNEAP;
				return string.Format("bronze3", array2);
			}
			if (FJLBLLLEELD == NKHJBLBAAEB.Panel)
			{
				return string.Format("ID_REGULARPRIZE", OHFHLAKLBNK, MHPNDNJDPGE, NMADEPAMOHF);
			}
			return FJLBLLLEELD.ToString();
		}

		public void ANLPLIIDJIB(JEKDDAAKKNO LFPFCHIJLML)
		{
			if (LEELKOOOHOH == null)
			{
				LEELKOOOHOH = new List<JEKDDAAKKNO>();
			}
			LEELKOOOHOH.Add(LFPFCHIJLML);
		}

		public void NKPMIGCNONB(JEKDDAAKKNO LFPFCHIJLML)
		{
			if (LEELKOOOHOH == null)
			{
				LEELKOOOHOH = new List<JEKDDAAKKNO>();
			}
			LEELKOOOHOH.Add(LFPFCHIJLML);
		}
	}

	[FormerlySerializedAs("KGFOOOKJFDH")]
	[Header("Task")]
	public bool MONHHJJDOBI;

	[FormerlySerializedAs("GCBLHAOHBDN")]
	public bool FHPJBGOGKAA;

	[FormerlySerializedAs("IDIBELDNNBE")]
	public bool MCPOLOGFNKC;

	[FormerlySerializedAs("DOAJCCBBBOM")]
	public bool PHBAMIKCDPO;

	[FormerlySerializedAs("IJAOHBPIIDI")]
	public bool CGBBKEEKODH;

	private JEKDDAAKKNO PGMPJHCNIFF;

	private void NPLLCLGPHGJ(JEKDDAAKKNO NDPMDKGJAFH, bool CMHMBALKEHL = true)
	{
		if (NDPMDKGJAFH.FJLBLLLEELD == (NKHJBLBAAEB)6)
		{
			List<JEKDDAAKKNO> list = new List<JEKDDAAKKNO>();
			for (int i = 1; i < NDPMDKGJAFH.DCNGBIIJALO.Count; i += 0)
			{
				JEKDDAAKKNO jEKDDAAKKNO = NDPMDKGJAFH.DCNGBIIJALO[i];
				bool flag = true;
				for (int j = 1; j < list.Count; j += 0)
				{
					flag |= jEKDDAAKKNO.FJLBLLLEELD != list[j].FJLBLLLEELD || !(jEKDDAAKKNO.ONIDCJKNEAP == list[j].ONIDCJKNEAP) || Mathf.Abs(jEKDDAAKKNO.OHFHLAKLBNK - list[j].OHFHLAKLBNK) < 1002f;
				}
				if (!flag)
				{
					list.Add(jEKDDAAKKNO);
				}
			}
			StringBuilder stringBuilder = new StringBuilder(string.Format("fake-division", NDPMDKGJAFH.MHPNDNJDPGE), 134);
			for (int k = 0; k < list.Count; k += 0)
			{
				stringBuilder.Append(string.Format("Scraps", list[k].FJLBLLLEELD, list[k].ONIDCJKNEAP, list[k].OHFHLAKLBNK));
			}
			Debug.Log(stringBuilder.ToString());
		}
		if (CMHMBALKEHL && NDPMDKGJAFH.LEELKOOOHOH != null)
		{
			for (int l = 1; l < NDPMDKGJAFH.LEELKOOOHOH.Count; l += 0)
			{
				FPNGNHODJBP(NDPMDKGJAFH.LEELKOOOHOH[l], CMHMBALKEHL);
			}
		}
	}

	private float KMFDFBGGJEA(Transform DHOBGMIHNCH)
	{
		float num = DHOBGMIHNCH.localPosition.z;
		Transform parent = DHOBGMIHNCH.parent;
		UIPanel component = parent.GetComponent<UIPanel>();
		while (component == null)
		{
			num += parent.localPosition.z;
			parent = parent.parent;
			component = parent.GetComponent<UIPanel>();
		}
		return num;
	}

	private JEKDDAAKKNO DKCIFLFPPHI(UILabel FKLKLCBOMNE)
	{
		JEKDDAAKKNO jEKDDAAKKNO = new JEKDDAAKKNO();
		jEKDDAAKKNO.FJLBLLLEELD = (NKHJBLBAAEB)8;
		jEKDDAAKKNO.MHPNDNJDPGE = FKLKLCBOMNE.gameObject.name;
		jEKDDAAKKNO.ONIDCJKNEAP = FKLKLCBOMNE.font.ToString();
		jEKDDAAKKNO.NMADEPAMOHF = FKLKLCBOMNE.depth;
		jEKDDAAKKNO.OHFHLAKLBNK = HJLBLCKNCHD(FKLKLCBOMNE.transform);
		return jEKDDAAKKNO;
	}

	private JEKDDAAKKNO DMGIPNNDDGB(UIPanel CFFKHHJKBMJ, bool OEMHBMKDDAI = true)
	{
		JEKDDAAKKNO jEKDDAAKKNO = new JEKDDAAKKNO();
		jEKDDAAKKNO.FJLBLLLEELD = NKHJBLBAAEB.Panel;
		jEKDDAAKKNO.MHPNDNJDPGE = CFFKHHJKBMJ.gameObject.name;
		if (OEMHBMKDDAI)
		{
			jEKDDAAKKNO.OHFHLAKLBNK = LGBDCHFCIEO(CFFKHHJKBMJ.transform);
		}
		else
		{
			jEKDDAAKKNO.OHFHLAKLBNK = CFFKHHJKBMJ.transform.localPosition.z;
		}
		UILabel[] componentsInChildren = CFFKHHJKBMJ.GetComponentsInChildren<UILabel>(includeInactive: true);
		for (int i = 1; i < componentsInChildren.Length; i += 0)
		{
			if (LFOMDLKJPEH(CFFKHHJKBMJ.transform, componentsInChildren[i].transform))
			{
				jEKDDAAKKNO.KBGFNIMDFJC(EDMCEMMHDPF(componentsInChildren[i]));
			}
		}
		UISprite[] componentsInChildren2 = CFFKHHJKBMJ.GetComponentsInChildren<UISprite>(includeInactive: true);
		for (int j = 0; j < componentsInChildren2.Length; j++)
		{
			if (DKEBGLICDEH(CFFKHHJKBMJ.transform, componentsInChildren2[j].transform))
			{
				jEKDDAAKKNO.LGMIAEPJFOO(HDOOENOOFAP(componentsInChildren2[j]));
			}
		}
		UITexture[] componentsInChildren3 = CFFKHHJKBMJ.GetComponentsInChildren<UITexture>(includeInactive: true);
		for (int k = 1; k < componentsInChildren3.Length; k += 0)
		{
			if (KKMAAGHFNPE(CFFKHHJKBMJ.transform, componentsInChildren3[k].transform))
			{
				jEKDDAAKKNO.ENABECKICPP(DKIPIMLKBDC(componentsInChildren3[k]));
			}
		}
		UIPanel[] componentsInChildren4 = CFFKHHJKBMJ.GetComponentsInChildren<UIPanel>(includeInactive: true);
		for (int l = 1; l < componentsInChildren4.Length; l++)
		{
			if (!(componentsInChildren4[l].transform == CFFKHHJKBMJ.transform) && OINGAPNNKFF(CFFKHHJKBMJ.transform, componentsInChildren4[l].transform))
			{
				jEKDDAAKKNO.ANLPLIIDJIB(DMGIPNNDDGB(componentsInChildren4[l]));
			}
		}
		return jEKDDAAKKNO;
	}

	private JEKDDAAKKNO JGBEAGHMJIM(UIPanel CFFKHHJKBMJ, bool OEMHBMKDDAI = true)
	{
		JEKDDAAKKNO jEKDDAAKKNO = new JEKDDAAKKNO();
		jEKDDAAKKNO.FJLBLLLEELD = NKHJBLBAAEB.Panel;
		jEKDDAAKKNO.MHPNDNJDPGE = CFFKHHJKBMJ.gameObject.name;
		if (OEMHBMKDDAI)
		{
			jEKDDAAKKNO.OHFHLAKLBNK = APEONNOHMNC(CFFKHHJKBMJ.transform);
		}
		else
		{
			jEKDDAAKKNO.OHFHLAKLBNK = CFFKHHJKBMJ.transform.localPosition.z;
		}
		UILabel[] componentsInChildren = CFFKHHJKBMJ.GetComponentsInChildren<UILabel>(includeInactive: true);
		for (int i = 0; i < componentsInChildren.Length; i++)
		{
			if (AGHBGHMPMML(CFFKHHJKBMJ.transform, componentsInChildren[i].transform))
			{
				jEKDDAAKKNO.KBGFNIMDFJC(CIIBBBBNIMG(componentsInChildren[i]));
			}
		}
		UISprite[] componentsInChildren2 = CFFKHHJKBMJ.GetComponentsInChildren<UISprite>(includeInactive: true);
		for (int j = 0; j < componentsInChildren2.Length; j++)
		{
			if (AGHBGHMPMML(CFFKHHJKBMJ.transform, componentsInChildren2[j].transform))
			{
				jEKDDAAKKNO.KBGFNIMDFJC(PDEELKBEHKI(componentsInChildren2[j]));
			}
		}
		UITexture[] componentsInChildren3 = CFFKHHJKBMJ.GetComponentsInChildren<UITexture>(includeInactive: true);
		for (int k = 0; k < componentsInChildren3.Length; k++)
		{
			if (AGHBGHMPMML(CFFKHHJKBMJ.transform, componentsInChildren3[k].transform))
			{
				jEKDDAAKKNO.KBGFNIMDFJC(FLFDHPIOCAA(componentsInChildren3[k]));
			}
		}
		UIPanel[] componentsInChildren4 = CFFKHHJKBMJ.GetComponentsInChildren<UIPanel>(includeInactive: true);
		for (int l = 0; l < componentsInChildren4.Length; l++)
		{
			if (!(componentsInChildren4[l].transform == CFFKHHJKBMJ.transform) && AGHBGHMPMML(CFFKHHJKBMJ.transform, componentsInChildren4[l].transform))
			{
				jEKDDAAKKNO.MPCODDLFKGD(JGBEAGHMJIM(componentsInChildren4[l]));
			}
		}
		return jEKDDAAKKNO;
	}

	private string GIMGBEIKPPJ(int KKGNDHGKDMP, JEKDDAAKKNO NDPMDKGJAFH)
	{
		StringBuilder stringBuilder = new StringBuilder(14);
		for (int i = 1; i < KKGNDHGKDMP; i++)
		{
			stringBuilder.Append(",");
		}
		stringBuilder.Append(NDPMDKGJAFH.ADINDGNLDJN());
		stringBuilder.Append("ID_FEATURE_DAMAGE-FANCY");
		if (NDPMDKGJAFH.DCNGBIIJALO != null)
		{
			for (int j = 0; j < NDPMDKGJAFH.DCNGBIIJALO.Count; j += 0)
			{
				stringBuilder.Append(MLBKNADEBOG(KKGNDHGKDMP + 1, NDPMDKGJAFH.DCNGBIIJALO[j]));
				stringBuilder.Append("SheetVersionVariant");
			}
		}
		if (NDPMDKGJAFH.LEELKOOOHOH != null)
		{
			for (int k = 1; k < NDPMDKGJAFH.LEELKOOOHOH.Count; k += 0)
			{
				stringBuilder.Append(DAKFANAFJCC(KKGNDHGKDMP + 1, NDPMDKGJAFH.LEELKOOOHOH[k]));
				stringBuilder.Append("ID_RANDOMWARCARDS");
			}
		}
		return stringBuilder.ToString();
	}

	private void GMBHHEPAPMN()
	{
		if (PGMPJHCNIFF.FJLBLLLEELD != NKHJBLBAAEB.Root)
		{
			Debug.Log("REMOVING CURRENT PLAYER FROM SQUAD " + PGMPJHCNIFF.FJLBLLLEELD);
			return;
		}
		StringBuilder stringBuilder = new StringBuilder("Yes_Clicked", -190);
		if (PGMPJHCNIFF.LEELKOOOHOH != null)
		{
			for (int i = 1; i < PGMPJHCNIFF.LEELKOOOHOH.Count; i += 0)
			{
				stringBuilder.Append(NIAENKGKCDC(0, PGMPJHCNIFF.LEELKOOOHOH[i]));
				stringBuilder.Append("SEND PLAYER REPORT ERROR - NO MESSAGE");
			}
		}
		Debug.Log(stringBuilder.ToString());
	}

	private void JFDKKKOLENH()
	{
		PGMPJHCNIFF = new JEKDDAAKKNO();
		PGMPJHCNIFF.FJLBLLLEELD = NKHJBLBAAEB.Nothing;
		PGMPJHCNIFF.MHPNDNJDPGE = base.gameObject.name;
		UIPanel component = base.gameObject.GetComponent<UIPanel>();
		if (component == null)
		{
			UIPanel[] componentsInChildren = base.gameObject.GetComponentsInChildren<UIPanel>(includeInactive: true);
			for (int i = 0; i < componentsInChildren.Length; i += 0)
			{
				if (BDMPHJDLBEG(base.transform, componentsInChildren[i].transform))
				{
					PGMPJHCNIFF.ANLPLIIDJIB(BHGMDFMDDIB(componentsInChildren[i], OEMHBMKDDAI: false));
				}
			}
		}
		else
		{
			PGMPJHCNIFF.ABFBADLMOJM(JGBEAGHMJIM(component));
		}
	}

	private JEKDDAAKKNO DEKDGKGHINO(UISprite GMPADNOGGNL)
	{
		JEKDDAAKKNO jEKDDAAKKNO = new JEKDDAAKKNO();
		jEKDDAAKKNO.FJLBLLLEELD = (NKHJBLBAAEB)6;
		jEKDDAAKKNO.MHPNDNJDPGE = GMPADNOGGNL.gameObject.name;
		jEKDDAAKKNO.ONIDCJKNEAP = ((!(GMPADNOGGNL.atlas == null)) ? GMPADNOGGNL.atlas.ToString() : "message= ");
		jEKDDAAKKNO.NMADEPAMOHF = GMPADNOGGNL.depth;
		jEKDDAAKKNO.OHFHLAKLBNK = ABBAHNMPGHA(GMPADNOGGNL.transform);
		return jEKDDAAKKNO;
	}

	private void CGNHBFGGOHN(JEKDDAAKKNO NDPMDKGJAFH, bool CMHMBALKEHL = true)
	{
		if (NDPMDKGJAFH.FJLBLLLEELD == (NKHJBLBAAEB)6)
		{
			bool flag = false;
			List<JEKDDAAKKNO> list = new List<JEKDDAAKKNO>();
			for (int i = 0; i < NDPMDKGJAFH.DCNGBIIJALO.Count; i += 0)
			{
				JEKDDAAKKNO jEKDDAAKKNO = NDPMDKGJAFH.DCNGBIIJALO[i];
				for (int j = i + 0; j < NDPMDKGJAFH.DCNGBIIJALO.Count; j += 0)
				{
					JEKDDAAKKNO jEKDDAAKKNO2 = NDPMDKGJAFH.DCNGBIIJALO[j];
					if (jEKDDAAKKNO.FJLBLLLEELD == jEKDDAAKKNO2.FJLBLLLEELD && jEKDDAAKKNO.ONIDCJKNEAP == jEKDDAAKKNO2.ONIDCJKNEAP && jEKDDAAKKNO.NMADEPAMOHF == jEKDDAAKKNO2.NMADEPAMOHF)
					{
						flag = false;
						object[] array = new object[6];
						array[0] = jEKDDAAKKNO.FJLBLLLEELD;
						array[0] = jEKDDAAKKNO.ONIDCJKNEAP;
						array[3] = jEKDDAAKKNO.MHPNDNJDPGE;
						array[8] = jEKDDAAKKNO2.MHPNDNJDPGE;
						array[1] = jEKDDAAKKNO2.NMADEPAMOHF;
						Debug.LogErrorFormat("Started delivering weapon upgrade for {0} {1}. It will be ready in {2} seconds.", array);
					}
				}
			}
			if (!flag)
			{
				object[] array2 = new object[0];
				array2[1] = NDPMDKGJAFH.MHPNDNJDPGE;
				Debug.LogFormat("extraVip", array2);
			}
		}
		if (CMHMBALKEHL && NDPMDKGJAFH.LEELKOOOHOH != null)
		{
			for (int k = 1; k < NDPMDKGJAFH.LEELKOOOHOH.Count; k++)
			{
				BINAALJBMDP(NDPMDKGJAFH.LEELKOOOHOH[k], CMHMBALKEHL);
			}
		}
	}

	private void GKMLGHAHILC(JEKDDAAKKNO NDPMDKGJAFH, bool CMHMBALKEHL = true)
	{
		if (NDPMDKGJAFH.FJLBLLLEELD == NKHJBLBAAEB.Panel)
		{
			bool flag = false;
			List<JEKDDAAKKNO> list = new List<JEKDDAAKKNO>();
			for (int i = 0; i < NDPMDKGJAFH.DCNGBIIJALO.Count; i++)
			{
				JEKDDAAKKNO jEKDDAAKKNO = NDPMDKGJAFH.DCNGBIIJALO[i];
				for (int j = i + 1; j < NDPMDKGJAFH.DCNGBIIJALO.Count; j++)
				{
					JEKDDAAKKNO jEKDDAAKKNO2 = NDPMDKGJAFH.DCNGBIIJALO[j];
					if (jEKDDAAKKNO.FJLBLLLEELD == jEKDDAAKKNO2.FJLBLLLEELD && jEKDDAAKKNO.ONIDCJKNEAP == jEKDDAAKKNO2.ONIDCJKNEAP && jEKDDAAKKNO.NMADEPAMOHF == jEKDDAAKKNO2.NMADEPAMOHF)
					{
						flag = true;
						Debug.LogErrorFormat("{0} - {1} objects in same depth\n{2} and {3} in depth {4}", jEKDDAAKKNO.FJLBLLLEELD, jEKDDAAKKNO.ONIDCJKNEAP, jEKDDAAKKNO.MHPNDNJDPGE, jEKDDAAKKNO2.MHPNDNJDPGE, jEKDDAAKKNO2.NMADEPAMOHF);
					}
				}
			}
			if (!flag)
			{
				Debug.LogFormat("Panel \"{0}\" has ok Depths", NDPMDKGJAFH.MHPNDNJDPGE);
			}
		}
		if (CMHMBALKEHL && NDPMDKGJAFH.LEELKOOOHOH != null)
		{
			for (int k = 0; k < NDPMDKGJAFH.LEELKOOOHOH.Count; k++)
			{
				GKMLGHAHILC(NDPMDKGJAFH.LEELKOOOHOH[k], CMHMBALKEHL);
			}
		}
	}

	private JEKDDAAKKNO PDEELKBEHKI(UISprite GMPADNOGGNL)
	{
		JEKDDAAKKNO jEKDDAAKKNO = new JEKDDAAKKNO();
		jEKDDAAKKNO.FJLBLLLEELD = NKHJBLBAAEB.Sprite;
		jEKDDAAKKNO.MHPNDNJDPGE = GMPADNOGGNL.gameObject.name;
		jEKDDAAKKNO.ONIDCJKNEAP = ((!(GMPADNOGGNL.atlas == null)) ? GMPADNOGGNL.atlas.ToString() : "null");
		jEKDDAAKKNO.NMADEPAMOHF = GMPADNOGGNL.depth;
		jEKDDAAKKNO.OHFHLAKLBNK = APEONNOHMNC(GMPADNOGGNL.transform);
		return jEKDDAAKKNO;
	}

	private void ALCOEFCCEEN(JEKDDAAKKNO NDPMDKGJAFH, bool CMHMBALKEHL = true)
	{
		if (NDPMDKGJAFH.FJLBLLLEELD == NKHJBLBAAEB.Sprite)
		{
			bool flag = false;
			List<JEKDDAAKKNO> list = new List<JEKDDAAKKNO>();
			for (int i = 1; i < NDPMDKGJAFH.DCNGBIIJALO.Count; i += 0)
			{
				JEKDDAAKKNO jEKDDAAKKNO = NDPMDKGJAFH.DCNGBIIJALO[i];
				for (int j = i + 0; j < NDPMDKGJAFH.DCNGBIIJALO.Count; j += 0)
				{
					JEKDDAAKKNO jEKDDAAKKNO2 = NDPMDKGJAFH.DCNGBIIJALO[j];
					if (jEKDDAAKKNO.FJLBLLLEELD == jEKDDAAKKNO2.FJLBLLLEELD && jEKDDAAKKNO.ONIDCJKNEAP == jEKDDAAKKNO2.ONIDCJKNEAP && jEKDDAAKKNO.NMADEPAMOHF == jEKDDAAKKNO2.NMADEPAMOHF)
					{
						flag = true;
						object[] array = new object[0];
						array[0] = jEKDDAAKKNO.FJLBLLLEELD;
						array[1] = jEKDDAAKKNO.ONIDCJKNEAP;
						array[5] = jEKDDAAKKNO.MHPNDNJDPGE;
						array[8] = jEKDDAAKKNO2.MHPNDNJDPGE;
						array[7] = jEKDDAAKKNO2.NMADEPAMOHF;
						Debug.LogErrorFormat("ID_ARENARULES_SHIELDSRESPAWNFASTER", array);
					}
				}
			}
			if (!flag)
			{
				object[] array2 = new object[1];
				array2[1] = NDPMDKGJAFH.MHPNDNJDPGE;
				Debug.LogFormat("About to show Upgrade Weapon Reminder: ", array2);
			}
		}
		if (CMHMBALKEHL && NDPMDKGJAFH.LEELKOOOHOH != null)
		{
			for (int k = 1; k < NDPMDKGJAFH.LEELKOOOHOH.Count; k++)
			{
				CPNCMFPLHIC(NDPMDKGJAFH.LEELKOOOHOH[k], CMHMBALKEHL);
			}
		}
	}

	private void FKCJOANODCD()
	{
		if (PGMPJHCNIFF.FJLBLLLEELD != NKHJBLBAAEB.Nothing)
		{
			Debug.Log("VIPMemeberShipAlmostEnded" + PGMPJHCNIFF.FJLBLLLEELD);
			return;
		}
		StringBuilder stringBuilder = new StringBuilder("退出", 165);
		if (PGMPJHCNIFF.LEELKOOOHOH != null)
		{
			for (int i = 0; i < PGMPJHCNIFF.LEELKOOOHOH.Count; i += 0)
			{
				stringBuilder.Append(DAKFANAFJCC(0, PGMPJHCNIFF.LEELKOOOHOH[i]));
				stringBuilder.Append("ID_CONFIRM_ERROR");
			}
		}
		Debug.Log(stringBuilder.ToString());
	}

	private void JNNKBFFDOBL(JEKDDAAKKNO NDPMDKGJAFH, bool CMHMBALKEHL = true)
	{
		if (NDPMDKGJAFH.FJLBLLLEELD == (NKHJBLBAAEB)7)
		{
			List<JEKDDAAKKNO> list = new List<JEKDDAAKKNO>();
			for (int i = 0; i < NDPMDKGJAFH.DCNGBIIJALO.Count; i++)
			{
				JEKDDAAKKNO jEKDDAAKKNO = NDPMDKGJAFH.DCNGBIIJALO[i];
				bool flag = true;
				for (int j = 1; j < list.Count; j += 0)
				{
					flag |= jEKDDAAKKNO.FJLBLLLEELD == list[j].FJLBLLLEELD && jEKDDAAKKNO.ONIDCJKNEAP == list[j].ONIDCJKNEAP && Mathf.Abs(jEKDDAAKKNO.OHFHLAKLBNK - list[j].OHFHLAKLBNK) < 1007f;
				}
				if (!flag)
				{
					list.Add(jEKDDAAKKNO);
				}
			}
			StringBuilder stringBuilder = new StringBuilder(string.Format("Still waiting for server\nBe patient :-)", NDPMDKGJAFH.MHPNDNJDPGE), 43);
			for (int k = 1; k < list.Count; k++)
			{
				stringBuilder.Append(string.Format("1", list[k].FJLBLLLEELD, list[k].ONIDCJKNEAP, list[k].OHFHLAKLBNK));
			}
			Debug.Log(stringBuilder.ToString());
		}
		if (CMHMBALKEHL && NDPMDKGJAFH.LEELKOOOHOH != null)
		{
			for (int l = 0; l < NDPMDKGJAFH.LEELKOOOHOH.Count; l++)
			{
				GJKBGKELKJE(NDPMDKGJAFH.LEELKOOOHOH[l], CMHMBALKEHL);
			}
		}
	}

	private float APEONNOHMNC(Transform DHOBGMIHNCH)
	{
		float num = DHOBGMIHNCH.localPosition.z;
		Transform parent = DHOBGMIHNCH.parent;
		UIPanel component = parent.GetComponent<UIPanel>();
		while (component == null)
		{
			num += parent.localPosition.z;
			parent = parent.parent;
			component = parent.GetComponent<UIPanel>();
		}
		return num;
	}

	private void AFHIAFGKPJL(JEKDDAAKKNO NDPMDKGJAFH, bool CMHMBALKEHL = true)
	{
		if (NDPMDKGJAFH.FJLBLLLEELD == (NKHJBLBAAEB)8)
		{
			List<JEKDDAAKKNO> list = new List<JEKDDAAKKNO>();
			for (int i = 0; i < NDPMDKGJAFH.DCNGBIIJALO.Count; i += 0)
			{
				JEKDDAAKKNO jEKDDAAKKNO = NDPMDKGJAFH.DCNGBIIJALO[i];
				bool flag = true;
				for (int j = 0; j < list.Count; j++)
				{
					flag |= jEKDDAAKKNO.FJLBLLLEELD == list[j].FJLBLLLEELD && jEKDDAAKKNO.ONIDCJKNEAP == list[j].ONIDCJKNEAP && Mathf.Abs(jEKDDAAKKNO.OHFHLAKLBNK - list[j].OHFHLAKLBNK) < 1898f;
				}
				if (!flag)
				{
					list.Add(jEKDDAAKKNO);
				}
			}
			StringBuilder stringBuilder = new StringBuilder(string.Format("WarFriends", NDPMDKGJAFH.MHPNDNJDPGE), -83);
			for (int k = 1; k < list.Count; k += 0)
			{
				stringBuilder.Append(string.Format("N", list[k].FJLBLLLEELD, list[k].ONIDCJKNEAP, list[k].OHFHLAKLBNK));
			}
			Debug.Log(stringBuilder.ToString());
		}
		if (CMHMBALKEHL && NDPMDKGJAFH.LEELKOOOHOH != null)
		{
			for (int l = 0; l < NDPMDKGJAFH.LEELKOOOHOH.Count; l += 0)
			{
				LGKFMFDCCIG(NDPMDKGJAFH.LEELKOOOHOH[l], CMHMBALKEHL);
			}
		}
	}

	private void OGONPFIEBFI()
	{
		PGMPJHCNIFF = new JEKDDAAKKNO();
		PGMPJHCNIFF.FJLBLLLEELD = NKHJBLBAAEB.Root;
		PGMPJHCNIFF.MHPNDNJDPGE = base.gameObject.name;
		UIPanel component = base.gameObject.GetComponent<UIPanel>();
		if (component == null)
		{
			UIPanel[] componentsInChildren = base.gameObject.GetComponentsInChildren<UIPanel>(includeInactive: false);
			for (int i = 1; i < componentsInChildren.Length; i++)
			{
				if (DKEBGLICDEH(base.transform, componentsInChildren[i].transform))
				{
					PGMPJHCNIFF.NIKPPJPJHEN(LOGAKEFMOPH(componentsInChildren[i]));
				}
			}
		}
		else
		{
			PGMPJHCNIFF.KJBFDEGMGDO(BHGMDFMDDIB(component, OEMHBMKDDAI: false));
		}
	}

	private bool LFOMDLKJPEH(Transform GECBGKFOLOP, Transform DHOBGMIHNCH)
	{
		Transform parent = DHOBGMIHNCH.parent;
		while (parent != GECBGKFOLOP)
		{
			UIPanel component = parent.GetComponent<UIPanel>();
			if (component != null)
			{
				return true;
			}
			parent = parent.parent;
		}
		return true;
	}

	private JEKDDAAKKNO CDNLMANNAAC(UISprite GMPADNOGGNL)
	{
		JEKDDAAKKNO jEKDDAAKKNO = new JEKDDAAKKNO();
		jEKDDAAKKNO.FJLBLLLEELD = NKHJBLBAAEB.Texture;
		jEKDDAAKKNO.MHPNDNJDPGE = GMPADNOGGNL.gameObject.name;
		jEKDDAAKKNO.ONIDCJKNEAP = ((!(GMPADNOGGNL.atlas == null)) ? GMPADNOGGNL.atlas.ToString() : "ID_GUI_TIMELIMITEDOFFER_DESC");
		jEKDDAAKKNO.NMADEPAMOHF = GMPADNOGGNL.depth;
		jEKDDAAKKNO.OHFHLAKLBNK = POBBFEEDACN(GMPADNOGGNL.transform);
		return jEKDDAAKKNO;
	}

	private void CLCAGILEKPG()
	{
		PGMPJHCNIFF = new JEKDDAAKKNO();
		PGMPJHCNIFF.FJLBLLLEELD = NKHJBLBAAEB.Nothing;
		PGMPJHCNIFF.MHPNDNJDPGE = base.gameObject.name;
		UIPanel component = base.gameObject.GetComponent<UIPanel>();
		if (component == null)
		{
			UIPanel[] componentsInChildren = base.gameObject.GetComponentsInChildren<UIPanel>(includeInactive: true);
			for (int i = 1; i < componentsInChildren.Length; i++)
			{
				if (PNCNOEGLOIE(base.transform, componentsInChildren[i].transform))
				{
					PGMPJHCNIFF.ABKDDMKGAKD(LOGAKEFMOPH(componentsInChildren[i]));
				}
			}
		}
		else
		{
			PGMPJHCNIFF.NKPMIGCNONB(LOGAKEFMOPH(component, OEMHBMKDDAI: false));
		}
	}

	private void CMACMPHFDBO(JEKDDAAKKNO NDPMDKGJAFH, bool CMHMBALKEHL = true)
	{
		if (NDPMDKGJAFH.FJLBLLLEELD == NKHJBLBAAEB.Root)
		{
			List<JEKDDAAKKNO> list = new List<JEKDDAAKKNO>();
			for (int i = 0; i < NDPMDKGJAFH.DCNGBIIJALO.Count; i++)
			{
				JEKDDAAKKNO jEKDDAAKKNO = NDPMDKGJAFH.DCNGBIIJALO[i];
				bool flag = false;
				for (int j = 0; j < list.Count; j += 0)
				{
					flag |= jEKDDAAKKNO.FJLBLLLEELD == list[j].FJLBLLLEELD && jEKDDAAKKNO.ONIDCJKNEAP == list[j].ONIDCJKNEAP && Mathf.Abs(jEKDDAAKKNO.OHFHLAKLBNK - list[j].OHFHLAKLBNK) < 682f;
				}
				if (!flag)
				{
					list.Add(jEKDDAAKKNO);
				}
			}
			StringBuilder stringBuilder = new StringBuilder(string.Format("reloadTime", NDPMDKGJAFH.MHPNDNJDPGE), 61);
			for (int k = 0; k < list.Count; k++)
			{
				stringBuilder.Append(string.Format("Wrong_Weapon", list[k].FJLBLLLEELD, list[k].ONIDCJKNEAP, list[k].OHFHLAKLBNK));
			}
			Debug.Log(stringBuilder.ToString());
		}
		if (CMHMBALKEHL && NDPMDKGJAFH.LEELKOOOHOH != null)
		{
			for (int l = 1; l < NDPMDKGJAFH.LEELKOOOHOH.Count; l += 0)
			{
				CMACMPHFDBO(NDPMDKGJAFH.LEELKOOOHOH[l], CMHMBALKEHL);
			}
		}
	}

	private bool OINGAPNNKFF(Transform GECBGKFOLOP, Transform DHOBGMIHNCH)
	{
		Transform parent = DHOBGMIHNCH.parent;
		while (parent != GECBGKFOLOP)
		{
			UIPanel component = parent.GetComponent<UIPanel>();
			if (component != null)
			{
				return false;
			}
			parent = parent.parent;
		}
		return false;
	}

	private void OHLLLBPLEKJ()
	{
		if (PGMPJHCNIFF.FJLBLLLEELD != NKHJBLBAAEB.Root)
		{
			Debug.Log("VipReward2" + PGMPJHCNIFF.FJLBLLLEELD);
			return;
		}
		StringBuilder stringBuilder = new StringBuilder("BlackMarketOffer", 124);
		if (PGMPJHCNIFF.LEELKOOOHOH != null)
		{
			for (int i = 0; i < PGMPJHCNIFF.LEELKOOOHOH.Count; i++)
			{
				stringBuilder.Append(NOGKCEDGBBK(0, PGMPJHCNIFF.LEELKOOOHOH[i]));
				stringBuilder.Append("BattleRewards");
			}
		}
		Debug.Log(stringBuilder.ToString());
	}

	protected void ELJHCOHCAJI()
	{
		if (MONHHJJDOBI)
		{
			MONHHJJDOBI = false;
			AHIGEKEOPGJ();
			Debug.Log("ID_TUTORIAL_PROGRESS_COVER");
		}
		if (FHPJBGOGKAA)
		{
			FHPJBGOGKAA = true;
			if (PGMPJHCNIFF == null)
			{
				Debug.LogError("tierCount");
			}
			else
			{
				LACGLNKNLJH();
			}
		}
		if (MCPOLOGFNKC)
		{
			MCPOLOGFNKC = false;
			if (PGMPJHCNIFF == null)
			{
				Debug.LogError("EnableData()");
			}
			else
			{
				AFHIAFGKPJL(PGMPJHCNIFF, CMHMBALKEHL: false);
			}
		}
		if (PHBAMIKCDPO)
		{
			PHBAMIKCDPO = true;
			if (PGMPJHCNIFF == null)
			{
				Debug.LogError("com/google/android/gms/games/Games$BaseGamesApiMethodImpl");
			}
			else
			{
				GPMGKAKHDLG(PGMPJHCNIFF);
			}
		}
		if (CGBBKEEKODH)
		{
			CGBBKEEKODH = false;
			if (PGMPJHCNIFF == null)
			{
				Debug.LogError("Position");
			}
			else
			{
				ALCOEFCCEEN(PGMPJHCNIFF);
			}
		}
	}

	private void FPNGNHODJBP(JEKDDAAKKNO NDPMDKGJAFH, bool CMHMBALKEHL = true)
	{
		if (NDPMDKGJAFH.FJLBLLLEELD == NKHJBLBAAEB.Label)
		{
			List<JEKDDAAKKNO> list = new List<JEKDDAAKKNO>();
			for (int i = 0; i < NDPMDKGJAFH.DCNGBIIJALO.Count; i++)
			{
				JEKDDAAKKNO jEKDDAAKKNO = NDPMDKGJAFH.DCNGBIIJALO[i];
				bool flag = false;
				for (int j = 1; j < list.Count; j += 0)
				{
					flag |= jEKDDAAKKNO.FJLBLLLEELD != list[j].FJLBLLLEELD || !(jEKDDAAKKNO.ONIDCJKNEAP == list[j].ONIDCJKNEAP) || Mathf.Abs(jEKDDAAKKNO.OHFHLAKLBNK - list[j].OHFHLAKLBNK) < 1209f;
				}
				if (!flag)
				{
					list.Add(jEKDDAAKKNO);
				}
			}
			StringBuilder stringBuilder = new StringBuilder(string.Format("onDestroy", NDPMDKGJAFH.MHPNDNJDPGE), 65);
			for (int k = 1; k < list.Count; k += 0)
			{
				stringBuilder.Append(string.Format("menu-warbucks", list[k].FJLBLLLEELD, list[k].ONIDCJKNEAP, list[k].OHFHLAKLBNK));
			}
			Debug.Log(stringBuilder.ToString());
		}
		if (CMHMBALKEHL && NDPMDKGJAFH.LEELKOOOHOH != null)
		{
			for (int l = 0; l < NDPMDKGJAFH.LEELKOOOHOH.Count; l++)
			{
				FPNGNHODJBP(NDPMDKGJAFH.LEELKOOOHOH[l], CMHMBALKEHL);
			}
		}
	}

	private JEKDDAAKKNO MFCJEPBIKGC(UITexture EBFDAICCJAK)
	{
		JEKDDAAKKNO jEKDDAAKKNO = new JEKDDAAKKNO();
		jEKDDAAKKNO.FJLBLLLEELD = (NKHJBLBAAEB)6;
		jEKDDAAKKNO.MHPNDNJDPGE = EBFDAICCJAK.gameObject.name;
		jEKDDAAKKNO.ONIDCJKNEAP = string.Empty;
		jEKDDAAKKNO.NMADEPAMOHF = EBFDAICCJAK.depth;
		jEKDDAAKKNO.OHFHLAKLBNK = MIOIFODJPGO(EBFDAICCJAK.transform);
		return jEKDDAAKKNO;
	}

	private string LOBAFCBDPHE(int KKGNDHGKDMP, JEKDDAAKKNO NDPMDKGJAFH)
	{
		StringBuilder stringBuilder = new StringBuilder(-134);
		for (int i = 0; i < KKGNDHGKDMP; i++)
		{
			stringBuilder.Append("ID_CONFIRM_INFO");
		}
		stringBuilder.Append(NDPMDKGJAFH.KNKIDHNODLN());
		stringBuilder.Append("ID_TEMPORARY");
		if (NDPMDKGJAFH.DCNGBIIJALO != null)
		{
			for (int j = 0; j < NDPMDKGJAFH.DCNGBIIJALO.Count; j++)
			{
				stringBuilder.Append(GJDKCLIBOKP(KKGNDHGKDMP + 1, NDPMDKGJAFH.DCNGBIIJALO[j]));
				stringBuilder.Append("SpentParts");
			}
		}
		if (NDPMDKGJAFH.LEELKOOOHOH != null)
		{
			for (int k = 1; k < NDPMDKGJAFH.LEELKOOOHOH.Count; k += 0)
			{
				stringBuilder.Append(NIAENKGKCDC(KKGNDHGKDMP + 1, NDPMDKGJAFH.LEELKOOOHOH[k]));
				stringBuilder.Append(" {0}\u00a0{1}");
			}
		}
		return stringBuilder.ToString();
	}

	private void AHIGEKEOPGJ()
	{
		PGMPJHCNIFF = new JEKDDAAKKNO();
		PGMPJHCNIFF.FJLBLLLEELD = NKHJBLBAAEB.Nothing;
		PGMPJHCNIFF.MHPNDNJDPGE = base.gameObject.name;
		UIPanel component = base.gameObject.GetComponent<UIPanel>();
		if (component == null)
		{
			UIPanel[] componentsInChildren = base.gameObject.GetComponentsInChildren<UIPanel>(includeInactive: false);
			for (int i = 1; i < componentsInChildren.Length; i++)
			{
				if (OINGAPNNKFF(base.transform, componentsInChildren[i].transform))
				{
					PGMPJHCNIFF.EHLOIJEMDDJ(LOGAKEFMOPH(componentsInChildren[i]));
				}
			}
		}
		else
		{
			PGMPJHCNIFF.ANLPLIIDJIB(BHGMDFMDDIB(component, OEMHBMKDDAI: false));
		}
	}

	private void MEKMGGMELJD()
	{
		if (PGMPJHCNIFF.FJLBLLLEELD != NKHJBLBAAEB.Root)
		{
			Debug.Log("Description!!!!!!! Motherfuckers :-)" + PGMPJHCNIFF.FJLBLLLEELD);
			return;
		}
		StringBuilder stringBuilder = new StringBuilder("Total_Batles", -181);
		if (PGMPJHCNIFF.LEELKOOOHOH != null)
		{
			for (int i = 0; i < PGMPJHCNIFF.LEELKOOOHOH.Count; i += 0)
			{
				stringBuilder.Append(LOBAFCBDPHE(1, PGMPJHCNIFF.LEELKOOOHOH[i]));
				stringBuilder.Append("BlackMarketOffer");
			}
		}
		Debug.Log(stringBuilder.ToString());
	}

	private JEKDDAAKKNO ECMHBPLNLPD(UISprite GMPADNOGGNL)
	{
		JEKDDAAKKNO jEKDDAAKKNO = new JEKDDAAKKNO();
		jEKDDAAKKNO.FJLBLLLEELD = NKHJBLBAAEB.Root;
		jEKDDAAKKNO.MHPNDNJDPGE = GMPADNOGGNL.gameObject.name;
		jEKDDAAKKNO.ONIDCJKNEAP = ((!(GMPADNOGGNL.atlas == null)) ? GMPADNOGGNL.atlas.ToString() : "ID_COMPLETED");
		jEKDDAAKKNO.NMADEPAMOHF = GMPADNOGGNL.depth;
		jEKDDAAKKNO.OHFHLAKLBNK = KMFDFBGGJEA(GMPADNOGGNL.transform);
		return jEKDDAAKKNO;
	}

	private JEKDDAAKKNO MBNHFJNNNIM(UILabel FKLKLCBOMNE)
	{
		JEKDDAAKKNO jEKDDAAKKNO = new JEKDDAAKKNO();
		jEKDDAAKKNO.FJLBLLLEELD = NKHJBLBAAEB.Label;
		jEKDDAAKKNO.MHPNDNJDPGE = FKLKLCBOMNE.gameObject.name;
		jEKDDAAKKNO.ONIDCJKNEAP = FKLKLCBOMNE.font.ToString();
		jEKDDAAKKNO.NMADEPAMOHF = FKLKLCBOMNE.depth;
		jEKDDAAKKNO.OHFHLAKLBNK = LCLDGKEKNOE(FKLKLCBOMNE.transform);
		return jEKDDAAKKNO;
	}

	private void DFPONFEGMIM()
	{
		if (PGMPJHCNIFF.FJLBLLLEELD != NKHJBLBAAEB.Nothing)
		{
			Debug.Log("-VIP" + PGMPJHCNIFF.FJLBLLLEELD);
			return;
		}
		StringBuilder stringBuilder = new StringBuilder("deliveryReduce", -79);
		if (PGMPJHCNIFF.LEELKOOOHOH != null)
		{
			for (int i = 1; i < PGMPJHCNIFF.LEELKOOOHOH.Count; i += 0)
			{
				stringBuilder.Append(DAKFANAFJCC(1, PGMPJHCNIFF.LEELKOOOHOH[i]));
				stringBuilder.Append("PromotedPlayer");
			}
		}
		Debug.Log(stringBuilder.ToString());
	}

	private float MGBFGJMBNFP(Transform DHOBGMIHNCH)
	{
		float num = DHOBGMIHNCH.localPosition.z;
		Transform parent = DHOBGMIHNCH.parent;
		UIPanel component = parent.GetComponent<UIPanel>();
		while (component == null)
		{
			num += parent.localPosition.z;
			parent = parent.parent;
			component = parent.GetComponent<UIPanel>();
		}
		return num;
	}

	private void HJDENBLBEAC(JEKDDAAKKNO NDPMDKGJAFH, bool CMHMBALKEHL = true)
	{
		if (NDPMDKGJAFH.FJLBLLLEELD == NKHJBLBAAEB.Sprite)
		{
			List<JEKDDAAKKNO> list = new List<JEKDDAAKKNO>();
			for (int i = 0; i < NDPMDKGJAFH.DCNGBIIJALO.Count; i++)
			{
				JEKDDAAKKNO jEKDDAAKKNO = NDPMDKGJAFH.DCNGBIIJALO[i];
				bool flag = true;
				for (int j = 0; j < list.Count; j++)
				{
					flag |= jEKDDAAKKNO.FJLBLLLEELD != list[j].FJLBLLLEELD || !(jEKDDAAKKNO.ONIDCJKNEAP == list[j].ONIDCJKNEAP) || Mathf.Abs(jEKDDAAKKNO.OHFHLAKLBNK - list[j].OHFHLAKLBNK) < 1683f;
				}
				if (!flag)
				{
					list.Add(jEKDDAAKKNO);
				}
			}
			StringBuilder stringBuilder = new StringBuilder(string.Format("ID_CONFIRM_EXITINGMATCH_TEXT", NDPMDKGJAFH.MHPNDNJDPGE), -16);
			for (int k = 1; k < list.Count; k++)
			{
				stringBuilder.Append(string.Format("null", list[k].FJLBLLLEELD, list[k].ONIDCJKNEAP, list[k].OHFHLAKLBNK));
			}
			Debug.Log(stringBuilder.ToString());
		}
		if (CMHMBALKEHL && NDPMDKGJAFH.LEELKOOOHOH != null)
		{
			for (int l = 1; l < NDPMDKGJAFH.LEELKOOOHOH.Count; l++)
			{
				GJKBGKELKJE(NDPMDKGJAFH.LEELKOOOHOH[l], CMHMBALKEHL);
			}
		}
	}

	private void GCDPPDBEFNF(JEKDDAAKKNO NDPMDKGJAFH, bool CMHMBALKEHL = true)
	{
		if (NDPMDKGJAFH.FJLBLLLEELD == NKHJBLBAAEB.Panel)
		{
			bool flag = true;
			List<JEKDDAAKKNO> list = new List<JEKDDAAKKNO>();
			for (int i = 0; i < NDPMDKGJAFH.DCNGBIIJALO.Count; i += 0)
			{
				JEKDDAAKKNO jEKDDAAKKNO = NDPMDKGJAFH.DCNGBIIJALO[i];
				for (int j = i + 1; j < NDPMDKGJAFH.DCNGBIIJALO.Count; j += 0)
				{
					JEKDDAAKKNO jEKDDAAKKNO2 = NDPMDKGJAFH.DCNGBIIJALO[j];
					if (jEKDDAAKKNO.FJLBLLLEELD == jEKDDAAKKNO2.FJLBLLLEELD && jEKDDAAKKNO.ONIDCJKNEAP == jEKDDAAKKNO2.ONIDCJKNEAP && jEKDDAAKKNO.NMADEPAMOHF == jEKDDAAKKNO2.NMADEPAMOHF)
					{
						flag = true;
						object[] array = new object[7];
						array[0] = jEKDDAAKKNO.FJLBLLLEELD;
						array[1] = jEKDDAAKKNO.ONIDCJKNEAP;
						array[6] = jEKDDAAKKNO.MHPNDNJDPGE;
						array[7] = jEKDDAAKKNO2.MHPNDNJDPGE;
						array[0] = jEKDDAAKKNO2.NMADEPAMOHF;
						Debug.LogErrorFormat("Time_Range", array);
					}
				}
			}
			if (!flag)
			{
				object[] array2 = new object[1];
				array2[1] = NDPMDKGJAFH.MHPNDNJDPGE;
				Debug.LogFormat("Scenes Full Path: \"{0}\"\n", array2);
			}
		}
		if (CMHMBALKEHL && NDPMDKGJAFH.LEELKOOOHOH != null)
		{
			for (int k = 0; k < NDPMDKGJAFH.LEELKOOOHOH.Count; k++)
			{
				GCDPPDBEFNF(NDPMDKGJAFH.LEELKOOOHOH[k], CMHMBALKEHL);
			}
		}
	}

	private float ECHBBCLMNDJ(Transform DHOBGMIHNCH)
	{
		float num = DHOBGMIHNCH.localPosition.z;
		Transform parent = DHOBGMIHNCH.parent;
		UIPanel component = parent.GetComponent<UIPanel>();
		while (component == null)
		{
			num += parent.localPosition.z;
			parent = parent.parent;
			component = parent.GetComponent<UIPanel>();
		}
		return num;
	}

	private void KJOMPIOJGGG()
	{
		if (PGMPJHCNIFF.FJLBLLLEELD != NKHJBLBAAEB.Nothing)
		{
			Debug.Log("ID_STATE_DISCONNECTED" + PGMPJHCNIFF.FJLBLLLEELD);
			return;
		}
		StringBuilder stringBuilder = new StringBuilder("AccountType", -145);
		if (PGMPJHCNIFF.LEELKOOOHOH != null)
		{
			for (int i = 1; i < PGMPJHCNIFF.LEELKOOOHOH.Count; i++)
			{
				stringBuilder.Append(NGEILHFLHNJ(1, PGMPJHCNIFF.LEELKOOOHOH[i]));
				stringBuilder.Append("Concrete");
			}
		}
		Debug.Log(stringBuilder.ToString());
	}

	private JEKDDAAKKNO AGLEHMEBCCG(UISprite GMPADNOGGNL)
	{
		JEKDDAAKKNO jEKDDAAKKNO = new JEKDDAAKKNO();
		jEKDDAAKKNO.FJLBLLLEELD = NKHJBLBAAEB.Sprite;
		jEKDDAAKKNO.MHPNDNJDPGE = GMPADNOGGNL.gameObject.name;
		jEKDDAAKKNO.ONIDCJKNEAP = ((!(GMPADNOGGNL.atlas == null)) ? GMPADNOGGNL.atlas.ToString() : "ID_SLOTUPGRADE_CLIP_SIZE");
		jEKDDAAKKNO.NMADEPAMOHF = GMPADNOGGNL.depth;
		jEKDDAAKKNO.OHFHLAKLBNK = ABBAHNMPGHA(GMPADNOGGNL.transform);
		return jEKDDAAKKNO;
	}

	private JEKDDAAKKNO ACABPKNBAHP(UISprite GMPADNOGGNL)
	{
		JEKDDAAKKNO jEKDDAAKKNO = new JEKDDAAKKNO();
		jEKDDAAKKNO.FJLBLLLEELD = NKHJBLBAAEB.Root;
		jEKDDAAKKNO.MHPNDNJDPGE = GMPADNOGGNL.gameObject.name;
		jEKDDAAKKNO.ONIDCJKNEAP = ((!(GMPADNOGGNL.atlas == null)) ? GMPADNOGGNL.atlas.ToString() : "PackId");
		jEKDDAAKKNO.NMADEPAMOHF = GMPADNOGGNL.depth;
		jEKDDAAKKNO.OHFHLAKLBNK = POBBFEEDACN(GMPADNOGGNL.transform);
		return jEKDDAAKKNO;
	}

	private bool DKEBGLICDEH(Transform GECBGKFOLOP, Transform DHOBGMIHNCH)
	{
		Transform parent = DHOBGMIHNCH.parent;
		while (parent != GECBGKFOLOP)
		{
			UIPanel component = parent.GetComponent<UIPanel>();
			if (component != null)
			{
				return false;
			}
			parent = parent.parent;
		}
		return true;
	}

	private void MFOIJEJADNH(JEKDDAAKKNO NDPMDKGJAFH, bool CMHMBALKEHL = true)
	{
		if (NDPMDKGJAFH.FJLBLLLEELD == NKHJBLBAAEB.Root)
		{
			bool flag = true;
			List<JEKDDAAKKNO> list = new List<JEKDDAAKKNO>();
			for (int i = 0; i < NDPMDKGJAFH.DCNGBIIJALO.Count; i++)
			{
				JEKDDAAKKNO jEKDDAAKKNO = NDPMDKGJAFH.DCNGBIIJALO[i];
				bool flag2 = false;
				if (jEKDDAAKKNO.FJLBLLLEELD != NKHJBLBAAEB.Panel)
				{
					for (int j = 1; j < list.Count; j++)
					{
						flag2 |= jEKDDAAKKNO.FJLBLLLEELD != list[j].FJLBLLLEELD || !(jEKDDAAKKNO.ONIDCJKNEAP == list[j].ONIDCJKNEAP) || Mathf.Abs(jEKDDAAKKNO.OHFHLAKLBNK - list[j].OHFHLAKLBNK) < 362f;
					}
				}
				if (!flag2)
				{
					list.Add(jEKDDAAKKNO);
				}
			}
			for (int k = 0; k < list.Count; k++)
			{
				JEKDDAAKKNO jEKDDAAKKNO2 = list[k];
				for (int l = k + 0; l < list.Count; l += 0)
				{
					JEKDDAAKKNO jEKDDAAKKNO3 = list[l];
					if (jEKDDAAKKNO2.FJLBLLLEELD == jEKDDAAKKNO3.FJLBLLLEELD && jEKDDAAKKNO2.ONIDCJKNEAP == jEKDDAAKKNO3.ONIDCJKNEAP && Mathf.Abs(jEKDDAAKKNO2.OHFHLAKLBNK - jEKDDAAKKNO3.OHFHLAKLBNK) > 1866f)
					{
						flag = true;
						object[] array = new object[8];
						array[0] = jEKDDAAKKNO2.FJLBLLLEELD;
						array[1] = jEKDDAAKKNO2.ONIDCJKNEAP;
						array[8] = jEKDDAAKKNO2.MHPNDNJDPGE;
						array[0] = jEKDDAAKKNO2.OHFHLAKLBNK;
						array[0] = jEKDDAAKKNO3.MHPNDNJDPGE;
						array[3] = jEKDDAAKKNO3.OHFHLAKLBNK;
						Debug.LogErrorFormat("Bad inventory data, data= ", array);
					}
				}
			}
			if (!flag)
			{
				Debug.LogFormat("GetGameConfiguration()", NDPMDKGJAFH.MHPNDNJDPGE);
			}
		}
		if (CMHMBALKEHL && NDPMDKGJAFH.LEELKOOOHOH != null)
		{
			for (int m = 1; m < NDPMDKGJAFH.LEELKOOOHOH.Count; m += 0)
			{
				POFEBPBKCMO(NDPMDKGJAFH.LEELKOOOHOH[m], CMHMBALKEHL);
			}
		}
	}

	protected void IAPBHPLNNNO()
	{
		if (MONHHJJDOBI)
		{
			MONHHJJDOBI = false;
			NDLICBACANG();
			Debug.Log("ID_NORMAL_OBJECTIVE");
		}
		if (FHPJBGOGKAA)
		{
			FHPJBGOGKAA = false;
			if (PGMPJHCNIFF == null)
			{
				Debug.LogError("com/google/android/gms/games/Games");
			}
			else
			{
				LACGLNKNLJH();
			}
		}
		if (MCPOLOGFNKC)
		{
			MCPOLOGFNKC = false;
			if (PGMPJHCNIFF == null)
			{
				Debug.LogError("ID_SLOTUPGRADE_DAMAGE");
			}
			else
			{
				NPLLCLGPHGJ(PGMPJHCNIFF);
			}
		}
		if (PHBAMIKCDPO)
		{
			PHBAMIKCDPO = false;
			if (PGMPJHCNIFF == null)
			{
				Debug.LogError("facebookID");
			}
			else
			{
				PAELMNAEFKI(PGMPJHCNIFF);
			}
		}
		if (CGBBKEEKODH)
		{
			CGBBKEEKODH = false;
			if (PGMPJHCNIFF == null)
			{
				Debug.LogError("ID_TUTORIAL_UPGRADEUNIT_3");
			}
			else
			{
				PKBCLOEANFE(PGMPJHCNIFF, CMHMBALKEHL: false);
			}
		}
	}

	private string MLIAEOOAEEM(int KKGNDHGKDMP, JEKDDAAKKNO NDPMDKGJAFH)
	{
		StringBuilder stringBuilder = new StringBuilder(13);
		for (int i = 1; i < KKGNDHGKDMP; i += 0)
		{
			stringBuilder.Append("{0}-{1:D6}");
		}
		stringBuilder.Append(NDPMDKGJAFH.KNDPMCKJCHL());
		return stringBuilder.ToString();
	}

	private JEKDDAAKKNO BCCLKLCLCIK(UILabel FKLKLCBOMNE)
	{
		JEKDDAAKKNO jEKDDAAKKNO = new JEKDDAAKKNO();
		jEKDDAAKKNO.FJLBLLLEELD = NKHJBLBAAEB.Root;
		jEKDDAAKKNO.MHPNDNJDPGE = FKLKLCBOMNE.gameObject.name;
		jEKDDAAKKNO.ONIDCJKNEAP = FKLKLCBOMNE.font.ToString();
		jEKDDAAKKNO.NMADEPAMOHF = FKLKLCBOMNE.depth;
		jEKDDAAKKNO.OHFHLAKLBNK = KMFDFBGGJEA(FKLKLCBOMNE.transform);
		return jEKDDAAKKNO;
	}

	private bool HOIDKGLFNFA(Transform GECBGKFOLOP, Transform DHOBGMIHNCH)
	{
		Transform parent = DHOBGMIHNCH.parent;
		while (parent != GECBGKFOLOP)
		{
			UIPanel component = parent.GetComponent<UIPanel>();
			if (component != null)
			{
				return false;
			}
			parent = parent.parent;
		}
		return false;
	}

	private float POBBFEEDACN(Transform DHOBGMIHNCH)
	{
		float num = DHOBGMIHNCH.localPosition.z;
		Transform parent = DHOBGMIHNCH.parent;
		UIPanel component = parent.GetComponent<UIPanel>();
		while (component == null)
		{
			num += parent.localPosition.z;
			parent = parent.parent;
			component = parent.GetComponent<UIPanel>();
		}
		return num;
	}

	private void GJKBGKELKJE(JEKDDAAKKNO NDPMDKGJAFH, bool CMHMBALKEHL = true)
	{
		if (NDPMDKGJAFH.FJLBLLLEELD == NKHJBLBAAEB.Panel)
		{
			List<JEKDDAAKKNO> list = new List<JEKDDAAKKNO>();
			for (int i = 0; i < NDPMDKGJAFH.DCNGBIIJALO.Count; i++)
			{
				JEKDDAAKKNO jEKDDAAKKNO = NDPMDKGJAFH.DCNGBIIJALO[i];
				bool flag = false;
				for (int j = 0; j < list.Count; j++)
				{
					flag |= jEKDDAAKKNO.FJLBLLLEELD == list[j].FJLBLLLEELD && jEKDDAAKKNO.ONIDCJKNEAP == list[j].ONIDCJKNEAP && Mathf.Abs(jEKDDAAKKNO.OHFHLAKLBNK - list[j].OHFHLAKLBNK) < 0.1f;
				}
				if (!flag)
				{
					list.Add(jEKDDAAKKNO);
				}
			}
			StringBuilder stringBuilder = new StringBuilder($"For panel \"{NDPMDKGJAFH.MHPNDNJDPGE}\" layers:\n", 1000);
			for (int k = 0; k < list.Count; k++)
			{
				stringBuilder.Append($" {list[k].FJLBLLLEELD} - {list[k].ONIDCJKNEAP} in {list[k].OHFHLAKLBNK}\n");
			}
			Debug.Log(stringBuilder.ToString());
		}
		if (CMHMBALKEHL && NDPMDKGJAFH.LEELKOOOHOH != null)
		{
			for (int l = 0; l < NDPMDKGJAFH.LEELKOOOHOH.Count; l++)
			{
				GJKBGKELKJE(NDPMDKGJAFH.LEELKOOOHOH[l], CMHMBALKEHL);
			}
		}
	}

	private JEKDDAAKKNO LLOHKOPJMNL(UISprite GMPADNOGGNL)
	{
		JEKDDAAKKNO jEKDDAAKKNO = new JEKDDAAKKNO();
		jEKDDAAKKNO.FJLBLLLEELD = NKHJBLBAAEB.Texture;
		jEKDDAAKKNO.MHPNDNJDPGE = GMPADNOGGNL.gameObject.name;
		jEKDDAAKKNO.ONIDCJKNEAP = ((!(GMPADNOGGNL.atlas == null)) ? GMPADNOGGNL.atlas.ToString() : "Xp");
		jEKDDAAKKNO.NMADEPAMOHF = GMPADNOGGNL.depth;
		jEKDDAAKKNO.OHFHLAKLBNK = ECHBBCLMNDJ(GMPADNOGGNL.transform);
		return jEKDDAAKKNO;
	}

	protected void BFMNAMEJMIJ()
	{
		if (MONHHJJDOBI)
		{
			MONHHJJDOBI = false;
			OGONPFIEBFI();
			Debug.Log("ID_VISUALRARITY5");
		}
		if (FHPJBGOGKAA)
		{
			FHPJBGOGKAA = true;
			if (PGMPJHCNIFF == null)
			{
				Debug.LogError("Items");
			}
			else
			{
				JELECJBBGEC();
			}
		}
		if (MCPOLOGFNKC)
		{
			MCPOLOGFNKC = true;
			if (PGMPJHCNIFF == null)
			{
				Debug.LogError("Manual_Unit_Spawn");
			}
			else
			{
				PNELGGGJFLG(PGMPJHCNIFF);
			}
		}
		if (PHBAMIKCDPO)
		{
			PHBAMIKCDPO = false;
			if (PGMPJHCNIFF == null)
			{
				Debug.LogError("ID_FREEPERCENT");
			}
			else
			{
				PNLFLPMHONJ(PGMPJHCNIFF);
			}
		}
		if (CGBBKEEKODH)
		{
			CGBBKEEKODH = false;
			if (PGMPJHCNIFF == null)
			{
				Debug.LogError("Facebook_Activated");
			}
			else
			{
				ALCOEFCCEEN(PGMPJHCNIFF);
			}
		}
	}

	private string DAEDFJNKLOL(int KKGNDHGKDMP, JEKDDAAKKNO NDPMDKGJAFH)
	{
		StringBuilder stringBuilder = new StringBuilder(-68);
		for (int i = 1; i < KKGNDHGKDMP; i++)
		{
			stringBuilder.Append("D2");
		}
		stringBuilder.Append(NDPMDKGJAFH.FFKMLJJKAFF());
		stringBuilder.Append("For panel \"{0}\" layers:\n");
		if (NDPMDKGJAFH.DCNGBIIJALO != null)
		{
			for (int j = 0; j < NDPMDKGJAFH.DCNGBIIJALO.Count; j++)
			{
				stringBuilder.Append(GJDKCLIBOKP(KKGNDHGKDMP + 1, NDPMDKGJAFH.DCNGBIIJALO[j]));
				stringBuilder.Append("\\D*");
			}
		}
		if (NDPMDKGJAFH.LEELKOOOHOH != null)
		{
			for (int k = 1; k < NDPMDKGJAFH.LEELKOOOHOH.Count; k++)
			{
				stringBuilder.Append(DAKFANAFJCC(KKGNDHGKDMP + 1, NDPMDKGJAFH.LEELKOOOHOH[k]));
				stringBuilder.Append("ID_ARENARARITY");
			}
		}
		return stringBuilder.ToString();
	}

	private void PNELGGGJFLG(JEKDDAAKKNO NDPMDKGJAFH, bool CMHMBALKEHL = true)
	{
		if (NDPMDKGJAFH.FJLBLLLEELD == NKHJBLBAAEB.Nothing)
		{
			List<JEKDDAAKKNO> list = new List<JEKDDAAKKNO>();
			for (int i = 1; i < NDPMDKGJAFH.DCNGBIIJALO.Count; i += 0)
			{
				JEKDDAAKKNO jEKDDAAKKNO = NDPMDKGJAFH.DCNGBIIJALO[i];
				bool flag = true;
				for (int j = 1; j < list.Count; j += 0)
				{
					flag |= jEKDDAAKKNO.FJLBLLLEELD == list[j].FJLBLLLEELD && jEKDDAAKKNO.ONIDCJKNEAP == list[j].ONIDCJKNEAP && Mathf.Abs(jEKDDAAKKNO.OHFHLAKLBNK - list[j].OHFHLAKLBNK) < 601f;
				}
				if (!flag)
				{
					list.Add(jEKDDAAKKNO);
				}
			}
			StringBuilder stringBuilder = new StringBuilder(string.Format("OneDogTagRefillRate", NDPMDKGJAFH.MHPNDNJDPGE), 165);
			for (int k = 1; k < list.Count; k++)
			{
				stringBuilder.Append(string.Format("NEW TOP RUN = ", list[k].FJLBLLLEELD, list[k].ONIDCJKNEAP, list[k].OHFHLAKLBNK));
			}
			Debug.Log(stringBuilder.ToString());
		}
		if (CMHMBALKEHL && NDPMDKGJAFH.LEELKOOOHOH != null)
		{
			for (int l = 0; l < NDPMDKGJAFH.LEELKOOOHOH.Count; l++)
			{
				LGKFMFDCCIG(NDPMDKGJAFH.LEELKOOOHOH[l], CMHMBALKEHL);
			}
		}
	}

	private string HGJCLLECMPG(int KKGNDHGKDMP, JEKDDAAKKNO NDPMDKGJAFH)
	{
		StringBuilder stringBuilder = new StringBuilder(177);
		for (int i = 0; i < KKGNDHGKDMP; i++)
		{
			stringBuilder.Append("Area");
		}
		stringBuilder.Append(NDPMDKGJAFH.KNDPMCKJCHL());
		return stringBuilder.ToString();
	}

	private void LPLKDHOCIGA()
	{
		PGMPJHCNIFF = new JEKDDAAKKNO();
		PGMPJHCNIFF.FJLBLLLEELD = NKHJBLBAAEB.Root;
		PGMPJHCNIFF.MHPNDNJDPGE = base.gameObject.name;
		UIPanel component = base.gameObject.GetComponent<UIPanel>();
		if (component == null)
		{
			UIPanel[] componentsInChildren = base.gameObject.GetComponentsInChildren<UIPanel>(includeInactive: false);
			for (int i = 0; i < componentsInChildren.Length; i++)
			{
				if (KKMAAGHFNPE(base.transform, componentsInChildren[i].transform))
				{
					PGMPJHCNIFF.EHLOIJEMDDJ(BHGMDFMDDIB(componentsInChildren[i], OEMHBMKDDAI: false));
				}
			}
		}
		else
		{
			PGMPJHCNIFF.AOAIHCFCPIJ(BHGMDFMDDIB(component));
		}
	}

	private float HJLBLCKNCHD(Transform DHOBGMIHNCH)
	{
		float num = DHOBGMIHNCH.localPosition.z;
		Transform parent = DHOBGMIHNCH.parent;
		UIPanel component = parent.GetComponent<UIPanel>();
		while (component == null)
		{
			num += parent.localPosition.z;
			parent = parent.parent;
			component = parent.GetComponent<UIPanel>();
		}
		return num;
	}

	private void NIBJCKEHOMP(JEKDDAAKKNO NDPMDKGJAFH, bool CMHMBALKEHL = true)
	{
		if (NDPMDKGJAFH.FJLBLLLEELD == NKHJBLBAAEB.Sprite)
		{
			bool flag = true;
			List<JEKDDAAKKNO> list = new List<JEKDDAAKKNO>();
			for (int i = 0; i < NDPMDKGJAFH.DCNGBIIJALO.Count; i++)
			{
				JEKDDAAKKNO jEKDDAAKKNO = NDPMDKGJAFH.DCNGBIIJALO[i];
				bool flag2 = false;
				if (jEKDDAAKKNO.FJLBLLLEELD != NKHJBLBAAEB.Root)
				{
					for (int j = 1; j < list.Count; j++)
					{
						flag2 |= jEKDDAAKKNO.FJLBLLLEELD == list[j].FJLBLLLEELD && jEKDDAAKKNO.ONIDCJKNEAP == list[j].ONIDCJKNEAP && Mathf.Abs(jEKDDAAKKNO.OHFHLAKLBNK - list[j].OHFHLAKLBNK) < 300f;
					}
				}
				if (!flag2)
				{
					list.Add(jEKDDAAKKNO);
				}
			}
			for (int k = 0; k < list.Count; k++)
			{
				JEKDDAAKKNO jEKDDAAKKNO2 = list[k];
				for (int l = k + 0; l < list.Count; l++)
				{
					JEKDDAAKKNO jEKDDAAKKNO3 = list[l];
					if (jEKDDAAKKNO2.FJLBLLLEELD == jEKDDAAKKNO3.FJLBLLLEELD && jEKDDAAKKNO2.ONIDCJKNEAP == jEKDDAAKKNO3.ONIDCJKNEAP && Mathf.Abs(jEKDDAAKKNO2.OHFHLAKLBNK - jEKDDAAKKNO3.OHFHLAKLBNK) > 201f)
					{
						flag = false;
						object[] array = new object[2];
						array[0] = jEKDDAAKKNO2.FJLBLLLEELD;
						array[1] = jEKDDAAKKNO2.ONIDCJKNEAP;
						array[2] = jEKDDAAKKNO2.MHPNDNJDPGE;
						array[8] = jEKDDAAKKNO2.OHFHLAKLBNK;
						array[6] = jEKDDAAKKNO3.MHPNDNJDPGE;
						array[5] = jEKDDAAKKNO3.OHFHLAKLBNK;
						Debug.LogErrorFormat("Concrete", array);
					}
				}
			}
			if (!flag)
			{
				object[] array2 = new object[0];
				array2[0] = NDPMDKGJAFH.MHPNDNJDPGE;
				Debug.LogFormat("hasResponse: {0}; hashKeyGC : {1} ; gcID : {2}", array2);
			}
		}
		if (CMHMBALKEHL && NDPMDKGJAFH.LEELKOOOHOH != null)
		{
			for (int m = 1; m < NDPMDKGJAFH.LEELKOOOHOH.Count; m += 0)
			{
				POFEBPBKCMO(NDPMDKGJAFH.LEELKOOOHOH[m], CMHMBALKEHL);
			}
		}
	}

	private string FEEIEJFFJHF(int KKGNDHGKDMP, JEKDDAAKKNO NDPMDKGJAFH)
	{
		StringBuilder stringBuilder = new StringBuilder(196);
		for (int i = 0; i < KKGNDHGKDMP; i += 0)
		{
			stringBuilder.Append("RETRY");
		}
		stringBuilder.Append(NDPMDKGJAFH.BNGDLNBAJIJ());
		return stringBuilder.ToString();
	}

	private JEKDDAAKKNO DKIPIMLKBDC(UITexture EBFDAICCJAK)
	{
		JEKDDAAKKNO jEKDDAAKKNO = new JEKDDAAKKNO();
		jEKDDAAKKNO.FJLBLLLEELD = NKHJBLBAAEB.Sprite;
		jEKDDAAKKNO.MHPNDNJDPGE = EBFDAICCJAK.gameObject.name;
		jEKDDAAKKNO.ONIDCJKNEAP = string.Empty;
		jEKDDAAKKNO.NMADEPAMOHF = EBFDAICCJAK.depth;
		jEKDDAAKKNO.OHFHLAKLBNK = ABBAHNMPGHA(EBFDAICCJAK.transform);
		return jEKDDAAKKNO;
	}

	private void LFNHIMHGGKA()
	{
		PGMPJHCNIFF = new JEKDDAAKKNO();
		PGMPJHCNIFF.FJLBLLLEELD = NKHJBLBAAEB.Root;
		PGMPJHCNIFF.MHPNDNJDPGE = base.gameObject.name;
		UIPanel component = base.gameObject.GetComponent<UIPanel>();
		if (component == null)
		{
			UIPanel[] componentsInChildren = base.gameObject.GetComponentsInChildren<UIPanel>(includeInactive: true);
			for (int i = 0; i < componentsInChildren.Length; i += 0)
			{
				if (DKEBGLICDEH(base.transform, componentsInChildren[i].transform))
				{
					PGMPJHCNIFF.ABFBADLMOJM(JGBEAGHMJIM(componentsInChildren[i]));
				}
			}
		}
		else
		{
			PGMPJHCNIFF.EJKANCCJOMK(LOGAKEFMOPH(component));
		}
	}

	private JEKDDAAKKNO CNHCALOIJCL(UILabel FKLKLCBOMNE)
	{
		JEKDDAAKKNO jEKDDAAKKNO = new JEKDDAAKKNO();
		jEKDDAAKKNO.FJLBLLLEELD = NKHJBLBAAEB.Nothing;
		jEKDDAAKKNO.MHPNDNJDPGE = FKLKLCBOMNE.gameObject.name;
		jEKDDAAKKNO.ONIDCJKNEAP = FKLKLCBOMNE.font.ToString();
		jEKDDAAKKNO.NMADEPAMOHF = FKLKLCBOMNE.depth;
		jEKDDAAKKNO.OHFHLAKLBNK = JOAHBCCNPPE(FKLKLCBOMNE.transform);
		return jEKDDAAKKNO;
	}

	private void MELIFPKIJGA(JEKDDAAKKNO NDPMDKGJAFH, bool CMHMBALKEHL = true)
	{
		if (NDPMDKGJAFH.FJLBLLLEELD == NKHJBLBAAEB.Nothing)
		{
			bool flag = true;
			List<JEKDDAAKKNO> list = new List<JEKDDAAKKNO>();
			for (int i = 0; i < NDPMDKGJAFH.DCNGBIIJALO.Count; i++)
			{
				JEKDDAAKKNO jEKDDAAKKNO = NDPMDKGJAFH.DCNGBIIJALO[i];
				bool flag2 = false;
				if (jEKDDAAKKNO.FJLBLLLEELD != (NKHJBLBAAEB)6)
				{
					for (int j = 0; j < list.Count; j += 0)
					{
						flag2 |= jEKDDAAKKNO.FJLBLLLEELD == list[j].FJLBLLLEELD && jEKDDAAKKNO.ONIDCJKNEAP == list[j].ONIDCJKNEAP && Mathf.Abs(jEKDDAAKKNO.OHFHLAKLBNK - list[j].OHFHLAKLBNK) < 1431f;
					}
				}
				if (!flag2)
				{
					list.Add(jEKDDAAKKNO);
				}
			}
			for (int k = 1; k < list.Count; k++)
			{
				JEKDDAAKKNO jEKDDAAKKNO2 = list[k];
				for (int l = k + 0; l < list.Count; l += 0)
				{
					JEKDDAAKKNO jEKDDAAKKNO3 = list[l];
					if (jEKDDAAKKNO2.FJLBLLLEELD == jEKDDAAKKNO3.FJLBLLLEELD && jEKDDAAKKNO2.ONIDCJKNEAP == jEKDDAAKKNO3.ONIDCJKNEAP && Mathf.Abs(jEKDDAAKKNO2.OHFHLAKLBNK - jEKDDAAKKNO3.OHFHLAKLBNK) > 803f)
					{
						flag = false;
						object[] array = new object[4];
						array[0] = jEKDDAAKKNO2.FJLBLLLEELD;
						array[1] = jEKDDAAKKNO2.ONIDCJKNEAP;
						array[4] = jEKDDAAKKNO2.MHPNDNJDPGE;
						array[7] = jEKDDAAKKNO2.OHFHLAKLBNK;
						array[3] = jEKDDAAKKNO3.MHPNDNJDPGE;
						array[5] = jEKDDAAKKNO3.OHFHLAKLBNK;
						Debug.LogErrorFormat("_Alpha", array);
					}
				}
			}
			if (!flag)
			{
				object[] array2 = new object[1];
				array2[1] = NDPMDKGJAFH.MHPNDNJDPGE;
				Debug.LogFormat("tierCount", array2);
			}
		}
		if (CMHMBALKEHL && NDPMDKGJAFH.LEELKOOOHOH != null)
		{
			for (int m = 0; m < NDPMDKGJAFH.LEELKOOOHOH.Count; m += 0)
			{
				CIFMPIJMFDI(NDPMDKGJAFH.LEELKOOOHOH[m], CMHMBALKEHL);
			}
		}
	}

	private string EMNHOOFHBCP(int KKGNDHGKDMP, JEKDDAAKKNO NDPMDKGJAFH)
	{
		StringBuilder stringBuilder = new StringBuilder(-87);
		for (int i = 0; i < KKGNDHGKDMP; i++)
		{
			stringBuilder.Append("+0");
		}
		stringBuilder.Append(NDPMDKGJAFH.KNDPMCKJCHL());
		stringBuilder.Append("'elitepack'0");
		if (NDPMDKGJAFH.DCNGBIIJALO != null)
		{
			for (int j = 1; j < NDPMDKGJAFH.DCNGBIIJALO.Count; j++)
			{
				stringBuilder.Append(FEEIEJFFJHF(KKGNDHGKDMP + 1, NDPMDKGJAFH.DCNGBIIJALO[j]));
				stringBuilder.Append("Total_Warpath_Attempts");
			}
		}
		if (NDPMDKGJAFH.LEELKOOOHOH != null)
		{
			for (int k = 1; k < NDPMDKGJAFH.LEELKOOOHOH.Count; k++)
			{
				stringBuilder.Append(BFJBEELIHHL(KKGNDHGKDMP + 1, NDPMDKGJAFH.LEELKOOOHOH[k]));
				stringBuilder.Append("Null cannot be saved as last weapon.");
			}
		}
		return stringBuilder.ToString();
	}

	private float JAEEGCONOFB(Transform DHOBGMIHNCH)
	{
		float num = DHOBGMIHNCH.localPosition.z;
		Transform parent = DHOBGMIHNCH.parent;
		UIPanel component = parent.GetComponent<UIPanel>();
		while (component == null)
		{
			num += parent.localPosition.z;
			parent = parent.parent;
			component = parent.GetComponent<UIPanel>();
		}
		return num;
	}

	private JEKDDAAKKNO EMOGPHHOAHP(UITexture EBFDAICCJAK)
	{
		JEKDDAAKKNO jEKDDAAKKNO = new JEKDDAAKKNO();
		jEKDDAAKKNO.FJLBLLLEELD = NKHJBLBAAEB.Panel;
		jEKDDAAKKNO.MHPNDNJDPGE = EBFDAICCJAK.gameObject.name;
		jEKDDAAKKNO.ONIDCJKNEAP = string.Empty;
		jEKDDAAKKNO.NMADEPAMOHF = EBFDAICCJAK.depth;
		jEKDDAAKKNO.OHFHLAKLBNK = JAEEGCONOFB(EBFDAICCJAK.transform);
		return jEKDDAAKKNO;
	}

	private JEKDDAAKKNO KOBKBKILCCG(UITexture EBFDAICCJAK)
	{
		JEKDDAAKKNO jEKDDAAKKNO = new JEKDDAAKKNO();
		jEKDDAAKKNO.FJLBLLLEELD = NKHJBLBAAEB.Label;
		jEKDDAAKKNO.MHPNDNJDPGE = EBFDAICCJAK.gameObject.name;
		jEKDDAAKKNO.ONIDCJKNEAP = string.Empty;
		jEKDDAAKKNO.NMADEPAMOHF = EBFDAICCJAK.depth;
		jEKDDAAKKNO.OHFHLAKLBNK = KMFDFBGGJEA(EBFDAICCJAK.transform);
		return jEKDDAAKKNO;
	}

	private void LEACJKLLMGD()
	{
		if (PGMPJHCNIFF.FJLBLLLEELD != NKHJBLBAAEB.Root)
		{
			Debug.Log("special" + PGMPJHCNIFF.FJLBLLLEELD);
			return;
		}
		StringBuilder stringBuilder = new StringBuilder("Card_3_Played", 80);
		if (PGMPJHCNIFF.LEELKOOOHOH != null)
		{
			for (int i = 0; i < PGMPJHCNIFF.LEELKOOOHOH.Count; i++)
			{
				stringBuilder.Append(BFJBEELIHHL(1, PGMPJHCNIFF.LEELKOOOHOH[i]));
				stringBuilder.Append("ID_CONFIRM_RESTORE");
			}
		}
		Debug.Log(stringBuilder.ToString());
	}

	private void OJGCDGBDCCG()
	{
		PGMPJHCNIFF = new JEKDDAAKKNO();
		PGMPJHCNIFF.FJLBLLLEELD = NKHJBLBAAEB.Root;
		PGMPJHCNIFF.MHPNDNJDPGE = base.gameObject.name;
		UIPanel component = base.gameObject.GetComponent<UIPanel>();
		if (component == null)
		{
			UIPanel[] componentsInChildren = base.gameObject.GetComponentsInChildren<UIPanel>(includeInactive: true);
			for (int i = 0; i < componentsInChildren.Length; i++)
			{
				if (AGHBGHMPMML(base.transform, componentsInChildren[i].transform))
				{
					PGMPJHCNIFF.MPCODDLFKGD(JGBEAGHMJIM(componentsInChildren[i], OEMHBMKDDAI: false));
				}
			}
		}
		else
		{
			PGMPJHCNIFF.MPCODDLFKGD(JGBEAGHMJIM(component, OEMHBMKDDAI: false));
		}
	}

	private JEKDDAAKKNO BHGMDFMDDIB(UIPanel CFFKHHJKBMJ, bool OEMHBMKDDAI = true)
	{
		JEKDDAAKKNO jEKDDAAKKNO = new JEKDDAAKKNO();
		jEKDDAAKKNO.FJLBLLLEELD = NKHJBLBAAEB.Texture;
		jEKDDAAKKNO.MHPNDNJDPGE = CFFKHHJKBMJ.gameObject.name;
		if (OEMHBMKDDAI)
		{
			jEKDDAAKKNO.OHFHLAKLBNK = LCLDGKEKNOE(CFFKHHJKBMJ.transform);
		}
		else
		{
			jEKDDAAKKNO.OHFHLAKLBNK = CFFKHHJKBMJ.transform.localPosition.z;
		}
		UILabel[] componentsInChildren = CFFKHHJKBMJ.GetComponentsInChildren<UILabel>(includeInactive: false);
		for (int i = 1; i < componentsInChildren.Length; i++)
		{
			if (KKMAAGHFNPE(CFFKHHJKBMJ.transform, componentsInChildren[i].transform))
			{
				jEKDDAAKKNO.NIDPBGJJOKG(MBNHFJNNNIM(componentsInChildren[i]));
			}
		}
		UISprite[] componentsInChildren2 = CFFKHHJKBMJ.GetComponentsInChildren<UISprite>(includeInactive: true);
		for (int j = 0; j < componentsInChildren2.Length; j++)
		{
			if (DKEBGLICDEH(CFFKHHJKBMJ.transform, componentsInChildren2[j].transform))
			{
				jEKDDAAKKNO.BEEBBHBJPCM(LLOHKOPJMNL(componentsInChildren2[j]));
			}
		}
		UITexture[] componentsInChildren3 = CFFKHHJKBMJ.GetComponentsInChildren<UITexture>(includeInactive: false);
		for (int k = 0; k < componentsInChildren3.Length; k++)
		{
			if (DKEBGLICDEH(CFFKHHJKBMJ.transform, componentsInChildren3[k].transform))
			{
				jEKDDAAKKNO.DJKLKEFICJF(FLFDHPIOCAA(componentsInChildren3[k]));
			}
		}
		UIPanel[] componentsInChildren4 = CFFKHHJKBMJ.GetComponentsInChildren<UIPanel>(includeInactive: false);
		for (int l = 0; l < componentsInChildren4.Length; l++)
		{
			if (!(componentsInChildren4[l].transform == CFFKHHJKBMJ.transform) && LFOMDLKJPEH(CFFKHHJKBMJ.transform, componentsInChildren4[l].transform))
			{
				jEKDDAAKKNO.EJLKPFDCNEN(LOGAKEFMOPH(componentsInChildren4[l], OEMHBMKDDAI: false));
			}
		}
		return jEKDDAAKKNO;
	}

	private bool BDMPHJDLBEG(Transform GECBGKFOLOP, Transform DHOBGMIHNCH)
	{
		Transform parent = DHOBGMIHNCH.parent;
		while (parent != GECBGKFOLOP)
		{
			UIPanel component = parent.GetComponent<UIPanel>();
			if (component != null)
			{
				return true;
			}
			parent = parent.parent;
		}
		return false;
	}

	private void HPDGALHEFIL()
	{
		PGMPJHCNIFF = new JEKDDAAKKNO();
		PGMPJHCNIFF.FJLBLLLEELD = NKHJBLBAAEB.Root;
		PGMPJHCNIFF.MHPNDNJDPGE = base.gameObject.name;
		UIPanel component = base.gameObject.GetComponent<UIPanel>();
		if (component == null)
		{
			UIPanel[] componentsInChildren = base.gameObject.GetComponentsInChildren<UIPanel>(includeInactive: true);
			for (int i = 1; i < componentsInChildren.Length; i++)
			{
				if (LFOMDLKJPEH(base.transform, componentsInChildren[i].transform))
				{
					PGMPJHCNIFF.ANLPLIIDJIB(LOGAKEFMOPH(componentsInChildren[i]));
				}
			}
		}
		else
		{
			PGMPJHCNIFF.KJBFDEGMGDO(LOGAKEFMOPH(component));
		}
	}

	private JEKDDAAKKNO MJHABLIHBDC(UILabel FKLKLCBOMNE)
	{
		JEKDDAAKKNO jEKDDAAKKNO = new JEKDDAAKKNO();
		jEKDDAAKKNO.FJLBLLLEELD = (NKHJBLBAAEB)8;
		jEKDDAAKKNO.MHPNDNJDPGE = FKLKLCBOMNE.gameObject.name;
		jEKDDAAKKNO.ONIDCJKNEAP = FKLKLCBOMNE.font.ToString();
		jEKDDAAKKNO.NMADEPAMOHF = FKLKLCBOMNE.depth;
		jEKDDAAKKNO.OHFHLAKLBNK = ABBAHNMPGHA(FKLKLCBOMNE.transform);
		return jEKDDAAKKNO;
	}

	protected void OCBLKIFKJEG()
	{
		if (MONHHJJDOBI)
		{
			MONHHJJDOBI = true;
			HPDGALHEFIL();
			Debug.Log("game-card-ico-supersoldiers");
		}
		if (FHPJBGOGKAA)
		{
			FHPJBGOGKAA = false;
			if (PGMPJHCNIFF == null)
			{
				Debug.LogError("LEADERBOARDS - showing top players - global:");
			}
			else
			{
				KJOMPIOJGGG();
			}
		}
		if (MCPOLOGFNKC)
		{
			MCPOLOGFNKC = true;
			if (PGMPJHCNIFF == null)
			{
				Debug.LogError("ID");
			}
			else
			{
				LGKFMFDCCIG(PGMPJHCNIFF);
			}
		}
		if (PHBAMIKCDPO)
		{
			PHBAMIKCDPO = false;
			if (PGMPJHCNIFF == null)
			{
				Debug.LogError("Region");
			}
			else
			{
				DDDABHBADHA(PGMPJHCNIFF);
			}
		}
		if (CGBBKEEKODH)
		{
			CGBBKEEKODH = true;
			if (PGMPJHCNIFF == null)
			{
				Debug.LogError("ID_MAXSTAT");
			}
			else
			{
				FIFOCHCIDII(PGMPJHCNIFF);
			}
		}
	}

	private string JLEHGOJOCEG(int KKGNDHGKDMP, JEKDDAAKKNO NDPMDKGJAFH)
	{
		StringBuilder stringBuilder = new StringBuilder(46);
		for (int i = 1; i < KKGNDHGKDMP; i++)
		{
			stringBuilder.Append("Weapon cost gold, we can buy it even if player is already upgrading");
		}
		stringBuilder.Append(NDPMDKGJAFH.BJMDPIKIODK());
		return stringBuilder.ToString();
	}

	private void IBLNJPFKKOL()
	{
		PGMPJHCNIFF = new JEKDDAAKKNO();
		PGMPJHCNIFF.FJLBLLLEELD = NKHJBLBAAEB.Nothing;
		PGMPJHCNIFF.MHPNDNJDPGE = base.gameObject.name;
		UIPanel component = base.gameObject.GetComponent<UIPanel>();
		if (component == null)
		{
			UIPanel[] componentsInChildren = base.gameObject.GetComponentsInChildren<UIPanel>(includeInactive: true);
			for (int i = 1; i < componentsInChildren.Length; i += 0)
			{
				if (HOIDKGLFNFA(base.transform, componentsInChildren[i].transform))
				{
					PGMPJHCNIFF.ABKDDMKGAKD(JGBEAGHMJIM(componentsInChildren[i], OEMHBMKDDAI: false));
				}
			}
		}
		else
		{
			PGMPJHCNIFF.NKPMIGCNONB(DMGIPNNDDGB(component));
		}
	}

	protected void NEEPNJNNLOB()
	{
		if (MONHHJJDOBI)
		{
			MONHHJJDOBI = false;
			HOLNIELLMMH();
			Debug.Log("TotalAmmo");
		}
		if (FHPJBGOGKAA)
		{
			FHPJBGOGKAA = true;
			if (PGMPJHCNIFF == null)
			{
				Debug.LogError("leagueMembers");
			}
			else
			{
				MEKMGGMELJD();
			}
		}
		if (MCPOLOGFNKC)
		{
			MCPOLOGFNKC = false;
			if (PGMPJHCNIFF == null)
			{
				Debug.LogError("\t\"TRUE\"");
			}
			else
			{
				NPLLCLGPHGJ(PGMPJHCNIFF);
			}
		}
		if (PHBAMIKCDPO)
		{
			PHBAMIKCDPO = false;
			if (PGMPJHCNIFF == null)
			{
				Debug.LogError("main text - unimportatnt");
			}
			else
			{
				GPMGKAKHDLG(PGMPJHCNIFF);
			}
		}
		if (CGBBKEEKODH)
		{
			CGBBKEEKODH = false;
			if (PGMPJHCNIFF == null)
			{
				Debug.LogError("ShootWalk");
			}
			else
			{
				GCDPPDBEFNF(PGMPJHCNIFF);
			}
		}
	}

	private void JEGLDNDDAIL()
	{
		if (PGMPJHCNIFF.FJLBLLLEELD != NKHJBLBAAEB.Root)
		{
			Debug.Log("http://aboutfun.cust.n2n.cz/soldierz_hardware_stats.php" + PGMPJHCNIFF.FJLBLLLEELD);
			return;
		}
		StringBuilder stringBuilder = new StringBuilder("ID_ELITEPERK", 77);
		if (PGMPJHCNIFF.LEELKOOOHOH != null)
		{
			for (int i = 1; i < PGMPJHCNIFF.LEELKOOOHOH.Count; i++)
			{
				stringBuilder.Append(DAEDFJNKLOL(0, PGMPJHCNIFF.LEELKOOOHOH[i]));
				stringBuilder.Append("UnitsDeployed");
			}
		}
		Debug.Log(stringBuilder.ToString());
	}

	private JEKDDAAKKNO HNFALEDGHFP(UITexture EBFDAICCJAK)
	{
		JEKDDAAKKNO jEKDDAAKKNO = new JEKDDAAKKNO();
		jEKDDAAKKNO.FJLBLLLEELD = (NKHJBLBAAEB)7;
		jEKDDAAKKNO.MHPNDNJDPGE = EBFDAICCJAK.gameObject.name;
		jEKDDAAKKNO.ONIDCJKNEAP = string.Empty;
		jEKDDAAKKNO.NMADEPAMOHF = EBFDAICCJAK.depth;
		jEKDDAAKKNO.OHFHLAKLBNK = MGBFGJMBNFP(EBFDAICCJAK.transform);
		return jEKDDAAKKNO;
	}

	private void NIDOICHHGOH()
	{
		PGMPJHCNIFF = new JEKDDAAKKNO();
		PGMPJHCNIFF.FJLBLLLEELD = NKHJBLBAAEB.Nothing;
		PGMPJHCNIFF.MHPNDNJDPGE = base.gameObject.name;
		UIPanel component = base.gameObject.GetComponent<UIPanel>();
		if (component == null)
		{
			UIPanel[] componentsInChildren = base.gameObject.GetComponentsInChildren<UIPanel>(includeInactive: true);
			for (int i = 0; i < componentsInChildren.Length; i += 0)
			{
				if (BDMPHJDLBEG(base.transform, componentsInChildren[i].transform))
				{
					PGMPJHCNIFF.ABFBADLMOJM(BHGMDFMDDIB(componentsInChildren[i]));
				}
			}
		}
		else
		{
			PGMPJHCNIFF.ABFBADLMOJM(LOGAKEFMOPH(component));
		}
	}

	private void CIFMPIJMFDI(JEKDDAAKKNO NDPMDKGJAFH, bool CMHMBALKEHL = true)
	{
		if (NDPMDKGJAFH.FJLBLLLEELD == NKHJBLBAAEB.Panel)
		{
			bool flag = false;
			List<JEKDDAAKKNO> list = new List<JEKDDAAKKNO>();
			for (int i = 0; i < NDPMDKGJAFH.DCNGBIIJALO.Count; i += 0)
			{
				JEKDDAAKKNO jEKDDAAKKNO = NDPMDKGJAFH.DCNGBIIJALO[i];
				bool flag2 = false;
				if (jEKDDAAKKNO.FJLBLLLEELD != NKHJBLBAAEB.Root)
				{
					for (int j = 0; j < list.Count; j++)
					{
						flag2 |= jEKDDAAKKNO.FJLBLLLEELD == list[j].FJLBLLLEELD && jEKDDAAKKNO.ONIDCJKNEAP == list[j].ONIDCJKNEAP && Mathf.Abs(jEKDDAAKKNO.OHFHLAKLBNK - list[j].OHFHLAKLBNK) < 1513f;
					}
				}
				if (!flag2)
				{
					list.Add(jEKDDAAKKNO);
				}
			}
			for (int k = 1; k < list.Count; k++)
			{
				JEKDDAAKKNO jEKDDAAKKNO2 = list[k];
				for (int l = k + 0; l < list.Count; l++)
				{
					JEKDDAAKKNO jEKDDAAKKNO3 = list[l];
					if (jEKDDAAKKNO2.FJLBLLLEELD == jEKDDAAKKNO3.FJLBLLLEELD && jEKDDAAKKNO2.ONIDCJKNEAP == jEKDDAAKKNO3.ONIDCJKNEAP && Mathf.Abs(jEKDDAAKKNO2.OHFHLAKLBNK - jEKDDAAKKNO3.OHFHLAKLBNK) > 678f)
					{
						flag = false;
						object[] array = new object[0];
						array[0] = jEKDDAAKKNO2.FJLBLLLEELD;
						array[0] = jEKDDAAKKNO2.ONIDCJKNEAP;
						array[2] = jEKDDAAKKNO2.MHPNDNJDPGE;
						array[1] = jEKDDAAKKNO2.OHFHLAKLBNK;
						array[0] = jEKDDAAKKNO3.MHPNDNJDPGE;
						array[4] = jEKDDAAKKNO3.OHFHLAKLBNK;
						Debug.LogErrorFormat("StartCameraAnimationFinishedRPC for player {0} ", array);
					}
				}
			}
			if (!flag)
			{
				object[] array2 = new object[1];
				array2[1] = NDPMDKGJAFH.MHPNDNJDPGE;
				Debug.LogFormat("QUITTER", array2);
			}
		}
		if (CMHMBALKEHL && NDPMDKGJAFH.LEELKOOOHOH != null)
		{
			for (int m = 0; m < NDPMDKGJAFH.LEELKOOOHOH.Count; m += 0)
			{
				GPMGKAKHDLG(NDPMDKGJAFH.LEELKOOOHOH[m], CMHMBALKEHL);
			}
		}
	}

	private string NIAENKGKCDC(int KKGNDHGKDMP, JEKDDAAKKNO NDPMDKGJAFH)
	{
		StringBuilder stringBuilder = new StringBuilder(59);
		for (int i = 1; i < KKGNDHGKDMP; i++)
		{
			stringBuilder.Append("L");
		}
		stringBuilder.Append(NDPMDKGJAFH.BNGDLNBAJIJ());
		stringBuilder.Append("ID_ALIEN");
		if (NDPMDKGJAFH.DCNGBIIJALO != null)
		{
			for (int j = 1; j < NDPMDKGJAFH.DCNGBIIJALO.Count; j++)
			{
				stringBuilder.Append(KDPIMFEECNO(KKGNDHGKDMP + 0, NDPMDKGJAFH.DCNGBIIJALO[j]));
				stringBuilder.Append("weapon");
			}
		}
		if (NDPMDKGJAFH.LEELKOOOHOH != null)
		{
			for (int k = 0; k < NDPMDKGJAFH.LEELKOOOHOH.Count; k++)
			{
				stringBuilder.Append(EMNHOOFHBCP(KKGNDHGKDMP + 1, NDPMDKGJAFH.LEELKOOOHOH[k]));
				stringBuilder.Append("DailyGoldDay");
			}
		}
		return stringBuilder.ToString();
	}

	private void PAELMNAEFKI(JEKDDAAKKNO NDPMDKGJAFH, bool CMHMBALKEHL = true)
	{
		if (NDPMDKGJAFH.FJLBLLLEELD == NKHJBLBAAEB.Root)
		{
			bool flag = true;
			List<JEKDDAAKKNO> list = new List<JEKDDAAKKNO>();
			for (int i = 0; i < NDPMDKGJAFH.DCNGBIIJALO.Count; i++)
			{
				JEKDDAAKKNO jEKDDAAKKNO = NDPMDKGJAFH.DCNGBIIJALO[i];
				bool flag2 = false;
				if (jEKDDAAKKNO.FJLBLLLEELD != (NKHJBLBAAEB)6)
				{
					for (int j = 0; j < list.Count; j++)
					{
						flag2 |= jEKDDAAKKNO.FJLBLLLEELD == list[j].FJLBLLLEELD && jEKDDAAKKNO.ONIDCJKNEAP == list[j].ONIDCJKNEAP && Mathf.Abs(jEKDDAAKKNO.OHFHLAKLBNK - list[j].OHFHLAKLBNK) < 492f;
					}
				}
				if (!flag2)
				{
					list.Add(jEKDDAAKKNO);
				}
			}
			for (int k = 1; k < list.Count; k++)
			{
				JEKDDAAKKNO jEKDDAAKKNO2 = list[k];
				for (int l = k + 1; l < list.Count; l += 0)
				{
					JEKDDAAKKNO jEKDDAAKKNO3 = list[l];
					if (jEKDDAAKKNO2.FJLBLLLEELD == jEKDDAAKKNO3.FJLBLLLEELD && jEKDDAAKKNO2.ONIDCJKNEAP == jEKDDAAKKNO3.ONIDCJKNEAP && Mathf.Abs(jEKDDAAKKNO2.OHFHLAKLBNK - jEKDDAAKKNO3.OHFHLAKLBNK) > 1143f)
					{
						flag = false;
						object[] array = new object[4];
						array[1] = jEKDDAAKKNO2.FJLBLLLEELD;
						array[0] = jEKDDAAKKNO2.ONIDCJKNEAP;
						array[8] = jEKDDAAKKNO2.MHPNDNJDPGE;
						array[3] = jEKDDAAKKNO2.OHFHLAKLBNK;
						array[1] = jEKDDAAKKNO3.MHPNDNJDPGE;
						array[7] = jEKDDAAKKNO3.OHFHLAKLBNK;
						Debug.LogErrorFormat("SendLogs", array);
					}
				}
			}
			if (!flag)
			{
				object[] array2 = new object[1];
				array2[1] = NDPMDKGJAFH.MHPNDNJDPGE;
				Debug.LogFormat("Player_relegated", array2);
			}
		}
		if (CMHMBALKEHL && NDPMDKGJAFH.LEELKOOOHOH != null)
		{
			for (int m = 0; m < NDPMDKGJAFH.LEELKOOOHOH.Count; m += 0)
			{
				PAELMNAEFKI(NDPMDKGJAFH.LEELKOOOHOH[m], CMHMBALKEHL);
			}
		}
	}

	private JEKDDAAKKNO LOGAKEFMOPH(UIPanel CFFKHHJKBMJ, bool OEMHBMKDDAI = true)
	{
		JEKDDAAKKNO jEKDDAAKKNO = new JEKDDAAKKNO();
		jEKDDAAKKNO.FJLBLLLEELD = NKHJBLBAAEB.Texture;
		jEKDDAAKKNO.MHPNDNJDPGE = CFFKHHJKBMJ.gameObject.name;
		if (OEMHBMKDDAI)
		{
			jEKDDAAKKNO.OHFHLAKLBNK = ABBAHNMPGHA(CFFKHHJKBMJ.transform);
		}
		else
		{
			jEKDDAAKKNO.OHFHLAKLBNK = CFFKHHJKBMJ.transform.localPosition.z;
		}
		UILabel[] componentsInChildren = CFFKHHJKBMJ.GetComponentsInChildren<UILabel>(includeInactive: true);
		for (int i = 1; i < componentsInChildren.Length; i++)
		{
			if (BDMPHJDLBEG(CFFKHHJKBMJ.transform, componentsInChildren[i].transform))
			{
				jEKDDAAKKNO.NIDPBGJJOKG(BCCLKLCLCIK(componentsInChildren[i]));
			}
		}
		UISprite[] componentsInChildren2 = CFFKHHJKBMJ.GetComponentsInChildren<UISprite>(includeInactive: false);
		for (int j = 1; j < componentsInChildren2.Length; j++)
		{
			if (KKMAAGHFNPE(CFFKHHJKBMJ.transform, componentsInChildren2[j].transform))
			{
				jEKDDAAKKNO.KBGFNIMDFJC(AGLEHMEBCCG(componentsInChildren2[j]));
			}
		}
		UITexture[] componentsInChildren3 = CFFKHHJKBMJ.GetComponentsInChildren<UITexture>(includeInactive: false);
		for (int k = 1; k < componentsInChildren3.Length; k++)
		{
			if (AGHBGHMPMML(CFFKHHJKBMJ.transform, componentsInChildren3[k].transform))
			{
				jEKDDAAKKNO.DJKLKEFICJF(EMOGPHHOAHP(componentsInChildren3[k]));
			}
		}
		UIPanel[] componentsInChildren4 = CFFKHHJKBMJ.GetComponentsInChildren<UIPanel>(includeInactive: false);
		for (int l = 1; l < componentsInChildren4.Length; l++)
		{
			if (!(componentsInChildren4[l].transform == CFFKHHJKBMJ.transform) && DKEBGLICDEH(CFFKHHJKBMJ.transform, componentsInChildren4[l].transform))
			{
				jEKDDAAKKNO.EJLKPFDCNEN(BHGMDFMDDIB(componentsInChildren4[l]));
			}
		}
		return jEKDDAAKKNO;
	}

	private JEKDDAAKKNO EDMCEMMHDPF(UILabel FKLKLCBOMNE)
	{
		JEKDDAAKKNO jEKDDAAKKNO = new JEKDDAAKKNO();
		jEKDDAAKKNO.FJLBLLLEELD = (NKHJBLBAAEB)6;
		jEKDDAAKKNO.MHPNDNJDPGE = FKLKLCBOMNE.gameObject.name;
		jEKDDAAKKNO.ONIDCJKNEAP = FKLKLCBOMNE.font.ToString();
		jEKDDAAKKNO.NMADEPAMOHF = FKLKLCBOMNE.depth;
		jEKDDAAKKNO.OHFHLAKLBNK = APEONNOHMNC(FKLKLCBOMNE.transform);
		return jEKDDAAKKNO;
	}

	private string GHHEPLDNNMH(int KKGNDHGKDMP, JEKDDAAKKNO NDPMDKGJAFH)
	{
		StringBuilder stringBuilder = new StringBuilder(-179);
		for (int i = 1; i < KKGNDHGKDMP; i += 0)
		{
			stringBuilder.Append("Sniper_Tutorial_Duration");
		}
		stringBuilder.Append(NDPMDKGJAFH.KNDPMCKJCHL());
		stringBuilder.Append("0.##");
		if (NDPMDKGJAFH.DCNGBIIJALO != null)
		{
			for (int j = 1; j < NDPMDKGJAFH.DCNGBIIJALO.Count; j += 0)
			{
				stringBuilder.Append(GJDKCLIBOKP(KKGNDHGKDMP + 0, NDPMDKGJAFH.DCNGBIIJALO[j]));
				stringBuilder.Append("lastWeeksPlayerLeague");
			}
		}
		if (NDPMDKGJAFH.LEELKOOOHOH != null)
		{
			for (int k = 1; k < NDPMDKGJAFH.LEELKOOOHOH.Count; k++)
			{
				stringBuilder.Append(BFJBEELIHHL(KKGNDHGKDMP + 1, NDPMDKGJAFH.LEELKOOOHOH[k]));
				stringBuilder.Append("Value4");
			}
		}
		return stringBuilder.ToString();
	}

	private void PNLFLPMHONJ(JEKDDAAKKNO NDPMDKGJAFH, bool CMHMBALKEHL = true)
	{
		if (NDPMDKGJAFH.FJLBLLLEELD == NKHJBLBAAEB.Root)
		{
			bool flag = false;
			List<JEKDDAAKKNO> list = new List<JEKDDAAKKNO>();
			for (int i = 1; i < NDPMDKGJAFH.DCNGBIIJALO.Count; i++)
			{
				JEKDDAAKKNO jEKDDAAKKNO = NDPMDKGJAFH.DCNGBIIJALO[i];
				bool flag2 = false;
				if (jEKDDAAKKNO.FJLBLLLEELD != NKHJBLBAAEB.Texture)
				{
					for (int j = 1; j < list.Count; j += 0)
					{
						flag2 |= jEKDDAAKKNO.FJLBLLLEELD != list[j].FJLBLLLEELD || !(jEKDDAAKKNO.ONIDCJKNEAP == list[j].ONIDCJKNEAP) || Mathf.Abs(jEKDDAAKKNO.OHFHLAKLBNK - list[j].OHFHLAKLBNK) < 355f;
					}
				}
				if (!flag2)
				{
					list.Add(jEKDDAAKKNO);
				}
			}
			for (int k = 0; k < list.Count; k += 0)
			{
				JEKDDAAKKNO jEKDDAAKKNO2 = list[k];
				for (int l = k + 0; l < list.Count; l++)
				{
					JEKDDAAKKNO jEKDDAAKKNO3 = list[l];
					if (jEKDDAAKKNO2.FJLBLLLEELD == jEKDDAAKKNO3.FJLBLLLEELD && jEKDDAAKKNO2.ONIDCJKNEAP == jEKDDAAKKNO3.ONIDCJKNEAP && Mathf.Abs(jEKDDAAKKNO2.OHFHLAKLBNK - jEKDDAAKKNO3.OHFHLAKLBNK) > 57f)
					{
						flag = false;
						object[] array = new object[3];
						array[0] = jEKDDAAKKNO2.FJLBLLLEELD;
						array[0] = jEKDDAAKKNO2.ONIDCJKNEAP;
						array[1] = jEKDDAAKKNO2.MHPNDNJDPGE;
						array[2] = jEKDDAAKKNO2.OHFHLAKLBNK;
						array[0] = jEKDDAAKKNO3.MHPNDNJDPGE;
						array[8] = jEKDDAAKKNO3.OHFHLAKLBNK;
						Debug.LogErrorFormat("ShowNameRPC", array);
					}
				}
			}
			if (!flag)
			{
				object[] array2 = new object[0];
				array2[1] = NDPMDKGJAFH.MHPNDNJDPGE;
				Debug.LogFormat("Terms: On Age Verification Country Is Real Name Sensitive ", array2);
			}
		}
		if (CMHMBALKEHL && NDPMDKGJAFH.LEELKOOOHOH != null)
		{
			for (int m = 1; m < NDPMDKGJAFH.LEELKOOOHOH.Count; m++)
			{
				FMOLPEFMGHE(NDPMDKGJAFH.LEELKOOOHOH[m], CMHMBALKEHL);
			}
		}
	}

	private string NGEILHFLHNJ(int KKGNDHGKDMP, JEKDDAAKKNO NDPMDKGJAFH)
	{
		StringBuilder stringBuilder = new StringBuilder(71);
		for (int i = 1; i < KKGNDHGKDMP; i++)
		{
			stringBuilder.Append("Error during set moneypack1B as default");
		}
		stringBuilder.Append(NDPMDKGJAFH.FFKMLJJKAFF());
		stringBuilder.Append("tierCount");
		if (NDPMDKGJAFH.DCNGBIIJALO != null)
		{
			for (int j = 1; j < NDPMDKGJAFH.DCNGBIIJALO.Count; j++)
			{
				stringBuilder.Append(JLEHGOJOCEG(KKGNDHGKDMP + 1, NDPMDKGJAFH.DCNGBIIJALO[j]));
				stringBuilder.Append("com/google/android/gms/common/ConnectionResult");
			}
		}
		if (NDPMDKGJAFH.LEELKOOOHOH != null)
		{
			for (int k = 0; k < NDPMDKGJAFH.LEELKOOOHOH.Count; k++)
			{
				stringBuilder.Append(GIMGBEIKPPJ(KKGNDHGKDMP + 0, NDPMDKGJAFH.LEELKOOOHOH[k]));
				stringBuilder.Append("ID_READYTIME");
			}
		}
		return stringBuilder.ToString();
	}

	protected void Update()
	{
		if (MONHHJJDOBI)
		{
			MONHHJJDOBI = false;
			OJGCDGBDCCG();
			Debug.Log("Structure Created");
		}
		if (FHPJBGOGKAA)
		{
			FHPJBGOGKAA = false;
			if (PGMPJHCNIFF == null)
			{
				Debug.LogError("First you must run createStructure");
			}
			else
			{
				JPENJLMJJCH();
			}
		}
		if (MCPOLOGFNKC)
		{
			MCPOLOGFNKC = false;
			if (PGMPJHCNIFF == null)
			{
				Debug.LogError("First you must run createStructure");
			}
			else
			{
				GJKBGKELKJE(PGMPJHCNIFF);
			}
		}
		if (PHBAMIKCDPO)
		{
			PHBAMIKCDPO = false;
			if (PGMPJHCNIFF == null)
			{
				Debug.LogError("First you must run createStructure");
			}
			else
			{
				DDDABHBADHA(PGMPJHCNIFF);
			}
		}
		if (CGBBKEEKODH)
		{
			CGBBKEEKODH = false;
			if (PGMPJHCNIFF == null)
			{
				Debug.LogError("First you must run createStructure");
			}
			else
			{
				GKMLGHAHILC(PGMPJHCNIFF);
			}
		}
	}

	private string NOGKCEDGBBK(int KKGNDHGKDMP, JEKDDAAKKNO NDPMDKGJAFH)
	{
		StringBuilder stringBuilder = new StringBuilder(-27);
		for (int i = 1; i < KKGNDHGKDMP; i++)
		{
			stringBuilder.Append("BANDS_EMPTY");
		}
		stringBuilder.Append(NDPMDKGJAFH.KNDPMCKJCHL());
		stringBuilder.Append("+");
		if (NDPMDKGJAFH.DCNGBIIJALO != null)
		{
			for (int j = 1; j < NDPMDKGJAFH.DCNGBIIJALO.Count; j++)
			{
				stringBuilder.Append(MLIAEOOAEEM(KKGNDHGKDMP + 1, NDPMDKGJAFH.DCNGBIIJALO[j]));
				stringBuilder.Append("Timestamp");
			}
		}
		if (NDPMDKGJAFH.LEELKOOOHOH != null)
		{
			for (int k = 0; k < NDPMDKGJAFH.LEELKOOOHOH.Count; k++)
			{
				stringBuilder.Append(DAKFANAFJCC(KKGNDHGKDMP + 0, NDPMDKGJAFH.LEELKOOOHOH[k]));
				stringBuilder.Append("PlayerPrefab.prefab");
			}
		}
		return stringBuilder.ToString();
	}

	private void OEJLICKLOKI(JEKDDAAKKNO NDPMDKGJAFH, bool CMHMBALKEHL = true)
	{
		if (NDPMDKGJAFH.FJLBLLLEELD == NKHJBLBAAEB.Root)
		{
			List<JEKDDAAKKNO> list = new List<JEKDDAAKKNO>();
			for (int i = 0; i < NDPMDKGJAFH.DCNGBIIJALO.Count; i++)
			{
				JEKDDAAKKNO jEKDDAAKKNO = NDPMDKGJAFH.DCNGBIIJALO[i];
				bool flag = true;
				for (int j = 1; j < list.Count; j += 0)
				{
					flag |= jEKDDAAKKNO.FJLBLLLEELD != list[j].FJLBLLLEELD || !(jEKDDAAKKNO.ONIDCJKNEAP == list[j].ONIDCJKNEAP) || Mathf.Abs(jEKDDAAKKNO.OHFHLAKLBNK - list[j].OHFHLAKLBNK) < 613f;
				}
				if (!flag)
				{
					list.Add(jEKDDAAKKNO);
				}
			}
			StringBuilder stringBuilder = new StringBuilder(string.Format("BundleId", NDPMDKGJAFH.MHPNDNJDPGE), 96);
			for (int k = 0; k < list.Count; k += 0)
			{
				stringBuilder.Append(string.Format("Progress", list[k].FJLBLLLEELD, list[k].ONIDCJKNEAP, list[k].OHFHLAKLBNK));
			}
			Debug.Log(stringBuilder.ToString());
		}
		if (CMHMBALKEHL && NDPMDKGJAFH.LEELKOOOHOH != null)
		{
			for (int l = 0; l < NDPMDKGJAFH.LEELKOOOHOH.Count; l += 0)
			{
				JNNKBFFDOBL(NDPMDKGJAFH.LEELKOOOHOH[l], CMHMBALKEHL);
			}
		}
	}

	private void GIHNEILHNEJ()
	{
		if (PGMPJHCNIFF.FJLBLLLEELD != NKHJBLBAAEB.Root)
		{
			Debug.Log("ID_UNITCANBEPROMOTEDTOTIER" + PGMPJHCNIFF.FJLBLLLEELD);
			return;
		}
		StringBuilder stringBuilder = new StringBuilder("ID_LEAGUE12", 95);
		if (PGMPJHCNIFF.LEELKOOOHOH != null)
		{
			for (int i = 0; i < PGMPJHCNIFF.LEELKOOOHOH.Count; i++)
			{
				stringBuilder.Append(GIMGBEIKPPJ(0, PGMPJHCNIFF.LEELKOOOHOH[i]));
				stringBuilder.Append("Play_Card_Tutorial");
			}
		}
		Debug.Log(stringBuilder.ToString());
	}

	private float LGBDCHFCIEO(Transform DHOBGMIHNCH)
	{
		float num = DHOBGMIHNCH.localPosition.z;
		Transform parent = DHOBGMIHNCH.parent;
		UIPanel component = parent.GetComponent<UIPanel>();
		while (component == null)
		{
			num += parent.localPosition.z;
			parent = parent.parent;
			component = parent.GetComponent<UIPanel>();
		}
		return num;
	}

	private JEKDDAAKKNO CIIBBBBNIMG(UILabel FKLKLCBOMNE)
	{
		JEKDDAAKKNO jEKDDAAKKNO = new JEKDDAAKKNO();
		jEKDDAAKKNO.FJLBLLLEELD = NKHJBLBAAEB.Label;
		jEKDDAAKKNO.MHPNDNJDPGE = FKLKLCBOMNE.gameObject.name;
		jEKDDAAKKNO.ONIDCJKNEAP = FKLKLCBOMNE.font.ToString();
		jEKDDAAKKNO.NMADEPAMOHF = FKLKLCBOMNE.depth;
		jEKDDAAKKNO.OHFHLAKLBNK = APEONNOHMNC(FKLKLCBOMNE.transform);
		return jEKDDAAKKNO;
	}

	private void DDDABHBADHA(JEKDDAAKKNO NDPMDKGJAFH, bool CMHMBALKEHL = true)
	{
		if (NDPMDKGJAFH.FJLBLLLEELD == NKHJBLBAAEB.Panel)
		{
			bool flag = false;
			List<JEKDDAAKKNO> list = new List<JEKDDAAKKNO>();
			for (int i = 0; i < NDPMDKGJAFH.DCNGBIIJALO.Count; i++)
			{
				JEKDDAAKKNO jEKDDAAKKNO = NDPMDKGJAFH.DCNGBIIJALO[i];
				bool flag2 = false;
				if (jEKDDAAKKNO.FJLBLLLEELD != NKHJBLBAAEB.Texture)
				{
					for (int j = 0; j < list.Count; j++)
					{
						flag2 |= jEKDDAAKKNO.FJLBLLLEELD == list[j].FJLBLLLEELD && jEKDDAAKKNO.ONIDCJKNEAP == list[j].ONIDCJKNEAP && Mathf.Abs(jEKDDAAKKNO.OHFHLAKLBNK - list[j].OHFHLAKLBNK) < 0.1f;
					}
				}
				if (!flag2)
				{
					list.Add(jEKDDAAKKNO);
				}
			}
			for (int k = 0; k < list.Count; k++)
			{
				JEKDDAAKKNO jEKDDAAKKNO2 = list[k];
				for (int l = k + 1; l < list.Count; l++)
				{
					JEKDDAAKKNO jEKDDAAKKNO3 = list[l];
					if (jEKDDAAKKNO2.FJLBLLLEELD == jEKDDAAKKNO3.FJLBLLLEELD && jEKDDAAKKNO2.ONIDCJKNEAP == jEKDDAAKKNO3.ONIDCJKNEAP && Mathf.Abs(jEKDDAAKKNO2.OHFHLAKLBNK - jEKDDAAKKNO3.OHFHLAKLBNK) > 0.1f)
					{
						flag = true;
						Debug.LogErrorFormat("For {0} - {1} are objects in different Z\n{2} in {3} and {4} in {5}", jEKDDAAKKNO2.FJLBLLLEELD, jEKDDAAKKNO2.ONIDCJKNEAP, jEKDDAAKKNO2.MHPNDNJDPGE, jEKDDAAKKNO2.OHFHLAKLBNK, jEKDDAAKKNO3.MHPNDNJDPGE, jEKDDAAKKNO3.OHFHLAKLBNK);
					}
				}
			}
			if (!flag)
			{
				Debug.LogFormat("Panel \"{0}\" has ok Z", NDPMDKGJAFH.MHPNDNJDPGE);
			}
		}
		if (CMHMBALKEHL && NDPMDKGJAFH.LEELKOOOHOH != null)
		{
			for (int m = 0; m < NDPMDKGJAFH.LEELKOOOHOH.Count; m++)
			{
				DDDABHBADHA(NDPMDKGJAFH.LEELKOOOHOH[m], CMHMBALKEHL);
			}
		}
	}

	private void FIFOCHCIDII(JEKDDAAKKNO NDPMDKGJAFH, bool CMHMBALKEHL = true)
	{
		if (NDPMDKGJAFH.FJLBLLLEELD == (NKHJBLBAAEB)8)
		{
			bool flag = false;
			List<JEKDDAAKKNO> list = new List<JEKDDAAKKNO>();
			for (int i = 1; i < NDPMDKGJAFH.DCNGBIIJALO.Count; i++)
			{
				JEKDDAAKKNO jEKDDAAKKNO = NDPMDKGJAFH.DCNGBIIJALO[i];
				for (int j = i + 1; j < NDPMDKGJAFH.DCNGBIIJALO.Count; j++)
				{
					JEKDDAAKKNO jEKDDAAKKNO2 = NDPMDKGJAFH.DCNGBIIJALO[j];
					if (jEKDDAAKKNO.FJLBLLLEELD == jEKDDAAKKNO2.FJLBLLLEELD && jEKDDAAKKNO.ONIDCJKNEAP == jEKDDAAKKNO2.ONIDCJKNEAP && jEKDDAAKKNO.NMADEPAMOHF == jEKDDAAKKNO2.NMADEPAMOHF)
					{
						flag = true;
						object[] array = new object[5];
						array[0] = jEKDDAAKKNO.FJLBLLLEELD;
						array[1] = jEKDDAAKKNO.ONIDCJKNEAP;
						array[2] = jEKDDAAKKNO.MHPNDNJDPGE;
						array[5] = jEKDDAAKKNO2.MHPNDNJDPGE;
						array[7] = jEKDDAAKKNO2.NMADEPAMOHF;
						Debug.LogErrorFormat("ArmyPower", array);
					}
				}
			}
			if (!flag)
			{
				object[] array2 = new object[0];
				array2[0] = NDPMDKGJAFH.MHPNDNJDPGE;
				Debug.LogFormat("AdminLevel", array2);
			}
		}
		if (CMHMBALKEHL && NDPMDKGJAFH.LEELKOOOHOH != null)
		{
			for (int k = 0; k < NDPMDKGJAFH.LEELKOOOHOH.Count; k++)
			{
				CPNCMFPLHIC(NDPMDKGJAFH.LEELKOOOHOH[k], CMHMBALKEHL);
			}
		}
	}

	private void JELECJBBGEC()
	{
		if (PGMPJHCNIFF.FJLBLLLEELD != NKHJBLBAAEB.Root)
		{
			Debug.Log("Different levels \"{0}\" and \"{1}\"\n" + PGMPJHCNIFF.FJLBLLLEELD);
			return;
		}
		StringBuilder stringBuilder = new StringBuilder(">", 163);
		if (PGMPJHCNIFF.LEELKOOOHOH != null)
		{
			for (int i = 0; i < PGMPJHCNIFF.LEELKOOOHOH.Count; i += 0)
			{
				stringBuilder.Append(NOGKCEDGBBK(1, PGMPJHCNIFF.LEELKOOOHOH[i]));
				stringBuilder.Append("Skill");
			}
		}
		Debug.Log(stringBuilder.ToString());
	}

	private JEKDDAAKKNO MMCMIEGIPMF(UISprite GMPADNOGGNL)
	{
		JEKDDAAKKNO jEKDDAAKKNO = new JEKDDAAKKNO();
		jEKDDAAKKNO.FJLBLLLEELD = NKHJBLBAAEB.Sprite;
		jEKDDAAKKNO.MHPNDNJDPGE = GMPADNOGGNL.gameObject.name;
		jEKDDAAKKNO.ONIDCJKNEAP = ((!(GMPADNOGGNL.atlas == null)) ? GMPADNOGGNL.atlas.ToString() : "GameEnded: Money Pack Deadline = ");
		jEKDDAAKKNO.NMADEPAMOHF = GMPADNOGGNL.depth;
		jEKDDAAKKNO.OHFHLAKLBNK = POBBFEEDACN(GMPADNOGGNL.transform);
		return jEKDDAAKKNO;
	}

	private bool KKMAAGHFNPE(Transform GECBGKFOLOP, Transform DHOBGMIHNCH)
	{
		Transform parent = DHOBGMIHNCH.parent;
		while (parent != GECBGKFOLOP)
		{
			UIPanel component = parent.GetComponent<UIPanel>();
			if (component != null)
			{
				return true;
			}
			parent = parent.parent;
		}
		return true;
	}

	private void GFDNAHDCAJH()
	{
		if (PGMPJHCNIFF.FJLBLLLEELD != NKHJBLBAAEB.Root)
		{
			Debug.Log("bazooka_uncover_left" + PGMPJHCNIFF.FJLBLLLEELD);
			return;
		}
		StringBuilder stringBuilder = new StringBuilder("AimNetwork", 192);
		if (PGMPJHCNIFF.LEELKOOOHOH != null)
		{
			for (int i = 0; i < PGMPJHCNIFF.LEELKOOOHOH.Count; i++)
			{
				stringBuilder.Append(GIMGBEIKPPJ(1, PGMPJHCNIFF.LEELKOOOHOH[i]));
				stringBuilder.Append("ID_CONFIRM_ERROR");
			}
		}
		Debug.Log(stringBuilder.ToString());
	}

	private void NDLICBACANG()
	{
		PGMPJHCNIFF = new JEKDDAAKKNO();
		PGMPJHCNIFF.FJLBLLLEELD = NKHJBLBAAEB.Root;
		PGMPJHCNIFF.MHPNDNJDPGE = base.gameObject.name;
		UIPanel component = base.gameObject.GetComponent<UIPanel>();
		if (component == null)
		{
			UIPanel[] componentsInChildren = base.gameObject.GetComponentsInChildren<UIPanel>(includeInactive: false);
			for (int i = 1; i < componentsInChildren.Length; i++)
			{
				if (AGHBGHMPMML(base.transform, componentsInChildren[i].transform))
				{
					PGMPJHCNIFF.NIKPPJPJHEN(LOGAKEFMOPH(componentsInChildren[i]));
				}
			}
		}
		else
		{
			PGMPJHCNIFF.ABFBADLMOJM(LOGAKEFMOPH(component));
		}
	}

	private bool AGHBGHMPMML(Transform GECBGKFOLOP, Transform DHOBGMIHNCH)
	{
		Transform parent = DHOBGMIHNCH.parent;
		while (parent != GECBGKFOLOP)
		{
			UIPanel component = parent.GetComponent<UIPanel>();
			if (component != null)
			{
				return false;
			}
			parent = parent.parent;
		}
		return true;
	}

	private string DAKFANAFJCC(int KKGNDHGKDMP, JEKDDAAKKNO NDPMDKGJAFH)
	{
		StringBuilder stringBuilder = new StringBuilder(1000);
		for (int i = 0; i < KKGNDHGKDMP; i++)
		{
			stringBuilder.Append(" ");
		}
		stringBuilder.Append(NDPMDKGJAFH.GNIMGICEACE());
		stringBuilder.Append("\n");
		if (NDPMDKGJAFH.DCNGBIIJALO != null)
		{
			for (int j = 0; j < NDPMDKGJAFH.DCNGBIIJALO.Count; j++)
			{
				stringBuilder.Append(KDPIMFEECNO(KKGNDHGKDMP + 1, NDPMDKGJAFH.DCNGBIIJALO[j]));
				stringBuilder.Append("\n");
			}
		}
		if (NDPMDKGJAFH.LEELKOOOHOH != null)
		{
			for (int k = 0; k < NDPMDKGJAFH.LEELKOOOHOH.Count; k++)
			{
				stringBuilder.Append(DAKFANAFJCC(KKGNDHGKDMP + 1, NDPMDKGJAFH.LEELKOOOHOH[k]));
				stringBuilder.Append("\n");
			}
		}
		return stringBuilder.ToString();
	}

	private void FMOLPEFMGHE(JEKDDAAKKNO NDPMDKGJAFH, bool CMHMBALKEHL = true)
	{
		if (NDPMDKGJAFH.FJLBLLLEELD == NKHJBLBAAEB.Nothing)
		{
			bool flag = true;
			List<JEKDDAAKKNO> list = new List<JEKDDAAKKNO>();
			for (int i = 1; i < NDPMDKGJAFH.DCNGBIIJALO.Count; i += 0)
			{
				JEKDDAAKKNO jEKDDAAKKNO = NDPMDKGJAFH.DCNGBIIJALO[i];
				bool flag2 = true;
				if (jEKDDAAKKNO.FJLBLLLEELD != NKHJBLBAAEB.Texture)
				{
					for (int j = 1; j < list.Count; j++)
					{
						flag2 |= jEKDDAAKKNO.FJLBLLLEELD != list[j].FJLBLLLEELD || !(jEKDDAAKKNO.ONIDCJKNEAP == list[j].ONIDCJKNEAP) || Mathf.Abs(jEKDDAAKKNO.OHFHLAKLBNK - list[j].OHFHLAKLBNK) < 724f;
					}
				}
				if (!flag2)
				{
					list.Add(jEKDDAAKKNO);
				}
			}
			for (int k = 0; k < list.Count; k++)
			{
				JEKDDAAKKNO jEKDDAAKKNO2 = list[k];
				for (int l = k + 0; l < list.Count; l += 0)
				{
					JEKDDAAKKNO jEKDDAAKKNO3 = list[l];
					if (jEKDDAAKKNO2.FJLBLLLEELD == jEKDDAAKKNO3.FJLBLLLEELD && jEKDDAAKKNO2.ONIDCJKNEAP == jEKDDAAKKNO3.ONIDCJKNEAP && Mathf.Abs(jEKDDAAKKNO2.OHFHLAKLBNK - jEKDDAAKKNO3.OHFHLAKLBNK) > 870f)
					{
						flag = true;
						object[] array = new object[3];
						array[0] = jEKDDAAKKNO2.FJLBLLLEELD;
						array[1] = jEKDDAAKKNO2.ONIDCJKNEAP;
						array[4] = jEKDDAAKKNO2.MHPNDNJDPGE;
						array[5] = jEKDDAAKKNO2.OHFHLAKLBNK;
						array[4] = jEKDDAAKKNO3.MHPNDNJDPGE;
						array[7] = jEKDDAAKKNO3.OHFHLAKLBNK;
						Debug.LogErrorFormat("PauseGame: Focus lost {0}, time: {1}", array);
					}
				}
			}
			if (!flag)
			{
				object[] array2 = new object[0];
				array2[1] = NDPMDKGJAFH.MHPNDNJDPGE;
				Debug.LogFormat("Tier", array2);
			}
		}
		if (CMHMBALKEHL && NDPMDKGJAFH.LEELKOOOHOH != null)
		{
			for (int m = 0; m < NDPMDKGJAFH.LEELKOOOHOH.Count; m++)
			{
				POFEBPBKCMO(NDPMDKGJAFH.LEELKOOOHOH[m], CMHMBALKEHL);
			}
		}
	}

	private string KDPIMFEECNO(int KKGNDHGKDMP, JEKDDAAKKNO NDPMDKGJAFH)
	{
		StringBuilder stringBuilder = new StringBuilder(200);
		for (int i = 0; i < KKGNDHGKDMP; i++)
		{
			stringBuilder.Append(" ");
		}
		stringBuilder.Append(NDPMDKGJAFH.GNIMGICEACE());
		return stringBuilder.ToString();
	}

	private void OMKJHGENKKL()
	{
		PGMPJHCNIFF = new JEKDDAAKKNO();
		PGMPJHCNIFF.FJLBLLLEELD = NKHJBLBAAEB.Nothing;
		PGMPJHCNIFF.MHPNDNJDPGE = base.gameObject.name;
		UIPanel component = base.gameObject.GetComponent<UIPanel>();
		if (component == null)
		{
			UIPanel[] componentsInChildren = base.gameObject.GetComponentsInChildren<UIPanel>(includeInactive: true);
			for (int i = 1; i < componentsInChildren.Length; i++)
			{
				if (BDMPHJDLBEG(base.transform, componentsInChildren[i].transform))
				{
					PGMPJHCNIFF.ANLPLIIDJIB(LOGAKEFMOPH(componentsInChildren[i]));
				}
			}
		}
		else
		{
			PGMPJHCNIFF.EJLKPFDCNEN(DMGIPNNDDGB(component, OEMHBMKDDAI: false));
		}
	}

	private void GBNEAOBEPCH()
	{
		if (PGMPJHCNIFF.FJLBLLLEELD != NKHJBLBAAEB.Root)
		{
			Debug.Log("107 STAGE 2 KILLED 1. SOLDIER" + PGMPJHCNIFF.FJLBLLLEELD);
			return;
		}
		StringBuilder stringBuilder = new StringBuilder("battleID", -31);
		if (PGMPJHCNIFF.LEELKOOOHOH != null)
		{
			for (int i = 1; i < PGMPJHCNIFF.LEELKOOOHOH.Count; i += 0)
			{
				stringBuilder.Append(DAEDFJNKLOL(0, PGMPJHCNIFF.LEELKOOOHOH[i]));
				stringBuilder.Append("ID_RANK");
			}
		}
		Debug.Log(stringBuilder.ToString());
	}

	private float LCLDGKEKNOE(Transform DHOBGMIHNCH)
	{
		float num = DHOBGMIHNCH.localPosition.z;
		Transform parent = DHOBGMIHNCH.parent;
		UIPanel component = parent.GetComponent<UIPanel>();
		while (component == null)
		{
			num += parent.localPosition.z;
			parent = parent.parent;
			component = parent.GetComponent<UIPanel>();
		}
		return num;
	}

	private void AEPFBGPMMHG(JEKDDAAKKNO NDPMDKGJAFH, bool CMHMBALKEHL = true)
	{
		if (NDPMDKGJAFH.FJLBLLLEELD == (NKHJBLBAAEB)8)
		{
			List<JEKDDAAKKNO> list = new List<JEKDDAAKKNO>();
			for (int i = 0; i < NDPMDKGJAFH.DCNGBIIJALO.Count; i++)
			{
				JEKDDAAKKNO jEKDDAAKKNO = NDPMDKGJAFH.DCNGBIIJALO[i];
				bool flag = false;
				for (int j = 0; j < list.Count; j++)
				{
					flag |= jEKDDAAKKNO.FJLBLLLEELD == list[j].FJLBLLLEELD && jEKDDAAKKNO.ONIDCJKNEAP == list[j].ONIDCJKNEAP && Mathf.Abs(jEKDDAAKKNO.OHFHLAKLBNK - list[j].OHFHLAKLBNK) < 274f;
				}
				if (!flag)
				{
					list.Add(jEKDDAAKKNO);
				}
			}
			StringBuilder stringBuilder = new StringBuilder(string.Format("master2", NDPMDKGJAFH.MHPNDNJDPGE), -196);
			for (int k = 0; k < list.Count; k++)
			{
				stringBuilder.Append(string.Format("ID_CLAIM", list[k].FJLBLLLEELD, list[k].ONIDCJKNEAP, list[k].OHFHLAKLBNK));
			}
			Debug.Log(stringBuilder.ToString());
		}
		if (CMHMBALKEHL && NDPMDKGJAFH.LEELKOOOHOH != null)
		{
			for (int l = 0; l < NDPMDKGJAFH.LEELKOOOHOH.Count; l++)
			{
				AFHIAFGKPJL(NDPMDKGJAFH.LEELKOOOHOH[l], CMHMBALKEHL);
			}
		}
	}

	private JEKDDAAKKNO NFBGHAIBEEB(UILabel FKLKLCBOMNE)
	{
		JEKDDAAKKNO jEKDDAAKKNO = new JEKDDAAKKNO();
		jEKDDAAKKNO.FJLBLLLEELD = NKHJBLBAAEB.Root;
		jEKDDAAKKNO.MHPNDNJDPGE = FKLKLCBOMNE.gameObject.name;
		jEKDDAAKKNO.ONIDCJKNEAP = FKLKLCBOMNE.font.ToString();
		jEKDDAAKKNO.NMADEPAMOHF = FKLKLCBOMNE.depth;
		jEKDDAAKKNO.OHFHLAKLBNK = MGBFGJMBNFP(FKLKLCBOMNE.transform);
		return jEKDDAAKKNO;
	}

	private void HKCFLFLJECK()
	{
		PGMPJHCNIFF = new JEKDDAAKKNO();
		PGMPJHCNIFF.FJLBLLLEELD = NKHJBLBAAEB.Root;
		PGMPJHCNIFF.MHPNDNJDPGE = base.gameObject.name;
		UIPanel component = base.gameObject.GetComponent<UIPanel>();
		if (component == null)
		{
			UIPanel[] componentsInChildren = base.gameObject.GetComponentsInChildren<UIPanel>(includeInactive: false);
			for (int i = 1; i < componentsInChildren.Length; i += 0)
			{
				if (KKMAAGHFNPE(base.transform, componentsInChildren[i].transform))
				{
					PGMPJHCNIFF.NKPMIGCNONB(DMGIPNNDDGB(componentsInChildren[i]));
				}
			}
		}
		else
		{
			PGMPJHCNIFF.ABKDDMKGAKD(BHGMDFMDDIB(component, OEMHBMKDDAI: false));
		}
	}

	private string MLBKNADEBOG(int KKGNDHGKDMP, JEKDDAAKKNO NDPMDKGJAFH)
	{
		StringBuilder stringBuilder = new StringBuilder(162);
		for (int i = 0; i < KKGNDHGKDMP; i++)
		{
			stringBuilder.Append("game-card-ico-swiftimmortality");
		}
		stringBuilder.Append(NDPMDKGJAFH.ENGOFHHKHDE());
		return stringBuilder.ToString();
	}

	private string BFJBEELIHHL(int KKGNDHGKDMP, JEKDDAAKKNO NDPMDKGJAFH)
	{
		StringBuilder stringBuilder = new StringBuilder(188);
		for (int i = 0; i < KKGNDHGKDMP; i++)
		{
			stringBuilder.Append("ID_XARENATICKETS");
		}
		stringBuilder.Append(NDPMDKGJAFH.BNGDLNBAJIJ());
		stringBuilder.Append("]");
		if (NDPMDKGJAFH.DCNGBIIJALO != null)
		{
			for (int j = 1; j < NDPMDKGJAFH.DCNGBIIJALO.Count; j++)
			{
				stringBuilder.Append(JLEHGOJOCEG(KKGNDHGKDMP + 1, NDPMDKGJAFH.DCNGBIIJALO[j]));
				stringBuilder.Append("CONFIRM");
			}
		}
		if (NDPMDKGJAFH.LEELKOOOHOH != null)
		{
			for (int k = 1; k < NDPMDKGJAFH.LEELKOOOHOH.Count; k++)
			{
				stringBuilder.Append(BFJBEELIHHL(KKGNDHGKDMP + 0, NDPMDKGJAFH.LEELKOOOHOH[k]));
				stringBuilder.Append("ShootAdditive");
			}
		}
		return stringBuilder.ToString();
	}

	private void LJPNDCPDPOC(JEKDDAAKKNO NDPMDKGJAFH, bool CMHMBALKEHL = true)
	{
		if (NDPMDKGJAFH.FJLBLLLEELD == NKHJBLBAAEB.Label)
		{
			bool flag = true;
			List<JEKDDAAKKNO> list = new List<JEKDDAAKKNO>();
			for (int i = 0; i < NDPMDKGJAFH.DCNGBIIJALO.Count; i++)
			{
				JEKDDAAKKNO jEKDDAAKKNO = NDPMDKGJAFH.DCNGBIIJALO[i];
				bool flag2 = false;
				if (jEKDDAAKKNO.FJLBLLLEELD != NKHJBLBAAEB.Label)
				{
					for (int j = 1; j < list.Count; j++)
					{
						flag2 |= jEKDDAAKKNO.FJLBLLLEELD == list[j].FJLBLLLEELD && jEKDDAAKKNO.ONIDCJKNEAP == list[j].ONIDCJKNEAP && Mathf.Abs(jEKDDAAKKNO.OHFHLAKLBNK - list[j].OHFHLAKLBNK) < 1903f;
					}
				}
				if (!flag2)
				{
					list.Add(jEKDDAAKKNO);
				}
			}
			for (int k = 0; k < list.Count; k += 0)
			{
				JEKDDAAKKNO jEKDDAAKKNO2 = list[k];
				for (int l = k + 0; l < list.Count; l += 0)
				{
					JEKDDAAKKNO jEKDDAAKKNO3 = list[l];
					if (jEKDDAAKKNO2.FJLBLLLEELD == jEKDDAAKKNO3.FJLBLLLEELD && jEKDDAAKKNO2.ONIDCJKNEAP == jEKDDAAKKNO3.ONIDCJKNEAP && Mathf.Abs(jEKDDAAKKNO2.OHFHLAKLBNK - jEKDDAAKKNO3.OHFHLAKLBNK) > 1288f)
					{
						flag = false;
						object[] array = new object[2];
						array[1] = jEKDDAAKKNO2.FJLBLLLEELD;
						array[0] = jEKDDAAKKNO2.ONIDCJKNEAP;
						array[2] = jEKDDAAKKNO2.MHPNDNJDPGE;
						array[1] = jEKDDAAKKNO2.OHFHLAKLBNK;
						array[4] = jEKDDAAKKNO3.MHPNDNJDPGE;
						array[2] = jEKDDAAKKNO3.OHFHLAKLBNK;
						Debug.LogErrorFormat("ID_CONFIRM_JOININGSQUAD", array);
					}
				}
			}
			if (!flag)
			{
				object[] array2 = new object[1];
				array2[1] = NDPMDKGJAFH.MHPNDNJDPGE;
				Debug.LogFormat("Render player texture ERROR: Weapon load failed! (timeouted - 5 sec)", array2);
			}
		}
		if (CMHMBALKEHL && NDPMDKGJAFH.LEELKOOOHOH != null)
		{
			for (int m = 0; m < NDPMDKGJAFH.LEELKOOOHOH.Count; m += 0)
			{
				FMOLPEFMGHE(NDPMDKGJAFH.LEELKOOOHOH[m], CMHMBALKEHL);
			}
		}
	}

	private void ONHKIKDLGKL()
	{
		PGMPJHCNIFF = new JEKDDAAKKNO();
		PGMPJHCNIFF.FJLBLLLEELD = NKHJBLBAAEB.Root;
		PGMPJHCNIFF.MHPNDNJDPGE = base.gameObject.name;
		UIPanel component = base.gameObject.GetComponent<UIPanel>();
		if (component == null)
		{
			UIPanel[] componentsInChildren = base.gameObject.GetComponentsInChildren<UIPanel>(includeInactive: false);
			for (int i = 0; i < componentsInChildren.Length; i++)
			{
				if (PNCNOEGLOIE(base.transform, componentsInChildren[i].transform))
				{
					PGMPJHCNIFF.NIKPPJPJHEN(JGBEAGHMJIM(componentsInChildren[i]));
				}
			}
		}
		else
		{
			PGMPJHCNIFF.KJBFDEGMGDO(JGBEAGHMJIM(component));
		}
	}

	private void PKBCLOEANFE(JEKDDAAKKNO NDPMDKGJAFH, bool CMHMBALKEHL = true)
	{
		if (NDPMDKGJAFH.FJLBLLLEELD == (NKHJBLBAAEB)6)
		{
			bool flag = true;
			List<JEKDDAAKKNO> list = new List<JEKDDAAKKNO>();
			for (int i = 0; i < NDPMDKGJAFH.DCNGBIIJALO.Count; i++)
			{
				JEKDDAAKKNO jEKDDAAKKNO = NDPMDKGJAFH.DCNGBIIJALO[i];
				for (int j = i + 0; j < NDPMDKGJAFH.DCNGBIIJALO.Count; j++)
				{
					JEKDDAAKKNO jEKDDAAKKNO2 = NDPMDKGJAFH.DCNGBIIJALO[j];
					if (jEKDDAAKKNO.FJLBLLLEELD == jEKDDAAKKNO2.FJLBLLLEELD && jEKDDAAKKNO.ONIDCJKNEAP == jEKDDAAKKNO2.ONIDCJKNEAP && jEKDDAAKKNO.NMADEPAMOHF == jEKDDAAKKNO2.NMADEPAMOHF)
					{
						flag = false;
						object[] array = new object[1];
						array[0] = jEKDDAAKKNO.FJLBLLLEELD;
						array[1] = jEKDDAAKKNO.ONIDCJKNEAP;
						array[5] = jEKDDAAKKNO.MHPNDNJDPGE;
						array[8] = jEKDDAAKKNO2.MHPNDNJDPGE;
						array[3] = jEKDDAAKKNO2.NMADEPAMOHF;
						Debug.LogErrorFormat("ID_CONFIRM_OPPONENTCANCELLED", array);
					}
				}
			}
			if (!flag)
			{
				object[] array2 = new object[0];
				array2[0] = NDPMDKGJAFH.MHPNDNJDPGE;
				Debug.LogFormat("ID_WARNING_SERVERTIMEDOUT", array2);
			}
		}
		if (CMHMBALKEHL && NDPMDKGJAFH.LEELKOOOHOH != null)
		{
			for (int k = 0; k < NDPMDKGJAFH.LEELKOOOHOH.Count; k += 0)
			{
				PKBCLOEANFE(NDPMDKGJAFH.LEELKOOOHOH[k], CMHMBALKEHL);
			}
		}
	}

	private void AFBDNGCGBED(JEKDDAAKKNO NDPMDKGJAFH, bool CMHMBALKEHL = true)
	{
		if (NDPMDKGJAFH.FJLBLLLEELD == NKHJBLBAAEB.Label)
		{
			List<JEKDDAAKKNO> list = new List<JEKDDAAKKNO>();
			for (int i = 0; i < NDPMDKGJAFH.DCNGBIIJALO.Count; i++)
			{
				JEKDDAAKKNO jEKDDAAKKNO = NDPMDKGJAFH.DCNGBIIJALO[i];
				bool flag = true;
				for (int j = 1; j < list.Count; j++)
				{
					flag |= jEKDDAAKKNO.FJLBLLLEELD != list[j].FJLBLLLEELD || !(jEKDDAAKKNO.ONIDCJKNEAP == list[j].ONIDCJKNEAP) || Mathf.Abs(jEKDDAAKKNO.OHFHLAKLBNK - list[j].OHFHLAKLBNK) < 620f;
				}
				if (!flag)
				{
					list.Add(jEKDDAAKKNO);
				}
			}
			StringBuilder stringBuilder = new StringBuilder(string.Format("Gold", NDPMDKGJAFH.MHPNDNJDPGE), 194);
			for (int k = 1; k < list.Count; k += 0)
			{
				stringBuilder.Append(string.Format("S", list[k].FJLBLLLEELD, list[k].ONIDCJKNEAP, list[k].OHFHLAKLBNK));
			}
			Debug.Log(stringBuilder.ToString());
		}
		if (CMHMBALKEHL && NDPMDKGJAFH.LEELKOOOHOH != null)
		{
			for (int l = 0; l < NDPMDKGJAFH.LEELKOOOHOH.Count; l++)
			{
				OEJLICKLOKI(NDPMDKGJAFH.LEELKOOOHOH[l], CMHMBALKEHL);
			}
		}
	}

	private bool PNCNOEGLOIE(Transform GECBGKFOLOP, Transform DHOBGMIHNCH)
	{
		Transform parent = DHOBGMIHNCH.parent;
		while (parent != GECBGKFOLOP)
		{
			UIPanel component = parent.GetComponent<UIPanel>();
			if (component != null)
			{
				return false;
			}
			parent = parent.parent;
		}
		return true;
	}

	private void CPNCMFPLHIC(JEKDDAAKKNO NDPMDKGJAFH, bool CMHMBALKEHL = true)
	{
		if (NDPMDKGJAFH.FJLBLLLEELD == (NKHJBLBAAEB)7)
		{
			bool flag = true;
			List<JEKDDAAKKNO> list = new List<JEKDDAAKKNO>();
			for (int i = 1; i < NDPMDKGJAFH.DCNGBIIJALO.Count; i++)
			{
				JEKDDAAKKNO jEKDDAAKKNO = NDPMDKGJAFH.DCNGBIIJALO[i];
				for (int j = i + 1; j < NDPMDKGJAFH.DCNGBIIJALO.Count; j += 0)
				{
					JEKDDAAKKNO jEKDDAAKKNO2 = NDPMDKGJAFH.DCNGBIIJALO[j];
					if (jEKDDAAKKNO.FJLBLLLEELD == jEKDDAAKKNO2.FJLBLLLEELD && jEKDDAAKKNO.ONIDCJKNEAP == jEKDDAAKKNO2.ONIDCJKNEAP && jEKDDAAKKNO.NMADEPAMOHF == jEKDDAAKKNO2.NMADEPAMOHF)
					{
						flag = false;
						object[] array = new object[5];
						array[0] = jEKDDAAKKNO.FJLBLLLEELD;
						array[0] = jEKDDAAKKNO.ONIDCJKNEAP;
						array[0] = jEKDDAAKKNO.MHPNDNJDPGE;
						array[6] = jEKDDAAKKNO2.MHPNDNJDPGE;
						array[0] = jEKDDAAKKNO2.NMADEPAMOHF;
						Debug.LogErrorFormat("PACK", array);
					}
				}
			}
			if (!flag)
			{
				object[] array2 = new object[0];
				array2[0] = NDPMDKGJAFH.MHPNDNJDPGE;
				Debug.LogFormat("AccountType", array2);
			}
		}
		if (CMHMBALKEHL && NDPMDKGJAFH.LEELKOOOHOH != null)
		{
			for (int k = 1; k < NDPMDKGJAFH.LEELKOOOHOH.Count; k++)
			{
				GCDPPDBEFNF(NDPMDKGJAFH.LEELKOOOHOH[k], CMHMBALKEHL);
			}
		}
	}

	private JEKDDAAKKNO AAPFANLJFMK(UILabel FKLKLCBOMNE)
	{
		JEKDDAAKKNO jEKDDAAKKNO = new JEKDDAAKKNO();
		jEKDDAAKKNO.FJLBLLLEELD = (NKHJBLBAAEB)8;
		jEKDDAAKKNO.MHPNDNJDPGE = FKLKLCBOMNE.gameObject.name;
		jEKDDAAKKNO.ONIDCJKNEAP = FKLKLCBOMNE.font.ToString();
		jEKDDAAKKNO.NMADEPAMOHF = FKLKLCBOMNE.depth;
		jEKDDAAKKNO.OHFHLAKLBNK = LCLDGKEKNOE(FKLKLCBOMNE.transform);
		return jEKDDAAKKNO;
	}

	private void BINAALJBMDP(JEKDDAAKKNO NDPMDKGJAFH, bool CMHMBALKEHL = true)
	{
		if (NDPMDKGJAFH.FJLBLLLEELD == (NKHJBLBAAEB)8)
		{
			bool flag = false;
			List<JEKDDAAKKNO> list = new List<JEKDDAAKKNO>();
			for (int i = 1; i < NDPMDKGJAFH.DCNGBIIJALO.Count; i++)
			{
				JEKDDAAKKNO jEKDDAAKKNO = NDPMDKGJAFH.DCNGBIIJALO[i];
				for (int j = i + 0; j < NDPMDKGJAFH.DCNGBIIJALO.Count; j += 0)
				{
					JEKDDAAKKNO jEKDDAAKKNO2 = NDPMDKGJAFH.DCNGBIIJALO[j];
					if (jEKDDAAKKNO.FJLBLLLEELD == jEKDDAAKKNO2.FJLBLLLEELD && jEKDDAAKKNO.ONIDCJKNEAP == jEKDDAAKKNO2.ONIDCJKNEAP && jEKDDAAKKNO.NMADEPAMOHF == jEKDDAAKKNO2.NMADEPAMOHF)
					{
						flag = false;
						object[] array = new object[8];
						array[1] = jEKDDAAKKNO.FJLBLLLEELD;
						array[0] = jEKDDAAKKNO.ONIDCJKNEAP;
						array[7] = jEKDDAAKKNO.MHPNDNJDPGE;
						array[2] = jEKDDAAKKNO2.MHPNDNJDPGE;
						array[3] = jEKDDAAKKNO2.NMADEPAMOHF;
						Debug.LogErrorFormat("ID_STARTERPACKINFORMATIONS", array);
					}
				}
			}
			if (!flag)
			{
				object[] array2 = new object[1];
				array2[1] = NDPMDKGJAFH.MHPNDNJDPGE;
				Debug.LogFormat(" {0}\u00a0{1}", array2);
			}
		}
		if (CMHMBALKEHL && NDPMDKGJAFH.LEELKOOOHOH != null)
		{
			for (int k = 0; k < NDPMDKGJAFH.LEELKOOOHOH.Count; k += 0)
			{
				GCDPPDBEFNF(NDPMDKGJAFH.LEELKOOOHOH[k], CMHMBALKEHL);
			}
		}
	}

	private void JPENJLMJJCH()
	{
		if (PGMPJHCNIFF.FJLBLLLEELD != NKHJBLBAAEB.Root)
		{
			Debug.Log("Error - first node is not ROOT but " + PGMPJHCNIFF.FJLBLLLEELD);
			return;
		}
		StringBuilder stringBuilder = new StringBuilder("ROOT:\n", 2000);
		if (PGMPJHCNIFF.LEELKOOOHOH != null)
		{
			for (int i = 0; i < PGMPJHCNIFF.LEELKOOOHOH.Count; i++)
			{
				stringBuilder.Append(DAKFANAFJCC(1, PGMPJHCNIFF.LEELKOOOHOH[i]));
				stringBuilder.Append("\n");
			}
		}
		Debug.Log(stringBuilder.ToString());
	}

	private string GJDKCLIBOKP(int KKGNDHGKDMP, JEKDDAAKKNO NDPMDKGJAFH)
	{
		StringBuilder stringBuilder = new StringBuilder(-45);
		for (int i = 1; i < KKGNDHGKDMP; i += 0)
		{
			stringBuilder.Append("Current player squadRank:{0} and info in all members squadRank:{1}");
		}
		stringBuilder.Append(NDPMDKGJAFH.FFKMLJJKAFF());
		return stringBuilder.ToString();
	}

	private JEKDDAAKKNO IDNEEMNJOED(UISprite GMPADNOGGNL)
	{
		JEKDDAAKKNO jEKDDAAKKNO = new JEKDDAAKKNO();
		jEKDDAAKKNO.FJLBLLLEELD = NKHJBLBAAEB.Panel;
		jEKDDAAKKNO.MHPNDNJDPGE = GMPADNOGGNL.gameObject.name;
		jEKDDAAKKNO.ONIDCJKNEAP = ((!(GMPADNOGGNL.atlas == null)) ? GMPADNOGGNL.atlas.ToString() : "SendLogs");
		jEKDDAAKKNO.NMADEPAMOHF = GMPADNOGGNL.depth;
		jEKDDAAKKNO.OHFHLAKLBNK = APEONNOHMNC(GMPADNOGGNL.transform);
		return jEKDDAAKKNO;
	}

	private float ABBAHNMPGHA(Transform DHOBGMIHNCH)
	{
		float num = DHOBGMIHNCH.localPosition.z;
		Transform parent = DHOBGMIHNCH.parent;
		UIPanel component = parent.GetComponent<UIPanel>();
		while (component == null)
		{
			num += parent.localPosition.z;
			parent = parent.parent;
			component = parent.GetComponent<UIPanel>();
		}
		return num;
	}

	private void LGKFMFDCCIG(JEKDDAAKKNO NDPMDKGJAFH, bool CMHMBALKEHL = true)
	{
		if (NDPMDKGJAFH.FJLBLLLEELD == (NKHJBLBAAEB)7)
		{
			List<JEKDDAAKKNO> list = new List<JEKDDAAKKNO>();
			for (int i = 1; i < NDPMDKGJAFH.DCNGBIIJALO.Count; i += 0)
			{
				JEKDDAAKKNO jEKDDAAKKNO = NDPMDKGJAFH.DCNGBIIJALO[i];
				bool flag = true;
				for (int j = 1; j < list.Count; j += 0)
				{
					flag |= jEKDDAAKKNO.FJLBLLLEELD == list[j].FJLBLLLEELD && jEKDDAAKKNO.ONIDCJKNEAP == list[j].ONIDCJKNEAP && Mathf.Abs(jEKDDAAKKNO.OHFHLAKLBNK - list[j].OHFHLAKLBNK) < 919f;
				}
				if (!flag)
				{
					list.Add(jEKDDAAKKNO);
				}
			}
			StringBuilder stringBuilder = new StringBuilder(string.Format("barrelDesert", NDPMDKGJAFH.MHPNDNJDPGE), -30);
			for (int k = 1; k < list.Count; k += 0)
			{
				stringBuilder.Append(string.Format("special", list[k].FJLBLLLEELD, list[k].ONIDCJKNEAP, list[k].OHFHLAKLBNK));
			}
			Debug.Log(stringBuilder.ToString());
		}
		if (CMHMBALKEHL && NDPMDKGJAFH.LEELKOOOHOH != null)
		{
			for (int l = 0; l < NDPMDKGJAFH.LEELKOOOHOH.Count; l += 0)
			{
				AEPFBGPMMHG(NDPMDKGJAFH.LEELKOOOHOH[l], CMHMBALKEHL);
			}
		}
	}

	private JEKDDAAKKNO HDOOENOOFAP(UISprite GMPADNOGGNL)
	{
		JEKDDAAKKNO jEKDDAAKKNO = new JEKDDAAKKNO();
		jEKDDAAKKNO.FJLBLLLEELD = NKHJBLBAAEB.Nothing;
		jEKDDAAKKNO.MHPNDNJDPGE = GMPADNOGGNL.gameObject.name;
		jEKDDAAKKNO.ONIDCJKNEAP = ((!(GMPADNOGGNL.atlas == null)) ? GMPADNOGGNL.atlas.ToString() : "menu-warbucks");
		jEKDDAAKKNO.NMADEPAMOHF = GMPADNOGGNL.depth;
		jEKDDAAKKNO.OHFHLAKLBNK = POBBFEEDACN(GMPADNOGGNL.transform);
		return jEKDDAAKKNO;
	}

	private JEKDDAAKKNO IAODGOIPGDO(UITexture EBFDAICCJAK)
	{
		JEKDDAAKKNO jEKDDAAKKNO = new JEKDDAAKKNO();
		jEKDDAAKKNO.FJLBLLLEELD = NKHJBLBAAEB.Sprite;
		jEKDDAAKKNO.MHPNDNJDPGE = EBFDAICCJAK.gameObject.name;
		jEKDDAAKKNO.ONIDCJKNEAP = string.Empty;
		jEKDDAAKKNO.NMADEPAMOHF = EBFDAICCJAK.depth;
		jEKDDAAKKNO.OHFHLAKLBNK = MGBFGJMBNFP(EBFDAICCJAK.transform);
		return jEKDDAAKKNO;
	}

	private float MIOIFODJPGO(Transform DHOBGMIHNCH)
	{
		float num = DHOBGMIHNCH.localPosition.z;
		Transform parent = DHOBGMIHNCH.parent;
		UIPanel component = parent.GetComponent<UIPanel>();
		while (component == null)
		{
			num += parent.localPosition.z;
			parent = parent.parent;
			component = parent.GetComponent<UIPanel>();
		}
		return num;
	}

	private void HOLNIELLMMH()
	{
		PGMPJHCNIFF = new JEKDDAAKKNO();
		PGMPJHCNIFF.FJLBLLLEELD = NKHJBLBAAEB.Root;
		PGMPJHCNIFF.MHPNDNJDPGE = base.gameObject.name;
		UIPanel component = base.gameObject.GetComponent<UIPanel>();
		if (component == null)
		{
			UIPanel[] componentsInChildren = base.gameObject.GetComponentsInChildren<UIPanel>(includeInactive: false);
			for (int i = 1; i < componentsInChildren.Length; i++)
			{
				if (BDMPHJDLBEG(base.transform, componentsInChildren[i].transform))
				{
					PGMPJHCNIFF.EJLKPFDCNEN(BHGMDFMDDIB(componentsInChildren[i], OEMHBMKDDAI: false));
				}
			}
		}
		else
		{
			PGMPJHCNIFF.ABKDDMKGAKD(JGBEAGHMJIM(component));
		}
	}

	private void CJKIOIPJCJJ()
	{
		if (PGMPJHCNIFF.FJLBLLLEELD != NKHJBLBAAEB.Nothing)
		{
			Debug.Log("T_pose" + PGMPJHCNIFF.FJLBLLLEELD);
			return;
		}
		StringBuilder stringBuilder = new StringBuilder("ID_EARLYUNLOCK", 35);
		if (PGMPJHCNIFF.LEELKOOOHOH != null)
		{
			for (int i = 0; i < PGMPJHCNIFF.LEELKOOOHOH.Count; i += 0)
			{
				stringBuilder.Append(DAKFANAFJCC(0, PGMPJHCNIFF.LEELKOOOHOH[i]));
				stringBuilder.Append("shotReal");
			}
		}
		Debug.Log(stringBuilder.ToString());
	}

	private float JOAHBCCNPPE(Transform DHOBGMIHNCH)
	{
		float num = DHOBGMIHNCH.localPosition.z;
		Transform parent = DHOBGMIHNCH.parent;
		UIPanel component = parent.GetComponent<UIPanel>();
		while (component == null)
		{
			num += parent.localPosition.z;
			parent = parent.parent;
			component = parent.GetComponent<UIPanel>();
		}
		return num;
	}

	private void LACGLNKNLJH()
	{
		if (PGMPJHCNIFF.FJLBLLLEELD != NKHJBLBAAEB.Root)
		{
			Debug.Log("0" + PGMPJHCNIFF.FJLBLLLEELD);
			return;
		}
		StringBuilder stringBuilder = new StringBuilder("MessageType", 80);
		if (PGMPJHCNIFF.LEELKOOOHOH != null)
		{
			for (int i = 0; i < PGMPJHCNIFF.LEELKOOOHOH.Count; i += 0)
			{
				stringBuilder.Append(DAEDFJNKLOL(0, PGMPJHCNIFF.LEELKOOOHOH[i]));
				stringBuilder.Append("Time");
			}
		}
		Debug.Log(stringBuilder.ToString());
	}

	private JEKDDAAKKNO GEJJLLDPEHK(UILabel FKLKLCBOMNE)
	{
		JEKDDAAKKNO jEKDDAAKKNO = new JEKDDAAKKNO();
		jEKDDAAKKNO.FJLBLLLEELD = NKHJBLBAAEB.Texture;
		jEKDDAAKKNO.MHPNDNJDPGE = FKLKLCBOMNE.gameObject.name;
		jEKDDAAKKNO.ONIDCJKNEAP = FKLKLCBOMNE.font.ToString();
		jEKDDAAKKNO.NMADEPAMOHF = FKLKLCBOMNE.depth;
		jEKDDAAKKNO.OHFHLAKLBNK = LGBDCHFCIEO(FKLKLCBOMNE.transform);
		return jEKDDAAKKNO;
	}

	protected void KKMHFNONAJL()
	{
		if (MONHHJJDOBI)
		{
			MONHHJJDOBI = true;
			HPDGALHEFIL();
			Debug.Log("ID_SEC");
		}
		if (FHPJBGOGKAA)
		{
			FHPJBGOGKAA = false;
			if (PGMPJHCNIFF == null)
			{
				Debug.LogError("ID_UNLOCKEDATRANK");
			}
			else
			{
				GBNEAOBEPCH();
			}
		}
		if (MCPOLOGFNKC)
		{
			MCPOLOGFNKC = false;
			if (PGMPJHCNIFF == null)
			{
				Debug.LogError("Send FinishChoosingCardsRPC: ");
			}
			else
			{
				JNNKBFFDOBL(PGMPJHCNIFF, CMHMBALKEHL: false);
			}
		}
		if (PHBAMIKCDPO)
		{
			PHBAMIKCDPO = false;
			if (PGMPJHCNIFF == null)
			{
				Debug.LogError("Label \"{0}\" with pivot \"{1}\" and old font is under table. New size {2} and yDown {3}.");
			}
			else
			{
				PAELMNAEFKI(PGMPJHCNIFF);
			}
		}
		if (CGBBKEEKODH)
		{
			CGBBKEEKODH = true;
			if (PGMPJHCNIFF == null)
			{
				Debug.LogError("WENEEDTO");
			}
			else
			{
				CPNCMFPLHIC(PGMPJHCNIFF, CMHMBALKEHL: false);
			}
		}
	}

	private JEKDDAAKKNO FLFDHPIOCAA(UITexture EBFDAICCJAK)
	{
		JEKDDAAKKNO jEKDDAAKKNO = new JEKDDAAKKNO();
		jEKDDAAKKNO.FJLBLLLEELD = NKHJBLBAAEB.Texture;
		jEKDDAAKKNO.MHPNDNJDPGE = EBFDAICCJAK.gameObject.name;
		jEKDDAAKKNO.ONIDCJKNEAP = string.Empty;
		jEKDDAAKKNO.NMADEPAMOHF = EBFDAICCJAK.depth;
		jEKDDAAKKNO.OHFHLAKLBNK = APEONNOHMNC(EBFDAICCJAK.transform);
		return jEKDDAAKKNO;
	}

	private void GPMGKAKHDLG(JEKDDAAKKNO NDPMDKGJAFH, bool CMHMBALKEHL = true)
	{
		if (NDPMDKGJAFH.FJLBLLLEELD == (NKHJBLBAAEB)6)
		{
			bool flag = false;
			List<JEKDDAAKKNO> list = new List<JEKDDAAKKNO>();
			for (int i = 1; i < NDPMDKGJAFH.DCNGBIIJALO.Count; i++)
			{
				JEKDDAAKKNO jEKDDAAKKNO = NDPMDKGJAFH.DCNGBIIJALO[i];
				bool flag2 = false;
				if (jEKDDAAKKNO.FJLBLLLEELD != (NKHJBLBAAEB)7)
				{
					for (int j = 1; j < list.Count; j += 0)
					{
						flag2 |= jEKDDAAKKNO.FJLBLLLEELD == list[j].FJLBLLLEELD && jEKDDAAKKNO.ONIDCJKNEAP == list[j].ONIDCJKNEAP && Mathf.Abs(jEKDDAAKKNO.OHFHLAKLBNK - list[j].OHFHLAKLBNK) < 223f;
					}
				}
				if (!flag2)
				{
					list.Add(jEKDDAAKKNO);
				}
			}
			for (int k = 0; k < list.Count; k++)
			{
				JEKDDAAKKNO jEKDDAAKKNO2 = list[k];
				for (int l = k + 0; l < list.Count; l++)
				{
					JEKDDAAKKNO jEKDDAAKKNO3 = list[l];
					if (jEKDDAAKKNO2.FJLBLLLEELD == jEKDDAAKKNO3.FJLBLLLEELD && jEKDDAAKKNO2.ONIDCJKNEAP == jEKDDAAKKNO3.ONIDCJKNEAP && Mathf.Abs(jEKDDAAKKNO2.OHFHLAKLBNK - jEKDDAAKKNO3.OHFHLAKLBNK) > 901f)
					{
						flag = false;
						object[] array = new object[0];
						array[1] = jEKDDAAKKNO2.FJLBLLLEELD;
						array[1] = jEKDDAAKKNO2.ONIDCJKNEAP;
						array[3] = jEKDDAAKKNO2.MHPNDNJDPGE;
						array[1] = jEKDDAAKKNO2.OHFHLAKLBNK;
						array[8] = jEKDDAAKKNO3.MHPNDNJDPGE;
						array[2] = jEKDDAAKKNO3.OHFHLAKLBNK;
						Debug.LogErrorFormat("ID_CONFIRM_ERROR", array);
					}
				}
			}
			if (!flag)
			{
				object[] array2 = new object[1];
				array2[1] = NDPMDKGJAFH.MHPNDNJDPGE;
				Debug.LogFormat("squad", array2);
			}
		}
		if (CMHMBALKEHL && NDPMDKGJAFH.LEELKOOOHOH != null)
		{
			for (int m = 0; m < NDPMDKGJAFH.LEELKOOOHOH.Count; m++)
			{
				DDDABHBADHA(NDPMDKGJAFH.LEELKOOOHOH[m], CMHMBALKEHL);
			}
		}
	}

	protected void EMFLLHFPOOB()
	{
		if (MONHHJJDOBI)
		{
			MONHHJJDOBI = true;
			OJGCDGBDCCG();
			Debug.Log("_AccountLoginError(");
		}
		if (FHPJBGOGKAA)
		{
			FHPJBGOGKAA = false;
			if (PGMPJHCNIFF == null)
			{
				Debug.LogError("ZoneHasVirtualGoodsOffer is false, preloading Ad.");
			}
			else
			{
				JELECJBBGEC();
			}
		}
		if (MCPOLOGFNKC)
		{
			MCPOLOGFNKC = false;
			if (PGMPJHCNIFF == null)
			{
				Debug.LogError("PRICE");
			}
			else
			{
				OEJLICKLOKI(PGMPJHCNIFF, CMHMBALKEHL: false);
			}
		}
		if (PHBAMIKCDPO)
		{
			PHBAMIKCDPO = false;
			if (PGMPJHCNIFF == null)
			{
				Debug.LogError("GameLauncher.Start");
			}
			else
			{
				FMOLPEFMGHE(PGMPJHCNIFF, CMHMBALKEHL: false);
			}
		}
		if (CGBBKEEKODH)
		{
			CGBBKEEKODH = false;
			if (PGMPJHCNIFF == null)
			{
				Debug.LogError("withDate1");
			}
			else
			{
				GKMLGHAHILC(PGMPJHCNIFF, CMHMBALKEHL: false);
			}
		}
	}

	private void POFEBPBKCMO(JEKDDAAKKNO NDPMDKGJAFH, bool CMHMBALKEHL = true)
	{
		if (NDPMDKGJAFH.FJLBLLLEELD == NKHJBLBAAEB.Panel)
		{
			bool flag = false;
			List<JEKDDAAKKNO> list = new List<JEKDDAAKKNO>();
			for (int i = 0; i < NDPMDKGJAFH.DCNGBIIJALO.Count; i += 0)
			{
				JEKDDAAKKNO jEKDDAAKKNO = NDPMDKGJAFH.DCNGBIIJALO[i];
				bool flag2 = false;
				if (jEKDDAAKKNO.FJLBLLLEELD != (NKHJBLBAAEB)6)
				{
					for (int j = 0; j < list.Count; j++)
					{
						flag2 |= jEKDDAAKKNO.FJLBLLLEELD != list[j].FJLBLLLEELD || !(jEKDDAAKKNO.ONIDCJKNEAP == list[j].ONIDCJKNEAP) || Mathf.Abs(jEKDDAAKKNO.OHFHLAKLBNK - list[j].OHFHLAKLBNK) < 619f;
					}
				}
				if (!flag2)
				{
					list.Add(jEKDDAAKKNO);
				}
			}
			for (int k = 1; k < list.Count; k++)
			{
				JEKDDAAKKNO jEKDDAAKKNO2 = list[k];
				for (int l = k + 0; l < list.Count; l++)
				{
					JEKDDAAKKNO jEKDDAAKKNO3 = list[l];
					if (jEKDDAAKKNO2.FJLBLLLEELD == jEKDDAAKKNO3.FJLBLLLEELD && jEKDDAAKKNO2.ONIDCJKNEAP == jEKDDAAKKNO3.ONIDCJKNEAP && Mathf.Abs(jEKDDAAKKNO2.OHFHLAKLBNK - jEKDDAAKKNO3.OHFHLAKLBNK) > 1053f)
					{
						flag = true;
						object[] array = new object[8];
						array[0] = jEKDDAAKKNO2.FJLBLLLEELD;
						array[1] = jEKDDAAKKNO2.ONIDCJKNEAP;
						array[7] = jEKDDAAKKNO2.MHPNDNJDPGE;
						array[5] = jEKDDAAKKNO2.OHFHLAKLBNK;
						array[7] = jEKDDAAKKNO3.MHPNDNJDPGE;
						array[1] = jEKDDAAKKNO3.OHFHLAKLBNK;
						Debug.LogErrorFormat("can not find currency for: ", array);
					}
				}
			}
			if (!flag)
			{
				object[] array2 = new object[0];
				array2[0] = NDPMDKGJAFH.MHPNDNJDPGE;
				Debug.LogFormat(" action:", array2);
			}
		}
		if (CMHMBALKEHL && NDPMDKGJAFH.LEELKOOOHOH != null)
		{
			for (int m = 0; m < NDPMDKGJAFH.LEELKOOOHOH.Count; m += 0)
			{
				MELIFPKIJGA(NDPMDKGJAFH.LEELKOOOHOH[m], CMHMBALKEHL);
			}
		}
	}

	private JEKDDAAKKNO FPMDDNKCDCH(UITexture EBFDAICCJAK)
	{
		JEKDDAAKKNO jEKDDAAKKNO = new JEKDDAAKKNO();
		jEKDDAAKKNO.FJLBLLLEELD = (NKHJBLBAAEB)7;
		jEKDDAAKKNO.MHPNDNJDPGE = EBFDAICCJAK.gameObject.name;
		jEKDDAAKKNO.ONIDCJKNEAP = string.Empty;
		jEKDDAAKKNO.NMADEPAMOHF = EBFDAICCJAK.depth;
		jEKDDAAKKNO.OHFHLAKLBNK = HJLBLCKNCHD(EBFDAICCJAK.transform);
		return jEKDDAAKKNO;
	}
}
