namespace UnityEngine;

/// <summary>
///   <para>Types of UnityGUI input and processing events.</para>
/// </summary>
public enum EventType
{
	/// <summary>
	///   <para>Mouse button was pressed.</para>
	/// </summary>
	MouseDown = 0,
	/// <summary>
	///   <para>Mouse button was released.</para>
	/// </summary>
	MouseUp = 1,
	/// <summary>
	///   <para>Mouse was moved (editor views only).</para>
	/// </summary>
	MouseMove = 2,
	/// <summary>
	///   <para>Mouse was dragged.</para>
	/// </summary>
	MouseDrag = 3,
	/// <summary>
	///   <para>A keyboard key was pressed.</para>
	/// </summary>
	KeyDown = 4,
	/// <summary>
	///   <para>A keyboard key was released.</para>
	/// </summary>
	KeyUp = 5,
	/// <summary>
	///   <para>The scroll wheel was moved.</para>
	/// </summary>
	ScrollWheel = 6,
	/// <summary>
	///   <para>A repaint event. One is sent every frame.</para>
	/// </summary>
	Repaint = 7,
	/// <summary>
	///   <para>A layout event.</para>
	/// </summary>
	Layout = 8,
	/// <summary>
	///   <para>Editor only: drag &amp; drop operation updated.</para>
	/// </summary>
	DragUpdated = 9,
	/// <summary>
	///   <para>Editor only: drag &amp; drop operation performed.</para>
	/// </summary>
	DragPerform = 10,
	/// <summary>
	///   <para>Editor only: drag &amp; drop operation exited.</para>
	/// </summary>
	DragExited = 15,
	/// <summary>
	///   <para>Event should be ignored.</para>
	/// </summary>
	Ignore = 11,
	/// <summary>
	///   <para>Already processed event.</para>
	/// </summary>
	Used = 12,
	/// <summary>
	///   <para>Validates a special command (e.g. copy &amp; paste).</para>
	/// </summary>
	ValidateCommand = 13,
	/// <summary>
	///   <para>Execute a special command (eg. copy &amp; paste).</para>
	/// </summary>
	ExecuteCommand = 14,
	/// <summary>
	///   <para>User has right-clicked (or control-clicked on the mac).</para>
	/// </summary>
	ContextClick = 16,
	mouseDown = 0,
	mouseUp = 1,
	mouseMove = 2,
	mouseDrag = 3,
	keyDown = 4,
	keyUp = 5,
	scrollWheel = 6,
	repaint = 7,
	layout = 8,
	dragUpdated = 9,
	dragPerform = 10,
	ignore = 11,
	used = 12
}
