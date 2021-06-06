using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxcontrollerJ : MonoBehaviour
{
    EdgeCollider2D col;
    [SerializeField] bool level3;
    // Start is called before the first frame update
    void Start()
    {
        col = this.GetComponents<EdgeCollider2D>()[0];
        col.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (level3)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                if (this.transform.position.y > collision.gameObject.transform.position.y)
                {
                    this.col.enabled = false;
                }
                else if (this.transform.position.y-2 < collision.gameObject.transform.position.y)
                {
                    this.col.enabled = true;
                }
            }
        }
        else
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                if (this.transform.position.y > collision.gameObject.transform.position.y)
                {
                    this.col.enabled = false;
                }
                else if (this.transform.position.y < collision.gameObject.transform.position.y)
                {
                    this.col.enabled = true;
                }
            }
        }
    }
}
