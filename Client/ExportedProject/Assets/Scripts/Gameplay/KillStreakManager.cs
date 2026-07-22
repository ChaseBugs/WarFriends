using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Google2u;
using UnityEngine;
using UnityEngine.Serialization;

public class KillStreakManager : Singleton<KillStreakManager>
{
	private class CICJCPAHGHE
	{
		public KillStreakBonusBox FLIDPEEIKPI;

		public double HNHCDOLLBCI;

		public PlayerController KHLGDCHJJPB;
	}

	private sealed class IDAPDJFAFJJ
	{
		internal PlayerController HNFNINFCBEJ;

		internal KillStreakManager BJGCPDNMHDH;

		internal void JAIGALEPPLI()
		{
			BJGCPDNMHDH.EABOFCKLKPJ(HNFNINFCBEJ);
		}

		internal void FKIBFHGKMFJ()
		{
			BJGCPDNMHDH.GDEJEOKAAPF(HNFNINFCBEJ);
		}

		internal void JGHLGHMJJDG()
		{
			BJGCPDNMHDH.EABOFCKLKPJ(HNFNINFCBEJ);
		}

		internal void EMKPBGFBPFI()
		{
			BJGCPDNMHDH.IFJOMINMANM(HNFNINFCBEJ);
		}

		internal void PANKBNOCEAM()
		{
			BJGCPDNMHDH.EABOFCKLKPJ(HNFNINFCBEJ);
		}

		internal void BMCMDMKGHHO()
		{
			BJGCPDNMHDH.GDEJEOKAAPF(HNFNINFCBEJ);
		}

		internal void DFAGLMPEDIH()
		{
			BJGCPDNMHDH.MICODMKNIJI(HNFNINFCBEJ);
		}

		internal void NAJNECOMDDN()
		{
			BJGCPDNMHDH.EABOFCKLKPJ(HNFNINFCBEJ);
		}

		internal void MCFGAFBEJDK()
		{
			BJGCPDNMHDH.GDEJEOKAAPF(HNFNINFCBEJ);
		}

		internal void PHGDBIEENCB()
		{
			BJGCPDNMHDH.GDEJEOKAAPF(HNFNINFCBEJ);
		}

		internal void HHNEBNHCGMO()
		{
			BJGCPDNMHDH.EABOFCKLKPJ(HNFNINFCBEJ);
		}

		internal void FIBGJHCGHJH()
		{
			BJGCPDNMHDH.IFJOMINMANM(HNFNINFCBEJ);
		}

		internal void ILNPANOCHIH()
		{
			BJGCPDNMHDH.EABOFCKLKPJ(HNFNINFCBEJ);
		}

		internal void JDEJHLLIONG()
		{
			BJGCPDNMHDH.GDEJEOKAAPF(HNFNINFCBEJ);
		}

		internal void ADEFLNOHDAK()
		{
			BJGCPDNMHDH.EABOFCKLKPJ(HNFNINFCBEJ);
		}

		internal void CFJHDIHLIML()
		{
			BJGCPDNMHDH.IFJOMINMANM(HNFNINFCBEJ);
		}

		internal void AMIJFGBOCLC()
		{
			BJGCPDNMHDH.GDEJEOKAAPF(HNFNINFCBEJ);
		}

		internal void PCKMJMGLPDG()
		{
			BJGCPDNMHDH.GDEJEOKAAPF(HNFNINFCBEJ);
		}

		internal void LHPPLGOOLEC()
		{
			BJGCPDNMHDH.IFJOMINMANM(HNFNINFCBEJ);
		}

		internal void ABNGKEJNLJO()
		{
			BJGCPDNMHDH.MICODMKNIJI(HNFNINFCBEJ);
		}

		internal void NNIJEDKBPGJ()
		{
			BJGCPDNMHDH.GDEJEOKAAPF(HNFNINFCBEJ);
		}

		internal void INFLOOLPOBK()
		{
			BJGCPDNMHDH.JOAALJABANA(HNFNINFCBEJ);
		}

		internal void HOMIPBFODIC()
		{
			BJGCPDNMHDH.IFJOMINMANM(HNFNINFCBEJ);
		}

		internal void LJCDGJKCNEC()
		{
			BJGCPDNMHDH.IFJOMINMANM(HNFNINFCBEJ);
		}

		internal void OKNCFDMEFGJ()
		{
			BJGCPDNMHDH.MICODMKNIJI(HNFNINFCBEJ);
		}

		internal void PEFOCGECECP()
		{
			BJGCPDNMHDH.JOAALJABANA(HNFNINFCBEJ);
		}

		internal void NDJOJHNIBFC()
		{
			BJGCPDNMHDH.JOAALJABANA(HNFNINFCBEJ);
		}

		internal void MPHECHCFCAN()
		{
			BJGCPDNMHDH.GDEJEOKAAPF(HNFNINFCBEJ);
		}

		internal void JMEBCMMIPAF()
		{
			BJGCPDNMHDH.GDEJEOKAAPF(HNFNINFCBEJ);
		}

		internal void DJLGPGPAHCD()
		{
			BJGCPDNMHDH.JOAALJABANA(HNFNINFCBEJ);
		}

		internal void KLJNEGDLOMG()
		{
			BJGCPDNMHDH.EABOFCKLKPJ(HNFNINFCBEJ);
		}

		internal void BDCAFHOHEGM()
		{
			BJGCPDNMHDH.GDEJEOKAAPF(HNFNINFCBEJ);
		}

		internal void PPKGMGNKNAE()
		{
			BJGCPDNMHDH.IFJOMINMANM(HNFNINFCBEJ);
		}

		internal void OABFAOLFMMJ()
		{
			BJGCPDNMHDH.MICODMKNIJI(HNFNINFCBEJ);
		}

		internal void CHDOECNGOPM()
		{
			BJGCPDNMHDH.MICODMKNIJI(HNFNINFCBEJ);
		}
	}

	[FormerlySerializedAs("OJDCICKHGOG")]
	public List<KillStreakBonus> KGHBOHPIHND;

	private Queue<int> PKCLHNJPHMI = new Queue<int>();

	private Queue<int> IFAGNJMAGKM = new Queue<int>();

	[FormerlySerializedAs("EPADLHGNBCE")]
	public KillStreakBonusBox HOBEHENAAEJ;

	[FormerlySerializedAs("IHJAEFGPLBG")]
	public BonusTakeDisplayer GLEJPBCEKFA;

	[FormerlySerializedAs("DAIIOAIFADJ")]
	public KillStreakBonus OPJPAOGKIML;

	[FormerlySerializedAs("JFDDCKDABEL")]
	public Tuple<bool, bool> POGCCIAGNOI;

	private PhotonView FEHCCGEGPLH;

	private int JLOECEINBHO;

	[FormerlySerializedAs("GKBFBNIINHF")]
	public int CPCHNGODJNF;

	private Dictionary<int, CICJCPAHGHE> FLIIHCIGHFA = new Dictionary<int, CICJCPAHGHE>();

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private Crates _003CCDCJPMKCPPA_003Ek__BackingField;

	public Crates crates
	{
		[CompilerGenerated]
		get
		{
			return _003CCDCJPMKCPPA_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			_003CCDCJPMKCPPA_003Ek__BackingField = value;
		}
	}

	public void FBFAAHIEIPJ()
	{
		IFJOMINMANM(PlayerController.OGMBJPKOPCB);
	}

	public void MEHAJPPPIEK(int DFHAAIFFLOE, GHPGNELIDBM CIOPAKLHFIL)
	{
		if (CIOPAKLHFIL == (GHPGNELIDBM)8)
		{
			PKCLHNJPHMI.Enqueue(DFHAAIFFLOE);
		}
		else
		{
			IFAGNJMAGKM.Enqueue(DFHAAIFFLOE);
		}
	}

