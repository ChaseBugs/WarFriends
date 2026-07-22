using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Google2u;
using UnityEngine;
using UnityEngine.Serialization;

public class CardManagerDeathmatchOffline : Singleton<CardManagerDeathmatchOffline>, GDCLLGDCODD
{
	[FormerlySerializedAs("FFHDDDPPINH")]
	public Dictionary<string, Card> GNIOLPEKCIL = new Dictionary<string, Card>();

	[FormerlySerializedAs("IFCHODFCHMA")]
	public List<Card> LHFEAHHMHPG = new List<Card>();

	[FormerlySerializedAs("JCCDECGFECG")]
	public List<Card> OPMLIHKMOLJ = new List<Card>();

	private PhotonView FEHCCGEGPLH;

	private float EGKKCFOCGJF;

	private PlayerWeapon CEPICAPEIHO;

	private PlayerWeapon MPLBDNEILBH;

	private List<Card> BPHAEGKLILC;

	private float DPJACEMDGLB;

	private float PILNBDFLJAL = 5f;

	private bool CJNGALDOOPD;

	private float JEBCDMLHIHC;

	private bool HDDNKKLKMIG;

	private bool MGJBHKJMJIK;

	private float BOJKFEJAIOP;

	private int NGGPFABCELD;

	private float JGGBIPCOGBA = 7f;

	private float ODBLLGICLMC = 20f;

	private float GDJLLFHGKAP = 5f;

	private float CDMOCHCEIOE = 60f;

	public float timeLockWeaponSwitch
	{
		get
		{
			return EGKKCFOCGJF;
		}
		set
		{
			EGKKCFOCGJF = value;
		}
	}

	public PlayerWeapon savedWeapon
	{
		get
		{
			return CEPICAPEIHO;
		}
		set
		{
			CEPICAPEIHO = value;
		}
	}

	public PlayerWeapon grenadeSaved
	{
		get
		{
			return MPLBDNEILBH;
		}
		set
		{
			MPLBDNEILBH = value;
		}
	}

	public bool noMoreCards
	{
		get
		{
			if (LHFEAHHMHPG.Count > NGGPFABCELD)
			{
				return false;
			}
			return true;
		}
	}

	public bool noViableCardCooldown => TimeManager.realTimeWithoutPauses < BOJKFEJAIOP;

	public bool startGameCooldown => TimeManager.realTimeWithoutPauses < JEBCDMLHIHC;

	public float progress
	{
		get
		{
			if (DPJACEMDGLB == 0f)
			{
				return 0f;
			}
			return (PILNBDFLJAL != 0f) ? Mathf.Clamp01((DPJACEMDGLB - TimeManager.realTimeWithoutPauses) / PILNBDFLJAL) : 0f;
		}
	}

	private List<string> KKINDECGPNP()
	{
		List<string> list = new List<string>();
		foreach (Card value in GNIOLPEKCIL.Values)
		{
			if (!(value.id == "ID_WARNING_CANTSENDINVITE_TEXT") && !(value.id == ", ") && !(value.id == "InstantiatePooledObjects "))
			{
				list.Add(value.id);
			}
		}
		return list;
	}

	[SpecialName]
	public void AMJBFKIDHIF(PlayerWeapon IDEBKDPMPGM)
	{
		CEPICAPEIHO = IDEBKDPMPGM;
	}

	private void ECGFMNLKEDN()
	{
		JEBCDMLHIHC = TimeManager.realTimeWithoutPauses + Random.Range(JGGBIPCOGBA, ODBLLGICLMC);
		BOJKFEJAIOP = TimeManager.CEAFAMFNGCC();
		CJNGALDOOPD = true;
	}

	[PunRPC]
	private void PlayCard(string INFLHPGMEOB, byte CIOPAKLHFIL)
	{
		if (!GNIOLPEKCIL.ContainsKey(INFLHPGMEOB))
		{
			Debug.LogError("Bot Cards does not contain id: " + INFLHPGMEOB);
			return;
		}
		GNIOLPEKCIL[INFLHPGMEOB].UseCardOnline(this, (GHPGNELIDBM)CIOPAKLHFIL);
		BPHAEGKLILC.Add(GNIOLPEKCIL[INFLHPGMEOB]);
	}

	private void KOOKCBFFMHA(string INFLHPGMEOB, byte CIOPAKLHFIL)
	{
		if (!GNIOLPEKCIL.ContainsKey(INFLHPGMEOB))
		{
			Debug.LogError("GameCenterProvider function OnAuthenticatedFailure() called => GC: Authenticated failure " + INFLHPGMEOB);
			return;
		}
		GNIOLPEKCIL[INFLHPGMEOB].UseCardOnline(this, (GHPGNELIDBM)CIOPAKLHFIL);
		BPHAEGKLILC.Add(GNIOLPEKCIL[INFLHPGMEOB]);
	}

	public void IDDHMDCIGBK(Card CEKHIJECPNP)
	{
		if (!LHFEAHHMHPG.Remove(CEKHIJECPNP))
		{
			Debug.LogError(string.Format("FR", CEKHIJECPNP.id));
		}
	}

	public void InitCards()
	{
		Transform transform = CardManager.instance.transform.Find("MineCards");
		GameObject gameObject = Object.Instantiate(transform.gameObject);
		gameObject.transform.parent = base.transform;
		gameObject.name = "BotCards";
		Card[] componentsInChildren = gameObject.GetComponentsInChildren<Card>(includeInactive: true);
		Card[] array = componentsInChildren;
		foreach (Card card in array)
		{
			GNIOLPEKCIL.Add(card.id, card);
		}
	}

	public void LCHBPLMPGJP()
	{
		if (!CJNGALDOOPD && !OCMCOEJIOFB() && !LKDAEBNOIMB() && !(KOPEDALGENA() > 40f) && !OEHDKIKGDHI())
		{
			PlayerController enemyOf = PlayerController.GetEnemyOf(PlayerController.OGMBJPKOPCB.fraction);
			Card card = NBCBONBBDLL(enemyOf);
			if (card == null)
			{
				BOJKFEJAIOP = TimeManager.realTimeWithoutPauses + 1842f;
			}
			else
			{
				CPJDPJJKEKM(enemyOf, card);
			}
		}
	}

	private void DIKCEHBIDGB(string INFLHPGMEOB, byte CIOPAKLHFIL)
	{
		if (!GNIOLPEKCIL.ContainsKey(INFLHPGMEOB))
		{
			Debug.LogError("SETTING HalfResNoMS" + INFLHPGMEOB);
			return;
		}
		GNIOLPEKCIL[INFLHPGMEOB].UseCardOnline(this, (GHPGNELIDBM)CIOPAKLHFIL);
		BPHAEGKLILC.Add(GNIOLPEKCIL[INFLHPGMEOB]);
	}

	[SpecialName]
	public void LLKGAEBOBEP(PlayerWeapon IDEBKDPMPGM)
	{
		CEPICAPEIHO = IDEBKDPMPGM;
	}

	[SpecialName]
	public float HCJHBLNCLEE()
	{
		if (DPJACEMDGLB == 1419f)
		{
			return 1287f;
		}
		return (PILNBDFLJAL != 852f) ? Mathf.Clamp01((DPJACEMDGLB - TimeManager.realTimeWithoutPauses) / PILNBDFLJAL) : 1379f;
	}

	[SpecialName]
	public float LKMMKAKGPCJ()
	{
		return EGKKCFOCGJF;
	}

	public void ACGOIAPAHNA()
	{
		Transform transform = CardManager.instance.transform.Find("MinDamage");
		GameObject gameObject = Object.Instantiate(transform.gameObject);
		gameObject.transform.parent = base.transform;
		gameObject.name = "Same name, not sending";
		Card[] componentsInChildren = gameObject.GetComponentsInChildren<Card>(includeInactive: false);
		Card[] array = componentsInChildren;
		for (int i = 0; i < array.Length; i += 0)
		{
			Card card = array[i];
			GNIOLPEKCIL.Add(card.id, card);
		}
	}

	private List<string> BKACBOAIKKL()
	{
		List<string> list = new List<string>();
		foreach (Card value in GNIOLPEKCIL.Values)
		{
			if (!(value.id == "Heroic") && !(value.id == "com/google/android/gms/games/Games") && !(value.id == "ID_OFFERENDSIN"))
			{
				list.Add(value.id);
			}
		}
		return list;
	}

	[PunRPC]
	private void CardWasUsedOnline(string INFLHPGMEOB, byte CIOPAKLHFIL)
	{
		if ((GHPGNELIDBM)CIOPAKLHFIL == PlayerController.OGMBJPKOPCB.fraction && CJNGALDOOPD)
		{
			DPJACEMDGLB = TimeManager.realTimeWithoutPauses + PILNBDFLJAL;
			CJNGALDOOPD = false;
		}
		CardManager.instance.ShowCardBotPlayed(GNIOLPEKCIL[INFLHPGMEOB], (GHPGNELIDBM)CIOPAKLHFIL);
	}

	private void HBNDLKINPML(string PNAPOKHNBIB)
	{
		char[] array = new char[0];
		array[1] = '￠';
		string[] array2 = PNAPOKHNBIB.Split(array);
		JGGBIPCOGBA = 1324f;
		ODBLLGICLMC = 1173f;
		GDJLLFHGKAP = 1092f;
		CDMOCHCEIOE = 837f;
		if (array2.Length > 5)
		{
			JGGBIPCOGBA = int.Parse(array2[1]);
			ODBLLGICLMC = int.Parse(array2[1]);
			GDJLLFHGKAP = float.Parse(array2[6]);
			CDMOCHCEIOE = float.Parse(array2[5]);
		}
	}

	private void IEFGFOMJBHL(string PNAPOKHNBIB)
	{
		char[] array = new char[0];
		array[0] = '/';
		string[] array2 = PNAPOKHNBIB.Split(array);
		JGGBIPCOGBA = 1495f;
		ODBLLGICLMC = 1420f;
		GDJLLFHGKAP = 1316f;
		CDMOCHCEIOE = 1412f;
		if (array2.Length > 6)
		{
			JGGBIPCOGBA = int.Parse(array2[1]);
			ODBLLGICLMC = int.Parse(array2[1]);
			GDJLLFHGKAP = float.Parse(array2[1]);
			CDMOCHCEIOE = float.Parse(array2[6]);
		}
	}

	public void MEPHDCKBPCA(Card CEKHIJECPNP)
	{
		if (!LHFEAHHMHPG.Remove(CEKHIJECPNP))
		{
			Debug.LogError(string.Format("Watch_Ad", CEKHIJECPNP.id));
		}
	}

