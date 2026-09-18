using System;
using System.Collections.Generic;
using UnityEngine;

public class TweenAnimator : Core_BaseScript
{
	public enum TweenType
	{
		Position,
		Rotation,
		AlphaTk2d,
		Color,
		Scale,
		Alpha,
		TextCounter,
		SufixTextCounter,
		TextCounterSpecial,
		TimeCounter,
		ProgressBar,
		AlphaHider,
		Sound,
		TextCounterLong
	}

	[Serializable]
	public class TweenRecord
	{
		[SerializeField]
		public int id;

		[SerializeField]
		public TweenType type;

		[SerializeField]
		public float time;

		[SerializeField]
		public float delay;

		[SerializeField]
		public object to;

		[SerializeField]
		public object from;

		[SerializeField]
		public UITweener.Method method = UITweener.Method.EaseInOut;

		[SerializeField]
		public UITweener.Style style;

		[SerializeField]
		public int playAfterId = -1;

		[SerializeField]
		public GameObject tweenTarget;

		[SerializeField]
		public int numOfRepetitions;

		[SerializeField]
		public SoundsManager.SoundsEnum soundEnum;
	}

	public List<TweenRecord> allTweens = new List<TweenRecord>();

	public Action<int> TweenFinished;

	private bool isActive = true;

	public bool play;

	private static Dictionary<TweenType, Type> mTypesDic = new Dictionary<TweenType, Type>
	{
		{
			TweenType.Position,
			typeof(TweenPosition)
		},
		{
			TweenType.Rotation,
			typeof(TweenRotation)
		},
		{
			TweenType.AlphaTk2d,
			typeof(TweenAlphaTk2d)
		},
		{
			TweenType.Color,
			typeof(TweenColor)
		},
		{
			TweenType.Scale,
			typeof(TweenScale)
		},
		{
			TweenType.Alpha,
			typeof(TweenAlpha)
		},
		{
			TweenType.TextCounter,
			typeof(TweenTextCounter)
		},
		{
			TweenType.SufixTextCounter,
			typeof(TweenSufixTextCounter)
		},
		{
			TweenType.TextCounterSpecial,
			typeof(TweenCounterSpecial)
		},
		{
			TweenType.TimeCounter,
			typeof(TweenTimeCounter)
		},
		{
			TweenType.ProgressBar,
			typeof(TweenProgressBar)
		},
		{
			TweenType.AlphaHider,
			typeof(TweenAlphaHider)
		},
		{
			TweenType.Sound,
			typeof(AudioClip)
		},
		{
			TweenType.TextCounterLong,
			typeof(TweenTextCounterLong)
		}
	};

	public TweenRecord AddTween(int id, TweenType tweenType, GameObject tweenTarget, float time, object to, float delay = 0f, int playAfterIdFinished = -1, object from = null, UITweener.Method method = UITweener.Method.EaseInOut, UITweener.Style style = UITweener.Style.Once, int numOfRepetitions = 1)
	{
		TweenRecord tweenRecord = new TweenRecord();
		tweenRecord.delay = delay;
		tweenRecord.id = id;
		tweenRecord.type = tweenType;
		tweenRecord.time = time;
		tweenRecord.from = from;
		tweenRecord.to = to;
		tweenRecord.playAfterId = playAfterIdFinished;
		tweenRecord.method = method;
		tweenRecord.style = style;
		tweenRecord.tweenTarget = tweenTarget;
		tweenRecord.numOfRepetitions = numOfRepetitions;
		TweenRecord tweenRecord2 = tweenRecord;
		allTweens.Add(tweenRecord2);
		return tweenRecord2;
	}

	public TweenRecord AddSoundTween(int id, SoundsManager.SoundsEnum soundEntry, float delay = 0f, int playAfterIdFinished = -1)
	{
		TweenRecord tweenRecord = new TweenRecord();
		tweenRecord.delay = delay;
		tweenRecord.id = id;
		tweenRecord.type = TweenType.Sound;
		tweenRecord.playAfterId = playAfterIdFinished;
		tweenRecord.soundEnum = soundEntry;
		TweenRecord tweenRecord2 = tweenRecord;
		allTweens.Add(tweenRecord2);
		return tweenRecord2;
	}

	public void PlayTweens()
	{
		isActive = true;
		foreach (TweenRecord allTween in allTweens)
		{
			if (allTween.playAfterId == -1)
			{
				PlayTween(allTween);
			}
		}
	}

	public TweenRecord GetTween(int i)
	{
		foreach (TweenRecord allTween in allTweens)
		{
			if (allTween.id == i)
			{
				return allTween;
			}
		}
		return null;
	}

