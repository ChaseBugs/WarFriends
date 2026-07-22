using System;
using System.Collections.Generic;
using UnityEngine.Scripting;

[Serializable]
[Preserve]
public class CommanderData
{
	public string commanderid;

	public List<CommanderObjectiveData> objectives;

	public SpecialOpsData specialOpsData;
}
