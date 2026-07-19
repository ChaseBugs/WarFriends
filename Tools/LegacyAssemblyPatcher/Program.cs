using Mono.Cecil;
using Mono.Cecil.Cil;
using AssetRipper.HashAlgorithms;
using System.Buffers.Binary;
using System.Text;

if (args.Length < 1)
{
    Console.Error.WriteLine("Usage: LegacyAssemblyPatcher <assembly> [--patch] [--rename-assembly <name>] [--retarget <old=new>] [--search-directory <path>] [--dump-script-types <csv>]");
    return 2;
}

var assemblyPath = Path.GetFullPath(args[0]);
var patch = args.Skip(1).Any(value => value == "--patch");
var guardAndroidRotation = args.Skip(1).Any(value => value == "--guard-android-rotation");
var guardGooglePlayDownloader = args.Skip(1).Any(value => value == "--guard-google-play-downloader");
var fixSingletonLifecycle = args.Skip(1).Any(value => value == "--fix-singleton-lifecycle");
var guardHybridRuntime = args.Skip(1).Any(value => value == "--guard-hybrid-runtime");
var guardShutdownCallbacks = args.Skip(1).Any(value => value == "--guard-shutdown-callbacks");
string? renamedAssembly = null;
var retargets = new Dictionary<string, string>(StringComparer.Ordinal);
var searchDirectories = new List<string>();
string? scriptTypeMapPath = null;
string? fieldMapPath = null;
string? serializationAliasSourcePath = null;
string? sequenceSerializationAliasSourcePath = null;
string? dumpMethodName = null;
var dumpAssemblyReferences = args.Skip(1).Any(value => value == "--dump-assembly-references");
for (var index = 1; index < args.Length; index++)
{
    if (args[index] == "--rename-assembly" && index + 1 < args.Length)
    {
        renamedAssembly = args[++index];
    }
    else if (args[index] == "--retarget" && index + 1 < args.Length)
    {
        var pair = args[++index].Split('=', 2);
        if (pair.Length != 2 || string.IsNullOrWhiteSpace(pair[0]) || string.IsNullOrWhiteSpace(pair[1]))
        {
            Console.Error.WriteLine("Invalid --retarget value. Expected <old=new>.");
            return 2;
        }

        retargets[pair[0]] = pair[1];
    }
    else if (args[index] == "--search-directory" && index + 1 < args.Length)
    {
        searchDirectories.Add(Path.GetFullPath(args[++index]));
    }
    else if (args[index] == "--dump-script-types" && index + 1 < args.Length)
    {
        scriptTypeMapPath = Path.GetFullPath(args[++index]);
    }
    else if (args[index] == "--dump-fields" && index + 1 < args.Length)
    {
        fieldMapPath = Path.GetFullPath(args[++index]);
    }
    else if (args[index] == "--add-serialization-aliases-from" && index + 1 < args.Length)
    {
        serializationAliasSourcePath = Path.GetFullPath(args[++index]);
    }
    else if (args[index] == "--add-sequence-serialization-aliases-from" && index + 1 < args.Length)
    {
        sequenceSerializationAliasSourcePath = Path.GetFullPath(args[++index]);
    }
    else if (args[index] == "--dump-method" && index + 1 < args.Length)
    {
        dumpMethodName = args[++index];
    }
}

var resolver = new DefaultAssemblyResolver();
resolver.AddSearchDirectory(Path.GetDirectoryName(assemblyPath)!);
foreach (var searchDirectory in searchDirectories)
{
    resolver.AddSearchDirectory(searchDirectory);
}
var assembly = AssemblyDefinition.ReadAssembly(assemblyPath, new ReaderParameters
{
    ReadWrite = false,
    AssemblyResolver = resolver
});
var module = assembly.MainModule;

var particleTypes = module.GetTypeReferences()
    .Where(type => type.FullName == "UnityEngine.ParticleEmitter")
    .ToList();

var particleMembers = module.GetMemberReferences()
    .Where(member => member.DeclaringType.FullName == "UnityEngine.ParticleEmitter")
    .Select(member => $"{member.GetType().Name}: {member.FullName}")
    .Distinct()
    .OrderBy(value => value)
    .ToList();

Console.WriteLine($"Assembly: {assembly.Name.Name}");
Console.WriteLine($"ParticleEmitter type references: {particleTypes.Count}");
foreach (var member in particleMembers)
{
    Console.WriteLine(member);
}

