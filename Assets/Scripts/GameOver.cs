using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public Text textoGO,textoContinue;

    // Start is called before the first frame update
    void Start()
    {
        textoGO.text = ControleBarrasJ.morteMotivo.ToString();
        if (Checkpoint.lastLevelName == "Lab-01")
        {
            textoContinue.text = "Você perdeu todas as vidas, presisone \" ESPAÇO\" para voltar ao menu";
        }
        else
        {
            textoContinue.text = "Você ainda possui " + Checkpoint.restLife + " vida(s), presisone \" ESPAÇO\" para continuar";
        }
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (Checkpoint.lastLevelName == "Lab-01")
            {
                SceneManager.LoadScene("Menu");
            }
            else
            {
                SceneManager.LoadScene(Checkpoint.lastLevelName);
            }            
        }
    }
}
