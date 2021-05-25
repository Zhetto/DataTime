using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public static int life;
    Rigidbody2D rb;
    [SerializeField]
    float speedMovement,speedClimb;
    [SerializeField]
    float forceJump;
    bool jump,climb;
    Vector3  movement;
    Platform platform;
    public static bool directionRight;
    Animator anim;
    float scaleX;

    public GameObject projectile;
    [SerializeField] Transform firePositionRight, firePositionLeft;
    public float fireRate;

    private void Awake()
    {
        //this.gameObject.AddComponent<Rigidbody2D>();
        //this.gameObject.AddComponent<BoxCollider2D>();

    }
    // Start is called before the first frame update
    void Start()
    {
        scaleX = this.transform.localScale.x;
        life = 10;
        fireRate = 0f;
        if(SceneManager.GetActiveScene().name== "Fase2-level1")
        {
            life = 10;
        }        
        directionRight = true ;
        movement = new Vector3(0,0,0);
        rb = this.GetComponent<Rigidbody2D>();
        rb.freezeRotation = true;
        rb.angularDrag = 1;
        rb.gravityScale = 2;
        speedMovement = speedMovement != 0 ? speedMovement : 1;
        forceJump = forceJump != 0 ? forceJump : 1;
        anim = GetComponent<Animator>();
    }



    // Update is called once per frame
    void FixedUpdate()
    {
 
        if (Input.GetKey(GameController.getKeyCode(LoadControl.Control.rightKey)))
        {
            //Debug.Log("direita");
            this.transform.position += Vector3.right*speedMovement;
            directionRight = true;
            this.transform.localScale = new Vector3(scaleX,this.transform.localScale.y, this.transform.localScale.z);
            anim.SetBool("Walk", true);
        }

        if (Input.GetKey(GameController.getKeyCode(LoadControl.Control.leftKey)))
        {
            this.transform.position += Vector3.left * speedMovement;
            this.transform.localScale = new Vector3 (-scaleX, this.transform.localScale.y, this.transform.localScale.z);
            directionRight = false;
            anim.SetBool("Walk", true);
        }

        if (Input.GetKeyDown(GameController.getKeyCode(LoadControl.Control.downKey)) && this.platform != null)
        {
            this.jump = false;
            this.platform.gameObject.GetComponent<BoxCollider2D>().enabled = false;
        }
        if (Input.GetKey(GameController.getKeyCode(LoadControl.Control.downKey)) && climb)
        {
            this.transform.position -= new Vector3(0, speedClimb * Time.deltaTime, 0);
        }
        if (life <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    public void LateUpdate()
    {
        if (Input.GetKeyDown(GameController.getKeyCode(LoadControl.Control.upKey)) && jump)
        {
            rb.AddForce(new Vector2(0, forceJump));
            this.jump = false;
        }
        if (Input.GetKey(GameController.getKeyCode(LoadControl.Control.upKey)) && climb)
        {
            this.transform.position += new Vector3(0, speedClimb * Time.deltaTime, 0);
        }

        if (Input.GetKeyDown(GameController.getKeyCode(LoadControl.Control.resumeKey)) && fireRate > 0.5)
        {
            Fire();
            fireRate = 0f;
            anim.SetBool("Fire", true);
        }

        else
        {
            fireRate += Time.deltaTime;
        }
        if (Input.GetKeyUp(GameController.getKeyCode(LoadControl.Control.leftKey)))
        {
            anim.SetBool("Walk", false);
        }

        if (Input.GetKeyUp(GameController.getKeyCode(LoadControl.Control.rightKey)))
        {
            anim.SetBool("Walk", false);
        }

        if (Input.GetKeyUp(GameController.getKeyCode(LoadControl.Control.resumeKey)))
        {
            anim.SetBool("Fire", false);
        }

    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            jump = true;

            if (collision.gameObject.GetComponent<Platform>() != null)
            {
                this.platform = collision.gameObject.GetComponent<Platform>();
            }
            else
            {
                this.platform = null;
            }
        }        
    }

    public void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            jump = false;
        }
    }

    public void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Climb"))
        {
            if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.W))
            {
                this.rb.gravityScale = 0;
                this.rb.velocity = new Vector2();
                this.climb = true;
            }
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Climb"))
        {
            this.rb.gravityScale = 2;
            this.climb = false;
        }
    }

    private void Fire()
    {
        GameObject obj = ObjectPooler.current.GetPooledObject();
        if (obj == null) return;

        obj.transform.position = firePositionRight.position;
        obj.SetActive(true);
    }
}
