using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

[Flags]
[JsonConverter(typeof(StringEnumConverter))]
public enum WeaponCategory
{
	None = 0,
	AssaultRifle = 1,
	SMG = 2,
	LMG = 4,
	SniperRifle = 8,
	RocketLauncher = 0x10,
	Shotgun = 0x20,
	Grenade = 0x40,
	Pistol = 0x80,
	Minigun = 0x100,
	GrenadeLauncher = 0x200,
	Primary = 7,
	Special = 0x128,
	Explosive = 0x250,
	Any = -1
}
