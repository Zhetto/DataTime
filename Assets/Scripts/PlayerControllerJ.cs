using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerControllerJ : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField]
    float speedMovement,speedClimb;
    [SerializeField]
    float forceJump;
    bool jump,climb;
    Vector3  movement;
    PlatformJ platform;
    BoxcontrollerJ box;
    public GameObject projectile;
    public Transform firePosition;
    public float fireRate;
    private float direction;
    private Vector3 dRight;
    private Vector3 dLeft;
    public float life;
    public ControleBarrasJ vida;
    public bool temOdre = false;
    public int odreUsos = 3;
    public bool temLaranja = false;
    public int laranjaUsos;
    public EnemyMeleeJ inimigoCount;
    public int count;

    // Start is called before the first frame update
    void Start()
    {
        life = 3;
        dRight = transform.localScale;
        dLeft = transform.localScale;
        dLeft.x = dLeft.x * -1;
        movement = new Vector3(0,0,0);
        rb = this.GetComponent<Rigidbody2D>();
        rb.freezeRotation = true;
        rb.angularDrag = 1;
        rb.gravityScale = 2;
        speedMovement = speedMovement != 0 ? speedMovement : 1;
        forceJump = forceJump != 0 ? forceJump : 1;
        fireRate = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        direction = Input.GetAxis("Horizontal");
        count = inimigoCount.count;

        if(direction > 0)
        {
            transform.localScale = dRight;
        }

        if (direction < 0)
        {
            transform.localScale = dLeft;
        }

        if (Input.GetAxisRaw("Horizontal") != 0)
        {
            this.movement.x = (Input.GetAxisRaw("Horizontal") *this.speedMovement*Time.deltaTime);
            this.transform.position += this.movement;
        }

        if (Input.GetKeyDown(KeyCode.W) && jump)
        {
            rb.AddForce(new Vector2(0, forceJump));
            this.jump = false;            
        }
        else if(Input.GetKey(KeyCode.W) && climb)
        {
            this.transform.position += new Vector3(0, speedClimb * Time.deltaTime, 0);
        }

        if (Input.GetKeyDown(KeyCode.S) && this.platform != null)
        {
            this.jump = false;
            this.platform.gameObject.GetComponent<BoxCollider2D>().enabled = false;
        }
        else if (Input.GetKey(KeyCode.S) && climb)
        {
            this.transform.position -= new Vector3(0, speedClimb * Time.deltaTime, 0);
        }

        if (Input.GetKeyDown(KeyCode.S) && this.box != null)
        {
            this.jump = false;
            this.box.gameObject.GetComponent<EdgeCollider2D>().enabled = false;
        }

        if (Input.GetKey(KeyCode.Space) && fireRate > 1)
        {
            Fire();
            fireRate = 0f;
        }
        else
        {
            fireRate += Time.deltaTime;
        }

        if (life <= 0)
        {
            Destroy(this.gameObject);
            Debug.Log("Morreu por tiro");
            SceneManager.LoadScene("Menu");
        }
        if (Input.GetKey(KeyCode.Q) && temLaranja == true && laranjaUsos > 0)
        {
            vida.RecuperaVida();
            life++;
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            jump = true;

            if (collision.gameObject.GetComponent<PlatformJ>() != null)
            {
                this.platform = collision.gameObject.GetComponent<PlatformJ>();
            }
            else
            {
                this.platform = null;
            }

            if (collision.gameObject.GetComponent<BoxcontrollerJ>() != null)
            {
                this.box = collision.gameObject.GetComponent<BoxcontrollerJ>();
            }
            else
            {
                this.box = null;
            }
        }
        if (collision.gameObject.CompareTag("Inimigo"))
        {
            life--;
            vida.Dano();
            Debug.Log("Player recebeu Dano");
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Tiro"))
        {
            life--;
            vida.Dano();
            Debug.Log("Player recebeu Dano");
        }

        if (collision.CompareTag("Inimigo"))
        {
            life--;
        }

        if (collision.CompareTag("NPC"))
        {
            temOdre = true;
        }

        if (collision.CompareTag("Saida1"))
        {
            SceneManager.LoadScene("Egito2");
        }

        if (collision.CompareTag("Saida2") && inimigoCount.count == 0)
        {
            SceneManager.LoadScene("Egito3");
        }

        if (collision.CompareTag("Saida3"))
        {
            SceneManager.LoadScene("Fase2-level1");
        }
    }

    private void Fire()
    {
        GameObject obj = ObjectPoolerJ.current.GetPooledObject();
        if (obj == null) return;
        obj.GetComponent<ProjectileControllerJ>().Atirando(transform);
        obj.transform.position = firePosition.position;
        obj.transform.rotation = firePosition.rotation;
        obj.SetActive(true);
    }
}