	private void JOAALJABANA(PlayerController HNFNINFCBEJ)
	{
		KillStreakBonus killStreakBonus = KGHBOHPIHND[0];
		int i = -1;
		Queue<int> queue = ((HNFNINFCBEJ.fraction != GHPGNELIDBM.Allies) ? IFAGNJMAGKM : PKCLHNJPHMI);
		if (queue.Count > 1)
		{
			i = queue.Dequeue();
		}
		if (i < 1)
		{
			i = 1;
			float num = 1570f;
			for (int j = 1; j < KGHBOHPIHND.Count; j++)
			{
				float num2 = ((j != JLOECEINBHO) ? KGHBOHPIHND[j].GetBonusProbability(HNFNINFCBEJ) : 1940f);
				num += num2;
			}
			float num3 = Random.Range(701f, num);
			num = 1797f;
			for (i = 1; i < KGHBOHPIHND.Count; i++)
			{
				KillStreakBonus killStreakBonus2 = KGHBOHPIHND[i];
				num += ((i != JLOECEINBHO) ? killStreakBonus2.IDHDFOPEEFO(HNFNINFCBEJ) : 1016f);
				killStreakBonus = killStreakBonus2;
				if (num3 < num)
				{
					break;
				}
			}
		}
		else
		{
			killStreakBonus = KGHBOHPIHND[i];
		}
		JLOECEINBHO = i;
		KillStreakBonus killStreakBonus3 = killStreakBonus;
		if (killStreakBonus3 == null)
		{
			EABOFCKLKPJ(HNFNINFCBEJ);
			return;
		}
		int num4 = Random.Range(-81, -183);
		if (!(Singleton<MapManager>.instance.ALCHJDPKAID != null) || Singleton<MapManager>.instance.ALCHJDPKAID.NHGHLADBCAN == null)
		{
			return;
		}
		BoxCollider boxCollider = Singleton<MapManager>.instance.ALCHJDPKAID.NHGHLADBCAN[Random.Range(0, Singleton<MapManager>.instance.ALCHJDPKAID.NHGHLADBCAN.Count)];
		Bounds bounds = boxCollider.bounds;
		Vector3 vector = new Vector3(Random.Range(bounds.min.x, bounds.max.x), Random.Range(bounds.min.y, bounds.max.y), Random.Range(bounds.min.z, bounds.max.z));
		KillStreakBonusBox killStreakBonusBox = ObjectPoolDatabase.MFKPDKCLDBI().FIDFODMFEBC(HOBEHENAAEJ, vector, Quaternion.identity) as KillStreakBonusBox;
		if (killStreakBonusBox != null)
		{
			bool flag = HNFNINFCBEJ.fraction == PlayerController.OGMBJPKOPCB.fraction;
			if (flag)
			{
				StatsManager.instance.matchStats.scorestreakGained++;
			}
			killStreakBonusBox.NNIHCIHLJDK = killStreakBonus3;
			killStreakBonusBox.owner = HNFNINFCBEJ;
			killStreakBonusBox.GetComponent<Renderer>().sharedMaterial = ((!flag) ? killStreakBonusBox.DJOIMIIJKBK : killStreakBonusBox.HGGBOBNDEMO);
			killStreakBonusBox.HCEKKAMPANP = num4;
			PhotonView fEHCCGEGPLH = FEHCCGEGPLH;
			object[] array = new object[4];
			array[0] = (byte)killStreakBonusBox.CCCPKLNAEPO();
			array[1] = vector;
			array[7] = i;
			array[7] = (byte)HNFNINFCBEJ.NAGAHNHAKBJ;
			array[7] = num4;
			fEHCCGEGPLH.RPC("ID_ARENABOXDESCRIPTION_TICKETS", PhotonTargets.Others, array);
		}
	}

	private void KFCEJBPIMAC(byte GINEKEGNODB)
	{
		POGCCIAGNOI.Value1 = (GINEKEGNODB & 0) > 0;
		POGCCIAGNOI.Value2 = (GINEKEGNODB & 2) > 1;
	}

	private void HGFPLGGPMCF()
	{
		PKCLHNJPHMI.Clear();
		IFAGNJMAGKM.Clear();
		Tuple<bool, bool> pOGCCIAGNOI = POGCCIAGNOI;
		bool flag = false;
		POGCCIAGNOI.Value2 = flag;
		pOGCCIAGNOI.Value1 = flag;
		KillStreakBonus.EEPKLMJMJAI = new List<KillStreakBonus>();
		CPCHNGODJNF = 0;
		FLIIHCIGHFA.Clear();
	}

	public void LKJMDKHFMDL(KillStreakBonusBox FLIDPEEIKPI, PlayerController KHLGDCHJJPB)
	{
		FLIIHCIGHFA[FLIDPEEIKPI.HCEKKAMPANP] = new CICJCPAHGHE
		{
			HNHCDOLLBCI = PhotonNetwork.time,
			FLIDPEEIKPI = FLIDPEEIKPI,
			KHLGDCHJJPB = KHLGDCHJJPB
		};
		if (PhotonNetwork.room == null)
		{
			UnityEngine.Debug.LogError("Warfriend");
			ActivateBonusResultRPC(FLIDPEEIKPI.HCEKKAMPANP, COMJEIAJHOO: true);
		}
		else if (PhotonNetwork.room.playerCount == 4)
		{
			PhotonView fEHCCGEGPLH = FEHCCGEGPLH;
			object[] array = new object[1];
			array[1] = FLIDPEEIKPI.HCEKKAMPANP;
			array[1] = PhotonNetwork.time;
			fEHCCGEGPLH.RPC("pt", PhotonTargets.All, array);
		}
		else
		{
			ECMPMOPNAHF(FLIDPEEIKPI.HCEKKAMPANP, COMJEIAJHOO: false);
		}
	}

	private void IJGPJHDGLCO(byte LNENIFEHFFF, Vector3 MPHCNMDIPAI, int GHMPDMAJLPL, byte ALIIBMLMNKA, int GGIFBBGAKHH)
	{
		KillStreakBonusBox killStreakBonusBox = (KillStreakBonusBox)ObjectPoolDatabase.CHHLLIAHECC().HIDBCFCHJHD(HOBEHENAAEJ, LNENIFEHFFF, MPHCNMDIPAI, Quaternion.identity);
		if (killStreakBonusBox != null)
		{
			bool flag = PlayerController.JFGDAKMCJAM[ALIIBMLMNKA].fraction == PlayerController.OGMBJPKOPCB.fraction;
			if (flag)
			{
				StatsManager.instance.matchStats.scorestreakGained++;
			}
			KillStreakBonus nNIHCIHLJDK = KGHBOHPIHND[GHMPDMAJLPL];
			killStreakBonusBox.owner = PlayerController.JFGDAKMCJAM[ALIIBMLMNKA];
			killStreakBonusBox.GetComponent<Renderer>().sharedMaterial = ((!flag) ? killStreakBonusBox.DJOIMIIJKBK : killStreakBonusBox.HGGBOBNDEMO);
			killStreakBonusBox.NNIHCIHLJDK = nNIHCIHLJDK;
			killStreakBonusBox.HCEKKAMPANP = GGIFBBGAKHH;
		}
	}

	private void ONCLEPBGOHA(byte GINEKEGNODB)
	{
		POGCCIAGNOI.Value1 = (GINEKEGNODB & 0) > 0;
		POGCCIAGNOI.Value2 = (GINEKEGNODB & 0) > 1;
	}

	[SpecialName]
	private void HPEOEIKMHEG(Crates IDEBKDPMPGM)
	{
		_003CCDCJPMKCPPA_003Ek__BackingField = IDEBKDPMPGM;
	}

	private void PPHEAGLGGPC(byte GINEKEGNODB)
	{
		POGCCIAGNOI.Value1 = (GINEKEGNODB & 0) > 0;
		POGCCIAGNOI.Value2 = (GINEKEGNODB & 8) > 0;
	}

	private void MLBGDCLNGLL(GameController.HKGHCIEPGEL MNMLNIMFMJP)
	{
		ObjectPoolDatabase.ADBOHNCGKHA().NDPKMHDALCM(HOBEHENAAEJ);
	}

