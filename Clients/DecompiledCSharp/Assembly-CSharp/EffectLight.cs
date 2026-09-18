using UnityEngine;

[RequireComponent(typeof(Light))]
public class EffectLight : MonoBehaviour
{
	public float duration = -1f;

	public bool looping;

	public float delay = -1f;

	public float lifetime = -1f;

	public AnimationCurve intensityOverLifetime = new AnimationCurve(new Keyframe(0f, 1f), new Keyframe(1f, 0f));

	public Gradient colorOverLifetime;

	private float startTime;

	private float originalIntensity;

	private Color originalColor;

	private Light targetLight;

	private void Awake()
	{
		UpdateSettings();
	}

	private void OnEnable()
	{
		startTime = Time.time + delay;
	}

	private void Update()
	{
		if (startTime > Time.time || startTime + lifetime < Time.time)
		{
			targetLight.enabled = false;
		}
		else if (startTime + lifetime > Time.time && duration > 0f)
		{
			targetLight.enabled = true;
			float time = (Time.time - startTime) / lifetime;
			targetLight.intensity = originalIntensity * intensityOverLifetime.Evaluate(time);
			targetLight.color = originalColor * colorOverLifetime.Evaluate(time);
		}
		if (looping && startTime + duration < Time.time)
		{
			startTime = Time.time;
		}
	}

	private void UpdateSettings()
	{
		targetLight = GetComponent<Light>();
		originalIntensity = targetLight.intensity;
		originalColor = targetLight.color;
		ParticleSystem particleSystem = null;
		if ((bool)GetComponent<ParticleSystem>())
		{
			particleSystem = GetComponent<ParticleSystem>();
		}
		else if ((bool)base.transform.parent.GetComponent<ParticleSystem>())
		{
			particleSystem = base.transform.parent.GetComponent<ParticleSystem>();
		}
		if (particleSystem != null)
		{
			if (duration < 0f)
			{
				duration = particleSystem.duration;
			}
			if (delay < 0f)
			{
				delay = particleSystem.startDelay;
			}
			if (lifetime < 0f)
			{
				lifetime = particleSystem.startLifetime;
			}
			if (delay > 0f)
			{
				targetLight.enabled = false;
			}
		}
		else
		{
			Debug.LogWarning("Effect light has to be attached to gameobject with a particle system component or to a gameobject whos parent has a particle system component.", base.gameObject);
		}
	}
}
