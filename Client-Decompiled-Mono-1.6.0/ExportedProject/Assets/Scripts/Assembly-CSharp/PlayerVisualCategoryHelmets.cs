using System;
using UnityEngine;

public class PlayerVisualCategoryHelmets : PlayerVisualCategoryGeneric<PlayerVisualCategoryHelmets.PlayerVisualHelmet>
{
	[Serializable]
	public class PlayerVisualHelmet : PlayerVisualHead
	{
		public int hairIndex;

		public virtual void MKMBNMIGDJG(KMNCIJPDFPJ KHLGDCHJJPB, bool OGKCIFGLKJJ = false)
		{
			BMGPGCMNIGE(KHLGDCHJJPB, OGKCIFGLKJJ);
			KHLGDCHJJPB.meshChanger.AJKDDHHKBBO(this);
			if (Application.isPlaying)
			{
				KHLGDCHJJPB.equippedHelmet = this;
				CamoTransform value = null;
				string text = KHLGDCHJJPB.playerVisuals[1];
				if (text != null)
				{
					camoTransformDict.TryGetValue(text, out value);
				}
				CamoTransform.HMEAHLPOFNI(KHLGDCHJJPB.meshChanger.LJBKNMJBPEG.OKGBANFPPAF.meshFilter.gameObject, value);
				CamoTransform.HOFCJJODJHF(KHLGDCHJJPB.meshChanger.LJBKNMJBPEG.OJAPOOKMMPK.meshFilter.gameObject, value);
			}
		}

		public virtual void NOJKGKIIGFD(KMNCIJPDFPJ KHLGDCHJJPB, bool OGKCIFGLKJJ = false)
		{
			base.HGGLCMFPPIB(KHLGDCHJJPB, OGKCIFGLKJJ);
			KHLGDCHJJPB.meshChanger.ChangeHelmet(this);
			if (Application.isPlaying)
			{
				KHLGDCHJJPB.equippedHelmet = this;
				CamoTransform value = null;
				string text = KHLGDCHJJPB.playerVisuals[1];
				if (text != null)
				{
					camoTransformDict.TryGetValue(text, out value);
				}
				CamoTransform.FGMDLCLGDKG(KHLGDCHJJPB.meshChanger.LJBKNMJBPEG.OKGBANFPPAF.meshFilter.gameObject, value);
				CamoTransform.JFHEFPAHOPK(KHLGDCHJJPB.meshChanger.LJBKNMJBPEG.OJAPOOKMMPK.meshFilter.gameObject, value);
			}
		}

		public override void CMMJHCBJBMK(KMNCIJPDFPJ KHLGDCHJJPB, bool OGKCIFGLKJJ = false)
		{
			JFAEGFFIIKH(KHLGDCHJJPB, OGKCIFGLKJJ);
			KHLGDCHJJPB.meshChanger.OLEBJCPJELE(this);
			if (Application.isPlaying)
			{
				KHLGDCHJJPB.equippedHelmet = this;
				CamoTransform value = null;
				string text = KHLGDCHJJPB.playerVisuals[1];
				if (text != null)
				{
					camoTransformDict.TryGetValue(text, out value);
				}
				CamoTransform.HOFCJJODJHF(KHLGDCHJJPB.meshChanger.LJBKNMJBPEG.OKGBANFPPAF.meshFilter.gameObject, value);
				CamoTransform.CFOMMPPEGDE(KHLGDCHJJPB.meshChanger.LJBKNMJBPEG.OJAPOOKMMPK.meshFilter.gameObject, value);
			}
		}

		public virtual void IOJPMAJOHNN(KMNCIJPDFPJ KHLGDCHJJPB, bool OGKCIFGLKJJ = false)
		{
			BMGPGCMNIGE(KHLGDCHJJPB, OGKCIFGLKJJ);
			KHLGDCHJJPB.meshChanger.OLEBJCPJELE(this);
			if (Application.isPlaying)
			{
				KHLGDCHJJPB.equippedHelmet = this;
				CamoTransform value = null;
				string text = KHLGDCHJJPB.playerVisuals[0];
				if (text != null)
				{
					camoTransformDict.TryGetValue(text, out value);
				}
				CamoTransform.MAJAFLLCBKG(KHLGDCHJJPB.meshChanger.LJBKNMJBPEG.OKGBANFPPAF.meshFilter.gameObject, value);
				CamoTransform.HMEAHLPOFNI(KHLGDCHJJPB.meshChanger.LJBKNMJBPEG.OJAPOOKMMPK.meshFilter.gameObject, value);
			}
		}

