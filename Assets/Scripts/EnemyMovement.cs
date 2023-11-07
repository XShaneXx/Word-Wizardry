using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] float speed;
    Vector3 enemyPosition;

    void Update()
    {
        enemyPosition= new Vector3 (speed*Time.deltaTime*(1), 0, 0);
        transform.Translate (enemyPosition);
    }

    public void Die()
    {
        Destroy(gameObject);
    }
}
