using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Microscope : MonoBehaviour
{
    [SerializeField] Text txt;
    [SerializeField] GameObject lamina,finish;
    bool open;
    // Start is called before the first frame update
    void Start()
    {
        open = false;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if(open && Input.GetKeyDown(KeyCode.E))
        {
            lamina.SetActive(true);
            finish.SetActive(true);
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            txt.text = "Pressione E para interagir";
            open = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            txt.text = "";
            open = false;
        }
    }
}
