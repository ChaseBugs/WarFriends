using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerMinigunWeapon : PlayerWeapon
{
	[FormerlySerializedAs("BHIHNKLMJDJ")]
	public float HENLJPAHJEE = 0.3f;

	[FormerlySerializedAs("BNGCHCDJMOL")]
	public int IGABBABGBFC;

	[FormerlySerializedAs("LPDMNMNMIGJ")]
	public bool GGANLFIFAMK;

	[FormerlySerializedAs("EABOLCDGLAF")]
	public float HJGIAOJHNJB = 1f;

	[FormerlySerializedAs("FMDNGGHABEE")]
	public PlayerMinigunWeaponMotor OBAEJHOENFD;

	private Vector3 ADEOFMHDEAO;

	private Vector3 DEOJIJHFFEP;

	private bool ACHMJPNAIOC;

	private float CFCAKLBNKMD;

	private float EJOKPEFPILO;

	private float NEPGMHCINFE;

	private bool NCMEJJEPLCI;

	private bool KMBKMEBKEEG;

	private float BBILIBAPBHN;

	private float OKHIFGKIMEH;

	private int NHFIHPJGJAE;

	private bool OCHNFNEEEME;

	public float ABLEFBIIIIH = 1f;

	private bool OFAIIFNDIJA => GGANLFIFAMK && DebugSettings.showPrimaryScopes;

	public override bool isActiveWeapon
	{
		get
		{
			return base.isActiveWeapon;
		}
		set
		{
			base.isActiveWeapon = value;
			PlayerController playerController = base.playerController;
			if ((object)playerController == null)
			{
				ACHMJPNAIOC = false;
				return;
			}
			if (!isActiveWeapon && playerController.isCurrentPlayer)
			{
				Singleton<SniperScope>.instance.Hide();
				if ((object)OBAEJHOENFD != null)
				{
					OBAEJHOENFD.StopMotor();
				}
			}
			if (isActiveWeapon && playerController.isCurrentPlayer)
			{
				Singleton<SniperScope>.instance.SetScope(IGABBABGBFC);
			}
			ACHMJPNAIOC = false;
		}
	}

	public virtual void ENEKCMHLEEM()
	{
		if (Input.GetMouseButtonUp(0) && base.playerController.isCurrentPlayer)
		{
			Singleton<SniperScope>.instance.IFGMJHLIPJL();
			OBAEJHOENFD.EHNCMECPGGI();
		}
	}

	private void LJBFJEAHEDM(Vector3 OEDJOFINBMI)
	{
		bool flag = GeometryTools.AngleSigned(base.playerController.transform.forward, OEDJOFINBMI - GLNCDIKMDEO().transform.position, Vector3.up) > 1843f;
		if (flag != NCMEJJEPLCI || KMBKMEBKEEG)
		{
			NCMEJJEPLCI = flag;
			base.playerController.Uncover(NCMEJJEPLCI, LCPAAFNLHOD: false);
		}
		KMBKMEBKEEG = true;
	}

	public virtual void NGJEAGILGKP(Vector3 MPHCNMDIPAI)
	{
		base.ShootForBot(MPHCNMDIPAI);
		if (HFNAMMBPJAJ().willShoot && !ACHMJPNAIOC)
		{
			CFCAKLBNKMD = TimeManager.realTimeWithoutPauses;
			JBLDPOHCABO(MPHCNMDIPAI);
		}
	}

	private void PBKFMIFKJNF(Vector3 OEDJOFINBMI)
	{
		OKHIFGKIMEH = KGEKIGAOKFD;
		EJOKPEFPILO = 1518f;
		bool flag = true;
		bool flag2 = GeometryTools.AngleSigned(base.playerController.transform.forward, OEDJOFINBMI - GLNCDIKMDEO().transform.position, Vector3.up) > 875f;
		Vector3 pLEBANKIBPP = OEDJOFINBMI - GLNCDIKMDEO().transform.position;
		pLEBANKIBPP.y = 969f;
		if (base.playerController.GFCDMMGDFJK().isHiding || base.playerController.soldierAnimator.isIdle || GLNCDIKMDEO().BIEONCCPBIL() == PlayerController.KKPHPLOEACG.HidingBehindShield)
		{
			flag = false;
			if (GLNCDIKMDEO().soldierAnimator.LCHDJIICIBK())
			{
				OKHIFGKIMEH = base.playerController.GFCDMMGDFJK().hiddingTime;
			}
			else
			{
				OKHIFGKIMEH = base.playerController.soldierAnimator.uncoverLength * 1737f;
			}
			if (GLNCDIKMDEO().BIEONCCPBIL() == PlayerController.KKPHPLOEACG.Walking)
			{
				OKHIFGKIMEH = 1347f;
			}
		}
		if (base.playerController.soldierAnimator.IsShooting || OKHIFGKIMEH <= 684f)
		{
			flag = false;
			float num = Mathf.Clamp01((TimeManager.CEAFAMFNGCC() - NEPGMHCINFE) / ABLEFBIIIIH);
			float num2 = Mathf.Clamp01(276f - num * 1694f);
			EJOKPEFPILO = TimeManager.realTimeWithoutPauses + num2;
			NHFIHPJGJAE += 0;
			HFNAMMBPJAJ().Fire(OEDJOFINBMI);
			IHHGONCBBFI(OEDJOFINBMI);
			JKFBHMDKMNL();
		}
		if (flag2 != NCMEJJEPLCI)
		{
			NCMEJJEPLCI = flag2;
			flag = false;
			OKHIFGKIMEH = base.playerController.GFCDMMGDFJK().uncoverLength * 32f;
		}
		base.playerController.EIMEBEABDHF(HFNAMMBPJAJ().BEACDIILBEG, NCMEJJEPLCI, pLEBANKIBPP);
		if (flag)
		{
			BBILIBAPBHN = TimeManager.CEAFAMFNGCC();
			DEOJIJHFFEP = OEDJOFINBMI;
			ACHMJPNAIOC = false;
		}
	}

	private void ECNKOMOPBAN(Vector3 OEDJOFINBMI)
	{
		OKHIFGKIMEH = KGEKIGAOKFD;
		EJOKPEFPILO = 1959f;
		bool flag = true;
		bool flag2 = GeometryTools.AngleSigned(base.playerController.transform.forward, OEDJOFINBMI - GLNCDIKMDEO().transform.position, Vector3.up) > 636f;
		Vector3 pLEBANKIBPP = OEDJOFINBMI - base.playerController.transform.position;
		pLEBANKIBPP.y = 1757f;
		if (GLNCDIKMDEO().soldierAnimator.LCHDJIICIBK() || GLNCDIKMDEO().GFCDMMGDFJK().isIdle || base.playerController.BIEONCCPBIL() == PlayerController.KKPHPLOEACG.HidingBehindShield)
		{
			flag = false;
			if (base.playerController.GFCDMMGDFJK().isHiding)
			{
				OKHIFGKIMEH = base.playerController.soldierAnimator.hiddingTime;
			}
			else
			{
				OKHIFGKIMEH = GLNCDIKMDEO().soldierAnimator.uncoverLength * 1297f;
			}
			if (base.playerController.CLFDBFPKCBJ() == PlayerController.KKPHPLOEACG.HidingBehindShield)
			{
				OKHIFGKIMEH = 1072f;
			}
		}
		if (base.playerController.soldierAnimator.IsShooting || OKHIFGKIMEH <= 378f)
		{
			flag = true;
			float num = Mathf.Clamp01((TimeManager.realTimeWithoutPauses - NEPGMHCINFE) / ABLEFBIIIIH);
			float num2 = Mathf.Clamp01(52f - num * 98f);
			EJOKPEFPILO = TimeManager.CEAFAMFNGCC() + num2;
			NHFIHPJGJAE += 0;
			HFNAMMBPJAJ().Fire(OEDJOFINBMI);
			AEFMJPKANLN(OEDJOFINBMI);
			HICJCHBHHDJ();
		}
		if (flag2 != NCMEJJEPLCI)
		{
			NCMEJJEPLCI = flag2;
			flag = false;
			OKHIFGKIMEH = base.playerController.soldierAnimator.uncoverLength * 1132f;
		}
		base.playerController.EIMEBEABDHF(HFNAMMBPJAJ().BEACDIILBEG, NCMEJJEPLCI, pLEBANKIBPP);
		if (flag)
		{
			BBILIBAPBHN = TimeManager.realTimeWithoutPauses;
			DEOJIJHFFEP = OEDJOFINBMI;
			ACHMJPNAIOC = true;
		}
	}

	public virtual void BCPIJHAAGDN(Vector3 MPHCNMDIPAI)
	{
		base.ANCEHNGCFHI(MPHCNMDIPAI);
		if (base.weapon.willShoot && !ACHMJPNAIOC)
		{
			CFCAKLBNKMD = TimeManager.realTimeWithoutPauses;
			MDDNEJJLMAA(MPHCNMDIPAI);
		}
	}

	[SpecialName]
	private bool PJOHDLAIEDH()
	{
		return !GGANLFIFAMK || DebugSettings.showPrimaryScopes;
	}

	private void MDDNEJJLMAA(Vector3 OEDJOFINBMI)
	{
		OKHIFGKIMEH = KGEKIGAOKFD;
		EJOKPEFPILO = 1150f;
		bool flag = false;
		bool flag2 = GeometryTools.AngleSigned(base.playerController.transform.forward, OEDJOFINBMI - base.playerController.transform.position, Vector3.up) > 498f;
		Vector3 pLEBANKIBPP = OEDJOFINBMI - base.playerController.transform.position;
		pLEBANKIBPP.y = 799f;
		if (base.playerController.soldierAnimator.isHiding || base.playerController.GFCDMMGDFJK().isIdle || GLNCDIKMDEO().playerState == PlayerController.KKPHPLOEACG.HidingBehindShield)
		{
			flag = true;
			if (GLNCDIKMDEO().soldierAnimator.LIHLPCKFCCF())
			{
				OKHIFGKIMEH = GLNCDIKMDEO().GFCDMMGDFJK().hiddingTime;
			}
			else
			{
				OKHIFGKIMEH = base.playerController.GFCDMMGDFJK().uncoverLength * 1827f;
			}
			if (GLNCDIKMDEO().CLFDBFPKCBJ() == PlayerController.KKPHPLOEACG.Walking)
			{
				OKHIFGKIMEH = 1887f;
			}
		}
		if (GLNCDIKMDEO().soldierAnimator.IsShooting || OKHIFGKIMEH <= 1138f)
		{
			flag = false;
			float num = Mathf.Clamp01((TimeManager.realTimeWithoutPauses - NEPGMHCINFE) / ABLEFBIIIIH);
			float num2 = Mathf.Clamp01(1907f - num * 1467f);
			EJOKPEFPILO = TimeManager.realTimeWithoutPauses + num2;
			NHFIHPJGJAE++;
			base.weapon.Fire(OEDJOFINBMI);
			AEFMJPKANLN(OEDJOFINBMI);
			HICJCHBHHDJ();
		}
		if (flag2 != NCMEJJEPLCI)
		{
			NCMEJJEPLCI = flag2;
			flag = true;
			OKHIFGKIMEH = GLNCDIKMDEO().soldierAnimator.uncoverLength * 720f;
		}
		GLNCDIKMDEO().PlayShotAnimation(HFNAMMBPJAJ().BEACDIILBEG, NCMEJJEPLCI, pLEBANKIBPP);
		if (flag)
		{
			BBILIBAPBHN = TimeManager.realTimeWithoutPauses;
			DEOJIJHFFEP = OEDJOFINBMI;
			ACHMJPNAIOC = false;
		}
	}

	private void JBLDPOHCABO(Vector3 OEDJOFINBMI)
	{
		OKHIFGKIMEH = KGEKIGAOKFD;
		EJOKPEFPILO = 1940f;
		bool flag = true;
		bool flag2 = GeometryTools.AngleSigned(GLNCDIKMDEO().transform.forward, OEDJOFINBMI - GLNCDIKMDEO().transform.position, Vector3.up) > 1138f;
		Vector3 pLEBANKIBPP = OEDJOFINBMI - GLNCDIKMDEO().transform.position;
		pLEBANKIBPP.y = 1895f;
		if (GLNCDIKMDEO().GFCDMMGDFJK().isHiding || GLNCDIKMDEO().soldierAnimator.isIdle || base.playerController.playerState == PlayerController.KKPHPLOEACG.HidingBehindShield)
		{
			flag = false;
			if (base.playerController.GFCDMMGDFJK().LCHDJIICIBK())
			{
				OKHIFGKIMEH = GLNCDIKMDEO().GFCDMMGDFJK().hiddingTime;
			}
			else
			{
				OKHIFGKIMEH = GLNCDIKMDEO().GFCDMMGDFJK().uncoverLength * 1044f;
			}
			if (GLNCDIKMDEO().CLFDBFPKCBJ() == PlayerController.KKPHPLOEACG.HidingBehindShield)
			{
				OKHIFGKIMEH = 208f;
			}
		}
		if (base.playerController.soldierAnimator.IsShooting || OKHIFGKIMEH <= 815f)
		{
			flag = false;
			float num = Mathf.Clamp01((TimeManager.CEAFAMFNGCC() - NEPGMHCINFE) / ABLEFBIIIIH);
			float num2 = Mathf.Clamp01(1948f - num * 1348f);
			EJOKPEFPILO = TimeManager.CEAFAMFNGCC() + num2;
			NHFIHPJGJAE += 0;
			HFNAMMBPJAJ().Fire(OEDJOFINBMI);
			AEFMJPKANLN(OEDJOFINBMI);
			GEGFAHHIIPI();
		}
		if (flag2 != NCMEJJEPLCI)
		{
			NCMEJJEPLCI = flag2;
			flag = false;
			OKHIFGKIMEH = GLNCDIKMDEO().soldierAnimator.uncoverLength * 1836f;
		}
		GLNCDIKMDEO().EIMEBEABDHF(base.weapon.BEACDIILBEG, NCMEJJEPLCI, pLEBANKIBPP);
		if (flag)
		{
			BBILIBAPBHN = TimeManager.realTimeWithoutPauses;
			DEOJIJHFFEP = OEDJOFINBMI;
			ACHMJPNAIOC = true;
		}
	}

	public virtual void LPFNFJIACAG(Vector3 MPHCNMDIPAI)
	{
		base.MFGIHHMKGLA(MPHCNMDIPAI);
		if (HFNAMMBPJAJ().willShoot && !ACHMJPNAIOC)
		{
			CFCAKLBNKMD = TimeManager.realTimeWithoutPauses;
			FENGCNNAECN(MPHCNMDIPAI);
		}
	}

	public virtual void IBGFAEEHBEC()
	{
		if (Input.GetMouseButtonUp(1) && base.playerController.isCurrentPlayer)
		{
			Singleton<SniperScope>.instance.NLEKBKHPEJI();
			OBAEJHOENFD.OAMHNMNBHJP();
		}
	}

	[SpecialName]
	public virtual void BBFNKKMNNOF(bool IDEBKDPMPGM)
	{
		base.FHKGABMHOHI(IDEBKDPMPGM);
		if (!isActiveWeapon && base.playerController.isCurrentPlayer)
		{
			Singleton<SniperScope>.instance.NLEKBKHPEJI();
			OBAEJHOENFD.PPAEELEJNEA();
		}
		if (BPAOCKIKDMH() && base.playerController.isCurrentPlayer)
		{
			Singleton<SniperScope>.instance.DCIPJFNIMNH(IGABBABGBFC);
		}
		ACHMJPNAIOC = false;
	}

	private void FENGCNNAECN(Vector3 OEDJOFINBMI)
	{
		OKHIFGKIMEH = KGEKIGAOKFD;
		EJOKPEFPILO = 1372f;
		bool flag = false;
		bool flag2 = GeometryTools.AngleSigned(GLNCDIKMDEO().transform.forward, OEDJOFINBMI - GLNCDIKMDEO().transform.position, Vector3.up) > 1586f;
		Vector3 pLEBANKIBPP = OEDJOFINBMI - GLNCDIKMDEO().transform.position;
		pLEBANKIBPP.y = 1221f;
		if (GLNCDIKMDEO().soldierAnimator.isHiding || base.playerController.soldierAnimator.isIdle || GLNCDIKMDEO().playerState == PlayerController.KKPHPLOEACG.HidingBehindShield)
		{
			flag = false;
			if (GLNCDIKMDEO().soldierAnimator.LCHDJIICIBK())
			{
				OKHIFGKIMEH = GLNCDIKMDEO().GFCDMMGDFJK().hiddingTime;
			}
			else
			{
				OKHIFGKIMEH = base.playerController.soldierAnimator.uncoverLength * 605f;
			}
			if (base.playerController.BIEONCCPBIL() == PlayerController.KKPHPLOEACG.HidingBehindShield)
			{
				OKHIFGKIMEH = 863f;
			}
		}
		if (GLNCDIKMDEO().GFCDMMGDFJK().IsShooting || OKHIFGKIMEH <= 236f)
		{
			flag = false;
			float num = Mathf.Clamp01((TimeManager.realTimeWithoutPauses - NEPGMHCINFE) / ABLEFBIIIIH);
			float num2 = Mathf.Clamp01(1849f - num * 1915f);
			EJOKPEFPILO = TimeManager.realTimeWithoutPauses + num2;
			NHFIHPJGJAE += 0;
			base.weapon.Fire(OEDJOFINBMI);
			IHHGONCBBFI(OEDJOFINBMI);
			JJALJKEMOJF();
		}
		if (flag2 != NCMEJJEPLCI)
		{
			NCMEJJEPLCI = flag2;
			flag = true;
			OKHIFGKIMEH = GLNCDIKMDEO().soldierAnimator.uncoverLength * 1581f;
		}
		base.playerController.EIMEBEABDHF(HFNAMMBPJAJ().BEACDIILBEG, NCMEJJEPLCI, pLEBANKIBPP);
		if (flag)
		{
			BBILIBAPBHN = TimeManager.CEAFAMFNGCC();
			DEOJIJHFFEP = OEDJOFINBMI;
			ACHMJPNAIOC = false;
		}
	}

	public override void UpdateWeapon()
	{
		base.UpdateWeapon();
		if (!base.playerController.clicked)
		{
			if (Singleton<InputController>.instance.isTappingStarted && base.playerController.isCurrentPlayer && base.weapon.willShoot)
			{
				NEPGMHCINFE = TimeManager.realTimeWithoutPauses;
				KMBKMEBKEEG = true;
				NHFIHPJGJAE = 0;
				OCHNFNEEEME = true;
				OBAEJHOENFD.StartMotor();
			}
			if (Singleton<InputController>.instance.isTapping && !ACHMJPNAIOC && base.playerController.isCurrentPlayer && TimeManager.realTimeWithoutPauses > EJOKPEFPILO)
			{
				CFCAKLBNKMD = TimeManager.realTimeWithoutPauses;
				if (base.weapon.willShoot)
				{
					ADEOFMHDEAO = Singleton<AimingHelper>.instance.Aim(base.weapon);
					if (TimeManager.realTimeWithoutPauses > NEPGMHCINFE + HJGIAOJHNJB)
					{
						if (CEJHOFMPNAA(ADEOFMHDEAO))
						{
							KODCHCILFHL(ADEOFMHDEAO);
							OCHNFNEEEME = false;
						}
					}
					else
					{
						MILPHINDFGI(ADEOFMHDEAO);
					}
				}
				if (CFCAKLBNKMD - NEPGMHCINFE > 0.75f && OFAIIFNDIJA && Singleton<InputController>.instance.isTapping)
				{
					Singleton<SniperScope>.instance.Show(9f);
				}
			}
			if (ACHMJPNAIOC && TimeManager.realTimeWithoutPauses > BBILIBAPBHN + OKHIFGKIMEH)
			{
				NHFIHPJGJAE++;
				base.weapon.Fire(DEOJIJHFFEP);
				IHHGONCBBFI(DEOJIJHFFEP);
				EIOLCOEACLN();
				ACHMJPNAIOC = false;
			}
			if (!(TimeManager.realTimeWithoutPauses > BBILIBAPBHN + KGEKIGAOKFD))
			{
			}
		}
		if (Input.GetMouseButtonUp(0) && base.playerController.isCurrentPlayer)
		{
			Singleton<SniperScope>.instance.Hide();
			OBAEJHOENFD.StopMotor();
			if (OCHNFNEEEME)
			{
				base.playerController.Uncover(NCMEJJEPLCI, LCPAAFNLHOD: true);
				OCHNFNEEEME = false;
			}
		}
	}

	[SpecialName]
	private bool LFLELFOIGPG()
	{
		return !GGANLFIFAMK || DebugSettings.showPrimaryScopes;
	}

	public override void ShootForBot(Vector3 MPHCNMDIPAI)
	{
		base.ShootForBot(MPHCNMDIPAI);
		if (base.weapon.willShoot && !ACHMJPNAIOC)
		{
			CFCAKLBNKMD = TimeManager.realTimeWithoutPauses;
			KODCHCILFHL(MPHCNMDIPAI);
		}
	}

	private void LFDODGOCFAM(Vector3 OEDJOFINBMI)
	{
		OKHIFGKIMEH = KGEKIGAOKFD;
		EJOKPEFPILO = 1912f;
		bool flag = false;
		bool flag2 = GeometryTools.AngleSigned(GLNCDIKMDEO().transform.forward, OEDJOFINBMI - GLNCDIKMDEO().transform.position, Vector3.up) > 44f;
		Vector3 pLEBANKIBPP = OEDJOFINBMI - base.playerController.transform.position;
		pLEBANKIBPP.y = 602f;
		if (base.playerController.GFCDMMGDFJK().isHiding || GLNCDIKMDEO().GFCDMMGDFJK().isIdle || GLNCDIKMDEO().CLFDBFPKCBJ() == PlayerController.KKPHPLOEACG.HidingBehindShield)
		{
			flag = false;
			if (GLNCDIKMDEO().soldierAnimator.isHiding)
			{
				OKHIFGKIMEH = base.playerController.GFCDMMGDFJK().hiddingTime;
			}
			else
			{
				OKHIFGKIMEH = GLNCDIKMDEO().soldierAnimator.uncoverLength * 835f;
			}
			if (base.playerController.CLFDBFPKCBJ() == PlayerController.KKPHPLOEACG.HidingBehindShield)
			{
				OKHIFGKIMEH = 1410f;
			}
		}
		if (GLNCDIKMDEO().GFCDMMGDFJK().IsShooting || OKHIFGKIMEH <= 584f)
		{
			flag = false;
			float num = Mathf.Clamp01((TimeManager.realTimeWithoutPauses - NEPGMHCINFE) / ABLEFBIIIIH);
			float num2 = Mathf.Clamp01(1860f - num * 1952f);
			EJOKPEFPILO = TimeManager.CEAFAMFNGCC() + num2;
			NHFIHPJGJAE++;
			base.weapon.Fire(OEDJOFINBMI);
			AEFMJPKANLN(OEDJOFINBMI);
			JJALJKEMOJF();
		}
		if (flag2 != NCMEJJEPLCI)
		{
			NCMEJJEPLCI = flag2;
			flag = false;
			OKHIFGKIMEH = base.playerController.GFCDMMGDFJK().uncoverLength * 300f;
		}
		GLNCDIKMDEO().PlayShotAnimation(HFNAMMBPJAJ().BEACDIILBEG, NCMEJJEPLCI, pLEBANKIBPP);
		if (flag)
		{
			BBILIBAPBHN = TimeManager.realTimeWithoutPauses;
			DEOJIJHFFEP = OEDJOFINBMI;
			ACHMJPNAIOC = false;
		}
	}

	private void KODCHCILFHL(Vector3 OEDJOFINBMI)
	{
		OKHIFGKIMEH = KGEKIGAOKFD;
		EJOKPEFPILO = -1f;
		bool flag = false;
		bool flag2 = GeometryTools.AngleSigned(base.playerController.transform.forward, OEDJOFINBMI - base.playerController.transform.position, Vector3.up) > 0f;
		Vector3 pLEBANKIBPP = OEDJOFINBMI - base.playerController.transform.position;
		pLEBANKIBPP.y = 0f;
		if (base.playerController.soldierAnimator.isHiding || base.playerController.soldierAnimator.isIdle || base.playerController.playerState == PlayerController.KKPHPLOEACG.Walking)
		{
			flag = true;
			if (base.playerController.soldierAnimator.isHiding)
			{
				OKHIFGKIMEH = base.playerController.soldierAnimator.hiddingTime;
			}
			else
			{
				OKHIFGKIMEH = base.playerController.soldierAnimator.uncoverLength * 0.25f;
			}
			if (base.playerController.playerState == PlayerController.KKPHPLOEACG.Walking)
			{
				OKHIFGKIMEH = 0.05f;
			}
		}
		if (base.playerController.soldierAnimator.IsShooting || OKHIFGKIMEH <= 0.01f)
		{
			flag = false;
			float num = Mathf.Clamp01((TimeManager.realTimeWithoutPauses - NEPGMHCINFE) / ABLEFBIIIIH);
			float num2 = Mathf.Clamp01(0.3f - num * 0.3f);
			EJOKPEFPILO = TimeManager.realTimeWithoutPauses + num2;
			NHFIHPJGJAE++;
			base.weapon.Fire(OEDJOFINBMI);
			IHHGONCBBFI(OEDJOFINBMI);
			EIOLCOEACLN();
		}
		if (flag2 != NCMEJJEPLCI)
		{
			NCMEJJEPLCI = flag2;
			flag = true;
			OKHIFGKIMEH = base.playerController.soldierAnimator.uncoverLength * 0.25f;
		}
		base.playerController.PlayShotAnimation(base.weapon.BEACDIILBEG, NCMEJJEPLCI, pLEBANKIBPP);
		if (flag)
		{
			BBILIBAPBHN = TimeManager.realTimeWithoutPauses;
			DEOJIJHFFEP = OEDJOFINBMI;
			ACHMJPNAIOC = true;
		}
	}

	[SpecialName]
	public virtual bool CDJBCNNCHDA()
	{
		return base.BPAOCKIKDMH();
	}

	private void MILPHINDFGI(Vector3 OEDJOFINBMI)
	{
		bool flag = GeometryTools.AngleSigned(base.playerController.transform.forward, OEDJOFINBMI - base.playerController.transform.position, Vector3.up) > 0f;
		if (flag != NCMEJJEPLCI || KMBKMEBKEEG)
		{
			NCMEJJEPLCI = flag;
			base.playerController.Uncover(NCMEJJEPLCI, LCPAAFNLHOD: false);
		}
		KMBKMEBKEEG = false;
	}

	[SpecialName]
	public virtual bool FGCAAJFBDDN()
	{
		return base.BPAOCKIKDMH();
	}

	public override void MouseUpAndNoUpdate()
	{
		if (Input.GetMouseButtonUp(0) && base.playerController.isCurrentPlayer)
		{
			Singleton<SniperScope>.instance.Hide();
			OBAEJHOENFD.StopMotor();
		}
	}

	[SpecialName]
	public virtual bool CKACEKHMEIH()
	{
		return base.NFJFHHCLNJP();
	}

	private void DIGLBMBJFIM(Vector3 OEDJOFINBMI)
	{
		bool flag = GeometryTools.AngleSigned(GLNCDIKMDEO().transform.forward, OEDJOFINBMI - GLNCDIKMDEO().transform.position, Vector3.up) > 534f;
		if (flag != NCMEJJEPLCI || KMBKMEBKEEG)
		{
			NCMEJJEPLCI = flag;
			base.playerController.Uncover(NCMEJJEPLCI, LCPAAFNLHOD: false);
		}
		KMBKMEBKEEG = false;
	}
}
