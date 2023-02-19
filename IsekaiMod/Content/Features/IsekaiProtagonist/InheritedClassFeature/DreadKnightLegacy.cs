﻿using IsekaiMod.Content.Classes.IsekaiProtagonist;
using IsekaiMod.Content.Features.IsekaiProtagonist.Archetypes.EdgeLord;
using IsekaiMod.Content.Features.IsekaiProtagonist.Archetypes.Villain;
using IsekaiMod.Utilities;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Prerequisites;
using Kingmaker.Blueprints.Classes.Selection;
using TabletopTweaks.Core.Utilities;
using static IsekaiMod.Main;

namespace IsekaiMod.Content.Features.IsekaiProtagonist.InheritedClassFeature {
    internal class DreadKnightLegacy {
        private static BlueprintFeature sinfulabsolution = BlueprintTools.GetBlueprint<BlueprintFeature>("5bdcb8eaee8c42c988731fc23e075f73");
        private static BlueprintFeature sinfulabsolution2 = BlueprintTools.GetBlueprint<BlueprintFeature>("c0f985c802504593af9c96c0636c7692");
        private static BlueprintFeature auraofAbsolution = BlueprintTools.GetBlueprint<BlueprintFeature>("cddb5febac6848e3919d8775628e8cc8");
        private static BlueprintFeatureSelection crueltySelection = BlueprintTools.GetBlueprint<BlueprintFeatureSelection>("402fccae3c2147e78da4ff9f6f061461");
        //private static BlueprintFeatureSelection crueltySelection2 = BlueprintTools.GetBlueprint<BlueprintFeatureSelection>("f5334c9f58ae4aa0be821613dd1ef6d2");
        //private static BlueprintFeatureSelection crueltySelection3 = BlueprintTools.GetBlueprint<BlueprintFeatureSelection>("8a1f32662b4241feada7a4ba604e996e");
        //private static BlueprintFeatureSelection crueltySelection4 = BlueprintTools.GetBlueprint<BlueprintFeatureSelection>("eae1f9f3226f49a4aaea7cbc7b286007");

        private static BlueprintProgression prog;


        public static void Configure() {
            //only add this stereotype if the Dread Knight Class has been added
            if (!ModSupport.IsExpandedContentEnabled()
                || sinfulabsolution == null
                || crueltySelection == null) return;

            prog = Helpers.CreateBlueprint<BlueprintProgression>(IsekaiContext, "DreadKnightLegacy", bp => {
                bp.SetName(IsekaiContext, "Dread Knight Legacy - Dread Lord");
                bp.SetDescription(IsekaiContext, "*Blinks and slowly backs away*, Uhm are you certain you want to play this? I mean Dread Knights are kind of evil, you know? \n As in the they are the opposite of anything a paladin represents...");
                bp.GiveFeaturesForPreviousLevels = true;
                bp.IsClassFeature = true;
                bp.m_Classes = new BlueprintProgression.ClassWithLevel[] {
                    new BlueprintProgression.ClassWithLevel {
                        m_Class = IsekaiProtagonistClass.GetReference(),
                        AdditionalLevel = 0
                    }
                };
                bp.AddComponent<PrerequisiteAlignment>(c => { c.Alignment = Kingmaker.UnitLogic.Alignments.AlignmentMaskType.Evil; });
                bp.LevelEntries = new LevelEntry[] {
                    Helpers.CreateLevelEntry(1, sinfulabsolution),
                    //Helpers.CreateLevelEntry(3, crueltySelection),
                    Helpers.CreateLevelEntry(4, sinfulabsolution2),
                    //Helpers.CreateLevelEntry(6, crueltySelection2),
                    Helpers.CreateLevelEntry(7, sinfulabsolution2),
                    //Helpers.CreateLevelEntry(9, crueltySelection3),
                    Helpers.CreateLevelEntry(10, sinfulabsolution2),
                    Helpers.CreateLevelEntry(11, auraofAbsolution),
                    //Helpers.CreateLevelEntry(12, crueltySelection4),
                    Helpers.CreateLevelEntry(13, sinfulabsolution2),
                    //Helpers.CreateLevelEntry(15, crueltySelection4),
                    Helpers.CreateLevelEntry(16, sinfulabsolution2),
                    //Helpers.CreateLevelEntry(18, crueltySelection4),
                    Helpers.CreateLevelEntry(19, sinfulabsolution2),

            };
                bp.UIGroups = new UIGroup[] {
                    Helpers.CreateUIGroup(sinfulabsolution,sinfulabsolution2,auraofAbsolution/*,crueltySelection,crueltySelection2,crueltySelection3,crueltySelection4*/),
                };

            });
            LegacySelection.GetClassFeature().AddFeatures(prog);
            LegacySelection.GetOverwhelmingFeature().AddFeatures(prog);
            VillainLegacySelection.getClassFeature().AddFeatures(prog);
            EdgeLordLegacySelection.getClassFeature().AddFeatures(prog);
        }

        public static BlueprintProgression Get() {
            if (prog != null) return prog;
            return BlueprintTools.GetModBlueprint<BlueprintProgression>(IsekaiContext, "DreadKnightLegacy");
        }
    }
}
