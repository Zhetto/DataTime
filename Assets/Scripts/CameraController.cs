using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Transform playerTransform;
    [SerializeField]
    float force;
    Vector3 temp;


    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (!GameController.Pause)
        {
            temp = Vector3.MoveTowards(this.transform.position, playerTransform.transform.position, force);
            this.transform.position = new Vector3(temp.x, temp.y+.3f, -10);
            //this.temp = transform.position;
            //if (playerTransform.position.x > minLimit.x && playerTransform.position.x < maxLimit.x)
            //{
            //    temp.x = playerTransform.position.x;
            //}

            //if (playerTransform.position.y > minLimit.y && playerTransform.position.y < maxLimit.y)
            //{
            //    temp.y = playerTransform.position.y+3;
            //}

            //this.transform.position = temp;
        }
    }
}