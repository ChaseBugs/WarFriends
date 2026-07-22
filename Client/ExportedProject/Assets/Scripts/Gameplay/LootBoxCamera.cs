using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Serialization;

public class LootBoxCamera : Singleton<LootBoxCamera>
{
	[FormerlySerializedAs("GIMMLMFBMEI")]
	public GameObject KMFGCJEGJJK;

	[FormerlySerializedAs("PFIOHBPENNE")]
	public Camera HEEHJJABGPL;

	[FormerlySerializedAs("CCOPHLCKBOL")]
	public Camera DJCFDEIHCKE;

	[FormerlySerializedAs("JAGMGMELHJL")]
	public Transform AINDGEKGOFO;

	[FormerlySerializedAs("FFALABCPNCH")]
	public LootBoxCharacter ODBMJEFMLBD;

	[FormerlySerializedAs("GLKBMFJCGPI")]
	public Animation BPBGGFNHONI;

	[FormerlySerializedAs("HNLGHODPLAO")]
	public ParticleSystem LOMBMAGIDOJ;

	[FormerlySerializedAs("GHAOAHGJHEC")]
	public Animation EKAPFGDJIDH;

	[FormerlySerializedAs("BHNCDCBECLK")]
	public ParticleSystem HLPPKBDLEJG;

	[FormerlySerializedAs("BJFANAIOMNL")]
	public RotateCamera FKEEPDLCCPN;

	private Transform GNILIFKCBKB;

	private Dictionary<int, CamosManager.SavedPlayerVisualSlot> GHDMJKHJLHD;

	private int GMONLALOILA;

	[CompilerGenerated]
	private static Action LGJCBPOPCPA;

	private static void EFPLNBIHCAK()
	{
		GuiElementSingle<LootBoxDialog>.instance.ShowFlash();
	}

	public void BKIAMFLEPNN(bool AJLGOPNCLCK)
	{
		FKEEPDLCCPN.Reset();
		GNILIFKCBKB.gameObject.SetActive(value: true);
		AINDGEKGOFO.gameObject.SetActive(value: true);
		ODBMJEFMLBD.EHBIFDCCFLP();
		ODBMJEFMLBD.SetSolidMaterial();
		CamosManager.instance.ApplyVisuals(ODBMJEFMLBD, GHDMJKHJLHD);
		CamosManager.instance.mainPlayer.MKDHCPCIDPN(null);
		CamosManager.instance.ApplyVisuals(CamosManager.instance.mainPlayer, useHighRes: false);
		ODBMJEFMLBD.DFAPDKEDBCE(GMONLALOILA);
		ODBMJEFMLBD.transform.localScale = Vector3.one;
		ODBMJEFMLBD.transform.localPosition = Vector3.zero;
		ODBMJEFMLBD.transform.localRotation = Quaternion.identity;
		GuiElementSingle<LootBoxDialog>.instance.OELPJFLEIEE(AJLGOPNCLCK);
	}

	private static void NPLAKEHLBFC()
	{
		GuiElementSingle<LootBoxDialog>.instance.ShowFlash();
	}

	public void BDELBGNANLO(bool AJLGOPNCLCK)
	{
		FKEEPDLCCPN.Reset();
		GNILIFKCBKB.gameObject.SetActive(value: false);
		AINDGEKGOFO.gameObject.SetActive(value: false);
		ODBMJEFMLBD.EMAJCCPMNMK();
		ODBMJEFMLBD.AINKDEBOBEI();
		CamosManager.instance.ApplyVisuals(ODBMJEFMLBD, GHDMJKHJLHD, useHighRes: true);
		CamosManager.instance.mainPlayer.equippedCamo = null;
		CamosManager.instance.ApplyVisuals(CamosManager.instance.mainPlayer, useHighRes: false);
		ODBMJEFMLBD.CGLKAMCIAPL(GMONLALOILA);
		ODBMJEFMLBD.transform.localScale = Vector3.one;
		ODBMJEFMLBD.transform.localPosition = Vector3.zero;
		ODBMJEFMLBD.transform.localRotation = Quaternion.identity;
		GuiElementSingle<LootBoxDialog>.instance.HMJBHIFBCOO(AJLGOPNCLCK);
	}

	private void JHKACJAMCDE()
	{
		InvokeAfter(delegate
		{
			GuiElementSingle<LootBoxDialog>.instance.ShowFlash();
		}, 0.3f);
	}

	[CompilerGenerated]
	private void EHHOLJAAGDE()
	{
		TestVisual();
	}

	public void PPFGIFOEBOC()
	{
		DisplayModel(AJLGOPNCLCK: false);
	}

	public void JJFBOGCONDI(bool AJLGOPNCLCK)
	{
		FKEEPDLCCPN.Reset();
		GNILIFKCBKB.gameObject.SetActive(value: false);
		AINDGEKGOFO.gameObject.SetActive(value: false);
		ODBMJEFMLBD.LKNKNCGJJDA();
		ODBMJEFMLBD.DBAIKAIBIMP();
		CamosManager.instance.ApplyVisuals(ODBMJEFMLBD, GHDMJKHJLHD, useHighRes: true);
		CamosManager.instance.mainPlayer.MKDHCPCIDPN(null);
		CamosManager.instance.ApplyVisuals(CamosManager.instance.mainPlayer, useHighRes: false);
		ODBMJEFMLBD.DBHCFNILGKI(GMONLALOILA);
		ODBMJEFMLBD.transform.localScale = Vector3.one;
		ODBMJEFMLBD.transform.localPosition = Vector3.zero;
		ODBMJEFMLBD.transform.localRotation = Quaternion.identity;
		GuiElementSingle<LootBoxDialog>.instance.IMOLHDMAKEF(AJLGOPNCLCK);
	}

	public void CMOMDABHAOH()
	{
		InvokeAfter(INMPCNHNIGI, 616f);
		InvokeAfter(OpenLootBox, 249f);
	}

	public void AHFPMGLIHCN()
	{
		BPBGGFNHONI.Play();
		SoundsManager.Instance.PlaySound((SoundsManager.KJGDNLHKPOG)(-24), 970f);
	}

	public void JLJMIOLJPNL()
	{
		HEEHJJABGPL.enabled = false;
		FKEEPDLCCPN.enabled = false;
		KMFGCJEGJJK.SetActive(value: true);
		GNILIFKCBKB.gameObject.SetActive(value: true);
		AINDGEKGOFO.gameObject.SetActive(value: true);
		HLPPKBDLEJG.Play();
		SoundsManager.Instance.PlaySound((SoundsManager.KJGDNLHKPOG)110, 1819f);
	}