		public virtual void NADANFOFKPE(KMNCIJPDFPJ KHLGDCHJJPB, bool OGKCIFGLKJJ = false)
		{
			base.CMMJHCBJBMK(KHLGDCHJJPB, OGKCIFGLKJJ);
			KHLGDCHJJPB.meshChanger.ChangeHelmet(this);
			if (Application.isPlaying)
			{
				KHLGDCHJJPB.equippedHelmet = this;
				CamoTransform value = null;
				string text = KHLGDCHJJPB.playerVisuals[0];
				if (text != null)
				{
					camoTransformDict.TryGetValue(text, out value);
				}
				CamoTransform.CFOMMPPEGDE(KHLGDCHJJPB.meshChanger.LJBKNMJBPEG.OKGBANFPPAF.meshFilter.gameObject, value);
				CamoTransform.HOFCJJODJHF(KHLGDCHJJPB.meshChanger.LJBKNMJBPEG.OJAPOOKMMPK.meshFilter.gameObject, value);
			}
		}

		public override void MNEEDLCGAFN(KMNCIJPDFPJ KHLGDCHJJPB, bool OGKCIFGLKJJ = false)
		{
			base.MNEEDLCGAFN(KHLGDCHJJPB, OGKCIFGLKJJ);
			KHLGDCHJJPB.meshChanger.ChangeHelmet(this);
			if (Application.isPlaying)
			{
				KHLGDCHJJPB.equippedHelmet = this;
				CamoTransform value = null;
				string text = KHLGDCHJJPB.playerVisuals[0];
				if (text != null)
				{
					camoTransformDict.TryGetValue(text, out value);
				}
				CamoTransform.NOGDMEDGABN(KHLGDCHJJPB.meshChanger.LJBKNMJBPEG.OKGBANFPPAF.meshFilter.gameObject, value);
				CamoTransform.NOGDMEDGABN(KHLGDCHJJPB.meshChanger.LJBKNMJBPEG.OJAPOOKMMPK.meshFilter.gameObject, value);
			}
		}

		public virtual void JPOJNFHBNFH(KMNCIJPDFPJ KHLGDCHJJPB, bool OGKCIFGLKJJ = false)
		{
			JFAEGFFIIKH(KHLGDCHJJPB, OGKCIFGLKJJ);
			KHLGDCHJJPB.meshChanger.AJKDDHHKBBO(this);
			if (Application.isPlaying)
			{
				KHLGDCHJJPB.equippedHelmet = this;
				CamoTransform value = null;
				string text = KHLGDCHJJPB.playerVisuals[0];
				if (text != null)
				{
					camoTransformDict.TryGetValue(text, out value);
				}
				CamoTransform.CFOMMPPEGDE(KHLGDCHJJPB.meshChanger.LJBKNMJBPEG.OKGBANFPPAF.meshFilter.gameObject, value);
				CamoTransform.CGEFBCAIEOK(KHLGDCHJJPB.meshChanger.LJBKNMJBPEG.OJAPOOKMMPK.meshFilter.gameObject, value);
			}
		}

		public virtual void BKPMGJFDAOB(KMNCIJPDFPJ KHLGDCHJJPB, bool OGKCIFGLKJJ = false)
		{
			base.CMMJHCBJBMK(KHLGDCHJJPB, OGKCIFGLKJJ);
			KHLGDCHJJPB.meshChanger.DDIENJDMHNI(this);
			if (Application.isPlaying)
			{
				KHLGDCHJJPB.equippedHelmet = this;
				CamoTransform value = null;
				string text = KHLGDCHJJPB.playerVisuals[0];
				if (text != null)
				{
					camoTransformDict.TryGetValue(text, out value);
				}
				CamoTransform.CGEFBCAIEOK(KHLGDCHJJPB.meshChanger.LJBKNMJBPEG.OKGBANFPPAF.meshFilter.gameObject, value);
				CamoTransform.AMMAFMFNCIF(KHLGDCHJJPB.meshChanger.LJBKNMJBPEG.OJAPOOKMMPK.meshFilter.gameObject, value);
			}
		}