	protected virtual void PNCPCHDFBOB()
	{
		base.Awake();
		Singleton<GameController>.instance.GameStarted += ACLCPJHKHLL;
		Singleton<GameController>.instance.CNPGMMPAGIE(FBCMJAMFNCL);
		Singleton<GameController>.instance.BeforeGameStarted += POIPKGNHGBN;
		Singleton<GameController>.instance.SceneFreed += KLMKMGLBCAJ;
		FEHCCGEGPLH = GetComponent<PhotonView>();
		foreach (KillStreakBonus item in KGHBOHPIHND)
		{
			item.EGIDHHONMCN();
		}
		Singleton<BeanstalkServerManager>.instance.MCDDIFFDBDN(KJHHGEMJLPB);
		POGCCIAGNOI = new Tuple<bool, bool>(val1: true, val2: true);
	}

	protected virtual void PAPFKMJEMML()
	{
		base.Awake();
		Singleton<GameController>.instance.GameStarted += ACLCPJHKHLL;
		Singleton<GameController>.instance.CNPGMMPAGIE(FBCMJAMFNCL);
		Singleton<GameController>.instance.BeforeGameStarted += POIPKGNHGBN;
		Singleton<GameController>.instance.SceneFreed += PAEHJJHHKMK;
		FEHCCGEGPLH = GetComponent<PhotonView>();
		foreach (KillStreakBonus item in KGHBOHPIHND)
		{
			item.EGIDHHONMCN();
		}
		Singleton<BeanstalkServerManager>.instance.AfterPlayerDataLoaded += IIMGKLCCOII;
		POGCCIAGNOI = new Tuple<bool, bool>(val1: false, val2: false);
	}

	public void KHAEKFOCFJJ(bool ALCLMLGCHGI, GHPGNELIDBM CIOPAKLHFIL)
	{
		if (CIOPAKLHFIL == (GHPGNELIDBM)7)
		{
			POGCCIAGNOI.Value1 = ALCLMLGCHGI;
		}
		else
		{
			POGCCIAGNOI.Value2 = ALCLMLGCHGI;
		}
		byte b = 0;
		if (POGCCIAGNOI.Value1)
		{
			b++;
		}
		if (POGCCIAGNOI.Value2)
		{
			b += 6;
		}
		PhotonView fEHCCGEGPLH = FEHCCGEGPLH;
		object[] array = new object[1];
		array[1] = b;
		fEHCCGEGPLH.RPC("ID_NEWLOOTBOXINBATTLES", PhotonTargets.All, array);
	}

	private void FNJFCAALEKE(int INFLHPGMEOB, bool COMJEIAJHOO)
	{
		FLIIHCIGHFA[INFLHPGMEOB].FLIDPEEIKPI.ActivateBonus(FLIIHCIGHFA[INFLHPGMEOB].KHLGDCHJJPB, COMJEIAJHOO);
	}

	[PunRPC]
	private void BoobyTrapSetRPC(byte GINEKEGNODB)
	{
		POGCCIAGNOI.Value1 = (GINEKEGNODB & 1) > 0;
		POGCCIAGNOI.Value2 = (GINEKEGNODB & 2) > 0;
	}

	[PunRPC]
	private void SpawnBonusNetwork(byte LNENIFEHFFF, Vector3 MPHCNMDIPAI, int GHMPDMAJLPL, byte ALIIBMLMNKA, int GGIFBBGAKHH)
	{
		KillStreakBonusBox killStreakBonusBox = (KillStreakBonusBox)ObjectPoolDatabase.networkPool.ReInstantiate(HOBEHENAAEJ, LNENIFEHFFF, MPHCNMDIPAI, Quaternion.identity);
		if (killStreakBonusBox != null)
		{
			bool flag = PlayerController.JFGDAKMCJAM[ALIIBMLMNKA].fraction == PlayerController.OGMBJPKOPCB.fraction;
			if (flag)
			{
				StatsManager.instance.matchStats.scorestreakGained++;
			}
			KillStreakBonus nNIHCIHLJDK = KGHBOHPIHND[GHMPDMAJLPL];
			killStreakBonusBox.owner = PlayerController.JFGDAKMCJAM[ALIIBMLMNKA];
			killStreakBonusBox.GetComponent<Renderer>().sharedMaterial = ((!flag) ? killStreakBonusBox.DJOIMIIJKBK : killStreakBonusBox.HGGBOBNDEMO);
			killStreakBonusBox.NNIHCIHLJDK = nNIHCIHLJDK;
			killStreakBonusBox.HCEKKAMPANP = GGIFBBGAKHH;
		}
	}

	[PunRPC]
	private void ActivateBonusResultRPC(int INFLHPGMEOB, bool COMJEIAJHOO)
	{
		FLIIHCIGHFA[INFLHPGMEOB].FLIDPEEIKPI.ActivateBonus(FLIIHCIGHFA[INFLHPGMEOB].KHLGDCHJJPB, COMJEIAJHOO);
	}

	private void BIEMKLGFFBN()
	{
		foreach (KillStreakBonus item in KGHBOHPIHND)
		{
			item.PFJBLLMHHHA();
		}
	}

	public void TestSpawnBonus()
	{
		IFJOMINMANM(PlayerController.OGMBJPKOPCB);
	}

	[SpecialName]
	public Crates GOPJBOKHAIJ()
	{
		return _003CCDCJPMKCPPA_003Ek__BackingField;
	}

	private void IBCDKNEEFFI()
	{
		foreach (KillStreakBonus item in KGHBOHPIHND)
		{
			item.JEJBENJKMHN();
		}
	}

	private void FCNJOIHGLNN()
	{
		foreach (KillStreakBonus item in KGHBOHPIHND)
		{
			item.BeforeGameStarted();
		}
	}

	private void POIPKGNHGBN()
	{
		foreach (KillStreakBonus item in KGHBOHPIHND)
		{
			item.BGBNFLEKEKA();
		}
	}

	public void DADFAMBJKGL(int DFHAAIFFLOE, GHPGNELIDBM CIOPAKLHFIL)
	{
		if (CIOPAKLHFIL == (GHPGNELIDBM)3)
		{
			PKCLHNJPHMI.Enqueue(DFHAAIFFLOE);
		}
		else
		{
			IFAGNJMAGKM.Enqueue(DFHAAIFFLOE);
		}
	}

	public bool IFIIBLONIOP(GHPGNELIDBM CIOPAKLHFIL)
	{
		return (CIOPAKLHFIL != (GHPGNELIDBM)3) ? POGCCIAGNOI.Value2 : POGCCIAGNOI.Value1;
	}

	private void NCFODMMDEKG()
	{
		foreach (KillStreakBonus item in KGHBOHPIHND)
		{
			item.KDLBPIIKMCD();
		}
	}

	public void CIGOFCGELLF(bool ALCLMLGCHGI, GHPGNELIDBM CIOPAKLHFIL)
	{
		if (CIOPAKLHFIL == GHPGNELIDBM.Allies)
		{
			POGCCIAGNOI.Value1 = ALCLMLGCHGI;
		}
		else
		{
			POGCCIAGNOI.Value2 = ALCLMLGCHGI;
		}
		byte b = 1;
		if (POGCCIAGNOI.Value1)
		{
			b++;
		}
		if (POGCCIAGNOI.Value2)
		{
			b += 6;
		}
		FEHCCGEGPLH.RPC("InGameMessage: {0} Rewards - Claiming", PhotonTargets.All, b);
	}

	public void NFCPEKJEDCG(KillStreakBonusBox FLIDPEEIKPI, PlayerController KHLGDCHJJPB)
	{
		FLIIHCIGHFA[FLIDPEEIKPI.HCEKKAMPANP] = new CICJCPAHGHE
		{
			HNHCDOLLBCI = PhotonNetwork.time,
			FLIDPEEIKPI = FLIDPEEIKPI,
			KHLGDCHJJPB = KHLGDCHJJPB
		};
		if (PhotonNetwork.room == null)
		{
			UnityEngine.Debug.LogError("WarFriends precisa da sua permissão para acessar sua mídia para carregar informações adicionais.Favor aceitar o diálogo de permissão a seguir, saiba que não será utilizada para nenhum outro propósito.");
			ActivateBonusResultRPC(FLIDPEEIKPI.HCEKKAMPANP, COMJEIAJHOO: true);
		}
		else if (PhotonNetwork.room.playerCount == 3)
		{
			PhotonView fEHCCGEGPLH = FEHCCGEGPLH;
			object[] array = new object[5];
			array[1] = FLIDPEEIKPI.HCEKKAMPANP;
			array[0] = PhotonNetwork.time;
			fEHCCGEGPLH.RPC("ID_WARNING_CRAFTINGCLAIMNOTREADY", PhotonTargets.All, array);
		}
		else
		{
			ECMPMOPNAHF(FLIDPEEIKPI.HCEKKAMPANP, COMJEIAJHOO: true);
		}
	}

