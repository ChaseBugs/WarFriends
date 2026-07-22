using System;
using UnityEngine;

public class PlayerVisualCategoryHeadAccesories : PlayerVisualCategoryGeneric<PlayerVisualCategoryHeadAccesories.PlayerVisualHeadAccesory>
{
	[Serializable]
	public class PlayerVisualHeadAccesory : PlayerVisualHead
	{
		public int visualSlotId;

		public virtual void KAEOMEFIGLE(KMNCIJPDFPJ DGJFKDADPHE, bool OGKCIFGLKJJ = false)
		{
			HGGLCMFPPIB(DGJFKDADPHE, OGKCIFGLKJJ);
			DGJFKDADPHE.meshChanger.KPLKGFJGADK(this);
			if (!Application.isPlaying)
			{
				return;
			}
			DGJFKDADPHE.equippedHeadAccesory = this;
			CamoTransform value = null;
			string text = DGJFKDADPHE.playerVisuals[1];
			if (text != null)
			{
				camoTransformDict.TryGetValue(text, out value);
			}
			foreach (ModelAttachments.ModelAttachment item in DGJFKDADPHE.meshChanger.AKPKJMNGFIE.BLHMGOMCDFG)
			{
				if (item.mPrefab == base.mesh)
				{
					CamoTransform.NOGDMEDGABN(item.mInstance.gameObject, value);
				}
			}
		}

		public virtual void DAHJAEGOCAP(KMNCIJPDFPJ DGJFKDADPHE, bool OGKCIFGLKJJ = false)
		{
			BMGPGCMNIGE(DGJFKDADPHE, OGKCIFGLKJJ);
			DGJFKDADPHE.meshChanger.JIKADKGLKML(this);
			if (!Application.isPlaying)
			{
				return;
			}
			DGJFKDADPHE.equippedHeadAccesory = this;
			CamoTransform value = null;
			string text = DGJFKDADPHE.playerVisuals[0];
			if (text != null)
			{
				camoTransformDict.TryGetValue(text, out value);
			}
			foreach (ModelAttachments.ModelAttachment item in DGJFKDADPHE.meshChanger.AKPKJMNGFIE.BLHMGOMCDFG)
			{
				if (item.mPrefab == base.mesh)
				{
					CamoTransform.MAJAFLLCBKG(item.mInstance.gameObject, value);
				}
			}
		}

		public virtual void KGACOPBGFOA(KMNCIJPDFPJ DGJFKDADPHE, bool OGKCIFGLKJJ = false)
		{
			EECOAJIAIOG(DGJFKDADPHE, OGKCIFGLKJJ);
			DGJFKDADPHE.meshChanger.INCHOFKIBOI(this);
			if (!Application.isPlaying)
			{
				return;
			}
			DGJFKDADPHE.equippedHeadAccesory = this;
			CamoTransform value = null;
			string text = DGJFKDADPHE.playerVisuals[1];
			if (text != null)
			{
				camoTransformDict.TryGetValue(text, out value);
			}
			foreach (ModelAttachments.ModelAttachment item in DGJFKDADPHE.meshChanger.AKPKJMNGFIE.BLHMGOMCDFG)
			{
				if (item.mPrefab == KCCDEHDNHAL())
				{
					CamoTransform.MAJAFLLCBKG(item.mInstance.gameObject, value);
				}
			}
		}

		public virtual void HFIMIJMGLJO(KMNCIJPDFPJ DGJFKDADPHE, bool OGKCIFGLKJJ = false)
		{
			JFAEGFFIIKH(DGJFKDADPHE, OGKCIFGLKJJ);
			DGJFKDADPHE.meshChanger.LJNGFJFDIHO(this);
			if (!Application.isPlaying)
			{
				return;
			}
			DGJFKDADPHE.equippedHeadAccesory = this;
			CamoTransform value = null;
			string text = DGJFKDADPHE.playerVisuals[0];
			if (text != null)
			{
				camoTransformDict.TryGetValue(text, out value);
			}
			foreach (ModelAttachments.ModelAttachment item in DGJFKDADPHE.meshChanger.AKPKJMNGFIE.BLHMGOMCDFG)
			{
				if (item.mPrefab == NAPOIPPPJFC())
				{
					CamoTransform.MAJAFLLCBKG(item.mInstance.gameObject, value);
				}
			}
		}

