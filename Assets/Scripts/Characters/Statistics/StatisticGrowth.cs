using UnityEngine;
using System;
using Characters;

namespace Characters.Statistics
{
    [Serializable]
    public class StatisticGrowth
    {
        public float VitalityMultiplier { get; set; } = 1.1f;
        public float EnduranceMultiplier { get; set; } = 1.1f;
        public float StrengthMultiplier { get; set; } = 1.1f;
        public float DexterityMultiplier { get; set; } = 1.1f;
        public float ConstitutionMultiplier { get; set; } = 1.1f;
        public float IntelligenceMultiplier { get; set; } = 1.1f;
        public float WisdomMultiplier { get; set; } = 1.1f;
        public float CharismaMultiplier { get; set; } = 1.1f;

        public static StatisticGrowth GetGrowthForType(CharacterType type)
        {
            switch (type)
            {
                case CharacterType.MeleeDamage:
                    return new StatisticGrowth
                    {
                        VitalityMultiplier = 1.1f,
                        EnduranceMultiplier = 1.15f,
                        StrengthMultiplier = 1.25f,
                        DexterityMultiplier = 1.05f,
                        ConstitutionMultiplier = 1.15f,
                        IntelligenceMultiplier = 1.05f,
                        WisdomMultiplier = 1.1f,
                        CharismaMultiplier = 1.1f,
                    };
                case CharacterType.RangedDamage:
                    return new StatisticGrowth
                    {
                        VitalityMultiplier = 1.1f,
                        EnduranceMultiplier = 1.15f,
                        StrengthMultiplier = 1.25f,
                        DexterityMultiplier = 1.15f,
                        ConstitutionMultiplier = 1.05f,
                        IntelligenceMultiplier = 1.05f,
                        WisdomMultiplier = 1.1f,
                        CharismaMultiplier = 1.1f,
                    };
                case CharacterType.FastAttacker:
                    return new StatisticGrowth
                    {
                        VitalityMultiplier = 1.05f,
                        EnduranceMultiplier = 1.15f,
                        StrengthMultiplier = 1.1f,
                        DexterityMultiplier = 1.25f,
                        ConstitutionMultiplier = 1.05f,
                        IntelligenceMultiplier = 1.1f,
                        WisdomMultiplier = 1.1f,
                        CharismaMultiplier = 1.15f,
                    };
                case CharacterType.Healer:
                    return new StatisticGrowth
                    {
                        VitalityMultiplier = 1.05f,
                        EnduranceMultiplier = 1.1f,
                        StrengthMultiplier = 1.25f,
                        ConstitutionMultiplier = 1.05f,
                        DexterityMultiplier = 1.15f,
                        CharismaMultiplier = 1.15f,
                        IntelligenceMultiplier = 1.1f,
                        WisdomMultiplier = 1.1f,
                    };
                case CharacterType.Tank:
                    return new StatisticGrowth
                    {
                        VitalityMultiplier = 1.15f,
                        EnduranceMultiplier = 1.05f,
                        StrengthMultiplier = 1.1f,
                        ConstitutionMultiplier = 1.25f,
                        DexterityMultiplier = 1.05f,
                        CharismaMultiplier = 1.1f,
                        IntelligenceMultiplier = 1.15f,
                        WisdomMultiplier = 1.1f,
                    };
                default:
                    return new StatisticGrowth();
            }
        }
    }
}