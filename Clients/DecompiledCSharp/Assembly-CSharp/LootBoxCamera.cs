using System;
using System.Collections.Generic;
using UnityEngine;

public class LootBoxCamera : Singleton<LootBoxCamera>
{
	public GameObject background;

	public Camera lootboxCamera;

	public Camera dialogCamera;

	public Transform characterParent;

	public LootBoxCharacter lootBoxCharacter;

	public Animation lootBoxOpenAnimation;

	public ParticleSystem lootBoxOpenParticles;

	public Animation lootBoxShowUpAnimation;

	public ParticleSystem screenShowParticles;

	public RotateCamera rotateCamera;

	private Transform mLootBoxPrent;

	private Dictionary<int, CamosManager.SavedPlayerVisualSlot> mPlayerVisuals;

	private int mRandomCategory;

	protected override void Awake()
	{
		base.Awake();
		mLootBoxPrent = lootBoxOpenAnimation.transform;
		background.gameObject.SetActive(value: false);
		AnimationEvent component = lootBoxOpenAnimation.GetComponent<AnimationEvent>();
		if (component != null)
		{
			component.OnAnimationEvent = (Action<string>)Delegate.Combine(component.OnAnimationEvent, new Action<string>(OnAnimationEvent));
		}
		dialogCamera.gameObject.SetActive(value: false);
	}

	protected void Update()
	{
	}

	public void Test()
	{
		InvokeAfter(delegate
		{
			TestVisual();
		}, 0f);
		InvokeAfter(OpenLootBox, 4f);
	}

	public void TestVisual()
	{
		mRandomCategory = UnityEngine.Random.Range(0, 3);
		mPlayerVisuals = new Dictionary<int, CamosManager.SavedPlayerVisualSlot>();
		mPlayerVisuals[mRandomCategory] = new CamosManager.SavedPlayerVisualSlot
		{
			equippedID = CamosManager.instance.RandomPlayerVisual(mRandomCategory).id
		};
		Show();
		ShowUpLootBox();
	}

	public void ShowVisual(PlayerVisual visual)
	{
		mRandomCategory = visual.owner.categoryNumber;
		mPlayerVisuals = new Dictionary<int, CamosManager.SavedPlayerVisualSlot>();
		mPlayerVisuals[mRandomCategory] = new CamosManager.SavedPlayerVisualSlot
		{
			equippedID = visual.id
		};
		if (mRandomCategory != 0)
		{
			mPlayerVisuals[0] = new CamosManager.SavedPlayerVisualSlot
			{
				equippedID = CamosManager.instance.playerVisualCategories[0].equippedVisual.id
			};
		}
		Show();
		ShowUpLootBox();
	}

	public void Show()
	{
		lootboxCamera.enabled = true;
		rotateCamera.enabled = true;
		background.SetActive(value: true);
		mLootBoxPrent.gameObject.SetActive(value: true);
		characterParent.gameObject.SetActive(value: false);
		screenShowParticles.Play();
		SoundsManager.Instance.PlaySound(SoundsManager.SoundsEnum.BootcampIntro);
	}

	public void Skip()
	{
		DisplayModel(wasSkipped: true);
	}

	public void Hide()
	{
		lootboxCamera.enabled = false;
		rotateCamera.enabled = false;
	}

	public void DisplayModel(bool wasSkipped)
	{
		rotateCamera.Reset();
		mLootBoxPrent.gameObject.SetActive(value: false);
		characterParent.gameObject.SetActive(value: true);
		lootBoxCharacter.Prepare();
		lootBoxCharacter.SetSolidMaterial();
		CamosManager.instance.ApplyVisuals(lootBoxCharacter, mPlayerVisuals, useHighRes: true);
		CamosManager.instance.mainPlayer.equippedCamo = null;
		CamosManager.instance.ApplyVisuals(CamosManager.instance.mainPlayer, useHighRes: true);
		lootBoxCharacter.SetAccesory(mRandomCategory);
		lootBoxCharacter.transform.localScale = Vector3.one;
		lootBoxCharacter.transform.localPosition = Vector3.zero;
		lootBoxCharacter.transform.localRotation = Quaternion.identity;
		GuiElementSingle<LootBoxDialog>.instance.ShowVisualInfo(wasSkipped);
	}

	public void ShowUpLootBox()
	{
		AnimationState animationState = lootBoxOpenAnimation["LootBoxOpen"];
		animationState.normalizedTime = 0f;
		animationState.weight = 1f;
		animationState.enabled = true;
		lootBoxOpenAnimation.Sample();
		animationState.enabled = false;
		lootBoxShowUpAnimation.Play("LootBoxShowUp");
		lootBoxShowUpAnimation.PlayQueued("LootBoxRotation");
	}

	public void OpenLootBox()
	{
		lootBoxOpenAnimation.Play();
		SoundsManager.Instance.PlaySound(SoundsManager.SoundsEnum.OpenLootbox);
	}

	private void OnAnimationEvent(string s)
	{
		if (s == "boxOpen")
		{
			lootBoxOpenParticles.Play();
		}
		if (s == "animationEnd")
		{
			EndOfLootboxOpening();
		}
	}

	private void EndOfLootboxOpening()
	{
		InvokeAfter(delegate
		{
			GuiElementSingle<LootBoxDialog>.instance.ShowFlash();
		}, 0.3f);
	}
}
