using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Globalization;
using System.Reflection;

namespace Mono.Data.Sqlite;

[DefaultProperty("DataSource")]
[DefaultMember("Item")]
public sealed class SqliteConnectionStringBuilder : DbConnectionStringBuilder
{
	private Hashtable _properties;

	[Browsable(true)]
	[DefaultValue(3)]
	public int Version
	{
		get
		{
			TryGetValue("version", out var value);
			return Convert.ToInt32(value, CultureInfo.CurrentCulture);
		}
		set
		{
			if (value != 3)
			{
				throw new NotSupportedException();
			}
			this["version"] = value;
		}
	}

	[DisplayName("Synchronous")]
	[Browsable(true)]
	[DefaultValue(SynchronizationModes.Normal)]
	public SynchronizationModes SyncMode
	{
		get
		{
			TryGetValue("synchronous", out var value);
			if (value is string)
			{
				return (SynchronizationModes)(int)TypeDescriptor.GetConverter(typeof(SynchronizationModes)).ConvertFrom(value);
			}
			return (SynchronizationModes)(int)value;
		}
		set
		{
			this["synchronous"] = value;
		}
	}

	[Browsable(true)]
	[DefaultValue(false)]
	public bool UseUTF16Encoding
	{
		get
		{
			TryGetValue("useutf16encoding", out var value);
			return SqliteConvert.ToBoolean(value);
		}
		set
		{
			this["useutf16encoding"] = value;
		}
	}

	[Browsable(true)]
	[DefaultValue(false)]
	public bool Pooling
	{
		get
		{
			TryGetValue("pooling", out var value);
			return SqliteConvert.ToBoolean(value);
		}
		set
		{
			this["pooling"] = value;
		}
	}

	[Browsable(true)]
	[DefaultValue(true)]
	public bool BinaryGUID
	{
		get
		{
			TryGetValue("binaryguid", out var value);
			return SqliteConvert.ToBoolean(value);
		}
		set
		{
			this["binaryguid"] = value;
		}
	}

	[DisplayName("Data Source")]
	[Browsable(true)]
	[DefaultValue("")]
	public string DataSource
	{
		get
		{
			TryGetValue("data source", out var value);
			return value.ToString();
		}
		set
		{
			this["data source"] = value;
		}
	}

	[Browsable(false)]
	public string Uri
	{
		get
		{
			TryGetValue("uri", out var value);
			return value.ToString();
		}
		set
		{
			this["uri"] = value;
		}
	}

	[DefaultValue(30)]
	[DisplayName("Default Timeout")]
	[Browsable(true)]
	public int DefaultTimeout
	{
		get
		{
			TryGetValue("default timeout", out var value);
			return Convert.ToInt32(value, CultureInfo.CurrentCulture);
		}
		set
		{
			this["default timeout"] = value;
		}
	}

	[DefaultValue(true)]
	[Browsable(true)]
	public bool Enlist
	{
		get
		{
			TryGetValue("enlist", out var value);
			return SqliteConvert.ToBoolean(value);
		}
		set
		{
			this["enlist"] = value;
		}
	}

	[DefaultValue(false)]
	[Browsable(true)]
	public bool FailIfMissing
	{
		get
		{
			TryGetValue("failifmissing", out var value);
			return SqliteConvert.ToBoolean(value);
		}
		set
		{
			this["failifmissing"] = value;
		}
	}

	[Browsable(true)]
	[DefaultValue(false)]
	[DisplayName("Legacy Format")]
	public bool LegacyFormat
	{
		get
		{
			TryGetValue("legacy format", out var value);
			return SqliteConvert.ToBoolean(value);
		}
		set
		{
			this["legacy format"] = value;
		}
	}

	[Browsable(true)]
	[DefaultValue(false)]
	[DisplayName("Read Only")]
	public bool ReadOnly
	{
		get
		{
			TryGetValue("read only", out var value);
			return SqliteConvert.ToBoolean(value);
		}
		set
		{
			this["read only"] = value;
		}
	}

	[PasswordPropertyText(true)]
	[DefaultValue("")]
	[Browsable(true)]
	public string Password
	{
		get
		{
			TryGetValue("password", out var value);
			return value.ToString();
		}
		set
		{
			this["password"] = value;
		}
	}

