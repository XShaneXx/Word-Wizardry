using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] float speed;
    Vector3 enemyPosition;
    public Animator animator;
    public float deathAnimationDurationInFrames = 10;
    public float frameRate = 60;

    void Update()
    {
        enemyPosition= new Vector3 (speed*Time.deltaTime*(1), 0, 0);
        transform.Translate (enemyPosition);
    }

    public void Die()
    {
        animator.SetBool("isDead", true);
        StartCoroutine(DelayedDestroy());
    }

    private IEnumerator DelayedDestroy()
    {
        float durationInSeconds = deathAnimationDurationInFrames / frameRate;
        yield return new WaitForSeconds(durationInSeconds);
        Destroy(gameObject);
    }
}