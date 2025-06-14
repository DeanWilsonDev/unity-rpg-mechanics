using System;

using Unity.VisualScripting;

using UnityEngine;

namespace RPGMechanics.Characters.Statistics
{
    [Serializable]
    public class StatisticGenerator
    {
        public static CharacterStatistics GetStatisticsForLevel(int level, CharacterType type)
        {
            
            
            
            var baseStatistics = CharacterStatistics.GetBaseStatisticsForCharacterType(type);
            return baseStatistics; 
            var growth = StatisticGrowth.GetGrowthForType(type);

            return new CharacterStatistics
            {
                Level = level,
                MaxLevel = 100, // Find a better max level
                CurrentExperience = 0,
                ExperienceToNextLevel = 1000, // TODO: some equation
                MaxHealth = 100,
                CurrentHealth = ApplyModifier(baseStatistics.MaxHealth,
                    growth.VitalityMultiplier,
                    level),
                Endurance = ApplyModifier(baseStatistics.Endurance,
                    growth.EnduranceMultiplier,
                    level),
                CurrentStamina = ApplyModifier(baseStatistics.Endurance,
                    growth.EnduranceMultiplier,
                    level),
                CarryWeight = 100,
                Strength = ApplyModifier(baseStatistics.Strength,
                    growth.StrengthMultiplier,
                    level),
                Dexterity = ApplyModifier(baseStatistics.Dexterity,
                    growth.DexterityMultiplier,
                    level),
                Constitution = ApplyModifier(baseStatistics.Constitution,
                    growth.ConstitutionMultiplier,
                    level),
                Intelligence = ApplyModifier(baseStatistics.Intelligence,
                    growth.IntelligenceMultiplier,
                    level),
                Wisdom = ApplyModifier(baseStatistics.Wisdom,
                    growth.WisdomMultiplier,
                    level),
                Charisma = ApplyModifier(baseStatistics.Charisma,
                    growth.CharismaMultiplier,
                    level)
            };
        }

        private static int ApplyModifier(int statistic, float modifier, int level)
        {
            return Mathf.RoundToInt(statistic * Mathf.Pow(modifier, level - 1));
        }

        private static float ApplyModifier(float statistic, float modifier, int level)
        {
            return statistic * Mathf.Pow(modifier, level - 1);
        }
    }
}