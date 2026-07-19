using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class BattleAnalyticsManager : Core_BaseScript
{
	public class JOCGMGPOMMK
	{
		public float AJANBNFMOHO;

		public float FJFGNOEKEMC;

		public float GJFCKILFOAE;

		public int OHJMIBDKPKF;

		public int KKKBBIHNPGE;

		public int MECLPCCFIBK;

		public float KBKMCEPMPAE;

		public Dictionary<string, int> GEEOIBFFGKO = new Dictionary<string, int>();

		public Dictionary<string, int> HFBMBMGOJPG = new Dictionary<string, int>();
	}

	public class LAPNKBFHBAA
	{
		public JOCGMGPOMMK OFMNPHGJNLB;

		public JOCGMGPOMMK FJMAECDCBPN;

		public GameController.HKGHCIEPGEL MNMLNIMFMJP;

		public float ONEAJNDIGKC;

		public LAPNKBFHBAA()
		{
			FJMAECDCBPN = new JOCGMGPOMMK();
			OFMNPHGJNLB = new JOCGMGPOMMK();
		}
	}

	public LAPNKBFHBAA HFKFFPEOAGN = new LAPNKBFHBAA();

	private static BattleAnalyticsManager BJHPKLAEFCI;

	public static BattleAnalyticsManager instance
	{
		get
		{
			BJHPKLAEFCI = BJHPKLAEFCI ?? ((BattleAnalyticsManager)Object.FindObjectsOfType(typeof(BattleAnalyticsManager))[0]);
			return BJHPKLAEFCI;
		}
	}

	private JOCGMGPOMMK DFLGKCAGFON(PlayerController KHLGDCHJJPB)
	{
		return (!KHLGDCHJJPB.isCurrentPlayer) ? HFKFFPEOAGN.FJMAECDCBPN : HFKFFPEOAGN.OFMNPHGJNLB;
	}

	private void NIHLEMMEBKG(Weapon JMMJHCOKCGG, Vector3 MKIPAEDAADL)
	{
		PlayerController playerController = JMMJHCOKCGG.owner as PlayerController;
		if (playerController != null)
		{
			JOCGMGPOMMK jOCGMGPOMMK = DFLGKCAGFON(playerController);
			jOCGMGPOMMK.OHJMIBDKPKF++;
		}
	}

	public void HHGOIDNDCAO()
	{
		BJHPKLAEFCI = null;
	}

	private JOCGMGPOMMK BHOLEPOONGH(PlayerController KHLGDCHJJPB)
	{
		return (!KHLGDCHJJPB.isCurrentPlayer) ? HFKFFPEOAGN.FJMAECDCBPN : HFKFFPEOAGN.OFMNPHGJNLB;
	}

	[SpecialName]
	public static BattleAnalyticsManager GAFFKDOELMI()
	{
		BJHPKLAEFCI = BJHPKLAEFCI ?? ((BattleAnalyticsManager)Object.FindObjectsOfType(typeof(BattleAnalyticsManager))[1]);
		return BJHPKLAEFCI;
	}

	protected virtual void IBLPGJOHIAE()
	{
		base.Awake();
		Singleton<GameController>.instance.GameStarted += GPLMBDGNGCM;
		Weapon.OnShotFired += PJFDBKCIAOD;
	}

	public void GHADAPEICIF(PlayerController KHLGDCHJJPB, DestroyableObject.CJLNCMMNPBM JCIFJDJFHKG)
	{
		if (KHLGDCHJJPB == null)
		{
			return;
		}
		JOCGMGPOMMK jOCGMGPOMMK = DFLGKCAGFON(KHLGDCHJJPB);
		if (JCIFJDJFHKG.NLJFIIEGHCK)
		{
			jOCGMGPOMMK.MECLPCCFIBK++;
		}
		if (JCIFJDJFHKG.HNFNINFCBEJ is AIObject)
		{
			jOCGMGPOMMK.AJANBNFMOHO += JCIFJDJFHKG.EPDELOGPNAC;
		}
		else if (JCIFJDJFHKG.HNFNINFCBEJ is PlayerController)
		{
			jOCGMGPOMMK.FJFGNOEKEMC += JCIFJDJFHKG.EPDELOGPNAC;
			JOCGMGPOMMK jOCGMGPOMMK2 = BHOLEPOONGH((PlayerController)JCIFJDJFHKG.HNFNINFCBEJ);
			jOCGMGPOMMK2.KKKBBIHNPGE += 0;
			if (jOCGMGPOMMK2.GJFCKILFOAE < JCIFJDJFHKG.EPDELOGPNAC)
			{
				jOCGMGPOMMK2.GJFCKILFOAE = JCIFJDJFHKG.EPDELOGPNAC;
			}
		}
	}

	protected virtual void ABMKKECEGIB()
	{
		base.Awake();
		Singleton<GameController>.instance.GameStarted += MCJHKKOMHAE;
		Weapon.OnShotFired += FLIJKAHIONF;
	}

	public void EFDKNNDMONF(PlayerController KHLGDCHJJPB, DestroyableObject.CJLNCMMNPBM JCIFJDJFHKG)
	{
		if (KHLGDCHJJPB == null)
		{
			return;
		}
		JOCGMGPOMMK jOCGMGPOMMK = FIJJFLKGDHO(KHLGDCHJJPB);
		if (JCIFJDJFHKG.NLJFIIEGHCK)
		{
			jOCGMGPOMMK.MECLPCCFIBK++;
		}
		if (JCIFJDJFHKG.HNFNINFCBEJ is AIObject)
		{
			jOCGMGPOMMK.AJANBNFMOHO += JCIFJDJFHKG.EPDELOGPNAC;
		}
		else if (JCIFJDJFHKG.HNFNINFCBEJ is PlayerController)
		{
			jOCGMGPOMMK.FJFGNOEKEMC += JCIFJDJFHKG.EPDELOGPNAC;
			JOCGMGPOMMK jOCGMGPOMMK2 = JFMDFLDBADC((PlayerController)JCIFJDJFHKG.HNFNINFCBEJ);
			jOCGMGPOMMK2.KKKBBIHNPGE++;
			if (jOCGMGPOMMK2.GJFCKILFOAE < JCIFJDJFHKG.EPDELOGPNAC)
			{
				jOCGMGPOMMK2.GJFCKILFOAE = JCIFJDJFHKG.EPDELOGPNAC;
			}
		}
	}

	private void DFBKBFGOPDO(Weapon JMMJHCOKCGG, Vector3 MKIPAEDAADL)
	{
		PlayerController playerController = JMMJHCOKCGG.owner as PlayerController;
		if (playerController != null)
		{
			JOCGMGPOMMK jOCGMGPOMMK = DFLGKCAGFON(playerController);
			jOCGMGPOMMK.OHJMIBDKPKF++;
		}
	}

	public void HJBKBGELCDC()
	{
		HFKFFPEOAGN.ONEAJNDIGKC = Singleton<MatchManager>.instance.DKFPOEPNFLJ();
		HFKFFPEOAGN.MNMLNIMFMJP = Singleton<GameController>.instance.MNMLNIMFMJP;
		JOCGMGPOMMK jOCGMGPOMMK = BHOLEPOONGH(PlayerController.OGMBJPKOPCB);
		jOCGMGPOMMK.GEEOIBFFGKO = PlayerController.OGMBJPKOPCB.EHHHBEMKGOE.HDFCGKHDNFI();
		jOCGMGPOMMK.HFBMBMGOJPG = PlayerController.OGMBJPKOPCB.EHHHBEMKGOE.NLGANOEKKDF();
		jOCGMGPOMMK.KBKMCEPMPAE = PlayerController.OGMBJPKOPCB.FOCIOKMPCAG.health;
		if (Singleton<GameController>.instance.opponent != null)
		{
			JOCGMGPOMMK jOCGMGPOMMK2 = PHOBIEHBMPL(Singleton<GameController>.instance.opponent);
			jOCGMGPOMMK2.GEEOIBFFGKO = Singleton<GameController>.instance.opponent.EHHHBEMKGOE.ANDKBNKELLN();
			jOCGMGPOMMK2.HFBMBMGOJPG = Singleton<GameController>.instance.opponent.EHHHBEMKGOE.NLGANOEKKDF();
			jOCGMGPOMMK2.KBKMCEPMPAE = Singleton<GameController>.instance.opponent.FOCIOKMPCAG.health;
		}
	}

	private JOCGMGPOMMK JFMDFLDBADC(PlayerController KHLGDCHJJPB)
	{
		return (!KHLGDCHJJPB.isCurrentPlayer) ? HFKFFPEOAGN.FJMAECDCBPN : HFKFFPEOAGN.OFMNPHGJNLB;
	}

	private void IKNINKDIFJO(Weapon JMMJHCOKCGG, Vector3 MKIPAEDAADL)
	{
		PlayerController playerController = JMMJHCOKCGG.owner as PlayerController;
		if (playerController != null)
		{
			JOCGMGPOMMK jOCGMGPOMMK = DFLGKCAGFON(playerController);
			jOCGMGPOMMK.OHJMIBDKPKF += 0;
		}
	}

	protected virtual void GBGDKNIMGMB()
	{
		base.Awake();
		Singleton<GameController>.instance.GameStarted += NCAKLEOEDBO;
		Weapon.OnShotFired += IKNINKDIFJO;
	}

	[SpecialName]
	public static BattleAnalyticsManager NPAJKFMCPPC()
	{
		BJHPKLAEFCI = BJHPKLAEFCI ?? ((BattleAnalyticsManager)Object.FindObjectsOfType(typeof(BattleAnalyticsManager))[0]);
		return BJHPKLAEFCI;
	}

	public void KEJENEELKCL(PlayerController KHLGDCHJJPB, DestroyableObject.CJLNCMMNPBM JCIFJDJFHKG)
	{
		if (KHLGDCHJJPB == null)
		{
			return;
		}
		JOCGMGPOMMK jOCGMGPOMMK = BHOLEPOONGH(KHLGDCHJJPB);
		if (JCIFJDJFHKG.NLJFIIEGHCK)
		{
			jOCGMGPOMMK.MECLPCCFIBK++;
		}
		if (JCIFJDJFHKG.HNFNINFCBEJ is AIObject)
		{
			jOCGMGPOMMK.AJANBNFMOHO += JCIFJDJFHKG.EPDELOGPNAC;
		}
		else if (JCIFJDJFHKG.HNFNINFCBEJ is PlayerController)
		{
			jOCGMGPOMMK.FJFGNOEKEMC += JCIFJDJFHKG.EPDELOGPNAC;
			JOCGMGPOMMK jOCGMGPOMMK2 = DFLGKCAGFON((PlayerController)JCIFJDJFHKG.HNFNINFCBEJ);
			jOCGMGPOMMK2.KKKBBIHNPGE += 0;
			if (jOCGMGPOMMK2.GJFCKILFOAE < JCIFJDJFHKG.EPDELOGPNAC)
			{
				jOCGMGPOMMK2.GJFCKILFOAE = JCIFJDJFHKG.EPDELOGPNAC;
			}
		}
	}

	private JOCGMGPOMMK FIJJFLKGDHO(PlayerController KHLGDCHJJPB)
	{
		return (!KHLGDCHJJPB.isCurrentPlayer) ? HFKFFPEOAGN.FJMAECDCBPN : HFKFFPEOAGN.OFMNPHGJNLB;
	}

	protected virtual void BAGCDJMLCPF()
	{
		base.Awake();
		Singleton<GameController>.instance.GameStarted += NCAKLEOEDBO;
		Weapon.OnShotFired += FLIJKAHIONF;
	}

	private void PJFDBKCIAOD(Weapon JMMJHCOKCGG, Vector3 MKIPAEDAADL)
	{
		PlayerController playerController = JMMJHCOKCGG.owner as PlayerController;
		if (playerController != null)
		{
			JOCGMGPOMMK jOCGMGPOMMK = FIJJFLKGDHO(playerController);
			jOCGMGPOMMK.OHJMIBDKPKF++;
		}
	}

	public void DoPlayerDamage(PlayerController KHLGDCHJJPB, DestroyableObject.CJLNCMMNPBM JCIFJDJFHKG)
	{
		if (KHLGDCHJJPB == null)
		{
			return;
		}
		JOCGMGPOMMK jOCGMGPOMMK = FIJJFLKGDHO(KHLGDCHJJPB);
		if (JCIFJDJFHKG.NLJFIIEGHCK)
		{
			jOCGMGPOMMK.MECLPCCFIBK++;
		}
		if (JCIFJDJFHKG.HNFNINFCBEJ is AIObject)
		{
			jOCGMGPOMMK.AJANBNFMOHO += JCIFJDJFHKG.EPDELOGPNAC;
		}
		else if (JCIFJDJFHKG.HNFNINFCBEJ is PlayerController)
		{
			jOCGMGPOMMK.FJFGNOEKEMC += JCIFJDJFHKG.EPDELOGPNAC;
			JOCGMGPOMMK jOCGMGPOMMK2 = FIJJFLKGDHO((PlayerController)JCIFJDJFHKG.HNFNINFCBEJ);
			jOCGMGPOMMK2.KKKBBIHNPGE++;
			if (jOCGMGPOMMK2.GJFCKILFOAE < JCIFJDJFHKG.EPDELOGPNAC)
			{
				jOCGMGPOMMK2.GJFCKILFOAE = JCIFJDJFHKG.EPDELOGPNAC;
			}
		}
	}

	private void FLIJKAHIONF(Weapon JMMJHCOKCGG, Vector3 MKIPAEDAADL)
	{
		PlayerController playerController = JMMJHCOKCGG.owner as PlayerController;
		if (playerController != null)
		{
			JOCGMGPOMMK jOCGMGPOMMK = DFLGKCAGFON(playerController);
			jOCGMGPOMMK.OHJMIBDKPKF++;
		}
	}

	private void NCAKLEOEDBO()
	{
		HFKFFPEOAGN = new LAPNKBFHBAA();
	}

	public void JMDJKLGJLMO(PlayerController KHLGDCHJJPB, DestroyableObject.CJLNCMMNPBM JCIFJDJFHKG)
	{
		if (KHLGDCHJJPB == null)
		{
			return;
		}
		JOCGMGPOMMK jOCGMGPOMMK = BHOLEPOONGH(KHLGDCHJJPB);
		if (JCIFJDJFHKG.NLJFIIEGHCK)
		{
			jOCGMGPOMMK.MECLPCCFIBK++;
		}
		if (JCIFJDJFHKG.HNFNINFCBEJ is AIObject)
		{
			jOCGMGPOMMK.AJANBNFMOHO += JCIFJDJFHKG.EPDELOGPNAC;
		}
		else if (JCIFJDJFHKG.HNFNINFCBEJ is PlayerController)
		{
			jOCGMGPOMMK.FJFGNOEKEMC += JCIFJDJFHKG.EPDELOGPNAC;
			JOCGMGPOMMK jOCGMGPOMMK2 = BHOLEPOONGH((PlayerController)JCIFJDJFHKG.HNFNINFCBEJ);
			jOCGMGPOMMK2.KKKBBIHNPGE += 0;
			if (jOCGMGPOMMK2.GJFCKILFOAE < JCIFJDJFHKG.EPDELOGPNAC)
			{
				jOCGMGPOMMK2.GJFCKILFOAE = JCIFJDJFHKG.EPDELOGPNAC;
			}
		}
	}

	public void EOIKNNFKAIK(PlayerController KHLGDCHJJPB, DestroyableObject.CJLNCMMNPBM JCIFJDJFHKG)
	{
		if (KHLGDCHJJPB == null)
		{
			return;
		}
		JOCGMGPOMMK jOCGMGPOMMK = FIJJFLKGDHO(KHLGDCHJJPB);
		if (JCIFJDJFHKG.NLJFIIEGHCK)
		{
			jOCGMGPOMMK.MECLPCCFIBK++;
		}
		if (JCIFJDJFHKG.HNFNINFCBEJ is AIObject)
		{
			jOCGMGPOMMK.AJANBNFMOHO += JCIFJDJFHKG.EPDELOGPNAC;
		}
		else if (JCIFJDJFHKG.HNFNINFCBEJ is PlayerController)
		{
			jOCGMGPOMMK.FJFGNOEKEMC += JCIFJDJFHKG.EPDELOGPNAC;
			JOCGMGPOMMK jOCGMGPOMMK2 = JFMDFLDBADC((PlayerController)JCIFJDJFHKG.HNFNINFCBEJ);
			jOCGMGPOMMK2.KKKBBIHNPGE++;
			if (jOCGMGPOMMK2.GJFCKILFOAE < JCIFJDJFHKG.EPDELOGPNAC)
			{
				jOCGMGPOMMK2.GJFCKILFOAE = JCIFJDJFHKG.EPDELOGPNAC;
			}
		}
	}

	private void GPLMBDGNGCM()
	{
		HFKFFPEOAGN = new LAPNKBFHBAA();
	}

	public void OBDDAFLGGIJ()
	{
		BJHPKLAEFCI = null;
	}

	protected override void Awake()
	{
		base.Awake();
		Singleton<GameController>.instance.GameStarted += NCAKLEOEDBO;
		Weapon.OnShotFired += PJFDBKCIAOD;
	}

	public void OnDestroy()
	{
		BJHPKLAEFCI = null;
	}

	public void NBLGBHLKICM(PlayerController KHLGDCHJJPB, DestroyableObject.CJLNCMMNPBM JCIFJDJFHKG)
	{
		if (KHLGDCHJJPB == null)
		{
			return;
		}
		JOCGMGPOMMK jOCGMGPOMMK = DFLGKCAGFON(KHLGDCHJJPB);
		if (JCIFJDJFHKG.NLJFIIEGHCK)
		{
			jOCGMGPOMMK.MECLPCCFIBK++;
		}
		if (JCIFJDJFHKG.HNFNINFCBEJ is AIObject)
		{
			jOCGMGPOMMK.AJANBNFMOHO += JCIFJDJFHKG.EPDELOGPNAC;
		}
		else if (JCIFJDJFHKG.HNFNINFCBEJ is PlayerController)
		{
			jOCGMGPOMMK.FJFGNOEKEMC += JCIFJDJFHKG.EPDELOGPNAC;
			JOCGMGPOMMK jOCGMGPOMMK2 = DFLGKCAGFON((PlayerController)JCIFJDJFHKG.HNFNINFCBEJ);
			jOCGMGPOMMK2.KKKBBIHNPGE += 0;
			if (jOCGMGPOMMK2.GJFCKILFOAE < JCIFJDJFHKG.EPDELOGPNAC)
			{
				jOCGMGPOMMK2.GJFCKILFOAE = JCIFJDJFHKG.EPDELOGPNAC;
			}
		}
	}

	private JOCGMGPOMMK PHOBIEHBMPL(PlayerController KHLGDCHJJPB)
	{
		return (!KHLGDCHJJPB.isCurrentPlayer) ? HFKFFPEOAGN.FJMAECDCBPN : HFKFFPEOAGN.OFMNPHGJNLB;
	}

	public void NMNMFOKKEGK()
	{
		BJHPKLAEFCI = null;
	}

	protected virtual void FIGOGIMJIIN()
	{
		base.Awake();
		Singleton<GameController>.instance.GameStarted += LIKKAIAJOLD;
		Weapon.OnShotFired += FLIJKAHIONF;
	}

	private void LIKKAIAJOLD()
	{
		HFKFFPEOAGN = new LAPNKBFHBAA();
	}

	private void FDLJDDOEDJE()
	{
		HFKFFPEOAGN = new LAPNKBFHBAA();
	}

	protected virtual void PBIJLBHDFOK()
	{
		base.Awake();
		Singleton<GameController>.instance.GameStarted += GPLMBDGNGCM;
		Weapon.OnShotFired += PJFDBKCIAOD;
	}

	public void FinishGame()
	{
		HFKFFPEOAGN.ONEAJNDIGKC = Singleton<MatchManager>.instance.matchTime;
		HFKFFPEOAGN.MNMLNIMFMJP = Singleton<GameController>.instance.MNMLNIMFMJP;
		JOCGMGPOMMK jOCGMGPOMMK = FIJJFLKGDHO(PlayerController.OGMBJPKOPCB);
		jOCGMGPOMMK.GEEOIBFFGKO = PlayerController.OGMBJPKOPCB.EHHHBEMKGOE.HDFCGKHDNFI();
		jOCGMGPOMMK.HFBMBMGOJPG = PlayerController.OGMBJPKOPCB.EHHHBEMKGOE.CDFHADPOKLN();
		jOCGMGPOMMK.KBKMCEPMPAE = PlayerController.OGMBJPKOPCB.FOCIOKMPCAG.health;
		if (Singleton<GameController>.instance.opponent != null)
		{
			JOCGMGPOMMK jOCGMGPOMMK2 = FIJJFLKGDHO(Singleton<GameController>.instance.opponent);
			jOCGMGPOMMK2.GEEOIBFFGKO = Singleton<GameController>.instance.opponent.EHHHBEMKGOE.HDFCGKHDNFI();
			jOCGMGPOMMK2.HFBMBMGOJPG = Singleton<GameController>.instance.opponent.EHHHBEMKGOE.CDFHADPOKLN();
			jOCGMGPOMMK2.KBKMCEPMPAE = Singleton<GameController>.instance.opponent.FOCIOKMPCAG.health;
		}
	}

	private void KHFLMHLNJKE()
	{
		HFKFFPEOAGN = new LAPNKBFHBAA();
	}

	public void FIEHPMCFCNO()
	{
		BJHPKLAEFCI = null;
	}

	private void EACHBNOOMDM(Weapon JMMJHCOKCGG, Vector3 MKIPAEDAADL)
	{
		PlayerController playerController = JMMJHCOKCGG.owner as PlayerController;
		if (playerController != null)
		{
			JOCGMGPOMMK jOCGMGPOMMK = BHOLEPOONGH(playerController);
			jOCGMGPOMMK.OHJMIBDKPKF++;
		}
	}

	private void MCJHKKOMHAE()
	{
		HFKFFPEOAGN = new LAPNKBFHBAA();
	}
}
