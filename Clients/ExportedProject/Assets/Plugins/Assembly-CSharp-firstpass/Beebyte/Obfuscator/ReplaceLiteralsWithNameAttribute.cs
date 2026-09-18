using System;

namespace Beebyte.Obfuscator
{
[AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Enum | AttributeTargets.Method | AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Event | AttributeTargets.Interface)]
public class ReplaceLiteralsWithNameAttribute : Attribute
{
}
}
