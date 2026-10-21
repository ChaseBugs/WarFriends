using System.Security.Cryptography;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;
using War.Shared;

namespace War.BattleServer;

public sealed record WeaponSlotManifest(int Slot,int WeaponIndex,WeaponManifest Weapon,int WeaponUpgrade);
