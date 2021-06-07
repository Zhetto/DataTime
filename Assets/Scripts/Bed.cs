using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bed : MonoBehaviour
{
    [SerializeField] GameObject cover;
    bool active,sleep;
    float time;
    [SerializeField] Text text;
    [SerializeField] GameObject artefact,madame;
    [SerializeField] Dialogue[] Kelley, Humphrey;
    [SerializeField] DialogueController dialogue;
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

            if (sleep)
            {
                if (Time.time >= time+5)
                {
                    GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().enabled = true;
                    cover.SetActive(false);
                    artefact.SetActive(true);
                    madame.SetActive(false);
                    GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>().SetBool("Walk", false);
                    dialogue.initial = GameController.playerChoice.name == "Kelley" ? Kelley : Humphrey;
                    dialogue.StartDialogue();
                    
                    Destroy(this);
                }
                else
                {
                    GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().enabled = false;
                    //Debug.Log("aumentar opacidade");
                    cover.SetActive(true) ;
                }
            }
        }
    }

    private void LateUpdate()
    {
        if (active)
        {
            if (Input.GetKeyDown(KeyCode.E) && time == 0)
            {
                sleep = true;
                time = Time.time;
                text.text = "";
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            active = true;
            text.text = "Pressione E para dormir";
        }        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            active = false;
            text.text = "";
        }
    }
}
