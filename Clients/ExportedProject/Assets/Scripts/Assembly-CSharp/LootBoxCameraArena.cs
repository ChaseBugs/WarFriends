using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootBoxCameraArena : Singleton<LootBoxCameraArena>
{
	[SerializeField]
	private GameObject mBackground;

	[SerializeField]
	private Transform mCharacterParent;

	[SerializeField]
	private Camera mDialogCamera;

	[SerializeField]
	private Camera mLootboxCamera;

	[SerializeField]
	private Animation mLootBoxOpenAnimation;

	[SerializeField]
	private Animation mLootBoxShowUpAnimation;

	[SerializeField]
	private RotateCamera mRotateCamera;

	[SerializeField]
	private ParticleSystem mScreenShowParticles;

	[SerializeField]
	private ParticleSystem mLootBoxOpenParticles;

	[SerializeField]
	private List<Material> mLootBoxMaterials;

	[SerializeField]
	private GameObject mLootBox;

	private LevelBehaviour mDisplayedBehaviour;

	private Transform mLootBoxPrent;

	private AIObject mInstance;

	public event Action LootBoxShowedUp;

	protected override void Awake()
	{
		base.Awake();
		mLootBoxPrent = mLootBoxOpenAnimation.transform;
		mBackground.gameObject.SetActive(value: false);
		AnimationEvent component = mLootBoxOpenAnimation.GetComponent<AnimationEvent>();
		if (component != null)
		{
			component.OnAnimationEvent = (Action<string>)Delegate.Combine(component.OnAnimationEvent, new Action<string>(OnAnimationEvent));
		}
		mDialogCamera.gameObject.SetActive(value: false);
	}

	public void DisplayModel(LevelBehaviour behaviour, bool isLootboxReward)
	{
		UpgradeSlots.showElite = true;
		mCharacterParent.transform.parent.localScale = ((!isLootboxReward) ? (Vector3.one * 2.3f) : (Vector3.one * 2.85f));
		mBackground.SetActive(isLootboxReward);
		Show(showBackground: false);
		mDisplayedBehaviour = behaviour;
		mRotateCamera.Reset();
		mLootBoxPrent.gameObject.SetActive(value: false);
		mCharacterParent.gameObject.SetActive(value: true);
		StartCoroutine(DisplayModelCoroutine(mDisplayedBehaviour));
	}

	public void HideModel()
	{
		mCharacterParent.gameObject.SetActive(value: false);
	}

	public void PlayParticles()
	{
		mScreenShowParticles.Play();
	}

	public void ShowUpLootBox(WarArenaConfig.LootBoxType lootBoxType)
	{
		mCharacterParent.transform.parent.localScale = Vector3.one * 2.85f;
		Show(showBackground: true);
		mScreenShowParticles.Play();
		AnimationState animationState = mLootBoxOpenAnimation["open"];
		animationState.normalizedTime = 0f;
		animationState.weight = 1f;
		animationState.enabled = true;
		mLootBoxOpenAnimation.Sample();
		animationState.enabled = false;
		mLootBoxShowUpAnimation.Play("LootBoxShowUp");
		mLootBoxShowUpAnimation.PlayQueued("LootBoxRotation");
		SkinnedMeshRenderer componentInChildren = mLootBox.GetComponentInChildren<SkinnedMeshRenderer>();
		componentInChildren.material = mLootBoxMaterials[(int)lootBoxType];
		InvokeAfter(OpenLootBox, 0.5f);
	}

	public void Hide()
	{
		UpgradeSlots.showElite = false;
		mLootboxCamera.enabled = false;
		mRotateCamera.enabled = false;
		mBackground.gameObject.SetActive(value: false);
		DestroyModel(unload: true);
	}

	private void DestroyModel(bool unload)
	{
		if (mInstance != null)
		{
			mInstance.DestroyPooled(changeParentBack: true);
			mInstance.transform.localPosition = default(Vector3);
			mInstance.transform.localScale = Vector3.one;
			if (unload)
			{
				mInstance.preparedBehaviour.Unload();
			}
			mInstance = null;
		}
	}

	private IEnumerator DisplayModelCoroutine(LevelBehaviour behavior)
	{
		PlayerController.currentPlayer.fraction = Fractions.Allies;
		ArmyUnit3DModel s = null;
		DestroyModel(unload: true);
		yield return StartCoroutine(behavior.PrepareVisualsForGameCoroutine(UnitUpgradeDefinition.GetPreviewUpgrades(behavior, 1f), bought: true, mine: true, unloadWeapon: true));
		DestroyModel(unload: false);
		AIObject enemy = Singleton<LevelBehaviourManager>.instance.GenerateNewEnemy(behavior);
		if (enemy != null && enemy.prefab != null)
		{
			enemy.isPrewiev = true;
			enemy.fraction = Fractions.Allies;
			mInstance = (AIObject)ObjectPoolDatabase.networkPool.ReInstantiate(enemy);
			mInstance.transform.parent = mCharacterParent;
			mInstance.transform.localRotation = Quaternion.identity;
		}
		s = mInstance.GetComponent<ArmyUnit3DModel>();
		mInstance.transform.localPosition = -s.middle.localPosition;
		mInstance.transform.localScale = Vector3.one;
		mCharacterParent.localScale = s.scale * Vector3.one;
		mInstance.isPrewiev = true;
		mInstance.UpdatePreview(inGame: false);
		mCharacterParent.localPosition = behavior.modelPosition;
	}

	private void Show(bool showBackground)
	{
		mLootboxCamera.enabled = true;
		mRotateCamera.enabled = true;
		if (showBackground)
		{
			mBackground.SetActive(value: true);
		}
		mLootBoxPrent.gameObject.SetActive(value: true);
		mCharacterParent.gameObject.SetActive(value: false);
	}

	private void OpenLootBox()
	{
		mLootBoxOpenAnimation.Play("open");
		SoundsManager.Instance.PlaySound(SoundsManager.SoundsEnum.OpenLootbox);
	}

	private void OnAnimationEvent(string s)
	{
		if (s == "boxOpen")
		{
			mLootBoxOpenParticles.Play();
		}
		if (s == "animationEnd" && this.LootBoxShowedUp != null)
		{
			this.LootBoxShowedUp();
		}
	}
}