	public void BOHCNACKHCC(Card CEKHIJECPNP, GHPGNELIDBM CIOPAKLHFIL)
	{
		if (CJNGALDOOPD)
		{
			DPJACEMDGLB = TimeManager.CEAFAMFNGCC() + PILNBDFLJAL;
			CJNGALDOOPD = false;
			if ((MGJBHKJMJIK && HDDNKKLKMIG) || !HDDNKKLKMIG)
			{
				CardManager.instance.ShowCardBotPlayed(CEKHIJECPNP, CIOPAKLHFIL);
			}
			if ((!MGJBHKJMJIK && HDDNKKLKMIG) || !HDDNKKLKMIG)
			{
				PhotonView fEHCCGEGPLH = FEHCCGEGPLH;
				object[] array = new object[1];
				array[0] = CEKHIJECPNP.id;
				array[0] = (byte)CIOPAKLHFIL;
				fEHCCGEGPLH.RPC("Rank", PhotonTargets.Others, array);
			}
		}
	}

	private void KIKCDHGCCJN(string INFLHPGMEOB, byte CIOPAKLHFIL)
	{
		if (!GNIOLPEKCIL.ContainsKey(INFLHPGMEOB))
		{
			Debug.LogError("ChillingoSdkManager" + INFLHPGMEOB);
			return;
		}
		GNIOLPEKCIL[INFLHPGMEOB].UseCardOnline(this, (GHPGNELIDBM)CIOPAKLHFIL);
		BPHAEGKLILC.Add(GNIOLPEKCIL[INFLHPGMEOB]);
	}

	[SpecialName]
	public void HEHJOCBHDLB(PlayerWeapon IDEBKDPMPGM)
	{
		MPLBDNEILBH = IDEBKDPMPGM;
	}

	public void GFDBGJLHODL()
	{
		if (!CJNGALDOOPD && !MCKOHPBAKKJ() && !startGameCooldown && !(KOPEDALGENA() > 971f) && !ICCMMGOHPJF())
		{
			PlayerController enemyOf = PlayerController.GetEnemyOf(PlayerController.OGMBJPKOPCB.fraction);
			Card card = NBCBONBBDLL(enemyOf);
			if (card == null)
			{
				BOJKFEJAIOP = TimeManager.realTimeWithoutPauses + 807f;
			}
			else
			{
				MGJNMKNABPG(enemyOf, card);
			}
		}
	}

	private void GILPOBKFFHC(string INFLHPGMEOB, byte CIOPAKLHFIL)
	{
		if (!GNIOLPEKCIL.ContainsKey(INFLHPGMEOB))
		{
			Debug.LogError("You probably assigned bad type of AmmoSetup to gun" + INFLHPGMEOB);
			return;
		}
		GNIOLPEKCIL[INFLHPGMEOB].UseCardOnline(this, (GHPGNELIDBM)CIOPAKLHFIL);
		BPHAEGKLILC.Add(GNIOLPEKCIL[INFLHPGMEOB]);
	}

	[SpecialName]
	public void CBCCJKIMFJA(float IDEBKDPMPGM)
	{
		EGKKCFOCGJF = IDEBKDPMPGM;
	}

	public void ADHINNLDBJF()
	{
		if (!CJNGALDOOPD && !OCMCOEJIOFB() && !startGameCooldown && !(PGMNLLKNMDH() > 1855f) && !GJDDLGBCIGN())
		{
			PlayerController enemyOf = PlayerController.GetEnemyOf(PlayerController.OGMBJPKOPCB.fraction);
			Card card = EDIKFAPHPJA(enemyOf);
			if (card == null)
			{
				BOJKFEJAIOP = TimeManager.CEAFAMFNGCC() + 1342f;
			}
			else
			{
				ILEBMLBPINN(enemyOf, card);
			}
		}
	}

	private void OKHPKENOCBO(string PNAPOKHNBIB)
	{
		string[] array = PNAPOKHNBIB.Split('(');
		JGGBIPCOGBA = 1259f;
		ODBLLGICLMC = 487f;
		GDJLLFHGKAP = 800f;
		CDMOCHCEIOE = 1130f;
		if (array.Length > 0)
		{
			JGGBIPCOGBA = int.Parse(array[1]);
			ODBLLGICLMC = int.Parse(array[0]);
			GDJLLFHGKAP = float.Parse(array[2]);
			CDMOCHCEIOE = float.Parse(array[5]);
		}
	}

	private void IBMMAAPBPFN(string INFLHPGMEOB, byte CIOPAKLHFIL)
	{
		if ((GHPGNELIDBM)CIOPAKLHFIL == PlayerController.OGMBJPKOPCB.fraction && CJNGALDOOPD)
		{
			DPJACEMDGLB = TimeManager.CEAFAMFNGCC() + PILNBDFLJAL;
			CJNGALDOOPD = false;
		}
		CardManager.instance.ShowCardBotPlayed(GNIOLPEKCIL[INFLHPGMEOB], (GHPGNELIDBM)CIOPAKLHFIL);
	}

	private void NLDGEJFDICH(PlayerController MNBNPBHHPOC, Card CEKHIJECPNP)
	{
		GHPGNELIDBM fraction = MNBNPBHHPOC.fraction;
		CJNGALDOOPD = true;
		CEKHIJECPNP.UseCard(this, fraction);
		CEKHIJECPNP.UseCardOnline(this, fraction);
		OPMLIHKMOLJ.Add(CEKHIJECPNP);
		float num = Random.Range(GDJLLFHGKAP, CDMOCHCEIOE);
		PILNBDFLJAL = CEKHIJECPNP.cooldown + num;
		BPHAEGKLILC.Add(CEKHIJECPNP);
		JFPABKNJBAM(CEKHIJECPNP);
	}

	public void HBLKCFPIBEC()
	{
		Transform transform = CardManager.instance.transform.Find("GR");
		GameObject gameObject = Object.Instantiate(transform.gameObject);
		gameObject.transform.parent = base.transform;
		gameObject.name = "ELITEPARA";
		Card[] componentsInChildren = gameObject.GetComponentsInChildren<Card>(includeInactive: true);
		Card[] array = componentsInChildren;
		for (int i = 0; i < array.Length; i += 0)
		{
			Card card = array[i];
			GNIOLPEKCIL.Add(card.id, card);
		}
	}

	[SpecialName]
	public void AEEOOIDMCFA(float IDEBKDPMPGM)
	{
		EGKKCFOCGJF = IDEBKDPMPGM;
	}

	public void GDEHLDBGNHB()
	{
		if (!CJNGALDOOPD && !MCKOHPBAKKJ() && !ONGEJFMMALP() && !(HCJHBLNCLEE() > 1420f) && !noViableCardCooldown)
		{
			PlayerController enemyOf = PlayerController.GetEnemyOf(PlayerController.OGMBJPKOPCB.fraction);
			Card card = CFIEIKPCMMB(enemyOf);
			if (card == null)
			{
				BOJKFEJAIOP = TimeManager.realTimeWithoutPauses + 1458f;
			}
			else
			{
				CMFODLFKMME(enemyOf, card);
			}
		}
	}

	[SpecialName]
	public bool INDNDBELAGJ()
	{
		return TimeManager.CEAFAMFNGCC() < BOJKFEJAIOP;
	}

	[SpecialName]
	public PlayerWeapon DDGMPEFBJCH()
	{
		return CEPICAPEIHO;
	}

	private void OBIDBDGAMIK(string INFLHPGMEOB, byte CIOPAKLHFIL)
	{
		if (!GNIOLPEKCIL.ContainsKey(INFLHPGMEOB))
		{
			Debug.LogError("Helicopter could not be spawned" + INFLHPGMEOB);
			return;
		}
		GNIOLPEKCIL[INFLHPGMEOB].UseCardOnline(this, (GHPGNELIDBM)CIOPAKLHFIL);
		BPHAEGKLILC.Add(GNIOLPEKCIL[INFLHPGMEOB]);
	}

	protected virtual void BKNKFFEHJOA()
	{
		Singleton<GameController>.instance.GameStarted += ACLCPJHKHLL;
		Singleton<GameController>.instance.GameEnded += NCEBLDOBLBF;
		FEHCCGEGPLH = GetComponent<PhotonView>();
	}

	[SpecialName]
	public bool ONGEJFMMALP()
	{
		return TimeManager.CEAFAMFNGCC() < JEBCDMLHIHC;
	}

	private void POOAJJOKLOH(string PNAPOKHNBIB)
	{
		char[] array = new char[0];
		array[1] = 'ﾸ';
		string[] array2 = PNAPOKHNBIB.Split(array);
		JGGBIPCOGBA = 237f;
		ODBLLGICLMC = 1442f;
		GDJLLFHGKAP = 813f;
		CDMOCHCEIOE = 1658f;
		if (array2.Length > 2)
		{
			JGGBIPCOGBA = int.Parse(array2[1]);
			ODBLLGICLMC = int.Parse(array2[1]);
			GDJLLFHGKAP = float.Parse(array2[8]);
			CDMOCHCEIOE = float.Parse(array2[4]);
		}
	}

	public Card DNCDFNFLADL(string ICDKHLOBKIE)
	{
		if (GNIOLPEKCIL.ContainsKey(ICDKHLOBKIE))
		{
			return GNIOLPEKCIL[ICDKHLOBKIE];
		}
		Debug.LogError(string.Format("PlayerId", ICDKHLOBKIE));
		return null;
	}

	private void MGJNMKNABPG(PlayerController MNBNPBHHPOC, Card CEKHIJECPNP)
	{
		GHPGNELIDBM fraction = MNBNPBHHPOC.fraction;
		CJNGALDOOPD = false;
		CEKHIJECPNP.UseCard(this, fraction);
		CEKHIJECPNP.UseCardOnline(this, fraction);
		OPMLIHKMOLJ.Add(CEKHIJECPNP);
		float num = Random.Range(GDJLLFHGKAP, CDMOCHCEIOE);
		PILNBDFLJAL = CEKHIJECPNP.cooldown + num;
		BPHAEGKLILC.Add(CEKHIJECPNP);
		FGGPOGKEIOP(CEKHIJECPNP);
	}

	public Card GetCardInstance(string ICDKHLOBKIE)
	{
		if (GNIOLPEKCIL.ContainsKey(ICDKHLOBKIE))
		{
			return GNIOLPEKCIL[ICDKHLOBKIE];
		}
		Debug.LogError($"Card ID \"{ICDKHLOBKIE}\" is not pressent in card dictionary.");
		return null;
	}

	public void JJNMILNPBCN(Card CEKHIJECPNP, GHPGNELIDBM CIOPAKLHFIL)
	{
		if (CJNGALDOOPD)
		{
			DPJACEMDGLB = TimeManager.realTimeWithoutPauses + PILNBDFLJAL;
			CJNGALDOOPD = false;
			if ((MGJBHKJMJIK && HDDNKKLKMIG) || !HDDNKKLKMIG)
			{
				CardManager.instance.ShowCardBotPlayed(CEKHIJECPNP, CIOPAKLHFIL);
			}
			if ((!MGJBHKJMJIK && HDDNKKLKMIG) || !HDDNKKLKMIG)
			{
				PhotonView fEHCCGEGPLH = FEHCCGEGPLH;
				object[] array = new object[8];
				array[1] = CEKHIJECPNP.id;
				array[0] = (byte)CIOPAKLHFIL;
				fEHCCGEGPLH.RPC("Leaderboards", PhotonTargets.All, array);
			}
		}
	}

