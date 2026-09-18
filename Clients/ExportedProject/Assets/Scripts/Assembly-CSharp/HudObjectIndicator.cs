using System.Collections;
using System.Collections.Specialized;
using UnityEngine;

[RequireComponent(typeof(PoolableObject))]
public class HudObjectIndicator : Core_BaseScript
{
	public enum IndicatorAnimation
	{
		CardIco,
		InfoIco,
		EngineerIco,
		None
	}

	private Transform mTransform;

	private Transform mAinCameraTransform;

	private Transform m2DCameraTransform;

	public Transform snapTransform;

	public bool show = true;

	public string spriteName;

	private OrderedDictionary mIndicators = new OrderedDictionary();

	private Transform mIndicatorsParentTransform;

	private float mCurrentWidth;

	public Vector3 indicatorOffset;

	public bool alwaysOnTop;

	public bool updateScale;

	private Vector3 mOffset;

	protected override void Awake()
	{
		base.Awake();
		mTransform = base.transform;
		m2DCameraTransform = HealthBarManager.instance.guiCamera.transform;
		mAinCameraTransform = Singleton<GameCamera>.instance.transform;
		GameObject gameObject = new GameObject("iconParent");
		gameObject.transform.parent = Singleton<GameCamera>.instance.cameraHUD.transform;
		mIndicatorsParentTransform = gameObject.transform;
		if (show)
		{
			AddIndicator(spriteName, Color.white);
		}
	}

	private void OnEnable()
	{
		if (show)
		{
			mIndicatorsParentTransform.gameObject.SetActive(value: true);
		}
		else
		{
			mIndicatorsParentTransform.gameObject.SetActive(value: false);
		}
	}

	public void Reset()
	{
		if (mIndicatorsParentTransform != null)
		{
			mIndicatorsParentTransform.gameObject.SetActive(value: false);
		}
		IDictionaryEnumerator enumerator = mIndicators.GetEnumerator();
		while (enumerator.MoveNext())
		{
			HudObjectIndicator2D hudObjectIndicator2D = (HudObjectIndicator2D)enumerator.Value;
			hudObjectIndicator2D.DestroyPooled(changeParentBack: true);
		}
		mIndicators.Clear();
		mCurrentWidth = 0f;
	}

	private void OnDisable()
	{
		Reset();
	}

	public void Show(bool value)
	{
		Show(spriteName, value, IndicatorAnimation.InfoIco);
		show = value;
	}

	public void Disable()
	{
		mIndicatorsParentTransform.gameObject.SetActive(value: false);
	}

	public void RemoveAllIconExceptDeathIco()
	{
		object[] array = new object[mIndicators.Count];
		mIndicators.Keys.CopyTo(array, 0);
		for (int i = 0; i < array.Length; i++)
		{
			if (array[i] is string && array[i] as string != "game-card-ico-backstab")
			{
				RemoveIndicator(array[i] as string);
			}
		}
	}

	public string ConvertSpriteIDtoSpriteName(int id)
	{
		tk2dSpriteDefinition[] spriteDefinitions = Singleton<ObjectPoolDatabase>.instance.indicator.sprite.Collection.spriteDefinitions;
		if (id >= 0 && id < spriteDefinitions.Length)
		{
			return spriteDefinitions[id].name;
		}
		return string.Empty;
	}

	public void Hide(string spriteName, float destroyTime = 0.5f)
	{
		RemoveIndicator(spriteName, IndicatorAnimation.None, destroyTime);
	}

	public int Show(string spriteName, bool value, IndicatorAnimation anim)
	{
		if (value)
		{
			mIndicatorsParentTransform.gameObject.SetActive(value);
		}
		HudObjectIndicator2D hudObjectIndicator2D = null;
		if (value)
		{
			hudObjectIndicator2D = AddIndicator(spriteName, Color.white, anim);
			if (hudObjectIndicator2D != null)
			{
				return hudObjectIndicator2D.sprite.spriteId;
			}
			return -1;
		}
		return RemoveIndicator(spriteName, anim);
	}

	public int Show(string spriteName, bool value, IndicatorAnimation anim, Color iconColor)
	{
		if (value)
		{
			mIndicatorsParentTransform.gameObject.SetActive(value);
		}
		HudObjectIndicator2D hudObjectIndicator2D = null;
		if (value)
		{
			hudObjectIndicator2D = AddIndicator(spriteName, iconColor, anim);
			if (hudObjectIndicator2D != null)
			{
				return hudObjectIndicator2D.sprite.spriteId;
			}
			return -1;
		}
		return RemoveIndicator(spriteName, anim);
	}

