using UnityEngine;

namespace Agens.Stickers
{
	public static class AFBCAMKGKEG
	{
		public static Texture2D BDACMMCJLIM(Texture2D EOFMHBNDCCP, int CEHFMMJHCKC, int FBMIFHHEOBO, Color FMLEEJAOHGL, float AAHKOHAJKKJ, FilterMode JGMLALPJHIC = FilterMode.Trilinear, ScaleMode BIPJEHFCJNB = ScaleMode.ScaleToFit)
		{
			Texture2D texture2D = new Texture2D(CEHFMMJHCKC, FBMIFHHEOBO, TextureFormat.ARGB32, mipChain: false);
			if (EOFMHBNDCCP == null)
			{
				Debug.LogWarning("Source texture is null");
				return texture2D;
			}
			RenderTexture renderTexture = CPBBCPJKOEC(EOFMHBNDCCP, CEHFMMJHCKC, FBMIFHHEOBO, FMLEEJAOHGL, AAHKOHAJKKJ, JGMLALPJHIC, BIPJEHFCJNB);
			Rect source = new Rect(0f, 0f, CEHFMMJHCKC, FBMIFHHEOBO);
			texture2D.ReadPixels(source, 0, 0, recalculateMipMaps: true);
			texture2D.Apply(updateMipmaps: false);
			RenderTexture.active = null;
			renderTexture.Release();
			return texture2D;
		}

		private static RenderTexture CPBBCPJKOEC(Texture2D EOFMHBNDCCP, int CEHFMMJHCKC, int FBMIFHHEOBO, Color FMLEEJAOHGL, float AAHKOHAJKKJ, FilterMode DCDPJKKBPGG = FilterMode.Trilinear, ScaleMode KDPDKGIELHG = ScaleMode.ScaleToFit)
		{
			EOFMHBNDCCP.filterMode = DCDPJKKBPGG;
			EOFMHBNDCCP.Apply(updateMipmaps: true);
			RenderTexture result = (RenderTexture.active = new RenderTexture(CEHFMMJHCKC, FBMIFHHEOBO, 32));
			GL.LoadPixelMatrix(0f, CEHFMMJHCKC, FBMIFHHEOBO, 0f);
			GL.Clear(clearDepth: true, clearColor: true, FMLEEJAOHGL);
			AAHKOHAJKKJ = ((KDPDKGIELHG != ScaleMode.ScaleToFit) ? 1f : Mathf.Clamp01(AAHKOHAJKKJ));
			float num = (float)CEHFMMJHCKC * AAHKOHAJKKJ;
			float num2 = (float)FBMIFHHEOBO * AAHKOHAJKKJ;
			float x = ((float)CEHFMMJHCKC - num) / 2f;
			float y = ((float)FBMIFHHEOBO - num2) / 2f;
			LDAMJBEEDJA(new Rect(x, y, num, num2), EOFMHBNDCCP, KDPDKGIELHG);
			return result;
		}

		private static void LDAMJBEEDJA(Rect MPHCNMDIPAI, Texture FOIJFCPKPAM, ScaleMode KDPDKGIELHG, float ABOANACCBFI = 0f)
		{
			if ((double)ABOANACCBFI == 0.0)
			{
				ABOANACCBFI = (float)FOIJFCPKPAM.width / (float)FOIJFCPKPAM.height;
			}
			Rect LBBAMBFABPD = default(Rect);
			Rect PFJEPFFMLGF = default(Rect);
			FPKCHLBKANL(MPHCNMDIPAI, KDPDKGIELHG, ABOANACCBFI, ref LBBAMBFABPD, ref PFJEPFFMLGF);
			Graphics.DrawTexture(LBBAMBFABPD, FOIJFCPKPAM, PFJEPFFMLGF, 0, 0, 0, 0);
		}

		private static bool FPKCHLBKANL(Rect MPHCNMDIPAI, ScaleMode KDPDKGIELHG, float ABOANACCBFI, ref Rect LBBAMBFABPD, ref Rect PFJEPFFMLGF)
		{
			float num = MPHCNMDIPAI.width / MPHCNMDIPAI.height;
			bool result = false;
			switch (KDPDKGIELHG)
			{
			case ScaleMode.ScaleToFit:
				if (num > ABOANACCBFI)
				{
					float num4 = ABOANACCBFI / num;
					LBBAMBFABPD = new Rect(MPHCNMDIPAI.xMin + (float)((double)MPHCNMDIPAI.width * (1.0 - (double)num4) * 0.5), MPHCNMDIPAI.yMin, num4 * MPHCNMDIPAI.width, MPHCNMDIPAI.height);
					PFJEPFFMLGF = new Rect(0f, 0f, 1f, 1f);
					result = true;
				}
				else
				{
					float num5 = num / ABOANACCBFI;
					LBBAMBFABPD = new Rect(MPHCNMDIPAI.xMin, MPHCNMDIPAI.yMin + (float)((double)MPHCNMDIPAI.height * (1.0 - (double)num5) * 0.5), MPHCNMDIPAI.width, num5 * MPHCNMDIPAI.height);
					PFJEPFFMLGF = new Rect(0f, 0f, 1f, 1f);
					result = true;
				}
				break;
			case ScaleMode.ScaleAndCrop:
				if (num > ABOANACCBFI)
				{
					float num2 = ABOANACCBFI / num;
					LBBAMBFABPD = MPHCNMDIPAI;
					PFJEPFFMLGF = new Rect(0f, (float)((1.0 - (double)num2) * 0.5), 1f, num2);
					result = true;
				}
				else
				{
					float num3 = num / ABOANACCBFI;
					LBBAMBFABPD = MPHCNMDIPAI;
					PFJEPFFMLGF = new Rect((float)(0.5 - (double)num3 * 0.5), 0f, num3, 1f);
					result = true;
				}
				break;
			case ScaleMode.StretchToFill:
				LBBAMBFABPD = MPHCNMDIPAI;
				PFJEPFFMLGF = new Rect(0f, 0f, 1f, 1f);
				result = true;
				break;
			}
			return result;
		}
	}
}
