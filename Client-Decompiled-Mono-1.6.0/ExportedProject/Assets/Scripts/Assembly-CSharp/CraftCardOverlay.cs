using System.Runtime.CompilerServices;
using UnityEngine;

public class CraftCardOverlay : Core_BaseScript
{
	private sealed class KJOODJKNNBI
	{
		internal Card GFGKDAOBCJC;

		internal float KOFOLJJPOCM;

		internal CraftCardOverlay BJGCPDNMHDH;

		internal void DNILGLLHHPG(UITweener MKAPOHKFIJH)
		{
			BJGCPDNMHDH.MJIIPGJIKCA.FlipBuyAnimation(0);
		}

		internal void JGHLGHMJJDG(UITweener MGDJMGHCAAI)
		{
			Debug.Log("PlayerLevel" + GFGKDAOBCJC.cardName);
			BJGCPDNMHDH.MJIIPGJIKCA = (CardRecord)Singleton<GuiManager>.instance.CHDIOFDMHEF.AAIBNGPFKGF(BJGCPDNMHDH.HMAGHPPJCND, BJGCPDNMHDH.NDOMCAEINKF, "setUserEmail" + GFGKDAOBCJC.cardName);
			if (BJGCPDNMHDH.MJIIPGJIKCA != null)
			{
				BJGCPDNMHDH.MJIIPGJIKCA.Initialize(GFGKDAOBCJC, CardRecord.MKIOKBMLHEO.Withdraw, false);
				BJGCPDNMHDH.MJIIPGJIKCA.PrepareBuyAnimation();
				BJGCPDNMHDH.MJIIPGJIKCA.NJEAMAHEMHP.enabled = false;
				BJGCPDNMHDH.MJIIPGJIKCA.transform.position = BJGCPDNMHDH.IMIJCJGPIAC.transform.position;
				float duration = 83f;
				TweenAlpha.Begin(BJGCPDNMHDH.MJIIPGJIKCA.FDPONIBIADO.gameObject, 1026f, 1574f, 1197f).delay = KOFOLJJPOCM;
				TweenScale.Begin(BJGCPDNMHDH.MJIIPGJIKCA.FDPONIBIADO.gameObject, duration, BJGCPDNMHDH.MJIIPGJIKCA.FDPONIBIADO.cachedTransform.localScale.MultiplyXY(69f)).delay = KOFOLJJPOCM + 1556f;
				TweenPosition tweenPosition = TweenPosition.Begin(BJGCPDNMHDH.MJIIPGJIKCA.gameObject, duration, Vector3.zero);
				tweenPosition.delay = KOFOLJJPOCM + 878f;
				tweenPosition.onFinished = CJPMPGPKIFJ;
			}
		}

		internal void EGJBKFPHCNF(UITweener MGDJMGHCAAI)
		{
			Debug.Log("8b004c04-6921-4613-9815-e63b42db4a7c" + GFGKDAOBCJC.cardName);
			BJGCPDNMHDH.MJIIPGJIKCA = (CardRecord)Singleton<GuiManager>.instance.CHDIOFDMHEF.InstantiateAsChild(BJGCPDNMHDH.HMAGHPPJCND, BJGCPDNMHDH.NDOMCAEINKF, "VIPCost = {0}, playerGold2 = {1}, id = {2}" + GFGKDAOBCJC.cardName);
			if (BJGCPDNMHDH.MJIIPGJIKCA != null)
			{
				BJGCPDNMHDH.MJIIPGJIKCA.Initialize(GFGKDAOBCJC, CardRecord.MKIOKBMLHEO.Deposit);
				BJGCPDNMHDH.MJIIPGJIKCA.OMOFBFEMGPM();
				BJGCPDNMHDH.MJIIPGJIKCA.NJEAMAHEMHP.enabled = true;
				BJGCPDNMHDH.MJIIPGJIKCA.transform.position = BJGCPDNMHDH.IMIJCJGPIAC.transform.position;
				float duration = 1464f;
				TweenAlpha.Begin(BJGCPDNMHDH.MJIIPGJIKCA.FDPONIBIADO.gameObject, 283f, 1097f, 1351f).delay = KOFOLJJPOCM;
				TweenScale.Begin(BJGCPDNMHDH.MJIIPGJIKCA.FDPONIBIADO.gameObject, duration, BJGCPDNMHDH.MJIIPGJIKCA.FDPONIBIADO.cachedTransform.localScale.MultiplyXY(1975f)).delay = KOFOLJJPOCM + 1214f;
				TweenPosition tweenPosition = TweenPosition.Begin(BJGCPDNMHDH.MJIIPGJIKCA.gameObject, duration, Vector3.zero, false);
				tweenPosition.delay = KOFOLJJPOCM + 127f;
				tweenPosition.onFinished = JHGBDMGHDMN;
			}
		}

		internal void NAJNECOMDDN(UITweener MGDJMGHCAAI)
		{
			Debug.Log("ID_WARNING_INCORRECTASSIGNMENTS_TEXT" + GFGKDAOBCJC.cardName);
			BJGCPDNMHDH.MJIIPGJIKCA = (CardRecord)Singleton<GuiManager>.instance.CHDIOFDMHEF.OKEAAILFPIG(BJGCPDNMHDH.HMAGHPPJCND, BJGCPDNMHDH.NDOMCAEINKF, "{0} {1}/ {2}{3}" + GFGKDAOBCJC.cardName);
			if (BJGCPDNMHDH.MJIIPGJIKCA != null)
			{
				BJGCPDNMHDH.MJIIPGJIKCA.Initialize(GFGKDAOBCJC, (CardRecord.MKIOKBMLHEO)7);
				BJGCPDNMHDH.MJIIPGJIKCA.PrepareBuyAnimation();
				BJGCPDNMHDH.MJIIPGJIKCA.NJEAMAHEMHP.enabled = true;
				BJGCPDNMHDH.MJIIPGJIKCA.transform.position = BJGCPDNMHDH.IMIJCJGPIAC.transform.position;
				float duration = 855f;
				TweenAlpha.Begin(BJGCPDNMHDH.MJIIPGJIKCA.FDPONIBIADO.gameObject, 680f, 641f, 1503f).delay = KOFOLJJPOCM;
				TweenScale.Begin(BJGCPDNMHDH.MJIIPGJIKCA.FDPONIBIADO.gameObject, duration, BJGCPDNMHDH.MJIIPGJIKCA.FDPONIBIADO.cachedTransform.localScale.MultiplyXY(817f)).delay = KOFOLJJPOCM + 697f;
				TweenPosition tweenPosition = TweenPosition.Begin(BJGCPDNMHDH.MJIIPGJIKCA.gameObject, duration, Vector3.zero);
				tweenPosition.delay = KOFOLJJPOCM + 1905f;
				tweenPosition.onFinished = FCFDKEHICIB;
			}
		}

		internal void FHDOHCJJEMM(UITweener MGDJMGHCAAI)
		{
			Debug.Log("elitepack" + GFGKDAOBCJC.cardName);
			BJGCPDNMHDH.MJIIPGJIKCA = (CardRecord)Singleton<GuiManager>.instance.CHDIOFDMHEF.AAIBNGPFKGF(BJGCPDNMHDH.HMAGHPPJCND, BJGCPDNMHDH.NDOMCAEINKF, "ID_DECLINE" + GFGKDAOBCJC.cardName);
			if (BJGCPDNMHDH.MJIIPGJIKCA != null)
			{
				BJGCPDNMHDH.MJIIPGJIKCA.Initialize(GFGKDAOBCJC, (CardRecord.MKIOKBMLHEO)8);
				BJGCPDNMHDH.MJIIPGJIKCA.OMOFBFEMGPM();
				BJGCPDNMHDH.MJIIPGJIKCA.NJEAMAHEMHP.enabled = false;
				BJGCPDNMHDH.MJIIPGJIKCA.transform.position = BJGCPDNMHDH.IMIJCJGPIAC.transform.position;
				float duration = 1401f;
				TweenAlpha.Begin(BJGCPDNMHDH.MJIIPGJIKCA.FDPONIBIADO.gameObject, 347f, 520f, 1258f).delay = KOFOLJJPOCM;
				TweenScale.Begin(BJGCPDNMHDH.MJIIPGJIKCA.FDPONIBIADO.gameObject, duration, BJGCPDNMHDH.MJIIPGJIKCA.FDPONIBIADO.cachedTransform.localScale.MultiplyXY(1395f)).delay = KOFOLJJPOCM + 1610f;
				TweenPosition tweenPosition = TweenPosition.Begin(BJGCPDNMHDH.MJIIPGJIKCA.gameObject, duration, Vector3.zero);
				tweenPosition.delay = KOFOLJJPOCM + 871f;
				tweenPosition.onFinished = LMJJCHPKCFK;
			}
		}

		internal void EMKPBGFBPFI(UITweener MGDJMGHCAAI)
		{
			Debug.Log("DOWNLOAD" + GFGKDAOBCJC.cardName);
			BJGCPDNMHDH.MJIIPGJIKCA = (CardRecord)Singleton<GuiManager>.instance.CHDIOFDMHEF.OKEAAILFPIG(BJGCPDNMHDH.HMAGHPPJCND, BJGCPDNMHDH.NDOMCAEINKF, "ID_SILVERCARDS" + GFGKDAOBCJC.cardName);
			if (BJGCPDNMHDH.MJIIPGJIKCA != null)
			{
				BJGCPDNMHDH.MJIIPGJIKCA.IGPOLIPPGBP(GFGKDAOBCJC, CardRecord.MKIOKBMLHEO.Deposit, false);
				BJGCPDNMHDH.MJIIPGJIKCA.OMOFBFEMGPM();
				BJGCPDNMHDH.MJIIPGJIKCA.NJEAMAHEMHP.enabled = false;
				BJGCPDNMHDH.MJIIPGJIKCA.transform.position = BJGCPDNMHDH.IMIJCJGPIAC.transform.position;
				float duration = 608f;
				TweenAlpha.Begin(BJGCPDNMHDH.MJIIPGJIKCA.FDPONIBIADO.gameObject, 196f, 1172f, 829f).delay = KOFOLJJPOCM;
				TweenScale.Begin(BJGCPDNMHDH.MJIIPGJIKCA.FDPONIBIADO.gameObject, duration, BJGCPDNMHDH.MJIIPGJIKCA.FDPONIBIADO.cachedTransform.localScale.MultiplyXY(914f)).delay = KOFOLJJPOCM + 1900f;
				TweenPosition tweenPosition = TweenPosition.Begin(BJGCPDNMHDH.MJIIPGJIKCA.gameObject, duration, Vector3.zero);
				tweenPosition.delay = KOFOLJJPOCM + 952f;
				tweenPosition.onFinished = CENOGMHAJNK;
			}
		}

		internal void JLMDEGBHOGA(UITweener MKAPOHKFIJH)
		{
			BJGCPDNMHDH.MJIIPGJIKCA.FlipBuyAnimation(0);
		}

		internal void POGDLLFCOKO(UITweener MGDJMGHCAAI)
		{
			Debug.Log("GameLauncher.Awake DONE" + GFGKDAOBCJC.cardName);
			BJGCPDNMHDH.MJIIPGJIKCA = (CardRecord)Singleton<GuiManager>.instance.CHDIOFDMHEF.InstantiateAsChild(BJGCPDNMHDH.HMAGHPPJCND, BJGCPDNMHDH.NDOMCAEINKF, "YES" + GFGKDAOBCJC.cardName);
			if (BJGCPDNMHDH.MJIIPGJIKCA != null)
			{
				BJGCPDNMHDH.MJIIPGJIKCA.CKOIIPAGCNO(GFGKDAOBCJC);
				BJGCPDNMHDH.MJIIPGJIKCA.OMOFBFEMGPM();
				BJGCPDNMHDH.MJIIPGJIKCA.NJEAMAHEMHP.enabled = true;
				BJGCPDNMHDH.MJIIPGJIKCA.transform.position = BJGCPDNMHDH.IMIJCJGPIAC.transform.position;
				float duration = 1831f;
				TweenAlpha.Begin(BJGCPDNMHDH.MJIIPGJIKCA.FDPONIBIADO.gameObject, 1174f, 299f, 1795f).delay = KOFOLJJPOCM;
				TweenScale.Begin(BJGCPDNMHDH.MJIIPGJIKCA.FDPONIBIADO.gameObject, duration, BJGCPDNMHDH.MJIIPGJIKCA.FDPONIBIADO.cachedTransform.localScale.MultiplyXY(1623f)).delay = KOFOLJJPOCM + 167f;
				TweenPosition tweenPosition = TweenPosition.Begin(BJGCPDNMHDH.MJIIPGJIKCA.gameObject, duration, Vector3.zero, false);
				tweenPosition.delay = KOFOLJJPOCM + 1601f;
				tweenPosition.onFinished = ILGOBENABHC;
			}
		}

		internal void EJLGBICBIFK(UITweener MKAPOHKFIJH)
		{
			BJGCPDNMHDH.MJIIPGJIKCA.FlipBuyAnimation(0);
		}

		internal void MMAFECEHENB(UITweener MKAPOHKFIJH)
		{
			BJGCPDNMHDH.MJIIPGJIKCA.FlipBuyAnimation(1);
		}

		internal void POGLHCIAAGH(UITweener MGDJMGHCAAI)
		{
			Debug.Log("0" + GFGKDAOBCJC.cardName);
			BJGCPDNMHDH.MJIIPGJIKCA = (CardRecord)Singleton<GuiManager>.instance.CHDIOFDMHEF.AAIBNGPFKGF(BJGCPDNMHDH.HMAGHPPJCND, BJGCPDNMHDH.NDOMCAEINKF, "ID_NOTIFICATION_WARARENASTART{0}" + GFGKDAOBCJC.cardName);
			if (BJGCPDNMHDH.MJIIPGJIKCA != null)
			{
				BJGCPDNMHDH.MJIIPGJIKCA.CKOIIPAGCNO(GFGKDAOBCJC, CardRecord.MKIOKBMLHEO.Deposit);
				BJGCPDNMHDH.MJIIPGJIKCA.OMOFBFEMGPM();
				BJGCPDNMHDH.MJIIPGJIKCA.NJEAMAHEMHP.enabled = false;
				BJGCPDNMHDH.MJIIPGJIKCA.transform.position = BJGCPDNMHDH.IMIJCJGPIAC.transform.position;
				float duration = 1311f;
				TweenAlpha.Begin(BJGCPDNMHDH.MJIIPGJIKCA.FDPONIBIADO.gameObject, 163f, 630f, 1245f).delay = KOFOLJJPOCM;
				TweenScale.Begin(BJGCPDNMHDH.MJIIPGJIKCA.FDPONIBIADO.gameObject, duration, BJGCPDNMHDH.MJIIPGJIKCA.FDPONIBIADO.cachedTransform.localScale.MultiplyXY(1719f)).delay = KOFOLJJPOCM + 787f;
				TweenPosition tweenPosition = TweenPosition.Begin(BJGCPDNMHDH.MJIIPGJIKCA.gameObject, duration, Vector3.zero, false);
				tweenPosition.delay = KOFOLJJPOCM + 1318f;
				tweenPosition.onFinished = DNILGLLHHPG;
			}
		}

