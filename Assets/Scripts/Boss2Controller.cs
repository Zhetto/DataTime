using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss2Controller : MonoBehaviour
{
    [SerializeField] Image fill,fillSecond;
    [SerializeField] GameObject finish;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Orb.vidaTotal == 0)
        {
            fillSecond.enabled = true;
        }
        fill.fillAmount = (float)Orb.vidaTotal / 12;
        if (fillSecond.enabled)
        {
            fillSecond.fillAmount = (float)Boss2.vida / 10;
            if (fillSecond.fillAmount == 0)
            {
                finish.SetActive(true);
                Destroy(this.gameObject);
            }
        }
    }
}
