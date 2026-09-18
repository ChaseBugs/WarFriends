using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Security;
using System.Text.RegularExpressions;
using Amazon.Runtime.Internal.Util;
using Amazon.Util.Internal;
using Mono.Data.Sqlite;
using ThirdParty.Json.LitJson;
using UnityEngine;

namespace Amazon.MobileAnalytics.MobileAnalyticsManager.Internal;

[SecuritySafeCritical]
public class SQLiteEventStore : IEventStore, IDisposable
{
	private Logger _logger = Logger.GetLogger(typeof(SQLiteEventStore));

	private const string TABLE_NAME = "ma_events";

	private const string EVENT_COLUMN_NAME = "ma_event";

	private const string EVENT_ID_COLUMN_NAME = "ma_event_id";

	private const string EVENT_DELIVERY_ATTEMPT_COUNT_COLUMN_NAME = "ma_delivery_attempt_count";

	private const string MA_APP_ID_COLUMN_NAME = "ma_app_id";

	private const string TABLE_ROWID = "ROWID";

	private const string DB_SIZE_KEY = "MAX_DB_SIZE";

	private const string DB_WARNING_THRESHOLD_KEY = "DB_WARNING_THRESHOLD";

	private const string dbFileName = "mobile_analytic_event.db";

	private static object _lock = new object();

	private MobileAnalyticsManagerConfig _maConfig;

	private bool _isDisposed;

	private SqliteConnection connection;

	public string DBfileFullPath { get; internal set; }

	public long DatabaseSize
	{
		get
		{
			string commandText = "PRAGMA page_count;";
			string commandText2 = "PRAGMA page_size;";
			long num = 0L;
			long num2 = 0L;
			lock (_lock)
			{
				try
				{
					connection = new SqliteConnection("URI=file:" + DBfileFullPath);
					connection.Open();
					using SqliteCommand sqliteCommand = connection.CreateCommand();
					sqliteCommand.CommandText = commandText;
					using (SqliteDataReader sqliteDataReader = sqliteCommand.ExecuteReader())
					{
						if (sqliteDataReader.HasRows)
						{
							while (sqliteDataReader.Read())
							{
								num = sqliteDataReader.GetInt64(0);
							}
						}
					}
					sqliteCommand.CommandText = commandText2;
					using SqliteDataReader sqliteDataReader2 = sqliteCommand.ExecuteReader();
					if (sqliteDataReader2.HasRows)
					{
						while (sqliteDataReader2.Read())
						{
							num2 = sqliteDataReader2.GetInt64(0);
						}
					}
				}
				finally
				{
					if (connection != null)
					{
						connection.Close();
						connection.Dispose();
					}
				}
			}
			return num * num2;
		}
	}

	public SQLiteEventStore(MobileAnalyticsManagerConfig maConfig)
	{
		_maConfig = maConfig;
		SetupSQLiteEventStore();
	}

	public void Dispose()
	{
		Dispose(disposing: true);
		GC.SuppressFinalize(this);
	}

	protected virtual void Dispose(bool disposing)
	{
		if (!_isDisposed)
		{
			if (disposing && connection != null)
			{
				connection.Close();
				connection.Dispose();
			}
			_isDisposed = true;
		}
	}

	private void CreateOrOpenDatabase()
	{
		lock (_lock)
		{
			DBfileFullPath = Path.Combine(AmazonHookedPlatformInfo.Instance.PersistentDataPath, "mobile_analytic_event.db");
			string commandText = "PRAGMA auto_vacuum = 1";
			string commandText2 = string.Format(CultureInfo.InvariantCulture, "CREATE TABLE IF NOT EXISTS {0} ({1} TEXT NOT NULL,{2} TEXT NOT NULL UNIQUE,{3} TEXT NOT NULL, {4}  INTEGER NOT NULL DEFAULT 0 )", "ma_events", "ma_event", "ma_event_id", "ma_app_id", "ma_delivery_attempt_count");
			if (!File.Exists(DBfileFullPath))
			{
				string directoryName = Path.GetDirectoryName(DBfileFullPath);
				if (!Directory.Exists(directoryName))
				{
					Directory.CreateDirectory(directoryName);
				}
				SqliteConnection.CreateFile(DBfileFullPath);
			}
			try
			{
				connection = new SqliteConnection("URI=file:" + DBfileFullPath);
				connection.Open();
				using (SqliteCommand sqliteCommand = connection.CreateCommand())
				{
					sqliteCommand.CommandText = commandText;
					sqliteCommand.ExecuteNonQuery();
				}
				using SqliteCommand sqliteCommand2 = connection.CreateCommand();
				sqliteCommand2.CommandText = commandText2;
				sqliteCommand2.ExecuteNonQuery();
			}
			finally
			{
				if (connection != null)
				{
					connection.Close();
					connection.Dispose();
				}
			}
		}
	}

	private void SetupSQLiteEventStore()
	{
		CreateOrOpenDatabase();
	}

