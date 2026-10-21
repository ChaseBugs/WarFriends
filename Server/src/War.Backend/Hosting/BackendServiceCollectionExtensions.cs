using System.Threading.RateLimiting;
using Microsoft.AspNetCore.RateLimiting;
using War.Backend.Features.Accounts;
using War.Backend.Features.Battle.Admission;
using War.Backend.Features.Battle.Authentication;
using War.Backend.Features.Battle.Queue;
using War.Backend.Features.Battle.Rematch;
using War.Backend.Features.Battle.Settlement;
using War.Backend.Features.Network;
using War.Backend.Hosting.Configuration;
using War.Backend.Legacy;
using War.Backend.Legacy.Dispatch;
using War.Backend.Legacy.Dispatch.Composition;
using War.Backend.Transport.Http;
using War.Infrastructure;
using War.Persistence;

namespace War.Backend.Hosting;

public static class BackendServiceCollectionExtensions
{
    public static IServiceCollection AddBackendServices(this IServiceCollection services,
        BackendDeploymentOptions deployment)
    {
        services.AddSingleton(deployment);
        AddPersistence(services, deployment.Database);
        AddLegacy(services, deployment.Legacy);
        AddBattle(services, deployment.Battle);
        AddRateLimits(services, deployment.RateLimits);
        AddApplicationServices(services);
        return services;
    }

    private static void AddApplicationServices(IServiceCollection services)
    {
        services.AddSingleton(TimeProvider.System);
        services.AddSingleton<AccountApplicationService>();
        services.AddSingleton<ConnectivityProbeService>();
        services.AddSingleton<BattlePlayerAuthentication>();
        services.AddSingleton<BattleControlAuthenticator>();
        services.AddSingleton<BattleGrantApplicationService>();
        services.AddSingleton<BattleQueueAdmission>();
        services.AddSingleton<BattleQueueHosting>();
        services.AddSingleton<BattleQueueApplicationService>();
        services.AddSingleton<BattleQueueAttemptService>();
        services.AddSingleton<BattleQueueCancellationService>();
        services.AddSingleton<BattleRematchApplicationService>();
    }

    private static void AddPersistence(IServiceCollection services, BackendDatabaseOptions database)
    {
        string uri = database.Uri;
        string name = database.DatabaseName;
        services.AddSingleton(_ => new AccountStore(uri, name));
        services.AddSingleton(_ => new BattleAllocationStore(uri, name));
        services.AddSingleton(_ => new BattleAllocationPreparationStore(uri, name));
        services.AddSingleton(_ => new BattleGrantStore(uri, name));
        services.AddSingleton(_ => new BattleMatchQueueStore(uri, name));
        services.AddSingleton(_ => new BattleManifestSnapshotStore(uri, name));
        services.AddSingleton(_ => new BattleResultStore(uri, name));
        services.AddSingleton(_ => new BattleRematchConsentStore(uri, name));
        services.AddSingleton(_ => new BattleResultArchivalLeaseStore(uri, name));
        services.AddSingleton(_ => new LegacyPlayerStore(uri, name));
        services.AddSingleton(_ => new LegacyBufferStore(uri, name));
        services.AddSingleton(_ => new LegacySquadStore(uri, name));
    }

    private static void AddLegacy(IServiceCollection services, BackendLegacyOptions legacy)
    {
        BattleClientWeaponIndices.Validate();
        LegacyInitialLoadout.Validate();
        BattleWeaponOwnership.Validate();
        BattleUnitProjection.Validate();

        services.AddSingleton(legacy.Catalog);
        services.AddSingleton(legacy.Starter);
        services.AddSingleton<LegacyBufferProcessor>();
        services.AddSingleton<LegacyBattleStartService>();
        services.AddSingleton<BattleSettlementService>();
        services.AddSingleton<ILegacySessionAuthentication, LegacySessionAuthentication>();
        services.AddSingleton(LegacyActionComposition.Create);
        services.AddSingleton<LegacyRequestDispatcher>();
    }

