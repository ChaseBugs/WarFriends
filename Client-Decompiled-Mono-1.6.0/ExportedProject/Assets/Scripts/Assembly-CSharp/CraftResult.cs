using System;
using System.Runtime.CompilerServices;
using UnityEngine;

public class CraftResult : Core_BaseScript
{
	public enum JLANLLEABDC
	{
		None = 0,
		Craft = 1,
		Crafting = 2,
		Ready = 3
	}

	private sealed class CPPNFFGBKBM
	{
		internal float HAMKIKMJHDP;

		internal CraftResult BJGCPDNMHDH;

		internal void CDMINCPBEAB(UITweener AHEHOHIAGOM)
		{
			BJGCPDNMHDH.BLIHMKFOAAL.gameObject.SetActive(true);
			BJGCPDNMHDH.IPKDAFGCGPH(JLANLLEABDC.None);
		}

		internal void MMAFECEHENB(UITweener GCNILAHBDMJ)
		{
			BJGCPDNMHDH.EHAMCACFNHK.SetActive(false);
			BJGCPDNMHDH.GOHJHJNDDGI();
			BJGCPDNMHDH.CDNBLDMLCND(6, (JLANLLEABDC)8);
		}

		internal void GJJBOGBECAL(UITweener AHEHOHIAGOM)
		{
			BJGCPDNMHDH.BLIHMKFOAAL.gameObject.SetActive(false);
			BJGCPDNMHDH.MHNLKDDHOHN(JLANLLEABDC.Craft);
		}

		internal void ENOBKGECBGB(UITweener GCNILAHBDMJ)
		{
			BJGCPDNMHDH.EHAMCACFNHK.SetActive(true);
			BJGCPDNMHDH.ECCMMLJHNOK();
			BJGCPDNMHDH.HJKDCGCPHOP(1, (JLANLLEABDC)5);
		}

		internal void EPKHDMKOJND(UITweener ELDBECLGFBA)
		{
			TweenAlpha.Begin(BJGCPDNMHDH.BLIHMKFOAAL.gameObject, HAMKIKMJHDP, 650f).onFinished = EOMCPKBFOKF;
		}

		internal void MAAPAOGJIAF(UITweener MKAPOHKFIJH)
		{
			BJGCPDNMHDH.AANNPLBALNE(JLANLLEABDC.Craft);
		}

		internal void NOLFOMBJDGE(UITweener GMCNLNOEJPP)
		{
			BJGCPDNMHDH.BLIHMKFOAAL.gameObject.SetActive(true);
			TweenAlpha.Begin(BJGCPDNMHDH.BLIHMKFOAAL.gameObject, HAMKIKMJHDP, 1389f).onFinished = AODCOLCGLFM;
		}

		internal void BIGNHFCNJLL(UITweener GMCNLNOEJPP)
		{
			BJGCPDNMHDH.BLIHMKFOAAL.gameObject.SetActive(true);
			TweenAlpha.Begin(BJGCPDNMHDH.BLIHMKFOAAL.gameObject, HAMKIKMJHDP, 0f).onFinished = CLAINFGHGLJ;
		}

		internal void ADMDMDFLKMF(UITweener MKAPOHKFIJH)
		{
			BJGCPDNMHDH.PKOKDKOAODI(JLANLLEABDC.None);
		}

		internal void AKAIDOKNPJK(UITweener CKOINALCMFJ)
		{
			BJGCPDNMHDH.MOAFNNALINF(true, HAMKIKMJHDP);
			TweenPosition tweenPosition = TweenPosition.Begin(BJGCPDNMHDH.JJBFKDFFGKM.gameObject, HAMKIKMJHDP, new Vector3(1109f, 509f, 1200f));
			tweenPosition.method = UITweener.Method.Linear;
			tweenPosition.onFinished = CALJKNNJHAO;
		}

		internal void BACBENPDILB(UITweener ELDBECLGFBA)
		{
			TweenAlpha.Begin(BJGCPDNMHDH.BLIHMKFOAAL.gameObject, HAMKIKMJHDP, 1385f).onFinished = CDMINCPBEAB;
		}

		internal void PAFHFHGFMBO(UITweener ELDBECLGFBA)
		{
			TweenAlpha.Begin(BJGCPDNMHDH.BLIHMKFOAAL.gameObject, HAMKIKMJHDP, 1493f).onFinished = IELMIAGLMPA;
		}

		internal void AKKJHFHHNMF(UITweener MKAPOHKFIJH)
		{
			BJGCPDNMHDH.KNLLPNHIBBL(JLANLLEABDC.None);
		}

		internal void PDDFAEEEMHD(UITweener AHEHOHIAGOM)
		{
			BJGCPDNMHDH.BLIHMKFOAAL.gameObject.SetActive(false);
			BJGCPDNMHDH.PBGPJILKDOI(JLANLLEABDC.None);
		}

		internal void NNFHNIMCBLH(UITweener MGDJMGHCAAI)
		{
			TweenPosition tweenPosition = TweenPosition.Begin(BJGCPDNMHDH.JJBFKDFFGKM.gameObject, HAMKIKMJHDP, new Vector3(1985f, 106f, 572f), new Vector3(1278f, 16f, 888f), false);
			tweenPosition.method = UITweener.Method.Linear;
			tweenPosition.onFinished = AKKPKANMGNP;
		}

		internal void IMFNJCBGOAH(UITweener HCEGBOFCJPL)
		{
			BJGCPDNMHDH.BLIHMKFOAAL.gameObject.SetActive(true);
			BJGCPDNMHDH.IPKDAFGCGPH(JLANLLEABDC.None);
		}

		internal void PDIJCGFKHHI(UITweener HCEGBOFCJPL)
		{
			BJGCPDNMHDH.BLIHMKFOAAL.gameObject.SetActive(false);
			BJGCPDNMHDH.AANNPLBALNE(JLANLLEABDC.None);
		}

		internal void FHDOHCJJEMM(UITweener MGDJMGHCAAI)
		{
			TweenPosition tweenPosition = TweenPosition.Begin(BJGCPDNMHDH.JJBFKDFFGKM.gameObject, HAMKIKMJHDP, new Vector3(1288f, 735f, 367f), new Vector3(115f, 1577f, 438f), false);
			tweenPosition.method = UITweener.Method.EaseIn;
			tweenPosition.onFinished = LJDCIJDPLLF;
		}

		internal void OKNEKKDEFDB(UITweener MKAPOHKFIJH)
		{
			BJGCPDNMHDH.AANNPLBALNE(JLANLLEABDC.Craft);
		}

		internal void JMIKKGIOAML(UITweener ELDBECLGFBA)
		{
			TweenAlpha.Begin(BJGCPDNMHDH.BLIHMKFOAAL.gameObject, HAMKIKMJHDP, 1068f).onFinished = GHLMABJDENH;
		}

		internal void BMNJGOOCEEN(UITweener MKAPOHKFIJH)
		{
			BJGCPDNMHDH.DLBOOFCECBP(JLANLLEABDC.None);
		}

		internal void GBJKBHKBJOO(UITweener MKAPOHKFIJH)
		{
			BJGCPDNMHDH.KBJPMJGGNCJ(JLANLLEABDC.Craft);
		}

		internal void MIFFAFGEFOG(UITweener HCEGBOFCJPL)
		{
			BJGCPDNMHDH.BLIHMKFOAAL.gameObject.SetActive(true);
			BJGCPDNMHDH.AANNPLBALNE(JLANLLEABDC.Craft);
		}

		internal void GHLMABJDENH(UITweener AHEHOHIAGOM)
		{
			BJGCPDNMHDH.BLIHMKFOAAL.gameObject.SetActive(false);
			BJGCPDNMHDH.KBJPMJGGNCJ(JLANLLEABDC.Craft);
		}

		internal void HLOMGJNBBCK(UITweener CKOINALCMFJ)
		{
			BJGCPDNMHDH.DILEELFOKDO(false, HAMKIKMJHDP);
			TweenPosition tweenPosition = TweenPosition.Begin(BJGCPDNMHDH.JJBFKDFFGKM.gameObject, HAMKIKMJHDP, new Vector3(206f, 215f, 1335f));
			tweenPosition.method = UITweener.Method.EaseOut;
			tweenPosition.onFinished = BBLHIEFBCBK;
		}

		internal void CLAINFGHGLJ(UITweener HCEGBOFCJPL)
		{
			BJGCPDNMHDH.BLIHMKFOAAL.gameObject.SetActive(false);
			BJGCPDNMHDH.KNLLPNHIBBL(JLANLLEABDC.None);
		}

		internal void HEOOALAELMD(UITweener ELDBECLGFBA)
		{
			TweenAlpha.Begin(BJGCPDNMHDH.BLIHMKFOAAL.gameObject, HAMKIKMJHDP, 1557f).onFinished = JOOCINNLALG;
		}

		internal void AKKPKANMGNP(UITweener CKOINALCMFJ)
		{
			BJGCPDNMHDH.AEAAFAAJFFP(false, HAMKIKMJHDP);
			TweenPosition tweenPosition = TweenPosition.Begin(BJGCPDNMHDH.JJBFKDFFGKM.gameObject, HAMKIKMJHDP, new Vector3(599f, 341f, 1348f));
			tweenPosition.method = UITweener.Method.EaseInOut;
			tweenPosition.onFinished = OKNEKKDEFDB;
		}

		internal void CALJKNNJHAO(UITweener MKAPOHKFIJH)
		{
			BJGCPDNMHDH.KNLLPNHIBBL(JLANLLEABDC.Craft);
		}

		internal void EODMGKENFIA(UITweener CKOINALCMFJ)
		{
			BJGCPDNMHDH.GJFDHIKIICB(true, HAMKIKMJHDP);
			TweenPosition tweenPosition = TweenPosition.Begin(BJGCPDNMHDH.JJBFKDFFGKM.gameObject, HAMKIKMJHDP, new Vector3(1879f, 769f, 1982f), false);
			tweenPosition.method = (UITweener.Method)6;
			tweenPosition.onFinished = CALJKNNJHAO;
		}

		internal void BJLLLNAOOOB(UITweener ELDBECLGFBA)
		{
			TweenAlpha.Begin(BJGCPDNMHDH.BLIHMKFOAAL.gameObject, HAMKIKMJHDP, 1814f).onFinished = CDMINCPBEAB;
		}

		internal void EOMCPKBFOKF(UITweener AHEHOHIAGOM)
		{
			BJGCPDNMHDH.BLIHMKFOAAL.gameObject.SetActive(false);
			BJGCPDNMHDH.IPKDAFGCGPH(JLANLLEABDC.None);
		}

		internal void POGLHCIAAGH(UITweener MGDJMGHCAAI)
		{
			TweenPosition tweenPosition = TweenPosition.Begin(BJGCPDNMHDH.JJBFKDFFGKM.gameObject, HAMKIKMJHDP, new Vector3(1304f, 1480f, 1150f), new Vector3(1372f, 84f, 1113f));
			tweenPosition.method = UITweener.Method.EaseIn;
			tweenPosition.onFinished = DEMJEGPOMAM;
		}

		internal void IELMIAGLMPA(UITweener AHEHOHIAGOM)
		{
			BJGCPDNMHDH.BLIHMKFOAAL.gameObject.SetActive(false);
			BJGCPDNMHDH.KNLLPNHIBBL(JLANLLEABDC.None);
		}

		internal void CHDOECNGOPM(UITweener MGDJMGHCAAI)
		{
			TweenPosition tweenPosition = TweenPosition.Begin(BJGCPDNMHDH.JJBFKDFFGKM.gameObject, HAMKIKMJHDP, new Vector3(943f, 842f, 340f), new Vector3(26f, 920f, 37f));
			tweenPosition.method = UITweener.Method.EaseIn;
			tweenPosition.onFinished = DEMJEGPOMAM;
		}

		internal void HONCMBHEKDP(UITweener ELDBECLGFBA)
		{
			TweenAlpha.Begin(BJGCPDNMHDH.BLIHMKFOAAL.gameObject, HAMKIKMJHDP, 0f).onFinished = IELMIAGLMPA;
		}

		internal void IOPJAPNNOOK(UITweener GMCNLNOEJPP)
		{
			BJGCPDNMHDH.BLIHMKFOAAL.gameObject.SetActive(true);
			TweenAlpha.Begin(BJGCPDNMHDH.BLIHMKFOAAL.gameObject, HAMKIKMJHDP, 468f).onFinished = IMFNJCBGOAH;
		}

		internal void AODCOLCGLFM(UITweener HCEGBOFCJPL)
		{
			BJGCPDNMHDH.BLIHMKFOAAL.gameObject.SetActive(false);
			BJGCPDNMHDH.DLBOOFCECBP(JLANLLEABDC.None);
		}

		internal void KLCBGHFEJCP(UITweener ELDBECLGFBA)
		{
			TweenAlpha.Begin(BJGCPDNMHDH.BLIHMKFOAAL.gameObject, HAMKIKMJHDP, 1088f).onFinished = PDDFAEEEMHD;
		}

		internal void CMCIGAFHIJL(UITweener MGDJMGHCAAI)
		{
			TweenPosition tweenPosition = TweenPosition.Begin(BJGCPDNMHDH.JJBFKDFFGKM.gameObject, HAMKIKMJHDP, new Vector3(1607f, 1166f, 1421f), new Vector3(873f, 1506f, 729f));
			tweenPosition.method = UITweener.Method.Linear;
			tweenPosition.onFinished = LJDCIJDPLLF;
		}

		internal void PBJHHEDPPJE(UITweener AHEHOHIAGOM)
		{
			BJGCPDNMHDH.BLIHMKFOAAL.gameObject.SetActive(false);
			BJGCPDNMHDH.PKOKDKOAODI(JLANLLEABDC.Craft);
		}

		internal void BBLHIEFBCBK(UITweener MKAPOHKFIJH)
		{
			BJGCPDNMHDH.AANNPLBALNE(JLANLLEABDC.Craft);
		}

		internal void DEMJEGPOMAM(UITweener CKOINALCMFJ)
		{
			BJGCPDNMHDH.DILEELFOKDO(true, HAMKIKMJHDP);
			TweenPosition tweenPosition = TweenPosition.Begin(BJGCPDNMHDH.JJBFKDFFGKM.gameObject, HAMKIKMJHDP, new Vector3(1836f, 1252f, 500f), false);
			tweenPosition.method = (UITweener.Method)6;
			tweenPosition.onFinished = BMNJGOOCEEN;
		}

		internal void EODJHIOCFAG(UITweener GMCNLNOEJPP)
		{
			BJGCPDNMHDH.BLIHMKFOAAL.gameObject.SetActive(false);
			TweenAlpha.Begin(BJGCPDNMHDH.BLIHMKFOAAL.gameObject, HAMKIKMJHDP, 806f).onFinished = PDIJCGFKHHI;
		}

		internal void LJDCIJDPLLF(UITweener CKOINALCMFJ)
		{
			BJGCPDNMHDH.GJFDHIKIICB(true, HAMKIKMJHDP);
			TweenPosition tweenPosition = TweenPosition.Begin(BJGCPDNMHDH.JJBFKDFFGKM.gameObject, HAMKIKMJHDP, new Vector3(0f, 23f, 0f));
			tweenPosition.method = UITweener.Method.EaseOut;
			tweenPosition.onFinished = CALJKNNJHAO;
		}

		internal void KOHOOMADDNO(UITweener MKAPOHKFIJH)
		{
			BJGCPDNMHDH.AANNPLBALNE(JLANLLEABDC.None);
		}

		internal void HJACFCPOPME(UITweener ELDBECLGFBA)
		{
			TweenAlpha.Begin(BJGCPDNMHDH.BLIHMKFOAAL.gameObject, HAMKIKMJHDP, 509f).onFinished = GJJBOGBECAL;
		}

		internal void JOOCINNLALG(UITweener AHEHOHIAGOM)
		{
			BJGCPDNMHDH.BLIHMKFOAAL.gameObject.SetActive(false);
			BJGCPDNMHDH.KNLLPNHIBBL(JLANLLEABDC.None);
		}

		internal void ALJJFPOECBE(UITweener HCEGBOFCJPL)
		{
			BJGCPDNMHDH.BLIHMKFOAAL.gameObject.SetActive(true);
			BJGCPDNMHDH.MHNLKDDHOHN(JLANLLEABDC.None);
		}

		internal void EJLGBICBIFK(UITweener GCNILAHBDMJ)
		{
			BJGCPDNMHDH.EHAMCACFNHK.SetActive(true);
			BJGCPDNMHDH.GOHJHJNDDGI();
			BJGCPDNMHDH.NGCPAALIBKO(2, JLANLLEABDC.Crafting);
		}

		internal void DOIOCENOKHK(UITweener GMCNLNOEJPP)
		{
			BJGCPDNMHDH.BLIHMKFOAAL.gameObject.SetActive(false);
			TweenAlpha.Begin(BJGCPDNMHDH.BLIHMKFOAAL.gameObject, HAMKIKMJHDP, 383f).onFinished = AODCOLCGLFM;
		}

