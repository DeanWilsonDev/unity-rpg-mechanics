using RPGMechanics.Characters.Statistics;
using RPGMechanics.Weapons;

using UnityEngine;

namespace RPGMechanics.Characters
{
    public class CharacterInitializer
    {
        public CharacterStatistics Statistics { get; set; }
        public string CharacterName { get; set; }
        public CharacterType CharacterType { get; set; }
        public Health CharacterHealth { get; set; }
        public Transform WeaponSlot { get; set; }
        public Inventory.Inventory Inventory { get; set; }
        public Animator Animator { get; set; }
        public Weapon CurrentWeapon { get; set; }
    }
    
    [RequireComponent(typeof(Health))]
    public abstract class Character : MonoBehaviour, IDamagable
    {
        [SerializeField] protected internal CharacterStatistics statistics;
        [SerializeField] protected internal string characterName;

        [SerializeField] protected internal CharacterType characterType;

        // TODO: This will probably come from the Inventory somehow
        [SerializeField] protected internal Weapon CurrentWeapon;
        [field: SerializeField] public Animator Animator { get; private set; }

        public CharacterStatistics Statistics => statistics;
        public string CharacterName => characterName;
        public CharacterType CharacterType => characterType;
        [field: SerializeField] public Health CharacterHealth { get; set; }

        [field: SerializeField] protected internal Transform WeaponSlot { get; set; }

        public abstract Inventory.Inventory Inventory { get; protected set; }

        protected void Awake()
        {
            if (!Animator) { Animator = GetComponent<Animator>(); }

            if (!CharacterHealth) { CharacterHealth = GetComponent<Health>(); }
        }

        protected virtual void Start()
        {
            statistics = StatisticGenerator.GetStatisticsForLevel(1, characterType);
            CharacterHealth.Initialize(statistics);
            if (CurrentWeapon && WeaponSlot)
            {
                CurrentWeapon.transform.parent = WeaponSlot.transform;
                CurrentWeapon.transform.localPosition = WeaponSlot.transform.localPosition;
            }
        }

        public virtual Character InitializeCharacter(CharacterInitializer initializer)
        {
            this.statistics = initializer.Statistics;
            this.characterName = initializer.CharacterName;
            this.characterType = initializer.CharacterType;
            this.Animator = initializer.Animator;
            this.WeaponSlot = initializer.WeaponSlot;
            this.CharacterHealth = initializer.CharacterHealth;
            this.CurrentWeapon = initializer.CurrentWeapon;
            this.Inventory = initializer.Inventory;
            return this;
        }

        public virtual float TakeDamage(float damage)
        {
            if (CharacterHealth)
            {
                return CharacterHealth.TakeDamage(damage);
            }

            Debug.LogError("No health component on character");
            return 0;
        }

        public bool IsDead()
        {
            if (CharacterHealth)
            {
                return CharacterHealth.IsDead();
            }

            Debug.LogError("No health component on character");
            return true;
        }
    }
}