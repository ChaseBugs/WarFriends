using War.Backend.Legacy;

namespace War.LegacyContract.Tests;

internal sealed record CatalogBufferScenario(
    string Name,
    BufferedRequest Request,
    DatabaseResult Expected,
    Action<CatalogBufferFixture>? Arrange = null);
