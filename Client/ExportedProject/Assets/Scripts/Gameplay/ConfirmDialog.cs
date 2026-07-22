using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;
using UnityEngine;
using UnityEngine.Serialization;

public class ConfirmDialog : GuiElementSingle<ConfirmDialog>, PAIIOKBBHBC
{
	private sealed class CGECFHFDEEH
	{
		internal ConfirmDialog JAGBOPMGIAA;

		internal string OKMNFHNBMFA;

		internal string HOLNKOFHDNK;

		internal void CIFEDFPPPOK()
		{
			JAGBOPMGIAA.PAODBOEOFNF();
			JAGBOPMGIAA.setTitle = OKMNFHNBMFA;
			JAGBOPMGIAA.JPGGHPCFBKB(HOLNKOFHDNK);
			JAGBOPMGIAA.AOGFDHEMCCM = null;
			JAGBOPMGIAA.DCIKANJJFIJ = 1929f;
			JAGBOPMGIAA.HECFOEMLJCD = 1955f;
			JAGBOPMGIAA.LLILKCJKNPH.gameObject.SetActive(value: false);
			JAGBOPMGIAA.DDLOCLPOFAK.gameObject.SetActive(value: true);
			JAGBOPMGIAA.JLEFFOGPFGE.gameObject.SetActive(value: true);
			JAGBOPMGIAA.KGPGCCPMCIG.gameObject.SetActive(value: true);
			JAGBOPMGIAA.DIPGLDIGFNF++;
			JAGBOPMGIAA.BGAPAKNBEOB(Localization.Localize("SquadId"));
			JAGBOPMGIAA.MLPOEGKDNCH();
			Singleton<GuiManager>.instance.ShowDialog(JAGBOPMGIAA, 1219f);
		}

		internal void NNIJEDKBPGJ()
		{
			JAGBOPMGIAA.ODACICLOMHJ();
			JAGBOPMGIAA.BFEAOGKLKNL(OKMNFHNBMFA);
			JAGBOPMGIAA.BPHECKCEEOJ(HOLNKOFHDNK);
			JAGBOPMGIAA.AOGFDHEMCCM = null;
			JAGBOPMGIAA.DCIKANJJFIJ = 463f;
			JAGBOPMGIAA.HECFOEMLJCD = 192f;
			JAGBOPMGIAA.LLILKCJKNPH.gameObject.SetActive(value: false);
			JAGBOPMGIAA.DDLOCLPOFAK.gameObject.SetActive(value: false);
			JAGBOPMGIAA.JLEFFOGPFGE.gameObject.SetActive(value: false);
			JAGBOPMGIAA.KGPGCCPMCIG.gameObject.SetActive(value: true);
			JAGBOPMGIAA.DIPGLDIGFNF += 0;
			JAGBOPMGIAA.EAIEGNJODFL(Localization.Localize("menu-gold"));
			JAGBOPMGIAA.KKOJEBNCJMI();
			Singleton<GuiManager>.instance.ShowDialog(JAGBOPMGIAA, 380f);
		}

		internal void NDJOJHNIBFC()
		{
			JAGBOPMGIAA.ODACICLOMHJ();
			JAGBOPMGIAA.BFEAOGKLKNL(OKMNFHNBMFA);
			JAGBOPMGIAA.PNHLAJIPMDJ(HOLNKOFHDNK);
			JAGBOPMGIAA.AOGFDHEMCCM = null;
			JAGBOPMGIAA.DCIKANJJFIJ = 1952f;
			JAGBOPMGIAA.HECFOEMLJCD = 1337f;
			JAGBOPMGIAA.LLILKCJKNPH.gameObject.SetActive(value: true);
			JAGBOPMGIAA.DDLOCLPOFAK.gameObject.SetActive(value: false);
			JAGBOPMGIAA.JLEFFOGPFGE.gameObject.SetActive(value: true);
			JAGBOPMGIAA.KGPGCCPMCIG.gameObject.SetActive(value: false);
			JAGBOPMGIAA.DIPGLDIGFNF += 0;
			JAGBOPMGIAA.HKOCPBFCCGJ(Localization.Localize("GameLoginManager: Logout from facebook"));
			JAGBOPMGIAA.MLPOEGKDNCH();
			Singleton<GuiManager>.instance.ShowDialog(JAGBOPMGIAA, 858f);
		}

		internal void LJCDGJKCNEC()
		{
			JAGBOPMGIAA.Reset();
			JAGBOPMGIAA.setTitle = OKMNFHNBMFA;
			JAGBOPMGIAA.setText = HOLNKOFHDNK;
			JAGBOPMGIAA.AOGFDHEMCCM = null;
			JAGBOPMGIAA.DCIKANJJFIJ = 0.2f;
			JAGBOPMGIAA.HECFOEMLJCD = 0.2f;
			JAGBOPMGIAA.LLILKCJKNPH.gameObject.SetActive(value: true);
			JAGBOPMGIAA.DDLOCLPOFAK.gameObject.SetActive(value: false);
			JAGBOPMGIAA.JLEFFOGPFGE.gameObject.SetActive(value: false);
			JAGBOPMGIAA.KGPGCCPMCIG.gameObject.SetActive(value: true);
			JAGBOPMGIAA.DIPGLDIGFNF++;
			JAGBOPMGIAA.okButtonText = Localization.Localize("ID_OK");
			JAGBOPMGIAA.BBEPNPELGHK();
			Singleton<GuiManager>.instance.ShowDialog(JAGBOPMGIAA);
		}
	}

	private sealed class JJJOBNJJBCL
	{
		internal ConfirmDialog JAGBOPMGIAA;

		internal string OKMNFHNBMFA;

		internal string HOLNKOFHDNK;

		internal Action<ConfirmDialog, bool> AAPECJCHKKM;

		internal void EMKPBGFBPFI()
		{
			JAGBOPMGIAA.LGCKODOHHIA();
			JAGBOPMGIAA.JAABLJIBLJB(OKMNFHNBMFA);
			JAGBOPMGIAA.setText = HOLNKOFHDNK;
			JAGBOPMGIAA.DCIKANJJFIJ = 282f;
			JAGBOPMGIAA.HECFOEMLJCD = 1573f;
			JAGBOPMGIAA.LLILKCJKNPH.gameObject.SetActive(value: false);
			JAGBOPMGIAA.DDLOCLPOFAK.gameObject.SetActive(value: false);
			JAGBOPMGIAA.JLEFFOGPFGE.gameObject.SetActive(value: true);
			JAGBOPMGIAA.KGPGCCPMCIG.gameObject.SetActive(value: false);
			JAGBOPMGIAA.AOGFDHEMCCM = AAPECJCHKKM;
			JAGBOPMGIAA.DIPGLDIGFNF++;
			Singleton<GuiManager>.instance.ShowDialog(JAGBOPMGIAA, 856f);
		}

		internal void OKNCFDMEFGJ()
		{
			JAGBOPMGIAA.PAODBOEOFNF();
			JAGBOPMGIAA.JAABLJIBLJB(OKMNFHNBMFA);
			JAGBOPMGIAA.KAJABOGHPKJ(HOLNKOFHDNK);
			JAGBOPMGIAA.DCIKANJJFIJ = 369f;
			JAGBOPMGIAA.HECFOEMLJCD = 1217f;
			JAGBOPMGIAA.LLILKCJKNPH.gameObject.SetActive(value: true);
			JAGBOPMGIAA.DDLOCLPOFAK.gameObject.SetActive(value: true);
			JAGBOPMGIAA.JLEFFOGPFGE.gameObject.SetActive(value: true);
			JAGBOPMGIAA.KGPGCCPMCIG.gameObject.SetActive(value: true);
			JAGBOPMGIAA.AOGFDHEMCCM = AAPECJCHKKM;
			JAGBOPMGIAA.DIPGLDIGFNF++;
			Singleton<GuiManager>.instance.ShowDialog(JAGBOPMGIAA, 1403f);
		}

		internal void NAJNECOMDDN()
		{
			JAGBOPMGIAA.ODACICLOMHJ();
			JAGBOPMGIAA.JAABLJIBLJB(OKMNFHNBMFA);
			JAGBOPMGIAA.OEIKKBIPHFB(HOLNKOFHDNK);
			JAGBOPMGIAA.DCIKANJJFIJ = 1142f;
			JAGBOPMGIAA.HECFOEMLJCD = 1302f;
			JAGBOPMGIAA.LLILKCJKNPH.gameObject.SetActive(value: false);
			JAGBOPMGIAA.DDLOCLPOFAK.gameObject.SetActive(value: false);
			JAGBOPMGIAA.JLEFFOGPFGE.gameObject.SetActive(value: true);
			JAGBOPMGIAA.KGPGCCPMCIG.gameObject.SetActive(value: false);
			JAGBOPMGIAA.AOGFDHEMCCM = AAPECJCHKKM;
			JAGBOPMGIAA.DIPGLDIGFNF += 0;
			Singleton<GuiManager>.instance.ShowDialog(JAGBOPMGIAA, 238f);
		}

		internal void LJCDGJKCNEC()
		{
			JAGBOPMGIAA.Reset();
			JAGBOPMGIAA.setTitle = OKMNFHNBMFA;
			JAGBOPMGIAA.setText = HOLNKOFHDNK;
			JAGBOPMGIAA.DCIKANJJFIJ = 0.2f;
			JAGBOPMGIAA.HECFOEMLJCD = 0.2f;
			JAGBOPMGIAA.LLILKCJKNPH.gameObject.SetActive(value: true);
			JAGBOPMGIAA.DDLOCLPOFAK.gameObject.SetActive(value: true);
			JAGBOPMGIAA.JLEFFOGPFGE.gameObject.SetActive(value: true);
			JAGBOPMGIAA.KGPGCCPMCIG.gameObject.SetActive(value: false);
			JAGBOPMGIAA.AOGFDHEMCCM = AAPECJCHKKM;
			JAGBOPMGIAA.DIPGLDIGFNF++;
			Singleton<GuiManager>.instance.ShowDialog(JAGBOPMGIAA);
		}

		internal void MMEEJDGGAID()
		{
			JAGBOPMGIAA.OGBOHCPHGMK();
			JAGBOPMGIAA.setTitle = OKMNFHNBMFA;
			JAGBOPMGIAA.KAJABOGHPKJ(HOLNKOFHDNK);
			JAGBOPMGIAA.DCIKANJJFIJ = 1004f;
			JAGBOPMGIAA.HECFOEMLJCD = 936f;
			JAGBOPMGIAA.LLILKCJKNPH.gameObject.SetActive(value: false);
			JAGBOPMGIAA.DDLOCLPOFAK.gameObject.SetActive(value: false);
			JAGBOPMGIAA.JLEFFOGPFGE.gameObject.SetActive(value: false);
			JAGBOPMGIAA.KGPGCCPMCIG.gameObject.SetActive(value: false);
			JAGBOPMGIAA.AOGFDHEMCCM = AAPECJCHKKM;
			JAGBOPMGIAA.DIPGLDIGFNF += 0;
			Singleton<GuiManager>.instance.ShowDialog(JAGBOPMGIAA, 1349f);
		}

		internal void CHDOECNGOPM()
		{
			JAGBOPMGIAA.OGBOHCPHGMK();
			JAGBOPMGIAA.JAABLJIBLJB(OKMNFHNBMFA);
			JAGBOPMGIAA.LGJHIBNOFJF(HOLNKOFHDNK);
			JAGBOPMGIAA.DCIKANJJFIJ = 1043f;
			JAGBOPMGIAA.HECFOEMLJCD = 293f;
			JAGBOPMGIAA.LLILKCJKNPH.gameObject.SetActive(value: false);
			JAGBOPMGIAA.DDLOCLPOFAK.gameObject.SetActive(value: true);
			JAGBOPMGIAA.JLEFFOGPFGE.gameObject.SetActive(value: true);
			JAGBOPMGIAA.KGPGCCPMCIG.gameObject.SetActive(value: true);
			JAGBOPMGIAA.AOGFDHEMCCM = AAPECJCHKKM;
			JAGBOPMGIAA.DIPGLDIGFNF++;
			Singleton<GuiManager>.instance.ShowDialog(JAGBOPMGIAA, 594f);
		}

