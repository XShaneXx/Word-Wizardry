using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField] GameObject enemyPrefab1;
    [SerializeField] GameObject enemyPrefab2;
    public float spawnInterval = 3f;
    public Transform spawnPoint;
    public float spawnChancePrefab1 = 1.0f;
    public TypingManger scoreGot;

    private bool p9 = false;
    private bool p8 = false;
    private bool p7 = false;
    private bool p6 = false;
    private bool p5 = false;
    private bool p4 = false;
    private bool p3 = false;
    private bool p2 = false;
    private bool p1 = false;

    void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    IEnumerator SpawnEnemy()
    {
        while (true)
        {
            // Randomly choose between enemyPrefab1 and enemyPrefab2 based on spawn chances
            GameObject selectedPrefab = Random.Range(0f, 1f) < spawnChancePrefab1 ? enemyPrefab1 : enemyPrefab2;

            Instantiate(selectedPrefab, spawnPoint.position, Quaternion.identity);
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    void Update()
    {
        int currentScore = scoreGot.getScore();

        if (currentScore >= 10000 && !p9)
        {
            spawnChancePrefab1 -= 0.1f; // 0.9
            p9 = true; 
        }
        
        if (currentScore >= 20000 && !p8)
        {
            spawnChancePrefab1 -= 0.1f; //0.8
            p8 = true;
        }
        
        if (currentScore >= 30000 && !p7)
        {
            spawnChancePrefab1 -= 0.1f; //0.7
            p7 = true;
        }
        
        if (currentScore >= 40000 && !p6)
        {
            spawnChancePrefab1 -= 0.1f; //0.6
            p6 = true;
        }
        
        if (currentScore >= 50000 && !p5)
        {
            spawnChancePrefab1 -= 0.1f; //0.5
            p5 = true;
        }
        
        if (currentScore >= 60000 && !p4)
        {
            spawnChancePrefab1 -= 0.1f; //0.4
            p4 = true;
        }
        
        if (currentScore >= 70000 && !p3)
        {
            spawnChancePrefab1 -= 0.1f; //0.3
            p3 = true;
        }
        
        if (currentScore >= 80000 && !p2)
        {
            spawnChancePrefab1 -= 0.1f; //0.2
            p2 = true;
        }
        
        if (currentScore >= 90000 && !p1)
        {
            spawnChancePrefab1 -= 0.1f; //0.1
            p1 = true;
        }
    }
}
