using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public Transform firePoint;
    public TypingManger Typing;

    // Update is called once per frame
    void Update()
    {
        float energy = Typing.getEnergy();

        if (Input.GetKeyDown(KeyCode.Space) && energy >= 10f)
        {
            Fire();
            Typing.addScore(1000);
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
            }
        }
    }
}
