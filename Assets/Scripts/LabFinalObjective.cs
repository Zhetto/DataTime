using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LabFinalObjective : MonoBehaviour
{
    [SerializeField] Text txt;
    int count;
    [SerializeField] GameObject microscope;
    // Start is called before the first frame update
    void Start()
    {
        count = 2;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.otherCollider.enabled = false;
            count--;

            if(count <= 0)
            {
                microscope.SetActive(true);
                txt.text = "";
                Destroy(this.gameObject);
            }
        }        
    }
}