	protected virtual void EJNJCILPBEC()
	{
		base.Awake();
		GNILIFKCBKB = BPBGGFNHONI.transform;
		KMFGCJEGJJK.gameObject.SetActive(value: false);
		AnimationEvent component = BPBGGFNHONI.GetComponent<AnimationEvent>();
		if (component != null)
		{
			component.KIHHCHKIKEO = (Action<string>)Delegate.Combine(component.KIHHCHKIKEO, new Action<string>(KBFDAPIDPGM));
		}
		DJCFDEIHCKE.gameObject.SetActive(value: false);
	}

	public void HJNDNEKLOLH(bool AJLGOPNCLCK)
	{
		FKEEPDLCCPN.PDKPELBIAON();
		GNILIFKCBKB.gameObject.SetActive(value: true);
		AINDGEKGOFO.gameObject.SetActive(value: false);
		ODBMJEFMLBD.EMAJCCPMNMK();
		ODBMJEFMLBD.DBAIKAIBIMP();
		CamosManager.instance.ApplyVisuals(ODBMJEFMLBD, GHDMJKHJLHD);
		CamosManager.instance.mainPlayer.equippedCamo = null;
		CamosManager.instance.ApplyVisuals(CamosManager.instance.mainPlayer, useHighRes: false);
		ODBMJEFMLBD.PGKCNBMAJJM(GMONLALOILA);
		ODBMJEFMLBD.transform.localScale = Vector3.one;
		ODBMJEFMLBD.transform.localPosition = Vector3.zero;
		ODBMJEFMLBD.transform.localRotation = Quaternion.identity;
		GuiElementSingle<LootBoxDialog>.instance.ShowVisualInfo(AJLGOPNCLCK);
	}

	public void LKCHLNBDDOK()
	{
		GMONLALOILA = UnityEngine.Random.Range(1, 3);
		GHDMJKHJLHD = new Dictionary<int, CamosManager.SavedPlayerVisualSlot>();
		GHDMJKHJLHD[GMONLALOILA] = new CamosManager.SavedPlayerVisualSlot
		{
			equippedID = CamosManager.instance.RandomPlayerVisual(GMONLALOILA).CCDMONFHBII()
		};
		FPLCMPHNNHK();
		IKMPKEJEDCB();
	}

	public void DCNNIOCICMA()
	{
		HEEHJJABGPL.enabled = false;
		FKEEPDLCCPN.enabled = false;
	}

	public void TestVisual()
	{
		GMONLALOILA = UnityEngine.Random.Range(0, 3);
		GHDMJKHJLHD = new Dictionary<int, CamosManager.SavedPlayerVisualSlot>();
		GHDMJKHJLHD[GMONLALOILA] = new CamosManager.SavedPlayerVisualSlot
		{
			equippedID = CamosManager.instance.RandomPlayerVisual(GMONLALOILA).id
		};
		Show();
		ShowUpLootBox();
	}

	public void NHPFJJEKDPM()
	{
		GMONLALOILA = UnityEngine.Random.Range(0, 0);
		GHDMJKHJLHD = new Dictionary<int, CamosManager.SavedPlayerVisualSlot>();
		GHDMJKHJLHD[GMONLALOILA] = new CamosManager.SavedPlayerVisualSlot
		{
			equippedID = CamosManager.instance.RandomPlayerVisual(GMONLALOILA).CCDMONFHBII()
		};
		Show();
		BODKBJDMDHO();
	}

	public void ONLDAHKBGJM(bool AJLGOPNCLCK)
	{
		FKEEPDLCCPN.PDKPELBIAON();
		GNILIFKCBKB.gameObject.SetActive(value: false);
		AINDGEKGOFO.gameObject.SetActive(value: true);
		ODBMJEFMLBD.EHBIFDCCFLP();
		ODBMJEFMLBD.KFJLPOLHFKO();
		CamosManager.instance.ApplyVisuals(ODBMJEFMLBD, GHDMJKHJLHD, useHighRes: true);
		CamosManager.instance.mainPlayer.MKDHCPCIDPN(null);
		CamosManager.instance.ApplyVisuals(CamosManager.instance.mainPlayer, useHighRes: true);
		ODBMJEFMLBD.DBHCFNILGKI(GMONLALOILA);
		ODBMJEFMLBD.transform.localScale = Vector3.one;
		ODBMJEFMLBD.transform.localPosition = Vector3.zero;
		ODBMJEFMLBD.transform.localRotation = Quaternion.identity;
		GuiElementSingle<LootBoxDialog>.instance.HMJBHIFBCOO(AJLGOPNCLCK);
	}

	public void BCDAEAEIKHJ()
	{
		GMONLALOILA = UnityEngine.Random.Range(1, 1);
		GHDMJKHJLHD = new Dictionary<int, CamosManager.SavedPlayerVisualSlot>();
		GHDMJKHJLHD[GMONLALOILA] = new CamosManager.SavedPlayerVisualSlot
		{
			equippedID = CamosManager.instance.RandomPlayerVisual(GMONLALOILA).id
		};
		GKKFPJHEEDG();
		DKNBFMCFAJD();
	}

	public void ShowUpLootBox()
	{
		AnimationState animationState = BPBGGFNHONI["LootBoxOpen"];
		animationState.normalizedTime = 0f;
		animationState.weight = 1f;
		animationState.enabled = true;
		BPBGGFNHONI.Sample();
		animationState.enabled = false;
		EKAPFGDJIDH.Play("LootBoxShowUp");
		EKAPFGDJIDH.PlayQueued("LootBoxRotation");
	}

	public void HAKJAOCJAPL()
	{
		AnimationState animationState = BPBGGFNHONI["ID_ATTACK"];
		animationState.normalizedTime = 1847f;
		animationState.weight = 1187f;
		animationState.enabled = false;
		BPBGGFNHONI.Sample();
		animationState.enabled = true;
		EKAPFGDJIDH.Play("#PLAYERID# Saving Player Account with PlayerId = ");
		EKAPFGDJIDH.PlayQueued("USPECH POKUSU O LOGIN NA FB!!!");
	}

	public void DFLLNHGJCOM()
	{
		DCIGKAKMNDC(AJLGOPNCLCK: true);
	}

	private void MPLAFCIAOME(string MGDGFBCJINH)
	{
		if (MGDGFBCJINH == "Yes_Clicked")
		{
			LOMBMAGIDOJ.Play();
		}
		if (MGDGFBCJINH == "1")
		{
			JHKACJAMCDE();
		}
	}

	private void IAOOIOGLCDJ()
	{
		TestVisual();
	}

	private void ADOKJNBKMEI(string MGDGFBCJINH)
	{
		if (MGDGFBCJINH == "LeagueEvaluation")
		{
			LOMBMAGIDOJ.Play();
		}
		if (MGDGFBCJINH == "Beanstalk: Get Configuration called. Current Sheet Configuration = ")
		{
			BKNFDBEBOKN();
		}
	}