		public virtual void LAOELJCICBN(KMNCIJPDFPJ KHLGDCHJJPB, bool OGKCIFGLKJJ = false)
		{
			JFAEGFFIIKH(KHLGDCHJJPB, OGKCIFGLKJJ);
			KHLGDCHJJPB.meshChanger.AJKDDHHKBBO(this);
			if (Application.isPlaying)
			{
				KHLGDCHJJPB.equippedHelmet = this;
				CamoTransform value = null;
				string text = KHLGDCHJJPB.playerVisuals[1];
				if (text != null)
				{
					camoTransformDict.TryGetValue(text, out value);
				}
				CamoTransform.ENPAJAGIALF(KHLGDCHJJPB.meshChanger.LJBKNMJBPEG.OKGBANFPPAF.meshFilter.gameObject, value);
				CamoTransform.AMMAFMFNCIF(KHLGDCHJJPB.meshChanger.LJBKNMJBPEG.OJAPOOKMMPK.meshFilter.gameObject, value);
			}
		}

		public virtual void GNCLNHCCLMB(KMNCIJPDFPJ KHLGDCHJJPB, bool OGKCIFGLKJJ = false)
		{
			BMGPGCMNIGE(KHLGDCHJJPB, OGKCIFGLKJJ);
			KHLGDCHJJPB.meshChanger.AJKDDHHKBBO(this);
			if (Application.isPlaying)
			{
				KHLGDCHJJPB.equippedHelmet = this;
				CamoTransform value = null;
				string text = KHLGDCHJJPB.playerVisuals[1];
				if (text != null)
				{
					camoTransformDict.TryGetValue(text, out value);
				}
				CamoTransform.HMEAHLPOFNI(KHLGDCHJJPB.meshChanger.LJBKNMJBPEG.OKGBANFPPAF.meshFilter.gameObject, value);
				CamoTransform.LGEBMIOKFCJ(KHLGDCHJJPB.meshChanger.LJBKNMJBPEG.OJAPOOKMMPK.meshFilter.gameObject, value);
			}
		}

		public virtual void AMCJLPNNOKN(KMNCIJPDFPJ KHLGDCHJJPB, bool OGKCIFGLKJJ = false)
		{
			base.MNEEDLCGAFN(KHLGDCHJJPB, OGKCIFGLKJJ);
			KHLGDCHJJPB.meshChanger.DDIENJDMHNI(this);
			if (Application.isPlaying)
			{
				KHLGDCHJJPB.equippedHelmet = this;
				CamoTransform value = null;
				string text = KHLGDCHJJPB.playerVisuals[0];
				if (text != null)
				{
					camoTransformDict.TryGetValue(text, out value);
				}
				CamoTransform.ENPAJAGIALF(KHLGDCHJJPB.meshChanger.LJBKNMJBPEG.OKGBANFPPAF.meshFilter.gameObject, value);
				CamoTransform.NOGDMEDGABN(KHLGDCHJJPB.meshChanger.LJBKNMJBPEG.OJAPOOKMMPK.meshFilter.gameObject, value);
			}
		}

		public virtual void FEOHAJEAGMD(KMNCIJPDFPJ KHLGDCHJJPB, bool OGKCIFGLKJJ = false)
		{
			base.MNEEDLCGAFN(KHLGDCHJJPB, OGKCIFGLKJJ);
			KHLGDCHJJPB.meshChanger.ChangeHelmet(this);
			if (Application.isPlaying)
			{
				KHLGDCHJJPB.equippedHelmet = this;
				CamoTransform value = null;
				string text = KHLGDCHJJPB.playerVisuals[1];
				if (text != null)
				{
					camoTransformDict.TryGetValue(text, out value);
				}
				CamoTransform.HOFCJJODJHF(KHLGDCHJJPB.meshChanger.LJBKNMJBPEG.OKGBANFPPAF.meshFilter.gameObject, value);
				CamoTransform.MAJAFLLCBKG(KHLGDCHJJPB.meshChanger.LJBKNMJBPEG.OJAPOOKMMPK.meshFilter.gameObject, value);
			}
		}

