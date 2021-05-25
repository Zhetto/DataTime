using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileControllerJ :  MonoBehaviour
{
    public float projectileSpeed;
    private Rigidbody2D rb;
    float escala;

    private void OnEnable()
    {
        if (rb != null)
        {
            if (escala > 0)
            {
                rb.velocity = Vector3.right * projectileSpeed;
            }
            else if (escala < 0)
            {
                rb.velocity = Vector3.left * projectileSpeed;
            }
            
        }
    }

    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = Vector2.up * projectileSpeed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Inimigo") || collision.CompareTag("Player"))
        {
            gameObject.SetActive(false);
            Debug.Log("Tiro desativado");
        }

        if (collision.CompareTag("Barreira") || collision.CompareTag("Floor"))
        {
            gameObject.SetActive(false);
        }
    }

    public void Atirando(Transform trans)
    {
        escala = trans.localScale.x;
    }

    private void OnBecameInvisible()
    {
        gameObject.SetActive(false);
        Debug.Log("Tiro desativado");
    }
}
