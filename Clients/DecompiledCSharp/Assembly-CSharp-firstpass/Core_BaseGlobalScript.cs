using UnityEngine;

public class Core_BaseGlobalScript : Core_BaseScript
{
	private bool _isInitialized;

	public bool IsInitialized => _isInitialized;

	protected override void Awake()
	{
		base.Awake();
		Object.DontDestroyOnLoad(this);
		_isInitialized = true;
	}

	protected virtual void Awake_Safe()
	{
	}

	public virtual void InitForEditor()
	{
		_isInitialized = true;
	}
}