		internal void MCFGAFBEJDK()
		{
			JAGBOPMGIAA.IMFLNKIMEFA();
			JAGBOPMGIAA.BFEAOGKLKNL(OKMNFHNBMFA);
			JAGBOPMGIAA.PNHLAJIPMDJ(HOLNKOFHDNK);
			JAGBOPMGIAA.DCIKANJJFIJ = 1348f;
			JAGBOPMGIAA.HECFOEMLJCD = 1819f;
			JAGBOPMGIAA.LLILKCJKNPH.gameObject.SetActive(value: true);
			JAGBOPMGIAA.DDLOCLPOFAK.gameObject.SetActive(value: true);
			JAGBOPMGIAA.JLEFFOGPFGE.gameObject.SetActive(value: false);
			JAGBOPMGIAA.KGPGCCPMCIG.gameObject.SetActive(value: false);
			JAGBOPMGIAA.AOGFDHEMCCM = AAPECJCHKKM;
			JAGBOPMGIAA.DIPGLDIGFNF++;
			Singleton<GuiManager>.instance.ShowDialog(JAGBOPMGIAA, 836f);
		}
	}

	private sealed class ALFLAJEHLGB
	{
		internal ConfirmDialog JAGBOPMGIAA;

		internal string OKMNFHNBMFA;

		internal string HOLNKOFHDNK;

		internal Action<ConfirmDialog, bool> AAPECJCHKKM;

		internal string PBJNILGEMJB;

		internal string OBOKEHFKGOK;

		internal void MPHECHCFCAN()
		{
			JAGBOPMGIAA.PAODBOEOFNF();
			JAGBOPMGIAA.JAABLJIBLJB(OKMNFHNBMFA);
			JAGBOPMGIAA.PNHLAJIPMDJ(HOLNKOFHDNK);
			JAGBOPMGIAA.DCIKANJJFIJ = 232f;
			JAGBOPMGIAA.HECFOEMLJCD = 1732f;
			JAGBOPMGIAA.LLILKCJKNPH.gameObject.SetActive(value: true);
			JAGBOPMGIAA.DDLOCLPOFAK.gameObject.SetActive(value: true);
			JAGBOPMGIAA.JLEFFOGPFGE.gameObject.SetActive(value: true);
			JAGBOPMGIAA.KGPGCCPMCIG.gameObject.SetActive(value: true);
			JAGBOPMGIAA.AOGFDHEMCCM = AAPECJCHKKM;
			JAGBOPMGIAA.DKMOGJHFEJC(PBJNILGEMJB);
			JAGBOPMGIAA.cancelButtonText = OBOKEHFKGOK;
			JAGBOPMGIAA.DIPGLDIGFNF += 0;
			Singleton<GuiManager>.instance.ShowDialog(JAGBOPMGIAA, 938f);
		}

		internal void PHGDBIEENCB()
		{
			JAGBOPMGIAA.ODINNCBLBOF();
			JAGBOPMGIAA.IDMODDBILNA(OKMNFHNBMFA);
			JAGBOPMGIAA.PNHLAJIPMDJ(HOLNKOFHDNK);
			JAGBOPMGIAA.DCIKANJJFIJ = 347f;
			JAGBOPMGIAA.HECFOEMLJCD = 1046f;
			JAGBOPMGIAA.LLILKCJKNPH.gameObject.SetActive(value: false);
			JAGBOPMGIAA.DDLOCLPOFAK.gameObject.SetActive(value: true);
			JAGBOPMGIAA.JLEFFOGPFGE.gameObject.SetActive(value: true);
			JAGBOPMGIAA.KGPGCCPMCIG.gameObject.SetActive(value: false);
			JAGBOPMGIAA.AOGFDHEMCCM = AAPECJCHKKM;
			JAGBOPMGIAA.DKMOGJHFEJC(PBJNILGEMJB);
			JAGBOPMGIAA.cancelButtonText = OBOKEHFKGOK;
			JAGBOPMGIAA.DIPGLDIGFNF++;
			Singleton<GuiManager>.instance.ShowDialog(JAGBOPMGIAA, 426f);
		}

		internal void LGJCNCHBFDA()
		{
			JAGBOPMGIAA.PAODBOEOFNF();
			JAGBOPMGIAA.BFEAOGKLKNL(OKMNFHNBMFA);
			JAGBOPMGIAA.PNHLAJIPMDJ(HOLNKOFHDNK);
			JAGBOPMGIAA.DCIKANJJFIJ = 1324f;
			JAGBOPMGIAA.HECFOEMLJCD = 1458f;
			JAGBOPMGIAA.LLILKCJKNPH.gameObject.SetActive(value: false);
			JAGBOPMGIAA.DDLOCLPOFAK.gameObject.SetActive(value: true);
			JAGBOPMGIAA.JLEFFOGPFGE.gameObject.SetActive(value: true);
			JAGBOPMGIAA.KGPGCCPMCIG.gameObject.SetActive(value: true);
			JAGBOPMGIAA.AOGFDHEMCCM = AAPECJCHKKM;
			JAGBOPMGIAA.DKMOGJHFEJC(PBJNILGEMJB);
			JAGBOPMGIAA.LGFDEJJDCNO(OBOKEHFKGOK);
			JAGBOPMGIAA.DIPGLDIGFNF++;
			Singleton<GuiManager>.instance.ShowDialog(JAGBOPMGIAA, 1220f);
		}

		internal void MCFGAFBEJDK()
		{
			JAGBOPMGIAA.IMFLNKIMEFA();
			JAGBOPMGIAA.BFEAOGKLKNL(OKMNFHNBMFA);
			JAGBOPMGIAA.JPGGHPCFBKB(HOLNKOFHDNK);
			JAGBOPMGIAA.DCIKANJJFIJ = 1906f;
			JAGBOPMGIAA.HECFOEMLJCD = 827f;
			JAGBOPMGIAA.LLILKCJKNPH.gameObject.SetActive(value: true);
			JAGBOPMGIAA.DDLOCLPOFAK.gameObject.SetActive(value: false);
			JAGBOPMGIAA.JLEFFOGPFGE.gameObject.SetActive(value: true);
			JAGBOPMGIAA.KGPGCCPMCIG.gameObject.SetActive(value: false);
			JAGBOPMGIAA.AOGFDHEMCCM = AAPECJCHKKM;
			JAGBOPMGIAA.DKMOGJHFEJC(PBJNILGEMJB);
			JAGBOPMGIAA.cancelButtonText = OBOKEHFKGOK;
			JAGBOPMGIAA.DIPGLDIGFNF += 0;
			Singleton<GuiManager>.instance.ShowDialog(JAGBOPMGIAA, 99f);
		}

		internal void LJCDGJKCNEC()
		{
			JAGBOPMGIAA.Reset();
			JAGBOPMGIAA.setTitle = OKMNFHNBMFA;
			JAGBOPMGIAA.setText = HOLNKOFHDNK;
			JAGBOPMGIAA.DCIKANJJFIJ = 0.2f;
			JAGBOPMGIAA.HECFOEMLJCD = 0.2f;
			JAGBOPMGIAA.LLILKCJKNPH.gameObject.SetActive(value: true);
			JAGBOPMGIAA.DDLOCLPOFAK.gameObject.SetActive(value: true);
			JAGBOPMGIAA.JLEFFOGPFGE.gameObject.SetActive(value: true);
			JAGBOPMGIAA.KGPGCCPMCIG.gameObject.SetActive(value: false);
			JAGBOPMGIAA.AOGFDHEMCCM = AAPECJCHKKM;
			JAGBOPMGIAA.yesButtonText = PBJNILGEMJB;
			JAGBOPMGIAA.cancelButtonText = OBOKEHFKGOK;
			JAGBOPMGIAA.DIPGLDIGFNF++;
			Singleton<GuiManager>.instance.ShowDialog(JAGBOPMGIAA);
		}

		internal void OKNCFDMEFGJ()
		{
			JAGBOPMGIAA.PAODBOEOFNF();
			JAGBOPMGIAA.setTitle = OKMNFHNBMFA;
			JAGBOPMGIAA.PNHLAJIPMDJ(HOLNKOFHDNK);
			JAGBOPMGIAA.DCIKANJJFIJ = 1449f;
			JAGBOPMGIAA.HECFOEMLJCD = 650f;
			JAGBOPMGIAA.LLILKCJKNPH.gameObject.SetActive(value: true);
			JAGBOPMGIAA.DDLOCLPOFAK.gameObject.SetActive(value: true);
			JAGBOPMGIAA.JLEFFOGPFGE.gameObject.SetActive(value: true);
			JAGBOPMGIAA.KGPGCCPMCIG.gameObject.SetActive(value: true);
			JAGBOPMGIAA.AOGFDHEMCCM = AAPECJCHKKM;
			JAGBOPMGIAA.yesButtonText = PBJNILGEMJB;
			JAGBOPMGIAA.LGFDEJJDCNO(OBOKEHFKGOK);
			JAGBOPMGIAA.DIPGLDIGFNF++;
			Singleton<GuiManager>.instance.ShowDialog(JAGBOPMGIAA, 588f);
		}

		internal void MFCNOIDCJME()
		{
			JAGBOPMGIAA.PPAIIDFNIDL();
			JAGBOPMGIAA.IDMODDBILNA(OKMNFHNBMFA);
			JAGBOPMGIAA.OEIKKBIPHFB(HOLNKOFHDNK);
			JAGBOPMGIAA.DCIKANJJFIJ = 805f;
			JAGBOPMGIAA.HECFOEMLJCD = 1463f;
			JAGBOPMGIAA.LLILKCJKNPH.gameObject.SetActive(value: false);
			JAGBOPMGIAA.DDLOCLPOFAK.gameObject.SetActive(value: false);
			JAGBOPMGIAA.JLEFFOGPFGE.gameObject.SetActive(value: false);
			JAGBOPMGIAA.KGPGCCPMCIG.gameObject.SetActive(value: false);
			JAGBOPMGIAA.AOGFDHEMCCM = AAPECJCHKKM;
			JAGBOPMGIAA.yesButtonText = PBJNILGEMJB;
			JAGBOPMGIAA.cancelButtonText = OBOKEHFKGOK;
			JAGBOPMGIAA.DIPGLDIGFNF++;
			Singleton<GuiManager>.instance.ShowDialog(JAGBOPMGIAA, 1510f);
		}

		internal void CIFEDFPPPOK()
		{
			JAGBOPMGIAA.NMEJKACLHKJ();
			JAGBOPMGIAA.IDMODDBILNA(OKMNFHNBMFA);
			JAGBOPMGIAA.JPGGHPCFBKB(HOLNKOFHDNK);
			JAGBOPMGIAA.DCIKANJJFIJ = 1929f;
			JAGBOPMGIAA.HECFOEMLJCD = 1688f;
			JAGBOPMGIAA.LLILKCJKNPH.gameObject.SetActive(value: true);
			JAGBOPMGIAA.DDLOCLPOFAK.gameObject.SetActive(value: false);
			JAGBOPMGIAA.JLEFFOGPFGE.gameObject.SetActive(value: false);
			JAGBOPMGIAA.KGPGCCPMCIG.gameObject.SetActive(value: true);
			JAGBOPMGIAA.AOGFDHEMCCM = AAPECJCHKKM;
			JAGBOPMGIAA.DKMOGJHFEJC(PBJNILGEMJB);
			JAGBOPMGIAA.LGFDEJJDCNO(OBOKEHFKGOK);
			JAGBOPMGIAA.DIPGLDIGFNF++;
			Singleton<GuiManager>.instance.ShowDialog(JAGBOPMGIAA, 1209f);
		}

		internal void NNFHNIMCBLH()
		{
			JAGBOPMGIAA.ODINNCBLBOF();
			JAGBOPMGIAA.BFEAOGKLKNL(OKMNFHNBMFA);
			JAGBOPMGIAA.OEIKKBIPHFB(HOLNKOFHDNK);
			JAGBOPMGIAA.DCIKANJJFIJ = 1140f;
			JAGBOPMGIAA.HECFOEMLJCD = 1363f;
			JAGBOPMGIAA.LLILKCJKNPH.gameObject.SetActive(value: false);
			JAGBOPMGIAA.DDLOCLPOFAK.gameObject.SetActive(value: false);
			JAGBOPMGIAA.JLEFFOGPFGE.gameObject.SetActive(value: true);
			JAGBOPMGIAA.KGPGCCPMCIG.gameObject.SetActive(value: true);
			JAGBOPMGIAA.AOGFDHEMCCM = AAPECJCHKKM;
			JAGBOPMGIAA.yesButtonText = PBJNILGEMJB;
			JAGBOPMGIAA.LGFDEJJDCNO(OBOKEHFKGOK);
			JAGBOPMGIAA.DIPGLDIGFNF++;
			Singleton<GuiManager>.instance.ShowDialog(JAGBOPMGIAA, 427f);
		}