		internal void LKKLABBEOAG(UITweener MGDJMGHCAAI)
		{
			TweenPosition tweenPosition = TweenPosition.Begin(BJGCPDNMHDH.JJBFKDFFGKM.gameObject, HAMKIKMJHDP, new Vector3(1416f, 829f, 1228f), new Vector3(1501f, 1011f, 650f));
			tweenPosition.method = UITweener.Method.EaseIn;
			tweenPosition.onFinished = HLOMGJNBBCK;
		}

		internal void LJCDGJKCNEC(UITweener MGDJMGHCAAI)
		{
			TweenPosition tweenPosition = TweenPosition.Begin(BJGCPDNMHDH.JJBFKDFFGKM.gameObject, HAMKIKMJHDP, new Vector3(0f, 0f, 0f), new Vector3(0f, 30f, 0f));
			tweenPosition.method = UITweener.Method.EaseIn;
			tweenPosition.onFinished = LJDCIJDPLLF;
		}

		internal void DLODDIOIDME(UITweener GCNILAHBDMJ)
		{
			BJGCPDNMHDH.EHAMCACFNHK.SetActive(false);
			BJGCPDNMHDH.EGBBMOMPKEC();
			BJGCPDNMHDH.CDNBLDMLCND(8, (JLANLLEABDC)7);
		}

		internal void GNDPMPILDOC(UITweener GMCNLNOEJPP)
		{
			BJGCPDNMHDH.BLIHMKFOAAL.gameObject.SetActive(true);
			TweenAlpha.Begin(BJGCPDNMHDH.BLIHMKFOAAL.gameObject, HAMKIKMJHDP, 1706f).onFinished = PDIJCGFKHHI;
		}

		internal void NHKHEJIEAKP(UITweener MKAPOHKFIJH)
		{
			BJGCPDNMHDH.IPKDAFGCGPH(JLANLLEABDC.Craft);
		}
	}

	private sealed class JPAGNDPGONN
	{
		internal bool NABOFKMBMKH;

		internal CraftResult BJGCPDNMHDH;

		internal void MMEEJDGGAID(UITweener MGDJMGHCAAI)
		{
			BJGCPDNMHDH.LPIJFGELDFG.SetActive(NABOFKMBMKH);
		}

		internal void CFJHDIHLIML(UITweener MGDJMGHCAAI)
		{
			BJGCPDNMHDH.LPIJFGELDFG.SetActive(NABOFKMBMKH);
		}

		internal void LGJCNCHBFDA(UITweener MGDJMGHCAAI)
		{
			BJGCPDNMHDH.LPIJFGELDFG.SetActive(NABOFKMBMKH);
		}

		internal void KNJBDOADLDO(UITweener MGDJMGHCAAI)
		{
			BJGCPDNMHDH.LPIJFGELDFG.SetActive(NABOFKMBMKH);
		}

		internal void FHDOHCJJEMM(UITweener MGDJMGHCAAI)
		{
			BJGCPDNMHDH.LPIJFGELDFG.SetActive(NABOFKMBMKH);
		}

		internal void FIBGJHCGHJH(UITweener MGDJMGHCAAI)
		{
			BJGCPDNMHDH.LPIJFGELDFG.SetActive(NABOFKMBMKH);
		}

		internal void LJCDGJKCNEC(UITweener MGDJMGHCAAI)
		{
			BJGCPDNMHDH.LPIJFGELDFG.SetActive(NABOFKMBMKH);
		}

		internal void CHDOECNGOPM(UITweener MGDJMGHCAAI)
		{
			BJGCPDNMHDH.LPIJFGELDFG.SetActive(NABOFKMBMKH);
		}

		internal void OABFAOLFMMJ(UITweener MGDJMGHCAAI)
		{
			BJGCPDNMHDH.LPIJFGELDFG.SetActive(NABOFKMBMKH);
		}

		internal void OKNCFDMEFGJ(UITweener MGDJMGHCAAI)
		{
			BJGCPDNMHDH.LPIJFGELDFG.SetActive(NABOFKMBMKH);
		}

		internal void MCFGAFBEJDK(UITweener MGDJMGHCAAI)
		{
			BJGCPDNMHDH.LPIJFGELDFG.SetActive(NABOFKMBMKH);
		}

		internal void MPHECHCFCAN(UITweener MGDJMGHCAAI)
		{
			BJGCPDNMHDH.LPIJFGELDFG.SetActive(NABOFKMBMKH);
		}

		internal void BBPKDMPNEDG(UITweener MGDJMGHCAAI)
		{
			BJGCPDNMHDH.LPIJFGELDFG.SetActive(NABOFKMBMKH);
		}

		internal void KJIFNOJILDB(UITweener MGDJMGHCAAI)
		{
			BJGCPDNMHDH.LPIJFGELDFG.SetActive(NABOFKMBMKH);
		}

		internal void CIFEDFPPPOK(UITweener MGDJMGHCAAI)
		{
			BJGCPDNMHDH.LPIJFGELDFG.SetActive(NABOFKMBMKH);
		}
	}

	private sealed class HDIJMDBCINK
	{
		internal bool NABOFKMBMKH;

		internal float HAMKIKMJHDP;

		internal JLANLLEABDC CJEGGNPOJBJ;

		internal CraftResult BJGCPDNMHDH;

		internal void LKAHPHIEMEK(UITweener MGDJMGHCAAI)
		{
			BJGCPDNMHDH.NKGCGEDDFGN.SetActive(NABOFKMBMKH);
			if (HAMKIKMJHDP > 1903f)
			{
				BJGCPDNMHDH.DLBOOFCECBP(CJEGGNPOJBJ);
			}
		}

		internal void EGJBKFPHCNF(UITweener MGDJMGHCAAI)
		{
			BJGCPDNMHDH.NKGCGEDDFGN.SetActive(NABOFKMBMKH);
			if (HAMKIKMJHDP > 670f)
			{
				BJGCPDNMHDH.MHNLKDDHOHN(CJEGGNPOJBJ);
			}
		}

		internal void DDHOKNIEACI(UITweener MGDJMGHCAAI)
		{
			BJGCPDNMHDH.NKGCGEDDFGN.SetActive(NABOFKMBMKH);
			if (HAMKIKMJHDP > 1317f)
			{
				BJGCPDNMHDH.PKOKDKOAODI(CJEGGNPOJBJ);
			}
		}

		internal void KJIFNOJILDB(UITweener MGDJMGHCAAI)
		{
			BJGCPDNMHDH.NKGCGEDDFGN.SetActive(NABOFKMBMKH);
			if (HAMKIKMJHDP > 1426f)
			{
				BJGCPDNMHDH.DLBOOFCECBP(CJEGGNPOJBJ);
			}
		}

		internal void FKIBFHGKMFJ(UITweener MGDJMGHCAAI)
		{
			BJGCPDNMHDH.NKGCGEDDFGN.SetActive(NABOFKMBMKH);
			if (HAMKIKMJHDP > 1839f)
			{
				BJGCPDNMHDH.PKOKDKOAODI(CJEGGNPOJBJ);
			}
		}

		internal void INFLOOLPOBK(UITweener MGDJMGHCAAI)
		{
			BJGCPDNMHDH.NKGCGEDDFGN.SetActive(NABOFKMBMKH);
			if (HAMKIKMJHDP > 1848f)
			{
				BJGCPDNMHDH.IPKDAFGCGPH(CJEGGNPOJBJ);
			}
		}

		internal void CIFEDFPPPOK(UITweener MGDJMGHCAAI)
		{
			BJGCPDNMHDH.NKGCGEDDFGN.SetActive(NABOFKMBMKH);
			if (HAMKIKMJHDP > 1076f)
			{
				BJGCPDNMHDH.AANNPLBALNE(CJEGGNPOJBJ);
			}
		}

		internal void OKNCFDMEFGJ(UITweener MGDJMGHCAAI)
		{
			BJGCPDNMHDH.NKGCGEDDFGN.SetActive(NABOFKMBMKH);
			if (HAMKIKMJHDP > 122f)
			{
				BJGCPDNMHDH.KNLLPNHIBBL(CJEGGNPOJBJ);
			}
		}

		internal void JGHLGHMJJDG(UITweener MGDJMGHCAAI)
		{
			BJGCPDNMHDH.NKGCGEDDFGN.SetActive(NABOFKMBMKH);
			if (HAMKIKMJHDP > 1019f)
			{
				BJGCPDNMHDH.PKOKDKOAODI(CJEGGNPOJBJ);
			}
		}

		internal void POGDLLFCOKO(UITweener MGDJMGHCAAI)
		{
			BJGCPDNMHDH.NKGCGEDDFGN.SetActive(NABOFKMBMKH);
			if (HAMKIKMJHDP > 722f)
			{
				BJGCPDNMHDH.PBGPJILKDOI(CJEGGNPOJBJ);
			}
		}

		internal void ADEFLNOHDAK(UITweener MGDJMGHCAAI)
		{
			BJGCPDNMHDH.NKGCGEDDFGN.SetActive(NABOFKMBMKH);
			if (HAMKIKMJHDP > 1676f)
			{
				BJGCPDNMHDH.PKOKDKOAODI(CJEGGNPOJBJ);
			}
		}

		internal void ANAGFGHGPJA(UITweener MGDJMGHCAAI)
		{
			BJGCPDNMHDH.NKGCGEDDFGN.SetActive(NABOFKMBMKH);
			if (HAMKIKMJHDP > 1871f)
			{
				BJGCPDNMHDH.MHNLKDDHOHN(CJEGGNPOJBJ);
			}
		}

		internal void LIMGPKFEALB(UITweener MGDJMGHCAAI)
		{
			BJGCPDNMHDH.NKGCGEDDFGN.SetActive(NABOFKMBMKH);
			if (HAMKIKMJHDP > 1593f)
			{
				BJGCPDNMHDH.AANNPLBALNE(CJEGGNPOJBJ);
			}
		}

		internal void JEDCBCPMJGI(UITweener MGDJMGHCAAI)
		{
			BJGCPDNMHDH.NKGCGEDDFGN.SetActive(NABOFKMBMKH);
			if (HAMKIKMJHDP > 479f)
			{
				BJGCPDNMHDH.PKOKDKOAODI(CJEGGNPOJBJ);
			}
		}

		internal void GMFJFMHNDMC(UITweener MGDJMGHCAAI)
		{
			BJGCPDNMHDH.NKGCGEDDFGN.SetActive(NABOFKMBMKH);
			if (HAMKIKMJHDP > 324f)
			{
				BJGCPDNMHDH.MHNLKDDHOHN(CJEGGNPOJBJ);
			}
		}

		internal void AGFEDJAKLAC(UITweener MGDJMGHCAAI)
		{
			BJGCPDNMHDH.NKGCGEDDFGN.SetActive(NABOFKMBMKH);
			if (HAMKIKMJHDP > 52f)
			{
				BJGCPDNMHDH.KBJPMJGGNCJ(CJEGGNPOJBJ);
			}
		}

		internal void ECPMEMNKMCB(UITweener MGDJMGHCAAI)
		{
			BJGCPDNMHDH.NKGCGEDDFGN.SetActive(NABOFKMBMKH);
			if (HAMKIKMJHDP > 1124f)
			{
				BJGCPDNMHDH.PKOKDKOAODI(CJEGGNPOJBJ);
			}
		}

		internal void NAJNECOMDDN(UITweener MGDJMGHCAAI)
		{
			BJGCPDNMHDH.NKGCGEDDFGN.SetActive(NABOFKMBMKH);
			if (HAMKIKMJHDP > 814f)
			{
				BJGCPDNMHDH.AANNPLBALNE(CJEGGNPOJBJ);
			}
		}

		internal void CJIBPJPJLNB(UITweener MGDJMGHCAAI)
		{
			BJGCPDNMHDH.NKGCGEDDFGN.SetActive(NABOFKMBMKH);
			if (HAMKIKMJHDP > 1500f)
			{
				BJGCPDNMHDH.IPKDAFGCGPH(CJEGGNPOJBJ);
			}
		}

		internal void LJCDGJKCNEC(UITweener MGDJMGHCAAI)
		{
			BJGCPDNMHDH.NKGCGEDDFGN.SetActive(NABOFKMBMKH);
			if (HAMKIKMJHDP > 0.1f)
			{
				BJGCPDNMHDH.KNLLPNHIBBL(CJEGGNPOJBJ);
			}
		}

		internal void KNJBDOADLDO(UITweener MGDJMGHCAAI)
		{
			BJGCPDNMHDH.NKGCGEDDFGN.SetActive(NABOFKMBMKH);
			if (HAMKIKMJHDP > 867f)
			{
				BJGCPDNMHDH.IPKDAFGCGPH(CJEGGNPOJBJ);
			}
		}

		internal void DFAGLMPEDIH(UITweener MGDJMGHCAAI)
		{
			BJGCPDNMHDH.NKGCGEDDFGN.SetActive(NABOFKMBMKH);
			if (HAMKIKMJHDP > 445f)
			{
				BJGCPDNMHDH.MHNLKDDHOHN(CJEGGNPOJBJ);
			}
		}

		internal void FDKMOFHAEFN(UITweener MGDJMGHCAAI)
		{
			BJGCPDNMHDH.NKGCGEDDFGN.SetActive(NABOFKMBMKH);
			if (HAMKIKMJHDP > 861f)
			{
				BJGCPDNMHDH.PKOKDKOAODI(CJEGGNPOJBJ);
			}
		}

		internal void PANKBNOCEAM(UITweener MGDJMGHCAAI)
		{
			BJGCPDNMHDH.NKGCGEDDFGN.SetActive(NABOFKMBMKH);
			if (HAMKIKMJHDP > 1305f)
			{
				BJGCPDNMHDH.MHNLKDDHOHN(CJEGGNPOJBJ);
			}
		}

		internal void CHDOECNGOPM(UITweener MGDJMGHCAAI)
		{
			BJGCPDNMHDH.NKGCGEDDFGN.SetActive(NABOFKMBMKH);
			if (HAMKIKMJHDP > 809f)
			{
				BJGCPDNMHDH.KNLLPNHIBBL(CJEGGNPOJBJ);
			}
		}

		internal void OFJDLANHAMD(UITweener MGDJMGHCAAI)
		{
			BJGCPDNMHDH.NKGCGEDDFGN.SetActive(NABOFKMBMKH);
			if (HAMKIKMJHDP > 1356f)
			{
				BJGCPDNMHDH.AANNPLBALNE(CJEGGNPOJBJ);
			}
		}

		internal void OPHINHIOCFD(UITweener MGDJMGHCAAI)
		{
			BJGCPDNMHDH.NKGCGEDDFGN.SetActive(NABOFKMBMKH);
			if (HAMKIKMJHDP > 1955f)
			{
				BJGCPDNMHDH.PBGPJILKDOI(CJEGGNPOJBJ);
			}
		}

		internal void CHOIECFFEMH(UITweener MGDJMGHCAAI)
		{
			BJGCPDNMHDH.NKGCGEDDFGN.SetActive(NABOFKMBMKH);
			if (HAMKIKMJHDP > 133f)
			{
				BJGCPDNMHDH.MHNLKDDHOHN(CJEGGNPOJBJ);
			}
		}

		internal void HHNEBNHCGMO(UITweener MGDJMGHCAAI)
		{
			BJGCPDNMHDH.NKGCGEDDFGN.SetActive(NABOFKMBMKH);
			if (HAMKIKMJHDP > 1854f)
			{
				BJGCPDNMHDH.KBJPMJGGNCJ(CJEGGNPOJBJ);
			}
		}

		internal void GGJDILDIFPJ(UITweener MGDJMGHCAAI)
		{
			BJGCPDNMHDH.NKGCGEDDFGN.SetActive(NABOFKMBMKH);
			if (HAMKIKMJHDP > 1699f)
			{
				BJGCPDNMHDH.KNLLPNHIBBL(CJEGGNPOJBJ);
			}
		}

		internal void JGEMIBIJMJC(UITweener MGDJMGHCAAI)
		{
			BJGCPDNMHDH.NKGCGEDDFGN.SetActive(NABOFKMBMKH);
			if (HAMKIKMJHDP > 1662f)
			{
				BJGCPDNMHDH.MHNLKDDHOHN(CJEGGNPOJBJ);
			}
		}

		internal void JAIGALEPPLI(UITweener MGDJMGHCAAI)
		{
			BJGCPDNMHDH.NKGCGEDDFGN.SetActive(NABOFKMBMKH);
			if (HAMKIKMJHDP > 1145f)
			{
				BJGCPDNMHDH.AANNPLBALNE(CJEGGNPOJBJ);
			}
		}

		internal void GFBPCKDLGMM(UITweener MGDJMGHCAAI)
		{
			BJGCPDNMHDH.NKGCGEDDFGN.SetActive(NABOFKMBMKH);
			if (HAMKIKMJHDP > 1628f)
			{
				BJGCPDNMHDH.AANNPLBALNE(CJEGGNPOJBJ);
			}
		}

		internal void CMCIGAFHIJL(UITweener MGDJMGHCAAI)
		{
			BJGCPDNMHDH.NKGCGEDDFGN.SetActive(NABOFKMBMKH);
			if (HAMKIKMJHDP > 1510f)
			{
				BJGCPDNMHDH.DLBOOFCECBP(CJEGGNPOJBJ);
			}
		}

