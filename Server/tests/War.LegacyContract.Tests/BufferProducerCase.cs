using War.Backend.Legacy;

namespace War.LegacyContract.Tests;

internal sealed record BufferProducerCase(BufferedRequest Request, DatabaseResult Expected);
