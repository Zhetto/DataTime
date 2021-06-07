using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MagicItem : MonoBehaviour
{
    bool active;
    bool collect;
    SpriteRenderer sprite;
    [SerializeField]float colorForce;
    Color color;
    [SerializeField] Text text;
    [SerializeField] GameObject uiEnemy, enemyController, platforms,madame;
    [SerializeField] DialogueController dialog;
    [SerializeField] Dialogue[] Kelley, Humphrey;
    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        color = new Color(colorForce, colorForce, colorForce, colorForce);
    }

    // Update is called once per frame
    void FixedUpdate()
    {


        if (collect)
        {
            sprite.color -= color;
            if (sprite.color.a <= 0)
            {
                //enemyController.SetActive(true);
                uiEnemy.SetActive(true);
                platforms.SetActive(false);
                //Debug.Log("Liberar inimigos");
                Destroy(this);
            }
        }
    }

    private void LateUpdate()
    {
        if (active)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                collect = true;
                madame.SetActive(true);
                madame.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
                madame.transform.position += Vector3.down*2f;
                madame.transform.position += Vector3.left * 4f;
                dialog.OpenFinally = enemyController;
                dialog.initial = GameController.playerChoice.name == "Kelley" ? Kelley : Humphrey;
                dialog.StartDialogue();
                Camera.main.orthographicSize = 3.7f;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            active = true;
            text.text = "Pressione E para coletar o item";
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
