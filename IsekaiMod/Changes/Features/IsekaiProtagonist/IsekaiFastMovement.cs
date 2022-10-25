﻿using IsekaiMod.Extensions;
using IsekaiMod.Utilities;
using Kingmaker.Blueprints.Classes;
using Kingmaker.EntitySystem.Stats;
using Kingmaker.Enums;
using Kingmaker.UnitLogic.FactLogic;

namespace IsekaiMod.Changes.Features.IsekaiProtagonist
{
    class IsekaiFastMovement
    {
        public static void Add()
        {
            var Icon_FastMovement = Resources.GetBlueprint<BlueprintFeature>("d294a5dddd0120046aae7d4eb6cbc4fc").m_Icon;
            var IsekaiFastMovement = Helpers.CreateBlueprint<BlueprintFeature>("IsekaiFastMovement", bp => {
                bp.SetName("Fast Movement");
                bp.SetDescription("At 8th level, you gain a +10 {g|Encyclopedia:Bonus}bonus{/g} to your {g|Encyclopedia:Speed}speed{/g}.");
                bp.m_Icon = Icon_FastMovement;
                bp.AddComponent<AddStatBonus>(c => {
                    c.Descriptor = ModifierDescriptor.None;
                    c.Stat = StatType.Speed;
                    c.Value = 10;
                });
                bp.IsClassFeature = true;
            });
        }
    }
}