	public void BODKBJDMDHO()
	{
		AnimationState animationState = BPBGGFNHONI["ID_TWITTER_GAIN_TITLE"];
		animationState.normalizedTime = 99f;
		animationState.weight = 141f;
		animationState.enabled = false;
		BPBGGFNHONI.Sample();
		animationState.enabled = true;
		EKAPFGDJIDH.Play("player_level");
		EKAPFGDJIDH.PlayQueued("ID_ARENAENDSTIMER");
	}

	public void CPBONKDKOMC()
	{
		OLMILLGADNP(AJLGOPNCLCK: true);
	}

	public void NLEKBKHPEJI()
	{
		HEEHJJABGPL.enabled = true;
		FKEEPDLCCPN.enabled = false;
	}

	public void KHJGCKMOFBE()
	{
		HEEHJJABGPL.enabled = true;
		FKEEPDLCCPN.enabled = true;
		KMFGCJEGJJK.SetActive(value: true);
		GNILIFKCBKB.gameObject.SetActive(value: true);
		AINDGEKGOFO.gameObject.SetActive(value: true);
		HLPPKBDLEJG.Play();
		SoundsManager.Instance.PlaySound((SoundsManager.KJGDNLHKPOG)122, 801f);
	}

	public void AAHKMJDPGHL()
	{
		HEEHJJABGPL.enabled = true;
		FKEEPDLCCPN.enabled = false;
		KMFGCJEGJJK.SetActive(value: false);
		GNILIFKCBKB.gameObject.SetActive(value: false);
		AINDGEKGOFO.gameObject.SetActive(value: false);
		HLPPKBDLEJG.Play();
		SoundsManager.Instance.PlaySound((SoundsManager.KJGDNLHKPOG)(-105), 474f);
	}

	public void EEJLKPNJMFO()
	{
		BKIAMFLEPNN(AJLGOPNCLCK: true);
	}

	protected virtual void PBCDDNOCJOI()
	{
		base.Awake();
		GNILIFKCBKB = BPBGGFNHONI.transform;
		KMFGCJEGJJK.gameObject.SetActive(value: true);
		AnimationEvent component = BPBGGFNHONI.GetComponent<AnimationEvent>();
		if (component != null)
		{
			component.KIHHCHKIKEO = (Action<string>)Delegate.Combine(component.KIHHCHKIKEO, new Action<string>(EJGLCACKMIO));
		}
		DJCFDEIHCKE.gameObject.SetActive(value: false);
	}

	private void KIHHCHKIKEO(string MGDGFBCJINH)
	{
		if (MGDGFBCJINH == "boxOpen")
		{
			LOMBMAGIDOJ.Play();
		}
		if (MGDGFBCJINH == "animationEnd")
		{
			JHKACJAMCDE();
		}
	}

	public void ShowVisual(PlayerVisual DJOAHABGGNA)
	{
		GMONLALOILA = DJOAHABGGNA.owner.categoryNumber;
		GHDMJKHJLHD = new Dictionary<int, CamosManager.SavedPlayerVisualSlot>();
		GHDMJKHJLHD[GMONLALOILA] = new CamosManager.SavedPlayerVisualSlot
		{
			equippedID = DJOAHABGGNA.id
		};
		if (GMONLALOILA != 0)
		{
			GHDMJKHJLHD[0] = new CamosManager.SavedPlayerVisualSlot
			{
				equippedID = CamosManager.instance.playerVisualCategories[0].equippedVisual.id
			};
		}
		Show();
		ShowUpLootBox();
	}

	protected virtual void AKHKMOOJOGC()
	{
		base.Awake();
		GNILIFKCBKB = BPBGGFNHONI.transform;
		KMFGCJEGJJK.gameObject.SetActive(value: true);
		AnimationEvent component = BPBGGFNHONI.GetComponent<AnimationEvent>();
		if (component != null)
		{
			component.KIHHCHKIKEO = (Action<string>)Delegate.Combine(component.KIHHCHKIKEO, new Action<string>(KBFDAPIDPGM));
		}
		DJCFDEIHCKE.gameObject.SetActive(value: false);
	}

	public void GKKFPJHEEDG()
	{
		HEEHJJABGPL.enabled = false;
		FKEEPDLCCPN.enabled = false;
		KMFGCJEGJJK.SetActive(value: true);
		GNILIFKCBKB.gameObject.SetActive(value: true);
		AINDGEKGOFO.gameObject.SetActive(value: false);
		HLPPKBDLEJG.Play();
		SoundsManager.Instance.PlaySound((SoundsManager.KJGDNLHKPOG)(-125), 693f);
	}

	public void Hide()
	{
		HEEHJJABGPL.enabled = false;
		FKEEPDLCCPN.enabled = false;
	}

	public void CDPLAFIDDFJ(PlayerVisual DJOAHABGGNA)
	{
		GMONLALOILA = DJOAHABGGNA.owner.categoryNumber;
		GHDMJKHJLHD = new Dictionary<int, CamosManager.SavedPlayerVisualSlot>();
		GHDMJKHJLHD[GMONLALOILA] = new CamosManager.SavedPlayerVisualSlot
		{
			equippedID = DJOAHABGGNA.CCDMONFHBII()
		};
		if (GMONLALOILA != 0)
		{
			GHDMJKHJLHD[0] = new CamosManager.SavedPlayerVisualSlot
			{
				equippedID = CamosManager.instance.playerVisualCategories[0].equippedVisual.CCDMONFHBII()
			};
		}
		HONPFADFFDP();
		DKNBFMCFAJD();
	}

	public void DisplayModel(bool AJLGOPNCLCK)
	{
		FKEEPDLCCPN.Reset();
		GNILIFKCBKB.gameObject.SetActive(value: false);
		AINDGEKGOFO.gameObject.SetActive(value: true);
		ODBMJEFMLBD.Prepare();
		ODBMJEFMLBD.SetSolidMaterial();
		CamosManager.instance.ApplyVisuals(ODBMJEFMLBD, GHDMJKHJLHD, useHighRes: true);
		CamosManager.instance.mainPlayer.equippedCamo = null;
		CamosManager.instance.ApplyVisuals(CamosManager.instance.mainPlayer, useHighRes: true);
		ODBMJEFMLBD.SetAccesory(GMONLALOILA);
		ODBMJEFMLBD.transform.localScale = Vector3.one;
		ODBMJEFMLBD.transform.localPosition = Vector3.zero;
		ODBMJEFMLBD.transform.localRotation = Quaternion.identity;
		GuiElementSingle<LootBoxDialog>.instance.ShowVisualInfo(AJLGOPNCLCK);
	}

