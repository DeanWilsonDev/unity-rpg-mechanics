using UnityEngine;

namespace RPGMechanics.SceneBuilding
{
    public class SceneBootstrapper: MonoBehaviour
    {
        public GameObject playerPrefab;
        public GameObject enemyPrefab;

        void Awake()
        {
            var player = Instantiate(playerPrefab, new Vector3(0, 0, 0), Quaternion.identity);
            player.name = "Player";

        }


    }
}