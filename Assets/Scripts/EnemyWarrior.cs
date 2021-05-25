using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWarrior : MonoBehaviour
{
    [SerializeField]
    bool right, attencion,stop;
    Transform playerTransform;
    Animator anim;
    Vector3 scale;
    [SerializeField]
    float speed;
    int life;
    // Start is called before the first frame update
    void Start()
    {
        life = 2;
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        anim = GetComponent<Animator>();
        right = Random.Range(0, 2) == 0 ? false : true ;
        scale = this.transform.localScale;
    }

    // Update is called once per frame
    void FixedUpdate()
    {        
        if (attencion)
        {
            right = this.transform.position.x >= playerTransform.transform.position.x ? false : true;
                                    
        }
        if (!stop)
        {
            anim.SetBool("Walk", true);
            this.transform.position += right ? Vector3.right * speed : Vector3.left * speed;
        }
        else
        {
            anim.SetBool("Walk", false);
        }
        if (right)
        {
            this.transform.localScale = new Vector3(scale.x, scale.y, scale.z);
        }
        else
        {
            this.transform.localScale = new Vector3(scale.x * -1, scale.y, scale.z);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //Implementar lógica ao player colidir com o inimigo
            stop = true;
            PlayerController.life--;
            //Debug.Log("Colidiu com o player");
           //Debug.Log("dano no inimigo");            
        }else if (collision.gameObject.CompareTag("bullet"))
        {
            collision.gameObject.SetActive(false);
            life--;
            if (life <= 0)
            {
                //Debug.Log("Inimigo morto");
                EnemyController.spawnedEnemys--;
                EnemyController.diedEnemys++;                
                Destroy(this.gameObject);
            }
        }
        if(collision.gameObject.name == "wall" || collision.gameObject.name == "Door")
        {
            right = !right;
        }       
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //Implementar lógica ao player colidir com o inimigo
            stop = false;
            //Debug.Log("Descolidiu com o player");
            
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //Implementar lógica ao player entrar do raio do inimigo
            //Debug.Log("Sentiu a presença do player");
            attencion = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //Implementar lógica ao player sair do raio do inimigo
            //Debug.Log("Não sente mais a presença do player");
            attencion = false;
            right = !right;
        }
    }
}