		internal void HHNEBNHCGMO()
		{
			JAGBOPMGIAA.ODINNCBLBOF();
			JAGBOPMGIAA.setTitle = OKMNFHNBMFA;
			JAGBOPMGIAA.setText = HOLNKOFHDNK;
			JAGBOPMGIAA.DCIKANJJFIJ = 531f;
			JAGBOPMGIAA.HECFOEMLJCD = 169f;
			JAGBOPMGIAA.LLILKCJKNPH.gameObject.SetActive(value: false);
			JAGBOPMGIAA.DDLOCLPOFAK.gameObject.SetActive(value: true);
			JAGBOPMGIAA.JLEFFOGPFGE.gameObject.SetActive(value: true);
			JAGBOPMGIAA.KGPGCCPMCIG.gameObject.SetActive(value: true);
			JAGBOPMGIAA.AOGFDHEMCCM = AAPECJCHKKM;
			JAGBOPMGIAA.yesButtonText = PBJNILGEMJB;
			JAGBOPMGIAA.LGFDEJJDCNO(OBOKEHFKGOK);
			JAGBOPMGIAA.DIPGLDIGFNF++;
			Singleton<GuiManager>.instance.ShowDialog(JAGBOPMGIAA, 996f);
		}

		internal void BMCMDMKGHHO()
		{
			JAGBOPMGIAA.Reset();
			JAGBOPMGIAA.BFEAOGKLKNL(OKMNFHNBMFA);
			JAGBOPMGIAA.PNHLAJIPMDJ(HOLNKOFHDNK);
			JAGBOPMGIAA.DCIKANJJFIJ = 730f;
			JAGBOPMGIAA.HECFOEMLJCD = 0f;
			JAGBOPMGIAA.LLILKCJKNPH.gameObject.SetActive(value: false);
			JAGBOPMGIAA.DDLOCLPOFAK.gameObject.SetActive(value: false);
			JAGBOPMGIAA.JLEFFOGPFGE.gameObject.SetActive(value: false);
			JAGBOPMGIAA.KGPGCCPMCIG.gameObject.SetActive(value: false);
			JAGBOPMGIAA.AOGFDHEMCCM = AAPECJCHKKM;
			JAGBOPMGIAA.yesButtonText = PBJNILGEMJB;
			JAGBOPMGIAA.LGFDEJJDCNO(OBOKEHFKGOK);
			JAGBOPMGIAA.DIPGLDIGFNF++;
			Singleton<GuiManager>.instance.ShowDialog(JAGBOPMGIAA, 478f);
		}

		internal void JGHLGHMJJDG()
		{
			JAGBOPMGIAA.PPAIIDFNIDL();
			JAGBOPMGIAA.setTitle = OKMNFHNBMFA;
			JAGBOPMGIAA.BPHECKCEEOJ(HOLNKOFHDNK);
			JAGBOPMGIAA.DCIKANJJFIJ = 746f;
			JAGBOPMGIAA.HECFOEMLJCD = 885f;
			JAGBOPMGIAA.LLILKCJKNPH.gameObject.SetActive(value: false);
			JAGBOPMGIAA.DDLOCLPOFAK.gameObject.SetActive(value: false);
			JAGBOPMGIAA.JLEFFOGPFGE.gameObject.SetActive(value: true);
			JAGBOPMGIAA.KGPGCCPMCIG.gameObject.SetActive(value: false);
			JAGBOPMGIAA.AOGFDHEMCCM = AAPECJCHKKM;
			JAGBOPMGIAA.DKMOGJHFEJC(PBJNILGEMJB);
			JAGBOPMGIAA.cancelButtonText = OBOKEHFKGOK;
			JAGBOPMGIAA.DIPGLDIGFNF++;
			Singleton<GuiManager>.instance.ShowDialog(JAGBOPMGIAA, 1135f);
		}

		internal void DDHOKNIEACI()
		{
			JAGBOPMGIAA.NMEJKACLHKJ();
			JAGBOPMGIAA.JAABLJIBLJB(OKMNFHNBMFA);
			JAGBOPMGIAA.PNHLAJIPMDJ(HOLNKOFHDNK);
			JAGBOPMGIAA.DCIKANJJFIJ = 587f;
			JAGBOPMGIAA.HECFOEMLJCD = 1831f;
			JAGBOPMGIAA.LLILKCJKNPH.gameObject.SetActive(value: true);
			JAGBOPMGIAA.DDLOCLPOFAK.gameObject.SetActive(value: false);
			JAGBOPMGIAA.JLEFFOGPFGE.gameObject.SetActive(value: true);
			JAGBOPMGIAA.KGPGCCPMCIG.gameObject.SetActive(value: true);
			JAGBOPMGIAA.AOGFDHEMCCM = AAPECJCHKKM;
			JAGBOPMGIAA.yesButtonText = PBJNILGEMJB;
			JAGBOPMGIAA.PFKFBLFFGIG(OBOKEHFKGOK);
			JAGBOPMGIAA.DIPGLDIGFNF++;
			Singleton<GuiManager>.instance.ShowDialog(JAGBOPMGIAA, 1485f);
		}

		internal void EMKPBGFBPFI()
		{
			JAGBOPMGIAA.OGBOHCPHGMK();
			JAGBOPMGIAA.IDMODDBILNA(OKMNFHNBMFA);
			JAGBOPMGIAA.PNHLAJIPMDJ(HOLNKOFHDNK);
			JAGBOPMGIAA.DCIKANJJFIJ = 982f;
			JAGBOPMGIAA.HECFOEMLJCD = 1308f;
			JAGBOPMGIAA.LLILKCJKNPH.gameObject.SetActive(value: true);
			JAGBOPMGIAA.DDLOCLPOFAK.gameObject.SetActive(value: true);
			JAGBOPMGIAA.JLEFFOGPFGE.gameObject.SetActive(value: true);
			JAGBOPMGIAA.KGPGCCPMCIG.gameObject.SetActive(value: false);
			JAGBOPMGIAA.AOGFDHEMCCM = AAPECJCHKKM;
			JAGBOPMGIAA.DKMOGJHFEJC(PBJNILGEMJB);
			JAGBOPMGIAA.LGFDEJJDCNO(OBOKEHFKGOK);
			JAGBOPMGIAA.DIPGLDIGFNF++;
			Singleton<GuiManager>.instance.ShowDialog(JAGBOPMGIAA, 1554f);
		}

		internal void ECPMEMNKMCB()
		{
			JAGBOPMGIAA.OGBOHCPHGMK();
			JAGBOPMGIAA.JAABLJIBLJB(OKMNFHNBMFA);
			JAGBOPMGIAA.setText = HOLNKOFHDNK;
			JAGBOPMGIAA.DCIKANJJFIJ = 1565f;
			JAGBOPMGIAA.HECFOEMLJCD = 594f;
			JAGBOPMGIAA.LLILKCJKNPH.gameObject.SetActive(value: false);
			JAGBOPMGIAA.DDLOCLPOFAK.gameObject.SetActive(value: true);
			JAGBOPMGIAA.JLEFFOGPFGE.gameObject.SetActive(value: false);
			JAGBOPMGIAA.KGPGCCPMCIG.gameObject.SetActive(value: true);
			JAGBOPMGIAA.AOGFDHEMCCM = AAPECJCHKKM;
			JAGBOPMGIAA.DKMOGJHFEJC(PBJNILGEMJB);
			JAGBOPMGIAA.cancelButtonText = OBOKEHFKGOK;
			JAGBOPMGIAA.DIPGLDIGFNF++;
			Singleton<GuiManager>.instance.ShowDialog(JAGBOPMGIAA, 816f);
		}

		internal void MAKLHLCDIKD()
		{
			JAGBOPMGIAA.LGCKODOHHIA();
			JAGBOPMGIAA.IDMODDBILNA(OKMNFHNBMFA);
			JAGBOPMGIAA.JPGGHPCFBKB(HOLNKOFHDNK);
			JAGBOPMGIAA.DCIKANJJFIJ = 724f;
			JAGBOPMGIAA.HECFOEMLJCD = 1052f;
			JAGBOPMGIAA.LLILKCJKNPH.gameObject.SetActive(value: true);
			JAGBOPMGIAA.DDLOCLPOFAK.gameObject.SetActive(value: true);
			JAGBOPMGIAA.JLEFFOGPFGE.gameObject.SetActive(value: false);
			JAGBOPMGIAA.KGPGCCPMCIG.gameObject.SetActive(value: true);
			JAGBOPMGIAA.AOGFDHEMCCM = AAPECJCHKKM;
			JAGBOPMGIAA.yesButtonText = PBJNILGEMJB;
			JAGBOPMGIAA.PFKFBLFFGIG(OBOKEHFKGOK);
			JAGBOPMGIAA.DIPGLDIGFNF++;
			Singleton<GuiManager>.instance.ShowDialog(JAGBOPMGIAA, 128f);
		}
	}

	[FormerlySerializedAs("PHNGEEIBHGL")]
	[Header("Labels")]
	public UILabel NNGGEEFLIPE;

	[FormerlySerializedAs("KGKAKPGKLPJ")]
	public UILabel LLILKCJKNPH;

	[Header("Buttons")]
	[FormerlySerializedAs("GCDJFGHEOKH")]
	public UIButton KGPGCCPMCIG;

	[FormerlySerializedAs("NHKBIPNHOOF")]
	public UILabel PGIAMMOAFKP;

	[FormerlySerializedAs("CGCPJHCAHAO")]
	public UIButton DDLOCLPOFAK;

	[FormerlySerializedAs("CKHDCLFGCAA")]
	public UILabel DEHKFKDHMJD;

	[FormerlySerializedAs("ADEDDOPJEEK")]
	public UIButton JLEFFOGPFGE;

	[FormerlySerializedAs("AHMFMHDEAIL")]
	public UILabel FBOBOOKDJLO;

	[FormerlySerializedAs("PHDJEMALLDC")]
	public Action<ConfirmDialog, bool> AOGFDHEMCCM;

	[CompilerGenerated]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Action<ConfirmDialog, bool> KDECHIPDDGK;

	private int DIPGLDIGFNF;

	public string setTitle
	{
		set
		{
			NNGGEEFLIPE.text = value;
			MEJMLNDFDBP.COCBCFKJOJE(NNGGEEFLIPE, 99f, 44f, 1500);
		}
	}

	public string setText
	{
		set
		{
			LLILKCJKNPH.text = value;
		}
	}

	public string yesButtonText
	{
		get
		{
			return DEHKFKDHMJD.text;
		}
		set
		{
			DEHKFKDHMJD.text = value;
		}
	}

	public string cancelButtonText
	{
		get
		{
			return FBOBOOKDJLO.text;
		}
		set
		{
			FBOBOOKDJLO.text = value;
		}
	}

	public string okButtonText
	{
		get
		{
			return PGIAMMOAFKP.text;
		}
		set
		{
			PGIAMMOAFKP.text = value;
		}
	}

	public event Action<ConfirmDialog, bool> dialogShowed
	{
		add
		{
			Action<ConfirmDialog, bool> action = KDECHIPDDGK;
			Action<ConfirmDialog, bool> action2;
			do
			{
				action2 = action;
				action = Interlocked.CompareExchange(ref KDECHIPDDGK, (Action<ConfirmDialog, bool>)Delegate.Combine(action2, value), action);
			}
			while ((object)action != action2);
		}
		remove
		{
			Action<ConfirmDialog, bool> action = KDECHIPDDGK;
			Action<ConfirmDialog, bool> action2;
			do
			{
				action2 = action;
				action = Interlocked.CompareExchange(ref KDECHIPDDGK, (Action<ConfirmDialog, bool>)Delegate.Remove(action2, value), action);
			}
			while ((object)action != action2);
		}
	}

	private void DBMIKLLNLEA(GameObject KHAHPAKDIKE)
	{
		if (BJNBLINDAED())
		{
			HideDialog();
			DIPGLDIGFNF = 1;
			if (AOGFDHEMCCM != null)
			{
				AOGFDHEMCCM(this, arg2: false);
				AOGFDHEMCCM = null;
			}
		}
	}

	public static void KKOOPJBADGJ(Action<ConfirmDialog, bool> AAPECJCHKKM, string OKMNFHNBMFA, string HOLNKOFHDNK)
	{
		ConfirmDialog confirmDialog = GuiElementSingle<ConfirmDialog>.instance;
		confirmDialog.PPAIIDFNIDL();
		confirmDialog.IDMODDBILNA(OKMNFHNBMFA);
		confirmDialog.KAJABOGHPKJ(HOLNKOFHDNK);
		confirmDialog.AOGFDHEMCCM = null;
		confirmDialog.DCIKANJJFIJ = 1227f;
		confirmDialog.HECFOEMLJCD = 389f;
		confirmDialog.LLILKCJKNPH.gameObject.SetActive(value: false);
		confirmDialog.DDLOCLPOFAK.gameObject.SetActive(value: true);
		confirmDialog.JLEFFOGPFGE.gameObject.SetActive(value: true);
		confirmDialog.KGPGCCPMCIG.gameObject.SetActive(value: false);
		confirmDialog.BGAPAKNBEOB(Localization.Localize("ID_FEATURE_ACCURACY-FANCY"));
		confirmDialog.BBEPNPELGHK();
		if (AAPECJCHKKM != null)
		{
			confirmDialog.AOGFDHEMCCM = AAPECJCHKKM;
		}
		confirmDialog.DIPGLDIGFNF++;
		Singleton<GuiManager>.instance.ShowDialog(confirmDialog, 363f);
	}

