using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMeleeJ : MonoBehaviour
{
    public float velocidade;
    public Transform target;
    public bool ladoDireito = false;
    public float life;
    public float lineOfSite;
    Animator anim;
    public int count;
    public SpriteRenderer sprite;
    public PlayerController contador;
    AudioSource ataque, hit;
    Color corInicial;


    private void Awake()
    {
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        ataque = GetComponent<AudioSource>();
        corInicial = this.GetComponent<SpriteRenderer>().color;
        hit = GameObject.FindGameObjectWithTag("Dano").GetComponent<AudioSource>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

        float distanceFromPlayer = Vector2.Distance(transform.position, target.position);
        if (distanceFromPlayer < lineOfSite)
        {
            anim.SetBool("isWalking", true);
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(target.position.x, transform.position.y), velocidade * Time.deltaTime);
        }
        else
        {
            anim.SetBool("isWalking", false);
        }

        if ((transform.position.x - target.position.x) > 0 && !ladoDireito)
            Virar();
        if ((transform.position.x - target.position.x) < 0 && ladoDireito)
            Virar();

        if (life <= 0)
        {
            if (this.name.Contains("Warrior"))
            {
                EnemyController.spawnedEnemys--;
                EnemyController.diedEnemys++;
            }
            
            Destroy(this.gameObject);
        }
    }

    void Virar()
    {
        ladoDireito = !ladoDireito;
        Vector2 novoScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
        transform.localScale = novoScale;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, lineOfSite);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

       /* if (life <= 0)
        {
            if (this.name.Contains("Warrior"))
            {
                EnemyController.spawnedEnemys--;
                EnemyController.diedEnemys++;
            }
            //Contador();
            Destroy(this.gameObject);
        }*/

        if (collision.CompareTag("Tiro"))
        {
            hit.Play();
            life--;
            StartCoroutine(TomarDano());
        }

        /*if (life <= 0)
        {
            Contador();
            Destroy(this.gameObject);
        }*/
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            ataque.Play();
        }
    }

    IEnumerator TomarDano()
    {
        sprite.color = Color.red;
        yield return new WaitForSeconds(0.3f);
        sprite.color = this.corInicial;
    }

    public void Atacar()
    {
        ataque.Play();
    }

    private void Contador()
    {
        contador.inimigoCount += 1 ;
    }
}