if (!string.IsNullOrWhiteSpace(scriptTypeMapPath))
{
    var report = new StringBuilder();
    report.AppendLine("file_id,namespace,name,full_name,base_type");
    foreach (var type in EnumerateTypes(module.Types).OrderBy(value => value.FullName, StringComparer.Ordinal))
    {
        report.AppendLine(string.Join(",", new[]
        {
            CalculateScriptFileId(type.Namespace ?? string.Empty, type.Name).ToString(),
            Csv(type.Namespace ?? string.Empty),
            Csv(type.Name),
            Csv(type.FullName),
            Csv(type.BaseType == null ? string.Empty : type.BaseType.FullName)
        }));
    }

    File.WriteAllText(scriptTypeMapPath, report.ToString());
    Console.WriteLine($"Script type map: {scriptTypeMapPath}");
}

if (!string.IsNullOrWhiteSpace(fieldMapPath))
{
    var report = new StringBuilder();
    report.AppendLine("type,field,field_type,is_static,is_not_serialized");
    foreach (var type in EnumerateTypes(module.Types).OrderBy(value => value.FullName, StringComparer.Ordinal))
    {
        foreach (var field in type.Fields)
        {
            report.AppendLine(string.Join(",", new[]
            {
                Csv(type.FullName),
                Csv(field.Name),
                Csv(field.FieldType.FullName),
                field.IsStatic ? "true" : "false",
                field.IsNotSerialized ? "true" : "false"
            }));
        }
    }

    File.WriteAllText(fieldMapPath, report.ToString());
    Console.WriteLine($"Field map: {fieldMapPath}");
}

var changes = 0;

if (dumpAssemblyReferences)
{
    Console.WriteLine("Identity: " + assembly.Name.FullName);
    foreach (AssemblyNameReference reference in module.AssemblyReferences.OrderBy(reference => reference.Name, StringComparer.Ordinal))
    {
        Console.WriteLine("Reference: " + reference.FullName);
    }
}

if (!string.IsNullOrWhiteSpace(dumpMethodName))
{
    string[] methodParts = dumpMethodName.Split(new[] { "::" }, 2, StringSplitOptions.None);
    TypeDefinition? dumpType = methodParts.Length == 2
        ? EnumerateTypes(module.Types).FirstOrDefault(type => type.FullName == methodParts[0])
        : null;
    IEnumerable<MethodDefinition> dumpMethods = dumpType == null
        ? Enumerable.Empty<MethodDefinition>()
        : dumpType.Methods.Where(method => method.Name == methodParts[1]);
    foreach (MethodDefinition method in dumpMethods)
    {
        Console.WriteLine("METHOD " + method.FullName);
        foreach (Instruction instruction in method.Body.Instructions)
        {
            Console.WriteLine(instruction);
        }
    }
}

if (patch && particleTypes.Count > 0)
{
    var compatibilityReference = module.AssemblyReferences
        .FirstOrDefault(reference => reference.Name == "WarFriends.LegacyCompat");
    if (compatibilityReference == null)
    {
        compatibilityReference = new AssemblyNameReference("WarFriends.LegacyCompat", new Version(1, 0, 0, 0));
        module.AssemblyReferences.Add(compatibilityReference);
    }

    foreach (var type in particleTypes)
    {
        type.Namespace = "WarFriends.Legacy";
        type.Name = "ParticleEmitterCompat";
        type.Scope = compatibilityReference;
    }

    changes += particleTypes.Count;
    Console.WriteLine($"Patched {particleTypes.Count} ParticleEmitter reference(s).");
}

if (guardAndroidRotation)
{
    TypeDefinition? rotationType = module.Types.FirstOrDefault(type => type.FullName == "AndroidRotationLockUtil");
    MethodDefinition? allowAutorotation = rotationType?.Methods.FirstOrDefault(method =>
        method.Name == "AllowAutorotation" && method.IsStatic && method.Parameters.Count == 0 && method.ReturnType.FullName == "System.Boolean");
    MethodReference? platformGetter = module.GetMemberReferences().OfType<MethodReference>().FirstOrDefault(method =>
        method.FullName == "UnityEngine.RuntimePlatform UnityEngine.Application::get_platform()");

    if (platformGetter == null)
    {
        AssemblyNameReference? unityEngineReference = module.AssemblyReferences.FirstOrDefault(reference => reference.Name == "UnityEngine");
        if (unityEngineReference != null)
        {
            TypeReference runtimePlatform = new TypeReference("UnityEngine", "RuntimePlatform", module, unityEngineReference, true);
            TypeReference application = new TypeReference("UnityEngine", "Application", module, unityEngineReference);
            platformGetter = new MethodReference("get_platform", runtimePlatform, application) { HasThis = false };
        }
    }

    if (allowAutorotation == null || !allowAutorotation.HasBody || platformGetter == null)
    {
        Console.Error.WriteLine("Could not locate AndroidRotationLockUtil.AllowAutorotation or Application.platform.");
        assembly.Dispose();
        return 3;
    }

    Instruction firstInstruction = allowAutorotation.Body.Instructions[0];
    ILProcessor il = allowAutorotation.Body.GetILProcessor();
    il.InsertBefore(firstInstruction, il.Create(OpCodes.Call, platformGetter));
    il.InsertBefore(firstInstruction, il.Create(OpCodes.Ldc_I4_S, (sbyte)11));
    il.InsertBefore(firstInstruction, il.Create(OpCodes.Beq, firstInstruction));
    il.InsertBefore(firstInstruction, il.Create(OpCodes.Ldc_I4_0));
    il.InsertBefore(firstInstruction, il.Create(OpCodes.Ret));
    changes++;
    Console.WriteLine("Guarded AndroidRotationLockUtil.AllowAutorotation outside RuntimePlatform.Android.");
}

