using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace UnityEngine;

/// <summary>
///   <para>A UnityGUI event.</para>
/// </summary>
[StructLayout(LayoutKind.Sequential)]
public sealed class Event
{
	[NonSerialized]
	internal IntPtr m_Ptr;

	private static Event s_Current;

	private static Event s_MasterEvent;

	/// <summary>
	///   <para>The mouse position.</para>
	/// </summary>
	public Vector2 mousePosition
	{
		get
		{
			Internal_GetMousePosition(out var value);
			return value;
		}
		set
		{
			Internal_SetMousePosition(value);
		}
	}

	/// <summary>
	///   <para>The relative movement of the mouse compared to last event.</para>
	/// </summary>
	public Vector2 delta
	{
		get
		{
			Internal_GetMouseDelta(out var value);
			return value;
		}
		set
		{
			Internal_SetMouseDelta(value);
		}
	}

	[Obsolete("Use HandleUtility.GUIPointToWorldRay(Event.current.mousePosition);", true)]
	public Ray mouseRay
	{
		get
		{
			return new Ray(Vector3.up, Vector3.up);
		}
		set
		{
		}
	}

	/// <summary>
	///   <para>Is Shift held down? (Read Only)</para>
	/// </summary>
	public bool shift
	{
		get
		{
			return (modifiers & EventModifiers.Shift) != 0;
		}
		set
		{
			if (!value)
			{
				modifiers &= ~EventModifiers.Shift;
			}
			else
			{
				modifiers |= EventModifiers.Shift;
			}
		}
	}

	/// <summary>
	///   <para>Is Control key held down? (Read Only)</para>
	/// </summary>
	public bool control
	{
		get
		{
			return (modifiers & EventModifiers.Control) != 0;
		}
		set
		{
			if (!value)
			{
				modifiers &= ~EventModifiers.Control;
			}
			else
			{
				modifiers |= EventModifiers.Control;
			}
		}
	}

	/// <summary>
	///   <para>Is Alt/Option key held down? (Read Only)</para>
	/// </summary>
	public bool alt
	{
		get
		{
			return (modifiers & EventModifiers.Alt) != 0;
		}
		set
		{
			if (!value)
			{
				modifiers &= ~EventModifiers.Alt;
			}
			else
			{
				modifiers |= EventModifiers.Alt;
			}
		}
	}

	/// <summary>
	///   <para>Is Command/Windows key held down? (Read Only)</para>
	/// </summary>
	public bool command
	{
		get
		{
			return (modifiers & EventModifiers.Command) != 0;
		}
		set
		{
			if (!value)
			{
				modifiers &= ~EventModifiers.Command;
			}
			else
			{
				modifiers |= EventModifiers.Command;
			}
		}
	}

	/// <summary>
	///   <para>Is Caps Lock on? (Read Only)</para>
	/// </summary>
	public bool capsLock
	{
		get
		{
			return (modifiers & EventModifiers.CapsLock) != 0;
		}
		set
		{
			if (!value)
			{
				modifiers &= ~EventModifiers.CapsLock;
			}
			else
			{
				modifiers |= EventModifiers.CapsLock;
			}
		}
	}

	/// <summary>
	///   <para>Is the current keypress on the numeric keyboard? (Read Only)</para>
	/// </summary>
	public bool numeric
	{
		get
		{
			return (modifiers & EventModifiers.Numeric) != 0;
		}
		set
		{
			if (!value)
			{
				modifiers &= ~EventModifiers.Shift;
			}
			else
			{
				modifiers |= EventModifiers.Shift;
			}
		}
	}

	/// <summary>
	///   <para>Is the current keypress a function key? (Read Only)</para>
	/// </summary>
	public bool functionKey => (modifiers & EventModifiers.FunctionKey) != 0;

	/// <summary>
	///   <para>The current event that's being processed right now.</para>
	/// </summary>
	public static Event current
	{
		get
		{
			return s_Current;
		}
		set
		{
			if (value != null)
			{
				s_Current = value;
			}
			else
			{
				s_Current = s_MasterEvent;
			}
			Internal_SetNativeEvent(s_Current.m_Ptr);
		}
	}

	/// <summary>
	///   <para>Is this event a keyboard event? (Read Only)</para>
	/// </summary>
	public bool isKey
	{
		get
		{
			EventType eventType = type;
			return eventType == EventType.KeyDown || eventType == EventType.KeyUp;
		}
	}