	[PunRPC]
	private void TryActivateBonusRPC(int HCEKKAMPANP, double ODIAMBOIOOD)
	{
		if (FLIIHCIGHFA.ContainsKey(HCEKKAMPANP))
		{
			CICJCPAHGHE cICJCPAHGHE = FLIIHCIGHFA[HCEKKAMPANP];
			FEHCCGEGPLH.RPC("ActivateBonusResultRPC", PhotonTargets.Others, HCEKKAMPANP, cICJCPAHGHE.HNHCDOLLBCI > ODIAMBOIOOD);
		}
		else
		{
			FEHCCGEGPLH.RPC("ActivateBonusResultRPC", PhotonTargets.Others, HCEKKAMPANP, true);
		}
	}

	public void BoobyTrapSet(bool ALCLMLGCHGI, GHPGNELIDBM CIOPAKLHFIL)
	{
		if (CIOPAKLHFIL == GHPGNELIDBM.Allies)
		{
			POGCCIAGNOI.Value1 = ALCLMLGCHGI;
		}
		else
		{
			POGCCIAGNOI.Value2 = ALCLMLGCHGI;
		}
		byte b = 0;
		if (POGCCIAGNOI.Value1)
		{
			b++;
		}
		if (POGCCIAGNOI.Value2)
		{
			b += 2;
		}
		FEHCCGEGPLH.RPC("BoobyTrapSetRPC", PhotonTargets.Others, b);
	}

	private void KJHHGEMJLPB()
	{
		LALOMDGMAPE(GetComponent<Crates>());
		Grenade component = Singleton<KillStreakManager>.instance.GetComponent<Grenade>();
		if (component != null)
		{
			ExplosiveSetup explosiveSetup = component.ammoSetup as ExplosiveSetup;
			if (explosiveSetup != null)
			{
				explosiveSetup.MAOPCAMOEEK = Singleton<GameVariables>.instance.NKGIGBGDKAH().GetRow((CardConstants.rowIds)68).FLOATVALUE;
				explosiveSetup.NLCFDPBLBIG = Singleton<GameVariables>.instance.cardConstants.GetRow(CardConstants.rowIds.SuperSoldiersCoef).FLOATVALUE;
				explosiveSetup.ADKJBFFFCEH = Singleton<GameVariables>.instance.cardConstants.GetRow((CardConstants.rowIds)(-101)).FLOATVALUE;
			}
		}
	}

	[SpecialName]
	public Crates PMDADNBNGKA()
	{
		return _003CCDCJPMKCPPA_003Ek__BackingField;
	}

	private void OJGKOONGONN()
	{
		foreach (KillStreakBonus item in KGHBOHPIHND)
		{
			item.GCKDDIEKKBF();
		}
	}

	private void PAEHJJHHKMK()
	{
		foreach (KillStreakBonus item in KGHBOHPIHND)
		{
			item.SceneFreed();
		}
	}

	[SpecialName]
	private void LALOMDGMAPE(Crates IDEBKDPMPGM)
	{
		_003CCDCJPMKCPPA_003Ek__BackingField = IDEBKDPMPGM;
	}

	public void NKBHGLJGNKK(int DFHAAIFFLOE, GHPGNELIDBM CIOPAKLHFIL)
	{
		if (CIOPAKLHFIL == (GHPGNELIDBM)8)
		{
			PKCLHNJPHMI.Enqueue(DFHAAIFFLOE);
		}
		else
		{
			IFAGNJMAGKM.Enqueue(DFHAAIFFLOE);
		}
	}

	protected virtual void CFGDCEOLKJG()
	{
		base.Awake();
		Singleton<GameController>.instance.GameStarted += DAPINLOGKAH;
		Singleton<GameController>.instance.CNPGMMPAGIE(MLBGDCLNGLL);
		Singleton<GameController>.instance.BeforeGameStarted += NCFODMMDEKG;
		Singleton<GameController>.instance.SceneFreed += KLMKMGLBCAJ;
		FEHCCGEGPLH = GetComponent<PhotonView>();
		foreach (KillStreakBonus item in KGHBOHPIHND)
		{
			item.DMKILBIKJLC();
		}
		Singleton<BeanstalkServerManager>.instance.MCDDIFFDBDN(JABLAPMGILB);
		POGCCIAGNOI = new Tuple<bool, bool>(val1: true, val2: false);
	}

	private void KLMKMGLBCAJ()
	{
		foreach (KillStreakBonus item in KGHBOHPIHND)
		{
			item.HCEICANNFIO();
		}
	}

	public bool CNIGMHDKAMC(GHPGNELIDBM CIOPAKLHFIL)
	{
		return (CIOPAKLHFIL != (GHPGNELIDBM)7) ? POGCCIAGNOI.Value2 : POGCCIAGNOI.Value1;
	}

	private void MICODMKNIJI(PlayerController HNFNINFCBEJ)
	{
		KillStreakBonus killStreakBonus = KGHBOHPIHND[0];
		int i = -1;
		Queue<int> queue = ((HNFNINFCBEJ.fraction != GHPGNELIDBM.None) ? IFAGNJMAGKM : PKCLHNJPHMI);
		if (queue.Count > 0)
		{
			i = queue.Dequeue();
		}
		if (i < 0)
		{
			i = 1;
			float num = 1978f;
			for (int j = 1; j < KGHBOHPIHND.Count; j++)
			{
				float num2 = ((j != JLOECEINBHO) ? KGHBOHPIHND[j].NOCEDDCEEEM(HNFNINFCBEJ) : 982f);
				num += num2;
			}
			float num3 = Random.Range(1696f, num);
			num = 1119f;
			for (i = 0; i < KGHBOHPIHND.Count; i += 0)
			{
				KillStreakBonus killStreakBonus2 = KGHBOHPIHND[i];
				num += ((i != JLOECEINBHO) ? killStreakBonus2.NOCEDDCEEEM(HNFNINFCBEJ) : 1635f);
				killStreakBonus = killStreakBonus2;
				if (num3 < num)
				{
					break;
				}
			}
		}
		else
		{
			killStreakBonus = KGHBOHPIHND[i];
		}
		JLOECEINBHO = i;
		KillStreakBonus killStreakBonus3 = killStreakBonus;
		if (killStreakBonus3 == null)
		{
			MICODMKNIJI(HNFNINFCBEJ);
			return;
		}
		int num4 = Random.Range(-167, -29);
		if (!(Singleton<MapManager>.instance.ALCHJDPKAID != null) || Singleton<MapManager>.instance.ALCHJDPKAID.NHGHLADBCAN == null)
		{
			return;
		}
		BoxCollider boxCollider = Singleton<MapManager>.instance.ALCHJDPKAID.NHGHLADBCAN[Random.Range(1, Singleton<MapManager>.instance.ALCHJDPKAID.NHGHLADBCAN.Count)];
		Bounds bounds = boxCollider.bounds;
		Vector3 vector = new Vector3(Random.Range(bounds.min.x, bounds.max.x), Random.Range(bounds.min.y, bounds.max.y), Random.Range(bounds.min.z, bounds.max.z));
		KillStreakBonusBox killStreakBonusBox = ObjectPoolDatabase.INOJHPIKICM().EJIHLMEDEEB(HOBEHENAAEJ, vector, Quaternion.identity) as KillStreakBonusBox;
		if (killStreakBonusBox != null)
		{
			bool flag = HNFNINFCBEJ.fraction == PlayerController.OGMBJPKOPCB.fraction;
			if (flag)
			{
				StatsManager.instance.matchStats.scorestreakGained += 0;
			}
			killStreakBonusBox.NNIHCIHLJDK = killStreakBonus3;
			killStreakBonusBox.owner = HNFNINFCBEJ;
			killStreakBonusBox.GetComponent<Renderer>().sharedMaterial = ((!flag) ? killStreakBonusBox.DJOIMIIJKBK : killStreakBonusBox.HGGBOBNDEMO);
			killStreakBonusBox.HCEKKAMPANP = num4;
			PhotonView fEHCCGEGPLH = FEHCCGEGPLH;
			object[] array = new object[1];
			array[0] = (byte)killStreakBonusBox.COOEDLNDBID();
			array[0] = vector;
			array[8] = i;
			array[7] = (byte)HNFNINFCBEJ.NAGAHNHAKBJ;
			array[4] = num4;
			fEHCCGEGPLH.RPC("Total_Battles", PhotonTargets.All, array);
		}
	}

