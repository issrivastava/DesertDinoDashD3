using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [System.Serializable]
    public struct SpawnableObject
    {
        public GameObject prefab;
        [Range(0f, 1f)]
        public float spawnChance;
    }
    public SpawnableObject[] objects;
    public float minSpawnRate = 0.1f;
    public float maxSpawnRate = 0.2f;
    private float leftEdge;
    private void Start()
    {
        leftEdge = Camera.main.ScreenToWorldPoint(Vector3.zero).x - 2f;
    }
    private void Update()
    {
        transform.position += BackgroundScroll.Instance.scrollSpeed * Time.deltaTime * Vector3.left;
        if (transform.position.x < leftEdge) 
        {
            Destroy(gameObject);
        }
    }
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
                GameObject Obstacle = Instantiate(obj.prefab);
                Obstacle.transform.position += transform.position;
                break;
            }
            spawnChance -= obj.spawnChance;
        }
        Invoke(nameof(Spawn), Random.Range(minSpawnRate, maxSpawnRate));
    }
}