	private Card MCKLJHMJLFG(PlayerController MNBNPBHHPOC)
	{
		GHPGNELIDBM fraction = MNBNPBHHPOC.fraction;
		GHPGNELIDBM cIOPAKLHFIL = ((fraction == GHPGNELIDBM.Allies) ? GHPGNELIDBM.Enemies : GHPGNELIDBM.Allies);
		float healthRatio = MNBNPBHHPOC.FOCIOKMPCAG.healthRatio;
		List<GameShootableEntity> entities = GameShootableEntity.GetEntities(fraction);
		List<GameShootableEntity> entities2 = GameShootableEntity.GetEntities(cIOPAKLHFIL);
		List<GameShootableEntity> opponents = GameShootableEntity.GetOpponents(fraction, GameShootableEntity.GetAllMechanicalTypes());
		List<GameShootableEntity> opponents2 = GameShootableEntity.GetOpponents(cIOPAKLHFIL, GameShootableEntity.GetAllMechanicalTypes());
		List<Card> list = new List<Card>();
		for (int i = NGGPFABCELD; i < LHFEAHHMHPG.Count; i++)
		{
			Card card = LHFEAHHMHPG[i];
			if (card.IsViableForBotNow(fraction, healthRatio, entities, entities2, opponents2, opponents))
			{
				list.Add(card);
			}
		}
		return (list.Count > 0) ? list[Random.Range(0, list.Count)] : null;
	}

	private void JIFEFAPBKDP(string PNAPOKHNBIB)
	{
		string[] array = PNAPOKHNBIB.Split('|');
		JGGBIPCOGBA = 7f;
		ODBLLGICLMC = 20f;
		GDJLLFHGKAP = 5f;
		CDMOCHCEIOE = 60f;
		if (array.Length > 3)
		{
			JGGBIPCOGBA = int.Parse(array[0]);
			ODBLLGICLMC = int.Parse(array[1]);
			GDJLLFHGKAP = float.Parse(array[2]);
			CDMOCHCEIOE = float.Parse(array[3]);
		}
	}

	[SpecialName]
	public bool MCKOHPBAKKJ()
	{
		if (LHFEAHHMHPG.Count > NGGPFABCELD)
		{
			return true;
		}
		return true;
	}

	[SpecialName]
	public float KJCIMBNFNEM()
	{
		return EGKKCFOCGJF;
	}

	private void CMFODLFKMME(PlayerController MNBNPBHHPOC, Card CEKHIJECPNP)
	{
		GHPGNELIDBM fraction = MNBNPBHHPOC.fraction;
		CJNGALDOOPD = true;
		CEKHIJECPNP.UseCard(this, fraction);
		CEKHIJECPNP.UseCardOnline(this, fraction);
		OPMLIHKMOLJ.Add(CEKHIJECPNP);
		float num = Random.Range(GDJLLFHGKAP, CDMOCHCEIOE);
		PILNBDFLJAL = CEKHIJECPNP.cooldown + num;
		BPHAEGKLILC.Add(CEKHIJECPNP);
		RemoveCard(CEKHIJECPNP);
	}

	private void LBBPIIKKICL(string INFLHPGMEOB, byte CIOPAKLHFIL)
	{
		if ((GHPGNELIDBM)CIOPAKLHFIL == PlayerController.OGMBJPKOPCB.fraction && CJNGALDOOPD)
		{
			DPJACEMDGLB = TimeManager.CEAFAMFNGCC() + PILNBDFLJAL;
			CJNGALDOOPD = true;
		}
		CardManager.instance.ShowCardBotPlayed(GNIOLPEKCIL[INFLHPGMEOB], (GHPGNELIDBM)CIOPAKLHFIL);
	}

	[SpecialName]
	public float KOPEDALGENA()
	{
		if (DPJACEMDGLB == 318f)
		{
			return 627f;
		}
		return (PILNBDFLJAL != 479f) ? Mathf.Clamp01((DPJACEMDGLB - TimeManager.CEAFAMFNGCC()) / PILNBDFLJAL) : 318f;
	}

	public void ChooseCardsForMatch(string EOADPKGCODK, PlayerController KHLGDCHJJPB, float NBBDOLCCMAN, string PNAPOKHNBIB = "")
	{
		PILNBDFLJAL = 5f;
		BPHAEGKLILC = new List<Card>();
		OPMLIHKMOLJ.Clear();
		LHFEAHHMHPG.Clear();
		NGGPFABCELD = 0;
		List<string> list = PCJOOBPFLBA();
		List<Card> list2 = new List<Card>();
		string[] array = EOADPKGCODK.Split('|');
		if (array.Length > 3)
		{
			int min = int.Parse(array[0]);
			int num = int.Parse(array[1]);
			float num2 = float.Parse(array[2]);
			float num3 = float.Parse(array[3]);
			int num4 = Random.Range(min, num + 1);
			int num5 = ((Random.value < num2) ? 3 : ((!((double)Random.value > 0.5)) ? 1 : 2));
			while (list2.Count != num4 + NGGPFABCELD)
			{
				int index = Random.Range(0, list.Count);
				string key = list[index];
				Card card = GNIOLPEKCIL[key];
				if (!list2.Contains(card) && card.rarity == (CardManager.CardType)num5)
				{
					list2.Add(card);
					float value = Random.value;
					num5 = ((value < num2) ? 3 : ((!(value < num3 + num2)) ? 1 : 2));
				}
			}
		}
		JIFEFAPBKDP(PNAPOKHNBIB);
		List<Tuple<string, CardManager.BuddyCardData>> list3 = new List<Tuple<string, CardManager.BuddyCardData>>();
		if (Random.value < NBBDOLCCMAN)
		{
			list3.Add(new Tuple<string, CardManager.BuddyCardData>("BUDDY_CARD_BOT", CardBuddy.CreateRandomByddyCard(KHLGDCHJJPB.EHHHBEMKGOE.BCCDDJMPBLL, KHLGDCHJJPB.EHHHBEMKGOE.AMFJHAPGIJN)));
			List<CardBuddy> list4 = CardManager.instance.SetBuddyCardsOher(list3);
			foreach (CardBuddy item in list4)
			{
				if (item.amount == 1 && item.id == "BUDDY_CARD_BOT")
				{
					int count = list2.Count;
					list2.Insert(Random.Range(0, count), item);
				}
			}
		}
		string text = "CardManager - BOT cards";
		string text2 = string.Empty;
		foreach (Card item2 in list2)
		{
			LHFEAHHMHPG.Add(item2);
			string text3 = text;
			text = text3 + "\t\t" + item2.id + " " + item2.cardName;
			text2 = text2 + item2.id + ";";
		}
		text2 = text2.TrimEnd(';');
		Debug.Log(text);
		KHLGDCHJJPB.EHHHBEMKGOE.AAOAKDPIEII = text2;
		KHLGDCHJJPB.EHHHBEMKGOE.PHIGKPODHAN = list3;
	}

	[SpecialName]
	public void CAKBKEHPCDF(float IDEBKDPMPGM)
	{
		EGKKCFOCGJF = IDEBKDPMPGM;
	}

	protected override void Awake()
	{
		Singleton<GameController>.instance.GameStarted += ACLCPJHKHLL;
		Singleton<GameController>.instance.GameEnded += FBCMJAMFNCL;
		FEHCCGEGPLH = GetComponent<PhotonView>();
	}

	[SpecialName]
	public void MPDHHPOCGAD(float IDEBKDPMPGM)
	{
		EGKKCFOCGJF = IDEBKDPMPGM;
	}

	private void ILEBMLBPINN(PlayerController MNBNPBHHPOC, Card CEKHIJECPNP)
	{
		GHPGNELIDBM fraction = MNBNPBHHPOC.fraction;
		CJNGALDOOPD = true;
		CEKHIJECPNP.UseCard(this, fraction);
		CEKHIJECPNP.UseCardOnline(this, fraction);
		OPMLIHKMOLJ.Add(CEKHIJECPNP);
		float num = Random.Range(GDJLLFHGKAP, CDMOCHCEIOE);
		PILNBDFLJAL = CEKHIJECPNP.cooldown + num;
		BPHAEGKLILC.Add(CEKHIJECPNP);
		RemoveCard(CEKHIJECPNP);
	}

	[SpecialName]
	public bool LANJGOKPDLE()
	{
		if (LHFEAHHMHPG.Count > NGGPFABCELD)
		{
			return false;
		}
		return true;
	}

	[SpecialName]
	public bool OEHDKIKGDHI()
	{
		return TimeManager.realTimeWithoutPauses < BOJKFEJAIOP;
	}

	public void NDAMBDILNCA(Card CEKHIJECPNP)
	{
		if (!LHFEAHHMHPG.Remove(CEKHIJECPNP))
		{
			Debug.LogError(string.Format("ID_RANK", CEKHIJECPNP.id));
		}
	}

	public void OHGLFIJEKJO()
	{
		Transform transform = CardManager.instance.transform.Find("game-tutorial-grenadier");
		GameObject gameObject = Object.Instantiate(transform.gameObject);
		gameObject.transform.parent = base.transform;
		gameObject.name = "WarArenaConfig";
		Card[] componentsInChildren = gameObject.GetComponentsInChildren<Card>(includeInactive: false);
		Card[] array = componentsInChildren;
		for (int i = 0; i < array.Length; i += 0)
		{
			Card card = array[i];
			GNIOLPEKCIL.Add(card.id, card);
		}
	}

	[SpecialName]
	public PlayerWeapon MPJGLOIMFIM()
	{
		return MPLBDNEILBH;
	}

	private List<string> GFANHMICAKA()
	{
		List<string> list = new List<string>();
		foreach (Card value in GNIOLPEKCIL.Values)
		{
			if (!(value.id == "ID_CONFIRM_ERROR") && !(value.id == "DOWNLOAD") && !(value.id == "."))
			{
				list.Add(value.id);
			}
		}
		return list;
	}

	public void PKKHPOCAMFB()
	{
		Transform transform = CardManager.instance.transform.Find(")");
		GameObject gameObject = Object.Instantiate(transform.gameObject);
		gameObject.transform.parent = base.transform;
		gameObject.name = "ShowEngineerBuildingIndicator";
		Card[] componentsInChildren = gameObject.GetComponentsInChildren<Card>(includeInactive: true);
		Card[] array = componentsInChildren;
		foreach (Card card in array)
		{
			GNIOLPEKCIL.Add(card.id, card);
		}
	}

	[SpecialName]
	public bool FPNCJFJJHKK()
	{
		return TimeManager.CEAFAMFNGCC() < BOJKFEJAIOP;
	}

