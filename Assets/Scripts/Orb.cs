using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orb : MonoBehaviour
{
    public static int vidaTotal;
    [SerializeField] GameObject fx;
    int vida;
    // Start is called before the first frame update
    void Start()
    {
        vida = 3;
        vidaTotal = 12;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.CompareTag("Tiro"))
        {
            collision.gameObject.SetActive(false);
            vida--;
            if( vida <= 0)
            {
                Destroy(this.gameObject);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.gameObject.SetActive(false);
        if (collision.gameObject.CompareTag("Tiro"))
        {
            vida--;
            if (vida <= 0)
            {
                vidaTotal--;
                //Ao destruir a orb
                Instantiate(fx,this.transform.position,this.transform.rotation);
                Destroy(this.gameObject);
            }
        }
    }
}