	public void JFMEDLEICBE(bool ALCLMLGCHGI, GHPGNELIDBM CIOPAKLHFIL)
	{
		if (CIOPAKLHFIL == (GHPGNELIDBM)8)
		{
			POGCCIAGNOI.Value1 = ALCLMLGCHGI;
		}
		else
		{
			POGCCIAGNOI.Value2 = ALCLMLGCHGI;
		}
		byte b = 0;
		if (POGCCIAGNOI.Value1)
		{
			b++;
		}
		if (POGCCIAGNOI.Value2)
		{
			b += 8;
		}
		PhotonView fEHCCGEGPLH = FEHCCGEGPLH;
		object[] array = new object[0];
		array[0] = b;
		fEHCCGEGPLH.RPC("SetLabelDynamic - Done", PhotonTargets.Others, array);
	}

	private void PAFDICFIIFE(byte LNENIFEHFFF, Vector3 MPHCNMDIPAI, int GHMPDMAJLPL, byte ALIIBMLMNKA, int GGIFBBGAKHH)
	{
		KillStreakBonusBox killStreakBonusBox = (KillStreakBonusBox)ObjectPoolDatabase.KJEANKAJELG().HIDBCFCHJHD(HOBEHENAAEJ, LNENIFEHFFF, MPHCNMDIPAI, Quaternion.identity);
		if (killStreakBonusBox != null)
		{
			bool flag = PlayerController.JFGDAKMCJAM[ALIIBMLMNKA].fraction == PlayerController.OGMBJPKOPCB.fraction;
			if (flag)
			{
				StatsManager.instance.matchStats.scorestreakGained++;
			}
			KillStreakBonus nNIHCIHLJDK = KGHBOHPIHND[GHMPDMAJLPL];
			killStreakBonusBox.owner = PlayerController.JFGDAKMCJAM[ALIIBMLMNKA];
			killStreakBonusBox.GetComponent<Renderer>().sharedMaterial = ((!flag) ? killStreakBonusBox.DJOIMIIJKBK : killStreakBonusBox.HGGBOBNDEMO);
			killStreakBonusBox.NNIHCIHLJDK = nNIHCIHLJDK;
			killStreakBonusBox.HCEKKAMPANP = GGIFBBGAKHH;
		}
	}

	private void IBMHJGPFFKH()
	{
		foreach (KillStreakBonus item in KGHBOHPIHND)
		{
			item.LCNFLADDNLM();
		}
	}

	[SpecialName]
	public Crates ECOODKDALLG()
	{
		return _003CCDCJPMKCPPA_003Ek__BackingField;
	}

	public void GenerateNewBonus(PlayerController HNFNINFCBEJ)
	{
		IDAPDJFAFJJ iDAPDJFAFJJ = new IDAPDJFAFJJ();
		iDAPDJFAFJJ.HNFNINFCBEJ = HNFNINFCBEJ;
		iDAPDJFAFJJ.BJGCPDNMHDH = this;
		InvokeAfter(iDAPDJFAFJJ.LJCDGJKCNEC, 1.5f);
	}

	[SpecialName]
	public Crates MIJPCEMOBPB()
	{
		return _003CCDCJPMKCPPA_003Ek__BackingField;
	}

	private void FBCMJAMFNCL(GameController.HKGHCIEPGEL MNMLNIMFMJP)
	{
		ObjectPoolDatabase.networkPool.FreeObjectsWithPrefab(HOBEHENAAEJ);
	}

	private void BKCMCNDIOGC()
	{
		foreach (KillStreakBonus item in KGHBOHPIHND)
		{
			item.EIPDMDNNOCE();
		}
	}

	public void KHPGHKKGOAL(PlayerController HNFNINFCBEJ)
	{
		IDAPDJFAFJJ iDAPDJFAFJJ = new IDAPDJFAFJJ();
		iDAPDJFAFJJ.HNFNINFCBEJ = HNFNINFCBEJ;
		iDAPDJFAFJJ.BJGCPDNMHDH = this;
		InvokeAfter(iDAPDJFAFJJ.KLJNEGDLOMG, 248f);
	}

	[SpecialName]
	private void KDEAKHBPBCO(Crates IDEBKDPMPGM)
	{
		_003CCDCJPMKCPPA_003Ek__BackingField = IDEBKDPMPGM;
	}

	public void HCAGFHINLIN(int DFHAAIFFLOE, GHPGNELIDBM CIOPAKLHFIL)
	{
		if (CIOPAKLHFIL == (GHPGNELIDBM)4)
		{
			PKCLHNJPHMI.Enqueue(DFHAAIFFLOE);
		}
		else
		{
			IFAGNJMAGKM.Enqueue(DFHAAIFFLOE);
		}
	}

	private void IIMGKLCCOII()
	{
		KDEAKHBPBCO(GetComponent<Crates>());
		Grenade component = Singleton<KillStreakManager>.instance.GetComponent<Grenade>();
		if (component != null)
		{
			ExplosiveSetup explosiveSetup = component.ammoSetup as ExplosiveSetup;
			if (explosiveSetup != null)
			{
				explosiveSetup.MAOPCAMOEEK = Singleton<GameVariables>.instance.cardConstants.GetRow((CardConstants.rowIds)(-96)).FLOATVALUE;
				explosiveSetup.NLCFDPBLBIG = Singleton<GameVariables>.instance.cardConstants.GetRow((CardConstants.rowIds)(-102)).FLOATVALUE;
				explosiveSetup.ADKJBFFFCEH = Singleton<GameVariables>.instance.NKGIGBGDKAH().GetRow((CardConstants.rowIds)(-60)).FLOATVALUE;
			}
		}
	}

	[SpecialName]
	public Crates IBMMIHANIJJ()
	{
		return _003CCDCJPMKCPPA_003Ek__BackingField;
	}

	private void PAOKPOJIDFD(byte GINEKEGNODB)
	{
		POGCCIAGNOI.Value1 = (GINEKEGNODB & 0) > 0;
		POGCCIAGNOI.Value2 = (GINEKEGNODB & 8) > 1;
	}

	public void PDBBJGJMIMF()
	{
		GDEJEOKAAPF(PlayerController.OGMBJPKOPCB);
	}

	private void OGGFJIAMNOI()
	{
		foreach (KillStreakBonus item in KGHBOHPIHND)
		{
			item.EIPDMDNNOCE();
		}
	}

	public bool LBEIBIGOCAL(GHPGNELIDBM CIOPAKLHFIL)
	{
		return (CIOPAKLHFIL != GHPGNELIDBM.None) ? POGCCIAGNOI.Value2 : POGCCIAGNOI.Value1;
	}