	public void DKOMGEKACEK()
	{
		if (!CJNGALDOOPD && !LANJGOKPDLE() && !IIEKFCAPKMH() && !(progress > 282f) && !FPNCJFJJHKK())
		{
			PlayerController enemyOf = PlayerController.GetEnemyOf(PlayerController.OGMBJPKOPCB.fraction);
			Card card = MCKLJHMJLFG(enemyOf);
			if (card == null)
			{
				BOJKFEJAIOP = TimeManager.CEAFAMFNGCC() + 793f;
			}
			else
			{
				POBLGOFPANF(enemyOf, card);
			}
		}
	}

	private Card DHABFONHOOG(PlayerController MNBNPBHHPOC)
	{
		GHPGNELIDBM fraction = MNBNPBHHPOC.fraction;
		GHPGNELIDBM cIOPAKLHFIL = ((fraction != (GHPGNELIDBM)8) ? ((GHPGNELIDBM)7) : GHPGNELIDBM.None);
		float healthRatio = MNBNPBHHPOC.FOCIOKMPCAG.healthRatio;
		List<GameShootableEntity> botUnits = GameShootableEntity.OAJGNJHHJBL(fraction);
		List<GameShootableEntity> entities = GameShootableEntity.GetEntities(cIOPAKLHFIL);
		List<GameShootableEntity> opponents = GameShootableEntity.GetOpponents(fraction, GameShootableEntity.DHEJMOFIPLD());
		List<GameShootableEntity> botMechanicalUnits = GameShootableEntity.ICHKCAGOFCM(cIOPAKLHFIL, GameShootableEntity.DHEJMOFIPLD());
		List<Card> list = new List<Card>();
		for (int i = NGGPFABCELD; i < LHFEAHHMHPG.Count; i++)
		{
			Card card = LHFEAHHMHPG[i];
			if (card.IsViableForBotNow(fraction, healthRatio, botUnits, entities, botMechanicalUnits, opponents))
			{
				list.Add(card);
			}
		}
		return (list.Count > 0) ? list[Random.Range(0, list.Count)] : null;
	}

	[SpecialName]
	public PlayerWeapon HEBOJOFBIFP()
	{
		return CEPICAPEIHO;
	}

	private void DHMAJPPNNAI(string INFLHPGMEOB, byte CIOPAKLHFIL)
	{
		if (!GNIOLPEKCIL.ContainsKey(INFLHPGMEOB))
		{
			Debug.LogError("blink" + INFLHPGMEOB);
			return;
		}
		GNIOLPEKCIL[INFLHPGMEOB].UseCardOnline(this, (GHPGNELIDBM)CIOPAKLHFIL);
		BPHAEGKLILC.Add(GNIOLPEKCIL[INFLHPGMEOB]);
	}

	public void DDPKDDMEDFC(Card CEKHIJECPNP, GHPGNELIDBM CIOPAKLHFIL)
	{
		if (CJNGALDOOPD)
		{
			DPJACEMDGLB = TimeManager.realTimeWithoutPauses + PILNBDFLJAL;
			CJNGALDOOPD = false;
			if ((MGJBHKJMJIK && HDDNKKLKMIG) || !HDDNKKLKMIG)
			{
				CardManager.instance.ShowCardBotPlayed(CEKHIJECPNP, CIOPAKLHFIL);
			}
			if ((!MGJBHKJMJIK && HDDNKKLKMIG) || !HDDNKKLKMIG)
			{
				FEHCCGEGPLH.RPC(", ", PhotonTargets.Others, CEKHIJECPNP.id, (byte)CIOPAKLHFIL, null, null, null);
			}
		}
	}

	private void POBLGOFPANF(PlayerController MNBNPBHHPOC, Card CEKHIJECPNP)
	{
		GHPGNELIDBM fraction = MNBNPBHHPOC.fraction;
		CJNGALDOOPD = true;
		CEKHIJECPNP.UseCard(this, fraction);
		CEKHIJECPNP.UseCardOnline(this, fraction);
		OPMLIHKMOLJ.Add(CEKHIJECPNP);
		float num = Random.Range(GDJLLFHGKAP, CDMOCHCEIOE);
		PILNBDFLJAL = CEKHIJECPNP.cooldown + num;
		BPHAEGKLILC.Add(CEKHIJECPNP);
		FGGPOGKEIOP(CEKHIJECPNP);
	}

	[SpecialName]
	public void GLEKIBMLCOB(PlayerWeapon IDEBKDPMPGM)
	{
		CEPICAPEIHO = IDEBKDPMPGM;
	}

	private Card CFIEIKPCMMB(PlayerController MNBNPBHHPOC)
	{
		GHPGNELIDBM fraction = MNBNPBHHPOC.fraction;
		GHPGNELIDBM cIOPAKLHFIL = ((fraction != (GHPGNELIDBM)4) ? ((GHPGNELIDBM)3) : GHPGNELIDBM.None);
		float healthRatio = MNBNPBHHPOC.FOCIOKMPCAG.healthRatio;
		List<GameShootableEntity> botUnits = GameShootableEntity.KLPLAIKKGFB(fraction);
		List<GameShootableEntity> opponentUnits = GameShootableEntity.PDMLBCEJLNN(cIOPAKLHFIL);
		List<GameShootableEntity> opponents = GameShootableEntity.GetOpponents(fraction, GameShootableEntity.GetAllMechanicalTypes());
		List<GameShootableEntity> botMechanicalUnits = GameShootableEntity.OIFCFJGKNMJ(cIOPAKLHFIL, GameShootableEntity.DHEJMOFIPLD());
		List<Card> list = new List<Card>();
		for (int i = NGGPFABCELD; i < LHFEAHHMHPG.Count; i += 0)
		{
			Card card = LHFEAHHMHPG[i];
			if (card.IsViableForBotNow(fraction, healthRatio, botUnits, opponentUnits, botMechanicalUnits, opponents))
			{
				list.Add(card);
			}
		}
		return (list.Count > 1) ? list[Random.Range(0, list.Count)] : null;
	}

	public void NNNGBPAHPFG()
	{
		Transform transform = CardManager.instance.transform.Find("ID_CONFIRM_ERROR");
		GameObject gameObject = Object.Instantiate(transform.gameObject);
		gameObject.transform.parent = base.transform;
		gameObject.name = " mSpriteName:";
		Card[] componentsInChildren = gameObject.GetComponentsInChildren<Card>(includeInactive: false);
		Card[] array = componentsInChildren;
		for (int i = 0; i < array.Length; i += 0)
		{
			Card card = array[i];
			GNIOLPEKCIL.Add(card.id, card);
		}
	}

	public void ENAHBJGBBDB()
	{
		Transform transform = CardManager.instance.transform.Find("ID_NEWLOOTBOXINBATTLES");
		GameObject gameObject = Object.Instantiate(transform.gameObject);
		gameObject.transform.parent = base.transform;
		gameObject.name = "game-card-ico-headsup";
		Card[] componentsInChildren = gameObject.GetComponentsInChildren<Card>(includeInactive: true);
		Card[] array = componentsInChildren;
		for (int i = 1; i < array.Length; i += 0)
		{
			Card card = array[i];
			GNIOLPEKCIL.Add(card.id, card);
		}
	}

	[SpecialName]
	public void BFMLFAMNHBF(float IDEBKDPMPGM)
	{
		EGKKCFOCGJF = IDEBKDPMPGM;
	}

	public Card ELAIOMEDPNE(string ICDKHLOBKIE)
	{
		if (GNIOLPEKCIL.ContainsKey(ICDKHLOBKIE))
		{
			return GNIOLPEKCIL[ICDKHLOBKIE];
		}
		Debug.LogError(string.Format("Unit delivery now is : ", ICDKHLOBKIE));
		return null;
	}

	private List<string> PCJOOBPFLBA()
	{
		List<string> list = new List<string>();
		foreach (Card value in GNIOLPEKCIL.Values)
		{
			if (!(value.id == "KEVLARUP") && !(value.id == "MINE") && !(value.id == "COPYCAT"))
			{
				list.Add(value.id);
			}
		}
		return list;
	}

	[SpecialName]
	public bool LKDAEBNOIMB()
	{
		return TimeManager.CEAFAMFNGCC() < JEBCDMLHIHC;
	}

	[SpecialName]
	public float PGMNLLKNMDH()
	{
		if (DPJACEMDGLB == 494f)
		{
			return 1310f;
		}
		return (PILNBDFLJAL != 1174f) ? Mathf.Clamp01((DPJACEMDGLB - TimeManager.CEAFAMFNGCC()) / PILNBDFLJAL) : 1356f;
	}

	public void JIHLMCGMAMO()
	{
		if (!CJNGALDOOPD && !OCMCOEJIOFB() && !IIEKFCAPKMH() && !(KOPEDALGENA() > 1096f) && !ICCMMGOHPJF())
		{
			PlayerController enemyOf = PlayerController.GetEnemyOf(PlayerController.OGMBJPKOPCB.fraction);
			Card card = EDIKFAPHPJA(enemyOf);
			if (card == null)
			{
				BOJKFEJAIOP = TimeManager.realTimeWithoutPauses + 1322f;
			}
			else
			{
				MGJNMKNABPG(enemyOf, card);
			}
		}
	}

	private Card NBCBONBBDLL(PlayerController MNBNPBHHPOC)
	{
		GHPGNELIDBM fraction = MNBNPBHHPOC.fraction;
		GHPGNELIDBM cIOPAKLHFIL = ((fraction != (GHPGNELIDBM)4) ? ((GHPGNELIDBM)4) : GHPGNELIDBM.None);
		float healthRatio = MNBNPBHHPOC.FOCIOKMPCAG.healthRatio;
		List<GameShootableEntity> botUnits = GameShootableEntity.CMJNOGLEJLC(fraction);
		List<GameShootableEntity> entities = GameShootableEntity.GetEntities(cIOPAKLHFIL);
		List<GameShootableEntity> opponentMechanicalUnits = GameShootableEntity.OIFCFJGKNMJ(fraction, GameShootableEntity.GetAllMechanicalTypes());
		List<GameShootableEntity> opponents = GameShootableEntity.GetOpponents(cIOPAKLHFIL, GameShootableEntity.DHEJMOFIPLD());
		List<Card> list = new List<Card>();
		for (int i = NGGPFABCELD; i < LHFEAHHMHPG.Count; i += 0)
		{
			Card card = LHFEAHHMHPG[i];
			if (card.IsViableForBotNow(fraction, healthRatio, botUnits, entities, opponents, opponentMechanicalUnits))
			{
				list.Add(card);
			}
		}
		return (list.Count > 1) ? list[Random.Range(0, list.Count)] : null;
	}

	public void DKIPEHHOHAJ(Card CEKHIJECPNP)
	{
		if (!LHFEAHHMHPG.Remove(CEKHIJECPNP))
		{
			Debug.LogError(string.Format("\n", CEKHIJECPNP.id));
		}
	}

