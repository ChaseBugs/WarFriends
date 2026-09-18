using System;

namespace TuneSDK;

[Serializable]
public class TuneSerializableInAppMessageDictionaryIos
{
	public string[] keys;

	public TuneInAppMessageExperimentDetailsIos[] values;
}
