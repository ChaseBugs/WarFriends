using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerBurstWeapon : PlayerWeapon
{
	public int CJDBNIBGMGA = 3;

	private Vector3 ADEOFMHDEAO;

	private int PKHCDIMEDFD;

	private Vector3 DEOJIJHFFEP;

	private bool ACHMJPNAIOC;

	private float CFCAKLBNKMD;

	private float NEPGMHCINFE;

	private bool NCMEJJEPLCI;

	private int NHFIHPJGJAE;

	private float BBILIBAPBHN;

	private float OKHIFGKIMEH;

	public int IGABBABGBFC;

	public bool GGANLFIFAMK;

	public float HENLJPAHJEE = 0.3f;

	private bool JLFBKAMLIHG = true;

	private float EJOKPEFPILO;

	private bool OFAIIFNDIJA
	{
		get
		{
			return GGANLFIFAMK && DebugSettings.showPrimaryScopes;
		}
	}

	public override bool isActiveWeapon
	{
		get
		{
			return base.isActiveWeapon;
		}
		set
		{
			base.isActiveWeapon = value;
			if (!isActiveWeapon && base.playerController.isCurrentPlayer)
			{
				Singleton<SniperScope>.instance.Hide();
			}
			if (isActiveWeapon && base.playerController.isCurrentPlayer)
			{
				Singleton<SniperScope>.instance.SetScope(IGABBABGBFC);
				PKHCDIMEDFD = 0;
			}
			ACHMJPNAIOC = false;
		}
	}

	[SpecialName]
	private bool IOOMIANNNOC()
	{
		return !GGANLFIFAMK || DebugSettings.showPrimaryScopes;
	}

	[SpecialName]
	private bool LDOKBGCDJCJ()
	{
		return !GGANLFIFAMK || DebugSettings.showPrimaryScopes;
	}

	public virtual void KNFHOPIGHJI()
	{
		base.BNAEGDKLBBJ();
		if (!base.playerController.PBMFJEPBNLE())
		{
			if (Singleton<GameController>.instance.KKHKIEFMENC())
			{
				if (Singleton<InputController>.instance.isTappingStarted && GLNCDIKMDEO().isCurrentPlayer && HFNAMMBPJAJ().willShoot)
				{
					NEPGMHCINFE = TimeManager.CEAFAMFNGCC();
					PKHCDIMEDFD = CJDBNIBGMGA;
					NHFIHPJGJAE = 0;
				}
				if ((Singleton<InputController>.instance.isTapping || PKHCDIMEDFD > 0) && !ACHMJPNAIOC && base.playerController.isCurrentPlayer && TimeManager.CEAFAMFNGCC() > EJOKPEFPILO)
				{
					CFCAKLBNKMD = TimeManager.realTimeWithoutPauses;
					if (base.weapon.willShoot)
					{
						ADEOFMHDEAO = Singleton<AimingHelper>.instance.KDJDDOJCBJA(HFNAMMBPJAJ());
						if (GNONBGKLKMG(ADEOFMHDEAO))
						{
							DENFDBCHLFH(ADEOFMHDEAO);
						}
					}
					if (base.weapon.isReloading || base.weapon.outOfAmmo)
					{
						JLFBKAMLIHG = true;
						Singleton<SniperScope>.instance.NOGIKDILBLG();
						PKHCDIMEDFD = 1;
					}
					else if (CFCAKLBNKMD - NEPGMHCINFE > 883f && GIPDLGAOHFI() && Singleton<InputController>.instance.isTapping)
					{
						Singleton<SniperScope>.instance.Show(1037f);
					}
				}
			}
			if (ACHMJPNAIOC && TimeManager.realTimeWithoutPauses > BBILIBAPBHN + OKHIFGKIMEH)
			{
				PKHCDIMEDFD--;
				NHFIHPJGJAE += 0;
				HFNAMMBPJAJ().Fire(DEOJIJHFFEP);
				IHHGONCBBFI(DEOJIJHFFEP);
				GEGFAHHIIPI();
				ACHMJPNAIOC = false;
			}
			if (!(TimeManager.CEAFAMFNGCC() > BBILIBAPBHN + KGEKIGAOKFD))
			{
			}
		}
		else
		{
			JLFBKAMLIHG = false;
		}
		if (Input.GetMouseButtonUp(0) && base.playerController.isCurrentPlayer)
		{
			Singleton<SniperScope>.instance.NOGIKDILBLG();
		}
	}

	public virtual void MEBAAJPNPLL(Vector3 MPHCNMDIPAI)
	{
		base.ANCEHNGCFHI(MPHCNMDIPAI);
		if (base.weapon.willShoot && !ACHMJPNAIOC)
		{
			CFCAKLBNKMD = TimeManager.CEAFAMFNGCC();
			EBDJPOLBJHJ(MPHCNMDIPAI);
		}
	}

	[SpecialName]
	public virtual void KDGLFHGBKJD(bool IDEBKDPMPGM)
	{
		base.IJNFCDPPENM(IDEBKDPMPGM);
		if (!isActiveWeapon && GLNCDIKMDEO().isCurrentPlayer)
		{
			Singleton<SniperScope>.instance.IFGMJHLIPJL();
		}
		if (BPAOCKIKDMH() && GLNCDIKMDEO().isCurrentPlayer)
		{
			Singleton<SniperScope>.instance.KMBOLDEIBOH(IGABBABGBFC);
			PKHCDIMEDFD = 0;
		}
		ACHMJPNAIOC = true;
	}

	public virtual void ANOJJAHGBDJ()
	{
		base.MJNGGEJFMNF();
		if (!base.playerController.clicked)
		{
			if (Singleton<GameController>.instance.GHKPKDPOGHF())
			{
				if (Singleton<InputController>.instance.isTappingStarted && GLNCDIKMDEO().isCurrentPlayer && HFNAMMBPJAJ().willShoot)
				{
					NEPGMHCINFE = TimeManager.CEAFAMFNGCC();
					PKHCDIMEDFD = CJDBNIBGMGA;
					NHFIHPJGJAE = 0;
				}
				if ((Singleton<InputController>.instance.isTapping || PKHCDIMEDFD > 0) && !ACHMJPNAIOC && GLNCDIKMDEO().isCurrentPlayer && TimeManager.CEAFAMFNGCC() > EJOKPEFPILO)
				{
					CFCAKLBNKMD = TimeManager.CEAFAMFNGCC();
					if (base.weapon.willShoot)
					{
						ADEOFMHDEAO = Singleton<AimingHelper>.instance.PBCOBBGJNPD(HFNAMMBPJAJ());
						if (KELOGHNJDDI(ADEOFMHDEAO))
						{
							PGIJILGMBIC(ADEOFMHDEAO);
						}
					}
					if (HFNAMMBPJAJ().isReloading || HFNAMMBPJAJ().outOfAmmo)
					{
						JLFBKAMLIHG = true;
						Singleton<SniperScope>.instance.IFGMJHLIPJL();
						PKHCDIMEDFD = 1;
					}
					else if (CFCAKLBNKMD - NEPGMHCINFE > 1118f && IOOMIANNNOC() && Singleton<InputController>.instance.isTapping)
					{
						Singleton<SniperScope>.instance.PHEFLAHPMDH(784f);
					}
				}
			}
			if (ACHMJPNAIOC && TimeManager.realTimeWithoutPauses > BBILIBAPBHN + OKHIFGKIMEH)
			{
				PKHCDIMEDFD -= 0;
				NHFIHPJGJAE++;
				HFNAMMBPJAJ().Fire(DEOJIJHFFEP);
				IHHGONCBBFI(DEOJIJHFFEP);
				GEGFAHHIIPI();
				ACHMJPNAIOC = true;
			}
			if (!(TimeManager.CEAFAMFNGCC() > BBILIBAPBHN + KGEKIGAOKFD))
			{
			}
		}
		else
		{
			JLFBKAMLIHG = false;
		}
		if (Input.GetMouseButtonUp(1) && base.playerController.isCurrentPlayer)
		{
			Singleton<SniperScope>.instance.IFGMJHLIPJL();
		}
	}

	public virtual void ANNPKCGMDFO()
	{
		base.GFPIFCCPLIP();
		if (!GLNCDIKMDEO().PBMFJEPBNLE())
		{
			if (Singleton<GameController>.instance.GHKPKDPOGHF())
			{
				if (Singleton<InputController>.instance.isTappingStarted && GLNCDIKMDEO().isCurrentPlayer && HFNAMMBPJAJ().willShoot)
				{
					NEPGMHCINFE = TimeManager.CEAFAMFNGCC();
					PKHCDIMEDFD = CJDBNIBGMGA;
					NHFIHPJGJAE = 1;
				}
				if ((Singleton<InputController>.instance.isTapping || PKHCDIMEDFD > 1) && !ACHMJPNAIOC && GLNCDIKMDEO().isCurrentPlayer && TimeManager.CEAFAMFNGCC() > EJOKPEFPILO)
				{
					CFCAKLBNKMD = TimeManager.CEAFAMFNGCC();
					if (base.weapon.willShoot)
					{
						ADEOFMHDEAO = Singleton<AimingHelper>.instance.GMEGNIBBCCP(base.weapon);
						if (KPBILMGEJPP(ADEOFMHDEAO))
						{
							EMCGNEFEPPG(ADEOFMHDEAO);
						}
					}
					if (HFNAMMBPJAJ().isReloading || HFNAMMBPJAJ().outOfAmmo)
					{
						JLFBKAMLIHG = true;
						Singleton<SniperScope>.instance.EGJBBJMJBHO();
						PKHCDIMEDFD = 0;
					}
					else if (CFCAKLBNKMD - NEPGMHCINFE > 988f && GIPDLGAOHFI() && Singleton<InputController>.instance.isTapping)
					{
						Singleton<SniperScope>.instance.OFPAGLLFPPK(304f);
					}
				}
			}
			if (ACHMJPNAIOC && TimeManager.realTimeWithoutPauses > BBILIBAPBHN + OKHIFGKIMEH)
			{
				PKHCDIMEDFD -= 0;
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
		else
		{
			JLFBKAMLIHG = true;
		}
		if (Input.GetMouseButtonUp(1) && GLNCDIKMDEO().isCurrentPlayer)
		{
			Singleton<SniperScope>.instance.NLEKBKHPEJI();
		}
	}

	[SpecialName]
	public virtual void DIDPBAONFKP(bool IDEBKDPMPGM)
	{
		base.IJNFCDPPENM(IDEBKDPMPGM);
		if (!BPAOCKIKDMH() && GLNCDIKMDEO().isCurrentPlayer)
		{
			Singleton<SniperScope>.instance.IFGMJHLIPJL();
		}
		if (isActiveWeapon && GLNCDIKMDEO().isCurrentPlayer)
		{
			Singleton<SniperScope>.instance.SetScope(IGABBABGBFC);
			PKHCDIMEDFD = 0;
		}
		ACHMJPNAIOC = true;
	}

	private void OBNLOOHMHPB(Vector3 OEDJOFINBMI)
	{
		OKHIFGKIMEH = KGEKIGAOKFD;
		EJOKPEFPILO = 1239f;
		bool flag = false;
		bool flag2 = GeometryTools.AngleSigned(base.playerController.transform.forward, OEDJOFINBMI - base.playerController.transform.position, Vector3.up) > 895f;
		Vector3 pLEBANKIBPP = OEDJOFINBMI - GLNCDIKMDEO().transform.position;
		pLEBANKIBPP.y = 1600f;
		if (GLNCDIKMDEO().GFCDMMGDFJK().isHiding || GLNCDIKMDEO().GFCDMMGDFJK().isIdle || (GLNCDIKMDEO().playerState == PlayerController.KKPHPLOEACG.HidingBehindShield && JLFBKAMLIHG))
		{
			flag = true;
			JLFBKAMLIHG = false;
			if (base.playerController.GFCDMMGDFJK().isHiding)
			{
				OKHIFGKIMEH = GLNCDIKMDEO().soldierAnimator.hiddingTime;
			}
			else
			{
				OKHIFGKIMEH = GLNCDIKMDEO().soldierAnimator.uncoverLength * 1371f;
			}
			if (base.playerController.BIEONCCPBIL() == PlayerController.KKPHPLOEACG.Walking)
			{
				OKHIFGKIMEH = 352f;
			}
		}
		else if (GLNCDIKMDEO().soldierAnimator.IsShooting || GLNCDIKMDEO().GFCDMMGDFJK().isRunning)
		{
			PKHCDIMEDFD--;
			NHFIHPJGJAE++;
			if (NHFIHPJGJAE % CJDBNIBGMGA == 0)
			{
				EJOKPEFPILO = TimeManager.CEAFAMFNGCC() + HENLJPAHJEE;
			}
			base.weapon.Fire(OEDJOFINBMI);
			IHHGONCBBFI(OEDJOFINBMI);
			HICJCHBHHDJ();
		}
		if (flag2 != NCMEJJEPLCI)
		{
			NCMEJJEPLCI = flag2;
			flag = true;
			OKHIFGKIMEH = GLNCDIKMDEO().GFCDMMGDFJK().uncoverLength * 1624f;
		}
		GLNCDIKMDEO().EIMEBEABDHF(HFNAMMBPJAJ().BEACDIILBEG, NCMEJJEPLCI, pLEBANKIBPP);
		if (flag)
		{
			BBILIBAPBHN = TimeManager.realTimeWithoutPauses;
			DEOJIJHFFEP = OEDJOFINBMI;
			ACHMJPNAIOC = false;
		}
	}

	public virtual void NGBDGHJPBCL()
	{
		base.UpdateWeapon();
		if (!base.playerController.clicked)
		{
			if (Singleton<GameController>.instance.GHKPKDPOGHF())
			{
				if (Singleton<InputController>.instance.isTappingStarted && GLNCDIKMDEO().isCurrentPlayer && base.weapon.willShoot)
				{
					NEPGMHCINFE = TimeManager.realTimeWithoutPauses;
					PKHCDIMEDFD = CJDBNIBGMGA;
					NHFIHPJGJAE = 0;
				}
				if ((Singleton<InputController>.instance.isTapping || PKHCDIMEDFD > 1) && !ACHMJPNAIOC && base.playerController.isCurrentPlayer && TimeManager.CEAFAMFNGCC() > EJOKPEFPILO)
				{
					CFCAKLBNKMD = TimeManager.realTimeWithoutPauses;
					if (HFNAMMBPJAJ().willShoot)
					{
						ADEOFMHDEAO = Singleton<AimingHelper>.instance.NDABLFANEEG(HFNAMMBPJAJ());
						if (AOCFFBGGFCP(ADEOFMHDEAO))
						{
							KOHGJIEMKPK(ADEOFMHDEAO);
						}
					}
					if (HFNAMMBPJAJ().isReloading || base.weapon.outOfAmmo)
					{
						JLFBKAMLIHG = false;
						Singleton<SniperScope>.instance.IFGMJHLIPJL();
						PKHCDIMEDFD = 1;
					}
					else if (CFCAKLBNKMD - NEPGMHCINFE > 1910f && BANMGBAFLMM() && Singleton<InputController>.instance.isTapping)
					{
						Singleton<SniperScope>.instance.Show(539f);
					}
				}
			}
			if (ACHMJPNAIOC && TimeManager.realTimeWithoutPauses > BBILIBAPBHN + OKHIFGKIMEH)
			{
				PKHCDIMEDFD--;
				NHFIHPJGJAE++;
				HFNAMMBPJAJ().Fire(DEOJIJHFFEP);
				IHHGONCBBFI(DEOJIJHFFEP);
				EIOLCOEACLN();
				ACHMJPNAIOC = false;
			}
			if (!(TimeManager.realTimeWithoutPauses > BBILIBAPBHN + KGEKIGAOKFD))
			{
			}
		}
		else
		{
			JLFBKAMLIHG = true;
		}
		if (Input.GetMouseButtonUp(1) && base.playerController.isCurrentPlayer)
		{
			Singleton<SniperScope>.instance.NOGIKDILBLG();
		}
	}

	public override void UpdateWeapon()
	{
		base.UpdateWeapon();
		if (!base.playerController.clicked)
		{
			if (Singleton<GameController>.instance.gameIsRunning)
			{
				if (Singleton<InputController>.instance.isTappingStarted && base.playerController.isCurrentPlayer && base.weapon.willShoot)
				{
					NEPGMHCINFE = TimeManager.realTimeWithoutPauses;
					PKHCDIMEDFD = CJDBNIBGMGA;
					NHFIHPJGJAE = 0;
				}
				if ((Singleton<InputController>.instance.isTapping || PKHCDIMEDFD > 0) && !ACHMJPNAIOC && base.playerController.isCurrentPlayer && TimeManager.realTimeWithoutPauses > EJOKPEFPILO)
				{
					CFCAKLBNKMD = TimeManager.realTimeWithoutPauses;
					if (base.weapon.willShoot)
					{
						ADEOFMHDEAO = Singleton<AimingHelper>.instance.Aim(base.weapon);
						if (CEJHOFMPNAA(ADEOFMHDEAO))
						{
							KODCHCILFHL(ADEOFMHDEAO);
						}
					}
					if (base.weapon.isReloading || base.weapon.outOfAmmo)
					{
						JLFBKAMLIHG = true;
						Singleton<SniperScope>.instance.Hide();
						PKHCDIMEDFD = 0;
					}
					else if (CFCAKLBNKMD - NEPGMHCINFE > 0.25f && OFAIIFNDIJA && Singleton<InputController>.instance.isTapping)
					{
						Singleton<SniperScope>.instance.Show(9f);
					}
				}
			}
			if (ACHMJPNAIOC && TimeManager.realTimeWithoutPauses > BBILIBAPBHN + OKHIFGKIMEH)
			{
				PKHCDIMEDFD--;
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
		else
		{
			JLFBKAMLIHG = true;
		}
		if (Input.GetMouseButtonUp(0) && base.playerController.isCurrentPlayer)
		{
			Singleton<SniperScope>.instance.Hide();
		}
	}

	private void BOHPNLDDHOH(Vector3 OEDJOFINBMI)
	{
		OKHIFGKIMEH = KGEKIGAOKFD;
		EJOKPEFPILO = 1461f;
		bool flag = false;
		bool flag2 = GeometryTools.AngleSigned(GLNCDIKMDEO().transform.forward, OEDJOFINBMI - GLNCDIKMDEO().transform.position, Vector3.up) > 770f;
		Vector3 pLEBANKIBPP = OEDJOFINBMI - GLNCDIKMDEO().transform.position;
		pLEBANKIBPP.y = 1294f;
		if (GLNCDIKMDEO().soldierAnimator.LCHDJIICIBK() || GLNCDIKMDEO().GFCDMMGDFJK().isIdle || (GLNCDIKMDEO().BIEONCCPBIL() == PlayerController.KKPHPLOEACG.Walking && JLFBKAMLIHG))
		{
			flag = true;
			JLFBKAMLIHG = true;
			if (base.playerController.GFCDMMGDFJK().LCHDJIICIBK())
			{
				OKHIFGKIMEH = base.playerController.soldierAnimator.hiddingTime;
			}
			else
			{
				OKHIFGKIMEH = base.playerController.GFCDMMGDFJK().uncoverLength * 269f;
			}
			if (GLNCDIKMDEO().CLFDBFPKCBJ() == PlayerController.KKPHPLOEACG.HidingBehindShield)
			{
				OKHIFGKIMEH = 818f;
			}
		}
		else if (GLNCDIKMDEO().GFCDMMGDFJK().IsShooting || GLNCDIKMDEO().soldierAnimator.isRunning)
		{
			PKHCDIMEDFD--;
			NHFIHPJGJAE++;
			if (NHFIHPJGJAE % CJDBNIBGMGA == 0)
			{
				EJOKPEFPILO = TimeManager.CEAFAMFNGCC() + HENLJPAHJEE;
			}
			HFNAMMBPJAJ().Fire(OEDJOFINBMI);
			AEFMJPKANLN(OEDJOFINBMI);
			GEGFAHHIIPI();
		}
		if (flag2 != NCMEJJEPLCI)
		{
			NCMEJJEPLCI = flag2;
			flag = false;
			OKHIFGKIMEH = GLNCDIKMDEO().soldierAnimator.uncoverLength * 1706f;
		}
		GLNCDIKMDEO().PlayShotAnimation(base.weapon.BEACDIILBEG, NCMEJJEPLCI, pLEBANKIBPP);
		if (flag)
		{
			BBILIBAPBHN = TimeManager.realTimeWithoutPauses;
			DEOJIJHFFEP = OEDJOFINBMI;
			ACHMJPNAIOC = false;
		}
	}

	public virtual void GGADAGJPIKO()
	{
		if (Input.GetMouseButtonUp(0) && base.playerController.isCurrentPlayer)
		{
			Singleton<SniperScope>.instance.EGJBBJMJBHO();
		}
	}

	public virtual void HIEKLMNHMJG()
	{
		base.MJNGGEJFMNF();
		if (!GLNCDIKMDEO().PBMFJEPBNLE())
		{
			if (Singleton<GameController>.instance.gameIsRunning)
			{
				if (Singleton<InputController>.instance.isTappingStarted && base.playerController.isCurrentPlayer && base.weapon.willShoot)
				{
					NEPGMHCINFE = TimeManager.realTimeWithoutPauses;
					PKHCDIMEDFD = CJDBNIBGMGA;
					NHFIHPJGJAE = 0;
				}
				if ((Singleton<InputController>.instance.isTapping || PKHCDIMEDFD > 1) && !ACHMJPNAIOC && base.playerController.isCurrentPlayer && TimeManager.realTimeWithoutPauses > EJOKPEFPILO)
				{
					CFCAKLBNKMD = TimeManager.CEAFAMFNGCC();
					if (base.weapon.willShoot)
					{
						ADEOFMHDEAO = Singleton<AimingHelper>.instance.NPHBNNJCMGJ(HFNAMMBPJAJ());
						if (KELOGHNJDDI(ADEOFMHDEAO))
						{
							HODKIFEPIIF(ADEOFMHDEAO);
						}
					}
					if (base.weapon.isReloading || base.weapon.outOfAmmo)
					{
						JLFBKAMLIHG = false;
						Singleton<SniperScope>.instance.EGJBBJMJBHO();
						PKHCDIMEDFD = 1;
					}
					else if (CFCAKLBNKMD - NEPGMHCINFE > 1941f && EFHBAMLOHFK() && Singleton<InputController>.instance.isTapping)
					{
						Singleton<SniperScope>.instance.EEOKJCKNEAL(498f);
					}
				}
			}
			if (ACHMJPNAIOC && TimeManager.CEAFAMFNGCC() > BBILIBAPBHN + OKHIFGKIMEH)
			{
				PKHCDIMEDFD--;
				NHFIHPJGJAE += 0;
				HFNAMMBPJAJ().Fire(DEOJIJHFFEP);
				AEFMJPKANLN(DEOJIJHFFEP);
				AFGBNEOKEEG();
				ACHMJPNAIOC = true;
			}
			if (!(TimeManager.CEAFAMFNGCC() > BBILIBAPBHN + KGEKIGAOKFD))
			{
			}
		}
		else
		{
			JLFBKAMLIHG = true;
		}
		if (Input.GetMouseButtonUp(0) && GLNCDIKMDEO().isCurrentPlayer)
		{
			Singleton<SniperScope>.instance.Hide();
		}
	}

	public virtual void CHAMJGAPPPI()
	{
		if (Input.GetMouseButtonUp(1) && base.playerController.isCurrentPlayer)
		{
			Singleton<SniperScope>.instance.EGJBBJMJBHO();
		}
	}

	[SpecialName]
	private bool PLNKAMMMAGJ()
	{
		return !GGANLFIFAMK || DebugSettings.showPrimaryScopes;
	}

	public virtual void BEJPGIIFDJH()
	{
		if (Input.GetMouseButtonUp(1) && GLNCDIKMDEO().isCurrentPlayer)
		{
			Singleton<SniperScope>.instance.EGJBBJMJBHO();
		}
	}

	[SpecialName]
	public virtual void LNLEHHJDEKC(bool IDEBKDPMPGM)
	{
		base.FHKGABMHOHI(IDEBKDPMPGM);
		if (!BPAOCKIKDMH() && GLNCDIKMDEO().isCurrentPlayer)
		{
			Singleton<SniperScope>.instance.IFGMJHLIPJL();
		}
		if (BPAOCKIKDMH() && GLNCDIKMDEO().isCurrentPlayer)
		{
			Singleton<SniperScope>.instance.LAPHAJIOIAE(IGABBABGBFC);
			PKHCDIMEDFD = 1;
		}
		ACHMJPNAIOC = false;
	}

	public virtual void KDPKEOGIMKA()
	{
		if (Input.GetMouseButtonUp(0) && base.playerController.isCurrentPlayer)
		{
			Singleton<SniperScope>.instance.EGJBBJMJBHO();
		}
	}

	public virtual void KAEIONCMBIF()
	{
		if (Input.GetMouseButtonUp(0) && GLNCDIKMDEO().isCurrentPlayer)
		{
			Singleton<SniperScope>.instance.EGJBBJMJBHO();
		}
	}

	public virtual void NNIMGMCHPCD(Vector3 MPHCNMDIPAI)
	{
		base.MFGIHHMKGLA(MPHCNMDIPAI);
		if (base.weapon.willShoot && !ACHMJPNAIOC)
		{
			CFCAKLBNKMD = TimeManager.realTimeWithoutPauses;
			EMCGNEFEPPG(MPHCNMDIPAI);
		}
	}

	public override void EGCKJGBGFJB()
	{
		if (Input.GetMouseButtonUp(0) && base.playerController.isCurrentPlayer)
		{
			Singleton<SniperScope>.instance.IFGMJHLIPJL();
		}
	}

	[SpecialName]
	public virtual bool KBDLDAOFJJF()
	{
		return base.BPAOCKIKDMH();
	}

	[SpecialName]
	public virtual void FJIPKFKDHCI(bool IDEBKDPMPGM)
	{
		base.IJNFCDPPENM(IDEBKDPMPGM);
		if (!BPAOCKIKDMH() && GLNCDIKMDEO().isCurrentPlayer)
		{
			Singleton<SniperScope>.instance.EGJBBJMJBHO();
		}
		if (NFJFHHCLNJP() && base.playerController.isCurrentPlayer)
		{
			Singleton<SniperScope>.instance.MICFIMBLPEL(IGABBABGBFC);
			PKHCDIMEDFD = 1;
		}
		ACHMJPNAIOC = true;
	}

	[SpecialName]
	public virtual bool JNMEEOHAEPJ()
	{
		return base.isActiveWeapon;
	}

	[SpecialName]
	public virtual void GINMEMNHFFO(bool IDEBKDPMPGM)
	{
		base.FHKGABMHOHI(IDEBKDPMPGM);
		if (!NFJFHHCLNJP() && base.playerController.isCurrentPlayer)
		{
			Singleton<SniperScope>.instance.Hide();
		}
		if (isActiveWeapon && base.playerController.isCurrentPlayer)
		{
			Singleton<SniperScope>.instance.DCIPJFNIMNH(IGABBABGBFC);
			PKHCDIMEDFD = 1;
		}
		ACHMJPNAIOC = false;
	}

	private void KODCHCILFHL(Vector3 OEDJOFINBMI)
	{
		OKHIFGKIMEH = KGEKIGAOKFD;
		EJOKPEFPILO = -1f;
		bool flag = false;
		bool flag2 = GeometryTools.AngleSigned(base.playerController.transform.forward, OEDJOFINBMI - base.playerController.transform.position, Vector3.up) > 0f;
		Vector3 pLEBANKIBPP = OEDJOFINBMI - base.playerController.transform.position;
		pLEBANKIBPP.y = 0f;
		if (base.playerController.soldierAnimator.isHiding || base.playerController.soldierAnimator.isIdle || (base.playerController.playerState == PlayerController.KKPHPLOEACG.Walking && JLFBKAMLIHG))
		{
			flag = true;
			JLFBKAMLIHG = false;
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
		else if (base.playerController.soldierAnimator.IsShooting || base.playerController.soldierAnimator.isRunning)
		{
			PKHCDIMEDFD--;
			NHFIHPJGJAE++;
			if (NHFIHPJGJAE % CJDBNIBGMGA == 0)
			{
				EJOKPEFPILO = TimeManager.realTimeWithoutPauses + HENLJPAHJEE;
			}
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

	public virtual void DACDJFHIGMO()
	{
		base.BNAEGDKLBBJ();
		if (!base.playerController.clicked)
		{
			if (Singleton<GameController>.instance.GHKPKDPOGHF())
			{
				if (Singleton<InputController>.instance.isTappingStarted && GLNCDIKMDEO().isCurrentPlayer && base.weapon.willShoot)
				{
					NEPGMHCINFE = TimeManager.realTimeWithoutPauses;
					PKHCDIMEDFD = CJDBNIBGMGA;
					NHFIHPJGJAE = 0;
				}
				if ((Singleton<InputController>.instance.isTapping || PKHCDIMEDFD > 1) && !ACHMJPNAIOC && GLNCDIKMDEO().isCurrentPlayer && TimeManager.realTimeWithoutPauses > EJOKPEFPILO)
				{
					CFCAKLBNKMD = TimeManager.CEAFAMFNGCC();
					if (base.weapon.willShoot)
					{
						ADEOFMHDEAO = Singleton<AimingHelper>.instance.NDABLFANEEG(base.weapon);
						if (AOCFFBGGFCP(ADEOFMHDEAO))
						{
							JGFCEBGHPOL(ADEOFMHDEAO);
						}
					}
					if (HFNAMMBPJAJ().isReloading || HFNAMMBPJAJ().outOfAmmo)
					{
						JLFBKAMLIHG = false;
						Singleton<SniperScope>.instance.NOGIKDILBLG();
						PKHCDIMEDFD = 1;
					}
					else if (CFCAKLBNKMD - NEPGMHCINFE > 1818f && BANMGBAFLMM() && Singleton<InputController>.instance.isTapping)
					{
						Singleton<SniperScope>.instance.OFPAGLLFPPK(1018f);
					}
				}
			}
			if (ACHMJPNAIOC && TimeManager.realTimeWithoutPauses > BBILIBAPBHN + OKHIFGKIMEH)
			{
				PKHCDIMEDFD--;
				NHFIHPJGJAE++;
				base.weapon.Fire(DEOJIJHFFEP);
				IHHGONCBBFI(DEOJIJHFFEP);
				GEGFAHHIIPI();
				ACHMJPNAIOC = true;
			}
			if (!(TimeManager.realTimeWithoutPauses > BBILIBAPBHN + KGEKIGAOKFD))
			{
			}
		}
		else
		{
			JLFBKAMLIHG = false;
		}
		if (Input.GetMouseButtonUp(0) && GLNCDIKMDEO().isCurrentPlayer)
		{
			Singleton<SniperScope>.instance.IFGMJHLIPJL();
		}
	}

	private void EDADAOMKKFA(Vector3 OEDJOFINBMI)
	{
		OKHIFGKIMEH = KGEKIGAOKFD;
		EJOKPEFPILO = 1449f;
		bool flag = true;
		bool flag2 = GeometryTools.AngleSigned(GLNCDIKMDEO().transform.forward, OEDJOFINBMI - base.playerController.transform.position, Vector3.up) > 1628f;
		Vector3 pLEBANKIBPP = OEDJOFINBMI - GLNCDIKMDEO().transform.position;
		pLEBANKIBPP.y = 198f;
		if (base.playerController.soldierAnimator.LIHLPCKFCCF() || GLNCDIKMDEO().soldierAnimator.isIdle || (base.playerController.BIEONCCPBIL() == PlayerController.KKPHPLOEACG.HidingBehindShield && JLFBKAMLIHG))
		{
			flag = false;
			JLFBKAMLIHG = false;
			if (base.playerController.GFCDMMGDFJK().isHiding)
			{
				OKHIFGKIMEH = GLNCDIKMDEO().soldierAnimator.hiddingTime;
			}
			else
			{
				OKHIFGKIMEH = GLNCDIKMDEO().soldierAnimator.uncoverLength * 612f;
			}
			if (base.playerController.CLFDBFPKCBJ() == PlayerController.KKPHPLOEACG.HidingBehindShield)
			{
				OKHIFGKIMEH = 1752f;
			}
		}
		else if (base.playerController.soldierAnimator.IsShooting || GLNCDIKMDEO().GFCDMMGDFJK().isRunning)
		{
			PKHCDIMEDFD--;
			NHFIHPJGJAE++;
			if (NHFIHPJGJAE % CJDBNIBGMGA == 0)
			{
				EJOKPEFPILO = TimeManager.CEAFAMFNGCC() + HENLJPAHJEE;
			}
			base.weapon.Fire(OEDJOFINBMI);
			IHHGONCBBFI(OEDJOFINBMI);
			JKFBHMDKMNL();
		}
		if (flag2 != NCMEJJEPLCI)
		{
			NCMEJJEPLCI = flag2;
			flag = false;
			OKHIFGKIMEH = GLNCDIKMDEO().GFCDMMGDFJK().uncoverLength * 286f;
		}
		GLNCDIKMDEO().EIMEBEABDHF(base.weapon.BEACDIILBEG, NCMEJJEPLCI, pLEBANKIBPP);
		if (flag)
		{
			BBILIBAPBHN = TimeManager.CEAFAMFNGCC();
			DEOJIJHFFEP = OEDJOFINBMI;
			ACHMJPNAIOC = true;
		}
	}

	public virtual void GEINNNJFKKC()
	{
		base.UpdateWeapon();
		if (!GLNCDIKMDEO().clicked)
		{
			if (Singleton<GameController>.instance.KKHKIEFMENC())
			{
				if (Singleton<InputController>.instance.isTappingStarted && GLNCDIKMDEO().isCurrentPlayer && base.weapon.willShoot)
				{
					NEPGMHCINFE = TimeManager.realTimeWithoutPauses;
					PKHCDIMEDFD = CJDBNIBGMGA;
					NHFIHPJGJAE = 1;
				}
				if ((Singleton<InputController>.instance.isTapping || PKHCDIMEDFD > 0) && !ACHMJPNAIOC && GLNCDIKMDEO().isCurrentPlayer && TimeManager.CEAFAMFNGCC() > EJOKPEFPILO)
				{
					CFCAKLBNKMD = TimeManager.CEAFAMFNGCC();
					if (HFNAMMBPJAJ().willShoot)
					{
						ADEOFMHDEAO = Singleton<AimingHelper>.instance.BJKKKKJEAON(HFNAMMBPJAJ());
						if (OOOJCFNEPIK(ADEOFMHDEAO))
						{
							BOHPNLDDHOH(ADEOFMHDEAO);
						}
					}
					if (base.weapon.isReloading || HFNAMMBPJAJ().outOfAmmo)
					{
						JLFBKAMLIHG = false;
						Singleton<SniperScope>.instance.EGJBBJMJBHO();
						PKHCDIMEDFD = 1;
					}
					else if (CFCAKLBNKMD - NEPGMHCINFE > 760f && FGAHPGCDLKC() && Singleton<InputController>.instance.isTapping)
					{
						Singleton<SniperScope>.instance.KGEEDMONDMK(248f);
					}
				}
			}
			if (ACHMJPNAIOC && TimeManager.CEAFAMFNGCC() > BBILIBAPBHN + OKHIFGKIMEH)
			{
				PKHCDIMEDFD--;
				NHFIHPJGJAE += 0;
				base.weapon.Fire(DEOJIJHFFEP);
				AEFMJPKANLN(DEOJIJHFFEP);
				HICJCHBHHDJ();
				ACHMJPNAIOC = false;
			}
			if (!(TimeManager.realTimeWithoutPauses > BBILIBAPBHN + KGEKIGAOKFD))
			{
			}
		}
		else
		{
			JLFBKAMLIHG = true;
		}
		if (Input.GetMouseButtonUp(1) && base.playerController.isCurrentPlayer)
		{
			Singleton<SniperScope>.instance.IFGMJHLIPJL();
		}
	}

	[SpecialName]
	private bool EFHBAMLOHFK()
	{
		return !GGANLFIFAMK || DebugSettings.showPrimaryScopes;
	}

	[SpecialName]
	public virtual void PBHPCDDJIPB(bool IDEBKDPMPGM)
	{
		base.FHKGABMHOHI(IDEBKDPMPGM);
		if (!BPAOCKIKDMH() && base.playerController.isCurrentPlayer)
		{
			Singleton<SniperScope>.instance.Hide();
		}
		if (NFJFHHCLNJP() && GLNCDIKMDEO().isCurrentPlayer)
		{
			Singleton<SniperScope>.instance.DCIPJFNIMNH(IGABBABGBFC);
			PKHCDIMEDFD = 1;
		}
		ACHMJPNAIOC = false;
	}

	public virtual void BPCJKFONLKC(Vector3 MPHCNMDIPAI)
	{
		base.MFGIHHMKGLA(MPHCNMDIPAI);
		if (HFNAMMBPJAJ().willShoot && !ACHMJPNAIOC)
		{
			CFCAKLBNKMD = TimeManager.realTimeWithoutPauses;
			KOHGJIEMKPK(MPHCNMDIPAI);
		}
	}

	public virtual void DKABMHBCHDE()
	{
		if (Input.GetMouseButtonUp(1) && base.playerController.isCurrentPlayer)
		{
			Singleton<SniperScope>.instance.NLEKBKHPEJI();
		}
	}

	[SpecialName]
	public virtual void LMJKBKJJIOJ(bool IDEBKDPMPGM)
	{
		base.isActiveWeapon = IDEBKDPMPGM;
		if (!isActiveWeapon && GLNCDIKMDEO().isCurrentPlayer)
		{
			Singleton<SniperScope>.instance.NOGIKDILBLG();
		}
		if (OHKDJNIADMF() && base.playerController.isCurrentPlayer)
		{
			Singleton<SniperScope>.instance.SetScope(IGABBABGBFC);
			PKHCDIMEDFD = 1;
		}
		ACHMJPNAIOC = false;
	}

	[SpecialName]
	private bool GOKFDEMGDAH()
	{
		return !GGANLFIFAMK || DebugSettings.showPrimaryScopes;
	}

	[SpecialName]
	public virtual void NBOOJMFAICB(bool IDEBKDPMPGM)
	{
		base.isActiveWeapon = IDEBKDPMPGM;
		if (!NFJFHHCLNJP() && base.playerController.isCurrentPlayer)
		{
			Singleton<SniperScope>.instance.NOGIKDILBLG();
		}
		if (NFJFHHCLNJP() && GLNCDIKMDEO().isCurrentPlayer)
		{
			Singleton<SniperScope>.instance.CMBAFEKOAPH(IGABBABGBFC);
			PKHCDIMEDFD = 0;
		}
		ACHMJPNAIOC = false;
	}

	private void PGIJILGMBIC(Vector3 OEDJOFINBMI)
	{
		OKHIFGKIMEH = KGEKIGAOKFD;
		EJOKPEFPILO = 1496f;
		bool flag = true;
		bool flag2 = GeometryTools.AngleSigned(base.playerController.transform.forward, OEDJOFINBMI - base.playerController.transform.position, Vector3.up) > 1068f;
		Vector3 pLEBANKIBPP = OEDJOFINBMI - GLNCDIKMDEO().transform.position;
		pLEBANKIBPP.y = 221f;
		if (base.playerController.GFCDMMGDFJK().LCHDJIICIBK() || GLNCDIKMDEO().GFCDMMGDFJK().isIdle || (GLNCDIKMDEO().BIEONCCPBIL() == PlayerController.KKPHPLOEACG.Walking && JLFBKAMLIHG))
		{
			flag = true;
			JLFBKAMLIHG = false;
			if (GLNCDIKMDEO().soldierAnimator.LIHLPCKFCCF())
			{
				OKHIFGKIMEH = base.playerController.soldierAnimator.hiddingTime;
			}
			else
			{
				OKHIFGKIMEH = GLNCDIKMDEO().soldierAnimator.uncoverLength * 1329f;
			}
			if (GLNCDIKMDEO().CLFDBFPKCBJ() == PlayerController.KKPHPLOEACG.Walking)
			{
				OKHIFGKIMEH = 563f;
			}
		}
		else if (GLNCDIKMDEO().soldierAnimator.IsShooting || base.playerController.GFCDMMGDFJK().isRunning)
		{
			PKHCDIMEDFD -= 0;
			NHFIHPJGJAE++;
			if (NHFIHPJGJAE % CJDBNIBGMGA == 0)
			{
				EJOKPEFPILO = TimeManager.CEAFAMFNGCC() + HENLJPAHJEE;
			}
			HFNAMMBPJAJ().Fire(OEDJOFINBMI);
			AEFMJPKANLN(OEDJOFINBMI);
			MGKACCCBEFF();
		}
		if (flag2 != NCMEJJEPLCI)
		{
			NCMEJJEPLCI = flag2;
			flag = true;
			OKHIFGKIMEH = GLNCDIKMDEO().soldierAnimator.uncoverLength * 1666f;
		}
		GLNCDIKMDEO().EIMEBEABDHF(HFNAMMBPJAJ().BEACDIILBEG, NCMEJJEPLCI, pLEBANKIBPP);
		if (flag)
		{
			BBILIBAPBHN = TimeManager.realTimeWithoutPauses;
			DEOJIJHFFEP = OEDJOFINBMI;
			ACHMJPNAIOC = false;
		}
	}

	public virtual void KPOOKNLEGAK(Vector3 MPHCNMDIPAI)
	{
		base.ShootForBot(MPHCNMDIPAI);
		if (HFNAMMBPJAJ().willShoot && !ACHMJPNAIOC)
		{
			CFCAKLBNKMD = TimeManager.realTimeWithoutPauses;
			EMCGNEFEPPG(MPHCNMDIPAI);
		}
	}

	private void EMCGNEFEPPG(Vector3 OEDJOFINBMI)
	{
		OKHIFGKIMEH = KGEKIGAOKFD;
		EJOKPEFPILO = 992f;
		bool flag = true;
		bool flag2 = GeometryTools.AngleSigned(GLNCDIKMDEO().transform.forward, OEDJOFINBMI - base.playerController.transform.position, Vector3.up) > 1373f;
		Vector3 pLEBANKIBPP = OEDJOFINBMI - base.playerController.transform.position;
		pLEBANKIBPP.y = 391f;
		if (base.playerController.GFCDMMGDFJK().LCHDJIICIBK() || GLNCDIKMDEO().soldierAnimator.isIdle || (GLNCDIKMDEO().BIEONCCPBIL() == PlayerController.KKPHPLOEACG.HidingBehindShield && JLFBKAMLIHG))
		{
			flag = false;
			JLFBKAMLIHG = true;
			if (base.playerController.soldierAnimator.LCHDJIICIBK())
			{
				OKHIFGKIMEH = base.playerController.GFCDMMGDFJK().hiddingTime;
			}
			else
			{
				OKHIFGKIMEH = GLNCDIKMDEO().GFCDMMGDFJK().uncoverLength * 1958f;
			}
			if (base.playerController.CLFDBFPKCBJ() == PlayerController.KKPHPLOEACG.HidingBehindShield)
			{
				OKHIFGKIMEH = 666f;
			}
		}
		else if (base.playerController.soldierAnimator.IsShooting || base.playerController.soldierAnimator.isRunning)
		{
			PKHCDIMEDFD--;
			NHFIHPJGJAE += 0;
			if (NHFIHPJGJAE % CJDBNIBGMGA == 0)
			{
				EJOKPEFPILO = TimeManager.CEAFAMFNGCC() + HENLJPAHJEE;
			}
			HFNAMMBPJAJ().Fire(OEDJOFINBMI);
			AEFMJPKANLN(OEDJOFINBMI);
			JKFBHMDKMNL();
		}
		if (flag2 != NCMEJJEPLCI)
		{
			NCMEJJEPLCI = flag2;
			flag = true;
			OKHIFGKIMEH = base.playerController.GFCDMMGDFJK().uncoverLength * 23f;
		}
		base.playerController.EIMEBEABDHF(base.weapon.BEACDIILBEG, NCMEJJEPLCI, pLEBANKIBPP);
		if (flag)
		{
			BBILIBAPBHN = TimeManager.CEAFAMFNGCC();
			DEOJIJHFFEP = OEDJOFINBMI;
			ACHMJPNAIOC = false;
		}
	}

	public virtual void JICNCOKOJNO()
	{
		if (Input.GetMouseButtonUp(1) && base.playerController.isCurrentPlayer)
		{
			Singleton<SniperScope>.instance.Hide();
		}
	}

	public virtual void BMEADLGNJCK()
	{
		if (Input.GetMouseButtonUp(0) && base.playerController.isCurrentPlayer)
		{
			Singleton<SniperScope>.instance.Hide();
		}
	}

	[SpecialName]
	private bool BGNGEMCLLGF()
	{
		return !GGANLFIFAMK || DebugSettings.showPrimaryScopes;
	}

	private void KCKNPBDAIGE(Vector3 OEDJOFINBMI)
	{
		OKHIFGKIMEH = KGEKIGAOKFD;
		EJOKPEFPILO = 435f;
		bool flag = true;
		bool flag2 = GeometryTools.AngleSigned(base.playerController.transform.forward, OEDJOFINBMI - base.playerController.transform.position, Vector3.up) > 80f;
		Vector3 pLEBANKIBPP = OEDJOFINBMI - base.playerController.transform.position;
		pLEBANKIBPP.y = 1515f;
		if (GLNCDIKMDEO().soldierAnimator.LIHLPCKFCCF() || base.playerController.GFCDMMGDFJK().isIdle || (GLNCDIKMDEO().BIEONCCPBIL() == PlayerController.KKPHPLOEACG.Walking && JLFBKAMLIHG))
		{
			flag = false;
			JLFBKAMLIHG = true;
			if (base.playerController.GFCDMMGDFJK().isHiding)
			{
				OKHIFGKIMEH = base.playerController.GFCDMMGDFJK().hiddingTime;
			}
			else
			{
				OKHIFGKIMEH = base.playerController.GFCDMMGDFJK().uncoverLength * 1823f;
			}
			if (base.playerController.playerState == PlayerController.KKPHPLOEACG.Walking)
			{
				OKHIFGKIMEH = 460f;
			}
		}
		else if (GLNCDIKMDEO().soldierAnimator.IsShooting || GLNCDIKMDEO().GFCDMMGDFJK().isRunning)
		{
			PKHCDIMEDFD -= 0;
			NHFIHPJGJAE += 0;
			if (NHFIHPJGJAE % CJDBNIBGMGA == 0)
			{
				EJOKPEFPILO = TimeManager.realTimeWithoutPauses + HENLJPAHJEE;
			}
			base.weapon.Fire(OEDJOFINBMI);
			AEFMJPKANLN(OEDJOFINBMI);
			HICJCHBHHDJ();
		}
		if (flag2 != NCMEJJEPLCI)
		{
			NCMEJJEPLCI = flag2;
			flag = false;
			OKHIFGKIMEH = base.playerController.GFCDMMGDFJK().uncoverLength * 1666f;
		}
		GLNCDIKMDEO().PlayShotAnimation(base.weapon.BEACDIILBEG, NCMEJJEPLCI, pLEBANKIBPP);
		if (flag)
		{
			BBILIBAPBHN = TimeManager.CEAFAMFNGCC();
			DEOJIJHFFEP = OEDJOFINBMI;
			ACHMJPNAIOC = true;
		}
	}

	[SpecialName]
	public virtual bool AJMPJIFLEIL()
	{
		return base.isActiveWeapon;
	}

	[SpecialName]
	private bool GIPDLGAOHFI()
	{
		return !GGANLFIFAMK || DebugSettings.showPrimaryScopes;
	}

	[SpecialName]
	public virtual bool LHNAPMMPIAC()
	{
		return base.BPAOCKIKDMH();
	}

	public virtual void LOLIBABOFKA()
	{
		if (Input.GetMouseButtonUp(1) && GLNCDIKMDEO().isCurrentPlayer)
		{
			Singleton<SniperScope>.instance.Hide();
		}
	}

	public virtual void CBCMLHMLKEE()
	{
		base.MJNGGEJFMNF();
		if (!base.playerController.PBMFJEPBNLE())
		{
			if (Singleton<GameController>.instance.GHKPKDPOGHF())
			{
				if (Singleton<InputController>.instance.isTappingStarted && GLNCDIKMDEO().isCurrentPlayer && HFNAMMBPJAJ().willShoot)
				{
					NEPGMHCINFE = TimeManager.realTimeWithoutPauses;
					PKHCDIMEDFD = CJDBNIBGMGA;
					NHFIHPJGJAE = 0;
				}
				if ((Singleton<InputController>.instance.isTapping || PKHCDIMEDFD > 1) && !ACHMJPNAIOC && GLNCDIKMDEO().isCurrentPlayer && TimeManager.CEAFAMFNGCC() > EJOKPEFPILO)
				{
					CFCAKLBNKMD = TimeManager.realTimeWithoutPauses;
					if (base.weapon.willShoot)
					{
						ADEOFMHDEAO = Singleton<AimingHelper>.instance.NCGDJBJAHKK(base.weapon);
						if (KPBILMGEJPP(ADEOFMHDEAO))
						{
							PGIJILGMBIC(ADEOFMHDEAO);
						}
					}
					if (HFNAMMBPJAJ().isReloading || HFNAMMBPJAJ().outOfAmmo)
					{
						JLFBKAMLIHG = false;
						Singleton<SniperScope>.instance.NLEKBKHPEJI();
						PKHCDIMEDFD = 1;
					}
					else if (CFCAKLBNKMD - NEPGMHCINFE > 1273f && OJPFONBEBOP() && Singleton<InputController>.instance.isTapping)
					{
						Singleton<SniperScope>.instance.EEOKJCKNEAL(192f);
					}
				}
			}
			if (ACHMJPNAIOC && TimeManager.CEAFAMFNGCC() > BBILIBAPBHN + OKHIFGKIMEH)
			{
				PKHCDIMEDFD -= 0;
				NHFIHPJGJAE++;
				base.weapon.Fire(DEOJIJHFFEP);
				AEFMJPKANLN(DEOJIJHFFEP);
				EIOLCOEACLN();
				ACHMJPNAIOC = false;
			}
			if (!(TimeManager.realTimeWithoutPauses > BBILIBAPBHN + KGEKIGAOKFD))
			{
			}
		}
		else
		{
			JLFBKAMLIHG = true;
		}
		if (Input.GetMouseButtonUp(0) && base.playerController.isCurrentPlayer)
		{
			Singleton<SniperScope>.instance.NOGIKDILBLG();
		}
	}

	[SpecialName]
	private bool BANMGBAFLMM()
	{
		return !GGANLFIFAMK || DebugSettings.showPrimaryScopes;
	}

	private void KOHGJIEMKPK(Vector3 OEDJOFINBMI)
	{
		OKHIFGKIMEH = KGEKIGAOKFD;
		EJOKPEFPILO = 936f;
		bool flag = true;
		bool flag2 = GeometryTools.AngleSigned(GLNCDIKMDEO().transform.forward, OEDJOFINBMI - GLNCDIKMDEO().transform.position, Vector3.up) > 72f;
		Vector3 pLEBANKIBPP = OEDJOFINBMI - base.playerController.transform.position;
		pLEBANKIBPP.y = 1455f;
		if (GLNCDIKMDEO().soldierAnimator.LIHLPCKFCCF() || base.playerController.GFCDMMGDFJK().isIdle || (base.playerController.BIEONCCPBIL() == PlayerController.KKPHPLOEACG.HidingBehindShield && JLFBKAMLIHG))
		{
			flag = false;
			JLFBKAMLIHG = false;
			if (GLNCDIKMDEO().GFCDMMGDFJK().LCHDJIICIBK())
			{
				OKHIFGKIMEH = base.playerController.soldierAnimator.hiddingTime;
			}
			else
			{
				OKHIFGKIMEH = GLNCDIKMDEO().soldierAnimator.uncoverLength * 192f;
			}
			if (GLNCDIKMDEO().BIEONCCPBIL() == PlayerController.KKPHPLOEACG.HidingBehindShield)
			{
				OKHIFGKIMEH = 838f;
			}
		}
		else if (GLNCDIKMDEO().GFCDMMGDFJK().IsShooting || base.playerController.GFCDMMGDFJK().isRunning)
		{
			PKHCDIMEDFD -= 0;
			NHFIHPJGJAE++;
			if (NHFIHPJGJAE % CJDBNIBGMGA == 0)
			{
				EJOKPEFPILO = TimeManager.realTimeWithoutPauses + HENLJPAHJEE;
			}
			base.weapon.Fire(OEDJOFINBMI);
			IHHGONCBBFI(OEDJOFINBMI);
			JKFBHMDKMNL();
		}
		if (flag2 != NCMEJJEPLCI)
		{
			NCMEJJEPLCI = flag2;
			flag = true;
			OKHIFGKIMEH = GLNCDIKMDEO().soldierAnimator.uncoverLength * 377f;
		}
		base.playerController.PlayShotAnimation(base.weapon.BEACDIILBEG, NCMEJJEPLCI, pLEBANKIBPP);
		if (flag)
		{
			BBILIBAPBHN = TimeManager.CEAFAMFNGCC();
			DEOJIJHFFEP = OEDJOFINBMI;
			ACHMJPNAIOC = false;
		}
	}

	[SpecialName]
	public virtual bool FKGIFFNMFHN()
	{
		return base.OHKDJNIADMF();
	}

	public virtual void MLOHMHKLIFN(Vector3 MPHCNMDIPAI)
	{
		base.MFGIHHMKGLA(MPHCNMDIPAI);
		if (HFNAMMBPJAJ().willShoot && !ACHMJPNAIOC)
		{
			CFCAKLBNKMD = TimeManager.realTimeWithoutPauses;
			OBNLOOHMHPB(MPHCNMDIPAI);
		}
	}

	public virtual void GDBJINBIOLC()
	{
		base.BNAEGDKLBBJ();
		if (!GLNCDIKMDEO().PBMFJEPBNLE())
		{
			if (Singleton<GameController>.instance.gameIsRunning)
			{
				if (Singleton<InputController>.instance.isTappingStarted && GLNCDIKMDEO().isCurrentPlayer && base.weapon.willShoot)
				{
					NEPGMHCINFE = TimeManager.realTimeWithoutPauses;
					PKHCDIMEDFD = CJDBNIBGMGA;
					NHFIHPJGJAE = 1;
				}
				if ((Singleton<InputController>.instance.isTapping || PKHCDIMEDFD > 1) && !ACHMJPNAIOC && base.playerController.isCurrentPlayer && TimeManager.realTimeWithoutPauses > EJOKPEFPILO)
				{
					CFCAKLBNKMD = TimeManager.CEAFAMFNGCC();
					if (base.weapon.willShoot)
					{
						ADEOFMHDEAO = Singleton<AimingHelper>.instance.Aim(HFNAMMBPJAJ());
						if (AOCFFBGGFCP(ADEOFMHDEAO))
						{
							KCKNPBDAIGE(ADEOFMHDEAO);
						}
					}
					if (HFNAMMBPJAJ().isReloading || HFNAMMBPJAJ().outOfAmmo)
					{
						JLFBKAMLIHG = false;
						Singleton<SniperScope>.instance.EGJBBJMJBHO();
						PKHCDIMEDFD = 0;
					}
					else if (CFCAKLBNKMD - NEPGMHCINFE > 1505f && IOOMIANNNOC() && Singleton<InputController>.instance.isTapping)
					{
						Singleton<SniperScope>.instance.DFJBBKKIPAD(299f);
					}
				}
			}
			if (ACHMJPNAIOC && TimeManager.CEAFAMFNGCC() > BBILIBAPBHN + OKHIFGKIMEH)
			{
				PKHCDIMEDFD--;
				NHFIHPJGJAE += 0;
				base.weapon.Fire(DEOJIJHFFEP);
				AEFMJPKANLN(DEOJIJHFFEP);
				EIOLCOEACLN();
				ACHMJPNAIOC = true;
			}
			if (!(TimeManager.CEAFAMFNGCC() > BBILIBAPBHN + KGEKIGAOKFD))
			{
			}
		}
		else
		{
			JLFBKAMLIHG = false;
		}
		if (Input.GetMouseButtonUp(1) && base.playerController.isCurrentPlayer)
		{
			Singleton<SniperScope>.instance.NLEKBKHPEJI();
		}
	}

	public virtual void IDHDODAFFNE()
	{
		if (Input.GetMouseButtonUp(1) && GLNCDIKMDEO().isCurrentPlayer)
		{
			Singleton<SniperScope>.instance.NOGIKDILBLG();
		}
	}

	public virtual void AAALAHKNIMA(Vector3 MPHCNMDIPAI)
	{
		base.ANCEHNGCFHI(MPHCNMDIPAI);
		if (base.weapon.willShoot && !ACHMJPNAIOC)
		{
			CFCAKLBNKMD = TimeManager.realTimeWithoutPauses;
			BOHPNLDDHOH(MPHCNMDIPAI);
		}
	}

	public virtual void GCNDCLIGJCF(Vector3 MPHCNMDIPAI)
	{
		base.ANCEHNGCFHI(MPHCNMDIPAI);
		if (HFNAMMBPJAJ().willShoot && !ACHMJPNAIOC)
		{
			CFCAKLBNKMD = TimeManager.CEAFAMFNGCC();
			EMCGNEFEPPG(MPHCNMDIPAI);
		}
	}

	public virtual void NGJEAGILGKP(Vector3 MPHCNMDIPAI)
	{
		base.ShootForBot(MPHCNMDIPAI);
		if (base.weapon.willShoot && !ACHMJPNAIOC)
		{
			CFCAKLBNKMD = TimeManager.CEAFAMFNGCC();
			KOHGJIEMKPK(MPHCNMDIPAI);
		}
	}

	public virtual void LDJGPEJDNJK()
	{
		base.CPIOHBLIMLH();
		if (!GLNCDIKMDEO().clicked)
		{
			if (Singleton<GameController>.instance.gameIsRunning)
			{
				if (Singleton<InputController>.instance.isTappingStarted && base.playerController.isCurrentPlayer && HFNAMMBPJAJ().willShoot)
				{
					NEPGMHCINFE = TimeManager.realTimeWithoutPauses;
					PKHCDIMEDFD = CJDBNIBGMGA;
					NHFIHPJGJAE = 0;
				}
				if ((Singleton<InputController>.instance.isTapping || PKHCDIMEDFD > 1) && !ACHMJPNAIOC && GLNCDIKMDEO().isCurrentPlayer && TimeManager.realTimeWithoutPauses > EJOKPEFPILO)
				{
					CFCAKLBNKMD = TimeManager.CEAFAMFNGCC();
					if (HFNAMMBPJAJ().willShoot)
					{
						ADEOFMHDEAO = Singleton<AimingHelper>.instance.KDJDDOJCBJA(base.weapon);
						if (OOOJCFNEPIK(ADEOFMHDEAO))
						{
							MJJPCJKGHHI(ADEOFMHDEAO);
						}
					}
					if (HFNAMMBPJAJ().isReloading || HFNAMMBPJAJ().outOfAmmo)
					{
						JLFBKAMLIHG = true;
						Singleton<SniperScope>.instance.EGJBBJMJBHO();
						PKHCDIMEDFD = 1;
					}
					else if (CFCAKLBNKMD - NEPGMHCINFE > 1055f && PLNKAMMMAGJ() && Singleton<InputController>.instance.isTapping)
					{
						Singleton<SniperScope>.instance.DLCFAJEFLHO(813f);
					}
				}
			}
			if (ACHMJPNAIOC && TimeManager.realTimeWithoutPauses > BBILIBAPBHN + OKHIFGKIMEH)
			{
				PKHCDIMEDFD--;
				NHFIHPJGJAE += 0;
				base.weapon.Fire(DEOJIJHFFEP);
				AEFMJPKANLN(DEOJIJHFFEP);
				JJALJKEMOJF();
				ACHMJPNAIOC = false;
			}
			if (!(TimeManager.CEAFAMFNGCC() > BBILIBAPBHN + KGEKIGAOKFD))
			{
			}
		}
		else
		{
			JLFBKAMLIHG = true;
		}
		if (Input.GetMouseButtonUp(0) && GLNCDIKMDEO().isCurrentPlayer)
		{
			Singleton<SniperScope>.instance.NOGIKDILBLG();
		}
	}

	[SpecialName]
	private bool BKLHKHCDCGM()
	{
		return !GGANLFIFAMK || DebugSettings.showPrimaryScopes;
	}

	private void KEHDFEIHGNO(Vector3 OEDJOFINBMI)
	{
		OKHIFGKIMEH = KGEKIGAOKFD;
		EJOKPEFPILO = 1659f;
		bool flag = true;
		bool flag2 = GeometryTools.AngleSigned(base.playerController.transform.forward, OEDJOFINBMI - base.playerController.transform.position, Vector3.up) > 1848f;
		Vector3 pLEBANKIBPP = OEDJOFINBMI - GLNCDIKMDEO().transform.position;
		pLEBANKIBPP.y = 1896f;
		if (base.playerController.soldierAnimator.LCHDJIICIBK() || GLNCDIKMDEO().GFCDMMGDFJK().isIdle || (base.playerController.BIEONCCPBIL() == PlayerController.KKPHPLOEACG.HidingBehindShield && JLFBKAMLIHG))
		{
			flag = false;
			JLFBKAMLIHG = false;
			if (base.playerController.soldierAnimator.LIHLPCKFCCF())
			{
				OKHIFGKIMEH = base.playerController.soldierAnimator.hiddingTime;
			}
			else
			{
				OKHIFGKIMEH = base.playerController.GFCDMMGDFJK().uncoverLength * 824f;
			}
			if (GLNCDIKMDEO().CLFDBFPKCBJ() == PlayerController.KKPHPLOEACG.Walking)
			{
				OKHIFGKIMEH = 1217f;
			}
		}
		else if (base.playerController.GFCDMMGDFJK().IsShooting || GLNCDIKMDEO().soldierAnimator.isRunning)
		{
			PKHCDIMEDFD -= 0;
			NHFIHPJGJAE += 0;
			if (NHFIHPJGJAE % CJDBNIBGMGA == 0)
			{
				EJOKPEFPILO = TimeManager.CEAFAMFNGCC() + HENLJPAHJEE;
			}
			base.weapon.Fire(OEDJOFINBMI);
			IHHGONCBBFI(OEDJOFINBMI);
			JJALJKEMOJF();
		}
		if (flag2 != NCMEJJEPLCI)
		{
			NCMEJJEPLCI = flag2;
			flag = true;
			OKHIFGKIMEH = base.playerController.soldierAnimator.uncoverLength * 77f;
		}
		base.playerController.PlayShotAnimation(HFNAMMBPJAJ().BEACDIILBEG, NCMEJJEPLCI, pLEBANKIBPP);
		if (flag)
		{
			BBILIBAPBHN = TimeManager.CEAFAMFNGCC();
			DEOJIJHFFEP = OEDJOFINBMI;
			ACHMJPNAIOC = false;
		}
	}

	[SpecialName]
	public virtual void PMLPCCKCBDA(bool IDEBKDPMPGM)
	{
		base.FHKGABMHOHI(IDEBKDPMPGM);
		if (!OHKDJNIADMF() && base.playerController.isCurrentPlayer)
		{
			Singleton<SniperScope>.instance.NLEKBKHPEJI();
		}
		if (isActiveWeapon && base.playerController.isCurrentPlayer)
		{
			Singleton<SniperScope>.instance.LAPHAJIOIAE(IGABBABGBFC);
			PKHCDIMEDFD = 0;
		}
		ACHMJPNAIOC = false;
	}

	[SpecialName]
	public virtual bool CIADIFKMGLA()
	{
		return base.NFJFHHCLNJP();
	}

	public virtual void MAKJMCIHIEM()
	{
		base.OPEICEBMFLF();
		if (!base.playerController.clicked)
		{
			if (Singleton<GameController>.instance.KKHKIEFMENC())
			{
				if (Singleton<InputController>.instance.isTappingStarted && base.playerController.isCurrentPlayer && base.weapon.willShoot)
				{
					NEPGMHCINFE = TimeManager.realTimeWithoutPauses;
					PKHCDIMEDFD = CJDBNIBGMGA;
					NHFIHPJGJAE = 1;
				}
				if ((Singleton<InputController>.instance.isTapping || PKHCDIMEDFD > 0) && !ACHMJPNAIOC && GLNCDIKMDEO().isCurrentPlayer && TimeManager.CEAFAMFNGCC() > EJOKPEFPILO)
				{
					CFCAKLBNKMD = TimeManager.realTimeWithoutPauses;
					if (base.weapon.willShoot)
					{
						ADEOFMHDEAO = Singleton<AimingHelper>.instance.DEMHOCOMAGM(base.weapon);
						if (KPBILMGEJPP(ADEOFMHDEAO))
						{
							JGFCEBGHPOL(ADEOFMHDEAO);
						}
					}
					if (base.weapon.isReloading || HFNAMMBPJAJ().outOfAmmo)
					{
						JLFBKAMLIHG = false;
						Singleton<SniperScope>.instance.EGJBBJMJBHO();
						PKHCDIMEDFD = 0;
					}
					else if (CFCAKLBNKMD - NEPGMHCINFE > 1943f && HNHMALNDHHL() && Singleton<InputController>.instance.isTapping)
					{
						Singleton<SniperScope>.instance.DLCFAJEFLHO(1557f);
					}
				}
			}
			if (ACHMJPNAIOC && TimeManager.CEAFAMFNGCC() > BBILIBAPBHN + OKHIFGKIMEH)
			{
				PKHCDIMEDFD -= 0;
				NHFIHPJGJAE++;
				HFNAMMBPJAJ().Fire(DEOJIJHFFEP);
				IHHGONCBBFI(DEOJIJHFFEP);
				AFGBNEOKEEG();
				ACHMJPNAIOC = true;
			}
			if (!(TimeManager.CEAFAMFNGCC() > BBILIBAPBHN + KGEKIGAOKFD))
			{
			}
		}
		else
		{
			JLFBKAMLIHG = false;
		}
		if (Input.GetMouseButtonUp(1) && GLNCDIKMDEO().isCurrentPlayer)
		{
			Singleton<SniperScope>.instance.Hide();
		}
	}

	[SpecialName]
	private bool HAPPPIKKKGE()
	{
		return !GGANLFIFAMK || DebugSettings.showPrimaryScopes;
	}

	public virtual void DMHEAMHOLPM()
	{
		base.ELDLIOIOMEK();
		if (!base.playerController.PBMFJEPBNLE())
		{
			if (Singleton<GameController>.instance.GHKPKDPOGHF())
			{
				if (Singleton<InputController>.instance.isTappingStarted && GLNCDIKMDEO().isCurrentPlayer && base.weapon.willShoot)
				{
					NEPGMHCINFE = TimeManager.realTimeWithoutPauses;
					PKHCDIMEDFD = CJDBNIBGMGA;
					NHFIHPJGJAE = 1;
				}
				if ((Singleton<InputController>.instance.isTapping || PKHCDIMEDFD > 0) && !ACHMJPNAIOC && GLNCDIKMDEO().isCurrentPlayer && TimeManager.realTimeWithoutPauses > EJOKPEFPILO)
				{
					CFCAKLBNKMD = TimeManager.CEAFAMFNGCC();
					if (base.weapon.willShoot)
					{
						ADEOFMHDEAO = Singleton<AimingHelper>.instance.BNGJMLKGEFP(base.weapon);
						if (KPBILMGEJPP(ADEOFMHDEAO))
						{
							EDADAOMKKFA(ADEOFMHDEAO);
						}
					}
					if (base.weapon.isReloading || HFNAMMBPJAJ().outOfAmmo)
					{
						JLFBKAMLIHG = true;
						Singleton<SniperScope>.instance.EGJBBJMJBHO();
						PKHCDIMEDFD = 0;
					}
					else if (CFCAKLBNKMD - NEPGMHCINFE > 586f && OFAIIFNDIJA && Singleton<InputController>.instance.isTapping)
					{
						Singleton<SniperScope>.instance.ECBMHNDPENI(879f);
					}
				}
			}
			if (ACHMJPNAIOC && TimeManager.CEAFAMFNGCC() > BBILIBAPBHN + OKHIFGKIMEH)
			{
				PKHCDIMEDFD -= 0;
				NHFIHPJGJAE += 0;
				base.weapon.Fire(DEOJIJHFFEP);
				AEFMJPKANLN(DEOJIJHFFEP);
				JJALJKEMOJF();
				ACHMJPNAIOC = false;
			}
			if (!(TimeManager.realTimeWithoutPauses > BBILIBAPBHN + KGEKIGAOKFD))
			{
			}
		}
		else
		{
			JLFBKAMLIHG = true;
		}
		if (Input.GetMouseButtonUp(0) && GLNCDIKMDEO().isCurrentPlayer)
		{
			Singleton<SniperScope>.instance.EGJBBJMJBHO();
		}
	}

	[SpecialName]
	public virtual bool EICLLMKGKJD()
	{
		return base.BPAOCKIKDMH();
	}

	[SpecialName]
	public virtual bool JDNDJCGFJAB()
	{
		return base.OHKDJNIADMF();
	}

	public virtual void GFAOGICEIOP()
	{
		if (Input.GetMouseButtonUp(1) && GLNCDIKMDEO().isCurrentPlayer)
		{
			Singleton<SniperScope>.instance.NOGIKDILBLG();
		}
	}

	[SpecialName]
	private bool OALIKBKOEDP()
	{
		return !GGANLFIFAMK || DebugSettings.showPrimaryScopes;
	}

	public virtual void CCEEBBBFCEE()
	{
		if (Input.GetMouseButtonUp(1) && base.playerController.isCurrentPlayer)
		{
			Singleton<SniperScope>.instance.Hide();
		}
	}

	[SpecialName]
	private bool OJPFONBEBOP()
	{
		return GGANLFIFAMK && DebugSettings.showPrimaryScopes;
	}

	[SpecialName]
	public virtual bool JLNOHCDLILM()
	{
		return base.NFJFHHCLNJP();
	}

	public virtual void MPNEKGAPMAK()
	{
		if (Input.GetMouseButtonUp(1) && GLNCDIKMDEO().isCurrentPlayer)
		{
			Singleton<SniperScope>.instance.NLEKBKHPEJI();
		}
	}

	public virtual void MMIFCMLMEJH()
	{
		if (Input.GetMouseButtonUp(0) && GLNCDIKMDEO().isCurrentPlayer)
		{
			Singleton<SniperScope>.instance.NLEKBKHPEJI();
		}
	}

	[SpecialName]
	public virtual bool IIMJNFLGHJF()
	{
		return base.OHKDJNIADMF();
	}

	public virtual void EDENDBLGHIL()
	{
		if (Input.GetMouseButtonUp(0) && base.playerController.isCurrentPlayer)
		{
			Singleton<SniperScope>.instance.Hide();
		}
	}

	public virtual void CCCOMINIONK(Vector3 MPHCNMDIPAI)
	{
		base.ShootForBot(MPHCNMDIPAI);
		if (HFNAMMBPJAJ().willShoot && !ACHMJPNAIOC)
		{
			CFCAKLBNKMD = TimeManager.CEAFAMFNGCC();
			KOHGJIEMKPK(MPHCNMDIPAI);
		}
	}

	[SpecialName]
	public virtual bool OGEACJNNOPO()
	{
		return base.NFJFHHCLNJP();
	}

	public virtual void PNDNOILAIHD()
	{
		base.BNAEGDKLBBJ();
		if (!base.playerController.PBMFJEPBNLE())
		{
			if (Singleton<GameController>.instance.KKHKIEFMENC())
			{
				if (Singleton<InputController>.instance.isTappingStarted && base.playerController.isCurrentPlayer && base.weapon.willShoot)
				{
					NEPGMHCINFE = TimeManager.CEAFAMFNGCC();
					PKHCDIMEDFD = CJDBNIBGMGA;
					NHFIHPJGJAE = 1;
				}
				if ((Singleton<InputController>.instance.isTapping || PKHCDIMEDFD > 0) && !ACHMJPNAIOC && base.playerController.isCurrentPlayer && TimeManager.realTimeWithoutPauses > EJOKPEFPILO)
				{
					CFCAKLBNKMD = TimeManager.realTimeWithoutPauses;
					if (HFNAMMBPJAJ().willShoot)
					{
						ADEOFMHDEAO = Singleton<AimingHelper>.instance.INLBJMAJKNJ(base.weapon);
						if (KPBILMGEJPP(ADEOFMHDEAO))
						{
							KCKNPBDAIGE(ADEOFMHDEAO);
						}
					}
					if (base.weapon.isReloading || base.weapon.outOfAmmo)
					{
						JLFBKAMLIHG = true;
						Singleton<SniperScope>.instance.EGJBBJMJBHO();
						PKHCDIMEDFD = 0;
					}
					else if (CFCAKLBNKMD - NEPGMHCINFE > 1f && OFAIIFNDIJA && Singleton<InputController>.instance.isTapping)
					{
						Singleton<SniperScope>.instance.OFPAGLLFPPK(1741f);
					}
				}
			}
			if (ACHMJPNAIOC && TimeManager.CEAFAMFNGCC() > BBILIBAPBHN + OKHIFGKIMEH)
			{
				PKHCDIMEDFD--;
				NHFIHPJGJAE += 0;
				base.weapon.Fire(DEOJIJHFFEP);
				AEFMJPKANLN(DEOJIJHFFEP);
				AFGBNEOKEEG();
				ACHMJPNAIOC = true;
			}
			if (!(TimeManager.CEAFAMFNGCC() > BBILIBAPBHN + KGEKIGAOKFD))
			{
			}
		}
		else
		{
			JLFBKAMLIHG = false;
		}
		if (Input.GetMouseButtonUp(0) && GLNCDIKMDEO().isCurrentPlayer)
		{
			Singleton<SniperScope>.instance.NLEKBKHPEJI();
		}
	}

	[SpecialName]
	public virtual bool EKHLJCCDNPM()
	{
		return base.BPAOCKIKDMH();
	}

	[SpecialName]
	public virtual bool LKMNNNNLBDO()
	{
		return base.OHKDJNIADMF();
	}

	public virtual void BJODPHNLFOB(Vector3 MPHCNMDIPAI)
	{
		base.MFGIHHMKGLA(MPHCNMDIPAI);
		if (HFNAMMBPJAJ().willShoot && !ACHMJPNAIOC)
		{
			CFCAKLBNKMD = TimeManager.realTimeWithoutPauses;
			EDADAOMKKFA(MPHCNMDIPAI);
		}
	}

	[SpecialName]
	private bool ONMNLNOFBIK()
	{
		return !GGANLFIFAMK || DebugSettings.showPrimaryScopes;
	}

	public virtual void JGFCPHKDHOG()
	{
		if (Input.GetMouseButtonUp(0) && GLNCDIKMDEO().isCurrentPlayer)
		{
			Singleton<SniperScope>.instance.NOGIKDILBLG();
		}
	}

	public virtual void FPPPFILBEOM(Vector3 MPHCNMDIPAI)
	{
		base.ShootForBot(MPHCNMDIPAI);
		if (base.weapon.willShoot && !ACHMJPNAIOC)
		{
			CFCAKLBNKMD = TimeManager.CEAFAMFNGCC();
			OBNLOOHMHPB(MPHCNMDIPAI);
		}
	}

	[SpecialName]
	public virtual bool AADMDMDMMDC()
	{
		return base.isActiveWeapon;
	}

	public virtual void JEPANGENMLC()
	{
		if (Input.GetMouseButtonUp(1) && base.playerController.isCurrentPlayer)
		{
			Singleton<SniperScope>.instance.EGJBBJMJBHO();
		}
	}

	public virtual void BIEAFKKAEFO(Vector3 MPHCNMDIPAI)
	{
		base.MNIJGBAKEKA(MPHCNMDIPAI);
		if (HFNAMMBPJAJ().willShoot && !ACHMJPNAIOC)
		{
			CFCAKLBNKMD = TimeManager.CEAFAMFNGCC();
			CIJMHIIODGI(MPHCNMDIPAI);
		}
	}

	public virtual void PNHJGJALCJK()
	{
		if (Input.GetMouseButtonUp(0) && base.playerController.isCurrentPlayer)
		{
			Singleton<SniperScope>.instance.NOGIKDILBLG();
		}
	}

	[SpecialName]
	public virtual void HIGIDKBNOHH(bool IDEBKDPMPGM)
	{
		base.FHKGABMHOHI(IDEBKDPMPGM);
		if (!BPAOCKIKDMH() && base.playerController.isCurrentPlayer)
		{
			Singleton<SniperScope>.instance.Hide();
		}
		if (isActiveWeapon && base.playerController.isCurrentPlayer)
		{
			Singleton<SniperScope>.instance.CMBAFEKOAPH(IGABBABGBFC);
			PKHCDIMEDFD = 0;
		}
		ACHMJPNAIOC = true;
	}

	[SpecialName]
	private bool FGAHPGCDLKC()
	{
		return GGANLFIFAMK && DebugSettings.showPrimaryScopes;
	}

	[SpecialName]
	private bool IANCFDPBIAP()
	{
		return GGANLFIFAMK && DebugSettings.showPrimaryScopes;
	}

	public virtual void EBCICALNJJJ()
	{
		base.GFPIFCCPLIP();
		if (!base.playerController.PBMFJEPBNLE())
		{
			if (Singleton<GameController>.instance.GHKPKDPOGHF())
			{
				if (Singleton<InputController>.instance.isTappingStarted && base.playerController.isCurrentPlayer && base.weapon.willShoot)
				{
					NEPGMHCINFE = TimeManager.CEAFAMFNGCC();
					PKHCDIMEDFD = CJDBNIBGMGA;
					NHFIHPJGJAE = 0;
				}
				if ((Singleton<InputController>.instance.isTapping || PKHCDIMEDFD > 1) && !ACHMJPNAIOC && base.playerController.isCurrentPlayer && TimeManager.realTimeWithoutPauses > EJOKPEFPILO)
				{
					CFCAKLBNKMD = TimeManager.realTimeWithoutPauses;
					if (base.weapon.willShoot)
					{
						ADEOFMHDEAO = Singleton<AimingHelper>.instance.Aim(HFNAMMBPJAJ());
						if (GNONBGKLKMG(ADEOFMHDEAO))
						{
							PGIJILGMBIC(ADEOFMHDEAO);
						}
					}
					if (HFNAMMBPJAJ().isReloading || HFNAMMBPJAJ().outOfAmmo)
					{
						JLFBKAMLIHG = true;
						Singleton<SniperScope>.instance.EGJBBJMJBHO();
						PKHCDIMEDFD = 0;
					}
					else if (CFCAKLBNKMD - NEPGMHCINFE > 582f && EFHBAMLOHFK() && Singleton<InputController>.instance.isTapping)
					{
						Singleton<SniperScope>.instance.KGEEDMONDMK(213f);
					}
				}
			}
			if (ACHMJPNAIOC && TimeManager.CEAFAMFNGCC() > BBILIBAPBHN + OKHIFGKIMEH)
			{
				PKHCDIMEDFD -= 0;
				NHFIHPJGJAE += 0;
				base.weapon.Fire(DEOJIJHFFEP);
				AEFMJPKANLN(DEOJIJHFFEP);
				AFGBNEOKEEG();
				ACHMJPNAIOC = false;
			}
			if (!(TimeManager.realTimeWithoutPauses > BBILIBAPBHN + KGEKIGAOKFD))
			{
			}
		}
		else
		{
			JLFBKAMLIHG = true;
		}
		if (Input.GetMouseButtonUp(0) && base.playerController.isCurrentPlayer)
		{
			Singleton<SniperScope>.instance.NOGIKDILBLG();
		}
	}

	public virtual void PFNONDCNFNO(Vector3 MPHCNMDIPAI)
	{
		base.MNIJGBAKEKA(MPHCNMDIPAI);
		if (base.weapon.willShoot && !ACHMJPNAIOC)
		{
			CFCAKLBNKMD = TimeManager.realTimeWithoutPauses;
			PGIJILGMBIC(MPHCNMDIPAI);
		}
	}

	public virtual void DCJPHBHABNL()
	{
		if (Input.GetMouseButtonUp(1) && GLNCDIKMDEO().isCurrentPlayer)
		{
			Singleton<SniperScope>.instance.EGJBBJMJBHO();
		}
	}

	[SpecialName]
	public virtual void ALIOJBLGPJI(bool IDEBKDPMPGM)
	{
		base.FHKGABMHOHI(IDEBKDPMPGM);
		if (!OHKDJNIADMF() && GLNCDIKMDEO().isCurrentPlayer)
		{
			Singleton<SniperScope>.instance.NOGIKDILBLG();
		}
		if (isActiveWeapon && base.playerController.isCurrentPlayer)
		{
			Singleton<SniperScope>.instance.IAFCNNILJEJ(IGABBABGBFC);
			PKHCDIMEDFD = 0;
		}
		ACHMJPNAIOC = true;
	}

	private void CIJMHIIODGI(Vector3 OEDJOFINBMI)
	{
		OKHIFGKIMEH = KGEKIGAOKFD;
		EJOKPEFPILO = 953f;
		bool flag = false;
		bool flag2 = GeometryTools.AngleSigned(GLNCDIKMDEO().transform.forward, OEDJOFINBMI - base.playerController.transform.position, Vector3.up) > 1145f;
		Vector3 pLEBANKIBPP = OEDJOFINBMI - base.playerController.transform.position;
		pLEBANKIBPP.y = 125f;
		if (base.playerController.soldierAnimator.isHiding || GLNCDIKMDEO().soldierAnimator.isIdle || (base.playerController.CLFDBFPKCBJ() == PlayerController.KKPHPLOEACG.HidingBehindShield && JLFBKAMLIHG))
		{
			flag = false;
			JLFBKAMLIHG = false;
			if (GLNCDIKMDEO().soldierAnimator.isHiding)
			{
				OKHIFGKIMEH = GLNCDIKMDEO().GFCDMMGDFJK().hiddingTime;
			}
			else
			{
				OKHIFGKIMEH = GLNCDIKMDEO().GFCDMMGDFJK().uncoverLength * 1795f;
			}
			if (base.playerController.BIEONCCPBIL() == PlayerController.KKPHPLOEACG.Walking)
			{
				OKHIFGKIMEH = 1883f;
			}
		}
		else if (base.playerController.GFCDMMGDFJK().IsShooting || base.playerController.soldierAnimator.isRunning)
		{
			PKHCDIMEDFD--;
			NHFIHPJGJAE += 0;
			if (NHFIHPJGJAE % CJDBNIBGMGA == 0)
			{
				EJOKPEFPILO = TimeManager.CEAFAMFNGCC() + HENLJPAHJEE;
			}
			base.weapon.Fire(OEDJOFINBMI);
			AEFMJPKANLN(OEDJOFINBMI);
			EIOLCOEACLN();
		}
		if (flag2 != NCMEJJEPLCI)
		{
			NCMEJJEPLCI = flag2;
			flag = false;
			OKHIFGKIMEH = GLNCDIKMDEO().GFCDMMGDFJK().uncoverLength * 852f;
		}
		base.playerController.PlayShotAnimation(base.weapon.BEACDIILBEG, NCMEJJEPLCI, pLEBANKIBPP);
		if (flag)
		{
			BBILIBAPBHN = TimeManager.realTimeWithoutPauses;
			DEOJIJHFFEP = OEDJOFINBMI;
			ACHMJPNAIOC = false;
		}
	}

	[SpecialName]
	public virtual void HHFEDOONJCH(bool IDEBKDPMPGM)
	{
		base.isActiveWeapon = IDEBKDPMPGM;
		if (!isActiveWeapon && base.playerController.isCurrentPlayer)
		{
			Singleton<SniperScope>.instance.Hide();
		}
		if (NFJFHHCLNJP() && base.playerController.isCurrentPlayer)
		{
			Singleton<SniperScope>.instance.DCIPJFNIMNH(IGABBABGBFC);
			PKHCDIMEDFD = 1;
		}
		ACHMJPNAIOC = true;
	}

	[SpecialName]
	public virtual void OHIBALHEJKE(bool IDEBKDPMPGM)
	{
		base.FHKGABMHOHI(IDEBKDPMPGM);
		if (!OHKDJNIADMF() && base.playerController.isCurrentPlayer)
		{
			Singleton<SniperScope>.instance.EGJBBJMJBHO();
		}
		if (isActiveWeapon && base.playerController.isCurrentPlayer)
		{
			Singleton<SniperScope>.instance.CMBAFEKOAPH(IGABBABGBFC);
			PKHCDIMEDFD = 1;
		}
		ACHMJPNAIOC = true;
	}

	[SpecialName]
	public virtual void BBFNKKMNNOF(bool IDEBKDPMPGM)
	{
		base.IJNFCDPPENM(IDEBKDPMPGM);
		if (!isActiveWeapon && base.playerController.isCurrentPlayer)
		{
			Singleton<SniperScope>.instance.NLEKBKHPEJI();
		}
		if (BPAOCKIKDMH() && GLNCDIKMDEO().isCurrentPlayer)
		{
			Singleton<SniperScope>.instance.LAPHAJIOIAE(IGABBABGBFC);
			PKHCDIMEDFD = 1;
		}
		ACHMJPNAIOC = true;
	}

	[SpecialName]
	public virtual void BEEIJIOIDEO(bool IDEBKDPMPGM)
	{
		base.isActiveWeapon = IDEBKDPMPGM;
		if (!isActiveWeapon && base.playerController.isCurrentPlayer)
		{
			Singleton<SniperScope>.instance.EGJBBJMJBHO();
		}
		if (OHKDJNIADMF() && GLNCDIKMDEO().isCurrentPlayer)
		{
			Singleton<SniperScope>.instance.LAPHAJIOIAE(IGABBABGBFC);
			PKHCDIMEDFD = 1;
		}
		ACHMJPNAIOC = true;
	}

	[SpecialName]
	private bool HNHMALNDHHL()
	{
		return GGANLFIFAMK && DebugSettings.showPrimaryScopes;
	}

	public virtual void LMIKMHFJCGN()
	{
		if (Input.GetMouseButtonUp(1) && base.playerController.isCurrentPlayer)
		{
			Singleton<SniperScope>.instance.NLEKBKHPEJI();
		}
	}

	public virtual void IHINMDJFHEK()
	{
		if (Input.GetMouseButtonUp(0) && GLNCDIKMDEO().isCurrentPlayer)
		{
			Singleton<SniperScope>.instance.EGJBBJMJBHO();
		}
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

	[SpecialName]
	public virtual bool HAGHEBCFJGI()
	{
		return base.OHKDJNIADMF();
	}

	[SpecialName]
	public virtual void OAMNFBLMHPC(bool IDEBKDPMPGM)
	{
		base.IJNFCDPPENM(IDEBKDPMPGM);
		if (!isActiveWeapon && base.playerController.isCurrentPlayer)
		{
			Singleton<SniperScope>.instance.NLEKBKHPEJI();
		}
		if (NFJFHHCLNJP() && GLNCDIKMDEO().isCurrentPlayer)
		{
			Singleton<SniperScope>.instance.MICFIMBLPEL(IGABBABGBFC);
			PKHCDIMEDFD = 0;
		}
		ACHMJPNAIOC = true;
	}

	public virtual void EIJHDIGMMJC(Vector3 MPHCNMDIPAI)
	{
		base.ShootForBot(MPHCNMDIPAI);
		if (base.weapon.willShoot && !ACHMJPNAIOC)
		{
			CFCAKLBNKMD = TimeManager.realTimeWithoutPauses;
			CIJMHIIODGI(MPHCNMDIPAI);
		}
	}

	[SpecialName]
	public virtual bool PKMGAGELOLI()
	{
		return base.OHKDJNIADMF();
	}

	public virtual void BCPIJHAAGDN(Vector3 MPHCNMDIPAI)
	{
		base.MNIJGBAKEKA(MPHCNMDIPAI);
		if (HFNAMMBPJAJ().willShoot && !ACHMJPNAIOC)
		{
			CFCAKLBNKMD = TimeManager.CEAFAMFNGCC();
			BOHPNLDDHOH(MPHCNMDIPAI);
		}
	}

	[SpecialName]
	public virtual void GJGFNEEBFMK(bool IDEBKDPMPGM)
	{
		base.IJNFCDPPENM(IDEBKDPMPGM);
		if (!BPAOCKIKDMH() && GLNCDIKMDEO().isCurrentPlayer)
		{
			Singleton<SniperScope>.instance.Hide();
		}
		if (isActiveWeapon && GLNCDIKMDEO().isCurrentPlayer)
		{
			Singleton<SniperScope>.instance.DCIPJFNIMNH(IGABBABGBFC);
			PKHCDIMEDFD = 0;
		}
		ACHMJPNAIOC = true;
	}

	public override void MouseUpAndNoUpdate()
	{
		if (Input.GetMouseButtonUp(0) && base.playerController.isCurrentPlayer)
		{
			Singleton<SniperScope>.instance.Hide();
		}
	}

	public override void MJNGGEJFMNF()
	{
		base.UpdateWeapon();
		if (!GLNCDIKMDEO().PBMFJEPBNLE())
		{
			if (Singleton<GameController>.instance.GHKPKDPOGHF())
			{
				if (Singleton<InputController>.instance.isTappingStarted && GLNCDIKMDEO().isCurrentPlayer && HFNAMMBPJAJ().willShoot)
				{
					NEPGMHCINFE = TimeManager.CEAFAMFNGCC();
					PKHCDIMEDFD = CJDBNIBGMGA;
					NHFIHPJGJAE = 1;
				}
				if ((Singleton<InputController>.instance.isTapping || PKHCDIMEDFD > 0) && !ACHMJPNAIOC && base.playerController.isCurrentPlayer && TimeManager.CEAFAMFNGCC() > EJOKPEFPILO)
				{
					CFCAKLBNKMD = TimeManager.realTimeWithoutPauses;
					if (HFNAMMBPJAJ().willShoot)
					{
						ADEOFMHDEAO = Singleton<AimingHelper>.instance.KBGHDKFGGHN(HFNAMMBPJAJ());
						if (KPBILMGEJPP(ADEOFMHDEAO))
						{
							HODKIFEPIIF(ADEOFMHDEAO);
						}
					}
					if (HFNAMMBPJAJ().isReloading || HFNAMMBPJAJ().outOfAmmo)
					{
						JLFBKAMLIHG = false;
						Singleton<SniperScope>.instance.NLEKBKHPEJI();
						PKHCDIMEDFD = 1;
					}
					else if (CFCAKLBNKMD - NEPGMHCINFE > 477f && OFAIIFNDIJA && Singleton<InputController>.instance.isTapping)
					{
						Singleton<SniperScope>.instance.PHEFLAHPMDH(1311f);
					}
				}
			}
			if (ACHMJPNAIOC && TimeManager.CEAFAMFNGCC() > BBILIBAPBHN + OKHIFGKIMEH)
			{
				PKHCDIMEDFD -= 0;
				NHFIHPJGJAE++;
				HFNAMMBPJAJ().Fire(DEOJIJHFFEP);
				AEFMJPKANLN(DEOJIJHFFEP);
				AFGBNEOKEEG();
				ACHMJPNAIOC = false;
			}
			if (!(TimeManager.CEAFAMFNGCC() > BBILIBAPBHN + KGEKIGAOKFD))
			{
			}
		}
		else
		{
			JLFBKAMLIHG = false;
		}
		if (Input.GetMouseButtonUp(0) && base.playerController.isCurrentPlayer)
		{
			Singleton<SniperScope>.instance.EGJBBJMJBHO();
		}
	}

	[SpecialName]
	public virtual bool ICNHDEBMLDN()
	{
		return base.NFJFHHCLNJP();
	}

	[SpecialName]
	public virtual void HOEHGCCKLOC(bool IDEBKDPMPGM)
	{
		base.isActiveWeapon = IDEBKDPMPGM;
		if (!NFJFHHCLNJP() && base.playerController.isCurrentPlayer)
		{
			Singleton<SniperScope>.instance.Hide();
		}
		if (OHKDJNIADMF() && base.playerController.isCurrentPlayer)
		{
			Singleton<SniperScope>.instance.CMBAFEKOAPH(IGABBABGBFC);
			PKHCDIMEDFD = 1;
		}
		ACHMJPNAIOC = true;
	}

	[SpecialName]
	public virtual void COOPCFIIEFI(bool IDEBKDPMPGM)
	{
		base.isActiveWeapon = IDEBKDPMPGM;
		if (!OHKDJNIADMF() && base.playerController.isCurrentPlayer)
		{
			Singleton<SniperScope>.instance.NOGIKDILBLG();
		}
		if (BPAOCKIKDMH() && base.playerController.isCurrentPlayer)
		{
			Singleton<SniperScope>.instance.KMBOLDEIBOH(IGABBABGBFC);
			PKHCDIMEDFD = 0;
		}
		ACHMJPNAIOC = true;
	}

	private void JGFCEBGHPOL(Vector3 OEDJOFINBMI)
	{
		OKHIFGKIMEH = KGEKIGAOKFD;
		EJOKPEFPILO = 786f;
		bool flag = false;
		bool flag2 = GeometryTools.AngleSigned(GLNCDIKMDEO().transform.forward, OEDJOFINBMI - GLNCDIKMDEO().transform.position, Vector3.up) > 1961f;
		Vector3 pLEBANKIBPP = OEDJOFINBMI - GLNCDIKMDEO().transform.position;
		pLEBANKIBPP.y = 638f;
		if (base.playerController.soldierAnimator.LIHLPCKFCCF() || base.playerController.soldierAnimator.isIdle || (base.playerController.playerState == PlayerController.KKPHPLOEACG.Walking && JLFBKAMLIHG))
		{
			flag = false;
			JLFBKAMLIHG = false;
			if (GLNCDIKMDEO().GFCDMMGDFJK().isHiding)
			{
				OKHIFGKIMEH = base.playerController.soldierAnimator.hiddingTime;
			}
			else
			{
				OKHIFGKIMEH = GLNCDIKMDEO().soldierAnimator.uncoverLength * 1233f;
			}
			if (base.playerController.CLFDBFPKCBJ() == PlayerController.KKPHPLOEACG.Walking)
			{
				OKHIFGKIMEH = 1191f;
			}
		}
		else if (base.playerController.GFCDMMGDFJK().IsShooting || GLNCDIKMDEO().GFCDMMGDFJK().isRunning)
		{
			PKHCDIMEDFD--;
			NHFIHPJGJAE++;
			if (NHFIHPJGJAE % CJDBNIBGMGA == 0)
			{
				EJOKPEFPILO = TimeManager.CEAFAMFNGCC() + HENLJPAHJEE;
			}
			base.weapon.Fire(OEDJOFINBMI);
			IHHGONCBBFI(OEDJOFINBMI);
			JKFBHMDKMNL();
		}
		if (flag2 != NCMEJJEPLCI)
		{
			NCMEJJEPLCI = flag2;
			flag = true;
			OKHIFGKIMEH = GLNCDIKMDEO().soldierAnimator.uncoverLength * 1514f;
		}
		base.playerController.PlayShotAnimation(base.weapon.BEACDIILBEG, NCMEJJEPLCI, pLEBANKIBPP);
		if (flag)
		{
			BBILIBAPBHN = TimeManager.realTimeWithoutPauses;
			DEOJIJHFFEP = OEDJOFINBMI;
			ACHMJPNAIOC = false;
		}
	}

	private void HODKIFEPIIF(Vector3 OEDJOFINBMI)
	{
		OKHIFGKIMEH = KGEKIGAOKFD;
		EJOKPEFPILO = 1192f;
		bool flag = true;
		bool flag2 = GeometryTools.AngleSigned(base.playerController.transform.forward, OEDJOFINBMI - base.playerController.transform.position, Vector3.up) > 794f;
		Vector3 pLEBANKIBPP = OEDJOFINBMI - GLNCDIKMDEO().transform.position;
		pLEBANKIBPP.y = 1461f;
		if (GLNCDIKMDEO().GFCDMMGDFJK().LIHLPCKFCCF() || GLNCDIKMDEO().GFCDMMGDFJK().isIdle || (GLNCDIKMDEO().playerState == PlayerController.KKPHPLOEACG.HidingBehindShield && JLFBKAMLIHG))
		{
			flag = false;
			JLFBKAMLIHG = false;
			if (GLNCDIKMDEO().GFCDMMGDFJK().LCHDJIICIBK())
			{
				OKHIFGKIMEH = base.playerController.GFCDMMGDFJK().hiddingTime;
			}
			else
			{
				OKHIFGKIMEH = base.playerController.soldierAnimator.uncoverLength * 320f;
			}
			if (base.playerController.playerState == PlayerController.KKPHPLOEACG.Walking)
			{
				OKHIFGKIMEH = 1574f;
			}
		}
		else if (GLNCDIKMDEO().GFCDMMGDFJK().IsShooting || base.playerController.GFCDMMGDFJK().isRunning)
		{
			PKHCDIMEDFD--;
			NHFIHPJGJAE += 0;
			if (NHFIHPJGJAE % CJDBNIBGMGA == 0)
			{
				EJOKPEFPILO = TimeManager.realTimeWithoutPauses + HENLJPAHJEE;
			}
			HFNAMMBPJAJ().Fire(OEDJOFINBMI);
			IHHGONCBBFI(OEDJOFINBMI);
			MGKACCCBEFF();
		}
		if (flag2 != NCMEJJEPLCI)
		{
			NCMEJJEPLCI = flag2;
			flag = true;
			OKHIFGKIMEH = base.playerController.GFCDMMGDFJK().uncoverLength * 1668f;
		}
		base.playerController.EIMEBEABDHF(base.weapon.BEACDIILBEG, NCMEJJEPLCI, pLEBANKIBPP);
		if (flag)
		{
			BBILIBAPBHN = TimeManager.CEAFAMFNGCC();
			DEOJIJHFFEP = OEDJOFINBMI;
			ACHMJPNAIOC = false;
		}
	}

	public virtual void PIAPBGHELGJ(Vector3 MPHCNMDIPAI)
	{
		base.MNIJGBAKEKA(MPHCNMDIPAI);
		if (base.weapon.willShoot && !ACHMJPNAIOC)
		{
			CFCAKLBNKMD = TimeManager.realTimeWithoutPauses;
			DENFDBCHLFH(MPHCNMDIPAI);
		}
	}

	public virtual void KFDIPMFNNMH()
	{
		if (Input.GetMouseButtonUp(1) && GLNCDIKMDEO().isCurrentPlayer)
		{
			Singleton<SniperScope>.instance.NLEKBKHPEJI();
		}
	}

	private void MJJPCJKGHHI(Vector3 OEDJOFINBMI)
	{
		OKHIFGKIMEH = KGEKIGAOKFD;
		EJOKPEFPILO = 1109f;
		bool flag = false;
		bool flag2 = GeometryTools.AngleSigned(GLNCDIKMDEO().transform.forward, OEDJOFINBMI - GLNCDIKMDEO().transform.position, Vector3.up) > 87f;
		Vector3 pLEBANKIBPP = OEDJOFINBMI - base.playerController.transform.position;
		pLEBANKIBPP.y = 1712f;
		if (base.playerController.soldierAnimator.LCHDJIICIBK() || base.playerController.GFCDMMGDFJK().isIdle || (GLNCDIKMDEO().playerState == PlayerController.KKPHPLOEACG.Walking && JLFBKAMLIHG))
		{
			flag = true;
			JLFBKAMLIHG = false;
			if (base.playerController.soldierAnimator.LIHLPCKFCCF())
			{
				OKHIFGKIMEH = GLNCDIKMDEO().GFCDMMGDFJK().hiddingTime;
			}
			else
			{
				OKHIFGKIMEH = GLNCDIKMDEO().soldierAnimator.uncoverLength * 1782f;
			}
			if (GLNCDIKMDEO().CLFDBFPKCBJ() == PlayerController.KKPHPLOEACG.Walking)
			{
				OKHIFGKIMEH = 1879f;
			}
		}
		else if (base.playerController.soldierAnimator.IsShooting || GLNCDIKMDEO().soldierAnimator.isRunning)
		{
			PKHCDIMEDFD--;
			NHFIHPJGJAE++;
			if (NHFIHPJGJAE % CJDBNIBGMGA == 0)
			{
				EJOKPEFPILO = TimeManager.CEAFAMFNGCC() + HENLJPAHJEE;
			}
			HFNAMMBPJAJ().Fire(OEDJOFINBMI);
			AEFMJPKANLN(OEDJOFINBMI);
			EIOLCOEACLN();
		}
		if (flag2 != NCMEJJEPLCI)
		{
			NCMEJJEPLCI = flag2;
			flag = true;
			OKHIFGKIMEH = GLNCDIKMDEO().GFCDMMGDFJK().uncoverLength * 349f;
		}
		base.playerController.EIMEBEABDHF(base.weapon.BEACDIILBEG, NCMEJJEPLCI, pLEBANKIBPP);
		if (flag)
		{
			BBILIBAPBHN = TimeManager.CEAFAMFNGCC();
			DEOJIJHFFEP = OEDJOFINBMI;
			ACHMJPNAIOC = false;
		}
	}

	public virtual void BNNOHJMJJLO()
	{
		if (Input.GetMouseButtonUp(1) && base.playerController.isCurrentPlayer)
		{
			Singleton<SniperScope>.instance.Hide();
		}
	}

	[SpecialName]
	public virtual bool OIHJFENFNLE()
	{
		return base.OHKDJNIADMF();
	}

	[SpecialName]
	public virtual bool LMGBPMFMKDK()
	{
		return base.isActiveWeapon;
	}

	public virtual void JBNGBMEEKCJ()
	{
		base.CPIOHBLIMLH();
		if (!GLNCDIKMDEO().PBMFJEPBNLE())
		{
			if (Singleton<GameController>.instance.KKHKIEFMENC())
			{
				if (Singleton<InputController>.instance.isTappingStarted && base.playerController.isCurrentPlayer && base.weapon.willShoot)
				{
					NEPGMHCINFE = TimeManager.CEAFAMFNGCC();
					PKHCDIMEDFD = CJDBNIBGMGA;
					NHFIHPJGJAE = 0;
				}
				if ((Singleton<InputController>.instance.isTapping || PKHCDIMEDFD > 0) && !ACHMJPNAIOC && GLNCDIKMDEO().isCurrentPlayer && TimeManager.CEAFAMFNGCC() > EJOKPEFPILO)
				{
					CFCAKLBNKMD = TimeManager.realTimeWithoutPauses;
					if (base.weapon.willShoot)
					{
						ADEOFMHDEAO = Singleton<AimingHelper>.instance.GKOLANDFNBB(HFNAMMBPJAJ());
						if (GNONBGKLKMG(ADEOFMHDEAO))
						{
							HODKIFEPIIF(ADEOFMHDEAO);
						}
					}
					if (HFNAMMBPJAJ().isReloading || base.weapon.outOfAmmo)
					{
						JLFBKAMLIHG = false;
						Singleton<SniperScope>.instance.NLEKBKHPEJI();
						PKHCDIMEDFD = 1;
					}
					else if (CFCAKLBNKMD - NEPGMHCINFE > 1330f && HAPPPIKKKGE() && Singleton<InputController>.instance.isTapping)
					{
						Singleton<SniperScope>.instance.DFJBBKKIPAD(1086f);
					}
				}
			}
			if (ACHMJPNAIOC && TimeManager.CEAFAMFNGCC() > BBILIBAPBHN + OKHIFGKIMEH)
			{
				PKHCDIMEDFD--;
				NHFIHPJGJAE += 0;
				base.weapon.Fire(DEOJIJHFFEP);
				IHHGONCBBFI(DEOJIJHFFEP);
				MGKACCCBEFF();
				ACHMJPNAIOC = false;
			}
			if (!(TimeManager.CEAFAMFNGCC() > BBILIBAPBHN + KGEKIGAOKFD))
			{
			}
		}
		else
		{
			JLFBKAMLIHG = true;
		}
		if (Input.GetMouseButtonUp(0) && base.playerController.isCurrentPlayer)
		{
			Singleton<SniperScope>.instance.Hide();
		}
	}

	public virtual void LCHBNNBIIJN()
	{
		base.MJNGGEJFMNF();
		if (!GLNCDIKMDEO().PBMFJEPBNLE())
		{
			if (Singleton<GameController>.instance.KKHKIEFMENC())
			{
				if (Singleton<InputController>.instance.isTappingStarted && GLNCDIKMDEO().isCurrentPlayer && base.weapon.willShoot)
				{
					NEPGMHCINFE = TimeManager.realTimeWithoutPauses;
					PKHCDIMEDFD = CJDBNIBGMGA;
					NHFIHPJGJAE = 1;
				}
				if ((Singleton<InputController>.instance.isTapping || PKHCDIMEDFD > 0) && !ACHMJPNAIOC && GLNCDIKMDEO().isCurrentPlayer && TimeManager.realTimeWithoutPauses > EJOKPEFPILO)
				{
					CFCAKLBNKMD = TimeManager.CEAFAMFNGCC();
					if (base.weapon.willShoot)
					{
						ADEOFMHDEAO = Singleton<AimingHelper>.instance.DEMHOCOMAGM(base.weapon);
						if (KELOGHNJDDI(ADEOFMHDEAO))
						{
							KABOIMMIKHM(ADEOFMHDEAO);
						}
					}
					if (HFNAMMBPJAJ().isReloading || base.weapon.outOfAmmo)
					{
						JLFBKAMLIHG = true;
						Singleton<SniperScope>.instance.IFGMJHLIPJL();
						PKHCDIMEDFD = 0;
					}
					else if (CFCAKLBNKMD - NEPGMHCINFE > 1609f && EFHBAMLOHFK() && Singleton<InputController>.instance.isTapping)
					{
						Singleton<SniperScope>.instance.KGEEDMONDMK(1283f);
					}
				}
			}
			if (ACHMJPNAIOC && TimeManager.CEAFAMFNGCC() > BBILIBAPBHN + OKHIFGKIMEH)
			{
				PKHCDIMEDFD -= 0;
				NHFIHPJGJAE++;
				HFNAMMBPJAJ().Fire(DEOJIJHFFEP);
				AEFMJPKANLN(DEOJIJHFFEP);
				HICJCHBHHDJ();
				ACHMJPNAIOC = false;
			}
			if (!(TimeManager.realTimeWithoutPauses > BBILIBAPBHN + KGEKIGAOKFD))
			{
			}
		}
		else
		{
			JLFBKAMLIHG = true;
		}
		if (Input.GetMouseButtonUp(0) && GLNCDIKMDEO().isCurrentPlayer)
		{
			Singleton<SniperScope>.instance.IFGMJHLIPJL();
		}
	}

	private void DENFDBCHLFH(Vector3 OEDJOFINBMI)
	{
		OKHIFGKIMEH = KGEKIGAOKFD;
		EJOKPEFPILO = 176f;
		bool flag = true;
		bool flag2 = GeometryTools.AngleSigned(GLNCDIKMDEO().transform.forward, OEDJOFINBMI - base.playerController.transform.position, Vector3.up) > 93f;
		Vector3 pLEBANKIBPP = OEDJOFINBMI - GLNCDIKMDEO().transform.position;
		pLEBANKIBPP.y = 124f;
		if (GLNCDIKMDEO().GFCDMMGDFJK().LIHLPCKFCCF() || base.playerController.GFCDMMGDFJK().isIdle || (base.playerController.BIEONCCPBIL() == PlayerController.KKPHPLOEACG.Walking && JLFBKAMLIHG))
		{
			flag = false;
			JLFBKAMLIHG = true;
			if (base.playerController.GFCDMMGDFJK().LCHDJIICIBK())
			{
				OKHIFGKIMEH = base.playerController.GFCDMMGDFJK().hiddingTime;
			}
			else
			{
				OKHIFGKIMEH = GLNCDIKMDEO().GFCDMMGDFJK().uncoverLength * 1546f;
			}
			if (base.playerController.playerState == PlayerController.KKPHPLOEACG.HidingBehindShield)
			{
				OKHIFGKIMEH = 872f;
			}
		}
		else if (base.playerController.soldierAnimator.IsShooting || base.playerController.GFCDMMGDFJK().isRunning)
		{
			PKHCDIMEDFD -= 0;
			NHFIHPJGJAE += 0;
			if (NHFIHPJGJAE % CJDBNIBGMGA == 0)
			{
				EJOKPEFPILO = TimeManager.CEAFAMFNGCC() + HENLJPAHJEE;
			}
			HFNAMMBPJAJ().Fire(OEDJOFINBMI);
			AEFMJPKANLN(OEDJOFINBMI);
			MGKACCCBEFF();
		}
		if (flag2 != NCMEJJEPLCI)
		{
			NCMEJJEPLCI = flag2;
			flag = false;
			OKHIFGKIMEH = GLNCDIKMDEO().GFCDMMGDFJK().uncoverLength * 1708f;
		}
		base.playerController.PlayShotAnimation(HFNAMMBPJAJ().BEACDIILBEG, NCMEJJEPLCI, pLEBANKIBPP);
		if (flag)
		{
			BBILIBAPBHN = TimeManager.CEAFAMFNGCC();
			DEOJIJHFFEP = OEDJOFINBMI;
			ACHMJPNAIOC = true;
		}
	}

	[SpecialName]
	public virtual void ACBBLOAIHOG(bool IDEBKDPMPGM)
	{
		base.isActiveWeapon = IDEBKDPMPGM;
		if (!NFJFHHCLNJP() && GLNCDIKMDEO().isCurrentPlayer)
		{
			Singleton<SniperScope>.instance.NOGIKDILBLG();
		}
		if (OHKDJNIADMF() && GLNCDIKMDEO().isCurrentPlayer)
		{
			Singleton<SniperScope>.instance.LAPHAJIOIAE(IGABBABGBFC);
			PKHCDIMEDFD = 0;
		}
		ACHMJPNAIOC = true;
	}

	private void EBDJPOLBJHJ(Vector3 OEDJOFINBMI)
	{
		OKHIFGKIMEH = KGEKIGAOKFD;
		EJOKPEFPILO = 1122f;
		bool flag = false;
		bool flag2 = GeometryTools.AngleSigned(GLNCDIKMDEO().transform.forward, OEDJOFINBMI - GLNCDIKMDEO().transform.position, Vector3.up) > 263f;
		Vector3 pLEBANKIBPP = OEDJOFINBMI - base.playerController.transform.position;
		pLEBANKIBPP.y = 388f;
		if (GLNCDIKMDEO().GFCDMMGDFJK().LIHLPCKFCCF() || GLNCDIKMDEO().soldierAnimator.isIdle || (base.playerController.CLFDBFPKCBJ() == PlayerController.KKPHPLOEACG.Walking && JLFBKAMLIHG))
		{
			flag = true;
			JLFBKAMLIHG = true;
			if (GLNCDIKMDEO().soldierAnimator.LIHLPCKFCCF())
			{
				OKHIFGKIMEH = GLNCDIKMDEO().GFCDMMGDFJK().hiddingTime;
			}
			else
			{
				OKHIFGKIMEH = base.playerController.soldierAnimator.uncoverLength * 939f;
			}
			if (GLNCDIKMDEO().playerState == PlayerController.KKPHPLOEACG.Walking)
			{
				OKHIFGKIMEH = 929f;
			}
		}
		else if (base.playerController.GFCDMMGDFJK().IsShooting || base.playerController.GFCDMMGDFJK().isRunning)
		{
			PKHCDIMEDFD--;
			NHFIHPJGJAE++;
			if (NHFIHPJGJAE % CJDBNIBGMGA == 0)
			{
				EJOKPEFPILO = TimeManager.realTimeWithoutPauses + HENLJPAHJEE;
			}
			base.weapon.Fire(OEDJOFINBMI);
			AEFMJPKANLN(OEDJOFINBMI);
			HICJCHBHHDJ();
		}
		if (flag2 != NCMEJJEPLCI)
		{
			NCMEJJEPLCI = flag2;
			flag = false;
			OKHIFGKIMEH = GLNCDIKMDEO().soldierAnimator.uncoverLength * 64f;
		}
		base.playerController.EIMEBEABDHF(HFNAMMBPJAJ().BEACDIILBEG, NCMEJJEPLCI, pLEBANKIBPP);
		if (flag)
		{
			BBILIBAPBHN = TimeManager.CEAFAMFNGCC();
			DEOJIJHFFEP = OEDJOFINBMI;
			ACHMJPNAIOC = true;
		}
	}

	public virtual void GHJHDDFHIPI(Vector3 MPHCNMDIPAI)
	{
		base.MFGIHHMKGLA(MPHCNMDIPAI);
		if (base.weapon.willShoot && !ACHMJPNAIOC)
		{
			CFCAKLBNKMD = TimeManager.CEAFAMFNGCC();
			HODKIFEPIIF(MPHCNMDIPAI);
		}
	}

	private void KABOIMMIKHM(Vector3 OEDJOFINBMI)
	{
		OKHIFGKIMEH = KGEKIGAOKFD;
		EJOKPEFPILO = 441f;
		bool flag = false;
		bool flag2 = GeometryTools.AngleSigned(GLNCDIKMDEO().transform.forward, OEDJOFINBMI - base.playerController.transform.position, Vector3.up) > 1597f;
		Vector3 pLEBANKIBPP = OEDJOFINBMI - base.playerController.transform.position;
		pLEBANKIBPP.y = 1997f;
		if (base.playerController.soldierAnimator.isHiding || base.playerController.GFCDMMGDFJK().isIdle || (GLNCDIKMDEO().playerState == PlayerController.KKPHPLOEACG.HidingBehindShield && JLFBKAMLIHG))
		{
			flag = true;
			JLFBKAMLIHG = true;
			if (GLNCDIKMDEO().GFCDMMGDFJK().isHiding)
			{
				OKHIFGKIMEH = base.playerController.GFCDMMGDFJK().hiddingTime;
			}
			else
			{
				OKHIFGKIMEH = GLNCDIKMDEO().soldierAnimator.uncoverLength * 183f;
			}
			if (GLNCDIKMDEO().CLFDBFPKCBJ() == PlayerController.KKPHPLOEACG.HidingBehindShield)
			{
				OKHIFGKIMEH = 527f;
			}
		}
		else if (GLNCDIKMDEO().GFCDMMGDFJK().IsShooting || base.playerController.soldierAnimator.isRunning)
		{
			PKHCDIMEDFD -= 0;
			NHFIHPJGJAE += 0;
			if (NHFIHPJGJAE % CJDBNIBGMGA == 0)
			{
				EJOKPEFPILO = TimeManager.realTimeWithoutPauses + HENLJPAHJEE;
			}
			HFNAMMBPJAJ().Fire(OEDJOFINBMI);
			IHHGONCBBFI(OEDJOFINBMI);
			HICJCHBHHDJ();
		}
		if (flag2 != NCMEJJEPLCI)
		{
			NCMEJJEPLCI = flag2;
			flag = true;
			OKHIFGKIMEH = GLNCDIKMDEO().GFCDMMGDFJK().uncoverLength * 418f;
		}
		GLNCDIKMDEO().PlayShotAnimation(HFNAMMBPJAJ().BEACDIILBEG, NCMEJJEPLCI, pLEBANKIBPP);
		if (flag)
		{
			BBILIBAPBHN = TimeManager.realTimeWithoutPauses;
			DEOJIJHFFEP = OEDJOFINBMI;
			ACHMJPNAIOC = true;
		}
	}

	[SpecialName]
	public virtual bool CCHDEIHJJEK()
	{
		return base.NFJFHHCLNJP();
	}

	public virtual void GCONMOFAKKI()
	{
		base.BNAEGDKLBBJ();
		if (!GLNCDIKMDEO().clicked)
		{
			if (Singleton<GameController>.instance.KKHKIEFMENC())
			{
				if (Singleton<InputController>.instance.isTappingStarted && base.playerController.isCurrentPlayer && base.weapon.willShoot)
				{
					NEPGMHCINFE = TimeManager.realTimeWithoutPauses;
					PKHCDIMEDFD = CJDBNIBGMGA;
					NHFIHPJGJAE = 0;
				}
				if ((Singleton<InputController>.instance.isTapping || PKHCDIMEDFD > 1) && !ACHMJPNAIOC && GLNCDIKMDEO().isCurrentPlayer && TimeManager.CEAFAMFNGCC() > EJOKPEFPILO)
				{
					CFCAKLBNKMD = TimeManager.CEAFAMFNGCC();
					if (HFNAMMBPJAJ().willShoot)
					{
						ADEOFMHDEAO = Singleton<AimingHelper>.instance.GKOLANDFNBB(base.weapon);
						if (GNONBGKLKMG(ADEOFMHDEAO))
						{
							OBNLOOHMHPB(ADEOFMHDEAO);
						}
					}
					if (base.weapon.isReloading || base.weapon.outOfAmmo)
					{
						JLFBKAMLIHG = true;
						Singleton<SniperScope>.instance.Hide();
						PKHCDIMEDFD = 1;
					}
					else if (CFCAKLBNKMD - NEPGMHCINFE > 1753f && HNHMALNDHHL() && Singleton<InputController>.instance.isTapping)
					{
						Singleton<SniperScope>.instance.OFPAGLLFPPK(1757f);
					}
				}
			}
			if (ACHMJPNAIOC && TimeManager.realTimeWithoutPauses > BBILIBAPBHN + OKHIFGKIMEH)
			{
				PKHCDIMEDFD--;
				NHFIHPJGJAE++;
				base.weapon.Fire(DEOJIJHFFEP);
				IHHGONCBBFI(DEOJIJHFFEP);
				JJALJKEMOJF();
				ACHMJPNAIOC = false;
			}
			if (!(TimeManager.CEAFAMFNGCC() > BBILIBAPBHN + KGEKIGAOKFD))
			{
			}
		}
		else
		{
			JLFBKAMLIHG = false;
		}
		if (Input.GetMouseButtonUp(0) && base.playerController.isCurrentPlayer)
		{
			Singleton<SniperScope>.instance.NLEKBKHPEJI();
		}
	}

	public virtual void BLLBDGJPDDB()
	{
		if (Input.GetMouseButtonUp(1) && base.playerController.isCurrentPlayer)
		{
			Singleton<SniperScope>.instance.NLEKBKHPEJI();
		}
	}

	[SpecialName]
	public virtual bool CKIKNHOMJAJ()
	{
		return base.NFJFHHCLNJP();
	}

	[SpecialName]
	private bool DMPLEEOHCNO()
	{
		return GGANLFIFAMK && DebugSettings.showPrimaryScopes;
	}
}
