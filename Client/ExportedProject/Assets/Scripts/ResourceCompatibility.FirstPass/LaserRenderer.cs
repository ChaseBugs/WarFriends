using UnityEngine;

public class LaserRenderer : MonoBehaviour
{
	public Material zangyMaterial;

	public Material lineMaterial;

	public Vector2 textureOffsetSpeeds;

	public bool lookAtCamera;

	public Vector3 laserEndPoint;

	public float laserWidth;

	public Renderer[] renderers;

	public ParticleSystem startingParticle;

	public ParticleSystem endingParticle;

	public Color innerWhiteColor;

	public Color tintColor;

	private Camera mainCamera;

	public void ChangeCamera(Camera cam)
	{
	}

	private void Start()
	{
	}

	private void LateUpdate()
	{
	}

	private void OnEndPointChanged()
	{
	}

	private void OnTintColorChanged()
	{
	}

	private void OnLaserWidthChanged()
	{
	}
}
