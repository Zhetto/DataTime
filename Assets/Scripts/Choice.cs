using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Choice : MonoBehaviour
{
    static string name = "null";
    [SerializeField] GameObject Humphrey, Kelley;
    [SerializeField] Dialogue[] dialogueHumphrey, dialogueKelley;
    [SerializeField] GameObject choice;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public  void getName()
    {
        name = this.gameObject.name;
    }

    public void confirmar(DialogueController dialogue)
    {
        if(name == "Humphrey")
        {
            GameController.playerChoice = Humphrey;
            dialogue.initial = this.dialogueHumphrey;
        }
        else if(name == "Kelley")
        {
            GameController.playerChoice = Kelley;
            dialogue.initial = this.dialogueKelley;
        }
        
        dialogue.StartDialogue();

        choice.SetActive(false);
    }
}