		public virtual void CEOHNCPFPKH(KMNCIJPDFPJ DGJFKDADPHE, bool OGKCIFGLKJJ = false)
		{
			EECOAJIAIOG(DGJFKDADPHE, OGKCIFGLKJJ);
			DGJFKDADPHE.meshChanger.KPLKGFJGADK(this);
			if (!Application.isPlaying)
			{
				return;
			}
			DGJFKDADPHE.equippedHeadAccesory = this;
			CamoTransform value = null;
			string text = DGJFKDADPHE.playerVisuals[0];
			if (text != null)
			{
				camoTransformDict.TryGetValue(text, out value);
			}
			foreach (ModelAttachments.ModelAttachment item in DGJFKDADPHE.meshChanger.AKPKJMNGFIE.BLHMGOMCDFG)
			{
				if (item.mPrefab == base.mesh)
				{
					CamoTransform.JFHEFPAHOPK(item.mInstance.gameObject, value);
				}
			}
		}

		public virtual void BGFJGOIILMC(KMNCIJPDFPJ DGJFKDADPHE, bool OGKCIFGLKJJ = false)
		{
			HGGLCMFPPIB(DGJFKDADPHE, OGKCIFGLKJJ);
			DGJFKDADPHE.meshChanger.MFEIJIEPDPE(this);
			if (!Application.isPlaying)
			{
				return;
			}
			DGJFKDADPHE.equippedHeadAccesory = this;
			CamoTransform value = null;
			string text = DGJFKDADPHE.playerVisuals[1];
			if (text != null)
			{
				camoTransformDict.TryGetValue(text, out value);
			}
			foreach (ModelAttachments.ModelAttachment item in DGJFKDADPHE.meshChanger.AKPKJMNGFIE.BLHMGOMCDFG)
			{
				if (item.mPrefab == NAPOIPPPJFC())
				{
					CamoTransform.FGMDLCLGDKG(item.mInstance.gameObject, value);
				}
			}
		}

		public virtual void GPPPJCILIFF(KMNCIJPDFPJ DGJFKDADPHE, bool OGKCIFGLKJJ = false)
		{
			BMGPGCMNIGE(DGJFKDADPHE, OGKCIFGLKJJ);
			DGJFKDADPHE.meshChanger.OGMIPACFIBF(this);
			if (!Application.isPlaying)
			{
				return;
			}
			DGJFKDADPHE.equippedHeadAccesory = this;
			CamoTransform value = null;
			string text = DGJFKDADPHE.playerVisuals[1];
			if (text != null)
			{
				camoTransformDict.TryGetValue(text, out value);
			}
			foreach (ModelAttachments.ModelAttachment item in DGJFKDADPHE.meshChanger.AKPKJMNGFIE.BLHMGOMCDFG)
			{
				if (item.mPrefab == KCCDEHDNHAL())
				{
					CamoTransform.MAJAFLLCBKG(item.mInstance.gameObject, value);
				}
			}
		}

		public virtual void GKJJFHNGMCB(KMNCIJPDFPJ DGJFKDADPHE, bool OGKCIFGLKJJ = false)
		{
			CJOGNDNIBPD(DGJFKDADPHE, OGKCIFGLKJJ);
			DGJFKDADPHE.meshChanger.MFEIJIEPDPE(this);
			if (!Application.isPlaying)
			{
				return;
			}
			DGJFKDADPHE.equippedHeadAccesory = this;
			CamoTransform value = null;
			string text = DGJFKDADPHE.playerVisuals[0];
			if (text != null)
			{
				camoTransformDict.TryGetValue(text, out value);
			}
			foreach (ModelAttachments.ModelAttachment item in DGJFKDADPHE.meshChanger.AKPKJMNGFIE.BLHMGOMCDFG)
			{
				if (item.mPrefab == KCCDEHDNHAL())
				{
					CamoTransform.HOFCJJODJHF(item.mInstance.gameObject, value);
				}
			}
		}

