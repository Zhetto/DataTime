using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaOdre : MonoBehaviour
{
    bool pegou;
    [SerializeField] Dialogue[] dialogues;
    // Start is called before the first frame update
    void Start()
    {
        pegou = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player") && !pegou)
        {
            DialogueController dialogo = GameObject.FindObjectOfType<DialogueController>();
            dialogo.initial = dialogues;
            dialogo.StartDialogue();
            PlayerController player = GameObject.FindObjectOfType<PlayerController>();
            player.odreUsos = 3;
            player.temOdre = true;
            pegou = true;
            player.anim.SetBool("Walk", false);
        }
    }
}
