using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlterStairLayer : MonoBehaviour
{
    [SerializeField]GameObject stair;
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
            stair.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if(this.transform.position.y > collision.gameObject.transform.position.y)
            {
                stair.SetActive(false);
            }
        }
    }
}
