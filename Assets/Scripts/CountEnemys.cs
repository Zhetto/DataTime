using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountEnemys : MonoBehaviour
{
    [SerializeField] FinishLevel script;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (EnemyController.diedEnemys >= 10)
        {
            script.enabled = true;
            Destroy(this);
        }
    }
}