	private HudObjectIndicator2D AddIndicator(string sprName, Color iconColor, IndicatorAnimation anim = IndicatorAnimation.InfoIco)
	{
		if (string.IsNullOrEmpty(sprName))
		{
			Debug.Log("trying to add emty indicator " + base.gameObject.name);
		}
		HudObjectIndicator2D indicator;
		if (mIndicators.Contains(sprName))
		{
			indicator = (HudObjectIndicator2D)mIndicators[sprName];
			return indicator;
		}
		indicator = (HudObjectIndicator2D)Singleton<ObjectPoolDatabase>.instance.mainObjectPool.Instantiate(Singleton<ObjectPoolDatabase>.instance.indicator);
		if (indicator == null)
		{
			return null;
		}
		indicator.border.gameObject.SetActive(value: false);
		indicator.transparentBG.gameObject.SetActive(value: false);
		indicator.transform.parent = mIndicatorsParentTransform;
		indicator.transform.localScale = Vector3.one;
		indicator.progress = 1f;
		mIndicators.Add(sprName, indicator);
		indicator.colour = iconColor;
		indicator.SetSprite(sprName);
		mCurrentWidth += indicator.sprite.GetBounds().size.x;
		Vector3 vector = new Vector3(0f - mCurrentWidth * 0.5f, 0f, 0f);
		IDictionaryEnumerator enumerator = mIndicators.GetEnumerator();
		while (enumerator.MoveNext())
		{
			HudObjectIndicator2D hudObjectIndicator2D = (HudObjectIndicator2D)enumerator.Value;
			Bounds bounds = hudObjectIndicator2D.sprite.GetBounds();
			Vector3 position = vector + new Vector3(bounds.size.x * 0.5f, 0f, 0f);
			if (hudObjectIndicator2D == indicator)
			{
				switch (anim)
				{
				case IndicatorAnimation.CardIco:
				{
					Vector3 topPos = position + new Vector3(0f, 5f, 0f);
					indicator.transform.localPosition = vector;
					TweenPosition tweenPosition = TweenPosition.Begin(indicator.gameObject, 0.2f, position, topPos);
					tweenPosition.delay = 0.23f;
					tweenPosition.onFinished = delegate
					{
						TweenPosition.Begin(indicator.gameObject, 0.2f, topPos, position).delay = 0f;
						indicator.transparentBG.SetSprite(sprName);
						indicator.border.SetSprite("game-card-ico-stroke");
						indicator.border.SortingOrder = 20;
						indicator.border.gameObject.SetActive(value: true);
						indicator.transparentBG.gameObject.SetActive(value: true);
					};
					break;
				}
				case IndicatorAnimation.EngineerIco:
				{
					Vector3 vector3 = position + new Vector3(0f, bounds.size.y * -0.25f, 0f);
					indicator.transform.localPosition = vector3;
					TweenPosition.Begin(indicator.gameObject, 0.2f, vector3, position).delay = 0.2f;
					indicator.border.SetSprite("game-engi-progress-bg");
					indicator.border.SortingOrder = -1;
					indicator.border.gameObject.SetActive(value: true);
					break;
				}
				default:
				{
					Vector3 vector2 = position + new Vector3(0f, bounds.size.y * 6f, 0f);
					indicator.transform.localPosition = vector2;
					TweenPosition.Begin(indicator.gameObject, 0.2f, vector2, position).delay = 0.2f;
					break;
				}
				}
				Color color = indicator.sprite.color;
				color.a = 0f;
				indicator.sprite.color = color;
				TweenAlphaTk2d.Begin(indicator.sprite.gameObject, 0.2f, 1f).delay = 0.2f;
			}
			else
			{
				TweenPosition.Begin(hudObjectIndicator2D.gameObject, 0.2f, position).delay = 0f;
			}
			vector += new Vector3(bounds.size.x, 0f, 0f);
		}
		return indicator;
	}