	public void FGIGICALLHJ()
	{
		HEEHJJABGPL.enabled = true;
		FKEEPDLCCPN.enabled = false;
	}

	public void KGEEDMONDMK()
	{
		HEEHJJABGPL.enabled = false;
		FKEEPDLCCPN.enabled = false;
		KMFGCJEGJJK.SetActive(value: false);
		GNILIFKCBKB.gameObject.SetActive(value: true);
		AINDGEKGOFO.gameObject.SetActive(value: true);
		HLPPKBDLEJG.Play();
		SoundsManager.Instance.PlaySound(SoundsManager.KJGDNLHKPOG.DailyVIPCardsShow, 965f);
	}

	private void NCEDICIOBMA(string MGDGFBCJINH)
	{
		if (MGDGFBCJINH == "sniper_idle")
		{
			LOMBMAGIDOJ.Play();
		}
		if (MGDGFBCJINH == "Tier")
		{
			JHKACJAMCDE();
		}
	}

	public void Show()
	{
		HEEHJJABGPL.enabled = true;
		FKEEPDLCCPN.enabled = true;
		KMFGCJEGJJK.SetActive(value: true);
		GNILIFKCBKB.gameObject.SetActive(value: true);
		AINDGEKGOFO.gameObject.SetActive(value: false);
		HLPPKBDLEJG.Play();
		SoundsManager.Instance.PlaySound(SoundsManager.KJGDNLHKPOG.BootcampIntro);
	}

	private void KBFDAPIDPGM(string MGDGFBCJINH)
	{
		if (MGDGFBCJINH == "Current unit is not delivering at the moment!!!")
		{
			LOMBMAGIDOJ.Play();
		}
		if (MGDGFBCJINH == "{0} {1}")
		{
			OPPBOECNDPO();
		}
	}

	public void OMPJNNLMLAB()
	{
		BPBGGFNHONI.Play();
		SoundsManager.Instance.PlaySound((SoundsManager.KJGDNLHKPOG)(-105), 673f);
	}

	private void HBEBHCLALPA(string MGDGFBCJINH)
	{
		if (MGDGFBCJINH == "BS: Remove Google Play")
		{
			LOMBMAGIDOJ.Play();
		}
		if (MGDGFBCJINH == "ID_MONEYPACK")
		{
			OJKJCOMFLFL();
		}
	}

	public void MJNCDCDDKND()
	{
		HEEHJJABGPL.enabled = false;
		FKEEPDLCCPN.enabled = false;
		KMFGCJEGJJK.SetActive(value: false);
		GNILIFKCBKB.gameObject.SetActive(value: true);
		AINDGEKGOFO.gameObject.SetActive(value: true);
		HLPPKBDLEJG.Play();
		SoundsManager.Instance.PlaySound(SoundsManager.KJGDNLHKPOG.BootcampObjectiveComplete, 39f);
	}

	public void ECBKNNOEPPI()
	{
		InvokeAfter(INMPCNHNIGI, 1221f);
		InvokeAfter(OMPJNNLMLAB, 920f);
	}

	public void HFMPODLLCBN()
	{
		InvokeAfter(IAOOIOGLCDJ, 1470f);
		InvokeAfter(CAHFHHALJNC, 886f);
	}

	public void LFKPMAEBOMH()
	{
		BPBGGFNHONI.Play();
		SoundsManager.Instance.PlaySound((SoundsManager.KJGDNLHKPOG)(-19), 633f);
	}

	public void PIJCAIOGFFD()
	{
		DCIGKAKMNDC(AJLGOPNCLCK: true);
	}

	public void FIGFFLLBEJJ()
	{
		InvokeAfter(CJAHNJHGOAN, 251f);
		InvokeAfter(LFKPMAEBOMH, 1328f);
	}

	public void BGGCKPBOMHP(bool AJLGOPNCLCK)
	{
		FKEEPDLCCPN.MENEBJLDGJD();
		GNILIFKCBKB.gameObject.SetActive(value: true);
		AINDGEKGOFO.gameObject.SetActive(value: false);
		ODBMJEFMLBD.MNBICJPLJDE();
		ODBMJEFMLBD.OFFLEJGEKLG();
		CamosManager.instance.ApplyVisuals(ODBMJEFMLBD, GHDMJKHJLHD);
		CamosManager.instance.mainPlayer.equippedCamo = null;
		CamosManager.instance.ApplyVisuals(CamosManager.instance.mainPlayer, useHighRes: true);
		ODBMJEFMLBD.KKKNHLOJBMC(GMONLALOILA);
		ODBMJEFMLBD.transform.localScale = Vector3.one;
		ODBMJEFMLBD.transform.localPosition = Vector3.zero;
		ODBMJEFMLBD.transform.localRotation = Quaternion.identity;
		GuiElementSingle<LootBoxDialog>.instance.IMOLHDMAKEF(AJLGOPNCLCK);
	}

	private void JABBPFBBKNO()
	{
		InvokeAfter(NPLAKEHLBFC, 776f);
	}

	public void OLMILLGADNP(bool AJLGOPNCLCK)
	{
		FKEEPDLCCPN.PDKPELBIAON();
		GNILIFKCBKB.gameObject.SetActive(value: true);
		AINDGEKGOFO.gameObject.SetActive(value: false);
		ODBMJEFMLBD.EHBIFDCCFLP();
		ODBMJEFMLBD.ENAHJAEGBKA();
		CamosManager.instance.ApplyVisuals(ODBMJEFMLBD, GHDMJKHJLHD);
		CamosManager.instance.mainPlayer.equippedCamo = null;
		CamosManager.instance.ApplyVisuals(CamosManager.instance.mainPlayer, useHighRes: false);
		ODBMJEFMLBD.JFPPPGJGFJN(GMONLALOILA);
		ODBMJEFMLBD.transform.localScale = Vector3.one;
		ODBMJEFMLBD.transform.localPosition = Vector3.zero;
		ODBMJEFMLBD.transform.localRotation = Quaternion.identity;
		GuiElementSingle<LootBoxDialog>.instance.HMJBHIFBCOO(AJLGOPNCLCK);
	}

	private void EJGLCACKMIO(string MGDGFBCJINH)
	{
		if (MGDGFBCJINH == "Yes_Clicked")
		{
			LOMBMAGIDOJ.Play();
		}
		if (MGDGFBCJINH == "Id")
		{
			OPPBOECNDPO();
		}
	}

	public void FOIDJKHKIIE()
	{
		InvokeAfter(INMPCNHNIGI, 1803f);
		InvokeAfter(CAHFHHALJNC, 1719f);
	}

