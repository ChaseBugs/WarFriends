using System;

namespace UnityEngine.iOS;

/// <summary>
///   <para>iOS device generation.</para>
/// </summary>
public enum DeviceGeneration
{
	Unknown = 0,
	/// <summary>
	///   <para>iPhone, first generation.</para>
	/// </summary>
	iPhone = 1,
	/// <summary>
	///   <para>iPhone, second generation.</para>
	/// </summary>
	iPhone3G = 2,
	/// <summary>
	///   <para>iPhone, third generation.</para>
	/// </summary>
	iPhone3GS = 3,
	/// <summary>
	///   <para>iPod Touch, first generation.</para>
	/// </summary>
	iPodTouch1Gen = 4,
	/// <summary>
	///   <para>iPod Touch, second generation.</para>
	/// </summary>
	iPodTouch2Gen = 5,
	/// <summary>
	///   <para>iPod Touch, third generation.</para>
	/// </summary>
	iPodTouch3Gen = 6,
	/// <summary>
	///   <para>iPad, first generation.</para>
	/// </summary>
	iPad1Gen = 7,
	/// <summary>
	///   <para>iPhone, fourth generation.</para>
	/// </summary>
	iPhone4 = 8,
	/// <summary>
	///   <para>iPod Touch, fourth generation.</para>
	/// </summary>
	iPodTouch4Gen = 9,
	/// <summary>
	///   <para>iPad, second generation.</para>
	/// </summary>
	iPad2Gen = 10,
	/// <summary>
	///   <para>iPhone, fifth generation.</para>
	/// </summary>
	iPhone4S = 11,
	/// <summary>
	///   <para>iPad, third generation.</para>
	/// </summary>
	iPad3Gen = 12,
	/// <summary>
	///   <para>iPhone5.</para>
	/// </summary>
	iPhone5 = 13,
	/// <summary>
	///   <para>iPod Touch, fifth generation.</para>
	/// </summary>
	iPodTouch5Gen = 14,
	/// <summary>
	///   <para>iPadMini, first generation.</para>
	/// </summary>
	iPadMini1Gen = 15,
	/// <summary>
	///   <para>iPad, fourth generation.</para>
	/// </summary>
	iPad4Gen = 16,
	/// <summary>
	///   <para>iPhone 5C.</para>
	/// </summary>
	iPhone5C = 17,
	/// <summary>
	///   <para>iPhone 5S.</para>
	/// </summary>
	iPhone5S = 18,
	/// <summary>
	///   <para>iPad Air.</para>
	/// </summary>
	iPadAir1 = 19,
	/// <summary>
	///   <para>iPad Air (fifth generation).</para>
	/// </summary>
	[Obsolete("Please use iPadAir1 instead.")]
	iPad5Gen = 19,
	/// <summary>
	///   <para>iPadMini Retina (second generation).</para>
	/// </summary>
	iPadMini2Gen = 20,
	/// <summary>
	///   <para>iPhone 6.</para>
	/// </summary>
	iPhone6 = 21,
	/// <summary>
	///   <para>iPhone 6 plus.</para>
	/// </summary>
	iPhone6Plus = 22,
	/// <summary>
	///   <para>iPad Mini 3.</para>
	/// </summary>
	iPadMini3Gen = 23,
	/// <summary>
	///   <para>iPad Air 2.</para>
	/// </summary>
	iPadAir2 = 24,
	/// <summary>
	///   <para>iPhone6S value.</para>
	/// </summary>
	iPhone6S = 25,
	/// <summary>
	///   <para>iPhone6Plus value.</para>
	/// </summary>
	iPhone6SPlus = 26,
	/// <summary>
	///   <para>iPadProGen1 value.</para>
	/// </summary>
	iPadPro1Gen = 27,
	/// <summary>
	///   <para>iPadMini 4th Generation.</para>
	/// </summary>
	iPadMini4Gen = 28,
	/// <summary>
	///   <para>Yet unknown iPhone.</para>
	/// </summary>
	iPhoneUnknown = 10001,
	/// <summary>
	///   <para>Yet unknown iPad.</para>
	/// </summary>
	iPadUnknown = 10002,
	/// <summary>
	///   <para>Yet unknown iPodTouch.</para>
	/// </summary>
	iPodTouchUnknown = 10003
}
