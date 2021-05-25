using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Comet : MonoBehaviour
{
    CameraController camController;
    GameObject player;
    [SerializeField]
    GameObject counterInit;
    GameObject comet, explosion;
    [SerializeField]
    GameObject enemyController,enemyUi;
    float time,delay;
    // Start is called before the first frame update
    void Start()
    {
        time = 0;
        delay = 5;
        player = GameObject.FindGameObjectWithTag("Player");
        comet = this.gameObject.transform.GetChild(0).gameObject;
        explosion = this.gameObject.transform.GetChild(1).gameObject;
        camController = FindObjectOfType<Camera>().GetComponent<CameraController>();
    }

    private void FixedUpdate()
    {
        if(time!=0)
        {
            if (Time.time < time + delay)
            {
                //Debug.Log("O personagem ainda não pode se mover");
                GameController.TimeInit = (int)(time + delay - Time.time);
                //Active Counter init
                counterInit.SetActive(true);
            }
            else
            {
                //Debug.Log("O personagem pode se mover");
                //Active move player
                player.GetComponent<PlayerController>().enabled = true;
                if (enemyController != null)
                {
                    enemyController.SetActive(true);
                    enemyUi.SetActive(true);
                }
                Destroy(this.gameObject);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            camController.enabled = true;
            Destroy(comet);
            explosion.SetActive(true);
            player.SetActive(true);
            this.GetComponent<BoxCollider2D>().enabled = false;
            player.transform.position = new Vector3(this.transform.position.x, this.transform.position.y +2, this.transform.position.z);
            time = Time.time;

        }
    }
}
