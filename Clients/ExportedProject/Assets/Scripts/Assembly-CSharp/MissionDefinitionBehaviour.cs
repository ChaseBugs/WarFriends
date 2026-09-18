using System;

[Serializable]
public class MissionDefinitionBehaviour
{
	[Popup(new string[]
	{
		"Assaulter", "Sniper", "Grenadier", "Shotgunner", "Parachuter", "Minigunner", "RocketLauncher", "Swat", "Engineer", "Drone",
		"Helicopter", "DeployHeli", "Humvee", "Buggy", "Tank", "MachineGunner", "SciFi", "Transporter", "Commando", "Flamethrower",
		"Gunslinger", "Warper", "Mortar", "Mech"
	})]
	public string name;

	public int level;

	public int sceneLimit;

	public int missionLimit;
}
