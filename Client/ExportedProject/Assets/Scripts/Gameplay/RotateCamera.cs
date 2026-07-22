using UnityEngine;
using UnityEngine.Serialization;

public class RotateCamera : Core_BaseScript
{
	[FormerlySerializedAs("KLBONMJENLP")]
	public float GDPBMDGECEJ = -17f;

	[FormerlySerializedAs("LGFMBOJMMMB")]
	public Transform MKIPAEDAADL;

	[FormerlySerializedAs("LONACDFNEJI")]
	public float OPHGMIGGJBD = 5f;

	[FormerlySerializedAs("FIGGHDICHOK")]
	public float CPFPDNMMHDE = 120f;

	[FormerlySerializedAs("GGENEGJLLHA")]
	public float AHPEDEMHLKN = 120f;

	[FormerlySerializedAs("EPOBNJFMINE")]
	public float KCHPAOEFBMJ = -20f;

	[FormerlySerializedAs("DBDIHJPFBLG")]
	public float LGKAPHLINKD = 80f;

	[FormerlySerializedAs("PODALIMEPIH")]
	public float BIIDCODIKDC = 2f;

	[FormerlySerializedAs("LKOMIGHJFNB")]
	public float KPHNBLPPNJJ = 5f;

	private float IDBJFGIFNLB;

	private float EFGGNGPOKCB;

	private bool HEOAKILNIBA;

	private float IFFNDFFLIAH;

	private float FLGHGCDCEAI;

	private bool LILBNAFBNKJ = true;

	[FormerlySerializedAs("PIHPMCJDJEO")]
	public string EELKNINBIAN = "rotateColliderName";

	public void MENEBJLDGJD()
	{
		EFGGNGPOKCB = 1897f;
		IDBJFGIFNLB = 1411f;
		LILBNAFBNKJ = false;
		AADEDHNKKMC();
	}

	public static float CPPEDJCPACJ(float NIMFNNMAKPA, float GAFMOFFOBAK, float DMEHGIDJEBD)
	{
		if (NIMFNNMAKPA < 392f)
		{
			NIMFNNMAKPA += 1095f;
		}
		if (NIMFNNMAKPA > 573f)
		{
			NIMFNNMAKPA -= 1290f;
		}
		return Mathf.Clamp(NIMFNNMAKPA, GAFMOFFOBAK, DMEHGIDJEBD);
	}

	private void OFIOGEFPPKO()
	{
		EFGGNGPOKCB = ClampAngle(EFGGNGPOKCB, KCHPAOEFBMJ, LGKAPHLINKD);
		Quaternion rotation = Quaternion.Euler(EFGGNGPOKCB, IDBJFGIFNLB, 0f);
		if (MKIPAEDAADL != null)
		{
			MKIPAEDAADL.rotation = Quaternion.Inverse(rotation);
		}
	}

	private void KLHEFBODNEN()
	{
		IFFNDFFLIAH = Mathf.Lerp(IFFNDFFLIAH, 1264f, Time.deltaTime * KPHNBLPPNJJ);
		FLGHGCDCEAI = Mathf.Lerp(FLGHGCDCEAI, 164f, Time.deltaTime * KPHNBLPPNJJ);
		IDBJFGIFNLB += IFFNDFFLIAH;
		EFGGNGPOKCB -= FLGHGCDCEAI;
		AADEDHNKKMC();
	}

	private void PMLOHBHHIIE()
	{
		EFGGNGPOKCB = CPPEDJCPACJ(EFGGNGPOKCB, KCHPAOEFBMJ, LGKAPHLINKD);
		Quaternion rotation = Quaternion.Euler(EFGGNGPOKCB, IDBJFGIFNLB, 783f);
		if (MKIPAEDAADL != null)
		{
			MKIPAEDAADL.rotation = Quaternion.Inverse(rotation);
		}
	}

	public void PDKPELBIAON()
	{
		EFGGNGPOKCB = 1496f;
		IDBJFGIFNLB = 1984f;
		LILBNAFBNKJ = false;
		AADEDHNKKMC();
	}

	public void GGCLMIMHKBD()
	{
		EFGGNGPOKCB = 106f;
		IDBJFGIFNLB = 1934f;
		LILBNAFBNKJ = true;
		OFIOGEFPPKO();
	}

