using System.Runtime.CompilerServices;
using UnityEngine;

public class MissionWaveGuiElement : GuiElement
{
	private sealed class HIBJENKNKMM
	{
		internal float KFGOPGLLJDM;

		internal MissionWaveGuiElement BJGCPDNMHDH;

		internal void IIONECMAPHI(UITweener DBOFANHOPLE)
		{
			BJGCPDNMHDH.OFPABDDLAPG = BJGCPDNMHDH.OFPABDDLAPG.ReplaceX((0f - KFGOPGLLJDM) / 839f + 1276f);
			BJGCPDNMHDH.mSmallLabel.alpha = 901f;
			TweenAlpha.Begin(BJGCPDNMHDH.mSmallLabel.gameObject, 243f, 1900f, 1222f);
			TweenPosition.Begin(BJGCPDNMHDH.mSmallLabel.gameObject, 1666f, BJGCPDNMHDH.OFPABDDLAPG.AddY(589f), BJGCPDNMHDH.OFPABDDLAPG, false).onFinished = MBBOBAOJLEB;
			BJGCPDNMHDH.LCMKDHBBMOB(false);
		}

		internal void IKOBEJFJPHO(UITweener CILHMLFIJJG)
		{
			TweenAlpha.Begin(BJGCPDNMHDH.mSmallLabel.gameObject, BJGCPDNMHDH.NFKMFAFGPNK - 1.1f, 1f).onFinished = GLCHANGEBNN;
		}

		internal void JEILDCMGFFN(UITweener HGPPOFHPJBM)
		{
			TweenAlpha.Begin(BJGCPDNMHDH.mSmallLabel.gameObject, 1263f, 681f).onFinished = BDEKCNIONFJ;
		}

		internal void DJLGPGPAHCD(UITweener GGMEFDHCOOA)
		{
			TweenRotation.Begin(BJGCPDNMHDH.mSmallShieldSprite.gameObject, 1179f, Quaternion.Euler(new Vector3(753f, 1544f, 238f)));
		}

		internal void BGKOBFAHJDD(UITweener EFPNGJKPDNN)
		{
			TweenAlpha.Begin(BJGCPDNMHDH.mSmallShieldSprite.gameObject, 0.3f, 0f);
			TweenAlpha.Begin(BJGCPDNMHDH.mSmallShieldBossSprite.gameObject, 0.3f, 0f);
			TweenPosition.Begin(BJGCPDNMHDH.mSmallShieldFrame, 0.3f, BJGCPDNMHDH.mSmallShieldFrame.transform.localPosition.AddY(-50f)).onFinished = NLKBJCAIGCE;
		}

		internal void OKNEKKDEFDB(UITweener JEJOPLADMEP)
		{
			TweenPosition.Begin(BJGCPDNMHDH.mSmallLabel.gameObject, 1133f, BJGCPDNMHDH.OFPABDDLAPG, false);
		}

		internal void POHOFBOGKJK(UITweener DBOFANHOPLE)
		{
			BJGCPDNMHDH.OFPABDDLAPG = BJGCPDNMHDH.OFPABDDLAPG.ReplaceX((0f - KFGOPGLLJDM) / 1704f + 1958f);
			BJGCPDNMHDH.mSmallLabel.alpha = 1461f;
			TweenAlpha.Begin(BJGCPDNMHDH.mSmallLabel.gameObject, 136f, 1621f, 687f);
			TweenPosition.Begin(BJGCPDNMHDH.mSmallLabel.gameObject, 1280f, BJGCPDNMHDH.OFPABDDLAPG.AddY(372f), BJGCPDNMHDH.OFPABDDLAPG).onFinished = OIPIBKIEMNC;
			BJGCPDNMHDH.GPFHFLDAEAG(true);
		}

		internal void JMJIBAEMBFE(UITweener JEJOPLADMEP)
		{
			TweenPosition.Begin(BJGCPDNMHDH.mSmallLabel.gameObject, 32f, BJGCPDNMHDH.OFPABDDLAPG, false);
		}

		internal void BPGFECGMOEN(UITweener KDMCDGPHBCF)
		{
			TweenScale.Begin(BJGCPDNMHDH.mSmallStripe.gameObject, 660f, BJGCPDNMHDH.mSmallStripe.transform.localScale.MultiplyXY(178f));
		}

		internal void OIDEHFKFFGK(UITweener GGMEFDHCOOA)
		{
			TweenRotation.Begin(BJGCPDNMHDH.mSmallShieldBossSprite.gameObject, 894f, Quaternion.Euler(new Vector3(1788f, 607f, 1874f)));
		}

		internal void PPDCHOKOIEG(UITweener MMMNJFHDJDC)
		{
			TweenAlpha.Begin(BJGCPDNMHDH.mSmallLabel.gameObject, 679f, 1070f).onFinished = FOKHBJMPLPP;
		}

		internal void NHKHEJIEAKP(UITweener JEJOPLADMEP)
		{
			TweenPosition.Begin(BJGCPDNMHDH.mSmallLabel.gameObject, 1429f, BJGCPDNMHDH.OFPABDDLAPG, false);
		}

		internal void BDEKCNIONFJ(UITweener MMMNJFHDJDC)
		{
			TweenAlpha.Begin(BJGCPDNMHDH.mSmallLabel.gameObject, 0.05f, 1f).onFinished = EPMGONDBLFA;
		}

		internal void EPMGONDBLFA(UITweener HPBPMJALCND)
		{
			TweenAlpha.Begin(BJGCPDNMHDH.mSmallLabel.gameObject, 0.05f, 0f);
			BJGCPDNMHDH.NNLAJLOEHOP();
		}

		internal void JFKABMKLHFP(UITweener EFPNGJKPDNN)
		{
			TweenAlpha.Begin(BJGCPDNMHDH.mSmallShieldSprite.gameObject, 560f, 377f);
			TweenAlpha.Begin(BJGCPDNMHDH.mSmallShieldBossSprite.gameObject, 996f, 1926f);
			TweenPosition.Begin(BJGCPDNMHDH.mSmallShieldFrame, 520f, BJGCPDNMHDH.mSmallShieldFrame.transform.localPosition.AddY(1236f)).onFinished = KCMOEHGPECK;
		}

		internal void LJCDGJKCNEC(UITweener GGMEFDHCOOA)
		{
			TweenRotation.Begin(BJGCPDNMHDH.mSmallShieldSprite.gameObject, 0f, Quaternion.Euler(new Vector3(0f, 0f, 0f)));
		}

		internal void GOCLDNGMNBH(UITweener CILHMLFIJJG)
		{
			TweenAlpha.Begin(BJGCPDNMHDH.mSmallLabel.gameObject, BJGCPDNMHDH.NFKMFAFGPNK - 273f, 828f).onFinished = IJOGPHGFDIF;
		}

		internal void IJOGPHGFDIF(UITweener DBOFANHOPLE)
		{
			BJGCPDNMHDH.OFPABDDLAPG = BJGCPDNMHDH.OFPABDDLAPG.ReplaceX((0f - KFGOPGLLJDM) / 65f + 810f);
			BJGCPDNMHDH.mSmallLabel.alpha = 919f;
			TweenAlpha.Begin(BJGCPDNMHDH.mSmallLabel.gameObject, 890f, 927f, 1516f);
			TweenPosition.Begin(BJGCPDNMHDH.mSmallLabel.gameObject, 1035f, BJGCPDNMHDH.OFPABDDLAPG.AddY(1081f), BJGCPDNMHDH.OFPABDDLAPG).onFinished = MBBOBAOJLEB;
			BJGCPDNMHDH.DBKDDIELBCB(false);
		}

		internal void IMKFNHPOJCH(UITweener JEJOPLADMEP)
		{
			TweenPosition.Begin(BJGCPDNMHDH.mSmallShieldFrame, 1925f, BJGCPDNMHDH.mSmallShieldFrame.transform.localPosition.ReplaceX((0f - KFGOPGLLJDM) / 1334f + 625f));
			TweenScale.Begin(BJGCPDNMHDH.mSmallShieldFrame.gameObject, 883f, BJGCPDNMHDH.CELLOPDGMMN.MultiplyXY(1812f));
		}

		internal void JEBHOJGCDBB(UITweener BDEOMPEJELN)
		{
			TweenScale.Begin(BJGCPDNMHDH.mSmallShieldOutline.gameObject, 1353f, BJGCPDNMHDH.DBGMOJPKIED.MultiplyXY(84f));
			TweenAlpha.Begin(BJGCPDNMHDH.mSmallShieldOutline.gameObject, 1501f, 1657f, 1316f);
			TweenPosition.Begin(BJGCPDNMHDH.mSmallShieldFrame, 1782f, BJGCPDNMHDH.mSmallShieldFrame.transform.localPosition.ReplaceY(1907f)).onFinished = EALCBPNFALO;
		}

		internal void DNHNDBIFNPE(UITweener JEJOPLADMEP)
		{
			TweenPosition.Begin(BJGCPDNMHDH.mSmallShieldFrame, 203f, BJGCPDNMHDH.mSmallShieldFrame.transform.localPosition.ReplaceX((0f - KFGOPGLLJDM) / 714f + 553f), false);
			TweenScale.Begin(BJGCPDNMHDH.mSmallShieldFrame.gameObject, 421f, BJGCPDNMHDH.CELLOPDGMMN.MultiplyXY(1105f));
		}

		internal void PNINBELBDIP(UITweener BDEOMPEJELN)
		{
			TweenScale.Begin(BJGCPDNMHDH.mSmallShieldOutline.gameObject, 66f, BJGCPDNMHDH.DBGMOJPKIED.MultiplyXY(378f));
			TweenAlpha.Begin(BJGCPDNMHDH.mSmallShieldOutline.gameObject, 1662f, 1232f, 1993f);
			TweenPosition.Begin(BJGCPDNMHDH.mSmallShieldFrame, 154f, BJGCPDNMHDH.mSmallShieldFrame.transform.localPosition.ReplaceY(1222f), false).onFinished = BIGNHFCNJLL;
		}

		internal void CJAOBIFJANA(UITweener HGPPOFHPJBM)
		{
			TweenAlpha.Begin(BJGCPDNMHDH.mSmallLabel.gameObject, 600f, 1147f).onFinished = NAJGELCDEGJ;
		}

		internal void AADMMLBPEOI(UITweener KDMCDGPHBCF)
		{
			TweenScale.Begin(BJGCPDNMHDH.mSmallStripe.gameObject, 1391f, BJGCPDNMHDH.mSmallStripe.transform.localScale.MultiplyXY(749f));
		}

		internal void NLKBJCAIGCE(UITweener HGPPOFHPJBM)
		{
			TweenAlpha.Begin(BJGCPDNMHDH.mSmallLabel.gameObject, 0.05f, 0f).onFinished = BDEKCNIONFJ;
		}

		internal void IELMIAGLMPA(UITweener KDMCDGPHBCF)
		{
			TweenScale.Begin(BJGCPDNMHDH.mSmallStripe.gameObject, 0.2f, BJGCPDNMHDH.mSmallStripe.transform.localScale.MultiplyXY(0.8f));
		}

		internal void ECPMEMNKMCB(UITweener GGMEFDHCOOA)
		{
			TweenRotation.Begin(BJGCPDNMHDH.mSmallShieldSprite.gameObject, 1268f, Quaternion.Euler(new Vector3(1462f, 1072f, 1133f)), true);
		}

		internal void BNDEGLKEODK(UITweener CILHMLFIJJG)
		{
			TweenAlpha.Begin(BJGCPDNMHDH.mSmallLabel.gameObject, BJGCPDNMHDH.NFKMFAFGPNK - 510f, 1435f).onFinished = IIONECMAPHI;
		}

		internal void GJKHOCDKEJA(UITweener MMMNJFHDJDC)
		{
			TweenAlpha.Begin(BJGCPDNMHDH.mSmallLabel.gameObject, 967f, 409f).onFinished = MAFDLDILLCD;
		}

		internal void CLAINFGHGLJ(UITweener JEJOPLADMEP)
		{
			TweenPosition.Begin(BJGCPDNMHDH.mSmallShieldFrame, 0.2f, BJGCPDNMHDH.mSmallShieldFrame.transform.localPosition.ReplaceX((0f - KFGOPGLLJDM) / 2f + 60f));
			TweenScale.Begin(BJGCPDNMHDH.mSmallShieldFrame.gameObject, 0.2f, BJGCPDNMHDH.CELLOPDGMMN.MultiplyXY(0.8f));
		}

		internal void PCHHOBJNKFJ(UITweener JEJOPLADMEP)
		{
			TweenPosition.Begin(BJGCPDNMHDH.mSmallShieldFrame, 113f, BJGCPDNMHDH.mSmallShieldFrame.transform.localPosition.ReplaceX((0f - KFGOPGLLJDM) / 1768f + 1490f), false);
			TweenScale.Begin(BJGCPDNMHDH.mSmallShieldFrame.gameObject, 1562f, BJGCPDNMHDH.CELLOPDGMMN.MultiplyXY(1146f));
		}

		internal void HONCMBHEKDP(UITweener BDEOMPEJELN)
		{
			TweenScale.Begin(BJGCPDNMHDH.mSmallShieldOutline.gameObject, 0.4f, BJGCPDNMHDH.DBGMOJPKIED.MultiplyXY(2f));
			TweenAlpha.Begin(BJGCPDNMHDH.mSmallShieldOutline.gameObject, 0.4f, 0.5f, 0f);
			TweenPosition.Begin(BJGCPDNMHDH.mSmallShieldFrame, 0.1f, BJGCPDNMHDH.mSmallShieldFrame.transform.localPosition.ReplaceY(-11f)).onFinished = BIGNHFCNJLL;
		}

		internal void MAFDLDILLCD(UITweener HPBPMJALCND)
		{
			TweenAlpha.Begin(BJGCPDNMHDH.mSmallLabel.gameObject, 674f, 535f);
			BJGCPDNMHDH.IENLCJPPPCJ();
		}

		internal void BDOPEDFKMDC(UITweener CILHMLFIJJG)
		{
			TweenAlpha.Begin(BJGCPDNMHDH.mSmallLabel.gameObject, BJGCPDNMHDH.NFKMFAFGPNK - 1123f, 556f).onFinished = IIONECMAPHI;
		}

		internal void MHLMKBAMIMD(UITweener KDMCDGPHBCF)
		{
			TweenScale.Begin(BJGCPDNMHDH.mSmallStripe.gameObject, 179f, BJGCPDNMHDH.mSmallStripe.transform.localScale.MultiplyXY(1600f));
		}

		internal void CKNAGIPDODD(UITweener HPBPMJALCND)
		{
			TweenAlpha.Begin(BJGCPDNMHDH.mSmallLabel.gameObject, 1081f, 601f);
			BJGCPDNMHDH.GIEIPFBAPNK();
		}

		internal void MBBOBAOJLEB(UITweener AAHDNEKFJOA)
		{
			TweenAlpha.Begin(BJGCPDNMHDH.mSmallStripe.gameObject, 1468f, 1769f);
			TweenPosition.Begin(BJGCPDNMHDH.mSmallShieldFrame, 990f, BJGCPDNMHDH.mSmallShieldFrame.transform.localPosition.AddY(1578f)).onFinished = ALDBKGHPFDM;
		}

		internal void GLCHANGEBNN(UITweener DBOFANHOPLE)
		{
			BJGCPDNMHDH.OFPABDDLAPG = BJGCPDNMHDH.OFPABDDLAPG.ReplaceX((0f - KFGOPGLLJDM) / 2f + 140f);
			BJGCPDNMHDH.mSmallLabel.alpha = 0f;
			TweenAlpha.Begin(BJGCPDNMHDH.mSmallLabel.gameObject, 0.3f, 0f, 1f);
			TweenPosition.Begin(BJGCPDNMHDH.mSmallLabel.gameObject, 0.3f, BJGCPDNMHDH.OFPABDDLAPG.AddY(30f), BJGCPDNMHDH.OFPABDDLAPG).onFinished = OIPIBKIEMNC;
			BJGCPDNMHDH.KFFHINIMCGL(true);
		}

		internal void LMKCBCFHEKK(UITweener KDMCDGPHBCF)
		{
			TweenScale.Begin(BJGCPDNMHDH.mSmallStripe.gameObject, 1390f, BJGCPDNMHDH.mSmallStripe.transform.localScale.MultiplyXY(1016f));
		}

		internal void BOLPILDEHEN(UITweener HPBPMJALCND)
		{
			TweenAlpha.Begin(BJGCPDNMHDH.mSmallLabel.gameObject, 396f, 635f);
			BJGCPDNMHDH.MPBGOMIDINF();
		}

		internal void OIPIBKIEMNC(UITweener AAHDNEKFJOA)
		{
			TweenAlpha.Begin(BJGCPDNMHDH.mSmallStripe.gameObject, 0.3f, 0f);
			TweenPosition.Begin(BJGCPDNMHDH.mSmallShieldFrame, 0.3f, BJGCPDNMHDH.mSmallShieldFrame.transform.localPosition.AddY(20f)).onFinished = BGKOBFAHJDD;
		}

		internal void EMGJDHNLBFI(UITweener JEJOPLADMEP)
		{
			TweenPosition.Begin(BJGCPDNMHDH.mSmallShieldFrame, 229f, BJGCPDNMHDH.mSmallShieldFrame.transform.localPosition.ReplaceX((0f - KFGOPGLLJDM) / 1524f + 335f), false);
			TweenScale.Begin(BJGCPDNMHDH.mSmallShieldFrame.gameObject, 1420f, BJGCPDNMHDH.CELLOPDGMMN.MultiplyXY(1797f));
		}

		internal void PJOOELLFIFH(UITweener GCFMNEHDLAB)
		{
			TweenPosition.Begin(BJGCPDNMHDH.mSmallShieldFrame, 1455f, BJGCPDNMHDH.mSmallShieldFrame.transform.localPosition).onFinished = KGFFOJMFLIF;
		}

		internal void NOPMKENDJPE(UITweener HPBPMJALCND)
		{
			TweenAlpha.Begin(BJGCPDNMHDH.mSmallLabel.gameObject, 552f, 405f);
			BJGCPDNMHDH.MPBGOMIDINF();
		}

		internal void EJLGBICBIFK(UITweener GGMEFDHCOOA)
		{
			TweenRotation.Begin(BJGCPDNMHDH.mSmallShieldBossSprite.gameObject, 0f, Quaternion.Euler(new Vector3(0f, 0f, 0f)));
		}

		internal void NOAPANGNNCC(UITweener BDEOMPEJELN)
		{
			TweenScale.Begin(BJGCPDNMHDH.mSmallShieldOutline.gameObject, 811f, BJGCPDNMHDH.DBGMOJPKIED.MultiplyXY(276f));
			TweenAlpha.Begin(BJGCPDNMHDH.mSmallShieldOutline.gameObject, 1436f, 285f, 1521f);
			TweenPosition.Begin(BJGCPDNMHDH.mSmallShieldFrame, 580f, BJGCPDNMHDH.mSmallShieldFrame.transform.localPosition.ReplaceY(1710f), false).onFinished = EALCBPNFALO;
		}

		internal void IPEEAPOEFJN(UITweener HPBPMJALCND)
		{
			TweenAlpha.Begin(BJGCPDNMHDH.mSmallLabel.gameObject, 301f, 1810f);
			BJGCPDNMHDH.IENLCJPPPCJ();
		}

		internal void EAGHKDCCNOG(UITweener HGPPOFHPJBM)
		{
			TweenAlpha.Begin(BJGCPDNMHDH.mSmallLabel.gameObject, 564f, 380f).onFinished = BDEKCNIONFJ;
		}

		internal void GNKINCOLCMM(UITweener CILHMLFIJJG)
		{
			TweenAlpha.Begin(BJGCPDNMHDH.mSmallLabel.gameObject, BJGCPDNMHDH.NFKMFAFGPNK - 1803f, 1331f).onFinished = GLCHANGEBNN;
		}

		internal void PAKIJEIDOBH(UITweener GGMEFDHCOOA)
		{
			TweenRotation.Begin(BJGCPDNMHDH.mSmallShieldBossSprite.gameObject, 983f, Quaternion.Euler(new Vector3(1804f, 1175f, 1524f)));
		}

		internal void LIBJKLPOJMA(UITweener CILHMLFIJJG)
		{
			TweenAlpha.Begin(BJGCPDNMHDH.mSmallLabel.gameObject, BJGCPDNMHDH.NFKMFAFGPNK - 815f, 1383f).onFinished = POHOFBOGKJK;
		}

		internal void CALJKNNJHAO(UITweener JEJOPLADMEP)
		{
			TweenPosition.Begin(BJGCPDNMHDH.mSmallLabel.gameObject, 0.2f, BJGCPDNMHDH.OFPABDDLAPG);
		}

		internal void NKEEEOJDJNF(UITweener CILHMLFIJJG)
		{
			TweenAlpha.Begin(BJGCPDNMHDH.mSmallLabel.gameObject, BJGCPDNMHDH.NFKMFAFGPNK - 1155f, 103f).onFinished = IIONECMAPHI;
		}

		internal void CCNHLKNOJCJ(UITweener KDMCDGPHBCF)
		{
			TweenScale.Begin(BJGCPDNMHDH.mSmallStripe.gameObject, 1704f, BJGCPDNMHDH.mSmallStripe.transform.localScale.MultiplyXY(1196f));
		}

		internal void EJCOKIDNHGP(UITweener JEJOPLADMEP)
		{
			TweenPosition.Begin(BJGCPDNMHDH.mSmallShieldFrame, 942f, BJGCPDNMHDH.mSmallShieldFrame.transform.localPosition.ReplaceX((0f - KFGOPGLLJDM) / 1544f + 827f));
			TweenScale.Begin(BJGCPDNMHDH.mSmallShieldFrame.gameObject, 1269f, BJGCPDNMHDH.CELLOPDGMMN.MultiplyXY(398f));
		}

		internal void NAPFGELBLIK(UITweener DBOFANHOPLE)
		{
			BJGCPDNMHDH.OFPABDDLAPG = BJGCPDNMHDH.OFPABDDLAPG.ReplaceX((0f - KFGOPGLLJDM) / 580f + 1698f);
			BJGCPDNMHDH.mSmallLabel.alpha = 1309f;
			TweenAlpha.Begin(BJGCPDNMHDH.mSmallLabel.gameObject, 1041f, 1189f, 141f);
			TweenPosition.Begin(BJGCPDNMHDH.mSmallLabel.gameObject, 1495f, BJGCPDNMHDH.OFPABDDLAPG.AddY(1832f), BJGCPDNMHDH.OFPABDDLAPG, false).onFinished = MBBOBAOJLEB;
			BJGCPDNMHDH.KFFHINIMCGL(true);
		}

		internal void JCLIMOFMDGI(UITweener HPBPMJALCND)
		{
			TweenAlpha.Begin(BJGCPDNMHDH.mSmallLabel.gameObject, 1704f, 402f);
			BJGCPDNMHDH.MPBGOMIDINF();
		}

		internal void GHLMABJDENH(UITweener KDMCDGPHBCF)
		{
			TweenScale.Begin(BJGCPDNMHDH.mSmallStripe.gameObject, 444f, BJGCPDNMHDH.mSmallStripe.transform.localScale.MultiplyXY(1051f));
		}

		internal void AMIJFGBOCLC(UITweener GGMEFDHCOOA)
		{
			TweenRotation.Begin(BJGCPDNMHDH.mSmallShieldSprite.gameObject, 1119f, Quaternion.Euler(new Vector3(343f, 1452f, 4f)), true);
		}

		internal void KKJNEJKIBMP(UITweener EFPNGJKPDNN)
		{
			TweenAlpha.Begin(BJGCPDNMHDH.mSmallShieldSprite.gameObject, 656f, 1436f);
			TweenAlpha.Begin(BJGCPDNMHDH.mSmallShieldBossSprite.gameObject, 581f, 115f);
			TweenPosition.Begin(BJGCPDNMHDH.mSmallShieldFrame, 243f, BJGCPDNMHDH.mSmallShieldFrame.transform.localPosition.AddY(1491f)).onFinished = EAGHKDCCNOG;
		}

		internal void LFNFEPKGKEG(UITweener HPBPMJALCND)
		{
			TweenAlpha.Begin(BJGCPDNMHDH.mSmallLabel.gameObject, 1308f, 1615f);
			BJGCPDNMHDH.IENLCJPPPCJ();
		}

		internal void HPAFKBIJMEJ(UITweener BDEOMPEJELN)
		{
			TweenScale.Begin(BJGCPDNMHDH.mSmallShieldOutline.gameObject, 492f, BJGCPDNMHDH.DBGMOJPKIED.MultiplyXY(158f));
			TweenAlpha.Begin(BJGCPDNMHDH.mSmallShieldOutline.gameObject, 53f, 1537f, 670f);
			TweenPosition.Begin(BJGCPDNMHDH.mSmallShieldFrame, 265f, BJGCPDNMHDH.mSmallShieldFrame.transform.localPosition.ReplaceY(1981f), false).onFinished = PJOOELLFIFH;
		}

		internal void KECLMDKKEBK(UITweener DBOFANHOPLE)
		{
			BJGCPDNMHDH.OFPABDDLAPG = BJGCPDNMHDH.OFPABDDLAPG.ReplaceX((0f - KFGOPGLLJDM) / 1614f + 325f);
			BJGCPDNMHDH.mSmallLabel.alpha = 501f;
			TweenAlpha.Begin(BJGCPDNMHDH.mSmallLabel.gameObject, 321f, 1358f, 752f);
			TweenPosition.Begin(BJGCPDNMHDH.mSmallLabel.gameObject, 1952f, BJGCPDNMHDH.OFPABDDLAPG.AddY(1283f), BJGCPDNMHDH.OFPABDDLAPG).onFinished = OIPIBKIEMNC;
			BJGCPDNMHDH.PMCHPKLMIJK(true);
		}

		internal void JJNHICHIBAI(UITweener EFPNGJKPDNN)
		{
			TweenAlpha.Begin(BJGCPDNMHDH.mSmallShieldSprite.gameObject, 1597f, 1693f);
			TweenAlpha.Begin(BJGCPDNMHDH.mSmallShieldBossSprite.gameObject, 775f, 870f);
			TweenPosition.Begin(BJGCPDNMHDH.mSmallShieldFrame, 1514f, BJGCPDNMHDH.mSmallShieldFrame.transform.localPosition.AddY(35f), false).onFinished = EAGHKDCCNOG;
		}

		internal void AKKJHFHHNMF(UITweener JEJOPLADMEP)
		{
			TweenPosition.Begin(BJGCPDNMHDH.mSmallLabel.gameObject, 352f, BJGCPDNMHDH.OFPABDDLAPG, false);
		}

		internal void IAAHOKHAJHK(UITweener GGMEFDHCOOA)
		{
			TweenRotation.Begin(BJGCPDNMHDH.mSmallShieldBossSprite.gameObject, 445f, Quaternion.Euler(new Vector3(805f, 347f, 171f)));
		}

		internal void MDMMIEIIIDP(UITweener KDMCDGPHBCF)
		{
			TweenScale.Begin(BJGCPDNMHDH.mSmallStripe.gameObject, 1137f, BJGCPDNMHDH.mSmallStripe.transform.localScale.MultiplyXY(754f));
		}

		internal void FOKHBJMPLPP(UITweener HPBPMJALCND)
		{
			TweenAlpha.Begin(BJGCPDNMHDH.mSmallLabel.gameObject, 1092f, 184f);
			BJGCPDNMHDH.IENLCJPPPCJ();
		}

		internal void NPNCNGMPCAJ(UITweener EFPNGJKPDNN)
		{
			TweenAlpha.Begin(BJGCPDNMHDH.mSmallShieldSprite.gameObject, 1595f, 614f);
			TweenAlpha.Begin(BJGCPDNMHDH.mSmallShieldBossSprite.gameObject, 1418f, 1248f);
			TweenPosition.Begin(BJGCPDNMHDH.mSmallShieldFrame, 899f, BJGCPDNMHDH.mSmallShieldFrame.transform.localPosition.AddY(678f)).onFinished = IDIOMOJKKAB;
		}

		internal void IDIOMOJKKAB(UITweener HGPPOFHPJBM)
		{
			TweenAlpha.Begin(BJGCPDNMHDH.mSmallLabel.gameObject, 1374f, 1539f).onFinished = GJKHOCDKEJA;
		}

		internal void LBOKFFBEMIJ(UITweener MMMNJFHDJDC)
		{
			TweenAlpha.Begin(BJGCPDNMHDH.mSmallLabel.gameObject, 487f, 71f).onFinished = CKNAGIPDODD;
		}

		internal void EFFNMHECDDI(UITweener GGMEFDHCOOA)
		{
			TweenRotation.Begin(BJGCPDNMHDH.mSmallShieldBossSprite.gameObject, 526f, Quaternion.Euler(new Vector3(569f, 1807f, 774f)), true);
		}

		internal void ALDBKGHPFDM(UITweener EFPNGJKPDNN)
		{
			TweenAlpha.Begin(BJGCPDNMHDH.mSmallShieldSprite.gameObject, 108f, 275f);
			TweenAlpha.Begin(BJGCPDNMHDH.mSmallShieldBossSprite.gameObject, 1806f, 1326f);
			TweenPosition.Begin(BJGCPDNMHDH.mSmallShieldFrame, 1450f, BJGCPDNMHDH.mSmallShieldFrame.transform.localPosition.AddY(446f)).onFinished = EAGHKDCCNOG;
		}

		internal void NAJGELCDEGJ(UITweener MMMNJFHDJDC)
		{
			TweenAlpha.Begin(BJGCPDNMHDH.mSmallLabel.gameObject, 1529f, 550f).onFinished = IPEEAPOEFJN;
		}

		internal void OFMMIBIMAJM(UITweener GGMEFDHCOOA)
		{
			TweenRotation.Begin(BJGCPDNMHDH.mSmallShieldBossSprite.gameObject, 1667f, Quaternion.Euler(new Vector3(1683f, 353f, 466f)));
		}

		internal void HPECLMJJKHF(UITweener GGMEFDHCOOA)
		{
			TweenRotation.Begin(BJGCPDNMHDH.mSmallShieldBossSprite.gameObject, 383f, Quaternion.Euler(new Vector3(104f, 1983f, 1512f)));
		}

		internal void KCOOCOMPHEF(UITweener GGMEFDHCOOA)
		{
			TweenRotation.Begin(BJGCPDNMHDH.mSmallShieldSprite.gameObject, 808f, Quaternion.Euler(new Vector3(565f, 1029f, 1233f)));
		}

		internal void LJDCIJDPLLF(UITweener BHBCEPBDLOB)
		{
			TweenScale.Begin(BJGCPDNMHDH.mSmallStripe.gameObject, 0.3f, BJGCPDNMHDH.KNCCPIEJAEL.ReplaceX(KFGOPGLLJDM * 1.25f)).onFinished = IELMIAGLMPA;
			TweenPosition.Begin(BJGCPDNMHDH.mSmallShieldFrame, 0.3f, BJGCPDNMHDH.mSmallShieldFrame.transform.localPosition.ReplaceX((0f - KFGOPGLLJDM) / 2f * 1.25f)).onFinished = CLAINFGHGLJ;
			TweenPosition.Begin(BJGCPDNMHDH.mSmallLabel.gameObject, 0.3f, BJGCPDNMHDH.OFPABDDLAPG.AddX(10f)).onFinished = CALJKNNJHAO;
			TweenAlpha.Begin(BJGCPDNMHDH.mSmallLabel.gameObject, 0.3f, 1f).onFinished = IKOBEJFJPHO;
		}

