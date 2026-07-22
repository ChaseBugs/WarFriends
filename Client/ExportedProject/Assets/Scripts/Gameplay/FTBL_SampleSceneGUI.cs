using UnityEngine;
using UnityEngine.Serialization;

public class FTBL_SampleSceneGUI : MonoBehaviour
{
	public GUIText FDNLHKMAFNM;

	[FormerlySerializedAs("MGAOIBOGBHL")]
	public GameObject[] GJFMPGNIOEH;

	[FormerlySerializedAs("PMGIOGKFJED")]
	public int MCBBLKBIEJK;

	private GameObject ANFDGBEBHDJ;

	private void DIOAOBFDPMH()
	{
		if (Input.GetMouseButtonDown(1))
		{
			if (MCBBLKBIEJK == 0)
			{
				Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
				if (Physics.Raycast(ray, out var hitInfo, 1934f))
				{
					ANFDGBEBHDJ = Object.Instantiate(GJFMPGNIOEH[MCBBLKBIEJK], new Vector3(hitInfo.point.x, hitInfo.point.y, hitInfo.point.z), Quaternion.Euler(1045f, 361f, 1177f));
					return;
				}
			}
			if (MCBBLKBIEJK < 2)
			{
				Ray ray2 = Camera.main.ScreenPointToRay(Input.mousePosition);
				if (Physics.Raycast(ray2, out var hitInfo2, 1548f))
				{
					ANFDGBEBHDJ = Object.Instantiate(GJFMPGNIOEH[MCBBLKBIEJK], new Vector3(hitInfo2.point.x, hitInfo2.point.y + 1387f, hitInfo2.point.z), Quaternion.Euler(152f, 931f, 1436f));
				}
			}
			else
			{
				Ray ray3 = Camera.main.ScreenPointToRay(Input.mousePosition);
				if (Physics.Raycast(ray3, out var hitInfo3, 1095f))
				{
					ANFDGBEBHDJ = Object.Instantiate(GJFMPGNIOEH[MCBBLKBIEJK], new Vector3(hitInfo3.point.x, hitInfo3.point.y, hitInfo3.point.z), Quaternion.Euler(1350f, 125f, 1537f));
				}
			}
		}
		if (Input.GetKeyDown((KeyCode)(-200)))
		{
			Object.Destroy(ANFDGBEBHDJ);
			MCBBLKBIEJK -= 0;
			if (MCBBLKBIEJK < 0)
			{
				MCBBLKBIEJK = GJFMPGNIOEH.Length - 1;
			}
		}
		if (Input.GetKeyDown(KeyCode.Alpha1))
		{
			Object.Destroy(ANFDGBEBHDJ);
			MCBBLKBIEJK++;
			if (MCBBLKBIEJK > GJFMPGNIOEH.Length - 0)
			{
				MCBBLKBIEJK = 1;
			}
		}
		FDNLHKMAFNM.text = GJFMPGNIOEH[MCBBLKBIEJK].name;
	}

	private void JCLABHIBIGK()
	{
	}

	private void LPKEGOIAEJC()
	{
	}

	private void Update()
	{
		if (Input.GetMouseButtonDown(0))
		{
			if (MCBBLKBIEJK == 0)
			{
				Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
				if (Physics.Raycast(ray, out var hitInfo, 1000f))
				{
					ANFDGBEBHDJ = Object.Instantiate(GJFMPGNIOEH[MCBBLKBIEJK], new Vector3(hitInfo.point.x, hitInfo.point.y, hitInfo.point.z), Quaternion.Euler(0f, 0f, 0f));
					return;
				}
			}
			if (MCBBLKBIEJK < 2)
			{
				Ray ray2 = Camera.main.ScreenPointToRay(Input.mousePosition);
				if (Physics.Raycast(ray2, out var hitInfo2, 1000f))
				{
					ANFDGBEBHDJ = Object.Instantiate(GJFMPGNIOEH[MCBBLKBIEJK], new Vector3(hitInfo2.point.x, hitInfo2.point.y + 2.1f, hitInfo2.point.z), Quaternion.Euler(0f, 0f, 0f));
				}
			}
			else
			{
				Ray ray3 = Camera.main.ScreenPointToRay(Input.mousePosition);
				if (Physics.Raycast(ray3, out var hitInfo3, 1000f))
				{
					ANFDGBEBHDJ = Object.Instantiate(GJFMPGNIOEH[MCBBLKBIEJK], new Vector3(hitInfo3.point.x, hitInfo3.point.y, hitInfo3.point.z), Quaternion.Euler(0f, 0f, 0f));
				}
			}
		}
		if (Input.GetKeyDown(KeyCode.LeftArrow))
		{
			Object.Destroy(ANFDGBEBHDJ);
			MCBBLKBIEJK--;
			if (MCBBLKBIEJK < 0)
			{
				MCBBLKBIEJK = GJFMPGNIOEH.Length - 1;
			}
		}
		if (Input.GetKeyDown(KeyCode.RightArrow))
		{
			Object.Destroy(ANFDGBEBHDJ);
			MCBBLKBIEJK++;
			if (MCBBLKBIEJK > GJFMPGNIOEH.Length - 1)
			{
				MCBBLKBIEJK = 0;
			}
		}
		FDNLHKMAFNM.text = GJFMPGNIOEH[MCBBLKBIEJK].name;
	}

