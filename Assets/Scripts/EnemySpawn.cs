using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField] GameObject enemyPrefab;
    
    void Start()
    {
        Instantiate(enemyPrefab, this.transform.position, Quaternion.identity);
    }
}