	[DisplayName("Page Size")]
	[Browsable(true)]
	[DefaultValue(1024)]
	public int PageSize
	{
		get
		{
			TryGetValue("page size", out var value);
			return Convert.ToInt32(value, CultureInfo.CurrentCulture);
		}
		set
		{
			this["page size"] = value;
		}
	}

	[Browsable(true)]
	[DisplayName("Max Page Count")]
	[DefaultValue(0)]
	public int MaxPageCount
	{
		get
		{
			TryGetValue("max page count", out var value);
			return Convert.ToInt32(value, CultureInfo.CurrentCulture);
		}
		set
		{
			this["max page count"] = value;
		}
	}

	[Browsable(true)]
	[DefaultValue(2000)]
	[DisplayName("Cache Size")]
	public int CacheSize
	{
		get
		{
			TryGetValue("cache size", out var value);
			return Convert.ToInt32(value, CultureInfo.CurrentCulture);
		}
		set
		{
			this["cache size"] = value;
		}
	}

	[Browsable(true)]
	[DefaultValue(SQLiteDateFormats.ISO8601)]
	public SQLiteDateFormats DateTimeFormat
	{
		get
		{
			TryGetValue("datetimeformat", out var value);
			if (value is string)
			{
				return (SQLiteDateFormats)(int)TypeDescriptor.GetConverter(typeof(SQLiteDateFormats)).ConvertFrom(value);
			}
			return (SQLiteDateFormats)(int)value;
		}
		set
		{
			this["datetimeformat"] = value;
		}
	}

	[DefaultValue(SQLiteJournalModeEnum.Delete)]
	[DisplayName("Journal Mode")]
	[Browsable(true)]
	public SQLiteJournalModeEnum JournalMode
	{
		get
		{
			TryGetValue("journal mode", out var value);
			if (value is string)
			{
				return (SQLiteJournalModeEnum)(int)TypeDescriptor.GetConverter(typeof(SQLiteJournalModeEnum)).ConvertFrom(value);
			}
			return (SQLiteJournalModeEnum)(int)value;
		}
		set
		{
			this["journal mode"] = value;
		}
	}

	[DisplayName("Default Isolation Level")]
	[Browsable(true)]
	[DefaultValue(IsolationLevel.Serializable)]
	public IsolationLevel DefaultIsolationLevel
	{
		get
		{
			TryGetValue("default isolationlevel", out var value);
			if (value is string)
			{
				return (IsolationLevel)(int)TypeDescriptor.GetConverter(typeof(IsolationLevel)).ConvertFrom(value);
			}
			return (IsolationLevel)(int)value;
		}
		set
		{
			this["default isolationlevel"] = value;
		}
	}

	public SqliteConnectionStringBuilder()
	{
		Initialize(null);
	}

	public SqliteConnectionStringBuilder(string connectionString)
	{
		Initialize(connectionString);
	}

	private void Initialize(string cnnString)
	{
		_properties = new Hashtable(StringComparer.InvariantCultureIgnoreCase);
		try
		{
			base.GetProperties(_properties);
		}
		catch (NotImplementedException)
		{
			FallbackGetProperties(_properties);
		}
		if (!string.IsNullOrEmpty(cnnString))
		{
			base.ConnectionString = cnnString;
		}
	}

	public override bool TryGetValue(string keyword, out object value)
	{
		bool flag = base.TryGetValue(keyword, out value);
		if (!_properties.ContainsKey(keyword))
		{
			return flag;
		}
		if (!(_properties[keyword] is PropertyDescriptor propertyDescriptor))
		{
			return flag;
		}
		if (flag)
		{
			if (propertyDescriptor.PropertyType == typeof(bool))
			{
				value = SqliteConvert.ToBoolean(value);
			}
			else
			{
				value = TypeDescriptor.GetConverter(propertyDescriptor.PropertyType).ConvertFrom(value);
			}
		}
		else if (propertyDescriptor.Attributes[typeof(DefaultValueAttribute)] is DefaultValueAttribute defaultValueAttribute)
		{
			value = defaultValueAttribute.Value;
			flag = true;
		}
		return flag;
	}

	private void FallbackGetProperties(Hashtable propertyList)
	{
		foreach (PropertyDescriptor property in TypeDescriptor.GetProperties(this, noCustomTypeDesc: true))
		{
			if (property.Name != "ConnectionString" && !propertyList.ContainsKey(property.DisplayName))
			{
				propertyList.Add(property.DisplayName, property);
			}
		}
	}
}
