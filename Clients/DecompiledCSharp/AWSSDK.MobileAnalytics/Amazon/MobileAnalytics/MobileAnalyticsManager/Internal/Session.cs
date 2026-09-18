using System;
using System.IO;
using System.Security;
using System.Threading;
using Amazon.Runtime.Internal;
using Amazon.Runtime.Internal.Util;
using Amazon.Util;
using Amazon.Util.Internal;
using ThirdParty.Json.LitJson;

namespace Amazon.MobileAnalytics.MobileAnalyticsManager.Internal;

[SecuritySafeCritical]
public class Session : IDisposable
{
	internal class SessionStorage
	{
		public DateTime _startTime;

		public DateTime? _stopTime;

		public DateTime _preStartTime;

		public string _sessionId;

		public long _duration;

		public SessionStorage()
		{
			_sessionId = null;
			_duration = 0L;
		}
	}

	private Logger _logger = Logger.GetLogger(typeof(Session));

	private object _lock = new object();

	private MobileAnalyticsManagerConfig _maConfig;

	private volatile SessionStorage _sessionStorage;

	private string _appID;

	private string _sessionStorageFileName = "_session_storage.json";

	private string _sessionStorageFileFullPath;

	public DateTime StartTime { get; set; }

	public DateTime? StopTime { get; set; }

	public DateTime PreStartTime { get; set; }

	public string SessionId { get; set; }

	public long Duration { get; set; }

	[SecuritySafeCritical]
	public Session(string appID, MobileAnalyticsManagerConfig maConfig)
	{
		_maConfig = maConfig;
		_appID = appID;
		_sessionStorageFileFullPath = Path.Combine(AmazonHookedPlatformInfo.Instance.PersistentDataPath, appID + _sessionStorageFileName);
		_logger.InfoFormat("Initialize a new session. The session storage file is {0}.", _sessionStorageFileFullPath);
		_sessionStorage = new SessionStorage();
	}

	public void Start()
	{
		lock (_lock)
		{
			RetrieveSessionStorage();
			if (_sessionStorage != null && !string.IsNullOrEmpty(_sessionStorage._sessionId))
			{
				StartTime = _sessionStorage._startTime;
				StopTime = _sessionStorage._stopTime;
				SessionId = _sessionStorage._sessionId;
				Duration = _sessionStorage._duration;
				Resume();
			}
			else
			{
				NewSessionHelper();
			}
		}
	}

	public void Pause()
	{
		lock (_lock)
		{
			PauseSessionHelper();
			SaveSessionStorage();
		}
	}

	public void Resume()
	{
		lock (_lock)
		{
			if (!StopTime.HasValue)
			{
				_logger.InfoFormat("Call Resume() without calling Pause() first. But this can be valid opertion only when MobileAnalyticsManager instance is created.");
				return;
			}
			DateTime correctedUtcNow = AWSSDKUtils.CorrectedUtcNow;
			if (StopTime.Value < correctedUtcNow)
			{
				if (Convert.ToInt64((correctedUtcNow - StopTime.Value).TotalMilliseconds) > _maConfig.SessionTimeout * 1000)
				{
					StopSessionHelper();
					NewSessionHelper();
				}
				else
				{
					ResumeSessionHelper();
				}
			}
			else
			{
				InvalidOperationException exception = new InvalidOperationException();
				_logger.Error(exception, "Session stop time is earlier than start time !");
			}
		}
	}

	private void NewSessionHelper()
	{
		StartTime = AWSSDKUtils.CorrectedUtcNow;
		PreStartTime = AWSSDKUtils.CorrectedUtcNow;
		StopTime = null;
		SessionId = Guid.NewGuid().ToString();
		Duration = 0L;
		CustomEvent customEvent = new CustomEvent("_session.start");
		customEvent.StartTimestamp = StartTime;
		customEvent.SessionId = SessionId;
		MobileAnalyticsManager.GetInstance(_appID).RecordEvent(customEvent);
	}