if (guardGooglePlayDownloader)
{
    TypeDefinition? downloaderType = module.Types.FirstOrDefault(type => type.FullName == "GooglePlayDownloader");
    MethodReference? platformGetter = CreatePlatformGetter(module);
    string[] methodNames =
    {
        "RunningOnAndroid", "GetExpansionFilePath", "GetMainOBBPath", "GetPatchOBBPath", "FetchOBB", "populateOBBData"
    };

    if (downloaderType == null || platformGetter == null)
    {
        Console.Error.WriteLine("Could not locate GooglePlayDownloader or Application.platform.");
        assembly.Dispose();
        return 3;
    }

    foreach (string methodName in methodNames)
    {
        MethodDefinition? method = downloaderType.Methods.FirstOrDefault(candidate => candidate.Name == methodName && candidate.IsStatic);
        if (method == null || !method.HasBody)
        {
            Console.Error.WriteLine("Could not locate GooglePlayDownloader." + methodName + ".");
            assembly.Dispose();
            return 3;
        }

        Instruction firstInstruction = method.Body.Instructions[0];
        ILProcessor il = method.Body.GetILProcessor();
        il.InsertBefore(firstInstruction, il.Create(OpCodes.Call, platformGetter));
        il.InsertBefore(firstInstruction, il.Create(OpCodes.Ldc_I4_S, (sbyte)11));
        il.InsertBefore(firstInstruction, il.Create(OpCodes.Beq, firstInstruction));
        if (method.ReturnType.FullName == "System.Boolean")
        {
            il.InsertBefore(firstInstruction, il.Create(OpCodes.Ldc_I4_0));
        }
        else if (method.ReturnType.FullName == "System.String")
        {
            il.InsertBefore(firstInstruction, il.Create(OpCodes.Ldnull));
        }
        else if (method.ReturnType.FullName != "System.Void")
        {
            Console.Error.WriteLine("Unsupported guarded return type: " + method.ReturnType.FullName);
            assembly.Dispose();
            return 3;
        }
        il.InsertBefore(firstInstruction, il.Create(OpCodes.Ret));
        changes++;
    }

    Console.WriteLine("Guarded GooglePlayDownloader Android bridge methods outside RuntimePlatform.Android.");
}

if (fixSingletonLifecycle)
{
    TypeDefinition? singletonType = module.Types.FirstOrDefault(type => type.FullName == "Singleton");
    TypeDefinition? genericSingletonType = module.Types.FirstOrDefault(type => type.Name == "Singleton`1");
    FieldDefinition? applicationIsQuittingField = singletonType?.Fields.FirstOrDefault(field => field.Name == "applicationIsQuitting");
    FieldDefinition? instanceField = genericSingletonType?.Fields.FirstOrDefault(field => field.Name == "_instance");
    MethodDefinition? onDestroy = genericSingletonType?.Methods.FirstOrDefault(method => method.Name == "OnDestroy" && method.Parameters.Count == 0);
    if (singletonType == null || genericSingletonType == null || applicationIsQuittingField == null ||
        instanceField == null || onDestroy == null)
    {
        Console.Error.WriteLine("Could not locate legacy Singleton lifecycle members.");
        assembly.Dispose();
        return 3;
    }

    onDestroy.Body = new MethodBody(onDestroy);
    ILProcessor destroyIl = onDestroy.Body.GetILProcessor();
    destroyIl.Append(destroyIl.Create(OpCodes.Ldnull));
    destroyIl.Append(destroyIl.Create(OpCodes.Stsfld, instanceField));
    destroyIl.Append(destroyIl.Create(OpCodes.Ret));

    MethodDefinition? onApplicationQuit = singletonType.Methods.FirstOrDefault(method =>
        method.Name == "OnApplicationQuit" && method.Parameters.Count == 0);
    if (onApplicationQuit == null)
    {
        onApplicationQuit = new MethodDefinition(
            "OnApplicationQuit",
            MethodAttributes.Public | MethodAttributes.HideBySig,
            module.TypeSystem.Void);
        singletonType.Methods.Add(onApplicationQuit);
    }

    onApplicationQuit.Body = new MethodBody(onApplicationQuit);
    ILProcessor quitIl = onApplicationQuit.Body.GetILProcessor();
    quitIl.Append(quitIl.Create(OpCodes.Ldc_I4_1));
    quitIl.Append(quitIl.Create(OpCodes.Stsfld, applicationIsQuittingField));
    quitIl.Append(quitIl.Create(OpCodes.Ret));
    changes += 2;
    Console.WriteLine("Fixed Singleton lifecycle so scene destruction is not treated as application quit.");
}

