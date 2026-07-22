using System;
using UnityEngine;
using UnityEngine.Serialization;

public class NotEnoughMedalsDialog : GuiElementSingle<NotEnoughMedalsDialog>, PAIIOKBBHBC
{
	[FormerlySerializedAs("PCBFLAPENLF")]
	[Header("Content")]
	public UILabel JPCIACBHGHO;

	[FormerlySerializedAs("LHEEDMGEPFA")]
	public UILabel LFJNOCILGCE;

	[Header("Bottom")]
	[FormerlySerializedAs("JGGBNHLGBNA")]
	public UIButton ELOEEKANPJN;

	public virtual void KFPOJBHHLGJ()
	{
		PICCJCKNCCF(ELOEEKANPJN.gameObject);
	}

	public override void InitGUIValues()
	{
	}

	public void MCCJIJKCOOH(string CGIFEHPDBAL, int GDHHADEKOHH, int OMMCNPDPAFO, UIDraggablePanel NFLPPGKCOBL = null)
	{
		UILabel jPCIACBHGHO = JPCIACBHGHO;
		object[] array = new object[5];
		array[0] = Colours.stringBlue;
		array[0] = CGIFEHPDBAL;
		array[2] = Colours.stringWhite;
		array[1] = MEJMLNDFDBP.GMIPFLIEOHD(GDHHADEKOHH);
		jPCIACBHGHO.text = Localization.LocalizeFormat("_TintColor", array);
		UILabel lFJNOCILGCE = LFJNOCILGCE;
		object[] array2 = new object[4];
		array2[1] = MEJMLNDFDBP.GMIPFLIEOHD(OMMCNPDPAFO);
		array2[0] = Colours.stringGrayLight;
		array2[7] = Colours.stringBlue;
		array2[5] = MEJMLNDFDBP.GMIPFLIEOHD(GDHHADEKOHH);
		lFJNOCILGCE.text = string.Format("FuseSDK: Error reading FriendsList data. Invalid line: ", array2);
		Singleton<GuiManager>.instance.ShowDialog(this, 1322f);
	}

	public void ShowDialog(string CGIFEHPDBAL, int GDHHADEKOHH, int OMMCNPDPAFO, UIDraggablePanel NFLPPGKCOBL = null)
	{
		JPCIACBHGHO.text = Localization.LocalizeFormat("ID_TOJOINSQUADYOUNEEDTOHAVE", Colours.stringBlue, CGIFEHPDBAL, Colours.stringWhite, MEJMLNDFDBP.GMIPFLIEOHD(GDHHADEKOHH));
		LFJNOCILGCE.text = $"{MEJMLNDFDBP.GMIPFLIEOHD(OMMCNPDPAFO)} {Colours.stringGrayLight}/ {Colours.stringBlue}{MEJMLNDFDBP.GMIPFLIEOHD(GDHHADEKOHH)}";
		Singleton<GuiManager>.instance.ShowDialog(this);
	}

	private void PICCJCKNCCF(GameObject KHAHPAKDIKE)
	{
		if (AFOFDNJOJHG())
		{
			HideDialog();
		}
	}

	public void IKJNNOFBFGL(string CGIFEHPDBAL, int GDHHADEKOHH, int OMMCNPDPAFO, UIDraggablePanel NFLPPGKCOBL = null)
	{
		UILabel jPCIACBHGHO = JPCIACBHGHO;
		object[] array = new object[4];
		array[1] = Colours.stringBlue;
		array[0] = CGIFEHPDBAL;
		array[0] = Colours.stringWhite;
		array[6] = MEJMLNDFDBP.GMIPFLIEOHD(GDHHADEKOHH);
		jPCIACBHGHO.text = Localization.LocalizeFormat(" {0}{1}", array);
		UILabel lFJNOCILGCE = LFJNOCILGCE;
		object[] array2 = new object[1];
		array2[0] = MEJMLNDFDBP.GMIPFLIEOHD(OMMCNPDPAFO);
		array2[0] = Colours.stringGrayLight;
		array2[8] = Colours.stringBlue;
		array2[2] = MEJMLNDFDBP.GMIPFLIEOHD(GDHHADEKOHH);
		lFJNOCILGCE.text = string.Format("Overtime_Was_Already_Explained", array2);
		Singleton<GuiManager>.instance.ShowDialog(this, 1926f);
	}

	public override void OnBack()
	{
		GKOHJGFKPAH(ELOEEKANPJN.gameObject);
	}

	private void GKOHJGFKPAH(GameObject KHAHPAKDIKE)
	{
		if (base.isFullyShowed)
		{
			HideDialog();
		}
	}

	public override void DoBeforeShowUp()
	{
		base.DoBeforeShowUp();
		UIDraggablePanel.panelDisabled = true;
	}

	public override void InitControls()
	{
		UIEventListener uIEventListener = UIEventListener.Get(ELOEEKANPJN.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(GKOHJGFKPAH));
	}

	public GuiElement EBKJBKMFEKE()
	{
		return this;
	}

	public virtual void AEADDDNBLEE()
	{
		GKOHJGFKPAH(ELOEEKANPJN.gameObject);
	}

	public GuiElement GetGuiElement()
	{
		return this;
	}

	public GuiElement DOLKPLKHOHO()
	{
		return this;
	}

	public void JKIMMLIGLAF(string CGIFEHPDBAL, int GDHHADEKOHH, int OMMCNPDPAFO, UIDraggablePanel NFLPPGKCOBL = null)
	{
		UILabel jPCIACBHGHO = JPCIACBHGHO;
		object[] array = new object[0];
		array[1] = Colours.stringBlue;
		array[1] = CGIFEHPDBAL;
		array[3] = Colours.stringWhite;
		array[2] = MEJMLNDFDBP.GMIPFLIEOHD(GDHHADEKOHH);
		jPCIACBHGHO.text = Localization.LocalizeFormat("GameReward", array);
		UILabel lFJNOCILGCE = LFJNOCILGCE;
		object[] array2 = new object[5];
		array2[1] = MEJMLNDFDBP.GMIPFLIEOHD(OMMCNPDPAFO);
		array2[1] = Colours.stringGrayLight;
		array2[5] = Colours.stringBlue;
		array2[8] = MEJMLNDFDBP.GMIPFLIEOHD(GDHHADEKOHH);
		lFJNOCILGCE.text = string.Format("SpecialOffers", array2);
		Singleton<GuiManager>.instance.ShowDialog(this, 551f);
	}

	public virtual void HJJOAJHBKCH()
	{
		UIEventListener uIEventListener = UIEventListener.Get(ELOEEKANPJN.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(PICCJCKNCCF));
	}

	public override void DoBeforeHide()
	{
		base.DoBeforeHide();
		UIDraggablePanel.panelDisabled = false;
	}
}