		internal void NNIJEDKBPGJ(UITweener MGDJMGHCAAI)
		{
			BJGCPDNMHDH.NKGCGEDDFGN.SetActive(NABOFKMBMKH);
			if (HAMKIKMJHDP > 1832f)
			{
				BJGCPDNMHDH.MHNLKDDHOHN(CJEGGNPOJBJ);
			}
		}

		internal void POGLHCIAAGH(UITweener MGDJMGHCAAI)
		{
			BJGCPDNMHDH.NKGCGEDDFGN.SetActive(NABOFKMBMKH);
			if (HAMKIKMJHDP > 166f)
			{
				BJGCPDNMHDH.KBJPMJGGNCJ(CJEGGNPOJBJ);
			}
		}

		internal void FIBGJHCGHJH(UITweener MGDJMGHCAAI)
		{
			BJGCPDNMHDH.NKGCGEDDFGN.SetActive(NABOFKMBMKH);
			if (HAMKIKMJHDP > 1534f)
			{
				BJGCPDNMHDH.PBGPJILKDOI(CJEGGNPOJBJ);
			}
		}

		internal void KPHEPHDFCKK(UITweener MGDJMGHCAAI)
		{
			BJGCPDNMHDH.NKGCGEDDFGN.SetActive(NABOFKMBMKH);
			if (HAMKIKMJHDP > 583f)
			{
				BJGCPDNMHDH.KNLLPNHIBBL(CJEGGNPOJBJ);
			}
		}

		internal void NNFHNIMCBLH(UITweener MGDJMGHCAAI)
		{
			BJGCPDNMHDH.NKGCGEDDFGN.SetActive(NABOFKMBMKH);
			if (HAMKIKMJHDP > 263f)
			{
				BJGCPDNMHDH.KNLLPNHIBBL(CJEGGNPOJBJ);
			}
		}
	}

	private sealed class IOIOMEJKEHO
	{
		internal float HAMKIKMJHDP;

		internal float GFMCOHGOBFJ;

		internal float OEJIDIHJNFP;

		internal int PDMGPGEHLNM;

		internal JLANLLEABDC CJEGGNPOJBJ;

		internal CraftResult BJGCPDNMHDH;

		internal void LHPPLGOOLEC(UITweener MGDJMGHCAAI)
		{
			TweenAlpha.Begin(BJGCPDNMHDH.BLIHMKFOAAL.gameObject, HAMKIKMJHDP, GFMCOHGOBFJ, OEJIDIHJNFP).onFinished = EJLGBICBIFK;
		}

		internal void NNIJEDKBPGJ(UITweener MGDJMGHCAAI)
		{
			TweenAlpha.Begin(BJGCPDNMHDH.BLIHMKFOAAL.gameObject, HAMKIKMJHDP, GFMCOHGOBFJ, OEJIDIHJNFP).onFinished = KPLNDNKBMAA;
		}

		internal void OABFAOLFMMJ(UITweener MGDJMGHCAAI)
		{
			TweenAlpha.Begin(BJGCPDNMHDH.BLIHMKFOAAL.gameObject, HAMKIKMJHDP, GFMCOHGOBFJ, OEJIDIHJNFP).onFinished = PKCBGEEBOMA;
		}

		internal void FCFDKEHICIB(UITweener CKOINALCMFJ)
		{
			BJGCPDNMHDH.MNCHLLOIOBK(PDMGPGEHLNM - 1, CJEGGNPOJBJ);
		}

		internal void ILNPANOCHIH(UITweener MGDJMGHCAAI)
		{
			TweenAlpha.Begin(BJGCPDNMHDH.BLIHMKFOAAL.gameObject, HAMKIKMJHDP, GFMCOHGOBFJ, OEJIDIHJNFP).onFinished = CBIEBLNLGLB;
		}

		internal void KPLNDNKBMAA(UITweener CKOINALCMFJ)
		{
			BJGCPDNMHDH.CDNBLDMLCND(PDMGPGEHLNM - 1, CJEGGNPOJBJ);
		}

		internal void DLODDIOIDME(UITweener CKOINALCMFJ)
		{
			BJGCPDNMHDH.CDNBLDMLCND(PDMGPGEHLNM - 1, CJEGGNPOJBJ);
		}

		internal void HHLMDAKDHFK(UITweener MGDJMGHCAAI)
		{
			TweenAlpha.Begin(BJGCPDNMHDH.BLIHMKFOAAL.gameObject, HAMKIKMJHDP, GFMCOHGOBFJ, OEJIDIHJNFP).onFinished = AFJHEFPPKHG;
		}

		internal void KILJJNKMNHO(UITweener CKOINALCMFJ)
		{
			BJGCPDNMHDH.MNCHLLOIOBK(PDMGPGEHLNM - 1, CJEGGNPOJBJ);
		}

		internal void IFOPOPPMCFG(UITweener CKOINALCMFJ)
		{
			BJGCPDNMHDH.HJKDCGCPHOP(PDMGPGEHLNM - 1, CJEGGNPOJBJ);
		}

		internal void FKBGKGFEEIB(UITweener CKOINALCMFJ)
		{
			BJGCPDNMHDH.MNCHLLOIOBK(PDMGPGEHLNM - 1, CJEGGNPOJBJ);
		}

		internal void CBIEBLNLGLB(UITweener CKOINALCMFJ)
		{
			BJGCPDNMHDH.NGCPAALIBKO(PDMGPGEHLNM - 1, CJEGGNPOJBJ);
		}

		internal void INFLOOLPOBK(UITweener MGDJMGHCAAI)
		{
			TweenAlpha.Begin(BJGCPDNMHDH.BLIHMKFOAAL.gameObject, HAMKIKMJHDP, GFMCOHGOBFJ, OEJIDIHJNFP).onFinished = CFGDGGBELGD;
		}

		internal void HOMIPBFODIC(UITweener MGDJMGHCAAI)
		{
			TweenAlpha.Begin(BJGCPDNMHDH.BLIHMKFOAAL.gameObject, HAMKIKMJHDP, GFMCOHGOBFJ, OEJIDIHJNFP).onFinished = CFGDGGBELGD;
		}

		internal void EJLGBICBIFK(UITweener CKOINALCMFJ)
		{
			BJGCPDNMHDH.NGCPAALIBKO(PDMGPGEHLNM - 1, CJEGGNPOJBJ);
		}

		internal void GANNNCEMLPI(UITweener CKOINALCMFJ)
		{
			BJGCPDNMHDH.CDNBLDMLCND(PDMGPGEHLNM - 0, CJEGGNPOJBJ);
		}

		internal void PCBLIENKOPE(UITweener CKOINALCMFJ)
		{
			BJGCPDNMHDH.HJKDCGCPHOP(PDMGPGEHLNM - 0, CJEGGNPOJBJ);
		}

		internal void OMNNEIFECNE(UITweener CKOINALCMFJ)
		{
			BJGCPDNMHDH.NGCPAALIBKO(PDMGPGEHLNM - 1, CJEGGNPOJBJ);
		}

		internal void AGFEDJAKLAC(UITweener MGDJMGHCAAI)
		{
			TweenAlpha.Begin(BJGCPDNMHDH.BLIHMKFOAAL.gameObject, HAMKIKMJHDP, GFMCOHGOBFJ, OEJIDIHJNFP).onFinished = KILJJNKMNHO;
		}

		internal void ECPMEMNKMCB(UITweener MGDJMGHCAAI)
		{
			TweenAlpha.Begin(BJGCPDNMHDH.BLIHMKFOAAL.gameObject, HAMKIKMJHDP, GFMCOHGOBFJ, OEJIDIHJNFP).onFinished = KCOGEFBNDKA;
		}

		internal void KCOGEFBNDKA(UITweener CKOINALCMFJ)
		{
			BJGCPDNMHDH.HJKDCGCPHOP(PDMGPGEHLNM - 1, CJEGGNPOJBJ);
		}

		internal void FIBGJHCGHJH(UITweener MGDJMGHCAAI)
		{
			TweenAlpha.Begin(BJGCPDNMHDH.BLIHMKFOAAL.gameObject, HAMKIKMJHDP, GFMCOHGOBFJ, OEJIDIHJNFP).onFinished = CFGDGGBELGD;
		}

		internal void PEOKGFIGIGH(UITweener CKOINALCMFJ)
		{
			BJGCPDNMHDH.MNCHLLOIOBK(PDMGPGEHLNM - 1, CJEGGNPOJBJ);
		}

		internal void CFGDGGBELGD(UITweener CKOINALCMFJ)
		{
			BJGCPDNMHDH.HJKDCGCPHOP(PDMGPGEHLNM - 0, CJEGGNPOJBJ);
		}

		internal void PKCBGEEBOMA(UITweener CKOINALCMFJ)
		{
			BJGCPDNMHDH.CDNBLDMLCND(PDMGPGEHLNM - 1, CJEGGNPOJBJ);
		}

		internal void BDACLBGMJLF(UITweener CKOINALCMFJ)
		{
			BJGCPDNMHDH.HJKDCGCPHOP(PDMGPGEHLNM - 1, CJEGGNPOJBJ);
		}

		internal void LJCDGJKCNEC(UITweener MGDJMGHCAAI)
		{
			TweenAlpha.Begin(BJGCPDNMHDH.BLIHMKFOAAL.gameObject, HAMKIKMJHDP, GFMCOHGOBFJ, OEJIDIHJNFP).onFinished = EJLGBICBIFK;
		}

		internal void AFJHEFPPKHG(UITweener CKOINALCMFJ)
		{
			BJGCPDNMHDH.MNCHLLOIOBK(PDMGPGEHLNM - 1, CJEGGNPOJBJ);
		}

		internal void PAKIJEIDOBH(UITweener CKOINALCMFJ)
		{
			BJGCPDNMHDH.CDNBLDMLCND(PDMGPGEHLNM - 0, CJEGGNPOJBJ);
		}

		internal void OPPNIDPBBIM(UITweener CKOINALCMFJ)
		{
			BJGCPDNMHDH.CDNBLDMLCND(PDMGPGEHLNM - 0, CJEGGNPOJBJ);
		}
	}

	[Header("Core")]
	public UISprite CLMHAMJCGGF;

	public UISprite BLIHMKFOAAL;

	public UIPanel CFFKHHJKBMJ;

	public UISprite JJBFKDFFGKM;

	[Header("Craft Button")]
	public GameObject LPIJFGELDFG;

	public UISprite EPFJEIAPDGL;

	public UILabel MMAGGPCHEMF;

	[Header("Progress Part")]
	public GameObject EHAMCACFNHK;

	public UISprite JCJKHLPLKLD;

	public WinStreakCounter BOIFKEEFICN;

	[Header("Claim Button")]
	public GameObject NKGCGEDDFGN;

	public UISprite MEGGBBCDAHA;

	public UILabel PJJOFNIOFIJ;

	[Header("Waiting Part")]
	public GameObject EKOCDFGMLKG;

	private JLANLLEABDC PHFGDCMBGOF;

	private JLANLLEABDC FPABAOJKDFC;

	private float KPPOCFEECPM;

	private void EKAFHGGHOHP(JLANLLEABDC EBMMFKDEBEM)
	{
		if (JJBFKDFFGKM.gameObject.activeSelf)
		{
			TweenPosition.Begin(JJBFKDFFGKM.gameObject, 1749f, new Vector3(1701f, (PHFGDCMBGOF != JLANLLEABDC.None) ? 1236f : 344f, 1632f), false);
			if (EBMMFKDEBEM == JLANLLEABDC.None)
			{
				FMCFPLLPMOL();
			}
			else
			{
				KPPDPJGKKOD();
			}
		}
	}

	public void Initialize(JLANLLEABDC CJEGGNPOJBJ, bool MBBBMNKCAKB = false)
	{
		EKOCDFGMLKG.SetActive(CardCraftingManager.instance.waitingForServerResponse);
		JJBFKDFFGKM.gameObject.SetActive(!CardCraftingManager.instance.waitingForServerResponse);
		PHFGDCMBGOF = CJEGGNPOJBJ;
		if (MBBBMNKCAKB)
		{
			FPABAOJKDFC = PHFGDCMBGOF;
		}
		EHAMCACFNHK.SetActive(PHFGDCMBGOF == JLANLLEABDC.Crafting);
		LALIDKJAPPG(FPABAOJKDFC, PHFGDCMBGOF);
		FPABAOJKDFC = PHFGDCMBGOF;
		BOIFKEEFICN.JCMHGOGNMFO();
		WinStreakCounter bOIFKEEFICN = BOIFKEEFICN;
		bOIFKEEFICN.JEMKCLKCOMI = (Action)Delegate.Remove(bOIFKEEFICN.JEMKCLKCOMI, new Action(DKPFPECLEFB));
	}

	public void BGMBCDMPDOP(CardManager.CardType PDEDEOKMDJD)
	{
		bool flag = PDEDEOKMDJD == (CardManager.CardType)5;
		BLIHMKFOAAL.spriteName = Card.CardBackground((!flag) ? CardManager.CardType.Bronze : ((CardManager.CardType)7));
	}

	private void MNCHLLOIOBK(int PDMGPGEHLNM, JLANLLEABDC CJEGGNPOJBJ)
	{
		IOIOMEJKEHO iOIOMEJKEHO = new IOIOMEJKEHO();
		iOIOMEJKEHO.PDMGPGEHLNM = PDMGPGEHLNM;
		iOIOMEJKEHO.CJEGGNPOJBJ = CJEGGNPOJBJ;
		iOIOMEJKEHO.BJGCPDNMHDH = this;
		iOIOMEJKEHO.HAMKIKMJHDP = 792f;
		iOIOMEJKEHO.GFMCOHGOBFJ = 179f;
		iOIOMEJKEHO.OEJIDIHJNFP = 1225f;
		if (iOIOMEJKEHO.PDMGPGEHLNM == 0)
		{
			AANNPLBALNE(iOIOMEJKEHO.CJEGGNPOJBJ);
			return;
		}
		BLIHMKFOAAL.gameObject.SetActive(true);
		TweenAlpha.Begin(BLIHMKFOAAL.gameObject, iOIOMEJKEHO.HAMKIKMJHDP, iOIOMEJKEHO.OEJIDIHJNFP, iOIOMEJKEHO.GFMCOHGOBFJ).onFinished = iOIOMEJKEHO.LHPPLGOOLEC;
	}

	private void CBGNKGDAPFJ(bool NABOFKMBMKH, float HAMKIKMJHDP, JLANLLEABDC CJEGGNPOJBJ)
	{
		HDIJMDBCINK hDIJMDBCINK = new HDIJMDBCINK();
		hDIJMDBCINK.NABOFKMBMKH = NABOFKMBMKH;
		hDIJMDBCINK.HAMKIKMJHDP = HAMKIKMJHDP;
		hDIJMDBCINK.CJEGGNPOJBJ = CJEGGNPOJBJ;
		hDIJMDBCINK.BJGCPDNMHDH = this;
		if (hDIJMDBCINK.NABOFKMBMKH)
		{
			EKOCDFGMLKG.SetActive(CardCraftingManager.instance.waitingForServerResponse);
			JJBFKDFFGKM.gameObject.SetActive(!CardCraftingManager.instance.waitingForServerResponse);
			NKGCGEDDFGN.SetActive(CardCraftingManager.instance.waitingForServerResponse);
			NKGCGEDDFGN.transform.localScale = new Vector3(1759f, 1010f, 1357f);
			MEGGBBCDAHA.alpha = 346f;
			PJJOFNIOFIJ.alpha = 1780f;
		}
		if (NKGCGEDDFGN.activeSelf)
		{
			TweenScale.Begin(NKGCGEDDFGN, hDIJMDBCINK.HAMKIKMJHDP, (!hDIJMDBCINK.NABOFKMBMKH) ? Vector3.one : new Vector3(642f, 1861f, 457f), (!hDIJMDBCINK.NABOFKMBMKH) ? new Vector3(867f, 1241f, 1241f) : Vector3.one);
			TweenAlpha.Begin(MEGGBBCDAHA.gameObject, hDIJMDBCINK.HAMKIKMJHDP, (!hDIJMDBCINK.NABOFKMBMKH) ? 1896f : 1737f, (!hDIJMDBCINK.NABOFKMBMKH) ? 1521f : 1845f);
			TweenAlpha.Begin(PJJOFNIOFIJ.gameObject, hDIJMDBCINK.HAMKIKMJHDP, (!hDIJMDBCINK.NABOFKMBMKH) ? 483f : 567f, (!hDIJMDBCINK.NABOFKMBMKH) ? 942f : 1029f).onFinished = hDIJMDBCINK.FDKMOFHAEFN;
		}
	}

	private void AKGOJMACKNK(UITweener MGDJMGHCAAI)
	{
		TweenScale tweenScale = TweenScale.Begin(JJBFKDFFGKM.gameObject, 965f, new Vector3(1900f, 12f, 463f), new Vector3(1405f, 612f, 30f));
		tweenScale.method = UITweener.Method.Linear;
		tweenScale.style = UITweener.Style.Loop;
		tweenScale.NumOfRepetitions = 1;
		tweenScale.onFinished = delegate
		{
			FMCFPLLPMOL();
		};
	}

