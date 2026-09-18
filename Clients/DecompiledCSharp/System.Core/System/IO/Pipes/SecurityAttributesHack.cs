namespace System.IO.Pipes;

internal struct SecurityAttributesHack(bool inheritable)
{
	public readonly int Length = 0;

	public readonly IntPtr SecurityDescriptor = IntPtr.Zero;

	public readonly bool Inheritable = inheritable;
}