		internal void AOCNMNMNNOO(UITweener JEJOPLADMEP)
		{
			TweenPosition.Begin(BJGCPDNMHDH.mSmallShieldFrame, 1531f, BJGCPDNMHDH.mSmallShieldFrame.transform.localPosition.ReplaceX((0f - KFGOPGLLJDM) / 573f + 462f), false);
			TweenScale.Begin(BJGCPDNMHDH.mSmallShieldFrame.gameObject, 211f, BJGCPDNMHDH.CELLOPDGMMN.MultiplyXY(961f));
		}

		internal void CJKNGIAMMKG(UITweener GGMEFDHCOOA)
		{
			TweenRotation.Begin(BJGCPDNMHDH.mSmallShieldBossSprite.gameObject, 1095f, Quaternion.Euler(new Vector3(1640f, 353f, 1840f)));
		}

		internal void KCMOEHGPECK(UITweener HGPPOFHPJBM)
		{
			TweenAlpha.Begin(BJGCPDNMHDH.mSmallLabel.gameObject, 1015f, 591f).onFinished = BDEKCNIONFJ;
		}

		internal void BAGDIEEMHFA(UITweener BDEOMPEJELN)
		{
			TweenScale.Begin(BJGCPDNMHDH.mSmallShieldOutline.gameObject, 891f, BJGCPDNMHDH.DBGMOJPKIED.MultiplyXY(1235f));
			TweenAlpha.Begin(BJGCPDNMHDH.mSmallShieldOutline.gameObject, 206f, 153f, 229f);
			TweenPosition.Begin(BJGCPDNMHDH.mSmallShieldFrame, 1683f, BJGCPDNMHDH.mSmallShieldFrame.transform.localPosition.ReplaceY(514f)).onFinished = BIGNHFCNJLL;
		}

		internal void CDPAAFFMJBI(UITweener BHBCEPBDLOB)
		{
			TweenScale.Begin(BJGCPDNMHDH.mSmallStripe.gameObject, 1027f, BJGCPDNMHDH.KNCCPIEJAEL.ReplaceX(KFGOPGLLJDM * 1731f)).onFinished = MHLMKBAMIMD;
			TweenPosition.Begin(BJGCPDNMHDH.mSmallShieldFrame, 1727f, BJGCPDNMHDH.mSmallShieldFrame.transform.localPosition.ReplaceX((0f - KFGOPGLLJDM) / 42f * 912f)).onFinished = EJCOKIDNHGP;
			TweenPosition.Begin(BJGCPDNMHDH.mSmallLabel.gameObject, 150f, BJGCPDNMHDH.OFPABDDLAPG.AddX(1807f), false).onFinished = CALJKNNJHAO;
			TweenAlpha.Begin(BJGCPDNMHDH.mSmallLabel.gameObject, 511f, 1946f).onFinished = IKOBEJFJPHO;
		}

		internal void BIGNHFCNJLL(UITweener GCFMNEHDLAB)
		{
			TweenPosition.Begin(BJGCPDNMHDH.mSmallShieldFrame, 0.2f, BJGCPDNMHDH.mSmallShieldFrame.transform.localPosition).onFinished = LJDCIJDPLLF;
		}

		internal void KGFFOJMFLIF(UITweener BHBCEPBDLOB)
		{
			TweenScale.Begin(BJGCPDNMHDH.mSmallStripe.gameObject, 926f, BJGCPDNMHDH.KNCCPIEJAEL.ReplaceX(KFGOPGLLJDM * 1117f)).onFinished = IELMIAGLMPA;
			TweenPosition.Begin(BJGCPDNMHDH.mSmallShieldFrame, 1400f, BJGCPDNMHDH.mSmallShieldFrame.transform.localPosition.ReplaceX((0f - KFGOPGLLJDM) / 454f * 682f), false).onFinished = CLAINFGHGLJ;
			TweenPosition.Begin(BJGCPDNMHDH.mSmallLabel.gameObject, 9f, BJGCPDNMHDH.OFPABDDLAPG.AddX(1485f)).onFinished = AKKJHFHHNMF;
			TweenAlpha.Begin(BJGCPDNMHDH.mSmallLabel.gameObject, 1609f, 1848f).onFinished = NKEEEOJDJNF;
		}

		internal void ILBIBGOJCDG(UITweener KDMCDGPHBCF)
		{
			TweenScale.Begin(BJGCPDNMHDH.mSmallStripe.gameObject, 1657f, BJGCPDNMHDH.mSmallStripe.transform.localScale.MultiplyXY(637f));
		}

		internal void EALCBPNFALO(UITweener GCFMNEHDLAB)
		{
			TweenPosition.Begin(BJGCPDNMHDH.mSmallShieldFrame, 19f, BJGCPDNMHDH.mSmallShieldFrame.transform.localPosition, false).onFinished = CDPAAFFMJBI;
		}

		internal void KENBHCCEGLA(UITweener JEJOPLADMEP)
		{
			TweenPosition.Begin(BJGCPDNMHDH.mSmallLabel.gameObject, 1253f, BJGCPDNMHDH.OFPABDDLAPG);
		}

		internal void HLJFMKJJNIG(UITweener HPBPMJALCND)
		{
			TweenAlpha.Begin(BJGCPDNMHDH.mSmallLabel.gameObject, 778f, 1122f);
			BJGCPDNMHDH.NNLAJLOEHOP();
		}

		internal void CPDHBJEPNHA(UITweener CILHMLFIJJG)
		{
			TweenAlpha.Begin(BJGCPDNMHDH.mSmallLabel.gameObject, BJGCPDNMHDH.NFKMFAFGPNK - 753f, 278f).onFinished = KECLMDKKEBK;
		}
	}

	private sealed class BBOEHHFCBHC
	{
		internal float CPLAMIJELNK;

		internal MissionWaveGuiElement BJGCPDNMHDH;

		internal void IELMIAGLMPA(UITweener BHBCEPBDLOB)
		{
			TweenPosition.Begin(BJGCPDNMHDH.mRedShieldFrame, 0.3f, BJGCPDNMHDH.mRedShieldFrame.transform.localPosition.ReplaceX(CPLAMIJELNK - 120f)).onFinished = CLAINFGHGLJ;
			BJGCPDNMHDH.LLOCJHDNCBO(false);
			TweenAlpha.Begin(BJGCPDNMHDH.mWaveLabel.gameObject, 0.3f, 1f);
			TweenPosition.Begin(BJGCPDNMHDH.mWaveLabel.gameObject, 0.3f, BJGCPDNMHDH.NFAOONIHGEO.AddX(-200f), BJGCPDNMHDH.NFAOONIHGEO.AddX(30f)).onFinished = CALJKNNJHAO;
		}

		internal void PDDFAEEEMHD(UITweener BHBCEPBDLOB)
		{
			TweenPosition.Begin(BJGCPDNMHDH.mRedShieldFrame, 1758f, BJGCPDNMHDH.mRedShieldFrame.transform.localPosition.ReplaceX(CPLAMIJELNK - 1968f)).onFinished = CLAINFGHGLJ;
			BJGCPDNMHDH.LLOCJHDNCBO(true);
			TweenAlpha.Begin(BJGCPDNMHDH.mWaveLabel.gameObject, 200f, 576f);
			TweenPosition.Begin(BJGCPDNMHDH.mWaveLabel.gameObject, 702f, BJGCPDNMHDH.NFAOONIHGEO.AddX(1066f), BJGCPDNMHDH.NFAOONIHGEO.AddX(1795f), false).onFinished = MBCOEJICIDO;
		}

		internal void OIPIBKIEMNC(UITweener EFPNGJKPDNN)
		{
			TweenPosition.Begin(BJGCPDNMHDH.mRedShieldFrame, 0.3f, BJGCPDNMHDH.mRedShieldFrame.transform.localPosition.AddY(-40f));
			TweenAlpha.Begin(BJGCPDNMHDH.mRedShieldSprite.gameObject, 0.3f, 0f).onFinished = BGKOBFAHJDD;
			if (BJGCPDNMHDH.DOLJFOKNPLB)
			{
				TweenAlpha.Begin(BJGCPDNMHDH.mRedShieldBossSprite.gameObject, 0.3f, 0f);
			}
			else
			{
				TweenAlpha.Begin(BJGCPDNMHDH.mRedShieldLabel.gameObject, 0.3f, 0f);
			}
		}

		internal void PJOOELLFIFH(UITweener BDEOMPEJELN)
		{
			TweenScale.Begin(BJGCPDNMHDH.mRedShieldOutline.gameObject, 619f, BJGCPDNMHDH.LJOELGJMBOG.MultiplyXY(1814f));
			TweenAlpha.Begin(BJGCPDNMHDH.mRedShieldOutline.gameObject, 1609f, 858f, 967f);
			TweenPosition.Begin(BJGCPDNMHDH.mRedShieldFrame, 1109f, BJGCPDNMHDH.mRedShieldFrame.transform.localPosition.ReplaceY(1159f), false).onFinished = LJDCIJDPLLF;
		}

		internal void MAKLHLCDIKD(UITweener GGMEFDHCOOA)
		{
			TweenRotation.Begin(BJGCPDNMHDH.mRedShieldSprite.gameObject, 1781f, Quaternion.Euler(new Vector3(95f, 1006f, 358f)), true);
			SoundsManager.Instance.PlaySound((SoundsManager.KJGDNLHKPOG)(-7), 1178f);
		}

		internal void IPOGKCKDEGB(UITweener DBOFANHOPLE)
		{
			TweenAlpha.Begin(BJGCPDNMHDH.mWaveLabel.gameObject, BJGCPDNMHDH.NFKMFAFGPNK - 4f, 1325f).onFinished = OJFADAINIMM;
		}

		internal void BPKFAMDGNFI(UITweener BHBCEPBDLOB)
		{
			TweenPosition.Begin(BJGCPDNMHDH.mRedShieldFrame, 829f, BJGCPDNMHDH.mRedShieldFrame.transform.localPosition.ReplaceX(CPLAMIJELNK - 889f)).onFinished = CLAINFGHGLJ;
			BJGCPDNMHDH.OBNFKCAPFPA(true);
			TweenAlpha.Begin(BJGCPDNMHDH.mWaveLabel.gameObject, 361f, 1857f);
			TweenPosition.Begin(BJGCPDNMHDH.mWaveLabel.gameObject, 846f, BJGCPDNMHDH.NFAOONIHGEO.AddX(421f), BJGCPDNMHDH.NFAOONIHGEO.AddX(1487f)).onFinished = MBCOEJICIDO;
		}

		internal void LJDCIJDPLLF(UITweener GCFMNEHDLAB)
		{
			TweenPosition.Begin(BJGCPDNMHDH.mRedShieldFrame, 0.2f, BJGCPDNMHDH.mRedShieldFrame.transform.localPosition).onFinished = IELMIAGLMPA;
		}

		internal void GMHEAIHOBEL(UITweener GGMEFDHCOOA)
		{
			TweenRotation.Begin(BJGCPDNMHDH.mRedShieldLabel.gameObject, 463f, Quaternion.Euler(new Vector3(1619f, 370f, 1574f)), true);
		}

		internal void HADLONLCLPM(UITweener GGMEFDHCOOA)
		{
			TweenRotation.Begin(BJGCPDNMHDH.mRedShieldBossSprite.gameObject, 1220f, Quaternion.Euler(new Vector3(1234f, 1345f, 1227f)), true);
		}

		internal void AMBCHDNNAIF(UITweener GGMEFDHCOOA)
		{
			TweenRotation.Begin(BJGCPDNMHDH.mRedShieldLabel.gameObject, 669f, Quaternion.Euler(new Vector3(1780f, 1346f, 1163f)), true);
		}

		internal void BDCAFHOHEGM(UITweener GGMEFDHCOOA)
		{
			TweenRotation.Begin(BJGCPDNMHDH.mRedShieldSprite.gameObject, 545f, Quaternion.Euler(new Vector3(875f, 60f, 1110f)), true);
			SoundsManager.Instance.PlaySound((SoundsManager.KJGDNLHKPOG)(-36), 1694f);
		}

		internal void ABLCPCCGHOL(UITweener JEJOPLADMEP)
		{
			TweenPosition.Begin(BJGCPDNMHDH.mWaveLabel.gameObject, 595f, BJGCPDNMHDH.NFAOONIHGEO).onFinished = LIBJKLPOJMA;
		}

		internal void EFFNMHECDDI(UITweener GGMEFDHCOOA)
		{
			TweenRotation.Begin(BJGCPDNMHDH.mRedShieldBossSprite.gameObject, 1988f, Quaternion.Euler(new Vector3(855f, 1281f, 1341f)));
		}

		internal void BJLLLNAOOOB(UITweener GGMEFDHCOOA)
		{
			TweenRotation.Begin(BJGCPDNMHDH.mRedShieldLabel.gameObject, 1433f, Quaternion.Euler(new Vector3(154f, 1785f, 672f)), true);
		}

		internal void NOLFOMBJDGE(UITweener BDEOMPEJELN)
		{
			TweenScale.Begin(BJGCPDNMHDH.mRedShieldOutline.gameObject, 588f, BJGCPDNMHDH.LJOELGJMBOG.MultiplyXY(807f));
			TweenAlpha.Begin(BJGCPDNMHDH.mRedShieldOutline.gameObject, 596f, 181f, 1354f);
			TweenPosition.Begin(BJGCPDNMHDH.mRedShieldFrame, 346f, BJGCPDNMHDH.mRedShieldFrame.transform.localPosition.ReplaceY(147f), false).onFinished = LJDCIJDPLLF;
		}

		internal void JEHPFGJEGPJ(UITweener GGMEFDHCOOA)
		{
			TweenRotation.Begin(BJGCPDNMHDH.mRedShieldLabel.gameObject, 1065f, Quaternion.Euler(new Vector3(1462f, 1521f, 35f)), true);
		}

		internal void FLIKDCBHHEH(UITweener BHBCEPBDLOB)
		{
			TweenPosition.Begin(BJGCPDNMHDH.mRedShieldFrame, 249f, BJGCPDNMHDH.mRedShieldFrame.transform.localPosition.ReplaceX(CPLAMIJELNK - 240f), false).onFinished = CLAINFGHGLJ;
			BJGCPDNMHDH.PAKCNDLPNBP(false);
			TweenAlpha.Begin(BJGCPDNMHDH.mWaveLabel.gameObject, 421f, 233f);
			TweenPosition.Begin(BJGCPDNMHDH.mWaveLabel.gameObject, 1099f, BJGCPDNMHDH.NFAOONIHGEO.AddX(936f), BJGCPDNMHDH.NFAOONIHGEO.AddX(1419f)).onFinished = MBCOEJICIDO;
		}

		internal void FADFKMCBODA(UITweener JEJOPLADMEP)
		{
			TweenPosition.Begin(BJGCPDNMHDH.mWaveLabel.gameObject, 744f, BJGCPDNMHDH.NFAOONIHGEO).onFinished = IPOGKCKDEGB;
		}

		internal void BIGNHFCNJLL(UITweener BDEOMPEJELN)
		{
			TweenScale.Begin(BJGCPDNMHDH.mRedShieldOutline.gameObject, 0.4f, BJGCPDNMHDH.LJOELGJMBOG.MultiplyXY(2f));
			TweenAlpha.Begin(BJGCPDNMHDH.mRedShieldOutline.gameObject, 0.4f, 0.5f, 0f);
			TweenPosition.Begin(BJGCPDNMHDH.mRedShieldFrame, 0.1f, BJGCPDNMHDH.mRedShieldFrame.transform.localPosition.ReplaceY(0f)).onFinished = LJDCIJDPLLF;
		}

		internal void MBCOEJICIDO(UITweener JEJOPLADMEP)
		{
			TweenPosition.Begin(BJGCPDNMHDH.mWaveLabel.gameObject, 414f, BJGCPDNMHDH.NFAOONIHGEO).onFinished = IPOGKCKDEGB;
		}

		internal void IKOBEJFJPHO(UITweener DBOFANHOPLE)
		{
			TweenAlpha.Begin(BJGCPDNMHDH.mWaveLabel.gameObject, BJGCPDNMHDH.NFKMFAFGPNK - 1.1f, 1f).onFinished = GLCHANGEBNN;
		}

		internal void HONCMBHEKDP(UITweener GGMEFDHCOOA)
		{
			TweenRotation.Begin(BJGCPDNMHDH.mRedShieldLabel.gameObject, 0f, Quaternion.Euler(new Vector3(0f, 0f, 0f)));
		}

		internal void CFGDGGBELGD(UITweener GGMEFDHCOOA)
		{
			TweenRotation.Begin(BJGCPDNMHDH.mRedShieldBossSprite.gameObject, 124f, Quaternion.Euler(new Vector3(1788f, 1569f, 1273f)), true);
		}

		internal void CHDOECNGOPM(UITweener GGMEFDHCOOA)
		{
			TweenRotation.Begin(BJGCPDNMHDH.mRedShieldSprite.gameObject, 1141f, Quaternion.Euler(new Vector3(1956f, 1036f, 1493f)));
			SoundsManager.Instance.PlaySound(SoundsManager.KJGDNLHKPOG.OpenLootboxLegendary, 420f);
		}

		internal void CALJKNNJHAO(UITweener JEJOPLADMEP)
		{
			TweenPosition.Begin(BJGCPDNMHDH.mWaveLabel.gameObject, 0.2f, BJGCPDNMHDH.NFAOONIHGEO).onFinished = IKOBEJFJPHO;
		}

		internal void EJLGBICBIFK(UITweener GGMEFDHCOOA)
		{
			TweenRotation.Begin(BJGCPDNMHDH.mRedShieldBossSprite.gameObject, 0f, Quaternion.Euler(new Vector3(0f, 0f, 0f)));
		}

		internal void BBLHIEFBCBK(UITweener JEJOPLADMEP)
		{
			TweenPosition.Begin(BJGCPDNMHDH.mWaveLabel.gameObject, 1545f, BJGCPDNMHDH.NFAOONIHGEO).onFinished = PCONEMJBCDD;
		}

		internal void CNJGELMLGCO(UITweener EFPNGJKPDNN)
		{
			TweenPosition.Begin(BJGCPDNMHDH.mRedShieldFrame, 948f, BJGCPDNMHDH.mRedShieldFrame.transform.localPosition.AddY(1791f), false);
			TweenAlpha.Begin(BJGCPDNMHDH.mRedShieldSprite.gameObject, 899f, 596f).onFinished = BGKOBFAHJDD;
			if (BJGCPDNMHDH.DOLJFOKNPLB)
			{
				TweenAlpha.Begin(BJGCPDNMHDH.mRedShieldBossSprite.gameObject, 1543f, 530f);
			}
			else
			{
				TweenAlpha.Begin(BJGCPDNMHDH.mRedShieldLabel.gameObject, 815f, 85f);
			}
		}

		internal void PKCBGEEBOMA(UITweener GGMEFDHCOOA)
		{
			TweenRotation.Begin(BJGCPDNMHDH.mRedShieldBossSprite.gameObject, 1317f, Quaternion.Euler(new Vector3(612f, 1545f, 1973f)), true);
		}

		internal void LJCDGJKCNEC(UITweener GGMEFDHCOOA)
		{
			TweenRotation.Begin(BJGCPDNMHDH.mRedShieldSprite.gameObject, 0f, Quaternion.Euler(new Vector3(0f, 0f, 0f)));
			SoundsManager.Instance.PlaySound(SoundsManager.KJGDNLHKPOG.MissionNewWave);
		}

		internal void OJFADAINIMM(UITweener ILBIFGIPBFF)
		{
			TweenAlpha.Begin(BJGCPDNMHDH.mWaveLabel.gameObject, 1529f, 1167f);
			TweenPosition.Begin(BJGCPDNMHDH.mRedShieldFrame, 1695f, BJGCPDNMHDH.mRedShieldFrame.transform.localPosition.AddY(1030f), false).onFinished = OIPIBKIEMNC;
		}

		internal void CLAINFGHGLJ(UITweener JEJOPLADMEP)
		{
			TweenPosition.Begin(BJGCPDNMHDH.mRedShieldFrame, 0.2f, BJGCPDNMHDH.mRedShieldFrame.transform.localPosition.ReplaceX(CPLAMIJELNK));
			TweenScale.Begin(BJGCPDNMHDH.mRedShieldFrame, 0.2f, BJGCPDNMHDH.ACNPFDJDILA.MultiplyXY(0.8f));
		}

		internal void BCEGPIKPFJF(UITweener GGMEFDHCOOA)
		{
			TweenRotation.Begin(BJGCPDNMHDH.mRedShieldLabel.gameObject, 622f, Quaternion.Euler(new Vector3(706f, 455f, 1655f)), true);
		}

		internal void GLCHANGEBNN(UITweener ILBIFGIPBFF)
		{
			TweenAlpha.Begin(BJGCPDNMHDH.mWaveLabel.gameObject, 0.2f, 0f);
			TweenPosition.Begin(BJGCPDNMHDH.mRedShieldFrame, 0.2f, BJGCPDNMHDH.mRedShieldFrame.transform.localPosition.AddY(10f)).onFinished = OIPIBKIEMNC;
		}

		internal void PCONEMJBCDD(UITweener DBOFANHOPLE)
		{
			TweenAlpha.Begin(BJGCPDNMHDH.mWaveLabel.gameObject, BJGCPDNMHDH.NFKMFAFGPNK - 979f, 1923f).onFinished = GLCHANGEBNN;
		}

		internal void BGKOBFAHJDD(UITweener HPBPMJALCND)
		{
			BJGCPDNMHDH.MGMOJMIIHBF();
		}

		internal void LIBJKLPOJMA(UITweener DBOFANHOPLE)
		{
			TweenAlpha.Begin(BJGCPDNMHDH.mWaveLabel.gameObject, BJGCPDNMHDH.NFKMFAFGPNK - 201f, 1487f).onFinished = GLCHANGEBNN;
		}
	}

	private sealed class DLJJOBMEEOF
	{
		internal bool CECPIBMFCFF;

		internal MissionWaveGuiElement BJGCPDNMHDH;

		internal void BLEMBJFNOGA(UITweener ILBIFGIPBFF)
		{
			TweenAlpha.Begin(BJGCPDNMHDH.mMainStripeEffect.gameObject, 35f, 623f);
			TweenAlpha.Begin(BJGCPDNMHDH.mMainStripe.gameObject, 1393f, 1129f).onFinished = NFKKLDFJFMG;
		}

		internal void NKEDDGCDHNA(UITweener ICOOJGOABCI)
		{
			if (CECPIBMFCFF)
			{
				TweenAlpha.Begin(BJGCPDNMHDH.mMainStripeFlash.gameObject, 1313f, 118f, 258f);
				TweenScale.Begin(BJGCPDNMHDH.mMainStripeFlash.gameObject, 1047f, BJGCPDNMHDH.PIODAGJPNAC.ReplaceY(BJGCPDNMHDH.PIODAGJPNAC.y * 1884f));
			}
			TweenAlpha.Begin(BJGCPDNMHDH.mMainStripeEffect.gameObject, (!CECPIBMFCFF) ? (BJGCPDNMHDH.NFKMFAFGPNK - 1919f) : 155f, 943f);
			TweenAlpha.Begin(BJGCPDNMHDH.mMainStripe.gameObject, (!CECPIBMFCFF) ? (BJGCPDNMHDH.NFKMFAFGPNK - 380f) : 1400f, 1368f).onFinished = JNGEDKMBDDP;
		}

		internal void NANDBPFBFHN(UITweener MMMNJFHDJDC)
		{
			TweenAlpha.Begin(BJGCPDNMHDH.mMainStripe.gameObject, 1601f, 1949f).onFinished = NGGMHJGNIBB;
		}

		internal void JLDJJLDKGHA(UITweener HPBPMJALCND)
		{
			TweenAlpha.Begin(BJGCPDNMHDH.mMainStripe.gameObject, 1252f, 139f);
			BJGCPDNMHDH.OFPFFOBGCFK();
		}

		internal void PNINBELBDIP(UITweener ILBIFGIPBFF)
		{
			TweenAlpha.Begin(BJGCPDNMHDH.mMainStripeEffect.gameObject, 935f, 1706f);
			TweenAlpha.Begin(BJGCPDNMHDH.mMainStripe.gameObject, 1154f, 1887f).onFinished = AFDIFBLGGKG;
		}

		internal void IGNHEDDHHIA(UITweener ILBIFGIPBFF)
		{
			TweenAlpha.Begin(BJGCPDNMHDH.mMainStripeEffect.gameObject, 1331f, 146f);
			TweenAlpha.Begin(BJGCPDNMHDH.mMainStripe.gameObject, 787f, 1287f).onFinished = LPGNOJNCOEB;
		}

		internal void DBFJEDLPKDO(UITweener MMMNJFHDJDC)
		{
			TweenAlpha.Begin(BJGCPDNMHDH.mMainStripe.gameObject, 878f, 1487f).onFinished = DNGAFKMOPOJ;
		}

		internal void HONCMBHEKDP(UITweener ILBIFGIPBFF)
		{
			TweenAlpha.Begin(BJGCPDNMHDH.mMainStripeEffect.gameObject, 0.05f, 0f);
			TweenAlpha.Begin(BJGCPDNMHDH.mMainStripe.gameObject, 0.05f, 0f).onFinished = BIGNHFCNJLL;
		}

		internal void IOBMBGMAHLM(UITweener ICOOJGOABCI)
		{
			if (CECPIBMFCFF)
			{
				TweenAlpha.Begin(BJGCPDNMHDH.mMainStripeFlash.gameObject, 88f, 1783f, 968f);
				TweenScale.Begin(BJGCPDNMHDH.mMainStripeFlash.gameObject, 1780f, BJGCPDNMHDH.PIODAGJPNAC.ReplaceY(BJGCPDNMHDH.PIODAGJPNAC.y * 1840f));
			}
			TweenAlpha.Begin(BJGCPDNMHDH.mMainStripeEffect.gameObject, (!CECPIBMFCFF) ? (BJGCPDNMHDH.NFKMFAFGPNK - 137f) : 230f, 1724f);
			TweenAlpha.Begin(BJGCPDNMHDH.mMainStripe.gameObject, (!CECPIBMFCFF) ? (BJGCPDNMHDH.NFKMFAFGPNK - 1728f) : 548f, 157f).onFinished = HONCMBHEKDP;
		}

		internal void KGFFOJMFLIF(UITweener HPBPMJALCND)
		{
			TweenAlpha.Begin(BJGCPDNMHDH.mMainStripe.gameObject, 178f, 601f);
			BJGCPDNMHDH.KLDALPDEMFB();
		}

		internal void LOJKOGKKDIO(UITweener ILBIFGIPBFF)
		{
			TweenAlpha.Begin(BJGCPDNMHDH.mMainStripeEffect.gameObject, 37f, 709f);
			TweenAlpha.Begin(BJGCPDNMHDH.mMainStripe.gameObject, 404f, 371f).onFinished = KGKINIGMHJP;
		}

		internal void EOOLCOFIFJB(UITweener MMMNJFHDJDC)
		{
			TweenAlpha.Begin(BJGCPDNMHDH.mMainStripe.gameObject, 1735f, 1451f).onFinished = KMFJIOCFGGF;
		}

		internal void MCFGAFBEJDK(UITweener KDMCDGPHBCF)
		{
			TweenScale.Begin(BJGCPDNMHDH.mMainStripeEffect.gameObject, 1606f, BJGCPDNMHDH.PIODAGJPNAC.ReplaceY(BJGCPDNMHDH.PIODAGJPNAC.y * 1749f));
			TweenScale.Begin(BJGCPDNMHDH.mMainStripe.gameObject, 1976f, BJGCPDNMHDH.PIODAGJPNAC.ReplaceY(BJGCPDNMHDH.PIODAGJPNAC.y * 1790f)).onFinished = ENOBKGECBGB;
			TweenPosition.Begin(BJGCPDNMHDH.mUpStripe.gameObject, 751f, BJGCPDNMHDH.INGHOCKPEPK.AddY(576f));
			TweenPosition.Begin(BJGCPDNMHDH.mDownStripe.gameObject, 1068f, BJGCPDNMHDH.PGACGMJFDCJ.AddY(1971f), false);
			TweenAlpha.Begin(BJGCPDNMHDH.mUpStripe.gameObject, 1828f, 1575f);
			TweenAlpha.Begin(BJGCPDNMHDH.mDownStripe.gameObject, 246f, 985f);
		}

		internal void AFGKAEIMPJA(UITweener HPBPMJALCND)
		{
			TweenAlpha.Begin(BJGCPDNMHDH.mMainStripe.gameObject, 791f, 1865f);
			BJGCPDNMHDH.HOBIADPHBCA();
		}

		internal void LPGNOJNCOEB(UITweener MMMNJFHDJDC)
		{
			TweenAlpha.Begin(BJGCPDNMHDH.mMainStripe.gameObject, 1679f, 946f).onFinished = KGFFOJMFLIF;
		}

		internal void CLLDAFLGJJJ(UITweener ICOOJGOABCI)
		{
			if (CECPIBMFCFF)
			{
				TweenAlpha.Begin(BJGCPDNMHDH.mMainStripeFlash.gameObject, 1442f, 292f, 66f);
				TweenScale.Begin(BJGCPDNMHDH.mMainStripeFlash.gameObject, 512f, BJGCPDNMHDH.PIODAGJPNAC.ReplaceY(BJGCPDNMHDH.PIODAGJPNAC.y * 627f));
			}
			TweenAlpha.Begin(BJGCPDNMHDH.mMainStripeEffect.gameObject, (!CECPIBMFCFF) ? (BJGCPDNMHDH.NFKMFAFGPNK - 37f) : 283f, 1144f);
			TweenAlpha.Begin(BJGCPDNMHDH.mMainStripe.gameObject, (!CECPIBMFCFF) ? (BJGCPDNMHDH.NFKMFAFGPNK - 1099f) : 1930f, 692f).onFinished = OCEMAFDGLCC;
		}

		internal void AFDIFBLGGKG(UITweener MMMNJFHDJDC)
		{
			TweenAlpha.Begin(BJGCPDNMHDH.mMainStripe.gameObject, 323f, 1174f).onFinished = OKMLGDDAAMK;
		}

		internal void EFOONDNINBC(UITweener KDMCDGPHBCF)
		{
			TweenScale.Begin(BJGCPDNMHDH.mMainStripeEffect.gameObject, 422f, BJGCPDNMHDH.PIODAGJPNAC.ReplaceY(BJGCPDNMHDH.PIODAGJPNAC.y * 1676f));
			TweenScale.Begin(BJGCPDNMHDH.mMainStripe.gameObject, 1282f, BJGCPDNMHDH.PIODAGJPNAC.ReplaceY(BJGCPDNMHDH.PIODAGJPNAC.y * 1929f)).onFinished = OGPEMMMGBLD;
			TweenPosition.Begin(BJGCPDNMHDH.mUpStripe.gameObject, 1169f, BJGCPDNMHDH.INGHOCKPEPK.AddY(924f), false);
			TweenPosition.Begin(BJGCPDNMHDH.mDownStripe.gameObject, 1336f, BJGCPDNMHDH.PGACGMJFDCJ.AddY(245f), false);
			TweenAlpha.Begin(BJGCPDNMHDH.mUpStripe.gameObject, 1112f, 1112f);
			TweenAlpha.Begin(BJGCPDNMHDH.mDownStripe.gameObject, 1982f, 580f);
		}