if (guardHybridRuntime)
{
    TypeDefinition? inventoryType = module.Types.FirstOrDefault(type => type.FullName == "WeaponInventory");
    TypeDefinition? playerWeaponType = module.Types.FirstOrDefault(type => type.FullName == "PlayerWeapon");
    TypeDefinition? fuseServiceType = module.Types.FirstOrDefault(type => type.FullName == "LPDEOBOCICH");
    MethodDefinition? inventoryAwake = inventoryType?.Methods.FirstOrDefault(method => method.Name == "Awake" && method.Parameters.Count == 0);
    MethodDefinition? setUpPlayer = inventoryType?.Methods.FirstOrDefault(method => method.Name == "SetUpPlayer" && method.Parameters.Count == 1);
    MethodDefinition? weaponGetter = playerWeaponType?.Methods.FirstOrDefault(method => method.Name == "get_weapon" && method.Parameters.Count == 0);
    MethodDefinition? fuseConstructor = fuseServiceType?.Methods.FirstOrDefault(method => method.IsConstructor && method.Parameters.Count == 1 && method.Parameters[0].ParameterType.FullName == "FuseSDK");
    if (inventoryAwake == null || setUpPlayer == null || weaponGetter == null || fuseConstructor == null)
    {
        Console.Error.WriteLine("Could not locate hybrid runtime guard methods.");
        assembly.Dispose();
        return 3;
    }

    Instruction? awakeLoopContinue = inventoryAwake.Body.Instructions.FirstOrDefault(instruction => instruction.Offset == 0x008d);
    Instruction? awakeAfterSetupLocal = inventoryAwake.Body.Instructions.FirstOrDefault(instruction => instruction.Offset == 0x0074);
    Instruction? awakeBeforeSetupCall = inventoryAwake.Body.Instructions.FirstOrDefault(instruction => instruction.Offset == 0x0086);
    Instruction? setupLoopContinue = setUpPlayer.Body.Instructions.FirstOrDefault(instruction => instruction.Offset == 0x0038);
    Instruction? setupBeforeWeaponLoad = setUpPlayer.Body.Instructions.FirstOrDefault(instruction => instruction.Offset == 0x0025);
    if (awakeLoopContinue == null || awakeAfterSetupLocal == null || awakeBeforeSetupCall == null ||
        setupLoopContinue == null || setupBeforeWeaponLoad == null)
    {
        Console.Error.WriteLine("Unexpected WeaponInventory IL layout.");
        assembly.Dispose();
        return 3;
    }

    ILProcessor awakeIl = inventoryAwake.Body.GetILProcessor();
    awakeIl.InsertBefore(awakeAfterSetupLocal, awakeIl.Create(OpCodes.Ldloc_1));
    awakeIl.InsertBefore(awakeAfterSetupLocal, awakeIl.Create(OpCodes.Brfalse, awakeLoopContinue));
    awakeIl.InsertBefore(awakeBeforeSetupCall, awakeIl.Create(OpCodes.Ldloc_3));
    awakeIl.InsertBefore(awakeBeforeSetupCall, awakeIl.Create(OpCodes.Brfalse, awakeLoopContinue));
    awakeIl.InsertBefore(awakeBeforeSetupCall, awakeIl.Create(OpCodes.Ldloc_3));
    awakeIl.InsertBefore(awakeBeforeSetupCall, awakeIl.Create(OpCodes.Callvirt, weaponGetter));
    awakeIl.InsertBefore(awakeBeforeSetupCall, awakeIl.Create(OpCodes.Brfalse, awakeLoopContinue));

    ILProcessor setupIl = setUpPlayer.Body.GetILProcessor();
    setupIl.InsertBefore(setupBeforeWeaponLoad, setupIl.Create(OpCodes.Ldloc_0));
    setupIl.InsertBefore(setupBeforeWeaponLoad, setupIl.Create(OpCodes.Brfalse, setupLoopContinue));
    setupIl.InsertBefore(setupBeforeWeaponLoad, setupIl.Create(OpCodes.Ldloc_0));
    setupIl.InsertBefore(setupBeforeWeaponLoad, setupIl.Create(OpCodes.Callvirt, weaponGetter));
    setupIl.InsertBefore(setupBeforeWeaponLoad, setupIl.Create(OpCodes.Brfalse, setupLoopContinue));

    ILProcessor fuseIl = fuseConstructor.Body.GetILProcessor();
    List<Instruction> fuseStores = fuseConstructor.Body.Instructions.Where(instruction =>
        instruction.OpCode == OpCodes.Stfld && instruction.Operand is FieldReference field &&
        field.DeclaringType.FullName == "FuseSDK" && field.Name == "iOSAppID").ToList();
    foreach (Instruction store in fuseStores)
    {
        Instruction? loadArgument = store.Previous?.Previous;
        Instruction? target = store.Next;
        if (loadArgument == null || target == null || loadArgument.OpCode != OpCodes.Ldarg_1)
        {
            Console.Error.WriteLine("Unexpected FuseSDK assignment IL layout.");
            assembly.Dispose();
            return 3;
        }

        fuseIl.InsertBefore(loadArgument, fuseIl.Create(OpCodes.Ldarg_1));
        fuseIl.InsertBefore(loadArgument, fuseIl.Create(OpCodes.Brfalse, target));
    }

    changes += 3;
    Console.WriteLine("Guarded legacy weapon setup and optional FuseSDK references for hybrid resources.");
}