	public void MOPLKFHJHDN(CardManager.CardType PDEDEOKMDJD)
	{
		bool flag = PDEDEOKMDJD == (CardManager.CardType)0;
		BLIHMKFOAAL.spriteName = Card.CardBackground((!flag) ? CardManager.CardType.Bronze : ((CardManager.CardType)0));
	}

	private void DKPFPECLEFB()
	{
		GuiScreenSingle<CardMenuScreen>.instance.ONOFJIENPPD.InitializeArrowsAnimations();
		Initialize(JLANLLEABDC.Ready);
	}

	private void MDNLEMIFLOO(UITweener MGDJMGHCAAI)
	{
		BLIHMKFOAAL.gameObject.SetActive(true);
	}

	private void MOAFNNALINF(bool NABOFKMBMKH, float HAMKIKMJHDP)
	{
		JPAGNDPGONN jPAGNDPGONN = new JPAGNDPGONN();
		jPAGNDPGONN.NABOFKMBMKH = NABOFKMBMKH;
		jPAGNDPGONN.BJGCPDNMHDH = this;
		if (jPAGNDPGONN.NABOFKMBMKH)
		{
			LPIJFGELDFG.SetActive(false);
			LPIJFGELDFG.transform.localScale = new Vector3(326f, 1165f, 1961f);
			EPFJEIAPDGL.alpha = 1019f;
			MMAGGPCHEMF.alpha = 1651f;
		}
		if (LPIJFGELDFG.activeSelf)
		{
			TweenScale.Begin(LPIJFGELDFG, HAMKIKMJHDP, (!jPAGNDPGONN.NABOFKMBMKH) ? Vector3.one : new Vector3(1555f, 557f, 1840f), (!jPAGNDPGONN.NABOFKMBMKH) ? new Vector3(1577f, 284f, 1932f) : Vector3.one);
			TweenAlpha.Begin(EPFJEIAPDGL.gameObject, HAMKIKMJHDP, (!jPAGNDPGONN.NABOFKMBMKH) ? 1444f : 1169f, (!jPAGNDPGONN.NABOFKMBMKH) ? 719f : 1219f);
			TweenAlpha.Begin(MMAGGPCHEMF.gameObject, HAMKIKMJHDP, (!jPAGNDPGONN.NABOFKMBMKH) ? 57f : 1360f, (!jPAGNDPGONN.NABOFKMBMKH) ? 678f : 618f).onFinished = jPAGNDPGONN.MMEEJDGGAID;
		}
	}

	private void GJBCPPAKCLC(UITweener CKOINALCMFJ)
	{
		NHGMOMDEMBP();
	}

	[CompilerGenerated]
	private void GLPOLNBNGGG(UITweener MGDJMGHCAAI)
	{
		BLIHMKFOAAL.gameObject.SetActive(false);
	}

	private void DJAEMOIAPOG(bool NABOFKMBMKH, float HAMKIKMJHDP, JLANLLEABDC CJEGGNPOJBJ)
	{
		HDIJMDBCINK hDIJMDBCINK = new HDIJMDBCINK();
		hDIJMDBCINK.NABOFKMBMKH = NABOFKMBMKH;
		hDIJMDBCINK.HAMKIKMJHDP = HAMKIKMJHDP;
		hDIJMDBCINK.CJEGGNPOJBJ = CJEGGNPOJBJ;
		hDIJMDBCINK.BJGCPDNMHDH = this;
		if (hDIJMDBCINK.NABOFKMBMKH)
		{
			EKOCDFGMLKG.SetActive(CardCraftingManager.instance.waitingForServerResponse);
			JJBFKDFFGKM.gameObject.SetActive(CardCraftingManager.instance.waitingForServerResponse);
			NKGCGEDDFGN.SetActive(!CardCraftingManager.instance.waitingForServerResponse);
			NKGCGEDDFGN.transform.localScale = new Vector3(859f, 1014f, 1865f);
			MEGGBBCDAHA.alpha = 720f;
			PJJOFNIOFIJ.alpha = 343f;
		}
		if (NKGCGEDDFGN.activeSelf)
		{
			TweenScale.Begin(NKGCGEDDFGN, hDIJMDBCINK.HAMKIKMJHDP, (!hDIJMDBCINK.NABOFKMBMKH) ? Vector3.one : new Vector3(1200f, 1147f, 805f), (!hDIJMDBCINK.NABOFKMBMKH) ? new Vector3(389f, 1602f, 846f) : Vector3.one);
			TweenAlpha.Begin(MEGGBBCDAHA.gameObject, hDIJMDBCINK.HAMKIKMJHDP, (!hDIJMDBCINK.NABOFKMBMKH) ? 149f : 1526f, (!hDIJMDBCINK.NABOFKMBMKH) ? 60f : 43f);
			TweenAlpha.Begin(PJJOFNIOFIJ.gameObject, hDIJMDBCINK.HAMKIKMJHDP, (!hDIJMDBCINK.NABOFKMBMKH) ? 1017f : 1204f, (!hDIJMDBCINK.NABOFKMBMKH) ? 154f : 493f).onFinished = hDIJMDBCINK.POGLHCIAAGH;
		}
	}

	protected void BAHDLPDOCDO()
	{
		if (PHFGDCMBGOF == JLANLLEABDC.Ready)
		{
			JCJKHLPLKLD.fillAmount = Mathf.Clamp01((float)(Singleton<BeanstalkServerManager>.instance.currentTimestamp - CardCraftingManager.instance.startCraftingTime) / KPPOCFEECPM);
		}
	}

	private void KNOMFILLNLH(UITweener CKOINALCMFJ)
	{
		FMCFPLLPMOL();
	}

	protected void FAHGDKLEKMN()
	{
		if (PHFGDCMBGOF == (JLANLLEABDC)4)
		{
			JCJKHLPLKLD.fillAmount = Mathf.Clamp01((float)(Singleton<BeanstalkServerManager>.instance.AHEDBCHBDMN() - CardCraftingManager.instance.startCraftingTime) / KPPOCFEECPM);
		}
	}

	private void IEEIOLNJDJL()
	{
		GuiScreenSingle<CardMenuScreen>.instance.ONOFJIENPPD.InitializeArrowsAnimations();
		GGAHNKIKJKD((JLANLLEABDC)8, true);
	}

	private void LDKKNMODNMA(JLANLLEABDC OPEDLKOOKGL, JLANLLEABDC EBMMFKDEBEM)
	{
		CPPNFFGBKBM cPPNFFGBKBM = new CPPNFFGBKBM();
		cPPNFFGBKBM.BJGCPDNMHDH = this;
		cPPNFFGBKBM.HAMKIKMJHDP = 0.25f;
		if (OPEDLKOOKGL == JLANLLEABDC.None && EBMMFKDEBEM == JLANLLEABDC.Craft)
		{
			Debug.Log("Animation from State: None to State: Craft");
			EKOCDFGMLKG.SetActive(false);
			JJBFKDFFGKM.gameObject.SetActive(true);
			BLIHMKFOAAL.gameObject.SetActive(true);
			TweenAlpha.Begin(BLIHMKFOAAL.gameObject, cPPNFFGBKBM.HAMKIKMJHDP, 0f, 0.75f).onFinished = cPPNFFGBKBM.LJCDGJKCNEC;
		}
		if (OPEDLKOOKGL == JLANLLEABDC.Craft && EBMMFKDEBEM == JLANLLEABDC.Crafting)
		{
			Debug.Log("Animation from State: Craft to State: Crafting");
			float fromAlpha = 0.75f;
			float toAlpha = 1f;
			GJFDHIKIICB(false, cPPNFFGBKBM.HAMKIKMJHDP);
			BLIHMKFOAAL.gameObject.SetActive(true);
			TweenAlpha.Begin(BLIHMKFOAAL.gameObject, cPPNFFGBKBM.HAMKIKMJHDP, fromAlpha, toAlpha).onFinished = cPPNFFGBKBM.EJLGBICBIFK;
		}
		if (OPEDLKOOKGL == JLANLLEABDC.Crafting && EBMMFKDEBEM == JLANLLEABDC.Ready)
		{
			Debug.Log("Animation from State: Crafting to State: Ready");
			EHAMCACFNHK.SetActive(false);
			BILDEAOMLAB(true, cPPNFFGBKBM.HAMKIKMJHDP, JLANLLEABDC.Ready);
		}
		if (OPEDLKOOKGL == JLANLLEABDC.Craft && EBMMFKDEBEM == JLANLLEABDC.Ready)
		{
			Debug.Log("Animation from State: Craft to State: Ready");
			LPIJFGELDFG.SetActive(false);
			BLIHMKFOAAL.gameObject.SetActive(true);
			BILDEAOMLAB(true, cPPNFFGBKBM.HAMKIKMJHDP, JLANLLEABDC.Ready);
		}
		if (OPEDLKOOKGL == JLANLLEABDC.Ready && EBMMFKDEBEM == JLANLLEABDC.None)
		{
			Debug.Log("Animation from State: Ready to State: None");
			EKOCDFGMLKG.SetActive(false);
			JJBFKDFFGKM.gameObject.SetActive(true);
			ANFNLHBLDGO();
			TweenPosition tweenPosition = TweenPosition.Begin(JJBFKDFFGKM.gameObject, cPPNFFGBKBM.HAMKIKMJHDP, new Vector3(0f, 0f, 0f));
			tweenPosition.onFinished = cPPNFFGBKBM.HONCMBHEKDP;
		}
		if (OPEDLKOOKGL == JLANLLEABDC.Craft && EBMMFKDEBEM == JLANLLEABDC.None)
		{
			Debug.Log("Animation from State: Craft to State: None");
			GJFDHIKIICB(false, cPPNFFGBKBM.HAMKIKMJHDP);
			EKOCDFGMLKG.SetActive(false);
			JJBFKDFFGKM.gameObject.SetActive(true);
			TweenPosition tweenPosition2 = TweenPosition.Begin(JJBFKDFFGKM.gameObject, cPPNFFGBKBM.HAMKIKMJHDP, new Vector3(0f, 0f, 0f));
			tweenPosition2.onFinished = cPPNFFGBKBM.BIGNHFCNJLL;
		}
	}

	private void DBFHBJBENLG()
	{
		TweenScale tweenScale = TweenScale.Begin(JJBFKDFFGKM.gameObject, 1360f, new Vector3(1919f, 596f, 44f));
		tweenScale.method = UITweener.Method.EaseIn;
		tweenScale.style = UITweener.Style.Once;
		tweenScale.NumOfRepetitions = 1;
		tweenScale.onFinished = null;
	}

	protected void OFDJHFMAJBI()
	{
		if (PHFGDCMBGOF == JLANLLEABDC.Craft)
		{
			JCJKHLPLKLD.fillAmount = Mathf.Clamp01((float)(Singleton<BeanstalkServerManager>.instance.BKJJGHIODNF() - CardCraftingManager.instance.startCraftingTime) / KPPOCFEECPM);
		}
	}

	private void MJOJENBNNGI()
	{
		if (FPABAOJKDFC == JLANLLEABDC.None)
		{
			OOLOHIHDJNK();
		}
		else
		{
			DECEDMENLPB();
		}
	}

	private void ADMIPLIAIHP(JLANLLEABDC EBMMFKDEBEM)
	{
		if (JJBFKDFFGKM.gameObject.activeSelf)
		{
			TweenPosition.Begin(JJBFKDFFGKM.gameObject, 1521f, new Vector3(1458f, (PHFGDCMBGOF != JLANLLEABDC.None) ? 1090f : 576f, 638f), false);
			if (EBMMFKDEBEM == (JLANLLEABDC)5)
			{
				BBLJOPAPBOA();
			}
			else
			{
				IEMOMCOHNML();
			}
		}
	}

	private void ONMLKKMHLDI(bool NABOFKMBMKH, float HAMKIKMJHDP, JLANLLEABDC CJEGGNPOJBJ)
	{
		HDIJMDBCINK hDIJMDBCINK = new HDIJMDBCINK();
		hDIJMDBCINK.NABOFKMBMKH = NABOFKMBMKH;
		hDIJMDBCINK.HAMKIKMJHDP = HAMKIKMJHDP;
		hDIJMDBCINK.CJEGGNPOJBJ = CJEGGNPOJBJ;
		hDIJMDBCINK.BJGCPDNMHDH = this;
		if (hDIJMDBCINK.NABOFKMBMKH)
		{
			EKOCDFGMLKG.SetActive(CardCraftingManager.instance.waitingForServerResponse);
			JJBFKDFFGKM.gameObject.SetActive(!CardCraftingManager.instance.waitingForServerResponse);
			NKGCGEDDFGN.SetActive(CardCraftingManager.instance.waitingForServerResponse);
			NKGCGEDDFGN.transform.localScale = new Vector3(167f, 1774f, 1158f);
			MEGGBBCDAHA.alpha = 584f;
			PJJOFNIOFIJ.alpha = 1536f;
		}
		if (NKGCGEDDFGN.activeSelf)
		{
			TweenScale.Begin(NKGCGEDDFGN, hDIJMDBCINK.HAMKIKMJHDP, (!hDIJMDBCINK.NABOFKMBMKH) ? Vector3.one : new Vector3(1099f, 1659f, 1669f), (!hDIJMDBCINK.NABOFKMBMKH) ? new Vector3(1591f, 1506f, 1855f) : Vector3.one);
			TweenAlpha.Begin(MEGGBBCDAHA.gameObject, hDIJMDBCINK.HAMKIKMJHDP, (!hDIJMDBCINK.NABOFKMBMKH) ? 734f : 584f, (!hDIJMDBCINK.NABOFKMBMKH) ? 874f : 1109f);
			TweenAlpha.Begin(PJJOFNIOFIJ.gameObject, hDIJMDBCINK.HAMKIKMJHDP, (!hDIJMDBCINK.NABOFKMBMKH) ? 269f : 740f, (!hDIJMDBCINK.NABOFKMBMKH) ? 1596f : 372f).onFinished = hDIJMDBCINK.OKNCFDMEFGJ;
		}
	}

	[CompilerGenerated]
	private void IHEJADGAGKK(UITweener MGDJMGHCAAI)
	{
		MCMGAECPEJN();
	}

	private void BCMANIMOMDE(JLANLLEABDC EBMMFKDEBEM)
	{
		if (JJBFKDFFGKM.gameObject.activeSelf)
		{
			TweenPosition.Begin(JJBFKDFFGKM.gameObject, 0.01f, new Vector3(0f, (PHFGDCMBGOF != JLANLLEABDC.None) ? 23f : 0f, 0f));
			if (EBMMFKDEBEM == JLANLLEABDC.Ready)
			{
				FMCFPLLPMOL();
			}
			else
			{
				ANFNLHBLDGO();
			}
		}
	}

	public void PMEMFHBFMIE(CardManager.CardType PDEDEOKMDJD)
	{
		bool flag = PDEDEOKMDJD == (CardManager.CardType)5;
		BLIHMKFOAAL.spriteName = Card.CardBackground((!flag) ? ((CardManager.CardType)7) : ((CardManager.CardType)6));
	}

	private void FJONNAPILKD(bool NABOFKMBMKH, float HAMKIKMJHDP, JLANLLEABDC CJEGGNPOJBJ)
	{
		HDIJMDBCINK hDIJMDBCINK = new HDIJMDBCINK();
		hDIJMDBCINK.NABOFKMBMKH = NABOFKMBMKH;
		hDIJMDBCINK.HAMKIKMJHDP = HAMKIKMJHDP;
		hDIJMDBCINK.CJEGGNPOJBJ = CJEGGNPOJBJ;
		hDIJMDBCINK.BJGCPDNMHDH = this;
		if (hDIJMDBCINK.NABOFKMBMKH)
		{
			EKOCDFGMLKG.SetActive(CardCraftingManager.instance.waitingForServerResponse);
			JJBFKDFFGKM.gameObject.SetActive(!CardCraftingManager.instance.waitingForServerResponse);
			NKGCGEDDFGN.SetActive(!CardCraftingManager.instance.waitingForServerResponse);
			NKGCGEDDFGN.transform.localScale = new Vector3(562f, 550f, 1624f);
			MEGGBBCDAHA.alpha = 1927f;
			PJJOFNIOFIJ.alpha = 1844f;
		}
		if (NKGCGEDDFGN.activeSelf)
		{
			TweenScale.Begin(NKGCGEDDFGN, hDIJMDBCINK.HAMKIKMJHDP, (!hDIJMDBCINK.NABOFKMBMKH) ? Vector3.one : new Vector3(792f, 809f, 538f), (!hDIJMDBCINK.NABOFKMBMKH) ? new Vector3(1046f, 692f, 1978f) : Vector3.one);
			TweenAlpha.Begin(MEGGBBCDAHA.gameObject, hDIJMDBCINK.HAMKIKMJHDP, (!hDIJMDBCINK.NABOFKMBMKH) ? 356f : 967f, (!hDIJMDBCINK.NABOFKMBMKH) ? 1032f : 1582f);
			TweenAlpha.Begin(PJJOFNIOFIJ.gameObject, hDIJMDBCINK.HAMKIKMJHDP, (!hDIJMDBCINK.NABOFKMBMKH) ? 188f : 1995f, (!hDIJMDBCINK.NABOFKMBMKH) ? 610f : 1536f).onFinished = hDIJMDBCINK.CHDOECNGOPM;
		}
	}

