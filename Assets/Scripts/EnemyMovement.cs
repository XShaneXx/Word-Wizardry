using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] float speed;
    public Animator animator;
    Vector3 enemyPosition;

    private void Start()
    {
        animator=GetComponent<Animator>();
    }

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