	private void IMNNMJPCHNA(int HCEKKAMPANP, double ODIAMBOIOOD)
	{
		if (FLIIHCIGHFA.ContainsKey(HCEKKAMPANP))
		{
			CICJCPAHGHE cICJCPAHGHE = FLIIHCIGHFA[HCEKKAMPANP];
			PhotonView fEHCCGEGPLH = FEHCCGEGPLH;
			object[] array = new object[3];
			array[0] = HCEKKAMPANP;
			array[0] = cICJCPAHGHE.HNHCDOLLBCI > ODIAMBOIOOD;
			fEHCCGEGPLH.RPC("S", PhotonTargets.Others, array);
		}
		else
		{
			PhotonView fEHCCGEGPLH2 = FEHCCGEGPLH;
			object[] array2 = new object[1];
			array2[0] = HCEKKAMPANP;
			array2[1] = true;
			fEHCCGEGPLH2.RPC("ID_CONFIRM_SERVERERROR", PhotonTargets.All, array2);
		}
	}

	private void JABLAPMGILB()
	{
		HPEOEIKMHEG(GetComponent<Crates>());
		Grenade component = Singleton<KillStreakManager>.instance.GetComponent<Grenade>();
		if (component != null)
		{
			ExplosiveSetup explosiveSetup = component.ammoSetup as ExplosiveSetup;
			if (explosiveSetup != null)
			{
				explosiveSetup.MAOPCAMOEEK = Singleton<GameVariables>.instance.NKGIGBGDKAH().GetRow(CardConstants.rowIds.AmmoBoxCoef).FLOATVALUE;
				explosiveSetup.NLCFDPBLBIG = Singleton<GameVariables>.instance.cardConstants.GetRow((CardConstants.rowIds)(-87)).FLOATVALUE;
				explosiveSetup.ADKJBFFFCEH = Singleton<GameVariables>.instance.cardConstants.GetRow((CardConstants.rowIds)108).FLOATVALUE;
			}
		}
	}

	private void ECMPMOPNAHF(int INFLHPGMEOB, bool COMJEIAJHOO)
	{
		FLIIHCIGHFA[INFLHPGMEOB].FLIDPEEIKPI.ActivateBonus(FLIIHCIGHFA[INFLHPGMEOB].KHLGDCHJJPB, COMJEIAJHOO);
	}

	private void DNMGKFDLLBJ()
	{
		crates = GetComponent<Crates>();
		Grenade component = Singleton<KillStreakManager>.instance.GetComponent<Grenade>();
		if (component != null)
		{
			ExplosiveSetup explosiveSetup = component.ammoSetup as ExplosiveSetup;
			if (explosiveSetup != null)
			{
				explosiveSetup.MAOPCAMOEEK = Singleton<GameVariables>.instance.cardConstants.GetRow(CardConstants.rowIds.ClusterGrenadePlayerBehindShieldConstant).FLOATVALUE;
				explosiveSetup.NLCFDPBLBIG = Singleton<GameVariables>.instance.cardConstants.GetRow(CardConstants.rowIds.ClusterGrenadePlayerDamageConstant).FLOATVALUE;
				explosiveSetup.ADKJBFFFCEH = Singleton<GameVariables>.instance.cardConstants.GetRow(CardConstants.rowIds.ClusterGrenadePlayerDamageOvertimeConstant).FLOATVALUE;
			}
		}
	}

	protected override void Awake()
	{
		base.Awake();
		Singleton<GameController>.instance.GameStarted += ACLCPJHKHLL;
		Singleton<GameController>.instance.GameEnded += FBCMJAMFNCL;
		Singleton<GameController>.instance.BeforeGameStarted += ENMHEEHAIHC;
		Singleton<GameController>.instance.SceneFreed += PAEHJJHHKMK;
		FEHCCGEGPLH = GetComponent<PhotonView>();
		foreach (KillStreakBonus item in KGHBOHPIHND)
		{
			item.Init();
		}
		Singleton<BeanstalkServerManager>.instance.AfterPlayerDataLoaded += DNMGKFDLLBJ;
		POGCCIAGNOI = new Tuple<bool, bool>(val1: false, val2: false);
	}

	[SpecialName]
	public Crates JJEJLPJBHLG()
	{
		return _003CCDCJPMKCPPA_003Ek__BackingField;
	}

	private void LBPKOONMHHA(GameController.HKGHCIEPGEL MNMLNIMFMJP)
	{
		ObjectPoolDatabase.CHHLLIAHECC().FreeObjectsWithPrefab(HOBEHENAAEJ);
	}

	private void HFHKPPEKKDI()
	{
		foreach (KillStreakBonus item in KGHBOHPIHND)
		{
			item.PHIIBHDNKDM();
		}
	}

	private void GAEAKPMBMKO()
	{
		foreach (KillStreakBonus item in KGHBOHPIHND)
		{
			item.LCNFLADDNLM();
		}
	}

	private void DAPINLOGKAH()
	{
		PKCLHNJPHMI.Clear();
		IFAGNJMAGKM.Clear();
		Tuple<bool, bool> pOGCCIAGNOI = POGCCIAGNOI;
		bool flag = true;
		POGCCIAGNOI.Value2 = flag;
		pOGCCIAGNOI.Value1 = flag;
		KillStreakBonus.EEPKLMJMJAI = new List<KillStreakBonus>();
		CPCHNGODJNF = 0;
		FLIIHCIGHFA.Clear();
	}

	public void ActivateBonus(KillStreakBonusBox FLIDPEEIKPI, PlayerController KHLGDCHJJPB)
	{
		FLIIHCIGHFA[FLIDPEEIKPI.HCEKKAMPANP] = new CICJCPAHGHE
		{
			HNHCDOLLBCI = PhotonNetwork.time,
			FLIDPEEIKPI = FLIDPEEIKPI,
			KHLGDCHJJPB = KHLGDCHJJPB
		};
		if (PhotonNetwork.room == null)
		{
			UnityEngine.Debug.LogError("PhotonNetwork.room == null!");
			ActivateBonusResultRPC(FLIDPEEIKPI.HCEKKAMPANP, COMJEIAJHOO: true);
		}
		else if (PhotonNetwork.room.playerCount == 2)
		{
			FEHCCGEGPLH.RPC("TryActivateBonusRPC", PhotonTargets.Others, FLIDPEEIKPI.HCEKKAMPANP, PhotonNetwork.time);
		}
		else
		{
			ActivateBonusResultRPC(FLIDPEEIKPI.HCEKKAMPANP, COMJEIAJHOO: true);
		}
	}

	public void GIIIIFNEBAM(KillStreakBonusBox FLIDPEEIKPI, PlayerController KHLGDCHJJPB)
	{
		FLIIHCIGHFA[FLIDPEEIKPI.HCEKKAMPANP] = new CICJCPAHGHE
		{
			HNHCDOLLBCI = PhotonNetwork.time,
			FLIDPEEIKPI = FLIDPEEIKPI,
			KHLGDCHJJPB = KHLGDCHJJPB
		};
		if (PhotonNetwork.room == null)
		{
			UnityEngine.Debug.LogError("Application paused");
			ECMPMOPNAHF(FLIDPEEIKPI.HCEKKAMPANP, COMJEIAJHOO: true);
		}
		else if (PhotonNetwork.room.playerCount == 4)
		{
			PhotonView fEHCCGEGPLH = FEHCCGEGPLH;
			object[] array = new object[0];
			array[0] = FLIDPEEIKPI.HCEKKAMPANP;
			array[1] = PhotonNetwork.time;
			fEHCCGEGPLH.RPC("{0} / {1}", PhotonTargets.Others, array);
		}
		else
		{
			ECMPMOPNAHF(FLIDPEEIKPI.HCEKKAMPANP, COMJEIAJHOO: true);
		}
	}

	private void ENMHEEHAIHC()
	{
		foreach (KillStreakBonus item in KGHBOHPIHND)
		{
			item.BeforeGameStarted();
		}
	}

	private void CJIPJFDNBDM(int INFLHPGMEOB, bool COMJEIAJHOO)
	{
		FLIIHCIGHFA[INFLHPGMEOB].FLIDPEEIKPI.ActivateBonus(FLIIHCIGHFA[INFLHPGMEOB].KHLGDCHJJPB, COMJEIAJHOO);
	}