		public virtual void IPNEPDBDMJL(KMNCIJPDFPJ KHLGDCHJJPB, bool OGKCIFGLKJJ = false)
		{
			BMGPGCMNIGE(KHLGDCHJJPB, OGKCIFGLKJJ);
			KHLGDCHJJPB.meshChanger.ChangeHelmet(this);
			if (Application.isPlaying)
			{
				KHLGDCHJJPB.equippedHelmet = this;
				CamoTransform value = null;
				string text = KHLGDCHJJPB.playerVisuals[0];
				if (text != null)
				{
					camoTransformDict.TryGetValue(text, out value);
				}
				CamoTransform.MAJAFLLCBKG(KHLGDCHJJPB.meshChanger.LJBKNMJBPEG.OKGBANFPPAF.meshFilter.gameObject, value);
				CamoTransform.CGEFBCAIEOK(KHLGDCHJJPB.meshChanger.LJBKNMJBPEG.OJAPOOKMMPK.meshFilter.gameObject, value);
			}
		}

		public virtual void MHPDNIHMFFM(KMNCIJPDFPJ KHLGDCHJJPB, bool OGKCIFGLKJJ = false)
		{
			EECOAJIAIOG(KHLGDCHJJPB, OGKCIFGLKJJ);
			KHLGDCHJJPB.meshChanger.AJKDDHHKBBO(this);
			if (Application.isPlaying)
			{
				KHLGDCHJJPB.equippedHelmet = this;
				CamoTransform value = null;
				string text = KHLGDCHJJPB.playerVisuals[1];
				if (text != null)
				{
					camoTransformDict.TryGetValue(text, out value);
				}
				CamoTransform.JFHEFPAHOPK(KHLGDCHJJPB.meshChanger.LJBKNMJBPEG.OKGBANFPPAF.meshFilter.gameObject, value);
				CamoTransform.CGEFBCAIEOK(KHLGDCHJJPB.meshChanger.LJBKNMJBPEG.OJAPOOKMMPK.meshFilter.gameObject, value);
			}
		}

		public virtual void ECGDPOALJOL(KMNCIJPDFPJ KHLGDCHJJPB, bool OGKCIFGLKJJ = false)
		{
			BMGPGCMNIGE(KHLGDCHJJPB, OGKCIFGLKJJ);
			KHLGDCHJJPB.meshChanger.DDIENJDMHNI(this);
			if (Application.isPlaying)
			{
				KHLGDCHJJPB.equippedHelmet = this;
				CamoTransform value = null;
				string text = KHLGDCHJJPB.playerVisuals[0];
				if (text != null)
				{
					camoTransformDict.TryGetValue(text, out value);
				}
				CamoTransform.HMEAHLPOFNI(KHLGDCHJJPB.meshChanger.LJBKNMJBPEG.OKGBANFPPAF.meshFilter.gameObject, value);
				CamoTransform.CFOMMPPEGDE(KHLGDCHJJPB.meshChanger.LJBKNMJBPEG.OJAPOOKMMPK.meshFilter.gameObject, value);
			}
		}

		public virtual void DAPNGEOOGPL(KMNCIJPDFPJ KHLGDCHJJPB, bool OGKCIFGLKJJ = false)
		{
			EECOAJIAIOG(KHLGDCHJJPB, OGKCIFGLKJJ);
			KHLGDCHJJPB.meshChanger.DDIENJDMHNI(this);
			if (Application.isPlaying)
			{
				KHLGDCHJJPB.equippedHelmet = this;
				CamoTransform value = null;
				string text = KHLGDCHJJPB.playerVisuals[0];
				if (text != null)
				{
					camoTransformDict.TryGetValue(text, out value);
				}
				CamoTransform.IKGEMNOMEHO(KHLGDCHJJPB.meshChanger.LJBKNMJBPEG.OKGBANFPPAF.meshFilter.gameObject, value);
				CamoTransform.CGEFBCAIEOK(KHLGDCHJJPB.meshChanger.LJBKNMJBPEG.OJAPOOKMMPK.meshFilter.gameObject, value);
			}
		}

