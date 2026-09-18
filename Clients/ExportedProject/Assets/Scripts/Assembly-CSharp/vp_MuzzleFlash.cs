using UnityEngine;

public class vp_MuzzleFlash : MonoBehaviour
{
	protected float m_FadeSpeed = 0.065f;

	public bool m_ForceShow;

	protected Color m_Color = new Color(1f, 1f, 1f, 0f);

	private Renderer mRenderer;

	private bool mIgnoreTimeScale;

	private void Awake()
	{
		m_Color = GetComponent<Renderer>().material.GetColor("_TintColor");
		m_Color.a = 0f;
		m_ForceShow = false;
		mRenderer = GetComponent<Renderer>();
	}

	private void Update()
	{
		if (m_ForceShow)
		{
			Show();
		}
		else if (m_Color.a > 0f)
		{
			m_Color.a -= m_FadeSpeed * Time.deltaTime * 60f;
		}
		else
		{
			base.gameObject.SetActive(value: false);
		}
		mRenderer.material.SetColor("_TintColor", m_Color);
	}

	public void Show()
	{
		m_Color.a = 0.5f;
	}

	public void Shoot()
	{
		base.transform.Rotate(0f, 0f, Random.Range(0, 360));
		m_Color.a = 0.5f;
	}

	public void Shoot(bool ignoreTimeScale)
	{
		mIgnoreTimeScale = ignoreTimeScale;
		base.gameObject.SetActive(value: true);
		base.transform.Rotate(0f, 0f, Random.Range(0, 360));
		m_Color.a = 0.6f;
	}
}
