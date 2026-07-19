using UnityEngine;

public class WaitForAnimation : CoroutineReturn
{
	private GameObject _go;

	private string _name;

	private float _time;

	private float _weight;

	private int startFrame;

	public string name
	{
		get
		{
			return _name;
		}
	}

	public override bool finished
	{
		get
		{
			if (Time.frameCount <= startFrame + 1)
			{
				return false;
			}
			if (_weight == -1f)
			{
				return !_go.GetComponent<Animation>()[_name].enabled || _go.GetComponent<Animation>()[_name].normalizedTime >= _time || _go.GetComponent<Animation>()[_name].weight == 0f || _go.GetComponent<Animation>()[_name].speed == 0f;
			}
			if ((double)_weight < 0.5)
			{
				return _go.GetComponent<Animation>()[_name].weight <= Mathf.Clamp01(_weight);
			}
			return _go.GetComponent<Animation>()[_name].weight >= Mathf.Clamp01(_weight);
		}
		set
		{
			base.finished = value;
		}
	}

	public WaitForAnimation(GameObject go, string name, float time = 1f, float weight = -1f)
	{
		startFrame = Time.frameCount;
		_go = go;
		_name = name;
		_time = Mathf.Clamp01(time);
		_weight = weight;
	}
}