if (guardShutdownCallbacks)
{
    FieldReference? quittingField = module.GetMemberReferences().OfType<FieldReference>().FirstOrDefault(field =>
        field.DeclaringType.FullName == "Singleton" && field.Name == "applicationIsQuitting");
    TypeDefinition? onlineControllerType = module.Types.FirstOrDefault(type => type.FullName == "GameControllerOnline");
    TypeDefinition? notificationType = module.Types.FirstOrDefault(type => type.FullName == "PushNotificationManager");
    MethodDefinition? disconnected = onlineControllerType?.Methods.FirstOrDefault(method =>
        method.Name == "OnDisconnectedFromPhoton" && method.Parameters.Count == 0);
    MethodDefinition? outputNotifications = notificationType?.Methods.FirstOrDefault(method =>
        method.Name == "OutputLocalNotifications" && method.Parameters.Count == 0);
    MethodDefinition? rescheduleNotifications = notificationType?.Methods.FirstOrDefault(method =>
        method.Name == "RescheduleLocalNotifications" && method.Parameters.Count == 0);
    if (quittingField == null || disconnected == null || outputNotifications == null || rescheduleNotifications == null)
    {
        Console.Error.WriteLine("Could not locate shutdown callback guard members.");
        assembly.Dispose();
        return 3;
    }

    foreach (MethodDefinition method in new[] { disconnected, outputNotifications, rescheduleNotifications })
    {
        Instruction first = method.Body.Instructions[0];
        if (first.OpCode == OpCodes.Ldsfld && first.Operand is FieldReference existingGuard &&
            existingGuard.DeclaringType.FullName == "Singleton" && existingGuard.Name == "applicationIsQuitting")
        {
            continue;
        }

        ILProcessor il = method.Body.GetILProcessor();
        il.InsertBefore(first, il.Create(OpCodes.Ldsfld, quittingField));
        il.InsertBefore(first, il.Create(OpCodes.Brfalse, first));
        il.InsertBefore(first, il.Create(OpCodes.Ret));
        changes++;
    }

    Console.WriteLine("Guarded Photon and notification shutdown callbacks after singleton teardown begins.");
}

