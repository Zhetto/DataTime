using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndDrop : MonoBehaviour
{
    [SerializeField]
    GameObject currentPiece;
    Vector3 mousePosition;
    RaycastHit2D hit;
    public static bool mouseDown,check;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        
        if (Input.GetMouseButtonDown(0))
        {
            mouseDown = true;
            hit = Physics2D.Raycast(mousePosition,Vector2.zero);

            if (hit.transform.gameObject.CompareTag("piece") && !hit.transform.gameObject.GetComponent<Pieces>().right)
            {
                currentPiece = hit.transform.gameObject;
            }
            
        }
        if (Input.GetMouseButtonUp(0))
        {
            if (currentPiece.CompareTag("piece"))
            {
                check = true;
            }
            mouseDown = false;
            currentPiece = null;            
            //mousePosition = new Vector3(mousePosition.x, mousePosition.y, 0);
            //currentPiece.transform.position = mousePosition;
        }

        if (currentPiece != null)
        {
            mousePosition = new Vector3(mousePosition.x, mousePosition.y, -.1f);
            currentPiece.transform.position = mousePosition;
        }
    }
}
