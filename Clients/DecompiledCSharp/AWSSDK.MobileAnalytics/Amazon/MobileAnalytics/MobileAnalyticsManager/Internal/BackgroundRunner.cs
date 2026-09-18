using System;
using System.Collections.Generic;
using System.Threading;
using Amazon.MobileAnalytics.Model;
using Amazon.Runtime.Internal;
using Amazon.Runtime.Internal.Util;
using UnityEngine;

namespace Amazon.MobileAnalytics.MobileAnalyticsManager.Internal;

public class BackgroundRunner
{
	private static volatile bool ShouldStop;

	private Logger _logger = Logger.GetLogger(typeof(BackgroundRunner));

	private object _lock = new object();

	private const int BackgroundSubmissionWaitTime = 60;

	private static Thread _thread;

	private static volatile bool _shouldStop;

	public static void AbortBackgroundRunner()
	{
		ShouldStop = true;
	}

	private bool IsAlive()
	{
		if (_thread != null && _thread.ThreadState != ThreadState.Stopped && _thread.ThreadState != ThreadState.Aborted)
		{
			return _thread.ThreadState != ThreadState.AbortRequested;
		}
		return false;
	}

	public void StartWork()
	{
		lock (_lock)
		{
			if (!IsAlive())
			{
				_thread = new Thread(DoWork);
				_thread.Start();
			}
		}
	}

	public static void AbortBackgroundThread()
	{
		_shouldStop = true;
		if (_thread != null)
		{
			_thread.Join();
			_thread = null;
		}
	}

	private void DoWork()
	{
		while (!_shouldStop)
		{
			try
			{
				_logger.InfoFormat("Mobile Analytics Manager is trying to deliver events in background thread.");
				foreach (string key in MobileAnalyticsManager.CopyOfInstanceDictionary.Keys)
				{
					MobileAnalyticsManager mobileAnalyticsManager = null;
					try
					{
						mobileAnalyticsManager = MobileAnalyticsManager.GetInstance(key);
						mobileAnalyticsManager.BackgroundDeliveryClient.AttemptDelivery();
					}
					catch (Exception ex)
					{
						_logger.Error(ex, "An exception occurred in Mobile Analytics Delivery Client : {0}", ex.ToString());
						if (mobileAnalyticsManager != null)
						{
							MobileAnalyticsErrorEventArgs eventArgs = new MobileAnalyticsErrorEventArgs(GetType().Name, "An exception occurred when deliverying events to Amazon Mobile Analytics.", ex, new List<Amazon.MobileAnalytics.Model.Event>());
							mobileAnalyticsManager.OnRaiseErrorEvent(eventArgs);
						}
					}
				}
				Thread.Sleep(60000);
			}
			catch (ThreadAbortException)
			{
				_logger.DebugFormat("Mobile Analytics Manager thread aborted");
			}
			catch (Exception exception)
			{
				_logger.Error(exception, "An exception occurred in Mobile Analytics Manager.");
			}
			UnityRequestQueue.Instance.ExecuteOnMainThread(delegate
			{
				if (Application.isEditor && !Application.isPlaying)
				{
					AbortBackgroundThread();
				}
			});
		}
	}
}
