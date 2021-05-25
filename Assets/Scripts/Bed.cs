using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bed : MonoBehaviour
{
    [SerializeField] Image cover;
    bool active,sleep;
    float time;
    [SerializeField] GameObject artefact;
    // Start is called before the first frame update
    void Start()
    {
        time = 0;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (active)
        {
            if (Input.GetKeyDown(GameController.getKeyCode(LoadControl.Control.resumeKey)) && time==0)
            {
                sleep = true;
                time = Time.time;
            }

            if (sleep)
            {
                if (Time.time >= time+5)
                {
                    //Debug.Log("diminuir opacidade");
                    cover.color -= new Color(0, 0, 0, 0001f);
                    if(cover.color.a <= 0)
                    {
                        artefact.SetActive(true);
                        Destroy(this);
                        //Debug.Log("Acordou");
                    }
                }
                else
                {
                    //Debug.Log("aumentar opacidade");
                    cover.color += new Color(0, 0, 0, 0001f);
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            active = true;
        }        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            active = false;
        }
    }
}
