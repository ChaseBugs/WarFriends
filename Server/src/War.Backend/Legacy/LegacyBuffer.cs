using System.Text.Json;
using System.Text.Json.Nodes;
using MongoDB.Driver;
using War.Persistence;

namespace War.Backend.Legacy;

/// <summary>One entry of the client's <c>Dictionary&lt;int, Request&gt;</c>.</summary>
/// <param name="Index">The dictionary key, which is the order the client queued the request in.</param>
/// <param name="Action">The <c>Request.action</c> field.</param>
/// <param name="Data">The <c>Request.data</c> field: either a bare string or a JSON document,
/// depending on the action. It is always transported as a JSON string.</param>
public sealed record BufferedRequest(int Index, DatabaseAction Action, string? Data);

/// <summary>A parsed buffer: the client's id for it and its requests in index order.</summary>
public sealed record ParsedBuffer(string BufferId, IReadOnlyList<BufferedRequest> Requests);

/// <summary>
/// Parses the two places buffered requests arrive: the <c>Requests</c> field of
/// <see cref="DatabaseAction.SendRequestBuffer"/>, and the <c>Buffers</c> field that
/// <see cref="DatabaseAction.GetPlayerData"/> carries for every buffer the client has not yet had
/// acknowledged.
/// </summary>
public static class LegacyBufferParser
{
    /// <summary>
    /// Guards against a client sending an unbounded buffer. The client's own buffers are formed
    /// from UI actions over a few seconds, so a legitimate one is small.
    /// </summary>
    public const int MaxRequestsPerBuffer = 256;

    /// <summary>Guards against an unbounded number of buffers replayed in one GetPlayerData.</summary>
    public const int MaxBuffers = 64;

    /// <summary>
    /// Parses <c>JsonConvert.SerializeObject(Dictionary&lt;int, Request&gt;)</c>, which is a JSON
    /// object whose keys are the integer indices: <c>{"0":{"action":104,"data":"M4A1"}}</c>.
    /// Returns requests sorted by index, which is the order the player performed them in.
    /// </summary>
    public static IReadOnlyList<BufferedRequest> ParseRequests(string? json)
    {
        var requests = new List<BufferedRequest>();
        if (string.IsNullOrEmpty(json)) return requests;
        if (JsonNode.Parse(json) is not JsonObject root) return requests;
        foreach (var (key, value) in root)
        {
            if (!int.TryParse(key, out int index) || value is not JsonObject entry) continue;
            // Newtonsoft writes the DatabaseAction enum as its integer by default.
            if (entry["action"]?.GetValue<int>() is not int actionId) continue;
            if (!Enum.IsDefined(typeof(DatabaseAction), actionId)) continue;
            requests.Add(new BufferedRequest(index, (DatabaseAction)actionId, entry["data"]?.GetValue<string>()));
            if (requests.Count > MaxRequestsPerBuffer) break;
        }
        requests.Sort((a, b) => a.Index.CompareTo(b.Index));
        return requests;
    }

    /// <summary>
    /// Parses <c>RequestBufferManager.GetJsonData()</c>, a JSON object of buffer id to serialized
    /// <c>RequestBuffer</c>. Only <c>requests</c> is needed; <c>alreadySent</c> is the client's own
    /// local bookkeeping and carries no authority here.
    /// </summary>
    public static IReadOnlyList<ParsedBuffer> ParseBuffers(string? json)
    {
        var buffers = new List<ParsedBuffer>();
        if (string.IsNullOrEmpty(json)) return buffers;
        if (JsonNode.Parse(json) is not JsonObject root) return buffers;
        foreach (var (bufferId, value) in root)
        {
            if (value is not JsonObject buffer || bufferId.Length is 0 or > 128) continue;
            var requests = ParseRequests(buffer["requests"]?.ToJsonString());
            if (requests.Count > 0) buffers.Add(new ParsedBuffer(bufferId, requests));
            if (buffers.Count >= MaxBuffers) break;
        }
        return buffers;
    }
}

