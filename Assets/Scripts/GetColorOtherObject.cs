using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GetColorOtherObject : MonoBehaviour
{
    [SerializeField]
    SpriteRenderer parent;
    SpriteRenderer sprite;
    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(this.parent.color.a != this.sprite.color.a)
        {
            this.sprite.color = this.parent.color;
        }
    }
}