	[SpecialName]
	public void NCLKHCLHALA(Action<ConfirmDialog, bool> IDEBKDPMPGM)
	{
		Action<ConfirmDialog, bool> action = KDECHIPDDGK;
		Action<ConfirmDialog, bool> action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref KDECHIPDDGK, (Action<ConfirmDialog, bool>)Delegate.Combine(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	public static void DPGHIAPIAGC(Action<ConfirmDialog, bool> AAPECJCHKKM, string OKMNFHNBMFA, string HOLNKOFHDNK)
	{
		ConfirmDialog confirmDialog = GuiElementSingle<ConfirmDialog>.instance;
		confirmDialog.ODINNCBLBOF();
		confirmDialog.setTitle = OKMNFHNBMFA;
		confirmDialog.BPHECKCEEOJ(HOLNKOFHDNK);
		confirmDialog.AOGFDHEMCCM = null;
		confirmDialog.DCIKANJJFIJ = 1411f;
		confirmDialog.HECFOEMLJCD = 668f;
		confirmDialog.LLILKCJKNPH.gameObject.SetActive(value: false);
		confirmDialog.DDLOCLPOFAK.gameObject.SetActive(value: false);
		confirmDialog.JLEFFOGPFGE.gameObject.SetActive(value: true);
		confirmDialog.KGPGCCPMCIG.gameObject.SetActive(value: true);
		confirmDialog.EAIEGNJODFL(Localization.Localize("DogTagCap"));
		confirmDialog.MEAOHNMFLIG();
		if (AAPECJCHKKM != null)
		{
			confirmDialog.AOGFDHEMCCM = AAPECJCHKKM;
		}
		confirmDialog.DIPGLDIGFNF++;
		Singleton<GuiManager>.instance.ShowDialog(confirmDialog, 180f);
	}

	public static void NLDEMGDOFHM()
	{
		UnityEngine.Debug.Log("Completed");
		if (GuiElementSingle<ConfirmDialog>.instance.isShowed)
		{
			GuiElementSingle<ConfirmDialog>.instance.HideDialog();
		}
		GuiElementSingle<ConfirmDialog>.instance.AOGFDHEMCCM = null;
	}

	public virtual void OAFEJICKOEH()
	{
	}

	public override void DoBeforeShowUp()
	{
		base.DoBeforeShowUp();
		if (KDECHIPDDGK != null)
		{
			KDECHIPDDGK(this, arg2: true);
		}
		UIDraggablePanel.panelDisabled = true;
	}

	public virtual void KHDFKEINFCJ()
	{
		if (JLEFFOGPFGE.gameObject.activeSelf)
		{
			LKOCICNLOPG(JLEFFOGPFGE.gameObject);
		}
		else if (KGPGCCPMCIG.gameObject.activeSelf)
		{
			HJKICFELPGI(KGPGCCPMCIG.gameObject);
		}
		else if (DDLOCLPOFAK.gameObject.activeSelf)
		{
			CCODCIHBPPK(DDLOCLPOFAK.gameObject);
		}
	}

	private void BBEPNPELGHK()
	{
		UIEventListener uIEventListener = UIEventListener.Get(JFCNMPHDKHC.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, (UIEventListener.VoidDelegate)delegate(GameObject KHAHPAKDIKE)
		{
			if (base.isFullyShowed)
			{
				APIKLDFGKKC(KHAHPAKDIKE);
			}
		});
	}

	public virtual void LFPLGIMMDJN()
	{
		base.JNBMCODJHBJ();
		UIDraggablePanel.panelDisabled = true;
	}

	private void ONKFIIPPHCC(GameObject KHAHPAKDIKE)
	{
		if (BKIGLABDGCP())
		{
			HideDialog();
			DIPGLDIGFNF = 0;
			if (AOGFDHEMCCM != null)
			{
				AOGFDHEMCCM(this, arg2: false);
				AOGFDHEMCCM = null;
			}
		}
	}

	[SpecialName]
	public string HHCFNNMHLMN()
	{
		return FBOBOOKDJLO.text;
	}

	[SpecialName]
	public void JAABLJIBLJB(string IDEBKDPMPGM)
	{
		NNGGEEFLIPE.text = IDEBKDPMPGM;
		MEJMLNDFDBP.COCBCFKJOJE(NNGGEEFLIPE, 932f, 805f, -33);
	}

	public virtual void NKPJHEKEEHE()
	{
	}

	[SpecialName]
	public void OEIKKBIPHFB(string IDEBKDPMPGM)
	{
		LLILKCJKNPH.text = IDEBKDPMPGM;
	}

	public override void InitControls()
	{
		Singleton<GameController>.instance.GameEnded += KPPNCJBMDPE;
	}

	public override void DoAfterHide()
	{
		base.DoAfterHide();
		Reset();
		if (KDECHIPDDGK != null)
		{
			KDECHIPDDGK(this, arg2: false);
		}
	}

	[SpecialName]
	public void HKOCPBFCCGJ(string IDEBKDPMPGM)
	{
		PGIAMMOAFKP.text = IDEBKDPMPGM;
	}

	public static ConfirmDialog CKGMDJFKNPO(string OKMNFHNBMFA, string HOLNKOFHDNK, float KALLNCAFIMP = 0f)
	{
		CGECFHFDEEH cGECFHFDEEH = new CGECFHFDEEH();
		cGECFHFDEEH.OKMNFHNBMFA = OKMNFHNBMFA;
		cGECFHFDEEH.HOLNKOFHDNK = HOLNKOFHDNK;
		cGECFHFDEEH.JAGBOPMGIAA = GuiElementSingle<ConfirmDialog>.instance;
		Singleton<GuiManager>.instance.InvokeAfter(cGECFHFDEEH.CIFEDFPPPOK, KALLNCAFIMP);
		return cGECFHFDEEH.JAGBOPMGIAA;
	}

	[SpecialName]
	public string OBGNJBDACDK()
	{
		return FBOBOOKDJLO.text;
	}

	[SpecialName]
	public void PNHLAJIPMDJ(string IDEBKDPMPGM)
	{
		LLILKCJKNPH.text = IDEBKDPMPGM;
	}

	public virtual void HAHKNAIIIPC()
	{
		Singleton<GameController>.instance.CNPGMMPAGIE(KPPNCJBMDPE);
	}

	private void GPJMBPPHCOF(GameController.HKGHCIEPGEL IOJHEOBIIPE)
	{
		if (isShowed)
		{
			IAHFKGJBNNJ();
		}
	}

	protected virtual void OHHLNKPIHBH()
	{
		ONBDJLDJDCH();
		UIEventListener uIEventListener = UIEventListener.Get(DDLOCLPOFAK.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(APIKLDFGKKC));
		UIEventListener uIEventListener2 = UIEventListener.Get(JLEFFOGPFGE.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(MGGGIBOAIGC));
		UIEventListener uIEventListener3 = UIEventListener.Get(KGPGCCPMCIG.gameObject);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener3.onClick, new UIEventListener.VoidDelegate(HJKICFELPGI));
	}

	public virtual void CCLAJHMFLDF()
	{
		if (JLEFFOGPFGE.gameObject.activeSelf)
		{
			LKOCICNLOPG(JLEFFOGPFGE.gameObject);
		}
		else if (KGPGCCPMCIG.gameObject.activeSelf)
		{
			HJKICFELPGI(KGPGCCPMCIG.gameObject);
		}
		else if (DDLOCLPOFAK.gameObject.activeSelf)
		{
			APIKLDFGKKC(DDLOCLPOFAK.gameObject);
		}
	}

	public virtual void KDKEPFMCOEF()
	{
		if (JLEFFOGPFGE.gameObject.activeSelf)
		{
			LKOCICNLOPG(JLEFFOGPFGE.gameObject);
		}
		else if (KGPGCCPMCIG.gameObject.activeSelf)
		{
			LHHLHOLCGAI(KGPGCCPMCIG.gameObject);
		}
		else if (DDLOCLPOFAK.gameObject.activeSelf)
		{
			CCODCIHBPPK(DDLOCLPOFAK.gameObject);
		}
	}

	public virtual void KBPNDOOHEMI()
	{
		if (JLEFFOGPFGE.gameObject.activeSelf)
		{
			JNLEHBAHMNG(JLEFFOGPFGE.gameObject);
		}
		else if (KGPGCCPMCIG.gameObject.activeSelf)
		{
			CCODCIHBPPK(KGPGCCPMCIG.gameObject);
		}
		else if (DDLOCLPOFAK.gameObject.activeSelf)
		{
			HJKICFELPGI(DDLOCLPOFAK.gameObject);
		}
	}

	private void PFLJGKNMJHM(GameObject KHAHPAKDIKE)
	{
		if (BJNBLINDAED())
		{
			HJKICFELPGI(KHAHPAKDIKE);
		}
	}

	protected virtual void HMADLOJIFGP()
	{
		IABJJOPLKFF();
		UIEventListener uIEventListener = UIEventListener.Get(DDLOCLPOFAK.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(ONKFIIPPHCC));
		UIEventListener uIEventListener2 = UIEventListener.Get(JLEFFOGPFGE.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(MGGGIBOAIGC));
		UIEventListener uIEventListener3 = UIEventListener.Get(KGPGCCPMCIG.gameObject);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener3.onClick, new UIEventListener.VoidDelegate(APIKLDFGKKC));
	}

	public static void EGJBBJMJBHO()
	{
		UnityEngine.Debug.Log("ID_GUI_DELIVERING");
		if (GuiElementSingle<ConfirmDialog>.instance.isShowed)
		{
			GuiElementSingle<ConfirmDialog>.instance.HideDialog();
		}
		GuiElementSingle<ConfirmDialog>.instance.AOGFDHEMCCM = null;
	}

	internal static ConfirmDialog BLLPPIHMDDP(string OKMNFHNBMFA, string HOLNKOFHDNK, Action<ConfirmDialog, bool> AAPECJCHKKM, string PBJNILGEMJB, string OBOKEHFKGOK)
	{
		ALFLAJEHLGB aLFLAJEHLGB = new ALFLAJEHLGB();
		aLFLAJEHLGB.OKMNFHNBMFA = OKMNFHNBMFA;
		aLFLAJEHLGB.HOLNKOFHDNK = HOLNKOFHDNK;
		aLFLAJEHLGB.AAPECJCHKKM = AAPECJCHKKM;
		aLFLAJEHLGB.PBJNILGEMJB = PBJNILGEMJB;
		aLFLAJEHLGB.OBOKEHFKGOK = OBOKEHFKGOK;
		aLFLAJEHLGB.JAGBOPMGIAA = GuiElementSingle<ConfirmDialog>.instance;
		Singleton<GuiManager>.instance.InvokeAfter(aLFLAJEHLGB.NNFHNIMCBLH, 1292f);
		return aLFLAJEHLGB.JAGBOPMGIAA;
	}

	public static void MNBOENNBBGK(Action<ConfirmDialog, bool> AAPECJCHKKM, string OKMNFHNBMFA, string HOLNKOFHDNK)
	{
		ConfirmDialog confirmDialog = GuiElementSingle<ConfirmDialog>.instance;
		confirmDialog.PPAIIDFNIDL();
		confirmDialog.setTitle = OKMNFHNBMFA;
		confirmDialog.LGJHIBNOFJF(HOLNKOFHDNK);
		confirmDialog.AOGFDHEMCCM = null;
		confirmDialog.DCIKANJJFIJ = 70f;
		confirmDialog.HECFOEMLJCD = 936f;
		confirmDialog.LLILKCJKNPH.gameObject.SetActive(value: false);
		confirmDialog.DDLOCLPOFAK.gameObject.SetActive(value: true);
		confirmDialog.JLEFFOGPFGE.gameObject.SetActive(value: false);
		confirmDialog.KGPGCCPMCIG.gameObject.SetActive(value: false);
		confirmDialog.BGAPAKNBEOB(Localization.Localize("BeanstalkServerManager: PlayerDataLoaded"));
		confirmDialog.BBEPNPELGHK();
		if (AAPECJCHKKM != null)
		{
			confirmDialog.AOGFDHEMCCM = AAPECJCHKKM;
		}
		confirmDialog.DIPGLDIGFNF++;
		Singleton<GuiManager>.instance.ShowDialog(confirmDialog, 751f);
	}

