using System;
using UnityEngine;

public class UserGeneratedContent : GuiElementSingle<UserGeneratedContent>, PAIIOKBBHBC
{
	[Header("Buttons")]
	public UIButton CCFFNAKFPPE;

	public virtual void OBNCKIBJOGJ()
	{
		Singleton<BeanstalkServerManager>.instance.DBDGCNFCOBI();
	}

	public virtual void NGHAPNEFBED()
	{
		Singleton<BeanstalkServerManager>.instance.DBDGCNFCOBI();
	}

	public GuiElement FEJMHFBCGDO()
	{
		return this;
	}

	public override void InitControls()
	{
		UIEventListener uIEventListener = UIEventListener.Get(CCFFNAKFPPE.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(GKOHJGFKPAH));
	}

	public virtual void BMMNJICILHJ()
	{
		UIEventListener uIEventListener = UIEventListener.Get(CCFFNAKFPPE.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(GKOHJGFKPAH));
	}

	private void GKOHJGFKPAH(GameObject KHAHPAKDIKE)
	{
		if (base.isFullyShowed)
		{
			HideDialog();
		}
	}

	public GuiElement DAHIAEDLPBE()
	{
		return this;
	}

	private void GELJAHKAPOI(GameObject KHAHPAKDIKE)
	{
		if (BKIGLABDGCP())
		{
			HideDialog();
		}
	}

	public virtual void JNDJIOOGPGD()
	{
		UIEventListener uIEventListener = UIEventListener.Get(CCFFNAKFPPE.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(GKOHJGFKPAH));
	}

	public GuiElement GetGuiElement()
	{
		return this;
	}

	public override void InitGUIValues()
	{
		Singleton<BeanstalkServerManager>.instance.DBDGCNFCOBI();
	}

	public override void OnBack()
	{
		GKOHJGFKPAH(CCFFNAKFPPE.gameObject);
	}

	public virtual void JCIBDJMFOLI()
	{
		Singleton<BeanstalkServerManager>.instance.DBDGCNFCOBI();
	}

	public virtual void KFPOJBHHLGJ()
	{
		GKOHJGFKPAH(CCFFNAKFPPE.gameObject);
	}

	public virtual void OKMMGFMKJGG()
	{
		Singleton<BeanstalkServerManager>.instance.DBDGCNFCOBI();
	}

	public virtual void BFLHENDLPLK()
	{
		Singleton<BeanstalkServerManager>.instance.DBDGCNFCOBI();
	}
}
