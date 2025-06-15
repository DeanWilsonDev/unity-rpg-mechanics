using RPGMechanics.Characters;
using RPGMechanics.Characters.Player;
using RPGMechanics.Characters.Statistics;

using Unity.VisualScripting;

using UnityEngine;

namespace RPGMechanics.SceneBuilding
{
    public class PlayerBuilder
    {
        private const int PLAYER_LAYER = 7;

        public static void CreatePlayerPrefab()
        {
            GameObject go = new GameObject { name = "Player" };

            // Add Components 
            AddModel(go);

            var controller = go.AddComponent<CharacterController>();




            go.tag = "Player";
            go.layer = PLAYER_LAYER;
        }

        private static Health AddHealth(GameObject go, CharacterStatistics stats)
        {
            var health = go.AddComponent<Health>();
            health.Initialize(stats);
            return health;
        } 

        private static PlayerCharacter AddPlayerCharacter(GameObject go)
        {
            var player = go.AddComponent<PlayerCharacter>();
            // Set properties
            const CharacterType characterType = CharacterType.MeleeDamage;
            var stats = CharacterStatistics.GetBaseStatisticsForCharacterType(characterType);
            var health = AddHealth(go, stats);
            var animator = AddAnimator(go); 

            var initializer = new PlayerCharacterInitializer
            {
                Statistics = stats,
                CharacterName = "Player",
                CharacterType = characterType,
                CharacterHealth = health,
                WeaponSlot = null,
                Inventory = null,
                Animator = animator,
                CurrentWeapon = null,
                PlayerInventory = null,
                InputReader = null,
                CharacterController = null
            };

            player.InitializeCharacter(initializer);

            return player;
        }

        private static GameObject AddModel(GameObject go)
        {
            GameObject modelPrefab = Resources.Load<GameObject>("Models/PlayerModel");
            GameObject visual;

            if (modelPrefab == null)
            {
                // If the model isn't found, default to a Capsule
                Debug.LogError("PlayerModel not found in 'Resources/Models/', using Capsule as a default");
                visual = new GameObject { name = "Model" };

                var renderer = visual.AddComponent<MeshRenderer>();
                var filter = visual.AddComponent<MeshFilter>();
                filter.mesh = Resources.GetBuiltinResource<Mesh>("Capsule.fbx");
                renderer.material = new Material(Shader.Find("Standard"));

                return visual;
            }

            visual = Object.Instantiate(modelPrefab);
            visual.name = "Model";
            return visual;
        }


        private static Animator AddAnimator(GameObject go)
        {
            var animator = go.AddComponent<Animator>();
            // Set Properties
            
            return animator;
        }
    }
}