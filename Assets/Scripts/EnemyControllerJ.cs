using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControllerJ : MonoBehaviour
{
    public float velocidade;
    public Transform target;
    public bool ladoDireito = false;
    public float lineOfSite;
    public float shootRange;
    public GameObject projetil;
    public Transform firePositionInimigo;
    public float fireRate;
    private float life;

    // Start is called before the first frame update
    void Start()
    {
        life = 1;
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
       float distanceFromPlayer = Vector2.Distance(transform.position, target.position);
       if (distanceFromPlayer < lineOfSite && distanceFromPlayer > shootRange)
        {
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(target.position.x, transform.position.y), velocidade * Time.deltaTime);
        }
       else if (distanceFromPlayer <= shootRange)
        {
            if(fireRate > 0.5)
            {
                Fire();
                fireRate = 0;
            }
            else
            {
                fireRate += Time.deltaTime;
            }
        }
        if ((transform.position.x - target.position.x) > 0 && !ladoDireito)
            Virar();
        if((transform.position.x - target.position.x) < 0 && ladoDireito)
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
        Gizmos.DrawWireSphere(transform.position, shootRange);
    }

    private void Fire()
    {
        GameObject obj = ObjectPoolerJ.current.GetPooledObject();
        if (obj == null) return;
        obj.GetComponent<ProjectileControllerJ>().Atirando(transform);
        obj.transform.position = firePositionInimigo.position;
        obj.transform.rotation = firePositionInimigo.rotation;
        obj.SetActive(true);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Tiro"))
        {
            life--;
        }

        if (life <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
