using System.Reflection;
using System.Runtime.InteropServices;
using War.Backend;
using War.Battle.Domain.Matchmaking;
using War.BattleServer;
using War.Client;
using War.Infrastructure;
using War.Persistence;
using War.Shared;

namespace War.Battle.Tests.Architecture;

/// <summary>Verifies compiled ownership without starting a host, socket, native lease or database.</summary>
internal static class BattleProjectBoundaryTests
{
    private const string DomainAssemblyName = "War.Battle.Domain";
    private const string SimulationAssemblyName = "War.Battle.Simulation";
    private const string WorkerAssemblyName = "War.BattleServer";

    internal static int Run()
    {
        int checks = CheckDomain();
        checks += CheckSimulation();
        checks += CheckHostsAndConsumers();
        checks += CheckResources();
        checks += CheckPortableProjects();
        Require(BattleQueueAttemptTokens.LifetimeSeconds == BattleQueueAttemptPolicy.LifetimeSeconds,
            "Token issuance and durable queue receipts use different admission windows.");
        return checks + 1;
    }

    private static int CheckDomain()
    {
        Type[] types = [typeof(MatchManifest), typeof(ParticipantManifest), typeof(WeaponManifest),
            typeof(BattleTerminalEvidenceValidator), typeof(CompleteBattleEvidenceValidator),
            typeof(BattleArmyStatsProjection), typeof(OrdinaryCardInventory), typeof(OrdinaryCardIdentityCatalog),
            typeof(BattleQueueAttemptIdentity), typeof(BattleQueueAttemptPolicy), typeof(BattleCombatContent),
            typeof(ArmyDeploymentCatalog), typeof(WeaponBindingGraphCatalog), typeof(MortarWeaponPoolSource),
            typeof(GrenadeRigCatalog), typeof(GrenadeBallistics), typeof(HelicopterAircraftPosePolicy),
            typeof(BulletFlightDefinition)];
        int checks = CheckOwners(types, DomainAssemblyName);
        Assembly domain = typeof(MatchManifest).Assembly;
        Require(domain.GetReferencedAssemblies().All(IsRuleReference),
            "Domain acquired a simulation, hosting, persistence, signing or unreviewed dependency.");
        const BindingFlags Methods = BindingFlags.DeclaredOnly | BindingFlags.Public | BindingFlags.NonPublic |
            BindingFlags.Static | BindingFlags.Instance;
        Require(domain.GetTypes().SelectMany(type => type.GetMethods(Methods)).All(method =>
            method.GetCustomAttribute<DllImportAttribute>() == null), "Domain owns a native physics import.");
        return checks + 2;
    }

    private static int CheckSimulation()
    {
        Type[] types = [typeof(MatchEngine), typeof(CoopMatchRuntime), typeof(IMatchRuntime), typeof(BulletFlight),
            typeof(RifleMatchSimulation), typeof(NativeHelicopterPhysicsWorld), typeof(NativeHelicopterRope),
            typeof(MissionRuntimeFactory), typeof(RifleProjectileFactory), typeof(SmgProjectileFactory),
            typeof(PistolProjectileFactory), typeof(LmgProjectileFactory), typeof(MinigunProjectileFactory),
            typeof(SniperProjectileFactory)];
        int checks = CheckOwners(types, SimulationAssemblyName);
        Require(typeof(MatchEngine).Assembly.GetReferencedAssemblies().All(reference =>
            IsRuleReference(reference) || reference.Name == DomainAssemblyName),
            "Simulation acquired a host, signer, database or ASP.NET dependency.");
        Require(typeof(BulletLaunch).IsValueType && typeof(WeaponStageSelection).IsValueType,
            "Grouping projectile inputs introduced a reference context per shot.");

        Type[] catalogs = [typeof(RifleBindingCatalog), typeof(SmgCatalog), typeof(PistolCatalog),
            typeof(LmgCatalog), typeof(MinigunCatalog), typeof(SniperCatalog)];
        foreach (Type catalog in catalogs)
        {
            Require(!catalog.GetMethods(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance)
                .Any(method => method.Name == "Prepare"), "A source catalog still constructs runtime projectiles.");
        }
        return checks + 2 + catalogs.Length;
    }

