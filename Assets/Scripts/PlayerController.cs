using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    public float jumpForce;
    public float gravityModifier;
    public bool isOnGround = false;
    public bool gameOver;
    // Animation type variable
    private Animator playerAnim;

    // Start is called before the first frame update
    void Start()
    {
        // Get gravity component from Player´s Inspector
        playerRb = GetComponent<Rigidbody>();
        // Get animator component from Player´s Inspector
        playerAnim = GetComponent<Animator>();
        Physics.gravity *= gravityModifier;
    }

    // Update is called once per frame
    void Update()
    {
        // When Spacebar pressed and player is touching the ground, jump
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround)
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
            // When jumping, trigger the jump animation
            playerAnim.SetTrigger("Jump_trig");
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        // If there is a collision with the gameObject tagged as "Ground", isOnGround state is changed to True
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
        }
        // If collition with Obstacle tagged gameObject, gameOver printed as a Debug message
        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            gameOver = true;
            Debug.Log("Game Over!");
        }

    }
}
