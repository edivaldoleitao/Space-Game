using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnerScritp : MonoBehaviour
{
    public GameObject enemyPrefab; // Prefab do inimigo
    public float spawnInterval = 2f; // Intervalo entre os spawns
    public int maxEnemies = 10; // Quantidade m�xima de inimigos
    [SerializeField] private Transform firingPoint;
    private int currentEnemies = 0;
    public float spawnRateIncreaseInterval = 30f; // Intervalo para aumentar a taxa de spawn
    public float spawnRateIncreaseAmount = 0.1f; // Aumento na taxa de spawn a cada intervalo
    public int maxEnemiesIncreaseAmount = 2; // Aumento na quantidade m�xima de inimigos a cada intervalos
    private float timeSinceLastSpawnRateIncrease = 0f;
    private float increase = 1f;

    void Start()
    {
        // Come�a a spawnar inimigos
        InvokeRepeating("SpawnEnemy", 0f, spawnInterval);
    }

    void Update()
    {
        // Verifica se � hora de aumentar a taxa de spawn
        timeSinceLastSpawnRateIncrease += Time.deltaTime;
        if (timeSinceLastSpawnRateIncrease >= spawnRateIncreaseInterval)
        {
            timeSinceLastSpawnRateIncrease = 0f;

            if(spawnInterval > 0f)
                spawnInterval -= spawnRateIncreaseAmount;

            maxEnemies += maxEnemiesIncreaseAmount;
            enemyPrefab.GetComponent<enemyScript>().currentMoveSpeed += increase;
            increase += 1;

            // Cancela a repeti��o atual e inicia uma nova com a nova taxa de spawn
            CancelInvoke("SpawnEnemy");
            InvokeRepeating("SpawnEnemy", 0f, spawnInterval);
        }
    }


    void SpawnEnemy()
    {
        if (currentEnemies < maxEnemies)
        {
            // Calcula uma posi��o aleat�ria ao redor do ponto de spawn
            Vector3 spawnPosition = transform.position + Random.insideUnitSphere * 5f;
            spawnPosition.y = 0f; // Mant�m a altura no mesmo n�vel do ponto de spawn

            // Instancia o inimigo na posi��o calculada
            Instantiate(enemyPrefab, firingPoint.position, firingPoint.rotation) ;

            currentEnemies++;
        }
    }
}
