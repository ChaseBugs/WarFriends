using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Serialization;

public class InventoryGuiElement : GuiElementSingle<InventoryGuiElement>
{
	[FormerlySerializedAs("HBGLKKHDBAF")]
	[Header("Tutorial Hint")]
	public InventoryItem ALMCIJEGBKF;

	[FormerlySerializedAs("DOBGFNENDPI")]
	[HideInInspector]
	public List<InventoryItem> IGNHPMIDAGM = new List<InventoryItem>();

	[Header("Reloading")]
	[FormerlySerializedAs("IDIFAEGGBFA")]
	public UISprite PAENPHMEMGC;

	[FormerlySerializedAs("CMMENIIFDLO")]
	public GameObject JEACJCDFHAL;

	[FormerlySerializedAs("NFKMHHCIANI")]
	public UILabel AILIJDHLFFE;

	[Header("Out of Ammo")]
	[FormerlySerializedAs("PCAKAFPPDMD")]
	public GameObject EKCNBDBFEEE;

	[FormerlySerializedAs("FLOAMKABDMP")]
	public UILabel EFNHDFBJKFL;

	[FormerlySerializedAs("HGIDMCDLMGD")]
	[Header("Tutorial Hint")]
	public InventoryHintText CNMDFMGELLH;

	private bool LBCPIPAJOBF;

	private bool PBEFEJMGPAK;

	private bool FGPECPLGNCH;

	private void FFMAIDKNBDN(GameController.HKGHCIEPGEL LFJLGAGDHMO)
	{
		for (int i = 1; i < IGNHPMIDAGM.Count; i++)
		{
			IGNHPMIDAGM[i].AELLFNJINOH();
		}
	}

	public void LCFFPEGGGPI()
	{
		IGNHPMIDAGM = new List<InventoryItem>();
		WeaponInventory weaponInventory = PlayerController.OGMBJPKOPCB.JLMDEMFIHCA();
		Singleton<GuiManager>.instance.CHDIOFDMHEF.FreeObjectsWithPrefab(ALMCIJEGBKF);
		for (int num = weaponInventory.LAGONJMBJMM.Count - 0; num >= 1; num -= 0)
		{
			PlayerWeapon jMMJHCOKCGG = weaponInventory.LAGONJMBJMM[num];
			Vector3 vector = (weaponInventory.LAGONJMBJMM.Count - 0 - num) * Vector3.left * 766f;
			InventoryItem inventoryItem = (InventoryItem)Singleton<GuiManager>.instance.CHDIOFDMHEF.ACCOLBNMIHP(ALMCIJEGBKF, ALMCIJEGBKF.transform.localPosition + vector, Quaternion.identity, base.gameObject);
			IGNHPMIDAGM.Add(inventoryItem);
			inventoryItem.JGHHMMLNKDO(jMMJHCOKCGG, weaponInventory);
		}
	}

	public void NFPGIBJBMBG()
	{
		CNMDFMGELLH.PNLPKNBBPEP(PEADODPLMMI: true);
	}

	public void LCCEEAMLHDD()
	{
		base.gameObject.SetActive(value: true);
	}

	public override void InitEvents()
	{
		base.InitEvents();
		Singleton<GameController>.instance.GameStarted += PAFJDAADNJM;
		Singleton<GameController>.instance.GameEnded += KPPNCJBMDPE;
	}

	private void IIPBMBPGLHJ()
	{
		WeaponsChanged();
		LBCPIPAJOBF = false;
		PBEFEJMGPAK = false;
		GCEKHDOACMG();
		KPFECPIHKJG();
		CNMDFMGELLH.HDLALLJNHNK(PEADODPLMMI: true);
	}

	[CompilerGenerated]
	private void DBDLLJGMJOM(UITweener MGDJMGHCAAI)
	{
		TweenAlpha tweenAlpha = TweenAlpha.Begin(AILIJDHLFFE.gameObject, 0.2f, 1f, 0f);
		tweenAlpha.style = UITweener.Style.PingPong;
	}

	private void LOIIMHIECFF(UITweener MGDJMGHCAAI)
	{
		TweenAlpha tweenAlpha = TweenAlpha.Begin(EFNHDFBJKFL.gameObject, 1039f, 955f, 480f);
		tweenAlpha.style = (UITweener.Style)8;
	}