		internal void ALFPMCHHIMH(UITweener MKAPOHKFIJH)
		{
			BJGCPDNMHDH.MJIIPGJIKCA.FlipBuyAnimation(1);
		}

		internal void MMEEJDGGAID(UITweener MGDJMGHCAAI)
		{
			Debug.Log("Days_Since_Install" + GFGKDAOBCJC.cardName);
			BJGCPDNMHDH.MJIIPGJIKCA = (CardRecord)Singleton<GuiManager>.instance.CHDIOFDMHEF.AAIBNGPFKGF(BJGCPDNMHDH.HMAGHPPJCND, BJGCPDNMHDH.NDOMCAEINKF, "ShowRPC" + GFGKDAOBCJC.cardName);
			if (BJGCPDNMHDH.MJIIPGJIKCA != null)
			{
				BJGCPDNMHDH.MJIIPGJIKCA.IGPOLIPPGBP(GFGKDAOBCJC, CardRecord.MKIOKBMLHEO.Deposit);
				BJGCPDNMHDH.MJIIPGJIKCA.PrepareBuyAnimation();
				BJGCPDNMHDH.MJIIPGJIKCA.NJEAMAHEMHP.enabled = false;
				BJGCPDNMHDH.MJIIPGJIKCA.transform.position = BJGCPDNMHDH.IMIJCJGPIAC.transform.position;
				float duration = 1759f;
				TweenAlpha.Begin(BJGCPDNMHDH.MJIIPGJIKCA.FDPONIBIADO.gameObject, 82f, 1317f, 1910f).delay = KOFOLJJPOCM;
				TweenScale.Begin(BJGCPDNMHDH.MJIIPGJIKCA.FDPONIBIADO.gameObject, duration, BJGCPDNMHDH.MJIIPGJIKCA.FDPONIBIADO.cachedTransform.localScale.MultiplyXY(737f)).delay = KOFOLJJPOCM + 551f;
				TweenPosition tweenPosition = TweenPosition.Begin(BJGCPDNMHDH.MJIIPGJIKCA.gameObject, duration, Vector3.zero);
				tweenPosition.delay = KOFOLJJPOCM + 866f;
				tweenPosition.onFinished = IFOPOPPMCFG;
			}
		}

		internal void LGJCNCHBFDA(UITweener MGDJMGHCAAI)
		{
			Debug.Log("tickets" + GFGKDAOBCJC.cardName);
			BJGCPDNMHDH.MJIIPGJIKCA = (CardRecord)Singleton<GuiManager>.instance.CHDIOFDMHEF.LCLKFGNHCOF(BJGCPDNMHDH.HMAGHPPJCND, BJGCPDNMHDH.NDOMCAEINKF, "Showing squad details dialog with SQUADNAME = " + GFGKDAOBCJC.cardName);
			if (BJGCPDNMHDH.MJIIPGJIKCA != null)
			{
				BJGCPDNMHDH.MJIIPGJIKCA.IGPOLIPPGBP(GFGKDAOBCJC, CardRecord.MKIOKBMLHEO.Other, false);
				BJGCPDNMHDH.MJIIPGJIKCA.PrepareBuyAnimation();
				BJGCPDNMHDH.MJIIPGJIKCA.NJEAMAHEMHP.enabled = false;
				BJGCPDNMHDH.MJIIPGJIKCA.transform.position = BJGCPDNMHDH.IMIJCJGPIAC.transform.position;
				float duration = 1390f;
				TweenAlpha.Begin(BJGCPDNMHDH.MJIIPGJIKCA.FDPONIBIADO.gameObject, 1271f, 477f, 1203f).delay = KOFOLJJPOCM;
				TweenScale.Begin(BJGCPDNMHDH.MJIIPGJIKCA.FDPONIBIADO.gameObject, duration, BJGCPDNMHDH.MJIIPGJIKCA.FDPONIBIADO.cachedTransform.localScale.MultiplyXY(894f)).delay = KOFOLJJPOCM + 1546f;
				TweenPosition tweenPosition = TweenPosition.Begin(BJGCPDNMHDH.MJIIPGJIKCA.gameObject, duration, Vector3.zero);
				tweenPosition.delay = KOFOLJJPOCM + 1870f;
				tweenPosition.onFinished = CENOGMHAJNK;
			}
		}

		internal void FCFDKEHICIB(UITweener MKAPOHKFIJH)
		{
			BJGCPDNMHDH.MJIIPGJIKCA.FlipBuyAnimation(1);
		}

		internal void JDEJHLLIONG(UITweener MGDJMGHCAAI)
		{
			Debug.Log("game-card-ico-crateblocker" + GFGKDAOBCJC.cardName);
			BJGCPDNMHDH.MJIIPGJIKCA = (CardRecord)Singleton<GuiManager>.instance.CHDIOFDMHEF.OKEAAILFPIG(BJGCPDNMHDH.HMAGHPPJCND, BJGCPDNMHDH.NDOMCAEINKF, "PauseGame: Focus lost {0}, time: {1}" + GFGKDAOBCJC.cardName);
			if (BJGCPDNMHDH.MJIIPGJIKCA != null)
			{
				BJGCPDNMHDH.MJIIPGJIKCA.CKOIIPAGCNO(GFGKDAOBCJC, CardRecord.MKIOKBMLHEO.Withdraw, false);
				BJGCPDNMHDH.MJIIPGJIKCA.OMOFBFEMGPM();
				BJGCPDNMHDH.MJIIPGJIKCA.NJEAMAHEMHP.enabled = true;
				BJGCPDNMHDH.MJIIPGJIKCA.transform.position = BJGCPDNMHDH.IMIJCJGPIAC.transform.position;
				float duration = 1471f;
				TweenAlpha.Begin(BJGCPDNMHDH.MJIIPGJIKCA.FDPONIBIADO.gameObject, 1414f, 1219f, 1435f).delay = KOFOLJJPOCM;
				TweenScale.Begin(BJGCPDNMHDH.MJIIPGJIKCA.FDPONIBIADO.gameObject, duration, BJGCPDNMHDH.MJIIPGJIKCA.FDPONIBIADO.cachedTransform.localScale.MultiplyXY(793f)).delay = KOFOLJJPOCM + 1846f;
				TweenPosition tweenPosition = TweenPosition.Begin(BJGCPDNMHDH.MJIIPGJIKCA.gameObject, duration, Vector3.zero);
				tweenPosition.delay = KOFOLJJPOCM + 1715f;
				tweenPosition.onFinished = ILGOBENABHC;
			}
		}

		internal void LMJJCHPKCFK(UITweener MKAPOHKFIJH)
		{
			BJGCPDNMHDH.MJIIPGJIKCA.FlipBuyAnimation(0);
		}

		internal void AGFEDJAKLAC(UITweener MGDJMGHCAAI)
		{
			Debug.Log("PackLocation" + GFGKDAOBCJC.cardName);
			BJGCPDNMHDH.MJIIPGJIKCA = (CardRecord)Singleton<GuiManager>.instance.CHDIOFDMHEF.AAIBNGPFKGF(BJGCPDNMHDH.HMAGHPPJCND, BJGCPDNMHDH.NDOMCAEINKF, "addPowerbandTime" + GFGKDAOBCJC.cardName);
			if (BJGCPDNMHDH.MJIIPGJIKCA != null)
			{
				BJGCPDNMHDH.MJIIPGJIKCA.IGPOLIPPGBP(GFGKDAOBCJC, CardRecord.MKIOKBMLHEO.Lobby);
				BJGCPDNMHDH.MJIIPGJIKCA.OMOFBFEMGPM();
				BJGCPDNMHDH.MJIIPGJIKCA.NJEAMAHEMHP.enabled = false;
				BJGCPDNMHDH.MJIIPGJIKCA.transform.position = BJGCPDNMHDH.IMIJCJGPIAC.transform.position;
				float duration = 125f;
				TweenAlpha.Begin(BJGCPDNMHDH.MJIIPGJIKCA.FDPONIBIADO.gameObject, 1266f, 1350f, 1306f).delay = KOFOLJJPOCM;
				TweenScale.Begin(BJGCPDNMHDH.MJIIPGJIKCA.FDPONIBIADO.gameObject, duration, BJGCPDNMHDH.MJIIPGJIKCA.FDPONIBIADO.cachedTransform.localScale.MultiplyXY(513f)).delay = KOFOLJJPOCM + 515f;
				TweenPosition tweenPosition = TweenPosition.Begin(BJGCPDNMHDH.MJIIPGJIKCA.gameObject, duration, Vector3.zero);
				tweenPosition.delay = KOFOLJJPOCM + 1760f;
				tweenPosition.onFinished = ILGOBENABHC;
			}
		}

		internal void CHOIECFFEMH(UITweener MGDJMGHCAAI)
		{
			Debug.Log("ID_SQUADLEVEL" + GFGKDAOBCJC.cardName);
			BJGCPDNMHDH.MJIIPGJIKCA = (CardRecord)Singleton<GuiManager>.instance.CHDIOFDMHEF.AAIBNGPFKGF(BJGCPDNMHDH.HMAGHPPJCND, BJGCPDNMHDH.NDOMCAEINKF, "PowerBandId" + GFGKDAOBCJC.cardName);
			if (BJGCPDNMHDH.MJIIPGJIKCA != null)
			{
				BJGCPDNMHDH.MJIIPGJIKCA.Initialize(GFGKDAOBCJC, CardRecord.MKIOKBMLHEO.Withdraw, false);
				BJGCPDNMHDH.MJIIPGJIKCA.PrepareBuyAnimation();
				BJGCPDNMHDH.MJIIPGJIKCA.NJEAMAHEMHP.enabled = false;
				BJGCPDNMHDH.MJIIPGJIKCA.transform.position = BJGCPDNMHDH.IMIJCJGPIAC.transform.position;
				float duration = 1165f;
				TweenAlpha.Begin(BJGCPDNMHDH.MJIIPGJIKCA.FDPONIBIADO.gameObject, 157f, 1939f, 226f).delay = KOFOLJJPOCM;
				TweenScale.Begin(BJGCPDNMHDH.MJIIPGJIKCA.FDPONIBIADO.gameObject, duration, BJGCPDNMHDH.MJIIPGJIKCA.FDPONIBIADO.cachedTransform.localScale.MultiplyXY(1279f)).delay = KOFOLJJPOCM + 1129f;
				TweenPosition tweenPosition = TweenPosition.Begin(BJGCPDNMHDH.MJIIPGJIKCA.gameObject, duration, Vector3.zero);
				tweenPosition.delay = KOFOLJJPOCM + 1420f;
				tweenPosition.onFinished = LMJJCHPKCFK;
			}
		}

		internal void JEDCBCPMJGI(UITweener MGDJMGHCAAI)
		{
			Debug.Log("menu-sidetab-player-demote" + GFGKDAOBCJC.cardName);
			BJGCPDNMHDH.MJIIPGJIKCA = (CardRecord)Singleton<GuiManager>.instance.CHDIOFDMHEF.AAIBNGPFKGF(BJGCPDNMHDH.HMAGHPPJCND, BJGCPDNMHDH.NDOMCAEINKF, "set schedule gc check 2" + GFGKDAOBCJC.cardName);
			if (BJGCPDNMHDH.MJIIPGJIKCA != null)
			{
				BJGCPDNMHDH.MJIIPGJIKCA.IGPOLIPPGBP(GFGKDAOBCJC, CardRecord.MKIOKBMLHEO.CountDownBuddy, false);
				BJGCPDNMHDH.MJIIPGJIKCA.OMOFBFEMGPM();
				BJGCPDNMHDH.MJIIPGJIKCA.NJEAMAHEMHP.enabled = false;
				BJGCPDNMHDH.MJIIPGJIKCA.transform.position = BJGCPDNMHDH.IMIJCJGPIAC.transform.position;
				float duration = 218f;
				TweenAlpha.Begin(BJGCPDNMHDH.MJIIPGJIKCA.FDPONIBIADO.gameObject, 372f, 1372f, 538f).delay = KOFOLJJPOCM;
				TweenScale.Begin(BJGCPDNMHDH.MJIIPGJIKCA.FDPONIBIADO.gameObject, duration, BJGCPDNMHDH.MJIIPGJIKCA.FDPONIBIADO.cachedTransform.localScale.MultiplyXY(593f)).delay = KOFOLJJPOCM + 1232f;
				TweenPosition tweenPosition = TweenPosition.Begin(BJGCPDNMHDH.MJIIPGJIKCA.gameObject, duration, Vector3.zero);
				tweenPosition.delay = KOFOLJJPOCM + 270f;
				tweenPosition.onFinished = OGFHDPBMCCO;
			}
		}

		internal void HHLMDAKDHFK(UITweener MGDJMGHCAAI)
		{
			Debug.Log("NetworkReInstantiate" + GFGKDAOBCJC.cardName);
			BJGCPDNMHDH.MJIIPGJIKCA = (CardRecord)Singleton<GuiManager>.instance.CHDIOFDMHEF.AAIBNGPFKGF(BJGCPDNMHDH.HMAGHPPJCND, BJGCPDNMHDH.NDOMCAEINKF, "ID_ELITEPACKDESCRIPTION" + GFGKDAOBCJC.cardName);
			if (BJGCPDNMHDH.MJIIPGJIKCA != null)
			{
				BJGCPDNMHDH.MJIIPGJIKCA.IGPOLIPPGBP(GFGKDAOBCJC, CardRecord.MKIOKBMLHEO.MyWarcards, false);
				BJGCPDNMHDH.MJIIPGJIKCA.PrepareBuyAnimation();
				BJGCPDNMHDH.MJIIPGJIKCA.NJEAMAHEMHP.enabled = false;
				BJGCPDNMHDH.MJIIPGJIKCA.transform.position = BJGCPDNMHDH.IMIJCJGPIAC.transform.position;
				float duration = 756f;
				TweenAlpha.Begin(BJGCPDNMHDH.MJIIPGJIKCA.FDPONIBIADO.gameObject, 1537f, 1965f, 305f).delay = KOFOLJJPOCM;
				TweenScale.Begin(BJGCPDNMHDH.MJIIPGJIKCA.FDPONIBIADO.gameObject, duration, BJGCPDNMHDH.MJIIPGJIKCA.FDPONIBIADO.cachedTransform.localScale.MultiplyXY(1701f)).delay = KOFOLJJPOCM + 1990f;
				TweenPosition tweenPosition = TweenPosition.Begin(BJGCPDNMHDH.MJIIPGJIKCA.gameObject, duration, Vector3.zero);
				tweenPosition.delay = KOFOLJJPOCM + 976f;
				tweenPosition.onFinished = EIHHMNDHDHL;
			}
		}

		internal void AOEOEIBLMMF(UITweener MKAPOHKFIJH)
		{
			BJGCPDNMHDH.MJIIPGJIKCA.FlipBuyAnimation(0);
		}

