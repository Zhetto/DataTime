using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mira : MonoBehaviour
{
    Vector3 scale,scaleMax,scaleMin,partial,partialPosition;
    [SerializeField] float force;
    bool expand;
    // Start is called before the first frame update
    void Start()
    {
        scale = this.transform.localScale;
        scaleMax = scale * 1.1f;
        scaleMin = scale *0.9f;
        expand = true;
        partial = new Vector3(force, force, 0);
        Cursor.visible = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        partialPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        partialPosition.z = 0;
        this.transform.position = partialPosition;
        if (this.transform.localScale.x > scaleMax.x)
        {
            expand = false;
        }
        else if(this.transform.localScale.x < scaleMin.x)
        {
            expand = true;
        }

        this.transform.localScale = expand ? this.transform.localScale +=partial : this.transform.localScale -= partial ;
    }
}
