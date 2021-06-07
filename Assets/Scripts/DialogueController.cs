using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DialogueController : MonoBehaviour
{
    [SerializeField] Text name, message;
    [SerializeField] Image img;
    public Queue<Dialogue> sentences;
    [SerializeField]public  Dialogue[] initial;
    [SerializeField]public  GameObject OpenFinally;
    [SerializeField] GameObject finish;
    AudioSource aud;

    Animator anim;
    [SerializeField] bool open;
    // Start is called before the first frame update
    void Start()
    {
        aud = this.gameObject.AddComponent<AudioSource>();
        aud.clip = Resources.Load("tic") as AudioClip;
        sentences = new Queue<Dialogue>();
        anim = GetComponent<Animator>();
        anim.SetBool("Open", true);
        StartDialogue();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            DisplayNextSentence();
        }
    }

    public void StartDialogue()
    {
        try { GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().enabled = false; } catch { }
        anim.SetBool("Open", true);

        sentences.Clear();

        foreach (Dialogue sentence in initial)
        {
            sentences.Enqueue(sentence);            
        }        

        DisplayNextSentence();

    }

    public void DisplayNextSentence()
    {        
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        Dialogue sentence = sentences.Dequeue();
        name.text = sentence.name;
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence.sentences));
        img.sprite = sentence.sprite;
    }

    IEnumerator TypeSentence(string sentence)
    {
        message.text = "";
        foreach(char letter in sentence.ToCharArray())
        {
            aud.Play();
            message.text += letter;
            yield return .02f;
        }
    }

    public void EndDialogue()
    {
        try { GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().enabled = true; } catch { }
        anim.SetBool("Open", false);
        if (SceneManager.GetActiveScene().name == "Lab-01" || SceneManager.GetActiveScene().name == "Lab-02" || SceneManager.GetActiveScene().name == "Fase2-level3")
        {
            if (OpenFinally != null)
            {
                OpenFinally.SetActive(true);
                OpenFinally = null;
            }
            else if (GameController.playerChoice != null)
            {
                finish.SetActive(true);
            }
        }
    }
}
