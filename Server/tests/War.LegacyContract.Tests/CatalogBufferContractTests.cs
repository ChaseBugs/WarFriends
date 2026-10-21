using Microsoft.Extensions.Logging.Abstractions;
using Newtonsoft.Json.Linq;
using War.Backend.Legacy;
using War.Backend.Legacy.Buffering;
using War.Persistence.Legacy.Buffers;

namespace War.LegacyContract.Tests;

internal static class CatalogBufferContractTests
{
    internal static int Run(JObject matrix, IEnumerable<CatalogBufferScenario>? cases = null)
    {
        int scenarios = 0;
        var names = new HashSet<string>(StringComparer.Ordinal);
        foreach (CatalogBufferScenario scenario in cases ?? CatalogBufferScenarios.All())
        {
            Require(names.Add(scenario.Name), "Duplicate producer scenario identity: " + scenario.Name);
            try
            {
                RunScenario(scenario, matrix);
                scenarios++;
            }
            catch (Exception error)
            {
                throw new InvalidOperationException("Catalog producer scenario failed: " + scenario.Name, error);
            }
        }

        return scenarios;
    }

    private static void RunScenario(CatalogBufferScenario scenario, JObject matrix)
    {
        var fixture = new CatalogBufferFixture();
        scenario.Arrange?.Invoke(fixture);
        fixture.Prepare();
        string before = PlayerState.Write(fixture.Player);
        var planner = new LegacyBufferPlanner(fixture.Catalog, LegacyBufferProcessor.SupportedActions,
            NullLogger.Instance);

        LegacyBufferedMutation mutation = planner.Plan(fixture.Player, scenario.Request,
            CatalogBufferFixture.Now, CatalogBufferFixture.RandomSeed);
        Require(mutation.Result == (int)scenario.Expected, $"Expected {scenario.Expected}, got {mutation.Result}.");
        Require(PlayerState.Write(fixture.Player) == before, "Pure planning changed its input snapshot.");
        CheckFailureHasNoMutation(fixture, mutation);
        fixture.CheckMutation?.Invoke(mutation);
        fixture.Commit(mutation);

        var receipt = new LegacyBufferedActionResult(fixture.Player, mutation.ResponseJson, mutation.Delivery);
        CheckProjection(receipt, scenario.Request, matrix);
        fixture.ChangeCurrentAuthority(scenario.Request);
        CheckProjection(receipt, scenario.Request, matrix);
        Require(receipt.ResponseJson == mutation.ResponseJson, "Replay replaced canonical response evidence.");
        BufferProducerCoverage.Record(scenario.Request, mutation, hasCheckedAuthority: true);
    }

    private static void CheckFailureHasNoMutation(CatalogBufferFixture fixture, LegacyBufferedMutation mutation)
    {
        if (mutation.Result == (int)DatabaseResult.Success)
        {
            return;
        }

        Require(mutation.Serialized.Count == 0 && mutation.Gold == fixture.Player.Gold &&
            mutation.WarBucks == fixture.Player.WarBucks && mutation.Scraps == fixture.Player.Scraps &&
            mutation.ArmyPower == fixture.Player.ArmyPower, "Failure planned an account mutation.");
    }

    private static void CheckProjection(LegacyBufferedActionResult receipt, BufferedRequest request, JObject matrix)
    {
        string json = LegacyBufferedResponse.Project(receipt, CatalogBufferFixture.Now + 10, request).ToJsonString();
        JObject response = JObject.Parse(json);
        Require((int?)response["ActionId"] == (int)request.Action &&
            (int?)response["Result"] == (int?)JObject.Parse(receipt.ResponseJson!)["Result"],
            "Projection changed the action or committed result.");
        BufferContractMatrixTests.Read(response, true);
        BufferRollbackAuthorityChecks.Verify(response, receipt.Player, matrix, request);
        BufferDeliveryAuthorityChecks.Verify(response, receipt, CatalogBufferFixture.Now + 10);
    }

    private static void Require(bool condition, string message)
    {
        if (!condition)
        {
            throw new InvalidOperationException(message);
        }
    }
}
