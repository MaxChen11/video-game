using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_movement : MonoBehaviour
{

    public GameObject player;
    public Rigidbody2D playerRB;
    public float playerSpeed;
    public float playerJumpForce;

    // Start is called before the first frame update
    void Start()
    {
        playerSpeed = 0.04f;
        playerJumpForce = 500f;
    }

    // Update is called once per frame
    void Update()
    {
        // Horizontal movement
        player.transform.Translate(Vector3.right * Input.GetAxisRaw("Horizontal") * playerSpeed);

        // Jumping
        if (Input.GetKeyDown("space"))
        {
            playerRB.AddForce(Vector2.up * playerJumpForce);
        }
        Vector3 characterScale = transform.localScale;
        if (Input.GetAxis("Horizontal") > 0)
        {
            characterScale.x = 1;
        }
        if (Input.GetAxis("Horizontal") < 0)
        {
            characterScale.x = -1;
        }
        transform.localScale = characterScale;
    }
}
