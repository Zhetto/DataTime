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


    private void Awake()
    {
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
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

        if (life <= 0)
        {
            if (this.name.Contains("Warrior"))
            {
                EnemyController.spawnedEnemys--;
                EnemyController.diedEnemys++;
            }
            Contador();
            Destroy(this.gameObject);
        }

        if (collision.CompareTag("Tiro"))
        {
            life--;
            StartCoroutine(TomarDano());
        }

        /*if (life <= 0)
        {
            Contador();
            Destroy(this.gameObject);
        }*/
    }

    IEnumerator TomarDano()
    {
        sprite.color = Color.red;
        yield return new WaitForSeconds(0.3f);
        sprite.color = Color.white;
    }

    private void Contador()
    {
        count++;
    }
}
