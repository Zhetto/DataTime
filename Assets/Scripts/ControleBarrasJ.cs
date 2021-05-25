using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ControleBarrasJ : MonoBehaviour
{
    public Slider sedeSlider;
    public int qntSede = 10;
    float tempoSede;
    public int qntVida = 3;
    public Slider vidaSlidder;
    public PlayerControllerJ odre;

    // Start is called before the first frame update
    void Start()
    {
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
            SceneManager.LoadScene("Menu");
        }

        if (vidaSlidder.value <= 0)
        {
            SceneManager.LoadScene("Menu");
        }

        if (Input.GetKey(KeyCode.E) && odre.temOdre == true && odre.odreUsos > 0)
        {
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
