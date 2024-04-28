using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    public GameObject[] objectsToSpawn; // Array dos objetos que podem ser spawnados
    public float spawnIntervalMin = 1f; // Intervalo mínimo de spawn
    public float spawnIntervalMax = 3f; // Intervalo máximo de spawn
    public float spawnRange = 3f; // Range máximo de deslocamento do local de spawn

    private float nextSpawnTime; // Tempo do próximo spawn

    void Start()
    {
        // Define o próximo tempo de spawn inicial
        nextSpawnTime = Time.time + Random.Range(spawnIntervalMin, spawnIntervalMax);
    }

    void Update()
    {
        // Verifica se é hora de spawnar um novo objeto
        if (Time.time >= nextSpawnTime)
        {
            // Escolhe um objeto aleatório do array
            GameObject objectToSpawn = objectsToSpawn[Random.Range(0, objectsToSpawn.Length)];

            // Calcula um deslocamento aleatório dentro do range especificado
            Vector3 spawnPosition = transform.position + new Vector3(Random.Range(-spawnRange, spawnRange), 0f, Random.Range(-spawnRange, spawnRange));

            // Instancia o objeto na posição do spawner com o deslocamento aleatório
            Instantiate(objectToSpawn, spawnPosition, Quaternion.identity);

            // Define o próximo tempo de spawn
            nextSpawnTime = Time.time + Random.Range(spawnIntervalMin, spawnIntervalMax);
        }
    }
}
