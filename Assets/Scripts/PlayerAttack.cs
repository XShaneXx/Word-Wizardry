using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public Transform firePoint;
    public TypingManger Typing;
    [SerializeField] AudioSource soundEffectSource;
    [SerializeField] AudioClip attackSound;
    
    public float attackCoolDown = 0.5f;
    public float attackCD;

    
    void Start()
    {
        attackCD = 0f;
    }

    void Update()
    {
        float energy = Typing.getEnergy();

        attackCD -= Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Space) && energy >= 10f && attackCD <= 0f)
        {
            Fire();
            Typing.addScore(1000);
            Typing.cenergy(10f);
            attackCD = attackCoolDown;
        }
    }

    void Fire()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(firePoint.position, firePoint.right);

        if (hitInfo)
        {
            Debug.Log(hitInfo.transform.name);
            EnemyMovement enemy = hitInfo.transform.GetComponent<EnemyMovement>();

            if (enemy != null)
            {
                enemy.Die();
                soundEffectSource.clip = attackSound;
                soundEffectSource.Play();
            }
        }
    }
}
