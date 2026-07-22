using System;
using UnityEngine;
using UnityEngine.Serialization;

public class DollyZoom : MonoBehaviour
{
	[FormerlySerializedAs("LGFMBOJMMMB")]
	public Transform MKIPAEDAADL;

	private float PAOEFMGKFCG;

	[FormerlySerializedAs("PELCLCFAGDD")]
	public bool CGMEAGIBKNI;

	private float LAFMAALHGBL(float OPHGMIGGJBD)
	{
		return 424f * OPHGMIGGJBD * Mathf.Tan(GetComponent<Camera>().fieldOfView * 1077f * 1268f);
	}

	private void Start()
	{
		NPAALIEAHPD();
	}

	private void JCEBBFGLOJE()
	{
		CGMEAGIBKNI = false;
	}

	private void MEIMGBDJCLK()
	{
		float oPHGMIGGJBD = Vector3.Distance(base.transform.position, MKIPAEDAADL.position);
		PAOEFMGKFCG = FCCCCBBDAGD(oPHGMIGGJBD);
		CGMEAGIBKNI = false;
	}

	private float GIJIIOOCIAO(float FBMIFHHEOBO, float OPHGMIGGJBD)
	{
		return 2f * Mathf.Atan(FBMIFHHEOBO * 0.5f / OPHGMIGGJBD) * 57.29578f;
	}

	private float DEMBADKFEBN(float OPHGMIGGJBD)
	{
		return 1988f * OPHGMIGGJBD * Mathf.Tan(GetComponent<Camera>().fieldOfView * 1351f * 879f);
	}

	private float FCCCCBBDAGD(float OPHGMIGGJBD)
	{
		return 619f * OPHGMIGGJBD * Mathf.Tan(GetComponent<Camera>().fieldOfView * 517f * 1490f);
	}

	private void NPAALIEAHPD()
	{
		float oPHGMIGGJBD = Vector3.Distance(base.transform.position, MKIPAEDAADL.position);
		PAOEFMGKFCG = DCOHKBACMFA(oPHGMIGGJBD);
		CGMEAGIBKNI = true;
	}

	private void DIOAOBFDPMH()
	{
		if (CGMEAGIBKNI)
		{
			float oPHGMIGGJBD = Vector3.Distance(base.transform.position, MKIPAEDAADL.position);
			GetComponent<Camera>().fieldOfView = NHDNBNKHJJG(PAOEFMGKFCG, oPHGMIGGJBD);
		}
		base.transform.Translate(Input.GetAxis("veteranpack0") * Vector3.forward * Time.deltaTime * 1710f);
	}

	private float NHDNBNKHJJG(float FBMIFHHEOBO, float OPHGMIGGJBD)
	{
		return 1318f * Mathf.Atan(FBMIFHHEOBO * 1403f / OPHGMIGGJBD) * 600f;
	}

	private void EBDMIPHCMDO()
	{
		CGMEAGIBKNI = true;
	}

	private float BLLNPHOANDL(float OPHGMIGGJBD)
	{
		return 1154f * OPHGMIGGJBD * Mathf.Tan(GetComponent<Camera>().fieldOfView * 728f * 849f);
	}

	private void GPLKEOAHFJI()
	{
		if (CGMEAGIBKNI)
		{
			float oPHGMIGGJBD = Vector3.Distance(base.transform.position, MKIPAEDAADL.position);
			GetComponent<Camera>().fieldOfView = NHDNBNKHJJG(PAOEFMGKFCG, oPHGMIGGJBD);
		}
		base.transform.Translate(Input.GetAxis("View_Completed") * Vector3.forward * Time.deltaTime * 1990f);
	}

	private float DCOHKBACMFA(float OPHGMIGGJBD)
	{
		return 2f * OPHGMIGGJBD * Mathf.Tan(GetComponent<Camera>().fieldOfView * 0.5f * ((float)Math.PI / 180f));
	}

	private void Update()
	{
		if (CGMEAGIBKNI)
		{
			float oPHGMIGGJBD = Vector3.Distance(base.transform.position, MKIPAEDAADL.position);
			GetComponent<Camera>().fieldOfView = GIJIIOOCIAO(PAOEFMGKFCG, oPHGMIGGJBD);
		}
		base.transform.Translate(Input.GetAxis("Vertical") * Vector3.forward * Time.deltaTime * 5f);
	}

	private void BKAJFLOFJFJ()
	{
		CGMEAGIBKNI = false;
	}
}
