using UnityEngine;
public class Obstacle_Spawner : MonoBehaviour
{
    [System.Serializable]
    public struct SpawnableObject
    {
        public GameObject prefab;
        [Range(0f, 10f)]
        public float spawnChance;
    }

    public SpawnableObject[] objects;
    public float minSpawnRate = 1f;
    public float maxSpawnRate = 2f;

    private void OnEnable()
    {
        Invoke(nameof(Spawn), Random.Range(minSpawnRate, maxSpawnRate));
    }

    private void OnDisable()
    {
        CancelInvoke();
    }

    private void Spawn()
    {
        float spawnChance = Random.value;

        foreach (SpawnableObject obj in objects)
        {
            if (spawnChance < obj.spawnChance)
            {
                GameObject obstacle = Instantiate(obj.prefab);
                obstacle.transform.position += transform.position;
                break;
            }
            spawnChance -= obj.spawnChance;
        }
        Invoke(nameof(Spawn), Random.Range(minSpawnRate, maxSpawnRate));
    }
}