	private int RemoveIndicator(string sprName, IndicatorAnimation anim = IndicatorAnimation.InfoIco, float destroyTime = 0.5f)
	{
		float delay = ((anim != IndicatorAnimation.CardIco) ? 0f : 0.1f);
		int result = -1;
		if (mIndicators.Contains(sprName))
		{
			HudObjectIndicator2D indicator = (HudObjectIndicator2D)mIndicators[sprName];
			mIndicators.Remove(sprName);
			result = indicator.sprite.spriteId;
			Bounds bounds = indicator.sprite.GetBounds();
			mCurrentWidth -= bounds.size.x;
			Vector3 vector = new Vector3(0f - mCurrentWidth * 0.5f, 0f, 0f);
			IDictionaryEnumerator enumerator = mIndicators.GetEnumerator();
			while (enumerator.MoveNext())
			{
				HudObjectIndicator2D hudObjectIndicator2D = (HudObjectIndicator2D)enumerator.Value;
				Bounds bounds2 = hudObjectIndicator2D.sprite.GetBounds();
				Vector3 pos = vector + new Vector3(bounds2.size.x * 0.5f, 0f, 0f);
				TweenPosition.Begin(hudObjectIndicator2D.gameObject, 0.3f, pos).delay = delay;
				vector += new Vector3(bounds2.size.x, 0f, 0f);
			}
			switch (anim)
			{
			case IndicatorAnimation.CardIco:
			{
				TweenAlphaTk2d ta = TweenAlphaTk2d.Begin(indicator.sprite.gameObject, 0.08f, 0f);
				ta.delay = 0f;
				ta.onFinished = delegate
				{
					indicator.progress = 1f;
					ta = TweenAlphaTk2d.Begin(indicator.sprite.gameObject, 0.08f, 1f);
					ta.onFinished = delegate
					{
						ta = TweenAlphaTk2d.Begin(indicator.sprite.gameObject, 0.08f, 0f);
						ta.onFinished = delegate
						{
							ta = TweenAlphaTk2d.Begin(indicator.sprite.gameObject, 0.08f, 1f);
							ta.onFinished = delegate
							{
								ta = TweenAlphaTk2d.Begin(indicator.sprite.gameObject, 0.08f, 0f);
							};
						};
					};
				};
				break;
			}
			case IndicatorAnimation.EngineerIco:
				TweenPosition.Begin(indicator.gameObject, 0.2f, indicator.gameObject.transform.localPosition - new Vector3(0f, bounds.size.y * -0.25f, 0f)).delay = 0f;
				break;
			default:
				TweenPosition.Begin(indicator.gameObject, 0.2f, indicator.gameObject.transform.localPosition - new Vector3(0f, bounds.size.y * 6f, 0f)).delay = 0f;
				TweenAlphaTk2d.Begin(indicator.sprite.gameObject, 0.2f, 0f).delay = 0f;
				break;
			}
			indicator.DestroyPooled(destroyTime, returnToPool: true);
		}
		return result;
	}

	protected void Update()
	{
		if (mIndicatorsParentTransform.gameObject.activeInHierarchy)
		{
			if (updateScale)
			{
				float num = Vector3.Distance(mTransform.position, mAinCameraTransform.position);
				Vector3 vector = new Vector3(5.5f / num, 5.5f / num, 5.5f / num);
				vector = Vector3.ClampMagnitude(vector, 2.3f);
				mIndicatorsParentTransform.localScale = vector;
				mOffset = Vector3.Scale(indicatorOffset, vector);
			}
			if (alwaysOnTop)
			{
				Vector3 vector2 = m2DCameraTransform.position + new Vector3(0f, 0f, HealthBarManager.instance.guiCamera.nearClipPlane + 3f);
				Vector3 point = Singleton<GameCamera>.instance.camera.WorldToNormalizedViewportPoint((!(snapTransform != null)) ? mTransform.position : snapTransform.position);
				point = HealthBarManager.instance.guiCamera.NormalizedViewportToWorldPoint(point);
				point.z = vector2.z;
				mIndicatorsParentTransform.position = point + mOffset;
			}
			else
			{
				Vector3 point2 = Singleton<GameCamera>.instance.camera.WorldToNormalizedViewportPoint((!(snapTransform != null)) ? mTransform.position : snapTransform.position);
				mIndicatorsParentTransform.position = HealthBarManager.instance.guiCamera.NormalizedViewportToWorldPoint(point2) + mOffset;
			}
		}
		mOffset = indicatorOffset;
	}

	public int SetProgress(string spriteName, float value)
	{
		if (mIndicators.Contains(spriteName))
		{
			HudObjectIndicator2D hudObjectIndicator2D = (HudObjectIndicator2D)mIndicators[spriteName];
			hudObjectIndicator2D.progress = value;
			return hudObjectIndicator2D.sprite.spriteId;
		}
		return -1;
	}
}
