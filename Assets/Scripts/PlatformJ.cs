using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformJ : MonoBehaviour
{
    BoxCollider2D col;
    // Start is called before the first frame update
    void Start()
    {
        col = this.GetComponents<BoxCollider2D>()[0];
        col.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if(this.transform.position.y > collision.gameObject.transform.position.y)
            {
                this.col.enabled = false;
            }else if(this.transform.position.y < collision.gameObject.transform.position.y)
            {
                this.col.enabled = true;
            }
        }
    }
}