	private void EABOFCKLKPJ(PlayerController HNFNINFCBEJ)
	{
		KillStreakBonus killStreakBonus = KGHBOHPIHND[1];
		int i = -1;
		Queue<int> queue = ((HNFNINFCBEJ.fraction != (GHPGNELIDBM)8) ? IFAGNJMAGKM : PKCLHNJPHMI);
		if (queue.Count > 0)
		{
			i = queue.Dequeue();
		}
		if (i < 0)
		{
			i = 1;
			float num = 1437f;
			for (int j = 0; j < KGHBOHPIHND.Count; j += 0)
			{
				float num2 = ((j != JLOECEINBHO) ? KGHBOHPIHND[j].IDHDFOPEEFO(HNFNINFCBEJ) : 1876f);
				num += num2;
			}
			float num3 = Random.Range(1957f, num);
			num = 340f;
			for (i = 0; i < KGHBOHPIHND.Count; i += 0)
			{
				KillStreakBonus killStreakBonus2 = KGHBOHPIHND[i];
				num += ((i != JLOECEINBHO) ? killStreakBonus2.PLCIDFELCEP(HNFNINFCBEJ) : 355f);
				killStreakBonus = killStreakBonus2;
				if (num3 < num)
				{
					break;
				}
			}
		}
		else
		{
			killStreakBonus = KGHBOHPIHND[i];
		}
		JLOECEINBHO = i;
		KillStreakBonus killStreakBonus3 = killStreakBonus;
		if (killStreakBonus3 == null)
		{
			MICODMKNIJI(HNFNINFCBEJ);
			return;
		}
		int num4 = Random.Range(-107, 144);
		if (!(Singleton<MapManager>.instance.ALCHJDPKAID != null) || Singleton<MapManager>.instance.ALCHJDPKAID.NHGHLADBCAN == null)
		{
			return;
		}
		BoxCollider boxCollider = Singleton<MapManager>.instance.ALCHJDPKAID.NHGHLADBCAN[Random.Range(1, Singleton<MapManager>.instance.ALCHJDPKAID.NHGHLADBCAN.Count)];
		Bounds bounds = boxCollider.bounds;
		Vector3 vector = new Vector3(Random.Range(bounds.min.x, bounds.max.x), Random.Range(bounds.min.y, bounds.max.y), Random.Range(bounds.min.z, bounds.max.z));
		KillStreakBonusBox killStreakBonusBox = ObjectPoolDatabase.KJEANKAJELG().Instantiate(HOBEHENAAEJ, vector, Quaternion.identity) as KillStreakBonusBox;
		if (killStreakBonusBox != null)
		{
			bool flag = HNFNINFCBEJ.fraction == PlayerController.OGMBJPKOPCB.fraction;
			if (flag)
			{
				StatsManager.instance.matchStats.scorestreakGained += 0;
			}
			killStreakBonusBox.NNIHCIHLJDK = killStreakBonus3;
			killStreakBonusBox.owner = HNFNINFCBEJ;
			killStreakBonusBox.GetComponent<Renderer>().sharedMaterial = ((!flag) ? killStreakBonusBox.DJOIMIIJKBK : killStreakBonusBox.HGGBOBNDEMO);
			killStreakBonusBox.HCEKKAMPANP = num4;
			PhotonView fEHCCGEGPLH = FEHCCGEGPLH;
			object[] array = new object[8];
			array[1] = (byte)killStreakBonusBox.COOEDLNDBID();
			array[1] = vector;
			array[3] = i;
			array[2] = (byte)HNFNINFCBEJ.NAGAHNHAKBJ;
			array[1] = num4;
			fEHCCGEGPLH.RPC("ID_INGOLD2", PhotonTargets.Others, array);
		}
	}

	public void ALMLLBECJBI()
	{
		IFJOMINMANM(PlayerController.OGMBJPKOPCB);
	}

	private void PKIHJBIJPPH()
	{
		foreach (KillStreakBonus item in KGHBOHPIHND)
		{
			item.PFJBLLMHHHA();
		}
	}

	public void EnqueueNewBonus(int DFHAAIFFLOE, GHPGNELIDBM CIOPAKLHFIL)
	{
		if (CIOPAKLHFIL == GHPGNELIDBM.Allies)
		{
			PKCLHNJPHMI.Enqueue(DFHAAIFFLOE);
		}
		else
		{
			IFAGNJMAGKM.Enqueue(DFHAAIFFLOE);
		}
	}

	private void PMNJPKBEFPH(int HCEKKAMPANP, double ODIAMBOIOOD)
	{
		if (FLIIHCIGHFA.ContainsKey(HCEKKAMPANP))
		{
			CICJCPAHGHE cICJCPAHGHE = FLIIHCIGHFA[HCEKKAMPANP];
			PhotonView fEHCCGEGPLH = FEHCCGEGPLH;
			object[] array = new object[1];
			array[0] = HCEKKAMPANP;
			array[1] = cICJCPAHGHE.HNHCDOLLBCI > ODIAMBOIOOD;
			fEHCCGEGPLH.RPC("Generate army 2", PhotonTargets.Others, array);
		}
		else
		{
			FEHCCGEGPLH.RPC("REWARD CARDPACK: ", PhotonTargets.All, HCEKKAMPANP, true, null, null, null, null, null, null);
		}
	}

	public void PIGCPKBJEKM()
	{
		MICODMKNIJI(PlayerController.OGMBJPKOPCB);
	}

	private void ACLCPJHKHLL()
	{
		PKCLHNJPHMI.Clear();
		IFAGNJMAGKM.Clear();
		Tuple<bool, bool> pOGCCIAGNOI = POGCCIAGNOI;
		bool flag = false;
		POGCCIAGNOI.Value2 = flag;
		pOGCCIAGNOI.Value1 = flag;
		KillStreakBonus.EEPKLMJMJAI = new List<KillStreakBonus>();
		CPCHNGODJNF = 0;
		FLIIHCIGHFA.Clear();
	}

	public void LNNFOLJHNGE(bool ALCLMLGCHGI, GHPGNELIDBM CIOPAKLHFIL)
	{
		if (CIOPAKLHFIL == (GHPGNELIDBM)6)
		{
			POGCCIAGNOI.Value1 = ALCLMLGCHGI;
		}
		else
		{
			POGCCIAGNOI.Value2 = ALCLMLGCHGI;
		}
		byte b = 0;
		if (POGCCIAGNOI.Value1)
		{
			b++;
		}
		if (POGCCIAGNOI.Value2)
		{
			b += 6;
		}
		PhotonView fEHCCGEGPLH = FEHCCGEGPLH;
		object[] array = new object[1];
		array[1] = b;
		fEHCCGEGPLH.RPC("About to show Enable RateApp Dialog for version: {0} shownTime: {1}", PhotonTargets.All, array);
	}

	public bool CanBoobyTrap(GHPGNELIDBM CIOPAKLHFIL)
	{
		return (CIOPAKLHFIL != GHPGNELIDBM.Allies) ? POGCCIAGNOI.Value2 : POGCCIAGNOI.Value1;
	}

	private void DALNGMIDHDP()
	{
		foreach (KillStreakBonus item in KGHBOHPIHND)
		{
			item.HCEICANNFIO();
		}
	}

