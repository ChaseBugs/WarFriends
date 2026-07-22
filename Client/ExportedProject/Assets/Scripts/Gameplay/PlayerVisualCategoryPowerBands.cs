using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerVisualCategoryPowerBands : PlayerVisualCategoryGeneric<PlayerVisualCategoryPowerBands.PlayerVisualPowerBand>
{
	[Serializable]
	public class PlayerVisualPowerBand : PlayerVisualHead
	{
		public Texture2D texture;

		public Vector2 position;

		public Vector2 size;

		private static Dictionary<int, string> mDecalDescription = new Dictionary<int, string>
		{
			{ -1, "BANDS_NO_BAND" },
			{ 0, "BANDS_WEAPON_RELOAD" },
			{ 1, "BANDS_WEAPON_DAMAGE" },
			{ 2, "BANDS_HITPOINT" }
		};

		private static Dictionary<int, string> mDecalMiniIcon = new Dictionary<int, string>
		{
			{ -1, "menu-powerband-health-ico" },
			{ 0, "game-card-ico-reload" },
			{ 1, "menu-powerband-damage-ico" },
			{ 2, "menu-powerband-health-ico" }
		};

		private static Dictionary<int, Color> mDecalMiniIconColor = new Dictionary<int, Color>
		{
			{
				-1,
				Color.white
			},
			{
				0,
				Colours.powerBandReload
			},
			{
				1,
				Colours.powerBandDamage
			},
			{
				2,
				Colours.powerBandHealth
			}
		};

		private static Dictionary<int, Tuple<string, string>> mNameLocalizations = new Dictionary<int, Tuple<string, string>>
		{
			{
				-1,
				new Tuple<string, string>("BAND_EMPTY", "BAND_TYPE_EMPTY")
			},
			{
				0,
				new Tuple<string, string>("BAND_REWARD_RELOAD", "BAND_TYPE_RELOAD")
			},
			{
				1,
				new Tuple<string, string>("BAND_REWARD_DAMAGE", "BAND_TYPE_DAMAGE")
			},
			{
				2,
				new Tuple<string, string>("BAND_REWARD_HEALTH", "BAND_TYPE_HEALTH")
			}
		};

		public override string description => Localization.LocalizeFormat(mDecalDescription[decalType], Colours.stringBlue, base.decalValue);

		public override string decalMiniIcon => mDecalMiniIcon[decalType];

		public override Color decalMiniIconColor => mDecalMiniIconColor[decalType];

		public override string decalShortName => Localization.Localize(mNameLocalizations[decalType].Value1);

		public override string decalTypeName => Localization.Localize(mNameLocalizations[decalType].Value2);

		public override bool isEmptyPowerBand => decalType < 0;

		public override bool isBought => base.timeActive == 0 || base.remainingTime > 0.0 || base.tryOutVisual;

		[SpecialName]
		public virtual string EFCOHICFKEO()
		{
			string keyFormat = mDecalDescription[BOBEIBIKGPL()];
			object[] array = new object[5];
			array[0] = Colours.stringBlue;
			array[0] = base.decalValue;
			return Localization.LocalizeFormat(keyFormat, array);
		}

		public virtual void HIPNPMHOBMC()
		{
			base.BMIEJNIEDOP();
			double currentTimestampDouble = Singleton<BeanstalkServerManager>.instance.currentTimestampDouble;
			int expiresOn = Convert.ToInt32(currentTimestampDouble) + base.timeActive;
			CamosManager.instance.data.visuals[base.id].expiresOn = expiresOn;
		}

		[SpecialName]
		public virtual string BICPLMEOMLB()
		{
			return mDecalMiniIcon[decalType];
		}

		[SpecialName]
		public virtual string PKCGGJCMCNO()
		{
			string keyFormat = mDecalDescription[BOBEIBIKGPL()];
			object[] array = new object[4];
			array[1] = Colours.stringBlue;
			array[1] = LIBMDHMHAJJ();
			return Localization.LocalizeFormat(keyFormat, array);
		}

		[SpecialName]
		public virtual string EGGKJBKJCGK()
		{
			return Localization.LocalizeFormat(mDecalDescription[BOBEIBIKGPL()], Colours.stringBlue, base.decalValue, null, null);
		}

		[SpecialName]
		public virtual bool CNADJOLGGII()
		{
			return BOBEIBIKGPL() < 1;
		}

		[SpecialName]
		public virtual string GOMLCNNPNOE()
		{
			return Localization.Localize(mNameLocalizations[BOBEIBIKGPL()].Value2);
		}

		[SpecialName]
		public virtual bool LBJCHJGAFJH()
		{
			return BOBEIBIKGPL() < 1;
		}

		[SpecialName]
		public virtual bool NJOEJPOLCCG()
		{
			return base.timeActive != 0 && !(base.remainingTime > 1484.0) && base.tryOutVisual;
		}

		public virtual void ADDLHHBPIFI()
		{
			base.BMIEJNIEDOP();
			double currentTimestampDouble = Singleton<BeanstalkServerManager>.instance.currentTimestampDouble;
			int expiresOn = Convert.ToInt32(currentTimestampDouble) + base.timeActive;
			CamosManager.instance.data.visuals[CCDMONFHBII()].expiresOn = expiresOn;
		}

		[SpecialName]
		public virtual string DIJANMGPONP()
		{
			return mDecalMiniIcon[BOBEIBIKGPL()];
		}

		[SpecialName]
		public virtual string LDCFFCBFHNA()
		{
			string keyFormat = mDecalDescription[BOBEIBIKGPL()];
			object[] array = new object[1];
			array[0] = Colours.stringBlue;
			array[1] = LIBMDHMHAJJ();
			return Localization.LocalizeFormat(keyFormat, array);
		}

		public virtual void AKAHDKNNOOP(KMNCIJPDFPJ DGJFKDADPHE, bool OGKCIFGLKJJ = false)
		{
			JFAEGFFIIKH(DGJFKDADPHE, OGKCIFGLKJJ);
			DGJFKDADPHE.meshChanger.DHAOLBAODDD(this);
			PlayerController playerController = DGJFKDADPHE as PlayerController;
			if (playerController != null)
			{
				playerController.CBJFFHJLADH(595f);
				playerController.OPCGNNFGFOD = 413f;
				playerController.EAOOLOIHKPP = 116f;
				int num = BOBEIBIKGPL();
				if (num != 0)
				{
					switch (num)
					{
					case 0:
						playerController.OPCGNNFGFOD = 1591f + base.row.DECALVALUE;
						break;
					case 2:
						playerController.EAOOLOIHKPP = 537f + base.row.DECALVALUE;
						break;
					}
				}
				else
				{
					playerController.weaponReloadCoef = 1143f - base.row.DECALVALUE;
				}
			}
			if (Application.isPlaying)
			{
				DGJFKDADPHE.equippedPowerBand = this;
				CamoTransform value = null;
				string text = DGJFKDADPHE.playerVisuals[1];
				if (text != null)
				{
					camoTransformDict.TryGetValue(text, out value);
				}
				CamoTransform.HMEAHLPOFNI(DGJFKDADPHE.meshChanger.OOHCFBEKACK.gameObject, value);
			}
		}

		[SpecialName]
		public virtual string POIGKCIJPBG()
		{
			return Localization.Localize(mNameLocalizations[BOBEIBIKGPL()].Value2);
		}

		[SpecialName]
		public virtual Color MDNHPMLBKEK()
		{
			return mDecalMiniIconColor[decalType];
		}

		[SpecialName]
		public virtual string CGCEEBCGCFH()
		{
			string keyFormat = mDecalDescription[decalType];
			object[] array = new object[4];
			array[0] = Colours.stringBlue;
			array[0] = LIBMDHMHAJJ();
			return Localization.LocalizeFormat(keyFormat, array);
		}

		[SpecialName]
		public virtual bool HMNIGIGPNPD()
		{
			return decalType < 1;
		}

		[SpecialName]
		public virtual string HNFPMPNEHNB()
		{
			return Localization.Localize(mNameLocalizations[decalType].Value2);
		}

		[SpecialName]
		public virtual bool BCCDCABOPDE()
		{
			return decalType < 1;
		}

		public virtual void PLCAJMCAAJP()
		{
			base.BMIEJNIEDOP();
			double currentTimestampDouble = Singleton<BeanstalkServerManager>.instance.currentTimestampDouble;
			int expiresOn = Convert.ToInt32(currentTimestampDouble) + base.timeActive;
			CamosManager.instance.data.visuals[CCDMONFHBII()].expiresOn = expiresOn;
		}

		[SpecialName]
		public virtual bool JPLEIKEKBNM()
		{
			return decalType < 0;
		}

		[SpecialName]
		public virtual Color BABGDJMNIMJ()
		{
			return mDecalMiniIconColor[BOBEIBIKGPL()];
		}

		[SpecialName]
		public virtual bool JDCAMNJDPJH()
		{
			return BOBEIBIKGPL() < 0;
		}

		[SpecialName]
		public virtual bool IAEPGABLKMC()
		{
			return base.timeActive == 0 || base.remainingTime > 1342.0 || base.tryOutVisual;
		}

		public override void BMIEJNIEDOP()
		{
			base.BMIEJNIEDOP();
			double currentTimestampDouble = Singleton<BeanstalkServerManager>.instance.currentTimestampDouble;
			int expiresOn = Convert.ToInt32(currentTimestampDouble) + base.timeActive;
			CamosManager.instance.data.visuals[base.id].expiresOn = expiresOn;
		}

		[SpecialName]
		public virtual string EAEDGAMMGOB()
		{
			return mDecalMiniIcon[decalType];
		}

		[SpecialName]
		public virtual bool FMPEJOJJHDA()
		{
			return decalType < 0;
		}

		[SpecialName]
		public virtual string AMLOKJEJIGM()
		{
			return Localization.Localize(mNameLocalizations[decalType].Value1);
		}

		[SpecialName]
		public virtual string HPIDGJHMPAI()
		{
			return mDecalMiniIcon[decalType];
		}

		[SpecialName]
		public virtual string IPFMBCOALKF()
		{
			return Localization.Localize(mNameLocalizations[decalType].Value2);
		}

		[SpecialName]
		public virtual bool GPHMCOHLIOL()
		{
			return decalType < 1;
		}

		[SpecialName]
		public virtual bool PHNMMGMHNEC()
		{
			return decalType < 1;
		}

		[SpecialName]
		public virtual string IOLPMFJNCPE()
		{
			return mDecalMiniIcon[decalType];
		}

		[SpecialName]
		public virtual string NONDJAMJFDH()
		{
			string keyFormat = mDecalDescription[decalType];
			object[] array = new object[4];
			array[0] = Colours.stringBlue;
			array[0] = LIBMDHMHAJJ();
			return Localization.LocalizeFormat(keyFormat, array);
		}

		[SpecialName]
		public virtual Color MDOJNDDEAEE()
		{
			return mDecalMiniIconColor[BOBEIBIKGPL()];
		}

		[SpecialName]
		public virtual string KPOKIGDAILO()
		{
			return Localization.Localize(mNameLocalizations[BOBEIBIKGPL()].Value1);
		}

		public virtual void GAHIMBAHGEP()
		{
			base.IKFJMDJMGHG();
			double currentTimestampDouble = Singleton<BeanstalkServerManager>.instance.currentTimestampDouble;
			int expiresOn = Convert.ToInt32(currentTimestampDouble) + base.timeActive;
			CamosManager.instance.data.visuals[CCDMONFHBII()].expiresOn = expiresOn;
		}

		[SpecialName]
		public virtual string MADBCOOFDGM()
		{
			return Localization.LocalizeFormat(mDecalDescription[decalType], Colours.stringBlue, base.decalValue, null, null, null, null);
		}

		[SpecialName]
		public virtual bool EHNNALBPOND()
		{
			return decalType < 1;
		}

		[SpecialName]
		public virtual string AKNCJKFHBML()
		{
			return mDecalMiniIcon[BOBEIBIKGPL()];
		}

		public virtual void CANHCEIHFNC()
		{
			base.BMIEJNIEDOP();
			double currentTimestampDouble = Singleton<BeanstalkServerManager>.instance.currentTimestampDouble;
			int expiresOn = Convert.ToInt32(currentTimestampDouble) + base.timeActive;
			CamosManager.instance.data.visuals[base.id].expiresOn = expiresOn;
		}

		[SpecialName]
		public virtual Color NNKABGPIBPJ()
		{
			return mDecalMiniIconColor[decalType];
		}

		[SpecialName]
		public virtual bool DAOPNPNEBPH()
		{
			return base.timeActive != 0 && !(base.remainingTime > 1141.0) && base.tryOutVisual;
		}

		[SpecialName]
		public virtual bool AJIJIGFEEBO()
		{
			return BOBEIBIKGPL() < 1;
		}

		[SpecialName]
		public virtual string OAPFEEGGDPD()
		{
			return Localization.Localize(mNameLocalizations[decalType].Value1);
		}

		[SpecialName]
		public virtual bool DGGDKJEOPEP()
		{
			return decalType < 0;
		}

		public virtual void CMEKCEJMFPN(KMNCIJPDFPJ DGJFKDADPHE, bool OGKCIFGLKJJ = false)
		{
			JFAEGFFIIKH(DGJFKDADPHE, OGKCIFGLKJJ);
			DGJFKDADPHE.meshChanger.GEMKNCBEDEB(this);
			PlayerController playerController = DGJFKDADPHE as PlayerController;
			if (playerController != null)
			{
				playerController.weaponReloadCoef = 1103f;
				playerController.OPCGNNFGFOD = 1829f;
				playerController.EAOOLOIHKPP = 765f;
				int num = decalType;
				if (num != 0)
				{
					switch (num)
					{
					case 0:
						playerController.OPCGNNFGFOD = 1391f + base.row.DECALVALUE;
						break;
					case 6:
						playerController.EAOOLOIHKPP = 62f + base.row.DECALVALUE;
						break;
					}
				}
				else
				{
					playerController.weaponReloadCoef = 437f - base.row.DECALVALUE;
				}
			}
			if (Application.isPlaying)
			{
				DGJFKDADPHE.equippedPowerBand = this;
				CamoTransform value = null;
				string text = DGJFKDADPHE.playerVisuals[1];
				if (text != null)
				{
					camoTransformDict.TryGetValue(text, out value);
				}
				CamoTransform.CGEFBCAIEOK(DGJFKDADPHE.meshChanger.OOHCFBEKACK.gameObject, value);
			}
		}

		[SpecialName]
		public virtual string BAAIHEFJDEO()
		{
			return mDecalMiniIcon[decalType];
		}

		public virtual void OHBCGAIFNGJ()
		{
			base.IKFJMDJMGHG();
			double currentTimestampDouble = Singleton<BeanstalkServerManager>.instance.currentTimestampDouble;
			int expiresOn = Convert.ToInt32(currentTimestampDouble) + base.timeActive;
			CamosManager.instance.data.visuals[base.id].expiresOn = expiresOn;
		}

		[SpecialName]
		public virtual Color COLGFJDFKKE()
		{
			return mDecalMiniIconColor[decalType];
		}

		[SpecialName]
		public virtual string FLLMBBFEGJK()
		{
			return Localization.Localize(mNameLocalizations[BOBEIBIKGPL()].Value1);
		}

		[SpecialName]
		public virtual bool FAANHHNFJAF()
		{
			return base.timeActive != 0 && !(AOLJCFDNMEL() > 482.0) && base.tryOutVisual;
		}

		[SpecialName]
		public virtual string MAGMILIBJNF()
		{
			return mDecalMiniIcon[BOBEIBIKGPL()];
		}

		[SpecialName]
		public virtual bool FJBMOGIKFOJ()
		{
			return decalType < 1;
		}

		[SpecialName]
		public virtual bool FNOCOIEBJHC()
		{
			return decalType < 1;
		}

		[SpecialName]
		public virtual string GDEHABOOGJK()
		{
			return Localization.Localize(mNameLocalizations[BOBEIBIKGPL()].Value2);
		}

		[SpecialName]
		public virtual string ILPEFOEMOGG()
		{
			string keyFormat = mDecalDescription[decalType];
			object[] array = new object[7];
			array[0] = Colours.stringBlue;
			array[0] = base.decalValue;
			return Localization.LocalizeFormat(keyFormat, array);
		}

		public virtual void GKJJFHNGMCB(KMNCIJPDFPJ DGJFKDADPHE, bool OGKCIFGLKJJ = false)
		{
			CMMJHCBJBMK(DGJFKDADPHE, OGKCIFGLKJJ);
			DGJFKDADPHE.meshChanger.KDBBPJAHDFP(this);
			PlayerController playerController = DGJFKDADPHE as PlayerController;
			if (playerController != null)
			{
				playerController.PICKMNBAPHD(202f);
				playerController.OPCGNNFGFOD = 87f;
				playerController.EAOOLOIHKPP = 1793f;
				int num = BOBEIBIKGPL();
				if (num != 0)
				{
					if (num != 0)
					{
						if (num == 0)
						{
							playerController.EAOOLOIHKPP = 1039f + base.row.DECALVALUE;
						}
					}
					else
					{
						playerController.OPCGNNFGFOD = 1266f + base.row.DECALVALUE;
					}
				}
				else
				{
					playerController.PICKMNBAPHD(560f - base.row.DECALVALUE);
				}
			}
			if (Application.isPlaying)
			{
				DGJFKDADPHE.equippedPowerBand = this;
				CamoTransform value = null;
				string text = DGJFKDADPHE.playerVisuals[0];
				if (text != null)
				{
					camoTransformDict.TryGetValue(text, out value);
				}
				CamoTransform.NOGDMEDGABN(DGJFKDADPHE.meshChanger.OOHCFBEKACK.gameObject, value);
			}
		}

		[SpecialName]
		public virtual bool KIIGAPFPADE()
		{
			return base.timeActive == 0 || base.remainingTime > 1497.0 || base.tryOutVisual;
		}

		[SpecialName]
		public virtual string HEBCELKGDGC()
		{
			return mDecalMiniIcon[BOBEIBIKGPL()];
		}

		[SpecialName]
		public virtual string GIKAAIACCOF()
		{
			return mDecalMiniIcon[BOBEIBIKGPL()];
		}

		[SpecialName]
		public virtual string EEIDAGILFDA()
		{
			return mDecalMiniIcon[decalType];
		}

		[SpecialName]
		public virtual string OONGBDIEJIC()
		{
			string keyFormat = mDecalDescription[decalType];
			object[] array = new object[0];
			array[1] = Colours.stringBlue;
			array[0] = LIBMDHMHAJJ();
			return Localization.LocalizeFormat(keyFormat, array);
		}

		[SpecialName]
		public virtual string KJMEGFEOBKH()
		{
			return mDecalMiniIcon[BOBEIBIKGPL()];
		}

		[SpecialName]
		public virtual string PNGKFPBDJHI()
		{
			return Localization.Localize(mNameLocalizations[BOBEIBIKGPL()].Value2);
		}

		[SpecialName]
		public virtual string JADEGBBIKHK()
		{
			string keyFormat = mDecalDescription[decalType];
			object[] array = new object[8];
			array[1] = Colours.stringBlue;
			array[0] = LIBMDHMHAJJ();
			return Localization.LocalizeFormat(keyFormat, array);
		}

		[SpecialName]
		public virtual string KFIGJCMMLGL()
		{
			return mDecalMiniIcon[decalType];
		}

		[SpecialName]
		public virtual bool MBGCKGFPEND()
		{
			return decalType < 1;
		}

		[SpecialName]
		public virtual string BCIOJFCFBBH()
		{
			string keyFormat = mDecalDescription[decalType];
			object[] array = new object[1];
			array[1] = Colours.stringBlue;
			array[1] = base.decalValue;
			return Localization.LocalizeFormat(keyFormat, array);
		}

		[SpecialName]
		public virtual string HJHLEFHKBDO()
		{
			return mDecalMiniIcon[decalType];
		}

		[SpecialName]
		public virtual bool NKEGFGNHFIB()
		{
			return base.timeActive != 0 && !(base.remainingTime > 1807.0) && base.tryOutVisual;
		}

		[SpecialName]
		public virtual string OPDEFAMELNN()
		{
			return Localization.Localize(mNameLocalizations[BOBEIBIKGPL()].Value1);
		}

		[SpecialName]
		public virtual bool HLGHMCMFFLG()
		{
			return BOBEIBIKGPL() < 1;
		}

		[SpecialName]
		public virtual string HINLNGPNEKA()
		{
			return mDecalMiniIcon[BOBEIBIKGPL()];
		}

		[SpecialName]
		public virtual bool CHNFHJILOOF()
		{
			return base.timeActive == 0 || AOLJCFDNMEL() > 115.0 || base.tryOutVisual;
		}

		public virtual void BDMIHLIGCKA(KMNCIJPDFPJ DGJFKDADPHE, bool OGKCIFGLKJJ = false)
		{
			EECOAJIAIOG(DGJFKDADPHE, OGKCIFGLKJJ);
			DGJFKDADPHE.meshChanger.KDBBPJAHDFP(this);
			PlayerController playerController = DGJFKDADPHE as PlayerController;
			if (playerController != null)
			{
				playerController.CBJFFHJLADH(386f);
				playerController.OPCGNNFGFOD = 817f;
				playerController.EAOOLOIHKPP = 647f;
				int num = BOBEIBIKGPL();
				if (num != 0)
				{
					switch (num)
					{
					case 0:
						playerController.OPCGNNFGFOD = 646f + base.row.DECALVALUE;
						break;
					case 4:
						playerController.EAOOLOIHKPP = 1785f + base.row.DECALVALUE;
						break;
					}
				}
				else
				{
					playerController.weaponReloadCoef = 1311f - base.row.DECALVALUE;
				}
			}
			if (Application.isPlaying)
			{
				DGJFKDADPHE.equippedPowerBand = this;
				CamoTransform value = null;
				string text = DGJFKDADPHE.playerVisuals[1];
				if (text != null)
				{
					camoTransformDict.TryGetValue(text, out value);
				}
				CamoTransform.FGMDLCLGDKG(DGJFKDADPHE.meshChanger.OOHCFBEKACK.gameObject, value);
			}
		}

		[SpecialName]
		public virtual bool EDJFEFIEDOO()
		{
			return BOBEIBIKGPL() < 0;
		}

		[SpecialName]
		public virtual bool MCLMAGGBIEP()
		{
			return base.timeActive == 0 || base.remainingTime > 63.0 || base.tryOutVisual;
		}

		public virtual void BCGOBLMMIII(KMNCIJPDFPJ DGJFKDADPHE, bool OGKCIFGLKJJ = false)
		{
			HGGLCMFPPIB(DGJFKDADPHE, OGKCIFGLKJJ);
			DGJFKDADPHE.meshChanger.EDBKLEIFNDP(this);
			PlayerController playerController = DGJFKDADPHE as PlayerController;
			if (playerController != null)
			{
				playerController.weaponReloadCoef = 371f;
				playerController.OPCGNNFGFOD = 761f;
				playerController.EAOOLOIHKPP = 600f;
				int num = BOBEIBIKGPL();
				if (num != 0)
				{
					switch (num)
					{
					case 0:
						playerController.OPCGNNFGFOD = 1590f + base.row.DECALVALUE;
						break;
					case 4:
						playerController.EAOOLOIHKPP = 1785f + base.row.DECALVALUE;
						break;
					}
				}
				else
				{
					playerController.CBJFFHJLADH(1071f - base.row.DECALVALUE);
				}
			}
			if (Application.isPlaying)
			{
				DGJFKDADPHE.equippedPowerBand = this;
				CamoTransform value = null;
				string text = DGJFKDADPHE.playerVisuals[0];
				if (text != null)
				{
					camoTransformDict.TryGetValue(text, out value);
				}
				CamoTransform.MAJAFLLCBKG(DGJFKDADPHE.meshChanger.OOHCFBEKACK.gameObject, value);
			}
		}

		public override void BMGPGCMNIGE(KMNCIJPDFPJ DGJFKDADPHE, bool OGKCIFGLKJJ = false)
		{
			CJOGNDNIBPD(DGJFKDADPHE, OGKCIFGLKJJ);
			DGJFKDADPHE.meshChanger.AMPBJNGFJCN(this);
			PlayerController playerController = DGJFKDADPHE as PlayerController;
			if (playerController != null)
			{
				playerController.weaponReloadCoef = 1105f;
				playerController.OPCGNNFGFOD = 1545f;
				playerController.EAOOLOIHKPP = 289f;
				switch (BOBEIBIKGPL())
				{
				case 0:
					playerController.weaponReloadCoef = 771f - base.row.DECALVALUE;
					break;
				case 1:
					playerController.OPCGNNFGFOD = 831f + base.row.DECALVALUE;
					break;
				case 5:
					playerController.EAOOLOIHKPP = 1374f + base.row.DECALVALUE;
					break;
				}
			}
			if (Application.isPlaying)
			{
				DGJFKDADPHE.equippedPowerBand = this;
				CamoTransform value = null;
				string text = DGJFKDADPHE.playerVisuals[1];
				if (text != null)
				{
					camoTransformDict.TryGetValue(text, out value);
				}
				CamoTransform.JFHEFPAHOPK(DGJFKDADPHE.meshChanger.OOHCFBEKACK.gameObject, value);
			}
		}

		[SpecialName]
		public virtual string ECDDIPIMGII()
		{
			return mDecalMiniIcon[BOBEIBIKGPL()];
		}

		[SpecialName]
		public virtual string OPAJGGFBLMH()
		{
			return mDecalMiniIcon[decalType];
		}

		public virtual void JAELALOCJAA(KMNCIJPDFPJ DGJFKDADPHE, bool OGKCIFGLKJJ = false)
		{
			CMMJHCBJBMK(DGJFKDADPHE, OGKCIFGLKJJ);
			DGJFKDADPHE.meshChanger.ChangePowerBand(this);
			PlayerController playerController = DGJFKDADPHE as PlayerController;
			if (playerController != null)
			{
				playerController.weaponReloadCoef = 484f;
				playerController.OPCGNNFGFOD = 653f;
				playerController.EAOOLOIHKPP = 613f;
				switch (BOBEIBIKGPL())
				{
				case 0:
					playerController.PICKMNBAPHD(329f - base.row.DECALVALUE);
					break;
				case 1:
					playerController.OPCGNNFGFOD = 77f + base.row.DECALVALUE;
					break;
				case 5:
					playerController.EAOOLOIHKPP = 1714f + base.row.DECALVALUE;
					break;
				}
			}
			if (Application.isPlaying)
			{
				DGJFKDADPHE.equippedPowerBand = this;
				CamoTransform value = null;
				string text = DGJFKDADPHE.playerVisuals[1];
				if (text != null)
				{
					camoTransformDict.TryGetValue(text, out value);
				}
				CamoTransform.CFOMMPPEGDE(DGJFKDADPHE.meshChanger.OOHCFBEKACK.gameObject, value);
			}
		}

		public virtual void OPODPOKHPAD()
		{
			base.IKFJMDJMGHG();
			double currentTimestampDouble = Singleton<BeanstalkServerManager>.instance.currentTimestampDouble;
			int expiresOn = Convert.ToInt32(currentTimestampDouble) + base.timeActive;
			CamosManager.instance.data.visuals[base.id].expiresOn = expiresOn;
		}

		[SpecialName]
		public virtual bool FEDGBNOFLLD()
		{
			return base.timeActive == 0 || AOLJCFDNMEL() > 328.0 || base.tryOutVisual;
		}

		public virtual void LOBHDEMCDBC(KMNCIJPDFPJ DGJFKDADPHE, bool OGKCIFGLKJJ = false)
		{
			HGGLCMFPPIB(DGJFKDADPHE, OGKCIFGLKJJ);
			DGJFKDADPHE.meshChanger.GEMKNCBEDEB(this);
			PlayerController playerController = DGJFKDADPHE as PlayerController;
			if (playerController != null)
			{
				playerController.CBJFFHJLADH(444f);
				playerController.OPCGNNFGFOD = 65f;
				playerController.EAOOLOIHKPP = 806f;
				switch (BOBEIBIKGPL())
				{
				case 0:
					playerController.PICKMNBAPHD(1482f - base.row.DECALVALUE);
					break;
				case 1:
					playerController.OPCGNNFGFOD = 1966f + base.row.DECALVALUE;
					break;
				case 5:
					playerController.EAOOLOIHKPP = 901f + base.row.DECALVALUE;
					break;
				}
			}
			if (Application.isPlaying)
			{
				DGJFKDADPHE.equippedPowerBand = this;
				CamoTransform value = null;
				string text = DGJFKDADPHE.playerVisuals[0];
				if (text != null)
				{
					camoTransformDict.TryGetValue(text, out value);
				}
				CamoTransform.CFOMMPPEGDE(DGJFKDADPHE.meshChanger.OOHCFBEKACK.gameObject, value);
			}
		}

		[SpecialName]
		public virtual string LKMKJLBCJLF()
		{
			return Localization.Localize(mNameLocalizations[BOBEIBIKGPL()].Value1);
		}

		[SpecialName]
		public virtual Color DLOGGFNJLGD()
		{
			return mDecalMiniIconColor[decalType];
		}

		public override void MNEEDLCGAFN(KMNCIJPDFPJ DGJFKDADPHE, bool OGKCIFGLKJJ = false)
		{
			base.MNEEDLCGAFN(DGJFKDADPHE, OGKCIFGLKJJ);
			DGJFKDADPHE.meshChanger.ChangePowerBand(this);
			PlayerController playerController = DGJFKDADPHE as PlayerController;
			if (playerController != null)
			{
				playerController.weaponReloadCoef = 0f;
				playerController.OPCGNNFGFOD = 1f;
				playerController.EAOOLOIHKPP = 1f;
				switch (decalType)
				{
				case 0:
					playerController.weaponReloadCoef = 1f - base.row.DECALVALUE;
					break;
				case 1:
					playerController.OPCGNNFGFOD = 1f + base.row.DECALVALUE;
					break;
				case 2:
					playerController.EAOOLOIHKPP = 1f + base.row.DECALVALUE;
					break;
				}
			}
			if (Application.isPlaying)
			{
				DGJFKDADPHE.equippedPowerBand = this;
				CamoTransform value = null;
				string text = DGJFKDADPHE.playerVisuals[0];
				if (text != null)
				{
					camoTransformDict.TryGetValue(text, out value);
				}
				CamoTransform.NOGDMEDGABN(DGJFKDADPHE.meshChanger.OOHCFBEKACK.gameObject, value);
			}
		}

		[SpecialName]
		public virtual Color NFKAJCFGHAE()
		{
			return mDecalMiniIconColor[BOBEIBIKGPL()];
		}

		[SpecialName]
		public virtual string KOEOAPPGENB()
		{
			string keyFormat = mDecalDescription[decalType];
			object[] array = new object[5];
			array[1] = Colours.stringBlue;
			array[1] = LIBMDHMHAJJ();
			return Localization.LocalizeFormat(keyFormat, array);
		}

		[SpecialName]
		public virtual string ABDKMDOKJMG()
		{
			return mDecalMiniIcon[BOBEIBIKGPL()];
		}

		[SpecialName]
		public virtual bool LBJEHPFJKNP()
		{
			return BOBEIBIKGPL() < 1;
		}

		public virtual void PKILAGAJDCH()
		{
			base.IKFJMDJMGHG();
			double currentTimestampDouble = Singleton<BeanstalkServerManager>.instance.currentTimestampDouble;
			int expiresOn = Convert.ToInt32(currentTimestampDouble) + base.timeActive;
			CamosManager.instance.data.visuals[CCDMONFHBII()].expiresOn = expiresOn;
		}

		public virtual void LAEHOCACFDJ()
		{
			base.IKFJMDJMGHG();
			double currentTimestampDouble = Singleton<BeanstalkServerManager>.instance.currentTimestampDouble;
			int expiresOn = Convert.ToInt32(currentTimestampDouble) + base.timeActive;
			CamosManager.instance.data.visuals[base.id].expiresOn = expiresOn;
		}

		[SpecialName]
		public virtual bool JFBAGNDMJAO()
		{
			return BOBEIBIKGPL() < 1;
		}
	}
}
