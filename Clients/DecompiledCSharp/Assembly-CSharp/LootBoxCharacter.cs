using UnityEngine;

public class LootBoxCharacter : Core_BaseScript, ICharacter
{
	[SerializeField]
	private SoldierMeshChanger mMeshChanger;

	public Animation characterAnimation;

	public Material solidMaterial;

	public Material transparentMaterial;

	public SoldierMeshChanger meshChanger => mMeshChanger;

	public string[] playerVisuals { get; set; }

	public PlayerVisualCategoryCamos.PlayerVisualCamo equippedCamo { get; set; }

	public PlayerVisualCategoryHelmets.PlayerVisualHelmet equippedHelmet { get; set; }

	public PlayerVisualCategoryHeadAccesories.PlayerVisualHeadAccesory equippedHeadAccesory { get; set; }

	public PlayerVisualCategoryPowerBands.PlayerVisualPowerBand equippedPowerBand { get; set; }

	public void Prepare()
	{
		playerVisuals = new string[4];
		SamplemAnimation("engineer_idle", 0f);
	}

	public void SetAccesory(int id)
	{
		switch (id)
		{
		case 0:
			EnableParts(body: true, helmet: false, attachment: false);
			break;
		case 1:
			EnableParts(body: false, helmet: true, attachment: false);
			break;
		case 2:
			EnableParts(body: false, helmet: false, attachment: true);
			break;
		}
	}

	public void SetSolidMaterial()
	{
		meshChanger.skinnedMeshRenderer.material = solidMaterial;
	}

	private void EnableParts(bool body, bool helmet, bool attachment)
	{
		meshChanger.skinnedMeshRenderer.enabled = true;
		if (!body)
		{
			transparentMaterial.mainTexture = meshChanger.skinnedMeshRenderer.material.mainTexture;
			meshChanger.skinnedMeshRenderer.material = transparentMaterial;
			meshChanger.hair.GetComponent<MeshRenderer>().sharedMaterial = transparentMaterial;
		}
		else
		{
			meshChanger.hair.GetComponent<MeshRenderer>().sharedMaterial = meshChanger.skinnedMeshRenderer.material;
		}
		meshChanger.helmet.gameObject.SetActive(helmet);
		meshChanger.helmetAttachments.modelAttachments[0].parent.gameObject.SetActive(attachment);
	}

	private void SamplemAnimation(string mAnimationName, float normalizedTime)
	{
		characterAnimation.Stop();
		AnimationState animationState = characterAnimation[mAnimationName];
		animationState.enabled = true;
		animationState.weight = 1f;
		animationState.normalizedTime = normalizedTime;
		characterAnimation.Sample();
		animationState.enabled = false;
	}
}