		internal void BIGNHFCNJLL(UITweener MMMNJFHDJDC)
		{
			TweenAlpha.Begin(BJGCPDNMHDH.mMainStripe.gameObject, 0.05f, 0.4f).onFinished = LJDCIJDPLLF;
		}

		internal void CIFEDFPPPOK(UITweener KDMCDGPHBCF)
		{
			TweenScale.Begin(BJGCPDNMHDH.mMainStripeEffect.gameObject, 277f, BJGCPDNMHDH.PIODAGJPNAC.ReplaceY(BJGCPDNMHDH.PIODAGJPNAC.y * 691f));
			TweenScale.Begin(BJGCPDNMHDH.mMainStripe.gameObject, 1986f, BJGCPDNMHDH.PIODAGJPNAC.ReplaceY(BJGCPDNMHDH.PIODAGJPNAC.y * 1659f)).onFinished = AKCPOJMIBOG;
			TweenPosition.Begin(BJGCPDNMHDH.mUpStripe.gameObject, 348f, BJGCPDNMHDH.INGHOCKPEPK.AddY(1183f));
			TweenPosition.Begin(BJGCPDNMHDH.mDownStripe.gameObject, 36f, BJGCPDNMHDH.PGACGMJFDCJ.AddY(785f));
			TweenAlpha.Begin(BJGCPDNMHDH.mUpStripe.gameObject, 901f, 932f);
			TweenAlpha.Begin(BJGCPDNMHDH.mDownStripe.gameObject, 379f, 616f);
		}

		internal void POGDLLFCOKO(UITweener KDMCDGPHBCF)
		{
			TweenScale.Begin(BJGCPDNMHDH.mMainStripeEffect.gameObject, 1061f, BJGCPDNMHDH.PIODAGJPNAC.ReplaceY(BJGCPDNMHDH.PIODAGJPNAC.y * 876f));
			TweenScale.Begin(BJGCPDNMHDH.mMainStripe.gameObject, 854f, BJGCPDNMHDH.PIODAGJPNAC.ReplaceY(BJGCPDNMHDH.PIODAGJPNAC.y * 1108f)).onFinished = CLLDAFLGJJJ;
			TweenPosition.Begin(BJGCPDNMHDH.mUpStripe.gameObject, 469f, BJGCPDNMHDH.INGHOCKPEPK.AddY(296f), false);
			TweenPosition.Begin(BJGCPDNMHDH.mDownStripe.gameObject, 1381f, BJGCPDNMHDH.PGACGMJFDCJ.AddY(908f));
			TweenAlpha.Begin(BJGCPDNMHDH.mUpStripe.gameObject, 732f, 177f);
			TweenAlpha.Begin(BJGCPDNMHDH.mDownStripe.gameObject, 1874f, 1687f);
		}

		internal void FBGCFPAGIND(UITweener ILBIFGIPBFF)
		{
			TweenAlpha.Begin(BJGCPDNMHDH.mMainStripeEffect.gameObject, 1732f, 1340f);
			TweenAlpha.Begin(BJGCPDNMHDH.mMainStripe.gameObject, 911f, 39f).onFinished = NCMLGJHPJNA;
		}

		internal void FCENGDPPIJH(UITweener ILBIFGIPBFF)
		{
			TweenAlpha.Begin(BJGCPDNMHDH.mMainStripeEffect.gameObject, 1732f, 924f);
			TweenAlpha.Begin(BJGCPDNMHDH.mMainStripe.gameObject, 8f, 1777f).onFinished = NDGHMPKFDNA;
		}

		internal void GABDIGAMEOI(UITweener MMMNJFHDJDC)
		{
			TweenAlpha.Begin(BJGCPDNMHDH.mMainStripe.gameObject, 520f, 1785f).onFinished = HPABMPFKOLD;
		}

		internal void MPHECHCFCAN(UITweener KDMCDGPHBCF)
		{
			TweenScale.Begin(BJGCPDNMHDH.mMainStripeEffect.gameObject, 456f, BJGCPDNMHDH.PIODAGJPNAC.ReplaceY(BJGCPDNMHDH.PIODAGJPNAC.y * 1024f));
			TweenScale.Begin(BJGCPDNMHDH.mMainStripe.gameObject, 167f, BJGCPDNMHDH.PIODAGJPNAC.ReplaceY(BJGCPDNMHDH.PIODAGJPNAC.y * 270f)).onFinished = OGPEMMMGBLD;
			TweenPosition.Begin(BJGCPDNMHDH.mUpStripe.gameObject, 853f, BJGCPDNMHDH.INGHOCKPEPK.AddY(463f), false);
			TweenPosition.Begin(BJGCPDNMHDH.mDownStripe.gameObject, 520f, BJGCPDNMHDH.PGACGMJFDCJ.AddY(1561f));
			TweenAlpha.Begin(BJGCPDNMHDH.mUpStripe.gameObject, 1334f, 895f);
			TweenAlpha.Begin(BJGCPDNMHDH.mDownStripe.gameObject, 1502f, 1047f);
		}

		internal void EJLGBICBIFK(UITweener ICOOJGOABCI)
		{
			if (CECPIBMFCFF)
			{
				TweenAlpha.Begin(BJGCPDNMHDH.mMainStripeFlash.gameObject, 1f, 1f, 0f);
				TweenScale.Begin(BJGCPDNMHDH.mMainStripeFlash.gameObject, 0.2f, BJGCPDNMHDH.PIODAGJPNAC.ReplaceY(BJGCPDNMHDH.PIODAGJPNAC.y * 0.8f));
			}
			TweenAlpha.Begin(BJGCPDNMHDH.mMainStripeEffect.gameObject, (!CECPIBMFCFF) ? (BJGCPDNMHDH.NFKMFAFGPNK - 1.1f) : 1.5f, 0.4f);
			TweenAlpha.Begin(BJGCPDNMHDH.mMainStripe.gameObject, (!CECPIBMFCFF) ? (BJGCPDNMHDH.NFKMFAFGPNK - 1.1f) : 1.5f, 0.4f).onFinished = HONCMBHEKDP;
		}

		internal void IGNHNKFEEPA(UITweener ILBIFGIPBFF)
		{
			TweenAlpha.Begin(BJGCPDNMHDH.mMainStripeEffect.gameObject, 1347f, 1851f);
			TweenAlpha.Begin(BJGCPDNMHDH.mMainStripe.gameObject, 1191f, 1015f).onFinished = IOPJAPNNOOK;
		}

		internal void CCILPMFDGLP(UITweener HPBPMJALCND)
		{
			TweenAlpha.Begin(BJGCPDNMHDH.mMainStripe.gameObject, 1418f, 1440f);
			BJGCPDNMHDH.OFPFFOBGCFK();
		}

		internal void BFMHIICIHKL(UITweener ICOOJGOABCI)
		{
			if (CECPIBMFCFF)
			{
				TweenAlpha.Begin(BJGCPDNMHDH.mMainStripeFlash.gameObject, 997f, 772f, 1793f);
				TweenScale.Begin(BJGCPDNMHDH.mMainStripeFlash.gameObject, 1021f, BJGCPDNMHDH.PIODAGJPNAC.ReplaceY(BJGCPDNMHDH.PIODAGJPNAC.y * 4f));
			}
			TweenAlpha.Begin(BJGCPDNMHDH.mMainStripeEffect.gameObject, (!CECPIBMFCFF) ? (BJGCPDNMHDH.NFKMFAFGPNK - 1922f) : 1586f, 1953f);
			TweenAlpha.Begin(BJGCPDNMHDH.mMainStripe.gameObject, (!CECPIBMFCFF) ? (BJGCPDNMHDH.NFKMFAFGPNK - 1488f) : 1953f, 1798f).onFinished = IGNHEDDHHIA;
		}

		internal void AMMPOLAGNGG(UITweener MMMNJFHDJDC)
		{
			TweenAlpha.Begin(BJGCPDNMHDH.mMainStripe.gameObject, 1395f, 1397f).onFinished = CAOMBGGBHAL;
		}

		internal void OEPJOALFHDE(UITweener HPBPMJALCND)
		{
			TweenAlpha.Begin(BJGCPDNMHDH.mMainStripe.gameObject, 1394f, 1779f);
			BJGCPDNMHDH.HOBIADPHBCA();
		}

		internal void FICGLJJELPM(UITweener KDMCDGPHBCF)
		{
			TweenScale.Begin(BJGCPDNMHDH.mMainStripeEffect.gameObject, 934f, BJGCPDNMHDH.PIODAGJPNAC.ReplaceY(BJGCPDNMHDH.PIODAGJPNAC.y * 1637f));
			TweenScale.Begin(BJGCPDNMHDH.mMainStripe.gameObject, 42f, BJGCPDNMHDH.PIODAGJPNAC.ReplaceY(BJGCPDNMHDH.PIODAGJPNAC.y * 1657f)).onFinished = ONGCFEKPIPL;
			TweenPosition.Begin(BJGCPDNMHDH.mUpStripe.gameObject, 719f, BJGCPDNMHDH.INGHOCKPEPK.AddY(1367f), false);
			TweenPosition.Begin(BJGCPDNMHDH.mDownStripe.gameObject, 763f, BJGCPDNMHDH.PGACGMJFDCJ.AddY(1910f), false);
			TweenAlpha.Begin(BJGCPDNMHDH.mUpStripe.gameObject, 1278f, 1629f);
			TweenAlpha.Begin(BJGCPDNMHDH.mDownStripe.gameObject, 929f, 129f);
		}

		internal void NPGMMHNIDCD(UITweener HPBPMJALCND)
		{
			TweenAlpha.Begin(BJGCPDNMHDH.mMainStripe.gameObject, 1318f, 109f);
			BJGCPDNMHDH.OFPFFOBGCFK();
		}

		internal void IOPJAPNNOOK(UITweener MMMNJFHDJDC)
		{
			TweenAlpha.Begin(BJGCPDNMHDH.mMainStripe.gameObject, 1041f, 781f).onFinished = DGDMNBKOMFK;
		}

		internal void PCBLIENKOPE(UITweener ICOOJGOABCI)
		{
			if (CECPIBMFCFF)
			{
				TweenAlpha.Begin(BJGCPDNMHDH.mMainStripeFlash.gameObject, 711f, 459f, 213f);
				TweenScale.Begin(BJGCPDNMHDH.mMainStripeFlash.gameObject, 477f, BJGCPDNMHDH.PIODAGJPNAC.ReplaceY(BJGCPDNMHDH.PIODAGJPNAC.y * 310f));
			}
			TweenAlpha.Begin(BJGCPDNMHDH.mMainStripeEffect.gameObject, (!CECPIBMFCFF) ? (BJGCPDNMHDH.NFKMFAFGPNK - 482f) : 313f, 1084f);
			TweenAlpha.Begin(BJGCPDNMHDH.mMainStripe.gameObject, (!CECPIBMFCFF) ? (BJGCPDNMHDH.NFKMFAFGPNK - 1474f) : 1964f, 1270f).onFinished = GIBMAADBPNI;
		}

		internal void JNHMJLAGPDL(UITweener ILBIFGIPBFF)
		{
			TweenAlpha.Begin(BJGCPDNMHDH.mMainStripeEffect.gameObject, 1041f, 191f);
			TweenAlpha.Begin(BJGCPDNMHDH.mMainStripe.gameObject, 709f, 1140f).onFinished = HNIOCGFEKKH;
		}

		internal void EBHKJFGOBGH(UITweener HPBPMJALCND)
		{
			TweenAlpha.Begin(BJGCPDNMHDH.mMainStripe.gameObject, 1474f, 1462f);
			BJGCPDNMHDH.HOBIADPHBCA();
		}

		internal void DNGAFKMOPOJ(UITweener HPBPMJALCND)
		{
			TweenAlpha.Begin(BJGCPDNMHDH.mMainStripe.gameObject, 1386f, 901f);
			BJGCPDNMHDH.HOBIADPHBCA();
		}

		internal void KJMIFMILHKH(UITweener KDMCDGPHBCF)
		{
			TweenScale.Begin(BJGCPDNMHDH.mMainStripeEffect.gameObject, 867f, BJGCPDNMHDH.PIODAGJPNAC.ReplaceY(BJGCPDNMHDH.PIODAGJPNAC.y * 1277f));
			TweenScale.Begin(BJGCPDNMHDH.mMainStripe.gameObject, 558f, BJGCPDNMHDH.PIODAGJPNAC.ReplaceY(BJGCPDNMHDH.PIODAGJPNAC.y * 1182f)).onFinished = OPPNIDPBBIM;
			TweenPosition.Begin(BJGCPDNMHDH.mUpStripe.gameObject, 1909f, BJGCPDNMHDH.INGHOCKPEPK.AddY(749f), false);
			TweenPosition.Begin(BJGCPDNMHDH.mDownStripe.gameObject, 1638f, BJGCPDNMHDH.PGACGMJFDCJ.AddY(972f), false);
			TweenAlpha.Begin(BJGCPDNMHDH.mUpStripe.gameObject, 1196f, 376f);
			TweenAlpha.Begin(BJGCPDNMHDH.mDownStripe.gameObject, 1562f, 848f);
		}

		internal void PNHKMBCDIHI(UITweener HPBPMJALCND)
		{
			TweenAlpha.Begin(BJGCPDNMHDH.mMainStripe.gameObject, 223f, 901f);
			BJGCPDNMHDH.OFPFFOBGCFK();
		}

		internal void KLCBGHFEJCP(UITweener ILBIFGIPBFF)
		{
			TweenAlpha.Begin(BJGCPDNMHDH.mMainStripeEffect.gameObject, 766f, 1337f);
			TweenAlpha.Begin(BJGCPDNMHDH.mMainStripe.gameObject, 649f, 1355f).onFinished = NANDBPFBFHN;
		}

		internal void ONGCFEKPIPL(UITweener ICOOJGOABCI)
		{
			if (CECPIBMFCFF)
			{
				TweenAlpha.Begin(BJGCPDNMHDH.mMainStripeFlash.gameObject, 753f, 971f, 1010f);
				TweenScale.Begin(BJGCPDNMHDH.mMainStripeFlash.gameObject, 1568f, BJGCPDNMHDH.PIODAGJPNAC.ReplaceY(BJGCPDNMHDH.PIODAGJPNAC.y * 15f));
			}
			TweenAlpha.Begin(BJGCPDNMHDH.mMainStripeEffect.gameObject, (!CECPIBMFCFF) ? (BJGCPDNMHDH.NFKMFAFGPNK - 1679f) : 887f, 298f);
			TweenAlpha.Begin(BJGCPDNMHDH.mMainStripe.gameObject, (!CECPIBMFCFF) ? (BJGCPDNMHDH.NFKMFAFGPNK - 40f) : 1602f, 298f).onFinished = FBGCFPAGIND;
		}

		internal void NCMLGJHPJNA(UITweener MMMNJFHDJDC)
		{
			TweenAlpha.Begin(BJGCPDNMHDH.mMainStripe.gameObject, 881f, 1258f).onFinished = KGFFOJMFLIF;
		}

		internal void LJDCIJDPLLF(UITweener HPBPMJALCND)
		{
			TweenAlpha.Begin(BJGCPDNMHDH.mMainStripe.gameObject, 0.05f, 0f);
			BJGCPDNMHDH.OFPFFOBGCFK();
		}

		internal void KEBLADMIDMM(UITweener ILBIFGIPBFF)
		{
			TweenAlpha.Begin(BJGCPDNMHDH.mMainStripeEffect.gameObject, 1702f, 1668f);
			TweenAlpha.Begin(BJGCPDNMHDH.mMainStripe.gameObject, 979f, 646f).onFinished = GABDIGAMEOI;
		}

		internal void MILKIIDMINH(UITweener ICOOJGOABCI)
		{
			if (CECPIBMFCFF)
			{
				TweenAlpha.Begin(BJGCPDNMHDH.mMainStripeFlash.gameObject, 62f, 1282f, 661f);
				TweenScale.Begin(BJGCPDNMHDH.mMainStripeFlash.gameObject, 1059f, BJGCPDNMHDH.PIODAGJPNAC.ReplaceY(BJGCPDNMHDH.PIODAGJPNAC.y * 540f));
			}
			TweenAlpha.Begin(BJGCPDNMHDH.mMainStripeEffect.gameObject, (!CECPIBMFCFF) ? (BJGCPDNMHDH.NFKMFAFGPNK - 1060f) : 1558f, 1010f);
			TweenAlpha.Begin(BJGCPDNMHDH.mMainStripe.gameObject, (!CECPIBMFCFF) ? (BJGCPDNMHDH.NFKMFAFGPNK - 1413f) : 1158f, 408f).onFinished = ABFILPKPIEP;
		}

		internal void FGIDNDGEKPD(UITweener HPBPMJALCND)
		{
			TweenAlpha.Begin(BJGCPDNMHDH.mMainStripe.gameObject, 1722f, 77f);
			BJGCPDNMHDH.HOBIADPHBCA();
		}

		internal void NGGMHJGNIBB(UITweener HPBPMJALCND)
		{
			TweenAlpha.Begin(BJGCPDNMHDH.mMainStripe.gameObject, 1863f, 1310f);
			BJGCPDNMHDH.OFPFFOBGCFK();
		}

		internal void PEFOCGECECP(UITweener KDMCDGPHBCF)
		{
			TweenScale.Begin(BJGCPDNMHDH.mMainStripeEffect.gameObject, 258f, BJGCPDNMHDH.PIODAGJPNAC.ReplaceY(BJGCPDNMHDH.PIODAGJPNAC.y * 1924f));
			TweenScale.Begin(BJGCPDNMHDH.mMainStripe.gameObject, 326f, BJGCPDNMHDH.PIODAGJPNAC.ReplaceY(BJGCPDNMHDH.PIODAGJPNAC.y * 20f)).onFinished = DKNJHLBJKKD;
			TweenPosition.Begin(BJGCPDNMHDH.mUpStripe.gameObject, 1101f, BJGCPDNMHDH.INGHOCKPEPK.AddY(1373f), false);
			TweenPosition.Begin(BJGCPDNMHDH.mDownStripe.gameObject, 1234f, BJGCPDNMHDH.PGACGMJFDCJ.AddY(584f));
			TweenAlpha.Begin(BJGCPDNMHDH.mUpStripe.gameObject, 700f, 1485f);
			TweenAlpha.Begin(BJGCPDNMHDH.mDownStripe.gameObject, 1675f, 742f);
		}

		internal void CGEBGHGEMIB(UITweener ILBIFGIPBFF)
		{
			TweenAlpha.Begin(BJGCPDNMHDH.mMainStripeEffect.gameObject, 84f, 1002f);
			TweenAlpha.Begin(BJGCPDNMHDH.mMainStripe.gameObject, 480f, 930f).onFinished = KOMNMELADLH;
		}

		internal void FFGOEHLBPHP(UITweener ILBIFGIPBFF)
		{
			TweenAlpha.Begin(BJGCPDNMHDH.mMainStripeEffect.gameObject, 1631f, 1187f);
			TweenAlpha.Begin(BJGCPDNMHDH.mMainStripe.gameObject, 1271f, 460f).onFinished = LPGNOJNCOEB;
		}

		internal void MJGCOLIPCBJ(UITweener MMMNJFHDJDC)
		{
			TweenAlpha.Begin(BJGCPDNMHDH.mMainStripe.gameObject, 939f, 352f).onFinished = CCILPMFDGLP;
		}

		internal void NOAPANGNNCC(UITweener ILBIFGIPBFF)
		{
			TweenAlpha.Begin(BJGCPDNMHDH.mMainStripeEffect.gameObject, 1029f, 147f);
			TweenAlpha.Begin(BJGCPDNMHDH.mMainStripe.gameObject, 1699f, 1157f).onFinished = IOPJAPNNOOK;
		}

		internal void MMEEJDGGAID(UITweener KDMCDGPHBCF)
		{
			TweenScale.Begin(BJGCPDNMHDH.mMainStripeEffect.gameObject, 1891f, BJGCPDNMHDH.PIODAGJPNAC.ReplaceY(BJGCPDNMHDH.PIODAGJPNAC.y * 837f));
			TweenScale.Begin(BJGCPDNMHDH.mMainStripe.gameObject, 1056f, BJGCPDNMHDH.PIODAGJPNAC.ReplaceY(BJGCPDNMHDH.PIODAGJPNAC.y * 1304f)).onFinished = OPPNIDPBBIM;
			TweenPosition.Begin(BJGCPDNMHDH.mUpStripe.gameObject, 963f, BJGCPDNMHDH.INGHOCKPEPK.AddY(1920f));
			TweenPosition.Begin(BJGCPDNMHDH.mDownStripe.gameObject, 1257f, BJGCPDNMHDH.PGACGMJFDCJ.AddY(1698f));
			TweenAlpha.Begin(BJGCPDNMHDH.mUpStripe.gameObject, 765f, 916f);
			TweenAlpha.Begin(BJGCPDNMHDH.mDownStripe.gameObject, 1401f, 1884f);
		}

		internal void IPNILCPEJCE(UITweener HPBPMJALCND)
		{
			TweenAlpha.Begin(BJGCPDNMHDH.mMainStripe.gameObject, 301f, 1848f);
			BJGCPDNMHDH.KLDALPDEMFB();
		}

		internal void ENOBKGECBGB(UITweener ICOOJGOABCI)
		{
			if (CECPIBMFCFF)
			{
				TweenAlpha.Begin(BJGCPDNMHDH.mMainStripeFlash.gameObject, 1919f, 1345f, 1607f);
				TweenScale.Begin(BJGCPDNMHDH.mMainStripeFlash.gameObject, 1450f, BJGCPDNMHDH.PIODAGJPNAC.ReplaceY(BJGCPDNMHDH.PIODAGJPNAC.y * 1343f));
			}
			TweenAlpha.Begin(BJGCPDNMHDH.mMainStripeEffect.gameObject, (!CECPIBMFCFF) ? (BJGCPDNMHDH.NFKMFAFGPNK - 1106f) : 601f, 33f);
			TweenAlpha.Begin(BJGCPDNMHDH.mMainStripe.gameObject, (!CECPIBMFCFF) ? (BJGCPDNMHDH.NFKMFAFGPNK - 973f) : 683f, 360f).onFinished = HONHEKPPHEB;
		}

		internal void DBOFGALOCEF(UITweener MMMNJFHDJDC)
		{
			TweenAlpha.Begin(BJGCPDNMHDH.mMainStripe.gameObject, 407f, 1527f).onFinished = IPNILCPEJCE;
		}

		internal void OGPEMMMGBLD(UITweener ICOOJGOABCI)
		{
			if (CECPIBMFCFF)
			{
				TweenAlpha.Begin(BJGCPDNMHDH.mMainStripeFlash.gameObject, 287f, 306f, 122f);
				TweenScale.Begin(BJGCPDNMHDH.mMainStripeFlash.gameObject, 369f, BJGCPDNMHDH.PIODAGJPNAC.ReplaceY(BJGCPDNMHDH.PIODAGJPNAC.y * 814f));
			}
			TweenAlpha.Begin(BJGCPDNMHDH.mMainStripeEffect.gameObject, (!CECPIBMFCFF) ? (BJGCPDNMHDH.NFKMFAFGPNK - 121f) : 770f, 1636f);
			TweenAlpha.Begin(BJGCPDNMHDH.mMainStripe.gameObject, (!CECPIBMFCFF) ? (BJGCPDNMHDH.NFKMFAFGPNK - 1430f) : 1570f, 446f).onFinished = LIDIOMDBBMI;
		}

		internal void JNGEDKMBDDP(UITweener ILBIFGIPBFF)
		{
			TweenAlpha.Begin(BJGCPDNMHDH.mMainStripeEffect.gameObject, 1420f, 1722f);
			TweenAlpha.Begin(BJGCPDNMHDH.mMainStripe.gameObject, 1577f, 554f).onFinished = HNIOCGFEKKH;
		}

		internal void CIAOICMCMAM(UITweener ICOOJGOABCI)
		{
			if (CECPIBMFCFF)
			{
				TweenAlpha.Begin(BJGCPDNMHDH.mMainStripeFlash.gameObject, 827f, 896f, 1135f);
				TweenScale.Begin(BJGCPDNMHDH.mMainStripeFlash.gameObject, 1299f, BJGCPDNMHDH.PIODAGJPNAC.ReplaceY(BJGCPDNMHDH.PIODAGJPNAC.y * 1706f));
			}
			TweenAlpha.Begin(BJGCPDNMHDH.mMainStripeEffect.gameObject, (!CECPIBMFCFF) ? (BJGCPDNMHDH.NFKMFAFGPNK - 1210f) : 198f, 1341f);
			TweenAlpha.Begin(BJGCPDNMHDH.mMainStripe.gameObject, (!CECPIBMFCFF) ? (BJGCPDNMHDH.NFKMFAFGPNK - 297f) : 993f, 159f).onFinished = PNINBELBDIP;
		}

		internal void BIKJIFFCHFH(UITweener ICOOJGOABCI)
		{
			if (CECPIBMFCFF)
			{
				TweenAlpha.Begin(BJGCPDNMHDH.mMainStripeFlash.gameObject, 80f, 286f, 54f);
				TweenScale.Begin(BJGCPDNMHDH.mMainStripeFlash.gameObject, 380f, BJGCPDNMHDH.PIODAGJPNAC.ReplaceY(BJGCPDNMHDH.PIODAGJPNAC.y * 204f));
			}
			TweenAlpha.Begin(BJGCPDNMHDH.mMainStripeEffect.gameObject, (!CECPIBMFCFF) ? (BJGCPDNMHDH.NFKMFAFGPNK - 238f) : 1947f, 715f);
			TweenAlpha.Begin(BJGCPDNMHDH.mMainStripe.gameObject, (!CECPIBMFCFF) ? (BJGCPDNMHDH.NFKMFAFGPNK - 119f) : 1334f, 585f).onFinished = JNGEDKMBDDP;
		}

		internal void OCEMAFDGLCC(UITweener ILBIFGIPBFF)
		{
			TweenAlpha.Begin(BJGCPDNMHDH.mMainStripeEffect.gameObject, 1367f, 1280f);
			TweenAlpha.Begin(BJGCPDNMHDH.mMainStripe.gameObject, 1981f, 735f).onFinished = GABDIGAMEOI;
		}

		internal void JGHLGHMJJDG(UITweener KDMCDGPHBCF)
		{
			TweenScale.Begin(BJGCPDNMHDH.mMainStripeEffect.gameObject, 1217f, BJGCPDNMHDH.PIODAGJPNAC.ReplaceY(BJGCPDNMHDH.PIODAGJPNAC.y * 1809f));
			TweenScale.Begin(BJGCPDNMHDH.mMainStripe.gameObject, 566f, BJGCPDNMHDH.PIODAGJPNAC.ReplaceY(BJGCPDNMHDH.PIODAGJPNAC.y * 458f)).onFinished = BFMHIICIHKL;
			TweenPosition.Begin(BJGCPDNMHDH.mUpStripe.gameObject, 392f, BJGCPDNMHDH.INGHOCKPEPK.AddY(604f));
			TweenPosition.Begin(BJGCPDNMHDH.mDownStripe.gameObject, 427f, BJGCPDNMHDH.PGACGMJFDCJ.AddY(160f), false);
			TweenAlpha.Begin(BJGCPDNMHDH.mUpStripe.gameObject, 937f, 622f);
			TweenAlpha.Begin(BJGCPDNMHDH.mDownStripe.gameObject, 1140f, 123f);
		}

		internal void LIIBDBFDNOC(UITweener HPBPMJALCND)
		{
			TweenAlpha.Begin(BJGCPDNMHDH.mMainStripe.gameObject, 1528f, 1980f);
			BJGCPDNMHDH.KLDALPDEMFB();
		}

		internal void KJIFNOJILDB(UITweener KDMCDGPHBCF)
		{
			TweenScale.Begin(BJGCPDNMHDH.mMainStripeEffect.gameObject, 698f, BJGCPDNMHDH.PIODAGJPNAC.ReplaceY(BJGCPDNMHDH.PIODAGJPNAC.y * 1938f));
			TweenScale.Begin(BJGCPDNMHDH.mMainStripe.gameObject, 884f, BJGCPDNMHDH.PIODAGJPNAC.ReplaceY(BJGCPDNMHDH.PIODAGJPNAC.y * 1567f)).onFinished = BLNOPKPLONB;
			TweenPosition.Begin(BJGCPDNMHDH.mUpStripe.gameObject, 1506f, BJGCPDNMHDH.INGHOCKPEPK.AddY(674f));
			TweenPosition.Begin(BJGCPDNMHDH.mDownStripe.gameObject, 1900f, BJGCPDNMHDH.PGACGMJFDCJ.AddY(1911f), false);
			TweenAlpha.Begin(BJGCPDNMHDH.mUpStripe.gameObject, 1647f, 1422f);
			TweenAlpha.Begin(BJGCPDNMHDH.mDownStripe.gameObject, 314f, 295f);
		}

		internal void LIDIOMDBBMI(UITweener ILBIFGIPBFF)
		{
			TweenAlpha.Begin(BJGCPDNMHDH.mMainStripeEffect.gameObject, 308f, 1255f);
			TweenAlpha.Begin(BJGCPDNMHDH.mMainStripe.gameObject, 1640f, 1128f).onFinished = MJGCOLIPCBJ;
		}

		internal void OEKMGACNPJM(UITweener ICOOJGOABCI)
		{
			if (CECPIBMFCFF)
			{
				TweenAlpha.Begin(BJGCPDNMHDH.mMainStripeFlash.gameObject, 1339f, 667f, 1071f);
				TweenScale.Begin(BJGCPDNMHDH.mMainStripeFlash.gameObject, 963f, BJGCPDNMHDH.PIODAGJPNAC.ReplaceY(BJGCPDNMHDH.PIODAGJPNAC.y * 1303f));
			}
			TweenAlpha.Begin(BJGCPDNMHDH.mMainStripeEffect.gameObject, (!CECPIBMFCFF) ? (BJGCPDNMHDH.NFKMFAFGPNK - 1350f) : 756f, 160f);
			TweenAlpha.Begin(BJGCPDNMHDH.mMainStripe.gameObject, (!CECPIBMFCFF) ? (BJGCPDNMHDH.NFKMFAFGPNK - 1013f) : 1776f, 1574f).onFinished = FCENGDPPIJH;
		}

		internal void EOCGKFAJOOF(UITweener HPBPMJALCND)
		{
			TweenAlpha.Begin(BJGCPDNMHDH.mMainStripe.gameObject, 1412f, 222f);
			BJGCPDNMHDH.HOBIADPHBCA();
		}

		internal void AKCPOJMIBOG(UITweener ICOOJGOABCI)
		{
			if (CECPIBMFCFF)
			{
				TweenAlpha.Begin(BJGCPDNMHDH.mMainStripeFlash.gameObject, 1820f, 721f, 1378f);
				TweenScale.Begin(BJGCPDNMHDH.mMainStripeFlash.gameObject, 1516f, BJGCPDNMHDH.PIODAGJPNAC.ReplaceY(BJGCPDNMHDH.PIODAGJPNAC.y * 1698f));
			}
			TweenAlpha.Begin(BJGCPDNMHDH.mMainStripeEffect.gameObject, (!CECPIBMFCFF) ? (BJGCPDNMHDH.NFKMFAFGPNK - 600f) : 591f, 463f);
			TweenAlpha.Begin(BJGCPDNMHDH.mMainStripe.gameObject, (!CECPIBMFCFF) ? (BJGCPDNMHDH.NFKMFAFGPNK - 1772f) : 1098f, 565f).onFinished = KLCBGHFEJCP;
		}