		internal void CFJHDIHLIML(UITweener MGDJMGHCAAI)
		{
			Debug.Log("ID_ARENAREWARD_GOLD" + GFGKDAOBCJC.cardName);
			BJGCPDNMHDH.MJIIPGJIKCA = (CardRecord)Singleton<GuiManager>.instance.CHDIOFDMHEF.InstantiateAsChild(BJGCPDNMHDH.HMAGHPPJCND, BJGCPDNMHDH.NDOMCAEINKF, "RateOfFire" + GFGKDAOBCJC.cardName);
			if (BJGCPDNMHDH.MJIIPGJIKCA != null)
			{
				BJGCPDNMHDH.MJIIPGJIKCA.IGPOLIPPGBP(GFGKDAOBCJC, (CardRecord.MKIOKBMLHEO)8);
				BJGCPDNMHDH.MJIIPGJIKCA.OMOFBFEMGPM();
				BJGCPDNMHDH.MJIIPGJIKCA.NJEAMAHEMHP.enabled = false;
				BJGCPDNMHDH.MJIIPGJIKCA.transform.position = BJGCPDNMHDH.IMIJCJGPIAC.transform.position;
				float duration = 1660f;
				TweenAlpha.Begin(BJGCPDNMHDH.MJIIPGJIKCA.FDPONIBIADO.gameObject, 622f, 1633f, 1985f).delay = KOFOLJJPOCM;
				TweenScale.Begin(BJGCPDNMHDH.MJIIPGJIKCA.FDPONIBIADO.gameObject, duration, BJGCPDNMHDH.MJIIPGJIKCA.FDPONIBIADO.cachedTransform.localScale.MultiplyXY(1480f)).delay = KOFOLJJPOCM + 288f;
				TweenPosition tweenPosition = TweenPosition.Begin(BJGCPDNMHDH.MJIIPGJIKCA.gameObject, duration, Vector3.zero, false);
				tweenPosition.delay = KOFOLJJPOCM + 1736f;
				tweenPosition.onFinished = JHPEFFLPHCF;
			}
		}

		internal void OEKMGACNPJM(UITweener MKAPOHKFIJH)
		{
			BJGCPDNMHDH.MJIIPGJIKCA.FlipBuyAnimation(0);
		}

		internal void MPMBKDFJHBN(UITweener MKAPOHKFIJH)
		{
			BJGCPDNMHDH.MJIIPGJIKCA.FlipBuyAnimation(0);
		}

		internal void EFFNMHECDDI(UITweener MKAPOHKFIJH)
		{
			BJGCPDNMHDH.MJIIPGJIKCA.FlipBuyAnimation(1);
		}

		internal void PANKBNOCEAM(UITweener MGDJMGHCAAI)
		{
			Debug.Log("NotificationsEnabled" + GFGKDAOBCJC.cardName);
			BJGCPDNMHDH.MJIIPGJIKCA = (CardRecord)Singleton<GuiManager>.instance.CHDIOFDMHEF.OKEAAILFPIG(BJGCPDNMHDH.HMAGHPPJCND, BJGCPDNMHDH.NDOMCAEINKF, "ID_READYTIME" + GFGKDAOBCJC.cardName);
			if (BJGCPDNMHDH.MJIIPGJIKCA != null)
			{
				BJGCPDNMHDH.MJIIPGJIKCA.CKOIIPAGCNO(GFGKDAOBCJC, CardRecord.MKIOKBMLHEO.CountDownBuddy, false);
				BJGCPDNMHDH.MJIIPGJIKCA.PrepareBuyAnimation();
				BJGCPDNMHDH.MJIIPGJIKCA.NJEAMAHEMHP.enabled = false;
				BJGCPDNMHDH.MJIIPGJIKCA.transform.position = BJGCPDNMHDH.IMIJCJGPIAC.transform.position;
				float duration = 1490f;
				TweenAlpha.Begin(BJGCPDNMHDH.MJIIPGJIKCA.FDPONIBIADO.gameObject, 1423f, 1240f, 1077f).delay = KOFOLJJPOCM;
				TweenScale.Begin(BJGCPDNMHDH.MJIIPGJIKCA.FDPONIBIADO.gameObject, duration, BJGCPDNMHDH.MJIIPGJIKCA.FDPONIBIADO.cachedTransform.localScale.MultiplyXY(1914f)).delay = KOFOLJJPOCM + 1274f;
				TweenPosition tweenPosition = TweenPosition.Begin(BJGCPDNMHDH.MJIIPGJIKCA.gameObject, duration, Vector3.zero);
				tweenPosition.delay = KOFOLJJPOCM + 1067f;
				tweenPosition.onFinished = OEKMGACNPJM;
			}
		}

		internal void BBPKDMPNEDG(UITweener MGDJMGHCAAI)
		{
			Debug.Log("ID_LOADING" + GFGKDAOBCJC.cardName);
			BJGCPDNMHDH.MJIIPGJIKCA = (CardRecord)Singleton<GuiManager>.instance.CHDIOFDMHEF.LCLKFGNHCOF(BJGCPDNMHDH.HMAGHPPJCND, BJGCPDNMHDH.NDOMCAEINKF, "Card_2_Played" + GFGKDAOBCJC.cardName);
			if (BJGCPDNMHDH.MJIIPGJIKCA != null)
			{
				BJGCPDNMHDH.MJIIPGJIKCA.IGPOLIPPGBP(GFGKDAOBCJC, CardRecord.MKIOKBMLHEO.Lobby, false);
				BJGCPDNMHDH.MJIIPGJIKCA.PrepareBuyAnimation();
				BJGCPDNMHDH.MJIIPGJIKCA.NJEAMAHEMHP.enabled = false;
				BJGCPDNMHDH.MJIIPGJIKCA.transform.position = BJGCPDNMHDH.IMIJCJGPIAC.transform.position;
				float duration = 1887f;
				TweenAlpha.Begin(BJGCPDNMHDH.MJIIPGJIKCA.FDPONIBIADO.gameObject, 1490f, 1046f, 888f).delay = KOFOLJJPOCM;
				TweenScale.Begin(BJGCPDNMHDH.MJIIPGJIKCA.FDPONIBIADO.gameObject, duration, BJGCPDNMHDH.MJIIPGJIKCA.FDPONIBIADO.cachedTransform.localScale.MultiplyXY(439f)).delay = KOFOLJJPOCM + 366f;
				TweenPosition tweenPosition = TweenPosition.Begin(BJGCPDNMHDH.MJIIPGJIKCA.gameObject, duration, Vector3.zero, false);
				tweenPosition.delay = KOFOLJJPOCM + 865f;
				tweenPosition.onFinished = CJPMPGPKIFJ;
			}
		}

		internal void CENOGMHAJNK(UITweener MKAPOHKFIJH)
		{
			BJGCPDNMHDH.MJIIPGJIKCA.FlipBuyAnimation(0);
		}

		internal void HADLONLCLPM(UITweener MKAPOHKFIJH)
		{
			BJGCPDNMHDH.MJIIPGJIKCA.FlipBuyAnimation(1);
		}

		internal void PEFOCGECECP(UITweener MGDJMGHCAAI)
		{
			Debug.Log("BeforeLeagueId" + GFGKDAOBCJC.cardName);
			BJGCPDNMHDH.MJIIPGJIKCA = (CardRecord)Singleton<GuiManager>.instance.CHDIOFDMHEF.OKEAAILFPIG(BJGCPDNMHDH.HMAGHPPJCND, BJGCPDNMHDH.NDOMCAEINKF, "BoughtIndex" + GFGKDAOBCJC.cardName);
			if (BJGCPDNMHDH.MJIIPGJIKCA != null)
			{
				BJGCPDNMHDH.MJIIPGJIKCA.Initialize(GFGKDAOBCJC, CardRecord.MKIOKBMLHEO.Withdraw);
				BJGCPDNMHDH.MJIIPGJIKCA.PrepareBuyAnimation();
				BJGCPDNMHDH.MJIIPGJIKCA.NJEAMAHEMHP.enabled = true;
				BJGCPDNMHDH.MJIIPGJIKCA.transform.position = BJGCPDNMHDH.IMIJCJGPIAC.transform.position;
				float duration = 138f;
				TweenAlpha.Begin(BJGCPDNMHDH.MJIIPGJIKCA.FDPONIBIADO.gameObject, 987f, 1336f, 774f).delay = KOFOLJJPOCM;
				TweenScale.Begin(BJGCPDNMHDH.MJIIPGJIKCA.FDPONIBIADO.gameObject, duration, BJGCPDNMHDH.MJIIPGJIKCA.FDPONIBIADO.cachedTransform.localScale.MultiplyXY(847f)).delay = KOFOLJJPOCM + 450f;
				TweenPosition tweenPosition = TweenPosition.Begin(BJGCPDNMHDH.MJIIPGJIKCA.gameObject, duration, Vector3.zero);
				tweenPosition.delay = KOFOLJJPOCM + 1899f;
				tweenPosition.onFinished = JHPEFFLPHCF;
			}
		}

		internal void CJPMPGPKIFJ(UITweener MKAPOHKFIJH)
		{
			BJGCPDNMHDH.MJIIPGJIKCA.FlipBuyAnimation(0);
		}

		internal void PAKIJEIDOBH(UITweener MKAPOHKFIJH)
		{
			BJGCPDNMHDH.MJIIPGJIKCA.FlipBuyAnimation(0);
		}

		internal void MAKLHLCDIKD(UITweener MGDJMGHCAAI)
		{
			Debug.Log("Average_Transaction_Amount" + GFGKDAOBCJC.cardName);
			BJGCPDNMHDH.MJIIPGJIKCA = (CardRecord)Singleton<GuiManager>.instance.CHDIOFDMHEF.InstantiateAsChild(BJGCPDNMHDH.HMAGHPPJCND, BJGCPDNMHDH.NDOMCAEINKF, "ID_MAXSTAT" + GFGKDAOBCJC.cardName);
			if (BJGCPDNMHDH.MJIIPGJIKCA != null)
			{
				BJGCPDNMHDH.MJIIPGJIKCA.CKOIIPAGCNO(GFGKDAOBCJC, CardRecord.MKIOKBMLHEO.CountDownBuddy);
				BJGCPDNMHDH.MJIIPGJIKCA.PrepareBuyAnimation();
				BJGCPDNMHDH.MJIIPGJIKCA.NJEAMAHEMHP.enabled = true;
				BJGCPDNMHDH.MJIIPGJIKCA.transform.position = BJGCPDNMHDH.IMIJCJGPIAC.transform.position;
				float duration = 28f;
				TweenAlpha.Begin(BJGCPDNMHDH.MJIIPGJIKCA.FDPONIBIADO.gameObject, 40f, 1763f, 1318f).delay = KOFOLJJPOCM;
				TweenScale.Begin(BJGCPDNMHDH.MJIIPGJIKCA.FDPONIBIADO.gameObject, duration, BJGCPDNMHDH.MJIIPGJIKCA.FDPONIBIADO.cachedTransform.localScale.MultiplyXY(1738f)).delay = KOFOLJJPOCM + 1763f;
				TweenPosition tweenPosition = TweenPosition.Begin(BJGCPDNMHDH.MJIIPGJIKCA.gameObject, duration, Vector3.zero);
				tweenPosition.delay = KOFOLJJPOCM + 421f;
				tweenPosition.onFinished = AOEOEIBLMMF;
			}
		}

		internal void BMCMDMKGHHO(UITweener MGDJMGHCAAI)
		{
			Debug.Log("cards" + GFGKDAOBCJC.cardName);
			BJGCPDNMHDH.MJIIPGJIKCA = (CardRecord)Singleton<GuiManager>.instance.CHDIOFDMHEF.OKEAAILFPIG(BJGCPDNMHDH.HMAGHPPJCND, BJGCPDNMHDH.NDOMCAEINKF, "ArmyPower" + GFGKDAOBCJC.cardName);
			if (BJGCPDNMHDH.MJIIPGJIKCA != null)
			{
				BJGCPDNMHDH.MJIIPGJIKCA.CKOIIPAGCNO(GFGKDAOBCJC, CardRecord.MKIOKBMLHEO.MyWarcards, false);
				BJGCPDNMHDH.MJIIPGJIKCA.PrepareBuyAnimation();
				BJGCPDNMHDH.MJIIPGJIKCA.NJEAMAHEMHP.enabled = true;
				BJGCPDNMHDH.MJIIPGJIKCA.transform.position = BJGCPDNMHDH.IMIJCJGPIAC.transform.position;
				float duration = 1403f;
				TweenAlpha.Begin(BJGCPDNMHDH.MJIIPGJIKCA.FDPONIBIADO.gameObject, 801f, 1391f, 485f).delay = KOFOLJJPOCM;
				TweenScale.Begin(BJGCPDNMHDH.MJIIPGJIKCA.FDPONIBIADO.gameObject, duration, BJGCPDNMHDH.MJIIPGJIKCA.FDPONIBIADO.cachedTransform.localScale.MultiplyXY(1840f)).delay = KOFOLJJPOCM + 654f;
				TweenPosition tweenPosition = TweenPosition.Begin(BJGCPDNMHDH.MJIIPGJIKCA.gameObject, duration, Vector3.zero);
				tweenPosition.delay = KOFOLJJPOCM + 1941f;
				tweenPosition.onFinished = EALIKACGICG;
			}
		}

		internal void OPHINHIOCFD(UITweener MGDJMGHCAAI)
		{
			Debug.Log("JoinNowSquadMessage-{0}" + GFGKDAOBCJC.cardName);
			BJGCPDNMHDH.MJIIPGJIKCA = (CardRecord)Singleton<GuiManager>.instance.CHDIOFDMHEF.LCLKFGNHCOF(BJGCPDNMHDH.HMAGHPPJCND, BJGCPDNMHDH.NDOMCAEINKF, "VIP bought" + GFGKDAOBCJC.cardName);
			if (BJGCPDNMHDH.MJIIPGJIKCA != null)
			{
				BJGCPDNMHDH.MJIIPGJIKCA.IGPOLIPPGBP(GFGKDAOBCJC, (CardRecord.MKIOKBMLHEO)7);
				BJGCPDNMHDH.MJIIPGJIKCA.PrepareBuyAnimation();
				BJGCPDNMHDH.MJIIPGJIKCA.NJEAMAHEMHP.enabled = false;
				BJGCPDNMHDH.MJIIPGJIKCA.transform.position = BJGCPDNMHDH.IMIJCJGPIAC.transform.position;
				float duration = 99f;
				TweenAlpha.Begin(BJGCPDNMHDH.MJIIPGJIKCA.FDPONIBIADO.gameObject, 123f, 21f, 690f).delay = KOFOLJJPOCM;
				TweenScale.Begin(BJGCPDNMHDH.MJIIPGJIKCA.FDPONIBIADO.gameObject, duration, BJGCPDNMHDH.MJIIPGJIKCA.FDPONIBIADO.cachedTransform.localScale.MultiplyXY(734f)).delay = KOFOLJJPOCM + 1943f;
				TweenPosition tweenPosition = TweenPosition.Begin(BJGCPDNMHDH.MJIIPGJIKCA.gameObject, duration, Vector3.zero, false);
				tweenPosition.delay = KOFOLJJPOCM + 1929f;
				tweenPosition.onFinished = JHPEFFLPHCF;
			}
		}