		public virtual void CDNIELDCDFD(KMNCIJPDFPJ DGJFKDADPHE, bool OGKCIFGLKJJ = false)
		{
			CJOGNDNIBPD(DGJFKDADPHE, OGKCIFGLKJJ);
			DGJFKDADPHE.meshChanger.KPLKGFJGADK(this);
			if (!Application.isPlaying)
			{
				return;
			}
			DGJFKDADPHE.equippedHeadAccesory = this;
			CamoTransform value = null;
			string text = DGJFKDADPHE.playerVisuals[1];
			if (text != null)
			{
				camoTransformDict.TryGetValue(text, out value);
			}
			foreach (ModelAttachments.ModelAttachment item in DGJFKDADPHE.meshChanger.AKPKJMNGFIE.BLHMGOMCDFG)
			{
				if (item.mPrefab == NAPOIPPPJFC())
				{
					CamoTransform.NOGDMEDGABN(item.mInstance.gameObject, value);
				}
			}
		}

		public override void MNEEDLCGAFN(KMNCIJPDFPJ DGJFKDADPHE, bool OGKCIFGLKJJ = false)
		{
			base.MNEEDLCGAFN(DGJFKDADPHE, OGKCIFGLKJJ);
			DGJFKDADPHE.meshChanger.ChangeHelmetAttachment(this);
			if (!Application.isPlaying)
			{
				return;
			}
			DGJFKDADPHE.equippedHeadAccesory = this;
			CamoTransform value = null;
			string text = DGJFKDADPHE.playerVisuals[0];
			if (text != null)
			{
				camoTransformDict.TryGetValue(text, out value);
			}
			foreach (ModelAttachments.ModelAttachment item in DGJFKDADPHE.meshChanger.AKPKJMNGFIE.BLHMGOMCDFG)
			{
				if (item.mPrefab == base.mesh)
				{
					CamoTransform.NOGDMEDGABN(item.mInstance.gameObject, value);
				}
			}
		}

		public virtual void LOBHDEMCDBC(KMNCIJPDFPJ DGJFKDADPHE, bool OGKCIFGLKJJ = false)
		{
			EECOAJIAIOG(DGJFKDADPHE, OGKCIFGLKJJ);
			DGJFKDADPHE.meshChanger.MFEIJIEPDPE(this);
			if (!Application.isPlaying)
			{
				return;
			}
			DGJFKDADPHE.equippedHeadAccesory = this;
			CamoTransform value = null;
			string text = DGJFKDADPHE.playerVisuals[0];
			if (text != null)
			{
				camoTransformDict.TryGetValue(text, out value);
			}
			foreach (ModelAttachments.ModelAttachment item in DGJFKDADPHE.meshChanger.AKPKJMNGFIE.BLHMGOMCDFG)
			{
				if (item.mPrefab == KCCDEHDNHAL())
				{
					CamoTransform.IKGEMNOMEHO(item.mInstance.gameObject, value);
				}
			}
		}

		public virtual void AMCJLPNNOKN(KMNCIJPDFPJ DGJFKDADPHE, bool OGKCIFGLKJJ = false)
		{
			CMMJHCBJBMK(DGJFKDADPHE, OGKCIFGLKJJ);
			DGJFKDADPHE.meshChanger.IACDKOAILCD(this);
			if (!Application.isPlaying)
			{
				return;
			}
			DGJFKDADPHE.equippedHeadAccesory = this;
			CamoTransform value = null;
			string text = DGJFKDADPHE.playerVisuals[1];
			if (text != null)
			{
				camoTransformDict.TryGetValue(text, out value);
			}
			foreach (ModelAttachments.ModelAttachment item in DGJFKDADPHE.meshChanger.AKPKJMNGFIE.BLHMGOMCDFG)
			{
				if (item.mPrefab == NAPOIPPPJFC())
				{
					CamoTransform.CGEFBCAIEOK(item.mInstance.gameObject, value);
				}
			}
		}