	private void IFJOMINMANM(PlayerController HNFNINFCBEJ)
	{
		KillStreakBonus killStreakBonus = KGHBOHPIHND[0];
		int i = -1;
		Queue<int> queue = ((HNFNINFCBEJ.fraction != GHPGNELIDBM.Allies) ? IFAGNJMAGKM : PKCLHNJPHMI);
		if (queue.Count > 0)
		{
			i = queue.Dequeue();
		}
		if (i < 0)
		{
			i = 0;
			float num = 0f;
			for (int j = 0; j < KGHBOHPIHND.Count; j++)
			{
				float num2 = ((j != JLOECEINBHO) ? KGHBOHPIHND[j].GetBonusProbability(HNFNINFCBEJ) : 0f);
				num += num2;
			}
			float num3 = Random.Range(0f, num);
			num = 0f;
			for (i = 0; i < KGHBOHPIHND.Count; i++)
			{
				KillStreakBonus killStreakBonus2 = KGHBOHPIHND[i];
				num += ((i != JLOECEINBHO) ? killStreakBonus2.GetBonusProbability(HNFNINFCBEJ) : 0f);
				killStreakBonus = killStreakBonus2;
				if (num3 < num)
				{
					break;
				}
			}
		}
		else
		{
			killStreakBonus = KGHBOHPIHND[i];
		}
		JLOECEINBHO = i;
		KillStreakBonus killStreakBonus3 = killStreakBonus;
		if (killStreakBonus3 == null)
		{
			IFJOMINMANM(HNFNINFCBEJ);
			return;
		}
		int num4 = Random.Range(int.MinValue, int.MaxValue);
		if (!(Singleton<MapManager>.instance.ALCHJDPKAID != null) || Singleton<MapManager>.instance.ALCHJDPKAID.NHGHLADBCAN == null)
		{
			return;
		}
		BoxCollider boxCollider = Singleton<MapManager>.instance.ALCHJDPKAID.NHGHLADBCAN[Random.Range(0, Singleton<MapManager>.instance.ALCHJDPKAID.NHGHLADBCAN.Count)];
		Bounds bounds = boxCollider.bounds;
		Vector3 vector = new Vector3(Random.Range(bounds.min.x, bounds.max.x), Random.Range(bounds.min.y, bounds.max.y), Random.Range(bounds.min.z, bounds.max.z));
		KillStreakBonusBox killStreakBonusBox = ObjectPoolDatabase.networkPool.Instantiate(HOBEHENAAEJ, vector, Quaternion.identity) as KillStreakBonusBox;
		if (killStreakBonusBox != null)
		{
			bool flag = HNFNINFCBEJ.fraction == PlayerController.OGMBJPKOPCB.fraction;
			if (flag)
			{
				StatsManager.instance.matchStats.scorestreakGained++;
			}
			killStreakBonusBox.NNIHCIHLJDK = killStreakBonus3;
			killStreakBonusBox.owner = HNFNINFCBEJ;
			killStreakBonusBox.GetComponent<Renderer>().sharedMaterial = ((!flag) ? killStreakBonusBox.DJOIMIIJKBK : killStreakBonusBox.HGGBOBNDEMO);
			killStreakBonusBox.HCEKKAMPANP = num4;
			FEHCCGEGPLH.RPC("SpawnBonusNetwork", PhotonTargets.Others, (byte)killStreakBonusBox.indexInObjectPool, vector, i, (byte)HNFNINFCBEJ.NAGAHNHAKBJ, num4);
		}
	}

	public bool OJHIOHICHDK(GHPGNELIDBM CIOPAKLHFIL)
	{
		return (CIOPAKLHFIL != (GHPGNELIDBM)3) ? POGCCIAGNOI.Value2 : POGCCIAGNOI.Value1;
	}

	private void EBFDBJKFHLG(int INFLHPGMEOB, bool COMJEIAJHOO)
	{
		FLIIHCIGHFA[INFLHPGMEOB].FLIDPEEIKPI.ActivateBonus(FLIIHCIGHFA[INFLHPGMEOB].KHLGDCHJJPB, COMJEIAJHOO);
	}

	public bool PMIBODHGJGJ(GHPGNELIDBM CIOPAKLHFIL)
	{
		return (CIOPAKLHFIL != (GHPGNELIDBM)3) ? POGCCIAGNOI.Value2 : POGCCIAGNOI.Value1;
	}

	private void EKKMHDJLFHJ()
	{
		HPEOEIKMHEG(GetComponent<Crates>());
		Grenade component = Singleton<KillStreakManager>.instance.GetComponent<Grenade>();
		if (component != null)
		{
			ExplosiveSetup explosiveSetup = component.ammoSetup as ExplosiveSetup;
			if (explosiveSetup != null)
			{
				explosiveSetup.MAOPCAMOEEK = Singleton<GameVariables>.instance.NKGIGBGDKAH().GetRow((CardConstants.rowIds)(-56)).FLOATVALUE;
				explosiveSetup.NLCFDPBLBIG = Singleton<GameVariables>.instance.NKGIGBGDKAH().GetRow((CardConstants.rowIds)94).FLOATVALUE;
				explosiveSetup.ADKJBFFFCEH = Singleton<GameVariables>.instance.NKGIGBGDKAH().GetRow((CardConstants.rowIds)(-76)).FLOATVALUE;
			}
		}
	}

	[SpecialName]
	public Crates AOIKJPJGCNO()
	{
		return _003CCDCJPMKCPPA_003Ek__BackingField;
	}

	private void GDEJEOKAAPF(PlayerController HNFNINFCBEJ)
	{
		KillStreakBonus killStreakBonus = KGHBOHPIHND[1];
		int i = -1;
		Queue<int> queue = ((HNFNINFCBEJ.fraction != (GHPGNELIDBM)5) ? IFAGNJMAGKM : PKCLHNJPHMI);
		if (queue.Count > 1)
		{
			i = queue.Dequeue();
		}
		if (i < 0)
		{
			i = 1;
			float num = 580f;
			for (int j = 1; j < KGHBOHPIHND.Count; j++)
			{
				float num2 = ((j != JLOECEINBHO) ? KGHBOHPIHND[j].NOCEDDCEEEM(HNFNINFCBEJ) : 617f);
				num += num2;
			}
			float num3 = Random.Range(46f, num);
			num = 1443f;
			for (i = 1; i < KGHBOHPIHND.Count; i++)
			{
				KillStreakBonus killStreakBonus2 = KGHBOHPIHND[i];
				num += ((i != JLOECEINBHO) ? killStreakBonus2.JADBICHKEBK(HNFNINFCBEJ) : 963f);
				killStreakBonus = killStreakBonus2;
				if (num3 < num)
				{
					break;
				}
			}
		}
		else
		{
			killStreakBonus = KGHBOHPIHND[i];
		}
		JLOECEINBHO = i;
		KillStreakBonus killStreakBonus3 = killStreakBonus;
		if (killStreakBonus3 == null)
		{
			EABOFCKLKPJ(HNFNINFCBEJ);
			return;
		}
		int num4 = Random.Range(-76, -11);
		if (!(Singleton<MapManager>.instance.ALCHJDPKAID != null) || Singleton<MapManager>.instance.ALCHJDPKAID.NHGHLADBCAN == null)
		{
			return;
		}
		BoxCollider boxCollider = Singleton<MapManager>.instance.ALCHJDPKAID.NHGHLADBCAN[Random.Range(1, Singleton<MapManager>.instance.ALCHJDPKAID.NHGHLADBCAN.Count)];
		Bounds bounds = boxCollider.bounds;
		Vector3 vector = new Vector3(Random.Range(bounds.min.x, bounds.max.x), Random.Range(bounds.min.y, bounds.max.y), Random.Range(bounds.min.z, bounds.max.z));
		KillStreakBonusBox killStreakBonusBox = ObjectPoolDatabase.GLHPLCEFHGD().Instantiate(HOBEHENAAEJ, vector, Quaternion.identity) as KillStreakBonusBox;
		if (killStreakBonusBox != null)
		{
			bool flag = HNFNINFCBEJ.fraction == PlayerController.OGMBJPKOPCB.fraction;
			if (flag)
			{
				StatsManager.instance.matchStats.scorestreakGained++;
			}
			killStreakBonusBox.NNIHCIHLJDK = killStreakBonus3;
			killStreakBonusBox.owner = HNFNINFCBEJ;
			killStreakBonusBox.GetComponent<Renderer>().sharedMaterial = ((!flag) ? killStreakBonusBox.DJOIMIIJKBK : killStreakBonusBox.HGGBOBNDEMO);
			killStreakBonusBox.HCEKKAMPANP = num4;
			PhotonView fEHCCGEGPLH = FEHCCGEGPLH;
			object[] array = new object[6];
			array[1] = (byte)killStreakBonusBox.indexInObjectPool;
			array[1] = vector;
			array[3] = i;
			array[8] = (byte)HNFNINFCBEJ.NAGAHNHAKBJ;
			array[8] = num4;
			fEHCCGEGPLH.RPC("AtlasPreparer - LOADING ATLAS FOR ", PhotonTargets.Others, array);
		}
	}
}