	private void StopSessionHelper()
	{
		DateTime correctedUtcNow = AWSSDKUtils.CorrectedUtcNow;
		StopTime = correctedUtcNow;
		CustomEvent customEvent = new CustomEvent("_session.stop");
		customEvent.StartTimestamp = StartTime;
		if (StopTime.HasValue)
		{
			customEvent.StopTimestamp = StopTime;
		}
		customEvent.SessionId = SessionId;
		customEvent.Duration = Duration;
		MobileAnalyticsManager.GetInstance(_appID).RecordEvent(customEvent);
	}

	private void PauseSessionHelper()
	{
		DateTime correctedUtcNow = AWSSDKUtils.CorrectedUtcNow;
		StopTime = correctedUtcNow;
		Duration += Convert.ToInt64((correctedUtcNow - PreStartTime).TotalMilliseconds);
		CustomEvent customEvent = new CustomEvent("_session.pause");
		customEvent.StartTimestamp = StartTime;
		if (StopTime.HasValue)
		{
			customEvent.StopTimestamp = StopTime;
		}
		customEvent.SessionId = SessionId;
		customEvent.Duration = Duration;
		MobileAnalyticsManager.GetInstance(_appID).RecordEvent(customEvent);
	}

	private void ResumeSessionHelper()
	{
		DateTime correctedUtcNow = AWSSDKUtils.CorrectedUtcNow;
		PreStartTime = correctedUtcNow;
		CustomEvent customEvent = new CustomEvent("_session.resume");
		customEvent.StartTimestamp = StartTime;
		if (StopTime.HasValue)
		{
			customEvent.StopTimestamp = StopTime;
		}
		customEvent.SessionId = SessionId;
		customEvent.Duration = Duration;
		MobileAnalyticsManager.GetInstance(_appID).RecordEvent(customEvent);
	}

	private void SaveSessionStorage()
	{
		_sessionStorage._startTime = StartTime;
		_sessionStorage._stopTime = StopTime;
		_sessionStorage._preStartTime = PreStartTime;
		_sessionStorage._sessionId = SessionId;
		_sessionStorage._duration = Duration;
		_logger.DebugFormat("Mobile Analytics is about to store session info: {0} ", JsonMapper.ToJson(_sessionStorage));
		Action action = delegate
		{
			if (!File.Exists(_sessionStorageFileFullPath))
			{
				File.Create(_sessionStorageFileFullPath).Close();
				File.WriteAllText(_sessionStorageFileFullPath, JsonMapper.ToJson(_sessionStorage));
			}
			else
			{
				File.WriteAllText(_sessionStorageFileFullPath, string.Empty);
				File.WriteAllText(_sessionStorageFileFullPath, JsonMapper.ToJson(_sessionStorage));
			}
		};
		if (UnityInitializer.IsMainThread())
		{
			action();
			return;
		}
		ManualResetEvent e = new ManualResetEvent(initialState: false);
		UnityRequestQueue.Instance.ExecuteOnMainThread(delegate
		{
			action();
			e.Set();
		});
		e.WaitOne();
	}

	private void RetrieveSessionStorage()
	{
		string sessionString = null;
		Action action = delegate
		{
			if (File.Exists(_sessionStorageFileFullPath))
			{
				StreamReader streamReader = new StreamReader(_sessionStorageFileFullPath);
				sessionString = streamReader.ReadToEnd();
				streamReader.Close();
				_logger.DebugFormat("Mobile Analytics retrieves session info: {0}", sessionString);
			}
			else
			{
				_logger.DebugFormat("Mobile Analytics session file does not exist.");
			}
		};
		if (UnityInitializer.IsMainThread())
		{
			action();
		}
		else
		{
			ManualResetEvent e = new ManualResetEvent(initialState: false);
			UnityRequestQueue.Instance.ExecuteOnMainThread(delegate
			{
				action();
				e.Set();
			});
			e.WaitOne();
		}
		if (!string.IsNullOrEmpty(sessionString))
		{
			_sessionStorage = JsonMapper.ToObject<SessionStorage>(sessionString);
		}
	}

	public void Dispose()
	{
		Dispose(disposing: true);
		GC.SuppressFinalize(this);
	}

	protected virtual void Dispose(bool disposing)
	{
	}
}
