using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Checkpoint : MonoBehaviour
{
    public static int restLife { get; set; }
    public static string lastLevelName { get; set; }

    void Awake()
    {
        if (!PlayerPrefs.HasKey("restLife"))
        {
            resetKeys();
        }

        restLife = PlayerPrefs.GetInt("restLife");
        lastLevelName = PlayerPrefs.GetString("lastLevelName");
    }

    // Start is called before the first frame update
    void Start()
    {
        if (SceneManager.GetActiveScene().name != "Menu")
        {
            
            Debug.Log("Antes RestLife: " + restLife + " lastLevelName: " + lastLevelName);
            alterLastLevelName(SceneManager.GetActiveScene().name);
            Debug.Log("Depois RestLife: " + restLife + " lastLevelName: " + lastLevelName);
        }else if(SceneManager.GetActiveScene().name == "Menu" || SceneManager.GetActiveScene().name == "Lab-Final")
        {
            Cursor.visible = true;
        }
    }

    public static void decreaseRestLife()
    {
        restLife--;
        if (restLife <= 0)
        {
            resetKeys();
        }
        else
        {
            PlayerPrefs.SetInt("restLife", restLife);
        }
    }

    static void alterLastLevelName(string name)
    {
        lastLevelName = name;
        PlayerPrefs.SetString("lastLevelName", lastLevelName);
    }

    public static void resetKeys()
    {
        PlayerPrefs.SetString("Player", "Nenhum");
        PlayerController.laranjaUsos = 0;
        Debug.Log("Resetou");
        PlayerPrefs.SetInt("restLife", 3);
        PlayerPrefs.SetString("lastLevelName", "Lab-01");
        lastLevelName = PlayerPrefs.GetString("lastLevelName");
    }
}