		public virtual void GNCLNHCCLMB(KMNCIJPDFPJ DGJFKDADPHE, bool OGKCIFGLKJJ = false)
		{
			HGGLCMFPPIB(DGJFKDADPHE, OGKCIFGLKJJ);
			DGJFKDADPHE.meshChanger.INCHOFKIBOI(this);
			if (!Application.isPlaying)
			{
				return;
			}
			DGJFKDADPHE.equippedHeadAccesory = this;
			CamoTransform value = null;
			string text = DGJFKDADPHE.playerVisuals[1];
			if (text != null)
			{
				camoTransformDict.TryGetValue(text, out value);
			}
			foreach (ModelAttachments.ModelAttachment item in DGJFKDADPHE.meshChanger.AKPKJMNGFIE.BLHMGOMCDFG)
			{
				if (item.mPrefab == NAPOIPPPJFC())
				{
					CamoTransform.NOGDMEDGABN(item.mInstance.gameObject, value);
				}
			}
		}

		public virtual void LOICOCNLJLJ(KMNCIJPDFPJ DGJFKDADPHE, bool OGKCIFGLKJJ = false)
		{
			HGGLCMFPPIB(DGJFKDADPHE, OGKCIFGLKJJ);
			DGJFKDADPHE.meshChanger.ChangeHelmetAttachment(this);
			if (!Application.isPlaying)
			{
				return;
			}
			DGJFKDADPHE.equippedHeadAccesory = this;
			CamoTransform value = null;
			string text = DGJFKDADPHE.playerVisuals[1];
			if (text != null)
			{
				camoTransformDict.TryGetValue(text, out value);
			}
			foreach (ModelAttachments.ModelAttachment item in DGJFKDADPHE.meshChanger.AKPKJMNGFIE.BLHMGOMCDFG)
			{
				if (item.mPrefab == KCCDEHDNHAL())
				{
					CamoTransform.CGEFBCAIEOK(item.mInstance.gameObject, value);
				}
			}
		}

		public virtual void HGEEMGCOIMM(KMNCIJPDFPJ DGJFKDADPHE, bool OGKCIFGLKJJ = false)
		{
			CMMJHCBJBMK(DGJFKDADPHE, OGKCIFGLKJJ);
			DGJFKDADPHE.meshChanger.LJNGFJFDIHO(this);
			if (!Application.isPlaying)
			{
				return;
			}
			DGJFKDADPHE.equippedHeadAccesory = this;
			CamoTransform value = null;
			string text = DGJFKDADPHE.playerVisuals[1];
			if (text != null)
			{
				camoTransformDict.TryGetValue(text, out value);
			}
			foreach (ModelAttachments.ModelAttachment item in DGJFKDADPHE.meshChanger.AKPKJMNGFIE.BLHMGOMCDFG)
			{
				if (item.mPrefab == base.mesh)
				{
					CamoTransform.IKGEMNOMEHO(item.mInstance.gameObject, value);
				}
			}
		}

		public virtual void CGDBMFBMLLL(KMNCIJPDFPJ DGJFKDADPHE, bool OGKCIFGLKJJ = false)
		{
			BMGPGCMNIGE(DGJFKDADPHE, OGKCIFGLKJJ);
			DGJFKDADPHE.meshChanger.LJNGFJFDIHO(this);
			if (!Application.isPlaying)
			{
				return;
			}
			DGJFKDADPHE.equippedHeadAccesory = this;
			CamoTransform value = null;
			string text = DGJFKDADPHE.playerVisuals[0];
			if (text != null)
			{
				camoTransformDict.TryGetValue(text, out value);
			}
			foreach (ModelAttachments.ModelAttachment item in DGJFKDADPHE.meshChanger.AKPKJMNGFIE.BLHMGOMCDFG)
			{
				if (item.mPrefab == base.mesh)
				{
					CamoTransform.IKGEMNOMEHO(item.mInstance.gameObject, value);
				}
			}
		}

