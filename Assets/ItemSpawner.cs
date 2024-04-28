using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    public GameObject[] objectsToSpawn; // Array dos objetos que podem ser spawnados
    public float spawnIntervalMin = 1f; // Intervalo m�nimo de spawn
    public float spawnIntervalMax = 3f; // Intervalo m�ximo de spawn
    public float spawnRange = 3f; // Range m�ximo de deslocamento do local de spawn

    private float nextSpawnTime; // Tempo do pr�ximo spawn

    void Start()
    {
        // Define o pr�ximo tempo de spawn inicial
        nextSpawnTime = Time.time + Random.Range(spawnIntervalMin, spawnIntervalMax);
    }

    void Update()
    {
        // Verifica se � hora de spawnar um novo objeto
        if (Time.time >= nextSpawnTime)
        {
            // Escolhe um objeto aleat�rio do array
            GameObject objectToSpawn = objectsToSpawn[Random.Range(0, objectsToSpawn.Length)];

            // Calcula um deslocamento aleat�rio dentro do range especificado
            Vector3 spawnPosition = transform.position + new Vector3(Random.Range(-spawnRange, spawnRange), 0f, Random.Range(-spawnRange, spawnRange));

            // Instancia o objeto na posi��o do spawner com o deslocamento aleat�rio
            Instantiate(objectToSpawn, spawnPosition, Quaternion.identity);

            // Define o pr�ximo tempo de spawn
            nextSpawnTime = Time.time + Random.Range(spawnIntervalMin, spawnIntervalMax);
        }
    }
}