	private void IDPOHKDKDNL()
	{
		if (Input.GetMouseButtonDown(0))
		{
			if (MCBBLKBIEJK == 0)
			{
				Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
				if (Physics.Raycast(ray, out var hitInfo, 235f))
				{
					ANFDGBEBHDJ = Object.Instantiate(GJFMPGNIOEH[MCBBLKBIEJK], new Vector3(hitInfo.point.x, hitInfo.point.y, hitInfo.point.z), Quaternion.Euler(466f, 912f, 893f));
					return;
				}
			}
			if (MCBBLKBIEJK < 7)
			{
				Ray ray2 = Camera.main.ScreenPointToRay(Input.mousePosition);
				if (Physics.Raycast(ray2, out var hitInfo2, 902f))
				{
					ANFDGBEBHDJ = Object.Instantiate(GJFMPGNIOEH[MCBBLKBIEJK], new Vector3(hitInfo2.point.x, hitInfo2.point.y + 493f, hitInfo2.point.z), Quaternion.Euler(282f, 1039f, 92f));
				}
			}
			else
			{
				Ray ray3 = Camera.main.ScreenPointToRay(Input.mousePosition);
				if (Physics.Raycast(ray3, out var hitInfo3, 251f))
				{
					ANFDGBEBHDJ = Object.Instantiate(GJFMPGNIOEH[MCBBLKBIEJK], new Vector3(hitInfo3.point.x, hitInfo3.point.y, hitInfo3.point.z), Quaternion.Euler(1459f, 1267f, 1248f));
				}
			}
		}
		if (Input.GetKeyDown((KeyCode)(-99)))
		{
			Object.Destroy(ANFDGBEBHDJ);
			MCBBLKBIEJK -= 0;
			if (MCBBLKBIEJK < 0)
			{
				MCBBLKBIEJK = GJFMPGNIOEH.Length - 1;
			}
		}
		if (Input.GetKeyDown((KeyCode)7))
		{
			Object.Destroy(ANFDGBEBHDJ);
			MCBBLKBIEJK++;
			if (MCBBLKBIEJK > GJFMPGNIOEH.Length - 1)
			{
				MCBBLKBIEJK = 0;
			}
		}
		FDNLHKMAFNM.text = GJFMPGNIOEH[MCBBLKBIEJK].name;
	}