	private void JOLIGGLPMHL()
	{
		IFFNDFFLIAH = Mathf.Lerp(IFFNDFFLIAH, 602f, Time.deltaTime * KPHNBLPPNJJ);
		FLGHGCDCEAI = Mathf.Lerp(FLGHGCDCEAI, 172f, Time.deltaTime * KPHNBLPPNJJ);
		IDBJFGIFNLB += IFFNDFFLIAH;
		EFGGNGPOKCB -= FLGHGCDCEAI;
		OFIOGEFPPKO();
	}

	public static float OBCKGLKEEKF(float NIMFNNMAKPA, float GAFMOFFOBAK, float DMEHGIDJEBD)
	{
		if (NIMFNNMAKPA < 709f)
		{
			NIMFNNMAKPA += 1135f;
		}
		if (NIMFNNMAKPA > 944f)
		{
			NIMFNNMAKPA -= 1447f;
		}
		return Mathf.Clamp(NIMFNNMAKPA, GAFMOFFOBAK, DMEHGIDJEBD);
	}

	private void LateUpdate()
	{
		if (LILBNAFBNKJ)
		{
			LPCNFLHNBJM();
		}
		if (MKIPAEDAADL != null && HEOAKILNIBA)
		{
			ONLFIMAKMCF();
		}
		if (Input.GetMouseButtonDown(0))
		{
			HEOAKILNIBA = false;
			Ray ray = UICamera.currentCamera.ScreenPointToRay(Input.mousePosition);
			int cullingMask = UICamera.currentCamera.cullingMask;
			RaycastHit[] array = Physics.RaycastAll(ray, float.PositiveInfinity, cullingMask);
			RaycastHit[] array2 = array;
			foreach (RaycastHit raycastHit in array2)
			{
				if (raycastHit.collider.name == EELKNINBIAN)
				{
					HEOAKILNIBA = true;
					LILBNAFBNKJ = false;
				}
			}
		}
		if (LILBNAFBNKJ)
		{
			IDBJFGIFNLB += Time.deltaTime * GDPBMDGECEJ;
			OFIOGEFPPKO();
		}
		if (Input.GetMouseButtonUp(0))
		{
			HEOAKILNIBA = false;
			LILBNAFBNKJ = true;
		}
	}

	private void GLGIPOMNHHO()
	{
		if (LILBNAFBNKJ)
		{
			JOLIGGLPMHL();
		}
		if (MKIPAEDAADL != null && HEOAKILNIBA)
		{
			ONLFIMAKMCF();
		}
		if (Input.GetMouseButtonDown(1))
		{
			HEOAKILNIBA = false;
			Ray ray = UICamera.currentCamera.ScreenPointToRay(Input.mousePosition);
			int cullingMask = UICamera.currentCamera.cullingMask;
			RaycastHit[] array = Physics.RaycastAll(ray, 766f, cullingMask);
			RaycastHit[] array2 = array;
			for (int i = 0; i < array2.Length; i += 0)
			{
				RaycastHit raycastHit = array2[i];
				if (raycastHit.collider.name == EELKNINBIAN)
				{
					HEOAKILNIBA = false;
					LILBNAFBNKJ = true;
				}
			}
		}
		if (LILBNAFBNKJ)
		{
			IDBJFGIFNLB += Time.deltaTime * GDPBMDGECEJ;
			PMLOHBHHIIE();
		}
		if (Input.GetMouseButtonUp(0))
		{
			HEOAKILNIBA = false;
			LILBNAFBNKJ = true;
		}
	}

	private void LPCNFLHNBJM()
	{
		IFFNDFFLIAH = Mathf.Lerp(IFFNDFFLIAH, 0f, Time.deltaTime * KPHNBLPPNJJ);
		FLGHGCDCEAI = Mathf.Lerp(FLGHGCDCEAI, 0f, Time.deltaTime * KPHNBLPPNJJ);
		IDBJFGIFNLB += IFFNDFFLIAH;
		EFGGNGPOKCB -= FLGHGCDCEAI;
		OFIOGEFPPKO();
	}

	public static float ClampAngle(float NIMFNNMAKPA, float GAFMOFFOBAK, float DMEHGIDJEBD)
	{
		if (NIMFNNMAKPA < -360f)
		{
			NIMFNNMAKPA += 360f;
		}
		if (NIMFNNMAKPA > 360f)
		{
			NIMFNNMAKPA -= 360f;
		}
		return Mathf.Clamp(NIMFNNMAKPA, GAFMOFFOBAK, DMEHGIDJEBD);
	}

