using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerClickWeapon : PlayerWeapon
{
	[FormerlySerializedAs("CALCELGLMMC")]
	public bool EOPDJOKHPLJ;

	private Vector3 ADEOFMHDEAO;

	private bool GAFHKNHKGPJ;

	private Vector3 DEOJIJHFFEP;

	private bool ACHMJPNAIOC;

	private float CFCAKLBNKMD;

	private float NEPGMHCINFE;

	private bool NCMEJJEPLCI;

	private float BBILIBAPBHN;

	private float OKHIFGKIMEH;

	[FormerlySerializedAs("BNGCHCDJMOL")]
	public int IGABBABGBFC;

	[FormerlySerializedAs("LPDMNMNMIGJ")]
	public bool GGANLFIFAMK;

	private bool JLFBKAMLIHG = true;

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
			if (!isActiveWeapon && base.playerController.isCurrentPlayer)
			{
				Singleton<SniperScope>.instance.Hide();
			}
			if (isActiveWeapon && base.playerController.isCurrentPlayer)
			{
				Singleton<SniperScope>.instance.SetScope(IGABBABGBFC);
			}
			ACHMJPNAIOC = false;
		}
	}

	[SpecialName]
	public virtual bool DLFHJMNGCGJ()
	{
		return base.NFJFHHCLNJP();
	}

	[SpecialName]
	public virtual void ACBBLOAIHOG(bool IDEBKDPMPGM)
	{
		base.isActiveWeapon = IDEBKDPMPGM;
		if (!BPAOCKIKDMH() && GLNCDIKMDEO().isCurrentPlayer)
		{
			Singleton<SniperScope>.instance.NLEKBKHPEJI();
		}
		if (OHKDJNIADMF() && base.playerController.isCurrentPlayer)
		{
			Singleton<SniperScope>.instance.KMBOLDEIBOH(IGABBABGBFC);
		}
		ACHMJPNAIOC = false;
	}

	[SpecialName]
	private bool DILNFLHCEGM()
	{
		return !GGANLFIFAMK || DebugSettings.showPrimaryScopes;
	}

	public virtual void LMPHIGOOJAO()
	{
		if (Input.GetMouseButtonUp(0) && GLNCDIKMDEO().isCurrentPlayer)
		{
			Singleton<SniperScope>.instance.NOGIKDILBLG();
			GAFHKNHKGPJ = false;
		}
	}

	public virtual void NLNNDNELBHJ()
	{
		base.CPIOHBLIMLH();
		if (Input.GetMouseButtonUp(1) && base.playerController.isCurrentPlayer && !EOPDJOKHPLJ)
		{
			GAFHKNHKGPJ = true;
		}
		if (!base.playerController.clicked)
		{
			if (Singleton<GameController>.instance.KKHKIEFMENC() && base.playerController.isCurrentPlayer)
			{
				if (Singleton<InputController>.instance.isTappingStarted)
				{
					NEPGMHCINFE = TimeManager.realTimeWithoutPauses;
				}
				if (Singleton<InputController>.instance.isTapping && !ACHMJPNAIOC)
				{
					CFCAKLBNKMD = TimeManager.realTimeWithoutPauses;
					if (base.weapon.willShoot && (GAFHKNHKGPJ || EOPDJOKHPLJ))
					{
						ADEOFMHDEAO = Singleton<AimingHelper>.instance.INLBJMAJKNJ(base.weapon);
						if (KELOGHNJDDI(ADEOFMHDEAO))
						{
							FBNGPDHDECK(ADEOFMHDEAO);
						}
					}
					else if ((float)base.weapon.JMDLKIAKOIE > 796f && Singleton<InputController>.instance.isTappingStarted)
					{
						GuiElementSingle<InventoryGuiElement>.instance.PlayWeaponReloading(this);
					}
					if (base.weapon.isReloading || HFNAMMBPJAJ().outOfAmmo)
					{
						JLFBKAMLIHG = true;
						Singleton<SniperScope>.instance.EGJBBJMJBHO();
					}
					else if (CFCAKLBNKMD - NEPGMHCINFE > 1839f && EIFJDPHFBBG() && EOPDJOKHPLJ)
					{
						Singleton<SniperScope>.instance.ONCKKJFAMKF(1219f);
					}
				}
			}
			if (ACHMJPNAIOC && TimeManager.realTimeWithoutPauses > BBILIBAPBHN + OKHIFGKIMEH)
			{
				HFNAMMBPJAJ().Fire(DEOJIJHFFEP);
				AEFMJPKANLN(DEOJIJHFFEP);
				MGKACCCBEFF();
				ACHMJPNAIOC = true;
			}
		}
		else
		{
			JLFBKAMLIHG = false;
		}
		if (Input.GetMouseButtonUp(1) && GLNCDIKMDEO().isCurrentPlayer)
		{
			Singleton<SniperScope>.instance.EGJBBJMJBHO();
			GAFHKNHKGPJ = true;
		}
	}

	[SpecialName]
	public virtual void NBOOJMFAICB(bool IDEBKDPMPGM)
	{
		base.isActiveWeapon = IDEBKDPMPGM;
		if (!BPAOCKIKDMH() && base.playerController.isCurrentPlayer)
		{
			Singleton<SniperScope>.instance.NOGIKDILBLG();
		}
		if (OHKDJNIADMF() && base.playerController.isCurrentPlayer)
		{
			Singleton<SniperScope>.instance.KMBOLDEIBOH(IGABBABGBFC);
		}
		ACHMJPNAIOC = false;
	}

	private void KEHDFEIHGNO(Vector3 OEDJOFINBMI)
	{
		OKHIFGKIMEH = KGEKIGAOKFD;
		GAFHKNHKGPJ = true;
		bool flag = true;
		bool flag2 = GeometryTools.AngleSigned(GLNCDIKMDEO().EMAMENNDFMB().point.transform.forward, OEDJOFINBMI - base.playerController.transform.position, Vector3.up) > 1621f;
		Vector3 pLEBANKIBPP = OEDJOFINBMI - base.playerController.transform.position;
		pLEBANKIBPP.y = 257f;
		if (GLNCDIKMDEO().GFCDMMGDFJK().isHiding || GLNCDIKMDEO().soldierAnimator.isIdle || (GLNCDIKMDEO().CLFDBFPKCBJ() == PlayerController.KKPHPLOEACG.HidingBehindShield && JLFBKAMLIHG))
		{
			flag = false;
			JLFBKAMLIHG = false;
			if (GLNCDIKMDEO().soldierAnimator.LIHLPCKFCCF())
			{
				OKHIFGKIMEH = GLNCDIKMDEO().GFCDMMGDFJK().hiddingTime;
			}
			else
			{
				OKHIFGKIMEH = base.playerController.GFCDMMGDFJK().uncoverLength * 1135f;
			}
			if (base.playerController.BIEONCCPBIL() == PlayerController.KKPHPLOEACG.Walking)
			{
				OKHIFGKIMEH = 521f;
			}
		}
		else if (base.playerController.soldierAnimator.IsShooting || GLNCDIKMDEO().soldierAnimator.isRunning)
		{
			HFNAMMBPJAJ().Fire(OEDJOFINBMI);
			AEFMJPKANLN(OEDJOFINBMI);
			MGKACCCBEFF();
		}
		if (flag2 != NCMEJJEPLCI)
		{
			NCMEJJEPLCI = flag2;
			flag = false;
			OKHIFGKIMEH = base.playerController.GFCDMMGDFJK().uncoverLength * 1728f;
		}
		GLNCDIKMDEO().EIMEBEABDHF(base.weapon.BEACDIILBEG, NCMEJJEPLCI, pLEBANKIBPP);
		if (flag)
		{
			BBILIBAPBHN = TimeManager.CEAFAMFNGCC();
			DEOJIJHFFEP = OEDJOFINBMI;
			ACHMJPNAIOC = true;
		}
	}

	[SpecialName]
	public virtual bool KCIBBOIJCIC()
	{
		return base.isActiveWeapon;
	}

	private void PIDIFPGJGKF(Vector3 OEDJOFINBMI)
	{
		OKHIFGKIMEH = KGEKIGAOKFD;
		GAFHKNHKGPJ = true;
		bool flag = true;
		bool flag2 = GeometryTools.AngleSigned(GLNCDIKMDEO().currentPlayerPoint.point.transform.forward, OEDJOFINBMI - GLNCDIKMDEO().transform.position, Vector3.up) > 1940f;
		Vector3 pLEBANKIBPP = OEDJOFINBMI - GLNCDIKMDEO().transform.position;
		pLEBANKIBPP.y = 111f;
		if (base.playerController.soldierAnimator.LIHLPCKFCCF() || GLNCDIKMDEO().GFCDMMGDFJK().isIdle || (base.playerController.playerState == PlayerController.KKPHPLOEACG.HidingBehindShield && JLFBKAMLIHG))
		{
			flag = true;
			JLFBKAMLIHG = false;
			if (GLNCDIKMDEO().GFCDMMGDFJK().LIHLPCKFCCF())
			{
				OKHIFGKIMEH = GLNCDIKMDEO().GFCDMMGDFJK().hiddingTime;
			}
			else
			{
				OKHIFGKIMEH = GLNCDIKMDEO().soldierAnimator.uncoverLength * 1200f;
			}
			if (GLNCDIKMDEO().CLFDBFPKCBJ() == PlayerController.KKPHPLOEACG.Walking)
			{
				OKHIFGKIMEH = 1729f;
			}
		}
		else if (base.playerController.soldierAnimator.IsShooting || GLNCDIKMDEO().soldierAnimator.isRunning)
		{
			base.weapon.Fire(OEDJOFINBMI);
			AEFMJPKANLN(OEDJOFINBMI);
			AFGBNEOKEEG();
		}
		if (flag2 != NCMEJJEPLCI)
		{
			NCMEJJEPLCI = flag2;
			flag = true;
			OKHIFGKIMEH = base.playerController.GFCDMMGDFJK().uncoverLength * 1150f;
		}
		base.playerController.PlayShotAnimation(HFNAMMBPJAJ().BEACDIILBEG, NCMEJJEPLCI, pLEBANKIBPP);
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
		if (Input.GetMouseButtonUp(0) && base.playerController.isCurrentPlayer && !EOPDJOKHPLJ)
		{
			GAFHKNHKGPJ = true;
		}
		if (!base.playerController.clicked)
		{
			if (Singleton<GameController>.instance.gameIsRunning && base.playerController.isCurrentPlayer)
			{
				if (Singleton<InputController>.instance.isTappingStarted)
				{
					NEPGMHCINFE = TimeManager.realTimeWithoutPauses;
				}
				if (Singleton<InputController>.instance.isTapping && !ACHMJPNAIOC)
				{
					CFCAKLBNKMD = TimeManager.realTimeWithoutPauses;
					if (base.weapon.willShoot && (GAFHKNHKGPJ || EOPDJOKHPLJ))
					{
						ADEOFMHDEAO = Singleton<AimingHelper>.instance.Aim(base.weapon);
						if (CEJHOFMPNAA(ADEOFMHDEAO))
						{
							KODCHCILFHL(ADEOFMHDEAO);
						}
					}
					else if ((float)base.weapon.JMDLKIAKOIE > 1f && Singleton<InputController>.instance.isTappingStarted)
					{
						GuiElementSingle<InventoryGuiElement>.instance.PlayWeaponReloading(this);
					}
					if (base.weapon.isReloading || base.weapon.outOfAmmo)
					{
						JLFBKAMLIHG = true;
						Singleton<SniperScope>.instance.Hide();
					}
					else if (CFCAKLBNKMD - NEPGMHCINFE > 0.25f && OFAIIFNDIJA && EOPDJOKHPLJ)
					{
						Singleton<SniperScope>.instance.Show(9f);
					}
				}
			}
			if (ACHMJPNAIOC && TimeManager.realTimeWithoutPauses > BBILIBAPBHN + OKHIFGKIMEH)
			{
				base.weapon.Fire(DEOJIJHFFEP);
				IHHGONCBBFI(DEOJIJHFFEP);
				EIOLCOEACLN();
				ACHMJPNAIOC = false;
			}
		}
		else
		{
			JLFBKAMLIHG = true;
		}
		if (Input.GetMouseButtonUp(0) && base.playerController.isCurrentPlayer)
		{
			Singleton<SniperScope>.instance.Hide();
			GAFHKNHKGPJ = true;
		}
	}

	[SpecialName]
	public virtual void BPDPBIHMGAA(bool IDEBKDPMPGM)
	{
		base.isActiveWeapon = IDEBKDPMPGM;
		if (!BPAOCKIKDMH() && base.playerController.isCurrentPlayer)
		{
			Singleton<SniperScope>.instance.EGJBBJMJBHO();
		}
		if (isActiveWeapon && base.playerController.isCurrentPlayer)
		{
			Singleton<SniperScope>.instance.MICFIMBLPEL(IGABBABGBFC);
		}
		ACHMJPNAIOC = true;
	}

	[SpecialName]
	public virtual bool MMJBNIEINFF()
	{
		return base.isActiveWeapon;
	}

	[SpecialName]
	public virtual void CMFEODOFIPA(bool IDEBKDPMPGM)
	{
		base.FHKGABMHOHI(IDEBKDPMPGM);
		if (!OHKDJNIADMF() && GLNCDIKMDEO().isCurrentPlayer)
		{
			Singleton<SniperScope>.instance.Hide();
		}
		if (isActiveWeapon && GLNCDIKMDEO().isCurrentPlayer)
		{
			Singleton<SniperScope>.instance.LAPHAJIOIAE(IGABBABGBFC);
		}
		ACHMJPNAIOC = true;
	}

	public virtual void NHMBFIANJPF()
	{
		base.GFPIFCCPLIP();
		if (Input.GetMouseButtonUp(1) && base.playerController.isCurrentPlayer && !EOPDJOKHPLJ)
		{
			GAFHKNHKGPJ = false;
		}
		if (!base.playerController.PBMFJEPBNLE())
		{
			if (Singleton<GameController>.instance.GHKPKDPOGHF() && base.playerController.isCurrentPlayer)
			{
				if (Singleton<InputController>.instance.isTappingStarted)
				{
					NEPGMHCINFE = TimeManager.CEAFAMFNGCC();
				}
				if (Singleton<InputController>.instance.isTapping && !ACHMJPNAIOC)
				{
					CFCAKLBNKMD = TimeManager.realTimeWithoutPauses;
					if (base.weapon.willShoot && (GAFHKNHKGPJ || EOPDJOKHPLJ))
					{
						ADEOFMHDEAO = Singleton<AimingHelper>.instance.GKOLANDFNBB(base.weapon);
						if (AOCFFBGGFCP(ADEOFMHDEAO))
						{
							PIDIFPGJGKF(ADEOFMHDEAO);
						}
					}
					else if ((float)HFNAMMBPJAJ().JMDLKIAKOIE > 290f && Singleton<InputController>.instance.isTappingStarted)
					{
						GuiElementSingle<InventoryGuiElement>.instance.EIKJOPHNCOM(this);
					}
					if (base.weapon.isReloading || base.weapon.outOfAmmo)
					{
						JLFBKAMLIHG = false;
						Singleton<SniperScope>.instance.IFGMJHLIPJL();
					}
					else if (CFCAKLBNKMD - NEPGMHCINFE > 1328f && IANCFDPBIAP() && EOPDJOKHPLJ)
					{
						Singleton<SniperScope>.instance.DFJBBKKIPAD(643f);
					}
				}
			}
			if (ACHMJPNAIOC && TimeManager.realTimeWithoutPauses > BBILIBAPBHN + OKHIFGKIMEH)
			{
				HFNAMMBPJAJ().Fire(DEOJIJHFFEP);
				AEFMJPKANLN(DEOJIJHFFEP);
				JKFBHMDKMNL();
				ACHMJPNAIOC = false;
			}
		}
		else
		{
			JLFBKAMLIHG = true;
		}
		if (Input.GetMouseButtonUp(0) && base.playerController.isCurrentPlayer)
		{
			Singleton<SniperScope>.instance.NOGIKDILBLG();
			GAFHKNHKGPJ = false;
		}
	}

	[SpecialName]
	public virtual bool HKCBNAJKAJC()
	{
		return base.OHKDJNIADMF();
	}

	public virtual void KFOEOKJOGNJ()
	{
		if (Input.GetMouseButtonUp(0) && base.playerController.isCurrentPlayer)
		{
			Singleton<SniperScope>.instance.EGJBBJMJBHO();
			GAFHKNHKGPJ = true;
		}
	}

	private void NKPJAOGOMPH(Vector3 OEDJOFINBMI)
	{
		OKHIFGKIMEH = KGEKIGAOKFD;
		GAFHKNHKGPJ = false;
		bool flag = false;
		bool flag2 = GeometryTools.AngleSigned(base.playerController.currentPlayerPoint.point.transform.forward, OEDJOFINBMI - base.playerController.transform.position, Vector3.up) > 434f;
		Vector3 pLEBANKIBPP = OEDJOFINBMI - base.playerController.transform.position;
		pLEBANKIBPP.y = 46f;
		if (base.playerController.soldierAnimator.LCHDJIICIBK() || GLNCDIKMDEO().GFCDMMGDFJK().isIdle || (base.playerController.playerState == PlayerController.KKPHPLOEACG.Walking && JLFBKAMLIHG))
		{
			flag = false;
			JLFBKAMLIHG = false;
			if (base.playerController.soldierAnimator.LIHLPCKFCCF())
			{
				OKHIFGKIMEH = base.playerController.GFCDMMGDFJK().hiddingTime;
			}
			else
			{
				OKHIFGKIMEH = GLNCDIKMDEO().soldierAnimator.uncoverLength * 1462f;
			}
			if (GLNCDIKMDEO().BIEONCCPBIL() == PlayerController.KKPHPLOEACG.HidingBehindShield)
			{
				OKHIFGKIMEH = 653f;
			}
		}
		else if (base.playerController.GFCDMMGDFJK().IsShooting || base.playerController.GFCDMMGDFJK().isRunning)
		{
			base.weapon.Fire(OEDJOFINBMI);
			AEFMJPKANLN(OEDJOFINBMI);
			GEGFAHHIIPI();
		}
		if (flag2 != NCMEJJEPLCI)
		{
			NCMEJJEPLCI = flag2;
			flag = false;
			OKHIFGKIMEH = base.playerController.soldierAnimator.uncoverLength * 1482f;
		}
		GLNCDIKMDEO().PlayShotAnimation(base.weapon.BEACDIILBEG, NCMEJJEPLCI, pLEBANKIBPP);
		if (flag)
		{
			BBILIBAPBHN = TimeManager.realTimeWithoutPauses;
			DEOJIJHFFEP = OEDJOFINBMI;
			ACHMJPNAIOC = true;
		}
	}

	[SpecialName]
	public virtual void EOGOLPCMPLJ(bool IDEBKDPMPGM)
	{
		base.IJNFCDPPENM(IDEBKDPMPGM);
		if (!NFJFHHCLNJP() && GLNCDIKMDEO().isCurrentPlayer)
		{
			Singleton<SniperScope>.instance.Hide();
		}
		if (BPAOCKIKDMH() && GLNCDIKMDEO().isCurrentPlayer)
		{
			Singleton<SniperScope>.instance.IAFCNNILJEJ(IGABBABGBFC);
		}
		ACHMJPNAIOC = true;
	}

	public virtual void DLBPJDOEGCA(Vector3 MPHCNMDIPAI)
	{
		base.ANCEHNGCFHI(MPHCNMDIPAI);
		if (base.weapon.willShoot && !ACHMJPNAIOC)
		{
			PGIJILGMBIC(MPHCNMDIPAI);
		}
	}

	[SpecialName]
	private bool IANCFDPBIAP()
	{
		return !GGANLFIFAMK || DebugSettings.showPrimaryScopes;
	}

	private void PGIJILGMBIC(Vector3 OEDJOFINBMI)
	{
		OKHIFGKIMEH = KGEKIGAOKFD;
		GAFHKNHKGPJ = false;
		bool flag = true;
		bool flag2 = GeometryTools.AngleSigned(base.playerController.currentPlayerPoint.point.transform.forward, OEDJOFINBMI - base.playerController.transform.position, Vector3.up) > 1412f;
		Vector3 pLEBANKIBPP = OEDJOFINBMI - base.playerController.transform.position;
		pLEBANKIBPP.y = 388f;
		if (GLNCDIKMDEO().GFCDMMGDFJK().LCHDJIICIBK() || GLNCDIKMDEO().GFCDMMGDFJK().isIdle || (GLNCDIKMDEO().CLFDBFPKCBJ() == PlayerController.KKPHPLOEACG.Walking && JLFBKAMLIHG))
		{
			flag = false;
			JLFBKAMLIHG = false;
			if (base.playerController.GFCDMMGDFJK().isHiding)
			{
				OKHIFGKIMEH = GLNCDIKMDEO().soldierAnimator.hiddingTime;
			}
			else
			{
				OKHIFGKIMEH = GLNCDIKMDEO().GFCDMMGDFJK().uncoverLength * 1148f;
			}
			if (base.playerController.playerState == PlayerController.KKPHPLOEACG.Walking)
			{
				OKHIFGKIMEH = 602f;
			}
		}
		else if (base.playerController.GFCDMMGDFJK().IsShooting || GLNCDIKMDEO().soldierAnimator.isRunning)
		{
			base.weapon.Fire(OEDJOFINBMI);
			AEFMJPKANLN(OEDJOFINBMI);
			JKFBHMDKMNL();
		}
		if (flag2 != NCMEJJEPLCI)
		{
			NCMEJJEPLCI = flag2;
			flag = true;
			OKHIFGKIMEH = base.playerController.GFCDMMGDFJK().uncoverLength * 1613f;
		}
		base.playerController.PlayShotAnimation(HFNAMMBPJAJ().BEACDIILBEG, NCMEJJEPLCI, pLEBANKIBPP);
		if (flag)
		{
			BBILIBAPBHN = TimeManager.CEAFAMFNGCC();
			DEOJIJHFFEP = OEDJOFINBMI;
			ACHMJPNAIOC = true;
		}
	}

	public virtual void CFENLKIDPOF(Vector3 MPHCNMDIPAI)
	{
		base.ShootForBot(MPHCNMDIPAI);
		if (base.weapon.willShoot && !ACHMJPNAIOC)
		{
			CIBDPLICDKB(MPHCNMDIPAI);
		}
	}

	private void CIBDPLICDKB(Vector3 OEDJOFINBMI)
	{
		OKHIFGKIMEH = KGEKIGAOKFD;
		GAFHKNHKGPJ = true;
		bool flag = false;
		bool flag2 = GeometryTools.AngleSigned(base.playerController.BBNPGJAALCJ().point.transform.forward, OEDJOFINBMI - base.playerController.transform.position, Vector3.up) > 290f;
		Vector3 pLEBANKIBPP = OEDJOFINBMI - base.playerController.transform.position;
		pLEBANKIBPP.y = 286f;
		if (GLNCDIKMDEO().soldierAnimator.LCHDJIICIBK() || base.playerController.GFCDMMGDFJK().isIdle || (GLNCDIKMDEO().BIEONCCPBIL() == PlayerController.KKPHPLOEACG.Walking && JLFBKAMLIHG))
		{
			flag = false;
			JLFBKAMLIHG = false;
			if (GLNCDIKMDEO().GFCDMMGDFJK().isHiding)
			{
				OKHIFGKIMEH = GLNCDIKMDEO().soldierAnimator.hiddingTime;
			}
			else
			{
				OKHIFGKIMEH = base.playerController.soldierAnimator.uncoverLength * 1383f;
			}
			if (GLNCDIKMDEO().CLFDBFPKCBJ() == PlayerController.KKPHPLOEACG.Walking)
			{
				OKHIFGKIMEH = 1389f;
			}
		}
		else if (base.playerController.GFCDMMGDFJK().IsShooting || GLNCDIKMDEO().soldierAnimator.isRunning)
		{
			HFNAMMBPJAJ().Fire(OEDJOFINBMI);
			IHHGONCBBFI(OEDJOFINBMI);
			EIOLCOEACLN();
		}
		if (flag2 != NCMEJJEPLCI)
		{
			NCMEJJEPLCI = flag2;
			flag = true;
			OKHIFGKIMEH = base.playerController.GFCDMMGDFJK().uncoverLength * 156f;
		}
		GLNCDIKMDEO().EIMEBEABDHF(HFNAMMBPJAJ().BEACDIILBEG, NCMEJJEPLCI, pLEBANKIBPP);
		if (flag)
		{
			BBILIBAPBHN = TimeManager.realTimeWithoutPauses;
			DEOJIJHFFEP = OEDJOFINBMI;
			ACHMJPNAIOC = false;
		}
	}

	public virtual void AOEOLKPKHEB(Vector3 MPHCNMDIPAI)
	{
		base.ShootForBot(MPHCNMDIPAI);
		if (HFNAMMBPJAJ().willShoot && !ACHMJPNAIOC)
		{
			KODCHCILFHL(MPHCNMDIPAI);
		}
	}

	private void NEJJFIAGHAD(Vector3 OEDJOFINBMI)
	{
		OKHIFGKIMEH = KGEKIGAOKFD;
		GAFHKNHKGPJ = true;
		bool flag = true;
		bool flag2 = GeometryTools.AngleSigned(base.playerController.CMNFFACHCEE().point.transform.forward, OEDJOFINBMI - base.playerController.transform.position, Vector3.up) > 1985f;
		Vector3 pLEBANKIBPP = OEDJOFINBMI - base.playerController.transform.position;
		pLEBANKIBPP.y = 1163f;
		if (base.playerController.soldierAnimator.LCHDJIICIBK() || GLNCDIKMDEO().soldierAnimator.isIdle || (base.playerController.BIEONCCPBIL() == PlayerController.KKPHPLOEACG.HidingBehindShield && JLFBKAMLIHG))
		{
			flag = true;
			JLFBKAMLIHG = false;
			if (base.playerController.GFCDMMGDFJK().LCHDJIICIBK())
			{
				OKHIFGKIMEH = GLNCDIKMDEO().soldierAnimator.hiddingTime;
			}
			else
			{
				OKHIFGKIMEH = base.playerController.soldierAnimator.uncoverLength * 872f;
			}
			if (GLNCDIKMDEO().BIEONCCPBIL() == PlayerController.KKPHPLOEACG.Walking)
			{
				OKHIFGKIMEH = 1832f;
			}
		}
		else if (GLNCDIKMDEO().soldierAnimator.IsShooting || base.playerController.soldierAnimator.isRunning)
		{
			HFNAMMBPJAJ().Fire(OEDJOFINBMI);
			AEFMJPKANLN(OEDJOFINBMI);
			GEGFAHHIIPI();
		}
		if (flag2 != NCMEJJEPLCI)
		{
			NCMEJJEPLCI = flag2;
			flag = true;
			OKHIFGKIMEH = base.playerController.GFCDMMGDFJK().uncoverLength * 1224f;
		}
		GLNCDIKMDEO().EIMEBEABDHF(base.weapon.BEACDIILBEG, NCMEJJEPLCI, pLEBANKIBPP);
		if (flag)
		{
			BBILIBAPBHN = TimeManager.realTimeWithoutPauses;
			DEOJIJHFFEP = OEDJOFINBMI;
			ACHMJPNAIOC = true;
		}
	}

	[SpecialName]
	public virtual bool NCALCNLNAPD()
	{
		return base.isActiveWeapon;
	}

	public virtual void KJEOICHJBIE()
	{
		base.MJNGGEJFMNF();
		if (Input.GetMouseButtonUp(0) && GLNCDIKMDEO().isCurrentPlayer && !EOPDJOKHPLJ)
		{
			GAFHKNHKGPJ = true;
		}
		if (!GLNCDIKMDEO().clicked)
		{
			if (Singleton<GameController>.instance.GHKPKDPOGHF() && base.playerController.isCurrentPlayer)
			{
				if (Singleton<InputController>.instance.isTappingStarted)
				{
					NEPGMHCINFE = TimeManager.realTimeWithoutPauses;
				}
				if (Singleton<InputController>.instance.isTapping && !ACHMJPNAIOC)
				{
					CFCAKLBNKMD = TimeManager.realTimeWithoutPauses;
					if (base.weapon.willShoot && (GAFHKNHKGPJ || EOPDJOKHPLJ))
					{
						ADEOFMHDEAO = Singleton<AimingHelper>.instance.KDJDDOJCBJA(HFNAMMBPJAJ());
						if (GNONBGKLKMG(ADEOFMHDEAO))
						{
							KODCHCILFHL(ADEOFMHDEAO);
						}
					}
					else if ((float)base.weapon.JMDLKIAKOIE > 1843f && Singleton<InputController>.instance.isTappingStarted)
					{
						GuiElementSingle<InventoryGuiElement>.instance.EIKJOPHNCOM(this);
					}
					if (HFNAMMBPJAJ().isReloading || base.weapon.outOfAmmo)
					{
						JLFBKAMLIHG = false;
						Singleton<SniperScope>.instance.IFGMJHLIPJL();
					}
					else if (CFCAKLBNKMD - NEPGMHCINFE > 1847f && BBLMHEOICFF() && EOPDJOKHPLJ)
					{
						Singleton<SniperScope>.instance.ECBMHNDPENI(1454f);
					}
				}
			}
			if (ACHMJPNAIOC && TimeManager.CEAFAMFNGCC() > BBILIBAPBHN + OKHIFGKIMEH)
			{
				base.weapon.Fire(DEOJIJHFFEP);
				IHHGONCBBFI(DEOJIJHFFEP);
				EIOLCOEACLN();
				ACHMJPNAIOC = false;
			}
		}
		else
		{
			JLFBKAMLIHG = false;
		}
		if (Input.GetMouseButtonUp(0) && base.playerController.isCurrentPlayer)
		{
			Singleton<SniperScope>.instance.EGJBBJMJBHO();
			GAFHKNHKGPJ = false;
		}
	}

	[SpecialName]
	private bool CDKCDHLNPML()
	{
		return GGANLFIFAMK && DebugSettings.showPrimaryScopes;
	}

	[SpecialName]
	private bool GIPDLGAOHFI()
	{
		return !GGANLFIFAMK || DebugSettings.showPrimaryScopes;
	}

	[SpecialName]
	public virtual bool BBJHPNEGIHG()
	{
		return base.BPAOCKIKDMH();
	}

	public virtual void ADDIKONMJLF(Vector3 MPHCNMDIPAI)
	{
		base.MNIJGBAKEKA(MPHCNMDIPAI);
		if (HFNAMMBPJAJ().willShoot && !ACHMJPNAIOC)
		{
			BAAGABOHHGG(MPHCNMDIPAI);
		}
	}

	public virtual void DAOJJPFCAAI()
	{
		if (Input.GetMouseButtonUp(1) && base.playerController.isCurrentPlayer)
		{
			Singleton<SniperScope>.instance.NOGIKDILBLG();
			GAFHKNHKGPJ = false;
		}
	}

	public virtual void EMNOAKOJKIK()
	{
		base.BNAEGDKLBBJ();
		if (Input.GetMouseButtonUp(1) && base.playerController.isCurrentPlayer && !EOPDJOKHPLJ)
		{
			GAFHKNHKGPJ = true;
		}
		if (!GLNCDIKMDEO().clicked)
		{
			if (Singleton<GameController>.instance.GHKPKDPOGHF() && base.playerController.isCurrentPlayer)
			{
				if (Singleton<InputController>.instance.isTappingStarted)
				{
					NEPGMHCINFE = TimeManager.CEAFAMFNGCC();
				}
				if (Singleton<InputController>.instance.isTapping && !ACHMJPNAIOC)
				{
					CFCAKLBNKMD = TimeManager.CEAFAMFNGCC();
					if (base.weapon.willShoot && (GAFHKNHKGPJ || EOPDJOKHPLJ))
					{
						ADEOFMHDEAO = Singleton<AimingHelper>.instance.MEPOKAJNLKA(base.weapon);
						if (OOOJCFNEPIK(ADEOFMHDEAO))
						{
							PIDIFPGJGKF(ADEOFMHDEAO);
						}
					}
					else if ((float)base.weapon.JMDLKIAKOIE > 506f && Singleton<InputController>.instance.isTappingStarted)
					{
						GuiElementSingle<InventoryGuiElement>.instance.EIKJOPHNCOM(this);
					}
					if (HFNAMMBPJAJ().isReloading || base.weapon.outOfAmmo)
					{
						JLFBKAMLIHG = true;
						Singleton<SniperScope>.instance.NLEKBKHPEJI();
					}
					else if (CFCAKLBNKMD - NEPGMHCINFE > 1893f && OFAIIFNDIJA && EOPDJOKHPLJ)
					{
						Singleton<SniperScope>.instance.KGEEDMONDMK(1195f);
					}
				}
			}
			if (ACHMJPNAIOC && TimeManager.realTimeWithoutPauses > BBILIBAPBHN + OKHIFGKIMEH)
			{
				HFNAMMBPJAJ().Fire(DEOJIJHFFEP);
				AEFMJPKANLN(DEOJIJHFFEP);
				HICJCHBHHDJ();
				ACHMJPNAIOC = false;
			}
		}
		else
		{
			JLFBKAMLIHG = false;
		}
		if (Input.GetMouseButtonUp(1) && base.playerController.isCurrentPlayer)
		{
			Singleton<SniperScope>.instance.NOGIKDILBLG();
			GAFHKNHKGPJ = false;
		}
	}

	public virtual void LGCLPDEDHJF(Vector3 MPHCNMDIPAI)
	{
		base.MFGIHHMKGLA(MPHCNMDIPAI);
		if (base.weapon.willShoot && !ACHMJPNAIOC)
		{
			FBNGPDHDECK(MPHCNMDIPAI);
		}
	}

	[SpecialName]
	public virtual bool FHBOOPADLEI()
	{
		return base.isActiveWeapon;
	}

	public virtual void NIIBPDLACGO()
	{
		base.MJNGGEJFMNF();
		if (Input.GetMouseButtonUp(0) && base.playerController.isCurrentPlayer && !EOPDJOKHPLJ)
		{
			GAFHKNHKGPJ = true;
		}
		if (!base.playerController.PBMFJEPBNLE())
		{
			if (Singleton<GameController>.instance.GHKPKDPOGHF() && base.playerController.isCurrentPlayer)
			{
				if (Singleton<InputController>.instance.isTappingStarted)
				{
					NEPGMHCINFE = TimeManager.realTimeWithoutPauses;
				}
				if (Singleton<InputController>.instance.isTapping && !ACHMJPNAIOC)
				{
					CFCAKLBNKMD = TimeManager.CEAFAMFNGCC();
					if (HFNAMMBPJAJ().willShoot && (GAFHKNHKGPJ || EOPDJOKHPLJ))
					{
						ADEOFMHDEAO = Singleton<AimingHelper>.instance.MEPOKAJNLKA(base.weapon);
						if (OOOJCFNEPIK(ADEOFMHDEAO))
						{
							PGIJILGMBIC(ADEOFMHDEAO);
						}
					}
					else if ((float)base.weapon.JMDLKIAKOIE > 1716f && Singleton<InputController>.instance.isTappingStarted)
					{
						GuiElementSingle<InventoryGuiElement>.instance.PlayWeaponReloading(this);
					}
					if (base.weapon.isReloading || base.weapon.outOfAmmo)
					{
						JLFBKAMLIHG = false;
						Singleton<SniperScope>.instance.IFGMJHLIPJL();
					}
					else if (CFCAKLBNKMD - NEPGMHCINFE > 1087f && DOFPGHBEPFN() && EOPDJOKHPLJ)
					{
						Singleton<SniperScope>.instance.DFJBBKKIPAD(689f);
					}
				}
			}
			if (ACHMJPNAIOC && TimeManager.realTimeWithoutPauses > BBILIBAPBHN + OKHIFGKIMEH)
			{
				HFNAMMBPJAJ().Fire(DEOJIJHFFEP);
				AEFMJPKANLN(DEOJIJHFFEP);
				EIOLCOEACLN();
				ACHMJPNAIOC = true;
			}
		}
		else
		{
			JLFBKAMLIHG = false;
		}
		if (Input.GetMouseButtonUp(0) && GLNCDIKMDEO().isCurrentPlayer)
		{
			Singleton<SniperScope>.instance.EGJBBJMJBHO();
			GAFHKNHKGPJ = false;
		}
	}

	public virtual void IDJKKBKLPJF()
	{
		if (Input.GetMouseButtonUp(1) && base.playerController.isCurrentPlayer)
		{
			Singleton<SniperScope>.instance.NLEKBKHPEJI();
			GAFHKNHKGPJ = false;
		}
	}

	private void BAAGABOHHGG(Vector3 OEDJOFINBMI)
	{
		OKHIFGKIMEH = KGEKIGAOKFD;
		GAFHKNHKGPJ = true;
		bool flag = true;
		bool flag2 = GeometryTools.AngleSigned(GLNCDIKMDEO().EMAMENNDFMB().point.transform.forward, OEDJOFINBMI - base.playerController.transform.position, Vector3.up) > 902f;
		Vector3 pLEBANKIBPP = OEDJOFINBMI - base.playerController.transform.position;
		pLEBANKIBPP.y = 828f;
		if (base.playerController.soldierAnimator.isHiding || GLNCDIKMDEO().soldierAnimator.isIdle || (base.playerController.CLFDBFPKCBJ() == PlayerController.KKPHPLOEACG.HidingBehindShield && JLFBKAMLIHG))
		{
			flag = false;
			JLFBKAMLIHG = false;
			if (base.playerController.GFCDMMGDFJK().LCHDJIICIBK())
			{
				OKHIFGKIMEH = GLNCDIKMDEO().GFCDMMGDFJK().hiddingTime;
			}
			else
			{
				OKHIFGKIMEH = GLNCDIKMDEO().GFCDMMGDFJK().uncoverLength * 809f;
			}
			if (GLNCDIKMDEO().playerState == PlayerController.KKPHPLOEACG.Walking)
			{
				OKHIFGKIMEH = 202f;
			}
		}
		else if (GLNCDIKMDEO().soldierAnimator.IsShooting || GLNCDIKMDEO().soldierAnimator.isRunning)
		{
			base.weapon.Fire(OEDJOFINBMI);
			AEFMJPKANLN(OEDJOFINBMI);
			JJALJKEMOJF();
		}
		if (flag2 != NCMEJJEPLCI)
		{
			NCMEJJEPLCI = flag2;
			flag = true;
			OKHIFGKIMEH = GLNCDIKMDEO().soldierAnimator.uncoverLength * 916f;
		}
		GLNCDIKMDEO().PlayShotAnimation(base.weapon.BEACDIILBEG, NCMEJJEPLCI, pLEBANKIBPP);
		if (flag)
		{
			BBILIBAPBHN = TimeManager.realTimeWithoutPauses;
			DEOJIJHFFEP = OEDJOFINBMI;
			ACHMJPNAIOC = true;
		}
	}

	public virtual void ECNDAAJHACI()
	{
		if (Input.GetMouseButtonUp(0) && GLNCDIKMDEO().isCurrentPlayer)
		{
			Singleton<SniperScope>.instance.NLEKBKHPEJI();
			GAFHKNHKGPJ = true;
		}
	}

	[SpecialName]
	private bool BBLMHEOICFF()
	{
		return !GGANLFIFAMK || DebugSettings.showPrimaryScopes;
	}

	[SpecialName]
	public virtual void HKNIKBJFOII(bool IDEBKDPMPGM)
	{
		base.isActiveWeapon = IDEBKDPMPGM;
		if (!OHKDJNIADMF() && base.playerController.isCurrentPlayer)
		{
			Singleton<SniperScope>.instance.EGJBBJMJBHO();
		}
		if (NFJFHHCLNJP() && base.playerController.isCurrentPlayer)
		{
			Singleton<SniperScope>.instance.IAFCNNILJEJ(IGABBABGBFC);
		}
		ACHMJPNAIOC = false;
	}

	[SpecialName]
	public virtual bool CAOCBKABFAH()
	{
		return base.BPAOCKIKDMH();
	}

	[SpecialName]
	public virtual void JOELIILCPAA(bool IDEBKDPMPGM)
	{
		base.isActiveWeapon = IDEBKDPMPGM;
		if (!BPAOCKIKDMH() && base.playerController.isCurrentPlayer)
		{
			Singleton<SniperScope>.instance.NLEKBKHPEJI();
		}
		if (OHKDJNIADMF() && GLNCDIKMDEO().isCurrentPlayer)
		{
			Singleton<SniperScope>.instance.SetScope(IGABBABGBFC);
		}
		ACHMJPNAIOC = true;
	}

	public override void ShootForBot(Vector3 MPHCNMDIPAI)
	{
		base.ShootForBot(MPHCNMDIPAI);
		if (base.weapon.willShoot && !ACHMJPNAIOC)
		{
			KODCHCILFHL(MPHCNMDIPAI);
		}
	}

	public virtual void ENDHECEMBEC(Vector3 MPHCNMDIPAI)
	{
		base.ShootForBot(MPHCNMDIPAI);
		if (HFNAMMBPJAJ().willShoot && !ACHMJPNAIOC)
		{
			KODCHCILFHL(MPHCNMDIPAI);
		}
	}

	private void CDEKJENJMEP(Vector3 OEDJOFINBMI)
	{
		OKHIFGKIMEH = KGEKIGAOKFD;
		GAFHKNHKGPJ = false;
		bool flag = true;
		bool flag2 = GeometryTools.AngleSigned(GLNCDIKMDEO().EMAMENNDFMB().point.transform.forward, OEDJOFINBMI - base.playerController.transform.position, Vector3.up) > 1719f;
		Vector3 pLEBANKIBPP = OEDJOFINBMI - GLNCDIKMDEO().transform.position;
		pLEBANKIBPP.y = 4f;
		if (base.playerController.soldierAnimator.LIHLPCKFCCF() || GLNCDIKMDEO().GFCDMMGDFJK().isIdle || (base.playerController.playerState == PlayerController.KKPHPLOEACG.Walking && JLFBKAMLIHG))
		{
			flag = true;
			JLFBKAMLIHG = false;
			if (base.playerController.GFCDMMGDFJK().LCHDJIICIBK())
			{
				OKHIFGKIMEH = GLNCDIKMDEO().soldierAnimator.hiddingTime;
			}
			else
			{
				OKHIFGKIMEH = base.playerController.soldierAnimator.uncoverLength * 1991f;
			}
			if (base.playerController.CLFDBFPKCBJ() == PlayerController.KKPHPLOEACG.HidingBehindShield)
			{
				OKHIFGKIMEH = 1631f;
			}
		}
		else if (GLNCDIKMDEO().GFCDMMGDFJK().IsShooting || base.playerController.soldierAnimator.isRunning)
		{
			HFNAMMBPJAJ().Fire(OEDJOFINBMI);
			IHHGONCBBFI(OEDJOFINBMI);
			JKFBHMDKMNL();
		}
		if (flag2 != NCMEJJEPLCI)
		{
			NCMEJJEPLCI = flag2;
			flag = true;
			OKHIFGKIMEH = base.playerController.soldierAnimator.uncoverLength * 1409f;
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
	private bool FDKNNGJEIPF()
	{
		return !GGANLFIFAMK || DebugSettings.showPrimaryScopes;
	}

	[SpecialName]
	private bool HPCKFNBHFBM()
	{
		return !GGANLFIFAMK || DebugSettings.showPrimaryScopes;
	}

	[SpecialName]
	public virtual void IHAEGAMJJJF(bool IDEBKDPMPGM)
	{
		base.FHKGABMHOHI(IDEBKDPMPGM);
		if (!OHKDJNIADMF() && GLNCDIKMDEO().isCurrentPlayer)
		{
			Singleton<SniperScope>.instance.Hide();
		}
		if (NFJFHHCLNJP() && base.playerController.isCurrentPlayer)
		{
			Singleton<SniperScope>.instance.DCIPJFNIMNH(IGABBABGBFC);
		}
		ACHMJPNAIOC = false;
	}

	public virtual void CEOODAJAJAK()
	{
		base.CPIOHBLIMLH();
		if (Input.GetMouseButtonUp(1) && GLNCDIKMDEO().isCurrentPlayer && !EOPDJOKHPLJ)
		{
			GAFHKNHKGPJ = false;
		}
		if (!GLNCDIKMDEO().PBMFJEPBNLE())
		{
			if (Singleton<GameController>.instance.KKHKIEFMENC() && base.playerController.isCurrentPlayer)
			{
				if (Singleton<InputController>.instance.isTappingStarted)
				{
					NEPGMHCINFE = TimeManager.CEAFAMFNGCC();
				}
				if (Singleton<InputController>.instance.isTapping && !ACHMJPNAIOC)
				{
					CFCAKLBNKMD = TimeManager.realTimeWithoutPauses;
					if (HFNAMMBPJAJ().willShoot && (GAFHKNHKGPJ || EOPDJOKHPLJ))
					{
						ADEOFMHDEAO = Singleton<AimingHelper>.instance.KBGHDKFGGHN(HFNAMMBPJAJ());
						if (GNONBGKLKMG(ADEOFMHDEAO))
						{
							PIDIFPGJGKF(ADEOFMHDEAO);
						}
					}
					else if ((float)HFNAMMBPJAJ().JMDLKIAKOIE > 1243f && Singleton<InputController>.instance.isTappingStarted)
					{
						GuiElementSingle<InventoryGuiElement>.instance.PlayWeaponReloading(this);
					}
					if (HFNAMMBPJAJ().isReloading || base.weapon.outOfAmmo)
					{
						JLFBKAMLIHG = true;
						Singleton<SniperScope>.instance.IFGMJHLIPJL();
					}
					else if (CFCAKLBNKMD - NEPGMHCINFE > 204f && GNGJCCPAKHP() && EOPDJOKHPLJ)
					{
						Singleton<SniperScope>.instance.ECBMHNDPENI(672f);
					}
				}
			}
			if (ACHMJPNAIOC && TimeManager.realTimeWithoutPauses > BBILIBAPBHN + OKHIFGKIMEH)
			{
				HFNAMMBPJAJ().Fire(DEOJIJHFFEP);
				IHHGONCBBFI(DEOJIJHFFEP);
				GEGFAHHIIPI();
				ACHMJPNAIOC = false;
			}
		}
		else
		{
			JLFBKAMLIHG = true;
		}
		if (Input.GetMouseButtonUp(1) && base.playerController.isCurrentPlayer)
		{
			Singleton<SniperScope>.instance.IFGMJHLIPJL();
			GAFHKNHKGPJ = false;
		}
	}

	public virtual void NPBCHBLDGMD(Vector3 MPHCNMDIPAI)
	{
		base.ShootForBot(MPHCNMDIPAI);
		if (HFNAMMBPJAJ().willShoot && !ACHMJPNAIOC)
		{
			KFOFOBMOFOB(MPHCNMDIPAI);
		}
	}

	[SpecialName]
	public virtual bool KOBKNMGEGLJ()
	{
		return base.BPAOCKIKDMH();
	}

	private void FFFHDPDDDMH(Vector3 OEDJOFINBMI)
	{
		OKHIFGKIMEH = KGEKIGAOKFD;
		GAFHKNHKGPJ = true;
		bool flag = false;
		bool flag2 = GeometryTools.AngleSigned(base.playerController.BBNPGJAALCJ().point.transform.forward, OEDJOFINBMI - base.playerController.transform.position, Vector3.up) > 1010f;
		Vector3 pLEBANKIBPP = OEDJOFINBMI - GLNCDIKMDEO().transform.position;
		pLEBANKIBPP.y = 1430f;
		if (GLNCDIKMDEO().GFCDMMGDFJK().LCHDJIICIBK() || GLNCDIKMDEO().soldierAnimator.isIdle || (base.playerController.CLFDBFPKCBJ() == PlayerController.KKPHPLOEACG.HidingBehindShield && JLFBKAMLIHG))
		{
			flag = true;
			JLFBKAMLIHG = true;
			if (base.playerController.soldierAnimator.isHiding)
			{
				OKHIFGKIMEH = GLNCDIKMDEO().GFCDMMGDFJK().hiddingTime;
			}
			else
			{
				OKHIFGKIMEH = GLNCDIKMDEO().soldierAnimator.uncoverLength * 871f;
			}
			if (GLNCDIKMDEO().BIEONCCPBIL() == PlayerController.KKPHPLOEACG.HidingBehindShield)
			{
				OKHIFGKIMEH = 1755f;
			}
		}
		else if (base.playerController.GFCDMMGDFJK().IsShooting || GLNCDIKMDEO().GFCDMMGDFJK().isRunning)
		{
			HFNAMMBPJAJ().Fire(OEDJOFINBMI);
			IHHGONCBBFI(OEDJOFINBMI);
			EIOLCOEACLN();
		}
		if (flag2 != NCMEJJEPLCI)
		{
			NCMEJJEPLCI = flag2;
			flag = true;
			OKHIFGKIMEH = base.playerController.GFCDMMGDFJK().uncoverLength * 541f;
		}
		GLNCDIKMDEO().PlayShotAnimation(base.weapon.BEACDIILBEG, NCMEJJEPLCI, pLEBANKIBPP);
		if (flag)
		{
			BBILIBAPBHN = TimeManager.realTimeWithoutPauses;
			DEOJIJHFFEP = OEDJOFINBMI;
			ACHMJPNAIOC = true;
		}
	}

	[SpecialName]
	private bool IHBKBPJFEFK()
	{
		return !GGANLFIFAMK || DebugSettings.showPrimaryScopes;
	}

	[SpecialName]
	public virtual bool CDJBCNNCHDA()
	{
		return base.NFJFHHCLNJP();
	}

	[SpecialName]
	public virtual void FIMICFFMHEK(bool IDEBKDPMPGM)
	{
		base.FHKGABMHOHI(IDEBKDPMPGM);
		if (!NFJFHHCLNJP() && base.playerController.isCurrentPlayer)
		{
			Singleton<SniperScope>.instance.NOGIKDILBLG();
		}
		if (BPAOCKIKDMH() && GLNCDIKMDEO().isCurrentPlayer)
		{
			Singleton<SniperScope>.instance.IAFCNNILJEJ(IGABBABGBFC);
		}
		ACHMJPNAIOC = true;
	}

	public virtual void CJANLOFPLPH()
	{
		base.GFPIFCCPLIP();
		if (Input.GetMouseButtonUp(0) && base.playerController.isCurrentPlayer && !EOPDJOKHPLJ)
		{
			GAFHKNHKGPJ = true;
		}
		if (!base.playerController.clicked)
		{
			if (Singleton<GameController>.instance.GHKPKDPOGHF() && GLNCDIKMDEO().isCurrentPlayer)
			{
				if (Singleton<InputController>.instance.isTappingStarted)
				{
					NEPGMHCINFE = TimeManager.CEAFAMFNGCC();
				}
				if (Singleton<InputController>.instance.isTapping && !ACHMJPNAIOC)
				{
					CFCAKLBNKMD = TimeManager.CEAFAMFNGCC();
					if (base.weapon.willShoot && (GAFHKNHKGPJ || EOPDJOKHPLJ))
					{
						ADEOFMHDEAO = Singleton<AimingHelper>.instance.KBGHDKFGGHN(HFNAMMBPJAJ());
						if (OOOJCFNEPIK(ADEOFMHDEAO))
						{
							NKPJAOGOMPH(ADEOFMHDEAO);
						}
					}
					else if ((float)base.weapon.JMDLKIAKOIE > 1687f && Singleton<InputController>.instance.isTappingStarted)
					{
						GuiElementSingle<InventoryGuiElement>.instance.PlayWeaponReloading(this);
					}
					if (base.weapon.isReloading || HFNAMMBPJAJ().outOfAmmo)
					{
						JLFBKAMLIHG = false;
						Singleton<SniperScope>.instance.NLEKBKHPEJI();
					}
					else if (CFCAKLBNKMD - NEPGMHCINFE > 1480f && BBLMHEOICFF() && EOPDJOKHPLJ)
					{
						Singleton<SniperScope>.instance.KGEEDMONDMK(0f);
					}
				}
			}
			if (ACHMJPNAIOC && TimeManager.realTimeWithoutPauses > BBILIBAPBHN + OKHIFGKIMEH)
			{
				HFNAMMBPJAJ().Fire(DEOJIJHFFEP);
				IHHGONCBBFI(DEOJIJHFFEP);
				JJALJKEMOJF();
				ACHMJPNAIOC = true;
			}
		}
		else
		{
			JLFBKAMLIHG = false;
		}
		if (Input.GetMouseButtonUp(0) && base.playerController.isCurrentPlayer)
		{
			Singleton<SniperScope>.instance.IFGMJHLIPJL();
			GAFHKNHKGPJ = false;
		}
	}

	[SpecialName]
	public virtual bool MBBOLBGPNDN()
	{
		return base.BPAOCKIKDMH();
	}

	[SpecialName]
	private bool PAHBIHGBKFA()
	{
		return !GGANLFIFAMK || DebugSettings.showPrimaryScopes;
	}

	[SpecialName]
	private bool DOFPGHBEPFN()
	{
		return !GGANLFIFAMK || DebugSettings.showPrimaryScopes;
	}

	public virtual void ACNAHHKGCNP()
	{
		if (Input.GetMouseButtonUp(1) && GLNCDIKMDEO().isCurrentPlayer)
		{
			Singleton<SniperScope>.instance.IFGMJHLIPJL();
			GAFHKNHKGPJ = true;
		}
	}

	[SpecialName]
	public virtual bool EONGGIBBJCP()
	{
		return base.BPAOCKIKDMH();
	}

	public override void MouseUpAndNoUpdate()
	{
		if (Input.GetMouseButtonUp(0) && base.playerController.isCurrentPlayer)
		{
			Singleton<SniperScope>.instance.Hide();
			GAFHKNHKGPJ = true;
		}
	}

	public virtual void CBCMLHMLKEE()
	{
		base.ELDLIOIOMEK();
		if (Input.GetMouseButtonUp(1) && GLNCDIKMDEO().isCurrentPlayer && !EOPDJOKHPLJ)
		{
			GAFHKNHKGPJ = true;
		}
		if (!GLNCDIKMDEO().PBMFJEPBNLE())
		{
			if (Singleton<GameController>.instance.gameIsRunning && GLNCDIKMDEO().isCurrentPlayer)
			{
				if (Singleton<InputController>.instance.isTappingStarted)
				{
					NEPGMHCINFE = TimeManager.realTimeWithoutPauses;
				}
				if (Singleton<InputController>.instance.isTapping && !ACHMJPNAIOC)
				{
					CFCAKLBNKMD = TimeManager.CEAFAMFNGCC();
					if (base.weapon.willShoot && (GAFHKNHKGPJ || EOPDJOKHPLJ))
					{
						ADEOFMHDEAO = Singleton<AimingHelper>.instance.Aim(HFNAMMBPJAJ());
						if (KELOGHNJDDI(ADEOFMHDEAO))
						{
							PGIJILGMBIC(ADEOFMHDEAO);
						}
					}
					else if ((float)base.weapon.JMDLKIAKOIE > 1187f && Singleton<InputController>.instance.isTappingStarted)
					{
						GuiElementSingle<InventoryGuiElement>.instance.EIKJOPHNCOM(this);
					}
					if (base.weapon.isReloading || base.weapon.outOfAmmo)
					{
						JLFBKAMLIHG = true;
						Singleton<SniperScope>.instance.EGJBBJMJBHO();
					}
					else if (CFCAKLBNKMD - NEPGMHCINFE > 949f && GIPDLGAOHFI() && EOPDJOKHPLJ)
					{
						Singleton<SniperScope>.instance.PHEFLAHPMDH(1430f);
					}
				}
			}
			if (ACHMJPNAIOC && TimeManager.CEAFAMFNGCC() > BBILIBAPBHN + OKHIFGKIMEH)
			{
				HFNAMMBPJAJ().Fire(DEOJIJHFFEP);
				AEFMJPKANLN(DEOJIJHFFEP);
				EIOLCOEACLN();
				ACHMJPNAIOC = true;
			}
		}
		else
		{
			JLFBKAMLIHG = true;
		}
		if (Input.GetMouseButtonUp(1) && base.playerController.isCurrentPlayer)
		{
			Singleton<SniperScope>.instance.NOGIKDILBLG();
			GAFHKNHKGPJ = false;
		}
	}

	public virtual void LBBNNAEBEHH()
	{
		base.CPIOHBLIMLH();
		if (Input.GetMouseButtonUp(0) && GLNCDIKMDEO().isCurrentPlayer && !EOPDJOKHPLJ)
		{
			GAFHKNHKGPJ = false;
		}
		if (!GLNCDIKMDEO().PBMFJEPBNLE())
		{
			if (Singleton<GameController>.instance.GHKPKDPOGHF() && GLNCDIKMDEO().isCurrentPlayer)
			{
				if (Singleton<InputController>.instance.isTappingStarted)
				{
					NEPGMHCINFE = TimeManager.realTimeWithoutPauses;
				}
				if (Singleton<InputController>.instance.isTapping && !ACHMJPNAIOC)
				{
					CFCAKLBNKMD = TimeManager.realTimeWithoutPauses;
					if (HFNAMMBPJAJ().willShoot && (GAFHKNHKGPJ || EOPDJOKHPLJ))
					{
						ADEOFMHDEAO = Singleton<AimingHelper>.instance.INLBJMAJKNJ(HFNAMMBPJAJ());
						if (KELOGHNJDDI(ADEOFMHDEAO))
						{
							FFFHDPDDDMH(ADEOFMHDEAO);
						}
					}
					else if ((float)HFNAMMBPJAJ().JMDLKIAKOIE > 753f && Singleton<InputController>.instance.isTappingStarted)
					{
						GuiElementSingle<InventoryGuiElement>.instance.EIKJOPHNCOM(this);
					}
					if (base.weapon.isReloading || HFNAMMBPJAJ().outOfAmmo)
					{
						JLFBKAMLIHG = false;
						Singleton<SniperScope>.instance.NLEKBKHPEJI();
					}
					else if (CFCAKLBNKMD - NEPGMHCINFE > 757f && APELEHKEKPK() && EOPDJOKHPLJ)
					{
						Singleton<SniperScope>.instance.EKGIMBEJLFH(880f);
					}
				}
			}
			if (ACHMJPNAIOC && TimeManager.realTimeWithoutPauses > BBILIBAPBHN + OKHIFGKIMEH)
			{
				HFNAMMBPJAJ().Fire(DEOJIJHFFEP);
				AEFMJPKANLN(DEOJIJHFFEP);
				JJALJKEMOJF();
				ACHMJPNAIOC = false;
			}
		}
		else
		{
			JLFBKAMLIHG = false;
		}
		if (Input.GetMouseButtonUp(1) && GLNCDIKMDEO().isCurrentPlayer)
		{
			Singleton<SniperScope>.instance.NLEKBKHPEJI();
			GAFHKNHKGPJ = true;
		}
	}

	[SpecialName]
	private bool GKMJMBJBGJN()
	{
		return !GGANLFIFAMK || DebugSettings.showPrimaryScopes;
	}

	public virtual void NIFIENAOONB()
	{
		if (Input.GetMouseButtonUp(1) && GLNCDIKMDEO().isCurrentPlayer)
		{
			Singleton<SniperScope>.instance.Hide();
			GAFHKNHKGPJ = true;
		}
	}

	private void MNIMHOFEDAI(Vector3 OEDJOFINBMI)
	{
		OKHIFGKIMEH = KGEKIGAOKFD;
		GAFHKNHKGPJ = true;
		bool flag = true;
		bool flag2 = GeometryTools.AngleSigned(GLNCDIKMDEO().CMNFFACHCEE().point.transform.forward, OEDJOFINBMI - GLNCDIKMDEO().transform.position, Vector3.up) > 524f;
		Vector3 pLEBANKIBPP = OEDJOFINBMI - GLNCDIKMDEO().transform.position;
		pLEBANKIBPP.y = 695f;
		if (GLNCDIKMDEO().soldierAnimator.LIHLPCKFCCF() || GLNCDIKMDEO().GFCDMMGDFJK().isIdle || (base.playerController.BIEONCCPBIL() == PlayerController.KKPHPLOEACG.Walking && JLFBKAMLIHG))
		{
			flag = false;
			JLFBKAMLIHG = false;
			if (GLNCDIKMDEO().soldierAnimator.isHiding)
			{
				OKHIFGKIMEH = GLNCDIKMDEO().GFCDMMGDFJK().hiddingTime;
			}
			else
			{
				OKHIFGKIMEH = GLNCDIKMDEO().GFCDMMGDFJK().uncoverLength * 632f;
			}
			if (base.playerController.CLFDBFPKCBJ() == PlayerController.KKPHPLOEACG.Walking)
			{
				OKHIFGKIMEH = 1143f;
			}
		}
		else if (GLNCDIKMDEO().GFCDMMGDFJK().IsShooting || base.playerController.GFCDMMGDFJK().isRunning)
		{
			base.weapon.Fire(OEDJOFINBMI);
			IHHGONCBBFI(OEDJOFINBMI);
			EIOLCOEACLN();
		}
		if (flag2 != NCMEJJEPLCI)
		{
			NCMEJJEPLCI = flag2;
			flag = false;
			OKHIFGKIMEH = base.playerController.GFCDMMGDFJK().uncoverLength * 523f;
		}
		GLNCDIKMDEO().EIMEBEABDHF(HFNAMMBPJAJ().BEACDIILBEG, NCMEJJEPLCI, pLEBANKIBPP);
		if (flag)
		{
			BBILIBAPBHN = TimeManager.CEAFAMFNGCC();
			DEOJIJHFFEP = OEDJOFINBMI;
			ACHMJPNAIOC = false;
		}
	}

	[SpecialName]
	private bool CHFEFLFMEPF()
	{
		return !GGANLFIFAMK || DebugSettings.showPrimaryScopes;
	}

	public virtual void FCJOOKMIEDF(Vector3 MPHCNMDIPAI)
	{
		base.MNIJGBAKEKA(MPHCNMDIPAI);
		if (HFNAMMBPJAJ().willShoot && !ACHMJPNAIOC)
		{
			MMOBPLJGHJB(MPHCNMDIPAI);
		}
	}

	public virtual void ENPIGKILOOG()
	{
		if (Input.GetMouseButtonUp(1) && base.playerController.isCurrentPlayer)
		{
			Singleton<SniperScope>.instance.NOGIKDILBLG();
			GAFHKNHKGPJ = false;
		}
	}

	public virtual void GIHDLFBHIOE()
	{
		base.BNAEGDKLBBJ();
		if (Input.GetMouseButtonUp(0) && GLNCDIKMDEO().isCurrentPlayer && !EOPDJOKHPLJ)
		{
			GAFHKNHKGPJ = false;
		}
		if (!base.playerController.clicked)
		{
			if (Singleton<GameController>.instance.GHKPKDPOGHF() && GLNCDIKMDEO().isCurrentPlayer)
			{
				if (Singleton<InputController>.instance.isTappingStarted)
				{
					NEPGMHCINFE = TimeManager.realTimeWithoutPauses;
				}
				if (Singleton<InputController>.instance.isTapping && !ACHMJPNAIOC)
				{
					CFCAKLBNKMD = TimeManager.CEAFAMFNGCC();
					if (HFNAMMBPJAJ().willShoot && (GAFHKNHKGPJ || EOPDJOKHPLJ))
					{
						ADEOFMHDEAO = Singleton<AimingHelper>.instance.KDJDDOJCBJA(HFNAMMBPJAJ());
						if (CEJHOFMPNAA(ADEOFMHDEAO))
						{
							KEHDFEIHGNO(ADEOFMHDEAO);
						}
					}
					else if ((float)base.weapon.JMDLKIAKOIE > 400f && Singleton<InputController>.instance.isTappingStarted)
					{
						GuiElementSingle<InventoryGuiElement>.instance.PlayWeaponReloading(this);
					}
					if (HFNAMMBPJAJ().isReloading || HFNAMMBPJAJ().outOfAmmo)
					{
						JLFBKAMLIHG = false;
						Singleton<SniperScope>.instance.Hide();
					}
					else if (CFCAKLBNKMD - NEPGMHCINFE > 1935f && EIFJDPHFBBG() && EOPDJOKHPLJ)
					{
						Singleton<SniperScope>.instance.Show(1757f);
					}
				}
			}
			if (ACHMJPNAIOC && TimeManager.CEAFAMFNGCC() > BBILIBAPBHN + OKHIFGKIMEH)
			{
				HFNAMMBPJAJ().Fire(DEOJIJHFFEP);
				IHHGONCBBFI(DEOJIJHFFEP);
				HICJCHBHHDJ();
				ACHMJPNAIOC = false;
			}
		}
		else
		{
			JLFBKAMLIHG = true;
		}
		if (Input.GetMouseButtonUp(1) && base.playerController.isCurrentPlayer)
		{
			Singleton<SniperScope>.instance.IFGMJHLIPJL();
			GAFHKNHKGPJ = false;
		}
	}

	public virtual void GHNGAHBJGIH()
	{
		base.MJNGGEJFMNF();
		if (Input.GetMouseButtonUp(0) && base.playerController.isCurrentPlayer && !EOPDJOKHPLJ)
		{
			GAFHKNHKGPJ = false;
		}
		if (!base.playerController.PBMFJEPBNLE())
		{
			if (Singleton<GameController>.instance.KKHKIEFMENC() && GLNCDIKMDEO().isCurrentPlayer)
			{
				if (Singleton<InputController>.instance.isTappingStarted)
				{
					NEPGMHCINFE = TimeManager.realTimeWithoutPauses;
				}
				if (Singleton<InputController>.instance.isTapping && !ACHMJPNAIOC)
				{
					CFCAKLBNKMD = TimeManager.realTimeWithoutPauses;
					if (base.weapon.willShoot && (GAFHKNHKGPJ || EOPDJOKHPLJ))
					{
						ADEOFMHDEAO = Singleton<AimingHelper>.instance.PBCOBBGJNPD(HFNAMMBPJAJ());
						if (GNONBGKLKMG(ADEOFMHDEAO))
						{
							BAAGABOHHGG(ADEOFMHDEAO);
						}
					}
					else if ((float)HFNAMMBPJAJ().JMDLKIAKOIE > 1277f && Singleton<InputController>.instance.isTappingStarted)
					{
						GuiElementSingle<InventoryGuiElement>.instance.PlayWeaponReloading(this);
					}
					if (HFNAMMBPJAJ().isReloading || HFNAMMBPJAJ().outOfAmmo)
					{
						JLFBKAMLIHG = true;
						Singleton<SniperScope>.instance.EGJBBJMJBHO();
					}
					else if (CFCAKLBNKMD - NEPGMHCINFE > 132f && GNGJCCPAKHP() && EOPDJOKHPLJ)
					{
						Singleton<SniperScope>.instance.Show(1628f);
					}
				}
			}
			if (ACHMJPNAIOC && TimeManager.CEAFAMFNGCC() > BBILIBAPBHN + OKHIFGKIMEH)
			{
				base.weapon.Fire(DEOJIJHFFEP);
				IHHGONCBBFI(DEOJIJHFFEP);
				AFGBNEOKEEG();
				ACHMJPNAIOC = true;
			}
		}
		else
		{
			JLFBKAMLIHG = false;
		}
		if (Input.GetMouseButtonUp(1) && base.playerController.isCurrentPlayer)
		{
			Singleton<SniperScope>.instance.EGJBBJMJBHO();
			GAFHKNHKGPJ = true;
		}
	}

	public virtual void ICCILFBELJD()
	{
		base.ELDLIOIOMEK();
		if (Input.GetMouseButtonUp(0) && GLNCDIKMDEO().isCurrentPlayer && !EOPDJOKHPLJ)
		{
			GAFHKNHKGPJ = true;
		}
		if (!base.playerController.PBMFJEPBNLE())
		{
			if (Singleton<GameController>.instance.KKHKIEFMENC() && base.playerController.isCurrentPlayer)
			{
				if (Singleton<InputController>.instance.isTappingStarted)
				{
					NEPGMHCINFE = TimeManager.CEAFAMFNGCC();
				}
				if (Singleton<InputController>.instance.isTapping && !ACHMJPNAIOC)
				{
					CFCAKLBNKMD = TimeManager.realTimeWithoutPauses;
					if (HFNAMMBPJAJ().willShoot && (GAFHKNHKGPJ || EOPDJOKHPLJ))
					{
						ADEOFMHDEAO = Singleton<AimingHelper>.instance.NBIFJONHHGF(HFNAMMBPJAJ());
						if (KPBILMGEJPP(ADEOFMHDEAO))
						{
							NKPJAOGOMPH(ADEOFMHDEAO);
						}
					}
					else if ((float)base.weapon.JMDLKIAKOIE > 1930f && Singleton<InputController>.instance.isTappingStarted)
					{
						GuiElementSingle<InventoryGuiElement>.instance.EIKJOPHNCOM(this);
					}
					if (base.weapon.isReloading || base.weapon.outOfAmmo)
					{
						JLFBKAMLIHG = false;
						Singleton<SniperScope>.instance.EGJBBJMJBHO();
					}
					else if (CFCAKLBNKMD - NEPGMHCINFE > 1034f && GKMJMBJBGJN() && EOPDJOKHPLJ)
					{
						Singleton<SniperScope>.instance.EKGIMBEJLFH(1202f);
					}
				}
			}
			if (ACHMJPNAIOC && TimeManager.realTimeWithoutPauses > BBILIBAPBHN + OKHIFGKIMEH)
			{
				HFNAMMBPJAJ().Fire(DEOJIJHFFEP);
				IHHGONCBBFI(DEOJIJHFFEP);
				HICJCHBHHDJ();
				ACHMJPNAIOC = false;
			}
		}
		else
		{
			JLFBKAMLIHG = true;
		}
		if (Input.GetMouseButtonUp(1) && GLNCDIKMDEO().isCurrentPlayer)
		{
			Singleton<SniperScope>.instance.Hide();
			GAFHKNHKGPJ = true;
		}
	}

	private void KFOFOBMOFOB(Vector3 OEDJOFINBMI)
	{
		OKHIFGKIMEH = KGEKIGAOKFD;
		GAFHKNHKGPJ = false;
		bool flag = false;
		bool flag2 = GeometryTools.AngleSigned(base.playerController.BBNPGJAALCJ().point.transform.forward, OEDJOFINBMI - base.playerController.transform.position, Vector3.up) > 1616f;
		Vector3 pLEBANKIBPP = OEDJOFINBMI - GLNCDIKMDEO().transform.position;
		pLEBANKIBPP.y = 552f;
		if (base.playerController.soldierAnimator.LCHDJIICIBK() || GLNCDIKMDEO().GFCDMMGDFJK().isIdle || (GLNCDIKMDEO().BIEONCCPBIL() == PlayerController.KKPHPLOEACG.Walking && JLFBKAMLIHG))
		{
			flag = false;
			JLFBKAMLIHG = false;
			if (base.playerController.GFCDMMGDFJK().LCHDJIICIBK())
			{
				OKHIFGKIMEH = base.playerController.soldierAnimator.hiddingTime;
			}
			else
			{
				OKHIFGKIMEH = GLNCDIKMDEO().soldierAnimator.uncoverLength * 1815f;
			}
			if (base.playerController.CLFDBFPKCBJ() == PlayerController.KKPHPLOEACG.HidingBehindShield)
			{
				OKHIFGKIMEH = 605f;
			}
		}
		else if (GLNCDIKMDEO().soldierAnimator.IsShooting || base.playerController.GFCDMMGDFJK().isRunning)
		{
			HFNAMMBPJAJ().Fire(OEDJOFINBMI);
			IHHGONCBBFI(OEDJOFINBMI);
			GEGFAHHIIPI();
		}
		if (flag2 != NCMEJJEPLCI)
		{
			NCMEJJEPLCI = flag2;
			flag = false;
			OKHIFGKIMEH = GLNCDIKMDEO().soldierAnimator.uncoverLength * 891f;
		}
		GLNCDIKMDEO().EIMEBEABDHF(base.weapon.BEACDIILBEG, NCMEJJEPLCI, pLEBANKIBPP);
		if (flag)
		{
			BBILIBAPBHN = TimeManager.realTimeWithoutPauses;
			DEOJIJHFFEP = OEDJOFINBMI;
			ACHMJPNAIOC = false;
		}
	}

	[SpecialName]
	public virtual void IAELADMPJLE(bool IDEBKDPMPGM)
	{
		base.isActiveWeapon = IDEBKDPMPGM;
		if (!BPAOCKIKDMH() && base.playerController.isCurrentPlayer)
		{
			Singleton<SniperScope>.instance.NLEKBKHPEJI();
		}
		if (NFJFHHCLNJP() && GLNCDIKMDEO().isCurrentPlayer)
		{
			Singleton<SniperScope>.instance.SetScope(IGABBABGBFC);
		}
		ACHMJPNAIOC = false;
	}

	[SpecialName]
	public virtual void KMHIIEOLKPD(bool IDEBKDPMPGM)
	{
		base.FHKGABMHOHI(IDEBKDPMPGM);
		if (!isActiveWeapon && GLNCDIKMDEO().isCurrentPlayer)
		{
			Singleton<SniperScope>.instance.NOGIKDILBLG();
		}
		if (NFJFHHCLNJP() && GLNCDIKMDEO().isCurrentPlayer)
		{
			Singleton<SniperScope>.instance.MICFIMBLPEL(IGABBABGBFC);
		}
		ACHMJPNAIOC = true;
	}

	[SpecialName]
	public virtual void NOJPKGGJCOD(bool IDEBKDPMPGM)
	{
		base.IJNFCDPPENM(IDEBKDPMPGM);
		if (!NFJFHHCLNJP() && base.playerController.isCurrentPlayer)
		{
			Singleton<SniperScope>.instance.NOGIKDILBLG();
		}
		if (NFJFHHCLNJP() && base.playerController.isCurrentPlayer)
		{
			Singleton<SniperScope>.instance.SetScope(IGABBABGBFC);
		}
		ACHMJPNAIOC = true;
	}

	[SpecialName]
	public virtual void CFGMPDCOJPB(bool IDEBKDPMPGM)
	{
		base.FHKGABMHOHI(IDEBKDPMPGM);
		if (!isActiveWeapon && base.playerController.isCurrentPlayer)
		{
			Singleton<SniperScope>.instance.NOGIKDILBLG();
		}
		if (isActiveWeapon && GLNCDIKMDEO().isCurrentPlayer)
		{
			Singleton<SniperScope>.instance.DCIPJFNIMNH(IGABBABGBFC);
		}
		ACHMJPNAIOC = false;
	}

	public virtual void LDDJMDLOGKG()
	{
		base.BNAEGDKLBBJ();
		if (Input.GetMouseButtonUp(1) && base.playerController.isCurrentPlayer && !EOPDJOKHPLJ)
		{
			GAFHKNHKGPJ = false;
		}
		if (!base.playerController.clicked)
		{
			if (Singleton<GameController>.instance.GHKPKDPOGHF() && base.playerController.isCurrentPlayer)
			{
				if (Singleton<InputController>.instance.isTappingStarted)
				{
					NEPGMHCINFE = TimeManager.CEAFAMFNGCC();
				}
				if (Singleton<InputController>.instance.isTapping && !ACHMJPNAIOC)
				{
					CFCAKLBNKMD = TimeManager.CEAFAMFNGCC();
					if (HFNAMMBPJAJ().willShoot && (GAFHKNHKGPJ || EOPDJOKHPLJ))
					{
						ADEOFMHDEAO = Singleton<AimingHelper>.instance.NBIFJONHHGF(base.weapon);
						if (CEJHOFMPNAA(ADEOFMHDEAO))
						{
							FJOAFENKGFJ(ADEOFMHDEAO);
						}
					}
					else if ((float)base.weapon.JMDLKIAKOIE > 1832f && Singleton<InputController>.instance.isTappingStarted)
					{
						GuiElementSingle<InventoryGuiElement>.instance.EIKJOPHNCOM(this);
					}
					if (HFNAMMBPJAJ().isReloading || HFNAMMBPJAJ().outOfAmmo)
					{
						JLFBKAMLIHG = false;
						Singleton<SniperScope>.instance.EGJBBJMJBHO();
					}
					else if (CFCAKLBNKMD - NEPGMHCINFE > 1953f && IHBKBPJFEFK() && EOPDJOKHPLJ)
					{
						Singleton<SniperScope>.instance.GKKFPJHEEDG(450f);
					}
				}
			}
			if (ACHMJPNAIOC && TimeManager.CEAFAMFNGCC() > BBILIBAPBHN + OKHIFGKIMEH)
			{
				base.weapon.Fire(DEOJIJHFFEP);
				IHHGONCBBFI(DEOJIJHFFEP);
				AFGBNEOKEEG();
				ACHMJPNAIOC = true;
			}
		}
		else
		{
			JLFBKAMLIHG = true;
		}
		if (Input.GetMouseButtonUp(0) && GLNCDIKMDEO().isCurrentPlayer)
		{
			Singleton<SniperScope>.instance.EGJBBJMJBHO();
			GAFHKNHKGPJ = false;
		}
	}

	[SpecialName]
	public virtual void MOIHKLDMHFH(bool IDEBKDPMPGM)
	{
		base.IJNFCDPPENM(IDEBKDPMPGM);
		if (!isActiveWeapon && GLNCDIKMDEO().isCurrentPlayer)
		{
			Singleton<SniperScope>.instance.EGJBBJMJBHO();
		}
		if (NFJFHHCLNJP() && GLNCDIKMDEO().isCurrentPlayer)
		{
			Singleton<SniperScope>.instance.LAPHAJIOIAE(IGABBABGBFC);
		}
		ACHMJPNAIOC = false;
	}

	[SpecialName]
	public virtual void NDKDMHPLINH(bool IDEBKDPMPGM)
	{
		base.IJNFCDPPENM(IDEBKDPMPGM);
		if (!BPAOCKIKDMH() && base.playerController.isCurrentPlayer)
		{
			Singleton<SniperScope>.instance.Hide();
		}
		if (isActiveWeapon && base.playerController.isCurrentPlayer)
		{
			Singleton<SniperScope>.instance.MICFIMBLPEL(IGABBABGBFC);
		}
		ACHMJPNAIOC = false;
	}

	[SpecialName]
	public virtual bool MOOAIFBEOCA()
	{
		return base.OHKDJNIADMF();
	}

	[SpecialName]
	public virtual bool JAFBPFNHIBN()
	{
		return base.isActiveWeapon;
	}

	public virtual void GFGGOKEGMBJ(Vector3 MPHCNMDIPAI)
	{
		base.ShootForBot(MPHCNMDIPAI);
		if (HFNAMMBPJAJ().willShoot && !ACHMJPNAIOC)
		{
			FFFHDPDDDMH(MPHCNMDIPAI);
		}
	}

	[SpecialName]
	public virtual bool FKGDBHMBLGA()
	{
		return base.OHKDJNIADMF();
	}

	[SpecialName]
	public virtual bool MIIILBCFAEC()
	{
		return base.NFJFHHCLNJP();
	}

	private void FBNGPDHDECK(Vector3 OEDJOFINBMI)
	{
		OKHIFGKIMEH = KGEKIGAOKFD;
		GAFHKNHKGPJ = false;
		bool flag = true;
		bool flag2 = GeometryTools.AngleSigned(base.playerController.currentPlayerPoint.point.transform.forward, OEDJOFINBMI - base.playerController.transform.position, Vector3.up) > 786f;
		Vector3 pLEBANKIBPP = OEDJOFINBMI - base.playerController.transform.position;
		pLEBANKIBPP.y = 1690f;
		if (base.playerController.soldierAnimator.isHiding || base.playerController.GFCDMMGDFJK().isIdle || (base.playerController.BIEONCCPBIL() == PlayerController.KKPHPLOEACG.Walking && JLFBKAMLIHG))
		{
			flag = false;
			JLFBKAMLIHG = true;
			if (GLNCDIKMDEO().GFCDMMGDFJK().LCHDJIICIBK())
			{
				OKHIFGKIMEH = GLNCDIKMDEO().GFCDMMGDFJK().hiddingTime;
			}
			else
			{
				OKHIFGKIMEH = GLNCDIKMDEO().soldierAnimator.uncoverLength * 1545f;
			}
			if (GLNCDIKMDEO().playerState == PlayerController.KKPHPLOEACG.HidingBehindShield)
			{
				OKHIFGKIMEH = 247f;
			}
		}
		else if (base.playerController.soldierAnimator.IsShooting || base.playerController.GFCDMMGDFJK().isRunning)
		{
			HFNAMMBPJAJ().Fire(OEDJOFINBMI);
			IHHGONCBBFI(OEDJOFINBMI);
			HICJCHBHHDJ();
		}
		if (flag2 != NCMEJJEPLCI)
		{
			NCMEJJEPLCI = flag2;
			flag = false;
			OKHIFGKIMEH = base.playerController.GFCDMMGDFJK().uncoverLength * 547f;
		}
		GLNCDIKMDEO().EIMEBEABDHF(base.weapon.BEACDIILBEG, NCMEJJEPLCI, pLEBANKIBPP);
		if (flag)
		{
			BBILIBAPBHN = TimeManager.CEAFAMFNGCC();
			DEOJIJHFFEP = OEDJOFINBMI;
			ACHMJPNAIOC = false;
		}
	}

	public virtual void MIBPGJEALAN()
	{
		base.BNAEGDKLBBJ();
		if (Input.GetMouseButtonUp(0) && GLNCDIKMDEO().isCurrentPlayer && !EOPDJOKHPLJ)
		{
			GAFHKNHKGPJ = false;
		}
		if (!base.playerController.PBMFJEPBNLE())
		{
			if (Singleton<GameController>.instance.KKHKIEFMENC() && base.playerController.isCurrentPlayer)
			{
				if (Singleton<InputController>.instance.isTappingStarted)
				{
					NEPGMHCINFE = TimeManager.CEAFAMFNGCC();
				}
				if (Singleton<InputController>.instance.isTapping && !ACHMJPNAIOC)
				{
					CFCAKLBNKMD = TimeManager.CEAFAMFNGCC();
					if (HFNAMMBPJAJ().willShoot && (GAFHKNHKGPJ || EOPDJOKHPLJ))
					{
						ADEOFMHDEAO = Singleton<AimingHelper>.instance.NBIFJONHHGF(HFNAMMBPJAJ());
						if (KPBILMGEJPP(ADEOFMHDEAO))
						{
							KFOFOBMOFOB(ADEOFMHDEAO);
						}
					}
					else if ((float)HFNAMMBPJAJ().JMDLKIAKOIE > 1953f && Singleton<InputController>.instance.isTappingStarted)
					{
						GuiElementSingle<InventoryGuiElement>.instance.PlayWeaponReloading(this);
					}
					if (base.weapon.isReloading || HFNAMMBPJAJ().outOfAmmo)
					{
						JLFBKAMLIHG = true;
						Singleton<SniperScope>.instance.Hide();
					}
					else if (CFCAKLBNKMD - NEPGMHCINFE > 1222f && CHFEFLFMEPF() && EOPDJOKHPLJ)
					{
						Singleton<SniperScope>.instance.ECBMHNDPENI(663f);
					}
				}
			}
			if (ACHMJPNAIOC && TimeManager.CEAFAMFNGCC() > BBILIBAPBHN + OKHIFGKIMEH)
			{
				base.weapon.Fire(DEOJIJHFFEP);
				AEFMJPKANLN(DEOJIJHFFEP);
				GEGFAHHIIPI();
				ACHMJPNAIOC = true;
			}
		}
		else
		{
			JLFBKAMLIHG = true;
		}
		if (Input.GetMouseButtonUp(1) && base.playerController.isCurrentPlayer)
		{
			Singleton<SniperScope>.instance.EGJBBJMJBHO();
			GAFHKNHKGPJ = false;
		}
	}

	private void FJOAFENKGFJ(Vector3 OEDJOFINBMI)
	{
		OKHIFGKIMEH = KGEKIGAOKFD;
		GAFHKNHKGPJ = true;
		bool flag = false;
		bool flag2 = GeometryTools.AngleSigned(GLNCDIKMDEO().currentPlayerPoint.point.transform.forward, OEDJOFINBMI - GLNCDIKMDEO().transform.position, Vector3.up) > 942f;
		Vector3 pLEBANKIBPP = OEDJOFINBMI - GLNCDIKMDEO().transform.position;
		pLEBANKIBPP.y = 856f;
		if (GLNCDIKMDEO().GFCDMMGDFJK().isHiding || base.playerController.GFCDMMGDFJK().isIdle || (GLNCDIKMDEO().BIEONCCPBIL() == PlayerController.KKPHPLOEACG.HidingBehindShield && JLFBKAMLIHG))
		{
			flag = false;
			JLFBKAMLIHG = true;
			if (GLNCDIKMDEO().soldierAnimator.LCHDJIICIBK())
			{
				OKHIFGKIMEH = GLNCDIKMDEO().GFCDMMGDFJK().hiddingTime;
			}
			else
			{
				OKHIFGKIMEH = GLNCDIKMDEO().GFCDMMGDFJK().uncoverLength * 139f;
			}
			if (GLNCDIKMDEO().playerState == PlayerController.KKPHPLOEACG.HidingBehindShield)
			{
				OKHIFGKIMEH = 86f;
			}
		}
		else if (base.playerController.GFCDMMGDFJK().IsShooting || base.playerController.GFCDMMGDFJK().isRunning)
		{
			base.weapon.Fire(OEDJOFINBMI);
			IHHGONCBBFI(OEDJOFINBMI);
			JKFBHMDKMNL();
		}
		if (flag2 != NCMEJJEPLCI)
		{
			NCMEJJEPLCI = flag2;
			flag = false;
			OKHIFGKIMEH = base.playerController.GFCDMMGDFJK().uncoverLength * 1576f;
		}
		GLNCDIKMDEO().PlayShotAnimation(HFNAMMBPJAJ().BEACDIILBEG, NCMEJJEPLCI, pLEBANKIBPP);
		if (flag)
		{
			BBILIBAPBHN = TimeManager.CEAFAMFNGCC();
			DEOJIJHFFEP = OEDJOFINBMI;
			ACHMJPNAIOC = false;
		}
	}

	[SpecialName]
	public virtual void PFNIGDGEJHE(bool IDEBKDPMPGM)
	{
		base.isActiveWeapon = IDEBKDPMPGM;
		if (!BPAOCKIKDMH() && GLNCDIKMDEO().isCurrentPlayer)
		{
			Singleton<SniperScope>.instance.EGJBBJMJBHO();
		}
		if (isActiveWeapon && GLNCDIKMDEO().isCurrentPlayer)
		{
			Singleton<SniperScope>.instance.SetScope(IGABBABGBFC);
		}
		ACHMJPNAIOC = true;
	}

	public virtual void EFEHPJLOHAC()
	{
		if (Input.GetMouseButtonUp(0) && GLNCDIKMDEO().isCurrentPlayer)
		{
			Singleton<SniperScope>.instance.IFGMJHLIPJL();
			GAFHKNHKGPJ = false;
		}
	}

	[SpecialName]
	public virtual bool AICINPLGKOJ()
	{
		return base.isActiveWeapon;
	}

	[SpecialName]
	private bool GNGJCCPAKHP()
	{
		return GGANLFIFAMK && DebugSettings.showPrimaryScopes;
	}

	public virtual void IOGONKHLGIA()
	{
		base.GFPIFCCPLIP();
		if (Input.GetMouseButtonUp(1) && base.playerController.isCurrentPlayer && !EOPDJOKHPLJ)
		{
			GAFHKNHKGPJ = true;
		}
		if (!base.playerController.PBMFJEPBNLE())
		{
			if (Singleton<GameController>.instance.gameIsRunning && GLNCDIKMDEO().isCurrentPlayer)
			{
				if (Singleton<InputController>.instance.isTappingStarted)
				{
					NEPGMHCINFE = TimeManager.realTimeWithoutPauses;
				}
				if (Singleton<InputController>.instance.isTapping && !ACHMJPNAIOC)
				{
					CFCAKLBNKMD = TimeManager.realTimeWithoutPauses;
					if (base.weapon.willShoot && (GAFHKNHKGPJ || EOPDJOKHPLJ))
					{
						ADEOFMHDEAO = Singleton<AimingHelper>.instance.NEEAFOMPJLH(HFNAMMBPJAJ());
						if (OOOJCFNEPIK(ADEOFMHDEAO))
						{
							MMOBPLJGHJB(ADEOFMHDEAO);
						}
					}
					else if ((float)base.weapon.JMDLKIAKOIE > 1149f && Singleton<InputController>.instance.isTappingStarted)
					{
						GuiElementSingle<InventoryGuiElement>.instance.EIKJOPHNCOM(this);
					}
					if (HFNAMMBPJAJ().isReloading || base.weapon.outOfAmmo)
					{
						JLFBKAMLIHG = true;
						Singleton<SniperScope>.instance.NOGIKDILBLG();
					}
					else if (CFCAKLBNKMD - NEPGMHCINFE > 1600f && CDKCDHLNPML() && EOPDJOKHPLJ)
					{
						Singleton<SniperScope>.instance.DFJBBKKIPAD(905f);
					}
				}
			}
			if (ACHMJPNAIOC && TimeManager.CEAFAMFNGCC() > BBILIBAPBHN + OKHIFGKIMEH)
			{
				HFNAMMBPJAJ().Fire(DEOJIJHFFEP);
				IHHGONCBBFI(DEOJIJHFFEP);
				EIOLCOEACLN();
				ACHMJPNAIOC = false;
			}
		}
		else
		{
			JLFBKAMLIHG = true;
		}
		if (Input.GetMouseButtonUp(0) && GLNCDIKMDEO().isCurrentPlayer)
		{
			Singleton<SniperScope>.instance.Hide();
			GAFHKNHKGPJ = false;
		}
	}

	[SpecialName]
	public virtual bool IONJGEOHFPJ()
	{
		return base.isActiveWeapon;
	}

	public virtual void DDFKFIELCKO()
	{
		base.OPEICEBMFLF();
		if (Input.GetMouseButtonUp(1) && GLNCDIKMDEO().isCurrentPlayer && !EOPDJOKHPLJ)
		{
			GAFHKNHKGPJ = true;
		}
		if (!GLNCDIKMDEO().PBMFJEPBNLE())
		{
			if (Singleton<GameController>.instance.KKHKIEFMENC() && GLNCDIKMDEO().isCurrentPlayer)
			{
				if (Singleton<InputController>.instance.isTappingStarted)
				{
					NEPGMHCINFE = TimeManager.realTimeWithoutPauses;
				}
				if (Singleton<InputController>.instance.isTapping && !ACHMJPNAIOC)
				{
					CFCAKLBNKMD = TimeManager.realTimeWithoutPauses;
					if (HFNAMMBPJAJ().willShoot && (GAFHKNHKGPJ || EOPDJOKHPLJ))
					{
						ADEOFMHDEAO = Singleton<AimingHelper>.instance.OHDMDJLDNOK(base.weapon);
						if (KELOGHNJDDI(ADEOFMHDEAO))
						{
							KFOFOBMOFOB(ADEOFMHDEAO);
						}
					}
					else if ((float)base.weapon.JMDLKIAKOIE > 129f && Singleton<InputController>.instance.isTappingStarted)
					{
						GuiElementSingle<InventoryGuiElement>.instance.EIKJOPHNCOM(this);
					}
					if (base.weapon.isReloading || HFNAMMBPJAJ().outOfAmmo)
					{
						JLFBKAMLIHG = true;
						Singleton<SniperScope>.instance.Hide();
					}
					else if (CFCAKLBNKMD - NEPGMHCINFE > 625f && IANCFDPBIAP() && EOPDJOKHPLJ)
					{
						Singleton<SniperScope>.instance.ECBMHNDPENI(1909f);
					}
				}
			}
			if (ACHMJPNAIOC && TimeManager.CEAFAMFNGCC() > BBILIBAPBHN + OKHIFGKIMEH)
			{
				HFNAMMBPJAJ().Fire(DEOJIJHFFEP);
				AEFMJPKANLN(DEOJIJHFFEP);
				HICJCHBHHDJ();
				ACHMJPNAIOC = false;
			}
		}
		else
		{
			JLFBKAMLIHG = true;
		}
		if (Input.GetMouseButtonUp(1) && base.playerController.isCurrentPlayer)
		{
			Singleton<SniperScope>.instance.EGJBBJMJBHO();
			GAFHKNHKGPJ = true;
		}
	}

	[SpecialName]
	public virtual bool CCHDEIHJJEK()
	{
		return base.NFJFHHCLNJP();
	}

	public virtual void MABLFMLMCPK()
	{
		base.OPEICEBMFLF();
		if (Input.GetMouseButtonUp(0) && base.playerController.isCurrentPlayer && !EOPDJOKHPLJ)
		{
			GAFHKNHKGPJ = false;
		}
		if (!GLNCDIKMDEO().clicked)
		{
			if (Singleton<GameController>.instance.KKHKIEFMENC() && GLNCDIKMDEO().isCurrentPlayer)
			{
				if (Singleton<InputController>.instance.isTappingStarted)
				{
					NEPGMHCINFE = TimeManager.realTimeWithoutPauses;
				}
				if (Singleton<InputController>.instance.isTapping && !ACHMJPNAIOC)
				{
					CFCAKLBNKMD = TimeManager.realTimeWithoutPauses;
					if (HFNAMMBPJAJ().willShoot && (GAFHKNHKGPJ || EOPDJOKHPLJ))
					{
						ADEOFMHDEAO = Singleton<AimingHelper>.instance.PBCOBBGJNPD(HFNAMMBPJAJ());
						if (OOOJCFNEPIK(ADEOFMHDEAO))
						{
							BAAGABOHHGG(ADEOFMHDEAO);
						}
					}
					else if ((float)base.weapon.JMDLKIAKOIE > 224f && Singleton<InputController>.instance.isTappingStarted)
					{
						GuiElementSingle<InventoryGuiElement>.instance.EIKJOPHNCOM(this);
					}
					if (HFNAMMBPJAJ().isReloading || HFNAMMBPJAJ().outOfAmmo)
					{
						JLFBKAMLIHG = false;
						Singleton<SniperScope>.instance.EGJBBJMJBHO();
					}
					else if (CFCAKLBNKMD - NEPGMHCINFE > 1892f && GNGJCCPAKHP() && EOPDJOKHPLJ)
					{
						Singleton<SniperScope>.instance.ECBMHNDPENI(716f);
					}
				}
			}
			if (ACHMJPNAIOC && TimeManager.realTimeWithoutPauses > BBILIBAPBHN + OKHIFGKIMEH)
			{
				HFNAMMBPJAJ().Fire(DEOJIJHFFEP);
				AEFMJPKANLN(DEOJIJHFFEP);
				EIOLCOEACLN();
				ACHMJPNAIOC = false;
			}
		}
		else
		{
			JLFBKAMLIHG = false;
		}
		if (Input.GetMouseButtonUp(0) && GLNCDIKMDEO().isCurrentPlayer)
		{
			Singleton<SniperScope>.instance.Hide();
			GAFHKNHKGPJ = false;
		}
	}

	private void KODCHCILFHL(Vector3 OEDJOFINBMI)
	{
		OKHIFGKIMEH = KGEKIGAOKFD;
		GAFHKNHKGPJ = false;
		bool flag = false;
		bool flag2 = GeometryTools.AngleSigned(base.playerController.currentPlayerPoint.point.transform.forward, OEDJOFINBMI - base.playerController.transform.position, Vector3.up) > 0f;
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
	private bool EIFJDPHFBBG()
	{
		return GGANLFIFAMK && DebugSettings.showPrimaryScopes;
	}

	[SpecialName]
	public virtual void CJMOLLLBKGK(bool IDEBKDPMPGM)
	{
		base.FHKGABMHOHI(IDEBKDPMPGM);
		if (!NFJFHHCLNJP() && GLNCDIKMDEO().isCurrentPlayer)
		{
			Singleton<SniperScope>.instance.NOGIKDILBLG();
		}
		if (NFJFHHCLNJP() && base.playerController.isCurrentPlayer)
		{
			Singleton<SniperScope>.instance.DCIPJFNIMNH(IGABBABGBFC);
		}
		ACHMJPNAIOC = false;
	}

	public virtual void LFNHGLFBNMP()
	{
		if (Input.GetMouseButtonUp(0) && GLNCDIKMDEO().isCurrentPlayer)
		{
			Singleton<SniperScope>.instance.NOGIKDILBLG();
			GAFHKNHKGPJ = false;
		}
	}

	public virtual void AGCGDPHCIAC(Vector3 MPHCNMDIPAI)
	{
		base.ANCEHNGCFHI(MPHCNMDIPAI);
		if (HFNAMMBPJAJ().willShoot && !ACHMJPNAIOC)
		{
			MMOBPLJGHJB(MPHCNMDIPAI);
		}
	}

	public virtual void IECOOJGCFGM()
	{
		if (Input.GetMouseButtonUp(1) && base.playerController.isCurrentPlayer)
		{
			Singleton<SniperScope>.instance.NLEKBKHPEJI();
			GAFHKNHKGPJ = true;
		}
	}

	[SpecialName]
	public virtual bool CJBKCMGMKBH()
	{
		return base.isActiveWeapon;
	}

	public virtual void HHOOAGBAINO()
	{
		base.OPEICEBMFLF();
		if (Input.GetMouseButtonUp(1) && base.playerController.isCurrentPlayer && !EOPDJOKHPLJ)
		{
			GAFHKNHKGPJ = false;
		}
		if (!base.playerController.PBMFJEPBNLE())
		{
			if (Singleton<GameController>.instance.KKHKIEFMENC() && base.playerController.isCurrentPlayer)
			{
				if (Singleton<InputController>.instance.isTappingStarted)
				{
					NEPGMHCINFE = TimeManager.CEAFAMFNGCC();
				}
				if (Singleton<InputController>.instance.isTapping && !ACHMJPNAIOC)
				{
					CFCAKLBNKMD = TimeManager.realTimeWithoutPauses;
					if (HFNAMMBPJAJ().willShoot && (GAFHKNHKGPJ || EOPDJOKHPLJ))
					{
						ADEOFMHDEAO = Singleton<AimingHelper>.instance.GMEGNIBBCCP(HFNAMMBPJAJ());
						if (GNONBGKLKMG(ADEOFMHDEAO))
						{
							PIDIFPGJGKF(ADEOFMHDEAO);
						}
					}
					else if ((float)HFNAMMBPJAJ().JMDLKIAKOIE > 1118f && Singleton<InputController>.instance.isTappingStarted)
					{
						GuiElementSingle<InventoryGuiElement>.instance.EIKJOPHNCOM(this);
					}
					if (HFNAMMBPJAJ().isReloading || HFNAMMBPJAJ().outOfAmmo)
					{
						JLFBKAMLIHG = false;
						Singleton<SniperScope>.instance.NLEKBKHPEJI();
					}
					else if (CFCAKLBNKMD - NEPGMHCINFE > 46f && GIPDLGAOHFI() && EOPDJOKHPLJ)
					{
						Singleton<SniperScope>.instance.ONCKKJFAMKF(1086f);
					}
				}
			}
			if (ACHMJPNAIOC && TimeManager.CEAFAMFNGCC() > BBILIBAPBHN + OKHIFGKIMEH)
			{
				base.weapon.Fire(DEOJIJHFFEP);
				AEFMJPKANLN(DEOJIJHFFEP);
				HICJCHBHHDJ();
				ACHMJPNAIOC = false;
			}
		}
		else
		{
			JLFBKAMLIHG = false;
		}
		if (Input.GetMouseButtonUp(0) && base.playerController.isCurrentPlayer)
		{
			Singleton<SniperScope>.instance.NOGIKDILBLG();
			GAFHKNHKGPJ = true;
		}
	}

	private void MMOBPLJGHJB(Vector3 OEDJOFINBMI)
	{
		OKHIFGKIMEH = KGEKIGAOKFD;
		GAFHKNHKGPJ = true;
		bool flag = false;
		bool flag2 = GeometryTools.AngleSigned(base.playerController.BBNPGJAALCJ().point.transform.forward, OEDJOFINBMI - base.playerController.transform.position, Vector3.up) > 1843f;
		Vector3 pLEBANKIBPP = OEDJOFINBMI - GLNCDIKMDEO().transform.position;
		pLEBANKIBPP.y = 450f;
		if (GLNCDIKMDEO().soldierAnimator.LIHLPCKFCCF() || base.playerController.soldierAnimator.isIdle || (GLNCDIKMDEO().playerState == PlayerController.KKPHPLOEACG.HidingBehindShield && JLFBKAMLIHG))
		{
			flag = false;
			JLFBKAMLIHG = false;
			if (GLNCDIKMDEO().soldierAnimator.LCHDJIICIBK())
			{
				OKHIFGKIMEH = GLNCDIKMDEO().GFCDMMGDFJK().hiddingTime;
			}
			else
			{
				OKHIFGKIMEH = base.playerController.soldierAnimator.uncoverLength * 1918f;
			}
			if (GLNCDIKMDEO().playerState == PlayerController.KKPHPLOEACG.HidingBehindShield)
			{
				OKHIFGKIMEH = 1857f;
			}
		}
		else if (GLNCDIKMDEO().GFCDMMGDFJK().IsShooting || GLNCDIKMDEO().GFCDMMGDFJK().isRunning)
		{
			HFNAMMBPJAJ().Fire(OEDJOFINBMI);
			AEFMJPKANLN(OEDJOFINBMI);
			EIOLCOEACLN();
		}
		if (flag2 != NCMEJJEPLCI)
		{
			NCMEJJEPLCI = flag2;
			flag = true;
			OKHIFGKIMEH = base.playerController.GFCDMMGDFJK().uncoverLength * 305f;
		}
		GLNCDIKMDEO().EIMEBEABDHF(base.weapon.BEACDIILBEG, NCMEJJEPLCI, pLEBANKIBPP);
		if (flag)
		{
			BBILIBAPBHN = TimeManager.CEAFAMFNGCC();
			DEOJIJHFFEP = OEDJOFINBMI;
			ACHMJPNAIOC = false;
		}
	}

	[SpecialName]
	public virtual bool CHLNDCEDPKL()
	{
		return base.BPAOCKIKDMH();
	}

	public virtual void KINCLALGJJD()
	{
		base.OPEICEBMFLF();
		if (Input.GetMouseButtonUp(1) && base.playerController.isCurrentPlayer && !EOPDJOKHPLJ)
		{
			GAFHKNHKGPJ = false;
		}
		if (!GLNCDIKMDEO().PBMFJEPBNLE())
		{
			if (Singleton<GameController>.instance.gameIsRunning && GLNCDIKMDEO().isCurrentPlayer)
			{
				if (Singleton<InputController>.instance.isTappingStarted)
				{
					NEPGMHCINFE = TimeManager.realTimeWithoutPauses;
				}
				if (Singleton<InputController>.instance.isTapping && !ACHMJPNAIOC)
				{
					CFCAKLBNKMD = TimeManager.realTimeWithoutPauses;
					if (base.weapon.willShoot && (GAFHKNHKGPJ || EOPDJOKHPLJ))
					{
						ADEOFMHDEAO = Singleton<AimingHelper>.instance.KBGHDKFGGHN(HFNAMMBPJAJ());
						if (KPBILMGEJPP(ADEOFMHDEAO))
						{
							CDEKJENJMEP(ADEOFMHDEAO);
						}
					}
					else if ((float)HFNAMMBPJAJ().JMDLKIAKOIE > 17f && Singleton<InputController>.instance.isTappingStarted)
					{
						GuiElementSingle<InventoryGuiElement>.instance.PlayWeaponReloading(this);
					}
					if (HFNAMMBPJAJ().isReloading || base.weapon.outOfAmmo)
					{
						JLFBKAMLIHG = false;
						Singleton<SniperScope>.instance.NLEKBKHPEJI();
					}
					else if (CFCAKLBNKMD - NEPGMHCINFE > 1231f && IANCFDPBIAP() && EOPDJOKHPLJ)
					{
						Singleton<SniperScope>.instance.ECBMHNDPENI(576f);
					}
				}
			}
			if (ACHMJPNAIOC && TimeManager.CEAFAMFNGCC() > BBILIBAPBHN + OKHIFGKIMEH)
			{
				base.weapon.Fire(DEOJIJHFFEP);
				IHHGONCBBFI(DEOJIJHFFEP);
				AFGBNEOKEEG();
				ACHMJPNAIOC = true;
			}
		}
		else
		{
			JLFBKAMLIHG = true;
		}
		if (Input.GetMouseButtonUp(1) && base.playerController.isCurrentPlayer)
		{
			Singleton<SniperScope>.instance.IFGMJHLIPJL();
			GAFHKNHKGPJ = true;
		}
	}

	[SpecialName]
	private bool LFLELFOIGPG()
	{
		return GGANLFIFAMK && DebugSettings.showPrimaryScopes;
	}

	[SpecialName]
	public virtual void DJLBLNMCOOG(bool IDEBKDPMPGM)
	{
		base.isActiveWeapon = IDEBKDPMPGM;
		if (!isActiveWeapon && base.playerController.isCurrentPlayer)
		{
			Singleton<SniperScope>.instance.IFGMJHLIPJL();
		}
		if (NFJFHHCLNJP() && GLNCDIKMDEO().isCurrentPlayer)
		{
			Singleton<SniperScope>.instance.CMBAFEKOAPH(IGABBABGBFC);
		}
		ACHMJPNAIOC = false;
	}

	[SpecialName]
	public virtual void GJGFNEEBFMK(bool IDEBKDPMPGM)
	{
		base.FHKGABMHOHI(IDEBKDPMPGM);
		if (!isActiveWeapon && base.playerController.isCurrentPlayer)
		{
			Singleton<SniperScope>.instance.IFGMJHLIPJL();
		}
		if (BPAOCKIKDMH() && GLNCDIKMDEO().isCurrentPlayer)
		{
			Singleton<SniperScope>.instance.LAPHAJIOIAE(IGABBABGBFC);
		}
		ACHMJPNAIOC = false;
	}

	[SpecialName]
	private bool APELEHKEKPK()
	{
		return !GGANLFIFAMK || DebugSettings.showPrimaryScopes;
	}

	[SpecialName]
	public virtual void IDANPPFOLJD(bool IDEBKDPMPGM)
	{
		base.FHKGABMHOHI(IDEBKDPMPGM);
		if (!isActiveWeapon && base.playerController.isCurrentPlayer)
		{
			Singleton<SniperScope>.instance.EGJBBJMJBHO();
		}
		if (NFJFHHCLNJP() && base.playerController.isCurrentPlayer)
		{
			Singleton<SniperScope>.instance.KMBOLDEIBOH(IGABBABGBFC);
		}
		ACHMJPNAIOC = false;
	}

	[SpecialName]
	public virtual bool CEFLIPOJDPL()
	{
		return base.OHKDJNIADMF();
	}

	public virtual void JGFCPHKDHOG()
	{
		if (Input.GetMouseButtonUp(0) && GLNCDIKMDEO().isCurrentPlayer)
		{
			Singleton<SniperScope>.instance.NLEKBKHPEJI();
			GAFHKNHKGPJ = true;
		}
	}

	public virtual void HDPLMDKEGFC(Vector3 MPHCNMDIPAI)
	{
		base.ANCEHNGCFHI(MPHCNMDIPAI);
		if (base.weapon.willShoot && !ACHMJPNAIOC)
		{
			BAAGABOHHGG(MPHCNMDIPAI);
		}
	}

	[SpecialName]
	public virtual void GMAHCBGFIKJ(bool IDEBKDPMPGM)
	{
		base.IJNFCDPPENM(IDEBKDPMPGM);
		if (!OHKDJNIADMF() && base.playerController.isCurrentPlayer)
		{
			Singleton<SniperScope>.instance.IFGMJHLIPJL();
		}
		if (NFJFHHCLNJP() && base.playerController.isCurrentPlayer)
		{
			Singleton<SniperScope>.instance.DCIPJFNIMNH(IGABBABGBFC);
		}
		ACHMJPNAIOC = false;
	}

	public virtual void OCHIGPGMFKB()
	{
		if (Input.GetMouseButtonUp(0) && base.playerController.isCurrentPlayer)
		{
			Singleton<SniperScope>.instance.NOGIKDILBLG();
			GAFHKNHKGPJ = true;
		}
	}
}
