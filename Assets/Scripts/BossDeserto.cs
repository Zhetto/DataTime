using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossDeserto : MonoBehaviour
{
    [Header("Idle")]
    [SerializeField] float idleMoveSpeed;
    [SerializeField] Vector2 idleMoveDirection;

    [Header("AttackUpNDown")]
    [SerializeField] float attackMoveSpeed;
    [SerializeField] Vector2 attackMoveDirection;

    [Header("AttackPlayer")]
    [SerializeField] float attackPlayerSpeed;
    [SerializeField] Transform player;
    private Vector2 playerPosition;
    private bool hasPlayerPosition;

    [Header("Other")]
    [SerializeField] Transform groundCheckUp;
    [SerializeField] Transform groundCheckDown;
    [SerializeField] Transform groundCheckWall;
    [SerializeField] float groundCheckRadius;
    [SerializeField] LayerMask groundLayer;
    private bool isTouchingUp;
    private bool isTouchingDown;
    private bool isTouchingWall;
    private Rigidbody2D enemyRB;
    private bool goingUp = true;
    private bool facingLeft = true;
    private Animator enemyAnim;

    // Start is called before the first frame update
    void Start()
    {
        idleMoveDirection.Normalize();
        attackMoveDirection.Normalize();
        enemyRB = GetComponent<Rigidbody2D>();
        enemyAnim = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

        isTouchingUp = Physics2D.OverlapCircle(groundCheckUp.position, groundCheckRadius, groundLayer);
        isTouchingDown = Physics2D.OverlapCircle(groundCheckDown.position, groundCheckRadius, groundLayer);
        isTouchingWall = Physics2D.OverlapCircle(groundCheckWall.position, groundCheckRadius, groundLayer);
        //IdleState();
        //AttackUpNDown();

        if (Input.GetKeyDown(KeyCode.P))
        {
            AttackPlayer();
        }
        FlipTowardsPlayer();
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawSphere(groundCheckUp.position, groundCheckRadius);
        Gizmos.DrawSphere(groundCheckDown.position, groundCheckRadius);
        Gizmos.DrawSphere(groundCheckWall.position, groundCheckRadius);
    }

    public void IdleState()
    {
        if(isTouchingUp && goingUp)
        {
            ChangeDirection();
        }
        else if(isTouchingDown && !goingUp)
        {
            ChangeDirection();
        }

        if (isTouchingWall)
        {
            if (facingLeft)
            {
                Flip();
            }
            else if (!facingLeft)
            {
                Flip();
            }
        }
        enemyRB.velocity = idleMoveSpeed * idleMoveDirection;
    }

    public void AttackUpNDown()
    {
        if (isTouchingUp && goingUp)
        {
            ChangeDirection();
        }
        else if (isTouchingDown && !goingUp)
        {
            ChangeDirection();
        }

        if (isTouchingWall)
        {
            if (facingLeft)
            {
                Flip();
            }
            else if (!facingLeft)
            {
                Flip();
            }
        }
        enemyRB.velocity = attackMoveSpeed * attackMoveDirection;
    }

    public void AttackPlayer()
    {
        if (!hasPlayerPosition)
        {
            playerPosition = player.position - transform.position;
            playerPosition.Normalize();
            hasPlayerPosition = true;
        }
        if (hasPlayerPosition)
        {
            enemyRB.velocity = playerPosition * attackMoveSpeed;
        }
        if(isTouchingWall || isTouchingDown)
        {
            enemyRB.velocity = Vector2.zero;
            hasPlayerPosition = false;
        }
    }

    public void randomStatePicker()
    {
        int randomState = Random.Range(0, 2);

        if(randomState == 0)
        {
            enemyAnim.SetTrigger("AttackUpNDown");
        }
        if(randomState == 1)
        {
            enemyAnim.SetTrigger("AttackPlayer");
        }
    }

    void FlipTowardsPlayer()
    {
        float playerDirection = player.position.x - transform.position.x;

        if(playerDirection > 0 && facingLeft)
        {
            Flip();
        }
        else if(playerDirection < 0 && !facingLeft)
        {
            Flip();
        }
    }
    void ChangeDirection()
    {
        goingUp = !goingUp;
        idleMoveDirection.y *= -1;
        attackMoveDirection.y *= -1;
    }

    void Flip()
    {
        facingLeft = !facingLeft;
        idleMoveDirection.x *= -1;
        attackMoveDirection.x *= -1;
        transform.Rotate(0, 180, 0);
    }
}