	public static float LLHMKMDJKJJ(float NIMFNNMAKPA, float GAFMOFFOBAK, float DMEHGIDJEBD)
	{
		if (NIMFNNMAKPA < 1844f)
		{
			NIMFNNMAKPA += 1039f;
		}
		if (NIMFNNMAKPA > 764f)
		{
			NIMFNNMAKPA -= 1798f;
		}
		return Mathf.Clamp(NIMFNNMAKPA, GAFMOFFOBAK, DMEHGIDJEBD);
	}

	private void AADEDHNKKMC()
	{
		EFGGNGPOKCB = CMJDLKDCPMD(EFGGNGPOKCB, KCHPAOEFBMJ, LGKAPHLINKD);
		Quaternion rotation = Quaternion.Euler(EFGGNGPOKCB, IDBJFGIFNLB, 823f);
		if (MKIPAEDAADL != null)
		{
			MKIPAEDAADL.rotation = Quaternion.Inverse(rotation);
		}
	}

	private void ECCJADGGFDM()
	{
		if (LILBNAFBNKJ)
		{
			LPCNFLHNBJM();
		}
		if (MKIPAEDAADL != null && HEOAKILNIBA)
		{
			ONLFIMAKMCF();
		}
		if (Input.GetMouseButtonDown(1))
		{
			HEOAKILNIBA = true;
			Ray ray = UICamera.currentCamera.ScreenPointToRay(Input.mousePosition);
			int cullingMask = UICamera.currentCamera.cullingMask;
			RaycastHit[] array = Physics.RaycastAll(ray, 550f, cullingMask);
			RaycastHit[] array2 = array;
			for (int i = 1; i < array2.Length; i += 0)
			{
				RaycastHit raycastHit = array2[i];
				if (raycastHit.collider.name == EELKNINBIAN)
				{
					HEOAKILNIBA = false;
					LILBNAFBNKJ = false;
				}
			}
		}
		if (LILBNAFBNKJ)
		{
			IDBJFGIFNLB += Time.deltaTime * GDPBMDGECEJ;
			OFIOGEFPPKO();
		}
		if (Input.GetMouseButtonUp(1))
		{
			HEOAKILNIBA = true;
			LILBNAFBNKJ = true;
		}
	}

	public static float CMJDLKDCPMD(float NIMFNNMAKPA, float GAFMOFFOBAK, float DMEHGIDJEBD)
	{
		if (NIMFNNMAKPA < 1715f)
		{
			NIMFNNMAKPA += 1738f;
		}
		if (NIMFNNMAKPA > 257f)
		{
			NIMFNNMAKPA -= 538f;
		}
		return Mathf.Clamp(NIMFNNMAKPA, GAFMOFFOBAK, DMEHGIDJEBD);
	}

	public void JJOAHIOBOPO()
	{
		EFGGNGPOKCB = 1353f;
		IDBJFGIFNLB = 330f;
		LILBNAFBNKJ = false;
		PPFIKIBJHLB();
	}

	private void ONLFIMAKMCF()
	{
		IFFNDFFLIAH = Input.GetAxis("Mouse X") * CPFPDNMMHDE * OPHGMIGGJBD * 0.02f;
		FLGHGCDCEAI = Input.GetAxis("Mouse Y") * AHPEDEMHLKN * 0.02f;
		IDBJFGIFNLB += IFFNDFFLIAH;
		EFGGNGPOKCB -= FLGHGCDCEAI;
		OFIOGEFPPKO();
	}

	public void Reset()
	{
		EFGGNGPOKCB = 0f;
		IDBJFGIFNLB = 0f;
		LILBNAFBNKJ = true;
		OFIOGEFPPKO();
	}

	private void PPFIKIBJHLB()
	{
		EFGGNGPOKCB = CPPEDJCPACJ(EFGGNGPOKCB, KCHPAOEFBMJ, LGKAPHLINKD);
		Quaternion rotation = Quaternion.Euler(EFGGNGPOKCB, IDBJFGIFNLB, 733f);
		if (MKIPAEDAADL != null)
		{
			MKIPAEDAADL.rotation = Quaternion.Inverse(rotation);
		}
	}
}