		public virtual void KOJIMIGFELD(KMNCIJPDFPJ KHLGDCHJJPB, bool OGKCIFGLKJJ = false)
		{
			JFAEGFFIIKH(KHLGDCHJJPB, OGKCIFGLKJJ);
			KHLGDCHJJPB.meshChanger.DDIENJDMHNI(this);
			if (Application.isPlaying)
			{
				KHLGDCHJJPB.equippedHelmet = this;
				CamoTransform value = null;
				string text = KHLGDCHJJPB.playerVisuals[1];
				if (text != null)
				{
					camoTransformDict.TryGetValue(text, out value);
				}
				CamoTransform.JFHEFPAHOPK(KHLGDCHJJPB.meshChanger.LJBKNMJBPEG.OKGBANFPPAF.meshFilter.gameObject, value);
				CamoTransform.LGEBMIOKFCJ(KHLGDCHJJPB.meshChanger.LJBKNMJBPEG.OJAPOOKMMPK.meshFilter.gameObject, value);
			}
		}

		public virtual void GIJBMOJKLMN(KMNCIJPDFPJ KHLGDCHJJPB, bool OGKCIFGLKJJ = false)
		{
			base.MNEEDLCGAFN(KHLGDCHJJPB, OGKCIFGLKJJ);
			KHLGDCHJJPB.meshChanger.AJKDDHHKBBO(this);
			if (Application.isPlaying)
			{
				KHLGDCHJJPB.equippedHelmet = this;
				CamoTransform value = null;
				string text = KHLGDCHJJPB.playerVisuals[0];
				if (text != null)
				{
					camoTransformDict.TryGetValue(text, out value);
				}
				CamoTransform.ENPAJAGIALF(KHLGDCHJJPB.meshChanger.LJBKNMJBPEG.OKGBANFPPAF.meshFilter.gameObject, value);
				CamoTransform.FLDBPONAFAC(KHLGDCHJJPB.meshChanger.LJBKNMJBPEG.OJAPOOKMMPK.meshFilter.gameObject, value);
			}
		}

		public virtual void HGEEMGCOIMM(KMNCIJPDFPJ KHLGDCHJJPB, bool OGKCIFGLKJJ = false)
		{
			JFAEGFFIIKH(KHLGDCHJJPB, OGKCIFGLKJJ);
			KHLGDCHJJPB.meshChanger.AJKDDHHKBBO(this);
			if (Application.isPlaying)
			{
				KHLGDCHJJPB.equippedHelmet = this;
				CamoTransform value = null;
				string text = KHLGDCHJJPB.playerVisuals[0];
				if (text != null)
				{
					camoTransformDict.TryGetValue(text, out value);
				}
				CamoTransform.ENPAJAGIALF(KHLGDCHJJPB.meshChanger.LJBKNMJBPEG.OKGBANFPPAF.meshFilter.gameObject, value);
				CamoTransform.CFOMMPPEGDE(KHLGDCHJJPB.meshChanger.LJBKNMJBPEG.OJAPOOKMMPK.meshFilter.gameObject, value);
			}
		}

		public virtual void NPOILLIFOGF(KMNCIJPDFPJ KHLGDCHJJPB, bool OGKCIFGLKJJ = false)
		{
			base.MNEEDLCGAFN(KHLGDCHJJPB, OGKCIFGLKJJ);
			KHLGDCHJJPB.meshChanger.DDIENJDMHNI(this);
			if (Application.isPlaying)
			{
				KHLGDCHJJPB.equippedHelmet = this;
				CamoTransform value = null;
				string text = KHLGDCHJJPB.playerVisuals[1];
				if (text != null)
				{
					camoTransformDict.TryGetValue(text, out value);
				}
				CamoTransform.HMEAHLPOFNI(KHLGDCHJJPB.meshChanger.LJBKNMJBPEG.OKGBANFPPAF.meshFilter.gameObject, value);
				CamoTransform.HMEAHLPOFNI(KHLGDCHJJPB.meshChanger.LJBKNMJBPEG.OJAPOOKMMPK.meshFilter.gameObject, value);
			}
		}

