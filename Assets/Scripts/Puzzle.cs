using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle : MonoBehaviour
{
    public bool show;
    Camera cam;
    CameraController camController;
    SpriteRenderer spr;
    Color color;
    GameObject player;
    Vector3 partial;
    [SerializeField] FinishLevel finish;
    [SerializeField]
    float forceColor,force, strech;
    public static int counter;
    // Start is called before the first frame update
    void Start()
    {
        counter = 0;
        cam = FindObjectOfType<Camera>();
        camController = cam.GetComponent<CameraController>();
        spr = GetComponent<SpriteRenderer>();
        color = new Color(0, 0, 0, forceColor);
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (counter == 30)
        {
            //Implementar mecânicas após concluir o quebra cabeças
            finish.enabled = true;
            counter++;
            GameObject.Find("MapPuzzle").GetComponent<Animator>().SetBool("open", false);

        }
        if (show)
        {
            if (spr.color.a < 1)
            {
                spr.color += color;
            }
            if (camController.enabled)
            {
                camController.enabled = false;
            }
            //if (cam.transform.position.x != this.transform.position.x)
            //{
            //    partial = Vector3.MoveTowards(cam.transform.position, this.transform.position, force);
            //    cam.transform.position = new Vector3(partial.x, partial.y, -10);
            //}
            if (cam.orthographicSize > 2.5 && cam.transform.position.x != this.transform.position.x)
            {
                cam.orthographicSize -= strech;
                partial = Vector3.MoveTowards(cam.transform.position, this.transform.position, force);
                cam.transform.position = new Vector3(partial.x, partial.y, -10);
            }
        }
        else
        {
            if (spr.color.a > 0)
            {
                spr.color -= color;
            }           
            if (cam.orthographicSize < 5)
            {
                cam.orthographicSize += strech;            }

            if (cam.transform.position.x == player.transform.position.x)
            {
                cam.GetComponent<CameraController>().enabled = true;
                this.show = true;
                this.enabled = false;
            }
            else
            {
                partial = Vector3.MoveTowards(cam.transform.position, player.transform.position, force);
                cam.transform.position = new Vector3(partial.x, partial.y + .3f, -10);
            }
        }
    }
}