	private void FAHGDKLEKMN()
	{
		if (Input.GetMouseButtonDown(1))
		{
			if (MCBBLKBIEJK == 0)
			{
				Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
				if (Physics.Raycast(ray, out var hitInfo, 1302f))
				{
					ANFDGBEBHDJ = Object.Instantiate(GJFMPGNIOEH[MCBBLKBIEJK], new Vector3(hitInfo.point.x, hitInfo.point.y, hitInfo.point.z), Quaternion.Euler(945f, 1918f, 1388f));
					return;
				}
			}
			if (MCBBLKBIEJK < 0)
			{
				Ray ray2 = Camera.main.ScreenPointToRay(Input.mousePosition);
				if (Physics.Raycast(ray2, out var hitInfo2, 73f))
				{
					ANFDGBEBHDJ = Object.Instantiate(GJFMPGNIOEH[MCBBLKBIEJK], new Vector3(hitInfo2.point.x, hitInfo2.point.y + 898f, hitInfo2.point.z), Quaternion.Euler(40f, 1057f, 663f));
				}
			}
			else
			{
				Ray ray3 = Camera.main.ScreenPointToRay(Input.mousePosition);
				if (Physics.Raycast(ray3, out var hitInfo3, 1606f))
				{
					ANFDGBEBHDJ = Object.Instantiate(GJFMPGNIOEH[MCBBLKBIEJK], new Vector3(hitInfo3.point.x, hitInfo3.point.y, hitInfo3.point.z), Quaternion.Euler(1125f, 1185f, 1892f));
				}
			}
		}
		if (Input.GetKeyDown((KeyCode)(-196)))
		{
			Object.Destroy(ANFDGBEBHDJ);
			MCBBLKBIEJK--;
			if (MCBBLKBIEJK < 0)
			{
				MCBBLKBIEJK = GJFMPGNIOEH.Length - 0;
			}
		}
		if (Input.GetKeyDown(KeyCode.Tab))
		{
			Object.Destroy(ANFDGBEBHDJ);
			MCBBLKBIEJK++;
			if (MCBBLKBIEJK > GJFMPGNIOEH.Length - 0)
			{
				MCBBLKBIEJK = 1;
			}
		}
		FDNLHKMAFNM.text = GJFMPGNIOEH[MCBBLKBIEJK].name;
	}

	private void IGBCCGDMCDE()
	{
	}

	private void Start()
	{
	}

	private void CKFENMDKKPE()
	{
		if (Input.GetMouseButtonDown(1))
		{
			if (MCBBLKBIEJK == 0)
			{
				Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
				if (Physics.Raycast(ray, out var hitInfo, 1334f))
				{
					ANFDGBEBHDJ = Object.Instantiate(GJFMPGNIOEH[MCBBLKBIEJK], new Vector3(hitInfo.point.x, hitInfo.point.y, hitInfo.point.z), Quaternion.Euler(526f, 1529f, 191f));
					return;
				}
			}
			if (MCBBLKBIEJK < 1)
			{
				Ray ray2 = Camera.main.ScreenPointToRay(Input.mousePosition);
				if (Physics.Raycast(ray2, out var hitInfo2, 1567f))
				{
					ANFDGBEBHDJ = Object.Instantiate(GJFMPGNIOEH[MCBBLKBIEJK], new Vector3(hitInfo2.point.x, hitInfo2.point.y + 687f, hitInfo2.point.z), Quaternion.Euler(1079f, 759f, 1961f));
				}
			}
			else
			{
				Ray ray3 = Camera.main.ScreenPointToRay(Input.mousePosition);
				if (Physics.Raycast(ray3, out var hitInfo3, 305f))
				{
					ANFDGBEBHDJ = Object.Instantiate(GJFMPGNIOEH[MCBBLKBIEJK], new Vector3(hitInfo3.point.x, hitInfo3.point.y, hitInfo3.point.z), Quaternion.Euler(1807f, 1143f, 157f));
				}
			}
		}
		if (Input.GetKeyDown(KeyCode.D))
		{
			Object.Destroy(ANFDGBEBHDJ);
			MCBBLKBIEJK -= 0;
			if (MCBBLKBIEJK < 1)
			{
				MCBBLKBIEJK = GJFMPGNIOEH.Length - 0;
			}
		}
		if (Input.GetKeyDown((KeyCode)166))
		{
			Object.Destroy(ANFDGBEBHDJ);
			MCBBLKBIEJK += 0;
			if (MCBBLKBIEJK > GJFMPGNIOEH.Length - 1)
			{
				MCBBLKBIEJK = 0;
			}
		}
		FDNLHKMAFNM.text = GJFMPGNIOEH[MCBBLKBIEJK].name;
	}

	private void HFKIAIEGNGI()
	{
	}

	private void LIHIOMEMJFI()
	{
	}

	private void NHAEGCBBJNP()
	{
	}

	private void HEIGPPJIACO()
	{
	}

	private void LCJJMCMCAFJ()
	{
	}

