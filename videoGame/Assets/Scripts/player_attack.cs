using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class player_attack : MonoBehaviour
{

    public Animator playerSpriteAnimator;
    public Transform attackPoint;
    public float attackRange;
    public LayerMask enemyLayers;
    public int attackDamage;
    Scene scene;


    private void Start()
    {
        attackRange = 1f;
        attackDamage = 20;
        scene = SceneManager.GetActiveScene();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Attack();
        }
    }

    void Attack()
    {
        playerSpriteAnimator.SetTrigger("Attack");
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
        foreach (Collider2D enemy in hitEnemies)
        {
            if (scene.buildIndex == 0)
            {
                enemy.GetComponent<dummy>().TakeDamage(attackDamage);
            }
            if (scene.buildIndex == 1)
            {
                enemy.GetComponent<blastMove>().TakeDamage(attackDamage);
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