	/// <summary>
	///   <para>Is this event a mouse event? (Read Only)</para>
	/// </summary>
	public bool isMouse
	{
		get
		{
			EventType eventType = type;
			return eventType == EventType.MouseMove || eventType == EventType.MouseDown || eventType == EventType.MouseUp || eventType == EventType.MouseDrag;
		}
	}

	public extern EventType rawType
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		get;
	}

	/// <summary>
	///   <para>The type of event.</para>
	/// </summary>
	public extern EventType type
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		get;
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		set;
	}

	/// <summary>
	///   <para>Which mouse button was pressed.</para>
	/// </summary>
	public extern int button
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		get;
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		set;
	}

	/// <summary>
	///   <para>Which modifier keys are held down.</para>
	/// </summary>
	public extern EventModifiers modifiers
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		get;
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		set;
	}

	public extern float pressure
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		get;
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		set;
	}

	/// <summary>
	///   <para>How many consecutive mouse clicks have we received.</para>
	/// </summary>
	public extern int clickCount
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		get;
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		set;
	}

	/// <summary>
	///   <para>The character typed.</para>
	/// </summary>
	public extern char character
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		get;
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		set;
	}

	/// <summary>
	///   <para>The name of an ExecuteCommand or ValidateCommand Event.</para>
	/// </summary>
	public extern string commandName
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		get;
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		set;
	}

	/// <summary>
	///   <para>The raw key code for keyboard events.</para>
	/// </summary>
	public extern KeyCode keyCode
	{
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		get;
		[MethodImpl(MethodImplOptions.InternalCall)]
		[WrapperlessIcall]
		set;
	}

	public Event()
	{
		Init();
	}

	public Event(Event other)
	{
		if (other == null)
		{
			throw new ArgumentException("Event to copy from is null.");
		}
		InitCopy(other);
	}

	private Event(IntPtr ptr)
	{
		InitPtr(ptr);
	}

	~Event()
	{
		Cleanup();
	}

	private static void Internal_MakeMasterEventCurrent()
	{
		if (s_MasterEvent == null)
		{
			s_MasterEvent = new Event();
		}
		s_Current = s_MasterEvent;
		Internal_SetNativeEvent(s_MasterEvent.m_Ptr);
	}

	/// <summary>
	///   <para>Create a keyboard event.</para>
	/// </summary>
	/// <param name="key"></param>
	public static Event KeyboardEvent(string key)
	{
		Event obj = new Event();
		obj.type = EventType.KeyDown;
		if (string.IsNullOrEmpty(key))
		{
			return obj;
		}
		int num = 0;
		bool flag = false;
		do
		{
			flag = true;
			if (num >= key.Length)
			{
				flag = false;
				break;
			}
			switch (key[num])
			{
			case '&':
				obj.modifiers |= EventModifiers.Alt;
				num++;
				break;
			case '^':
				obj.modifiers |= EventModifiers.Control;
				num++;
				break;
			case '%':
				obj.modifiers |= EventModifiers.Command;
				num++;
				break;
			case '#':
				obj.modifiers |= EventModifiers.Shift;
				num++;
				break;
			default:
				flag = false;
				break;
			}
		}
		while (flag);
		string text = key.Substring(num, key.Length - num).ToLower();
		switch (text)
		{
		case "[0]":
			obj.character = '0';
			obj.keyCode = KeyCode.Keypad0;
			break;
		case "[1]":
			obj.character = '1';
			obj.keyCode = KeyCode.Keypad1;
			break;
		case "[2]":
			obj.character = '2';
			obj.keyCode = KeyCode.Keypad2;
			break;
		case "[3]":
			obj.character = '3';
			obj.keyCode = KeyCode.Keypad3;
			break;
		case "[4]":
			obj.character = '4';
			obj.keyCode = KeyCode.Keypad4;
			break;
		case "[5]":
			obj.character = '5';
			obj.keyCode = KeyCode.Keypad5;
			break;
		case "[6]":
			obj.character = '6';
			obj.keyCode = KeyCode.Keypad6;
			break;
		case "[7]":
			obj.character = '7';
			obj.keyCode = KeyCode.Keypad7;
			break;
		case "[8]":
			obj.character = '8';
			obj.keyCode = KeyCode.Keypad8;
			break;
		case "[9]":
			obj.character = '9';
			obj.keyCode = KeyCode.Keypad9;
			break;
		case "[.]":
			obj.character = '.';
			obj.keyCode = KeyCode.KeypadPeriod;
			break;
		case "[/]":
			obj.character = '/';
			obj.keyCode = KeyCode.KeypadDivide;
			break;
		case "[-]":
			obj.character = '-';
			obj.keyCode = KeyCode.KeypadMinus;
			break;
		case "[+]":
			obj.character = '+';
			obj.keyCode = KeyCode.KeypadPlus;
			break;
		case "[=]":
			obj.character = '=';
			obj.keyCode = KeyCode.KeypadEquals;
			break;
		case "[equals]":
			obj.character = '=';
			obj.keyCode = KeyCode.KeypadEquals;
			break;
		case "[enter]":
			obj.character = '\n';
			obj.keyCode = KeyCode.KeypadEnter;
			break;
		case "up":
			obj.keyCode = KeyCode.UpArrow;
			obj.modifiers |= EventModifiers.FunctionKey;
			break;
		case "down":
			obj.keyCode = KeyCode.DownArrow;
			obj.modifiers |= EventModifiers.FunctionKey;
			break;
		case "left":
			obj.keyCode = KeyCode.LeftArrow;
			obj.modifiers |= EventModifiers.FunctionKey;
			break;
		case "right":
			obj.keyCode = KeyCode.RightArrow;
			obj.modifiers |= EventModifiers.FunctionKey;
			break;
		case "insert":
			obj.keyCode = KeyCode.Insert;
			obj.modifiers |= EventModifiers.FunctionKey;
			break;
		case "home":
			obj.keyCode = KeyCode.Home;
			obj.modifiers |= EventModifiers.FunctionKey;
			break;
		case "end":
			obj.keyCode = KeyCode.End;
			obj.modifiers |= EventModifiers.FunctionKey;
			break;
		case "pgup":
			obj.keyCode = KeyCode.PageDown;
			obj.modifiers |= EventModifiers.FunctionKey;
			break;
		case "page up":
			obj.keyCode = KeyCode.PageUp;
			obj.modifiers |= EventModifiers.FunctionKey;
			break;
		case "pgdown":
			obj.keyCode = KeyCode.PageUp;
			obj.modifiers |= EventModifiers.FunctionKey;
			break;
		case "page down":
			obj.keyCode = KeyCode.PageDown;
			obj.modifiers |= EventModifiers.FunctionKey;
			break;
		case "backspace":
			obj.keyCode = KeyCode.Backspace;
			obj.modifiers |= EventModifiers.FunctionKey;
			break;
		case "delete":
			obj.keyCode = KeyCode.Delete;
			obj.modifiers |= EventModifiers.FunctionKey;
			break;
		case "tab":
			obj.keyCode = KeyCode.Tab;
			break;
		case "f1":
			obj.keyCode = KeyCode.F1;
			obj.modifiers |= EventModifiers.FunctionKey;
			break;
		case "f2":
			obj.keyCode = KeyCode.F2;
			obj.modifiers |= EventModifiers.FunctionKey;
			break;
		case "f3":
			obj.keyCode = KeyCode.F3;
			obj.modifiers |= EventModifiers.FunctionKey;
			break;
		case "f4":
			obj.keyCode = KeyCode.F4;
			obj.modifiers |= EventModifiers.FunctionKey;
			break;
		case "f5":
			obj.keyCode = KeyCode.F5;
			obj.modifiers |= EventModifiers.FunctionKey;
			break;
		case "f6":
			obj.keyCode = KeyCode.F6;
			obj.modifiers |= EventModifiers.FunctionKey;
			break;
		case "f7":
			obj.keyCode = KeyCode.F7;
			obj.modifiers |= EventModifiers.FunctionKey;
			break;
		case "f8":
			obj.keyCode = KeyCode.F8;
			obj.modifiers |= EventModifiers.FunctionKey;
			break;
		case "f9":
			obj.keyCode = KeyCode.F9;
			obj.modifiers |= EventModifiers.FunctionKey;
			break;
		case "f10":
			obj.keyCode = KeyCode.F10;
			obj.modifiers |= EventModifiers.FunctionKey;
			break;
		case "f11":
			obj.keyCode = KeyCode.F11;
			obj.modifiers |= EventModifiers.FunctionKey;
			break;
		case "f12":
			obj.keyCode = KeyCode.F12;
			obj.modifiers |= EventModifiers.FunctionKey;
			break;
		case "f13":
			obj.keyCode = KeyCode.F13;
			obj.modifiers |= EventModifiers.FunctionKey;
			break;
		case "f14":
			obj.keyCode = KeyCode.F14;
			obj.modifiers |= EventModifiers.FunctionKey;
			break;
		case "f15":
			obj.keyCode = KeyCode.F15;
			obj.modifiers |= EventModifiers.FunctionKey;
			break;
		case "[esc]":
			obj.keyCode = KeyCode.Escape;
			break;
		case "return":
			obj.character = '\n';
			obj.keyCode = KeyCode.Return;
			obj.modifiers &= ~EventModifiers.FunctionKey;
			break;
		case "space":
			obj.keyCode = KeyCode.Space;
			obj.character = ' ';
			obj.modifiers &= ~EventModifiers.FunctionKey;
			break;
		default:
			if (text.Length != 1)
			{
				try
				{
					obj.keyCode = (KeyCode)(int)Enum.Parse(typeof(KeyCode), text, ignoreCase: true);
				}
				catch (ArgumentException)
				{
					Debug.LogError(UnityString.Format("Unable to find key name that matches '{0}'", text));
				}
			}
			else
			{
				obj.character = text.ToLower()[0];
				obj.keyCode = (KeyCode)obj.character;
				if (obj.modifiers != EventModifiers.None)
				{
					obj.character = '\0';
				}
			}
			break;
		}
		return obj;
	}

	public override int GetHashCode()
	{
		int num = 1;
		if (isKey)
		{
			num = (ushort)keyCode;
		}
		if (isMouse)
		{
			num = mousePosition.GetHashCode();
		}
		return (num * 37) | (int)modifiers;
	}

	public override bool Equals(object obj)
	{
		if (obj == null)
		{
			return false;
		}
		if (object.ReferenceEquals(this, obj))
		{
			return true;
		}
		if (obj.GetType() != GetType())
		{
			return false;
		}
		Event obj2 = (Event)obj;
		if (type != obj2.type || (modifiers & ~EventModifiers.CapsLock) != (obj2.modifiers & ~EventModifiers.CapsLock))
		{
			return false;
		}
		if (isKey)
		{
			return keyCode == obj2.keyCode;
		}
		if (isMouse)
		{
			return mousePosition == obj2.mousePosition;
		}
		return false;
	}

	public override string ToString()
	{
		if (isKey)
		{
			if (character == '\0')
			{
				return UnityString.Format("Event:{0}   Character:\\0   Modifiers:{1}   KeyCode:{2}", type, modifiers, keyCode);
			}
			return string.Concat("Event:", type, "   Character:", (int)character, "   Modifiers:", modifiers, "   KeyCode:", keyCode);
		}
		if (isMouse)
		{
			return UnityString.Format("Event: {0}   Position: {1} Modifiers: {2}", type, mousePosition, modifiers);
		}
		if (type == EventType.ExecuteCommand || type == EventType.ValidateCommand)
		{
			return UnityString.Format("Event: {0}  \"{1}\"", type, commandName);
		}
		return string.Empty + type;
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	private extern void Init();

	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	private extern void Cleanup();

	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	private extern void InitCopy(Event other);

	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	private extern void InitPtr(IntPtr ptr);

	/// <summary>
	///   <para>Get a filtered event type for a given control ID.</para>
	/// </summary>
	/// <param name="controlID">The ID of the control you are querying from.</param>
	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	public extern EventType GetTypeForControl(int controlID);

	private void Internal_SetMousePosition(Vector2 value)
	{
		INTERNAL_CALL_Internal_SetMousePosition(this, ref value);
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	private static extern void INTERNAL_CALL_Internal_SetMousePosition(Event self, ref Vector2 value);

	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	private extern void Internal_GetMousePosition(out Vector2 value);

	private void Internal_SetMouseDelta(Vector2 value)
	{
		INTERNAL_CALL_Internal_SetMouseDelta(this, ref value);
	}

	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	private static extern void INTERNAL_CALL_Internal_SetMouseDelta(Event self, ref Vector2 value);

	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	private extern void Internal_GetMouseDelta(out Vector2 value);

	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	private static extern void Internal_SetNativeEvent(IntPtr ptr);

	/// <summary>
	///   <para>Use this event.</para>
	/// </summary>
	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	public extern void Use();

	/// <summary>
	///   <para>Get the next queued [Event] from the event system.</para>
	/// </summary>
	/// <param name="outEvent">Next Event.</param>
	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	public static extern bool PopEvent(Event outEvent);

	/// <summary>
	///   <para>Returns the current number of events that are stored in the event queue.</para>
	/// </summary>
	/// <returns>
	///   <para>Current number of events currently in the event queue.</para>
	/// </returns>
	[MethodImpl(MethodImplOptions.InternalCall)]
	[WrapperlessIcall]
	public static extern int GetEventCount();
}