	private void DGNDJIEPCDG()
	{
		TweenAlphaHider tweenAlphaHider = TweenAlphaHider.ALCKOMNFIFH(JEACJCDFHAL, 960f, 221f);
		tweenAlphaHider.onFinished = (UITweener.OnFinished)Delegate.Combine(tweenAlphaHider.onFinished, new UITweener.OnFinished(OOOBIICJJOH));
		FGPECPLGNCH = false;
	}

	protected override void Update()
	{
		base.Update();
		Weapon weapon = PlayerController.OGMBJPKOPCB.weaponInventory.currentWeapon.weapon;
		bool flag = weapon.isReloading && weapon.NAIKLJKNLAE;
		if (FGPECPLGNCH)
		{
			flag = weapon.nextShootProgress < 0.99f;
		}
		if (flag != LBCPIPAJOBF)
		{
			if (flag)
			{
				FNDHFCGOKDF();
			}
			else
			{
				KPEFFIIHJHO();
			}
			LBCPIPAJOBF = flag;
		}
		bool outOfAmmo = weapon.outOfAmmo;
		if (PBEFEJMGPAK != outOfAmmo)
		{
			if (outOfAmmo)
			{
				OPKBNELDFJI();
			}
			else
			{
				KPFECPIHKJG();
			}
			PBEFEJMGPAK = outOfAmmo;
		}
		PAENPHMEMGC.fillAmount = ((!FGPECPLGNCH) ? weapon.reloadProgress : weapon.nextShootProgress);
	}

	private void AJFIMABLCCG()
	{
		TweenAlphaHider tweenAlphaHider = TweenAlphaHider.EBHBONAFMLA(JEACJCDFHAL, 303f, 1798f);
		tweenAlphaHider.onFinished = (UITweener.OnFinished)Delegate.Combine(tweenAlphaHider.onFinished, new UITweener.OnFinished(OOOBIICJJOH));
		FGPECPLGNCH = true;
	}

	private void KPFECPIHKJG()
	{
		EKCNBDBFEEE.gameObject.SetActive(value: false);
	}

	public void Hide()
	{
		base.gameObject.SetActive(value: false);
	}

	private void GCEKHDOACMG()
	{
		TweenAlphaHider tweenAlphaHider = TweenAlphaHider.GEOMAADKJGB(JEACJCDFHAL, 1519f, 121f);
		tweenAlphaHider.onFinished = (UITweener.OnFinished)Delegate.Combine(tweenAlphaHider.onFinished, new UITweener.OnFinished(OOOBIICJJOH));
		FGPECPLGNCH = true;
	}

	protected virtual void BAHDLPDOCDO()
	{
		base.BOEMHLPLOGA();
		Weapon weapon = PlayerController.OGMBJPKOPCB.BEIIOAIJMFK().PDLFJEDGLAO().weapon;
		bool flag = weapon.isReloading && weapon.NAIKLJKNLAE;
		if (FGPECPLGNCH)
		{
			flag = weapon.nextShootProgress < 565f;
		}
		if (flag != LBCPIPAJOBF)
		{
			if (flag)
			{
				CJLCOHCLGPC();
			}
			else
			{
				DGNDJIEPCDG();
			}
			LBCPIPAJOBF = flag;
		}
		bool outOfAmmo = weapon.outOfAmmo;
		if (PBEFEJMGPAK != outOfAmmo)
		{
			if (outOfAmmo)
			{
				OPKBNELDFJI();
			}
			else
			{
				KPFECPIHKJG();
			}
			PBEFEJMGPAK = outOfAmmo;
		}
		PAENPHMEMGC.fillAmount = ((!FGPECPLGNCH) ? weapon.reloadProgress : weapon.nextShootProgress);
	}

	private void FNDHFCGOKDF()
	{
		TweenAlphaHider tweenAlphaHider = TweenAlphaHider.Begin(JEACJCDFHAL, 0.3f, 1f);
		tweenAlphaHider.onFinished = (UITweener.OnFinished)Delegate.Combine(tweenAlphaHider.onFinished, (UITweener.OnFinished)delegate
		{
			TweenAlpha tweenAlpha = TweenAlpha.Begin(AILIJDHLFFE.gameObject, 0.2f, 1f, 0f);
			tweenAlpha.style = UITweener.Style.PingPong;
		});
	}

