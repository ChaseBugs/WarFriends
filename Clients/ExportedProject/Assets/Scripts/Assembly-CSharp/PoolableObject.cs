using UnityEngine;

public class PoolableObject : Core_BaseScript
{
	private ObjectPool m_Pool;

	public bool isActivated;

	private bool mIsStared;

	private bool mDestroyInTimeWasCalled;

	public int indexInObjectPool { get; set; }

	public PoolableObject prefab { get; set; }

	public ObjectPool pool
	{
		get
		{
			return m_Pool;
		}
		set
		{
			m_Pool = value;
		}
	}

	public bool isInstantiated { get; set; }

	public Transform poolParent { get; set; }

	protected override void Start()
	{
		base.Start();
		if (!isInstantiated)
		{
			SafeStart();
		}
		mIsStared = true;
		if (!isActivated && !isInstantiated && pool != null)
		{
			base.gameObject.SetActive(value: false);
		}
	}

	public virtual void OnInstancied()
	{
		isInstantiated = true;
		mDestroyInTimeWasCalled = false;
	}

	public void Init()
	{
		if (!mIsStared)
		{
			SafeStart();
		}
	}

	public virtual void BeforeInstancied()
	{
	}

	public virtual void SafeStart()
	{
	}

	public virtual void DestroyPooled()
	{
		if (isInstantiated || pool == null)
		{
			if (pool != null)
			{
				pool.FreeObject(this);
				isInstantiated = false;
				mDestroyInTimeWasCalled = false;
			}
			else
			{
				Object.Destroy(base.gameObject);
			}
		}
	}

	public virtual void DestroyPooled(bool changeParentBack)
	{
		if (changeParentBack)
		{
			base.transform.parent = poolParent;
		}
		DestroyPooled();
	}

	public virtual void DestroyPooled(float time, bool returnToPool = false)
	{
		if ((isInstantiated || pool == null) && !mDestroyInTimeWasCalled)
		{
			if (base.gameObject.activeInHierarchy)
			{
				if (pool == null)
				{
					InvokeAfter(delegate
					{
						DestroyPooled(returnToPool);
					}, time);
				}
				else
				{
					pool.InvokeAfter(delegate
					{
						DestroyPooled(returnToPool);
					}, time);
				}
			}
			else
			{
				DestroyPooled(returnToPool);
			}
		}
		mDestroyInTimeWasCalled = true;
	}
}
