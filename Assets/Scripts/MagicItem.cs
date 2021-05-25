using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicItem : MonoBehaviour
{
    bool active;
    bool collect;
    SpriteRenderer sprite;
    [SerializeField]float colorForce;
    Color color;
    [SerializeField] GameObject uiEnemy, enemyController, platforms;
    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        color = new Color(colorForce, colorForce, colorForce, colorForce);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (active)
        {
            if (Input.GetKeyDown(GameController.getKeyCode(LoadControl.Control.resumeKey)))
            {
                collect = true;
            }
        }

        if (collect)
        {
            sprite.color -= color;
            if (sprite.color.a <= 0)
            {
                enemyController.SetActive(true);
                uiEnemy.SetActive(true);
                platforms.SetActive(false);
                //Debug.Log("Liberar inimigos");
                Destroy(this);
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