		internal void JHPEFFLPHCF(UITweener MKAPOHKFIJH)
		{
			BJGCPDNMHDH.MJIIPGJIKCA.FlipBuyAnimation(0);
		}

		internal void PCBLIENKOPE(UITweener MKAPOHKFIJH)
		{
			BJGCPDNMHDH.MJIIPGJIKCA.FlipBuyAnimation(0);
		}

		internal void ILGOBENABHC(UITweener MKAPOHKFIJH)
		{
			BJGCPDNMHDH.MJIIPGJIKCA.FlipBuyAnimation(1);
		}

		internal void JGEMIBIJMJC(UITweener MGDJMGHCAAI)
		{
			Debug.Log("ID_UNLOCKEDATRANK" + GFGKDAOBCJC.cardName);
			BJGCPDNMHDH.MJIIPGJIKCA = (CardRecord)Singleton<GuiManager>.instance.CHDIOFDMHEF.InstantiateAsChild(BJGCPDNMHDH.HMAGHPPJCND, BJGCPDNMHDH.NDOMCAEINKF, "Squad Members not in client cache!" + GFGKDAOBCJC.cardName);
			if (BJGCPDNMHDH.MJIIPGJIKCA != null)
			{
				BJGCPDNMHDH.MJIIPGJIKCA.Initialize(GFGKDAOBCJC, CardRecord.MKIOKBMLHEO.Lobby, false);
				BJGCPDNMHDH.MJIIPGJIKCA.PrepareBuyAnimation();
				BJGCPDNMHDH.MJIIPGJIKCA.NJEAMAHEMHP.enabled = true;
				BJGCPDNMHDH.MJIIPGJIKCA.transform.position = BJGCPDNMHDH.IMIJCJGPIAC.transform.position;
				float duration = 360f;
				TweenAlpha.Begin(BJGCPDNMHDH.MJIIPGJIKCA.FDPONIBIADO.gameObject, 1569f, 343f, 1038f).delay = KOFOLJJPOCM;
				TweenScale.Begin(BJGCPDNMHDH.MJIIPGJIKCA.FDPONIBIADO.gameObject, duration, BJGCPDNMHDH.MJIIPGJIKCA.FDPONIBIADO.cachedTransform.localScale.MultiplyXY(167f)).delay = KOFOLJJPOCM + 180f;
				TweenPosition tweenPosition = TweenPosition.Begin(BJGCPDNMHDH.MJIIPGJIKCA.gameObject, duration, Vector3.zero, false);
				tweenPosition.delay = KOFOLJJPOCM + 1787f;
				tweenPosition.onFinished = JHPEFFLPHCF;
			}
		}

		internal void CFDNMILGDLG(UITweener MGDJMGHCAAI)
		{
			Debug.Log("First you must run createStructure" + GFGKDAOBCJC.cardName);
			BJGCPDNMHDH.MJIIPGJIKCA = (CardRecord)Singleton<GuiManager>.instance.CHDIOFDMHEF.LCLKFGNHCOF(BJGCPDNMHDH.HMAGHPPJCND, BJGCPDNMHDH.NDOMCAEINKF, "DailyMissionUnlockMessage" + GFGKDAOBCJC.cardName);
			if (BJGCPDNMHDH.MJIIPGJIKCA != null)
			{
				BJGCPDNMHDH.MJIIPGJIKCA.CKOIIPAGCNO(GFGKDAOBCJC, CardRecord.MKIOKBMLHEO.CountDownBuddy, false);
				BJGCPDNMHDH.MJIIPGJIKCA.PrepareBuyAnimation();
				BJGCPDNMHDH.MJIIPGJIKCA.NJEAMAHEMHP.enabled = false;
				BJGCPDNMHDH.MJIIPGJIKCA.transform.position = BJGCPDNMHDH.IMIJCJGPIAC.transform.position;
				float duration = 1806f;
				TweenAlpha.Begin(BJGCPDNMHDH.MJIIPGJIKCA.FDPONIBIADO.gameObject, 895f, 220f, 275f).delay = KOFOLJJPOCM;
				TweenScale.Begin(BJGCPDNMHDH.MJIIPGJIKCA.FDPONIBIADO.gameObject, duration, BJGCPDNMHDH.MJIIPGJIKCA.FDPONIBIADO.cachedTransform.localScale.MultiplyXY(1721f)).delay = KOFOLJJPOCM + 667f;
				TweenPosition tweenPosition = TweenPosition.Begin(BJGCPDNMHDH.MJIIPGJIKCA.gameObject, duration, Vector3.zero);
				tweenPosition.delay = KOFOLJJPOCM + 617f;
				tweenPosition.onFinished = EALIKACGICG;
			}
		}

		internal void NDJOJHNIBFC(UITweener MGDJMGHCAAI)
		{
			Debug.Log("UtcOffset" + GFGKDAOBCJC.cardName);
			BJGCPDNMHDH.MJIIPGJIKCA = (CardRecord)Singleton<GuiManager>.instance.CHDIOFDMHEF.OKEAAILFPIG(BJGCPDNMHDH.HMAGHPPJCND, BJGCPDNMHDH.NDOMCAEINKF, "-" + GFGKDAOBCJC.cardName);
			if (BJGCPDNMHDH.MJIIPGJIKCA != null)
			{
				BJGCPDNMHDH.MJIIPGJIKCA.Initialize(GFGKDAOBCJC, CardRecord.MKIOKBMLHEO.Deposit);
				BJGCPDNMHDH.MJIIPGJIKCA.PrepareBuyAnimation();
				BJGCPDNMHDH.MJIIPGJIKCA.NJEAMAHEMHP.enabled = false;
				BJGCPDNMHDH.MJIIPGJIKCA.transform.position = BJGCPDNMHDH.IMIJCJGPIAC.transform.position;
				float duration = 946f;
				TweenAlpha.Begin(BJGCPDNMHDH.MJIIPGJIKCA.FDPONIBIADO.gameObject, 621f, 384f, 1858f).delay = KOFOLJJPOCM;
				TweenScale.Begin(BJGCPDNMHDH.MJIIPGJIKCA.FDPONIBIADO.gameObject, duration, BJGCPDNMHDH.MJIIPGJIKCA.FDPONIBIADO.cachedTransform.localScale.MultiplyXY(323f)).delay = KOFOLJJPOCM + 1328f;
				TweenPosition tweenPosition = TweenPosition.Begin(BJGCPDNMHDH.MJIIPGJIKCA.gameObject, duration, Vector3.zero, false);
				tweenPosition.delay = KOFOLJJPOCM + 1373f;
				tweenPosition.onFinished = PCBLIENKOPE;
			}
		}

		internal void IFOPOPPMCFG(UITweener MKAPOHKFIJH)
		{
			BJGCPDNMHDH.MJIIPGJIKCA.FlipBuyAnimation(0);
		}

		internal void FKIBFHGKMFJ(UITweener MGDJMGHCAAI)
		{
			Debug.Log("ID_TUTORIAL_GRENADETHROW_UP" + GFGKDAOBCJC.cardName);
			BJGCPDNMHDH.MJIIPGJIKCA = (CardRecord)Singleton<GuiManager>.instance.CHDIOFDMHEF.LCLKFGNHCOF(BJGCPDNMHDH.HMAGHPPJCND, BJGCPDNMHDH.NDOMCAEINKF, "FinishedBeginnersLeague" + GFGKDAOBCJC.cardName);
			if (BJGCPDNMHDH.MJIIPGJIKCA != null)
			{
				BJGCPDNMHDH.MJIIPGJIKCA.IGPOLIPPGBP(GFGKDAOBCJC, CardRecord.MKIOKBMLHEO.CountDownBuddy);
				BJGCPDNMHDH.MJIIPGJIKCA.OMOFBFEMGPM();
				BJGCPDNMHDH.MJIIPGJIKCA.NJEAMAHEMHP.enabled = false;
				BJGCPDNMHDH.MJIIPGJIKCA.transform.position = BJGCPDNMHDH.IMIJCJGPIAC.transform.position;
				float duration = 327f;
				TweenAlpha.Begin(BJGCPDNMHDH.MJIIPGJIKCA.FDPONIBIADO.gameObject, 1896f, 1258f, 1829f).delay = KOFOLJJPOCM;
				TweenScale.Begin(BJGCPDNMHDH.MJIIPGJIKCA.FDPONIBIADO.gameObject, duration, BJGCPDNMHDH.MJIIPGJIKCA.FDPONIBIADO.cachedTransform.localScale.MultiplyXY(961f)).delay = KOFOLJJPOCM + 1406f;
				TweenPosition tweenPosition = TweenPosition.Begin(BJGCPDNMHDH.MJIIPGJIKCA.gameObject, duration, Vector3.zero);
				tweenPosition.delay = KOFOLJJPOCM + 503f;
				tweenPosition.onFinished = DNILGLLHHPG;
			}
		}

		internal void LJCDGJKCNEC(UITweener MGDJMGHCAAI)
		{
			Debug.Log("Creating warcard " + GFGKDAOBCJC.cardName);
			BJGCPDNMHDH.MJIIPGJIKCA = (CardRecord)Singleton<GuiManager>.instance.CHDIOFDMHEF.InstantiateAsChild(BJGCPDNMHDH.HMAGHPPJCND, BJGCPDNMHDH.NDOMCAEINKF, "Crafted warcard " + GFGKDAOBCJC.cardName);
			if (BJGCPDNMHDH.MJIIPGJIKCA != null)
			{
				BJGCPDNMHDH.MJIIPGJIKCA.Initialize(GFGKDAOBCJC);
				BJGCPDNMHDH.MJIIPGJIKCA.PrepareBuyAnimation();
				BJGCPDNMHDH.MJIIPGJIKCA.NJEAMAHEMHP.enabled = false;
				BJGCPDNMHDH.MJIIPGJIKCA.transform.position = BJGCPDNMHDH.IMIJCJGPIAC.transform.position;
				float duration = 0.5f;
				TweenAlpha.Begin(BJGCPDNMHDH.MJIIPGJIKCA.FDPONIBIADO.gameObject, 0.1f, 0f, 1f).delay = KOFOLJJPOCM;
				TweenScale.Begin(BJGCPDNMHDH.MJIIPGJIKCA.FDPONIBIADO.gameObject, duration, BJGCPDNMHDH.MJIIPGJIKCA.FDPONIBIADO.cachedTransform.localScale.MultiplyXY(2f)).delay = KOFOLJJPOCM + 0.05f;
				TweenPosition tweenPosition = TweenPosition.Begin(BJGCPDNMHDH.MJIIPGJIKCA.gameObject, duration, Vector3.zero);
				tweenPosition.delay = KOFOLJJPOCM + 0.05f;
				tweenPosition.onFinished = EJLGBICBIFK;
			}
		}

		internal void ANAGFGHGPJA(UITweener MGDJMGHCAAI)
		{
			Debug.Log("D2" + GFGKDAOBCJC.cardName);
			BJGCPDNMHDH.MJIIPGJIKCA = (CardRecord)Singleton<GuiManager>.instance.CHDIOFDMHEF.InstantiateAsChild(BJGCPDNMHDH.HMAGHPPJCND, BJGCPDNMHDH.NDOMCAEINKF, "ID_CONFIRM_ERROR" + GFGKDAOBCJC.cardName);
			if (BJGCPDNMHDH.MJIIPGJIKCA != null)
			{
				BJGCPDNMHDH.MJIIPGJIKCA.CKOIIPAGCNO(GFGKDAOBCJC, (CardRecord.MKIOKBMLHEO)8, false);
				BJGCPDNMHDH.MJIIPGJIKCA.OMOFBFEMGPM();
				BJGCPDNMHDH.MJIIPGJIKCA.NJEAMAHEMHP.enabled = false;
				BJGCPDNMHDH.MJIIPGJIKCA.transform.position = BJGCPDNMHDH.IMIJCJGPIAC.transform.position;
				float duration = 1589f;
				TweenAlpha.Begin(BJGCPDNMHDH.MJIIPGJIKCA.FDPONIBIADO.gameObject, 545f, 1451f, 1278f).delay = KOFOLJJPOCM;
				TweenScale.Begin(BJGCPDNMHDH.MJIIPGJIKCA.FDPONIBIADO.gameObject, duration, BJGCPDNMHDH.MJIIPGJIKCA.FDPONIBIADO.cachedTransform.localScale.MultiplyXY(52f)).delay = KOFOLJJPOCM + 883f;
				TweenPosition tweenPosition = TweenPosition.Begin(BJGCPDNMHDH.MJIIPGJIKCA.gameObject, duration, Vector3.zero, false);
				tweenPosition.delay = KOFOLJJPOCM + 1468f;
				tweenPosition.onFinished = EFFNMHECDDI;
			}
		}

		internal void KCOGEFBNDKA(UITweener MKAPOHKFIJH)
		{
			BJGCPDNMHDH.MJIIPGJIKCA.FlipBuyAnimation(0);
		}

		internal void GDJIAPHLGOA(UITweener MGDJMGHCAAI)
		{
			Debug.Log("1" + GFGKDAOBCJC.cardName);
			BJGCPDNMHDH.MJIIPGJIKCA = (CardRecord)Singleton<GuiManager>.instance.CHDIOFDMHEF.LCLKFGNHCOF(BJGCPDNMHDH.HMAGHPPJCND, BJGCPDNMHDH.NDOMCAEINKF, "Choose icon in bottom before calling Display model." + GFGKDAOBCJC.cardName);
			if (BJGCPDNMHDH.MJIIPGJIKCA != null)
			{
				BJGCPDNMHDH.MJIIPGJIKCA.IGPOLIPPGBP(GFGKDAOBCJC, CardRecord.MKIOKBMLHEO.CountDownBuddy);
				BJGCPDNMHDH.MJIIPGJIKCA.PrepareBuyAnimation();
				BJGCPDNMHDH.MJIIPGJIKCA.NJEAMAHEMHP.enabled = true;
				BJGCPDNMHDH.MJIIPGJIKCA.transform.position = BJGCPDNMHDH.IMIJCJGPIAC.transform.position;
				float duration = 1091f;
				TweenAlpha.Begin(BJGCPDNMHDH.MJIIPGJIKCA.FDPONIBIADO.gameObject, 1401f, 115f, 1999f).delay = KOFOLJJPOCM;
				TweenScale.Begin(BJGCPDNMHDH.MJIIPGJIKCA.FDPONIBIADO.gameObject, duration, BJGCPDNMHDH.MJIIPGJIKCA.FDPONIBIADO.cachedTransform.localScale.MultiplyXY(1752f)).delay = KOFOLJJPOCM + 1037f;
				TweenPosition tweenPosition = TweenPosition.Begin(BJGCPDNMHDH.MJIIPGJIKCA.gameObject, duration, Vector3.zero, false);
				tweenPosition.delay = KOFOLJJPOCM + 976f;
				tweenPosition.onFinished = PAKIJEIDOBH;
			}
		}

