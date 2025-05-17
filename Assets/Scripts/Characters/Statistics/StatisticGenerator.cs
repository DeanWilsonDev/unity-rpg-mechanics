using System;
using UnityEngine;

namespace Characters.Statistics
{
    [Serializable]
    public class StatisticGenerator
    {
        public static CharacterStatistics GetStatisticsForLevel(int level, CharacterType type)
        {
            var baseStatistics = CharacterStatistics.GetBaseStatisticsForCharacterType(type);
            var growth = StatisticGrowth.GetGrowthForType(type);

            return new CharacterStatistics
            {
                Vitality = baseStatistics.Vitality * Mathf.Pow(growth.VitalityMultiplier, level - 1),
                Endurance = baseStatistics.Endurance * Mathf.Pow(growth.EnduranceMultiplier, level - 1),
                Strength = Mathf.RoundToInt(baseStatistics.Strength * Mathf.Pow(growth.StrengthMultiplier, level - 1)),
                Dexterity = Mathf.RoundToInt(
                    baseStatistics.Dexterity * Mathf.Pow(growth.DexterityMultiplier, level - 1)),
                Constitution = Mathf.RoundToInt(baseStatistics.Constitution *
                                                Mathf.Pow(growth.ConstitutionMultiplier, level - 1)),
                Intelligence = Mathf.RoundToInt(baseStatistics.Intelligence *
                                                Mathf.Pow(growth.IntelligenceMultiplier, level - 1)),
                Wisdom = Mathf.RoundToInt(baseStatistics.Wisdom * Mathf.Pow(growth.WisdomMultiplier, level - 1)),
                Charisma = Mathf.RoundToInt(baseStatistics.Charisma * Mathf.Pow(growth.CharismaMultiplier, level - 1)),
            };
        }
    }
}