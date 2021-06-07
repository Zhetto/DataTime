using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Room : MonoBehaviour
{
    SpriteRenderer sprite;
    [SerializeField] SpriteRenderer madame;
    public bool show,go,opened;
    Camera cam;
    Vector3 initialPosition;
    [SerializeField] SpriteRenderer chair;
    [SerializeField] float forceColor, forceExpand,limitExpandMax,limitExpandMin,forceGo;
    [SerializeField] Text text;
    [SerializeField] GameObject[] objects;
    [SerializeField] DialogueController dialog;
    [SerializeField] Dialogue[] Kelley, Humphrey;
    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        show = false;
        cam = Camera.main;
        go = false;

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (go)
        {            
            if (show)
            {
                cam.GetComponent<MoveCamera>().enabled = false;
                if (sprite.color.a < 1)
                {
                    sprite.color += new Color(0, 0, 0, forceColor);
                }

                if (madame.color.a < 1)
                {
                    madame.color += new Color(0, 0, 0, forceColor);
                }
                if (cam.orthographicSize > limitExpandMin)
                {
                    cam.orthographicSize -= forceExpand;
                }
                if (cam.transform.position.x != this.transform.position.x)
                {
                    //Debug.Log("Ir até o quarto");
                    Vector3 partial = new Vector3(this.transform.position.x, this.transform.position.y, cam.transform.position.z);
                    cam.transform.position = Vector3.MoveTowards(cam.transform.position, partial, forceGo);
                }
            }
            else
            {
                if (sprite.color.a > 0)
                {
                    sprite.color -= new Color(0, 0, 0, forceColor);
                }
                if (madame.color.a > 0)
                {
                    madame.color -= new Color(0, 0, 0, forceColor);
                }
                if (cam.orthographicSize < limitExpandMax)
                {
                    cam.orthographicSize += forceExpand;
                }
                if (cam.transform.position != initialPosition)
                {
                    //Debug.Log("Ir até o quarto");
                    cam.transform.position = Vector3.MoveTowards(cam.transform.position, initialPosition, forceGo);
                }
                else
                {
                    cam.GetComponent<MoveCamera>().enabled = true;
                    if (sprite.color.a <= 0)
                    {
                        go = false;
                    }
                }
            }
        }
    }

    private void LateUpdate()
    {
        if (Input.GetKeyDown(KeyCode.E) && show && !opened)
        {
            opened = true;
            go = true;
            chair.enabled = false;
            text.text = "";
            this.gameObject.transform.GetChild(0).gameObject.SetActive(true);
            foreach(GameObject item in objects)
            {
                item.SetActive(false);
            }
            GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>().SetBool("Walk", false);
            dialog.initial = GameController.playerChoice.name == "Kelley" ? Kelley : Humphrey ;
            dialog.StartDialogue();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            initialPosition = cam.transform.position;
            show = true;
            text.text = "Pressione E para entrar no quarto";
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            foreach (GameObject item in objects)
            {
                item.SetActive(true);
            }
            opened = false;
            Debug.Log("Saiu do quarto");
            show = false;            
            chair.enabled = true;
            text.text = "";
            this.gameObject.transform.GetChild(0).gameObject.SetActive(false);
            
        }
    }
}