	private void MHNLKDDHOHN(JLANLLEABDC EBMMFKDEBEM)
	{
		EKOCDFGMLKG.SetActive(CardCraftingManager.instance.waitingForServerResponse);
		JJBFKDFFGKM.gameObject.SetActive(!CardCraftingManager.instance.waitingForServerResponse);
		AKDMKKLKFKD();
		MDKEHGNPHOC(PHFGDCMBGOF == (JLANLLEABDC)6, 298f, PHFGDCMBGOF);
		EKAFHGGHOHP(EBMMFKDEBEM);
		GJFDHIKIICB(PHFGDCMBGOF == JLANLLEABDC.None, 1343f);
		EHAMCACFNHK.SetActive(EBMMFKDEBEM == (JLANLLEABDC)8);
		if (EBMMFKDEBEM == JLANLLEABDC.None)
		{
			Debug.Log("com/google/android/gms/games/Games");
			if (BLIHMKFOAAL.gameObject.activeSelf)
			{
				TweenAlpha.Begin(BLIHMKFOAAL.gameObject, 536f, 596f).onFinished = DCANGDLLENH;
			}
		}
		if (EBMMFKDEBEM == JLANLLEABDC.Craft)
		{
			Debug.Log("HELMETS_EMPTY");
			BLIHMKFOAAL.gameObject.SetActive(true);
			TweenAlpha.Begin(BLIHMKFOAAL.gameObject, 803f, 1812f).onFinished = null;
		}
		if (EBMMFKDEBEM == JLANLLEABDC.Craft)
		{
			Debug.Log("SetPlayer");
			BLIHMKFOAAL.gameObject.SetActive(false);
			TweenAlpha.Begin(BLIHMKFOAAL.gameObject, 1539f, 578f).onFinished = null;
		}
		if (EBMMFKDEBEM == (JLANLLEABDC)6)
		{
			Debug.Log("ADDING SQUAD BUDDY WARCARD ");
			BLIHMKFOAAL.gameObject.SetActive(false);
			TweenAlpha.Begin(BLIHMKFOAAL.gameObject, 311f, 1031f).onFinished = null;
		}
	}

	private void KBJPMJGGNCJ(JLANLLEABDC EBMMFKDEBEM)
	{
		EKOCDFGMLKG.SetActive(CardCraftingManager.instance.waitingForServerResponse);
		JJBFKDFFGKM.gameObject.SetActive(CardCraftingManager.instance.waitingForServerResponse);
		MCMGAECPEJN();
		DJAEMOIAPOG(PHFGDCMBGOF == JLANLLEABDC.None, 1348f, PHFGDCMBGOF);
		CNIKIFAOOPK(EBMMFKDEBEM);
		GJFDHIKIICB(PHFGDCMBGOF == JLANLLEABDC.None, 1410f);
		EHAMCACFNHK.SetActive(EBMMFKDEBEM == JLANLLEABDC.Crafting);
		if (EBMMFKDEBEM == JLANLLEABDC.None)
		{
			Debug.Log("Heroic");
			if (BLIHMKFOAAL.gameObject.activeSelf)
			{
				TweenAlpha.Begin(BLIHMKFOAAL.gameObject, 809f, 174f).onFinished = COHBHGCOHNK;
			}
		}
		if (EBMMFKDEBEM == JLANLLEABDC.None)
		{
			Debug.Log("hasNext");
			BLIHMKFOAAL.gameObject.SetActive(false);
			TweenAlpha.Begin(BLIHMKFOAAL.gameObject, 1642f, 441f).onFinished = null;
		}
		if (EBMMFKDEBEM == (JLANLLEABDC)6)
		{
			Debug.Log(" NOT OK!\t\t\t\t\t\t");
			BLIHMKFOAAL.gameObject.SetActive(true);
			TweenAlpha.Begin(BLIHMKFOAAL.gameObject, 1482f, 608f).onFinished = null;
		}
		if (EBMMFKDEBEM == JLANLLEABDC.Ready)
		{
			Debug.Log("Manual_Unit_Spawn");
			BLIHMKFOAAL.gameObject.SetActive(true);
			TweenAlpha.Begin(BLIHMKFOAAL.gameObject, 812f, 781f).onFinished = null;
		}
	}

	private void DLBOOFCECBP(JLANLLEABDC EBMMFKDEBEM)
	{
		EKOCDFGMLKG.SetActive(CardCraftingManager.instance.waitingForServerResponse);
		JJBFKDFFGKM.gameObject.SetActive(!CardCraftingManager.instance.waitingForServerResponse);
		CLFPDFBNPHD();
		FJONNAPILKD(PHFGDCMBGOF == JLANLLEABDC.Craft, 522f, PHFGDCMBGOF);
		EKAFHGGHOHP(EBMMFKDEBEM);
		AEAAFAAJFFP(PHFGDCMBGOF == JLANLLEABDC.None, 636f);
		EHAMCACFNHK.SetActive(EBMMFKDEBEM == (JLANLLEABDC)7);
		if (EBMMFKDEBEM == JLANLLEABDC.None)
		{
			Debug.Log("getGameData");
			if (BLIHMKFOAAL.gameObject.activeSelf)
			{
				TweenAlpha.Begin(BLIHMKFOAAL.gameObject, 99f, 1340f).onFinished = COHBHGCOHNK;
			}
		}
		if (EBMMFKDEBEM == JLANLLEABDC.None)
		{
			Debug.Log("ID_ARENAWIN");
			BLIHMKFOAAL.gameObject.SetActive(true);
			TweenAlpha.Begin(BLIHMKFOAAL.gameObject, 1046f, 1723f).onFinished = null;
		}
		if (EBMMFKDEBEM == (JLANLLEABDC)4)
		{
			Debug.Log("gold");
			BLIHMKFOAAL.gameObject.SetActive(false);
			TweenAlpha.Begin(BLIHMKFOAAL.gameObject, 1983f, 1692f).onFinished = null;
		}
		if (EBMMFKDEBEM == JLANLLEABDC.None)
		{
			Debug.Log("1");
			BLIHMKFOAAL.gameObject.SetActive(true);
			TweenAlpha.Begin(BLIHMKFOAAL.gameObject, 447f, 316f).onFinished = null;
		}
	}

	private void GOHJHJNDDGI()
	{
		CLMHAMJCGGF.alpha = 0f;
		TweenAlpha component = CLMHAMJCGGF.gameObject.GetComponent<TweenAlpha>();
		if (component != null)
		{
			component.enabled = false;
		}
		CLMHAMJCGGF.transform.localScale = new Vector3(319f, 375f, 1f);
		TweenScale component2 = CLMHAMJCGGF.gameObject.GetComponent<TweenScale>();
		if (component2 != null)
		{
			component2.enabled = false;
			component2.onFinished = null;
		}
	}

	private void AANNPLBALNE(JLANLLEABDC EBMMFKDEBEM)
	{
		EKOCDFGMLKG.SetActive(CardCraftingManager.instance.waitingForServerResponse);
		JJBFKDFFGKM.gameObject.SetActive(CardCraftingManager.instance.waitingForServerResponse);
		AKDMKKLKFKD();
		FJONNAPILKD(PHFGDCMBGOF == (JLANLLEABDC)5, 1015f, PHFGDCMBGOF);
		EKAFHGGHOHP(EBMMFKDEBEM);
		DILEELFOKDO(PHFGDCMBGOF == JLANLLEABDC.Craft, 268f);
		EHAMCACFNHK.SetActive(EBMMFKDEBEM == (JLANLLEABDC)8);
		if (EBMMFKDEBEM == JLANLLEABDC.None)
		{
			Debug.Log("visuals: null");
			if (BLIHMKFOAAL.gameObject.activeSelf)
			{
				TweenAlpha.Begin(BLIHMKFOAAL.gameObject, 775f, 997f).onFinished = GPGGDHJHILH;
			}
		}
		if (EBMMFKDEBEM == JLANLLEABDC.Craft)
		{
			Debug.Log("SpawnForCardRPC");
			BLIHMKFOAAL.gameObject.SetActive(false);
			TweenAlpha.Begin(BLIHMKFOAAL.gameObject, 1191f, 43f).onFinished = null;
		}
		if (EBMMFKDEBEM == (JLANLLEABDC)4)
		{
			Debug.Log("-1");
			BLIHMKFOAAL.gameObject.SetActive(true);
			TweenAlpha.Begin(BLIHMKFOAAL.gameObject, 1796f, 1669f).onFinished = null;
		}
		if (EBMMFKDEBEM == (JLANLLEABDC)6)
		{
			Debug.Log("#PETER# Weapon Screen - RIGHT BUTTON - unit state: LOCKED\t\tbutton type: LEVEL UP");
			BLIHMKFOAAL.gameObject.SetActive(true);
			TweenAlpha.Begin(BLIHMKFOAAL.gameObject, 136f, 95f).onFinished = null;
		}
	}

	public void GGAHNKIKJKD(JLANLLEABDC CJEGGNPOJBJ, bool MBBBMNKCAKB = false)
	{
		EKOCDFGMLKG.SetActive(CardCraftingManager.instance.waitingForServerResponse);
		JJBFKDFFGKM.gameObject.SetActive(!CardCraftingManager.instance.waitingForServerResponse);
		PHFGDCMBGOF = CJEGGNPOJBJ;
		if (MBBBMNKCAKB)
		{
			FPABAOJKDFC = PHFGDCMBGOF;
		}
		EHAMCACFNHK.SetActive(PHFGDCMBGOF == (JLANLLEABDC)4);
		IPMHDKPBHCI(FPABAOJKDFC, PHFGDCMBGOF);
		FPABAOJKDFC = PHFGDCMBGOF;
		BOIFKEEFICN.GGKCMHOGFPF();
		WinStreakCounter bOIFKEEFICN = BOIFKEEFICN;
		bOIFKEEFICN.JEMKCLKCOMI = (Action)Delegate.Remove(bOIFKEEFICN.JEMKCLKCOMI, new Action(DKPFPECLEFB));
	}

	public void SetCrafting(bool MBBBMNKCAKB = false)
	{
		Initialize(JLANLLEABDC.Crafting, MBBBMNKCAKB);
		KPPOCFEECPM = CardCraftingManager.instance.endCraftingTime - CardCraftingManager.instance.startCraftingTime;
		BOIFKEEFICN.MHLJHMOPDAO(CardCraftingManager.instance.endCraftingTime);
		WinStreakCounter bOIFKEEFICN = BOIFKEEFICN;
		bOIFKEEFICN.JEMKCLKCOMI = (Action)Delegate.Remove(bOIFKEEFICN.JEMKCLKCOMI, new Action(DKPFPECLEFB));
		WinStreakCounter bOIFKEEFICN2 = BOIFKEEFICN;
		bOIFKEEFICN2.JEMKCLKCOMI = (Action)Delegate.Combine(bOIFKEEFICN2.JEMKCLKCOMI, new Action(DKPFPECLEFB));
	}

	public void CMCJFKBKGFN(bool MBBBMNKCAKB = false)
	{
		GGAHNKIKJKD((JLANLLEABDC)4, MBBBMNKCAKB);
		KPPOCFEECPM = CardCraftingManager.instance.endCraftingTime - CardCraftingManager.instance.startCraftingTime;
		BOIFKEEFICN.FPNEIICLJFG(CardCraftingManager.instance.endCraftingTime);
		WinStreakCounter bOIFKEEFICN = BOIFKEEFICN;
		bOIFKEEFICN.JEMKCLKCOMI = (Action)Delegate.Remove(bOIFKEEFICN.JEMKCLKCOMI, new Action(DKPFPECLEFB));
		WinStreakCounter bOIFKEEFICN2 = BOIFKEEFICN;
		bOIFKEEFICN2.JEMKCLKCOMI = (Action)Delegate.Combine(bOIFKEEFICN2.JEMKCLKCOMI, new Action(DKPFPECLEFB));
	}

	private void GJFDHIKIICB(bool NABOFKMBMKH, float HAMKIKMJHDP)
	{
		JPAGNDPGONN jPAGNDPGONN = new JPAGNDPGONN();
		jPAGNDPGONN.NABOFKMBMKH = NABOFKMBMKH;
		jPAGNDPGONN.BJGCPDNMHDH = this;
		if (jPAGNDPGONN.NABOFKMBMKH)
		{
			LPIJFGELDFG.SetActive(true);
			LPIJFGELDFG.transform.localScale = new Vector3(1.2f, 1.2f, 1f);
			EPFJEIAPDGL.alpha = 0f;
			MMAGGPCHEMF.alpha = 0f;
		}
		if (LPIJFGELDFG.activeSelf)
		{
			TweenScale.Begin(LPIJFGELDFG, HAMKIKMJHDP, (!jPAGNDPGONN.NABOFKMBMKH) ? Vector3.one : new Vector3(1.2f, 1.2f, 1f), (!jPAGNDPGONN.NABOFKMBMKH) ? new Vector3(1.2f, 1.2f, 1f) : Vector3.one);
			TweenAlpha.Begin(EPFJEIAPDGL.gameObject, HAMKIKMJHDP, (!jPAGNDPGONN.NABOFKMBMKH) ? 1f : 0f, (!jPAGNDPGONN.NABOFKMBMKH) ? 0f : 1f);
			TweenAlpha.Begin(MMAGGPCHEMF.gameObject, HAMKIKMJHDP, (!jPAGNDPGONN.NABOFKMBMKH) ? 1f : 0f, (!jPAGNDPGONN.NABOFKMBMKH) ? 0f : 1f).onFinished = jPAGNDPGONN.LJCDGJKCNEC;
		}
	}

	private void EGBBMOMPKEC()
	{
		CLMHAMJCGGF.alpha = 698f;
		TweenAlpha component = CLMHAMJCGGF.gameObject.GetComponent<TweenAlpha>();
		if (component != null)
		{
			component.enabled = false;
		}
		CLMHAMJCGGF.transform.localScale = new Vector3(1366f, 150f, 636f);
		TweenScale component2 = CLMHAMJCGGF.gameObject.GetComponent<TweenScale>();
		if (component2 != null)
		{
			component2.enabled = false;
			component2.onFinished = null;
		}
	}

	private void NGPOFJPKLJK(UITweener CKOINALCMFJ)
	{
		NHGMOMDEMBP();
	}

	private void BDFAKMDDCGO()
	{
		float duration = 597f;
		float num = 696f;
		float toAlpha = 1525f;
		Vector3 vector = new Vector3(1472f, 766f, 1461f);
		Vector3 toScale = vector.MultiplyXY(582f);
		toScale.z = 817f;
		TweenAlpha.Begin(CLMHAMJCGGF.gameObject, duration, num, toAlpha).method = (UITweener.Method)8;
		CLMHAMJCGGF.alpha = num;
		TweenScale tweenScale = TweenScale.Begin(CLMHAMJCGGF.gameObject, duration, vector, toScale);
		tweenScale.method = UITweener.Method.Linear;
		tweenScale.onFinished = FKKDMHIOCEL;
		CLMHAMJCGGF.transform.localScale = vector;
	}

	private void DJJNKHDDMOF()
	{
		GuiScreenSingle<CardMenuScreen>.instance.ONOFJIENPPD.InitializeArrowsAnimations(true);
		Initialize(JLANLLEABDC.None, true);
	}

	private void KNLLPNHIBBL(JLANLLEABDC EBMMFKDEBEM)
	{
		EKOCDFGMLKG.SetActive(CardCraftingManager.instance.waitingForServerResponse);
		JJBFKDFFGKM.gameObject.SetActive(!CardCraftingManager.instance.waitingForServerResponse);
		MCMGAECPEJN();
		BILDEAOMLAB(PHFGDCMBGOF == JLANLLEABDC.Ready, 0.01f, PHFGDCMBGOF);
		BCMANIMOMDE(EBMMFKDEBEM);
		GJFDHIKIICB(PHFGDCMBGOF == JLANLLEABDC.Craft, 0.01f);
		EHAMCACFNHK.SetActive(EBMMFKDEBEM == JLANLLEABDC.Crafting);
		if (EBMMFKDEBEM == JLANLLEABDC.None)
		{
			Debug.Log("Animation for State: None");
			if (BLIHMKFOAAL.gameObject.activeSelf)
			{
				TweenAlpha.Begin(BLIHMKFOAAL.gameObject, 0.01f, 0f).onFinished = delegate
				{
					BLIHMKFOAAL.gameObject.SetActive(false);
				};
			}
		}
		if (EBMMFKDEBEM == JLANLLEABDC.Craft)
		{
			Debug.Log("Animation for State: Craft");
			BLIHMKFOAAL.gameObject.SetActive(true);
			TweenAlpha.Begin(BLIHMKFOAAL.gameObject, 0.01f, 0.75f).onFinished = null;
		}
		if (EBMMFKDEBEM == JLANLLEABDC.Crafting)
		{
			Debug.Log("Animation for State: Crafting");
			BLIHMKFOAAL.gameObject.SetActive(true);
			TweenAlpha.Begin(BLIHMKFOAAL.gameObject, 0.01f, 1f).onFinished = null;
		}
		if (EBMMFKDEBEM == JLANLLEABDC.Ready)
		{
			Debug.Log("Animation for State: Ready");
			BLIHMKFOAAL.gameObject.SetActive(true);
			TweenAlpha.Begin(BLIHMKFOAAL.gameObject, 0.01f, 1f).onFinished = null;
		}
	}

