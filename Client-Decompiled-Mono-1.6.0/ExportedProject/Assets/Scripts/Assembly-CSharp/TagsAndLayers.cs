using UnityEngine;

public class TagsAndLayers : Singleton<TagsAndLayers>
{
	public static string BCOCLOGHEBA = "MapDefinition";

	public static int FEFDIKDCGII = 8;

	public static int PLPNKLDHELM = 10;

	public static int GIDHAMNOIHG = 13;

	public static int ALONKNCEAEA = 30;

	public static int KFLGCPACECP = 14;

	public static int LFJMBCANMMO = 15;

	public static int PDDCIEOHNLE = 16;

	public static int DEBNDJGPFIM = 22;

	public static int KMHEAJAIJOF = 23;

	public static int JNCLCGHJAOO = 24;

	public static int DDDHLJCIEEM = 26;

	public static int NHFGADFFGDN = 27;

	public static int DJLKEEHPAGA = (1 << FEFDIKDCGII) | (1 << DEBNDJGPFIM) | (1 << KMHEAJAIJOF) | (1 << JNCLCGHJAOO) | (1 << NHFGADFFGDN) | (1 << DDDHLJCIEEM);

	public static int LOIIIBKKOPP = (1 << GIDHAMNOIHG) | (1 << ALONKNCEAEA);

	public LayerMask ILJHAFNIPMF;

	public LayerMask CJKEJNEAFDH;

	public LayerMask IGBBFBNFNBJ;

	public LayerMask BAFPJAGNEHI(GHPGNELIDBM CIOPAKLHFIL, int BLOHNLJOPIM)
	{
		switch (CIOPAKLHFIL)
		{
		case GHPGNELIDBM.None:
			return (int)IGBBFBNFNBJ & ~BLOHNLJOPIM;
		case (GHPGNELIDBM)7:
			return (int)CJKEJNEAFDH & ~BLOHNLJOPIM;
		default:
			return (int)ILJHAFNIPMF & ~BLOHNLJOPIM;
		}
	}

	public static bool LKIJKDCGCMI(GameObject ECHOPGPBLOK)
	{
		return ECHOPGPBLOK.layer != GIDHAMNOIHG && ECHOPGPBLOK.layer == ALONKNCEAEA;
	}

	public int ALDBGABJCKN(GHPGNELIDBM CIOPAKLHFIL, bool MNFCGHNFFFF)
	{
		switch (CIOPAKLHFIL)
		{
		case GHPGNELIDBM.Enemies:
			return (!MNFCGHNFFFF) ? KMHEAJAIJOF : NHFGADFFGDN;
		case (GHPGNELIDBM)4:
			return (!MNFCGHNFFFF) ? DEBNDJGPFIM : DDDHLJCIEEM;
		default:
			return FEFDIKDCGII;
		}
	}

	public LayerMask GetBulletMask(GHPGNELIDBM CIOPAKLHFIL, int BLOHNLJOPIM)
	{
		switch (CIOPAKLHFIL)
		{
		case GHPGNELIDBM.Enemies:
			return (int)IGBBFBNFNBJ & ~BLOHNLJOPIM;
		case GHPGNELIDBM.Allies:
			return (int)CJKEJNEAFDH & ~BLOHNLJOPIM;
		default:
			return (int)ILJHAFNIPMF & ~BLOHNLJOPIM;
		}
	}

	public int GetFractionBulletLayer(GHPGNELIDBM CIOPAKLHFIL, bool MNFCGHNFFFF)
	{
		switch (CIOPAKLHFIL)
		{
		case GHPGNELIDBM.Enemies:
			return (!MNFCGHNFFFF) ? KMHEAJAIJOF : NHFGADFFGDN;
		case GHPGNELIDBM.Allies:
			return (!MNFCGHNFFFF) ? DEBNDJGPFIM : DDDHLJCIEEM;
		default:
			return FEFDIKDCGII;
		}
	}

	public static bool IsStatic(GameObject ECHOPGPBLOK)
	{
		return ECHOPGPBLOK.layer == GIDHAMNOIHG || ECHOPGPBLOK.layer == ALONKNCEAEA;
	}

	public int BFGGNFNKMAK(GHPGNELIDBM CIOPAKLHFIL, bool MNFCGHNFFFF)
	{
		switch (CIOPAKLHFIL)
		{
		case GHPGNELIDBM.Enemies:
			return (!MNFCGHNFFFF) ? KMHEAJAIJOF : NHFGADFFGDN;
		case (GHPGNELIDBM)4:
			return (!MNFCGHNFFFF) ? DEBNDJGPFIM : DDDHLJCIEEM;
		default:
			return FEFDIKDCGII;
		}
	}

	public LayerMask CMHMEJDGIBJ(GHPGNELIDBM CIOPAKLHFIL, int BLOHNLJOPIM)
	{
		if (CIOPAKLHFIL != GHPGNELIDBM.Enemies)
		{
			if (CIOPAKLHFIL == GHPGNELIDBM.Enemies)
			{
				return (int)CJKEJNEAFDH & ~BLOHNLJOPIM;
			}
			return (int)ILJHAFNIPMF & ~BLOHNLJOPIM;
		}
		return (int)IGBBFBNFNBJ & ~BLOHNLJOPIM;
	}

	public int MHMMLBHAOCI(GHPGNELIDBM CIOPAKLHFIL, bool MNFCGHNFFFF)
	{
		switch (CIOPAKLHFIL)
		{
		case GHPGNELIDBM.None:
			return (!MNFCGHNFFFF) ? KMHEAJAIJOF : NHFGADFFGDN;
		case (GHPGNELIDBM)5:
			return (!MNFCGHNFFFF) ? DEBNDJGPFIM : DDDHLJCIEEM;
		default:
			return FEFDIKDCGII;
		}
	}

	public static bool IsDestroyableObject(GameObject ECHOPGPBLOK)
	{
		int layer = ECHOPGPBLOK.layer;
		return layer == FEFDIKDCGII || layer == DEBNDJGPFIM || layer == KMHEAJAIJOF || layer == JNCLCGHJAOO || layer == NHFGADFFGDN || layer == DDDHLJCIEEM;
	}

	public int JAKCJDDDKPG(GHPGNELIDBM CIOPAKLHFIL, bool MNFCGHNFFFF)
	{
		switch (CIOPAKLHFIL)
		{
		case GHPGNELIDBM.None:
			return (!MNFCGHNFFFF) ? KMHEAJAIJOF : NHFGADFFGDN;
		case (GHPGNELIDBM)7:
			return (!MNFCGHNFFFF) ? DEBNDJGPFIM : DDDHLJCIEEM;
		default:
			return FEFDIKDCGII;
		}
	}

	public static bool KHKNLLDEBMA(GameObject ECHOPGPBLOK)
	{
		return ECHOPGPBLOK.layer == GIDHAMNOIHG || ECHOPGPBLOK.layer == ALONKNCEAEA;
	}

	public static bool JEIDEFIFCLE(GameObject ECHOPGPBLOK)
	{
		return ECHOPGPBLOK.layer == GIDHAMNOIHG || ECHOPGPBLOK.layer == ALONKNCEAEA;
	}
}
