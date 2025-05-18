using System;
using UnityEngine;

namespace Characters.Statistics
{
    [Serializable]
    public class CharacterStatistics
    {
        [SerializeField] private int level;
        [SerializeField] private int maxLevel;
        [SerializeField] private int currentExperience;
        [SerializeField] private int experienceToNextLevel;

        [SerializeField] private float vitality;
        [SerializeField] private float currentHealth;
        [SerializeField] private float endurance;
        [SerializeField] private float currentStamina;

        [SerializeField] private int carryWeight;

        [SerializeField] private int strength;
        [SerializeField] private int dexterity;
        [SerializeField] private int constitution;
        [SerializeField] private int intelligence;
        [SerializeField] private int wisdom;
        [SerializeField] private int charisma;


        private const float BaseVitality = 100;
        private const float VitalityScaleThreshold = 5;
        private const float BaseEndurance = 50;
        private const float EnduranceScaleThreshold = 8;
        private const int BaseCarryWeight = 250;
        private const float CarryWeightScaleThreshold = 20;


        /// <summary>
        /// The Current Level of the Character.
        /// </summary>
        public int Level
        {
            get => level;
            set => level = value;
        }

        /// <summary>
        /// The max level the character can reach.
        /// </summary>
        public int MaxLevel
        {
            get => maxLevel;
            set => maxLevel = value;
        }

        /// <summary>
        /// The amount of experience the character has.
        /// </summary>
        public int CurrentExperience
        {
            get => currentExperience;
            set => currentExperience = value;
        }

        /// <summary>
        /// The required amount of experience to reach the next level.
        /// </summary>
        public int ExperienceToNextLevel
        {
            get => experienceToNextLevel;
            set => experienceToNextLevel = value;
        }

        /// <summary>
        /// Max Health
        /// The amount of maximum health a character can have.
        /// </summary>
        public float Vitality
        {
            get => vitality;
            set => vitality = BaseVitality * (1 + Mathf.Pow((value / VitalityScaleThreshold), 2));
        }

        /// <summary>
        /// Health 
        /// the current amount of health a character has.
        /// </summary>
        public float CurrentHealth
        {
            get => currentHealth;
            set => currentHealth = value;
        }

        /// <summary>
        /// Max Stamina
        /// The amount of maximum stamina a character can have.
        /// </summary>
        public float Endurance
        {
            get => endurance;
            set => endurance = BaseEndurance * (1 + Mathf.Pow((value / EnduranceScaleThreshold), 2));
        }

        /// <summary>
        /// Stamina 
        /// The current amount of stamina a character has.
        /// </summary>
        public float CurrentStamina
        {
            get => currentStamina;
            set => currentStamina = value;
        }

        /// <summary>
        /// Item Storage Capacity
        /// The amount of weight a character can carry.
        /// Scales based on Strength.
        /// </summary>
        public int CarryWeight
        {
            get => carryWeight;
            set => carryWeight =
                Mathf.RoundToInt(BaseCarryWeight * (1 + Mathf.Pow((value / CarryWeightScaleThreshold), 2)));
        }


        /// <summary>
        /// Melee Damage
        /// The amount of damage a character can deal with melee attacks.
        /// Strength also adds to the amount of weight a Character can carry
        /// </summary>
        public int Strength
        {
            get => strength;
            set => strength = value;
        }

        /// <summary>
        /// Ranged Damage
        /// The amount of damage a character can deal with ranged attacks.
        /// Dexterity also adds modifiers to the amount of Endurance gained at each level.
        /// </summary>
        public int Dexterity
        {
            get => dexterity;
            set => dexterity = value;
        }

        /// <summary>
        /// Damage Reduction
        /// Adds modifiers to damage taken and vitality gained at each level 
        /// </summary>
        public int Constitution
        {
            get => constitution;
            set => constitution = value;
        }

        /// <summary>
        /// Knowledge and Reasoning
        /// Intelligence adds modifiers for skills and abilities. (INT / 2)
        /// </summary>
        public int Intelligence
        {
            get => intelligence;
            set => intelligence = value;
        }

        /// <summary>
        /// Willpower and Perception
        /// Wisdom adds modifiers for skills and abilities.
        /// This also affects the amount of health a healer can restore.
        /// </summary>
        public int Wisdom
        {
            get => wisdom;
            set => wisdom = value;
        }


        /// <summary>
        /// Persuasion and Critical Chance
        /// Charisma adds modifiers for Critical Hits
        /// Charisma Saves in conversations
        /// </summary>
        public int Charisma
        {
            get => charisma;
            set => charisma = value;
        }


        public static CharacterStatistics GetBaseStatisticsForCharacterType(CharacterType type)
        {
            return type switch
            {
                CharacterType.MeleeDamage => new CharacterStatistics
                {
                    Level = 1,
                    Vitality = BaseVitality,
                    CurrentHealth = BaseVitality,
                    Endurance = BaseEndurance,
                    CurrentStamina = BaseEndurance,
                    CarryWeight = BaseCarryWeight,
                    Strength = 8,
                    Dexterity = 4,
                    Constitution = 6,
                    Intelligence = 3,
                    Wisdom = 1,
                    Charisma = 3,
                },
                CharacterType.RangedDamage => new CharacterStatistics
                {
                    Level = 1,
                    Vitality = BaseVitality,
                    CurrentHealth = BaseVitality,
                    Endurance = BaseEndurance,
                    CurrentStamina = BaseEndurance,
                    CarryWeight = BaseCarryWeight,
                    Strength = 4,
                    Dexterity = 8,
                    Constitution = 3,
                    Intelligence = 5,
                    Wisdom = 1,
                    Charisma = 4,
                },
                CharacterType.FastAttacker => new CharacterStatistics
                {
                    Level = 1,
                    Vitality = BaseVitality,
                    CurrentHealth = BaseVitality,
                    Endurance = BaseEndurance,
                    CurrentStamina = BaseEndurance,
                    CarryWeight = BaseCarryWeight,
                    Strength = 6,
                    Dexterity = 6,
                    Constitution = 3,
                    Intelligence = 4,
                    Wisdom = 1,
                    Charisma = 5,
                },
                CharacterType.Healer => new CharacterStatistics
                {
                    Level = 1,
                    Vitality = BaseVitality,
                    CurrentHealth = BaseVitality,
                    Endurance = BaseEndurance,
                    CurrentStamina = BaseEndurance,
                    CarryWeight = BaseCarryWeight,
                    Strength = 2,
                    Dexterity = 2,
                    Constitution = 2,
                    Intelligence = 5,
                    Wisdom = 8,
                    Charisma = 6,
                },
                CharacterType.Tank => new CharacterStatistics
                {
                    level = 1,
                    Vitality = BaseVitality,
                    CurrentHealth = BaseVitality,
                    Endurance = BaseEndurance,
                    CurrentStamina = BaseEndurance,
                    CarryWeight = BaseCarryWeight,
                    Strength = 6,
                    Dexterity = 3,
                    Constitution = 8,
                    Intelligence = 3,
                    Wisdom = 1,
                    Charisma = 4,
                },
                _ => new CharacterStatistics
                {
                    Level = 1,
                    Vitality = BaseVitality,
                    CurrentHealth = BaseVitality,
                    Endurance = BaseEndurance,
                    CurrentStamina = BaseEndurance,
                    CarryWeight = BaseCarryWeight,
                    Strength = 1,
                    Dexterity = 1,
                    Constitution = 1,
                    Intelligence = 1,
                    Wisdom = 1,
                    Charisma = 1,
                }
            };
        }
    }
}