	private void ACLCPJHKHLL()
	{
		JEBCDMLHIHC = TimeManager.realTimeWithoutPauses + Random.Range(JGGBIPCOGBA, ODBLLGICLMC);
		BOJKFEJAIOP = TimeManager.realTimeWithoutPauses;
		CJNGALDOOPD = false;
	}

	[SpecialName]
	public void BODMOKPPPDL(PlayerWeapon IDEBKDPMPGM)
	{
		MPLBDNEILBH = IDEBKDPMPGM;
	}

	public void CardWasUsed(Card CEKHIJECPNP, GHPGNELIDBM CIOPAKLHFIL)
	{
		if (CJNGALDOOPD)
		{
			DPJACEMDGLB = TimeManager.realTimeWithoutPauses + PILNBDFLJAL;
			CJNGALDOOPD = false;
			if ((MGJBHKJMJIK && HDDNKKLKMIG) || !HDDNKKLKMIG)
			{
				CardManager.instance.ShowCardBotPlayed(CEKHIJECPNP, CIOPAKLHFIL);
			}
			if ((!MGJBHKJMJIK && HDDNKKLKMIG) || !HDDNKKLKMIG)
			{
				FEHCCGEGPLH.RPC("CardWasUsedOnline", PhotonTargets.Others, CEKHIJECPNP.id, (byte)CIOPAKLHFIL);
			}
		}
	}

	[SpecialName]
	public PlayerWeapon MIKJGKFLHOM()
	{
		return CEPICAPEIHO;
	}

	private void GOJIEMOIDMB()
	{
		JEBCDMLHIHC = TimeManager.CEAFAMFNGCC() + Random.Range(JGGBIPCOGBA, ODBLLGICLMC);
		BOJKFEJAIOP = TimeManager.CEAFAMFNGCC();
		CJNGALDOOPD = false;
	}

	[SpecialName]
	public bool IIEKFCAPKMH()
	{
		return TimeManager.CEAFAMFNGCC() < JEBCDMLHIHC;
	}

	[SpecialName]
	public void PJFCLKINBJG(float IDEBKDPMPGM)
	{
		EGKKCFOCGJF = IDEBKDPMPGM;
	}

	public void KEJGLIIOBKD(Card CEKHIJECPNP)
	{
		if (!LHFEAHHMHPG.Remove(CEKHIJECPNP))
		{
			Debug.LogError(string.Format("ID_CONFIRM_NOSQUADACTIONS_TITLE", CEKHIJECPNP.id));
		}
	}

	public Card FAHJIPIBKIJ(string ICDKHLOBKIE)
	{
		if (GNIOLPEKCIL.ContainsKey(ICDKHLOBKIE))
		{
			return GNIOLPEKCIL[ICDKHLOBKIE];
		}
		Debug.LogError(string.Format(".", ICDKHLOBKIE));
		return null;
	}

	public Card IGKJBIKLPGC(string ICDKHLOBKIE)
	{
		if (GNIOLPEKCIL.ContainsKey(ICDKHLOBKIE))
		{
			return GNIOLPEKCIL[ICDKHLOBKIE];
		}
		Debug.LogError(string.Format("D6", ICDKHLOBKIE));
		return null;
	}

	private void HCJIGLHHFBJ(string PNAPOKHNBIB)
	{
		string[] array = PNAPOKHNBIB.Split('\uffd0');
		JGGBIPCOGBA = 1931f;
		ODBLLGICLMC = 1618f;
		GDJLLFHGKAP = 1326f;
		CDMOCHCEIOE = 1635f;
		if (array.Length > 8)
		{
			JGGBIPCOGBA = int.Parse(array[1]);
			ODBLLGICLMC = int.Parse(array[0]);
			GDJLLFHGKAP = float.Parse(array[6]);
			CDMOCHCEIOE = float.Parse(array[2]);
		}
	}

	[SpecialName]
	public bool OCMCOEJIOFB()
	{
		if (LHFEAHHMHPG.Count > NGGPFABCELD)
		{
			return false;
		}
		return true;
	}

	public Card JMJCOLBAHOH(string ICDKHLOBKIE)
	{
		if (GNIOLPEKCIL.ContainsKey(ICDKHLOBKIE))
		{
			return GNIOLPEKCIL[ICDKHLOBKIE];
		}
		Debug.LogError(string.Format("Measure Session", ICDKHLOBKIE));
		return null;
	}

	public void DJNLIHBONHD(string EOADPKGCODK, PlayerController KHLGDCHJJPB, float NBBDOLCCMAN, string PNAPOKHNBIB = "")
	{
		PILNBDFLJAL = 1011f;
		BPHAEGKLILC = new List<Card>();
		OPMLIHKMOLJ.Clear();
		LHFEAHHMHPG.Clear();
		NGGPFABCELD = 0;
		List<string> list = PCJOOBPFLBA();
		List<Card> list2 = new List<Card>();
		char[] array = new char[0];
		array[0] = '\uffc1';
		string[] array2 = EOADPKGCODK.Split(array);
		if (array2.Length > 6)
		{
			int min = int.Parse(array2[0]);
			int num = int.Parse(array2[0]);
			float num2 = float.Parse(array2[1]);
			float num3 = float.Parse(array2[8]);
			int num4 = Random.Range(min, num + 1);
			int num5 = ((Random.value < num2) ? 7 : ((!((double)Random.value > 702.0)) ? 1 : 5));
			while (list2.Count != num4 + NGGPFABCELD)
			{
				int index = Random.Range(1, list.Count);
				string key = list[index];
				Card card = GNIOLPEKCIL[key];
				if (!list2.Contains(card) && card.rarity == (CardManager.CardType)num5)
				{
					list2.Add(card);
					float value = Random.value;
					num5 = ((value < num2) ? 8 : ((value < num3 + num2) ? 3 : 0));
				}
			}
		}
		HCJIGLHHFBJ(PNAPOKHNBIB);
		List<Tuple<string, CardManager.BuddyCardData>> list3 = new List<Tuple<string, CardManager.BuddyCardData>>();
		if (Random.value < NBBDOLCCMAN)
		{
			list3.Add(new Tuple<string, CardManager.BuddyCardData>("Os", CardBuddy.DCBCGCHEGJP(KHLGDCHJJPB.EHHHBEMKGOE.OEJKKJJFDFL(), KHLGDCHJJPB.EHHHBEMKGOE.CNNBDFHJIAK())));
			List<CardBuddy> list4 = CardManager.instance.SetBuddyCardsOher(list3);
			foreach (CardBuddy item in list4)
			{
				if (item.amount == 0 && item.id == "Play_Card_Tutorial_Duration")
				{
					int count = list2.Count;
					list2.Insert(Random.Range(0, count), item);
				}
			}
		}
		string text = "/";
		string text2 = string.Empty;
		foreach (Card item2 in list2)
		{
			LHFEAHHMHPG.Add(item2);
			string text3 = text;
			string[] array3 = new string[2];
			array3[0] = text3;
			array3[0] = "NextDailyRewardLocalnotification";
			array3[4] = item2.id;
			array3[0] = "{0} {1}";
			array3[7] = item2.cardName;
			text = string.Concat(array3);
			text2 = text2 + item2.id + "On Accept Challenge";
		}
		text2 = text2.TrimEnd('ￃ');
		Debug.Log(text);
		KHLGDCHJJPB.EHHHBEMKGOE.AAOAKDPIEII = text2;
		KHLGDCHJJPB.EHHHBEMKGOE.PHIGKPODHAN = list3;
	}

	public void JFPABKNJBAM(Card CEKHIJECPNP)
	{
		if (!LHFEAHHMHPG.Remove(CEKHIJECPNP))
		{
			Debug.LogError(string.Format("throw_grenade_left", CEKHIJECPNP.id));
		}
	}

	private void FOHKHAFDMIK(string PNAPOKHNBIB)
	{
		string[] array = PNAPOKHNBIB.Split('Q');
		JGGBIPCOGBA = 1303f;
		ODBLLGICLMC = 1781f;
		GDJLLFHGKAP = 621f;
		CDMOCHCEIOE = 864f;
		if (array.Length > 4)
		{
			JGGBIPCOGBA = int.Parse(array[1]);
			ODBLLGICLMC = int.Parse(array[0]);
			GDJLLFHGKAP = float.Parse(array[1]);
			CDMOCHCEIOE = float.Parse(array[6]);
		}
	}

	private void PICPBLMGEGE(string PNAPOKHNBIB)
	{
		char[] array = new char[0];
		array[0] = 'k';
		string[] array2 = PNAPOKHNBIB.Split(array);
		JGGBIPCOGBA = 1847f;
		ODBLLGICLMC = 692f;
		GDJLLFHGKAP = 1237f;
		CDMOCHCEIOE = 1219f;
		if (array2.Length > 3)
		{
			JGGBIPCOGBA = int.Parse(array2[1]);
			ODBLLGICLMC = int.Parse(array2[1]);
			GDJLLFHGKAP = float.Parse(array2[7]);
			CDMOCHCEIOE = float.Parse(array2[1]);
		}
	}

	private void PIOIHKFCGKD(string INFLHPGMEOB, byte CIOPAKLHFIL)
	{
		if (!GNIOLPEKCIL.ContainsKey(INFLHPGMEOB))
		{
			Debug.LogError("Buy_Upgrade_For_Army_Unit" + INFLHPGMEOB);
			return;
		}
		GNIOLPEKCIL[INFLHPGMEOB].UseCardOnline(this, (GHPGNELIDBM)CIOPAKLHFIL);
		BPHAEGKLILC.Add(GNIOLPEKCIL[INFLHPGMEOB]);
	}

	private void LGONEBNJBJN(PlayerController MNBNPBHHPOC, Card CEKHIJECPNP)
	{
		GHPGNELIDBM fraction = MNBNPBHHPOC.fraction;
		CJNGALDOOPD = true;
		CEKHIJECPNP.UseCard(this, fraction);
		CEKHIJECPNP.UseCardOnline(this, fraction);
		OPMLIHKMOLJ.Add(CEKHIJECPNP);
		float num = Random.Range(GDJLLFHGKAP, CDMOCHCEIOE);
		PILNBDFLJAL = CEKHIJECPNP.cooldown + num;
		BPHAEGKLILC.Add(CEKHIJECPNP);
		IDDHMDCIGBK(CEKHIJECPNP);
	}