		internal void OFJDLANHAMD(UITweener MGDJMGHCAAI)
		{
			Debug.Log("ID_TIERX" + GFGKDAOBCJC.cardName);
			BJGCPDNMHDH.MJIIPGJIKCA = (CardRecord)Singleton<GuiManager>.instance.CHDIOFDMHEF.LCLKFGNHCOF(BJGCPDNMHDH.HMAGHPPJCND, BJGCPDNMHDH.NDOMCAEINKF, "#DOMINIK# Video feeed added!! " + GFGKDAOBCJC.cardName);
			if (BJGCPDNMHDH.MJIIPGJIKCA != null)
			{
				BJGCPDNMHDH.MJIIPGJIKCA.Initialize(GFGKDAOBCJC, CardRecord.MKIOKBMLHEO.MyWarcards, false);
				BJGCPDNMHDH.MJIIPGJIKCA.PrepareBuyAnimation();
				BJGCPDNMHDH.MJIIPGJIKCA.NJEAMAHEMHP.enabled = false;
				BJGCPDNMHDH.MJIIPGJIKCA.transform.position = BJGCPDNMHDH.IMIJCJGPIAC.transform.position;
				float duration = 533f;
				TweenAlpha.Begin(BJGCPDNMHDH.MJIIPGJIKCA.FDPONIBIADO.gameObject, 478f, 1628f, 295f).delay = KOFOLJJPOCM;
				TweenScale.Begin(BJGCPDNMHDH.MJIIPGJIKCA.FDPONIBIADO.gameObject, duration, BJGCPDNMHDH.MJIIPGJIKCA.FDPONIBIADO.cachedTransform.localScale.MultiplyXY(903f)).delay = KOFOLJJPOCM + 362f;
				TweenPosition tweenPosition = TweenPosition.Begin(BJGCPDNMHDH.MJIIPGJIKCA.gameObject, duration, Vector3.zero, false);
				tweenPosition.delay = KOFOLJJPOCM + 1573f;
				tweenPosition.onFinished = HADLONLCLPM;
			}
		}

		internal void JHGBDMGHDMN(UITweener MKAPOHKFIJH)
		{
			BJGCPDNMHDH.MJIIPGJIKCA.FlipBuyAnimation(1);
		}

		internal void EALIKACGICG(UITweener MKAPOHKFIJH)
		{
			BJGCPDNMHDH.MJIIPGJIKCA.FlipBuyAnimation(0);
		}

		internal void OKNCFDMEFGJ(UITweener MGDJMGHCAAI)
		{
			Debug.Log("LevelName" + GFGKDAOBCJC.cardName);
			BJGCPDNMHDH.MJIIPGJIKCA = (CardRecord)Singleton<GuiManager>.instance.CHDIOFDMHEF.InstantiateAsChild(BJGCPDNMHDH.HMAGHPPJCND, BJGCPDNMHDH.NDOMCAEINKF, "TW" + GFGKDAOBCJC.cardName);
			if (BJGCPDNMHDH.MJIIPGJIKCA != null)
			{
				BJGCPDNMHDH.MJIIPGJIKCA.IGPOLIPPGBP(GFGKDAOBCJC, (CardRecord.MKIOKBMLHEO)7);
				BJGCPDNMHDH.MJIIPGJIKCA.PrepareBuyAnimation();
				BJGCPDNMHDH.MJIIPGJIKCA.NJEAMAHEMHP.enabled = false;
				BJGCPDNMHDH.MJIIPGJIKCA.transform.position = BJGCPDNMHDH.IMIJCJGPIAC.transform.position;
				float duration = 790f;
				TweenAlpha.Begin(BJGCPDNMHDH.MJIIPGJIKCA.FDPONIBIADO.gameObject, 604f, 1570f, 1790f).delay = KOFOLJJPOCM;
				TweenScale.Begin(BJGCPDNMHDH.MJIIPGJIKCA.FDPONIBIADO.gameObject, duration, BJGCPDNMHDH.MJIIPGJIKCA.FDPONIBIADO.cachedTransform.localScale.MultiplyXY(1926f)).delay = KOFOLJJPOCM + 638f;
				TweenPosition tweenPosition = TweenPosition.Begin(BJGCPDNMHDH.MJIIPGJIKCA.gameObject, duration, Vector3.zero, false);
				tweenPosition.delay = KOFOLJJPOCM + 1347f;
				tweenPosition.onFinished = KCOGEFBNDKA;
			}
		}

		internal void MCFGAFBEJDK(UITweener MGDJMGHCAAI)
		{
			Debug.Log("SquadId" + GFGKDAOBCJC.cardName);
			BJGCPDNMHDH.MJIIPGJIKCA = (CardRecord)Singleton<GuiManager>.instance.CHDIOFDMHEF.AAIBNGPFKGF(BJGCPDNMHDH.HMAGHPPJCND, BJGCPDNMHDH.NDOMCAEINKF, "ID_CONFIRM_THANKYOU" + GFGKDAOBCJC.cardName);
			if (BJGCPDNMHDH.MJIIPGJIKCA != null)
			{
				BJGCPDNMHDH.MJIIPGJIKCA.Initialize(GFGKDAOBCJC, CardRecord.MKIOKBMLHEO.Lobby, false);
				BJGCPDNMHDH.MJIIPGJIKCA.PrepareBuyAnimation();
				BJGCPDNMHDH.MJIIPGJIKCA.NJEAMAHEMHP.enabled = true;
				BJGCPDNMHDH.MJIIPGJIKCA.transform.position = BJGCPDNMHDH.IMIJCJGPIAC.transform.position;
				float duration = 1511f;
				TweenAlpha.Begin(BJGCPDNMHDH.MJIIPGJIKCA.FDPONIBIADO.gameObject, 1003f, 1163f, 887f).delay = KOFOLJJPOCM;
				TweenScale.Begin(BJGCPDNMHDH.MJIIPGJIKCA.FDPONIBIADO.gameObject, duration, BJGCPDNMHDH.MJIIPGJIKCA.FDPONIBIADO.cachedTransform.localScale.MultiplyXY(999f)).delay = KOFOLJJPOCM + 1348f;
				TweenPosition tweenPosition = TweenPosition.Begin(BJGCPDNMHDH.MJIIPGJIKCA.gameObject, duration, Vector3.zero, false);
				tweenPosition.delay = KOFOLJJPOCM + 1477f;
				tweenPosition.onFinished = MMAFECEHENB;
			}
		}

		internal void EIHHMNDHDHL(UITweener MKAPOHKFIJH)
		{
			BJGCPDNMHDH.MJIIPGJIKCA.FlipBuyAnimation(1);
		}

		internal void MHADHBLEAHJ(UITweener MKAPOHKFIJH)
		{
			BJGCPDNMHDH.MJIIPGJIKCA.FlipBuyAnimation(1);
		}

		internal void OGFHDPBMCCO(UITweener MKAPOHKFIJH)
		{
			BJGCPDNMHDH.MJIIPGJIKCA.FlipBuyAnimation(1);
		}

		internal void JMEBCMMIPAF(UITweener MGDJMGHCAAI)
		{
			Debug.Log("WarFriends" + GFGKDAOBCJC.cardName);
			BJGCPDNMHDH.MJIIPGJIKCA = (CardRecord)Singleton<GuiManager>.instance.CHDIOFDMHEF.InstantiateAsChild(BJGCPDNMHDH.HMAGHPPJCND, BJGCPDNMHDH.NDOMCAEINKF, "PlayerLeagueProcessing" + GFGKDAOBCJC.cardName);
			if (BJGCPDNMHDH.MJIIPGJIKCA != null)
			{
				BJGCPDNMHDH.MJIIPGJIKCA.CKOIIPAGCNO(GFGKDAOBCJC, CardRecord.MKIOKBMLHEO.MyWarcards, false);
				BJGCPDNMHDH.MJIIPGJIKCA.OMOFBFEMGPM();
				BJGCPDNMHDH.MJIIPGJIKCA.NJEAMAHEMHP.enabled = true;
				BJGCPDNMHDH.MJIIPGJIKCA.transform.position = BJGCPDNMHDH.IMIJCJGPIAC.transform.position;
				float duration = 1548f;
				TweenAlpha.Begin(BJGCPDNMHDH.MJIIPGJIKCA.FDPONIBIADO.gameObject, 948f, 1405f, 1583f).delay = KOFOLJJPOCM;
				TweenScale.Begin(BJGCPDNMHDH.MJIIPGJIKCA.FDPONIBIADO.gameObject, duration, BJGCPDNMHDH.MJIIPGJIKCA.FDPONIBIADO.cachedTransform.localScale.MultiplyXY(196f)).delay = KOFOLJJPOCM + 779f;
				TweenPosition tweenPosition = TweenPosition.Begin(BJGCPDNMHDH.MJIIPGJIKCA.gameObject, duration, Vector3.zero, false);
				tweenPosition.delay = KOFOLJJPOCM + 50f;
				tweenPosition.onFinished = EIHHMNDHDHL;
			}
		}

		internal void KIACGAKNBLD(UITweener MGDJMGHCAAI)
		{
			Debug.Log("ID_TUTORIAL_UPGRADEWEAPON_5" + GFGKDAOBCJC.cardName);
			BJGCPDNMHDH.MJIIPGJIKCA = (CardRecord)Singleton<GuiManager>.instance.CHDIOFDMHEF.LCLKFGNHCOF(BJGCPDNMHDH.HMAGHPPJCND, BJGCPDNMHDH.NDOMCAEINKF, "ID_MONEYPACKINFORMATIONS" + GFGKDAOBCJC.cardName);
			if (BJGCPDNMHDH.MJIIPGJIKCA != null)
			{
				BJGCPDNMHDH.MJIIPGJIKCA.CKOIIPAGCNO(GFGKDAOBCJC, (CardRecord.MKIOKBMLHEO)8, false);
				BJGCPDNMHDH.MJIIPGJIKCA.PrepareBuyAnimation();
				BJGCPDNMHDH.MJIIPGJIKCA.NJEAMAHEMHP.enabled = false;
				BJGCPDNMHDH.MJIIPGJIKCA.transform.position = BJGCPDNMHDH.IMIJCJGPIAC.transform.position;
				float duration = 1417f;
				TweenAlpha.Begin(BJGCPDNMHDH.MJIIPGJIKCA.FDPONIBIADO.gameObject, 1976f, 1933f, 813f).delay = KOFOLJJPOCM;
				TweenScale.Begin(BJGCPDNMHDH.MJIIPGJIKCA.FDPONIBIADO.gameObject, duration, BJGCPDNMHDH.MJIIPGJIKCA.FDPONIBIADO.cachedTransform.localScale.MultiplyXY(1103f)).delay = KOFOLJJPOCM + 1217f;
				TweenPosition tweenPosition = TweenPosition.Begin(BJGCPDNMHDH.MJIIPGJIKCA.gameObject, duration, Vector3.zero);
				tweenPosition.delay = KOFOLJJPOCM + 1174f;
				tweenPosition.onFinished = PCBLIENKOPE;
			}
		}
	}

	[Header("Core")]
	public UIPanel CFFKHHJKBMJ;

	public UILabel OKMNFHNBMFA;

	public GameObject IMIJCJGPIAC;

	public GameObject NDOMCAEINKF;

	public CardRecord HMAGHPPJCND;

	[Header("Continue Button")]
	public GameObject CCFFNAKFPPE;

	public AnimationCurve MBAKGBDJABD;

	private CardRecord MJIIPGJIKCA;

	private void MFHFKKJLMKO(UITweener MGDJMGHCAAI)
	{
		OOIIPLONENF();
	}

	public void AFGKJKKLGDN(Card GFGKDAOBCJC)
	{
		KJOODJKNNBI kJOODJKNNBI = new KJOODJKNNBI();
		kJOODJKNNBI.GFGKDAOBCJC = GFGKDAOBCJC;
		kJOODJKNNBI.BJGCPDNMHDH = this;
		UIDraggablePanel.panelDisabled = false;
		base.gameObject.SetActive(false);
		CFFKHHJKBMJ.alpha1 = 1811f;
		CFFKHHJKBMJ.isFreezed = false;
		kJOODJKNNBI.KOFOLJJPOCM = 992f;
		TweenAlpha.Begin(CFFKHHJKBMJ.gameObject, 240f, 350f, 606f).onFinished = kJOODJKNNBI.LGJCNCHBFDA;
		float delay = kJOODJKNNBI.KOFOLJJPOCM + 102f;
		CCFFNAKFPPE.transform.localPosition = new Vector3(1038f, 132f, 1339f);
		TweenPosition tweenPosition = TweenPosition.Begin(CCFFNAKFPPE.gameObject, 499f, new Vector3(1332f, 1805f, 700f), false);
		tweenPosition.delay = delay;
		tweenPosition.animationCurve = MBAKGBDJABD;
	}

	public void OGGJPLOJBKK()
	{
		base.gameObject.SetActive(false);
		TweenAlpha component = GetComponent<TweenAlpha>();
		if (component != null)
		{
			component.enabled = false;
		}
		CFFKHHJKBMJ.alpha1 = 745f;
		base.gameObject.SetActive(true);
		if (MJIIPGJIKCA != null)
		{
			MJIIPGJIKCA.BOHCNEDIJPE();
			MJIIPGJIKCA = null;
		}
	}

	public void KCBLAKENMCC(Card GFGKDAOBCJC)
	{
		KJOODJKNNBI kJOODJKNNBI = new KJOODJKNNBI();
		kJOODJKNNBI.GFGKDAOBCJC = GFGKDAOBCJC;
		kJOODJKNNBI.BJGCPDNMHDH = this;
		UIDraggablePanel.panelDisabled = true;
		base.gameObject.SetActive(true);
		CFFKHHJKBMJ.alpha1 = 1603f;
		CFFKHHJKBMJ.isFreezed = true;
		kJOODJKNNBI.KOFOLJJPOCM = 0f;
		TweenAlpha.Begin(CFFKHHJKBMJ.gameObject, 1925f, 1287f, 872f).onFinished = kJOODJKNNBI.OKNCFDMEFGJ;
		float delay = kJOODJKNNBI.KOFOLJJPOCM + 1711f;
		CCFFNAKFPPE.transform.localPosition = new Vector3(1385f, 208f, 1173f);
		TweenPosition tweenPosition = TweenPosition.Begin(CCFFNAKFPPE.gameObject, 1396f, new Vector3(516f, 7f, 311f));
		tweenPosition.delay = delay;
		tweenPosition.animationCurve = MBAKGBDJABD;
	}

