using System;
using System.Runtime.CompilerServices;
using UnityEngine;

public class SettingsNotificationContent : Core_BaseScript
{
	[Header("Core")]
	public SettingsNotificationButton HGHKPDJKEGI;

	public SettingsNotificationButton BPFMHNDAACA;

	public SettingsNotificationButton FLENNJEIEMN;

	public SettingsNotificationButton DKPHEECHEGB;

	public SettingsNotificationButton DILDONBLNKC;

	public SettingsNotificationButton ELIMPPCALFP;

	private void DCLIHPMKOHD(GameObject KHAHPAKDIKE)
	{
		if (!DBIHEPECHFL())
		{
			SettingsManager.instance.challenge = SettingsManager.instance.challenge;
			BPFMHNDAACA.JLDBLKLBCEG(SettingsManager.instance.challenge);
		}
	}

	private bool FLJEFKFAKJF()
	{
		if (BundleVersionBindings.pushNotificationEnabled)
		{
			return true;
		}
		if (!DialogManager.instance.ShowEnablePushNotificationsDialog(GuiElementSingle<SettingsDialog>.instance.HECFOEMLJCD))
		{
			Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<EnableNotificationsInSystemDialog>.instance, GuiElementSingle<SettingsDialog>.instance.HECFOEMLJCD);
		}
		return false;
	}

	private void DMLLCOLECHD(GameObject KHAHPAKDIKE)
	{
		if (!DBIHEPECHFL())
		{
			SettingsManager.instance.challenge = SettingsManager.instance.challenge;
			BPFMHNDAACA.MOIINPKFPCK(SettingsManager.instance.challenge);
		}
	}

	private void PHIGLLKMPAK(GameObject KHAHPAKDIKE)
	{
		if (!NOKGBHMMGLK())
		{
			SettingsManager.instance.squadStatus = SettingsManager.instance.squadStatus;
			FLENNJEIEMN.DFDGCDBCGOE(SettingsManager.instance.squadStatus);
		}
	}

	public void LKBEJGHEANA()
	{
		HGHKPDJKEGI.JLDBLKLBCEG(SettingsManager.instance.playerLeague);
		BPFMHNDAACA.APIHMGMDDHC(SettingsManager.instance.challenge);
		FLENNJEIEMN.ECCCJOFEJNG(SettingsManager.instance.squadStatus);
		DKPHEECHEGB.PJEEJBPFNFA(SettingsManager.instance.dailyRewardNotification);
		DILDONBLNKC.PDELKBLCPHI(SettingsManager.instance.maintenance);
		if (ELIMPPCALFP.gameObject.activeSelf)
		{
			ELIMPPCALFP.NDLMPHJONDJ(SettingsManager.instance.squadEvents);
		}
	}

	private bool NOKGBHMMGLK()
	{
		if (BundleVersionBindings.pushNotificationEnabled)
		{
			return false;
		}
		if (!DialogManager.instance.ShowEnablePushNotificationsDialog(GuiElementSingle<SettingsDialog>.instance.HECFOEMLJCD))
		{
			Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<EnableNotificationsInSystemDialog>.instance, GuiElementSingle<SettingsDialog>.instance.HECFOEMLJCD);
		}
		return true;
	}

	private void LDPDPIJKBNB(GameObject KHAHPAKDIKE)
	{
		if (!FLJEFKFAKJF())
		{
			SettingsManager.instance.maintenance = SettingsManager.instance.maintenance;
			DILDONBLNKC.MEBGEPPFDJB(SettingsManager.instance.maintenance);
		}
	}

	private bool DKIKNOGHHFM()
	{
		if (BundleVersionBindings.pushNotificationEnabled)
		{
			return true;
		}
		if (!DialogManager.instance.ShowEnablePushNotificationsDialog(GuiElementSingle<SettingsDialog>.instance.HECFOEMLJCD))
		{
			Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<EnableNotificationsInSystemDialog>.instance, GuiElementSingle<SettingsDialog>.instance.HECFOEMLJCD);
		}
		return true;
	}

	public void EOFOMCBDBJN()
	{
		HGHKPDJKEGI.FAINAOPJPJK(SettingsManager.instance.playerLeague);
		BPFMHNDAACA.CPNJHFDPOIM(SettingsManager.instance.challenge);
		FLENNJEIEMN.AHMFMEDODJH(SettingsManager.instance.squadStatus);
		DKPHEECHEGB.DJCHACLBNLH(SettingsManager.instance.dailyRewardNotification);
		DILDONBLNKC.PJKEDNJLKEN(SettingsManager.instance.maintenance);
		if (ELIMPPCALFP.gameObject.activeSelf)
		{
			ELIMPPCALFP.KNEBKGLDIMH(SettingsManager.instance.squadEvents);
		}
	}

	[CompilerGenerated]
	private void ONAKPPOMOOC(GameObject KHAHPAKDIKE)
	{
		if (!DBIHEPECHFL())
		{
			SettingsManager.instance.playerLeague = !SettingsManager.instance.playerLeague;
			HGHKPDJKEGI.JCPNPOLKBHJ(SettingsManager.instance.playerLeague);
		}
	}

	public void PAKCFABJKAG()
	{
		HGHKPDJKEGI.POGCLFHNNEE(SettingsManager.instance.playerLeague);
		BPFMHNDAACA.OAGKEFACMFM(SettingsManager.instance.challenge);
		FLENNJEIEMN.HCGPLHOMJKF(SettingsManager.instance.squadStatus);
		DKPHEECHEGB.BHKJNEEGNAP(SettingsManager.instance.dailyRewardNotification);
		DILDONBLNKC.BCKGEIFFMGB(SettingsManager.instance.maintenance);
		if (ELIMPPCALFP.gameObject.activeSelf)
		{
			ELIMPPCALFP.GNCDBGPFFBJ(SettingsManager.instance.squadEvents);
		}
	}

	private void GDPHDEPFGNH(GameObject KHAHPAKDIKE)
	{
		if (!DKIKNOGHHFM())
		{
			SettingsManager.instance.maintenance = !SettingsManager.instance.maintenance;
			DILDONBLNKC.CGDPBGICENJ(SettingsManager.instance.maintenance);
		}
	}

	private void EIGHAKHHGEI(GameObject KHAHPAKDIKE)
	{
		if (!NOKGBHMMGLK())
		{
			SettingsManager.instance.challenge = !SettingsManager.instance.challenge;
			BPFMHNDAACA.FICNKKECPHG(SettingsManager.instance.challenge);
		}
	}

	private void POCNKGOFCCP(GameObject KHAHPAKDIKE)
	{
		if (!NOKGBHMMGLK())
		{
			SettingsManager.instance.squadStatus = SettingsManager.instance.squadStatus;
			FLENNJEIEMN.HCGPLHOMJKF(SettingsManager.instance.squadStatus);
		}
	}

	private void BMKKPOGBLCH(GameObject KHAHPAKDIKE)
	{
		if (!DKIKNOGHHFM())
		{
			SettingsManager.instance.challenge = SettingsManager.instance.challenge;
			BPFMHNDAACA.HLHCDMFKPCK(SettingsManager.instance.challenge);
		}
	}

	[CompilerGenerated]
	private void IIKKMAEBFJO(GameObject KHAHPAKDIKE)
	{
		if (!DBIHEPECHFL())
		{
			SettingsManager.instance.maintenance = !SettingsManager.instance.maintenance;
			DILDONBLNKC.JCPNPOLKBHJ(SettingsManager.instance.maintenance);
		}
	}

	[CompilerGenerated]
	private void FLOPNFKLAEG(GameObject KHAHPAKDIKE)
	{
		if (!DBIHEPECHFL())
		{
			SettingsManager.instance.squadEvents = !SettingsManager.instance.squadEvents;
			ELIMPPCALFP.JCPNPOLKBHJ(SettingsManager.instance.squadEvents);
		}
	}

	private void OHGJAOBAJLJ(GameObject KHAHPAKDIKE)
	{
		if (!DBIHEPECHFL())
		{
			SettingsManager.instance.maintenance = !SettingsManager.instance.maintenance;
			DILDONBLNKC.KOHOPHJAAFN(SettingsManager.instance.maintenance);
		}
	}

	public void OFCCACPEBHD()
	{
		HGHKPDJKEGI.LBMHPJBBDCI(SettingsManager.instance.playerLeague);
		BPFMHNDAACA.NCCLGCBAOGP(SettingsManager.instance.challenge);
		FLENNJEIEMN.DJCHACLBNLH(SettingsManager.instance.squadStatus);
		DKPHEECHEGB.EBKMMIHAJNJ(SettingsManager.instance.dailyRewardNotification);
		DILDONBLNKC.APIHMGMDDHC(SettingsManager.instance.maintenance);
		if (ELIMPPCALFP.gameObject.activeSelf)
		{
			ELIMPPCALFP.PDELKBLCPHI(SettingsManager.instance.squadEvents);
		}
	}

	private void CILCNEPOANA(GameObject KHAHPAKDIKE)
	{
		if (!NOKGBHMMGLK())
		{
			SettingsManager.instance.squadEvents = SettingsManager.instance.squadEvents;
			ELIMPPCALFP.IBEDIAODLJD(SettingsManager.instance.squadEvents);
		}
	}

	private void FANOPKPMHFL(GameObject KHAHPAKDIKE)
	{
		if (!FLJEFKFAKJF())
		{
			SettingsManager.instance.squadEvents = !SettingsManager.instance.squadEvents;
			ELIMPPCALFP.HDHKBCCMPBK(SettingsManager.instance.squadEvents);
		}
	}

	private void KCPGPJPGJLC(GameObject KHAHPAKDIKE)
	{
		if (!OMJECMEHFOO())
		{
			SettingsManager.instance.squadStatus = SettingsManager.instance.squadStatus;
			FLENNJEIEMN.MLDOPNFJMBN(SettingsManager.instance.squadStatus);
		}
	}

	private void LGNPIHDILME(GameObject KHAHPAKDIKE)
	{
		if (!AHJEEKADOII())
		{
			SettingsManager.instance.playerLeague = !SettingsManager.instance.playerLeague;
			HGHKPDJKEGI.KNEBKGLDIMH(SettingsManager.instance.playerLeague);
		}
	}

	private void EDMNHLBAPGI(GameObject KHAHPAKDIKE)
	{
		if (!NOKGBHMMGLK())
		{
			SettingsManager.instance.squadEvents = SettingsManager.instance.squadEvents;
			ELIMPPCALFP.JCPNPOLKBHJ(SettingsManager.instance.squadEvents);
		}
	}

	private void OBJOKFPIPBA(GameObject KHAHPAKDIKE)
	{
		if (!DKIKNOGHHFM())
		{
			SettingsManager.instance.dailyRewardNotification = !SettingsManager.instance.dailyRewardNotification;
			DKPHEECHEGB.MLDOPNFJMBN(SettingsManager.instance.dailyRewardNotification);
		}
	}

	[CompilerGenerated]
	private void DCOJJDIKBBC(GameObject KHAHPAKDIKE)
	{
		if (!DBIHEPECHFL())
		{
			SettingsManager.instance.squadStatus = !SettingsManager.instance.squadStatus;
			FLENNJEIEMN.JCPNPOLKBHJ(SettingsManager.instance.squadStatus);
		}
	}

	private void GPMFBDNDKHO(GameObject KHAHPAKDIKE)
	{
		if (!DKIKNOGHHFM())
		{
			SettingsManager.instance.maintenance = !SettingsManager.instance.maintenance;
			DILDONBLNKC.CPNJHFDPOIM(SettingsManager.instance.maintenance);
		}
	}

	private void POAGJAGIJNI(GameObject KHAHPAKDIKE)
	{
		if (!AHJEEKADOII())
		{
			SettingsManager.instance.maintenance = SettingsManager.instance.maintenance;
			DILDONBLNKC.PJEEJBPFNFA(SettingsManager.instance.maintenance);
		}
	}

	private void ANDKLJCGBOB(GameObject KHAHPAKDIKE)
	{
		if (!FLJEFKFAKJF())
		{
			SettingsManager.instance.squadEvents = SettingsManager.instance.squadEvents;
			ELIMPPCALFP.DOJIMFFIAJN(SettingsManager.instance.squadEvents);
		}
	}

	private void CAGCFLDHAMC(GameObject KHAHPAKDIKE)
	{
		if (!DBIHEPECHFL())
		{
			SettingsManager.instance.maintenance = !SettingsManager.instance.maintenance;
			DILDONBLNKC.EOELBJJBACF(SettingsManager.instance.maintenance);
		}
	}

	private bool AHJEEKADOII()
	{
		if (BundleVersionBindings.pushNotificationEnabled)
		{
			return true;
		}
		if (!DialogManager.instance.ShowEnablePushNotificationsDialog(GuiElementSingle<SettingsDialog>.instance.HECFOEMLJCD))
		{
			Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<EnableNotificationsInSystemDialog>.instance, GuiElementSingle<SettingsDialog>.instance.HECFOEMLJCD);
		}
		return true;
	}

	public void HCMELDFOBCP()
	{
		HGHKPDJKEGI.HDHKBCCMPBK(SettingsManager.instance.playerLeague);
		BPFMHNDAACA.PJEEJBPFNFA(SettingsManager.instance.challenge);
		FLENNJEIEMN.DOJIMFFIAJN(SettingsManager.instance.squadStatus);
		DKPHEECHEGB.BCKGEIFFMGB(SettingsManager.instance.dailyRewardNotification);
		DILDONBLNKC.IBEDIAODLJD(SettingsManager.instance.maintenance);
		if (ELIMPPCALFP.gameObject.activeSelf)
		{
			ELIMPPCALFP.HCGPLHOMJKF(SettingsManager.instance.squadEvents);
		}
	}

	private void OALFKPOPGML(GameObject KHAHPAKDIKE)
	{
		if (!DBIHEPECHFL())
		{
			SettingsManager.instance.squadEvents = SettingsManager.instance.squadEvents;
			ELIMPPCALFP.FICNKKECPHG(SettingsManager.instance.squadEvents);
		}
	}

	private void GEDCMOAKHFO(GameObject KHAHPAKDIKE)
	{
		if (!DKIKNOGHHFM())
		{
			SettingsManager.instance.maintenance = !SettingsManager.instance.maintenance;
			DILDONBLNKC.HCGPLHOMJKF(SettingsManager.instance.maintenance);
		}
	}

	private void IMPBICMABOD(GameObject KHAHPAKDIKE)
	{
		if (!NOKGBHMMGLK())
		{
			SettingsManager.instance.maintenance = SettingsManager.instance.maintenance;
			DILDONBLNKC.FGDLKJOINNE(SettingsManager.instance.maintenance);
		}
	}

	private void ELDICDLIPOM(GameObject KHAHPAKDIKE)
	{
		if (!OMJECMEHFOO())
		{
			SettingsManager.instance.squadStatus = SettingsManager.instance.squadStatus;
			FLENNJEIEMN.HLHCDMFKPCK(SettingsManager.instance.squadStatus);
		}
	}

	private void DLADEIFJEFJ(GameObject KHAHPAKDIKE)
	{
		if (!DKIKNOGHHFM())
		{
			SettingsManager.instance.dailyRewardNotification = !SettingsManager.instance.dailyRewardNotification;
			DKPHEECHEGB.EOELBJJBACF(SettingsManager.instance.dailyRewardNotification);
		}
	}

	public void FHINGMFHKLG()
	{
		UIEventListener uIEventListener = UIEventListener.Get(HGHKPDJKEGI.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(JHENNGOBJCJ));
		UIEventListener uIEventListener2 = UIEventListener.Get(BPFMHNDAACA.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(KODMNNEDCIJ));
		UIEventListener uIEventListener3 = UIEventListener.Get(FLENNJEIEMN.gameObject);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener3.onClick, new UIEventListener.VoidDelegate(GHCODJJEMPA));
		UIEventListener uIEventListener4 = UIEventListener.Get(DKPHEECHEGB.gameObject);
		uIEventListener4.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener4.onClick, new UIEventListener.VoidDelegate(ALAKPDOONDO));
		UIEventListener uIEventListener5 = UIEventListener.Get(DILDONBLNKC.gameObject);
		uIEventListener5.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener5.onClick, new UIEventListener.VoidDelegate(KMEFPIAKHJD));
		UIEventListener uIEventListener6 = UIEventListener.Get(ELIMPPCALFP.gameObject);
		uIEventListener6.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener6.onClick, new UIEventListener.VoidDelegate(ANDKLJCGBOB));
	}

	public void InitControls()
	{
		UIEventListener uIEventListener = UIEventListener.Get(HGHKPDJKEGI.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, (UIEventListener.VoidDelegate)delegate
		{
			if (!DBIHEPECHFL())
			{
				SettingsManager.instance.playerLeague = !SettingsManager.instance.playerLeague;
				HGHKPDJKEGI.JCPNPOLKBHJ(SettingsManager.instance.playerLeague);
			}
		});
		UIEventListener uIEventListener2 = UIEventListener.Get(BPFMHNDAACA.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, (UIEventListener.VoidDelegate)delegate
		{
			if (!DBIHEPECHFL())
			{
				SettingsManager.instance.challenge = !SettingsManager.instance.challenge;
				BPFMHNDAACA.JCPNPOLKBHJ(SettingsManager.instance.challenge);
			}
		});
		UIEventListener uIEventListener3 = UIEventListener.Get(FLENNJEIEMN.gameObject);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener3.onClick, (UIEventListener.VoidDelegate)delegate
		{
			if (!DBIHEPECHFL())
			{
				SettingsManager.instance.squadStatus = !SettingsManager.instance.squadStatus;
				FLENNJEIEMN.JCPNPOLKBHJ(SettingsManager.instance.squadStatus);
			}
		});
		UIEventListener uIEventListener4 = UIEventListener.Get(DKPHEECHEGB.gameObject);
		uIEventListener4.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener4.onClick, (UIEventListener.VoidDelegate)delegate
		{
			if (!DBIHEPECHFL())
			{
				SettingsManager.instance.dailyRewardNotification = !SettingsManager.instance.dailyRewardNotification;
				DKPHEECHEGB.JCPNPOLKBHJ(SettingsManager.instance.dailyRewardNotification);
			}
		});
		UIEventListener uIEventListener5 = UIEventListener.Get(DILDONBLNKC.gameObject);
		uIEventListener5.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener5.onClick, (UIEventListener.VoidDelegate)delegate
		{
			if (!DBIHEPECHFL())
			{
				SettingsManager.instance.maintenance = !SettingsManager.instance.maintenance;
				DILDONBLNKC.JCPNPOLKBHJ(SettingsManager.instance.maintenance);
			}
		});
		UIEventListener uIEventListener6 = UIEventListener.Get(ELIMPPCALFP.gameObject);
		uIEventListener6.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener6.onClick, (UIEventListener.VoidDelegate)delegate
		{
			if (!DBIHEPECHFL())
			{
				SettingsManager.instance.squadEvents = !SettingsManager.instance.squadEvents;
				ELIMPPCALFP.JCPNPOLKBHJ(SettingsManager.instance.squadEvents);
			}
		});
	}

	private void OKNBHFHOHHK(GameObject KHAHPAKDIKE)
	{
		if (!NOKGBHMMGLK())
		{
			SettingsManager.instance.squadStatus = !SettingsManager.instance.squadStatus;
			FLENNJEIEMN.NBAGFDGPFNB(SettingsManager.instance.squadStatus);
		}
	}

	private bool DBIHEPECHFL()
	{
		if (BundleVersionBindings.pushNotificationEnabled)
		{
			return false;
		}
		if (!DialogManager.instance.ShowEnablePushNotificationsDialog(GuiElementSingle<SettingsDialog>.instance.HECFOEMLJCD))
		{
			Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<EnableNotificationsInSystemDialog>.instance, GuiElementSingle<SettingsDialog>.instance.HECFOEMLJCD);
		}
		return true;
	}

	public void EHNFJGINHDJ()
	{
		HGHKPDJKEGI.AHMFMEDODJH(SettingsManager.instance.playerLeague);
		BPFMHNDAACA.MLDOPNFJMBN(SettingsManager.instance.challenge);
		FLENNJEIEMN.PCGLGONPMNM(SettingsManager.instance.squadStatus);
		DKPHEECHEGB.PJEEJBPFNFA(SettingsManager.instance.dailyRewardNotification);
		DILDONBLNKC.DNHOHNOJHCM(SettingsManager.instance.maintenance);
		if (ELIMPPCALFP.gameObject.activeSelf)
		{
			ELIMPPCALFP.MLDOPNFJMBN(SettingsManager.instance.squadEvents);
		}
	}

	public void InitGUIValues()
	{
		HGHKPDJKEGI.JCPNPOLKBHJ(SettingsManager.instance.playerLeague);
		BPFMHNDAACA.JCPNPOLKBHJ(SettingsManager.instance.challenge);
		FLENNJEIEMN.JCPNPOLKBHJ(SettingsManager.instance.squadStatus);
		DKPHEECHEGB.JCPNPOLKBHJ(SettingsManager.instance.dailyRewardNotification);
		DILDONBLNKC.JCPNPOLKBHJ(SettingsManager.instance.maintenance);
		if (ELIMPPCALFP.gameObject.activeSelf)
		{
			ELIMPPCALFP.JCPNPOLKBHJ(SettingsManager.instance.squadEvents);
		}
	}

	private void GHCODJJEMPA(GameObject KHAHPAKDIKE)
	{
		if (!AHJEEKADOII())
		{
			SettingsManager.instance.squadStatus = !SettingsManager.instance.squadStatus;
			FLENNJEIEMN.FGDLKJOINNE(SettingsManager.instance.squadStatus);
		}
	}

	private void BKAMJCOJAOE(GameObject KHAHPAKDIKE)
	{
		if (!NOKGBHMMGLK())
		{
			SettingsManager.instance.challenge = SettingsManager.instance.challenge;
			BPFMHNDAACA.KNEBKGLDIMH(SettingsManager.instance.challenge);
		}
	}

	private void GMFAMOINIPH(GameObject KHAHPAKDIKE)
	{
		if (!DBIHEPECHFL())
		{
			SettingsManager.instance.playerLeague = SettingsManager.instance.playerLeague;
			HGHKPDJKEGI.BHKJNEEGNAP(SettingsManager.instance.playerLeague);
		}
	}

	private void JHENNGOBJCJ(GameObject KHAHPAKDIKE)
	{
		if (!AHJEEKADOII())
		{
			SettingsManager.instance.playerLeague = SettingsManager.instance.playerLeague;
			HGHKPDJKEGI.DOJIMFFIAJN(SettingsManager.instance.playerLeague);
		}
	}

	private void FKCALGEPEMD(GameObject KHAHPAKDIKE)
	{
		if (!AHJEEKADOII())
		{
			SettingsManager.instance.playerLeague = !SettingsManager.instance.playerLeague;
			HGHKPDJKEGI.FGDLKJOINNE(SettingsManager.instance.playerLeague);
		}
	}

	private void GFJFDAHLFBG(GameObject KHAHPAKDIKE)
	{
		if (!NOKGBHMMGLK())
		{
			SettingsManager.instance.challenge = SettingsManager.instance.challenge;
			BPFMHNDAACA.KOHOPHJAAFN(SettingsManager.instance.challenge);
		}
	}

	private void IIBJJEHHEKF(GameObject KHAHPAKDIKE)
	{
		if (!NOKGBHMMGLK())
		{
			SettingsManager.instance.maintenance = !SettingsManager.instance.maintenance;
			DILDONBLNKC.CLIIFEHMKCP(SettingsManager.instance.maintenance);
		}
	}

	[CompilerGenerated]
	private void EACNIDLHDGD(GameObject KHAHPAKDIKE)
	{
		if (!DBIHEPECHFL())
		{
			SettingsManager.instance.dailyRewardNotification = !SettingsManager.instance.dailyRewardNotification;
			DKPHEECHEGB.JCPNPOLKBHJ(SettingsManager.instance.dailyRewardNotification);
		}
	}

	private void BLLKBLCPNLH(GameObject KHAHPAKDIKE)
	{
		if (!DBIHEPECHFL())
		{
			SettingsManager.instance.squadStatus = !SettingsManager.instance.squadStatus;
			FLENNJEIEMN.DOJIMFFIAJN(SettingsManager.instance.squadStatus);
		}
	}

	private void BPCKLFHMPCJ(GameObject KHAHPAKDIKE)
	{
		if (!DKIKNOGHHFM())
		{
			SettingsManager.instance.challenge = !SettingsManager.instance.challenge;
			BPFMHNDAACA.FICNKKECPHG(SettingsManager.instance.challenge);
		}
	}

	private void PKICGGPLKDI(GameObject KHAHPAKDIKE)
	{
		if (!DKIKNOGHHFM())
		{
			SettingsManager.instance.maintenance = SettingsManager.instance.maintenance;
			DILDONBLNKC.ECCCJOFEJNG(SettingsManager.instance.maintenance);
		}
	}

	[CompilerGenerated]
	private void HMGMPCIHJIC(GameObject KHAHPAKDIKE)
	{
		if (!DBIHEPECHFL())
		{
			SettingsManager.instance.challenge = !SettingsManager.instance.challenge;
			BPFMHNDAACA.JCPNPOLKBHJ(SettingsManager.instance.challenge);
		}
	}

	private void ALAKPDOONDO(GameObject KHAHPAKDIKE)
	{
		if (!OMJECMEHFOO())
		{
			SettingsManager.instance.dailyRewardNotification = SettingsManager.instance.dailyRewardNotification;
			DKPHEECHEGB.APIHMGMDDHC(SettingsManager.instance.dailyRewardNotification);
		}
	}

	public void JNDJIOOGPGD()
	{
		UIEventListener uIEventListener = UIEventListener.Get(HGHKPDJKEGI.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(JHENNGOBJCJ));
		UIEventListener uIEventListener2 = UIEventListener.Get(BPFMHNDAACA.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(BKAMJCOJAOE));
		UIEventListener uIEventListener3 = UIEventListener.Get(FLENNJEIEMN.gameObject);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener3.onClick, new UIEventListener.VoidDelegate(KCPGPJPGJLC));
		UIEventListener uIEventListener4 = UIEventListener.Get(DKPHEECHEGB.gameObject);
		uIEventListener4.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener4.onClick, new UIEventListener.VoidDelegate(OBJOKFPIPBA));
		UIEventListener uIEventListener5 = UIEventListener.Get(DILDONBLNKC.gameObject);
		uIEventListener5.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener5.onClick, new UIEventListener.VoidDelegate(CAGCFLDHAMC));
		UIEventListener uIEventListener6 = UIEventListener.Get(ELIMPPCALFP.gameObject);
		uIEventListener6.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener6.onClick, new UIEventListener.VoidDelegate(OALFKPOPGML));
	}

	private void KMEFPIAKHJD(GameObject KHAHPAKDIKE)
	{
		if (!OMJECMEHFOO())
		{
			SettingsManager.instance.maintenance = !SettingsManager.instance.maintenance;
			DILDONBLNKC.FGDLKJOINNE(SettingsManager.instance.maintenance);
		}
	}

	private void JECNKDGGJNC(GameObject KHAHPAKDIKE)
	{
		if (!NOKGBHMMGLK())
		{
			SettingsManager.instance.squadStatus = !SettingsManager.instance.squadStatus;
			FLENNJEIEMN.JLDBLKLBCEG(SettingsManager.instance.squadStatus);
		}
	}

	public void PAHEFBCOENP()
	{
		HGHKPDJKEGI.NCCLGCBAOGP(SettingsManager.instance.playerLeague);
		BPFMHNDAACA.NCCLGCBAOGP(SettingsManager.instance.challenge);
		FLENNJEIEMN.DNHOHNOJHCM(SettingsManager.instance.squadStatus);
		DKPHEECHEGB.CGDPBGICENJ(SettingsManager.instance.dailyRewardNotification);
		DILDONBLNKC.EOELBJJBACF(SettingsManager.instance.maintenance);
		if (ELIMPPCALFP.gameObject.activeSelf)
		{
			ELIMPPCALFP.ECCCJOFEJNG(SettingsManager.instance.squadEvents);
		}
	}

	public void GMJCEEHFAJG()
	{
		UIEventListener uIEventListener = UIEventListener.Get(HGHKPDJKEGI.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(GMFAMOINIPH));
		UIEventListener uIEventListener2 = UIEventListener.Get(BPFMHNDAACA.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(GFJFDAHLFBG));
		UIEventListener uIEventListener3 = UIEventListener.Get(FLENNJEIEMN.gameObject);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener3.onClick, new UIEventListener.VoidDelegate(POCNKGOFCCP));
		UIEventListener uIEventListener4 = UIEventListener.Get(DKPHEECHEGB.gameObject);
		uIEventListener4.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener4.onClick, (UIEventListener.VoidDelegate)delegate
		{
			if (!DBIHEPECHFL())
			{
				SettingsManager.instance.dailyRewardNotification = !SettingsManager.instance.dailyRewardNotification;
				DKPHEECHEGB.JCPNPOLKBHJ(SettingsManager.instance.dailyRewardNotification);
			}
		});
		UIEventListener uIEventListener5 = UIEventListener.Get(DILDONBLNKC.gameObject);
		uIEventListener5.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener5.onClick, new UIEventListener.VoidDelegate(IMPBICMABOD));
		UIEventListener uIEventListener6 = UIEventListener.Get(ELIMPPCALFP.gameObject);
		uIEventListener6.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener6.onClick, (UIEventListener.VoidDelegate)delegate
		{
			if (!DBIHEPECHFL())
			{
				SettingsManager.instance.squadEvents = !SettingsManager.instance.squadEvents;
				ELIMPPCALFP.JCPNPOLKBHJ(SettingsManager.instance.squadEvents);
			}
		});
	}

	private void BEDGCIFBDJG(GameObject KHAHPAKDIKE)
	{
		if (!NOKGBHMMGLK())
		{
			SettingsManager.instance.maintenance = SettingsManager.instance.maintenance;
			DILDONBLNKC.NCCLGCBAOGP(SettingsManager.instance.maintenance);
		}
	}

	private void IFLEKKDBNBF(GameObject KHAHPAKDIKE)
	{
		if (!FLJEFKFAKJF())
		{
			SettingsManager.instance.challenge = SettingsManager.instance.challenge;
			BPFMHNDAACA.PEAHMOOPMIL(SettingsManager.instance.challenge);
		}
	}

	private bool OMJECMEHFOO()
	{
		if (BundleVersionBindings.pushNotificationEnabled)
		{
			return false;
		}
		if (!DialogManager.instance.ShowEnablePushNotificationsDialog(GuiElementSingle<SettingsDialog>.instance.HECFOEMLJCD))
		{
			Singleton<GuiManager>.instance.ShowDialog(GuiElementSingle<EnableNotificationsInSystemDialog>.instance, GuiElementSingle<SettingsDialog>.instance.HECFOEMLJCD);
		}
		return true;
	}

	private void KODMNNEDCIJ(GameObject KHAHPAKDIKE)
	{
		if (!NOKGBHMMGLK())
		{
			SettingsManager.instance.challenge = SettingsManager.instance.challenge;
			BPFMHNDAACA.BHKJNEEGNAP(SettingsManager.instance.challenge);
		}
	}

	private void PHNIDKNOFJO(GameObject KHAHPAKDIKE)
	{
		if (!AHJEEKADOII())
		{
			SettingsManager.instance.challenge = !SettingsManager.instance.challenge;
			BPFMHNDAACA.LBMHPJBBDCI(SettingsManager.instance.challenge);
		}
	}
}
