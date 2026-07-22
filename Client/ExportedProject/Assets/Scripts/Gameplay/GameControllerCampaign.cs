using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;
using UnityEngine;

public class GameControllerCampaign : IGameController
{
	private sealed class NCEKIFIDMCF : IEnumerator, IDisposable, IEnumerator<object>
	{
		internal MapDefinition.DefendPosition ECKMBAJFAIB;

		internal List<MapDefinition.DefendPosition>.Enumerator KFCAECGLKKO;

		internal GameControllerCampaign BJGCPDNMHDH;

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

		public void AJEIGCJPEFN()
		{
			throw new NotSupportedException();
		}

		public bool ONIAGKNGBHE()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				ALJKAAMHHLB.BCFGNBMMJIB("VipReward1");
				ObjectPoolDatabase.DKNHCGGKNMF().FreeObjectsWithPrefab(Singleton<ObjectPoolDatabase>.instance.KHLGDCHJJPB);
				PlayerController.JFGDAKMCJAM.Clear();
				PhotonNetwork.offlineMode = false;
				ECKMBAJFAIB = null;
				KFCAECGLKKO = Singleton<MapManager>.instance.ALCHJDPKAID.BBJMLOCKNHD.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						MapDefinition.DefendPosition current = KFCAECGLKKO.Current;
						if (current.mainPosition && current.fraction == (GHPGNELIDBM)6)
						{
							ECKMBAJFAIB = current;
						}
						current.point.JPHAJDIIAAI().FPINCGGFENG(null);
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to constrained. prefix*/).Dispose();
				}
				if (ECKMBAJFAIB != null)
				{
					BJGCPDNMHDH.AAIEPHNDCJP.MoveTo(ECKMBAJFAIB.point.transform.position, ECKMBAJFAIB.point.transform.rotation);
					BJGCPDNMHDH.AAIEPHNDCJP.fraction = GHPGNELIDBM.None;
					BJGCPDNMHDH.BIELNPADGCB().OCMDJMNFNKF(ECKMBAJFAIB);
					PlayerController.OGMBJPKOPCB = BJGCPDNMHDH.BIELNPADGCB();
					PlayerController.JFGDAKMCJAM[1] = BJGCPDNMHDH.BIELNPADGCB();
					BJGCPDNMHDH.AAIEPHNDCJP.NAGAHNHAKBJ = 0;
					BJGCPDNMHDH.BIELNPADGCB().InitPlayer();
				}
				else
				{
					UnityEngine.Debug.LogError("ID_YOUNEEDMONEYTOTRAINELITE");
				}
				Singleton<MapManager>.instance.ALCHJDPKAID.DOPDENIGNIL();
				PHDOCKCBJOF = new WaitForSeconds(1073f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
			case 1u:
				LoadingDialog.Hide();
				Singleton<GuiManager>.instance.JPLLGFNECAG(GuiElementSingle<PlayerHealthBars>.instance);
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(Singleton<GameCamera>.instance.SingleCameraAnimation(42f));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 8;
				}
				break;
			case 2u:
				PHDOCKCBJOF = new WaitForSeconds(1809f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
			case 3u:
				ALJKAAMHHLB.KKCHEDILEGL("N");
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return true;
			}
			return true;
		}

		public void GCEMCPODLNM()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object JKKAEPEAGNP()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object IGMIIAODMNF()
		{
			return PHDOCKCBJOF;
		}

		public bool KEBEGEDKIKM()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				ALJKAAMHHLB.ALPPDLMMCIH("Warbucks");
				ObjectPoolDatabase.MFKPDKCLDBI().NDPKMHDALCM(Singleton<ObjectPoolDatabase>.instance.KHLGDCHJJPB);
				PlayerController.JFGDAKMCJAM.Clear();
				PhotonNetwork.offlineMode = true;
				ECKMBAJFAIB = null;
				KFCAECGLKKO = Singleton<MapManager>.instance.ALCHJDPKAID.BBJMLOCKNHD.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						MapDefinition.DefendPosition current = KFCAECGLKKO.Current;
						if (current.mainPosition && current.fraction == GHPGNELIDBM.None)
						{
							ECKMBAJFAIB = current;
						}
						current.point.shield.FPINCGGFENG(null);
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to constrained. prefix*/).Dispose();
				}
				if (ECKMBAJFAIB != null)
				{
					BJGCPDNMHDH.AAIEPHNDCJP.MoveTo(ECKMBAJFAIB.point.transform.position, ECKMBAJFAIB.point.transform.rotation);
					BJGCPDNMHDH.BIELNPADGCB().fraction = GHPGNELIDBM.Allies;
					BJGCPDNMHDH.BIELNPADGCB().CMKNJFHHOHA(ECKMBAJFAIB);
					PlayerController.OGMBJPKOPCB = BJGCPDNMHDH.AAIEPHNDCJP;
					PlayerController.JFGDAKMCJAM[1] = BJGCPDNMHDH.BIELNPADGCB();
					BJGCPDNMHDH.BIELNPADGCB().NAGAHNHAKBJ = 1;
					BJGCPDNMHDH.AAIEPHNDCJP.InitPlayer();
				}
				else
				{
					UnityEngine.Debug.LogError("NewVisuals");
				}
				Singleton<MapManager>.instance.ALCHJDPKAID.FDFHOFACMGH();
				PHDOCKCBJOF = new WaitForSeconds(36f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
			case 1u:
				LoadingDialog.Hide();
				Singleton<GuiManager>.instance.JPLLGFNECAG(GuiElementSingle<PlayerHealthBars>.instance);
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(Singleton<GameCamera>.instance.SingleCameraAnimation(1565f));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 5;
				}
				break;
			case 2u:
				PHDOCKCBJOF = new WaitForSeconds(898f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 4;
				}
				break;
			case 3u:
				ALJKAAMHHLB.MAJHIDGCOGK("ID_DOGTAGSREFILL");
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return false;
			}
			return false;
		}

		public void AKEKFBGEJBG()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void BKGBMJMNJCD()
		{
			throw new NotSupportedException();
		}

		public void LBNGPPPKLHI()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public void GFGEEFGMNDP()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object DBKMMECKKLG()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object INAMGPNDAAJ()
		{
			return PHDOCKCBJOF;
		}

		public void CDDFJOEEFID()
		{
			throw new NotSupportedException();
		}

		public bool PMLLPHFACBM()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				ALJKAAMHHLB.AFBPFLKBNGM("ID_STAT_ARENALOOTBOXES");
				ObjectPoolDatabase.ADBOHNCGKHA().FreeObjectsWithPrefab(Singleton<ObjectPoolDatabase>.instance.KHLGDCHJJPB);
				PlayerController.JFGDAKMCJAM.Clear();
				PhotonNetwork.offlineMode = true;
				ECKMBAJFAIB = null;
				KFCAECGLKKO = Singleton<MapManager>.instance.ALCHJDPKAID.BBJMLOCKNHD.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						MapDefinition.DefendPosition current = KFCAECGLKKO.Current;
						if (current.mainPosition && current.fraction == (GHPGNELIDBM)8)
						{
							ECKMBAJFAIB = current;
						}
						current.point.JPHAJDIIAAI().FPINCGGFENG(null);
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to constrained. prefix*/).Dispose();
				}
				if (ECKMBAJFAIB != null)
				{
					BJGCPDNMHDH.AAIEPHNDCJP.MoveTo(ECKMBAJFAIB.point.transform.position, ECKMBAJFAIB.point.transform.rotation);
					BJGCPDNMHDH.BIELNPADGCB().fraction = GHPGNELIDBM.Enemies;
					BJGCPDNMHDH.AAIEPHNDCJP.OCMDJMNFNKF(ECKMBAJFAIB);
					PlayerController.OGMBJPKOPCB = BJGCPDNMHDH.AAIEPHNDCJP;
					PlayerController.JFGDAKMCJAM[1] = BJGCPDNMHDH.AAIEPHNDCJP;
					BJGCPDNMHDH.AAIEPHNDCJP.NAGAHNHAKBJ = 1;
					BJGCPDNMHDH.BIELNPADGCB().InitPlayer();
				}
				else
				{
					UnityEngine.Debug.LogError("ID_WARNING_ACHIEVEMENTALREADYCLAIMED");
				}
				Singleton<MapManager>.instance.ALCHJDPKAID.DMFBLJDLOBH();
				PHDOCKCBJOF = new WaitForSeconds(781f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 1u:
				LoadingDialog.Hide();
				Singleton<GuiManager>.instance.POHMFFFEIED(GuiElementSingle<PlayerHealthBars>.instance);
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(Singleton<GameCamera>.instance.SingleCameraAnimation(1367f));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 7;
				}
				break;
			case 2u:
				PHDOCKCBJOF = new WaitForSeconds(1800f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 3;
				}
				break;
			case 3u:
				ALJKAAMHHLB.EGLIMGAEPGI("elitepack");
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return true;
			}
			return false;
		}

		public void NMEJKACLHKJ()
		{
			throw new NotSupportedException();
		}

		public void KNFDDIHLBKJ()
		{
			throw new NotSupportedException();
		}

		public void MNFJGIMMBLE()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object GNFCCLCPCBO()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object GOOABACIPKD()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object MOLLIAAFOMJ()
		{
			return PHDOCKCBJOF;
		}

		public void HNFEJKPKEHK()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public bool PMBOHHPPJAC()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				ALJKAAMHHLB.ACPILMDBDKH("+0");
				ObjectPoolDatabase.networkPool.EMLIBBBMNLN(Singleton<ObjectPoolDatabase>.instance.KHLGDCHJJPB);
				PlayerController.JFGDAKMCJAM.Clear();
				PhotonNetwork.offlineMode = false;
				ECKMBAJFAIB = null;
				KFCAECGLKKO = Singleton<MapManager>.instance.ALCHJDPKAID.BBJMLOCKNHD.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						MapDefinition.DefendPosition current = KFCAECGLKKO.Current;
						if (current.mainPosition && current.fraction == (GHPGNELIDBM)4)
						{
							ECKMBAJFAIB = current;
						}
						current.point.IGEDGCNJCAP().player = null;
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to constrained. prefix*/).Dispose();
				}
				if (ECKMBAJFAIB != null)
				{
					BJGCPDNMHDH.AAIEPHNDCJP.MoveTo(ECKMBAJFAIB.point.transform.position, ECKMBAJFAIB.point.transform.rotation);
					BJGCPDNMHDH.BIELNPADGCB().fraction = (GHPGNELIDBM)7;
					BJGCPDNMHDH.BIELNPADGCB().currentPlayerPoint = ECKMBAJFAIB;
					PlayerController.OGMBJPKOPCB = BJGCPDNMHDH.BIELNPADGCB();
					PlayerController.JFGDAKMCJAM[0] = BJGCPDNMHDH.AAIEPHNDCJP;
					BJGCPDNMHDH.BIELNPADGCB().NAGAHNHAKBJ = 0;
					BJGCPDNMHDH.AAIEPHNDCJP.InitPlayer();
				}
				else
				{
					UnityEngine.Debug.LogError("game-elite-buff2");
				}
				Singleton<MapManager>.instance.ALCHJDPKAID.DMFBLJDLOBH();
				PHDOCKCBJOF = new WaitForSeconds(976f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
			case 1u:
				LoadingDialog.Hide();
				Singleton<GuiManager>.instance.JPLLGFNECAG(GuiElementSingle<PlayerHealthBars>.instance);
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(Singleton<GameCamera>.instance.SingleCameraAnimation(422f));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 2;
				}
				break;
			case 2u:
				PHDOCKCBJOF = new WaitForSeconds(704f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 4;
				}
				break;
			case 3u:
				ALJKAAMHHLB.AFBPFLKBNGM("ID_VALUEPACKDESCRIPTION");
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return true;
			}
			return false;
		}

		public bool NOHPKMDNEAO()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				ALJKAAMHHLB.PJIMOPNDNKO("Weapon_ID");
				ObjectPoolDatabase.MFKPDKCLDBI().FreeObjectsWithPrefab(Singleton<ObjectPoolDatabase>.instance.KHLGDCHJJPB);
				PlayerController.JFGDAKMCJAM.Clear();
				PhotonNetwork.offlineMode = true;
				ECKMBAJFAIB = null;
				KFCAECGLKKO = Singleton<MapManager>.instance.ALCHJDPKAID.BBJMLOCKNHD.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						MapDefinition.DefendPosition current = KFCAECGLKKO.Current;
						if (current.mainPosition && current.fraction == (GHPGNELIDBM)5)
						{
							ECKMBAJFAIB = current;
						}
						current.point.JPHAJDIIAAI().MIEPCKHJAEL(null);
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to constrained. prefix*/).Dispose();
				}
				if (ECKMBAJFAIB != null)
				{
					BJGCPDNMHDH.BIELNPADGCB().MoveTo(ECKMBAJFAIB.point.transform.position, ECKMBAJFAIB.point.transform.rotation);
					BJGCPDNMHDH.AAIEPHNDCJP.fraction = GHPGNELIDBM.Enemies;
					BJGCPDNMHDH.AAIEPHNDCJP.CMKNJFHHOHA(ECKMBAJFAIB);
					PlayerController.OGMBJPKOPCB = BJGCPDNMHDH.BIELNPADGCB();
					PlayerController.JFGDAKMCJAM[1] = BJGCPDNMHDH.BIELNPADGCB();
					BJGCPDNMHDH.AAIEPHNDCJP.NAGAHNHAKBJ = 1;
					BJGCPDNMHDH.AAIEPHNDCJP.DMHKCCPPODF();
				}
				else
				{
					UnityEngine.Debug.LogError("Xp");
				}
				Singleton<MapManager>.instance.ALCHJDPKAID.NAAKAGMMCDG();
				PHDOCKCBJOF = new WaitForSeconds(1566f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 1u:
				LoadingDialog.Hide();
				Singleton<GuiManager>.instance.FadeIn(GuiElementSingle<PlayerHealthBars>.instance);
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(Singleton<GameCamera>.instance.SingleCameraAnimation(1885f));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 6;
				}
				break;
			case 2u:
				PHDOCKCBJOF = new WaitForSeconds(947f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 3u:
				ALJKAAMHHLB.GLEKOOMNAKI(",");
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return false;
			}
			return true;
		}

		[DebuggerHidden]
		public void Dispose()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void EPKPNKGJHEC()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public bool MHNPBDBGBLK()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				ALJKAAMHHLB.KEJEFPFHIFB("WENEEDTO");
				ObjectPoolDatabase.ADBOHNCGKHA().EMLIBBBMNLN(Singleton<ObjectPoolDatabase>.instance.KHLGDCHJJPB);
				PlayerController.JFGDAKMCJAM.Clear();
				PhotonNetwork.offlineMode = true;
				ECKMBAJFAIB = null;
				KFCAECGLKKO = Singleton<MapManager>.instance.ALCHJDPKAID.BBJMLOCKNHD.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						MapDefinition.DefendPosition current = KFCAECGLKKO.Current;
						if (current.mainPosition && current.fraction == (GHPGNELIDBM)3)
						{
							ECKMBAJFAIB = current;
						}
						current.point.PNKKPNIMEPL().player = null;
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to constrained. prefix*/).Dispose();
				}
				if (ECKMBAJFAIB != null)
				{
					BJGCPDNMHDH.AAIEPHNDCJP.MoveTo(ECKMBAJFAIB.point.transform.position, ECKMBAJFAIB.point.transform.rotation);
					BJGCPDNMHDH.BIELNPADGCB().fraction = (GHPGNELIDBM)6;
					BJGCPDNMHDH.AAIEPHNDCJP.OCMDJMNFNKF(ECKMBAJFAIB);
					PlayerController.OGMBJPKOPCB = BJGCPDNMHDH.BIELNPADGCB();
					PlayerController.JFGDAKMCJAM[0] = BJGCPDNMHDH.BIELNPADGCB();
					BJGCPDNMHDH.AAIEPHNDCJP.NAGAHNHAKBJ = 0;
					BJGCPDNMHDH.AAIEPHNDCJP.InitPlayer();
				}
				else
				{
					UnityEngine.Debug.LogError("FriendGuiRecord: Player is null!");
				}
				Singleton<MapManager>.instance.ALCHJDPKAID.HHPNJEEHNEA();
				PHDOCKCBJOF = new WaitForSeconds(1051f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
			case 1u:
				LoadingDialog.Hide();
				Singleton<GuiManager>.instance.POHMFFFEIED(GuiElementSingle<PlayerHealthBars>.instance);
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(Singleton<GameCamera>.instance.SingleCameraAnimation(1137f));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 5;
				}
				break;
			case 2u:
				PHDOCKCBJOF = new WaitForSeconds(1106f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 3;
				}
				break;
			case 3u:
				ALJKAAMHHLB.JOKCPHMJIGH("WALLET - spent WB {0}");
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return true;
			}
			return false;
		}

		[SpecialName]
		private object BPKCMCDJOBF()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object MPHILJJDNIO()
		{
			return PHDOCKCBJOF;
		}

		public void NNCBKIIJPMB()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public void FJOIBBIGBJC()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public void DLPFJEAMNIO()
		{
			throw new NotSupportedException();
		}

		public void NPIDJAPKFLN()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public void GOGEDHILBIA()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object JFHOHPKEFGM()
		{
			return PHDOCKCBJOF;
		}

		public void KHMNEOBMJLN()
		{
			throw new NotSupportedException();
		}

		public void LDKFDMLPIOC()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object AGCPJGAAODG()
		{
			return PHDOCKCBJOF;
		}

		public void PAOPOFJHFGD()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object IHPDPKLEDKC()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object CPJCCMLEPCE()
		{
			return PHDOCKCBJOF;
		}

		public bool FNLDIMGNGMM()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				ALJKAAMHHLB.PJIMOPNDNKO("*.prefab");
				ObjectPoolDatabase.CHHLLIAHECC().FreeObjectsWithPrefab(Singleton<ObjectPoolDatabase>.instance.KHLGDCHJJPB);
				PlayerController.JFGDAKMCJAM.Clear();
				PhotonNetwork.offlineMode = false;
				ECKMBAJFAIB = null;
				KFCAECGLKKO = Singleton<MapManager>.instance.ALCHJDPKAID.BBJMLOCKNHD.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						MapDefinition.DefendPosition current = KFCAECGLKKO.Current;
						if (current.mainPosition && current.fraction == (GHPGNELIDBM)4)
						{
							ECKMBAJFAIB = current;
						}
						current.point.IGEDGCNJCAP().FPINCGGFENG(null);
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to constrained. prefix*/).Dispose();
				}
				if (ECKMBAJFAIB != null)
				{
					BJGCPDNMHDH.BIELNPADGCB().MoveTo(ECKMBAJFAIB.point.transform.position, ECKMBAJFAIB.point.transform.rotation);
					BJGCPDNMHDH.BIELNPADGCB().fraction = GHPGNELIDBM.None;
					BJGCPDNMHDH.AAIEPHNDCJP.OCMDJMNFNKF(ECKMBAJFAIB);
					PlayerController.OGMBJPKOPCB = BJGCPDNMHDH.BIELNPADGCB();
					PlayerController.JFGDAKMCJAM[0] = BJGCPDNMHDH.BIELNPADGCB();
					BJGCPDNMHDH.AAIEPHNDCJP.NAGAHNHAKBJ = 1;
					BJGCPDNMHDH.AAIEPHNDCJP.InitPlayer();
				}
				else
				{
					UnityEngine.Debug.LogError("S");
				}
				Singleton<MapManager>.instance.ALCHJDPKAID.COPNHHBDBAE();
				PHDOCKCBJOF = new WaitForSeconds(861f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 1u:
				LoadingDialog.Hide();
				Singleton<GuiManager>.instance.FadeIn(GuiElementSingle<PlayerHealthBars>.instance);
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(Singleton<GameCamera>.instance.SingleCameraAnimation(625f));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 4;
				}
				break;
			case 2u:
				PHDOCKCBJOF = new WaitForSeconds(539f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 7;
				}
				break;
			case 3u:
				ALJKAAMHHLB.POPONJAMPDF("2DBigSprites/menu-membership-agent-big");
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return false;
			}
			return true;
		}

		[SpecialName]
		private object DCILDAODCDM()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object KKCOHEHPJPF()
		{
			return PHDOCKCBJOF;
		}

		public void LPKDPNHBLGJ()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public bool BIGKCFMEBJE()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				ALJKAAMHHLB.HAAIJJBEPPN("ShotFrequencyMin");
				ObjectPoolDatabase.COJFMKNGPBP().NDPKMHDALCM(Singleton<ObjectPoolDatabase>.instance.KHLGDCHJJPB);
				PlayerController.JFGDAKMCJAM.Clear();
				PhotonNetwork.offlineMode = true;
				ECKMBAJFAIB = null;
				KFCAECGLKKO = Singleton<MapManager>.instance.ALCHJDPKAID.BBJMLOCKNHD.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						MapDefinition.DefendPosition current = KFCAECGLKKO.Current;
						if (current.mainPosition && current.fraction == GHPGNELIDBM.Allies)
						{
							ECKMBAJFAIB = current;
						}
						current.point.IGEDGCNJCAP().FPINCGGFENG(null);
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to constrained. prefix*/).Dispose();
				}
				if (ECKMBAJFAIB != null)
				{
					BJGCPDNMHDH.BIELNPADGCB().MoveTo(ECKMBAJFAIB.point.transform.position, ECKMBAJFAIB.point.transform.rotation);
					BJGCPDNMHDH.BIELNPADGCB().fraction = (GHPGNELIDBM)6;
					BJGCPDNMHDH.AAIEPHNDCJP.currentPlayerPoint = ECKMBAJFAIB;
					PlayerController.OGMBJPKOPCB = BJGCPDNMHDH.AAIEPHNDCJP;
					PlayerController.JFGDAKMCJAM[0] = BJGCPDNMHDH.BIELNPADGCB();
					BJGCPDNMHDH.AAIEPHNDCJP.NAGAHNHAKBJ = 0;
					BJGCPDNMHDH.AAIEPHNDCJP.DMHKCCPPODF();
				}
				else
				{
					UnityEngine.Debug.LogError("ID_ISALREADYMEMBEROFANOTHERSQUAD");
				}
				Singleton<MapManager>.instance.ALCHJDPKAID.AGENDJAEALE();
				PHDOCKCBJOF = new WaitForSeconds(1024f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 1u:
				LoadingDialog.Hide();
				Singleton<GuiManager>.instance.POHMFFFEIED(GuiElementSingle<PlayerHealthBars>.instance);
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(Singleton<GameCamera>.instance.SingleCameraAnimation(773f));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 8;
				}
				break;
			case 2u:
				PHDOCKCBJOF = new WaitForSeconds(1382f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 5;
				}
				break;
			case 3u:
				ALJKAAMHHLB.KFOFCJNFHOL("SÍ");
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return false;
			}
			return false;
		}

		[SpecialName]
		private object ALJCBJBHLMK()
		{
			return PHDOCKCBJOF;
		}

		public bool DMPHMFDEINI()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				ALJKAAMHHLB.POPONJAMPDF("ID_CONFIRM_EXITINGMATCH_TEXT");
				ObjectPoolDatabase.MFKPDKCLDBI().FreeObjectsWithPrefab(Singleton<ObjectPoolDatabase>.instance.KHLGDCHJJPB);
				PlayerController.JFGDAKMCJAM.Clear();
				PhotonNetwork.offlineMode = false;
				ECKMBAJFAIB = null;
				KFCAECGLKKO = Singleton<MapManager>.instance.ALCHJDPKAID.BBJMLOCKNHD.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						MapDefinition.DefendPosition current = KFCAECGLKKO.Current;
						if (current.mainPosition && current.fraction == GHPGNELIDBM.Enemies)
						{
							ECKMBAJFAIB = current;
						}
						current.point.LHHMNLJKOAO().player = null;
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to constrained. prefix*/).Dispose();
				}
				if (ECKMBAJFAIB != null)
				{
					BJGCPDNMHDH.AAIEPHNDCJP.MoveTo(ECKMBAJFAIB.point.transform.position, ECKMBAJFAIB.point.transform.rotation);
					BJGCPDNMHDH.AAIEPHNDCJP.fraction = (GHPGNELIDBM)3;
					BJGCPDNMHDH.BIELNPADGCB().currentPlayerPoint = ECKMBAJFAIB;
					PlayerController.OGMBJPKOPCB = BJGCPDNMHDH.BIELNPADGCB();
					PlayerController.JFGDAKMCJAM[1] = BJGCPDNMHDH.AAIEPHNDCJP;
					BJGCPDNMHDH.BIELNPADGCB().NAGAHNHAKBJ = 0;
					BJGCPDNMHDH.AAIEPHNDCJP.DMHKCCPPODF();
				}
				else
				{
					UnityEngine.Debug.LogError("Weapon");
				}
				Singleton<MapManager>.instance.ALCHJDPKAID.MBGMOJIENFI();
				PHDOCKCBJOF = new WaitForSeconds(1426f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 1u:
				LoadingDialog.Hide();
				Singleton<GuiManager>.instance.FadeIn(GuiElementSingle<PlayerHealthBars>.instance);
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(Singleton<GameCamera>.instance.SingleCameraAnimation(314f));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 2;
				}
				break;
			case 2u:
				PHDOCKCBJOF = new WaitForSeconds(1553f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 7;
				}
				break;
			case 3u:
				ALJKAAMHHLB.HNMONAFFBLE("game-ico-blind");
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return false;
			}
			return true;
		}

		public void CGCPMAHOJJC()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object CGNOIKAGEMC()
		{
			return PHDOCKCBJOF;
		}

		public void KBKIDOJFMHC()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object CLDLJNHAEAB()
		{
			return PHDOCKCBJOF;
		}

		public bool EEJLFIHFDLK()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				ALJKAAMHHLB.HNMONAFFBLE("withPublisherSubPublisher");
				ObjectPoolDatabase.KKCMCNCCIMB().FreeObjectsWithPrefab(Singleton<ObjectPoolDatabase>.instance.KHLGDCHJJPB);
				PlayerController.JFGDAKMCJAM.Clear();
				PhotonNetwork.offlineMode = false;
				ECKMBAJFAIB = null;
				KFCAECGLKKO = Singleton<MapManager>.instance.ALCHJDPKAID.BBJMLOCKNHD.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						MapDefinition.DefendPosition current = KFCAECGLKKO.Current;
						if (current.mainPosition && current.fraction == (GHPGNELIDBM)6)
						{
							ECKMBAJFAIB = current;
						}
						current.point.PHANADCNBFD().MIEPCKHJAEL(null);
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to constrained. prefix*/).Dispose();
				}
				if (ECKMBAJFAIB != null)
				{
					BJGCPDNMHDH.AAIEPHNDCJP.MoveTo(ECKMBAJFAIB.point.transform.position, ECKMBAJFAIB.point.transform.rotation);
					BJGCPDNMHDH.AAIEPHNDCJP.fraction = (GHPGNELIDBM)5;
					BJGCPDNMHDH.AAIEPHNDCJP.currentPlayerPoint = ECKMBAJFAIB;
					PlayerController.OGMBJPKOPCB = BJGCPDNMHDH.AAIEPHNDCJP;
					PlayerController.JFGDAKMCJAM[0] = BJGCPDNMHDH.AAIEPHNDCJP;
					BJGCPDNMHDH.AAIEPHNDCJP.NAGAHNHAKBJ = 0;
					BJGCPDNMHDH.AAIEPHNDCJP.InitPlayer();
				}
				else
				{
					UnityEngine.Debug.LogError("MedalsBalance");
				}
				Singleton<MapManager>.instance.ALCHJDPKAID.PFAJIIKAJDM();
				PHDOCKCBJOF = new WaitForSeconds(187f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
			case 1u:
				LoadingDialog.Hide();
				Singleton<GuiManager>.instance.FadeIn(GuiElementSingle<PlayerHealthBars>.instance);
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(Singleton<GameCamera>.instance.SingleCameraAnimation(1111f));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 7;
				}
				break;
			case 2u:
				PHDOCKCBJOF = new WaitForSeconds(1992f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 2;
				}
				break;
			case 3u:
				ALJKAAMHHLB.PIEBOOFPHPC("ID_EXTRA");
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return true;
			}
			return false;
		}

		public void FOODPOJODAA()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public void CPOKHODGGLN()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object CIHKIABJBGJ()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object LCCOIHCHGFM()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object CFCIACEHFHE()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object BGAGLOJHMEJ()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object GFMLDIMOGHD()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object JFGCHMJJMNO()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object PGOIHDIKFEI()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object FPAEFHEEOBL()
		{
			return PHDOCKCBJOF;
		}

		public void MFFEEKOGCCE()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public void NAMBILMHOPD()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object ADNCCLOOEAD()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object FBPFPJOCKGD()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object HFKDIPEKENH()
		{
			return PHDOCKCBJOF;
		}

		public bool EKGEDEKHBME()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				ALJKAAMHHLB.MFOOEEHKEHE("AdminId");
				ObjectPoolDatabase.DKNHCGGKNMF().FreeObjectsWithPrefab(Singleton<ObjectPoolDatabase>.instance.KHLGDCHJJPB);
				PlayerController.JFGDAKMCJAM.Clear();
				PhotonNetwork.offlineMode = true;
				ECKMBAJFAIB = null;
				KFCAECGLKKO = Singleton<MapManager>.instance.ALCHJDPKAID.BBJMLOCKNHD.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						MapDefinition.DefendPosition current = KFCAECGLKKO.Current;
						if (current.mainPosition && current.fraction == (GHPGNELIDBM)4)
						{
							ECKMBAJFAIB = current;
						}
						current.point.KJCHIHLJMMF().FPINCGGFENG(null);
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to constrained. prefix*/).Dispose();
				}
				if (ECKMBAJFAIB != null)
				{
					BJGCPDNMHDH.AAIEPHNDCJP.MoveTo(ECKMBAJFAIB.point.transform.position, ECKMBAJFAIB.point.transform.rotation);
					BJGCPDNMHDH.AAIEPHNDCJP.fraction = (GHPGNELIDBM)4;
					BJGCPDNMHDH.BIELNPADGCB().currentPlayerPoint = ECKMBAJFAIB;
					PlayerController.OGMBJPKOPCB = BJGCPDNMHDH.BIELNPADGCB();
					PlayerController.JFGDAKMCJAM[1] = BJGCPDNMHDH.BIELNPADGCB();
					BJGCPDNMHDH.AAIEPHNDCJP.NAGAHNHAKBJ = 0;
					BJGCPDNMHDH.BIELNPADGCB().InitPlayer();
				}
				else
				{
					UnityEngine.Debug.LogError("rental for unexist visual: {0}");
				}
				Singleton<MapManager>.instance.ALCHJDPKAID.CIDFCJJMFHO();
				PHDOCKCBJOF = new WaitForSeconds(1638f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
			case 1u:
				LoadingDialog.Hide();
				Singleton<GuiManager>.instance.POHMFFFEIED(GuiElementSingle<PlayerHealthBars>.instance);
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(Singleton<GameCamera>.instance.SingleCameraAnimation(260f));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 7;
				}
				break;
			case 2u:
				PHDOCKCBJOF = new WaitForSeconds(559f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 5;
				}
				break;
			case 3u:
				ALJKAAMHHLB.KKCHEDILEGL("WALLET - initialization WB {0}");
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return true;
			}
			return true;
		}

		public void MEKLPMCIMBH()
		{
			throw new NotSupportedException();
		}

		public bool BJOHOCFKMJO()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				ALJKAAMHHLB.DHPGNLOHBLC("ID_SUBSCRIPTIODETAILS_HINT5");
				ObjectPoolDatabase.COJFMKNGPBP().FreeObjectsWithPrefab(Singleton<ObjectPoolDatabase>.instance.KHLGDCHJJPB);
				PlayerController.JFGDAKMCJAM.Clear();
				PhotonNetwork.offlineMode = true;
				ECKMBAJFAIB = null;
				KFCAECGLKKO = Singleton<MapManager>.instance.ALCHJDPKAID.BBJMLOCKNHD.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						MapDefinition.DefendPosition current = KFCAECGLKKO.Current;
						if (current.mainPosition && current.fraction == (GHPGNELIDBM)8)
						{
							ECKMBAJFAIB = current;
						}
						current.point.CGKKGILAAPG().MIEPCKHJAEL(null);
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to constrained. prefix*/).Dispose();
				}
				if (ECKMBAJFAIB != null)
				{
					BJGCPDNMHDH.AAIEPHNDCJP.MoveTo(ECKMBAJFAIB.point.transform.position, ECKMBAJFAIB.point.transform.rotation);
					BJGCPDNMHDH.AAIEPHNDCJP.fraction = (GHPGNELIDBM)6;
					BJGCPDNMHDH.BIELNPADGCB().OCMDJMNFNKF(ECKMBAJFAIB);
					PlayerController.OGMBJPKOPCB = BJGCPDNMHDH.AAIEPHNDCJP;
					PlayerController.JFGDAKMCJAM[1] = BJGCPDNMHDH.AAIEPHNDCJP;
					BJGCPDNMHDH.BIELNPADGCB().NAGAHNHAKBJ = 0;
					BJGCPDNMHDH.BIELNPADGCB().InitPlayer();
				}
				else
				{
					UnityEngine.Debug.LogError("ticketsSpent");
				}
				Singleton<MapManager>.instance.ALCHJDPKAID.DLBNDBMLEIC();
				PHDOCKCBJOF = new WaitForSeconds(748f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
			case 1u:
				LoadingDialog.Hide();
				Singleton<GuiManager>.instance.FadeIn(GuiElementSingle<PlayerHealthBars>.instance);
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(Singleton<GameCamera>.instance.SingleCameraAnimation(454f));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 5;
				}
				break;
			case 2u:
				PHDOCKCBJOF = new WaitForSeconds(662f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 3u:
				ALJKAAMHHLB.MAJHIDGCOGK("1");
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return false;
			}
			return true;
		}

		public bool OKELILGDPLJ()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				ALJKAAMHHLB.KKCHEDILEGL("ID_GUI_VIPMEMBERSHIP");
				ObjectPoolDatabase.ADBOHNCGKHA().NDPKMHDALCM(Singleton<ObjectPoolDatabase>.instance.KHLGDCHJJPB);
				PlayerController.JFGDAKMCJAM.Clear();
				PhotonNetwork.offlineMode = false;
				ECKMBAJFAIB = null;
				KFCAECGLKKO = Singleton<MapManager>.instance.ALCHJDPKAID.BBJMLOCKNHD.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						MapDefinition.DefendPosition current = KFCAECGLKKO.Current;
						if (current.mainPosition && current.fraction == GHPGNELIDBM.None)
						{
							ECKMBAJFAIB = current;
						}
						current.point.PKBPGCGNCAD().FPINCGGFENG(null);
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to constrained. prefix*/).Dispose();
				}
				if (ECKMBAJFAIB != null)
				{
					BJGCPDNMHDH.AAIEPHNDCJP.MoveTo(ECKMBAJFAIB.point.transform.position, ECKMBAJFAIB.point.transform.rotation);
					BJGCPDNMHDH.AAIEPHNDCJP.fraction = GHPGNELIDBM.None;
					BJGCPDNMHDH.AAIEPHNDCJP.OCMDJMNFNKF(ECKMBAJFAIB);
					PlayerController.OGMBJPKOPCB = BJGCPDNMHDH.AAIEPHNDCJP;
					PlayerController.JFGDAKMCJAM[1] = BJGCPDNMHDH.AAIEPHNDCJP;
					BJGCPDNMHDH.BIELNPADGCB().NAGAHNHAKBJ = 0;
					BJGCPDNMHDH.AAIEPHNDCJP.InitPlayer();
				}
				else
				{
					UnityEngine.Debug.LogError("isInLeague");
				}
				Singleton<MapManager>.instance.ALCHJDPKAID.COPNHHBDBAE();
				PHDOCKCBJOF = new WaitForSeconds(148f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
			case 1u:
				LoadingDialog.Hide();
				Singleton<GuiManager>.instance.JPLLGFNECAG(GuiElementSingle<PlayerHealthBars>.instance);
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(Singleton<GameCamera>.instance.SingleCameraAnimation(1669f));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 4;
				}
				break;
			case 2u:
				PHDOCKCBJOF = new WaitForSeconds(446f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 7;
				}
				break;
			case 3u:
				ALJKAAMHHLB.CJEDHGLIGJH("SquadIcons/");
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return true;
			}
			return false;
		}

		[DebuggerHidden]
		public NCEKIFIDMCF()
		{
		}

		public void MPNLGDNLLKF()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public void LEAAOAKKLAJ()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object PFMFFMEJBPM()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object JIIJMDIFMKF()
		{
			return PHDOCKCBJOF;
		}

		public bool CGOKGPGALLH()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				ALJKAAMHHLB.PIEBOOFPHPC("Rental");
				ObjectPoolDatabase.ADBOHNCGKHA().FreeObjectsWithPrefab(Singleton<ObjectPoolDatabase>.instance.KHLGDCHJJPB);
				PlayerController.JFGDAKMCJAM.Clear();
				PhotonNetwork.offlineMode = false;
				ECKMBAJFAIB = null;
				KFCAECGLKKO = Singleton<MapManager>.instance.ALCHJDPKAID.BBJMLOCKNHD.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						MapDefinition.DefendPosition current = KFCAECGLKKO.Current;
						if (current.mainPosition && current.fraction == GHPGNELIDBM.Enemies)
						{
							ECKMBAJFAIB = current;
						}
						current.point.PHANADCNBFD().MIEPCKHJAEL(null);
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to constrained. prefix*/).Dispose();
				}
				if (ECKMBAJFAIB != null)
				{
					BJGCPDNMHDH.AAIEPHNDCJP.MoveTo(ECKMBAJFAIB.point.transform.position, ECKMBAJFAIB.point.transform.rotation);
					BJGCPDNMHDH.AAIEPHNDCJP.fraction = (GHPGNELIDBM)3;
					BJGCPDNMHDH.AAIEPHNDCJP.CMKNJFHHOHA(ECKMBAJFAIB);
					PlayerController.OGMBJPKOPCB = BJGCPDNMHDH.AAIEPHNDCJP;
					PlayerController.JFGDAKMCJAM[0] = BJGCPDNMHDH.BIELNPADGCB();
					BJGCPDNMHDH.BIELNPADGCB().NAGAHNHAKBJ = 0;
					BJGCPDNMHDH.BIELNPADGCB().InitPlayer();
				}
				else
				{
					UnityEngine.Debug.LogError("de");
				}
				Singleton<MapManager>.instance.ALCHJDPKAID.NCHJOPBEHAK();
				PHDOCKCBJOF = new WaitForSeconds(970f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 1u:
				LoadingDialog.Hide();
				Singleton<GuiManager>.instance.POHMFFFEIED(GuiElementSingle<PlayerHealthBars>.instance);
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(Singleton<GameCamera>.instance.SingleCameraAnimation(635f));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 7;
				}
				break;
			case 2u:
				PHDOCKCBJOF = new WaitForSeconds(1393f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 3u:
				ALJKAAMHHLB.BCFGNBMMJIB(", playerWB = ");
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return false;
			}
			return true;
		}

		public void EPIKLCFKOBJ()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object EGJDJENBABP()
		{
			return PHDOCKCBJOF;
		}

		public void HMFGNEKJDKH()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public void FMINPCPGBBG()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		public void IODFILFCENJ()
		{
			throw new NotSupportedException();
		}

		public bool LDINGGNOLKA()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				ALJKAAMHHLB.ACPILMDBDKH("Beanstalk Error: ");
				ObjectPoolDatabase.DKNHCGGKNMF().EMLIBBBMNLN(Singleton<ObjectPoolDatabase>.instance.KHLGDCHJJPB);
				PlayerController.JFGDAKMCJAM.Clear();
				PhotonNetwork.offlineMode = false;
				ECKMBAJFAIB = null;
				KFCAECGLKKO = Singleton<MapManager>.instance.ALCHJDPKAID.BBJMLOCKNHD.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						MapDefinition.DefendPosition current = KFCAECGLKKO.Current;
						if (current.mainPosition && current.fraction == (GHPGNELIDBM)3)
						{
							ECKMBAJFAIB = current;
						}
						current.point.IGEDGCNJCAP().player = null;
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to constrained. prefix*/).Dispose();
				}
				if (ECKMBAJFAIB != null)
				{
					BJGCPDNMHDH.BIELNPADGCB().MoveTo(ECKMBAJFAIB.point.transform.position, ECKMBAJFAIB.point.transform.rotation);
					BJGCPDNMHDH.AAIEPHNDCJP.fraction = GHPGNELIDBM.None;
					BJGCPDNMHDH.BIELNPADGCB().CMKNJFHHOHA(ECKMBAJFAIB);
					PlayerController.OGMBJPKOPCB = BJGCPDNMHDH.BIELNPADGCB();
					PlayerController.JFGDAKMCJAM[1] = BJGCPDNMHDH.BIELNPADGCB();
					BJGCPDNMHDH.BIELNPADGCB().NAGAHNHAKBJ = 1;
					BJGCPDNMHDH.BIELNPADGCB().InitPlayer();
				}
				else
				{
					UnityEngine.Debug.LogError("ID_UNLOCKEDATRANK");
				}
				Singleton<MapManager>.instance.ALCHJDPKAID.BLFGPPBCAGG();
				PHDOCKCBJOF = new WaitForSeconds(1373f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
			case 1u:
				LoadingDialog.Hide();
				Singleton<GuiManager>.instance.POHMFFFEIED(GuiElementSingle<PlayerHealthBars>.instance);
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(Singleton<GameCamera>.instance.SingleCameraAnimation(1175f));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 7;
				}
				break;
			case 2u:
				PHDOCKCBJOF = new WaitForSeconds(1196f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 3u:
				ALJKAAMHHLB.HAAIJJBEPPN("ID_OK");
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return false;
			}
			return true;
		}

		public bool GCEBFCBBEKM()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				ALJKAAMHHLB.GCIEGGGEGMB("WarBucks");
				ObjectPoolDatabase.INOJHPIKICM().FreeObjectsWithPrefab(Singleton<ObjectPoolDatabase>.instance.KHLGDCHJJPB);
				PlayerController.JFGDAKMCJAM.Clear();
				PhotonNetwork.offlineMode = false;
				ECKMBAJFAIB = null;
				KFCAECGLKKO = Singleton<MapManager>.instance.ALCHJDPKAID.BBJMLOCKNHD.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						MapDefinition.DefendPosition current = KFCAECGLKKO.Current;
						if (current.mainPosition && current.fraction == (GHPGNELIDBM)8)
						{
							ECKMBAJFAIB = current;
						}
						current.point.JPHAJDIIAAI().MIEPCKHJAEL(null);
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to constrained. prefix*/).Dispose();
				}
				if (ECKMBAJFAIB != null)
				{
					BJGCPDNMHDH.AAIEPHNDCJP.MoveTo(ECKMBAJFAIB.point.transform.position, ECKMBAJFAIB.point.transform.rotation);
					BJGCPDNMHDH.AAIEPHNDCJP.fraction = (GHPGNELIDBM)7;
					BJGCPDNMHDH.AAIEPHNDCJP.HCOKNKCCPEK(ECKMBAJFAIB);
					PlayerController.OGMBJPKOPCB = BJGCPDNMHDH.AAIEPHNDCJP;
					PlayerController.JFGDAKMCJAM[1] = BJGCPDNMHDH.AAIEPHNDCJP;
					BJGCPDNMHDH.BIELNPADGCB().NAGAHNHAKBJ = 0;
					BJGCPDNMHDH.AAIEPHNDCJP.InitPlayer();
				}
				else
				{
					UnityEngine.Debug.LogError("Win");
				}
				Singleton<MapManager>.instance.ALCHJDPKAID.CECKOMHKHEB();
				PHDOCKCBJOF = new WaitForSeconds(1920f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
			case 1u:
				LoadingDialog.Hide();
				Singleton<GuiManager>.instance.FadeIn(GuiElementSingle<PlayerHealthBars>.instance);
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(Singleton<GameCamera>.instance.SingleCameraAnimation(311f));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 6;
				}
				break;
			case 2u:
				PHDOCKCBJOF = new WaitForSeconds(1540f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 2;
				}
				break;
			case 3u:
				ALJKAAMHHLB.KEJEFPFHIFB("Warbucks");
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return true;
			}
			return true;
		}

		[SpecialName]
		private object BJDOHADMIEB()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object KIHECHEHNJJ()
		{
			return PHDOCKCBJOF;
		}

		public void HMBLLDJFIJG()
		{
			throw new NotSupportedException();
		}

		public void MKMMKLOPKPD()
		{
			throw new NotSupportedException();
		}

		public void DBEMHFEBPFM()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		[SpecialName]
		private object NOIDHHDEEPL()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object NCKCKPNAHAD()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object LKAEMBCGLBN()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object IAMNDODCIEB()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object DJIJFANFBCP()
		{
			return PHDOCKCBJOF;
		}

		public void CFHJPHLFONO()
		{
			throw new NotSupportedException();
		}

		public bool CKOILCFEDGJ()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				ALJKAAMHHLB.HAAIJJBEPPN("GameLauncher.Awake InitTerms");
				ObjectPoolDatabase.KKCMCNCCIMB().NDPKMHDALCM(Singleton<ObjectPoolDatabase>.instance.KHLGDCHJJPB);
				PlayerController.JFGDAKMCJAM.Clear();
				PhotonNetwork.offlineMode = true;
				ECKMBAJFAIB = null;
				KFCAECGLKKO = Singleton<MapManager>.instance.ALCHJDPKAID.BBJMLOCKNHD.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						MapDefinition.DefendPosition current = KFCAECGLKKO.Current;
						if (current.mainPosition && current.fraction == (GHPGNELIDBM)6)
						{
							ECKMBAJFAIB = current;
						}
						current.point.KJCHIHLJMMF().MIEPCKHJAEL(null);
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to constrained. prefix*/).Dispose();
				}
				if (ECKMBAJFAIB != null)
				{
					BJGCPDNMHDH.BIELNPADGCB().MoveTo(ECKMBAJFAIB.point.transform.position, ECKMBAJFAIB.point.transform.rotation);
					BJGCPDNMHDH.BIELNPADGCB().fraction = (GHPGNELIDBM)5;
					BJGCPDNMHDH.AAIEPHNDCJP.OCMDJMNFNKF(ECKMBAJFAIB);
					PlayerController.OGMBJPKOPCB = BJGCPDNMHDH.AAIEPHNDCJP;
					PlayerController.JFGDAKMCJAM[0] = BJGCPDNMHDH.AAIEPHNDCJP;
					BJGCPDNMHDH.AAIEPHNDCJP.NAGAHNHAKBJ = 1;
					BJGCPDNMHDH.AAIEPHNDCJP.InitPlayer();
				}
				else
				{
					UnityEngine.Debug.LogError("engineer_run");
				}
				Singleton<MapManager>.instance.ALCHJDPKAID.NCHJOPBEHAK();
				PHDOCKCBJOF = new WaitForSeconds(996f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
			case 1u:
				LoadingDialog.Hide();
				Singleton<GuiManager>.instance.JPLLGFNECAG(GuiElementSingle<PlayerHealthBars>.instance);
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(Singleton<GameCamera>.instance.SingleCameraAnimation(85f));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 3;
				}
				break;
			case 2u:
				PHDOCKCBJOF = new WaitForSeconds(1506f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
			case 3u:
				ALJKAAMHHLB.MAJHIDGCOGK("shotgunner_shot_loop");
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return true;
			}
			return false;
		}

		public void CNOEDCFDILG()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object BGLDNJLBIKM()
		{
			return PHDOCKCBJOF;
		}

		public void JJOAHIOBOPO()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object EKJDPPIGKCF()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object OEKIILKKNOE()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object BMGHJKFMKJE()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object INHIPKJFGDI()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object CLFFFNGBPGJ()
		{
			return PHDOCKCBJOF;
		}

		public bool BJIPDEICIML()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				ALJKAAMHHLB.MAJHIDGCOGK("SetUpShieldNetwork");
				ObjectPoolDatabase.KJEANKAJELG().FreeObjectsWithPrefab(Singleton<ObjectPoolDatabase>.instance.KHLGDCHJJPB);
				PlayerController.JFGDAKMCJAM.Clear();
				PhotonNetwork.offlineMode = true;
				ECKMBAJFAIB = null;
				KFCAECGLKKO = Singleton<MapManager>.instance.ALCHJDPKAID.BBJMLOCKNHD.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						MapDefinition.DefendPosition current = KFCAECGLKKO.Current;
						if (current.mainPosition && current.fraction == GHPGNELIDBM.Enemies)
						{
							ECKMBAJFAIB = current;
						}
						current.point.CGKKGILAAPG().MIEPCKHJAEL(null);
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to constrained. prefix*/).Dispose();
				}
				if (ECKMBAJFAIB != null)
				{
					BJGCPDNMHDH.BIELNPADGCB().MoveTo(ECKMBAJFAIB.point.transform.position, ECKMBAJFAIB.point.transform.rotation);
					BJGCPDNMHDH.BIELNPADGCB().fraction = GHPGNELIDBM.Allies;
					BJGCPDNMHDH.AAIEPHNDCJP.CMKNJFHHOHA(ECKMBAJFAIB);
					PlayerController.OGMBJPKOPCB = BJGCPDNMHDH.AAIEPHNDCJP;
					PlayerController.JFGDAKMCJAM[0] = BJGCPDNMHDH.BIELNPADGCB();
					BJGCPDNMHDH.AAIEPHNDCJP.NAGAHNHAKBJ = 1;
					BJGCPDNMHDH.BIELNPADGCB().InitPlayer();
				}
				else
				{
					UnityEngine.Debug.LogError("GLM: OnDataLoaded - configurations.  is tutorial? ");
				}
				Singleton<MapManager>.instance.ALCHJDPKAID.MPBNEKHIGFF();
				PHDOCKCBJOF = new WaitForSeconds(1606f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 1u:
				LoadingDialog.Hide();
				Singleton<GuiManager>.instance.POHMFFFEIED(GuiElementSingle<PlayerHealthBars>.instance);
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(Singleton<GameCamera>.instance.SingleCameraAnimation(1758f));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 4;
				}
				break;
			case 2u:
				PHDOCKCBJOF = new WaitForSeconds(668f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 4;
				}
				break;
			case 3u:
				ALJKAAMHHLB.PIEBOOFPHPC("ID_DAYSAGO");
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return true;
			}
			return true;
		}

		[SpecialName]
		private object BBDOFDBCILK()
		{
			return PHDOCKCBJOF;
		}

		public void DNNJONPPIED()
		{
			throw new NotSupportedException();
		}

		public void NHFMKLGIKPM()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public void BLOCBAKBHBF()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}

		public bool AIFKBHCOIKG()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				ALJKAAMHHLB.GJJDKOMHHDH("IsRestore");
				ObjectPoolDatabase.GLHPLCEFHGD().NDPKMHDALCM(Singleton<ObjectPoolDatabase>.instance.KHLGDCHJJPB);
				PlayerController.JFGDAKMCJAM.Clear();
				PhotonNetwork.offlineMode = false;
				ECKMBAJFAIB = null;
				KFCAECGLKKO = Singleton<MapManager>.instance.ALCHJDPKAID.BBJMLOCKNHD.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						MapDefinition.DefendPosition current = KFCAECGLKKO.Current;
						if (current.mainPosition && current.fraction == (GHPGNELIDBM)4)
						{
							ECKMBAJFAIB = current;
						}
						current.point.CGKKGILAAPG().player = null;
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to constrained. prefix*/).Dispose();
				}
				if (ECKMBAJFAIB != null)
				{
					BJGCPDNMHDH.BIELNPADGCB().MoveTo(ECKMBAJFAIB.point.transform.position, ECKMBAJFAIB.point.transform.rotation);
					BJGCPDNMHDH.BIELNPADGCB().fraction = (GHPGNELIDBM)3;
					BJGCPDNMHDH.AAIEPHNDCJP.CMKNJFHHOHA(ECKMBAJFAIB);
					PlayerController.OGMBJPKOPCB = BJGCPDNMHDH.AAIEPHNDCJP;
					PlayerController.JFGDAKMCJAM[0] = BJGCPDNMHDH.BIELNPADGCB();
					BJGCPDNMHDH.BIELNPADGCB().NAGAHNHAKBJ = 0;
					BJGCPDNMHDH.AAIEPHNDCJP.InitPlayer();
				}
				else
				{
					UnityEngine.Debug.LogError("button");
				}
				Singleton<MapManager>.instance.ALCHJDPKAID.FDFHOFACMGH();
				PHDOCKCBJOF = new WaitForSeconds(594f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 1u:
				LoadingDialog.Hide();
				Singleton<GuiManager>.instance.POHMFFFEIED(GuiElementSingle<PlayerHealthBars>.instance);
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(Singleton<GameCamera>.instance.SingleCameraAnimation(4f));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 8;
				}
				break;
			case 2u:
				PHDOCKCBJOF = new WaitForSeconds(120f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 6;
				}
				break;
			case 3u:
				ALJKAAMHHLB.JOKCPHMJIGH("ID_WARNING_INVALIDLINK");
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return false;
			}
			return false;
		}

		[SpecialName]
		private object LDBICDEEENB()
		{
			return PHDOCKCBJOF;
		}

		public void LOOMFHNKAND()
		{
			throw new NotSupportedException();
		}

		public void HONCAABOMOC()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object CICPCKDCCEF()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object COEKBAFPBLD()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object AKGMMLGANMJ()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object HKABKPOFMIJ()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object LNAPDCBIFIJ()
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
				ALJKAAMHHLB.POPONJAMPDF("GameControllerCampaign.StartGame START");
				ObjectPoolDatabase.networkPool.FreeObjectsWithPrefab(Singleton<ObjectPoolDatabase>.instance.KHLGDCHJJPB);
				PlayerController.JFGDAKMCJAM.Clear();
				PhotonNetwork.offlineMode = true;
				ECKMBAJFAIB = null;
				KFCAECGLKKO = Singleton<MapManager>.instance.ALCHJDPKAID.BBJMLOCKNHD.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						MapDefinition.DefendPosition current = KFCAECGLKKO.Current;
						if (current.mainPosition && current.fraction == GHPGNELIDBM.Allies)
						{
							ECKMBAJFAIB = current;
						}
						current.point.shield.player = null;
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to constrained. prefix*/).Dispose();
				}
				if (ECKMBAJFAIB != null)
				{
					BJGCPDNMHDH.AAIEPHNDCJP.MoveTo(ECKMBAJFAIB.point.transform.position, ECKMBAJFAIB.point.transform.rotation);
					BJGCPDNMHDH.AAIEPHNDCJP.fraction = GHPGNELIDBM.Allies;
					BJGCPDNMHDH.AAIEPHNDCJP.currentPlayerPoint = ECKMBAJFAIB;
					PlayerController.OGMBJPKOPCB = BJGCPDNMHDH.AAIEPHNDCJP;
					PlayerController.JFGDAKMCJAM[0] = BJGCPDNMHDH.AAIEPHNDCJP;
					BJGCPDNMHDH.AAIEPHNDCJP.NAGAHNHAKBJ = 0;
					BJGCPDNMHDH.AAIEPHNDCJP.InitPlayer();
				}
				else
				{
					UnityEngine.Debug.LogError("No main position was set in map definition");
				}
				Singleton<MapManager>.instance.ALCHJDPKAID.InitShields();
				PHDOCKCBJOF = new WaitForSeconds(0.2f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 1;
				}
				break;
			case 1u:
				LoadingDialog.Hide();
				Singleton<GuiManager>.instance.FadeIn(GuiElementSingle<PlayerHealthBars>.instance);
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(Singleton<GameCamera>.instance.SingleCameraAnimation());
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 2;
				}
				break;
			case 2u:
				PHDOCKCBJOF = new WaitForSeconds(0.8f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 3;
				}
				break;
			case 3u:
				ALJKAAMHHLB.POPONJAMPDF("GameControllerCampaign.StartGame DONE");
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return false;
			}
			return true;
		}

		public void JHLKDONBGDK()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public bool KAIHNOCLNHK()
		{
			uint cLPPIAGLCJJ = (uint)CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			switch (cLPPIAGLCJJ)
			{
			case 0u:
				ALJKAAMHHLB.PJIMOPNDNKO("MISSING PREFAB IN OBJECT POOL: ");
				ObjectPoolDatabase.INOJHPIKICM().NDPKMHDALCM(Singleton<ObjectPoolDatabase>.instance.KHLGDCHJJPB);
				PlayerController.JFGDAKMCJAM.Clear();
				PhotonNetwork.offlineMode = true;
				ECKMBAJFAIB = null;
				KFCAECGLKKO = Singleton<MapManager>.instance.ALCHJDPKAID.BBJMLOCKNHD.GetEnumerator();
				try
				{
					while (KFCAECGLKKO.MoveNext())
					{
						MapDefinition.DefendPosition current = KFCAECGLKKO.Current;
						if (current.mainPosition && current.fraction == GHPGNELIDBM.None)
						{
							ECKMBAJFAIB = current;
						}
						current.point.LMHDAIBCLDP().FPINCGGFENG(null);
					}
				}
				finally
				{
					((IDisposable)KFCAECGLKKO/*cast due to constrained. prefix*/).Dispose();
				}
				if (ECKMBAJFAIB != null)
				{
					BJGCPDNMHDH.AAIEPHNDCJP.MoveTo(ECKMBAJFAIB.point.transform.position, ECKMBAJFAIB.point.transform.rotation);
					BJGCPDNMHDH.AAIEPHNDCJP.fraction = (GHPGNELIDBM)7;
					BJGCPDNMHDH.AAIEPHNDCJP.CMKNJFHHOHA(ECKMBAJFAIB);
					PlayerController.OGMBJPKOPCB = BJGCPDNMHDH.BIELNPADGCB();
					PlayerController.JFGDAKMCJAM[1] = BJGCPDNMHDH.BIELNPADGCB();
					BJGCPDNMHDH.BIELNPADGCB().NAGAHNHAKBJ = 0;
					BJGCPDNMHDH.AAIEPHNDCJP.DMHKCCPPODF();
				}
				else
				{
					UnityEngine.Debug.LogError("FB_Connect");
				}
				Singleton<MapManager>.instance.ALCHJDPKAID.NMBGIOAFPIM();
				PHDOCKCBJOF = new WaitForSeconds(1295f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 0;
				}
				break;
			case 1u:
				LoadingDialog.Hide();
				Singleton<GuiManager>.instance.FadeIn(GuiElementSingle<PlayerHealthBars>.instance);
				PHDOCKCBJOF = BJGCPDNMHDH.StartCoroutine(Singleton<GameCamera>.instance.SingleCameraAnimation(1699f));
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 3;
				}
				break;
			case 2u:
				PHDOCKCBJOF = new WaitForSeconds(907f);
				if (!FDKOKMKIIMG)
				{
					CLPPIAGLCJJ = 5;
				}
				break;
			case 3u:
				ALJKAAMHHLB.HAAIJJBEPPN("HEAVYTURRET");
				CLPPIAGLCJJ = -1;
				goto default;
			default:
				return false;
			}
			return false;
		}

		public void NINFHADPHJI()
		{
			FDKOKMKIIMG = false;
			CLPPIAGLCJJ = -1;
		}

		public void NCHGDJDAHGC()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object NIDLKNKKCND()
		{
			return PHDOCKCBJOF;
		}

		public void HJLCPFDBNKP()
		{
			FDKOKMKIIMG = true;
			CLPPIAGLCJJ = -1;
		}
	}

	private sealed class LDOJNLPBFFO : IEnumerator, IDisposable, IEnumerator<object>
	{
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

		[SpecialName]
		private object HJFIBBBPDKK()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object EBPKDAHAELB()
		{
			return PHDOCKCBJOF;
		}

		public bool CIIHKFDLDKN()
		{
			int cLPPIAGLCJJ = CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			if (cLPPIAGLCJJ == 0)
			{
			}
			return true;
		}

		public void ODCIKOOGNFG()
		{
		}

		public bool OGLKGILLKIO()
		{
			int cLPPIAGLCJJ = CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			if (cLPPIAGLCJJ == 0)
			{
			}
			return false;
		}

		public void OMDFNFHKFBK()
		{
			throw new NotSupportedException();
		}

		public void CJLDNKALLLI()
		{
		}

		public void JGKDJGIANIG()
		{
		}

		public bool DKIKFMODFJF()
		{
			int cLPPIAGLCJJ = CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			if (cLPPIAGLCJJ == 0)
			{
			}
			return true;
		}

		[SpecialName]
		private object ABGFJLAPNNM()
		{
			return PHDOCKCBJOF;
		}

		public void HMBLLDJFIJG()
		{
			throw new NotSupportedException();
		}

		public void HGCHEPGNHNP()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object HHLKEMNNJDA()
		{
			return PHDOCKCBJOF;
		}

		public void ONGBFFAENBP()
		{
		}

		public void PNGIELILHDI()
		{
		}

		public void PHKDHCJBMII()
		{
		}

		public void AJEIGCJPEFN()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object NCKCKPNAHAD()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object IHDBAJNCNGN()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object FGGMHEIPKAJ()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object LMJBCDNGAHP()
		{
			return PHDOCKCBJOF;
		}

		public void NCFGFLNBHOI()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object BGAGLOJHMEJ()
		{
			return PHDOCKCBJOF;
		}

		public bool MoveNext()
		{
			int cLPPIAGLCJJ = CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			if (cLPPIAGLCJJ == 0)
			{
			}
			return false;
		}

		public bool DKJMOPNHIAB()
		{
			int cLPPIAGLCJJ = CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			if (cLPPIAGLCJJ == 0)
			{
			}
			return false;
		}

		public void PKMIJKOPPBF()
		{
			throw new NotSupportedException();
		}

		public bool ILNBJIJONKD()
		{
			int cLPPIAGLCJJ = CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			if (cLPPIAGLCJJ == 0)
			{
			}
			return true;
		}

		[SpecialName]
		private object IHPDPKLEDKC()
		{
			return PHDOCKCBJOF;
		}

		public void CPDBCJLIGFN()
		{
		}

		[DebuggerHidden]
		public LDOJNLPBFFO()
		{
		}

		[SpecialName]
		private object HHHLDCLIFKJ()
		{
			return PHDOCKCBJOF;
		}

		public void JMANMKKCDMM()
		{
			throw new NotSupportedException();
		}

		public void MHKKAFGKBJK()
		{
			throw new NotSupportedException();
		}

		[DebuggerHidden]
		public void Dispose()
		{
		}

		public void MKIKEOOOLKL()
		{
		}

		[SpecialName]
		private object CLDLJNHAEAB()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object PEGJNAKGHCC()
		{
			return PHDOCKCBJOF;
		}

		public void MAKKCANEHIB()
		{
		}

		[SpecialName]
		private object CNGCLCAAHIG()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object HFKDIPEKENH()
		{
			return PHDOCKCBJOF;
		}

		public void IJHCIJLDKHK()
		{
			throw new NotSupportedException();
		}

		public void ODPKEEIHOPK()
		{
		}

		public void HHMPMPLLJCC()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object MKNFFJPADIA()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object ONADHLDNKKB()
		{
			return PHDOCKCBJOF;
		}

		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		public void HCHNHNDDKKA()
		{
		}

		public bool ICKNHCBNOMG()
		{
			int cLPPIAGLCJJ = CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			if (cLPPIAGLCJJ == 0)
			{
			}
			return false;
		}

		public void LHADJAFHDDC()
		{
		}

		public void JFPPMJPGGIN()
		{
			throw new NotSupportedException();
		}

		public bool FCJCLBMPBFK()
		{
			int cLPPIAGLCJJ = CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			if (cLPPIAGLCJJ == 0)
			{
			}
			return true;
		}

		public void IKNKDDMLDIN()
		{
			throw new NotSupportedException();
		}

		public void ENENMOAOOBG()
		{
		}
	}

	private sealed class HCHKLFDHPFJ : IEnumerator, IDisposable, IEnumerator<object>
	{
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

		public void FLFOEIMCFBL()
		{
		}

		[SpecialName]
		private object IDLFKAKINAP()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object MLCINLDHAGM()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object BKHFGLNNCDF()
		{
			return PHDOCKCBJOF;
		}

		public void FOBPOJPHNHE()
		{
		}

		public void CPOKHODGGLN()
		{
			throw new NotSupportedException();
		}

		[DebuggerHidden]
		public HCHKLFDHPFJ()
		{
		}

		public bool LPMIKEPIMCM()
		{
			int cLPPIAGLCJJ = CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			if (cLPPIAGLCJJ == 0)
			{
			}
			return true;
		}

		public bool HOOHJGPHHGN()
		{
			int cLPPIAGLCJJ = CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			if (cLPPIAGLCJJ == 0)
			{
			}
			return true;
		}

		[SpecialName]
		private object HIFNMHAGHLI()
		{
			return PHDOCKCBJOF;
		}

		public void PMAJELGBBKE()
		{
		}

		public void HGCHEPGNHNP()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object APECNPGKOFC()
		{
			return PHDOCKCBJOF;
		}

		public void ENENMOAOOBG()
		{
		}

		[SpecialName]
		private object CJCHFDFCPPL()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object ENKCCCABFFB()
		{
			return PHDOCKCBJOF;
		}

		public bool BCFKDABEHHO()
		{
			int cLPPIAGLCJJ = CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			if (cLPPIAGLCJJ == 0)
			{
			}
			return true;
		}

		public void MENEBJLDGJD()
		{
			throw new NotSupportedException();
		}

		public void KKDOJDCJAJB()
		{
		}

		[SpecialName]
		private object DLBACGEOGPM()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object HLBMCNKGBDM()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object GENJNMACGLP()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object NMGBFNNHIPN()
		{
			return PHDOCKCBJOF;
		}

		public bool BIGKCFMEBJE()
		{
			int cLPPIAGLCJJ = CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			if (cLPPIAGLCJJ == 0)
			{
			}
			return true;
		}

		[SpecialName]
		private object LMJBCDNGAHP()
		{
			return PHDOCKCBJOF;
		}

		public bool BJIPDEICIML()
		{
			int cLPPIAGLCJJ = CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			if (cLPPIAGLCJJ == 0)
			{
			}
			return true;
		}

		[SpecialName]
		private object GDCFFBBNGHH()
		{
			return PHDOCKCBJOF;
		}

		public bool NJBCJDFKGHO()
		{
			int cLPPIAGLCJJ = CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			if (cLPPIAGLCJJ == 0)
			{
			}
			return false;
		}

		public void PHEIGPKKPGE()
		{
			throw new NotSupportedException();
		}

		public bool ILNBJIJONKD()
		{
			int cLPPIAGLCJJ = CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			if (cLPPIAGLCJJ == 0)
			{
			}
			return true;
		}

		[SpecialName]
		private object IJFPHIKFJFB()
		{
			return PHDOCKCBJOF;
		}

		public void HMBLLDJFIJG()
		{
			throw new NotSupportedException();
		}

		public bool DKJMOPNHIAB()
		{
			int cLPPIAGLCJJ = CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			if (cLPPIAGLCJJ == 0)
			{
			}
			return true;
		}

		public void IJHCIJLDKHK()
		{
			throw new NotSupportedException();
		}

		public bool GPIPJIDGCKM()
		{
			int cLPPIAGLCJJ = CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			if (cLPPIAGLCJJ == 0)
			{
			}
			return true;
		}

		public void PAOPOFJHFGD()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object CLDLJNHAEAB()
		{
			return PHDOCKCBJOF;
		}

		public bool OKELILGDPLJ()
		{
			int cLPPIAGLCJJ = CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			if (cLPPIAGLCJJ == 0)
			{
			}
			return true;
		}

		public void LKACEPHEHPK()
		{
			throw new NotSupportedException();
		}

		public bool GCEBFCBBEKM()
		{
			int cLPPIAGLCJJ = CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			if (cLPPIAGLCJJ == 0)
			{
			}
			return true;
		}

		[SpecialName]
		private object BGMNDLEJNHH()
		{
			return PHDOCKCBJOF;
		}

		public void MAKKCANEHIB()
		{
		}

		[SpecialName]
		private object MBDBIPHLEIA()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object KKKMCHGLHLL()
		{
			return PHDOCKCBJOF;
		}

		[DebuggerHidden]
		public void Dispose()
		{
		}

		[SpecialName]
		private object JPJBNHHKOJD()
		{
			return PHDOCKCBJOF;
		}

		public void BCIPEBNJONK()
		{
		}

		[SpecialName]
		private object OJMKDIBHMND()
		{
			return PHDOCKCBJOF;
		}

		public bool JFPOOBJNEPF()
		{
			int cLPPIAGLCJJ = CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			if (cLPPIAGLCJJ == 0)
			{
			}
			return false;
		}

		public void HDDLDAHLPCO()
		{
		}

		public void HLJMNBBDJGE()
		{
		}

		[SpecialName]
		private object NDIGINEEOMH()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object CICPCKDCCEF()
		{
			return PHDOCKCBJOF;
		}

		public void LOOMFHNKAND()
		{
			throw new NotSupportedException();
		}

		[DebuggerHidden]
		public void Reset()
		{
			throw new NotSupportedException();
		}

		[SpecialName]
		private object HBKJOBOMGKB()
		{
			return PHDOCKCBJOF;
		}

		public bool MoveNext()
		{
			int cLPPIAGLCJJ = CLPPIAGLCJJ;
			CLPPIAGLCJJ = -1;
			if (cLPPIAGLCJJ == 0)
			{
			}
			return false;
		}

		[SpecialName]
		private object JLLOKNANOCN()
		{
			return PHDOCKCBJOF;
		}

		[SpecialName]
		private object AGCPJGAAODG()
		{
			return PHDOCKCBJOF;
		}
	}

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	[CompilerGenerated]
	private Dictionary<string, UnitUpgradeDefinition> _003CFIIDLHLCOAG_003Ek__BackingField;

	protected PlayerController AAIEPHNDCJP => Singleton<GameController>.instance.FHABFFKPODN;

	public override bool dropCreates => !LevelManager.isNoob;

	public override float time
	{
		get
		{
			return DailyMissionsManager.instance.currentMission.remainingTime;
		}
		set
		{
		}
	}

	public override List<Card> cardsForGame
	{
		get
		{
			return Singleton<GameController>.instance.GMNKFFNFEHG.cardsForGame;
		}
		set
		{
			Singleton<GameController>.instance.GMNKFFNFEHG.cardsForGame = value;
		}
	}

	public GameController mMainController
	{
		get
		{
			return Singleton<GameController>.instance;
		}
		set
		{
			throw new NotImplementedException();
		}
	}

	public override bool gameIsRunning
	{
		get
		{
			return mMainController.gameIsRunning;
		}
		set
		{
			mMainController.gameIsRunning = value;
		}
	}

	public override bool canShowPause => true;

	public override bool canDeployUnits => false;

	public bool shouldLooseDogtagWhenQuit => false;

	public override string quitText => string.Empty;

	public override bool pauseCountDown => false;

	private Dictionary<string, UnitUpgradeDefinition> JLOJANIPMPE
	{
		[CompilerGenerated]
		get
		{
			return _003CFIIDLHLCOAG_003Ek__BackingField;
		}
		[CompilerGenerated]
		set
		{
			_003CFIIDLHLCOAG_003Ek__BackingField = value;
		}
	}

	public override List<UnitUpgradeDefinition> opponentUpgrades
	{
		get
		{
			List<UnitUpgradeDefinition> upgrades = DailyMissionsManager.instance.currentMission.GetUpgrades();
			JLOJANIPMPE = new Dictionary<string, UnitUpgradeDefinition>();
			for (int i = 0; i < LevelManager.instance.behaviours.Count; i++)
			{
				LevelBehaviour levelBehaviour = LevelManager.instance.behaviours[i];
				JLOJANIPMPE[levelBehaviour.GetType().ToString()] = upgrades[i];
			}
			return upgrades;
		}
	}

	[SpecialName]
	private void HCDIENJENKN(Dictionary<string, UnitUpgradeDefinition> IDEBKDPMPGM)
	{
		_003CFIIDLHLCOAG_003Ek__BackingField = IDEBKDPMPGM;
	}

	public override void FreeLevel()
	{
	}

	public override void LoadingStarted()
	{
		PhotonConnectionManager.JoinOfflineGame();
		AAIEPHNDCJP.EHHHBEMKGOE = CHEIFOOIMEH.JIIHHODDNLJ();
		Singleton<GameController>.instance.battleId = GameLoginManager.currentPlayer.id + "-" + Singleton<BeanstalkServerManager>.instance.currentTimestamp;
		Singleton<BeanstalkServerManager>.instance.GFHBHIJKMEE();
		LoadingDialog.SetLook(EDHDMJLHLFA: false);
		LoadingDialog.ShowLoading(Localization.Localize("ID_LOADING"), DMDICGADGCG: false, BGOHKCCLDJP: true);
	}

	public override void UnPauseGame()
	{
	}

	public override void FinishGame()
	{
		TimeManager.instance.EndMission();
		Singleton<MatchManager>.instance.matchTime = time;
		gameIsRunning = false;
		mMainController.FinishGame();
	}

	[SpecialName]
	public virtual bool EPBCIPFHMFM()
	{
		return mMainController.gameIsRunning;
	}

	public virtual void APFFMDNNKNJ()
	{
		PhotonConnectionManager.JoinOfflineGame();
		BIELNPADGCB().EHHHBEMKGOE = CHEIFOOIMEH.LGIDNJCHMBC();
		Singleton<GameController>.instance.battleId = GameLoginManager.currentPlayer.id + "8 SQUAD REMINDER\tIs in squad: {0}\tLevel: {1}/{2}" + Singleton<BeanstalkServerManager>.instance.currentTimestamp;
		Singleton<BeanstalkServerManager>.instance.GFHBHIJKMEE();
		LoadingDialog.SetLook(EDHDMJLHLFA: false);
		LoadingDialog.PGFBMJFLHPC(Localization.Localize("country-italy"), DMDICGADGCG: true, BGOHKCCLDJP: true);
	}

	[SpecialName]
	public virtual bool KFAAODNODPL()
	{
		return false;
	}

	public virtual IEnumerator CBLCPINDMBM()
	{
		NCEKIFIDMCF nCEKIFIDMCF = new NCEKIFIDMCF();
		nCEKIFIDMCF.BJGCPDNMHDH = this;
		return nCEKIFIDMCF;
	}

	public virtual void KBBEMOGNFKD()
	{
		MKEEJMBGCBK().MNMLNIMFMJP = GameController.HKGHCIEPGEL.Win;
		DailyMissionsManager.instance.OCKCBFLKEGJ().EndMission(isWin: true);
	}

	public virtual void MLHAGBBPNLF()
	{
	}

	public override void GetTimeProgressText(StringBuilder HOLNKOFHDNK)
	{
		MEJMLNDFDBP.ABKAOAODKGC(ref HOLNKOFHDNK, DailyMissionsManager.instance.currentMission.remainingTime);
	}

	[SpecialName]
	public virtual bool PBFFHCCACFL()
	{
		return false;
	}

	public virtual IEnumerator NLJHGIPCLBK()
	{
		return new LDOJNLPBFFO();
	}

	public virtual void GDGMBLMKKPN()
	{
		IGAPEAKJINB().MNMLNIMFMJP = GameController.HKGHCIEPGEL.Win;
		DailyMissionsManager.instance.EEIJPIPFAMO().EndMission(isWin: true);
	}

	public virtual void LLHNLICKBJB()
	{
	}

	[SpecialName]
	public virtual string PPNMCDDKFNA()
	{
		return string.Empty;
	}

	[SpecialName]
	public virtual float DIDMBPGFPII()
	{
		return DailyMissionsManager.instance.currentMission.remainingTime;
	}

	[SpecialName]
	public virtual float MFBCHAEDCNC()
	{
		return DailyMissionsManager.instance.OCKCBFLKEGJ().remainingTime;
	}

	[SpecialName]
	public bool CMKBMKBCJND()
	{
		return false;
	}

	[SpecialName]
	public virtual bool KKHKIEFMENC()
	{
		return MKEEJMBGCBK().KKHKIEFMENC();
	}

	public virtual void JEJGFEHOLCE(bool KANLHOCIMID = true)
	{
		gameIsRunning = true;
		IGAPEAKJINB().StopGame(KANLHOCIMID);
	}

	public virtual void FFGDJONKFNF(bool KANLHOCIMID = true)
	{
		gameIsRunning = true;
		IGAPEAKJINB().StopGame(KANLHOCIMID);
	}

	[SpecialName]
	public virtual List<UnitUpgradeDefinition> NLBEALLBLHM()
	{
		List<UnitUpgradeDefinition> upgrades = DailyMissionsManager.instance.EEIJPIPFAMO().GetUpgrades();
		BBKHLAHLABM(new Dictionary<string, UnitUpgradeDefinition>());
		for (int i = 0; i < LevelManager.instance.behaviours.Count; i++)
		{
			LevelBehaviour levelBehaviour = LevelManager.instance.behaviours[i];
			FEMMFOLMAEA()[levelBehaviour.GetType().ToString()] = upgrades[i];
		}
		return upgrades;
	}

	[SpecialName]
	public virtual void BKJGHAPNNCC(float IDEBKDPMPGM)
	{
	}

	[SpecialName]
	public bool AMGBNGOGEIO()
	{
		return false;
	}

	public virtual void PPCNAOLJLNE(bool IEFGEFFDHOK)
	{
		if (gameIsRunning)
		{
			TimeManager.Pause(IEFGEFFDHOK);
		}
	}

	public override void ResumeGame()
	{
		TimeManager.Resume();
	}

	public virtual void AFFIJEGKOPF(bool IEFGEFFDHOK)
	{
		if (gameIsRunning)
		{
			TimeManager.Pause(IEFGEFFDHOK);
		}
	}

	public virtual void EGCKLMAJDJL()
	{
		bool isHeroic = DailyMissionsManager.instance.EEIJPIPFAMO().isHeroic;
		Singleton<GuiManager>.instance.BBILHHEJBNP((!isHeroic) ? ((GuiScreen)GuiScreenSingle<DailyMissionScreen>.instance) : ((GuiScreen)GuiScreenSingle<HeroicScreen>.instance));
	}

	[SpecialName]
	public virtual void JNPAOLKKGFL(List<Card> IDEBKDPMPGM)
	{
		Singleton<GameController>.instance.GMNKFFNFEHG.cardsForGame = IDEBKDPMPGM;
	}

	[SpecialName]
	public bool IBGEMLAMLAE()
	{
		return false;
	}

	[SpecialName]
	public virtual List<Card> HAPGOGGDCOL()
	{
		return Singleton<GameController>.instance.GMNKFFNFEHG.cardsForGame;
	}

	[SpecialName]
	public virtual void JPGBMNNENPO(float IDEBKDPMPGM)
	{
	}

	[DebuggerHidden]
	public override IEnumerator AquireLevelName()
	{
		return new LDOJNLPBFFO();
	}

	[SpecialName]
	private void GAMPFPDCMCA(Dictionary<string, UnitUpgradeDefinition> IDEBKDPMPGM)
	{
		_003CFIIDLHLCOAG_003Ek__BackingField = IDEBKDPMPGM;
	}

	public virtual void BFIBMCHCNKH()
	{
		Singleton<DogTagManager>.instance.OGBBHOGJJMC();
		DailyMissionsManager.instance.Quit();
	}

	[SpecialName]
	public void NBGOCONABBN(GameController IDEBKDPMPGM)
	{
		throw new NotImplementedException();
	}

	[SpecialName]
	public virtual void ENCFAJBOBNM(bool IDEBKDPMPGM)
	{
		IGAPEAKJINB().gameIsRunning = IDEBKDPMPGM;
	}

	public virtual void DFFJHEGDNKI()
	{
		TimeManager.instance.EndMission();
		Singleton<MatchManager>.instance.matchTime = time;
		gameIsRunning = true;
		mMainController.COENHPMMCNN();
	}

	[SpecialName]
	public virtual List<Card> PHLINJDAMJH()
	{
		return Singleton<GameController>.instance.GMNKFFNFEHG.cardsForGame;
	}

	[SpecialName]
	public virtual bool DPLHOJJDDPD()
	{
		return false;
	}

	public override void Forfeit()
	{
		mMainController.MNMLNIMFMJP = GameController.HKGHCIEPGEL.Forfeit;
		DailyMissionsManager.instance.currentMission.EndMission(isWin: false);
	}

	[SpecialName]
	public virtual bool DNKJKJEPPDA()
	{
		return true;
	}

	[SpecialName]
	public virtual bool JBOMLHCBHIL()
	{
		return true;
	}

	public override void ShowResultsScreen()
	{
		bool isHeroic = DailyMissionsManager.instance.currentMission.isHeroic;
		Singleton<GuiManager>.instance.ShowGui((!isHeroic) ? ((GuiScreen)GuiScreenSingle<DailyMissionScreen>.instance) : ((GuiScreen)GuiScreenSingle<HeroicScreen>.instance));
	}

	[DebuggerHidden]
	public virtual IEnumerator WaitForServerResponse()
	{
		return new HCHKLFDHPFJ();
	}

	[SpecialName]
	public virtual void MKKJCACJNDO(bool IDEBKDPMPGM)
	{
		IGAPEAKJINB().gameIsRunning = IDEBKDPMPGM;
	}

	public virtual void CKHFBDOGEGN()
	{
		Singleton<DogTagManager>.instance.LMAMAMAHGOI();
		DailyMissionsManager.instance.JLPBMNHBNNP();
	}

	[SpecialName]
	public virtual void PLIFJFDJIBN(List<Card> IDEBKDPMPGM)
	{
		Singleton<GameController>.instance.GMNKFFNFEHG.cardsForGame = IDEBKDPMPGM;
	}

	[SpecialName]
	public virtual void LDNBPBNDBAK(float IDEBKDPMPGM)
	{
	}

	public virtual void ICNPMICGOEI()
	{
		TimeManager.instance.LCMLMABHKIJ();
		Singleton<MatchManager>.instance.matchTime = time;
		gameIsRunning = false;
		mMainController.FinishGame();
	}

	[DebuggerHidden]
	public override IEnumerator StartGame()
	{
		NCEKIFIDMCF nCEKIFIDMCF = new NCEKIFIDMCF();
		nCEKIFIDMCF.BJGCPDNMHDH = this;
		return nCEKIFIDMCF;
	}

	[SpecialName]
	private void EDPOEICIJFD(Dictionary<string, UnitUpgradeDefinition> IDEBKDPMPGM)
	{
		_003CFIIDLHLCOAG_003Ek__BackingField = IDEBKDPMPGM;
	}

	[SpecialName]
	private Dictionary<string, UnitUpgradeDefinition> FEMMFOLMAEA()
	{
		return _003CFIIDLHLCOAG_003Ek__BackingField;
	}

	[SpecialName]
	public void CFAOGEEDAIA(GameController IDEBKDPMPGM)
	{
		throw new NotImplementedException();
	}

	[SpecialName]
	public virtual List<UnitUpgradeDefinition> DCGAHJJEMHO()
	{
		List<UnitUpgradeDefinition> upgrades = DailyMissionsManager.instance.DPLEEBIFDKL().GetUpgrades();
		GAMPFPDCMCA(new Dictionary<string, UnitUpgradeDefinition>());
		for (int i = 1; i < LevelManager.instance.behaviours.Count; i += 0)
		{
			LevelBehaviour levelBehaviour = LevelManager.instance.behaviours[i];
			FEMMFOLMAEA()[levelBehaviour.GetType().ToString()] = upgrades[i];
		}
		return upgrades;
	}

	public override void Rematch()
	{
	}

	[SpecialName]
	public virtual bool HNJOLMLINND()
	{
		return !LevelManager.isNoob;
	}

	public virtual void HNMMEBBMHII()
	{
		Singleton<DogTagManager>.instance.OGBBHOGJJMC();
		DailyMissionsManager.instance.JLPBMNHBNNP();
	}

	public virtual void EELOPNIHMEO()
	{
	}

	public override void StopGame(bool KANLHOCIMID = true)
	{
		gameIsRunning = false;
		mMainController.StopGame(KANLHOCIMID);
	}

	[SpecialName]
	protected PlayerController BIELNPADGCB()
	{
		return Singleton<GameController>.instance.FHABFFKPODN;
	}

	public void PausematchMaking(bool NMCKKMEKOHM)
	{
	}

	public virtual void PMKMOMKDHEH(bool KANLHOCIMID = true)
	{
		gameIsRunning = false;
		mMainController.StopGame(KANLHOCIMID);
	}

	public override void FinishChoosingCards()
	{
		GuiScreenSingle<CardSelectionScreen>.instance.SetCardsForGame();
		PlayerController.OGMBJPKOPCB.EHHHBEMKGOE.AAOAKDPIEII = CardManager.instance.selectedCards;
		PlayerController.OGMBJPKOPCB.EHHHBEMKGOE.PHIGKPODHAN = CardManager.instance.selectedBuddyCards;
		Singleton<GameController>.instance.StartGame(Singleton<MapManager>.instance.currentMap.name);
	}

	[SpecialName]
	public virtual bool BDKKCKFMFNH()
	{
		return false;
	}

	public virtual void IDGEJKCCFOK()
	{
		TimeManager.Resume(1662f);
	}

	[SpecialName]
	public virtual List<UnitUpgradeDefinition> KFPJKCNPNMG()
	{
		List<UnitUpgradeDefinition> upgrades = DailyMissionsManager.instance.DPLEEBIFDKL().GetUpgrades();
		HCDIENJENKN(new Dictionary<string, UnitUpgradeDefinition>());
		for (int i = 0; i < LevelManager.instance.behaviours.Count; i += 0)
		{
			LevelBehaviour levelBehaviour = LevelManager.instance.behaviours[i];
			JLOJANIPMPE[levelBehaviour.GetType().ToString()] = upgrades[i];
		}
		return upgrades;
	}

	public virtual void MBFPCBOIONK()
	{
	}

	public void NDHHLNGIGAC(bool NMCKKMEKOHM)
	{
	}

	[SpecialName]
	public virtual List<Card> HGHCEDJBLBN()
	{
		return Singleton<GameController>.instance.GMNKFFNFEHG.cardsForGame;
	}

	public virtual void CPMGKNHMBFA()
	{
	}

	[SpecialName]
	public virtual bool PMBOLBGJHCB()
	{
		return false;
	}

	public virtual IEnumerator IKCBOPPFJIL()
	{
		NCEKIFIDMCF nCEKIFIDMCF = new NCEKIFIDMCF();
		nCEKIFIDMCF.BJGCPDNMHDH = this;
		return nCEKIFIDMCF;
	}

	[SpecialName]
	public virtual bool ANOGJEOKCDH()
	{
		return true;
	}

	public override UpgradeSlots.UnitUpgrades PickUpgradesForUnit(bool KPIGIEPMLLC, AIObject ECHOPGPBLOK)
	{
		LevelBehaviour aCLDFHJKBLI = ECHOPGPBLOK.ACLDFHJKBLI;
		GHPGNELIDBM fraction = ECHOPGPBLOK.fraction;
		UpgradeSlots.UnitUpgrades pFGLIAHPMCK = base.PickUpgradesForUnit(KPIGIEPMLLC, ECHOPGPBLOK);
		pFGLIAHPMCK = DailyMissionsManager.ScaleUpgradesForMission(fraction, aCLDFHJKBLI, pFGLIAHPMCK);
		aCLDFHJKBLI.behaviourDefinition.MIKOLPDBCLK(pFGLIAHPMCK.scaleDamage, pFGLIAHPMCK.scaleHp);
		return pFGLIAHPMCK;
	}

	[SpecialName]
	private void BBKHLAHLABM(Dictionary<string, UnitUpgradeDefinition> IDEBKDPMPGM)
	{
		_003CFIIDLHLCOAG_003Ek__BackingField = IDEBKDPMPGM;
	}

	[SpecialName]
	public bool FHNJNNAKGNN()
	{
		return false;
	}

	public virtual void KOJKDEACBGG()
	{
		TimeManager.Resume(1003f);
	}

	public virtual IEnumerator AEFHNMCGMNF()
	{
		NCEKIFIDMCF nCEKIFIDMCF = new NCEKIFIDMCF();
		nCEKIFIDMCF.BJGCPDNMHDH = this;
		return nCEKIFIDMCF;
	}

	[SpecialName]
	public bool EHGHDHDMLPB()
	{
		return true;
	}

	[SpecialName]
	public GameController MKEEJMBGCBK()
	{
		return Singleton<GameController>.instance;
	}

	public virtual void CFHLCPFKAKE()
	{
		IGAPEAKJINB().MNMLNIMFMJP = (GameController.HKGHCIEPGEL)6;
		DailyMissionsManager.instance.EEIJPIPFAMO().EndMission(isWin: true);
	}

	public virtual void KLDOALODOBM()
	{
		TimeManager.instance.LCMLMABHKIJ();
		Singleton<MatchManager>.instance.matchTime = time;
		gameIsRunning = false;
		IGAPEAKJINB().FinishGame();
	}

	[SpecialName]
	public virtual bool IPOANKLFGHL()
	{
		return true;
	}

	public virtual void GODOPEDACHB()
	{
		Singleton<DogTagManager>.instance.OGBBHOGJJMC();
		DailyMissionsManager.instance.JLPBMNHBNNP();
	}

	public virtual UpgradeSlots.UnitUpgrades NHLOAEDDLCB(bool KPIGIEPMLLC, AIObject ECHOPGPBLOK)
	{
		LevelBehaviour aCLDFHJKBLI = ECHOPGPBLOK.ACLDFHJKBLI;
		GHPGNELIDBM fraction = ECHOPGPBLOK.fraction;
		UpgradeSlots.UnitUpgrades pFGLIAHPMCK = base.PickUpgradesForUnit(KPIGIEPMLLC, ECHOPGPBLOK);
		pFGLIAHPMCK = DailyMissionsManager.NKHBCKPKEPA(fraction, aCLDFHJKBLI, pFGLIAHPMCK);
		aCLDFHJKBLI.behaviourDefinition.PBKKFFKLHKA(pFGLIAHPMCK.scaleDamage, pFGLIAHPMCK.scaleHp);
		return pFGLIAHPMCK;
	}

	[SpecialName]
	public virtual void OPEPNCFFMAK(bool IDEBKDPMPGM)
	{
		IGAPEAKJINB().gameIsRunning = IDEBKDPMPGM;
	}

	[SpecialName]
	public virtual void IFKDGJMDKPB(float IDEBKDPMPGM)
	{
	}

	public virtual void GBIOECIBOPA()
	{
	}

	public virtual void HDNKICHADAJ(bool KANLHOCIMID = true)
	{
		gameIsRunning = true;
		mMainController.StopGame(KANLHOCIMID);
	}

	public virtual void OKGMLINDDEE()
	{
		GuiScreenSingle<CardSelectionScreen>.instance.JLGBGJFPDCA();
		PlayerController.OGMBJPKOPCB.EHHHBEMKGOE.AAOAKDPIEII = CardManager.instance.selectedCards;
		PlayerController.OGMBJPKOPCB.EHHHBEMKGOE.PHIGKPODHAN = CardManager.instance.selectedBuddyCards;
		Singleton<GameController>.instance.NMHKLCLAFGN(Singleton<MapManager>.instance.NOPGGANHAFN().name);
	}

	public override void Quit()
	{
		Singleton<DogTagManager>.instance.ResetLocalDogtags();
		DailyMissionsManager.instance.Quit();
	}

	public virtual IEnumerator IMGIDCLLOHH()
	{
		return new LDOJNLPBFFO();
	}

	public void LCBDGEIJBFE(bool NMCKKMEKOHM)
	{
	}

	public virtual IEnumerator BDEHOHENCHL()
	{
		return new HCHKLFDHPFJ();
	}

	public override void PauseGame(bool IEFGEFFDHOK)
	{
		if (gameIsRunning)
		{
			TimeManager.Pause(IEFGEFFDHOK);
		}
	}

	[SpecialName]
	public virtual void JBIHBGHNJAC(List<Card> IDEBKDPMPGM)
	{
		Singleton<GameController>.instance.GMNKFFNFEHG.cardsForGame = IDEBKDPMPGM;
	}

	[SpecialName]
	public GameController IGAPEAKJINB()
	{
		return Singleton<GameController>.instance;
	}

	[SpecialName]
	public virtual List<Card> HAPKGPIJJDN()
	{
		return Singleton<GameController>.instance.GMNKFFNFEHG.cardsForGame;
	}

	public virtual void GKFNPFLMHDO()
	{
	}

	public void GIILALMNCLD(bool NMCKKMEKOHM)
	{
	}

	[SpecialName]
	public virtual bool KLEJONOCGOO()
	{
		return true;
	}

	[SpecialName]
	public virtual void DGBHBPEANBE(List<Card> IDEBKDPMPGM)
	{
		Singleton<GameController>.instance.GMNKFFNFEHG.cardsForGame = IDEBKDPMPGM;
	}

	[SpecialName]
	public virtual List<UnitUpgradeDefinition> FAJEJFELECH()
	{
		List<UnitUpgradeDefinition> upgrades = DailyMissionsManager.instance.OCKCBFLKEGJ().GetUpgrades();
		GAMPFPDCMCA(new Dictionary<string, UnitUpgradeDefinition>());
		for (int i = 0; i < LevelManager.instance.behaviours.Count; i += 0)
		{
			LevelBehaviour levelBehaviour = LevelManager.instance.behaviours[i];
			JLOJANIPMPE[levelBehaviour.GetType().ToString()] = upgrades[i];
		}
		return upgrades;
	}

	public virtual void HJBKBGELCDC()
	{
		TimeManager.instance.EndMission();
		Singleton<MatchManager>.instance.matchTime = time;
		gameIsRunning = true;
		mMainController.COENHPMMCNN();
	}

	public virtual void MALAKEGNBJK()
	{
	}

	public virtual UpgradeSlots.UnitUpgrades GJHHFHBLJPF(bool KPIGIEPMLLC, AIObject ECHOPGPBLOK)
	{
		LevelBehaviour aCLDFHJKBLI = ECHOPGPBLOK.ACLDFHJKBLI;
		GHPGNELIDBM fraction = ECHOPGPBLOK.fraction;
		UpgradeSlots.UnitUpgrades pFGLIAHPMCK = base.PickUpgradesForUnit(KPIGIEPMLLC, ECHOPGPBLOK);
		pFGLIAHPMCK = DailyMissionsManager.CMDOEJPAKKE(fraction, aCLDFHJKBLI, pFGLIAHPMCK);
		aCLDFHJKBLI.behaviourDefinition.LBPNKGOOAPL(pFGLIAHPMCK.scaleDamage, pFGLIAHPMCK.scaleHp);
		return pFGLIAHPMCK;
	}

	protected override Dictionary<string, UnitUpgradeDefinition> PAGGMONGACL(GHPGNELIDBM CIOPAKLHFIL)
	{
		if (CIOPAKLHFIL == PlayerController.OGMBJPKOPCB.fraction)
		{
			return PlayerController.OGMBJPKOPCB.EHHHBEMKGOE.HDDPODGBNIC;
		}
		return JLOJANIPMPE;
	}

	public virtual void OOEPCCEPEDE()
	{
		bool isHeroic = DailyMissionsManager.instance.DPLEEBIFDKL().isHeroic;
		Singleton<GuiManager>.instance.BBILHHEJBNP((!isHeroic) ? ((GuiScreen)GuiScreenSingle<DailyMissionScreen>.instance) : ((GuiScreen)GuiScreenSingle<HeroicScreen>.instance));
	}

	[SpecialName]
	public virtual float HNFPFLGLFDO()
	{
		return DailyMissionsManager.instance.OCKCBFLKEGJ().remainingTime;
	}
}