		public virtual void DAFOEOPNMAH(KMNCIJPDFPJ DGJFKDADPHE, bool OGKCIFGLKJJ = false)
		{
			JFAEGFFIIKH(DGJFKDADPHE, OGKCIFGLKJJ);
			DGJFKDADPHE.meshChanger.ChangeHelmetAttachment(this);
			if (!Application.isPlaying)
			{
				return;
			}
			DGJFKDADPHE.equippedHeadAccesory = this;
			CamoTransform value = null;
			string text = DGJFKDADPHE.playerVisuals[1];
			if (text != null)
			{
				camoTransformDict.TryGetValue(text, out value);
			}
			foreach (ModelAttachments.ModelAttachment item in DGJFKDADPHE.meshChanger.AKPKJMNGFIE.BLHMGOMCDFG)
			{
				if (item.mPrefab == base.mesh)
				{
					CamoTransform.MAJAFLLCBKG(item.mInstance.gameObject, value);
				}
			}
		}

		public virtual void AEFANBFMJHG(KMNCIJPDFPJ DGJFKDADPHE, bool OGKCIFGLKJJ = false)
		{
			base.MNEEDLCGAFN(DGJFKDADPHE, OGKCIFGLKJJ);
			DGJFKDADPHE.meshChanger.LJDPGIHJDOM(this);
			if (!Application.isPlaying)
			{
				return;
			}
			DGJFKDADPHE.equippedHeadAccesory = this;
			CamoTransform value = null;
			string text = DGJFKDADPHE.playerVisuals[0];
			if (text != null)
			{
				camoTransformDict.TryGetValue(text, out value);
			}
			foreach (ModelAttachments.ModelAttachment item in DGJFKDADPHE.meshChanger.AKPKJMNGFIE.BLHMGOMCDFG)
			{
				if (item.mPrefab == KCCDEHDNHAL())
				{
					CamoTransform.AMMAFMFNCIF(item.mInstance.gameObject, value);
				}
			}
		}

		public virtual void DAPNGEOOGPL(KMNCIJPDFPJ DGJFKDADPHE, bool OGKCIFGLKJJ = false)
		{
			HGGLCMFPPIB(DGJFKDADPHE, OGKCIFGLKJJ);
			DGJFKDADPHE.meshChanger.OGMIPACFIBF(this);
			if (!Application.isPlaying)
			{
				return;
			}
			DGJFKDADPHE.equippedHeadAccesory = this;
			CamoTransform value = null;
			string text = DGJFKDADPHE.playerVisuals[0];
			if (text != null)
			{
				camoTransformDict.TryGetValue(text, out value);
			}
			foreach (ModelAttachments.ModelAttachment item in DGJFKDADPHE.meshChanger.AKPKJMNGFIE.BLHMGOMCDFG)
			{
				if (item.mPrefab == NAPOIPPPJFC())
				{
					CamoTransform.ENPAJAGIALF(item.mInstance.gameObject, value);
				}
			}
		}

		public virtual void BJMDCIJONDM(KMNCIJPDFPJ DGJFKDADPHE, bool OGKCIFGLKJJ = false)
		{
			CMMJHCBJBMK(DGJFKDADPHE, OGKCIFGLKJJ);
			DGJFKDADPHE.meshChanger.JIKADKGLKML(this);
			if (!Application.isPlaying)
			{
				return;
			}
			DGJFKDADPHE.equippedHeadAccesory = this;
			CamoTransform value = null;
			string text = DGJFKDADPHE.playerVisuals[0];
			if (text != null)
			{
				camoTransformDict.TryGetValue(text, out value);
			}
			foreach (ModelAttachments.ModelAttachment item in DGJFKDADPHE.meshChanger.AKPKJMNGFIE.BLHMGOMCDFG)
			{
				if (item.mPrefab == NAPOIPPPJFC())
				{
					CamoTransform.FLDBPONAFAC(item.mInstance.gameObject, value);
				}
			}
		}

