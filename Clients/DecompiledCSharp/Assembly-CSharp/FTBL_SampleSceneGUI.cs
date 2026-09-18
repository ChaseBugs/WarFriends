using UnityEngine;

public class FTBL_SampleSceneGUI : MonoBehaviour
{
	public GUIText prefabName;

	public GameObject[] particlePrefab;

	public int particleNum;

	private GameObject effectPrefab;

	private void Start()
	{
	}

	private void Update()
	{
		if (Input.GetMouseButtonDown(0))
		{
			if (particleNum == 0)
			{
				Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
				if (Physics.Raycast(ray, out var hitInfo, 1000f))
				{
					effectPrefab = (GameObject)Object.Instantiate(particlePrefab[particleNum], new Vector3(hitInfo.point.x, hitInfo.point.y, hitInfo.point.z), Quaternion.Euler(0f, 0f, 0f));
					return;
				}
			}
			if (particleNum < 2)
			{
				Ray ray2 = Camera.main.ScreenPointToRay(Input.mousePosition);
				if (Physics.Raycast(ray2, out var hitInfo2, 1000f))
				{
					effectPrefab = (GameObject)Object.Instantiate(particlePrefab[particleNum], new Vector3(hitInfo2.point.x, hitInfo2.point.y + 2.1f, hitInfo2.point.z), Quaternion.Euler(0f, 0f, 0f));
				}
			}
			else
			{
				Ray ray3 = Camera.main.ScreenPointToRay(Input.mousePosition);
				if (Physics.Raycast(ray3, out var hitInfo3, 1000f))
				{
					effectPrefab = (GameObject)Object.Instantiate(particlePrefab[particleNum], new Vector3(hitInfo3.point.x, hitInfo3.point.y, hitInfo3.point.z), Quaternion.Euler(0f, 0f, 0f));
				}
			}
		}
		if (Input.GetKeyDown(KeyCode.LeftArrow))
		{
			Object.Destroy(effectPrefab);
			particleNum--;
			if (particleNum < 0)
			{
				particleNum = particlePrefab.Length - 1;
			}
		}
		if (Input.GetKeyDown(KeyCode.RightArrow))
		{
			Object.Destroy(effectPrefab);
			particleNum++;
			if (particleNum > particlePrefab.Length - 1)
			{
				particleNum = 0;
			}
		}
		prefabName.text = particlePrefab[particleNum].name;
	}
}