	public void PutEvent(string eventString, string appId)
	{
		bool flag = false;
		long databaseSize = DatabaseSize;
		if (string.IsNullOrEmpty(appId))
		{
			throw new ArgumentNullException("AppId");
		}
		if (databaseSize >= _maConfig.MaxDBSize)
		{
			flag = false;
			InvalidOperationException exception = new InvalidOperationException();
			_logger.Error(exception, "The database size has exceeded the threshold limit. Unable to insert any new events");
		}
		else if ((double)databaseSize / (double)_maConfig.MaxDBSize >= _maConfig.DBWarningThreshold)
		{
			flag = true;
			_logger.InfoFormat("The database size is almost full");
		}
		else
		{
			flag = true;
		}
		if (!flag)
		{
			return;
		}
		lock (_lock)
		{
			string commandText = string.Format(CultureInfo.InvariantCulture, "INSERT INTO {0}  ({1},{2},{3}) values(@eventString , @eventId , @appid )", "ma_events", "ma_event", "ma_event_id", "ma_app_id");
			try
			{
				connection = new SqliteConnection("URI=file:" + DBfileFullPath);
				connection.Open();
				using SqliteCommand sqliteCommand = connection.CreateCommand();
				sqliteCommand.CommandText = commandText;
				BindData(sqliteCommand, eventString, Guid.NewGuid().ToString(), appId);
				sqliteCommand.ExecuteNonQuery();
			}
			finally
			{
				if (connection != null)
				{
					connection.Close();
					connection.Dispose();
				}
			}
		}
	}

	public void DeleteEvent(List<string> rowIds)
	{
		lock (_lock)
		{
			try
			{
				connection = new SqliteConnection("URI=file:" + DBfileFullPath);
				connection.Open();
				string text = string.Format(CultureInfo.InvariantCulture, "'{0}'", string.Join("', '", rowIds.ToArray()));
				string commandText = string.Format(CultureInfo.InvariantCulture, "DELETE FROM {0} WHERE {1} IN ({2})", "ma_events", "ma_event_id", text);
				using SqliteCommand sqliteCommand = connection.CreateCommand();
				sqliteCommand.CommandText = commandText;
				sqliteCommand.ExecuteNonQuery();
			}
			finally
			{
				if (connection != null)
				{
					connection.Close();
					connection.Dispose();
				}
			}
		}
	}

	public List<JsonData> GetEvents(string appID, int maxAllowed)
	{
		List<JsonData> list = new List<JsonData>();
		lock (_lock)
		{
			try
			{
				connection = new SqliteConnection("URI=file:" + DBfileFullPath);
				connection.Open();
				string commandText = string.Format(CultureInfo.InvariantCulture, "SELECT {0},{1},{2} FROM {3} WHERE {4}  = @appId ORDER BY {5}, ROWID LIMIT {6} ", "ma_event_id", "ma_event", "ma_app_id", "ma_events", "ma_app_id", "ma_delivery_attempt_count", maxAllowed);
				using SqliteCommand sqliteCommand = connection.CreateCommand();
				sqliteCommand.CommandText = commandText;
				BindData(sqliteCommand, appID);
				using SqliteDataReader sqliteDataReader = sqliteCommand.ExecuteReader();
				if (sqliteDataReader.HasRows)
				{
					while (sqliteDataReader.Read())
					{
						JsonData jsonData = new JsonData();
						jsonData["id"] = sqliteDataReader.GetString(0);
						jsonData["event"] = sqliteDataReader.GetString(1);
						jsonData["appId"] = sqliteDataReader.GetString(2);
						list.Add(jsonData);
					}
				}
			}
			finally
			{
				if (connection != null)
				{
					connection.Close();
					connection.Dispose();
				}
			}
		}
		return list;
	}

	public long NumberOfEvents(string appID)
	{
		long num = 0L;
		lock (_lock)
		{
			try
			{
				connection = new SqliteConnection("URI=file:" + DBfileFullPath);
				connection.Open();
				string commandText = string.Format(CultureInfo.InvariantCulture, "SELECT COUNT(*) C FROM {0} where {1} = @appId ", "ma_events", "ma_app_id");
				using SqliteCommand sqliteCommand = connection.CreateCommand();
				sqliteCommand.CommandText = commandText;
				BindData(sqliteCommand, appID);
				using SqliteDataReader sqliteDataReader = sqliteCommand.ExecuteReader();
				if (sqliteDataReader.HasRows)
				{
					Debug.Log("HAS ROWS = TRUE");
					while (sqliteDataReader.Read())
					{
						num = sqliteDataReader.GetInt32(0);
						Debug.Log($"count = {num}");
					}
				}
			}
			finally
			{
				if (connection != null)
				{
					connection.Close();
					connection.Dispose();
				}
			}
		}
		return num;
	}

	public bool IncrementDeliveryAttempt(List<string> rowIds)
	{
		bool result = false;
		lock (_lock)
		{
			try
			{
				connection = new SqliteConnection("URI=file:" + DBfileFullPath);
				connection.Open();
				string arg = "'" + string.Join("', '", rowIds.ToArray()) + "'";
				string commandText = $"UPDATE ma_events SET ma_delivery_attempt_count= ma_delivery_attempt_count+1 WHERE ma_event_id IN ({arg})";
				using SqliteCommand sqliteCommand = connection.CreateCommand();
				sqliteCommand.CommandText = commandText;
				sqliteCommand.ExecuteNonQuery();
			}
			finally
			{
				if (connection != null)
				{
					connection.Close();
					connection.Dispose();
				}
			}
			return result;
		}
	}

	private static void BindData(SqliteCommand command, params object[] parameters)
	{
		string commandText = command.CommandText;
		int num = 0;
		foreach (Match item in Regex.Matches(commandText, "(\\@\\w+) "))
		{
			DateTime? dateTime = parameters[num] as DateTime?;
			if (dateTime.HasValue)
			{
				command.Parameters.Add(new SqliteParameter(item.Groups[1].Value, dateTime.Value.Ticks.ToString(CultureInfo.InvariantCulture.NumberFormat)));
			}
			else
			{
				command.Parameters.Add(new SqliteParameter(item.Groups[1].Value, parameters[num]));
			}
			num++;
		}
	}
}
