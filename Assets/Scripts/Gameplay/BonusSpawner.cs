using UnityEngine;
using System.Collections.Generic;

namespace Pinball.Gameplay
{
    public class BonusSpawner : MonoBehaviour
    {
        [System.Serializable]
        public class BonusSpawnPoint
        {
            public Transform point;
            public bool occupied;
        }

        public GameObject smallBonusPrefab;
        public GameObject bigBonusPrefab;
        public List<BonusSpawnPoint> spawnPoints;
        public float minSpawnTime = 3f;
        public float maxSpawnTime = 7f;

        private void Start()
        {
            StartCoroutine(SpawnBonusRoutine());
        }

        private IEnumerator<WaitForSeconds> SpawnBonusRoutine()
        {
            while (true)
            {
                yield return new WaitForSeconds(Random.Range(minSpawnTime, maxSpawnTime));
                var freePoints = spawnPoints.FindAll(p => !p.occupied);
                if (freePoints.Count == 0) continue;
                var point = freePoints[Random.Range(0, freePoints.Count)];
                var prefab = Random.value > 0.5f ? smallBonusPrefab : bigBonusPrefab;
                var bonus = Instantiate(prefab, point.point.position, Quaternion.identity);
                point.occupied = true;
                bonus.GetComponent<Bonus>().OnCollected += () => point.occupied = false;
            }
        }
    }
}