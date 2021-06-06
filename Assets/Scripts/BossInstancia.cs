using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossInstancia : MonoBehaviour
{
    public GameObject bossDeserto;
    public Transform spawn;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Instantiate(bossDeserto, spawn.transform.position, spawn.transform.rotation);
            this.GetComponents<BoxCollider2D>()[1].enabled = false;
        }
    }
}
