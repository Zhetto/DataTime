using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GarotaBar : MonoBehaviour
{
    GameObject player;
    Vector3 scaleRight,scaleLeft;
    // Start is called before the first frame update
    void Start()
    {
        scaleRight = this.transform.localScale;
        scaleLeft = new Vector3(scaleRight.x * -1, scaleRight.y, scaleRight.z);
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if(player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player");
        }
        if(this.transform.position.x > player.transform.position.x)
        {
            this.transform.localScale = scaleLeft;
        }
        else
        {
            this.transform.localScale = scaleRight;
        }
    }
}