    private static int CheckHostsAndConsumers()
    {
        Type[] hosts = [typeof(NetworkWorker), typeof(MatchRouter), typeof(TerminalOutbox),
            typeof(ActiveMatchJournal), typeof(MatchTokens)];
        int checks = CheckOwners(hosts, WorkerAssemblyName);
        Type[] keyPolicies = [typeof(TransportSecurityPolicy), typeof(BattleControlKeyPolicy),
            typeof(BattleKeyMaterial), typeof(BattleEndpointPolicy), typeof(DeploymentValueParser),
            typeof(TerminalResultEnvelope), typeof(BoundedStreamReader), typeof(ControlRequestAuthenticator)];
        checks += CheckOwners(keyPolicies, "War.Infrastructure");
        Require(!typeof(BattleManifestFactory).Assembly.GetReferencedAssemblies().Any(reference =>
            reference.Name is WorkerAssemblyName or SimulationAssemblyName),
            "Backend depends on the battle executable or mutable simulation.");
        Require(!typeof(LegacyPlayerStore).Assembly.GetReferencedAssemblies().Any(reference =>
            reference.Name is WorkerAssemblyName or SimulationAssemblyName or "War.Infrastructure"),
            "Persistence depends on the Worker, simulation or signer.");
        Require(!typeof(BattleQueueAttemptTokens).Assembly.GetReferencedAssemblies().Any(reference =>
            reference.Name is WorkerAssemblyName or SimulationAssemblyName or "War.Backend" or "War.Persistence"),
            "Signing infrastructure depends on a host, simulation or persistence.");
        return checks + 3;
    }

    private static int CheckResources()
    {
        string[] domainResources = ["War.BattleServer.GrenadeRig", "War.BattleServer.OrdinaryCardIdentities"];
        string[] simulationResources = ["War.BattleServer.GrenadierCornerMuzzles",
            "War.BattleServer.GrenadierPrimaryWeapon"];
        Require(typeof(MatchManifest).Assembly.GetManifestResourceNames().Order(StringComparer.Ordinal)
            .SequenceEqual(domainResources), "Domain resource ownership differs from its loaders.");
        Require(typeof(MatchEngine).Assembly.GetManifestResourceNames().Order(StringComparer.Ordinal)
            .SequenceEqual(simulationResources), "Simulation resource ownership differs from its loaders.");
        Require(typeof(NetworkWorker).Assembly.GetManifestResourceNames().Length == 0,
            "The Worker duplicates a library-owned source resource.");
        Require(OrdinaryCardIdentityCatalog.All.Count == 67 && GrenadierPrimaryWeapon.Instance.Speed > 0,
            "Embedded catalog loaders no longer validate their source-bound resources.");
        return 4;
    }

    private static int CheckPortableProjects()
    {
        Assembly[] portable = [typeof(BackendClient).Assembly, typeof(CanonicalGuid).Assembly];
        foreach (Assembly assembly in portable)
        {
            Require(!assembly.GetReferencedAssemblies().Any(reference =>
                reference.Name?.StartsWith("War.Battle", StringComparison.Ordinal) == true ||
                reference.Name is "War.Infrastructure" or "War.Persistence" or "War.Backend"),
                "A portable SDK project acquired a server-only dependency.");
        }
        return portable.Length;
    }

    private static int CheckOwners(Type[] types, string assemblyName)
    {
        foreach (Type type in types)
        {
            Require(type.Assembly.GetName().Name == assemblyName,
                $"{type.Name} is owned by {type.Assembly.GetName().Name}, expected {assemblyName}.");
        }
        return types.Length;
    }

    private static bool IsRuleReference(AssemblyName reference)
    {
        return reference.Name is "War.Shared" or "Google.Protobuf" or "netstandard" ||
            reference.Name?.StartsWith("System.", StringComparison.Ordinal) == true;
    }

    private static void Require(bool condition, string message)
    {
        if (!condition)
        {
            throw new InvalidOperationException(message);
        }
    }
}
