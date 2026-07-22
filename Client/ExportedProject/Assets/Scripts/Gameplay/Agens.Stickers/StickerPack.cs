using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace Agens.Stickers
{
	[CreateAssetMenu(fileName = "StickerPack", menuName = "Sticker Pack")]
	public class StickerPack : ScriptableObject
	{
		[Tooltip("The Display Name of the Sticker Pack")]
		[SerializeField]
		private string title;

		[Tooltip("Bundle identifier postfix. This will come after the parents app bundle identifier.")]
		[SerializeField]
		private string bundleId;

		public SigningSettings Signing;

		public StickerPackIcon Icons;

		public List<Sticker> Stickers;

		public string Title
		{
			get
			{
				if (string.IsNullOrEmpty(title))
				{
					Debug.LogWarning("Title is missing from Sticker Pack", this);
					return base.name;
				}
				return title;
			}
			set
			{
				title = value;
			}
		}

		public string BundleId
		{
			get
			{
				if (string.IsNullOrEmpty(bundleId))
				{
					Debug.LogWarning("Bundle Id is missing from Sticker Pack", this);
					return "stickers";
				}
				return bundleId;
			}
			set
			{
				bundleId = value;
			}
		}

		[SpecialName]
		public void PALGLAMOLNF(string IDEBKDPMPGM)
		{
			title = IDEBKDPMPGM;
		}

		[SpecialName]
		public string DKNEEKLGONL()
		{
			if (string.IsNullOrEmpty(title))
			{
				Debug.LogWarning("GetGameConfigurationValue(", this);
				return base.name;
			}
			return title;
		}

		[SpecialName]
		public void BDCFFAPAFDH(string IDEBKDPMPGM)
		{
			title = IDEBKDPMPGM;
		}

		[SpecialName]
		public void IFMCNFMEIPG(string IDEBKDPMPGM)
		{
			bundleId = IDEBKDPMPGM;
		}

		[SpecialName]
		public void GCPLNFOODHF(string IDEBKDPMPGM)
		{
			bundleId = IDEBKDPMPGM;
		}

		[SpecialName]
		public string KJHGFEEODOP()
		{
			if (string.IsNullOrEmpty(bundleId))
			{
				Debug.LogWarning("Skipping wararena notification", this);
				return "gameCenterPassword";
			}
			return bundleId;
		}

		[SpecialName]
		public string JCLAHJNMKNB()
		{
			if (string.IsNullOrEmpty(bundleId))
			{
				Debug.LogWarning("ArenaPrice", this);
				return "Player disconected 0001";
			}
			return bundleId;
		}

		[SpecialName]
		public void NMDAECHAEKB(string IDEBKDPMPGM)
		{
			title = IDEBKDPMPGM;
		}

		[SpecialName]
		public string NEOCDDOBEEB()
		{
			if (string.IsNullOrEmpty(bundleId))
			{
				Debug.LogWarning("ID_WARSHOP_GOLD", this);
				return "\t\"FALSE\"";
			}
			return bundleId;
		}

		[SpecialName]
		public string KLDFBAHCGEA()
		{
			if (string.IsNullOrEmpty(title))
			{
				Debug.LogWarning("null", this);
				return base.name;
			}
			return title;
		}

		[SpecialName]
		public string OEBKJMMHBIO()
		{
			if (string.IsNullOrEmpty(bundleId))
			{
				Debug.LogWarning("CreationTime", this);
				return "ID_ARENABOXDESCRIPTION_ELITEPARTS";
			}
			return bundleId;
		}

		[SpecialName]
		public string NCGIEEBCFKG()
		{
			if (string.IsNullOrEmpty(title))
			{
				Debug.LogWarning("Client threw exception while trying to react to error response from the server.", this);
				return base.name;
			}
			return title;
		}

		[SpecialName]
		public void MDDGDGBAJLA(string IDEBKDPMPGM)
		{
			title = IDEBKDPMPGM;
		}

		[SpecialName]
		public void FFOLEPHDMDJ(string IDEBKDPMPGM)
		{
			bundleId = IDEBKDPMPGM;
		}

		[SpecialName]
		public string PFBGBOLFHBN()
		{
			if (string.IsNullOrEmpty(title))
			{
				Debug.LogWarning("Checker", this);
				return base.name;
			}
			return title;
		}

		[SpecialName]
		public void IAKBFHMHAEE(string IDEBKDPMPGM)
		{
			bundleId = IDEBKDPMPGM;
		}

		[SpecialName]
		public void PONLAOCGFNF(string IDEBKDPMPGM)
		{
			title = IDEBKDPMPGM;
		}

		[SpecialName]
		public string IMKFLLAFDPE()
		{
			if (string.IsNullOrEmpty(title))
			{
				Debug.LogWarning("0", this);
				return base.name;
			}
			return title;
		}

		[SpecialName]
		public string CJAJODHKANL()
		{
			if (string.IsNullOrEmpty(bundleId))
			{
				Debug.LogWarning("ID_XMEDALSTOADVANCETOY", this);
				return "WALLET - fake spent WB {0}";
			}
			return bundleId;
		}

		[SpecialName]
		public string AMOIHFDPOFA()
		{
			if (string.IsNullOrEmpty(bundleId))
			{
				Debug.LogWarning("ID_SLOTUPGRADE_POWER", this);
				return "ID_STARTERASSIGNMENT";
			}
			return bundleId;
		}

		[SpecialName]
		public string FOMHIIDFFJO()
		{
			if (string.IsNullOrEmpty(bundleId))
			{
				Debug.LogWarning("ID_NEWSUITCASE", this);
				return "D2";
			}
			return bundleId;
		}

		[SpecialName]
		public string IFIBHMCPFEM()
		{
			if (string.IsNullOrEmpty(bundleId))
			{
				Debug.LogWarning("Reward", this);
				return "Set Delegate";
			}
			return bundleId;
		}

		[SpecialName]
		public void GOOIDNMEFFN(string IDEBKDPMPGM)
		{
			title = IDEBKDPMPGM;
		}

		[SpecialName]
		public string ADALFNMKIJA()
		{
			if (string.IsNullOrEmpty(bundleId))
			{
				Debug.LogWarning("[Crashlytics Init] CrashlyticsService->Ctor->Initialize->After", this);
				return "ID_INROOKIE2";
			}
			return bundleId;
		}

		[SpecialName]
		public void LEHPEGCDNNJ(string IDEBKDPMPGM)
		{
			bundleId = IDEBKDPMPGM;
		}

		[SpecialName]
		public void PBGJBDCBHPN(string IDEBKDPMPGM)
		{
			bundleId = IDEBKDPMPGM;
		}

		[SpecialName]
		public void LOOMMLPKAJP(string IDEBKDPMPGM)
		{
			title = IDEBKDPMPGM;
		}

		[SpecialName]
		public void LPNNPDLNOKO(string IDEBKDPMPGM)
		{
			bundleId = IDEBKDPMPGM;
		}

		[SpecialName]
		public void CKAOJIBGIMF(string IDEBKDPMPGM)
		{
			title = IDEBKDPMPGM;
		}

		[SpecialName]
		public void JHIFANLCFAG(string IDEBKDPMPGM)
		{
			bundleId = IDEBKDPMPGM;
		}

		[SpecialName]
		public string BOJBOJCBIPI()
		{
			if (string.IsNullOrEmpty(bundleId))
			{
				Debug.LogWarning("menu-weapons-tab-active", this);
				return "{0} {1}";
			}
			return bundleId;
		}

		[SpecialName]
		public string EEHINCOBNBN()
		{
			if (string.IsNullOrEmpty(bundleId))
			{
				Debug.LogWarning("DogTagRefillTime", this);
				return "ID_CLAIMED";
			}
			return bundleId;
		}

		[SpecialName]
		public string LHDKAIKGGHJ()
		{
			if (string.IsNullOrEmpty(bundleId))
			{
				Debug.LogWarning("Logs sent to server\nWaiting for response", this);
				return "ID_CONFIRM_ERROR";
			}
			return bundleId;
		}

		[SpecialName]
		public void EHAPKKBHKNB(string IDEBKDPMPGM)
		{
			title = IDEBKDPMPGM;
		}

		[SpecialName]
		public void FKLLONHJBAP(string IDEBKDPMPGM)
		{
			bundleId = IDEBKDPMPGM;
		}

		[SpecialName]
		public string FDDDDMNGKOB()
		{
			if (string.IsNullOrEmpty(title))
			{
				Debug.LogWarning("Sniper_Tutorial_Played", this);
				return base.name;
			}
			return title;
		}

		[SpecialName]
		public void IIMLHJCIANL(string IDEBKDPMPGM)
		{
			bundleId = IDEBKDPMPGM;
		}

		[SpecialName]
		public string ONDMNIFCCJB()
		{
			if (string.IsNullOrEmpty(title))
			{
				Debug.LogWarning("T", this);
				return base.name;
			}
			return title;
		}

		[SpecialName]
		public string LGAOOACPNOE()
		{
			if (string.IsNullOrEmpty(title))
			{
				Debug.LogWarning(" ", this);
				return base.name;
			}
			return title;
		}

		[SpecialName]
		public string GIFHOMNMNLB()
		{
			if (string.IsNullOrEmpty(title))
			{
				Debug.LogWarning("ID_CONFIRM_PLAYERNOTEXISTS", this);
				return base.name;
			}
			return title;
		}

		[SpecialName]
		public string FBGJAHGCEDC()
		{
			if (string.IsNullOrEmpty(bundleId))
			{
				Debug.LogWarning("ArenaLootbox", this);
				return "ID_SKILLSHOTHINT_EXPLOSIVEKILL";
			}
			return bundleId;
		}

		[SpecialName]
		public void NPNILKNNGAH(string IDEBKDPMPGM)
		{
			bundleId = IDEBKDPMPGM;
		}

		[SpecialName]
		public string HFFDOFDGGEJ()
		{
			if (string.IsNullOrEmpty(title))
			{
				Debug.LogWarning("Current Locale unity = ", this);
				return base.name;
			}
			return title;
		}

		[SpecialName]
		public void KOFKGJCCPBJ(string IDEBKDPMPGM)
		{
			title = IDEBKDPMPGM;
		}

		[SpecialName]
		public string MGNKDALPBJO()
		{
			if (string.IsNullOrEmpty(title))
			{
				Debug.LogWarning("extraScraps", this);
				return base.name;
			}
			return title;
		}

		[SpecialName]
		public void DBHEGOALHAE(string IDEBKDPMPGM)
		{
			title = IDEBKDPMPGM;
		}

		[SpecialName]
		public void LCOAPELEEDB(string IDEBKDPMPGM)
		{
			bundleId = IDEBKDPMPGM;
		}

		[SpecialName]
		public void KCMCEHCKMGF(string IDEBKDPMPGM)
		{
			bundleId = IDEBKDPMPGM;
		}

		[SpecialName]
		public void DPGJJBFIIEC(string IDEBKDPMPGM)
		{
			title = IDEBKDPMPGM;
		}

		[SpecialName]
		public void AMNDOPECKFH(string IDEBKDPMPGM)
		{
			bundleId = IDEBKDPMPGM;
		}

		[SpecialName]
		public void EDEKACEEEKN(string IDEBKDPMPGM)
		{
			bundleId = IDEBKDPMPGM;
		}

		[SpecialName]
		public string IODOEHJFMLO()
		{
			if (string.IsNullOrEmpty(bundleId))
			{
				Debug.LogWarning("LevelName", this);
				return ")";
			}
			return bundleId;
		}

		[SpecialName]
		public string GPJNGAIAOAJ()
		{
			if (string.IsNullOrEmpty(bundleId))
			{
				Debug.LogWarning("ID_GETAREWARD1", this);
				return "[0-9.,]*";
			}
			return bundleId;
		}
	}
}
