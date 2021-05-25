using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    public float projectileSpeed;
    private Rigidbody2D rb;

    private void OnEnable()
    {
        if (rb != null)
        {
            rb.velocity = PlayerController.directionRight ? Vector2.right * projectileSpeed : Vector2.left * projectileSpeed;
        }
        Invoke("Disable", 2f);
    }

    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = Vector2.up * projectileSpeed;
    }

    void Disable()
    {
        gameObject.SetActive(false);
        Debug.Log("Tiro desativado");
    }  

    private void OnDisable()
    {
        CancelInvoke();
    }
}
