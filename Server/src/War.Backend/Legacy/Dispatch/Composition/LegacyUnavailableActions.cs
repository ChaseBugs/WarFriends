using Action = War.Backend.Legacy.DatabaseAction;
using Entry = War.Backend.Legacy.Dispatch.LegacyActionRegistration;
using Feature = War.Backend.Legacy.Dispatch.LegacyActionFeature;

namespace War.Backend.Legacy.Dispatch.Composition;

/// <summary>Explicitly closes unsupported direct actions, including buffered mutations.</summary>
internal static class LegacyUnavailableActions
{
    public static IReadOnlyList<Entry> BufferedOnly()
    {
        return
        [
            Entry.Buffered(Action.BuyWeaponUpgrade, Feature.Inventory),
            Entry.Buffered(Action.InstantWeaponUpgrade, Feature.Inventory),
            Entry.Buffered(Action.ActivateWeaponUpgrade, Feature.Inventory),
            Entry.Buffered(Action.BuyWeapon, Feature.Inventory),
            Entry.Buffered(Action.BuyUnitUpgrade, Feature.Inventory),
            Entry.Buffered(Action.InstantUnitUpgrade, Feature.Inventory),
            Entry.Buffered(Action.ActivateUnitUpgrade, Feature.Inventory),
            Entry.Buffered(Action.BuyUnit, Feature.Inventory),
            Entry.Buffered(Action.BuyCardPack, Feature.Cards),
            Entry.Buffered(Action.WeaponWasShown, Feature.Inventory),
            Entry.Buffered(Action.ArmyUnitWasShown, Feature.Inventory),
            Entry.Buffered(Action.BuyDecal, Feature.Inventory),
            Entry.Buffered(Action.EquipDecal, Feature.Inventory),
            Entry.Buffered(Action.EquipWeapon, Feature.Inventory),
            Entry.Buffered(Action.InstantBuyUnit, Feature.Inventory),
            Entry.Buffered(Action.InstantBuyWeapon, Feature.Inventory),
            Entry.Buffered(Action.ActivateUnit, Feature.Inventory),
            Entry.Buffered(Action.ActivateWeapon, Feature.Inventory),
            Entry.Buffered(Action.PromoteUnit, Feature.Inventory),
            Entry.Buffered(Action.VisualWasShown, Feature.Inventory),
            Entry.Buffered(Action.SaveLastSeenSquadChatTimeStamp, Feature.Squads),
            Entry.Buffered(Action.ConvertScrapsToParts, Feature.Economy),
            Entry.Buffered(Action.ConvertPartsToScraps, Feature.Economy),
            Entry.Buffered(Action.UpgradeEliteSlot, Feature.Inventory),
            Entry.Buffered(Action.UpdateEquippedUnits, Feature.Inventory),
        ];
    }

    public static IReadOnlyList<Entry> Closed()
    {
        return [.. ClosedCore(), .. ClosedAdditional()];
    }