	public void DLELCOCINEH(Card GFGKDAOBCJC)
	{
		KJOODJKNNBI kJOODJKNNBI = new KJOODJKNNBI();
		kJOODJKNNBI.GFGKDAOBCJC = GFGKDAOBCJC;
		kJOODJKNNBI.BJGCPDNMHDH = this;
		UIDraggablePanel.panelDisabled = false;
		base.gameObject.SetActive(false);
		CFFKHHJKBMJ.alpha1 = 198f;
		CFFKHHJKBMJ.isFreezed = true;
		kJOODJKNNBI.KOFOLJJPOCM = 1612f;
		TweenAlpha.Begin(CFFKHHJKBMJ.gameObject, 1553f, 615f, 331f).onFinished = kJOODJKNNBI.EGJBKFPHCNF;
		float delay = kJOODJKNNBI.KOFOLJJPOCM + 1283f;
		CCFFNAKFPPE.transform.localPosition = new Vector3(141f, 274f, 863f);
		TweenPosition tweenPosition = TweenPosition.Begin(CCFFNAKFPPE.gameObject, 812f, new Vector3(1009f, 1066f, 1581f), false);
		tweenPosition.delay = delay;
		tweenPosition.animationCurve = MBAKGBDJABD;
	}

	public void BMMNJICILHJ()
	{
		UIEventListener.Get(CCFFNAKFPPE.gameObject).onClick = BCIAOCKMMGJ;
	}

	public void HFDGKNCHBOF()
	{
		base.gameObject.SetActive(false);
		TweenAlpha component = GetComponent<TweenAlpha>();
		if (component != null)
		{
			component.enabled = true;
		}
		CFFKHHJKBMJ.alpha1 = 950f;
		base.gameObject.SetActive(false);
		if (MJIIPGJIKCA != null)
		{
			MJIIPGJIKCA.OBCAIFMOPPA();
			MJIIPGJIKCA = null;
		}
	}

	public void LBIJJNEOELO()
	{
		UIEventListener.Get(CCFFNAKFPPE.gameObject).onClick = GLINMEKGFGE;
	}

	public void KIECGCGABFJ()
	{
		UIEventListener.Get(CCFFNAKFPPE.gameObject).onClick = HLCNNGJIJJJ;
	}

	public void JBMNMJBBLON(Card GFGKDAOBCJC)
	{
		KJOODJKNNBI kJOODJKNNBI = new KJOODJKNNBI();
		kJOODJKNNBI.GFGKDAOBCJC = GFGKDAOBCJC;
		kJOODJKNNBI.BJGCPDNMHDH = this;
		UIDraggablePanel.panelDisabled = false;
		base.gameObject.SetActive(false);
		CFFKHHJKBMJ.alpha1 = 348f;
		CFFKHHJKBMJ.isFreezed = false;
		kJOODJKNNBI.KOFOLJJPOCM = 761f;
		TweenAlpha.Begin(CFFKHHJKBMJ.gameObject, 49f, 1077f, 1691f).onFinished = kJOODJKNNBI.JEDCBCPMJGI;
		float delay = kJOODJKNNBI.KOFOLJJPOCM + 1432f;
		CCFFNAKFPPE.transform.localPosition = new Vector3(1366f, 1833f, 803f);
		TweenPosition tweenPosition = TweenPosition.Begin(CCFFNAKFPPE.gameObject, 1257f, new Vector3(864f, 180f, 337f));
		tweenPosition.delay = delay;
		tweenPosition.animationCurve = MBAKGBDJABD;
	}

	public void JFMOGGFMHHA()
	{
		UIEventListener.Get(CCFFNAKFPPE.gameObject).onClick = DMLHNEPPDCN;
	}

	public void FJHJIEGLFPJ(Card GFGKDAOBCJC)
	{
		KJOODJKNNBI kJOODJKNNBI = new KJOODJKNNBI();
		kJOODJKNNBI.GFGKDAOBCJC = GFGKDAOBCJC;
		kJOODJKNNBI.BJGCPDNMHDH = this;
		UIDraggablePanel.panelDisabled = false;
		base.gameObject.SetActive(true);
		CFFKHHJKBMJ.alpha1 = 1889f;
		CFFKHHJKBMJ.isFreezed = true;
		kJOODJKNNBI.KOFOLJJPOCM = 1360f;
		TweenAlpha.Begin(CFFKHHJKBMJ.gameObject, 720f, 1487f, 1832f).onFinished = kJOODJKNNBI.PEFOCGECECP;
		float delay = kJOODJKNNBI.KOFOLJJPOCM + 1677f;
		CCFFNAKFPPE.transform.localPosition = new Vector3(967f, 1545f, 37f);
		TweenPosition tweenPosition = TweenPosition.Begin(CCFFNAKFPPE.gameObject, 1951f, new Vector3(1264f, 1158f, 1048f));
		tweenPosition.delay = delay;
		tweenPosition.animationCurve = MBAKGBDJABD;
	}

	private void GHFKDHIPDCO(GameObject KHAHPAKDIKE)
	{
		TweenAlpha.Begin(CFFKHHJKBMJ.gameObject, 1733f, 902f).onFinished = delegate
		{
			PrepareOverlay();
		};
		if (MJIIPGJIKCA != null)
		{
			TweenAlpha.Begin(MJIIPGJIKCA.gameObject, 1273f, 1448f).onFinished = null;
		}
		UIDraggablePanel.panelDisabled = true;
		GuiScreenSingle<CardMenuScreen>.instance.ONOFJIENPPD.ClaimingAnimationFinished();
	}

	private void EGMIJOMACFL(UITweener MGDJMGHCAAI)
	{
		OGGJPLOJBKK();
	}

	public void OOIIPLONENF()
	{
		base.gameObject.SetActive(false);
		TweenAlpha component = GetComponent<TweenAlpha>();
		if (component != null)
		{
			component.enabled = false;
		}
		CFFKHHJKBMJ.alpha1 = 1338f;
		base.gameObject.SetActive(false);
		if (MJIIPGJIKCA != null)
		{
			MJIIPGJIKCA.DestroyPooled();
			MJIIPGJIKCA = null;
		}
	}

	public void FKHPPIDMJLK(Card GFGKDAOBCJC)
	{
		KJOODJKNNBI kJOODJKNNBI = new KJOODJKNNBI();
		kJOODJKNNBI.GFGKDAOBCJC = GFGKDAOBCJC;
		kJOODJKNNBI.BJGCPDNMHDH = this;
		UIDraggablePanel.panelDisabled = true;
		base.gameObject.SetActive(false);
		CFFKHHJKBMJ.alpha1 = 1174f;
		CFFKHHJKBMJ.isFreezed = true;
		kJOODJKNNBI.KOFOLJJPOCM = 879f;
		TweenAlpha.Begin(CFFKHHJKBMJ.gameObject, 852f, 1074f, 979f).onFinished = kJOODJKNNBI.OPHINHIOCFD;
		float delay = kJOODJKNNBI.KOFOLJJPOCM + 1728f;
		CCFFNAKFPPE.transform.localPosition = new Vector3(818f, 939f, 415f);
		TweenPosition tweenPosition = TweenPosition.Begin(CCFFNAKFPPE.gameObject, 1301f, new Vector3(1723f, 969f, 108f), false);
		tweenPosition.delay = delay;
		tweenPosition.animationCurve = MBAKGBDJABD;
	}

	private void HPANGBBFNPO(UITweener MGDJMGHCAAI)
	{
		OOIIPLONENF();
	}

	private void FAGAKNHGPED(GameObject KHAHPAKDIKE)
	{
		TweenAlpha.Begin(CFFKHHJKBMJ.gameObject, 224f, 1472f).onFinished = EEKJEHAIPKF;
		if (MJIIPGJIKCA != null)
		{
			TweenAlpha.Begin(MJIIPGJIKCA.gameObject, 1191f, 771f).onFinished = null;
		}
		UIDraggablePanel.panelDisabled = false;
		GuiScreenSingle<CardMenuScreen>.instance.ONOFJIENPPD.FLFFGCDKAOC();
	}

	public void InitControls()
	{
		UIEventListener.Get(CCFFNAKFPPE.gameObject).onClick = HLCNNGJIJJJ;
	}

	public void OKDPCPHJAJH(Card GFGKDAOBCJC)
	{
		KJOODJKNNBI kJOODJKNNBI = new KJOODJKNNBI();
		kJOODJKNNBI.GFGKDAOBCJC = GFGKDAOBCJC;
		kJOODJKNNBI.BJGCPDNMHDH = this;
		UIDraggablePanel.panelDisabled = true;
		base.gameObject.SetActive(true);
		CFFKHHJKBMJ.alpha1 = 1774f;
		CFFKHHJKBMJ.isFreezed = false;
		kJOODJKNNBI.KOFOLJJPOCM = 532f;
		TweenAlpha.Begin(CFFKHHJKBMJ.gameObject, 1347f, 1250f, 1914f).onFinished = kJOODJKNNBI.JGEMIBIJMJC;
		float delay = kJOODJKNNBI.KOFOLJJPOCM + 98f;
		CCFFNAKFPPE.transform.localPosition = new Vector3(1881f, 1900f, 1455f);
		TweenPosition tweenPosition = TweenPosition.Begin(CCFFNAKFPPE.gameObject, 454f, new Vector3(231f, 532f, 742f), false);
		tweenPosition.delay = delay;
		tweenPosition.animationCurve = MBAKGBDJABD;
	}

	public void PGOMBLHHHKD()
	{
		UIEventListener.Get(CCFFNAKFPPE.gameObject).onClick = DMLHNEPPDCN;
	}

	private void EHFKMBAHHCB(UITweener MGDJMGHCAAI)
	{
		CDOACBPKOJJ();
	}

	private void EFBJPHFAPEC(GameObject KHAHPAKDIKE)
	{
		TweenAlpha.Begin(CFFKHHJKBMJ.gameObject, 1891f, 339f).onFinished = DHBGHLBNAKM;
		if (MJIIPGJIKCA != null)
		{
			TweenAlpha.Begin(MJIIPGJIKCA.gameObject, 1390f, 1751f).onFinished = null;
		}
		UIDraggablePanel.panelDisabled = false;
		GuiScreenSingle<CardMenuScreen>.instance.ONOFJIENPPD.FLFFGCDKAOC();
	}

	private void EEKJEHAIPKF(UITweener MGDJMGHCAAI)
	{
		APPEDGOEHIB();
	}

	private void BCIAOCKMMGJ(GameObject KHAHPAKDIKE)
	{
		TweenAlpha.Begin(CFFKHHJKBMJ.gameObject, 59f, 1938f).onFinished = HPANGBBFNPO;
		if (MJIIPGJIKCA != null)
		{
			TweenAlpha.Begin(MJIIPGJIKCA.gameObject, 223f, 220f).onFinished = null;
		}
		UIDraggablePanel.panelDisabled = true;
		GuiScreenSingle<CardMenuScreen>.instance.ONOFJIENPPD.FLFFGCDKAOC();
	}

	public void OOCKMPOEALO(Card GFGKDAOBCJC)
	{
		KJOODJKNNBI kJOODJKNNBI = new KJOODJKNNBI();
		kJOODJKNNBI.GFGKDAOBCJC = GFGKDAOBCJC;
		kJOODJKNNBI.BJGCPDNMHDH = this;
		UIDraggablePanel.panelDisabled = false;
		base.gameObject.SetActive(true);
		CFFKHHJKBMJ.alpha1 = 1537f;
		CFFKHHJKBMJ.isFreezed = false;
		kJOODJKNNBI.KOFOLJJPOCM = 1768f;
		TweenAlpha.Begin(CFFKHHJKBMJ.gameObject, 30f, 1254f, 1544f).onFinished = kJOODJKNNBI.JGEMIBIJMJC;
		float delay = kJOODJKNNBI.KOFOLJJPOCM + 1548f;
		CCFFNAKFPPE.transform.localPosition = new Vector3(1892f, 495f, 1591f);
		TweenPosition tweenPosition = TweenPosition.Begin(CCFFNAKFPPE.gameObject, 1327f, new Vector3(360f, 1443f, 999f));
		tweenPosition.delay = delay;
		tweenPosition.animationCurve = MBAKGBDJABD;
	}

	public void MNHAOCEONAK()
	{
		UIEventListener.Get(CCFFNAKFPPE.gameObject).onClick = EFBJPHFAPEC;
	}

	private void BMHMIHACPJL(GameObject KHAHPAKDIKE)
	{
		TweenAlpha.Begin(CFFKHHJKBMJ.gameObject, 1673f, 1651f).onFinished = BHPHPCJNGKD;
		if (MJIIPGJIKCA != null)
		{
			TweenAlpha.Begin(MJIIPGJIKCA.gameObject, 1284f, 931f).onFinished = null;
		}
		UIDraggablePanel.panelDisabled = true;
		GuiScreenSingle<CardMenuScreen>.instance.ONOFJIENPPD.FLFFGCDKAOC();
	}

	private void LDBMDBNINLH(GameObject KHAHPAKDIKE)
	{
		TweenAlpha.Begin(CFFKHHJKBMJ.gameObject, 821f, 1039f).onFinished = GAKHDICLPBF;
		if (MJIIPGJIKCA != null)
		{
			TweenAlpha.Begin(MJIIPGJIKCA.gameObject, 1100f, 650f).onFinished = null;
		}
		UIDraggablePanel.panelDisabled = false;
		GuiScreenSingle<CardMenuScreen>.instance.ONOFJIENPPD.ClaimingAnimationFinished();
	}

	private void ENABLCNAGNI(UITweener MGDJMGHCAAI)
	{
		OMMCPOINFIE();
	}

	private void JCAOCANJBNK(UITweener MGDJMGHCAAI)
	{
		KHJFFDNCBHP();
	}

	private void FHMGAMIFCDO(UITweener MGDJMGHCAAI)
	{
		DBCMAJEFKIH();
	}

	public void IIKJAILNKEH()
	{
		base.gameObject.SetActive(false);
		TweenAlpha component = GetComponent<TweenAlpha>();
		if (component != null)
		{
			component.enabled = true;
		}
		CFFKHHJKBMJ.alpha1 = 1659f;
		base.gameObject.SetActive(false);
		if (MJIIPGJIKCA != null)
		{
			MJIIPGJIKCA.OBCAIFMOPPA();
			MJIIPGJIKCA = null;
		}
	}

	private void BHPHPCJNGKD(UITweener MGDJMGHCAAI)
	{
		MKDCGEHJAML();
	}

	public void LJPAAJFNJAB()
	{
		UIEventListener.Get(CCFFNAKFPPE.gameObject).onClick = PKIMAMEIAOK;
	}

	public void MMLMOHEJJNC()
	{
		base.gameObject.SetActive(false);
		TweenAlpha component = GetComponent<TweenAlpha>();
		if (component != null)
		{
			component.enabled = false;
		}
		CFFKHHJKBMJ.alpha1 = 726f;
		base.gameObject.SetActive(false);
		if (MJIIPGJIKCA != null)
		{
			MJIIPGJIKCA.DestroyPooled();
			MJIIPGJIKCA = null;
		}
	}

	private void GAKHDICLPBF(UITweener MGDJMGHCAAI)
	{
		MKDCGEHJAML();
	}

