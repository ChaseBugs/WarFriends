using System;
using System.Collections.Generic;
using System.Globalization;
using Google2u;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using UnityEngine;

internal class KillSpecificEnemyUnits : Assignment
{
	private static Dictionary<string, Type> mBehavioursDictionary = new Dictionary<string, Type>(StringComparer.OrdinalIgnoreCase)
	{
		{
			"Assaulter",
			typeof(SoldierBehaviourAssaulter)
		},
		{
			"Sniper",
			typeof(SoldierBehaviourSniper)
		},
		{
			"Grenadier",
			typeof(SoldierBehaviourGrennader)
		},
		{
			"Shotgunner",
			typeof(SoldierBehaviourShotgunner)
		},
		{
			"Parachuter",
			typeof(SoldierBehaviourParachuter)
		},
		{
			"Minigunner",
			typeof(SoldierBehaviourMinigunner)
		},
		{
			"RocketLauncher",
			typeof(SoldierBehaviourBazooka)
		},
		{
			"Swat",
			typeof(SoldierBehaviourSwat)
		},
		{
			"Engineer",
			typeof(SoldierBehaviourEngineer)
		},
		{
			"Drone",
			typeof(DroneBehaviour)
		},
		{
			"Helicopter",
			typeof(AssaultHelicopterBehaviour)
		},
		{
			"DeployHeli",
			typeof(HelicopterBehaviour)
		},
		{
			"Humvee",
			typeof(CarBehaviour)
		},
		{
			"Buggy",
			typeof(CarBuggyBehaviour)
		},
		{
			"Tank",
			typeof(TankBehaviour)
		},
		{
			"MachineGunner",
			typeof(SoldierBehaviourMachineGunner)
		},
		{
			"SciFi",
			typeof(SoldierBehaviourSciFi)
		},
		{
			"Transporter",
			typeof(CarTransporterBehaviour)
		},
		{
			"Commando",
			typeof(SoldierBehaviourCommando)
		},
		{
			"Flamethrower",
			typeof(SoldierBehaviourFlamethrower)
		},
		{
			"Gunslinger",
			typeof(SoldierBehaviourGunslinger)
		},
		{
			"Warper",
			typeof(SoldierBehaviourWarper)
		},
		{
			"Mortar",
			typeof(SoldierBehaviourMortar)
		},
		{
			"Mech",
			typeof(MechBehaviour)
		}
	};

	protected override string basicDescription
	{
		get
		{
			int fFHHEHHFOKJ = Convert.ToInt32(base.mData[0]);
			Type type = mBehavioursDictionary[(string)base.mData[1]];
			LevelBehaviour behaviour = LevelManager.instance.GetBehaviour(type);
			return Localization.LocalizeFormat(base.translationId, MEJMLNDFDBP.PHCBFODPDOD(fFHHEHHFOKJ), behaviour.unitName);
		}
	}

	private bool isVehicle
	{
		get
		{
			if (base.mData == null || base.mData.Length < 2)
			{
				return false;
			}
			string key = Convert.ToString(base.mData[1]);
			if (!mBehavioursDictionary.ContainsKey(key))
			{
				return false;
			}
			Type type = mBehavioursDictionary[key];
			return type.IsAssignableFrom(typeof(VehicleBehaviour));
		}
	}

	public override string assignmentPicture
	{
		get
		{
			return (!isVehicle) ? "menu-assignments-type-kill" : "menu-assignments-type-destroy";
		}
	}

	public override bool hasHint
	{
		get
		{
			return LevelManager.instance.currentLevel.displayNumber >= LevelManager.instance.dailyMissionUnlockLevel;
		}
	}

	public override string hintText
	{
		get
		{
			return Localization.Localize("ID_ASSIGNMENTHINTWARPATH");
		}
	}

	public KillSpecificEnemyUnits(AssignmentsManager.DatabaseAssignment dbAssignment, float levelProgress, string secondParameter = "")
		: base(dbAssignment, levelProgress)
	{
		Debug.Log("Assignment: Kill Specific Enemy Units");
		base.mData = new object[2];
		float playerLevelProgress = LevelManager.instance.GetPlayerLevelProgress();
		TaskDefinitionsRow row = AssignmentsManager.instance.taskDefinitions.GetRow("ID_" + 4);
		if (row == null)
		{
			Debug.Log("Assignment: Error, task definition not found for id = " + base.id);
			return;
		}
		if (string.IsNullOrEmpty(secondParameter))
		{
			secondParameter = dbAssignment.secondTarget.ToString(CultureInfo.InvariantCulture);
		}
		JToken unit = GetUnit(row, playerLevelProgress, secondParameter);
		if (unit != null)
		{
			base.mData[0] = dbAssignment.target * KHJJFPPACBP.HNMDPGKPLNK(unit["SPAWNCOUNT"]);
			string text = unit["NAME"].ToObject<string>();
			base.mData[1] = text;
		}
	}

	private JToken GetUnit(TaskDefinitionsRow definition, float playerLevelProgress, string param)
	{
		Dictionary<string, object> dictionary = JsonConvert.DeserializeObject<Dictionary<string, object>>(definition.SECONDTARGETPARAMETER);
		if (dictionary == null)
		{
			return null;
		}
		if (!string.IsNullOrEmpty(param))
		{
			return (JToken)dictionary[param];
		}
		int num = (int)Mathf.Lerp(definition.SECONDTARGETMIN, definition.SECONDTARGETMAX, playerLevelProgress);
		List<string> list = new List<string>();
		foreach (KeyValuePair<string, object> item in dictionary)
		{
			int num2 = KHJJFPPACBP.PELILBMKGHE(item.Key);
			if (num2 <= num)
			{
				list.Add(item.Key);
			}
		}
		System.Random random = new System.Random();
		int index = random.Next(0, list.Count - 1);
		return (JToken)dictionary[list[index]];
	}

	public override float Update()
	{
		string key = Convert.ToString(base.mData[1]);
		Type iOIKKIIFOCB = mBehavioursDictionary[key];
		int unitKilledCount = Singleton<ScoreManager>.instance.GetUnitKilledCount(iOIKKIIFOCB);
		base.mCompleteFract = CompareIntAndInt(unitKilledCount, Convert.ToInt32(base.mData[0]));
		return base.mCompleteFract;
	}
}
