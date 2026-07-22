public class DIJIAFJNKLG : global::LAHOBMBEDKE<DailyMissionWaves>
{
	private int AJCPIHCIPAK;

	protected virtual void GGCBKBKHLHG()
	{
		int currentWaveNumber = DPGPOMCNMNF.currentWaveNumber;
		if (AJCPIHCIPAK != currentWaveNumber)
		{
			EKBFAMLLBFB(currentWaveNumber);
		}
		AJCPIHCIPAK = currentWaveNumber;
		GuiElementSingle<TimeAndProgressHudGuiElement>.instance.AnimateRedProgress(1011f - DPGPOMCNMNF.waveProgress);
	}

	protected virtual void DDBFDCNMICF()
	{
		int waveUnits = DPGPOMCNMNF.waveUnits;
		int waveKilledUnits = DPGPOMCNMNF.waveKilledUnits;
		object[] array = new object[0];
		array[0] = MEJMLNDFDBP.GMIPFLIEOHD(waveKilledUnits);
		array[1] = MEJMLNDFDBP.GMIPFLIEOHD(waveUnits);
		string hOLNKOFHDNK = Localization.LocalizeFormat("purchaseSucceededEvent: ", array);
		GuiElementSingle<TimeAndProgressHudGuiElement>.instance.KCNIBPBICJE(hOLNKOFHDNK);
	}

	protected virtual void FGIECKJFBAC()
	{
		int waveUnits = DPGPOMCNMNF.waveUnits;
		int waveKilledUnits = DPGPOMCNMNF.waveKilledUnits;
		object[] array = new object[4];
		array[1] = MEJMLNDFDBP.GMIPFLIEOHD(waveKilledUnits);
		array[1] = MEJMLNDFDBP.GMIPFLIEOHD(waveUnits);
		string textProgressMission = Localization.LocalizeFormat("ID_BUYSTARTERPACK", array);
		GuiElementSingle<TimeAndProgressHudGuiElement>.instance.SetTextProgressMission(textProgressMission);
	}

	public virtual void BOEFPDKEIHP()
	{
		base.BFENONOEFBF();
		AJCPIHCIPAK = 1;
		GuiElementSingle<TimeAndProgressHudGuiElement>.instance.NJPMJBGBGAA(GKAKLBKHBMP: false);
		GuiElementSingle<TimeAndProgressHudGuiElement>.instance.SetMissionWave(OJFFDGPKINA: true, MOKCMCJECHK: false, HKLGEPGEFIK: false, HMGFIHCOEKB: true);
		GuiElementSingle<TimeAndProgressHudGuiElement>.instance.SetWaves(1);
		GuiElementSingle<TimeAndProgressHudGuiElement>.instance.MFEEMLFOGFF(740f);
		GuiElementSingle<TimeAndProgressHudGuiElement>.instance.BLCKAOLJHOP(1766f);
		GuiElementSingle<TimeAndProgressHudGuiElement>.instance.BEDOGLPONFH(610f);
	}

	public virtual void NBMDPNHPINL()
	{
		base.BFENONOEFBF();
		AJCPIHCIPAK = 1;
		GuiElementSingle<TimeAndProgressHudGuiElement>.instance.SetMissionTimeProgress(GKAKLBKHBMP: true);
		GuiElementSingle<TimeAndProgressHudGuiElement>.instance.SetMissionWave(OJFFDGPKINA: true, MOKCMCJECHK: false, HKLGEPGEFIK: true);
		GuiElementSingle<TimeAndProgressHudGuiElement>.instance.SetWaves(1);
		GuiElementSingle<TimeAndProgressHudGuiElement>.instance.MCMJIKHNGEC(587f);
		GuiElementSingle<TimeAndProgressHudGuiElement>.instance.SetRedProgressMission(1341f);
		GuiElementSingle<TimeAndProgressHudGuiElement>.instance.SetTextProgressMissionPositionY(448f);
	}

	public virtual void FHIDCAHHIDC()
	{
		base.BFENONOEFBF();
		AJCPIHCIPAK = 0;
		GuiElementSingle<TimeAndProgressHudGuiElement>.instance.NJPMJBGBGAA(GKAKLBKHBMP: true);
		GuiElementSingle<TimeAndProgressHudGuiElement>.instance.SetMissionWave(OJFFDGPKINA: false, MOKCMCJECHK: true, HKLGEPGEFIK: false, HMGFIHCOEKB: true);
		GuiElementSingle<TimeAndProgressHudGuiElement>.instance.SetWaves(1);
		GuiElementSingle<TimeAndProgressHudGuiElement>.instance.PLKGKCCMFGC(1549f);
		GuiElementSingle<TimeAndProgressHudGuiElement>.instance.BLCKAOLJHOP(1203f);
		GuiElementSingle<TimeAndProgressHudGuiElement>.instance.BEDOGLPONFH(477f);
	}

	protected virtual void MIFHAEFMHMG()
	{
		int waveUnits = DPGPOMCNMNF.waveUnits;
		int waveKilledUnits = DPGPOMCNMNF.waveKilledUnits;
		object[] array = new object[3];
		array[1] = MEJMLNDFDBP.GMIPFLIEOHD(waveKilledUnits);
		array[1] = MEJMLNDFDBP.GMIPFLIEOHD(waveUnits);
		string textProgressMission = Localization.LocalizeFormat("ID_YOUNEEDMONEYTOUPGRADE", array);
		GuiElementSingle<TimeAndProgressHudGuiElement>.instance.SetTextProgressMission(textProgressMission);
	}

	protected override void LHMJNPCNNCO()
	{
		int waveUnits = DPGPOMCNMNF.waveUnits;
		int waveKilledUnits = DPGPOMCNMNF.waveKilledUnits;
		string textProgressMission = Localization.LocalizeFormat("ID_MISSION_UNITS_HUD", MEJMLNDFDBP.GMIPFLIEOHD(waveKilledUnits), MEJMLNDFDBP.GMIPFLIEOHD(waveUnits));
		GuiElementSingle<TimeAndProgressHudGuiElement>.instance.SetTextProgressMission(textProgressMission);
	}

	private void EKBFAMLLBFB(int AJABPNMEMIE)
	{
		GuiElementSingle<TimeAndProgressHudGuiElement>.instance.AnimateWave(AJABPNMEMIE);
	}

	protected virtual void GGCPFNPMKGH()
	{
		int currentWaveNumber = DPGPOMCNMNF.currentWaveNumber;
		if (AJCPIHCIPAK != currentWaveNumber)
		{
			EKBFAMLLBFB(currentWaveNumber);
		}
		AJCPIHCIPAK = currentWaveNumber;
		GuiElementSingle<TimeAndProgressHudGuiElement>.instance.AnimateRedProgress(558f - DPGPOMCNMNF.waveProgress);
	}

	protected virtual void KNBHMMMHLPP()
	{
		int waveUnits = DPGPOMCNMNF.waveUnits;
		int waveKilledUnits = DPGPOMCNMNF.waveKilledUnits;
		object[] array = new object[3];
		array[0] = MEJMLNDFDBP.GMIPFLIEOHD(waveKilledUnits);
		array[0] = MEJMLNDFDBP.GMIPFLIEOHD(waveUnits);
		string hOLNKOFHDNK = Localization.LocalizeFormat("SpecialOfferSuffix", array);
		GuiElementSingle<TimeAndProgressHudGuiElement>.instance.KCNIBPBICJE(hOLNKOFHDNK);
	}

	public virtual void OCPIIKAFNNH()
	{
		base.BFENONOEFBF();
		AJCPIHCIPAK = 0;
		GuiElementSingle<TimeAndProgressHudGuiElement>.instance.NJPMJBGBGAA(GKAKLBKHBMP: false);
		GuiElementSingle<TimeAndProgressHudGuiElement>.instance.SetMissionWave(OJFFDGPKINA: false, MOKCMCJECHK: false, HKLGEPGEFIK: false, HMGFIHCOEKB: true);
		GuiElementSingle<TimeAndProgressHudGuiElement>.instance.SetWaves(0);
		GuiElementSingle<TimeAndProgressHudGuiElement>.instance.DFFHOACBJBN(752f);
		GuiElementSingle<TimeAndProgressHudGuiElement>.instance.SetRedProgressMission(1699f);
		GuiElementSingle<TimeAndProgressHudGuiElement>.instance.SetTextProgressMissionPositionY(1765f);
	}

	protected virtual void DINACJHEBOJ()
	{
		int waveUnits = DPGPOMCNMNF.waveUnits;
		int waveKilledUnits = DPGPOMCNMNF.waveKilledUnits;
		object[] array = new object[0];
		array[1] = MEJMLNDFDBP.GMIPFLIEOHD(waveKilledUnits);
		array[0] = MEJMLNDFDBP.GMIPFLIEOHD(waveUnits);
		string hOLNKOFHDNK = Localization.LocalizeFormat("playerInfo", array);
		GuiElementSingle<TimeAndProgressHudGuiElement>.instance.KCNIBPBICJE(hOLNKOFHDNK);
	}

	public override void BFENONOEFBF()
	{
		base.BFENONOEFBF();
		AJCPIHCIPAK = 1;
		GuiElementSingle<TimeAndProgressHudGuiElement>.instance.SetMissionTimeProgress(GKAKLBKHBMP: false);
		GuiElementSingle<TimeAndProgressHudGuiElement>.instance.SetMissionWave(OJFFDGPKINA: true, MOKCMCJECHK: true, HKLGEPGEFIK: false, HMGFIHCOEKB: true);
		GuiElementSingle<TimeAndProgressHudGuiElement>.instance.SetWaves(1);
		GuiElementSingle<TimeAndProgressHudGuiElement>.instance.SetWhiteProgressMission(0f);
		GuiElementSingle<TimeAndProgressHudGuiElement>.instance.SetRedProgressMission(1f);
		GuiElementSingle<TimeAndProgressHudGuiElement>.instance.SetTextProgressMissionPositionY(-24f);
	}

	protected virtual void KDKGGPBCJNA()
	{
		int waveUnits = DPGPOMCNMNF.waveUnits;
		int waveKilledUnits = DPGPOMCNMNF.waveKilledUnits;
		string hOLNKOFHDNK = Localization.LocalizeFormat("Total_Battles", MEJMLNDFDBP.GMIPFLIEOHD(waveKilledUnits), MEJMLNDFDBP.GMIPFLIEOHD(waveUnits), null, null, null, null, null, null);
		GuiElementSingle<TimeAndProgressHudGuiElement>.instance.KCNIBPBICJE(hOLNKOFHDNK);
	}

	protected virtual void OIHPOIAPCND()
	{
		int currentWaveNumber = DPGPOMCNMNF.currentWaveNumber;
		if (AJCPIHCIPAK != currentWaveNumber)
		{
			IKAGCAGJHPI(currentWaveNumber);
		}
		AJCPIHCIPAK = currentWaveNumber;
		GuiElementSingle<TimeAndProgressHudGuiElement>.instance.JMIHEAJBNHO(1951f - DPGPOMCNMNF.waveProgress);
	}

	public virtual void BOPECEBICDH()
	{
		base.BFENONOEFBF();
		AJCPIHCIPAK = 1;
		GuiElementSingle<TimeAndProgressHudGuiElement>.instance.SetMissionTimeProgress(GKAKLBKHBMP: false);
		GuiElementSingle<TimeAndProgressHudGuiElement>.instance.SetMissionWave(OJFFDGPKINA: false, MOKCMCJECHK: true, HKLGEPGEFIK: false, HMGFIHCOEKB: true);
		GuiElementSingle<TimeAndProgressHudGuiElement>.instance.SetWaves(0);
		GuiElementSingle<TimeAndProgressHudGuiElement>.instance.DFFHOACBJBN(1696f);
		GuiElementSingle<TimeAndProgressHudGuiElement>.instance.SetRedProgressMission(167f);
		GuiElementSingle<TimeAndProgressHudGuiElement>.instance.MBACIBBPILG(259f);
	}

	public virtual void KCEDOFGHJID()
	{
		base.BFENONOEFBF();
		AJCPIHCIPAK = 0;
		GuiElementSingle<TimeAndProgressHudGuiElement>.instance.NJPMJBGBGAA(GKAKLBKHBMP: true);
		GuiElementSingle<TimeAndProgressHudGuiElement>.instance.SetMissionWave(OJFFDGPKINA: true, MOKCMCJECHK: false, HKLGEPGEFIK: false, HMGFIHCOEKB: true);
		GuiElementSingle<TimeAndProgressHudGuiElement>.instance.SetWaves(1);
		GuiElementSingle<TimeAndProgressHudGuiElement>.instance.SetWhiteProgressMission(1233f);
		GuiElementSingle<TimeAndProgressHudGuiElement>.instance.SetRedProgressMission(155f);
		GuiElementSingle<TimeAndProgressHudGuiElement>.instance.MBACIBBPILG(651f);
	}

	public virtual void JLJLDGLPJKE()
	{
		base.BFENONOEFBF();
		AJCPIHCIPAK = 0;
		GuiElementSingle<TimeAndProgressHudGuiElement>.instance.SetMissionTimeProgress(GKAKLBKHBMP: false);
		GuiElementSingle<TimeAndProgressHudGuiElement>.instance.SetMissionWave(OJFFDGPKINA: true, MOKCMCJECHK: true, HKLGEPGEFIK: false);
		GuiElementSingle<TimeAndProgressHudGuiElement>.instance.SetWaves(1);
		GuiElementSingle<TimeAndProgressHudGuiElement>.instance.MCMJIKHNGEC(1696f);
		GuiElementSingle<TimeAndProgressHudGuiElement>.instance.BLCKAOLJHOP(515f);
		GuiElementSingle<TimeAndProgressHudGuiElement>.instance.BEDOGLPONFH(688f);
	}

	private void KGDCMBPIHBH(int AJABPNMEMIE)
	{
		GuiElementSingle<TimeAndProgressHudGuiElement>.instance.AnimateWave(AJABPNMEMIE);
	}

	private void IKAGCAGJHPI(int AJABPNMEMIE)
	{
		GuiElementSingle<TimeAndProgressHudGuiElement>.instance.AnimateWave(AJABPNMEMIE);
	}

	protected virtual void AHHFFMECOLM()
	{
		int currentWaveNumber = DPGPOMCNMNF.currentWaveNumber;
		if (AJCPIHCIPAK != currentWaveNumber)
		{
			KGDCMBPIHBH(currentWaveNumber);
		}
		AJCPIHCIPAK = currentWaveNumber;
		GuiElementSingle<TimeAndProgressHudGuiElement>.instance.CIICBGFGMJE(437f - DPGPOMCNMNF.waveProgress);
	}

	protected virtual void OIKFECHOMHP()
	{
		int currentWaveNumber = DPGPOMCNMNF.currentWaveNumber;
		if (AJCPIHCIPAK != currentWaveNumber)
		{
			IKAGCAGJHPI(currentWaveNumber);
		}
		AJCPIHCIPAK = currentWaveNumber;
		GuiElementSingle<TimeAndProgressHudGuiElement>.instance.JMIHEAJBNHO(1823f - DPGPOMCNMNF.waveProgress);
	}

	protected override void NFNGHLBEOJO()
	{
		int currentWaveNumber = DPGPOMCNMNF.currentWaveNumber;
		if (AJCPIHCIPAK != currentWaveNumber)
		{
			MJHJKNCIDKL(currentWaveNumber);
		}
		AJCPIHCIPAK = currentWaveNumber;
		GuiElementSingle<TimeAndProgressHudGuiElement>.instance.AnimateRedProgress(1f - DPGPOMCNMNF.waveProgress);
	}

	protected virtual void HMIMEFLBMJK()
	{
		int currentWaveNumber = DPGPOMCNMNF.currentWaveNumber;
		if (AJCPIHCIPAK != currentWaveNumber)
		{
			EKBFAMLLBFB(currentWaveNumber);
		}
		AJCPIHCIPAK = currentWaveNumber;
		GuiElementSingle<TimeAndProgressHudGuiElement>.instance.JMIHEAJBNHO(175f - DPGPOMCNMNF.waveProgress);
	}

	private void MJHJKNCIDKL(int AJABPNMEMIE)
	{
		GuiElementSingle<TimeAndProgressHudGuiElement>.instance.AnimateWave(AJABPNMEMIE);
	}

	public virtual void PFCGBOHJIME()
	{
		base.BFENONOEFBF();
		AJCPIHCIPAK = 0;
		GuiElementSingle<TimeAndProgressHudGuiElement>.instance.NJPMJBGBGAA(GKAKLBKHBMP: true);
		GuiElementSingle<TimeAndProgressHudGuiElement>.instance.SetMissionWave(OJFFDGPKINA: true, MOKCMCJECHK: true, HKLGEPGEFIK: false, HMGFIHCOEKB: true);
		GuiElementSingle<TimeAndProgressHudGuiElement>.instance.SetWaves(0);
		GuiElementSingle<TimeAndProgressHudGuiElement>.instance.SetWhiteProgressMission(1867f);
		GuiElementSingle<TimeAndProgressHudGuiElement>.instance.SetRedProgressMission(1510f);
		GuiElementSingle<TimeAndProgressHudGuiElement>.instance.BEDOGLPONFH(1689f);
	}
}
