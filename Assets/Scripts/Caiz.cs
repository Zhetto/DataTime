using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Caiz : MonoBehaviour
{
    [SerializeField] GameObject finish;
    [SerializeField] float speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        this.transform.position += Vector3.right * speed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == "Barco Chines")
        {
            finish.SetActive(true);
            this.enabled = false;
        }
    }
}