		public virtual void BGFJGOIILMC(KMNCIJPDFPJ KHLGDCHJJPB, bool OGKCIFGLKJJ = false)
		{
			base.CJOGNDNIBPD(KHLGDCHJJPB, OGKCIFGLKJJ);
			KHLGDCHJJPB.meshChanger.AJKDDHHKBBO(this);
			if (Application.isPlaying)
			{
				KHLGDCHJJPB.equippedHelmet = this;
				CamoTransform value = null;
				string text = KHLGDCHJJPB.playerVisuals[0];
				if (text != null)
				{
					camoTransformDict.TryGetValue(text, out value);
				}
				CamoTransform.ENPAJAGIALF(KHLGDCHJJPB.meshChanger.LJBKNMJBPEG.OKGBANFPPAF.meshFilter.gameObject, value);
				CamoTransform.NOGDMEDGABN(KHLGDCHJJPB.meshChanger.LJBKNMJBPEG.OJAPOOKMMPK.meshFilter.gameObject, value);
			}
		}

		public virtual void MCPLHKIFNAN(KMNCIJPDFPJ KHLGDCHJJPB, bool OGKCIFGLKJJ = false)
		{
			base.MNEEDLCGAFN(KHLGDCHJJPB, OGKCIFGLKJJ);
			KHLGDCHJJPB.meshChanger.AJKDDHHKBBO(this);
			if (Application.isPlaying)
			{
				KHLGDCHJJPB.equippedHelmet = this;
				CamoTransform value = null;
				string text = KHLGDCHJJPB.playerVisuals[1];
				if (text != null)
				{
					camoTransformDict.TryGetValue(text, out value);
				}
				CamoTransform.AMMAFMFNCIF(KHLGDCHJJPB.meshChanger.LJBKNMJBPEG.OKGBANFPPAF.meshFilter.gameObject, value);
				CamoTransform.AMMAFMFNCIF(KHLGDCHJJPB.meshChanger.LJBKNMJBPEG.OJAPOOKMMPK.meshFilter.gameObject, value);
			}
		}

		public virtual void KGMPPPCFPGP(KMNCIJPDFPJ KHLGDCHJJPB, bool OGKCIFGLKJJ = false)
		{
			EECOAJIAIOG(KHLGDCHJJPB, OGKCIFGLKJJ);
			KHLGDCHJJPB.meshChanger.DDIENJDMHNI(this);
			if (Application.isPlaying)
			{
				KHLGDCHJJPB.equippedHelmet = this;
				CamoTransform value = null;
				string text = KHLGDCHJJPB.playerVisuals[1];
				if (text != null)
				{
					camoTransformDict.TryGetValue(text, out value);
				}
				CamoTransform.HMEAHLPOFNI(KHLGDCHJJPB.meshChanger.LJBKNMJBPEG.OKGBANFPPAF.meshFilter.gameObject, value);
				CamoTransform.MAJAFLLCBKG(KHLGDCHJJPB.meshChanger.LJBKNMJBPEG.OJAPOOKMMPK.meshFilter.gameObject, value);
			}
		}

		public virtual void CEOHNCPFPKH(KMNCIJPDFPJ KHLGDCHJJPB, bool OGKCIFGLKJJ = false)
		{
			base.MNEEDLCGAFN(KHLGDCHJJPB, OGKCIFGLKJJ);
			KHLGDCHJJPB.meshChanger.OLEBJCPJELE(this);
			if (Application.isPlaying)
			{
				KHLGDCHJJPB.equippedHelmet = this;
				CamoTransform value = null;
				string text = KHLGDCHJJPB.playerVisuals[0];
				if (text != null)
				{
					camoTransformDict.TryGetValue(text, out value);
				}
				CamoTransform.CFOMMPPEGDE(KHLGDCHJJPB.meshChanger.LJBKNMJBPEG.OKGBANFPPAF.meshFilter.gameObject, value);
				CamoTransform.HMEAHLPOFNI(KHLGDCHJJPB.meshChanger.LJBKNMJBPEG.OJAPOOKMMPK.meshFilter.gameObject, value);
			}
		}