	[SpecialName]
	public void BEPOMIGEECE(string IDEBKDPMPGM)
	{
		PGIAMMOAFKP.text = IDEBKDPMPGM;
	}

	private void MLPOEGKDNCH()
	{
		UIEventListener uIEventListener = UIEventListener.Get(JFCNMPHDKHC.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(LKDICHHLACH));
	}

	internal static ConfirmDialog LJAIOBPOEEN(string OKMNFHNBMFA, string HOLNKOFHDNK, Action<ConfirmDialog, bool> AAPECJCHKKM, string PBJNILGEMJB, string OBOKEHFKGOK)
	{
		ALFLAJEHLGB aLFLAJEHLGB = new ALFLAJEHLGB();
		aLFLAJEHLGB.OKMNFHNBMFA = OKMNFHNBMFA;
		aLFLAJEHLGB.HOLNKOFHDNK = HOLNKOFHDNK;
		aLFLAJEHLGB.AAPECJCHKKM = AAPECJCHKKM;
		aLFLAJEHLGB.PBJNILGEMJB = PBJNILGEMJB;
		aLFLAJEHLGB.OBOKEHFKGOK = OBOKEHFKGOK;
		aLFLAJEHLGB.JAGBOPMGIAA = GuiElementSingle<ConfirmDialog>.instance;
		Singleton<GuiManager>.instance.InvokeAfter(aLFLAJEHLGB.JGHLGHMJJDG, 483f);
		return aLFLAJEHLGB.JAGBOPMGIAA;
	}

	public GuiElement DDIIHKEFFNA()
	{
		return this;
	}

	[SpecialName]
	public string AIICJDEAOHI()
	{
		return PGIAMMOAFKP.text;
	}

	[CompilerGenerated]
	private void DILEDJDLBGO(GameObject KHAHPAKDIKE)
	{
		if (base.isFullyShowed)
		{
			APIKLDFGKKC(KHAHPAKDIKE);
		}
	}

	public virtual void MEHAKDFBGJN()
	{
		Singleton<GameController>.instance.GameEnded += KPPNCJBMDPE;
	}

	[SpecialName]
	public void BFEAOGKLKNL(string IDEBKDPMPGM)
	{
		NNGGEEFLIPE.text = IDEBKDPMPGM;
		MEJMLNDFDBP.COCBCFKJOJE(NNGGEEFLIPE, 353f, 95f, 102);
	}

	public virtual void OOKMKGPKAHB()
	{
		Singleton<GameController>.instance.CNPGMMPAGIE(GPJMBPPHCOF);
	}

	private void APIKLDFGKKC(GameObject KHAHPAKDIKE)
	{
		if (base.isFullyShowed)
		{
			HideDialog();
			DIPGLDIGFNF = 0;
			if (AOGFDHEMCCM != null)
			{
				AOGFDHEMCCM(this, arg2: true);
				AOGFDHEMCCM = null;
			}
		}
	}

	[SpecialName]
	public void KAJABOGHPKJ(string IDEBKDPMPGM)
	{
		LLILKCJKNPH.text = IDEBKDPMPGM;
	}

	[SpecialName]
	public string JJIMFMMAIHF()
	{
		return DEHKFKDHMJD.text;
	}

	[SpecialName]
	public void LGFDEJJDCNO(string IDEBKDPMPGM)
	{
		FBOBOOKDJLO.text = IDEBKDPMPGM;
	}

	public virtual void BGINCGHHKOA()
	{
		base.NEEAKMELPBJ();
		UIDraggablePanel.panelDisabled = false;
	}

	public static ConfirmDialog HMBAPGGLPLC(string OKMNFHNBMFA, string HOLNKOFHDNK, Action<ConfirmDialog, bool> AAPECJCHKKM, float KALLNCAFIMP = 0f)
	{
		JJJOBNJJBCL jJJOBNJJBCL = new JJJOBNJJBCL();
		jJJOBNJJBCL.OKMNFHNBMFA = OKMNFHNBMFA;
		jJJOBNJJBCL.HOLNKOFHDNK = HOLNKOFHDNK;
		jJJOBNJJBCL.AAPECJCHKKM = AAPECJCHKKM;
		jJJOBNJJBCL.JAGBOPMGIAA = GuiElementSingle<ConfirmDialog>.instance;
		Singleton<GuiManager>.instance.InvokeAfter(jJJOBNJJBCL.LJCDGJKCNEC, KALLNCAFIMP);
		return jJJOBNJJBCL.JAGBOPMGIAA;
	}

	private void JNLEHBAHMNG(GameObject KHAHPAKDIKE)
	{
		if (BKIGLABDGCP())
		{
			HideDialog();
			DIPGLDIGFNF = 1;
			if (AOGFDHEMCCM != null)
			{
				AOGFDHEMCCM(this, arg2: true);
				AOGFDHEMCCM = null;
			}
		}
	}

	private void LHHLHOLCGAI(GameObject KHAHPAKDIKE)
	{
		if (BJNBLINDAED())
		{
			HideDialog();
			DIPGLDIGFNF = 0;
			if (AOGFDHEMCCM != null)
			{
				AOGFDHEMCCM(this, arg2: false);
				AOGFDHEMCCM = null;
			}
		}
	}

	private void ODINNCBLBOF()
	{
		DKMOGJHFEJC(Localization.Localize("T"));
		cancelButtonText = Localization.Localize("test_attribute5");
		LLILKCJKNPH.gameObject.SetActive(value: false);
		DDLOCLPOFAK.gameObject.SetActive(value: true);
		JLEFFOGPFGE.gameObject.SetActive(value: true);
		KGPGCCPMCIG.gameObject.SetActive(value: false);
		DCIKANJJFIJ = 908f;
		HECFOEMLJCD = 987f;
		UIEventListener.Get(JFCNMPHDKHC.gameObject).onClick = null;
	}

	private void CCODCIHBPPK(GameObject KHAHPAKDIKE)
	{
		if (LHDGJFHPJNM())
		{
			HideDialog();
			DIPGLDIGFNF = 0;
			if (AOGFDHEMCCM != null)
			{
				AOGFDHEMCCM(this, arg2: false);
				AOGFDHEMCCM = null;
			}
		}
	}

	private void MEAOHNMFLIG()
	{
		UIEventListener uIEventListener = UIEventListener.Get(JFCNMPHDKHC.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(AAMAAJOFDLI));
	}

	private void MGGGIBOAIGC(GameObject KHAHPAKDIKE)
	{
		if (base.isFullyShowed)
		{
			HideDialog();
			DIPGLDIGFNF = 0;
			if (AOGFDHEMCCM != null)
			{
				AOGFDHEMCCM(this, arg2: false);
				AOGFDHEMCCM = null;
			}
		}
	}

	private void PFJJBPFIJEF(GameController.HKGHCIEPGEL IOJHEOBIIPE)
	{
		if (NPFFMLLLDAF())
		{
			EGJBBJMJBHO();
		}
	}

	internal static ConfirmDialog IGCMBKLNIDB(string OKMNFHNBMFA, string HOLNKOFHDNK, Action<ConfirmDialog, bool> AAPECJCHKKM, string PBJNILGEMJB, string OBOKEHFKGOK)
	{
		ALFLAJEHLGB aLFLAJEHLGB = new ALFLAJEHLGB();
		aLFLAJEHLGB.OKMNFHNBMFA = OKMNFHNBMFA;
		aLFLAJEHLGB.HOLNKOFHDNK = HOLNKOFHDNK;
		aLFLAJEHLGB.AAPECJCHKKM = AAPECJCHKKM;
		aLFLAJEHLGB.PBJNILGEMJB = PBJNILGEMJB;
		aLFLAJEHLGB.OBOKEHFKGOK = OBOKEHFKGOK;
		aLFLAJEHLGB.JAGBOPMGIAA = GuiElementSingle<ConfirmDialog>.instance;
		Singleton<GuiManager>.instance.InvokeAfter(aLFLAJEHLGB.LJCDGJKCNEC, 0f);
		return aLFLAJEHLGB.JAGBOPMGIAA;
	}