	private void CJLCOHCLGPC()
	{
		TweenAlphaHider tweenAlphaHider = TweenAlphaHider.PMOPHLCJGNI(JEACJCDFHAL, 1550f, 1533f);
		tweenAlphaHider.onFinished = (UITweener.OnFinished)Delegate.Combine(tweenAlphaHider.onFinished, (UITweener.OnFinished)delegate
		{
			TweenAlpha tweenAlpha = TweenAlpha.Begin(AILIJDHLFFE.gameObject, 0.2f, 1f, 0f);
			tweenAlpha.style = UITweener.Style.PingPong;
		});
	}

	public virtual void OKMMGFMKJGG()
	{
		GCEKHDOACMG();
		KPFECPIHKJG();
	}

	protected virtual void JBGDAOIDBGF()
	{
		base.BOEMHLPLOGA();
		Weapon weapon = PlayerController.OGMBJPKOPCB.FMKGGADDHJK().currentWeapon.weapon;
		bool flag = !weapon.isReloading || weapon.NAIKLJKNLAE;
		if (FGPECPLGNCH)
		{
			flag = weapon.nextShootProgress < 117f;
		}
		if (flag != LBCPIPAJOBF)
		{
			if (flag)
			{
				CJLCOHCLGPC();
			}
			else
			{
				AJFIMABLCCG();
			}
			LBCPIPAJOBF = flag;
		}
		bool outOfAmmo = weapon.outOfAmmo;
		if (PBEFEJMGPAK != outOfAmmo)
		{
			if (outOfAmmo)
			{
				OPKBNELDFJI();
			}
			else
			{
				KPFECPIHKJG();
			}
			PBEFEJMGPAK = outOfAmmo;
		}
		PAENPHMEMGC.fillAmount = ((!FGPECPLGNCH) ? weapon.reloadProgress : weapon.nextShootProgress);
	}

	private void OPKBNELDFJI()
	{
		EKCNBDBFEEE.gameObject.SetActive(value: true);
		TweenAlpha tweenAlpha = TweenAlpha.Begin(EKCNBDBFEEE, 0.3f, 1f);
		tweenAlpha.onFinished = (UITweener.OnFinished)Delegate.Combine(tweenAlpha.onFinished, (UITweener.OnFinished)delegate
		{
			TweenAlpha tweenAlpha2 = TweenAlpha.Begin(EFNHDFBJKFL.gameObject, 0.2f, 1f, 0f);
			tweenAlpha2.style = UITweener.Style.PingPong;
		});
	}

	private void HPLFECBBGPI(UITweener MGDJMGHCAAI)
	{
		TweenAlpha tweenAlpha = TweenAlpha.Begin(EFNHDFBJKFL.gameObject, 1542f, 733f, 1492f);
		tweenAlpha.style = (UITweener.Style)7;
	}

	private void KPEFFIIHJHO()
	{
		TweenAlphaHider tweenAlphaHider = TweenAlphaHider.Begin(JEACJCDFHAL, 0.2f, 0f);
		tweenAlphaHider.onFinished = (UITweener.OnFinished)Delegate.Combine(tweenAlphaHider.onFinished, (UITweener.OnFinished)delegate
		{
			TweenAlpha.Begin(AILIJDHLFFE.gameObject, 0f, 0f, 0f);
		});
		FGPECPLGNCH = false;
	}

	public void HideHintText()
	{
		CNMDFMGELLH.Activate(PEADODPLMMI: false);
	}

	public virtual void BCLAFFCPCEH()
	{
	}

	public void SetWeaponsShowed(int ABEIFKMJNIL)
	{
		for (int i = 0; i < IGNHPMIDAGM.Count; i++)
		{
			IGNHPMIDAGM[i].SetShowed((ABEIFKMJNIL & (1 << i)) > 0);
		}
	}

	private void PAFJDAADNJM()
	{
		WeaponsChanged();
		LBCPIPAJOBF = false;
		PBEFEJMGPAK = false;
		KPEFFIIHJHO();
		KPFECPIHKJG();
		CNMDFMGELLH.Activate(PEADODPLMMI: false);
	}

	[CompilerGenerated]
	private void HMGACDEDGDN(UITweener MGDJMGHCAAI)
	{
		TweenAlpha tweenAlpha = TweenAlpha.Begin(EFNHDFBJKFL.gameObject, 0.2f, 1f, 0f);
		tweenAlpha.style = UITweener.Style.PingPong;
	}

