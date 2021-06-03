using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Room : MonoBehaviour
{
    SpriteRenderer sprite;
    public bool show,go;
    Camera cam;
    Vector3 initialPosition;
    [SerializeField] SpriteRenderer chair;
    [SerializeField] float forceColor, forceExpand,limitExpandMax,limitExpandMin,forceGo;
    [SerializeField] Text text;
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

    private void LateUpdate()
    {
        if (Input.GetKeyDown(KeyCode.E) && show)
        {
            go = true;
            chair.enabled = false;
            text.text = "";
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
            Debug.Log("Saiu do quarto");
            show = false;            
            chair.enabled = true;
            text.text = "";
        }
    }
}