	private void PlayTween(TweenRecord r, bool useOnFinished = true)
	{
		UITweener uITweener = null;
		switch (r.type)
		{
		case TweenType.Position:
			uITweener = ((r.from != null) ? TweenPosition.Begin(r.tweenTarget, r.time, (Vector3)r.from, (Vector3)r.to) : TweenPosition.Begin(r.tweenTarget, r.time, (Vector3)r.to));
			break;
		case TweenType.Scale:
			uITweener = ((r.from != null) ? TweenScale.Begin(r.tweenTarget, r.time, (Vector3)r.from, (Vector3)r.to) : TweenScale.Begin(r.tweenTarget, r.time, (Vector3)r.to));
			break;
		case TweenType.AlphaTk2d:
			uITweener = ((r.from != null) ? TweenAlphaTk2d.Begin(r.tweenTarget, r.time, (float)r.from, (float)r.to) : TweenAlphaTk2d.Begin(r.tweenTarget, r.time, (float)r.to));
			break;
		case TweenType.Alpha:
			uITweener = ((r.from != null) ? TweenAlpha.Begin(r.tweenTarget, r.time, (float)r.from, (float)r.to) : TweenAlpha.Begin(r.tweenTarget, r.time, (float)r.to));
			break;
		case TweenType.AlphaHider:
			uITweener = ((r.from != null) ? TweenAlphaHider.Begin(r.tweenTarget, r.time, (float)r.from, (float)r.to) : TweenAlphaHider.Begin(r.tweenTarget, r.time, (float)r.to));
			break;
		case TweenType.ProgressBar:
			uITweener = ((r.from != null) ? TweenProgressBar.Begin(r.tweenTarget, r.time, (FloatObject)r.from, (FloatObject)r.to) : TweenProgressBar.Begin(r.tweenTarget, r.time, (FloatObject)r.to));
			break;
		case TweenType.TextCounter:
			uITweener = ((r.from != null) ? TweenTextCounter.Begin(r.tweenTarget, r.time, (IntObject)r.from, (IntObject)r.to) : TweenTextCounter.Begin(r.tweenTarget, r.time, (IntObject)r.to));
			break;
		case TweenType.TextCounterLong:
			uITweener = ((r.from != null) ? TweenTextCounterLong.Begin(r.tweenTarget, r.time, (LongObject)r.from, (LongObject)r.to) : TweenTextCounterLong.Begin(r.tweenTarget, r.time, (LongObject)r.to));
			break;
		case TweenType.SufixTextCounter:
			uITweener = ((r.from != null) ? TweenSufixTextCounter.Begin(r.tweenTarget, r.time, (IntObject)r.from, (IntObject)r.to) : TweenSufixTextCounter.Begin(r.tweenTarget, r.time, (IntObject)r.to));
			break;
		case TweenType.TextCounterSpecial:
			uITweener = ((r.from != null) ? TweenCounterSpecial.Begin(r.tweenTarget, r.time, (IntObject)r.from, (IntObject)r.to) : TweenCounterSpecial.Begin(r.tweenTarget, r.time, (IntObject)r.to));
			break;
		case TweenType.TimeCounter:
			uITweener = ((r.from != null) ? TweenTimeCounter.Begin(r.tweenTarget, r.time, (IntObject)r.from, (IntObject)r.to) : TweenTimeCounter.Begin(r.tweenTarget, r.time, (IntObject)r.to));
			break;
		case TweenType.Color:
			uITweener = ((r.from != null) ? TweenColor.Begin(r.tweenTarget, r.time, (Color)r.from, (Color)r.to) : TweenColor.Begin(r.tweenTarget, r.time, (Color)r.to));
			break;
		case TweenType.Rotation:
			uITweener = ((r.from != null) ? TweenRotation.Begin(r.tweenTarget, r.time, (Quaternion)r.from, (Quaternion)r.to) : TweenRotation.Begin(r.tweenTarget, r.time, (Quaternion)r.to));
			break;
		case TweenType.Sound:
			if (!useOnFinished)
			{
				return;
			}
			if (r.delay > 0f)
			{
				InvokeAfter(delegate
				{
					SoundsManager.Instance.PlaySound(r.soundEnum);
				}, r.delay);
			}
			else
			{
				SoundsManager.Instance.PlaySound(r.soundEnum);
			}
			return;
		}
		r.tweenTarget.gameObject.SetActive(value: true);
		if (uITweener != null)
		{
			uITweener.delay = r.delay;
			uITweener.method = r.method;
			uITweener.style = r.style;
			uITweener.NumOfRepetitions = r.numOfRepetitions;
			uITweener.id = r.id;
			if (useOnFinished)
			{
				UITweener uITweener2 = uITweener;
				uITweener2.onFinished = (UITweener.OnFinished)Delegate.Combine(uITweener2.onFinished, new UITweener.OnFinished(OnFinished));
			}
		}
	}

	public void Stop()
	{
		isActive = false;
	}

	private void OnFinished(UITweener tween)
	{
		if (TweenFinished != null)
		{
			TweenFinished(tween.id);
		}
		if (!isActive)
		{
			return;
		}
		int id = tween.id;
		foreach (TweenRecord allTween in allTweens)
		{
			if (allTween.playAfterId == id)
			{
				PlayTween(allTween);
			}
		}
	}

	protected void Update()
	{
		if (play)
		{
			play = false;
			PlayTweens();
		}
	}

	public void GenerateTweens()
	{
		foreach (TweenRecord allTween in allTweens)
		{
			if (allTween.type != TweenType.Sound)
			{
				Type type = mTypesDic[allTween.type];
				Component component = allTween.tweenTarget.GetComponent(type);
				if (component == null)
				{
					UITweener uITweener = (UITweener)allTween.tweenTarget.AddComponent(type);
					uITweener.enabled = false;
				}
			}
		}
	}

	public void ResetTweens()
	{
		foreach (TweenRecord allTween in allTweens)
		{
			if (allTween.type != TweenType.Sound)
			{
				Type type = mTypesDic[allTween.type];
				Component component = allTween.tweenTarget.GetComponent(type);
				if (component != null)
				{
					(component as UITweener).enabled = false;
				}
			}
		}
	}

	public void FinishTweens()
	{
		foreach (TweenRecord allTween in allTweens)
		{
			object obj = allTween.from;
			allTween.from = allTween.to;
			float time = allTween.time;
			int id = allTween.id;
			allTween.id = -1;
			allTween.time = 0f;
			PlayTween(allTween, useOnFinished: false);
			allTween.from = obj;
			allTween.time = time;
			allTween.id = id;
		}
	}
}