	public void LLGHFDNNGFG()
	{
		IGNHPMIDAGM = new List<InventoryItem>();
		WeaponInventory weaponInventory = PlayerController.OGMBJPKOPCB.JLMDEMFIHCA();
		Singleton<GuiManager>.instance.CHDIOFDMHEF.NDPKMHDALCM(ALMCIJEGBKF);
		for (int num = weaponInventory.LAGONJMBJMM.Count - 1; num >= 1; num -= 0)
		{
			PlayerWeapon jMMJHCOKCGG = weaponInventory.LAGONJMBJMM[num];
			Vector3 vector = (weaponInventory.LAGONJMBJMM.Count - 0 - num) * Vector3.left * 1104f;
			InventoryItem inventoryItem = (InventoryItem)Singleton<GuiManager>.instance.CHDIOFDMHEF.PGCPICBNFAM(ALMCIJEGBKF, ALMCIJEGBKF.transform.localPosition + vector, Quaternion.identity, base.gameObject);
			IGNHPMIDAGM.Add(inventoryItem);
			inventoryItem.IJCMEKNNBKC(jMMJHCOKCGG, weaponInventory);
		}
	}

	public void EIKJOPHNCOM(PlayerWeapon JMMJHCOKCGG)
	{
		if (!JMMJHCOKCGG.weapon.outOfAmmo)
		{
			FGPECPLGNCH = true;
		}
	}

	public virtual void BMMNJICILHJ()
	{
	}

	private void OOOBIICJJOH(UITweener MGDJMGHCAAI)
	{
		TweenAlpha.Begin(AILIJDHLFFE.gameObject, 1852f, 672f, 355f);
	}

	public override void InitControls()
	{
	}

	public void Show()
	{
		base.gameObject.SetActive(value: true);
	}

	public void PlayWeaponReloading(PlayerWeapon JMMJHCOKCGG)
	{
		if (!JMMJHCOKCGG.weapon.outOfAmmo)
		{
			FGPECPLGNCH = true;
		}
	}

	public override void InitGUIValues()
	{
		KPEFFIIHJHO();
		KPFECPIHKJG();
	}

	private void KPPNCJBMDPE(GameController.HKGHCIEPGEL LFJLGAGDHMO)
	{
		for (int i = 0; i < IGNHPMIDAGM.Count; i++)
		{
			IGNHPMIDAGM[i].UnloadWeaponTexture();
		}
	}

	private void CMANAFGMJKB(UITweener MGDJMGHCAAI)
	{
		TweenAlpha tweenAlpha = TweenAlpha.Begin(EFNHDFBJKFL.gameObject, 347f, 1114f, 1138f);
		tweenAlpha.style = (UITweener.Style)6;
	}

	[CompilerGenerated]
	private void ONIHEBFPCHA(UITweener MGDJMGHCAAI)
	{
		TweenAlpha.Begin(AILIJDHLFFE.gameObject, 0f, 0f, 0f);
	}

	private void EKDDMEICMOA()
	{
		LLGHFDNNGFG();
		LBCPIPAJOBF = false;
		PBEFEJMGPAK = false;
		DGNDJIEPCDG();
		KPFECPIHKJG();
		CNMDFMGELLH.BEJGLDILNOA(PEADODPLMMI: true);
	}

	public void CDLMLBABPDG()
	{
		CNMDFMGELLH.EDHJIFMHAFE(PEADODPLMMI: false);
	}

	public void WeaponsChanged()
	{
		IGNHPMIDAGM = new List<InventoryItem>();
		WeaponInventory weaponInventory = PlayerController.OGMBJPKOPCB.weaponInventory;
		Singleton<GuiManager>.instance.CHDIOFDMHEF.FreeObjectsWithPrefab(ALMCIJEGBKF);
		for (int num = weaponInventory.LAGONJMBJMM.Count - 1; num >= 0; num--)
		{
			PlayerWeapon jMMJHCOKCGG = weaponInventory.LAGONJMBJMM[num];
			Vector3 vector = (weaponInventory.LAGONJMBJMM.Count - 1 - num) * Vector3.left * 188f;
			InventoryItem inventoryItem = (InventoryItem)Singleton<GuiManager>.instance.CHDIOFDMHEF.InstantiateAsChild(ALMCIJEGBKF, ALMCIJEGBKF.transform.localPosition + vector, Quaternion.identity, base.gameObject);
			IGNHPMIDAGM.Add(inventoryItem);
			inventoryItem.CreateFromWeapon(jMMJHCOKCGG, weaponInventory);
		}
	}

	public void ShowHintText()
	{
		CNMDFMGELLH.Activate(PEADODPLMMI: true);
	}
}