    private static void AddBattle(IServiceCollection services, BackendBattleOptions battle)
    {
        services.AddSingleton(battle);
        services.AddSingleton(new BattleTickets(battle.Keys.SigningKey));
        services.AddSingleton(new BattleQueueAttemptTokens(battle.Keys.ControlKey!));
        services.AddSingleton<BattleControlHttpClient>();
        services.AddSingleton(provider => new BattleMatchControlClient(
            provider.GetRequiredService<BattleControlHttpClient>().Client, battle.Keys.ControlKey!));
        services.AddSingleton(provider => new BattleMatchCancellationClient(
            provider.GetRequiredService<BattleControlHttpClient>().Client, battle.Keys.ControlKey!));
        services.AddSingleton<BattleAllocationSource>();
        services.AddSingleton<BattlePlayerPresentationSource>();
        services.AddSingleton<BattleRematchCancellation>();
        services.AddSingleton<BattleTerminalAcceptance>();
        services.AddHostedService<BattleResultArchivalService>();
        services.AddHostedService<BattleCancellationRecoveryService>();
        AddProvisioning(services, battle);
    }

    private static void AddProvisioning(IServiceCollection services, BackendBattleOptions battle)
    {
        services.AddSingleton(provider => new BattleCancellationPreparation(
            provider.GetRequiredService<BattleManifestSnapshotStore>(),
            provider.GetRequiredService<BattleMatchControlClient>(),
            provider.GetService<BattleManifestFactory>(), battle.ControlEndpoint));
        services.AddSingleton(provider => new BattlePairedCancellation(
            provider.GetRequiredService<BattleCancellationPreparation>(),
            provider.GetRequiredService<BattleTerminalAcceptance>(),
            provider.GetRequiredService<BattleMatchCancellationClient>(), battle.ControlEndpoint));
        services.AddSingleton(provider => new BattleMatchProvisioner(
            provider.GetRequiredService<BattleMatchControlClient>(),
            provider.GetRequiredService<BattleGrantStore>(), battle.ControlEndpoint));
        if (!battle.Content.IsConfigured)
        {
            return;
        }

        services.AddSingleton(battle.Content.Weapons!);
        services.AddSingleton(provider => new BattleManifestFactory(
            BattleSettlementTemplate.Bind(battle.Content.CopyTemplate(),
                provider.GetRequiredService<BackendDeploymentOptions>().Legacy.Rewards),
            provider.GetRequiredService<BattleAllocationStore>(),
            provider.GetRequiredService<BattlePlayerPresentationSource>(),
            provider.GetRequiredService<IBattleWeaponManifestCatalog>()));
        AddRematchAllocator(services, battle);
    }

    private static void AddRematchAllocator(IServiceCollection services, BackendBattleOptions battle)
    {
        if (battle.CompatibilityKey == null)
        {
            return;
        }
        services.AddSingleton(provider => new BattleRematchAllocator(
            new BattleRematchAllocator.Stores(provider.GetRequiredService<BattleRematchConsentStore>(),
                provider.GetRequiredService<BattleResultStore>(),
                provider.GetRequiredService<BattleManifestSnapshotStore>(),
                provider.GetRequiredService<BattleMatchQueueStore>()),
            new BattleRematchAllocator.Hosting(provider.GetRequiredService<BattleManifestFactory>(),
                provider.GetRequiredService<BattleMatchProvisioner>(), battle.CompatibilityKey)));
    }

    private static void AddRateLimits(IServiceCollection services, BackendRateLimitOptions rateLimits)
    {
        services.AddRateLimiter(options =>
        {
            options.RejectionStatusCode = StatusCodes.Status429TooManyRequests;
            AddRatePolicy(options, "api", rateLimits.Api);
            AddRatePolicy(options, "auth", rateLimits.Auth);
        });
    }

    private static void AddRatePolicy(RateLimiterOptions options, string name, FixedWindowPolicy policy)
    {
        options.AddPolicy(name, context => RateLimitPartition.GetFixedWindowLimiter(
            context.Connection.RemoteIpAddress?.ToString() ?? "unknown",
            _ => new FixedWindowRateLimiterOptions
            {
                PermitLimit = policy.PermitLimit,
                Window = policy.Window,
                QueueLimit = 0
            }));
    }
}
