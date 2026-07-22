using UnityEngine;

public static class EJLBCNBODJG
{
	public static float CBHCAEBJNOE(float IDEBKDPMPGM)
	{
		if (Mathf.Approximately(IDEBKDPMPGM, 0f))
		{
			return 0f;
		}
		if (Mathf.Approximately(IDEBKDPMPGM, 1f))
		{
			return 1f;
		}
		return Mathf.Clamp01(IDEBKDPMPGM);
	}
}