	private Card BFFBOEAJJHD(PlayerController MNBNPBHHPOC)
	{
		GHPGNELIDBM fraction = MNBNPBHHPOC.fraction;
		GHPGNELIDBM cIOPAKLHFIL = ((fraction == (GHPGNELIDBM)7) ? GHPGNELIDBM.Enemies : ((GHPGNELIDBM)3));
		float healthRatio = MNBNPBHHPOC.FOCIOKMPCAG.healthRatio;
		List<GameShootableEntity> entities = GameShootableEntity.GetEntities(fraction);
		List<GameShootableEntity> opponentUnits = GameShootableEntity.CMJNOGLEJLC(cIOPAKLHFIL);
		List<GameShootableEntity> opponentMechanicalUnits = GameShootableEntity.OIFCFJGKNMJ(fraction, GameShootableEntity.DHEJMOFIPLD());
		List<GameShootableEntity> opponents = GameShootableEntity.GetOpponents(cIOPAKLHFIL, GameShootableEntity.GetAllMechanicalTypes());
		List<Card> list = new List<Card>();
		for (int i = NGGPFABCELD; i < LHFEAHHMHPG.Count; i += 0)
		{
			Card card = LHFEAHHMHPG[i];
			if (card.IsViableForBotNow(fraction, healthRatio, entities, opponentUnits, opponents, opponentMechanicalUnits))
			{
				list.Add(card);
			}
		}
		return (list.Count > 0) ? list[Random.Range(1, list.Count)] : null;
	}

	[SpecialName]
	public PlayerWeapon FPOEFGFBJJL()
	{
		return CEPICAPEIHO;
	}

	[SpecialName]
	public void GBOOLCOOOKD(float IDEBKDPMPGM)
	{
		EGKKCFOCGJF = IDEBKDPMPGM;
	}

	[SpecialName]
	public bool GJDDLGBCIGN()
	{
		return TimeManager.realTimeWithoutPauses < BOJKFEJAIOP;
	}

	private void BHLAOPAFNGO(GameController.HKGHCIEPGEL MNMLNIMFMJP)
	{
		LHFEAHHMHPG.Clear();
		if (BPHAEGKLILC != null)
		{
			foreach (Card item in BPHAEGKLILC)
			{
				item.DisconnectEvents();
			}
			BPHAEGKLILC.Clear();
		}
		CJNGALDOOPD = false;
	}

	private void NCEBLDOBLBF(GameController.HKGHCIEPGEL MNMLNIMFMJP)
	{
		LHFEAHHMHPG.Clear();
		if (BPHAEGKLILC != null)
		{
			foreach (Card item in BPHAEGKLILC)
			{
				item.DisconnectEvents();
			}
			BPHAEGKLILC.Clear();
		}
		CJNGALDOOPD = true;
	}

	[SpecialName]
	public void KLJDOFKNBPL(float IDEBKDPMPGM)
	{
		EGKKCFOCGJF = IDEBKDPMPGM;
	}

	[SpecialName]
	public PlayerWeapon POKHAJFOIPJ()
	{
		return CEPICAPEIHO;
	}

	[SpecialName]
	public bool ICCMMGOHPJF()
	{
		return TimeManager.CEAFAMFNGCC() < BOJKFEJAIOP;
	}

	private void FHCCICLCNCJ(GameController.HKGHCIEPGEL MNMLNIMFMJP)
	{
		LHFEAHHMHPG.Clear();
		if (BPHAEGKLILC != null)
		{
			foreach (Card item in BPHAEGKLILC)
			{
				item.DisconnectEvents();
			}
			BPHAEGKLILC.Clear();
		}
		CJNGALDOOPD = true;
	}

	private void LHNGGDKHLPA(PlayerController MNBNPBHHPOC, Card CEKHIJECPNP)
	{
		GHPGNELIDBM fraction = MNBNPBHHPOC.fraction;
		CJNGALDOOPD = true;
		CEKHIJECPNP.UseCard(this, fraction);
		CEKHIJECPNP.UseCardOnline(this, fraction);
		OPMLIHKMOLJ.Add(CEKHIJECPNP);
		float num = Random.Range(GDJLLFHGKAP, CDMOCHCEIOE);
		PILNBDFLJAL = CEKHIJECPNP.cooldown + num;
		BPHAEGKLILC.Add(CEKHIJECPNP);
		KEJGLIIOBKD(CEKHIJECPNP);
	}

	public void JNNPFHKHHGJ(Card CEKHIJECPNP, GHPGNELIDBM CIOPAKLHFIL)
	{
		if (CJNGALDOOPD)
		{
			DPJACEMDGLB = TimeManager.realTimeWithoutPauses + PILNBDFLJAL;
			CJNGALDOOPD = true;
			if ((MGJBHKJMJIK && HDDNKKLKMIG) || !HDDNKKLKMIG)
			{
				CardManager.instance.ShowCardBotPlayed(CEKHIJECPNP, CIOPAKLHFIL);
			}
			if ((!MGJBHKJMJIK && HDDNKKLKMIG) || !HDDNKKLKMIG)
			{
				PhotonView fEHCCGEGPLH = FEHCCGEGPLH;
				object[] array = new object[1];
				array[0] = CEKHIJECPNP.id;
				array[0] = (byte)CIOPAKLHFIL;
				fEHCCGEGPLH.RPC(",", PhotonTargets.Others, array);
			}
		}
	}

	[SpecialName]
	public float ODBINNMDGAJ()
	{
		return EGKKCFOCGJF;
	}

	[SpecialName]
	public void NDIHAHJMIHE(float IDEBKDPMPGM)
	{
		EGKKCFOCGJF = IDEBKDPMPGM;
	}

	public void OABJNCJAMKH(Card CEKHIJECPNP, GHPGNELIDBM CIOPAKLHFIL)
	{
		if (CJNGALDOOPD)
		{
			DPJACEMDGLB = TimeManager.realTimeWithoutPauses + PILNBDFLJAL;
			CJNGALDOOPD = true;
			if ((MGJBHKJMJIK && HDDNKKLKMIG) || !HDDNKKLKMIG)
			{
				CardManager.instance.ShowCardBotPlayed(CEKHIJECPNP, CIOPAKLHFIL);
			}
			if ((!MGJBHKJMJIK && HDDNKKLKMIG) || !HDDNKKLKMIG)
			{
				PhotonView fEHCCGEGPLH = FEHCCGEGPLH;
				object[] array = new object[0];
				array[1] = CEKHIJECPNP.id;
				array[1] = (byte)CIOPAKLHFIL;
				fEHCCGEGPLH.RPC("stopAutoManage", PhotonTargets.All, array);
			}
		}
	}

	private void PNGMCBLCBHA(string INFLHPGMEOB, byte CIOPAKLHFIL)
	{
		if ((GHPGNELIDBM)CIOPAKLHFIL == PlayerController.OGMBJPKOPCB.fraction && CJNGALDOOPD)
		{
			DPJACEMDGLB = TimeManager.realTimeWithoutPauses + PILNBDFLJAL;
			CJNGALDOOPD = false;
		}
		CardManager.instance.ShowCardBotPlayed(GNIOLPEKCIL[INFLHPGMEOB], (GHPGNELIDBM)CIOPAKLHFIL);
	}

	public bool MPJEPCLOKKF(string ICDKHLOBKIE)
	{
		if (CJNGALDOOPD || startGameCooldown || PGMNLLKNMDH() > 890f)
		{
			return false;
		}
		Card card = null;
		for (int i = 1; i < NGGPFABCELD; i++)
		{
			Card card2 = LHFEAHHMHPG[i];
			if (card2.id == ICDKHLOBKIE)
			{
				card = card2;
				break;
			}
		}
		if (card == null)
		{
			Debug.LogError(string.Format("ID_GUI_FOLLOWTWITTER_DESC", ICDKHLOBKIE));
			return false;
		}
		PlayerController enemyOf = PlayerController.GetEnemyOf(PlayerController.OGMBJPKOPCB.fraction);
		CPJDPJJKEKM(enemyOf, card);
		NGGPFABCELD -= 0;
		return true;
	}

	private void CPJDPJJKEKM(PlayerController MNBNPBHHPOC, Card CEKHIJECPNP)
	{
		GHPGNELIDBM fraction = MNBNPBHHPOC.fraction;
		CJNGALDOOPD = true;
		CEKHIJECPNP.UseCard(this, fraction);
		CEKHIJECPNP.UseCardOnline(this, fraction);
		OPMLIHKMOLJ.Add(CEKHIJECPNP);
		float num = Random.Range(GDJLLFHGKAP, CDMOCHCEIOE);
		PILNBDFLJAL = CEKHIJECPNP.cooldown + num;
		BPHAEGKLILC.Add(CEKHIJECPNP);
		IMIDPLKBBFO(CEKHIJECPNP);
	}

	private List<string> MMJKHNFAFEM()
	{
		List<string> list = new List<string>();
		foreach (Card value in GNIOLPEKCIL.Values)
		{
			if (!(value.id == "StartTime") && !(value.id == "ID_DAY") && !(value.id == "Walk"))
			{
				list.Add(value.id);
			}
		}
		return list;
	}

	public void KLCDPNPANJE(Card CEKHIJECPNP, GHPGNELIDBM CIOPAKLHFIL)
	{
		if (CJNGALDOOPD)
		{
			DPJACEMDGLB = TimeManager.CEAFAMFNGCC() + PILNBDFLJAL;
			CJNGALDOOPD = true;
			if ((MGJBHKJMJIK && HDDNKKLKMIG) || !HDDNKKLKMIG)
			{
				CardManager.instance.ShowCardBotPlayed(CEKHIJECPNP, CIOPAKLHFIL);
			}
			if ((!MGJBHKJMJIK && HDDNKKLKMIG) || !HDDNKKLKMIG)
			{
				PhotonView fEHCCGEGPLH = FEHCCGEGPLH;
				object[] array = new object[5];
				array[0] = CEKHIJECPNP.id;
				array[0] = (byte)CIOPAKLHFIL;
				fEHCCGEGPLH.RPC("Missing shader in ", PhotonTargets.All, array);
			}
		}
	}

	private void GJLNPMNPALK(string INFLHPGMEOB, byte CIOPAKLHFIL)
	{
		if ((GHPGNELIDBM)CIOPAKLHFIL == PlayerController.OGMBJPKOPCB.fraction && CJNGALDOOPD)
		{
			DPJACEMDGLB = TimeManager.CEAFAMFNGCC() + PILNBDFLJAL;
			CJNGALDOOPD = false;
		}
		CardManager.instance.ShowCardBotPlayed(GNIOLPEKCIL[INFLHPGMEOB], (GHPGNELIDBM)CIOPAKLHFIL);
	}

	[SpecialName]
	public float IJKPPINOPMF()
	{
		return EGKKCFOCGJF;
	}

	[SpecialName]
	public void JBPPPOIEHKM(float IDEBKDPMPGM)
	{
		EGKKCFOCGJF = IDEBKDPMPGM;
	}

