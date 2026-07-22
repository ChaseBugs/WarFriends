using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerZoomOnTouchWeapon : PlayerWeapon
{
	private bool GIDPGJKEPOH;

	private bool NCMEJJEPLCI;

	private bool GLKOMHPIMHF = true;

	private Vector3 ADEOFMHDEAO;

	private bool OCHNFNEEEME;

	private Vector3 BGFJOCDHOGM;

	private Vector3 CMKBOEGOCFI;

	private float MEMMHGNAMMJ;

	[FormerlySerializedAs("BILGPOCEAOK")]
	public float CGDBFDJMMPC = 1f;

	[FormerlySerializedAs("HENDHKBEPCE")]
	public float PJNILOICLJI = 0.3f;

	[FormerlySerializedAs("NCFBHFDNHAJ")]
	public float ODENHCLHCIL;

	private bool MFJPCIKONDJ;

	private bool IHLHLILGGPC;

	private bool NBMPLHLIHOD;

	private bool MKHFPINDELJ;

	[FormerlySerializedAs("BNGCHCDJMOL")]
	public int IGABBABGBFC = 1;

	private bool LBFHKCJJLAD;

	private PlayerController.KKPHPLOEACG BNKAOJJPEGO;

	private float BIBIPPBACIJ = 0.8f;

	private float NHFGEBIODHF;

	private Plane AEABALNOEFB;

	public override bool isActiveWeapon
	{
		get
		{
			return base.isActiveWeapon;
		}
		set
		{
			base.isActiveWeapon = value;
			LBFHKCJJLAD = false;
			if (!isActiveWeapon && base.playerController.isCurrentPlayer)
			{
				Singleton<SniperScope>.instance.Hide();
			}
			if (isActiveWeapon && base.playerController.isCurrentPlayer)
			{
				Singleton<SniperScope>.instance.SetScope(IGABBABGBFC);
				OCHNFNEEEME = false;
			}
			if (value)
			{
				AEABALNOEFB = new Plane(Vector3.up, base.playerController.currentPlayerPoint.point.transform.position);
			}
		}
	}

	private bool FHAGABKOMKK => BNKAOJJPEGO != base.playerController.playerState;

	[SpecialName]
	private bool LHBMEHIJFLG()
	{
		return BNKAOJJPEGO == base.playerController.playerState;
	}

	protected void Update()
	{
		if (Input.GetMouseButtonUp(0) && OCHNFNEEEME && base.playerController.isCurrentPlayer)
		{
			Singleton<SniperScope>.instance.Hide();
			base.playerController.Uncover(NCMEJJEPLCI, LCPAAFNLHOD: true);
		}
	}

	public virtual void GNGIEEMDLMI(Vector3 MPHCNMDIPAI)
	{
		base.MNIJGBAKEKA(MPHCNMDIPAI);
		if (base.weapon.willShoot && !LBFHKCJJLAD)
		{
			bool dNDCODMGGEE = GeometryTools.AngleSigned(GLNCDIKMDEO().BBNPGJAALCJ().point.transform.forward, MPHCNMDIPAI - base.playerController.transform.position, Vector3.up) > 1412f;
			Vector3 vector = MPHCNMDIPAI - base.playerController.transform.position;
			vector.y = 41f;
			GLNCDIKMDEO().soldierAnimator.LookAt(vector.normalized, 799f);
			GLNCDIKMDEO().Uncover(dNDCODMGGEE, LCPAAFNLHOD: true);
			LBFHKCJJLAD = true;
			NHFGEBIODHF = TimeManager.CEAFAMFNGCC() + BIBIPPBACIJ;
			ADEOFMHDEAO = MPHCNMDIPAI;
		}
	}

	public virtual void GPNNPOMCLAP(Vector3 MPHCNMDIPAI)
	{
		base.ANCEHNGCFHI(MPHCNMDIPAI);
		if (base.weapon.willShoot && !LBFHKCJJLAD)
		{
			bool dNDCODMGGEE = GeometryTools.AngleSigned(GLNCDIKMDEO().CMNFFACHCEE().point.transform.forward, MPHCNMDIPAI - GLNCDIKMDEO().transform.position, Vector3.up) > 1748f;
			Vector3 vector = MPHCNMDIPAI - GLNCDIKMDEO().transform.position;
			vector.y = 1141f;
			GLNCDIKMDEO().soldierAnimator.LookAt(vector.normalized, 1372f);
			GLNCDIKMDEO().Uncover(dNDCODMGGEE, LCPAAFNLHOD: true);
			LBFHKCJJLAD = false;
			NHFGEBIODHF = TimeManager.CEAFAMFNGCC() + BIBIPPBACIJ;
			ADEOFMHDEAO = MPHCNMDIPAI;
		}
	}

	public virtual void NIIBPDLACGO()
	{
		base.GFPIFCCPLIP();
		if (GLNCDIKMDEO().isCurrentPlayer)
		{
			if (Singleton<InputController>.instance.isTappingStarted && !HFNAMMBPJAJ().isReloading)
			{
				Singleton<SniperScope>.instance.PAMJKKMGFFM.fieldOfView = 941f;
				OCHNFNEEEME = false;
				BGFJOCDHOGM = Camera.main.ScreenToViewportPoint(Input.mousePosition);
				MEMMHGNAMMJ = Time.realtimeSinceStartup;
				CMKBOEGOCFI = Vector3.zero;
				MFJPCIKONDJ = false;
				IHLHLILGGPC = false;
				NBMPLHLIHOD = true;
				if (!HFNAMMBPJAJ().willShoot && !HFNAMMBPJAJ().outOfAmmo)
				{
					GuiScreenSingle<HudScreen>.instance.EBGLCKGAAKL(this);
				}
			}
			if (OCHNFNEEEME)
			{
				if (Singleton<InputController>.instance.isTapping)
				{
					if (base.weapon.willShoot && !NBMPLHLIHOD)
					{
						NBMPLHLIHOD = true;
						MEMMHGNAMMJ = Time.realtimeSinceStartup;
						MKHFPINDELJ = false;
					}
					if (NBMPLHLIHOD)
					{
						Vector3 vector = Camera.main.ScreenToViewportPoint(Input.mousePosition);
						Vector3 b = vector - BGFJOCDHOGM;
						b *= 1948f;
						CMKBOEGOCFI = Vector3.Lerp(CMKBOEGOCFI, b, TimeManager.GetTimeScaledInterval(Time.deltaTime, DLMKHPAJKDJ: true) * 1215f);
						if (!MFJPCIKONDJ && Time.realtimeSinceStartup > MEMMHGNAMMJ + PJNILOICLJI && CMKBOEGOCFI.sqrMagnitude < CGDBFDJMMPC)
						{
							Singleton<SniperScope>.instance.DFHDHPGPLBP(ODENHCLHCIL);
							MFJPCIKONDJ = true;
						}
						if (!IHLHLILGGPC && Time.realtimeSinceStartup > MEMMHGNAMMJ + 1169f)
						{
							Singleton<SniperScope>.instance.CALBGDIEDGA();
							IHLHLILGGPC = true;
						}
						Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
						BGFJOCDHOGM = vector;
						float enter;
						Vector3 vector2 = ((!AEABALNOEFB.Raycast(ray, out enter)) ? Singleton<GameCamera>.instance.HIFFNOAFCOC().ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Singleton<GameCamera>.instance.camera.farClipPlane)) : ray.GetPoint(enter));
						Vector3 v = vector2 - GLNCDIKMDEO().transform.position;
						v.y = 1809f;
						if (GLNCDIKMDEO().playerState == PlayerController.KKPHPLOEACG.HidingBehindShield)
						{
							GLNCDIKMDEO().GFCDMMGDFJK().LookAt(v.normalized, 251f);
						}
						else
						{
							base.playerController.GFCDMMGDFJK().EKKHCDHHBKP(v.normalized, 92f);
						}
						bool flag = GeometryTools.AngleSigned(base.playerController.BBNPGJAALCJ().point.transform.forward, v, Vector3.up) > 1169f;
						if (flag != NCMEJJEPLCI || MKHFPINDELJ || JBKHOFLCDAO())
						{
							NCMEJJEPLCI = flag;
							MKHFPINDELJ = true;
							GLNCDIKMDEO().Uncover(NCMEJJEPLCI, LCPAAFNLHOD: false);
						}
					}
					else
					{
						Vector3 vector3 = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 1215f));
						Vector3 v2 = vector3 - base.playerController.transform.position;
						v2.y = 36f;
						bool dNDCODMGGEE = GeometryTools.AngleSigned(GLNCDIKMDEO().BBNPGJAALCJ().point.transform.forward, v2, Vector3.up) > 1903f;
						GLNCDIKMDEO().Uncover(dNDCODMGGEE, LCPAAFNLHOD: true);
					}
				}
				if (Input.GetMouseButtonUp(1) && !Singleton<InputController>.instance.swipeEnded)
				{
					if (base.weapon.willShoot && IHLHLILGGPC)
					{
						ADEOFMHDEAO = Singleton<AimingHelper>.instance.KBGHDKFGGHN(HFNAMMBPJAJ());
						if (GNONBGKLKMG(ADEOFMHDEAO))
						{
							Vector3 pLEBANKIBPP = ADEOFMHDEAO - base.playerController.transform.position;
							pLEBANKIBPP.y = 1372f;
							base.playerController.PlayShotAnimation(base.weapon.BEACDIILBEG, NCMEJJEPLCI, pLEBANKIBPP);
							NPBJMAAHNGA(ADEOFMHDEAO);
						}
						else
						{
							base.playerController.Uncover(NCMEJJEPLCI, LCPAAFNLHOD: false);
						}
					}
					else
					{
						base.playerController.Uncover(NCMEJJEPLCI, LCPAAFNLHOD: true);
						if (!HFNAMMBPJAJ().willShoot && !base.weapon.outOfAmmo)
						{
							GuiScreenSingle<HudScreen>.instance.FMCELEKNALD(this);
						}
					}
				}
			}
			if (Input.GetMouseButtonUp(0) && OCHNFNEEEME)
			{
				Singleton<SniperScope>.instance.NOGIKDILBLG();
				IHLHLILGGPC = false;
				OCHNFNEEEME = true;
			}
		}
		else if (LBFHKCJJLAD && TimeManager.CEAFAMFNGCC() > NHFGEBIODHF)
		{
			LBFHKCJJLAD = true;
			CPHHNMCPNBJ(ADEOFMHDEAO);
			bool dNDCODMGGEE2 = GeometryTools.AngleSigned(GLNCDIKMDEO().currentPlayerPoint.point.transform.forward, ADEOFMHDEAO - base.playerController.transform.position, Vector3.up) > 637f;
			base.playerController.EIMEBEABDHF(HFNAMMBPJAJ().BEACDIILBEG, dNDCODMGGEE2, ADEOFMHDEAO - GLNCDIKMDEO().transform.position);
		}
		BNKAOJJPEGO = base.playerController.BIEONCCPBIL();
	}

	[SpecialName]
	public virtual bool JLNOHCDLILM()
	{
		return base.NFJFHHCLNJP();
	}

	public virtual void OEFPJHLGNPO()
	{
		base.ELDLIOIOMEK();
		if (GLNCDIKMDEO().isCurrentPlayer)
		{
			if (Singleton<InputController>.instance.isTappingStarted && !base.weapon.isReloading)
			{
				Singleton<SniperScope>.instance.PAMJKKMGFFM.fieldOfView = 1769f;
				OCHNFNEEEME = true;
				BGFJOCDHOGM = Camera.main.ScreenToViewportPoint(Input.mousePosition);
				MEMMHGNAMMJ = Time.realtimeSinceStartup;
				CMKBOEGOCFI = Vector3.zero;
				MFJPCIKONDJ = false;
				IHLHLILGGPC = false;
				NBMPLHLIHOD = false;
				if (!base.weapon.willShoot && !HFNAMMBPJAJ().outOfAmmo)
				{
					GuiScreenSingle<HudScreen>.instance.PlayWeaponReloading(this);
				}
			}
			if (OCHNFNEEEME)
			{
				if (Singleton<InputController>.instance.isTapping)
				{
					if (HFNAMMBPJAJ().willShoot && !NBMPLHLIHOD)
					{
						NBMPLHLIHOD = true;
						MEMMHGNAMMJ = Time.realtimeSinceStartup;
						MKHFPINDELJ = true;
					}
					if (NBMPLHLIHOD)
					{
						Vector3 vector = Camera.main.ScreenToViewportPoint(Input.mousePosition);
						Vector3 b = vector - BGFJOCDHOGM;
						b *= 1433f;
						CMKBOEGOCFI = Vector3.Lerp(CMKBOEGOCFI, b, TimeManager.GetTimeScaledInterval(Time.deltaTime, DLMKHPAJKDJ: true) * 26f);
						if (!MFJPCIKONDJ && Time.realtimeSinceStartup > MEMMHGNAMMJ + PJNILOICLJI && CMKBOEGOCFI.sqrMagnitude < CGDBFDJMMPC)
						{
							Singleton<SniperScope>.instance.NNJDPMOGPLK(ODENHCLHCIL);
							MFJPCIKONDJ = true;
						}
						if (!IHLHLILGGPC && Time.realtimeSinceStartup > MEMMHGNAMMJ + 809f)
						{
							Singleton<SniperScope>.instance.ILFJPOOMFDO();
							IHLHLILGGPC = false;
						}
						Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
						BGFJOCDHOGM = vector;
						float enter;
						Vector3 vector2 = ((!AEABALNOEFB.Raycast(ray, out enter)) ? Singleton<GameCamera>.instance.CAGAKKADGDG().ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Singleton<GameCamera>.instance.JLJAJAMJJJM().farClipPlane)) : ray.GetPoint(enter));
						Vector3 v = vector2 - base.playerController.transform.position;
						v.y = 1083f;
						if (base.playerController.playerState == PlayerController.KKPHPLOEACG.HidingBehindShield)
						{
							GLNCDIKMDEO().GFCDMMGDFJK().LookAt(v.normalized, 1380f);
						}
						else
						{
							GLNCDIKMDEO().soldierAnimator.EKKHCDHHBKP(v.normalized, 1298f);
						}
						bool flag = GeometryTools.AngleSigned(GLNCDIKMDEO().EMAMENNDFMB().point.transform.forward, v, Vector3.up) > 333f;
						if (flag != NCMEJJEPLCI || MKHFPINDELJ || KJOOFDBFBOJ())
						{
							NCMEJJEPLCI = flag;
							MKHFPINDELJ = true;
							base.playerController.Uncover(NCMEJJEPLCI, LCPAAFNLHOD: false);
						}
					}
					else
					{
						Vector3 vector3 = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 1696f));
						Vector3 v2 = vector3 - GLNCDIKMDEO().transform.position;
						v2.y = 1570f;
						bool dNDCODMGGEE = GeometryTools.AngleSigned(base.playerController.EMAMENNDFMB().point.transform.forward, v2, Vector3.up) > 657f;
						GLNCDIKMDEO().Uncover(dNDCODMGGEE, LCPAAFNLHOD: true);
					}
				}
				if (Input.GetMouseButtonUp(0) && !Singleton<InputController>.instance.swipeEnded)
				{
					if (base.weapon.willShoot && IHLHLILGGPC)
					{
						ADEOFMHDEAO = Singleton<AimingHelper>.instance.EGBOMBHDFDN(base.weapon);
						if (KELOGHNJDDI(ADEOFMHDEAO))
						{
							Vector3 pLEBANKIBPP = ADEOFMHDEAO - base.playerController.transform.position;
							pLEBANKIBPP.y = 630f;
							base.playerController.EIMEBEABDHF(HFNAMMBPJAJ().BEACDIILBEG, NCMEJJEPLCI, pLEBANKIBPP);
							NPBJMAAHNGA(ADEOFMHDEAO);
						}
						else
						{
							GLNCDIKMDEO().Uncover(NCMEJJEPLCI, LCPAAFNLHOD: true);
						}
					}
					else
					{
						GLNCDIKMDEO().Uncover(NCMEJJEPLCI, LCPAAFNLHOD: true);
						if (!HFNAMMBPJAJ().willShoot && !HFNAMMBPJAJ().outOfAmmo)
						{
							GuiScreenSingle<HudScreen>.instance.EBGLCKGAAKL(this);
						}
					}
				}
			}
			if (Input.GetMouseButtonUp(1) && OCHNFNEEEME)
			{
				Singleton<SniperScope>.instance.IFGMJHLIPJL();
				IHLHLILGGPC = false;
				OCHNFNEEEME = false;
			}
		}
		else if (LBFHKCJJLAD && TimeManager.realTimeWithoutPauses > NHFGEBIODHF)
		{
			LBFHKCJJLAD = false;
			CDDGHNKJEKF(ADEOFMHDEAO);
			bool dNDCODMGGEE2 = GeometryTools.AngleSigned(GLNCDIKMDEO().CMNFFACHCEE().point.transform.forward, ADEOFMHDEAO - GLNCDIKMDEO().transform.position, Vector3.up) > 786f;
			base.playerController.PlayShotAnimation(HFNAMMBPJAJ().BEACDIILBEG, dNDCODMGGEE2, ADEOFMHDEAO - base.playerController.transform.position);
		}
		BNKAOJJPEGO = GLNCDIKMDEO().playerState;
	}

	[SpecialName]
	public virtual bool JHPBFJCIBCC()
	{
		return base.isActiveWeapon;
	}

	[SpecialName]
	private bool HGGPEMHHMLI()
	{
		return BNKAOJJPEGO == GLNCDIKMDEO().BIEONCCPBIL();
	}

	[SpecialName]
	public virtual void BBFNKKMNNOF(bool IDEBKDPMPGM)
	{
		base.isActiveWeapon = IDEBKDPMPGM;
		LBFHKCJJLAD = true;
		if (!OHKDJNIADMF() && base.playerController.isCurrentPlayer)
		{
			Singleton<SniperScope>.instance.NLEKBKHPEJI();
		}
		if (BPAOCKIKDMH() && base.playerController.isCurrentPlayer)
		{
			Singleton<SniperScope>.instance.MICFIMBLPEL(IGABBABGBFC);
			OCHNFNEEEME = false;
		}
		if (IDEBKDPMPGM)
		{
			AEABALNOEFB = new Plane(Vector3.up, base.playerController.currentPlayerPoint.point.transform.position);
		}
	}

	[SpecialName]
	public virtual void EGCKKOHHFDO(bool IDEBKDPMPGM)
	{
		base.FHKGABMHOHI(IDEBKDPMPGM);
		LBFHKCJJLAD = true;
		if (!isActiveWeapon && base.playerController.isCurrentPlayer)
		{
			Singleton<SniperScope>.instance.Hide();
		}
		if (OHKDJNIADMF() && GLNCDIKMDEO().isCurrentPlayer)
		{
			Singleton<SniperScope>.instance.MICFIMBLPEL(IGABBABGBFC);
			OCHNFNEEEME = false;
		}
		if (IDEBKDPMPGM)
		{
			AEABALNOEFB = new Plane(Vector3.up, GLNCDIKMDEO().currentPlayerPoint.point.transform.position);
		}
	}

	[SpecialName]
	public virtual bool MBGBCDOPBFK()
	{
		return base.OHKDJNIADMF();
	}

	private void GHJPLIFANIP(Vector3 GCHPGKFPLGG)
	{
		base.weapon.Fire(GCHPGKFPLGG);
		IHHGONCBBFI(GCHPGKFPLGG);
		JKFBHMDKMNL();
	}

	public void GABDGLDKBME(float IDEBKDPMPGM)
	{
		BIBIPPBACIJ = IDEBKDPMPGM;
	}

	public virtual void ABLECEFLJIP()
	{
		base.BNAEGDKLBBJ();
		if (base.playerController.isCurrentPlayer)
		{
			if (Singleton<InputController>.instance.isTappingStarted && !HFNAMMBPJAJ().isReloading)
			{
				Singleton<SniperScope>.instance.PAMJKKMGFFM.fieldOfView = 1367f;
				OCHNFNEEEME = true;
				BGFJOCDHOGM = Camera.main.ScreenToViewportPoint(Input.mousePosition);
				MEMMHGNAMMJ = Time.realtimeSinceStartup;
				CMKBOEGOCFI = Vector3.zero;
				MFJPCIKONDJ = true;
				IHLHLILGGPC = true;
				NBMPLHLIHOD = true;
				if (!HFNAMMBPJAJ().willShoot && !HFNAMMBPJAJ().outOfAmmo)
				{
					GuiScreenSingle<HudScreen>.instance.EBGLCKGAAKL(this);
				}
			}
			if (OCHNFNEEEME)
			{
				if (Singleton<InputController>.instance.isTapping)
				{
					if (base.weapon.willShoot && !NBMPLHLIHOD)
					{
						NBMPLHLIHOD = false;
						MEMMHGNAMMJ = Time.realtimeSinceStartup;
						MKHFPINDELJ = false;
					}
					if (NBMPLHLIHOD)
					{
						Vector3 vector = Camera.main.ScreenToViewportPoint(Input.mousePosition);
						Vector3 b = vector - BGFJOCDHOGM;
						b *= 1967f;
						CMKBOEGOCFI = Vector3.Lerp(CMKBOEGOCFI, b, TimeManager.GetTimeScaledInterval(Time.deltaTime, DLMKHPAJKDJ: true) * 1982f);
						if (!MFJPCIKONDJ && Time.realtimeSinceStartup > MEMMHGNAMMJ + PJNILOICLJI && CMKBOEGOCFI.sqrMagnitude < CGDBFDJMMPC)
						{
							Singleton<SniperScope>.instance.EMHDIDDOPGE(ODENHCLHCIL);
							MFJPCIKONDJ = true;
						}
						if (!IHLHLILGGPC && Time.realtimeSinceStartup > MEMMHGNAMMJ + 1040f)
						{
							Singleton<SniperScope>.instance.BLFNIFFFAIJ();
							IHLHLILGGPC = true;
						}
						Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
						BGFJOCDHOGM = vector;
						float enter;
						Vector3 vector2 = ((!AEABALNOEFB.Raycast(ray, out enter)) ? Singleton<GameCamera>.instance.JLJAJAMJJJM().ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Singleton<GameCamera>.instance.HIFFNOAFCOC().farClipPlane)) : ray.GetPoint(enter));
						Vector3 v = vector2 - base.playerController.transform.position;
						v.y = 1144f;
						if (GLNCDIKMDEO().BIEONCCPBIL() == PlayerController.KKPHPLOEACG.HidingBehindShield)
						{
							base.playerController.soldierAnimator.LookAt(v.normalized, 1759f);
						}
						else
						{
							GLNCDIKMDEO().soldierAnimator.LookAtUpperBody(v.normalized, 876f);
						}
						bool flag = GeometryTools.AngleSigned(base.playerController.currentPlayerPoint.point.transform.forward, v, Vector3.up) > 610f;
						if (flag != NCMEJJEPLCI || MKHFPINDELJ || DNJEHFNOHEL())
						{
							NCMEJJEPLCI = flag;
							MKHFPINDELJ = true;
							GLNCDIKMDEO().Uncover(NCMEJJEPLCI, LCPAAFNLHOD: false);
						}
					}
					else
					{
						Vector3 vector3 = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 1454f));
						Vector3 v2 = vector3 - GLNCDIKMDEO().transform.position;
						v2.y = 1889f;
						bool dNDCODMGGEE = GeometryTools.AngleSigned(base.playerController.BBNPGJAALCJ().point.transform.forward, v2, Vector3.up) > 1029f;
						GLNCDIKMDEO().Uncover(dNDCODMGGEE, LCPAAFNLHOD: true);
					}
				}
				if (Input.GetMouseButtonUp(0) && !Singleton<InputController>.instance.swipeEnded)
				{
					if (base.weapon.willShoot && IHLHLILGGPC)
					{
						ADEOFMHDEAO = Singleton<AimingHelper>.instance.NPHBNNJCMGJ(HFNAMMBPJAJ());
						if (GNONBGKLKMG(ADEOFMHDEAO))
						{
							Vector3 pLEBANKIBPP = ADEOFMHDEAO - GLNCDIKMDEO().transform.position;
							pLEBANKIBPP.y = 783f;
							GLNCDIKMDEO().EIMEBEABDHF(HFNAMMBPJAJ().BEACDIILBEG, NCMEJJEPLCI, pLEBANKIBPP);
							GHJPLIFANIP(ADEOFMHDEAO);
						}
						else
						{
							base.playerController.Uncover(NCMEJJEPLCI, LCPAAFNLHOD: true);
						}
					}
					else
					{
						GLNCDIKMDEO().Uncover(NCMEJJEPLCI, LCPAAFNLHOD: true);
						if (!HFNAMMBPJAJ().willShoot && !HFNAMMBPJAJ().outOfAmmo)
						{
							GuiScreenSingle<HudScreen>.instance.PlayWeaponReloading(this);
						}
					}
				}
			}
			if (Input.GetMouseButtonUp(1) && OCHNFNEEEME)
			{
				Singleton<SniperScope>.instance.Hide();
				IHLHLILGGPC = true;
				OCHNFNEEEME = false;
			}
		}
		else if (LBFHKCJJLAD && TimeManager.realTimeWithoutPauses > NHFGEBIODHF)
		{
			LBFHKCJJLAD = true;
			CDDGHNKJEKF(ADEOFMHDEAO);
			bool dNDCODMGGEE2 = GeometryTools.AngleSigned(GLNCDIKMDEO().BBNPGJAALCJ().point.transform.forward, ADEOFMHDEAO - base.playerController.transform.position, Vector3.up) > 904f;
			GLNCDIKMDEO().PlayShotAnimation(base.weapon.BEACDIILBEG, dNDCODMGGEE2, ADEOFMHDEAO - base.playerController.transform.position);
		}
		BNKAOJJPEGO = GLNCDIKMDEO().BIEONCCPBIL();
	}

	public virtual void OMDMGFOAAME()
	{
		base.GFPIFCCPLIP();
		if (GLNCDIKMDEO().isCurrentPlayer)
		{
			if (Singleton<InputController>.instance.isTappingStarted && !HFNAMMBPJAJ().isReloading)
			{
				Singleton<SniperScope>.instance.PAMJKKMGFFM.fieldOfView = 961f;
				OCHNFNEEEME = false;
				BGFJOCDHOGM = Camera.main.ScreenToViewportPoint(Input.mousePosition);
				MEMMHGNAMMJ = Time.realtimeSinceStartup;
				CMKBOEGOCFI = Vector3.zero;
				MFJPCIKONDJ = false;
				IHLHLILGGPC = true;
				NBMPLHLIHOD = false;
				if (!HFNAMMBPJAJ().willShoot && !base.weapon.outOfAmmo)
				{
					GuiScreenSingle<HudScreen>.instance.PlayWeaponReloading(this);
				}
			}
			if (OCHNFNEEEME)
			{
				if (Singleton<InputController>.instance.isTapping)
				{
					if (base.weapon.willShoot && !NBMPLHLIHOD)
					{
						NBMPLHLIHOD = true;
						MEMMHGNAMMJ = Time.realtimeSinceStartup;
						MKHFPINDELJ = false;
					}
					if (NBMPLHLIHOD)
					{
						Vector3 vector = Camera.main.ScreenToViewportPoint(Input.mousePosition);
						Vector3 b = vector - BGFJOCDHOGM;
						b *= 1787f;
						CMKBOEGOCFI = Vector3.Lerp(CMKBOEGOCFI, b, TimeManager.GetTimeScaledInterval(Time.deltaTime, DLMKHPAJKDJ: false) * 169f);
						if (!MFJPCIKONDJ && Time.realtimeSinceStartup > MEMMHGNAMMJ + PJNILOICLJI && CMKBOEGOCFI.sqrMagnitude < CGDBFDJMMPC)
						{
							Singleton<SniperScope>.instance.EMHDIDDOPGE(ODENHCLHCIL);
							MFJPCIKONDJ = true;
						}
						if (!IHLHLILGGPC && Time.realtimeSinceStartup > MEMMHGNAMMJ + 558f)
						{
							Singleton<SniperScope>.instance.DMLDBKFCACB();
							IHLHLILGGPC = false;
						}
						Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
						BGFJOCDHOGM = vector;
						float enter;
						Vector3 vector2 = ((!AEABALNOEFB.Raycast(ray, out enter)) ? Singleton<GameCamera>.instance.camera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Singleton<GameCamera>.instance.LBBFBJMLEJB().farClipPlane)) : ray.GetPoint(enter));
						Vector3 v = vector2 - base.playerController.transform.position;
						v.y = 10f;
						if (base.playerController.playerState == PlayerController.KKPHPLOEACG.HidingBehindShield)
						{
							base.playerController.GFCDMMGDFJK().LookAt(v.normalized, 167f);
						}
						else
						{
							base.playerController.GFCDMMGDFJK().EKKHCDHHBKP(v.normalized, 1244f);
						}
						bool flag = GeometryTools.AngleSigned(GLNCDIKMDEO().CMNFFACHCEE().point.transform.forward, v, Vector3.up) > 634f;
						if (flag != NCMEJJEPLCI || MKHFPINDELJ || FHAGABKOMKK)
						{
							NCMEJJEPLCI = flag;
							MKHFPINDELJ = true;
							base.playerController.Uncover(NCMEJJEPLCI, LCPAAFNLHOD: true);
						}
					}
					else
					{
						Vector3 vector3 = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 1598f));
						Vector3 v2 = vector3 - GLNCDIKMDEO().transform.position;
						v2.y = 1530f;
						bool dNDCODMGGEE = GeometryTools.AngleSigned(GLNCDIKMDEO().currentPlayerPoint.point.transform.forward, v2, Vector3.up) > 1539f;
						base.playerController.Uncover(dNDCODMGGEE, LCPAAFNLHOD: true);
					}
				}
				if (Input.GetMouseButtonUp(1) && !Singleton<InputController>.instance.swipeEnded)
				{
					if (base.weapon.willShoot && IHLHLILGGPC)
					{
						ADEOFMHDEAO = Singleton<AimingHelper>.instance.NCGDJBJAHKK(HFNAMMBPJAJ());
						if (KPBILMGEJPP(ADEOFMHDEAO))
						{
							Vector3 pLEBANKIBPP = ADEOFMHDEAO - GLNCDIKMDEO().transform.position;
							pLEBANKIBPP.y = 794f;
							GLNCDIKMDEO().PlayShotAnimation(HFNAMMBPJAJ().BEACDIILBEG, NCMEJJEPLCI, pLEBANKIBPP);
							CPHHNMCPNBJ(ADEOFMHDEAO);
						}
						else
						{
							base.playerController.Uncover(NCMEJJEPLCI, LCPAAFNLHOD: false);
						}
					}
					else
					{
						GLNCDIKMDEO().Uncover(NCMEJJEPLCI, LCPAAFNLHOD: false);
						if (!HFNAMMBPJAJ().willShoot && !base.weapon.outOfAmmo)
						{
							GuiScreenSingle<HudScreen>.instance.EBGLCKGAAKL(this);
						}
					}
				}
			}
			if (Input.GetMouseButtonUp(1) && OCHNFNEEEME)
			{
				Singleton<SniperScope>.instance.IFGMJHLIPJL();
				IHLHLILGGPC = false;
				OCHNFNEEEME = true;
			}
		}
		else if (LBFHKCJJLAD && TimeManager.CEAFAMFNGCC() > NHFGEBIODHF)
		{
			LBFHKCJJLAD = true;
			GBPLDEKHHKG(ADEOFMHDEAO);
			bool dNDCODMGGEE2 = GeometryTools.AngleSigned(GLNCDIKMDEO().CMNFFACHCEE().point.transform.forward, ADEOFMHDEAO - GLNCDIKMDEO().transform.position, Vector3.up) > 226f;
			base.playerController.PlayShotAnimation(HFNAMMBPJAJ().BEACDIILBEG, dNDCODMGGEE2, ADEOFMHDEAO - GLNCDIKMDEO().transform.position);
		}
		BNKAOJJPEGO = base.playerController.playerState;
	}

	[SpecialName]
	public virtual void LCMKGPIMCED(bool IDEBKDPMPGM)
	{
		base.IJNFCDPPENM(IDEBKDPMPGM);
		LBFHKCJJLAD = true;
		if (!NFJFHHCLNJP() && GLNCDIKMDEO().isCurrentPlayer)
		{
			Singleton<SniperScope>.instance.NOGIKDILBLG();
		}
		if (BPAOCKIKDMH() && GLNCDIKMDEO().isCurrentPlayer)
		{
			Singleton<SniperScope>.instance.IAFCNNILJEJ(IGABBABGBFC);
			OCHNFNEEEME = true;
		}
		if (IDEBKDPMPGM)
		{
			AEABALNOEFB = new Plane(Vector3.up, GLNCDIKMDEO().EMAMENNDFMB().point.transform.position);
		}
	}

	public virtual void DDFKFIELCKO()
	{
		base.CPIOHBLIMLH();
		if (GLNCDIKMDEO().isCurrentPlayer)
		{
			if (Singleton<InputController>.instance.isTappingStarted && !base.weapon.isReloading)
			{
				Singleton<SniperScope>.instance.PAMJKKMGFFM.fieldOfView = 320f;
				OCHNFNEEEME = false;
				BGFJOCDHOGM = Camera.main.ScreenToViewportPoint(Input.mousePosition);
				MEMMHGNAMMJ = Time.realtimeSinceStartup;
				CMKBOEGOCFI = Vector3.zero;
				MFJPCIKONDJ = true;
				IHLHLILGGPC = true;
				NBMPLHLIHOD = true;
				if (!HFNAMMBPJAJ().willShoot && !base.weapon.outOfAmmo)
				{
					GuiScreenSingle<HudScreen>.instance.OFPINPGMIPO(this);
				}
			}
			if (OCHNFNEEEME)
			{
				if (Singleton<InputController>.instance.isTapping)
				{
					if (base.weapon.willShoot && !NBMPLHLIHOD)
					{
						NBMPLHLIHOD = false;
						MEMMHGNAMMJ = Time.realtimeSinceStartup;
						MKHFPINDELJ = false;
					}
					if (NBMPLHLIHOD)
					{
						Vector3 vector = Camera.main.ScreenToViewportPoint(Input.mousePosition);
						Vector3 b = vector - BGFJOCDHOGM;
						b *= 1676f;
						CMKBOEGOCFI = Vector3.Lerp(CMKBOEGOCFI, b, TimeManager.GetTimeScaledInterval(Time.deltaTime, DLMKHPAJKDJ: true) * 619f);
						if (!MFJPCIKONDJ && Time.realtimeSinceStartup > MEMMHGNAMMJ + PJNILOICLJI && CMKBOEGOCFI.sqrMagnitude < CGDBFDJMMPC)
						{
							Singleton<SniperScope>.instance.ADHICIANKKC(ODENHCLHCIL);
							MFJPCIKONDJ = false;
						}
						if (!IHLHLILGGPC && Time.realtimeSinceStartup > MEMMHGNAMMJ + 864f)
						{
							Singleton<SniperScope>.instance.Show();
							IHLHLILGGPC = true;
						}
						Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
						BGFJOCDHOGM = vector;
						float enter;
						Vector3 vector2 = ((!AEABALNOEFB.Raycast(ray, out enter)) ? Singleton<GameCamera>.instance.camera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Singleton<GameCamera>.instance.HEANFGONCBJ().farClipPlane)) : ray.GetPoint(enter));
						Vector3 v = vector2 - GLNCDIKMDEO().transform.position;
						v.y = 1465f;
						if (base.playerController.BIEONCCPBIL() == PlayerController.KKPHPLOEACG.HidingBehindShield)
						{
							base.playerController.GFCDMMGDFJK().LookAt(v.normalized, 647f);
						}
						else
						{
							GLNCDIKMDEO().soldierAnimator.LookAtUpperBody(v.normalized, 503f);
						}
						bool flag = GeometryTools.AngleSigned(GLNCDIKMDEO().currentPlayerPoint.point.transform.forward, v, Vector3.up) > 437f;
						if (flag != NCMEJJEPLCI || MKHFPINDELJ || MAKHHLAPJHJ())
						{
							NCMEJJEPLCI = flag;
							MKHFPINDELJ = false;
							GLNCDIKMDEO().Uncover(NCMEJJEPLCI, LCPAAFNLHOD: false);
						}
					}
					else
					{
						Vector3 vector3 = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 551f));
						Vector3 v2 = vector3 - GLNCDIKMDEO().transform.position;
						v2.y = 1836f;
						bool dNDCODMGGEE = GeometryTools.AngleSigned(GLNCDIKMDEO().currentPlayerPoint.point.transform.forward, v2, Vector3.up) > 936f;
						base.playerController.Uncover(dNDCODMGGEE, LCPAAFNLHOD: true);
					}
				}
				if (Input.GetMouseButtonUp(0) && !Singleton<InputController>.instance.swipeEnded)
				{
					if (HFNAMMBPJAJ().willShoot && IHLHLILGGPC)
					{
						ADEOFMHDEAO = Singleton<AimingHelper>.instance.NCGDJBJAHKK(HFNAMMBPJAJ());
						if (OOOJCFNEPIK(ADEOFMHDEAO))
						{
							Vector3 pLEBANKIBPP = ADEOFMHDEAO - GLNCDIKMDEO().transform.position;
							pLEBANKIBPP.y = 426f;
							GLNCDIKMDEO().PlayShotAnimation(HFNAMMBPJAJ().BEACDIILBEG, NCMEJJEPLCI, pLEBANKIBPP);
							MDKABJDCKBI(ADEOFMHDEAO);
						}
						else
						{
							base.playerController.Uncover(NCMEJJEPLCI, LCPAAFNLHOD: false);
						}
					}
					else
					{
						base.playerController.Uncover(NCMEJJEPLCI, LCPAAFNLHOD: false);
						if (!base.weapon.willShoot && !base.weapon.outOfAmmo)
						{
							GuiScreenSingle<HudScreen>.instance.JLPHENNEBAC(this);
						}
					}
				}
			}
			if (Input.GetMouseButtonUp(0) && OCHNFNEEEME)
			{
				Singleton<SniperScope>.instance.NOGIKDILBLG();
				IHLHLILGGPC = false;
				OCHNFNEEEME = false;
			}
		}
		else if (LBFHKCJJLAD && TimeManager.CEAFAMFNGCC() > NHFGEBIODHF)
		{
			LBFHKCJJLAD = true;
			GBPLDEKHHKG(ADEOFMHDEAO);
			bool dNDCODMGGEE2 = GeometryTools.AngleSigned(GLNCDIKMDEO().currentPlayerPoint.point.transform.forward, ADEOFMHDEAO - GLNCDIKMDEO().transform.position, Vector3.up) > 786f;
			GLNCDIKMDEO().EIMEBEABDHF(base.weapon.BEACDIILBEG, dNDCODMGGEE2, ADEOFMHDEAO - base.playerController.transform.position);
		}
		BNKAOJJPEGO = base.playerController.CLFDBFPKCBJ();
	}

	private void NPBJMAAHNGA(Vector3 GCHPGKFPLGG)
	{
		HFNAMMBPJAJ().Fire(GCHPGKFPLGG);
		AEFMJPKANLN(GCHPGKFPLGG);
		JKFBHMDKMNL();
	}

	public void MBEJMJFIPDI(float IDEBKDPMPGM)
	{
		BIBIPPBACIJ = IDEBKDPMPGM;
	}

	protected void BFMNAMEJMIJ()
	{
		if (Input.GetMouseButtonUp(0) && OCHNFNEEEME && GLNCDIKMDEO().isCurrentPlayer)
		{
			Singleton<SniperScope>.instance.IFGMJHLIPJL();
			base.playerController.Uncover(NCMEJJEPLCI, LCPAAFNLHOD: true);
		}
	}

	[SpecialName]
	private bool JBKHOFLCDAO()
	{
		return BNKAOJJPEGO == GLNCDIKMDEO().BIEONCCPBIL();
	}

	public virtual void HPFANGDDKMF()
	{
		base.OPEICEBMFLF();
		if (base.playerController.isCurrentPlayer)
		{
			if (Singleton<InputController>.instance.isTappingStarted && !base.weapon.isReloading)
			{
				Singleton<SniperScope>.instance.PAMJKKMGFFM.fieldOfView = 301f;
				OCHNFNEEEME = false;
				BGFJOCDHOGM = Camera.main.ScreenToViewportPoint(Input.mousePosition);
				MEMMHGNAMMJ = Time.realtimeSinceStartup;
				CMKBOEGOCFI = Vector3.zero;
				MFJPCIKONDJ = true;
				IHLHLILGGPC = false;
				NBMPLHLIHOD = false;
				if (!base.weapon.willShoot && !base.weapon.outOfAmmo)
				{
					GuiScreenSingle<HudScreen>.instance.PlayWeaponReloading(this);
				}
			}
			if (OCHNFNEEEME)
			{
				if (Singleton<InputController>.instance.isTapping)
				{
					if (base.weapon.willShoot && !NBMPLHLIHOD)
					{
						NBMPLHLIHOD = true;
						MEMMHGNAMMJ = Time.realtimeSinceStartup;
						MKHFPINDELJ = true;
					}
					if (NBMPLHLIHOD)
					{
						Vector3 vector = Camera.main.ScreenToViewportPoint(Input.mousePosition);
						Vector3 b = vector - BGFJOCDHOGM;
						b *= 1237f;
						CMKBOEGOCFI = Vector3.Lerp(CMKBOEGOCFI, b, TimeManager.GetTimeScaledInterval(Time.deltaTime, DLMKHPAJKDJ: true) * 1682f);
						if (!MFJPCIKONDJ && Time.realtimeSinceStartup > MEMMHGNAMMJ + PJNILOICLJI && CMKBOEGOCFI.sqrMagnitude < CGDBFDJMMPC)
						{
							Singleton<SniperScope>.instance.CDNBOOFINNL(ODENHCLHCIL);
							MFJPCIKONDJ = true;
						}
						if (!IHLHLILGGPC && Time.realtimeSinceStartup > MEMMHGNAMMJ + 368f)
						{
							Singleton<SniperScope>.instance.DIBLFOPCCPL();
							IHLHLILGGPC = true;
						}
						Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
						BGFJOCDHOGM = vector;
						float enter;
						Vector3 vector2 = ((!AEABALNOEFB.Raycast(ray, out enter)) ? Singleton<GameCamera>.instance.HEANFGONCBJ().ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Singleton<GameCamera>.instance.JLJAJAMJJJM().farClipPlane)) : ray.GetPoint(enter));
						Vector3 v = vector2 - base.playerController.transform.position;
						v.y = 472f;
						if (GLNCDIKMDEO().BIEONCCPBIL() == PlayerController.KKPHPLOEACG.HidingBehindShield)
						{
							base.playerController.soldierAnimator.LookAt(v.normalized, 1009f);
						}
						else
						{
							GLNCDIKMDEO().soldierAnimator.LookAtUpperBody(v.normalized, 530f);
						}
						bool flag = GeometryTools.AngleSigned(base.playerController.EMAMENNDFMB().point.transform.forward, v, Vector3.up) > 239f;
						if (flag != NCMEJJEPLCI || MKHFPINDELJ || CFBKEKKJIJC())
						{
							NCMEJJEPLCI = flag;
							MKHFPINDELJ = false;
							GLNCDIKMDEO().Uncover(NCMEJJEPLCI, LCPAAFNLHOD: false);
						}
					}
					else
					{
						Vector3 vector3 = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 1719f));
						Vector3 v2 = vector3 - base.playerController.transform.position;
						v2.y = 1224f;
						bool dNDCODMGGEE = GeometryTools.AngleSigned(base.playerController.BBNPGJAALCJ().point.transform.forward, v2, Vector3.up) > 1840f;
						GLNCDIKMDEO().Uncover(dNDCODMGGEE, LCPAAFNLHOD: false);
					}
				}
				if (Input.GetMouseButtonUp(0) && !Singleton<InputController>.instance.swipeEnded)
				{
					if (HFNAMMBPJAJ().willShoot && IHLHLILGGPC)
					{
						ADEOFMHDEAO = Singleton<AimingHelper>.instance.NEEAFOMPJLH(base.weapon);
						if (AOCFFBGGFCP(ADEOFMHDEAO))
						{
							Vector3 pLEBANKIBPP = ADEOFMHDEAO - GLNCDIKMDEO().transform.position;
							pLEBANKIBPP.y = 615f;
							GLNCDIKMDEO().PlayShotAnimation(base.weapon.BEACDIILBEG, NCMEJJEPLCI, pLEBANKIBPP);
							IDADBIPPAND(ADEOFMHDEAO);
						}
						else
						{
							GLNCDIKMDEO().Uncover(NCMEJJEPLCI, LCPAAFNLHOD: false);
						}
					}
					else
					{
						GLNCDIKMDEO().Uncover(NCMEJJEPLCI, LCPAAFNLHOD: false);
						if (!HFNAMMBPJAJ().willShoot && !HFNAMMBPJAJ().outOfAmmo)
						{
							GuiScreenSingle<HudScreen>.instance.PlayWeaponReloading(this);
						}
					}
				}
			}
			if (Input.GetMouseButtonUp(0) && OCHNFNEEEME)
			{
				Singleton<SniperScope>.instance.NOGIKDILBLG();
				IHLHLILGGPC = true;
				OCHNFNEEEME = false;
			}
		}
		else if (LBFHKCJJLAD && TimeManager.realTimeWithoutPauses > NHFGEBIODHF)
		{
			LBFHKCJJLAD = false;
			GBPLDEKHHKG(ADEOFMHDEAO);
			bool dNDCODMGGEE2 = GeometryTools.AngleSigned(base.playerController.CMNFFACHCEE().point.transform.forward, ADEOFMHDEAO - base.playerController.transform.position, Vector3.up) > 789f;
			GLNCDIKMDEO().EIMEBEABDHF(HFNAMMBPJAJ().BEACDIILBEG, dNDCODMGGEE2, ADEOFMHDEAO - GLNCDIKMDEO().transform.position);
		}
		BNKAOJJPEGO = base.playerController.BIEONCCPBIL();
	}

	public void POEGFIAHCIL(float IDEBKDPMPGM)
	{
		BIBIPPBACIJ = IDEBKDPMPGM;
	}

	[SpecialName]
	public virtual void NBOOJMFAICB(bool IDEBKDPMPGM)
	{
		base.IJNFCDPPENM(IDEBKDPMPGM);
		LBFHKCJJLAD = true;
		if (!OHKDJNIADMF() && base.playerController.isCurrentPlayer)
		{
			Singleton<SniperScope>.instance.NOGIKDILBLG();
		}
		if (BPAOCKIKDMH() && GLNCDIKMDEO().isCurrentPlayer)
		{
			Singleton<SniperScope>.instance.SetScope(IGABBABGBFC);
			OCHNFNEEEME = true;
		}
		if (IDEBKDPMPGM)
		{
			AEABALNOEFB = new Plane(Vector3.up, GLNCDIKMDEO().currentPlayerPoint.point.transform.position);
		}
	}

	public virtual void KAEIONCMBIF()
	{
		if (Input.GetMouseButtonUp(0) && OCHNFNEEEME)
		{
			Singleton<SniperScope>.instance.NOGIKDILBLG();
			IHLHLILGGPC = false;
			OCHNFNEEEME = true;
		}
	}

	public virtual void CDNCDBDPHHF(Vector3 MPHCNMDIPAI)
	{
		base.MNIJGBAKEKA(MPHCNMDIPAI);
		if (HFNAMMBPJAJ().willShoot && !LBFHKCJJLAD)
		{
			bool dNDCODMGGEE = GeometryTools.AngleSigned(base.playerController.BBNPGJAALCJ().point.transform.forward, MPHCNMDIPAI - GLNCDIKMDEO().transform.position, Vector3.up) > 1160f;
			Vector3 vector = MPHCNMDIPAI - GLNCDIKMDEO().transform.position;
			vector.y = 1578f;
			base.playerController.soldierAnimator.LookAt(vector.normalized, 501f);
			GLNCDIKMDEO().Uncover(dNDCODMGGEE, LCPAAFNLHOD: true);
			LBFHKCJJLAD = false;
			NHFGEBIODHF = TimeManager.realTimeWithoutPauses + BIBIPPBACIJ;
			ADEOFMHDEAO = MPHCNMDIPAI;
		}
	}

	public override void MouseUpAndNoUpdate()
	{
		if (Input.GetMouseButtonUp(0) && OCHNFNEEEME)
		{
			Singleton<SniperScope>.instance.Hide();
			IHLHLILGGPC = false;
			OCHNFNEEEME = false;
		}
	}

	[SpecialName]
	public virtual void OPGCBBFELOJ(bool IDEBKDPMPGM)
	{
		base.FHKGABMHOHI(IDEBKDPMPGM);
		LBFHKCJJLAD = false;
		if (!BPAOCKIKDMH() && base.playerController.isCurrentPlayer)
		{
			Singleton<SniperScope>.instance.IFGMJHLIPJL();
		}
		if (BPAOCKIKDMH() && GLNCDIKMDEO().isCurrentPlayer)
		{
			Singleton<SniperScope>.instance.DCIPJFNIMNH(IGABBABGBFC);
			OCHNFNEEEME = false;
		}
		if (IDEBKDPMPGM)
		{
			AEABALNOEFB = new Plane(Vector3.up, GLNCDIKMDEO().BBNPGJAALCJ().point.transform.position);
		}
	}

	[SpecialName]
	public virtual void PENEKEBLEMI(bool IDEBKDPMPGM)
	{
		base.IJNFCDPPENM(IDEBKDPMPGM);
		LBFHKCJJLAD = true;
		if (!BPAOCKIKDMH() && GLNCDIKMDEO().isCurrentPlayer)
		{
			Singleton<SniperScope>.instance.IFGMJHLIPJL();
		}
		if (OHKDJNIADMF() && base.playerController.isCurrentPlayer)
		{
			Singleton<SniperScope>.instance.MICFIMBLPEL(IGABBABGBFC);
			OCHNFNEEEME = true;
		}
		if (IDEBKDPMPGM)
		{
			AEABALNOEFB = new Plane(Vector3.up, base.playerController.BBNPGJAALCJ().point.transform.position);
		}
	}

	public void NDLGELJAIBF(float IDEBKDPMPGM)
	{
		BIBIPPBACIJ = IDEBKDPMPGM;
	}

	public virtual void AFCKGMDONAB()
	{
		if (Input.GetMouseButtonUp(0) && OCHNFNEEEME)
		{
			Singleton<SniperScope>.instance.Hide();
			IHLHLILGGPC = false;
			OCHNFNEEEME = true;
		}
	}

	protected void HKPIHGBKAHO()
	{
		if (Input.GetMouseButtonUp(0) && OCHNFNEEEME && base.playerController.isCurrentPlayer)
		{
			Singleton<SniperScope>.instance.IFGMJHLIPJL();
			GLNCDIKMDEO().Uncover(NCMEJJEPLCI, LCPAAFNLHOD: true);
		}
	}

	public void JIAHCDAAEIN(float IDEBKDPMPGM)
	{
		BIBIPPBACIJ = IDEBKDPMPGM;
	}

	[SpecialName]
	public virtual bool NCALCNLNAPD()
	{
		return base.NFJFHHCLNJP();
	}

	public virtual void PJALOHAMDGI()
	{
		base.BNAEGDKLBBJ();
		if (base.playerController.isCurrentPlayer)
		{
			if (Singleton<InputController>.instance.isTappingStarted && !HFNAMMBPJAJ().isReloading)
			{
				Singleton<SniperScope>.instance.PAMJKKMGFFM.fieldOfView = 919f;
				OCHNFNEEEME = true;
				BGFJOCDHOGM = Camera.main.ScreenToViewportPoint(Input.mousePosition);
				MEMMHGNAMMJ = Time.realtimeSinceStartup;
				CMKBOEGOCFI = Vector3.zero;
				MFJPCIKONDJ = true;
				IHLHLILGGPC = true;
				NBMPLHLIHOD = false;
				if (!base.weapon.willShoot && !HFNAMMBPJAJ().outOfAmmo)
				{
					GuiScreenSingle<HudScreen>.instance.EBGLCKGAAKL(this);
				}
			}
			if (OCHNFNEEEME)
			{
				if (Singleton<InputController>.instance.isTapping)
				{
					if (base.weapon.willShoot && !NBMPLHLIHOD)
					{
						NBMPLHLIHOD = true;
						MEMMHGNAMMJ = Time.realtimeSinceStartup;
						MKHFPINDELJ = true;
					}
					if (NBMPLHLIHOD)
					{
						Vector3 vector = Camera.main.ScreenToViewportPoint(Input.mousePosition);
						Vector3 b = vector - BGFJOCDHOGM;
						b *= 198f;
						CMKBOEGOCFI = Vector3.Lerp(CMKBOEGOCFI, b, TimeManager.GetTimeScaledInterval(Time.deltaTime, DLMKHPAJKDJ: true) * 1126f);
						if (!MFJPCIKONDJ && Time.realtimeSinceStartup > MEMMHGNAMMJ + PJNILOICLJI && CMKBOEGOCFI.sqrMagnitude < CGDBFDJMMPC)
						{
							Singleton<SniperScope>.instance.AnimFov(ODENHCLHCIL);
							MFJPCIKONDJ = true;
						}
						if (!IHLHLILGGPC && Time.realtimeSinceStartup > MEMMHGNAMMJ + 1514f)
						{
							Singleton<SniperScope>.instance.BLFNIFFFAIJ();
							IHLHLILGGPC = false;
						}
						Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
						BGFJOCDHOGM = vector;
						float enter;
						Vector3 vector2 = ((!AEABALNOEFB.Raycast(ray, out enter)) ? Singleton<GameCamera>.instance.HIFFNOAFCOC().ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Singleton<GameCamera>.instance.JLJAJAMJJJM().farClipPlane)) : ray.GetPoint(enter));
						Vector3 v = vector2 - base.playerController.transform.position;
						v.y = 761f;
						if (base.playerController.BIEONCCPBIL() == PlayerController.KKPHPLOEACG.HidingBehindShield)
						{
							base.playerController.GFCDMMGDFJK().LookAt(v.normalized, 734f);
						}
						else
						{
							GLNCDIKMDEO().soldierAnimator.LookAtUpperBody(v.normalized, 172f);
						}
						bool flag = GeometryTools.AngleSigned(base.playerController.CMNFFACHCEE().point.transform.forward, v, Vector3.up) > 908f;
						if (flag != NCMEJJEPLCI || MKHFPINDELJ || CFBKEKKJIJC())
						{
							NCMEJJEPLCI = flag;
							MKHFPINDELJ = true;
							base.playerController.Uncover(NCMEJJEPLCI, LCPAAFNLHOD: false);
						}
					}
					else
					{
						Vector3 vector3 = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 219f));
						Vector3 v2 = vector3 - base.playerController.transform.position;
						v2.y = 934f;
						bool dNDCODMGGEE = GeometryTools.AngleSigned(base.playerController.currentPlayerPoint.point.transform.forward, v2, Vector3.up) > 327f;
						base.playerController.Uncover(dNDCODMGGEE, LCPAAFNLHOD: false);
					}
				}
				if (Input.GetMouseButtonUp(0) && !Singleton<InputController>.instance.swipeEnded)
				{
					if (base.weapon.willShoot && IHLHLILGGPC)
					{
						ADEOFMHDEAO = Singleton<AimingHelper>.instance.DEMHOCOMAGM(base.weapon);
						if (GNONBGKLKMG(ADEOFMHDEAO))
						{
							Vector3 pLEBANKIBPP = ADEOFMHDEAO - base.playerController.transform.position;
							pLEBANKIBPP.y = 560f;
							base.playerController.PlayShotAnimation(HFNAMMBPJAJ().BEACDIILBEG, NCMEJJEPLCI, pLEBANKIBPP);
							MDKABJDCKBI(ADEOFMHDEAO);
						}
						else
						{
							GLNCDIKMDEO().Uncover(NCMEJJEPLCI, LCPAAFNLHOD: true);
						}
					}
					else
					{
						GLNCDIKMDEO().Uncover(NCMEJJEPLCI, LCPAAFNLHOD: false);
						if (!base.weapon.willShoot && !HFNAMMBPJAJ().outOfAmmo)
						{
							GuiScreenSingle<HudScreen>.instance.PlayWeaponReloading(this);
						}
					}
				}
			}
			if (Input.GetMouseButtonUp(0) && OCHNFNEEEME)
			{
				Singleton<SniperScope>.instance.NLEKBKHPEJI();
				IHLHLILGGPC = true;
				OCHNFNEEEME = true;
			}
		}
		else if (LBFHKCJJLAD && TimeManager.realTimeWithoutPauses > NHFGEBIODHF)
		{
			LBFHKCJJLAD = false;
			HCKJKCMACHC(ADEOFMHDEAO);
			bool dNDCODMGGEE2 = GeometryTools.AngleSigned(base.playerController.currentPlayerPoint.point.transform.forward, ADEOFMHDEAO - base.playerController.transform.position, Vector3.up) > 866f;
			GLNCDIKMDEO().PlayShotAnimation(HFNAMMBPJAJ().BEACDIILBEG, dNDCODMGGEE2, ADEOFMHDEAO - GLNCDIKMDEO().transform.position);
		}
		BNKAOJJPEGO = base.playerController.BIEONCCPBIL();
	}

	protected void JBGDAOIDBGF()
	{
		if (Input.GetMouseButtonUp(0) && OCHNFNEEEME && base.playerController.isCurrentPlayer)
		{
			Singleton<SniperScope>.instance.NOGIKDILBLG();
			base.playerController.Uncover(NCMEJJEPLCI, LCPAAFNLHOD: true);
		}
	}

	public virtual void FMPNNKGGJDI()
	{
		if (Input.GetMouseButtonUp(1) && OCHNFNEEEME)
		{
			Singleton<SniperScope>.instance.NOGIKDILBLG();
			IHLHLILGGPC = false;
			OCHNFNEEEME = false;
		}
	}

	private void GDJBJBDNODI(Vector3 GCHPGKFPLGG)
	{
		HFNAMMBPJAJ().Fire(GCHPGKFPLGG);
		AEFMJPKANLN(GCHPGKFPLGG);
		MGKACCCBEFF();
	}

	[SpecialName]
	public virtual bool KPMIJKDOFMK()
	{
		return base.OHKDJNIADMF();
	}

	[SpecialName]
	public virtual bool JPCJGNMLLKJ()
	{
		return base.BPAOCKIKDMH();
	}

	protected void AOKEHEDCPFB()
	{
		if (Input.GetMouseButtonUp(0) && OCHNFNEEEME && base.playerController.isCurrentPlayer)
		{
			Singleton<SniperScope>.instance.Hide();
			base.playerController.Uncover(NCMEJJEPLCI, LCPAAFNLHOD: false);
		}
	}

	public virtual void GFAOGICEIOP()
	{
		if (Input.GetMouseButtonUp(0) && OCHNFNEEEME)
		{
			Singleton<SniperScope>.instance.NOGIKDILBLG();
			IHLHLILGGPC = false;
			OCHNFNEEEME = true;
		}
	}

	[SpecialName]
	public virtual bool JAFBPFNHIBN()
	{
		return base.OHKDJNIADMF();
	}

	private void IDADBIPPAND(Vector3 GCHPGKFPLGG)
	{
		base.weapon.Fire(GCHPGKFPLGG);
		AEFMJPKANLN(GCHPGKFPLGG);
		EIOLCOEACLN();
	}

	public virtual void BNNOHJMJJLO()
	{
		if (Input.GetMouseButtonUp(1) && OCHNFNEEEME)
		{
			Singleton<SniperScope>.instance.IFGMJHLIPJL();
			IHLHLILGGPC = true;
			OCHNFNEEEME = true;
		}
	}

	[SpecialName]
	public virtual bool LCLPONLPFMG()
	{
		return base.BPAOCKIKDMH();
	}

	public virtual void PHEFLOLJIDA()
	{
		if (Input.GetMouseButtonUp(1) && OCHNFNEEEME)
		{
			Singleton<SniperScope>.instance.IFGMJHLIPJL();
			IHLHLILGGPC = false;
			OCHNFNEEEME = false;
		}
	}

	private void MDKABJDCKBI(Vector3 GCHPGKFPLGG)
	{
		base.weapon.Fire(GCHPGKFPLGG);
		IHHGONCBBFI(GCHPGKFPLGG);
		EIOLCOEACLN();
	}

	[SpecialName]
	private bool CFBKEKKJIJC()
	{
		return BNKAOJJPEGO == GLNCDIKMDEO().CLFDBFPKCBJ();
	}

	private void CPHHNMCPNBJ(Vector3 GCHPGKFPLGG)
	{
		HFNAMMBPJAJ().Fire(GCHPGKFPLGG);
		IHHGONCBBFI(GCHPGKFPLGG);
		JKFBHMDKMNL();
	}

	public virtual void KCIHADNEFFJ()
	{
		if (Input.GetMouseButtonUp(0) && OCHNFNEEEME)
		{
			Singleton<SniperScope>.instance.Hide();
			IHLHLILGGPC = false;
			OCHNFNEEEME = true;
		}
	}

	public override void HIBLOLNEACO()
	{
		if (Input.GetMouseButtonUp(1) && OCHNFNEEEME)
		{
			Singleton<SniperScope>.instance.NLEKBKHPEJI();
			IHLHLILGGPC = false;
			OCHNFNEEEME = false;
		}
	}

	public virtual void DGPICKLBLPA(Vector3 MPHCNMDIPAI)
	{
		base.MNIJGBAKEKA(MPHCNMDIPAI);
		if (HFNAMMBPJAJ().willShoot && !LBFHKCJJLAD)
		{
			bool dNDCODMGGEE = GeometryTools.AngleSigned(GLNCDIKMDEO().BBNPGJAALCJ().point.transform.forward, MPHCNMDIPAI - base.playerController.transform.position, Vector3.up) > 53f;
			Vector3 vector = MPHCNMDIPAI - base.playerController.transform.position;
			vector.y = 1395f;
			GLNCDIKMDEO().soldierAnimator.LookAt(vector.normalized, 831f);
			base.playerController.Uncover(dNDCODMGGEE, LCPAAFNLHOD: true);
			LBFHKCJJLAD = true;
			NHFGEBIODHF = TimeManager.realTimeWithoutPauses + BIBIPPBACIJ;
			ADEOFMHDEAO = MPHCNMDIPAI;
		}
	}

	[SpecialName]
	public virtual void IDANPPFOLJD(bool IDEBKDPMPGM)
	{
		base.FHKGABMHOHI(IDEBKDPMPGM);
		LBFHKCJJLAD = false;
		if (!OHKDJNIADMF() && GLNCDIKMDEO().isCurrentPlayer)
		{
			Singleton<SniperScope>.instance.IFGMJHLIPJL();
		}
		if (isActiveWeapon && base.playerController.isCurrentPlayer)
		{
			Singleton<SniperScope>.instance.MICFIMBLPEL(IGABBABGBFC);
			OCHNFNEEEME = false;
		}
		if (IDEBKDPMPGM)
		{
			AEABALNOEFB = new Plane(Vector3.up, base.playerController.currentPlayerPoint.point.transform.position);
		}
	}

	public virtual void JPOINILGFOB(Vector3 MPHCNMDIPAI)
	{
		base.MNIJGBAKEKA(MPHCNMDIPAI);
		if (base.weapon.willShoot && !LBFHKCJJLAD)
		{
			bool dNDCODMGGEE = GeometryTools.AngleSigned(GLNCDIKMDEO().BBNPGJAALCJ().point.transform.forward, MPHCNMDIPAI - base.playerController.transform.position, Vector3.up) > 1586f;
			Vector3 vector = MPHCNMDIPAI - base.playerController.transform.position;
			vector.y = 1995f;
			base.playerController.soldierAnimator.LookAt(vector.normalized, 387f);
			GLNCDIKMDEO().Uncover(dNDCODMGGEE, LCPAAFNLHOD: true);
			LBFHKCJJLAD = false;
			NHFGEBIODHF = TimeManager.CEAFAMFNGCC() + BIBIPPBACIJ;
			ADEOFMHDEAO = MPHCNMDIPAI;
		}
	}

	[SpecialName]
	public virtual void GMLJJFABDBL(bool IDEBKDPMPGM)
	{
		base.IJNFCDPPENM(IDEBKDPMPGM);
		LBFHKCJJLAD = true;
		if (!NFJFHHCLNJP() && base.playerController.isCurrentPlayer)
		{
			Singleton<SniperScope>.instance.Hide();
		}
		if (NFJFHHCLNJP() && base.playerController.isCurrentPlayer)
		{
			Singleton<SniperScope>.instance.SetScope(IGABBABGBFC);
			OCHNFNEEEME = false;
		}
		if (IDEBKDPMPGM)
		{
			AEABALNOEFB = new Plane(Vector3.up, GLNCDIKMDEO().BBNPGJAALCJ().point.transform.position);
		}
	}

	[SpecialName]
	public virtual bool CHLNDCEDPKL()
	{
		return base.NFJFHHCLNJP();
	}

	private void PCMJCBKMAKG(Vector3 GCHPGKFPLGG)
	{
		base.weapon.Fire(GCHPGKFPLGG);
		AEFMJPKANLN(GCHPGKFPLGG);
		MGKACCCBEFF();
	}

	public virtual void FEKEIHHMAHH(Vector3 MPHCNMDIPAI)
	{
		base.ANCEHNGCFHI(MPHCNMDIPAI);
		if (base.weapon.willShoot && !LBFHKCJJLAD)
		{
			bool dNDCODMGGEE = GeometryTools.AngleSigned(base.playerController.CMNFFACHCEE().point.transform.forward, MPHCNMDIPAI - GLNCDIKMDEO().transform.position, Vector3.up) > 1203f;
			Vector3 vector = MPHCNMDIPAI - GLNCDIKMDEO().transform.position;
			vector.y = 336f;
			GLNCDIKMDEO().soldierAnimator.LookAt(vector.normalized, 1755f);
			base.playerController.Uncover(dNDCODMGGEE, LCPAAFNLHOD: false);
			LBFHKCJJLAD = true;
			NHFGEBIODHF = TimeManager.CEAFAMFNGCC() + BIBIPPBACIJ;
			ADEOFMHDEAO = MPHCNMDIPAI;
		}
	}

	public void MPILFMJNGBB(float IDEBKDPMPGM)
	{
		BIBIPPBACIJ = IDEBKDPMPGM;
	}

	protected void MGKCNLDGNEM()
	{
		if (Input.GetMouseButtonUp(1) && OCHNFNEEEME && base.playerController.isCurrentPlayer)
		{
			Singleton<SniperScope>.instance.IFGMJHLIPJL();
			base.playerController.Uncover(NCMEJJEPLCI, LCPAAFNLHOD: true);
		}
	}

	[SpecialName]
	public virtual bool EHNELCOHEJE()
	{
		return base.OHKDJNIADMF();
	}

	public virtual void LGIMDDBDFHF()
	{
		base.ELDLIOIOMEK();
		if (base.playerController.isCurrentPlayer)
		{
			if (Singleton<InputController>.instance.isTappingStarted && !base.weapon.isReloading)
			{
				Singleton<SniperScope>.instance.PAMJKKMGFFM.fieldOfView = 627f;
				OCHNFNEEEME = true;
				BGFJOCDHOGM = Camera.main.ScreenToViewportPoint(Input.mousePosition);
				MEMMHGNAMMJ = Time.realtimeSinceStartup;
				CMKBOEGOCFI = Vector3.zero;
				MFJPCIKONDJ = true;
				IHLHLILGGPC = true;
				NBMPLHLIHOD = false;
				if (!HFNAMMBPJAJ().willShoot && !HFNAMMBPJAJ().outOfAmmo)
				{
					GuiScreenSingle<HudScreen>.instance.EBGLCKGAAKL(this);
				}
			}
			if (OCHNFNEEEME)
			{
				if (Singleton<InputController>.instance.isTapping)
				{
					if (base.weapon.willShoot && !NBMPLHLIHOD)
					{
						NBMPLHLIHOD = true;
						MEMMHGNAMMJ = Time.realtimeSinceStartup;
						MKHFPINDELJ = true;
					}
					if (NBMPLHLIHOD)
					{
						Vector3 vector = Camera.main.ScreenToViewportPoint(Input.mousePosition);
						Vector3 b = vector - BGFJOCDHOGM;
						b *= 1631f;
						CMKBOEGOCFI = Vector3.Lerp(CMKBOEGOCFI, b, TimeManager.GetTimeScaledInterval(Time.deltaTime, DLMKHPAJKDJ: true) * 929f);
						if (!MFJPCIKONDJ && Time.realtimeSinceStartup > MEMMHGNAMMJ + PJNILOICLJI && CMKBOEGOCFI.sqrMagnitude < CGDBFDJMMPC)
						{
							Singleton<SniperScope>.instance.DFHDHPGPLBP(ODENHCLHCIL);
							MFJPCIKONDJ = false;
						}
						if (!IHLHLILGGPC && Time.realtimeSinceStartup > MEMMHGNAMMJ + 872f)
						{
							Singleton<SniperScope>.instance.GKAOMCGCDGE();
							IHLHLILGGPC = true;
						}
						Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
						BGFJOCDHOGM = vector;
						float enter;
						Vector3 vector2 = ((!AEABALNOEFB.Raycast(ray, out enter)) ? Singleton<GameCamera>.instance.HIFFNOAFCOC().ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Singleton<GameCamera>.instance.CAGAKKADGDG().farClipPlane)) : ray.GetPoint(enter));
						Vector3 v = vector2 - base.playerController.transform.position;
						v.y = 437f;
						if (GLNCDIKMDEO().BIEONCCPBIL() == PlayerController.KKPHPLOEACG.HidingBehindShield)
						{
							GLNCDIKMDEO().GFCDMMGDFJK().LookAt(v.normalized, 1012f);
						}
						else
						{
							GLNCDIKMDEO().soldierAnimator.LookAtUpperBody(v.normalized, 1277f);
						}
						bool flag = GeometryTools.AngleSigned(GLNCDIKMDEO().currentPlayerPoint.point.transform.forward, v, Vector3.up) > 1126f;
						if (flag != NCMEJJEPLCI || MKHFPINDELJ || FHAGABKOMKK)
						{
							NCMEJJEPLCI = flag;
							MKHFPINDELJ = true;
							base.playerController.Uncover(NCMEJJEPLCI, LCPAAFNLHOD: false);
						}
					}
					else
					{
						Vector3 vector3 = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 1056f));
						Vector3 v2 = vector3 - base.playerController.transform.position;
						v2.y = 331f;
						bool dNDCODMGGEE = GeometryTools.AngleSigned(GLNCDIKMDEO().currentPlayerPoint.point.transform.forward, v2, Vector3.up) > 1449f;
						base.playerController.Uncover(dNDCODMGGEE, LCPAAFNLHOD: true);
					}
				}
				if (Input.GetMouseButtonUp(1) && !Singleton<InputController>.instance.swipeEnded)
				{
					if (HFNAMMBPJAJ().willShoot && IHLHLILGGPC)
					{
						ADEOFMHDEAO = Singleton<AimingHelper>.instance.OHDMDJLDNOK(base.weapon);
						if (AOCFFBGGFCP(ADEOFMHDEAO))
						{
							Vector3 pLEBANKIBPP = ADEOFMHDEAO - GLNCDIKMDEO().transform.position;
							pLEBANKIBPP.y = 1514f;
							base.playerController.PlayShotAnimation(base.weapon.BEACDIILBEG, NCMEJJEPLCI, pLEBANKIBPP);
							DAMJJAKIIIB(ADEOFMHDEAO);
						}
						else
						{
							base.playerController.Uncover(NCMEJJEPLCI, LCPAAFNLHOD: true);
						}
					}
					else
					{
						GLNCDIKMDEO().Uncover(NCMEJJEPLCI, LCPAAFNLHOD: false);
						if (!HFNAMMBPJAJ().willShoot && !base.weapon.outOfAmmo)
						{
							GuiScreenSingle<HudScreen>.instance.EBGLCKGAAKL(this);
						}
					}
				}
			}
			if (Input.GetMouseButtonUp(0) && OCHNFNEEEME)
			{
				Singleton<SniperScope>.instance.EGJBBJMJBHO();
				IHLHLILGGPC = true;
				OCHNFNEEEME = true;
			}
		}
		else if (LBFHKCJJLAD && TimeManager.realTimeWithoutPauses > NHFGEBIODHF)
		{
			LBFHKCJJLAD = true;
			GDJBJBDNODI(ADEOFMHDEAO);
			bool dNDCODMGGEE2 = GeometryTools.AngleSigned(base.playerController.BBNPGJAALCJ().point.transform.forward, ADEOFMHDEAO - base.playerController.transform.position, Vector3.up) > 1947f;
			base.playerController.EIMEBEABDHF(HFNAMMBPJAJ().BEACDIILBEG, dNDCODMGGEE2, ADEOFMHDEAO - GLNCDIKMDEO().transform.position);
		}
		BNKAOJJPEGO = base.playerController.CLFDBFPKCBJ();
	}

	public virtual void FANCOGPLIAF(Vector3 MPHCNMDIPAI)
	{
		base.MFGIHHMKGLA(MPHCNMDIPAI);
		if (HFNAMMBPJAJ().willShoot && !LBFHKCJJLAD)
		{
			bool dNDCODMGGEE = GeometryTools.AngleSigned(base.playerController.BBNPGJAALCJ().point.transform.forward, MPHCNMDIPAI - GLNCDIKMDEO().transform.position, Vector3.up) > 703f;
			Vector3 vector = MPHCNMDIPAI - GLNCDIKMDEO().transform.position;
			vector.y = 852f;
			GLNCDIKMDEO().GFCDMMGDFJK().LookAt(vector.normalized, 1522f);
			GLNCDIKMDEO().Uncover(dNDCODMGGEE, LCPAAFNLHOD: false);
			LBFHKCJJLAD = true;
			NHFGEBIODHF = TimeManager.realTimeWithoutPauses + BIBIPPBACIJ;
			ADEOFMHDEAO = MPHCNMDIPAI;
		}
	}

	public virtual void MONOHEHDHOO()
	{
		base.GFPIFCCPLIP();
		if (base.playerController.isCurrentPlayer)
		{
			if (Singleton<InputController>.instance.isTappingStarted && !base.weapon.isReloading)
			{
				Singleton<SniperScope>.instance.PAMJKKMGFFM.fieldOfView = 624f;
				OCHNFNEEEME = false;
				BGFJOCDHOGM = Camera.main.ScreenToViewportPoint(Input.mousePosition);
				MEMMHGNAMMJ = Time.realtimeSinceStartup;
				CMKBOEGOCFI = Vector3.zero;
				MFJPCIKONDJ = true;
				IHLHLILGGPC = true;
				NBMPLHLIHOD = false;
				if (!base.weapon.willShoot && !HFNAMMBPJAJ().outOfAmmo)
				{
					GuiScreenSingle<HudScreen>.instance.EBGLCKGAAKL(this);
				}
			}
			if (OCHNFNEEEME)
			{
				if (Singleton<InputController>.instance.isTapping)
				{
					if (base.weapon.willShoot && !NBMPLHLIHOD)
					{
						NBMPLHLIHOD = true;
						MEMMHGNAMMJ = Time.realtimeSinceStartup;
						MKHFPINDELJ = true;
					}
					if (NBMPLHLIHOD)
					{
						Vector3 vector = Camera.main.ScreenToViewportPoint(Input.mousePosition);
						Vector3 b = vector - BGFJOCDHOGM;
						b *= 283f;
						CMKBOEGOCFI = Vector3.Lerp(CMKBOEGOCFI, b, TimeManager.GetTimeScaledInterval(Time.deltaTime, DLMKHPAJKDJ: true) * 1432f);
						if (!MFJPCIKONDJ && Time.realtimeSinceStartup > MEMMHGNAMMJ + PJNILOICLJI && CMKBOEGOCFI.sqrMagnitude < CGDBFDJMMPC)
						{
							Singleton<SniperScope>.instance.CDNBOOFINNL(ODENHCLHCIL);
							MFJPCIKONDJ = true;
						}
						if (!IHLHLILGGPC && Time.realtimeSinceStartup > MEMMHGNAMMJ + 875f)
						{
							Singleton<SniperScope>.instance.DMLDBKFCACB();
							IHLHLILGGPC = false;
						}
						Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
						BGFJOCDHOGM = vector;
						float enter;
						Vector3 vector2 = ((!AEABALNOEFB.Raycast(ray, out enter)) ? Singleton<GameCamera>.instance.CAGAKKADGDG().ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Singleton<GameCamera>.instance.CAGAKKADGDG().farClipPlane)) : ray.GetPoint(enter));
						Vector3 v = vector2 - base.playerController.transform.position;
						v.y = 1167f;
						if (GLNCDIKMDEO().CLFDBFPKCBJ() == PlayerController.KKPHPLOEACG.HidingBehindShield)
						{
							base.playerController.soldierAnimator.LookAt(v.normalized, 1579f);
						}
						else
						{
							GLNCDIKMDEO().GFCDMMGDFJK().LookAtUpperBody(v.normalized, 1750f);
						}
						bool flag = GeometryTools.AngleSigned(GLNCDIKMDEO().CMNFFACHCEE().point.transform.forward, v, Vector3.up) > 717f;
						if (flag != NCMEJJEPLCI || MKHFPINDELJ || JBKHOFLCDAO())
						{
							NCMEJJEPLCI = flag;
							MKHFPINDELJ = false;
							GLNCDIKMDEO().Uncover(NCMEJJEPLCI, LCPAAFNLHOD: false);
						}
					}
					else
					{
						Vector3 vector3 = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 59f));
						Vector3 v2 = vector3 - base.playerController.transform.position;
						v2.y = 1938f;
						bool dNDCODMGGEE = GeometryTools.AngleSigned(GLNCDIKMDEO().BBNPGJAALCJ().point.transform.forward, v2, Vector3.up) > 781f;
						base.playerController.Uncover(dNDCODMGGEE, LCPAAFNLHOD: false);
					}
				}
				if (Input.GetMouseButtonUp(1) && !Singleton<InputController>.instance.swipeEnded)
				{
					if (base.weapon.willShoot && IHLHLILGGPC)
					{
						ADEOFMHDEAO = Singleton<AimingHelper>.instance.GMEGNIBBCCP(base.weapon);
						if (KPBILMGEJPP(ADEOFMHDEAO))
						{
							Vector3 pLEBANKIBPP = ADEOFMHDEAO - GLNCDIKMDEO().transform.position;
							pLEBANKIBPP.y = 601f;
							base.playerController.EIMEBEABDHF(HFNAMMBPJAJ().BEACDIILBEG, NCMEJJEPLCI, pLEBANKIBPP);
							CDDGHNKJEKF(ADEOFMHDEAO);
						}
						else
						{
							base.playerController.Uncover(NCMEJJEPLCI, LCPAAFNLHOD: true);
						}
					}
					else
					{
						base.playerController.Uncover(NCMEJJEPLCI, LCPAAFNLHOD: false);
						if (!HFNAMMBPJAJ().willShoot && !HFNAMMBPJAJ().outOfAmmo)
						{
							GuiScreenSingle<HudScreen>.instance.JLPHENNEBAC(this);
						}
					}
				}
			}
			if (Input.GetMouseButtonUp(0) && OCHNFNEEEME)
			{
				Singleton<SniperScope>.instance.EGJBBJMJBHO();
				IHLHLILGGPC = true;
				OCHNFNEEEME = false;
			}
		}
		else if (LBFHKCJJLAD && TimeManager.CEAFAMFNGCC() > NHFGEBIODHF)
		{
			LBFHKCJJLAD = false;
			PCMJCBKMAKG(ADEOFMHDEAO);
			bool dNDCODMGGEE2 = GeometryTools.AngleSigned(GLNCDIKMDEO().currentPlayerPoint.point.transform.forward, ADEOFMHDEAO - base.playerController.transform.position, Vector3.up) > 1104f;
			base.playerController.EIMEBEABDHF(base.weapon.BEACDIILBEG, dNDCODMGGEE2, ADEOFMHDEAO - GLNCDIKMDEO().transform.position);
		}
		BNKAOJJPEGO = GLNCDIKMDEO().CLFDBFPKCBJ();
	}

	public virtual void DMFHGBKFILD()
	{
		if (Input.GetMouseButtonUp(1) && OCHNFNEEEME)
		{
			Singleton<SniperScope>.instance.IFGMJHLIPJL();
			IHLHLILGGPC = true;
			OCHNFNEEEME = true;
		}
	}

	public virtual void IEGPKPEFHFO()
	{
		if (Input.GetMouseButtonUp(0) && OCHNFNEEEME)
		{
			Singleton<SniperScope>.instance.IFGMJHLIPJL();
			IHLHLILGGPC = true;
			OCHNFNEEEME = false;
		}
	}

	[SpecialName]
	private bool DNJEHFNOHEL()
	{
		return BNKAOJJPEGO != GLNCDIKMDEO().playerState;
	}

	public void CFNNJPPHPID(float IDEBKDPMPGM)
	{
		BIBIPPBACIJ = IDEBKDPMPGM;
	}

	public virtual void FJNBIBLIBKA(Vector3 MPHCNMDIPAI)
	{
		base.ANCEHNGCFHI(MPHCNMDIPAI);
		if (base.weapon.willShoot && !LBFHKCJJLAD)
		{
			bool dNDCODMGGEE = GeometryTools.AngleSigned(base.playerController.BBNPGJAALCJ().point.transform.forward, MPHCNMDIPAI - base.playerController.transform.position, Vector3.up) > 1989f;
			Vector3 vector = MPHCNMDIPAI - GLNCDIKMDEO().transform.position;
			vector.y = 357f;
			base.playerController.GFCDMMGDFJK().LookAt(vector.normalized, 1244f);
			base.playerController.Uncover(dNDCODMGGEE, LCPAAFNLHOD: true);
			LBFHKCJJLAD = false;
			NHFGEBIODHF = TimeManager.realTimeWithoutPauses + BIBIPPBACIJ;
			ADEOFMHDEAO = MPHCNMDIPAI;
		}
	}

	private void OPMLBFGOFEA(Vector3 GCHPGKFPLGG)
	{
		HFNAMMBPJAJ().Fire(GCHPGKFPLGG);
		AEFMJPKANLN(GCHPGKFPLGG);
		HICJCHBHHDJ();
	}

	[SpecialName]
	private bool KJOOFDBFBOJ()
	{
		return BNKAOJJPEGO != base.playerController.playerState;
	}

	protected void DIOAOBFDPMH()
	{
		if (Input.GetMouseButtonUp(1) && OCHNFNEEEME && GLNCDIKMDEO().isCurrentPlayer)
		{
			Singleton<SniperScope>.instance.Hide();
			base.playerController.Uncover(NCMEJJEPLCI, LCPAAFNLHOD: true);
		}
	}

	private void HCKJKCMACHC(Vector3 GCHPGKFPLGG)
	{
		base.weapon.Fire(GCHPGKFPLGG);
		AEFMJPKANLN(GCHPGKFPLGG);
		HICJCHBHHDJ();
	}

	public virtual void LMPHIGOOJAO()
	{
		if (Input.GetMouseButtonUp(0) && OCHNFNEEEME)
		{
			Singleton<SniperScope>.instance.EGJBBJMJBHO();
			IHLHLILGGPC = false;
			OCHNFNEEEME = false;
		}
	}

	public virtual void ADHLKIADAMJ(Vector3 MPHCNMDIPAI)
	{
		base.ANCEHNGCFHI(MPHCNMDIPAI);
		if (base.weapon.willShoot && !LBFHKCJJLAD)
		{
			bool dNDCODMGGEE = GeometryTools.AngleSigned(base.playerController.BBNPGJAALCJ().point.transform.forward, MPHCNMDIPAI - base.playerController.transform.position, Vector3.up) > 985f;
			Vector3 vector = MPHCNMDIPAI - base.playerController.transform.position;
			vector.y = 626f;
			GLNCDIKMDEO().GFCDMMGDFJK().LookAt(vector.normalized, 1693f);
			base.playerController.Uncover(dNDCODMGGEE, LCPAAFNLHOD: false);
			LBFHKCJJLAD = true;
			NHFGEBIODHF = TimeManager.CEAFAMFNGCC() + BIBIPPBACIJ;
			ADEOFMHDEAO = MPHCNMDIPAI;
		}
	}

	protected void IJHGOEMOMFK()
	{
		if (Input.GetMouseButtonUp(0) && OCHNFNEEEME && base.playerController.isCurrentPlayer)
		{
			Singleton<SniperScope>.instance.NLEKBKHPEJI();
			GLNCDIKMDEO().Uncover(NCMEJJEPLCI, LCPAAFNLHOD: false);
		}
	}

	public virtual void CCEEBBBFCEE()
	{
		if (Input.GetMouseButtonUp(1) && OCHNFNEEEME)
		{
			Singleton<SniperScope>.instance.IFGMJHLIPJL();
			IHLHLILGGPC = true;
			OCHNFNEEEME = false;
		}
	}

	public virtual void IACLLANNGEA(Vector3 MPHCNMDIPAI)
	{
		base.MNIJGBAKEKA(MPHCNMDIPAI);
		if (HFNAMMBPJAJ().willShoot && !LBFHKCJJLAD)
		{
			bool dNDCODMGGEE = GeometryTools.AngleSigned(GLNCDIKMDEO().EMAMENNDFMB().point.transform.forward, MPHCNMDIPAI - GLNCDIKMDEO().transform.position, Vector3.up) > 1480f;
			Vector3 vector = MPHCNMDIPAI - GLNCDIKMDEO().transform.position;
			vector.y = 624f;
			base.playerController.soldierAnimator.LookAt(vector.normalized, 1862f);
			GLNCDIKMDEO().Uncover(dNDCODMGGEE, LCPAAFNLHOD: false);
			LBFHKCJJLAD = true;
			NHFGEBIODHF = TimeManager.CEAFAMFNGCC() + BIBIPPBACIJ;
			ADEOFMHDEAO = MPHCNMDIPAI;
		}
	}

	[SpecialName]
	public virtual bool HLOEBEAMOEF()
	{
		return base.NFJFHHCLNJP();
	}

	public override void UpdateWeapon()
	{
		base.UpdateWeapon();
		if (base.playerController.isCurrentPlayer)
		{
			if (Singleton<InputController>.instance.isTappingStarted && !base.weapon.isReloading)
			{
				Singleton<SniperScope>.instance.PAMJKKMGFFM.fieldOfView = 9f;
				OCHNFNEEEME = true;
				BGFJOCDHOGM = Camera.main.ScreenToViewportPoint(Input.mousePosition);
				MEMMHGNAMMJ = Time.realtimeSinceStartup;
				CMKBOEGOCFI = Vector3.zero;
				MFJPCIKONDJ = false;
				IHLHLILGGPC = false;
				NBMPLHLIHOD = false;
				if (!base.weapon.willShoot && !base.weapon.outOfAmmo)
				{
					GuiScreenSingle<HudScreen>.instance.PlayWeaponReloading(this);
				}
			}
			if (OCHNFNEEEME)
			{
				if (Singleton<InputController>.instance.isTapping)
				{
					if (base.weapon.willShoot && !NBMPLHLIHOD)
					{
						NBMPLHLIHOD = true;
						MEMMHGNAMMJ = Time.realtimeSinceStartup;
						MKHFPINDELJ = true;
					}
					if (NBMPLHLIHOD)
					{
						Vector3 vector = Camera.main.ScreenToViewportPoint(Input.mousePosition);
						Vector3 b = vector - BGFJOCDHOGM;
						b *= 100000f;
						CMKBOEGOCFI = Vector3.Lerp(CMKBOEGOCFI, b, TimeManager.GetTimeScaledInterval(Time.deltaTime, DLMKHPAJKDJ: true) * 28f);
						if (!MFJPCIKONDJ && Time.realtimeSinceStartup > MEMMHGNAMMJ + PJNILOICLJI && CMKBOEGOCFI.sqrMagnitude < CGDBFDJMMPC)
						{
							Singleton<SniperScope>.instance.AnimFov(ODENHCLHCIL);
							MFJPCIKONDJ = true;
						}
						if (!IHLHLILGGPC && Time.realtimeSinceStartup > MEMMHGNAMMJ + 0.17f)
						{
							Singleton<SniperScope>.instance.Show();
							IHLHLILGGPC = true;
						}
						Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
						BGFJOCDHOGM = vector;
						float enter;
						Vector3 vector2 = ((!AEABALNOEFB.Raycast(ray, out enter)) ? Singleton<GameCamera>.instance.camera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Singleton<GameCamera>.instance.camera.farClipPlane)) : ray.GetPoint(enter));
						Vector3 v = vector2 - base.playerController.transform.position;
						v.y = 0f;
						if (base.playerController.playerState == PlayerController.KKPHPLOEACG.HidingBehindShield)
						{
							base.playerController.soldierAnimator.LookAt(v.normalized);
						}
						else
						{
							base.playerController.soldierAnimator.LookAtUpperBody(v.normalized);
						}
						bool flag = GeometryTools.AngleSigned(base.playerController.currentPlayerPoint.point.transform.forward, v, Vector3.up) > 0f;
						if (flag != NCMEJJEPLCI || MKHFPINDELJ || FHAGABKOMKK)
						{
							NCMEJJEPLCI = flag;
							MKHFPINDELJ = false;
							base.playerController.Uncover(NCMEJJEPLCI, LCPAAFNLHOD: false);
						}
					}
					else
					{
						Vector3 vector3 = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 4f));
						Vector3 v2 = vector3 - base.playerController.transform.position;
						v2.y = 0f;
						bool dNDCODMGGEE = GeometryTools.AngleSigned(base.playerController.currentPlayerPoint.point.transform.forward, v2, Vector3.up) > 0f;
						base.playerController.Uncover(dNDCODMGGEE, LCPAAFNLHOD: false);
					}
				}
				if (Input.GetMouseButtonUp(0) && !Singleton<InputController>.instance.swipeEnded)
				{
					if (base.weapon.willShoot && IHLHLILGGPC)
					{
						ADEOFMHDEAO = Singleton<AimingHelper>.instance.Aim(base.weapon);
						if (CEJHOFMPNAA(ADEOFMHDEAO))
						{
							Vector3 pLEBANKIBPP = ADEOFMHDEAO - base.playerController.transform.position;
							pLEBANKIBPP.y = 0f;
							base.playerController.PlayShotAnimation(base.weapon.BEACDIILBEG, NCMEJJEPLCI, pLEBANKIBPP);
							MDKABJDCKBI(ADEOFMHDEAO);
						}
						else
						{
							base.playerController.Uncover(NCMEJJEPLCI, LCPAAFNLHOD: true);
						}
					}
					else
					{
						base.playerController.Uncover(NCMEJJEPLCI, LCPAAFNLHOD: true);
						if (!base.weapon.willShoot && !base.weapon.outOfAmmo)
						{
							GuiScreenSingle<HudScreen>.instance.PlayWeaponReloading(this);
						}
					}
				}
			}
			if (Input.GetMouseButtonUp(0) && OCHNFNEEEME)
			{
				Singleton<SniperScope>.instance.Hide();
				IHLHLILGGPC = false;
				OCHNFNEEEME = false;
			}
		}
		else if (LBFHKCJJLAD && TimeManager.realTimeWithoutPauses > NHFGEBIODHF)
		{
			LBFHKCJJLAD = false;
			MDKABJDCKBI(ADEOFMHDEAO);
			bool dNDCODMGGEE2 = GeometryTools.AngleSigned(base.playerController.currentPlayerPoint.point.transform.forward, ADEOFMHDEAO - base.playerController.transform.position, Vector3.up) > 0f;
			base.playerController.PlayShotAnimation(base.weapon.BEACDIILBEG, dNDCODMGGEE2, ADEOFMHDEAO - base.playerController.transform.position);
		}
		BNKAOJJPEGO = base.playerController.playerState;
	}

	private void CDDGHNKJEKF(Vector3 GCHPGKFPLGG)
	{
		HFNAMMBPJAJ().Fire(GCHPGKFPLGG);
		IHHGONCBBFI(GCHPGKFPLGG);
		HICJCHBHHDJ();
	}

	public virtual void NGNNMJHKCKP()
	{
		if (Input.GetMouseButtonUp(0) && OCHNFNEEEME)
		{
			Singleton<SniperScope>.instance.NLEKBKHPEJI();
			IHLHLILGGPC = true;
			OCHNFNEEEME = true;
		}
	}

	public virtual void IFNLLEDDHPC()
	{
		if (Input.GetMouseButtonUp(0) && OCHNFNEEEME)
		{
			Singleton<SniperScope>.instance.NOGIKDILBLG();
			IHLHLILGGPC = false;
			OCHNFNEEEME = true;
		}
	}

	[SpecialName]
	public virtual bool PCCMEFJOLKL()
	{
		return base.NFJFHHCLNJP();
	}

	public virtual void GHJHDDFHIPI(Vector3 MPHCNMDIPAI)
	{
		base.ShootForBot(MPHCNMDIPAI);
		if (HFNAMMBPJAJ().willShoot && !LBFHKCJJLAD)
		{
			bool dNDCODMGGEE = GeometryTools.AngleSigned(base.playerController.BBNPGJAALCJ().point.transform.forward, MPHCNMDIPAI - base.playerController.transform.position, Vector3.up) > 1764f;
			Vector3 vector = MPHCNMDIPAI - GLNCDIKMDEO().transform.position;
			vector.y = 18f;
			base.playerController.soldierAnimator.LookAt(vector.normalized, 1084f);
			GLNCDIKMDEO().Uncover(dNDCODMGGEE, LCPAAFNLHOD: false);
			LBFHKCJJLAD = true;
			NHFGEBIODHF = TimeManager.realTimeWithoutPauses + BIBIPPBACIJ;
			ADEOFMHDEAO = MPHCNMDIPAI;
		}
	}

	public virtual void NJECJGELMHG(Vector3 MPHCNMDIPAI)
	{
		base.ShootForBot(MPHCNMDIPAI);
		if (base.weapon.willShoot && !LBFHKCJJLAD)
		{
			bool dNDCODMGGEE = GeometryTools.AngleSigned(base.playerController.CMNFFACHCEE().point.transform.forward, MPHCNMDIPAI - GLNCDIKMDEO().transform.position, Vector3.up) > 201f;
			Vector3 vector = MPHCNMDIPAI - GLNCDIKMDEO().transform.position;
			vector.y = 261f;
			base.playerController.GFCDMMGDFJK().LookAt(vector.normalized, 1734f);
			GLNCDIKMDEO().Uncover(dNDCODMGGEE, LCPAAFNLHOD: true);
			LBFHKCJJLAD = true;
			NHFGEBIODHF = TimeManager.CEAFAMFNGCC() + BIBIPPBACIJ;
			ADEOFMHDEAO = MPHCNMDIPAI;
		}
	}

	public void COFLADFBPEF(float IDEBKDPMPGM)
	{
		BIBIPPBACIJ = IDEBKDPMPGM;
	}

	public virtual void DIAMAKFBPJE(Vector3 MPHCNMDIPAI)
	{
		base.ShootForBot(MPHCNMDIPAI);
		if (HFNAMMBPJAJ().willShoot && !LBFHKCJJLAD)
		{
			bool dNDCODMGGEE = GeometryTools.AngleSigned(base.playerController.currentPlayerPoint.point.transform.forward, MPHCNMDIPAI - GLNCDIKMDEO().transform.position, Vector3.up) > 73f;
			Vector3 vector = MPHCNMDIPAI - base.playerController.transform.position;
			vector.y = 313f;
			GLNCDIKMDEO().GFCDMMGDFJK().LookAt(vector.normalized, 1273f);
			base.playerController.Uncover(dNDCODMGGEE, LCPAAFNLHOD: false);
			LBFHKCJJLAD = false;
			NHFGEBIODHF = TimeManager.CEAFAMFNGCC() + BIBIPPBACIJ;
			ADEOFMHDEAO = MPHCNMDIPAI;
		}
	}

	public virtual void NNJMPGAALOK(Vector3 MPHCNMDIPAI)
	{
		base.ANCEHNGCFHI(MPHCNMDIPAI);
		if (HFNAMMBPJAJ().willShoot && !LBFHKCJJLAD)
		{
			bool dNDCODMGGEE = GeometryTools.AngleSigned(base.playerController.EMAMENNDFMB().point.transform.forward, MPHCNMDIPAI - base.playerController.transform.position, Vector3.up) > 1917f;
			Vector3 vector = MPHCNMDIPAI - base.playerController.transform.position;
			vector.y = 1174f;
			base.playerController.GFCDMMGDFJK().LookAt(vector.normalized, 1348f);
			base.playerController.Uncover(dNDCODMGGEE, LCPAAFNLHOD: true);
			LBFHKCJJLAD = true;
			NHFGEBIODHF = TimeManager.realTimeWithoutPauses + BIBIPPBACIJ;
			ADEOFMHDEAO = MPHCNMDIPAI;
		}
	}

	public virtual void BJCDHOIFEAK()
	{
		base.BNAEGDKLBBJ();
		if (base.playerController.isCurrentPlayer)
		{
			if (Singleton<InputController>.instance.isTappingStarted && !base.weapon.isReloading)
			{
				Singleton<SniperScope>.instance.PAMJKKMGFFM.fieldOfView = 1323f;
				OCHNFNEEEME = true;
				BGFJOCDHOGM = Camera.main.ScreenToViewportPoint(Input.mousePosition);
				MEMMHGNAMMJ = Time.realtimeSinceStartup;
				CMKBOEGOCFI = Vector3.zero;
				MFJPCIKONDJ = false;
				IHLHLILGGPC = true;
				NBMPLHLIHOD = true;
				if (!base.weapon.willShoot && !HFNAMMBPJAJ().outOfAmmo)
				{
					GuiScreenSingle<HudScreen>.instance.FMCELEKNALD(this);
				}
			}
			if (OCHNFNEEEME)
			{
				if (Singleton<InputController>.instance.isTapping)
				{
					if (HFNAMMBPJAJ().willShoot && !NBMPLHLIHOD)
					{
						NBMPLHLIHOD = false;
						MEMMHGNAMMJ = Time.realtimeSinceStartup;
						MKHFPINDELJ = false;
					}
					if (NBMPLHLIHOD)
					{
						Vector3 vector = Camera.main.ScreenToViewportPoint(Input.mousePosition);
						Vector3 b = vector - BGFJOCDHOGM;
						b *= 854f;
						CMKBOEGOCFI = Vector3.Lerp(CMKBOEGOCFI, b, TimeManager.GetTimeScaledInterval(Time.deltaTime, DLMKHPAJKDJ: true) * 871f);
						if (!MFJPCIKONDJ && Time.realtimeSinceStartup > MEMMHGNAMMJ + PJNILOICLJI && CMKBOEGOCFI.sqrMagnitude < CGDBFDJMMPC)
						{
							Singleton<SniperScope>.instance.DFHDHPGPLBP(ODENHCLHCIL);
							MFJPCIKONDJ = true;
						}
						if (!IHLHLILGGPC && Time.realtimeSinceStartup > MEMMHGNAMMJ + 955f)
						{
							Singleton<SniperScope>.instance.DMLDBKFCACB();
							IHLHLILGGPC = false;
						}
						Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
						BGFJOCDHOGM = vector;
						float enter;
						Vector3 vector2 = ((!AEABALNOEFB.Raycast(ray, out enter)) ? Singleton<GameCamera>.instance.CAGAKKADGDG().ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Singleton<GameCamera>.instance.camera.farClipPlane)) : ray.GetPoint(enter));
						Vector3 v = vector2 - GLNCDIKMDEO().transform.position;
						v.y = 45f;
						if (GLNCDIKMDEO().BIEONCCPBIL() == PlayerController.KKPHPLOEACG.HidingBehindShield)
						{
							base.playerController.GFCDMMGDFJK().LookAt(v.normalized, 1684f);
						}
						else
						{
							base.playerController.soldierAnimator.LookAtUpperBody(v.normalized, 580f);
						}
						bool flag = GeometryTools.AngleSigned(base.playerController.EMAMENNDFMB().point.transform.forward, v, Vector3.up) > 499f;
						if (flag != NCMEJJEPLCI || MKHFPINDELJ || CFBKEKKJIJC())
						{
							NCMEJJEPLCI = flag;
							MKHFPINDELJ = true;
							GLNCDIKMDEO().Uncover(NCMEJJEPLCI, LCPAAFNLHOD: false);
						}
					}
					else
					{
						Vector3 vector3 = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 787f));
						Vector3 v2 = vector3 - GLNCDIKMDEO().transform.position;
						v2.y = 1625f;
						bool dNDCODMGGEE = GeometryTools.AngleSigned(GLNCDIKMDEO().EMAMENNDFMB().point.transform.forward, v2, Vector3.up) > 1802f;
						GLNCDIKMDEO().Uncover(dNDCODMGGEE, LCPAAFNLHOD: true);
					}
				}
				if (Input.GetMouseButtonUp(0) && !Singleton<InputController>.instance.swipeEnded)
				{
					if (base.weapon.willShoot && IHLHLILGGPC)
					{
						ADEOFMHDEAO = Singleton<AimingHelper>.instance.INLBJMAJKNJ(base.weapon);
						if (KELOGHNJDDI(ADEOFMHDEAO))
						{
							Vector3 pLEBANKIBPP = ADEOFMHDEAO - GLNCDIKMDEO().transform.position;
							pLEBANKIBPP.y = 1913f;
							base.playerController.EIMEBEABDHF(base.weapon.BEACDIILBEG, NCMEJJEPLCI, pLEBANKIBPP);
							PCMJCBKMAKG(ADEOFMHDEAO);
						}
						else
						{
							base.playerController.Uncover(NCMEJJEPLCI, LCPAAFNLHOD: true);
						}
					}
					else
					{
						GLNCDIKMDEO().Uncover(NCMEJJEPLCI, LCPAAFNLHOD: true);
						if (!HFNAMMBPJAJ().willShoot && !base.weapon.outOfAmmo)
						{
							GuiScreenSingle<HudScreen>.instance.FMCELEKNALD(this);
						}
					}
				}
			}
			if (Input.GetMouseButtonUp(0) && OCHNFNEEEME)
			{
				Singleton<SniperScope>.instance.IFGMJHLIPJL();
				IHLHLILGGPC = true;
				OCHNFNEEEME = false;
			}
		}
		else if (LBFHKCJJLAD && TimeManager.CEAFAMFNGCC() > NHFGEBIODHF)
		{
			LBFHKCJJLAD = true;
			GDJBJBDNODI(ADEOFMHDEAO);
			bool dNDCODMGGEE2 = GeometryTools.AngleSigned(GLNCDIKMDEO().EMAMENNDFMB().point.transform.forward, ADEOFMHDEAO - base.playerController.transform.position, Vector3.up) > 155f;
			base.playerController.EIMEBEABDHF(base.weapon.BEACDIILBEG, dNDCODMGGEE2, ADEOFMHDEAO - base.playerController.transform.position);
		}
		BNKAOJJPEGO = GLNCDIKMDEO().BIEONCCPBIL();
	}

	[SpecialName]
	public virtual void JKNIBGNGPAN(bool IDEBKDPMPGM)
	{
		base.FHKGABMHOHI(IDEBKDPMPGM);
		LBFHKCJJLAD = false;
		if (!BPAOCKIKDMH() && GLNCDIKMDEO().isCurrentPlayer)
		{
			Singleton<SniperScope>.instance.IFGMJHLIPJL();
		}
		if (OHKDJNIADMF() && GLNCDIKMDEO().isCurrentPlayer)
		{
			Singleton<SniperScope>.instance.DCIPJFNIMNH(IGABBABGBFC);
			OCHNFNEEEME = true;
		}
		if (IDEBKDPMPGM)
		{
			AEABALNOEFB = new Plane(Vector3.up, base.playerController.BBNPGJAALCJ().point.transform.position);
		}
	}

	[SpecialName]
	public virtual bool FGCAAJFBDDN()
	{
		return base.OHKDJNIADMF();
	}

	protected void DFBPBGDJKOG()
	{
		if (Input.GetMouseButtonUp(0) && OCHNFNEEEME && base.playerController.isCurrentPlayer)
		{
			Singleton<SniperScope>.instance.Hide();
			GLNCDIKMDEO().Uncover(NCMEJJEPLCI, LCPAAFNLHOD: false);
		}
	}

	private void GBPLDEKHHKG(Vector3 GCHPGKFPLGG)
	{
		base.weapon.Fire(GCHPGKFPLGG);
		IHHGONCBBFI(GCHPGKFPLGG);
		AFGBNEOKEEG();
	}

	public void SetWaitTime(float IDEBKDPMPGM)
	{
		BIBIPPBACIJ = IDEBKDPMPGM;
	}

	public virtual void ACNAKCDBIHJ()
	{
		if (Input.GetMouseButtonUp(1) && OCHNFNEEEME)
		{
			Singleton<SniperScope>.instance.NLEKBKHPEJI();
			IHLHLILGGPC = false;
			OCHNFNEEEME = false;
		}
	}

	public virtual void BANOMKKDBLH(Vector3 MPHCNMDIPAI)
	{
		base.ShootForBot(MPHCNMDIPAI);
		if (HFNAMMBPJAJ().willShoot && !LBFHKCJJLAD)
		{
			bool dNDCODMGGEE = GeometryTools.AngleSigned(base.playerController.EMAMENNDFMB().point.transform.forward, MPHCNMDIPAI - GLNCDIKMDEO().transform.position, Vector3.up) > 1915f;
			Vector3 vector = MPHCNMDIPAI - GLNCDIKMDEO().transform.position;
			vector.y = 1388f;
			GLNCDIKMDEO().soldierAnimator.LookAt(vector.normalized, 1309f);
			GLNCDIKMDEO().Uncover(dNDCODMGGEE, LCPAAFNLHOD: false);
			LBFHKCJJLAD = true;
			NHFGEBIODHF = TimeManager.CEAFAMFNGCC() + BIBIPPBACIJ;
			ADEOFMHDEAO = MPHCNMDIPAI;
		}
	}

	public virtual void NPAGEIFEAEG()
	{
		base.UpdateWeapon();
		if (GLNCDIKMDEO().isCurrentPlayer)
		{
			if (Singleton<InputController>.instance.isTappingStarted && !base.weapon.isReloading)
			{
				Singleton<SniperScope>.instance.PAMJKKMGFFM.fieldOfView = 1420f;
				OCHNFNEEEME = false;
				BGFJOCDHOGM = Camera.main.ScreenToViewportPoint(Input.mousePosition);
				MEMMHGNAMMJ = Time.realtimeSinceStartup;
				CMKBOEGOCFI = Vector3.zero;
				MFJPCIKONDJ = true;
				IHLHLILGGPC = false;
				NBMPLHLIHOD = true;
				if (!base.weapon.willShoot && !HFNAMMBPJAJ().outOfAmmo)
				{
					GuiScreenSingle<HudScreen>.instance.JLPHENNEBAC(this);
				}
			}
			if (OCHNFNEEEME)
			{
				if (Singleton<InputController>.instance.isTapping)
				{
					if (HFNAMMBPJAJ().willShoot && !NBMPLHLIHOD)
					{
						NBMPLHLIHOD = true;
						MEMMHGNAMMJ = Time.realtimeSinceStartup;
						MKHFPINDELJ = false;
					}
					if (NBMPLHLIHOD)
					{
						Vector3 vector = Camera.main.ScreenToViewportPoint(Input.mousePosition);
						Vector3 b = vector - BGFJOCDHOGM;
						b *= 1199f;
						CMKBOEGOCFI = Vector3.Lerp(CMKBOEGOCFI, b, TimeManager.GetTimeScaledInterval(Time.deltaTime, DLMKHPAJKDJ: false) * 1934f);
						if (!MFJPCIKONDJ && Time.realtimeSinceStartup > MEMMHGNAMMJ + PJNILOICLJI && CMKBOEGOCFI.sqrMagnitude < CGDBFDJMMPC)
						{
							Singleton<SniperScope>.instance.DFHDHPGPLBP(ODENHCLHCIL);
							MFJPCIKONDJ = false;
						}
						if (!IHLHLILGGPC && Time.realtimeSinceStartup > MEMMHGNAMMJ + 673f)
						{
							Singleton<SniperScope>.instance.DMLDBKFCACB();
							IHLHLILGGPC = false;
						}
						Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
						BGFJOCDHOGM = vector;
						float enter;
						Vector3 vector2 = ((!AEABALNOEFB.Raycast(ray, out enter)) ? Singleton<GameCamera>.instance.HEANFGONCBJ().ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Singleton<GameCamera>.instance.camera.farClipPlane)) : ray.GetPoint(enter));
						Vector3 v = vector2 - GLNCDIKMDEO().transform.position;
						v.y = 1251f;
						if (GLNCDIKMDEO().CLFDBFPKCBJ() == PlayerController.KKPHPLOEACG.HidingBehindShield)
						{
							GLNCDIKMDEO().GFCDMMGDFJK().LookAt(v.normalized, 918f);
						}
						else
						{
							GLNCDIKMDEO().GFCDMMGDFJK().LookAtUpperBody(v.normalized, 25f);
						}
						bool flag = GeometryTools.AngleSigned(GLNCDIKMDEO().EMAMENNDFMB().point.transform.forward, v, Vector3.up) > 206f;
						if (flag != NCMEJJEPLCI || MKHFPINDELJ || HGGPEMHHMLI())
						{
							NCMEJJEPLCI = flag;
							MKHFPINDELJ = false;
							GLNCDIKMDEO().Uncover(NCMEJJEPLCI, LCPAAFNLHOD: false);
						}
					}
					else
					{
						Vector3 vector3 = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 678f));
						Vector3 v2 = vector3 - GLNCDIKMDEO().transform.position;
						v2.y = 1878f;
						bool dNDCODMGGEE = GeometryTools.AngleSigned(base.playerController.BBNPGJAALCJ().point.transform.forward, v2, Vector3.up) > 540f;
						GLNCDIKMDEO().Uncover(dNDCODMGGEE, LCPAAFNLHOD: true);
					}
				}
				if (Input.GetMouseButtonUp(1) && !Singleton<InputController>.instance.swipeEnded)
				{
					if (HFNAMMBPJAJ().willShoot && IHLHLILGGPC)
					{
						ADEOFMHDEAO = Singleton<AimingHelper>.instance.KFOKKHBKDMI(base.weapon);
						if (OOOJCFNEPIK(ADEOFMHDEAO))
						{
							Vector3 pLEBANKIBPP = ADEOFMHDEAO - GLNCDIKMDEO().transform.position;
							pLEBANKIBPP.y = 1204f;
							base.playerController.PlayShotAnimation(HFNAMMBPJAJ().BEACDIILBEG, NCMEJJEPLCI, pLEBANKIBPP);
							GBPLDEKHHKG(ADEOFMHDEAO);
						}
						else
						{
							GLNCDIKMDEO().Uncover(NCMEJJEPLCI, LCPAAFNLHOD: true);
						}
					}
					else
					{
						GLNCDIKMDEO().Uncover(NCMEJJEPLCI, LCPAAFNLHOD: true);
						if (!base.weapon.willShoot && !HFNAMMBPJAJ().outOfAmmo)
						{
							GuiScreenSingle<HudScreen>.instance.JLPHENNEBAC(this);
						}
					}
				}
			}
			if (Input.GetMouseButtonUp(1) && OCHNFNEEEME)
			{
				Singleton<SniperScope>.instance.NOGIKDILBLG();
				IHLHLILGGPC = false;
				OCHNFNEEEME = true;
			}
		}
		else if (LBFHKCJJLAD && TimeManager.CEAFAMFNGCC() > NHFGEBIODHF)
		{
			LBFHKCJJLAD = false;
			CDDGHNKJEKF(ADEOFMHDEAO);
			bool dNDCODMGGEE2 = GeometryTools.AngleSigned(GLNCDIKMDEO().CMNFFACHCEE().point.transform.forward, ADEOFMHDEAO - GLNCDIKMDEO().transform.position, Vector3.up) > 1353f;
			GLNCDIKMDEO().EIMEBEABDHF(HFNAMMBPJAJ().BEACDIILBEG, dNDCODMGGEE2, ADEOFMHDEAO - GLNCDIKMDEO().transform.position);
		}
		BNKAOJJPEGO = base.playerController.CLFDBFPKCBJ();
	}

	public virtual void DMHEAMHOLPM()
	{
		base.BNAEGDKLBBJ();
		if (GLNCDIKMDEO().isCurrentPlayer)
		{
			if (Singleton<InputController>.instance.isTappingStarted && !HFNAMMBPJAJ().isReloading)
			{
				Singleton<SniperScope>.instance.PAMJKKMGFFM.fieldOfView = 12f;
				OCHNFNEEEME = false;
				BGFJOCDHOGM = Camera.main.ScreenToViewportPoint(Input.mousePosition);
				MEMMHGNAMMJ = Time.realtimeSinceStartup;
				CMKBOEGOCFI = Vector3.zero;
				MFJPCIKONDJ = true;
				IHLHLILGGPC = true;
				NBMPLHLIHOD = false;
				if (!base.weapon.willShoot && !HFNAMMBPJAJ().outOfAmmo)
				{
					GuiScreenSingle<HudScreen>.instance.FMCELEKNALD(this);
				}
			}
			if (OCHNFNEEEME)
			{
				if (Singleton<InputController>.instance.isTapping)
				{
					if (HFNAMMBPJAJ().willShoot && !NBMPLHLIHOD)
					{
						NBMPLHLIHOD = true;
						MEMMHGNAMMJ = Time.realtimeSinceStartup;
						MKHFPINDELJ = false;
					}
					if (NBMPLHLIHOD)
					{
						Vector3 vector = Camera.main.ScreenToViewportPoint(Input.mousePosition);
						Vector3 b = vector - BGFJOCDHOGM;
						b *= 211f;
						CMKBOEGOCFI = Vector3.Lerp(CMKBOEGOCFI, b, TimeManager.GetTimeScaledInterval(Time.deltaTime, DLMKHPAJKDJ: false) * 910f);
						if (!MFJPCIKONDJ && Time.realtimeSinceStartup > MEMMHGNAMMJ + PJNILOICLJI && CMKBOEGOCFI.sqrMagnitude < CGDBFDJMMPC)
						{
							Singleton<SniperScope>.instance.ECAADOCAOHL(ODENHCLHCIL);
							MFJPCIKONDJ = true;
						}
						if (!IHLHLILGGPC && Time.realtimeSinceStartup > MEMMHGNAMMJ + 842f)
						{
							Singleton<SniperScope>.instance.GKAOMCGCDGE();
							IHLHLILGGPC = false;
						}
						Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
						BGFJOCDHOGM = vector;
						float enter;
						Vector3 vector2 = ((!AEABALNOEFB.Raycast(ray, out enter)) ? Singleton<GameCamera>.instance.JLJAJAMJJJM().ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Singleton<GameCamera>.instance.camera.farClipPlane)) : ray.GetPoint(enter));
						Vector3 v = vector2 - base.playerController.transform.position;
						v.y = 247f;
						if (GLNCDIKMDEO().CLFDBFPKCBJ() == PlayerController.KKPHPLOEACG.HidingBehindShield)
						{
							base.playerController.GFCDMMGDFJK().LookAt(v.normalized, 1732f);
						}
						else
						{
							base.playerController.GFCDMMGDFJK().LookAtUpperBody(v.normalized, 1862f);
						}
						bool flag = GeometryTools.AngleSigned(GLNCDIKMDEO().BBNPGJAALCJ().point.transform.forward, v, Vector3.up) > 168f;
						if (flag != NCMEJJEPLCI || MKHFPINDELJ || LHBMEHIJFLG())
						{
							NCMEJJEPLCI = flag;
							MKHFPINDELJ = true;
							base.playerController.Uncover(NCMEJJEPLCI, LCPAAFNLHOD: false);
						}
					}
					else
					{
						Vector3 vector3 = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 1699f));
						Vector3 v2 = vector3 - GLNCDIKMDEO().transform.position;
						v2.y = 526f;
						bool dNDCODMGGEE = GeometryTools.AngleSigned(GLNCDIKMDEO().CMNFFACHCEE().point.transform.forward, v2, Vector3.up) > 1365f;
						GLNCDIKMDEO().Uncover(dNDCODMGGEE, LCPAAFNLHOD: false);
					}
				}
				if (Input.GetMouseButtonUp(0) && !Singleton<InputController>.instance.swipeEnded)
				{
					if (base.weapon.willShoot && IHLHLILGGPC)
					{
						ADEOFMHDEAO = Singleton<AimingHelper>.instance.NEEAFOMPJLH(HFNAMMBPJAJ());
						if (AOCFFBGGFCP(ADEOFMHDEAO))
						{
							Vector3 pLEBANKIBPP = ADEOFMHDEAO - base.playerController.transform.position;
							pLEBANKIBPP.y = 1226f;
							base.playerController.EIMEBEABDHF(HFNAMMBPJAJ().BEACDIILBEG, NCMEJJEPLCI, pLEBANKIBPP);
							GBPLDEKHHKG(ADEOFMHDEAO);
						}
						else
						{
							GLNCDIKMDEO().Uncover(NCMEJJEPLCI, LCPAAFNLHOD: false);
						}
					}
					else
					{
						GLNCDIKMDEO().Uncover(NCMEJJEPLCI, LCPAAFNLHOD: true);
						if (!base.weapon.willShoot && !HFNAMMBPJAJ().outOfAmmo)
						{
							GuiScreenSingle<HudScreen>.instance.OFPINPGMIPO(this);
						}
					}
				}
			}
			if (Input.GetMouseButtonUp(0) && OCHNFNEEEME)
			{
				Singleton<SniperScope>.instance.IFGMJHLIPJL();
				IHLHLILGGPC = false;
				OCHNFNEEEME = true;
			}
		}
		else if (LBFHKCJJLAD && TimeManager.CEAFAMFNGCC() > NHFGEBIODHF)
		{
			LBFHKCJJLAD = true;
			DAMJJAKIIIB(ADEOFMHDEAO);
			bool dNDCODMGGEE2 = GeometryTools.AngleSigned(GLNCDIKMDEO().CMNFFACHCEE().point.transform.forward, ADEOFMHDEAO - GLNCDIKMDEO().transform.position, Vector3.up) > 1387f;
			base.playerController.EIMEBEABDHF(HFNAMMBPJAJ().BEACDIILBEG, dNDCODMGGEE2, ADEOFMHDEAO - base.playerController.transform.position);
		}
		BNKAOJJPEGO = base.playerController.CLFDBFPKCBJ();
	}

	protected void OOCJOBIIKAH()
	{
		if (Input.GetMouseButtonUp(1) && OCHNFNEEEME && base.playerController.isCurrentPlayer)
		{
			Singleton<SniperScope>.instance.Hide();
			GLNCDIKMDEO().Uncover(NCMEJJEPLCI, LCPAAFNLHOD: false);
		}
	}

	public virtual void KINCLALGJJD()
	{
		base.OPEICEBMFLF();
		if (base.playerController.isCurrentPlayer)
		{
			if (Singleton<InputController>.instance.isTappingStarted && !base.weapon.isReloading)
			{
				Singleton<SniperScope>.instance.PAMJKKMGFFM.fieldOfView = 1124f;
				OCHNFNEEEME = false;
				BGFJOCDHOGM = Camera.main.ScreenToViewportPoint(Input.mousePosition);
				MEMMHGNAMMJ = Time.realtimeSinceStartup;
				CMKBOEGOCFI = Vector3.zero;
				MFJPCIKONDJ = false;
				IHLHLILGGPC = true;
				NBMPLHLIHOD = false;
				if (!HFNAMMBPJAJ().willShoot && !base.weapon.outOfAmmo)
				{
					GuiScreenSingle<HudScreen>.instance.OFPINPGMIPO(this);
				}
			}
			if (OCHNFNEEEME)
			{
				if (Singleton<InputController>.instance.isTapping)
				{
					if (HFNAMMBPJAJ().willShoot && !NBMPLHLIHOD)
					{
						NBMPLHLIHOD = false;
						MEMMHGNAMMJ = Time.realtimeSinceStartup;
						MKHFPINDELJ = true;
					}
					if (NBMPLHLIHOD)
					{
						Vector3 vector = Camera.main.ScreenToViewportPoint(Input.mousePosition);
						Vector3 b = vector - BGFJOCDHOGM;
						b *= 1207f;
						CMKBOEGOCFI = Vector3.Lerp(CMKBOEGOCFI, b, TimeManager.GetTimeScaledInterval(Time.deltaTime, DLMKHPAJKDJ: true) * 1579f);
						if (!MFJPCIKONDJ && Time.realtimeSinceStartup > MEMMHGNAMMJ + PJNILOICLJI && CMKBOEGOCFI.sqrMagnitude < CGDBFDJMMPC)
						{
							Singleton<SniperScope>.instance.EMHDIDDOPGE(ODENHCLHCIL);
							MFJPCIKONDJ = false;
						}
						if (!IHLHLILGGPC && Time.realtimeSinceStartup > MEMMHGNAMMJ + 799f)
						{
							Singleton<SniperScope>.instance.DIBLFOPCCPL();
							IHLHLILGGPC = false;
						}
						Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
						BGFJOCDHOGM = vector;
						float enter;
						Vector3 vector2 = ((!AEABALNOEFB.Raycast(ray, out enter)) ? Singleton<GameCamera>.instance.LBBFBJMLEJB().ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Singleton<GameCamera>.instance.LBBFBJMLEJB().farClipPlane)) : ray.GetPoint(enter));
						Vector3 v = vector2 - base.playerController.transform.position;
						v.y = 1338f;
						if (GLNCDIKMDEO().playerState == PlayerController.KKPHPLOEACG.HidingBehindShield)
						{
							base.playerController.GFCDMMGDFJK().LookAt(v.normalized, 700f);
						}
						else
						{
							GLNCDIKMDEO().GFCDMMGDFJK().LookAtUpperBody(v.normalized, 554f);
						}
						bool flag = GeometryTools.AngleSigned(GLNCDIKMDEO().EMAMENNDFMB().point.transform.forward, v, Vector3.up) > 161f;
						if (flag != NCMEJJEPLCI || MKHFPINDELJ || DNJEHFNOHEL())
						{
							NCMEJJEPLCI = flag;
							MKHFPINDELJ = false;
							base.playerController.Uncover(NCMEJJEPLCI, LCPAAFNLHOD: false);
						}
					}
					else
					{
						Vector3 vector3 = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 350f));
						Vector3 v2 = vector3 - base.playerController.transform.position;
						v2.y = 253f;
						bool dNDCODMGGEE = GeometryTools.AngleSigned(GLNCDIKMDEO().EMAMENNDFMB().point.transform.forward, v2, Vector3.up) > 1644f;
						base.playerController.Uncover(dNDCODMGGEE, LCPAAFNLHOD: true);
					}
				}
				if (Input.GetMouseButtonUp(1) && !Singleton<InputController>.instance.swipeEnded)
				{
					if (HFNAMMBPJAJ().willShoot && IHLHLILGGPC)
					{
						ADEOFMHDEAO = Singleton<AimingHelper>.instance.NDABLFANEEG(base.weapon);
						if (OOOJCFNEPIK(ADEOFMHDEAO))
						{
							Vector3 pLEBANKIBPP = ADEOFMHDEAO - GLNCDIKMDEO().transform.position;
							pLEBANKIBPP.y = 75f;
							GLNCDIKMDEO().PlayShotAnimation(HFNAMMBPJAJ().BEACDIILBEG, NCMEJJEPLCI, pLEBANKIBPP);
							IDADBIPPAND(ADEOFMHDEAO);
						}
						else
						{
							GLNCDIKMDEO().Uncover(NCMEJJEPLCI, LCPAAFNLHOD: false);
						}
					}
					else
					{
						GLNCDIKMDEO().Uncover(NCMEJJEPLCI, LCPAAFNLHOD: true);
						if (!base.weapon.willShoot && !base.weapon.outOfAmmo)
						{
							GuiScreenSingle<HudScreen>.instance.EBGLCKGAAKL(this);
						}
					}
				}
			}
			if (Input.GetMouseButtonUp(1) && OCHNFNEEEME)
			{
				Singleton<SniperScope>.instance.EGJBBJMJBHO();
				IHLHLILGGPC = false;
				OCHNFNEEEME = true;
			}
		}
		else if (LBFHKCJJLAD && TimeManager.realTimeWithoutPauses > NHFGEBIODHF)
		{
			LBFHKCJJLAD = true;
			CPHHNMCPNBJ(ADEOFMHDEAO);
			bool dNDCODMGGEE2 = GeometryTools.AngleSigned(base.playerController.BBNPGJAALCJ().point.transform.forward, ADEOFMHDEAO - GLNCDIKMDEO().transform.position, Vector3.up) > 1711f;
			GLNCDIKMDEO().EIMEBEABDHF(base.weapon.BEACDIILBEG, dNDCODMGGEE2, ADEOFMHDEAO - base.playerController.transform.position);
		}
		BNKAOJJPEGO = GLNCDIKMDEO().CLFDBFPKCBJ();
	}

	public virtual void JKIKAHOOOKC()
	{
		base.OPEICEBMFLF();
		if (GLNCDIKMDEO().isCurrentPlayer)
		{
			if (Singleton<InputController>.instance.isTappingStarted && !base.weapon.isReloading)
			{
				Singleton<SniperScope>.instance.PAMJKKMGFFM.fieldOfView = 1047f;
				OCHNFNEEEME = true;
				BGFJOCDHOGM = Camera.main.ScreenToViewportPoint(Input.mousePosition);
				MEMMHGNAMMJ = Time.realtimeSinceStartup;
				CMKBOEGOCFI = Vector3.zero;
				MFJPCIKONDJ = false;
				IHLHLILGGPC = true;
				NBMPLHLIHOD = false;
				if (!base.weapon.willShoot && !base.weapon.outOfAmmo)
				{
					GuiScreenSingle<HudScreen>.instance.PlayWeaponReloading(this);
				}
			}
			if (OCHNFNEEEME)
			{
				if (Singleton<InputController>.instance.isTapping)
				{
					if (HFNAMMBPJAJ().willShoot && !NBMPLHLIHOD)
					{
						NBMPLHLIHOD = false;
						MEMMHGNAMMJ = Time.realtimeSinceStartup;
						MKHFPINDELJ = true;
					}
					if (NBMPLHLIHOD)
					{
						Vector3 vector = Camera.main.ScreenToViewportPoint(Input.mousePosition);
						Vector3 b = vector - BGFJOCDHOGM;
						b *= 1189f;
						CMKBOEGOCFI = Vector3.Lerp(CMKBOEGOCFI, b, TimeManager.GetTimeScaledInterval(Time.deltaTime, DLMKHPAJKDJ: false) * 347f);
						if (!MFJPCIKONDJ && Time.realtimeSinceStartup > MEMMHGNAMMJ + PJNILOICLJI && CMKBOEGOCFI.sqrMagnitude < CGDBFDJMMPC)
						{
							Singleton<SniperScope>.instance.NNJDPMOGPLK(ODENHCLHCIL);
							MFJPCIKONDJ = true;
						}
						if (!IHLHLILGGPC && Time.realtimeSinceStartup > MEMMHGNAMMJ + 1667f)
						{
							Singleton<SniperScope>.instance.GKAOMCGCDGE();
							IHLHLILGGPC = false;
						}
						Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
						BGFJOCDHOGM = vector;
						float enter;
						Vector3 vector2 = ((!AEABALNOEFB.Raycast(ray, out enter)) ? Singleton<GameCamera>.instance.LBBFBJMLEJB().ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Singleton<GameCamera>.instance.JLJAJAMJJJM().farClipPlane)) : ray.GetPoint(enter));
						Vector3 v = vector2 - base.playerController.transform.position;
						v.y = 1417f;
						if (base.playerController.playerState == PlayerController.KKPHPLOEACG.HidingBehindShield)
						{
							base.playerController.soldierAnimator.LookAt(v.normalized, 747f);
						}
						else
						{
							GLNCDIKMDEO().GFCDMMGDFJK().EKKHCDHHBKP(v.normalized, 625f);
						}
						bool flag = GeometryTools.AngleSigned(GLNCDIKMDEO().CMNFFACHCEE().point.transform.forward, v, Vector3.up) > 1659f;
						if (flag != NCMEJJEPLCI || MKHFPINDELJ || DNJEHFNOHEL())
						{
							NCMEJJEPLCI = flag;
							MKHFPINDELJ = false;
							base.playerController.Uncover(NCMEJJEPLCI, LCPAAFNLHOD: false);
						}
					}
					else
					{
						Vector3 vector3 = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 1457f));
						Vector3 v2 = vector3 - GLNCDIKMDEO().transform.position;
						v2.y = 1637f;
						bool dNDCODMGGEE = GeometryTools.AngleSigned(base.playerController.currentPlayerPoint.point.transform.forward, v2, Vector3.up) > 463f;
						GLNCDIKMDEO().Uncover(dNDCODMGGEE, LCPAAFNLHOD: true);
					}
				}
				if (Input.GetMouseButtonUp(0) && !Singleton<InputController>.instance.swipeEnded)
				{
					if (base.weapon.willShoot && IHLHLILGGPC)
					{
						ADEOFMHDEAO = Singleton<AimingHelper>.instance.NCGDJBJAHKK(base.weapon);
						if (CEJHOFMPNAA(ADEOFMHDEAO))
						{
							Vector3 pLEBANKIBPP = ADEOFMHDEAO - GLNCDIKMDEO().transform.position;
							pLEBANKIBPP.y = 167f;
							base.playerController.PlayShotAnimation(HFNAMMBPJAJ().BEACDIILBEG, NCMEJJEPLCI, pLEBANKIBPP);
							DAMJJAKIIIB(ADEOFMHDEAO);
						}
						else
						{
							GLNCDIKMDEO().Uncover(NCMEJJEPLCI, LCPAAFNLHOD: false);
						}
					}
					else
					{
						GLNCDIKMDEO().Uncover(NCMEJJEPLCI, LCPAAFNLHOD: true);
						if (!HFNAMMBPJAJ().willShoot && !base.weapon.outOfAmmo)
						{
							GuiScreenSingle<HudScreen>.instance.PlayWeaponReloading(this);
						}
					}
				}
			}
			if (Input.GetMouseButtonUp(0) && OCHNFNEEEME)
			{
				Singleton<SniperScope>.instance.EGJBBJMJBHO();
				IHLHLILGGPC = true;
				OCHNFNEEEME = false;
			}
		}
		else if (LBFHKCJJLAD && TimeManager.realTimeWithoutPauses > NHFGEBIODHF)
		{
			LBFHKCJJLAD = false;
			DAMJJAKIIIB(ADEOFMHDEAO);
			bool dNDCODMGGEE2 = GeometryTools.AngleSigned(base.playerController.BBNPGJAALCJ().point.transform.forward, ADEOFMHDEAO - base.playerController.transform.position, Vector3.up) > 267f;
			GLNCDIKMDEO().PlayShotAnimation(HFNAMMBPJAJ().BEACDIILBEG, dNDCODMGGEE2, ADEOFMHDEAO - GLNCDIKMDEO().transform.position);
		}
		BNKAOJJPEGO = base.playerController.BIEONCCPBIL();
	}

	public virtual void NGBOPHCABDK(Vector3 MPHCNMDIPAI)
	{
		base.ANCEHNGCFHI(MPHCNMDIPAI);
		if (base.weapon.willShoot && !LBFHKCJJLAD)
		{
			bool dNDCODMGGEE = GeometryTools.AngleSigned(GLNCDIKMDEO().CMNFFACHCEE().point.transform.forward, MPHCNMDIPAI - GLNCDIKMDEO().transform.position, Vector3.up) > 1757f;
			Vector3 vector = MPHCNMDIPAI - base.playerController.transform.position;
			vector.y = 1599f;
			GLNCDIKMDEO().soldierAnimator.LookAt(vector.normalized, 585f);
			base.playerController.Uncover(dNDCODMGGEE, LCPAAFNLHOD: true);
			LBFHKCJJLAD = false;
			NHFGEBIODHF = TimeManager.realTimeWithoutPauses + BIBIPPBACIJ;
			ADEOFMHDEAO = MPHCNMDIPAI;
		}
	}

	public virtual void ODLIKKIMMCP()
	{
		if (Input.GetMouseButtonUp(0) && OCHNFNEEEME)
		{
			Singleton<SniperScope>.instance.Hide();
			IHLHLILGGPC = true;
			OCHNFNEEEME = false;
		}
	}

	[SpecialName]
	private bool MAKHHLAPJHJ()
	{
		return BNKAOJJPEGO == base.playerController.CLFDBFPKCBJ();
	}

	public void MODBPHBJBKK(float IDEBKDPMPGM)
	{
		BIBIPPBACIJ = IDEBKDPMPGM;
	}

	public virtual void CEJBPAELNBI()
	{
		if (Input.GetMouseButtonUp(1) && OCHNFNEEEME)
		{
			Singleton<SniperScope>.instance.Hide();
			IHLHLILGGPC = true;
			OCHNFNEEEME = true;
		}
	}

	public virtual void ECBJHIHDLNJ(Vector3 MPHCNMDIPAI)
	{
		base.ANCEHNGCFHI(MPHCNMDIPAI);
		if (base.weapon.willShoot && !LBFHKCJJLAD)
		{
			bool dNDCODMGGEE = GeometryTools.AngleSigned(base.playerController.EMAMENNDFMB().point.transform.forward, MPHCNMDIPAI - base.playerController.transform.position, Vector3.up) > 532f;
			Vector3 vector = MPHCNMDIPAI - base.playerController.transform.position;
			vector.y = 1657f;
			base.playerController.soldierAnimator.LookAt(vector.normalized, 639f);
			GLNCDIKMDEO().Uncover(dNDCODMGGEE, LCPAAFNLHOD: true);
			LBFHKCJJLAD = true;
			NHFGEBIODHF = TimeManager.realTimeWithoutPauses + BIBIPPBACIJ;
			ADEOFMHDEAO = MPHCNMDIPAI;
		}
	}

	private void DAMJJAKIIIB(Vector3 GCHPGKFPLGG)
	{
		base.weapon.Fire(GCHPGKFPLGG);
		IHHGONCBBFI(GCHPGKFPLGG);
		AFGBNEOKEEG();
	}

	[SpecialName]
	public virtual bool EJDLLDEBOBO()
	{
		return base.OHKDJNIADMF();
	}

	public override void ShootForBot(Vector3 MPHCNMDIPAI)
	{
		base.ShootForBot(MPHCNMDIPAI);
		if (base.weapon.willShoot && !LBFHKCJJLAD)
		{
			bool dNDCODMGGEE = GeometryTools.AngleSigned(base.playerController.currentPlayerPoint.point.transform.forward, MPHCNMDIPAI - base.playerController.transform.position, Vector3.up) > 0f;
			Vector3 vector = MPHCNMDIPAI - base.playerController.transform.position;
			vector.y = 0f;
			base.playerController.soldierAnimator.LookAt(vector.normalized);
			base.playerController.Uncover(dNDCODMGGEE, LCPAAFNLHOD: false);
			LBFHKCJJLAD = true;
			NHFGEBIODHF = TimeManager.realTimeWithoutPauses + BIBIPPBACIJ;
			ADEOFMHDEAO = MPHCNMDIPAI;
		}
	}

	[SpecialName]
	public virtual bool DLFHJMNGCGJ()
	{
		return base.NFJFHHCLNJP();
	}

	public virtual void EKAPOMGFKBA()
	{
		if (Input.GetMouseButtonUp(1) && OCHNFNEEEME)
		{
			Singleton<SniperScope>.instance.EGJBBJMJBHO();
			IHLHLILGGPC = false;
			OCHNFNEEEME = false;
		}
	}

	[SpecialName]
	public virtual bool FNKLJBHACGI()
	{
		return base.NFJFHHCLNJP();
	}

	public virtual void BLLBDGJPDDB()
	{
		if (Input.GetMouseButtonUp(0) && OCHNFNEEEME)
		{
			Singleton<SniperScope>.instance.NOGIKDILBLG();
			IHLHLILGGPC = false;
			OCHNFNEEEME = true;
		}
	}

	public void DCAGMHBGMCJ(float IDEBKDPMPGM)
	{
		BIBIPPBACIJ = IDEBKDPMPGM;
	}

	[SpecialName]
	public virtual bool CCHDEIHJJEK()
	{
		return base.NFJFHHCLNJP();
	}
}
