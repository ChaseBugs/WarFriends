using System;
using CodeStage.AntiCheat.ObscuredTypes;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

public class ObscuredIntConverter : CustomCreationConverter<ObscuredInt>
{
	public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
	{
		if (reader.TokenType == JsonToken.Null)
		{
			return default(ObscuredInt);
		}
		int num = serializer.Deserialize<int>(reader);
		ObscuredInt obscuredInt = num;
		return obscuredInt;
	}

	public override ObscuredInt Create(Type objectType)
	{
		return default(ObscuredInt);
	}
}
