using System.Collections.Generic;
using UnityEngine;

public class UnitModelLoaderWithAnimations : UnitModelLoader
{
	public Animation animation;

	public override void LoadModel(GameObject unitModel)
	{
		base.LoadModel(unitModel);
		List<string> list = new List<string>();
		Animation component = unitModel.GetComponent<Animation>();
		foreach (object item in component)
		{
			AnimationState animationState = item as AnimationState;
			if (animationState != null)
			{
				list.Add(animationState.name);
			}
		}
		foreach (string item2 in list)
		{
			if (animation.GetClip(item2) != null)
			{
				animation.RemoveClip(item2);
			}
		}
		foreach (string item3 in list)
		{
			animation.AddClip(component.GetClip(item3), item3);
		}
	}

	public override void Reset()
	{
		base.Reset();
		List<string> list = new List<string>();
		foreach (AnimationState item in animation)
		{
			list.Add(item.name);
		}
		foreach (string item2 in list)
		{
			animation.RemoveClip(item2);
		}
	}
}