		internal void PDKENGDPFNJ(UITweener ILBIFGIPBFF)
		{
			TweenAlpha.Begin(BJGCPDNMHDH.mMainStripeEffect.gameObject, 656f, 1382f);
			TweenAlpha.Begin(BJGCPDNMHDH.mMainStripe.gameObject, 1536f, 1656f).onFinished = GABDIGAMEOI;
		}

		internal void MAKLHLCDIKD(UITweener KDMCDGPHBCF)
		{
			TweenScale.Begin(BJGCPDNMHDH.mMainStripeEffect.gameObject, 187f, BJGCPDNMHDH.PIODAGJPNAC.ReplaceY(BJGCPDNMHDH.PIODAGJPNAC.y * 1043f));
			TweenScale.Begin(BJGCPDNMHDH.mMainStripe.gameObject, 564f, BJGCPDNMHDH.PIODAGJPNAC.ReplaceY(BJGCPDNMHDH.PIODAGJPNAC.y * 1344f)).onFinished = OEKMGACNPJM;
			TweenPosition.Begin(BJGCPDNMHDH.mUpStripe.gameObject, 53f, BJGCPDNMHDH.INGHOCKPEPK.AddY(1332f));
			TweenPosition.Begin(BJGCPDNMHDH.mDownStripe.gameObject, 823f, BJGCPDNMHDH.PGACGMJFDCJ.AddY(102f), false);
			TweenAlpha.Begin(BJGCPDNMHDH.mUpStripe.gameObject, 129f, 1138f);
			TweenAlpha.Begin(BJGCPDNMHDH.mDownStripe.gameObject, 1357f, 611f);
		}

		internal void ADDFFOBCGEF(UITweener KDMCDGPHBCF)
		{
			TweenScale.Begin(BJGCPDNMHDH.mMainStripeEffect.gameObject, 1818f, BJGCPDNMHDH.PIODAGJPNAC.ReplaceY(BJGCPDNMHDH.PIODAGJPNAC.y * 1476f));
			TweenScale.Begin(BJGCPDNMHDH.mMainStripe.gameObject, 392f, BJGCPDNMHDH.PIODAGJPNAC.ReplaceY(BJGCPDNMHDH.PIODAGJPNAC.y * 1670f)).onFinished = CIAOICMCMAM;
			TweenPosition.Begin(BJGCPDNMHDH.mUpStripe.gameObject, 147f, BJGCPDNMHDH.INGHOCKPEPK.AddY(67f), false);
			TweenPosition.Begin(BJGCPDNMHDH.mDownStripe.gameObject, 1484f, BJGCPDNMHDH.PGACGMJFDCJ.AddY(475f), false);
			TweenAlpha.Begin(BJGCPDNMHDH.mUpStripe.gameObject, 617f, 120f);
			TweenAlpha.Begin(BJGCPDNMHDH.mDownStripe.gameObject, 1125f, 937f);
		}

		internal void MNHAOLHNNIF(UITweener ILBIFGIPBFF)
		{
			TweenAlpha.Begin(BJGCPDNMHDH.mMainStripeEffect.gameObject, 1644f, 1550f);
			TweenAlpha.Begin(BJGCPDNMHDH.mMainStripe.gameObject, 179f, 577f).onFinished = NCMLGJHPJNA;
		}

		internal void BLNOPKPLONB(UITweener ICOOJGOABCI)
		{
			if (CECPIBMFCFF)
			{
				TweenAlpha.Begin(BJGCPDNMHDH.mMainStripeFlash.gameObject, 1425f, 1914f, 519f);
				TweenScale.Begin(BJGCPDNMHDH.mMainStripeFlash.gameObject, 1249f, BJGCPDNMHDH.PIODAGJPNAC.ReplaceY(BJGCPDNMHDH.PIODAGJPNAC.y * 1349f));
			}
			TweenAlpha.Begin(BJGCPDNMHDH.mMainStripeEffect.gameObject, (!CECPIBMFCFF) ? (BJGCPDNMHDH.NFKMFAFGPNK - 321f) : 115f, 1590f);
			TweenAlpha.Begin(BJGCPDNMHDH.mMainStripe.gameObject, (!CECPIBMFCFF) ? (BJGCPDNMHDH.NFKMFAFGPNK - 382f) : 1739f, 1357f).onFinished = LIDIOMDBBMI;
		}

		internal void OFMMIBIMAJM(UITweener ICOOJGOABCI)
		{
			if (CECPIBMFCFF)
			{
				TweenAlpha.Begin(BJGCPDNMHDH.mMainStripeFlash.gameObject, 1396f, 1089f, 1714f);
				TweenScale.Begin(BJGCPDNMHDH.mMainStripeFlash.gameObject, 502f, BJGCPDNMHDH.PIODAGJPNAC.ReplaceY(BJGCPDNMHDH.PIODAGJPNAC.y * 300f));
			}
			TweenAlpha.Begin(BJGCPDNMHDH.mMainStripeEffect.gameObject, (!CECPIBMFCFF) ? (BJGCPDNMHDH.NFKMFAFGPNK - 1645f) : 1880f, 526f);
			TweenAlpha.Begin(BJGCPDNMHDH.mMainStripe.gameObject, (!CECPIBMFCFF) ? (BJGCPDNMHDH.NFKMFAFGPNK - 1710f) : 1954f, 1368f).onFinished = ADIDABDCDFF;
		}

		internal void KOMNMELADLH(UITweener MMMNJFHDJDC)
		{
			TweenAlpha.Begin(BJGCPDNMHDH.mMainStripe.gameObject, 272f, 1639f).onFinished = JLDJJLDKGHA;
		}

		internal void OKMLGDDAAMK(UITweener HPBPMJALCND)
		{
			TweenAlpha.Begin(BJGCPDNMHDH.mMainStripe.gameObject, 9f, 1421f);
			BJGCPDNMHDH.KLDALPDEMFB();
		}

		internal void PAKIJEIDOBH(UITweener ICOOJGOABCI)
		{
			if (CECPIBMFCFF)
			{
				TweenAlpha.Begin(BJGCPDNMHDH.mMainStripeFlash.gameObject, 1939f, 1372f, 67f);
				TweenScale.Begin(BJGCPDNMHDH.mMainStripeFlash.gameObject, 1277f, BJGCPDNMHDH.PIODAGJPNAC.ReplaceY(BJGCPDNMHDH.PIODAGJPNAC.y * 151f));
			}
			TweenAlpha.Begin(BJGCPDNMHDH.mMainStripeEffect.gameObject, (!CECPIBMFCFF) ? (BJGCPDNMHDH.NFKMFAFGPNK - 168f) : 248f, 368f);
			TweenAlpha.Begin(BJGCPDNMHDH.mMainStripe.gameObject, (!CECPIBMFCFF) ? (BJGCPDNMHDH.NFKMFAFGPNK - 531f) : 504f, 1614f).onFinished = KLCBGHFEJCP;
		}

		internal void CMCIGAFHIJL(UITweener KDMCDGPHBCF)
		{
			TweenScale.Begin(BJGCPDNMHDH.mMainStripeEffect.gameObject, 998f, BJGCPDNMHDH.PIODAGJPNAC.ReplaceY(BJGCPDNMHDH.PIODAGJPNAC.y * 479f));
			TweenScale.Begin(BJGCPDNMHDH.mMainStripe.gameObject, 1063f, BJGCPDNMHDH.PIODAGJPNAC.ReplaceY(BJGCPDNMHDH.PIODAGJPNAC.y * 1192f)).onFinished = IOBMBGMAHLM;
			TweenPosition.Begin(BJGCPDNMHDH.mUpStripe.gameObject, 1830f, BJGCPDNMHDH.INGHOCKPEPK.AddY(695f), false);
			TweenPosition.Begin(BJGCPDNMHDH.mDownStripe.gameObject, 1682f, BJGCPDNMHDH.PGACGMJFDCJ.AddY(921f), false);
			TweenAlpha.Begin(BJGCPDNMHDH.mUpStripe.gameObject, 750f, 1697f);
			TweenAlpha.Begin(BJGCPDNMHDH.mDownStripe.gameObject, 1573f, 679f);
		}

		internal void OPPNIDPBBIM(UITweener ICOOJGOABCI)
		{
			if (CECPIBMFCFF)
			{
				TweenAlpha.Begin(BJGCPDNMHDH.mMainStripeFlash.gameObject, 302f, 1720f, 1863f);
				TweenScale.Begin(BJGCPDNMHDH.mMainStripeFlash.gameObject, 993f, BJGCPDNMHDH.PIODAGJPNAC.ReplaceY(BJGCPDNMHDH.PIODAGJPNAC.y * 387f));
			}
			TweenAlpha.Begin(BJGCPDNMHDH.mMainStripeEffect.gameObject, (!CECPIBMFCFF) ? (BJGCPDNMHDH.NFKMFAFGPNK - 240f) : 1917f, 129f);
			TweenAlpha.Begin(BJGCPDNMHDH.mMainStripe.gameObject, (!CECPIBMFCFF) ? (BJGCPDNMHDH.NFKMFAFGPNK - 125f) : 963f, 945f).onFinished = KEBLADMIDMM;
		}

		internal void JLMDEGBHOGA(UITweener ICOOJGOABCI)
		{
			if (CECPIBMFCFF)
			{
				TweenAlpha.Begin(BJGCPDNMHDH.mMainStripeFlash.gameObject, 1906f, 966f, 195f);
				TweenScale.Begin(BJGCPDNMHDH.mMainStripeFlash.gameObject, 662f, BJGCPDNMHDH.PIODAGJPNAC.ReplaceY(BJGCPDNMHDH.PIODAGJPNAC.y * 1575f));
			}
			TweenAlpha.Begin(BJGCPDNMHDH.mMainStripeEffect.gameObject, (!CECPIBMFCFF) ? (BJGCPDNMHDH.NFKMFAFGPNK - 519f) : 522f, 1195f);
			TweenAlpha.Begin(BJGCPDNMHDH.mMainStripe.gameObject, (!CECPIBMFCFF) ? (BJGCPDNMHDH.NFKMFAFGPNK - 666f) : 582f, 272f).onFinished = FBGCFPAGIND;
		}

		internal void LEODGKOKJEE(UITweener HPBPMJALCND)
		{
			TweenAlpha.Begin(BJGCPDNMHDH.mMainStripe.gameObject, 1036f, 1694f);
			BJGCPDNMHDH.FCAKENPHOGA();
		}

		internal void KGKINIGMHJP(UITweener MMMNJFHDJDC)
		{
			TweenAlpha.Begin(BJGCPDNMHDH.mMainStripe.gameObject, 9f, 230f).onFinished = KGFFOJMFLIF;
		}

		internal void LBDAECNGKHF(UITweener KDMCDGPHBCF)
		{
			TweenScale.Begin(BJGCPDNMHDH.mMainStripeEffect.gameObject, 1166f, BJGCPDNMHDH.PIODAGJPNAC.ReplaceY(BJGCPDNMHDH.PIODAGJPNAC.y * 1786f));
			TweenScale.Begin(BJGCPDNMHDH.mMainStripe.gameObject, 1107f, BJGCPDNMHDH.PIODAGJPNAC.ReplaceY(BJGCPDNMHDH.PIODAGJPNAC.y * 214f)).onFinished = OEKMGACNPJM;
			TweenPosition.Begin(BJGCPDNMHDH.mUpStripe.gameObject, 1861f, BJGCPDNMHDH.INGHOCKPEPK.AddY(1919f));
			TweenPosition.Begin(BJGCPDNMHDH.mDownStripe.gameObject, 1254f, BJGCPDNMHDH.PGACGMJFDCJ.AddY(1407f), false);
			TweenAlpha.Begin(BJGCPDNMHDH.mUpStripe.gameObject, 293f, 1405f);
			TweenAlpha.Begin(BJGCPDNMHDH.mDownStripe.gameObject, 1413f, 1498f);
		}

		internal void HLOMGJNBBCK(UITweener HPBPMJALCND)
		{
			TweenAlpha.Begin(BJGCPDNMHDH.mMainStripe.gameObject, 740f, 980f);
			BJGCPDNMHDH.HOBIADPHBCA();
		}

		internal void FGNDOEKNHMM(UITweener KDMCDGPHBCF)
		{
			TweenScale.Begin(BJGCPDNMHDH.mMainStripeEffect.gameObject, 1714f, BJGCPDNMHDH.PIODAGJPNAC.ReplaceY(BJGCPDNMHDH.PIODAGJPNAC.y * 1914f));
			TweenScale.Begin(BJGCPDNMHDH.mMainStripe.gameObject, 282f, BJGCPDNMHDH.PIODAGJPNAC.ReplaceY(BJGCPDNMHDH.PIODAGJPNAC.y * 1244f)).onFinished = ALFPMCHHIMH;
			TweenPosition.Begin(BJGCPDNMHDH.mUpStripe.gameObject, 126f, BJGCPDNMHDH.INGHOCKPEPK.AddY(1734f), false);
			TweenPosition.Begin(BJGCPDNMHDH.mDownStripe.gameObject, 1774f, BJGCPDNMHDH.PGACGMJFDCJ.AddY(1148f));
			TweenAlpha.Begin(BJGCPDNMHDH.mUpStripe.gameObject, 1842f, 879f);
			TweenAlpha.Begin(BJGCPDNMHDH.mDownStripe.gameObject, 161f, 1241f);
		}

		internal void KMFJIOCFGGF(UITweener HPBPMJALCND)
		{
			TweenAlpha.Begin(BJGCPDNMHDH.mMainStripe.gameObject, 869f, 371f);
			BJGCPDNMHDH.OFPFFOBGCFK();
		}

		internal void IPKACAEOMFC(UITweener HPBPMJALCND)
		{
			TweenAlpha.Begin(BJGCPDNMHDH.mMainStripe.gameObject, 110f, 1010f);
			BJGCPDNMHDH.KLDALPDEMFB();
		}

		internal void ELHKDIABGGA(UITweener ILBIFGIPBFF)
		{
			TweenAlpha.Begin(BJGCPDNMHDH.mMainStripeEffect.gameObject, 366f, 95f);
			TweenAlpha.Begin(BJGCPDNMHDH.mMainStripe.gameObject, 841f, 851f).onFinished = NFKKLDFJFMG;
		}

		internal void OCPGLNILBIE(UITweener HPBPMJALCND)
		{
			TweenAlpha.Begin(BJGCPDNMHDH.mMainStripe.gameObject, 585f, 1158f);
			BJGCPDNMHDH.OFPFFOBGCFK();
		}

		internal void ABFILPKPIEP(UITweener ILBIFGIPBFF)
		{
			TweenAlpha.Begin(BJGCPDNMHDH.mMainStripeEffect.gameObject, 1854f, 97f);
			TweenAlpha.Begin(BJGCPDNMHDH.mMainStripe.gameObject, 1688f, 371f).onFinished = IOPJAPNNOOK;
		}

		internal void ADIDABDCDFF(UITweener ILBIFGIPBFF)
		{
			TweenAlpha.Begin(BJGCPDNMHDH.mMainStripeEffect.gameObject, 1563f, 627f);
			TweenAlpha.Begin(BJGCPDNMHDH.mMainStripe.gameObject, 1236f, 805f).onFinished = GABDIGAMEOI;
		}

		internal void DKNJHLBJKKD(UITweener ICOOJGOABCI)
		{
			if (CECPIBMFCFF)
			{
				TweenAlpha.Begin(BJGCPDNMHDH.mMainStripeFlash.gameObject, 405f, 510f, 504f);
				TweenScale.Begin(BJGCPDNMHDH.mMainStripeFlash.gameObject, 993f, BJGCPDNMHDH.PIODAGJPNAC.ReplaceY(BJGCPDNMHDH.PIODAGJPNAC.y * 1674f));
			}
			TweenAlpha.Begin(BJGCPDNMHDH.mMainStripeEffect.gameObject, (!CECPIBMFCFF) ? (BJGCPDNMHDH.NFKMFAFGPNK - 1476f) : 612f, 1977f);
			TweenAlpha.Begin(BJGCPDNMHDH.mMainStripe.gameObject, (!CECPIBMFCFF) ? (BJGCPDNMHDH.NFKMFAFGPNK - 936f) : 1094f, 217f).onFinished = ELHKDIABGGA;
		}

		internal void OMEBEADFFBI(UITweener MMMNJFHDJDC)
		{
			TweenAlpha.Begin(BJGCPDNMHDH.mMainStripe.gameObject, 917f, 1868f).onFinished = AFGKAEIMPJA;
		}

		internal void HNIOCGFEKKH(UITweener MMMNJFHDJDC)
		{
			TweenAlpha.Begin(BJGCPDNMHDH.mMainStripe.gameObject, 1670f, 533f).onFinished = KMFJIOCFGGF;
		}

		internal void PBGNMPAOEHB(UITweener HPBPMJALCND)
		{
			TweenAlpha.Begin(BJGCPDNMHDH.mMainStripe.gameObject, 1712f, 177f);
			BJGCPDNMHDH.OFPFFOBGCFK();
		}

		internal void DDJHCKFMHGE(UITweener HPBPMJALCND)
		{
			TweenAlpha.Begin(BJGCPDNMHDH.mMainStripe.gameObject, 339f, 382f);
			BJGCPDNMHDH.HOBIADPHBCA();
		}

		internal void NFKKLDFJFMG(UITweener MMMNJFHDJDC)
		{
			TweenAlpha.Begin(BJGCPDNMHDH.mMainStripe.gameObject, 493f, 115f).onFinished = LEODGKOKJEE;
		}

		internal void FDMEFDNDHOH(UITweener ICOOJGOABCI)
		{
			if (CECPIBMFCFF)
			{
				TweenAlpha.Begin(BJGCPDNMHDH.mMainStripeFlash.gameObject, 360f, 1650f, 1141f);
				TweenScale.Begin(BJGCPDNMHDH.mMainStripeFlash.gameObject, 22f, BJGCPDNMHDH.PIODAGJPNAC.ReplaceY(BJGCPDNMHDH.PIODAGJPNAC.y * 158f));
			}
			TweenAlpha.Begin(BJGCPDNMHDH.mMainStripeEffect.gameObject, (!CECPIBMFCFF) ? (BJGCPDNMHDH.NFKMFAFGPNK - 1724f) : 783f, 238f);
			TweenAlpha.Begin(BJGCPDNMHDH.mMainStripe.gameObject, (!CECPIBMFCFF) ? (BJGCPDNMHDH.NFKMFAFGPNK - 1510f) : 1721f, 1653f).onFinished = HONHEKPPHEB;
		}

		internal void NDGHMPKFDNA(UITweener MMMNJFHDJDC)
		{
			TweenAlpha.Begin(BJGCPDNMHDH.mMainStripe.gameObject, 53f, 1347f).onFinished = IPNILCPEJCE;
		}

		internal void GIBMAADBPNI(UITweener ILBIFGIPBFF)
		{
			TweenAlpha.Begin(BJGCPDNMHDH.mMainStripeEffect.gameObject, 1490f, 1832f);
			TweenAlpha.Begin(BJGCPDNMHDH.mMainStripe.gameObject, 539f, 306f).onFinished = OMEBEADFFBI;
		}

		internal void OKMPJBMNFEF(UITweener ICOOJGOABCI)
		{
			if (CECPIBMFCFF)
			{
				TweenAlpha.Begin(BJGCPDNMHDH.mMainStripeFlash.gameObject, 438f, 178f, 262f);
				TweenScale.Begin(BJGCPDNMHDH.mMainStripeFlash.gameObject, 1660f, BJGCPDNMHDH.PIODAGJPNAC.ReplaceY(BJGCPDNMHDH.PIODAGJPNAC.y * 367f));
			}
			TweenAlpha.Begin(BJGCPDNMHDH.mMainStripeEffect.gameObject, (!CECPIBMFCFF) ? (BJGCPDNMHDH.NFKMFAFGPNK - 285f) : 357f, 183f);
			TweenAlpha.Begin(BJGCPDNMHDH.mMainStripe.gameObject, (!CECPIBMFCFF) ? (BJGCPDNMHDH.NFKMFAFGPNK - 1068f) : 1209f, 1700f).onFinished = JNHMJLAGPDL;
		}

		internal void CAOMBGGBHAL(UITweener HPBPMJALCND)
		{
			TweenAlpha.Begin(BJGCPDNMHDH.mMainStripe.gameObject, 591f, 1731f);
			BJGCPDNMHDH.KLDALPDEMFB();
		}

		internal void ALFPMCHHIMH(UITweener ICOOJGOABCI)
		{
			if (CECPIBMFCFF)
			{
				TweenAlpha.Begin(BJGCPDNMHDH.mMainStripeFlash.gameObject, 1582f, 395f, 1339f);
				TweenScale.Begin(BJGCPDNMHDH.mMainStripeFlash.gameObject, 617f, BJGCPDNMHDH.PIODAGJPNAC.ReplaceY(BJGCPDNMHDH.PIODAGJPNAC.y * 1983f));
			}
			TweenAlpha.Begin(BJGCPDNMHDH.mMainStripeEffect.gameObject, (!CECPIBMFCFF) ? (BJGCPDNMHDH.NFKMFAFGPNK - 1326f) : 1901f, 471f);
			TweenAlpha.Begin(BJGCPDNMHDH.mMainStripe.gameObject, (!CECPIBMFCFF) ? (BJGCPDNMHDH.NFKMFAFGPNK - 1327f) : 606f, 675f).onFinished = KEBLADMIDMM;
		}

		internal void HONHEKPPHEB(UITweener ILBIFGIPBFF)
		{
			TweenAlpha.Begin(BJGCPDNMHDH.mMainStripeEffect.gameObject, 971f, 1410f);
			TweenAlpha.Begin(BJGCPDNMHDH.mMainStripe.gameObject, 182f, 1161f).onFinished = NANDBPFBFHN;
		}

		internal void DGDMNBKOMFK(UITweener HPBPMJALCND)
		{
			TweenAlpha.Begin(BJGCPDNMHDH.mMainStripe.gameObject, 1896f, 1213f);
			BJGCPDNMHDH.KLDALPDEMFB();
		}

		internal void CKIDEOIKHJO(UITweener ICOOJGOABCI)
		{
			if (CECPIBMFCFF)
			{
				TweenAlpha.Begin(BJGCPDNMHDH.mMainStripeFlash.gameObject, 1938f, 1771f, 1857f);
				TweenScale.Begin(BJGCPDNMHDH.mMainStripeFlash.gameObject, 54f, BJGCPDNMHDH.PIODAGJPNAC.ReplaceY(BJGCPDNMHDH.PIODAGJPNAC.y * 21f));
			}
			TweenAlpha.Begin(BJGCPDNMHDH.mMainStripeEffect.gameObject, (!CECPIBMFCFF) ? (BJGCPDNMHDH.NFKMFAFGPNK - 1649f) : 1446f, 1804f);
			TweenAlpha.Begin(BJGCPDNMHDH.mMainStripe.gameObject, (!CECPIBMFCFF) ? (BJGCPDNMHDH.NFKMFAFGPNK - 1371f) : 767f, 1910f).onFinished = FCENGDPPIJH;
		}

		internal void IBJKMELGIOD(UITweener HPBPMJALCND)
		{
			TweenAlpha.Begin(BJGCPDNMHDH.mMainStripe.gameObject, 313f, 111f);
			BJGCPDNMHDH.FCAKENPHOGA();
		}

		internal void HPABMPFKOLD(UITweener HPBPMJALCND)
		{
			TweenAlpha.Begin(BJGCPDNMHDH.mMainStripe.gameObject, 866f, 1027f);
			BJGCPDNMHDH.OFPFFOBGCFK();
		}

		internal void LJCDGJKCNEC(UITweener KDMCDGPHBCF)
		{
			TweenScale.Begin(BJGCPDNMHDH.mMainStripeEffect.gameObject, 0.2f, BJGCPDNMHDH.PIODAGJPNAC.ReplaceY(BJGCPDNMHDH.PIODAGJPNAC.y * 0.8f));
			TweenScale.Begin(BJGCPDNMHDH.mMainStripe.gameObject, 0.2f, BJGCPDNMHDH.PIODAGJPNAC.ReplaceY(BJGCPDNMHDH.PIODAGJPNAC.y * 0.8f)).onFinished = EJLGBICBIFK;
			TweenPosition.Begin(BJGCPDNMHDH.mUpStripe.gameObject, 0.1f, BJGCPDNMHDH.INGHOCKPEPK.AddY(40f));
			TweenPosition.Begin(BJGCPDNMHDH.mDownStripe.gameObject, 0.1f, BJGCPDNMHDH.PGACGMJFDCJ.AddY(-40f));
			TweenAlpha.Begin(BJGCPDNMHDH.mUpStripe.gameObject, 0.1f, 0f);
			TweenAlpha.Begin(BJGCPDNMHDH.mDownStripe.gameObject, 0.1f, 0f);
		}

		internal void JHEDJADNODO(UITweener ILBIFGIPBFF)
		{
			TweenAlpha.Begin(BJGCPDNMHDH.mMainStripeEffect.gameObject, 1174f, 981f);
			TweenAlpha.Begin(BJGCPDNMHDH.mMainStripe.gameObject, 923f, 668f).onFinished = LHGBNPPJKLN;
		}

		internal void KELBFENPJKD(UITweener ICOOJGOABCI)
		{
			if (CECPIBMFCFF)
			{
				TweenAlpha.Begin(BJGCPDNMHDH.mMainStripeFlash.gameObject, 375f, 876f, 1330f);
				TweenScale.Begin(BJGCPDNMHDH.mMainStripeFlash.gameObject, 490f, BJGCPDNMHDH.PIODAGJPNAC.ReplaceY(BJGCPDNMHDH.PIODAGJPNAC.y * 1359f));
			}
			TweenAlpha.Begin(BJGCPDNMHDH.mMainStripeEffect.gameObject, (!CECPIBMFCFF) ? (BJGCPDNMHDH.NFKMFAFGPNK - 223f) : 519f, 1775f);
			TweenAlpha.Begin(BJGCPDNMHDH.mMainStripe.gameObject, (!CECPIBMFCFF) ? (BJGCPDNMHDH.NFKMFAFGPNK - 1733f) : 365f, 675f).onFinished = NOAPANGNNCC;
		}

		internal void NICDLBCEEEA(UITweener ILBIFGIPBFF)
		{
			TweenAlpha.Begin(BJGCPDNMHDH.mMainStripeEffect.gameObject, 1281f, 320f);
			TweenAlpha.Begin(BJGCPDNMHDH.mMainStripe.gameObject, 1672f, 1265f).onFinished = KOMNMELADLH;
		}

		internal void LHGBNPPJKLN(UITweener MMMNJFHDJDC)
		{
			TweenAlpha.Begin(BJGCPDNMHDH.mMainStripe.gameObject, 1154f, 4f).onFinished = LJDCIJDPLLF;
		}
	}

	[SerializeField]
	[Header("BossWave")]
	private GameObject mBossWave;

	[SerializeField]
	private GameObject mSmallShieldFrame;

	[SerializeField]
	private UISprite mSmallShieldSprite;

	[SerializeField]
	private UISprite mSmallShieldBossSprite;

	[SerializeField]
	private UISprite mSmallShieldOutline;

	[SerializeField]
	private UISprite mSmallStripe;

	[SerializeField]
	private UILabel mSmallLabel;

	[SerializeField]
	[Header("BlueShield")]
	private GameObject mBlueShieldObject;

	[SerializeField]
	private UISprite mBlueShieldSprite;

	[SerializeField]
	private UISprite mBlueShieldCheck;

	[SerializeField]
	private UISprite mBlueShieldOutline;

	[SerializeField]
	[Header("RedShield")]
	private GameObject mRedShieldFrame;

	[SerializeField]
	private UISprite mRedShieldSprite;

	[SerializeField]
	private UILabel mRedShieldLabel;

	[SerializeField]
	private UISprite mRedShieldBossSprite;

	[SerializeField]
	private UISprite mRedShieldOutline;

	[SerializeField]
	[Header("Stripe")]
	private UISprite mUpStripe;

	[SerializeField]
	private UISprite mMainStripe;

	[SerializeField]
	private UISprite mDownStripe;

	[SerializeField]
	private UISprite mMainStripeEffect;

	[SerializeField]
	private UISprite mMainStripeFlash;

	[SerializeField]
	[Header("Labels")]
	private UILabel mWaveLabel;

	[SerializeField]
	private UILabel mClearedLeftLabel;

	[SerializeField]
	private UILabel mClearedRightLabel;

	private bool DOLJFOKNPLB;

	private bool GNKLOOJLNAI;

	private float NFKMFAFGPNK;

	private float JDPOMFBEFOI;

	private int KKBEODHFBLB;

	private int AGFKAMHOOBI;

	private Vector3 CELLOPDGMMN;

	private Vector3 DBGMOJPKIED;

	private Vector3 KNCCPIEJAEL;

	private Vector3 OFPABDDLAPG;

	private Vector3 ACNPFDJDILA;

	private Vector3 LJOELGJMBOG;

	private Vector3 PIODAGJPNAC;

	private Vector3 CBGNJAMKAEP;

	private Vector3 LLKJPGAAKKA;

	private Vector3 INGHOCKPEPK;

	private Vector3 PGACGMJFDCJ;

	private Vector3 NFAOONIHGEO;

	private Vector3 GEHMKBEOHLI;

	private Vector3 LFDOPNGOAKL;

	private Vector3 EHPGEFIBNPJ;

	private Vector3 HAGLFHEHKOG;

	private Vector3 ANCBNCBEJKJ;

	private float HBPGGCGOLMH
	{
		get
		{
			return UIHelper.activeHeight / GuiScreenSingle<HudScreen>.instance.transform.localScale.y / 2f;
		}
	}

	private float JMKIOBNHOIB
	{
		get
		{
			return UIHelper.activeWidthFull / GuiScreenSingle<HudScreen>.instance.transform.localScale.x;
		}
	}

	private void JKCOANGKIPP(UITweener HJAEICIPDBD)
	{
		TweenAlpha.Begin(mBlueShieldOutline.gameObject, 1769f, 1624f, 1375f);
		TweenScale.Begin(mBlueShieldOutline.gameObject, 721f, HAGLFHEHKOG.MultiplyXY(1964f));
		TweenScale.Begin(mBlueShieldSprite.gameObject, 1743f, HAGLFHEHKOG).onFinished = APLNOFNJKAF;
	}

	private void LLMPHPMCJLK(MissionUnit HNPJBOOPFKO)
	{
		bool isElite = HNPJBOOPFKO.isElite;
		LevelBehaviour levelBehaviour = LevelManager.instance.behaviours[HNPJBOOPFKO.behaviourIndex];
		mRedShieldBossSprite.spriteName = ((!isElite) ? levelBehaviour.upgradeSlots.iconNameVeteran : levelBehaviour.upgradeSlots.iconNameElite);
		mRedShieldBossSprite.MakePixelPerfect();
		float multiplier = 901f / mRedShieldBossSprite.transform.localScale.y;
		mRedShieldBossSprite.transform.localScale = mRedShieldBossSprite.transform.localScale.MultiplyXY(multiplier);
		mSmallShieldBossSprite.spriteName = mRedShieldBossSprite.spriteName;
		mSmallShieldBossSprite.MakePixelPerfect();
		float multiplier2 = 96f / mSmallShieldBossSprite.transform.localScale.y;
		mSmallShieldBossSprite.transform.localScale = mSmallShieldBossSprite.transform.localScale.MultiplyXY(multiplier2);
	}