		public override void CJOGNDNIBPD(KMNCIJPDFPJ KHLGDCHJJPB, bool OGKCIFGLKJJ = false)
		{
			base.HGGLCMFPPIB(KHLGDCHJJPB, OGKCIFGLKJJ);
			KHLGDCHJJPB.meshChanger.ChangeHelmet(this);
			if (Application.isPlaying)
			{
				KHLGDCHJJPB.equippedHelmet = this;
				CamoTransform value = null;
				string text = KHLGDCHJJPB.playerVisuals[0];
				if (text != null)
				{
					camoTransformDict.TryGetValue(text, out value);
				}
				CamoTransform.HOFCJJODJHF(KHLGDCHJJPB.meshChanger.LJBKNMJBPEG.OKGBANFPPAF.meshFilter.gameObject, value);
				CamoTransform.IKGEMNOMEHO(KHLGDCHJJPB.meshChanger.LJBKNMJBPEG.OJAPOOKMMPK.meshFilter.gameObject, value);
			}
		}

		public virtual void BKMDCICJPMO(KMNCIJPDFPJ KHLGDCHJJPB, bool OGKCIFGLKJJ = false)
		{
			base.CJOGNDNIBPD(KHLGDCHJJPB, OGKCIFGLKJJ);
			KHLGDCHJJPB.meshChanger.AJKDDHHKBBO(this);
			if (Application.isPlaying)
			{
				KHLGDCHJJPB.equippedHelmet = this;
				CamoTransform value = null;
				string text = KHLGDCHJJPB.playerVisuals[1];
				if (text != null)
				{
					camoTransformDict.TryGetValue(text, out value);
				}
				CamoTransform.HOFCJJODJHF(KHLGDCHJJPB.meshChanger.LJBKNMJBPEG.OKGBANFPPAF.meshFilter.gameObject, value);
				CamoTransform.FLDBPONAFAC(KHLGDCHJJPB.meshChanger.LJBKNMJBPEG.OJAPOOKMMPK.meshFilter.gameObject, value);
			}
		}

		public virtual void HFIMIJMGLJO(KMNCIJPDFPJ KHLGDCHJJPB, bool OGKCIFGLKJJ = false)
		{
			base.CJOGNDNIBPD(KHLGDCHJJPB, OGKCIFGLKJJ);
			KHLGDCHJJPB.meshChanger.AJKDDHHKBBO(this);
			if (Application.isPlaying)
			{
				KHLGDCHJJPB.equippedHelmet = this;
				CamoTransform value = null;
				string text = KHLGDCHJJPB.playerVisuals[0];
				if (text != null)
				{
					camoTransformDict.TryGetValue(text, out value);
				}
				CamoTransform.LGEBMIOKFCJ(KHLGDCHJJPB.meshChanger.LJBKNMJBPEG.OKGBANFPPAF.meshFilter.gameObject, value);
				CamoTransform.HOFCJJODJHF(KHLGDCHJJPB.meshChanger.LJBKNMJBPEG.OJAPOOKMMPK.meshFilter.gameObject, value);
			}
		}

		public virtual void EFBHOFDJEHL(KMNCIJPDFPJ KHLGDCHJJPB, bool OGKCIFGLKJJ = false)
		{
			BMGPGCMNIGE(KHLGDCHJJPB, OGKCIFGLKJJ);
			KHLGDCHJJPB.meshChanger.ChangeHelmet(this);
			if (Application.isPlaying)
			{
				KHLGDCHJJPB.equippedHelmet = this;
				CamoTransform value = null;
				string text = KHLGDCHJJPB.playerVisuals[1];
				if (text != null)
				{
					camoTransformDict.TryGetValue(text, out value);
				}
				CamoTransform.LGEBMIOKFCJ(KHLGDCHJJPB.meshChanger.LJBKNMJBPEG.OKGBANFPPAF.meshFilter.gameObject, value);
				CamoTransform.FGMDLCLGDKG(KHLGDCHJJPB.meshChanger.LJBKNMJBPEG.OJAPOOKMMPK.meshFilter.gameObject, value);
			}
		}

