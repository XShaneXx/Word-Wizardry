using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] float speed;
    Vector3 enemyPosition;
    
    void FixedUpdate()
    {
        enemyPosition= new Vector3 (0, speed*Time.deltaTime*(-1), 0);
        transform.Translate (enemyPosition);
    }
}
