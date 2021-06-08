using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public static int life;
    public ControleBarrasJ vida;
    Rigidbody2D rb;
    [SerializeField]
    float speedMovement,speedClimb;
    BoxcontrollerJ box;
    [SerializeField]
    float forceJump;
    bool jump,climb;
    Vector3  movement;
    Platform platform;
    public static bool directionRight;
    Animator anim;
    float scaleX;
    private Vector3 dRight;
    private Vector3 dLeft;
    public GameObject projectile;
    public Transform firePosition;
    public int odreUsos;
    public float fireRate;
    public int inimigoCount;
    public bool temOdre = false;
    public bool pegouOdre;
    public static int laranjaUsos = 0;
    public int testeLaranjas;
    public bool pegouLaranjas;
    [SerializeField]
    GameObject jumpFx;
    public GameObject dialogo;
    public Text textoL;
    public Text textoO;
    SpriteRenderer sprite;
    AudioSource dano;
    Vector2 mousePosition;
    public BossDeserto boss;
    public AudioSource consumir;
    public CameraController camera;
    bool tomouQueda = false;

    private void Awake()
    {
        /*if (SceneManager.GetActiveScene().name == "Egito3")
        {
            boss = GameObject.FindGameObjectWithTag("BossDeserto").GetComponent<BossDeserto>();
        }*/
        //this.gameObject.AddComponent<Rigidbody2D>();
        //this.gameObject.AddComponent<BoxCollider2D>();
       
    }
    // Start is called before the first frame update
    void Start()
    {
        life = 3;
        dRight = transform.localScale;
        dLeft = transform.localScale;
        dLeft.x = dLeft.x * -1;
        movement = new Vector3(0, 0, 0);
        rb = this.GetComponent<Rigidbody2D>();
        rb.freezeRotation = true;
        rb.angularDrag = 1;
        rb.gravityScale = 2;
        speedMovement = speedMovement != 0 ? speedMovement : 1;
        forceJump = forceJump != 0 ? forceJump : 1;
        fireRate = 0f;
        anim = GetComponent<Animator>();
        dialogo = GameObject.FindGameObjectWithTag("Dialogo");
        pegouLaranjas = false;
        pegouOdre = false;
        textoL = GameObject.FindGameObjectWithTag("TextoL").GetComponent<Text>();
        textoO = GameObject.FindGameObjectWithTag("TextoO").GetComponent<Text>();
    }



    // Update is called once per frame
    void FixedUpdate()
    {
        if (SceneManager.GetActiveScene().name == "Egito3")
        {
            camera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraController>();
        }
        sprite = GetComponent<SpriteRenderer>();
        dano = GetComponent<AudioSource>();

        testeLaranjas = laranjaUsos;

        textoL.text = testeLaranjas.ToString();
        textoO.text = odreUsos.ToString();

        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if(mousePosition.x > this.transform.position.x)
        {
            transform.localScale = dRight;
        }
        else
        {
            transform.localScale = dLeft;
        }

        if (Input.GetKey(GameController.getKeyCode(LoadControl.Control.rightKey)))
        {
            //Debug.Log("direita");
            this.transform.position += Vector3.right*speedMovement;
            transform.localScale = dRight;
            anim.SetBool("Walk", true);
        }

        if (Input.GetKey(GameController.getKeyCode(LoadControl.Control.leftKey)))
        {
            this.transform.position += Vector3.left * speedMovement;
            transform.localScale = dLeft;
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
        if (Input.GetKeyDown(GameController.getKeyCode(LoadControl.Control.downKey)) && this.box != null)
        {
            this.jump = false;
            this.box.gameObject.GetComponent<EdgeCollider2D>().enabled = false;
        }
        if (vida.vidaSlidder.value <= 0)
        {
            Debug.Log("Morreu");
            Checkpoint.decreaseRestLife();
        }

        if (rb.velocity.y < -15 && !tomouQueda)
        {
            Debug.Log("you fell");
            tomouQueda = true;
        }
    }

    public void LateUpdate()
    {
        if (Input.GetKeyDown(GameController.getKeyCode(LoadControl.Control.upKey)) && jump)
        {
            rb.AddForce(new Vector2(0, forceJump));
            this.jump = false;
            anim.SetBool("Jump", true);
            GameObject fx = Instantiate(jumpFx, this.transform.position - Vector3.up * 1.35f, this.transform.rotation);
            fx.transform.Rotate(Vector3.right * -90);
        }

        if (Input.GetKey(GameController.getKeyCode(LoadControl.Control.upKey)) && climb)
        {
            this.transform.position += new Vector3(0, speedClimb * Time.deltaTime, 0);
        }

        if (Input.GetMouseButton(0) && fireRate > 0.5 && SceneManager.GetActiveScene().name != "Lab-01" && SceneManager.GetActiveScene().name != "Lab-02" && SceneManager.GetActiveScene().name != "Lab-Final" && SceneManager.GetActiveScene().name != "Menu")
        {
            Debug.Log("Clicou");
            //Fire();
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

        if (Input.GetMouseButtonUp(0) && SceneManager.GetActiveScene().name != "Lab-Final")
        {
            anim.SetBool("Fire", false);
        }

        if (Input.GetKeyDown(KeyCode.Q) && laranjaUsos > 0 && vida.vidaSlidder.value < 3)
        {
            consumir = GameObject.FindGameObjectWithTag("CLaranja").GetComponent<AudioSource>();
            consumir.Play();
            laranjaUsos--;
            vida.RecuperaVida();
            life++;
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            jump = true;
           
            if (tomouQueda == true)
            {
                dano.Play();
                vida.Dano();
                StartCoroutine(TomarDano());
                tomouQueda = false;
            }
            
            anim.SetBool("Jump", false);
            GameObject fx = Instantiate(jumpFx, this.transform.position - Vector3.up * 1.35f, this.transform.rotation);
            fx.transform.Rotate(Vector3.right * -90);

            if (collision.gameObject.GetComponent<Platform>() != null)
            {
                this.platform = collision.gameObject.GetComponent<Platform>();
            }
            else
            {
                this.platform = null;
            }
        }
        if (collision.gameObject.CompareTag("Inimigo") || collision.gameObject.CompareTag("BossDeserto") || collision.gameObject.CompareTag("Orb"))
        {
            dano.Play();
            StartCoroutine(TomarDano());
            vida.Dano();
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
            Debug.Log("Player recebeu Dano");
        }

        if (collision.CompareTag("Odre") && pegouOdre == false)
        {
            dialogo.GetComponent<DialogueController>().enabled = true;
            anim.SetBool("Walk", false);
            //textoBarraca.gameObject.SetActive(true);
            temOdre = true;
            odreUsos = 3;
            pegouOdre = true;
        }

        if (collision.CompareTag("Saida1"))
        {
            SceneManager.LoadScene("Egito2");
        }

        if (collision.CompareTag("Saida2") && inimigoCount == 0)
        {
            temOdre = false;
            SceneManager.LoadScene("Egito3");
        }

        if (collision.CompareTag("Saida3") && BossDeserto.bossMorto == true)
        {
            SceneManager.LoadScene("Lab-02");
        }

        if (collision.CompareTag("Laranja"))
        {
            laranjaUsos++;
            Debug.Log("Laranja add");
        }

        if (collision.CompareTag("NPC") && laranjaUsos == 0 && pegouLaranjas == false)
        {
            dialogo.GetComponent<DialogueController>().enabled = true;
            anim.SetBool("Walk", false);
            laranjaUsos += 3;
            pegouLaranjas = true;
        }

        if (collision.CompareTag("Porta"))
        {
            Camera.main.orthographicSize = 8;
            camera.xMax = 65.5f;
            camera.xMin = -56;
            camera.yMax = 13;
            camera.yMin = -13;
        }
    }

    IEnumerator TomarDano()
    {
        sprite.color = Color.red;
        yield return new WaitForSeconds(0.25f);
        sprite.color = Color.white;
    }
    private void Fire()
    {
        dano.PlayOneShot(Resources.Load("Tiro") as AudioClip);
        GameObject obj = ObjectPooler.current.GetPooledObject();
        if (obj == null) return;
        obj.GetComponent<ProjectileControllerJ>().Atirando(transform);
        obj.transform.position = firePosition.position;
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        obj.transform.right = (mousePosition - (Vector2)transform.position).normalized;
        //obj.transform.localScale = new Vector3(this.transform.localScale.x < 0 ? -6 : 6,obj.transform.localScale.y, obj.transform.localScale.z);
        obj.SetActive(true);
    }
}