	public void DGOEMCHLFED(Card GFGKDAOBCJC)
	{
		KJOODJKNNBI kJOODJKNNBI = new KJOODJKNNBI();
		kJOODJKNNBI.GFGKDAOBCJC = GFGKDAOBCJC;
		kJOODJKNNBI.BJGCPDNMHDH = this;
		UIDraggablePanel.panelDisabled = false;
		base.gameObject.SetActive(false);
		CFFKHHJKBMJ.alpha1 = 1820f;
		CFFKHHJKBMJ.isFreezed = true;
		kJOODJKNNBI.KOFOLJJPOCM = 1778f;
		TweenAlpha.Begin(CFFKHHJKBMJ.gameObject, 427f, 254f, 1956f).onFinished = kJOODJKNNBI.MMEEJDGGAID;
		float delay = kJOODJKNNBI.KOFOLJJPOCM + 1563f;
		CCFFNAKFPPE.transform.localPosition = new Vector3(655f, 471f, 607f);
		TweenPosition tweenPosition = TweenPosition.Begin(CCFFNAKFPPE.gameObject, 60f, new Vector3(378f, 202f, 712f));
		tweenPosition.delay = delay;
		tweenPosition.animationCurve = MBAKGBDJABD;
	}

	public void OMMCPOINFIE()
	{
		base.gameObject.SetActive(false);
		TweenAlpha component = GetComponent<TweenAlpha>();
		if (component != null)
		{
			component.enabled = true;
		}
		CFFKHHJKBMJ.alpha1 = 801f;
		base.gameObject.SetActive(true);
		if (MJIIPGJIKCA != null)
		{
			MJIIPGJIKCA.OBCAIFMOPPA();
			MJIIPGJIKCA = null;
		}
	}

	private void PKIMAMEIAOK(GameObject KHAHPAKDIKE)
	{
		TweenAlpha.Begin(CFFKHHJKBMJ.gameObject, 1011f, 934f).onFinished = JAIPKKJBDFL;
		if (MJIIPGJIKCA != null)
		{
			TweenAlpha.Begin(MJIIPGJIKCA.gameObject, 58f, 1528f).onFinished = null;
		}
		UIDraggablePanel.panelDisabled = true;
		GuiScreenSingle<CardMenuScreen>.instance.ONOFJIENPPD.ClaimingAnimationFinished();
	}

	public void DBCMAJEFKIH()
	{
		base.gameObject.SetActive(false);
		TweenAlpha component = GetComponent<TweenAlpha>();
		if (component != null)
		{
			component.enabled = true;
		}
		CFFKHHJKBMJ.alpha1 = 1189f;
		base.gameObject.SetActive(true);
		if (MJIIPGJIKCA != null)
		{
			MJIIPGJIKCA.DestroyPooled();
			MJIIPGJIKCA = null;
		}
	}

	private void JDONJMIGOFE(UITweener MGDJMGHCAAI)
	{
		APPEDGOEHIB();
	}

	public void HCAOABHNLID()
	{
		UIEventListener.Get(CCFFNAKFPPE.gameObject).onClick = GHFKDHIPDCO;
	}

	public void PLAKLPJEAHM()
	{
		UIEventListener.Get(CCFFNAKFPPE.gameObject).onClick = FAGAKNHGPED;
	}

	private void LPHGCCBNGLB(GameObject KHAHPAKDIKE)
	{
		TweenAlpha.Begin(CFFKHHJKBMJ.gameObject, 1157f, 1102f).onFinished = GAKHDICLPBF;
		if (MJIIPGJIKCA != null)
		{
			TweenAlpha.Begin(MJIIPGJIKCA.gameObject, 507f, 826f).onFinished = null;
		}
		UIDraggablePanel.panelDisabled = false;
		GuiScreenSingle<CardMenuScreen>.instance.ONOFJIENPPD.FLFFGCDKAOC();
	}

	private void DKIFIELOBND(UITweener MGDJMGHCAAI)
	{
		MKDCGEHJAML();
	}

	private void DHBGHLBNAKM(UITweener MGDJMGHCAAI)
	{
		PrepareOverlay();
	}

	public void HCGDNLHIOBL()
	{
		UIEventListener.Get(CCFFNAKFPPE.gameObject).onClick = GILLJAGGBIP;
	}

	public void IOEECBMEHNN()
	{
		base.gameObject.SetActive(true);
		TweenAlpha component = GetComponent<TweenAlpha>();
		if (component != null)
		{
			component.enabled = false;
		}
		CFFKHHJKBMJ.alpha1 = 1507f;
		base.gameObject.SetActive(false);
		if (MJIIPGJIKCA != null)
		{
			MJIIPGJIKCA.DestroyPooled();
			MJIIPGJIKCA = null;
		}
	}

	public void AnimateWarcard(Card GFGKDAOBCJC)
	{
		KJOODJKNNBI kJOODJKNNBI = new KJOODJKNNBI();
		kJOODJKNNBI.GFGKDAOBCJC = GFGKDAOBCJC;
		kJOODJKNNBI.BJGCPDNMHDH = this;
		UIDraggablePanel.panelDisabled = true;
		base.gameObject.SetActive(true);
		CFFKHHJKBMJ.alpha1 = 0f;
		CFFKHHJKBMJ.isFreezed = false;
		kJOODJKNNBI.KOFOLJJPOCM = 0.05f;
		TweenAlpha.Begin(CFFKHHJKBMJ.gameObject, 0.2f, 0f, 1f).onFinished = kJOODJKNNBI.LJCDGJKCNEC;
		float delay = kJOODJKNNBI.KOFOLJJPOCM + 0.2f;
		CCFFNAKFPPE.transform.localPosition = new Vector3(0f, -100f, 0f);
		TweenPosition tweenPosition = TweenPosition.Begin(CCFFNAKFPPE.gameObject, 0.6f, new Vector3(0f, 160f, 0f));
		tweenPosition.delay = delay;
		tweenPosition.animationCurve = MBAKGBDJABD;
	}

	public void PrepareOverlay()
	{
		base.gameObject.SetActive(true);
		TweenAlpha component = GetComponent<TweenAlpha>();
		if (component != null)
		{
			component.enabled = false;
		}
		CFFKHHJKBMJ.alpha1 = 0f;
		base.gameObject.SetActive(false);
		if (MJIIPGJIKCA != null)
		{
			MJIIPGJIKCA.DestroyPooled();
			MJIIPGJIKCA = null;
		}
	}

	public void IFFHAHNNKGA(Card GFGKDAOBCJC)
	{
		KJOODJKNNBI kJOODJKNNBI = new KJOODJKNNBI();
		kJOODJKNNBI.GFGKDAOBCJC = GFGKDAOBCJC;
		kJOODJKNNBI.BJGCPDNMHDH = this;
		UIDraggablePanel.panelDisabled = true;
		base.gameObject.SetActive(true);
		CFFKHHJKBMJ.alpha1 = 689f;
		CFFKHHJKBMJ.isFreezed = true;
		kJOODJKNNBI.KOFOLJJPOCM = 618f;
		TweenAlpha.Begin(CFFKHHJKBMJ.gameObject, 351f, 1889f, 1657f).onFinished = kJOODJKNNBI.MMEEJDGGAID;
		float delay = kJOODJKNNBI.KOFOLJJPOCM + 429f;
		CCFFNAKFPPE.transform.localPosition = new Vector3(1600f, 872f, 1050f);
		TweenPosition tweenPosition = TweenPosition.Begin(CCFFNAKFPPE.gameObject, 1948f, new Vector3(1876f, 550f, 1036f), false);
		tweenPosition.delay = delay;
		tweenPosition.animationCurve = MBAKGBDJABD;
	}

	public void APPEDGOEHIB()
	{
		base.gameObject.SetActive(true);
		TweenAlpha component = GetComponent<TweenAlpha>();
		if (component != null)
		{
			component.enabled = true;
		}
		CFFKHHJKBMJ.alpha1 = 1415f;
		base.gameObject.SetActive(false);
		if (MJIIPGJIKCA != null)
		{
			MJIIPGJIKCA.OBCAIFMOPPA();
			MJIIPGJIKCA = null;
		}
	}

	private void CDEPIKPMLBL(UITweener MGDJMGHCAAI)
	{
		PFFGLHIPDAJ();
	}

	private void ODDLDJHNOEA(GameObject KHAHPAKDIKE)
	{
		TweenAlpha.Begin(CFFKHHJKBMJ.gameObject, 257f, 1399f).onFinished = CNGAMLPANGE;
		if (MJIIPGJIKCA != null)
		{
			TweenAlpha.Begin(MJIIPGJIKCA.gameObject, 1398f, 1651f).onFinished = null;
		}
		UIDraggablePanel.panelDisabled = false;
		GuiScreenSingle<CardMenuScreen>.instance.ONOFJIENPPD.FLFFGCDKAOC();
	}

	public void OPEGELBFAMN(Card GFGKDAOBCJC)
	{
		KJOODJKNNBI kJOODJKNNBI = new KJOODJKNNBI();
		kJOODJKNNBI.GFGKDAOBCJC = GFGKDAOBCJC;
		kJOODJKNNBI.BJGCPDNMHDH = this;
		UIDraggablePanel.panelDisabled = false;
		base.gameObject.SetActive(true);
		CFFKHHJKBMJ.alpha1 = 717f;
		CFFKHHJKBMJ.isFreezed = true;
		kJOODJKNNBI.KOFOLJJPOCM = 153f;
		TweenAlpha.Begin(CFFKHHJKBMJ.gameObject, 1717f, 1339f, 401f).onFinished = kJOODJKNNBI.PEFOCGECECP;
		float delay = kJOODJKNNBI.KOFOLJJPOCM + 797f;
		CCFFNAKFPPE.transform.localPosition = new Vector3(1826f, 1113f, 326f);
		TweenPosition tweenPosition = TweenPosition.Begin(CCFFNAKFPPE.gameObject, 922f, new Vector3(394f, 485f, 1889f), false);
		tweenPosition.delay = delay;
		tweenPosition.animationCurve = MBAKGBDJABD;
	}

	private void POFKJDBFABO(GameObject KHAHPAKDIKE)
	{
		TweenAlpha.Begin(CFFKHHJKBMJ.gameObject, 789f, 226f).onFinished = MLLMKALJALG;
		if (MJIIPGJIKCA != null)
		{
			TweenAlpha.Begin(MJIIPGJIKCA.gameObject, 1152f, 1190f).onFinished = null;
		}
		UIDraggablePanel.panelDisabled = false;
		GuiScreenSingle<CardMenuScreen>.instance.ONOFJIENPPD.ClaimingAnimationFinished();
	}

	private void GILLJAGGBIP(GameObject KHAHPAKDIKE)
	{
		TweenAlpha.Begin(CFFKHHJKBMJ.gameObject, 1661f, 834f).onFinished = MHIANLDIEKI;
		if (MJIIPGJIKCA != null)
		{
			TweenAlpha.Begin(MJIIPGJIKCA.gameObject, 1053f, 1886f).onFinished = null;
		}
		UIDraggablePanel.panelDisabled = false;
		GuiScreenSingle<CardMenuScreen>.instance.ONOFJIENPPD.ClaimingAnimationFinished();
	}

	[CompilerGenerated]
	private void PALBEIKOFKK(UITweener MGDJMGHCAAI)
	{
		PrepareOverlay();
	}

	private void DFCHEPMHLLI(GameObject KHAHPAKDIKE)
	{
		TweenAlpha.Begin(CFFKHHJKBMJ.gameObject, 710f, 1730f).onFinished = delegate
		{
			PrepareOverlay();
		};
		if (MJIIPGJIKCA != null)
		{
			TweenAlpha.Begin(MJIIPGJIKCA.gameObject, 711f, 1008f).onFinished = null;
		}
		UIDraggablePanel.panelDisabled = false;
		GuiScreenSingle<CardMenuScreen>.instance.ONOFJIENPPD.ClaimingAnimationFinished();
	}

	private void DMLHNEPPDCN(GameObject KHAHPAKDIKE)
	{
		TweenAlpha.Begin(CFFKHHJKBMJ.gameObject, 1299f, 1027f).onFinished = DKIFIELOBND;
		if (MJIIPGJIKCA != null)
		{
			TweenAlpha.Begin(MJIIPGJIKCA.gameObject, 672f, 1209f).onFinished = null;
		}
		UIDraggablePanel.panelDisabled = true;
		GuiScreenSingle<CardMenuScreen>.instance.ONOFJIENPPD.FLFFGCDKAOC();
	}

	public void EFACHONJLPL()
	{
		UIEventListener.Get(CCFFNAKFPPE.gameObject).onClick = DMLHNEPPDCN;
	}

	private void HLCNNGJIJJJ(GameObject KHAHPAKDIKE)
	{
		TweenAlpha.Begin(CFFKHHJKBMJ.gameObject, 0.2f, 0f).onFinished = delegate
		{
			PrepareOverlay();
		};
		if (MJIIPGJIKCA != null)
		{
			TweenAlpha.Begin(MJIIPGJIKCA.gameObject, 0.2f, 0f).onFinished = null;
		}
		UIDraggablePanel.panelDisabled = false;
		GuiScreenSingle<CardMenuScreen>.instance.ONOFJIENPPD.ClaimingAnimationFinished();
	}

	private void PPPDFJKGGGD(UITweener MGDJMGHCAAI)
	{
		MKDCGEHJAML();
	}

	private void CLGODDBNENC(GameObject KHAHPAKDIKE)
	{
		TweenAlpha.Begin(CFFKHHJKBMJ.gameObject, 71f, 1813f).onFinished = DKIFIELOBND;
		if (MJIIPGJIKCA != null)
		{
			TweenAlpha.Begin(MJIIPGJIKCA.gameObject, 309f, 587f).onFinished = null;
		}
		UIDraggablePanel.panelDisabled = false;
		GuiScreenSingle<CardMenuScreen>.instance.ONOFJIENPPD.FLFFGCDKAOC();
	}

	public void OFEKFCBGDBM(Card GFGKDAOBCJC)
	{
		KJOODJKNNBI kJOODJKNNBI = new KJOODJKNNBI();
		kJOODJKNNBI.GFGKDAOBCJC = GFGKDAOBCJC;
		kJOODJKNNBI.BJGCPDNMHDH = this;
		UIDraggablePanel.panelDisabled = true;
		base.gameObject.SetActive(false);
		CFFKHHJKBMJ.alpha1 = 371f;
		CFFKHHJKBMJ.isFreezed = false;
		kJOODJKNNBI.KOFOLJJPOCM = 631f;
		TweenAlpha.Begin(CFFKHHJKBMJ.gameObject, 489f, 1792f, 348f).onFinished = kJOODJKNNBI.CFDNMILGDLG;
		float delay = kJOODJKNNBI.KOFOLJJPOCM + 769f;
		CCFFNAKFPPE.transform.localPosition = new Vector3(509f, 1503f, 579f);
		TweenPosition tweenPosition = TweenPosition.Begin(CCFFNAKFPPE.gameObject, 601f, new Vector3(1868f, 887f, 292f));
		tweenPosition.delay = delay;
		tweenPosition.animationCurve = MBAKGBDJABD;
	}

