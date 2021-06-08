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
    public AudioSource consumir;
    public static string morteMotivo;

    // Start is called before the first frame update
    void Start()
    {
        if(SceneManager.GetActiveScene().name == "Egito2")
        {
            consumir = GameObject.FindGameObjectWithTag("COdre").GetComponent<AudioSource>();
            qntSede = 30;
        }

        if (SceneManager.GetActiveScene().name != "Lab-01"){
            vidaSlidder = GameObject.FindGameObjectWithTag("BarraVida").GetComponent<Slider>();
            sedeSlider = GameObject.FindGameObjectWithTag("BarraSede").GetComponent<Slider>();
        }
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

        if (sedeSlider.value <= 0 && SceneManager.GetActiveScene().name != "Menu")
        {
            morteMotivo = "Você Morreu Desidratado. Beba Água!";
            Debug.Log("Você morreu Desidratado");
            Checkpoint.decreaseRestLife();
            qntVida = 3;
            SceneManager.LoadScene("GameOver");
        }

        if (vidaSlidder.value <= 0 && SceneManager.GetActiveScene().name != "Menu")
        {
            morteMotivo = "Você Morreu ao levar Dano.";
            qntVida = 3;
            Checkpoint.decreaseRestLife();
            SceneManager.LoadScene("GameOver");
        }

        if (Input.GetKeyDown(KeyCode.F) && odre.temOdre == true && odre.odreUsos > 0)
        {
            consumir.Play();
            odre.odreUsos --;
            Debug.Log(odre.odreUsos);
            tempoSede = 30;
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
