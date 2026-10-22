using System;
using System.Collections.Generic;
using Beebyte.Obfuscator;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

[Skip]
public abstract class DatabaseSerializedObject : Core_BaseGlobalScript
{
	private static readonly List<DatabaseSerializedObject> SerializedObjects;

	protected abstract Type SerializeType { get; }

	protected abstract object SerializedObject { get; set; }

	static DatabaseSerializedObject()
	{
		SerializedObjects = new List<DatabaseSerializedObject>();
		JsonConvert.DefaultSettings = () => new JsonSerializerSettings
		{
			Converters = new List<JsonConverter>
			{
				new ObscuredIntConverter()
			}
		};
	}

	protected override void Awake()
	{
		base.Awake();
		SerializedObjects.Add(this);
	}

	protected virtual void LoadEmpty()
	{
		SerializedObject = Activator.CreateInstance(SerializeType);
	}

	internal static void LoadObjects(JToken dictionary)
	{
		foreach (DatabaseSerializedObject serializedObject in SerializedObjects)
		{
			serializedObject.Load(dictionary);
		}
	}

    internal static JObject CaptureOfflineSnapshot()
    {
        JObject snapshot = new JObject();
        // The recovered converter only reads ObscuredInt. Offline snapshots also
        // need to write its numeric value, not its encrypted implementation fields.
        JsonSerializer serializer = JsonSerializer.Create(new JsonSerializerSettings
        {
            Converters = new List<JsonConverter> { new OfflineSnapshotIntConverter() }
        });
        foreach (DatabaseSerializedObject item in SerializedObjects)
        {
            if (item != null)
            {
                using (var text = new System.IO.StringWriter(System.Globalization.CultureInfo.InvariantCulture))
                using (var writer = new JsonTextWriter(text))
                {
                    serializer.Serialize(writer, item.SerializedObject);
                    snapshot[item.SerializeType.Name] = new JObject { ["S"] = text.ToString() };
                }
            }
        }
        return snapshot;
    }

    private sealed class OfflineSnapshotIntConverter : JsonConverter
    {
        public override bool CanRead { get { return false; } }
        public override bool CanConvert(Type type) { return type == typeof(CodeStage.AntiCheat.ObscuredTypes.ObscuredInt); }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            writer.WriteValue((int)(CodeStage.AntiCheat.ObscuredTypes.ObscuredInt)value);
        }
        public override object ReadJson(JsonReader reader, Type type, object existing, JsonSerializer serializer)
        {
            throw new NotSupportedException("Offline snapshot converter is write-only.");
        }
    }

	internal static void TryLoadObjects(JToken dictionary)
	{
		foreach (DatabaseSerializedObject serializedObject in SerializedObjects)
		{
			serializedObject.TryLoad(dictionary);
		}
	}

	protected virtual void Load(JToken dictionary)
	{
	}

	protected virtual void TryLoad(JToken dictionary)
	{
	}

	protected virtual void Load(Dictionary<string, object> dictionary)
	{
	}
}