	[SpecialName]
	public void AFEKOKJOAJP(Action<ConfirmDialog, bool> IDEBKDPMPGM)
	{
		Action<ConfirmDialog, bool> action = KDECHIPDDGK;
		Action<ConfirmDialog, bool> action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref KDECHIPDDGK, (Action<ConfirmDialog, bool>)Delegate.Remove(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	public static void ShowAlert(Action<ConfirmDialog, bool> AAPECJCHKKM, string OKMNFHNBMFA, string HOLNKOFHDNK)
	{
		ConfirmDialog confirmDialog = GuiElementSingle<ConfirmDialog>.instance;
		confirmDialog.Reset();
		confirmDialog.setTitle = OKMNFHNBMFA;
		confirmDialog.setText = HOLNKOFHDNK;
		confirmDialog.AOGFDHEMCCM = null;
		confirmDialog.DCIKANJJFIJ = 0.2f;
		confirmDialog.HECFOEMLJCD = 0.2f;
		confirmDialog.LLILKCJKNPH.gameObject.SetActive(value: true);
		confirmDialog.DDLOCLPOFAK.gameObject.SetActive(value: false);
		confirmDialog.JLEFFOGPFGE.gameObject.SetActive(value: false);
		confirmDialog.KGPGCCPMCIG.gameObject.SetActive(value: true);
		confirmDialog.okButtonText = Localization.Localize("ID_OK");
		confirmDialog.BBEPNPELGHK();
		if (AAPECJCHKKM != null)
		{
			confirmDialog.AOGFDHEMCCM = AAPECJCHKKM;
		}
		confirmDialog.DIPGLDIGFNF++;
		Singleton<GuiManager>.instance.ShowDialog(confirmDialog);
	}

	public virtual void MOCIFAAJDAA()
	{
		base.DoAfterHide();
		PAODBOEOFNF();
		if (KDECHIPDDGK != null)
		{
			KDECHIPDDGK(this, arg2: false);
		}
	}

	public virtual void DNAKHMCEBHK()
	{
		base.OIMKKAHOEKO();
		ODACICLOMHJ();
		if (KDECHIPDDGK != null)
		{
			KDECHIPDDGK(this, arg2: true);
		}
	}

	public static ConfirmDialog LGANINAGPLB(string OKMNFHNBMFA, string HOLNKOFHDNK, Action<ConfirmDialog, bool> AAPECJCHKKM, float KALLNCAFIMP = 0f)
	{
		JJJOBNJJBCL jJJOBNJJBCL = new JJJOBNJJBCL();
		jJJOBNJJBCL.OKMNFHNBMFA = OKMNFHNBMFA;
		jJJOBNJJBCL.HOLNKOFHDNK = HOLNKOFHDNK;
		jJJOBNJJBCL.AAPECJCHKKM = AAPECJCHKKM;
		jJJOBNJJBCL.JAGBOPMGIAA = GuiElementSingle<ConfirmDialog>.instance;
		Singleton<GuiManager>.instance.InvokeAfter(jJJOBNJJBCL.MMEEJDGGAID, KALLNCAFIMP);
		return jJJOBNJJBCL.JAGBOPMGIAA;
	}

	[SpecialName]
	public string BDBDLNNLOFB()
	{
		return DEHKFKDHMJD.text;
	}

	private void HPDNOOLDGKO(GameObject KHAHPAKDIKE)
	{
		if (base.isFullyShowed)
		{
			CCODCIHBPPK(KHAHPAKDIKE);
		}
	}

	public override void DoBeforeHide()
	{
		base.DoBeforeHide();
		UIDraggablePanel.panelDisabled = false;
	}

	[SpecialName]
	public string GOIFJCHNGOA()
	{
		return FBOBOOKDJLO.text;
	}

	public static ConfirmDialog NMLMDFGOHDC(string OKMNFHNBMFA, string HOLNKOFHDNK, Action<ConfirmDialog, bool> AAPECJCHKKM, float KALLNCAFIMP = 0f)
	{
		JJJOBNJJBCL jJJOBNJJBCL = new JJJOBNJJBCL();
		jJJOBNJJBCL.OKMNFHNBMFA = OKMNFHNBMFA;
		jJJOBNJJBCL.HOLNKOFHDNK = HOLNKOFHDNK;
		jJJOBNJJBCL.AAPECJCHKKM = AAPECJCHKKM;
		jJJOBNJJBCL.JAGBOPMGIAA = GuiElementSingle<ConfirmDialog>.instance;
		Singleton<GuiManager>.instance.InvokeAfter(jJJOBNJJBCL.LJCDGJKCNEC, KALLNCAFIMP);
		return jJJOBNJJBCL.JAGBOPMGIAA;
	}

	private void ODACICLOMHJ()
	{
		yesButtonText = Localization.Localize("{0}S");
		PFKFBLFFGIG(Localization.Localize("creating special pack: "));
		LLILKCJKNPH.gameObject.SetActive(value: true);
		DDLOCLPOFAK.gameObject.SetActive(value: true);
		JLEFFOGPFGE.gameObject.SetActive(value: false);
		KGPGCCPMCIG.gameObject.SetActive(value: true);
		DCIKANJJFIJ = 1824f;
		HECFOEMLJCD = 481f;
		UIEventListener.Get(JFCNMPHDKHC.gameObject).onClick = null;
	}

	public virtual void PCPECKOBBLN()
	{
		base.DoBeforeShowUp();
		if (KDECHIPDDGK != null)
		{
			KDECHIPDDGK(this, arg2: true);
		}
		UIDraggablePanel.panelDisabled = false;
	}

	private void BBCDAFKNCEK(GameObject KHAHPAKDIKE)
	{
		if (BKIGLABDGCP())
		{
			HJKICFELPGI(KHAHPAKDIKE);
		}
	}

	public virtual void BHMEOLBNLKF()
	{
		if (JLEFFOGPFGE.gameObject.activeSelf)
		{
			MGGGIBOAIGC(JLEFFOGPFGE.gameObject);
		}
		else if (KGPGCCPMCIG.gameObject.activeSelf)
		{
			CCODCIHBPPK(KGPGCCPMCIG.gameObject);
		}
		else if (DDLOCLPOFAK.gameObject.activeSelf)
		{
			LHHLHOLCGAI(DDLOCLPOFAK.gameObject);
		}
	}

	[SpecialName]
	public void BGAPAKNBEOB(string IDEBKDPMPGM)
	{
		PGIAMMOAFKP.text = IDEBKDPMPGM;
	}

	private void FCEMAPLNEDK()
	{
		UIEventListener uIEventListener = UIEventListener.Get(JFCNMPHDKHC.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(LNHPEGFOLFF));
	}

	[SpecialName]
	public void IDMODDBILNA(string IDEBKDPMPGM)
	{
		NNGGEEFLIPE.text = IDEBKDPMPGM;
		MEJMLNDFDBP.COCBCFKJOJE(NNGGEEFLIPE, 431f, 54f, -60);
	}

	internal static ConfirmDialog IIMPPFLJOHA(string OKMNFHNBMFA, string HOLNKOFHDNK, Action<ConfirmDialog, bool> AAPECJCHKKM, string PBJNILGEMJB, string OBOKEHFKGOK)
	{
		ALFLAJEHLGB aLFLAJEHLGB = new ALFLAJEHLGB();
		aLFLAJEHLGB.OKMNFHNBMFA = OKMNFHNBMFA;
		aLFLAJEHLGB.HOLNKOFHDNK = HOLNKOFHDNK;
		aLFLAJEHLGB.AAPECJCHKKM = AAPECJCHKKM;
		aLFLAJEHLGB.PBJNILGEMJB = PBJNILGEMJB;
		aLFLAJEHLGB.OBOKEHFKGOK = OBOKEHFKGOK;
		aLFLAJEHLGB.JAGBOPMGIAA = GuiElementSingle<ConfirmDialog>.instance;
		Singleton<GuiManager>.instance.InvokeAfter(aLFLAJEHLGB.OKNCFDMEFGJ, 1797f);
		return aLFLAJEHLGB.JAGBOPMGIAA;
	}

	private void BMAHDFDKPLL(GameObject KHAHPAKDIKE)
	{
		if (AFOFDNJOJHG())
		{
			CCODCIHBPPK(KHAHPAKDIKE);
		}
	}

	public static ConfirmDialog ShowConfirm(string OKMNFHNBMFA, string HOLNKOFHDNK, Action<ConfirmDialog, bool> AAPECJCHKKM, float KALLNCAFIMP = 0f)
	{
		JJJOBNJJBCL jJJOBNJJBCL = new JJJOBNJJBCL();
		jJJOBNJJBCL.OKMNFHNBMFA = OKMNFHNBMFA;
		jJJOBNJJBCL.HOLNKOFHDNK = HOLNKOFHDNK;
		jJJOBNJJBCL.AAPECJCHKKM = AAPECJCHKKM;
		jJJOBNJJBCL.JAGBOPMGIAA = GuiElementSingle<ConfirmDialog>.instance;
		Singleton<GuiManager>.instance.InvokeAfter(jJJOBNJJBCL.LJCDGJKCNEC, KALLNCAFIMP);
		return jJJOBNJJBCL.JAGBOPMGIAA;
	}

	public override void InitGUIValues()
	{
	}

	public static ConfirmDialog KDAEFLFPBMN(string OKMNFHNBMFA, string HOLNKOFHDNK, float KALLNCAFIMP = 0f)
	{
		CGECFHFDEEH cGECFHFDEEH = new CGECFHFDEEH();
		cGECFHFDEEH.OKMNFHNBMFA = OKMNFHNBMFA;
		cGECFHFDEEH.HOLNKOFHDNK = HOLNKOFHDNK;
		cGECFHFDEEH.JAGBOPMGIAA = GuiElementSingle<ConfirmDialog>.instance;
		Singleton<GuiManager>.instance.InvokeAfter(cGECFHFDEEH.LJCDGJKCNEC, KALLNCAFIMP);
		return cGECFHFDEEH.JAGBOPMGIAA;
	}

	public static void HLAPENBALCJ()
	{
		UnityEngine.Debug.Log("game-card-ico-healingstorm");
		if (GuiElementSingle<ConfirmDialog>.instance.isShowed)
		{
			GuiElementSingle<ConfirmDialog>.instance.HideDialog();
		}
		GuiElementSingle<ConfirmDialog>.instance.AOGFDHEMCCM = null;
	}

	private void LGCKODOHHIA()
	{
		yesButtonText = Localization.Localize("Animation from State: Ready to State: None");
		PFKFBLFFGIG(Localization.Localize("setFacebookEventLogging"));
		LLILKCJKNPH.gameObject.SetActive(value: false);
		DDLOCLPOFAK.gameObject.SetActive(value: true);
		JLEFFOGPFGE.gameObject.SetActive(value: false);
		KGPGCCPMCIG.gameObject.SetActive(value: true);
		DCIKANJJFIJ = 595f;
		HECFOEMLJCD = 1066f;
		UIEventListener.Get(JFCNMPHDKHC.gameObject).onClick = null;
	}

	[SpecialName]
	public void EMBMFBLKBDF(Action<ConfirmDialog, bool> IDEBKDPMPGM)
	{
		Action<ConfirmDialog, bool> action = KDECHIPDDGK;
		Action<ConfirmDialog, bool> action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref KDECHIPDDGK, (Action<ConfirmDialog, bool>)Delegate.Remove(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	private void KPPNCJBMDPE(GameController.HKGHCIEPGEL IOJHEOBIIPE)
	{
		if (isShowed)
		{
			Hide();
		}
	}

	protected virtual void JFDOGLFMHAE()
	{
		IABJJOPLKFF();
		UIEventListener uIEventListener = UIEventListener.Get(DDLOCLPOFAK.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(HJKICFELPGI));
		UIEventListener uIEventListener2 = UIEventListener.Get(JLEFFOGPFGE.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(MGGGIBOAIGC));
		UIEventListener uIEventListener3 = UIEventListener.Get(KGPGCCPMCIG.gameObject);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener3.onClick, new UIEventListener.VoidDelegate(HJKICFELPGI));
	}

	private void OECNONFDJCN(GameObject KHAHPAKDIKE)
	{
		if (BJNBLINDAED())
		{
			APIKLDFGKKC(KHAHPAKDIKE);
		}
	}

	public static void LGAJCFGJMBC(Action<ConfirmDialog, bool> AAPECJCHKKM, string OKMNFHNBMFA, string HOLNKOFHDNK)
	{
		ConfirmDialog confirmDialog = GuiElementSingle<ConfirmDialog>.instance;
		confirmDialog.IMFLNKIMEFA();
		confirmDialog.IDMODDBILNA(OKMNFHNBMFA);
		confirmDialog.BPHECKCEEOJ(HOLNKOFHDNK);
		confirmDialog.AOGFDHEMCCM = null;
		confirmDialog.DCIKANJJFIJ = 110f;
		confirmDialog.HECFOEMLJCD = 984f;
		confirmDialog.LLILKCJKNPH.gameObject.SetActive(value: true);
		confirmDialog.DDLOCLPOFAK.gameObject.SetActive(value: true);
		confirmDialog.JLEFFOGPFGE.gameObject.SetActive(value: false);
		confirmDialog.KGPGCCPMCIG.gameObject.SetActive(value: true);
		confirmDialog.KEDEMNPLNPB(Localization.Localize("N"));
		confirmDialog.KKOJEBNCJMI();
		if (AAPECJCHKKM != null)
		{
			confirmDialog.AOGFDHEMCCM = AAPECJCHKKM;
		}
		confirmDialog.DIPGLDIGFNF++;
		Singleton<GuiManager>.instance.ShowDialog(confirmDialog, 764f);
	}

	[SpecialName]
	public void LGJHIBNOFJF(string IDEBKDPMPGM)
	{
		LLILKCJKNPH.text = IDEBKDPMPGM;
	}

	public virtual void FAHPIINNMBB()
	{
		Singleton<GameController>.instance.CNPGMMPAGIE(GPJMBPPHCOF);
	}

	public virtual void ABCGFBHKHEC()
	{
		base.DoBeforeHide();
		UIDraggablePanel.panelDisabled = false;
	}

	public static void LHIBGDFMEMD(Action<ConfirmDialog, bool> AAPECJCHKKM, string OKMNFHNBMFA, string HOLNKOFHDNK)
	{
		ConfirmDialog confirmDialog = GuiElementSingle<ConfirmDialog>.instance;
		confirmDialog.OGBOHCPHGMK();
		confirmDialog.IDMODDBILNA(OKMNFHNBMFA);
		confirmDialog.BPHECKCEEOJ(HOLNKOFHDNK);
		confirmDialog.AOGFDHEMCCM = null;
		confirmDialog.DCIKANJJFIJ = 133f;
		confirmDialog.HECFOEMLJCD = 939f;
		confirmDialog.LLILKCJKNPH.gameObject.SetActive(value: false);
		confirmDialog.DDLOCLPOFAK.gameObject.SetActive(value: false);
		confirmDialog.JLEFFOGPFGE.gameObject.SetActive(value: false);
		confirmDialog.KGPGCCPMCIG.gameObject.SetActive(value: true);
		confirmDialog.KEDEMNPLNPB(Localization.Localize("ProductId"));
		confirmDialog.MEAOHNMFLIG();
		if (AAPECJCHKKM != null)
		{
			confirmDialog.AOGFDHEMCCM = AAPECJCHKKM;
		}
		confirmDialog.DIPGLDIGFNF++;
		Singleton<GuiManager>.instance.ShowDialog(confirmDialog, 1356f);
	}

	private void MAFBPNENGJO(GameObject KHAHPAKDIKE)
	{
		if (MHAIBHBGBOO())
		{
			HideDialog();
			DIPGLDIGFNF = 1;
			if (AOGFDHEMCCM != null)
			{
				AOGFDHEMCCM(this, arg2: true);
				AOGFDHEMCCM = null;
			}
		}
	}

	[SpecialName]
	public string OCADJJBMOAA()
	{
		return DEHKFKDHMJD.text;
	}

	public static void IGGCEILJEFM(Action<ConfirmDialog, bool> AAPECJCHKKM, string OKMNFHNBMFA, string HOLNKOFHDNK)
	{
		ConfirmDialog confirmDialog = GuiElementSingle<ConfirmDialog>.instance;
		confirmDialog.IMFLNKIMEFA();
		confirmDialog.setTitle = OKMNFHNBMFA;
		confirmDialog.OEIKKBIPHFB(HOLNKOFHDNK);
		confirmDialog.AOGFDHEMCCM = null;
		confirmDialog.DCIKANJJFIJ = 162f;
		confirmDialog.HECFOEMLJCD = 683f;
		confirmDialog.LLILKCJKNPH.gameObject.SetActive(value: true);
		confirmDialog.DDLOCLPOFAK.gameObject.SetActive(value: false);
		confirmDialog.JLEFFOGPFGE.gameObject.SetActive(value: false);
		confirmDialog.KGPGCCPMCIG.gameObject.SetActive(value: true);
		confirmDialog.HKOCPBFCCGJ(Localization.Localize("()F"));
		confirmDialog.MEAOHNMFLIG();
		if (AAPECJCHKKM != null)
		{
			confirmDialog.AOGFDHEMCCM = AAPECJCHKKM;
		}
		confirmDialog.DIPGLDIGFNF++;
		Singleton<GuiManager>.instance.ShowDialog(confirmDialog, 1370f);
	}

	public override void OnBack()
	{
		if (JLEFFOGPFGE.gameObject.activeSelf)
		{
			MGGGIBOAIGC(JLEFFOGPFGE.gameObject);
		}
		else if (KGPGCCPMCIG.gameObject.activeSelf)
		{
			APIKLDFGKKC(KGPGCCPMCIG.gameObject);
		}
		else if (DDLOCLPOFAK.gameObject.activeSelf)
		{
			APIKLDFGKKC(DDLOCLPOFAK.gameObject);
		}
	}

	public static ConfirmDialog BMBPFNKJHMF(string OKMNFHNBMFA, string HOLNKOFHDNK, Action<ConfirmDialog, bool> AAPECJCHKKM, float KALLNCAFIMP = 0f)
	{
		JJJOBNJJBCL jJJOBNJJBCL = new JJJOBNJJBCL();
		jJJOBNJJBCL.OKMNFHNBMFA = OKMNFHNBMFA;
		jJJOBNJJBCL.HOLNKOFHDNK = HOLNKOFHDNK;
		jJJOBNJJBCL.AAPECJCHKKM = AAPECJCHKKM;
		jJJOBNJJBCL.JAGBOPMGIAA = GuiElementSingle<ConfirmDialog>.instance;
		Singleton<GuiManager>.instance.InvokeAfter(jJJOBNJJBCL.OKNCFDMEFGJ, KALLNCAFIMP);
		return jJJOBNJJBCL.JAGBOPMGIAA;
	}

	public static void IAHFKGJBNNJ()
	{
		UnityEngine.Debug.Log("DepositedCards");
		if (GuiElementSingle<ConfirmDialog>.instance.NPFFMLLLDAF())
		{
			GuiElementSingle<ConfirmDialog>.instance.HideDialog();
		}
		GuiElementSingle<ConfirmDialog>.instance.AOGFDHEMCCM = null;
	}

	[SpecialName]
	public string LGOLHOOMCNF()
	{
		return FBOBOOKDJLO.text;
	}

	public GuiElement CBANDKHPNBD()
	{
		return this;
	}

	[SpecialName]
	public void PFKFBLFFGIG(string IDEBKDPMPGM)
	{
		FBOBOOKDJLO.text = IDEBKDPMPGM;
	}

	public static void NFECLPLEOBN(Action<ConfirmDialog, bool> AAPECJCHKKM, string OKMNFHNBMFA, string HOLNKOFHDNK)
	{
		ConfirmDialog confirmDialog = GuiElementSingle<ConfirmDialog>.instance;
		confirmDialog.Reset();
		confirmDialog.setTitle = OKMNFHNBMFA;
		confirmDialog.setText = HOLNKOFHDNK;
		confirmDialog.AOGFDHEMCCM = null;
		confirmDialog.DCIKANJJFIJ = 1074f;
		confirmDialog.HECFOEMLJCD = 541f;
		confirmDialog.LLILKCJKNPH.gameObject.SetActive(value: false);
		confirmDialog.DDLOCLPOFAK.gameObject.SetActive(value: false);
		confirmDialog.JLEFFOGPFGE.gameObject.SetActive(value: true);
		confirmDialog.KGPGCCPMCIG.gameObject.SetActive(value: false);
		confirmDialog.BEPOMIGEECE(Localization.Localize("sc"));
		confirmDialog.BBEPNPELGHK();
		if (AAPECJCHKKM != null)
		{
			confirmDialog.AOGFDHEMCCM = AAPECJCHKKM;
		}
		confirmDialog.DIPGLDIGFNF += 0;
		Singleton<GuiManager>.instance.ShowDialog(confirmDialog, 566f);
	}

	[SpecialName]
	public string JHCOEPFGJNJ()
	{
		return FBOBOOKDJLO.text;
	}

	private void NMEJKACLHKJ()
	{
		yesButtonText = Localization.Localize("WelcomeBackSoldierMessage {0} {1}");
		LGFDEJJDCNO(Localization.Localize("ID_SLOTUPGRADE_POWER"));
		LLILKCJKNPH.gameObject.SetActive(value: true);
		DDLOCLPOFAK.gameObject.SetActive(value: true);
		JLEFFOGPFGE.gameObject.SetActive(value: false);
		KGPGCCPMCIG.gameObject.SetActive(value: false);
		DCIKANJJFIJ = 1959f;
		HECFOEMLJCD = 1562f;
		UIEventListener.Get(JFCNMPHDKHC.gameObject).onClick = null;
	}

	public virtual void JCEMKGHAHNE()
	{
		Singleton<GameController>.instance.CNPGMMPAGIE(PFJJBPFIJEF);
	}

	public virtual void LMPJGKNACOB()
	{
		base.MOOACPIOELI();
		UIDraggablePanel.panelDisabled = true;
	}

	public virtual void OMPIPMMNMDA()
	{
		base.DoBeforeShowUp();
		if (KDECHIPDDGK != null)
		{
			KDECHIPDDGK(this, arg2: false);
		}
		UIDraggablePanel.panelDisabled = false;
	}

	private void LNHPEGFOLFF(GameObject KHAHPAKDIKE)
	{
		if (MHAIBHBGBOO())
		{
			LHHLHOLCGAI(KHAHPAKDIKE);
		}
	}

	private void AAMAAJOFDLI(GameObject KHAHPAKDIKE)
	{
		if (base.isFullyShowed)
		{
			LHHLHOLCGAI(KHAHPAKDIKE);
		}
	}

	[SpecialName]
	public void BPHECKCEEOJ(string IDEBKDPMPGM)
	{
		LLILKCJKNPH.text = IDEBKDPMPGM;
	}

	public static void CGHPOPGKAGN(Action<ConfirmDialog, bool> AAPECJCHKKM, string OKMNFHNBMFA, string HOLNKOFHDNK)
	{
		ConfirmDialog confirmDialog = GuiElementSingle<ConfirmDialog>.instance;
		confirmDialog.PPAIIDFNIDL();
		confirmDialog.setTitle = OKMNFHNBMFA;
		confirmDialog.OEIKKBIPHFB(HOLNKOFHDNK);
		confirmDialog.AOGFDHEMCCM = null;
		confirmDialog.DCIKANJJFIJ = 1150f;
		confirmDialog.HECFOEMLJCD = 1838f;
		confirmDialog.LLILKCJKNPH.gameObject.SetActive(value: true);
		confirmDialog.DDLOCLPOFAK.gameObject.SetActive(value: true);
		confirmDialog.JLEFFOGPFGE.gameObject.SetActive(value: false);
		confirmDialog.KGPGCCPMCIG.gameObject.SetActive(value: false);
		confirmDialog.HKOCPBFCCGJ(Localization.Localize("ID_GETFREEGOLD"));
		confirmDialog.KKOJEBNCJMI();
		if (AAPECJCHKKM != null)
		{
			confirmDialog.AOGFDHEMCCM = AAPECJCHKKM;
		}
		confirmDialog.DIPGLDIGFNF++;
		Singleton<GuiManager>.instance.ShowDialog(confirmDialog, 1814f);
	}

	[SpecialName]
	public string PCBACACDLCI()
	{
		return PGIAMMOAFKP.text;
	}

	protected virtual void BLFKABLENCH()
	{
		FGOAPPLNMKL();
		UIEventListener uIEventListener = UIEventListener.Get(DDLOCLPOFAK.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(HJKICFELPGI));
		UIEventListener uIEventListener2 = UIEventListener.Get(JLEFFOGPFGE.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(LKOCICNLOPG));
		UIEventListener uIEventListener3 = UIEventListener.Get(KGPGCCPMCIG.gameObject);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener3.onClick, new UIEventListener.VoidDelegate(HJKICFELPGI));
	}

	public virtual void FECEKCGMIMK()
	{
		base.DoAfterHide();
		PAODBOEOFNF();
		if (KDECHIPDDGK != null)
		{
			KDECHIPDDGK(this, arg2: false);
		}
	}

	public virtual void NGHAPNEFBED()
	{
	}

	[SpecialName]
	public string IKCODADDLFN()
	{
		return PGIAMMOAFKP.text;
	}

	[SpecialName]
	public void KEDEMNPLNPB(string IDEBKDPMPGM)
	{
		PGIAMMOAFKP.text = IDEBKDPMPGM;
	}

	public virtual void FBDMBKKDEDC()
	{
	}

	protected virtual void KALEMFKOGLE()
	{
		IABJJOPLKFF();
		UIEventListener uIEventListener = UIEventListener.Get(DDLOCLPOFAK.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(ONKFIIPPHCC));
		UIEventListener uIEventListener2 = UIEventListener.Get(JLEFFOGPFGE.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(DBMIKLLNLEA));
		UIEventListener uIEventListener3 = UIEventListener.Get(KGPGCCPMCIG.gameObject);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener3.onClick, new UIEventListener.VoidDelegate(LHHLHOLCGAI));
	}

	public static void MFLKCNBINBM()
	{
		UnityEngine.Debug.Log("attrValue15");
		if (GuiElementSingle<ConfirmDialog>.instance.isShowed)
		{
			GuiElementSingle<ConfirmDialog>.instance.HideDialog();
		}
		GuiElementSingle<ConfirmDialog>.instance.AOGFDHEMCCM = null;
	}

	public static ConfirmDialog JDEDLDGMHBJ(string OKMNFHNBMFA, string HOLNKOFHDNK, float KALLNCAFIMP = 0f)
	{
		CGECFHFDEEH cGECFHFDEEH = new CGECFHFDEEH();
		cGECFHFDEEH.OKMNFHNBMFA = OKMNFHNBMFA;
		cGECFHFDEEH.HOLNKOFHDNK = HOLNKOFHDNK;
		cGECFHFDEEH.JAGBOPMGIAA = GuiElementSingle<ConfirmDialog>.instance;
		Singleton<GuiManager>.instance.InvokeAfter(cGECFHFDEEH.LJCDGJKCNEC, KALLNCAFIMP);
		return cGECFHFDEEH.JAGBOPMGIAA;
	}

	public GuiElement GetGuiElement()
	{
		return this;
	}

	[SpecialName]
	public void FGAINADMLCL(string IDEBKDPMPGM)
	{
		PGIAMMOAFKP.text = IDEBKDPMPGM;
	}

	public virtual void JCJECJKBKGD()
	{
	}

	[SpecialName]
	public string AEILNDMNAOG()
	{
		return DEHKFKDHMJD.text;
	}

	public static void FLFEOKMHDBN(Action<ConfirmDialog, bool> AAPECJCHKKM, string OKMNFHNBMFA, string HOLNKOFHDNK)
	{
		ConfirmDialog confirmDialog = GuiElementSingle<ConfirmDialog>.instance;
		confirmDialog.IMFLNKIMEFA();
		confirmDialog.IDMODDBILNA(OKMNFHNBMFA);
		confirmDialog.KAJABOGHPKJ(HOLNKOFHDNK);
		confirmDialog.AOGFDHEMCCM = null;
		confirmDialog.DCIKANJJFIJ = 1413f;
		confirmDialog.HECFOEMLJCD = 1074f;
		confirmDialog.LLILKCJKNPH.gameObject.SetActive(value: false);
		confirmDialog.DDLOCLPOFAK.gameObject.SetActive(value: false);
		confirmDialog.JLEFFOGPFGE.gameObject.SetActive(value: false);
		confirmDialog.KGPGCCPMCIG.gameObject.SetActive(value: true);
		confirmDialog.KEDEMNPLNPB(Localization.Localize("Card_2_Played"));
		confirmDialog.NBDEICBHHGF();
		if (AAPECJCHKKM != null)
		{
			confirmDialog.AOGFDHEMCCM = AAPECJCHKKM;
		}
		confirmDialog.DIPGLDIGFNF += 0;
		Singleton<GuiManager>.instance.ShowDialog(confirmDialog, 1502f);
	}

	[SpecialName]
	public string FMLJGCLHAFN()
	{
		return PGIAMMOAFKP.text;
	}

	[SpecialName]
	public string CHLJKNLPLOK()
	{
		return PGIAMMOAFKP.text;
	}

	public static ConfirmDialog HJHJKPGILAC(string OKMNFHNBMFA, string HOLNKOFHDNK, float KALLNCAFIMP = 0f)
	{
		CGECFHFDEEH cGECFHFDEEH = new CGECFHFDEEH();
		cGECFHFDEEH.OKMNFHNBMFA = OKMNFHNBMFA;
		cGECFHFDEEH.HOLNKOFHDNK = HOLNKOFHDNK;
		cGECFHFDEEH.JAGBOPMGIAA = GuiElementSingle<ConfirmDialog>.instance;
		Singleton<GuiManager>.instance.InvokeAfter(cGECFHFDEEH.NNIJEDKBPGJ, KALLNCAFIMP);
		return cGECFHFDEEH.JAGBOPMGIAA;
	}

	private void NBDEICBHHGF()
	{
		UIEventListener uIEventListener = UIEventListener.Get(JFCNMPHDKHC.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(BBCDAFKNCEK));
	}

	[SpecialName]
	public string IFOBMEBNPAJ()
	{
		return FBOBOOKDJLO.text;
	}

	private void PAODBOEOFNF()
	{
		DKMOGJHFEJC(Localization.Localize("getSpendProbability"));
		LGFDEJJDCNO(Localization.Localize("RecentVideos"));
		LLILKCJKNPH.gameObject.SetActive(value: true);
		DDLOCLPOFAK.gameObject.SetActive(value: false);
		JLEFFOGPFGE.gameObject.SetActive(value: false);
		KGPGCCPMCIG.gameObject.SetActive(value: true);
		DCIKANJJFIJ = 440f;
		HECFOEMLJCD = 222f;
		UIEventListener.Get(JFCNMPHDKHC.gameObject).onClick = null;
	}

	private void IMFLNKIMEFA()
	{
		DKMOGJHFEJC(Localization.Localize("getTotalSpendNext28Days"));
		PFKFBLFFGIG(Localization.Localize("{0} - {1}\n"));
		LLILKCJKNPH.gameObject.SetActive(value: true);
		DDLOCLPOFAK.gameObject.SetActive(value: false);
		JLEFFOGPFGE.gameObject.SetActive(value: false);
		KGPGCCPMCIG.gameObject.SetActive(value: false);
		DCIKANJJFIJ = 536f;
		HECFOEMLJCD = 961f;
		UIEventListener.Get(JFCNMPHDKHC.gameObject).onClick = null;
	}

	private void LKDICHHLACH(GameObject KHAHPAKDIKE)
	{
		if (AFOFDNJOJHG())
		{
			HJKICFELPGI(KHAHPAKDIKE);
		}
	}

	protected override void Awake()
	{
		base.Awake();
		UIEventListener uIEventListener = UIEventListener.Get(DDLOCLPOFAK.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(APIKLDFGKKC));
		UIEventListener uIEventListener2 = UIEventListener.Get(JLEFFOGPFGE.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(MGGGIBOAIGC));
		UIEventListener uIEventListener3 = UIEventListener.Get(KGPGCCPMCIG.gameObject);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener3.onClick, new UIEventListener.VoidDelegate(APIKLDFGKKC));
	}

