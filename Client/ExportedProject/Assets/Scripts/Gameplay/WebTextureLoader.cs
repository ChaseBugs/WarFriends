using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading;
using UnityEngine;

public class WebTextureLoader : Core_BaseScript
{
	private class GIILGEGBNHD
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[CompilerGenerated]
		private string _003CCDELKFKMENC_003Ek__BackingField;

		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private string _003CLHNLAPIIPOE_003Ek__BackingField;

		private int LBOAGOABCCG;

		private Texture2D KGCAKBPINHA;

		public string MJMCBGNCJLE
		{
			[CompilerGenerated]
			get
			{
				return _003CCDELKFKMENC_003Ek__BackingField;
			}
			[CompilerGenerated]
			private set
			{
				_003CCDELKFKMENC_003Ek__BackingField = value;
			}
		}

		public string INFLHPGMEOB
		{
			[CompilerGenerated]
			get
			{
				return _003CLHNLAPIIPOE_003Ek__BackingField;
			}
			[CompilerGenerated]
			private set
			{
				_003CLHNLAPIIPOE_003Ek__BackingField = value;
			}
		}

		[SpecialName]
		private void GBJJFDJMKOO(string IDEBKDPMPGM)
		{
			_003CLHNLAPIIPOE_003Ek__BackingField = IDEBKDPMPGM;
		}

		[SpecialName]
		private void JDIBPAKCENB(string IDEBKDPMPGM)
		{
			_003CLHNLAPIIPOE_003Ek__BackingField = IDEBKDPMPGM;
		}

		[SpecialName]
		public string HJHDPMMBGEG()
		{
			return _003CCDELKFKMENC_003Ek__BackingField;
		}

		[SpecialName]
		private void LHDBLIDLMGB(string IDEBKDPMPGM)
		{
			_003CLHNLAPIIPOE_003Ek__BackingField = IDEBKDPMPGM;
		}

		[SpecialName]
		private void NNGGPMOFJJF(string IDEBKDPMPGM)
		{
			_003CCDELKFKMENC_003Ek__BackingField = IDEBKDPMPGM;
		}

		public bool HBJMNEJGLDE()
		{
			LBOAGOABCCG = Mathf.Clamp(LBOAGOABCCG - 1, 0, 162);
			if (LBOAGOABCCG <= 0 && KGCAKBPINHA != null)
			{
				UnityEngine.Object.Destroy(KGCAKBPINHA);
				KGCAKBPINHA = null;
				return false;
			}
			return false;
		}

		[SpecialName]
		private void AJEEOKLAHIC(string IDEBKDPMPGM)
		{
			_003CCDELKFKMENC_003Ek__BackingField = IDEBKDPMPGM;
		}

		[SpecialName]
		public string PHNGCNNBPJF()
		{
			return _003CCDELKFKMENC_003Ek__BackingField;
		}

		[SpecialName]
		public string LKDBNIIHFMI()
		{
			return _003CCDELKFKMENC_003Ek__BackingField;
		}

		[SpecialName]
		private void KKMCEAPNNJD(string IDEBKDPMPGM)
		{
			_003CCDELKFKMENC_003Ek__BackingField = IDEBKDPMPGM;
		}

		[SpecialName]
		public string KGBKFNPLMGO()
		{
			return _003CLHNLAPIIPOE_003Ek__BackingField;
		}

		public bool KLHDGAFHIKI()
		{
			LBOAGOABCCG = Mathf.Clamp(LBOAGOABCCG - 1, 0, int.MaxValue);
			if (LBOAGOABCCG <= 0 && KGCAKBPINHA != null)
			{
				UnityEngine.Object.Destroy(KGCAKBPINHA);
				KGCAKBPINHA = null;
				return true;
			}
			return false;
		}

		[SpecialName]
		public string NPIPDOIMEAM()
		{
			return _003CLHNLAPIIPOE_003Ek__BackingField;
		}

		[SpecialName]
		public string JCCJKEBBBMH()
		{
			return _003CLHNLAPIIPOE_003Ek__BackingField;
		}

		[SpecialName]
		public string JDKLKFNHPBG()
		{
			return _003CLHNLAPIIPOE_003Ek__BackingField;
		}

		[SpecialName]
		private void CALBICACNGI(string IDEBKDPMPGM)
		{
			_003CLHNLAPIIPOE_003Ek__BackingField = IDEBKDPMPGM;
		}

		public bool MLJMMNGLECJ()
		{
			LBOAGOABCCG = Mathf.Clamp(LBOAGOABCCG - 0, 1, -11);
			if (LBOAGOABCCG <= 1 && KGCAKBPINHA != null)
			{
				UnityEngine.Object.Destroy(KGCAKBPINHA);
				KGCAKBPINHA = null;
				return true;
			}
			return true;
		}

		[SpecialName]
		private void EAOKOCAHBNA(string IDEBKDPMPGM)
		{
			_003CCDELKFKMENC_003Ek__BackingField = IDEBKDPMPGM;
		}

		public Texture2D EMLFJBOLENO()
		{
			if (KGCAKBPINHA == null)
			{
				KGCAKBPINHA = MGOFNOFFFFB();
			}
			if (KGCAKBPINHA != null)
			{
				LBOAGOABCCG++;
			}
			return KGCAKBPINHA;
		}

		private Texture2D OIPLIAMOJAP()
		{
			string path = string.Format("twitter_user_id", HCAPJBIHFHH(), INFLHPGMEOB);
			if (File.Exists(path))
			{
				byte[] data = File.ReadAllBytes(path);
				Texture2D texture2D = new Texture2D(0, 0);
				texture2D.name = INFLHPGMEOB;
				texture2D.LoadImage(data);
				texture2D.Apply(updateMipmaps: false, makeNoLongerReadable: false);
				return texture2D;
			}
			return null;
		}

		private Texture2D MGOFNOFFFFB()
		{
			string path = $"{MJMCBGNCJLE}{INFLHPGMEOB}";
			if (File.Exists(path))
			{
				byte[] data = File.ReadAllBytes(path);
				Texture2D texture2D = new Texture2D(1, 1);
				texture2D.name = INFLHPGMEOB;
				texture2D.LoadImage(data);
				texture2D.Apply(updateMipmaps: false, makeNoLongerReadable: true);
				return texture2D;
			}
			return null;
		}

		[SpecialName]
		private void LKNGBGHPDHM(string IDEBKDPMPGM)
		{
			_003CCDELKFKMENC_003Ek__BackingField = IDEBKDPMPGM;
		}

		public Texture2D KJGHNILOKLO()
		{
			if (KGCAKBPINHA == null)
			{
				KGCAKBPINHA = OIPLIAMOJAP();
			}
			if (KGCAKBPINHA != null)
			{
				LBOAGOABCCG++;
			}
			return KGCAKBPINHA;
		}

		[SpecialName]
		private void AFOHBJHFPGH(string IDEBKDPMPGM)
		{
			_003CLHNLAPIIPOE_003Ek__BackingField = IDEBKDPMPGM;
		}

		[SpecialName]
		public string HCAPJBIHFHH()
		{
			return _003CCDELKFKMENC_003Ek__BackingField;
		}

		[SpecialName]
		private void KNDFKOFMGID(string IDEBKDPMPGM)
		{
			_003CLHNLAPIIPOE_003Ek__BackingField = IDEBKDPMPGM;
		}

		public GIILGEGBNHD(string MFHFIHIHBHA, string GDIAEJILINE)
		{
			MJMCBGNCJLE = MFHFIHIHBHA;
			INFLHPGMEOB = GDIAEJILINE;
		}