/// <summary>
/// Applies buffered requests to a player, at most once each, and builds the results array the
/// client's <c>ProcessBuffer</c> consumes.
/// </summary>
/// <remarks>
/// <para><b>Result encoding.</b> Unlike <c>Player</c>/<c>PlayerData</c>, entries here are plain
/// JSON, not DynamoDB AttributeValues: <c>ProcessBuffer</c> reads them with <c>ParseIntToken</c>,
/// <c>ParseLongToken</c> and the single-argument <c>ParseString</c>. Nested blobs are JSON
/// documents escaped inside a string, because <c>LevelManager.UpdateWeapon</c> casts the token to
/// <c>string</c> before deserializing it.</para>
/// <para><b>On success the client needs only <c>ActionId</c> and <c>Result</c>.</b> Every other
/// field it reads on a success branch is null-guarded. The rollback fields are read on the failure
/// branches, so a failure result must carry the authoritative state the client should revert to.</para>
/// <para><b>Implemented actions are those whose effect is fully determined by the request and the
/// stored player state.</b> The economy actions additionally need the price/reward catalog from the
/// client's Google2u sheets; until that is imported, they return a failure rather than a fabricated
/// success, because a success the server did not actually apply would desynchronise the client's
/// wallet from the authoritative balance.</para>
/// </remarks>
public sealed class LegacyBufferProcessor(LegacyPlayerStore players, LegacyBufferStore buffers, ILogger<LegacyBufferProcessor> logger)
{
    /// <summary>
    /// Actions this server applies. Everything else in the client's 27-action buffered set is
    /// economy or cosmetic-catalog work that needs sheet data the server does not have yet.
    /// </summary>
    private static readonly HashSet<DatabaseAction> Implemented =
    [
        DatabaseAction.WeaponWasShown,
        DatabaseAction.ArmyUnitWasShown,
        DatabaseAction.VisualWasShown,
        DatabaseAction.EquipWeapon,
        DatabaseAction.UpdateEquippedUnits
    ];

    /// <summary>
    /// Applies every request of one buffer in index order and returns the results array.
    /// </summary>
    public async Task<JsonArray> Apply(LegacyPlayerDocument player, ParsedBuffer buffer, CancellationToken ct)
    {
        var receipt = await buffers.Find(player.Id, buffer.BufferId, ct);
        var results = new JsonArray();
        var state = new WorkingState(player);

        foreach (var request in buffer.Requests)
        {
            var recorded = receipt?.Entries.FirstOrDefault(e => e.Index == request.Index);
            if (recorded is { Result: not null })
            {
                // Already applied on an earlier delivery of this buffer. Replay the same answer.
                results.Add(Result(request.Action, (DatabaseResult)recorded.Result.Value));
                continue;
            }

            if (!await buffers.TryClaim(player.Id, buffer.BufferId, request.Index, (int)request.Action, ct))
            {
                // Claimed but never completed: a previous attempt stopped between applying the
                // effect and recording it, so whether it landed is unknown. Re-applying could
                // double it, so report a failure and let the player retry deliberately.
                logger.LogWarning("Buffer {BufferId} request {Index} for player {PlayerId} was claimed but not completed; not re-applying.", buffer.BufferId, request.Index, player.Id);
                results.Add(Result(request.Action, DatabaseResult.ServerRespondedWithError));
                continue;
            }

            var outcome = Execute(request, state);
            await state.Flush(players, ct);
            await buffers.Complete(player.Id, buffer.BufferId, request.Index, (int)outcome.Code, ct);
            results.Add(outcome.Node);
        }
        return results;
    }

    private (DatabaseResult Code, JsonObject Node) Execute(BufferedRequest request, WorkingState state)
    {
        if (!Implemented.Contains(request.Action))
        {
            logger.LogInformation("Buffered action {Action} needs catalog data the server does not have; reporting failure rather than a hollow success.", request.Action);
            return (DatabaseResult.ServerMaintenance, Result(request.Action, DatabaseResult.ServerMaintenance));
        }
        try
        {
            return request.Action switch
            {
                DatabaseAction.WeaponWasShown => WeaponWasShown(request, state),
                DatabaseAction.ArmyUnitWasShown => ArmyUnitWasShown(request, state),
                DatabaseAction.VisualWasShown => VisualWasShown(request, state),
                DatabaseAction.EquipWeapon => EquipWeapon(request, state),
                DatabaseAction.UpdateEquippedUnits => UpdateEquippedUnits(request, state),
                _ => (DatabaseResult.ServerMaintenance, Result(request.Action, DatabaseResult.ServerMaintenance))
            };
        }
        catch (JsonException e)
        {
            logger.LogWarning("Buffered action {Action} carried unparsable data: {Error}", request.Action, e.GetType().Name);
            return (DatabaseResult.JsonFailure, Result(request.Action, DatabaseResult.JsonFailure));
        }
    }

