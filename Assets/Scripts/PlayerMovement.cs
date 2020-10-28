using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float speed = 5f;
    public float movementHorizontal = 0f;
    public Rigidbody2D rigidBody;
    public float jumpForce;
    public Transform groundChkPoint;
    public float groundChkRadius;
    public LayerMask groundLayer;
    private bool isTouchingGround;
    private Animator playeranimation;
    public Vector3 respawnPoint;
    private LevelManager levelManager;

    
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        playeranimation = GetComponent<Animator>();
        respawnPoint = transform.position;
        levelManager = FindObjectOfType<LevelManager>();

    }

    void Update()
    {
        isTouchingGround = Physics2D.OverlapCircle(groundChkPoint.position,groundChkRadius,groundLayer);
        movementHorizontal = Input.GetAxis("Horizontal");


        if (movementHorizontal < 0)
        {
            rigidBody.velocity = new Vector2(movementHorizontal * speed, rigidBody.velocity.y);
            transform.localScale = new Vector2(-2, 2);
        }
        else if (movementHorizontal > 0)
        {
            rigidBody.velocity = new Vector2(movementHorizontal * speed, rigidBody.velocity.y);
            transform.localScale = new Vector2(2,2); 

        }
        else {
            rigidBody.velocity = new Vector2(0, rigidBody.velocity.y);
        }

        if (Input.GetButtonDown("Jump")&&isTouchingGround)
        {
            rigidBody.velocity = new Vector2(rigidBody.velocity.x, jumpForce);
        }

        playeranimation.SetFloat("Speed",Mathf.Abs(rigidBody.velocity.x));
        playeranimation.SetBool("OnGround",isTouchingGround);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "fallDetect")
        {

            levelManager.respawnPlayer();

        }
        if (other.tag == "Enemy")
        {

            levelManager.respawnPlayer();

        }
        if (other.tag == "Checkpoint")
        {
            respawnPoint = other.transform.position;
            
        }

        if (other.tag == "Platform")
        {
            this.transform.parent = other.transform;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        this.transform.parent = null;
    }

    
}