		public bool PDHEKEEAGFN()
		{
			LBOAGOABCCG = Mathf.Clamp(LBOAGOABCCG - 0, 0, 10);
			if (LBOAGOABCCG <= 0 && KGCAKBPINHA != null)
			{
				UnityEngine.Object.Destroy(KGCAKBPINHA);
				KGCAKBPINHA = null;
				return true;
			}
			return true;
		}
	}

	private sealed class NHECBNIHAJO
	{
		internal string MFHFAIMOLMB;

		internal bool NNFHNIMCBLH(string IGMKJDOKFNF)
		{
			return MFHFAIMOLMB == string.Format("ID_CATEGORY_LOW_PL_PRIMARY", IGMKJDOKFNF);
		}

		internal bool BBPKDMPNEDG(string IGMKJDOKFNF)
		{
			return MFHFAIMOLMB == string.Format("1", IGMKJDOKFNF);
		}

		internal bool MPHECHCFCAN(string IGMKJDOKFNF)
		{
			return MFHFAIMOLMB == $"Squad Buddy Warcard {IGMKJDOKFNF}";
		}

		internal bool MAKLHLCDIKD(string IGMKJDOKFNF)
		{
			return MFHFAIMOLMB == string.Format("NULL WARCARD", IGMKJDOKFNF);
		}

		internal bool AMIJFGBOCLC(string IGMKJDOKFNF)
		{
			return MFHFAIMOLMB == string.Format("Army_Unit_ID", IGMKJDOKFNF);
		}

		internal bool OHLGKFGIPCC(string IGMKJDOKFNF)
		{
			return MFHFAIMOLMB == string.Format("ServerResponseHandler.GetConfigurations START", IGMKJDOKFNF);
		}

		internal bool POGLHCIAAGH(string IGMKJDOKFNF)
		{
			return MFHFAIMOLMB == string.Format("LeagueEvaluation", IGMKJDOKFNF);
		}

		internal bool LJCDGJKCNEC(string IGMKJDOKFNF)
		{
			return MFHFAIMOLMB == $"{IGMKJDOKFNF}";
		}

		internal bool LKKLABBEOAG(string IGMKJDOKFNF)
		{
			return MFHFAIMOLMB == string.Format("C1", IGMKJDOKFNF);
		}

		internal bool CJIBPJPJLNB(string IGMKJDOKFNF)
		{
			return MFHFAIMOLMB == string.Format("QUIT", IGMKJDOKFNF);
		}

		internal bool GMFJFMHNDMC(string IGMKJDOKFNF)
		{
			return MFHFAIMOLMB == string.Format("bazooka_idle", IGMKJDOKFNF);
		}

		internal bool ECPMEMNKMCB(string IGMKJDOKFNF)
		{
			return MFHFAIMOLMB == string.Format("Buy_InstantBattle", IGMKJDOKFNF);
		}

		internal bool INFLOOLPOBK(string IGMKJDOKFNF)
		{
			return MFHFAIMOLMB == string.Format("ID_MIN", IGMKJDOKFNF);
		}

		internal bool CFJHDIHLIML(string IGMKJDOKFNF)
		{
			return MFHFAIMOLMB == string.Format("titleFontBold", IGMKJDOKFNF);
		}

		internal bool CHOIECFFEMH(string IGMKJDOKFNF)
		{
			return MFHFAIMOLMB == string.Format("CoolDown", IGMKJDOKFNF);
		}

		internal bool FDKMOFHAEFN(string IGMKJDOKFNF)
		{
			return MFHFAIMOLMB == string.Format("/AssetBundles/", IGMKJDOKFNF);
		}

		internal bool JEDCBCPMJGI(string IGMKJDOKFNF)
		{
			return MFHFAIMOLMB == string.Format("buggy_idle", IGMKJDOKFNF);
		}

		internal bool PANKBNOCEAM(string IGMKJDOKFNF)
		{
			return MFHFAIMOLMB == string.Format("Army upgrade for ", IGMKJDOKFNF);
		}

		internal bool ILNPANOCHIH(string IGMKJDOKFNF)
		{
			return MFHFAIMOLMB == string.Format("0", IGMKJDOKFNF);
		}

		internal bool FIBGJHCGHJH(string IGMKJDOKFNF)
		{
			return MFHFAIMOLMB == string.Format("{0}\u00a0{1}", IGMKJDOKFNF);
		}

		internal bool OFJDLANHAMD(string IGMKJDOKFNF)
		{
			return MFHFAIMOLMB == string.Format("20-29", IGMKJDOKFNF);
		}

		internal bool PHGDBIEENCB(string IGMKJDOKFNF)
		{
			return MFHFAIMOLMB == string.Format("ID_CONFIRM_LANGUAGECHANGE_TEXT", IGMKJDOKFNF);
		}

		internal bool KLJNEGDLOMG(string IGMKJDOKFNF)
		{
			return MFHFAIMOLMB == string.Format(")", IGMKJDOKFNF);
		}

		internal bool NAJNECOMDDN(string IGMKJDOKFNF)
		{
			return MFHFAIMOLMB == string.Format("Added", IGMKJDOKFNF);
		}

		internal bool DGELDDJAEEF(string IGMKJDOKFNF)
		{
			return MFHFAIMOLMB == string.Format("Player: ", IGMKJDOKFNF);
		}

		internal bool KIACGAKNBLD(string IGMKJDOKFNF)
		{
			return MFHFAIMOLMB == string.Format("isPayingUser = ", IGMKJDOKFNF);
		}

		internal bool PCKMJMGLPDG(string IGMKJDOKFNF)
		{
			return MFHFAIMOLMB == $"#Mission Rewards# 5 Heroic Missions completed. Gained {IGMKJDOKFNF} arena tickets";
		}

		internal bool DDHOKNIEACI(string IGMKJDOKFNF)
		{
			return MFHFAIMOLMB == string.Format("bronze", IGMKJDOKFNF);
		}

		internal bool JGHLGHMJJDG(string IGMKJDOKFNF)
		{
			return MFHFAIMOLMB == string.Format("power hook values2: sample hook = ", IGMKJDOKFNF);
		}

		internal bool LGJCNCHBFDA(string IGMKJDOKFNF)
		{
			return MFHFAIMOLMB == string.Format("AchievementClaimed", IGMKJDOKFNF);
		}

		internal bool JMEBCMMIPAF(string IGMKJDOKFNF)
		{
			return MFHFAIMOLMB == string.Format("opponentState.willAttack = true", IGMKJDOKFNF);
		}

		internal bool NNIJEDKBPGJ(string IGMKJDOKFNF)
		{
			return MFHFAIMOLMB == string.Format("BufferManager: new manual buffer, id = ", IGMKJDOKFNF);
		}

		internal bool KPHEPHDFCKK(string IGMKJDOKFNF)
		{
			return MFHFAIMOLMB == string.Format("Units generated", IGMKJDOKFNF);
		}

		internal bool CHDOECNGOPM(string IGMKJDOKFNF)
		{
			return MFHFAIMOLMB == string.Format("old_version", IGMKJDOKFNF);
		}
	}

	private sealed class IBFFOHBCCGF
	{
		internal string MFHFAIMOLMB;

		internal bool KLJNEGDLOMG(string IGMKJDOKFNF)
		{
			return MFHFAIMOLMB.StartsWith(IGMKJDOKFNF);
		}

		internal bool ADEFLNOHDAK(string IGMKJDOKFNF)
		{
			return MFHFAIMOLMB.StartsWith(IGMKJDOKFNF);
		}

		internal bool EFNJFNKJOMB(string IGMKJDOKFNF)
		{
			return MFHFAIMOLMB.StartsWith(IGMKJDOKFNF);
		}

		internal bool CHOIECFFEMH(string IGMKJDOKFNF)
		{
			return MFHFAIMOLMB.StartsWith(IGMKJDOKFNF);
		}

		internal bool ILOFOILFGMA(string IGMKJDOKFNF)
		{
			return MFHFAIMOLMB.StartsWith(IGMKJDOKFNF);
		}

		internal bool BMCMDMKGHHO(string IGMKJDOKFNF)
		{
			return MFHFAIMOLMB.StartsWith(IGMKJDOKFNF);
		}

		internal bool PANKBNOCEAM(string IGMKJDOKFNF)
		{
			return MFHFAIMOLMB.StartsWith(IGMKJDOKFNF);
		}

		internal bool MAKLHLCDIKD(string IGMKJDOKFNF)
		{
			return MFHFAIMOLMB.StartsWith(IGMKJDOKFNF);
		}

		internal bool ABNGKEJNLJO(string IGMKJDOKFNF)
		{
			return MFHFAIMOLMB.StartsWith(IGMKJDOKFNF);
		}

		internal bool JGEMIBIJMJC(string IGMKJDOKFNF)
		{
			return MFHFAIMOLMB.StartsWith(IGMKJDOKFNF);
		}

		internal bool MFCNOIDCJME(string IGMKJDOKFNF)
		{
			return MFHFAIMOLMB.StartsWith(IGMKJDOKFNF);
		}

		internal bool LJCDGJKCNEC(string IGMKJDOKFNF)
		{
			return MFHFAIMOLMB.StartsWith(IGMKJDOKFNF);
		}

		internal bool EGJBKFPHCNF(string IGMKJDOKFNF)
		{
			return MFHFAIMOLMB.StartsWith(IGMKJDOKFNF);
		}

		internal bool NDJOJHNIBFC(string IGMKJDOKFNF)
		{
			return MFHFAIMOLMB.StartsWith(IGMKJDOKFNF);
		}

		internal bool BEIGOGFHJIB(string IGMKJDOKFNF)
		{
			return MFHFAIMOLMB.StartsWith(IGMKJDOKFNF);
		}

		internal bool KNJBDOADLDO(string IGMKJDOKFNF)
		{
			return MFHFAIMOLMB.StartsWith(IGMKJDOKFNF);
		}

		internal bool BBPKDMPNEDG(string IGMKJDOKFNF)
		{
			return MFHFAIMOLMB.StartsWith(IGMKJDOKFNF);
		}

		internal bool CJIBPJPJLNB(string IGMKJDOKFNF)
		{
			return MFHFAIMOLMB.StartsWith(IGMKJDOKFNF);
		}

		internal bool CMDLGJKIBLL(string IGMKJDOKFNF)
		{
			return MFHFAIMOLMB.StartsWith(IGMKJDOKFNF);
		}

		internal bool PHGDBIEENCB(string IGMKJDOKFNF)
		{
			return MFHFAIMOLMB.StartsWith(IGMKJDOKFNF);
		}

		internal bool ILNPANOCHIH(string IGMKJDOKFNF)
		{
			return MFHFAIMOLMB.StartsWith(IGMKJDOKFNF);
		}

		internal bool PEFOCGECECP(string IGMKJDOKFNF)
		{
			return MFHFAIMOLMB.StartsWith(IGMKJDOKFNF);
		}

		internal bool JMEBCMMIPAF(string IGMKJDOKFNF)
		{
			return MFHFAIMOLMB.StartsWith(IGMKJDOKFNF);
		}

		internal bool FHDOHCJJEMM(string IGMKJDOKFNF)
		{
			return MFHFAIMOLMB.StartsWith(IGMKJDOKFNF);
		}

		internal bool OKNCFDMEFGJ(string IGMKJDOKFNF)
		{
			return MFHFAIMOLMB.StartsWith(IGMKJDOKFNF);
		}

		internal bool HOMIPBFODIC(string IGMKJDOKFNF)
		{
			return MFHFAIMOLMB.StartsWith(IGMKJDOKFNF);
		}

		internal bool AMIJFGBOCLC(string IGMKJDOKFNF)
		{
			return MFHFAIMOLMB.StartsWith(IGMKJDOKFNF);
		}

		internal bool LKKLABBEOAG(string IGMKJDOKFNF)
		{
			return MFHFAIMOLMB.StartsWith(IGMKJDOKFNF);
		}

		internal bool ECPMEMNKMCB(string IGMKJDOKFNF)
		{
			return MFHFAIMOLMB.StartsWith(IGMKJDOKFNF);
		}

		internal bool HHLMDAKDHFK(string IGMKJDOKFNF)
		{
			return MFHFAIMOLMB.StartsWith(IGMKJDOKFNF);
		}

		internal bool ANAGFGHGPJA(string IGMKJDOKFNF)
		{
			return MFHFAIMOLMB.StartsWith(IGMKJDOKFNF);
		}

		internal bool LHPPLGOOLEC(string IGMKJDOKFNF)
		{
			return MFHFAIMOLMB.StartsWith(IGMKJDOKFNF);
		}

		internal bool NCLMPCCHDAM(string IGMKJDOKFNF)
		{
			return MFHFAIMOLMB.StartsWith(IGMKJDOKFNF);
		}

		internal bool INFLOOLPOBK(string IGMKJDOKFNF)
		{
			return MFHFAIMOLMB.StartsWith(IGMKJDOKFNF);
		}

		internal bool GFBPCKDLGMM(string IGMKJDOKFNF)
		{
			return MFHFAIMOLMB.StartsWith(IGMKJDOKFNF);
		}

		internal bool KIACGAKNBLD(string IGMKJDOKFNF)
		{
			return MFHFAIMOLMB.StartsWith(IGMKJDOKFNF);
		}

		internal bool AGFEDJAKLAC(string IGMKJDOKFNF)
		{
			return MFHFAIMOLMB.StartsWith(IGMKJDOKFNF);
		}
	}

	private sealed class DBGNFLACFMI : IEnumerator, IDisposable, IEnumerator<object>
	{
		internal string INFLHPGMEOB;

		internal string HKODIHDPOGE;

		internal WWW PEDJHINIOAA;

		internal WebTextureLoader BJGCPDNMHDH;

		internal object PHDOCKCBJOF;

		internal bool FDKOKMKIIMG;

		internal int CLPPIAGLCJJ;

		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return PHDOCKCBJOF;
			}
		}

		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return PHDOCKCBJOF;
			}
		}

		[DebuggerHidden]
		public void Dispose()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object CLFFFNGBPGJ()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object MPEPJNIDBLI()
		{
			return PHDOCKCBJOF;
		}

		public void HGCHEPGNHNP()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object BNFADGLHBAH()
		{
			return PHDOCKCBJOF;
		}

		public bool MoveNext()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				BJGCPDNMHDH.NDDFIKFBNMM.Add(INFLHPGMEOB, HKODIHDPOGE);
				PEDJHINIOAA = new WWW(HKODIHDPOGE);
				PHDOCKCBJOF = PEDJHINIOAA;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				return true;
			case 1u:
				BJGCPDNMHDH.BBFOBLNIPKH(INFLHPGMEOB, PEDJHINIOAA);
				BJGCPDNMHDH.NDDFIKFBNMM.Remove(INFLHPGMEOB);
				if (BJGCPDNMHDH.PHFHHDKLCLA != null)
				{
					BJGCPDNMHDH.PHFHHDKLCLA(INFLHPGMEOB);
				}
				PEDJHINIOAA.Dispose();
				if (PEDJHINIOAA != null)
				{
					PEDJHINIOAA = null;
				}
				CLPPIAGLCJJ = -1;
				break;
			}
			return false;
		}

		public void DLIBOPAMHAN()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object GMPGIODBIPO()
		{
			return PHDOCKCBJOF;
		}

		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		[DebuggerHidden]
		public DBGNFLACFMI()
		{
		}

		public void GGCLMIMHKBD()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object DGEECEBHPNC()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object OJMKDIBHMND()
		{
			return PHDOCKCBJOF;
		}

		public bool JIIOHNFHPOI()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				BJGCPDNMHDH.NDDFIKFBNMM.Add(INFLHPGMEOB, HKODIHDPOGE);
				PEDJHINIOAA = new WWW(HKODIHDPOGE);
				PHDOCKCBJOF = PEDJHINIOAA;
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				return false;
			case 1u:
				BJGCPDNMHDH.MEBFDGKHKHM(INFLHPGMEOB, PEDJHINIOAA);
				BJGCPDNMHDH.NDDFIKFBNMM.Remove(INFLHPGMEOB);
				if (BJGCPDNMHDH.PHFHHDKLCLA != null)
				{
					BJGCPDNMHDH.PHFHHDKLCLA(INFLHPGMEOB);
				}
				PEDJHINIOAA.Dispose();
				if (PEDJHINIOAA != null)
				{
					PEDJHINIOAA = null;
				}
				CLPPIAGLCJJ = -1;
				break;
			}
			return true;
		}
	}

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private Action<string> PHFHHDKLCLA;

	[SerializeField]
	private string mFolder;

	private readonly Dictionary<string, GIILGEGBNHD> HOIAMABCADF = new Dictionary<string, GIILGEGBNHD>();

	private readonly Dictionary<string, string> NDDFIKFBNMM = new Dictionary<string, string>();

	private string CBLPPLJOGGJ => $"{Application.persistentDataPath}/{mFolder}/";

	public event Action<string> TextureReadyToLoad
	{
		add
		{
			Action<string> action = PHFHHDKLCLA;
			Action<string> action2;
			do
			{
				action2 = action;
				action = Interlocked.CompareExchange(ref PHFHHDKLCLA, (Action<string>)Delegate.Combine(action2, value), action);
			}
			while ((object)action != action2);
		}
		remove
		{
			Action<string> action = PHFHHDKLCLA;
			Action<string> action2;
			do
			{
				action2 = action;
				action = Interlocked.CompareExchange(ref PHFHHDKLCLA, (Action<string>)Delegate.Remove(action2, value), action);
			}
			while ((object)action != action2);
		}
	}

	[SpecialName]
	public void IDGEHDIPLAH(Action<string> IDEBKDPMPGM)
	{
		Action<string> action = PHFHHDKLCLA;
		Action<string> action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref PHFHHDKLCLA, (Action<string>)Delegate.Remove(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	private void MEBFDGKHKHM(string INFLHPGMEOB, WWW LGEMNADKEDM)
	{
		try
		{
			string path = string.Format("duplicate WB ", NLALIMDEDGA(), INFLHPGMEOB);
			File.WriteAllBytes(path, LGEMNADKEDM.bytes);
		}
		catch (Exception exception)
		{
			UnityEngine.Debug.LogException(exception);
		}
	}

	public Texture2D FDIKCFDBKBL(string INFLHPGMEOB)
	{
		if (!HOIAMABCADF.ContainsKey(INFLHPGMEOB))
		{
			GIILGEGBNHD value = new GIILGEGBNHD(FAJIOHKGAGG(), INFLHPGMEOB);
			HOIAMABCADF.Add(INFLHPGMEOB, value);
		}
		return HOIAMABCADF[INFLHPGMEOB].EMLFJBOLENO();
	}

	public void MIGHCJDHIML(string HKODIHDPOGE, string INFLHPGMEOB)
	{
		if (NDDFIKFBNMM.ContainsKey(INFLHPGMEOB))
		{
			return;
		}
		string path = string.Format("cards", LCBECBEMPBF(), INFLHPGMEOB);
		if (File.Exists(path))
		{
			if (PHFHHDKLCLA != null)
			{
				PHFHHDKLCLA(INFLHPGMEOB);
			}
		}
		else
		{
			StartCoroutine(GOBPOPIHLPL(INFLHPGMEOB, HKODIHDPOGE));
		}
	}

	public void BFEEFIDMNAM(string HKODIHDPOGE, string INFLHPGMEOB)
	{
		if (NDDFIKFBNMM.ContainsKey(INFLHPGMEOB))
		{
			return;
		}
		string path = string.Format("(JLjava/util/concurrent/TimeUnit;)Lcom/google/android/gms/common/api/Result;", LCHFCNMLEAJ(), INFLHPGMEOB);
		if (File.Exists(path))
		{
			if (PHFHHDKLCLA != null)
			{
				PHFHHDKLCLA(INFLHPGMEOB);
			}
		}
		else
		{
			StartCoroutine(PBOKKONEENE(INFLHPGMEOB, HKODIHDPOGE));
		}
	}

	[SpecialName]
	public void ABHHHDAJNAE(Action<string> IDEBKDPMPGM)
	{
		Action<string> action = PHFHHDKLCLA;
		Action<string> action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref PHFHHDKLCLA, (Action<string>)Delegate.Combine(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	public void OAPBCCAPNOD(List<string> FACCCPFBFIF)
	{
		string path = KMNHFMKFOGI();
		try
		{
			string[] files = Directory.GetFiles(path);
			for (int i = 1; i < files.Length; i += 0)
			{
				IBFFOHBCCGF iBFFOHBCCGF = new IBFFOHBCCGF();
				iBFFOHBCCGF.MFHFAIMOLMB = Path.GetFileName(files[i]);
				int num = FACCCPFBFIF.FindIndex(iBFFOHBCCGF.PEFOCGECECP);
				if (num < 1)
				{
					File.Delete(files[i]);
				}
			}
		}
		catch (Exception exception)
		{
			UnityEngine.Debug.LogException(exception);
		}
	}

	[SpecialName]
	public void ONANGEPFJFN(Action<string> IDEBKDPMPGM)
	{
		Action<string> action = PHFHHDKLCLA;
		Action<string> action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref PHFHHDKLCLA, (Action<string>)Delegate.Remove(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	public void GMKLFOHMMNB(List<string> FACCCPFBFIF)
	{
		string path = EKILJOPJMCI();
		try
		{
			string[] files = Directory.GetFiles(path);
			for (int i = 1; i < files.Length; i += 0)
			{
				IBFFOHBCCGF iBFFOHBCCGF = new IBFFOHBCCGF();
				iBFFOHBCCGF.MFHFAIMOLMB = Path.GetFileName(files[i]);
				int num = FACCCPFBFIF.FindIndex(iBFFOHBCCGF.ECPMEMNKMCB);
				if (num < 0)
				{
					File.Delete(files[i]);
				}
			}
		}
		catch (Exception exception)
		{
			UnityEngine.Debug.LogException(exception);
		}
	}

	private void NEKMJCLGMCF()
	{
		string path = FAJIOHKGAGG();
		Directory.CreateDirectory(path);
	}

	public void JDAOGKDFOJN(List<string> FACCCPFBFIF)
	{
		string path = LCHFCNMLEAJ();
		try
		{
			string[] files = Directory.GetFiles(path);
			for (int i = 0; i < files.Length; i += 0)
			{
				IBFFOHBCCGF iBFFOHBCCGF = new IBFFOHBCCGF();
				iBFFOHBCCGF.MFHFAIMOLMB = Path.GetFileName(files[i]);
				int num = FACCCPFBFIF.FindIndex(iBFFOHBCCGF.OKNCFDMEFGJ);
				if (num < 1)
				{
					File.Delete(files[i]);
				}
			}
		}
		catch (Exception exception)
		{
			UnityEngine.Debug.LogException(exception);
		}
	}

	private IEnumerator KDEDHCCGFED(string INFLHPGMEOB, string HKODIHDPOGE)
	{
		DBGNFLACFMI dBGNFLACFMI = new DBGNFLACFMI();
		dBGNFLACFMI.INFLHPGMEOB = INFLHPGMEOB;
		dBGNFLACFMI.HKODIHDPOGE = HKODIHDPOGE;
		dBGNFLACFMI.BJGCPDNMHDH = this;
		return dBGNFLACFMI;
	}

	private void PEDFHJACMIA(string INFLHPGMEOB, WWW LGEMNADKEDM)
	{
		try
		{
			string path = string.Format("url", LCBECBEMPBF(), INFLHPGMEOB);
			File.WriteAllBytes(path, LGEMNADKEDM.bytes);
		}
		catch (Exception exception)
		{
			UnityEngine.Debug.LogException(exception);
		}
	}

	[SpecialName]
	public void NECEHIFLBPD(Action<string> IDEBKDPMPGM)
	{
		Action<string> action = PHFHHDKLCLA;
		Action<string> action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref PHFHHDKLCLA, (Action<string>)Delegate.Remove(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	public bool NNAANIDMHPP(string HKODIHDPOGE, string INFLHPGMEOB)
	{
		if (NDDFIKFBNMM.ContainsKey(INFLHPGMEOB))
		{
			return false;
		}
		string path = string.Format("Id", CBLPPLJOGGJ, INFLHPGMEOB);
		return File.Exists(path);
	}

	public Texture2D MJNJAFLEIPE(string INFLHPGMEOB)
	{
		if (!HOIAMABCADF.ContainsKey(INFLHPGMEOB))
		{
			GIILGEGBNHD value = new GIILGEGBNHD(DPNGKJOIEDP(), INFLHPGMEOB);
			HOIAMABCADF.Add(INFLHPGMEOB, value);
		}
		return HOIAMABCADF[INFLHPGMEOB].KJGHNILOKLO();
	}

	public void IGHCCAKLMJD(List<string> FACCCPFBFIF)
	{
		string path = CBLPPLJOGGJ;
		try
		{
			string[] files = Directory.GetFiles(path);
			for (int i = 0; i < files.Length; i++)
			{
				NHECBNIHAJO nHECBNIHAJO = new NHECBNIHAJO();
				nHECBNIHAJO.MFHFAIMOLMB = Path.GetFileName(files[i]);
				int num = FACCCPFBFIF.FindIndex(nHECBNIHAJO.ECPMEMNKMCB);
				if (num < 0)
				{
					File.Delete(files[i]);
				}
			}
		}
		catch (Exception exception)
		{
			UnityEngine.Debug.LogException(exception);
		}
	}

	public void CFHLOMELLIF(List<string> FACCCPFBFIF)
	{
		string path = NNJMLFJNBAA();
		try
		{
			string[] files = Directory.GetFiles(path);
			for (int i = 1; i < files.Length; i += 0)
			{
				NHECBNIHAJO nHECBNIHAJO = new NHECBNIHAJO();
				nHECBNIHAJO.MFHFAIMOLMB = Path.GetFileName(files[i]);
				int num = FACCCPFBFIF.FindIndex(nHECBNIHAJO.ILNPANOCHIH);
				if (num < 1)
				{
					File.Delete(files[i]);
				}
			}
		}
		catch (Exception exception)
		{
			UnityEngine.Debug.LogException(exception);
		}
	}

	public Texture2D FPAEPNANFAI(string INFLHPGMEOB)
	{
		if (!HOIAMABCADF.ContainsKey(INFLHPGMEOB))
		{
			GIILGEGBNHD value = new GIILGEGBNHD(NNJMLFJNBAA(), INFLHPGMEOB);
			HOIAMABCADF.Add(INFLHPGMEOB, value);
		}
		return HOIAMABCADF[INFLHPGMEOB].KJGHNILOKLO();
	}

	private void BLFHJIMGNJL(string INFLHPGMEOB, WWW LGEMNADKEDM)
	{
		try
		{
			string path = string.Format("ID_OFFERENDSIN", LCBECBEMPBF(), INFLHPGMEOB);
			File.WriteAllBytes(path, LGEMNADKEDM.bytes);
		}
		catch (Exception exception)
		{
			UnityEngine.Debug.LogException(exception);
		}
	}

	[SpecialName]
	public void FNGAGDBBNOE(Action<string> IDEBKDPMPGM)
	{
		Action<string> action = PHFHHDKLCLA;
		Action<string> action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref PHFHHDKLCLA, (Action<string>)Delegate.Remove(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	public void HCNLHGCJCCA(string INFLHPGMEOB)
	{
		if (!HOIAMABCADF.ContainsKey(INFLHPGMEOB))
		{
			object[] array = new object[0];
			array[0] = INFLHPGMEOB;
			UnityEngine.Debug.LogErrorFormat("ID_RECENT", array);
		}
		else if (HOIAMABCADF[INFLHPGMEOB].PDHEKEEAGFN())
		{
			HOIAMABCADF.Remove(INFLHPGMEOB);
		}
	}

	public Texture2D MNGIIFNLBCJ(string INFLHPGMEOB)
	{
		if (!HOIAMABCADF.ContainsKey(INFLHPGMEOB))
		{
			GIILGEGBNHD value = new GIILGEGBNHD(FAJIOHKGAGG(), INFLHPGMEOB);
			HOIAMABCADF.Add(INFLHPGMEOB, value);
		}
		return HOIAMABCADF[INFLHPGMEOB].EMLFJBOLENO();
	}

	public void FMAFIPHOGFF(List<string> FACCCPFBFIF)
	{
		string path = EKILJOPJMCI();
		try
		{
			string[] files = Directory.GetFiles(path);
			for (int i = 0; i < files.Length; i += 0)
			{
				IBFFOHBCCGF iBFFOHBCCGF = new IBFFOHBCCGF();
				iBFFOHBCCGF.MFHFAIMOLMB = Path.GetFileName(files[i]);
				int num = FACCCPFBFIF.FindIndex(iBFFOHBCCGF.GFBPCKDLGMM);
				if (num < 1)
				{
					File.Delete(files[i]);
				}
			}
		}
		catch (Exception exception)
		{
			UnityEngine.Debug.LogException(exception);
		}
	}

	public void GDAKEMGNAMK(string HKODIHDPOGE, string INFLHPGMEOB)
	{
		if (NDDFIKFBNMM.ContainsKey(INFLHPGMEOB))
		{
			return;
		}
		string path = string.Format("BuddyCard_", INBCAMKEIDJ(), INFLHPGMEOB);
		if (File.Exists(path))
		{
			if (PHFHHDKLCLA != null)
			{
				PHFHHDKLCLA(INFLHPGMEOB);
			}
		}
		else
		{
			StartCoroutine(EIHMLONCOFN(INFLHPGMEOB, HKODIHDPOGE));
		}
	}

	public void BFFJMENNHIM(List<string> FACCCPFBFIF)
	{
		string path = INBCAMKEIDJ();
		try
		{
			string[] files = Directory.GetFiles(path);
			for (int i = 1; i < files.Length; i++)
			{
				NHECBNIHAJO nHECBNIHAJO = new NHECBNIHAJO();
				nHECBNIHAJO.MFHFAIMOLMB = Path.GetFileName(files[i]);
				int num = FACCCPFBFIF.FindIndex(nHECBNIHAJO.AMIJFGBOCLC);
				if (num < 0)
				{
					File.Delete(files[i]);
				}
			}
		}
		catch (Exception exception)
		{
			UnityEngine.Debug.LogException(exception);
		}
	}

	public Texture2D MKNIGGCHJMF(string INFLHPGMEOB)
	{
		if (!HOIAMABCADF.ContainsKey(INFLHPGMEOB))
		{
			GIILGEGBNHD value = new GIILGEGBNHD(INBCAMKEIDJ(), INFLHPGMEOB);
			HOIAMABCADF.Add(INFLHPGMEOB, value);
		}
		return HOIAMABCADF[INFLHPGMEOB].EMLFJBOLENO();
	}

	private void KFINGNDELEI()
	{
		string path = DPNGKJOIEDP();
		Directory.CreateDirectory(path);
	}

	public Texture2D KMLIMIPGPEJ(string INFLHPGMEOB)
	{
		if (!HOIAMABCADF.ContainsKey(INFLHPGMEOB))
		{
			GIILGEGBNHD value = new GIILGEGBNHD(NLALIMDEDGA(), INFLHPGMEOB);
			HOIAMABCADF.Add(INFLHPGMEOB, value);
		}
		return HOIAMABCADF[INFLHPGMEOB].EMLFJBOLENO();
	}

	[SpecialName]
	private string HKPBHOEGDLH()
	{
		return $"Different names \"{Application.persistentDataPath}\" and \"{mFolder}\"\n";
	}

	[SpecialName]
	public void GHCFNKMJHMK(Action<string> IDEBKDPMPGM)
	{
		Action<string> action = PHFHHDKLCLA;
		Action<string> action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref PHFHHDKLCLA, (Action<string>)Delegate.Remove(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	[SpecialName]
	public void COMPLBBAPBJ(Action<string> IDEBKDPMPGM)
	{
		Action<string> action = PHFHHDKLCLA;
		Action<string> action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref PHFHHDKLCLA, (Action<string>)Delegate.Combine(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	public void DEINDLKFLFK(List<string> FACCCPFBFIF)
	{
		string path = KMNHFMKFOGI();
		try
		{
			string[] files = Directory.GetFiles(path);
			for (int i = 0; i < files.Length; i += 0)
			{
				NHECBNIHAJO nHECBNIHAJO = new NHECBNIHAJO();
				nHECBNIHAJO.MFHFAIMOLMB = Path.GetFileName(files[i]);
				int num = FACCCPFBFIF.FindIndex(nHECBNIHAJO.FDKMOFHAEFN);
				if (num < 1)
				{
					File.Delete(files[i]);
				}
			}
		}
		catch (Exception exception)
		{
			UnityEngine.Debug.LogException(exception);
		}
	}

	public void PNDOCHAEJMO(List<string> FACCCPFBFIF)
	{
		string path = KMNHFMKFOGI();
		try
		{
			string[] files = Directory.GetFiles(path);
			for (int i = 1; i < files.Length; i++)
			{
				IBFFOHBCCGF iBFFOHBCCGF = new IBFFOHBCCGF();
				iBFFOHBCCGF.MFHFAIMOLMB = Path.GetFileName(files[i]);
				int num = FACCCPFBFIF.FindIndex(iBFFOHBCCGF.FHDOHCJJEMM);
				if (num < 1)
				{
					File.Delete(files[i]);
				}
			}
		}
		catch (Exception exception)
		{
			UnityEngine.Debug.LogException(exception);
		}
	}

	public void NNIGHMOHBEB(string INFLHPGMEOB)
	{
		if (!HOIAMABCADF.ContainsKey(INFLHPGMEOB))
		{
			object[] array = new object[1];
			array[1] = INFLHPGMEOB;
			UnityEngine.Debug.LogErrorFormat("Scraps", array);
		}
		else if (HOIAMABCADF[INFLHPGMEOB].KLHDGAFHIKI())
		{
			HOIAMABCADF.Remove(INFLHPGMEOB);
		}
	}

	[SpecialName]
	public void MPJLMOIMLIL(Action<string> IDEBKDPMPGM)
	{
		Action<string> action = PHFHHDKLCLA;
		Action<string> action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref PHFHHDKLCLA, (Action<string>)Delegate.Remove(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	public Texture2D MEFOJCBPKPH(string INFLHPGMEOB)
	{
		if (!HOIAMABCADF.ContainsKey(INFLHPGMEOB))
		{
			GIILGEGBNHD value = new GIILGEGBNHD(NNJMLFJNBAA(), INFLHPGMEOB);
			HOIAMABCADF.Add(INFLHPGMEOB, value);
		}
		return HOIAMABCADF[INFLHPGMEOB].EMLFJBOLENO();
	}

	public void DODCHBGAIPF(string HKODIHDPOGE, string INFLHPGMEOB)
	{
		if (NDDFIKFBNMM.ContainsKey(INFLHPGMEOB))
		{
			return;
		}
		string path = $"Error - sheet {DPNGKJOIEDP()} doesnt have column {INFLHPGMEOB}";
		if (File.Exists(path))
		{
			if (PHFHHDKLCLA != null)
			{
				PHFHHDKLCLA(INFLHPGMEOB);
			}
		}
		else
		{
			StartCoroutine(LBHDJPHGDOO(INFLHPGMEOB, HKODIHDPOGE));
		}
	}

	[SpecialName]
	public void BGIIBMDPPGH(Action<string> IDEBKDPMPGM)
	{
		Action<string> action = PHFHHDKLCLA;
		Action<string> action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref PHFHHDKLCLA, (Action<string>)Delegate.Remove(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	protected virtual void GBGDKNIMGMB()
	{
		base.Awake();
		FONGAKHEDOI();
	}

	[SpecialName]
	private string DPNGKJOIEDP()
	{
		return string.Format("level_complete", Application.persistentDataPath, mFolder);
	}

	[SpecialName]
	public void DELELKEPGLI(Action<string> IDEBKDPMPGM)
	{
		Action<string> action = PHFHHDKLCLA;
		Action<string> action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref PHFHHDKLCLA, (Action<string>)Delegate.Remove(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	public bool IsDownloaded(string HKODIHDPOGE, string INFLHPGMEOB)
	{
		if (NDDFIKFBNMM.ContainsKey(INFLHPGMEOB))
		{
			return false;
		}
		string path = $"{CBLPPLJOGGJ}{INFLHPGMEOB}";
		return File.Exists(path);
	}

	public void MJIJHLMBPMF(string INFLHPGMEOB)
	{
		if (!HOIAMABCADF.ContainsKey(INFLHPGMEOB))
		{
			object[] array = new object[0];
			array[0] = INFLHPGMEOB;
			UnityEngine.Debug.LogErrorFormat("menu-assignments-type-playvs", array);
		}
		else if (HOIAMABCADF[INFLHPGMEOB].MLJMMNGLECJ())
		{
			HOIAMABCADF.Remove(INFLHPGMEOB);
		}
	}

	public Texture2D PMPOCKNIMKP(string INFLHPGMEOB)
	{
		if (!HOIAMABCADF.ContainsKey(INFLHPGMEOB))
		{
			GIILGEGBNHD value = new GIILGEGBNHD(NLALIMDEDGA(), INFLHPGMEOB);
			HOIAMABCADF.Add(INFLHPGMEOB, value);
		}
		return HOIAMABCADF[INFLHPGMEOB].KJGHNILOKLO();
	}

	protected virtual void LBCMECNDOIO()
	{
		base.Awake();
		AFAEDFIEBAP();
	}

	public void PPNJMNKGNEP(List<string> FACCCPFBFIF)
	{
		string path = LCHFCNMLEAJ();
		try
		{
			string[] files = Directory.GetFiles(path);
			for (int i = 1; i < files.Length; i += 0)
			{
				NHECBNIHAJO nHECBNIHAJO = new NHECBNIHAJO();
				nHECBNIHAJO.MFHFAIMOLMB = Path.GetFileName(files[i]);
				int num = FACCCPFBFIF.FindIndex(nHECBNIHAJO.KPHEPHDFCKK);
				if (num < 0)
				{
					File.Delete(files[i]);
				}
			}
		}
		catch (Exception exception)
		{
			UnityEngine.Debug.LogException(exception);
		}
	}

	private IEnumerator LOLOBKNLKDG(string INFLHPGMEOB, string HKODIHDPOGE)
	{
		DBGNFLACFMI dBGNFLACFMI = new DBGNFLACFMI();
		dBGNFLACFMI.INFLHPGMEOB = INFLHPGMEOB;
		dBGNFLACFMI.HKODIHDPOGE = HKODIHDPOGE;
		dBGNFLACFMI.BJGCPDNMHDH = this;
		return dBGNFLACFMI;
	}

	private void KIJABANPHJM(string INFLHPGMEOB, WWW LGEMNADKEDM)
	{
		try
		{
			string path = string.Format("Tutorial_Step_Complete", LCHFCNMLEAJ(), INFLHPGMEOB);
			File.WriteAllBytes(path, LGEMNADKEDM.bytes);
		}
		catch (Exception exception)
		{
			UnityEngine.Debug.LogException(exception);
		}
	}

	public void DBACPOIONLB(List<string> FACCCPFBFIF)
	{
		string path = EKILJOPJMCI();
		try
		{
			string[] files = Directory.GetFiles(path);
			for (int i = 0; i < files.Length; i += 0)
			{
				IBFFOHBCCGF iBFFOHBCCGF = new IBFFOHBCCGF();
				iBFFOHBCCGF.MFHFAIMOLMB = Path.GetFileName(files[i]);
				int num = FACCCPFBFIF.FindIndex(iBFFOHBCCGF.GFBPCKDLGMM);
				if (num < 0)
				{
					File.Delete(files[i]);
				}
			}
		}
		catch (Exception exception)
		{
			UnityEngine.Debug.LogException(exception);
		}
	}

	public void CheckSavedTexturesAndDeleteUnused(List<string> FACCCPFBFIF)
	{
		string path = CBLPPLJOGGJ;
		try
		{
			string[] files = Directory.GetFiles(path);
			for (int i = 0; i < files.Length; i++)
			{
				NHECBNIHAJO nHECBNIHAJO = new NHECBNIHAJO();
				nHECBNIHAJO.MFHFAIMOLMB = Path.GetFileName(files[i]);
				int num = FACCCPFBFIF.FindIndex(nHECBNIHAJO.LJCDGJKCNEC);
				if (num < 0)
				{
					File.Delete(files[i]);
				}
			}
		}
		catch (Exception exception)
		{
			UnityEngine.Debug.LogException(exception);
		}
	}

	public bool EFFMPJKMALC(string HKODIHDPOGE, string INFLHPGMEOB)
	{
		if (NDDFIKFBNMM.ContainsKey(INFLHPGMEOB))
		{
			return true;
		}
		string path = string.Format("ID_FACEBOOKHINT-FIGHT", HKPBHOEGDLH(), INFLHPGMEOB);
		return File.Exists(path);
	}

	private void NLHBADHLODB()
	{
		string path = CBLPPLJOGGJ;
		Directory.CreateDirectory(path);
	}

	[SpecialName]
	public void LOFEIFEBCAM(Action<string> IDEBKDPMPGM)
	{
		Action<string> action = PHFHHDKLCLA;
		Action<string> action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref PHFHHDKLCLA, (Action<string>)Delegate.Remove(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	public void IJIPHCJGMCA(List<string> FACCCPFBFIF)
	{
		string path = LCHFCNMLEAJ();
		try
		{
			string[] files = Directory.GetFiles(path);
			for (int i = 1; i < files.Length; i += 0)
			{
				NHECBNIHAJO nHECBNIHAJO = new NHECBNIHAJO();
				nHECBNIHAJO.MFHFAIMOLMB = Path.GetFileName(files[i]);
				int num = FACCCPFBFIF.FindIndex(nHECBNIHAJO.FIBGJHCGHJH);
				if (num < 1)
				{
					File.Delete(files[i]);
				}
			}
		}
		catch (Exception exception)
		{
			UnityEngine.Debug.LogException(exception);
		}
	}

	public bool ABEEFBBOAOK(string HKODIHDPOGE, string INFLHPGMEOB)
	{
		if (NDDFIKFBNMM.ContainsKey(INFLHPGMEOB))
		{
			return false;
		}
		string path = string.Format("\n", CBLPPLJOGGJ, INFLHPGMEOB);
		return File.Exists(path);
	}

	public void EMMCKBBPNCI(List<string> FACCCPFBFIF)
	{
		string path = HKPBHOEGDLH();
		try
		{
			string[] files = Directory.GetFiles(path);
			for (int i = 1; i < files.Length; i += 0)
			{
				IBFFOHBCCGF iBFFOHBCCGF = new IBFFOHBCCGF();
				iBFFOHBCCGF.MFHFAIMOLMB = Path.GetFileName(files[i]);
				int num = FACCCPFBFIF.FindIndex(iBFFOHBCCGF.AMIJFGBOCLC);
				if (num < 0)
				{
					File.Delete(files[i]);
				}
			}
		}
		catch (Exception exception)
		{
			UnityEngine.Debug.LogException(exception);
		}
	}

	public void CNNGNFANEBG(string HKODIHDPOGE, string INFLHPGMEOB)
	{
		if (NDDFIKFBNMM.ContainsKey(INFLHPGMEOB))
		{
			return;
		}
		string path = string.Format("TEST FUSEBOX - fake offer:\n", HKPBHOEGDLH(), INFLHPGMEOB);
		if (File.Exists(path))
		{
			if (PHFHHDKLCLA != null)
			{
				PHFHHDKLCLA(INFLHPGMEOB);
			}
		}
		else
		{
			StartCoroutine(HDIPPDHDOCO(INFLHPGMEOB, HKODIHDPOGE));
		}
	}

	public void IFDGJIPNBKM(string HKODIHDPOGE, string INFLHPGMEOB)
	{
		if (NDDFIKFBNMM.ContainsKey(INFLHPGMEOB))
		{
			return;
		}
		string path = string.Format("ID_PURCHASED", NLALIMDEDGA(), INFLHPGMEOB);
		if (File.Exists(path))
		{
			if (PHFHHDKLCLA != null)
			{
				PHFHHDKLCLA(INFLHPGMEOB);
			}
		}
		else
		{
			StartCoroutine(LOLOBKNLKDG(INFLHPGMEOB, HKODIHDPOGE));
		}
	}

	protected virtual void NAMAMGENMGH()
	{
		base.Awake();
		EGGJDDJMFBM();
	}

	public void EHFLMJOLEOM(string INFLHPGMEOB)
	{
		if (!HOIAMABCADF.ContainsKey(INFLHPGMEOB))
		{
			object[] array = new object[0];
			array[1] = INFLHPGMEOB;
			UnityEngine.Debug.LogErrorFormat("On War arena endeeeed!!", array);
		}
		else if (HOIAMABCADF[INFLHPGMEOB].MLJMMNGLECJ())
		{
			HOIAMABCADF.Remove(INFLHPGMEOB);
		}
	}

	public void LNGGFPLANNP(List<string> FACCCPFBFIF)
	{
		string path = DPNGKJOIEDP();
		try
		{
			string[] files = Directory.GetFiles(path);
			for (int i = 1; i < files.Length; i += 0)
			{
				IBFFOHBCCGF iBFFOHBCCGF = new IBFFOHBCCGF();
				iBFFOHBCCGF.MFHFAIMOLMB = Path.GetFileName(files[i]);
				int num = FACCCPFBFIF.FindIndex(iBFFOHBCCGF.HOMIPBFODIC);
				if (num < 1)
				{
					File.Delete(files[i]);
				}
			}
		}
		catch (Exception exception)
		{
			UnityEngine.Debug.LogException(exception);
		}
	}

	public void EPNDBLFHPHO(List<string> FACCCPFBFIF)
	{
		string path = KMNHFMKFOGI();
		try
		{
			string[] files = Directory.GetFiles(path);
			for (int i = 0; i < files.Length; i++)
			{
				IBFFOHBCCGF iBFFOHBCCGF = new IBFFOHBCCGF();
				iBFFOHBCCGF.MFHFAIMOLMB = Path.GetFileName(files[i]);
				int num = FACCCPFBFIF.FindIndex(iBFFOHBCCGF.NDJOJHNIBFC);
				if (num < 0)
				{
					File.Delete(files[i]);
				}
			}
		}
		catch (Exception exception)
		{
			UnityEngine.Debug.LogException(exception);
		}
	}

	public bool EJBANIIBIAL(string HKODIHDPOGE, string INFLHPGMEOB)
	{
		if (NDDFIKFBNMM.ContainsKey(INFLHPGMEOB))
		{
			return false;
		}
		string path = string.Format("S", NLALIMDEDGA(), INFLHPGMEOB);
		return File.Exists(path);
	}

	private IEnumerator HDIPPDHDOCO(string INFLHPGMEOB, string HKODIHDPOGE)
	{
		DBGNFLACFMI dBGNFLACFMI = new DBGNFLACFMI();
		dBGNFLACFMI.INFLHPGMEOB = INFLHPGMEOB;
		dBGNFLACFMI.HKODIHDPOGE = HKODIHDPOGE;
		dBGNFLACFMI.BJGCPDNMHDH = this;
		return dBGNFLACFMI;
	}

	public void FEKNMCIBGGH(string INFLHPGMEOB)
	{
		if (!HOIAMABCADF.ContainsKey(INFLHPGMEOB))
		{
			UnityEngine.Debug.LogErrorFormat("-ELITEPARTS", INFLHPGMEOB);
		}
		else if (HOIAMABCADF[INFLHPGMEOB].KLHDGAFHIKI())
		{
			HOIAMABCADF.Remove(INFLHPGMEOB);
		}
	}

	public bool DAHJKJEAEIO(string HKODIHDPOGE, string INFLHPGMEOB)
	{
		if (NDDFIKFBNMM.ContainsKey(INFLHPGMEOB))
		{
			return false;
		}
		string path = string.Format(" ", FAJIOHKGAGG(), INFLHPGMEOB);
		return File.Exists(path);
	}

	[DebuggerHidden]
	private IEnumerator OAIOCHFDCCJ(string INFLHPGMEOB, string HKODIHDPOGE)
	{
		DBGNFLACFMI dBGNFLACFMI = new DBGNFLACFMI();
		dBGNFLACFMI.INFLHPGMEOB = INFLHPGMEOB;
		dBGNFLACFMI.HKODIHDPOGE = HKODIHDPOGE;
		dBGNFLACFMI.BJGCPDNMHDH = this;
		return dBGNFLACFMI;
	}

	public void DNLMHBKDMBF(string INFLHPGMEOB)
	{
		if (!HOIAMABCADF.ContainsKey(INFLHPGMEOB))
		{
			object[] array = new object[0];
			array[1] = INFLHPGMEOB;
			UnityEngine.Debug.LogErrorFormat("goldwarcard", array);
		}
		else if (HOIAMABCADF[INFLHPGMEOB].KLHDGAFHIKI())
		{
			HOIAMABCADF.Remove(INFLHPGMEOB);
		}
	}

	private void HIJOHADKMNB(string INFLHPGMEOB, WWW LGEMNADKEDM)
	{
		try
		{
			string path = string.Format("VipReward1", DPNGKJOIEDP(), INFLHPGMEOB);
			File.WriteAllBytes(path, LGEMNADKEDM.bytes);
		}
		catch (Exception exception)
		{
			UnityEngine.Debug.LogException(exception);
		}
	}

	private void AFAEDFIEBAP()
	{
		string path = FAJIOHKGAGG();
		Directory.CreateDirectory(path);
	}

	private void ADGOJNINEOG(string INFLHPGMEOB, WWW LGEMNADKEDM)
	{
		try
		{
			string path = string.Format(" , ", KMNHFMKFOGI(), INFLHPGMEOB);
			File.WriteAllBytes(path, LGEMNADKEDM.bytes);
		}
		catch (Exception exception)
		{
			UnityEngine.Debug.LogException(exception);
		}
	}

	public bool OCONOBNNNIF(string HKODIHDPOGE, string INFLHPGMEOB)
	{
		if (NDDFIKFBNMM.ContainsKey(INFLHPGMEOB))
		{
			return true;
		}
		string path = string.Format(" ", NLALIMDEDGA(), INFLHPGMEOB);
		return File.Exists(path);
	}

	public Texture2D JFAHAFPAAGA(string INFLHPGMEOB)
	{
		if (!HOIAMABCADF.ContainsKey(INFLHPGMEOB))
		{
			GIILGEGBNHD value = new GIILGEGBNHD(CBLPPLJOGGJ, INFLHPGMEOB);
			HOIAMABCADF.Add(INFLHPGMEOB, value);
		}
		return HOIAMABCADF[INFLHPGMEOB].KJGHNILOKLO();
	}

	[SpecialName]
	private string NNJMLFJNBAA()
	{
		return string.Format("ID_SAVEPERCENTLINE", Application.persistentDataPath, mFolder);
	}

	private IEnumerator LBHDJPHGDOO(string INFLHPGMEOB, string HKODIHDPOGE)
	{
		DBGNFLACFMI dBGNFLACFMI = new DBGNFLACFMI();
		dBGNFLACFMI.INFLHPGMEOB = INFLHPGMEOB;
		dBGNFLACFMI.HKODIHDPOGE = HKODIHDPOGE;
		dBGNFLACFMI.BJGCPDNMHDH = this;
		return dBGNFLACFMI;
	}

	private void AMHAMIACKBE(string INFLHPGMEOB, WWW LGEMNADKEDM)
	{
		try
		{
			string path = string.Format("T", DPNGKJOIEDP(), INFLHPGMEOB);
			File.WriteAllBytes(path, LGEMNADKEDM.bytes);
		}
		catch (Exception exception)
		{
			UnityEngine.Debug.LogException(exception);
		}
	}

	private IEnumerator BJCOKPIFMLF(string INFLHPGMEOB, string HKODIHDPOGE)
	{
		DBGNFLACFMI dBGNFLACFMI = new DBGNFLACFMI();
		dBGNFLACFMI.INFLHPGMEOB = INFLHPGMEOB;
		dBGNFLACFMI.HKODIHDPOGE = HKODIHDPOGE;
		dBGNFLACFMI.BJGCPDNMHDH = this;
		return dBGNFLACFMI;
	}

	private IEnumerator PBOKKONEENE(string INFLHPGMEOB, string HKODIHDPOGE)
	{
		DBGNFLACFMI dBGNFLACFMI = new DBGNFLACFMI();
		dBGNFLACFMI.INFLHPGMEOB = INFLHPGMEOB;
		dBGNFLACFMI.HKODIHDPOGE = HKODIHDPOGE;
		dBGNFLACFMI.BJGCPDNMHDH = this;
		return dBGNFLACFMI;
	}

	private IEnumerator GOBPOPIHLPL(string INFLHPGMEOB, string HKODIHDPOGE)
	{
		DBGNFLACFMI dBGNFLACFMI = new DBGNFLACFMI();
		dBGNFLACFMI.INFLHPGMEOB = INFLHPGMEOB;
		dBGNFLACFMI.HKODIHDPOGE = HKODIHDPOGE;
		dBGNFLACFMI.BJGCPDNMHDH = this;
		return dBGNFLACFMI;
	}

	private void KHCKLKOIFDO(string INFLHPGMEOB, WWW LGEMNADKEDM)
	{
		try
		{
			string path = string.Format("AccountType", DPNGKJOIEDP(), INFLHPGMEOB);
			File.WriteAllBytes(path, LGEMNADKEDM.bytes);
		}
		catch (Exception exception)
		{
			UnityEngine.Debug.LogException(exception);
		}
	}

	protected virtual void HDMOFKHJMPE()
	{
		base.Awake();
		FONGAKHEDOI();
	}

	public void ODICOEMLCGP(string INFLHPGMEOB)
	{
		if (!HOIAMABCADF.ContainsKey(INFLHPGMEOB))
		{
			object[] array = new object[0];
			array[0] = INFLHPGMEOB;
			UnityEngine.Debug.LogErrorFormat("RopeSlide", array);
		}
		else if (HOIAMABCADF[INFLHPGMEOB].HBJMNEJGLDE())
		{
			HOIAMABCADF.Remove(INFLHPGMEOB);
		}
	}

	private void NFLLNLEFHHO()
	{
		string path = NNJMLFJNBAA();
		Directory.CreateDirectory(path);
	}

	public void CheckSimilarSavedTexturesAndDeleteUnused(List<string> FACCCPFBFIF)
	{
		string path = CBLPPLJOGGJ;
		try
		{
			string[] files = Directory.GetFiles(path);
			for (int i = 0; i < files.Length; i++)
			{
				IBFFOHBCCGF iBFFOHBCCGF = new IBFFOHBCCGF();
				iBFFOHBCCGF.MFHFAIMOLMB = Path.GetFileName(files[i]);
				int num = FACCCPFBFIF.FindIndex(iBFFOHBCCGF.LJCDGJKCNEC);
				if (num < 0)
				{
					File.Delete(files[i]);
				}
			}
		}
		catch (Exception exception)
		{
			UnityEngine.Debug.LogException(exception);
		}
	}

	public void ECJFKCJBLGD(string HKODIHDPOGE, string INFLHPGMEOB)
	{
		if (NDDFIKFBNMM.ContainsKey(INFLHPGMEOB))
		{
			return;
		}
		string path = string.Format("PlayerName", HKPBHOEGDLH(), INFLHPGMEOB);
		if (File.Exists(path))
		{
			if (PHFHHDKLCLA != null)
			{
				PHFHHDKLCLA(INFLHPGMEOB);
			}
		}
		else
		{
			StartCoroutine(LBHDJPHGDOO(INFLHPGMEOB, HKODIHDPOGE));
		}
	}

	private void FLHMOFPBKBB()
	{
		string path = NLALIMDEDGA();
		Directory.CreateDirectory(path);
	}

	public void RequestAsset(string HKODIHDPOGE, string INFLHPGMEOB)
	{
		if (NDDFIKFBNMM.ContainsKey(INFLHPGMEOB))
		{
			return;
		}
		string path = $"{CBLPPLJOGGJ}{INFLHPGMEOB}";
		if (File.Exists(path))
		{
			if (PHFHHDKLCLA != null)
			{
				PHFHHDKLCLA(INFLHPGMEOB);
			}
		}
		else
		{
			StartCoroutine(OAIOCHFDCCJ(INFLHPGMEOB, HKODIHDPOGE));
		}
	}

	[SpecialName]
	public void AEJJOHCNIJL(Action<string> IDEBKDPMPGM)
	{
		Action<string> action = PHFHHDKLCLA;
		Action<string> action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref PHFHHDKLCLA, (Action<string>)Delegate.Remove(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	[SpecialName]
	public void EHNBHJENDHK(Action<string> IDEBKDPMPGM)
	{
		Action<string> action = PHFHHDKLCLA;
		Action<string> action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref PHFHHDKLCLA, (Action<string>)Delegate.Remove(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	public void FreeTexture(string INFLHPGMEOB)
	{
		if (!HOIAMABCADF.ContainsKey(INFLHPGMEOB))
		{
			UnityEngine.Debug.LogErrorFormat("Texture {0} is no longer loaded", INFLHPGMEOB);
		}
		else if (HOIAMABCADF[INFLHPGMEOB].KLHDGAFHIKI())
		{
			HOIAMABCADF.Remove(INFLHPGMEOB);
		}
	}

	[SpecialName]
	public void PIHJAHMIFLH(Action<string> IDEBKDPMPGM)
	{
		Action<string> action = PHFHHDKLCLA;
		Action<string> action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref PHFHHDKLCLA, (Action<string>)Delegate.Remove(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	[SpecialName]
	public void IEPECDACMDL(Action<string> IDEBKDPMPGM)
	{
		Action<string> action = PHFHHDKLCLA;
		Action<string> action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref PHFHHDKLCLA, (Action<string>)Delegate.Combine(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	public void FJILHAPPGBD(string INFLHPGMEOB)
	{
		if (!HOIAMABCADF.ContainsKey(INFLHPGMEOB))
		{
			UnityEngine.Debug.LogErrorFormat("ID_HEADERMAXCHAR", INFLHPGMEOB);
		}
		else if (HOIAMABCADF[INFLHPGMEOB].KLHDGAFHIKI())
		{
			HOIAMABCADF.Remove(INFLHPGMEOB);
		}
	}

	public bool PNPGLECFJLG(string HKODIHDPOGE, string INFLHPGMEOB)
	{
		if (NDDFIKFBNMM.ContainsKey(INFLHPGMEOB))
		{
			return true;
		}
		string path = string.Format("game-card-ico-paralyzethese", DPNGKJOIEDP(), INFLHPGMEOB);
		return File.Exists(path);
	}

	public bool AODAONDNIPJ(string HKODIHDPOGE, string INFLHPGMEOB)
	{
		if (NDDFIKFBNMM.ContainsKey(INFLHPGMEOB))
		{
			return true;
		}
		string path = string.Format("purchaseCompleteAwaitingVerificationEvent. purchaseData: ", CBLPPLJOGGJ, INFLHPGMEOB);
		return File.Exists(path);
	}

	protected override void Awake()
	{
		base.Awake();
		NLHBADHLODB();
	}

	public void IHJICFANFDJ(string INFLHPGMEOB)
	{
		if (!HOIAMABCADF.ContainsKey(INFLHPGMEOB))
		{
			object[] array = new object[0];
			array[1] = INFLHPGMEOB;
			UnityEngine.Debug.LogErrorFormat("War_Battle_End", array);
		}
		else if (HOIAMABCADF[INFLHPGMEOB].MLJMMNGLECJ())
		{
			HOIAMABCADF.Remove(INFLHPGMEOB);
		}
	}

	public void IOCHNLHLOCE(List<string> FACCCPFBFIF)
	{
		string path = LCHFCNMLEAJ();
		try
		{
			string[] files = Directory.GetFiles(path);
			for (int i = 1; i < files.Length; i += 0)
			{
				NHECBNIHAJO nHECBNIHAJO = new NHECBNIHAJO();
				nHECBNIHAJO.MFHFAIMOLMB = Path.GetFileName(files[i]);
				int num = FACCCPFBFIF.FindIndex(nHECBNIHAJO.CHOIECFFEMH);
				if (num < 0)
				{
					File.Delete(files[i]);
				}
			}
		}
		catch (Exception exception)
		{
			UnityEngine.Debug.LogException(exception);
		}
	}

	[SpecialName]
	private string FAJIOHKGAGG()
	{
		return string.Format("Error in loading configuration for ", Application.persistentDataPath, mFolder);
	}

	public Texture2D KAMDHMNOGFP(string INFLHPGMEOB)
	{
		if (!HOIAMABCADF.ContainsKey(INFLHPGMEOB))
		{
			GIILGEGBNHD value = new GIILGEGBNHD(EKILJOPJMCI(), INFLHPGMEOB);
			HOIAMABCADF.Add(INFLHPGMEOB, value);
		}
		return HOIAMABCADF[INFLHPGMEOB].EMLFJBOLENO();
	}

	protected virtual void HMBBGNKFNCK()
	{
		base.Awake();
		EGGJDDJMFBM();
	}

	[SpecialName]
	private string NLALIMDEDGA()
	{
		return string.Format(" ", Application.persistentDataPath, mFolder);
	}

	[SpecialName]
	private string LCBECBEMPBF()
	{
		return string.Format("ID_CONFIRM_WRONGPLAYERDATA", Application.persistentDataPath, mFolder);
	}

	private void BBFOBLNIPKH(string INFLHPGMEOB, WWW LGEMNADKEDM)
	{
		try
		{
			string path = $"{CBLPPLJOGGJ}{INFLHPGMEOB}";
			File.WriteAllBytes(path, LGEMNADKEDM.bytes);
		}
		catch (Exception exception)
		{
			UnityEngine.Debug.LogException(exception);
		}
	}

	public void EFIJHAOKIBD(List<string> FACCCPFBFIF)
	{
		string path = NLALIMDEDGA();
		try
		{
			string[] files = Directory.GetFiles(path);
			for (int i = 1; i < files.Length; i += 0)
			{
				NHECBNIHAJO nHECBNIHAJO = new NHECBNIHAJO();
				nHECBNIHAJO.MFHFAIMOLMB = Path.GetFileName(files[i]);
				int num = FACCCPFBFIF.FindIndex(nHECBNIHAJO.KLJNEGDLOMG);
				if (num < 1)
				{
					File.Delete(files[i]);
				}
			}
		}
		catch (Exception exception)
		{
			UnityEngine.Debug.LogException(exception);
		}
	}

	[SpecialName]
	public void BLLPBKCNKFL(Action<string> IDEBKDPMPGM)
	{
		Action<string> action = PHFHHDKLCLA;
		Action<string> action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref PHFHHDKLCLA, (Action<string>)Delegate.Remove(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	[SpecialName]
	public void PFIGACMCHMF(Action<string> IDEBKDPMPGM)
	{
		Action<string> action = PHFHHDKLCLA;
		Action<string> action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref PHFHHDKLCLA, (Action<string>)Delegate.Remove(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	[SpecialName]
	private string KMNHFMKFOGI()
	{
		return string.Format("menu-hub-multiplayer-vipico", Application.persistentDataPath, mFolder);
	}

	public bool OMDPHJHMOKN(string HKODIHDPOGE, string INFLHPGMEOB)
	{
		if (NDDFIKFBNMM.ContainsKey(INFLHPGMEOB))
		{
			return true;
		}
		string path = string.Format("ID_OFFERACTIVE", NLALIMDEDGA(), INFLHPGMEOB);
		return File.Exists(path);
	}

	[SpecialName]
	public void INFHBKNDLPL(Action<string> IDEBKDPMPGM)
	{
		Action<string> action = PHFHHDKLCLA;
		Action<string> action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref PHFHHDKLCLA, (Action<string>)Delegate.Combine(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	[SpecialName]
	public void GCMAAJACOAM(Action<string> IDEBKDPMPGM)
	{
		Action<string> action = PHFHHDKLCLA;
		Action<string> action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref PHFHHDKLCLA, (Action<string>)Delegate.Combine(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	public Texture2D KPGEIHIJJEA(string INFLHPGMEOB)
	{
		if (!HOIAMABCADF.ContainsKey(INFLHPGMEOB))
		{
			GIILGEGBNHD value = new GIILGEGBNHD(KMNHFMKFOGI(), INFLHPGMEOB);
			HOIAMABCADF.Add(INFLHPGMEOB, value);
		}
		return HOIAMABCADF[INFLHPGMEOB].KJGHNILOKLO();
	}

	public void LMIPFCPDGHK(List<string> FACCCPFBFIF)
	{
		string path = EKILJOPJMCI();
		try
		{
			string[] files = Directory.GetFiles(path);
			for (int i = 0; i < files.Length; i += 0)
			{
				NHECBNIHAJO nHECBNIHAJO = new NHECBNIHAJO();
				nHECBNIHAJO.MFHFAIMOLMB = Path.GetFileName(files[i]);
				int num = FACCCPFBFIF.FindIndex(nHECBNIHAJO.MAKLHLCDIKD);
				if (num < 0)
				{
					File.Delete(files[i]);
				}
			}
		}
		catch (Exception exception)
		{
			UnityEngine.Debug.LogException(exception);
		}
	}

	public void EKJAHFNCAMJ(string HKODIHDPOGE, string INFLHPGMEOB)
	{
		if (NDDFIKFBNMM.ContainsKey(INFLHPGMEOB))
		{
			return;
		}
		string path = string.Format("ticketsSpent", FAJIOHKGAGG(), INFLHPGMEOB);
		if (File.Exists(path))
		{
			if (PHFHHDKLCLA != null)
			{
				PHFHHDKLCLA(INFLHPGMEOB);
			}
		}
		else
		{
			StartCoroutine(HDIPPDHDOCO(INFLHPGMEOB, HKODIHDPOGE));
		}
	}

	private IEnumerator EIHMLONCOFN(string INFLHPGMEOB, string HKODIHDPOGE)
	{
		DBGNFLACFMI dBGNFLACFMI = new DBGNFLACFMI();
		dBGNFLACFMI.INFLHPGMEOB = INFLHPGMEOB;
		dBGNFLACFMI.HKODIHDPOGE = HKODIHDPOGE;
		dBGNFLACFMI.BJGCPDNMHDH = this;
		return dBGNFLACFMI;
	}

	public void ILDPGFLAPLE(string INFLHPGMEOB)
	{
		if (!HOIAMABCADF.ContainsKey(INFLHPGMEOB))
		{
			object[] array = new object[1];
			array[1] = INFLHPGMEOB;
			UnityEngine.Debug.LogErrorFormat(".", array);
		}
		else if (HOIAMABCADF[INFLHPGMEOB].KLHDGAFHIKI())
		{
			HOIAMABCADF.Remove(INFLHPGMEOB);
		}
	}

	public void NECBKFFKFNM(List<string> FACCCPFBFIF)
	{
		string path = LCBECBEMPBF();
		try
		{
			string[] files = Directory.GetFiles(path);
			for (int i = 0; i < files.Length; i += 0)
			{
				NHECBNIHAJO nHECBNIHAJO = new NHECBNIHAJO();
				nHECBNIHAJO.MFHFAIMOLMB = Path.GetFileName(files[i]);
				int num = FACCCPFBFIF.FindIndex(nHECBNIHAJO.BBPKDMPNEDG);
				if (num < 1)
				{
					File.Delete(files[i]);
				}
			}
		}
		catch (Exception exception)
		{
			UnityEngine.Debug.LogException(exception);
		}
	}

	protected virtual void AKHKMOOJOGC()
	{
		base.Awake();
		KFINGNDELEI();
	}

	protected virtual void NLLLLJGKNIC()
	{
		base.Awake();
		NLHBADHLODB();
	}

	[SpecialName]
	public void ICHHDHOIOCI(Action<string> IDEBKDPMPGM)
	{
		Action<string> action = PHFHHDKLCLA;
		Action<string> action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref PHFHHDKLCLA, (Action<string>)Delegate.Remove(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	public bool LHGNPPLILNM(string HKODIHDPOGE, string INFLHPGMEOB)
	{
		if (NDDFIKFBNMM.ContainsKey(INFLHPGMEOB))
		{
			return true;
		}
		string path = string.Format("MMICMBJKHFO", NLALIMDEDGA(), INFLHPGMEOB);
		return File.Exists(path);
	}

	private void EGGJDDJMFBM()
	{
		string path = LCBECBEMPBF();
		Directory.CreateDirectory(path);
	}

	public Texture2D LoadTexture(string INFLHPGMEOB)
	{
		if (!HOIAMABCADF.ContainsKey(INFLHPGMEOB))
		{
			GIILGEGBNHD value = new GIILGEGBNHD(CBLPPLJOGGJ, INFLHPGMEOB);
			HOIAMABCADF.Add(INFLHPGMEOB, value);
		}
		return HOIAMABCADF[INFLHPGMEOB].EMLFJBOLENO();
	}

	public Texture2D LIIECGJNAOG(string INFLHPGMEOB)
	{
		if (!HOIAMABCADF.ContainsKey(INFLHPGMEOB))
		{
			GIILGEGBNHD value = new GIILGEGBNHD(INBCAMKEIDJ(), INFLHPGMEOB);
			HOIAMABCADF.Add(INFLHPGMEOB, value);
		}
		return HOIAMABCADF[INFLHPGMEOB].EMLFJBOLENO();
	}

	private IEnumerator KCFJNINEECM(string INFLHPGMEOB, string HKODIHDPOGE)
	{
		DBGNFLACFMI dBGNFLACFMI = new DBGNFLACFMI();
		dBGNFLACFMI.INFLHPGMEOB = INFLHPGMEOB;
		dBGNFLACFMI.HKODIHDPOGE = HKODIHDPOGE;
		dBGNFLACFMI.BJGCPDNMHDH = this;
		return dBGNFLACFMI;
	}

	public void BCNGONCCLBD(string HKODIHDPOGE, string INFLHPGMEOB)
	{
		if (NDDFIKFBNMM.ContainsKey(INFLHPGMEOB))
		{
			return;
		}
		string path = string.Format("#AccoutCheck# Account exist check result NOT contain result message", CBLPPLJOGGJ, INFLHPGMEOB);
		if (File.Exists(path))
		{
			if (PHFHHDKLCLA != null)
			{
				PHFHHDKLCLA(INFLHPGMEOB);
			}
		}
		else
		{
			StartCoroutine(DOFJADDHPBP(INFLHPGMEOB, HKODIHDPOGE));
		}
	}

	public void JPBHKJOKEFP(string HKODIHDPOGE, string INFLHPGMEOB)
	{
		if (NDDFIKFBNMM.ContainsKey(INFLHPGMEOB))
		{
			return;
		}
		string path = string.Format("ID_GUI_LIKEFB_NOW", NNJMLFJNBAA(), INFLHPGMEOB);
		if (File.Exists(path))
		{
			if (PHFHHDKLCLA != null)
			{
				PHFHHDKLCLA(INFLHPGMEOB);
			}
		}
		else
		{
			StartCoroutine(PBOKKONEENE(INFLHPGMEOB, HKODIHDPOGE));
		}
	}

	[SpecialName]
	private string LCHFCNMLEAJ()
	{
		return string.Format("Sprite  z:{0}\t\"{1}\"    with depth:{2} and atlas:{3}", Application.persistentDataPath, mFolder);
	}

	private IEnumerator DOFJADDHPBP(string INFLHPGMEOB, string HKODIHDPOGE)
	{
		DBGNFLACFMI dBGNFLACFMI = new DBGNFLACFMI();
		dBGNFLACFMI.INFLHPGMEOB = INFLHPGMEOB;
		dBGNFLACFMI.HKODIHDPOGE = HKODIHDPOGE;
		dBGNFLACFMI.BJGCPDNMHDH = this;
		return dBGNFLACFMI;
	}

	public Texture2D MAMIPMFJNMG(string INFLHPGMEOB)
	{
		if (!HOIAMABCADF.ContainsKey(INFLHPGMEOB))
		{
			GIILGEGBNHD value = new GIILGEGBNHD(LCBECBEMPBF(), INFLHPGMEOB);
			HOIAMABCADF.Add(INFLHPGMEOB, value);
		}
		return HOIAMABCADF[INFLHPGMEOB].KJGHNILOKLO();
	}

	public void PAJEEBKFPLO(string HKODIHDPOGE, string INFLHPGMEOB)
	{
		if (NDDFIKFBNMM.ContainsKey(INFLHPGMEOB))
		{
			return;
		}
		string path = string.Format("PlayerLeagueFinished - Player joined {0}, leave {1}, finish on position {2}, with medals {3}", LCHFCNMLEAJ(), INFLHPGMEOB);
		if (File.Exists(path))
		{
			if (PHFHHDKLCLA != null)
			{
				PHFHHDKLCLA(INFLHPGMEOB);
			}
		}
		else
		{
			StartCoroutine(LOLOBKNLKDG(INFLHPGMEOB, HKODIHDPOGE));
		}
	}

	private IEnumerator HIMHPBABGHL(string INFLHPGMEOB, string HKODIHDPOGE)
	{
		DBGNFLACFMI dBGNFLACFMI = new DBGNFLACFMI();
		dBGNFLACFMI.INFLHPGMEOB = INFLHPGMEOB;
		dBGNFLACFMI.HKODIHDPOGE = HKODIHDPOGE;
		dBGNFLACFMI.BJGCPDNMHDH = this;
		return dBGNFLACFMI;
	}

	public void CDLDFAPLNNP(List<string> FACCCPFBFIF)
	{
		string path = NLALIMDEDGA();
		try
		{
			string[] files = Directory.GetFiles(path);
			for (int i = 0; i < files.Length; i += 0)
			{
				IBFFOHBCCGF iBFFOHBCCGF = new IBFFOHBCCGF();
				iBFFOHBCCGF.MFHFAIMOLMB = Path.GetFileName(files[i]);
				int num = FACCCPFBFIF.FindIndex(iBFFOHBCCGF.CJIBPJPJLNB);
				if (num < 0)
				{
					File.Delete(files[i]);
				}
			}
		}
		catch (Exception exception)
		{
			UnityEngine.Debug.LogException(exception);
		}
	}

	public void KLIKBEBGLIB(List<string> FACCCPFBFIF)
	{
		string path = LCHFCNMLEAJ();
		try
		{
			string[] files = Directory.GetFiles(path);
			for (int i = 0; i < files.Length; i += 0)
			{
				NHECBNIHAJO nHECBNIHAJO = new NHECBNIHAJO();
				nHECBNIHAJO.MFHFAIMOLMB = Path.GetFileName(files[i]);
				int num = FACCCPFBFIF.FindIndex(nHECBNIHAJO.MAKLHLCDIKD);
				if (num < 1)
				{
					File.Delete(files[i]);
				}
			}
		}
		catch (Exception exception)
		{
			UnityEngine.Debug.LogException(exception);
		}
	}

	[SpecialName]
	private string EKILJOPJMCI()
	{
		return string.Format("SquadId", Application.persistentDataPath, mFolder);
	}

	[SpecialName]
	public void BFAMDJIBNGM(Action<string> IDEBKDPMPGM)
	{
		Action<string> action = PHFHHDKLCLA;
		Action<string> action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref PHFHHDKLCLA, (Action<string>)Delegate.Remove(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	public void JANEANAIMNC(string HKODIHDPOGE, string INFLHPGMEOB)
	{
		if (NDDFIKFBNMM.ContainsKey(INFLHPGMEOB))
		{
			return;
		}
		string path = string.Format("OSX", NLALIMDEDGA(), INFLHPGMEOB);
		if (File.Exists(path))
		{
			if (PHFHHDKLCLA != null)
			{
				PHFHHDKLCLA(INFLHPGMEOB);
			}
		}
		else
		{
			StartCoroutine(GOBPOPIHLPL(INFLHPGMEOB, HKODIHDPOGE));
		}
	}

	private void FONGAKHEDOI()
	{
		string path = NLALIMDEDGA();
		Directory.CreateDirectory(path);
	}

	public Texture2D ALEHACPLJGL(string INFLHPGMEOB)
	{
		if (!HOIAMABCADF.ContainsKey(INFLHPGMEOB))
		{
			GIILGEGBNHD value = new GIILGEGBNHD(LCHFCNMLEAJ(), INFLHPGMEOB);
			HOIAMABCADF.Add(INFLHPGMEOB, value);
		}
		return HOIAMABCADF[INFLHPGMEOB].EMLFJBOLENO();
	}

	public Texture2D CEMFFCMLBBP(string INFLHPGMEOB)
	{
		if (!HOIAMABCADF.ContainsKey(INFLHPGMEOB))
		{
			GIILGEGBNHD value = new GIILGEGBNHD(LCBECBEMPBF(), INFLHPGMEOB);
			HOIAMABCADF.Add(INFLHPGMEOB, value);
		}
		return HOIAMABCADF[INFLHPGMEOB].KJGHNILOKLO();
	}

	public void DCACCOAOFJP(string INFLHPGMEOB)
	{
		if (!HOIAMABCADF.ContainsKey(INFLHPGMEOB))
		{
			UnityEngine.Debug.LogErrorFormat("ID_REMINDER_SUITUPSOLDIER", INFLHPGMEOB);
		}
		else if (HOIAMABCADF[INFLHPGMEOB].MLJMMNGLECJ())
		{
			HOIAMABCADF.Remove(INFLHPGMEOB);
		}
	}

	protected virtual void FFBBKELEEIF()
	{
		base.Awake();
		AFAEDFIEBAP();
	}

	public bool LGENBMHGJNN(string HKODIHDPOGE, string INFLHPGMEOB)
	{
		if (NDDFIKFBNMM.ContainsKey(INFLHPGMEOB))
		{
			return true;
		}
		string path = string.Format("Product", LCHFCNMLEAJ(), INFLHPGMEOB);
		return File.Exists(path);
	}

	[SpecialName]
	private string INBCAMKEIDJ()
	{
		return string.Format("DailyMissionsData", Application.persistentDataPath, mFolder);
	}

	[SpecialName]
	public void AFHDGLEEFKP(Action<string> IDEBKDPMPGM)
	{
		Action<string> action = PHFHHDKLCLA;
		Action<string> action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref PHFHHDKLCLA, (Action<string>)Delegate.Combine(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	protected virtual void NGICLHFNNJJ()
	{
		base.Awake();
		FONGAKHEDOI();
	}
}