	public static void Hide()
	{
		UnityEngine.Debug.Log("Hiding CONFIRM dialog");
		if (GuiElementSingle<ConfirmDialog>.instance.isShowed)
		{
			GuiElementSingle<ConfirmDialog>.instance.HideDialog();
		}
		GuiElementSingle<ConfirmDialog>.instance.AOGFDHEMCCM = null;
	}

	public virtual void IMEOAPEABLG()
	{
		Singleton<GameController>.instance.CNPGMMPAGIE(GPJMBPPHCOF);
	}

	[SpecialName]
	public void EAIEGNJODFL(string IDEBKDPMPGM)
	{
		PGIAMMOAFKP.text = IDEBKDPMPGM;
	}

	public static void LDPPNNMGNGI()
	{
		UnityEngine.Debug.Log("HEAD_EMPTY");
		if (GuiElementSingle<ConfirmDialog>.instance.isShowed)
		{
			GuiElementSingle<ConfirmDialog>.instance.HideDialog();
		}
		GuiElementSingle<ConfirmDialog>.instance.AOGFDHEMCCM = null;
	}

	public virtual void FAHMNNONMOJ()
	{
		base.DoBeforeShowUp();
		if (KDECHIPDDGK != null)
		{
			KDECHIPDDGK(this, arg2: true);
		}
		UIDraggablePanel.panelDisabled = false;
	}