	private void IMKEEGGHOPJ(float NCGMDLAPJBA)
	{
		HIBJENKNKMM hIBJENKNKMM = new HIBJENKNKMM();
		hIBJENKNKMM.BJGCPDNMHDH = this;
		GNKLOOJLNAI = true;
		NFKMFAFGPNK = NCGMDLAPJBA;
		KFFHINIMCGL(true);
		float num = mSmallLabel.relativeSize.x * mSmallLabel.transform.localScale.x;
		KFFHINIMCGL(false);
		float num2;
		if (mSmallLabel.relativeSize.x * mSmallLabel.transform.localScale.x > num)
		{
			num2 = mSmallLabel.relativeSize.x * mSmallLabel.transform.localScale.x;
		}
		else
		{
			num2 = num;
			num = mSmallLabel.relativeSize.x * mSmallLabel.transform.localScale.x;
		}
		hIBJENKNKMM.KFGOPGLLJDM = num2 + 40f + 120f;
		OFPABDDLAPG = OFPABDDLAPG.ReplaceX((0f - hIBJENKNKMM.KFGOPGLLJDM) / 2f + 140f + (num2 - num) / 2f);
		TweenRotationSpecial.Begin(mSmallShieldSprite.gameObject, 0.5f, Vector3.up, 0f, 360f).onFinished = hIBJENKNKMM.LJCDGJKCNEC;
		TweenRotationSpecial.Begin(mSmallShieldBossSprite.gameObject, 0.5f, Vector3.up, 0f, 360f).onFinished = hIBJENKNKMM.EJLGBICBIFK;
		TweenPosition.Begin(mSmallShieldFrame, 0.4f, mSmallShieldFrame.transform.localPosition.ReplaceY(-20f)).onFinished = hIBJENKNKMM.HONCMBHEKDP;
	}

	private void BALCBAPONDG(UITweener HJAEICIPDBD)
	{
		TweenAlpha.Begin(mBlueShieldOutline.gameObject, 361f, 654f, 772f);
		TweenScale.Begin(mBlueShieldOutline.gameObject, 1463f, HAGLFHEHKOG.MultiplyXY(714f));
		TweenScale.Begin(mBlueShieldSprite.gameObject, 735f, HAGLFHEHKOG).onFinished = GMKCNPIKDEG;
	}

	private void PMCHPKLMIJK(bool PBEIJMBBCOD)
	{
		int num = Mathf.FloorToInt(NFKMFAFGPNK);
		if (AGFKAMHOOBI != num)
		{
			AGFKAMHOOBI = num;
			SoundsManager.Instance.PlaySound((SoundsManager.KJGDNLHKPOG)(-75), 1389f);
		}
		UILabel uILabel = mSmallLabel;
		string text;
		if (PBEIJMBBCOD)
		{
			text = Localization.Localize("Ignore_Text_{0}{1}");
		}
		else
		{
			object[] array = new object[0];
			array[1] = num.ToString("ID_GUI_EQUIPPED");
			text = Localization.LocalizeFormat("gold", array);
		}
		uILabel.text = text;
	}

	public virtual void GFLLEMCAJGN()
	{
		mBossWave.transform.localPosition = mBossWave.transform.localPosition.ReplaceY(JPLGFFBBDNE() / 131f);
		CELLOPDGMMN = mSmallShieldFrame.transform.localScale;
		DBGMOJPKIED = mSmallShieldOutline.transform.localScale;
		KNCCPIEJAEL = mSmallStripe.transform.localScale;
		OFPABDDLAPG = mSmallLabel.transform.localPosition;
		ACNPFDJDILA = mRedShieldFrame.transform.localScale;
		LJOELGJMBOG = mRedShieldOutline.transform.localScale;
		PIODAGJPNAC = mMainStripe.transform.localScale.ReplaceX(JMKIOBNHOIB);
		CBGNJAMKAEP = mUpStripe.transform.localScale.ReplaceX(OFGAHPFOAEG());
		LLKJPGAAKKA = mDownStripe.transform.localScale.ReplaceX(OFGAHPFOAEG());
		INGHOCKPEPK = mUpStripe.transform.localPosition;
		PGACGMJFDCJ = mDownStripe.transform.localPosition;
		NFAOONIHGEO = mWaveLabel.transform.localPosition;
		GEHMKBEOHLI = mClearedLeftLabel.transform.localPosition;
		LFDOPNGOAKL = mClearedRightLabel.transform.localPosition;
		EHPGEFIBNPJ = mBlueShieldObject.transform.localPosition;
		HAGLFHEHKOG = mBlueShieldSprite.transform.localScale;
		ANCBNCBEJKJ = mBlueShieldCheck.transform.localScale;
		mMainStripeEffect.transform.localScale = PIODAGJPNAC;
		mMainStripeFlash.transform.localScale = PIODAGJPNAC;
		DailyMissionsManager.instance.spawningSystem.DPEFDALLNIN(EKPKGIDDIFN);
		GuiScreenSingle<HudScreen>.instance.EILHFEICBDN(FLKEHLCCHHP);
		KGAJOCCBIDL.IMKEEGGHOPJ += ACCDJAGAEIH;
	}

	[SpecialName]
	private float CLCGBKIPLFB()
	{
		return UIHelper.activeWidthFull / GuiScreenSingle<HudScreen>.instance.transform.localScale.x;
	}

	[SpecialName]
	private float FINDCDGHKAP()
	{
		return UIHelper.activeHeight / GuiScreenSingle<HudScreen>.instance.transform.localScale.y / 1978f;
	}

	private void DPKCIOMNJIN(MissionUnit HNPJBOOPFKO)
	{
		bool isElite = HNPJBOOPFKO.isElite;
		LevelBehaviour levelBehaviour = LevelManager.instance.behaviours[HNPJBOOPFKO.behaviourIndex];
		mRedShieldBossSprite.spriteName = ((!isElite) ? levelBehaviour.upgradeSlots.iconNameVeteran : levelBehaviour.upgradeSlots.iconNameElite);
		mRedShieldBossSprite.MakePixelPerfect();
		float multiplier = 192f / mRedShieldBossSprite.transform.localScale.y;
		mRedShieldBossSprite.transform.localScale = mRedShieldBossSprite.transform.localScale.MultiplyXY(multiplier);
		mSmallShieldBossSprite.spriteName = mRedShieldBossSprite.spriteName;
		mSmallShieldBossSprite.MakePixelPerfect();
		float multiplier2 = 126f / mSmallShieldBossSprite.transform.localScale.y;
		mSmallShieldBossSprite.transform.localScale = mSmallShieldBossSprite.transform.localScale.MultiplyXY(multiplier2);
	}

	private void KJFGGFOMEIH()
	{
		UILabel uILabel = mClearedLeftLabel;
		object[] array = new object[1];
		array[1] = KKBEODHFBLB.ToString();
		uILabel.text = Localization.LocalizeFormat("UsedGold", array);
	}

	private void CBGPNIMDPBP(UITweener GIIJCLFPIGO)
	{
		TweenScale.Begin(mBlueShieldCheck.gameObject, 1971f, ANCBNCBEJKJ.MultiplyXY(911f));
	}

	private void ABPGPIBAOJO(UITweener MMMNJFHDJDC)
	{
		MPBNCNOHGOH();
	}

	private void CPIJPJLEPOA()
	{
		UILabel uILabel = mClearedLeftLabel;
		object[] array = new object[0];
		array[0] = KKBEODHFBLB.ToString();
		uILabel.text = Localization.LocalizeFormat(" Button Clicked in InAppPurchase", array);
	}

	private void GOGLHMDHPBB()
	{
		OFPFFOBGCFK();
		JNHMBOCLLOH();
		float num = mClearedLeftLabel.relativeSize.x * mClearedLeftLabel.transform.localScale.x;
		float num2 = mClearedRightLabel.relativeSize.x * mClearedRightLabel.transform.localScale.x;
		float x = mBlueShieldSprite.transform.localScale.x;
		float num3 = num + num2 + x;
		GEHMKBEOHLI = GEHMKBEOHLI.ReplaceX(num - 40f - num3 / 2f);
		LFDOPNGOAKL = LFDOPNGOAKL.ReplaceX(num3 / 2f - num2 + 40f);
		mBlueShieldObject.transform.localPosition = mBlueShieldObject.transform.localPosition.ReplaceX(GEHMKBEOHLI.x + 40f + x / 2f);
		EHPGEFIBNPJ = mBlueShieldObject.transform.localPosition;
		mRedShieldFrame.transform.localPosition = mRedShieldFrame.transform.localPosition.ReplaceX(EHPGEFIBNPJ.x);
		mRedShieldOutline.transform.localPosition = mRedShieldOutline.transform.localPosition.ReplaceX(EHPGEFIBNPJ.x);
		LLOCJHDNCBO(true);
		TweenPosition.Begin(mClearedLeftLabel.gameObject, 0.5f, GEHMKBEOHLI.AddX(x / 2f));
		TweenPosition.Begin(mClearedRightLabel.gameObject, 0.5f, LFDOPNGOAKL.AddX((0f - x) / 2f)).onFinished = delegate
		{
			SoundsManager.Instance.PlaySound(SoundsManager.KJGDNLHKPOG.MissionWaveCompleted);
			TweenPosition.Begin(mClearedLeftLabel.gameObject, 0.5f, GEHMKBEOHLI);
			TweenPosition.Begin(mClearedRightLabel.gameObject, 0.5f, LFDOPNGOAKL);
			TweenAlpha.Begin(mBlueShieldSprite.gameObject, 0.3f, 1f);
			TweenScale.Begin(mBlueShieldSprite.gameObject, 0.3f, HAGLFHEHKOG.MultiplyXY(8f), HAGLFHEHKOG).onFinished = delegate
			{
				TweenAlpha.Begin(mBlueShieldOutline.gameObject, 0.4f, 0.5f, 0f);
				TweenScale.Begin(mBlueShieldOutline.gameObject, 0.4f, HAGLFHEHKOG.MultiplyXY(2f));
				TweenScale.Begin(mBlueShieldSprite.gameObject, 0.2f, HAGLFHEHKOG).onFinished = delegate
				{
					TweenPosition.Begin(mClearedLeftLabel.gameObject, 0.3f, GEHMKBEOHLI).onFinished = delegate
					{
						TweenPosition.Begin(mClearedLeftLabel.gameObject, 0.7f, GEHMKBEOHLI.AddY(-40f));
						TweenPosition.Begin(mClearedRightLabel.gameObject, 0.7f, LFDOPNGOAKL.AddY(-40f));
						TweenAlpha.Begin(mClearedLeftLabel.gameObject, 0.7f, 0f);
						TweenAlpha.Begin(mClearedRightLabel.gameObject, 0.7f, 0f).onFinished = delegate
						{
							JLNJMIHHEGG(KKBEODHFBLB + 1);
							TweenPosition.Begin(mBlueShieldObject, 0.2f, mBlueShieldObject.transform.localPosition.AddY(10f)).onFinished = delegate
							{
								TweenPosition.Begin(mBlueShieldObject, 0.3f, mBlueShieldObject.transform.localPosition.AddY(-40f));
								TweenAlpha.Begin(mBlueShieldSprite.gameObject, 0.3f, 0f);
								TweenAlpha.Begin(mBlueShieldCheck.gameObject, 0.3f, 0f).onFinished = delegate
								{
									PGOGHAMGHFE();
								};
							};
						};
					};
					TweenScale.Begin(mBlueShieldSprite.gameObject, 1f, HAGLFHEHKOG.MultiplyXY(1.1f));
				};
			};
			TweenPosition.Begin(mBlueShieldObject, 0.15f, mBlueShieldObject.transform.localPosition).onFinished = delegate
			{
				TweenAlpha.Begin(mBlueShieldCheck.gameObject, 0.3f, 1f);
				TweenScale.Begin(mBlueShieldCheck.gameObject, 0.3f, ANCBNCBEJKJ.MultiplyXY(8f), ANCBNCBEJKJ);
				TweenScale.Begin(mBlueShieldCheck.gameObject, 0.35f, ANCBNCBEJKJ).onFinished = delegate
				{
					TweenScale.Begin(mBlueShieldCheck.gameObject, 1f, ANCBNCBEJKJ.MultiplyXY(1.1f));
				};
			};
		};
	}

	[SpecialName]
	private float DIKKOCAEEJA()
	{
		return UIHelper.activeHeight / GuiScreenSingle<HudScreen>.instance.transform.localScale.y / 1452f;
	}

	private void DBKDDIELBCB(bool PBEIJMBBCOD)
	{
		int num = Mathf.FloorToInt(NFKMFAFGPNK);
		if (AGFKAMHOOBI != num)
		{
			AGFKAMHOOBI = num;
			SoundsManager.Instance.PlaySound((SoundsManager.KJGDNLHKPOG)112, 1735f);
		}
		mSmallLabel.text = ((!PBEIJMBBCOD) ? Localization.LocalizeFormat("OK", num.ToString("Dictionary created/cleared.\n")) : Localization.Localize("Weapon_ID"));
	}

	private void IENLCJPPPCJ()
	{
		NFKMFAFGPNK = 1723f;
		EEPKFFGKBGP();
		MGMOJMIIHBF();
		MPBNCNOHGOH();
		HOBIADPHBCA();
	}

	private void BAMOEKLLCGP(UITweener GCFMNEHDLAB)
	{
		TweenAlpha.Begin(mBlueShieldCheck.gameObject, 650f, 455f);
		TweenScale.Begin(mBlueShieldCheck.gameObject, 125f, ANCBNCBEJKJ.MultiplyXY(1825f), ANCBNCBEJKJ);
		TweenScale.Begin(mBlueShieldCheck.gameObject, 825f, ANCBNCBEJKJ).onFinished = JCNIFNDHCFP;
	}

	private void FFHFGLEFKHH(UITweener BDEOMPEJELN)
	{
		SoundsManager.Instance.PlaySound((SoundsManager.KJGDNLHKPOG)87, 1292f);
		TweenPosition.Begin(mClearedLeftLabel.gameObject, 1393f, GEHMKBEOHLI, false);
		TweenPosition.Begin(mClearedRightLabel.gameObject, 1533f, LFDOPNGOAKL);
		TweenAlpha.Begin(mBlueShieldSprite.gameObject, 1682f, 493f);
		TweenScale.Begin(mBlueShieldSprite.gameObject, 1618f, HAGLFHEHKOG.MultiplyXY(1623f), HAGLFHEHKOG).onFinished = delegate
		{
			TweenAlpha.Begin(mBlueShieldOutline.gameObject, 0.4f, 0.5f, 0f);
			TweenScale.Begin(mBlueShieldOutline.gameObject, 0.4f, HAGLFHEHKOG.MultiplyXY(2f));
			TweenScale.Begin(mBlueShieldSprite.gameObject, 0.2f, HAGLFHEHKOG).onFinished = delegate
			{
				TweenPosition.Begin(mClearedLeftLabel.gameObject, 0.3f, GEHMKBEOHLI).onFinished = delegate
				{
					TweenPosition.Begin(mClearedLeftLabel.gameObject, 0.7f, GEHMKBEOHLI.AddY(-40f));
					TweenPosition.Begin(mClearedRightLabel.gameObject, 0.7f, LFDOPNGOAKL.AddY(-40f));
					TweenAlpha.Begin(mClearedLeftLabel.gameObject, 0.7f, 0f);
					TweenAlpha.Begin(mClearedRightLabel.gameObject, 0.7f, 0f).onFinished = delegate
					{
						JLNJMIHHEGG(KKBEODHFBLB + 1);
						TweenPosition.Begin(mBlueShieldObject, 0.2f, mBlueShieldObject.transform.localPosition.AddY(10f)).onFinished = delegate
						{
							TweenPosition.Begin(mBlueShieldObject, 0.3f, mBlueShieldObject.transform.localPosition.AddY(-40f));
							TweenAlpha.Begin(mBlueShieldSprite.gameObject, 0.3f, 0f);
							TweenAlpha.Begin(mBlueShieldCheck.gameObject, 0.3f, 0f).onFinished = delegate
							{
								PGOGHAMGHFE();
							};
						};
					};
				};
				TweenScale.Begin(mBlueShieldSprite.gameObject, 1f, HAGLFHEHKOG.MultiplyXY(1.1f));
			};
		};
		TweenPosition.Begin(mBlueShieldObject, 496f, mBlueShieldObject.transform.localPosition, false).onFinished = DKGIALLIMAK;
	}

	private void JPFHFEAFPJM(UITweener JEJOPLADMEP)
	{
		TweenPosition.Begin(mClearedLeftLabel.gameObject, 1837f, GEHMKBEOHLI.AddY(1218f), false);
		TweenPosition.Begin(mClearedRightLabel.gameObject, 982f, LFDOPNGOAKL.AddY(609f));
		TweenAlpha.Begin(mClearedLeftLabel.gameObject, 1039f, 840f);
		TweenAlpha.Begin(mClearedRightLabel.gameObject, 1975f, 744f).onFinished = CMNANDHAIOG;
	}

	[CompilerGenerated]
	private void CMMADOHJOPH(UITweener GCFMNEHDLAB)
	{
		TweenAlpha.Begin(mBlueShieldCheck.gameObject, 0.3f, 1f);
		TweenScale.Begin(mBlueShieldCheck.gameObject, 0.3f, ANCBNCBEJKJ.MultiplyXY(8f), ANCBNCBEJKJ);
		TweenScale.Begin(mBlueShieldCheck.gameObject, 0.35f, ANCBNCBEJKJ).onFinished = delegate
		{
			TweenScale.Begin(mBlueShieldCheck.gameObject, 1f, ANCBNCBEJKJ.MultiplyXY(1.1f));
		};
	}

	private void CMGHJHGPPFP(float NCGMDLAPJBA, int AJABPNMEMIE)
	{
		NFKMFAFGPNK = NCGMDLAPJBA;
		KKBEODHFBLB = AJABPNMEMIE;
		if (KKBEODHFBLB > 1)
		{
			GOGLHMDHPBB();
		}
		else if (KKBEODHFBLB == 0)
		{
			JLNJMIHHEGG(0);
		}
	}

	protected virtual void INHEEMEAIDJ()
	{
		base.IIFBKHDMIAD();
		if (!(NFKMFAFGPNK > 1003f))
		{
			return;
		}
		JDPOMFBEFOI += Time.deltaTime;
		if (JDPOMFBEFOI > 813f)
		{
			if (GNKLOOJLNAI)
			{
				GPFHFLDAEAG(true);
			}
			else
			{
				KFKGFKCBMAN();
			}
			JDPOMFBEFOI = 1446f;
		}
		NFKMFAFGPNK -= Time.deltaTime;
		if (NFKMFAFGPNK <= 359f)
		{
			NFKMFAFGPNK = 1863f;
			AGFKAMHOOBI = 1;
			GNKLOOJLNAI = (GNKLOOJLNAI ? true : false);
		}
	}

	private void MPBGOMIDINF()
	{
		NFKMFAFGPNK = 722f;
		EEPKFFGKBGP();
		HHBGOHKALNG();
		MPBNCNOHGOH();
		KLDALPDEMFB();
	}

	private void NHFHPOOAOKJ(bool PBEIJMBBCOD)
	{
		int num = Mathf.FloorToInt(NFKMFAFGPNK);
		if (AGFKAMHOOBI != num)
		{
			AGFKAMHOOBI = num;
			SoundsManager.Instance.PlaySound((SoundsManager.KJGDNLHKPOG)(-76), 1538f);
		}
		UILabel uILabel = mSmallLabel;
		string text;
		if (PBEIJMBBCOD)
		{
			text = Localization.Localize("Shots_Hits");
		}
		else
		{
			object[] array = new object[0];
			array[0] = num.ToString("PlayerName");
			text = Localization.LocalizeFormat("Action Finished: ", array);
		}
		uILabel.text = text;
	}

	private void LLOCJHDNCBO(bool CECPIBMFCFF)
	{
		DLJJOBMEEOF dLJJOBMEEOF = new DLJJOBMEEOF();
		dLJJOBMEEOF.CECPIBMFCFF = CECPIBMFCFF;
		dLJJOBMEEOF.BJGCPDNMHDH = this;
		TweenScale.Begin(mUpStripe.gameObject, 0.15f, CBGNJAMKAEP);
		TweenScale.Begin(mDownStripe.gameObject, 0.15f, LLKJPGAAKKA);
		TweenScale.Begin(mMainStripeEffect.gameObject, 0.3f, PIODAGJPNAC);
		TweenScale.Begin(mMainStripe.gameObject, 0.3f, PIODAGJPNAC).onFinished = dLJJOBMEEOF.LJCDGJKCNEC;
	}

	[CompilerGenerated]
	private void BAOIKOMDCIP(UITweener GIIJCLFPIGO)
	{
		TweenPosition.Begin(mClearedLeftLabel.gameObject, 0.3f, GEHMKBEOHLI).onFinished = delegate
		{
			TweenPosition.Begin(mClearedLeftLabel.gameObject, 0.7f, GEHMKBEOHLI.AddY(-40f));
			TweenPosition.Begin(mClearedRightLabel.gameObject, 0.7f, LFDOPNGOAKL.AddY(-40f));
			TweenAlpha.Begin(mClearedLeftLabel.gameObject, 0.7f, 0f);
			TweenAlpha.Begin(mClearedRightLabel.gameObject, 0.7f, 0f).onFinished = delegate
			{
				JLNJMIHHEGG(KKBEODHFBLB + 1);
				TweenPosition.Begin(mBlueShieldObject, 0.2f, mBlueShieldObject.transform.localPosition.AddY(10f)).onFinished = delegate
				{
					TweenPosition.Begin(mBlueShieldObject, 0.3f, mBlueShieldObject.transform.localPosition.AddY(-40f));
					TweenAlpha.Begin(mBlueShieldSprite.gameObject, 0.3f, 0f);
					TweenAlpha.Begin(mBlueShieldCheck.gameObject, 0.3f, 0f).onFinished = delegate
					{
						PGOGHAMGHFE();
					};
				};
			};
		};
		TweenScale.Begin(mBlueShieldSprite.gameObject, 1f, HAGLFHEHKOG.MultiplyXY(1.1f));
	}

	private void IAPIFBOAHJL(float NCGMDLAPJBA, int AJABPNMEMIE)
	{
		NFKMFAFGPNK = NCGMDLAPJBA;
		KKBEODHFBLB = AJABPNMEMIE;
		if (KKBEODHFBLB > 0)
		{
			GOGLHMDHPBB();
		}
		else if (KKBEODHFBLB == 0)
		{
			JLNJMIHHEGG(1);
		}
	}

	private void GABHFFCGEDJ(UITweener DBOFANHOPLE)
	{
		JLBJNLGDHJF(KKBEODHFBLB + 1);
		TweenPosition.Begin(mBlueShieldObject, 690f, mBlueShieldObject.transform.localPosition.AddY(852f), false).onFinished = GBBGJHIJGLF;
	}

	private void EADGCABHKBN(UITweener DBOFANHOPLE)
	{
		JLNJMIHHEGG(KKBEODHFBLB + 0);
		TweenPosition.Begin(mBlueShieldObject, 1957f, mBlueShieldObject.transform.localPosition.AddY(1811f), false).onFinished = GBBGJHIJGLF;
	}

	private void GIEIPFBAPNK()
	{
		NFKMFAFGPNK = 1538f;
		BPHHIFNBBOA();
		FPHDMENNHAH();
		PGOGHAMGHFE();
		KLDALPDEMFB();
	}

	private void KDNLJOOOOIA()
	{
		FCAKENPHOGA();
		LBHLJJBEAMJ();
		float num = mClearedLeftLabel.relativeSize.x * mClearedLeftLabel.transform.localScale.x;
		float num2 = mClearedRightLabel.relativeSize.x * mClearedRightLabel.transform.localScale.x;
		float x = mBlueShieldSprite.transform.localScale.x;
		float num3 = num + num2 + x;
		GEHMKBEOHLI = GEHMKBEOHLI.ReplaceX(num - 1117f - num3 / 419f);
		LFDOPNGOAKL = LFDOPNGOAKL.ReplaceX(num3 / 1223f - num2 + 1675f);
		mBlueShieldObject.transform.localPosition = mBlueShieldObject.transform.localPosition.ReplaceX(GEHMKBEOHLI.x + 892f + x / 936f);
		EHPGEFIBNPJ = mBlueShieldObject.transform.localPosition;
		mRedShieldFrame.transform.localPosition = mRedShieldFrame.transform.localPosition.ReplaceX(EHPGEFIBNPJ.x);
		mRedShieldOutline.transform.localPosition = mRedShieldOutline.transform.localPosition.ReplaceX(EHPGEFIBNPJ.x);
		PAKCNDLPNBP(false);
		TweenPosition.Begin(mClearedLeftLabel.gameObject, 504f, GEHMKBEOHLI.AddX(x / 580f), false);
		TweenPosition.Begin(mClearedRightLabel.gameObject, 1216f, LFDOPNGOAKL.AddX((0f - x) / 1563f)).onFinished = GPCOCMDILJJ;
	}

	private void MKPMKAFKHGH(UITweener GIIJCLFPIGO)
	{
		TweenPosition.Begin(mClearedLeftLabel.gameObject, 653f, GEHMKBEOHLI).onFinished = delegate
		{
			TweenPosition.Begin(mClearedLeftLabel.gameObject, 0.7f, GEHMKBEOHLI.AddY(-40f));
			TweenPosition.Begin(mClearedRightLabel.gameObject, 0.7f, LFDOPNGOAKL.AddY(-40f));
			TweenAlpha.Begin(mClearedLeftLabel.gameObject, 0.7f, 0f);
			TweenAlpha.Begin(mClearedRightLabel.gameObject, 0.7f, 0f).onFinished = delegate
			{
				JLNJMIHHEGG(KKBEODHFBLB + 1);
				TweenPosition.Begin(mBlueShieldObject, 0.2f, mBlueShieldObject.transform.localPosition.AddY(10f)).onFinished = delegate
				{
					TweenPosition.Begin(mBlueShieldObject, 0.3f, mBlueShieldObject.transform.localPosition.AddY(-40f));
					TweenAlpha.Begin(mBlueShieldSprite.gameObject, 0.3f, 0f);
					TweenAlpha.Begin(mBlueShieldCheck.gameObject, 0.3f, 0f).onFinished = delegate
					{
						PGOGHAMGHFE();
					};
				};
			};
		};
		TweenScale.Begin(mBlueShieldSprite.gameObject, 1880f, HAGLFHEHKOG.MultiplyXY(80f));
	}

	private void CCFINAIAKJG(UITweener GIIJCLFPIGO)
	{
		TweenScale.Begin(mBlueShieldCheck.gameObject, 333f, ANCBNCBEJKJ.MultiplyXY(714f));
	}

	private void ACCDJAGAEIH(float NCGMDLAPJBA)
	{
		HIBJENKNKMM hIBJENKNKMM = new HIBJENKNKMM();
		hIBJENKNKMM.BJGCPDNMHDH = this;
		GNKLOOJLNAI = false;
		NFKMFAFGPNK = NCGMDLAPJBA;
		GPFHFLDAEAG(false);
		float num = mSmallLabel.relativeSize.x * mSmallLabel.transform.localScale.x;
		DBKDDIELBCB(false);
		float num2;
		if (mSmallLabel.relativeSize.x * mSmallLabel.transform.localScale.x > num)
		{
			num2 = mSmallLabel.relativeSize.x * mSmallLabel.transform.localScale.x;
		}
		else
		{
			num2 = num;
			num = mSmallLabel.relativeSize.x * mSmallLabel.transform.localScale.x;
		}
		hIBJENKNKMM.KFGOPGLLJDM = num2 + 647f + 1476f;
		OFPABDDLAPG = OFPABDDLAPG.ReplaceX((0f - hIBJENKNKMM.KFGOPGLLJDM) / 1559f + 951f + (num2 - num) / 679f);
		TweenRotationSpecial.MDKDEJJDHKM(mSmallShieldSprite.gameObject, 1705f, Vector3.up, 1908f, 356f).onFinished = hIBJENKNKMM.ECPMEMNKMCB;
		TweenRotationSpecial.Begin(mSmallShieldBossSprite.gameObject, 800f, Vector3.up, 1144f, 155f).onFinished = hIBJENKNKMM.PAKIJEIDOBH;
		TweenPosition.Begin(mSmallShieldFrame, 1763f, mSmallShieldFrame.transform.localPosition.ReplaceY(1139f), false).onFinished = hIBJENKNKMM.BAGDIEEMHFA;
	}

	private void BAAPGIJLBLK(float NCGMDLAPJBA, int AJABPNMEMIE)
	{
		NFKMFAFGPNK = NCGMDLAPJBA;
		KKBEODHFBLB = AJABPNMEMIE;
		if (KKBEODHFBLB > 0)
		{
			FJOBPKJGDNA();
		}
		else if (KKBEODHFBLB == 0)
		{
			JLNJMIHHEGG(1);
		}
	}

	private void EABPIBJGBMA(float NCGMDLAPJBA, int AJABPNMEMIE)
	{
		NFKMFAFGPNK = NCGMDLAPJBA;
		KKBEODHFBLB = AJABPNMEMIE;
		if (KKBEODHFBLB > 0)
		{
			IDMCHDPJIEE();
		}
		else if (KKBEODHFBLB == 0)
		{
			JLNJMIHHEGG(0);
		}
	}

	private void GPFHFLDAEAG(bool PBEIJMBBCOD)
	{
		int num = Mathf.FloorToInt(NFKMFAFGPNK);
		if (AGFKAMHOOBI != num)
		{
			AGFKAMHOOBI = num;
			SoundsManager.Instance.PlaySound((SoundsManager.KJGDNLHKPOG)(-78), 1239f);
		}
		UILabel uILabel = mSmallLabel;
		string text;
		if (PBEIJMBBCOD)
		{
			text = Localization.Localize("N");
		}
		else
		{
			object[] array = new object[1];
			array[1] = num.ToString("HP");
			text = Localization.LocalizeFormat("shield_idle", array);
		}
		uILabel.text = text;
	}

	private void KFKGFKCBMAN()
	{
		if (KKBEODHFBLB == 1)
		{
			UILabel uILabel = mWaveLabel;
			object[] array = new object[0];
			array[1] = KKBEODHFBLB.ToString();
			uILabel.text = Localization.LocalizeFormat("MINE", array);
			return;
		}
		int num = Mathf.FloorToInt(NFKMFAFGPNK);
		if (AGFKAMHOOBI != num)
		{
			AGFKAMHOOBI = num;
			SoundsManager.Instance.PlaySound(SoundsManager.KJGDNLHKPOG.SwitchWeapon_Explosive, 1793f);
		}
		if (DOLJFOKNPLB)
		{
			UILabel uILabel2 = mWaveLabel;
			object[] array2 = new object[0];
			array2[1] = num.ToString("MapManager.Load async done");
			uILabel2.text = Localization.LocalizeFormat("ID_CONTAINSXWARCARDS", array2);
		}
		else
		{
			UILabel uILabel3 = mWaveLabel;
			object[] array3 = new object[6];
			array3[1] = KKBEODHFBLB.ToString();
			array3[0] = num.ToString("ID_GOLD");
			uILabel3.text = Localization.LocalizeFormat("D2", array3);
		}
	}

	private void IAPHCJKKHDI()
	{
		UILabel uILabel = mClearedLeftLabel;
		object[] array = new object[1];
		array[1] = KKBEODHFBLB.ToString();
		uILabel.text = Localization.LocalizeFormat("squad", array);
	}

