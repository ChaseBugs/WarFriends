using Mono.Cecil;
using Mono.Cecil.Cil;
using AssetRipper.HashAlgorithms;
using System.Buffers.Binary;
using System.Text;

if (args.Length < 1)
{
    Console.Error.WriteLine("Usage: LegacyAssemblyPatcher <assembly> [--patch] [--rename-assembly <name>] [--retarget <old=new>] [--merge-assembly-ref <old=new>] [--search-directory <path>] [--dump-script-types <csv>] [--dump-type-closure <seed-list> <csv>] [--dump-field-data <name>]");
    return 2;
}

var assemblyPath = Path.GetFullPath(args[0]);
var patch = args.Skip(1).Any(value => value == "--patch");
var guardAndroidRotation = args.Skip(1).Any(value => value == "--guard-android-rotation");
var guardGooglePlayDownloader = args.Skip(1).Any(value => value == "--guard-google-play-downloader");
var fixSingletonLifecycle = args.Skip(1).Any(value => value == "--fix-singleton-lifecycle");
var guardHybridRuntime = args.Skip(1).Any(value => value == "--guard-hybrid-runtime");
var guardShutdownCallbacks = args.Skip(1).Any(value => value == "--guard-shutdown-callbacks");
var guardSingletonInstance = args.Skip(1).Any(value => value == "--guard-singleton-instance");
var guardBattleAwakes = args.Skip(1).Any(value => value == "--guard-battle-awakes");
var guardDontDestroyOnLoad = args.Skip(1).Any(value => value == "--guard-dont-destroy-on-load");
string? redirectServerBaseUrl = null;
var bypassConnectivityCheck = args.Skip(1).Any(value => value == "--bypass-connectivity-check");
var guardNguiDrawCall = args.Skip(1).Any(value => value == "--guard-ngui-drawcall");
var enableLocalhostDevFlag = args.Skip(1).Any(value => value == "--enable-localhost-dev-flag");
var setServerEndpointConstant = args.Skip(1).Any(value => value == "--set-server-endpoint-constant");
string? renamedAssembly = null;
var retargets = new Dictionary<string, string>(StringComparer.Ordinal);
var assemblyMerges = new Dictionary<string, string>(StringComparer.Ordinal);
var searchDirectories = new List<string>();
string? scriptTypeMapPath = null;
string? typeClosureSeedPath = null;
string? typeClosureOutputPath = null;
string? fieldMapPath = null;
string? serializationAliasSourcePath = null;
string? sequenceSerializationAliasSourcePath = null;
string? dumpMethodName = null;
string? dumpFieldDataName = null;
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
    else if (args[index] == "--merge-assembly-ref" && index + 1 < args.Length)
    {
        var pair = args[++index].Split('=', 2);
        if (pair.Length != 2 || string.IsNullOrWhiteSpace(pair[0]) || string.IsNullOrWhiteSpace(pair[1]))
        {
            Console.Error.WriteLine("Invalid --merge-assembly-ref value. Expected <old=new>.");
            return 2;
        }

        assemblyMerges[pair[0]] = pair[1];
    }
    else if (args[index] == "--redirect-server-base-url" && index + 1 < args.Length)
    {
        redirectServerBaseUrl = args[++index];
    }
    else if (args[index] == "--search-directory" && index + 1 < args.Length)
    {
        searchDirectories.Add(Path.GetFullPath(args[++index]));
    }
    else if (args[index] == "--dump-script-types" && index + 1 < args.Length)
    {
        scriptTypeMapPath = Path.GetFullPath(args[++index]);
    }
    else if (args[index] == "--dump-type-closure" && index + 2 < args.Length)
    {
        typeClosureSeedPath = Path.GetFullPath(args[++index]);
        typeClosureOutputPath = Path.GetFullPath(args[++index]);
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
    else if (args[index] == "--dump-field-data" && index + 1 < args.Length)
    {
        dumpFieldDataName = args[++index];
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

if (!string.IsNullOrWhiteSpace(typeClosureSeedPath) && !string.IsNullOrWhiteSpace(typeClosureOutputPath))
{
    // A source replacement must include the exact 4.9.5 base classes and member types used by
    // every serialized seed. Binding a newer derived class to a similarly named 1.6.0 base can
    // silently change virtual slots and serialized layout. The Cecil closure follows metadata,
    // IL operands, attributes, and nested types so only genuinely reachable assembly-local
    // source files are selected while third-party and Unity references remain external.
    HashSet<string> seedNames = File.ReadAllLines(typeClosureSeedPath)
        .Select(line => line.Trim())
        .Where(line => line.Length > 0)
        .ToHashSet(StringComparer.Ordinal);
    IReadOnlyList<(TypeDefinition Type, bool IsSeed)> closure = CalculateTypeClosure(module, seedNames);

    var report = new StringBuilder();
    report.AppendLine("full_name,namespace,name,reason");
    foreach ((TypeDefinition type, bool isSeed) in closure)
    {
        report.AppendLine(string.Join(",", new[]
        {
            Csv(type.FullName),
            Csv(type.Namespace ?? string.Empty),
            Csv(type.Name),
            Csv(isSeed ? "closure root" : "assembly-local dependency")
        }));
    }
    File.WriteAllText(typeClosureOutputPath, report.ToString());
    Console.WriteLine($"Type closure: {typeClosureOutputPath} ({seedNames.Count} seeds, {closure.Count} top-level types)");
}

if (!string.IsNullOrWhiteSpace(fieldMapPath))
{
    var report = new StringBuilder();
    report.AppendLine("type,field,field_type,is_static,is_not_serialized,is_public,custom_attributes");
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
                field.IsNotSerialized ? "true" : "false",
                field.IsPublic ? "true" : "false",
                Csv(string.Join(";", field.CustomAttributes
                    .Select(attribute => attribute.AttributeType.FullName)
                    .OrderBy(value => value, StringComparer.Ordinal)))
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

if (!string.IsNullOrWhiteSpace(dumpFieldDataName))
{
    // RuntimeHelpers.InitializeArray receives only a field token in IL. Decompilers can
    // lose that token when producing C#, so expose the exact RVA bytes needed to rebuild
    // source initializers without guessing gameplay values.
    foreach (FieldDefinition field in EnumerateTypes(module.Types)
        .SelectMany(type => type.Fields)
        .Where(field => field.Name.Contains(dumpFieldDataName, StringComparison.Ordinal)))
    {
        byte[] data = field.InitialValue ?? Array.Empty<byte>();
        Console.WriteLine($"FIELD-DATA {field.DeclaringType.FullName}::{field.Name} bytes={data.Length}");
        Console.WriteLine(Convert.ToHexString(data));
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

if (guardSingletonInstance)
{
    AssemblyNameReference compatReference = module.AssemblyReferences.FirstOrDefault(reference => reference.Name == "WarFriends.LegacyCompat");
    if (compatReference == null)
    {
        compatReference = new AssemblyNameReference("WarFriends.LegacyCompat", new Version(1, 0, 0, 0));
        module.AssemblyReferences.Add(compatReference);
    }

    TypeReference? objectType = module.GetTypeReferences().FirstOrDefault(type => type.FullName == "UnityEngine.Object");
    TypeReference? systemTypeType = module.GetTypeReferences().FirstOrDefault(type => type.FullName == "System.Type");
    if (objectType == null || systemTypeType == null)
    {
        Console.Error.WriteLine("Could not resolve UnityEngine.Object / System.Type references for singleton guard.");
        assembly.Dispose();
        return 3;
    }

    TypeReference supportType = new TypeReference("WarFriends.Legacy", "SingletonSupport", module, compatReference);
    MethodReference findOrCreate = new MethodReference("FindOrCreate", objectType, supportType) { HasThis = false };
    findOrCreate.Parameters.Add(new ParameterDefinition(systemTypeType));
    MethodReference firstOrDefault = new MethodReference("FirstOrDefault", objectType, supportType) { HasThis = false };
    firstOrDefault.Parameters.Add(new ParameterDefinition(new ArrayType(objectType)));

    string[] getComponentsMethods = { "GetComponents", "GetComponentsInChildren", "GetComponentsInParent" };
    int rewrittenSingletons = 0;
    int rewrittenComponents = 0;
    foreach (TypeDefinition type in EnumerateTypes(module.Types))
    {
        foreach (MethodDefinition method in type.Methods)
        {
            if (!method.HasBody)
            {
                continue;
            }

            ILProcessor il = method.Body.GetILProcessor();
            Mono.Collections.Generic.Collection<Instruction> instructions = method.Body.Instructions;
            for (int index = 0; index < instructions.Count; index++)
            {
                Instruction instruction = instructions[index];
                if (instruction.OpCode != OpCodes.Call && instruction.OpCode != OpCodes.Callvirt)
                {
                    continue;
                }

                Instruction? indexInstruction = instruction.Next;
                Instruction? elementInstruction = indexInstruction?.Next;
                bool indexedZero = indexInstruction != null && elementInstruction != null &&
                    IsLoadIntegerZero(indexInstruction) && elementInstruction.OpCode == OpCodes.Ldelem_Ref;
                if (!indexedZero)
                {
                    continue;
                }

                // Static Object.FindObjectsOfType(type)[0]: find the live instance or lazily create one.
                if (instruction.Operand is MethodReference callee &&
                    callee.DeclaringType != null &&
                    callee.DeclaringType.FullName == "UnityEngine.Object" &&
                    callee.Name == "FindObjectsOfType" &&
                    callee.Parameters.Count == 1 &&
                    callee.Parameters[0].ParameterType.FullName == "System.Type")
                {
                    instruction.OpCode = OpCodes.Call;
                    instruction.Operand = findOrCreate;
                    il.Remove(elementInstruction!);
                    il.Remove(indexInstruction!);
                    rewrittenSingletons++;
                    changes++;
                    continue;
                }

                // Instance GetComponents*<T>(...)[0]: take the first element or null, then cast back to T.
                if (instruction.Operand is GenericInstanceMethod genericCallee &&
                    genericCallee.ElementMethod.DeclaringType != null &&
                    (genericCallee.ElementMethod.DeclaringType.FullName == "UnityEngine.Component" ||
                     genericCallee.ElementMethod.DeclaringType.FullName == "UnityEngine.GameObject") &&
                    getComponentsMethods.Contains(genericCallee.ElementMethod.Name) &&
                    genericCallee.GenericArguments.Count == 1)
                {
                    TypeReference elementType = genericCallee.GenericArguments[0];
                    indexInstruction!.OpCode = OpCodes.Call;
                    indexInstruction.Operand = firstOrDefault;
                    elementInstruction!.OpCode = OpCodes.Castclass;
                    elementInstruction.Operand = elementType;
                    rewrittenComponents++;
                    changes++;
                }
            }
        }
    }

    Console.WriteLine($"Guarded {rewrittenSingletons} FindObjectsOfType(type)[0] via SingletonSupport.FindOrCreate; " +
        $"{rewrittenComponents} GetComponents*<T>()[0] via SingletonSupport.FirstOrDefault.");
}

if (setServerEndpointConstant)
{
    // Point the client's base-URL builders at the single global constant WarFriends.Legacy.ServerEndpoint
    // .BaseUrl, so the endpoint lives in one editable place instead of the scattered hardcoded strings.
    TypeDefinition? urlProvider = module.Types.FirstOrDefault(type => type.FullName == "DJOJPKGADMP");
    if (urlProvider == null)
    {
        Console.Error.WriteLine("Could not locate DJOJPKGADMP server-URL provider.");
        assembly.Dispose();
        return 3;
    }

    AssemblyNameReference compatReference = module.AssemblyReferences.FirstOrDefault(reference => reference.Name == "WarFriends.LegacyCompat");
    if (compatReference == null)
    {
        compatReference = new AssemblyNameReference("WarFriends.LegacyCompat", new Version(1, 0, 0, 0));
        module.AssemblyReferences.Add(compatReference);
    }

    TypeReference endpointType = new TypeReference("WarFriends.Legacy", "ServerEndpoint", module, compatReference);
    FieldReference baseUrlField = new FieldReference("BaseUrl", module.TypeSystem.String, endpointType);

    string[] builderNames = { "NPDIBOLPACA", "BGMBGEOAKPP" };
    int rewritten = 0;
    foreach (string builderName in builderNames)
    {
        MethodDefinition? builder = urlProvider.Methods.FirstOrDefault(method =>
            method.Name == builderName && method.Parameters.Count == 0 &&
            method.ReturnType.FullName == "System.String");
        if (builder == null || !builder.HasBody)
        {
            Console.Error.WriteLine($"Could not locate DJOJPKGADMP::{builderName}().");
            continue;
        }

        builder.Body = new MethodBody(builder);
        ILProcessor il = builder.Body.GetILProcessor();
        il.Append(il.Create(OpCodes.Ldsfld, baseUrlField));
        il.Append(il.Create(OpCodes.Ret));
        rewritten++;
        changes++;
    }

    Console.WriteLine($"Pointed {rewritten} server base-URL builder(s) at WarFriends.Legacy.ServerEndpoint.BaseUrl.");
}

if (enableLocalhostDevFlag)
{
    // Flip the client's OWN built-in localhost dev switch (decompiled as DJOJPKGADMP.DLKMLPAHJEI, returns
    // false) to true. Its URL builder NPDIBOLPACA then yields "http://localhost:8081/api/" via the
    // developers' original branch, instead of the retired AWS host — no invented logic, no hardcoded URL.
    // The hybrid DLL's obfuscated getter name differs from the decompile, so locate it dynamically as the
    // bool-returning DJOJPKGADMP method NPDIBOLPACA calls to gate the localhost branch.
    TypeDefinition? urlProviderType = module.Types.FirstOrDefault(type => type.FullName == "DJOJPKGADMP");
    MethodDefinition? urlBuilder = urlProviderType?.Methods.FirstOrDefault(method => method.Name == "NPDIBOLPACA" && method.HasBody);
    MethodDefinition? flagGetter = urlBuilder?.Body.Instructions
        .Where(instruction => (instruction.OpCode == OpCodes.Call || instruction.OpCode == OpCodes.Callvirt) &&
            instruction.Operand is MethodReference callee &&
            callee.DeclaringType?.FullName == "DJOJPKGADMP" &&
            callee.ReturnType.FullName == "System.Boolean" &&
            callee.Parameters.Count == 0)
        .Select(instruction => (instruction.Operand as MethodReference)?.Resolve())
        .FirstOrDefault(method => method != null);
    if (flagGetter == null || !flagGetter.HasBody)
    {
        Console.Error.WriteLine("Could not locate the localhost dev flag getter used by DJOJPKGADMP.NPDIBOLPACA.");
        assembly.Dispose();
        return 3;
    }

    flagGetter.Body = new MethodBody(flagGetter);
    ILProcessor il = flagGetter.Body.GetILProcessor();
    il.Append(il.Create(OpCodes.Ldc_I4_1));
    il.Append(il.Create(OpCodes.Ret));
    changes++;
    Console.WriteLine("Enabled client built-in localhost dev flag (DJOJPKGADMP.DLKMLPAHJEI -> true).");
}

if (guardNguiDrawCall)
{
    // NGUI UIDrawCall.UpdateMaterials reads mSharedMat.shader while building the clip-shader name.
    // AssetRipper-recovered draw calls (e.g. GuiAtlasSplash) can have a null mSharedMat, so that
    // dereference NREs every frame under [ExecuteInEditMode]/render. Skip the clip-shader block when
    // the shared material is null.
    MethodDefinition? updateMaterials = module.Types.FirstOrDefault(type => type.FullName == "UIDrawCall")?
        .Methods.FirstOrDefault(method => method.Name == "UpdateMaterials" && method.Parameters.Count == 0);
    if (updateMaterials == null || !updateMaterials.HasBody)
    {
        Console.Error.WriteLine("Could not locate UIDrawCall.UpdateMaterials().");
        assembly.Dispose();
        return 3;
    }

    Instruction? shaderGetter = updateMaterials.Body.Instructions.FirstOrDefault(instruction =>
        instruction.OpCode == OpCodes.Callvirt && instruction.Operand is MethodReference method &&
        method.Name == "get_shader" && method.DeclaringType?.FullName == "UnityEngine.Material");
    Instruction? sharedMatLoad = shaderGetter?.Previous;
    Instruction? blockStart = sharedMatLoad?.Previous;
    FieldReference? sharedMatField = sharedMatLoad?.Operand as FieldReference;
    Instruction? clippingBranch = updateMaterials.Body.Instructions.FirstOrDefault(instruction =>
        instruction.OpCode == OpCodes.Brfalse && instruction.Previous?.OpCode == OpCodes.Ldfld &&
        (instruction.Previous.Operand as FieldReference)?.Name == "mClipping");
    Instruction? skipTarget = clippingBranch?.Operand as Instruction;

    if (sharedMatField == null || sharedMatField.Name != "mSharedMat" || blockStart == null || skipTarget == null)
    {
        Console.Error.WriteLine("Unexpected UIDrawCall.UpdateMaterials IL layout.");
        assembly.Dispose();
        return 3;
    }

    // The whole method ends by assigning to the draw call's MeshRenderer (mRen). Recovered draw calls
    // can have a null mRen, so mRen.get_sharedMaterial()/get_sharedMaterials() NRE at the tail (the path
    // the splash atlas hits, since it has no clipping/depth). Guard the method so it returns immediately
    // when mRen is null - there is nothing to update without a renderer.
    FieldReference? renField = updateMaterials.Body.Instructions
        .Select(instruction => instruction.Operand as FieldReference)
        .FirstOrDefault(field => field != null && field.Name == "mRen");
    if (renField == null)
    {
        Console.Error.WriteLine("Could not locate UIDrawCall.mRen field.");
        assembly.Dispose();
        return 3;
    }

    ILProcessor il = updateMaterials.Body.GetILProcessor();

    Instruction originalFirst = updateMaterials.Body.Instructions[0];
    il.InsertBefore(originalFirst, il.Create(OpCodes.Ldarg_0));
    il.InsertBefore(originalFirst, il.Create(OpCodes.Ldfld, renField));
    il.InsertBefore(originalFirst, il.Create(OpCodes.Brtrue, originalFirst));
    il.InsertBefore(originalFirst, il.Create(OpCodes.Ret));

    il.InsertBefore(blockStart, il.Create(OpCodes.Ldarg_0));
    il.InsertBefore(blockStart, il.Create(OpCodes.Ldfld, sharedMatField));
    il.InsertBefore(blockStart, il.Create(OpCodes.Brfalse, skipTarget));
    changes++;
    Console.WriteLine("Guarded UIDrawCall.UpdateMaterials against a null MeshRenderer and null shared material.");
}

if (bypassConnectivityCheck)
{
    // BeanstalkServerManager.CheckIsOnline(Action) posts to "<base>/check.php" and only invokes its
    // success callback when the response body is exactly "ok". The reimplemented Server has no
    // check.php route, so the probe fails and the client shows the "check connection" error instead
    // of proceeding to CreateAccount. Rewrite the method to invoke the callback directly.
    MethodDefinition? checkIsOnline = module.Types.FirstOrDefault(type => type.FullName == "BeanstalkServerManager")?
        .Methods.FirstOrDefault(method => method.Name == "CheckIsOnline" && method.Parameters.Count == 1 &&
            method.Parameters[0].ParameterType.FullName == "System.Action");
    if (checkIsOnline == null)
    {
        Console.Error.WriteLine("Could not locate BeanstalkServerManager.CheckIsOnline(System.Action).");
        assembly.Dispose();
        return 3;
    }

    TypeReference actionType = checkIsOnline.Parameters[0].ParameterType;
    MethodReference invoke = new MethodReference("Invoke", module.TypeSystem.Void, actionType) { HasThis = true };

    checkIsOnline.Body = new MethodBody(checkIsOnline);
    ILProcessor il = checkIsOnline.Body.GetILProcessor();
    Instruction ret = il.Create(OpCodes.Ret);
    il.Append(il.Create(OpCodes.Ldarg_1));
    il.Append(il.Create(OpCodes.Brfalse, ret));
    il.Append(il.Create(OpCodes.Ldarg_1));
    il.Append(il.Create(OpCodes.Callvirt, invoke));
    il.Append(ret);
    changes++;
    Console.WriteLine("Bypassed BeanstalkServerManager.CheckIsOnline connectivity probe (invokes callback directly).");
}

if (!string.IsNullOrWhiteSpace(redirectServerBaseUrl))
{
    // DJOJPKGADMP builds BeanstalkServerManager's base URL. Both builders are overwritten so the
    // client posts to the local reimplemented backend instead of the retired AWS/Beanstalk host.
    // The value must be the exact base ending in '/', producing "<base><action>/<version>". Use a
    // plain http:// base so BestHTTP never runs the pinned-certificate validator (AACFNCKFCHO).
    TypeDefinition? urlProvider = module.Types.FirstOrDefault(type => type.FullName == "DJOJPKGADMP");
    if (urlProvider == null)
    {
        Console.Error.WriteLine("Could not locate DJOJPKGADMP server-URL provider.");
        assembly.Dispose();
        return 3;
    }

    string[] builderNames = { "NPDIBOLPACA", "BGMBGEOAKPP" };
    int rewritten = 0;
    foreach (string builderName in builderNames)
    {
        MethodDefinition? builder = urlProvider.Methods.FirstOrDefault(method =>
            method.Name == builderName && method.Parameters.Count == 0 &&
            method.ReturnType.FullName == "System.String");
        if (builder == null || !builder.HasBody)
        {
            Console.Error.WriteLine($"Could not locate DJOJPKGADMP::{builderName}().");
            continue;
        }

        builder.Body = new MethodBody(builder);
        ILProcessor il = builder.Body.GetILProcessor();
        il.Append(il.Create(OpCodes.Ldstr, redirectServerBaseUrl));
        il.Append(il.Create(OpCodes.Ret));
        rewritten++;
        changes++;
    }

    Console.WriteLine($"Redirected {rewritten} server base-URL builder(s) to {redirectServerBaseUrl}.");
}

if (guardDontDestroyOnLoad)
{
    AssemblyNameReference compatReference = module.AssemblyReferences.FirstOrDefault(reference => reference.Name == "WarFriends.LegacyCompat");
    if (compatReference == null)
    {
        compatReference = new AssemblyNameReference("WarFriends.LegacyCompat", new Version(1, 0, 0, 0));
        module.AssemblyReferences.Add(compatReference);
    }

    TypeReference? objectType = module.GetTypeReferences().FirstOrDefault(type => type.FullName == "UnityEngine.Object");
    if (objectType == null)
    {
        Console.Error.WriteLine("Could not resolve UnityEngine.Object reference for DontDestroyOnLoad guard.");
        assembly.Dispose();
        return 3;
    }

    TypeReference supportType = new TypeReference("WarFriends.Legacy", "SingletonSupport", module, compatReference);
    MethodReference guardedDontDestroy = new MethodReference("DontDestroyOnLoadIfPlaying", module.TypeSystem.Void, supportType) { HasThis = false };
    guardedDontDestroy.Parameters.Add(new ParameterDefinition(objectType));

    int rewritten = 0;
    foreach (TypeDefinition type in EnumerateTypes(module.Types))
    {
        foreach (MethodDefinition method in type.Methods)
        {
            if (!method.HasBody)
            {
                continue;
            }

            foreach (Instruction instruction in method.Body.Instructions)
            {
                if ((instruction.OpCode == OpCodes.Call || instruction.OpCode == OpCodes.Callvirt) &&
                    instruction.Operand is MethodReference callee &&
                    callee.DeclaringType?.FullName == "UnityEngine.Object" &&
                    callee.Name == "DontDestroyOnLoad" &&
                    callee.Parameters.Count == 1)
                {
                    instruction.OpCode = OpCodes.Call;
                    instruction.Operand = guardedDontDestroy;
                    rewritten++;
                    changes++;
                }
            }
        }
    }

    Console.WriteLine($"Guarded {rewritten} DontDestroyOnLoad call(s) via SingletonSupport.DontDestroyOnLoadIfPlaying.");
}

if (guardBattleAwakes)
{
    // Barrel.Awake subscribes to a DestroyableObject component that the recovered prefab may lack;
    // GetComponent<DestroyableObject>() then returns null and add_OnDamage/add_OnDeath NRE. Skip the
    // subscriptions when the component is absent.
    MethodDefinition? barrelAwake = module.Types.FirstOrDefault(type => type.FullName == "Barrel")?
        .Methods.FirstOrDefault(method => method.Name == "Awake" && method.Parameters.Count == 0);
    if (barrelAwake != null && barrelAwake.HasBody)
    {
        Instruction? addOnDamage = barrelAwake.Body.Instructions.FirstOrDefault(instruction =>
            instruction.OpCode == OpCodes.Callvirt && instruction.Operand is MethodReference method &&
            method.Name == "add_OnDamage" && method.DeclaringType?.Name == "DestroyableObject");
        Instruction? addOnDeath = barrelAwake.Body.Instructions.LastOrDefault(instruction =>
            instruction.OpCode == OpCodes.Callvirt && instruction.Operand is MethodReference method &&
            method.Name == "add_OnDeath" && method.DeclaringType?.Name == "DestroyableObject");
        Instruction? getDestroyable = barrelAwake.Body.Instructions.FirstOrDefault(instruction =>
            (instruction.OpCode == OpCodes.Call || instruction.OpCode == OpCodes.Callvirt) &&
            instruction.Operand is GenericInstanceMethod generic && generic.ElementMethod.Name == "GetComponent" &&
            generic.GenericArguments.Count == 1 && generic.GenericArguments[0].FullName == "DestroyableObject");
        VariableDefinition? destroyableLocal = ResolveStoreLocal(barrelAwake, getDestroyable?.Next);

        if (addOnDamage != null && addOnDeath != null && destroyableLocal != null && addOnDeath.Next != null)
        {
            Instruction blockStart = addOnDamage;
            for (int step = 0; step < 4 && blockStart.Previous != null; step++)
            {
                blockStart = blockStart.Previous;
            }

            ILProcessor il = barrelAwake.Body.GetILProcessor();
            il.InsertBefore(blockStart, il.Create(OpCodes.Ldloc, destroyableLocal));
            il.InsertBefore(blockStart, il.Create(OpCodes.Brfalse, addOnDeath.Next));
            changes++;
            Console.WriteLine("Guarded Barrel.Awake against a missing DestroyableObject component.");
        }
        else
        {
            Console.Error.WriteLine("Skipped Barrel.Awake guard: unexpected IL layout.");
        }
    }

    // MapManager.Awake indexes its serialized map list at [0]; when the recovered list is null it NREs.
    // Return after the base Singleton Awake when the list is not populated.
    MethodDefinition? mapAwake = module.Types.FirstOrDefault(type => type.FullName == "MapManager")?
        .Methods.FirstOrDefault(method => method.Name == "Awake" && method.Parameters.Count == 0);
    if (mapAwake != null && mapAwake.HasBody)
    {
        Instruction? getItem = mapAwake.Body.Instructions.FirstOrDefault(instruction =>
            instruction.OpCode == OpCodes.Callvirt && instruction.Operand is MethodReference method &&
            method.Name == "get_Item" && method.DeclaringType?.Name == "List`1");
        FieldReference? listField = getItem?.Previous?.Previous?.Operand as FieldReference;
        Instruction? baseAwakeCall = mapAwake.Body.Instructions.FirstOrDefault(instruction =>
            instruction.OpCode == OpCodes.Call && instruction.Operand is MethodReference method &&
            method.Name == "Awake" && method.DeclaringType?.Name == "Singleton`1");

        if (listField != null && baseAwakeCall != null && baseAwakeCall.Next != null)
        {
            Instruction continuation = baseAwakeCall.Next;
            ILProcessor il = mapAwake.Body.GetILProcessor();
            il.InsertBefore(continuation, il.Create(OpCodes.Ldarg_0));
            il.InsertBefore(continuation, il.Create(OpCodes.Ldfld, listField));
            il.InsertBefore(continuation, il.Create(OpCodes.Brtrue, continuation));
            il.InsertBefore(continuation, il.Create(OpCodes.Ret));
            changes++;
            Console.WriteLine("Guarded MapManager.Awake against a null map list.");
        }
        else
        {
            Console.Error.WriteLine("Skipped MapManager.Awake guard: unexpected IL layout.");
        }
    }
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

foreach (var (oldName, newName) in assemblyMerges.Select(pair => (pair.Key, pair.Value)))
{
    var source = module.AssemblyReferences.FirstOrDefault(reference => reference.Name == oldName);
    if (source == null)
    {
        Console.WriteLine($"Merge assembly reference {oldName} -> {newName}: source reference not present, skipping.");
        continue;
    }

    var target = module.AssemblyReferences.FirstOrDefault(reference => reference.Name == newName);
    if (target == null)
    {
        target = new AssemblyNameReference(newName, source.Version);
        module.AssemblyReferences.Add(target);
    }

    var repointed = 0;
    foreach (var typeReference in module.GetTypeReferences())
    {
        if (ReferenceEquals(typeReference.Scope, source))
        {
            typeReference.Scope = target;
            repointed++;
        }
    }

    module.AssemblyReferences.Remove(source);
    changes++;
    Console.WriteLine($"Merged assembly reference {oldName} -> {newName} ({repointed} type reference(s) repointed).");
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

static IReadOnlyList<(TypeDefinition Type, bool IsSeed)> CalculateTypeClosure(
    ModuleDefinition module,
    IReadOnlySet<string> seedNames)
{
    Dictionary<string, TypeDefinition> definitions = EnumerateTypes(module.Types)
        .ToDictionary(type => type.FullName, StringComparer.Ordinal);
    var selectedTopLevelNames = new HashSet<string>(StringComparer.Ordinal);
    var queuedTopLevelNames = new HashSet<string>(StringComparer.Ordinal);
    var queue = new Queue<TypeDefinition>();

    foreach (string seedName in seedNames.OrderBy(value => value, StringComparer.Ordinal))
    {
        if (!definitions.TryGetValue(seedName, out TypeDefinition? seed))
        {
            throw new InvalidOperationException($"Type-closure seed does not exist in assembly: {seedName}");
        }
        TypeDefinition topLevelSeed = GetTopLevelType(seed);
        if (queuedTopLevelNames.Add(topLevelSeed.FullName))
        {
            queue.Enqueue(topLevelSeed);
        }
    }

    while (queue.Count > 0)
    {
        TypeDefinition current = queue.Dequeue();
        selectedTopLevelNames.Add(current.FullName);

        foreach (string referencedName in EnumerateReferencedTypeNames(current))
        {
            if (!definitions.TryGetValue(referencedName, out TypeDefinition? referenced))
            {
                continue;
            }
            TypeDefinition referencedTopLevel = GetTopLevelType(referenced);
            if (queuedTopLevelNames.Add(referencedTopLevel.FullName))
            {
                queue.Enqueue(referencedTopLevel);
            }
        }
    }

    return selectedTopLevelNames
        .Select(name => definitions[name])
        .OrderBy(type => type.FullName, StringComparer.Ordinal)
        .Select(type => (type, seedNames.Contains(type.FullName)))
        .ToList();
}

static TypeDefinition GetTopLevelType(TypeDefinition type)
{
    while (type.DeclaringType != null)
    {
        type = type.DeclaringType;
    }
    return type;
}

static IEnumerable<string> EnumerateReferencedTypeNames(TypeDefinition topLevelType)
{
    var names = new HashSet<string>(StringComparer.Ordinal);

    void AddTypeReference(TypeReference? type)
    {
        if (type == null)
        {
            return;
        }

        if (type is GenericInstanceType genericInstance)
        {
            AddTypeReference(genericInstance.ElementType);
            foreach (TypeReference argument in genericInstance.GenericArguments)
            {
                AddTypeReference(argument);
            }
            return;
        }

        if (type is TypeSpecification specification)
        {
            AddTypeReference(specification.ElementType);
            return;
        }

        names.Add(type.FullName);
    }

    void AddGenericParameters(IEnumerable<GenericParameter> parameters)
    {
        foreach (GenericParameter parameter in parameters)
        {
            foreach (GenericParameterConstraint constraint in parameter.Constraints)
            {
                AddTypeReference(constraint.ConstraintType);
            }
            AddCustomAttributes(parameter.CustomAttributes);
        }
    }

    void AddMethodReference(MethodReference method)
    {
        AddTypeReference(method.DeclaringType);
        AddTypeReference(method.ReturnType);
        foreach (ParameterDefinition parameter in method.Parameters)
        {
            AddTypeReference(parameter.ParameterType);
        }
        if (method is GenericInstanceMethod genericMethod)
        {
            foreach (TypeReference argument in genericMethod.GenericArguments)
            {
                AddTypeReference(argument);
            }
        }
    }

    void AddFieldReference(FieldReference field)
    {
        AddTypeReference(field.DeclaringType);
        AddTypeReference(field.FieldType);
    }

    void AddCustomAttributes(IEnumerable<CustomAttribute> attributes)
    {
        foreach (CustomAttribute attribute in attributes)
        {
            AddTypeReference(attribute.AttributeType);
            AddMethodReference(attribute.Constructor);
            foreach (CustomAttributeArgument argument in attribute.ConstructorArguments)
            {
                AddCustomAttributeArgument(argument);
            }
            foreach (CustomAttributeNamedArgument argument in attribute.Fields)
            {
                AddCustomAttributeArgument(argument.Argument);
            }
            foreach (CustomAttributeNamedArgument argument in attribute.Properties)
            {
                AddCustomAttributeArgument(argument.Argument);
            }
        }
    }

    void AddCustomAttributeArgument(CustomAttributeArgument argument)
    {
        AddTypeReference(argument.Type);
        if (argument.Value is TypeReference typeValue)
        {
            AddTypeReference(typeValue);
        }
        else if (argument.Value is CustomAttributeArgument[] array)
        {
            foreach (CustomAttributeArgument item in array)
            {
                AddCustomAttributeArgument(item);
            }
        }
    }

    foreach (TypeDefinition type in EnumerateTypes(new[] { topLevelType }))
    {
        AddTypeReference(type.BaseType);
        foreach (InterfaceImplementation implementation in type.Interfaces)
        {
            AddTypeReference(implementation.InterfaceType);
            AddCustomAttributes(implementation.CustomAttributes);
        }
        AddGenericParameters(type.GenericParameters);
        AddCustomAttributes(type.CustomAttributes);

        foreach (FieldDefinition field in type.Fields)
        {
            AddTypeReference(field.FieldType);
            AddCustomAttributes(field.CustomAttributes);
        }

        foreach (PropertyDefinition property in type.Properties)
        {
            AddTypeReference(property.PropertyType);
            foreach (ParameterDefinition parameter in property.Parameters)
            {
                AddTypeReference(parameter.ParameterType);
            }
            AddCustomAttributes(property.CustomAttributes);
        }

        foreach (EventDefinition eventDefinition in type.Events)
        {
            AddTypeReference(eventDefinition.EventType);
            AddCustomAttributes(eventDefinition.CustomAttributes);
        }

        foreach (MethodDefinition method in type.Methods)
        {
            AddMethodReference(method);
            AddGenericParameters(method.GenericParameters);
            AddCustomAttributes(method.CustomAttributes);
            foreach (ParameterDefinition parameter in method.Parameters)
            {
                AddCustomAttributes(parameter.CustomAttributes);
            }
            foreach (MethodReference methodOverride in method.Overrides)
            {
                AddMethodReference(methodOverride);
            }

            if (!method.HasBody)
            {
                continue;
            }
            foreach (VariableDefinition variable in method.Body.Variables)
            {
                AddTypeReference(variable.VariableType);
            }
            foreach (ExceptionHandler handler in method.Body.ExceptionHandlers)
            {
                AddTypeReference(handler.CatchType);
            }
            foreach (Instruction instruction in method.Body.Instructions)
            {
                switch (instruction.Operand)
                {
                    case TypeReference typeReference:
                        AddTypeReference(typeReference);
                        break;
                    case MethodReference methodReference:
                        AddMethodReference(methodReference);
                        break;
                    case FieldReference fieldReference:
                        AddFieldReference(fieldReference);
                        break;
                    case CallSite callSite:
                        AddTypeReference(callSite.ReturnType);
                        foreach (ParameterDefinition parameter in callSite.Parameters)
                        {
                            AddTypeReference(parameter.ParameterType);
                        }
                        break;
                }
            }
        }
    }

    return names;
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

static VariableDefinition? ResolveStoreLocal(MethodDefinition method, Instruction? store)
{
    if (store == null)
    {
        return null;
    }

    if (store.OpCode == OpCodes.Stloc_0)
    {
        return method.Body.Variables.ElementAtOrDefault(0);
    }

    if (store.OpCode == OpCodes.Stloc_1)
    {
        return method.Body.Variables.ElementAtOrDefault(1);
    }

    if (store.OpCode == OpCodes.Stloc_2)
    {
        return method.Body.Variables.ElementAtOrDefault(2);
    }

    if (store.OpCode == OpCodes.Stloc_3)
    {
        return method.Body.Variables.ElementAtOrDefault(3);
    }

    if ((store.OpCode == OpCodes.Stloc || store.OpCode == OpCodes.Stloc_S) && store.Operand is VariableDefinition variable)
    {
        return variable;
    }

    return null;
}

static bool IsLoadIntegerZero(Instruction instruction)
{
    if (instruction.OpCode == OpCodes.Ldc_I4_0)
    {
        return true;
    }

    if (instruction.OpCode == OpCodes.Ldc_I4 && instruction.Operand is int intValue)
    {
        return intValue == 0;
    }

    if (instruction.OpCode == OpCodes.Ldc_I4_S && instruction.Operand is sbyte sbyteValue)
    {
        return sbyteValue == 0;
    }

    return false;
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
