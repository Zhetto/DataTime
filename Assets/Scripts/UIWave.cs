using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIWave : MonoBehaviour
{
    [SerializeField]
    Image fillEnemyLife;
    [SerializeField]
    float forceFill,currentFill,targetFill;
    bool init,decrease;
    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        init = true;
        decrease = false;
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        targetFill = 1-((EnemyController.diedEnemys * (float)100) / EnemyController.maxEnemy) / 100;
        //Debug.Log(targetFill.ToString()+decrease);
        currentFill = fillEnemyLife.fillAmount;
        if (init)
        {
            fillEnemyLife.fillAmount += forceFill;
            if (fillEnemyLife.fillAmount >= 1)
            {
                init = false;
                decrease = true;
            }            
        }
        if (decrease)
        {
            if (currentFill > targetFill)
            {
                fillEnemyLife.fillAmount -= forceFill;
                if (fillEnemyLife.fillAmount <= 0)
                {
                    anim.SetBool("down", true);
                    if (!anim.GetCurrentAnimatorStateInfo(0).IsName("down"))
                    {
                        Destroy(this.gameObject);
                    }
                }
            }           
        }
    }
}