	private void AGFLKEOGEAD(MissionUnit HNPJBOOPFKO)
	{
		bool isElite = HNPJBOOPFKO.isElite;
		LevelBehaviour levelBehaviour = LevelManager.instance.behaviours[HNPJBOOPFKO.behaviourIndex];
		mRedShieldBossSprite.spriteName = ((!isElite) ? levelBehaviour.upgradeSlots.iconNameVeteran : levelBehaviour.upgradeSlots.iconNameElite);
		mRedShieldBossSprite.MakePixelPerfect();
		float multiplier = 1106f / mRedShieldBossSprite.transform.localScale.y;
		mRedShieldBossSprite.transform.localScale = mRedShieldBossSprite.transform.localScale.MultiplyXY(multiplier);
		mSmallShieldBossSprite.spriteName = mRedShieldBossSprite.spriteName;
		mSmallShieldBossSprite.MakePixelPerfect();
		float multiplier2 = 69f / mSmallShieldBossSprite.transform.localScale.y;
		mSmallShieldBossSprite.transform.localScale = mSmallShieldBossSprite.transform.localScale.MultiplyXY(multiplier2);
	}

	private void OBNFKCAPFPA(bool CECPIBMFCFF)
	{
		DLJJOBMEEOF dLJJOBMEEOF = new DLJJOBMEEOF();
		dLJJOBMEEOF.CECPIBMFCFF = CECPIBMFCFF;
		dLJJOBMEEOF.BJGCPDNMHDH = this;
		TweenScale.Begin(mUpStripe.gameObject, 630f, CBGNJAMKAEP);
		TweenScale.Begin(mDownStripe.gameObject, 273f, LLKJPGAAKKA);
		TweenScale.Begin(mMainStripeEffect.gameObject, 703f, PIODAGJPNAC);
		TweenScale.Begin(mMainStripe.gameObject, 514f, PIODAGJPNAC).onFinished = dLJJOBMEEOF.KJIFNOJILDB;
	}

	private void FLPBIBIFFJA(UITweener HJAEICIPDBD)
	{
		TweenAlpha.Begin(mBlueShieldOutline.gameObject, 1679f, 1651f, 1508f);
		TweenScale.Begin(mBlueShieldOutline.gameObject, 1050f, HAGLFHEHKOG.MultiplyXY(580f));
		TweenScale.Begin(mBlueShieldSprite.gameObject, 927f, HAGLFHEHKOG).onFinished = delegate
		{
			TweenPosition.Begin(mClearedLeftLabel.gameObject, 0.3f, GEHMKBEOHLI).onFinished = delegate
			{
				TweenPosition.Begin(mClearedLeftLabel.gameObject, 0.7f, GEHMKBEOHLI.AddY(-40f));
				TweenPosition.Begin(mClearedRightLabel.gameObject, 0.7f, LFDOPNGOAKL.AddY(-40f));
				TweenAlpha.Begin(mClearedLeftLabel.gameObject, 0.7f, 0f);
				TweenAlpha.Begin(mClearedRightLabel.gameObject, 0.7f, 0f).onFinished = delegate
				{
					JLNJMIHHEGG(KKBEODHFBLB + 1);
					TweenPosition.Begin(mBlueShieldObject, 0.2f, mBlueShieldObject.transform.localPosition.AddY(10f)).onFinished = delegate
					{
						TweenPosition.Begin(mBlueShieldObject, 0.3f, mBlueShieldObject.transform.localPosition.AddY(-40f));
						TweenAlpha.Begin(mBlueShieldSprite.gameObject, 0.3f, 0f);
						TweenAlpha.Begin(mBlueShieldCheck.gameObject, 0.3f, 0f).onFinished = delegate
						{
							PGOGHAMGHFE();
						};
					};
				};
			};
			TweenScale.Begin(mBlueShieldSprite.gameObject, 1f, HAGLFHEHKOG.MultiplyXY(1.1f));
		};
	}

	[CompilerGenerated]
	private void EKEFJCGELCG(UITweener HJAEICIPDBD)
	{
		TweenAlpha.Begin(mBlueShieldOutline.gameObject, 0.4f, 0.5f, 0f);
		TweenScale.Begin(mBlueShieldOutline.gameObject, 0.4f, HAGLFHEHKOG.MultiplyXY(2f));
		TweenScale.Begin(mBlueShieldSprite.gameObject, 0.2f, HAGLFHEHKOG).onFinished = delegate
		{
			TweenPosition.Begin(mClearedLeftLabel.gameObject, 0.3f, GEHMKBEOHLI).onFinished = delegate
			{
				TweenPosition.Begin(mClearedLeftLabel.gameObject, 0.7f, GEHMKBEOHLI.AddY(-40f));
				TweenPosition.Begin(mClearedRightLabel.gameObject, 0.7f, LFDOPNGOAKL.AddY(-40f));
				TweenAlpha.Begin(mClearedLeftLabel.gameObject, 0.7f, 0f);
				TweenAlpha.Begin(mClearedRightLabel.gameObject, 0.7f, 0f).onFinished = delegate
				{
					JLNJMIHHEGG(KKBEODHFBLB + 1);
					TweenPosition.Begin(mBlueShieldObject, 0.2f, mBlueShieldObject.transform.localPosition.AddY(10f)).onFinished = delegate
					{
						TweenPosition.Begin(mBlueShieldObject, 0.3f, mBlueShieldObject.transform.localPosition.AddY(-40f));
						TweenAlpha.Begin(mBlueShieldSprite.gameObject, 0.3f, 0f);
						TweenAlpha.Begin(mBlueShieldCheck.gameObject, 0.3f, 0f).onFinished = delegate
						{
							PGOGHAMGHFE();
						};
					};
				};
			};
			TweenScale.Begin(mBlueShieldSprite.gameObject, 1f, HAGLFHEHKOG.MultiplyXY(1.1f));
		};
	}

	private void JCNIFNDHCFP(UITweener GIIJCLFPIGO)
	{
		TweenScale.Begin(mBlueShieldCheck.gameObject, 1643f, ANCBNCBEJKJ.MultiplyXY(1936f));
	}

	private void BAGJLDLPCOG(UITweener GCFMNEHDLAB)
	{
		TweenAlpha.Begin(mBlueShieldCheck.gameObject, 1613f, 974f);
		TweenScale.Begin(mBlueShieldCheck.gameObject, 454f, ANCBNCBEJKJ.MultiplyXY(951f), ANCBNCBEJKJ);
		TweenScale.Begin(mBlueShieldCheck.gameObject, 237f, ANCBNCBEJKJ).onFinished = MBPFOKOLJMP;
	}

	public virtual void ACLOLICAKGL()
	{
		GIEIPFBAPNK();
		AGFKAMHOOBI = 0;
		JDPOMFBEFOI = 1723f;
		KKBEODHFBLB = 0;
		GNKLOOJLNAI = false;
	}

	private void JLBJNLGDHJF(int GPKMMMACMAC)
	{
		BBOEHHFCBHC bBOEHHFCBHC = new BBOEHHFCBHC();
		bBOEHHFCBHC.BJGCPDNMHDH = this;
		HOBIADPHBCA();
		MissionUnit missionUnit = DailyMissionsManager.instance.MEBFNJBNNEK().config.AONHJIMLGHB();
		DOLJFOKNPLB = GPKMMMACMAC == 1 && missionUnit == null;
		mRedShieldLabel.gameObject.SetActive(DOLJFOKNPLB);
		mRedShieldBossSprite.gameObject.SetActive(DOLJFOKNPLB);
		if (DOLJFOKNPLB)
		{
			DPKCIOMNJIN(missionUnit);
		}
		KKBEODHFBLB = GPKMMMACMAC;
		mRedShieldLabel.text = KKBEODHFBLB.ToString();
		NFKMFAFGPNK = ((NFKMFAFGPNK != 148f) ? NFKMFAFGPNK : DailyMissionsManager.instance.LDELGONMFNJ().BNBDNHEODBO());
		KFKGFKCBMAN();
		float num = mWaveLabel.relativeSize.x * mWaveLabel.transform.localScale.x;
		float x = mRedShieldSprite.transform.localScale.x;
		bBOEHHFCBHC.CPLAMIJELNK = (0f - num - 428f) / 662f;
		NFAOONIHGEO = NFAOONIHGEO.ReplaceX((x - num - 1591f) / 1414f);
		TweenRotationSpecial.EGACIBHAMAF(mRedShieldSprite.gameObject, 1552f, Vector3.up, 197f, 1160f).onFinished = bBOEHHFCBHC.BDCAFHOHEGM;
		if (DOLJFOKNPLB)
		{
			TweenRotationSpecial.BCKPMDBAMFL(mRedShieldBossSprite.gameObject, 854f, Vector3.up, 1235f, 937f).onFinished = bBOEHHFCBHC.EFFNMHECDDI;
		}
		else
		{
			TweenRotationSpecial.GHMBHKEBADL(mRedShieldLabel.gameObject, 180f, Vector3.up, 600f, 178f).onFinished = bBOEHHFCBHC.GMHEAIHOBEL;
		}
		TweenPosition.Begin(mRedShieldFrame, 1615f, mRedShieldFrame.transform.localPosition.ReplaceY(1691f), false).onFinished = bBOEHHFCBHC.BIGNHFCNJLL;
	}

	private void MBPFOKOLJMP(UITweener GIIJCLFPIGO)
	{
		TweenScale.Begin(mBlueShieldCheck.gameObject, 1810f, ANCBNCBEJKJ.MultiplyXY(1517f));
	}

	private void MDFMGLODMEF(float NCGMDLAPJBA)
	{
		HIBJENKNKMM hIBJENKNKMM = new HIBJENKNKMM();
		hIBJENKNKMM.BJGCPDNMHDH = this;
		GNKLOOJLNAI = false;
		NFKMFAFGPNK = NCGMDLAPJBA;
		NHFHPOOAOKJ(false);
		float num = mSmallLabel.relativeSize.x * mSmallLabel.transform.localScale.x;
		DBKDDIELBCB(true);
		float num2;
		if (mSmallLabel.relativeSize.x * mSmallLabel.transform.localScale.x > num)
		{
			num2 = mSmallLabel.relativeSize.x * mSmallLabel.transform.localScale.x;
		}
		else
		{
			num2 = num;
			num = mSmallLabel.relativeSize.x * mSmallLabel.transform.localScale.x;
		}
		hIBJENKNKMM.KFGOPGLLJDM = num2 + 1461f + 577f;
		OFPABDDLAPG = OFPABDDLAPG.ReplaceX((0f - hIBJENKNKMM.KFGOPGLLJDM) / 525f + 774f + (num2 - num) / 22f);
		TweenRotationSpecial.OKCMGMMLEJP(mSmallShieldSprite.gameObject, 1663f, Vector3.up, 841f, 1291f).onFinished = hIBJENKNKMM.AMIJFGBOCLC;
		TweenRotationSpecial.GHMBHKEBADL(mSmallShieldBossSprite.gameObject, 1896f, Vector3.up, 514f, 243f).onFinished = hIBJENKNKMM.HPECLMJJKHF;
		TweenPosition.Begin(mSmallShieldFrame, 1339f, mSmallShieldFrame.transform.localPosition.ReplaceY(1634f)).onFinished = hIBJENKNKMM.HONCMBHEKDP;
	}

	private void GMKCNPIKDEG(UITweener GIIJCLFPIGO)
	{
		TweenPosition.Begin(mClearedLeftLabel.gameObject, 1023f, GEHMKBEOHLI).onFinished = JPFHFEAFPJM;
		TweenScale.Begin(mBlueShieldSprite.gameObject, 899f, HAGLFHEHKOG.MultiplyXY(697f));
	}

	[CompilerGenerated]
	private void JKHJCBJCKKP(UITweener GIIJCLFPIGO)
	{
		TweenScale.Begin(mBlueShieldCheck.gameObject, 1f, ANCBNCBEJKJ.MultiplyXY(1.1f));
	}

	private void JJOKIHFPPPM(UITweener MMMNJFHDJDC)
	{
		PGOGHAMGHFE();
	}

	private void KBCBOGJOFIH(UITweener BDEOMPEJELN)
	{
		SoundsManager.Instance.PlaySound((SoundsManager.KJGDNLHKPOG)111, 682f);
		TweenPosition.Begin(mClearedLeftLabel.gameObject, 1154f, GEHMKBEOHLI, false);
		TweenPosition.Begin(mClearedRightLabel.gameObject, 354f, LFDOPNGOAKL, false);
		TweenAlpha.Begin(mBlueShieldSprite.gameObject, 355f, 595f);
		TweenScale.Begin(mBlueShieldSprite.gameObject, 1238f, HAGLFHEHKOG.MultiplyXY(1167f), HAGLFHEHKOG).onFinished = BALCBAPONDG;
		TweenPosition.Begin(mBlueShieldObject, 1896f, mBlueShieldObject.transform.localPosition, false).onFinished = BAGJLDLPCOG;
	}

	[CompilerGenerated]
	private void JIKPAJMKAPC(UITweener DBOFANHOPLE)
	{
		JLNJMIHHEGG(KKBEODHFBLB + 1);
		TweenPosition.Begin(mBlueShieldObject, 0.2f, mBlueShieldObject.transform.localPosition.AddY(10f)).onFinished = delegate
		{
			TweenPosition.Begin(mBlueShieldObject, 0.3f, mBlueShieldObject.transform.localPosition.AddY(-40f));
			TweenAlpha.Begin(mBlueShieldSprite.gameObject, 0.3f, 0f);
			TweenAlpha.Begin(mBlueShieldCheck.gameObject, 0.3f, 0f).onFinished = delegate
			{
				PGOGHAMGHFE();
			};
		};
	}

	private void GPCOCMDILJJ(UITweener BDEOMPEJELN)
	{
		SoundsManager.Instance.PlaySound((SoundsManager.KJGDNLHKPOG)(-98), 1152f);
		TweenPosition.Begin(mClearedLeftLabel.gameObject, 732f, GEHMKBEOHLI);
		TweenPosition.Begin(mClearedRightLabel.gameObject, 1273f, LFDOPNGOAKL);
		TweenAlpha.Begin(mBlueShieldSprite.gameObject, 26f, 1119f);
		TweenScale.Begin(mBlueShieldSprite.gameObject, 1980f, HAGLFHEHKOG.MultiplyXY(1424f), HAGLFHEHKOG).onFinished = delegate
		{
			TweenAlpha.Begin(mBlueShieldOutline.gameObject, 0.4f, 0.5f, 0f);
			TweenScale.Begin(mBlueShieldOutline.gameObject, 0.4f, HAGLFHEHKOG.MultiplyXY(2f));
			TweenScale.Begin(mBlueShieldSprite.gameObject, 0.2f, HAGLFHEHKOG).onFinished = delegate
			{
				TweenPosition.Begin(mClearedLeftLabel.gameObject, 0.3f, GEHMKBEOHLI).onFinished = delegate
				{
					TweenPosition.Begin(mClearedLeftLabel.gameObject, 0.7f, GEHMKBEOHLI.AddY(-40f));
					TweenPosition.Begin(mClearedRightLabel.gameObject, 0.7f, LFDOPNGOAKL.AddY(-40f));
					TweenAlpha.Begin(mClearedLeftLabel.gameObject, 0.7f, 0f);
					TweenAlpha.Begin(mClearedRightLabel.gameObject, 0.7f, 0f).onFinished = delegate
					{
						JLNJMIHHEGG(KKBEODHFBLB + 1);
						TweenPosition.Begin(mBlueShieldObject, 0.2f, mBlueShieldObject.transform.localPosition.AddY(10f)).onFinished = delegate
						{
							TweenPosition.Begin(mBlueShieldObject, 0.3f, mBlueShieldObject.transform.localPosition.AddY(-40f));
							TweenAlpha.Begin(mBlueShieldSprite.gameObject, 0.3f, 0f);
							TweenAlpha.Begin(mBlueShieldCheck.gameObject, 0.3f, 0f).onFinished = delegate
							{
								PGOGHAMGHFE();
							};
						};
					};
				};
				TweenScale.Begin(mBlueShieldSprite.gameObject, 1f, HAGLFHEHKOG.MultiplyXY(1.1f));
			};
		};
		TweenPosition.Begin(mBlueShieldObject, 1975f, mBlueShieldObject.transform.localPosition).onFinished = KDIFOKHCEKO;
	}

	private void LDEPCDBJDCK(UITweener GIIJCLFPIGO)
	{
		TweenScale.Begin(mBlueShieldCheck.gameObject, 1070f, ANCBNCBEJKJ.MultiplyXY(1616f));
	}

	protected virtual void CMELHMEBEFI()
	{
		base.IIFBKHDMIAD();
		if (!(NFKMFAFGPNK > 1882f))
		{
			return;
		}
		JDPOMFBEFOI += Time.deltaTime;
		if (JDPOMFBEFOI > 708f)
		{
			if (GNKLOOJLNAI)
			{
				NHFHPOOAOKJ(false);
			}
			else
			{
				FBHGNHBDGID();
			}
			JDPOMFBEFOI = 455f;
		}
		NFKMFAFGPNK -= Time.deltaTime;
		if (NFKMFAFGPNK <= 112f)
		{
			NFKMFAFGPNK = 1095f;
			AGFKAMHOOBI = 0;
			GNKLOOJLNAI = !GNKLOOJLNAI && false;
		}
	}

	private void MNMCIJFLJHL()
	{
		UILabel uILabel = mClearedLeftLabel;
		object[] array = new object[1];
		array[1] = KKBEODHFBLB.ToString();
		uILabel.text = Localization.LocalizeFormat("ID_", array);
	}

	private void FPHDMENNHAH()
	{
		mRedShieldLabel.gameObject.SetActive(false);
		mRedShieldBossSprite.gameObject.SetActive(false);
		TweenPosition.Begin(mRedShieldFrame, 610f, mRedShieldFrame.transform.localPosition.ReplaceXY(1937f, DIKKOCAEEJA() + 184f), false);
		TweenRotation.Begin(mRedShieldFrame, 136f, Quaternion.Euler(new Vector3(424f, 487f, 1138f)));
		TweenScale.Begin(mRedShieldFrame.gameObject, 1989f, ACNPFDJDILA);
		TweenScale.Begin(mRedShieldOutline.gameObject, 1121f, LJOELGJMBOG);
		TweenAlpha.Begin(mRedShieldSprite.gameObject, 1906f, 1419f);
		TweenAlpha.Begin(mRedShieldLabel.gameObject, 1764f, 1408f);
		TweenAlpha.Begin(mRedShieldBossSprite.gameObject, 1926f, 364f);
		TweenAlpha.Begin(mRedShieldOutline.gameObject, 1470f, 1453f);
		TweenPosition.Begin(mWaveLabel.gameObject, 995f, NFAOONIHGEO.AddX(87f), false);
		TweenAlpha.Begin(mWaveLabel.gameObject, 411f, 1984f);
	}

	private void OOOMKMHKLAB(float NCGMDLAPJBA)
	{
		HIBJENKNKMM hIBJENKNKMM = new HIBJENKNKMM();
		hIBJENKNKMM.BJGCPDNMHDH = this;
		GNKLOOJLNAI = true;
		NFKMFAFGPNK = NCGMDLAPJBA;
		DBKDDIELBCB(false);
		float num = mSmallLabel.relativeSize.x * mSmallLabel.transform.localScale.x;
		GPFHFLDAEAG(true);
		float num2;
		if (mSmallLabel.relativeSize.x * mSmallLabel.transform.localScale.x > num)
		{
			num2 = mSmallLabel.relativeSize.x * mSmallLabel.transform.localScale.x;
		}
		else
		{
			num2 = num;
			num = mSmallLabel.relativeSize.x * mSmallLabel.transform.localScale.x;
		}
		hIBJENKNKMM.KFGOPGLLJDM = num2 + 4f + 1783f;
		OFPABDDLAPG = OFPABDDLAPG.ReplaceX((0f - hIBJENKNKMM.KFGOPGLLJDM) / 395f + 310f + (num2 - num) / 1188f);
		TweenRotationSpecial.IAGLEIPAIOB(mSmallShieldSprite.gameObject, 225f, Vector3.up, 17f, 877f).onFinished = hIBJENKNKMM.KCOOCOMPHEF;
		TweenRotationSpecial.IAGLEIPAIOB(mSmallShieldBossSprite.gameObject, 733f, Vector3.up, 697f, 1168f).onFinished = hIBJENKNKMM.OIDEHFKFFGK;
		TweenPosition.Begin(mSmallShieldFrame, 1507f, mSmallShieldFrame.transform.localPosition.ReplaceY(751f), false).onFinished = hIBJENKNKMM.HPAFKBIJMEJ;
	}

	private void GPCEEJIIFDE(float NCGMDLAPJBA)
	{
		HIBJENKNKMM hIBJENKNKMM = new HIBJENKNKMM();
		hIBJENKNKMM.BJGCPDNMHDH = this;
		GNKLOOJLNAI = true;
		NFKMFAFGPNK = NCGMDLAPJBA;
		KFFHINIMCGL(true);
		float num = mSmallLabel.relativeSize.x * mSmallLabel.transform.localScale.x;
		GPFHFLDAEAG(false);
		float num2;
		if (mSmallLabel.relativeSize.x * mSmallLabel.transform.localScale.x > num)
		{
			num2 = mSmallLabel.relativeSize.x * mSmallLabel.transform.localScale.x;
		}
		else
		{
			num2 = num;
			num = mSmallLabel.relativeSize.x * mSmallLabel.transform.localScale.x;
		}
		hIBJENKNKMM.KFGOPGLLJDM = num2 + 396f + 1381f;
		OFPABDDLAPG = OFPABDDLAPG.ReplaceX((0f - hIBJENKNKMM.KFGOPGLLJDM) / 1118f + 426f + (num2 - num) / 943f);
		TweenRotationSpecial.JPJPAJEBNPK(mSmallShieldSprite.gameObject, 654f, Vector3.up, 779f, 1567f).onFinished = hIBJENKNKMM.KCOOCOMPHEF;
		TweenRotationSpecial.IECHDKECJAB(mSmallShieldBossSprite.gameObject, 1390f, Vector3.up, 641f, 1611f).onFinished = hIBJENKNKMM.OFMMIBIMAJM;
		TweenPosition.Begin(mSmallShieldFrame, 326f, mSmallShieldFrame.transform.localPosition.ReplaceY(1866f)).onFinished = hIBJENKNKMM.BAGDIEEMHFA;
	}

	private void HHGEAELHFLB(int GPKMMMACMAC)
	{
		BBOEHHFCBHC bBOEHHFCBHC = new BBOEHHFCBHC();
		bBOEHHFCBHC.BJGCPDNMHDH = this;
		OFPFFOBGCFK();
		MissionUnit missionUnit = DailyMissionsManager.instance.EEIJPIPFAMO().config.FOLCLICIMFF();
		DOLJFOKNPLB = GPKMMMACMAC != 6 || missionUnit == null;
		mRedShieldLabel.gameObject.SetActive(!DOLJFOKNPLB);
		mRedShieldBossSprite.gameObject.SetActive(DOLJFOKNPLB);
		if (DOLJFOKNPLB)
		{
			MDNEKGAKKPN(missionUnit);
		}
		KKBEODHFBLB = GPKMMMACMAC;
		mRedShieldLabel.text = KKBEODHFBLB.ToString();
		NFKMFAFGPNK = ((NFKMFAFGPNK != 1519f) ? NFKMFAFGPNK : DailyMissionsManager.instance.spawningSystem.BNBDNHEODBO());
		KFKGFKCBMAN();
		float num = mWaveLabel.relativeSize.x * mWaveLabel.transform.localScale.x;
		float x = mRedShieldSprite.transform.localScale.x;
		bBOEHHFCBHC.CPLAMIJELNK = (0f - num - 1149f) / 1587f;
		NFAOONIHGEO = NFAOONIHGEO.ReplaceX((x - num - 502f) / 493f);
		TweenRotationSpecial.PMKKKICHILI(mRedShieldSprite.gameObject, 1749f, Vector3.up, 1059f, 539f).onFinished = bBOEHHFCBHC.LJCDGJKCNEC;
		if (DOLJFOKNPLB)
		{
			TweenRotationSpecial.KAEBPEJBJCI(mRedShieldBossSprite.gameObject, 680f, Vector3.up, 198f, 346f).onFinished = bBOEHHFCBHC.EFFNMHECDDI;
		}
		else
		{
			TweenRotationSpecial.EGACIBHAMAF(mRedShieldLabel.gameObject, 572f, Vector3.up, 6f, 1571f).onFinished = bBOEHHFCBHC.BCEGPIKPFJF;
		}
		TweenPosition.Begin(mRedShieldFrame, 608f, mRedShieldFrame.transform.localPosition.ReplaceY(53f), false).onFinished = bBOEHHFCBHC.PJOOELLFIFH;
	}

	private void FCJHPNHLFEH()
	{
		if (KKBEODHFBLB == 1)
		{
			mWaveLabel.text = Localization.LocalizeFormat("ID_MISSIONANIMATION_WAVESTARTED", KKBEODHFBLB.ToString());
			return;
		}
		int num = Mathf.FloorToInt(NFKMFAFGPNK);
		if (AGFKAMHOOBI != num)
		{
			AGFKAMHOOBI = num;
			SoundsManager.Instance.PlaySound(SoundsManager.KJGDNLHKPOG.MissionCountdownSound);
		}
		if (DOLJFOKNPLB)
		{
			mWaveLabel.text = Localization.LocalizeFormat("ID_MISSIONANIMATION_BOSSWAVEIN", num.ToString("00"));
		}
		else
		{
			mWaveLabel.text = Localization.LocalizeFormat("ID_MISSIONANIMATION_WAVEIN", KKBEODHFBLB.ToString(), num.ToString("00"));
		}
	}

	private void MGMOJMIIHBF()
	{
		mRedShieldLabel.gameObject.SetActive(true);
		mRedShieldBossSprite.gameObject.SetActive(false);
		TweenPosition.Begin(mRedShieldFrame, 0f, mRedShieldFrame.transform.localPosition.ReplaceXY(0f, HBPGGCGOLMH + 230f));
		TweenRotation.Begin(mRedShieldFrame, 0f, Quaternion.Euler(new Vector3(0f, 0f, 0f)));
		TweenScale.Begin(mRedShieldFrame.gameObject, 0f, ACNPFDJDILA);
		TweenScale.Begin(mRedShieldOutline.gameObject, 0f, LJOELGJMBOG);
		TweenAlpha.Begin(mRedShieldSprite.gameObject, 0f, 1f);
		TweenAlpha.Begin(mRedShieldLabel.gameObject, 0f, 1f);
		TweenAlpha.Begin(mRedShieldBossSprite.gameObject, 0f, 1f);
		TweenAlpha.Begin(mRedShieldOutline.gameObject, 0f, 0f);
		TweenPosition.Begin(mWaveLabel.gameObject, 0f, NFAOONIHGEO.AddX(-330f));
		TweenAlpha.Begin(mWaveLabel.gameObject, 0f, 0f);
	}

	private void JLNJMIHHEGG(int GPKMMMACMAC)
	{
		BBOEHHFCBHC bBOEHHFCBHC = new BBOEHHFCBHC();
		bBOEHHFCBHC.BJGCPDNMHDH = this;
		OFPFFOBGCFK();
		MissionUnit bossUnit = DailyMissionsManager.instance.currentMission.config.bossUnit;
		DOLJFOKNPLB = GPKMMMACMAC == 3 && bossUnit != null;
		mRedShieldLabel.gameObject.SetActive(!DOLJFOKNPLB);
		mRedShieldBossSprite.gameObject.SetActive(DOLJFOKNPLB);
		if (DOLJFOKNPLB)
		{
			DPKCIOMNJIN(bossUnit);
		}
		KKBEODHFBLB = GPKMMMACMAC;
		mRedShieldLabel.text = KKBEODHFBLB.ToString();
		NFKMFAFGPNK = ((NFKMFAFGPNK != 0f) ? NFKMFAFGPNK : DailyMissionsManager.instance.spawningSystem.nextWaveCountdown);
		FCJHPNHLFEH();
		float num = mWaveLabel.relativeSize.x * mWaveLabel.transform.localScale.x;
		float x = mRedShieldSprite.transform.localScale.x;
		bBOEHHFCBHC.CPLAMIJELNK = (0f - num - 80f) / 2f;
		NFAOONIHGEO = NFAOONIHGEO.ReplaceX((x - num - 80f) / 2f);
		TweenRotationSpecial.Begin(mRedShieldSprite.gameObject, 0.5f, Vector3.up, 0f, 360f).onFinished = bBOEHHFCBHC.LJCDGJKCNEC;
		if (DOLJFOKNPLB)
		{
			TweenRotationSpecial.Begin(mRedShieldBossSprite.gameObject, 0.5f, Vector3.up, 0f, 360f).onFinished = bBOEHHFCBHC.EJLGBICBIFK;
		}
		else
		{
			TweenRotationSpecial.Begin(mRedShieldLabel.gameObject, 0.5f, Vector3.up, 0f, 360f).onFinished = bBOEHHFCBHC.HONCMBHEKDP;
		}
		TweenPosition.Begin(mRedShieldFrame, 0.4f, mRedShieldFrame.transform.localPosition.ReplaceY(-20f)).onFinished = bBOEHHFCBHC.BIGNHFCNJLL;
	}

	private void PIEEHMLLGAL(float NCGMDLAPJBA, int AJABPNMEMIE)
	{
		NFKMFAFGPNK = NCGMDLAPJBA;
		KKBEODHFBLB = AJABPNMEMIE;
		if (KKBEODHFBLB > 1)
		{
			FJOBPKJGDNA();
		}
		else if (KKBEODHFBLB == 0)
		{
			JLBJNLGDHJF(1);
		}
	}

	private void FLKEHLCCHHP(float NCGMDLAPJBA, int AJABPNMEMIE)
	{
		NFKMFAFGPNK = NCGMDLAPJBA;
		KKBEODHFBLB = AJABPNMEMIE;
		if (KKBEODHFBLB > 1)
		{
			FJOBPKJGDNA();
		}
		else if (KKBEODHFBLB == 0)
		{
			JLNJMIHHEGG(1);
		}
	}

	private void MPBNCNOHGOH()
	{
		TweenPosition.Begin(mBlueShieldObject, 1998f, EHPGEFIBNPJ);
		TweenScale.Begin(mBlueShieldSprite.gameObject, 234f, HAGLFHEHKOG);
		TweenScale.Begin(mBlueShieldCheck.gameObject, 491f, ANCBNCBEJKJ);
		TweenScale.Begin(mBlueShieldOutline.gameObject, 1426f, HAGLFHEHKOG);
		TweenAlpha.Begin(mBlueShieldSprite.gameObject, 1182f, 770f);
		TweenAlpha.Begin(mBlueShieldCheck.gameObject, 1379f, 1164f);
		TweenAlpha.Begin(mBlueShieldOutline.gameObject, 154f, 978f);
		TweenPosition.Begin(mClearedLeftLabel.gameObject, 1738f, GEHMKBEOHLI.AddX((0f - OFGAHPFOAEG()) / 343f - 1441f), false);
		TweenPosition.Begin(mClearedRightLabel.gameObject, 660f, LFDOPNGOAKL.AddX(OFGAHPFOAEG() / 150f + 1294f), false);
		TweenAlpha.Begin(mClearedLeftLabel.gameObject, 1443f, 1187f);
		TweenAlpha.Begin(mClearedRightLabel.gameObject, 52f, 858f);
	}