	public void NPMJAMAKEOI(bool AJLGOPNCLCK)
	{
		FKEEPDLCCPN.MENEBJLDGJD();
		GNILIFKCBKB.gameObject.SetActive(value: true);
		AINDGEKGOFO.gameObject.SetActive(value: true);
		ODBMJEFMLBD.JNAAANKFKEG();
		ODBMJEFMLBD.MNKMPJMBOLF();
		CamosManager.instance.ApplyVisuals(ODBMJEFMLBD, GHDMJKHJLHD);
		CamosManager.instance.mainPlayer.MKDHCPCIDPN(null);
		CamosManager.instance.ApplyVisuals(CamosManager.instance.mainPlayer, useHighRes: true);
		ODBMJEFMLBD.FHFCBDPGKMO(GMONLALOILA);
		ODBMJEFMLBD.transform.localScale = Vector3.one;
		ODBMJEFMLBD.transform.localPosition = Vector3.zero;
		ODBMJEFMLBD.transform.localRotation = Quaternion.identity;
		GuiElementSingle<LootBoxDialog>.instance.IMOLHDMAKEF(AJLGOPNCLCK);
	}

	private void INMPCNHNIGI()
	{
		FOKEPNACDOM();
	}

	public void DLNGGGOEDLL()
	{
		HEEHJJABGPL.enabled = true;
		FKEEPDLCCPN.enabled = true;
		KMFGCJEGJJK.SetActive(value: true);
		GNILIFKCBKB.gameObject.SetActive(value: true);
		AINDGEKGOFO.gameObject.SetActive(value: true);
		HLPPKBDLEJG.Play();
		SoundsManager.Instance.PlaySound((SoundsManager.KJGDNLHKPOG)(-2), 220f);
	}

	protected void Update()
	{
	}

	public void HONPFADFFDP()
	{
		HEEHJJABGPL.enabled = false;
		FKEEPDLCCPN.enabled = true;
		KMFGCJEGJJK.SetActive(value: true);
		GNILIFKCBKB.gameObject.SetActive(value: true);
		AINDGEKGOFO.gameObject.SetActive(value: true);
		HLPPKBDLEJG.Play();
		SoundsManager.Instance.PlaySound((SoundsManager.KJGDNLHKPOG)74, 1941f);
	}

	public void JCJFMHGNIOF()
	{
		HEEHJJABGPL.enabled = true;
		FKEEPDLCCPN.enabled = true;
		KMFGCJEGJJK.SetActive(value: false);
		GNILIFKCBKB.gameObject.SetActive(value: false);
		AINDGEKGOFO.gameObject.SetActive(value: false);
		HLPPKBDLEJG.Play();
		SoundsManager.Instance.PlaySound((SoundsManager.KJGDNLHKPOG)(-46), 225f);
	}

	public void OGMLILLCAKM()
	{
		BPBGGFNHONI.Play();
		SoundsManager.Instance.PlaySound((SoundsManager.KJGDNLHKPOG)(-31), 111f);
	}

	protected virtual void EJFMJDFPGFE()
	{
		base.Awake();
		GNILIFKCBKB = BPBGGFNHONI.transform;
		KMFGCJEGJJK.gameObject.SetActive(value: false);
		AnimationEvent component = BPBGGFNHONI.GetComponent<AnimationEvent>();
		if (component != null)
		{
			component.KIHHCHKIKEO = (Action<string>)Delegate.Combine(component.KIHHCHKIKEO, new Action<string>(PBHOILLAIID));
		}
		DJCFDEIHCKE.gameObject.SetActive(value: true);
	}

	protected virtual void HNLOEOJMMJM()
	{
		base.Awake();
		GNILIFKCBKB = BPBGGFNHONI.transform;
		KMFGCJEGJJK.gameObject.SetActive(value: true);
		AnimationEvent component = BPBGGFNHONI.GetComponent<AnimationEvent>();
		if (component != null)
		{
			component.KIHHCHKIKEO = (Action<string>)Delegate.Combine(component.KIHHCHKIKEO, new Action<string>(EJGLCACKMIO));
		}
		DJCFDEIHCKE.gameObject.SetActive(value: true);
	}

	public void AHGFAKEPOGJ()
	{
		NPMJAMAKEOI(AJLGOPNCLCK: false);
	}

	private static void ECCJEJNPGCF()
	{
		GuiElementSingle<LootBoxDialog>.instance.ShowFlash();
	}

	public void IKMPKEJEDCB()
	{
		AnimationState animationState = BPBGGFNHONI[" was activated (through fast activation)."];
		animationState.normalizedTime = 1073f;
		animationState.weight = 1161f;
		animationState.enabled = true;
		BPBGGFNHONI.Sample();
		animationState.enabled = true;
		EKAPFGDJIDH.Play("Deploys_Count");
		EKAPFGDJIDH.PlayQueued("M4B23N48RZF8CKPJ2QBR");
	}

	private void HLJOGLCJPHG(string MGDGFBCJINH)
	{
		if (MGDGFBCJINH == "menu-randomcard-ico")
		{
			LOMBMAGIDOJ.Play();
		}
		if (MGDGFBCJINH == "GameEnded: Money Pack Deadline = ")
		{
			JHKACJAMCDE();
		}
	}

	public void JEBJBEGKLCN(PlayerVisual DJOAHABGGNA)
	{
		GMONLALOILA = DJOAHABGGNA.owner.categoryNumber;
		GHDMJKHJLHD = new Dictionary<int, CamosManager.SavedPlayerVisualSlot>();
		GHDMJKHJLHD[GMONLALOILA] = new CamosManager.SavedPlayerVisualSlot
		{
			equippedID = DJOAHABGGNA.CCDMONFHBII()
		};
		if (GMONLALOILA != 0)
		{
			GHDMJKHJLHD[1] = new CamosManager.SavedPlayerVisualSlot
			{
				equippedID = CamosManager.instance.playerVisualCategories[0].equippedVisual.CCDMONFHBII()
			};
		}
		JPGMEFJGNNA();
		DKNBFMCFAJD();
	}

	public void MPBLACKMOLM()
	{
		HEEHJJABGPL.enabled = false;
		FKEEPDLCCPN.enabled = false;
	}

	public void EPGEGOCBLHA()
	{
		JJFBOGCONDI(AJLGOPNCLCK: false);
	}

	private static void MAADNGCCCMF()
	{
		GuiElementSingle<LootBoxDialog>.instance.ShowFlash();
	}