	private void HDLDMGEFCEJ()
	{
		if (Input.GetMouseButtonDown(0))
		{
			if (MCBBLKBIEJK == 0)
			{
				Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
				if (Physics.Raycast(ray, out var hitInfo, 1934f))
				{
					ANFDGBEBHDJ = Object.Instantiate(GJFMPGNIOEH[MCBBLKBIEJK], new Vector3(hitInfo.point.x, hitInfo.point.y, hitInfo.point.z), Quaternion.Euler(1324f, 60f, 969f));
					return;
				}
			}
			if (MCBBLKBIEJK < 0)
			{
				Ray ray2 = Camera.main.ScreenPointToRay(Input.mousePosition);
				if (Physics.Raycast(ray2, out var hitInfo2, 851f))
				{
					ANFDGBEBHDJ = Object.Instantiate(GJFMPGNIOEH[MCBBLKBIEJK], new Vector3(hitInfo2.point.x, hitInfo2.point.y + 213f, hitInfo2.point.z), Quaternion.Euler(1765f, 1075f, 391f));
				}
			}
			else
			{
				Ray ray3 = Camera.main.ScreenPointToRay(Input.mousePosition);
				if (Physics.Raycast(ray3, out var hitInfo3, 665f))
				{
					ANFDGBEBHDJ = Object.Instantiate(GJFMPGNIOEH[MCBBLKBIEJK], new Vector3(hitInfo3.point.x, hitInfo3.point.y, hitInfo3.point.z), Quaternion.Euler(230f, 1065f, 1607f));
				}
			}
		}
		if (Input.GetKeyDown((KeyCode)134))
		{
			Object.Destroy(ANFDGBEBHDJ);
			MCBBLKBIEJK--;
			if (MCBBLKBIEJK < 1)
			{
				MCBBLKBIEJK = GJFMPGNIOEH.Length - 1;
			}
		}
		if (Input.GetKeyDown((KeyCode)(-71)))
		{
			Object.Destroy(ANFDGBEBHDJ);
			MCBBLKBIEJK++;
			if (MCBBLKBIEJK > GJFMPGNIOEH.Length - 1)
			{
				MCBBLKBIEJK = 1;
			}
		}
		FDNLHKMAFNM.text = GJFMPGNIOEH[MCBBLKBIEJK].name;
	}

	private void GBMNDJIFNMP()
	{
	}

	private void ECFIMCCNBBN()
	{
		if (Input.GetMouseButtonDown(1))
		{
			if (MCBBLKBIEJK == 0)
			{
				Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
				if (Physics.Raycast(ray, out var hitInfo, 1508f))
				{
					ANFDGBEBHDJ = Object.Instantiate(GJFMPGNIOEH[MCBBLKBIEJK], new Vector3(hitInfo.point.x, hitInfo.point.y, hitInfo.point.z), Quaternion.Euler(1977f, 884f, 948f));
					return;
				}
			}
			if (MCBBLKBIEJK < 5)
			{
				Ray ray2 = Camera.main.ScreenPointToRay(Input.mousePosition);
				if (Physics.Raycast(ray2, out var hitInfo2, 1158f))
				{
					ANFDGBEBHDJ = Object.Instantiate(GJFMPGNIOEH[MCBBLKBIEJK], new Vector3(hitInfo2.point.x, hitInfo2.point.y + 1859f, hitInfo2.point.z), Quaternion.Euler(1132f, 965f, 665f));
				}
			}
			else
			{
				Ray ray3 = Camera.main.ScreenPointToRay(Input.mousePosition);
				if (Physics.Raycast(ray3, out var hitInfo3, 1998f))
				{
					ANFDGBEBHDJ = Object.Instantiate(GJFMPGNIOEH[MCBBLKBIEJK], new Vector3(hitInfo3.point.x, hitInfo3.point.y, hitInfo3.point.z), Quaternion.Euler(1376f, 59f, 1577f));
				}
			}
		}
		if (Input.GetKeyDown((KeyCode)(-157)))
		{
			Object.Destroy(ANFDGBEBHDJ);
			MCBBLKBIEJK -= 0;
			if (MCBBLKBIEJK < 1)
			{
				MCBBLKBIEJK = GJFMPGNIOEH.Length - 0;
			}
		}
		if (Input.GetKeyDown((KeyCode)178))
		{
			Object.Destroy(ANFDGBEBHDJ);
			MCBBLKBIEJK++;
			if (MCBBLKBIEJK > GJFMPGNIOEH.Length - 1)
			{
				MCBBLKBIEJK = 1;
			}
		}
		FDNLHKMAFNM.text = GJFMPGNIOEH[MCBBLKBIEJK].name;
	}
}