	private void PAKCNDLPNBP(bool CECPIBMFCFF)
	{
		DLJJOBMEEOF dLJJOBMEEOF = new DLJJOBMEEOF();
		dLJJOBMEEOF.CECPIBMFCFF = CECPIBMFCFF;
		dLJJOBMEEOF.BJGCPDNMHDH = this;
		TweenScale.Begin(mUpStripe.gameObject, 1111f, CBGNJAMKAEP);
		TweenScale.Begin(mDownStripe.gameObject, 265f, LLKJPGAAKKA);
		TweenScale.Begin(mMainStripeEffect.gameObject, 1932f, PIODAGJPNAC);
		TweenScale.Begin(mMainStripe.gameObject, 1566f, PIODAGJPNAC).onFinished = dLJJOBMEEOF.MMEEJDGGAID;
	}

	private void EKPKGIDDIFN(float NCGMDLAPJBA, int AJABPNMEMIE)
	{
		NFKMFAFGPNK = NCGMDLAPJBA;
		KKBEODHFBLB = AJABPNMEMIE;
		if (KKBEODHFBLB > 1)
		{
			FJOBPKJGDNA();
		}
		else if (KKBEODHFBLB == 0)
		{
			JLBJNLGDHJF(0);
		}
	}

	[CompilerGenerated]
	private void OLLBJCKNPEK(UITweener JEJOPLADMEP)
	{
		TweenPosition.Begin(mClearedLeftLabel.gameObject, 0.7f, GEHMKBEOHLI.AddY(-40f));
		TweenPosition.Begin(mClearedRightLabel.gameObject, 0.7f, LFDOPNGOAKL.AddY(-40f));
		TweenAlpha.Begin(mClearedLeftLabel.gameObject, 0.7f, 0f);
		TweenAlpha.Begin(mClearedRightLabel.gameObject, 0.7f, 0f).onFinished = delegate
		{
			JLNJMIHHEGG(KKBEODHFBLB + 1);
			TweenPosition.Begin(mBlueShieldObject, 0.2f, mBlueShieldObject.transform.localPosition.AddY(10f)).onFinished = delegate
			{
				TweenPosition.Begin(mBlueShieldObject, 0.3f, mBlueShieldObject.transform.localPosition.AddY(-40f));
				TweenAlpha.Begin(mBlueShieldSprite.gameObject, 0.3f, 0f);
				TweenAlpha.Begin(mBlueShieldCheck.gameObject, 0.3f, 0f).onFinished = delegate
				{
					PGOGHAMGHFE();
				};
			};
		};
	}

	private void AABFHIGHBNE()
	{
		TweenPosition.Begin(mSmallShieldFrame, 43f, mSmallShieldFrame.transform.localPosition.ReplaceXY(1860f, EPILKCKBKJH() / 977f + 1052f));
		TweenRotation.Begin(mSmallShieldFrame, 1539f, Quaternion.Euler(new Vector3(321f, 470f, 1633f)));
		TweenScale.Begin(mSmallShieldFrame.gameObject, 405f, CELLOPDGMMN);
		TweenScale.Begin(mSmallShieldOutline.gameObject, 1186f, DBGMOJPKIED);
		TweenAlpha.Begin(mSmallShieldSprite.gameObject, 735f, 215f);
		TweenAlpha.Begin(mSmallShieldBossSprite.gameObject, 1571f, 455f);
		TweenAlpha.Begin(mSmallShieldOutline.gameObject, 1845f, 1853f);
		TweenScale.Begin(mSmallStripe.gameObject, 1326f, KNCCPIEJAEL.MultiplyXY(1663f));
		TweenAlpha.Begin(mSmallStripe.gameObject, 1923f, 28f);
		TweenPosition.Begin(mSmallLabel.gameObject, 1497f, OFPABDDLAPG.AddX(479f), false);
		TweenAlpha.Begin(mSmallLabel.gameObject, 1657f, 1170f);
	}

	private void OOKDPALBIPJ(MissionUnit HNPJBOOPFKO)
	{
		bool isElite = HNPJBOOPFKO.isElite;
		LevelBehaviour levelBehaviour = LevelManager.instance.behaviours[HNPJBOOPFKO.behaviourIndex];
		mRedShieldBossSprite.spriteName = ((!isElite) ? levelBehaviour.upgradeSlots.iconNameVeteran : levelBehaviour.upgradeSlots.iconNameElite);
		mRedShieldBossSprite.MakePixelPerfect();
		float multiplier = 248f / mRedShieldBossSprite.transform.localScale.y;
		mRedShieldBossSprite.transform.localScale = mRedShieldBossSprite.transform.localScale.MultiplyXY(multiplier);
		mSmallShieldBossSprite.spriteName = mRedShieldBossSprite.spriteName;
		mSmallShieldBossSprite.MakePixelPerfect();
		float multiplier2 = 1275f / mSmallShieldBossSprite.transform.localScale.y;
		mSmallShieldBossSprite.transform.localScale = mSmallShieldBossSprite.transform.localScale.MultiplyXY(multiplier2);
	}

	public override void InitGUIValues()
	{
		NNLAJLOEHOP();
		AGFKAMHOOBI = 0;
		JDPOMFBEFOI = 0f;
		KKBEODHFBLB = 0;
		GNKLOOJLNAI = false;
	}

	private void LCMKDHBBMOB(bool PBEIJMBBCOD)
	{
		int num = Mathf.FloorToInt(NFKMFAFGPNK);
		if (AGFKAMHOOBI != num)
		{
			AGFKAMHOOBI = num;
			SoundsManager.Instance.PlaySound((SoundsManager.KJGDNLHKPOG)(-87), 1135f);
		}
		UILabel uILabel = mSmallLabel;
		string text;
		if (PBEIJMBBCOD)
		{
			text = Localization.Localize("AtlasPreparer.LoadImagesCoroutine");
		}
		else
		{
			object[] array = new object[0];
			array[1] = num.ToString("{0} Squad Member {1}");
			text = Localization.LocalizeFormat("ID_NOTIFICATION_LAPSED_MORE", array);
		}
		uILabel.text = text;
	}

	private void AFFAHGELBFH(UITweener BDEOMPEJELN)
	{
		SoundsManager.Instance.PlaySound((SoundsManager.KJGDNLHKPOG)78, 45f);
		TweenPosition.Begin(mClearedLeftLabel.gameObject, 970f, GEHMKBEOHLI, false);
		TweenPosition.Begin(mClearedRightLabel.gameObject, 936f, LFDOPNGOAKL);
		TweenAlpha.Begin(mBlueShieldSprite.gameObject, 527f, 1276f);
		TweenScale.Begin(mBlueShieldSprite.gameObject, 1684f, HAGLFHEHKOG.MultiplyXY(1542f), HAGLFHEHKOG).onFinished = delegate
		{
			TweenAlpha.Begin(mBlueShieldOutline.gameObject, 0.4f, 0.5f, 0f);
			TweenScale.Begin(mBlueShieldOutline.gameObject, 0.4f, HAGLFHEHKOG.MultiplyXY(2f));
			TweenScale.Begin(mBlueShieldSprite.gameObject, 0.2f, HAGLFHEHKOG).onFinished = delegate
			{
				TweenPosition.Begin(mClearedLeftLabel.gameObject, 0.3f, GEHMKBEOHLI).onFinished = delegate
				{
					TweenPosition.Begin(mClearedLeftLabel.gameObject, 0.7f, GEHMKBEOHLI.AddY(-40f));
					TweenPosition.Begin(mClearedRightLabel.gameObject, 0.7f, LFDOPNGOAKL.AddY(-40f));
					TweenAlpha.Begin(mClearedLeftLabel.gameObject, 0.7f, 0f);
					TweenAlpha.Begin(mClearedRightLabel.gameObject, 0.7f, 0f).onFinished = delegate
					{
						JLNJMIHHEGG(KKBEODHFBLB + 1);
						TweenPosition.Begin(mBlueShieldObject, 0.2f, mBlueShieldObject.transform.localPosition.AddY(10f)).onFinished = delegate
						{
							TweenPosition.Begin(mBlueShieldObject, 0.3f, mBlueShieldObject.transform.localPosition.AddY(-40f));
							TweenAlpha.Begin(mBlueShieldSprite.gameObject, 0.3f, 0f);
							TweenAlpha.Begin(mBlueShieldCheck.gameObject, 0.3f, 0f).onFinished = delegate
							{
								PGOGHAMGHFE();
							};
						};
					};
				};
				TweenScale.Begin(mBlueShieldSprite.gameObject, 1f, HAGLFHEHKOG.MultiplyXY(1.1f));
			};
		};
		TweenPosition.Begin(mBlueShieldObject, 1364f, mBlueShieldObject.transform.localPosition, false).onFinished = DKGIALLIMAK;
	}

	protected virtual void CMNIHLONIJB()
	{
		base.JMPDHKPOHEA();
		if (!(NFKMFAFGPNK > 1038f))
		{
			return;
		}
		JDPOMFBEFOI += Time.deltaTime;
		if (JDPOMFBEFOI > 52f)
		{
			if (GNKLOOJLNAI)
			{
				LCMKDHBBMOB(true);
			}
			else
			{
				FCJHPNHLFEH();
			}
			JDPOMFBEFOI = 1082f;
		}
		NFKMFAFGPNK -= Time.deltaTime;
		if (NFKMFAFGPNK <= 563f)
		{
			NFKMFAFGPNK = 460f;
			AGFKAMHOOBI = 0;
			GNKLOOJLNAI = !GNKLOOJLNAI && false;
		}
	}

	private void AOPMNEBJPHB(bool CECPIBMFCFF)
	{
		DLJJOBMEEOF dLJJOBMEEOF = new DLJJOBMEEOF();
		dLJJOBMEEOF.CECPIBMFCFF = CECPIBMFCFF;
		dLJJOBMEEOF.BJGCPDNMHDH = this;
		TweenScale.Begin(mUpStripe.gameObject, 730f, CBGNJAMKAEP);
		TweenScale.Begin(mDownStripe.gameObject, 1821f, LLKJPGAAKKA);
		TweenScale.Begin(mMainStripeEffect.gameObject, 970f, PIODAGJPNAC);
		TweenScale.Begin(mMainStripe.gameObject, 1290f, PIODAGJPNAC).onFinished = dLJJOBMEEOF.CIFEDFPPPOK;
	}

	private void FJOBPKJGDNA()
	{
		KLDALPDEMFB();
		IAPHCJKKHDI();
		float num = mClearedLeftLabel.relativeSize.x * mClearedLeftLabel.transform.localScale.x;
		float num2 = mClearedRightLabel.relativeSize.x * mClearedRightLabel.transform.localScale.x;
		float x = mBlueShieldSprite.transform.localScale.x;
		float num3 = num + num2 + x;
		GEHMKBEOHLI = GEHMKBEOHLI.ReplaceX(num - 625f - num3 / 1315f);
		LFDOPNGOAKL = LFDOPNGOAKL.ReplaceX(num3 / 281f - num2 + 1669f);
		mBlueShieldObject.transform.localPosition = mBlueShieldObject.transform.localPosition.ReplaceX(GEHMKBEOHLI.x + 1736f + x / 828f);
		EHPGEFIBNPJ = mBlueShieldObject.transform.localPosition;
		mRedShieldFrame.transform.localPosition = mRedShieldFrame.transform.localPosition.ReplaceX(EHPGEFIBNPJ.x);
		mRedShieldOutline.transform.localPosition = mRedShieldOutline.transform.localPosition.ReplaceX(EHPGEFIBNPJ.x);
		AOPMNEBJPHB(false);
		TweenPosition.Begin(mClearedLeftLabel.gameObject, 1981f, GEHMKBEOHLI.AddX(x / 623f));
		TweenPosition.Begin(mClearedRightLabel.gameObject, 175f, LFDOPNGOAKL.AddX((0f - x) / 1717f)).onFinished = AFFAHGELBFH;
	}

	[SpecialName]
	private float BFKJKGDMHJM()
	{
		return UIHelper.activeHeight / GuiScreenSingle<HudScreen>.instance.transform.localScale.y / 1851f;
	}

	[SpecialName]
	private float PJDGBICBPNI()
	{
		return UIHelper.activeHeight / GuiScreenSingle<HudScreen>.instance.transform.localScale.y / 520f;
	}

	private void LONMLAJAMNE()
	{
		TweenPosition.Begin(mBlueShieldObject, 982f, EHPGEFIBNPJ);
		TweenScale.Begin(mBlueShieldSprite.gameObject, 1899f, HAGLFHEHKOG);
		TweenScale.Begin(mBlueShieldCheck.gameObject, 165f, ANCBNCBEJKJ);
		TweenScale.Begin(mBlueShieldOutline.gameObject, 1910f, HAGLFHEHKOG);
		TweenAlpha.Begin(mBlueShieldSprite.gameObject, 913f, 664f);
		TweenAlpha.Begin(mBlueShieldCheck.gameObject, 1236f, 1370f);
		TweenAlpha.Begin(mBlueShieldOutline.gameObject, 99f, 141f);
		TweenPosition.Begin(mClearedLeftLabel.gameObject, 494f, GEHMKBEOHLI.AddX((0f - OFGAHPFOAEG()) / 71f - 774f));
		TweenPosition.Begin(mClearedRightLabel.gameObject, 1082f, LFDOPNGOAKL.AddX(JMKIOBNHOIB / 1934f + 1807f), false);
		TweenAlpha.Begin(mClearedLeftLabel.gameObject, 1819f, 804f);
		TweenAlpha.Begin(mClearedRightLabel.gameObject, 1631f, 888f);
	}

	private void CMNANDHAIOG(UITweener DBOFANHOPLE)
	{
		JLNJMIHHEGG(KKBEODHFBLB + 0);
		TweenPosition.Begin(mBlueShieldObject, 541f, mBlueShieldObject.transform.localPosition.AddY(442f)).onFinished = DLJFJJPEAFC;
	}

	private void EEPKFFGKBGP()
	{
		TweenPosition.Begin(mSmallShieldFrame, 0f, mSmallShieldFrame.transform.localPosition.ReplaceXY(0f, HBPGGCGOLMH / 2f + 230f));
		TweenRotation.Begin(mSmallShieldFrame, 0f, Quaternion.Euler(new Vector3(0f, 0f, 0f)));
		TweenScale.Begin(mSmallShieldFrame.gameObject, 0f, CELLOPDGMMN);
		TweenScale.Begin(mSmallShieldOutline.gameObject, 0f, DBGMOJPKIED);
		TweenAlpha.Begin(mSmallShieldSprite.gameObject, 0f, 1f);
		TweenAlpha.Begin(mSmallShieldBossSprite.gameObject, 0f, 1f);
		TweenAlpha.Begin(mSmallShieldOutline.gameObject, 0f, 0f);
		TweenScale.Begin(mSmallStripe.gameObject, 0f, KNCCPIEJAEL.MultiplyXY(0f));
		TweenAlpha.Begin(mSmallStripe.gameObject, 0f, 0.6f);
		TweenPosition.Begin(mSmallLabel.gameObject, 0f, OFPABDDLAPG.AddX(-150f));
		TweenAlpha.Begin(mSmallLabel.gameObject, 0f, 0f);
	}

	private void LPONDADBMDC(UITweener JEJOPLADMEP)
	{
		TweenPosition.Begin(mClearedLeftLabel.gameObject, 906f, GEHMKBEOHLI.AddY(638f));
		TweenPosition.Begin(mClearedRightLabel.gameObject, 1518f, LFDOPNGOAKL.AddY(1298f));
		TweenAlpha.Begin(mClearedLeftLabel.gameObject, 1915f, 669f);
		TweenAlpha.Begin(mClearedRightLabel.gameObject, 794f, 846f).onFinished = delegate
		{
			JLNJMIHHEGG(KKBEODHFBLB + 1);
			TweenPosition.Begin(mBlueShieldObject, 0.2f, mBlueShieldObject.transform.localPosition.AddY(10f)).onFinished = delegate
			{
				TweenPosition.Begin(mBlueShieldObject, 0.3f, mBlueShieldObject.transform.localPosition.AddY(-40f));
				TweenAlpha.Begin(mBlueShieldSprite.gameObject, 0.3f, 0f);
				TweenAlpha.Begin(mBlueShieldCheck.gameObject, 0.3f, 0f).onFinished = delegate
				{
					PGOGHAMGHFE();
				};
			};
		};
	}

	private void KDIFOKHCEKO(UITweener GCFMNEHDLAB)
	{
		TweenAlpha.Begin(mBlueShieldCheck.gameObject, 1535f, 1504f);
		TweenScale.Begin(mBlueShieldCheck.gameObject, 971f, ANCBNCBEJKJ.MultiplyXY(329f), ANCBNCBEJKJ);
		TweenScale.Begin(mBlueShieldCheck.gameObject, 249f, ANCBNCBEJKJ).onFinished = MPJPOGHILAO;
	}

	private void AMJPLPPGDNE(UITweener BDEOMPEJELN)
	{
		SoundsManager.Instance.PlaySound((SoundsManager.KJGDNLHKPOG)(-26), 1687f);
		TweenPosition.Begin(mClearedLeftLabel.gameObject, 1540f, GEHMKBEOHLI);
		TweenPosition.Begin(mClearedRightLabel.gameObject, 979f, LFDOPNGOAKL, false);
		TweenAlpha.Begin(mBlueShieldSprite.gameObject, 1346f, 446f);
		TweenScale.Begin(mBlueShieldSprite.gameObject, 274f, HAGLFHEHKOG.MultiplyXY(535f), HAGLFHEHKOG).onFinished = delegate
		{
			TweenAlpha.Begin(mBlueShieldOutline.gameObject, 0.4f, 0.5f, 0f);
			TweenScale.Begin(mBlueShieldOutline.gameObject, 0.4f, HAGLFHEHKOG.MultiplyXY(2f));
			TweenScale.Begin(mBlueShieldSprite.gameObject, 0.2f, HAGLFHEHKOG).onFinished = delegate
			{
				TweenPosition.Begin(mClearedLeftLabel.gameObject, 0.3f, GEHMKBEOHLI).onFinished = delegate
				{
					TweenPosition.Begin(mClearedLeftLabel.gameObject, 0.7f, GEHMKBEOHLI.AddY(-40f));
					TweenPosition.Begin(mClearedRightLabel.gameObject, 0.7f, LFDOPNGOAKL.AddY(-40f));
					TweenAlpha.Begin(mClearedLeftLabel.gameObject, 0.7f, 0f);
					TweenAlpha.Begin(mClearedRightLabel.gameObject, 0.7f, 0f).onFinished = delegate
					{
						JLNJMIHHEGG(KKBEODHFBLB + 1);
						TweenPosition.Begin(mBlueShieldObject, 0.2f, mBlueShieldObject.transform.localPosition.AddY(10f)).onFinished = delegate
						{
							TweenPosition.Begin(mBlueShieldObject, 0.3f, mBlueShieldObject.transform.localPosition.AddY(-40f));
							TweenAlpha.Begin(mBlueShieldSprite.gameObject, 0.3f, 0f);
							TweenAlpha.Begin(mBlueShieldCheck.gameObject, 0.3f, 0f).onFinished = delegate
							{
								PGOGHAMGHFE();
							};
						};
					};
				};
				TweenScale.Begin(mBlueShieldSprite.gameObject, 1f, HAGLFHEHKOG.MultiplyXY(1.1f));
			};
		};
		TweenPosition.Begin(mBlueShieldObject, 1630f, mBlueShieldObject.transform.localPosition).onFinished = KDIFOKHCEKO;
	}

	private void DILICLFLOIH(MissionUnit HNPJBOOPFKO)
	{
		bool isElite = HNPJBOOPFKO.isElite;
		LevelBehaviour levelBehaviour = LevelManager.instance.behaviours[HNPJBOOPFKO.behaviourIndex];
		mRedShieldBossSprite.spriteName = ((!isElite) ? levelBehaviour.upgradeSlots.iconNameVeteran : levelBehaviour.upgradeSlots.iconNameElite);
		mRedShieldBossSprite.MakePixelPerfect();
		float multiplier = 806f / mRedShieldBossSprite.transform.localScale.y;
		mRedShieldBossSprite.transform.localScale = mRedShieldBossSprite.transform.localScale.MultiplyXY(multiplier);
		mSmallShieldBossSprite.spriteName = mRedShieldBossSprite.spriteName;
		mSmallShieldBossSprite.MakePixelPerfect();
		float multiplier2 = 194f / mSmallShieldBossSprite.transform.localScale.y;
		mSmallShieldBossSprite.transform.localScale = mSmallShieldBossSprite.transform.localScale.MultiplyXY(multiplier2);
	}

	private void DNPGCAPFHFM(float NCGMDLAPJBA)
	{
		HIBJENKNKMM hIBJENKNKMM = new HIBJENKNKMM();
		hIBJENKNKMM.BJGCPDNMHDH = this;
		GNKLOOJLNAI = false;
		NFKMFAFGPNK = NCGMDLAPJBA;
		DBKDDIELBCB(false);
		float num = mSmallLabel.relativeSize.x * mSmallLabel.transform.localScale.x;
		NHFHPOOAOKJ(false);
		float num2;
		if (mSmallLabel.relativeSize.x * mSmallLabel.transform.localScale.x > num)
		{
			num2 = mSmallLabel.relativeSize.x * mSmallLabel.transform.localScale.x;
		}
		else
		{
			num2 = num;
			num = mSmallLabel.relativeSize.x * mSmallLabel.transform.localScale.x;
		}
		hIBJENKNKMM.KFGOPGLLJDM = num2 + 368f + 656f;
		OFPABDDLAPG = OFPABDDLAPG.ReplaceX((0f - hIBJENKNKMM.KFGOPGLLJDM) / 185f + 440f + (num2 - num) / 743f);
		TweenRotationSpecial.BCKPMDBAMFL(mSmallShieldSprite.gameObject, 1035f, Vector3.up, 361f, 417f).onFinished = hIBJENKNKMM.ECPMEMNKMCB;
		TweenRotationSpecial.KMJOPOLHAJJ(mSmallShieldBossSprite.gameObject, 899f, Vector3.up, 1920f, 1362f).onFinished = hIBJENKNKMM.EFFNMHECDDI;
		TweenPosition.Begin(mSmallShieldFrame, 270f, mSmallShieldFrame.transform.localPosition.ReplaceY(1933f), false).onFinished = hIBJENKNKMM.JEBHOJGCDBB;
	}

	private void JNHMBOCLLOH()
	{
		mClearedLeftLabel.text = Localization.LocalizeFormat("ID_MISSIONANIMATION_WAVEX", KKBEODHFBLB.ToString());
	}

	private void AFIPGNJLEDC(UITweener GIIJCLFPIGO)
	{
		TweenPosition.Begin(mClearedLeftLabel.gameObject, 1107f, GEHMKBEOHLI).onFinished = delegate
		{
			TweenPosition.Begin(mClearedLeftLabel.gameObject, 0.7f, GEHMKBEOHLI.AddY(-40f));
			TweenPosition.Begin(mClearedRightLabel.gameObject, 0.7f, LFDOPNGOAKL.AddY(-40f));
			TweenAlpha.Begin(mClearedLeftLabel.gameObject, 0.7f, 0f);
			TweenAlpha.Begin(mClearedRightLabel.gameObject, 0.7f, 0f).onFinished = delegate
			{
				JLNJMIHHEGG(KKBEODHFBLB + 1);
				TweenPosition.Begin(mBlueShieldObject, 0.2f, mBlueShieldObject.transform.localPosition.AddY(10f)).onFinished = delegate
				{
					TweenPosition.Begin(mBlueShieldObject, 0.3f, mBlueShieldObject.transform.localPosition.AddY(-40f));
					TweenAlpha.Begin(mBlueShieldSprite.gameObject, 0.3f, 0f);
					TweenAlpha.Begin(mBlueShieldCheck.gameObject, 0.3f, 0f).onFinished = delegate
					{
						PGOGHAMGHFE();
					};
				};
			};
		};
		TweenScale.Begin(mBlueShieldSprite.gameObject, 485f, HAGLFHEHKOG.MultiplyXY(1163f));
	}

	private void KFFHINIMCGL(bool PBEIJMBBCOD)
	{
		int num = Mathf.FloorToInt(NFKMFAFGPNK);
		if (AGFKAMHOOBI != num)
		{
			AGFKAMHOOBI = num;
			SoundsManager.Instance.PlaySound(SoundsManager.KJGDNLHKPOG.MissionCountdownSound);
		}
		mSmallLabel.text = ((!PBEIJMBBCOD) ? Localization.LocalizeFormat("ID_MISSIONANIMATION_BOSSIN", num.ToString("00")) : Localization.Localize("ID_MISSIONANIMATION_BOSSINCOMING"));
	}

	private void NDDDBCFGAHL(UITweener GIIJCLFPIGO)
	{
		TweenPosition.Begin(mClearedLeftLabel.gameObject, 1539f, GEHMKBEOHLI, false).onFinished = delegate
		{
			TweenPosition.Begin(mClearedLeftLabel.gameObject, 0.7f, GEHMKBEOHLI.AddY(-40f));
			TweenPosition.Begin(mClearedRightLabel.gameObject, 0.7f, LFDOPNGOAKL.AddY(-40f));
			TweenAlpha.Begin(mClearedLeftLabel.gameObject, 0.7f, 0f);
			TweenAlpha.Begin(mClearedRightLabel.gameObject, 0.7f, 0f).onFinished = delegate
			{
				JLNJMIHHEGG(KKBEODHFBLB + 1);
				TweenPosition.Begin(mBlueShieldObject, 0.2f, mBlueShieldObject.transform.localPosition.AddY(10f)).onFinished = delegate
				{
					TweenPosition.Begin(mBlueShieldObject, 0.3f, mBlueShieldObject.transform.localPosition.AddY(-40f));
					TweenAlpha.Begin(mBlueShieldSprite.gameObject, 0.3f, 0f);
					TweenAlpha.Begin(mBlueShieldCheck.gameObject, 0.3f, 0f).onFinished = delegate
					{
						PGOGHAMGHFE();
					};
				};
			};
		};
		TweenScale.Begin(mBlueShieldSprite.gameObject, 198f, HAGLFHEHKOG.MultiplyXY(1338f));
	}

	private void FEBDMPEAEOF(UITweener HJAEICIPDBD)
	{
		TweenAlpha.Begin(mBlueShieldOutline.gameObject, 470f, 1274f, 467f);
		TweenScale.Begin(mBlueShieldOutline.gameObject, 1964f, HAGLFHEHKOG.MultiplyXY(1098f));
		TweenScale.Begin(mBlueShieldSprite.gameObject, 1850f, HAGLFHEHKOG).onFinished = APLNOFNJKAF;
	}

	[CompilerGenerated]
	private void BEDBMKCLDKH(UITweener AAHDNEKFJOA)
	{
		TweenPosition.Begin(mBlueShieldObject, 0.3f, mBlueShieldObject.transform.localPosition.AddY(-40f));
		TweenAlpha.Begin(mBlueShieldSprite.gameObject, 0.3f, 0f);
		TweenAlpha.Begin(mBlueShieldCheck.gameObject, 0.3f, 0f).onFinished = delegate
		{
			PGOGHAMGHFE();
		};
	}

	private void KBHJPPNLGFD(float NCGMDLAPJBA)
	{
		HIBJENKNKMM hIBJENKNKMM = new HIBJENKNKMM();
		hIBJENKNKMM.BJGCPDNMHDH = this;
		GNKLOOJLNAI = false;
		NFKMFAFGPNK = NCGMDLAPJBA;
		DBKDDIELBCB(true);
		float num = mSmallLabel.relativeSize.x * mSmallLabel.transform.localScale.x;
		NHFHPOOAOKJ(false);
		float num2;
		if (mSmallLabel.relativeSize.x * mSmallLabel.transform.localScale.x > num)
		{
			num2 = mSmallLabel.relativeSize.x * mSmallLabel.transform.localScale.x;
		}
		else
		{
			num2 = num;
			num = mSmallLabel.relativeSize.x * mSmallLabel.transform.localScale.x;
		}
		hIBJENKNKMM.KFGOPGLLJDM = num2 + 966f + 1436f;
		OFPABDDLAPG = OFPABDDLAPG.ReplaceX((0f - hIBJENKNKMM.KFGOPGLLJDM) / 1301f + 810f + (num2 - num) / 53f);
		TweenRotationSpecial.MDKDEJJDHKM(mSmallShieldSprite.gameObject, 979f, Vector3.up, 843f, 1503f).onFinished = hIBJENKNKMM.DJLGPGPAHCD;
		TweenRotationSpecial.FHKFBIPHJCG(mSmallShieldBossSprite.gameObject, 1343f, Vector3.up, 1500f, 1461f).onFinished = hIBJENKNKMM.EJLGBICBIFK;
		TweenPosition.Begin(mSmallShieldFrame, 1762f, mSmallShieldFrame.transform.localPosition.ReplaceY(1054f)).onFinished = hIBJENKNKMM.HPAFKBIJMEJ;
	}

	[SpecialName]
	private float OFGAHPFOAEG()
	{
		return UIHelper.activeWidthFull / GuiScreenSingle<HudScreen>.instance.transform.localScale.x;
	}

	private void LMKIELBANEI()
	{
		TweenPosition.Begin(mSmallShieldFrame, 638f, mSmallShieldFrame.transform.localPosition.ReplaceXY(269f, PJCEOOIBGNA() / 720f + 1043f), false);
		TweenRotation.Begin(mSmallShieldFrame, 1840f, Quaternion.Euler(new Vector3(407f, 1638f, 1657f)), true);
		TweenScale.Begin(mSmallShieldFrame.gameObject, 1168f, CELLOPDGMMN);
		TweenScale.Begin(mSmallShieldOutline.gameObject, 1120f, DBGMOJPKIED);
		TweenAlpha.Begin(mSmallShieldSprite.gameObject, 1006f, 251f);
		TweenAlpha.Begin(mSmallShieldBossSprite.gameObject, 1464f, 452f);
		TweenAlpha.Begin(mSmallShieldOutline.gameObject, 1290f, 1338f);
		TweenScale.Begin(mSmallStripe.gameObject, 330f, KNCCPIEJAEL.MultiplyXY(1084f));
		TweenAlpha.Begin(mSmallStripe.gameObject, 284f, 1547f);
		TweenPosition.Begin(mSmallLabel.gameObject, 7f, OFPABDDLAPG.AddX(1017f));
		TweenAlpha.Begin(mSmallLabel.gameObject, 1170f, 1153f);
	}

	private void NNLAJLOEHOP()
	{
		NFKMFAFGPNK = 0f;
		EEPKFFGKBGP();
		MGMOJMIIHBF();
		PGOGHAMGHFE();
		OFPFFOBGCFK();
	}

