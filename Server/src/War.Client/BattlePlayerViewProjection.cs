using System;
using System.Collections.Generic;
using System.Linq;
using War.Protocol;
using War.Shared;

namespace War.Client
{
    /// <summary>Validates Backend-owned recovered player views before Unity can construct scene objects.</summary>
    public static class BattlePlayerViewProjection
    {
        public static IReadOnlyList<BattlePlayerView> Validate(MatchConnectionGrant grant)
        {
            if(grant==null || grant.PlayerViews.Count!=2 ||
               grant.PlayerViews.Select(x=>x.PlayerId).Distinct(StringComparer.Ordinal).Count()!=2 ||
               !grant.PlayerViews.Any(x=>x.PlayerId==grant.PlayerId))
                throw new ArgumentException("Match grant requires two distinct roster player views including its owner.");
            var result=new List<BattlePlayerView>(2);
            foreach(var view in grant.PlayerViews)
            {
                if(view.Fraction<1 || view.Fraction>2 || view.DefendPosition<0 || view.DefendPosition>1)
                    throw new ArgumentException("Match grant contains invalid player placement.");
                BattlePlayerPresentation.Validate(new BattlePlayerPresentation(view.PlayerId,view.DisplayName,view.Level,
                    view.ArmyPower,view.Skill,view.LeagueMedals,view.BeginnersLeague,view.LeagueId,view.Country,view.IsVip,
                    view.VisualIds.ToArray(),view.Weapons.Select(x=>new BattleWeaponPresentation(x.Slot,x.WeaponIndex,x.SourceId,x.UpgradeIndex)).ToArray(),
                    view.Units.Select(x=>new BattleUnitPresentation(x.SourceId,x.UpgradeIndex,x.SpecialIndex,x.EliteIndex,x.Tier)).ToArray()));
                result.Add(view.Clone());
            }
            if(result[0].Fraction==result[1].Fraction)
                throw new ArgumentException("Match grant player views must use opposing factions.");
            return result.AsReadOnly();
        }
    }
}
