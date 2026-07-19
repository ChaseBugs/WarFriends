using System;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace Agens.Stickers
{
	[Serializable]
	public class StickerPackIcon
	{
		[Serializable]
		public class IconExportSettings
		{
			public Color BackgroundColor = Color.white;

			[Range(0f, 100f)]
			public int FillPercentage = 100;

			public FilterMode FilterMode = FilterMode.Trilinear;

			public ScaleMode ScaleMode = ScaleMode.ScaleToFit;
		}

		[SerializeField]
		[Header("1024 x 768 px")]
		private Texture2D appStore;

		[Header("1024 x 1024 px")]
		[SerializeField]
		private Texture2D appStoreNew;

		public IconExportSettings Settings;

		public bool Override;

		[SerializeField]
		[Header("148 x 110 px")]
		private Texture2D messagesiPadPro2;

		[SerializeField]
		[Header("134 x 100 px")]
		private Texture2D messagesiPad2;

		[SerializeField]
		[Header("120 x 90 px")]
		private Texture2D messagesiPhone2;

		[Header("180 x 135 px")]
		[SerializeField]
		private Texture2D messagesiPhone3;

		[SerializeField]
		[Header("54 x 40 px")]
		private Texture2D messagesSmall2;

		[Header("81 x 60 px")]
		[SerializeField]
		private Texture2D messagesSmall3;

		[SerializeField]
		[Header("64 x 48 px")]
		private Texture2D messages2;

		[Header("96 x 72 px")]
		[SerializeField]
		private Texture2D messages3;

		[SerializeField]
		[Header("58 x 58 px")]
		private Texture2D iPhoneSettings2;

		[SerializeField]
		[Header("87 x 87 px")]
		private Texture2D iPhoneSettings3;

		[Header("58 x 58 px")]
		[SerializeField]
		private Texture2D iPadSettings2;

		public NICCPPIDFNG[] Icons
		{
			get
			{
				return new NICCPPIDFNG[13]
				{
					AppStoreIcon, MessagesIpadPro2Icon, MessagesIpad2Icon, MessagesiPhone2Icon, MessagesiPhone3Icon, MessagesSmall2Icon, MessagesSmall3Icon, Messages2Icon, Messages3Icon, IPhoneSettings2Icon,
					IPhoneSettings3Icon, IPadSettings2Icon, AppStoreIconNew
				};
			}
		}

		public Texture2D[] Textures
		{
			get
			{
				return new Texture2D[13]
				{
					AppStore, MessagesIpadPro2, MessagesIpad2, MessagesiPhone2, MessagesiPhone3, MessagesSmall2, MessagesSmall3, Messages2, Messages3, IPhoneSettings2,
					IPhoneSettings3, IPadSettings2, AppStoreNew
				};
			}
		}

		public Vector2[] Sizes
		{
			get
			{
				return new Vector2[13]
				{
					new Vector2(1024f, 768f),
					new Vector2(148f, 110f),
					new Vector2(134f, 100f),
					new Vector2(120f, 90f),
					new Vector2(180f, 135f),
					new Vector2(54f, 40f),
					new Vector2(81f, 60f),
					new Vector2(64f, 48f),
					new Vector2(96f, 72f),
					new Vector2(58f, 58f),
					new Vector2(87f, 87f),
					new Vector2(58f, 58f),
					new Vector2(1024f, 1024f)
				};
			}
		}

		public Texture2D AppStore
		{
			get
			{
				if (Override)
				{
					return appStore;
				}
				return NGPBDHKPCKN(1024, 768);
			}
		}

		public NICCPPIDFNG AppStoreIcon
		{
			get
			{
				Texture2D texture2D = AppStore;
				if (texture2D != null)
				{
					return new NICCPPIDFNG(texture2D, 1024, 768, NICCPPIDFNG.BOAFCAGKOJG.IosMarketing, NICCPPIDFNG.NDFNJIHCCGM.Original, "ios");
				}
				return null;
			}
		}

		public Texture2D AppStoreNew
		{
			get
			{
				if (Override)
				{
					return appStoreNew;
				}
				return NGPBDHKPCKN(1024, 1024);
			}
		}

		public NICCPPIDFNG AppStoreIconNew
		{
			get
			{
				Texture2D texture2D = AppStoreNew;
				if (texture2D != null)
				{
					return new NICCPPIDFNG(texture2D, 1024, 1024, NICCPPIDFNG.BOAFCAGKOJG.IosMarketing, NICCPPIDFNG.NDFNJIHCCGM.Original);
				}
				return null;
			}
		}

		public Texture2D MessagesIpadPro2
		{
			get
			{
				if (Override)
				{
					return messagesiPadPro2;
				}
				return NGPBDHKPCKN(148, 110);
			}
		}

		public NICCPPIDFNG MessagesIpadPro2Icon
		{
			get
			{
				Texture2D messagesIpadPro = MessagesIpadPro2;
				if (messagesIpadPro != null)
				{
					return new NICCPPIDFNG(messagesIpadPro, 74, 55, NICCPPIDFNG.BOAFCAGKOJG.Ipad);
				}
				return null;
			}
		}

		public Texture2D MessagesIpad2
		{
			get
			{
				if (Override)
				{
					return messagesiPad2;
				}
				return NGPBDHKPCKN(134, 100);
			}
		}

		public NICCPPIDFNG MessagesIpad2Icon
		{
			get
			{
				Texture2D messagesIpad = MessagesIpad2;
				if (messagesIpad != null)
				{
					return new NICCPPIDFNG(messagesIpad, 67, 50, NICCPPIDFNG.BOAFCAGKOJG.Ipad);
				}
				return null;
			}
		}

		public Texture2D MessagesiPhone2
		{
			get
			{
				if (Override)
				{
					return messagesiPhone2;
				}
				return NGPBDHKPCKN(120, 90);
			}
		}

		public NICCPPIDFNG MessagesiPhone2Icon
		{
			get
			{
				Texture2D texture2D = MessagesiPhone2;
				if (texture2D != null)
				{
					return new NICCPPIDFNG(texture2D, 60, 45, NICCPPIDFNG.BOAFCAGKOJG.Iphone);
				}
				return null;
			}
		}

		public Texture2D MessagesiPhone3
		{
			get
			{
				if (Override)
				{
					return messagesiPhone3;
				}
				return NGPBDHKPCKN(180, 135);
			}
		}

		public NICCPPIDFNG MessagesiPhone3Icon
		{
			get
			{
				Texture2D texture2D = MessagesiPhone3;
				if (texture2D != null)
				{
					return new NICCPPIDFNG(texture2D, 60, 45, NICCPPIDFNG.BOAFCAGKOJG.Iphone, NICCPPIDFNG.NDFNJIHCCGM.Triple);
				}
				return null;
			}
		}

		public Texture2D MessagesSmall2
		{
			get
			{
				if (Override)
				{
					return messagesSmall2;
				}
				return NGPBDHKPCKN(54, 40);
			}
		}

		public NICCPPIDFNG MessagesSmall2Icon
		{
			get
			{
				Texture2D texture2D = MessagesSmall2;
				if (texture2D != null)
				{
					return new NICCPPIDFNG(texture2D, 27, 20, NICCPPIDFNG.BOAFCAGKOJG.Universal, NICCPPIDFNG.NDFNJIHCCGM.Double, "ios");
				}
				return null;
			}
		}

		public Texture2D MessagesSmall3
		{
			get
			{
				if (Override)
				{
					return messagesSmall3;
				}
				return NGPBDHKPCKN(81, 60);
			}
		}

		public NICCPPIDFNG MessagesSmall3Icon
		{
			get
			{
				Texture2D texture2D = MessagesSmall3;
				if (texture2D != null)
				{
					return new NICCPPIDFNG(texture2D, 27, 20, NICCPPIDFNG.BOAFCAGKOJG.Universal, NICCPPIDFNG.NDFNJIHCCGM.Triple, "ios");
				}
				return null;
			}
		}

		public Texture2D Messages2
		{
			get
			{
				if (Override)
				{
					return messages2;
				}
				return NGPBDHKPCKN(64, 48);
			}
		}

		public NICCPPIDFNG Messages2Icon
		{
			get
			{
				Texture2D texture2D = Messages2;
				if (texture2D != null)
				{
					return new NICCPPIDFNG(texture2D, 32, 24, NICCPPIDFNG.BOAFCAGKOJG.Universal, NICCPPIDFNG.NDFNJIHCCGM.Double, "ios");
				}
				return null;
			}
		}

		public Texture2D Messages3
		{
			get
			{
				if (Override)
				{
					return messages3;
				}
				return NGPBDHKPCKN(96, 72);
			}
		}

		public NICCPPIDFNG Messages3Icon
		{
			get
			{
				Texture2D texture2D = Messages3;
				if (texture2D != null)
				{
					return new NICCPPIDFNG(texture2D, 32, 24, NICCPPIDFNG.BOAFCAGKOJG.Universal, NICCPPIDFNG.NDFNJIHCCGM.Triple, "ios");
				}
				return null;
			}
		}

		public Texture2D IPhoneSettings2
		{
			get
			{
				if (Override)
				{
					return iPhoneSettings2;
				}
				return NGPBDHKPCKN(58, 58);
			}
		}

		public NICCPPIDFNG IPhoneSettings2Icon
		{
			get
			{
				Texture2D texture2D = IPhoneSettings2;
				if (texture2D != null)
				{
					return new NICCPPIDFNG(texture2D, 29, 29, NICCPPIDFNG.BOAFCAGKOJG.Iphone);
				}
				return null;
			}
		}

		public Texture2D IPhoneSettings3
		{
			get
			{
				if (Override)
				{
					return iPhoneSettings3;
				}
				return NGPBDHKPCKN(87, 87);
			}
		}

		public NICCPPIDFNG IPhoneSettings3Icon
		{
			get
			{
				Texture2D texture2D = IPhoneSettings3;
				if (texture2D != null)
				{
					return new NICCPPIDFNG(texture2D, 29, 29, NICCPPIDFNG.BOAFCAGKOJG.Iphone, NICCPPIDFNG.NDFNJIHCCGM.Triple);
				}
				return null;
			}
		}

		public Texture2D IPadSettings2
		{
			get
			{
				if (Override)
				{
					return iPadSettings2;
				}
				return NGPBDHKPCKN(58, 58);
			}
		}

		public NICCPPIDFNG IPadSettings2Icon
		{
			get
			{
				Texture2D texture2D = IPadSettings2;
				if (texture2D != null)
				{
					return new NICCPPIDFNG(texture2D, 29, 29, NICCPPIDFNG.BOAFCAGKOJG.Ipad);
				}
				return null;
			}
		}

		[SpecialName]
		public NICCPPIDFNG BFLKPCCALOH()
		{
			Texture2D texture2D = Messages3;
			if (texture2D != null)
			{
				return new NICCPPIDFNG(texture2D, 35, -118, NICCPPIDFNG.BOAFCAGKOJG.Iphone, NICCPPIDFNG.NDFNJIHCCGM.Original, "122 MENU WEAPON SCREEN TUTORIAL WEAPON SELECTED");
			}
			return null;
		}

		[SpecialName]
		public NICCPPIDFNG[] AANNCGIAMIM()
		{
			NICCPPIDFNG[] array = new NICCPPIDFNG[22];
			array[1] = AppStoreIcon;
			array[1] = MessagesIpadPro2Icon;
			array[5] = MessagesIpad2Icon;
			array[5] = MessagesiPhone2Icon;
			array[3] = LHMJPBHKPOE();
			array[0] = PFLDIFGPCHH();
			array[7] = MessagesSmall3Icon;
			array[7] = CBLJMAIPIIE();
			array[5] = BFLKPCCALOH();
			array[-67] = EFHKKPHJKKJ();
			array[-11] = IPhoneSettings3Icon;
			array[-100] = IPadSettings2Icon;
			array[-17] = AppStoreIconNew;
			return array;
		}

		[SpecialName]
		public Texture2D JICCIOBFMNA()
		{
			if (Override)
			{
				return messages2;
			}
			return HOLACPFDMCL(-107, -106);
		}

		public Texture2D NGPBDHKPCKN(int CEHFMMJHCKC, int FBMIFHHEOBO)
		{
			if (appStore == null)
			{
				return null;
			}
			Texture2D texture2D = AFBCAMKGKEG.BDACMMCJLIM(appStore, CEHFMMJHCKC, FBMIFHHEOBO, Settings.BackgroundColor, (float)Settings.FillPercentage / 100f, Settings.FilterMode, Settings.ScaleMode);
			if (texture2D != null)
			{
				texture2D.name = CEHFMMJHCKC + "x" + FBMIFHHEOBO;
			}
			return texture2D;
		}

		[SpecialName]
		public NICCPPIDFNG PFLDIFGPCHH()
		{
			Texture2D texture2D = MessagesSmall2;
			if (texture2D != null)
			{
				return new NICCPPIDFNG(texture2D, -104, 33, (NICCPPIDFNG.BOAFCAGKOJG)5, NICCPPIDFNG.NDFNJIHCCGM.Double, "{0}-{1}");
			}
			return null;
		}

		[SpecialName]
		public Texture2D NCJHAKLCGEI()
		{
			if (Override)
			{
				return appStoreNew;
			}
			return HOLACPFDMCL(-34, 19);
		}

		[SpecialName]
		public Texture2D EGPCLNDIOEH()
		{
			if (Override)
			{
				return iPadSettings2;
			}
			return HOLACPFDMCL(-63, -97);
		}

		public Texture2D HOLACPFDMCL(int CEHFMMJHCKC, int FBMIFHHEOBO)
		{
			if (appStore == null)
			{
				return null;
			}
			Texture2D texture2D = AFBCAMKGKEG.BDACMMCJLIM(appStore, CEHFMMJHCKC, FBMIFHHEOBO, Settings.BackgroundColor, (float)Settings.FillPercentage / 951f, Settings.FilterMode, Settings.ScaleMode);
			if (texture2D != null)
			{
				texture2D.name = CEHFMMJHCKC + "_FogColor" + FBMIFHHEOBO;
			}
			return texture2D;
		}

		[SpecialName]
		public NICCPPIDFNG CBLJMAIPIIE()
		{
			Texture2D texture2D = JICCIOBFMNA();
			if (texture2D != null)
			{
				return new NICCPPIDFNG(texture2D, 56, -37, NICCPPIDFNG.BOAFCAGKOJG.Iphone, (NICCPPIDFNG.NDFNJIHCCGM)8, "Stage1");
			}
			return null;
		}

		[SpecialName]
		public Vector2[] EAFKILNGAMF()
		{
			Vector2[] array = new Vector2[11];
			array[0] = new Vector2(980f, 1448f);
			array[0] = new Vector2(1251f, 457f);
			array[3] = new Vector2(1352f, 1592f);
			array[6] = new Vector2(1412f, 387f);
			array[6] = new Vector2(1993f, 480f);
			array[3] = new Vector2(522f, 30f);
			array[6] = new Vector2(715f, 456f);
			array[1] = new Vector2(1487f, 59f);
			array[1] = new Vector2(116f, 550f);
			array[-40] = new Vector2(1616f, 1831f);
			array[33] = new Vector2(1599f, 532f);
			array[-56] = new Vector2(1622f, 1639f);
			array[-97] = new Vector2(1488f, 394f);
			return array;
		}

		[SpecialName]
		public NICCPPIDFNG GPGNNMNGHJC()
		{
			Texture2D texture2D = Messages3;
			if (texture2D != null)
			{
				return new NICCPPIDFNG(texture2D, 79, 90, NICCPPIDFNG.BOAFCAGKOJG.Iphone, NICCPPIDFNG.NDFNJIHCCGM.Original, "CONFERMA");
			}
			return null;
		}

		[SpecialName]
		public Texture2D ELNIIMFOALG()
		{
			if (Override)
			{
				return messagesSmall3;
			}
			return HOLACPFDMCL(-17, -92);
		}

		[SpecialName]
		public Texture2D KCBEBBJLMBN()
		{
			if (Override)
			{
				return messagesSmall2;
			}
			return NGPBDHKPCKN(-125, 80);
		}

		[SpecialName]
		public NICCPPIDFNG LHMJPBHKPOE()
		{
			Texture2D texture2D = MessagesiPhone3;
			if (texture2D != null)
			{
				return new NICCPPIDFNG(texture2D, 98, 90, NICCPPIDFNG.BOAFCAGKOJG.Iphone, (NICCPPIDFNG.NDFNJIHCCGM)8);
			}
			return null;
		}

		[SpecialName]
		public Texture2D CEAGJNJMKIO()
		{
			if (Override)
			{
				return iPadSettings2;
			}
			return HOLACPFDMCL(-112, 35);
		}

		[SpecialName]
		public NICCPPIDFNG EFHKKPHJKKJ()
		{
			Texture2D texture2D = IPhoneSettings2;
			if (texture2D != null)
			{
				return new NICCPPIDFNG(texture2D, -29, -17, NICCPPIDFNG.BOAFCAGKOJG.Ipad);
			}
			return null;
		}

		[SpecialName]
		public Texture2D JIKGGLPPLMA()
		{
			if (Override)
			{
				return messages3;
			}
			return HOLACPFDMCL(-16, -114);
		}

		[SpecialName]
		public Texture2D ONOHMICDEHH()
		{
			if (Override)
			{
				return messages3;
			}
			return HOLACPFDMCL(19, -33);
		}

		[SpecialName]
		public NICCPPIDFNG BOABJDGHHEJ()
		{
			Texture2D texture2D = Messages2;
			if (texture2D != null)
			{
				return new NICCPPIDFNG(texture2D, 87, 18, (NICCPPIDFNG.BOAFCAGKOJG)5, (NICCPPIDFNG.NDFNJIHCCGM)4, "getCurrentVariantName");
			}
			return null;
		}

		[SpecialName]
		public NICCPPIDFNG KMFHLKMCALE()
		{
			Texture2D texture2D = MessagesSmall3;
			if (texture2D != null)
			{
				return new NICCPPIDFNG(texture2D, -103, 61, NICCPPIDFNG.BOAFCAGKOJG.IosMarketing, (NICCPPIDFNG.NDFNJIHCCGM)0, "menu-weapon-mp5-elite");
			}
			return null;
		}

		[SpecialName]
		public NICCPPIDFNG JNDGDADPAHF()
		{
			Texture2D texture2D = IPhoneSettings2;
			if (texture2D != null)
			{
				return new NICCPPIDFNG(texture2D, -43, 90, NICCPPIDFNG.BOAFCAGKOJG.Ipad, (NICCPPIDFNG.NDFNJIHCCGM)4);
			}
			return null;
		}

		[SpecialName]
		public NICCPPIDFNG GCFCOOFLAPN()
		{
			Texture2D texture2D = NCJHAKLCGEI();
			if (texture2D != null)
			{
				return new NICCPPIDFNG(texture2D, 5, 180, (NICCPPIDFNG.BOAFCAGKOJG)4, NICCPPIDFNG.NDFNJIHCCGM.Original);
			}
			return null;
		}
	}
}