    // The client sets savedWeapons[name].showed locally at WeaponScreen.cs:530; mirror it.
    private static (DatabaseResult, JsonObject) WeaponWasShown(BufferedRequest request, WorkingState state)
    {
        if (string.IsNullOrEmpty(request.Data)) return Fail(request, DatabaseResult.WrongPlayerData);
        Slot(state.Levels.SavedWeapons, request.Data).Showed = true;
        state.LevelsChanged();
        return Ok(request);
    }

    // The client sets savedArmies[name].showed locally at ArmyScreen.cs:398; mirror it.
    private static (DatabaseResult, JsonObject) ArmyUnitWasShown(BufferedRequest request, WorkingState state)
    {
        if (string.IsNullOrEmpty(request.Data)) return Fail(request, DatabaseResult.WrongPlayerData);
        Slot(state.Levels.SavedArmies, request.Data).Showed = true;
        state.LevelsChanged();
        return Ok(request);
    }

    // CamosScreen.WasShown clears notificate only; it does not touch showed. Mirror exactly.
    private static (DatabaseResult, JsonObject) VisualWasShown(BufferedRequest request, WorkingState state)
    {
        if (string.IsNullOrEmpty(request.Data)) return Fail(request, DatabaseResult.WrongPlayerData);
        Slot(state.Decals.Visuals, request.Data).Notificate = false;
        state.DecalsChanged();
        return Ok(request);
    }

    /// <summary>
    /// Moves a weapon into an inventory slot. The server checks ownership, which is why the client
    /// has a <see cref="DatabaseResult.WeaponNotBought"/> branch for this action carrying the state
    /// to revert to.
    /// </summary>
    private static (DatabaseResult, JsonObject) EquipWeapon(BufferedRequest request, WorkingState state)
    {
        var payload = JsonNode.Parse(request.Data ?? "") as JsonObject;
        string? name = payload?["Name"]?.GetValue<string>();
        if (payload == null || string.IsNullOrEmpty(name)) return Fail(request, DatabaseResult.WrongPlayerData);
        if (!int.TryParse(payload["SlotIndex"]?.ToString(), out int slotIndex) || slotIndex is < 0 or > 32) return Fail(request, DatabaseResult.WrongPlayerData);
        int.TryParse(payload["Index"]?.ToString(), out int weaponIndex);

        if (!state.Levels.SavedWeapons.TryGetValue(name, out var weapon) || !(weapon.Bought || weapon.Borrowed))
        {
            // Hand back the authoritative weapon and inventory so the client reverts its slot.
            var rollback = Result(request.Action, DatabaseResult.WeaponNotBought);
            rollback["LevelName"] = name;
            rollback["Weapon"] = PlayerState.Write(weapon ?? new SavedWeaponSlots());
            rollback["InventoryData"] = PlayerState.Write(state.Inventory);
            return (DatabaseResult.WeaponNotBought, rollback);
        }

        state.Inventory.Slots[slotIndex] = new SerializedSlotDetail { Name = name, WeaponIndex = weaponIndex };
        state.InventoryChanged();
        state.RecordClientArmyPower(payload["ArmyPower"]);
        return Ok(request);
    }

