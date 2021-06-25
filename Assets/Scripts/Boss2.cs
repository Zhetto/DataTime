using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Boss2 : MonoBehaviour
{
    [SerializeField] float forceVertical,forceHorizontal;
    Vector3 localScale,negLocalScale,tempPlayerPosition,tempThisPosition;
    bool down,right,segundaForma;
    public bool attack;
    float limitMaxY, limitMinY;
    GameObject player;
    Animator anim;
    public static int vida;
    [SerializeField] CircleCollider2D collider;

    // Start is called before the first frame update
    void Start()
    {
        limitMaxY = this.transform.position.y + .5f;
        limitMinY = this.transform.position.y - .5f;
        localScale = this.transform.localScale;
        negLocalScale = localScale;
        negLocalScale.x *= -1;
        down = true;
        anim = GetComponent<Animator>();
        collider = GetComponent<CircleCollider2D>();
        vida = 10;
    }

    // Update is called once per frame
    void FixedUpdate()
    {        
        if(collider.enabled == false)
        {
            if (Orb.vidaTotal == 0)
            {
                forceHorizontal *= 1.2f;
                forceVertical *= 5f;
                collider.enabled = true;
                segundaForma = true;
                Orb.vidaTotal--;
                attack = false;
            }
        }
        if (!attack)
        {
            if (!segundaForma)
            {
                player = GameObject.FindGameObjectWithTag("Player");
                if (this.transform.position.y > limitMaxY)
                {
                    down = true;
                }
                else if (this.transform.position.y < limitMinY)
                {
                    down = false;
                }

                if (this.transform.position.x > player.transform.position.x && Vector3.Distance(this.transform.position, player.transform.position) > 18)
                {
                    right = false;
                }
                else if (this.transform.position.x < player.transform.position.x && Vector3.Distance(this.transform.position, player.transform.position) > 18)
                {
                    right = true;
                }

                this.transform.position = down ? this.transform.position + Vector3.down * forceVertical : this.transform.position + Vector3.up * forceVertical;
                this.transform.position = right ? this.transform.position + Vector3.right * forceHorizontal : this.transform.position + Vector3.left * forceHorizontal;
                this.transform.localScale = right ? negLocalScale : this.localScale;
            }
            else
            {
                player = GameObject.FindGameObjectWithTag("Player");
                if (this.transform.position.y > limitMaxY)
                {
                    down = true;
                }
                else if (this.transform.position.y < limitMinY-10)
                {
                    down = false;
                }
                if (this.transform.position.x > player.transform.position.x && Vector3.Distance(this.transform.position, player.transform.position) > 10)
                {
                    right = false;
                }
                else if (this.transform.position.x < player.transform.position.x && Vector3.Distance(this.transform.position, player.transform.position) > 10)
                {
                    right = true;
                }

                this.transform.position = down ? this.transform.position + Vector3.down * forceVertical : this.transform.position + Vector3.up * forceVertical;
                this.transform.position = right ? this.transform.position + Vector3.right * forceHorizontal : this.transform.position + Vector3.left * forceHorizontal;

                //if (this.transform.position.x == player.transform.position.x)
                //{
                //    tempPlayerPosition = player.transform.position;
                //    tempThisPosition = this.transform.position;
                //}
                //else
                //{
                    
                //    this.transform.localScale = right ? negLocalScale : this.localScale;
                //}

                //if(this.transform.position != player.transform.position)
                //{
                //    Vector2.MoveTowards((Vector2)this.transform.position, (Vector2)tempPlayerPosition,forceVertical);
                //}
                //else
                //{
                //    Vector2.MoveTowards((Vector2)this.transform.position, (Vector2)tempThisPosition, forceVertical);
                //}
            }
        }
    }

    void setAttackFalse()
    {
        if (!segundaForma)
        {
            attack = false;

        }
        anim.SetBool("Attack1", false);
        anim.SetBool("Attack2", false);
        anim.SetBool("Attack3", false);
    }
    void setAttackTrue()
    {
        attack = true;
    }

    void randomAttack()
    {
        if (Orb.vidaTotal > 0)
        {
            int random = Random.Range(0, 3);
            switch (random)
            {
                case 0:
                    anim.SetBool("Attack1", true);
                    break;
                case 1:
                    anim.SetBool("Attack2", true);
                    break;
                case 2:
                    anim.SetBool("Attack3", true);
                    break;

            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Tiro"))
        {
            collision.gameObject.SetActive(false);
            vida--;
            if (vida <= 0)
            {
                Instantiate(Resources.Load("Death Orbs") as GameObject,this.transform.position,this.transform.rotation);
                GameObject.FindObjectOfType<AudioSource>().PlayOneShot(Resources.Load("BossDie") as AudioClip);
                Destroy(this.gameObject);               
            }
        }
    }
}
