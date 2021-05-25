using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pieces : MonoBehaviour
{
    enum location {right,left,down }
    [SerializeField]
    location loc;
    [SerializeField]
    Vector3 rightPosition;
    public bool right;
    [SerializeField]AudioClip correct, paper;
    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.AddComponent<BoxCollider2D>();
        rightPosition = this.transform.position;
        switch (loc)
        {
            case location.left:
                transform.position = new Vector3(Random.Range(10.0f, 11.3f), Random.Range(-5.0f, -8.0f), -.1f);
                break;
            case location.right:
                transform.position = new Vector3(Random.Range(15.7f, 17.0f), Random.Range(-5.0f, -8.0f), -.1f);
                break;
            default:
                transform.position = new Vector3(Random.Range(10.0f, 17.0f), Random.Range(-7.5f, -8.0f), -.1f);
                break;
        }        
        right = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Vector3.Distance(this.transform.position, rightPosition) < 0.2f && !DragAndDrop.mouseDown && !right)
        {           
            right = true;
            this.GetComponent<BoxCollider2D>().enabled = false;
                        
        }     
        if (right)
        {
            this.transform.position = Vector3.MoveTowards(this.transform.position,rightPosition,.03f);
            if(this.transform.position == rightPosition)
            {                
                Puzzle.counter++;
                Debug.Log(Puzzle.counter);
                this.enabled = false;
                if (Puzzle.counter < 30)
                {
                    AudioController.PlaySound(correct);
                }
                else
                {
                    AudioController.PlaySound(paper);
                }
            }            
        }
    }
}
