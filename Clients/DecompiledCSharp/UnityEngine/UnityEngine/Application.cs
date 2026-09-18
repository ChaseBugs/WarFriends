using System;
using System.Collections;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Security;
using System.Text;
using UnityEngine.Internal;

namespace UnityEngine;

/// <summary>
///   <para>Access to application run-time data.</para>
/// </summary>
public sealed class Application
{
	/// <summary>
	///   <para>Use this delegate type with Application.logMessageReceived or Application.logMessageReceivedThreaded to monitor what gets logged.</para>
	/// </summary>
	/// <param name="condition"></param>
	/// <param name="stackTrace"></param>
	/// <param name="type"></param>
	public delegate void LogCallback(string condition, string stackTrace, LogType type);

	internal static AdvertisingIdentifierCallback OnAdvertisingIdentifierCallback;

	private static LogCallback s_LogCallbackHandler;

	private static LogCallback s_LogCallbackHandlerThreaded;

	private static volatile LogCallback s_RegisterLogCallbackDeprecated;

	/// <summary>
	///   <para>The level index that was last loaded (Read Only).</para>
	/// </summary>
	public static extern int loadedLevel
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		get;
	}

	/// <summary>
	///   <para>The name of the level that was last loaded (Read Only).</para>
	/// </summary>
	public static extern string loadedLevelName
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		get;
	}

	/// <summary>
	///   <para>Is some level being loaded? (Read Only)</para>
	/// </summary>
	[Obsolete("This property is deprecated, please use LoadLevelAsync to detect if a specific scene is currently loading.")]
	public static extern bool isLoadingLevel
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		get;
	}

	/// <summary>
	///   <para>The total number of levels available (Read Only).</para>
	/// </summary>
	public static extern int levelCount
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		get;
	}

	/// <summary>
	///   <para>How many bytes have we downloaded from the main unity web stream (Read Only).</para>
	/// </summary>
	public static extern int streamedBytes
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		get;
	}

	/// <summary>
	///   <para>Returns true when in any kind of player (Read Only).</para>
	/// </summary>
	public static extern bool isPlaying
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		get;
	}

	/// <summary>
	///   <para>Are we running inside the Unity editor? (Read Only)</para>
	/// </summary>
	public static extern bool isEditor
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		get;
	}

	/// <summary>
	///   <para>Are we running inside a web player? (Read Only)</para>
	/// </summary>
	public static extern bool isWebPlayer
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		get;
	}

	/// <summary>
	///   <para>Returns the platform the game is running (Read Only).</para>
	/// </summary>
	public static extern RuntimePlatform platform
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		get;
	}

	/// <summary>
	///   <para>Is the current Runtime platform a known mobile platform.</para>
	/// </summary>
	public static bool isMobilePlatform
	{
		get
		{
			switch (platform)
			{
			case RuntimePlatform.IPhonePlayer:
			case RuntimePlatform.Android:
			case RuntimePlatform.MetroPlayerX86:
			case RuntimePlatform.MetroPlayerX64:
			case RuntimePlatform.MetroPlayerARM:
			case RuntimePlatform.WP8Player:
			case RuntimePlatform.BlackBerryPlayer:
			case RuntimePlatform.TizenPlayer:
				return true;
			default:
				return false;
			}
		}
	}

	/// <summary>
	///   <para>Is the current Runtime platform a known console platform.</para>
	/// </summary>
	public static bool isConsolePlatform
	{
		get
		{
			RuntimePlatform runtimePlatform = platform;
			return runtimePlatform == RuntimePlatform.PS3 || runtimePlatform == RuntimePlatform.PS4 || runtimePlatform == RuntimePlatform.XBOX360 || runtimePlatform == RuntimePlatform.XboxOne;
		}
	}

	/// <summary>
	///   <para>Should the player be running when the application is in the background?</para>
	/// </summary>
	public static extern bool runInBackground
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		get;
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		set;
	}

	[Obsolete("use Application.isEditor instead")]
	public static bool isPlayer => !isEditor;

	internal static extern bool isBatchmode
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		get;
	}

	internal static extern bool isHumanControllingUs
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		get;
	}

	internal static extern bool isRunningUnitTests
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		get;
	}

	/// <summary>
	///   <para>Contains the path to the game data folder (Read Only).</para>
	/// </summary>
	public static extern string dataPath
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		get;
	}

	/// <summary>
	///   <para>Contains the path to the StreamingAssets folder (Read Only).</para>
	/// </summary>
	public static extern string streamingAssetsPath
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		get;
	}

	/// <summary>
	///   <para>Contains the path to a persistent data directory (Read Only).</para>
	/// </summary>
	[SecurityCritical]
	public static extern string persistentDataPath
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		get;
	}

	/// <summary>
	///   <para>Contains the path to a temporary data / cache directory (Read Only).</para>
	/// </summary>
	public static extern string temporaryCachePath
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		get;
	}

	/// <summary>
	///   <para>The path to the web player data file relative to the html file (Read Only).</para>
	/// </summary>
	public static extern string srcValue
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		get;
	}

	/// <summary>
	///   <para>The absolute path to the web player data file (Read Only).</para>
	/// </summary>
	public static extern string absoluteURL
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		get;
	}

	/// <summary>
	///   <para>The version of the Unity runtime used to play the content.</para>
	/// </summary>
	public static extern string unityVersion
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		get;
	}

	/// <summary>
	///   <para>Returns application version number  (Read Only).</para>
	/// </summary>
	public static extern string version
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		get;
	}

	/// <summary>
	///   <para>Returns application bundle identifier at runtime.</para>
	/// </summary>
	public static extern string bundleIdentifier
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		get;
	}

	/// <summary>
	///   <para>Returns application install mode (Read Only).</para>
	/// </summary>
	public static extern ApplicationInstallMode installMode
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		get;
	}

	/// <summary>
	///   <para>Returns application running in sandbox (Read Only).</para>
	/// </summary>
	public static extern ApplicationSandboxType sandboxType
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		get;
	}

	/// <summary>
	///   <para>Returns application product name (Read Only).</para>
	/// </summary>
	public static extern string productName
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		get;
	}

	/// <summary>
	///   <para>Return application company name (Read Only).</para>
	/// </summary>
	public static extern string companyName
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		get;
	}

	/// <summary>
	///   <para>A unique cloud project identifier. It is unique for every project (Read Only).</para>
	/// </summary>
	public static extern string cloudProjectId
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		get;
	}

	/// <summary>
	///   <para>Indicates whether Unity's webplayer security model is enabled.</para>
	/// </summary>
	public static extern bool webSecurityEnabled
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		get;
	}

	public static extern string webSecurityHostUrl
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		get;
	}

	/// <summary>
	///   <para>Instructs game to try to render at a specified frame rate.</para>
	/// </summary>
	public static extern int targetFrameRate
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		get;
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		set;
	}

	/// <summary>
	///   <para>The language the user's operating system is running in.</para>
	/// </summary>
	public static extern SystemLanguage systemLanguage
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		get;
	}

	/// <summary>
	///   <para>Stack trace logging options. The default value is StackTraceLogType.ScriptOnly.</para>
	/// </summary>
	public static extern StackTraceLogType stackTraceLogType
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		get;
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		set;
	}

	/// <summary>
	///   <para>Priority of background loading thread.</para>
	/// </summary>
	public static extern ThreadPriority backgroundLoadingPriority
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		get;
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		set;
	}

	/// <summary>
	///   <para>Returns the type of Internet reachability currently possible on the device.</para>
	/// </summary>
	public static extern NetworkReachability internetReachability
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		get;
	}

	/// <summary>
	///   <para>Returns false if application is altered in any way after it was built.</para>
	/// </summary>
	public static extern bool genuine
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		get;
	}

	/// <summary>
	///   <para>Returns true if application integrity can be confirmed.</para>
	/// </summary>
	public static extern bool genuineCheckAvailable
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		get;
	}

	internal static extern bool submitAnalytics
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		get;
	}

	/// <summary>
	///   <para>Checks whether splash screen is being shown.</para>
	/// </summary>
	public static extern bool isShowingSplashScreen
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		get;
	}

	public static event LogCallback logMessageReceived
	{
		add
		{
			s_LogCallbackHandler = (LogCallback)Delegate.Combine(s_LogCallbackHandler, value);
			SetLogCallbackDefined(defined: true, s_LogCallbackHandlerThreaded != null);
		}
		remove
		{
			s_LogCallbackHandler = (LogCallback)Delegate.Remove(s_LogCallbackHandler, value);
		}
	}

	public static event LogCallback logMessageReceivedThreaded
	{
		add
		{
			s_LogCallbackHandlerThreaded = (LogCallback)Delegate.Combine(s_LogCallbackHandlerThreaded, value);
			SetLogCallbackDefined(defined: true, threaded: true);
		}
		remove
		{
			s_LogCallbackHandlerThreaded = (LogCallback)Delegate.Remove(s_LogCallbackHandlerThreaded, value);
		}
	}

	/// <summary>
	///   <para>Quits the player application.</para>
	/// </summary>
	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	public static extern void Quit();

	/// <summary>
	///   <para>Cancels quitting the application. This is useful for showing a splash screen at the end of a game.</para>
	/// </summary>
	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	public static extern void CancelQuit();

	/// <summary>
	///   <para>Loads the level by its name or index.</para>
	/// </summary>
	/// <param name="index">The level to load.</param>
	/// <param name="name">The name of the level to load.</param>
	public static void LoadLevel(int index)
	{
		LoadLevelAsync(null, index, additive: false, mustCompleteNextFrame: true);
	}

	/// <summary>
	///   <para>Loads the level by its name or index.</para>
	/// </summary>
	/// <param name="index">The level to load.</param>
	/// <param name="name">The name of the level to load.</param>
	public static void LoadLevel(string name)
	{
		LoadLevelAsync(name, -1, additive: false, mustCompleteNextFrame: true);
	}

	/// <summary>
	///   <para>Loads the level asynchronously in the background.</para>
	/// </summary>
	/// <param name="index"></param>
	/// <param name="levelName"></param>
	public static AsyncOperation LoadLevelAsync(int index)
	{
		return LoadLevelAsync(null, index, additive: false, mustCompleteNextFrame: false);
	}

	/// <summary>
	///   <para>Loads the level asynchronously in the background.</para>
	/// </summary>
	/// <param name="index"></param>
	/// <param name="levelName"></param>
	public static AsyncOperation LoadLevelAsync(string levelName)
	{
		return LoadLevelAsync(levelName, -1, additive: false, mustCompleteNextFrame: false);
	}

	/// <summary>
	///   <para>Loads the level additively and asynchronously in the background.</para>
	/// </summary>
	/// <param name="index"></param>
	/// <param name="levelName"></param>
	public static AsyncOperation LoadLevelAdditiveAsync(int index)
	{
		return LoadLevelAsync(null, index, additive: true, mustCompleteNextFrame: false);
	}

	/// <summary>
	///   <para>Loads the level additively and asynchronously in the background.</para>
	/// </summary>
	/// <param name="index"></param>
	/// <param name="levelName"></param>
	public static AsyncOperation LoadLevelAdditiveAsync(string levelName)
	{
		return LoadLevelAsync(levelName, -1, additive: true, mustCompleteNextFrame: false);
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	private static extern AsyncOperation LoadLevelAsync(string monoLevelName, int index, bool additive, bool mustCompleteNextFrame);

	/// <summary>
	///   <para>Unloads all GameObject associated with the given scene. Note that assets are currently not unloaded, in order to free up asset memory call Resources.UnloadAllUnusedAssets.</para>
	/// </summary>
	/// <param name="index">Index of the scene in the PlayerSettings to unload.</param>
	/// <param name="scenePath">Name of the scene to Unload.</param>
	/// <returns>
	///   <para>Return true if the scene is unloaded.</para>
	/// </returns>
	public static bool UnloadLevel(int index)
	{
		return UnloadLevel(string.Empty, index);
	}

	/// <summary>
	///   <para>Unloads all GameObject associated with the given scene. Note that assets are currently not unloaded, in order to free up asset memory call Resources.UnloadAllUnusedAssets.</para>
	/// </summary>
	/// <param name="index">Index of the scene in the PlayerSettings to unload.</param>
	/// <param name="scenePath">Name of the scene to Unload.</param>
	/// <returns>
	///   <para>Return true if the scene is unloaded.</para>
	/// </returns>
	public static bool UnloadLevel(string scenePath)
	{
		return UnloadLevel(scenePath, -1);
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	private static extern bool UnloadLevel(string monoScenePath, int index);

	/// <summary>
	///   <para>Loads a level additively.</para>
	/// </summary>
	/// <param name="index"></param>
	/// <param name="name"></param>
	public static void LoadLevelAdditive(int index)
	{
		LoadLevelAsync(null, index, additive: true, mustCompleteNextFrame: true);
	}

	/// <summary>
	///   <para>Loads a level additively.</para>
	/// </summary>
	/// <param name="index"></param>
	/// <param name="name"></param>
	public static void LoadLevelAdditive(string name)
	{
		LoadLevelAsync(name, -1, additive: true, mustCompleteNextFrame: true);
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	private static extern float GetStreamProgressForLevelByName(string levelName);

	/// <summary>
	///   <para>How far has the download progressed? [0...1].</para>
	/// </summary>
	/// <param name="levelIndex"></param>
	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	public static extern float GetStreamProgressForLevel(int levelIndex);

	/// <summary>
	///   <para>How far has the download progressed? [0...1].</para>
	/// </summary>
	/// <param name="levelName"></param>
	public static float GetStreamProgressForLevel(string levelName)
	{
		return GetStreamProgressForLevelByName(levelName);
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	private static extern bool CanStreamedLevelBeLoadedByName(string levelName);

	/// <summary>
	///   <para>Can the streamed level be loaded?</para>
	/// </summary>
	/// <param name="levelIndex"></param>
	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	public static extern bool CanStreamedLevelBeLoaded(int levelIndex);

	/// <summary>
	///   <para>Can the streamed level be loaded?</para>
	/// </summary>
	/// <param name="levelName"></param>
	public static bool CanStreamedLevelBeLoaded(string levelName)
	{
		return CanStreamedLevelBeLoadedByName(levelName);
	}

	/// <summary>
	///   <para>Captures a screenshot at path filename as a PNG file.</para>
	/// </summary>
	/// <param name="filename">Pathname to save the screenshot file to.</param>
	/// <param name="superSize">Factor by which to increase resolution.</param>
	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	public static extern void CaptureScreenshot(string filename, [DefaultValue("0")] int superSize);

	/// <summary>
	///   <para>Captures a screenshot at path filename as a PNG file.</para>
	/// </summary>
	/// <param name="filename">Pathname to save the screenshot file to.</param>
	/// <param name="superSize">Factor by which to increase resolution.</param>
	[ExcludeFromDocs]
	public static void CaptureScreenshot(string filename)
	{
		int superSize = 0;
		CaptureScreenshot(filename, superSize);
	}

	/// <summary>
	///   <para>Is Unity activated with the Pro license?</para>
	/// </summary>
	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	public static extern bool HasProLicense();

	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	internal static extern bool HasAdvancedLicense();

	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	internal static extern bool HasARGV(string name);

	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	internal static extern string GetValueForARGV(string name);

	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	[Obsolete("Use Object.DontDestroyOnLoad instead")]
	public static extern void DontDestroyOnLoad(Object mono);

	private static string ObjectToJSString(object o)
	{
		if (o == null)
		{
			return "null";
		}
		if (o is string)
		{
			string text = o.ToString().Replace("\\", "\\\\");
			text = text.Replace("\"", "\\\"");
			text = text.Replace("\n", "\\n");
			text = text.Replace("\r", "\\r");
			text = text.Replace("\0", string.Empty);
			text = text.Replace("\u2028", string.Empty);
			text = text.Replace("\u2029", string.Empty);
			return '"' + text + '"';
		}
		if (o is int || o is short || o is uint || o is ushort || o is byte)
		{
			return o.ToString();
		}
		if (o is float)
		{
			NumberFormatInfo numberFormat = CultureInfo.InvariantCulture.NumberFormat;
			return ((float)o).ToString(numberFormat);
		}
		if (o is double)
		{
			NumberFormatInfo numberFormat2 = CultureInfo.InvariantCulture.NumberFormat;
			return ((double)o).ToString(numberFormat2);
		}
		if (o is char)
		{
			if ((char)o == '"')
			{
				return "\"\\\"\"";
			}
			return '"' + o.ToString() + '"';
		}
		if (o is IList)
		{
			IList list = (IList)o;
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("new Array(");
			int count = list.Count;
			for (int i = 0; i < count; i++)
			{
				if (i != 0)
				{
					stringBuilder.Append(", ");
				}
				stringBuilder.Append(ObjectToJSString(list[i]));
			}
			stringBuilder.Append(")");
			return stringBuilder.ToString();
		}
		return ObjectToJSString(o.ToString());
	}

	/// <summary>
	///   <para>Calls a function in the containing web page (Web Player only).</para>
	/// </summary>
	/// <param name="functionName"></param>
	/// <param name="args"></param>
	public static void ExternalCall(string functionName, params object[] args)
	{
		Internal_ExternalCall(BuildInvocationForArguments(functionName, args));
	}

	private static string BuildInvocationForArguments(string functionName, params object[] args)
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append(functionName);
		stringBuilder.Append('(');
		int num = args.Length;
		for (int i = 0; i < num; i++)
		{
			if (i != 0)
			{
				stringBuilder.Append(", ");
			}
			stringBuilder.Append(ObjectToJSString(args[i]));
		}
		stringBuilder.Append(')');
		stringBuilder.Append(';');
		return stringBuilder.ToString();
	}

	/// <summary>
	///   <para>Evaluates script function in the containing web page.</para>
	/// </summary>
	/// <param name="script">The Javascript function to call.</param>
	public static void ExternalEval(string script)
	{
		if (script.Length > 0 && script[script.Length - 1] != ';')
		{
			script += ';';
		}
		Internal_ExternalCall(script);
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	private static extern void Internal_ExternalCall(string script);

	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	internal static extern int GetBuildUnityVersion();

	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	internal static extern int GetNumericUnityVersion(string version);

	internal static void InvokeOnAdvertisingIdentifierCallback(string advertisingId, bool trackingEnabled)
	{
		if (OnAdvertisingIdentifierCallback != null)
		{
			OnAdvertisingIdentifierCallback(advertisingId, trackingEnabled);
		}
	}

	/// <summary>
	///   <para>Opens the url in a browser.</para>
	/// </summary>
	/// <param name="url"></param>
	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	public static extern void OpenURL(string url);

	[MethodImpl(MethodImplOptions.InternalCall)]
	[Obsolete("For internal use only")]
	[WrapperlessIcall]
	public static extern void CommitSuicide(int mode);

	private static void CallLogCallback(string logString, string stackTrace, LogType type, bool invokedOnMainThread)
	{
		if (invokedOnMainThread)
		{
			s_LogCallbackHandler?.Invoke(logString, stackTrace, type);
		}
		s_LogCallbackHandlerThreaded?.Invoke(logString, stackTrace, type);
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	private static extern void SetLogCallbackDefined(bool defined, bool threaded);

	/// <summary>
	///   <para>Request authorization to use the webcam or microphone in the Web Player.</para>
	/// </summary>
	/// <param name="mode"></param>
	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	public static extern AsyncOperation RequestUserAuthorization(UserAuthorization mode);

	/// <summary>
	///   <para>Check if the user has authorized use of the webcam or microphone in the Web Player.</para>
	/// </summary>
	/// <param name="mode"></param>
	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	public static extern bool HasUserAuthorization(UserAuthorization mode);

	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	internal static extern void ReplyToUserAuthorizationRequest(bool reply, [DefaultValue("false")] bool remember);

	[ExcludeFromDocs]
	internal static void ReplyToUserAuthorizationRequest(bool reply)
	{
		bool remember = false;
		ReplyToUserAuthorizationRequest(reply, remember);
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	private static extern int GetUserAuthorizationRequestMode_Internal();

	internal static UserAuthorization GetUserAuthorizationRequestMode()
	{
		return (UserAuthorization)GetUserAuthorizationRequestMode_Internal();
	}

	[Obsolete("Application.RegisterLogCallback is deprecated. Use Application.logMessageReceived instead.")]
	public static void RegisterLogCallback(LogCallback handler)
	{
		RegisterLogCallback(handler, threaded: false);
	}

	[Obsolete("Application.RegisterLogCallbackThreaded is deprecated. Use Application.logMessageReceivedThreaded instead.")]
	public static void RegisterLogCallbackThreaded(LogCallback handler)
	{
		RegisterLogCallback(handler, threaded: true);
	}

	private static void RegisterLogCallback(LogCallback handler, bool threaded)
	{
		if (s_RegisterLogCallbackDeprecated != null)
		{
			logMessageReceived -= s_RegisterLogCallbackDeprecated;
			logMessageReceivedThreaded -= s_RegisterLogCallbackDeprecated;
		}
		s_RegisterLogCallbackDeprecated = handler;
		if (handler != null)
		{
			if (threaded)
			{
				logMessageReceivedThreaded += handler;
			}
			else
			{
				logMessageReceived += handler;
			}
		}
	}
}
