using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class blastMove : MonoBehaviour
{

    public Transform blastPos;
    public Transform playerPos;

    public float blastMoveSpeed;
    public float agroRange;

    public Animator blastAnim;
    public bool chasing;

    public int maxHealth = 10;
    public int currentHealth;

    public GameObject blastMain;
    public GameObject blastSprite;
    public GameObject blastPoint;

    // Start is called before the first frame update
    void Start()
    {
        blastMoveSpeed = 0.02f;
        agroRange = 2.8f;
        chasing = true;
    }

    // Update is called once per frame
    void Update()
    {
        float distToPlayer = Vector2.Distance(blastPos.position, playerPos.position);
        Vector3 characterScale = transform.localScale;
        if (distToPlayer < agroRange)
        {
            //blastAnim.SetTrigger("windup");
            blastAnim.SetBool("attacking", true);
            chasing = false;
        }
        if (chasing == true)
        {
            if (playerPos.transform.position.x > blastPos.transform.position.x)
            {
                blastPos.transform.Translate(Vector3.right * blastMoveSpeed);
                characterScale.x = -1;
            }
            if (playerPos.transform.position.x < blastPos.transform.position.x)
            {
                blastPos.transform.Translate(Vector3.left * blastMoveSpeed);
                characterScale.x = 1;
            }
            transform.localScale = characterScale;
        }
    }

    public void ResumeChase(bool chase)
    {
        chasing = true;
    }

    // Damidge

    public void TakeDamage(int damage)
    {

        currentHealth -= damage;
        Debug.Log("Yeet");
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        Destroy(blastMain);
        Destroy(blastSprite);
        Destroy(blastPoint);
        SceneManager.LoadScene(3);
    }
}