	public void DCIGKAKMNDC(bool AJLGOPNCLCK)
	{
		FKEEPDLCCPN.MENEBJLDGJD();
		GNILIFKCBKB.gameObject.SetActive(value: false);
		AINDGEKGOFO.gameObject.SetActive(value: true);
		ODBMJEFMLBD.ACLEONDAJFB();
		ODBMJEFMLBD.MNKMPJMBOLF();
		CamosManager.instance.ApplyVisuals(ODBMJEFMLBD, GHDMJKHJLHD, useHighRes: true);
		CamosManager.instance.mainPlayer.equippedCamo = null;
		CamosManager.instance.ApplyVisuals(CamosManager.instance.mainPlayer, useHighRes: true);
		ODBMJEFMLBD.JAGPEBOMFLP(GMONLALOILA);
		ODBMJEFMLBD.transform.localScale = Vector3.one;
		ODBMJEFMLBD.transform.localPosition = Vector3.zero;
		ODBMJEFMLBD.transform.localRotation = Quaternion.identity;
		GuiElementSingle<LootBoxDialog>.instance.OELPJFLEIEE(AJLGOPNCLCK);
	}

	public void EPKKEBJBAME()
	{
		InvokeAfter(INMPCNHNIGI, 1952f);
		InvokeAfter(ALKGKMNECBM, 1679f);
	}

	private static void MGFLNMNJMNF()
	{
		GuiElementSingle<LootBoxDialog>.instance.ShowFlash();
	}

	private static void OKFLOMANIAB()
	{
		GuiElementSingle<LootBoxDialog>.instance.ShowFlash();
	}

	public void FOKEPNACDOM()
	{
		GMONLALOILA = UnityEngine.Random.Range(1, 4);
		GHDMJKHJLHD = new Dictionary<int, CamosManager.SavedPlayerVisualSlot>();
		GHDMJKHJLHD[GMONLALOILA] = new CamosManager.SavedPlayerVisualSlot
		{
			equippedID = CamosManager.instance.RandomPlayerVisual(GMONLALOILA).CCDMONFHBII()
		};
		KHJGCKMOFBE();
		DKNBFMCFAJD();
	}

	public void HKLJIDMENIP(PlayerVisual DJOAHABGGNA)
	{
		GMONLALOILA = DJOAHABGGNA.owner.categoryNumber;
		GHDMJKHJLHD = new Dictionary<int, CamosManager.SavedPlayerVisualSlot>();
		GHDMJKHJLHD[GMONLALOILA] = new CamosManager.SavedPlayerVisualSlot
		{
			equippedID = DJOAHABGGNA.id
		};
		if (GMONLALOILA != 0)
		{
			GHDMJKHJLHD[0] = new CamosManager.SavedPlayerVisualSlot
			{
				equippedID = CamosManager.instance.playerVisualCategories[1].equippedVisual.CCDMONFHBII()
			};
		}
		KGEEDMONDMK();
		HAKJAOCJAPL();
	}

	public void MPLOCJMIAOG()
	{
		HEEHJJABGPL.enabled = true;
		FKEEPDLCCPN.enabled = true;
	}

	protected virtual void HOINLOMCGFD()
	{
		base.Awake();
		GNILIFKCBKB = BPBGGFNHONI.transform;
		KMFGCJEGJJK.gameObject.SetActive(value: false);
		AnimationEvent component = BPBGGFNHONI.GetComponent<AnimationEvent>();
		if (component != null)
		{
			component.KIHHCHKIKEO = (Action<string>)Delegate.Combine(component.KIHHCHKIKEO, new Action<string>(HBEBHCLALPA));
		}
		DJCFDEIHCKE.gameObject.SetActive(value: true);
	}

	protected virtual void LKCMKAELBFO()
	{
		base.Awake();
		GNILIFKCBKB = BPBGGFNHONI.transform;
		KMFGCJEGJJK.gameObject.SetActive(value: true);
		AnimationEvent component = BPBGGFNHONI.GetComponent<AnimationEvent>();
		if (component != null)
		{
			component.KIHHCHKIKEO = (Action<string>)Delegate.Combine(component.KIHHCHKIKEO, new Action<string>(KBFDAPIDPGM));
		}
		DJCFDEIHCKE.gameObject.SetActive(value: true);
	}

	public void LGNNDPEJKGC()
	{
		DCIGKAKMNDC(AJLGOPNCLCK: false);
	}

	protected virtual void LBCMECNDOIO()
	{
		base.Awake();
		GNILIFKCBKB = BPBGGFNHONI.transform;
		KMFGCJEGJJK.gameObject.SetActive(value: false);
		AnimationEvent component = BPBGGFNHONI.GetComponent<AnimationEvent>();
		if (component != null)
		{
			component.KIHHCHKIKEO = (Action<string>)Delegate.Combine(component.KIHHCHKIKEO, new Action<string>(KBFDAPIDPGM));
		}
		DJCFDEIHCKE.gameObject.SetActive(value: false);
	}

	protected virtual void CDPAGKOKDOP()
	{
		base.Awake();
		GNILIFKCBKB = BPBGGFNHONI.transform;
		KMFGCJEGJJK.gameObject.SetActive(value: true);
		AnimationEvent component = BPBGGFNHONI.GetComponent<AnimationEvent>();
		if (component != null)
		{
			component.KIHHCHKIKEO = (Action<string>)Delegate.Combine(component.KIHHCHKIKEO, new Action<string>(ADOKJNBKMEI));
		}
		DJCFDEIHCKE.gameObject.SetActive(value: true);
	}

	protected override void Awake()
	{
		base.Awake();
		GNILIFKCBKB = BPBGGFNHONI.transform;
		KMFGCJEGJJK.gameObject.SetActive(value: false);
		AnimationEvent component = BPBGGFNHONI.GetComponent<AnimationEvent>();
		if (component != null)
		{
			component.KIHHCHKIKEO = (Action<string>)Delegate.Combine(component.KIHHCHKIKEO, new Action<string>(KIHHCHKIKEO));
		}
		DJCFDEIHCKE.gameObject.SetActive(value: false);
	}

	public void HEKNKONIKDC()
	{
		AnimationState animationState = BPBGGFNHONI["VipReward1"];
		animationState.normalizedTime = 461f;
		animationState.weight = 1638f;
		animationState.enabled = false;
		BPBGGFNHONI.Sample();
		animationState.enabled = true;
		EKAPFGDJIDH.Play("response= ");
		EKAPFGDJIDH.PlayQueued("#Game Rewards# - Squad Points: {0} (after offer mult x{1} on server)");
	}

	[CompilerGenerated]
	private static void NPAPMNBMDLB()
	{
		GuiElementSingle<LootBoxDialog>.instance.ShowFlash();
	}

	public void CAHFHHALJNC()
	{
		BPBGGFNHONI.Play();
		SoundsManager.Instance.PlaySound(SoundsManager.KJGDNLHKPOG.LevelUpUnlockedItem, 7f);
	}

