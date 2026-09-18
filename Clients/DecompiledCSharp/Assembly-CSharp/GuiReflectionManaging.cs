using System;
using System.Collections.Generic;
using UnityEngine;

public class GuiReflectionManaging : Core_BaseScript
{
	public enum Type
	{
		None,
		RunAll,
		OneRandom
	}

	[Serializable]
	public class Reflection
	{
		public UIReflectionEffect effekt;

		public float delayToStart;

		public Reflection(UIReflectionEffect reference, float delay = 0f)
		{
			effekt = reference;
			delayToStart = delay;
		}
	}

	[Header("Core Settings")]
	public Type type = Type.RunAll;

	public List<Reflection> reflectionEffects;

	protected override void Awake()
	{
		base.Awake();
		CounterManager instance = Singleton<CounterManager>.instance;
		instance.updateCounterSpecial = (Action)Delegate.Remove(instance.updateCounterSpecial, new Action(UpdateReflection));
		CounterManager instance2 = Singleton<CounterManager>.instance;
		instance2.updateCounterSpecial = (Action)Delegate.Combine(instance2.updateCounterSpecial, new Action(UpdateReflection));
	}

	private void UpdateReflection()
	{
		if (!base.gameObject.activeInHierarchy || type == Type.None || reflectionEffects.Count == 0)
		{
			return;
		}
		if (type == Type.OneRandom)
		{
			int num = UnityEngine.Random.Range(0, reflectionEffects.Count);
			if (reflectionEffects[num].effekt == null)
			{
				Debug.LogError("UIReflectionEffect reference missing for index " + num + " on object " + base.gameObject.name);
			}
			else
			{
				reflectionEffects[num].effekt.StartIn(reflectionEffects[num].delayToStart);
			}
		}
		else
		{
			if (type != Type.RunAll)
			{
				return;
			}
			for (int i = 0; i < reflectionEffects.Count; i++)
			{
				if (reflectionEffects[i].effekt == null)
				{
					Debug.LogError("UIReflectionEffect reference missing for index " + i + " on object " + base.gameObject.name);
				}
				else
				{
					reflectionEffects[i].effekt.StartIn(reflectionEffects[i].delayToStart);
				}
			}
		}
	}
}