    private static IReadOnlyList<Entry> ClosedCore()
    {
        return
        [
            Entry.Closed(Action.MessageSent),
            Entry.Closed(Action.AcceptChallenge),
            Entry.Closed(Action.GetAllPlayers),
            Entry.Closed(Action.IgnoreMessage),
            Entry.Closed(Action.GetFriendsInfo),
            Entry.Closed(Action.UniqueSquadNameFailure),
            Entry.Closed(Action.UniqueSquadNameSuccess),
            Entry.Closed(Action.RemoveUserFromSquad),
            Entry.Closed(Action.AddFacebook),
            Entry.Closed(Action.SwitchToFacebook),
            Entry.Closed(Action.FacebookLoginOk),
            Entry.Closed(Action.UserAddedToSquadSuccess),
            Entry.Closed(Action.GameStartedCampaign),
            Entry.Closed(Action.GameStartedCoopMaster),
            Entry.Closed(Action.GameStartedCoopClient),
            Entry.Closed(Action.AddToHitList),
            Entry.Closed(Action.GetPlayersFromHitList),
            Entry.Closed(Action.ExpandHitList),
            Entry.Closed(Action.HitListPlayerLoggedIn),
            Entry.Closed(Action.ProvokePlayer),
            Entry.Closed(Action.SearchPlayers),
            Entry.Closed(Action.SystemMessage),
            Entry.Closed(Action.ClaimReward),
            Entry.Closed(Action.DebugAddLevel),
            Entry.Closed(Action.GetSquadsByExperience),
            Entry.Closed(Action.GetPlayerLeaguesDivision),
            Entry.Closed(Action.GetPlayersByExperience),
            Entry.Closed(Action.DecalWasShown),
            Entry.Closed(Action.GetMissionLeaderboards),
            Entry.Closed(Action.SkipAssignment),
            Entry.Closed(Action.JoinSquadEvent),
            Entry.Closed(Action.BuyVip),
            Entry.Closed(Action.ChangeNameAndPassword),
            Entry.Closed(Action.CreateFullAccount),
            Entry.Closed(Action.GetSquadWarsDivision),
            Entry.Closed(Action.BuyPack),
            Entry.Closed(Action.DebugAddSquadLevel),
            Entry.Closed(Action.GenerateSpecialOffer),
            Entry.Closed(Action.AcceptSpecialOffer),
            Entry.Closed(Action.AcceptRentalOffer),
            Entry.Closed(Action.BuyInApp),
            Entry.Closed(Action.AddDebugGoodies),
        ];
    }

    private static IReadOnlyList<Entry> ClosedAdditional()
    {
        return
        [
            Entry.Closed(Action.SendPlayerReport),
            Entry.Closed(Action.GetLastWeeksPlayerLeague),
            Entry.Closed(Action.AddGameCenter),
            Entry.Closed(Action.AddVideoReward),
            Entry.Closed(Action.DebugChangeLevel),
            Entry.Closed(Action.InformSquadLeaderAboutEvent),
            Entry.Closed(Action.AddOneTimeReward),
            Entry.Closed(Action.DebugChangeMedals),
            Entry.Closed(Action.RemoveFacebook),
            Entry.Closed(Action.ClaimAssignment),
            Entry.Closed(Action.ClaimAssignmentMegaReward),
            Entry.Closed(Action.ReadMessage),
            Entry.Closed(Action.CompleteStarterAssignments),
            Entry.Closed(Action.ClaimStarterAssignment),
            Entry.Closed(Action.AddGooglePlay),
            Entry.Closed(Action.RemoveGooglePlay),
            Entry.Closed(Action.RestorePacks),
            Entry.Closed(Action.BuyLootboxes),
            Entry.Closed(Action.MessageWasShown),
            Entry.Closed(Action.FinishPlayerLeague),
            Entry.Closed(Action.InstantBattle),
            Entry.Closed(Action.EnterArena),
            Entry.Closed(Action.BuyArenaHearth),
            Entry.Closed(Action.TakeArenaLife),
            Entry.Closed(Action.GetScrapsReward),
            Entry.Closed(Action.DebugChangeArenaLives),
            Entry.Closed(Action.DebugChangeArenaWins),
            Entry.Closed(Action.GetArenaLeaderboards),
            Entry.Closed(Action.DebugAddScraps),
            Entry.Closed(Action.WarArenaEnded),
            Entry.Closed(Action.MaxAll),
            Entry.Closed(Action.DebugRenewRental),
            Entry.Closed(Action.RemoveOrUpdateGC),
            Entry.Closed(Action.RemoveFromLeague),
            Entry.Closed(Action.ExistGCAccount),
            Entry.Closed(Action.ExistFBAccount),
            Entry.Closed(Action.DebugChangeLeague),
            Entry.Closed(Action.DebugChangeDivision),
            Entry.Closed(Action.DebugChangeAnticheat),
            Entry.Closed(Action.RefundPack),
        ];
    }
}
