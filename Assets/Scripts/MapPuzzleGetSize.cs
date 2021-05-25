using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapPuzzleGetSize : MonoBehaviour
{
    [SerializeField]
    GameObject pieces;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.localScale.x>=2 || transform.localScale.y >= 2)
        {
            //Debug.Log("Activate pieces");
            pieces.SetActive(true);
            this.enabled = false;
        }
    }
}
