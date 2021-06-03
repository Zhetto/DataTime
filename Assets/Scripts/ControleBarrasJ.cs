using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ControleBarrasJ : MonoBehaviour
{
    public Slider vidaSlidder;
    public Slider sedeSlider;
    public int qntVida = 3;
    public int qntSede = 10;
    float tempoSede;
    public PlayerController odre;

    // Start is called before the first frame update
    void Start()
    {
        if(SceneManager.GetActiveScene().name == "Egito2")
        {
            qntSede = 20;
        }
        vidaSlidder = GameObject.FindObjectsOfType<Slider>()[1];
        sedeSlider = GameObject.FindObjectsOfType<Slider>()[0];
        vidaSlidder.value = qntVida;
        sedeSlider.value = qntSede;
        sedeSlider.maxValue = qntSede;
        tempoSede = qntSede;
    }

    // Update is called once per frame
    void Update()
    {
        tempoSede -= Time.deltaTime;
        sedeSlider.value = tempoSede;

        if (sedeSlider.value <= 0)
        {
            Debug.Log("Você morreu Desidratado");
            Checkpoint.decreaseRestLife();
            SceneManager.LoadScene("Menu");
        }

        if (vidaSlidder.value <= 0)
        {
            Checkpoint.decreaseRestLife();
            SceneManager.LoadScene("Menu");
        }

        if (Input.GetKeyDown(KeyCode.E) && odre.temOdre == true && odre.odreUsos > 0)
        {
            odre.odreUsos --;
            Debug.Log(odre.odreUsos);
            tempoSede = 20;
        }
    }

    public void Dano()
    {
        vidaSlidder.value -= 1;
    }

    public void RecuperaVida()
    {
        vidaSlidder.value += 1;
    }
}