if (!string.IsNullOrWhiteSpace(serializationAliasSourcePath))
{
    using AssemblyDefinition sourceAssembly = AssemblyDefinition.ReadAssembly(serializationAliasSourcePath);
    Dictionary<string, TypeDefinition> sourceTypes = EnumerateTypes(sourceAssembly.MainModule.Types)
        .ToDictionary(type => type.FullName, StringComparer.Ordinal);
    Dictionary<string, TypeDefinition> targetTypes = EnumerateTypes(module.Types)
        .ToDictionary(type => type.FullName, StringComparer.Ordinal);
    MethodReference? formerlySerializedAsConstructor = CreateFormerlySerializedAsConstructor(module);
    if (formerlySerializedAsConstructor == null)
    {
        Console.Error.WriteLine("Could not create FormerlySerializedAsAttribute constructor reference.");
        assembly.Dispose();
        return 3;
    }

    int aliasedTypes = 0;
    int addedAliases = 0;
    foreach ((string typeName, TypeDefinition sourceType) in sourceTypes)
    {
        if (!targetTypes.TryGetValue(typeName, out TypeDefinition? targetType))
        {
            continue;
        }

        List<FieldDefinition> sourceFields = sourceType.Fields.Where(IsUnitySerializableField).ToList();
        List<FieldDefinition> targetFields = targetType.Fields.Where(IsUnitySerializableField).ToList();
        if (sourceFields.Count != targetFields.Count ||
            !sourceFields.Select(field => field.FieldType.FullName).SequenceEqual(targetFields.Select(field => field.FieldType.FullName)))
        {
            continue;
        }

        bool typeChanged = false;
        for (int fieldIndex = 0; fieldIndex < sourceFields.Count; fieldIndex++)
        {
            string sourceName = sourceFields[fieldIndex].Name;
            FieldDefinition targetField = targetFields[fieldIndex];
            if (sourceName == targetField.Name || HasSerializationAlias(targetField, sourceName))
            {
                continue;
            }

            CustomAttribute alias = new CustomAttribute(formerlySerializedAsConstructor);
            alias.ConstructorArguments.Add(new CustomAttributeArgument(module.TypeSystem.String, sourceName));
            targetField.CustomAttributes.Add(alias);
            typeChanged = true;
            addedAliases++;
            changes++;
        }

        if (typeChanged)
        {
            aliasedTypes++;
        }
    }

    Console.WriteLine($"Added {addedAliases} serialization aliases across {aliasedTypes} exact-layout types.");
}

if (!string.IsNullOrWhiteSpace(sequenceSerializationAliasSourcePath))
{
    using AssemblyDefinition sourceAssembly = AssemblyDefinition.ReadAssembly(sequenceSerializationAliasSourcePath);
    Dictionary<string, TypeDefinition> sourceTypes = EnumerateTypes(sourceAssembly.MainModule.Types)
        .ToDictionary(type => type.FullName, StringComparer.Ordinal);
    Dictionary<string, TypeDefinition> targetTypes = EnumerateTypes(module.Types)
        .ToDictionary(type => type.FullName, StringComparer.Ordinal);
    MethodReference? formerlySerializedAsConstructor = CreateFormerlySerializedAsConstructor(module);
    if (formerlySerializedAsConstructor == null)
    {
        Console.Error.WriteLine("Could not create FormerlySerializedAsAttribute constructor reference.");
        assembly.Dispose();
        return 3;
    }

    int aliasedTypes = 0;
    int addedAliases = 0;
    foreach ((string typeName, TypeDefinition sourceType) in sourceTypes)
    {
        if (!targetTypes.TryGetValue(typeName, out TypeDefinition? targetType))
        {
            continue;
        }

        List<FieldDefinition> sourceFields = sourceType.Fields.Where(IsUnitySerializableField).ToList();
        List<FieldDefinition> targetFields = targetType.Fields.Where(IsUnitySerializableField).ToList();
        if (sourceFields.Count == 0 || targetFields.Count == 0)
        {
            continue;
        }

        List<(FieldDefinition Source, FieldDefinition Target)> matches = AlignSerializableFields(sourceFields, targetFields);
        bool typeChanged = false;
        foreach ((FieldDefinition sourceField, FieldDefinition targetField) in matches)
        {
            string sourceName = sourceField.Name;
            if (sourceName == targetField.Name || HasSerializationAlias(targetField, sourceName))
            {
                continue;
            }

            CustomAttribute alias = new CustomAttribute(formerlySerializedAsConstructor);
            alias.ConstructorArguments.Add(new CustomAttributeArgument(module.TypeSystem.String, sourceName));
            targetField.CustomAttributes.Add(alias);
            typeChanged = true;
            addedAliases++;
            changes++;
        }

        if (typeChanged)
        {
            aliasedTypes++;
        }
    }

    Console.WriteLine($"Added {addedAliases} serialization aliases across {aliasedTypes} sequence-aligned types.");
}

foreach (var reference in module.AssemblyReferences)
{
    if (retargets.TryGetValue(reference.Name, out var replacement))
    {
        Console.WriteLine($"Retargeted assembly reference {reference.Name} -> {replacement}.");
        reference.Name = replacement;
        changes++;
    }
}

if (retargets.Count > 0)
{
    foreach (var provider in EnumerateAttributeProviders(module))
    {
        foreach (var attribute in provider.CustomAttributes)
        {
            for (var argumentIndex = 0; argumentIndex < attribute.ConstructorArguments.Count; argumentIndex++)
            {
                var argument = attribute.ConstructorArguments[argumentIndex];
                attribute.ConstructorArguments[argumentIndex] = RetargetArgument(argument, retargets, ref changes);
            }

            for (var fieldIndex = 0; fieldIndex < attribute.Fields.Count; fieldIndex++)
            {
                var field = attribute.Fields[fieldIndex];
                attribute.Fields[fieldIndex] = new CustomAttributeNamedArgument(
                    field.Name,
                    RetargetArgument(field.Argument, retargets, ref changes));
            }

            for (var propertyIndex = 0; propertyIndex < attribute.Properties.Count; propertyIndex++)
            {
                var property = attribute.Properties[propertyIndex];
                attribute.Properties[propertyIndex] = new CustomAttributeNamedArgument(
                    property.Name,
                    RetargetArgument(property.Argument, retargets, ref changes));
            }
        }
    }
}