    /// <summary>
    /// Replaces the equipped/was-equipped flags across the army. The client sends only the units
    /// that carry a flag, so units it omits must have theirs cleared.
    /// </summary>
    private static (DatabaseResult, JsonObject) UpdateEquippedUnits(BufferedRequest request, WorkingState state)
    {
        var payload = JsonNode.Parse(request.Data ?? "") as JsonObject;
        if (payload?["equips"] is not JsonObject equips) return Fail(request, DatabaseResult.WrongPlayerData);

        // Reject the whole request if any named unit is not owned, and hand back the stored army so
        // the client can revert — this is the CantEquipUnit branch of its ProcessBuffer.
        foreach (var (unitName, _) in equips)
        {
            if (!state.Levels.SavedArmies.TryGetValue(unitName, out var unit) || !(unit.Bought || unit.Borrowed))
            {
                var stored = new JsonObject();
                foreach (var (name, slots) in state.Levels.SavedArmies) stored[name] = PlayerState.Write(slots);
                var rollback = Result(request.Action, DatabaseResult.CantEquipUnit);
                rollback["data"] = stored.ToJsonString();
                return (DatabaseResult.CantEquipUnit, rollback);
            }
        }

        foreach (var (_, slots) in state.Levels.SavedArmies)
        {
            slots.Equipped = false;
            slots.WasEquipped = false;
        }
        foreach (var (unitName, flags) in equips)
        {
            var slots = state.Levels.SavedArmies[unitName];
            slots.Equipped = flags?["equipped"]?.GetValue<bool>() ?? false;
            slots.WasEquipped = flags?["wasEquipped"]?.GetValue<bool>() ?? false;
        }
        state.LevelsChanged();
        state.RecordClientArmyPower(payload["armyPower"]);
        return Ok(request);
    }

    private static TSlot Slot<TSlot>(Dictionary<string, TSlot> map, string key) where TSlot : new()
    {
        if (!map.TryGetValue(key, out var slot)) map[key] = slot = new TSlot();
        return slot;
    }

    private static (DatabaseResult, JsonObject) Ok(BufferedRequest request) =>
        (DatabaseResult.Success, Result(request.Action, DatabaseResult.Success));

    private static (DatabaseResult, JsonObject) Fail(BufferedRequest request, DatabaseResult code) =>
        (code, Result(request.Action, code));

    private static JsonObject Result(DatabaseAction action, DatabaseResult result) =>
        new() { ["ActionId"] = (int)action, ["Result"] = (int)result };

    /// <summary>
    /// The player's blobs decoded once per buffer, with only the changed ones written back.
    /// </summary>
    private sealed class WorkingState(LegacyPlayerDocument document)
    {
        private LevelManagerData? levels;
        private InventoryData? inventory;
        private DecalManagerData? decals;
        private readonly HashSet<string> dirty = [];
        private int? clientArmyPower;

        public LevelManagerData Levels => levels ??= PlayerState.Read<LevelManagerData>(Blob("LevelManagerData"));
        public InventoryData Inventory => inventory ??= PlayerState.Read<InventoryData>(Blob("InventoryData"));
        public DecalManagerData Decals => decals ??= PlayerState.Read<DecalManagerData>(Blob("DecalManagerData"));

        public void LevelsChanged() => dirty.Add("LevelManagerData");
        public void InventoryChanged() => dirty.Add("InventoryData");
        public void DecalsChanged() => dirty.Add("DecalManagerData");

        /// <summary>
        /// Notes the army power the client asserted. It is stored for display and matchmaking
        /// continuity but is <b>not</b> authoritative: recomputing it needs the unit/weapon power
        /// values from the Google2u catalog. Until that lands, a client could understate or
        /// overstate it, so nothing that grants value may depend on it.
        /// </summary>
        public void RecordClientArmyPower(JsonNode? node)
        {
            if (node != null && int.TryParse(node.ToString(), out int power) && power >= 0) clientArmyPower = power;
        }

        private string? Blob(string key) => document.Serialized.GetValueOrDefault(key);

        public async Task Flush(LegacyPlayerStore store, CancellationToken ct)
        {
            foreach (string key in dirty)
            {
                string json = key switch
                {
                    "LevelManagerData" => PlayerState.Write(Levels),
                    "InventoryData" => PlayerState.Write(Inventory),
                    "DecalManagerData" => PlayerState.Write(Decals),
                    _ => throw new InvalidOperationException($"No writer for blob '{key}'.")
                };
                document.Serialized[key] = json;
                await store.SetSerialized(document.Id, key, json, ct);
            }
            dirty.Clear();
            if (clientArmyPower is int power && power != document.ArmyPower)
            {
                document.ArmyPower = power;
                await store.Update(document.Id, Builders<LegacyPlayerDocument>.Update.Set(x => x.ArmyPower, power), ct);
                clientArmyPower = null;
            }
        }
    }
}