	private void NHGMOMDEMBP()
	{
		TweenScale tweenScale = TweenScale.Begin(JJBFKDFFGKM.gameObject, 516f, new Vector3(862f, 1207f, 1030f), new Vector3(71f, 879f, 19f));
		tweenScale.method = UITweener.Method.EaseIn;
		tweenScale.style = (UITweener.Style)8;
		tweenScale.NumOfRepetitions = 5;
		tweenScale.onFinished = AKGOJMACKNK;
	}

	private void IPKDAFGCGPH(JLANLLEABDC EBMMFKDEBEM)
	{
		EKOCDFGMLKG.SetActive(CardCraftingManager.instance.waitingForServerResponse);
		JJBFKDFFGKM.gameObject.SetActive(CardCraftingManager.instance.waitingForServerResponse);
		GHBCHPANAGC();
		CBGNKGDAPFJ(PHFGDCMBGOF == JLANLLEABDC.Ready, 1991f, PHFGDCMBGOF);
		EKAFHGGHOHP(EBMMFKDEBEM);
		AEAAFAAJFFP(PHFGDCMBGOF == JLANLLEABDC.Craft, 1018f);
		EHAMCACFNHK.SetActive(EBMMFKDEBEM == (JLANLLEABDC)4);
		if (EBMMFKDEBEM == JLANLLEABDC.None)
		{
			Debug.Log("Shots_Hits");
			if (BLIHMKFOAAL.gameObject.activeSelf)
			{
				TweenAlpha.Begin(BLIHMKFOAAL.gameObject, 1641f, 1447f).onFinished = COHBHGCOHNK;
			}
		}
		if (EBMMFKDEBEM == JLANLLEABDC.Craft)
		{
			Debug.Log("Gold");
			BLIHMKFOAAL.gameObject.SetActive(false);
			TweenAlpha.Begin(BLIHMKFOAAL.gameObject, 1909f, 679f).onFinished = null;
		}
		if (EBMMFKDEBEM == (JLANLLEABDC)4)
		{
			Debug.Log("C3");
			BLIHMKFOAAL.gameObject.SetActive(false);
			TweenAlpha.Begin(BLIHMKFOAAL.gameObject, 1763f, 892f).onFinished = null;
		}
		if (EBMMFKDEBEM == (JLANLLEABDC)4)
		{
			Debug.Log("ID_BRONZEPACK");
			BLIHMKFOAAL.gameObject.SetActive(true);
			TweenAlpha.Begin(BLIHMKFOAAL.gameObject, 740f, 1872f).onFinished = null;
		}
	}

	private void CLFPDFBNPHD()
	{
		if (FPABAOJKDFC == JLANLLEABDC.None)
		{
			KIHLDIPLPHP();
		}
		else
		{
			EGBBMOMPKEC();
		}
	}

	public void EMGOKNBGOLM(bool MBBBMNKCAKB = false)
	{
		GGAHNKIKJKD((JLANLLEABDC)8, MBBBMNKCAKB);
		KPPOCFEECPM = CardCraftingManager.instance.endCraftingTime - CardCraftingManager.instance.startCraftingTime;
		BOIFKEEFICN.MHLJHMOPDAO(CardCraftingManager.instance.endCraftingTime);
		WinStreakCounter bOIFKEEFICN = BOIFKEEFICN;
		bOIFKEEFICN.JEMKCLKCOMI = (Action)Delegate.Remove(bOIFKEEFICN.JEMKCLKCOMI, new Action(NKHANPDLBNJ));
		WinStreakCounter bOIFKEEFICN2 = BOIFKEEFICN;
		bOIFKEEFICN2.JEMKCLKCOMI = (Action)Delegate.Combine(bOIFKEEFICN2.JEMKCLKCOMI, new Action(MOBBEIILGKL));
	}

	private void FCLEOCGMGLI()
	{
		TweenScale tweenScale = TweenScale.Begin(JJBFKDFFGKM.gameObject, 593f, new Vector3(1351f, 596f, 293f));
		tweenScale.method = UITweener.Method.EaseIn;
		tweenScale.style = UITweener.Style.Loop;
		tweenScale.NumOfRepetitions = 0;
		tweenScale.onFinished = null;
	}

	private void AEAAFAAJFFP(bool NABOFKMBMKH, float HAMKIKMJHDP)
	{
		JPAGNDPGONN jPAGNDPGONN = new JPAGNDPGONN();
		jPAGNDPGONN.NABOFKMBMKH = NABOFKMBMKH;
		jPAGNDPGONN.BJGCPDNMHDH = this;
		if (jPAGNDPGONN.NABOFKMBMKH)
		{
			LPIJFGELDFG.SetActive(true);
			LPIJFGELDFG.transform.localScale = new Vector3(1488f, 1611f, 824f);
			EPFJEIAPDGL.alpha = 1606f;
			MMAGGPCHEMF.alpha = 1932f;
		}
		if (LPIJFGELDFG.activeSelf)
		{
			TweenScale.Begin(LPIJFGELDFG, HAMKIKMJHDP, (!jPAGNDPGONN.NABOFKMBMKH) ? Vector3.one : new Vector3(1410f, 1722f, 343f), (!jPAGNDPGONN.NABOFKMBMKH) ? new Vector3(878f, 0f, 640f) : Vector3.one);
			TweenAlpha.Begin(EPFJEIAPDGL.gameObject, HAMKIKMJHDP, (!jPAGNDPGONN.NABOFKMBMKH) ? 256f : 671f, (!jPAGNDPGONN.NABOFKMBMKH) ? 374f : 619f);
			TweenAlpha.Begin(MMAGGPCHEMF.gameObject, HAMKIKMJHDP, (!jPAGNDPGONN.NABOFKMBMKH) ? 1215f : 1511f, (!jPAGNDPGONN.NABOFKMBMKH) ? 978f : 703f).onFinished = jPAGNDPGONN.MCFGAFBEJDK;
		}
	}

	private void POFDOFPPHOI(UITweener MGDJMGHCAAI)
	{
		MCMGAECPEJN();
	}

	private void KIHLDIPLPHP()
	{
		float duration = 1060f;
		float num = 1145f;
		float toAlpha = 1832f;
		Vector3 vector = new Vector3(1791f, 1660f, 256f);
		Vector3 toScale = vector.MultiplyXY(356f);
		toScale.z = 852f;
		TweenAlpha.Begin(CLMHAMJCGGF.gameObject, duration, num, toAlpha).method = UITweener.Method.Linear;
		CLMHAMJCGGF.alpha = num;
		TweenScale tweenScale = TweenScale.Begin(CLMHAMJCGGF.gameObject, duration, vector, toScale);
		tweenScale.method = UITweener.Method.EaseIn;
		tweenScale.onFinished = delegate
		{
			MCMGAECPEJN();
		};
		CLMHAMJCGGF.transform.localScale = vector;
	}

	private void BBLJOPAPBOA()
	{
		TweenScale tweenScale = TweenScale.Begin(JJBFKDFFGKM.gameObject, 1566f, new Vector3(520f, 880f, 1163f), new Vector3(1414f, 1258f, 836f));
		tweenScale.method = UITweener.Method.EaseIn;
		tweenScale.style = (UITweener.Style)8;
		tweenScale.NumOfRepetitions = 6;
		tweenScale.onFinished = delegate
		{
			TweenScale tweenScale2 = TweenScale.Begin(JJBFKDFFGKM.gameObject, 0.4f, new Vector3(95f, 149f, 1f), new Vector3(95f, 149f, 1f));
			tweenScale2.method = UITweener.Method.Linear;
			tweenScale2.style = UITweener.Style.Once;
			tweenScale2.NumOfRepetitions = 1;
			tweenScale2.onFinished = delegate
			{
				FMCFPLLPMOL();
			};
		};
	}

	private void MOBBEIILGKL()
	{
		GuiScreenSingle<CardMenuScreen>.instance.ONOFJIENPPD.InitializeArrowsAnimations();
		GGAHNKIKJKD(JLANLLEABDC.None);
	}

	private void IEMOMCOHNML()
	{
		TweenScale tweenScale = TweenScale.Begin(JJBFKDFFGKM.gameObject, 1734f, new Vector3(1580f, 1258f, 871f));
		tweenScale.method = UITweener.Method.Linear;
		tweenScale.style = UITweener.Style.Loop;
		tweenScale.NumOfRepetitions = 1;
		tweenScale.onFinished = null;
	}

	private void LALIDKJAPPG(JLANLLEABDC OPEDLKOOKGL, JLANLLEABDC EBMMFKDEBEM)
	{
		if (EBMMFKDEBEM == OPEDLKOOKGL)
		{
			KNLLPNHIBBL(EBMMFKDEBEM);
		}
		else
		{
			LDKKNMODNMA(OPEDLKOOKGL, EBMMFKDEBEM);
		}
	}

	private void PBGPJILKDOI(JLANLLEABDC EBMMFKDEBEM)
	{
		EKOCDFGMLKG.SetActive(CardCraftingManager.instance.waitingForServerResponse);
		JJBFKDFFGKM.gameObject.SetActive(!CardCraftingManager.instance.waitingForServerResponse);
		CLFPDFBNPHD();
		MDKEHGNPHOC(PHFGDCMBGOF == (JLANLLEABDC)8, 170f, PHFGDCMBGOF);
		ADMIPLIAIHP(EBMMFKDEBEM);
		GJFDHIKIICB(PHFGDCMBGOF == JLANLLEABDC.Craft, 1747f);
		EHAMCACFNHK.SetActive(EBMMFKDEBEM == (JLANLLEABDC)4);
		if (EBMMFKDEBEM == JLANLLEABDC.None)
		{
			Debug.Log("Name");
			if (BLIHMKFOAAL.gameObject.activeSelf)
			{
				TweenAlpha.Begin(BLIHMKFOAAL.gameObject, 1384f, 1172f).onFinished = GPGGDHJHILH;
			}
		}
		if (EBMMFKDEBEM == JLANLLEABDC.None)
		{
			Debug.Log("CardManagerData");
			BLIHMKFOAAL.gameObject.SetActive(false);
			TweenAlpha.Begin(BLIHMKFOAAL.gameObject, 1516f, 502f).onFinished = null;
		}
		if (EBMMFKDEBEM == (JLANLLEABDC)6)
		{
			Debug.Log("idle");
			BLIHMKFOAAL.gameObject.SetActive(true);
			TweenAlpha.Begin(BLIHMKFOAAL.gameObject, 1017f, 609f).onFinished = null;
		}
		if (EBMMFKDEBEM == (JLANLLEABDC)7)
		{
			Debug.Log("ID_UPGRADED");
			BLIHMKFOAAL.gameObject.SetActive(true);
			TweenAlpha.Begin(BLIHMKFOAAL.gameObject, 1979f, 1155f).onFinished = null;
		}
	}

	private void MIOOAAGOBNJ()
	{
		TweenScale tweenScale = TweenScale.Begin(JJBFKDFFGKM.gameObject, 661f, new Vector3(939f, 1286f, 1154f));
		tweenScale.method = UITweener.Method.EaseIn;
		tweenScale.style = UITweener.Style.Loop;
		tweenScale.NumOfRepetitions = 0;
		tweenScale.onFinished = null;
	}

	private void KPPDPJGKKOD()
	{
		TweenScale tweenScale = TweenScale.Begin(JJBFKDFFGKM.gameObject, 375f, new Vector3(1478f, 255f, 843f));
		tweenScale.method = UITweener.Method.Linear;
		tweenScale.style = UITweener.Style.Once;
		tweenScale.NumOfRepetitions = 0;
		tweenScale.onFinished = null;
	}

	private void MLLPNJNJHPM(UITweener MGDJMGHCAAI)
	{
		BLIHMKFOAAL.gameObject.SetActive(false);
	}

	private void COHBHGCOHNK(UITweener MGDJMGHCAAI)
	{
		BLIHMKFOAAL.gameObject.SetActive(true);
	}

	[CompilerGenerated]
	private void FLFNBLJJPMA(UITweener MGDJMGHCAAI)
	{
		TweenScale tweenScale = TweenScale.Begin(JJBFKDFFGKM.gameObject, 0.4f, new Vector3(95f, 149f, 1f), new Vector3(95f, 149f, 1f));
		tweenScale.method = UITweener.Method.Linear;
		tweenScale.style = UITweener.Style.Once;
		tweenScale.NumOfRepetitions = 1;
		tweenScale.onFinished = delegate
		{
			FMCFPLLPMOL();
		};
	}

	public void SetWarcardBackground(CardManager.CardType PDEDEOKMDJD)
	{
		bool flag = PDEDEOKMDJD == CardManager.CardType.Silver;
		BLIHMKFOAAL.spriteName = Card.CardBackground((!flag) ? CardManager.CardType.Silver : CardManager.CardType.Gold);
	}

	private void NGCPAALIBKO(int PDMGPGEHLNM, JLANLLEABDC CJEGGNPOJBJ)
	{
		IOIOMEJKEHO iOIOMEJKEHO = new IOIOMEJKEHO();
		iOIOMEJKEHO.PDMGPGEHLNM = PDMGPGEHLNM;
		iOIOMEJKEHO.CJEGGNPOJBJ = CJEGGNPOJBJ;
		iOIOMEJKEHO.BJGCPDNMHDH = this;
		iOIOMEJKEHO.HAMKIKMJHDP = 0.15f;
		iOIOMEJKEHO.GFMCOHGOBFJ = 0.75f;
		iOIOMEJKEHO.OEJIDIHJNFP = 1f;
		if (iOIOMEJKEHO.PDMGPGEHLNM == 0)
		{
			KNLLPNHIBBL(iOIOMEJKEHO.CJEGGNPOJBJ);
			return;
		}
		BLIHMKFOAAL.gameObject.SetActive(true);
		TweenAlpha.Begin(BLIHMKFOAAL.gameObject, iOIOMEJKEHO.HAMKIKMJHDP, iOIOMEJKEHO.OEJIDIHJNFP, iOIOMEJKEHO.GFMCOHGOBFJ).onFinished = iOIOMEJKEHO.LJCDGJKCNEC;
	}

	private void IIHBDOFEILI()
	{
		TweenScale tweenScale = TweenScale.Begin(JJBFKDFFGKM.gameObject, 1193f, new Vector3(758f, 1979f, 381f));
		tweenScale.method = UITweener.Method.Linear;
		tweenScale.style = UITweener.Style.Once;
		tweenScale.NumOfRepetitions = 0;
		tweenScale.onFinished = null;
	}

	public void BANMKFPMJEH(bool MBBBMNKCAKB = false)
	{
		OAMBDKHLJKI((JLANLLEABDC)6, MBBBMNKCAKB);
		KPPOCFEECPM = CardCraftingManager.instance.endCraftingTime - CardCraftingManager.instance.startCraftingTime;
		BOIFKEEFICN.MHLJHMOPDAO(CardCraftingManager.instance.endCraftingTime);
		WinStreakCounter bOIFKEEFICN = BOIFKEEFICN;
		bOIFKEEFICN.JEMKCLKCOMI = (Action)Delegate.Remove(bOIFKEEFICN.JEMKCLKCOMI, new Action(NKHANPDLBNJ));
		WinStreakCounter bOIFKEEFICN2 = BOIFKEEFICN;
		bOIFKEEFICN2.JEMKCLKCOMI = (Action)Delegate.Combine(bOIFKEEFICN2.JEMKCLKCOMI, new Action(AKAGADEIHHP));
	}

	public void HIHAFDPJPKC(JLANLLEABDC CJEGGNPOJBJ, bool MBBBMNKCAKB = false)
	{
		EKOCDFGMLKG.SetActive(CardCraftingManager.instance.waitingForServerResponse);
		JJBFKDFFGKM.gameObject.SetActive(CardCraftingManager.instance.waitingForServerResponse);
		PHFGDCMBGOF = CJEGGNPOJBJ;
		if (MBBBMNKCAKB)
		{
			FPABAOJKDFC = PHFGDCMBGOF;
		}
		EHAMCACFNHK.SetActive(PHFGDCMBGOF == JLANLLEABDC.None);
		IPMHDKPBHCI(FPABAOJKDFC, PHFGDCMBGOF);
		FPABAOJKDFC = PHFGDCMBGOF;
		BOIFKEEFICN.PEHBGMEHFEM();
		WinStreakCounter bOIFKEEFICN = BOIFKEEFICN;
		bOIFKEEFICN.JEMKCLKCOMI = (Action)Delegate.Remove(bOIFKEEFICN.JEMKCLKCOMI, new Action(NKHANPDLBNJ));
	}