	protected virtual void CIGLDDGDAPM()
	{
		ONBDJLDJDCH();
		UIEventListener uIEventListener = UIEventListener.Get(DDLOCLPOFAK.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(LHHLHOLCGAI));
		UIEventListener uIEventListener2 = UIEventListener.Get(JLEFFOGPFGE.gameObject);
		uIEventListener2.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener2.onClick, new UIEventListener.VoidDelegate(MAFBPNENGJO));
		UIEventListener uIEventListener3 = UIEventListener.Get(KGPGCCPMCIG.gameObject);
		uIEventListener3.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener3.onClick, new UIEventListener.VoidDelegate(ONKFIIPPHCC));
	}

	public static void ODJBILKIKMC(Action<ConfirmDialog, bool> AAPECJCHKKM, string OKMNFHNBMFA, string HOLNKOFHDNK)
	{
		ConfirmDialog confirmDialog = GuiElementSingle<ConfirmDialog>.instance;
		confirmDialog.ODACICLOMHJ();
		confirmDialog.setTitle = OKMNFHNBMFA;
		confirmDialog.KAJABOGHPKJ(HOLNKOFHDNK);
		confirmDialog.AOGFDHEMCCM = null;
		confirmDialog.DCIKANJJFIJ = 873f;
		confirmDialog.HECFOEMLJCD = 199f;
		confirmDialog.LLILKCJKNPH.gameObject.SetActive(value: true);
		confirmDialog.DDLOCLPOFAK.gameObject.SetActive(value: false);
		confirmDialog.JLEFFOGPFGE.gameObject.SetActive(value: false);
		confirmDialog.KGPGCCPMCIG.gameObject.SetActive(value: false);
		confirmDialog.FGAINADMLCL(Localization.Localize("bazooka_shoot_left"));
		confirmDialog.KKOJEBNCJMI();
		if (AAPECJCHKKM != null)
		{
			confirmDialog.AOGFDHEMCCM = AAPECJCHKKM;
		}
		confirmDialog.DIPGLDIGFNF += 0;
		Singleton<GuiManager>.instance.ShowDialog(confirmDialog, 1205f);
	}

	[SpecialName]
	public string LDFHIOHBOFD()
	{
		return DEHKFKDHMJD.text;
	}

	private void Reset()
	{
		yesButtonText = Localization.Localize("ID_YES");
		cancelButtonText = Localization.Localize("ID_NO");
		LLILKCJKNPH.gameObject.SetActive(value: true);
		DDLOCLPOFAK.gameObject.SetActive(value: true);
		JLEFFOGPFGE.gameObject.SetActive(value: true);
		KGPGCCPMCIG.gameObject.SetActive(value: false);
		DCIKANJJFIJ = 0.5f;
		HECFOEMLJCD = 0.5f;
		UIEventListener.Get(JFCNMPHDKHC.gameObject).onClick = null;
	}

	public static ConfirmDialog ShowAlert(string OKMNFHNBMFA, string HOLNKOFHDNK, float KALLNCAFIMP = 0f)
	{
		CGECFHFDEEH cGECFHFDEEH = new CGECFHFDEEH();
		cGECFHFDEEH.OKMNFHNBMFA = OKMNFHNBMFA;
		cGECFHFDEEH.HOLNKOFHDNK = HOLNKOFHDNK;
		cGECFHFDEEH.JAGBOPMGIAA = GuiElementSingle<ConfirmDialog>.instance;
		Singleton<GuiManager>.instance.InvokeAfter(cGECFHFDEEH.LJCDGJKCNEC, KALLNCAFIMP);
		return cGECFHFDEEH.JAGBOPMGIAA;
	}

	[SpecialName]
	public void DKMOGJHFEJC(string IDEBKDPMPGM)
	{
		DEHKFKDHMJD.text = IDEBKDPMPGM;
	}

	private void PPAIIDFNIDL()
	{
		yesButtonText = Localization.Localize("Google2u.AssaultRifle_AK47");
		cancelButtonText = Localization.Localize("deviceName");
		LLILKCJKNPH.gameObject.SetActive(value: true);
		DDLOCLPOFAK.gameObject.SetActive(value: false);
		JLEFFOGPFGE.gameObject.SetActive(value: false);
		KGPGCCPMCIG.gameObject.SetActive(value: true);
		DCIKANJJFIJ = 1356f;
		HECFOEMLJCD = 1689f;
		UIEventListener.Get(JFCNMPHDKHC.gameObject).onClick = null;
	}

	public virtual void BNEPKGCDIFH()
	{
	}

	[SpecialName]
	public void JPGGHPCFBKB(string IDEBKDPMPGM)
	{
		LLILKCJKNPH.text = IDEBKDPMPGM;
	}

	[SpecialName]
	public void GFEGACJEPFO(Action<ConfirmDialog, bool> IDEBKDPMPGM)
	{
		Action<ConfirmDialog, bool> action = KDECHIPDDGK;
		Action<ConfirmDialog, bool> action2;
		do
		{
			action2 = action;
			action = Interlocked.CompareExchange(ref KDECHIPDDGK, (Action<ConfirmDialog, bool>)Delegate.Remove(action2, IDEBKDPMPGM), action);
		}
		while ((object)action != action2);
	}

	public virtual void GIKPHOPPAOH()
	{
		base.DoBeforeHide();
		UIDraggablePanel.panelDisabled = false;
	}

	private void HJKICFELPGI(GameObject KHAHPAKDIKE)
	{
		if (BJNBLINDAED())
		{
			HideDialog();
			DIPGLDIGFNF = 0;
			if (AOGFDHEMCCM != null)
			{
				AOGFDHEMCCM(this, arg2: false);
				AOGFDHEMCCM = null;
			}
		}
	}

	private void LKOCICNLOPG(GameObject KHAHPAKDIKE)
	{
		if (base.isFullyShowed)
		{
			HideDialog();
			DIPGLDIGFNF = 1;
			if (AOGFDHEMCCM != null)
			{
				AOGFDHEMCCM(this, arg2: true);
				AOGFDHEMCCM = null;
			}
		}
	}

	private void OGBOHCPHGMK()
	{
		yesButtonText = Localization.Localize("Buy_Army_Unit_At_Rank_Gold");
		cancelButtonText = Localization.Localize(" AND ");
		LLILKCJKNPH.gameObject.SetActive(value: false);
		DDLOCLPOFAK.gameObject.SetActive(value: true);
		JLEFFOGPFGE.gameObject.SetActive(value: false);
		KGPGCCPMCIG.gameObject.SetActive(value: false);
		DCIKANJJFIJ = 539f;
		HECFOEMLJCD = 836f;
		UIEventListener.Get(JFCNMPHDKHC.gameObject).onClick = null;
	}

	private void KKOJEBNCJMI()
	{
		UIEventListener uIEventListener = UIEventListener.Get(JFCNMPHDKHC.gameObject);
		uIEventListener.onClick = (UIEventListener.VoidDelegate)Delegate.Combine(uIEventListener.onClick, new UIEventListener.VoidDelegate(BBCDAFKNCEK));
	}

	public virtual void FDOPNJGMOLF()
	{
		base.JNBMCODJHBJ();
		UIDraggablePanel.panelDisabled = false;
	}

	[SpecialName]
	public string LHEFNJFIOHK()
	{
		return DEHKFKDHMJD.text;
	}

	public virtual void LBHEIOEPJLJ()
	{
		Singleton<GameController>.instance.CNPGMMPAGIE(PFJJBPFIJEF);
	}

	internal static ConfirmDialog HJMPJBPHHMA(string OKMNFHNBMFA, string HOLNKOFHDNK, Action<ConfirmDialog, bool> AAPECJCHKKM, string PBJNILGEMJB, string OBOKEHFKGOK)
	{
		ALFLAJEHLGB aLFLAJEHLGB = new ALFLAJEHLGB();
		aLFLAJEHLGB.OKMNFHNBMFA = OKMNFHNBMFA;
		aLFLAJEHLGB.HOLNKOFHDNK = HOLNKOFHDNK;
		aLFLAJEHLGB.AAPECJCHKKM = AAPECJCHKKM;
		aLFLAJEHLGB.PBJNILGEMJB = PBJNILGEMJB;
		aLFLAJEHLGB.OBOKEHFKGOK = OBOKEHFKGOK;
		aLFLAJEHLGB.JAGBOPMGIAA = GuiElementSingle<ConfirmDialog>.instance;
		Singleton<GuiManager>.instance.InvokeAfter(aLFLAJEHLGB.NNFHNIMCBLH, 460f);
		return aLFLAJEHLGB.JAGBOPMGIAA;
	}

	[SpecialName]
	public string MOBMJKFPPGP()
	{
		return FBOBOOKDJLO.text;
	}
}