	protected void DIOAOBFDPMH()
	{
	}

	public void OPFGGHJKBOA()
	{
		AnimationState animationState = BPBGGFNHONI["ImproveAllWeaponsRPC"];
		animationState.normalizedTime = 235f;
		animationState.weight = 1016f;
		animationState.enabled = true;
		BPBGGFNHONI.Sample();
		animationState.enabled = false;
		EKAPFGDJIDH.Play("GameLaunch");
		EKAPFGDJIDH.PlayQueued("Play_Card_Tutorial");
	}

	public void Skip()
	{
		DisplayModel(AJLGOPNCLCK: true);
	}

	private static void CGHNPBMBAKC()
	{
		GuiElementSingle<LootBoxDialog>.instance.ShowFlash();
	}

	protected virtual void BMLLLOBPGIB()
	{
		base.Awake();
		GNILIFKCBKB = BPBGGFNHONI.transform;
		KMFGCJEGJJK.gameObject.SetActive(value: true);
		AnimationEvent component = BPBGGFNHONI.GetComponent<AnimationEvent>();
		if (component != null)
		{
			component.KIHHCHKIKEO = (Action<string>)Delegate.Combine(component.KIHHCHKIKEO, new Action<string>(ADOKJNBKMEI));
		}
		DJCFDEIHCKE.gameObject.SetActive(value: true);
	}

	public void FPLCMPHNNHK()
	{
		HEEHJJABGPL.enabled = false;
		FKEEPDLCCPN.enabled = false;
		KMFGCJEGJJK.SetActive(value: true);
		GNILIFKCBKB.gameObject.SetActive(value: false);
		AINDGEKGOFO.gameObject.SetActive(value: false);
		HLPPKBDLEJG.Play();
		SoundsManager.Instance.PlaySound(SoundsManager.KJGDNLHKPOG.CraftingClaim, 1639f);
	}

	public void OpenLootBox()
	{
		BPBGGFNHONI.Play();
		SoundsManager.Instance.PlaySound(SoundsManager.KJGDNLHKPOG.OpenLootbox);
	}

	public void ALKGKMNECBM()
	{
		BPBGGFNHONI.Play();
		SoundsManager.Instance.PlaySound(SoundsManager.KJGDNLHKPOG.CardEquiped, 730f);
	}

	public void KDLLKOJBGGO()
	{
		HEEHJJABGPL.enabled = false;
		FKEEPDLCCPN.enabled = true;
	}

	public void DKNBFMCFAJD()
	{
		AnimationState animationState = BPBGGFNHONI["Grenade_Throwing_Tutorial_Duration"];
		animationState.normalizedTime = 536f;
		animationState.weight = 18f;
		animationState.enabled = true;
		BPBGGFNHONI.Sample();
		animationState.enabled = true;
		EKAPFGDJIDH.Play("Average_Player_Level");
		EKAPFGDJIDH.PlayQueued("LevelName");
	}

	private void PFAHGLBHHHN()
	{
		FOKEPNACDOM();
	}

	protected void NHEOMLPEBLC()
	{
	}

	private static void DHJEAGDHGFL()
	{
		GuiElementSingle<LootBoxDialog>.instance.ShowFlash();
	}

	public void LDABDILKILH()
	{
		InvokeAfter(delegate
		{
			TestVisual();
		}, 627f);
		InvokeAfter(AHFPMGLIHCN, 1658f);
	}

	public void ALDLBOOEMIC()
	{
		GMONLALOILA = UnityEngine.Random.Range(1, 4);
		GHDMJKHJLHD = new Dictionary<int, CamosManager.SavedPlayerVisualSlot>();
		GHDMJKHJLHD[GMONLALOILA] = new CamosManager.SavedPlayerVisualSlot
		{
			equippedID = CamosManager.instance.RandomPlayerVisual(GMONLALOILA).id
		};
		HONPFADFFDP();
		HEKNKONIKDC();
	}

	public void KLLCFEFKEBK(PlayerVisual DJOAHABGGNA)
	{
		GMONLALOILA = DJOAHABGGNA.owner.categoryNumber;
		GHDMJKHJLHD = new Dictionary<int, CamosManager.SavedPlayerVisualSlot>();
		GHDMJKHJLHD[GMONLALOILA] = new CamosManager.SavedPlayerVisualSlot
		{
			equippedID = DJOAHABGGNA.CCDMONFHBII()
		};
		if (GMONLALOILA != 0)
		{
			GHDMJKHJLHD[1] = new CamosManager.SavedPlayerVisualSlot
			{
				equippedID = CamosManager.instance.playerVisualCategories[1].equippedVisual.id
			};
		}
		FPLCMPHNNHK();
		IKMPKEJEDCB();
	}

	public void CKAPICCHFDB()
	{
		InvokeAfter(BIPHMNKLLJC, 724f);
		InvokeAfter(OMPJNNLMLAB, 422f);
	}

	public void JLFFIBJCACB(PlayerVisual DJOAHABGGNA)
	{
		GMONLALOILA = DJOAHABGGNA.owner.categoryNumber;
		GHDMJKHJLHD = new Dictionary<int, CamosManager.SavedPlayerVisualSlot>();
		GHDMJKHJLHD[GMONLALOILA] = new CamosManager.SavedPlayerVisualSlot
		{
			equippedID = DJOAHABGGNA.CCDMONFHBII()
		};
		if (GMONLALOILA != 0)
		{
			GHDMJKHJLHD[0] = new CamosManager.SavedPlayerVisualSlot
			{
				equippedID = CamosManager.instance.playerVisualCategories[1].equippedVisual.CCDMONFHBII()
			};
		}
		MJNCDCDDKND();
		IKMPKEJEDCB();
	}

	public void HHKCDCCMECI()
	{
		HJNDNEKLOLH(AJLGOPNCLCK: true);
	}

	private static void LDEOAALEMIJ()
	{
		GuiElementSingle<LootBoxDialog>.instance.ShowFlash();
	}

	public void BAFEJLNLEBI()
	{
		InvokeAfter(BIPHMNKLLJC, 347f);
		InvokeAfter(OMPJNNLMLAB, 559f);
	}

	public void CIKLALMOLDM()
	{
		GMONLALOILA = UnityEngine.Random.Range(1, 6);
		GHDMJKHJLHD = new Dictionary<int, CamosManager.SavedPlayerVisualSlot>();
		GHDMJKHJLHD[GMONLALOILA] = new CamosManager.SavedPlayerVisualSlot
		{
			equippedID = CamosManager.instance.RandomPlayerVisual(GMONLALOILA).CCDMONFHBII()
		};
		GKKFPJHEEDG();
		IKMPKEJEDCB();
	}

