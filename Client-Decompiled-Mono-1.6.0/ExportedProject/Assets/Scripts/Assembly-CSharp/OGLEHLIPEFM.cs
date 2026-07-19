using System;
using System.Collections.Generic;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Text;
using Google2u;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using UnityEngine;

public class OGLEHLIPEFM
{
	private sealed class BDAJADMCBLN
	{
		internal DatabaseAction MHLAAHNPMFG;

		internal List<Tuple<string, string>> GMDJHENPLHB;

		internal void LJCDGJKCNEC()
		{
			Singleton<BeanstalkServerManager>.instance.MHJJKDKKAKC(MHLAAHNPMFG, GMDJHENPLHB);
		}

		internal void OKNCFDMEFGJ()
		{
			Singleton<BeanstalkServerManager>.instance.FFEACDMAGHG(MHLAAHNPMFG, GMDJHENPLHB);
		}

		internal void NNIJEDKBPGJ()
		{
			Singleton<BeanstalkServerManager>.instance.FFEACDMAGHG(MHLAAHNPMFG, GMDJHENPLHB);
		}

		internal void MAKLHLCDIKD()
		{
			Singleton<BeanstalkServerManager>.instance.MHJJKDKKAKC(MHLAAHNPMFG, GMDJHENPLHB);
		}
	}

	private sealed class FIPCAFCHKHM
	{
		internal string IOFHDGKGFBG;

		internal string EGLIJCPPLIP;

		internal void NAJNECOMDDN(bool ICNLEBMILEH)
		{
			if (ICNLEBMILEH)
			{
				GameLoginManager.instance.LogoutFromFacebook(true);
				return;
			}
			DialogManager.instance.HideAllDialogs();
			Singleton<DailyRewardManager>.instance.LNAIDLKGCFN = null;
			Singleton<MessageManager>.instance.CBFLNGPBHKJ();
			GameLoginManager.instance.acountDataDownloadingInProgress = false;
			GameLoginManager.instance.DeletePlayerAccount();
			Singleton<BeanstalkServerManager>.instance.ADHFEBMEPLO(IOFHDGKGFBG, EGLIJCPPLIP, AccountType.GooglePlay);
		}

		internal void ECPMEMNKMCB(bool ICNLEBMILEH)
		{
			if (ICNLEBMILEH)
			{
				GameLoginManager.instance.LogoutFromFacebook(false);
				return;
			}
			DialogManager.instance.HideAllDialogs();
			Singleton<DailyRewardManager>.instance.LNAIDLKGCFN = null;
			Singleton<MessageManager>.instance.CBFLNGPBHKJ();
			GameLoginManager.instance.acountDataDownloadingInProgress = false;
			GameLoginManager.instance.DeletePlayerAccount();
			Singleton<BeanstalkServerManager>.instance.ADHFEBMEPLO(IOFHDGKGFBG, EGLIJCPPLIP, (AccountType)1);
		}

		internal void KNJBDOADLDO(bool ICNLEBMILEH)
		{
			if (ICNLEBMILEH)
			{
				GameLoginManager.instance.LogoutFromFacebook(true);
				return;
			}
			DialogManager.instance.HideAllDialogs();
			Singleton<DailyRewardManager>.instance.LNAIDLKGCFN = null;
			Singleton<MessageManager>.instance.ClearAllMessages();
			GameLoginManager.instance.acountDataDownloadingInProgress = false;
			GameLoginManager.instance.DeletePlayerAccount();
			Singleton<BeanstalkServerManager>.instance.ADHFEBMEPLO(IOFHDGKGFBG, EGLIJCPPLIP, (AccountType)5);
		}

		internal void CMCIGAFHIJL(bool ICNLEBMILEH)
		{
			if (ICNLEBMILEH)
			{
				GameLoginManager.instance.LogoutFromFacebook(true);
				return;
			}
			DialogManager.instance.HideAllDialogs();
			Singleton<DailyRewardManager>.instance.LNAIDLKGCFN = null;
			Singleton<MessageManager>.instance.JJFNBAMGIDD();
			GameLoginManager.instance.acountDataDownloadingInProgress = true;
			GameLoginManager.instance.DeletePlayerAccount();
			Singleton<BeanstalkServerManager>.instance.ADHFEBMEPLO(IOFHDGKGFBG, EGLIJCPPLIP, AccountType.GameCenter);
		}

		internal void MMEEJDGGAID(bool ICNLEBMILEH)
		{
			if (ICNLEBMILEH)
			{
				GameLoginManager.instance.LogoutFromFacebook(false);
				return;
			}
			DialogManager.instance.HideAllDialogs();
			Singleton<DailyRewardManager>.instance.LNAIDLKGCFN = null;
			Singleton<MessageManager>.instance.MDOLMHFPFNK();
			GameLoginManager.instance.acountDataDownloadingInProgress = true;
			GameLoginManager.instance.DeletePlayerAccount();
			Singleton<BeanstalkServerManager>.instance.ADHFEBMEPLO(IOFHDGKGFBG, EGLIJCPPLIP, (AccountType)6);
		}

		internal void ILNPANOCHIH(bool ICNLEBMILEH)
		{
			if (ICNLEBMILEH)
			{
				GameLoginManager.instance.LogoutFromFacebook(false);
				return;
			}
			DialogManager.instance.HideAllDialogs();
			Singleton<DailyRewardManager>.instance.LNAIDLKGCFN = null;
			Singleton<MessageManager>.instance.ClearAllMessages();
			GameLoginManager.instance.acountDataDownloadingInProgress = true;
			GameLoginManager.instance.DeletePlayerAccount();
			Singleton<BeanstalkServerManager>.instance.ADHFEBMEPLO(IOFHDGKGFBG, EGLIJCPPLIP, AccountType.GameCenter);
		}

		internal void JGEMIBIJMJC(bool ICNLEBMILEH)
		{
			if (ICNLEBMILEH)
			{
				GameLoginManager.instance.LogoutFromFacebook(true);
				return;
			}
			DialogManager.instance.HideAllDialogs();
			Singleton<DailyRewardManager>.instance.LNAIDLKGCFN = null;
			Singleton<MessageManager>.instance.CBFLNGPBHKJ();
			GameLoginManager.instance.acountDataDownloadingInProgress = false;
			GameLoginManager.instance.DeletePlayerAccount();
			Singleton<BeanstalkServerManager>.instance.ADHFEBMEPLO(IOFHDGKGFBG, EGLIJCPPLIP, (AccountType)1);
		}

		internal void JGHLGHMJJDG(bool ICNLEBMILEH)
		{
			if (ICNLEBMILEH)
			{
				GameLoginManager.instance.LogoutFromFacebook(false);
				return;
			}
			DialogManager.instance.HideAllDialogs();
			Singleton<DailyRewardManager>.instance.LNAIDLKGCFN = null;
			Singleton<MessageManager>.instance.ClearAllMessages();
			GameLoginManager.instance.acountDataDownloadingInProgress = true;
			GameLoginManager.instance.DeletePlayerAccount();
			Singleton<BeanstalkServerManager>.instance.ADHFEBMEPLO(IOFHDGKGFBG, EGLIJCPPLIP, (AccountType)1);
		}

		internal void KJIFNOJILDB(bool ICNLEBMILEH)
		{
			if (ICNLEBMILEH)
			{
				GameLoginManager.instance.LogoutFromFacebook(true);
				return;
			}
			DialogManager.instance.HideAllDialogs();
			Singleton<DailyRewardManager>.instance.LNAIDLKGCFN = null;
			Singleton<MessageManager>.instance.CBFLNGPBHKJ();
			GameLoginManager.instance.acountDataDownloadingInProgress = true;
			GameLoginManager.instance.DeletePlayerAccount();
			Singleton<BeanstalkServerManager>.instance.ADHFEBMEPLO(IOFHDGKGFBG, EGLIJCPPLIP, (AccountType)1);
		}

		internal void LIMGPKFEALB(bool ICNLEBMILEH)
		{
			if (ICNLEBMILEH)
			{
				GameLoginManager.instance.LogoutFromFacebook(false);
				return;
			}
			DialogManager.instance.HideAllDialogs();
			Singleton<DailyRewardManager>.instance.LNAIDLKGCFN = null;
			Singleton<MessageManager>.instance.MDOLMHFPFNK();
			GameLoginManager.instance.acountDataDownloadingInProgress = true;
			GameLoginManager.instance.DeletePlayerAccount();
			Singleton<BeanstalkServerManager>.instance.ADHFEBMEPLO(IOFHDGKGFBG, EGLIJCPPLIP, (AccountType)1);
		}

		internal void DFAGLMPEDIH(bool ICNLEBMILEH)
		{
			if (ICNLEBMILEH)
			{
				GameLoginManager.instance.LogoutFromFacebook(true);
				return;
			}
			DialogManager.instance.HideAllDialogs();
			Singleton<DailyRewardManager>.instance.LNAIDLKGCFN = null;
			Singleton<MessageManager>.instance.ClearAllMessages();
			GameLoginManager.instance.acountDataDownloadingInProgress = false;
			GameLoginManager.instance.DeletePlayerAccount();
			Singleton<BeanstalkServerManager>.instance.ADHFEBMEPLO(IOFHDGKGFBG, EGLIJCPPLIP, (AccountType)1);
		}

		internal void JEGPCHMCABF(bool ICNLEBMILEH)
		{
			if (ICNLEBMILEH)
			{
				GameLoginManager.instance.LogoutFromFacebook(true);
				return;
			}
			DialogManager.instance.HideAllDialogs();
			Singleton<DailyRewardManager>.instance.LNAIDLKGCFN = null;
			Singleton<MessageManager>.instance.CBFLNGPBHKJ();
			GameLoginManager.instance.acountDataDownloadingInProgress = true;
			GameLoginManager.instance.DeletePlayerAccount();
			Singleton<BeanstalkServerManager>.instance.ADHFEBMEPLO(IOFHDGKGFBG, EGLIJCPPLIP, (AccountType)8);
		}

		internal void BEIGOGFHJIB(bool ICNLEBMILEH)
		{
			if (ICNLEBMILEH)
			{
				GameLoginManager.instance.LogoutFromFacebook(true);
				return;
			}
			DialogManager.instance.HideAllDialogs();
			Singleton<DailyRewardManager>.instance.LNAIDLKGCFN = null;
			Singleton<MessageManager>.instance.CBFLNGPBHKJ();
			GameLoginManager.instance.acountDataDownloadingInProgress = false;
			GameLoginManager.instance.DeletePlayerAccount();
			Singleton<BeanstalkServerManager>.instance.ADHFEBMEPLO(IOFHDGKGFBG, EGLIJCPPLIP, (AccountType)8);
		}

		internal void BBPKDMPNEDG(bool ICNLEBMILEH)
		{
			if (ICNLEBMILEH)
			{
				GameLoginManager.instance.LogoutFromFacebook(true);
				return;
			}
			DialogManager.instance.HideAllDialogs();
			Singleton<DailyRewardManager>.instance.LNAIDLKGCFN = null;
			Singleton<MessageManager>.instance.JJFNBAMGIDD();
			GameLoginManager.instance.acountDataDownloadingInProgress = false;
			GameLoginManager.instance.DeletePlayerAccount();
			Singleton<BeanstalkServerManager>.instance.ADHFEBMEPLO(IOFHDGKGFBG, EGLIJCPPLIP, AccountType.GameCenter);
		}

		internal void ADEFLNOHDAK(bool ICNLEBMILEH)
		{
			if (ICNLEBMILEH)
			{
				GameLoginManager.instance.LogoutFromFacebook(false);
				return;
			}
			DialogManager.instance.HideAllDialogs();
			Singleton<DailyRewardManager>.instance.LNAIDLKGCFN = null;
			Singleton<MessageManager>.instance.JJFNBAMGIDD();
			GameLoginManager.instance.acountDataDownloadingInProgress = true;
			GameLoginManager.instance.DeletePlayerAccount();
			Singleton<BeanstalkServerManager>.instance.ADHFEBMEPLO(IOFHDGKGFBG, EGLIJCPPLIP, (AccountType)1);
		}

		internal void LGJCNCHBFDA(bool ICNLEBMILEH)
		{
			if (ICNLEBMILEH)
			{
				GameLoginManager.instance.LogoutFromFacebook(true);
				return;
			}
			DialogManager.instance.HideAllDialogs();
			Singleton<DailyRewardManager>.instance.LNAIDLKGCFN = null;
			Singleton<MessageManager>.instance.ClearAllMessages();
			GameLoginManager.instance.acountDataDownloadingInProgress = true;
			GameLoginManager.instance.DeletePlayerAccount();
			Singleton<BeanstalkServerManager>.instance.ADHFEBMEPLO(IOFHDGKGFBG, EGLIJCPPLIP, AccountType.Facebook);
		}

		internal void JAIGALEPPLI(bool ICNLEBMILEH)
		{
			if (ICNLEBMILEH)
			{
				GameLoginManager.instance.LogoutFromFacebook(true);
				return;
			}
			DialogManager.instance.HideAllDialogs();
			Singleton<DailyRewardManager>.instance.LNAIDLKGCFN = null;
			Singleton<MessageManager>.instance.JJFNBAMGIDD();
			GameLoginManager.instance.acountDataDownloadingInProgress = true;
			GameLoginManager.instance.DeletePlayerAccount();
			Singleton<BeanstalkServerManager>.instance.ADHFEBMEPLO(IOFHDGKGFBG, EGLIJCPPLIP, AccountType.GameCenter);
		}

		internal void KLJNEGDLOMG(bool ICNLEBMILEH)
		{
			if (ICNLEBMILEH)
			{
				GameLoginManager.instance.LogoutFromFacebook(true);
				return;
			}
			DialogManager.instance.HideAllDialogs();
			Singleton<DailyRewardManager>.instance.LNAIDLKGCFN = null;
			Singleton<MessageManager>.instance.CBFLNGPBHKJ();
			GameLoginManager.instance.acountDataDownloadingInProgress = false;
			GameLoginManager.instance.DeletePlayerAccount();
			Singleton<BeanstalkServerManager>.instance.ADHFEBMEPLO(IOFHDGKGFBG, EGLIJCPPLIP, (AccountType)1);
		}

		internal void CFJHDIHLIML(bool ICNLEBMILEH)
		{
			if (ICNLEBMILEH)
			{
				GameLoginManager.instance.LogoutFromFacebook(false);
				return;
			}
			DialogManager.instance.HideAllDialogs();
			Singleton<DailyRewardManager>.instance.LNAIDLKGCFN = null;
			Singleton<MessageManager>.instance.JJFNBAMGIDD();
			GameLoginManager.instance.acountDataDownloadingInProgress = false;
			GameLoginManager.instance.DeletePlayerAccount();
			Singleton<BeanstalkServerManager>.instance.ADHFEBMEPLO(IOFHDGKGFBG, EGLIJCPPLIP, AccountType.Guest);
		}

		internal void BMCMDMKGHHO(bool ICNLEBMILEH)
		{
			if (ICNLEBMILEH)
			{
				GameLoginManager.instance.LogoutFromFacebook(true);
				return;
			}
			DialogManager.instance.HideAllDialogs();
			Singleton<DailyRewardManager>.instance.LNAIDLKGCFN = null;
			Singleton<MessageManager>.instance.CBFLNGPBHKJ();
			GameLoginManager.instance.acountDataDownloadingInProgress = false;
			GameLoginManager.instance.DeletePlayerAccount();
			Singleton<BeanstalkServerManager>.instance.ADHFEBMEPLO(IOFHDGKGFBG, EGLIJCPPLIP, (AccountType)6);
		}

		internal void CJIBPJPJLNB(bool ICNLEBMILEH)
		{
			if (ICNLEBMILEH)
			{
				GameLoginManager.instance.LogoutFromFacebook(false);
				return;
			}
			DialogManager.instance.HideAllDialogs();
			Singleton<DailyRewardManager>.instance.LNAIDLKGCFN = null;
			Singleton<MessageManager>.instance.MDOLMHFPFNK();
			GameLoginManager.instance.acountDataDownloadingInProgress = true;
			GameLoginManager.instance.DeletePlayerAccount();
			Singleton<BeanstalkServerManager>.instance.ADHFEBMEPLO(IOFHDGKGFBG, EGLIJCPPLIP, AccountType.Facebook);
		}

		internal void NCLMPCCHDAM(bool ICNLEBMILEH)
		{
			if (ICNLEBMILEH)
			{
				GameLoginManager.instance.LogoutFromFacebook(false);
				return;
			}
			DialogManager.instance.HideAllDialogs();
			Singleton<DailyRewardManager>.instance.LNAIDLKGCFN = null;
			Singleton<MessageManager>.instance.JJFNBAMGIDD();
			GameLoginManager.instance.acountDataDownloadingInProgress = false;
			GameLoginManager.instance.DeletePlayerAccount();
			Singleton<BeanstalkServerManager>.instance.ADHFEBMEPLO(IOFHDGKGFBG, EGLIJCPPLIP, (AccountType)6);
		}

		internal void ANAGFGHGPJA(bool ICNLEBMILEH)
		{
			if (ICNLEBMILEH)
			{
				GameLoginManager.instance.LogoutFromFacebook(false);
				return;
			}
			DialogManager.instance.HideAllDialogs();
			Singleton<DailyRewardManager>.instance.LNAIDLKGCFN = null;
			Singleton<MessageManager>.instance.JJFNBAMGIDD();
			GameLoginManager.instance.acountDataDownloadingInProgress = true;
			GameLoginManager.instance.DeletePlayerAccount();
			Singleton<BeanstalkServerManager>.instance.ADHFEBMEPLO(IOFHDGKGFBG, EGLIJCPPLIP, (AccountType)5);
		}

		internal void FKIBFHGKMFJ(bool ICNLEBMILEH)
		{
			if (ICNLEBMILEH)
			{
				GameLoginManager.instance.LogoutFromFacebook(true);
				return;
			}
			DialogManager.instance.HideAllDialogs();
			Singleton<DailyRewardManager>.instance.LNAIDLKGCFN = null;
			Singleton<MessageManager>.instance.CBFLNGPBHKJ();
			GameLoginManager.instance.acountDataDownloadingInProgress = false;
			GameLoginManager.instance.DeletePlayerAccount();
			Singleton<BeanstalkServerManager>.instance.ADHFEBMEPLO(IOFHDGKGFBG, EGLIJCPPLIP, AccountType.GooglePlay);
		}

		internal void GFBPCKDLGMM(bool ICNLEBMILEH)
		{
			if (ICNLEBMILEH)
			{
				GameLoginManager.instance.LogoutFromFacebook(true);
				return;
			}
			DialogManager.instance.HideAllDialogs();
			Singleton<DailyRewardManager>.instance.LNAIDLKGCFN = null;
			Singleton<MessageManager>.instance.CBFLNGPBHKJ();
			GameLoginManager.instance.acountDataDownloadingInProgress = true;
			GameLoginManager.instance.DeletePlayerAccount();
			Singleton<BeanstalkServerManager>.instance.ADHFEBMEPLO(IOFHDGKGFBG, EGLIJCPPLIP, AccountType.Facebook);
		}

		internal void ILOFOILFGMA(bool ICNLEBMILEH)
		{
			if (ICNLEBMILEH)
			{
				GameLoginManager.instance.LogoutFromFacebook(true);
				return;
			}
			DialogManager.instance.HideAllDialogs();
			Singleton<DailyRewardManager>.instance.LNAIDLKGCFN = null;
			Singleton<MessageManager>.instance.ClearAllMessages();
			GameLoginManager.instance.acountDataDownloadingInProgress = true;
			GameLoginManager.instance.DeletePlayerAccount();
			Singleton<BeanstalkServerManager>.instance.ADHFEBMEPLO(IOFHDGKGFBG, EGLIJCPPLIP, (AccountType)1);
		}

		internal void MCFGAFBEJDK(bool ICNLEBMILEH)
		{
			if (ICNLEBMILEH)
			{
				GameLoginManager.instance.LogoutFromFacebook(true);
				return;
			}
			DialogManager.instance.HideAllDialogs();
			Singleton<DailyRewardManager>.instance.LNAIDLKGCFN = null;
			Singleton<MessageManager>.instance.CBFLNGPBHKJ();
			GameLoginManager.instance.acountDataDownloadingInProgress = true;
			GameLoginManager.instance.DeletePlayerAccount();
			Singleton<BeanstalkServerManager>.instance.ADHFEBMEPLO(IOFHDGKGFBG, EGLIJCPPLIP, AccountType.Guest);
		}

		internal void KCOOCOMPHEF(bool ICNLEBMILEH)
		{
			if (ICNLEBMILEH)
			{
				GameLoginManager.instance.LogoutFromFacebook(false);
				return;
			}
			DialogManager.instance.HideAllDialogs();
			Singleton<DailyRewardManager>.instance.LNAIDLKGCFN = null;
			Singleton<MessageManager>.instance.MDOLMHFPFNK();
			GameLoginManager.instance.acountDataDownloadingInProgress = false;
			GameLoginManager.instance.DeletePlayerAccount();
			Singleton<BeanstalkServerManager>.instance.ADHFEBMEPLO(IOFHDGKGFBG, EGLIJCPPLIP, AccountType.GameCenter);
		}

		internal void DGELDDJAEEF(bool ICNLEBMILEH)
		{
			if (ICNLEBMILEH)
			{
				GameLoginManager.instance.LogoutFromFacebook(true);
				return;
			}
			DialogManager.instance.HideAllDialogs();
			Singleton<DailyRewardManager>.instance.LNAIDLKGCFN = null;
			Singleton<MessageManager>.instance.JJFNBAMGIDD();
			GameLoginManager.instance.acountDataDownloadingInProgress = false;
			GameLoginManager.instance.DeletePlayerAccount();
			Singleton<BeanstalkServerManager>.instance.ADHFEBMEPLO(IOFHDGKGFBG, EGLIJCPPLIP, (AccountType)6);
		}

		internal void ALIBBKEHCFC(bool ICNLEBMILEH)
		{
			if (ICNLEBMILEH)
			{
				GameLoginManager.instance.LogoutFromFacebook(true);
				return;
			}
			DialogManager.instance.HideAllDialogs();
			Singleton<DailyRewardManager>.instance.LNAIDLKGCFN = null;
			Singleton<MessageManager>.instance.ClearAllMessages();
			GameLoginManager.instance.acountDataDownloadingInProgress = false;
			GameLoginManager.instance.DeletePlayerAccount();
			Singleton<BeanstalkServerManager>.instance.ADHFEBMEPLO(IOFHDGKGFBG, EGLIJCPPLIP, (AccountType)5);
		}

		internal void MAKLHLCDIKD(bool ICNLEBMILEH)
		{
			if (ICNLEBMILEH)
			{
				GameLoginManager.instance.LogoutFromFacebook(true);
				return;
			}
			DialogManager.instance.HideAllDialogs();
			Singleton<DailyRewardManager>.instance.LNAIDLKGCFN = null;
			Singleton<MessageManager>.instance.JJFNBAMGIDD();
			GameLoginManager.instance.acountDataDownloadingInProgress = false;
			GameLoginManager.instance.DeletePlayerAccount();
			Singleton<BeanstalkServerManager>.instance.ADHFEBMEPLO(IOFHDGKGFBG, EGLIJCPPLIP, AccountType.GameCenter);
		}

		internal void PANKBNOCEAM(bool ICNLEBMILEH)
		{
			if (ICNLEBMILEH)
			{
				GameLoginManager.instance.LogoutFromFacebook(true);
				return;
			}
			DialogManager.instance.HideAllDialogs();
			Singleton<DailyRewardManager>.instance.LNAIDLKGCFN = null;
			Singleton<MessageManager>.instance.ClearAllMessages();
			GameLoginManager.instance.acountDataDownloadingInProgress = false;
			GameLoginManager.instance.DeletePlayerAccount();
			Singleton<BeanstalkServerManager>.instance.ADHFEBMEPLO(IOFHDGKGFBG, EGLIJCPPLIP, AccountType.GameCenter);
		}

		internal void EMKPBGFBPFI(bool ICNLEBMILEH)
		{
			if (ICNLEBMILEH)
			{
				GameLoginManager.instance.LogoutFromFacebook(false);
				return;
			}
			DialogManager.instance.HideAllDialogs();
			Singleton<DailyRewardManager>.instance.LNAIDLKGCFN = null;
			Singleton<MessageManager>.instance.JJFNBAMGIDD();
			GameLoginManager.instance.acountDataDownloadingInProgress = true;
			GameLoginManager.instance.DeletePlayerAccount();
			Singleton<BeanstalkServerManager>.instance.ADHFEBMEPLO(IOFHDGKGFBG, EGLIJCPPLIP, AccountType.Facebook);
		}

		internal void PHGDBIEENCB(bool ICNLEBMILEH)
		{
			if (ICNLEBMILEH)
			{
				GameLoginManager.instance.LogoutFromFacebook(true);
				return;
			}
			DialogManager.instance.HideAllDialogs();
			Singleton<DailyRewardManager>.instance.LNAIDLKGCFN = null;
			Singleton<MessageManager>.instance.ClearAllMessages();
			GameLoginManager.instance.acountDataDownloadingInProgress = true;
			GameLoginManager.instance.DeletePlayerAccount();
			Singleton<BeanstalkServerManager>.instance.ADHFEBMEPLO(IOFHDGKGFBG, EGLIJCPPLIP, AccountType.GooglePlay);
		}

		internal void AGFEDJAKLAC(bool ICNLEBMILEH)
		{
			if (ICNLEBMILEH)
			{
				GameLoginManager.instance.LogoutFromFacebook(false);
				return;
			}
			DialogManager.instance.HideAllDialogs();
			Singleton<DailyRewardManager>.instance.LNAIDLKGCFN = null;
			Singleton<MessageManager>.instance.MDOLMHFPFNK();
			GameLoginManager.instance.acountDataDownloadingInProgress = true;
			GameLoginManager.instance.DeletePlayerAccount();
			Singleton<BeanstalkServerManager>.instance.ADHFEBMEPLO(IOFHDGKGFBG, EGLIJCPPLIP, (AccountType)5);
		}

		internal void FDKMOFHAEFN(bool ICNLEBMILEH)
		{
			if (ICNLEBMILEH)
			{
				GameLoginManager.instance.LogoutFromFacebook(false);
				return;
			}
			DialogManager.instance.HideAllDialogs();
			Singleton<DailyRewardManager>.instance.LNAIDLKGCFN = null;
			Singleton<MessageManager>.instance.CBFLNGPBHKJ();
			GameLoginManager.instance.acountDataDownloadingInProgress = true;
			GameLoginManager.instance.DeletePlayerAccount();
			Singleton<BeanstalkServerManager>.instance.ADHFEBMEPLO(IOFHDGKGFBG, EGLIJCPPLIP, (AccountType)7);
		}

		internal void CMDLGJKIBLL(bool ICNLEBMILEH)
		{
			if (ICNLEBMILEH)
			{
				GameLoginManager.instance.LogoutFromFacebook(true);
				return;
			}
			DialogManager.instance.HideAllDialogs();
			Singleton<DailyRewardManager>.instance.LNAIDLKGCFN = null;
			Singleton<MessageManager>.instance.CBFLNGPBHKJ();
			GameLoginManager.instance.acountDataDownloadingInProgress = true;
			GameLoginManager.instance.DeletePlayerAccount();
			Singleton<BeanstalkServerManager>.instance.ADHFEBMEPLO(IOFHDGKGFBG, EGLIJCPPLIP, (AccountType)7);
		}

		internal void LHPPLGOOLEC(bool ICNLEBMILEH)
		{
			if (ICNLEBMILEH)
			{
				GameLoginManager.instance.LogoutFromFacebook(true);
				return;
			}
			DialogManager.instance.HideAllDialogs();
			Singleton<DailyRewardManager>.instance.LNAIDLKGCFN = null;
			Singleton<MessageManager>.instance.CBFLNGPBHKJ();
			GameLoginManager.instance.acountDataDownloadingInProgress = false;
			GameLoginManager.instance.DeletePlayerAccount();
			Singleton<BeanstalkServerManager>.instance.ADHFEBMEPLO(IOFHDGKGFBG, EGLIJCPPLIP, (AccountType)5);
		}

		internal void PPKGMGNKNAE(bool ICNLEBMILEH)
		{
			if (ICNLEBMILEH)
			{
				GameLoginManager.instance.LogoutFromFacebook(true);
				return;
			}
			DialogManager.instance.HideAllDialogs();
			Singleton<DailyRewardManager>.instance.LNAIDLKGCFN = null;
			Singleton<MessageManager>.instance.MDOLMHFPFNK();
			GameLoginManager.instance.acountDataDownloadingInProgress = false;
			GameLoginManager.instance.DeletePlayerAccount();
			Singleton<BeanstalkServerManager>.instance.ADHFEBMEPLO(IOFHDGKGFBG, EGLIJCPPLIP, (AccountType)5);
		}

		internal void HHLMDAKDHFK(bool ICNLEBMILEH)
		{
			if (ICNLEBMILEH)
			{
				GameLoginManager.instance.LogoutFromFacebook(true);
				return;
			}
			DialogManager.instance.HideAllDialogs();
			Singleton<DailyRewardManager>.instance.LNAIDLKGCFN = null;
			Singleton<MessageManager>.instance.ClearAllMessages();
			GameLoginManager.instance.acountDataDownloadingInProgress = false;
			GameLoginManager.instance.DeletePlayerAccount();
			Singleton<BeanstalkServerManager>.instance.ADHFEBMEPLO(IOFHDGKGFBG, EGLIJCPPLIP, (AccountType)7);
		}

		internal void LJCDGJKCNEC(bool ICNLEBMILEH)
		{
			if (ICNLEBMILEH)
			{
				GameLoginManager.instance.LogoutFromFacebook(true);
				return;
			}
			DialogManager.instance.HideAllDialogs();
			Singleton<DailyRewardManager>.instance.LNAIDLKGCFN = null;
			Singleton<MessageManager>.instance.ClearAllMessages();
			GameLoginManager.instance.acountDataDownloadingInProgress = true;
			GameLoginManager.instance.DeletePlayerAccount();
			Singleton<BeanstalkServerManager>.instance.ADHFEBMEPLO(IOFHDGKGFBG, EGLIJCPPLIP, AccountType.Facebook);
		}

		internal void POGLHCIAAGH(bool ICNLEBMILEH)
		{
			if (ICNLEBMILEH)
			{
				GameLoginManager.instance.LogoutFromFacebook(true);
				return;
			}
			DialogManager.instance.HideAllDialogs();
			Singleton<DailyRewardManager>.instance.LNAIDLKGCFN = null;
			Singleton<MessageManager>.instance.CBFLNGPBHKJ();
			GameLoginManager.instance.acountDataDownloadingInProgress = true;
			GameLoginManager.instance.DeletePlayerAccount();
			Singleton<BeanstalkServerManager>.instance.ADHFEBMEPLO(IOFHDGKGFBG, EGLIJCPPLIP, AccountType.Guest);
		}

		internal void NDJOJHNIBFC(bool ICNLEBMILEH)
		{
			if (ICNLEBMILEH)
			{
				GameLoginManager.instance.LogoutFromFacebook(true);
				return;
			}
			DialogManager.instance.HideAllDialogs();
			Singleton<DailyRewardManager>.instance.LNAIDLKGCFN = null;
			Singleton<MessageManager>.instance.JJFNBAMGIDD();
			GameLoginManager.instance.acountDataDownloadingInProgress = false;
			GameLoginManager.instance.DeletePlayerAccount();
			Singleton<BeanstalkServerManager>.instance.ADHFEBMEPLO(IOFHDGKGFBG, EGLIJCPPLIP, AccountType.Facebook);
		}

		internal void FHDOHCJJEMM(bool ICNLEBMILEH)
		{
			if (ICNLEBMILEH)
			{
				GameLoginManager.instance.LogoutFromFacebook(false);
				return;
			}
			DialogManager.instance.HideAllDialogs();
			Singleton<DailyRewardManager>.instance.LNAIDLKGCFN = null;
			Singleton<MessageManager>.instance.MDOLMHFPFNK();
			GameLoginManager.instance.acountDataDownloadingInProgress = false;
			GameLoginManager.instance.DeletePlayerAccount();
			Singleton<BeanstalkServerManager>.instance.ADHFEBMEPLO(IOFHDGKGFBG, EGLIJCPPLIP, AccountType.GameCenter);
		}

		internal void PEFOCGECECP(bool ICNLEBMILEH)
		{
			if (ICNLEBMILEH)
			{
				GameLoginManager.instance.LogoutFromFacebook(false);
				return;
			}
			DialogManager.instance.HideAllDialogs();
			Singleton<DailyRewardManager>.instance.LNAIDLKGCFN = null;
			Singleton<MessageManager>.instance.MDOLMHFPFNK();
			GameLoginManager.instance.acountDataDownloadingInProgress = false;
			GameLoginManager.instance.DeletePlayerAccount();
			Singleton<BeanstalkServerManager>.instance.ADHFEBMEPLO(IOFHDGKGFBG, EGLIJCPPLIP, (AccountType)6);
		}

		internal void CHOIECFFEMH(bool ICNLEBMILEH)
		{
			if (ICNLEBMILEH)
			{
				GameLoginManager.instance.LogoutFromFacebook(true);
				return;
			}
			DialogManager.instance.HideAllDialogs();
			Singleton<DailyRewardManager>.instance.LNAIDLKGCFN = null;
			Singleton<MessageManager>.instance.MDOLMHFPFNK();
			GameLoginManager.instance.acountDataDownloadingInProgress = false;
			GameLoginManager.instance.DeletePlayerAccount();
			Singleton<BeanstalkServerManager>.instance.ADHFEBMEPLO(IOFHDGKGFBG, EGLIJCPPLIP, AccountType.GameCenter);
		}

		internal void PCKMJMGLPDG(bool ICNLEBMILEH)
		{
			if (ICNLEBMILEH)
			{
				GameLoginManager.instance.LogoutFromFacebook(true);
				return;
			}
			DialogManager.instance.HideAllDialogs();
			Singleton<DailyRewardManager>.instance.LNAIDLKGCFN = null;
			Singleton<MessageManager>.instance.JJFNBAMGIDD();
			GameLoginManager.instance.acountDataDownloadingInProgress = true;
			GameLoginManager.instance.DeletePlayerAccount();
			Singleton<BeanstalkServerManager>.instance.ADHFEBMEPLO(IOFHDGKGFBG, EGLIJCPPLIP, (AccountType)7);
		}

		internal void OABFAOLFMMJ(bool ICNLEBMILEH)
		{
			if (ICNLEBMILEH)
			{
				GameLoginManager.instance.LogoutFromFacebook(false);
				return;
			}
			DialogManager.instance.HideAllDialogs();
			Singleton<DailyRewardManager>.instance.LNAIDLKGCFN = null;
			Singleton<MessageManager>.instance.MDOLMHFPFNK();
			GameLoginManager.instance.acountDataDownloadingInProgress = false;
			GameLoginManager.instance.DeletePlayerAccount();
			Singleton<BeanstalkServerManager>.instance.ADHFEBMEPLO(IOFHDGKGFBG, EGLIJCPPLIP, (AccountType)1);
		}

		internal void BDCAFHOHEGM(bool ICNLEBMILEH)
		{
			if (ICNLEBMILEH)
			{
				GameLoginManager.instance.LogoutFromFacebook(true);
				return;
			}
			DialogManager.instance.HideAllDialogs();
			Singleton<DailyRewardManager>.instance.LNAIDLKGCFN = null;
			Singleton<MessageManager>.instance.JJFNBAMGIDD();
			GameLoginManager.instance.acountDataDownloadingInProgress = true;
			GameLoginManager.instance.DeletePlayerAccount();
			Singleton<BeanstalkServerManager>.instance.ADHFEBMEPLO(IOFHDGKGFBG, EGLIJCPPLIP, AccountType.GameCenter);
		}

		internal void AMIJFGBOCLC(bool ICNLEBMILEH)
		{
			if (ICNLEBMILEH)
			{
				GameLoginManager.instance.LogoutFromFacebook(true);
				return;
			}
			DialogManager.instance.HideAllDialogs();
			Singleton<DailyRewardManager>.instance.LNAIDLKGCFN = null;
			Singleton<MessageManager>.instance.JJFNBAMGIDD();
			GameLoginManager.instance.acountDataDownloadingInProgress = true;
			GameLoginManager.instance.DeletePlayerAccount();
			Singleton<BeanstalkServerManager>.instance.ADHFEBMEPLO(IOFHDGKGFBG, EGLIJCPPLIP, AccountType.Guest);
		}

		internal void OPHINHIOCFD(bool ICNLEBMILEH)
		{
			if (ICNLEBMILEH)
			{
				GameLoginManager.instance.LogoutFromFacebook(false);
				return;
			}
			DialogManager.instance.HideAllDialogs();
			Singleton<DailyRewardManager>.instance.LNAIDLKGCFN = null;
			Singleton<MessageManager>.instance.CBFLNGPBHKJ();
			GameLoginManager.instance.acountDataDownloadingInProgress = true;
			GameLoginManager.instance.DeletePlayerAccount();
			Singleton<BeanstalkServerManager>.instance.ADHFEBMEPLO(IOFHDGKGFBG, EGLIJCPPLIP, (AccountType)8);
		}

		internal void LKKLABBEOAG(bool ICNLEBMILEH)
		{
			if (ICNLEBMILEH)
			{
				GameLoginManager.instance.LogoutFromFacebook(false);
				return;
			}
			DialogManager.instance.HideAllDialogs();
			Singleton<DailyRewardManager>.instance.LNAIDLKGCFN = null;
			Singleton<MessageManager>.instance.CBFLNGPBHKJ();
			GameLoginManager.instance.acountDataDownloadingInProgress = false;
			GameLoginManager.instance.DeletePlayerAccount();
			Singleton<BeanstalkServerManager>.instance.ADHFEBMEPLO(IOFHDGKGFBG, EGLIJCPPLIP, (AccountType)8);
		}

		internal void HOMIPBFODIC(bool ICNLEBMILEH)
		{
			if (ICNLEBMILEH)
			{
				GameLoginManager.instance.LogoutFromFacebook(false);
				return;
			}
			DialogManager.instance.HideAllDialogs();
			Singleton<DailyRewardManager>.instance.LNAIDLKGCFN = null;
			Singleton<MessageManager>.instance.JJFNBAMGIDD();
			GameLoginManager.instance.acountDataDownloadingInProgress = false;
			GameLoginManager.instance.DeletePlayerAccount();
			Singleton<BeanstalkServerManager>.instance.ADHFEBMEPLO(IOFHDGKGFBG, EGLIJCPPLIP, (AccountType)5);
		}
	}

	private sealed class DFNGILBMEEI
	{
		internal AccountType FEPHCHKJGHD;
	}

	private sealed class BHCMEPMHFMN
	{
		internal string INFLHPGMEOB;

		internal string PGHCHNIDLNJ;

		internal DFNGILBMEEI ALIKEGIJIHD;

		internal void EMKPBGFBPFI(bool AOGFDHEMCCM)
		{
			if (AOGFDHEMCCM)
			{
				Debug.Log("ID_CHANGENAMENOTENOUGHT");
				if (ALIKEGIJIHD.FEPHCHKJGHD != AccountType.Facebook)
				{
					if (ALIKEGIJIHD.FEPHCHKJGHD == (AccountType)1)
					{
						GameLoginManager.instance.LogoutFromGooglePlay(false);
					}
				}
				else
				{
					GameLoginManager.instance.LogoutFromFacebook(false);
				}
			}
			else
			{
				Debug.Log(" error (no ColumnNames)");
				DialogManager.instance.HideAllDialogs();
				Singleton<DailyRewardManager>.instance.LNAIDLKGCFN = null;
				Singleton<MessageManager>.instance.JJFNBAMGIDD();
				GameLoginManager.instance.acountDataDownloadingInProgress = false;
				Singleton<BeanstalkServerManager>.instance.ADHFEBMEPLO(INFLHPGMEOB, PGHCHNIDLNJ, ALIKEGIJIHD.FEPHCHKJGHD);
			}
		}

		internal void FIBGJHCGHJH(bool AOGFDHEMCCM)
		{
			if (AOGFDHEMCCM)
			{
				Debug.Log("VisualType");
				if (ALIKEGIJIHD.FEPHCHKJGHD != (AccountType)5)
				{
					if (ALIKEGIJIHD.FEPHCHKJGHD == (AccountType)1)
					{
						GameLoginManager.instance.LogoutFromGooglePlay(false);
					}
				}
				else
				{
					GameLoginManager.instance.LogoutFromFacebook(true);
				}
			}
			else
			{
				Debug.Log("Spend_Gold_On_Player_Customizations");
				DialogManager.instance.HideAllDialogs();
				Singleton<DailyRewardManager>.instance.LNAIDLKGCFN = null;
				Singleton<MessageManager>.instance.CBFLNGPBHKJ();
				GameLoginManager.instance.acountDataDownloadingInProgress = false;
				Singleton<BeanstalkServerManager>.instance.ADHFEBMEPLO(INFLHPGMEOB, PGHCHNIDLNJ, ALIKEGIJIHD.FEPHCHKJGHD);
			}
		}

		internal void BBPKDMPNEDG(bool AOGFDHEMCCM)
		{
			if (AOGFDHEMCCM)
			{
				Debug.Log("重試");
				if (ALIKEGIJIHD.FEPHCHKJGHD != AccountType.Guest)
				{
					if (ALIKEGIJIHD.FEPHCHKJGHD == AccountType.Facebook)
					{
						GameLoginManager.instance.LogoutFromGooglePlay(true);
					}
				}
				else
				{
					GameLoginManager.instance.LogoutFromFacebook(true);
				}
			}
			else
			{
				Debug.Log("#PETER# Weapon Screen - RIGHT BUTTON - weapon state: NOT BOUGHT\t\tbutton type: BUY UNIT");
				DialogManager.instance.HideAllDialogs();
				Singleton<DailyRewardManager>.instance.LNAIDLKGCFN = null;
				Singleton<MessageManager>.instance.ClearAllMessages();
				GameLoginManager.instance.acountDataDownloadingInProgress = true;
				Singleton<BeanstalkServerManager>.instance.ADHFEBMEPLO(INFLHPGMEOB, PGHCHNIDLNJ, ALIKEGIJIHD.FEPHCHKJGHD);
			}
		}

		internal void NAJNECOMDDN(bool AOGFDHEMCCM)
		{
			if (AOGFDHEMCCM)
			{
				Debug.Log("#PETER# Weapon Screen - RIGHT BUTTON - unit state: NOT BOUGHT\t\tbutton type: BUY UNIT");
				if (ALIKEGIJIHD.FEPHCHKJGHD != AccountType.GooglePlay)
				{
					if (ALIKEGIJIHD.FEPHCHKJGHD == AccountType.GooglePlay)
					{
						GameLoginManager.instance.LogoutFromGooglePlay(true);
					}
				}
				else
				{
					GameLoginManager.instance.LogoutFromFacebook(true);
				}
			}
			else
			{
				Debug.Log("rateAppClientVersion");
				DialogManager.instance.HideAllDialogs();
				Singleton<DailyRewardManager>.instance.LNAIDLKGCFN = null;
				Singleton<MessageManager>.instance.MDOLMHFPFNK();
				GameLoginManager.instance.acountDataDownloadingInProgress = true;
				Singleton<BeanstalkServerManager>.instance.ADHFEBMEPLO(INFLHPGMEOB, PGHCHNIDLNJ, ALIKEGIJIHD.FEPHCHKJGHD);
			}
		}

		internal void KJIFNOJILDB(bool AOGFDHEMCCM)
		{
			if (AOGFDHEMCCM)
			{
				Debug.Log("ID_CONFIRM_SQUADISALREADYFULL");
				if (ALIKEGIJIHD.FEPHCHKJGHD != AccountType.Guest)
				{
					if (ALIKEGIJIHD.FEPHCHKJGHD == AccountType.GooglePlay)
					{
						GameLoginManager.instance.LogoutFromGooglePlay(true);
					}
				}
				else
				{
					GameLoginManager.instance.LogoutFromFacebook(false);
				}
			}
			else
			{
				Debug.Log("Gold");
				DialogManager.instance.HideAllDialogs();
				Singleton<DailyRewardManager>.instance.LNAIDLKGCFN = null;
				Singleton<MessageManager>.instance.ClearAllMessages();
				GameLoginManager.instance.acountDataDownloadingInProgress = false;
				Singleton<BeanstalkServerManager>.instance.ADHFEBMEPLO(INFLHPGMEOB, PGHCHNIDLNJ, ALIKEGIJIHD.FEPHCHKJGHD);
			}
		}

		internal void ECPMEMNKMCB(bool AOGFDHEMCCM)
		{
			if (AOGFDHEMCCM)
			{
				Debug.Log("Scraps");
				if (ALIKEGIJIHD.FEPHCHKJGHD != (AccountType)8)
				{
					if (ALIKEGIJIHD.FEPHCHKJGHD == (AccountType)5)
					{
						GameLoginManager.instance.LogoutFromGooglePlay(false);
					}
				}
				else
				{
					GameLoginManager.instance.LogoutFromFacebook(true);
				}
			}
			else
			{
				Debug.Log("ID_BATTLEWINBONUSRISESTO");
				DialogManager.instance.HideAllDialogs();
				Singleton<DailyRewardManager>.instance.LNAIDLKGCFN = null;
				Singleton<MessageManager>.instance.CBFLNGPBHKJ();
				GameLoginManager.instance.acountDataDownloadingInProgress = true;
				Singleton<BeanstalkServerManager>.instance.ADHFEBMEPLO(INFLHPGMEOB, PGHCHNIDLNJ, ALIKEGIJIHD.FEPHCHKJGHD);
			}
		}

		internal void LJCDGJKCNEC(bool AOGFDHEMCCM)
		{
			if (AOGFDHEMCCM)
			{
				Debug.Log("Player chose to stay on his account");
				if (ALIKEGIJIHD.FEPHCHKJGHD != AccountType.Facebook)
				{
					if (ALIKEGIJIHD.FEPHCHKJGHD == AccountType.GooglePlay)
					{
						GameLoginManager.instance.LogoutFromGooglePlay(true);
					}
				}
				else
				{
					GameLoginManager.instance.LogoutFromFacebook(true);
				}
			}
			else
			{
				Debug.Log("Player chose to switch accounts");
				DialogManager.instance.HideAllDialogs();
				Singleton<DailyRewardManager>.instance.LNAIDLKGCFN = null;
				Singleton<MessageManager>.instance.ClearAllMessages();
				GameLoginManager.instance.acountDataDownloadingInProgress = true;
				Singleton<BeanstalkServerManager>.instance.ADHFEBMEPLO(INFLHPGMEOB, PGHCHNIDLNJ, ALIKEGIJIHD.FEPHCHKJGHD);
			}
		}

		internal void OKNCFDMEFGJ(bool AOGFDHEMCCM)
		{
			if (AOGFDHEMCCM)
			{
				Debug.Log("SquadId");
				if (ALIKEGIJIHD.FEPHCHKJGHD != (AccountType)6)
				{
					if (ALIKEGIJIHD.FEPHCHKJGHD == AccountType.GameCenter)
					{
						GameLoginManager.instance.LogoutFromGooglePlay(false);
					}
				}
				else
				{
					GameLoginManager.instance.LogoutFromFacebook(false);
				}
			}
			else
			{
				Debug.Log("N");
				DialogManager.instance.HideAllDialogs();
				Singleton<DailyRewardManager>.instance.LNAIDLKGCFN = null;
				Singleton<MessageManager>.instance.JJFNBAMGIDD();
				GameLoginManager.instance.acountDataDownloadingInProgress = false;
				Singleton<BeanstalkServerManager>.instance.ADHFEBMEPLO(INFLHPGMEOB, PGHCHNIDLNJ, ALIKEGIJIHD.FEPHCHKJGHD);
			}
		}

		internal void AMIJFGBOCLC(bool AOGFDHEMCCM)
		{
			if (AOGFDHEMCCM)
			{
				Debug.Log("Finished");
				if (ALIKEGIJIHD.FEPHCHKJGHD != AccountType.Facebook)
				{
					if (ALIKEGIJIHD.FEPHCHKJGHD == AccountType.Guest)
					{
						GameLoginManager.instance.LogoutFromGooglePlay(false);
					}
				}
				else
				{
					GameLoginManager.instance.LogoutFromFacebook(false);
				}
			}
			else
			{
				Debug.Log("WENEEDTO");
				DialogManager.instance.HideAllDialogs();
				Singleton<DailyRewardManager>.instance.LNAIDLKGCFN = null;
				Singleton<MessageManager>.instance.JJFNBAMGIDD();
				GameLoginManager.instance.acountDataDownloadingInProgress = true;
				Singleton<BeanstalkServerManager>.instance.ADHFEBMEPLO(INFLHPGMEOB, PGHCHNIDLNJ, ALIKEGIJIHD.FEPHCHKJGHD);
			}
		}

		internal void NNIJEDKBPGJ(bool AOGFDHEMCCM)
		{
			if (AOGFDHEMCCM)
			{
				Debug.Log(" 1\u00a0{0}");
				if (ALIKEGIJIHD.FEPHCHKJGHD != (AccountType)5)
				{
					if (ALIKEGIJIHD.FEPHCHKJGHD == (AccountType)8)
					{
						GameLoginManager.instance.LogoutFromGooglePlay(true);
					}
				}
				else
				{
					GameLoginManager.instance.LogoutFromFacebook(false);
				}
			}
			else
			{
				Debug.Log("equips");
				DialogManager.instance.HideAllDialogs();
				Singleton<DailyRewardManager>.instance.LNAIDLKGCFN = null;
				Singleton<MessageManager>.instance.CBFLNGPBHKJ();
				GameLoginManager.instance.acountDataDownloadingInProgress = true;
				Singleton<BeanstalkServerManager>.instance.ADHFEBMEPLO(INFLHPGMEOB, PGHCHNIDLNJ, ALIKEGIJIHD.FEPHCHKJGHD);
			}
		}

		internal void CIFEDFPPPOK(bool AOGFDHEMCCM)
		{
			if (AOGFDHEMCCM)
			{
				Debug.Log("./Assets/Scripts");
				if (ALIKEGIJIHD.FEPHCHKJGHD != AccountType.Facebook)
				{
					if (ALIKEGIJIHD.FEPHCHKJGHD == AccountType.GameCenter)
					{
						GameLoginManager.instance.LogoutFromGooglePlay(false);
					}
				}
				else
				{
					GameLoginManager.instance.LogoutFromFacebook(true);
				}
			}
			else
			{
				Debug.Log("ID_GUI_CHEATWARNING");
				DialogManager.instance.HideAllDialogs();
				Singleton<DailyRewardManager>.instance.LNAIDLKGCFN = null;
				Singleton<MessageManager>.instance.MDOLMHFPFNK();
				GameLoginManager.instance.acountDataDownloadingInProgress = false;
				Singleton<BeanstalkServerManager>.instance.ADHFEBMEPLO(INFLHPGMEOB, PGHCHNIDLNJ, ALIKEGIJIHD.FEPHCHKJGHD);
			}
		}

		internal void LGJCNCHBFDA(bool AOGFDHEMCCM)
		{
			if (AOGFDHEMCCM)
			{
				Debug.Log("ID_WARNING_ERRORCLAIMASSIGNMENT_TEXT");
				if (ALIKEGIJIHD.FEPHCHKJGHD != AccountType.Facebook)
				{
					if (ALIKEGIJIHD.FEPHCHKJGHD == (AccountType)6)
					{
						GameLoginManager.instance.LogoutFromGooglePlay(true);
					}
				}
				else
				{
					GameLoginManager.instance.LogoutFromFacebook(false);
				}
			}
			else
			{
				Debug.Log("ID_CONFIRM_NOSQUADACTIONS_TEXT");
				DialogManager.instance.HideAllDialogs();
				Singleton<DailyRewardManager>.instance.LNAIDLKGCFN = null;
				Singleton<MessageManager>.instance.ClearAllMessages();
				GameLoginManager.instance.acountDataDownloadingInProgress = false;
				Singleton<BeanstalkServerManager>.instance.ADHFEBMEPLO(INFLHPGMEOB, PGHCHNIDLNJ, ALIKEGIJIHD.FEPHCHKJGHD);
			}
		}

		internal void FHDOHCJJEMM(bool AOGFDHEMCCM)
		{
			if (AOGFDHEMCCM)
			{
				Debug.Log("elitepack");
				if (ALIKEGIJIHD.FEPHCHKJGHD != (AccountType)6)
				{
					if (ALIKEGIJIHD.FEPHCHKJGHD == AccountType.Guest)
					{
						GameLoginManager.instance.LogoutFromGooglePlay(false);
					}
				}
				else
				{
					GameLoginManager.instance.LogoutFromFacebook(false);
				}
			}
			else
			{
				Debug.Log("Squad Member");
				DialogManager.instance.HideAllDialogs();
				Singleton<DailyRewardManager>.instance.LNAIDLKGCFN = null;
				Singleton<MessageManager>.instance.CBFLNGPBHKJ();
				GameLoginManager.instance.acountDataDownloadingInProgress = true;
				Singleton<BeanstalkServerManager>.instance.ADHFEBMEPLO(INFLHPGMEOB, PGHCHNIDLNJ, ALIKEGIJIHD.FEPHCHKJGHD);
			}
		}
	}

	private LEDNENKKDJM HBJBOIMFDAM = new LEDNENKKDJM();

	private Dictionary<string, object> AIJKOENIJFL;

	private OIFCNEJNGJJ FBBKCGLIIOB;

	private bool MFADLJHJNAJ;

	[CompilerGenerated]
	private static Action<ConfirmDialog, bool> LGJCBPOPCPA;

	[CompilerGenerated]
	private static Comparison<Card> CCNLMGEJBIB;

	[CompilerGenerated]
	private static Action KBAICANEKOP;

	[CompilerGenerated]
	private static Action AOPBBLDIOCI;

	[CompilerGenerated]
	private static Action GGDOCGDGEDJ;

	[CompilerGenerated]
	private static Action GHMJMKLOPJK;

	[CompilerGenerated]
	private static Action ODJCCLLMIBO;

	[CompilerGenerated]
	private static Action IEPCBHLLNIP;

	[CompilerGenerated]
	private static Action OHFLEJJHBPJ;

	[CompilerGenerated]
	private static Action CPAMMJBHAEF;

	[CompilerGenerated]
	private static Action AINCBCEGBKN;

	[CompilerGenerated]
	private static Action EPOEJFEBIIL;

	[CompilerGenerated]
	private static Action NLIPFGNJCCI;

	[CompilerGenerated]
	private static Action NKNCGBONKGO;

	[CompilerGenerated]
	private static Action AHBILHIEFOF;

	private void EBOJHBJCGBG()
	{
		Debug.Log("Emblem updated!");
	}

	private void GFGIJJMCPLO()
	{
		Debug.Log("VIP bought");
		Singleton<VipManager>.instance.vipExpiration = KHJJFPPACBP.PELILBMKGHE(AIJKOENIJFL["Vip"]);
		Singleton<VipManager>.instance.vipStart = KHJJFPPACBP.PELILBMKGHE(AIJKOENIJFL["VipStart"]);
		long num = KHJJFPPACBP.OOAIMCEBPOK(AIJKOENIJFL["Gold"], 0L);
		string text = KHJJFPPACBP.BKFCLMMJNHK(AIJKOENIJFL["Id"], string.Empty);
		Singleton<EventTrackingManager>.instance.RegisterBuyVipEvent(text, (int)num);
		Singleton<EventTrackingManager>.instance.RegisterGoldOut("Buy_VIP", (int)num);
		Singleton<PurchaseProtection>.instance.VIPResponseCame(text);
		Singleton<Wallet>.instance.OFHCEFPOCMI(num);
		if (AIJKOENIJFL.ContainsKey("VipReward1"))
		{
			Debug.Log("response contain VipReward");
			string text2 = KHJJFPPACBP.BKFCLMMJNHK(AIJKOENIJFL["VipReward1"], string.Empty);
			string text3 = KHJJFPPACBP.BKFCLMMJNHK(AIJKOENIJFL["VipReward2"], string.Empty);
			string aPGKPOOHGFK = "a";
			if (AIJKOENIJFL.ContainsKey("VipRewardForDay"))
			{
				aPGKPOOHGFK = KHJJFPPACBP.BKFCLMMJNHK(AIJKOENIJFL["VipRewardForDay"], string.Empty);
			}
			Singleton<MessageManager>.instance.AddMessage(new NGGINCOPKKJ(text2, text3, aPGKPOOHGFK));
			CardManager.instance.AddCard(text2);
			CardManager.instance.AddCard(text3);
		}
		PlayerAnalytics.instance.AddTransaction(114, Singleton<VipManager>.instance.vipExpiration.ToString(CultureInfo.InvariantCulture), (int)num, 0, 0f);
	}

	private void MFPFGNKFLAB(List<Tuple<string, string>> GMDJHENPLHB)
	{
		foreach (Tuple<string, string> item in GMDJHENPLHB)
		{
			if (item.Value1 == "MessageId")
			{
				Singleton<AwaitingSquadMembersManager>.instance.OnPlayerAcceptedOrDeclined(item.Value2, true);
				return;
			}
		}
		Debug.LogError("no player Id found");
	}

	private void JHFMMNGADHN()
	{
		DatabasePlayer currentPlayer = GameLoginManager.currentPlayer;
		GameLoginManager.instance.UpdatePlayerLeagueAndMedals(currentPlayer.beginnersLeague, currentPlayer.leagueId, KHJJFPPACBP.PELILBMKGHE(AIJKOENIJFL["Medals"]), KHJJFPPACBP.PELILBMKGHE(AIJKOENIJFL["MedalsBalance"]), currentPlayer.remainingMatches);
	}

	private void BHJBMAFJDFI()
	{
		Debug.Log("Beanstalk: Update squad finished");
	}

	[CompilerGenerated]
	private static void KGBBDBHKDJP()
	{
		GameLoginManager.Relog();
	}

	public IJEAJGCCHEF MEKIOHFCHIK(DatabaseAction MHLAAHNPMFG, string EENKJBCCPBG, List<Tuple<string, string>> GMDJHENPLHB)
	{
		BDAJADMCBLN bDAJADMCBLN = new BDAJADMCBLN();
		bDAJADMCBLN.MHLAAHNPMFG = MHLAAHNPMFG;
		bDAJADMCBLN.GMDJHENPLHB = GMDJHENPLHB;
		try
		{
			float num = (float)(EENKJBCCPBG.Length * 2) / 1024f;
			if (num > 85f)
			{
				Debug.LogWarning(string.Format("Too big response from server, Action: {0} Size: {1}kB", bDAJADMCBLN.MHLAAHNPMFG, num));
			}
			ALJKAAMHHLB.POPONJAMPDF("ServerResponseHandler.ServerRequestFinished databaseAction: " + bDAJADMCBLN.MHLAAHNPMFG);
			if (bDAJADMCBLN.MHLAAHNPMFG == DatabaseAction.GetConfigurations)
			{
				ALJKAAMHHLB.POPONJAMPDF("ServerResponseHandler.GetConfigurations START");
				GameConfigurationManager.instance.UpdateConfigurationsNew(EENKJBCCPBG);
				Singleton<BeanstalkServerManager>.instance.DataWasLoaded(bDAJADMCBLN.MHLAAHNPMFG);
				ALJKAAMHHLB.POPONJAMPDF("ServerResponseHandler.GetConfigurations DONE");
				AIJKOENIJFL = null;
				return IJEAJGCCHEF.Success;
			}
			AIJKOENIJFL = (Dictionary<string, object>)JsonConvert.DeserializeObject(EENKJBCCPBG, typeof(Dictionary<string, object>));
			int num2 = Convert.ToInt32(AIJKOENIJFL["Result"]);
			if (num2 > 10)
			{
				Debug.Log(string.Concat("Beanstalk: ", bDAJADMCBLN.MHLAAHNPMFG, " failure. Server response = ", EENKJBCCPBG));
				try
				{
					IJEAJGCCHEF iJEAJGCCHEF = (IJEAJGCCHEF)num2;
					if (iJEAJGCCHEF == IJEAJGCCHEF.ThroughputExceededException)
					{
						WarningDialog.ShowError(Localization.Localize("ID_WARNING_CLICKOKTORESEND"), Localization.Localize("ID_WARNING_SERVERTIMEDOUT"), 0f, bDAJADMCBLN.LJCDGJKCNEC, string.Empty);
					}
					else
					{
						HBJBOIMFDAM.GOEHBPFDMLM((IJEAJGCCHEF)num2, AIJKOENIJFL, bDAJADMCBLN.MHLAAHNPMFG, bDAJADMCBLN.GMDJHENPLHB);
						Singleton<BeanstalkServerManager>.instance.ErrorWasReceived(bDAJADMCBLN.MHLAAHNPMFG);
					}
				}
				catch (Exception kIJELCLONNC)
				{
					Debug.LogError("Client threw exception while trying to react to error response from the server.");
					Singleton<BeanstalkServerManager>.instance.SendErrorMessage(kIJELCLONNC, bDAJADMCBLN.MHLAAHNPMFG, EENKJBCCPBG, Singleton<BeanstalkServerManager>.instance.postParameters);
				}
				return (IJEAJGCCHEF)num2;
			}
			try
			{
				switch (bDAJADMCBLN.MHLAAHNPMFG)
				{
				default:
					switch (bDAJADMCBLN.MHLAAHNPMFG)
					{
					case DatabaseAction.AddFacebook:
						HBDOKCCEKPP((IJEAJGCCHEF)num2, Constants.rowIds.FacebookLoginReward, AccountType.Facebook, "Facebook");
						goto end_IL_01db;
					case DatabaseAction.PromotePlayer:
						JKNGDCBCEPK();
						goto end_IL_01db;
					case DatabaseAction.DemotePlayer:
						CGEBFOELAFD();
						goto end_IL_01db;
					case DatabaseAction.PromotePlayerToFounder:
						KMDNJGDDMFO();
						goto end_IL_01db;
					case DatabaseAction.InvitePlayerToSquad:
						LABBAJMFJOI();
						goto end_IL_01db;
					case DatabaseAction.GameEnded:
						goto IL_06f5;
					case DatabaseAction.GameStartedMaster:
					case DatabaseAction.GameStartedClient:
					case DatabaseAction.GameStartedCampaign:
					case DatabaseAction.GameStartedCoopMaster:
					case DatabaseAction.GameStartedCoopClient:
						NCAKLEOEDBO(bDAJADMCBLN.MHLAAHNPMFG);
						goto end_IL_01db;
					case DatabaseAction.RefillDogtags:
						LJBIDGKODLN();
						goto end_IL_01db;
					case DatabaseAction.GetSquads:
					case DatabaseAction.FindSuggestedSquads:
						NADNNCBNJAC();
						goto end_IL_01db;
					case DatabaseAction.UpdateSquadEmblem:
						EBOJHBJCGBG();
						goto end_IL_01db;
					}
					switch (bDAJADMCBLN.MHLAAHNPMFG)
					{
					case DatabaseAction.ExistFBAccount:
						EHEOPGGMPCA((IJEAJGCCHEF)num2);
						goto end_IL_01db;
					case DatabaseAction.RemoveOrUpdateGC:
						FLHMFBGNPDF();
						goto end_IL_01db;
					case DatabaseAction.SpecialOfferShowed:
						Singleton<OfferManager>.instance.ShowedSavedOnServer();
						goto end_IL_01db;
					case DatabaseAction.MaxAll:
						PHDPKOLHJEP();
						goto end_IL_01db;
					case DatabaseAction.DebugChangeAnticheat:
						GLHCLFKEPJO();
						goto end_IL_01db;
					case DatabaseAction.DebugSetHeroicPoints:
						FPODOIEHEEM();
						goto end_IL_01db;
					case DatabaseAction.DebugChangeLeague:
						KJDFGIBJCBK();
						goto end_IL_01db;
					case DatabaseAction.DebugChangeDivision:
						HNMDIPFAPBP();
						goto end_IL_01db;
					case DatabaseAction.TutorialCheckFBAccount:
						BBGJLNCOJMA();
						goto end_IL_01db;
					case DatabaseAction.TutorialCheckGPGSAccount:
						GAEHHDOBANP();
						goto end_IL_01db;
					case DatabaseAction.ExistGCAccount:
						DLOKBMHHLIM();
						goto end_IL_01db;
					case DatabaseAction.CheckDailyReward:
						Debug.Log("daily reward chacked");
						if (AIJKOENIJFL.ContainsKey("dailyRewardData") && Singleton<DailyRewardManager>.instance.DailyRewardDataLoaded((JToken)AIJKOENIJFL["dailyRewardData"]) && !GuiScreenSingle<DailyRewardMonthScreen>.instance.isShowed)
						{
							DailyRewardManager.MGANBPBIOBK lNAIDLKGCFN = Singleton<DailyRewardManager>.instance.LNAIDLKGCFN;
							int lIJBBLBLPLG = lNAIDLKGCFN.LIJBBLBLPLG + lNAIDLKGCFN.NHKKNKEAEOE * 100;
							Singleton<MessageManager>.instance.AddMessage(new JGJIKFCHKDH(lIJBBLBLPLG));
						}
						goto end_IL_01db;
					case DatabaseAction.ClaimDailyReward:
						Debug.Log("daily reward claimed");
						Singleton<DailyRewardManager>.instance.DailyRewardDataLoaded((JToken)AIJKOENIJFL["dailyRewardData"]);
						goto end_IL_01db;
					case DatabaseAction.DebugRenewRental:
						Debug.Log("rental data deleted, new rental after restart game (still need finished tutorial and level >= 4!!!!)");
						goto end_IL_01db;
					case DatabaseAction.SaveFuseConfigs:
						JJPKFIEBPNK(bDAJADMCBLN.MHLAAHNPMFG);
						goto end_IL_01db;
					}
					switch (bDAJADMCBLN.MHLAAHNPMFG)
					{
					case DatabaseAction.TutorialEnded:
						goto IL_06f5;
					case DatabaseAction.GetMissionLeaderboards:
						KBBIOFPIJFI();
						goto end_IL_01db;
					case DatabaseAction.SkipAssignment:
						GGNOAHAHGOL();
						goto end_IL_01db;
					case DatabaseAction.JoinSquadEvent:
						HLFGEJLHJKE();
						goto end_IL_01db;
					case DatabaseAction.BuyVip:
						GFGIJJMCPLO();
						goto end_IL_01db;
					case DatabaseAction.GetPlayerLeaguesDivision:
						FPFMCNOBKBK();
						goto end_IL_01db;
					case DatabaseAction.GetSquadWarsDivision:
						CLBPOGIEGAN();
						goto end_IL_01db;
					case DatabaseAction.GetPlayersByExperience:
						FLOIMADDPPC();
						goto end_IL_01db;
					case DatabaseAction.CreateAccount:
						goto IL_08e1;
					case DatabaseAction.GameStartedTutorial:
						KHHFDNBFOHE();
						goto end_IL_01db;
					}
					switch (bDAJADMCBLN.MHLAAHNPMFG)
					{
					default:
						switch (bDAJADMCBLN.MHLAAHNPMFG)
						{
						default:
							switch (bDAJADMCBLN.MHLAAHNPMFG)
							{
							default:
								switch (bDAJADMCBLN.MHLAAHNPMFG)
								{
								default:
									switch (bDAJADMCBLN.MHLAAHNPMFG)
									{
									default:
										if (bDAJADMCBLN.MHLAAHNPMFG != DatabaseAction.IgnoreMessage)
										{
											if (bDAJADMCBLN.MHLAAHNPMFG != DatabaseAction.UpdateDeviceToken)
											{
												switch (bDAJADMCBLN.MHLAAHNPMFG)
												{
												default:
													if (bDAJADMCBLN.MHLAAHNPMFG == DatabaseAction.CraftAndClaimCard)
													{
														break;
													}
													if (bDAJADMCBLN.MHLAAHNPMFG != DatabaseAction.OnSubscriptionExpired)
													{
														if (bDAJADMCBLN.MHLAAHNPMFG == DatabaseAction.AddVideoFeed)
														{
															MHEHGPLIFHF.LLCLNJKBGGM(AIJKOENIJFL);
														}
													}
													else
													{
														CLAOLIOKIPP();
													}
													goto end_IL_01db;
												case DatabaseAction.SendRequestBuffer:
													NHGGEGECGGD();
													goto end_IL_01db;
												case DatabaseAction.GetSquadsByExperience:
													MNCAECBJMDD();
													goto end_IL_01db;
												}
												break;
											}
											PHJNGHFAJHI();
										}
										else
										{
											NBIFOCKMOEG();
										}
										goto end_IL_01db;
									case DatabaseAction.LeaveSquad:
										GCGBPMPECDO();
										goto end_IL_01db;
									case DatabaseAction.GetSquadDetails:
										LEBLKGEOHCC();
										goto end_IL_01db;
									case DatabaseAction.GetAllSquadMembers:
										HPGJJDLEOCL();
										goto end_IL_01db;
									}
									break;
								case DatabaseAction.GetFriendsInfo:
									OCCMLAHEDBG();
									goto end_IL_01db;
								case DatabaseAction.SetPlayerStatus:
									HOCGNAKEHNB();
									goto end_IL_01db;
								case DatabaseAction.LoginToCustomAccount:
									NAKEIPOABBD();
									goto end_IL_01db;
								}
								break;
							case DatabaseAction.MessageSent:
								PGECMLHMMCK();
								goto end_IL_01db;
							case DatabaseAction.GetAllMessages:
								DGFHKNLOBDH();
								goto end_IL_01db;
							case DatabaseAction.AcceptChallenge:
								HNPNDJPNPCK();
								goto end_IL_01db;
							}
							break;
						case DatabaseAction.ProvokePlayer:
							NKEJHEDLBHB();
							goto end_IL_01db;
						case DatabaseAction.ClaimReward:
							FABILEDDNIM();
							goto end_IL_01db;
						case DatabaseAction.DebugAddLevel:
							GFBILJALKHL();
							goto end_IL_01db;
						case DatabaseAction.SearchPlayers:
							MAFHBBEKBJJ();
							goto end_IL_01db;
						}
						break;
					case DatabaseAction.GetPlayerData:
						EGPLNLMMADN();
						goto end_IL_01db;
					case DatabaseAction.CreateSquad:
						LDDIAJPFJOP();
						goto end_IL_01db;
					case DatabaseAction.JoinSquad:
						OKGFAFJANGG();
						goto end_IL_01db;
					case DatabaseAction.CheckUniqueSquadName:
						EBDNFFCCKEP();
						goto end_IL_01db;
					}
					goto case DatabaseAction.ClaimCraftedCard;
				case DatabaseAction.SendCrashReport:
					KBDCCLLIEIN();
					break;
				case DatabaseAction.GetNewBMOffer:
					OAMHANEBKIE();
					break;
				case DatabaseAction.AddGooglePlay:
					HBDOKCCEKPP((IJEAJGCCHEF)num2, Constants.rowIds.GooglePlayLoginReward, AccountType.GooglePlay, "GooglePlay");
					break;
				case DatabaseAction.Test:
					Debug.Log("On Test = " + AIJKOENIJFL["Test"]);
					break;
				case DatabaseAction.UpdateAnalytics:
				case DatabaseAction.CompleteStarterAssignments:
					Debug.Log("Action Finished: " + bDAJADMCBLN.MHLAAHNPMFG);
					break;
				case DatabaseAction.DebugChangeArenaLives:
				case DatabaseAction.DebugChangeArenaWins:
					Debug.LogError("ON DEBUG ARENA!");
					WarArena.instance.data = JsonConvert.DeserializeObject<WarArena.WarArenaData>(KHJJFPPACBP.BKFCLMMJNHK(AIJKOENIJFL["WarArenaData"], string.Empty));
					break;
				case DatabaseAction.InstantBattle:
					DKKLKHHLEOK();
					break;
				case DatabaseAction.BuyArenaHearth:
					GOGPNEEKGNK();
					break;
				case DatabaseAction.TakeArenaLife:
					ELDJABHIMEP();
					break;
				case DatabaseAction.GetScrapsReward:
					DFOBJMMDJPG();
					break;
				case DatabaseAction.BuyInApp:
					PCJEEBJCBAI(bDAJADMCBLN.GMDJHENPLHB);
					break;
				case DatabaseAction.AcceptSpecialOffer:
				case DatabaseAction.AcceptRentalOffer:
					IEPANBKNHIA();
					break;
				case DatabaseAction.ClaimAssignmentMegaReward:
					BHJOFNIHGEP();
					break;
				case DatabaseAction.DebugChangeLevel:
					PHDPKOLHJEP();
					break;
				case DatabaseAction.DeclineSquadJoinRequest:
					MFPFGNKFLAB(bDAJADMCBLN.GMDJHENPLHB);
					break;
				case DatabaseAction.BuyPack:
					CMLJJBCKEDG(bDAJADMCBLN.GMDJHENPLHB);
					break;
				case DatabaseAction.BuyLootboxes:
					IFAOHFKDHFA();
					break;
				case DatabaseAction.OnVIPExpired:
					NEBPIHAPLNK();
					break;
				case DatabaseAction.UpdateRegionPings:
					BGHANIMKJBP();
					break;
				case DatabaseAction.KickPlayer:
					FLGFIIFFNKB();
					break;
				case DatabaseAction.DepositCards:
					HNKAMNMHPKC();
					break;
				case DatabaseAction.CreateGcAccount:
					goto IL_08e1;
				case DatabaseAction.PayOneDogTag:
					ILMBENLPAJD();
					break;
				case DatabaseAction.ReadMessage:
					Debug.Log("Beanstalk: Message read");
					break;
				case DatabaseAction.PhotonIsFull:
					AAFFKBOMPBI();
					break;
				case DatabaseAction.UpdateSquad:
					BHJBMAFJDFI();
					break;
				case DatabaseAction.JoinSquadRequest:
					FONIFKONEBO();
					break;
				case DatabaseAction.DebugAddSquadLevel:
					HIAJFPBNAFN();
					break;
				case DatabaseAction.ChangePlayerName:
					HIKDINCJEPB();
					break;
				case DatabaseAction.GenerateSpecialOffer:
					FFOGKGLPMJG();
					break;
				case DatabaseAction.AddDebugGoodies:
					KOHGDBEDGOI();
					break;
				case DatabaseAction.NotifyPlayerToDeposit:
				case DatabaseAction.UpdateArmyPower:
					Debug.Log("Action Success: " + bDAJADMCBLN.MHLAAHNPMFG);
					break;
				case DatabaseAction.GetPlayerInfo:
					CPGGGLJEDPG();
					break;
				case DatabaseAction.SendPlayerReport:
					CCACILAMEAL();
					break;
				case DatabaseAction.ReportCheater:
					JABANANGFBL();
					break;
				case DatabaseAction.RestorePacks:
					EPBJGADPPMM();
					break;
				case DatabaseAction.ClaimCraftedCard:
					GDNAPODCNCI();
					break;
				case DatabaseAction.GetNewAssignments:
					PDANLGNEDEG();
					break;
				case DatabaseAction.GetNewDailyMissions:
					JPHKHHNNIOA();
					break;
				case DatabaseAction.SkipDailyAssignment:
					KGIHKMDPIOA();
					break;
				case DatabaseAction.SaveDailyMissions:
					DDIPKGOPCMK();
					break;
				case DatabaseAction.ChangeLanguage:
					KIKPAKPICDB();
					break;
				case DatabaseAction.GetFullSquadInfo:
					KPINHONNIFH();
					break;
				case DatabaseAction.InformSquadLeaderAboutEvent:
					LGBFFPMPEKL();
					break;
				case DatabaseAction.AcceptSquadJoinRequest:
					JHFEDHCMCKD();
					break;
				case DatabaseAction.AddVideoReward:
					AJEOKDDJHNC(false);
					break;
				case DatabaseAction.FinishPlayerLeague:
					INNPDDAJBPN();
					break;
				case DatabaseAction.WithdrawCard:
					MHGNHIMLAOE();
					break;
				case DatabaseAction.AddGameCenter:
					PDBKBNILFPD();
					break;
				case DatabaseAction.AddOneTimeReward:
					OOIMBPCOENI();
					break;
				case DatabaseAction.DebugChangeMedals:
					JHFMMNGADHN();
					break;
				case DatabaseAction.ElitesFeatureShown:
					JFNGDDOMPAE.LLCLNJKBGGM(AIJKOENIJFL);
					break;
				case DatabaseAction.ChatShownFirstTime:
					HDHIDLFDNPP();
					break;
				case DatabaseAction.WarArenaShown:
					FCIGAKGDAHO.LLCLNJKBGGM(AIJKOENIJFL);
					break;
				case DatabaseAction.RemoveFacebook:
				case DatabaseAction.RemoveGooglePlay:
					FODDBJKDPNJ();
					break;
				case DatabaseAction.UpdateSettings:
					DCEFNJILKJC();
					break;
				case DatabaseAction.CustomizationShown:
					EOEBHMNFPKL();
					break;
				case DatabaseAction.WarpathShownFirstTime:
					NJJAEKGLGEK();
					break;
				case DatabaseAction.GetArenaLeaderboards:
					GEKJKNLPJIL.LLCLNJKBGGM(AIJKOENIJFL);
					break;
				case DatabaseAction.BuyWarbucksRequest:
					MIFGKEHBPOK.LLCLNJKBGGM(AIJKOENIJFL);
					break;
				case DatabaseAction.EnterArena:
					DIENNAGJJOM.LLCLNJKBGGM(AIJKOENIJFL);
					break;
				case DatabaseAction.WarArenaEnded:
					JOPIPCDHOLF.LLCLNJKBGGM(AIJKOENIJFL);
					break;
				case DatabaseAction.DebugAddScraps:
					DNNFNLDALCO.LLCLNJKBGGM(AIJKOENIJFL);
					break;
				case DatabaseAction.CardpoolShown:
					CLDNFMEPHJK();
					break;
				case DatabaseAction.CraftingShown:
					HFFMMBBGLAK();
					break;
				case DatabaseAction.SendLog:
					CDDOAAGDJMJ();
					break;
				case DatabaseAction.CraftCard:
					{
						DGCHKNFPMEN();
						break;
					}
					IL_06f5:
					KPPNCJBMDPE(bDAJADMCBLN.MHLAAHNPMFG);
					break;
					IL_08e1:
					JLMICAJOHIK();
					break;
					end_IL_01db:
					break;
				}
			}
			catch (Exception kIJELCLONNC2)
			{
				Debug.LogError("Exception while Parsing");
				Singleton<BeanstalkServerManager>.instance.SendErrorMessage(kIJELCLONNC2, bDAJADMCBLN.MHLAAHNPMFG, EENKJBCCPBG, Singleton<BeanstalkServerManager>.instance.postParameters);
				if (bDAJADMCBLN.MHLAAHNPMFG == DatabaseAction.GetPlayerData)
				{
					HBJBOIMFDAM.EJMJIHBAPEL(kIJELCLONNC2, bDAJADMCBLN.MHLAAHNPMFG, bDAJADMCBLN.GMDJHENPLHB);
					return IJEAJGCCHEF.JsonFailure;
				}
			}
			try
			{
				Singleton<BeanstalkServerManager>.instance.DataWasLoaded(bDAJADMCBLN.MHLAAHNPMFG);
			}
			catch (Exception kIJELCLONNC3)
			{
				Debug.LogError("Error when client tried to work with server response!");
				Debug.Log("Player is allowed to continue.");
				Singleton<BeanstalkServerManager>.instance.SendErrorMessage(kIJELCLONNC3, bDAJADMCBLN.MHLAAHNPMFG, EENKJBCCPBG, Singleton<BeanstalkServerManager>.instance.postParameters);
			}
			AIJKOENIJFL = null;
			return (IJEAJGCCHEF)num2;
		}
		catch (Exception kIJELCLONNC4)
		{
			AIJKOENIJFL = null;
			Debug.Log(string.Concat("Beanstalk: ", bDAJADMCBLN.MHLAAHNPMFG, " JSON failure."));
			Singleton<BeanstalkServerManager>.instance.SendErrorMessage(kIJELCLONNC4, bDAJADMCBLN.MHLAAHNPMFG, EENKJBCCPBG, Singleton<BeanstalkServerManager>.instance.postParameters);
			HBJBOIMFDAM.EJMJIHBAPEL(kIJELCLONNC4, bDAJADMCBLN.MHLAAHNPMFG, bDAJADMCBLN.GMDJHENPLHB);
			return IJEAJGCCHEF.JsonFailure;
		}
	}

	private void PHDPKOLHJEP()
	{
		LoadingDialog.Hide();
		NCNNKGNJNOH((JToken)AIJKOENIJFL["PlayerData"], false);
		GuiScreenSingle<ArmyScreen>.instance.UpdateArmy();
		GuiScreenSingle<ArmyScreen>.instance.SendEquippedUnits();
	}

	public OGLEHLIPEFM(OIFCNEJNGJJ ODIAMBOIOOD)
	{
		FBBKCGLIIOB = ODIAMBOIOOD;
	}

	private void DHCHJLDNNKM()
	{
		RequestBufferManager.instance.Clear();
		Singleton<MessageManager>.instance.CBFLNGPBHKJ();
		Singleton<BeanstalkServerManager>.instance.KKOKNNOPBEF();
		if (AIJKOENIJFL.ContainsKey("isSuccess"))
		{
			AANECPGDMGM aANECPGDMGM = AANECPGDMGM.MAINIENLLIL((JToken)AIJKOENIJFL["ID_MINUTES"]);
			GameLoginManager.instance.OnPlayerDataLoadedSquadNameCheck(aANECPGDMGM.MHPNDNJDPGE);
			LEBLKGEOHCC();
		}
		else
		{
			GameLoginManager.instance.RemovePlayerFromSquad();
		}
		if (AIJKOENIJFL.ContainsKey("Scenes"))
		{
			Debug.LogError("ID_ZEROSECONDS");
			BattleRewardsManager.instance.ClearAllRewards();
		}
		if (AIJKOENIJFL.ContainsKey("SquadRank"))
		{
			HHFHFANGCEJ hHFHFANGCEJ = HHFHFANGCEJ.NBCDBIJKKNG((JToken)AIJKOENIJFL["StarterPackDays"]);
			if (hHFHFANGCEJ != null)
			{
				Singleton<MessageManager>.instance.AddMessage(hHFHFANGCEJ);
			}
		}
		int beginnersLeague = ((!AIJKOENIJFL.ContainsKey("SAIR")) ? 1 : GameLoginManager.currentPlayer.beginnersLeague);
		string league = ((!AIJKOENIJFL.ContainsKey("menu-camos-alien")) ? GameLoginManager.currentPlayer.leagueId : KHJJFPPACBP.BKFCLMMJNHK(AIJKOENIJFL["ID_GUI_CHAT_SQUAD_JOINED"], string.Empty));
		int globalMedals = ((!AIJKOENIJFL.ContainsKey("D2")) ? GameLoginManager.currentPlayer.skill : KHJJFPPACBP.PELILBMKGHE(AIJKOENIJFL["BUDDY_CARD_BOT"], 1));
		int leagueMedals = ((!AIJKOENIJFL.ContainsKey("Area")) ? GameLoginManager.currentPlayer.medalsBalance : KHJJFPPACBP.PELILBMKGHE(AIJKOENIJFL["Generate army 3"], 1));
		int remainingMatches = ((!AIJKOENIJFL.ContainsKey("weapons")) ? ((int)(float)Singleton<GameVariables>.instance.OPDHANHDJDC().GetRow(Constants.rowIds.ArmoredVehicleShotCoeficient).FLOATVALUE) : KHJJFPPACBP.PELILBMKGHE(AIJKOENIJFL["SquadEventProgress"]));
		GameLoginManager.instance.UpdatePlayerLeagueAndMedals(beginnersLeague, league, globalMedals, leagueMedals, remainingMatches);
		if (AIJKOENIJFL.ContainsKey("EventDefinition"))
		{
			FBBKCGLIIOB.MJCAGDEHKIH(KHJJFPPACBP.PELILBMKGHE(AIJKOENIJFL["Bad Player Visuals!"]));
		}
		Singleton<ServerResultsCache>.instance.isSquadWarsProcessing = AIJKOENIJFL.ContainsKey("FJDACAACLLI");
		Singleton<ServerResultsCache>.instance.isPlayerLeagueProcessing = AIJKOENIJFL.ContainsKey("There is no unit selected as tutorial unit!!!!!!");
		if (AIJKOENIJFL.ContainsKey("iconParent"))
		{
			string text = KHJJFPPACBP.BKFCLMMJNHK(AIJKOENIJFL[" "], string.Empty);
			if (text != PushNotificationManager.instance.data.deviceToken)
			{
				Debug.LogWarning("S");
				if (PushNotificationManager.instance.hasValidDeviceToken() || PushNotificationManager.instance.ArePushNotificationsEnabledOnDevice())
				{
					Debug.Log("ID_CONFIRM_PURCHASEFAILED" + GameLoginManager.currentPlayer.deviceToken);
					PushNotificationManager.instance.EnablePushNotifications(GameLoginManager.currentPlayer.deviceToken);
				}
			}
			else
			{
				Debug.LogWarning("BattleRewards");
			}
		}
		else if (PushNotificationManager.instance.hasValidDeviceToken() || PushNotificationManager.instance.ArePushNotificationsEnabledOnDevice())
		{
			Debug.Log("S" + GameLoginManager.currentPlayer.deviceToken);
			PushNotificationManager.instance.EnablePushNotifications(GameLoginManager.currentPlayer.deviceToken);
		}
		if (AIJKOENIJFL.ContainsKey("ID_GUI_SILVER"))
		{
			FBBKCGLIIOB.HFLJOLLEMII(KHJJFPPACBP.PELILBMKGHE(AIJKOENIJFL["Event has ended! Download new Event"], 1));
			LeagueArcManager.instance.SetLeagueTimer(FBBKCGLIIOB.HKPLFMBAHCB());
			GuiScreenSingle<MainScreen>.instance.BEPFJDAJBJO.GGADAADPKHB.OKLOICHGJBE(FBBKCGLIIOB.PLINCCOCIDK());
		}
		FBBKCGLIIOB.AHFGFLONOEL(KHJJFPPACBP.PELILBMKGHE(AIJKOENIJFL["PNManager: Enable Push Notifications"], 1));
		NCNNKGNJNOH((JToken)AIJKOENIJFL["BuddyCard"], false);
		if (AIJKOENIJFL.ContainsKey("com.unity3d.player.UnityPlayer"))
		{
			string text2 = AIJKOENIJFL["thumbnailBig"].ToString();
			if (Singleton<DailyRewardManager>.instance.GIJDPEJGPBK((JToken)AIJKOENIJFL["-{0}-{1}"]) && !GuiScreenSingle<DailyRewardMonthScreen>.instance.NPFFMLLLDAF())
			{
				DailyRewardManager.MGANBPBIOBK lNAIDLKGCFN = Singleton<DailyRewardManager>.instance.LNAIDLKGCFN;
				Singleton<MessageManager>.instance.AddMessage(new JGJIKFCHKDH(lNAIDLKGCFN.LIJBBLBLPLG + lNAIDLKGCFN.NHKKNKEAEOE * -126), true);
			}
		}
		if (AIJKOENIJFL.ContainsKey("MIIBIjANBgkqhkiG9w0BAQEFAAOCAQ8AMIIBCgKCAQEAhOR82yQJKu6ymLcFyTQEFkgs7PfSVXPSWcLC1JtdbMTNUmNfoM0up/7/8nRGzquPkZKF0KwVzJZJepHRzRXJiZwhGgMvDNAjwilqKAWcVGbIZPbDBZCJWxqQDgs+Ma4Pr7cPV48tDSHFPzcDxGUvfjl+sOdb1GTBZLDr3XvzBwjOwrQ5wbiY7/YdZYiv0I3UfQzmxOL9a1XfzAI1M5TcAS4vE32dPRYTM72+pt+Vr2kPuY8rF9E5RcGBWLQHuyPg9vPBre2hJPAKWJUUKrLJmxwS+mS/yv/ROkpQgKslIRHzJBmuLaLwBJyU4ZR1UAYlnzafHj/CJv96Y+7TUiY/ZwIDAQAB"))
		{
			WarArena.instance.AGPLFGDABLN((JToken)AIJKOENIJFL["T"]);
		}
		else
		{
			Debug.LogError("trial");
		}
		if (AIJKOENIJFL.ContainsKey("ID_GUI_BEADVISED_CONNECTFB"))
		{
			string eDMMKNPFGKC = KHJJFPPACBP.BKFCLMMJNHK(AIJKOENIJFL["Start broadcasting"], string.Empty);
			EventAssignmentManager.FCNABDGJEOF().PNIPPPCIBMN(eDMMKNPFGKC);
		}
		else
		{
			Debug.Log("menu-weapon-mp5-elite");
		}
		if (AIJKOENIJFL.ContainsKey("ID_CARDPACKDETAILS_DESCRIPTION"))
		{
			VideoFeedManager.ELGLFHHBJHP().ONEEACNAGNJ((JToken)AIJKOENIJFL["CN"]);
		}
		else
		{
			Debug.LogError("Can not find asset {0}");
		}
		if (AIJKOENIJFL.ContainsKey("IsHitList"))
		{
			int num = KHJJFPPACBP.PELILBMKGHE(AIJKOENIJFL["ID_WARNING_NOTENOUGHTWARCARDS"], 1);
			Debug.Log("GameLauncher.LoadMainScene DONE" + num);
			Singleton<MessageManager>.instance.AddMessage(new HODMKPGAPAF(num, true), true);
			Singleton<EventTrackingManager>.instance.ArenaExpired(WarArena.instance.data.wins, WarArena.instance.data.lives, WarArena.instance.data.heartDialogShown);
			object[] array = new object[1];
			array[1] = WarArena.instance.data.lives;
			Debug.LogFormat("realShotProbability", array);
		}
		if (AIJKOENIJFL.ContainsKey("ID_CONFIRM_SQUADFULL"))
		{
			Debug.Log("203 AUTOSPAWN STARTED");
			Singleton<MessageManager>.instance.AddMessage(new NOIBBLPEDAG(WarArena.instance.FPLIPHCJGFO.INFLHPGMEOB));
		}
		if (AIJKOENIJFL.ContainsKey("Manual_Unit_Spawn"))
		{
			Debug.Log("WarFriendsは、重要なゲームデータをダウンロードするため、メディアストーレージへのアクセス許可が必要です。許可がないとゲームが機能できず、閉じてしまいます。再試行するか、WarFriendsをやめてください。");
			string iNFLHPGMEOB = WarArena.instance.FPLIPHCJGFO.INFLHPGMEOB;
			bool jHMJENBCOGE = WarArena.instance.PBGAHILNNAH();
			Singleton<MessageManager>.instance.AddMessage(new IFBNMHNJFPD(iNFLHPGMEOB, jHMJENBCOGE), true);
		}
		if (AIJKOENIJFL.ContainsKey("ID_GUI_EMBLEMUNLOCKED"))
		{
			int num2 = KHJJFPPACBP.PELILBMKGHE(AIJKOENIJFL["ID_TIER"], 1);
			int dHMHOEGPDAP = KHJJFPPACBP.PELILBMKGHE(AIJKOENIJFL["Bad player regiones, data= "], 1);
			string dailyGoldInAppId = Singleton<BeanstalkServerManager>.instance.NBJBKFEPJJC.GetDailyGoldInAppId();
			int getDailyGoldInAppDays = PlayerAnalytics.instance.data.getDailyGoldInAppDays;
			bool dLALMKLEIMK = KHJJFPPACBP.FOJOKBCNBCO(AIJKOENIJFL["Beanstalk: Squad Details is cached, returning ..."]);
			Singleton<MessageManager>.instance.AddMessage(new EKPKEMFBNLP(num2, dHMHOEGPDAP, dailyGoldInAppId, dLALMKLEIMK), true);
		}
		if (AIJKOENIJFL.ContainsKey("{0} {1}"))
		{
			Debug.Log("ID_JOINSQUADUNLOCKED");
			List<AssignmentsManager.DatabaseAssignment> assignments = AssignmentsManager.instance.data.assignments;
			for (int i = 1; i < assignments.Count; i += 0)
			{
				if (i < 7 && i >= assignments.Count - 1)
				{
					AssignmentsManager.DatabaseAssignment eFEIDBFDDBE = assignments[i];
					Singleton<EventTrackingManager>.instance.MINMHKPKOMN(eFEIDBFDDBE, AssignmentsManager.instance.data.issued, false);
				}
			}
			Singleton<EventTrackingManager>.instance.RegisterDailyVisit();
		}
		if (AIJKOENIJFL.ContainsKey("USD"))
		{
			string jAOIALFFMNI = KHJJFPPACBP.BKFCLMMJNHK(AIJKOENIJFL["Card_3_Played"], string.Empty);
			string fMLEGCOCCEM = KHJJFPPACBP.BKFCLMMJNHK(AIJKOENIJFL["ID_UNITTYPE2-HUD"], string.Empty);
			string aPGKPOOHGFK = "FuseBox Event DuplicateLootbox for {0}";
			if (AIJKOENIJFL.ContainsKey("Starting match against bot"))
			{
				aPGKPOOHGFK = KHJJFPPACBP.BKFCLMMJNHK(AIJKOENIJFL["AmmoPool"], string.Empty);
			}
			Singleton<MessageManager>.instance.AddMessage(new NGGINCOPKKJ(jAOIALFFMNI, fMLEGCOCCEM, aPGKPOOHGFK), true);
		}
		if (AIJKOENIJFL.ContainsKey("Add RARITY {0} warcard - {1}"))
		{
			string kJBPJOMHNKB = KHJJFPPACBP.BKFCLMMJNHK(AIJKOENIJFL["IsMatchMaking"], string.Empty);
			Singleton<MessageManager>.instance.AddMessage(new IHKHFKHENEJ(kJBPJOMHNKB));
		}
		if (AIJKOENIJFL.ContainsKey("{0} {1}/{2} {3}"))
		{
			JToken jToken = (JToken)AIJKOENIJFL["ID_UNLOCKEDATRANKX"];
			string text3 = KHJJFPPACBP.BKFCLMMJNHK(jToken["ID_CONFIRM_INAPP_VALIDATION"], string.Empty);
			string text4 = KHJJFPPACBP.BKFCLMMJNHK(jToken["ID_ARENARULES_SILVERWARCARDS"], string.Empty);
			DKHAOLDJLMK dKHAOLDJLMK = (DKHAOLDJLMK)KHJJFPPACBP.HNMDPGKPLNK(jToken["WINSTREAK FROM SERVER COUNT: {0} TIMESTAMP: {1}"]);
			bool jIFJOMPDNPN = true;
			string iEFGICLEKEE = jToken["ID_WARSHOP_MEMBERSHIP"].ToString();
			object[] array2 = new object[4];
			array2[0] = "#AccoutCheck# Account exist check result NOT contain result message";
			array2[0] = text3;
			array2[5] = "^\\d*-\\d*$";
			array2[7] = text4;
			array2[5] = "N";
			array2[7] = dKHAOLDJLMK;
			Debug.LogError(string.Concat(array2));
			Singleton<MessageManager>.instance.AddMessage(new EJOOEEEHKJM(text3, text4, dKHAOLDJLMK, jIFJOMPDNPN, iEFGICLEKEE));
		}
		if (AIJKOENIJFL.ContainsKey("Finished") && !MFADLJHJNAJ)
		{
			Debug.Log("OBJECT: {0}\nERROR: {1}\nSTACKTRACE: {2}");
			Singleton<GameController>.instance.battleId = KHJJFPPACBP.BKFCLMMJNHK(AIJKOENIJFL["PlayerGold"], string.Empty);
			Singleton<GameController>.instance.ContinueOrStartTutorial();
		}
		MFADLJHJNAJ = false;
		if (AIJKOENIJFL.ContainsKey("ClientPrice"))
		{
			Singleton<EventTrackingManager>.instance.fuseboxxService.DDJHJFKOLGM(AIJKOENIJFL["GameReward"] as string);
		}
		if (AIJKOENIJFL.ContainsKey("Google2u.DBUpgradeSlotsShotgunner"))
		{
			Singleton<OfferManager>.instance.UpdateSpecialPackFromServer((JToken)AIJKOENIJFL["Found starting gold currency = "], true);
		}
		Singleton<OfferManager>.instance.UpdateFromServer((!AIJKOENIJFL.ContainsKey("ServerResponseHandler.GetConfigurations DONE")) ? null : ((JToken)AIJKOENIJFL["IsPaid"]), true);
		GameLoginManager.instance.changeGCAfterTutorialInProgress = false;
		if (AIJKOENIJFL.ContainsKey("ID_STAT_LOSSES"))
		{
			JToken jToken2 = (JToken)AIJKOENIJFL["#PETER# Weapon Screen - RIGHT BUTTON - weapon state: LOCKED\t\tbutton type: LEVEL UP"];
			bool dNFOLCJEEDP = true;
			bool kNIBODJCBCE = false;
			if (jToken2["Downloading assetBundle {0} failed with error: {1}, depth: {2}"] != null)
			{
				Debug.Log("SquadMembers" + jToken2["ABOUT TO SHOW WELCOME BACK SOLDIER REWARDS, packId = "].ToString());
				dNFOLCJEEDP = KHJJFPPACBP.HNMDPGKPLNK(jToken2["Pack: Gold Cards "]) == 1;
			}
			if (jToken2[" |"] != null)
			{
				Debug.Log("Found starting gold currency = " + jToken2["ID_ALIEN"].ToString());
				kNIBODJCBCE = KHJJFPPACBP.FOJOKBCNBCO(jToken2[" iconName:"].ToString());
			}
			Singleton<EventTrackingManager>.instance.ALEEKCLMJLA(dNFOLCJEEDP, kNIBODJCBCE, false);
		}
	}

	private void AJEOKDDJHNC(bool ADKPMIIOMJC)
	{
		Debug.Log("BS: On add video reward success!");
		if (AIJKOENIJFL.ContainsKey("CardsInCardPack"))
		{
			Debug.Log("REWARD CARDPACK: " + AIJKOENIJFL["CardsInCardPack"]);
			JArray jArray = (JArray)AIJKOENIJFL["CardsInCardPack"];
			NGNPIOOAHEH iGOHEBEDMFH = ((!AIJKOENIJFL.ContainsKey("IsGold")) ? NGNPIOOAHEH.Silver : NGNPIOOAHEH.Gold);
			Card[] array = new Card[jArray.Count];
			int num = 0;
			foreach (JToken item in jArray)
			{
				string cardId = item.ToObject<string>();
				array[num] = CardManager.instance.GetCardInstance(cardId);
				num++;
				CardManager.instance.AddCard(cardId);
			}
			Singleton<MessageManager>.instance.AddMessage(new AGPANDBMDLC(IHFDGLMHHBE.CardPack, iGOHEBEDMFH, array));
		}
		if (AIJKOENIJFL.ContainsKey("AddedCards"))
		{
			Debug.Log("REWARD CARD: " + AIJKOENIJFL["AddedCards"]);
			JArray jArray2 = (JArray)AIJKOENIJFL["AddedCards"];
			JToken cEKHIJECPNP = null;
			foreach (JToken item2 in jArray2)
			{
				cEKHIJECPNP = item2;
				CardManager.instance.AddCard(item2.ToObject<string>());
			}
			GuiScreenSingle<CardMenuScreen>.instance.UpdateHeaderAndCards();
			Singleton<MessageManager>.instance.AddMessage(new AGPANDBMDLC(IHFDGLMHHBE.WarCard, cEKHIJECPNP));
		}
		if (AIJKOENIJFL.ContainsKey("DogTagSeconds") && AIJKOENIJFL.ContainsKey("DogTagLastUpdate"))
		{
			int jJBHBKCGLGK = KHJJFPPACBP.PELILBMKGHE(AIJKOENIJFL["DogTagSeconds"]);
			int bBPAMDDFNDM = KHJJFPPACBP.PELILBMKGHE(AIJKOENIJFL["DogTagLastUpdate"]);
			Singleton<DogTagManager>.instance.CAHCIHHBALK(jJBHBKCGLGK, bBPAMDDFNDM);
			Singleton<MessageManager>.instance.AddMessage(new AGPANDBMDLC(IHFDGLMHHBE.Dogtag));
			Singleton<EventTrackingManager>.instance.DDIEAJKJMFL(KKFOLKGHOJE.WatchAdDogTag);
		}
		if (AIJKOENIJFL.ContainsKey("Tickets"))
		{
			long num2 = KHJJFPPACBP.OOAIMCEBPOK(AIJKOENIJFL["Tickets"], 0L);
			Singleton<MessageManager>.instance.AddMessage(new AGPANDBMDLC(IHFDGLMHHBE.Tickets, num2));
			Singleton<EventTrackingManager>.instance.TicketsGained((!ADKPMIIOMJC) ? "GoldenSuitcase" : "MegaReward", (int)num2);
			Singleton<Wallet>.instance.AddTickets(num2);
		}
		if (AIJKOENIJFL.ContainsKey("Scraps"))
		{
			long num3 = KHJJFPPACBP.OOAIMCEBPOK(AIJKOENIJFL["Scraps"], 0L);
			Singleton<MessageManager>.instance.AddMessage(new AGPANDBMDLC(IHFDGLMHHBE.Scraps, num3));
			Singleton<EventTrackingManager>.instance.ScrapsGained((!ADKPMIIOMJC) ? "GoldenSuitcase" : "MegaReward", (int)num3);
			Singleton<Wallet>.instance.AddScraps(num3);
		}
		if (AIJKOENIJFL.ContainsKey("WarBucks"))
		{
			long iEALLELGOBM = KHJJFPPACBP.OOAIMCEBPOK(AIJKOENIJFL["WarBucks"], 0L);
			Singleton<MessageManager>.instance.AddMessage(new AGPANDBMDLC(IHFDGLMHHBE.Warbucks, iEALLELGOBM));
			Singleton<Wallet>.instance.NFLMMKJBKEJ(iEALLELGOBM);
		}
		if (AIJKOENIJFL.ContainsKey("Gold"))
		{
			long num4 = KHJJFPPACBP.OOAIMCEBPOK(AIJKOENIJFL["Gold"], 0L);
			Singleton<MessageManager>.instance.AddMessage(new AGPANDBMDLC(IHFDGLMHHBE.Gold, num4));
			Singleton<Wallet>.instance.COLJGNLBEII(num4);
		}
		if (AIJKOENIJFL.ContainsKey("addedVIP"))
		{
			long iEALLELGOBM2 = KHJJFPPACBP.OOAIMCEBPOK(AIJKOENIJFL["addedVIP"], 0L);
			Singleton<MessageManager>.instance.AddMessage(new AGPANDBMDLC(IHFDGLMHHBE.VIP, iEALLELGOBM2));
			Singleton<VipManager>.instance.vipExpiration = KHJJFPPACBP.PELILBMKGHE(AIJKOENIJFL["Vip"]);
			Singleton<VipManager>.instance.vipStart = KHJJFPPACBP.PELILBMKGHE(AIJKOENIJFL["VipStart"]);
			if (AIJKOENIJFL.ContainsKey("VipReward1"))
			{
				Debug.Log("response contain VipReward");
				string text = KHJJFPPACBP.BKFCLMMJNHK(AIJKOENIJFL["VipReward1"], string.Empty);
				string text2 = KHJJFPPACBP.BKFCLMMJNHK(AIJKOENIJFL["VipReward2"], string.Empty);
				string aPGKPOOHGFK = "a";
				if (AIJKOENIJFL.ContainsKey("VipRewardForDay"))
				{
					aPGKPOOHGFK = KHJJFPPACBP.BKFCLMMJNHK(AIJKOENIJFL["VipRewardForDay"], string.Empty);
				}
				Singleton<MessageManager>.instance.AddMessage(new NGGINCOPKKJ(text, text2, aPGKPOOHGFK));
				CardManager.instance.AddCard(text);
				CardManager.instance.AddCard(text2);
			}
		}
		if (AIJKOENIJFL.ContainsKey("addPowerbandTime"))
		{
			long kBJEOEEOEFG = KHJJFPPACBP.OOAIMCEBPOK(AIJKOENIJFL["addPowerbandTime"], 0L);
			string text3 = KHJJFPPACBP.BKFCLMMJNHK(AIJKOENIJFL["Id"], string.Empty);
			int expiresOn = KHJJFPPACBP.PELILBMKGHE(AIJKOENIJFL["ExpiresOn"]);
			PlayerVisual playerVisual = CamosManager.instance.GetPowerBand(text3);
			if (playerVisual == null)
			{
				playerVisual = CamosManager.instance.RandomPlayerVisual(3);
				Debug.LogErrorFormat("Server send power band reward id {0} which is null setting random {1}", text3, playerVisual.id);
			}
			Singleton<MessageManager>.instance.AddMessage(new AGPANDBMDLC(IHFDGLMHHBE.PowerBand, playerVisual, kBJEOEEOEFG));
			playerVisual.BMIEJNIEDOP();
			CamosManager.instance.data.visuals[text3].expiresOn = expiresOn;
			GuiScreenSingle<CamosScreen>.instance.EquipPlayerVisual(playerVisual);
		}
		if (AIJKOENIJFL.ContainsKey("NewVisuals"))
		{
			Dictionary<string, string> dictionary = JsonConvert.DeserializeObject<Dictionary<string, string>>(KHJJFPPACBP.BKFCLMMJNHK(AIJKOENIJFL["NewVisuals"], string.Empty));
			if (dictionary != null)
			{
				if (GuiScreenSingle<EndScreen>.instance.isShowed && GuiScreenSingle<EndScreen>.instance.isEndScreenLootboxAnimations)
				{
					GuiScreenSingle<EndScreen>.instance.videoRewardLootbox = CCNAEIGGMNK.JHDGAACJEGH(dictionary);
					if (GuiElementSingle<WaitingDialog>.instance.isFullyShowed)
					{
						WaitingDialog.Hide();
					}
				}
				else
				{
					Singleton<MessageManager>.instance.AddMessage(new AGPANDBMDLC(IHFDGLMHHBE.Lootboxes, CCNAEIGGMNK.JHDGAACJEGH(dictionary)));
				}
			}
			Debug.Log("Video ad reward - lootbox visuals List =  " + AIJKOENIJFL["NewVisuals"]);
		}
		if (AIJKOENIJFL.ContainsKey("videoAdRewardTimes"))
		{
			Singleton<EventTrackingManager>.instance.getAdlimits((JToken)AIJKOENIJFL["videoAdRewardTimes"]);
		}
	}

	private void PHJNGHFAJHI()
	{
		Debug.Log("Beanstalk: On Update device token");
	}

	private void FMBAIIPNDHI()
	{
		WaitingDialog.Hide();
	}

	private void HNFBGELNFIC(Dictionary<string, object> ADBLKIPEAMP)
	{
		if (ADBLKIPEAMP.ContainsKey("extraGold"))
		{
			long gNJFHBAKPAN = KHJJFPPACBP.OOAIMCEBPOK(ADBLKIPEAMP["extraGold"], 0L);
			Singleton<Wallet>.instance.COLJGNLBEII(gNJFHBAKPAN);
		}
		if (ADBLKIPEAMP.ContainsKey("extraWarBucks"))
		{
			long iEALLELGOBM = KHJJFPPACBP.OOAIMCEBPOK(ADBLKIPEAMP["extraWarBucks"], 0L);
			Singleton<Wallet>.instance.NFLMMKJBKEJ(iEALLELGOBM);
		}
		if (ADBLKIPEAMP.ContainsKey("extraTickets"))
		{
			long iEALLELGOBM2 = KHJJFPPACBP.OOAIMCEBPOK(ADBLKIPEAMP["extraTickets"], 0L);
			Singleton<Wallet>.instance.AddTickets(iEALLELGOBM2);
		}
		if (ADBLKIPEAMP.ContainsKey("extraScraps"))
		{
			long iEALLELGOBM3 = KHJJFPPACBP.OOAIMCEBPOK(ADBLKIPEAMP["extraScraps"], 0L);
			Singleton<Wallet>.instance.AddScraps(iEALLELGOBM3);
		}
		if (ADBLKIPEAMP.ContainsKey("extraDecal"))
		{
			JToken source = (JToken)ADBLKIPEAMP["extraDecal"];
			foreach (JToken item in source.AsJEnumerable())
			{
				if (item is JValue)
				{
					string text = item.ToString();
					PlayerVisual visual = CamosManager.instance.GetVisual(text);
					if (visual != null)
					{
						visual.BMIEJNIEDOP();
						continue;
					}
					Debug.LogFormat("#OFFERS# extra visual is null for ID {0}", text);
				}
			}
		}
		if (!ADBLKIPEAMP.ContainsKey("extraVip"))
		{
			return;
		}
		JToken jToken = (JToken)ADBLKIPEAMP["extraVip"];
		int vipStart = KHJJFPPACBP.HNMDPGKPLNK(jToken["vipStart"]);
		int vipExpiration = KHJJFPPACBP.HNMDPGKPLNK(jToken["vipExpire"]);
		Singleton<VipManager>.instance.vipStart = vipStart;
		Singleton<VipManager>.instance.vipExpiration = vipExpiration;
		if (jToken["VipReward1"] != null)
		{
			string text2 = KHJJFPPACBP.BKFCLMMJNHK(jToken["VipReward1"], string.Empty);
			string text3 = KHJJFPPACBP.BKFCLMMJNHK(jToken["VipReward2"], string.Empty);
			string aPGKPOOHGFK = "a";
			if (jToken["VipRewardForDay"] != null)
			{
				aPGKPOOHGFK = KHJJFPPACBP.BKFCLMMJNHK(jToken["VipRewardForDay"], string.Empty);
			}
			Singleton<MessageManager>.instance.AddMessage(new NGGINCOPKKJ(text2, text3, aPGKPOOHGFK));
			CardManager.instance.AddCard(text2);
			CardManager.instance.AddCard(text3);
		}
	}

	private void GBIJEMPBJGJ()
	{
		List<AANECPGDMGM> list = new List<AANECPGDMGM>();
		JArray jArray = (JArray)AIJKOENIJFL["StepId"];
		for (int i = 0; i < jArray.Count; i++)
		{
			list.Add(AANECPGDMGM.NAKCBLBJDHI(jArray[i]));
		}
		if (AIJKOENIJFL.ContainsKey("ID_UNIT"))
		{
			JArray jArray2 = (JArray)AIJKOENIJFL["ReconnectDialog Show"];
			List<AANECPGDMGM> list2 = new List<AANECPGDMGM>();
			for (int j = 0; j < jArray2.Count; j++)
			{
				list2.Add(AANECPGDMGM.BHPKKIHPAMG(jArray2[j]));
			}
			Singleton<ServerResultsCache>.instance.Insert<List<AANECPGDMGM>>("ID_VALUEPACK", list2, DateTime.Now.AddMinutes(293.0), DatabaseAction.DebugChangeMedals);
		}
		Singleton<ServerResultsCache>.instance.Insert<List<AANECPGDMGM>>("Skipping note with message ", list, DateTime.Now.AddMinutes(136.0), DatabaseAction.ActivateWeapon);
	}

	private void CLDNFMEPHJK()
	{
		Debug.Log("Card pool shown!!");
		PlayerAnalytics.instance.data.cardpoolShown = true;
		Singleton<NotificationManager>.instance.ClientCardpoolNotifications();
	}

	private static string JIMIKHFDEFC(JToken GDJGCNJEMIL, string IGKOKJFCCCI, bool BEINCBHAGKC)
	{
		DatabaseAction databaseAction = (DatabaseAction)KHJJFPPACBP.HNMDPGKPLNK(GDJGCNJEMIL["ActionId"]);
		IJEAJGCCHEF iJEAJGCCHEF = (IJEAJGCCHEF)KHJJFPPACBP.HNMDPGKPLNK(GDJGCNJEMIL["Result"]);
		switch (databaseAction)
		{
		case DatabaseAction.ClaimAssignment:
			switch (iJEAJGCCHEF)
			{
			case IJEAJGCCHEF.Success:
				Debug.Log("Claim Assignment success!");
				break;
			case IJEAJGCCHEF.AssignmentNotFound:
			case IJEAJGCCHEF.AssignmentIncorrectReward:
				Debug.LogError("ERROR CLAIM ASSIGNMENT - ASSIGNMENT NOT FOUND OR NOT COMPLETED");
				WarningDialog.ShowError(Localization.Localize("ID_WARNING_ERRORCLAIMASSIGNMENT_TEXT"), Localization.Localize("ID_WARNING_ERRORCLAIMASSIGNMENT"), 0f, null, string.Empty, true);
				AssignmentsManager.instance.LoadData(KHJJFPPACBP.BKFCLMMJNHK(GDJGCNJEMIL["AssignmentData"], string.Empty));
				Singleton<Wallet>.instance.GHPGMPNBJDB(KHJJFPPACBP.GKKLOFAGGLI(GDJGCNJEMIL["Gold"], 0L));
				break;
			}
			break;
		case DatabaseAction.ClaimStarterAssignment:
			switch (iJEAJGCCHEF)
			{
			case IJEAJGCCHEF.Success:
				Debug.Log("Claim Starter Assignment success!");
				if (GDJGCNJEMIL["Cards"] != null)
				{
					JArray jArray = (JArray)GDJGCNJEMIL["Cards"];
					Card[] array = new Card[jArray.Count];
					int num = 0;
					foreach (JToken item in jArray)
					{
						string cardId = KHJJFPPACBP.BKFCLMMJNHK(item, string.Empty);
						array[num] = CardManager.instance.GetCardInstance(cardId);
						num++;
						CardManager.instance.AddCard(cardId);
					}
					Singleton<MessageManager>.instance.AddMessage(new BIKOIGHBELB(array));
				}
				if (GDJGCNJEMIL["Warbucks"] != null)
				{
					Singleton<Wallet>.instance.NFLMMKJBKEJ(KHJJFPPACBP.GKKLOFAGGLI(GDJGCNJEMIL["Warbucks"], 0L));
				}
				if (GDJGCNJEMIL["Visual"] != null)
				{
					PlayerVisual visual = CamosManager.instance.GetVisual(KHJJFPPACBP.BKFCLMMJNHK(GDJGCNJEMIL["Visual"], string.Empty));
					if (visual != null)
					{
						Debug.Log("ADDING VISUAL ON CLIENT " + GDJGCNJEMIL["Visual"]);
						visual.BMIEJNIEDOP();
					}
					else
					{
						Debug.LogError("VISUAL = NULL");
					}
				}
				if (GDJGCNJEMIL["PowerBandId"] != null && GDJGCNJEMIL["PowerBandExpiresOn"] != null)
				{
					PlayerVisual powerBand = CamosManager.instance.GetPowerBand(KHJJFPPACBP.BKFCLMMJNHK(GDJGCNJEMIL["PowerBandId"], string.Empty));
					if (powerBand != null)
					{
						Debug.Log("ADDING POWERBAND ON CLIENT " + GDJGCNJEMIL["PowerBandId"]);
						powerBand.BMIEJNIEDOP();
						powerBand.PIAKMCDMHKJ(KHJJFPPACBP.HNMDPGKPLNK(GDJGCNJEMIL["PowerBandExpiresOn"]));
						powerBand.FHPICBCCOAO();
					}
					else
					{
						Debug.LogError("POWER BAND = NULL");
					}
				}
				if (GDJGCNJEMIL["Weapon"] != null)
				{
					WeaponLevelsSetup weaponLevelsSetup = LevelManager.instance.Weapon(KHJJFPPACBP.BKFCLMMJNHK(GDJGCNJEMIL["Weapon"], string.Empty));
					if (weaponLevelsSetup != null)
					{
						Debug.Log("ADDING WEAPON ON CLIENT" + GDJGCNJEMIL["Weapon"]);
						weaponLevelsSetup.bought = true;
					}
					else
					{
						Debug.LogError("ADDED WEAPON = NULL");
					}
				}
				if (GDJGCNJEMIL["AssignmentData"] != null)
				{
					AssignmentsManager.instance.LoadData(KHJJFPPACBP.BKFCLMMJNHK(GDJGCNJEMIL["AssignmentData"], string.Empty));
					Debug.Log("Yay! New daily assignments!");
				}
				break;
			case IJEAJGCCHEF.IncorrentStarterAssignments:
			case IJEAJGCCHEF.IncorrectStarterAssignmentReward:
				Debug.LogError("ERROR CLAIM STARTER ASSIGNMENT - ASSIGNMENT NOT FOUND OR NOT COMPLETED " + iJEAJGCCHEF);
				WarningDialog.ShowError(Localization.Localize("ID_WARNING_ERRORCLAIMASSIGNMENT_TEXT"), Localization.Localize("ID_WARNING_ERRORCLAIMASSIGNMENT"), 0f, null, string.Empty, true);
				StarterAssignmentsManager.instance.LoadData(KHJJFPPACBP.BKFCLMMJNHK(GDJGCNJEMIL["StarterAssignmentsData"], string.Empty));
				Singleton<Wallet>.instance.GHPGMPNBJDB(KHJJFPPACBP.GKKLOFAGGLI(GDJGCNJEMIL["Gold"], 0L));
				Singleton<Wallet>.instance.PLLPIAOOFFE(KHJJFPPACBP.GKKLOFAGGLI(GDJGCNJEMIL["WarBucks"], 0L));
				break;
			}
			break;
		case DatabaseAction.BuyCardPack:
			switch (iJEAJGCCHEF)
			{
			case IJEAJGCCHEF.Success:
				Debug.Log(string.Concat("Action ", databaseAction, " OK!"));
				break;
			case IJEAJGCCHEF.NotEnoughWarbucks:
			case IJEAJGCCHEF.CardPackNotFound:
				CardManager.instance.LoadData(GDJGCNJEMIL["CardManagerData"]);
				Singleton<Wallet>.instance.EHKKAOLJMCF(KHJJFPPACBP.GKKLOFAGGLI(GDJGCNJEMIL["Gold"], 0L), KHJJFPPACBP.GKKLOFAGGLI(GDJGCNJEMIL["WarBucks"], 0L));
				Debug.Log(string.Concat("Action ", databaseAction, " NOT OK!"));
				IGKOKJFCCCI = string.Concat(IGKOKJFCCCI, databaseAction, " (not enough warbucks), ");
				break;
			case IJEAJGCCHEF.NoDiscountFound:
				Debug.Log(string.Concat("Action ", databaseAction, " NOT OK!\t\t\t\t\t\t", iJEAJGCCHEF));
				CardManager.instance.LoadData(GDJGCNJEMIL["CardManagerData"]);
				Singleton<Wallet>.instance.EHKKAOLJMCF(KHJJFPPACBP.GKKLOFAGGLI(GDJGCNJEMIL["Gold"], 0L), KHJJFPPACBP.GKKLOFAGGLI(GDJGCNJEMIL["WarBucks"], 0L));
				Singleton<OfferManager>.instance.UpdateFromServer(GDJGCNJEMIL["SpecialOffers"]);
				WarningDialog.ShowError(Localization.Localize("ID_WARNING_OFFEREXPIRED_TEXT"), Localization.Localize("ID_WARNING_OFFEREXPIRED"), 0f, null, string.Empty);
				Singleton<BeanstalkServerManager>.instance.ErrorWasReceived(databaseAction);
				break;
			}
			break;
		case DatabaseAction.BuyWeaponUpgrade:
		case DatabaseAction.InstantWeaponUpgrade:
		case DatabaseAction.ActivateWeaponUpgrade:
		case DatabaseAction.BuyWeapon:
		case DatabaseAction.WeaponWasShown:
		case DatabaseAction.InstantBuyWeapon:
		case DatabaseAction.ActivateWeapon:
			switch (iJEAJGCCHEF)
			{
			case IJEAJGCCHEF.Success:
				Debug.Log(string.Concat("Action ", databaseAction, " OK!"));
				if (GDJGCNJEMIL["DeliveryTime"] != null && BEINCBHAGKC)
				{
					Debug.Log("Setting weapon delivery");
					LevelManager.instance.SetWeaponDeliveryTime(GDJGCNJEMIL["DeliveryTime"]);
				}
				break;
			case IJEAJGCCHEF.OfferNotFoundBM:
				Debug.Log("#DOMINIK# doesnt exists");
				WarningDialog.ShowError(Localization.Localize("ID_WARNING_BLACKMARKETDOESNTEXIST"), Localization.Localize("ID_WARNING_BLACKMARKETERROR"), 0f, delegate
				{
					GameLoginManager.Relog();
				}, string.Empty);
				break;
			case IJEAJGCCHEF.WeaponNotFoundBM:
				Debug.Log("#DOMINIK# weapon not found");
				WarningDialog.ShowError(Localization.Localize("ID_WARNING_BLACKMARKETNOTCONTAIN"), Localization.Localize("ID_WARNING_BLACKMARKETERROR"), 0f, delegate
				{
					GameLoginManager.Relog();
				}, string.Empty);
				break;
			case IJEAJGCCHEF.OfferOutOfTimeBM:
				Debug.Log("#DOMINIK# out of time");
				WarningDialog.ShowError(Localization.Localize("ID_WARNING_BLACKMARKETTIMEOUT"), Localization.Localize("ID_WARNING_BLACKMARKETERROR"), 0f, delegate
				{
					GameLoginManager.Relog();
				}, string.Empty);
				break;
			case IJEAJGCCHEF.NotEnoughWarbucks:
			case IJEAJGCCHEF.NotEnoughLevel:
			case IJEAJGCCHEF.AlreadyMaximumUpgrade:
			case IJEAJGCCHEF.NotEnoughGold:
			case IJEAJGCCHEF.WrongIndexToActivate:
			case IJEAJGCCHEF.AlreadyUpgrading:
			case IJEAJGCCHEF.TooSoonToActivate:
			case IJEAJGCCHEF.WeaponNotBought:
			case IJEAJGCCHEF.PriceNotFound:
			case IJEAJGCCHEF.PriceDidntCorrespond:
			case IJEAJGCCHEF.NegativePriceFromClient:
			{
				Debug.Log(string.Concat("Action ", databaseAction, " NOT OK!\t\t\t\t\t\t", iJEAJGCCHEF));
				string text = IGKOKJFCCCI;
				IGKOKJFCCCI = string.Concat(text, databaseAction, " (", iJEAJGCCHEF, "), ");
				if (GDJGCNJEMIL["WarBucks"] != null)
				{
					Singleton<Wallet>.instance.PLLPIAOOFFE(KHJJFPPACBP.GKKLOFAGGLI(GDJGCNJEMIL["WarBucks"], 0L));
				}
				if (GDJGCNJEMIL["Gold"] != null)
				{
					Singleton<Wallet>.instance.GHPGMPNBJDB(KHJJFPPACBP.GKKLOFAGGLI(GDJGCNJEMIL["Gold"], 0L));
				}
				if (GDJGCNJEMIL["weaponDelivery"] != null)
				{
					LevelManager.instance.UpdateWeaponDelivery(GDJGCNJEMIL["weaponDelivery"]);
				}
				LevelManager.instance.UpdateWeapon(KHJJFPPACBP.BKFCLMMJNHK(GDJGCNJEMIL["LevelName"], string.Empty), GDJGCNJEMIL["Weapon"]);
				Singleton<BeanstalkServerManager>.instance.ErrorWasReceived(databaseAction);
				break;
			}
			case IJEAJGCCHEF.NoDiscountFound:
				Debug.Log(string.Concat("Action ", databaseAction, " NOT OK!\t\t\t\t\t\t", iJEAJGCCHEF));
				if (GDJGCNJEMIL["WarBucks"] != null)
				{
					Singleton<Wallet>.instance.PLLPIAOOFFE(KHJJFPPACBP.GKKLOFAGGLI(GDJGCNJEMIL["WarBucks"], 0L));
				}
				if (GDJGCNJEMIL["Gold"] != null)
				{
					Singleton<Wallet>.instance.GHPGMPNBJDB(KHJJFPPACBP.GKKLOFAGGLI(GDJGCNJEMIL["Gold"], 0L));
				}
				if (GDJGCNJEMIL["weaponDelivery"] != null)
				{
					LevelManager.instance.UpdateWeaponDelivery(GDJGCNJEMIL["weaponDelivery"]);
				}
				LevelManager.instance.UpdateWeapon(KHJJFPPACBP.BKFCLMMJNHK(GDJGCNJEMIL["LevelName"], string.Empty), GDJGCNJEMIL["Weapon"]);
				Singleton<OfferManager>.instance.UpdateFromServer(GDJGCNJEMIL["SpecialOffers"]);
				WarningDialog.ShowError(Localization.Localize("ID_WARNING_OFFEREXPIRED_TEXT"), Localization.Localize("ID_WARNING_OFFEREXPIRED"), 0f, null, string.Empty);
				Singleton<BeanstalkServerManager>.instance.ErrorWasReceived(databaseAction);
				break;
			}
			Singleton<NotificationManager>.instance.UpdateWeaponDelivery();
			break;
		case DatabaseAction.BuyUnitUpgrade:
		case DatabaseAction.InstantUnitUpgrade:
		case DatabaseAction.ActivateUnitUpgrade:
		case DatabaseAction.BuyUnit:
		case DatabaseAction.ArmyUnitWasShown:
		case DatabaseAction.InstantBuyUnit:
		case DatabaseAction.ActivateUnit:
			switch (iJEAJGCCHEF)
			{
			case IJEAJGCCHEF.Success:
				Debug.Log(string.Concat("Action ", databaseAction, " OK!"));
				if (GDJGCNJEMIL["DeliveryTime"] != null && BEINCBHAGKC)
				{
					Debug.Log("Setting unit delivery");
					LevelManager.instance.SetUnitDeliveryTime(GDJGCNJEMIL["DeliveryTime"]);
				}
				break;
			case IJEAJGCCHEF.NotEnoughWarbucks:
			case IJEAJGCCHEF.NotEnoughLevel:
			case IJEAJGCCHEF.AlreadyMaximumUpgrade:
			case IJEAJGCCHEF.NotEnoughGold:
			case IJEAJGCCHEF.WrongIndexToActivate:
			case IJEAJGCCHEF.AlreadyUpgrading:
			case IJEAJGCCHEF.TooSoonToActivate:
			case IJEAJGCCHEF.PriceNotFound:
			case IJEAJGCCHEF.PriceDidntCorrespond:
			case IJEAJGCCHEF.NegativePriceFromClient:
			{
				Debug.Log(string.Concat("Action ", databaseAction, " NOT OK!\t\t\t\t\t\t", iJEAJGCCHEF));
				string text = IGKOKJFCCCI;
				IGKOKJFCCCI = string.Concat(text, databaseAction, " (#", iJEAJGCCHEF, "), ");
				if (GDJGCNJEMIL["WarBucks"] != null)
				{
					Singleton<Wallet>.instance.PLLPIAOOFFE(KHJJFPPACBP.GKKLOFAGGLI(GDJGCNJEMIL["WarBucks"], 0L));
				}
				if (GDJGCNJEMIL["Gold"] != null)
				{
					Singleton<Wallet>.instance.GHPGMPNBJDB(KHJJFPPACBP.GKKLOFAGGLI(GDJGCNJEMIL["Gold"], 0L));
				}
				if (GDJGCNJEMIL["unitDelivery"] != null)
				{
					LevelManager.instance.UpdateUnitDelivery(GDJGCNJEMIL["unitDelivery"]);
				}
				LevelManager.instance.UpdateUnit(KHJJFPPACBP.BKFCLMMJNHK(GDJGCNJEMIL["LevelName"], string.Empty), GDJGCNJEMIL["Unit"]);
				Singleton<BeanstalkServerManager>.instance.ErrorWasReceived(databaseAction);
				break;
			}
			case IJEAJGCCHEF.NoDiscountFound:
				Debug.Log(string.Concat("Action ", databaseAction, " NOT OK!\t\t\t\t\t\t", iJEAJGCCHEF));
				if (GDJGCNJEMIL["WarBucks"] != null)
				{
					Singleton<Wallet>.instance.PLLPIAOOFFE(KHJJFPPACBP.GKKLOFAGGLI(GDJGCNJEMIL["WarBucks"], 0L));
				}
				if (GDJGCNJEMIL["Gold"] != null)
				{
					Singleton<Wallet>.instance.GHPGMPNBJDB(KHJJFPPACBP.GKKLOFAGGLI(GDJGCNJEMIL["Gold"], 0L));
				}
				if (GDJGCNJEMIL["unitDelivery"] != null)
				{
					LevelManager.instance.UpdateUnitDelivery(GDJGCNJEMIL["unitDelivery"]);
				}
				LevelManager.instance.UpdateUnit(KHJJFPPACBP.BKFCLMMJNHK(GDJGCNJEMIL["LevelName"], string.Empty), GDJGCNJEMIL["Unit"]);
				Singleton<OfferManager>.instance.UpdateFromServer(GDJGCNJEMIL["SpecialOffers"]);
				WarningDialog.ShowError(Localization.Localize("ID_WARNING_OFFEREXPIRED_TEXT"), Localization.Localize("ID_WARNING_OFFEREXPIRED"), 0f, null, string.Empty);
				Singleton<BeanstalkServerManager>.instance.ErrorWasReceived(databaseAction);
				break;
			}
			Singleton<NotificationManager>.instance.UpdateUnitDelivery();
			break;
		case DatabaseAction.BuyDecal:
			switch (iJEAJGCCHEF)
			{
			case IJEAJGCCHEF.Success:
				Debug.Log(string.Concat("Action ", databaseAction, " OK!"));
				CamosManager.instance.data.visuals[KHJJFPPACBP.BKFCLMMJNHK(GDJGCNJEMIL["DecalId"], string.Empty)].expiresOn = KHJJFPPACBP.HNMDPGKPLNK(GDJGCNJEMIL["ExpiresOn"]);
				break;
			case IJEAJGCCHEF.NotEnoughWarbucks:
			case IJEAJGCCHEF.NotEnoughLevel:
			case IJEAJGCCHEF.NotEnoughGold:
			case IJEAJGCCHEF.DecalOnlyForVip:
			{
				Debug.Log(string.Concat("Action ", databaseAction, " NOT OK!\t\t\t\t\t\t", iJEAJGCCHEF));
				string text = IGKOKJFCCCI;
				IGKOKJFCCCI = string.Concat(text, databaseAction, " (#", iJEAJGCCHEF, "), ");
				if (GDJGCNJEMIL["WarBucks"] != null)
				{
					Singleton<Wallet>.instance.PLLPIAOOFFE(KHJJFPPACBP.GKKLOFAGGLI(GDJGCNJEMIL["WarBucks"], 0L));
				}
				if (GDJGCNJEMIL["Gold"] != null)
				{
					Singleton<Wallet>.instance.GHPGMPNBJDB(KHJJFPPACBP.GKKLOFAGGLI(GDJGCNJEMIL["Gold"], 0L));
				}
				CamosManager.instance.LoadData(KHJJFPPACBP.BKFCLMMJNHK(GDJGCNJEMIL["DecalManagerData"], string.Empty));
				Singleton<BeanstalkServerManager>.instance.ErrorWasReceived(databaseAction);
				break;
			}
			case IJEAJGCCHEF.NoDiscountFound:
				Debug.Log(string.Concat("Action ", databaseAction, " NOT OK!\t\t\t\t\t\t", iJEAJGCCHEF));
				if (GDJGCNJEMIL["WarBucks"] != null)
				{
					Singleton<Wallet>.instance.PLLPIAOOFFE(KHJJFPPACBP.GKKLOFAGGLI(GDJGCNJEMIL["WarBucks"], 0L));
				}
				if (GDJGCNJEMIL["Gold"] != null)
				{
					Singleton<Wallet>.instance.GHPGMPNBJDB(KHJJFPPACBP.GKKLOFAGGLI(GDJGCNJEMIL["Gold"], 0L));
				}
				CamosManager.instance.LoadData(KHJJFPPACBP.BKFCLMMJNHK(GDJGCNJEMIL["DecalManagerData"], string.Empty));
				Singleton<OfferManager>.instance.UpdateFromServer(GDJGCNJEMIL["SpecialOffers"]);
				WarningDialog.ShowError(Localization.Localize("ID_WARNING_OFFEREXPIRED_TEXT"), Localization.Localize("ID_WARNING_OFFEREXPIRED"), 0f, null, string.Empty);
				Singleton<BeanstalkServerManager>.instance.ErrorWasReceived(databaseAction);
				break;
			}
			break;
		case DatabaseAction.VisualWasShown:
			if (iJEAJGCCHEF == IJEAJGCCHEF.Success)
			{
				Debug.Log(string.Concat("Action ", databaseAction, " OK!"));
			}
			break;
		case DatabaseAction.DecalWasShown:
		case DatabaseAction.EquipDecal:
			switch (iJEAJGCCHEF)
			{
			case IJEAJGCCHEF.Success:
				Debug.Log(string.Concat("Action ", databaseAction, " OK!"));
				if (GDJGCNJEMIL["DecalManagerData"] != null)
				{
					CamosManager.instance.LoadData(KHJJFPPACBP.BKFCLMMJNHK(GDJGCNJEMIL["DecalManagerData"], string.Empty));
				}
				break;
			case IJEAJGCCHEF.DecalNotBought:
			case IJEAJGCCHEF.DecalCategoryNotFound:
			{
				Debug.Log(string.Concat("Action ", databaseAction, " NOT OK!\t\t\t\t\t\t", iJEAJGCCHEF));
				string text = IGKOKJFCCCI;
				IGKOKJFCCCI = string.Concat(text, databaseAction, " (#", iJEAJGCCHEF, "), ");
				CamosManager.instance.LoadData(KHJJFPPACBP.BKFCLMMJNHK(GDJGCNJEMIL["DecalManagerData"], string.Empty));
				Singleton<BeanstalkServerManager>.instance.ErrorWasReceived(databaseAction);
				break;
			}
			}
			break;
		case DatabaseAction.UpgradeEliteSlot:
			switch (iJEAJGCCHEF)
			{
			case IJEAJGCCHEF.Success:
				Debug.Log(string.Concat("Action ", databaseAction, " OK!"));
				break;
			case IJEAJGCCHEF.WrongIndexToActivate:
			{
				Debug.Log(string.Concat("Action ", databaseAction, " NOT OK!\t\t\t\t\t\t", iJEAJGCCHEF));
				string text = IGKOKJFCCCI;
				IGKOKJFCCCI = string.Concat(text, databaseAction, " (#", (int)iJEAJGCCHEF, "), ");
				WarningDialog.ShowError(Localization.Localize("ID_WARNING_WRONGINDEXTOACTIVATEELITE"), Localization.Localize("ID_CONFIRM_ERROR"), 0f, delegate
				{
					GameLoginManager.Relog();
				}, string.Empty);
				break;
			}
			case IJEAJGCCHEF.NotEnoughWarbucks:
			{
				Debug.Log(string.Concat("Action ", databaseAction, " NOT OK!\t\t\t\t\t\t", iJEAJGCCHEF));
				string text = IGKOKJFCCCI;
				IGKOKJFCCCI = string.Concat(text, databaseAction, " (#", (int)iJEAJGCCHEF, "), ");
				WarningDialog.ShowError(Localization.Localize("ID_WARNING_NOTENOUGHWARBUCKSFORELITE"), Localization.Localize("ID_CONFIRM_ERROR"), 0f, delegate
				{
					GameLoginManager.Relog();
				}, string.Empty);
				break;
			}
			case IJEAJGCCHEF.NotEnoughParts:
			{
				Debug.Log(string.Concat("Action ", databaseAction, " NOT OK!\t\t\t\t\t\t", iJEAJGCCHEF));
				string text = IGKOKJFCCCI;
				IGKOKJFCCCI = string.Concat(text, databaseAction, " (#", (int)iJEAJGCCHEF, "), ");
				WarningDialog.ShowError(Localization.Localize("ID_WARNING_INCORRECTAMOUNTOFELITEPARTS"), Localization.Localize("ID_CONFIRM_ERROR"), 0f, delegate
				{
					GameLoginManager.Relog();
				}, string.Empty);
				break;
			}
			case IJEAJGCCHEF.IncorrectValuesOnClient:
			{
				Debug.Log(string.Concat("Action ", databaseAction, " NOT OK!\t\t\t\t\t\t", iJEAJGCCHEF));
				string text = IGKOKJFCCCI;
				IGKOKJFCCCI = string.Concat(text, databaseAction, " (#", (int)iJEAJGCCHEF, "), ");
				WarningDialog.ShowError(Localization.Localize("ID_WARNING_INCORRECTVALUESONCLIENT"), Localization.Localize("ID_CONFIRM_ERROR"), 0f, delegate
				{
					GameLoginManager.Relog();
				}, string.Empty);
				break;
			}
			}
			break;
		case DatabaseAction.ConvertPartsToScraps:
			switch (iJEAJGCCHEF)
			{
			case IJEAJGCCHEF.Success:
				Debug.Log(string.Concat("Action ", databaseAction, " OK!"));
				break;
			case IJEAJGCCHEF.EliteSlotLocked:
			{
				Debug.Log(string.Concat("Action ", databaseAction, " NOT OK!\t\t\t\t\t\t", iJEAJGCCHEF));
				string text = IGKOKJFCCCI;
				IGKOKJFCCCI = string.Concat(text, databaseAction, " (#", (int)iJEAJGCCHEF, "), ");
				WarningDialog.ShowError(Localization.Localize("ID_WARNING_ELITESLOTLOCKED"), Localization.Localize("ID_CONFIRM_ERROR"), 0f, delegate
				{
					GameLoginManager.Relog();
				}, string.Empty);
				break;
			}
			case IJEAJGCCHEF.IncorrectPartsAmount:
			{
				Debug.Log(string.Concat("Action ", databaseAction, " NOT OK!\t\t\t\t\t\t", iJEAJGCCHEF));
				string text = IGKOKJFCCCI;
				IGKOKJFCCCI = string.Concat(text, databaseAction, " (#", (int)iJEAJGCCHEF, "), ");
				WarningDialog.ShowError(Localization.Localize("ID_WARNING_INCORRECTELITEPARTSAMOUNT"), Localization.Localize("ID_CONFIRM_ERROR"), 0f, delegate
				{
					GameLoginManager.Relog();
				}, string.Empty);
				break;
			}
			}
			break;
		case DatabaseAction.ConvertScrapsToParts:
			switch (iJEAJGCCHEF)
			{
			case IJEAJGCCHEF.Success:
				Debug.Log(string.Concat("Action ", databaseAction, " OK!"));
				break;
			case IJEAJGCCHEF.NotEnoughScraps:
			{
				Debug.Log(string.Concat("Action ", databaseAction, " NOT OK!\t\t\t\t\t\t", iJEAJGCCHEF));
				string text = IGKOKJFCCCI;
				IGKOKJFCCCI = string.Concat(text, databaseAction, " (#", (int)iJEAJGCCHEF, "), ");
				WarningDialog.ShowError(Localization.Localize("ID_WARNING_NOTENOUGHSCRAPS"), Localization.Localize("ID_CONFIRM_ERROR"), 0f, delegate
				{
					GameLoginManager.Relog();
				}, string.Empty);
				break;
			}
			}
			break;
		case DatabaseAction.EquipWeapon:
			switch (iJEAJGCCHEF)
			{
			case IJEAJGCCHEF.Success:
				Debug.Log(string.Concat("Action ", databaseAction, " OK!"));
				break;
			case IJEAJGCCHEF.WeaponNotBought:
			{
				Debug.Log(string.Concat("Action ", databaseAction, " NOT OK!\t\t\t\t\t\t", iJEAJGCCHEF));
				string text = IGKOKJFCCCI;
				IGKOKJFCCCI = string.Concat(text, databaseAction, " (#", (int)iJEAJGCCHEF, "), ");
				LevelManager.instance.UpdateWeapon(KHJJFPPACBP.BKFCLMMJNHK(GDJGCNJEMIL["LevelName"], string.Empty), GDJGCNJEMIL["Weapon"]);
				PlayerInventory.instance.LoadData(KHJJFPPACBP.BKFCLMMJNHK(GDJGCNJEMIL["InventoryData"], string.Empty));
				Singleton<BeanstalkServerManager>.instance.ErrorWasReceived(databaseAction);
				break;
			}
			}
			break;
		case DatabaseAction.AcceptRentalOffer:
			switch (iJEAJGCCHEF)
			{
			case IJEAJGCCHEF.Success:
			{
				Debug.Log(string.Concat("Action ", databaseAction, " OK!"));
				JToken jToken = GDJGCNJEMIL["Rental"];
				string text2 = jToken["Id"].ToString();
				switch (jToken["Type"].ToObject<DKHAOLDJLMK>())
				{
				case DKHAOLDJLMK.ArmyUnit:
				{
					LevelManager.SavedArmySlots value2;
					if (LevelManager.instance.data.savedArmies.TryGetValue(text2, out value2))
					{
						value2.borrowed = true;
					}
					else
					{
						Debug.LogError(string.Format("rental for unexist unit: {0}", text2));
					}
					break;
				}
				case DKHAOLDJLMK.Weapon:
				{
					LevelManager.SavedWeaponSlots value;
					if (LevelManager.instance.data.savedWeapons.TryGetValue(text2, out value))
					{
						value.borrowed = true;
					}
					else
					{
						Debug.LogError(string.Format("rental for unexist weapon: {0}", text2));
					}
					break;
				}
				case DKHAOLDJLMK.PlayerVisual:
					if (CamosManager.instance.data.visuals.ContainsKey(text2))
					{
						CamosManager.instance.data.visuals[text2].borrowed = true;
					}
					else
					{
						Debug.LogError(string.Format("rental for unexist visual: {0}", text2));
					}
					break;
				}
				break;
			}
			case IJEAJGCCHEF.NoRentalFound:
			{
				Debug.Log(string.Concat("Action ", databaseAction, " NOT OK!\t\t\t\t\t\t", iJEAJGCCHEF));
				string text = IGKOKJFCCCI;
				IGKOKJFCCCI = string.Concat(text, databaseAction, " (#", (int)iJEAJGCCHEF, "), ");
				Singleton<BeanstalkServerManager>.instance.ErrorWasReceived(databaseAction);
				break;
			}
			}
			return IGKOKJFCCCI;
		case DatabaseAction.ClaimEventAssignment:
		case DatabaseAction.ClaimEventMilestone:
			if (iJEAJGCCHEF == IJEAJGCCHEF.Success)
			{
				Debug.Log("#VOJTA# action success " + databaseAction);
				break;
			}
			Debug.Log("#VOJTA# ERROR CLAIMING EVENT ASSIGNMENT / MILESTONE!!" + iJEAJGCCHEF.ToString() + ", " + databaseAction);
			WarningDialog.ShowError(Localization.Localize("ID_WARNING_ERRORCLAIMEVENT"), Localization.Localize("ID_CONFIRM_ERROR"), 0f, delegate
			{
				GameLoginManager.Relog();
			}, string.Empty);
			break;
		case DatabaseAction.ClaimAchievement:
			switch (iJEAJGCCHEF)
			{
			case IJEAJGCCHEF.AchievementAlreadyClaimed:
				Debug.Log("#VOJTA# ERROR ACHIEVEMENT ALREADY CLAIMED!!");
				WarningDialog.ShowError(Localization.Localize("ID_WARNING_ACHIEVEMENTALREADYCLAIMED"), Localization.Localize("ID_CONFIRM_ERROR"), 0f, delegate
				{
					GameLoginManager.Relog();
				}, string.Empty);
				break;
			case IJEAJGCCHEF.AchievementRewardNotFound:
				Debug.Log("#VOJTA# ERROR ACHIEVEMENT REWARD NOT FOUND!!");
				WarningDialog.ShowError(Localization.Localize("ID_WARNING_ACHIEVEMENTREWARDNOTFOUND"), Localization.Localize("ID_CONFIRM_ERROR"), 0f, delegate
				{
					GameLoginManager.Relog();
				}, string.Empty);
				break;
			}
			break;
		default:
			Debug.Log(string.Concat("Action ", databaseAction, ", result = ", iJEAJGCCHEF, " (", (int)iJEAJGCCHEF, ")"));
			break;
		case DatabaseAction.UpdateEquippedUnits:
			switch (iJEAJGCCHEF)
			{
			case IJEAJGCCHEF.Success:
				Debug.Log(string.Concat("Action ", databaseAction, " OK!"));
				GuiElementSingle<ChatGuiElement>.instance.GECCCEDFCEI.DatabaseResult(true);
				GuiScreenSingle<ArmyScreen>.instance.EquippedUnitsUpdate();
				break;
			case IJEAJGCCHEF.CantEquipUnit:
			{
				Debug.Log(string.Concat("Action ", databaseAction, " NOT OK! Load army data from DB"));
				Dictionary<string, object> dictionary = ((GDJGCNJEMIL["data"] == null) ? null : JsonConvert.DeserializeObject<Dictionary<string, object>>(KHJJFPPACBP.BKFCLMMJNHK(GDJGCNJEMIL["data"], string.Empty)));
				if (dictionary != null)
				{
					foreach (KeyValuePair<string, object> item2 in dictionary)
					{
						string key = item2.Key;
						LevelManager.instance.UpdateUnit(key, item2.Value.ToString());
						Debug.Log(string.Format("data saved in DB for unit {0} : {1}", key, item2.Value.ToString()));
					}
				}
				GuiElementSingle<ChatGuiElement>.instance.GECCCEDFCEI.DatabaseResult(false);
				GuiScreenSingle<ArmyScreen>.instance.EquippedUnitsUpdate();
				break;
			}
			}
			break;
		case DatabaseAction.IgnoreMessage:
			break;
		}
		if (iJEAJGCCHEF == IJEAJGCCHEF.Success)
		{
			PushNotificationManager.instance.ScheduleLocalNotifications(databaseAction);
		}
		else
		{
			PushNotificationManager.instance.RescheduleLocalNotificationsAfterError(databaseAction);
		}
		return IGKOKJFCCCI;
	}

	private void GOGPNEEKGNK()
	{
		Debug.LogError("OnBuyArenaHeart!");
		int num = 0;
		int num2 = 0;
		if (AIJKOENIJFL.ContainsKey("ArenaLives"))
		{
			WarArena.instance.UpdateLives(KHJJFPPACBP.PELILBMKGHE(AIJKOENIJFL["ArenaLives"]));
		}
		if (AIJKOENIJFL.ContainsKey("ticketsSpent"))
		{
			num = KHJJFPPACBP.PELILBMKGHE(AIJKOENIJFL["ticketsSpent"]);
			Singleton<Wallet>.instance.TicketsSpent(num);
		}
		if (AIJKOENIJFL.ContainsKey("goldSpent"))
		{
			num2 = KHJJFPPACBP.PELILBMKGHE(AIJKOENIJFL["goldSpent"]);
			Singleton<Wallet>.instance.OFHCEFPOCMI(num2);
		}
		Singleton<EventTrackingManager>.instance.BuyHeart(num, num2, WarArena.instance.data.wins);
	}

	private void ALFIIBIBPOD()
	{
		GameLoginManager.instance.AddPlayerToSquad(KHJJFPPACBP.BKFCLMMJNHK(AIJKOENIJFL["There are no rigid body components on the ragdoll "], string.Empty), (SquadRank)KHJJFPPACBP.PELILBMKGHE(AIJKOENIJFL["0"]));
		AANECPGDMGM aANECPGDMGM = AANECPGDMGM.CPJAMAJJDHL((JToken)AIJKOENIJFL["no account in DB, ask to create new one"]);
		Singleton<BeanstalkServerManager>.instance.SquadUpdateWasReceived(aANECPGDMGM);
		if (AIJKOENIJFL.ContainsKey(" Golds for squad event - completed tier "))
		{
			int num = KHJJFPPACBP.PELILBMKGHE(AIJKOENIJFL["N0"], 1);
			Singleton<Wallet>.instance.COLJGNLBEII(num);
			Singleton<MessageManager>.instance.AddMessage(new AGPANDBMDLC(IHFDGLMHHBE.Gold, num));
			string dBKEY = Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.VipGoldCardRewardChance).DBKEY;
			PlayerAnalytics.instance.AddOneTimeReward(dBKEY);
		}
		Singleton<ServerResultsCache>.instance.Insert<AANECPGDMGM>("Assignment: DestroyEnemyCratesAssignment Constructor" + aANECPGDMGM.MHPNDNJDPGE, aANECPGDMGM, DateTime.Now.AddMinutes(132.0), (DatabaseAction)103);
		if (AIJKOENIJFL.ContainsKey("registerCustomProfileGeolocation"))
		{
			PlayerAnalytics.instance.data.squadCreationsCount = KHJJFPPACBP.PELILBMKGHE(AIJKOENIJFL["SquadWarsId"], 1);
			Debug.LogError("Card_1_Played" + PlayerAnalytics.instance.data.squadCreationsCount);
		}
		if (AIJKOENIJFL.ContainsKey("game-label-won"))
		{
			FBBKCGLIIOB.CEGNAEEBLMF(KHJJFPPACBP.PELILBMKGHE(AIJKOENIJFL["Remove Google Play Data"], 1));
			Debug.Log("com/google/android/gms/common/ConnectionResult" + FBBKCGLIIOB.ODCBDBDFHMF());
			GuiScreenSingle<LeaguesScreen>.instance.JFGEOAAOOCE.ShowSquadWarEndTime(FBBKCGLIIOB.ODCBDBDFHMF());
			GuiScreenSingle<MainScreen>.instance.BEPFJDAJBJO.GGADAADPKHB.LFEONLOGHFI(FBBKCGLIIOB.PBABKLJIMJL());
		}
		if (AIJKOENIJFL.ContainsKey("x{0}"))
		{
			Singleton<ServerResultsCache>.instance.squadEventDefinition = PFPAMNODNPF.BHPKKIHPAMG((JToken)AIJKOENIJFL["{0} {1}"]);
		}
	}

	private void JJPKFIEBPNK(DatabaseAction IFGAGNBDKBE)
	{
		Debug.LogFormat("response for {0}", IFGAGNBDKBE);
		StringBuilder stringBuilder = new StringBuilder();
		foreach (KeyValuePair<string, object> item in AIJKOENIJFL)
		{
			stringBuilder.AppendFormat("{0}: {1}\n", item.Key, item.Value);
		}
		Debug.Log(stringBuilder.ToString());
	}

	private void KBBIOFPIJFI()
	{
		Debug.LogError("TODO remove - obsolete");
	}

	private void HFFMMBBGLAK()
	{
		Debug.Log("New Feature - Crafting shown!!");
		PlayerAnalytics.instance.data.craftingShown = true;
	}

	private void KMDNJGDDMFO()
	{
		GameLoginManager.instance.UpdatePlayerSquadRank(SquadRank.Veteran);
		if (AIJKOENIJFL.ContainsKey("PromotedPlayer"))
		{
			JToken jToken = (JToken)AIJKOENIJFL["PromotedPlayer"];
			DatabasePlayer databasePlayer = DatabasePlayer.CreateFromDatabase(jToken);
			if (jToken["PromotedPlayerId"] != null)
			{
				databasePlayer.id = KHJJFPPACBP.BKFCLMMJNHK("PromotedPlayerId", "S", jToken, string.Empty);
			}
			Singleton<ServerResultsCache>.instance.OBDFPOKLBJO(databasePlayer);
			GuiScreenSingle<SquadScreen>.instance.BBNLILBDOEC.ServerResponseCame(DatabaseAction.PromotePlayerToFounder, databasePlayer.id);
			GuiScreenSingle<SquadScreen>.instance.BBNLILBDOEC.ServerResponseCame(DatabaseAction.PromotePlayerToFounder, GameLoginManager.currentPlayer.id);
			Singleton<BeanstalkServerManager>.instance.DataWasLoaded(DatabaseAction.GetAllSquadMembers);
		}
	}

	private void HNMDIPFAPBP()
	{
		Debug.LogError("division changed!!!");
		if (AIJKOENIJFL.ContainsKey("Squad"))
		{
			LEBLKGEOHCC();
		}
	}

	private void BEPDOBOPCON()
	{
		PlayerAnalytics.instance.data.chatShown = false;
	}

	private void EHEOPGGMPCA(IJEAJGCCHEF FBFJNHLKJEC)
	{
		FIPCAFCHKHM fIPCAFCHKHM = new FIPCAFCHKHM();
		switch (FBFJNHLKJEC)
		{
		case IJEAJGCCHEF.Success:
			Debug.Log("no account in DB, ask to create new one");
			ConfirmDialog.IGCMBKLNIDB(Localization.Localize("ID_RELOG_TO_WRONG_FB_DIALOG_TITLE"), Localization.Localize("ID_RELOG_TO_WRONG_FB_DIALOG_TEXT1"), delegate(ConfirmDialog PHHJDIGEOPJ, bool NCMHGPNPEJM)
			{
				if (NCMHGPNPEJM)
				{
					Debug.Log("create new account and add FB");
					DialogManager.instance.HideAllDialogs();
					Singleton<DailyRewardManager>.instance.LNAIDLKGCFN = null;
					GameLoginManager.instance.DeletePlayerAccount();
					GameLoginManager.instance.CreateNewAccount(false);
				}
				else
				{
					Debug.Log("logout from FB");
					GameLoginManager.instance.LogoutFromFacebook(true);
					LoadingDialog.Hide();
				}
			}, Localization.Localize("ID_CREATE"), Localization.Localize("ID_LOGOUT"));
			break;
		case IJEAJGCCHEF.AccountAlreadyCreated:
		{
			fIPCAFCHKHM.IOFHDGKGFBG = KHJJFPPACBP.BKFCLMMJNHK(AIJKOENIJFL["FacebookId"], string.Empty);
			string hECDGAPMDHJ = KHJJFPPACBP.BKFCLMMJNHK(AIJKOENIJFL["FacebookName"], string.Empty);
			fIPCAFCHKHM.EGLIJCPPLIP = KHJJFPPACBP.BKFCLMMJNHK(AIJKOENIJFL["FacebookPassword"], string.Empty);
			int lPGGKFLFGGN = KHJJFPPACBP.PELILBMKGHE(AIJKOENIJFL["facebookLevel"]);
			int oCFJAJCKLDH = KHJJFPPACBP.PELILBMKGHE(AIJKOENIJFL["facebookMedals"]);
			LoadingDialog.Hide();
			GuiElementSingle<UserExistsDialog>.instance.ShowDialog(AccountType.Facebook, fIPCAFCHKHM.LJCDGJKCNEC, hECDGAPMDHJ, lPGGKFLFGGN, oCFJAJCKLDH, Localization.Localize("ID_RELOG_TO_WRONG_FB_DIALOG_TEXT2"));
			break;
		}
		}
	}

	private void BBGJLNCOJMA()
	{
		Debug.Log("#AccoutCheck# FB account checked and have response!");
		if (AIJKOENIJFL.ContainsKey("resultMessage"))
		{
			string text = AIJKOENIJFL["resultMessage"].ToString();
			Debug.Log("#AccoutCheck# OnCheckFacebookInTutorial: " + text);
			if (text == "OK")
			{
				Debug.Log("#AccoutCheck# account exist");
				if (AIJKOENIJFL.ContainsKey("FacebookId"))
				{
					GameLoginManager.instance.OnFacebookUserExistDuringTutorial(AIJKOENIJFL["FacebookId"].ToString());
				}
				else
				{
					Debug.LogError("#AccoutCheck# missing ID from server");
				}
			}
			else
			{
				GameLoginManager.instance.OnAccoutNotExistAfterLoginServices(AccountType.Facebook);
			}
		}
		else
		{
			Debug.LogError("#AccoutCheck# Account exist check result NOT contain result message");
		}
	}

	[CompilerGenerated]
	private static void HFHKLLHDPNO()
	{
		GameLoginManager.Relog();
	}

	private void HMKDKKJGOJI(List<Tuple<string, string>> GMDJHENPLHB)
	{
		LoadingDialog.Hide();
		WaitingDialog.CIJLKGLNIPO();
		NCNNKGNJNOH((JToken)AIJKOENIJFL["ID_WARNING_CONNECTIONERROR_TEXT"], false);
		SoundsManager.Instance.PlaySound((SoundsManager.KJGDNLHKPOG)(-39), 342f);
		if (AIJKOENIJFL.ContainsKey("()Z"))
		{
			string text = (string)AIJKOENIJFL["C0"];
			Tuple<float, string> tuple = Singleton<BeanstalkServerManager>.instance.BBIEEHPFDDL.LOIBJHKOPKP(text);
			PlayerAnalytics.instance.AddTransaction(-100, text, 0, 0, tuple.Value1);
			if (!AIJKOENIJFL.ContainsKey("Player_Had_To_Select_Grenade"))
			{
				ConfirmDialog.JDEDLDGMHBJ(Localization.Localize("withOfferId"), Localization.Localize("N"), 1621f);
				string text2 = Singleton<BeanstalkServerManager>.instance.BBIEEHPFDDL.LAAAEGEENMA(text);
				Singleton<EventTrackingManager>.instance.RegisterKochavaInApp(text, tuple.Value1, "BeanstalkServerManager.PlayerDataWasLoaded START", text2);
				Singleton<EventTrackingManager>.instance.RegisterFacebookInApp(text, tuple.Value1, "^\\D*", text2);
				Singleton<EventTrackingManager>.instance.RegisterAwsAnalyticsInApp(text, tuple.Value1, tuple.Value2, FKHJMMCANDJ(GMDJHENPLHB), text2);
				Singleton<EventTrackingManager>.instance.RegisterInApp(text, tuple.Value1, tuple.Value2, FKHJMMCANDJ(GMDJHENPLHB), text2);
				Singleton<EventTrackingManager>.instance.RegisterBuyPackEvent(text);
				string buyOfferEventLocation = Singleton<BeanstalkServerManager>.instance.GetBuyOfferEventLocation();
				if (!string.IsNullOrEmpty(buyOfferEventLocation))
				{
					Singleton<EventTrackingManager>.instance.DNKPEPIPDPH(buyOfferEventLocation, text);
				}
				int packGold = Singleton<GameVariables>.instance.GetPackGold(text);
				int num = Singleton<GameVariables>.instance.CPNAPNOFLHK(text);
				if (packGold > 0)
				{
					Singleton<EventTrackingManager>.instance.RegisterGoldIn(text, packGold);
				}
				if (num > 0)
				{
					Singleton<EventTrackingManager>.instance.RegisterWBIn(text, num);
				}
				DialogManager.instance.ShowRateAppDialog(false);
			}
		}
		if (AIJKOENIJFL.ContainsKey("ReportType"))
		{
			Debug.Log("country-malaysia");
			string text3 = KHJJFPPACBP.BKFCLMMJNHK(AIJKOENIJFL[" "], string.Empty);
			string text4 = KHJJFPPACBP.BKFCLMMJNHK(AIJKOENIJFL["eventStart"], string.Empty);
			string aPGKPOOHGFK = " ";
			if (AIJKOENIJFL.ContainsKey("Time"))
			{
				aPGKPOOHGFK = KHJJFPPACBP.BKFCLMMJNHK(AIJKOENIJFL["menu-assignments-bg"], string.Empty);
			}
			Singleton<MessageManager>.instance.AddMessage(new NGGINCOPKKJ(text3, text4, aPGKPOOHGFK), true);
			CardManager.instance.AddCard(text3);
			CardManager.instance.AddCard(text4);
		}
		HNFBGELNFIC(AIJKOENIJFL);
	}

	private void GAEHHDOBANP()
	{
		Debug.Log("#AccoutCheck# gpgs account checked and have response!");
		if (AIJKOENIJFL.ContainsKey("resultMessage"))
		{
			string text = AIJKOENIJFL["resultMessage"].ToString();
			Debug.Log("#AccoutCheck# OnCheckGpgsInTutorial: " + text);
			if (text == "OK")
			{
				Debug.Log("#AccoutCheck# account exist");
				if (AIJKOENIJFL.ContainsKey("GooglePlayId"))
				{
					GameLoginManager.instance.OnGpgsUserExistDuringTutorial(AIJKOENIJFL["GooglePlayId"].ToString());
				}
				else
				{
					Debug.LogError("#AccoutCheck# missing ID from server");
				}
			}
			else
			{
				GameLoginManager.instance.OnAccoutNotExistAfterLoginServices(AccountType.GooglePlay);
			}
		}
		else
		{
			Debug.LogError("#AccoutCheck# Account exist check result NOT contain result message");
		}
	}

	private void NBIFOCKMOEG()
	{
		Debug.Log("Message ignored!");
	}

	[CompilerGenerated]
	private static void DABLLBJDFAM()
	{
		GameLoginManager.Relog();
	}

	private void AMCIGCPKMMJ(List<Tuple<string, string>> GMDJHENPLHB)
	{
		Debug.Log("), ");
		WaitingDialog.DNNLAHACDCK();
		string text = KHJJFPPACBP.BKFCLMMJNHK(AIJKOENIJFL["ID_UNITELITEPERKFULLYUPGRADED"], string.Empty);
		string fJLBLLLEELD = "ID_GUI_BRONZE";
		if (AIJKOENIJFL.ContainsKey("joinedPlayer"))
		{
			long num = KHJJFPPACBP.OOAIMCEBPOK(AIJKOENIJFL["x"], 0L);
			Singleton<Wallet>.instance.JAPAPDDBEMD(num);
			fJLBLLLEELD = "a";
			if (AIJKOENIJFL.ContainsKey("()Lcom/google/android/gms/common/ConnectionResult;"))
			{
				Singleton<BeanstalkServerManager>.instance.NBJBKFEPJJC.AddDailyGoldBooster();
				string iNFLHPGMEOB = text + FBBKCGLIIOB.JNHAHCPINEB();
				Singleton<MessageManager>.instance.AddMessage(new EKPKEMFBNLP(num, 1, iNFLHPGMEOB, false));
			}
			Singleton<EventTrackingManager>.instance.RegisterGoldIn(text, (int)num);
		}
		if (AIJKOENIJFL.ContainsKey("[0-9.,]*"))
		{
			long num2 = KHJJFPPACBP.OOAIMCEBPOK(AIJKOENIJFL["Please add object to pool, before instanciing it ::: prefab name = "], 1L);
			Singleton<Wallet>.instance.CJDCGFNCHMM(num2);
			Singleton<EventTrackingManager>.instance.RegisterWBIn(text, (int)num2);
		}
		bool flag = false;
		if (AIJKOENIJFL.ContainsKey("Snapshots"))
		{
			flag = KHJJFPPACBP.FOJOKBCNBCO(AIJKOENIJFL["ID_CONFIRM_SQUADNAMETAKEN"]);
			if (AIJKOENIJFL.ContainsKey("ID_XSKIRMISHESRESULT"))
			{
				SubscriptionManager.instance.UpdateSubscription(KHJJFPPACBP.PELILBMKGHE(AIJKOENIJFL["ID_VISUALRARITY1"]));
			}
			if (AIJKOENIJFL.ContainsKey("Enemy could not be spawned"))
			{
				Singleton<DogTagManager>.instance.ELLJNHLPDNF = KHJJFPPACBP.PELILBMKGHE(AIJKOENIJFL["Player "], 1);
			}
			if (AIJKOENIJFL.ContainsKey("ID_AREYOUSUREYOUWANTTOCONVERTPARTS") && KHJJFPPACBP.FOJOKBCNBCO(AIJKOENIJFL["), "], true))
			{
				return;
			}
			Singleton<EventTrackingManager>.instance.ALEEKCLMJLA(flag, AIJKOENIJFL.ContainsKey("FuseSDK: Parsing error in _FriendsListError") && KHJJFPPACBP.PELILBMKGHE(AIJKOENIJFL["ID_BUDDYCARD"]) == 0, false);
		}
		HNFBGELNFIC(AIJKOENIJFL);
		Tuple<float, string> tuple = Singleton<BeanstalkServerManager>.instance.BBIEEHPFDDL.LOIBJHKOPKP(text);
		bool kCBGHGFELIA = PlayerAnalytics.instance.data.GetInappCount() == 1;
		Singleton<EventTrackingManager>.instance.RegisterInapp(text, kCBGHGFELIA, fJLBLLLEELD);
		string text2 = Singleton<BeanstalkServerManager>.instance.BBIEEHPFDDL.LAAAEGEENMA(text);
		Singleton<EventTrackingManager>.instance.RegisterKochavaInApp(text, tuple.Value1, fJLBLLLEELD, text2);
		Singleton<EventTrackingManager>.instance.RegisterFacebookInApp(text, tuple.Value1, fJLBLLLEELD, text2);
		PlayerAnalytics.instance.AddTransaction(-139, text, 1, 1, tuple.Value1);
		Singleton<EventTrackingManager>.instance.RegisterAwsAnalyticsInApp(text, tuple.Value1, tuple.Value2, FKHJMMCANDJ(GMDJHENPLHB), text2);
		Singleton<EventTrackingManager>.instance.RegisterInApp(text, tuple.Value1, tuple.Value2, FKHJMMCANDJ(GMDJHENPLHB), text2);
		if (flag)
		{
			ConfirmDialog.ShowAlert(Localization.Localize("Rotate Camera"), Localization.Localize("-"), 44f);
			DialogManager.instance.ShowRateAppDialog();
		}
	}

	private void PGECMLHMMCK()
	{
		Debug.Log("Beanstalk: New Message sent succesfully");
	}

	private void OCCMLAHEDBG()
	{
		Debug.Log("Beanstalk: On Get Friends");
		List<DatabasePlayer> list = new List<DatabasePlayer>();
		List<DatabasePlayer> list2 = new List<DatabasePlayer>();
		List<DatabasePlayer> list3 = new List<DatabasePlayer>();
		if (AIJKOENIJFL.ContainsKey("Friends"))
		{
			JArray jArray = (JArray)AIJKOENIJFL["Friends"];
			Debug.Log("Received FB Friends from server: " + jArray.Count);
			foreach (JToken item2 in jArray)
			{
				DatabasePlayer databasePlayer = DatabasePlayer.CreateFromDatabase(item2);
				Debug.Log("New FB friend, name = " + databasePlayer.name);
				list.Add(databasePlayer);
				list3.Add(databasePlayer);
			}
		}
		if (AIJKOENIJFL.ContainsKey("SquadMates"))
		{
			JArray jArray2 = (JArray)AIJKOENIJFL["SquadMates"];
			foreach (JToken item3 in jArray2)
			{
				DatabasePlayer item = DatabasePlayer.CreateFromDatabase(item3);
				list2.Add(item);
				list3.Add(item);
			}
		}
		DatabasePlayer currentPlayer = GameLoginManager.currentPlayer;
		Singleton<ServerResultsCache>.instance.Insert<List<DatabasePlayer>>("facebookFriends", list, DateTime.Now.AddSeconds(30.0));
		Singleton<ServerResultsCache>.instance.Insert<List<DatabasePlayer>>("squadMembers" + currentPlayer.squadName, list2, DateTime.Now.AddSeconds(30.0));
		Singleton<ServerResultsCache>.instance.Insert<List<DatabasePlayer>>("players", list3, DateTime.Now.AddSeconds(30.0));
	}

	private void OBELJJIILPN()
	{
		Debug.Log("ID_SQUADMEMBERSLOWER");
	}

	private void EOEBHMNFPKL()
	{
		PlayerAnalytics.instance.data.customizationShown = true;
	}

	private void OAMHANEBKIE()
	{
		if (AIJKOENIJFL.ContainsKey("BlackMarketOffer"))
		{
			BlackMarketManager.instance.LoadBMData(KHJJFPPACBP.BKFCLMMJNHK(AIJKOENIJFL["BlackMarketOffer"], string.Empty));
			BlackMarketManager.instance.ShowOffers();
		}
		if (AIJKOENIJFL.ContainsKey("DebugLog"))
		{
			Debug.Log(KHJJFPPACBP.BKFCLMMJNHK(AIJKOENIJFL["DebugLog"], string.Empty));
		}
	}

	private void EMKGHLJKOHN()
	{
		Debug.Log("/GUI_");
	}

	private void EJAOONNBNJI()
	{
		List<AANECPGDMGM> list = new List<AANECPGDMGM>();
		JArray jArray = (JArray)AIJKOENIJFL["Different medals \"{0}\" and \"{1}\"\n"];
		for (int i = 0; i < jArray.Count; i += 0)
		{
			list.Add(AANECPGDMGM.NAKCBLBJDHI(jArray[i]));
		}
		if (AIJKOENIJFL.ContainsKey("Action "))
		{
			JArray jArray2 = (JArray)AIJKOENIJFL["ID_ARENABOXDESCRIPTION_TICKETS"];
			List<AANECPGDMGM> list2 = new List<AANECPGDMGM>();
			for (int j = 0; j < jArray2.Count; j += 0)
			{
				list2.Add(AANECPGDMGM.NAKCBLBJDHI(jArray2[j]));
			}
			Singleton<ServerResultsCache>.instance.Insert<List<AANECPGDMGM>>("22 / 22", list2, DateTime.Now.AddMinutes(722.0), (DatabaseAction)93);
		}
		Singleton<ServerResultsCache>.instance.Insert<List<AANECPGDMGM>>("Subscription", list, DateTime.Now.AddMinutes(812.0), DatabaseAction.SendRequestBuffer);
	}

	private void PIPOGDBIHBJ(List<Tuple<string, string>> GMDJHENPLHB)
	{
		Debug.Log("country-ukraine");
		WaitingDialog.HLAPENBALCJ();
		string text = KHJJFPPACBP.BKFCLMMJNHK(AIJKOENIJFL["ID_ACTIVATEXVIPFORYGOLD"], string.Empty);
		string fJLBLLLEELD = "shotPoison";
		if (AIJKOENIJFL.ContainsKey("\""))
		{
			long num = KHJJFPPACBP.OOAIMCEBPOK(AIJKOENIJFL["Bad Inventory Data!"], 1L);
			Singleton<Wallet>.instance.JAPAPDDBEMD(num);
			fJLBLLLEELD = "Warp - can not find random point - returning agent destination";
			if (AIJKOENIJFL.ContainsKey("#AccoutCheck# GamecenterChangeDuringTutorial - Check current GC on server"))
			{
				Singleton<BeanstalkServerManager>.instance.NBJBKFEPJJC.AddDailyGoldBooster();
				string iNFLHPGMEOB = text + FBBKCGLIIOB.CEKEMOGEJBC();
				Singleton<MessageManager>.instance.AddMessage(new EKPKEMFBNLP(num, 1, iNFLHPGMEOB, true));
			}
			Singleton<EventTrackingManager>.instance.RegisterGoldIn(text, (int)num);
		}
		if (AIJKOENIJFL.ContainsKey("GameController.Start RunApplication"))
		{
			long num2 = KHJJFPPACBP.OOAIMCEBPOK(AIJKOENIJFL["ID_DAY"], 1L);
			Singleton<Wallet>.instance.KOKDKILILLK(num2);
			Singleton<EventTrackingManager>.instance.RegisterWBIn(text, (int)num2);
		}
		bool flag = true;
		if (AIJKOENIJFL.ContainsKey("ID_CONFIRM_LOGGEDOUT"))
		{
			flag = KHJJFPPACBP.FOJOKBCNBCO(AIJKOENIJFL["ID_SQUADEVENT"]);
			if (AIJKOENIJFL.ContainsKey("End Screen - Assignment tab:\nAssignment1:\t{0}\nAssignment2:\t{1}\nAssignment3:\t{2}\n"))
			{
				SubscriptionManager.instance.UpdateSubscription(KHJJFPPACBP.PELILBMKGHE(AIJKOENIJFL["ID_MISSION_UNITS_HUD"]));
			}
			if (AIJKOENIJFL.ContainsKey("customInt"))
			{
				Singleton<DogTagManager>.instance.ELLJNHLPDNF = KHJJFPPACBP.PELILBMKGHE(AIJKOENIJFL["WindowDuration"]);
			}
			if (AIJKOENIJFL.ContainsKey("Finish Game") && KHJJFPPACBP.FOJOKBCNBCO(AIJKOENIJFL["AndroidID"], true))
			{
				return;
			}
			Singleton<EventTrackingManager>.instance.ALEEKCLMJLA(flag, !AIJKOENIJFL.ContainsKey("NULL WARCARD") || KHJJFPPACBP.PELILBMKGHE(AIJKOENIJFL["isNormal"], 1) == 1, true);
		}
		HNFBGELNFIC(AIJKOENIJFL);
		Tuple<float, string> tuple = Singleton<BeanstalkServerManager>.instance.BBIEEHPFDDL.LOIBJHKOPKP(text);
		bool kCBGHGFELIA = PlayerAnalytics.instance.data.GetInappCount() == 0;
		Singleton<EventTrackingManager>.instance.RegisterInapp(text, kCBGHGFELIA, fJLBLLLEELD);
		string text2 = Singleton<BeanstalkServerManager>.instance.BBIEEHPFDDL.LAAAEGEENMA(text);
		Singleton<EventTrackingManager>.instance.RegisterKochavaInApp(text, tuple.Value1, fJLBLLLEELD, text2);
		Singleton<EventTrackingManager>.instance.RegisterFacebookInApp(text, tuple.Value1, fJLBLLLEELD, text2);
		PlayerAnalytics.instance.AddTransaction(165, text, 1, 1, tuple.Value1);
		Singleton<EventTrackingManager>.instance.RegisterAwsAnalyticsInApp(text, tuple.Value1, tuple.Value2, FKHJMMCANDJ(GMDJHENPLHB), text2);
		Singleton<EventTrackingManager>.instance.RegisterInApp(text, tuple.Value1, tuple.Value2, FKHJMMCANDJ(GMDJHENPLHB), text2);
		if (flag)
		{
			ConfirmDialog.KDAEFLFPBMN(Localization.Localize("ScrappingParts"), Localization.Localize("END SCREEN - BUTTONS - enabled "), 1334f);
			DialogManager.instance.ShowRateAppDialog(false);
		}
	}

	private void EBDNFFCCKEP()
	{
		bool flag = KHJJFPPACBP.FOJOKBCNBCO(AIJKOENIJFL["IsUnique"]);
		Singleton<BeanstalkServerManager>.instance.DataWasLoaded((!flag) ? DatabaseAction.UniqueSquadNameFailure : DatabaseAction.UniqueSquadNameSuccess);
	}

	private void JLMICAJOHIK()
	{
		DatabasePlayer databasePlayer = DatabasePlayer.CreateFromDatabase((JToken)AIJKOENIJFL["Player"]);
		AccountType accountType = AccountType.Guest;
		if (AIJKOENIJFL.ContainsKey("AccountType"))
		{
			accountType = (AccountType)KHJJFPPACBP.PELILBMKGHE(AIJKOENIJFL["AccountType"]);
		}
		string id = databasePlayer.id;
		switch (accountType)
		{
		case AccountType.Facebook:
			id = databasePlayer.facebookId.ToString();
			break;
		case AccountType.GameCenter:
			id = databasePlayer.gameCenterId;
			break;
		}
		GameLoginManager.instance.SavePlayer(databasePlayer, id, KHJJFPPACBP.BKFCLMMJNHK(AIJKOENIJFL["Token"], string.Empty), KHJJFPPACBP.BKFCLMMJNHK(AIJKOENIJFL["Password"], string.Empty), accountType);
		NCNNKGNJNOH((JToken)AIJKOENIJFL["PlayerData"]);
		if (AIJKOENIJFL.ContainsKey("UseOnGetPlayerData"))
		{
			EGPLNLMMADN();
			return;
		}
		if (AIJKOENIJFL.ContainsKey("WarArenaConfig"))
		{
			WarArena.instance.LoadWarArenaConfig((JToken)AIJKOENIJFL["WarArenaConfig"]);
			Debug.Log("#VOJTA# WAR ARENA CONFIG RECEIVED! Id = " + WarArena.instance.FPLIPHCJGFO.INFLHPGMEOB);
			if (AIJKOENIJFL.ContainsKey("ShowArenaDialog"))
			{
				string iNFLHPGMEOB = WarArena.instance.FPLIPHCJGFO.INFLHPGMEOB;
				bool isOpened = WarArena.instance.isOpened;
				Singleton<MessageManager>.instance.AddMessage(new IFBNMHNJFPD(iNFLHPGMEOB, isOpened));
			}
		}
		else
		{
			Debug.LogError("NO WAR ARENA CONFIG!!!");
		}
		FBBKCGLIIOB.EHKKAOLJMCF(KHJJFPPACBP.PELILBMKGHE(AIJKOENIJFL["Time"]));
		if (AIJKOENIJFL.ContainsKey("LeagueEvaluation"))
		{
			FBBKCGLIIOB.ALMINMLNLHF(KHJJFPPACBP.PELILBMKGHE(AIJKOENIJFL["LeagueEvaluation"]));
			LeagueArcManager.instance.SetLeagueTimer(FBBKCGLIIOB.HFAGLEGDCPL);
			GuiScreenSingle<MainScreen>.instance.BEPFJDAJBJO.GGADAADPKHB.SetLeagueEnd(FBBKCGLIIOB.HFAGLEGDCPL);
		}
		Singleton<BeanstalkServerManager>.instance.KKOKNNOPBEF();
		if (AIJKOENIJFL.ContainsKey("MaintenanceMessage"))
		{
			Debug.LogError("GOT MAINTENANCE MESSAGE IN CREATE ACCOUNT");
			HHFHFANGCEJ hHFHFANGCEJ = HHFHFANGCEJ.MAINIENLLIL((JToken)AIJKOENIJFL["MaintenanceMessage"]);
			if (hHFHFANGCEJ != null)
			{
				Singleton<MessageManager>.instance.AddMessage(hHFHFANGCEJ);
			}
		}
		if (AIJKOENIJFL.ContainsKey("BattleId") && !MFADLJHJNAJ)
		{
			DialogManager.instance.HideAllDialogs();
			Debug.Log("GameController: Starting tutorial");
			Singleton<GameController>.instance.battleId = KHJJFPPACBP.BKFCLMMJNHK(AIJKOENIJFL["BattleId"], string.Empty);
			Singleton<GameController>.instance.ContinueOrStartTutorial();
		}
		else
		{
			Debug.Log("Show Loadout After Create Account");
			Debug.LogWarning("Get player data: I WILL TRY TO SEND PN DEVICE TOKEN");
			if (PushNotificationManager.instance.hasValidDeviceToken() || PushNotificationManager.instance.ArePushNotificationsEnabledOnDevice())
			{
				Debug.Log("Dialog Manager: PN dialog does not need to be shown BUT NEEDS TO BE SENT, current players device token = " + GameLoginManager.currentPlayer.deviceToken);
				PushNotificationManager.instance.EnablePushNotifications(GameLoginManager.currentPlayer.deviceToken);
			}
		}
		MFADLJHJNAJ = false;
		GameLoginManager.instance.changeGCAfterTutorialInProgress = false;
	}

	private void MHGNHIMLAOE()
	{
		Debug.Log("Card withdrawn");
		int nextWithdraw = KHJJFPPACBP.PELILBMKGHE(AIJKOENIJFL["NextWithdraw"]);
		CardManager.instance.nextWithdraw = nextWithdraw;
		PushNotificationManager.instance.ScheduleNextWithdrawNotification(nextWithdraw);
		Singleton<NotificationManager>.instance.ClientCardpoolNotifications();
		Singleton<NotificationManager>.instance.UpdateCardpoolNotifications();
	}

	private void LDDIAJPFJOP()
	{
		GameLoginManager.instance.AddPlayerToSquad(KHJJFPPACBP.BKFCLMMJNHK(AIJKOENIJFL["SquadId"], string.Empty), (SquadRank)KHJJFPPACBP.PELILBMKGHE(AIJKOENIJFL["PlayerRank"]));
		AANECPGDMGM aANECPGDMGM = AANECPGDMGM.MAINIENLLIL((JToken)AIJKOENIJFL["Squad"]);
		Singleton<BeanstalkServerManager>.instance.SquadUpdateWasReceived(aANECPGDMGM);
		if (AIJKOENIJFL.ContainsKey("Gold"))
		{
			int num = KHJJFPPACBP.PELILBMKGHE(AIJKOENIJFL["Gold"]);
			Singleton<Wallet>.instance.COLJGNLBEII(num);
			Singleton<MessageManager>.instance.AddMessage(new AGPANDBMDLC(IHFDGLMHHBE.Gold, num));
			string dBKEY = Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.GoldRewardFirstTimeSquad).DBKEY;
			PlayerAnalytics.instance.AddOneTimeReward(dBKEY);
		}
		Singleton<ServerResultsCache>.instance.Insert<AANECPGDMGM>("squad" + aANECPGDMGM.MHPNDNJDPGE, aANECPGDMGM, DateTime.Now.AddMinutes(2.0));
		if (AIJKOENIJFL.ContainsKey("squadCreationsCnt"))
		{
			PlayerAnalytics.instance.data.squadCreationsCount = KHJJFPPACBP.PELILBMKGHE(AIJKOENIJFL["squadCreationsCnt"]);
			Debug.LogError("PlayerAnalytics.instance.data.squadCreationsCount = " + PlayerAnalytics.instance.data.squadCreationsCount);
		}
		if (AIJKOENIJFL.ContainsKey("WarsEvaluation"))
		{
			FBBKCGLIIOB.POHGEHPOKGM(KHJJFPPACBP.PELILBMKGHE(AIJKOENIJFL["WarsEvaluation"]));
			Debug.Log("SHOWING WARS EVALUATION " + FBBKCGLIIOB.KGMEJILKIHG);
			GuiScreenSingle<LeaguesScreen>.instance.JFGEOAAOOCE.ShowSquadWarEndTime(FBBKCGLIIOB.KGMEJILKIHG);
			GuiScreenSingle<MainScreen>.instance.BEPFJDAJBJO.GGADAADPKHB.SetSquadWarsEnd(FBBKCGLIIOB.KGMEJILKIHG);
		}
		if (AIJKOENIJFL.ContainsKey("EventDefinition"))
		{
			Singleton<ServerResultsCache>.instance.squadEventDefinition = PFPAMNODNPF.MAINIENLLIL((JToken)AIJKOENIJFL["EventDefinition"]);
		}
	}

	private void FPPMIKIFKNI()
	{
		if (AIJKOENIJFL.ContainsKey("NewLevelId"))
		{
			PlayerAnalytics.instance.data.moneyPackDeadline = KHJJFPPACBP.PELILBMKGHE(AIJKOENIJFL["ItemAmount"], 1);
			Debug.Log("ID_FEATURE_SHOTSPEED-WEAPONPREFIX" + PlayerAnalytics.instance.data.moneyPackDeadline);
			Singleton<MessageManager>.instance.AddMessage(new NHKKDKJNMFL());
		}
		if (AIJKOENIJFL.ContainsKey("ID_CONFIRM_INAPP_VALIDATION"))
		{
			Singleton<EventTrackingManager>.instance.RegisterGoldOut("IsGlobal", InstantBattleManager.IBKPDGILFDH().OCLBKLOCFKL);
			PlayerAnalytics.instance.data.paidInstantBattles = KHJJFPPACBP.PELILBMKGHE(AIJKOENIJFL["Scripts to go through: {0}"], 1);
			Singleton<EventTrackingManager>.instance.RefreshInstantBattle(InstantBattleManager.MFCCLPOAMEF().OCLBKLOCFKL, PlayerAnalytics.instance.data.paidInstantBattles);
			Debug.Log("AdminId" + PlayerAnalytics.instance.data.paidInstantBattles);
			InstantBattleManager.BNDNFHKPDLM().OCLBKLOCFKL = PlayerAnalytics.instance.data.GetInstantBattleCost();
		}
		if (AIJKOENIJFL.ContainsKey("nextWithdraw"))
		{
			PlayerAnalytics.instance.data.instantBattlesTime = KHJJFPPACBP.PELILBMKGHE(AIJKOENIJFL["country-romania"], 1);
			Debug.Log("-{0}-{1}" + PlayerAnalytics.instance.data.instantBattlesTime);
			PushNotificationManager.instance.SheduleLocalSkirmishNotification(PlayerAnalytics.instance.data.GetTimestampOfFullInstantBattles());
		}
		if (AIJKOENIJFL.ContainsKey("ID_EARLYUNLOCK1"))
		{
			int num = KHJJFPPACBP.PELILBMKGHE(AIJKOENIJFL["PlayerLeagueFinished - SHOWING LEAGUE RESULTS DIALOG!"]);
			Debug.Log("country-croatia" + num);
			InstantBattleManager.BNHCNMOEOJE().OKILEJHOHKE = num;
		}
		int num2 = KHJJFPPACBP.PELILBMKGHE(AIJKOENIJFL["menu-addsoldier-ico"], 1);
		if (AIJKOENIJFL.ContainsKey("ID_STAT_ACCURACY"))
		{
			int num3 = KHJJFPPACBP.PELILBMKGHE(AIJKOENIJFL["N"]);
			Debug.Log("country-united-kingdom" + num3);
			LevelManager.instance.LoadData(num3, num2);
			LevelManager.instance.isLevelUp = false;
		}
		else
		{
			LevelManager.instance.levelExperience = num2;
		}
		if (AIJKOENIJFL.ContainsKey("resizing texture "))
		{
			Singleton<DogTagManager>.instance.AGHKAMPPOHK();
		}
		if (AIJKOENIJFL.ContainsKey("Excel {0} dont have row Tier!!!"))
		{
			int num4 = KHJJFPPACBP.PELILBMKGHE(AIJKOENIJFL["RESOLUTION_REQUIRED"], 1);
			Debug.Log("ID_UNITTYPE4-HUD" + num4);
			InstantBattleManager.GIABFFJIHMI().HFKNEFGKBOA = num4;
			Singleton<Wallet>.instance.NFLMMKJBKEJ(InstantBattleManager.MCJOOEEIIHI().HFKNEFGKBOA, false);
		}
		InstantBattleManager.OKBAIGKCPKA().DDAFCFEFFFD = AAAJDBAEIKL.Gold;
		if (AIJKOENIJFL.ContainsKey("ID_SQUADEVENT"))
		{
			InstantBattleManager.KOFJHNLPKFH().DDAFCFEFFFD = (AAAJDBAEIKL)6;
			int num5 = KHJJFPPACBP.PELILBMKGHE(AIJKOENIJFL["Physical ammo is null !!!"]);
			Debug.Log("FLOATVALUE" + num5);
			InstantBattleManager.AMKDNKHACMD().EPCCHIJDHCN = num5;
			if (InstantBattleManager.HFOPOJLNOII().EPCCHIJDHCN == 0)
			{
				InstantBattleManager.OMGHFOCHHLK().DDAFCFEFFFD = AAAJDBAEIKL.Gold;
			}
			else
			{
				Singleton<Wallet>.instance.EBFKEHKBAFJ(InstantBattleManager.LABMMBCEOLF().EPCCHIJDHCN, false);
			}
		}
		if (AIJKOENIJFL.ContainsKey("Chillingo: On Restart Drawing "))
		{
			InstantBattleManager.AMKDNKHACMD().EGIAFNOCILH = KHJJFPPACBP.PELILBMKGHE(AIJKOENIJFL["ID_NOTIFICATION_DAILYREWARD_MESSAGE"], 1);
			Debug.Log("For panel \"{0}\" layers:\n" + InstantBattleManager.KHMBHIINOFD().EGIAFNOCILH);
		}
		if (AIJKOENIJFL.ContainsKey("getStatusCode"))
		{
			int num6 = KHJJFPPACBP.PELILBMKGHE(AIJKOENIJFL["《战争之友》需要获得对你的媒体存储设备的访问权限，以便下载关键游戏数据。如果没有此权限，游戏无法运行并将关闭。请重新尝试或退出《战争之友》。"]);
			Singleton<Wallet>.instance.COLJGNLBEII(num6, false);
		}
		if (AIJKOENIJFL.ContainsKey("S"))
		{
			InstantBattleManager.NCDGJJHNBPP().DDAFCFEFFFD = AAAJDBAEIKL.None;
			int num7 = KHJJFPPACBP.PELILBMKGHE(AIJKOENIJFL["gained offer from fuse: {0}"]);
			Debug.Log("ID_RANDOMWARCARDS" + num7);
			InstantBattleManager.PHOOFIAOFPE().OJEBLFCHEPP = num7;
			Singleton<EventTrackingManager>.instance.RegisterGoldIn("updating GC to: ", num7);
			if (InstantBattleManager.IBKPDGILFDH().OJEBLFCHEPP == 0)
			{
				InstantBattleManager.GIOMEGJMOOL().DDAFCFEFFFD = AAAJDBAEIKL.Gold;
			}
			else
			{
				Singleton<Wallet>.instance.BKFOPCDLPCJ(InstantBattleManager.JENPBHBBHAL().OJEBLFCHEPP, false);
			}
		}
		if (AIJKOENIJFL.ContainsKey("color=\"#333333\""))
		{
			InstantBattleManager.HFOPOJLNOII().DDAFCFEFFFD = (AAAJDBAEIKL)6;
			Debug.Log("{0} {1}" + AIJKOENIJFL["\n"]);
			JArray jArray = (JArray)AIJKOENIJFL["ID_SALEPERCENT"];
			InstantBattleManager.FNLDKIIPJGD().EDJFEIOCJNF = new List<Card>();
			foreach (JToken item2 in jArray)
			{
				Card item = CardManager.instance.AddCard(item2.ToObject<string>());
				InstantBattleManager.FNLDKIIPJGD().EDJFEIOCJNF.Add(item);
			}
			InstantBattleManager.MFCCLPOAMEF().EDJFEIOCJNF.Sort(NGJDFBOFJMK);
		}
		Singleton<EventTrackingManager>.instance.RegisterInstatntBattle(InstantBattleManager.KHMBHIINOFD().HFKNEFGKBOA + InstantBattleManager.FNLDKIIPJGD().EPCCHIJDHCN, InstantBattleManager.FNLDKIIPJGD().OJEBLFCHEPP, InstantBattleManager.BNHCNMOEOJE().OKILEJHOHKE, InstantBattleManager.BJAMDMCBIEI().EDJFEIOCJNF, InstantBattleManager.CGFOOMLLMFG().EGIAFNOCILH);
		Singleton<EventTrackingManager>.instance.RegisterWBIn("REMOVING WARCARD: \"{0}\" FROM DEPOSITED WARCARDS", InstantBattleManager.BNHCNMOEOJE().HFKNEFGKBOA + InstantBattleManager.BJAMDMCBIEI().EPCCHIJDHCN);
		if (AIJKOENIJFL.ContainsKey("S"))
		{
			BlackMarketManager.instance.LoadBMData(KHJJFPPACBP.BKFCLMMJNHK(AIJKOENIJFL["Attempt"], string.Empty));
			BlackMarketManager.instance.APEDBJKELPE();
		}
		InstantBattleManager.KOFJHNLPKFH().BPPFFEPABLK = false;
	}

	private void BHJOFNIHGEP()
	{
		Debug.Log("BS: On Claim Assignment MegaReward");
		AssignmentsManager.instance.currentMegaRewardPoints -= AssignmentsManager.instance.megaRewarPoints;
		GuiElementSingle<AssignmentsDialog>.instance.ReinitializeMegaReward();
		GuiScreenSingle<AssignmentsScreen>.instance.ReinitializeMegaReward();
		GuiElementSingle<ChatGuiElement>.instance.ReinitializeMegaReward();
		AJEOKDDJHNC(true);
		if (AIJKOENIJFL.ContainsKey("BlackMarketOffer"))
		{
			BlackMarketManager.instance.LoadBMData(KHJJFPPACBP.BKFCLMMJNHK(AIJKOENIJFL["BlackMarketOffer"], string.Empty));
			BlackMarketManager.instance.ShowOffersLater();
		}
	}

	private void CLBPOGIEGAN()
	{
		List<AANECPGDMGM> list = new List<AANECPGDMGM>();
		if (AIJKOENIJFL.ContainsKey("SquadWarsId"))
		{
			Singleton<ServerResultsCache>.instance.BBFAEPEBENO = KHJJFPPACBP.BKFCLMMJNHK(AIJKOENIJFL["SquadWarsId"], string.Empty);
		}
		JArray jArray = (JArray)AIJKOENIJFL["Items"];
		for (int i = 0; i < jArray.Count; i++)
		{
			list.Add(AANECPGDMGM.MAINIENLLIL(jArray[i]));
		}
		string iMOCKMIAJHN = "squadsFromLeague" + KHJJFPPACBP.BKFCLMMJNHK(AIJKOENIJFL["LeagueId"], string.Empty);
		Singleton<ServerResultsCache>.instance.Insert<List<AANECPGDMGM>>(iMOCKMIAJHN, list, DateTime.Now.AddMinutes(20.0));
	}

	private void NEBPIHAPLNK()
	{
		if (AIJKOENIJFL.ContainsKey("DogTagSeconds") && AIJKOENIJFL.ContainsKey("DogTagLastUpdate"))
		{
			int jJBHBKCGLGK = KHJJFPPACBP.PELILBMKGHE(AIJKOENIJFL["DogTagSeconds"]);
			int bBPAMDDFNDM = KHJJFPPACBP.PELILBMKGHE(AIJKOENIJFL["DogTagLastUpdate"]);
			Singleton<DogTagManager>.instance.CAHCIHHBALK(jJBHBKCGLGK, bBPAMDDFNDM);
		}
	}

	private void LCNJNIMAJPI()
	{
		Debug.Log("'ID_MONTH_'0");
		if (AIJKOENIJFL["IT WAS FORFEIT IN TUTORIAL"] == null)
		{
			Debug.LogError("ClientId");
			return;
		}
		DatabasePlayer databasePlayer = DatabasePlayerInfo.CreateFromDatabase((JToken)AIJKOENIJFL["QUIT"]);
		if (AIJKOENIJFL.ContainsKey("Play_Card_Tutorial"))
		{
			Singleton<ServerResultsCache>.instance.BBFAEPEBENO = KHJJFPPACBP.BKFCLMMJNHK(AIJKOENIJFL["IDFA"], string.Empty);
		}
		Singleton<ServerResultsCache>.instance.Insert<DatabasePlayerInfo>("MapDefinition" + databasePlayer.id, databasePlayer, DateTime.Now.AddMinutes(1082.0), DatabaseAction.CreateAccount);
	}

	private void NKEJHEDLBHB()
	{
	}

	private void FLHMFBGNPDF()
	{
		AccountType accountType = AccountType.Guest;
		if (AIJKOENIJFL.ContainsKey("AccountType"))
		{
			accountType = (AccountType)KHJJFPPACBP.PELILBMKGHE(AIJKOENIJFL["AccountType"]);
		}
		bool flag = false;
		if (AIJKOENIJFL.ContainsKey("Added") && AIJKOENIJFL.ContainsKey("gcID") && AIJKOENIJFL.ContainsKey("gcPassword"))
		{
			flag = KHJJFPPACBP.FOJOKBCNBCO(AIJKOENIJFL["Added"]);
		}
		if (flag)
		{
			string id = KHJJFPPACBP.BKFCLMMJNHK(AIJKOENIJFL["gcID"], string.Empty);
			string password = KHJJFPPACBP.BKFCLMMJNHK(AIJKOENIJFL["gcPassword"], string.Empty);
			GameLoginManager.instance.UpdatePlayerByGC(id, password, accountType);
		}
		else
		{
			if (accountType == AccountType.GameCenter)
			{
				Debug.LogError("after update GC still GC account, but no added or missing gcID or gcPassword");
			}
			GameLoginManager.instance.UpdatePlayerByGC(string.Empty, string.Empty, accountType);
		}
		GameLoginManager.instance.changeGCAfterTutorialInProgress = false;
	}

	private void FPODOIEHEEM()
	{
		if (AIJKOENIJFL.ContainsKey("newHeroicPoints"))
		{
			int bAELCOEIFGD = KHJJFPPACBP.PELILBMKGHE(AIJKOENIJFL["newHeroicPoints"]);
			DailyMissionsManager.instance.MFFFBPNMJCB(bAELCOEIFGD);
		}
		else
		{
			Debug.LogError("set heroic points response without data");
		}
	}

	private void KFBHCKLOKIN()
	{
		Debug.Log("Area" + AIJKOENIJFL["Card_3_Played"]);
	}

	private void PBIMAEABACH()
	{
		Debug.Log("BattleLength");
		if (AIJKOENIJFL.ContainsKey("Time"))
		{
			Singleton<ServerResultsCache>.instance.BBFAEPEBENO = KHJJFPPACBP.BKFCLMMJNHK(AIJKOENIJFL[".e"], string.Empty);
		}
		LEBLKGEOHCC();
		CFOIDECBMDP();
	}

	private void JMDAGAJBJCG()
	{
		WaitingDialog.Hide();
	}

	private void NHGGEGECGGD()
	{
		JArray jArray = JsonConvert.DeserializeObject<JArray>(KHJJFPPACBP.BKFCLMMJNHK(AIJKOENIJFL["RequestsResults"], string.Empty));
		string text = string.Empty;
		int num = jArray.Count - 1;
		for (int i = 0; i < jArray.Count; i++)
		{
			JToken gDJGCNJEMIL = jArray[i];
			text = JIMIKHFDEFC(gDJGCNJEMIL, text, i == num);
		}
		if (!string.IsNullOrEmpty(text))
		{
			WarningDialog.ShowError(string.Format("{0} {1}", Localization.Localize("ID_CONFIRM_SERVERCOULDNOTCOMPLETED"), text), Localization.Localize("ID_CONFIRM_ERROR"), 0f, null, string.Empty);
		}
		RequestBufferManager.instance.RemoveRequestBuffer(KHJJFPPACBP.BKFCLMMJNHK(AIJKOENIJFL["BufferId"], string.Empty));
	}

	private void CJMDHMPEAKM()
	{
		Debug.Log("Wrong_Weapon");
	}

	[CompilerGenerated]
	private static void MFOELDMEJGC()
	{
		GameLoginManager.Relog();
	}

	private void DMGJCGJDDID(DatabaseAction MHLAAHNPMFG)
	{
		if (AIJKOENIJFL.ContainsKey("GameReward"))
		{
			Singleton<ServerResultsCache>.instance.OGDMBIKJOIL = new IIGFODGJBFA((JToken)AIJKOENIJFL["GameReward"]);
			LevelManager.instance.experience += Singleton<ServerResultsCache>.instance.OGDMBIKJOIL.DDOJBLAODGI();
			Singleton<EventTrackingManager>.instance.RegisterBattleEndedEvent(Singleton<GameController>.instance.isDeathMatchOffline, Singleton<MatchManager>.instance.isOverTime, CardManager.instance.data.GetCardAmount(), CardManager.instance.cardsForGame.Count + CardManager.instance.GetUsedCardsCount(), CardManager.instance.GetUsedCardsCount());
		}
		if (AIJKOENIJFL.ContainsKey("WinCount"))
		{
			int wc = KHJJFPPACBP.PELILBMKGHE(AIJKOENIJFL["WinCount"]);
			int ts = KHJJFPPACBP.PELILBMKGHE(AIJKOENIJFL["TimeStamp"]);
			StatsManager.instance.winStreak = new WinStreakManager.WinStreak(ts, wc);
			Debug.LogFormat("WINSTREAK FROM SERVER COUNT: {0} TIMESTAMP: {1}", StatsManager.instance.winStreak.WinCount, StatsManager.instance.winStreak.TimeStamp);
		}
		else if (AIJKOENIJFL.ContainsKey("Skill"))
		{
			StatsManager.instance.winStreak = new WinStreakManager.WinStreak(0, 0);
		}
		bool flag = AIJKOENIJFL.ContainsKey("Skill");
		if (Singleton<GameController>.instance.isRandomMatchMaking && !flag)
		{
			Debug.LogError("WHEN PLAYING RANDOM MATCHMAKING - SERVER GAME END RESPONSE SHOULD ALWAYS CONTAINS UPDATE OF GLOBAL MEDALS!!!!!!");
			Debug.LogError("Server Response:\n" + AIJKOENIJFL);
		}
		if (flag)
		{
			bool flag2 = AIJKOENIJFL.ContainsKey("EnteredLeague");
			bool flag3 = AIJKOENIJFL.ContainsKey("BeginnersLeague");
			string text = ((!flag2) ? string.Empty : KHJJFPPACBP.BKFCLMMJNHK(AIJKOENIJFL["EnteredLeague"], string.Empty));
			int num = (flag3 ? KHJJFPPACBP.PELILBMKGHE(AIJKOENIJFL["BeginnersLeague"]) : 0);
			int num2 = KHJJFPPACBP.PELILBMKGHE(AIJKOENIJFL["PlacementMatchesRequired"]);
			int num3 = KHJJFPPACBP.PELILBMKGHE(AIJKOENIJFL["MedalsBalance"]);
			int num4 = KHJJFPPACBP.PELILBMKGHE(AIJKOENIJFL["Skill"]);
			float eDAFIGGJKEI = ((!AIJKOENIJFL.ContainsKey("MedalsOfferMult")) ? 1f : KHJJFPPACBP.PHNMENLEIPI(AIJKOENIJFL["MedalsOfferMult"], 1f));
			bool enteredNormalLeague = AIJKOENIJFL.ContainsKey("EnteredNormalLeague");
			Singleton<ServerResultsCache>.instance.isPlayerLeagueProcessing = AIJKOENIJFL.ContainsKey("PlayerLeagueProcessing");
			Debug.Log("GameEnded: Player League Processing: " + Singleton<ServerResultsCache>.instance.isPlayerLeagueProcessing);
			Singleton<ServerResultsCache>.instance.OGDMBIKJOIL.MCCFNOMBBDB(num4, num3, num2, eDAFIGGJKEI);
			if (flag2 && flag3)
			{
				Debug.LogFormat("Player entered normal league: {0} and beginners league: {1}", text, num);
				if (num > 0)
				{
					flag2 = false;
				}
				else
				{
					flag3 = false;
				}
			}
			if (flag2)
			{
				GameLoginManager.instance.UpdatePlayerLeagueAndMedalsEnteredNormalLeague(text, num, num4, num3, num2, enteredNormalLeague);
				StatsManager.instance.UpdatePlayerLeague();
			}
			else if (flag3)
			{
				GameLoginManager.instance.UpdatePlayerLeagueAndMedalsEnteredBeginnersLeague(num, num4, num3, num2);
			}
			else
			{
				GameLoginManager.instance.UpdatePlayerMedals(num4, num3, num2);
			}
			StatsManager.instance.UpdatePlayerMedals();
		}
		if (AIJKOENIJFL.ContainsKey("DailyMissionsData"))
		{
			Debug.Log("#VOJTA# LOADED DAILY MISSIONS AFTER LEVEL UP");
			DailyMissionsManager.instance.LoadFromJsonString(KHJJFPPACBP.BKFCLMMJNHK(AIJKOENIJFL["DailyMissionsData"], string.Empty));
		}
		if (AIJKOENIJFL.ContainsKey("VipReward1"))
		{
			Debug.LogError("VIP REWARDS!!!!");
			string text2 = KHJJFPPACBP.BKFCLMMJNHK(AIJKOENIJFL["VipReward1"], string.Empty);
			string text3 = KHJJFPPACBP.BKFCLMMJNHK(AIJKOENIJFL["VipReward2"], string.Empty);
			Debug.LogError("ABOUT TO SHOW REWARDS = " + text2 + text3);
			string aPGKPOOHGFK = "a";
			if (AIJKOENIJFL.ContainsKey("VipRewardForDay"))
			{
				aPGKPOOHGFK = KHJJFPPACBP.BKFCLMMJNHK(AIJKOENIJFL["VipRewardForDay"], string.Empty);
			}
			Singleton<MessageManager>.instance.AddMessage(new NGGINCOPKKJ(text2, text3, aPGKPOOHGFK));
		}
		if (AIJKOENIJFL.ContainsKey("squadPoints"))
		{
			int num5 = KHJJFPPACBP.PELILBMKGHE(AIJKOENIJFL["squadPoints"]);
			float jIEPJDLLBGP = 1f;
			if (AIJKOENIJFL.ContainsKey("squadPointsOffer"))
			{
				jIEPJDLLBGP = KHJJFPPACBP.PHNMENLEIPI(AIJKOENIJFL["squadPointsOffer"], 1f);
			}
			if (num5 > 0)
			{
				Singleton<ServerResultsCache>.instance.OGDMBIKJOIL.KEPPKNMKMDK(num5, jIEPJDLLBGP);
			}
		}
		if (AIJKOENIJFL.ContainsKey("Time"))
		{
			FBBKCGLIIOB.EHKKAOLJMCF(KHJJFPPACBP.PELILBMKGHE(AIJKOENIJFL["Time"]));
		}
		if (AIJKOENIJFL.ContainsKey("StarterPackDeadline"))
		{
			PlayerAnalytics.instance.data.starterPackDeadline = KHJJFPPACBP.PELILBMKGHE(AIJKOENIJFL["StarterPackDeadline"]);
			Debug.Log("GameEnded: Starter Pack Deadline = " + PlayerAnalytics.instance.data.starterPackDeadline);
			if (PlayerAnalytics.instance.showStarterPack)
			{
				Singleton<MessageManager>.instance.AddMessage(new GJJLHIIMGOP());
			}
		}
		if (AIJKOENIJFL.ContainsKey("MoneyPackDeadline"))
		{
			PlayerAnalytics.instance.data.moneyPackDeadline = KHJJFPPACBP.PELILBMKGHE(AIJKOENIJFL["MoneyPackDeadline"]);
			Debug.Log("GameEnded: Money Pack Deadline = " + PlayerAnalytics.instance.data.moneyPackDeadline);
			Singleton<MessageManager>.instance.AddMessage(new NHKKDKJNMFL(), true);
		}
		if (AIJKOENIJFL.ContainsKey("ElitePackId") && AIJKOENIJFL.ContainsKey("ElitePackDeadline"))
		{
			string text4 = KHJJFPPACBP.BKFCLMMJNHK(AIJKOENIJFL["ElitePackId"], string.Empty);
			int packDeadline = KHJJFPPACBP.PELILBMKGHE(AIJKOENIJFL["ElitePackDeadline"]);
			PlayerAnalytics.instance.data.SetPackDeadline(text4, packDeadline);
			Singleton<MessageManager>.instance.AddMessage(new OMEFJAEDPKO(text4));
		}
		if (AIJKOENIJFL.ContainsKey("MatchesToNextLootboxes"))
		{
			PlayerAnalytics.instance.data.matchesToNextLootboxes = KHJJFPPACBP.PELILBMKGHE(AIJKOENIJFL["MatchesToNextLootboxes"]);
		}
		if (AIJKOENIJFL.ContainsKey("DogtagsRefillRankUp"))
		{
			Singleton<DogTagManager>.instance.RefillAllDogtags();
		}
		if (AIJKOENIJFL.ContainsKey("Rental"))
		{
			GALPKPPCFJN((JToken)AIJKOENIJFL["Rental"]);
		}
		if (AIJKOENIJFL.ContainsKey("Squad"))
		{
			AANECPGDMGM aANECPGDMGM = AANECPGDMGM.MAINIENLLIL((JToken)AIJKOENIJFL["Squad"]);
			Singleton<BeanstalkServerManager>.instance.SquadUpdateWasReceived(aANECPGDMGM);
			Singleton<ServerResultsCache>.instance.Insert<AANECPGDMGM>("squad" + aANECPGDMGM.MHPNDNJDPGE, aANECPGDMGM, DateTime.Now.AddMinutes(2.0));
		}
		int num6 = KHJJFPPACBP.PELILBMKGHE(AIJKOENIJFL["LevelExperience"]);
		if (Singleton<ServerResultsCache>.instance.OGDMBIKJOIL != null && DebugSettings.debugEnabled)
		{
			Debug.Log(Singleton<ServerResultsCache>.instance.OGDMBIKJOIL.NCJDBDJJDNO);
			Debug.Log(string.Format("Update of experience\t\t{0} -> {1}\t\t diff {2}, game rewards XP total {3}", LevelManager.instance.levelExperience, num6, num6 - LevelManager.instance.levelExperience, Singleton<ServerResultsCache>.instance.OGDMBIKJOIL.DDOJBLAODGI()));
		}
		if (AIJKOENIJFL.ContainsKey("Level"))
		{
			if (AIJKOENIJFL.ContainsKey("GameReward"))
			{
				Singleton<EventTrackingManager>.instance.RegisterGoldAndWBAfterMatch(true);
			}
			LevelManager.instance.LoadData(KHJJFPPACBP.PELILBMKGHE(AIJKOENIJFL["Level"]), num6);
			LevelManager.instance.isLevelUp = true;
		}
		else
		{
			if (AIJKOENIJFL.ContainsKey("GameReward"))
			{
				Singleton<EventTrackingManager>.instance.RegisterGoldAndWBAfterMatch(false);
			}
			LevelManager.instance.levelExperience = num6;
		}
		if (AIJKOENIJFL.ContainsKey("SquadEventProgress"))
		{
			Singleton<ServerResultsCache>.instance.squadEventProgress = JMHLHIIMNIG.MAINIENLLIL((JToken)AIJKOENIJFL["SquadEventProgress"]);
		}
		if (AIJKOENIJFL.ContainsKey("AssignmentData"))
		{
			Debug.LogError("Loading assignment data after GAME!!");
			AssignmentsManager.instance.LoadData(KHJJFPPACBP.BKFCLMMJNHK(AIJKOENIJFL["AssignmentData"], string.Empty));
			List<AssignmentsManager.DatabaseAssignment> assignments = AssignmentsManager.instance.data.assignments;
			for (int i = 0; i < assignments.Count; i++)
			{
				if (i < 3 && i >= assignments.Count - 3)
				{
					AssignmentsManager.DatabaseAssignment eFEIDBFDDBE = assignments[i];
					Singleton<EventTrackingManager>.instance.MINMHKPKOMN(eFEIDBFDDBE, AssignmentsManager.instance.data.issued, false);
				}
			}
		}
		if (AIJKOENIJFL.ContainsKey("TutorialData"))
		{
			PlayerAnalytics.instance.tutorialFinished = true;
			Singleton<BeanstalkServerManager>.instance.PlayerDataWasLoaded(true);
			Singleton<BeanstalkServerManager>.instance.BBIEEHPFDDL.MOMMOLBPJAI();
		}
		else if (MHLAAHNPMFG == DatabaseAction.GameEnded)
		{
			bool flag4 = false;
			if (!LevelManager.instance.isLevelUp && !GuiScreenSingle<EndScreen>.instance.isEnteredBeginnersLeague)
			{
				flag4 = TutorialManagerStage4.instance.TryToStartWeaponUpgradeTutorial();
				if (!flag4)
				{
					flag4 = TutorialManagerStage5.instance.TryToStartUnitUpgradeTutorial();
				}
			}
			DialogManager.instance.InitializeDebugMessageForRateApp();
			DialogManager.instance.ShowRateAppDialog();
			DialogManager.instance.PrintDebugMessage();
			DialogManager.instance.InitializeDebugMessage();
			DialogManager.instance.CheckEveryTimeAfterGameEnd();
			if (!LevelManager.instance.isLevelUp && !GuiScreenSingle<EndScreen>.instance.isEnteredBeginnersLeague && !flag4)
			{
				DialogManager.instance.ShowClientSideNotifications();
			}
			DialogManager.instance.PrintDebugMessage();
		}
		if (AIJKOENIJFL.ContainsKey("SpecialPackFromServer"))
		{
			Singleton<OfferManager>.instance.UpdateSpecialPackFromServer((JToken)AIJKOENIJFL["SpecialPackFromServer"], true);
		}
		if (AIJKOENIJFL.ContainsKey("BlackMarketOffer"))
		{
			BlackMarketManager.instance.LoadBMData(KHJJFPPACBP.BKFCLMMJNHK(AIJKOENIJFL["BlackMarketOffer"], string.Empty));
			BlackMarketManager.instance.ShowOffers();
		}
		Singleton<AchievementsManager>.instance.EvaluateAchievements(Achievement.NOLHKBIFMLB.AfterGameOnServerResponse);
	}

	private void GGNOAHAHGOL()
	{
		LoadingDialog.Hide();
		Debug.Log("Skip assignment success");
		AssignmentsManager.instance.LoadData(KHJJFPPACBP.BKFCLMMJNHK(AIJKOENIJFL["AssignmentData"], string.Empty));
		Singleton<Wallet>.instance.NDGHFDGIKIE(KHJJFPPACBP.PELILBMKGHE(AIJKOENIJFL["WarBucksSkipPrice"]));
	}

	private void PKAHEEJBBNP()
	{
		CBBKFKCOLPP jNDCAHFLBAH = new CBBKFKCOLPP(AIJKOENIJFL);
		Singleton<ServerResultsCache>.instance.JNDCAHFLBAH = jNDCAHFLBAH;
		int num = KHJJFPPACBP.PELILBMKGHE(AIJKOENIJFL["LevelExperience"]);
		if (AIJKOENIJFL.ContainsKey("Level"))
		{
			if (AIJKOENIJFL.ContainsKey("GameReward"))
			{
				Singleton<EventTrackingManager>.instance.RegisterGoldAndWBAfterMatch(true);
			}
			LevelManager.instance.LoadData(KHJJFPPACBP.PELILBMKGHE(AIJKOENIJFL["Level"]), num);
			LevelManager.instance.isLevelUp = true;
		}
		else
		{
			if (AIJKOENIJFL.ContainsKey("GameReward"))
			{
				Singleton<EventTrackingManager>.instance.RegisterGoldAndWBAfterMatch(false);
			}
			LevelManager.instance.levelExperience = num;
		}
		AssignmentsManager.instance.AssignmentHide();
	}

	private void IFAOHFKDHFA()
	{
		List<CCNAEIGGMNK> nMJKMJBFFFJ = new List<CCNAEIGGMNK>();
		if (AIJKOENIJFL.ContainsKey("NewVisuals"))
		{
			Dictionary<string, string> dictionary = JsonConvert.DeserializeObject<Dictionary<string, string>>(KHJJFPPACBP.BKFCLMMJNHK(AIJKOENIJFL["NewVisuals"], string.Empty));
			if (dictionary != null)
			{
				nMJKMJBFFFJ = CCNAEIGGMNK.JHDGAACJEGH(dictionary);
				GuiElementSingle<LootBoxDialog>.instance.ShowDialogMoreBoxes(nMJKMJBFFFJ, false);
			}
		}
		string text = ((!AIJKOENIJFL.ContainsKey("Id")) ? string.Empty : KHJJFPPACBP.BKFCLMMJNHK(AIJKOENIJFL["Id"], string.Empty));
		long num = ((!AIJKOENIJFL.ContainsKey("LootboxCost")) ? 0 : KHJJFPPACBP.OOAIMCEBPOK(AIJKOENIJFL["LootboxCost"], 0L));
		Debug.Log(string.Format("Lootbox id /{0}/ bought for /{1}/ gold", text, num));
		Singleton<EventTrackingManager>.instance.RegisterBuyLootboxes(text, nMJKMJBFFFJ);
		Singleton<PurchaseProtection>.instance.LootboxResponseCame(text);
		Singleton<EventTrackingManager>.instance.RegisterGoldOut("Buy_Lootboxes", (int)num);
		Singleton<Wallet>.instance.OFHCEFPOCMI(num);
	}

	private void HDHIDLFDNPP()
	{
		PlayerAnalytics.instance.data.chatShown = true;
	}

	private void CFOIDECBMDP()
	{
		if (AIJKOENIJFL.ContainsKey("#PETER# Weapon Screen - RIGHT BUTTON - unit state: UNIT DELIVERED\t\tbutton type: ACTIVATE UNIT"))
		{
			Singleton<ServerResultsCache>.instance.BBFAEPEBENO = KHJJFPPACBP.BKFCLMMJNHK(AIJKOENIJFL["QUIT"], string.Empty);
		}
		List<DatabasePlayer> list = new List<DatabasePlayer>();
		JArray jArray = (JArray)AIJKOENIJFL["placement"];
		string text = KHJJFPPACBP.BKFCLMMJNHK(AIJKOENIJFL["1"], string.Empty);
		bool flag = true;
		foreach (JToken item in jArray)
		{
			DatabasePlayer databasePlayer = DatabasePlayer.CreateFromDatabase(item);
			if (databasePlayer.id == GameLoginManager.instance.playerId)
			{
				GameLoginManager.instance.UpdatePlayerSquadRank(databasePlayer.squadRank);
				flag = false;
			}
			list.Add(databasePlayer);
		}
		if (!flag && text == GameLoginManager.currentPlayer.squadName)
		{
			GameLoginManager.instance.RemovePlayerFromSquad();
		}
		if (AIJKOENIJFL.ContainsKey("ID_ERRORSHORTNICK"))
		{
			JArray jArray2 = (JArray)AIJKOENIJFL["ID_STARTERASSIGNMENTSEXPIRED"];
			if (jArray2.Count > 1)
			{
				Debug.Log("S");
			}
			string text2 = "Unit_Upgrade";
			foreach (JToken item2 in jArray2)
			{
				HHFHFANGCEJ hHFHFANGCEJ = HHFHFANGCEJ.ONADBGMFLOB(item2);
				GNOIPPHBAKA gNOIPPHBAKA = hHFHFANGCEJ as GNOIPPHBAKA;
				if (gNOIPPHBAKA != null)
				{
					Debug.Log("DecalManagerData" + gNOIPPHBAKA.KHLGDCHJJPB.name);
					gNOIPPHBAKA.KHLGDCHJJPB.awaitingSquadMember = false;
					Singleton<AwaitingSquadMembersManager>.instance.ANEMDIOMNLL(gNOIPPHBAKA.KHLGDCHJJPB);
					Singleton<AwaitingSquadMembersManager>.instance.LCFLGLMHKBF(gNOIPPHBAKA);
					text2 += string.Format("ID_OVERTIME", gNOIPPHBAKA.KHLGDCHJJPB.name, gNOIPPHBAKA.KHLGDCHJJPB.id);
				}
			}
			Debug.Log(text2);
		}
		Singleton<ServerResultsCache>.instance.Insert<List<DatabasePlayer>>("B" + text, list, DateTime.Now.AddMinutes(400.0), (DatabaseAction)(-89));
		AANECPGDMGM aANECPGDMGM = Singleton<ServerResultsCache>.instance.MKKMNBIBCFM(text);
		if (aANECPGDMGM != null)
		{
			aANECPGDMGM.FOICGJEPBGL = list.Count;
			Singleton<ServerResultsCache>.instance.Insert<AANECPGDMGM>("ID_CONFIRM_PURCHASEFAILED" + text, aANECPGDMGM, DateTime.Now.AddMinutes(571.0), (DatabaseAction)(-149));
		}
	}

	private void NMBLBCKKINC()
	{
		Debug.Log("Automatic_Equip");
	}

	private static string FKHJMMCANDJ(List<Tuple<string, string>> GMDJHENPLHB)
	{
		for (int i = 0; i < GMDJHENPLHB.Count; i++)
		{
			if (GMDJHENPLHB[i].Value1 == "OrderId" || GMDJHENPLHB[i].Value1 == "IosTransactionId")
			{
				return GMDJHENPLHB[i].Value2;
			}
		}
		return null;
	}

	private void NKAOOCDDFPF()
	{
		Singleton<ServerResultsCache>.instance.squadSearchResult = new List<AANECPGDMGM>();
		Singleton<ServerResultsCache>.instance.squadSearchIsLocal = !AIJKOENIJFL.ContainsKey("Error Deserializing JSON for ") || KHJJFPPACBP.FOJOKBCNBCO(AIJKOENIJFL["ID_FEATURE_RELOAD-FANCY"]);
		JArray jArray = (JArray)AIJKOENIJFL["Rewards"];
		for (int i = 0; i < jArray.Count; i += 0)
		{
			Singleton<ServerResultsCache>.instance.JCALAMBKKNN().Add(AANECPGDMGM.CPJAMAJJDHL(jArray[i]));
		}
	}

	private static int NGJDFBOFJMK(Card JDEMAFGJGLD, Card NOJFJANOHEB)
	{
		return JDEMAFGJGLD.rarityNumber.CompareTo(NOJFJANOHEB.rarityNumber);
	}

	private void GJEBHBKEMHP()
	{
		Debug.Log("ArenaLives");
		GuiElementSingle<JoiningSquadDialog>.instance.PPCMFJIHNOI(false);
	}

	private void GDNAPODCNCI()
	{
		string text = KHJJFPPACBP.BKFCLMMJNHK(AIJKOENIJFL["CardId"], string.Empty);
		Debug.Log("Crafted warcard id from server: " + text);
		int nMIJMHLENMM = Singleton<BeanstalkServerManager>.instance.currentTimestamp - CardCraftingManager.instance.data.end;
		Singleton<EventTrackingManager>.instance.HFFGGKNEJJD(text, nMIJMHLENMM);
		CardCraftingManager.instance.ClaimWarcard(text);
	}

	private void FODDBJKDPNJ()
	{
		LoadingDialog.Hide();
		Debug.Log("Beanstalk: On Remove Login");
		AccountType accountType = (AccountType)KHJJFPPACBP.PELILBMKGHE(AIJKOENIJFL["AccountType"]);
		string playerName = KHJJFPPACBP.BKFCLMMJNHK(AIJKOENIJFL["Name"], string.Empty);
		string newGuestPassword = string.Empty;
		string newGuestId = string.Empty;
		if (accountType == AccountType.Guest)
		{
			newGuestPassword = KHJJFPPACBP.BKFCLMMJNHK(AIJKOENIJFL["guestPassword"], string.Empty);
			newGuestId = KHJJFPPACBP.BKFCLMMJNHK(AIJKOENIJFL["guestId"], string.Empty);
		}
		GameLoginManager.instance.RemoveLoginData(accountType, playerName, newGuestPassword, newGuestId);
	}

	private void FABILEDDNIM()
	{
		long num = KHJJFPPACBP.OOAIMCEBPOK(AIJKOENIJFL["Gold"], 0L);
		long num2 = KHJJFPPACBP.OOAIMCEBPOK(AIJKOENIJFL["Warbucks"], 0L);
		Singleton<Wallet>.instance.IGDGGPOJPHL(num, num2, 0L, 0L);
		if (num > 0)
		{
			Singleton<EventTrackingManager>.instance.RegisterGoldIn("Claim_Reward", (int)num);
		}
		if (num2 > 0)
		{
			Singleton<EventTrackingManager>.instance.RegisterWBIn("Claim_Reward", (int)num2);
		}
		if (!AIJKOENIJFL.ContainsKey("Rewards"))
		{
			return;
		}
		Debug.LogError("GOT REWARDS!!");
		foreach (JToken item in (JArray)AIJKOENIJFL["Rewards"])
		{
			Singleton<DailyRewardManager>.instance.ParseReward(item);
		}
	}

	public static string KOMJCLFNFIC()
	{
		return "JKoZIhvcNAQkBFhN2b2p0YXNpdnJAZ";
	}

	private void NADNNCBNJAC()
	{
		Singleton<ServerResultsCache>.instance.squadSearchResult = new List<AANECPGDMGM>();
		Singleton<ServerResultsCache>.instance.squadSearchIsLocal = AIJKOENIJFL.ContainsKey("IsLocal") && KHJJFPPACBP.FOJOKBCNBCO(AIJKOENIJFL["IsLocal"]);
		JArray jArray = (JArray)AIJKOENIJFL["Items"];
		for (int i = 0; i < jArray.Count; i++)
		{
			Singleton<ServerResultsCache>.instance.squadSearchResult.Add(AANECPGDMGM.MAINIENLLIL(jArray[i]));
		}
	}

	private void JHFEDHCMCKD()
	{
		Debug.Log("BS: player succesfully accepted to squad");
		if (AIJKOENIJFL.ContainsKey("joinedPlayer"))
		{
			DatabasePlayer databasePlayer = DatabasePlayer.CreateFromDatabase((JToken)AIJKOENIJFL["joinedPlayer"]);
			Singleton<ServerResultsCache>.instance.HHEKOPEGCCG(databasePlayer);
			Singleton<AwaitingSquadMembersManager>.instance.OnPlayerAcceptedOrDeclined(databasePlayer.id, false);
			Singleton<BeanstalkServerManager>.instance.DataWasLoaded(DatabaseAction.GetAllSquadMembers);
		}
		DatabasePlayer currentPlayer = GameLoginManager.currentPlayer;
		Singleton<BeanstalkServerManager>.instance.IIFBHBOKGKA(currentPlayer.squadName, true);
	}

	private void JJJDPDMGNKH()
	{
		PlayerAnalytics.instance.data.customizationShown = true;
	}

	private void JPHKHHNNIOA()
	{
		Debug.Log("#VOJTA# ON GET NEW DAILY MISSIONS");
		DailyMissionsManager.instance.LoadFromJsonString(KHJJFPPACBP.BKFCLMMJNHK(AIJKOENIJFL["DailyMissionsData"], string.Empty));
	}

	private void ELDJABHIMEP()
	{
		Debug.LogError("Take arena life!");
		if (AIJKOENIJFL.ContainsKey("ArenaLives"))
		{
			WarArena.instance.UpdateLives(KHJJFPPACBP.PELILBMKGHE(AIJKOENIJFL["ArenaLives"]));
			if ((int)WarArena.instance.data.lives <= 0)
			{
				DFOBJMMDJPG();
			}
		}
	}

	private void PINPJIIBOAC()
	{
		WaitingDialog.PNEPDNHKIKD();
		GameLoginManager.instance.RemovePlayerFromSquad();
		if (AIJKOENIJFL.ContainsKey("Amount"))
		{
			Debug.Log("Buy_Weapon_Upgrade");
			List<string> list = JsonConvert.DeserializeObject<List<string>>(KHJJFPPACBP.BKFCLMMJNHK(AIJKOENIJFL["ID_READYTIME"], string.Empty));
			foreach (string item in list)
			{
				Debug.Log("Days_Since_Install" + item + "twitterLogin");
				CardManager.instance.AddCard(item);
			}
		}
		Singleton<EventTrackingManager>.instance.RegisterSquadActivity("MainScene*.unity");
	}

	[CompilerGenerated]
	private static void IGLLMHKPABF()
	{
		GameLoginManager.Relog();
	}

	private void CGEBFOELAFD()
	{
		if (AIJKOENIJFL.ContainsKey("DemotedPlayer"))
		{
			DatabasePlayer databasePlayer = DatabasePlayer.CreateFromDatabase((JToken)AIJKOENIJFL["DemotedPlayer"]);
			Singleton<ServerResultsCache>.instance.OBDFPOKLBJO(databasePlayer);
			GuiScreenSingle<SquadScreen>.instance.BBNLILBDOEC.ServerResponseCame(DatabaseAction.DemotePlayer, databasePlayer.id);
			Singleton<BeanstalkServerManager>.instance.DataWasLoaded(DatabaseAction.GetAllSquadMembers);
			Singleton<EventTrackingManager>.instance.RegisterSquadActivity("Demote_Player");
		}
	}

	private static void DFHNIENKDGJ()
	{
		GameLoginManager.Relog();
	}

	private void ILMBENLPAJD()
	{
		int num = KHJJFPPACBP.PELILBMKGHE(AIJKOENIJFL["LastUpdate"]);
		FBBKCGLIIOB.EHKKAOLJMCF(num);
		Singleton<DogTagManager>.instance.CAHCIHHBALK(KHJJFPPACBP.PELILBMKGHE(AIJKOENIJFL["Seconds"]), num);
	}

	[CompilerGenerated]
	private static void JDCFKOLHEHJ()
	{
		GameLoginManager.Relog();
	}

	public void HKDMABGDJHH(IJEAJGCCHEF FBFJNHLKJEC, DatabaseAction MHLAAHNPMFG, List<Tuple<string, string>> GMDJHENPLHB)
	{
		HBJBOIMFDAM.GOEHBPFDMLM(FBFJNHLKJEC, null, MHLAAHNPMFG, GMDJHENPLHB);
	}

	private void KOHGDBEDGOI()
	{
		Debug.Log("On Debug add Goodies");
		LoadingDialog.Hide();
		NCNNKGNJNOH((JToken)AIJKOENIJFL["PlayerData"], false);
		GuiScreenSingle<ArmyScreen>.instance.UpdateArmy();
	}

	[CompilerGenerated]
	private static int BKOJPACDAJL(Card JDEMAFGJGLD, Card NOJFJANOHEB)
	{
		return JDEMAFGJGLD.rarityNumber.CompareTo(NOJFJANOHEB.rarityNumber);
	}

	private void KGIHKMDPIOA()
	{
		Debug.Log("BS: On Skip Assignemnt");
		AssignmentsManager.instance.LoadData(KHJJFPPACBP.BKFCLMMJNHK(AIJKOENIJFL["AssignmentData"], string.Empty));
	}

	private void JKNGDCBCEPK()
	{
		if (AIJKOENIJFL.ContainsKey("PromotedPlayer"))
		{
			JToken jToken = (JToken)AIJKOENIJFL["PromotedPlayer"];
			DatabasePlayer databasePlayer = DatabasePlayer.CreateFromDatabase(jToken);
			if (jToken["PromotedPlayerId"] != null)
			{
				databasePlayer.id = KHJJFPPACBP.BKFCLMMJNHK("PromotedPlayerId", "S", jToken, string.Empty);
			}
			Singleton<ServerResultsCache>.instance.OBDFPOKLBJO(databasePlayer);
			GuiScreenSingle<SquadScreen>.instance.BBNLILBDOEC.ServerResponseCame(DatabaseAction.PromotePlayer, databasePlayer.id);
			Singleton<BeanstalkServerManager>.instance.DataWasLoaded(DatabaseAction.GetAllSquadMembers);
			Singleton<EventTrackingManager>.instance.RegisterSquadActivity("Promote_Player");
		}
	}

	private void NAKEIPOABBD()
	{
		Debug.Log("On Login to Custom playerAccount");
		DatabasePlayer databasePlayer = DatabasePlayer.CreateFromDatabase((JToken)AIJKOENIJFL["Player"]);
		AccountType accountType = (AccountType)KHJJFPPACBP.PELILBMKGHE(AIJKOENIJFL["AccountType"]);
		string id = databasePlayer.id;
		switch (accountType)
		{
		case AccountType.Facebook:
			Debug.Log("USPECH POKUSU O LOGIN NA FB!!!");
			id = databasePlayer.facebookId.ToString(CultureInfo.InvariantCulture);
			GameLoginManager.instance.UpdateGCId(databasePlayer.gameCenterId);
			break;
		case AccountType.GameCenter:
			Debug.Log("USPECH POKUSU O LOGIN NA GC!!!");
			id = databasePlayer.gameCenterId;
			break;
		case AccountType.GooglePlay:
			Debug.Log("USPECH POKUSU O LOGIN NA GP!!!");
			id = databasePlayer.googlePlayId;
			break;
		}
		if (AIJKOENIJFL.ContainsKey("MaintenanceMessage"))
		{
			Debug.LogError("GOT MAINTENANCE MESSAGE IN LOGIN TO ACCOUNT");
			HHFHFANGCEJ hHFHFANGCEJ = HHFHFANGCEJ.MAINIENLLIL((JToken)AIJKOENIJFL["MaintenanceMessage"]);
			if (hHFHFANGCEJ != null)
			{
				Singleton<MessageManager>.instance.AddMessage(hHFHFANGCEJ);
			}
		}
		GameLoginManager.instance.SavePlayer(databasePlayer, id, KHJJFPPACBP.BKFCLMMJNHK(AIJKOENIJFL["Token"], string.Empty), KHJJFPPACBP.BKFCLMMJNHK(AIJKOENIJFL["Password"], string.Empty), accountType);
	}

	private void DFOBJMMDJPG()
	{
		int flawless = WarArena.instance.data.flawless;
		int fCDIFINLKIA = WarArena.instance.FPLIPHCJGFO.FCDIFINLKIA;
		bool flag = false;
		StatsManager.instance.arenaBattles++;
		WarArena.instance.data.matches++;
		if (AIJKOENIJFL.ContainsKey("GameReward"))
		{
			Singleton<ServerResultsCache>.instance.OGDMBIKJOIL = new IIGFODGJBFA((JToken)AIJKOENIJFL["GameReward"]);
			LevelManager.instance.experience += Singleton<ServerResultsCache>.instance.OGDMBIKJOIL.DDOJBLAODGI();
		}
		if (AIJKOENIJFL.ContainsKey("Rental"))
		{
			Debug.Log("RENTAL OFFER");
			GALPKPPCFJN((JToken)AIJKOENIJFL["Rental"]);
		}
		if (AIJKOENIJFL.ContainsKey("ArenaLives"))
		{
			WarArena.instance.data.lives = KHJJFPPACBP.PELILBMKGHE(AIJKOENIJFL["ArenaLives"]);
		}
		if (AIJKOENIJFL.ContainsKey("ArenaWins"))
		{
			WarArena.instance.data.wins = KHJJFPPACBP.PELILBMKGHE(AIJKOENIJFL["ArenaWins"]);
		}
		if (AIJKOENIJFL.ContainsKey("TopRun"))
		{
			WarArena.instance.data.topRun = KHJJFPPACBP.PELILBMKGHE(AIJKOENIJFL["TopRun"]);
			Debug.Log("NEW TOP RUN = " + WarArena.instance.data.topRun);
		}
		if (AIJKOENIJFL.ContainsKey("Flawless"))
		{
			WarArena.instance.data.flawless = KHJJFPPACBP.PELILBMKGHE(AIJKOENIJFL["Flawless"]);
			Debug.Log("NEW FLAWLESS = " + WarArena.instance.data.flawless);
		}
		if (AIJKOENIJFL.ContainsKey("HeartDialog"))
		{
			Singleton<MessageManager>.instance.AddMessage(new NOIBBLPEDAG(WarArena.instance.FPLIPHCJGFO.INFLHPGMEOB));
		}
		if (AIJKOENIJFL.ContainsKey("Lootbox"))
		{
			Debug.LogError("RECEIVED LOOTBOX");
			WarArena.instance.GCEEMAHCAJB = new IKGCOGIODMO((JToken)AIJKOENIJFL["Lootbox"]);
			Singleton<EventTrackingManager>.instance.ArenaLootbox(WarArena.instance.data.wins, WarArena.instance.GCEEMAHCAJB);
			StatsManager.instance.arenaLootboxes++;
		}
		else
		{
			WarArena.instance.GCEEMAHCAJB = null;
		}
		if (AIJKOENIJFL.ContainsKey("Scraps"))
		{
			int num = KHJJFPPACBP.PELILBMKGHE(AIJKOENIJFL["Scraps"]);
			Debug.Log("Arena Lost - Scraps received = " + num);
			Singleton<MessageManager>.instance.AddMessage(new HODMKPGAPAF(num, false));
			if ((int)WarArena.instance.data.lives == 0)
			{
				Singleton<EventTrackingManager>.instance.ArenaFinished(WarArena.instance.data.wins, WarArena.instance.data.runs);
			}
			else
			{
				Singleton<EventTrackingManager>.instance.ArenaExpired(WarArena.instance.data.wins, WarArena.instance.data.lives, WarArena.instance.data.heartDialogShown);
			}
			Debug.LogFormat("Arena Lost - you gain scraps. You have {0} lives.", WarArena.instance.data.lives);
		}
		if ((int)WarArena.instance.data.wins == WarArena.instance.FPLIPHCJGFO.NFOELJINGGN.Count)
		{
			bool flag2 = AIJKOENIJFL.ContainsKey("Shields");
			if (flag2)
			{
				StatsManager.instance.arenaFlawless++;
			}
			Singleton<EventTrackingManager>.instance.ArenaFinished((!flag2) ? ((int)WarArena.instance.data.wins) : 999, WarArena.instance.data.runs);
		}
		if (AIJKOENIJFL.ContainsKey("VisualType") && AIJKOENIJFL.ContainsKey("VisualTimestamp"))
		{
			string visualType = KHJJFPPACBP.BKFCLMMJNHK(AIJKOENIJFL["VisualType"], string.Empty);
			int visualTimestamp = KHJJFPPACBP.PELILBMKGHE(AIJKOENIJFL["VisualTimestamp"]);
			WarArena.instance.data.visualType = visualType;
			WarArena.instance.data.visualTimestamp = visualTimestamp;
			GameLoginManager.currentPlayer.visualType = visualType;
			GameLoginManager.currentPlayer.visualTimestamp = visualTimestamp;
		}
		if (AIJKOENIJFL.ContainsKey("Shields"))
		{
			int shields = KHJJFPPACBP.PELILBMKGHE(AIJKOENIJFL["Shields"]);
			if (WarArena.instance.data.shields == 0)
			{
				Singleton<MessageManager>.instance.AddMessage(new CDJFMONGAGP());
			}
			WarArena.instance.data.shields = shields;
		}
		if (AIJKOENIJFL.ContainsKey("DecalId") && AIJKOENIJFL.ContainsKey("DecalExpiresOn"))
		{
			string text = KHJJFPPACBP.BKFCLMMJNHK(AIJKOENIJFL["DecalId"], string.Empty);
			int eFFDGCBOEFG = KHJJFPPACBP.PELILBMKGHE(AIJKOENIJFL["DecalExpiresOn"]);
			PlayerVisual visual = CamosManager.instance.GetVisual(text);
			if (visual == null)
			{
				Debug.LogErrorFormat("Visual id \"{0}\" is not present on client", text);
			}
			else
			{
				bool flag3 = !visual.isBought;
				visual.PIAKMCDMHKJ(eFFDGCBOEFG);
				if (flag3)
				{
					flag = true;
					Singleton<MessageManager>.instance.AddMessage(new BLJJKJKHKAF(visual, WarArena.instance.data.wins));
				}
			}
		}
		if (AIJKOENIJFL.ContainsKey("BlackMarketOffer"))
		{
			BlackMarketManager.instance.LoadBMData(KHJJFPPACBP.BKFCLMMJNHK(AIJKOENIJFL["BlackMarketOffer"], string.Empty));
			BlackMarketManager.instance.ShowOffers();
		}
		if (flawless != WarArena.instance.data.flawless)
		{
			StatsManager.instance.OnNewFlawless();
			if (flawless == 0)
			{
				int fMNCEFJEDOF = WarArena.instance.data.shields - Singleton<BeanstalkServerManager>.instance.currentTimestamp;
				Singleton<MessageManager>.instance.AddMessage(new GMAKDLKICNJ(fMNCEFJEDOF, fCDIFINLKIA));
			}
			else
			{
				Singleton<MessageManager>.instance.AddMessage(new PPPKJFHMBPK(fCDIFINLKIA, true));
			}
		}
		else if ((int)WarArena.instance.data.wins == fCDIFINLKIA && !flag)
		{
			Singleton<MessageManager>.instance.AddMessage(new PPPKJFHMBPK(fCDIFINLKIA, false));
		}
		Singleton<AchievementsManager>.instance.EvaluateAchievements(Achievement.NOLHKBIFMLB.AfterGameOnServerResponse);
	}

	private void INNPDDAJBPN()
	{
		string text = ((!AIJKOENIJFL.ContainsKey("Finished")) ? "not finished" : "finished");
		Debug.Log("ON FINISH PLAYER LEAGUE, RESULT =" + text);
	}

	private void KPINHONNIFH()
	{
		Debug.Log("BS: On Get Full Squad Info");
		if (AIJKOENIJFL.ContainsKey("SquadWarsId"))
		{
			Singleton<ServerResultsCache>.instance.BBFAEPEBENO = KHJJFPPACBP.BKFCLMMJNHK(AIJKOENIJFL["SquadWarsId"], string.Empty);
		}
		LEBLKGEOHCC();
		HPGJJDLEOCL();
	}

	private static void GADHGHNEKPA()
	{
		GameLoginManager.Relog();
	}

	private void GFAFALCFDIO(IJEAJGCCHEF FBFJNHLKJEC)
	{
		FIPCAFCHKHM fIPCAFCHKHM = new FIPCAFCHKHM();
		switch (FBFJNHLKJEC)
		{
		case (IJEAJGCCHEF)0:
			Debug.Log("YES");
			ConfirmDialog.IGCMBKLNIDB(Localization.Localize("Special pack content: type: {0} rarity: {1} amount: {2}{3}"), Localization.Localize("Id"), delegate(ConfirmDialog PHHJDIGEOPJ, bool NCMHGPNPEJM)
			{
				if (NCMHGPNPEJM)
				{
					Debug.Log("create new account and add FB");
					DialogManager.instance.HideAllDialogs();
					Singleton<DailyRewardManager>.instance.LNAIDLKGCFN = null;
					GameLoginManager.instance.DeletePlayerAccount();
					GameLoginManager.instance.CreateNewAccount(false);
				}
				else
				{
					Debug.Log("logout from FB");
					GameLoginManager.instance.LogoutFromFacebook(true);
					LoadingDialog.Hide();
				}
			}, Localization.Localize("ID_TOCOMPLETE"), Localization.Localize("ID_GC_LOGIN_TUTORIAL_TITLE"));
			break;
		case IJEAJGCCHEF.Success:
		{
			fIPCAFCHKHM.IOFHDGKGFBG = KHJJFPPACBP.BKFCLMMJNHK(AIJKOENIJFL["leagueId"], string.Empty);
			string hECDGAPMDHJ = KHJJFPPACBP.BKFCLMMJNHK(AIJKOENIJFL["Wrong_Unit"], string.Empty);
			fIPCAFCHKHM.EGLIJCPPLIP = KHJJFPPACBP.BKFCLMMJNHK(AIJKOENIJFL["https://itunes.apple.com/app/warfriends/id"], string.Empty);
			int lPGGKFLFGGN = KHJJFPPACBP.PELILBMKGHE(AIJKOENIJFL["unit {0} start {1} end {2} current {3} activation needed {4} bought {5}"], 1);
			int oCFJAJCKLDH = KHJJFPPACBP.PELILBMKGHE(AIJKOENIJFL["S"]);
			LoadingDialog.Hide();
			GuiElementSingle<UserExistsDialog>.instance.CJNMLPANNPD((AccountType)5, fIPCAFCHKHM.FDKMOFHAEFN, hECDGAPMDHJ, lPGGKFLFGGN, oCFJAJCKLDH, Localization.Localize("localPlayerLeaderboard"));
			break;
		}
		}
	}

	public void CFDAMDCBHPL(IJEAJGCCHEF FBFJNHLKJEC, DatabaseAction MHLAAHNPMFG, List<Tuple<string, string>> GMDJHENPLHB)
	{
		HBJBOIMFDAM.GOEHBPFDMLM(FBFJNHLKJEC, null, MHLAAHNPMFG, GMDJHENPLHB);
	}

	private void PCJEEBJCBAI(List<Tuple<string, string>> GMDJHENPLHB)
	{
		Debug.Log("In App Delivered");
		WaitingDialog.Hide();
		string text = KHJJFPPACBP.BKFCLMMJNHK(AIJKOENIJFL["Id"], string.Empty);
		string fJLBLLLEELD = "Warbucks";
		if (AIJKOENIJFL.ContainsKey("Gold"))
		{
			long num = KHJJFPPACBP.OOAIMCEBPOK(AIJKOENIJFL["Gold"], 0L);
			Singleton<Wallet>.instance.AIBJABEBKKE(num);
			fJLBLLLEELD = "Gold";
			if (AIJKOENIJFL.ContainsKey("IsDaily"))
			{
				Singleton<BeanstalkServerManager>.instance.NBJBKFEPJJC.AddDailyGoldBooster();
				string iNFLHPGMEOB = text + FBBKCGLIIOB.CEKEMOGEJBC();
				Singleton<MessageManager>.instance.AddMessage(new EKPKEMFBNLP(num, 0, iNFLHPGMEOB, false));
			}
			Singleton<EventTrackingManager>.instance.RegisterGoldIn(text, (int)num);
		}
		if (AIJKOENIJFL.ContainsKey("Warbucks"))
		{
			long num2 = KHJJFPPACBP.OOAIMCEBPOK(AIJKOENIJFL["Warbucks"], 0L);
			Singleton<Wallet>.instance.HHLLLPAANOE(num2);
			Singleton<EventTrackingManager>.instance.RegisterWBIn(text, (int)num2);
		}
		bool flag = true;
		if (AIJKOENIJFL.ContainsKey("SubscriptionBought"))
		{
			flag = KHJJFPPACBP.FOJOKBCNBCO(AIJKOENIJFL["SubscriptionBought"]);
			if (AIJKOENIJFL.ContainsKey("ExpireTime"))
			{
				SubscriptionManager.instance.UpdateSubscription(KHJJFPPACBP.PELILBMKGHE(AIJKOENIJFL["ExpireTime"]));
			}
			if (AIJKOENIJFL.ContainsKey("dogTagTimerLock"))
			{
				Singleton<DogTagManager>.instance.ELLJNHLPDNF = KHJJFPPACBP.PELILBMKGHE(AIJKOENIJFL["dogTagTimerLock"]);
			}
			if (AIJKOENIJFL.ContainsKey("SubscriptionNoChange") && KHJJFPPACBP.FOJOKBCNBCO(AIJKOENIJFL["SubscriptionNoChange"]))
			{
				return;
			}
			Singleton<EventTrackingManager>.instance.ALEEKCLMJLA(flag, AIJKOENIJFL.ContainsKey("trial") && KHJJFPPACBP.PELILBMKGHE(AIJKOENIJFL["trial"]) == 1, false);
		}
		HNFBGELNFIC(AIJKOENIJFL);
		Tuple<float, string> tuple = Singleton<BeanstalkServerManager>.instance.BBIEEHPFDDL.LOIBJHKOPKP(text);
		bool kCBGHGFELIA = PlayerAnalytics.instance.data.GetInappCount() == 0;
		Singleton<EventTrackingManager>.instance.RegisterInapp(text, kCBGHGFELIA, fJLBLLLEELD);
		string text2 = Singleton<BeanstalkServerManager>.instance.BBIEEHPFDDL.LAAAEGEENMA(text);
		Singleton<EventTrackingManager>.instance.RegisterKochavaInApp(text, tuple.Value1, fJLBLLLEELD, text2);
		Singleton<EventTrackingManager>.instance.RegisterFacebookInApp(text, tuple.Value1, fJLBLLLEELD, text2);
		PlayerAnalytics.instance.AddTransaction(142, text, 0, 0, tuple.Value1);
		Singleton<EventTrackingManager>.instance.RegisterAwsAnalyticsInApp(text, tuple.Value1, tuple.Value2, FKHJMMCANDJ(GMDJHENPLHB), text2);
		Singleton<EventTrackingManager>.instance.RegisterInApp(text, tuple.Value1, tuple.Value2, FKHJMMCANDJ(GMDJHENPLHB), text2);
		if (flag)
		{
			ConfirmDialog.ShowAlert(Localization.Localize("ID_CONFIRM_THANKYOU"), Localization.Localize("ID_CONFIRM_THANKYOUPURCHASE"));
			DialogManager.instance.ShowRateAppDialog(false);
		}
	}

	private void LJBIDGKODLN()
	{
		long num = KHJJFPPACBP.OOAIMCEBPOK(AIJKOENIJFL["Gold"], 0L);
		Singleton<DogTagManager>.instance.RefillAllDogtags();
		Singleton<Wallet>.instance.OFHCEFPOCMI(num);
		Singleton<EventTrackingManager>.instance.RegisterEconomyEvent("Buy_Dogtags_With_Gold", (int)num);
		Singleton<EventTrackingManager>.instance.RegisterGoldOut("Buy_DogTags", (int)num);
		Singleton<EventTrackingManager>.instance.DDIEAJKJMFL(KKFOLKGHOJE.RefillDogTags);
	}

	private void BGHANIMKJBP()
	{
	}

	private void HAHKHENNEAL()
	{
		if (!AIJKOENIJFL.ContainsKey("+{0}"))
		{
			FBBKCGLIIOB.HIHAPFGDIGP(KHJJFPPACBP.PELILBMKGHE(AIJKOENIJFL["#PETER# League Arc "], 1));
		}
	}

	private void HPGJJDLEOCL()
	{
		if (AIJKOENIJFL.ContainsKey("SquadWarsId"))
		{
			Singleton<ServerResultsCache>.instance.BBFAEPEBENO = KHJJFPPACBP.BKFCLMMJNHK(AIJKOENIJFL["SquadWarsId"], string.Empty);
		}
		List<DatabasePlayer> list = new List<DatabasePlayer>();
		JArray jArray = (JArray)AIJKOENIJFL["SquadMembers"];
		string text = KHJJFPPACBP.BKFCLMMJNHK(AIJKOENIJFL["SquadId"], string.Empty);
		bool flag = false;
		foreach (JToken item in jArray)
		{
			DatabasePlayer databasePlayer = DatabasePlayer.CreateFromDatabase(item);
			if (databasePlayer.id == GameLoginManager.instance.playerId)
			{
				GameLoginManager.instance.UpdatePlayerSquadRank(databasePlayer.squadRank);
				flag = true;
			}
			list.Add(databasePlayer);
		}
		if (!flag && text == GameLoginManager.currentPlayer.squadName)
		{
			GameLoginManager.instance.RemovePlayerFromSquad();
		}
		if (AIJKOENIJFL.ContainsKey("SquadMessages"))
		{
			JArray jArray2 = (JArray)AIJKOENIJFL["SquadMessages"];
			if (jArray2.Count > 0)
			{
				Debug.Log("I Got New Squad Messages");
			}
			string text2 = "These players came from server as awaiting to squad:\n";
			foreach (JToken item2 in jArray2)
			{
				HHFHFANGCEJ hHFHFANGCEJ = HHFHFANGCEJ.MAINIENLLIL(item2);
				GNOIPPHBAKA gNOIPPHBAKA = hHFHFANGCEJ as GNOIPPHBAKA;
				if (gNOIPPHBAKA != null)
				{
					Debug.Log("Awaiting Squad Member = " + gNOIPPHBAKA.KHLGDCHJJPB.name);
					gNOIPPHBAKA.KHLGDCHJJPB.awaitingSquadMember = true;
					Singleton<AwaitingSquadMembersManager>.instance.AddAwaitingMember(gNOIPPHBAKA.KHLGDCHJJPB);
					Singleton<AwaitingSquadMembersManager>.instance.AddToMC(gNOIPPHBAKA);
					text2 += string.Format("Player name:{0} Player id:{1}\n", gNOIPPHBAKA.KHLGDCHJJPB.name, gNOIPPHBAKA.KHLGDCHJJPB.id);
				}
			}
			Debug.Log(text2);
		}
		Singleton<ServerResultsCache>.instance.Insert<List<DatabasePlayer>>("squadMembers" + text, list, DateTime.Now.AddMinutes(1.0), DatabaseAction.GetAllSquadMembers);
		AANECPGDMGM aANECPGDMGM = Singleton<ServerResultsCache>.instance.MKKMNBIBCFM(text, true);
		if (aANECPGDMGM != null)
		{
			aANECPGDMGM.FOICGJEPBGL = list.Count;
			Singleton<ServerResultsCache>.instance.Insert<AANECPGDMGM>("squad" + text, aANECPGDMGM, DateTime.Now.AddMinutes(1.0));
		}
	}

	private void KIKPAKPICDB()
	{
		Debug.Log("BS: On change language.");
		WaitingDialog.Hide();
		if (DebugSettings.debugEnabled)
		{
			Application.Quit();
		}
	}

	private void NCNNKGNJNOH(JToken DIGPAIOFOFE, bool DLAKGAPDBGF = true)
	{
		List<Card> list = null;
		Dictionary<string, CardManager.CardData> dictionary = null;
		if (Singleton<GameController>.instance.isTutorial)
		{
			list = new List<Card>(CardManager.instance.obtainedCards);
			Debug.Log("saved obtained cards: " + list.Count);
			Debug.Log("Cards on saved data: " + CardManager.instance.data.cardData.Count);
			dictionary = new Dictionary<string, CardManager.CardData>(CardManager.instance.data.cardData);
		}
		DatabaseSerializedObject.LoadObjects(DIGPAIOFOFE);
		if (DIGPAIOFOFE["Midnight"] != null)
		{
			int iDEBKDPMPGM = KHJJFPPACBP.PELILBMKGHE("Midnight", "N", DIGPAIOFOFE);
			FBBKCGLIIOB.BDPLOPBMHAB = iDEBKDPMPGM;
		}
		int jJBHBKCGLGK = KHJJFPPACBP.PELILBMKGHE("DogTagSeconds", "N", DIGPAIOFOFE);
		int bBPAMDDFNDM = KHJJFPPACBP.PELILBMKGHE("DogTagLastUpdate", "N", DIGPAIOFOFE);
		int oONMBBJECGA = KHJJFPPACBP.PELILBMKGHE("DogTagMax", "N", DIGPAIOFOFE);
		Singleton<DogTagManager>.instance.CAHCIHHBALK(jJBHBKCGLGK, bBPAMDDFNDM, oONMBBJECGA);
		if (DIGPAIOFOFE["Subscription"] != null)
		{
			JToken jToken = (JToken)JsonConvert.DeserializeObject(KHJJFPPACBP.BKFCLMMJNHK(DIGPAIOFOFE["Subscription"]["S"], string.Empty), typeof(JToken));
			if (jToken["expireTime"] != null)
			{
				SubscriptionManager.instance.UpdateSubscription(Convert.ToInt32(jToken["expireTime"].ToString()));
			}
			if (jToken["dogTagTimerLock"] != null)
			{
				Singleton<DogTagManager>.instance.ELLJNHLPDNF = Convert.ToInt32(jToken["dogTagTimerLock"].ToString());
			}
			else
			{
				Singleton<DogTagManager>.instance.ELLJNHLPDNF = Singleton<BeanstalkServerManager>.instance.currentTimestamp;
			}
		}
		if (DIGPAIOFOFE["TutorialData"] != null)
		{
			PlayerAnalytics.instance.tutorialFinished = true;
			if (Singleton<GameController>.instance.isTutorial)
			{
				Singleton<GameController>.instance.SwitchToSinglePlayer();
				Singleton<GameController>.instance.StopAllTutorials();
			}
			if (GuiElementSingle<TutorialDialog>.instance.isShowed)
			{
				GuiElementSingle<TutorialDialog>.instance.HideDialog();
			}
		}
		MFADLJHJNAJ = Singleton<GameController>.instance.isTutorial;
		if (MFADLJHJNAJ)
		{
			Debug.Log("adding cards: " + list.Count);
			if (list != null)
			{
				CardManager.instance.obtainedCards.AddRange(list);
			}
			if (dictionary != null)
			{
				CardManager.instance.data.cardData = new Dictionary<string, CardManager.CardData>(dictionary);
			}
			Debug.Log("Cards on saved data: " + CardManager.instance.data.cardData.Count);
			TutorialManagerStage1.instance.CheckAfterDownload();
			TutorialManagerStage2.instance.CheckAfterDownload();
			return;
		}
		long aFOPDKIJGHL = KHJJFPPACBP.OOAIMCEBPOK("Gold", "N", DIGPAIOFOFE, 0L);
		long kLKKKMJCMOM = KHJJFPPACBP.OOAIMCEBPOK("WarBucks", "N", DIGPAIOFOFE, 0L);
		int level = KHJJFPPACBP.PELILBMKGHE("Level", "N", DIGPAIOFOFE);
		int loadedLevelExperience = KHJJFPPACBP.PELILBMKGHE("LevelExperience", "N", DIGPAIOFOFE);
		long loadedExperience = KHJJFPPACBP.OOAIMCEBPOK("Experience", "N", DIGPAIOFOFE, 0L);
		int loadedArmyPower = KHJJFPPACBP.PELILBMKGHE("ArmyPower", "N", DIGPAIOFOFE);
		Singleton<VipManager>.instance.vipExpiration = ((DIGPAIOFOFE["Vip"] != null) ? KHJJFPPACBP.PELILBMKGHE("Vip", "N", DIGPAIOFOFE) : 0);
		Singleton<VipManager>.instance.vipStart = ((DIGPAIOFOFE["VipStart"] != null) ? KHJJFPPACBP.PELILBMKGHE("VipStart", "N", DIGPAIOFOFE) : 0);
		Singleton<VipManager>.instance.LoadNewPlayer();
		LevelManager.instance.LoadData(level, loadedLevelExperience, loadedExperience, loadedArmyPower);
		Singleton<Wallet>.instance.EHKKAOLJMCF(aFOPDKIJGHL, kLKKKMJCMOM);
		if (DIGPAIOFOFE["Tickets"] != null)
		{
			long pEFPOGOLNJD = KHJJFPPACBP.OOAIMCEBPOK("Tickets", "N", DIGPAIOFOFE, 0L);
			Singleton<Wallet>.instance.InitTickets(pEFPOGOLNJD);
		}
		if (DIGPAIOFOFE["Scraps"] != null)
		{
			long gFJEEJMNGJD = KHJJFPPACBP.OOAIMCEBPOK("Scraps", "N", DIGPAIOFOFE, 0L);
			Singleton<Wallet>.instance.InitScraps(gFJEEJMNGJD);
		}
		if (PlayerAnalytics.instance.data.squadCreationsCount > 0)
		{
			PlayerAnalytics.instance.data.squadCreationsCount--;
		}
		if (PlayerAnalytics.instance.data.matchesToNextLootboxes == 0)
		{
			PlayerAnalytics.instance.data.matchesToNextLootboxes = (int)(float)Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.LootboxAfterBattles).FLOATVALUE;
		}
		Debug.Log(string.Format("Loaded values during loading data from PlayerAnalytics : lastSeenSquadChatTimeStampDB = {0}, squadCreationsCount = {1}, matchesToNextLootboxes = {2}", PlayerAnalytics.instance.data.lastSeenSquadChatTimeStampDB, PlayerAnalytics.instance.data.squadCreationsCount, PlayerAnalytics.instance.data.matchesToNextLootboxes));
		if (DIGPAIOFOFE["SendLogs"] != null)
		{
			GameLoginManager.currentPlayer.sendLogsValue = KHJJFPPACBP.PELILBMKGHE("SendLogs", "N", DIGPAIOFOFE);
		}
		if (DIGPAIOFOFE["Position"] != null)
		{
			PlayerAnalytics.instance.globalPositon = KHJJFPPACBP.PELILBMKGHE("Position", "N", DIGPAIOFOFE);
		}
		if (DIGPAIOFOFE["battlesLostInRow"] != null)
		{
			StatsManager.instance.battlesLostInRow = KHJJFPPACBP.PELILBMKGHE("battlesLostInRow", "N", DIGPAIOFOFE);
		}
		if (DIGPAIOFOFE["videoAdRewardTimes"] != null)
		{
			JToken lFPFCHIJLML = (JToken)JsonConvert.DeserializeObject(KHJJFPPACBP.BKFCLMMJNHK(DIGPAIOFOFE["videoAdRewardTimes"]["S"], string.Empty), typeof(JToken));
			Singleton<EventTrackingManager>.instance.getAdlimits(lFPFCHIJLML);
		}
		ALJKAAMHHLB.POPONJAMPDF("ServerResponseHandler.LoadPlayerData");
		Singleton<BeanstalkServerManager>.instance.PlayerDataWasLoaded(DLAKGAPDBGF);
		if (DIGPAIOFOFE["FacebookName"] != null)
		{
			GameLoginManager.instance.facebookName = DIGPAIOFOFE["FacebookName"]["S"].ToString();
		}
	}

	private void CMLJJBCKEDG(List<Tuple<string, string>> GMDJHENPLHB)
	{
		LoadingDialog.Hide();
		WaitingDialog.Hide();
		NCNNKGNJNOH((JToken)AIJKOENIJFL["PlayerData"], false);
		SoundsManager.Instance.PlaySound(SoundsManager.KJGDNLHKPOG.CoinPurchase);
		if (AIJKOENIJFL.ContainsKey("PackId"))
		{
			string text = (string)AIJKOENIJFL["PackId"];
			Tuple<float, string> tuple = Singleton<BeanstalkServerManager>.instance.BBIEEHPFDDL.LOIBJHKOPKP(text);
			PlayerAnalytics.instance.AddTransaction(130, text, 0, 0, tuple.Value1);
			if (!AIJKOENIJFL.ContainsKey("IsRestore"))
			{
				ConfirmDialog.ShowAlert(Localization.Localize("ID_CONFIRM_THANKYOU"), Localization.Localize("ID_CONFIRM_THANKYOUPURCHASE"));
				string text2 = Singleton<BeanstalkServerManager>.instance.BBIEEHPFDDL.LAAAEGEENMA(text);
				Singleton<EventTrackingManager>.instance.RegisterKochavaInApp(text, tuple.Value1, "Pack", text2);
				Singleton<EventTrackingManager>.instance.RegisterFacebookInApp(text, tuple.Value1, "Pack", text2);
				Singleton<EventTrackingManager>.instance.RegisterAwsAnalyticsInApp(text, tuple.Value1, tuple.Value2, FKHJMMCANDJ(GMDJHENPLHB), text2);
				Singleton<EventTrackingManager>.instance.RegisterInApp(text, tuple.Value1, tuple.Value2, FKHJMMCANDJ(GMDJHENPLHB), text2);
				Singleton<EventTrackingManager>.instance.RegisterBuyPackEvent(text);
				string buyOfferEventLocation = Singleton<BeanstalkServerManager>.instance.GetBuyOfferEventLocation();
				if (!string.IsNullOrEmpty(buyOfferEventLocation))
				{
					Singleton<EventTrackingManager>.instance.DNKPEPIPDPH(buyOfferEventLocation, text);
				}
				int packGold = Singleton<GameVariables>.instance.GetPackGold(text);
				int packWarbucks = Singleton<GameVariables>.instance.GetPackWarbucks(text);
				if (packGold > 0)
				{
					Singleton<EventTrackingManager>.instance.RegisterGoldIn(text, packGold);
				}
				if (packWarbucks > 0)
				{
					Singleton<EventTrackingManager>.instance.RegisterWBIn(text, packWarbucks);
				}
				DialogManager.instance.ShowRateAppDialog(false);
			}
		}
		if (AIJKOENIJFL.ContainsKey("VipReward1"))
		{
			Debug.Log("response contain VipReward");
			string text3 = KHJJFPPACBP.BKFCLMMJNHK(AIJKOENIJFL["VipReward1"], string.Empty);
			string text4 = KHJJFPPACBP.BKFCLMMJNHK(AIJKOENIJFL["VipReward2"], string.Empty);
			string aPGKPOOHGFK = "a";
			if (AIJKOENIJFL.ContainsKey("VipRewardForDay"))
			{
				aPGKPOOHGFK = KHJJFPPACBP.BKFCLMMJNHK(AIJKOENIJFL["VipRewardForDay"], string.Empty);
			}
			Singleton<MessageManager>.instance.AddMessage(new NGGINCOPKKJ(text3, text4, aPGKPOOHGFK));
			CardManager.instance.AddCard(text3);
			CardManager.instance.AddCard(text4);
		}
		HNFBGELNFIC(AIJKOENIJFL);
	}

	private void HIKDINCJEPB()
	{
		LoadingDialog.Hide();
		Debug.Log("Beanstalk: On Change Name");
		if (KHJJFPPACBP.PELILBMKGHE(AIJKOENIJFL["PayForRename"]) == 1)
		{
			Singleton<Wallet>.instance.OFHCEFPOCMI(PlayerAnalytics.instance.renameGoldPrice);
		}
		PlayerAnalytics.instance.data.renameCount = KHJJFPPACBP.PELILBMKGHE(AIJKOENIJFL["RenameCount"]);
		GameLoginManager.instance.SavePlayerName(KHJJFPPACBP.BKFCLMMJNHK(AIJKOENIJFL["Name"], string.Empty));
	}

	private void FLGFIIFFNKB()
	{
		if (AIJKOENIJFL.ContainsKey("Player"))
		{
			DatabasePlayer databasePlayer = DatabasePlayer.CreateFromDatabase((JToken)AIJKOENIJFL["Player"]);
			Singleton<ServerResultsCache>.instance.OBDFPOKLBJO(new DatabasePlayer
			{
				id = databasePlayer.id,
				squadRank = SquadRank.None
			});
			GuiScreenSingle<SquadScreen>.instance.BBNLILBDOEC.ServerResponseCame(DatabaseAction.KickPlayer, databasePlayer.id);
			Singleton<BeanstalkServerManager>.instance.DataWasLoaded(DatabaseAction.GetAllSquadMembers);
		}
	}

	private void MAFHBBEKBJJ()
	{
		Singleton<ServerResultsCache>.instance.playerSearchResult = new List<DatabasePlayer>();
		JArray jArray = (JArray)AIJKOENIJFL["Items"];
		for (int i = 0; i < jArray.Count; i++)
		{
			Singleton<ServerResultsCache>.instance.playerSearchResult.Add(DatabasePlayer.CreateFromDatabase(jArray[i]));
		}
	}

	private void KBDCCLLIEIN()
	{
		Debug.Log("Beanstalk: Crash Report Succesfully Sent");
	}

	private void LANLNPCFGGL()
	{
		List<CCNAEIGGMNK> nMJKMJBFFFJ = new List<CCNAEIGGMNK>();
		if (AIJKOENIJFL.ContainsKey("com/google/android/gms/common/api/Status"))
		{
			Dictionary<string, string> dictionary = JsonConvert.DeserializeObject<Dictionary<string, string>>(KHJJFPPACBP.BKFCLMMJNHK(AIJKOENIJFL["ID_LOGOUT"], string.Empty));
			if (dictionary != null)
			{
				nMJKMJBFFFJ = CCNAEIGGMNK.AKPKOEIMCOH(dictionary);
				GuiElementSingle<LootBoxDialog>.instance.ShowDialogMoreBoxes(nMJKMJBFFFJ);
			}
		}
		string text = ((!AIJKOENIJFL.ContainsKey("WALLET - bought WB {0}")) ? string.Empty : KHJJFPPACBP.BKFCLMMJNHK(AIJKOENIJFL["Vip"], string.Empty));
		long num = ((!AIJKOENIJFL.ContainsKey("Assignment: Error, task definition not found for id = ")) ? 1 : KHJJFPPACBP.OOAIMCEBPOK(AIJKOENIJFL["N"], 0L));
		Debug.Log(string.Format("ID_TUTORIAL_UPGRADEUNIT_6", text, num));
		Singleton<EventTrackingManager>.instance.RegisterBuyLootboxes(text, nMJKMJBFFFJ);
		Singleton<PurchaseProtection>.instance.LootboxResponseCame(text);
		Singleton<EventTrackingManager>.instance.RegisterGoldOut("S", (int)num);
		Singleton<Wallet>.instance.OFHCEFPOCMI(num);
	}

	[CompilerGenerated]
	private static void IBNMGAEKADM()
	{
		GameLoginManager.Relog();
	}

	private void MHGEJEBDDPI()
	{
		string text = KHJJFPPACBP.BKFCLMMJNHK(AIJKOENIJFL["SetHitByUnit , "], string.Empty);
		Debug.Log("CardId" + text);
		int nMIJMHLENMM = Singleton<BeanstalkServerManager>.instance.currentTimestamp - CardCraftingManager.instance.data.end;
		Singleton<EventTrackingManager>.instance.HFFGGKNEJJD(text, nMIJMHLENMM);
		CardCraftingManager.instance.ClaimWarcard(text);
	}

	private void KPPNCJBMDPE(DatabaseAction MHLAAHNPMFG)
	{
		Singleton<GameController>.instance.gameEndServerResponse = GameController.AHDGGJJAOEO.Success;
		if (AIJKOENIJFL.ContainsKey("IsWarArena"))
		{
			DFOBJMMDJPG();
		}
		else if (AIJKOENIJFL.ContainsKey("IsWarPath"))
		{
			PKAHEEJBBNP();
		}
		else
		{
			DMGJCGJDDID(MHLAAHNPMFG);
		}
		if (AIJKOENIJFL.ContainsKey("SuggestedSquad"))
		{
			AANECPGDMGM aANECPGDMGM = AANECPGDMGM.MAINIENLLIL((JToken)AIJKOENIJFL["SuggestedSquad"]);
			Singleton<MessageManager>.instance.AddMessage(new NCBHACJNDOI(aANECPGDMGM));
			Debug.Log("#VOJTA# Got Suggested Squad!! Squad Name = " + aANECPGDMGM.MHPNDNJDPGE);
		}
	}

	private void DCEFNJILKJC()
	{
		Debug.Log("Beanstalk: On Send Settings");
	}

	private void CPHEDGCOAGJ(List<Tuple<string, string>> GMDJHENPLHB)
	{
		LoadingDialog.Hide();
		WaitingDialog.DNNLAHACDCK();
		NCNNKGNJNOH((JToken)AIJKOENIJFL["Try Joining room "]);
		SoundsManager.Instance.PlaySound(SoundsManager.KJGDNLHKPOG.CountdownSound, 804f);
		if (AIJKOENIJFL.ContainsKey("Time_Range"))
		{
			string text = (string)AIJKOENIJFL["ID_OFFERENDSIN"];
			Tuple<float, string> tuple = Singleton<BeanstalkServerManager>.instance.BBIEEHPFDDL.LOIBJHKOPKP(text);
			PlayerAnalytics.instance.AddTransaction(-15, text, 1, 0, tuple.Value1);
			if (!AIJKOENIJFL.ContainsKey("squadCreationsCnt"))
			{
				ConfirmDialog.CKGMDJFKNPO(Localization.Localize("squadMembers"), Localization.Localize("()Landroid/app/PendingIntent;"), 782f);
				string text2 = Singleton<BeanstalkServerManager>.instance.BBIEEHPFDDL.LAAAEGEENMA(text);
				Singleton<EventTrackingManager>.instance.RegisterKochavaInApp(text, tuple.Value1, "ammo", text2);
				Singleton<EventTrackingManager>.instance.RegisterFacebookInApp(text, tuple.Value1, "ID_SKILLSHOTHINT_LONGSHOT", text2);
				Singleton<EventTrackingManager>.instance.RegisterAwsAnalyticsInApp(text, tuple.Value1, tuple.Value2, FKHJMMCANDJ(GMDJHENPLHB), text2);
				Singleton<EventTrackingManager>.instance.RegisterInApp(text, tuple.Value1, tuple.Value2, FKHJMMCANDJ(GMDJHENPLHB), text2);
				Singleton<EventTrackingManager>.instance.RegisterBuyPackEvent(text);
				string text3 = Singleton<BeanstalkServerManager>.instance.EKEPPFLNBBH();
				if (!string.IsNullOrEmpty(text3))
				{
					Singleton<EventTrackingManager>.instance.DNKPEPIPDPH(text3, text);
				}
				int packGold = Singleton<GameVariables>.instance.GetPackGold(text);
				int num = Singleton<GameVariables>.instance.CPNAPNOFLHK(text);
				if (packGold > 0)
				{
					Singleton<EventTrackingManager>.instance.RegisterGoldIn(text, packGold);
				}
				if (num > 0)
				{
					Singleton<EventTrackingManager>.instance.RegisterWBIn(text, num);
				}
				DialogManager.instance.ShowRateAppDialog(false);
			}
		}
		if (AIJKOENIJFL.ContainsKey("Hide reconnect dialog"))
		{
			Debug.Log("Subscription");
			string text4 = KHJJFPPACBP.BKFCLMMJNHK(AIJKOENIJFL["CLUSTERGRENADE"], string.Empty);
			string text5 = KHJJFPPACBP.BKFCLMMJNHK(AIJKOENIJFL["DailyGoldDay"], string.Empty);
			string aPGKPOOHGFK = "qbz_run";
			if (AIJKOENIJFL.ContainsKey("   {0}"))
			{
				aPGKPOOHGFK = KHJJFPPACBP.BKFCLMMJNHK(AIJKOENIJFL["{0} {1}"], string.Empty);
			}
			Singleton<MessageManager>.instance.AddMessage(new NGGINCOPKKJ(text4, text5, aPGKPOOHGFK));
			CardManager.instance.AddCard(text4);
			CardManager.instance.AddCard(text5);
		}
		HNFBGELNFIC(AIJKOENIJFL);
	}

	private void AAFFKBOMPBI()
	{
		Debug.Log("Beanstalk: Photon Is Full sent");
	}

	private void LGBFFPMPEKL()
	{
		Debug.Log("BS: Squad Leader was informed about event!");
	}

	private void JABANANGFBL()
	{
		Debug.LogError("BS: Cheater report sent! PlayerID = " + AIJKOENIJFL["PlayerID"]);
	}

	private void HNPNDJPNPCK()
	{
		Debug.Log("On Accept Challenge");
	}

	private void NJJAEKGLGEK()
	{
		PlayerAnalytics.instance.data.warpathShown = true;
	}

	private void PDOBOFHANIE()
	{
		string text = KHJJFPPACBP.BKFCLMMJNHK(AIJKOENIJFL["DELIVERYTIME"], string.Empty);
		if (!string.IsNullOrEmpty(text))
		{
			Singleton<GameController>.instance.battleId = text;
		}
		Singleton<GameController>.instance.ContinueTutorialImmediately();
	}

	private void MEKAGDDHCKA()
	{
		Debug.Log("OK");
		int nextWithdraw = KHJJFPPACBP.PELILBMKGHE(AIJKOENIJFL["ID_NEWSUITCASE"], 1);
		CardManager.instance.nextWithdraw = nextWithdraw;
		PushNotificationManager.instance.ScheduleNextWithdrawNotification(nextWithdraw);
		Singleton<NotificationManager>.instance.ClientCardpoolNotifications();
		Singleton<NotificationManager>.instance.UpdateCardpoolNotifications();
	}

	private void CCACILAMEAL()
	{
		Debug.Log("BS: Player report sent!" + AIJKOENIJFL["Reported"]);
	}

	private static void IKAJNAIBEGJ()
	{
		GameLoginManager.Relog(false);
	}

	private static void KCPEGCIPPMM()
	{
		GameLoginManager.Relog();
	}

	private void PDANLGNEDEG()
	{
		Debug.Log("BS: On Get New Assignemnts");
		AssignmentsManager.instance.LoadData(KHJJFPPACBP.BKFCLMMJNHK(AIJKOENIJFL["AssignmentData"], string.Empty));
	}

	private void IEJKFGDDADD()
	{
		string text = KHJJFPPACBP.BKFCLMMJNHK(AIJKOENIJFL["Wrong_Category"], string.Empty);
		GameLoginManager.instance.AddPlayerToSquad(text, (SquadRank)KHJJFPPACBP.PELILBMKGHE(AIJKOENIJFL["0"], 1));
		if (AIJKOENIJFL.ContainsKey("{0} {1}"))
		{
			long num = KHJJFPPACBP.OOAIMCEBPOK(AIJKOENIJFL["Action "], 0L);
			Singleton<Wallet>.instance.BKFOPCDLPCJ(num);
			Singleton<MessageManager>.instance.AddMessage(new AGPANDBMDLC(IHFDGLMHHBE.Dogtag, num), true);
			string dBKEY = Singleton<GameVariables>.instance.constants.GetRow((Constants.rowIds)(-94)).DBKEY;
			PlayerAnalytics.instance.AddOneTimeReward(dBKEY);
		}
		GuiScreenSingle<SquadScreen>.instance.ShowSquadMembers();
		GuiScreenSingle<SquadScreen>.instance.GPMCMCLPHNL(GuiScreenSingle<MainScreen>.instance);
		Singleton<BeanstalkServerManager>.instance.EFEEANDLLIN((DatabaseAction)(-123));
		Singleton<EventTrackingManager>.instance.RegisterSquadActivity("Deposited Warcards: ");
		Singleton<BeanstalkServerManager>.instance.LHCLKHAOKOM(text, false);
	}

	private void CLAOLIOKIPP()
	{
		Debug.Log("Subscription Expired");
	}

	[CompilerGenerated]
	private static void LAIJBKAMEGI()
	{
		GameLoginManager.Relog();
	}

	private void DLOKBMHHLIM()
	{
		Debug.Log("#AccoutCheck# account checked and have response!");
		StringBuilder stringBuilder = new StringBuilder("#AccoutCheck# response\n");
		foreach (KeyValuePair<string, object> item in AIJKOENIJFL)
		{
			stringBuilder.AppendFormat("{0} - {1}\n", item.Key, item.Value);
		}
		Debug.Log(stringBuilder.ToString());
		if (AIJKOENIJFL.ContainsKey("resultMessage"))
		{
			string text = AIJKOENIJFL["resultMessage"].ToString();
			Debug.Log("#AccoutCheck# OnCheckExistGcAccount: " + text);
			if (text == "OK")
			{
				Debug.Log("#AccoutCheck# account exist");
				if (AIJKOENIJFL.ContainsKey("GameCenterId"))
				{
					GameLoginManager.instance.OnGamecenterUserExistDuringTutorial(AIJKOENIJFL["GameCenterId"].ToString());
				}
				else
				{
					Debug.LogError("#AccoutCheck# missing ID from server");
				}
			}
		}
		else
		{
			Debug.LogError("#AccoutCheck# Account exist check result NOT contain result message");
		}
	}

	private static void JMINDMJCEJF()
	{
		GameLoginManager.Relog(false);
	}

	private void DDIPKGOPCMK()
	{
		Debug.LogError("Mission data saved");
	}

	private void EGPLNLMMADN()
	{
		RequestBufferManager.instance.Clear();
		Singleton<MessageManager>.instance.ClearAllMessages();
		Singleton<BeanstalkServerManager>.instance.KKOKNNOPBEF();
		if (AIJKOENIJFL.ContainsKey("Squad"))
		{
			AANECPGDMGM aANECPGDMGM = AANECPGDMGM.MAINIENLLIL((JToken)AIJKOENIJFL["Squad"]);
			GameLoginManager.instance.OnPlayerDataLoadedSquadNameCheck(aANECPGDMGM.MHPNDNJDPGE);
			LEBLKGEOHCC();
		}
		else
		{
			GameLoginManager.instance.RemovePlayerFromSquad();
		}
		if (AIJKOENIJFL.ContainsKey("RemoveRewards"))
		{
			Debug.LogError("Used warcards and rewards from last match wre removed");
			BattleRewardsManager.instance.ClearAllRewards();
		}
		if (AIJKOENIJFL.ContainsKey("MaintenanceMessage"))
		{
			HHFHFANGCEJ hHFHFANGCEJ = HHFHFANGCEJ.MAINIENLLIL((JToken)AIJKOENIJFL["MaintenanceMessage"]);
			if (hHFHFANGCEJ != null)
			{
				Singleton<MessageManager>.instance.AddMessage(hHFHFANGCEJ);
			}
		}
		int beginnersLeague = (AIJKOENIJFL.ContainsKey("BeginnersLeague") ? GameLoginManager.currentPlayer.beginnersLeague : 0);
		string league = ((!AIJKOENIJFL.ContainsKey("LeagueId")) ? GameLoginManager.currentPlayer.leagueId : KHJJFPPACBP.BKFCLMMJNHK(AIJKOENIJFL["LeagueId"], string.Empty));
		int globalMedals = ((!AIJKOENIJFL.ContainsKey("Skill")) ? GameLoginManager.currentPlayer.skill : KHJJFPPACBP.PELILBMKGHE(AIJKOENIJFL["Skill"]));
		int leagueMedals = ((!AIJKOENIJFL.ContainsKey("MedalsBalance")) ? GameLoginManager.currentPlayer.medalsBalance : KHJJFPPACBP.PELILBMKGHE(AIJKOENIJFL["MedalsBalance"]));
		int remainingMatches = ((!AIJKOENIJFL.ContainsKey("PlacementMatchesRequired")) ? ((int)(float)Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.LeaguePlacementMatches).FLOATVALUE) : KHJJFPPACBP.PELILBMKGHE(AIJKOENIJFL["PlacementMatchesRequired"]));
		GameLoginManager.instance.UpdatePlayerLeagueAndMedals(beginnersLeague, league, globalMedals, leagueMedals, remainingMatches);
		if (AIJKOENIJFL.ContainsKey("UtcOffset"))
		{
			FBBKCGLIIOB.COKONGDDJEG(KHJJFPPACBP.PELILBMKGHE(AIJKOENIJFL["UtcOffset"]));
		}
		Singleton<ServerResultsCache>.instance.isSquadWarsProcessing = AIJKOENIJFL.ContainsKey("SquadWarsProcessing");
		Singleton<ServerResultsCache>.instance.isPlayerLeagueProcessing = AIJKOENIJFL.ContainsKey("PlayerLeagueProcessing");
		if (AIJKOENIJFL.ContainsKey("DeviceToken"))
		{
			string text = KHJJFPPACBP.BKFCLMMJNHK(AIJKOENIJFL["DeviceToken"], string.Empty);
			if (text != PushNotificationManager.instance.data.deviceToken)
			{
				Debug.LogWarning("Get player data: I SHOULD SEND PN DEVICET TOKEN");
				if (PushNotificationManager.instance.hasValidDeviceToken() || PushNotificationManager.instance.ArePushNotificationsEnabledOnDevice())
				{
					Debug.Log("Dialog Manager: PN dialog does not need to be shown BUT NEEDS TO BE SENT, current players device token = " + GameLoginManager.currentPlayer.deviceToken);
					PushNotificationManager.instance.EnablePushNotifications(GameLoginManager.currentPlayer.deviceToken);
				}
			}
			else
			{
				Debug.LogWarning("Get player data: NOT SENDING PN DEVICE TOKEN");
			}
		}
		else if (PushNotificationManager.instance.hasValidDeviceToken() || PushNotificationManager.instance.ArePushNotificationsEnabledOnDevice())
		{
			Debug.Log("Dialog Manager: PN dialog does not need to be shown BUT NEEDS TO BE SENT, current players device token = " + GameLoginManager.currentPlayer.deviceToken);
			PushNotificationManager.instance.EnablePushNotifications(GameLoginManager.currentPlayer.deviceToken);
		}
		if (AIJKOENIJFL.ContainsKey("LeagueEvaluation"))
		{
			FBBKCGLIIOB.ALMINMLNLHF(KHJJFPPACBP.PELILBMKGHE(AIJKOENIJFL["LeagueEvaluation"]));
			LeagueArcManager.instance.SetLeagueTimer(FBBKCGLIIOB.HFAGLEGDCPL);
			GuiScreenSingle<MainScreen>.instance.BEPFJDAJBJO.GGADAADPKHB.SetLeagueEnd(FBBKCGLIIOB.HFAGLEGDCPL);
		}
		FBBKCGLIIOB.EHKKAOLJMCF(KHJJFPPACBP.PELILBMKGHE(AIJKOENIJFL["Time"]));
		NCNNKGNJNOH((JToken)AIJKOENIJFL["PlayerData"]);
		if (AIJKOENIJFL.ContainsKey("dailyRewardData"))
		{
			string text2 = AIJKOENIJFL["dailyRewardData"].ToString();
			if (Singleton<DailyRewardManager>.instance.DailyRewardDataLoaded((JToken)AIJKOENIJFL["dailyRewardData"]) && !GuiScreenSingle<DailyRewardMonthScreen>.instance.isShowed)
			{
				DailyRewardManager.MGANBPBIOBK lNAIDLKGCFN = Singleton<DailyRewardManager>.instance.LNAIDLKGCFN;
				Singleton<MessageManager>.instance.AddMessage(new JGJIKFCHKDH(lNAIDLKGCFN.LIJBBLBLPLG + lNAIDLKGCFN.NHKKNKEAEOE * 100));
			}
		}
		if (AIJKOENIJFL.ContainsKey("WarArenaConfig"))
		{
			WarArena.instance.LoadWarArenaConfig((JToken)AIJKOENIJFL["WarArenaConfig"]);
		}
		else
		{
			Debug.LogError("NO WAR ARENA CONFIG!!!");
		}
		if (AIJKOENIJFL.ContainsKey("EventAssignmentConfig"))
		{
			string eDMMKNPFGKC = KHJJFPPACBP.BKFCLMMJNHK(AIJKOENIJFL["EventAssignmentConfig"], string.Empty);
			EventAssignmentManager.instance.PNIPPPCIBMN(eDMMKNPFGKC);
		}
		else
		{
			Debug.Log("NO EVENT ASSIGNMENT CONFIG RECEIVED!!!");
		}
		if (AIJKOENIJFL.ContainsKey("VideoFeed"))
		{
			VideoFeedManager.instance.LoadVideoFeedData((JToken)AIJKOENIJFL["VideoFeed"]);
		}
		else
		{
			Debug.LogError("NO Video Feed found!");
		}
		if (AIJKOENIJFL.ContainsKey("Scraps"))
		{
			int num = KHJJFPPACBP.PELILBMKGHE(AIJKOENIJFL["Scraps"]);
			Debug.Log("Arena Lost - Scraps received = " + num);
			Singleton<MessageManager>.instance.AddMessage(new HODMKPGAPAF(num, true));
			Singleton<EventTrackingManager>.instance.ArenaExpired(WarArena.instance.data.wins, WarArena.instance.data.lives, WarArena.instance.data.heartDialogShown);
			Debug.LogFormat("Arena Expired - you gain scraps. You have {0} lives.", WarArena.instance.data.lives);
		}
		if (AIJKOENIJFL.ContainsKey("HeartDialog"))
		{
			Debug.Log("Heart dialog should be shown in arena screen now");
			Singleton<MessageManager>.instance.AddMessage(new NOIBBLPEDAG(WarArena.instance.FPLIPHCJGFO.INFLHPGMEOB));
		}
		if (AIJKOENIJFL.ContainsKey("ShowArenaDialog"))
		{
			Debug.Log("SHOW WAR ARENA DIALOG!!");
			string iNFLHPGMEOB = WarArena.instance.FPLIPHCJGFO.INFLHPGMEOB;
			bool isOpened = WarArena.instance.isOpened;
			Singleton<MessageManager>.instance.AddMessage(new IFBNMHNJFPD(iNFLHPGMEOB, isOpened));
		}
		if (AIJKOENIJFL.ContainsKey("DailyGold"))
		{
			int num2 = KHJJFPPACBP.PELILBMKGHE(AIJKOENIJFL["DailyGold"]);
			int dHMHOEGPDAP = KHJJFPPACBP.PELILBMKGHE(AIJKOENIJFL["DailyGoldDay"]);
			string dailyGoldInAppId = Singleton<BeanstalkServerManager>.instance.NBJBKFEPJJC.GetDailyGoldInAppId();
			int getDailyGoldInAppDays = PlayerAnalytics.instance.data.getDailyGoldInAppDays;
			bool dLALMKLEIMK = KHJJFPPACBP.FOJOKBCNBCO(AIJKOENIJFL["DailyBonus"]);
			Singleton<MessageManager>.instance.AddMessage(new EKPKEMFBNLP(num2, dHMHOEGPDAP, dailyGoldInAppId, dLALMKLEIMK));
		}
		if (AIJKOENIJFL.ContainsKey("NewAssignments"))
		{
			Debug.Log("New Assignments!");
			List<AssignmentsManager.DatabaseAssignment> assignments = AssignmentsManager.instance.data.assignments;
			for (int i = 0; i < assignments.Count; i++)
			{
				if (i < 3 && i >= assignments.Count - 3)
				{
					AssignmentsManager.DatabaseAssignment eFEIDBFDDBE = assignments[i];
					Singleton<EventTrackingManager>.instance.MINMHKPKOMN(eFEIDBFDDBE, AssignmentsManager.instance.data.issued, false);
				}
			}
			Singleton<EventTrackingManager>.instance.RegisterDailyVisit();
		}
		if (AIJKOENIJFL.ContainsKey("VipReward1"))
		{
			string jAOIALFFMNI = KHJJFPPACBP.BKFCLMMJNHK(AIJKOENIJFL["VipReward1"], string.Empty);
			string fMLEGCOCCEM = KHJJFPPACBP.BKFCLMMJNHK(AIJKOENIJFL["VipReward2"], string.Empty);
			string aPGKPOOHGFK = "a";
			if (AIJKOENIJFL.ContainsKey("VipRewardForDay"))
			{
				aPGKPOOHGFK = KHJJFPPACBP.BKFCLMMJNHK(AIJKOENIJFL["VipRewardForDay"], string.Empty);
			}
			Singleton<MessageManager>.instance.AddMessage(new NGGINCOPKKJ(jAOIALFFMNI, fMLEGCOCCEM, aPGKPOOHGFK));
		}
		if (AIJKOENIJFL.ContainsKey("LapsedPlayerRewardId"))
		{
			string kJBPJOMHNKB = KHJJFPPACBP.BKFCLMMJNHK(AIJKOENIJFL["LapsedPlayerRewardId"], string.Empty);
			Singleton<MessageManager>.instance.AddMessage(new IHKHFKHENEJ(kJBPJOMHNKB));
		}
		if (AIJKOENIJFL.ContainsKey("Rental"))
		{
			JToken jToken = (JToken)AIJKOENIJFL["Rental"];
			string text3 = KHJJFPPACBP.BKFCLMMJNHK(jToken["Id"], string.Empty);
			string text4 = KHJJFPPACBP.BKFCLMMJNHK(jToken["Amount"], string.Empty);
			DKHAOLDJLMK dKHAOLDJLMK = (DKHAOLDJLMK)KHJJFPPACBP.HNMDPGKPLNK(jToken["Type"]);
			bool jIFJOMPDNPN = false;
			string iEFGICLEKEE = jToken["nextGenerate"].ToString();
			Debug.LogError("NEW RENTAL " + text3 + ", " + text4 + ", " + dKHAOLDJLMK);
			Singleton<MessageManager>.instance.AddMessage(new EJOOEEEHKJM(text3, text4, dKHAOLDJLMK, jIFJOMPDNPN, iEFGICLEKEE));
		}
		if (AIJKOENIJFL.ContainsKey("BattleId") && !MFADLJHJNAJ)
		{
			Debug.Log("START PLAYING TUTORIAL");
			Singleton<GameController>.instance.battleId = KHJJFPPACBP.BKFCLMMJNHK(AIJKOENIJFL["BattleId"], string.Empty);
			Singleton<GameController>.instance.ContinueOrStartTutorial();
		}
		MFADLJHJNAJ = false;
		if (AIJKOENIJFL.ContainsKey("fuseData"))
		{
			Singleton<EventTrackingManager>.instance.fuseboxxService.LBNACCMGPMP(AIJKOENIJFL["fuseData"] as string);
		}
		if (AIJKOENIJFL.ContainsKey("SpecialPackFromServer"))
		{
			Singleton<OfferManager>.instance.UpdateSpecialPackFromServer((JToken)AIJKOENIJFL["SpecialPackFromServer"], false);
		}
		Singleton<OfferManager>.instance.UpdateFromServer((!AIJKOENIJFL.ContainsKey("specialOffers")) ? null : ((JToken)AIJKOENIJFL["specialOffers"]));
		GameLoginManager.instance.changeGCAfterTutorialInProgress = false;
		if (AIJKOENIJFL.ContainsKey("subscriptionAnalytics"))
		{
			JToken jToken2 = (JToken)AIJKOENIJFL["subscriptionAnalytics"];
			bool dNFOLCJEEDP = false;
			bool kNIBODJCBCE = false;
			if (jToken2["subscribed"] != null)
			{
				Debug.Log("#DEBUG_50# " + jToken2["subscribed"].ToString());
				dNFOLCJEEDP = KHJJFPPACBP.HNMDPGKPLNK(jToken2["subscribed"]) == 1;
			}
			if (jToken2["trial"] != null)
			{
				Debug.Log("#DEBUG_50# " + jToken2["trial"].ToString());
				kNIBODJCBCE = KHJJFPPACBP.FOJOKBCNBCO(jToken2["trial"].ToString());
			}
			Singleton<EventTrackingManager>.instance.ALEEKCLMJLA(dNFOLCJEEDP, kNIBODJCBCE, true);
		}
	}

	private void DGFHKNLOBDH()
	{
		JArray jArray = (JArray)AIJKOENIJFL["Items"];
		if (jArray.Count > 1000)
		{
			Debug.LogError(string.Format("Recieved {0} messages:", jArray.Count));
		}
		for (int i = 0; i < jArray.Count; i++)
		{
			JToken oGNGMBLDAOP = jArray[i];
			HHFHFANGCEJ hHFHFANGCEJ = HHFHFANGCEJ.MAINIENLLIL(oGNGMBLDAOP);
			if (hHFHFANGCEJ != null)
			{
				Singleton<MessageManager>.instance.AddMessage(hHFHFANGCEJ);
			}
		}
		jArray = null;
	}

	private void CPGGGLJEDPG()
	{
		Debug.Log("On Get PLayer Info");
		if (AIJKOENIJFL["PlayerInfo"] == null)
		{
			Debug.LogError("From server came null PlayerInfo!");
			return;
		}
		DatabasePlayer databasePlayer = DatabasePlayerInfo.CreateFromDatabase((JToken)AIJKOENIJFL["PlayerInfo"]);
		if (AIJKOENIJFL.ContainsKey("SquadWarsId"))
		{
			Singleton<ServerResultsCache>.instance.BBFAEPEBENO = KHJJFPPACBP.BKFCLMMJNHK(AIJKOENIJFL["SquadWarsId"], string.Empty);
		}
		Singleton<ServerResultsCache>.instance.Insert<DatabasePlayerInfo>("playerInfo" + databasePlayer.id, databasePlayer, DateTime.Now.AddMinutes(1.0));
	}

	private static void GEMPPJNIEHG()
	{
		GameLoginManager.Relog();
	}

	private void GIJEHFFGLOC(DatabaseAction MHLAAHNPMFG)
	{
		Singleton<GameController>.instance.gameEndServerResponse = GameController.AHDGGJJAOEO.None;
		if (AIJKOENIJFL.ContainsKey(" , "))
		{
			DFOBJMMDJPG();
		}
		else if (AIJKOENIJFL.ContainsKey("ID_SILVER"))
		{
			PKAHEEJBBNP();
		}
		else
		{
			DMGJCGJDDID(MHLAAHNPMFG);
		}
		if (AIJKOENIJFL.ContainsKey("StartMovementAtTimeRPC"))
		{
			AANECPGDMGM aANECPGDMGM = AANECPGDMGM.MAINIENLLIL((JToken)AIJKOENIJFL["Name"]);
			Singleton<MessageManager>.instance.AddMessage(new NCBHACJNDOI(aANECPGDMGM), true);
			Debug.Log("AA:BB:CC:DD:EE:FF" + aANECPGDMGM.MHPNDNJDPGE);
		}
	}

	private void AFMMPGDELBH()
	{
		Debug.Log("PrepareBotForDeathMatch 7");
		GuiElementSingle<JoiningSquadDialog>.instance.PPCMFJIHNOI(false);
	}

	[CompilerGenerated]
	private static void GLLOGMOAIJK()
	{
		GameLoginManager.Relog();
	}

	private void LABBAJMFJOI()
	{
		WaitingDialog.Hide();
	}

	[CompilerGenerated]
	private static void MPPAKPBJAAD()
	{
		GameLoginManager.Relog();
	}

	private void OOIMBPCOENI()
	{
		Debug.Log("Beanstalk: On Add One Time Reward");
		if (!AIJKOENIJFL.ContainsKey("RewardId"))
		{
			return;
		}
		string text = KHJJFPPACBP.BKFCLMMJNHK(AIJKOENIJFL["RewardId"], string.Empty);
		PlayerAnalytics.instance.AddOneTimeReward(text);
		bool flag = text == "WeaponTutorial";
		bool flag2 = text == "UnitTutorial";
		bool flag3 = flag || flag2;
		bool flag4 = AIJKOENIJFL.ContainsKey("WasAdded");
		Debug.Log("One Time Reward: " + ((!flag4) ? "not added, called already!!" : "was added"));
		Debug.Log(string.Concat("ADDED GOLD ", AIJKOENIJFL["Gold"], " for ", text));
		long num = KHJJFPPACBP.OOAIMCEBPOK(AIJKOENIJFL["Gold"], 0L);
		long num2 = 0L;
		if (flag4)
		{
			Singleton<Wallet>.instance.COLJGNLBEII(num, !flag3);
			if (!flag3 && num > 0)
			{
				Singleton<MessageManager>.instance.AddMessage(new AGPANDBMDLC(IHFDGLMHHBE.Gold, num));
			}
		}
		if (AIJKOENIJFL.ContainsKey("WarBucks"))
		{
			Debug.Log(string.Concat("ADDED WB ", AIJKOENIJFL["WarBucks"], " for ", text));
			num2 = KHJJFPPACBP.OOAIMCEBPOK(AIJKOENIJFL["WarBucks"], 0L);
			if (flag4)
			{
				Singleton<Wallet>.instance.NFLMMKJBKEJ(num2, !flag3);
			}
		}
		if (flag)
		{
			TutorialManagerStage4.instance.RewardCame((int)num2, (int)num);
		}
		if (flag2)
		{
			TutorialManagerStage5.instance.RewardCame((int)num2, (int)num);
		}
	}

	private void NCAKLEOEDBO(DatabaseAction MHLAAHNPMFG)
	{
		Singleton<BeanstalkServerManager>.instance.MatchMakingGameWasCreated(true);
		FBBKCGLIIOB.EHKKAOLJMCF(KHJJFPPACBP.PELILBMKGHE(AIJKOENIJFL["Time"]));
		if (AIJKOENIJFL.ContainsKey("BattleId"))
		{
			Singleton<GameController>.instance.battleId = KHJJFPPACBP.BKFCLMMJNHK(AIJKOENIJFL["BattleId"], string.Empty);
		}
		if (AIJKOENIJFL.ContainsKey("Seconds"))
		{
			Singleton<DogTagManager>.instance.CAHCIHHBALK(KHJJFPPACBP.PELILBMKGHE(AIJKOENIJFL["Seconds"]), KHJJFPPACBP.PELILBMKGHE(AIJKOENIJFL["LastUpdate"]));
		}
		if (Singleton<DogTagManager>.instance.currentDogtags < 1)
		{
			Singleton<EventTrackingManager>.instance.DDIEAJKJMFL(KKFOLKGHOJE.RunOutOfDogtags);
		}
	}

	private void OKGFAFJANGG()
	{
		string text = KHJJFPPACBP.BKFCLMMJNHK(AIJKOENIJFL["SquadId"], string.Empty);
		GameLoginManager.instance.AddPlayerToSquad(text, (SquadRank)KHJJFPPACBP.PELILBMKGHE(AIJKOENIJFL["PlayerRank"]));
		if (AIJKOENIJFL.ContainsKey("Gold"))
		{
			long num = KHJJFPPACBP.OOAIMCEBPOK(AIJKOENIJFL["Gold"], 0L);
			Singleton<Wallet>.instance.COLJGNLBEII(num);
			Singleton<MessageManager>.instance.AddMessage(new AGPANDBMDLC(IHFDGLMHHBE.Gold, num));
			string dBKEY = Singleton<GameVariables>.instance.constants.GetRow(Constants.rowIds.GoldRewardFirstTimeSquad).DBKEY;
			PlayerAnalytics.instance.AddOneTimeReward(dBKEY);
		}
		GuiScreenSingle<SquadScreen>.instance.ShowSquadMembers();
		GuiScreenSingle<SquadScreen>.instance.previousScreen = GuiScreenSingle<MainScreen>.instance;
		Singleton<BeanstalkServerManager>.instance.DataWasLoaded(DatabaseAction.UserAddedToSquadSuccess);
		Singleton<EventTrackingManager>.instance.RegisterSquadActivity("Squad_Join");
		Singleton<BeanstalkServerManager>.instance.LHCLKHAOKOM(text);
	}

	[CompilerGenerated]
	private static void HDEMFKOPDGK()
	{
		GameLoginManager.Relog();
	}

	private void HOCGNAKEHNB()
	{
		if (!AIJKOENIJFL.ContainsKey("IsOffline"))
		{
			FBBKCGLIIOB.EHKKAOLJMCF(KHJJFPPACBP.PELILBMKGHE(AIJKOENIJFL["Time"]));
		}
	}

	private void HIAJFPBNAFN()
	{
		Debug.Log("On Level Squad Up");
		AANECPGDMGM aANECPGDMGM = AANECPGDMGM.MAINIENLLIL((JToken)AIJKOENIJFL["Squad"]);
		Singleton<BeanstalkServerManager>.instance.SquadUpdateWasReceived(aANECPGDMGM);
		Singleton<ServerResultsCache>.instance.Insert<AANECPGDMGM>("squad" + aANECPGDMGM.MHPNDNJDPGE, aANECPGDMGM, DateTime.Now.AddMinutes(2.0));
	}

	private static void FAHOCMANKDH()
	{
		GameLoginManager.Relog(false);
	}

	private void IEPANBKNHIA()
	{
		Debug.LogError("On Accept Special Offer");
		JArray jArray = JsonConvert.DeserializeObject<JArray>(KHJJFPPACBP.BKFCLMMJNHK(AIJKOENIJFL["RequestsResults"], string.Empty));
		string text = string.Empty;
		int num = jArray.Count - 1;
		for (int i = 0; i < jArray.Count; i++)
		{
			JToken gDJGCNJEMIL = jArray[i];
			text = JIMIKHFDEFC(gDJGCNJEMIL, text, i == num);
		}
		if (!string.IsNullOrEmpty(text))
		{
			WarningDialog.ShowError(string.Format("{0} {1}", Localization.Localize("ID_CONFIRM_SERVERCOULDNOTCOMPLETED"), text), Localization.Localize("ID_CONFIRM_ERROR"), 0f, null, string.Empty);
		}
	}

	private void PDBKBNILFPD()
	{
		Debug.Log("Beanstalk: On Add GameCenter");
		string gameCenterId = KHJJFPPACBP.BKFCLMMJNHK(AIJKOENIJFL["GameCenterId"], string.Empty);
		GameLoginManager.instance.SaveGameCenterData(gameCenterId);
	}

	private static void DCAPMIKHOCC(ConfirmDialog PHHJDIGEOPJ, bool NCMHGPNPEJM)
	{
		if (NCMHGPNPEJM)
		{
			Debug.Log("'ID_MONTH_'0");
			DialogManager.instance.HideAllDialogs();
			Singleton<DailyRewardManager>.instance.LNAIDLKGCFN = null;
			GameLoginManager.instance.DeletePlayerAccount();
			GameLoginManager.instance.CreateNewAccount(true);
		}
		else
		{
			Debug.Log("ID_GUI_SILVER");
			GameLoginManager.instance.LogoutFromFacebook(true);
			LoadingDialog.Hide();
		}
	}

	private void JNPGAOGEIPK()
	{
		PlayerAnalytics.instance.data.customizationShown = false;
	}

	private void GCGBPMPECDO()
	{
		WaitingDialog.Hide();
		GameLoginManager.instance.RemovePlayerFromSquad();
		if (AIJKOENIJFL.ContainsKey("DepositedCards"))
		{
			Debug.Log("Got player deposited Cards => adding cards to CardManagerData");
			List<string> list = JsonConvert.DeserializeObject<List<string>>(KHJJFPPACBP.BKFCLMMJNHK(AIJKOENIJFL["DepositedCards"], string.Empty));
			foreach (string item in list)
			{
				Debug.Log("Adding card " + item + " from deposited cards to normal cards");
				CardManager.instance.AddCard(item);
			}
		}
		Singleton<EventTrackingManager>.instance.RegisterSquadActivity("Squad_Leave");
	}

	private void HBDOKCCEKPP(IJEAJGCCHEF FBFJNHLKJEC, Constants.rowIds JLFAIPPONHK, AccountType FEPHCHKJGHD, string PGJNIAIHKDB)
	{
		DFNGILBMEEI dFNGILBMEEI = new DFNGILBMEEI();
		dFNGILBMEEI.FEPHCHKJGHD = FEPHCHKJGHD;
		LoadingDialog.Hide();
		BHCMEPMHFMN bHCMEPMHFMN = new BHCMEPMHFMN();
		bHCMEPMHFMN.ALIKEGIJIHD = dFNGILBMEEI;
		switch (FBFJNHLKJEC)
		{
		case IJEAJGCCHEF.Success:
			Debug.Log("Beanstalk: Add Service Provider Success");
			if (AIJKOENIJFL.ContainsKey("Gold"))
			{
				long num = KHJJFPPACBP.OOAIMCEBPOK(AIJKOENIJFL["Gold"], 0L);
				Singleton<Wallet>.instance.COLJGNLBEII(num);
				Singleton<MessageManager>.instance.AddMessage(new AGPANDBMDLC(IHFDGLMHHBE.Gold, num));
				string dBKEY = Singleton<GameVariables>.instance.constants.GetRow(JLFAIPPONHK).DBKEY;
				PlayerAnalytics.instance.AddOneTimeReward(dBKEY);
			}
			GameLoginManager.instance.SaveLoginData(KHJJFPPACBP.BKFCLMMJNHK(AIJKOENIJFL[PGJNIAIHKDB + "Id"], string.Empty), KHJJFPPACBP.BKFCLMMJNHK(AIJKOENIJFL[PGJNIAIHKDB + "Name"], string.Empty), KHJJFPPACBP.BKFCLMMJNHK(AIJKOENIJFL[PGJNIAIHKDB + "Password"], string.Empty), dFNGILBMEEI.FEPHCHKJGHD);
			Singleton<GuiManager>.instance.OFJAGAELHHO();
			if (AIJKOENIJFL.ContainsKey("Vip") && AIJKOENIJFL.ContainsKey("VipStart"))
			{
				Singleton<VipManager>.instance.vipExpiration = KHJJFPPACBP.PELILBMKGHE(AIJKOENIJFL["Vip"]);
				Singleton<VipManager>.instance.vipStart = KHJJFPPACBP.PELILBMKGHE(AIJKOENIJFL["VipStart"]);
			}
			if (AIJKOENIJFL.ContainsKey("VipReward1"))
			{
				Debug.Log("response contain VipReward");
				string text = KHJJFPPACBP.BKFCLMMJNHK(AIJKOENIJFL["VipReward1"], string.Empty);
				string text2 = KHJJFPPACBP.BKFCLMMJNHK(AIJKOENIJFL["VipReward2"], string.Empty);
				string aPGKPOOHGFK = "a";
				if (AIJKOENIJFL.ContainsKey("VipRewardForDay"))
				{
					aPGKPOOHGFK = KHJJFPPACBP.BKFCLMMJNHK(AIJKOENIJFL["VipRewardForDay"], string.Empty);
				}
				Singleton<MessageManager>.instance.AddMessage(new NGGINCOPKKJ(text, text2, aPGKPOOHGFK));
				CardManager.instance.AddCard(text);
				CardManager.instance.AddCard(text2);
			}
			break;
		case IJEAJGCCHEF.AccountAlreadyCreated:
		{
			Debug.Log("Beanstalk: That account already exists! Player will choose how to proceed, provider = " + PGJNIAIHKDB);
			bHCMEPMHFMN.INFLHPGMEOB = KHJJFPPACBP.BKFCLMMJNHK(AIJKOENIJFL[PGJNIAIHKDB + "Id"], string.Empty);
			string hECDGAPMDHJ = KHJJFPPACBP.BKFCLMMJNHK(AIJKOENIJFL[PGJNIAIHKDB + "Name"], string.Empty);
			bHCMEPMHFMN.PGHCHNIDLNJ = KHJJFPPACBP.BKFCLMMJNHK(AIJKOENIJFL[PGJNIAIHKDB + "Password"], string.Empty);
			int lPGGKFLFGGN = KHJJFPPACBP.PELILBMKGHE(AIJKOENIJFL[PGJNIAIHKDB + "Level"]);
			int oCFJAJCKLDH = KHJJFPPACBP.PELILBMKGHE(AIJKOENIJFL[PGJNIAIHKDB + "Medals"]);
			GuiElementSingle<UserExistsDialog>.instance.ShowDialog(dFNGILBMEEI.FEPHCHKJGHD, bHCMEPMHFMN.LJCDGJKCNEC, hECDGAPMDHJ, lPGGKFLFGGN, oCFJAJCKLDH, string.Empty);
			break;
		}
		}
	}

	private void FLOIMADDPPC()
	{
		Dictionary<string, FHIPGDADNFG> dictionary = new Dictionary<string, FHIPGDADNFG>();
		List<FHIPGDADNFG> list = new List<FHIPGDADNFG>();
		JArray jArray = (JArray)AIJKOENIJFL["Items"];
		for (int i = 0; i < jArray.Count; i++)
		{
			FHIPGDADNFG fHIPGDADNFG = FHIPGDADNFG.MAINIENLLIL(jArray[i]);
			dictionary.Add(fHIPGDADNFG.INFLHPGMEOB, fHIPGDADNFG);
		}
		JArray jArray2 = (JArray)AIJKOENIJFL["Local"];
		for (int j = 0; j < jArray2.Count; j++)
		{
			FHIPGDADNFG fHIPGDADNFG2 = FHIPGDADNFG.MAINIENLLIL(jArray2[j]);
			if (!string.IsNullOrEmpty(fHIPGDADNFG2.INFLHPGMEOB))
			{
				list.Add(fHIPGDADNFG2);
			}
		}
		Singleton<ServerResultsCache>.instance.Insert<List<FHIPGDADNFG>>("localPlayerLeaderboard", list, DateTime.Now.AddMinutes(2.0));
		Singleton<ServerResultsCache>.instance.Insert<Dictionary<string, FHIPGDADNFG>>("globalPlayerLeaderboard", dictionary, DateTime.Now.AddMinutes(2.0));
	}

	private void FPFMCNOBKBK()
	{
		if (AIJKOENIJFL.ContainsKey("PlayerLeaguesId"))
		{
			Singleton<ServerResultsCache>.instance.DIIJOILPPOC = KHJJFPPACBP.BKFCLMMJNHK(AIJKOENIJFL["PlayerLeaguesId"], string.Empty);
		}
		Dictionary<string, DatabasePlayer> dictionary = new Dictionary<string, DatabasePlayer>();
		JArray jArray = (JArray)AIJKOENIJFL["Items"];
		for (int i = 0; i < jArray.Count; i++)
		{
			DatabasePlayer databasePlayer = DatabasePlayer.CreateFromDatabase(jArray[i]);
			dictionary.Add(databasePlayer.id, databasePlayer);
		}
		string iMOCKMIAJHN = "leagueMembers" + KHJJFPPACBP.BKFCLMMJNHK(AIJKOENIJFL["LeagueId"], string.Empty);
		if (AIJKOENIJFL.ContainsKey("LeagueEvaluation"))
		{
			int num = KHJJFPPACBP.PELILBMKGHE(AIJKOENIJFL["LeagueEvaluation"]);
			Debug.Log("PLayerLeagueEvaluation = " + num);
			FBBKCGLIIOB.ALMINMLNLHF(num);
			LeagueArcManager.instance.SetLeagueTimer(FBBKCGLIIOB.HFAGLEGDCPL);
			GuiScreenSingle<MainScreen>.instance.BEPFJDAJBJO.GGADAADPKHB.SetLeagueEnd(FBBKCGLIIOB.HFAGLEGDCPL);
		}
		Singleton<ServerResultsCache>.instance.Insert<Dictionary<string, DatabasePlayer>>(iMOCKMIAJHN, dictionary, DateTime.Now.AddMinutes(2.0));
	}

	private void EPBJGADPPMM()
	{
		Debug.LogError("BEANSTALK: ON RESTORE PACKS");
		if (!Singleton<GameController>.instance.isTutorialInProgressOrPlaned)
		{
			Debug.LogError("HIDIING");
			LoadingDialog.Hide();
		}
		else
		{
			Debug.LogError("NOT HIDING");
		}
		NCNNKGNJNOH((JToken)AIJKOENIJFL["PlayerData"], false);
		if (AIJKOENIJFL.ContainsKey("RestoredPacks"))
		{
			Debug.LogError("RESTORE PACKS = " + AIJKOENIJFL["RestoredPacks"]);
		}
	}

	private void PMGLDDGKHOL()
	{
		DatabasePlayer databasePlayer = DatabasePlayer.CreateFromDatabase((JToken)AIJKOENIJFL["1"]);
		AccountType accountType = AccountType.Guest;
		if (AIJKOENIJFL.ContainsKey("ID_ARENARULES_ONLY"))
		{
			accountType = (AccountType)KHJJFPPACBP.PELILBMKGHE(AIJKOENIJFL["AssetBundleManifest"], 1);
		}
		string id = databasePlayer.id;
		switch (accountType)
		{
		case (AccountType)7:
			id = databasePlayer.facebookId.ToString();
			break;
		case (AccountType)8:
			id = databasePlayer.gameCenterId;
			break;
		}
		GameLoginManager.instance.SavePlayer(databasePlayer, id, KHJJFPPACBP.BKFCLMMJNHK(AIJKOENIJFL["LT"], string.Empty), KHJJFPPACBP.BKFCLMMJNHK(AIJKOENIJFL["count"], string.Empty), accountType);
		NCNNKGNJNOH((JToken)AIJKOENIJFL["experiment name is "]);
		if (AIJKOENIJFL.ContainsKey("ID_GOLD"))
		{
			EGPLNLMMADN();
			return;
		}
		if (AIJKOENIJFL.ContainsKey(", stacktrace = "))
		{
			WarArena.instance.AGPLFGDABLN((JToken)AIJKOENIJFL["124 MENU WEAPON SCREEN TUTORIAL WEAPON ACTIVATED"]);
			Debug.Log("Items" + WarArena.instance.FPLIPHCJGFO.INFLHPGMEOB);
			if (AIJKOENIJFL.ContainsKey("expires"))
			{
				string iNFLHPGMEOB = WarArena.instance.FPLIPHCJGFO.INFLHPGMEOB;
				bool jHMJENBCOGE = WarArena.instance.PBGAHILNNAH();
				Singleton<MessageManager>.instance.AddMessage(new IFBNMHNJFPD(iNFLHPGMEOB, jHMJENBCOGE));
			}
		}
		else
		{
			Debug.LogError("timestamp");
		}
		FBBKCGLIIOB.HIHAPFGDIGP(KHJJFPPACBP.PELILBMKGHE(AIJKOENIJFL["Spend_Gold_On_Army"], 1));
		if (AIJKOENIJFL.ContainsKey("PlayerLevel"))
		{
			FBBKCGLIIOB.OKHEBMFBBGA(KHJJFPPACBP.PELILBMKGHE(AIJKOENIJFL["ID_CATEGORY_LOW_SG_ASSAULT"]));
			LeagueArcManager.instance.PMFIHBKMBDE(FBBKCGLIIOB.NHONPMJPEFI());
			GuiScreenSingle<MainScreen>.instance.BEPFJDAJBJO.GGADAADPKHB.NGJKOLJLCHN(FBBKCGLIIOB.MIEPNALEJJL());
		}
		Singleton<BeanstalkServerManager>.instance.KKOKNNOPBEF();
		if (AIJKOENIJFL.ContainsKey("wasEquipped"))
		{
			Debug.LogError("Experience");
			HHFHFANGCEJ hHFHFANGCEJ = HHFHFANGCEJ.OALBDJKEPNF((JToken)AIJKOENIJFL["ID_LEAGUE3"]);
			if (hHFHFANGCEJ != null)
			{
				Singleton<MessageManager>.instance.AddMessage(hHFHFANGCEJ, true);
			}
		}
		if (AIJKOENIJFL.ContainsKey("ID_INPROGRESS") && !MFADLJHJNAJ)
		{
			DialogManager.instance.HideAllDialogs();
			Debug.Log("^\\d*-\\d*$");
			Singleton<GameController>.instance.battleId = KHJJFPPACBP.BKFCLMMJNHK(AIJKOENIJFL["Purchase_Special_Offer"], string.Empty);
			Singleton<GameController>.instance.ContinueOrStartTutorial();
		}
		else
		{
			Debug.Log("Fuseboxx: Game configuration received after time ");
			Debug.LogWarning("Starter_Assignment_Completed");
			if (PushNotificationManager.instance.hasValidDeviceToken() || PushNotificationManager.instance.ArePushNotificationsEnabledOnDevice())
			{
				Debug.Log("BoughtIndex" + GameLoginManager.currentPlayer.deviceToken);
				PushNotificationManager.instance.EnablePushNotifications(GameLoginManager.currentPlayer.deviceToken);
			}
		}
		MFADLJHJNAJ = true;
		GameLoginManager.instance.changeGCAfterTutorialInProgress = true;
	}

	private void KJDFGIBJCBK()
	{
		DatabasePlayer currentPlayer = GameLoginManager.currentPlayer;
		string league = ((!AIJKOENIJFL.ContainsKey("leagueId")) ? currentPlayer.leagueId : KHJJFPPACBP.BKFCLMMJNHK(AIJKOENIJFL["leagueId"], string.Empty));
		GameLoginManager.instance.UpdatePlayerLeagueAndMedals(0, league, currentPlayer.skill, 0, 0);
	}

	private void HLFGEJLHJKE()
	{
		Debug.Log("Joined Squad Event");
		Singleton<ServerResultsCache>.instance.squadEventProgress = JMHLHIIMNIG.MAINIENLLIL((JToken)AIJKOENIJFL["SquadEventProgress"]);
		if (GuiScreenSingle<SquadScreen>.instance.isShowed)
		{
			GuiScreenSingle<SquadScreen>.instance.NILIEMMOFNN.OnJoinedSquadEvent();
		}
	}

	private void FONIFKONEBO()
	{
		Debug.Log("Squad Request Sent!");
		GuiElementSingle<JoiningSquadDialog>.instance.SetRequestSend(true);
	}

	private void LEBLKGEOHCC()
	{
		if (AIJKOENIJFL.ContainsKey("SquadWarsId"))
		{
			Singleton<ServerResultsCache>.instance.BBFAEPEBENO = KHJJFPPACBP.BKFCLMMJNHK(AIJKOENIJFL["SquadWarsId"], string.Empty);
		}
		AANECPGDMGM aANECPGDMGM = AANECPGDMGM.MAINIENLLIL((JToken)AIJKOENIJFL["Squad"]);
		if (AIJKOENIJFL.ContainsKey("SquadId"))
		{
			string mHPNDNJDPGE = KHJJFPPACBP.BKFCLMMJNHK(AIJKOENIJFL["SquadId"], string.Empty);
			if (string.IsNullOrEmpty(aANECPGDMGM.MHPNDNJDPGE))
			{
				aANECPGDMGM.MHPNDNJDPGE = mHPNDNJDPGE;
			}
		}
		if (AIJKOENIJFL.ContainsKey("SquadWarsPosition"))
		{
			int num = KHJJFPPACBP.PELILBMKGHE(AIJKOENIJFL["SquadWarsPosition"]);
			Debug.LogWarning("Squad Position = " + num);
			aANECPGDMGM.CAACHMJGMEH = num;
		}
		if (AIJKOENIJFL.ContainsKey("WarsEvaluation"))
		{
			FBBKCGLIIOB.POHGEHPOKGM(KHJJFPPACBP.PELILBMKGHE(AIJKOENIJFL["WarsEvaluation"]));
			GuiScreenSingle<LeaguesScreen>.instance.JFGEOAAOOCE.ShowSquadWarEndTime(FBBKCGLIIOB.KGMEJILKIHG);
			GuiScreenSingle<MainScreen>.instance.BEPFJDAJBJO.GGADAADPKHB.SetSquadWarsEnd(FBBKCGLIIOB.KGMEJILKIHG);
		}
		Singleton<ServerResultsCache>.instance.squadEventDefinition = ((!AIJKOENIJFL.ContainsKey("EventDefinition")) ? null : PFPAMNODNPF.MAINIENLLIL((JToken)AIJKOENIJFL["EventDefinition"]));
		Singleton<ServerResultsCache>.instance.squadEventProgress = ((!AIJKOENIJFL.ContainsKey("SquadEventProgress")) ? null : JMHLHIIMNIG.MAINIENLLIL((JToken)AIJKOENIJFL["SquadEventProgress"]));
		Singleton<ServerResultsCache>.instance.Insert<AANECPGDMGM>("squad" + aANECPGDMGM.MHPNDNJDPGE, aANECPGDMGM, DateTime.Now.AddMinutes(2.0));
		Debug.Log("Squad updated , key=squad" + aANECPGDMGM.MHPNDNJDPGE);
		Singleton<BeanstalkServerManager>.instance.DataWasLoaded(DatabaseAction.GetSquadDetails);
		Singleton<BeanstalkServerManager>.instance.SquadUpdateWasReceived(aANECPGDMGM);
	}

	private void MJEKKDGACNA()
	{
		Debug.Log("ID_CONFIRM_PROMOTETOLEADER");
		GuiElementSingle<JoiningSquadDialog>.instance.SetRequestSend(false);
	}

	[CompilerGenerated]
	private static void CBJDEOPBFJO()
	{
		GameLoginManager.Relog();
	}

	private void CDDOAAGDJMJ()
	{
		Singleton<Logs>.instance.logsSent = true;
		Singleton<Logs>.instance.logId = AIJKOENIJFL["LogId"].ToString();
		Debug.Log("Beanstalk: Log Sent, Id = " + AIJKOENIJFL["LogId"]);
	}

	private void MNCAECBJMDD()
	{
		List<AANECPGDMGM> list = new List<AANECPGDMGM>();
		JArray jArray = (JArray)AIJKOENIJFL["Items"];
		for (int i = 0; i < jArray.Count; i++)
		{
			list.Add(AANECPGDMGM.MAINIENLLIL(jArray[i]));
		}
		if (AIJKOENIJFL.ContainsKey("Local"))
		{
			JArray jArray2 = (JArray)AIJKOENIJFL["Local"];
			List<AANECPGDMGM> list2 = new List<AANECPGDMGM>();
			for (int j = 0; j < jArray2.Count; j++)
			{
				list2.Add(AANECPGDMGM.MAINIENLLIL(jArray2[j]));
			}
			Singleton<ServerResultsCache>.instance.Insert<List<AANECPGDMGM>>("localSquadLeaderboard", list2, DateTime.Now.AddMinutes(2.0));
		}
		Singleton<ServerResultsCache>.instance.Insert<List<AANECPGDMGM>>("globalSquadLeaderboard", list, DateTime.Now.AddMinutes(2.0));
	}

	private void KHHFDNBFOHE()
	{
		string text = KHJJFPPACBP.BKFCLMMJNHK(AIJKOENIJFL["BattleId"], string.Empty);
		if (!string.IsNullOrEmpty(text))
		{
			Singleton<GameController>.instance.battleId = text;
		}
		Singleton<GameController>.instance.ContinueTutorialImmediately();
	}

	private void AELMFFDHPIC()
	{
		Debug.Log("ExtraHeart");
		if (!AIJKOENIJFL.ContainsKey("game-card-ico-backstab"))
		{
			return;
		}
		string text = KHJJFPPACBP.BKFCLMMJNHK(AIJKOENIJFL["GooglePlay"], string.Empty);
		PlayerAnalytics.instance.AddOneTimeReward(text);
		bool flag = text == "reload_pistol";
		bool flag2 = text == "{0}99 RESTART";
		bool flag3 = !flag && flag2;
		bool flag4 = AIJKOENIJFL.ContainsKey("-ELITEPARTS");
		Debug.Log("haveGcId" + ((!flag4) ? "//" : "Ribbon Bug Passed "));
		object[] array = new object[1];
		array[1] = "HEAD_SANTABEARD";
		array[1] = AIJKOENIJFL["Mission data saved"];
		array[8] = "Start overtime RPC";
		array[3] = text;
		Debug.Log(string.Concat(array));
		long num = KHJJFPPACBP.OOAIMCEBPOK(AIJKOENIJFL["Bot Cards does not contain id: "], 0L);
		long num2 = 0L;
		if (flag4)
		{
			Singleton<Wallet>.instance.COLJGNLBEII(num, !flag3);
			if (!flag3 && num > 0)
			{
				Singleton<MessageManager>.instance.AddMessage(new AGPANDBMDLC(IHFDGLMHHBE.Gold, num), true);
			}
		}
		if (AIJKOENIJFL.ContainsKey("ProductPrice"))
		{
			object[] array2 = new object[5];
			array2[0] = "_FogColor";
			array2[1] = AIJKOENIJFL["Button \"{0}\" has no assigned box collider."];
			array2[4] = "BattleWarbucksRewards";
			array2[2] = text;
			Debug.Log(string.Concat(array2));
			num2 = KHJJFPPACBP.OOAIMCEBPOK(AIJKOENIJFL["TÉLÉCHARGER"], 0L);
			if (flag4)
			{
				Singleton<Wallet>.instance.EBFKEHKBAFJ(num2, flag3);
			}
		}
		if (flag)
		{
			TutorialManagerStage4.instance.RewardCame((int)num2, (int)num);
		}
		if (flag2)
		{
			TutorialManagerStage5.instance.RewardCame((int)num2, (int)num);
		}
	}

	private void GALPKPPCFJN(JToken FIPBPEFMNJE)
	{
		string text = FIPBPEFMNJE["Id"].ToString();
		string text2 = FIPBPEFMNJE["Amount"].ToString();
		DKHAOLDJLMK dKHAOLDJLMK = FIPBPEFMNJE["Type"].ToObject<DKHAOLDJLMK>();
		bool jIFJOMPDNPN = true;
		AINIEKCODDE aINIEKCODDE = FIPBPEFMNJE["accepted"].ToObject<AINIEKCODDE>();
		string iEFGICLEKEE = FIPBPEFMNJE["nextGenerate"].ToString();
		Debug.LogError(string.Format("RentalId: {0}, rentalDiscount: {1}, state {2}", text, text2, aINIEKCODDE));
		Singleton<MessageManager>.instance.AddMessage(new EJOOEEEHKJM(text, text2, dKHAOLDJLMK, jIFJOMPDNPN, iEFGICLEKEE));
		switch (dKHAOLDJLMK)
		{
		case DKHAOLDJLMK.ArmyUnit:
		{
			Debug.Log("set unit not borrowed");
			LevelManager.SavedArmySlots value2;
			if (LevelManager.instance.data.savedArmies.TryGetValue(text, out value2))
			{
				value2.borrowed = false;
			}
			else
			{
				Debug.LogError(string.Format("rental for unexist unit: {0}", text));
			}
			break;
		}
		case DKHAOLDJLMK.Weapon:
		{
			Debug.Log("set weapon not borrowed");
			LevelManager.SavedWeaponSlots value;
			if (LevelManager.instance.data.savedWeapons.TryGetValue(text, out value))
			{
				value.borrowed = false;
			}
			else
			{
				Debug.LogError(string.Format("rental for unexist weapon: {0}", text));
			}
			break;
		}
		case DKHAOLDJLMK.PlayerVisual:
			Debug.Log("set visual not borrowed");
			if (CamosManager.instance.data.visuals.ContainsKey(text))
			{
				CamosManager.instance.data.visuals[text].borrowed = false;
			}
			else
			{
				Debug.LogError(string.Format("rental for unexist visual: {0}", text));
			}
			break;
		}
	}

	private void HNKAMNMHPKC()
	{
		Debug.Log("Cards Deposited");
		if (AIJKOENIJFL.ContainsKey("NextBuddyDeposit"))
		{
			CardManager.instance.nextBuddyDeposit = KHJJFPPACBP.PELILBMKGHE(AIJKOENIJFL["NextBuddyDeposit"]);
		}
		Singleton<NotificationManager>.instance.ClientCardpoolNotifications();
		Singleton<NotificationManager>.instance.UpdateCardpoolNotifications();
	}

	private void CPIANBMHDNA()
	{
		DatabasePlayer databasePlayer = DatabasePlayer.CreateFromDatabase((JToken)AIJKOENIJFL["silverwarcard"]);
		AccountType accountType = AccountType.Guest;
		if (AIJKOENIJFL.ContainsKey("ios-marketing"))
		{
			accountType = (AccountType)KHJJFPPACBP.PELILBMKGHE(AIJKOENIJFL["menu-weapon-mp5-elite"], 1);
		}
		string id = databasePlayer.id;
		if (accountType != (AccountType)5)
		{
			if (accountType == (AccountType)5)
			{
				id = databasePlayer.gameCenterId;
			}
		}
		else
		{
			id = databasePlayer.facebookId.ToString();
		}
		GameLoginManager.instance.SavePlayer(databasePlayer, id, KHJJFPPACBP.BKFCLMMJNHK(AIJKOENIJFL["canShow"], string.Empty), KHJJFPPACBP.BKFCLMMJNHK(AIJKOENIJFL["123 MENU WEAPON SCREEN TUTORIAL WEAPON BUY CLICKED"], string.Empty), accountType);
		NCNNKGNJNOH((JToken)AIJKOENIJFL["Name"], false);
		if (AIJKOENIJFL.ContainsKey("0"))
		{
			EGPLNLMMADN();
			return;
		}
		if (AIJKOENIJFL.ContainsKey("Total_Matchmaking_Battles"))
		{
			WarArena.instance.AGPLFGDABLN((JToken)AIJKOENIJFL["BlackMarketOffer"]);
			Debug.Log("ID_FRIENDWASDISCONNECTED" + WarArena.instance.FPLIPHCJGFO.INFLHPGMEOB);
			if (AIJKOENIJFL.ContainsKey("Staging"))
			{
				string iNFLHPGMEOB = WarArena.instance.FPLIPHCJGFO.INFLHPGMEOB;
				bool isOpened = WarArena.instance.isOpened;
				Singleton<MessageManager>.instance.AddMessage(new IFBNMHNJFPD(iNFLHPGMEOB, isOpened), true);
			}
		}
		else
		{
			Debug.LogError("GameCenterProvider function OnAuthenticated() called => GC: Authenticated with ");
		}
		FBBKCGLIIOB.EHKKAOLJMCF(KHJJFPPACBP.PELILBMKGHE(AIJKOENIJFL["AccountType"], 1));
		if (AIJKOENIJFL.ContainsKey("Unit"))
		{
			FBBKCGLIIOB.DALLMJEMHFJ(KHJJFPPACBP.PELILBMKGHE(AIJKOENIJFL["Row: Rank"], 1));
			LeagueArcManager.instance.PMFIHBKMBDE(FBBKCGLIIOB.MNDGIGAOMOK());
			GuiScreenSingle<MainScreen>.instance.BEPFJDAJBJO.GGADAADPKHB.OKLOICHGJBE(FBBKCGLIIOB.OCLCPOJNJBE());
		}
		Singleton<BeanstalkServerManager>.instance.KKOKNNOPBEF();
		if (AIJKOENIJFL.ContainsKey("Can not find player with fraction "))
		{
			Debug.LogError("ID_COMPLETED");
			HHFHFANGCEJ hHFHFANGCEJ = HHFHFANGCEJ.HKDJOAOBDIN((JToken)AIJKOENIJFL["Still waiting for server\nBe patient :-)"]);
			if (hHFHFANGCEJ != null)
			{
				Singleton<MessageManager>.instance.AddMessage(hHFHFANGCEJ);
			}
		}
		if (AIJKOENIJFL.ContainsKey("onFirstPlaylistDownloaded") && !MFADLJHJNAJ)
		{
			DialogManager.instance.HideAllDialogs();
			Debug.Log("Per funzionare, WarFriends deve scaricare circa 190MB di dati extra.\nIl tempo di download può variare in base alla tua rete e posizione.\n\nVuoi proseguire?");
			Singleton<GameController>.instance.battleId = KHJJFPPACBP.BKFCLMMJNHK(AIJKOENIJFL["Sessions"], string.Empty);
			Singleton<GameController>.instance.ContinueOrStartTutorial();
		}
		else
		{
			Debug.Log("unitDelivery");
			Debug.LogWarning("Facebook Service: Share dialog failed. Reason = ");
			if (PushNotificationManager.instance.hasValidDeviceToken() || PushNotificationManager.instance.ArePushNotificationsEnabledOnDevice())
			{
				Debug.Log("Day = " + GameLoginManager.currentPlayer.deviceToken);
				PushNotificationManager.instance.EnablePushNotifications(GameLoginManager.currentPlayer.deviceToken);
			}
		}
		MFADLJHJNAJ = false;
		GameLoginManager.instance.changeGCAfterTutorialInProgress = true;
	}

	private void DKKLKHHLEOK()
	{
		if (AIJKOENIJFL.ContainsKey("MoneyPackDeadline"))
		{
			PlayerAnalytics.instance.data.moneyPackDeadline = KHJJFPPACBP.PELILBMKGHE(AIJKOENIJFL["MoneyPackDeadline"]);
			Debug.Log("InstantBattleEnded: Money Pack Deadline = " + PlayerAnalytics.instance.data.moneyPackDeadline);
			Singleton<MessageManager>.instance.AddMessage(new NHKKDKJNMFL(), true);
		}
		if (AIJKOENIJFL.ContainsKey("PaidInstantBattles"))
		{
			Singleton<EventTrackingManager>.instance.RegisterGoldOut("Buy_InstantBattle", InstantBattleManager.instance.OCLBKLOCFKL);
			PlayerAnalytics.instance.data.paidInstantBattles = KHJJFPPACBP.PELILBMKGHE(AIJKOENIJFL["PaidInstantBattles"]);
			Singleton<EventTrackingManager>.instance.RefreshInstantBattle(InstantBattleManager.instance.OCLBKLOCFKL, PlayerAnalytics.instance.data.paidInstantBattles);
			Debug.Log("InstantBattleEnded: Paid Instant Battles = " + PlayerAnalytics.instance.data.paidInstantBattles);
			InstantBattleManager.instance.OCLBKLOCFKL = PlayerAnalytics.instance.data.GetInstantBattleCost();
		}
		if (AIJKOENIJFL.ContainsKey("InstantBattleTime"))
		{
			PlayerAnalytics.instance.data.instantBattlesTime = KHJJFPPACBP.PELILBMKGHE(AIJKOENIJFL["InstantBattleTime"]);
			Debug.Log("InstantBattleEnded: Instant Battle Time " + PlayerAnalytics.instance.data.instantBattlesTime);
			PushNotificationManager.instance.SheduleLocalSkirmishNotification(PlayerAnalytics.instance.data.GetTimestampOfFullInstantBattles());
		}
		if (AIJKOENIJFL.ContainsKey("ExperienceGained"))
		{
			int num = KHJJFPPACBP.PELILBMKGHE(AIJKOENIJFL["ExperienceGained"]);
			Debug.Log("InstantBattleEnded: REWARD EXPERIENCE: " + num);
			InstantBattleManager.instance.OKILEJHOHKE = num;
		}
		int num2 = KHJJFPPACBP.PELILBMKGHE(AIJKOENIJFL["LevelExperience"]);
		if (AIJKOENIJFL.ContainsKey("Level"))
		{
			int num3 = KHJJFPPACBP.PELILBMKGHE(AIJKOENIJFL["Level"]);
			Debug.Log("InstantBattleEnded: LEVEL UP " + num3);
			LevelManager.instance.LoadData(num3, num2);
			LevelManager.instance.isLevelUp = true;
		}
		else
		{
			LevelManager.instance.levelExperience = num2;
		}
		if (AIJKOENIJFL.ContainsKey("DogtagsRefillRankUp"))
		{
			Singleton<DogTagManager>.instance.RefillAllDogtags();
		}
		if (AIJKOENIJFL.ContainsKey("WarBucks"))
		{
			int num4 = KHJJFPPACBP.PELILBMKGHE(AIJKOENIJFL["WarBucks"]);
			Debug.Log("InstantBattleEnded: REWARD WARBUCKS: " + num4);
			InstantBattleManager.instance.HFKNEFGKBOA = num4;
			Singleton<Wallet>.instance.NFLMMKJBKEJ(InstantBattleManager.instance.HFKNEFGKBOA, false);
		}
		InstantBattleManager.instance.DDAFCFEFFFD = AAAJDBAEIKL.None;
		if (AIJKOENIJFL.ContainsKey("ExtraWarBucks"))
		{
			InstantBattleManager.instance.DDAFCFEFFFD = AAAJDBAEIKL.Warbucks;
			int num5 = KHJJFPPACBP.PELILBMKGHE(AIJKOENIJFL["ExtraWarBucks"]);
			Debug.Log("InstantBattleEnded: 3RD REWARD WARBUCKS: " + num5);
			InstantBattleManager.instance.EPCCHIJDHCN = num5;
			if (InstantBattleManager.instance.EPCCHIJDHCN == 0)
			{
				InstantBattleManager.instance.DDAFCFEFFFD = AAAJDBAEIKL.None;
			}
			else
			{
				Singleton<Wallet>.instance.NFLMMKJBKEJ(InstantBattleManager.instance.EPCCHIJDHCN, false);
			}
		}
		if (AIJKOENIJFL.ContainsKey("BattleCount"))
		{
			InstantBattleManager.instance.EGIAFNOCILH = KHJJFPPACBP.PELILBMKGHE(AIJKOENIJFL["BattleCount"]);
			Debug.Log("InstantBattleEnded: NUMBER OF BATTLES = " + InstantBattleManager.instance.EGIAFNOCILH);
		}
		if (AIJKOENIJFL.ContainsKey("LevelGold"))
		{
			int num6 = KHJJFPPACBP.PELILBMKGHE(AIJKOENIJFL["LevelGold"]);
			Singleton<Wallet>.instance.COLJGNLBEII(num6);
		}
		if (AIJKOENIJFL.ContainsKey("Gold"))
		{
			InstantBattleManager.instance.DDAFCFEFFFD = AAAJDBAEIKL.Gold;
			int num7 = KHJJFPPACBP.PELILBMKGHE(AIJKOENIJFL["Gold"]);
			Debug.Log("InstantBattleEnded: 3RD REWARD GOLD: " + num7);
			InstantBattleManager.instance.OJEBLFCHEPP = num7;
			Singleton<EventTrackingManager>.instance.RegisterGoldIn("Skirmish", num7);
			if (InstantBattleManager.instance.OJEBLFCHEPP == 0)
			{
				InstantBattleManager.instance.DDAFCFEFFFD = AAAJDBAEIKL.None;
			}
			else
			{
				Singleton<Wallet>.instance.COLJGNLBEII(InstantBattleManager.instance.OJEBLFCHEPP);
			}
		}
		if (AIJKOENIJFL.ContainsKey("AddedCards"))
		{
			InstantBattleManager.instance.DDAFCFEFFFD = AAAJDBAEIKL.WarCard;
			Debug.Log("InstantBattleEnded: 3RD REWARD WARCARDS: " + AIJKOENIJFL["AddedCards"]);
			JArray jArray = (JArray)AIJKOENIJFL["AddedCards"];
			InstantBattleManager.instance.EDJFEIOCJNF = new List<Card>();
			foreach (JToken item2 in jArray)
			{
				Card item = CardManager.instance.AddCard(item2.ToObject<string>());
				InstantBattleManager.instance.EDJFEIOCJNF.Add(item);
			}
			InstantBattleManager.instance.EDJFEIOCJNF.Sort((Card JDEMAFGJGLD, Card NOJFJANOHEB) => JDEMAFGJGLD.rarityNumber.CompareTo(NOJFJANOHEB.rarityNumber));
		}
		Singleton<EventTrackingManager>.instance.RegisterInstatntBattle(InstantBattleManager.instance.HFKNEFGKBOA + InstantBattleManager.instance.EPCCHIJDHCN, InstantBattleManager.instance.OJEBLFCHEPP, InstantBattleManager.instance.OKILEJHOHKE, InstantBattleManager.instance.EDJFEIOCJNF, InstantBattleManager.instance.EGIAFNOCILH);
		Singleton<EventTrackingManager>.instance.RegisterWBIn("Skirmish", InstantBattleManager.instance.HFKNEFGKBOA + InstantBattleManager.instance.EPCCHIJDHCN);
		if (AIJKOENIJFL.ContainsKey("BlackMarketOffer"))
		{
			BlackMarketManager.instance.LoadBMData(KHJJFPPACBP.BKFCLMMJNHK(AIJKOENIJFL["BlackMarketOffer"], string.Empty));
			BlackMarketManager.instance.ShowOffers();
		}
		InstantBattleManager.instance.BPPFFEPABLK = true;
	}

	private void OIEMDJKPADF()
	{
		CBBKFKCOLPP jNDCAHFLBAH = new CBBKFKCOLPP(AIJKOENIJFL);
		Singleton<ServerResultsCache>.instance.JNDCAHFLBAH = jNDCAHFLBAH;
		int num = KHJJFPPACBP.PELILBMKGHE(AIJKOENIJFL["InstantBattleEnded: 3RD REWARD WARBUCKS: "], 1);
		if (AIJKOENIJFL.ContainsKey("SquadId"))
		{
			if (AIJKOENIJFL.ContainsKey("stickers"))
			{
				Singleton<EventTrackingManager>.instance.RegisterGoldAndWBAfterMatch(false);
			}
			LevelManager.instance.LoadData(KHJJFPPACBP.PELILBMKGHE(AIJKOENIJFL["*****   Bootcamp 3/3 Started   *****"], 1), num);
			LevelManager.instance.isLevelUp = true;
		}
		else
		{
			if (AIJKOENIJFL.ContainsKey("squadCreationsCnt"))
			{
				Singleton<EventTrackingManager>.instance.CFGJLAHDDAO(false);
			}
			LevelManager.instance.levelExperience = num;
		}
		AssignmentsManager.instance.AssignmentHide();
	}

	private void ANELGPPCKDK()
	{
		Debug.Log("BattleId");
		if (AIJKOENIJFL.ContainsKey("TIMEOUT"))
		{
			string text = AIJKOENIJFL["Direct"].ToString();
			Debug.Log("leagueMedalsDiff" + text);
			if (text == "ID_CONFIRM_SERVERERROR")
			{
				Debug.Log("{0} {1}");
				if (AIJKOENIJFL.ContainsKey("CARDS_MIN"))
				{
					GameLoginManager.instance.OnFacebookUserExistDuringTutorial(AIJKOENIJFL["IsSpecial"].ToString());
				}
				else
				{
					Debug.LogError("menu-health-ico");
				}
			}
			else
			{
				GameLoginManager.instance.OnAccoutNotExistAfterLoginServices((AccountType)5);
			}
		}
		else
		{
			Debug.LogError("elite");
		}
	}

	private void DGCHKNFPMEN()
	{
		Debug.Log("On Craft Cards");
		int num = KHJJFPPACBP.PELILBMKGHE(AIJKOENIJFL["End"]);
		CardCraftingManager.instance.endCraftingTime = num;
		PushNotificationManager.instance.ScheduleCraftingFinishedNotification(num, CardCraftingManager.instance.isGoldCrafting);
		int[] rarityCounts = CardManager.instance.GetRarityCounts();
		List<string> cards = CardCraftingManager.instance.data.cards;
		foreach (string item in cards)
		{
			Singleton<EventTrackingManager>.instance.FPHNMABAJHN(item, rarityCounts);
		}
	}

	private void JNEDKACFBBC(List<Tuple<string, string>> GMDJHENPLHB)
	{
		Debug.Log("Current Language = ");
		WaitingDialog.GFGNLDJNNAI();
		string text = KHJJFPPACBP.BKFCLMMJNHK(AIJKOENIJFL["TimeOfMatch"], string.Empty);
		string fJLBLLLEELD = "N";
		if (AIJKOENIJFL.ContainsKey("Player profile - Show dialog for {0} from CACHE: {1}"))
		{
			long num = KHJJFPPACBP.OOAIMCEBPOK(AIJKOENIJFL["ID_STATE_WAITINGFOROPPONENT"], 1L);
			Singleton<Wallet>.instance.JAPAPDDBEMD(num);
			fJLBLLLEELD = "ID_MAX";
			if (AIJKOENIJFL.ContainsKey("Warfriends требуется разрешение на доступ к хранилищу мультимедиа для загрузки важных игровых данных.Ьез этого разрешения игра не может функционировать и будет закрыта. Пожалуйста, попробуй снова или выйди из WarFriends."))
			{
				Singleton<BeanstalkServerManager>.instance.NBJBKFEPJJC.AddDailyGoldBooster();
				string iNFLHPGMEOB = text + FBBKCGLIIOB.IJHDDLNGLHK();
				Singleton<MessageManager>.instance.AddMessage(new EKPKEMFBNLP(num, 1, iNFLHPGMEOB, true), true);
			}
			Singleton<EventTrackingManager>.instance.RegisterGoldIn(text, (int)num);
		}
		if (AIJKOENIJFL.ContainsKey("Leaderboards - Squad Wars - is in squad:{0},\t\tsquad wars procesing:{1}"))
		{
			long num2 = KHJJFPPACBP.OOAIMCEBPOK(AIJKOENIJFL["$#"], 0L);
			Singleton<Wallet>.instance.KOKDKILILLK(num2);
			Singleton<EventTrackingManager>.instance.RegisterWBIn(text, (int)num2);
		}
		bool flag = false;
		if (AIJKOENIJFL.ContainsKey("ID_GUI_ACCEPT_PLAYER"))
		{
			flag = KHJJFPPACBP.FOJOKBCNBCO(AIJKOENIJFL["There is no unit selected as tutorial unit!!!!!!"], true);
			if (AIJKOENIJFL.ContainsKey("ID_GUI_CHAT_BANNED_DESCBOX_PERMANENT"))
			{
				SubscriptionManager.instance.UpdateSubscription(KHJJFPPACBP.PELILBMKGHE(AIJKOENIJFL["LevelName"]));
			}
			if (AIJKOENIJFL.ContainsKey("105 STAGE 1 COVER 2"))
			{
				Singleton<DogTagManager>.instance.ELLJNHLPDNF = KHJJFPPACBP.PELILBMKGHE(AIJKOENIJFL["country-croatia"], 1);
			}
			if (AIJKOENIJFL.ContainsKey("ID_CONFIRM_SQUADISFULL") && KHJJFPPACBP.FOJOKBCNBCO(AIJKOENIJFL[")"]))
			{
				return;
			}
			Singleton<EventTrackingManager>.instance.ALEEKCLMJLA(flag, AIJKOENIJFL.ContainsKey("ID_EXPIRED") && KHJJFPPACBP.PELILBMKGHE(AIJKOENIJFL["ID_SALEPERCENTLINE"], 1) == 1, true);
		}
		HNFBGELNFIC(AIJKOENIJFL);
		Tuple<float, string> tuple = Singleton<BeanstalkServerManager>.instance.BBIEEHPFDDL.LOIBJHKOPKP(text);
		bool kCBGHGFELIA = PlayerAnalytics.instance.data.GetInappCount() == 1;
		Singleton<EventTrackingManager>.instance.RegisterInapp(text, kCBGHGFELIA, fJLBLLLEELD);
		string text2 = Singleton<BeanstalkServerManager>.instance.BBIEEHPFDDL.LAAAEGEENMA(text);
		Singleton<EventTrackingManager>.instance.RegisterKochavaInApp(text, tuple.Value1, fJLBLLLEELD, text2);
		Singleton<EventTrackingManager>.instance.RegisterFacebookInApp(text, tuple.Value1, fJLBLLLEELD, text2);
		PlayerAnalytics.instance.AddTransaction(99, text, 1, 1, tuple.Value1);
		Singleton<EventTrackingManager>.instance.RegisterAwsAnalyticsInApp(text, tuple.Value1, tuple.Value2, FKHJMMCANDJ(GMDJHENPLHB), text2);
		Singleton<EventTrackingManager>.instance.RegisterInApp(text, tuple.Value1, tuple.Value2, FKHJMMCANDJ(GMDJHENPLHB), text2);
		if (flag)
		{
			ConfirmDialog.CKGMDJFKNPO(Localization.Localize("ID_WARNING_OPPONENTDISCONNECTED"), Localization.Localize("menu-crown-bronze"), 1888f);
			DialogManager.instance.ShowRateAppDialog();
		}
	}

	private void GFBILJALKHL()
	{
		Debug.Log("On Debug Add Level");
		LevelManager.instance.LoadData(KHJJFPPACBP.PELILBMKGHE(AIJKOENIJFL["Level"]), 0);
		LevelManager.instance.isLevelUp = true;
		LevelManager.instance.isLevelUp = false;
		GuiElementSingle<MenuHeader>.instance.UpdateLevel();
		GuiElementSingle<MenuHeader>.instance.UpdateProgress();
	}

	[CompilerGenerated]
	private static void MBPKGNJIKAK()
	{
		GameLoginManager.Relog();
	}

	private void FFOGKGLPMJG()
	{
		Singleton<OfferManager>.instance.UpdateFromServer((!AIJKOENIJFL.ContainsKey("offers")) ? null : ((JToken)AIJKOENIJFL["offers"]));
	}

	private void GLHCLFKEPJO()
	{
		Debug.LogError("anticheat changed");
		if (AIJKOENIJFL.ContainsKey("Anticheat"))
		{
			PlayerAnalytics.instance.data.anticheatStatus = bool.Parse(AIJKOENIJFL["Anticheat"].ToString());
		}
	}

	[CompilerGenerated]
	private static void MAGMJFPKMOB(ConfirmDialog PHHJDIGEOPJ, bool NCMHGPNPEJM)
	{
		if (NCMHGPNPEJM)
		{
			Debug.Log("create new account and add FB");
			DialogManager.instance.HideAllDialogs();
			Singleton<DailyRewardManager>.instance.LNAIDLKGCFN = null;
			GameLoginManager.instance.DeletePlayerAccount();
			GameLoginManager.instance.CreateNewAccount(false);
		}
		else
		{
			Debug.Log("logout from FB");
			GameLoginManager.instance.LogoutFromFacebook(true);
			LoadingDialog.Hide();
		}
	}

	public void KJCDDLCEOIM(IJEAJGCCHEF FBFJNHLKJEC, DatabaseAction MHLAAHNPMFG, List<Tuple<string, string>> GMDJHENPLHB)
	{
		HBJBOIMFDAM.GOEHBPFDMLM(FBFJNHLKJEC, null, MHLAAHNPMFG, GMDJHENPLHB);
	}
}
