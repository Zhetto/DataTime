using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    SpriteRenderer sprite;
    public bool show,go;
    Camera cam;
    Vector3 initialPosition;
    [SerializeField] SpriteRenderer chair;
    [SerializeField] float forceColor, forceExpand,limitExpandMax,limitExpandMin,forceGo;
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
        if (Input.GetKeyDown(GameController.getKeyCode(LoadControl.Control.resumeKey)) && show)
        {
            go = true;
            chair.enabled = false;
        }
        if (go)
        {
            
            if (show)
            {
                cam.GetComponent<MoveCamera>().enabled = false;
                if (sprite.color.a < 1)
                {
                    sprite.color += new Color(0, 0, 0, forceColor);
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
                    go = false;
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            initialPosition = cam.transform.position;
            show = true;           
            
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Saiu do quarto");
            show = false;            
            chair.enabled = true;
        }
    }
}