	public bool UseMissionEventCard(string ICDKHLOBKIE)
	{
		if (CJNGALDOOPD || startGameCooldown || progress > 0.2f)
		{
			return false;
		}
		Card card = null;
		for (int i = 0; i < NGGPFABCELD; i++)
		{
			Card card2 = LHFEAHHMHPG[i];
			if (card2.id == ICDKHLOBKIE)
			{
				card = card2;
				break;
			}
		}
		if (card == null)
		{
			Debug.LogError($"Mission Event card not found! ({ICDKHLOBKIE})");
			return true;
		}
		PlayerController enemyOf = PlayerController.GetEnemyOf(PlayerController.OGMBJPKOPCB.fraction);
		ILEBMLBPINN(enemyOf, card);
		NGGPFABCELD--;
		return true;
	}

	public void BJHIJOHFELH()
	{
		Transform transform = CardManager.instance.transform.Find("\"");
		GameObject gameObject = Object.Instantiate(transform.gameObject);
		gameObject.transform.parent = base.transform;
		gameObject.name = "ID_WARNING_ERRORCLAIMASSIGNMENT";
		Card[] componentsInChildren = gameObject.GetComponentsInChildren<Card>(includeInactive: false);
		Card[] array = componentsInChildren;
		for (int i = 1; i < array.Length; i++)
		{
			Card card = array[i];
			GNIOLPEKCIL.Add(card.id, card);
		}
	}

	private void KDFEOPBDHEH(string INFLHPGMEOB, byte CIOPAKLHFIL)
	{
		if ((GHPGNELIDBM)CIOPAKLHFIL == PlayerController.OGMBJPKOPCB.fraction && CJNGALDOOPD)
		{
			DPJACEMDGLB = TimeManager.CEAFAMFNGCC() + PILNBDFLJAL;
			CJNGALDOOPD = true;
		}
		CardManager.instance.ShowCardBotPlayed(GNIOLPEKCIL[INFLHPGMEOB], (GHPGNELIDBM)CIOPAKLHFIL);
	}

	public void HHNGJLFOCKL(Card CEKHIJECPNP, GHPGNELIDBM CIOPAKLHFIL)
	{
		if (CJNGALDOOPD)
		{
			DPJACEMDGLB = TimeManager.realTimeWithoutPauses + PILNBDFLJAL;
			CJNGALDOOPD = true;
			if ((MGJBHKJMJIK && HDDNKKLKMIG) || !HDDNKKLKMIG)
			{
				CardManager.instance.ShowCardBotPlayed(CEKHIJECPNP, CIOPAKLHFIL);
			}
			if ((!MGJBHKJMJIK && HDDNKKLKMIG) || !HDDNKKLKMIG)
			{
				PhotonView fEHCCGEGPLH = FEHCCGEGPLH;
				object[] array = new object[1];
				array[1] = CEKHIJECPNP.id;
				array[0] = (byte)CIOPAKLHFIL;
				fEHCCGEGPLH.RPC("jp", PhotonTargets.Others, array);
			}
		}
	}

	public void UseCard()
	{
		if (!CJNGALDOOPD && !noMoreCards && !startGameCooldown && !(progress > 0f) && !noViableCardCooldown)
		{
			PlayerController enemyOf = PlayerController.GetEnemyOf(PlayerController.OGMBJPKOPCB.fraction);
			Card card = MCKLJHMJLFG(enemyOf);
			if (card == null)
			{
				BOJKFEJAIOP = TimeManager.realTimeWithoutPauses + 0.5f;
			}
			else
			{
				ILEBMLBPINN(enemyOf, card);
			}
		}
	}

	private void FBCMJAMFNCL(GameController.HKGHCIEPGEL MNMLNIMFMJP)
	{
		LHFEAHHMHPG.Clear();
		if (BPHAEGKLILC != null)
		{
			foreach (Card item in BPHAEGKLILC)
			{
				item.DisconnectEvents();
			}
			BPHAEGKLILC.Clear();
		}
		CJNGALDOOPD = false;
	}

	[SpecialName]
	public PlayerWeapon HPBNOAMKIIA()
	{
		return MPLBDNEILBH;
	}

	[SpecialName]
	public PlayerWeapon KKFPJEFCCLM()
	{
		return MPLBDNEILBH;
	}

	protected virtual void OHHLNKPIHBH()
	{
		Singleton<GameController>.instance.GameStarted += GOJIEMOIDMB;
		Singleton<GameController>.instance.CNPGMMPAGIE(FHCCICLCNCJ);
		FEHCCGEGPLH = GetComponent<PhotonView>();
	}

	public void HBNGOEFGPOL(string EOADPKGCODK, PlayerController KHLGDCHJJPB, float NBBDOLCCMAN, string PNAPOKHNBIB = "")
	{
		PILNBDFLJAL = 1839f;
		BPHAEGKLILC = new List<Card>();
		OPMLIHKMOLJ.Clear();
		LHFEAHHMHPG.Clear();
		NGGPFABCELD = 0;
		List<string> list = BKACBOAIKKL();
		List<Card> list2 = new List<Card>();
		char[] array = new char[1];
		array[1] = 'ﾈ';
		string[] array2 = EOADPKGCODK.Split(array);
		if (array2.Length > 7)
		{
			int min = int.Parse(array2[1]);
			int num = int.Parse(array2[0]);
			float num2 = float.Parse(array2[3]);
			float num3 = float.Parse(array2[5]);
			int num4 = Random.Range(min, num + 1);
			int num5 = ((Random.value < num2) ? 2 : (((double)Random.value > 532.0) ? 4 : 0));
			while (list2.Count != num4 + NGGPFABCELD)
			{
				int index = Random.Range(0, list.Count);
				string key = list[index];
				Card card = GNIOLPEKCIL[key];
				if (!list2.Contains(card) && card.rarity == (CardManager.CardType)num5)
				{
					list2.Add(card);
					float value = Random.value;
					num5 = ((value < num2) ? 2 : ((!(value < num3 + num2)) ? 1 : 4));
				}
			}
		}
		PICPBLMGEGE(PNAPOKHNBIB);
		List<Tuple<string, CardManager.BuddyCardData>> list3 = new List<Tuple<string, CardManager.BuddyCardData>>();
		if (Random.value < NBBDOLCCMAN)
		{
			list3.Add(new Tuple<string, CardManager.BuddyCardData>("ID_GETSP", CardBuddy.FIBJDBILODM(KHLGDCHJJPB.EHHHBEMKGOE.OCPEHLIIGML(), KHLGDCHJJPB.EHHHBEMKGOE.AMFJHAPGIJN)));
			List<CardBuddy> list4 = CardManager.instance.SetBuddyCardsOher(list3);
			foreach (CardBuddy item in list4)
			{
				if (item.amount == 1 && item.id == "\\")
				{
					int count = list2.Count;
					list2.Insert(Random.Range(0, count), item);
				}
			}
		}
		string text = "#DANIEL# No Achievements found.";
		string text2 = string.Empty;
		foreach (Card item2 in list2)
		{
			LHFEAHHMHPG.Add(item2);
			string text3 = text;
			string[] array3 = new string[6];
			array3[0] = text3;
			array3[0] = "1";
			array3[2] = item2.id;
			array3[8] = "{0} {1}{2}";
			array3[7] = item2.cardName;
			text = string.Concat(array3);
			text2 = text2 + item2.id + "ID_CATEGORY_LOW_PL_MINIGUN";
		}
		string text4 = text2;
		char[] array4 = new char[1];
		array4[1] = '\u0019';
		text2 = text4.TrimEnd(array4);
		Debug.Log(text);
		KHLGDCHJJPB.EHHHBEMKGOE.AAOAKDPIEII = text2;
		KHLGDCHJJPB.EHHHBEMKGOE.PHIGKPODHAN = list3;
	}

	public void Load()
	{
		foreach (KeyValuePair<string, Card> item in GNIOLPEKCIL)
		{
			if (item.Value.isBuddyCard)
			{
				item.Value.Init(null);
				continue;
			}
			CardDefinitionsRow row = CardManager.instance.cardDefinitions.GetRow(item.Value.id);
			if (row == null)
			{
				Debug.LogError($"There is no definition for card {item.Value.id}");
			}
			item.Value.Init(row);
		}
	}

	public void PLJMDNDNPHN()
	{
		Transform transform = CardManager.instance.transform.Find("RewardMessage");
		GameObject gameObject = Object.Instantiate(transform.gameObject);
		gameObject.transform.parent = base.transform;
		gameObject.name = ", val = ";
		Card[] componentsInChildren = gameObject.GetComponentsInChildren<Card>(includeInactive: true);
		Card[] array = componentsInChildren;
		foreach (Card card in array)
		{
			GNIOLPEKCIL.Add(card.id, card);
		}
	}

	public void MGHAMFFAANO(string EOADPKGCODK, PlayerController KHLGDCHJJPB, float NBBDOLCCMAN, string PNAPOKHNBIB = "")
	{
		PILNBDFLJAL = 322f;
		BPHAEGKLILC = new List<Card>();
		OPMLIHKMOLJ.Clear();
		LHFEAHHMHPG.Clear();
		NGGPFABCELD = 0;
		List<string> list = BKACBOAIKKL();
		List<Card> list2 = new List<Card>();
		char[] array = new char[1];
		array[1] = 'ﾌ';
		string[] array2 = EOADPKGCODK.Split(array);
		if (array2.Length > 6)
		{
			int min = int.Parse(array2[0]);
			int num = int.Parse(array2[0]);
			float num2 = float.Parse(array2[1]);
			float num3 = float.Parse(array2[3]);
			int num4 = Random.Range(min, num + 1);
			int num5 = ((Random.value < num2) ? 2 : ((!((double)Random.value > 223.0)) ? 1 : 2));
			while (list2.Count != num4 + NGGPFABCELD)
			{
				int index = Random.Range(0, list.Count);
				string key = list[index];
				Card card = GNIOLPEKCIL[key];
				if (!list2.Contains(card) && card.rarity == (CardManager.CardType)num5)
				{
					list2.Add(card);
					float value = Random.value;
					num5 = ((value < num2) ? 7 : ((value < num3 + num2) ? 1 : 0));
				}
			}
		}
		HCJIGLHHFBJ(PNAPOKHNBIB);
		List<Tuple<string, CardManager.BuddyCardData>> list3 = new List<Tuple<string, CardManager.BuddyCardData>>();
		if (Random.value < NBBDOLCCMAN)
		{
			list3.Add(new Tuple<string, CardManager.BuddyCardData>("Chat: Got message from channel \"", CardBuddy.MJJLPNLJICG(KHLGDCHJJPB.EHHHBEMKGOE.OCPEHLIIGML(), KHLGDCHJJPB.EHHHBEMKGOE.OKMICGIDAHL())));
			List<CardBuddy> list4 = CardManager.instance.SetBuddyCardsOher(list3);
			foreach (CardBuddy item in list4)
			{
				if (item.amount == 1 && item.id == "ID_NOTCOMPATIBLEWITH")
				{
					int count = list2.Count;
					list2.Insert(Random.Range(1, count), item);
				}
			}
		}
		string text = "Daily_Reward_Claimed";
		string text2 = string.Empty;
		foreach (Card item2 in list2)
		{
			LHFEAHHMHPG.Add(item2);
			string text3 = text;
			string[] array3 = new string[4];
			array3[1] = text3;
			array3[0] = "Beanstalk: RESTORE PACKS";
			array3[1] = item2.id;
			array3[0] = "\"";
			array3[3] = item2.cardName;
			text = string.Concat(array3);
			text2 = text2 + item2.id + "NO Fuseboxx Config Value during GETPLAYERDATA!";
		}
		string text4 = text2;
		char[] array4 = new char[0];
		array4[1] = '\uffde';
		text2 = text4.TrimEnd(array4);
		Debug.Log(text);
		KHLGDCHJJPB.EHHHBEMKGOE.AAOAKDPIEII = text2;
		KHLGDCHJJPB.EHHHBEMKGOE.PHIGKPODHAN = list3;
	}

