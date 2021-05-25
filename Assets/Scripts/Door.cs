using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] bool locked;
    bool hover;
    [SerializeField]FinishLevel finish;
    [SerializeField]AudioClip clip;
    // Start is called before the first frame update
    void Start()
    {
        hover = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (hover)
        {
            if (Input.GetKeyDown(GameController.getKeyCode(LoadControl.Control.resumeKey)))
            {
                if (!locked)
                {
                    //Logica caso seja a porta certa
                    //Debug.Log("porta certa");
                    AudioController.PlaySound(clip);
                    finish.enabled = true;
                    Destroy(this);
                }
                else
                {
                    //Logica caso seja a porta errada
                    AudioController.PlaySound(clip);
                    Debug.Log("porta errada");
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Colidiu com player");
            hover = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            hover = false;
        }
    }
}
