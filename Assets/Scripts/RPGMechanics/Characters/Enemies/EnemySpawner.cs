using UnityEngine;

namespace RPGMechanics.Characters.Enemies
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField] public GameObject enemyPrefab;

        public void SpawnEnemy(CharacterType type, int level)
        {
            var enemyObject = Instantiate(enemyPrefab, transform.position, Quaternion.identity);
            var enemyCharacter = enemyObject.GetComponent<Character>();

            enemyCharacter.characterName = type.ToString();
            enemyCharacter.characterType = type;
            enemyCharacter.statistics.Level = level;

            Debug.Log(
                $"{enemyCharacter.characterName} spawned at {transform.position} with level {level} and type {type}");
        }
    }
}