		public virtual void MDDCIINIMCL(KMNCIJPDFPJ KHLGDCHJJPB, bool OGKCIFGLKJJ = false)
		{
			base.MNEEDLCGAFN(KHLGDCHJJPB, OGKCIFGLKJJ);
			KHLGDCHJJPB.meshChanger.AJKDDHHKBBO(this);
			if (Application.isPlaying)
			{
				KHLGDCHJJPB.equippedHelmet = this;
				CamoTransform value = null;
				string text = KHLGDCHJJPB.playerVisuals[1];
				if (text != null)
				{
					camoTransformDict.TryGetValue(text, out value);
				}
				CamoTransform.CFOMMPPEGDE(KHLGDCHJJPB.meshChanger.LJBKNMJBPEG.OKGBANFPPAF.meshFilter.gameObject, value);
				CamoTransform.HOFCJJODJHF(KHLGDCHJJPB.meshChanger.LJBKNMJBPEG.OJAPOOKMMPK.meshFilter.gameObject, value);
			}
		}

		public override void HGGLCMFPPIB(KMNCIJPDFPJ KHLGDCHJJPB, bool OGKCIFGLKJJ = false)
		{
			EECOAJIAIOG(KHLGDCHJJPB, OGKCIFGLKJJ);
			KHLGDCHJJPB.meshChanger.DDIENJDMHNI(this);
			if (Application.isPlaying)
			{
				KHLGDCHJJPB.equippedHelmet = this;
				CamoTransform value = null;
				string text = KHLGDCHJJPB.playerVisuals[1];
				if (text != null)
				{
					camoTransformDict.TryGetValue(text, out value);
				}
				CamoTransform.CGEFBCAIEOK(KHLGDCHJJPB.meshChanger.LJBKNMJBPEG.OKGBANFPPAF.meshFilter.gameObject, value);
				CamoTransform.CFOMMPPEGDE(KHLGDCHJJPB.meshChanger.LJBKNMJBPEG.OJAPOOKMMPK.meshFilter.gameObject, value);
			}
		}

		public virtual void IHGINLFINKP(KMNCIJPDFPJ KHLGDCHJJPB, bool OGKCIFGLKJJ = false)
		{
			EECOAJIAIOG(KHLGDCHJJPB, OGKCIFGLKJJ);
			KHLGDCHJJPB.meshChanger.DDIENJDMHNI(this);
			if (Application.isPlaying)
			{
				KHLGDCHJJPB.equippedHelmet = this;
				CamoTransform value = null;
				string text = KHLGDCHJJPB.playerVisuals[0];
				if (text != null)
				{
					camoTransformDict.TryGetValue(text, out value);
				}
				CamoTransform.FGMDLCLGDKG(KHLGDCHJJPB.meshChanger.LJBKNMJBPEG.OKGBANFPPAF.meshFilter.gameObject, value);
				CamoTransform.NOGDMEDGABN(KHLGDCHJJPB.meshChanger.LJBKNMJBPEG.OJAPOOKMMPK.meshFilter.gameObject, value);
			}
		}

		public virtual void NNPIMCKLCIN(KMNCIJPDFPJ KHLGDCHJJPB, bool OGKCIFGLKJJ = false)
		{
			EECOAJIAIOG(KHLGDCHJJPB, OGKCIFGLKJJ);
			KHLGDCHJJPB.meshChanger.OLEBJCPJELE(this);
			if (Application.isPlaying)
			{
				KHLGDCHJJPB.equippedHelmet = this;
				CamoTransform value = null;
				string text = KHLGDCHJJPB.playerVisuals[1];
				if (text != null)
				{
					camoTransformDict.TryGetValue(text, out value);
				}
				CamoTransform.LGEBMIOKFCJ(KHLGDCHJJPB.meshChanger.LJBKNMJBPEG.OKGBANFPPAF.meshFilter.gameObject, value);
				CamoTransform.ENPAJAGIALF(KHLGDCHJJPB.meshChanger.LJBKNMJBPEG.OJAPOOKMMPK.meshFilter.gameObject, value);
			}
		}
	}
}