	public void JLHAGJNHEFG()
	{
		GMONLALOILA = UnityEngine.Random.Range(1, 3);
		GHDMJKHJLHD = new Dictionary<int, CamosManager.SavedPlayerVisualSlot>();
		GHDMJKHJLHD[GMONLALOILA] = new CamosManager.SavedPlayerVisualSlot
		{
			equippedID = CamosManager.instance.RandomPlayerVisual(GMONLALOILA).id
		};
		JLJMIOLJPNL();
		DKNBFMCFAJD();
	}

	public void HIFHGNNGGAM()
	{
		HEEHJJABGPL.enabled = true;
		FKEEPDLCCPN.enabled = true;
	}

	public void NFHPJBGNAGE()
	{
		AnimationState animationState = BPBGGFNHONI["Gold"];
		animationState.normalizedTime = 119f;
		animationState.weight = 889f;
		animationState.enabled = false;
		BPBGGFNHONI.Sample();
		animationState.enabled = true;
		EKAPFGDJIDH.Play("com/google/android/gms/games/Games");
		EKAPFGDJIDH.PlayQueued(" NOT OK!\t\t\t\t\t\t");
	}

	private void BIPHMNKLLJC()
	{
		NHPFJJEKDPM();
	}

	private void BKNFDBEBOKN()
	{
		InvokeAfter(delegate
		{
			GuiElementSingle<LootBoxDialog>.instance.ShowFlash();
		}, 204f);
	}

	public void EAGBKKFFBEL()
	{
		InvokeAfter(CJAHNJHGOAN, 494f);
		InvokeAfter(OGMLILLCAKM, 611f);
	}

	public void EAIGCCHKMDC()
	{
		GMONLALOILA = UnityEngine.Random.Range(1, 1);
		GHDMJKHJLHD = new Dictionary<int, CamosManager.SavedPlayerVisualSlot>();
		GHDMJKHJLHD[GMONLALOILA] = new CamosManager.SavedPlayerVisualSlot
		{
			equippedID = CamosManager.instance.RandomPlayerVisual(GMONLALOILA).CCDMONFHBII()
		};
		JPGMEFJGNNA();
		IKMPKEJEDCB();
	}

	public void JOBALFFPEBJ()
	{
		InvokeAfter(INMPCNHNIGI, 1389f);
		InvokeAfter(OGMLILLCAKM, 788f);
	}

	private void OJKJCOMFLFL()
	{
		InvokeAfter(EFPLNBIHCAK, 1044f);
	}

	public void Test()
	{
		InvokeAfter(delegate
		{
			TestVisual();
		}, 0f);
		InvokeAfter(OpenLootBox, 4f);
	}

	private void OPPBOECNDPO()
	{
		InvokeAfter(NPLAKEHLBFC, 1054f);
	}

	private void HEPFBGDBHCF()
	{
		BCDAEAEIKHJ();
	}

	protected virtual void BACJPKBJNIB()
	{
		base.Awake();
		GNILIFKCBKB = BPBGGFNHONI.transform;
		KMFGCJEGJJK.gameObject.SetActive(value: true);
		AnimationEvent component = BPBGGFNHONI.GetComponent<AnimationEvent>();
		if (component != null)
		{
			component.KIHHCHKIKEO = (Action<string>)Delegate.Combine(component.KIHHCHKIKEO, new Action<string>(HBEBHCLALPA));
		}
		DJCFDEIHCKE.gameObject.SetActive(value: false);
	}

	protected virtual void EJNKMAMBOEF()
	{
		base.Awake();
		GNILIFKCBKB = BPBGGFNHONI.transform;
		KMFGCJEGJJK.gameObject.SetActive(value: false);
		AnimationEvent component = BPBGGFNHONI.GetComponent<AnimationEvent>();
		if (component != null)
		{
			component.KIHHCHKIKEO = (Action<string>)Delegate.Combine(component.KIHHCHKIKEO, new Action<string>(MPLAFCIAOME));
		}
		DJCFDEIHCKE.gameObject.SetActive(value: false);
	}

	public void JPGMEFJGNNA()
	{
		HEEHJJABGPL.enabled = true;
		FKEEPDLCCPN.enabled = false;
		KMFGCJEGJJK.SetActive(value: true);
		GNILIFKCBKB.gameObject.SetActive(value: true);
		AINDGEKGOFO.gameObject.SetActive(value: false);
		HLPPKBDLEJG.Play();
		SoundsManager.Instance.PlaySound((SoundsManager.KJGDNLHKPOG)(-13), 955f);
	}

	public void CPKJEDJKLLA()
	{
		InvokeAfter(delegate
		{
			TestVisual();
		}, 766f);
		InvokeAfter(ALKGKMNECBM, 366f);
	}

	private void PLOCIGNMPDA(string MGDGFBCJINH)
	{
		if (MGDGFBCJINH == "Parts")
		{
			LOMBMAGIDOJ.Play();
		}
		if (MGDGFBCJINH == "url")
		{
			OPPBOECNDPO();
		}
	}

	private void PBHOILLAIID(string MGDGFBCJINH)
	{
		if (MGDGFBCJINH == "Returning null weapon for category: {0} level: {1}, minPower: {2}, maxPower: {3}")
		{
			LOMBMAGIDOJ.Play();
		}
		if (MGDGFBCJINH == "BAND_EMPTY")
		{
			JHKACJAMCDE();
		}
	}

	private void JACCBFHHFFG()
	{
		ALDLBOOEMIC();
	}

	public void CDMBFNDKKBM(bool AJLGOPNCLCK)
	{
		FKEEPDLCCPN.Reset();
		GNILIFKCBKB.gameObject.SetActive(value: true);
		AINDGEKGOFO.gameObject.SetActive(value: true);
		ODBMJEFMLBD.Prepare();
		ODBMJEFMLBD.KFJLPOLHFKO();
		CamosManager.instance.ApplyVisuals(ODBMJEFMLBD, GHDMJKHJLHD, useHighRes: true);
		CamosManager.instance.mainPlayer.equippedCamo = null;
		CamosManager.instance.ApplyVisuals(CamosManager.instance.mainPlayer, useHighRes: false);
		ODBMJEFMLBD.CGGNOJJEFKE(GMONLALOILA);
		ODBMJEFMLBD.transform.localScale = Vector3.one;
		ODBMJEFMLBD.transform.localPosition = Vector3.zero;
		ODBMJEFMLBD.transform.localRotation = Quaternion.identity;
		GuiElementSingle<LootBoxDialog>.instance.ShowVisualInfo(AJLGOPNCLCK);
	}

	private void CJAHNJHGOAN()
	{
		NHPFJJEKDPM();
	}
}