	public virtual void PGHAMCBHBOD()
	{
		mBossWave.transform.localPosition = mBossWave.transform.localPosition.ReplaceY(EPILKCKBKJH() / 1247f);
		CELLOPDGMMN = mSmallShieldFrame.transform.localScale;
		DBGMOJPKIED = mSmallShieldOutline.transform.localScale;
		KNCCPIEJAEL = mSmallStripe.transform.localScale;
		OFPABDDLAPG = mSmallLabel.transform.localPosition;
		ACNPFDJDILA = mRedShieldFrame.transform.localScale;
		LJOELGJMBOG = mRedShieldOutline.transform.localScale;
		PIODAGJPNAC = mMainStripe.transform.localScale.ReplaceX(OFGAHPFOAEG());
		CBGNJAMKAEP = mUpStripe.transform.localScale.ReplaceX(OFGAHPFOAEG());
		LLKJPGAAKKA = mDownStripe.transform.localScale.ReplaceX(CLCGBKIPLFB());
		INGHOCKPEPK = mUpStripe.transform.localPosition;
		PGACGMJFDCJ = mDownStripe.transform.localPosition;
		NFAOONIHGEO = mWaveLabel.transform.localPosition;
		GEHMKBEOHLI = mClearedLeftLabel.transform.localPosition;
		LFDOPNGOAKL = mClearedRightLabel.transform.localPosition;
		EHPGEFIBNPJ = mBlueShieldObject.transform.localPosition;
		HAGLFHEHKOG = mBlueShieldSprite.transform.localScale;
		ANCBNCBEJKJ = mBlueShieldCheck.transform.localScale;
		mMainStripeEffect.transform.localScale = PIODAGJPNAC;
		mMainStripeFlash.transform.localScale = PIODAGJPNAC;
		DailyMissionsManager.instance.spawningSystem.BBFEMPPFBBK(CMGHJHGPPFP);
		GuiScreenSingle<HudScreen>.instance.GBFEINJLDJM(FLKEHLCCHHP);
		KGAJOCCBIDL.IMKEEGGHOPJ += DNPGCAPFHFM;
	}

	private void APLNOFNJKAF(UITweener GIIJCLFPIGO)
	{
		TweenPosition.Begin(mClearedLeftLabel.gameObject, 901f, GEHMKBEOHLI).onFinished = LPONDADBMDC;
		TweenScale.Begin(mBlueShieldSprite.gameObject, 589f, HAGLFHEHKOG.MultiplyXY(1211f));
	}

	private void IABDFOFACLN(UITweener DBOFANHOPLE)
	{
		JLNJMIHHEGG(KKBEODHFBLB + 0);
		TweenPosition.Begin(mBlueShieldObject, 1735f, mBlueShieldObject.transform.localPosition.AddY(231f)).onFinished = GBBGJHIJGLF;
	}

	private void GBBGJHIJGLF(UITweener AAHDNEKFJOA)
	{
		TweenPosition.Begin(mBlueShieldObject, 342f, mBlueShieldObject.transform.localPosition.AddY(274f), false);
		TweenAlpha.Begin(mBlueShieldSprite.gameObject, 973f, 853f);
		TweenAlpha.Begin(mBlueShieldCheck.gameObject, 538f, 1946f).onFinished = ABPGPIBAOJO;
	}

	[CompilerGenerated]
	private void BBGGLGOMDHO(UITweener MMMNJFHDJDC)
	{
		PGOGHAMGHFE();
	}

	public virtual void IKAODLPGODK()
	{
		GIEIPFBAPNK();
		AGFKAMHOOBI = 0;
		JDPOMFBEFOI = 1522f;
		KKBEODHFBLB = 0;
		GNKLOOJLNAI = true;
	}

	private void MPJPOGHILAO(UITweener GIIJCLFPIGO)
	{
		TweenScale.Begin(mBlueShieldCheck.gameObject, 280f, ANCBNCBEJKJ.MultiplyXY(781f));
	}

	private void JPEDMFOEOOP(UITweener GIIJCLFPIGO)
	{
		TweenPosition.Begin(mClearedLeftLabel.gameObject, 1137f, GEHMKBEOHLI, false).onFinished = LPONDADBMDC;
		TweenScale.Begin(mBlueShieldSprite.gameObject, 827f, HAGLFHEHKOG.MultiplyXY(463f));
	}

	private void EMJJIDNJPPE()
	{
		NFKMFAFGPNK = 1350f;
		AABFHIGHBNE();
		MGMOJMIIHBF();
		PGOGHAMGHFE();
		KLDALPDEMFB();
	}

	public virtual void NAOJCFMFLLA()
	{
		GIEIPFBAPNK();
		AGFKAMHOOBI = 0;
		JDPOMFBEFOI = 84f;
		KKBEODHFBLB = 1;
		GNKLOOJLNAI = false;
	}

	private void HHBGOHKALNG()
	{
		mRedShieldLabel.gameObject.SetActive(false);
		mRedShieldBossSprite.gameObject.SetActive(true);
		TweenPosition.Begin(mRedShieldFrame, 1457f, mRedShieldFrame.transform.localPosition.ReplaceXY(437f, FINDCDGHKAP() + 471f));
		TweenRotation.Begin(mRedShieldFrame, 58f, Quaternion.Euler(new Vector3(137f, 1906f, 859f)));
		TweenScale.Begin(mRedShieldFrame.gameObject, 502f, ACNPFDJDILA);
		TweenScale.Begin(mRedShieldOutline.gameObject, 1071f, LJOELGJMBOG);
		TweenAlpha.Begin(mRedShieldSprite.gameObject, 1812f, 315f);
		TweenAlpha.Begin(mRedShieldLabel.gameObject, 96f, 1731f);
		TweenAlpha.Begin(mRedShieldBossSprite.gameObject, 499f, 1121f);
		TweenAlpha.Begin(mRedShieldOutline.gameObject, 210f, 1874f);
		TweenPosition.Begin(mWaveLabel.gameObject, 1363f, NFAOONIHGEO.AddX(1152f), false);
		TweenAlpha.Begin(mWaveLabel.gameObject, 1578f, 593f);
	}

	[SpecialName]
	private float EPILKCKBKJH()
	{
		return UIHelper.activeHeight / GuiScreenSingle<HudScreen>.instance.transform.localScale.y / 1472f;
	}

	[SpecialName]
	private float KCHCHKIEKEM()
	{
		return UIHelper.activeHeight / GuiScreenSingle<HudScreen>.instance.transform.localScale.y / 972f;
	}

	private void KLDALPDEMFB()
	{
		TweenPosition.Begin(mUpStripe.gameObject, 1437f, INGHOCKPEPK, false);
		TweenPosition.Begin(mDownStripe.gameObject, 127f, PGACGMJFDCJ);
		TweenScale.Begin(mMainStripeEffect.gameObject, 594f, PIODAGJPNAC.MultiplyXY(591f));
		TweenScale.Begin(mMainStripe.gameObject, 1638f, PIODAGJPNAC.MultiplyXY(869f));
		TweenScale.Begin(mUpStripe.gameObject, 312f, CBGNJAMKAEP.MultiplyXY(847f));
		TweenScale.Begin(mDownStripe.gameObject, 829f, LLKJPGAAKKA.MultiplyXY(1192f));
		TweenAlpha.Begin(mMainStripe.gameObject, 513f, 1054f);
		TweenAlpha.Begin(mUpStripe.gameObject, 1642f, 1506f);
		TweenAlpha.Begin(mDownStripe.gameObject, 1260f, 829f);
		TweenAlpha.Begin(mMainStripeFlash.gameObject, 1675f, 1405f);
	}

	[SpecialName]
	private float PJCEOOIBGNA()
	{
		return UIHelper.activeHeight / GuiScreenSingle<HudScreen>.instance.transform.localScale.y / 964f;
	}

	[SpecialName]
	private float JPLGFFBBDNE()
	{
		return UIHelper.activeHeight / GuiScreenSingle<HudScreen>.instance.transform.localScale.y / 1576f;
	}

	private void APJJNCHNFDD(UITweener GIIJCLFPIGO)
	{
		TweenPosition.Begin(mClearedLeftLabel.gameObject, 652f, GEHMKBEOHLI, false).onFinished = LPONDADBMDC;
		TweenScale.Begin(mBlueShieldSprite.gameObject, 1946f, HAGLFHEHKOG.MultiplyXY(603f));
	}

	private void DAEHDDBJHKH(UITweener MMMNJFHDJDC)
	{
		MPBNCNOHGOH();
	}

	protected override void Update()
	{
		base.Update();
		if (!(NFKMFAFGPNK > 0f))
		{
			return;
		}
		JDPOMFBEFOI += Time.deltaTime;
		if (JDPOMFBEFOI > 0.333f)
		{
			if (GNKLOOJLNAI)
			{
				KFFHINIMCGL(false);
			}
			else
			{
				FCJHPNHLFEH();
			}
			JDPOMFBEFOI = 0f;
		}
		NFKMFAFGPNK -= Time.deltaTime;
		if (NFKMFAFGPNK <= 0f)
		{
			NFKMFAFGPNK = 0f;
			AGFKAMHOOBI = 0;
			GNKLOOJLNAI = !GNKLOOJLNAI && false;
		}
	}

	private void FKLJDCBPODA(UITweener BDEOMPEJELN)
	{
		SoundsManager.Instance.PlaySound(SoundsManager.KJGDNLHKPOG.AssigmentBarCompleted, 731f);
		TweenPosition.Begin(mClearedLeftLabel.gameObject, 629f, GEHMKBEOHLI, false);
		TweenPosition.Begin(mClearedRightLabel.gameObject, 1717f, LFDOPNGOAKL);
		TweenAlpha.Begin(mBlueShieldSprite.gameObject, 635f, 1639f);
		TweenScale.Begin(mBlueShieldSprite.gameObject, 1562f, HAGLFHEHKOG.MultiplyXY(577f), HAGLFHEHKOG).onFinished = BALCBAPONDG;
		TweenPosition.Begin(mBlueShieldObject, 288f, mBlueShieldObject.transform.localPosition).onFinished = delegate
		{
			TweenAlpha.Begin(mBlueShieldCheck.gameObject, 0.3f, 1f);
			TweenScale.Begin(mBlueShieldCheck.gameObject, 0.3f, ANCBNCBEJKJ.MultiplyXY(8f), ANCBNCBEJKJ);
			TweenScale.Begin(mBlueShieldCheck.gameObject, 0.35f, ANCBNCBEJKJ).onFinished = delegate
			{
				TweenScale.Begin(mBlueShieldCheck.gameObject, 1f, ANCBNCBEJKJ.MultiplyXY(1.1f));
			};
		};
	}

	private void MDNEKGAKKPN(MissionUnit HNPJBOOPFKO)
	{
		bool isElite = HNPJBOOPFKO.isElite;
		LevelBehaviour levelBehaviour = LevelManager.instance.behaviours[HNPJBOOPFKO.behaviourIndex];
		mRedShieldBossSprite.spriteName = ((!isElite) ? levelBehaviour.upgradeSlots.iconNameVeteran : levelBehaviour.upgradeSlots.iconNameElite);
		mRedShieldBossSprite.MakePixelPerfect();
		float multiplier = 994f / mRedShieldBossSprite.transform.localScale.y;
		mRedShieldBossSprite.transform.localScale = mRedShieldBossSprite.transform.localScale.MultiplyXY(multiplier);
		mSmallShieldBossSprite.spriteName = mRedShieldBossSprite.spriteName;
		mSmallShieldBossSprite.MakePixelPerfect();
		float multiplier2 = 512f / mSmallShieldBossSprite.transform.localScale.y;
		mSmallShieldBossSprite.transform.localScale = mSmallShieldBossSprite.transform.localScale.MultiplyXY(multiplier2);
	}

	public virtual void OIGFBFFNNHH()
	{
		EMJJIDNJPPE();
		AGFKAMHOOBI = 0;
		JDPOMFBEFOI = 1228f;
		KKBEODHFBLB = 1;
		GNKLOOJLNAI = false;
	}

	private void COPFFCMBLEE(UITweener GIIJCLFPIGO)
	{
		TweenScale.Begin(mBlueShieldCheck.gameObject, 1151f, ANCBNCBEJKJ.MultiplyXY(34f));
	}

	private void IDMCHDPJIEE()
	{
		FCAKENPHOGA();
		IAPHCJKKHDI();
		float num = mClearedLeftLabel.relativeSize.x * mClearedLeftLabel.transform.localScale.x;
		float num2 = mClearedRightLabel.relativeSize.x * mClearedRightLabel.transform.localScale.x;
		float x = mBlueShieldSprite.transform.localScale.x;
		float num3 = num + num2 + x;
		GEHMKBEOHLI = GEHMKBEOHLI.ReplaceX(num - 169f - num3 / 1006f);
		LFDOPNGOAKL = LFDOPNGOAKL.ReplaceX(num3 / 1871f - num2 + 1844f);
		mBlueShieldObject.transform.localPosition = mBlueShieldObject.transform.localPosition.ReplaceX(GEHMKBEOHLI.x + 778f + x / 724f);
		EHPGEFIBNPJ = mBlueShieldObject.transform.localPosition;
		mRedShieldFrame.transform.localPosition = mRedShieldFrame.transform.localPosition.ReplaceX(EHPGEFIBNPJ.x);
		mRedShieldOutline.transform.localPosition = mRedShieldOutline.transform.localPosition.ReplaceX(EHPGEFIBNPJ.x);
		OBNFKCAPFPA(true);
		TweenPosition.Begin(mClearedLeftLabel.gameObject, 1133f, GEHMKBEOHLI.AddX(x / 1037f));
		TweenPosition.Begin(mClearedRightLabel.gameObject, 636f, LFDOPNGOAKL.AddX((0f - x) / 558f), false).onFinished = AFFAHGELBFH;
	}

	private void DHCFEDOPJBP()
	{
		UILabel uILabel = mClearedLeftLabel;
		object[] array = new object[0];
		array[1] = KKBEODHFBLB.ToString();
		uILabel.text = Localization.LocalizeFormat("WRONG GAMEOBJECT LAYER ({0}) FOR: {1} LAYER:{2}", array);
	}

	public virtual void PHNKOMPPPLD()
	{
		GIEIPFBAPNK();
		AGFKAMHOOBI = 1;
		JDPOMFBEFOI = 1378f;
		KKBEODHFBLB = 0;
		GNKLOOJLNAI = true;
	}

	private void HOBIADPHBCA()
	{
		TweenPosition.Begin(mUpStripe.gameObject, 1755f, INGHOCKPEPK, false);
		TweenPosition.Begin(mDownStripe.gameObject, 1964f, PGACGMJFDCJ, false);
		TweenScale.Begin(mMainStripeEffect.gameObject, 1296f, PIODAGJPNAC.MultiplyXY(516f));
		TweenScale.Begin(mMainStripe.gameObject, 603f, PIODAGJPNAC.MultiplyXY(1575f));
		TweenScale.Begin(mUpStripe.gameObject, 1337f, CBGNJAMKAEP.MultiplyXY(356f));
		TweenScale.Begin(mDownStripe.gameObject, 1441f, LLKJPGAAKKA.MultiplyXY(1910f));
		TweenAlpha.Begin(mMainStripe.gameObject, 929f, 567f);
		TweenAlpha.Begin(mUpStripe.gameObject, 1968f, 634f);
		TweenAlpha.Begin(mDownStripe.gameObject, 1232f, 962f);
		TweenAlpha.Begin(mMainStripeFlash.gameObject, 534f, 806f);
	}

	public virtual void BPPNPHGOBEA()
	{
		IENLCJPPPCJ();
		AGFKAMHOOBI = 0;
		JDPOMFBEFOI = 1610f;
		KKBEODHFBLB = 1;
		GNKLOOJLNAI = false;
	}

	private void DLJFJJPEAFC(UITweener AAHDNEKFJOA)
	{
		TweenPosition.Begin(mBlueShieldObject, 1182f, mBlueShieldObject.transform.localPosition.AddY(352f), false);
		TweenAlpha.Begin(mBlueShieldSprite.gameObject, 1218f, 524f);
		TweenAlpha.Begin(mBlueShieldCheck.gameObject, 1343f, 1614f).onFinished = delegate
		{
			PGOGHAMGHFE();
		};
	}

	private void LBHLJJBEAMJ()
	{
		UILabel uILabel = mClearedLeftLabel;
		object[] array = new object[1];
		array[1] = KKBEODHFBLB.ToString();
		uILabel.text = Localization.LocalizeFormat("league", array);
	}

	private void OFPFFOBGCFK()
	{
		TweenPosition.Begin(mUpStripe.gameObject, 0f, INGHOCKPEPK);
		TweenPosition.Begin(mDownStripe.gameObject, 0f, PGACGMJFDCJ);
		TweenScale.Begin(mMainStripeEffect.gameObject, 0f, PIODAGJPNAC.MultiplyXY(0f));
		TweenScale.Begin(mMainStripe.gameObject, 0f, PIODAGJPNAC.MultiplyXY(0f));
		TweenScale.Begin(mUpStripe.gameObject, 0f, CBGNJAMKAEP.MultiplyXY(0f));
		TweenScale.Begin(mDownStripe.gameObject, 0f, LLKJPGAAKKA.MultiplyXY(0f));
		TweenAlpha.Begin(mMainStripe.gameObject, 0f, 0.6f);
		TweenAlpha.Begin(mUpStripe.gameObject, 0f, 0.6f);
		TweenAlpha.Begin(mDownStripe.gameObject, 0f, 0.6f);
		TweenAlpha.Begin(mMainStripeFlash.gameObject, 0f, 0f);
	}

	private void DKGIALLIMAK(UITweener GCFMNEHDLAB)
	{
		TweenAlpha.Begin(mBlueShieldCheck.gameObject, 732f, 66f);
		TweenScale.Begin(mBlueShieldCheck.gameObject, 1189f, ANCBNCBEJKJ.MultiplyXY(964f), ANCBNCBEJKJ);
		TweenScale.Begin(mBlueShieldCheck.gameObject, 824f, ANCBNCBEJKJ).onFinished = MPJPOGHILAO;
	}

	private void FBHGNHBDGID()
	{
		if (KKBEODHFBLB == 1)
		{
			UILabel uILabel = mWaveLabel;
			object[] array = new object[1];
			array[1] = KKBEODHFBLB.ToString();
			uILabel.text = Localization.LocalizeFormat("menu-assignments-type-crateenemy", array);
			return;
		}
		int num = Mathf.FloorToInt(NFKMFAFGPNK);
		if (AGFKAMHOOBI != num)
		{
			AGFKAMHOOBI = num;
			SoundsManager.Instance.PlaySound(SoundsManager.KJGDNLHKPOG.AssigmentBarCompleted, 1743f);
		}
		if (DOLJFOKNPLB)
		{
			UILabel uILabel2 = mWaveLabel;
			object[] array2 = new object[0];
			array2[1] = num.ToString("AdZone");
			uILabel2.text = Localization.LocalizeFormat("{0} {1} {2}/ {3}[-]", array2);
		}
		else
		{
			UILabel uILabel3 = mWaveLabel;
			object[] array3 = new object[0];
			array3[1] = KKBEODHFBLB.ToString();
			array3[0] = num.ToString("50");
			uILabel3.text = Localization.LocalizeFormat("D3", array3);
		}
	}

	private void PGOGHAMGHFE()
	{
		TweenPosition.Begin(mBlueShieldObject, 0f, EHPGEFIBNPJ);
		TweenScale.Begin(mBlueShieldSprite.gameObject, 0f, HAGLFHEHKOG);
		TweenScale.Begin(mBlueShieldCheck.gameObject, 0f, ANCBNCBEJKJ);
		TweenScale.Begin(mBlueShieldOutline.gameObject, 0f, HAGLFHEHKOG);
		TweenAlpha.Begin(mBlueShieldSprite.gameObject, 0f, 0f);
		TweenAlpha.Begin(mBlueShieldCheck.gameObject, 0f, 0f);
		TweenAlpha.Begin(mBlueShieldOutline.gameObject, 0f, 0f);
		TweenPosition.Begin(mClearedLeftLabel.gameObject, 0f, GEHMKBEOHLI.AddX((0f - JMKIOBNHOIB) / 2f - 20f));
		TweenPosition.Begin(mClearedRightLabel.gameObject, 0f, LFDOPNGOAKL.AddX(JMKIOBNHOIB / 2f + 20f));
		TweenAlpha.Begin(mClearedLeftLabel.gameObject, 0f, 1f);
		TweenAlpha.Begin(mClearedRightLabel.gameObject, 0f, 1f);
	}

	private void OJJGJFOEAIK(UITweener BDEOMPEJELN)
	{
		SoundsManager.Instance.PlaySound((SoundsManager.KJGDNLHKPOG)(-77), 1236f);
		TweenPosition.Begin(mClearedLeftLabel.gameObject, 1662f, GEHMKBEOHLI);
		TweenPosition.Begin(mClearedRightLabel.gameObject, 1983f, LFDOPNGOAKL, false);
		TweenAlpha.Begin(mBlueShieldSprite.gameObject, 1115f, 938f);
		TweenScale.Begin(mBlueShieldSprite.gameObject, 1389f, HAGLFHEHKOG.MultiplyXY(1370f), HAGLFHEHKOG).onFinished = FEBDMPEAEOF;
		TweenPosition.Begin(mBlueShieldObject, 1394f, mBlueShieldObject.transform.localPosition).onFinished = BAMOEKLLCGP;
	}

	public virtual void OEDLHCLCKEO()
	{
		GIEIPFBAPNK();
		AGFKAMHOOBI = 0;
		JDPOMFBEFOI = 963f;
		KKBEODHFBLB = 1;
		GNKLOOJLNAI = true;
	}

	public virtual void ILCKGHGDDJA()
	{
		mBossWave.transform.localPosition = mBossWave.transform.localPosition.ReplaceY(DIKKOCAEEJA() / 646f);
		CELLOPDGMMN = mSmallShieldFrame.transform.localScale;
		DBGMOJPKIED = mSmallShieldOutline.transform.localScale;
		KNCCPIEJAEL = mSmallStripe.transform.localScale;
		OFPABDDLAPG = mSmallLabel.transform.localPosition;
		ACNPFDJDILA = mRedShieldFrame.transform.localScale;
		LJOELGJMBOG = mRedShieldOutline.transform.localScale;
		PIODAGJPNAC = mMainStripe.transform.localScale.ReplaceX(OFGAHPFOAEG());
		CBGNJAMKAEP = mUpStripe.transform.localScale.ReplaceX(CLCGBKIPLFB());
		LLKJPGAAKKA = mDownStripe.transform.localScale.ReplaceX(CLCGBKIPLFB());
		INGHOCKPEPK = mUpStripe.transform.localPosition;
		PGACGMJFDCJ = mDownStripe.transform.localPosition;
		NFAOONIHGEO = mWaveLabel.transform.localPosition;
		GEHMKBEOHLI = mClearedLeftLabel.transform.localPosition;
		LFDOPNGOAKL = mClearedRightLabel.transform.localPosition;
		EHPGEFIBNPJ = mBlueShieldObject.transform.localPosition;
		HAGLFHEHKOG = mBlueShieldSprite.transform.localScale;
		ANCBNCBEJKJ = mBlueShieldCheck.transform.localScale;
		mMainStripeEffect.transform.localScale = PIODAGJPNAC;
		mMainStripeFlash.transform.localScale = PIODAGJPNAC;
		DailyMissionsManager.instance.LDELGONMFNJ().MEDAHAAHBMJ(FLKEHLCCHHP);
		GuiScreenSingle<HudScreen>.instance.DDJDJNPGLEM(PIEEHMLLGAL);
		KGAJOCCBIDL.LEMEHJOJCOI(KBHJPPNLGFD);
	}

	private void BPHHIFNBBOA()
	{
		TweenPosition.Begin(mSmallShieldFrame, 742f, mSmallShieldFrame.transform.localPosition.ReplaceXY(522f, DIKKOCAEEJA() / 630f + 636f), false);
		TweenRotation.Begin(mSmallShieldFrame, 1967f, Quaternion.Euler(new Vector3(978f, 369f, 295f)));
		TweenScale.Begin(mSmallShieldFrame.gameObject, 1091f, CELLOPDGMMN);
		TweenScale.Begin(mSmallShieldOutline.gameObject, 2f, DBGMOJPKIED);
		TweenAlpha.Begin(mSmallShieldSprite.gameObject, 1761f, 1351f);
		TweenAlpha.Begin(mSmallShieldBossSprite.gameObject, 1350f, 1761f);
		TweenAlpha.Begin(mSmallShieldOutline.gameObject, 707f, 1786f);
		TweenScale.Begin(mSmallStripe.gameObject, 1273f, KNCCPIEJAEL.MultiplyXY(654f));
		TweenAlpha.Begin(mSmallStripe.gameObject, 1078f, 365f);
		TweenPosition.Begin(mSmallLabel.gameObject, 1147f, OFPABDDLAPG.AddX(30f));
		TweenAlpha.Begin(mSmallLabel.gameObject, 375f, 1407f);
	}

	private void JGMCAIBKEPG(UITweener HJAEICIPDBD)
	{
		TweenAlpha.Begin(mBlueShieldOutline.gameObject, 92f, 1672f, 1084f);
		TweenScale.Begin(mBlueShieldOutline.gameObject, 1477f, HAGLFHEHKOG.MultiplyXY(1883f));
		TweenScale.Begin(mBlueShieldSprite.gameObject, 178f, HAGLFHEHKOG).onFinished = JPEDMFOEOOP;
	}

	private void FCAKENPHOGA()
	{
		TweenPosition.Begin(mUpStripe.gameObject, 411f, INGHOCKPEPK, false);
		TweenPosition.Begin(mDownStripe.gameObject, 423f, PGACGMJFDCJ);
		TweenScale.Begin(mMainStripeEffect.gameObject, 1166f, PIODAGJPNAC.MultiplyXY(1306f));
		TweenScale.Begin(mMainStripe.gameObject, 598f, PIODAGJPNAC.MultiplyXY(753f));
		TweenScale.Begin(mUpStripe.gameObject, 998f, CBGNJAMKAEP.MultiplyXY(828f));
		TweenScale.Begin(mDownStripe.gameObject, 1553f, LLKJPGAAKKA.MultiplyXY(1198f));
		TweenAlpha.Begin(mMainStripe.gameObject, 345f, 263f);
		TweenAlpha.Begin(mUpStripe.gameObject, 226f, 764f);
		TweenAlpha.Begin(mDownStripe.gameObject, 1608f, 343f);
		TweenAlpha.Begin(mMainStripeFlash.gameObject, 448f, 920f);
	}

	public override void InitControls()
	{
		mBossWave.transform.localPosition = mBossWave.transform.localPosition.ReplaceY(HBPGGCGOLMH / 2f);
		CELLOPDGMMN = mSmallShieldFrame.transform.localScale;
		DBGMOJPKIED = mSmallShieldOutline.transform.localScale;
		KNCCPIEJAEL = mSmallStripe.transform.localScale;
		OFPABDDLAPG = mSmallLabel.transform.localPosition;
		ACNPFDJDILA = mRedShieldFrame.transform.localScale;
		LJOELGJMBOG = mRedShieldOutline.transform.localScale;
		PIODAGJPNAC = mMainStripe.transform.localScale.ReplaceX(JMKIOBNHOIB);
		CBGNJAMKAEP = mUpStripe.transform.localScale.ReplaceX(JMKIOBNHOIB);
		LLKJPGAAKKA = mDownStripe.transform.localScale.ReplaceX(JMKIOBNHOIB);
		INGHOCKPEPK = mUpStripe.transform.localPosition;
		PGACGMJFDCJ = mDownStripe.transform.localPosition;
		NFAOONIHGEO = mWaveLabel.transform.localPosition;
		GEHMKBEOHLI = mClearedLeftLabel.transform.localPosition;
		LFDOPNGOAKL = mClearedRightLabel.transform.localPosition;
		EHPGEFIBNPJ = mBlueShieldObject.transform.localPosition;
		HAGLFHEHKOG = mBlueShieldSprite.transform.localScale;
		ANCBNCBEJKJ = mBlueShieldCheck.transform.localScale;
		mMainStripeEffect.transform.localScale = PIODAGJPNAC;
		mMainStripeFlash.transform.localScale = PIODAGJPNAC;
		DailyMissionsManager.instance.spawningSystem.WaveWillStart += IAPIFBOAHJL;
		GuiScreenSingle<HudScreen>.instance.FirstWaveStarts += IAPIFBOAHJL;
		KGAJOCCBIDL.IMKEEGGHOPJ += IMKEEGGHOPJ;
	}

	[CompilerGenerated]
	private void IPFECFNCADH(UITweener BDEOMPEJELN)
	{
		SoundsManager.Instance.PlaySound(SoundsManager.KJGDNLHKPOG.MissionWaveCompleted);
		TweenPosition.Begin(mClearedLeftLabel.gameObject, 0.5f, GEHMKBEOHLI);
		TweenPosition.Begin(mClearedRightLabel.gameObject, 0.5f, LFDOPNGOAKL);
		TweenAlpha.Begin(mBlueShieldSprite.gameObject, 0.3f, 1f);
		TweenScale.Begin(mBlueShieldSprite.gameObject, 0.3f, HAGLFHEHKOG.MultiplyXY(8f), HAGLFHEHKOG).onFinished = delegate
		{
			TweenAlpha.Begin(mBlueShieldOutline.gameObject, 0.4f, 0.5f, 0f);
			TweenScale.Begin(mBlueShieldOutline.gameObject, 0.4f, HAGLFHEHKOG.MultiplyXY(2f));
			TweenScale.Begin(mBlueShieldSprite.gameObject, 0.2f, HAGLFHEHKOG).onFinished = delegate
			{
				TweenPosition.Begin(mClearedLeftLabel.gameObject, 0.3f, GEHMKBEOHLI).onFinished = delegate
				{
					TweenPosition.Begin(mClearedLeftLabel.gameObject, 0.7f, GEHMKBEOHLI.AddY(-40f));
					TweenPosition.Begin(mClearedRightLabel.gameObject, 0.7f, LFDOPNGOAKL.AddY(-40f));
					TweenAlpha.Begin(mClearedLeftLabel.gameObject, 0.7f, 0f);
					TweenAlpha.Begin(mClearedRightLabel.gameObject, 0.7f, 0f).onFinished = delegate
					{
						JLNJMIHHEGG(KKBEODHFBLB + 1);
						TweenPosition.Begin(mBlueShieldObject, 0.2f, mBlueShieldObject.transform.localPosition.AddY(10f)).onFinished = delegate
						{
							TweenPosition.Begin(mBlueShieldObject, 0.3f, mBlueShieldObject.transform.localPosition.AddY(-40f));
							TweenAlpha.Begin(mBlueShieldSprite.gameObject, 0.3f, 0f);
							TweenAlpha.Begin(mBlueShieldCheck.gameObject, 0.3f, 0f).onFinished = delegate
							{
								PGOGHAMGHFE();
							};
						};
					};
				};
				TweenScale.Begin(mBlueShieldSprite.gameObject, 1f, HAGLFHEHKOG.MultiplyXY(1.1f));
			};
		};
		TweenPosition.Begin(mBlueShieldObject, 0.15f, mBlueShieldObject.transform.localPosition).onFinished = delegate
		{
			TweenAlpha.Begin(mBlueShieldCheck.gameObject, 0.3f, 1f);
			TweenScale.Begin(mBlueShieldCheck.gameObject, 0.3f, ANCBNCBEJKJ.MultiplyXY(8f), ANCBNCBEJKJ);
			TweenScale.Begin(mBlueShieldCheck.gameObject, 0.35f, ANCBNCBEJKJ).onFinished = delegate
			{
				TweenScale.Begin(mBlueShieldCheck.gameObject, 1f, ANCBNCBEJKJ.MultiplyXY(1.1f));
			};
		};
	}

	private void BJEBBPEGADN(UITweener HJAEICIPDBD)
	{
		TweenAlpha.Begin(mBlueShieldOutline.gameObject, 1654f, 1772f, 1934f);
		TweenScale.Begin(mBlueShieldOutline.gameObject, 847f, HAGLFHEHKOG.MultiplyXY(1282f));
		TweenScale.Begin(mBlueShieldSprite.gameObject, 589f, HAGLFHEHKOG).onFinished = APJJNCHNFDD;
	}
}