		public virtual void FCBGGONHKJP(KMNCIJPDFPJ DGJFKDADPHE, bool OGKCIFGLKJJ = false)
		{
			BMGPGCMNIGE(DGJFKDADPHE, OGKCIFGLKJJ);
			DGJFKDADPHE.meshChanger.KPLKGFJGADK(this);
			if (!Application.isPlaying)
			{
				return;
			}
			DGJFKDADPHE.equippedHeadAccesory = this;
			CamoTransform value = null;
			string text = DGJFKDADPHE.playerVisuals[1];
			if (text != null)
			{
				camoTransformDict.TryGetValue(text, out value);
			}
			foreach (ModelAttachments.ModelAttachment item in DGJFKDADPHE.meshChanger.AKPKJMNGFIE.BLHMGOMCDFG)
			{
				if (item.mPrefab == base.mesh)
				{
					CamoTransform.ENPAJAGIALF(item.mInstance.gameObject, value);
				}
			}
		}

		public virtual void BAHJPHEHOBP(KMNCIJPDFPJ DGJFKDADPHE, bool OGKCIFGLKJJ = false)
		{
			EECOAJIAIOG(DGJFKDADPHE, OGKCIFGLKJJ);
			DGJFKDADPHE.meshChanger.IACDKOAILCD(this);
			if (!Application.isPlaying)
			{
				return;
			}
			DGJFKDADPHE.equippedHeadAccesory = this;
			CamoTransform value = null;
			string text = DGJFKDADPHE.playerVisuals[1];
			if (text != null)
			{
				camoTransformDict.TryGetValue(text, out value);
			}
			foreach (ModelAttachments.ModelAttachment item in DGJFKDADPHE.meshChanger.AKPKJMNGFIE.BLHMGOMCDFG)
			{
				if (item.mPrefab == base.mesh)
				{
					CamoTransform.CGEFBCAIEOK(item.mInstance.gameObject, value);
				}
			}
		}

		public virtual void IOJPMAJOHNN(KMNCIJPDFPJ DGJFKDADPHE, bool OGKCIFGLKJJ = false)
		{
			JFAEGFFIIKH(DGJFKDADPHE, OGKCIFGLKJJ);
			DGJFKDADPHE.meshChanger.IACDKOAILCD(this);
			if (!Application.isPlaying)
			{
				return;
			}
			DGJFKDADPHE.equippedHeadAccesory = this;
			CamoTransform value = null;
			string text = DGJFKDADPHE.playerVisuals[0];
			if (text != null)
			{
				camoTransformDict.TryGetValue(text, out value);
			}
			foreach (ModelAttachments.ModelAttachment item in DGJFKDADPHE.meshChanger.AKPKJMNGFIE.BLHMGOMCDFG)
			{
				if (item.mPrefab == base.mesh)
				{
					CamoTransform.MAJAFLLCBKG(item.mInstance.gameObject, value);
				}
			}
		}

		public virtual void ANACNFJCKFN(KMNCIJPDFPJ DGJFKDADPHE, bool OGKCIFGLKJJ = false)
		{
			HGGLCMFPPIB(DGJFKDADPHE, OGKCIFGLKJJ);
			DGJFKDADPHE.meshChanger.BFAMLOFOGFN(this);
			if (!Application.isPlaying)
			{
				return;
			}
			DGJFKDADPHE.equippedHeadAccesory = this;
			CamoTransform value = null;
			string text = DGJFKDADPHE.playerVisuals[0];
			if (text != null)
			{
				camoTransformDict.TryGetValue(text, out value);
			}
			foreach (ModelAttachments.ModelAttachment item in DGJFKDADPHE.meshChanger.AKPKJMNGFIE.BLHMGOMCDFG)
			{
				if (item.mPrefab == base.mesh)
				{
					CamoTransform.CFOMMPPEGDE(item.mInstance.gameObject, value);
				}
			}
		}
	}
}