if (!string.IsNullOrWhiteSpace(renamedAssembly) && assembly.Name.Name != renamedAssembly)
{
    Console.WriteLine($"Renamed assembly identity {assembly.Name.Name} -> {renamedAssembly}.");
    assembly.Name.Name = renamedAssembly;
    changes++;
}

if (changes == 0)
{
    assembly.Dispose();
    return 0;
}

var temporaryPath = assemblyPath + ".patched";
assembly.Write(temporaryPath);
assembly.Dispose();
File.Move(temporaryPath, assemblyPath, true);
Console.WriteLine($"Wrote {changes} assembly change(s).");
return 0;

static IEnumerable<ICustomAttributeProvider> EnumerateAttributeProviders(ModuleDefinition module)
{
    yield return module;
    yield return module.Assembly;

    foreach (var type in module.Types)
    {
        foreach (var provider in EnumerateTypeAttributeProviders(type))
        {
            yield return provider;
        }
    }
}

static IEnumerable<ICustomAttributeProvider> EnumerateTypeAttributeProviders(TypeDefinition type)
{
    yield return type;

    foreach (var parameter in type.GenericParameters)
    {
        yield return parameter;
    }

    foreach (var field in type.Fields)
    {
        yield return field;
    }

    foreach (var property in type.Properties)
    {
        yield return property;
    }

    foreach (var @event in type.Events)
    {
        yield return @event;
    }

    foreach (var method in type.Methods)
    {
        yield return method;
        yield return method.MethodReturnType;

        foreach (var parameter in method.Parameters)
        {
            yield return parameter;
        }

        foreach (var genericParameter in method.GenericParameters)
        {
            yield return genericParameter;
        }
    }

    foreach (var nestedType in type.NestedTypes)
    {
        foreach (var provider in EnumerateTypeAttributeProviders(nestedType))
        {
            yield return provider;
        }
    }
}

static CustomAttributeArgument RetargetArgument(
    CustomAttributeArgument argument,
    IReadOnlyDictionary<string, string> retargets,
    ref int changes)
{
    RetargetTypeReference(argument.Type, retargets, ref changes);

    if (argument.Value is TypeReference typeReference)
    {
        RetargetTypeReference(typeReference, retargets, ref changes);
        return new CustomAttributeArgument(argument.Type, typeReference);
    }

    if (argument.Value is CustomAttributeArgument[] arguments)
    {
        for (var index = 0; index < arguments.Length; index++)
        {
            arguments[index] = RetargetArgument(arguments[index], retargets, ref changes);
        }

        return new CustomAttributeArgument(argument.Type, arguments);
    }

    if (argument.Value is CustomAttributeArgument nestedArgument)
    {
        return new CustomAttributeArgument(
            argument.Type,
            RetargetArgument(nestedArgument, retargets, ref changes));
    }

    return argument;
}

static void RetargetTypeReference(
    TypeReference typeReference,
    IReadOnlyDictionary<string, string> retargets,
    ref int changes)
{
    var elementType = typeReference;
    while (elementType is TypeSpecification specification)
    {
        elementType = specification.ElementType;
    }

    if (elementType.Scope is AssemblyNameReference reference &&
        retargets.TryGetValue(reference.Name, out var replacement))
    {
        Console.WriteLine($"Retargeted custom attribute type {elementType.FullName}: {reference.Name} -> {replacement}.");
        reference.Name = replacement;
        changes++;
    }
}

static IEnumerable<TypeDefinition> EnumerateTypes(IEnumerable<TypeDefinition> types)
{
    foreach (var type in types)
    {
        yield return type;
        foreach (var nestedType in EnumerateTypes(type.NestedTypes))
        {
            yield return nestedType;
        }
    }
}

static int CalculateScriptFileId(string @namespace, string name)
{
    byte[] namespaceBytes = Encoding.UTF8.GetBytes(@namespace);
    byte[] nameBytes = Encoding.UTF8.GetBytes(name);
    byte[] source = new byte[4 + namespaceBytes.Length + nameBytes.Length];
    source[0] = (byte)'s';
    Buffer.BlockCopy(namespaceBytes, 0, source, 4, namespaceBytes.Length);
    Buffer.BlockCopy(nameBytes, 0, source, 4 + namespaceBytes.Length, nameBytes.Length);

    Span<byte> destination = stackalloc byte[16];
    MD4.HashData(source, destination);
    return BinaryPrimitives.ReadInt32LittleEndian(destination);
}