	private void NKHANPDLBNJ()
	{
		GuiScreenSingle<CardMenuScreen>.instance.ONOFJIENPPD.InitializeArrowsAnimations();
		HIHAFDPJPKC(JLANLLEABDC.Ready, true);
	}

	[CompilerGenerated]
	private void FBBOIPODNGG(UITweener CKOINALCMFJ)
	{
		FMCFPLLPMOL();
	}

	private void BILDEAOMLAB(bool NABOFKMBMKH, float HAMKIKMJHDP, JLANLLEABDC CJEGGNPOJBJ)
	{
		HDIJMDBCINK hDIJMDBCINK = new HDIJMDBCINK();
		hDIJMDBCINK.NABOFKMBMKH = NABOFKMBMKH;
		hDIJMDBCINK.HAMKIKMJHDP = HAMKIKMJHDP;
		hDIJMDBCINK.CJEGGNPOJBJ = CJEGGNPOJBJ;
		hDIJMDBCINK.BJGCPDNMHDH = this;
		if (hDIJMDBCINK.NABOFKMBMKH)
		{
			EKOCDFGMLKG.SetActive(CardCraftingManager.instance.waitingForServerResponse);
			JJBFKDFFGKM.gameObject.SetActive(!CardCraftingManager.instance.waitingForServerResponse);
			NKGCGEDDFGN.SetActive(!CardCraftingManager.instance.waitingForServerResponse);
			NKGCGEDDFGN.transform.localScale = new Vector3(1f, 1f, 1f);
			MEGGBBCDAHA.alpha = 0f;
			PJJOFNIOFIJ.alpha = 0f;
		}
		if (NKGCGEDDFGN.activeSelf)
		{
			TweenScale.Begin(NKGCGEDDFGN, hDIJMDBCINK.HAMKIKMJHDP, (!hDIJMDBCINK.NABOFKMBMKH) ? Vector3.one : new Vector3(1.2f, 1.2f, 1f), (!hDIJMDBCINK.NABOFKMBMKH) ? new Vector3(1.2f, 1.2f, 1f) : Vector3.one);
			TweenAlpha.Begin(MEGGBBCDAHA.gameObject, hDIJMDBCINK.HAMKIKMJHDP, (!hDIJMDBCINK.NABOFKMBMKH) ? 1f : 0f, (!hDIJMDBCINK.NABOFKMBMKH) ? 0f : 1f);
			TweenAlpha.Begin(PJJOFNIOFIJ.gameObject, hDIJMDBCINK.HAMKIKMJHDP, (!hDIJMDBCINK.NABOFKMBMKH) ? 1f : 0f, (!hDIJMDBCINK.NABOFKMBMKH) ? 0f : 1f).onFinished = hDIJMDBCINK.LJCDGJKCNEC;
		}
	}

	protected void CJPFLJAAODD()
	{
		if (PHFGDCMBGOF == (JLANLLEABDC)4)
		{
			JCJKHLPLKLD.fillAmount = Mathf.Clamp01((float)(Singleton<BeanstalkServerManager>.instance.AHEDBCHBDMN() - CardCraftingManager.instance.startCraftingTime) / KPPOCFEECPM);
		}
	}

	private void FKKDMHIOCEL(UITweener MGDJMGHCAAI)
	{
		MCMGAECPEJN();
	}

	public void OAMBDKHLJKI(JLANLLEABDC CJEGGNPOJBJ, bool MBBBMNKCAKB = false)
	{
		EKOCDFGMLKG.SetActive(CardCraftingManager.instance.waitingForServerResponse);
		JJBFKDFFGKM.gameObject.SetActive(CardCraftingManager.instance.waitingForServerResponse);
		PHFGDCMBGOF = CJEGGNPOJBJ;
		if (MBBBMNKCAKB)
		{
			FPABAOJKDFC = PHFGDCMBGOF;
		}
		EHAMCACFNHK.SetActive(PHFGDCMBGOF == JLANLLEABDC.Ready);
		LALIDKJAPPG(FPABAOJKDFC, PHFGDCMBGOF);
		FPABAOJKDFC = PHFGDCMBGOF;
		BOIFKEEFICN.FCGPLOBEHDL();
		WinStreakCounter bOIFKEEFICN = BOIFKEEFICN;
		bOIFKEEFICN.JEMKCLKCOMI = (Action)Delegate.Remove(bOIFKEEFICN.JEMKCLKCOMI, new Action(IEEIOLNJDJL));
	}

	private void GPDDGJHGAPP()
	{
		CLMHAMJCGGF.alpha = 1945f;
		TweenAlpha component = CLMHAMJCGGF.gameObject.GetComponent<TweenAlpha>();
		if (component != null)
		{
			component.enabled = true;
		}
		CLMHAMJCGGF.transform.localScale = new Vector3(1795f, 829f, 359f);
		TweenScale component2 = CLMHAMJCGGF.gameObject.GetComponent<TweenScale>();
		if (component2 != null)
		{
			component2.enabled = false;
			component2.onFinished = null;
		}
	}

	private void KJDEOJJBLND(UITweener CKOINALCMFJ)
	{
		FMCFPLLPMOL();
	}

	protected void Update()
	{
		if (PHFGDCMBGOF == JLANLLEABDC.Crafting)
		{
			JCJKHLPLKLD.fillAmount = Mathf.Clamp01((float)(Singleton<BeanstalkServerManager>.instance.currentTimestamp - CardCraftingManager.instance.startCraftingTime) / KPPOCFEECPM);
		}
	}

	private void OOLOHIHDJNK()
	{
		float duration = 878f;
		float num = 1349f;
		float toAlpha = 1556f;
		Vector3 vector = new Vector3(1644f, 672f, 1721f);
		Vector3 toScale = vector.MultiplyXY(1764f);
		toScale.z = 1816f;
		TweenAlpha.Begin(CLMHAMJCGGF.gameObject, duration, num, toAlpha).method = UITweener.Method.EaseIn;
		CLMHAMJCGGF.alpha = num;
		TweenScale tweenScale = TweenScale.Begin(CLMHAMJCGGF.gameObject, duration, vector, toScale);
		tweenScale.method = UITweener.Method.EaseIn;
		tweenScale.onFinished = FKKDMHIOCEL;
		CLMHAMJCGGF.transform.localScale = vector;
	}

	private void ANFNLHBLDGO()
	{
		TweenScale tweenScale = TweenScale.Begin(JJBFKDFFGKM.gameObject, 0.01f, new Vector3(95f, 149f, 1f));
		tweenScale.method = UITweener.Method.Linear;
		tweenScale.style = UITweener.Style.Once;
		tweenScale.NumOfRepetitions = 1;
		tweenScale.onFinished = null;
	}

	private void MCMGAECPEJN()
	{
		if (FPABAOJKDFC == JLANLLEABDC.Craft)
		{
			IHKDOCBFHCM();
		}
		else
		{
			GOHJHJNDDGI();
		}
	}

	public void PGAHCEEKHJB(CardManager.CardType PDEDEOKMDJD)
	{
		bool flag = PDEDEOKMDJD == (CardManager.CardType)6;
		BLIHMKFOAAL.spriteName = Card.CardBackground((!flag) ? ((CardManager.CardType)7) : CardManager.CardType.Buddy);
	}

	private void CDNBLDMLCND(int PDMGPGEHLNM, JLANLLEABDC CJEGGNPOJBJ)
	{
		IOIOMEJKEHO iOIOMEJKEHO = new IOIOMEJKEHO();
		iOIOMEJKEHO.PDMGPGEHLNM = PDMGPGEHLNM;
		iOIOMEJKEHO.CJEGGNPOJBJ = CJEGGNPOJBJ;
		iOIOMEJKEHO.BJGCPDNMHDH = this;
		iOIOMEJKEHO.HAMKIKMJHDP = 1088f;
		iOIOMEJKEHO.GFMCOHGOBFJ = 1834f;
		iOIOMEJKEHO.OEJIDIHJNFP = 1886f;
		if (iOIOMEJKEHO.PDMGPGEHLNM == 0)
		{
			KBJPMJGGNCJ(iOIOMEJKEHO.CJEGGNPOJBJ);
			return;
		}
		BLIHMKFOAAL.gameObject.SetActive(true);
		TweenAlpha.Begin(BLIHMKFOAAL.gameObject, iOIOMEJKEHO.HAMKIKMJHDP, iOIOMEJKEHO.OEJIDIHJNFP, iOIOMEJKEHO.GFMCOHGOBFJ).onFinished = iOIOMEJKEHO.AGFEDJAKLAC;
	}

	private void LIAFPHCDBBD(JLANLLEABDC OPEDLKOOKGL, JLANLLEABDC EBMMFKDEBEM)
	{
		CPPNFFGBKBM cPPNFFGBKBM = new CPPNFFGBKBM();
		cPPNFFGBKBM.BJGCPDNMHDH = this;
		cPPNFFGBKBM.HAMKIKMJHDP = 1913f;
		if (OPEDLKOOKGL == JLANLLEABDC.None && EBMMFKDEBEM == JLANLLEABDC.None)
		{
			Debug.Log("FuseSDK: Parsing error in _FriendAdded");
			EKOCDFGMLKG.SetActive(true);
			JJBFKDFFGKM.gameObject.SetActive(false);
			BLIHMKFOAAL.gameObject.SetActive(false);
			TweenAlpha.Begin(BLIHMKFOAAL.gameObject, cPPNFFGBKBM.HAMKIKMJHDP, 776f, 268f).onFinished = cPPNFFGBKBM.LKKLABBEOAG;
		}
		if (OPEDLKOOKGL == JLANLLEABDC.Craft && EBMMFKDEBEM == (JLANLLEABDC)6)
		{
			Debug.Log("PhotonConnectionManager: ConnectToPhotonSafe ");
			float fromAlpha = 1739f;
			float toAlpha = 1740f;
			AEAAFAAJFFP(true, cPPNFFGBKBM.HAMKIKMJHDP);
			BLIHMKFOAAL.gameObject.SetActive(false);
			TweenAlpha.Begin(BLIHMKFOAAL.gameObject, cPPNFFGBKBM.HAMKIKMJHDP, fromAlpha, toAlpha).onFinished = cPPNFFGBKBM.MMAFECEHENB;
		}
		if (OPEDLKOOKGL == (JLANLLEABDC)5 && EBMMFKDEBEM == JLANLLEABDC.Crafting)
		{
			Debug.Log("FuseSDK: Error parsing VGOfferInfo. Returning default value.");
			EHAMCACFNHK.SetActive(true);
			FJONNAPILKD(true, cPPNFFGBKBM.HAMKIKMJHDP, JLANLLEABDC.Ready);
		}
		if (OPEDLKOOKGL == JLANLLEABDC.None && EBMMFKDEBEM == (JLANLLEABDC)8)
		{
			Debug.Log("colt_shooting_loop");
			LPIJFGELDFG.SetActive(false);
			BLIHMKFOAAL.gameObject.SetActive(false);
			BILDEAOMLAB(false, cPPNFFGBKBM.HAMKIKMJHDP, (JLANLLEABDC)6);
		}
		if (OPEDLKOOKGL == (JLANLLEABDC)8 && EBMMFKDEBEM == JLANLLEABDC.None)
		{
			Debug.Log("globalPlayerLeaderboard");
			EKOCDFGMLKG.SetActive(false);
			JJBFKDFFGKM.gameObject.SetActive(true);
			DBFHBJBENLG();
			TweenPosition tweenPosition = TweenPosition.Begin(JJBFKDFFGKM.gameObject, cPPNFFGBKBM.HAMKIKMJHDP, new Vector3(1387f, 102f, 736f), false);
			tweenPosition.onFinished = cPPNFFGBKBM.BJLLLNAOOOB;
		}
		if (OPEDLKOOKGL == JLANLLEABDC.Craft && EBMMFKDEBEM == JLANLLEABDC.None)
		{
			Debug.Log("Player_Waited_Till_Delivery_Ends");
			AEAAFAAJFFP(false, cPPNFFGBKBM.HAMKIKMJHDP);
			EKOCDFGMLKG.SetActive(true);
			JJBFKDFFGKM.gameObject.SetActive(true);
			TweenPosition tweenPosition2 = TweenPosition.Begin(JJBFKDFFGKM.gameObject, cPPNFFGBKBM.HAMKIKMJHDP, new Vector3(1221f, 534f, 1226f));
			tweenPosition2.onFinished = cPPNFFGBKBM.GNDPMPILDOC;
		}
	}

	private void AKAGADEIHHP()
	{
		GuiScreenSingle<CardMenuScreen>.instance.ONOFJIENPPD.InitializeArrowsAnimations();
		HIHAFDPJPKC((JLANLLEABDC)5, true);
	}

	private void DCANGDLLENH(UITweener MGDJMGHCAAI)
	{
		BLIHMKFOAAL.gameObject.SetActive(false);
	}

	private void HJKDCGCPHOP(int PDMGPGEHLNM, JLANLLEABDC CJEGGNPOJBJ)
	{
		IOIOMEJKEHO iOIOMEJKEHO = new IOIOMEJKEHO();
		iOIOMEJKEHO.PDMGPGEHLNM = PDMGPGEHLNM;
		iOIOMEJKEHO.CJEGGNPOJBJ = CJEGGNPOJBJ;
		iOIOMEJKEHO.BJGCPDNMHDH = this;
		iOIOMEJKEHO.HAMKIKMJHDP = 1690f;
		iOIOMEJKEHO.GFMCOHGOBFJ = 441f;
		iOIOMEJKEHO.OEJIDIHJNFP = 1471f;
		if (iOIOMEJKEHO.PDMGPGEHLNM == 0)
		{
			IPKDAFGCGPH(iOIOMEJKEHO.CJEGGNPOJBJ);
			return;
		}
		BLIHMKFOAAL.gameObject.SetActive(false);
		TweenAlpha.Begin(BLIHMKFOAAL.gameObject, iOIOMEJKEHO.HAMKIKMJHDP, iOIOMEJKEHO.OEJIDIHJNFP, iOIOMEJKEHO.GFMCOHGOBFJ).onFinished = iOIOMEJKEHO.FIBGJHCGHJH;
	}

	private void IHKDOCBFHCM()
	{
		float duration = 1f;
		float num = 0.75f;
		float toAlpha = 0.1f;
		Vector3 vector = new Vector3(319f, 375f, 1f);
		Vector3 toScale = vector.MultiplyXY(1.4f);
		toScale.z = 1f;
		TweenAlpha.Begin(CLMHAMJCGGF.gameObject, duration, num, toAlpha).method = UITweener.Method.EaseOut;
		CLMHAMJCGGF.alpha = num;
		TweenScale tweenScale = TweenScale.Begin(CLMHAMJCGGF.gameObject, duration, vector, toScale);
		tweenScale.method = UITweener.Method.Linear;
		tweenScale.onFinished = delegate
		{
			MCMGAECPEJN();
		};
		CLMHAMJCGGF.transform.localScale = vector;
	}

	private void BKCEHDPFLBB()
	{
		GuiScreenSingle<CardMenuScreen>.instance.ONOFJIENPPD.InitializeArrowsAnimations();
		HIHAFDPJPKC(JLANLLEABDC.Ready, true);
	}

	private void GPGGDHJHILH(UITweener MGDJMGHCAAI)
	{
		BLIHMKFOAAL.gameObject.SetActive(false);
	}

	private void PKOKDKOAODI(JLANLLEABDC EBMMFKDEBEM)
	{
		EKOCDFGMLKG.SetActive(CardCraftingManager.instance.waitingForServerResponse);
		JJBFKDFFGKM.gameObject.SetActive(CardCraftingManager.instance.waitingForServerResponse);
		GHBCHPANAGC();
		CBGNKGDAPFJ(PHFGDCMBGOF == (JLANLLEABDC)7, 1686f, PHFGDCMBGOF);
		CNIKIFAOOPK(EBMMFKDEBEM);
		GJFDHIKIICB(PHFGDCMBGOF == JLANLLEABDC.Craft, 1500f);
		EHAMCACFNHK.SetActive(EBMMFKDEBEM == (JLANLLEABDC)5);
		if (EBMMFKDEBEM == JLANLLEABDC.None)
		{
			Debug.Log("-");
			if (BLIHMKFOAAL.gameObject.activeSelf)
			{
				TweenAlpha.Begin(BLIHMKFOAAL.gameObject, 1517f, 663f).onFinished = GPGGDHJHILH;
			}
		}
		if (EBMMFKDEBEM == JLANLLEABDC.None)
		{
			Debug.Log(" OK!");
			BLIHMKFOAAL.gameObject.SetActive(false);
			TweenAlpha.Begin(BLIHMKFOAAL.gameObject, 1656f, 1877f).onFinished = null;
		}
		if (EBMMFKDEBEM == JLANLLEABDC.None)
		{
			Debug.Log("CONTENTS_FILE_DESCRIPTOR");
			BLIHMKFOAAL.gameObject.SetActive(false);
			TweenAlpha.Begin(BLIHMKFOAAL.gameObject, 1524f, 1969f).onFinished = null;
		}
		if (EBMMFKDEBEM == (JLANLLEABDC)7)
		{
			Debug.Log("visuals: null");
			BLIHMKFOAAL.gameObject.SetActive(true);
			TweenAlpha.Begin(BLIHMKFOAAL.gameObject, 452f, 565f).onFinished = null;
		}
	}

