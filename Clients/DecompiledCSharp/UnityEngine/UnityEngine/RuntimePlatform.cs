using System;

namespace UnityEngine;

/// <summary>
///   <para>The platform application is running. Returned by Application.platform.</para>
/// </summary>
public enum RuntimePlatform
{
	/// <summary>
	///   <para>In the Unity editor on Mac OS X.</para>
	/// </summary>
	OSXEditor = 0,
	/// <summary>
	///   <para>In the player on Mac OS X.</para>
	/// </summary>
	OSXPlayer = 1,
	/// <summary>
	///   <para>In the player on Windows.</para>
	/// </summary>
	WindowsPlayer = 2,
	/// <summary>
	///   <para>In the web player on Mac OS X.</para>
	/// </summary>
	OSXWebPlayer = 3,
	/// <summary>
	///   <para>In the Dashboard widget on Mac OS X.</para>
	/// </summary>
	OSXDashboardPlayer = 4,
	/// <summary>
	///   <para>In the web player on Windows.</para>
	/// </summary>
	WindowsWebPlayer = 5,
	/// <summary>
	///   <para>In the Unity editor on Windows.</para>
	/// </summary>
	WindowsEditor = 7,
	/// <summary>
	///   <para>In the player on the iPhone.</para>
	/// </summary>
	IPhonePlayer = 8,
	/// <summary>
	///   <para>In the player on the XBOX360.</para>
	/// </summary>
	XBOX360 = 10,
	/// <summary>
	///   <para>In the player on the Play Station 3.</para>
	/// </summary>
	PS3 = 9,
	/// <summary>
	///   <para>In the player on Android devices.</para>
	/// </summary>
	Android = 11,
	[Obsolete("NaCl export is no longer supported in Unity 5.0+.")]
	NaCl = 12,
	[Obsolete("FlashPlayer export is no longer supported in Unity 5.0+.")]
	FlashPlayer = 15,
	/// <summary>
	///   <para>In the player on Linux.</para>
	/// </summary>
	LinuxPlayer = 13,
	/// <summary>
	///   <para>In the player on WebGL?</para>
	/// </summary>
	WebGLPlayer = 17,
	[Obsolete("Use WSAPlayerX86 instead")]
	MetroPlayerX86 = 18,
	/// <summary>
	///   <para>In the player on Windows Store Apps when CPU architecture is X86.</para>
	/// </summary>
	WSAPlayerX86 = 18,
	[Obsolete("Use WSAPlayerX64 instead")]
	MetroPlayerX64 = 19,
	/// <summary>
	///   <para>In the player on Windows Store Apps when CPU architecture is X64.</para>
	/// </summary>
	WSAPlayerX64 = 19,
	[Obsolete("Use WSAPlayerARM instead")]
	MetroPlayerARM = 20,
	/// <summary>
	///   <para>In the player on Windows Store Apps when CPU architecture is ARM.</para>
	/// </summary>
	WSAPlayerARM = 20,
	/// <summary>
	///   <para>In the player on Windows Phone 8 device.
	/// </para>
	/// </summary>
	WP8Player = 21,
	BlackBerryPlayer = 22,
	/// <summary>
	///   <para>In the player on Tizen.</para>
	/// </summary>
	TizenPlayer = 23,
	/// <summary>
	///   <para>In the player on the PS Vita.</para>
	/// </summary>
	PSP2 = 24,
	/// <summary>
	///   <para>In the player on the Playstation 4.</para>
	/// </summary>
	PS4 = 25,
	PSM = 26,
	/// <summary>
	///   <para>In the player on Xbox One.</para>
	/// </summary>
	XboxOne = 27,
	/// <summary>
	///   <para>In the player on Samsung Smart TV.</para>
	/// </summary>
	SamsungTVPlayer = 28,
	/// <summary>
	///   <para>In the player on Wii U.</para>
	/// </summary>
	WiiU = 30
}
