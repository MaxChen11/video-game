using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class boomSprite : MonoBehaviour
{
    public Transform blastPoint;
    public float blastRange;
    public LayerMask playerLayer;
    public Animator blastAnimator;
    public GameObject blastMain;

    private void Start()
    {
        blastRange = .5f;
    }

    void hitPlayer()
    {
        Collider2D[] hitPlayers = Physics2D.OverlapCircleAll(blastPoint.position, blastRange, playerLayer);
        foreach (Collider2D enemy in hitPlayers)
        {
            SceneManager.LoadScene(2);
        }
    }

    void endAnimation()
    {
        blastAnimator.SetBool("attacking", false);
        blastMain.GetComponent<blastMove>().ResumeChase(true);
    }
}