	private void CNGAMLPANGE(UITweener MGDJMGHCAAI)
	{
		OMMCPOINFIE();
	}

	private void ILHMNNHIAFM(GameObject KHAHPAKDIKE)
	{
		TweenAlpha.Begin(CFFKHHJKBMJ.gameObject, 1624f, 1588f).onFinished = EEKJEHAIPKF;
		if (MJIIPGJIKCA != null)
		{
			TweenAlpha.Begin(MJIIPGJIKCA.gameObject, 1655f, 999f).onFinished = null;
		}
		UIDraggablePanel.panelDisabled = true;
		GuiScreenSingle<CardMenuScreen>.instance.ONOFJIENPPD.FLFFGCDKAOC();
	}

	private void NKAKLIADNAN(GameObject KHAHPAKDIKE)
	{
		TweenAlpha.Begin(CFFKHHJKBMJ.gameObject, 768f, 1225f).onFinished = ENABLCNAGNI;
		if (MJIIPGJIKCA != null)
		{
			TweenAlpha.Begin(MJIIPGJIKCA.gameObject, 217f, 1882f).onFinished = null;
		}
		UIDraggablePanel.panelDisabled = false;
		GuiScreenSingle<CardMenuScreen>.instance.ONOFJIENPPD.FLFFGCDKAOC();
	}

	private void PCOAHNCHAJM(GameObject KHAHPAKDIKE)
	{
		TweenAlpha.Begin(CFFKHHJKBMJ.gameObject, 736f, 882f).onFinished = MLLMKALJALG;
		if (MJIIPGJIKCA != null)
		{
			TweenAlpha.Begin(MJIIPGJIKCA.gameObject, 1428f, 9f).onFinished = null;
		}
		UIDraggablePanel.panelDisabled = false;
		GuiScreenSingle<CardMenuScreen>.instance.ONOFJIENPPD.ClaimingAnimationFinished();
	}

	public void BCLAFFCPCEH()
	{
		UIEventListener.Get(CCFFNAKFPPE.gameObject).onClick = GHFKDHIPDCO;
	}

	public void MGJHBPOOIPN(Card GFGKDAOBCJC)
	{
		KJOODJKNNBI kJOODJKNNBI = new KJOODJKNNBI();
		kJOODJKNNBI.GFGKDAOBCJC = GFGKDAOBCJC;
		kJOODJKNNBI.BJGCPDNMHDH = this;
		UIDraggablePanel.panelDisabled = true;
		base.gameObject.SetActive(true);
		CFFKHHJKBMJ.alpha1 = 978f;
		CFFKHHJKBMJ.isFreezed = false;
		kJOODJKNNBI.KOFOLJJPOCM = 1825f;
		TweenAlpha.Begin(CFFKHHJKBMJ.gameObject, 1986f, 20f, 714f).onFinished = kJOODJKNNBI.JGEMIBIJMJC;
		float delay = kJOODJKNNBI.KOFOLJJPOCM + 1352f;
		CCFFNAKFPPE.transform.localPosition = new Vector3(15f, 419f, 1234f);
		TweenPosition tweenPosition = TweenPosition.Begin(CCFFNAKFPPE.gameObject, 568f, new Vector3(1263f, 1942f, 595f));
		tweenPosition.delay = delay;
		tweenPosition.animationCurve = MBAKGBDJABD;
	}

	public void BFIKGHDPPGC(Card GFGKDAOBCJC)
	{
		KJOODJKNNBI kJOODJKNNBI = new KJOODJKNNBI();
		kJOODJKNNBI.GFGKDAOBCJC = GFGKDAOBCJC;
		kJOODJKNNBI.BJGCPDNMHDH = this;
		UIDraggablePanel.panelDisabled = true;
		base.gameObject.SetActive(false);
		CFFKHHJKBMJ.alpha1 = 296f;
		CFFKHHJKBMJ.isFreezed = false;
		kJOODJKNNBI.KOFOLJJPOCM = 1140f;
		TweenAlpha.Begin(CFFKHHJKBMJ.gameObject, 1369f, 1422f, 210f).onFinished = kJOODJKNNBI.BMCMDMKGHHO;
		float delay = kJOODJKNNBI.KOFOLJJPOCM + 827f;
		CCFFNAKFPPE.transform.localPosition = new Vector3(1703f, 927f, 871f);
		TweenPosition tweenPosition = TweenPosition.Begin(CCFFNAKFPPE.gameObject, 951f, new Vector3(335f, 1222f, 1009f));
		tweenPosition.delay = delay;
		tweenPosition.animationCurve = MBAKGBDJABD;
	}

	public void MKDCGEHJAML()
	{
		base.gameObject.SetActive(true);
		TweenAlpha component = GetComponent<TweenAlpha>();
		if (component != null)
		{
			component.enabled = false;
		}
		CFFKHHJKBMJ.alpha1 = 1792f;
		base.gameObject.SetActive(false);
		if (MJIIPGJIKCA != null)
		{
			MJIIPGJIKCA.DestroyPooled();
			MJIIPGJIKCA = null;
		}
	}

	public void HLBFIPFAGAG()
	{
		base.gameObject.SetActive(false);
		TweenAlpha component = GetComponent<TweenAlpha>();
		if (component != null)
		{
			component.enabled = false;
		}
		CFFKHHJKBMJ.alpha1 = 1360f;
		base.gameObject.SetActive(true);
		if (MJIIPGJIKCA != null)
		{
			MJIIPGJIKCA.BOHCNEDIJPE();
			MJIIPGJIKCA = null;
		}
	}

	public void EKHPBJCCHJB(Card GFGKDAOBCJC)
	{
		KJOODJKNNBI kJOODJKNNBI = new KJOODJKNNBI();
		kJOODJKNNBI.GFGKDAOBCJC = GFGKDAOBCJC;
		kJOODJKNNBI.BJGCPDNMHDH = this;
		UIDraggablePanel.panelDisabled = true;
		base.gameObject.SetActive(false);
		CFFKHHJKBMJ.alpha1 = 706f;
		CFFKHHJKBMJ.isFreezed = false;
		kJOODJKNNBI.KOFOLJJPOCM = 764f;
		TweenAlpha.Begin(CFFKHHJKBMJ.gameObject, 57f, 890f, 1338f).onFinished = kJOODJKNNBI.KIACGAKNBLD;
		float delay = kJOODJKNNBI.KOFOLJJPOCM + 1610f;
		CCFFNAKFPPE.transform.localPosition = new Vector3(290f, 1602f, 274f);
		TweenPosition tweenPosition = TweenPosition.Begin(CCFFNAKFPPE.gameObject, 189f, new Vector3(1801f, 1674f, 760f), false);
		tweenPosition.delay = delay;
		tweenPosition.animationCurve = MBAKGBDJABD;
	}

	private void JAIPKKJBDFL(UITweener MGDJMGHCAAI)
	{
		HFDGKNCHBOF();
	}

	private void HNOGMMBPHAJ(UITweener MGDJMGHCAAI)
	{
		IKGAOJODHFB();
	}

	public void MGMOFABMJEM()
	{
		base.gameObject.SetActive(true);
		TweenAlpha component = GetComponent<TweenAlpha>();
		if (component != null)
		{
			component.enabled = false;
		}
		CFFKHHJKBMJ.alpha1 = 663f;
		base.gameObject.SetActive(true);
		if (MJIIPGJIKCA != null)
		{
			MJIIPGJIKCA.DestroyPooled();
			MJIIPGJIKCA = null;
		}
	}

	public void PFFGLHIPDAJ()
	{
		base.gameObject.SetActive(false);
		TweenAlpha component = GetComponent<TweenAlpha>();
		if (component != null)
		{
			component.enabled = true;
		}
		CFFKHHJKBMJ.alpha1 = 1884f;
		base.gameObject.SetActive(true);
		if (MJIIPGJIKCA != null)
		{
			MJIIPGJIKCA.BOHCNEDIJPE();
			MJIIPGJIKCA = null;
		}
	}

	private void MHIANLDIEKI(UITweener MGDJMGHCAAI)
	{
		PDKNEPFONOG();
	}

	public void IKGAOJODHFB()
	{
		base.gameObject.SetActive(false);
		TweenAlpha component = GetComponent<TweenAlpha>();
		if (component != null)
		{
			component.enabled = false;
		}
		CFFKHHJKBMJ.alpha1 = 1147f;
		base.gameObject.SetActive(true);
		if (MJIIPGJIKCA != null)
		{
			MJIIPGJIKCA.DestroyPooled();
			MJIIPGJIKCA = null;
		}
	}

	public void HONNOCAAJOD()
	{
		base.gameObject.SetActive(false);
		TweenAlpha component = GetComponent<TweenAlpha>();
		if (component != null)
		{
			component.enabled = true;
		}
		CFFKHHJKBMJ.alpha1 = 639f;
		base.gameObject.SetActive(false);
		if (MJIIPGJIKCA != null)
		{
			MJIIPGJIKCA.DestroyPooled();
			MJIIPGJIKCA = null;
		}
	}

	private void LKHLMELELND(GameObject KHAHPAKDIKE)
	{
		TweenAlpha.Begin(CFFKHHJKBMJ.gameObject, 276f, 1216f).onFinished = DHBGHLBNAKM;
		if (MJIIPGJIKCA != null)
		{
			TweenAlpha.Begin(MJIIPGJIKCA.gameObject, 1430f, 1300f).onFinished = null;
		}
		UIDraggablePanel.panelDisabled = false;
		GuiScreenSingle<CardMenuScreen>.instance.ONOFJIENPPD.ClaimingAnimationFinished();
	}

	public void OJALPBKKNKP()
	{
		base.gameObject.SetActive(false);
		TweenAlpha component = GetComponent<TweenAlpha>();
		if (component != null)
		{
			component.enabled = true;
		}
		CFFKHHJKBMJ.alpha1 = 1543f;
		base.gameObject.SetActive(true);
		if (MJIIPGJIKCA != null)
		{
			MJIIPGJIKCA.BOHCNEDIJPE();
			MJIIPGJIKCA = null;
		}
	}

	public void CDOACBPKOJJ()
	{
		base.gameObject.SetActive(false);
		TweenAlpha component = GetComponent<TweenAlpha>();
		if (component != null)
		{
			component.enabled = false;
		}
		CFFKHHJKBMJ.alpha1 = 1024f;
		base.gameObject.SetActive(true);
		if (MJIIPGJIKCA != null)
		{
			MJIIPGJIKCA.OBCAIFMOPPA();
			MJIIPGJIKCA = null;
		}
	}

	public void KENFPMINIOK(Card GFGKDAOBCJC)
	{
		KJOODJKNNBI kJOODJKNNBI = new KJOODJKNNBI();
		kJOODJKNNBI.GFGKDAOBCJC = GFGKDAOBCJC;
		kJOODJKNNBI.BJGCPDNMHDH = this;
		UIDraggablePanel.panelDisabled = false;
		base.gameObject.SetActive(false);
		CFFKHHJKBMJ.alpha1 = 891f;
		CFFKHHJKBMJ.isFreezed = true;
		kJOODJKNNBI.KOFOLJJPOCM = 1273f;
		TweenAlpha.Begin(CFFKHHJKBMJ.gameObject, 1865f, 1349f, 648f).onFinished = kJOODJKNNBI.AGFEDJAKLAC;
		float delay = kJOODJKNNBI.KOFOLJJPOCM + 1490f;
		CCFFNAKFPPE.transform.localPosition = new Vector3(1704f, 1210f, 1499f);
		TweenPosition tweenPosition = TweenPosition.Begin(CCFFNAKFPPE.gameObject, 1745f, new Vector3(1231f, 1076f, 619f));
		tweenPosition.delay = delay;
		tweenPosition.animationCurve = MBAKGBDJABD;
	}

	public void DBHFJIAILMJ(Card GFGKDAOBCJC)
	{
		KJOODJKNNBI kJOODJKNNBI = new KJOODJKNNBI();
		kJOODJKNNBI.GFGKDAOBCJC = GFGKDAOBCJC;
		kJOODJKNNBI.BJGCPDNMHDH = this;
		UIDraggablePanel.panelDisabled = false;
		base.gameObject.SetActive(true);
		CFFKHHJKBMJ.alpha1 = 1815f;
		CFFKHHJKBMJ.isFreezed = false;
		kJOODJKNNBI.KOFOLJJPOCM = 1495f;
		TweenAlpha.Begin(CFFKHHJKBMJ.gameObject, 757f, 127f, 394f).onFinished = kJOODJKNNBI.FHDOHCJJEMM;
		float delay = kJOODJKNNBI.KOFOLJJPOCM + 275f;
		CCFFNAKFPPE.transform.localPosition = new Vector3(273f, 1788f, 1353f);
		TweenPosition tweenPosition = TweenPosition.Begin(CCFFNAKFPPE.gameObject, 1002f, new Vector3(975f, 258f, 440f), false);
		tweenPosition.delay = delay;
		tweenPosition.animationCurve = MBAKGBDJABD;
	}

	public void PDKNEPFONOG()
	{
		base.gameObject.SetActive(false);
		TweenAlpha component = GetComponent<TweenAlpha>();
		if (component != null)
		{
			component.enabled = false;
		}
		CFFKHHJKBMJ.alpha1 = 1374f;
		base.gameObject.SetActive(false);
		if (MJIIPGJIKCA != null)
		{
			MJIIPGJIKCA.DestroyPooled();
			MJIIPGJIKCA = null;
		}
	}

	public void AFMPBPGLFMJ()
	{
		UIEventListener.Get(CCFFNAKFPPE.gameObject).onClick = HLCNNGJIJJJ;
	}

	public void KHJFFDNCBHP()
	{
		base.gameObject.SetActive(false);
		TweenAlpha component = GetComponent<TweenAlpha>();
		if (component != null)
		{
			component.enabled = true;
		}
		CFFKHHJKBMJ.alpha1 = 1632f;
		base.gameObject.SetActive(false);
		if (MJIIPGJIKCA != null)
		{
			MJIIPGJIKCA.BOHCNEDIJPE();
			MJIIPGJIKCA = null;
		}
	}

	private void MLLMKALJALG(UITweener MGDJMGHCAAI)
	{
		MMLMOHEJJNC();
	}

	private void GLINMEKGFGE(GameObject KHAHPAKDIKE)
	{
		TweenAlpha.Begin(CFFKHHJKBMJ.gameObject, 550f, 712f).onFinished = EHFKMBAHHCB;
		if (MJIIPGJIKCA != null)
		{
			TweenAlpha.Begin(MJIIPGJIKCA.gameObject, 783f, 674f).onFinished = null;
		}
		UIDraggablePanel.panelDisabled = false;
		GuiScreenSingle<CardMenuScreen>.instance.ONOFJIENPPD.FLFFGCDKAOC();
	}

	public void IODCFNOOAKM()
	{
		UIEventListener.Get(CCFFNAKFPPE.gameObject).onClick = PCOAHNCHAJM;
	}
}
