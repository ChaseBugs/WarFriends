using System;
using System.Collections.Generic;
using UnityEngine;

public class PlayerVisualCategoryPowerBands : PlayerVisualCategoryGeneric<PlayerVisualCategoryPowerBands.PlayerVisualPowerBand>
{
	[Serializable]
	public class PlayerVisualPowerBand : PlayerVisualHead
	{
		public Texture2D texture;

		public Vector2 position;

		public Vector2 size;

		private static Dictionary<int, string> mDecalDescription = new Dictionary<int, string>
		{
			{ -1, "BANDS_NO_BAND" },
			{ 0, "BANDS_WEAPON_RELOAD" },
			{ 1, "BANDS_WEAPON_DAMAGE" },
			{ 2, "BANDS_HITPOINT" }
		};

		private static Dictionary<int, string> mDecalMiniIcon = new Dictionary<int, string>
		{
			{ -1, "menu-powerband-health-ico" },
			{ 0, "game-card-ico-reload" },
			{ 1, "menu-powerband-damage-ico" },
			{ 2, "menu-powerband-health-ico" }
		};

		private static Dictionary<int, Color> mDecalMiniIconColor = new Dictionary<int, Color>
		{
			{
				-1,
				Color.white
			},
			{
				0,
				Colours.powerBandReload
			},
			{
				1,
				Colours.powerBandDamage
			},
			{
				2,
				Colours.powerBandHealth
			}
		};

		private static Dictionary<int, Tuple<string, string>> mNameLocalizations = new Dictionary<int, Tuple<string, string>>
		{
			{
				-1,
				new Tuple<string, string>("BAND_EMPTY", "BAND_TYPE_EMPTY")
			},
			{
				0,
				new Tuple<string, string>("BAND_REWARD_RELOAD", "BAND_TYPE_RELOAD")
			},
			{
				1,
				new Tuple<string, string>("BAND_REWARD_DAMAGE", "BAND_TYPE_DAMAGE")
			},
			{
				2,
				new Tuple<string, string>("BAND_REWARD_HEALTH", "BAND_TYPE_HEALTH")
			}
		};

		public override string description => Localization.LocalizeFormat(mDecalDescription[decalType], Colours.stringBlue, base.decalValue);

		public override string decalMiniIcon => mDecalMiniIcon[decalType];

		public override Color decalMiniIconColor => mDecalMiniIconColor[decalType];

		public override string decalShortName => Localization.Localize(mNameLocalizations[decalType].Value1);

		public override string decalTypeName => Localization.Localize(mNameLocalizations[decalType].Value2);

		public override bool isEmptyPowerBand => decalType < 0;

		public override bool isBought => base.timeActive == 0 || base.remainingTime > 0.0 || base.tryOutVisual;

		public override void ApplyVisual(ICharacter character, bool useHighRes = false)
		{
			base.ApplyVisual(character, useHighRes);
			character.meshChanger.ChangePowerBand(this);
			PlayerController playerController = character as PlayerController;
			if (playerController != null)
			{
				playerController.weaponReloadCoef = 0f;
				playerController.weaponDamageCoef = 1f;
				playerController.playerHitPointCoef = 1f;
				switch (decalType)
				{
				case 0:
					playerController.weaponReloadCoef = 1f - row.DECALVALUE;
					break;
				case 1:
					playerController.weaponDamageCoef = 1f + row.DECALVALUE;
					break;
				case 2:
					playerController.playerHitPointCoef = 1f + row.DECALVALUE;
					break;
				}
			}
			if (Application.isPlaying)
			{
				character.equippedPowerBand = this;
				CamoTransform value = null;
				string text = character.playerVisuals[0];
				if (text != null)
				{
					camoTransformDict.TryGetValue(text, out value);
				}
				CamoTransform.SetTransform(character.meshChanger.powerband.gameObject, value);
			}
		}

		public override void Buy()
		{
			base.Buy();
			double currentTimestampDouble = Singleton<BeanstalkServerManager>.instance.currentTimestampDouble;
			int expiresOn = Convert.ToInt32(currentTimestampDouble) + base.timeActive;
			CamosManager.instance.data.visuals[base.id].expiresOn = expiresOn;
		}
	}
}
