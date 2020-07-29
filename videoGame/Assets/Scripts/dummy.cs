using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class dummy : MonoBehaviour
{

    public int maxHealth = 100;
    public int currentHealth;

    public GameObject Dummy;
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {

        currentHealth -= damage;

        animator.SetTrigger("Damage");

        if(currentHealth <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        Destroy(Dummy);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