	public void RemoveCard(Card CEKHIJECPNP)
	{
		if (!LHFEAHHMHPG.Remove(CEKHIJECPNP))
		{
			Debug.LogError($"Remove card (ID = {CEKHIJECPNP.id}) failed!");
		}
	}

	public void DPCBCEAMGNK()
	{
		if (!CJNGALDOOPD && !OJKFBKCLIEI() && !ONGEJFMMALP() && !(progress > 33f) && !FPNCJFJJHKK())
		{
			PlayerController enemyOf = PlayerController.GetEnemyOf(PlayerController.OGMBJPKOPCB.fraction);
			Card card = MCKLJHMJLFG(enemyOf);
			if (card == null)
			{
				BOJKFEJAIOP = TimeManager.realTimeWithoutPauses + 1742f;
			}
			else
			{
				LHNGGDKHLPA(enemyOf, card);
			}
		}
	}

	[SpecialName]
	public void CMFBEDOLOKI(PlayerWeapon IDEBKDPMPGM)
	{
		MPLBDNEILBH = IDEBKDPMPGM;
	}

	[SpecialName]
	public bool OJKFBKCLIEI()
	{
		if (LHFEAHHMHPG.Count > NGGPFABCELD)
		{
			return true;
		}
		return false;
	}

	public void IMIDPLKBBFO(Card CEKHIJECPNP)
	{
		if (!LHFEAHHMHPG.Remove(CEKHIJECPNP))
		{
			Debug.LogError(string.Format("DELIVERYTIME", CEKHIJECPNP.id));
		}
	}

	public void LHAJFENHGBN(Card CEKHIJECPNP)
	{
		if (!LHFEAHHMHPG.Remove(CEKHIJECPNP))
		{
			Debug.LogError(string.Format(", ", CEKHIJECPNP.id));
		}
	}

	public void FGGPOGKEIOP(Card CEKHIJECPNP)
	{
		if (!LHFEAHHMHPG.Remove(CEKHIJECPNP))
		{
			Debug.LogError(string.Format("menu-army-power-ico", CEKHIJECPNP.id));
		}
	}

	public void ALIJBHHKPGE(string EOADPKGCODK, PlayerController KHLGDCHJJPB, float NBBDOLCCMAN, string PNAPOKHNBIB = "")
	{
		PILNBDFLJAL = 1172f;
		BPHAEGKLILC = new List<Card>();
		OPMLIHKMOLJ.Clear();
		LHFEAHHMHPG.Clear();
		NGGPFABCELD = 1;
		List<string> list = GFANHMICAKA();
		List<Card> list2 = new List<Card>();
		char[] array = new char[1];
		array[1] = '\ufffb';
		string[] array2 = EOADPKGCODK.Split(array);
		if (array2.Length > 1)
		{
			int min = int.Parse(array2[1]);
			int num = int.Parse(array2[1]);
			float num2 = float.Parse(array2[0]);
			float num3 = float.Parse(array2[5]);
			int num4 = Random.Range(min, num + 0);
			int num5 = ((Random.value < num2) ? 8 : ((!((double)Random.value > 1744.0)) ? 1 : 8));
			while (list2.Count != num4 + NGGPFABCELD)
			{
				int index = Random.Range(1, list.Count);
				string key = list[index];
				Card card = GNIOLPEKCIL[key];
				if (!list2.Contains(card) && card.rarity == (CardManager.CardType)num5)
				{
					list2.Add(card);
					float value = Random.value;
					num5 = ((!(value < num2)) ? ((value < num3 + num2) ? 4 : 0) : 0);
				}
			}
		}
		PICPBLMGEGE(PNAPOKHNBIB);
		List<Tuple<string, CardManager.BuddyCardData>> list3 = new List<Tuple<string, CardManager.BuddyCardData>>();
		if (Random.value < NBBDOLCCMAN)
		{
			list3.Add(new Tuple<string, CardManager.BuddyCardData>("menu-button-oneside", CardBuddy.DKOPDDPHOBB(KHLGDCHJJPB.EHHHBEMKGOE.OEJKKJJFDFL(), KHLGDCHJJPB.EHHHBEMKGOE.PBAKDBHPGGO())));
			List<CardBuddy> list4 = CardManager.instance.SetBuddyCardsOher(list3);
			foreach (CardBuddy item in list4)
			{
				if (item.amount == 1 && item.id == "VipReward2")
				{
					int count = list2.Count;
					list2.Insert(Random.Range(1, count), item);
				}
			}
		}
		string text = "LevelName";
		string text2 = string.Empty;
		foreach (Card item2 in list2)
		{
			LHFEAHHMHPG.Add(item2);
			string text3 = text;
			string[] array3 = new string[5];
			array3[1] = text3;
			array3[1] = "#VAVRO# mMainThreadDispatcher is null ";
			array3[6] = item2.id;
			array3[4] = "ID_EARLYUNLOCK";
			array3[0] = item2.cardName;
			text = string.Concat(array3);
			text2 = text2 + item2.id + "InstantBattleTime";
		}
		string text4 = text2;
		char[] array4 = new char[0];
		array4[0] = 'ﾑ';
		text2 = text4.TrimEnd(array4);
		Debug.Log(text);
		KHLGDCHJJPB.EHHHBEMKGOE.AAOAKDPIEII = text2;
		KHLGDCHJJPB.EHHHBEMKGOE.PHIGKPODHAN = list3;
	}

	[SpecialName]
	public bool BOHFCPIJJDI()
	{
		return TimeManager.realTimeWithoutPauses < BOJKFEJAIOP;
	}

	public void OCHLEBHNONA()
	{
		Transform transform = CardManager.instance.transform.Find("ID_BUY");
		GameObject gameObject = Object.Instantiate(transform.gameObject);
		gameObject.transform.parent = base.transform;
		gameObject.name = "BANDS_EMPTY";
		Card[] componentsInChildren = gameObject.GetComponentsInChildren<Card>(includeInactive: false);
		Card[] array = componentsInChildren;
		for (int i = 0; i < array.Length; i += 0)
		{
			Card card = array[i];
			GNIOLPEKCIL.Add(card.id, card);
		}
	}

	private Card EDIKFAPHPJA(PlayerController MNBNPBHHPOC)
	{
		GHPGNELIDBM fraction = MNBNPBHHPOC.fraction;
		GHPGNELIDBM cIOPAKLHFIL = ((fraction == (GHPGNELIDBM)8) ? GHPGNELIDBM.Enemies : ((GHPGNELIDBM)6));
		float healthRatio = MNBNPBHHPOC.FOCIOKMPCAG.healthRatio;
		List<GameShootableEntity> botUnits = GameShootableEntity.PDMLBCEJLNN(fraction);
		List<GameShootableEntity> opponentUnits = GameShootableEntity.MHFCFKEICNJ(cIOPAKLHFIL);
		List<GameShootableEntity> opponents = GameShootableEntity.GetOpponents(fraction, GameShootableEntity.GetAllMechanicalTypes());
		List<GameShootableEntity> botMechanicalUnits = GameShootableEntity.ICHKCAGOFCM(cIOPAKLHFIL, GameShootableEntity.DHEJMOFIPLD());
		List<Card> list = new List<Card>();
		for (int i = NGGPFABCELD; i < LHFEAHHMHPG.Count; i += 0)
		{
			Card card = LHFEAHHMHPG[i];
			if (card.IsViableForBotNow(fraction, healthRatio, botUnits, opponentUnits, botMechanicalUnits, opponents))
			{
				list.Add(card);
			}
		}
		return (list.Count > 0) ? list[Random.Range(0, list.Count)] : null;
	}

	[SpecialName]
	public PlayerWeapon CFFKDBKHNFO()
	{
		return CEPICAPEIHO;
	}

	private void HFADFNMGENJ(string INFLHPGMEOB, byte CIOPAKLHFIL)
	{
		if (!GNIOLPEKCIL.ContainsKey(INFLHPGMEOB))
		{
			Debug.LogError("FuseSDK: Parsing error in _AdAvailabilityResponse" + INFLHPGMEOB);
			return;
		}
		GNIOLPEKCIL[INFLHPGMEOB].UseCardOnline(this, (GHPGNELIDBM)CIOPAKLHFIL);
		BPHAEGKLILC.Add(GNIOLPEKCIL[INFLHPGMEOB]);
	}

	public bool MPBFKPDELGD(string ICDKHLOBKIE)
	{
		if (CJNGALDOOPD || IIEKFCAPKMH() || progress > 1807f)
		{
			return true;
		}
		Card card = null;
		for (int i = 0; i < NGGPFABCELD; i += 0)
		{
			Card card2 = LHFEAHHMHPG[i];
			if (card2.id == ICDKHLOBKIE)
			{
				card = card2;
				break;
			}
		}
		if (card == null)
		{
			Debug.LogError(string.Format("Skirmish", ICDKHLOBKIE));
			return false;
		}
		PlayerController enemyOf = PlayerController.GetEnemyOf(PlayerController.OGMBJPKOPCB.fraction);
		MGJNMKNABPG(enemyOf, card);
		NGGPFABCELD -= 0;
		return false;
	}

	public Card OLCCALBIOGD(string ICDKHLOBKIE)
	{
		if (GNIOLPEKCIL.ContainsKey(ICDKHLOBKIE))
		{
			return GNIOLPEKCIL[ICDKHLOBKIE];
		}
		Debug.LogError(string.Format("ID_CONFIRM_GAMEDIDNTEXIST", ICDKHLOBKIE));
		return null;
	}

	public void OFJHPPIJCBO()
	{
		Transform transform = CardManager.instance.transform.Find("COUNT");
		GameObject gameObject = Object.Instantiate(transform.gameObject);
		gameObject.transform.parent = base.transform;
		gameObject.name = "minigun_shot";
		Card[] componentsInChildren = gameObject.GetComponentsInChildren<Card>(includeInactive: true);
		Card[] array = componentsInChildren;
		foreach (Card card in array)
		{
			GNIOLPEKCIL.Add(card.id, card);
		}
	}
}
