using System.Runtime.CompilerServices;
using UnityEngine;

public class ShieldIcon : PoolableObject
{
	[SerializeField]
	private UISprite mBackground;

	[SerializeField]
	private UISprite highlight;

	[SerializeField]
	private UITexture mShieldTexture;

	[SerializeField]
	private UISprite mLockedSprite;

	[SerializeField]
	private GameObject mRarityPart;

	[SerializeField]
	private UISprite mRarityBackground;

	[SerializeField]
	private UILabel mRarityLabel;

	[SerializeField]
	private GameObject arenaPart;

	[SerializeField]
	private UISprite mEquippedIcon;

	[SerializeField]
	private GameObject notification;

	[CompilerGenerated]
	private ShieldCosmeticsManager.ShieldCosmeticModel _003CAOJMGPPIMGJ_003Ek__BackingField;

	private bool LHNAMBFDFEM;

	public ShieldCosmeticsManager.ShieldCosmeticModel shieldCosmetic
	{
		[CompilerGenerated]
		get
		{
			return null;
		}
		[CompilerGenerated]
		private set
		{
		}
	}

	public void Initialize(ShieldCosmeticsManager.ShieldCosmeticModel BDIOGLMNJNH)
	{
	}

	public void SetHighlight(bool AKJIHJFBJLE)
	{
	}

	public void UpdateEquipped()
	{
	}

	public void UpdateNotification()
	{
	}

	public void UpdateGraphics()
	{
	}

	private void OnClick()
	{
	}

	private void ECMMNJGCFDN()
	{
	}

	private void KKPFFIMDJCL()
	{
	}

	private void NGKCKCFILEJ(Texture2D GDFNLIOGOKH)
	{
	}

	public override void DestroyPooled()
	{
	}
}
