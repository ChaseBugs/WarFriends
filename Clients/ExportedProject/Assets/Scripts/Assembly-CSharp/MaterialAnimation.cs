using UnityEngine;

public class MaterialAnimation : MonoBehaviour
{
	public Vector2 Speed;

	public Vector2 Period;

	public Vector2 Amplitude;

	private Renderer mRenderer;

	private Material mMaterial;

	private Vector2 mCurrentOffset;

	private float mTime;

	private void Start()
	{
		mRenderer = GetComponent<Renderer>();
		mMaterial = mRenderer.sharedMaterial;
	}

	private void Update()
	{
		mTime += Time.deltaTime;
		Vector2 vector = new Vector2(Mathf.Sin(mTime * Period.x) * Amplitude.x, Mathf.Sin(mTime * Period.y) * Amplitude.y);
		mMaterial.mainTextureOffset = mTime * Speed + vector;
	}
}
