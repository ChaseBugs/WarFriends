using System;
using System.Collections.Generic;
using UnityEngine;

public class ArenaLootBox3D : Core_BaseScript
{
	[SerializeField]
	private GameObject mSstand;

	[SerializeField]
	private GameObject mBox;

	[SerializeField]
	private GameObject mShield;

	[SerializeField]
	private List<Material> mLootBoxMaterials;

	[SerializeField]
	private ParticleSystem particles;

	[SerializeField]
	private ParticleSystem mBoxGlow;

	[SerializeField]
	private Animation openAnimation;

	private WarArenaConfig.LootBoxType mType;

	public void ShowLootBox(WarArenaConfig.LootBoxType type)
	{
		OpenLootbox(open: false);
		SwitchShield(enableShield: false);
		SkinnedMeshRenderer componentInChildren = mBox.GetComponentInChildren<SkinnedMeshRenderer>();
		componentInChildren.material = mLootBoxMaterials[(int)type];
		mType = type;
	}

	public void ShowShield()
	{
		SwitchShield(enableShield: true);
	}

	private void SwitchShield(bool enableShield)
	{
		mSstand.SetActive(!enableShield);
		mBox.SetActive(!enableShield);
		mShield.SetActive(enableShield);
	}

	public void Hide()
	{
		Transform child = base.transform.GetChild(0);
		particles.Stop();
		mBoxGlow.Stop();
		TweenPosition.Begin(child.gameObject, 0.2f, -600f * Vector3.up).onFinished = delegate
		{
			OpenLootbox(open: false);
		};
	}

	public void ShowAnimation()
	{
		Transform tr = base.transform.GetChild(0);
		TweenPosition tweenPosition = TweenPosition.Begin(tr.gameObject, 0.4f, -300f * Vector3.up, 20f * Vector3.up);
		tweenPosition.onFinished = (UITweener.OnFinished)Delegate.Combine(tweenPosition.onFinished, (UITweener.OnFinished)delegate
		{
			TweenPosition.Begin(tr.gameObject, 0.1f, Vector3.zero);
		});
		TweenRotationSpecial.Begin(mBox.gameObject, 0f, Vector3.up, 0f, 0f);
		mBox.transform.localRotation = Quaternion.Euler(-90f, 0f, 0f);
		TweenPosition.Begin(mBox.gameObject, 0f, 2.3f * Vector3.up);
	}

	public void ShowClaimed()
	{
		TweenPosition.Begin(mBox.gameObject, 0f, 4.3f * Vector3.up);
		TweenRotationSpecial tweenRotationSpecial = TweenRotationSpecial.Begin(mBox.gameObject, 0f, Vector3.up, 0f, 0f);
		tweenRotationSpecial.baseRotation = new Vector3(-90f, 0f, 0f);
		tweenRotationSpecial.Sample(0f, isFinished: false);
		particles.Play(withChildren: true);
		OpenLootbox(open: true);
		mBoxGlow.Play();
	}

	private void OpenLootbox(bool open)
	{
		AnimationState animationState = openAnimation["open"];
		animationState.enabled = true;
		animationState.weight = 1f;
		animationState.normalizedTime = ((!open) ? 0f : 1f);
		openAnimation.Sample();
		animationState.enabled = false;
	}

	public void ShowClaimAnimation()
	{
		TweenPosition tweenPosition = TweenPosition.Begin(mBox.gameObject, 0.4f, 4.6f * Vector3.up);
		tweenPosition.onFinished = (UITweener.OnFinished)Delegate.Combine(tweenPosition.onFinished, (UITweener.OnFinished)delegate
		{
			TweenPosition tweenPosition2 = TweenPosition.Begin(mBox.gameObject, 0.1f, 4.3f * Vector3.up);
			tweenPosition2.onFinished = (UITweener.OnFinished)Delegate.Combine(tweenPosition2.onFinished, (UITweener.OnFinished)delegate
			{
				TweenRotationSpecial tweenRotationSpecial = TweenRotationSpecial.Begin(mBox.gameObject, 2f, Vector3.up, 360f, 0f);
				tweenRotationSpecial.baseRotation = new Vector3(-90f, 0f, 0f);
				tweenRotationSpecial.method = UITweener.Method.Linear;
				tweenRotationSpecial.style = UITweener.Style.Loop;
				particles.Play(withChildren: true);
			});
		});
	}
}
