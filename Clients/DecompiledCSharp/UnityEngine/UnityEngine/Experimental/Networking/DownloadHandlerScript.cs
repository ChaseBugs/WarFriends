using System.Runtime.InteropServices;

namespace UnityEngine.Experimental.Networking;

/// <summary>
///   <para>An abstract base class for user-created scripting-driven DownloadHandler implementations.</para>
/// </summary>
[StructLayout(LayoutKind.Sequential)]
public class DownloadHandlerScript : DownloadHandler
{
	/// <summary>
	///   <para>Create a DownloadHandlerScript which allocates new buffers when passing data to callbacks.</para>
	/// </summary>
	public DownloadHandlerScript()
	{
	}
}