static string Csv(string value)
{
    return "\"" + value.Replace("\"", "\"\"") + "\"";
}

static MethodReference? CreatePlatformGetter(ModuleDefinition module)
{
    MethodReference? existing = module.GetMemberReferences().OfType<MethodReference>().FirstOrDefault(method =>
        method.FullName == "UnityEngine.RuntimePlatform UnityEngine.Application::get_platform()");
    if (existing != null)
    {
        return existing;
    }

    AssemblyNameReference? unityEngineReference = module.AssemblyReferences.FirstOrDefault(reference => reference.Name == "UnityEngine");
    if (unityEngineReference == null)
    {
        return null;
    }

    TypeReference runtimePlatform = new TypeReference("UnityEngine", "RuntimePlatform", module, unityEngineReference, true);
    TypeReference application = new TypeReference("UnityEngine", "Application", module, unityEngineReference);
    return new MethodReference("get_platform", runtimePlatform, application) { HasThis = false };
}

static bool IsUnitySerializableField(FieldDefinition field)
{
    if (field.IsStatic || field.IsLiteral || field.IsNotSerialized)
    {
        return false;
    }

    return field.IsPublic || field.CustomAttributes.Any(attribute =>
        attribute.AttributeType.FullName == "UnityEngine.SerializeField");
}

static bool HasSerializationAlias(FieldDefinition field, string alias)
{
    foreach (CustomAttribute attribute in field.CustomAttributes)
    {
        if (attribute.AttributeType.FullName == "UnityEngine.Serialization.FormerlySerializedAsAttribute" &&
            attribute.ConstructorArguments.Count == 1 &&
            attribute.ConstructorArguments[0].Value as string == alias)
        {
            return true;
        }
    }

    return false;
}

static List<(FieldDefinition Source, FieldDefinition Target)> AlignSerializableFields(
    IReadOnlyList<FieldDefinition> sourceFields,
    IReadOnlyList<FieldDefinition> targetFields)
{
    // Field order is stable in Unity serialization. LCS permits fields added or removed
    // between releases while refusing to pair fields whose CLR types differ.
    int[,] lengths = new int[sourceFields.Count + 1, targetFields.Count + 1];
    for (int sourceIndex = sourceFields.Count - 1; sourceIndex >= 0; sourceIndex--)
    {
        for (int targetIndex = targetFields.Count - 1; targetIndex >= 0; targetIndex--)
        {
            if (sourceFields[sourceIndex].FieldType.FullName == targetFields[targetIndex].FieldType.FullName)
            {
                lengths[sourceIndex, targetIndex] = 1 + lengths[sourceIndex + 1, targetIndex + 1];
            }
            else
            {
                lengths[sourceIndex, targetIndex] = Math.Max(
                    lengths[sourceIndex + 1, targetIndex],
                    lengths[sourceIndex, targetIndex + 1]);
            }
        }
    }

    var matches = new List<(FieldDefinition Source, FieldDefinition Target)>();
    int sourceCursor = 0;
    int targetCursor = 0;
    while (sourceCursor < sourceFields.Count && targetCursor < targetFields.Count)
    {
        FieldDefinition sourceField = sourceFields[sourceCursor];
        FieldDefinition targetField = targetFields[targetCursor];
        if (sourceField.FieldType.FullName == targetField.FieldType.FullName &&
            lengths[sourceCursor, targetCursor] == 1 + lengths[sourceCursor + 1, targetCursor + 1])
        {
            matches.Add((sourceField, targetField));
            sourceCursor++;
            targetCursor++;
        }
        else if (lengths[sourceCursor + 1, targetCursor] > lengths[sourceCursor, targetCursor + 1])
        {
            sourceCursor++;
        }
        else
        {
            targetCursor++;
        }
    }

    return matches;
}

static MethodReference? CreateFormerlySerializedAsConstructor(ModuleDefinition module)
{
    AssemblyNameReference? unityEngineReference = module.AssemblyReferences.FirstOrDefault(reference => reference.Name == "UnityEngine");
    if (unityEngineReference == null)
    {
        return null;
    }

    TypeReference attributeType = new TypeReference(
        "UnityEngine.Serialization",
        "FormerlySerializedAsAttribute",
        module,
        unityEngineReference);
    MethodReference constructor = new MethodReference(".ctor", module.TypeSystem.Void, attributeType)
    {
        HasThis = true
    };
    constructor.Parameters.Add(new ParameterDefinition(module.TypeSystem.String));
    return constructor;
}