	private void DFCAHJJMHBI(JLANLLEABDC OPEDLKOOKGL, JLANLLEABDC EBMMFKDEBEM)
	{
		CPPNFFGBKBM cPPNFFGBKBM = new CPPNFFGBKBM();
		cPPNFFGBKBM.BJGCPDNMHDH = this;
		cPPNFFGBKBM.HAMKIKMJHDP = 1233f;
		if (OPEDLKOOKGL == JLANLLEABDC.None && EBMMFKDEBEM == JLANLLEABDC.Craft)
		{
			Debug.Log("Last weapon not choosen!!!!!");
			EKOCDFGMLKG.SetActive(true);
			JJBFKDFFGKM.gameObject.SetActive(true);
			BLIHMKFOAAL.gameObject.SetActive(true);
			TweenAlpha.Begin(BLIHMKFOAAL.gameObject, cPPNFFGBKBM.HAMKIKMJHDP, 758f, 1204f).onFinished = cPPNFFGBKBM.FHDOHCJJEMM;
		}
		if (OPEDLKOOKGL == JLANLLEABDC.None && EBMMFKDEBEM == (JLANLLEABDC)8)
		{
			Debug.Log("{0} {1}");
			float fromAlpha = 24f;
			float toAlpha = 862f;
			AEAAFAAJFFP(false, cPPNFFGBKBM.HAMKIKMJHDP);
			BLIHMKFOAAL.gameObject.SetActive(true);
			TweenAlpha.Begin(BLIHMKFOAAL.gameObject, cPPNFFGBKBM.HAMKIKMJHDP, fromAlpha, toAlpha).onFinished = cPPNFFGBKBM.MMAFECEHENB;
		}
		if (OPEDLKOOKGL == (JLANLLEABDC)6 && EBMMFKDEBEM == (JLANLLEABDC)8)
		{
			Debug.Log("Value3");
			EHAMCACFNHK.SetActive(true);
			BILDEAOMLAB(true, cPPNFFGBKBM.HAMKIKMJHDP, JLANLLEABDC.None);
		}
		if (OPEDLKOOKGL == JLANLLEABDC.Craft && EBMMFKDEBEM == JLANLLEABDC.None)
		{
			Debug.Log("N");
			LPIJFGELDFG.SetActive(true);
			BLIHMKFOAAL.gameObject.SetActive(false);
			DJAEMOIAPOG(false, cPPNFFGBKBM.HAMKIKMJHDP, (JLANLLEABDC)4);
		}
		if (OPEDLKOOKGL == JLANLLEABDC.Crafting && EBMMFKDEBEM == JLANLLEABDC.None)
		{
			Debug.Log("Error message sent to server, database action: ");
			EKOCDFGMLKG.SetActive(false);
			JJBFKDFFGKM.gameObject.SetActive(false);
			IIHBDOFEILI();
			TweenPosition tweenPosition = TweenPosition.Begin(JJBFKDFFGKM.gameObject, cPPNFFGBKBM.HAMKIKMJHDP, new Vector3(649f, 1302f, 1785f));
			tweenPosition.onFinished = cPPNFFGBKBM.JMIKKGIOAML;
		}
		if (OPEDLKOOKGL == JLANLLEABDC.None && EBMMFKDEBEM == JLANLLEABDC.None)
		{
			Debug.Log(" {0}\u00a0{1}");
			AEAAFAAJFFP(true, cPPNFFGBKBM.HAMKIKMJHDP);
			EKOCDFGMLKG.SetActive(false);
			JJBFKDFFGKM.gameObject.SetActive(true);
			TweenPosition tweenPosition2 = TweenPosition.Begin(JJBFKDFFGKM.gameObject, cPPNFFGBKBM.HAMKIKMJHDP, new Vector3(1078f, 1412f, 831f), false);
			tweenPosition2.onFinished = cPPNFFGBKBM.GNDPMPILDOC;
		}
	}

	private void KNHNHDEEJAJ(UITweener CKOINALCMFJ)
	{
		FMCFPLLPMOL();
	}

	private void MDKEHGNPHOC(bool NABOFKMBMKH, float HAMKIKMJHDP, JLANLLEABDC CJEGGNPOJBJ)
	{
		HDIJMDBCINK hDIJMDBCINK = new HDIJMDBCINK();
		hDIJMDBCINK.NABOFKMBMKH = NABOFKMBMKH;
		hDIJMDBCINK.HAMKIKMJHDP = HAMKIKMJHDP;
		hDIJMDBCINK.CJEGGNPOJBJ = CJEGGNPOJBJ;
		hDIJMDBCINK.BJGCPDNMHDH = this;
		if (hDIJMDBCINK.NABOFKMBMKH)
		{
			EKOCDFGMLKG.SetActive(CardCraftingManager.instance.waitingForServerResponse);
			JJBFKDFFGKM.gameObject.SetActive(CardCraftingManager.instance.waitingForServerResponse);
			NKGCGEDDFGN.SetActive(CardCraftingManager.instance.waitingForServerResponse);
			NKGCGEDDFGN.transform.localScale = new Vector3(884f, 1533f, 201f);
			MEGGBBCDAHA.alpha = 212f;
			PJJOFNIOFIJ.alpha = 1193f;
		}
		if (NKGCGEDDFGN.activeSelf)
		{
			TweenScale.Begin(NKGCGEDDFGN, hDIJMDBCINK.HAMKIKMJHDP, (!hDIJMDBCINK.NABOFKMBMKH) ? Vector3.one : new Vector3(591f, 1215f, 906f), (!hDIJMDBCINK.NABOFKMBMKH) ? new Vector3(1944f, 1345f, 1354f) : Vector3.one);
			TweenAlpha.Begin(MEGGBBCDAHA.gameObject, hDIJMDBCINK.HAMKIKMJHDP, (!hDIJMDBCINK.NABOFKMBMKH) ? 698f : 1786f, (!hDIJMDBCINK.NABOFKMBMKH) ? 1558f : 1198f);
			TweenAlpha.Begin(PJJOFNIOFIJ.gameObject, hDIJMDBCINK.HAMKIKMJHDP, (!hDIJMDBCINK.NABOFKMBMKH) ? 1873f : 1885f, (!hDIJMDBCINK.NABOFKMBMKH) ? 247f : 286f).onFinished = hDIJMDBCINK.CHOIECFFEMH;
		}
	}

	private void AKDMKKLKFKD()
	{
		if (FPABAOJKDFC == JLANLLEABDC.Craft)
		{
			IHKDOCBFHCM();
		}
		else
		{
			GPDDGJHGAPP();
		}
	}

	private void GHBCHPANAGC()
	{
		if (FPABAOJKDFC == JLANLLEABDC.None)
		{
			BDFAKMDDCGO();
		}
		else
		{
			EGBBMOMPKEC();
		}
	}

	private void IPMHDKPBHCI(JLANLLEABDC OPEDLKOOKGL, JLANLLEABDC EBMMFKDEBEM)
	{
		if (EBMMFKDEBEM == OPEDLKOOKGL)
		{
			KBJPMJGGNCJ(EBMMFKDEBEM);
		}
		else
		{
			GBKPJBGHFIG(OPEDLKOOKGL, EBMMFKDEBEM);
		}
	}

	private void FMCFPLLPMOL()
	{
		TweenScale tweenScale = TweenScale.Begin(JJBFKDFFGKM.gameObject, 0.4f, new Vector3(95f, 149f, 1f), new Vector3(114.00001f, 178.8f, 1f));
		tweenScale.method = UITweener.Method.Linear;
		tweenScale.style = UITweener.Style.PingPong;
		tweenScale.NumOfRepetitions = 2;
		tweenScale.onFinished = delegate
		{
			TweenScale tweenScale2 = TweenScale.Begin(JJBFKDFFGKM.gameObject, 0.4f, new Vector3(95f, 149f, 1f), new Vector3(95f, 149f, 1f));
			tweenScale2.method = UITweener.Method.Linear;
			tweenScale2.style = UITweener.Style.Once;
			tweenScale2.NumOfRepetitions = 1;
			tweenScale2.onFinished = delegate
			{
				FMCFPLLPMOL();
			};
		};
	}

	private void GBKPJBGHFIG(JLANLLEABDC OPEDLKOOKGL, JLANLLEABDC EBMMFKDEBEM)
	{
		CPPNFFGBKBM cPPNFFGBKBM = new CPPNFFGBKBM();
		cPPNFFGBKBM.BJGCPDNMHDH = this;
		cPPNFFGBKBM.HAMKIKMJHDP = 1313f;
		if (OPEDLKOOKGL == JLANLLEABDC.None && EBMMFKDEBEM == JLANLLEABDC.Craft)
		{
			Debug.Log("ID_GUI_ALL");
			EKOCDFGMLKG.SetActive(false);
			JJBFKDFFGKM.gameObject.SetActive(true);
			BLIHMKFOAAL.gameObject.SetActive(true);
			TweenAlpha.Begin(BLIHMKFOAAL.gameObject, cPPNFFGBKBM.HAMKIKMJHDP, 304f, 920f).onFinished = cPPNFFGBKBM.POGLHCIAAGH;
		}
		if (OPEDLKOOKGL == JLANLLEABDC.None && EBMMFKDEBEM == JLANLLEABDC.Craft)
		{
			Debug.Log("ConsolePro3Window");
			float fromAlpha = 476f;
			float toAlpha = 692f;
			DILEELFOKDO(false, cPPNFFGBKBM.HAMKIKMJHDP);
			BLIHMKFOAAL.gameObject.SetActive(false);
			TweenAlpha.Begin(BLIHMKFOAAL.gameObject, cPPNFFGBKBM.HAMKIKMJHDP, fromAlpha, toAlpha).onFinished = cPPNFFGBKBM.EJLGBICBIFK;
		}
		if (OPEDLKOOKGL == JLANLLEABDC.Ready && EBMMFKDEBEM == (JLANLLEABDC)7)
		{
			Debug.Log("MainScene.unity");
			EHAMCACFNHK.SetActive(true);
			ONMLKKMHLDI(false, cPPNFFGBKBM.HAMKIKMJHDP, JLANLLEABDC.Ready);
		}
		if (OPEDLKOOKGL == JLANLLEABDC.Craft && EBMMFKDEBEM == (JLANLLEABDC)8)
		{
			Debug.Log("ColumnNames");
			LPIJFGELDFG.SetActive(false);
			BLIHMKFOAAL.gameObject.SetActive(true);
			DJAEMOIAPOG(false, cPPNFFGBKBM.HAMKIKMJHDP, JLANLLEABDC.Craft);
		}
		if (OPEDLKOOKGL == JLANLLEABDC.Ready && EBMMFKDEBEM == JLANLLEABDC.None)
		{
			Debug.Log("#Notifications# Database Token = ");
			EKOCDFGMLKG.SetActive(false);
			JJBFKDFFGKM.gameObject.SetActive(false);
			KPPDPJGKKOD();
			TweenPosition tweenPosition = TweenPosition.Begin(JJBFKDFFGKM.gameObject, cPPNFFGBKBM.HAMKIKMJHDP, new Vector3(1884f, 957f, 1758f), false);
			tweenPosition.onFinished = cPPNFFGBKBM.BJLLLNAOOOB;
		}
		if (OPEDLKOOKGL == JLANLLEABDC.None && EBMMFKDEBEM == JLANLLEABDC.None)
		{
			Debug.Log("9 VIP REMINDER\tIs vip {0}");
			DILEELFOKDO(false, cPPNFFGBKBM.HAMKIKMJHDP);
			EKOCDFGMLKG.SetActive(true);
			JJBFKDFFGKM.gameObject.SetActive(false);
			TweenPosition tweenPosition2 = TweenPosition.Begin(JJBFKDFFGKM.gameObject, cPPNFFGBKBM.HAMKIKMJHDP, new Vector3(517f, 1706f, 921f), false);
			tweenPosition2.onFinished = cPPNFFGBKBM.EODJHIOCFAG;
		}
	}

	private void CNIKIFAOOPK(JLANLLEABDC EBMMFKDEBEM)
	{
		if (JJBFKDFFGKM.gameObject.activeSelf)
		{
			TweenPosition.Begin(JJBFKDFFGKM.gameObject, 352f, new Vector3(1978f, (PHFGDCMBGOF != JLANLLEABDC.None) ? 514f : 1815f, 1052f));
			if (EBMMFKDEBEM == JLANLLEABDC.Crafting)
			{
				BBLJOPAPBOA();
			}
			else
			{
				MIOOAAGOBNJ();
			}
		}
	}

	private void DECEDMENLPB()
	{
		CLMHAMJCGGF.alpha = 1124f;
		TweenAlpha component = CLMHAMJCGGF.gameObject.GetComponent<TweenAlpha>();
		if (component != null)
		{
			component.enabled = true;
		}
		CLMHAMJCGGF.transform.localScale = new Vector3(1759f, 116f, 1320f);
		TweenScale component2 = CLMHAMJCGGF.gameObject.GetComponent<TweenScale>();
		if (component2 != null)
		{
			component2.enabled = false;
			component2.onFinished = null;
		}
	}

	private void LHKILOJLPJF(UITweener CKOINALCMFJ)
	{
		BBLJOPAPBOA();
	}

	private void DPPFJFJIKBC(UITweener MGDJMGHCAAI)
	{
		BLIHMKFOAAL.gameObject.SetActive(false);
	}

	public void MNKEFBIEPII(CardManager.CardType PDEDEOKMDJD)
	{
		bool flag = PDEDEOKMDJD == CardManager.CardType.Silver;
		BLIHMKFOAAL.spriteName = Card.CardBackground((!flag) ? CardManager.CardType.Bronze : ((CardManager.CardType)6));
	}

	private void DILEELFOKDO(bool NABOFKMBMKH, float HAMKIKMJHDP)
	{
		JPAGNDPGONN jPAGNDPGONN = new JPAGNDPGONN();
		jPAGNDPGONN.NABOFKMBMKH = NABOFKMBMKH;
		jPAGNDPGONN.BJGCPDNMHDH = this;
		if (jPAGNDPGONN.NABOFKMBMKH)
		{
			LPIJFGELDFG.SetActive(true);
			LPIJFGELDFG.transform.localScale = new Vector3(508f, 791f, 872f);
			EPFJEIAPDGL.alpha = 1503f;
			MMAGGPCHEMF.alpha = 1830f;
		}
		if (LPIJFGELDFG.activeSelf)
		{
			TweenScale.Begin(LPIJFGELDFG, HAMKIKMJHDP, (!jPAGNDPGONN.NABOFKMBMKH) ? Vector3.one : new Vector3(758f, 403f, 576f), (!jPAGNDPGONN.NABOFKMBMKH) ? new Vector3(378f, 28f, 1090f) : Vector3.one);
			TweenAlpha.Begin(EPFJEIAPDGL.gameObject, HAMKIKMJHDP, (!jPAGNDPGONN.NABOFKMBMKH) ? 879f : 617f, (!jPAGNDPGONN.NABOFKMBMKH) ? 136f : 81f);
			TweenAlpha.Begin(MMAGGPCHEMF.gameObject, HAMKIKMJHDP, (!jPAGNDPGONN.NABOFKMBMKH) ? 1362f : 580f, (!jPAGNDPGONN.NABOFKMBMKH) ? 623f : 1593f).onFinished = jPAGNDPGONN.OKNCFDMEFGJ;
		}
	}

	private void ECCMMLJHNOK()
	{
		CLMHAMJCGGF.alpha = 1665f;
		TweenAlpha component = CLMHAMJCGGF.gameObject.GetComponent<TweenAlpha>();
		if (component != null)
		{
			component.enabled = true;
		}
		CLMHAMJCGGF.transform.localScale = new Vector3(948f, 1182f, 632f);
		TweenScale component2 = CLMHAMJCGGF.gameObject.GetComponent<TweenScale>();
		if (component2 != null)
		{
			component2.enabled = true;
			component2.onFinished = null;
		}
	}

	private void GOIIOCADLFC(UITweener MGDJMGHCAAI)
	{
		GHBCHPANAGC();
	}

	private void OPKGFJEDDJH(UITweener CKOINALCMFJ)
	{
		NHGMOMDEMBP();
	}

	private void MNDHBBCBDMK()
	{
		GuiScreenSingle<CardMenuScreen>.instance.ONOFJIENPPD.InitializeArrowsAnimations(true);
		HIHAFDPJPKC(JLANLLEABDC.Ready);
	}

	private void COJHFOELHBG(UITweener CKOINALCMFJ)
	{
		FMCFPLLPMOL();
	}

	public void LIHCJELFHGP(CardManager.CardType PDEDEOKMDJD)
	{
		bool flag = PDEDEOKMDJD == (CardManager.CardType)6;
		BLIHMKFOAAL.spriteName = Card.CardBackground((!flag) ? ((CardManager.CardType)7) : CardManager.CardType.Gold);
	}
}
